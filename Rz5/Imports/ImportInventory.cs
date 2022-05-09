using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Core;
using NewMethod;
using System.Data.SqlClient;
using System.Data.Common;

namespace Rz5
{
    public partial class ImportInventory
    {
        //Public Virtual Variables
        public virtual string PartNumberAliases
        {   //Aliases for use in deciding if column is PartNumber
            get { return "part|number|mfgpart|mpn|mfgptnum|pn"; }
        }
        public virtual string QuantityAliases
        {   //Aliases for use in deciding if column is Quantity
            get { return "qty|quantity|quanity"; }
        }
        public virtual string ManufacturerAliases
        {   //Aliases for use in deciding if column is Manufacturer
            get { return "mfg|mfr|manufacturer|brand|mani|mf"; }
        }
        public virtual string DateCodeAliases
        {   //Aliases for use in deciding if column is DateCode
            get { return "dc|datecode|date_code"; }
        }
        public virtual string PriceAliases
        {   //Aliases for use in deciding if column is Price
            get { return "price"; }
        }
        public virtual string CostAliases
        {   //Aliases for use in deciding if column is Cost
            get { return "cost"; }
        }
        public virtual string AlternatePartAliases
        {   //Aliases for use in deciding if column is AlternatePart
            get { return "alternate|internal"; }
        }
        public virtual string PackagingAliases
        {   //Aliases for use in deciding if column is Packaging
            get { return "packag|pkg"; }
        }
        public virtual string DescriptionAliases
        {   //Aliases for use in deciding if column is Description
            get { return "desc"; }
        }

        public virtual string BuyPurchaseIDAliases
        {   //Aliases for use in deciding if column is the buy_purchase_id
            get { return "buy_purchase_id|poid|orderid_purchase"; }
        }

        public virtual string BuyPurchaseOrdernumberAliases
        {   //Aliases for use in deciding if column is the buy_purchase_ordernumber
            get { return "buy_purchase_ordernumber|ponumber|ordernumber_purchase"; }
        }



        //Public Variables
        public Enums.StockType CurrentType = Enums.StockType.Any;
        public DataTable dtPast;
        public bool bPast = false;
        public bool refreshpastlist = false;
        public int sortColumn = -1;
        public ArrayList SelectedIDs;
        public ArrayList Exports;
        public exporttemplate CurrentExport;
        public long ImportPriority = 0;

        //KT Refactored from RzSensible        
        public string consignmentCode;
        public string buy_purchase_id;
        public string buy_purchase_ordernumber;

        //Stock Vendor information
        public string companyName;
        public string base_company_uid;

        //Constructors
        public ImportInventory()
        {
        }
        //Public Virtual Functions
        public virtual bool Init(Enums.StockType type)
        {
            CurrentType = type;
            return true;
        }
        //KT REfactored from RzSensible
        //Private Functions
        private bool HasExistingConsignment(ContextRz context, string id)
        {
            if (!Tools.Strings.StrExt(id))
                return false;
            int i = context.Data.SelectScalarInt32("select count(*) from partrecord where importid = '" + context.Filter(id) + "'");
            return i > 0;
        }

        public virtual int RunImport(ContextRz context, nDataTable dt, string id, string user_name, string comp_id, string cont_id)
        {   //Main Import function
            RunImport_Before(context, id); //Do pre-preparation logic
            if (!Tools.Strings.StrExt(id))
                return 0;
            companycontact ct = GetImportCompanyInfo(context, comp_id, cont_id);//Get companycontact info for import
            if (ct == null)
            {
                switch (CurrentType)
                {
                    case Enums.StockType.Consign:
                    case Enums.StockType.Excess:
                    case Enums.StockType.Offers:
                        return 0;
                }
            }
            NewMethod.n_user u = GetImportUserInfo(context, user_name);//Get agent for import

            if (u == null)
            {
                if (!context.TheLeader.AskYesNo("No agent was found. Do you want to assign an agent before importing?"))
                    return 0;
            }
            int ret = RunImport_Inventory(context, dt, ct, user_name, id);//Import all else (Inv)
            string tbl = "partrecord";
            if (Tools.Strings.StrCmp(CurrentType.ToString(), "offers"))
                tbl = "offer";
            RunImport_After(context, id, tbl);//Do after import logic (colors,sorting,etc)
            return ret;
        }
        public virtual void RunImport_Before(ContextRz context, string id)
        {   //Adds the importid column to partrecord
            context.Execute("alter table partrecord alter column importid varchar(255)", true);
            //KT Refactored from RzSensible
            if (CurrentType != Rz5.Enums.StockType.Consign)
                return;
            if (HasExistingConsignment(context, id))
            {
                if (!context.TheLeader.AskYesNo("A consignment list by the name " + id + " already exists. Do you want to delete the older list?"))
                    return;
                context.Execute("delete from partrecord where importid = '" + context.Filter(id) + "'");
            }


        }
        public virtual void RunImport_After(ContextRz context, string id, string table_name)
        {   //Update color and sorting information
            //KT Refactored from RzSensible.  This line was before the base.Runinport_After, so I'm putting on top.


            if (CurrentType == Enums.StockType.Consign)
            {
                if (!string.IsNullOrEmpty(this.consignmentCode))
                    context.Execute("update partrecord set consignment_code='" + consignmentCode + "' where importid ='" + context.Filter(id) + "'");
                else
                    throw new Exception("Error: Import complete, but consignment code not set.  Please notify warehouse management or it.");
                SaveConsignmentManifest(context, id);
            }
            if (CurrentType == Enums.StockType.Stock)
            {
                //buy_id, buy_ordernumber, companyID, companyname
                context.Execute("update partrecord set buy_purchase_id='" + buy_purchase_id + "', buy_purchase_ordernumber='" + buy_purchase_ordernumber + "' , companyname='" + this.companyName + "' , base_company_uid='" + base_company_uid + "' where importid ='" + context.Filter(id) + "'");
                //SaveImportManifest(context, id);
            }
            if (CurrentType == Enums.StockType.Offers)
            {
                context.Execute("update partrecord set isoffer=1  where importid ='" + context.Filter(id) + "'");

            }

            //Update the partrecord table to trigger recall
            UpdatePartsTriggerRecall(context, id);

            Int32 colur = CalcColorByType();
            if (colur != 0)
                UpdateColor(context, table_name, colur, id);
            UpdateSort(table_name, GetSort(CurrentType), id);


        }

        private void UpdatePartsTriggerRecall(ContextRz context, string id)
        {
            ArrayList partsList = context.QtC("partrecord", "select * from partrecord where importid = '" + id + "'");
            foreach (partrecord p in partsList)
            {
                //This should not only update the correct date_created, but also fire the change history, which doesn't happen by default on imports.
                p.date_created = p.datecreated;
                p.Update(context);
            }
        }

        private void SaveConsignmentManifest(ContextRz context, string id)
        {
            DataTable dt = context.Select("select * from partrecord where importid = '" + id + "'");
            if (dt.Rows.Count > 0)
            {
                try
                {
                    string sql = "insert into consignment_manifest(unique_id, fullpartnumber, quantity, manufacturer, cost, price, datecode, basenumber, stocktype, basenumberstripped, alternatepart, userdata_01, datecreated, datemodified, packaging, location, description, agentname, consignment_code, base_company_uid, vendorname, companyname, companycontactname, base_companycontact_uid, alternatepartstripped, rohs_info, the_purchase_uid, quantityallocated, allocated_notes, quantity_available, importid) ";
                    sql += "select unique_id, fullpartnumber, quantity, manufacturer, cost, price, datecode, basenumber, stocktype, basenumberstripped, alternatepart, userdata_01, datecreated, datemodified, packaging, location, description, agentname, consignment_code, base_company_uid, vendorname, companyname, companycontactname, base_companycontact_uid, alternatepartstripped, rohs_info, the_purchase_uid, quantityallocated, allocated_notes, quantity_available, importid from partrecord where importid = '" + id + "'";
                    context.Execute(sql);
                    context.Execute("update consignment_manifest set consignment_code='" + this.consignmentCode + "' where importid ='" + context.Filter(id) + "'");
                    context.Leader.Tell("Consignment Manifest successfully created");
                }
                catch (Exception ex)
                {
                    context.Leader.Tell(ex.Message);
                }
            }
        }

        public virtual int RunImport_Inventory(ContextRz context, nDataTable dt, companycontact ct, string user_name, string id)
        {   //Import inv items (excess,etc)
            PartImportArgs args = null;
            //if (Tools.Strings.StrCmp(CurrentType.ToString(), "offers"))
            //    args = new PartImportArgs("offer", false);
            //else
            args = new PartImportArgs("partrecord", false);

            //if (stocktype == Enums.StockType.Consign)
            //    dv.ImportObjects(context, "consignment_manifest", "unique_id", props, a, ref count, args.ExtraWhere);


            args.priority = ImportPriority;
            //KT - Set "IgnoreMissingQuantityField" to True
            if (Tools.Strings.StrCmp(CurrentType.ToString(), "master"))
                args.IgnoreMissingQuantityField = true;


            //Tag the aquisition_agent And aquisition_agent_uid
            if (context.Leader.AskYesNo("Would you like to tag this import list  to an agent?"))
            {
                n_user au = (n_user)frmChooseUser.ChooseUser();
                if (au != null)
                {
                    args.AcquisitionAgent = au;

                    ////Lock company for purchases to prevent accidentally cutton PO's for these.  Joey says it should be safe
                    //company c = (company)context.QtO("company", "select * from company where unique_id = '" + ct.base_company_uid + "'");
                    //if (c == null)
                    //    throw new Exception("No company found to lock for list aquisition purchases.");
                    //if (!c.islocked_purchase)
                    //{
                    //    c.islocked_purchase = true;
                    //    c.Update(context);
                    //}



                }

            }

            ImportParts(context, dt, CurrentType, ct, user_name, id, args);
            //if (CurrentType.ToString() == "Consign")//Duplicate this import into the consingn_manifest database.
            //{
            //    nDataTable CloneDT = dt;
            //    args.TableName = "consignment_manifest";
            //    ImportParts(context, dt, CurrentType, ct, user_name, id, args);//Actually, instead of fresh import, need to copy over the imported table so unqiue_id is same for linkage
            //}
            //dv.SetStatus("Finishing...");
            dt.ConvertToText();
            dt.RefreshFromDatabase(context);
            context.TheLeader.Tell("Done: " + Tools.Number.LongFormat(args.AcceptedCount) + " records were imported.");
            return Convert.ToInt32(args.AcceptedCount);
        }

        public virtual companycontact GetImportCompanyInfo(ContextRz context, string comp_id, string cont_id)
        {   //Get companycontact info for import
            companycontact ct = companycontact.GetById(context, cont_id);//companycontact.New(context);
            if (ct == null)
                throw new Exception("COuld not find companycontact associated with ID: " + cont_id);
            if (CurrentType != Enums.StockType.Stock && CurrentType != Enums.StockType.WebPart)
            {
                company xCompany = company.GetById(context, comp_id);
                if (xCompany != null)
                {
                    ct.companyname = xCompany.companyname;
                    ct.base_company_uid = xCompany.unique_id;
                    companycontact xContact = companycontact.GetById(context, cont_id);
                    if (xContact != null)
                    {
                        ct.contactname = xContact.contactname;
                        ct.primaryemailaddress = xContact.primaryemailaddress;
                        ct.primaryphone = xContact.primaryphone;
                        ct.primaryfax = xContact.primaryfax;
                        ct.unique_id = xContact.unique_id;
                    }
                    if (!Tools.Strings.StrExt(ct.contactname))
                        ct.contactname = xCompany.primarycontact;
                    if (!Tools.Strings.StrExt(ct.primaryemailaddress))
                        ct.primaryemailaddress = xCompany.primaryemailaddress;
                    if (!Tools.Strings.StrExt(ct.primaryphone))
                        ct.primaryphone = xCompany.primaryphone;
                    if (!Tools.Strings.StrExt(ct.primaryfax))
                        ct.primaryfax = xCompany.primaryfax;
                    GetImportCompanyInfo_After(xCompany);
                }
                else
                {
                    context.TheLeader.Tell("Please choose a company and optionally a contact before continuing.");
                    return null;
                }
            }
            return ct;
        }
        public virtual void GetImportCompanyInfo_After(company c)
        {
            //Run after companycontact info for extra logic
        }
        public virtual NewMethod.n_user GetImportUserInfo(ContextRz context, string user_name)
        {   //Get agent info for import
            if (!Tools.Strings.StrExt(user_name))
                return null;
            return NewMethod.n_user.GetByName(context, user_name);
        }
        public virtual void ArchiveSelected(ContextRz context, ArrayList selected_ids, string table_name, ref long count)
        {   //Archive all selected imports

            if (selected_ids == null)
                throw new Exception("");

            if (selected_ids.Count <= 0)
                throw new Exception("");

            String strIn = Tools.Data.GetIn(selected_ids);
            if (!Tools.Strings.StrExt(strIn))
                throw new Exception("ArchiveSelected: strIn is empty");

            String strSQL = GetArchiveSQL(strIn);
            long x = 0;
            string s = "";
            context.Execute(strSQL);
            DeleteSelected(context, selected_ids, table_name, ref count);
        }
        public virtual void DeleteSelected(ContextRz context, ArrayList selected_ids, string table_name, ref long count)
        {   //Delete all selected imports

            if (selected_ids == null || selected_ids.Count <= 0)
                throw new Exception("");

            String strIn = nTools.GetIn(selected_ids);
            if (!Tools.Strings.StrExt(strIn))
            {
                context.TheLeader.Tell("DeleteSelected: strIn is empty");
                return;
            }
            string s = "";
            context.Execute("delete from " + table_name + " where isnull(importid, '') in (" + strIn + ")");
        }
        public virtual long CountSelected(ContextRz context, ArrayList selected_ids, string table_name)
        {   //Get count for all selected imports
            if (selected_ids == null)
                return 0;
            if (selected_ids.Count <= 0)
                return 0;
            String s = nTools.GetIn(selected_ids);
            if (!Tools.Strings.StrExt(s))
                return 0;
            return context.SelectScalarInt64("select count(*) from " + table_name + " where isnull(importid, '') in (" + s + ")");
        }
        public virtual string GetImportName(ContextRz context, string username, string companyname)
        {   //Get name for this import
            if (!Tools.Strings.StrExt(username))
                username = context.xUser.name;
            string build = "[Auto]" + CurrentType.ToString();
            build += " on " + System.DateTime.Now.Year.ToString() + "-" + System.DateTime.Now.Month.ToString() + "-" + System.DateTime.Now.Day.ToString() + " " + nTools.TimeFormat(System.DateTime.Now);
            if (CurrentType != Enums.StockType.Stock)
            {
                if (Tools.Strings.StrExt(companyname))
                    build += " from " + companyname;
            }
            if (Tools.Strings.StrExt(username))
                build += " by " + username;
            return build;
        }
        public virtual void UpdateList(ContextRz context, partrecord p)
        {   //Update color for list by partrecord
            if (p == null)
                return;
            Int32 colur = partrecord.CalcColorByType(p.StockType, p.isarchivereq);
            context.Execute("update partrecord set grid_color = " + colur.ToString() + " where importid = '" + context.Filter(p.unique_id) + "'");
        }
        public virtual void UpdateColor(ContextRz context, string table, Int32 colur, string import_id)
        {   //Update color for list by import_id
            context.Execute("update " + table + " set grid_color = " + colur.ToString() + " where importid = '" + context.Filter(import_id) + "'");
        }
        public virtual void UpdateSort(string table, Int32 sort, string import_id)
        {
            //Update sort for list by import_id
        }
        public virtual Int32 GetSort(Enums.StockType t)
        {
            return -1;
        }
        public virtual DataTable GetPastDataTable(ContextRz context, string type)
        {
            return GetImportStatsTable(context);
        }
        public virtual void UpdateArchivable(company c)
        {

        }
        public virtual void AddPastItemNoSummary(DataRow r, System.Windows.Forms.ListViewItem i)
        {
            i.SubItems.Add("");
        }
        public virtual void CalcPast(ContextRz context, String type, ref long count)
        {
            dtPast = GetPastDataTable(context, type);
            if (Tools.Data.DataTableExists(dtPast))
                count = dtPast.Rows.Count;
            else
                count = 0;
        }
        public virtual void LoadExports(ContextRz context)
        {
            Exports = context.QtC("exporttemplate", "select * from exporttemplate where exportname > '' order by exportname");
        }
        public virtual DataTable GetImportStatsTable(ContextRz context)
        {
            context.Execute("drop table temp_past_stock_calc", true);
            context.Execute("select distinct(importid) as [importid] into temp_past_stock_calc from partrecord where isnull(importid, '') > ''");// order by importid");
            context.Execute("alter table temp_past_stock_calc add vendor_name varchar(255), total_count int, is_telecom bit, unique_id varchar(255), icon_index int, grid_color int, stocktype varchar(255)");
            context.Execute("update temp_past_stock_calc set unique_id = newid()");
            context.Execute("update temp_past_stock_calc set total_count = (select count(*) from partrecord where partrecord.importid = temp_past_stock_calc.importid)");
            //context.Execute("update temp_past_stock_calc set is_telecom = 0");
            //context.Execute("update temp_past_stock_calc set is_telecom = 1 where exists( select * from partrecord where partrecord.importid = temp_past_stock_calc.importid and isnull(isarchivereq, 0) = 1 )");
            context.Execute("update R set R.stocktype = P.stocktype from temp_past_stock_calc as R inner join partrecord as P on R.importid = P.importid");
            context.Execute("update R set R.vendor_name = p.companyname from temp_past_stock_calc as R inner join partrecord as P on R.importid = P.importid");
            return context.Select("select importid, vendor_name, total_count, stocktype from temp_past_stock_calc where isnull(importid, '') > '' order by vendor_name");
        }
        public virtual DataTable GetImportStatsTable(ContextRz context, String tablename)
        {
            if (!Tools.Strings.StrExt(tablename))
                tablename = "partrecord";
            context.Execute("drop table temp_past_stock_calc", true);
            context.Execute("select distinct(importid) as [importid] into temp_past_stock_calc from " + tablename + " where isnull(importid, '') > '' order by importid");
            context.Execute("alter table temp_past_stock_calc add total_count int, is_telecom bit");
            context.Execute("update temp_past_stock_calc set total_count = (select count(*) from " + tablename + " where " + tablename + ".importid = temp_past_stock_calc.importid)");
            context.Execute("update temp_past_stock_calc set is_telecom = 0");
            context.Execute("update temp_past_stock_calc set is_telecom = 1 where exists( select * from " + tablename + " where " + tablename + ".importid = temp_past_stock_calc.importid and isnull(" + tablename + ".isarchivereq, 0) = 1 )");
            return context.Select("select importid, total_count, is_telecom from temp_past_stock_calc where isnull(importid, '') > '' order by importid");
        }
        public virtual DataTable GetImportOffersTable(ContextRz context)
        {
            context.Execute("drop table temp_past_offer_calc", true);
            context.Execute("select distinct(importid) as [importid] into temp_past_offer_calc from offer where isnull(importid, '') > '' order by importid");
            context.Execute("alter table temp_past_offer_calc add total_count int");
            context.Execute("update temp_past_offer_calc set total_count = (select count(*) from offer where offer.importid = temp_past_offer_calc.importid)");
            return context.Select("select importid, total_count from temp_past_offer_calc where isnull(importid, '') > '' order by importid");
        }
        public virtual exporttemplate AddNewExport(ContextRz context)
        {
            exporttemplate x = exporttemplate.New(context);
            x.exportname = "New Export";
            x.exporttotext = false;
            x.exportstring = "select fullpartnumber as [Part], quantity as [Quantity], manufacturer as [Manufacturer], datecode as [datecode] from partrecord where quantity > 0 and stocktype in ('stock', 'excess', 'oem', 'consigned', 'consign') and len(isnull(fullpartnumber, '')) > 2 order by fullpartnumber, quantity";
            x.exportfile = @"c:\parts.xls";
            context.Insert(x);
            return x;
        }
        public virtual String GetColumnList(ContextRz context, String fromtable, String totable)
        {
            try
            {
                String col = "";
                DataTable df = context.Select("select top 1 * from " + fromtable);
                DataTable dt = context.Select("select top 1 * from " + totable);
                if (df == null)
                    return col;
                if (dt == null)
                    return col;
                foreach (DataColumn dc in dt.Columns)
                {
                    if (df.Columns.Contains(dc.ColumnName))
                    {
                        if (Tools.Strings.StrExt(col))
                            col += "," + dc.ColumnName;
                        else
                            col += dc.ColumnName;
                    }
                }
                return col;
            }
            catch { return ""; }
        }
        public virtual Boolean AllSameVendors(ContextRz context)
        {
            String id = "";
            foreach (String s in SelectedIDs)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                if (!Tools.Strings.StrExt(id))
                    id = context.SelectScalarString("select base_company_uid from partrecord where importid = '" + context.Filter(s) + "'");
                else
                {
                    Boolean b = Tools.Strings.StrCmp(id, context.SelectScalarString("select base_company_uid from partrecord where importid = '" + context.Filter(s) + "'"));
                    if (!b)
                        return false;
                }
            }
            return true;
        }
        public virtual String GetCurrentTable()
        {
            switch (CurrentType)
            {
                case Enums.StockType.Stock:
                case Enums.StockType.Consign:
                case Enums.StockType.Buy:
                case Enums.StockType.Excess:
                //KT
                case Enums.StockType.Master:
                    return "partrecord";
                case Enums.StockType.Archive:
                case Enums.StockType.Offers:
                    return "offer";
                case Enums.StockType.WebPart:
                    return "web_parts";
                default:
                    return "";
            }
        }
        public virtual Boolean ImportExists(ContextRz context, string id)
        {
            if (!Tools.Strings.StrExt(id))
                return false;
            String SQL = "select count(*) from ";
            String table = GetCurrentTable();
            if (!Tools.Strings.StrExt(table))
                SQL = "";
            else
                SQL += table + " where importid = '" + context.Filter(id) + "'";
            Int64 i = 0;
            if (Tools.Strings.StrExt(SQL))
                i = context.SelectScalarInt64(SQL);
            return i > 0;
        }
        public virtual Int32 CalcColorByType()
        {
            return partrecord.CalcColorByType(CurrentType);
        }
        public virtual void RunPartCrossReference(ContextRz context, ListView.SelectedListViewItemCollection lv)
        {
            if (lv == null)
                return;
            if (lv.Count <= 0)
                return;
            PartCrossReferenceSearchOptions p = new PartCrossReferenceSearchOptions();
            p.SQL_Table = "partrecord";
            p.SQL_PartField = "prefix+basenumberstripped";
            string in_where = "";
            foreach (ListViewItem l in lv)
            {
                if (Tools.Strings.StrExt(in_where))
                    in_where += ",'" + l.Text + "'";
                else
                    in_where += "'" + l.Text + "'";
            }
            if (!Tools.Strings.StrExt(in_where))
                return;
            p.SQL_Where = "importid in (" + in_where + ")";
            p.SQL_KeyFieldValue = lv[0].Text;

            context.Leader.ShowPartCrossReference(context, p);
        }
        public virtual void ImportParts(ContextRz context, nDataTable dv, Enums.StockType stocktype, companycontact contactinfo, String strAgent, String strImportID, PartImportArgs args)
        {   //Actually import parts           
            PrepareImportParts(context, dv, args, stocktype);
            SetExtraImportStuff(context, dv, stocktype, contactinfo, strAgent, strImportID, args);
            FilterImportParts(context, dv, args, false);
            ImportFilteredParts(context, dv, contactinfo, stocktype, args);
        }
        public virtual void PrepareImportParts(ContextRz context, nDataTable dv, PartImportArgs args, Enums.StockType stocktype)
        {
            //check for a part number
            if (!dv.HasColumnField("fullpartnumber"))
            {
                if (!dv.HasColumnField("prefix") || !dv.HasColumnField("basenumber"))
                    throw new Exception("No valid part field combination");
                else
                    args.PrefixBase = true;
            }
            else
                args.PrefixBase = false;

            //check for a quantity            
            if (!dv.HasColumnField("quantity"))
            {
                //Offers will sometimes not have QTY.  Sometimes they will however, whicih is why I can't leverage the IgNoreMissingQty field for all Offers, only when no qty detected
                //For Offers, not QTY is possible and valid, else we need to check overrride quantity 
                if (stocktype == Enums.StockType.Offers)
                    args.IgnoreMissingQuantityField = true;
                if (!args.IgnoreMissingQuantityField)
                {
                    //throw new Exception("No quantity column");
                    //KT - When no QTY, the import was failing
                    context.Leader.Tell("Please make sure you have a valid quanitiy to import");
                    return;
                }



            }
            dv.RemoveBlurb("?");
            dv.RemoveBlurb("€");
            dv.RemoveBlurb("xxx");
            //switch to table mode and set the field names
            dv.SetActualFieldNames(context);
            dv.FormalizeFieldTypes(context);

            //if (Tools.Strings.StrExt(s))
            //    args.AddLog(s);

            args.ImportCount = dv.Count;
            args.AcceptedCount = 0;
            args.RejectedCount = 0;
        }
        public virtual void SetExtraImportStuff(ContextRz context, nDataTable dv, Enums.StockType stocktype, companycontact contactinfo, String strAgent, String strImportID, PartImportArgs args)
        {
            //set the stock type
            dv.xData.Execute("alter table " + dv.TableName + " add stocktype varchar(255)", true);
            dv.xData.Execute("update " + dv.TableName + " set stocktype = '" + stocktype.ToString() + "' where isnull(stocktype, '') not in ('stock', 'excess', 'consign', 'buy') " + args.ExtraWhere);
            //set the import id
            dv.xData.Execute("alter table " + dv.TableName + " add importid varchar(255)", true);
            dv.xData.Execute("update " + dv.TableName + " set importid = '" + dv.xData.SyntaxFilter(strImportID) + "' where unique_id <> 'not an id' " + args.ExtraWhere);

            //set the agent
            dv.xData.Execute("alter table " + dv.TableName + " add agentname varchar(255)", true);
            dv.SetFieldIfBlank("agentname", strAgent);
            dv.xData.Execute("alter table " + dv.TableName + " add partsetup varchar(255)", true);
            //Set Stock Purchase Info
            if (stocktype == Enums.StockType.Stock)
            {
                dv.xData.Execute("alter table " + dv.TableName + " add buy_purchase_id varchar(255)", true);
                dv.xData.Execute("alter table " + dv.TableName + " add buy_purchase_ordernumber varchar(255)", true);
                dv.SetFieldIfBlank("agentname", strAgent);
                dv.xData.Execute("alter table " + dv.TableName + " add agentname varchar(255)", true);
                dv.SetFieldIfBlank("agentname", strAgent);
            }
            SetContactInfo(dv, contactinfo);
            ////Auqisition Agent
            //if (args.AcquisitionAgent != null)
            //    SetListAcquisitionAgent(dv, args.AcquisitionAgent);




        }

        private void SetListAcquisitionAgent(nDataTable dv, ArrayList a, n_user acquisitionAgent)
        {
            //set the stock type
            ////List Aquisition Agent
            a.Add("list_acquisition_agent");
            a.Add("list_acquisition_agent_uid");
            a.Add("split_commission_type");
            dv.xData.Execute("alter table " + dv.TableName + " add list_acquisition_agent varchar(255)", true);
            dv.xData.Execute("alter table " + dv.TableName + " add list_acquisition_agent_uid varchar(255)", true);
            dv.xData.Execute("alter table " + dv.TableName + " add split_commission_type varchar(255)", true);
            dv.xData.Execute("update " + dv.TableName + " set list_acquisition_agent = '" + acquisitionAgent.name + "'");
            dv.xData.Execute("update " + dv.TableName + " set list_acquisition_agent_uid = '" + acquisitionAgent.unique_id + "'");
            //dv.xData.Execute("update " + dv.TableName + " set list_acquisition_agent_uid = '" + SM_Enums.SplitCommissionType.list_acquisition.ToString() + "'");
        }

        public virtual bool ImportFilteredParts(ContextRz context, nDataTable dv, companycontact contactinfo, Enums.StockType stocktype, PartImportArgs args)
        {
            //KT This is confusing to me, but here are some things I've noticed:
            //The ArrayList a, is a list of properties.  If the prop is not in the Arraylist (a) then it won't get imported.
            //I believe the content from the DataView dv, gets copied over to the ArrayList (a).  If a is missing a field, it will get missed.
            //Since ArrayList is instantiated here, you need can either, add to the DV prior to the process, or you can do it here.


            long count = 0;
            ArrayList a = new ArrayList();
            a.Add("fullpartnumber");
            //KT - MAster parts need no QTY
            if (!args.IgnoreMissingQuantityField == true)
                a.Add("quantity");
            //KT Master Parts need an internal partnumber
            a.Add("internalpartnumber");
            a.Add("prefix");
            a.Add("basenumber");
            a.Add("basenumberstripped");
            a.Add("datecreated");
            a.Add("date_created");
            a.Add("companycontactname");
            a.Add("companyemailaddress");
            a.Add("companyfax");
            a.Add("companyname");
            a.Add("companyphone");
            a.Add("base_company_uid");
            a.Add("base_companycontact_uid");
            a.Add("agentname");
            a.Add("stocktype");
            a.Add("importid");
            //added 2009_10_27  how on earth were these missing?
            a.Add("description");
            a.Add("category");
            a.Add("condition");
            a.Add("packaging");

            dv.AddField("description");
            dv.AddField("category");
            dv.AddField("condition");
            dv.AddField("packaging");

            dv.AddField("cost", "float", "0");
            dv.AddField("price", "float", "0");

            dv.AddField("manufacturer");
            dv.AddField("datecode");
            dv.AddField("userdata_01");
            dv.AddField("userdata_02");
            dv.AddField("location");
            dv.AddField("internalcomment");
            //KT - Adding this to the temp_table
            dv.AddField("internalpartnumber");

            a.Add("cost");
            a.Add("price");
            a.Add("manufacturer");
            a.Add("datecode");
            a.Add("userdata_01");
            a.Add("userdata_02");
            a.Add("location");
            a.Add("internalcomment");

            a.Add("partsetup");
            dv.AddField("partsetup");
            dv.SetFieldIfBlank("partsetup", "");



            //Auqisition Agent
            if (args.AcquisitionAgent != null)
                SetListAcquisitionAgent(dv, a, args.AcquisitionAgent);





            if (stocktype == Enums.StockType.Stock)
            {
                a.Add("buy_purchase_id");
                a.Add("buy_purchase_ordernumber");
            }

            try
            {
                if (dv.FieldExists("alternatepart"))
                {
                    StripAltParts(dv);
                    a.Add("alternatepart");
                    a.Add("alternatepartstripped");
                }
            }
            catch { }

            List<CoreVarValAttribute> props = null;
            //if (Tools.Strings.StrCmp(args.TableName, "offer")) // && !Rz3App.xLogic.IsPMT)

            //{
            //    a.Add("contactname");
            //    a.Add("phonenumber");
            //    a.Add("faxnumber");
            //    dv.AddField("contactname");
            //    dv.AddField("phonenumber");
            //    dv.AddField("faxnumber");
            //    dv.SetFieldIfBlank("contactname", contactinfo.contactname);
            //    dv.SetFieldIfBlank("phonenumber", contactinfo.primaryphone);
            //    dv.SetFieldIfBlank("faxnumber", contactinfo.primaryfax);
            //    props = context.TheSysRz.VarVals("partrecord");
            //    dv.ImportObjects(context, "offer", "unique_id", props, a, ref count);
            //}
            ////else if (Tools.Strings.StrCmp(args.TableName, "consignment_manifest"))
            ////{
            ////    //props = context.TheSys.VarVals("partrecord");    //include system fields like date_created
            ////    //String tablename = args.TableName.ToLower();
            ////    //dv.ImportObjects(context, tablename, "unique_id", props, a, ref count, args.ExtraWhere);
            ////    //Partrecord import occurs 1st, so I shoul dhave those and the unqiue_ids, just need to copy this table to new table.
            ////    //Fill datatable witcontexth this import
            ////    //DataTable dt = context.Select("select * from partrecord where importid =  '" + p + "'" + x.TheData.Filter(i.Uid) + "'");
            ////    //Insert that datatable into consignment_manifest
            ////}
            //else
            //{
            String tablename = "";
            props = context.TheSys.VarVals("partrecord");   //include system fields like date_created

            tablename = args.TableName.ToLower();

            //if (Rz3App.xLogic.IsPMT && stocktype == Enums.StockType.Offers)
            //    tablename = "partrecord_offer";
            //if (Rz3App.xLogic.IsAAT && stocktype == Enums.StockType.WebPart)
            //    tablename = "web_parts";

            dv.ImportObjects(context, tablename, "unique_id", props, a, ref count, args.ExtraWhere);
            //}
            args.AcceptedCount = count;
            return true;
        }
        public void StripAltParts(nDataTable dv)
        {
            if (!dv.FieldExists("alternatepart"))
                return;
            dv.xData.Execute("alter table " + dv.TableName + " add alternatepartstripped varchar(255)", true);
            dv.xData.Execute("update " + dv.TableName + " set alternatepartstripped = replace(replace(replace(alternatepart, '-', ''), '\', ''), '/', '')", true);
        }
        public virtual void FilterImportParts(ContextRz context, nDataTable dv, PartImportArgs args, bool reinsert_alternates)
        {
            long count = 0;
            //part number
            if (args.PrefixBase)
            {
                PartObject.BuildPartNumber(dv);
                if (reinsert_alternates)
                {
                    PartObject.ReInsertAlternates(dv);
                    PartObject.ParsePartNumber(context, dv, args.Silent, ref count);
                }
            }
            else
            {
                if (reinsert_alternates)
                    PartObject.ReInsertAlternates(dv);
                PartObject.ParsePartNumber(context, dv, args.Silent, ref count);
            }
            if (count > 0)
            {
                args.AddLog(context, Tools.Number.LongFormat(count) + " rows deleted by blank base number criteria.");
                args.RejectedCount += count;
            }

            dv.CheckCriteria(context, "have no part number", "isnull(fullpartnumber, '') = ''", ref count);
            if (count > 0)
            {
                args.AddLog(context, Tools.Number.LongFormat(count) + " rows deleted by blank part number criteria.");
                args.RejectedCount += count;
            }

            dv.CheckCriteria(context, "have no base number", "temp_flagged = -1", ref count);
            if (count > 0)
            {
                args.AddLog(context, Tools.Number.LongFormat(count) + " rows deleted by blank base number criteria.");
                args.RejectedCount += count;
            }

            FilterBadPartNumbers(context, dv, ref count);
            if (count > 0)
            {
                args.AddLog(context, Tools.Number.LongFormat(count) + " rows deleted by bad part number criteria.");
                args.RejectedCount += count;
            }

            if (dv.HasColumnField("quantity"))
            {
                dv.CheckCriteria(context, "have no valid quantity", "quantity <= 0", ref count);
                if (count > 0)
                {
                    args.AddLog(context, Tools.Number.LongFormat(count) + " rows deleted by valid quantity criteria.");
                    args.RejectedCount += count;
                }
            }
            //datecreated
            dv.xData.Execute("alter table " + dv.TableName + " add datecreated datetime", true);
            dv.xData.Execute("update " + dv.TableName + " set datecreated = getdate() where datecreated is null or isdate(datecreated) = 0 or datediff(d, datecreated, cast('01/01/1900' as datetime)) = 0");

            //set the date
            dv.xData.Execute("alter table " + dv.TableName + " add date_created datetime", true);
            dv.xData.Execute("update " + dv.TableName + " set date_created = getdate() where date_created is null or isdate(date_created) = 0 or datediff(d, date_created, cast('01/01/1900' as datetime)) = 0");
        }
        public virtual void SetContactInfo(nDataTable dv, companycontact contactinfo)
        {
            //set the company and contact
            dv.AddField("companycontactname");
            dv.AddField("contactname");
            dv.AddField("companyemailaddress");
            dv.AddField("companyfax");
            dv.AddField("companyname");
            dv.AddField("companyphone");
            dv.AddField("base_company_uid");
            dv.AddField("base_companycontact_uid");
            if (contactinfo != null)
            {
                dv.SetFieldIfBlank("companycontactname", contactinfo.contactname);
                dv.SetFieldIfBlank("contactname", contactinfo.contactname);
                dv.SetFieldIfBlank("companyemailaddress", contactinfo.primaryemailaddress);
                dv.SetFieldIfBlank("companyfax", contactinfo.primaryfax);
                dv.SetFieldIfBlank("companyname", contactinfo.companyname);
                dv.SetFieldIfBlank("companyphone", contactinfo.primaryphone);
                dv.SetFieldIfBlank("base_company_uid", contactinfo.base_company_uid);
                dv.SetFieldIfBlank("base_companycontact_uid", contactinfo.unique_id);
            }
        }




        //private void SetListAcquisitionAgent(nDataTable dv, n_user acquisitionAgent)
        //{
        //    //List Aquisition Agent
        //    //Add Props to the DataView
        //    dv.AddField("list_acquisition_agent");
        //    dv.AddField("list_acquisition_agent_uid");           
        //    //Add the properties to the temp table.
        //    dv.xData.Execute("alter table " + dv.TableName + " add list_acquisition_agent varchar(255)", true);
        //    dv.xData.Execute("alter table " + dv.TableName + " add list_acquisition_agent_uid varchar(255)", true);
        //    //Set the Values
        //    dv.SetFieldIfBlank("list_acquisition_agent", acquisitionAgent.name);
        //    dv.SetFieldIfBlank("list_acquisition_agent_uid", acquisitionAgent.unique_id);
        //}


        public virtual void FilterBadPartNumbers(ContextRz context, nDataTable d, ref long count)
        {
            count = 0;
            String strWhere = " fullpartnumber is null or (len(fullpartnumber) < 4 and fullpartnumber like '%n%a%') or fullpartnumber = 'part number' or fullpartnumber like '%pull' or fullpartnumber like '%refurb' or fullpartnumber like '%pulls' or fullpartnumber like '%refurbs' ";

            Int64 l = d.xData.GetScalar_Long("select count(*) from " + d.TableName + " where " + strWhere);
            if (l > 0)
            {
                if (!context.TheLeader.AskYesNo(Tools.Number.LongFormat(l) + " items appear to have invalid part numbers ('n/a', 'part number', etc), and will be removed.  Do you want to continue?"))
                    return;
            }
            else
                return;

            d.xData.Execute("delete from " + d.TableName + " where " + strWhere, ref count);
        }
        //Protected Virtual Functions
        protected virtual string GetArchiveSQL(string strIn)
        {
            if (!Tools.Strings.StrExt(strIn))
                return "";
            String strSQL = "insert into offer( ";
            strSQL += " unique_id, ";
            strSQL += " fullpartnumber, ";
            strSQL += " quantity, ";
            strSQL += " prefix, ";
            strSQL += " basenumber, ";
            strSQL += " basenumberstripped, ";
            strSQL += " manufacturer, ";
            strSQL += " datecode, ";
            strSQL += " condition, ";
            strSQL += " packaging, ";
            strSQL += " partsetup, ";
            strSQL += " datecreated, ";
            strSQL += " isoffer, ";
            strSQL += " partsperpack, ";
            strSQL += " alternatepart, ";
            strSQL += " description, ";
            strSQL += " location, ";
            strSQL += " cost, ";
            strSQL += " price, ";
            strSQL += " companyname, ";
            strSQL += " contactname, ";
            strSQL += " phonenumber, ";
            strSQL += " faxnumber, ";
            strSQL += " importid, ";
            strSQL += " userdata_01, ";
            strSQL += " userdata_02, ";
            strSQL += " userdata_03, ";
            strSQL += " userdata_04, ";
            strSQL += " userdata_05, ";
            strSQL += " userdata_06, ";
            strSQL += " emailaddress) ";
            strSQL += " select ";
            strSQL += " left(unique_id, 50), ";
            strSQL += " left(fullpartnumber, 50), ";
            strSQL += " quantity, ";
            strSQL += " left(prefix, 50), ";
            strSQL += " left(basenumber, 50), ";
            strSQL += " left(basenumberstripped, 50), ";
            strSQL += " left(manufacturer, 50), ";
            strSQL += " left(datecode, 50), ";
            strSQL += " left(condition, 50), ";
            strSQL += " left(packaging, 50), ";
            strSQL += " left(partsetup, 50), ";
            strSQL += " datecreated, ";
            strSQL += " 1 as isoffer, ";
            strSQL += " partsperpack, ";
            strSQL += " left(alternatepart, 50), ";
            strSQL += " left(description, 50), ";
            strSQL += " left(location, 50), ";
            strSQL += " cost, ";
            strSQL += " price, ";
            strSQL += " left(companyname, 50), ";
            strSQL += " left(companycontactname, 50), ";
            strSQL += " left(companyphone, 50), ";
            strSQL += " left(companyfax, 50), ";
            strSQL += " left(importid, 50), ";
            strSQL += " left(userdata_01, 50), ";
            strSQL += " left(userdata_02, 50), ";
            strSQL += " left(userdata_03, 50), ";
            strSQL += " left(userdata_04, 50), ";
            strSQL += " left(userdata_05, 50), ";
            strSQL += " left(userdata_06, 50), ";
            strSQL += " left(companyemailaddress, 50) ";
            strSQL += " from partrecord where isnull(importid, '') in (" + strIn + ") ";
            return strSQL;
        }
        //Public Classes
        public class DeleteArgs
        {
            public String delete_from = "offer";
            public String delete_caption = "Offer";
        }
        public class MoveArgs
        {
            public String movetable = "";
            public String fromtable = "";
        }
    }
}
