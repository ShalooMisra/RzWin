using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Tools;
using Core;
using NewMethod;

//!!Need To Add
//ctl_warranty_period
//Loc: 6, 157
//Size: 203, 36
//then in competeload addd:  ctl_warranty_period.LoadList();
namespace Rz5
{
    public partial class view_company : ViewPlusMenu
    {
        private ContextNM TheContext
        {
            get { return RzWin.Context; }
        }
        public company CurrentCompany;
        Boolean bLoading = false;
        public nList m_SourceList;
        public virtual nList SourceList
        {
            set
            {
                if (value == null)
                {
                    cmdBack.Visible = false;
                    cmdForward.Visible = false;
                    lblScroll.Visible = false;
                }
                else
                {
                    cmdBack.Visible = true;
                    cmdForward.Visible = true;
                    lblScroll.Visible = true;
                    lblScroll.Text = value.GetScrollCaption();
                }
                m_SourceList = value;
            }
        }
        public view_company()
        {
            InitializeComponent();
        }

        //KT Refactored from RzSensible
        public override void Init(Item items)
        {
            base.Init(items);
            
            ctl_timezone.LoadList("timezone");
            ctl_industry_segment.LoadList(true);
            ctl_isverified.Caption = "AVL";


        }

        public override void CompleteLoad()
        {
            RemoveUnusedTabs();
           

            tabAccounts.Text = "Shipping Accounts";
            CurrentCompany = (company)GetCurrentObject();
            ctl_creditascustomer.zz_Enabled = false;
            ctl_creditasvendor.zz_Enabled = false;
            if (RzWin.Context.xUser.SuperUser)
                ctl_wherefoundcompany.AllowEdit = true;

            if (FeedbackControl.Visible)
            {
                FeedbackControl.CompleteLoad(CurrentCompany);
                lvFeedback.ShowTemplate("company_feedback_view", "feedback", RzWin.User.TemplateEditor);
            }
            user.CurrentObject = CurrentCompany;
            user.CurrentIDField = "base_mc_user_uid";
            user.CurrentNameField = "agentname";
            user.SetUserName();
            CheckPermissions();

            tsl.SelectedTab = pageContacts;
            ShowContacts();
            SetStatusVisible(CurrentCompany);
            //LoadCallSchedule();
            
            cmdSendCreditCardifoToQBs.Visible = false;
            if (RzWin.Logic.UseMergedQuotes)
            {
                pageBatches.Text = "Order Batches";
                //2010_02_05  this was commented out for some reason?               
                tabQuotes.Text = "Reqs / Quotes";
                result_qquotes.Visible = false;
                gbQuoteOptions.Visible = false;
            }
            ctl_companytype.LoadList(true);
            ShowNotify();
            LoadAutoArchiveTab();
            PPV.CompleteLoad(false);
            PPV.LoadViewBy(CurrentCompany);
            PPV.Caption = "Attachments for " + CurrentCompany.ToString();
            //KT 10-16-2015 - Removing need for users to be in accounting department to see credit cards:
            //if (!RzWin.Context.xUserRz.AccountingIs && !RzWin.Context.xUserRz.IsDeveloper())
            //ts.TabPages.Remove(tabCreditCard);


            //KT
            LoadVendorCredits();
            LoadVetted();
            //KT Refactored from Rz5
            consignmentCodes.Init(RzWin.Context, CurrentCompany);
            StartProblemCustomerTimer();
            GetOutstandingARAP();
            GetVendorCredits();
            LoadCompany_terms_Conditions();
            GetPortalSearchCount();
            sc1.CompleteLoad(RzWin.Context, CurrentCompany);
            base.CompleteLoad();
        }

        private void RemoveUnusedTabs()
        {
            //upper tabstrip
            ts.TabPages.Remove(tabQB);
            ts.TabPages.Remove(tabArchive);
            ts.TabPages.Remove(tabECommerce);
            ts.TabPages.Remove(tabCallSchedule);
            ts.TabPages.Remove(pagePOInfo);
            ts.TabPages.Remove(tabProducts);


            //lower tabstrip
            tsl.TabPages.Remove(tabGenie);
            tsl.TabPages.Remove(pageReqs);
        }

        private void LoadCallSchedule()
        {
            chkCallMonday.Checked = Tools.Strings.HasString(CurrentCompany.call_schedule, "|monday|");
            chkCallTuesday.Checked = Tools.Strings.HasString(CurrentCompany.call_schedule, "|tuesday|");
            chkCallWednesday.Checked = Tools.Strings.HasString(CurrentCompany.call_schedule, "|wednesday|");
            chkCallThursday.Checked = Tools.Strings.HasString(CurrentCompany.call_schedule, "|thursday|");
            chkCallFriday.Checked = Tools.Strings.HasString(CurrentCompany.call_schedule, "|friday|");
            chkCallSaturday.Checked = Tools.Strings.HasString(CurrentCompany.call_schedule, "|saturday|");
            chkCallSunday.Checked = Tools.Strings.HasString(CurrentCompany.call_schedule, "|sunday|");
        }
        private void SaveCallSchedule()
        {
            String o = CurrentCompany.call_schedule;
            String s = "";
            if (chkCallMonday.Checked)
                s += "|monday|";
            if (chkCallTuesday.Checked)
                s += "|tuesday|";
            if (chkCallWednesday.Checked)
                s += "|wednesday|";
            if (chkCallThursday.Checked)
                s += "|thursday|";
            if (chkCallFriday.Checked)
                s += "|friday|";
            if (chkCallSaturday.Checked)
                s += "|saturday|";
            if (chkCallSunday.Checked)
                s += "|sunday|";
            if (!Tools.Strings.StrCmp(o, s))
            {
                CurrentCompany.call_schedule = s;
                CurrentCompany.Update(RzWin.Context);
            }
        }
        private void SendCreditCardInfoToQBs()
        {
            if (RzWin.Context.TheSysRz.TheQuickBooksLogic.UpdateCustomerInfo(RzWin.Context, CurrentCompany, CurrentCompany.GetPrimaryBillingAddress(RzWin.Context), CurrentCompany.GetPrimaryShippingAddress(RzWin.Context), CurrentCompany.qb_name, true))
                RzWin.Leader.Tell("Updated.");
        }
        public virtual String GetContactName()
        {
            return (String)ctl_primarycontact.GetValue();
        }
        public override void CompleteSave()
        {
            if (!Strings.StrExt(ctl_wherefoundcompany.GetValue_String()))
            {
                throw new Exception("Could not save.  Please enter a source");
            }

            string sc = GetContactName();
            bool newcontact = false;
            if (Tools.Strings.StrExt(sc) && !Tools.Strings.StrCmp(CurrentCompany.primarycontact, sc))
                newcontact = true;
            //this grabs the new phone, fax, and email, if there is one
            base.CompleteSave();
            CheckExtraSave();
            if (newcontact)
            {
                companycontact c = CurrentCompany.GetContactByName(RzWin.Context, sc);
                if (c == null)
                {
                    if (RzWin.Leader.AskYesNo("Do you want to add " + sc + " as linked contact also?"))
                    {
                        c = CurrentCompany.AddContact(RzWin.Context);
                        c.contactname = sc;
                        c.Update(RzWin.Context);
                    }
                }
            }
            SaveCallSchedule();
            SaveVetted();
            SetStatusVisible(CurrentCompany);
            UpdateArchiveValues();
            SaveCompany_terms_Conditions();
            //CompleteSaveSplitCommission();
            //splitCommission1.CompleteSave();
            //CheckUpdateQbCompany();

        }

        private void CheckUpdateQbCompany()
        {
            if (RzWin.Context.CheckPermit(Permissions.ThePermits.SendCompaniesToQuickBooks))
            {
                //Is the Rz Company tagged to a qB_ListID?
                if (!string.IsNullOrEmpty(CurrentCompany.qb_company_ListID))
                {
                    //Set the company type for the QBFC query
                    Enums.CompanySelectionType type = Enums.CompanySelectionType.Customer;
                    if (CurrentCompany.companytype.ToLower().Contains("vendor"))
                        type = Enums.CompanySelectionType.Vendor;

                    //Actually check to see if this record exists in QB
                    if (RzWin.Context.TheSysRz.TheQuickBooksLogic.CompanyExists(RzWin.Context, CurrentCompany, type))
                    {
                        //If it exists, ask user if they want to update it.  //This should probably just happen.
                        if (RzWin.Leader.AskYesNo("Would you like to update this company in Quickbooks?"))
                            RzWin.Context.TheSysRz.TheQuickBooksLogic.UpdateCustomerInfo(RzWin.Context, CurrentCompany, CurrentCompany.GetPrimaryShippingAddress(RzWin.Context), CurrentCompany.GetPrimaryBillingAddress(RzWin.Context), CurrentCompany.companyname);

                    }

                }
            }
        }

        private void SaveCompany_terms_Conditions()
        {

            company_terms_conditions ct = CurrentCompany.GetExistingCompanyTC(RzWin.Context);
            if (ct == null)
                ct = CurrentCompany.AddNewCompanyTC(RzWin.Context);
            ct.has_dc_restriction = ctl_date_code_restriction.Checked;
            ct.has_packaging_restriction = ctl_packaging_requirements.Checked;
            ct.has_rohs_restriction = ctl_rohs_restriction.Checked;
            ct.has_broker_restriction = ctl_broker_restriction.Checked;
            ct.has_coo_restriction = ctl_coo_restriction.Checked;
            ct.has_testing_restriction = ctl_testing_restriction.Checked;
            ct.requires_traceability = ctl_requires_traceability.Checked;

            ct.has_packaging_restriction_detail = ctl_packaging_requirements_detail.Text;
            ct.has_dc_restriction_detail = ctl_date_code_restriction_detail.Text;
            ct.has_testing_restriction_detail = ctl_testing_restriction_detail.Text;

            ct.Update(RzWin.Context);
        }
        private void LoadCompany_terms_Conditions()
        {

            company_terms_conditions ct = CurrentCompany.GetExistingCompanyTC(RzWin.Context);
            if (ct != null)
            {

                ctl_rohs_restriction.Checked = ct.has_rohs_restriction;
                ctl_broker_restriction.Checked = ct.has_broker_restriction;
                ctl_coo_restriction.Checked = ct.has_coo_restriction;
                ctl_requires_traceability.Checked = ct.requires_traceability;
                
                if (ct.has_dc_restriction)
                {
                    ctl_date_code_restriction.Checked = true;
                    ctl_date_code_restriction_detail.Text = ct.has_dc_restriction_detail;
                }
                else
                {
                    ctl_date_code_restriction.Checked = false;
                    ctl_date_code_restriction_detail.Text = null;

                }
                ctl_date_code_restriction_detail.Enabled = ctl_date_code_restriction.Checked;


                if (ct.has_packaging_restriction)
                {
                    ctl_packaging_requirements.Checked = true;
                    ctl_packaging_requirements_detail.Text = ct.has_packaging_restriction_detail;
                }
                else
                {
                    ctl_packaging_requirements.Checked = false;
                    ctl_packaging_requirements_detail.Text = null;
                }
                ctl_packaging_requirements_detail.Enabled = ctl_packaging_requirements.Checked;


                if (ct.has_testing_restriction)
                {
                    ctl_testing_restriction.Checked = true;
                    ctl_testing_restriction_detail.Text = ct.has_testing_restriction_detail;
                }
                else
                {
                    ctl_testing_restriction.Checked = false;
                    ctl_testing_restriction_detail.Text = null;
                }
                ctl_testing_restriction_detail.Enabled = ctl_testing_restriction.Checked;






            }


        }

        //KT
        protected void SaveVetted()
        {
            //KT Had to rename the ctl_is_vetted to "cbx"_is_vetted, because the ORM auto-commits the boolean on click, therefore checking CurrentCompany.is_vetted is
            //never accurate to the existing database value at this point.
            if (cbx_is_vetted.zz_CheckValue != CurrentCompany.is_vetted)//detect if a change to vet status was just made, if not, do nothing
            {

                if (RzWin.Context.CheckPermit(Permissions.ThePermits.CanVetSuppliers))
                {
                    if (cbx_is_vetted.zz_CheckValue == true)
                    {
                        //If company was not already vetted, update to the new user and date, if I don't check this, it will get set to a new user and date on each save.
                        //it the company was already is_Vetted = true, nothing needs to be updated.
                        if (CurrentCompany.is_vetted == false)
                            CurrentCompany.is_vetted = true;
                        CurrentCompany.vetted_by = RzWin.Context.xUser.Name;
                        CurrentCompany.vetted_date = DateTime.Now;
                        CurrentCompany.Update(RzWin.Context);
                    }
                    else
                    {
                        //If the company was vetted, and is not being unvetted, set is_vetted = false, but leave the other date intact for historical reference.
                        //IF the company was already is_vetted = false, nothing needs to be updated.
                        if (CurrentCompany.is_vetted == true)
                            CurrentCompany.is_vetted = false;
                        CurrentCompany.Update(RzWin.Context);
                    }
                }
            }

        }
        protected void LoadVetted()
        {
            //KT - 1st, run the check vetted routine, which will un-vet if last purchase date was more than 365 days ago
            RzWin.Context.TheSysRz.TheCompanyLogic.CheckVetted(RzWin.Context, CurrentCompany);
            //KT Next load the vetting details
            cbx_is_vetted.zz_CheckValue = CurrentCompany.is_vetted;
            lblVetDate.Text = "Last vetted on: " + CurrentCompany.vetted_date.ToString("MM/dd/yy");
            lblVettedBy.Text = "Last vetted by: " + CurrentCompany.vetted_by;
        }


        public virtual void CheckExtraSave()
        {

        }
        public virtual void SetStatusVisible(company c)
        {
            try
            {
                optViewCust.Visible = false;
                optViewVend.Visible = false;
            }
            catch (Exception)
            {
            }
        }
        public override void HandleCommand(String strCommand)
        {
            try
            {
                switch (strCommand.ToLower())
                {
                    case "pastefrombf":
                        CompleteSave();
                        CurrentCompany.Paste(ToolsWin.Clipboard.GetClipText(), Enums.Website.BrokerForum);
                        CurrentCompany.Update(RzWin.Context);
                        CompleteLoad();
                        break;
                    case "pastefrompb":
                        CompleteSave();
                        CurrentCompany.Paste(ToolsWin.Clipboard.GetClipText(), Enums.Website.PartsBase);
                        CurrentCompany.Update(RzWin.Context);
                        CompleteLoad();
                        break;
                    default:
                        base.HandleCommand(strCommand);
                        break;
                }
            }
            catch (Exception)
            {
                base.HandleCommand(strCommand);
            }
        }
        public override void FinishedAction(ActArgs args)
        {
            base.FinishedAction(args);

            switch (args.ActionName.ToLower())
            {
                case "note":
                    CurrentCompany.last_activity_date = DateTime.Now;
                    CurrentCompany.Update(RzWin.Context);
                    break;
            }
        }
        private void ShowContacts()
        {
            result_contacts.Init(CurrentCompany.ContactArgsGet(RzWin.Context));
        }
        private void ShowAddresses()
        {
            result_addresses.Init(CurrentCompany.AddressArgsGet(RzWin.Context));
        }
        private void ShowShippingAccounts()
        {
            result_accounts.Init(CurrentCompany.AccountArgsGet(RzWin.Context));
        }
        private void ShowReqs()
        {
            result_reqs.ShowTemplate("QUICKSHOWREQS", "req", RzWin.User.TemplateEditor);
            result_reqs.ShowData("req", "base_company_uid = '" + CurrentCompany.unique_id + "'", "datecreated desc", result_reqs.UnlimitedResults ? -1 : SysNewMethod.ListLimitDefault);
        }
        private void ShowReqBatches()
        {
            if (RzWin.Logic.UseMergedQuotes)
            {
                result_reqbatches.Init(CurrentCompany.OrderBatchesArgsGet(RzWin.Context));
                //result_reqbatches.ShowTemplate("COMPANYORDERBATCHES", "dealheader", Rz3App.xUser.TemplateEditor);
                //result_reqbatches.ShowData("dealheader", "customer_uid = '" + CurrentCompany.unique_id + "'", "date_created desc", result_reqbatches.UnlimitedResults ? -1 : SysNewMethod.ListLimitDefault);
            }
            else
            {
                result_reqbatches.ShowTemplate("COMPANYREQBATCHES", "reqbatch", RzWin.User.TemplateEditor);
                result_reqbatches.ShowData("reqbatch", "base_company_uid = '" + CurrentCompany.unique_id + "'", "date_created desc", result_reqbatches.UnlimitedResults ? -1 : SysNewMethod.ListLimitDefault);
            }
        }
        private void ShowQuotes()
        {
            if (!RzWin.Logic.UseMergedQuotes)
            {
                result_qquotes.ShowTemplate("COMPANYQUOTES", "quote", RzWin.User.TemplateEditor);
                result_qquotes.ShowData("quote", "quotetype = 'giving out' and base_company_uid = '" + CurrentCompany.unique_id + "'", "quotedate desc", result_qquotes.UnlimitedResults ? -1 : SysNewMethod.ListLimitDefault);
                result_fquotes.ShowTemplate("COMPANYFORMALQUOTES", "orddet", RzWin.User.TemplateEditor);
                result_fquotes.ShowData(ordhed.MakeOrddetName("quote"), "orddet.ordertype = 'quote' and orddet.base_company_uid = '" + CurrentCompany.unique_id + "'", "orderdate desc", result_fquotes.UnlimitedResults ? -1 : SysNewMethod.ListLimitDefault);
            }
            else
                result_fquotes.Init(CurrentCompany.QuoteAndReqArgsGet(RzWin.Context));
            result_fquotes.ShowData(ordhed.MakeOrddetName("quote"), ordhed.MakeOrddetName(Enums.OrderType.Quote) + ".ordertype = 'quote' and " + ordhed.MakeOrddetName(Enums.OrderType.Quote) + ".base_company_uid = '" + CurrentCompany.unique_id + "'", "orderdate desc", result_fquotes.UnlimitedResults ? -1 : SysNewMethod.ListLimitDefault);
        }
        private void ShowBids()
        {
            result_bids.Init(CurrentCompany.BidArgsGet(RzWin.Context));
        }
        private void ShowOrders()
        {
            if (!optOrders.Checked)
            {
                ShowOrderLines();
                return;
            }
            String sw = "";
            if (optQuote.Checked)
                sw = "quote";
            else if (optSales.Checked)
                sw = "sales";
            else if (optPurchase.Checked)
                sw = "purchase";
            else if (optInvoices.Checked)
                sw = "invoice";
            else if (optRMAs.Checked)
                sw = "rma";
            else if (optVRMA.Checked)
                sw = "vendrma";
            else if (optService.Checked)
                sw = "service";
            if (Tools.Strings.StrExt(sw))
                sw = "base_company_uid = '" + CurrentCompany.unique_id + "' and ordertype = '" + sw + "'";
            else
                sw = "base_company_uid = '" + CurrentCompany.unique_id + "'";
            result_orders.ShowTemplate("COMPANYORDERS", "ordhed", RzWin.User.TemplateEditor);
            result_orders.ShowData("ordhed", sw, "orderdate desc", result_orders.UnlimitedResults ? -1 : SysNewMethod.ListLimitDefault);
        }
        private void ShowOrderLines()
        {
            if (optAll.Checked)
            {
                result_orders.ShowTemplate("COMPANYORDERDETAILS_all", "orddet_line", RzWin.User.TemplateEditor);
                result_orders.ShowData("orddet_line", "customer_uid = '" + CurrentCompany.unique_id + "' or vendor_uid = '" + CurrentCompany.unique_id + "'", "orderdate_sales desc", result_orders.UnlimitedResults ? -1 : SysNewMethod.ListLimitDefault);
                return;
            }
            if (optQuote.Checked)
            {
                result_orders.ShowTemplate("COMPANYORDERDETAILS", "orddet", RzWin.User.TemplateEditor);
                result_orders.ShowData("orddet", "base_company_uid = '" + CurrentCompany.unique_id + "' and ordertype = 'quote'", "orderdate desc", result_orders.UnlimitedResults ? -1 : SysNewMethod.ListLimitDefault);
                return;
            }
            String sw = "";
            if (optSales.Checked)
                sw = "sales";
            else if (optPurchase.Checked)
                sw = "purchase";
            else if (optInvoices.Checked)
                sw = "invoice";
            else if (optRMAs.Checked)
                sw = "rma";
            else if (optVRMA.Checked)
                sw = "vendrma";
            else if (optService.Checked)
                sw = "service";
            switch (sw.ToLower().Trim())
            {
                case "sales":
                    result_orders.ShowTemplate("COMPANYORDERDETAILS_sales", "orddet_line", RzWin.User.TemplateEditor);
                    result_orders.ShowData("orddet_line", "customer_uid = '" + CurrentCompany.unique_id + "' and len(isnull(orderid_sales,'')) > 0", "orderdate_sales desc", result_orders.UnlimitedResults ? -1 : SysNewMethod.ListLimitDefault);
                    break;
                case "purchase":
                    result_orders.ShowTemplate("COMPANYORDERDETAILS_purchase", "orddet_line", RzWin.User.TemplateEditor);
                    result_orders.ShowData("orddet_line", "vendor_uid = '" + CurrentCompany.unique_id + "' and len(isnull(orderid_purchase,'')) > 0", "orderdate_purchase desc", result_orders.UnlimitedResults ? -1 : SysNewMethod.ListLimitDefault);
                    break;
                case "invoice":
                    result_orders.ShowTemplate("COMPANYORDERDETAILS_invoice", "orddet_line", RzWin.User.TemplateEditor);
                    result_orders.ShowData("orddet_line", "customer_uid = '" + CurrentCompany.unique_id + "' and len(isnull(orderid_invoice,'')) > 0", "orderdate_invoice desc", result_orders.UnlimitedResults ? -1 : SysNewMethod.ListLimitDefault);
                    break;
                case "rma":
                    result_orders.ShowTemplate("COMPANYORDERDETAILS_rma", "orddet_line", RzWin.User.TemplateEditor);
                    result_orders.ShowData("orddet_line", "customer_uid = '" + CurrentCompany.unique_id + "' and len(isnull(orderid_rma,'')) > 0", "orderdate_rma desc", result_orders.UnlimitedResults ? -1 : SysNewMethod.ListLimitDefault);
                    break;
                case "vendrma":
                    result_orders.ShowTemplate("COMPANYORDERDETAILS_vendrma", "orddet_line", RzWin.User.TemplateEditor);
                    result_orders.ShowData("orddet_line", "vendor_uid = '" + CurrentCompany.unique_id + "' and len(isnull(orderid_vendrma,'')) > 0", "orderdate_vendrma desc", result_orders.UnlimitedResults ? -1 : SysNewMethod.ListLimitDefault);
                    break;
                case "service":
                    result_orders.ShowTemplate("COMPANYORDERDETAILS_service", "orddet_line", RzWin.User.TemplateEditor);
                    result_orders.ShowData("orddet_line", "service_vendor_uid = '" + CurrentCompany.unique_id + "' and len(isnull(orderid_service,'')) > 0", "orderdate_service desc", result_orders.UnlimitedResults ? -1 : SysNewMethod.ListLimitDefault);
                    break;
                default:
                    break;
            }
        }
        private void tsl_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoResize();

            if (tsl.SelectedTab == pageContacts)
                ShowContacts();

            if (tsl.SelectedTab == this.pageAddresses)
                ShowAddresses();

            if (tsl.SelectedTab == tabAccounts)
                ShowShippingAccounts();

            if (tsl.SelectedTab == pageReqs)
                ShowReqs();

            if (tsl.SelectedTab == pageBatches)
                ShowReqBatches();

            if (tsl.SelectedTab == tabQuotes)
                ShowQuotes();

            if (tsl.SelectedTab == pageBids)
                ShowBids();

            if (tsl.SelectedTab == tabOrders)
            {
                SetOptions();
                ShowOrders();
            }

            if (tsl.SelectedTab == pageNotes)
                ShowNotes();

            if (tsl.SelectedTab == tabCalls)
                ShowCalls();

            if (tsl.SelectedTab == tabPortalSearches)
                LoadPortalSearches();

            if (tsl.SelectedTab == tabExcess)
                ShowExcess();

            if (tsl.SelectedTab == tabFeedback)
                ShowFeedback();
        }
        private void result_addresses_Load(object sender, EventArgs e)
        {

        }
        private void ShowFeedback()
        {
            try
            {
                lvFeedback.Init(CurrentCompany.FeedbackArgsGet(RzWin.Context));
                //lvFeedback.Clear();
                //lvFeedback.ShowData("feedback", "the_company_uid = '" + CurrentCompany.unique_id + "'", "date_created desc", 200);
            }
            catch (Exception)
            {
            }
        }
        private void ShowExcess()
        {
            try
            {
                //if(Rz3App.xLogic.IsPMT)
                //{
                //    ShowPMTExcess();
                //    return;
                //}
                lvExcess.Clear();
                String classname = "";
                if (optExcess.Checked)
                {
                    lvExcess.Init(CurrentCompany.ExcessArgsGet(RzWin.Context));
                    //classname = "partrecord";
                    //lvExcess.ShowTemplate("company_excessview", "partrecord", Rz3App.xUser.TemplateEditor);
                }
                else
                {
                    classname = "offer";
                    lvExcess.ShowTemplate("company_archivedview", "offer", RzWin.User.TemplateEditor);
                    lvExcess.ShowData(classname, "( base_company_uid = '" + CurrentCompany.unique_id + "' or companyname = '" + RzWin.Context.Filter(CurrentCompany.companyname) + "') ", "date_created desc", 200);
                }
            }
            catch (Exception)
            {
            }
        }
        private void ShowNotes()
        {
            if (optStandard.Checked)
            {
                lvNotes.Init(CurrentCompany.NotesArgsGet(RzWin.Context));
                //lvNotes.ShowTemplate("companynotes", "contactnote", Rz3App.xUser.TemplateEditor);
                //lvNotes.ShowData("contactnote", "base_company_uid = '" + CurrentCompany.unique_id + "'", "NOTEDATE DESC", 200);
            }
            else
            {
                lvNotes.Init(CurrentCompany.UserNoteArgsGet(RzWin.Context));
            }
        }
        private void SetOptions()
        {
            //if( !Rz3App.xLogic.IsAtometron )
            //    return;
            //if( CurrentCompany.isvendor )
            //    optPurchase.Checked = true;
            //else if( CurrentCompany.iscustomer )
            //    optInvoices.Checked = true;
        }
        private void ShowCalls()
        {
            lvCalls.Init(CurrentCompany.CallArgsGet(RzWin.Context));
            //lvCalls.ShowTemplate("calllog", "calllog", Rz3App.xUser.TemplateEditor);
            //lvCalls.ShowData("calllog", "base_company_uid = '" + CurrentCompany.unique_id + "'", "DATECALL DESC", 200);
        }

        private void view_company_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        protected override void DoResize()
        {
            base.DoResize();
            try
            {
                tsl.Height = this.ClientRectangle.Height - tsl.Top;
                tsl.Width = this.ClientRectangle.Width - (tsl.Left + 300);

                gbOrderOptions.Top = 0;
                gbOrderOptions.Height = this.ClientRectangle.Height;

                result_orders.Left = gbOrderOptions.Right + 5;
                result_orders.Width = tabOrders.ClientRectangle.Width - result_orders.Left;
                result_orders.Top = 0;
                result_orders.Height = tabOrders.ClientRectangle.Height;

                gbBid.Left = 0;
                gbBid.Top = 0;
                gbBid.Width = pageBids.ClientRectangle.Width;

                result_bids.Left = 0;
                result_bids.Top = gbBid.Bottom;
                result_bids.Height = pageBids.ClientRectangle.Height - result_bids.Top;
                result_bids.Width = pageBids.ClientRectangle.Width;

                gbExcessOptions.Left = 0;
                gbExcessOptions.Top = 0;
                gbExcessOptions.Width = tabExcess.ClientRectangle.Width;

                lvExcess.Left = 0;
                lvExcess.Top = gbExcessOptions.Bottom;
                lvExcess.Height = tabExcess.ClientRectangle.Height - lvExcess.Top;
                lvExcess.Width = tabExcess.ClientRectangle.Width;

                lvNotes.Left = 0;
                lvNotes.Top = optStandard.Bottom;
                lvNotes.Width = pageNotes.ClientRectangle.Width;
                lvNotes.Height = pageNotes.ClientRectangle.Height - lvNotes.Top;

                nListVendorCredits.Left = 0;
                nListVendorCredits.Top = 0;
                nListVendorCredits.Width = tabCompanyCredits.ClientRectangle.Width;
                nListVendorCredits.Height = tabCompanyCredits.ClientRectangle.Height;

                lvPortalSearches.Left = 0;
                lvPortalSearches.Top = 0;
                lvPortalSearches.Width = tabPortalSearches.ClientRectangle.Width;
                lvPortalSearches.Height = tabPortalSearches.ClientRectangle.Height;

                consignmentCodes.Left = 0;
                consignmentCodes.Top = 0;
                consignmentCodes.Width = tabConsignCodes.ClientRectangle.Width;
                consignmentCodes.Height = tabConsignCodes.ClientRectangle.Height;


                if (RzWin.Logic.UseMergedQuotes)
                {
                    lvQuotes.Left = 0;
                    lvQuotes.Top = 0;
                    lvQuotes.Width = tabQuotes.ClientRectangle.Width;
                    lvQuotes.Height = tabQuotes.ClientRectangle.Height;

                    result_fquotes.Left = 0;
                    result_fquotes.Top = 0;
                    result_fquotes.Width = tabQuotes.ClientRectangle.Width;
                    result_fquotes.Height = tabQuotes.ClientRectangle.Height;

                }
                else
                {

                    result_qquotes.Left = 0;
                    result_qquotes.Top = 0;
                    result_qquotes.Width = tabQuotes.ClientRectangle.Width;
                    result_qquotes.Height = Convert.ToInt32(tabQuotes.ClientRectangle.Height / 2);

                    gbQuoteOptions.Left = 0;
                    gbQuoteOptions.Top = 0;
                    gbQuoteOptions.Width = panelAtometronQuote.ClientRectangle.Width;
                    lvQuotes.Left = 0;
                    lvQuotes.Top = gbQuoteOptions.Bottom;
                    lvQuotes.Height = panelAtometronQuote.ClientRectangle.Height - lvQuotes.Top;
                    lvQuotes.Width = panelAtometronQuote.ClientRectangle.Width;
                }
            }
            catch (Exception)
            {
            }
        }
        private void optAll_CheckedChanged(object sender, EventArgs e)
        {
            ShowOrders();
        }
        private void result_contacts_AboutToAdd(object sender, AddArgs args)
        {
            args.Handled = true;
            companycontact c = CurrentCompany.AddContact(RzWin.Context);
            //handled by AddContact
            //c.ISave();
            RzWin.Context.Show(c);
            //CurrentCompany.Show(new ShowArgs(c, false, false, true, false, false));
        }
        private void result_addresses_AboutToAdd(object sender, AddArgs args)
        {
            args.Handled = true;
            companyaddress c = CurrentCompany.AddAddress(RzWin.Context);
            //handled by AddAddress
            //c.ISave();
            RzWin.Context.Show(c);
            //CurrentCompany.Show(new ShowArgs(c, false, false, true, false, false));
        }
        private void result_accounts_AboutToAdd(object sender, AddArgs args)
        {
            args.Handled = true;
            shippingaccount c = shippingaccount.New(RzWin.Context);
            c.base_company_uid = CurrentCompany.unique_id;
            c.Insert(RzWin.Context);
            RzWin.Context.Show(c);
            //CurrentCompany.Show(new ShowArgs(c, false, false, true, false, false));
        }
        private void result_reqs_AboutToAdd(object sender, AddArgs args)
        {
            //args.Handled = true;
            //if (Rz3App.xLogic.UseMergedQuotes)
            //{
            //    dealheader.ShowManualDeal(Rz3App.xMainForm.TheContextNM, CurrentCompany, null);
            //}
            //else
            //{
            //    req c = CurrentCompany.AddReq();
            //    c.ISave();
            //    CurrentCompany.Show(new ShowArgs(c, false, false, true, false, false));
            //}
        }
        private void result_reqbatches_AboutToAdd(object sender, AddArgs args)
        {
            args.Handled = true;
            //if (RzLicense.LicenseType == LicenseTypes.Custom && !Rz3App.xLogic.UseMergedQuotes)
            //{
            //    reqbatch c = CurrentCompany.AddReqBatch();
            //    c.ISave();
            //    CurrentCompany.Show(new ShowArgs(c, false, false, true, false, false));
            //}
            //else
            dealheader.ShowManualDeal(RzWin.Context, CurrentCompany, null);
        }
        private void result_qquotes_AboutToAdd(object sender, AddArgs args)
        {
            //args.Handled = true;
            //quote c = CurrentCompany.AddQuote(Enums.QuoteType.GivingOut);
            //c.ISave();
            //CurrentCompany.Show(new ShowArgs(c, false, false, true, false, false));
        }
        private void result_bids_AboutToAdd(object sender, AddArgs args)
        {
            //args.Handled = true;
            //quote c = CurrentCompany.AddQuote(Enums.QuoteType.Receiving);
            //c.ISave();
            //CurrentCompany.Show(new ShowArgs(c, false, false, true, false, false));
        }
        public virtual void CheckExtraScroll()
        {

        }
        private void ts_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ts.SelectedIndex)
            {
                case 5:
                    LoadAutoArchiveTab();
                    break;
            }
        }
        private void LoadAutoArchiveTab()
        {
            bLoading = true;
            if (CurrentCompany.archiveperiod <= 0)
                optNoArchive.Checked = true;
            else
            {
                if (CurrentCompany.archiveperiod > 365)
                    udArchivePeriod.Value = 1;
                else
                    udArchivePeriod.Value = CurrentCompany.archiveperiod;
                optArchive.Checked = true;
            }
            if (CurrentCompany.delete_archives_period <= 0)
            {
                optToDelete.Checked = false;
                udDeleteArchivePeriod.Value = 1;
            }
            else
            {
                optToDelete.Checked = true;
                if (CurrentCompany.delete_archives_period > 365)
                    udDeleteArchivePeriod.Value = 1;
                else
                    udDeleteArchivePeriod.Value = CurrentCompany.delete_archives_period;
            }
            bLoading = false;
        }
        private void UpdateArchiveValues()
        {
            try
            {
                CurrentCompany.delete_oldoffers = optToDelete.Checked;
                CurrentCompany.archivetimespan = "day";
                if (!optArchive.Checked)
                    CurrentCompany.archiveperiod = 0;
                else
                    CurrentCompany.archiveperiod = (Int64)udArchivePeriod.Value;

                CurrentCompany.delete_archives = ctl_delete_archives.GetValue_Boolean();
                CurrentCompany.delete_archives_period = (Int64)udDeleteArchivePeriod.Value;
                CurrentCompany.Update(RzWin.Context);
            }
            catch (Exception)
            {
            }
        }
        private void optArchive_CheckedChanged(object sender, EventArgs e)
        {
            if (!bLoading)
                UpdateArchiveValues();
            if (optArchive.Checked)
            {
                gbArchiveSettings.Enabled = true;
                gbArchiveDeleteSettings.Enabled = true;
                if (CurrentCompany.archiveperiod > 0 && CurrentCompany.archiveperiod < 366)
                    udArchivePeriod.Value = CurrentCompany.archiveperiod;
                else
                    udArchivePeriod.Value = 1;
            }
        }
        private void optNoArchive_CheckedChanged(object sender, EventArgs e)
        {
            if (!bLoading)
                UpdateArchiveValues();
            if (optNoArchive.Checked)
            {
                gbArchiveSettings.Enabled = false;
                gbArchiveDeleteSettings.Enabled = false;
                udArchivePeriod.Value = 1;
                optToArchive.Checked = true;
                udDeleteArchivePeriod.Value = 0;
                ctl_delete_archives.SetValue(false);
            }
        }
        private void optToDelete_CheckedChanged(object sender, EventArgs e)
        {
            if (bLoading)
                return;
            UpdateArchiveValues();
        }
        private void udArchivePeriod_ValueChanged(object sender, EventArgs e)
        {
            if (bLoading)
                return;
            UpdateArchiveValues();
        }
        private void optToArchive_CheckedChanged(object sender, EventArgs e)
        {
            if (bLoading)
                return;
            UpdateArchiveValues();
        }
        private void lvNotes_AboutToAdd(object sender, AddArgs args)
        {
            args.Handled = true;
            if (optStandard.Checked)
            {
                contactnote n = CurrentCompany.CreateNewContactNote(RzWin.Context);
                n.base_mc_user_uid = RzWin.User.unique_id;
                n.agentname = RzWin.User.name;
                n.notedate = System.DateTime.Now;
                n.Update(RzWin.Context);
                TheContext.Show(n);
            }
            else
            {
                CurrentCompany.ShowNewNote(RzWin.Context);
            }
        }
        private void optActualBids_CheckedChanged(object sender, EventArgs e)
        {
            ShowBids();
        }
        private void lvCalls_AboutToAdd(object sender, AddArgs args)
        {
            args.Handled = true;
            calllog n = calllog.New(RzWin.Context);
            n.base_company_uid = CurrentCompany.unique_id;
            n.callcompanyname = CurrentCompany.companyname;
            n.base_mc_user_uid = RzWin.User.unique_id;
            n.agentname = RzWin.User.name;
            n.datecall = System.DateTime.Now;
            n.contactname = CurrentCompany.primarycontact;
            n.Insert(RzWin.Context);
            TheContext.Show(n);
        }
        private void ctl_companytype_DataChanged(GenericEvent e)
        {
            //try
            //{
            //    if(Rz3App.xLogic.IsPMT)
            //    {
            //        cType.bAltType = true;
            //        cType.SetType((String)ctl_companytype.GetValue());
            //    }
            //}
            //catch(Exception)
            //{
            //}
        }
        private void optExcess_CheckedChanged(object sender, EventArgs e)
        {
            ShowExcess();
        }
        private void optArchivedExcess_CheckedChanged(object sender, EventArgs e)
        {
            ShowExcess();
        }
        private void lvFeedback_AboutToAdd(object sender, AddArgs args)
        {
            args.Handled = true;
            if (CurrentCompany == null)
                return;
            frmFeedback xFeed = new frmFeedback();
            if (xFeed.CompleteLoad(CurrentCompany))
            {
                xFeed.ShowDialog();
                FeedbackControl.CompleteLoad(CurrentCompany);
            }
        }
        private void lvFeedback_AboutToThrow(Context x, ShowArgs args)
        {
            args.Handled = true;
            feedback f = (feedback)lvFeedback.GetSelectedObject();
            if (f == null)
                return;
            if (CurrentCompany == null)
                return;
            frmFeedback xFeed = new frmFeedback();
            if (xFeed.CompleteLoad(CurrentCompany, f))
                xFeed.ShowDialog();
        }



        private void optStandard_CheckedChanged(object sender, EventArgs e)
        {
            if (Object.ReferenceEquals(tsl.SelectedTab, pageNotes))
                ShowNotes();
        }
        private void optUserNotes_CheckedChanged(object sender, EventArgs e)
        {
            if (Object.ReferenceEquals(tsl.SelectedTab, pageNotes))
                ShowNotes();
        }
        private void optQuickQuotes_CheckedChanged(object sender, EventArgs e)
        {
            ShowQuotes();
        }
        private void optFormalQuotes_CheckedChanged(object sender, EventArgs e)
        {
            ShowQuotes();
        }
        private void optOffers_CheckedChanged(object sender, EventArgs e)
        {
            ShowExcess();
        }
        private void cmdSendCreditCardifoToQBs_Click(object sender, EventArgs e)
        {
            SendCreditCardInfoToQBs();
        }
        private void cmdChangeCompany_Click_2(object sender, EventArgs e)
        {
            //Commented out by KT on 7-31-2014 - This is causing Rz to crash in my IDE with no exception to trace it with.  Don't see why the save is necessary at this point anyway.  Logged as a bug that I will tackle as time / necessity dictate.
            try
            {
                CompleteSave();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: '{0}'", ex);
            }
            String s = "";
            if (!company.ChangeCompanyName(RzWin.Context, CurrentCompany, ref s))
                return;
            CompleteLoad();
            RzWin.Leader.Comment("Loading...");
            RzWin.Logic.CacheCompanies(RzWin.Context);
            RzWin.Leader.Comment("Done.");
            RzWin.Leader.StopPopStatus(false);


        }
        private void cmdChangeCompany_Click(object sender, EventArgs e)
        {
            String s = RzWin.Leader.AskForString("Please enter the new company name:", CurrentCompany.companyname, "New Company Name");
            if (!Tools.Strings.StrExt(s))
                return;
            if (s == CurrentCompany.companyname)
                return;
            String d = company.DistillCompanyName(s);
            if (d.Length <= 4)
            {
                RzWin.Leader.Tell("The company name " + s + ", when common words are removed, becomes '" + d + "', which is too short for the unique portion of a company name.");
                return;
            }
            company c = (company)RzWin.Context.QtO("company", "select * from company where unique_id <> '" + CurrentCompany.unique_id + "' and (companyname = '" + RzWin.Context.Filter(s) + "' or distilledname = '" + RzWin.Context.Filter(d) + "')");
            if (c != null)
            {
                RzWin.Leader.Tell("At least 1 other company (" + c.companyname + ") already has a name that is too similar to '" + s + "'");
                return;
            }
            CompleteSave();
            CurrentCompany.companyname = s;
            CurrentCompany.Update(RzWin.Context);
            RzWin.Context.Execute("update companycontact set companyname = '" + RzWin.Context.Filter(s) + "' where base_company_uid = '" + CurrentCompany.unique_id + "'");
            CompleteLoad();
            RzWin.Logic.CacheCompanies(RzWin.Context);
        }
        private void ctl_delete_archives_CheckChanged(object sender)
        {
            udDeleteArchivePeriod.Enabled = ctl_delete_archives.GetValue_Boolean();
        }
        private void lblNotifyAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ArrayList a = frmChooseUser_Multiple.Choose(RzWin.Logic.SalesPeople, "Agent Selection");
            if (a == null)
                return;

            if (a.Count == 0)
                return;

            foreach (String s in a)
            {
                CurrentCompany.po_notify += s + "\r\n";
            }

            CurrentCompany.Update(RzWin.Context);
            ShowNotify();
        }
        void ShowNotify()
        {
            lblNotifyList.Text = CurrentCompany.po_notify;
        }
        private void lblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ArrayList a = frmChooseUser_Multiple.Choose(RzWin.Logic.SalesPeople, "Agent Selection");
            if (a == null)
                return;

            if (a.Count == 0)
                return;

            foreach (String s in a)
            {
                CurrentCompany.po_notify = nTools.Replace(CurrentCompany.po_notify, s + "\r\n", "");
            }

            CurrentCompany.Update(RzWin.Context);
            ShowNotify();
        }
        private void lblClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CurrentCompany.po_notify = "";
            CurrentCompany.Update(RzWin.Context);
            ShowNotify();
        }
        private void DoNotEmailContacts(bool email)
        {
            try
            {
                if (CurrentCompany == null)
                    return;
                ArrayList a = CurrentCompany.GetAllContacts(RzWin.Context);
                if (a == null)
                    return;
                foreach (companycontact c in a)
                {
                    c.donotemail = email;
                    c.Update(RzWin.Context);
                }
            }
            catch { }
        }
        private void ctl_donotemail_CheckChanged(object sender)
        {
            DoNotEmailContacts(ctl_donotemail.GetValue_Boolean());
        }

        //private void nEdit_Boolean2_Load(object sender, EventArgs e)
        //{

        //}

        private void LoadVendorCredits()
        {
            ListArgs args = new ListArgs(RzWin.Context);
            args.TheClass = "companycredit";
            args.TheLimit = 200;
            args.AddCaption = "Add New Vendor Credit";
            args.TheOrder = "date_created desc";
            args.TheTable = "companycredit";
            args.TheTemplate = "companycredit";
            //args.TheWhere = "base_company_uid = '" +CurrentOrder.base_company_uid+ "' AND is_applied = " + includeUsedCredits;
            args.TheWhere = "base_company_uid = '" + CurrentCompany.unique_id + "'";
            //if (!RzWin.Context.Sys.ThePermitLogic.CheckPermit(RzWin.Context, NewMethod.Permissions.ThePermits.AddOtherChargeCredit, RzWin.Context.xUser))
            args.AddAllow = false;
            nListVendorCredits.ShowData(args);


        }

        private void CheckPermissions()
        {
            //if (!RzWin.Context.CheckPermit("Company:Assign:CanAssignAllCompanies")) //!Rz3App.xLogic.IsCTG && 
            if (!(RzWin.Context.CheckPermit((Permissions.ThePermits).AssignCompanies)))
                user.Enabled = false;

            ctl_isverified.Enabled = ((SysRz5)RzWin.Context.xSys).ThePermitLogic.CheckPermit(RzWin.Context, (Permissions.ThePermits).CanApplyAVL, RzWin.Context.xUser);
            ctl_has_financials.Enabled = ((SysRz5)RzWin.Context.xSys).ThePermitLogic.CheckPermit(RzWin.Context, (Permissions.ThePermits).CanVerifyFinancials, RzWin.Context.xUser);
            //if (((SysRz5)RzWin.Context.xSys).ThePermitLogic.CheckPermit(RzWin.Context, (Permissions.ThePermits).CanViewCompanyQBTab, RzWin.Context.xUser) && !ts.TabPages.Contains(tabQB))
            //    ts.TabPages.Add(tabQB);
            //KT - Added Permission Checks for Scope of approval
            ctl_SOA_components.Enabled = ((SysRz5)RzWin.Context.xSys).ThePermitLogic.CheckPermit(RzWin.Context, (Permissions.ThePermits).CanSetScopeOfApproval, RzWin.Context.xUser);
            ctl_SOA_services.Enabled = ((SysRz5)RzWin.Context.xSys).ThePermitLogic.CheckPermit(RzWin.Context, (Permissions.ThePermits).CanSetScopeOfApproval, RzWin.Context.xUser);
            if (RzWin.Context.CheckPermit(NewMethod.Permissions.ThePermits.EditCompanyCreditLimits))
            {
                ctl_creditascustomer.zz_Enabled = true;
                ctl_creditasvendor.zz_Enabled = true;
            }
            cbx_is_vetted.Enabled = ((SysRz5)RzWin.Context.xSys).ThePermitLogic.CheckPermit(RzWin.Context, (Permissions.ThePermits).CanVetSuppliers, RzWin.Context.xUser);
            gbCustomer.Enabled = ((SysRz5)RzWin.Context.xSys).ThePermitLogic.CheckPermit(RzWin.Context, (Permissions.ThePermits).CanSetCustomerTerms, RzWin.Context.xUser);
            gbVendor.Enabled = ((SysRz5)RzWin.Context.xSys).ThePermitLogic.CheckPermit(RzWin.Context, (Permissions.ThePermits).CanSetVendorTerms, RzWin.Context.xUser);
            ctl_problem_vendor.Enabled = ((SysRz5)RzWin.Context.xSys).ThePermitLogic.CheckPermit(RzWin.Context, (Permissions.ThePermits).CanSetProblemVendor, RzWin.Context.xUser);



            ctl_is_locked.Enabled = ((SysRz5)RzWin.Context.xSys).ThePermitLogic.CheckPermit(RzWin.Context, (Permissions.ThePermits).CanLockCompanies, RzWin.Context.xUser);
            ctl_islocked_purchase.Enabled = ((SysRz5)RzWin.Context.xSys).ThePermitLogic.CheckPermit(RzWin.Context, (Permissions.ThePermits).CanLockCompanies, RzWin.Context.xUser);


        }

        protected void StartProblemCustomerTimer()
        {
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Enabled = false;
            timer.Start();

            if (CurrentCompany.is_problem)
            {
                lblProblemCustomer.Visible = true;
                lblProblemCustomer.BringToFront();
                lblProblemCustomer.ForeColor = Color.Red;
                timer.Tick += new EventHandler(timer_Tick);
            }
            else
            {
                timer.Tick -= timer_Tick;
                lblProblemCustomer.Visible = false;
            }
            if (CurrentCompany.problem_vendor)
            {
                lblProblemVendor.Visible = true;
                lblProblemVendor.BringToFront();
                lblProblemVendor.ForeColor = Color.Red;
                timer.Tick += new EventHandler(timer_Tick);
            }
            else
            {
                timer.Tick -= timer_Tick;
                lblProblemVendor.Visible = false;
            }


        }
        protected void timer_Tick(object sender, EventArgs e)
        {
            if (lblProblemCustomer.ForeColor == Color.Black)
            {
                lblProblemCustomer.ForeColor = Color.Red;
                lblProblemVendor.ForeColor = Color.Red;
            }


            else
            {
                lblProblemCustomer.ForeColor = Color.Black;
                lblProblemVendor.ForeColor = Color.Black;
            }

        }

        protected void GetOutstandingARAP()
        {

            double d = RzWin.Context.TheSysRz.TheCompanyLogic.CalculateOutstandingBalance_Company(RzWin.Context, CurrentCompany);
            if (d > 0)
                lblOutstandingInvoiceAmnt.Text = "Outstanding Balance: " + d.ToString("C");
            else
                lblOutstandingInvoiceAmnt.Visible = false;
        }

        private void GetVendorCredits()
        {
            double d = RzWin.Context.TheSysRz.TheCompanyLogic.GetVendorCredits(RzWin.Context, CurrentCompany);
            if (d > 0)
                lblVendorCredits.Text = "Vendor Credits: " + d.ToString("C");
            else
                lblVendorCredits.Visible = false;
        }


        private void GetPortalSearchCount()
        {
            int totalSearches = RzWin.Context.SelectScalarInt32("select Count(*) from portal_searched_part where company_uid = '" + CurrentCompany.unique_id + "' AND is_internal != 1");
            tabPortalSearches.Text = "Portal Searches (" + totalSearches.ToString() + ")";
        }

        private void LoadPortalSearches()
        {
            //Since I want to group by request count, SearchArgs won't work (Can't do counts / aggreagates, only groups I don't think)
            //I had to create my own query, then manually add the required listview items (grid_color, icon_index) as well
            string sql = "select count(*) As searchCount, fullpartnumber, manufacturer, description, companyname, contactname,MAX(date_Created) [last_search_date], grid_color, icon_index from portal_searched_part where company_uid = '" + CurrentCompany.unique_id + "' AND is_internal != 1 group by fullpartnumber, manufacturer, description, companyname, contactname, grid_color, icon_index ";
            lvPortalSearches.Clear();
            lvPortalSearches.ShowTemplate("portal_searched_part", "portal_searched_part");
            lvPortalSearches.ShowData("portal_searched_part", sql);
        }

        private void ctl_date_code_restriction_CheckedChanged(object sender, EventArgs e)
        {
            ctl_date_code_restriction_detail.Enabled = ctl_date_code_restriction.Checked;
        }

        private void ctl_packaging_requirements_CheckedChanged(object sender, EventArgs e)
        {
            ctl_packaging_requirements_detail.Enabled = ctl_packaging_requirements.Checked;

        }

        private void ctl_testing_restriction_CheckedChanged(object sender, EventArgs e)
        {
            ctl_testing_restriction_detail.Enabled = ctl_testing_restriction.Checked;
        }

        private void btnCheckCreditLimit_Click(object sender, EventArgs e)
        {
            RzWin.Context.TheSysRz.TheCompanyLogic.CalculateOutstandingBalance_Company(RzWin.Context, CurrentCompany, true);

        }
    }
}