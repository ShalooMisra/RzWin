using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;

using Tools;
using Core;
using NewMethod;
using Tools.Database;

namespace Rz5
{
    public partial class company : company_auto, IAssignedAgent
    {
        public VarRefContacts ContactsVar;
        public override List<Var> VarsGetInitially()
        {
            List<Var> ret = base.VarsGetInitially();
            ret.Add(ContactsVar);
            return ret;
        }

        public override Var VarGetByName(string name)
        {
            switch (name)
            {
                case "Contacts":
                    return ContactsVar;
                default:
                    return base.VarGetByName(name);
            }
        }

        //Constructor
        public company()
        {
            ContactsVar = new VarRefContacts(this, new CoreVarRefManyAttribute("Contacts", "Rz4.company", "Rz4.companycontact", "TheCompany", "base_company_uid"));

        }

        //Private Functions
        private void UpdateCompanyCountry()
        {
            Tools.CompanyCountry c = Tools.People.GetCompanyCountryEnum(country, primaryemailaddress, primaryphone);
            int i = 0;
            switch (c)
            {
                case Tools.CompanyCountry.Europe:
                    i = 6;
                    break;
                case Tools.CompanyCountry.China:
                    i = 5;
                    break;
                default:
                    i = 7;
                    break;
            }
            icon_index = i;
        }
        private void UpdateCompanyColor()
        {
            grid_color = System.Drawing.Color.Blue.ToArgb();
            TimeSpan ts = DateTime.Now.Subtract(lastcontactdate);
            if (Tools.Strings.StrCmp(company_criteria, "9"))
                grid_color = System.Drawing.Color.Black.ToArgb();
            else if (Tools.Strings.StrCmp(company_criteria, "1"))
            {
                if (ts.Days > 7)
                    grid_color = System.Drawing.Color.Red.ToArgb();
            }
            else if (Tools.Strings.StrCmp(company_criteria, "2"))
            {
                if (ts.Days > 14)
                    grid_color = System.Drawing.Color.Red.ToArgb();
            }
            else if (Tools.Strings.StrCmp(company_criteria, "3"))
            {
                if (ts.Days > 30)
                    grid_color = System.Drawing.Color.Red.ToArgb();
            }
        }
        public void CalcReceivingPercent(ContextRz context)
        {
            int total = 0;
            int count = 0;

            ArrayList a = context.SelectScalarArray("select top 10 qualitycontrol from ordhed_purchase where isnull(qualitycontrol, '') > '' and base_company_uid = '" + this.unique_id + "' order by orderdate desc");

            foreach (String s in a)
            {
                try
                {
                    int num = Int32.Parse(s.Replace("%", "").Trim());
                    count++;
                    total += num;
                }
                catch { }
            }

            Double avg = 0;

            if (count > 0)
                avg = total / count;
            else
                avg = 100;

            this.bell_ringers = Convert.ToInt64(avg);


            //chkApprovedVendor.Checked = Tools.Strings.HasString(CurrentCompany.divisionof, ",AV,");
            //chkProbation.Checked = Tools.Strings.HasString(CurrentCompany.divisionof, ",PR,");
            //chkDisapproved.Checked = Tools.Strings.HasString(CurrentCompany.divisionof, ",DA,");

            //71% and above = Approved
            //50% and 70% = Probation
            //Below 50% = Disapproved

            if (this.bell_ringers < 50)
                this.divisionof = ",DA,";
            else if (this.bell_ringers < 71)
                this.divisionof = ",PR,";
            else
                this.divisionof = ",AV,";
        }
        public static void MakeExist(ContextRz q, String name, String contact, String email)
        {
            company c = (company)company.GetByName(q, name);
            //if (c != null && !q.xUser.SuperUser)
            //{
            //    if (!Tools.Strings.StrCmp(c.base_mc_user_uid, q.xUser.unique_id))
            //        c = null;
            //}

            if (c == null)
            {
                c = company.New(q);
                c.companyname = name;
                c.UserObjectSet((n_user)q.xUser);
            }

            if (!Tools.Strings.StrExt(c.primarycontact))
                c.primarycontact = contact;

            if (!Tools.Strings.StrExt(c.primaryemailaddress))
                c.primaryemailaddress = email;

            q.Insert(c);
        }
        public static void CalcStats(ContextNM context)
        {
            context.TheLeader.Comment("Calculating reqs...");
            context.Execute("update company set calc_reqs = (select count(*) from req where req.base_company_uid = company.unique_id)");


            context.TheLeader.Comment("Calculating bids...");
            context.Execute("update company set calc_bids = (select count(*) from quote where quotetype = 'receiving' and base_company_uid = company.unique_id)");


            context.TheLeader.Comment("Calculating quick quotes...");
            context.Execute("update company set calc_qquotes = (select count(*) from quote where quotetype = 'giving out' and base_company_uid = company.unique_id)");


            context.TheLeader.Comment("Calculating formal quotes...");
            context.Execute("update company set calc_fquotes = (select count(*) from orddet_quote inner join ordhed_quote on ordhed_quote.unique_id = orddet_quote.base_ordhed_uid where isnull(ordhed_quote.isvoid, 0) = 0 and ordhed_quote.base_company_uid = company.unique_id)");


            context.TheLeader.Comment("Calculating sales...");
            context.Execute("update company set calc_sales = (select count(*) from orddet_line inner join ordhed_invoice on ordhed_invoice.unique_id = orddet_line.orderid_invoice where isnull(ordhed_invoice.isvoid, 0) = 0 and ordhed_invoice.base_company_uid = company.unique_id)");


            context.TheLeader.Comment("Calculating purchases...");
            context.Execute("update company set calc_purchases = (select count(*) from orddet_line inner join ordhed_purchase on ordhed_purchase.unique_id = orddet_line.orderid_purchase where isnull(ordhed_purchase.isvoid, 0) = 0 and ordhed_purchase.base_company_uid = company.unique_id)");


            context.TheLeader.Comment("Calculating bids from reqs...");
            context.Execute("update company set bids_from_reqs = (select count(*) from quote where quotetype = 'receiving' and ( reqid in (select unique_id from req where req.base_company_uid = company.unique_id) or sessionid in (select unique_id from req where req.base_company_uid = company.unique_id) ))");


            context.TheLeader.Comment("Calculating potential sales...");
            context.Execute("update company set bell_ringers = (select count(*) from orddet_quote where target_price > 0 and unitcost > 0 and unitcost <= (target_price * 0.9) and orddet_quote.base_company_uid = company.unique_id)");

            context.TheLeader.Comment("Calculating total sales...");
            context.Execute("update company set total_sales_amount = (select sum(ordertotal) from ordhed_invoice where isnull(isvoid, 0) = 0 and base_company_uid = company.unique_id)");


            context.TheLeader.Comment("Calculating calls...");
            context.Execute("update company set calc_calls = (select count(*) from calllog where base_company_uid = company.unique_id)");


            context.TheLeader.Comment("Calculating notes...");
            context.Execute("update company set calc_notes = (select count(*) from contactnote where base_company_uid = company.unique_id)");


            context.TheLeader.Comment("Calculating last req...");
            context.Execute("update company set last_req_date = (select max(date_created) from orddet_quote where orddet_quote.base_company_uid = company.unique_id)");


            context.TheLeader.Comment("Calculating last sale...");
            context.Execute("update company set last_sale_date = (select max(orderdate) from " + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + " where " + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + ".ordertype = 'invoice' and " + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + ".base_company_uid = company.unique_id)");


            context.TheLeader.Comment("Calculating last call...");
            context.Execute("update company set last_call_date = (select max(datecall) from calllog where calllog.base_company_uid = company.unique_id)");


            context.TheLeader.Comment("Calculating last call result...");
            context.Execute("update company set last_call_result = (select top 1 left(callresult, 255) from calllog where calllog.base_company_uid = company.unique_id order by datecall desc)");


            context.TheLeader.Comment("Calculating last call notes...");
            context.Execute("update company set last_call_notes = (select top 1 left(callnotes, 255) from calllog where calllog.base_company_uid = company.unique_id order by datecall desc)");
        }
        public companyaddress QB_BillingAddress = null;
        public companyaddress QB_ShippingAddress = null;

        //ViewCompany Args
        public virtual ListArgs ContactArgsGet(ContextNM x)
        {
            ListArgs ret = new ListArgs(x);
            ret.TheCaption = "Contacts";
            ret.TheTable = "companycontact";
            ret.TheClass = "companycontact";
            ret.TheWhere = "base_company_uid = '" + unique_id + "'";
            ret.TheTemplate = "CONTACTS";
            ret.TheOrder = "contactname";
            ret.AddAllow = true;
            ret.AddCaption = "Add A New Contact";
            ret.AddQueryStrings.Add("target=item&id=" + this.unique_id + "&class=company&action=newcontact");
            return ret;
        }
        public List<companyaddress> AddressesGet(ContextNM x)
        {
            ListArgs args = AddressArgsGet(x);
            ArrayList addresses = x.List(args);
            List<companyaddress> ret = new List<companyaddress>();
            foreach (companyaddress a in addresses)
            {
                ret.Add(a);
            }
            return ret;
        }
        public ListArgs AddressArgsGet(ContextNM x)
        {
            ListArgs ret = new ListArgs(x);
            ret.TheCaption = "Billing And Shipping Addresses";
            ret.TheTable = "companyaddress";
            ret.TheClass = "companyaddress";
            ret.TheWhere = "base_company_uid = '" + unique_id + "'";
            ret.TheTemplate = "COMPANYADDRESSES";
            ret.TheOrder = "description";
            ret.AddAllow = true;
            ret.AddCaption = "Add A New Address";
            ret.AddQueryStrings.Add("target=item&id=" + this.unique_id + "&class=company&action=newaddress");
            return ret;
        }
        public ListArgs AccountArgsGet(ContextNM x)
        {
            ListArgs ret = new ListArgs(x);
            ret.TheCaption = "Shipping Accounts";
            ret.TheTable = "shippingaccount";
            ret.TheClass = "shippingaccount";
            ret.TheWhere = "base_company_uid = '" + unique_id + "'";
            ret.TheTemplate = "SHIPPINGACCOUNTS";
            ret.TheOrder = "description";
            ret.AddAllow = true;
            ret.AddCaption = "Add A New Account";
            ret.AddQueryStrings.Add("target=item&id=" + this.unique_id + "&class=company&action=newshippingaccount");
            return ret;
        }
        public ListArgs BidArgsGet(ContextNM x)
        {
            ListArgs ret = new ListArgs(x);
            ret.AddAllow = false;
            string template = "";
            string classname = "";
            string where = "";
            string order = "";
            if (((RzLogic)x.TheLogic).UseMergedQuotes)
            {
                template = "COMPANYQUOTES1";
                classname = "orddet_rfq";
                where = " base_company_uid = '" + unique_id + "'";
                order = "orderdate desc";
            }
            else
            {
                template = "COMPANYQUOTES";
                classname = "quote";
                where = "quotetype = 'receiving' and base_company_uid = '" + unique_id + "'";
                order = "quotedate desc";
            }
            ret.TheTable = classname;
            ret.TheClass = classname;
            ret.TheWhere = where;
            ret.TheTemplate = template;
            ret.TheOrder = order;
            return ret;
        }
        public ListArgs CallArgsGet(ContextNM x)
        {
            ListArgs ret = new ListArgs(x);
            ret.TheTable = "calllog";
            ret.TheClass = "calllog";
            ret.TheWhere = "base_company_uid = '" + unique_id + "'";
            ret.TheTemplate = "calllog";
            ret.TheOrder = "DATECALL DESC";
            ret.AddAllow = true;
            ret.AddCaption = "Add A New Call Log";
            ret.AddQueryStrings.Add("target=item&id=" + this.unique_id + "&class=company&action=newcalllog");
            return ret;
        }

        public ListArgs ExcessArgsGet(ContextNM x)
        {
            ListArgs ret = new ListArgs(x);
            ret.AddAllow = false;
            ret.TheTable = "partrecord";
            ret.TheClass = "partrecord";
            ret.TheWhere = "( base_company_uid = '" + unique_id + "' or companyname = '" + x.Filter(companyname) + "') ";
            ret.TheTemplate = "company_excessview";
            ret.TheOrder = "date_created desc";
            return ret;
        }
        public ListArgs FeedbackArgsGet(ContextNM x)
        {
            ListArgs ret = new ListArgs(x);
            ret.TheTable = "feedback";
            ret.TheClass = "feedback";
            ret.TheWhere = "the_company_uid = '" + unique_id + "'";
            ret.TheTemplate = "company_feedback_view";
            ret.TheOrder = "date_created desc";
            ret.AddAllow = true;
            ret.AddCaption = "Add New Feedback";
            ret.AddQueryStrings.Add("target=item&id=" + this.unique_id + "&class=company&action=newfeedback");
            return ret;
        }
        public ListArgs NotesArgsGet(ContextNM x)
        {
            ListArgs ret = new ListArgs(x);
            ret.TheTable = "contactnote";
            ret.TheClass = "contactnote";
            ret.TheWhere = "base_company_uid = '" + unique_id + "'";
            ret.TheTemplate = "companynotes";
            ret.TheOrder = "NOTEDATE DESC";
            ret.AddAllow = true;
            ret.AddCaption = "Add A New Note";
            ret.AddQueryStrings.Add("target=item&id=" + this.unique_id + "&class=company&action=newnote");
            return ret;
        }
        public ListArgs UserNoteArgsGet(ContextNM x)
        {
            ListArgs ret = new ListArgs(x);
            ret.TheTable = "usernote";
            ret.TheClass = "usernote";
            ret.TheWhere = "base_company_uid = '" + unique_id + "'";
            ret.TheTemplate = "DEFAULT_USER_NOTES";
            ret.TheOrder = "displaydate DESC";
            ret.AddAllow = false;
            return ret;
        }
        public virtual ListArgs OrderBatchesArgsGet(ContextNM x)
        {
            ListArgs ret = new ListArgs(x);
            string template = "";
            string classname = "";
            string where = "";
            string order = "";

            template = "COMPANYORDERBATCHES";
            classname = "dealheader";
            where = "customer_uid = '" + unique_id + "'";
            order = "date_created desc";

            ret.TheTable = classname;
            ret.TheClass = classname;
            ret.TheWhere = where;
            ret.TheTemplate = template;
            ret.TheOrder = order;
            ret.AddAllow = true;
            ret.AddCaption = "Add A New OrderBatch";
            ret.AddQueryStrings.Add("target=item&id=" + this.unique_id + "&class=company&action=neworderbatch");
            return ret;
        }
        public virtual ListArgs OrdersArgsGet(ContextNM x)
        {
            ListArgs ret = new ListArgs(x);
            //ret.AddAllow = false;
            ret.TheTable = "ordhed";
            ret.TheClass = "ordhed";
            ret.TheWhere = "base_company_uid = '" + unique_id + "'";
            ret.TheTemplate = "COMPANYORDERS";
            ret.TheOrder = "orderdate desc";

            //if (unlimited)
            //    ret.TheLimit = -1;
            //else
            //    ret.TheLimit = n_sys.ListLimitDefault;

            ret.AddAllow = false;

            //this is a good idea; lets talk about making it more universal in core
            //ret.AddAllow = true;
            //ret.AddCaptions.Add("Add A New Quote");
            //ret.AddQueryStrings.Add("target=item&id=" + this.unique_id + "&class=company&action=newformalquote");
            //ret.AddCaptions.Add("Add A New Sales Order");
            //ret.AddQueryStrings.Add("target=item&id=" + this.unique_id + "&class=company&action=new_sales");
            //ret.AddCaptions.Add("Add A New Invoice");
            //ret.AddQueryStrings.Add("target=item&id=" + this.unique_id + "&class=company&action=new_invoice");
            //ret.AddCaptions.Add("Add A New Purchase Order");
            //ret.AddQueryStrings.Add("target=item&id=" + this.unique_id + "&class=company&action=new_purchase");
            return ret;
        }
        public ListArgs ReqArgsGet(ContextNM x)
        {
            ListArgs ret = new ListArgs(x);
            ret.AddAllow = false;
            string template = "";
            string classname = "";
            string where = "";
            string order = "";
            if (((RzLogic)x.TheLogic).UseMergedQuotes)
            {
                template = "COMPANYFORMALQUOTES1";
                classname = "orddet_quote";
                where = "orddet_quote.base_company_uid = '" + unique_id + "' and (isnull(orddet_quote.quantityordered,0) <=0 or isnull(orddet_quote.unitprice,0) <=0)";
                order = "orderdate desc";
            }
            else
            {
                template = "QUICKSHOWREQS";
                classname = "req";
                where = "base_company_uid = '" + unique_id + "'";
                order = "datecreated desc";
            }
            ret.TheTable = classname;
            ret.TheClass = classname;
            ret.TheWhere = where;
            ret.TheTemplate = template;
            ret.TheOrder = order;

            //if (unlimited)
            //    ret.TheLimit = -1;
            //else
            //    ret.TheLimit = n_sys.ListLimitDefault;

            return ret;
        }
        public ListArgs QuoteArgsGet(ContextNM x)
        {
            ListArgs args = QuoteAndReqArgsGet(x);
            if (((RzLogic)x.TheLogic).UseMergedQuotes)
                args.TheWhere += "  and (isnull(orddet_quote.quantityordered,0) > 0 and isnull(orddet_quote.unitprice,0) > 0)";
            return args;
        }
        public virtual ListArgs QuoteAndReqArgsGet(ContextNM x)
        {
            ListArgs ret = new ListArgs(x);
            ret.AddAllow = false;
            string template = "COMPANYFORMALQUOTES1";
            string classname = "orddet_quote";
            string where = "orddet_quote.base_company_uid = '" + unique_id + "'";
            string order = "orderdate desc";

            ret.TheTable = classname;
            ret.TheClass = classname;
            ret.TheWhere = where;
            ret.TheTemplate = template;
            ret.TheOrder = order;
            return ret;
        }
        public static void Group(ContextNM x, nObject c)
        {
            Group(x, c, false);
        }
        public static void Group(ContextNM x, nObject c, String strGroup)
        {
            Group(x, c, false, strGroup);
        }
        public static void Group(ContextNM x, nObject c, bool undo)
        {
            Group(x, c, undo, "");
        }
        public static void Group(ContextNM x, nObject c, bool undo, String strGroup)
        {
            ArrayList a = new ArrayList();
            a.Add(c);
            Group(x, a, undo, c.ClassId, strGroup);
        }
        public static void Group(ContextNM x, ArrayList cs, String strClassName)
        {
            Group(x, cs, false, strClassName, "");
        }
        public static void Group(ContextNM x, ArrayList cs, String strClassName, String strGroup)
        {
            Group(x, cs, false, strClassName, strGroup);
        }
        public static void Group(ContextNM x, ArrayList cs, bool undo, String strClass, String strGroup)
        {
            if (x == null)
                return;
            ((ILeaderRz)x.TheLeader).SetCompanyGroup((ContextRz)x, cs, undo, strClass, strGroup);
        }
        public static company AddNew_Prompt(ContextRz x)
        {
            return company.AddNew(x, "", "", "", "", "");
        }
        public static company AddNew(ContextRz x, String strName)
        {
            return AddNew(x, strName, "", "", "", "");
        }



        //KT Refactored from RzSensible (RzSensible.CompanyLogic.cs)
        public static company AddNew(ContextRz x, String strName, String strContact, String strPhone, String strFax, String strEmail)
        {
            //return ((SysRz5)x.xSys).TheCompanyLogic.AddNew(x, strName, strContact, strPhone, strFax, strEmail);
            try
            {
                //Check to see if the company exists
                strName = ((ILeaderRz)x.Leader).VerifyCompanyName(strName);
                if (!Tools.Strings.StrExt(strName))
                    return null;

                //If it doesn't exist, Initiate new company record
                Rz5.company xCompany = Rz5.company.New(x);

                //Ask the user if this is a vendor
                if (x.TheLeader.AskYesNo("Is this company a Vendor?"))
                {
                    xCompany.companytype = "Vendor";
                    xCompany.isvendor = true;
                    xCompany.abs_type = "DIST";
                    NewMethod.n_user u = NewMethod.n_user.GetByName(x, "Vendor");
                    if (u != null)
                    {
                        xCompany.base_mc_user_uid = u.unique_id;
                        //xCompany.agentname = u.name;
                        //xCompany.agent = u.name;
                        xCompany.agentname = "Vendor";
                        xCompany.agent = "Vendor";
                        xCompany.wherefoundcompany = "Vendor";
                        xCompany.base_mc_user_uid = "4b8bfdf2196a4c1cbf388e041fcd526c";

                    }
                    else
                        x.TheLeader.Tell("User account 'Vendor' not found. Cannot assign to the 'Vendor' account!");
                }
                else
                {
                    //Not a vendor, user must provide the Source
                    String strSource = ((ILeaderRz)x.Leader).ChooseOneChoice(x, "Source", "Please Choose a source:");
                    if (!Tools.Strings.StrExt(strSource))
                        return null;
                    xCompany.wherefoundcompany = strSource;
                    //xCompany.base_mc_user_uid = x.xUser.unique_id;
                    //xCompany.agentname = x.xUser.name;
                    //KT New companies get assigned to the user who added it.
                    if (!Tools.Strings.StrExt(xCompany.base_mc_user_uid))
                    {
                        xCompany.base_mc_user_uid = x.xUser.unique_id;
                        xCompany.agentname = x.xUser.name;
                    }
                }

                xCompany.companyname = strName;
                xCompany.isactive = true;
                xCompany.primarycontact = strContact;
                xCompany.primaryphone = strPhone;
                xCompany.primaryfax = strFax;
                xCompany.primaryemailaddress = strEmail;

                //KT Added default TBD for new companies.
                xCompany.termsascustomer = "TBD";
                xCompany.termsasvendor = "TBD";
                xCompany.created_by_name = x.xUser.name;
                xCompany.created_by_uid = x.xUser.unique_id;
                xCompany.creditascustomer = 500;

                //Do the Insert
                xCompany.Insert(x);
                x.Logic.CacheCompanies(x);
                return xCompany;
            }
            catch { return null; }
        }


        //public static company AddNew(ContextRz x, String strName, String strContact, String strPhone, String strFax, String strEmail)
        //{
        //    try
        //    {
        //        //Check to see if the company exists
        //        strName = ((ILeaderRz)x.Leader).VerifyCompanyName(strName);
        //        if (!Tools.Strings.StrExt(strName))
        //            return null;

        //        //If it doesn't exist, Initiate new company record
        //        Rz5.company xCompany = Rz5.company.New(x);

        //        //Ask the user if this is a vendor
        //        if (x.TheLeader.AskYesNo("Is this company a Vendor?"))
        //        {
        //            xCompany.companytype = "Vendor";
        //            xCompany.isvendor = true;
        //            xCompany.abs_type = "DIST";
        //            NewMethod.n_user u = NewMethod.n_user.GetByName(x, "Vendor");
        //            if (u != null)
        //            {
        //                xCompany.base_mc_user_uid = u.unique_id;
        //                //xCompany.agentname = u.name;
        //                //xCompany.agent = u.name;
        //                xCompany.agentname = "Vendor";
        //                xCompany.agent = "Vendor";
        //                xCompany.wherefoundcompany = "Vendor";
        //                xCompany.base_mc_user_uid = "4b8bfdf2196a4c1cbf388e041fcd526c";

        //            }
        //            else
        //                x.TheLeader.Tell("User account 'Vendor' not found. Cannot assign to the 'Vendor' account!");
        //        }
        //        else
        //        {
        //            //Not a vendor, user must provide the Source
        //            String strSource = ((ILeaderRz)x.Leader).ChooseOneChoice(x, "Source", "Please Choose a source:");
        //            if (!Tools.Strings.StrExt(strSource))
        //                return null;
        //            xCompany.wherefoundcompany = strSource;
        //            xCompany.base_mc_user_uid = x.xUser.unique_id;
        //            xCompany.agentname = x.xUser.name;
        //        }

        //        xCompany.companyname = strName;
        //        xCompany.isactive = true;
        //        xCompany.primarycontact = strContact;
        //        xCompany.primaryphone = strPhone;
        //        xCompany.primaryfax = strFax;
        //        xCompany.primaryemailaddress = strEmail;

        //        //Dop the Insert
        //        xCompany.Insert(x);
        //        x.Logic.CacheCompanies(x);
        //        return xCompany;
        //    }
        //    catch { return null; }
        //}





        public static void UpdateCompanyOEM(ContextRz context, ArrayList companies)
        {
            context.TheLeader.StartPopStatus();
            foreach (String strCompany in companies)
            {
                UpdateCompany(context, strCompany, "OEM");
            }
            context.TheLeader.StopPopStatus(true);
        }
        public static void UpdateCompanyOEM(ContextRz context, String strCompany)
        {
            context.TheLeader.StartPopStatus();
            UpdateCompany(context, strCompany, "OEM");
            context.TheLeader.StopPopStatus(true);
        }
        public static void UpdateCompanyDIST(ContextRz context, ArrayList companies)
        {
            context.TheLeader.StartPopStatus();
            foreach (String strCompany in companies)
            {
                UpdateCompany(context, strCompany, "DIST");
            }
            context.TheLeader.StopPopStatus(true);
        }
        public static void UpdateCompanyDIST(ContextRz context, String strCompany)
        {
            context.TheLeader.StartPopStatus();
            UpdateCompany(context, strCompany, "DIST");
            context.TheLeader.StopPopStatus(true);
        }
        public static void UpdateCompany(ContextRz context, String strCompany, String strType)
        {
            UpdateCompany(context, strCompany, strType, "", "");
        }
        public static void UpdateCompany(ContextRz context, String strCompany, String strType, String strExtraSet, String strExtraCaption)
        {
            if (!Tools.Strings.StrExt(strCompany))
                return;
            context.TheLeader.Comment("Checking " + strType + "...");
            String strSQL = "select companyname, contactname, abs_type from companycontact where isnull(abs_type, '') != '' and isnull(abs_type, '') != '" + strType + "' and companyname = '" + context.TheData.Filter(strCompany) + "' order by companyname, contactname";
            DataTable dt = context.Select(strSQL);
            if (Tools.Data.DataTableExists(dt))
            {
                int i = 0;
                String summary = "Summary:\r\n";
                foreach (DataRow r in dt.Rows)
                {
                    summary += nData.NullFilter_String(r["companyname"]) + "  " + nData.NullFilter_String(r["contactname"]) + "  " + nData.NullFilter_String(r["abs_type"]) + "\r\n";
                    if (i > 5)
                    {
                        summary += "...";
                        break;
                    }
                    i++;
                }
                if (!context.TheLeader.AreYouSure("mark these contacts as " + strType + " even though " + Tools.Number.LongFormat(dt.Rows.Count) + " of them are already marked otherwise?"))
                    return;
            }
            context.TheLeader.Comment("Updating " + strCompany + " to " + strType + "...");
            //update all of the contacts
            context.TheLeader.Comment("Updating contacts...");
            long l = 0;
            strSQL = "update companycontact set abs_type = '" + strType + "'";
            if (Tools.Strings.StrExt(strExtraSet))
                strSQL += ", " + strExtraSet + " ";
            strSQL += "where companyname = '" + context.TheData.Filter(strCompany) + "'";
            context.TheData.TheConnection.Execute(strSQL, ref l);
            if (Tools.Strings.StrExt(strExtraCaption))
                context.TheLeader.Comment("Done: " + Tools.Number.LongFormat(l) + " contacts at " + strCompany + " were set to " + strType + ", " + strExtraCaption + ".");
            else
                context.TheLeader.Comment("Done: " + Tools.Number.LongFormat(l) + " contacts at " + strCompany + " were set to " + strType + ".");
        }
        public static String FilterCompanyName(String s)
        {
            return Tools.Strings.ParseDelimit(s, "[", 1).Trim();
        }
        public static ArrayList DistillCompanyKeys;
        public static ArrayList GetDistillCompanyCollection()
        {
            if (DistillCompanyKeys != null)
                return DistillCompanyKeys;
            ArrayList col = new ArrayList();
            col.Add("vendor");
            col.Add("customer");
            col.Add("international");
            col.Add("int");
            col.Add("incorporated");
            col.Add("inc");
            col.Add("components");
            col.Add("comp");
            col.Add("gmbh");
            col.Add("gbmh");
            col.Add("LTD");
            col.Add("Electronics");
            col.Add("ELEctronic");
            col.Add("COMPANY");
            col.Add("pty");
            col.Add("corp");
            col.Add("industries");
            col.Add("technologies");
            col.Add("technology");
            col.Add("llc");
            DistillCompanyKeys = col;
            return DistillCompanyKeys;
        }
        public static ArrayList DistillContactKeys;
        public static ArrayList GetDistillContactCollection()
        {
            if (DistillContactKeys != null)
                return DistillContactKeys;
            ArrayList col = new ArrayList();
            col.Add("mr ");
            col.Add("mr.");
            col.Add("mrs.");
            col.Add("mrs");
            col.Add("ms ");
            col.Add("ms.");
            col.Add(" jr");
            col.Add(" jr.");
            col.Add("dr ");
            col.Add("dr.");
            col.Add(" DUPE");
            col.Add("sgt.");
            col.Add("sgt ");
            col.Add(" sgt");
            col.Add("master ");
            col.Add("tech ");
            col.Add("msgt ");
            col.Add("msgt.");
            col.Add("col ");
            col.Add("col.");
            col.Add(" GONE");
            col.Add("lance cpl");
            col.Add("lance corporal");
            col.Add("capt ");
            col.Add("captain ");
            col.Add("cap ");
            col.Add("dept ");
            col.Add("tsgt ");
            DistillContactKeys = col;
            return DistillContactKeys;
        }
        public static String DistillCompanyName(String strName)
        {
            String s = Tools.Strings.Left(strName, 50);
            s = Tools.Strings.FilterTrash(s);
            for (int i = 0; i <= 10; i++)
            {
                s = s.Replace("[" + Tools.Strings.Right("0" + i.ToString().Trim(), 2) + "]", "");
            }
            ArrayList c = GetDistillCompanyCollection();
            int iter = 2;
            for (int i = 0; i < iter; i++)
            {
                foreach (String x in c)
                {
                    String t = x;
                    if (Tools.Strings.StrCmp(Tools.Strings.Right(s, t.Length), t))
                    {
                        s = Tools.Strings.Left(s, s.Length - t.Length);
                    }
                }
            }
            return s;
        }
        public static void DistillCompanyNameField(DataConnection xd, String strTable, String strSource, String strTarget)
        {
            xd.Execute("update " + strTable + " set " + strTarget + " = LTRIM(RTRIM(left(isnull(" + strSource + ", ''), 50)))");
            nTools.FilterTrashField(xd, strTable, strTarget, false, true);

            for (int i = 0; i <= 10; i++)
            {
                //s = s.Replace("[" + Tools.Strings.Right("0" + i.ToString().Trim(), 2) + "]", "");
                xd.Execute("update " + strTable + " set " + strTarget + " = replace(" + strTarget + ", '" + "[" + Tools.Strings.Right("0" + i.ToString().Trim(), 2) + "]" + "', '')");
            }
            ArrayList c = GetDistillCompanyCollection();
            int iter = 2;
            for (int i = 0; i < iter; i++)
            {
                foreach (String x in c)
                {
                    xd.Execute("update " + strTable + " set " + strTarget + " = left(" + strTarget + ", len(" + strTarget + ") - " + x.Length.ToString() + ") where " + strTarget + " like '%" + xd.SyntaxFilter(x) + "'");
                    //String t = x;
                    //if (Tools.Strings.StrCmp(Tools.Strings.Right(s, t.Length), t))
                    //{
                    //    s = Tools.Strings.Left(s, s.Length - t.Length);
                    //}
                }
            }
            xd.Execute("update " + strTable + " set " + strTarget + " = LTRIM(RTRIM(" + strTarget + "))");
        }
        public static void SetCompanyObject(nObject xObject, company value, String strCompanyIDField, String strCompanyNameField, String strContactIDField, String strContactNameField)
        {
            if (value == null)
            {
                xObject.ISet(strCompanyIDField, "");
                xObject.ISet(strCompanyNameField, "");
                xObject.ISet(strContactIDField, "");
                xObject.ISet(strContactNameField, "");
            }
            else
            {
                if (!Tools.Strings.StrCmp(value.unique_id, (String)xObject.IGet(strCompanyIDField)))
                {
                    xObject.ISet(strContactIDField, "");
                    xObject.ISet(strContactNameField, "");
                }
                xObject.ISet(strCompanyIDField, value.unique_id);
                xObject.ISet(strCompanyNameField, value.companyname);
            }
        }
        public static String GetEmailByID(ContextRz context, String strID)
        {
            return (String)context.SelectScalarString("select primaryemailaddress from company where unique_id = '" + strID + "'");
        }
        public static void FillIn(ContextRz context, nObject xObject, String strIDProp, String strNameProp)
        {
            if (!Tools.Strings.StrExt((String)xObject.IGet(strIDProp)) && Tools.Strings.StrExt((String)xObject.IGet(strNameProp)))
                xObject.ISet(strIDProp, company.TranslateNameToID(context, (String)xObject.IGet(strNameProp)));
            else if (!Tools.Strings.StrExt((String)xObject.IGet(strNameProp)) && Tools.Strings.StrExt((String)xObject.IGet(strIDProp)))
                xObject.ISet(strNameProp, company.TranslateIDToName(context, (String)xObject.IGet(strIDProp)));
        }
        public static company GetByEmailAddress(ContextRz x, String strAddress)
        {
            //if( Rz3App.xLogic.IsAAT )
            //    return GetByEmailAddressCheckContacts(xs, strAddress);
            return (company)x.QtO("company", "select top 1 * from company where primaryemailaddress = '" + x.Filter(strAddress) + "'");
        }
        public static company GetByEmailAddressCheckContacts(ContextRz x, String strAddress)
        {
            company c = (company)x.QtO("company", "select top 1 * from company where primaryemailaddress = '" + x.Filter(strAddress) + "'");
            if (c != null)
                return c;
            String id = x.TheData.SelectScalarString("select top 1 base_company_uid from companycontact where primaryemailaddress = '" + x.Filter(strAddress) + "'");
            if (Tools.Strings.StrExt(id))
                return null;
            return company.GetById(x, id);
        }
        public static company GetByName(ContextRz context, String strName)
        {
            return (company)context.TheData.GetByWhere(context, "company", "companyname = '" + context.Filter(strName) + "'");
        }
        public static company GetByDistilledName(ContextRz context, String strName)
        {
            return (company)context.QtO("company", "select top 1 * from company where distilledname = '" + context.Filter(company.DistillCompanyName(strName)) + "'");
        }
        public static String TranslateNameToID(ContextRz x, String strName)
        {
            try
            {
                if (!Tools.Strings.StrExt(strName))
                    return "";
                DataRow[] rows = x.Logic.CompanyList.Select("caption = '" + x.TheData.Filter(strName) + "'");
                if (rows.Length <= 0)
                    return x.TheData.SelectScalarString("select unique_id from company where companyname = '" + x.TheData.Filter(strName) + "'");
                DataRow r = rows[0];
                return (String)r[1];
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static String TranslateIDToName(ContextRz x, String strID)
        {
            try
            {
                DataRow[] rows = x.Logic.CompanyList.Select("unique_id = '" + x.TheData.Filter(strID) + "'");
                if (rows.Length <= 0)
                    return x.TheData.SelectScalarString("select companyname from company where unique_id = '" + x.TheData.Filter(strID) + "'");
                DataRow r = rows[0];
                return (String)r[0];
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static void GetRandomInfo(ContextRz x, ref String strID, ref String strName)
        {
            strID = "";
            strName = "";
            try
            {
                Int32 i = RandomProvider.Next(0, x.Logic.CompanyList.Rows.Count - 1);
                DataRow r = x.Logic.CompanyList.Rows[i];
                strID = (String)r[1];
                strName = (String)r[0];
            }
            catch (Exception)
            {
            }
        }
        //public static void BlockForProblems(ILinkedCompany x, CompanyStub l)
        //{
        //    BlockForProblems(x, l, Rz3App.xMainForm.TheContextNM);
        //}
        //public static void BlockForProblems(ILinkedCompany x, CompanyStub l, ContextNM xn)
        //{
        //    if (Rz3App.xUser.SuperUser)
        //        return;
        //    company c = x.CompanyObject;
        //    if (c == null)
        //        return;
        //    if (c.HasAnyProblems)
        //    {
        //        if (c.HasCriticalProblems && !Rz3App.xUser.SuperUser)
        //        {
        //            xn.TheLeader.TellTemp("This company has been " + c.ProblemDescription + ", and cannot be assigned.  Please contact accounting to continue.");
        //            l.Clear();
        //            x.CompanyObject = null;
        //        }
        //        else
        //            xn.TheLeader.TellTemp("Please note that this company has been " + c.ProblemDescription + ".");
        //        return;
        //    }
        //}
        public static bool Import(ContextNM x, nDataTable dtCompany, String strCompanyUID, nDataTable dtContact, String strContactUID, nDataTable dtAddress, String strAddressUID, String strUserID)
        {
            x.Reorg();
            return false;
            //if (!PrepareCompanyImport(contextRz, dtCompany, strUserID))
            //    return false;
            //if( !ImportCompanyList(dtCompany) )
            //    return false;
            //String strEmpty = "";
            //ArrayList a;
            //SortedList props;
            //long importcount = 0;
            ////contacts
            //if(dtContact != null)
            //{
            //    dtContact.SetActualFieldNames();
            //    if( !dtContact.FormalizeFieldTypes(false) )
            //        return false;
            //    dtContact.AddField("contactname");
            //    dtContact.AddField("companyname");
            //    dtContact.AddField("primaryphone");
            //    dtContact.AddField("primaryfax");
            //    dtContact.AddField("primaryemailaddress");
            //    dtContact.AddField("base_company_uid");
            //    if( !dtContact.CheckCriteria("have no contact name", "isnull(contactname , '') = ''", false) )
            //        return false;
            //    strEmpty = "";
            //    if( dtContact.xData.IsTextField(dtContact.TableName, strContactUID) )
            //        strEmpty = "isnull(" + dtContact.TableName + "." + strContactUID + ", '') > ''";
            //    else
            //        strEmpty = "isnull(" + dtContact.TableName + "." + strContactUID + ", 0) > 0";
            //    if( !dtContact.xData.Execute("update " + dtContact.TableName + " set base_company_uid = (select max(unique_id) from company where company." + strCompanyUID + " = " + dtContact.TableName + "." + strContactUID + ") where " + strEmpty + " and exists( select unique_id from company where company." + strCompanyUID + " = " + dtContact.TableName + "." + strContactUID + ")") )
            //        return false;
            //    if( !dtContact.xData.Execute("update " + dtContact.TableName + " set companyname = (select max(companyname) from company where company.unique_id = " + dtContact.TableName + ".base_company_uid) where isnull(base_company_uid, '') > ''") )
            //        return false;
            //    if( !dtContact.CheckCriteria("have no company link", "isnull(base_company_uid , '') = ''", false) )
            //        return false;
            //    a = new ArrayList();
            //    a.Add("contactname");
            //    a.Add("companyname");
            //    a.Add("primaryphone");
            //    a.Add("primaryfax");
            //    a.Add("primaryemailaddress");
            //    a.Add("base_company_uid");
            //    props = x.xSys.CoalescePropsByClass("companycontact");
            //    importcount = 0;
            //    if( !dtContact.ImportObjects("companycontact", "unique_id", props, a, ref importcount) )
            //        return false;
            //}
            ////addresses
            //if(dtAddress != null)
            //{
            //    dtAddress.SetActualFieldNames();
            //    if( !dtAddress.FormalizeFieldTypes(false) )
            //        return false;
            //    dtAddress.AddField("line1");
            //    dtAddress.AddField("base_company_uid");
            //    if( !dtAddress.CheckCriteria("have no first address line", "isnull(line1 , '') = ''", false) )
            //        return false;
            //    if( dtAddress.xData.IsTextField(dtAddress.TableName, strAddressUID) )
            //        strEmpty = "isnull(" + dtAddress.TableName + "." + strAddressUID + ", '') > ''";
            //    else
            //        strEmpty = "isnull(" + dtAddress.TableName + "." + strAddressUID + ", 0) > 0";
            //    if( !dtAddress.xData.Execute("update " + dtAddress.TableName + " set base_company_uid = (select max(unique_id) from company where company." + strCompanyUID + " = " + dtAddress.TableName + "." + strAddressUID + ") where " + strEmpty + " and exists( select unique_id from company where company." + strCompanyUID + " = " + dtAddress.TableName + "." + strAddressUID + ")") )
            //        return false;
            //    if( !dtAddress.CheckCriteria("have no company link", "isnull(base_company_uid , '') = ''", false) )
            //        return false;
            //    a = new ArrayList();
            //    a.Add("line1");
            //    a.Add("base_company_uid");
            //    props = x.xSys.CoalescePropsByClass("companyaddress");
            //    importcount = 0;
            //    if( !dtAddress.ImportObjects("companyaddress", "unique_id", props, a, ref importcount) )
            //        return false;
            //}
            //return true;
        }
        public static int Import(ContextRz context, nDataTable dtCompany, String strUserUID, String strSource)
        {
            PrepareCompanyImport(context, dtCompany, strUserUID);

            String id_update = "";

            if (!dtCompany.xData.FieldExists(dtCompany.TableName, "use_company_uid"))
            {
                id_update = "alter table " + dtCompany.TableName + " add use_company_uid varchar(255)";
                dtCompany.xData.Execute(id_update);
            }

            id_update = "update " + dtCompany.TableName + " set use_company_uid  = unique_id";
            dtCompany.xData.Execute(id_update);

            //merge them
            id_update = "update " + dtCompany.TableName + " set use_company_uid = ( select max(use_company_uid) from " + dtCompany.TableName + " x where isnull(" + dtCompany.TableName + ".companyname, '') > '' and x.companyname = " + dtCompany.TableName + ".companyname)";
            dtCompany.xData.Execute(id_update);

            id_update = "update x set use_company_uid = c.unique_id from " + dtCompany.TableName + " x inner join company c on x.companyname = c.companyname where isnull(x.companyname, '') > ''";
            dtCompany.xData.Execute(id_update);

            //source
            dtCompany.AddField("source");
            dtCompany.SetFieldIfBlank("source", strSource);
            //billing addresses
            if (dtCompany.HasColumnField("extra_billing_line1"))
            {
                dtCompany.AddField("extra_billing_line2");
                dtCompany.AddField("extra_billing_city");
                dtCompany.AddField("extra_billing_state");
                dtCompany.AddField("extra_billing_zip");
                dtCompany.AddField("extra_billing_country");
                //bring in the billing addresses
                String strSQL = "insert into companyaddress(unique_id, base_company_uid, line1, line2, adrcity, adrstate, adrzip, adrcountry, defaultbilling, description) select cast(newid() as varchar(255)) as unqiue_id, use_company_uid as base_company_uid, extra_billing_line1, extra_billing_line2, extra_billing_city, extra_billing_state, extra_billing_zip, extra_billing_country, 1 as defaultbilling, 'Billing' as description from " + dtCompany.TableName + " where isnull(extra_billing_line1, '') > ''";
                dtCompany.xData.Execute(strSQL);
            }
            //shipping addresses
            if (dtCompany.HasColumnField("extra_shipping_line1"))
            {
                dtCompany.AddField("extra_shipping_line2");
                dtCompany.AddField("extra_shipping_city");
                dtCompany.AddField("extra_shipping_state");
                dtCompany.AddField("extra_shipping_zip");
                dtCompany.AddField("extra_shipping_country");
                //bring in the shipping addresses
                String strSQL = "insert into companyaddress(unique_id, base_company_uid, line1, line2, adrcity, adrstate, adrzip, adrcountry, defaultshipping, description) select cast(newid() as varchar(255)) as unqiue_id, use_company_uid as base_company_uid, extra_shipping_line1, extra_shipping_line2, extra_shipping_city, extra_shipping_state, extra_shipping_zip, extra_shipping_country, 1 as defaultshipping, 'Shipping' as description from " + dtCompany.TableName + " where isnull(extra_shipping_line1, '') > ''";
                dtCompany.xData.Execute(strSQL);
            }
            //split name
            if (!dtCompany.HasColumnField("primarycontact"))
            {
                if (dtCompany.HasColumnField("extra_firstname") && dtCompany.HasColumnField("extra_lastname"))
                {
                    dtCompany.AddField("primarycontact");
                    dtCompany.xData.Execute("update " + dtCompany.TableName + " set primarycontact = LTRIM(RTRIM(isnull(extra_firstname, '') + ' ' + isnull(extra_lastname, '')))");
                }
                else
                {
                    //nStatus.TellUserTemp("Please choose either a full contact name field, or both a first and last contact name field.");
                    //return false;
                    dtCompany.AddField("primarycontact");
                }
            }
            //email domain
            if (dtCompany.HasColumnField("primaryemailaddress"))
            {
                dtCompany.AddField("email_domain");
                dtCompany.xData.SplitEmailDomain(dtCompany.TableName, "primaryemailaddress", "email_domain");
            }
            //contacts
            if (dtCompany.FieldExists("primarycontact"))
            {
                dtCompany.AddField("primaryphone");
                dtCompany.AddField("primaryfax");
                dtCompany.AddField("primaryemailaddress");
                dtCompany.AddField("email_domain");
                dtCompany.AddField("extra_contact_title");
                dtCompany.AddField("extra_contact_line1");
                dtCompany.AddField("extra_contact_line2");
                dtCompany.AddField("extra_contact_city");
                dtCompany.AddField("extra_contact_state");
                dtCompany.AddField("extra_contact_zip");
                dtCompany.AddField("extra_contact_country");
                dtCompany.AddField("extra_contact_id", "int", "0");

                if (!dtCompany.FieldExists("extra_contact_phone"))
                {
                    dtCompany.AddField("extra_contact_phone");
                    dtCompany.xData.Execute("update " + dtCompany.TableName + " set extra_contact_phone = primaryphone");
                }

                if (!dtCompany.FieldExists("extra_contact_fax"))
                {
                    dtCompany.AddField("extra_contact_fax");
                    dtCompany.xData.Execute("update " + dtCompany.TableName + " set extra_contact_fax = primaryfax");
                }

                dtCompany.AddField("extra_contact_phone2");
                dtCompany.AddField("extra_contact_phone3");
                dtCompany.AddField("extra_contact_phone4");

                context.Execute("alter table companycontact add contact_import_id int", true);

                if (!dtCompany.xData.FieldExists(dtCompany.TableName, "contact_already_exists"))
                    dtCompany.xData.Execute("alter table " + dtCompany.TableName + " add contact_already_exists bit");

                dtCompany.xData.Execute("update x set x.contact_already_exists = 1 from " + dtCompany.TableName + " x inner join companycontact c on x.primarycontact = c.contactname and x.use_company_uid = c.base_company_uid");

                //bring in the contacts
                String strSQL = "insert into companycontact(unique_id, base_company_uid, companyname, contactname, primaryphone, alternatephone, alternatefax, alternateemail, primaryfax, primaryemailaddress, email_domain, jobtype, line1, line2, adrcity, adrstate, adrzip, adrcountry, contact_import_id, agentname, base_mc_user_uid) select cast(newid() as varchar(255)) as unqiue_id, use_company_uid as base_company_uid, left(companyname,255), left(primarycontact,255), left(extra_contact_phone,50), left(extra_contact_phone2,50), left(extra_contact_phone3,50), left(extra_contact_phone4,50), left(extra_contact_fax,50), left(primaryemailaddress,50), left(email_domain,50), left(extra_contact_title, 50), left(extra_contact_line1, 255), left(extra_contact_line2, 255), left(extra_contact_city, 255), left(extra_contact_state, 255), left(extra_contact_zip, 255), left(extra_contact_country, 255), extra_contact_id, agentname, base_mc_user_uid from " + dtCompany.TableName + " where isnull(primarycontact, '') > '' and isnull(contact_already_exists, 0) = 0";
                dtCompany.xData.Execute(strSQL);
            }

            if (!dtCompany.FieldExists("date_created"))
            {
                dtCompany.AddField("date_created");
                dtCompany.xData.Execute("update " + dtCompany.TableName + " set date_created = '" + DateTime.Now.ToString() + "'");
            }

            if (dtCompany.Count == 0)
                throw new Exception("After filtering duplicates, no companies are left to import.");

            int ret = ImportCompanyList(context, dtCompany);

            if (dtCompany.HasColumnField("companyname") && dtCompany.HasColumnField("notetext"))
                company.ImportCompanyNotes(context, dtCompany);

            return ret;
        }
        public static void ImportCompanyNotes(ContextRz context, nDataTable dt)
        {
            String fields = "unique_id, base_company_uid, companyname, notetext, notedate";
            String sel = "cast(newid() as varchar(255)), notes_company_uid, companyname, isnull(notetext, ''), getdate()";

            if (!dt.xData.FieldExists(dt.TableName, "notes_company_uid"))
                dt.xData.Execute("alter table " + dt.TableName + " add notes_company_uid varchar(255), notes_contact_uid varchar(255)");

            dt.xData.Execute("update x set x.notes_company_uid = c.unique_id from " + dt.TableName + " x inner join company c on x.companyname = c.companyname");

            if (dt.HasColumnField("primarycontact"))
            {
                fields += ", base_companycontact_uid, contactname";
                sel += ", notes_contact_uid, primarycontact";
                dt.xData.Execute("update x set x.notes_contact_uid = c.unique_id from " + dt.TableName + " x inner join companycontact c on x.companyname = c.companyname and x.primarycontact = c.contactname");
            }

            long lnote = 0;
            dt.xData.Execute("insert into contactnote ( " + fields + " ) select " + sel + " from " + dt.TableName, ref lnote);
            context.TheLeader.Tell("Notes imported: " + lnote.ToString());
        }
        private static int ImportCompanyList(ContextRz context, nDataTable dtCompany)
        {
            ArrayList a = new ArrayList();
            a.Add("companyname");
            a.Add("base_mc_user_uid");
            a.Add("agentname");
            a.Add("source");

            List<CoreVarValAttribute> props = context.Sys.VarVals("company");

            String strFields = "";
            String strValues = "";
            //String strGroup = "";

            foreach (CoreVarValAttribute p in props)
            {
                strFields += ", " + p.Name;

                if (Tools.Strings.StrCmp(p.Name, "companyname"))
                {
                    strValues += ", " + p.Name;
                }
                else
                {
                    if (nTools.IsInArray(p.Name, a) || dtCompany.HasNonExtraColumnField(p.Name))  //nTools.IsInArray(p.name, a) || 
                    {
                        String strX = "";
                        switch (p.TheFieldType)
                        {
                            case FieldType.String:

                                if (p.TheFieldLength > 0)
                                    strX = ", max(left(" + p.Name + ", " + p.TheFieldLength.ToString() + "))";
                                else
                                    strX = ", max(left(" + p.Name + ", 50))";
                                break;
                            default:
                                strX = ", max(" + p.Name + ")";
                                break;
                        }
                        strValues += strX;
                        //strGroup += strX;
                    }
                    else
                    {
                        if (Tools.Strings.StrCmp(p.Name, "date_created"))
                            strValues += ", max(" + p.Name + ")";
                        else
                            strValues += ", " + DataConnectionSqlServer.ReplaceNullString(p.TheFieldType) + " as " + p.Name;
                    }
                }
            }

            String strSQL = "insert into company (unique_id " + strFields + ") select max(use_company_uid) " + strValues + " from " + dtCompany.TableName + " where use_company_uid <> 'not an id' and companyname not in (select isnull(companyname, '') from company) and use_company_uid not in ( select unique_id from company ) group by companyname ";  // +extra_where;   // + " group by " + unique_id_field + " " + strGroup
            //Tools.FileSystem.PopText(strSQL);
            //SetStatus("Importing...");
            long importcount = 0;
            dtCompany.xData.Execute(strSQL, ref importcount);
            return Convert.ToInt32(importcount);
        }
        public static void PrepareCompanyImport(ContextNM x, nDataTable dtCompany, String strUserUID)
        {
            dtCompany.SetActualFieldNames(x);
            dtCompany.FormalizeFieldTypes(x);
            dtCompany.LimitFieldLength("companyname", 50);

            dtCompany.CheckCriteria(x, "have no company name", "isnull(companyname, '') = ''");

            //before the duplicate filter, update the vendors by company name
            if (dtCompany.FieldExists("legacyid"))
                dtCompany.xData.Execute("update company set legacyid = (select max(legacyid) from " + dtCompany.TableName + " x where isnull(x.companyname, '') > '' and x.companyname = company.companyname) where isnull(legacyid, '') = ''");

            bool agent = dtCompany.HasColumnField("agentname");
            dtCompany.AddField("base_mc_user_uid");
            dtCompany.AddField("agentname");
            if (Tools.Strings.StrExt(strUserUID))
            {
                dtCompany.LinkInInfo("base_mc_user_uid", strUserUID, "n_user", "user_code", "unique_id");
                dtCompany.LinkInInfo("agentname", "base_mc_user_uid", "n_user", "unique_id", "name");
            }
            else
            {
                if (agent)
                {
                    dtCompany.LinkInInfo("base_mc_user_uid", "agentname", "n_user", "name", "unique_id");
                    dtCompany.LinkInInfo("agentname", "base_mc_user_uid", "n_user", "unique_id", "name");
                }
            }
        }
        public static void Consolidate(ContextRz context, ArrayList companies)
        {
            context.Reorg();
            //try
            //{
            //    CompanyMergeScreen s = new CompanyMergeScreen();
            //    RzApp.xMainForm.TabShow(s, "Company Merge");
            //    //TabPage t = Rz3App.xMainForm.ShowGenericTabControl(s);
            //    //t.Text = "Company Merge";
            //    s.CompleteLoad(companies);
            //}
            //catch(Exception)
            //{
            //}
        }
        public static void Assign(ContextNM x, ArrayList companies)
        {
            if (x == null)
                return;
            ((ILeaderRz)x.TheLeader).AssignAgentShow((ContextRz)x, companies);
        }
        public static company FindACompany(ContextRz context, String strName, String strPhone, String strFax, String strEmail)
        {
            company xCompany = null;
            String strDistill = "";
            //By Distilled Name
            if (Tools.Strings.StrExt(strName))
            {
                strDistill = company.DistillCompanyName(strName);
                if (Tools.Strings.StrExt(strDistill))
                {
                    xCompany = (company)context.QtO("company", "select * from company where distilledname = '" + context.Filter(strDistill) + "'");
                    if (xCompany != null)
                        return xCompany;
                }
            }
            //By Phone Number
            strName = strPhone;
            if (Tools.Strings.StrExt(strName))
            {
                strDistill = nTools.DistillPhoneNumber(strName);
                if (Tools.Strings.StrExt(strDistill) && strDistill.Length >= 7)
                {
                    xCompany = (company)context.QtO("company", "select * from company where distilledphone = '" + strDistill + "'");
                    if (xCompany != null)
                        return xCompany;
                }
            }
            //By Fax Number
            strName = strFax;
            if (Tools.Strings.StrExt(strName))
            {
                strDistill = nTools.DistillPhoneNumber(strName);
                if (Tools.Strings.StrExt(strDistill) && strDistill.Length >= 7)
                {
                    xCompany = (company)context.QtO("company", "select * from company where distilledfax = '" + strDistill + "'");
                    if (xCompany != null)
                        return xCompany;
                }
            }
            //By email address
            strDistill = strEmail.ToLower().Trim();
            if (strDistill.Contains("@") && strDistill.Length >= 4)
            {
                xCompany = (company)context.QtO("company", "select * from company where primaryemailaddress = '" + strDistill + "'");
                if (xCompany != null)
                    return xCompany;
            }
            return null;
        }
        public static void SetTimeZone(ContextRz context, ArrayList a)
        {
            try
            {
                if (a == null)
                    return;
                if (a.Count <= 0)
                    return;
                string s = context.TheLeader.AskForString("Please enter the time zone you want to assign.");
                foreach (company c in a)
                {
                    c.timezone = s;
                    context.Update(c);
                }
                context.TheLeader.Tell("Done.");
            }
            catch { }
        }
        public static void SetCompanyType(ContextNM x, ArrayList a)
        {
            if (x == null)
                return;
            ((ILeaderRz)x.TheLeader).SetCompanyType((ContextRz)x, a);
        }
        //Public Virtual Functions
        public virtual void AssignContacts(ContextRz context, NewMethod.n_user u)
        {
            context.Execute("update companycontact set base_mc_user_uid = '" + u.unique_id + "', agentname = '" + context.Filter(u.name) + "' where base_company_uid = '" + this.unique_id + "'");
        }
        public virtual String GetVendorTerms()
        {
            return termsasvendor;
        }
        public virtual bool HasAnyProblems
        {
            get
            {
                return (is_problem || is_locked || islocked_purchase || ispastdue || oncredithold);
            }
        }
        public virtual bool HasCriticalProblems
        {
            get
            {
                return (is_locked);
            }
        }
        public virtual String ProblemDescription
        {
            get
            {
                String s = "";
                if (is_problem)
                    s += "marked as a problem account";
                if (is_locked)
                {
                    if (Tools.Strings.StrExt(s))
                        s += " and ";
                    s += "marked as locked";
                }
                if (islocked_purchase)
                {
                    if (Tools.Strings.StrExt(s))
                        s += " and ";
                    s += "marked as locked for purchasing";
                }
                if (ispastdue)
                {
                    if (Tools.Strings.StrExt(s))
                        s += " and ";
                    s += "marked as past due";
                }
                if (oncredithold)
                {
                    if (Tools.Strings.StrExt(s))
                        s += " and ";
                    s += "marked as on credit hold";
                }
                return s;
            }
        }
        public virtual String GetQuickbooksCustomerName(ContextRz context)
        {
            if (Tools.Strings.StrExt(qb_name))
                return qb_name;
            else
                return context.TheSysRz.TheQuickBooksLogic.FilterCustomerName(context, companyname);
        }
        public virtual String GetQuickbooksVendorName(ContextRz context)
        {
            try
            {
                if (Tools.Strings.StrExt(qb_name_v))
                {
                    return qb_name_v;
                }
                else
                {
                    if (Tools.Strings.StrExt(context.TheSysRz.TheQuickBooksLogic.VendorSuffix(context)))
                    {
                        if (Tools.Strings.StrExt(qb_name))
                            return qb_name.Trim() + " " + context.TheSysRz.TheQuickBooksLogic.VendorSuffix(context).Trim();
                        else
                            return context.TheSysRz.TheQuickBooksLogic.FilterVendorName(context, companyname);
                    }
                    else
                        return context.TheSysRz.TheQuickBooksLogic.FilterCustomerName(context, companyname);
                }
            }
            catch (Exception ex)
            {
                context.TheLeader.Comment("Error in getting the QB vendor name: " + ex.Message);
                return "";
            }
        }
        //Public Override Functions
        public override void HandleAction(ActArgs args)
        {
            ContextRz xrz = (ContextRz)args.TheContext;
            if (Tools.Strings.StrCmp(args.ActionName, "new-purchase"))
                args.Name = "new_purchase";
            if (Tools.Strings.StrCmp(args.ActionName, "new-invoice"))
                args.Name = "new_invoice";
            if (Tools.Strings.StrCmp(args.ActionName, "new-sales"))
                args.Name = "new_sales";
            if (Tools.Strings.StrCmp(args.ActionName, "sende-mail"))
                args.Name = "sendemail";
            ArrayList a;
            switch (args.ActionName.ToLower().Trim())
            {
                case "newquote":
                    ShowNewOrder(xrz, Enums.OrderType.Quote);
                    args.Handled = true;
                    break;
                case "newbid":
                    ShowNewOrder(xrz, Enums.OrderType.RFQ);
                    args.Handled = true;
                    break;
                case "newfeedback":
                    ShowNewFeedback(xrz);
                    break;
                case "newcalllog":
                    ShowNewCallLog(xrz);
                    break;
                case "newnote":
                    ShowNewNote(xrz);
                    break;
                case "newshippingaccount":
                    ShowNewShippingAccount(xrz);
                    break;
                case "setcompanytype":
                    a = new ArrayList();
                    a.Add(this);
                    company.SetCompanyType(xrz, a);
                    break;
                case "settimezone":
                    a = new ArrayList();
                    a.Add(this);
                    company.SetTimeZone(xrz, a);
                    break;
                case "creditrequestform":
                    PrintCreditRequestForm(xrz);
                    break;
                case "newformalquote":
                case "createprintedquote":
                    ShowNewOrder(xrz, Enums.OrderType.Quote);
                    break;
                case "newconsigned":
                    ShowNewPart(xrz, Enums.StockType.Consign);
                    break;
                case "quickbooks":
                    DoAction_QuickBooks(args);
                    break;
                case "transactions":
                    DoAction_Transactions(args);
                    break;
                case "viewhistory":
                    DoAction_ViewHistory(args);
                    break;
                case "newcontact":
                    ShowNewContact(xrz);
                    break;
                case "sendemail":
                    DoAction_SendEmail(xrz, args);
                    break;
                case "new_purchase":
                    ShowNewOrder(xrz, Enums.OrderType.Purchase);
                    break;
                case "requestqbname":
                    DoAction_RequestQBName(args);
                    break;
                case "newaddress":
                    ShowNewAddress(xrz);
                    break;
                case "popqb":
                    throw new NotImplementedException("Company.PopQB");
                    break;
                case "new_invoice":
                    ShowNewOrder(xrz, Enums.OrderType.Invoice);
                    break;
                case "newtransaction":
                    ShowNewTransaction(xrz);
                    break;
                case "new_sales":
                    ShowNewOrder(xrz, Enums.OrderType.Sales);
                    break;
                case "scan/viewdocuments":
                    DoAction_ScanViewDocuments(args);
                    break;
                //case "addasqbcustomer":
                //case "addasquickbookscustomer":
                //    SendToQuickBooks(xrz, Enums.CompanySelectionType.Customer);
                //    break;
                //case "addasqbvendor":
                //case "addasquickbooksvendor":
                //    SendToQuickBooks(xrz, Enums.CompanySelectionType.Vendor);
                //    break;
                case "companytoqb":
                    ShowCompanyToQbForm(xrz, Enums.CompanySelectionType.Customer, this, GetPrimaryShippingAddressString(xrz), GetPrimaryBillingAddressString(xrz));
                    break;

                case "hotpart":
                    xrz.Logic.NewHotPart(xrz, this, null, "");
                    break;
                //case "labelrequest":
                //    if(context.Logic.SendLabelPrintRequest("marketing", this, "", false))
                //    {
                //        last_marketing = System.DateTime.Now;
                //        args.TheContext.Update(this);
                //    }
                //    break;
                case "assign":
                    DoAction_Assign((ContextNM)args.TheContext);
                    break;
                case "group":
                    company.Group((ContextNM)args.TheContext, this);
                    break;
                case "un-group":
                    company.Group((ContextNM)args.TheContext, this, true);
                    break;
                case "newexcess":
                    ShowNewPart(xrz, Enums.StockType.Excess);
                    break;
                case "neworderbatch":
                    dealheader.ShowManualDeal(xrz, this, null);
                    args.Handled = true;
                    break;
                //case "newpurchasingbatch":
                //    dealheader.ShowManualDeal(xSys, this.unique_id, companyname, "", "", true);
                //    break;
                case "checkwww.dnb.com":
                    company.CheckDnB(xrz, companyname, statename);
                    break;
                case "linecard":
                    LineCardEdit(xrz);
                    break;
                case "sende-mail":
                    base.HandleAction(args);
                    break;
                case "receivecustomerpayment":
                    xrz.TheLeaderRz.ReceivePaymentsShow(xrz, this);
                    break;
                //KT Refactored from RzSensible
                case "setindustrysegment":
                    a = new ArrayList();
                    a.Add(this);
                    company.SetIndustrySegment(xrz, args.TheItems.AllGet(args.TheContext));
                    break;



                default:
                    base.HandleAction(args);
                    break;
            }
        }
        public override void Inserting(Context x)
        {
            datecreated = DateTime.Now;
            datemodified = DateTime.Now;
            isactive = true;
            //if( Tools.Strings.StrExt(context.Logic.DefaultAgentName) && !Tools.Strings.StrExt(base_mc_user_uid) )
            //    base_mc_user_uid = NewMethod.n_user.TranslateNameToID((ContextRz)x, context.Logic.DefaultAgentName);
            base.Inserting(x);
        }
        public override void Updating(Context context)
        {
            ContextRz xrz = (ContextRz)context;

            distilledname = company.DistillCompanyName(companyname);
            distilledphone = nTools.DistillPhoneNumber(primaryphone);
            distilledfax = nTools.DistillPhoneNumber(primaryfax);
            strippedphone = distilledphone;
            NewMethod.n_user.FillIn((ContextNM)context, this, "base_mc_user_uid", "agentname");
            if (xrz.Logic.UpperCaseEverything)
            {
                companyname = companyname.ToUpper();
                primaryphone = primaryphone.ToUpper();
                primarycontact = primarycontact.ToUpper();
                country = country.ToUpper();
            }
            companyname = companyname.Trim();

            int freq = 0;

            try
            {
                if (Tools.Number.IsNumeric(this.contactfrequency))
                    freq = Int32.Parse(this.contactfrequency);
            }
            catch { }

            if (freq > 0 && Tools.Dates.DateExists(this.last_activity_date))
                this.next_contact_date = last_activity_date.Add(TimeSpan.FromDays(freq));
            base.Updating(context);
        }
        public override string ToString()
        {
            return companyname;
        }
        public override String GetClipHTML(ContextNM context)
        {
            String s = GetClipHeader(context);
            s += GetClipLine(context, "primarycontact", "Contact");
            s += GetClipLine_Phone("primaryphone", "primaryphoneextension", "Phone");
            s += GetClipLine(context, "primaryfax", "Fax");
            s += GetClipLine_Email("primaryemailaddress");
            s += GetClipLine_URL("primarywebaddress");
            s += context.xSys.GetHTMLList_SQL(context, "Quotes", ordhed.MakeOrdhedName(Enums.OrderType.Quote), "select top 100 " + ordhed.MakeOrdhedName(Enums.OrderType.Quote) + ".unique_id, " + ordhed.MakeOrdhedName(Enums.OrderType.Quote) + ".orderdate, " + ordhed.MakeOrddetName(Enums.OrderType.Quote) + ".fullpartnumber, " + ordhed.MakeOrddetName(Enums.OrderType.Quote) + ".quantityordered, " + ordhed.MakeOrddetName(Enums.OrderType.Quote) + ".unitprice from " + ordhed.MakeOrdhedName(Enums.OrderType.Quote) + " inner join " + ordhed.MakeOrddetName(Enums.OrderType.Quote) + " on " + ordhed.MakeOrddetName(Enums.OrderType.Quote) + ".base_ordhed_uid = " + ordhed.MakeOrdhedName(Enums.OrderType.Quote) + ".unique_id and " + ordhed.MakeOrdhedName(Enums.OrderType.Quote) + ".ordertype = 'quote' and " + ordhed.MakeOrdhedName(Enums.OrderType.Quote) + ".base_company_uid = '" + unique_id + "' order by " + ordhed.MakeOrdhedName(Enums.OrderType.Quote) + ".orderdate desc");
            return s;
        }

        //public bool UserIsCaptainofCompanyOwnerTeam(ContextNM x, n_user companyOwner)
        //{
        //    //x holds the current user x.xUser       
        //    //Captains are currently only used for team managers
        //    //If you are a team captain, you can view and edit all companies and orders on your team. 
        //    //foreach (n_team team in n_team.GetAllTeamsForUser(x, companyOwner.unique_id))//All the teams the CompanyOwner belongs to
        //    //{
        //    //    //if Current User is Captain of one of those teams
        //    //    n_member m = n_member.GetMemberByTeamID(x, team, x.xUser.unique_id);
        //    //    if (m != null)
        //    //        if (m.is_captain)
        //    //        {
        //    //            return true;
        //    //        }

        //    //}
        //    if (x.xUser.IsTeamCaptainOf(x, companyOwner.unique_id))
        //        return true;
        //    return false;
        //}

        public bool IsCompanyOwnedByTeamCaptain(ContextNM x, string companyOwnerID)
        {

            foreach (n_team team in n_team.GetAllTeamsForUser(x, x.xUser.unique_id))
            {
                ///If this company is owned by the team captain.                
                n_member m = n_member.GetMemberByTeamID(x, team, companyOwnerID);
                if (m != null)
                    if (m.is_captain)
                    {
                        return true;
                    }
            }
            return false;
        }

        public override bool CanBeViewedBy(ContextNM context, ShowArgs args)
        {
            return ((Rz5.PermitLogic)context.xSys.ThePermitLogic).CanBeViewedByCompany((ContextRz)context, this, context.xUser);
        }
        public override bool CanBeEditedBy(ContextNM context, ShowArgs args)
        {
            return ((Rz5.PermitLogic)context.xSys.ThePermitLogic).CanBeEditedByCompany((ContextRz)context, this, context.xUser);
        }
        //Public Functions
        public void CheckCompanyColor(ContextRz context)
        {
            Int32 color = 0;
            switch (company_criteria.ToLower().Trim())
            {
                case "1":
                case "2":
                case "3":
                    break;
                default:
                    grid_color = color;
                    context.Update(this);
                    return;
            }
            if (this.lastcontactdate == Tools.Dates.GetNullDate())
                color = 2;
            else
            {
                TimeSpan ts = DateTime.Now.Subtract(this.lastcontactdate);
                switch (company_criteria.ToLower().Trim())
                {
                    case "1":
                        //1- 1 wk (changed = red)
                        if (ts.Days > 7)
                            color = 2;
                        break;
                    case "2":
                        //2- 2 wks (changed = red)
                        if (ts.Days > 14)
                            color = 2;
                        break;
                    case "3":
                        //3- 1 mnth (changed = red)
                        if (ts.Days > 30)
                            color = 2;
                        break;
                    default:
                        return;
                }
            }
            grid_color = color;
            context.Update(this);
        }
        public void PrintCreditRequestForm(ContextRz context)
        {
            try
            {
                ordhed o = new ordhed();
                o.companyname = companyname;
                o.contactname = primarycontact;
                o.primaryphone = primaryphone;
                o.primaryfax = primaryfax;
                o.primaryemailaddress = primaryemailaddress;
                o.base_company_uid = unique_id;
                o.base_mc_user_uid = base_mc_user_uid;
                o.agentname = agentname;
                o.OrderType = Enums.OrderType.Invoice;
                o.Print(context);
            }
            catch
            {
            }
        }
        public bool CurrentAgentCanAssign(ContextRz context)
        {
            if (context.xUser.CheckPermit(context, "System:Edit:Can Assign All Companies"))
                return true;
            if (Tools.Strings.StrCmp(context.xUser.unique_id, base_mc_user_uid))
                return true;
            NewMethod.n_user yUser = UserObjectGet(context);
            if (yUser != null)
            {
                if (yUser.GetSetting_Boolean(context, "ishouseaccount"))
                    return true;
            }
            return false;
        }
        public companycontact GetContactByName(ContextRz context, String strName)
        {
            return (companycontact)context.QtO("companycontact", "select * from companycontact where base_company_uid = '" + this.unique_id + "' and contactname = '" + context.Filter(strName) + "'");
        }
        public ArrayList GetAllContacts(ContextRz context)
        {
            return context.QtC("companycontact", "select * from companycontact where base_company_uid = '" + unique_id + "' order by contactname");
        }
        public bool ShowPastDue(ContextRz context)
        {
            context.TheLeader.Tell("The company '" + companyname + "' has been marked 'Past Due', and cannot be added to a new order.");
            return false;
        }
        public void ShowNewNote(ContextRz context)
        {
            context.xSys.SendNote(context, this);
        }
        public usernote AddNote(ContextRz context)
        {
            usernote xNote = usernote.New(context);
            xNote.base_company_uid = unique_id;
            xNote.CreateObjectLink(context, this, this.ToString());
            context.Insert(xNote);
            return xNote;
        }
        public checkpayment AddTransaction(ContextRz context)
        {
            checkpayment c = checkpayment.New(context);
            c.base_company_uid = this.unique_id;
            c.transdate = System.DateTime.Now;
            context.Insert(c);
            return c;
        }
        public checkpayment ShowNewTransaction(ContextRz context)
        {
            checkpayment c = AddTransaction(context);
            context.Show(c);
            return c;
        }
        public companycontact AddContact(ContextRz context)
        {
            return context.TheSysRz.TheCompanyLogic.AddContact(context, this);
        }
        public companycontact ShowNewContact(ContextRz x)
        {
            companycontact c = AddContact(x);
            x.Show(c);
            //context.Show(c);
            return c;
        }
        public shippingaccount AddShippingAccount(ContextRz context)
        {
            shippingaccount c = shippingaccount.New(context);
            c.base_company_uid = this.unique_id;
            context.Insert(c);
            return c;
        }
        public shippingaccount ShowNewShippingAccount(ContextRz x)
        {
            shippingaccount a = AddShippingAccount(x);
            x.Show(a);
            return a;
        }
        public contactnote AddNewNote(ContextNM x)
        {
            contactnote c = contactnote.New(x);
            c.base_company_uid = this.unique_id;
            c.companyname = this.companyname;
            c.agentname = x.xUser.name;
            c.base_mc_user_uid = x.xUser.unique_id;
            c.notedate = DateTime.Now;
            x.Insert(c);
            return c;
        }
        public contactnote ShowNewNote(ContextNM x)
        {
            contactnote n = AddNewNote(x);
            x.Show(n);
            return n;
        }
        public calllog AddCallLog(ContextNM x)
        {
            calllog c = calllog.New(x);
            c.base_company_uid = this.unique_id;
            c.callcompanyname = this.companyname;
            c.agentname = x.xUser.name;
            c.base_mc_user_uid = x.xUser.unique_id;
            c.calldate = DateTime.Now.ToString();
            c.callorder = x.SelectScalarInt64("select count(*) from calllog where base_company_uid = '" + this.unique_id + "'") + 1;
            x.Insert(c);
            return c;
        }
        public calllog ShowNewCallLog(ContextNM x)
        {
            calllog n = AddCallLog(x);
            x.Show(n);
            return n;
        }
        public feedback AddFeedback(ContextNM x)
        {
            feedback c = feedback.New(x);
            c.the_company_uid = this.unique_id;
            c.companyname = this.companyname;
            c.agentname = x.xUser.name;
            c.the_n_user_uid = x.xUser.unique_id;
            c.date_created = DateTime.Now;
            x.Insert(c);
            return c;
        }
        public feedback ShowNewFeedback(ContextNM x)
        {
            feedback n = AddFeedback(x);
            x.Show(n);
            return n;
        }
        public dealheader ShowNewOrderBatch(ContextRz context)
        {
            dealheader d = OrderBatchAdd(context);
            if (d == null)
                return null;
            context.Show(d);
            return d;
        }


        //Get company_terms_conditions by id
        public company_terms_conditions GetExistingCompanyTC(ContextRz context)
        {
            return (company_terms_conditions)context.QtO("company_terms_conditions", "select * from company_terms_conditions where company_uid = '" + this.unique_id + "'");
        }

        //add new terms conditions
        public company_terms_conditions AddNewCompanyTC(ContextNM x)
        {
            company_terms_conditions c = company_terms_conditions.New(x);
            c.company_uid = this.unique_id;
            c.companyname = this.companyname;
            c.date_created = DateTime.Now;
            c.date_modified = DateTime.Now;
            x.Insert(c);
            return c;
        }


        public void FeedbackCalc(ContextNM context)
        {
            feedback_positive = context.SelectScalarInt32("select count(unique_id) from feedback where the_company_uid = '" + unique_id + "' and feedback_type = 'Positive'");
            feedback_neutral = context.SelectScalarInt32("select count(unique_id) from feedback where the_company_uid = '" + unique_id + "' and feedback_type = 'Neutral'");
            feedback_negative = context.SelectScalarInt32("select count(unique_id) from feedback where the_company_uid = '" + unique_id + "' and feedback_type = 'Negative'");

            feedback_rating = 0;
            try
            {
                feedback_rating = Tools.Number.CalcPercent(feedback_positive + feedback_negative, feedback_positive);

                //if (feedback_positive <= 0)
                //    return;
                //if (feedback_negative <= 0)
                //{
                //    feedback_rating = 100;
                //    return;
                //}
                //if (negative >= positive)
                //{
                //    feedback_rating = 100;
                //    return;
                //}
                //double per = ((double)negative / (double)positive);
                //feedback_rating = (Int32)((Double)per * (Double)100);
                //feedback_rating = 100 - feedback_rating;
            }
            catch (Exception)
            { }
        }
        public void Paste(String data, Enums.Website site)
        {
            try
            {
                String[] hold = Tools.Strings.Split(data, "\r\n");
                switch (site)
                {
                    case Enums.Website.BrokerForum:
                        PasteFromBF(hold);
                        break;
                    case Enums.Website.PartsBase:
                        PasteFromPB(hold);
                        break;
                }
            }
            catch (Exception)
            {
            }
        }
        public void MergeWith(ContextRz context, ArrayList companies)
        {
            MergeWith(context, nTools.GetIDString(companies));
        }
        public void MergeWith(ContextRz context, String company_ids)
        {
            if (Tools.Strings.HasString(company_ids.Replace(" ", ""), "''"))
                throw new Exception("Blank unique IDs cannot be consolidated.");

            context.Execute("alter table companycontact add companyid varchar(50)", true);
            context.Execute("alter table companyaddress add companyid varchar(50)", true);
            context.Execute("alter table shippingaccount add companyid varchar(50)", true);
            context.Execute("alter table calllog add companyid varchar(50)", true);
            context.Execute("alter table contactnote add companyid varchar(50)", true);
            context.Execute("alter table req add companyid varchar(50)", true);
            context.Execute("alter table quote add companyid varchar(50)", true);
            context.Execute("alter table dealheader add companyid varchar(50)", true);
            context.Execute("alter table dealcompany add companyid varchar(50)", true);
            context.Execute("alter table ordhed add companyid varchar(50)", true);
            context.Execute("alter table filelink add companyid varchar(50)", true);
            context.Execute("alter table orddet_quote add companyid varchar(50)", true);
            context.Execute("alter table orddet_rfq add companyid varchar(50)", true);
            context.Execute("alter table feedback add companyid varchar(50)", true);
           
            String strSQL = "";
            //contacts
            context.TheLeader.Comment("Merging contacts...");
            strSQL = "update companycontact set base_company_uid = '" + unique_id + "', companyname = '" + context.Filter(companyname) + "' where companyid in (" + company_ids + ") or base_company_uid in (" + company_ids + ") ";
            context.Execute(strSQL);
            //addresses
            context.TheLeader.Comment("Merging addresses...");
            strSQL = "update companyaddress set base_company_uid = '" + unique_id + "' where companyid in (" + company_ids + ") or base_company_uid in (" + company_ids + ") ";
            context.Execute(strSQL);
            //shippingaccount
            context.TheLeader.Comment("Merging shipping accounts...");
            strSQL = "update shippingaccount set base_company_uid = '" + unique_id + "' where companyid in (" + company_ids + ") or base_company_uid in (" + company_ids + ") ";
            context.Execute(strSQL);
            //call logs
            context.TheLeader.Comment("Merging call logs...");
            strSQL = "update calllog set base_company_uid = '" + unique_id + "', callcompanyname = '" + context.Filter(companyname) + "' where companyid in (" + company_ids + ") or base_company_uid in (" + company_ids + ") ";
            context.Execute(strSQL);
            //contact notes
            context.TheLeader.Comment("Merging contact notes...");
            strSQL = "update contactnote set base_company_uid = '" + unique_id + "', companyname = '" + context.Filter(companyname) + "' where companyid in (" + company_ids + ") or base_company_uid in (" + company_ids + ") ";
            context.Execute(strSQL);
            //reqs
            context.TheLeader.Comment("Merging reqs...");
            strSQL = "update req set base_company_uid = '" + unique_id + "', companyname = '" + context.Filter(companyname) + "' where companyid in (" + company_ids + ") or base_company_uid in (" + company_ids + ") ";
            context.Execute(strSQL);
            //quotes
            context.TheLeader.Comment("Merging quotes...");
            strSQL = "update quote set base_company_uid = '" + unique_id + "', companyname = '" + context.Filter(companyname) + "' where companyid in (" + company_ids + ") or base_company_uid in (" + company_ids + ") ";
            context.Execute(strSQL);
            //dealheader
            context.TheLeader.Comment("Merging order batches...");
            strSQL = "update dealheader set customer_uid = '" + unique_id + "', customer_name = '" + context.Filter(companyname) + "' where companyid in (" + company_ids + ") or customer_uid in (" + company_ids + ") ";
            context.Execute(strSQL);
            //dealcompany
            strSQL = "update dealcompany set the_company_uid = '" + unique_id + "', companyname = '" + context.Filter(companyname) + "' where companyid in (" + company_ids + ") or the_company_uid in (" + company_ids + ") ";
            context.Execute(strSQL);
            //ordddet_quote
            context.TheLeader.Comment("Merging reqs/quotes/rfqs...");
            strSQL = "update orddet_quote set base_company_uid = '" + unique_id + "', companyname = '" + context.Filter(companyname) + "' where companyid in (" + company_ids + ") or base_company_uid in (" + company_ids + ") ";
            context.Execute(strSQL);
            //ordddet_rfq
            strSQL = "update orddet_rfq set base_company_uid = '" + unique_id + "', companyname = '" + context.Filter(companyname) + "' where companyid in (" + company_ids + ") or base_company_uid in (" + company_ids + ") ";
            context.Execute(strSQL);
            //feedback
            context.TheLeader.Comment("Merging feedback...");
            strSQL = "update feedback set the_company_uid = '" + unique_id + "', companyname = '" + context.Filter(companyname) + "' where companyid in (" + company_ids + ") or the_company_uid in (" + company_ids + ") ";
            context.Execute(strSQL);
            //orders
            context.TheLeader.Comment("Merging orders...");
            String mergeSQL = "update <order table> set base_company_uid = '" + unique_id + "', companyname = '" + context.Filter(companyname) + "' where base_company_uid in (" + company_ids + ") ";
            ordhed.RunSQLOnOrderTables(context, mergeSQL);
            ////Customer line items
            //context.TheLeader.Comment("Merging customer line items...");
            //strSQL = "update orddet_line set customer_uid = '" + unique_id + "', cusotmer_name = '" + context.Filter(companyname) + "' where customer_uid in (" + company_ids + ") ";
            //context.Execute(strSQL);

            ////Vendor line items
            //context.TheLeader.Comment("Merging vendor line items...");
            //strSQL = "update orddet_line set vendor_uid = '" + unique_id + "', vendor_name = '" + context.Filter(companyname) + "' where vendor_uid in (" + company_ids + ") ";
            //context.Execute(strSQL);

            //filelinks
            context.TheLeader.Comment("Merging documents...");
            strSQL = "update filelink set objectid = '" + unique_id + "' where companyid in (" + company_ids + ") or objectid in (" + company_ids + ") ";
            context.Execute(strSQL);
            //deletes
            context.TheLeader.Comment("Deleting...");
            strSQL = "delete from company where unique_id in (" + company_ids + ")";
            context.Execute(strSQL);
            context.TheLeader.Comment("Done.");
            context.TheLeader.Tell("Done.");
        }
        public companyaddress GetFirstAddress(ContextRz context)
        {
            return (companyaddress)context.QtO("companyaddress", "select top 1 * from companyaddress where base_company_uid = '" + unique_id + "'");
        }
        public companyaddress AddAddress(ContextRz context)
        {
            companyaddress c = companyaddress.New(context);
            c.base_company_uid = this.unique_id;
            context.Insert(c);
            return c;
        }
        public companyaddress ShowNewAddress(ContextRz context)
        {
            companyaddress c = AddAddress(context);
            context.Show(c);
            return c;
        }
        public ordhed AddOrder(ContextRz context, Enums.OrderType type)
        {
            ordhed o = ordhed.CreateNew(context, type);
            o.AbsorbCompany(context, this);
            context.Update(o);
            return o;
        }
        public ordhed ShowNewOrder(ContextRz x, Enums.OrderType type)
        {
            ordhed o = AddOrder(x, type);
            x.Show(o);
            //context.Show(o);
            return o;
        }
        public String GetPrimaryBillingAddressString(ContextRz context)
        {
            companyaddress addy = GetPrimaryBillingAddress(context);
            if (addy == null)
                return "";
            else
                return addy.GetAddressString(context);
        }
        public companyaddress GetPrimaryBillingAddress(ContextRz context)
        {
            return GetPrimaryAddress(context, "Billing");
        }
        public String GetPrimaryShippingAddressString(ContextRz context)
        {
            companyaddress addy = GetPrimaryShippingAddress(context);
            if (addy == null)
                return "";
            else
                return addy.GetAddressString(context);
        }
        public companyaddress GetPrimaryShippingAddress(ContextRz context)
        {
            return GetPrimaryAddress(context, "Shipping");
        }
        public companyaddress GetPrimaryAddress(ContextRz context, String strType)
        {
            //return (companyaddress)context.QtO("companyaddress", "SELECT * FROM companyaddress WHERE base_company_uid = '" + unique_id + "' AND DESCRIPTION LIKE '%" + strType + "%'");
            //KT usign a string variable to switch between shipping / billinbg basen on the strType parameter
            //return (companyaddress)context.QtO("companyaddress", "SELECT * FROM companyaddress WHERE base_company_uid = '" + unique_id + "' AND defaultbilling = 1");
            return (companyaddress)context.QtO("companyaddress", "SELECT * FROM companyaddress WHERE base_company_uid = '" + unique_id + "' AND default" + strType.ToLower() + " = 1");
        }
        public partrecord AddPart(ContextRz context, Enums.StockType type)
        {
            partrecord p = partrecord.New(context);
            p.stocktype = type.ToString();
            p.base_company_uid = unique_id;
            p.companyname = companyname;
            p.vendorid = unique_id;
            p.vendorname = companyname;
            context.Insert(p);
            return p;
        }
        public partrecord ShowNewPart(ContextRz context, Enums.StockType type)
        {
            partrecord p = AddPart(context, type);
            context.Show(p);
            return p;
        }
        public void PopQB()
        {
            throw new NotImplementedException("Company.PopQB");
            //PopQBInfo(companyname, primarycontact, primaryphone, primaryfax, primaryemailaddress)
        }
        public void PickQBCompany(System.Windows.Forms.IWin32Window owner)
        {
            throw new NotImplementedException("Company.PickQBCompany");
            //frmqbcompany xForm;
            //String strID;
            //iaction xAction;
            //if( OwnerForm = null )
            //{
            //    xForm.Show vbModal, frmRecogniz
            //    else
            //    xForm.Show vbModal, OwnerForm
            //}
            //strID = xForm.qbid
            //if( Tools.Strings.StrExt(strID) )
            //{
            //    xAction.strSQL = "select * from ctg_qb where uniqueid = '" + strID + "'"
            //    xAction.GetRecordset
            //    xRz2.SpotUpdate(this, "QB_NAME", nTools.RecFilter(xAction.rst.Fields("companyname").Value))
            //    xRz2.SpotUpdate(this, "QB_TERMS", nTools.RecFilter(xAction.rst.Fields("terms").Value))
            //    xRz2.SpotUpdate(this, "QB_BILLING", nTools.RecFilter(xAction.rst.Fields("billingaddress").Value))
            //    xRz2.SpotUpdate(this, "QB_SHIPPING", nTools.RecFilter(xAction.rst.Fields("shippingaddress").Value))
            //}
            //Unload xForm
            //xForm= null
        }
        public void RequestQBName()
        {
            throw new NotImplementedException("Company.RequestQBName");
            //NotifyAccounting(this, companyname, "QuickBooks Name Request")
            //xRz2.MessageBoxTemp "Sent", "This request has been sent."
        }
        public bool ShowCompanyToQbForm(ContextRz context, Enums.CompanySelectionType t, company c, string shippingaddress, string billingaddress)
        {
            string strCompanyName = "";
            return context.TheLeaderRz.ShowAddQBCompany(c,ref strCompanyName, Enums.CompanySelectionType.Customer, shippingaddress, billingaddress);
            //try
            //{
            //    if (t == Enums.CompanySelectionType.Customer)
            //    {
            //        context.TheSysRz.TheQuickBooksLogic.MakeCustomerExist(context, this);
            //    }
            //    else
            //    {
            //        context.TheSysRz.TheQuickBooksLogic.MakeVendorExist(context, this);
            //    }
            //    return true;
            //}
            //catch
            //{
            //    return false;
            //}
        }
        public void ShowBatchConsolidate(ArrayList colCompanies)
        {
            throw new NotImplementedException("Company.ShowBatchConsolidate");
            //frmconsolidatecompany xForm;
            //xForm.colCompanies= colCompanies
            //xForm.CompleteStructure()
            //xForm.CompleteLoad()
            //xForm.Show vbModal
        }
        public String UserID
        {
            get
            {
                return base_mc_user_uid;
            }
            set
            {
                base_mc_user_uid = value;
            }
        }
        public String UserName
        {
            get
            {
                return agentname;
            }
            set
            {
                agentname = value;
            }
        }
        public n_user UserObjectGet(ContextRz context)
        {
            return n_user.GetById(context, base_mc_user_uid);
        }
        public void UserObjectSet(n_user value)
        {
            if (value == null)
            {
                base_mc_user_uid = "";
                agentname = "";
            }
            else
            {
                base_mc_user_uid = value.unique_id;
                agentname = value.name;
            }
        }
        public void DoAction_Assign(ContextNM x)
        {
            ArrayList a = new ArrayList();
            a.Add(this);
            Assign(x, a);
        }
        public void DoAction_ScanViewDocuments(ActArgs args)
        {
            args.TheContext.TheLeader.Error("reorg");
            ////s.CompleteLoad(Rz3App.xSys, o);
            //DocumentScanner s = new DocumentScanner();
            //Rz3App.xMainForm.TabShow(s, "Documents On " + GetFriendlyName());
            ////System.Windows.Forms.TabPage t = Rz3App.xMainForm.ShowGenericTabControl(s);
            ////t.Text = "Documents On " + GetFriendlyName();
            //s.CompleteLoad(this);
        }
        public void DoAction_RequestQBName(ActArgs args)
        {
            throw new NotImplementedException("Company.RequestQBName");
        }
        public void DoAction_QuickBooks(ActArgs args)
        {
            throw new NotImplementedException("Company.QuickBooks");
        }
        public void DoAction_Transactions(ActArgs args)
        {
            args.TheContext.TheLeader.Error("reorg");
            //xSys.ThrowObjectList("checkpayment", "base_company_uid = '" + unique_id + "'", "transdate", "transactions", 100, "Transactions");
        }
        public void DoAction_ViewHistory(ActArgs args)
        {
            args.TheContext.TheLeader.Error("reorg");
            //xSys.ThrowObjectList("companyhistory", "base_company_uid = '" + unique_id + "'", "HISTORYDATE", "ShowHistory", 100, "History");
        }
        public void DoAction_SendEmail(ContextRz context, ActArgs args)
        {
            ActuallySendEmail(context, args);
        }
        protected virtual void ActuallySendEmail(ContextRz context, ActArgs args)
        {
            //if (nTools.IsEmailAddress(primaryemailaddress))
            //{
            //    String err = "";
            //    String emails = GetEmailAddressString(context);
            //    context.TheSysRz.TheEmailLogic.SendOutlookEmail("", "", "I-Net", false, true, null, "", false, null, null, null, null, null, false, ref err);

            //    //ToolsOffice.OutlookOffice.SendOutlookMessage(emails, "", "", false, true, "", "", false, null, "", "", "", context.xUser.email_signature, ref err);
            //}
            //else
            //    context.TheLeader.Tell("'" + primaryemailaddress + "' does not appear to be a valid e-mail address.");
        }

        //KT Refactored from RzSensible
        protected virtual void GetIndustrySegmentChoice(ContextRz context, List<IItem> a)
        {
            try
            {
                if (a == null)
                    return;
                if (a.Count <= 0)
                    return;
                string choice = ((ILeaderRz)context.Leader).ChooseIndustrySection(context);
                if (!Tools.Strings.StrExt(choice))
                    return;
                foreach (company c in a)
                {
                    c.industry_segment = choice;
                    c.Insert(context);
                }
                context.Leader.Tell("Done.");
            }
            catch { }
        }
        //KT Refactored from RzSensible
        public static void SetIndustrySegment(ContextRz context, List<IItem> a)
        {
            try
            {
                if (a == null)
                    return;
                if (a.Count <= 0)
                    return;
                company comp = (company)a[0];
                if (comp == null)
                    return;
                comp.GetIndustrySegmentChoice(context, a);
            }
            catch { }
        }






        public void SendEmail(ContextRz context)
        {
            SendEmail(context, false);
        }
        public void SendEmail(ContextRz context, Boolean bChooseTemplate)
        {
            context.Reorg();
            //if(!nTools.IsEmailAddress(primaryemailaddress))
            //{
            //    context.TheLeader.Tell("'" + primaryemailaddress + "' does not appear to be a valid e-mail address.");
            //    return;
            //}
            //if(!bChooseTemplate)
            //{
            //    String err = "";
            //    ToolsOffice.OutlookOffice.SendOutlookMessage(primaryemailaddress, "", "", false, true, "", "", false, null, "", "", "", context.xUser.email_signature, ref err);
            //    return;
            //}
            //String strSubject = "";
            //frmChooseEmailTemplate xForm = new frmChooseEmailTemplate();
            //xForm.CompleteLoad(this);
            //xForm.ShowDialog(RzApp.xMainForm);
            //emailtemplate xTemplate = xForm.SelectedTemplate;
            //if( xTemplate == null )
            //    return;
            //String strAll = xTemplate.emailbody + xTemplate.emailfooter;
            //strAll = this.AssociateWithHTML(strAll);
            //strAll = context.xUser.AssociateWithHTML(strAll);
            //strSubject = xTemplate.subjectstring;
            //strSubject = this.AssociateWithHTML(strSubject);
            //strSubject = context.xUser.AssociateWithHTML(strSubject);
            //String err2 = "";
            //ToolsOffice.OutlookOffice.SendOutlookMessage(primaryemailaddress, strAll, strSubject, false, true, "", xTemplate.AttachmentFileString, false, null, "", "", "", context.xUser.email_signature, ref err2);
        }
        public void FlagExcessAsArchivable(ContextRz context)
        {
            String SQL = "update partrecord set is_archivable = 1 where base_company_uid = '" + unique_id + "'";
            context.Execute(SQL);
        }
        //Private Functions
        private string GetEmailAddressString(ContextRz context)
        {
            context.Reorg();
            return "";

            //string s = primaryemailaddress.Trim();
            //try
            //{
            //    ArrayList a = frmChooseContact_Multiple.Choose(this, RzApp.xMainForm, true);
            //    foreach (string ss in a)
            //    {
            //        if (!Tools.Strings.StrExt(s))
            //            s = ss;
            //        else
            //            s += ";" + ss;
            //    }
            //}
            //catch { }
            //return s;
        }
        private void PasteFromBF(String[] data)
        {
            try
            {
                for (Int32 i = 0; i < data.Length; i++)
                {
                    String line = data[i].Trim();
                    if (line.StartsWith("Address:"))
                    {
                        String info = line;
                        info = Tools.Strings.ParseDelimit(info, " Phone:", 2);
                        primaryphone = Tools.Strings.ParseDelimit(info, " Fax:", 1).Trim();
                        info = Tools.Strings.ParseDelimit(info, " Fax:", 2);
                        primaryfax = Tools.Strings.ParseDelimit(info, " Web Site:", 1).Trim();
                        info = Tools.Strings.ParseDelimit(info, " Web Site:", 2).Trim().ToLower();
                        primarywebaddress = Tools.Strings.ParseDelimit(info, ".com", 1).Trim() + ".com";
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        private void PasteFromPB(String[] data)
        {
            try
            {
                String phone = "";
                String email = "";
                foreach (String s in data)
                {
                    if (s.StartsWith("Phone:"))
                    {
                        phone = s;
                        continue;
                    }
                    if (s.StartsWith("Email:"))
                    {
                        email = s;
                        continue;
                    }
                }
                if (Tools.Strings.StrExt(phone))
                {
                    primaryphone = Tools.Strings.ParseDelimit(phone, " Fax:", 1).Replace("Phone:", "").Trim();
                    primaryfax = Tools.Strings.ParseDelimit(phone, " Fax:", 2).Trim();
                }
                if (Tools.Strings.StrExt(email))
                {
                    primaryemailaddress = Tools.Strings.ParseDelimit(email, " Web Address:", 1).Replace("Email:", "").Trim();
                    primarywebaddress = Tools.Strings.ParseDelimit(email, " Web Address:", 2).Trim();
                }
            }
            catch (Exception)
            {
            }
        }
        public static void CheckDnB(ContextRz context, String strCompanyName, String strState)
        {
            context.Reorg();

            //TabPageCore t = RzApp.xMainForm.TabGetByID("www.dnbi.com");
            //Browser b = null;
            //if(t == null)
            //{
            //    b = new Browser();
            //    b.ShowControls = true;
            //    RzApp.xMainForm.TabShow(b, "www.dnbi.com");
            //    TabPageCore th = RzApp.xMainForm.TabGetByID("www.dnbi.com");
            //    if( th != null )
            //        t = th;
            //}
            //else
            //{
            //    b = (Browser)t.TheControl;
            //}
            //RzApp.xMainForm.TabCheckShow("www.dnbi.com");
            //b.Navigate("https://www.dnbi.com/dnbi/companies/showCompanyHome");
            //b.WaitForDone();
            //if( !b.SetTextBox("quickSearchFld", strCompanyName) )
            //    return;
            //b.SetTextBox("companyQSState", strState);
            //b.ClickElement("input", "", "Search", "", "", false);
            ////String strStateClause = "";
            ////if( Tools.Strings.StrExt(strState) && strState.Length == 2)
            ////    strStateClause = "&state=" + strState;
            ////ToolsWin.WebWin.BrowseWebAddress("http://smallbusiness.dnb.com/webapp/wcs/stores/servlet/IballValidationCmd?storeId=10001&catalogId=70001&productId=0&searchType=BSF" + strStateClause + "&hiddenSessionId=-1028517250&busName=" + nTools.Replace(strCompanyName, " ", "+") + "&city=&country=US&x=15&y=8#goTop");
        }
        public dealheader OrderBatchAdd(ContextRz context)
        {
            dealheader d = dealheader.New(context);
            d.is_portal_generated = false;
            d.customer_name = this.companyname;
            d.customer_uid = this.unique_id;
            context.Insert(d);
            d.Init(context);
            return d;
        }
        public static bool ChangeCompanyName(ContextRz context, company CurrentCompany, ref String s)
        {
            s = context.TheLeader.AskForString("Please enter the new company name:", CurrentCompany.companyname, "New Company Name");
            if (!Tools.Strings.StrExt(s))
                return false;
            if (s == CurrentCompany.companyname)
                return false;
            //String d = company.DistillCompanyName(s);
            String d = s;
            if (d.Length <= 2)
            {
                if (!context.TheLeader.AreYouSure("make this company's name so short"))
                    return false;
            }
            company c = (company)context.QtO("company", "select * from company where unique_id <> '" + CurrentCompany.unique_id + "' and (companyname = '" + context.Filter(s) + "' or distilledname = '" + context.Filter(d) + "')");
            if (c != null)
            {
                context.TheLeader.Tell("At least 1 other company (" + c.companyname + ") already has a name that is too similar to '" + s + "'");
                return false;
            }

            CurrentCompany.companyname = s;
            context.Update(CurrentCompany);
            return company.ChangeCompanyNameFields(context, CurrentCompany, s);
        }
        public static bool ChangeCompanyNameFields(ContextRz context, company CurrentCompany, String s)
        {
            context.TheLeader.Comment("Updating...");
            context.Execute("update companycontact set companyname = '" + context.Filter(s) + "' where base_company_uid = '" + CurrentCompany.unique_id + "'");
            foreach (String so in ordhed.GetOrderTableNames())
            {
                context.Execute("update " + so + " set companyname = '" + context.Filter(s) + "' where base_company_uid = '" + CurrentCompany.unique_id + "'");
            }
            context.Execute("update orddet_quote set companyname = '" + context.Filter(s) + "' where base_company_uid = '" + CurrentCompany.unique_id + "'");
            context.Execute("update orddet_rfq set companyname = '" + context.Filter(s) + "' where base_company_uid = '" + CurrentCompany.unique_id + "'");
            context.Execute("update orddet_line set customer_name = '" + context.Filter(s) + "' where customer_uid = '" + CurrentCompany.unique_id + "'");
            context.Execute("update orddet_line set vendor_name = '" + context.Filter(s) + "' where vendor_uid = '" + CurrentCompany.unique_id + "'");
            context.Execute("update orddet_line set service_vendor_name = '" + context.Filter(s) + "' where service_vendor_uid = '" + CurrentCompany.unique_id + "'");
            return true;
        }
        public virtual bool SendEmailTemplate(ContextRz context)
        {
            ArrayList emails = GetPossibleEmailAddresses(context);
            if (emails.Count == 0)
            {
                context.TheLeader.Tell("Please enter at least one email address for this company.");
                return false;
            }
            ArrayList sel = context.Leader.ChooseFromArray(context, emails, "Address selection");
            if (sel == null)
                return false;

            if (sel.Count == 0)
                return false;

            emailtemplate t = context.Leader.AskForEmailTemplate(this);
            if (t == null)
                return false;

            String strHtml = t.GetBodyHtml(this);
            String last_po = "";
            strHtml = ConditionEmailTemplateHtml(context, strHtml, ref last_po);

            String to = (String)sel[0];
            sel.Remove(to);

            String strSubject = t.GetSubjectHtml(this).Replace("<LastPONumber>", last_po);
            String err = "";
            //context.TheSysRz.TheEmailLogic.SendOutlookEmail(to, strHtml, strSubject, false, true, "", "", false, null, "", "", "", "",true, ref err);
            context.TheSysRz.TheEmailLogic.SendEmail(context, new List<string>() { to }, strHtml, strSubject, false, true, null, null, null, true, null, null, true, ref err);

            //ToolsOffice.OutlookOffice.SendOutlookMessage(to, strHtml, strSubject, false, true, "", "", false, sel, "", "", "", "", ref err);

            //contactnote cn = new contactnote(Rz3App.xSys);
            contactnote cn = CreateNewContactNote(context);
            cn.notedate = DateTime.Now;
            cn.agentname = context.xUser.name;
            cn.base_mc_user_uid = context.xUser.unique_id;

            cn.notetext = "Sent Email: " + strSubject + "\r\n\r\n\r\n" + Tools.Html.ConvertHTMLToText_Quick(strHtml);
            cn.Update(context);

            return true;
        }
        public contactnote CreateNewContactNote(ContextRz context)
        {
            contactnote ret = contactnote.New(context);
            ret.base_company_uid = this.unique_id;
            ret.companyname = this.companyname;
            last_activity_date = DateTime.Now;
            Update(context);
            context.Insert(ret);
            return ret;
        }
        public virtual String ConditionEmailTemplateHtml(ContextRz context, String strHtml, ref String last_po)
        {
            return strHtml;
        }
        public ArrayList GetPossibleEmailAddresses(ContextRz context)
        {
            ArrayList ret = new ArrayList();

            if (nTools.IsEmailAddress(primaryemailaddress))
                ret.Add(primaryemailaddress);

            ArrayList c = context.SelectScalarArray("select distinct(primaryemailaddress) from companycontact where base_company_uid = '" + this.unique_id + "' and primaryemailaddress like '%@%.%' order by primaryemailaddress");
            foreach (String s in c)
            {
                if (nTools.IsEmailAddress(s))
                {
                    if (!ret.Contains(s))
                        ret.Add(s);
                }
            }

            return ret;
        }
        //public static void SetLastActivity(String companyid, DateTime date)
        //{
        //    if( !Tools.Strings.StrExt(companyid) )
        //        return;

        //    if (!Rz3App.xLogic.IsConcord)
        //        return;

        //    DateTime d = Rz3App.xSys.xData.GetScalar_Date("select last_activity_date from company where unique_id = '" + companyid + "'");
        //    if( d < date )
        //    {
        //        company c = company.GetByID(Rz3App.xSys, companyid);
        //        if( c == null )
        //            return;

        //        c.last_activity_date = date;
        //        c.IUpdate();
        //    }
        //}
        public static ListArgs SearchArgsGet(ContextRz context, String search)
        {
            ListArgs ret = new ListArgs(context);
            ret.TheTable = "company";
            ret.TheClass = "company";
            ret.TheCaption = "Companies";
            ret.AddAllow = true;
            ret.AddCaption = "Add A New Company";
            ret.OptionsAllow = true;
            ret.TheLimit = 200;
            ret.TheTemplate = "Company Search";

            String match = " like '%" + context.Filter(search) + "%'";
            ret.TheWhere = " ( companyname " + match + " or primaryphone " + match + " or primaryfax " + match + " or primaryemailaddress " + match + " or exists( select unique_id from companycontact x where x.base_company_uid = company.unique_id and ( x.contactname " + match + " or x.primaryphone " + match + " or primaryfax " + match + " or primaryemailaddress " + match + " ) ) )";

            return ret;
        }
        public ArrayList VendorContactsGet(ContextRz x)
        {
            return x.QtC("companycontact", "select * from companycontact where base_company_uid = '" + unique_id + "' and contact_function like 'Vendor%' order by contact_function");
        }
        public virtual void LineCardEdit(ContextRz context)
        {
            context.Reorg();
            //Win.Dialogs.LineCardEditor editor = new Win.Dialogs.LineCardEditor();
            //editor.Init(this);
            //editor.ShowDialog();
        }
        public companycontact ContactGetByName(ContextNM context, String contactname)
        {
            return (Rz5.companycontact)context.QtO("companycontact", "select * from companycontact where base_company_uid = '" + this.unique_id + "' and contactname = '" + context.Filter(contactname) + "'");
        }
        public companycontact ContactAdd(ContextNM context)
        {
            companycontact ret = companycontact.New(context);
            ret.base_company_uid = this.unique_id;
            ret.companyname = this.companyname;
            context.Insert(ret);
            return ret;
        }
        public companyaddress AddressGet(ContextNM context, String desc)
        {
            return (companyaddress)context.QtO("companyaddress", "select * from companyaddress where base_company_uid = '" + unique_id + "' and description like '" + context.Filter(desc) + "'");
        }
        public companyaddress AddressGetLike(ContextNM context, String desc)
        {
            return AddressGet(context, "%" + desc + "%");
        }
        public virtual bool VendorApprovedCheck(ContextRz context, ref string msg, bool supress_msg = false)
        {
            ////KT - Check if the vendor has been vetted.  This happened EVERY time you interact wit hthe vendor, this is not good.
            //if (!context.TheSysRz.TheCompanyLogic.CheckVetted(context, this))
            //{
            //    return false;
            //} 

            if (is_locked || islocked_purchase)
            {
                if (context.xUser.SuperUser)
                {
                    if (!supress_msg)
                        context.TheLeader.Tell("Please note that '" + companyname + "' has been marked as locked for purchasing.");
                }
                else
                {
                    if (!supress_msg)
                        context.TheLeader.Error("Please be aware that " + companyname + " has been marked as locked for purchasing.");
                    return false;
                }
            }
            //KT 11-8-2017 - Removing this, was excessing, just calling in order batch now.
            //if (problem_vendor)
            //{
            //    if (!supress_msg)
            //        context.TheLeader.Tell("Please be aware that " + companyname + " has been marked as a problem vendor, and check the company notes before completing this order.");
            //}
            if (Tools.Strings.StrCmp(companytype, "Service Vendor"))
            {
                if (!supress_msg)
                    context.TheLeader.Tell(companyname + " is marked as a Service Vendor.  To create a Service Order, please choose 'Send For Service' from an inventory or sale line item.");
                return false;
            }
            return true;
        }
        public virtual bool isServiceVendor(ContextRz context)
        {
            ////Any kind of lock
            //if (is_locked || islocked_purchase)
            //    return false;

            //Service Vendors are not automatically approved to buy product from?
            if (Tools.Strings.StrCmp(companytype, "Service Vendor"))
                return false;
            return true;
        }
        public virtual void ContactUpdate(companycontact c)
        {
            //apply common stuff from the company to the contact
            c.companyname = companyname;
            c.abs_type = abs_type;
            if (!Tools.Strings.StrExt(c.primaryphone))
                c.primaryphone = primaryphone;
            if (!Tools.Strings.StrExt(c.primaryfax))
                c.primaryfax = primaryfax;
            if (!Tools.Strings.StrExt(c.primaryemailaddress))
                ContactUpdatePrimaryEmail(c);
        }
        protected virtual void ContactUpdatePrimaryEmail(companycontact c)
        {
            if (c != null)
                c.primaryemailaddress = primaryemailaddress;
        }
        public void ContactsUpdateAll(ContextRz context)
        {
            foreach (companycontact c in ContactsVar.RefsList(context))
            {
                ContactUpdate(c);
                context.TheDelta.Update(context, c);
            }
        }

        public String DefaultCurrency(ContextRz context)
        {
            if (Tools.Strings.StrExt(default_currency))
                return default_currency;
            else
                return context.Accounts.BaseCurrency;
        }

        public void ApplyAdvancePaymentInTrans(ContextRz context, String memo, Double amount)
        {
            checkpayment cp = this.AddTransaction(context);
            cp.subtotal = amount;
            cp.TransactionType = Enums.TransactionType.Payment;
            cp.description = memo;
            cp.referencedata = "Advance Payment";
            cp.Update(context);

            balance_owed_customer -= amount;
            Update(context);

            JournalEntry e = new JournalEntry(memo);
            e.Add(context, context.Accounts.GetAccount(context, "Undeposited Funds"), amount, 0);
            e.Add(context, context.Accounts.GetAccount(context, "Advance Customer Payments"), 0, amount);
            e.Post(context);
        }

        public void ApplyVendorCreditInTrans(ContextRz context, String memo, Double amount, account cashAccount)
        {
            checkpayment cp = this.AddTransaction(context);
            cp.subtotal = amount;
            cp.TransactionType = Enums.TransactionType.Check;
            cp.description = memo;
            cp.referencedata = "Vendor Credit";
            cp.Update(context);
            balance_owed_vendor_Subtract(context, amount);
            JournalEntry e = new JournalEntry(memo);
            e.Add(context, context.Accounts.GetAccount(context, "Accounts Payable"), amount, 0);//"Vendor Credit Balances"
            e.Add(context, cashAccount, 0, amount);
            e.Post(context);
        }

        public void balance_owed_vendor_Add(ContextRz context, Double value)
        {
            balance_owed_vendor += value;
            TransValueUpdate(context, "balance_owed_vendor", TransValueUpdateOp.Add, value);
        }

        public void balance_owed_vendor_Subtract(ContextRz context, Double value)
        {
            balance_owed_vendor -= value;
            TransValueUpdate(context, "balance_owed_vendor", TransValueUpdateOp.Subtract, value);
        }

        public void balance_owed_customer_Add(ContextRz context, Double value)
        {
            balance_owed_customer += value;
            TransValueUpdate(context, "balance_owed_customer", TransValueUpdateOp.Add, value);
        }

        public void balance_owed_customer_Subtract(ContextRz context, Double value)
        {
            balance_owed_customer -= value;
            TransValueUpdate(context, "balance_owed_customer", TransValueUpdateOp.Subtract, value);
        }


        public static void ManageHubspotLinkage(ContextRz context, ArrayList objects)
        {
            company c = (company)objects[0];
            if (c == null)
                return;
            context.Leader.ManageHubspot(context, c);
        }
    }






    public interface ILinkedCompany
    {
        company CompanyObject { get; set; }
    }
    public class CompanyHandle
    {
        public String ID = "";
        public String Name = "";
        public CompanyHandle(String strID, String strName)
        {
            ID = strID;
            Name = strName;
        }
        public CompanyHandle(company c)
        {
            ID = c.unique_id;
            Name = c.companyname;
        }
    }
    public class PeopleSearchParameters
    {
        public String GeneralTerm = "";

        public String CompanyName = "";
        public String ContactName = "";
        public String PhoneFaxEmail = "";
        public String CompanyType = "";
        public bool IncludeBlankAgents = false;
        public String AgentNamePipeDelimited = "";  //Options.Agent
        public bool OnlyUnassigned = false;  //Options.OnlyUnassigned
        public String GroupName = "";  //Options.Group
        public String SourceName = "";  //Options.Source;
        public String CallSchedule = "";  //Options.CallSchedule
        public bool HasSales = false;  //Options.HasSales;
        public bool HasPurchases = false;   //Options.HasPurchases;
        public String OrderNumber = "";  //Options.OrderNumber;
        public DateTime OrderDate = Tools.Dates.GetNullDate();  //Options.OrderDate
        public String PartNumber = "";  //Options.PartNumber
        public String Address = "";  //Options.Address
        public bool ProspectAccounts = false;   //Options.ProspectAccounts
        public int ReqMin = 0;  //Options.ReqCount()
        public String MfgType = "";  //Options.MFGType
        public String ComType = "";
        public String Rank = "";  //Options.Rank
        public String TimeZone = "";  //Options.TimeZone;
        public ArrayList Filters = null;
        public bool OrderByDomain = false;
        public String CustomerStatus = "";
        public bool BadMailingAddress = false;
        public DateTime NotCalledSince = Tools.Dates.GetNullDate();
        public string Office = "";
        public bool Empty = false;
        public String CompanySubType = "";
        public String IndustrySegment = "";

        public String Phone = "";
        public String Fax = "";
        public String Email = "";

        public String AddrLines = "";
        public String City = "";
        public String State = "";
        public String Zip = "";
        public String Country = "";
        public string industry_segment = "";

        public PeopleSearchParameters()
        {
        }

        public PeopleSearchParameters(bool empty)
        {
            Empty = empty;
        }
    }

    public class VarRefContacts : VarRefMany<company, companycontact>
    {
        company TheCompany
        {
            get
            {
                return (company)Parent;
            }
        }

        public VarRefContacts(IItem parent, CoreVarAttribute attr)  //"base_company_uid"
            : base(parent, attr)
        {

        }

        public override void RefsAdd(Context x, IItems items, bool includeReverse)
        {
            base.RefsAdd(x, items, includeReverse);

            foreach (companycontact c in items.AllGet(x))
            {
                TheCompany.ContactUpdate(c);
                x.TheDelta.Update(x, c);
            }
        }
    }


    namespace Enums
    {
        public enum CompanySelectionType
        {
            Customer = 1,
            Vendor = 2,
            Both = 3
        }
    }

}