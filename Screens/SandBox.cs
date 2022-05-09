using System;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Web;
using NewMethod;
using Tools.Database;
using HubspotApis;
using System.Dynamic;
using CoreWin;
using System.Linq;
using Core;
using Rz5.Enums;
using SensibleDAL;
using RzInterfaceWin.Dialogs;
using static SM_Enums;

namespace Rz5
{
    public partial class SandBox : UserControl
    {
        Int64 total = 0;
        Int64 current = 0;
        HubspotApi hsa = new HubspotApi();
        ContextRz TheContext
        {
            get { return RzWin.Context; }
        }
        public SandBox()
        {
            InitializeComponent();
        }
        //Private Functions
        public void Init()
        {

        }
        private void InitStrippedAlternates(String strTable)
        {
            RzWin.Leader.Comment("Stripping alternates on " + strTable + "...");
            RzWin.Context.Execute("alter table " + strTable + " add alternatepartstripped varchar(255)", true);
            RzWin.Context.Execute("update " + strTable + " set alternatepartstripped = alternatepart where isnull(alternatepartstripped, '') = ''");
            nTools.StripField((DataConnectionSqlServer)RzWin.Context.Data.TheConnection, strTable, "alternatepartstripped");
        }
        private Int32 GetRandomQty(Int32 low, Int32 high)
        {
            try
            {
                Random RandomClass = new Random();
                return RandomClass.Next(low, high);
            }
            catch (Exception)
            {
                return 1;
            }
        }
        private void QBCompanyImport()
        {

            try
            {
                RzWin.Leader.Comment("Gathering Company List From QBs");
                ArrayList comp = RzWin.Context.TheSysRz.TheQuickBooksLogic.GetCompanyCollection(RzWin.Context);
                RzWin.Leader.Comment("Gathering Vendor List From QBs");
                ArrayList vend = RzWin.Context.TheSysRz.TheQuickBooksLogic.GetVendorCollection(RzWin.Context);
                ArrayList all = MergeArrayLists(comp, vend);
                RzWin.Leader.Comment("Finished Merging Lists; Importing..");
                foreach (company c in all)
                {
                    company ex = company.FindACompany(TheContext, c.companyname, c.primaryphone, c.primaryfax, c.primaryemailaddress);
                    if (ex != null)
                    {
                        RzWin.Leader.Comment("Updating information for company : " + ex.companyname);
                        UpdateCompanyInfo(ex, c);
                        continue;
                    }
                    RzWin.Leader.Comment("Adding company : " + c.companyname);
                    c.Update(RzWin.Context);
                    if (Tools.Strings.StrExt(c.primarycontact))
                    {
                        companycontact cc = (companycontact)TheContext.QtO("companycontact", "select * from companycontact where base_company_uid = '" + c.unique_id + "' and contactname = '" + RzWin.Context.Filter(c.primarycontact) + "'");
                        if (cc == null)
                        {
                            cc = companycontact.New(RzWin.Context);
                            cc.base_company_uid = c.unique_id;
                            cc.base_mc_user_uid = c.base_mc_user_uid;
                            cc.companyname = c.companyname;
                            cc.contactname = c.primarycontact;
                            cc.primaryphone = c.primaryphone;
                            cc.primaryfax = c.primaryfax;
                            cc.primaryemailaddress = c.primaryemailaddress;
                            cc.is_qbimport = true;
                            cc.Insert(RzWin.Context);
                        }
                    }
                    if (c.QB_BillingAddress != null)
                    {
                        c.QB_BillingAddress.base_company_uid = c.unique_id;
                        c.QB_BillingAddress.Update(RzWin.Context);
                    }
                    if (c.QB_ShippingAddress != null)
                    {
                        c.QB_ShippingAddress.base_company_uid = c.unique_id;
                        c.QB_ShippingAddress.Update(RzWin.Context);
                    }
                }
                RzWin.Context.Logic.CacheCompanies(RzWin.Context);
                RzWin.Leader.Comment("Done.");
            }
            catch (Exception ee)
            {
                RzWin.Leader.Comment("Error: " + ee.Message);
            }
        }
        private void QBJustCompanyImport()
        {
            RzWin.Context.Reorg();
            //try
            //{
            //    RzWin.Leader.Comment("Gathering Company List From QBs");
            //    ArrayList comp = RzWin.Context.TheSysRz.TheQuickBooksLogic.GetCompanyCollection(RzWin.Context);
            //    RzWin.Leader.Comment("Finished Merging Lists; Importing..");
            //    foreach (company c in comp)
            //    {
            //        company ex = company.FindACompany(RzWin.Context, c.companyname, c.primaryphone, c.primaryfax, c.primaryemailaddress);
            //        if (ex != null)
            //        {
            //            RzWin.Leader.Comment("Updating information for company : " + ex.companyname);
            //            UpdateCompanyInfo(ex, c);
            //            continue;
            //        }
            //        RzWin.Leader.Comment("Adding company : " + c.companyname);
            //        c.ISave();
            //        if (Tools.Strings.StrExt(c.primarycontact))
            //        {
            //            companycontact cc = (companycontact)RzWin.Context.xSys.QtO("companycontact", "select * from companycontact where base_company_uid = '" + c.unique_id + "' and contactname = '" + c.primarycontact + "'");
            //            if (cc == null)
            //            {
            //                cc = new companycontact(RzWin.Context.xSys);
            //                cc.base_company_uid = c.unique_id;
            //                cc.base_mc_user_uid = c.base_mc_user_uid;
            //                cc.companyname = c.companyname;
            //                cc.contactname = c.primarycontact;
            //                cc.primaryphone = c.primaryphone;
            //                cc.primaryfax = c.primaryfax;
            //                cc.primaryemailaddress = c.primaryemailaddress;
            //                cc.is_qbimport = true;
            //                cc.ISave();
            //            }
            //        }
            //        if (c.QB_BillingAddress != null)
            //        {
            //            c.QB_BillingAddress.base_company_uid = c.unique_id;
            //            c.QB_BillingAddress.ISave();
            //        }
            //        if (c.QB_ShippingAddress != null)
            //        {
            //            c.QB_ShippingAddress.base_company_uid = c.unique_id;
            //            c.QB_ShippingAddress.ISave();
            //        }
            //    }
            //    RzApp.CacheCompanies(TheContext);
            //    RzWin.Leader.Comment("Done.");
            //}
            //catch (Exception ee)
            //{
            //    RzWin.Leader.Comment("Error: " + ee.Message);
            //}
        }
        private void QBSalesImport(Boolean bRemove, DateTime date_cutoff)
        {
            try
            {
                if (bRemove)
                    RemoveRzOrders("sales");
                RzWin.Leader.Comment("Gathering Sales Orders From QBs");
                ArrayList sales = RzWin.Context.TheSysRz.TheQuickBooksLogic.GetSalesOrderCollection(RzWin.Context, date_cutoff);
                RzWin.Leader.Comment("Done.");
            }
            catch (Exception ee)
            {
                RzWin.Leader.Comment("Error: " + ee.Message);
                RzWin.Leader.Tell("Error: " + ee.Message);
            }
        }
        private void QBEstimateImport(Boolean bRemove)
        {
            try
            {
                if (bRemove)
                    RemoveRzOrders("quote");
                RzWin.Leader.Comment("Gathering Esimates From QBs");
                ArrayList sales = RzWin.Context.TheSysRz.TheQuickBooksLogic.GetEstimateCollection(RzWin.Context);
                RzWin.Leader.Comment("Done.");
            }
            catch (Exception ee)
            {
                RzWin.Leader.Comment("Error: " + ee.Message);
                RzWin.Leader.Tell("Error: " + ee.Message);
            }
        }//FormalQuotes
        private void QBCreditMemoImport(Boolean bRemove)
        {
            try
            {
                if (bRemove)
                    RemoveRzOrders("rma");
                RzWin.Leader.Comment("Gathering RMAs From QBs");
                ArrayList sales = RzWin.Context.TheSysRz.TheQuickBooksLogic.GetCreditMemoCollection(RzWin.Context);
                RzWin.Leader.Comment("Done.");
            }
            catch (Exception ee)
            {
                RzWin.Leader.Comment("Error: " + ee.Message);
                RzWin.Leader.Tell("Error: " + ee.Message);
            }
        }//RMAs
        private void QBPurchaseImport(Boolean bRemove, DateTime date_cutoff)
        {
            QBPurchaseImport(bRemove, date_cutoff, RzWin.Form.TheContextNM);
        }
        private void QBPurchaseImport(Boolean bRemove, DateTime date_cutoff, ContextNM x)
        {
            try
            {
                if (bRemove)
                    RemoveRzOrders("purchase");
                x.TheLeader.TellTemp("Starting Import.");
                RzWin.Leader.Comment("Gathering Purchase Orders From QBs");
                ArrayList purchases = RzWin.Context.TheSysRz.TheQuickBooksLogic.GetPurchaseOrderCollection(RzWin.Context, date_cutoff);
                RzWin.Leader.Comment("PO Import Complete");
                x.TheLeader.TellTemp("PO Import Complete");
            }
            catch (Exception ee)
            {
                RzWin.Leader.Comment("Error: " + ee.Message);
                RzWin.Leader.Tell("Error: " + ee.Message);
            }
        }
        private void QBInvoiceImport(Boolean bRemove, DateTime date_cutoff)
        {
            try
            {
                if (bRemove)
                    RemoveRzOrders("invoice");
                RzWin.Context.TheLeader.TellTemp("Starting Import.");
                RzWin.Leader.Comment("Gathering Invoices From QBs");
                ArrayList invoices = RzWin.Context.TheSysRz.TheQuickBooksLogic.GetInvoiceOrderCollection(RzWin.Context, date_cutoff);
                RzWin.Leader.Comment("Done.");
                RzWin.Context.TheLeader.TellTemp("Invoice Import Complete.");
            }
            catch (Exception ee)
            {
                RzWin.Leader.Comment("Error: " + ee.Message);
                RzWin.Leader.Tell("Error: " + ee.Message);
            }
        }
        private void UpdateCompanyInfo(company a, company b)
        {
            try
            {
                if (a == null || b == null)
                    return;
                if (!Tools.Strings.StrExt(a.primarycontact))
                    a.primarycontact = b.primarycontact;
                if (!Tools.Strings.StrExt(a.primaryphone))
                    a.primaryphone = b.primaryphone;
                if (!Tools.Strings.StrExt(a.primaryfax))
                    a.primaryfax = b.primaryfax;
                if (!Tools.Strings.StrExt(a.primaryemailaddress))
                    a.primaryemailaddress = b.primaryemailaddress;
                if (!Tools.Strings.StrExt(a.termsascustomer))
                    a.termsascustomer = b.termsascustomer;
                if (!Tools.Strings.StrExt(a.termsasvendor))
                    a.termsasvendor = b.termsasvendor;
                a.Update(RzWin.Context);
            }
            catch (Exception)
            {
            }
        }
        private ArrayList MergeArrayLists(ArrayList a, ArrayList b)
        {
            ArrayList z = new ArrayList();
            foreach (object o in a)
            {
                z.Add(o);
            }
            foreach (object o in b)
            {
                z.Add(o);
            }
            return z;
        }
        private void RemoveRzOrders(String type)
        {
            if (!Tools.Strings.StrExt(type))
                return;

            String SQL = "delete from ordhed_" + type + " where ordertype = '" + type + "'";
            RzWin.Context.Execute(SQL);
            SQL = "delete from orddet_" + type + " where ordertype = '" + type + "'";
            RzWin.Context.Execute(SQL);

        }
        private void ConvertFileToImage(Boolean bDeleteFile)
        {
            try
            {
                DataTable dt = RzWin.Context.Select("select unique_id from filelink where len(filepath)>0");
                if (dt.Rows.Count <= 0)
                {
                    RzWin.Leader.Tell("Statement:\n\rselect unique_id from filelink where len(filepath)>0\n\rReturned 0 rows.");
                    return;
                }
                RzWin.Leader.StartPopStatus();
                foreach (DataRow dr in dt.Rows)
                {
                    filelink fl = filelink.GetById(RzWin.Context, dr[0].ToString());
                    if (fl == null)
                        continue;
                    if (!File.Exists(fl.filepath))
                        continue;
                    fl.SetPictureDataByFile(fl.filepath);
                    RzWin.Leader.Comment("Saving " + fl.filepath);
                    fl.SavePictureData(RzWin.Context);
                    if (bDeleteFile)
                    {
                        File.Delete(fl.filepath);
                        fl.filepath = "";
                        fl.Update(RzWin.Context);
                    }
                }
                RzWin.Leader.Comment("Done.");
                RzWin.Leader.StopPopStatus(true);
            }
            catch (Exception ee)
            {
                RzWin.Leader.Tell("Error: " + ee.Message);
            }
        }
        private Double GetOrderPaymentTotal(ordhed o)
        {
            if (o == null)
                return 0;
            String SQL = "select sum(abs(transamount)) from checkpayment where base_ordhed_uid = '" + o.unique_id + "'";
            Double d = RzWin.Context.SelectScalarDouble(SQL);
            return d;
        }
        private String ParseCellText(mshtml.HTMLTableRow r, int i)
        {
            try
            {
                return GetCellText(r, i);
            }
            catch (Exception)
            {
                return "";
            }
        }
        private String GetCellText(mshtml.HTMLTableRow r, int i)
        {
            int j = 0;
            foreach (mshtml.IHTMLElement cell in r.cells)
            {
                if (j == i)
                {
                    if (cell.innerText != null)
                        return cell.innerText.Trim();
                    else
                        return "";
                }
                j++;
            }
            return "";
        }
        private mshtml.IHTMLElement GetCell(mshtml.HTMLTableRow r, int i)
        {
            int j = 0;
            foreach (mshtml.IHTMLElement cell in r.cells)
            {
                if (j == i)
                {
                    return cell;
                }
                j++;
            }
            return null;
        }
        private void AddToTable(String[] ary)
        {
            foreach (String s in ary)
            {
                if (!PartObject.IsPart(s.Trim()))
                    continue;
                RzWin.Context.Execute("insert into usbid_temp (part) values ('" + RzWin.Context.Filter(s.Trim()) + "')");
                Application.DoEvents();
            }
        }
        private void DoAATPartNumberLog()
        {
            try
            {
                RzWin.Context.Execute("drop table aat_parts");
                RzWin.Context.Execute("create table aat_parts (partnumber varchar(255), primary key(partnumber))");
                String SQL = "";
                ArrayList a = null;
                for (Int32 i = 0; i < 8; i++)
                {
                    SQL = GetAATSQL(i);
                    if (!Tools.Strings.StrExt(SQL))
                        continue;
                    a = RzWin.Context.SelectScalarArray(SQL);
                    if (a == null)
                        continue;
                    foreach (String s in a)
                    {
                        RzWin.Context.Execute("insert into aat_parts (partnumber) values ('" + s.ToUpper().Trim() + "')");
                    }
                }
                RzWin.Leader.Tell("Done.");
            }
            catch (Exception ee)
            {
                RzWin.Leader.Tell("Error: " + ee.Message);
            }
        }
        private String GetAATSQL(Int32 i)
        {
            switch (i)
            {
                case 0://partrecord
                    return "select distinct(isnull(fullpartnumber,'')) as part from partrecord where len(isnull(fullpartnumber,'')) > 0";
                case 1://req
                    return "select distinct(isnull(fullpartnumber,'')) as part from req where len(isnull(fullpartnumber,'')) > 0";
                case 2://quote
                    return "select distinct(isnull(fullpartnumber,'')) as part from quote where len(isnull(fullpartnumber,'')) > 0";
                case 3://offer
                    return "select distinct(isnull(fullpartnumber,'')) as part from offer where len(isnull(fullpartnumber,'')) > 0";
                case 4://orddet
                    return "select distinct(isnull(fullpartnumber,'')) as part from orddet where len(isnull(fullpartnumber,'')) > 0";
                default:
                    return "";
            }
        }
        private void AtomExp()
        {
            try
            {
                DataTable dt = RzWin.Context.Select("select top 10000 part from usbid_temp where isnull(qty, 1) = 1");
                if (dt == null)
                    return;
                foreach (DataRow dr in dt.Rows)
                {
                    current++;
                    RzWin.Leader.Comment("Record " + current + " of " + total);
                    String part = dr["part"].ToString();
                    if (!Tools.Strings.StrExt(part))
                        continue;
                    RzWin.Context.Execute("update usbid_temp set qty = cast(abs(RAND()* 1999) as int) where part = '" + RzWin.Context.Filter(part) + "'");
                }
                AtomExp();
            }
            catch (Exception ee)
            {
                RzWin.Leader.Tell("Error: " + ee.Message);
            }
        }
        private void AtomCSVExp()
        {
            try
            {

                //long ll = 0;
                //RzWin.Context.xSys.xData.ExportSQLToCsv("select * from usbid_temp", "atom_emails.csv", ref ll);
            }
            catch (Exception ee)
            {
                RzWin.Leader.Tell("Error: " + ee.Message);
            }
        }
        private Boolean NonPage(mshtml.IHTMLDocument2 xDoc)
        {
            if (xDoc.body.innerText.ToLower().Contains("http 404"))
                return true;
            if (xDoc.body.innerText.ToLower().Contains("this program cannot display the webpage"))
                return true;
            return false;
        }
        //Buttons
        private void cmdConvertFileLinks_Click(object sender, EventArgs e)
        {
            ConvertFileToImage(false);
        }
        private void cmdConvert_Click(object sender, EventArgs e)
        {
            StringBuilder s = new StringBuilder();
            for (int i = 4676; i <= 9000; i++)
            {
                s.AppendLine(i.ToString());
            }
            ToolsWin.Clipboard.SetClip(s.ToString());
            RzWin.Form.TheContext.TheLeader.TellTemp("");
            //RzWin.Leader.StartPopStatus();
            //Tools.Legacy.ImportRz3Mainstream(null, RzWin.Context.xSys, RzWin.Context.xSys.xData.server_name, RzWin.Context.xSys.xData.database_name, RzWin.Context.xSys.xData.user_password);
            //RzWin.Leader.StopPopStatus(true);
        }
        private void cmdSolomonInvoices_Click(object sender, EventArgs e)
        {
            //n_data_target t = frmDataSources.Choose(this, TheContext.xSys);
            //if (t == null)
            //    return;
            //PreDefinedImports.ImportInvoicesFromSolomon(TheContext, t);
        }
        private void cmdImportSolomonPOs_Click(object sender, EventArgs e)
        {
            //n_data_target t = frmDataSources.Choose(this, TheContext.xSys);
            //if (t == null)
            //    return;
            //PreDefinedImports.ImportPOsFromSolomon(TheContext, t);
        }
        private void cmdHighest_Click(object sender, EventArgs e)
        {
            RzWin.Leader.Tell(nTools.GetHighestFileName(Tools.FileSystem.GetAppPath(), "Interop.Excel.dll"));
        }
        private void cmdHTUsers_Click(object sender, EventArgs e)
        {
            //n_data_target t = frmDataSources.Choose(this, TheContext.xSys);
            //if (t == null)
            //    return;
            //PreDefinedImports.ImportUsersFromHT(TheContext, t);
        }
        private void cmdHTInvoices_Click(object sender, EventArgs e)
        {
            //n_data_target t = frmDataSources.Choose(this, TheContext.xSys);
            //if (t == null)
            //    return;
            //PreDefinedImports.ImportInvoicesFromHT(TheContext, t);
        }
        private void cmdHTPOs_Click(object sender, EventArgs e)
        {
            //n_data_target t = frmDataSources.Choose(this, TheContext.xSys);
            //if (t == null)
            //    return;
            //PreDefinedImports.ImportPOsFromHT(TheContext, t);
        }
        private void cmdInitStrippedAlternates_Click(object sender, EventArgs e)
        {
            RzWin.Leader.StartPopStatus();
            InitStrippedAlternates("partrecord");
            InitStrippedAlternates("req");
            InitStrippedAlternates("quote");
            InitStrippedAlternates("orddet");
            RzWin.Leader.Comment("Done.");
            RzWin.Leader.StopPopStatus(true);
        }
        private void cmdHTStock_Click(object sender, EventArgs e)
        {
            //n_data_target t = frmDataSources.Choose(this, TheContext.xSys);
            //if (t == null)
            //    return;
            //PreDefinedImports.ImportStockFromHT(TheContext, t);
        }
        private void cmdHTExcess_Click(object sender, EventArgs e)
        {
            //n_data_target t = frmDataSources.Choose(this, TheContext.xSys);
            //if (t == null)
            //    return;
            //PreDefinedImports.ImportExcessFromHT(TheContext, t);
        }
        private void cmdDocScan_Click(object sender, EventArgs e)
        {
        }
        private void cmdScanOptions_Click(object sender, EventArgs e)
        {
            try
            {
                string[] s = Tools.Strings.Split(RzWin.Context.SelectScalarString("select setting_value from n_set where name = 'scan_options'"), "|");
                for (Int32 i = 0; i < s.Length; i++)
                {
                    if (Tools.Strings.StrExt(s[i]))
                    {
                        n_choices c = RzWin.Context.xSys.GetChoicesByName("scan_options");
                        if (c == null)
                        {
                            c = n_choices.New(RzWin.Context);
                            c.name = "scan_options";
                            c.Insert(RzWin.Context);
                        }
                        n_choice cc = c.GetChoice(RzWin.Context, s[i].ToString());
                        if (cc == null)
                        {
                            cc = n_choice.New(RzWin.Context);
                            cc.name = s[i].ToString();
                            cc.the_n_choices_uid = c.unique_id;
                            cc.the_n_choices_order = c.GetNextOrder_the_n_choice(RzWin.Context);
                            cc.Insert(RzWin.Context);
                        }
                    }
                }
                RzWin.Leader.Tell("Done.");
            }
            catch (Exception)
            {
            }
        }
        private void cmdImportOffersToPartrecordOffer_Click(object sender, EventArgs e)
        {
            try
            {
                String strSQL = "";
                strSQL = "insert into partrecord_offer( ";
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
                strSQL += " base_company_uid, ";
                strSQL += " companyname, ";
                strSQL += " companycontactname, ";
                strSQL += " companyphone, ";
                strSQL += " companyfax, ";
                strSQL += " userdata_01, ";
                strSQL += " userdata_02, ";
                strSQL += " userdata_03, ";
                strSQL += " userdata_04, ";
                strSQL += " userdata_05, ";
                strSQL += " userdata_06, ";
                strSQL += " companyemailaddress) ";
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
                strSQL += " left(base_company_uid, 50), ";
                strSQL += " left(companyname, 50), ";
                strSQL += " left(contactname, 50), ";
                strSQL += " left(phonenumber, 50), ";
                strSQL += " left(faxnumber, 50), ";
                strSQL += " left(userdata_01, 50), ";
                strSQL += " left(userdata_02, 50), ";
                strSQL += " left(userdata_03, 50), ";
                strSQL += " left(userdata_04, 50), ";
                strSQL += " left(userdata_05, 50), ";
                strSQL += " left(userdata_06, 50), ";
                strSQL += " left(emailaddress, 50) ";
                strSQL += " from offer";
                //Tools.FileSystem.PopText(strSQL);
                RzWin.Context.Execute(strSQL);
            }
            catch (Exception ee)
            {
                RzWin.Leader.Tell("Error: " + ee.Message);
            }
        }
        private void cmdImportDocs_Click(object sender, EventArgs e)
        {
            try
            {
                RzWin.Leader.StartPopStatus();
                RzWin.Leader.Comment("Starting Transfer..");
                DataTable dt = RzWin.Context.Select("select link_name, folder_path, file_name, class_name, object_id from mc_link");
                if (dt != null)
                {
                    Int32 count = 1;
                    RzWin.Leader.Comment("Found " + dt.Rows.Count + " records.");
                    foreach (DataRow dr in dt.Rows)
                    {
                        mclink old = new mclink(dr);
                        RzWin.Leader.Comment(count.ToString() + ". Old Link: " + old.link_name + " - " + old.class_name);
                        filelink link = filelink.New(RzWin.Context);
                        link.objectclass = old.class_name;
                        link.objectid = old.object_id;
                        link.linkname = old.link_name;
                        String file = old.folder_path + (old.folder_path.EndsWith("\\") ? "" : "\\") + old.file_name;
                        if (File.Exists(file))
                        {
                            link.Insert(RzWin.Context);
                            if (link.IsPictureFile(file))
                                link.SetPictureDataByFile(file);
                            else
                                link.SetDocDataByFile(file);
                            link.SavePictureData(RzWin.Context);
                        }
                        else
                            RzWin.Leader.Comment("File Not Found: " + file);
                        count += 1;
                    }
                }
                RzWin.Leader.Comment("Transfer Complete.");
                RzWin.Leader.StopPopStatus(true);
            }
            catch (Exception ee)
            {
                RzWin.Leader.Comment("Error: " + ee.Message);
                RzWin.Leader.StopPopStatus(true);
            }
        }
        private void cmdSupplierEmailList_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    DataConnection d = new n_data_target(2, "71.251.105.34", "Stat", "sa", "newm3th0d").GetAsDataConnection();
            //    if (!d.ConnectPossible())
            //    {
            //        RzWin.Leader.Tell("Cannot connect to NM1 Data");
            //        return;
            //    }
            //    String email = "";
            //    String insert_SQL = "insert into disty_emails ( emailaddress ) values ";
            //    String comp_SQL = "select distinct(primaryemailaddress) from company where companytype like '%broker%' or companytype like  '%distributor%'";
            //    String cont_SQL = "select distinct(primaryemailaddress) from companycontact where base_company_uid in (select unique_id from company where companytype like '%broker%' or companytype like  '%distributor%')";
            //    DataTable dt = RzWin.Context.Select(comp_SQL);
            //    if (dt == null)
            //        RzWin.Leader.Tell("Company DataTable Null");
            //    else
            //    {
            //        if (dt.Rows.Count <= 0)
            //            RzWin.Leader.Tell("Company DataTable Has No Records.");
            //        else
            //        {
            //            foreach (DataRow dr in dt.Rows)
            //            {
            //                email = dr[0].ToString();
            //                if (!Tools.Strings.StrExt(email))
            //                    continue;
            //                d.Execute(insert_SQL + "( '" + email + "' )", true, true);
            //            }
            //        }
            //    }
            //    dt = RzWin.Context.Select(cont_SQL);
            //    if (dt == null)
            //    {
            //        RzWin.Leader.Tell("Contact DataTable Null");
            //        return;
            //    }
            //    if (dt.Rows.Count <= 0)
            //    {
            //        RzWin.Leader.Tell("Contact DataTable Has No Records.");
            //        return;
            //    }
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        email = dr[0].ToString();
            //        if (!Tools.Strings.StrExt(email))
            //            continue;
            //        d.Execute(insert_SQL + "( '" + email + "' )", true, true);
            //    }
            //    RzWin.Leader.Tell("Done.");
            //}
            //catch (Exception ee)
            //{
            //    RzWin.Leader.Tell("Error: " + ee.Message);
            //}
        }
        private void cmdTestQB_Click(object sender, EventArgs e)
        {
            RzWin.Leader.Tell((RzWin.Context.TheSysRz.TheQuickBooksLogic.CheckConnect(RzWin.Context) ? "Connection == True" : "Connection == False"));
        }
        private void cmdImportXML_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    String strFile = "c:\\template.xml";
            //    RzWin.Leader.StartPopStatus();
            //    if (!System.IO.File.Exists(strFile))
            //        return;
            //    RzWin.Leader.Comment(strFile + " exists.");
            //    System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();
            //    try
            //    {
            //        xDoc.Load(strFile);
            //    }
            //    catch (Exception ee)
            //    {
            //        return;
            //    }
            //    RzWin.Leader.Comment("File Loaded..");
            //    System.Xml.XmlNodeList l = xDoc.SelectNodes("objects/object");
            //    RzWin.Context.Execute("truncate table n_template");
            //    RzWin.Context.Execute("truncate table n_column");
            //    foreach (System.Xml.XmlNode xNode in l)
            //    {
            //        String strClass = xNode.Attributes["class"].Value;
            //        //xData.MakeTableExist(strClass);
            //        RzWin.Leader.Comment("Found class : " + strClass);
            //        System.Xml.XmlNodeList ps = xNode.SelectNodes("properties/property");
            //        System.Xml.XmlNode puid = null;
            //        //get the unique id
            //        foreach (System.Xml.XmlNode p in ps)
            //        {
            //            System.Xml.XmlNode pu = p.SelectSingleNode("name");
            //            if (pu != null)
            //            {
            //                if (Tools.Strings.StrCmp(pu.InnerText, "unique_id"))
            //                {
            //                    puid = p;
            //                    break;
            //                }
            //            }
            //        }
            //        //every object has a unique id
            //        if (puid == null)
            //            return;
            //        //find the object
            //        String strID = puid.SelectSingleNode("value").InnerText;
            //        if (!Tools.Strings.StrExt(strID))
            //            return;
            //        //get the object
            //        nObject o = RzWin.Context.GetById(strClass, strID);
            //        if (o == null)
            //        {
            //            o = RzWin.Context.xSys.MakeObject(strClass);
            //            o.unique_id = strID;
            //            o.date_created = DateTime.Now;
            //            o.date_modified = DateTime.Now;
            //            o.ISave_PreserveID(RzWin.Context);
            //        }
            //        foreach (System.Xml.XmlNode p in ps)
            //        {
            //            String strProp = p.SelectSingleNode("name").InnerText;
            //            String strVal = p.SelectSingleNode("value").InnerText;
            //            String strType = p.SelectSingleNode("type").InnerText;
            //            RzWin.Leader.Comment("Found prop : " + strProp);
            //            if (!Tools.Strings.StrCmp(strProp, "unique_id"))
            //            {
            //                if (Tools.Number.IsNumeric(strType))
            //                    o.ISet_String(strProp, strVal, Int32.Parse(strType));
            //            }
            //        }
            //        o.ISave();
            //    }
            //    RzWin.Leader.Comment("done");
            //}
            //catch (Exception ee)
            //{
            //}
        }
        private void cmdExport_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    String strFile = "c:\\template.xml";
            //    System.Xml.XmlTextWriter ttt = new System.Xml.XmlTextWriter(strFile, Encoding.ASCII);
            //    ttt.WriteStartDocument();
            //    ttt.WriteStartElement("objects");
            //    if (!RzWin.Context.xSys.WriteUpdateClass("n_template", ttt))
            //        return;
            //    if (!RzWin.Context.xSys.WriteUpdateClass("n_column", ttt))
            //        return;
            //    ttt.WriteEndElement();
            //    ttt.WriteEndDocument();
            //    ttt.Close();
            //}
            //catch (Exception)
            //{
            //    return;
            //}
        }
        private void cmdAddToNotifyMsgs_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    RzWin.Context.xSys.xData.MakeFieldExist("notify_messages", "ishtml", (Int32)FieldTypeBoolean, 0);
            //    if (RzWin.Context.xSys.xData.FieldExists("notify_messages", "ishtml"))
            //        RzWin.Leader.Tell("notify_messages.ishtml has been created");
            //    else
            //        RzWin.Leader.Tell("Failure to create notify_messages.ishtml");
            //}
            //catch (Exception ee)
            //{
            //    RzWin.Leader.Tell(ee.Message);
            //}
        }
        private void cmdImportOnlyChoices_Click(object sender, EventArgs e)
        {
            //if (!RzWin.Leader.AreYouSure("delete ALL of the choice list info in the system"))
            //    return;
            //n_data_target t = frmDataSources.Choose(this.ParentForm, RzWin.Context.xSys);
            //nData d = new nData(t);
            //try
            //{
            //    d.ConnectPossible();
            //}
            //catch(Exception ee)
            //{
            //    RzWin.Leader.Tell("No Connection: " + ee.Message);
            //}
        }
        private void cmdOnlyClip_Click(object sender, EventArgs e)
        {
            //n_data_target t = frmDataSources.Choose(this.ParentForm, RzWin.Context.xSys);
            //if (t == null)
            //    t = new n_data_target(2, RzWin.Context.xSys.xData.server_name, RzWin.Context.xSys.xData.database_name, RzWin.Context.xSys.xData.user_name, RzWin.Context.xSys.xData.user_password);
            //nData d = new nData(t);
            //String s = "";
            //if (d.CanConnect(ref s))
            //{
            //    //Tools.Legacy.ImportV12Clipboard(RzWin.Context.xSys, d);
            //    RzWin.Leader.Tell("Done.");
            //}
            //else
            //{
            //    RzWin.Leader.Tell("No Connection: " + s);
            //}
        }
        private void cmdDropChatConnection_Click(object sender, EventArgs e)
        {
            //ChatHook.DisconnectChatHook();
        }
        private void cmdStartChat_Click(object sender, EventArgs e)
        {
            //ChatHook.StartChatHook(RzWin.Context.xSys, Rz3App.xUser);
        }
        private void cmcQBCompanyImport_Click(object sender, EventArgs e)
        {
            if (bgImport.IsBusy)
                return;
            RzWin.Leader.StartPopStatus();
            bgImport.RunWorkerAsync("company");
        }
        private void cmcQBSalesImport_Click(object sender, EventArgs e)
        {
            if (bgImport.IsBusy)
                return;
            RzWin.Leader.StartPopStatus();
            bgImport.RunWorkerAsync("sales");
        }
        private void cmdSetAsDeveloper_Click(object sender, EventArgs e)
        {
            LoginInfo.IsDevelopmentMachine = true;
        }
        private void cmdSetQBAccount_Click(object sender, EventArgs e)
        {
            String qbaccount = RzWin.Context.GetSetting("qb_income_account");
            String newaccnt = RzWin.Leader.AskForString("Please enter the name of the QB's income account.", qbaccount, "Account Name");
            if (Tools.Strings.StrExt(newaccnt))
                RzWin.Context.SetSetting("qb_income_account", newaccnt);
        }
        private void cmdStripTracking_Click(object sender, EventArgs e)
        {
            try
            {
                RzWin.Leader.StartPopStatus();
                RzWin.Leader.Comment("Gathering all tracking numbers...");
                DataTable dt = RzWin.Context.Select("select unique_id, trackingnumber from ordhed where len(isnull(trackingnumber, '')) > 0 and len(isnull(trackingstripped, '')) <= 0");
                if (dt == null)
                {
                    RzWin.Leader.Comment("No tracking numbers were found.");
                    return;
                }
                if (dt.Rows.Count <= 0)
                {
                    RzWin.Leader.Comment("No tracking numbers were found to strip.");
                    return;
                }
                else
                    RzWin.Leader.Comment("Found " + dt.Rows.Count + " tracking numbers to strip.");
                foreach (DataRow dr in dt.Rows)
                {
                    String stripped = Tools.Strings.StripNonAlphaNumeric(dr["trackingnumber"].ToString(), false);
                    if (!Tools.Strings.StrExt(stripped))
                        continue;
                    RzWin.Leader.Comment("Updating tracking number: " + stripped);
                    RzWin.Context.Execute("update ordhed set trackingstripped = '" + stripped + "' where unique_id = '" + dr["unique_id"].ToString() + "'");
                }
                RzWin.Leader.Comment("Done.");
                RzWin.Leader.StopPopStatus(true);
            }
            catch (Exception ee)
            {
                RzWin.Leader.Comment("Error: " + ee.Message);
                RzWin.Leader.StopPopStatus(true);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
        }
        private void cmdDateTest_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Date test:");
            sb.AppendLine("nTools.DateFormat(): " + nTools.DateFormat(System.DateTime.Now));
            sb.AppendLine("Convert.ToString(): " + Convert.ToString(System.DateTime.Now));
            sb.AppendLine("ToString(): " + System.DateTime.Now.ToString());
            RzWin.Leader.Tell(sb.ToString());
        }
        private void cmdUpdateQuotes_Click(object sender, EventArgs e)
        {
            bg.RunWorkerAsync();
        }
        private void cmdTestPDFToText_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    String file = "c:\\columns.csv";
            //    String[] str = Tools.Strings.Split(Tools.Files.OpenFileAsString(file), "\r\n");
            //    foreach (String s in str)
            //    {
            //        if (!Tools.Strings.StrExt(s))
            //            continue;
            //        String[] spl = Tools.Strings.Split(s, ",");
            //        dibbs_columns dc = new dibbs_columns(xSys);
            //        dc.column_name = spl[0].Replace("\"", "");
            //        dc.column_order = Int64.Parse(spl[1].Replace("\"", ""));
            //        dc.default_value = spl[2].Replace("\"", "");
            //        dc.mandatory = (Tools.Strings.StrCmp(spl[3].Replace("\"", ""), "true")) ? true : false;
            //        dc.max_length = Int64.Parse(spl[4].Replace("\"", ""));
            //        dc.objectname = spl[5].Replace("\"", "");
            //        dc.propname = spl[6].Replace("\"", "");
            //        dc.strip_value = (Tools.Strings.StrCmp(spl[7].Replace("\"", ""), "true")) ? true : false;
            //        dc.ISave();
            //    }
            //    RzWin.Leader.Tell("Done!");
            //}
            //catch (Exception ee)
            //{
            //    RzWin.Leader.Tell("Error: " + ee.Message);
            //    return;
            //}
        }
        private void cmdError1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Int32 i = 5;
            //    Int32 k = 0;
            //    i = i / k;
            //}
            //catch (Exception ee)
            //{ nError.HandleError(ee); }
        }
        private void cmdError2_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    n_sys x = null;
            //    x.date_created = DateTime.Now;
            //}
            //catch (Exception ee)
            //{ nError.HandleError(ee); }
        }
        private void cmdError3_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    String s = "5g";
            //    Int64 i = Convert.ToInt64(s);
            //}
            //catch (Exception ee)
            //{ nError.HandleError(ee); }
        }
        private void cmdAtomARAP_Click(object sender, EventArgs e)
        {
            RzWin.Leader.Tell("Gathering Records.");
            bgAtom.RunWorkerAsync();
        }
        private void cmdUseAltReqScreens_Click(object sender, EventArgs e)
        {
            Boolean r = RzWin.Leader.AskYesNo("Answer 'Yes' to use alt req screens. Answer 'No' to not use the screens.");
            RzWin.Logic.UseAlternateReqScreens = r;
            RzWin.Context.SetSettingBoolean("usealtreqscreens", r);
        }
        private void cmdParseContactDomains_Click(object sender, EventArgs e)
        {
            if (!RzWin.Leader.AreYouSure("parse all of the contact domains"))
                return;

            ((DataConnectionSqlServer)RzWin.Context.Data.Connection).SplitEmailDomain("companycontact", "primaryemailaddress", "email_domain");
            RzWin.Leader.Tell("Done");
        }
        private void cmdAATOffers_Click(object sender, EventArgs e)
        {
            //if (!RzWin.Leader.AreYouSure("update the offers to reflect the company linked to"))
            //    return;
            //DataTable dt = RzWin.Context.Select("select distinct(isnull(companyname,'')) as companyname from offer where len(isnull(companyname,''))>0 and len(isnull(base_company_uid,''))<=0");
            //if (dt == null)
            //{
            //    RzWin.Leader.Tell("There were no records found.");
            //    return;
            //}
            //if (dt.Rows.Count <= 0)
            //{
            //    RzWin.Leader.Tell("There were no records found.");
            //    return;
            //}
            //RzWin.Leader.StartPopStatus();
            //try
            //{
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        String comp = dr["companyname"].ToString();
            //        if (!Tools.Strings.StrExt(comp))
            //            continue;
            //        company c = company.GetByName(RzWin.Context.xSys, comp);
            //        if (c == null)
            //            continue;
            //        RzWin.Leader.Comment("Updating " + c.companyname + ".");
            //        Boolean b = RzWin.Context.Execute("update offer set base_company_uid = '" + c.unique_id + "' where companyname = '" + c.companyname + "'", false, true);
            //        RzWin.Leader.Comment((b ? "Success." : "Error."));
            //    }
            //}
            //catch { }
            //RzWin.Leader.StopPopStatus(false);
        }
        private void cmdIntegrity_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = RzWin.Context.Select("select unique_id, isnull(notetext,'') as note from company where len(cast(notetext as varchar(255)))>0");
                if (dt == null)
                {
                    RzWin.Leader.Tell("No Records.");
                    return;
                }
                if (dt.Rows.Count <= 0)
                {
                    RzWin.Leader.Tell("No Records.");
                    return;
                }
                foreach (DataRow dr in dt.Rows)
                {
                    String id = dr["unique_id"].ToString();
                    String text = dr["note"].ToString();
                    if (!Tools.Strings.StrExt(id) || !Tools.Strings.StrExt(text))
                        continue;
                    contactnote n = contactnote.New(RzWin.Context);
                    n.base_company_uid = id;
                    n.notetext = text;
                    n.Insert(RzWin.Context);
                }
                RzWin.Leader.Tell("Done.");
            }
            catch { }
        }
        private void cmdUpdateBasicColors_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = RzWin.Context.Select("select unique_id, stocktype from partrecord where stocktype != 'buy'");
                if (dt == null)
                {
                    RzWin.Leader.Tell("No datatable.");
                    return;
                }
                if (dt.Rows.Count <= 0)
                {
                    RzWin.Leader.Tell("No records.");
                    return;
                }
                RzWin.Leader.Tell("DataTable retreived: " + dt.Rows.Count.ToString() + " records.");
                foreach (DataRow dr in dt.Rows)
                {
                    String stocktype = dr["stocktype"].ToString();
                    String id = dr["unique_id"].ToString();
                    if (!Tools.Strings.StrExt(id))
                        continue;
                    if (!Tools.Strings.StrExt(stocktype))
                        continue;
                    Int32 color = 0;
                    switch (stocktype.ToLower())
                    {
                        case "stock":
                        case "consign":
                            color = 1;
                            break;
                        case "excess":
                            color = 2;
                            break;
                    }
                    RzWin.Context.Execute("update partrecord set grid_color = " + color.ToString() + " where unique_id = '" + id + "'");
                }
                RzWin.Leader.Tell("Done.");
            }
            catch (Exception ee)
            { RzWin.Leader.Tell("Error: " + ee.Message); }
        }
        private void cmdVendorQBImport_Click(object sender, EventArgs e)
        {
            if (bgImport.IsBusy)
                return;
            RzWin.Leader.StartPopStatus();
            bgImport.RunWorkerAsync("jcompany");
        }
        private void cmdPhoenixStockPart_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = RzWin.Context.Select("select distinct(isnull(fullpartnumber, '')) as fullpartnumber from orddet where isnull(fullpartnumber, '') not in ( select distinct(isnull(fullpartnumber, '')) from partrecord) ");
                if (dt == null)
                    return;
                foreach (DataRow dr in dt.Rows)
                {
                    String fpn = dr["fullpartnumber"].ToString();
                    if (!Tools.Strings.StrExt(fpn))
                        continue;
                    partrecord pr = partrecord.New(RzWin.Context);
                    pr.fullpartnumber = fpn;
                    pr.StockType = Enums.StockType.Stock;
                    pr.Insert(RzWin.Context);
                }
                RzWin.Leader.Tell("Done.");
            }
            catch (Exception ee)
            { RzWin.Leader.Tell("Error: " + ee.Message); }
        }
        private void cmdAtometronUSBid2_Click(object sender, EventArgs e)
        {
            if (bgAtomExport.IsBusy)
                return;
            RzWin.Leader.StartPopStatus();
            bgAtomExport.RunWorkerAsync();
        }
        private void cmdAATPartRecordTable_Click(object sender, EventArgs e)
        {
            DoAATPartNumberLog();
        }
        private void nData_Accept()
        {

        }
        //Background Workers
        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                RzWin.Leader.StartPopStatus();
                RzWin.Leader.Comment("Starting..");
                ArrayList a = RzWin.Context.SelectScalarArray("select distinct(unique_id) from partrecord where stocktype = 'stock'");
                if (a == null)
                {
                    RzWin.Leader.Comment("No records found.");
                    return;
                }
                if (a.Count <= 0)
                {
                    RzWin.Leader.Comment("No records found.");
                    return;
                }
                int count = 0;
                foreach (string s in a)
                {
                    count++;
                    RzWin.Leader.Comment("Processing " + count.ToString() + " of " + a.Count.ToString());
                    if (!Tools.Strings.StrExt(s))
                        continue;
                    partrecord p = partrecord.GetById(RzWin.Context, s);
                    if (p == null)
                        continue;
                    p.Changed = true;
                    p.Update(RzWin.Context);
                }
                RzWin.Leader.Comment("Done.");
            }
            catch { }
        }
        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }
        private void bgImport_DoWork(object sender, DoWorkEventArgs e)
        {
            String arg = Tools.Strings.ParseDelimit(e.Argument.ToString(), "_", 1);
            String remove = Tools.Strings.ParseDelimit(e.Argument.ToString(), "_", 2); ;
            switch (arg.ToLower())
            {
                case "company":
                    QBCompanyImport();
                    break;
                case "jcompany":
                    QBJustCompanyImport();
                    break;
                case "sales":
                    QBSalesImport(Tools.Strings.StrExt(remove), Tools.Dates.GetNullDate());
                    break;
                case "purchase":
                    QBPurchaseImport(Tools.Strings.StrExt(remove), Tools.Dates.GetNullDate());
                    break;
                case "invoice":
                    QBInvoiceImport(Tools.Strings.StrExt(remove), Tools.Dates.GetNullDate());
                    break;
                case "both":
                    QBPurchaseImport(Tools.Strings.StrExt(remove), Tools.Dates.GetNullDate());
                    QBInvoiceImport(Tools.Strings.StrExt(remove), Tools.Dates.GetNullDate());
                    break;
            }
        }
        private void bgImport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RzWin.Leader.StopPopStatus(true);
            RzWin.Leader.Tell("Import Completed!");
        }
        private void bgAtom_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RzWin.Leader.Tell("Done.");
        }
        private void bgImportPhoenix_DoWork(object sender, DoWorkEventArgs e)
        {
            Boolean b = (Boolean)e.Argument;
            QBSalesImport(b, Tools.Dates.GetNullDate());
            QBEstimateImport(b);
            QBCreditMemoImport(b);
        }
        private void bgImportPhoenix_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RzWin.Leader.StopPopStatus(true);
            RzWin.Leader.Tell("Import Completed!");
        }
        private void bgAtomExport_DoWork(object sender, DoWorkEventArgs e)
        {
            //RzWin.Leader.Comment("Gathering totals...");
            //total = RzWin.Context.SelectScalarInt64("select count(*) from usbid_temp where isnull(qty, 1) = 1");
            //AtomExp();
            AtomCSVExp();
        }
        private void bgAtomExport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RzWin.Leader.StopPopStatus(true);
            RzWin.Leader.Tell("Done.");
        }
        //Private Classes
        private class mclink
        {
            public String link_name = "";
            public String folder_path = "";
            public String file_name = "";
            public String class_name = "";
            public String object_id = "";
            public mclink(DataRow dr)
            {
                if (dr == null)
                    return;
                try
                {
                    link_name = dr["link_name"].ToString();
                    folder_path = dr["folder_path"].ToString();
                    file_name = dr["file_name"].ToString();
                    class_name = dr["class_name"].ToString();
                    object_id = dr["object_id"].ToString();
                }
                catch (Exception)
                {
                }
            }
        }
        private void cmdNTCEmails_Click(object sender, EventArgs e)
        {
            String s = Tools.Files.OpenFileAsString("c:\\ntc_emails.txt");
            s = s.Replace(",", ";");
            ArrayList a = nTools.SplitArray(s, ";");
            StringBuilder sb = new StringBuilder();
            foreach (String str in a)
            {
                if (!Tools.Strings.StrExt(str))
                    continue;
                if (!nTools.IsEmailAddress(str))
                    continue;
                sb.AppendLine(str);
            }
            Tools.Files.SaveFileAsString("c:\\emails.txt", sb.ToString());
        }
        private void cmdNTCCustomerz_Click(object sender, EventArgs e)
        {
            long l = 0;
            String SQL = "select companyname as [Company], primarycontact as [Contact], primaryphone as [Phone], primaryfax as [Fax], primaryemailaddress as [Email], primarywebaddress as [Website], description as [Description], notetext as [Notes], agentname as [Agent] from company where unique_id in (select base_company_uid from partrecord where len(isnull(base_company_uid,''))>0 and len(isnull(importid,''))>0 )";
            RzWin.Context.Data.Connection.ExportCSV(SQL, "c:\\company.csv", ref l);
        }
        private void cmdBasicECaps_Click(object sender, EventArgs e)
        {
            //String strSQL = "select unique_id, description from partrecord where ";
            //strSQL += " description like 'AF%' or ";
            //strSQL += " description like 'RF%' or  ";
            //strSQL += " description like 'RM%' or  ";
            //strSQL += " description like 'DT%' or  ";
            //strSQL += " description like 'AT%' or ";
            //strSQL += " description like 'AM%'  or ";
            //strSQL += " description like 'RL%' or  ";
            //strSQL += " description like 'AL%' or  ";
            //strSQL += " description like 'CD%'  or ";
            //strSQL += " description like 'CG%' or  ";
            //strSQL += " description like 'SN%' ";

            //strSQL += " order by description";
            //DataTable d = RzWin.Context.Select(strSQL);

            //if (!Tools.Data.DataTableExists(d))
            //{
            //    RzWin.Leader.Tell("No caps.");
            //    return;
            //}

            //RzWin.Context.xSys.xData.MakeFieldExist("partrecord", "cap_type", (int)FieldType.String, 255);
            //RzWin.Context.xSys.xData.MakeFieldExist("partrecord", "cap_cap", (int)FieldTypeFloat, 0);
            //RzWin.Context.xSys.xData.MakeFieldExist("partrecord", "cap_volts", (int)FieldTypeFloat, 0);
            //RzWin.Context.xSys.xData.MakeFieldExist("partrecord", "cap_material", (int)FieldType.String, 255);
            //RzWin.Context.xSys.xData.MakeFieldExist("partrecord", "cap_coeff", (int)FieldType.String, 255);
            //RzWin.Context.xSys.xData.MakeFieldExist("partrecord", "cap_lead_space", (int)FieldTypeFloat, 0);
            //RzWin.Context.xSys.xData.MakeFieldExist("partrecord", "cap_tolerance", (int)FieldType.String, 255);
            //RzWin.Context.xSys.xData.MakeFieldExist("partrecord", "cap_packaging", (int)FieldType.String, 255);
            //RzWin.Context.xSys.xData.MakeFieldExist("partrecord", "cap_failure", (int)FieldType.String, 255);
            //RzWin.Context.xSys.xData.MakeFieldExist("partrecord", "cap_diameter", (int)FieldTypeFloat, 0);
            //RzWin.Context.xSys.xData.MakeFieldExist("partrecord", "cap_length", (int)FieldTypeFloat, 0);

            //RzWin.Leader.StartPopStatus("Parsing " + Tools.Number.LongFormat(d.Rows.Count) + " caps.");
            //foreach (DataRow r in d.Rows)
            //{
            //    try
            //    {
            //        String strID = nData.NullFilter_String(r["unique_id"]);
            //        String strDesc = nData.NullFilter_String(r["description"]).ToUpper().Trim();

            //        if (strDesc.StartsWith("SN"))
            //            strDesc = Tools.Strings.Left(strDesc, 17);
            //        else
            //            strDesc = Tools.Strings.ParseDelimit(strDesc, " ", 1).Trim();

            //        if (strDesc.StartsWith("SN"))
            //        {
            //            strDesc = strDesc.Replace(" ", "X");
            //            strDesc = strDesc.Replace("XX", "X");
            //            strDesc = strDesc.Replace("XX", "X");
            //            strDesc = strDesc.Replace("XX", "X");
            //            strDesc = strDesc.Replace("XX", "X");
            //        }

            //        if (strDesc.StartsWith("RMX"))
            //            strDesc = strDesc.Replace("RMX", "RMQ");

            //        if ((strDesc.StartsWith("CG") || strDesc.StartsWith("RM") || Tools.Number.IsNumeric(strDesc.Substring(2, 1))) && Tools.Strings.HasString(strDesc, "X") && !strDesc.StartsWith("AMP") && strDesc.Length > 4 && Tools.Strings.StrExt(nTools.FilterEverythingButNumbers(strDesc)))
            //        {
            //            String strType = "";
            //            Double dblCap = 0;
            //            Double dblVolts = 0;
            //            String strMaterial = "";
            //            String strTempCoeff = "";
            //            Double dblLeadSpace = 0;
            //            String strTolerance = "";
            //            String strPackaging = "";
            //            String strFailure = "";
            //            Double dblDiameter = 0;
            //            Double dblLength = 0;

            //            String[] arys = Tools.Strings.Split(strDesc.ToUpper(), "X");
            //            List<String> ary = new List<String>();
            //            foreach (String s in arys)
            //            {
            //                ary.Add(s.Trim());
            //            }

            //            ary.Add("");
            //            ary.Add("");
            //            ary.Add("");
            //            ary.Add("");
            //            ary.Add("");
            //            ary.Add("");
            //            ary.Add("");

            //            String rest = "";

            //            switch (Tools.Strings.Left(strDesc, 2).ToUpper())
            //            {
            //                case "AF":
            //                    strType = "Axial Film";
            //                    dblCap = ParseCapPower(Tools.Strings.Mid(ary[0], 3));
            //                    dblVolts = ParseVoltage(ary[1], ref rest);
            //                    if (Tools.Strings.StrExt(rest))
            //                        strMaterial = ParseMaterial(rest);
            //                    break;
            //                case "RF":
            //                    strType = "Radial Film";
            //                    dblCap = ParseCapPower(Tools.Strings.Mid(ary[0], 3));
            //                    dblVolts = ParseVoltage(ary[1], ref rest);
            //                    if (Tools.Strings.StrExt(rest))
            //                        strMaterial = ParseMaterial(rest);
            //                    break;
            //                case "RM":
            //                    strType = "Radial Mono";
            //                    dblCap = ParseCapPower(Tools.Strings.Mid(ary[0], 3), ref rest);
            //                    strTempCoeff = ParseTempCoeff(rest);
            //                    if (Tools.Number.IsNumeric(ary[1]))
            //                    {
            //                        dblVolts = ParseVoltage(ary[1]);
            //                    }
            //                    else
            //                    {
            //                        dblLeadSpace = ParseLeadSpace(Tools.Strings.Mid(ary[1], 1, 1));
            //                        strTolerance = ParseTolerance(Tools.Strings.Mid(ary[1], 2, 1));
            //                        dblVolts = ParseVoltage(Tools.Strings.Mid(ary[1], 3));
            //                    }
            //                    break;
            //                case "DT":
            //                    strType = "Dip Tantalum";
            //                    dblCap = ParseCapPower(Tools.Strings.Mid(ary[0], 3));
            //                    if (Tools.Number.IsNumeric(ary[1]) && !Tools.Strings.HasString(ary[1], "."))
            //                        dblVolts = ParseVoltage(ary[1]);
            //                    else
            //                    {
            //                        String three = Tools.Strings.Left(ary[1], 3);
            //                        if (Tools.Strings.HasString(three, "."))
            //                        {
            //                            three = Tools.Strings.Left(ary[1], 2);
            //                            dblVolts = ParseVoltage(three);
            //                            dblLeadSpace = ParseLeadSpace(Tools.Strings.Mid(ary[1], 3), ref rest);
            //                        }
            //                        else
            //                        {
            //                            dblVolts = ParseVoltage(three);
            //                            dblLeadSpace = ParseLeadSpace(Tools.Strings.Mid(ary[1], 4), ref rest);
            //                        }

            //                        if (Tools.Strings.StrExt(rest))
            //                            strPackaging = rest;
            //                    }
            //                    break;
            //                case "AT":
            //                    strType = "Axial Tantalum";
            //                    dblCap = ParseCapPower(Tools.Strings.Mid(ary[0], 3));
            //                    if (Tools.Number.IsNumeric(ary[1]))
            //                    {
            //                        dblVolts = ParseVoltage(ary[1]);
            //                    }
            //                    else
            //                    {
            //                        strTolerance = ParseTolerance(Tools.Strings.Mid(ary[1], 1, 1));
            //                        strFailure = ParseFailure(Tools.Strings.Mid(ary[1], 2, 1));
            //                        dblVolts = ParseVoltage(Tools.Strings.Mid(ary[1], 3));
            //                    }
            //                    break;
            //                case "AM":
            //                    strType = "Axial Ceramic";
            //                    dblCap = ParseCapPower(Tools.Strings.Mid(ary[0], 3));
            //                    dblVolts = ParseVoltage(ary[1]);
            //                    break;
            //                case "RL":
            //                    strType = "Radial Lead";
            //                    dblCap = ParseCapPower(Tools.Strings.Mid(ary[0], 3));
            //                    dblVolts = ParseVoltage(ary[1]);
            //                    dblDiameter = ParseDouble(ary[2]);
            //                    dblLength = ParseDouble(ary[3]);
            //                    break;
            //                case "AL":
            //                    strType = "Axial Lead";
            //                    dblCap = ParseCapPower(Tools.Strings.Mid(ary[0], 3));
            //                    dblVolts = ParseVoltage(ary[1]);
            //                    dblDiameter = ParseDouble(ary[2]);
            //                    dblLength = ParseDouble(ary[3]);
            //                    break;
            //                case "CD":
            //                    strType = "Ceramic Disc";
            //                    if (strDesc.IndexOf(".") > 5)
            //                    {
            //                        rest = "." + Tools.Strings.ParseDelimit(strDesc, ".", 2);
            //                        strDesc = Tools.Strings.ParseDelimit(strDesc, ".", 1);
            //                    }
            //                    else
            //                        rest = ary[2];

            //                    dblCap = ParseCapPower(Tools.Strings.Mid(ary[0], 3));
            //                    dblVolts = ParseVoltage(ary[1]);
            //                    dblLeadSpace = ParseLeadSpace(rest);
            //                    strTempCoeff = ParseTempCoeff(ary[3]);
            //                    break;
            //                case "CG":
            //                    strType = "Computer Grade";
            //                    rest = Tools.Strings.Mid(ary[0], 3);
            //                    if (!Tools.Strings.StrCmp(Tools.Strings.Left(rest, 1), ".") && !Tools.Number.IsNumeric(Tools.Strings.Left(rest, 1)))
            //                    {
            //                        dblDiameter = ParseDiameter(Tools.Strings.Left(rest, 1));
            //                        rest = Tools.Strings.Mid(rest, 2);
            //                    }

            //                    if (!Tools.Strings.StrCmp(Tools.Strings.Left(rest, 1), ".") && !Tools.Number.IsNumeric(Tools.Strings.Left(rest, 1)))
            //                    {
            //                        dblLength = ParseLength(Tools.Strings.Left(rest, 1));
            //                        rest = Tools.Strings.Mid(rest, 2);
            //                    }
            //                    dblVolts = ParseVoltage(rest);
            //                    dblCap = ParseCapPower(ary[1]);
            //                    break;
            //                case "SN":
            //                    strType = "Snap-In";
            //                    dblVolts = ParseVoltage(Tools.Strings.Mid(ary[0], 3));
            //                    dblCap = ParseCapPower(ary[1]);
            //                    dblDiameter = ParseDouble(ary[2]);
            //                    dblLength = ParseDouble(ary[3]);

            //                    break;
            //            }


            //            String all = "";
            //            if (Tools.Strings.StrExt(strType))
            //                all += "Type=" + strType + " ";

            //            if (dblCap > 0)
            //                all += "Cap=" + dblCap.ToString() + " ";

            //            if (dblVolts > 0)
            //                all += "Volts=" + dblVolts.ToString() + " ";

            //            if (Tools.Strings.StrExt(strMaterial))
            //                all += "Material=" + strMaterial + " ";

            //            if (Tools.Strings.StrExt(strTempCoeff))
            //                all += "TempCoeff=" + strTempCoeff + " ";

            //            if (dblLeadSpace > 0)
            //                all += "LeadSpace=" + dblLeadSpace.ToString() + " ";

            //            if (Tools.Strings.StrExt(strTolerance))
            //                all += "Tolerance=" + strTolerance + " ";

            //            if (Tools.Strings.StrExt(strPackaging))
            //                all += "Packaging=" + strPackaging + " ";

            //            if (Tools.Strings.StrExt(strFailure))
            //                all += "Failure=" + strFailure + " ";

            //            if (dblDiameter > 0)
            //                all += "Diameter=" + dblDiameter.ToString() + " ";

            //            if (dblLength > 0)
            //                all += "Length=" + dblLength.ToString() + " ";


            //            String strUpdate = "update partrecord set cap_info = '" + RzWin.Context.Filter(all) + "', ";
            //            strUpdate += "cap_type = '" + strType + "', ";
            //            strUpdate += "cap_cap = " + dblCap.ToString() + ", ";
            //            strUpdate += "cap_volts = " + dblVolts.ToString() + ", ";
            //            strUpdate += "cap_material = '" + strMaterial + "', ";
            //            strUpdate += "cap_coeff = '" + strTempCoeff + "', ";
            //            strUpdate += "cap_lead_space = " + dblLeadSpace.ToString() + ", ";
            //            strUpdate += "cap_tolerance = '" + strTolerance + "', ";
            //            strUpdate += "cap_packaging = '" + strPackaging + "', ";
            //            strUpdate += "cap_failure = '" + strFailure + "', ";
            //            strUpdate += "cap_diameter = " + dblDiameter.ToString() + ", ";
            //            strUpdate += "cap_length = " + dblLength.ToString() + "  ";
            //            strUpdate += " where unique_id = '" + RzWin.Context.Filter(strID) + "'";
            //            RzWin.Context.Execute(strUpdate);
            //            RzWin.Leader.Comment("Updated " + all);
            //        }
            //    }
            //    catch { }

            //    System.Windows.Forms.Application.DoEvents();
            //}

            //RzWin.Leader.Comment("Done.");
            //RzWin.Leader.StopPopStatus(true);
        }
        String ParseTolerance(String s)
        {
            switch (s.ToUpper())
            {
                case "F":
                    return "+-1%";
                case "G":
                    return "+-2%";
                case "J":
                    return "+-5%";
                case "K":
                    return "+-10%";
                case "M":
                    return "+-20%";
                case "Z":
                    return "-20% +80%";
            }
            return "";
        }
        double ParseDiameter(String s)
        {
            switch (s.ToUpper())
            {
                case "A":
                    return 35;
                case "B":
                    return 50.8;
                case "C":
                    return 63.5;
                case "D":
                    return 76.2;
                case "E":
                    return 44.5;
                case "F":
                    return 88.9;
            }
            return 0;
        }
        double ParseLength(String s)
        {
            switch (s.ToUpper())
            {
                case "A":
                    return 54;
                case "B":
                    return 79.4;
                case "C":
                    return 105;
                case "D":
                    return 117.52;
                case "E":
                    return 130;
                case "F":
                    return 143;
                case "G":
                    return 149;
                case "H":
                    return 168;
                case "I":
                    return 194;
                case "J":
                    return 219;
                case "K":
                    return 0;
                case "L":
                    return 92;
                case "M":
                    return 67;
            }
            return 0;
        }
        String ParseFailure(String s)
        {

            if (s == "-")
                return "";

            switch (s.ToUpper())
            {
                case "L":
                    return "";
                case "M":
                    return "1.0%";
                case "P":
                    return "0.1%";
                case "R":
                    return "0.01%";
                case "S":
                    return "0.001%";
            }
            return "";
        }
        String ParseTempCoeff(String s)
        {
            while (Tools.Number.IsNumeric(Tools.Strings.Left(s, 1)))
            {
                s = Tools.Strings.Mid(s, 2);
            }

            if (s == "-")
                return "";

            switch (s.ToUpper())
            {
                case "N":
                    return "NPO/COG";
                case "X":
                case "Q": //replaced for X in the parsing
                    return "X7R";
                case "Z":
                    return "Z5U";
            }
            return s;
        }
        Double ParseLeadSpace(String s)
        {
            String rest = "";
            return ParseLeadSpace(s, ref rest);
        }
        double ParseLeadSpace(String s, ref String rest)
        {
            try
            {
                String h = "";
                for (int i = 0; i < s.Length; i++)
                {
                    String c = s.Substring(i, 1);
                    if (Tools.Number.IsNumeric(c) || c == ".")
                        h += c;
                    else
                    {
                        rest = s.Substring(i);
                        break;
                    }
                }

                s = h;

                //s = s.Replace(".", "");
                //while (Tools.Strings.StrExt(s) && !Tools.Number.IsNumeric(Tools.Strings.Right(s, 1)))
                //{
                //    s = Tools.Strings.Left(s, s.Length - 1);
                //}

                Double d = Double.Parse(s);
                if (!Tools.Strings.HasString(s, "."))
                    d /= 10;
                return d;
            }
            catch { return 0; }
        }
        long ParseLong(String s)
        {
            try
            {
                return Int64.Parse(s);
            }
            catch { return 0; }
        }
        Double ParseDouble(String s)
        {
            try
            {
                return Double.Parse(s.Trim());
            }
            catch { return 0; }
        }
        Double ParseCapPower(String s)
        {
            String rest = "";
            return ParseCapPower(s, ref rest);
        }
        Double ParseCapPower(String s, ref String rest)
        {
            try
            {
                if (s.Length == 4 && s.StartsWith("0"))
                    s = Tools.Strings.Mid(s, 2);

                s = Tools.Strings.ParseDelimit(s, "-", 1);

                while (Tools.Strings.StrExt(s) && !Tools.Number.IsNumeric(s.Substring(0, 1)) && s.Substring(0, 1) != ".")
                {
                    rest += s.Substring(0, 1);
                    s = Tools.Strings.Mid(s, 2);
                }

                Double decimal_part = 0;
                if (Tools.Strings.HasString(s, "."))
                    s = s.Replace(".", "R");
                if (Tools.Strings.HasString(s, "R"))
                {
                    String dec = Tools.Strings.ParseDelimit(s, "R", 2);
                    if (Tools.Number.IsNumeric(dec))
                        decimal_part = Double.Parse("0." + dec);

                    s = Tools.Strings.ParseDelimit(s, "R", 1);
                }

                Double d = 0;

                if (s.Length == 2 || s.Length == 3 || s.Length == 4)
                {
                    if (s.Length == 2)
                    {
                        if (Tools.Number.IsNumeric(s))
                            return Int64.Parse(s);
                        else
                            return 0;
                    }

                    if (!Tools.Number.IsNumeric(s))
                        return 0;

                    String f = Tools.Strings.Left(s, 1);
                    String restx = Tools.Strings.Mid(s, 2);

                    long lrest = Int64.Parse(restx);
                    if (f != "0" && Tools.Number.IsNumeric(f))
                    {
                        if (lrest == 0)
                        {
                            lrest = Int64.Parse(f) * 100;
                        }
                        else
                        {
                            for (int i = 0; i < Int32.Parse(f); i++)
                            {
                                lrest *= 10;
                            }
                        }
                    }

                    d = lrest;
                }

                if (decimal_part > 0)
                    d = d += decimal_part;

                return d;
            }
            catch { return 0; }
        }
        Double ParseVoltage(String s)
        {
            String rest = "";
            return ParseVoltage(s, ref rest);
        }
        Double ParseVoltage(String s, ref String rest)
        {
            try
            {
                while (s.StartsWith("0"))
                {
                    s = Tools.Strings.Mid(s, 2);
                }

                Double decimal_part = 0;
                s = s.Replace(".", "R");
                if (Tools.Strings.HasString(s, "R"))
                {
                    try
                    {
                        decimal_part = Double.Parse("0." + Tools.Strings.ParseDelimit(s, "R", 2));
                    }
                    catch { }
                    s = Tools.Strings.ParseDelimit(s, "R", 1);
                }

                s = s.ToUpper().Replace("VDC", "");
                s = s.ToUpper().Replace("KV", "K");
                s = s.ToUpper().Replace("V", "");

                if (Tools.Strings.HasString(s, "K"))
                {
                    String s1 = Tools.Strings.ParseDelimit(s, "K", 1);
                    String s2 = Tools.Strings.ParseDelimit(s, "K", 2);
                    rest = s2;

                    if (Tools.Number.IsNumeric(s1))
                    {
                        Double d = Double.Parse(s1);
                        d *= 1000;
                        s = Convert.ToInt64(d).ToString();
                    }
                }
                else
                {
                    String h = "";
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (Tools.Number.IsNumeric(s.Substring(i, 1)))
                            h += s.Substring(i, 1);
                        else
                        {
                            rest = s.Substring(i);
                            break;
                        }
                    }
                    s = h;
                }

                if (!Tools.Number.IsNumeric(s))
                    return 0;

                Double ret = Double.Parse(s);
                if (decimal_part > 0)
                    ret += decimal_part;

                return ret;
            }
            catch { return 0; }
        }
        String ParseMaterial(String m)
        {
            if (m == "-")
                return "";

            String strMaterial = "";
            switch (m)
            {
                case "C":
                    strMaterial = "Polycarbonate";
                    break;
                case "P":
                    strMaterial = "Polyester";
                    break;
                case "MP":
                    strMaterial = "Metalized Polyester";
                    break;
                case "PP":
                    strMaterial = "Polypropylene";
                    break;
            }
            return strMaterial;
        }
        private void cmdSplitPics_Click(object sender, EventArgs e)
        {
            //SplitPics("C:\\Eternal\\Blends\\Desk\\Slides", 52, 49, 271, 139, "C:\\Eternal\\Blends\\Desk\\Blocks\\");
            SplitPics("C:\\Eternal\\Blends\\Desk\\Banners", 109, 35, 94, 74, "C:\\Eternal\\Blends\\Desk\\Blocks\\");


        }
        void SplitPics(String strFolder, int width, int height, int x, int y, String strDest)
        {
            String[] slides = Directory.GetFiles(strFolder);
            foreach (String s in slides)
            {
                Bitmap b = new Bitmap(s);
                Size z = new Size();
                z.Width = width;
                z.Height = height;
                Bitmap n = new Bitmap(width, height, b.PixelFormat);

                //Graphics gb = Graphics.FromImage(b);
                Graphics gn = Graphics.FromImage(n);
                gn.DrawImage(b, new Rectangle(0, 0, n.Width, n.Height), new Rectangle(x, y, n.Width, n.Height), GraphicsUnit.Pixel);
                n.Save(strDest + Path.GetFileName(s), System.Drawing.Imaging.ImageFormat.Jpeg);

                gn.Dispose();
                gn = null;
            }
        }
        private void cmdGetEmails_Click(object sender, EventArgs e)
        {
            //ArrayList a = ToolsOffice.OutlookOffice.GetMessages("pop.gmail.com", "rfqmatch@legendny.com", "br0k3r");
            //RzWin.Context.TheSysRz.TheEmailLogic.SendOutlookEmail(strAddress, strHeader + strFooter, strSubject, false, true, "", AttachmentFileString, false, null, strBCC, strFromAddress, "", context.xUser.email_signature, true, ref err);

        }
        private void button4_Click(object sender, EventArgs e)
        {
            //String s = Rz("plain", "", "plain", this.ParentForm);
            //if (!Tools.Strings.StrExt(s))
            //    return;

            //s = nTools.Encrypt(s, "rec0gnin");
            //Tools.FileSystem.PopText(s);
        }
        private void lblExtraFields_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //RzWin.Context.Execute("alter table partrecord add fan_type varchar(20), fan_voltage varchar(20), fan_current varchar(20), fan_termination varchar(20), fan_wire varchar(20), fan_size varchar(20), fan_cfm varchar(20)");
            //RzWin.Context.Execute("alter table partrecord add cap_type varchar(20), cap_cap float, cap_volts float, cap_material varchar(20), cap_coeff varchar(20), cap_lead_space float, cap_tolerance varchar(20), cap_packaging varchar(20), cap_failure varchar(20), cap_diameter float, cap_length float");
            //RzWin.Context.Execute("alter table partrecord add crystal_frequency float, crystal_package varchar(20), crystal_cap float, crystal_tolerance varchar(20)");
            //RzWin.Leader.Done();
        }
        private void lblFilterCompanyPhone_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!RzWin.Leader.AreYouSure("update all of the strippedphone values for the company table"))
                return;

            RzWin.Context.Execute("update company set strippedphone = isnull(primaryphone, '')");
            nTools.StripPhoneNumberField(RzWin.Context.Data.Connection, "company", "strippedphone");
            RzWin.Leader.Tell("Done.");
        }
        private void lblDate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                String strDate = RzWin.Leader.AskForString("Date", "", "Date");
                if (!Tools.Strings.StrExt(strDate))
                    return;

                DateTime dt = DateTime.Parse(strDate);
                RzWin.Leader.Tell("Result: " + dt.ToString());
            }
            catch (Exception ex)
            {
                RzWin.Leader.Tell("Error: " + ex.Message);
            }
        }
        private void lblNotesImport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            nDataTable d = new nDataTable((DataConnectionSqlServer)RzWin.Context.Data.Connection);

            String f = ToolsWin.FileSystem.ChooseAFile();
            if (!File.Exists(f))
                return;

            String s = "";
            d.AbsorbExcelFile_ByFile(RzWin.Context, f, "Sheet1$");

            RzWin.Context.Execute("delete from " + d.TableName + " where column_f1 = 'Task Key'");

            DataTable t = RzWin.Context.Select("select * from " + d.TableName);

            RzWin.Leader.StartPopStatus("Importing...");

            foreach (DataRow r in t.Rows)
            {
                int companyid = Tools.Data.NullFilterInt(r["Column_F2"]);
                int contactid = Tools.Data.NullFilterInt(r["Column_F4"]);

                String companyuid = RzWin.Context.SelectScalarString("select unique_id from company where companycode = '" + companyid.ToString() + "' ");
                String contactuid = RzWin.Context.SelectScalarString("select unique_id from companycontact where contact_import_id = " + contactid.ToString() + " ");

                contactnote n = contactnote.New(RzWin.Context);
                n.base_company_uid = companyuid;
                if (Tools.Strings.StrExt(companyuid))
                    n.companyname = RzWin.Context.SelectScalarString("select companyname from company where unique_id = '" + companyuid + "' ");

                n.base_companycontact_uid = contactuid;
                if (Tools.Strings.StrExt(contactuid))
                    n.contactname = RzWin.Context.SelectScalarString("select contactname from companycontact where unique_id = '" + contactuid + "' ");

                StringBuilder note = new StringBuilder();
                for (int c = 8; c < 40; c++)
                {
                    try
                    {
                        note.AppendLine(Tools.Strings.KillBlankLines(nData.NullFilter_String(r["Column_F" + c.ToString()])).Trim());
                    }
                    catch { }
                }

                n.agentname = nData.NullFilter_String(r["Column_F7"]);
                n.base_mc_user_uid = RzWin.Context.xSys.TranslateUserNameToID(n.agentname);
                n.notetext = note.ToString();

                n.Insert(RzWin.Context);
                RzWin.Leader.Comment("Saved note " + n.unique_id);
            }

            RzWin.Leader.Comment("Done.");
            RzWin.Leader.StopPopStatus();
        }
        private void lblOrdersImport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String strDatabaseName = RzWin.Leader.AskForString("Source Database", "Rz3_Hold", "Source");

            if (!Tools.Strings.StrExt(strDatabaseName))
                return;

            if (!RzWin.Context.Data.Connection.DatabaseExists(strDatabaseName))
            {
                RzWin.Leader.Tell(strDatabaseName + " doesn't exist");
                return;
            }

            DateTime since = frmChooseDate.ChooseDate(DateTime.Now.Subtract(TimeSpan.FromDays(30)), "Since", this.ParentForm);
            if (!Tools.Dates.DateExists(since))
                return;

            RzWin.Leader.StartPopStatus("Running...");
            foreach (String s in ordhed.OrderTypesStringArray)
            {
                MoveInfo(strDatabaseName, "ordhed_" + s, since, "orderdate");
                MoveInfo(strDatabaseName, "orddet_" + s, since, "orderdate");
            }

            RzWin.Leader.Comment("Done.");
            RzWin.Leader.StopPopStatus(true);
        }
        void MoveInfo(String strDatabaseName, String strClass, DateTime since, String datefield)
        {
            //n_class c = RzWin.Context.xSys.GetClassByName(strClass);

            //nData dx = new nData(RzWin.Context.xSys.xData.target_type, RzWin.Context.xSys.xData.server_name, RzWin.Context.xSys.xData.database_name, RzWin.Context.xSys.xData.user_name, RzWin.Context.xSys.xData.user_password);
            //dx.TheKey.DatabaseName = strDatabaseName;
            //dx.Init(dx.TheKey);

            //RzWin.Context.xSys.MakeClassDataStructure(c, dx, false, strClass);

            //SortedList s = RzWin.Context.xSys.CoalescePropsByClass(strClass);
            //StringBuilder fields = new StringBuilder();
            //int i = 0;
            //foreach (DictionaryEntry d in s)
            //{
            //    if (i != 0)
            //        fields.Append(", ");
            //    fields.Append(((n_prop)d.Value).name);
            //    i++;
            //}

            //String strSQL = "insert into " + strClass + " (  " + fields.ToString() + " ) select " + fields.ToString() + " from " + strDatabaseName + ".dbo." + strClass + " where " + datefield + " >= cast('" + Tools.Dates.DateFormatWithTimeRegardlessOfWindowsSettings(since) + "' as datetime) ";
            //RzWin.Leader.Comment("Running " + strClass);
            //RzWin.Context.Execute(strSQL);
        }
        private void lblVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tools.FileSystem.PopText(Tools.Misc.GetVersionNumber(Tools.ToolsNM.AssemblyNM).ToString());
        }
        private void lblRemoveArch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //if (!RzWin.Leader.AreYouSure("remove the Arch system"))
            //    return;

            //DataTable t = RzWin.Context.Select("select name from sysobjects where type = 'U' and left(name, 5) = 'arch_'");
            //if (nTools.DataTableExists(t))
            //{
            //    foreach (DataRow dr in t.Rows)
            //    {
            //        String s = dr[0].ToString();
            //        RzWin.Context.Execute("truncate table " + s);
            //    }
            //}

            //foreach (String s in RzWin.Context.xSys.xData.GetTableArray())
            //{
            //    RzWin.Context.Data.Connection.Execute("drop trigger " + s + "_delete", true);
            //    RzWin.Context.Execute("drop trigger " + s + "_update");
            //    RzWin.Context.Execute("drop trigger " + s + "_insert");
            //}
            //RzWin.Context.Execute("drop table arch_is_hooked", true);
            //nStatus.Done();
        }
        private void cmdImportPayChargeToQBs_Click(object sender, EventArgs e)
        {
            ImportPayChargeToQBs();
        }
        private void ImportPayChargeToQBs()
        {
            try
            {
                QBPaymentChargeImport q = new QBPaymentChargeImport();
                q.CompleteLoad();
                RzWin.Form.TabShow(q, "QB Payment/Charges Import");
            }
            catch { }
        }
        private void lblIdRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //if (!Rz3App.xLogic.IsAAT)
            //{
            RzWin.Leader.Tell("no");
            return;
            //}

            //if (!RzWin.Leader.AreYouSure("Remove the ID field from all tables"))
            //    return;

            //RzWin.Leader.StartPopStatus("Removing..");

            //ArrayList a = RzWin.Context.xSys.xData.GetTableArray();
            //foreach (String table in a)
            //{
            //    if (RzWin.Context.Execute("alter table " + table + " drop column id", false, true))
            //        RzWin.Leader.Comment("Removed ID from " + table);
            //    else
            //        RzWin.Leader.Comment("Skipped " + table);
            //}

            //RzWin.Leader.Comment("Done");
            //RzWin.Leader.StopPopStatus(true);
        }
        private void cmdWriteImages_Click(object sender, EventArgs e)
        {
            //nImage im = new nImage();
            //string folder = "c:\\Image16\\";
            //foreach (string s in IM.Images.Keys)
            //{
            //    im = new nImage(IM.Images[s]);
            //    im.SaveAsFile(folder + s); 
            //}
            //folder = "c:\\Image24\\";
            //foreach (string s in IMLrg.Images.Keys)
            //{
            //    im = new nImage(IMLrg.Images[s]);
            //    im.SaveAsFile(folder + s);
            //}
        }
        private void cmdImportDiscrepancyForm_Click(object sender, EventArgs e)
        {
            MessageBox.Show("reorg");
            //nFile f = nFile.GetFileFromDisk(true, Rz3App.xMainForm);
            //filelink l = new filelink(RzWin.Context.xSys);
            //l.picturedata = f.bytes;
            //l.filetype = "doc";
            //l.linkname = "DiscrepancyForm";
            //l.ISave();
            //l.SavePictureData();
            //RzWin.Context.SetSetting("DiscrepancyForm_ID", l.unique_id);
        }
        private void cmdStartUpdateTimer_Click(object sender, EventArgs e)
        {
            RzWin.Form.tmrUpdate.Interval = 1000;
            RzWin.Form.UpdateCheckingStart();
        }
        private void cmdImportPartWarnings_Click(object sender, EventArgs e)
        {
            //OpenFileDialog oFile = new OpenFileDialog();
            //oFile.ShowDialog();
            //string file = oFile.FileName;
            //part_warning.ImportPartWarningERAI(TheContext, file);
            //nStatus.Done();
        }
        private void cmdRemoveDiscrepancyForm_Click(object sender, EventArgs e)
        {
            if (!RzWin.Leader.AreYouSure("you want to delete DiscrepancyForm?"))
                return;
            string id = RzWin.Context.GetSetting("DiscrepancyForm_ID");
            if (!Tools.Strings.StrExt(id))
                return;
            filelink f = filelink.GetById(RzWin.Context, id);
            if (f != null)
                f.Delete(RzWin.Context);
            RzWin.Context.SetSetting("DiscrepancyForm_ID", "");
        }
        private void cmdUpdateSelectedClass_Click(object sender, EventArgs e)
        {
            //string c = RzWin.Leader.ASkForString("Please enter a class to update:");
            //if (!Tools.Strings.StrExt(c))
            //    return;
            //n_class cl = RzWin.Context.xSys.GetClassByName(c);
            //if (cl == null)
            //{
            //    RzWin.Leader.Tell("Class does not exist.");
            //    return;
            //}
            //string table = "temp_" + Tools.Strings.GetNewID() + "_table";
            //RzWin.Context.Execute("select distinct(unique_id) into " + table + " from " + cl.class_name, false, true);
            //long count = 0;
            //do
            //{
            //    ArrayList a = RzWin.Context.QtC(cl.class_name, "select * from " + cl.class_name + " where unique_id in (select top 100 unique_id from " + table + ")");
            //    if (a == null)
            //        return;
            //    if (a.Count <= 0)
            //        return;
            //    count = a.Count;
            //    foreach (nObject o in a)
            //    {
            //        o.ISave();
            //        RzWin.Context.Execute("delete from " + table + " where unique_id = '" + o.unique_id + "'", false, true);
            //    }
            //} while (count > 0);
            //RzWin.Leader.Tell("Done.");
        }
        private void cmdLoadFormGraphic_Click(object sender, EventArgs e)
        {
            //OpenFileDialog o = new OpenFileDialog();
            //o.ShowDialog();
            //string file = o.FileName;
            //byte[] b = nImage.GetPictureBytes(nImage.GetImageFromFile(file));
            //filelink f = new filelink(RzWin.Context.xSys);
            //f.linktype = "printedform_graphics";
            //f.linkname = Tools.Files.GetFileNameNoExtention(file);
            //f.filetype = Tools.Files.GetFileExtention(file);
            //f.ISave();
            //f.picturedata = b;
            //f.SavePictureData();
        }
        private void lblArRestore_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //if (!RzWin.Leader.AreYouSure("do the ar restore"))
            //    return;

            //if (!RzWin.Context.xSys.Recall)
            //{
            //    RzWin.Leader.Tell("This system isn't set up for Recall.");
            //    return;
            //}

            //SortedList props = RzWin.Context.xSys.GetPropsByClass(ordhed.MakeOrdhedName("purchase"));
            //DataTable d = RzWin.Context.xSys.recall_connection.Select("select * from ordhed_purchase where year(orderdate) = 2010 and month(orderdate) = 11 and recall_type = 3 and recall_date >= '12/16/2010 5:00:00PM' and recall_date <= '12/16/2010 5:30:00PM'");
            //foreach (DataRow r in d.Rows)
            //{
            //    ordhed.Restore(RzWin.Context, r, "purchase", props);
            //}

            //RzWin.Leader.Tell("Done.");
        }
        private void cmdUpdateTrackingField_Click(object sender, EventArgs e)
        {
            ////Test UnZip
            //Tools.Zip.UnZipOneFile("c:\\bkp\\x.zip", "c:\\bkp\\");
            ////End Test
            //ArrayList tables = new ArrayList();
            //tables.Add("ordhed_invoice");
            //tables.Add("ordhed_purchase");
            //tables.Add("ordhed_service");
            //tables.Add("ordhed_rma");
            //tables.Add("ordhed_vendrma");
            //foreach (string s in tables)
            //{
            //    string sql = "alter table " + s + " alter column trackingnumber varchar(8000);";
            //    RzWin.Context.Execute(sql, false, false);
            //}
            //RzWin.Leader.Tell("Done.");
        }
        private void lblShrink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RzWin.Leader.StartPopStatus("Shrinking pics...");
            //ArrayList a = RzWin.Logic.PictureData.GetScalarArray("select unique_id from partpicture");
            //Omit the company Logo, since it will get corrupted.  //unique_id = 1dc36dbc05694dc28d361f9f7fa141e8
            ArrayList a = RzWin.Logic.PictureData.GetScalarArray("select unique_id from partpicture where unique_id != '1dc36dbc05694dc28d361f9f7fa141e8'");
            RzWin.Leader.Comment("Found " + a.Count.ToString() + " pictures");
            foreach (String s in a)
            {
                partpicture p = partpicture.GetById(RzWin.Context, s, RzWin.Logic.PictureData);
                if (p == null)
                {
                    RzWin.Leader.Comment("Picture " + s + " was not found");
                    System.Windows.Forms.Application.DoEvents();
                    System.Windows.Forms.Application.DoEvents();
                    System.Windows.Forms.Application.DoEvents();
                    continue;
                }

                try
                {
                    p.ExtensionCheckUpdate(RzWin.Context);

                    switch (p.filetype.ToLower().Replace(".", ""))
                    {
                        case "jpg":

                            try
                            {
                                RzWin.Leader.Comment(p.filename);
                                p.LoadPictureData(RzWin.Context);
                                if (p.picturedata != null)
                                {
                                    p.SetPictureDataByImage((ContextRz)RzWin.Context, Tools.Picture.GetThumbnailScaleWidth(p.GetPictureImage(RzWin.Context), 512), p.filename);
                                    p.SavePictureData(RzWin.Context);
                                    p.UpdateTo(RzWin.Context, RzWin.Logic.PictureData);
                                }
                                else
                                    RzWin.Leader.Comment("PictureData for " + p.unique_id + " is null");
                            }
                            catch (Exception ex)
                            {
                                RzWin.Leader.Comment("Error: " + ex.Message);
                            }
                            break;
                        default:
                            RzWin.Leader.Comment("Skipping extension: " + p.filetype);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    RzWin.Leader.Comment("Error: " + ex.Message);
                }

                System.Windows.Forms.Application.DoEvents();
                System.Windows.Forms.Application.DoEvents();
                System.Windows.Forms.Application.DoEvents();
                System.Windows.Forms.Application.DoEvents();
                System.Windows.Forms.Application.DoEvents();
                System.Windows.Forms.Application.DoEvents();

            }

            RzWin.Leader.Comment("Done.");
            RzWin.Leader.StopPopStatus(true);
        }
        private void lblSaveClassInstances_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String c = RzWin.Context.TheLeader.AskForString("Class Name");
            if (!Tools.Strings.StrExt(c))
                return;
            if (bgwSaveInstance.IsBusy)
                return;
            bgwSaveInstance.RunWorkerAsync(c);
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //ImportRz3 i = new ImportRz3();
            //i.Import(RzWin.Context);
            //RzWin.Context.TheLeader.Tell("Done");
        }
        private void lnkReSaveStock_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (bg.IsBusy)
                return;
            bg.RunWorkerAsync();
        }
        private void lblImportCharges_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ImportRz3 i = new ImportRz3();
            i.ImportDeductions(RzWin.Context, DateTime.Parse("1/1/2011"));
        }
        private void lblZebraTest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //try
            //{
            //    OpenFileDialog oFile = new OpenFileDialog();
            //    oFile.ShowDialog();
            //    if (!Tools.Files.FileExists(oFile.FileName))
            //    {
            //        RzWin.Leader.Tell("!Tools.Files.FileExists(oFile.FileName)");
            //        return;
            //    }
            //    string s = Tools.Files.OpenFileAsString(oFile.FileName);
            //    if (!Tools.Strings.StrExt(s))
            //    {
            //        RzWin.Leader.Tell("!Tools.Strings.StrExt(s)");
            //        return;
            //    }
            //    string printer_name = RzWin.Context.TheLeader.AskForString("Enter printer name:", "Zebra", false);
            //    if (!Tools.Strings.StrExt(printer_name))
            //    {
            //        RzWin.Leader.Tell("!Tools.Strings.StrExt(printer_name)");
            //        return;
            //    }
            //    orddet_line l = orddet_line.GetById(RzWin.Context, RzWin.Context.TheLeader.AskForString("Enter orddet_line uid", "", false));
            //    if (l == null)
            //    {
            //        RzWin.Leader.Tell("(l == null)");
            //        return;
            //    }
            //    ArrayList a = new ArrayList();
            //    a.Add(l);
            //    a.Add(l.InvoiceVar.RefGet(RzWin.Context));
            //    s = s.Replace("BARCODE-ORDERREF", "<ordhed_invoice.orderreference>");
            //    s = s.Replace("BARCODE-MFGPN", "<orddet_line.fullpartnumber>");
            //    s = s.Replace("BARCODE-CUSTPN", "<orddet_line.internal_customer>");
            //    s = s.Replace("BARCODE-QTYPACKED", "<orddet_line.quantity_packed>");
            //    s = s.Replace("BARCODE-MANUFACTURER", "<orddet_line.manufacturer>");        
            //    RzWin.Leader.Tell("Press 'OK' when ready.");
            //    nTools.PopText(s);
            //    string after = "";
            //    Tools.Zebra.PrintZebraLabelData(RzWin.Context.xSys, s, a, null, false, printer_name, ref after);
            //    nTools.PopText(after);
            //}
            //catch { }
        }
        private void lblWBPDFTest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            wb.Navigate("http://www.recognin.com/How%20To%20Guide.pdf");
        }
        private void lnkSetSetting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string strName = RzWin.Context.TheLeaderRz.AskForString("Setting Name", "", false, "Name");
            if (!Tools.Strings.StrExt(strName))
                return;
            string strValue = RzWin.Context.TheLeaderRz.AskForString("Setting Value", "", true, "Value");
            if (!RzWin.Leader.AreYouSure("Set the " + strName + " setting = '" + strValue + "'"))
                return;
            RzWin.Context.SetSetting(strName, strValue);
            RzWin.Context.TheLeader.TellTemp("Done.");
        }
        private void lnkProcessCSV_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string str = "";
                string file = "c:\\list\\list.csv";
                string[] files = Directory.GetFiles("c:\\list\\", "*.csv");
                RzWin.Leader.StartPopStatus();
                long l = 1;
                long ll = 1;
                foreach (string s in files)
                {
                    string guts = Tools.Files.OpenFileAsString(s);
                    if (!Tools.Strings.StrExt(guts))
                        continue;
                    string[] lines = Tools.Strings.Split(guts, "\r\n");
                    foreach (string line in lines)
                    {
                        RzWin.Leader.Comment("File " + l.ToString() + " of " + files.Length.ToString() + " Line " + ll.ToString() + " of " + lines.Length.ToString());
                        if (!Tools.Strings.StrExt(line))
                            continue;
                        str += line + ",N/A,1\r\n";
                        ll++;
                    }
                    l++;
                }
                Tools.Files.SaveFileAsString(file, str);
            }
            catch { }
        }
        private void lblImportQBs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //ImportFromQBs qb = new ImportFromQBs();
            //if (!qb.CompleteLoad(RzWin.Context))
            //    return;
            //RzWin.Context.xSys.xMainForm.TabShow(qb, "Import from Quickbooks");
        }
        private void lblRzLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Rz4.Win.Screens.RzLink l = new Win.Screens.RzLink();
            //l.Init();
            //RzWin.Context.xSys.xMainForm.TabShow(l);
        }
        private void lnkOldCommReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CommissionReportScreen v = new CommissionReportScreen();
            RzWin.Form.TabShow(v, "Commission Report");
            v.Init();
        }
        private void lblBraunReqImport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataTable dt = ToolsOffice.ExcelOffice.OpenExcelAsDataTable("c:\\Reqs_Kate.xls", "Reqs_Kate$");
            if (dt == null)
            {
                RzWin.Context.TheLeader.Tell("Datatable came back null!");
                return;
            }
            NewMethod.n_user u = NewMethod.n_user.GetById(RzWin.Context, "7db98cd556744dda906773d35024c783");
            if (u == null)
            {
                RzWin.Context.TheLeader.Tell("User Kate was not found!");
                return;
            }
            bool first = true;
            foreach (DataRow dr in dt.Rows)
            {
                if (first)
                {
                    first = false;
                    continue;
                }
                KateReq r = new KateReq(RzWin.Context, dr, u);
                r.Import();
            }
            RzWin.Context.TheLeader.Tell("Done!");
        }
        private class KateReq
        {
            ContextRz TheContext;
            NewMethod.n_user User;
            string contactname = ""; //0
            string companyname = ""; //1
            DateTime orderdate = Tools.Dates.GetBlankDate(); //2
            string fullpartnumber = ""; //3
            string manufacturer = ""; //4
            string datecode = ""; //5
            int quantity = 0; //6
            double targetprice = 0; //7
            string notes = ""; //8

            public KateReq(ContextRz x, DataRow d, NewMethod.n_user u)
            {
                TheContext = x;
                User = u;
                if (d == null)
                    return;
                contactname = nData.NullFilter_String(d[0]);
                companyname = nData.NullFilter_String(d[1]);
                string date = nData.NullFilter_String(d[2]);
                DateTime dt = DateTime.Now;
                try { dt = Convert.ToDateTime(date); }
                catch { }
                orderdate = nData.NullFilter_DateTime(dt);
                fullpartnumber = nData.NullFilter_String(d[3]);
                manufacturer = nData.NullFilter_String(d[4]);
                datecode = nData.NullFilter_String(d[5]);
                quantity = Tools.Data.NullFilterInt(d[6]);
                targetprice = nData.NullFilter_Double(d[7]);
                notes = nData.NullFilter_String(d[8]);
            }
            public bool Import()
            {
                if (TheContext == null)
                    return false;
                company c = company.GetByName(RzWin.Context, companyname);
                if (c == null)
                    return false;
                companycontact cc = (companycontact)TheContext.QtO("companycontact", "select * from companycontact where base_company_uid = '" + c.unique_id + "' and contactname = '" + RzWin.Context.Filter(contactname) + "'");
                orddet_quote q = orddet_quote.New(RzWin.Context);
                q.source = "Import[" + DateTime.Now.ToShortDateString() + "]";
                q.target_quantity = quantity;
                q.fullpartnumber = fullpartnumber;
                q.target_manufacturer = manufacturer;
                q.manufacturer = manufacturer;
                q.target_datecode = datecode;
                q.datecode = datecode;
                q.target_price = targetprice;
                q.base_company_uid = c.unique_id;
                q.companyname = c.companyname;
                if (cc != null)
                    q.base_companycontact_uid = cc.unique_id;
                q.contactname = contactname;
                if (!Tools.Dates.DateExists(orderdate))
                    orderdate = DateTime.Now;
                q.orderdate = orderdate;
                q.internalcomment = notes;
                if (User != null)
                {
                    q.base_mc_user_uid = User.unique_id;
                    q.agentname = User.name;
                }
                q.Update(RzWin.Context);
                return true;
            }
        }
        private void lblTwit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TwitterTest();
        }
        private void TwitterTest()
        {
            TwitterClient client = new TwitterClient("JoelWaechter", "129643pz");
            client.SendMessage("Testing my twitter client code.");
        }
        public class TwitterClient
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public Exception Error { get; set; }
            private string _twitterUpdateUrl = "http://twitter.com/statuses/update.json";
            public TwitterClient(string userName, string password)
            {
                this.Username = userName; this.Password = password;
            }
            public void SendMessage(string message)
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(_twitterUpdateUrl);
                    request.Credentials = new NetworkCredential(this.Username, this.Password);
                    SetRequestParams(request);
                    string post = string.Format("status={0}", HttpUtility.UrlEncode(message));
                    using (Stream requestStream = request.GetRequestStream())
                    {
                        using (StreamWriter writer = new StreamWriter(requestStream))
                        {
                            writer.Write(post);
                        }
                    }
                    WebResponse response = request.GetResponse();
                    string content;
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            content = reader.ReadToEnd();
                        }
                    }
                }
                catch (Exception ex)
                { Error = ex; }
            }
            private static void SetRequestParams(HttpWebRequest request)
            {
                System.Net.ServicePointManager.Expect100Continue = false;
                request.Timeout = 50000; request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
            }
        }
        private void lblBFImport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmBFEmailImport i = new frmBFEmailImport();
            i.CompleteLoad(RzWin.Context);
            i.Show();
        }
        private void lblNafta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            nFile file = nFile.GetFileFromDisk();
            if (file == null)
                return;
            filelink f = (filelink)RzWin.Context.QtO("filelink", "select * from filelink where filetype = 'pdf' and linkname = 'nafta' and linktype = 'nafta_pdf'");
            if (f != null)
            {
                f.LoadPictureData(RzWin.Context);
                f.SaveDataAsFile();
                f.Delete(RzWin.Context);
            }
            f = filelink.New(RzWin.Context);
            f.filetype = "pdf";
            f.linkname = "nafta";
            f.linktype = "nafta_pdf";
            f.picturedata = file.bytes;
            f.Insert(RzWin.Context);
            f.SavePictureData(RzWin.Context);
            RzWin.Leader.Tell("Done");
        }
        private void lbl7525_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            nFile file = nFile.GetFileFromDisk();
            if (file == null)
                return;
            filelink f = (filelink)RzWin.Context.QtO("filelink", "select * from filelink where filetype = 'pdf' and linkname = '7525' and linktype = '7525_pdf'");
            if (f != null)
            {
                f.LoadPictureData(RzWin.Context);
                f.SaveDataAsFile();
                f.Delete(RzWin.Context);
            }
            f = filelink.New(RzWin.Context);
            f.filetype = "pdf";
            f.linkname = "7525";
            f.linktype = "7525_pdf";
            f.picturedata = file.bytes;
            f.Insert(RzWin.Context);
            f.SavePictureData(RzWin.Context);
            RzWin.Leader.Tell("Done");
        }
        private void lblTestPDF_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //string filename = "C:\\Work\\NAFTA.pdf";
            //if (!Tools.Files.FileExists(filename))
            //    return;
            //try
            //{
            //    ordhed_invoice i = ordhed_invoice.GetById(RzWin.Context, "0e184bd5548944708f213daf3a0b7cfd");
            //    if (i == null)
            //        return;
            //    iTextSharp.text.pdf.PdfReader pdfReader = new iTextSharp.text.pdf.PdfReader(filename);
            //    String newFile = Tools.Folder.ConditionFolderName(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + Tools.Strings.GetNewID() + ".pdf";
            //    iTextSharp.text.pdf.PdfStamper pdfStamper = new iTextSharp.text.pdf.PdfStamper(pdfReader, new FileStream(newFile, FileMode.Create), '8', true);
            //    iTextSharp.text.pdf.AcroFields pdfFormFields = pdfStamper.AcroFields;
            //    pdfFormFields.SetField("F[0].P1[0].fromdate[0]", "01/01/" + DateTime.Now.Year.ToString());
            //    pdfFormFields.SetField("F[0].P1[0].todate[0]", "12/31/" + DateTime.Now.Year.ToString());
            //    pdfFormFields.SetField("F[0].P1[0].importername[0]", i.companyname + "\r\n" + i.shippingaddress);
            //    string descr = "";
            //    double cost = 0;
            //    foreach (orddet d in i.DetailsList(RzWin.Context))
            //    {
            //        if (!(d is orddet_line))
            //            continue;
            //        orddet_line l = (orddet_line)d;
            //        if (Tools.Strings.StrExt(descr))
            //            descr += "\r\n";
            //        descr += l.description;
            //        cost += l.unit_cost;
            //    }
            //    pdfFormFields.SetField("F[0].P1[0].descripofgoods1[0]", descr);
            //    pdfFormFields.SetField("F[0].P1[0].netcost1[0]", cost.ToString());
            //    pdfFormFields.SetField("F[0].P1[0].DateE[0]", DateTime.Now.ToShortDateString());
            //    pdfStamper.FormFlattening = false; pdfStamper.Close();
            //    Tools.FileSystem.Shell(newFile);
            //}
            //catch { }
        }
        private void lblRyan1Import_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (bgRyan1.IsBusy)
                return;
            RzWin.Leader.StartPopStatus();
            bgRyan1.RunWorkerAsync();
        }
        private void lblRyan2Import_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (bgRyan2.IsBusy)
                return;
            RzWin.Leader.StartPopStatus();
            bgRyan2.RunWorkerAsync();
        }
        private void bgRyan1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DataTable dt = ToolsOffice.ExcelOffice.OpenExcelAsDataTable("c:\\Ryan1.xls", "Sheet1$");
                if (dt == null)
                {
                    RzWin.Leader.Comment("Datatable came back null!");
                    return;
                }
                n_user u = n_user.GetById(RzWin.Context, "3a42d43e49db4c54bcfdbe71be267524");
                if (u == null)
                {
                    RzWin.Leader.Comment("User Ryan could not be found!");
                    return;
                }
                bool first = true;
                int count = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    count++;
                    RzWin.Leader.Comment("Importing " + count.ToString() + " of " + dt.Rows.Count.ToString());
                    if (first)
                    {
                        first = false;
                        continue;
                    }
                    Ryan1 r = new Ryan1(RzWin.Context, dr, u);
                    r.Import();
                }
            }
            catch (Exception ee)
            { RzWin.Leader.Comment("Error: " + ee.Message); }
        }
        private void bgRyan1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RzWin.Leader.Comment("Done!");
            RzWin.Leader.StopPopStatus(true);
        }
        private void bgRyan2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DataTable dt = ToolsOffice.ExcelOffice.OpenExcelAsDataTable("c:\\Ryan2.xls", "Sheet1$");
                if (dt == null)
                {
                    RzWin.Leader.Comment("Datatable came back null!");
                    return;
                }
                n_user u = n_user.GetById(RzWin.Context, "3a42d43e49db4c54bcfdbe71be267524");
                if (u == null)
                {
                    RzWin.Leader.Comment("User Ryan could not be found!");
                    return;
                }
                int count = 0;
                company c = null;
                companycontact cc = null;
                foreach (DataRow dr in dt.Rows)
                {
                    count++;
                    RzWin.Leader.Comment("Importing " + count.ToString() + " of " + dt.Rows.Count.ToString());
                    string first = nData.NullFilter_String(dr[0]).Trim();
                    bool isnote = false;
                    bool iscomp = false;
                    switch (first.ToLower())
                    {
                        case "call - left message":
                        case "call completed":
                        case "field changed":
                        case "note":
                            isnote = true;
                            break;
                        case "type":
                            continue;
                        default:
                            iscomp = true;
                            break;
                    }
                    if (iscomp)
                    {
                        string comp = nData.NullFilter_String(dr[0]).Trim();
                        string cont = nData.NullFilter_String(dr[1]).Trim();
                        if (!Tools.Strings.StrExt(comp))
                            continue;
                        if (!Tools.Strings.StrExt(cont))
                            continue;
                        c = company.GetByDistilledName(RzWin.Context, company.DistillCompanyName(comp));
                        if (c == null)
                        {
                            c = company.New(RzWin.Context);
                            c.companyname = comp;
                            c.primarycontact = cont;
                            c.base_mc_user_uid = u.unique_id;
                            c.agent = u.name;
                            c.agentname = u.name;
                            c.importid = "Ryan Company/Contact Import";
                            c.Insert(RzWin.Context);
                        }
                        cc = companycontact.GetByDistilledName(RzWin.Context, companycontact.DistillContactName(cont), c.unique_id);
                        if (cc == null)
                        {
                            cc = c.AddContact(RzWin.Context);
                            cc.contactname = cont;
                            cc.base_mc_user_uid = u.unique_id;
                            cc.agentname = u.name;
                            cc.Update(RzWin.Context);
                        }
                        continue;
                    }
                    else if (isnote)
                    {
                        Ryan2 r = new Ryan2(RzWin.Context, dr, u, cc);
                        r.Import();
                    }
                    else
                        continue;
                }
            }
            catch (Exception ee)
            { RzWin.Leader.Comment("Error: " + ee.Message); }
        }
        private void bgRyan2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RzWin.Leader.Comment("Done!");
            RzWin.Leader.StopPopStatus(true);
        }
        private class Ryan1
        {
            ContextRz TheContext;
            NewMethod.n_user User;
            string first = ""; //0
            string last = ""; //1
            string contactname
            {
                get
                {
                    return (first.Trim() + " " + last.Trim()).Trim();
                }
            }
            string companyname = ""; //2
            string status = ""; //3
            string source = ""; //4
            string phone = ""; //5
            string ext = ""; //6
            string cell = ""; //7
            string email = ""; //8
            DateTime date = Tools.Dates.GetBlankDate(); //9

            public Ryan1(ContextRz x, DataRow d, NewMethod.n_user u)
            {
                TheContext = x;
                User = u;
                if (d == null)
                    return;
                first = (nData.NullFilter_String(d[0])).Trim();
                last = (nData.NullFilter_String(d[1])).Trim();
                companyname = nData.NullFilter_String(d[2]).Trim();
                status = nData.NullFilter_String(d[3]).Trim();
                source = nData.NullFilter_String(d[4]).Trim();
                phone = nData.NullFilter_String(d[5]).Trim();
                ext = nData.NullFilter_String(d[6]).Trim();
                cell = nData.NullFilter_String(d[7]).Trim();
                email = nData.NullFilter_String(d[8]).Trim();
                string date_s = nData.NullFilter_String(d[9]);
                DateTime dt = DateTime.Now;
                try { dt = Convert.ToDateTime(date_s); }
                catch { }
                date = dt;
            }
            public bool Import()
            {
                if (TheContext == null)
                    return false;
                company c = company.GetByDistilledName(RzWin.Context, company.DistillCompanyName(companyname));
                if (c == null)
                {
                    c = company.New(RzWin.Context);
                    c.companyname = companyname;
                    c.primarycontact = contactname;
                    c.primaryphone = phone;
                    c.primaryemailaddress = email;
                    c.base_mc_user_uid = User.unique_id;
                    c.agent = User.name;
                    c.agentname = User.name;
                    c.source = source;
                    c.lead_source = source;
                    c.companytype = status;
                    c.importid = "Ryan Company/Contact Import";
                    c.Insert(RzWin.Context);
                }
                companycontact cc = companycontact.GetByEmailAddress(TheContext, email);
                if (cc == null)
                    cc = companycontact.GetByDistilledName(TheContext, companycontact.DistillContactName(contactname), c.unique_id);
                if (cc == null)
                {
                    cc = c.AddContact(RzWin.Context);
                    cc.contactname = contactname;
                    cc.primaryphone = phone;
                    cc.primaryphoneextension = ext;
                    cc.primaryemailaddress = email;
                    cc.preferred_name = first;
                    cc.jobtype = status;
                    cc.source = source;
                    cc.base_mc_user_uid = User.unique_id;
                    cc.agentname = User.name;
                    cc.alternatephone = cell;
                    cc.datecreated = date;
                    cc.date_created = date;
                    cc.Update(RzWin.Context);
                }
                return true;
            }
        }
        private class Ryan2
        {
            ContextRz TheContext;
            NewMethod.n_user User;
            companycontact Contact;
            DateTime date = Tools.Dates.GetBlankDate();
            string note = "";

            public Ryan2(ContextRz x, DataRow d, NewMethod.n_user u, companycontact c)
            {
                TheContext = x;
                User = u;
                Contact = c;
                if (d == null)
                    return;
                if (Contact == null)
                    return;
                string hold = nData.NullFilter_String(d[1]);
                string date_s = "";
                try { date_s = hold.Substring(hold.Length - 4, 2) + "/" + hold.Substring(hold.Length - 2, 2) + "/" + hold.Substring(0, 4); }
                catch { }
                string time_s = nData.NullFilter_String(d[2]);
                DateTime dt = DateTime.Now;
                try { dt = Convert.ToDateTime(date_s + " " + time_s); }
                catch { }
                date = dt;
                note = nData.NullFilter_String(d[3]).Replace("&nbsp;", " ").Trim();
            }
            public bool Import()
            {
                if (TheContext == null)
                    return false;
                contactnote n = contactnote.New(RzWin.Context);
                n.agentname = User.name;
                n.base_company_uid = Contact.base_company_uid;
                n.base_companycontact_uid = Contact.unique_id;
                n.base_mc_user_uid = User.unique_id;
                n.companyname = Contact.companyname;
                n.contactname = Contact.contactname;
                n.date_created = date;
                n.date_modified = date;
                n.datecreated = date;
                n.datemodified = date;
                n.noteagent = User.name;
                n.notedate = date;
                n.notetext = note;
                n.Insert(RzWin.Context);
                return true;
            }
        }
        private void lblFirstNames_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!RzWin.Context.TheLeader.AreYouSure("update all contact first names"))
                return;

            DataTable d = RzWin.Context.Select("select unique_id, contactname from companycontact");
            foreach (DataRow r in d.Rows)
            {
                String id = Tools.Data.NullFilterString(r["unique_id"]);
                String name = Tools.Data.NullFilterString(r["contactname"]);
                String first = Tools.Strings.NiceFormat(Tools.People.FirstNameParse(name));
                RzWin.Context.Execute("update companycontact set first_name = '" + RzWin.Context.Filter(first) + "' where unique_id = '" + id + "'");
            }

            RzWin.Context.TheLeader.Tell("Done");
        }
        private void lnkEmailGMail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //// Connect to the IMAP server. The 'true' parameter specifies to use SSL 
            //// which is important (for Gmail at least) 
            //AE.Net.Mail.ImapClient ic = new AE.Net.Mail.ImapClient("imap.gmail.com", "joelw1977@gmail.com", "gig420pz",
            //                AE.Net.Mail.ImapClient.AuthMethods.Login, 993, true);
            //// Select a mailbox. Case-insensitive 
            //ic.SelectMailbox("INBOX");
            //Console.WriteLine(ic.GetMessageCount());
            //// Get the first *11* messages. 0 is the first message; 
            //// and it also includes the 10th message, which is really the eleventh ;) 
            //// MailMessage represents, well, a message in your mailbox 
            //AE.Net.Mail.MailMessage[] mm = ic.GetMessages(0, 10);
            //StringBuilder sb = new StringBuilder();
            //foreach (AE.Net.Mail.MailMessage m in mm)
            //{
            //    sb = new StringBuilder();
            //    if (m.Subject != null)
            //        sb.AppendLine("Subject: " + m.Subject);
            //    if (m.From != null)
            //        sb.AppendLine("From: " + m.From);
            //    if (m.ReplyTo != null)
            //        sb.AppendLine("ReplyTo: " + m.ReplyTo.ToString());
            //    if (m.Sender != null)
            //    {
            //        if (m.Sender.Address != null)
            //            sb.AppendLine("Sender: " + m.Sender.Address);
            //    }
            //    if (m.Body != null)
            //        sb.AppendLine("Body: " + m.Body);
            //    if (m.Date != null)
            //        sb.AppendLine("Date: " + m.Date.ToString());
            //    if (m.To != null)
            //        sb.AppendLine("Sender: " + m.To.ToString());
            //    Tools.FileSystem.PopText(sb.ToString());
            //}
            //// Probably wiser to use a using statement 
            //ic.Dispose();
        }
        private void lnkCommonSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SettingsPanel sp = new SettingsPanel();
            sp.CompleteLoad();
            RzWin.Form.TabShow(sp, "Settings Panel");
        }
        private void lnkTest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string[] file1 = Tools.Strings.Split(Tools.FileSystem.OpenFileAsString("C:\\Bilge\\Leads.csv"), "\r\n");
            string[] file2 = Tools.Strings.Split(Tools.FileSystem.OpenFileAsString("C:\\Bilge\\1.csv"), "\r\n");
            Dictionary<string, string> dLeads = new Dictionary<string, string>();
            Dictionary<string, string> dNew = new Dictionary<string, string>();
            foreach (string s in file1)
            {
                try { dLeads.Add(s, s); }
                catch { }
            }
            foreach (string s in file2)
            {
                string line = "";
                dLeads.TryGetValue(s, out line);
                if (!Tools.Strings.StrExt(line))
                {
                    try { dNew.Add(s, s); }
                    catch { }
                }
            }
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, string> kvp in dNew)
            {
                sb.AppendLine(kvp.Value);
            }
            Tools.FileSystem.SaveFileAsString(@"c:\bilge\Leads2.csv", sb.ToString());
        }
        private void lblFieldMain_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ContextRz x = RzWin.Context;
            x.Leader.StartPopStatus("Running field maintenance...");
            x.Sys.FieldMaintenance(x);
            x.Leader.CommentEllipse("Dropping extraneous recall fields");
            foreach (String table in x.Data.Connection.ScalarArray("select name from sysobjects where type = 'U'"))
            {
                x.Data.Connection.Execute("alter table " + table + " drop column recall_date", true);
                x.Data.Connection.Execute("alter table " + table + " drop column recall_user_uid", true);
                x.Data.Connection.Execute("alter table " + table + " drop column recall_user_name", true);
                x.Data.Connection.Execute("alter table " + table + " drop column recall_machine_name", true);
                x.Data.Connection.Execute("alter table " + table + " drop column recall_type", true);
                x.Data.Connection.Execute("alter table " + table + " drop column recall_version", true);
                x.Data.Connection.Execute("alter table " + table + " drop column recall_uid", true);
            }
            x.Leader.Comment("Done");
            x.Leader.StopPopStatus(true);
        }
        private void lblUpdateData_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ContextRz x = RzWin.Context;
            x.xSys.UpdateDataStructure(x, false);
            x.TheLeader.Comment("Done.");
            x.TheLeader.StopPopStatus(true);
        }
        private void bgwSaveInstance_DoWork(object sender, DoWorkEventArgs e)
        {
            string c = e.Argument.ToString();
            RzWin.Leader.StartPopStatus();
            RzWin.Leader.Comment("Starting..");
            SysNewMethod.UpdateAllByClass(RzWin.Context, c);
        }
        private void bgwSaveInstance_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RzWin.Leader.Comment("Done.");
            RzWin.Leader.StopPopStatus();
        }
        private void lnkPicDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (bgPics.IsBusy)
                return;
            bgPics.RunWorkerAsync();
        }
        private void bgPics_DoWork(object sender, DoWorkEventArgs e)
        {
            RzWin.Leader.StartPopStatus();
            RzWin.Leader.Comment("Starting..");
            //AdjustPartPicsOrddetLine();
            AdjustPartQCOrddetLine();
        }
        private void bgPics_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RzWin.Leader.Comment("Done.");
            RzWin.Leader.StopPopStatus();
        }
        private void AdjustPartPicsOrddetLine()
        {
            string sql = "select unique_id,the_ordhed_uid,(prefix+basenumberstripped) as fullpartnumber from partpicture where len(isnull(the_ordhed_uid,'')) > 0 and len(isnull(fullpartnumber,'')) > 0";
            DataTable dt = RzWin.Context.Select(sql);
            if (dt == null)
                return;
            int count = 0;
            foreach (DataRow dr in dt.Rows)
            {
                count++;
                RzWin.Leader.Comment("Processing " + count.ToString() + " of " + dt.Rows.Count.ToString());
                string id = nData.NullFilter_String(dr["unique_id"]);
                string ord_id = nData.NullFilter_String(dr["the_ordhed_uid"]);
                string pn = nData.NullFilter_String(dr["fullpartnumber"]);
                if (!Tools.Strings.StrExt(id))
                    continue;
                if (!Tools.Strings.StrExt(ord_id))
                    continue;
                if (!Tools.Strings.StrExt(pn))
                    continue;
                string type = RzWin.Context.SelectScalarString("select ordertype from ordhed where unique_id = '" + ord_id + "'");
                if (!Tools.Strings.StrExt(type))
                    continue;
                string det_id = RzWin.Context.SelectScalarString("select top 1 unique_id from orddet_line where orderid_" + type + "='" + ord_id + "' and prefix+basenumberstripped='" + pn + "' order by linecode_" + type + " asc");
                if (!Tools.Strings.StrExt(det_id))
                    continue;
                try { RzWin.Context.Execute("update partpicture set the_orddet_uid = '" + det_id + "' where unique_id = '" + id + "'"); }
                catch { }
            }
        }
        private void AdjustPartQCOrddetLine()
        {
            string sql = "select distinct(the_orddet_uid) from qualitycontrol where len(isnull(the_orddet_uid,'')) > 0";
            DataTable dt = RzWin.Context.Select(sql);
            if (dt == null)
                return;
            int count = 0;
            foreach (DataRow dr in dt.Rows)
            {
                count++;
                RzWin.Leader.Comment("Processing " + count.ToString() + " of " + dt.Rows.Count.ToString());
                string id = nData.NullFilter_String(dr["the_orddet_uid"]);
                if (!Tools.Strings.StrExt(id))
                    continue;
                string table = "orddet_purchase_bak_reorg";
                if (Environment.MachineName == "WESTWOOD1")
                    table = "orddet_purchase";
                string order = RzWin.Context.SelectScalarString("select ordernumber from " + table + " where unique_id = '" + id + "'");
                string pn = RzWin.Context.SelectScalarString("select prefix+basenumberstripped from " + table + " where unique_id = '" + id + "'");
                if (!Tools.Strings.StrExt(order))
                    continue;
                if (!Tools.Strings.StrExt(pn))
                    continue;
                string det_id = RzWin.Context.SelectScalarString("select top 1 unique_id from orddet_line where ordernumber_purchase = '" + order + "' and prefix+basenumberstripped='" + pn + "' order by linecode_purchase asc");
                if (!Tools.Strings.StrExt(det_id))
                    continue;
                string pack_uid = RzWin.Context.SelectScalarString("select unique_id from pack where the_orddet_purchase_uid = '" + det_id + "'");
                try { RzWin.Context.Execute("update qualitycontrol set the_orddet_uid = '" + det_id + "', the_companycontact_uid = '" + pack_uid + "' where the_orddet_uid = '" + id + "'"); }
                catch { }
            }
        }
        private void lnkCheckClosed_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (bgwClosedOrdersAlfa.IsBusy)
                return;
            bgwClosedOrdersAlfa.RunWorkerAsync();
        }
        private void bgwClosedOrdersAlfa_DoWork(object sender, DoWorkEventArgs e)
        {
            RzWin.Leader.StartPopStatus();
            RzWin.Leader.Comment("Starting..");
            CheckClosedOrdersAlfa();
        }
        private void bgwClosedOrdersAlfa_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RzWin.Leader.Comment("Done.");
            RzWin.Leader.StopPopStatus();
        }
        private void CheckClosedOrdersAlfa()
        {
            try
            {
                //Sales Orders
                RzWin.Leader.Comment("Gathering Sales Orders..");
                ArrayList a = RzWin.Context.SelectScalarArray("select distinct(unique_id) from ordhed_sales where isnull(isclosed,0) = 0 and unique_id in (select distinct(Rz3_Old.dbo.ordhed_sales.unique_id) from Rz3_Old.dbo.ordhed_sales where isnull(Rz3_Old.dbo.ordhed_sales.isclosed,0) = 1)");
                int i = 0;
                foreach (string id in a)
                {
                    i++;
                    RzWin.Leader.Comment("Closing SO " + i.ToString() + " of " + a.Count.ToString());
                    if (!Tools.Strings.StrExt(id))
                        continue;
                    ordhed_sales s = ordhed_sales.GetById(RzWin.Context, id);
                    if (s == null)
                        continue;
                    foreach (orddet_line d in s.DetailsList(RzWin.Context))
                    {
                        d.Status = Enums.OrderLineStatus.Shipped;
                        if (d.quantity_packed < d.quantity)
                            d.quantity_packed = d.quantity;
                        d.Update(RzWin.Context);
                    }
                    s.Update(RzWin.Context);
                }
                //Invoice
                RzWin.Leader.Comment("Gathering Invoices..");
                a = RzWin.Context.SelectScalarArray("select distinct(unique_id) from ordhed_invoice where isnull(isclosed,0) = 0 and unique_id in (select distinct(Rz3_Old.dbo.ordhed_invoice.unique_id) from Rz3_Old.dbo.ordhed_invoice where isnull(Rz3_Old.dbo.ordhed_invoice.isclosed,0) = 1)");
                i = 0;
                foreach (string id in a)
                {
                    i++;
                    RzWin.Leader.Comment("Closing Invoice " + i.ToString() + " of " + a.Count.ToString());
                    if (!Tools.Strings.StrExt(id))
                        continue;
                    ordhed_invoice s = ordhed_invoice.GetById(RzWin.Context, id);
                    if (s == null)
                        continue;
                    foreach (orddet_line d in s.DetailsList(RzWin.Context))
                    {
                        d.Status = Enums.OrderLineStatus.Shipped;
                        if (d.quantity_packed < d.quantity)
                            d.quantity_packed = d.quantity;
                        d.Update(RzWin.Context);
                    }
                    s.Update(RzWin.Context);
                }
                //Purchase
                RzWin.Leader.Comment("Gathering Purchases..");
                a = RzWin.Context.SelectScalarArray("select distinct(unique_id) from ordhed_purchase where isnull(isclosed,0) = 0 and unique_id in (select distinct(Rz3_Old.dbo.ordhed_purchase.unique_id) from Rz3_Old.dbo.ordhed_purchase where isnull(Rz3_Old.dbo.ordhed_purchase.isclosed,0) = 1)");
                i = 0;
                foreach (string id in a)
                {
                    i++;
                    RzWin.Leader.Comment("Closing Purchase " + i.ToString() + " of " + a.Count.ToString());
                    if (!Tools.Strings.StrExt(id))
                        continue;
                    ordhed_purchase s = ordhed_purchase.GetById(RzWin.Context, id);
                    if (s == null)
                        continue;
                    foreach (orddet_line d in s.DetailsList(RzWin.Context))
                    {
                        d.Status = Enums.OrderLineStatus.Received;
                        d.was_received = true;
                        if (d.quantity_unpacked < d.quantity)
                            d.quantity_unpacked = d.quantity;
                        d.Update(RzWin.Context);
                    }
                    s.Update(RzWin.Context);
                }
                //RMA
                RzWin.Leader.Comment("Gathering RMAs..");
                a = RzWin.Context.SelectScalarArray("select distinct(unique_id) from ordhed_rma where isnull(isclosed,0) = 0 and unique_id in (select distinct(Rz3_Old.dbo.ordhed_rma.unique_id) from Rz3_Old.dbo.ordhed_rma where isnull(Rz3_Old.dbo.ordhed_rma.isclosed,0) = 1)");
                i = 0;
                foreach (string id in a)
                {
                    i++;
                    RzWin.Leader.Comment("Closing RMA " + i.ToString() + " of " + a.Count.ToString());
                    if (!Tools.Strings.StrExt(id))
                        continue;
                    ordhed_rma s = ordhed_rma.GetById(RzWin.Context, id);
                    if (s == null)
                        continue;
                    foreach (orddet_line d in s.DetailsList(RzWin.Context))
                    {
                        d.Status = Enums.OrderLineStatus.RMA_Received;
                        d.was_rma_received = true;
                        if (d.quantity_unpacked_rma < d.quantity)
                            d.quantity_unpacked_rma = d.quantity;
                        d.Update(RzWin.Context);
                    }
                    s.Update(RzWin.Context);
                }
                //VendRMA
                RzWin.Leader.Comment("Gathering VendRMAs..");
                a = RzWin.Context.SelectScalarArray("select distinct(unique_id) from ordhed_vendrma where isnull(isclosed,0) = 0 and unique_id in (select distinct(Rz3_Old.dbo.ordhed_vendrma.unique_id) from Rz3_Old.dbo.ordhed_vendrma where isnull(Rz3_Old.dbo.ordhed_vendrma.isclosed,0) = 1)");
                i = 0;
                foreach (string id in a)
                {
                    i++;
                    RzWin.Leader.Comment("Closing VendRMA " + i.ToString() + " of " + a.Count.ToString());
                    if (!Tools.Strings.StrExt(id))
                        continue;
                    ordhed_vendrma s = ordhed_vendrma.GetById(RzWin.Context, id);
                    if (s == null)
                        continue;
                    foreach (orddet_line d in s.DetailsList(RzWin.Context))
                    {
                        d.Status = Enums.OrderLineStatus.Vendor_RMA_Shipped;
                        d.was_vendrma_shipped = true;
                        if (d.quantity_packed_vendrma < d.quantity)
                            d.quantity_packed_vendrma = d.quantity;
                        d.Update(RzWin.Context);
                    }
                    s.Update(RzWin.Context);
                }
                //Service
                RzWin.Leader.Comment("Gathering Service Orders..");
                a = RzWin.Context.SelectScalarArray("select distinct(unique_id) from ordhed_service where isnull(isclosed,0) = 0 and unique_id in (select distinct(Rz3_Old.dbo.ordhed_service.unique_id) from Rz3_Old.dbo.ordhed_service where isnull(Rz3_Old.dbo.ordhed_service.isclosed,0) = 1)");
                i = 0;
                foreach (string id in a)
                {
                    i++;
                    RzWin.Leader.Comment("Closing Service " + i.ToString() + " of " + a.Count.ToString());
                    if (!Tools.Strings.StrExt(id))
                        continue;
                    ordhed_service s = ordhed_service.GetById(RzWin.Context, id);
                    if (s == null)
                        continue;
                    foreach (orddet_line d in s.DetailsList(RzWin.Context))
                    {
                        d.Status = Enums.OrderLineStatus.Vendor_RMA_Shipped;
                        d.was_service_in = true;
                        if (d.quantity_packed_service < d.quantity)
                            d.quantity_packed_service = d.quantity;
                        if (d.quantity_unpacked_service < d.quantity)
                            d.quantity_unpacked_service = d.quantity;
                        d.Update(RzWin.Context);
                    }
                    s.Update(RzWin.Context);
                }
            }
            catch (Exception ee)
            {
                RzWin.Leader.Comment("Error: " + ee.Message);
            }
        }
        private void lnkUpdateAlfaCompTypes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            nDataTable d = new nDataTable((DataConnectionSqlServer)RzWin.Context.Data.Connection);
            String f = ToolsWin.FileSystem.ChooseAFile();
            if (!File.Exists(f))
                return;
            RzWin.Context.TheLeader.StartPopStatus("Importing file: " + f);
            d.AbsorbCSVFile(RzWin.Context, f);
            string table = d.TableName;
            RzWin.Context.Execute("UPDATE R SET R.companytype = P.column_1 FROM company AS R INNER JOIN " + table + " AS P ON R.companyname = P.column_0 WHERE R.companyname = P.column_0");
            RzWin.Context.TheLeader.Comment("Done.");
            RzWin.Context.TheLeader.StopPopStatus(true);
            RzWin.Context.Execute("drop table " + table);
        }
        private void lnkUpdateAlfaCompNumbs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!RzWin.Context.TheLeader.AskYesNo("Are you sure you want to update all company numbers in the system? This will overwrite any existing numbers!"))
                return;
            RzWin.Context.TheLeader.StartPopStatus("Starting...");
            //Customer (10000-19999)
            int i = 0;
            ArrayList a = RzWin.Context.QtC("company", "select * from company where companytype = 'Customer'");
            int numb = 10000;
            foreach (company c in a)
            {
                i++;
                RzWin.Context.TheLeader.Comment("Customer [" + i.ToString() + " of " + a.Count.ToString() + "] " + c.companyname + " : " + numb);
                c.companynumber = numb;
                c.Update(RzWin.Context, true);
                numb++;
                if (numb >= 20000)
                    break;
            }
            RzWin.Context.SetSettingInt32("cnum_customer_next", numb);
            //Vendor (20000-29999)
            i = 0;
            a = RzWin.Context.QtC("company", "select * from company where companytype = 'Vendor'");
            numb = 20000;
            foreach (company c in a)
            {
                i++;
                RzWin.Context.TheLeader.Comment("Vendor [" + i.ToString() + " of " + a.Count.ToString() + "] " + c.companyname + " : " + numb);
                c.companynumber = numb;
                c.Update(RzWin.Context, true);
                numb++;
                if (numb >= 30000)
                    break;
            }
            RzWin.Context.SetSettingInt32("cnum_vendor_next", numb);
            //Manufacturer (30000-39999)
            i = 0;
            a = RzWin.Context.QtC("company", "select * from company where companytype = 'Manufacturer'");
            numb = 30000;
            foreach (company c in a)
            {
                i++;
                RzWin.Context.TheLeader.Comment("Manufacturer [" + i.ToString() + " of " + a.Count.ToString() + "] " + c.companyname + " : " + numb);
                c.companynumber = numb;
                c.Update(RzWin.Context, true);
                numb++;
                if (numb >= 40000)
                    break;
            }
            RzWin.Context.SetSettingInt32("cnum_manufacturer_next", numb);
            //Broker / Ind. (40000-49999)
            i = 0;
            a = RzWin.Context.QtC("company", "select * from company where companytype = 'Broker / Ind.'");
            numb = 40000;
            foreach (company c in a)
            {
                i++;
                RzWin.Context.TheLeader.Comment("Broker / Ind. [" + i.ToString() + " of " + a.Count.ToString() + "] " + c.companyname + " : " + numb);
                c.companynumber = numb;
                c.Update(RzWin.Context, true);
                numb++;
                if (numb >= 50000)
                    break;
            }
            RzWin.Context.SetSettingInt32("cnum_broker_next", numb);
            //Distributor (50000-59999)
            i = 0;
            a = RzWin.Context.QtC("company", "select * from company where companytype = 'Distributor'");
            numb = 50000;
            foreach (company c in a)
            {
                i++;
                RzWin.Context.TheLeader.Comment("Distributor [" + i.ToString() + " of " + a.Count.ToString() + "] " + c.companyname + " : " + numb);
                c.companynumber = numb;
                c.Update(RzWin.Context, true);
                numb++;
                if (numb >= 60000)
                    break;
            }
            RzWin.Context.SetSettingInt32("cnum_distributor_next", numb);
            RzWin.Context.TheLeader.Comment("Done.");
            RzWin.Context.TheLeader.StopPopStatus(true);
        }
        private void lnkCreateOrderViews_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RzWin.Context.TheLeader.StartPopStatus("Creating Order Views...");
            ordhed.DropOrderViews(RzWin.Context);
            ordhed.CreateOrderViews(RzWin.Context);
            RzWin.Context.TheLeader.Comment("Done.");
            RzWin.Context.TheLeader.StopPopStatus();
        }

        private void lnkAccountingTest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tools.Dates.DateRange dr = new Tools.Dates.DateRange(Tools.Dates.GetMonthStart(DateTime.Now), DateTime.Now);
            RzWin.Context.Accounts.ShowIncomeStatement(RzWin.Context, dr);
            RzWin.Context.Accounts.ShowStatementOfOwnersEquity(RzWin.Context, dr);
            RzWin.Context.Accounts.ShowBalanceSheet(RzWin.Context, DateTime.Now);
            RzWin.Context.Accounts.ShowStatementOfCashFlows(RzWin.Context, dr);
        }

        private void lnkAddExampleAccounts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddExampleAccounts();
        }

        void AddExampleAccounts()
        {
            if (!RzWin.Context.TheLeader.AreYouSure("you want to remove ALL existing accounts/journal entries add the example accounts?"))
                return;
            RzWin.Context.Execute("truncate table account");
            RzWin.Context.Execute("truncate table journal");
            RzWin.Sys.ProofLogic.AddExampleAccounts(RzWin.Context);
            ArrayList a = RzWin.Context.QtC("account", "select * from account where type = '" + Tools.Strings.NiceEnum(AccountType.Income.ToString()) + "'");
            foreach (account aa in a)
            {   //Income accounts - credit
                double d = 0;
                double c = 0;
                if (aa.balance < 0)
                    d = aa.balance * -1;
                else
                    c = aa.balance;
                AddStartingJournalEntry(RzWin.Context, aa, d, c, DateTime.Now);
            }
            a = RzWin.Context.QtC("account", "select * from account where type = '" + Tools.Strings.NiceEnum(AccountType.CostOfGoodsSold.ToString()) + "'");
            foreach (account aa in a)
            {   //CostOfGoods accounts - debit
                double d = 0;
                double c = 0;
                if (aa.balance < 0)
                    c = aa.balance * -1;
                else
                    d = aa.balance;
                AddStartingJournalEntry(RzWin.Context, aa, d, c, DateTime.Now);
            }
            a = RzWin.Context.QtC("account", "select * from account where type = '" + Tools.Strings.NiceEnum(AccountType.Expense.ToString()) + "'");
            foreach (account aa in a)
            {   //Expense accounts - debit
                double d = 0;
                double c = 0;
                if (aa.balance < 0)
                    c = aa.balance * -1;
                else
                    d = aa.balance;
                AddStartingJournalEntry(RzWin.Context, aa, d, c, DateTime.Now);
            }
            a = RzWin.Context.QtC("account", "select * from account where type = '" + Tools.Strings.NiceEnum(AccountType.OtherIncome.ToString()) + "'");
            foreach (account aa in a)
            {   //Income accounts - credit
                double d = 0;
                double c = 0;
                if (aa.balance < 0)
                    d = aa.balance * -1;
                else
                    c = aa.balance;
                AddStartingJournalEntry(RzWin.Context, aa, d, c, DateTime.Now);
            }
            a = RzWin.Context.QtC("account", "select * from account where type = '" + Tools.Strings.NiceEnum(AccountType.OtherExpense.ToString()) + "'");
            foreach (account aa in a)
            {   //Expense accounts - debit
                double d = 0;
                double c = 0;
                if (aa.balance < 0)
                    c = aa.balance * -1;
                else
                    d = aa.balance;
                AddStartingJournalEntry(RzWin.Context, aa, d, c, DateTime.Now);
            }
            a = RzWin.Context.QtC("account", "select * from account where type = '" + Tools.Strings.NiceEnum(AccountType.Bank.ToString()) + "'");
            foreach (account aa in a)
            {   //Bank accounts - debit
                double d = 0;
                double c = 0;
                if (aa.balance < 0)
                    c = aa.balance * -1;
                else
                    d = aa.balance;
                AddStartingJournalEntry(RzWin.Context, aa, d, c, DateTime.Now);
            }
            a = RzWin.Context.QtC("account", "select * from account where type = '" + Tools.Strings.NiceEnum(AccountType.AccountsReceivable.ToString()) + "'");
            foreach (account aa in a)
            {   //Accounts Receivable accounts - debit
                double d = 0;
                double c = 0;
                if (aa.balance < 0)
                    c = aa.balance * -1;
                else
                    d = aa.balance;
                AddStartingJournalEntry(RzWin.Context, aa, d, c, DateTime.Now);
            }
            a = RzWin.Context.QtC("account", "select * from account where type = '" + Tools.Strings.NiceEnum(AccountType.OtherCurrentAssets.ToString()) + "'");
            foreach (account aa in a)
            {   //Other Current Asset accounts - debit
                double d = 0;
                double c = 0;
                if (aa.balance < 0)
                    c = aa.balance * -1;
                else
                    d = aa.balance;
                AddStartingJournalEntry(RzWin.Context, aa, d, c, DateTime.Now);
            }
            a = RzWin.Context.QtC("account", "select * from account where type = '" + Tools.Strings.NiceEnum(AccountType.FixedAssets.ToString()) + "'");
            foreach (account aa in a)
            {   //Fixed Asset accounts - debit
                double d = 0;
                double c = 0;
                if (aa.balance < 0)
                    c = aa.balance * -1;
                else
                    d = aa.balance;
                AddStartingJournalEntry(RzWin.Context, aa, d, c, DateTime.Now);
            }
            a = RzWin.Context.QtC("account", "select * from account where type = '" + Tools.Strings.NiceEnum(AccountType.OtherAssets.ToString()) + "'");
            foreach (account aa in a)
            {   //Other Asset accounts - debit
                double d = 0;
                double c = 0;
                if (aa.balance < 0)
                    c = aa.balance * -1;
                else
                    d = aa.balance;
                AddStartingJournalEntry(RzWin.Context, aa, d, c, DateTime.Now);
            }
            a = RzWin.Context.QtC("account", "select * from account where type = '" + Tools.Strings.NiceEnum(AccountType.AccountsPayable.ToString()) + "'");
            foreach (account aa in a)
            {   //Accounts Payable accounts - credit
                double d = 0;
                double c = 0;
                if (aa.balance < 0)
                    d = aa.balance * -1;
                else
                    c = aa.balance;
                AddStartingJournalEntry(RzWin.Context, aa, d, c, DateTime.Now);
            }
            a = RzWin.Context.QtC("account", "select * from account where type = '" + Tools.Strings.NiceEnum(AccountType.CreditCard.ToString()) + "'");
            foreach (account aa in a)
            {   //Credit Card accounts - credit
                double d = 0;
                double c = 0;
                if (aa.balance < 0)
                    d = aa.balance * -1;
                else
                    c = aa.balance;
                AddStartingJournalEntry(RzWin.Context, aa, d, c, DateTime.Now);
            }
            a = RzWin.Context.QtC("account", "select * from account where type = '" + Tools.Strings.NiceEnum(AccountType.OtherCurrentLiabilities.ToString()) + "'");
            foreach (account aa in a)
            {   //Other Current Liability accounts - credit
                double d = 0;
                double c = 0;
                if (aa.balance < 0)
                    d = aa.balance * -1;
                else
                    c = aa.balance;
                AddStartingJournalEntry(RzWin.Context, aa, d, c, DateTime.Now);
            }
            a = RzWin.Context.QtC("account", "select * from account where type = '" + Tools.Strings.NiceEnum(AccountType.LongTermLiabilities.ToString()) + "'");
            foreach (account aa in a)
            {   //Long Term Liability accounts - credit
                double d = 0;
                double c = 0;
                if (aa.balance < 0)
                    d = aa.balance * -1;
                else
                    c = aa.balance;
                AddStartingJournalEntry(RzWin.Context, aa, d, c, DateTime.Now);
            }
            a = RzWin.Context.QtC("account", "select * from account where type = '" + Tools.Strings.NiceEnum(AccountType.Equity.ToString()) + "'");
            foreach (account aa in a)
            {   //Equity accounts - credit
                double d = 0;
                double c = 0;
                if (aa.balance < 0)
                    d = aa.balance * -1;
                else
                    c = aa.balance;
                AddStartingJournalEntry(RzWin.Context, aa, d, c, DateTime.Now);
            }
            AddYearBeingJournalEntries();
            RzWin.Context.TheLeader.Tell("Done.");
        }
        private void AddYearBeingJournalEntries()
        {
            DateTime dt = new DateTime(DateTime.Now.Year, 7, 1);

            //Bank accounts - debit
            account a = account.GetByName(RzWin.Context, "Checking");
            a.balance = 36810.16;
            AddStartingJournalEntry(RzWin.Context, a, 36810.16, 0, dt);

            a = account.GetByName(RzWin.Context, "Savings");
            a.balance = 15881.03;
            AddStartingJournalEntry(RzWin.Context, a, 15881.03, 0, dt);

            a = account.GetByName(RzWin.Context, "Petty Cash");
            a.balance = 500;
            AddStartingJournalEntry(RzWin.Context, a, 500, 0, dt);

            //Accounts Receivable accounts - debit
            a = account.GetByName(RzWin.Context, "Accounts Receivable");
            a.balance = 21249.39;
            AddStartingJournalEntry(RzWin.Context, a, 21249.39, 0, dt);

            //Other Current Asset accounts - debit
            a = account.GetByName(RzWin.Context, "Undeposited Funds");
            a.balance = 18252.08;
            AddStartingJournalEntry(RzWin.Context, a, 18252.08, 0, dt);

            a = account.GetByName(RzWin.Context, "Inventory Asset");
            a.balance = 12767.04;
            AddStartingJournalEntry(RzWin.Context, a, 12767.04, 0, dt);

            a = account.GetByName(RzWin.Context, "Employee Advances");
            a.balance = 770;
            AddStartingJournalEntry(RzWin.Context, a, 770, 0, dt);

            a = account.GetByName(RzWin.Context, "Pre-Paid Insurance");
            a.balance = 4943.02;
            AddStartingJournalEntry(RzWin.Context, a, 4943.02, 0, dt);

            a = account.GetByName(RzWin.Context, "Retainage Receivable");
            a.balance = 1796.72;
            AddStartingJournalEntry(RzWin.Context, a, 1796.72, 0, dt);

            //Fixed Asset accounts - debit
            a = account.GetByName(RzWin.Context, "Furniture and Equipment");
            a.balance = 22826;
            AddStartingJournalEntry(RzWin.Context, a, 22826, 0, dt);

            a = account.GetByName(RzWin.Context, "Vehicles");
            a.balance = 78936.91;
            AddStartingJournalEntry(RzWin.Context, a, 78936.91, 0, dt);

            a = account.GetByName(RzWin.Context, "Buildings and Improvements");
            a.balance = 325000;
            AddStartingJournalEntry(RzWin.Context, a, 325000, 0, dt);

            a = account.GetByName(RzWin.Context, "Construction Equipment");
            a.balance = 15300;
            AddStartingJournalEntry(RzWin.Context, a, 15300, 0, dt);

            a = account.GetByName(RzWin.Context, "Land");
            a.balance = 90000;
            AddStartingJournalEntry(RzWin.Context, a, 90000, 0, dt);

            a = account.GetByName(RzWin.Context, "Accumulated Depreciation");
            a.balance = -110344.60;
            AddStartingJournalEntry(RzWin.Context, a, 0, 110344.60, dt);

            //Other Asset accounts - debit
            a = account.GetByName(RzWin.Context, "Security Deposits");
            a.balance = 1720;
            AddStartingJournalEntry(RzWin.Context, a, 1720, 0, dt);

            //Accounts Payable accounts - credit
            a = account.GetByName(RzWin.Context, "Accounts Payable");
            a.balance = 13100;
            AddStartingJournalEntry(RzWin.Context, a, 0, 13100, dt);

            //Credit Card accounts - credit
            a = account.GetByName(RzWin.Context, "AMEX");
            a.balance = 530;
            AddStartingJournalEntry(RzWin.Context, a, 0, 530, dt);

            //Other Current Liability accounts - credit
            a = account.GetByName(RzWin.Context, "Sales Tax Payable");
            a.balance = 72.18;
            AddStartingJournalEntry(RzWin.Context, a, 0, 72.18, dt);

            //Long Term Liability accounts - credit
            a = account.GetByName(RzWin.Context, "Loan - Vehicles (Van)");
            a.balance = 16290.52;
            AddStartingJournalEntry(RzWin.Context, a, 0, 16290.52, dt);

            a = account.GetByName(RzWin.Context, "Loan - Vehicles (Utility Truck)");
            a.balance = 19936.91;
            AddStartingJournalEntry(RzWin.Context, a, 0, 19936.91, dt);

            a = account.GetByName(RzWin.Context, "Loan - Vehicles (Pickup Truck)");
            a.balance = 22641;
            AddStartingJournalEntry(RzWin.Context, a, 0, 22641, dt);

            a = account.GetByName(RzWin.Context, "Loan - Construction Equipment");
            a.balance = 14343.11;
            AddStartingJournalEntry(RzWin.Context, a, 0, 14343.11, dt);

            a = account.GetByName(RzWin.Context, "Loan - Furniture/Office Equip");
            a.balance = 21000;
            AddStartingJournalEntry(RzWin.Context, a, 0, 21000, dt);

            a = account.GetByName(RzWin.Context, "Note Payable");
            a.balance = 31180.52;
            AddStartingJournalEntry(RzWin.Context, a, 0, 31180.52, dt);

            a = account.GetByName(RzWin.Context, "Mortgage - Office Building");
            a.balance = 296283;
            AddStartingJournalEntry(RzWin.Context, a, 0, 296283, dt);

            //Equity accounts - credit
            a = account.GetByName(RzWin.Context, "Opening Balance Equity");
            a.balance = 38773.75;
            AddStartingJournalEntry(RzWin.Context, a, 0, 38773.75, dt);

            a = account.GetByName(RzWin.Context, "Capital Stock");
            a.balance = 500;
            AddStartingJournalEntry(RzWin.Context, a, 0, 500, dt);

            a = account.GetByName(RzWin.Context, "Retained Earnings");
            a.balance = 61756.76;
            AddStartingJournalEntry(RzWin.Context, a, 0, 61756.76, dt);
        }
        private journal AddStartingJournalEntry(ContextRz x, account a, double debit, double credit, DateTime dt)
        {
            //For testing ONLY!!
            journal j = journal.CreateNoInsert(x, a, debit, credit);
            j.balance = a.balance;
            j.Insert(x);
            j.date_created = dt;
            j.Update(x);
            return j;
        }

        private void clearAccountBalances_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!RzWin.Context.TheLeader.AreYouSure("you want to remove ALL existing accounts add the example accounts"))
                return;

            RzWin.Sys.ProofLogic.AddExampleAccounts(RzWin.Context);
            RzWin.Sys.ProofLogic.ClearBalancesAndJournal(RzWin.Context);

            RzWin.Context.TheLeader.Tell("Done.");
        }

        private void removeNonRzAccounts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!RzWin.Context.TheLeader.AreYouSure("you want to remove many existing example accounts"))
                return;

            RzWin.Sys.ProofLogic.RemoveNonRzExampleAccounts(RzWin.Context);
            RzWin.Context.TheLeader.Tell("Done.");
        }

        private void productionAccounts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (RzWin.Context.SelectScalarInt32("select count(*) from account") > 0 || RzWin.Context.SelectScalarInt32("select count(*) from journal") > 0)
            {
                RzWin.Context.Leader.Tell("This option cannot be run if the account or journal tables are not completely empty");
                return;
            }

            if (!RzWin.Context.TheLeader.AreYouSure("you want to add the production accounts"))
                return;

            RzWin.Sys.ProofLogic.AddExampleAccounts(RzWin.Context, allowProduction: true);
            RzWin.Context.Execute("update account set balance = 0");
            RzWin.Sys.ProofLogic.RemoveNonRzExampleAccounts(RzWin.Context);

            RzWin.Context.TheLeader.Tell("Done.");
        }

        private void lnkImportQBsAccounts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!RzWin.Context.TheLeader.AskYesNo("Are you sure you want to run the QBs import? This will delete all existing account balances and journal entries."))
                return;
            if (bgwQBsAccounts.IsBusy)
                return;
            RzWin.Context.TheLeader.StartPopStatus();
            bgwQBsAccounts.RunWorkerAsync();
        }

        private void lnkCloseBooks_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Tools.Dates.DateRange r = new Tools.Dates.DateRange(Tools.Dates.GetMonthStart(DateTime.Now), Tools.Dates.GetMonthEnd(DateTime.Now));
                RzWin.Context.TheSysRz.TheAccountLogic.CloseTheBooks(RzWin.Context, r);
                RzWin.Context.TheLeader.Tell("Done.");
            }
            catch (Exception ee)
            {
                RzWin.Context.TheLeader.Error(ee.Message);
            }
        }

        private void bgwQBsAccounts_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                AddStartingAccounts(false);
                QuickBooksImportLogic.ImportFromQuickBooks(RzWin.Context);
            }
            catch (Exception ee)
            {
                RzWin.Context.TheLeader.Error(ee.Message);
            }
        }
        private void bgwQBsAccounts_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RzWin.Context.TheLeader.Comment("Done.");
            RzWin.Context.TheLeader.StopPopStatus();
        }
        private void AddStartingAccounts(bool report_done = true)
        {
            try
            {
                RzWin.Context.TheLeader.Comment("Truncating table account");
                RzWin.Context.Execute("truncate table account");
                RzWin.Context.TheLeader.Comment("Truncating table journal");
                RzWin.Context.Execute("truncate table journal");
                RzWin.Context.TheLeader.Comment("Adding Example Accounts");
                RzWin.Sys.ProofLogic.AddExampleAccounts(RzWin.Context, allowProduction: true);
                RzWin.Context.Execute("update account set balance = 0");
                RzWin.Context.TheLeader.Comment("Removing Non-RzExample Accounts");
                RzWin.Sys.ProofLogic.RemoveNonRzExampleAccounts(RzWin.Context);
                if (report_done)
                    RzWin.Context.TheLeader.Tell("Done.");
            }
            catch (Exception ee)
            {
                RzWin.Context.TheLeader.Error(ee.Message);
            }
        }
        private void lnkStartingAccounts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddStartingAccounts();
        }

        private void lnkTransferCount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QuickBooksImportLogic.GetTransferCount(RzWin.Context);
        }

        private void lnkAddRz3_Ext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string folder = RzWin.Context.TheLeader.AskForFolder();
            string[] files = Directory.GetFiles(folder, "*.cs", SearchOption.AllDirectories);
            foreach (string s in files)
            {
                string gutz = Tools.Files.OpenFileAsString(s);
                if (!gutz.Contains("using NewMethod;"))
                    continue;
                gutz = gutz.Replace("using NewMethod;\r\n", "using NewMethod;\r\nusing Rz3_Ext;\r\n");
                Tools.Files.SaveFileAsString(s, gutz);
            }
            RzWin.Context.TheLeader.Tell("Done.");
        }

        private void lnkEmailNotification_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tools.nEmailMessage m = new Tools.nEmailMessage();
            m.Subject = "Rz Test";
            m.TextBody = "Test";
            m.ToAddress = "joel@recognin.com";
            RzWin.Context.TheLogicRz.SetFromNotification(m);
            String error = "";
            if (!m.Send(ref error))
                RzWin.Context.TheLeader.Tell(error);
            else
                RzWin.Context.TheLeader.Tell("Done");
        }

        private void lnkImportGLPro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ContextRz x = RzWin.Context;
            try
            {
                nDataTable d = new nDataTable((DataConnectionSqlServer)RzWin.Context.Data.Connection);
                String f = ToolsWin.FileSystem.ChooseAFile();
                if (!File.Exists(f))
                    return;
                RzWin.Context.TheLeader.StartPopStatus("Importing file: " + f);
                d.AbsorbExcel2007File_ByFileFirstSheet(RzWin.Context, f);
                x.Execute("truncate table account");
                x.Execute("truncate table journal");
                DataTable dt = x.Select("select * from " + d.TableName);
                foreach (DataRow dr in dt.Rows)
                {
                    int main = 0;
                    bool is_sub = false;
                    int num = GetAccountNumber(Tools.Data.NullFilterString(dr[0]).Trim(), ref is_sub, ref main);
                    string acnt = GetAccountName(Tools.Data.NullFilterString(dr[0]).Trim());
                    string type = Tools.Data.NullFilterString(dr[1]).ToLower().Trim();
                    account a = new account();
                    account m = new account();
                    if (is_sub)
                        m = (account)x.QtO("account", "select * from account where number = " + main.ToString());
                    if (m == null)
                        m = new account();
                    a.full_name = m.name + (Tools.Strings.StrExt(m.name) ? ":" : "") + acnt;
                    a.name = acnt;
                    a.number = num;
                    a.parent_id = m.unique_id;
                    a.parent_name = m.name;
                    switch (type)
                    {
                        case "current assets":
                            a.Category = AccountCategory.Asset;
                            a.Type = AccountType.OtherCurrentAssets;
                            break;
                        case "current liab":
                            a.Category = AccountCategory.Liability;
                            a.Type = AccountType.OtherCurrentLiabilities;
                            break;
                        case "equity":
                            a.Category = AccountCategory.Equity;
                            a.Type = AccountType.Equity;
                            break;
                        case "expense":
                            a.Category = AccountCategory.Expense;
                            a.Type = AccountType.Expense;
                            break;
                        case "income":
                            a.Category = AccountCategory.Income;
                            a.Type = AccountType.Income;
                            break;
                        case "noncurrent assets":
                            a.Category = AccountCategory.Asset;
                            a.Type = AccountType.OtherAssets;
                            break;
                        case "noncurrent liab":
                            a.Category = AccountCategory.Liability;
                            a.Type = AccountType.OtherCurrentLiabilities;
                            break;
                        case "other income":
                            a.Category = AccountCategory.Income;
                            a.Type = AccountType.OtherIncome;
                            break;
                        case "retained earnings":
                            a.Category = AccountCategory.Income;
                            a.Type = AccountType.OtherIncome;
                            break;
                        case "suspense":
                            a.Category = AccountCategory.Income;
                            a.Type = AccountType.OtherIncome;
                            break;
                        case "units":
                            a.Category = AccountCategory.Income;
                            a.Type = AccountType.OtherIncome;
                            break;
                    }
                    a.Insert(x);
                }
                x.TheLeader.Comment("Done.");
                x.TheLeader.StopPopStatus(true);
                x.Execute("drop table " + d.TableName);
            }
            catch (Exception ee)
            {
                x.TheLeader.Comment("Error: " + ee.Message);
            }
        }
        int GetAccountNumber(string s, ref bool is_sub, ref int main)
        {
            string numb = "";
            string sub = "";
            bool in_sub = false;
            char[] chr = s.ToCharArray();
            foreach (char c in chr)
            {
                if (!Tools.Strings.StrExt(c.ToString()))
                    break;
                if (c == '.')
                {
                    in_sub = true;
                    continue;
                }
                if (!Tools.Number.IsNumeric(c.ToString()))
                    break;
                if (in_sub)
                    sub += c.ToString();
                else
                    numb += c.ToString();
            }
            if (!Tools.Strings.StrExt(sub))
                sub = "000";
            if (Convert.ToInt32(sub) > 0)
                is_sub = true;
            main = Convert.ToInt32(numb + "000");
            return Convert.ToInt32(numb + sub);
        }
        string GetAccountName(string s)
        {
            bool found = false;
            string build = "";
            char[] chr = s.ToCharArray();
            foreach (char c in chr)
            {
                if (!Tools.Strings.StrExt(c.ToString()) && !found)
                {
                    found = true;
                    continue;
                }
                if (found)
                    build += c.ToString();
            }
            return build.Trim();
        }

        //KT Refactored from RzSensible 8-19-2016
        private void lnkFixPhoneTable_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }



        private void lnkUpdateInvoiceBalances_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //KT only Invoices that outstandingamount doesn't match
            //List<string> AllInvoiceIDList = RzWin.Context.SelectScalarList("select unique_id from ordhed_invoice where outstandingamount != (select ordertotal - (select SUM(transamount) from checkpayment where base_ordhed_uid = ordhed_invoice.unique_id))");

            //KT only invoices where oustanging amount doesn't match ispaid value
            ///List<string> AllInvoiceIDList = RzWin.Context.SelectScalarList("select unique_id from ordhed_invoice where (ispaid = 1 AND outstandingamount != 0) OR (ispaid = 0 AND outstandingamount = 0)");
            DateTime startDate = RzWin.Context.Leader.AskForDate("Please select a starting date (All invoices after this date will be updated)", new DateTime(2017, 1, 1));
            string startDateStr = startDate.ToString("MM-dd-yyyy");
            List<string> AllInvoiceIDList = RzWin.Context.SelectScalarList("select unique_id from ordhed_invoice where net_profit = gross_profit and date_created >= '" + startDateStr + "'");
            List<ordhed_invoice> AllInvoicesList = new List<ordhed_invoice>();
            foreach (string s in AllInvoiceIDList)
            {
                //if (s == "3963b4b638564173942fca424850f933")
                AllInvoicesList.Add((ordhed_invoice)RzWin.Context.QtO("ordhed_invoice", "select * from ordhed_invoice where unique_id = '" + s + "'"));
            }
            if (AllInvoicesList.Count > 0)
            {
                RzWin.Leader.AskYesNo("You are about to re-calculate the balance for " + AllInvoicesList.Count + " invoices.  Proceed?");
                foreach (ordhed_invoice i in AllInvoicesList)
                {
                    i.CalculateAllAmounts(RzWin.Context);
                    if (i.outstandingamount == 0)
                        i.ispaid_Set(RzWin.Context, true);
                    else
                        i.ispaid_Set(RzWin.Context, false);
                    i.Update(RzWin.Context);
                }
                RzWin.Context.Leader.Tell("Complete! " + AllInvoicesList.Count + " Invoices updated.");
            }


        }

        private void linkUpdateQuoteOppStages_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ArrayList FormalQuotesList = RzWin.Context.QtC("ordhed_quote", "select * from ordhed_quote where date_created between '1-1-2015' and  GetDate()");
            foreach (ordhed_quote q in FormalQuotesList)
            {
                if (string.IsNullOrEmpty(q.opportunity_stage))
                    RzWin.Context.TheSysRz.TheOrderLogic.GetAndSyncOpportunityStage(RzWin.Context, q);
            }
        }

        private void lnklblCreateTestHubspotDeal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            string dealName = RzWin.Leader.AskForString("Please enter a deal name, or click OK to add a default name");


            Dictionary<string, string> properties = new Dictionary<string, string>();
            properties.Add("dealname", "RzText: " + DateTime.Now);
            properties.Add("amount", "1234");
            properties.Add("part_number", "PartNumber");
            HubspotApi.Deal deal = HubspotApi.Deals.CreateDeal(null, properties);
            if (deal != null)
            {
                RzWin.Leader.Tell("SUCCESS! " + HubspotApi.responseString);
            }
            else
            {
                RzWin.Leader.Tell("FAIL " + HubspotApi.responseString);
            }




        }

        private void lblCloseSalesOrders_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DateTime startDate = RzWin.Context.Leader.AskForDate("Please choose a start date.", DateTime.Now.AddMonths(-1));
            DateTime endDate = RzWin.Context.Leader.AskForDate("Please choose a start date.", DateTime.Now);
            ArrayList salesOrdersList = RzWin.Context.QtC("ordhed_sales", "select * from ordhed_sales where isClosed != 1 and orderdate >= '" + startDate.ToString() + "' and orderdate <= '" + endDate.ToString() + "'");
            RzWin.Context.Leader.Tell(salesOrdersList.Count.ToString() + " sales order results.");
            List<string> newlyClosedSalesOrders = new List<string>();
            foreach (ordhed_sales s in salesOrdersList)
            {
                bool alreadyclosed = s.isclosed;
                if (!s.isclosed)
                    s.Update(RzWin.Context);
                if (!alreadyclosed && s.isclosed)
                {
                    if (!newlyClosedSalesOrders.Contains(s.ordernumber))
                        newlyClosedSalesOrders.Add(s.ordernumber);
                }
            }

            if (newlyClosedSalesOrders.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("The following sales orders were just closed:" + Environment.NewLine + Environment.NewLine);
                foreach (string s in newlyClosedSalesOrders)
                {
                    sb.Append(s + Environment.NewLine);
                }
                RzWin.Leader.Tell(sb.ToString());
            }

        }

        private void lnkSetRecentTabs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Delete any existing   

            RzWin.Logic.SaveOpenTabs(RzWin.Context);
            //ArrayList recentTabs RzLogic.GetRe.xSysRsGetRecentTabs();

            //ShowRecentTabs(recentTabs);
            //if (recentTabs.Count > 0)
            //    if (RzWin.Context.Leader.AskYesNo("Would you like to delete those tabs?"))
            //        DeleteRecentTabs(recentTabs);


            //if (RzWin.Context.Leader.AskYesNo("Would you like to save your current tabs?"))
            //    SaveRecentTabs(recentTabs);

        }

        private void llOpenRecentTabs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RzWin.Logic.OpenRecentTabs(RzWin.Context);
        }

        private void lnkCreateQbSaleFromRzLine_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RzWin.Leader.Tell("Yup!");
        }

        private void llManuallyShipStock_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ContextRz x = RzWin.Context;

            try
            {
                //Set a batch ID so all these parts and the invoice can all be associated
                string batch_id = Guid.NewGuid().ToString();




                x.Leader.StartPopStatus("Beginning manual stock lines ship procedure ...");
                List<string> manualShipUniqueIds = new List<string>();
                //Provide a list of Partrecord Unique_ids
                //manualShipUniqueIds.AddRange(GetTestSystemPartrecordIds());
                //manualShipUniqueIds.AddRange(GetHarrisLotBuyIdsMarch2019());
                manualShipUniqueIds.AddRange(GetManualShipParts());

                //Limit results
                manualShipUniqueIds = manualShipUniqueIds.Take(14).ToList();

                //Check for empty
                if (manualShipUniqueIds.Count == 0)
                {
                    x.Leader.Comment("No partrecords identified for shipping.  Ending process.");
                    return;
                }

                //Warn and confirm with user
                if (!x.Leader.AskYesNo("You are about to manually remove stock items, and ship those line items for  " + manualShipUniqueIds.Count + " partrecord(s).  Are you sure you want to do this??!?  (This process cannot be undone)."))
                {
                    x.Leader.Comment("Procedure canceled by user.");
                    x.Leader.StopPopStatus(true);
                    return;
                }

                //Get the Invoice Company to associate with (i.e. who we are selling to)
                x.Leader.Comment("Getting the Invoice Company from the user.");
                company c = null;
                companycontact cc = null;
                x.Leader.ChooseCompany(x, ref c, ref cc);
                if (c == null)
                    throw new Exception("Invalid Company");



                //Must be an existing Invoice, get it from the user.
                ordhed_invoice i = null;
                x.Leader.Comment("Getting invoices for " + c.companyname + " from user.");
                i = x.Sys.TheInvoiceLogic.ChooseExistingInvoiceForCompany(x, c);
                if (i == null)
                    throw new Exception("No invoices found for " + c.companyname + ".  Please create the invoice to associate this shipped stock to.");
                x.Leader.Comment("Invoice Identified:   " + i.ordernumber + " (" + i.unique_id + ")");
                //Move the partrecords to shipped stock.
                List<partrecord> partsMovedToShippedStock = new List<partrecord>();

                foreach (string inventoryUId in manualShipUniqueIds)
                {

                    partrecord p = partrecord.GetById(x, inventoryUId);
                    if (p == null)
                    {
                        //IT may have been already deleted, let's confirm the unique_id for the part is in the shipped_stock table
                        shipped_stock ss = CheckShippedPartsTableForPart(x, inventoryUId);
                        if (ss != null)
                            x.Leader.Comment("Missing part " + ss.fullpartnumber + " found in shipped_stock_table.  Proceeding.");
                        else
                        {
                            //proceed = x.Leader.AskYesNo("ID does not exist in Current partrecord table, it may have been deleted previously.  You might want to confirm that this ID is present in the shipped_stock table.");
                            //if (!proceed)
                            throw new Exception("Could not find a partrecord for ID: " + inventoryUId);
                            //else
                            //x.Leader.Comment("Skipping missisng ID: " + inventoryUId);
                        }

                    }
                    else
                    {
                        //Part Found, move it to shipped_stock
                        x.Leader.Comment("Part identified as : " + p.fullpartnumber + " MFG: " + p.manufacturer + " QTY: " + p.quantity);
                        x.Leader.Comment("Setting invoice and batch identification for part.");
                        p.shipped_stock_invoice_id = i.unique_id;
                        p.shipped_stock_invoice_number = i.ordernumber;
                        p.shipped_stock_batch_id = batch_id;



                        //If this exists in the Shipped_stock table, it's already been moved, and just needs to be deleted from partrecord
                        x.Leader.Comment("Checking to see if this part already exists in the shipped_stock table");
                        shipped_stock ss = (shipped_stock)x.QtO("shipped_stock", "select * from shipped_stock where unique_id = '" + p.unique_id + "'");
                        if (ss == null)
                        {
                            x.Leader.Comment("Moving partrecord to shipped_stock table");
                            p.MoveTo(x, "shipped_stock");
                        }
                        // Add this partrecord to the list to be deleted later.
                        partsMovedToShippedStock.Add(p);
                    }

                }
                x.Leader.Comment("Successfully moved " + partsMovedToShippedStock.Count + " partrecords to shipped_stock.");

                //Associate the invoice with this batch
                x.Leader.Comment("Setting shipped_stock_batch_id for Invoice (" + i.ordernumber + ")");
                i.shipped_stock_batch_id = batch_id;
                i.Update(x);



                //After successful move, and invoice Attribution,  go ahead and delete.
                x.Leader.Comment("Deleting Parts from Inventory.");
                List<partrecord> partsDeleted = new List<partrecord>();
                foreach (partrecord p in partsMovedToShippedStock)
                {
                    x.Leader.Comment("Removing " + p.fullpartnumber + " from inventory.");
                    p.Delete(x);
                    partsDeleted.Add(p);
                }

                x.Leader.Comment("Successfully deleted " + partsDeleted.Count + " partrecords from inventory.");

                //Done
                x.Leader.Comment("Done!");
                x.Leader.StopPopStatus(true);
            }
            catch (Exception ex)
            {
                x.Leader.Comment(ex.Message);
                x.Leader.StopPopStatus(true);
            }
        }

        private shipped_stock CheckShippedPartsTableForPart(ContextRz x, string unique_id)
        {
            string sql = "select * from shipped_stock where unique_id = '" + unique_id + "'";
            shipped_stock ss = (shipped_stock)x.QtO("shipped_stock", sql);
            return ss;

        }

        private IEnumerable<string> GetManualShipParts()
        {
            return new List<string>()
            {




                "CA4B8518-A9F3-48D2-B052-85BD1D46456F",
"4025963E-33A6-40B1-9B83-E0D533443519",
"ED65C4C7-4BFB-42BA-B1E3-98227AFC4C22",
"75E34C84-E073-482E-946C-35D4417678EA",
"19EF6998-E77A-4871-9297-4A8862FEC585",
"B3C37992-D951-4336-9C24-F09EDCA2D5B0",
"ACD541A2-ED3C-4580-BE11-FBC695A152EF",
"35608C52-08D3-46B4-809B-B09E85F57F87",
"638A1F02-5642-4671-A14E-D86E4213289E",
"674D562A-8FF5-4575-AF9C-4C1EF5856FF8",
"F389374A-47A8-4960-AA3D-06896897EE8A",
"000F8C08-D6B4-4FC8-B373-748BE14DDA21",
"C5D67597-F4DE-456A-B460-E245D2B1C6AA",
"D83121B9-A79C-4353-971A-22A18DA8EF5D"


            };

        }

        private IEnumerable<string> GetHarrisLotBuyIdsMarch2019()
        {
            return new List<string>() {
                 "38CC4CC7-E467-4CEF-817E-76CF56A7CFF8",
"39E139E8-7DBB-49AD-BCD1-E1EE65872CA6",
"5905B13B-7727-4CD6-874C-FDED140E9D9E",
"D54E6D41-3758-4D47-B3A3-70322B5478AE",
"B485F4FC-BA42-47BF-96EF-61135BFC7D4D",
"079BC723-70C1-46FE-84B0-3DED5EC6F82E",
"3F9D84B5-0D94-4F2F-8486-3392555A6AE7",
"3034C323-2A65-49E9-BC55-E70A34BCD47D",
"4A1CF485-1C9E-4481-AD43-B8223411E895",
"632BEFAC-23D6-43F7-9726-569C92CF1BB0",
"78C6C13D-DCBB-45DC-9FA3-6D8A375C3B47",
"5DDFF997-20B3-4B37-AC75-C6AEC822438E",
"1C3F37A6-DE70-494C-A49C-30464C7C61C6",
"EA222509-8B39-436F-BED1-461410FCD1CE",
"72EEB46B-CF63-4146-9B20-FBE0E09AB00F",
"C3F517C9-9FF1-43EB-BC6F-955957EEC969",
"D6A1EDE7-E12C-41CB-8598-D681821EC81F",
"4432CE26-E97C-43BC-A8C7-F80FBC96DEFB",
"0A380FF7-C6F8-4129-89BD-E0659B5FE955",
"2C8BD2AB-F446-45E5-8662-0389B583BC95",
"AEDA2D28-C1A0-4EFF-A570-AEF00818E1DE",
"AB02D704-F4CB-42DF-9613-946B9ACA9B57",
"F82CA56F-6F00-4142-9DA1-7FEA31A9FA40",
"058F474F-C6A1-409E-B01C-EC9AC35B5E6C",
"1D2CFFE0-8183-4102-B75D-B58820CB416B",
"6CA9EB7A-9BE7-4BCE-BF69-85BE7B4269DE",
"CB60D676-0436-445B-9D51-A7649DBE0C31",
"8EA62111-6BCE-4DD2-B361-0836B246F816",
"B34A8105-8CE6-4FFA-9F43-91960331ABA7",
"4AE9FCBB-D9DB-4A95-B21C-5D51FB5CA3B0",
"18AE5D22-691A-4ADB-A26D-DCE2F5DD2961",
"9B7D47BA-C124-454A-91A0-0FF9AAE1999D",
"9C5C617E-E5F0-4B90-8754-F47BA280AF50",
"DA484CC3-0808-4631-A12E-AEEA1CC6307A",
"46DF6032-A0EB-460C-B325-78EE0D1ABE26",
"8BEDE34C-37B0-4D86-B39B-58E6F02BB87E",
"2D3AA49E-A8F9-44EC-B5BF-E38166580B2A",
"73C2A345-407E-4A7E-9421-2A9EA0E6BD2A",
"71E551C9-B34C-4B68-9378-B9C862B655D9",
"C78A2EB8-C38C-4503-BD33-FFEF2191CA31",
"C5233848-B23F-4CBB-9ABF-49926E2F92A5",
"0F5BF133-9663-43AE-9C0B-A74676627C4C",
"5F558940-06D1-471B-91C4-8DBEF4E559BD",
"6A0AA3E6-A2AF-41E1-902B-52116F5F19B3",
"79D8E1AF-81C9-4FA5-A160-CED6DCD63804",
"B72E5E6C-A3F8-4859-A96A-C45FD6F214CF",
"EF0B9C38-9256-40A3-98E6-3E0A712D0024",
"95314BEB-14E0-4808-9BB3-9BA82B8BE825",
"6FAD02EA-BC06-4BBF-9C8E-D8463541905D",
"D6623B98-01C2-4911-9BD3-3F6B07EDCA99",
"E39D43B0-73BC-426F-8722-48E7C90FA1EF",
"A7DEE779-01BE-4176-BBB1-277160EC9CF2",
"167A6EAF-9C40-47FC-82E5-5120567EC2F3",
"E69E7D3D-6B5A-4CDD-B946-523A52D059DA",
"10FE1413-58EF-4413-8361-A6661C2B945D",
"69B6379B-9B45-4427-A0BE-D9928BDD22D2",
"899E43F0-EECE-4C95-A59F-4817FABA0E86",
"35448427-8ADD-43E8-9C06-1430FC8E5146",
"CD28BEF0-A324-4EB3-BF0B-9ECF3963F2BC",
"911D7FFA-855E-4F97-A784-AC9921EC7F23",
"9333EC6D-66F7-4729-917D-41B08980E76C",
"248AF844-DCEB-41A1-8F59-B60D37588C2B",
"052C8A4D-4775-4782-9B53-1AD76616F580",
"8A0736B2-B046-4FAA-9917-8D6353974774",
"6A8593A4-7669-49B0-A531-B37224B3F543",
"378AC085-8BAC-4100-953C-753BCDB7C024",
"36856A68-6A80-4D70-B87B-1AD7E0E7E6CE",
"54E9ACBF-EA02-49EF-B78E-829A77E3CC8A",
"792C715C-6331-47A7-871C-F220E41C1873",
"25ADCADB-5874-4947-A6EB-7964B8AA02B2",
"A2BCC03A-FB07-4302-8CE9-4630BC3ADB97",
"9D192EF1-ECC6-4724-80E3-D2302C5FC66C",
"FE9F6B7A-70B3-4C01-8F38-4667111AE4FD",
"6AE3426D-417B-43CE-BB51-3168259DB2CE",
"1C84A685-4CBD-4759-BC13-0A2394B07844",
"8742DA30-1647-45A9-B581-C9F9AF10D87D",
"7487A588-3824-4D58-AFF0-FBBE98DAEF85",
"7A88A29D-DADE-4653-8F56-912E329DD7D3",
"0D9058EC-530B-49FF-9E47-0753A0579DBA",
"CF3CD9A1-8ED7-4C16-9B7E-E7F86727759F",
"A9CB9B1A-E4D6-472C-8096-AAB9D38FA61E",
"E6EF0C37-FA04-4680-9CF1-63DA32B27032",
"3DAD1B42-12CC-47BE-A5EE-1BE8A49FE932",
"DE39DBED-12C8-47F6-9B59-DCC45C0C7907",
"8D499B53-E986-444C-9B55-A10663BAEFB2",
"274828ED-C6CD-4C17-B1D7-E03D8F8044CD",
"3EC63B19-F399-4A1D-B084-4A997AB39CE7",
"E3A7074A-4299-4BC5-AF1C-AC734F1F57DE",
"B4ADDE3E-C77B-4CCA-BE30-B659FEB03E6F",
"C26E30FD-CB3A-4781-BB17-81B899C970B0",
"226FDE5E-B3B6-490C-9B5B-58F761FB10E6",
"DBFF370B-5F10-4A82-A25B-7232435EAAFE",
"993FB4BC-628B-4844-A3AD-E0EB5DE9BCA3",
"a7576f02199046609052d9227a1c474a",
"F091C8D2-E883-496A-ADE2-03FF7643A157",
"538034C3-871C-4AF6-B51A-2804154737EB",
"E35D6828-7BA4-4366-8EE9-866C06701F2A",
"81753073-9AFC-4B63-A4B3-18B832A84C0B",
"17CBFA64-3AA3-40EB-9024-01F8A58B67AA",
"DF5A0C5E-89DE-4668-8A38-903BF3F3F848",
"980DAE38-F869-4E2B-90F2-AFEAE030E0AC",
"45A2D6E2-778A-46B0-BD6E-37E4D9B334DB",
"E1726271-2742-45C1-92F1-C56B60F72C64",
"701C0C1A-E056-46F9-AEC5-D9240543F1F1",
"8E702FC2-C59D-473B-B00C-B95FF614784C",
"228345D5-FD5D-4BDD-BEA7-9FFF2FF2183F",
"69CAF460-1AEB-4BAF-BF41-0064E4E378CE",
"D4A629E9-F209-4EB9-83D5-DFBFBFEFA589",
"4579BB09-6AEC-4B2A-B41D-563260B31AEA",
"0D918F4D-A1D8-4200-9DC3-745888B944E7",
"B93AE87E-2DCA-435E-9E7C-252A8414F1D9",
"D1F6B55C-AADB-413C-B0E5-C60FBD815845",
"39B1BDD0-EE35-446A-B0FF-3AB9C34351BF",
"9EA4F13D-4975-43BA-A16D-ABEF8CEABCD2",
"A139B024-50A2-45EC-8960-DA73C23AA612",
"04D305C4-9E2D-4FC3-A757-DB854E619C4A",
"0C493A78-0FA7-48A0-9340-2CE017581286",
"A1731F1E-A8C8-41C0-9CFE-0442F36E77B8",
"2250135C-2E4A-4452-837C-872FC4818C41",
"F1ED9997-A0EC-4EE7-91CF-1E454C200AB4",
"F4E4E9FB-54D1-4E0F-8AD9-48894439FB52",
"C1ABBBB0-6DE0-48E5-9960-9C0340A88AF2",
"B77C1249-86A9-448F-9F8D-B358B069266F",
"07B1B6F4-F3DA-40B6-B123-D61913AD8640",
"FF41B846-75E2-4F70-B831-A51D01DF35A5",
"56B5E2A0-D944-490C-A830-52482DC9ECC5",
"BEA07C90-E519-45E8-A2C8-3E88E8B5C1EB",
"DEC343C6-B3CB-42D0-AF84-4ACDDC103E88",
"4EF3F929-CB63-483E-A4EA-FD80A84E8C19",
"16BC5884-C3E3-4B6D-B9F9-79903C2F9DF3",
"E0B902A2-50D4-46F6-8D7C-02215E192986",
"EB451DFE-FF74-4FD9-94D8-BF07A005F366",
"2C5F2526-3B34-4C47-A761-49CF6F984084",
"EE6D7DC4-A01C-4349-8C58-DCDB27A896F6",
"343F3D7B-0E46-4FA1-8CAF-EE188947244E",
"9D0B5891-76F6-4187-833B-503979F333F7",
"ABFB18D9-5632-4A89-AC61-9B240CD1578B",
"17CCD4FA-8756-48D4-AD1B-849D3E7376E2",
"c7c8f05a23a34a28a87a858e03584709",
"FF7C979B-87E3-45E5-B3E6-8830CDFFAB70",
"F71F6CE4-E0BD-493D-8C63-2F5BF61E6F1D",
"682439CA-87B7-401B-8994-346D097E7109",
"AC24EA01-F85C-4F4A-87EB-101DE2134EBC",
"9F29B739-46D0-4331-B69A-34CA059F2049",
"E9355C3A-4E14-4A64-8226-69DB69F0D6DD",
"2C932451-AB29-43B3-B84D-ECA6B65A84C6",
"8DFF9C5D-5B1B-4675-B782-444B4BACF954",
"FC7919D7-DE6C-4276-BEAC-E00A728F540B",
"FF351FF5-5A42-4F46-ACAD-410E9CB6FD29",
"7559EF1E-D288-4935-A455-4BE1230B6127",
"8A926876-6035-4D4D-9711-38E0DE63FDDF",
"70AA95AD-B79C-48FD-BC1A-EA31FAD1350F",
"B2D1E5CC-D36F-4F40-9DD5-B1F69B27CE05",
"12305F79-9D0F-4E31-BFD0-0BC1C652D822",
"BC1DEA32-A16B-4D06-B3C2-C11C362CCDF4",
"7E959410-E5EB-4C92-9030-862290997528",
"9668761A-C60F-43A4-8C8A-D2D52ACD703D",
"9E736315-B596-4386-92A6-BC79CCC288F9",
"543CED13-7BC0-489E-888E-FA61C463D712",
"ea51e6fb84d3477495987b2aaed20912",
"C0375611-7A2C-4FD3-B7A3-F9B85B2FE8BA",
"15FA8B67-C286-4DD8-A882-8AE50DD62AD4",
"1B40183D-F8F7-4416-A3A8-1D0A0FF64A2A",
"56A3010A-B9BC-46D8-8A3F-707FE7E6D68E",
"DBE40C5A-7D94-4B54-B830-808585D5D688",
"BEAE58D7-3C78-47E1-9C59-2BE633F776A5",
"459FCBAD-B21C-4354-9AB4-96B5FB2C11F1",
"21CE3272-E75D-4892-B669-731BE0260EBC",
"2CCDF6D0-DA78-475C-BA8D-334A29169BAB",
"E728B84A-556E-4D38-AD21-BD15970A44DC",
"40F61299-8561-4241-88FA-099D7BAEEA66",
"667F71AC-71FC-49FF-835B-A836A6B4C532",
"1D5CFC3B-2F93-4D5F-98F2-2C01A0E16FF8",
"CDD8B340-EC68-4474-918D-744AE2FA3E7E",
"3FCDBA54-F3BA-4AB8-B11D-E090038E17FC",
"FE031B02-01C6-47D2-AD54-6188F675ACDB",
"80AA2A46-028A-48A5-8FF3-18318FC57852",
"F583F0D2-6F2E-46EC-B49E-9F91376D4F14",
"7EC51CEE-B7B4-4771-B1FA-A71092E0B30D",
"6677D613-0836-482F-8817-258EFB18108B",
"49F3B5A5-F903-4D8F-B542-A2C03054D4AF",
"55C0C0C5-EACA-41F7-B444-486F6D182FFB",
"85358FF0-48BA-4D59-8F8F-129E99C916CE",
"49736447-DC90-499B-AD47-8C78672FE2BE",
"010439FF-7DFD-4D24-9700-1C5BB8A22CE6",
"DBB448A2-EC84-4706-9139-44BCD2EE22BF",
"77F86465-32C2-40BE-8A4C-8AA07A0EE323",
"1075ADEA-DCEF-4073-904A-CC0ABCD8CF28",
"6635735F-E209-4E43-BEA4-0A8C05AC71AB",
"6F3D230C-CF5B-41E8-96FE-FAC67AC9D784",
"7610797D-BA64-43B5-AC2C-7BCC298BF93D",
"369E362C-B1C0-46C2-9E63-12A9CBFE9B7A",
"558F4C32-81EB-4BC4-A772-F9161BEF74B3",
"343204DD-7453-45DE-AF70-789B8DEE37FA",
"E584EBA6-7F2B-4C7E-A806-9B6C653C3D2A",
"D1747691-6A6F-46C0-AD4F-04354828B57B",
"D3AC9656-24C1-4AFD-A160-D7D586FB90C2",
"40866E80-29C8-44A6-A6FA-4494C1789F9F",
"4A375C03-0576-4F13-B005-C5A244BD681D",
"AFE54241-9A7F-4381-8EDF-48E52A5D30CB",
"EA8D862B-6AD8-486F-989B-29DE19258BD3",
"7224B3C4-6967-43CD-8F7D-4E8944EF1823",
"973EFFEF-1474-4747-AC20-460478D1C004",
"9B0B0CFB-0327-4E71-982C-951AC33BCA3D",
"7E300822-F5C0-4579-8E81-20D917CDEC54",
"D6805A83-AE55-4058-8F30-AC0AF527A1B7",
"35175D0B-88AD-497F-8705-06987907677F",
"AC13BB22-C2B5-4C9E-90D2-0E33FC08FA57",
"10396781-00B0-4DEC-9E60-444D51C541BF",
"708AF9BF-A1B7-49FC-A082-3014F3B04549",
"6398805B-9564-4F17-AB50-062D71611B3B",
"ACF48194-BB2D-45D0-AF27-29F73B117F22",
"DB9B0EAA-17AA-42F6-9A04-A7BB883CDE7A",
"C7CAD8CF-5573-4588-8BC4-C9841C455D1B",
"C9854111-27D9-4DCE-A128-69A8185F7E79",
"4AEC049C-4BC2-41EF-97CC-4E720A203038",
"10435D53-5F5B-4230-BB25-E1BACBF419FB",
"8EB30A1A-ED16-4F5A-9E83-A194C0759244",
"52144D74-B8E4-48A8-90EE-B55557FF217C",
"c6a0f69d422641e5a75f04fb83fbcb8a",
"D0FE37EB-1CA3-4F5A-A302-C69D6266CAD0",
"D0990125-8E9B-438D-8FB1-2B60CC5EBE76",
"CADA4736-6030-4B88-A2BA-56057185F1D5",
"33C71114-187E-4A2E-8617-6D7488A27115",
"5C86A57B-F28A-4594-9B9E-7833A276EECD",
"92A602DB-95A1-4183-B59C-CF5351F2E691",
"D1392F51-92CF-4CB2-A973-5393A300D57F",
"EFE73981-3BDC-4478-862C-888B4F16756D",
"D9B99055-A225-47FF-AB9B-2D70DC9D0526",
"A77F03BB-87FC-4EDF-BF61-329FAB3077F8",
"72971A5E-AB7A-43CE-965C-7A1EA887CF36",
"1F88F34C-5E15-4A78-A682-7C36ABA3C3AC",
"87E9460C-FD55-4FD5-952B-716FADE82782",
"F6420D08-0FDB-415C-89E8-C6792C130B00",
"A6BACC34-8246-44F5-B5DF-86E7783284EE",
"69EB87C2-33F6-4964-9E54-368D66C41C6B",
"055BC8BD-AB2F-48CC-B7A7-B9AA1E62B5FA",
"0E8CB4FB-2D90-498D-9A8F-DD07B62E544B",
"F974C559-F182-4535-8BBB-11AB13C2F3E3",
"26411D87-0CF8-4FB0-8ACD-68494E68AC9C",
"AFB2DACD-C993-4FA6-89E0-2FD03B580A7D",
"AEF609F6-5362-43B7-8B30-2546DBBEAAE9",
"F6A1CB85-A0ED-4D5F-BA2F-4C409707E047",
"60d827518efb437eb9e82f16a9fdaf85",
"80BC4979-3EE3-4970-B6A9-2AC07B0E8387",
"7AC19C6C-773E-4FD7-98DF-B5163CEEC9E1",
"6F032663-274F-411A-A8DF-E4136D2DD645",
"0FC5262F-86A1-4BEE-8101-F48671CFA296",
"B2C0D044-E2D5-41FE-840B-F095861A9CEF",
"77463B15-0A09-4A2A-A286-F07964705587",
"D72C8272-6519-431B-AD92-0A9A7E68940C",
"F9B09DFC-3D37-4AE8-817F-F3024387E839",
"AD6661B6-E7E7-4350-B8AD-41321A4938AF",
"A1496AFE-44FB-465D-9A35-06F907B92D88",
"F1FE6E10-F8B6-467F-AF18-46E1FCAFC615",
"DA81833A-ED25-42A7-B72B-62454124F255",
"59674A7F-73C9-4BD4-B9F8-40604210E04E",
"8F07DECC-F333-43B8-AF4D-F750C3D1CBA2",
"2B8BE5BA-7417-4C77-AC58-C486307164F3",
"76C266BA-8B3F-4B94-A732-283BE8F9CEA3",
"3EA51EFB-E17F-40B8-BDF4-B6166934340B",
"D7EB168F-DEC8-460C-B637-F013EE492357",
"ED1E06AD-5164-4797-904F-A9E619A76162",
"A4C90489-5C68-4660-A027-D817E6F77625",
"FB55F5BC-8A0A-41A3-9D91-DCB2ED270CFF",
"A2E4C12F-E8ED-4A27-80C3-FBDA83CDD50C",
"FCBA8B97-0253-487F-B2AD-DA9186F499DC",
"A4892AD4-2F3F-4E1E-BCD2-5852E1D0974E",
"448ED399-3421-4055-85EF-C5B350189123",
"EF2D92AB-560C-4FBD-AD9D-E0B8B7A906F1",
"C3C17EF9-FE82-4D76-82D5-E857FDE4F0FA",
"B6E70F50-A8BF-443F-A756-537A3AA4199C",
"74317F7A-DC40-42EE-A3AF-6585D4F2844A",
"4EFAD6B1-BB0C-4F66-B171-FB4C4E06EEA7",
"E6D59DBC-C88B-476E-987B-E301202DFF4D",
"11E71FC5-CE56-41D0-8855-F9551E812648",
"7EE391E6-0908-4526-AA16-2DC253DB00B5",
"BD39DE9B-D82D-48AB-8B9F-6A5A88C14F64",
"E297BF1A-9962-41BD-AE6B-B22ED102E25F",
"7EEF52D7-722F-4BA2-8593-815768A058C0",
"86D38BB4-1AB5-4EBC-B6C7-BBBCA4C324F2",
"FD3CD938-07B9-4BB7-8CBB-6A8AF62DAB09",
"BF6A6A93-6A23-4CF8-8A7B-AC1BDE99D441",
"A466371F-1F75-4421-B59A-3877D3CCE530",
"3C8A5230-51AF-4D57-8B70-4DDB63B66957",
"853CDFB4-933A-4B3E-BCF9-D7C18751C442",
"749D072F-DB9E-4C5A-AF15-1C3E38C0D192",
"B0AF860A-959A-4EC0-BF20-48A5FFF0BE96",
"6D512ACE-0769-4E38-B19B-238EEA172E9A",
"B052D796-8D09-41B8-92E0-5B6B18410502",
"06641C47-0142-47CD-B0F7-4DD29828A48F",
"05F4B9BE-5192-4283-A04D-32B2C2BA79ED",
"492582BF-7BF4-4E02-8DD6-7571509947A9",
"EE126B3D-5B60-4474-850F-06165A903AB8",
"A4674B6E-7006-4492-9FF7-C51DCB8E6172",
"42899CF9-F2FA-44E4-BB30-3C64A7E4B5F4",
"3299E920-1BB0-4BFB-8DBE-171888FA650B",
"97752A78-B97E-4CAC-A7EE-44FDD1ADD567",
"E7D4FE2F-FFC4-4DE4-81E2-8080A0B17C11",
"790F9A04-60BF-495E-8649-B23AC83499A0",
"57113854-C168-4A2B-886D-28DDF93F6912",
"A4859C1A-F4CD-446E-89C0-E11069EA032B",
"E63AB281-FA01-4BF0-8ED1-D47A6916A8B6",
"D7E5F150-9CCE-4A1E-99D4-BE5AA54B47E0",
"D12D4A4D-2160-4263-8AF6-259D1E561CF1",
"E1DEB8B6-AF1E-4FFA-B1C9-BF23169209AC",
"1D130E2E-835F-4619-BB17-8F7858325ED2",
"7FD9CF92-7481-48A5-8A5B-B973895A0746",
"A5A41F73-CDDD-4101-A7E0-EC8745EF748A",
"8933DCB9-6989-4EDD-9BB3-C793B4984FEC",
"869BEBD0-76FE-47B6-BACC-896C8EB9F693",
"E8A16113-CA88-4723-9614-C3C2ADCC6379",
"B93D82C1-5DEE-44C9-8D59-EA9BA3DB1D62",
"57B092BF-A862-4CBB-B45A-62BD4336CCEB",
"8A324B33-6FA8-4498-8EAA-509D763641B2",
"0bf7fcdc378b47d1939ce54717ba95ab",
"A6C3EAC5-39DE-45F3-9121-5427B3DF3B67",
"080B4A61-DE4C-4A62-8A62-4FB13453DFF5",
"E08A460D-AEEB-4EE8-B125-91614924A750",
"8802A39D-5656-4546-9ACF-725985383B4E",
"DCEF1BD0-0F63-42B4-814B-DC8297F1AF00",
"1A020F5A-DC60-4919-A998-AAAF8FCD3265",
"D3C480E6-7BD9-4D30-A51A-F8F7311E77EF",
"72DA54CD-D6FE-4C51-8722-5835B1C08255",
"8F8C420A-24D5-48CA-99AF-02A8FF6F298D",
"CB55DCB2-DC4C-4448-9ECC-69F9FDFA9EA2",
"5CE6B6A2-05A4-40ED-A4A9-09FD8F8D2F68",
"C714F26E-AF11-4687-B898-D1A9CE868D25",
"41BE1DA6-18E2-45E3-8A8D-BEE9C632B2AF",
"A2DD8FB9-0CB3-4A5F-9885-F08CFE6B6B39",
"39B802B2-B5E6-4EF2-B5E0-1B00C995FF85",
"BBC1EC19-82A8-4C87-94FF-F3EC72123A35",
"0B3A200A-6569-45E8-9F13-B3024FB0B570",
"9403F184-6083-4BBD-97C6-1D13FF8C8C72",
"366C60A5-2751-45F9-BC07-E0564722C610",
"4798DC7C-BEB2-4CC6-8BEF-B733BDB63794",
"8E4EDC88-D3E4-456B-BCC7-258CA4ACB28B",
"F49F4C18-4C56-4AEC-BD3A-9AB37EA69699",
"408F2D08-0799-44E8-919E-9DFCBBFA20FD",
"A1E4DB19-53A2-4A75-9F7B-D45500F15D9F",
"0D8CE93E-AECC-4F6E-958A-E6B757BB9B44",
"6FF8371D-8D38-49FA-91FC-A6A26ED93B35",
"A0B81CE6-3C6D-4BCC-ABF8-835975A19600",
"FEDBFBD9-2EEF-4216-94E0-50B8DD030732",
"754775F7-5CEB-4DC8-954E-DF7CD818D096",
"EF6C2C5B-C308-4867-B7FC-FD3E7FBFD024",
"23AE005F-44B0-454E-9D14-E83DF2947189",
"6E7CA2EA-9F6B-4B84-9433-BAE4F7069623",
"76318FF5-F0C1-46EE-8C06-73B9593083E0",
"B9CB1FC1-7967-4222-B219-786CB73AF7D1",
"9F60C1AF-3F45-4FB8-B66D-0EE81059D916",
"57A64C5A-C44D-4B48-8B57-C580C9A6D34F",
"F4D2D8FE-4AA1-400D-A84C-079E53801635",
"DE8447A6-51A7-4A99-867C-8599A4A3D291",
"9FC8FB4F-A415-4F10-958B-2DB8FFB3557A",
"6D0BF4D1-31B7-480D-8A01-C7D6229ABD97",
"5e93ee3b1b214297af6980b5419e99f0",
"6C26177B-8693-4DCD-AA9E-031EC67A16C4",
"B2884A7E-9D12-45AD-8F1D-09C0B3FEFC17",
"64022DC2-E36A-4D5B-8914-821365C5BB2C",
"FD08CA6F-A05F-433F-80B8-B54F53BD0CAC",
"61CA291D-B8DD-45CF-B346-79D259C03A0F",
"AE2D6292-5EAA-4121-BBDE-16D54FA6F029",
"E681B031-58BF-486D-B635-9924D864B675",
"D6C9295D-5145-40D7-8387-FA7B0A54EC05",
"96D8FD9D-6DD3-4D5E-BEDD-7B3158D7F0C7",
"CE706265-F67E-4DBC-9BF9-C6B962660348",
"31820D20-59B2-46FC-9F3D-932721DB0C39",
"2E4A93FC-C5F7-4DB6-8868-4F010DC7816C",
"BE2F7F9D-CBA1-48FB-87BE-EDE78638AA1A",
"7CB99A2A-8AD6-4009-ACA0-8B52D7949F18",
"962DAF33-447D-4DB4-AF0D-5BC8FEE2644C",
"0B36B909-75C2-4EAF-A62D-B23F76067B23",
"5FF455D8-9D78-4DC8-BC64-624FCF65B976",
"AC7DD496-71B0-492B-81B7-5069ED045C82",
"5C505C8A-8BF2-41ED-9227-3EFAF88E3F71",
"C5431FC5-921C-4F74-9E45-C4D7726D9972",
"41B0A1D1-5D0C-46DE-A2E1-2F3AFEE86330",
"BEAF6ACB-3A95-42C9-AD3F-66AA6D3BFC2F",
"A8287788-CAD9-4D6B-8F54-965F4F068E9F",
"1F0FB118-433D-4557-ACC5-E7CC70E2421F",
"FD47FCCA-5BC4-47BC-BF84-C48234079BCF",
"9D994F7E-276F-406B-B9C7-0C93E1D92924",
"D552E77F-FB16-4F54-84D0-FFD34B983014",
"45CA4786-7833-4294-84E4-D186208AD356",
"F11F4170-C0B4-4F4D-8A77-9814394C69AF",
"BA7C9B4E-31D3-4BD8-8555-F23F39462120",
"5DDB42B6-6E8C-472C-921C-B70171DA2B39",
"2BC75780-BB9C-481E-B57B-CD3F2FF5C3D3",
"02B0B63B-5833-4B3C-82B1-BD2D7C8CAC18",
"2F12723C-E610-4EC5-88A2-660E0CDAA776",
"C21BB463-AF10-4C3F-9418-8F549BFD5020",
"125F87FE-76BF-401C-B9D9-C3C4A84B61B0",
"581B1027-FA4F-4D4C-AA35-960B056AFBCB",
"345A7376-C963-45D4-B044-6AF44E6C7109",
"D201B90E-132D-46F1-A2CF-03B433D3F00F",
"38C7C36A-97AD-4728-B45D-E9EEDA4BC82D",
"30553CFD-387E-4947-9BB8-AFF3898DAB2D",
"E1202B62-4FE0-47B1-BA28-126753D84FBE",
"8AC4F6A2-BBB6-4883-B6A7-F4FB6B5EF7CF",
"9DC732DA-D8A6-4EAF-A6D2-05875A01658C",
"0DC342C2-5179-43B6-89F2-AA457BBCD3AD",
"274D2A44-1DDC-43FB-8F7C-F5A9395CB3C7",
"68007EF4-B202-4C8E-8A4A-A90DA11EA7D5",
"8248A55A-E70E-4932-9E5E-BCE36CAE42BA",
"117DAC08-61AC-43C9-AD17-8ACD00ED6656",
"789CEB55-80DD-4CD1-9461-236B0B63A6C9",
"1C5C84DF-3E16-4F28-9072-92B3718B5045",
"88A726B0-265C-437B-9D65-E29A3EB33FA1",
"AE381D1A-C41F-4BB7-8A2E-E497B6CB17D3",
"681C11AC-412B-4A5D-B38C-B32123799BEB",
"ACC77AB7-889F-4BC9-9B04-6E82365967CA",
"AAD2A255-2096-4C49-BC4C-8E0685C9FBBA",
"CB8DD1BF-4D38-4C3B-9BD9-3CC1291FCA34",
"06379791-80B2-4D0A-AF9D-70E736A0AA34",
"12E02A8E-5B6D-4249-876D-FE5E85B95E76",
"7F3825C6-E799-4EE6-A3F1-454A20671870",
"634956EC-524F-4DA9-8AA6-2002E90EBBE8",
"8dd3e6fc5b7c4c36912791833cae0d10",
"090B0984-FFB1-4419-9843-4E79AA7889CA",
"03703313-D5BA-4B65-A475-2164CC89CCCE",
"8AC68834-23FB-4110-8AAB-CACE9DE06BB4",
"1B449E6E-B327-46B2-A6EA-F5D5DF66B73F",
"5BEC1BA5-7432-4DCF-BA97-33C5FCE7DAF2",
"C597A9AA-23F9-4875-91E6-96ED2F8B1193",
"F03954CD-9914-4C03-B8C1-7A44F244CA75",
"13D80F59-EA18-4B54-884D-EA9A7AAC8AE9",
"981B4DC1-6E52-46D5-B431-AE21534C9E7A",
"13D8152A-DBD4-4011-A9E9-40B8604DB4B8",
"307B8051-AA77-43CA-89A3-0305F7AD3180",
"7B64E2AB-B27B-4B6E-B7C4-CC298D149601",
"88C94B7A-493A-4331-A94F-529CC5F6BF64",
"B2F8AEF4-D727-437A-A583-135EC6AEF81F",
"DCFC38CB-4B10-4421-9C8F-8DF5A5978AF2",
"B8D8F7C1-3929-4D19-9EBB-F44DBB9A4CDB",
"CA23AD66-AE6E-49A1-8552-BFEFEEDEDC7F",
"3F57E15A-D8EE-4D11-AFAD-B93469ED2487",
"688EF051-2FAF-45CB-AED7-95750B5DA816",
"1949FB06-0564-4BD1-92FC-8AD30039A72D",
"B755A6D4-C5E0-44AF-9FAF-3D521E9E3B2D",
"BA597F5C-C527-4B4C-AD86-C5876ABFFEA6",
"BAD9CD62-7400-419E-9F97-EAC2D5579D5C",
"1E7704B8-59A1-4F52-AC09-D3A8D7695984",
"1EBA9274-F469-4FCF-B010-85CB7F26D249",
"2925FBD2-B1E0-4D05-BCB0-F7138573B704",
"583BF0A6-DFFD-4E40-B417-F9CCD5E52CE3",
"D322D160-30A5-4723-A112-D3D7DD31E763",
"CD3F755F-CAB7-4E62-B871-811733CDECF8",
"FE53079C-C2F9-4BE8-AEEA-B41A36B41A99",
"439812D8-AA84-4CB2-87E1-EC23EE3832CE",
"DFC2E410-8968-4330-BE65-BBD0EF9149E3",
"604BE5ED-F4D5-4038-9540-A3FE3E203813",
"B4D2CEE2-DB50-4D58-934B-6DB9FDF8C1AC",
"81308CCC-A3D2-49C9-B94C-B738278A12A1",
"A741ABAC-ACE8-4DCD-9634-420FCEEBD8E0",
"62D1C6EA-FBEA-47BA-A945-CA364900D032",
"31BD3479-1D83-4179-9A87-9F9E6E1DCFCA",
"0C04894A-D5A1-48CF-AC75-22DC885F3755",
"7029F85F-CDA5-489E-B75B-BE004C0D6D03",
"92B195CC-AF5B-44D1-8B1B-EA42BA2612C5",
"05F559B3-F2C4-45E9-AC88-7568553709F9",
"2646E9CB-F07F-42D6-835F-BA616C679DE0",
"03F84B07-B9E6-4D19-BADD-F81C9305A557",
"35132BAE-C47F-4A8B-8107-432FF90CA0DD",
"EFE42124-D9A4-421C-A3C5-2E1B2EBEB840",
"81E0FE43-C118-4579-9BB0-7AEEC58603B4",
"557D7E08-51D7-4E9E-B386-1D50E5408A1F",
"67EFFACA-31E7-40AB-A14F-A645C33EF712",
"A827E3E2-F48F-4F91-AE31-BF70B07F376E",
"7E34CC9F-1D38-46C3-8D4B-310ACED0668F",
"CC121523-FA40-4E6A-864A-1F86DA4DDD4C",
"A5B0CCC3-5DA2-43BC-A315-890D3C2B2D05",
"83029d4c52bd4444afb4bf910a09b7ab",
"B1D230EE-F33D-45CA-9897-5181B33854E7",
"2829C037-C197-44DF-9F90-59DBDFEC8E34",
"D10A9B45-1BBA-4C9D-8A73-6E19C2C98456",
"C8A47E13-3442-4F4F-B110-DDB1019BE0EA",
"01737687-DDAB-448C-8209-350BBFC38F67",
"EF44B9E5-BBB6-472F-9422-B4A7EE152DE8",
"6CC4BD52-0F21-45D1-835E-2356F5B0BC33",
"3FD4BD02-7586-4EB2-89C5-3059565602AC",
"ADF49D6D-B29D-4300-8F8F-FE74CAEA3E7A",
"4AD2D565-F69B-4432-8649-A83CD8BC4E28",
"34DA7A63-4ECB-4448-AA1C-4DBA57A6C791",
"2BCC5E5F-71B7-4594-97EF-92A7C779A841",
"180C9C46-70B2-463C-A3C1-B3051280C8C4",
"0B6DC947-752D-4F6C-87AF-C8750AD8DC06",
"DF4A3276-0613-4850-A642-26D6EFBCEA0B",
"74C1B8CD-D080-4E19-8EFB-BED975FA3C3D",
"AA0E297B-E94A-4CBA-B422-1A376F20D085",
"871e0035b5614a068d838008280f6288",
"8F8BAC2B-A6E7-440F-82AB-D723F8A49628",
"35BF591B-15D4-4BB7-8A06-E2FC37BA9E47",
"DC25E04C-5239-4ADA-98D4-ABE8370710EA",
"C8781153-3438-4A29-BD1C-DFD5A65B1525",
"3798CC00-104E-45FD-B127-C0F7377492D4",
"3A0C176C-A722-4D5B-AF4D-CFA37A76F27A",
"BF61EE45-29AA-409C-BF8C-9823B642ED2E",
"B7AB1747-4C9D-4327-A8AE-738022F84F9B",
"0387664D-2B75-416B-B1F3-0B3BF735C733",
"57EB9713-1DFF-4554-9EFE-18FF89EA6BFA",
"2FB3C34A-1C57-4DC9-B07B-1AA74210FE0E",
"6D9DDD0C-CCFF-46E4-B783-FA6D92B75355",
"E1330C56-816E-465B-881A-ECBDF8C57DF8",
"A3DF7B2F-A9C1-4ECC-8555-D8C326EA69C1",
"0183576B-B5A3-466A-B664-2A0D57216064",
"bab7a51e7f704d5d8b83458383d3cb81",
"DC6F70DB-600B-411C-916F-255014214460",
"B191A100-13B4-4EB4-A7FE-0A7822B04B2A",
"6CAC176F-C3DB-4CCC-A39F-3FE8D494B9E5",
"94051444-D63C-4970-ACD0-3C337EB960B4",
"96C47B11-7416-45CB-A4ED-8B282871B9FB",
"F360D67C-5725-468E-8D39-86535C25BADE",
"3748DA4D-488B-4B45-B3F6-9600A81D7C07",
"C28B9D23-DEC5-4886-9536-7AF729096905",
"cbe3793f984b4c6d85721dfc997636a1",
"A901BF0F-AE72-4D0B-8B26-7CBBB28EFC5E",
"F7F4D949-C1E2-4CDA-88FD-AB35E89CB627",
"91ECB199-19C6-4A41-A31C-C467C326ECFB",
"C145F281-13AF-48C8-B429-283ECD7E0155",
"A3E64D36-06FB-4070-BBE2-CFCF3884259C",
"61F2B7B3-7572-4F24-ADA0-7D73D5AB70DE",
"D58CD275-E8F7-4714-B55B-6A92AA7AB13D",
"F3D2CC3B-6E6B-4817-B253-D924A0813F26",
"AAA6D6DD-AB1A-4279-B70F-EAEC0022CDFE",
"D73788EB-786F-4013-9B35-B295016E412F",
"0197B503-3349-4BD2-8FB2-E1566FD43ED3",
"EC47ADEE-0AA8-4094-BB9F-B5C9D2B9E1F8",
"AB603C58-D0F4-4BCE-9B6F-1E7EC284799B",
"50026820-D21E-4AAD-83BF-215435279573",
"71D83C84-E855-4890-BA06-1146A8D370CC",
"5842C8B6-5025-4305-97AA-ABB7AE53CFF2",
"D779DF20-C128-4F88-9D7C-8A181DDFC092",
"5EE44700-A7E4-4D07-A43B-2A1086AA3A46",
"0D6628DC-F4F9-4916-A7DB-707705F70A26",
"EB70DF10-2293-408C-9F83-741878C5765C",
"6C145DF1-9E48-4AA4-9866-459D2555839D",
"B6282A16-7A7F-496C-A564-572DE2252BD0",
"4585F2D5-979B-4411-8B15-037848E7A41F",
"033A5DB0-C5B4-467B-887A-0F7DDA4B9648",
"99A0F4A8-D284-4EB9-846E-187EC6559793",
"64B38CDB-992E-48BF-BB52-E4FAA3C73D0D",
"FB30A1EB-4A63-499D-B109-4281D6DE30A8",
"CBD6EC97-A158-4997-B6BA-98A6621D3186",
"0D6EC333-1ED9-4A83-AA77-8171EB4CB1A2",
"4CBE405E-83CE-482F-9330-931AE3AD0DDE",
"B5F7BC3B-879C-4FEE-97EB-94894783CCF0",
"D45C65CD-3347-4AB1-A72E-88772035F97E",
"FBB8B548-E9B7-48A5-A630-815B4FF3A447",
"52DB85E1-045F-43A8-A158-229D9524CA4C",
"FA71BEB3-DDFF-4AEA-BC63-2C30C6F4DC64",
"0EFECAC9-3CFF-4850-80F6-07E15ED37CF9",
"594E8B8C-46D1-40E3-A0E2-543449EF657C",
"5F4A0671-3F73-4277-B8E9-7FF8E741AA21",
"F44ADF9D-BE32-4684-B910-ACD7C8A05A35",
"A4F59BC2-CF69-45DA-9BBD-5B392F8DC8EA",
"F390522B-141F-4BD9-BF50-E74443F6C119",
"FE3391D6-EC6B-465C-84C1-E906681A6D57",
"433D81F1-AA9B-4154-AF37-C1B4EF0BF2F4",
"373BDF4A-65E2-493E-B2DD-AC548D4568E7",
"001927E0-130A-433B-BC39-499949279A2E",
"5C3EE42F-266E-457E-A253-56FB43A8DFD7",
"EBB4D557-EDE9-466D-9E0A-087C8DE68BA7",
"E9BEC44A-A764-4684-AA37-EDD45F897850",
"4CC4B98A-7658-478E-B4B9-3B5ED5CCB553",
"FB777351-5287-4DF6-9DEA-4F45843BB48F",
"D0BC2F0A-4768-48B4-8E52-1A341FCEEDF1",
"7FBE0CB0-A1A8-4626-950B-82505B2B4D81",
"F1CCBC31-EC1B-4F7A-894F-4E653CEED0F1",
"4964A7DA-B29B-4E85-A35F-570F3DAD832E",
"ADA79B4D-576E-49B8-AB66-4A0EB2777CDD",
"9E02E2A3-6CFA-4280-964B-EA73A544E550",
"45ACA5D4-C420-4F67-9F12-3B6BD448E02F",
"55FFE11C-5743-4078-8D8C-4111FC403EC5",
"979E1B40-35CD-43A4-8B30-EC8A5E8CC28B",
"5764E2FC-5E98-4B17-A7EB-9AD9EB6F0D61",
"28927062-E081-4A19-8710-12B420779D82",
"AAE543B6-305D-4808-9C8B-C55362ECD0BE",
"E393F570-9253-4678-B5E9-FCF19CA84033",
"876417A0-2CE6-4867-8683-06BE8FF8ABBD",
"4593D97A-C1F4-41EF-8178-068D7B002665",
"1DF5A795-D7EC-4ACC-BDA7-A5BEDFCD8902",
"EB8CF062-EAF0-4100-8FCE-EC2174A55FDA",
"89E324FA-75BB-4510-8C1B-BCBE8633F4F1",
"AF54EFAB-8903-486B-A89E-5C575287992E",
"7F0C1C2D-3E36-4C19-8307-1256C43335E5",
"62CC9DE6-82A5-48B5-8529-8AF490D30CA1",
"C7C9F64C-AA1B-41F1-B9AB-82BDAF790271",
"B6535D8A-6CCB-4C40-9BCC-A19D820F4FF8",
"67B2F934-2D55-49A6-A817-7589C48DA715",
"C5A9182F-E6FC-445E-A352-04022794ACE1",
"621DA123-6DB2-4C50-8A7E-9FC3F57A6270",
"1CADDB9C-90C8-4972-9FB9-30CCB4B946E1",
"4C82F405-E7A0-46DE-99D1-ECC518D8A382",
"3AA3FB86-5B38-4B38-818A-ACF50F66073C",
"93A840C9-FE0B-44C2-A56A-AADEACB4992B",
"eddfa1e44f314f3d85a96e4bc56d3563",
"5A254E53-2C83-465A-8332-951538324656",
"3D3A140D-0ACD-4931-8DC2-68BC3AC9985D",
"6F53C911-13F2-41D7-9888-F8DA3430B13C",
"E4230051-8131-4FA8-AD50-97C2ABAD9D4D",
"236D270E-56E0-4A5C-BD2C-5FCB02CAA333",
"8C639C0F-F820-42C8-B32A-A6582582DF2C",
"ED1FC50F-ACD4-44FC-94A7-5469D8025C91",
"121B80D7-2709-4D02-BEF6-8C059A7556F5",
"D8639D21-F8AB-4EE3-A4AA-41B2FF702C8B",
"F7223DE8-C9B2-423D-A192-2A9277EB4B5F",
"FB1D8918-F98E-4CA5-AF80-B92F3FD9907C",
"52A1E40B-08FB-4306-8EC1-ACF586F3F7E5",
"6A221F9D-28BA-42FD-BB78-3F47615C8AEE",
"F1D6FCD2-84DA-4125-A4E3-972451E0930D",
"1DA71670-4329-4AA1-8A50-831C36E62F64",
"B96AE4F0-CC1B-4E5A-AE74-39974D0E5758",
"7BBA0BA0-E6BB-4934-B8FE-FA6D66829655",
"4AA4D881-73E4-4E93-957A-CEA158983936",
"32FCFDE4-3769-45C6-873D-FCE61CB80472",
"1E43FA42-506F-4CB1-AF85-1AD5777B70E1",
"00FCAC04-1B53-416B-836F-AD99712E9811",
"C5F26FFC-B7F1-48C7-8A94-4D212349B0E3",
"52AE774D-0A87-4822-98FD-0251A49161A8",
"72495776-70B8-4A5E-AFC6-CFF5DF2EF391",
"503FD749-88CE-4F6E-A643-D756AE29D0BD",
"0F640DE6-E028-4982-ADE6-146435020B62",
"45901D61-F471-4B86-8D55-E30AB29A810C",
"45CFCD14-50A1-4044-9B93-FEA50B63640A",
"FF8FB359-FAF0-4B90-9A64-DFB82A2B8242",
"1E890EF5-0783-4467-B2D7-C03AF223D2DA",
"9D68B2E3-417F-497A-9BEB-7C37872AAB17",
"8F176EFE-BC57-4C26-B7DF-4BD487AB862C",
"8BA38B29-7701-456C-9989-162D3CE7500A",
"0DDE89A6-1900-42E9-8FFA-115B33502565",
"A48BA95E-0175-492F-B9F7-C6FB6CE3BAA1",
"01F6938C-FFEE-4FEE-A5F1-0379136C92B3",
"B77723E9-280B-40F7-A600-877384011CE7",
"39e5cd3a1adc42b19ffaf68fa0426d8d",
"96ACC595-8839-40BD-85D1-CBA811D8CA2F",


            };

        }

        private IEnumerable<string> GetTestSystemPartrecordIds()
        {
            return new List<string>() { "4ee4c89376084f8fab8fbf0d0be6b7b4" }; //
        }

        private void llShowQuickBench_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RzWin.Context.TheLeaderRz.QuickBooksSettingsShow(RzWin.Context);
        }

        private void llUpdateHsQuotes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //try
            //{
            //    List<ordhed_quote> qList = RzWin.Context.QtC("ordhed_quote", "select * from ordhed_quote where orderdate >= '1-1-2019' and isvoid != 1 and ordernumber >= '0032363' ").Cast<ordhed_quote>().ToList();
            //    RzWin.Context.Leader.StartPopStatus("Updating " + qList.Count + " quotes ...");
            //    int i = 0;
            //    foreach (ordhed_quote q in qList)
            //    {
            //        if(q.hubspot_deal_id <= 0)
            //        {
            //            RzWin.Context.Leader.Comment("Quote #: "+q.ordernumber + " has no hubspot deal id ... skipping ...");
            //            continue;
            //        }

            //        RzWin.Leader.Comment("Updating quote# " + q.ordernumber + " ...");

            //        HubspotApi.Deal theDeal = HubspotApi.GetDealByID(q.hubspot_deal_id);
            //        string currentDealName = theDeal.properties.Where(w => w.Key == "dealname").Select(s => s.Value.value).FirstOrDefault();
            //        string currentDealAmount = theDeal.properties.Where(w => w.Key == "amount").Select(s => s.Value.value).FirstOrDefault();
            //        RzWin.Leader.Comment("Current HS Deal Name: " + currentDealName);
            //        RzWin.Leader.Comment("Current HS Deal Amount: " + currentDealAmount);
            //        //long l = 0;
            //        //bool isInt = Int64.TryParse(currentDealAmount, out l);

            //        //RzWin.Leader.Comment("Quote amount missing.  Updating to " + q.ordertotal);
            //        if (string.IsNullOrEmpty(currentDealAmount))
            //        if (theDeal != null)
            //            {
            //                RzWin.Context.TheSysRz.TheOrderLogic.UpdateHubspotDeal(RzWin.Context, q, theDeal);
            //                i++;
            //            }



            //    }

            //    RzWin.Leader.Comment("Finished. Total Records Updated: " + i);
            //    RzWin.Leader.StopPopStatus(true);
            //}
            //catch (Exception ex)
            //{
            //    RzWin.Leader.Error(ex.Message);
            //}

        }

        private void llUpdateHsDeals_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                //Get List of Batches with No Hubspot ID from 2020 that are not already closed;
                RzWin.Leader.StartPopStatus("Creating deals for batches that are missing a hub id.");
                List<dealheader> lstDealheaderNoHubID = new List<dealheader>();
                RzWin.Leader.Comment("Geting list of batches with no HubID ...");
                lstDealheaderNoHubID = RzWin.Context.QtC("dealheader", "select * from dealheader where date_created >= '1-1-2020' and hubspot_deal_id <= 0 and is_closed != 1 and LEN(isnull(contact_uid, '')) > 0 ").Cast<dealheader>().ToList();
                RzWin.Leader.Comment("Found " + lstDealheaderNoHubID.Count + " batches with no HubID ...");


                int i = 1;
                foreach (dealheader d in lstDealheaderNoHubID)
                {
                    RzWin.Leader.Comment("Item " + i.ToString() + ":  Creating deal for batch: " + d.dealheader_name + " ...");
                    HubspotApi.Deal theDeal = HubspotLogic.CreateHubspotDeal(d);
                    if (theDeal == null)
                    {
                        //For some reason deal not able to be created?
                        RzWin.Leader.Comment("Unable to create deal for  " + d.dealheader_name + "(Company: " + d.customer_name + ", Agent: " + d.agentname + ") ...");
                        continue;
                    }

                    //Deal successfully created.
                    RzWin.Leader.Comment("Deal created, HubID: " + theDeal.dealId);
                    i++;
                }



                RzWin.Leader.Comment("Finished. Total Deals created: " + i);
                RzWin.Leader.StopPopStatus(true);
            }
            catch (Exception ex)
            {
                RzWin.Leader.Error(ex.Message);
            }

        }


        private void llFixOtherMfg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                ContextRz x = RzWin.Context;
                List<orddet_quote> otherQuoteList = x.QtC("orddet_quote", "select * from orddet_quote where date_created >= '4-1-2020' AND target_manufacturer like '%OTHER%' AND LEN(isnull(fullpartnumber, '')) > 0 ORDER BY target_manufacturer ").Cast<orddet_quote>().ToList();
                List<string> partList = otherQuoteList.Select(s => s.fullpartnumber).Distinct().ToList();

                if (partList == null || partList.Count <= 0)
                {
                    RzWin.Leader.Tell("No parts with improper mfg found.  Nothing to do.");
                    return;
                }

                //Get an In memory list of matches with a report
                string report = "";

                foreach (orddet_quote q in otherQuoteList)
                {
                    string matchedMfg = x.TheSysRz.ThePartLogic.GetMfgMatches(x, q.fullpartnumber, true, true);

                    if (!string.IsNullOrEmpty(matchedMfg))
                    {
                        q.target_manufacturer = matchedMfg;
                        q.Update(x);
                    }


                }

                x.Leader.StopPopStatus(true);
            }

            catch (Exception ex)
            {
                RzWin.Leader.Error(ex.Message);
                RzWin.Leader.Comment("Error: " + ex.Message);
                RzWin.Leader.StopPopStatus();
            }
        }

        private void llChooseManufactuer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            //i.CompleteLoad(RzWin.Context);
            frmChooseManufacturer f = new frmChooseManufacturer("somerandompart", true);
            var result = f.ShowDialog();

            if (f.DialogResult == DialogResult.OK)
            {
                string manufacturer = f.SelectedManufacturer;
                RzWin.Leader.Tell(manufacturer + " was selected!");
            }
        }

        private void llTestSerilogLogging_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SensibleDAL.SystemLogic.Logs.LogEvent(LogType.Error, new Exception("Rz Test Serilog Logging").Message);
        }


        private void llCreateSplitCommissionObjects_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            //RzWin.Leader.Tell("This is currently not needed, just need to set it for upcoming / new splits. Manually");
            //return;

            //For each object that can have commission (Company, orddet_quote, orddet_line), can skip dealheader here and ordhed_Sales here, they won't carry ID, only their related lines.
            List<company> splitCommissionCompanies = new List<company>();
            List<orddet_quote> splitCommissionQuotes = new List<orddet_quote>();
            List<orddet_line> splitCommissionLines = new List<orddet_line>();
            splitCommissionCompanies = RzWin.Context.QtC("company", "select * From company where len(isnull(split_commission_agent_uid,'')) > 0").Cast<company>().ToList();
            splitCommissionQuotes = RzWin.Context.QtC("orddet_quote", "select * From orddet_quote where len(isnull(split_commission_agent_uid,'')) > 0").Cast<orddet_quote>().ToList();
            splitCommissionLines = RzWin.Context.QtC("orddet_line", "select * From orddet_line where len(isnull(split_commission_agent_uid,'')) > 0").Cast<orddet_line>().ToList();

            CreateSplitCommissionObjects(RzWin.Context, splitCommissionCompanies.Cast<object>().ToList());
            CreateSplitCommissionObjects(RzWin.Context, splitCommissionQuotes.Cast<object>().ToList());
            CreateSplitCommissionObjects(RzWin.Context, splitCommissionLines.Cast<object>().ToList());


        }

        private void CreateSplitCommissionObjects(ContextRz x, List<object> splitCommissionObjects)
        {
            
            x.Leader.StartPopStatus("Starting split commission object creation.");

            int index = 0;
            int total = 0;
            try
            {
                
                split_commission sc = null;
                foreach (object o in splitCommissionObjects)
                {
                    index++;
                    x.Leader.Comment("Processing object " + index + ":" + Environment.NewLine);



                    //string split_commissionID = "";
                    string agentName = "";
                    string agentID = "";
                    double commissionPercent = 0;
                    string splitType = "";


                    //Create the Split Commission Object
                    if (o is company)
                    {
                        x.Leader.Comment("Processing company " + ((company)o).companyname + Environment.NewLine);
                        agentName = ((company)o).split_commission_agent_name;
                        agentID = ((company)o).split_commission_agent_uid;
                        commissionPercent = GetCommissionPercentFromDesignType(o);
                        splitType = ((company)o).split_commission_default_type;
                    }

                    else if (o is orddet_quote)
                    {
                        x.Leader.Comment("Processing quote line " + ((orddet_quote)o).fullpartnumber + Environment.NewLine);
                        agentName = ((orddet_quote)o).split_commission_agent_name;
                        agentID = ((orddet_quote)o).split_commission_agent_uid;
                        commissionPercent = GetCommissionPercentFromDesignType(o);
                        splitType = ((orddet_quote)o).split_commission_type;
                    }

                    else if (o is orddet_line)
                    {
                        x.Leader.Comment("Processing order line " + ((orddet_line)o).fullpartnumber + Environment.NewLine);
                        agentName = ((orddet_line)o).split_commission_agent_name;
                        agentID = ((orddet_line)o).split_commission_agent_uid;
                        commissionPercent = GetCommissionPercentFromDesignType(o);
                        splitType = ((orddet_line)o).split_commission_type;
                    }


                    if (string.IsNullOrEmpty(agentName))
                        throw new Exception("Unable to set agent name variable");
                    else if (string.IsNullOrEmpty(agentID))
                        throw new Exception("Unable to set agent ID variable");
                    else if (commissionPercent <= 0)
                        throw new Exception("Unable to set commission percent variable");

                    x.Leader.Comment("Creating split_commission object ... " + Environment.NewLine);
                    sc = split_commission.New(x);
                    sc.Insert(x);                    

                                        
                    sc.split_commission_agent = agentName;
                    sc.split_commission_agent_id = agentID;
                    sc.split_commission_percent = commissionPercent;

                    //Link the split Commission Object to Rz Object (Set Rz Object Split Commission ID)
                    if (o is company)
                    {

                        sc.base_company_uid = ((company)o).unique_id;
                        ((company)o).split_commission_ID = sc.unique_id;
                        ((company)o).Update(x);
                        x.Leader.Comment("Successfully linked company to split commission object." + Environment.NewLine);
                    }

                    else if (o is orddet_quote)
                    {
                        sc.the_orddet_quote_uid = ((orddet_quote)o).unique_id;
                        ((orddet_quote)o).split_commission_ID = sc.unique_id;
                        ((orddet_quote)o).Update(x);
                        x.Leader.Comment("Successfully linked quote line to split commission object." + Environment.NewLine);
                    }

                    else if (o is orddet_line)
                    {
                        sc.the_orddet_line_uid = ((orddet_line)o).unique_id;
                        ((orddet_line)o).split_commission_ID = sc.unique_id;
                        ((orddet_line)o).Update(x);
                        x.Leader.Comment("Successfully linked order line to split commission object." + Environment.NewLine);

                    }

                    sc.Update(x);
                    x.Leader.Comment("Successful!" + Environment.NewLine);
                }
                total++;
                x.Leader.Comment("Successfuly created "+total.ToString()+" split commission objects!" + Environment.NewLine);
            }
            catch (Exception ex)
            {
                x.Leader.Comment("Error: " + ex.Message + Environment.NewLine);
                SensibleDAL.SystemLogic.Logs.LogEvent(ex);

            }
        }

        private double GetCommissionPercentFromDesignType(object o)
        {
            string splitType = "";
            if (o is company)
                splitType = ((company)o).split_commission_default_type;
            else if (o is orddet_quote)
                splitType = ((orddet_quote)o).split_commission_type;
            else if (o is orddet_line)
                splitType = ((orddet_line)o).split_commission_type;
            switch (splitType)
            {
                case "design":
                    {
                        return .10;

                    }
                default:
                    {
                        return .05;
                    }
            }
        }

        private void llCreateListAcquisitionSplitObjects_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            RzWin.Leader.Tell("This is currently not needed, would require new properties on the line item like list_acquisition_split_id.  Amost just as easy to read from the line item.");
            return;

            //For each object that can have commission (Company, orddet_quote, orddet_line), can skip dealheader here and ordhed_Sales here, they won't carry ID, only their related lines.           
            List<orddet_quote> splitCommissionQuotes = new List<orddet_quote>();
            List<orddet_line> splitCommissionLines = new List<orddet_line>();           
            splitCommissionQuotes = RzWin.Context.QtC("orddet_quote", "select * From orddet_quote where len(isnull(list_acquisition_agent_uid,'')) > 0").Cast<orddet_quote>().ToList();
            splitCommissionLines = RzWin.Context.QtC("orddet_line", "select * From orddet_line where len(isnull(list_acquisition_agent_uid,'')) > 0").Cast<orddet_line>().ToList();

            CreateListAcquisitionCommissionObjects(RzWin.Context, splitCommissionQuotes.Cast<object>().ToList());
            CreateListAcquisitionCommissionObjects(RzWin.Context, splitCommissionLines.Cast<object>().ToList());
        }

        private void CreateListAcquisitionCommissionObjects(ContextRz x, List<object> list)
        {
            x.Leader.StartPopStatus("Starting list acquisition split object creation.");

            int index = 0;
            int total = 0;
            try
            {

                split_commission sc = null;
                foreach (object o in list)
                {
                    index++;
                    x.Leader.Comment("Processing object " + index + ":" + Environment.NewLine);



                    //string split_commissionID = "";
                    string agentName = "";
                    string agentID = "";
                    double commissionPercent = .03;
                    string splitType = SM_Enums.SplitCommissionType.list_acquisition.ToString();


                    //Create the Split Commission Object                  

                    if (o is orddet_quote)
                    {
                        x.Leader.Comment("Processing quote line " + ((orddet_quote)o).fullpartnumber + Environment.NewLine);
                        agentName = ((orddet_quote)o).list_acquisition_agent;
                        agentID = ((orddet_quote)o).list_acquisition_agent_uid;
              
                    }

                    else if (o is orddet_line)
                    {
                        x.Leader.Comment("Processing order line " + ((orddet_line)o).fullpartnumber + Environment.NewLine);
                        agentName = ((orddet_line)o).list_acquisition_agent;
                        agentID = ((orddet_line)o).list_acquisition_agent_uid;
               
                       
                    }


                    if (string.IsNullOrEmpty(agentName))
                        throw new Exception("Unable to set agent name variable");
                    else if (string.IsNullOrEmpty(agentID))
                        throw new Exception("Unable to set agent ID variable");
                   
                    x.Leader.Comment("Creating List Acquisition split object ... " + Environment.NewLine);
                    sc = split_commission.New(x);
                    sc.Insert(x);


                    sc.split_commission_agent = agentName;
                    sc.split_commission_agent_id = agentID;
                    sc.split_commission_percent = commissionPercent;
                    sc.split_commission_type = splitType;

                    //Link the split Commission Object to Rz Object (Set Rz Object Split Commission ID)   
                     if (o is orddet_quote)
                    {
                        sc.the_orddet_quote_uid = ((orddet_quote)o).unique_id;
                        ((orddet_quote)o).split_commission_ID = sc.unique_id;
                        ((orddet_quote)o).Update(x);
                        x.Leader.Comment("Successfully linked quote line to split commission object." + Environment.NewLine);
                    }

                    else if (o is orddet_line)
                    {
                        sc.the_orddet_line_uid = ((orddet_line)o).unique_id;
                        ((orddet_line)o).split_commission_ID = sc.unique_id;
                        ((orddet_line)o).Update(x);
                        x.Leader.Comment("Successfully linked order line to split commission object." + Environment.NewLine);

                    }

                    sc.Update(x);
                    x.Leader.Comment("Successful!" + Environment.NewLine);
                }
                total++;
                x.Leader.Comment("Successfuly created " + total.ToString() + " split commission objects!" + Environment.NewLine);
            }
            catch (Exception ex)
            {
                x.Leader.Comment("Error: " + ex.Message + Environment.NewLine);
                SensibleDAL.SystemLogic.Logs.LogEvent(ex);

            }
        }

        private void llTestEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SensibleDAL.SystemLogic.Email.SendMail("rz_email_test@sensiblemicro.com", "ktill@sensiblemicro.com", "Rz Email Sandbox Test", "This is only a test.");
        }
    }
}

