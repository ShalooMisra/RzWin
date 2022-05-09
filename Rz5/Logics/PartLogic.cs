using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Core;
using NewMethod;
using Tools;
using System.Windows.Forms;
using SensibleDAL;
using System.Linq;

namespace Rz5
{
    public partial class PartLogic : NewMethod.Logic
    {
        //public virtual void ActionHandle(ContextRz context, ActArgs args)
        //{
        //    ArrayList objects = new ArrayList();
        //    foreach (IItem i in args.TheItems.AllGet(context))
        //    {
        //        objects.Add(i);
        //    }

        //    switch (args.ActionName.Trim().ToLower())
        //    {
        //        default:
        //            n_sys.HandleActionNM((ContextNM)context, args);
        //            break;
        //    }
        //}
        public virtual void GetSearchPermutationsExtra(ContextRz context, PartSearchParameters pars, ArrayList a, string strPrefix, string strBase)
        {

        }
        public override void ActsListStatic(Context x, ActSetup set)
        {
            base.ActsListStatic(x, set);
            ActHandle h = new ActHandle(new Act("Parts", new ActHandler(PartSearchShow)));
            set.Add(h);
            ActsListAddInventory(x, h);
            h.AddSubSeparator();
            h.SubActs.Add(new ActHandle(new Act("MultiSearch", new ActHandler(MultiSearchShow))));
            h.SubActs.Add(new ActHandle(new Act("OEM Products", new ActHandler(OemProductShow))));
        }

        public override void ActsListInstance(Context context, ActSetup mnu)
        {
            base.ActsListInstance(context, mnu);
            ActsListParts(context, mnu);
        }

        protected virtual bool CanSetStock(ContextNM context)
        {
            //KT Commented Out for Refactor
            //return context.xUser.SuperUser;  //2012_10_29 changed from simply 'true'
            //KT Refactored from RzSensible 4-29-2015

            if (context == null)
                return false;
            //if (context.xUser.CheckPermit(context, Permissions.ThePermits.CanManageCommission))
            //    return true;
            if (context.xUser.CheckPermit(context, Permissions.ThePermits.CanChangeStockType))
                return true;
            return context.xUser.super_user;
        }

        public override void ActInstance(Context context, ActArgs args)
        {
            //KT Commented Out for Refactor
            //List<partrecord> lines = new List<partrecord>();
            //foreach (IItem i in args.TheItems.AllGet(context))
            //{
            //    lines.Add((partrecord)i);
            //}
            //switch (args.ActionName.Trim().ToLower())
            //{
            //    default:
            //        base.ActInstance(context, args);
            //        break;
            //}

            //KT Refactored from RzSensible 4-29-2015
            List<partrecord> objects = new List<partrecord>();
            foreach (IItem i in args.TheItems.AllGet((ContextRz)context))
            {
                if (i is partrecord)
                    objects.Add((partrecord)i);
            }
            switch (args.ActionName.Trim().ToLower())
            {
                case "printwhselabel":
                    PrintWarehouseLabel((ContextRz)context, objects);
                    args.Handled = true;
                    break;
                default:
                    base.ActInstance(context, args);
                    break;
            }
        }
        protected virtual void ActListLabels(Context context, ActSetup mnu)
        {
            ////KT Commented Out for Refactor
            //mnu.Add("Print Label");
            ////KT Refactored from RzSensible 4-29-2015
            mnu.Add("Print WHSE Label");
        }


        public ArrayList GetCompanyConsignmentCodeList(ContextRz x, string companyID)
        {
            return x.Data.SelectScalarArray("select distinct(code_name) from consignment_code where vendor_uid = '" + companyID + "' order by code_name");
        }

        //KT Overbuy alert - Overbuy is a stock bid on batch##
        public void OverbuyAlert(ContextRz x, partrecord p, object o, bool alert = false)
        {
            try
            {
                if (p.is_overbuy)
                {

                    List<string> toAddresses = new List<string>();
                    n_user overBuyOwner = (n_user)x.QtO("n_user", "select * from n_user where unique_id = '" + p.purchase_agent_uid + "'");
                    //orddet_line purchaseline = (orddet_line)x.QtO("orddet_line", "select * from orddet_line where inventory_link_uid = '" + p.unique_id + "'");
                    string poID = x.SelectScalarString("select l.ordernumber_purchase from orddeT_line l inner join partrecord p on l.unique_id = p.purchase_line_uid and p.unique_id = '" + p.unique_id + "'");

                    toAddresses.Add(overBuyOwner.email_address);
                    //string emailtest = x.xUser.email_address.ToString();
                    toAddresses.Add("sm_sales_management@sensiblemicro.com");
                    toAddresses.Add("ktill@sensiblemicro.com");


                    if (alert) //Tell User
                    {
                        x.Leader.Tell("Alert!" + p.fullpartnumber + "is an overbuy from " + overBuyOwner.name + "'s Purchase Order #" + poID);
                    }


                    string ordertype = null;
                    string ordernumber = null;
                    string quantity = null;
                    string customerName = null;
                    string test = o.GetType().ToString();

                    switch (o.GetType().ToString())
                    {
                        case "Rz5.orddet_rfq":
                            {
                                orddet_rfq rfq = (orddet_rfq)o;
                                ordertype = "order batch";
                                dealheader dh = (dealheader)x.QtO("dealheader", "select * from dealheader where unique_id = '" + rfq.base_dealheader_uid + "'");
                                ordernumber = dh.dealheader_name;
                                //ordernumber = x.SelectScalarString("select dealheader_name from dealheader where unique_id = '" + rfq.base_dealheader_uid + "'");
                                quantity = rfq.quantity.ToString();
                                customerName = dh.customer_name;
                                break;
                            }

                        case "Rz5.orddet_quote":
                            {
                                orddet_quote quote = (orddet_quote)o;
                                dealheader dh = (dealheader)x.QtO("dealheader", "select * from dealheader where unique_id = '" + quote.base_dealheader_uid + "'");
                                ordertype = "formal quote";
                                ordernumber = quote.ordernumber;
                                quantity = quote.quantityordered.ToString();
                                customerName = dh.customer_name;
                                break;
                            }

                        case "Rz5.orddet_line":
                            {
                                orddet_line line = (orddet_line)o;
                                customerName = line.customer_name;
                                if (!string.IsNullOrEmpty(line.orderid_invoice))
                                {
                                    ordertype = "invoice";
                                    ordernumber = line.ordernumber_invoice;
                                    quantity = line.quantity_packed.ToString();

                                }
                                else
                                {
                                    ordertype = "sales order";
                                    ordernumber = line.ordernumber_sales;
                                    quantity = line.quantity.ToString();
                                }

                                break;
                            }
                        default:
                            {
                                ordertype = "<not set>";
                                ordernumber = "<not set>";
                                break;
                            }


                    }

                    string text = "One of " + overBuyOwner.Name + "'s overbuy parts (" + p.fullpartnumber + ", QTY:" + quantity + ") has been added to " + ordertype + "# " + ordernumber + " (" + customerName + "). Originating PO#: " + poID;

                    //Send email
                    nEmailMessage m = new nEmailMessage();
                    m.FromAddress = "alert@sensiblemicro.com";
                    m.SetToAndExtras(toAddresses);
                    m.Subject = "Overbuy Activity Notification";
                    m.ServerName = "smtp.sensiblemicro.local";
                    m.TextBody = text;
                    m.Send();
                }
            }
            catch (Exception ex)
            {
                x.Leader.Tell("Overbuy alert failed." + ex.Message);
            }

        }






        //Attempt to match a manufacturer to the most accurate, via various sources including API and Databases
        public string GetMfgMatches(ContextRz x, string searchPart, bool allowManualPick = false, bool autoAddToMfgChoiceList = false)
        {
            string matchedMfg = "";

            //Get a List if Silicon ExpertMatchResults     
            bool doSiliconExpert = SiliconExpertLogic.IsEnabled();
            if (!doSiliconExpert)
            {
                return "";
            }

            matchedMfg = GetMfgMatchFromSiliconExpert(x, searchPart);

            //Choose from Existing
            if (string.IsNullOrEmpty(matchedMfg))
            {
                if (!allowManualPick)
                    return null;
                //Add valid MFG to list.  Allow Manual will convert the search string to the choices list   
                matchedMfg = x.Leader.ChooseManufacturer(x, searchPart, autoAddToMfgChoiceList);
            }

            //bool to carry added choice results.
            bool choiceSaved = false;
            if (string.IsNullOrEmpty(matchedMfg))
            {

                x.Leader.Tell("No Matches found for " + searchPart);
                matchedMfg = "OTHER";
            }
            else
            {
                // If by now we have a match, send to choice add routing            
                choiceSaved = AddMfgToChoiceList(x, matchedMfg, autoAddToMfgChoiceList);
                //Build report
                string report = "No manufacturer match found for " + searchPart;
                if (!string.IsNullOrEmpty(matchedMfg))
                    report = "Matched " + searchPart + " to MFG: " + matchedMfg;
                //Send notification                
                //SystemLogic.Email.SendMail("silicon_match@sensiblemicro.com", "ktill@sensiblemicro.com", "Silicon Expert MFG Match Report", report);
                SystemLogic.Logs.LogEvent(SM_Enums.LogType.Information, report, true, "Rz");
            }

            //Return value
            return matchedMfg;
        }


        private string GetMfgMatchFromSiliconExpert(ContextRz x, string searchPart)
        {
            List<SiliconExpertLogic.SiliconExpertMfgMatch> seMatchList = SiliconExpertLogic.GetSiliconMfgMatchList(searchPart);

            //First, as user to select from Silicon Expert, if available
            string ret = "";
            if (seMatchList.Count > 0)
                ret = x.Leader.ChooseOneChoice(x, seMatchList.Select(s => s.matchedMfg).Distinct().ToList(), "Silicon Expert MFG for " + searchPart);
            return ret;
        }


        private bool AddMfgToChoiceList(ContextRz x, string matchedMfg, bool autoAddChoice = true)
        {
            //Get Current List
            List<string> currentMfgChoiceList = n_choices.ChoiceListGet(x, "manufacturer");
            //IF Already on list, all good.
            if (currentMfgChoiceList.Contains(matchedMfg))
                return false;

            //Check if should auto-add
            bool autoAddchoice = autoAddChoice;
            //IF not autoadd, ask user
            if (autoAddchoice == false)
                autoAddchoice = x.Leader.AreYouSure("Would you like to add " + matchedMfg + "  to the list of choices?");//If not on List, offer to save
            if (autoAddchoice)
            {
                //Create new Choice
                n_choices.ChoiceMakeExist(x, "manufacturer", matchedMfg);
                n_choices.CacheChoiceList(x, "manufacturer");
                return true;
            }
            return false;

        }
        public void LoadManufacturerDropDown(ContextRz x, nEdit_List ctl_target_manufacturer)
        {
            ctl_target_manufacturer.GetCombo().Items.Clear();
            ctl_target_manufacturer.GetCombo().AutoCompleteSource = AutoCompleteSource.ListItems;
            ctl_target_manufacturer.GetCombo().AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            List<string> mfgsList = n_choices.ChoiceListGet(x, "manufacturer");
            mfgsList.Sort();
            if (!mfgsList.Contains("OTHER"))
                mfgsList.Insert(0, "OTHER");
            if (!mfgsList.Contains("N/A"))
                mfgsList.Insert(1, "N/A");
            ctl_target_manufacturer.LoadListString(mfgsList);

        }
        public string GetManufacturerMatchString(ContextRz x, string matchPart)
        {
            //Ask user to confirm adding MFG            
            string matchMfg = GetMfgMatches(x, matchPart, true).Trim().ToUpper();
            return matchMfg;

        }


        //public void AlertMissingMfg(ContextRz x, string partNumber, string label)
        //{
        //    Tools.nEmailMessage msg = new nEmailMessage();
        //    msg.ToAddress = "ktill@sensiblemicro.com";
        //    msg.FromAddress = "rz@sensiblemicro.com";
        //    msg.CcRecipients.Add("joemar@sensiblemicro.com");
        //    msg.Subject = "Missing Manufacturer";
        //    msg.HTMLBody = partNumber + " is missing a manufacturer. (" + label + ")";
        //    msg.FromName = "Rz System Alerts";
        //    msg.Send();
        //}

        private void PrintWarehouseLabel(ContextRz x, List<partrecord> l)
        {
            try
            {
                ArrayList colObjects = new ArrayList();
                Boolean bBarcode = true;
                if (l.Count > 1)
                {
                    if (!x.TheLeader.AskYesNo("You are printing more than one label. Would you like the quantity editor to pop-up? This will occur for each inventory items you selected."))
                    {
                        foreach (partrecord p in l)
                        {
                            string po = "";
                            if (Tools.Strings.StrExt(p.buy_purchase_id))
                                po = x.SelectScalarString("select ordernumber from ordhed_purchase where unique_id = '" + p.buy_purchase_id + "'");
                            //p.resistortype = po;
                            p.activemarketing = po;
                            colObjects = new ArrayList();
                            colObjects.Add(p);
                            colObjects.Add(x.xUser);
                            Tools.Dymo.PrintDymoLabel(x, "stock", colObjects, null, bBarcode);
                        }
                        return;
                    }
                }
                foreach (partrecord p in l)
                {
                    orddet_line line = new orddet_line();
                    line.fullpartnumber = p.fullpartnumber;
                    line.manufacturer = p.manufacturer;
                    line.datecode = p.datecode;
                    line.quantity = Convert.ToInt32(p.quantity);
                    ArrayList a = ((ILeaderRz)x.Leader).EnterLabelLines(line);  // frmLabelLines.EnterLines(line);
                    if (a == null)
                        continue;
                    if (a.Count == 0)
                        continue;
                    foreach (String s in a)
                    {
                        String strq = Tools.Strings.ParseDelimit(s, ":", 1).Trim();
                        String strdc = Tools.Strings.ParseDelimit(s, ":", 2).Trim();
                        String strser = "";
                        String strex = "";
                        if (Tools.Strings.CharCount(s, ':') > 1)
                            strser = Tools.Strings.ParseDelimit(s, ":", 3).Trim();
                        if (Tools.Strings.CharCount(s, ':') > 2)
                            strex = Tools.Strings.ParseDelimit(s, ":", 4).Trim();
                        if (Tools.Number.IsNumeric(strq))
                        {
                            partrecord pp = (partrecord)p.CloneValues(x);
                            pp.unique_id = "<none>";
                            pp.quantity = Int32.Parse(strq);
                            pp.datecode = strdc;
                            string po = "";
                            if (Tools.Strings.StrExt(pp.buy_purchase_id))
                                po = x.SelectScalarString("select ordernumber from ordhed_purchase where unique_id = '" + pp.buy_purchase_id + "'");
                            //pp.resistortype = po;
                            pp.activemarketing = po;
                            colObjects = new ArrayList();
                            colObjects.Add(pp);
                            colObjects.Add(x.xUser);
                            Tools.Dymo.PrintDymoLabel(x, "stock", colObjects, null, bBarcode);
                        }
                    }
                }
            }
            catch { }
        }





        protected virtual void ActsListParts(Context context, ActSetup mnu)
        {
            ContextRz xrz = (ContextRz)context;

            if (mnu is ActSetupParts && ((ContextNM)context).xUser.SuperUser)
            {
                ActSetupParts msp = (ActSetupParts)mnu;
                if (msp.Shipped)
                {
                    mnu.Clear();
                    if (((ContextRz)context).xUser.SuperUser)
                        mnu.Add("Un-Ship");
                    mnu.Close();
                    return;
                }
            }
            mnu.Add("Give Quote");
            mnu.Add("Receive Bid");
            mnu.Add("Scan C of C");
            mnu.Add("Email Vendor");
            ActListLabels(context, mnu);
            if (xrz.CheckPermit("Stock:Manage:Split"))
                mnu.Add("Split");
            string strExtra = "";
            foreach (IItem o in mnu.TheItems.AllGet(context))
            {
                if (!(o is partrecord))
                    continue;
                partrecord p = (partrecord)o;
                strExtra = p.stocktype;
                break;
            }
            switch (strExtra.ToLower().Trim())
            {
                case "stock":
                    if (CanSetStock((ContextNM)context))
                    {
                        mnu.Add("Set Consign");
                        mnu.Add("Set Buy");
                    }
                    mnu.Add("View Purchase");
                    mnu.Add("View Sale");
                    mnu.Add("Send For Service");
                    break;
                case "consign":
                case "consigned":
                    if (CanSetStock((ContextNM)context))
                    {
                        mnu.Add("Set Stock");
                        mnu.Add("Set Buy");
                    }
                    mnu.Add("Send For Service");
                    break;
                case "oem":
                case "excess":
                case "archive":
                    if (CanSetStock((ContextNM)context))
                    {
                        mnu.Add("Set Stock");
                        mnu.Add("Set Buy");
                    }
                    mnu.Add("RFQ");
                    break;
                case "buy":
                    if (CanSetStock((ContextNM)context))
                    {
                        mnu.Add("Set Stock");
                        mnu.Add("Set Consign");
                    }
                    mnu.Add("View Purchase");
                    mnu.Add("View Sale");
                    mnu.Add("Send For Service");
                    break;
            }
        }
        public virtual String AllocatedCountSql(ContextRz context, String part)
        {
            return "select sum(quantity) from orddet_line where " + AllocatedSqlWhere(context, part);
        }

        public virtual String AllocatedSqlWhere(ContextRz context, String part)
        {
            return "part_number_stripped like '" + context.Filter(part) + "%' and isnull(orderid_sales, '') > '' and status in ('Open', 'Packing', 'Packed')";
        }

        public virtual PartSearchParameters PartSearchParametersDefaultGet(ContextRz x)
        {
            PartSearchParameters ret = new PartSearchParameters("");
            return ret;
        }

        public virtual bool UnShipViaSql(ContextRz context, string sql)
        {
            DataTable shipped = context.Select(sql);
            if (!Tools.Data.DataTableExists(shipped))
            {
                context.TheLeader.Tell("The shipped record for this scan could not be found");
                return false;
            }

            foreach (DataRow r in shipped.Rows)
            {
                partrecord sx = partrecord.New(context);
                sx.AbsorbRow(context, r);
                sx.UnShip(context, false);
                context.TheLeader.Comment("Un-Shipped " + sx.ToString());
            }
            return true;
        }

        protected virtual void ActsListAddInventory(Context x, ActHandle h)
        {
            h.SubActs.Add(new ActHandle(new Act("New Stock Part", new ActHandler(PartCreateStock))));
            h.SubActs.Add(new ActHandle(new Act("New Consigned Part", new ActHandler(PartCreateConsign))));
            h.SubActs.Add(new ActHandle(new Act("New Excess Part", new ActHandler(PartCreateExcess))));
            //KT - Add "New Master Part"
            h.SubActs.Add(new ActHandle(new Act("New Master Part", new ActHandler(PartCreateMaster))));
        }

        public void PartSearchShow(ContextRz x)
        {
            PartSearchShow(x, new ActArgs());
        }

        public void PartSearchShow(Context x, ActArgs args)
        {
            if (!((ContextRz)x).CheckPermit("Inventory:Search:Search Parts"))
            {
                x.TheLeader.ShowNoRight();
                args.Result(false);
                return;
            }
            ((ContextRz)x).TheLeaderRz.PartSearchShow((ContextRz)x, args);
        }

        public void PartCreateStock(Context x, ActArgs args)
        {
            args.Result(ShowNewPart((ContextRz)x, Enums.StockType.Stock) != null);
        }

        public void PartCreateConsign(Context x, ActArgs args)
        {
            args.Result(ShowNewPart((ContextRz)x, Enums.StockType.Consign) != null);
        }

        public void PartCreateExcess(Context x, ActArgs args)
        {
            args.Result(ShowNewPart((ContextRz)x, Enums.StockType.Excess) != null);
        }

        public void PartCreateMaster(Context x, ActArgs args)
        {
            args.Result(ShowNewPart((ContextRz)x, Enums.StockType.Master) != null);
        }

        public void MultiSearchShow(Context x)
        {
            MultiSearchShow(x, new ActArgs());
        }

        public void MultiSearchShow(Context x, ActArgs args)
        {
            MultiSearchShow((ContextRz)x, "");
            args.Result(true);
        }

        public void MultiSearchShow(ContextRz x, String partNumber)
        {
            x.Leader.MultiSearchShow(x, partNumber);
            //x.Reorg();
            //RzApp.xMainForm.ShowMultiSearch(partNumber);
        }

        public void OemProductShow(Context x, ActArgs args)
        {
            OemProductShow((ContextRz)x);
            args.Result(true);
        }

        public void OemProductShow(ContextRz x)
        {
            x.Leader.OEMProductsShow(x);

        }

        public virtual partrecord ShowNewPart(ContextRz context, Enums.StockType type)
        {
            if (!context.xUser.CheckPermit(context, "Stock:Create:Create" + type.ToString()))
            {
                context.TheLeader.ShowNoRight();
                return null;
            }
            partrecord p = AddNewPartRecord(context, type);
            //KT Don't need initial quantity for master parts
            if (type != Enums.StockType.Master)
            {

                long q = 0;
                if (!context.xUser.CheckPermit(context, "Inventory:Edit:Can Edit Part Quantity"))
                {
                    bool cancelled = false;
                    q = context.TheLeader.AskForInt32("New item quantity", 0, "Quantity", ref cancelled);
                    if (cancelled)
                        return null;
                }
                p.quantity = q;
            }


            context.Show(p);
            return p;
        }

        public virtual partrecord AddNewPartRecord(ContextNM x, Enums.StockType type)
        {
            partrecord p = partrecord.New(x);
            p.StockType = type;
            x.Insert(p);
            return p;
        }

        public ListArgsParts ShippedSearchArgsGet(ContextRz x, Rz5.PartSearchParameters pars)
        {
            ListArgsParts ret = PartSearchArgsGet(x, pars);
            ret.Shipped = true;
            ret.TheTable = "shipped_stock";
            ret.TheTemplate = "Shipped Search";
            ret.TheCaption = "Shipped Inventory";
            return ret;
        }

        public ListArgs MasterSearchArgsGet(ContextRz x, Rz5.PartSearchParameters pars)
        {
            ListArgs ret = new ListArgs(x);
            ret.TheTable = "part_master";
            ret.TheClass = "part_master";
            //KT - added the leading '%' wildcard
            ret.TheWhere = "part_number_stripped like '%" + Tools.Strings.FilterTrash(pars.SearchTerm) + "%'";
            ret.TheOrder = "part_number";
            ret.TheTemplate = "part_master_template";
            ret.TheCaption = "Item Master";
            ret.AddAllow = false;
            return ret;
        }

        public ListArgs OffersSearchArgsGet(ContextRz x, Rz5.PartSearchParameters pars)
        {
            ListArgs ret = new ListArgs(x);
            ret.TheTable = "partrecord";
            ret.TheClass = "partrecord";
            //KT - added the leading '%' wildcard
            ret.TheWhere = "part_number_stripped like '%" + Tools.Strings.FilterTrash(pars.SearchTerm) + "%'";
            ret.TheOrder = "fullpartnumber";
            ret.TheTemplate = "part_master_template";
            ret.TheCaption = "Item Master";
            ret.AddAllow = false;
            return ret;
        }

        //removed 2013_03_25
        //public virtual String GetPartSearchTable(ContextRz context)
        //{
        //    String table = "partrecord";
        //    if (context.Logic.IsPhoenixEMEA)
        //        table = "Rz.dbo.partrecord";
        //    else
        //        table = "Rz_EMEA.dbo.partrecord";
        //    return table;
        //}

        bool checkedSuppressPartSearchOrder = false;
        bool suppressPartSearchOrder = false;
        public virtual bool SuppressPartSearchOrder(ContextRz context)
        {
            if (!checkedSuppressPartSearchOrder)
            {
                suppressPartSearchOrder = context.GetSettingBoolean("suppress_part_search_order");
                checkedSuppressPartSearchOrder = true;
            }
            return suppressPartSearchOrder;
        }

        public virtual ListArgsParts PartSearchArgsGet(ContextRz x, PartSearchParameters pars)
        {
            ListArgsParts ret = new ListArgsParts(x);
            ret.TheContext = x;
            ret.OptionsAllow = true;
            ret.AddAllow = false;
            ret.TheClass = "partrecord";
            ret.TheTemplate = "PARTSEARCH";
            ret.TheCaption = "Stock, Consignments, Excess and Master";
            if (pars.SearchTerm == "")
                ret.HeaderOnly = true;
            ret.TheTable = "partrecord";
            //KT - Allow all Alternates search
            //pars.IncludeAllAlternates = true;

            if (SuppressPartSearchOrder(x))
            {
                pars.IncludeUserDefined = false;
                pars.IncludeAlternatePart = false;
                pars.IncludeAllAlternates = false;
                ret.TheOrder = "";
            }
            else
                ret.TheOrder = "fullpartnumber";

            StringBuilder sb = new StringBuilder();

            if (pars.IncludeAllocated && pars.IncludeStock && pars.IncludeConsign && pars.IncludeExcess && pars.IncludeMaster)
            {
                //nothing
            }
            else
            {
                String i = "";
                if (pars.IncludeAllocated)
                {
                    if (Tools.Strings.StrExt(i))
                        i = i + ", ";
                    i = i + "'buy'";
                }

                if (pars.IncludeStock)
                {
                    if (Tools.Strings.StrExt(i))
                        i = i + ", ";
                    i = i + "'stock'";
                }
                if (pars.IncludeConsign)
                {
                    if (Tools.Strings.StrExt(i))
                        i = i + ", ";
                    i = i + "'consign', 'consigned'";
                }
                if (pars.IncludeExcess)
                {
                    if (Tools.Strings.StrExt(i))
                        i = i + ", ";
                    i = i + "'excess', 'oem'";
                }
                //KT Include Master
                if (pars.IncludeMaster)
                {
                    if (Tools.Strings.StrExt(i))
                        i = i + ", ";
                    i = i + "'Master'";
                }

                if (pars.IncludeOffers)
                {
                    if (Tools.Strings.StrExt(i))
                        i = i + ", ";
                    i = i + "'Offers'";
                }

                if (Tools.Strings.StrExt(i))
                    sb.AppendLine(" stocktype in (" + i + ")");
            }

            if (!pars.IncludeZeroQuantity)
            {
                if (sb.ToString() != "")
                    sb.Append(" and ");
                sb.AppendLine(" quantity > 0 ");
            }

            switch (pars.TheTarget)
            {
                case PartSearchTarget.Manufacturer:
                    SearchAppendManufacturer(x, sb, pars, Core.BinaryOperatorType.And);
                    break;
                case PartSearchTarget.Description:
                    SearchAppendDescription(x, sb, pars, Core.BinaryOperatorType.And);
                    break;
                case PartSearchTarget.BoxNum:
                    SearchAppendBoxNum(x, sb, pars, Core.BinaryOperatorType.And);
                    break;
                case PartSearchTarget.All:

                    StringBuilder sbx = new StringBuilder();
                    SearchAppendPart(x, sbx, pars, Core.BinaryOperatorType.Or);
                    SearchAppendManufacturer(x, sbx, pars, Core.BinaryOperatorType.Or);
                    SearchAppendDescription(x, sbx, pars, Core.BinaryOperatorType.Or);
                    SearchAppendSerial(x, sbx, pars, Core.BinaryOperatorType.Or);

                    if (sb.ToString() != "")
                        sb.Append(" and ");
                    sb.Append(" ( ");
                    sb.Append(sbx.ToString());
                    sb.Append(" ) ");

                    break;
                default:

                    StringBuilder sbx2 = new StringBuilder();
                    SearchAppendPart(x, sbx2, pars, Core.BinaryOperatorType.Or);
                    //SearchAppendSerial(x, sbx2, pars, Core.BinaryOperatorType.Or);

                    if (sb.ToString() != "")
                        sb.Append(" and ");
                    sb.Append(" ( ");
                    sb.Append(sbx2.ToString());
                    sb.Append(" ) ");

                    break;
            }
            AddSearchSQLStock(pars, sb);
            if (!pars.UnlimitedResults)
                ret.TheLimit = 500;
            ret.TheWhere = sb.ToString();
            //KT Refactored from RzSensible 4-29-2015
            //if (Tools.Strings.StrExt(pars.CompanyName))
            //    ret.TheWhere += " and companyname = '" + x.Filter(pars.CompanyName) + "'";
            if (Tools.Strings.StrExt(pars.CompanyID))
                ret.TheWhere += " and base_company_uid = '" + x.Filter(pars.CompanyID) + "'";
            return ret;
        }


        public Stack GetRecentSearchStack(ContextRz x)
        {
            Stack PartNumbers = new Stack();
            ArrayList a = x.SelectScalarArray("select top 30 fullpartnumber + ' <> ' + cast(searchdate as varchar(255)) from partsearch where base_mc_user_uid = '" + x.xUser.unique_id + "' order by searchdate desc");
            for (int i = a.Count - 1; i >= 0; i--)
            {
                PartNumbers.Push(a[i]);
            }
            return PartNumbers;
        }

        public virtual void AddSearchSQLStock(PartSearchParameters pars, StringBuilder sb)
        {
        }

        protected virtual void SearchAppendPart(ContextRz context, StringBuilder sb, PartSearchParameters pars, BinaryOperatorType op)
        {
            ArrayList a = PartObject.GetSearchPermutations(context, pars);
            if (a.Count > 0)
            {
                if (sb.ToString() != "")
                    sb.Append(" " + op.ToString().ToLower() + " ");

                sb.AppendLine(" ( ");
                sb.Append(PartObject.BuildWhere(a));
                sb.AppendLine(" ) ");
            }
        }

        protected virtual void SearchAppendManufacturer(ContextNM x, StringBuilder sb, PartSearchParameters pars, BinaryOperatorType op)
        {
            if (sb.ToString() != "")
                sb.Append(" " + op.ToString().ToLower() + " ");
            sb.Append(" manufacturer like '%" + x.Filter(pars.SearchTerm) + "%' ");
        }

        void SearchAppendDescription(ContextNM x, StringBuilder sb, PartSearchParameters pars, BinaryOperatorType op)
        {
            if (sb.ToString() != "")
                sb.Append(" " + op.ToString().ToLower() + " ");
            sb.Append(DescriptionWhereCalc(x, pars));
        }

        void SearchAppendSerial(ContextNM x, StringBuilder sb, PartSearchParameters pars, BinaryOperatorType op)
        {
            if (sb.ToString() != "")
                sb.Append(" " + op.ToString().ToLower() + " ");
            sb.Append(" serial like '%" + x.Filter(pars.SearchTerm) + "%' ");
        }

        protected virtual void SearchAppendBoxNum(ContextNM x, StringBuilder sb, PartSearchParameters pars, BinaryOperatorType op)
        {
            if (sb.ToString() != "")
                sb.Append(" " + op.ToString().ToLower() + " ");

            if (pars.TheComparison == SearchComparison.Fuzzy)
                sb.Append(" boxnum like '%" + x.Filter(pars.SearchTerm) + "%' ");
            else if (pars.TheComparison == SearchComparison.Exact)
                sb.Append(" boxnum = '" + x.Filter(pars.SearchTerm) + "' ");
            else
                sb.Append(" boxnum like '" + x.Filter(pars.SearchTerm) + "%' ");
        }

        protected virtual String DescriptionWhereCalc(ContextNM x, PartSearchParameters pars)
        {
            return " description like '%" + x.Filter(pars.SearchTerm) + "%' ";
        }

        public long TotalStockCount(ContextRz context)
        {

            return context.SelectScalarInt64("select sum(quantity) from partrecord where stocktype = 'Stock'");
        }

        public virtual Rz5.StockEvaluatorCore GetStockEvaluatorCore()
        {
            return new Rz5.StockEvaluatorCore();
        }






    }

    public class ListArgsParts : ListArgs
    {
        public bool Shipped = false;

        public ListArgsParts(ContextNM context)
            : this(context, false)
        {
        }

        public ListArgsParts(ContextNM context, bool shipped)
            : base(context)
        {
            Shipped = shipped;
        }

        public override ActSetup ActSetupCreate()
        {
            return new ActSetupParts(Shipped);
        }
    }

    public class PartSearchShowArgs : ActArgs
    {
        public string PartNumber = "";
        public bool UseExisting = true;
        public bool RunSearch = false;
        public string CompanyId = "";
        public string ContactId = "";
        public Enums.PartSearchType SearchType = Enums.PartSearchType.None;

        public PartSearchShowArgs()
        {
        }

        public PartSearchShowArgs(String partNumber)
            : this(partNumber, false)
        {

        }
        public PartSearchShowArgs(String partNumber, bool runSearch)
        {
            PartNumber = partNumber;
            RunSearch = runSearch;
        }
    }

    namespace Enums
    {
        public enum PartSearchType
        {
            None = 0,
            Stock = 1,
            Avail = 2,
            Avail_Archive = 3,
            Reqs = 4,
            Quotes_All = 5,
            Quotes_Giving = 6,
            Quotes_Receiving = 7,
            Quotes_Formal = 8,
            Sales = 9,
            Buys = 10,
            Hit = 11,
            Allocated = 12,
            Bids = 13,
            Quotes_Merged = 14,
            RMA = 15,
            VendRMA = 16,
            WebParts = 17,
            Attachments = 18,
        }
    }



    public class ActSetupParts : ActSetup
    {
        public bool Shipped = false;

        public ActSetupParts(bool shipped)
        {
            Shipped = shipped;
        }
    }
}
