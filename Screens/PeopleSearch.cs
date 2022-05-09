
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Tools;
using Core;
using NewMethod;

namespace Rz5.Win.Screens
{

    public partial class PeopleSearch : SplitSearch, IPeopleSearch
    {
        public string CurrentClass = "";
        String TableToDelete = "";
        public PeopleSearch()
        {
            InitializeComponent();
        }
        public override void CompleteLoad()
        {
            //gbCustomer.Visible = false;
            lblNextCallList.Visible = false;
            lblGroupName.Text = "";
            optBoth.Visible = true;
            ctl_CompanyType.LoadList(true);
            base.CompleteLoad();
            SwitchCompany();
            DoResize();
        }
        ~PeopleSearch()
        {
            try
            {
            }
            catch { }
        }
        public override void DoResize()
        {
            try
            {
                try
                {
                    base.DoResize();
                }
                catch (Exception)
                {
                }
                pOptions.Left = 0;
                pOptions.Top = 0;
                pOptions.Height = this.ClientRectangle.Height;

                xDisplay.Left = pOptions.Right;
                xDisplay.Top = 0;
                xDisplay2.Left = pOptions.Width;
                xDisplay.Width = this.ClientRectangle.Width - pOptions.Width;
                xDisplay2.Width = xDisplay.Width;
                if (IsSplit)
                {
                    xDisplay2.Visible = true;
                    xDisplay.Height = this.ClientRectangle.Height / 2;
                    xDisplay2.Top = xDisplay.Top + xDisplay.Height;
                    xDisplay2.Height = xDisplay.Height;
                }
                else
                {
                    xDisplay2.Visible = false;
                    xDisplay.Height = this.ClientRectangle.Height;
                }

                this.tabPage = pageCompany;
                this.pictureBox = this.pictureBox2;
                this.tabControl = ts;
                ts.Height = this.ClientRectangle.Height - ts.Top;
                Int32 height = tabOptions.ClientRectangle.Height - (lblFilters.Height * 2);
                height = height - 10;
                height = (height / 2);
                lblFilters.Top = cmdExcelExport.Bottom + 2;
                lstFilters.Top = lblFilters.Bottom;
                lstFilters.Height = height;
                lblAlt.Top = lstFilters.Bottom;
                lvAlt.Top = lblAlt.Bottom;
                lvAlt.Height = (tabOptions.ClientRectangle.Height - lvAlt.Top) - 3;

            }
            catch (Exception)
            {
            }
        }
        private void CompleteDispose()
        {
        }
        public void SetCompanyName(String name)
        {
            Company = name;
        }
        public override void LoadTemplates()
        {
        }
        public virtual void SwitchContact()
        {
            SetOne("companycontact", "CONTACTSEARCH");
            SetContact();
        }
        public virtual void SwitchCompany()
        {
            SetCompany();
            SetOne("company", "COMPANYSEARCH");
        }
        public override void SwitchBoth()
        {
            SetBoth();
            SetTwo();
        }
        public override void SetTwo()
        {
            String strTemplate = "";
            CurrentClass = "<both>";
            xDisplay.Clear();
            xDisplay2.Clear();
            IsSplit = true;
            strTemplate = "COMPANYSEARCH";
            if (!xDisplay.IsShowingTemplate(strTemplate))
                xDisplay.ShowTemplate(strTemplate, "company", RzWin.User.TemplateEditor);
            strTemplate = "CONTACTSEARCH";
            if (!xDisplay2.IsShowingTemplate(strTemplate))
                xDisplay2.ShowTemplate(strTemplate, "companycontact", RzWin.User.TemplateEditor);
            DoResize();
        }
        public virtual void SetOne(string strClass, string strTemplate)
        {
            CurrentClass = strClass;
            IsSplit = false;
            xDisplay.Clear();
            if (!xDisplay.IsShowingTemplate(strTemplate))
            {
                xDisplay.ShowTemplate(strTemplate, strClass, RzWin.User.TemplateEditor);
            }
            DoResize();
        }
        public void SearchFirstCompany()
        {
        }
        public override void HandleCommand(String strCommand)
        {
            switch (strCommand.ToLower())
            {
                case "search":
                    DoSearch();
                    break;
                default:
                    if (strCommand.Contains("altsearch:"))
                        DoAltSearch(strCommand.Replace("altsearch:", ""));
                    else
                        base.HandleCommand(strCommand);
                    break;
            }
        }
        int hotindex = 0;
        private void ShowAgentList()
        {
        }
        public void DoExportToExcel()
        {
            try
            {
                String SQL = xDisplay.CurrentSQL;
                if (Tools.Strings.StrExt(SQL))
                    Tools.Data.SqlToExcel(RzWin.Context.Data.Connection, SQL);
                else
                    RzWin.Leader.Tell("You need to perform a search first.");
            }
            catch (Exception)
            {
            }
        }
        public void DoBulkEmail()
        {
            try
            {
                ArrayList ids = xDisplay.GetSelectedIDs();
                ArrayList ids2 = xDisplay2.GetSelectedIDs();
                if (ids.Count == 0)
                {
                    if (ids2.Count == 0)
                    {
                        RzWin.Leader.Tell("Please search for and select at least 1 company before continuing.");
                        return;
                    }
                }
                String SQL = "";
                if (optCompany.Checked)
                {
                    SQL = "select unique_id, isnull(primaryemailaddress, '') from company where unique_id in ( " + nTools.GetIn(ids) + " ) and isnull(primaryemailaddress, '') > '' ";
                    SQL += " union select base_company_uid, isnull(primaryemailaddress, '') from companycontact where base_company_uid in ( " + nTools.GetIn(ids) + " ) and isnull(primaryemailaddress, '') > '' ";
                }
                else if (optContact.Checked)
                    SQL = "select base_company_uid, isnull(primaryemailaddress, '') from companycontact where unique_id in ( " + nTools.GetIn(ids) + " ) and isnull(primaryemailaddress, '') > '' ";
                else
                {
                    if (ids.Count > 0 && ids2.Count > 0)
                    {
                        SQL = "select unique_id, isnull(primaryemailaddress, '') from company where unique_id in ( " + nTools.GetIn(ids) + " ) and isnull(primaryemailaddress, '') > '' ";
                        SQL += " union select base_company_uid, isnull(primaryemailaddress, '') from companycontact where base_company_uid in ( " + nTools.GetIn(ids) + " ) and isnull(primaryemailaddress, '') > '' ";
                        SQL += " union select base_company_uid, isnull(primaryemailaddress, '') from companycontact where unique_id in ( " + nTools.GetIn(ids2) + " ) and isnull(primaryemailaddress, '') > '' ";
                    }
                    else if (ids.Count > 0)
                    {
                        SQL = "select unique_id, isnull(primaryemailaddress, '') from company where unique_id in ( " + nTools.GetIn(ids) + " ) and isnull(primaryemailaddress, '') > '' ";
                        SQL += " union select base_company_uid, isnull(primaryemailaddress, '') from companycontact where base_company_uid in ( " + nTools.GetIn(ids) + " ) and isnull(primaryemailaddress, '') > '' ";
                    }
                    else if (ids2.Count > 0)
                        SQL = "select base_company_uid, isnull(primaryemailaddress, '') from companycontact where unique_id in ( " + nTools.GetIn(ids2) + " ) and isnull(primaryemailaddress, '') > '' ";
                }
                DataTable dt = RzWin.Context.Select(SQL);
                if (dt == null)
                    return;
                Control c = RzWin.Form.TabCheckShow("emailblaster");
                if (c != null)
                {
                    EmailBlaster bb = (EmailBlaster)c;
                    bb.LoadEmailsFromDataTable(dt);
                    return;
                }
                EmailBlaster b = ((LeaderWinUserRz)RzWin.Context.TheLeader).EmailBlasterCreate();
                RzWin.Form.TabShow(b, "Email Blaster");
                b.CompleteLoad(dt, null);
            }
            catch { }
        }
        public void DoAltSearch(String option)
        {
            try
            {
                switch (option)
                {
                    case "allvendors":
                    case "vendorsbypurchases":
                        ShowVendors("calc_purchases desc, companyname");
                        break;
                    case "vendorsbyagent":
                        ShowVendors("agentname, companyname");
                        break;
                    case "vendorsbytype":
                        ShowVendors("companytype, companyname");
                        break;
                    case "customersbysales":
                        ShowCustomers("calc_sales desc, companyname");
                        break;
                    case "customersbyvolume":
                        ShowCustomers("total_sales_amount desc, companyname");
                        break;
                    case "customersbyagent":
                        ShowCustomers("agentname, companyname");
                        break;
                    case "customersbytype":
                        ShowCustomers("companytype, companyname");
                        break;
                    case "oem+distdomains":
                        ShowOEMDistDomains();
                        break;
                }
            }
            catch (Exception)
            {
            }
        }
        private void ShowOEMDistDomains()
        {
            SwitchContact();

            String strSQL = "select ";
            if (!xDisplay.UnlimitedResults)
                strSQL += " top 200 ";

            strSQL += " " + xDisplay.GetFieldList("x") + " from companycontact x inner join companycontact y on isnull(x.email_domain, '') = isnull(y.email_domain, '') where isnull(x.email_domain, '') > '' and isnull(x.email_domain, '') not in (select domain_name from domain where isnull(always_exclude, 0) = 1) and isnull(x.abs_type, '') > '' and isnull(y.abs_type, '') > '' and isnull(x.abs_type, '') <> isnull(y.abs_type, '') group by " + xDisplay.GetGroupList("x") + " order by x.email_domain, x.companyname, x.contactname";
            xDisplay.ShowData("companycontact", strSQL);
        }
        protected virtual void ShowVendors(String order)
        {
            xDisplay.Clear();
            xDisplay.ShowData("company", " calc_purchases > 0 ", order, SysNewMethod.ListLimitDefault);

        }
        protected virtual void ShowCustomers(String order)
        {
            xDisplay.Clear();
            xDisplay.ShowData("company", " calc_sales > 0 ", order, SysNewMethod.ListLimitDefault);

        }
        public void DoPartSearch()
        {
            PartSearchShowArgs args = new PartSearchShowArgs();
            RzWin.Context.TheSysRz.ThePartLogic.PartSearchShow(RzWin.Context, args);
            Win.Screens.PartSearch ps = (Win.Screens.PartSearch)args.InfoFirst;
            if (ps == null)
                return;
            nObject o;
            if (IsSplit)
            {
                o = xDisplay2.GetSelectedObject();
                if (o == null)
                    o = xDisplay.GetSelectedObject();
            }
            else
            {
                o = xDisplay.GetSelectedObject();
            }
            if (o == null)
                return;
            try
            {
                switch (o.ClassId.ToLower())
                {
                    case "company":
                        ps.SetCompany((company)o);
                        break;
                    case "companycontact":
                        ps.SetContact((companycontact)o);
                        break;
                }
            }
            catch (Exception)
            {
            }
        }
        public void DoSearch()
        {
            xDisplay.SkipRows = 0;
            xDisplay.Clear();
            xDisplay2.Clear();

            ListArgs args1 = null;
            ListArgs args2 = null;

            if (IsSplit)
            {
                args1 = RzWin.Context.TheSysRz.TheCompanyLogic.PeopleSearchCompanyArgsGet(RzWin.Context, CurrentParameters);
                args2 = RzWin.Context.TheSysRz.TheCompanyLogic.PeopleSearchContactArgsGet(RzWin.Context, CurrentParameters);
            }
            else
            {
                switch (CurrentClass.ToLower())
                {
                    case "company":
                        args1 = RzWin.Context.TheSysRz.TheCompanyLogic.PeopleSearchCompanyArgsGet(RzWin.Context, CurrentParameters);
                        break;
                    case "companycontact":
                        args1 = RzWin.Context.TheSysRz.TheCompanyLogic.PeopleSearchContactArgsGet(RzWin.Context, CurrentParameters);

                        if (!Tools.Strings.StrCmp(xDisplay.CurrentTemplate.Name, "CONTACTSEARCH"))
                            SetOne("companycontact", "CONTACTSEARCH");

                        break;
                }
            }

            if (args1 != null)
            {
                if (xDisplay.UnlimitedResults)
                    args1.TheLimit = -1;
                else
                    args1.TheLimit = GetRowLimit();

                xDisplay.ShowData(args1);
            }

            if (args2 != null)
                xDisplay2.ShowData(args2);
        }
        public override void TopClicked(nObject xObject)
        {
            if (!IsSplit)
                return;
            SearchCompanyID(xObject.unique_id);
        }
        public void SearchCompanyID(String strID)
        {
            xDisplay2.ShowData("companycontact", " base_company_uid = '" + strID + "'", "contactname", GetRowLimit());
        }
        private void xDisplay_Load(object sender, EventArgs e)
        {
        }
        private void xDisplay_ObjectClicked(object sender, ObjectClickArgs args)
        {
        }
        public override int GetRowLimit()
        {
            if (UnlimitedResults)
                return -1;
            else
                return 200;
        }
        private void Options_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '\r':
                case '\n':
                    e.Handled = true;
                    HandleCommand("search");
                    break;
            }
        }
        private void xDisplay_AboutToThrow(object sender, ShowArgs args)
        {
            //args.Handled = true;
            //RzWin.Context.Show(args);
            try
            {
                view_company c = (view_company)args.ViewUsed;
                if (c != null)
                {
                    c.SourceList = xDisplay;
                }
            }
            catch (Exception)
            {
            }
        }

        //private void DoAddCompany()
        //{
        //    try
        //    {
        //        company c = company.AddNew(RzWin.Context, Company);
        //        if(c != null)
        //        {

        //            ////KT Commented out my new changes.  New Companies SHOULD be in the users name that added for 60 days.
        //            ////KT Commented out the old logic (below) and auto-assing new companies to house.
        //            //c.base_mc_user_uid = "17a7e95b7bcb47b0a2501d422f899100";
        //            //c.agentname = "House"; 


        //            //KT New companies get assigned to the user who added it.
        //            if (!Tools.Strings.StrExt(c.base_mc_user_uid))
        //            {
        //                c.base_mc_user_uid = RzWin.User.unique_id;
        //                c.agentname = RzWin.User.name;
        //            }
        //            //KT Added default TBD for new companies.
        //            c.termsascustomer = "TBD";
        //            c.termsasvendor = "TBD";
        //            c.created_by_name = RzWin.User.name;
        //            c.created_by_uid = RzWin.User.unique_id;
        //            c.creditascustomer = 500;
        //            c.Update(RzWin.Context);
        //            RzWin.Context.Show(c);
        //        }
        //    }
        //    catch(Exception)
        //    {
        //    }
        //}
        public void SearchContactsByCompanyNames(ArrayList a)
        {
            xDisplay.ShowData("companycontact", "companyname in (" + nTools.GetIn(a) + " )", "companyname, contactname");
        }
        public void SearchContactsByDomains(ArrayList a)
        {
            if (xDisplay.CurrentTemplate == null)
                SwitchContact();

            String strWhere = "";
            foreach (String s in a)
            {
                if (Tools.Strings.StrExt(strWhere))
                    strWhere += " or ";
                strWhere += "primaryemailaddress like '%@" + s + "'";
            }
            xDisplay.ShowData("companycontact", strWhere, "companyname, contactname");
        }
        public void SearchContactsByPhone(String stripped_phone)
        {
            SearchContactsByWhere(" ( replace(replace(replace(primaryphone, '-', ''), ')', ''), '(', '') like '%" + stripped_phone + "%' or strippedphone = '" + stripped_phone + "' )");
        }
        public void SearchContactsByWhere(String strWhere)
        {
            xDisplay.ShowData("companycontact", strWhere, "companyname, contactname");
        }
        public void SearchCompaniesByWhere(String strWhere)
        {
            xDisplay.ShowData("company", strWhere, "companyname");
        }
        private void xDisplay_FinishedAction(object sender, ActArgs args)
        {
            //Options.LoadGroupList();
        }
        private void ShowNextCallList()
        {
            //build a temp table
            String strTable = "call_list_" + RzWin.User.unique_id;
            if (RzWin.Context.Data.Connection.TableExists(strTable))
                RzWin.Context.Data.Connection.DropTable(strTable);
            String strSQL = "create table " + strTable + " (unique_id varchar(255))";
            RzWin.Context.Execute(strSQL);
            AddCallList(strTable, true);
            long l = RzWin.Context.SelectScalarInt64("select count(*) from " + strTable);
            if (l < 50)
                AddCallList(strTable, false);
            ShowCallList();
        }
        private void AddCallList(String strTable, bool priority)
        {
            String strSQL = "";
            String sp = "0";
            if (priority)
                sp = "1";
            long l = RzWin.Context.SelectScalarInt64("select count(*) from " + strTable);
            long need = 50 - l;
            if (need > 20)
                need = 20;

            String cust_criteria = "isnull(calc_sale_count, 0) > 0";
            //if (CustomerStatus == "prospect")
            //    cust_criteria = "( isnull(calc_sale_count, 0) = 0 and isnull(calc_fquote_count, 0) > 0 )";
            //else if (CustomerStatus == "inactive")
            //    cust_criteria = "( isnull(calc_sale_count, 0) = 0 and isnull(calc_fquote_count, 0) = 0 )";

            strSQL = "insert into " + strTable + " (unique_id) select top " + need.ToString() + " unique_id from companycontact where isnull(exclude_from_next, 0) = 0 and isnull(donotcall, 0) = 0 and companycontact.agentname = '" + RzWin.Context.Filter(RzWin.User.name) + "' and isnull(is_priority_defense, 0) = " + sp + " and " + cust_criteria + " order by calc_last_phonecall";
            RzWin.Context.Execute(strSQL);
            l = RzWin.Context.SelectScalarInt64("select count(*) from " + strTable);
            need = 50 - l;
            if (need > 20)
                need = 20;
            if (need > 0)
            {
                cust_criteria = "isnull(calc_fquote_count, 0) > 0";
                //if (CustomerStatus == "prospect")
                //    cust_criteria = "( isnull(calc_sale_count, 0) = 0 and isnull(calc_fquote_count, 0) > 0 )";
                //else if (CustomerStatus == "inactive")
                //    cust_criteria = "( isnull(calc_sale_count, 0) = 0 and isnull(calc_fquote_count, 0) = 0 )";
                strSQL = "insert into " + strTable + " (unique_id) select top " + need.ToString() + " unique_id from companycontact where isnull(exclude_from_next, 0) = 0 and isnull(donotcall, 0) = 0 and companycontact.agentname = '" + RzWin.Context.Filter(RzWin.User.name) + "' and isnull(is_priority_defense, 0) = " + sp + " and " + cust_criteria + " order by calc_last_phonecall";
                RzWin.Context.Execute(strSQL);
                l = RzWin.Context.SelectScalarInt64("select count(*) from " + strTable);
                need = 50 - l;
                if (need > 10)
                    need = 10;
                if (need > 0)
                {
                    cust_criteria = "isnull(calc_sale_count, 0) = 0 and isnull(calc_fquote_count, 0) = 0";
                    //if (CustomerStatus == "prospect")
                    //    cust_criteria = "( isnull(calc_sale_count, 0) = 0 and isnull(calc_fquote_count, 0) > 0 )";
                    //else if (CustomerStatus == "inactive")
                    //    cust_criteria = "( isnull(calc_sale_count, 0) = 0 and isnull(calc_fquote_count, 0) = 0 )";
                    //strSQL = "insert into " + strTable + " (unique_id) select top " + need.ToString() + " unique_id from companycontact where isnull(exclude_from_next, 0) = 0 and isnull(donotcall, 0) = 0 and companycontact.agentname = '" + RzWin.Context.Filter(RzWin.User.name) + "' and isnull(is_priority_defense, 0) = " + sp + " and " + cust_criteria + " order by calc_last_phonecall";
                    //RzWin.Context.Execute(strSQL);
                }
            }
        }
        private void xDisplay_FinishedFill(object sender)
        {
            if (Tools.Strings.StrExt(TableToDelete))
            {
                RzWin.Context.Data.Connection.DropTable(TableToDelete);
                TableToDelete = "";
            }
        }
        private void ShowCallList()
        {
            SwitchContact();
            this.xDisplay.Clear();
            String strTable = "call_list_" + RzWin.User.unique_id;
            if (!RzWin.Context.Data.Connection.TableExists(strTable))
            {
                ShowNextCallList();
                return;
            }
            SearchContactsByWhere("unique_id in (select unique_id from " + strTable + ")");
        }
        void ShowHot()
        {
            xDisplay.AsyncMode = false;
            SetOne("companycontact", "CONTACTSEARCH_3MONTH");

            String strUserID = RzWin.User.unique_id;
            if (Tools.Strings.StrExt(Agent))
            {
                String strSelectedID = RzWin.Context.xSys.TranslateUserNameToID(Agent);

                if (RzWin.User.SuperUser && Tools.Strings.StrExt(strSelectedID))
                    strUserID = strSelectedID;
                else if (Tools.Strings.StrExt(strSelectedID) && RzWin.User.IsTeamCaptainOf(RzWin.Context, strSelectedID))
                    strUserID = strSelectedID;
            }

            nSQL xs = new nSQL(true);

            if (Tools.Strings.StrExt(Group))
                xs.AddWhere(RzWin.Context, "group_name", "," + Group + ",");

            if (Tools.Strings.StrExt(CompanyType))
            {
                switch (CompanyType.ToLower().Trim())
                {
                    case "dist":
                    case "distributor":
                    case "d":
                        xs.AddWhere(RzWin.Context, "abs_type", "dist");
                        break;
                    case "oem":
                    case "o":
                        xs.AddWhere(RzWin.Context, "abs_type", "oem");
                        break;
                    case "non-dist":
                        xs.AddWhere(RzWin.Context, "abs_type", "dist", NewMethod.Enums.CompareType.NotEqual);
                        break;
                    case "non-oem":
                        xs.AddWhere(RzWin.Context, "abs_type", "oem", NewMethod.Enums.CompareType.NotEqual);
                        break;
                }
            }

            DateTime callcutoff = NotCalledSince;
            if (Tools.Dates.DateExists(callcutoff))
                xs.AddDirectWhereAnd("isnull(calc_last_phonecall, cast('01/01/1900' as datetime)) < cast('" + Tools.Dates.DateFormatWithTimeRegardlessOfWindowsSettings(callcutoff) + "' as datetime)");

            xs.AddDirectWhereAnd("base_mc_user_uid = '" + strUserID + "' and calc_sale_count > 0 and calc_last_sale <= cast('" + Tools.Dates.DateFormatWithTimeRegardlessOfWindowsSettings(DateTime.Now.Subtract(TimeSpan.FromDays(60))) + "' as datetime)");
            xDisplay.SkipRows = hotindex * 25;
            xDisplay.ShowData("companycontact", xs.RenderSQL(), "calc_sale_amount desc", 25 * (hotindex + 1));
        }
        private void Options_GotCurrentCallList(object sender, EventArgs e)
        {
            ShowCallList();
        }
        private void Options_GotHighlight(object sender, EventArgs e)
        {
            String s = Group;
            if (!Tools.Strings.StrExt(s))
                return;
            //get the index of the group_name column
            int i = xDisplay.CurrentTemplate.GetColumnIndexByProperty("group_name");
            if (i == -1)
                return;
            xDisplay.BackColorByString(Color.LightGray, i, s);
        }
        private void Options_GotNextCallList(object sender, EventArgs e)
        {
            ShowNextCallList();
        }
        private void Options_GotEvent(string strEvent)
        {
            HandleCommand(strEvent);
        }
        private void Options_SearchClicked()
        {
            HandleCommand("search");
        }
        public virtual PeopleSearchParameters CurrentParameters
        {
            get
            {
                PeopleSearchParameters ret = RzWin.Context.TheSysRz.TheCompanyLogic.PeopleSearchParametersCreate();
                ret.CompanyName = Company;
                ret.PhoneFaxEmail = PhoneFaxEmail;
                ret.ContactName = Contact;
                ret.CompanyType = CompanyType;
                ret.AgentNamePipeDelimited = Agent;
                ret.OnlyUnassigned = OnlyUnassigned;
                ret.GroupName = Group;
                ret.SourceName = Source;
                ret.CallSchedule = CallSchedule;
                ret.HasSales = HasSales;
                ret.HasPurchases = HasPurchases;
                ret.OrderNumber = OrderNumber;
                ret.OrderDate = OrderDate;
                ret.PartNumber = PartNumber;
                ret.Address = Address;
                ret.ProspectAccounts = ProspectAccounts;
                ret.ReqMin = ReqCount();
                ret.MfgType = MFGType;
                ret.ComType = COMType;
                ret.Rank = Rank;
                ret.TimeZone = TimeZone;
                ret.Filters = GetSelectedFilters();
                ret.OrderByDomain = OrderByDomain;
                //ret.CustomerStatus = CustomerStatus;
                ret.BadMailingAddress = BadMailingAddress;
                ret.NotCalledSince = NotCalledSince;
                ret.Office = Office;
                ret.industry_segment = IndustrySegment;
                return ret;
            }
        }
        //public event PeopleSearchOptionsClickHandler SearchClicked;
        //public event PeopleSearchOptionsEventHandler GotEvent;
        public virtual String Company
        {
            get
            {
                return ((String)ctl_CompanyName.GetValue()).Trim();
            }

            set
            {
                ctl_CompanyName.SetValue(value);
            }
        }
        public virtual String Contact
        {
            get
            {
                return ((String)ctl_ContactName.GetValue()).Trim();
            }
        }
        public virtual String PhoneFaxEmail
        {
            get
            {
                return ((String)ctl_PhoneFaxEmail.GetValue()).Trim();
            }
        }
        public virtual String CallSchedule
        {
            get
            {
                return ctlCallSchedule.GetValue_String().Trim();
            }
        }
        public virtual String Agent
        {
            get
            {
                try
                {
                    if (SelectedAgents.Count == 0)
                        return "";

                    String s = "";
                    foreach (String x in SelectedAgents)
                    {
                        if (Tools.Strings.StrExt(s))
                            s += "|";
                        s += x;
                    }

                    return s;
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }
        public virtual String Group
        {
            get
            {
                return lblGroupName.Text.Trim();
            }
        }
        public virtual String Source
        {
            get
            {
                return ((String)ctl_Source.GetValue()).Trim();
            }
        }
        public virtual String MFGType
        {
            get
            {
                return "";
            }
        }
        public virtual String Office
        {
            get
            {
                return "";
            }
        }
        public bool BadMailingAddress
        {
            get
            {
                return ctlBadMailingAddress.GetValue_Boolean();
            }
        }
        public virtual String COMType
        {
            get
            {
                return "";
            }
        }
        public virtual String Rank
        {
            get
            {
                return "";
            }
        }
        public virtual String TimeZone
        {
            get
            {
                return "";
            }
        }
        public virtual String CompanyType
        {
            get
            {
                return ((String)ctl_CompanyType.GetValue()).Trim();
            }
        }
        public virtual String OrderNumber
        {
            get
            {
                return ((String)ctl_OrderNumber.GetValue()).Trim();
            }
        }
        public virtual DateTime OrderDate
        {
            get
            {
                return ctl_OrderDate.GetValue_Date();
            }
        }
        public Int32 ReqCount()
        {
            return ctl_ReqCount.GetValue_Integer();
        }
        public Boolean HasSales
        {
            get
            {
                return chkSales.Checked;
            }
        }
        public Boolean HasPurchases
        {
            get
            {
                return chkPurchases.Checked;
            }
        }
        public bool OnlyUnassigned
        {
            get
            {
                return chkUnassigned.Checked;
            }
        }
        public DateTime NotCalledSince
        {
            get
            {
                return ctlCallCutoff.GetValue_Date();
            }
        }
        public bool OrderByDomain
        {
            get
            {
                return chkOrderByEmailDomain.Checked;
            }
        }
        //public virtual String CustomerStatus
        //{
        //    get
        //    {
        //        if (optCustomers.Checked)
        //            return "customer";
        //        if (optProspects.Checked)
        //            return "prospect";
        //        if (optInactive.Checked)
        //            return "inactive";
        //        return "";
        //    }
        //}
        public Boolean ProspectAccounts
        {
            get { return chkProspectAccount.Checked; }
        }
        //public virtual String ReferenceNumber
        //{
        //    get { return (String)ctl_ReferenceNumber.GetValue(); }
        //}
        public virtual String PartNumber
        {
            get
            {
                return ((String)ctl_PartNumber.GetValue()).Trim();
            }
        }
        public virtual String Address
        {
            get
            {
                return ((String)ctl_Address.GetValue()).Trim();
            }
        }

        public virtual string IndustrySegment
        {
            get
            {
                return ((string)ctl_industry_segment.GetValue()).Trim();
            }
        }



        public bool UnlimitedResults
        {
            get
            {
                return chkSwitchView.Checked;
            }
        }
        public ArrayList Filters;
        public virtual void CompleteLoadOptions()
        {
            ctl_OrderDate.SetValue(Tools.Dates.GetNullDate());
            LoadAlternateSearches();
            LoadFilters();
            DoResize();
            lblGroupName.Text = "";
            lblChoose.Visible = true;
            ctl_Source.AllowEdit = RzWin.User.SuperUser;
            ctl_Source.LoadList(true);
            SetVisibleControls();
            ctl_CompanyType.LoadList();
            if (!RzWin.User.SuperUser)
                ts.TabPages.Remove(tabOptions);
        }
        protected virtual void SetVisibleControls()
        {
            chkUnassigned.Visible = false;
            lblCurrentCallList.Visible = false;
            lblNextCallList.Visible = false;
            chkOrderByEmailDomain.Visible = false;
            pCTG.Visible = false;
        }
        private void LoadFilters()
        {
            lstFilters.Items.Clear();
            if (Filters == null)
                return;
            foreach (String s in Filters)
            {
                lstFilters.Items.Add(s);
            }
        }
        protected virtual void LoadAlternateSearches()
        {
            try
            {
                lvAlt.Items.Clear();
                lvAlt.Items.Add("All Vendors");
                lvAlt.Items.Add("Vendors By Purchases");
                lvAlt.Items.Add("Vendors By Agent");
                lvAlt.Items.Add("Vendors By Type");
                lvAlt.Items.Add("Customers By Sales");
                lvAlt.Items.Add("Customers By Volume");
                lvAlt.Items.Add("Customers By Agent");
                lvAlt.Items.Add("Customers By Type");
            }
            catch { }
        }
        public void SetCompany()
        {
            optCompany.Checked = true;
        }
        public void SetContact()
        {
            optContact.Checked = true;
        }
        public void SetBoth()
        {
            optBoth.Checked = true;
        }
        private void PeopleSearchOptions_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        protected TabControl tabControl;
        protected PictureBox pictureBox;
        protected TabPage tabPage;
        private void cmdSearch_Click(object sender, EventArgs e)
        {
            DoSearch();
        }
        private void cmdParts_Click(object sender, EventArgs e)
        {
            DoPartSearch();
        }
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            //DoAddCompany();
            company c = company.AddNew(RzWin.Context, "", "", "", "", "");
            if (c != null)
                RzWin.Context.Show(c);
        }
        protected virtual void cmdClear_Click(object sender, EventArgs e)
        {
            ctl_CompanyName.SetValue("");
            ctl_ContactName.SetValue("");
            ctl_PhoneFaxEmail.SetValue("");

            SelectedAgents = new ArrayList();
            ShowAgents();

            //ctl_Group.SetValue("");
            lblGroupName.Text = "";
            ctl_Source.SetValue("");
            ctl_CompanyType.SetValue("");
            ctl_OrderNumber.SetValue("");
            ctl_OrderDate.SetValue(Tools.Dates.GetNullDate());
            ctl_PartNumber.SetValue("");
            ctl_Address.SetValue("");
            chkSales.Checked = false;
            chkPurchases.Checked = false;

        }
        private void cmdNewScreen_Click(object sender, EventArgs e)
        {
            IPeopleSearch p = ((LeaderWinUserRz)RzWin.Context.TheLeaderRz).PeopleSearchCreate();
            RzWin.Form.TabShow((Control)p, "People Search");
            p.CompleteLoad();
        }
        private void opt_CheckedChanged(object sender, EventArgs e)
        {
            if (optCompany.Checked)
                SwitchCompany();
            else if (optContact.Checked)
                SwitchContact();
            else
                SwitchBoth();
        }
        private void ctl_Agent_ChangeUser(GenericEvent e)
        {
            //if (Rz3App.xLogic.IsCTG)
            //{

            //}
            //else
            //{

            //    ArrayList a = Rz3App.SalesPeople;
            //    if (Rz3App.xLogic.IsNasco)
            //    {
            //        a = Rz3App.SelectScalarArray("select name from n_user");
            //        if (a == null)
            //            a = Rz3App.SalesPeople;
            //    }
            //    n_user u = n_user.Choose(Rz3App.xSys, this.ParentForm, a, Rz3App.xUser.SuperUser);
            //    if (u == null)
            //        return;
            //    ctl_Agent.SetUserName(u.name);
            //}
        }
        public ArrayList GetSelectedFilters()
        {
            ArrayList a = new ArrayList();
            foreach (Object x in lstFilters.CheckedItems)
            {
                a.Add(x.ToString());
            }
            return a;
        }
        private void ctl_GotEnter()
        {
            DoSearch();
        }
        private void ctl_Group_Load(object sender, EventArgs e)
        {
        }
        protected override bool ProcessKeyPreview(ref Message m)
        {
            switch (m.WParam.ToInt32())
            {
                case 10:
                case 13:
                    DoSearch();
                    break;
            }
            return base.ProcessKeyPreview(ref m);
        }
        private void ts_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void ts_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoResize();
        }
        private void lvAlt_DoubleClick(object sender, EventArgs e)
        {
            if (lvAlt.SelectedItems.Count <= 0)
                return;
            String option = lvAlt.SelectedItems[0].Text.Trim().ToLower().Replace(" ", "");
            if (!Tools.Strings.StrExt(option))
                return;
            HandleCommand("altsearch:" + option);
        }
        private void chkSwitchView_CheckStateChanged(object sender, EventArgs e)
        {
            //GotEvent("switch");
        }
        private void cmdExcelExport_Click(object sender, EventArgs e)
        {
            DoExportToExcel();
        }
        private void cmdViewAgents_Click(object sender, EventArgs e)
        {
            ShowAgentList();
        }
        private void cmdBulkEmail_Click(object sender, EventArgs e)
        {
            DoBulkEmail();
        }
        private void lblEditGroups_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RzWin.Context.Reorg();
            //companycontact.ShowGroups(RzWin.Context);
        }
        public event EventHandler GotCurrentCallList;
        public event EventHandler GotNextCallList;
        public event EventHandler GotHighlight;
        private void lblNextCallList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!RzWin.Leader.AreYouSure("create a new call list"))
                return;
            if (GotNextCallList != null)
                GotNextCallList(null, null);
        }
        private void lblCurrentCallList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (GotCurrentCallList != null)
                GotCurrentCallList(null, null);
        }
        private void lblHighlight_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (GotHighlight != null)
                GotHighlight(null, null);
        }
        protected ArrayList SelectedAgents = new ArrayList();
        private void lblChooseAgents_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SelectedAgents = GetSelectedAgents();
            if (!RzWin.User.SuperUser)
                SelectedAgents.Remove("Unclaimed");
            ShowAgents();
        }
        protected virtual ArrayList GetSelectedAgents()
        {
            return frmChooseUser_Multiple.Choose(RzWin.Logic.SalesPeople, "Agent Selection", SelectedAgents);
        }
        void ShowAgents()
        {
            if (SelectedAgents.Count == 0)
                lblChooseAgents.Text = "<click to choose>";
            else if (SelectedAgents.Count == 1)
                lblChooseAgents.Text = (String)SelectedAgents[0];
            else
                lblChooseAgents.Text = (String)SelectedAgents[0] + " +" + Convert.ToInt32(SelectedAgents.Count - 1).ToString();
        }
        private void lblClearAgents_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SelectedAgents = new ArrayList();
            ShowAgents();
        }
        private void lvAlt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void lblNewSearch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Rz5.Win.Screens.IPeopleSearch p = ((Rz5.LeaderWinUserRz)RzWin.Context.TheLeader).PeopleSearchCreate();
            RzWin.Form.TabShow((UserControl)p, "People");

            p.CompleteLoad();
            p.SwitchCompany();  //otherwise nothing searches
        }
        private void cmd3Month_Click(object sender, EventArgs e)
        {
            hotindex = 0;
            ShowHot();
        }
        private void lblHot50_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            hotindex++;
            ShowHot();
        }
        private void lblPrevious_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (hotindex > 0)
                hotindex--;
            ShowHot();
        }
        private void lblChoose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String cn = "company";
            if (optContact.Checked)
                cn = "companycontact";
            String g = frmChooseGroup.Choose(cn, (n_user)RzWin.User);
            if (!Tools.Strings.StrExt(g))
                return;
            //ctl_Group.SetValue(g);
            lblGroupName.Text = g;
        }
        private void lblClearGroup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblGroupName.Text = "";
        }

        private void xDisplay2_AboutToThrow(Context x, ShowArgs args)
        {
            string test = "";           
        }

        private void xDisplay2_AboutToAction(object sender, ActArgs args)
        {
            string test = "";
        }
    }
    public interface IPeopleSearch
    {
        void CompleteLoad();
        void SetNotifySelection(NewMethod.ListArgs.IGenericNotify notify);
        void SetTwo();
        void SetCompanyName(String companyName);
        void DoSearch();
        void SearchCompanyID(String companyId);
        void SwitchCompany();
        void SwitchContact();
        void SearchContactsByWhere(String sql);
    }
    public delegate void PeopleSearchOptionsClickHandler();
    public delegate void PeopleSearchOptionsEventHandler(String strEvent);
}