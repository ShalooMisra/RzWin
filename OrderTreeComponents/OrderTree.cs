using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Core;
using NewMethod;
using System.Drawing;
using System.Data;
using HubspotApis;
using System.Linq;
using SensibleDAL;
using SensibleDAL.dbml;

namespace Rz5
{
    public partial class OrderTree : nView
    {
        //Public Variables
        public dealheader xDeal;
        //Protected Variables
        protected orddet_quote TheReq;
        protected orddet_quote TheQuote;
        protected nObject TheShowObject;
        protected bool FillFinished = false;
        protected string is_sale = "";
        protected string is_invoice = "";
        protected string pipelineStage = "";
        protected company CurrentCompany;
        protected companycontact CurrentCompanyContact;
        //protected NewMethod.n_user CurrentBatchAgent;
        //protected NewMethod.n_user CurrentSplitAgent;
        //protected string SplitCommissionType;
        protected split_commission sc;
        HubspotApi.Deal TheHubspotDeal = null;



        //Constructors
        public OrderTree()
        {
            InitializeComponent();
            if (RzWin.Context != null)
                RzWin.Context.TheSys.Changed += new DeltaHandler(TheSys_Changed);
        }
        ~OrderTree()
        {
            RzWin.Context.TheSys.Changed -= new DeltaHandler(TheSys_Changed);
        }
        void TheSys_Changed(Context x, ChangeArgs args)
        {
            TheSysChanged(x, args);
        }

        //Public Override Functions
        public override void Init(Item item)
        {
            IsLoading = true;
            base.Init(item);
            xDeal = (dealheader)GetCurrentObject();
            xDeal.Init(RzWin.Context);
            CurrentCompany = xDeal.CustomerObjectGet(RzWin.Context);
            CurrentCompanyContact = xDeal.ContactObjectGet(RzWin.Context);
            CheckActiveCustomerFinancials();

            if (string.IsNullOrEmpty(xDeal.base_mc_user_uid))
                SetInitialBatchAgent();
            //if (!string.IsNullOrEmpty(CurrentCompany.split_commission_agent_uid))
            //    RzWin.Context.TheSysRz.TheQuoteLogic.SetSplitCommission(RzWin.Context, xDeal.base_mc_user_uid, xDeal, CurrentCompany.split_commission_agent_uid, CurrentCompany.split_commission_default_type);

            LoadReqQuoteLV();
            LoadBlankBidLV();
            SetInitialSelection();
            SetCompanySplitCommission();
            IsLoading = false;
        }

        private void CheckActiveCustomerFinancials()
        {
            if (CurrentCompany == null)
                return;

            //CurrentlyVerified:
            //If the company has financials, AND the last sale date was less than 3 years ago, then true
            //else, set hasFinancials = false, and alert user.
            if (CurrentCompany.has_financials)
            {
                DateTime lastSale = RzWin.Context.SelectScalarDateTime("select MAX(orderdate) from ordhed_sales where base_company_uid = '" + CurrentCompany.unique_id + "' ");
                if (lastSale <= DateTime.Today.AddYears(-3))
                {
                    CurrentCompany.has_financials = false;
                    CurrentCompany.Update(RzWin.Context);
                    RzWin.Context.Leader.Tell("The last purchase date for " + CurrentCompany.companyname + " was " + lastSale.ToShortDateString() + " which is greater than 3 years ago.  You shouldf re-verify financials ASAP to avoid processing delays with this order.");
                }
            }
        }

        private void SetInitialBatchAgent()
        {

            //IF Tabitha, set Tabitha, still set Split
            //Example, if Davi

            //Get cuerrent system User info
            lblAgent.Text = RzWin.Context.xUser.name;
            xDeal.base_mc_user_uid = RzWin.Context.xUser.unique_id;
            xDeal.agentname = RzWin.Context.xUser.name;

            if (RzWin.Context.CheckPermit(Permissions.ThePermits.EditAllReqs_Quotes))//If the Current User cannot manage the agent
            {
                ////Set to choose, allow user to choose.
                //lblAgent.Text = "< Choose... >";
                lblAgent.Enabled = true;
            }

            //Update the line items (if any)
            foreach (orddet_quote q in xDeal.GetAllOrddetQuotes(RzWin.Context))
            {
                if (q.base_mc_user_uid != xDeal.base_mc_user_uid)
                {
                    q.base_mc_user_uid = xDeal.base_mc_user_uid;
                    q.agentname = xDeal.agentname;
                    q.Update(RzWin.Context);
                }
            }

            xDeal.Update(RzWin.Context);
        }

        public override void CompleteLoad()
        {
            IsLoading = true;
            base.CompleteLoad();
            CompleteLoad_Company();
            ctlName.SetValue(xDeal.dealheader_name);
            ctlNotes.SetValue(xDeal.notes);
            dl.xDeal = xDeal;
            dl.il = il;
            dl.ArrangeControls();
            dl.SavedObject += new EventHandler(dl_SavedObject);
            //Agent Name
            lblAgent.Enabled = RzWin.Context.CheckPermit(Permissions.ThePermits.EditAllReqs_Quotes);
            lblAgent.Text = xDeal.agentname;
            lblCompleteDelete.Visible = RzWin.User.IsDeveloper();
            chkIsSourced.SetValue(xDeal.is_sourced);





            if (CurrentCompany != null)
            {
                StartProblemCustomerTimer();
                GetOutstandingARAP();

            }
            if (CurrentCompany.is_locked)
                cmdQuote.Visible = false;
            else
                cmdQuote.Visible = true;

            LoadOemProduct();
            CompleteLoadHubspot();
            CompleteLoadOpportunity();
            CompleteLoadSplitCommission();



            DoResize();
            IsLoading = false;
        }


        public override void CompleteSave()
        {
            try
            {
                if (string.IsNullOrEmpty(xDeal.base_mc_user_uid))
                    throw new Exception("Please select a Batch Agent");
                CompleteSaveCompanyContact();
                IsLoading = true;
                xDeal.dealheader_name = ctlName.GetValue_String();
                xDeal.is_approved = ctlApproved.GetValue_Boolean();
                xDeal.notes = ctlNotes.GetValue_String();
                ctlName.ClearInfo();
                ctlApproved.ClearInfo();
                ctlNotes.ClearInfo();
                ctlName.SetValue(xDeal.dealheader_name);
                CompleteSaveBOM();
                //Loop through all parts, craete a 
                SetInternalPartsField();
                //CompleteLoadSplitCommission();                
                CompleteSaveOpportunity();
                xDeal.Update(RzWin.Context);

                LoadReqQuoteLV();
                IsLoading = false;

                //CheckAddressExists();

            }
            catch (Exception ex)
            {
                IsLoading = false;
                RzWin.Leader.Error(ex.Message);
                return;
            }
        }

        private void SetCompanySplitCommission()
        {
            if (!string.IsNullOrEmpty(CurrentCompany.split_commission_ID))
                if (string.IsNullOrEmpty(xDeal.split_commission_ID))
                {
                    xDeal.split_commission_ID = CurrentCompany.split_commission_ID;
                    xDeal.Update(RzWin.Context);
                }
        }

        private void CompleteLoadSplitCommission()
        {
            llSplitAgent.Enabled = RzWin.Context.xUser.CheckPermit(RzWin.Context, Permissions.ThePermits.CanManageCommission);
            llSplitAgent.Text = "< Choose... >";
            //Neither the company nor deal have a split ID, do nothing.
            if (string.IsNullOrEmpty(xDeal.split_commission_ID))
                return;
            sc = split_commission.GetById(RzWin.Context, xDeal.split_commission_ID);
            if (sc != null)
                llSplitAgent.Text = sc.split_commission_agent + "(" + sc.split_commission_percent + "%)";
        }

        private void CompleteLoadOpportunity()
        {
            //string oppStage = xDeal.opportunity_stage;
            if (string.IsNullOrEmpty(xDeal.opportunity_stage))
            {
                xDeal.opportunity_stage = SM_Enums.OpportunityStage.rfq_received.ToString();
                xDeal.Update(RzWin.Context);
            }
            lblOppStage.Text = xDeal.opportunity_stage;
            ctl_isLost.zz_CheckValue = xDeal.opportunity_stage.ToLower().Contains("lost");
        }

        private void CompleteLoadHubspot()
        {
            llEditHubspotDeal.Visible = false;
            //llblDealLink.Visible = false;
            //if (TheHubspotDeal == null)
            TheHubspotDeal = RzWin.Context.TheSysRz.TheOrderLogic.LoadHubspotDealControls(RzWin.Context, gbHubspot, llblDealLink, xDeal);
            if (TheHubspotDeal != null)
                llEditHubspotDeal.Visible = (RzWin.Context.CheckPermit(Permissions.ThePermits.CanManageHubspot));



        }



        private void dl_SavedObject(object sender, EventArgs e)
        {
            //Init(xDeal);
            LoadReqQuoteLV();
        }




        private void CompleteSaveBOM()
        {
            bool changed = false;
            bool is_bom = false;
            if (ctl_is_bom.zz_CheckValue == true)
                is_bom = true;
            if (xDeal.is_bom != is_bom)
            {
                xDeal.is_bom = is_bom;
                changed = true;
            }

            foreach (orddet_quote q in xDeal.GetAllOrddetQuotes(RzWin.Context))
            {
                if (q.is_bom != is_bom)
                {
                    changed = true;
                    q.is_bom = is_bom;
                    q.Update(RzWin.Context);

                }
            }
            //xDeal.Update(RzWin.Context); 
            if (changed)
            {
                LoadReqQuoteLV();
            }
        }


        private void CompleteSaveCompanyContact()
        {


            //Confirm Valid Company Contact
            companycontact c = companycontact.GetById(RzWin.Context, CompList.ContactID);
            if (c == null)
            {
                frmChooseContact xForm = new frmChooseContact();
                xForm.Text = "Please choose a contact for this Batch.";
                xForm.LoadContacts(xDeal.customer_uid);
                xForm.ShowDialog();

                string strContactID = xForm.SelectedID;
                c = companycontact.GetById(RzWin.Context, strContactID);

            }

            if (c == null)
                throw new Exception("Cannot Save Batch.  Please set a valid contact.");

            string emailAddress = c.primaryemailaddress;
            if (string.IsNullOrEmpty(emailAddress))
                emailAddress = RzWin.Context.Leader.AskForString("There doesn't appear to be a valid email for " + c.contactname + ".  You must set a valid email before saving.  Please do so now.");


            if (!Tools.Email.IsEmailAddress(emailAddress))
            {
                RzWin.Context.Leader.Error("'" + emailAddress + "' is not a valid email address.");
                return;
            }

            c.primaryemailaddress = emailAddress;
            c.Update(RzWin.Context);
            xDeal.contact_name = c.contactname;
            xDeal.contact_uid = c.unique_id;
            CompList.SetCompany(xDeal.customer_name, xDeal.customer_uid, xDeal.contact_name, xDeal.contact_uid);

            //If Valid COmpany Contact, confirm Valid Email Address


        }

        private void ManageHubspotCompanyLinkage(bool askConfirm = false)
        {



            ContextRz x = RzWin.Context;

            //Ensure CompList != null
            if (CompList == null)
                return;

            //Get the contact ID for the lookup.
            string contactID = CompList.GetContactID();
            if (string.IsNullOrEmpty(contactID))
                return;
            CurrentCompanyContact = companycontact.GetById(RzWin.Context, contactID);
            if (CurrentCompanyContact.hubspot_contact_id > 0 && CurrentCompany.hubspot_company_id > 0)
                return;


            if (string.IsNullOrEmpty(contactID))
            {
                //RzWin.Leader.Error(contactID + " is an invalid Rz Contact ID");
                return;
            }

            //Confirm valid Rz Contact Email.
            string contactEmail = CurrentCompanyContact.primaryemailaddress;
            if (!Tools.Email.IsEmailAddress(contactEmail))
            {
                //x.Leader.Error(contactEmail + " is not a valid email address.  Cannot identify Hubspot company.");
                return;
            }

            //We have a valid contact email
            //Get the HubspotContact by contact Email
            HubspotApi.Contact hsContact = HubspotApi.Contacts.GetContactByEmail(contactEmail);
            if (hsContact == null)
            {
                //x.Leader.Error("No Hubpspot Contact found for email address " + contactEmail + "Cannot identify Hubspot company.");
                return;

            }


            //Get the contact's associated company ID
            string strHsCompanyID = hsContact.Properties.Where(w => w.Key == "associatedcompanyid").Select(s => s.Value.value).FirstOrDefault();
            if (string.IsNullOrEmpty(strHsCompanyID))
                return;
            long hubspotCompanyID = Convert.ToInt64(strHsCompanyID);

            if (hubspotCompanyID == 0)
            {
                //x.Leader.Error("Could not get company ID from Hubspot Contact -  company associations.");
                return;
            }

            //Get the Company Related to the Contact
            HubspotApi.Company hsCompany = HubspotApi.Companies.GetCompanyByID(hubspotCompanyID);
            if (hsCompany == null)
            {
                //x.Leader.Error("Could not locate a Hubspot Company matching the ID: " + hubspotCompanyID);
                return;
            }

            //We have a valid Hubspot Owner, Company,  And Contact, let's compare to similar Rz Values
            //Rz Owner
            NewMethod.n_user rzCompanyOwner = NewMethod.n_user.GetById(x, CurrentCompany.base_mc_user_uid);
            if (rzCompanyOwner == null)
            {
                //x.Leader.Error("no Rz Owner found for this company matching n_user ID: " + CurrentCompany.base_mc_user_uid);
                return;
            }

            //Is the Rz Contact Linked with the Hubspot Contact (Hubspot Wins)
            string message = "";

            if (CurrentCompanyContact.hubspot_contact_id != hsContact.vid)
            {
                //We have a valid Hubspot Contact
                string hsContactFirstName = hsContact.Properties.Where(w => w.Key == "firstname").Select(s => s.Value.value).FirstOrDefault();
                string hsContactLastName = hsContact.Properties.Where(w => w.Key == "lastname").Select(s => s.Value.value).FirstOrDefault();
                long hsContactHubID = hsContact.vid;

                //Would you like to Associate <RzCompany> with <Hubspot Companmy>
                message = CurrentCompanyContact.contactname + " is not currently associated wtih the Hubspot identified contact: " + hsContactFirstName + " " + hsContactLastName + " [HubID: " + hsContactHubID + "]  Would you like link the Rz Contact with the Hubspot Contact?";

            }

            //Is the Rz Company Linked with the Hubspot Company (Hubspot Wins)
            if (CurrentCompany.hubspot_company_id != hsCompany.companyId)
            {
                string hsCompanyName = hsCompany.Properties.Where(w => w.Key == "name").Select(s => s.Value.value).FirstOrDefault();
                //Would you like to Associate <RzCompany> with <Hubspot Companmy>
                message = CurrentCompany.companyname + " is not currently associated wtih the Hubspot identified company: " + hsCompanyName + " [HubID: " + hsCompany.companyId + "]  Would you like link the Rz Company with the Hubspot Company?";
            }

            //Prompt for user confirm
            if (askConfirm)
                if (!RzWin.Leader.AskYesNo(message))
                    return;

            SensibleDAL.HubspotLogic.ManageRzHubspotCompanyLinkage(CurrentCompanyContact.unique_id, CurrentCompany.unique_id, hsContact, hsCompany);
            //CompleteLoad_Company();
            CurrentCompany = company.GetById(RzWin.Context, CurrentCompany.unique_id); //Refresh the hs properties for this company.

        }



        private void SetInternalPartsField()
        {
            //Loop through all the Distinct internalparts, add to a comma separated memofield.            
            List<orddet_quote> reqList = new List<orddet_quote>();
            string internalPartString = "";
            //Combines list
            List<string> combinedIpnMpn = new List<string>();

            //Limit to 5 parts, sometimes we import Hundres!

            List<string> first5reqIDs = lvReqs.GetAllIDs().Cast<string>().Take(5).ToList();
            //Req lines
            foreach (string s in first5reqIDs)
            {
                orddet_quote q = orddet_quote.GetById(RzWin.Context, s);
                if (q != null)
                {
                    string strIPN = q.internalpartnumber;
                    if (string.IsNullOrEmpty(strIPN))
                        strIPN = q.fullpartnumber;
                    if (string.IsNullOrEmpty(strIPN))
                        return;

                    if (!combinedIpnMpn.Contains(strIPN))
                        combinedIpnMpn.Add(strIPN);
                }
            }

            //Quote Lines
            foreach (string s in lvQuotes.GetAllIDs())
            {
                orddet_quote q = orddet_quote.GetById(RzWin.Context, s);
                if (q != null)
                {
                    string strIPN = q.internalpartnumber;
                    if (string.IsNullOrEmpty(strIPN))
                        strIPN = q.fullpartnumber;
                    if (string.IsNullOrEmpty(strIPN))
                        return;

                    if (!combinedIpnMpn.Contains(strIPN))
                        combinedIpnMpn.Add(strIPN);
                }
            }



            if (combinedIpnMpn.Count > 0)
            {
                foreach (string s in combinedIpnMpn)
                {
                    internalPartString += s;
                    if (s != combinedIpnMpn.Last())
                    {
                        internalPartString += ", ";
                    }
                }

                xDeal.internal_parts = internalPartString;
                xDeal.Update(RzWin.Context);
            }


        }



        private void SaveOemProduct()
        {
            xDeal.is_oem_product = ctl_is_oem_product.zz_CheckValue;
            if (ctl_is_oem_product.zz_CheckValue)
            {
                xDeal.oem_product_name = ctl_oem_product_name.Text;
                xDeal.oem_product_uid = ctl_oem_product_name.SelectedValue.ToString();
                xDeal.oem_product_qty = ctl_oem_product_qty.GetValue_Integer();
            }
            else
            {
                xDeal.oem_product_name = null;
                xDeal.oem_product_uid = null;
                xDeal.oem_product_qty = 0;
            }
        }

        private void LoadOemProduct()
        {
            ctl_oem_product_name.DataSource = null;
            //Need to set to null, Rz ORM detects changes (changecacge) When detected, CompleteLoad is fired again.  
            //At which point, this datasource will already be set, and thus read-only.  
            //Null it so I can re-establish it then re-bind it.
            DataTable dt = RzWin.Context.Select("Select unique_id, oem_product_name from oem_product");
            ctl_oem_product_name.Items.Add("Choose");

            DataRow dr = dt.NewRow();
            dr[0] = 0;
            dr[1] = "-Select-";
            dt.Rows.InsertAt(dr, 0);

            ctl_oem_product_name.DataSource = dt;
            ctl_oem_product_name.ValueMember = "unique_id";
            ctl_oem_product_name.DisplayMember = "oem_product_name";
            if (!string.IsNullOrEmpty(xDeal.oem_product_uid))
            {
                ctl_oem_product_name.SelectedValue = xDeal.oem_product_uid;
            }
            else
            {
                ctl_oem_product_name.SelectedIndex = 0;
            }

            ctl_oem_product_name.Visible = ctl_is_oem_product.zz_CheckValue;
            ctl_oem_product_qty.Visible = ctl_is_oem_product.zz_CheckValue;


        }

        //Public Virtual Functions
        public virtual void TheSysChanged(Context x, ChangeArgs args)
        {
            foreach (IItem i in args.Deleted())
            {
                if (i.ClassId == "orddet_rfq")
                    RemoveBid((ContextRz)x, (orddet_rfq)i, false);
            }
        }
        public virtual void ShowObject(nObject o)
        {
            if (o == null)
                return;
            dl.ShowObject(o);
            TheShowObject = null;
            if (o is orddet_quote)
                TheShowObject = o;
            DoResize();
        }

        public virtual void CloseObject(nObject o)
        {
            if (o == null)
                return;
            dl.CloseObjectIfOpen(o.unique_id);
            DoResize();
        }

        public virtual void ShowReqReport(orddet_quote q, bool purchasing)
        {

        }
        public virtual void CompleteLoad_Company()
        {
            CompList.SetCompany(xDeal.customer_name, xDeal.customer_uid, xDeal.contact_name, xDeal.contact_uid);
            check_financials();
        }
        public virtual void LoadReqQuoteLV()
        {
            try
            {
                if (xDeal == null)
                    return;
                ItemsInstance reqs = new ItemsInstance();
                ItemsInstance quotes = new ItemsInstance();
                //foreach (KeyValuePair<String, Item> k in xDeal.CustomerHalf.Details)
                foreach (orddet_quote q in xDeal.GetAllOrddetQuotes(RzWin.Context))
                {
                    //orddet_quote q = (orddet_quote)k.Value;
                    if (q.IsQuoted)
                        quotes.Add(RzWin.Context, q);
                    else
                        reqs.Add(RzWin.Context, q);
                }

                ListArgs args = new ListArgs(RzWin.Context);
                args.AddAllow = false;
                args.ExportAllow = false;
                args.OptionsAllow = false;
                args.TheCaption = "Requirements";
                args.TheClass = "orddet_quote";
                args.TheLimit = -1;
                args.TheOrder = "linecode";
                args.TheTable = "orddet_quote";
                args.TheTemplate = "orderbatch_req_listview";
                args.LiveItems = reqs;
                lvReqs.ShowData(args);

                args = new ListArgs(RzWin.Context);
                args.AddAllow = false;
                args.ExportAllow = false;
                args.OptionsAllow = false;
                args.TheCaption = "Quotes";
                args.TheClass = "orddet_quote";
                args.TheLimit = -1;
                args.TheOrder = "linecode";
                args.TheTable = "orddet_quote";
                args.TheTemplate = "orderbatch_quote_listview";
                args.LiveItems = quotes;
                lvQuotes.ShowData(args);
            }
            catch { }
        }
        public virtual void LoadBids(nObject o)
        {
            try
            {
                if (xDeal == null)
                    return;
                if (o == null)
                    return;
                if (IsLoading)
                    return;
                if (TheShowObject != null && FillFinished)
                {
                    o = TheShowObject;
                    TheShowObject = null;
                    FillFinished = false;
                }
                ListArgs args = new ListArgs(RzWin.Context);
                args.AddAllow = false;
                args.ExportAllow = false;
                args.OptionsAllow = false;
                args.TheCaption = "Bids for " + o.ToString();
                args.TheClass = "orddet_rfq";
                args.TheLimit = -1;
                args.TheOrder = "linecode";
                args.TheTable = "orddet_rfq";
                args.TheTemplate = "orderbatch_bid_listview";
                args.TheWhere = "base_dealheader_uid = '" + xDeal.unique_id + "' and the_orddet_quote_uid = '" + o.unique_id + "'";
                while (lvBids.IsAsyncRunning())
                    Application.DoEvents();
                lvBids.ShowData(args);
            }
            catch { }
        }
        //Protected Override Functions
        protected override void DoResize()
        {
            base.DoResize();
            try
            {
                if (Parent != null)
                    Parent.Text = xDeal.ToString();
                pLinks.Left = this.ClientRectangle.Width - pLinks.Width;
                dl.ArrangeControls();
                dl.Left = 0;
                dl.Width = this.ClientRectangle.Width;
                dl.Top = this.ClientRectangle.Height - dl.Height;
                flOrders.Left = 0;
                flOrders.Width = this.ClientRectangle.Width;
                flOrders.Height = dl.Top - flOrders.Top - 5;
                spOrders.Left = 0;
                spOrders.Width = flOrders.Width - 25;
                spOrders.Height = this.ClientRectangle.Height - flOrders.Top - 15;
                spReqs.SplitterDistance = spReqs.Width - 110;
                spBids.SplitterDistance = spReqs.SplitterDistance;
            }
            catch { }
        }
        protected override void InitUn()
        {
            base.InitUn();
            try
            {
                this.spOrders.SplitterMoved -= new System.Windows.Forms.SplitterEventHandler(this.spOrders_SplitterMoved);
                this.lblCompleteDelete.LinkClicked -= new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCompleteDelete_LinkClicked);
                this.lnkPartReport.LinkClicked -= new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPartReport_LinkClicked);
                this.lblDeal.LinkClicked -= new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblDeal_LinkClicked);
                this.lblLinks.LinkClicked -= new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLinks_LinkClicked);
                this.cmdNote.Click -= new System.EventHandler(this.cmdNote_Click);
                this.cmdClip.Click -= new System.EventHandler(this.cmdClip_Click);
                this.cmdSaveAndExit.Click -= new System.EventHandler(this.cmdSaveAndExit_Click);
                this.cmdSave.Click -= new System.EventHandler(this.cmdSave_Click);
                //this.lblAgent.LinkClicked -= new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAgent_LinkClicked);
                this.lblSearch.LinkClicked -= new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSearch_LinkClicked);
                this.bgw.DoWork -= new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
                this.bgw.RunWorkerCompleted -= new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted);
                this.lnkUpdateStats.LinkClicked -= new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUpdateStats_LinkClicked);
                this.CompList.ContactChangeFinished -= new ContactEventHandler(this.CompList_ContactChangeFinished);
                this.CompList.CompanyChangeFinished -= new ContactEventHandler(this.CompList_CompanyChangeFinished);
                this.dl.MakePO -= new BidLineEventHandler(this.dl_MakePO);
                this.dl.GotResize -= new System.EventHandler(this.dl_GotResize);
                this.Resize -= new System.EventHandler(this.OrderTree_Resize);
            }
            catch { }
        }
        //Protected Virtual Functions
        protected virtual void PartReport()
        {
            xDeal.Report(RzWin.Context);
        }
        protected virtual void AddNewReq(ContextRz x)
        {

            if (CurrentCompany == null)
            {
                x.Leader.Tell("Please choose a customer before adding requirements");
                return;
            }

            orddet_quote q = xDeal.CustomerHalf.QuoteAdd(x);
            if (q != null)
            {
                //q.Update(RzWin.Context);
                TheReq = q;
                TheQuote = null;
                ShowObject(q);
            }
        }
        protected virtual void ImportReqs()
        {
            DealImport i = new DealImport();
            i.xTree = this;
            RzWin.Form.TabShow(i, "Import to " + xDeal.dealheader_name);
            i.InitReq(xDeal, false);
        }
        protected virtual void CreateFormalQuote(ContextNM x, List<orddet_quote> quoteList = null)
        {
            if (xDeal == null)
                return;

            xDeal.CustomerHalf.FormalQuoteCreate((ContextRz)x, quoteList);
        }
        protected virtual void CreateSalesOrder(ContextNM x)
        {
            if (xDeal == null)
                return;
            xDeal.CustomerHalf.SalesOrderCreate((ContextRz)x);
        }
        protected virtual void SendToExcel()
        {
            if (xDeal == null)
                return;
            xDeal.ExportToExcelAsCustomer((ContextRz)RzWin.Context);
        }
        protected virtual void AddNewBid(ContextNM x, orddet_quote o)
        {
            company comp = null;
            companycontact cont = null;
            if (!RzWin.Leader.ChooseCompany((ContextRz)x, ref comp, ref cont))
                return;

            ContextRz xRz = (ContextRz)x;
            //Check if this company is one of our Excess Partners.  If so, they need to select the part from inventory.
            List<string> potentialParts = new List<string>();
            if (xRz.TheSysRz.TheCompanyLogic.IsPotentialExcessPart(xRz, comp, o, out potentialParts))
            {
                //Now, this will prevent getting bids from Excess partners even if the part is not on their excess lists, is that going ot be a problem? Joey says no.


                //Contrary to above, I am hearing frustration from this.  Will now check to see if
                //xRz.Leader.Tell(comp.companyname + " is one of our Excess partners.   Please check Part Search to see if they are already listing this part with us.  If so, use 'Inventory / Excess Bid' option to select the part from the Excess grid.");

                string message = "Rz has detected the following potential excess versions of this part from our Excess partners: " + Environment.NewLine;
                foreach (string ss in potentialParts)
                    message += ss + Environment.NewLine;
                xRz.Leader.Tell(message);
                SendExcessBidEmailAlert(xRz, xDeal, o, comp);
            }



            //Check Outstanding Vendor Credits etc:
            //if (comp != null)
            //    CheckOutstandinBalanceAlert(comp);


            //if (!VendorCheck((ContextRz)x, comp))
            //    return;
            //KT - Check if the vendor has been vetted.  Removing for now, as we don't want to get in the way of accepting bids            
            if (!(((SysRz5)RzWin.Context.xSys).TheCompanyLogic).CheckVendor((ContextRz)x, comp, true, true))
            {
                return;
            }

            orddet_rfq r = xDeal.VendorHalf.BidAdd(x, comp, cont);
            if (r != null)
            {
                r.fullpartnumber = o.fullpartnumber;
                r.target_quantity = o.target_quantity;
                r.quantityordered = o.target_quantity;
                r.alternatepart = o.alternatepart;
                r.Update(RzWin.Context);
                o.BidAbsorb(RzWin.Context, r);
                ShowObject(r);
            }
        }

        private void SendExcessBidEmailAlert(ContextRz xRz, dealheader xDeal, orddet_quote o, company comp)
        {
            string part = o.fullpartnumber.Trim().ToUpper();
            long qty = o.target_quantity;
            string batchName = xDeal.dealheader_name;
            string agentName = o.agentname;
            string companyName = comp.companyname;

            string subject = "Alert: Bid received for Excess partner: " + companyName;
            string body = "Company: " + companyName + "<br />";
            body += "Part: " + part + "<br />";
            body += "Qty: " + qty + "<br />";
            body += "Batch: " + batchName + "<br />";
            body += "Agent: " + agentName + "<br /><br />";
            body += "<em>Please search Rz to ensure this part isn't already listed on one of " + companyName + "'s Excess lists.</em>";
            SystemLogic.Email.SendMail("rz@sensiblemicro.com", "distysales@sensiblemicro.com", subject, body);

        }



        protected virtual void AddNewStockBid(ContextNM x, orddet_quote o)
        {
            if (o == null)
                return;
            orddet_rfq b = o.AddStockBid(x);
            if (b == null)
                return;
            try
            {
                xDeal.VendorHalf.Details.Add(b.unique_id, b);
                ////KT invoice Overbuy check - PartLogic.cs
                //if (b.stockid != null)
                //{
                //    partrecord p = (partrecord)x.QtO("partrecord", "select * from partrecord where unique_id = '" + b.stockid + "'");
                //    if(p != null)
                //    ((SysRz5)RzWin.Context.xSys).ThePartLogic.OverbuyAlert((ContextRz)x, p, b, true);
                //}

            }
            catch (Exception ex)
            {
                x.Leader.Tell(ex.Message);
            }
            ShowObject(b);
        }






        protected virtual void ShowQuoteStats(orddet_quote o)
        {
            frmQuoteStats f = new frmQuoteStats();
            f.CompleteLoad(o.unique_id, false);
            f.Show();
        }
        protected virtual void RemoveReqQuote(ContextNM x, orddet_quote o)
        {
            if (o == null)
                return;
            if (!RzWin.Leader.AreYouSure("remove " + o.GetTreeCaption(RzWin.Context)))
                return;
            //Close the object view if open.
            CloseObject(o);

            o.base_dealheader_uid = "";
            o.base_dealdetail_uid = "";
            o.the_orddet_rfq_uid = "";
            xDeal.CustomerHalf.Details.Remove(o.unique_id);
            if (o.ParentDetailGet(RzWin.Context) != null)
            {
                if (o.ParentDetailGet(RzWin.Context).DetailsGet(RzWin.Context) != null)
                    o.ParentDetailGet(RzWin.Context).DetailsGet(RzWin.Context).Remove(o);
            }
            o.ParentDetailSet(RzWin.Context, null);
            o.Update(RzWin.Context);
            if (o.DetailsGet(RzWin.Context) != null)
            {
                foreach (nObject r in o.DetailsGet(RzWin.Context))
                {
                    if (r is orddet_rfq)
                        RemoveBid(x, (orddet_rfq)r, false);
                }
            }
            //o.Delete(x);
            //o.Update(RzWin.Context);
        }
        protected virtual bool RemoveBid(ContextNM x, orddet_rfq o, bool ask = true)
        {
            if (o == null)
                return false;
            if (ask)
            {
                if (!RzWin.Leader.AreYouSure("remove " + o.GetTreeCaption(RzWin.Context)))
                    return false;
            }
            o.base_dealheader_uid = "";
            o.base_dealdetail_uid = "";
            o.the_orddet_quote_uid = "";
            xDeal.VendorHalf.Details.Remove(o.unique_id);
            if (o.ParentDetailGet(RzWin.Context) != null)
            {
                if (o.ParentDetailGet(RzWin.Context).DetailsGet(RzWin.Context) != null)
                    o.ParentDetailGet(RzWin.Context).DetailsGet(RzWin.Context).Remove(o);
            }
            o.ParentDetailSet(RzWin.Context, null);
            try { o.Update(RzWin.Context); }
            catch { }
            return true;
        }
        protected virtual void AcceptBid(ContextNM x, orddet_rfq o, orddet_quote q, int acceptedBidQty)
        {
            if (o == null)
                return;
            if (q == null)
                return;
            Item obj = null;
            xDeal.VendorHalf.Details.TryGetValue(o.unique_id, out obj);
            if (obj != null)
            {
                //If PartNumber mismatch, ask user if they would like to update the Quote part with the BidPart.
                ConfirmBidMatchesQuote(x, o, q);



                o = (orddet_rfq)obj;
                o.ParentDetailSet(RzWin.Context, q);
                o.Accept((ContextRz)x);
                if (o.is_accepted)
                    o.icon_index = -1000;
                else
                    o.icon_index = 0;
                o.Update(RzWin.Context);
            }

            //Current Bid Qty
            long currentBidQty = o.quantityordered;
            long currentReqQty = q.quantityordered;


            if (o.is_accepted)
            {

                q.quantityordered = currentReqQty + currentBidQty;
                q.unitcost = o.unitprice;
                q.manufacturer = o.manufacturer.ToUpper();
                q.datecode = o.datecode;
                q.condition = o.condition;
                q.rohs_info = o.rohs_info;
                q.packaging = o.packaging;
                q.delivery = o.delivery;
            }
            else
            {
                //sum of other related selected bis plus this bid
                q.quantityordered = currentReqQty - currentBidQty;
                q.unitprice = 0;
                q.unitcost = 0;
                q.manufacturer = "";
                q.datecode = "";
                q.condition = "";
                q.rohs_info = "";
                q.packaging = "";
                q.delivery = "";
            }




            //if (o.isinstock)

            q.Update(RzWin.Context);
            q.RefreshNodes(RzWin.Context);
            //    }
            //}
            lvReqs.Refresh();
            lvBids.Refresh();


        }

        private void ConfirmBidMatchesQuote(ContextNM x, orddet_rfq theBid, orddet_quote theReq)
        {
            string bidPart = theBid.fullpartnumber.Trim().ToUpper();
            string reqPart = theReq.fullpartnumber.Trim().ToUpper();
            if (bidPart != reqPart)
                if (x.Leader.AskYesNo("The bid part number (" + bidPart + ") does not match the req part number (" + reqPart + ").  Would you like to update the req part to match the bid?"))
                {
                    theReq.fullpartnumber = bidPart;
                    theReq.Update(x);
                }
        }

        //private void CheckOutstandinBalanceAlert(orddet_rfq theBid)
        //{
        //    if (theBid == null)
        //        return;
        //    if (!theBid.is_accepted)
        //        return;
        //    double balance = 0;
        //    //balance = 150; - testing
        //    company bidVendor = company.GetById(RzWin.Context, theBid.base_company_uid);
        //    if (bidVendor == null)
        //        return;

        //    //03-13-18 - Removing this until we can better identify outstanding VRMAs and Invoices from a buyer's point of view.
        //    //ArApInfo a = RzWin.Context.TheSysRz.TheCompanyLogic.CalculateOutstandingBalance(RzWin.Context, bidVendor);
        //    //if (a == null)
        //    //    return;
        //    //if (a.OutstandingAR > 0)
        //    //    balance += a.OutstandingAR;
        //    //companycredits
        //    balance += RzWin.Context.SelectScalarDouble("select creditamount from companycredit where is_applied != 1 and base_company_uid = '" + bidVendor.unique_id + "'");
        //    if (balance > 0)
        //        RzWin.Context.Leader.Tell("We have a " + Tools.Number.MoneyFormat_2_6(balance) + " credit outstanding credit with " + bidVendor.companyname);
        //}



        //KT Refactored from RzSensible 3-17-2015
        private void chkIsSourced_CheckChanged(object sender)
        {
            //GetOppStage();
            xDeal.is_sourced = chkIsSourced.GetValue_Boolean();
            ((dealheader)xDeal).is_sourced = chkIsSourced.GetValue_Boolean();
            xDeal.Update(RzWin.Context, true);
            //GetPipelineStage();
        }

        //Public Functions
        public void ShowObjectByID(String strID)
        {
            Item x = xDeal.GetObjectByID(strID);
            if (x != null)
                ShowObject((nObject)x);
        }
        protected void CompleteDispose()
        {
            dl.SavedObject -= new EventHandler(dl_SavedObject);
        }
        //Private Functions
        private void SaveAndCloseAllObjects()
        {
            ArrayList al = new ArrayList();
            foreach (KeyValuePair<String, nLineHandle> k in dl.DisplayedObjects)
            {
                al.Add(k.Value.xLine);
            }
            foreach (nLine l in al)
            {
                dl.DisplayedObjects.Remove(l.CurrentObject.unique_id);
                l.CompleteSave();
                try
                {
                    orddet_old d = (orddet_old)l.CurrentObject;
                    d.RefreshNodes(RzWin.Context);
                }
                catch { }
                dl.Remove(l);
            }
            dl.ArrangeControls();
            DoResize();
        }
        private void CustomerSet()
        {
            //CompleteLoad_Company();
            CurrentCompany = company.GetById(RzWin.Context, CompList.GetCompanyID());
            if (!string.IsNullOrEmpty(CompList.GetContactID()))
                CurrentCompanyContact = companycontact.GetById(RzWin.Context, CompList.GetContactID());


            xDeal.CustomerObject = CurrentCompany;
            if (CurrentCompanyContact == null)
                return;

            //We have a companycontact
            xDeal.ContactObject = CurrentCompanyContact;
            //Make sure to reassign this contact to the new company 
            string contact_company_id = CurrentCompanyContact.base_company_uid;
            string company_id = CurrentCompany.unique_id;
            if (contact_company_id != company_id)
            {
                if (RzWin.Leader.AskYesNo(CurrentCompanyContact.contactname + " is not currently associated with company: " + CurrentCompany.companyname + ".  Would you like to associate them now?"))
                {
                    CurrentCompanyContact.base_company_uid = CurrentCompany.unique_id;
                    CurrentCompanyContact.Update(RzWin.Context);
                }
            }

            ////Make sure to assign batch to the existing company's owner (even if that's house).
            //string company_agent_id = CurrentCompany.base_mc_user_uid;
            //if (company_agent_id != xDeal.base_mc_user_uid)
            //{
            //    xDeal.base_mc_user_uid = company_agent_id;
            //}

            xDeal.Update(RzWin.Context);
        }
        private string UpdateQuoteStats()
        {
            if (xDeal == null)
                return "Deal doesn't exist yet.";
            if (!xDeal.UpdateQuoteStats(RzWin.Context))
                return "Update Failed!";
            else
                return "success";
        }
        private void ShowQuoteStats()
        {
            frmQuoteStats f = new frmQuoteStats();
            f.CompleteLoad(xDeal.unique_id, true);
            f.Show();
        }
        private void ShowAttachments()
        {
            PartPictureViewer p = new PartPictureViewer();
            p.CompleteLoad();
            p.LoadViewBy(xDeal);
            RzWin.Form.TabShow(p, "Attachments On " + xDeal.ToString());
        }
        private void LoadBlankBidLV()
        {
            try
            {
                lvBids.SetAlternateIcons(lvBids.GetListViewControl().LargeImageList);
                lvBids.RequestIcon += new IconRequest(lvBids_RequestIcon);
                ListArgs args = new ListArgs(RzWin.Context);
                args.AddAllow = false;
                args.ExportAllow = false;
                args.OptionsAllow = false;
                args.TheCaption = "Bids for";
                args.TheClass = "orddet_rfq";
                args.TheLimit = -1;
                args.TheOrder = "orderdate desc";
                args.TheTable = "orddet_rfq";
                args.TheTemplate = "orderbatch_bid_listview";
                args.TheWhere = "base_dealheader_uid = '<not a valid id>' and the_orddet_quote_uid = '<not a valid id>'";
                lvBids.ShowData(args);
            }
            catch { }
        }
        private void CheckBidLoad()
        {
            if (TheReq != null)
                LoadBids(TheReq);
            else if (TheQuote != null)
                LoadBids(TheQuote);
        }
        private void UnSelectAll(nList lv)
        {
            if (lv == null)
                return;
            suppressClick = true;
            lv.CurrentID = "";
            foreach (ListViewItem xLst in lv.GetListViewControl().SelectedItems)
            {
                xLst.Selected = false;
            }
            suppressClick = false;
        }
        private void SetInitialSelection()
        {
            while (!FillFinished)
            {
                Application.DoEvents();
            }
            UnSelectAll(lvReqs);
            UnSelectAll(lvQuotes);
            if (lvReqs.GetListViewControl().Items.Count > 0)
                lvReqs.SelectFirst(true);
            else
                lvQuotes.SelectFirst(true);
        }
        private void SelectAll(bool quote, bool selected)
        {
            if (quote)
            {
                foreach (KeyValuePair<string, Item> kvp in xDeal.CustomerHalf.Details)
                {
                    try
                    {
                        orddet_quote q = (orddet_quote)kvp.Value;
                        if (q == null)
                            continue;
                        if (q.quantityordered <= 0 || q.unitprice <= 0)
                            continue;
                        q.isselected = selected;
                        RzWin.Context.TheDelta.Update(RzWin.Context, q);
                    }
                    catch { }
                }
            }
            else
            {
                foreach (KeyValuePair<string, Item> kvp in xDeal.CustomerHalf.Details)
                {
                    try
                    {
                        orddet_quote q = (orddet_quote)kvp.Value;
                        if (q == null)
                            continue;
                        if (q.quantityordered > 0 || q.unitprice > 0)
                            continue;
                        q.isselected = selected;
                        RzWin.Context.TheDelta.Update(RzWin.Context, q);
                    }
                    catch { }
                }
            }
        }
        //Buttons
        private void cmdSave_Click(object sender, EventArgs e)
        {
            CompleteSaveAndUpdate();
        }
        private void cmdSaveAndExit_Click(object sender, EventArgs e)
        {
            SaveAndCloseAllObjects();
            CompleteSave();
            RzWin.Form.TabTopClose();
        }
        private void cmdClip_Click(object sender, EventArgs e)
        {
            RzWin.User.AddClipObject(RzWin.Context, xDeal, true);
        }
        private void cmdNote_Click(object sender, EventArgs e)
        {
            RzWin.Context.xSys.SendNote(RzWin.Context, xDeal);
        }
        private void cmdNewReq_Click(object sender, EventArgs e)
        {
            AddNewReq(RzWin.Context);
        }
        private void cmdImportReqs_Click(object sender, EventArgs e)
        {
            ImportReqs();
        }
        private void cmdQuote_Click(object sender, EventArgs e)
        {
            CreateQuote();
        }

        private void CreateQuote(List<string> quoteIDs = null)
        {
            //Force Industry Segment
            if (string.IsNullOrEmpty(CurrentCompany.industry_segment))
            {
                string segment = RzWin.Leader.ChooseOneChoice(RzWin.Context, "industry_segment");
                if (!string.IsNullOrEmpty(segment))
                {
                    CurrentCompany.industry_segment = segment;
                    CurrentCompany.Update(RzWin.Context);
                }
                else
                {
                    RzWin.Leader.Tell("Sorry, you must set the Industry Segment for " + CurrentCompany.companyname + " before sending them a formal quote.");
                    return;
                }
            }

            //Hubspot   
            //CompleteSaveHubspot();

            bool allowCreate = true;
            if (quoteIDs == null)
                quoteIDs = lvQuotes.GetAllIDs().Cast<string>().ToList();
            List<orddet_quote> quoteLines = new List<orddet_quote>();

            foreach (string s in quoteIDs)
            {
                orddet_quote q = orddet_quote.GetById(RzWin.Context, s);
                if (q != null)
                    quoteLines.Add(q);
            }

            if (allowCreate)
            {
                xDeal.opportunity_stage = SM_Enums.OpportunityStage.formal_quote_created.ToString();
                xDeal.Update(RzWin.Context);
                CreateFormalQuote(RzWin.Context, quoteLines);
            }


        }

        private void cmdCreateSO_Click(object sender, EventArgs e)
        {
            CreateSalesOrder(RzWin.Context);
        }
        private void cmdXL_Click(object sender, EventArgs e)
        {
            SendToExcel();
        }
        private void cmdNewBid_Click(object sender, EventArgs e)
        {
            orddet_quote o = null;
            if (TheReq != null)
                o = TheReq;
            else if (TheQuote != null)
                o = TheQuote;
            if (o == null)
                return;
            AddNewBid(RzWin.Context, o);
        }
        private void cmdNewStockBid_Click(object sender, EventArgs e)
        {
            orddet_quote o = null;
            if (TheReq != null)
                o = TheReq;
            else if (TheQuote != null)
                o = TheQuote;
            if (o == null)
                return;
            AddNewStockBid(RzWin.Context, o);
        }
        //Control Events
        private void lvBids_RequestIcon(IconRequestArgs args)
        {
            int i = Tools.Data.NullFilterInt(args.row["icon_index"]);
            if (i == -1000)
                i = 8;
            else
                i = 0;
            args.icon = i;
        }
        private void OrderTree_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void CompList_CompanyChangeFinished(Tools.GenericEvent e)
        {
            CustomerSet();
            CompleteLoad_Company();
        }
        private void CompList_ContactChangeFinished(Tools.GenericEvent e)
        {
            CustomerSet();
        }
        private void dl_GotResize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void dl_MakePO(IBidLine l)
        {
            try
            {
                orddet_rfq r = l.CurrentBid;
                r.MakePO((ContextRz)RzWin.Context);
            }
            catch { }
        }
        private void sp_SplitterMoved(object sender, SplitterEventArgs e)
        {
            DoResize();
        }
        private void spOrders_SplitterMoved(object sender, SplitterEventArgs e)
        {
            DoResize();
        }
        private void lblLinks_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OrderMap m = new OrderMap();
            RzWin.Form.TabShow(m, "Order Map for " + xDeal.Name);
            //needed, since invoices, rmas etc could have been created since the initial cache
            //maybe this screen should listen for ordhed changes and only re-cache if there have been any
            xDeal.CacheOrders(RzWin.Context);
            m.CompleteLoadFromDeal(xDeal);
        }
        private void lblDeal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Rz3App.xMainForm.ShowDeal(xDeal);
        }

        private void lblSearch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String s = RzWin.Leader.AskForString("Part number or fragment", "", "Part #");
            if (!Tools.Strings.StrExt(s))
                return;
            suppressClick = true;
            try
            {
                List<String> strings = new List<string>();
                strings.Add(s.ToUpper().Trim());
                lvReqs.HighlightByFieldValue("fullpartnumber", strings, fuzzyMode: true);
                lvQuotes.HighlightByFieldValue("fullpartnumber", strings, fuzzyMode: true);
                lvBids.HighlightByFieldValue("fullpartnumber", strings, fuzzyMode: true);
            }
            catch { }
            suppressClick = false;
        }
        private void lblCompleteDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!RzWin.Leader.AreYouSure("delete this order batch and all of the related reqs, bids, and quotes"))
                return;

            xDeal.Obliterate(RzWin.Context);
            this.SendCloseRequest();
        }
        private void lnkPartReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PartReport();
        }
        private void lnkUpdateStats_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (bgw.IsBusy)
                return;
            throbber.ShowThrobber();
            bgw.RunWorkerAsync();
        }
        private void lnkAttachments_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowAttachments();
        }
        protected void lvReqs_AboutToThrow(Core.Context x, Core.ShowArgs args)
        {
            args.Handled = true;
            ShowObject(lvReqs.GetSelectedObject());
        }
        protected void lvQuotes_AboutToThrow(Core.Context x, Core.ShowArgs args)
        {
            args.Handled = true;
            string id = lvQuotes.GetSelectedID();
            if (!Tools.Strings.StrExt(id))
                return;
            //Item o = null;
            //xDeal.CustomerHalf.Details.TryGetValue(id, out o);
            //if (o == null)
            //    return;
            // ShowObject((nObject)o);

            ShowObject(lvQuotes.GetSelectedObject());
        }
        protected void lvBids_AboutToThrow(Core.Context x, Core.ShowArgs args)
        {
            args.Handled = true;
            string id = lvBids.GetSelectedID();
            if (!Tools.Strings.StrExt(id))
                return;
            Item o = null;
            xDeal.VendorHalf.Details.TryGetValue(id, out o);
            if (o == null)
                return;
            ShowObject((nObject)o);
        }

        bool suppressClick = false;
        protected void lvReqs_ObjectClicked(object sender, ObjectClickArgs args)
        {
            if (suppressClick)
                return;
            args.Handled = true;
            FillFinished = false;
            TheQuote = null;
            TheReq = (orddet_quote)lvReqs.GetSelectedObject();
            UnSelectAll(lvQuotes);
            cmdQuote.Visible = false;
            cmdCreateSO.Visible = false;
            tmr.Start();
            //if (TheReq != null)
            //    ShowObject(TheReq);

            //LoadBids(TheReq);
        }
        protected void lvQuotes_ObjectClicked(object sender, ObjectClickArgs args)
        {
            if (suppressClick)
                return;
            args.Handled = true;
            FillFinished = false;
            TheReq = null;
            TheQuote = (orddet_quote)lvQuotes.GetSelectedObject();
            UnSelectAll(lvReqs);
            cmdQuote.Visible = true;
            if (!CurrentCompany.is_locked)
                cmdQuote.Enabled = true;
            else
                cmdQuote.Enabled = false;

            tmr.Start();

        }
        protected void lvQuotes_FinishedFill(object sender)
        {
            FillFinished = true;
            CheckBidLoad();
        }
        //Background Workers
        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = UpdateQuoteStats();
        }
        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throbber.HideThrobber();
            LoadReqQuoteLV();
        }
        //Menus
        private void mnuNewBid_Click(object sender, EventArgs e)
        {
            orddet_quote o = null;
            if (TheReq != null)
                o = TheReq;
            else if (TheQuote != null)
                o = TheQuote;
            if (o == null)
                return;
            AddNewBid(RzWin.Context, o);
        }
        private void mnuAddStockBid_Click(object sender, EventArgs e)
        {
            orddet_quote o = null;
            if (TheReq != null)
                o = TheReq;
            else if (TheQuote != null)
                o = TheQuote;
            if (o == null)
                return;
            AddNewStockBid(RzWin.Context, o);
        }
        private void mnuAddToFQSO_Click(object sender, EventArgs e)
        {
            orddet_quote o = null;
            if (TheReq != null)
                o = TheReq;
            else if (TheQuote != null)
                o = TheQuote;
            if (o == null)
                return;
            xDeal.CustomerHalf.AddToFQSO(RzWin.Context, o, xDeal);


        }
        private void mnuViewQuoteStats_Click(object sender, EventArgs e)
        {
            orddet_quote o = null;
            if (TheReq != null)
                o = TheReq;
            else if (TheQuote != null)
                o = TheQuote;
            if (o == null)
                return;
            ShowQuoteStats(o);
        }
        private void mnuRemoveQuote_Click(object sender, EventArgs e)
        {
            try
            {
                orddet_quote o = null;
                if (TheReq != null)
                    o = TheReq;
                else if (TheQuote != null)
                    o = TheQuote;
                if (o == null)
                    return;

                RemoveReqQuote(RzWin.Context, o);
                LoadReqQuoteLV();
            }
            catch (Exception ex)
            {
                RzWin.Leader.Error(ex.Message);
            }

        }
        private void mnuAcceptBid_Click(object sender, EventArgs e)
        {
            ArrayList a = lvBids.GetSelectedObjects();
            orddet_quote q = null;
            if (TheReq != null)
                q = TheReq;
            else if (TheQuote != null)
                q = TheQuote;

            if (q == null)
            {
                RzWin.Context.TheLeader.Tell("You need to first select either a requirement or quote before accepting this bid.");
                return;
            }
            int acceptedBidQty = RzWin.Context.SelectScalarInt32("select  isnull(SUM(quantityordered),0) from orddet_rfq where the_orddet_quote_uid = '" + q.unique_id + "' and is_accepted = 1");
            foreach (orddet_rfq o in a)
            {
                if (o == null)
                    continue;
                AcceptBid(RzWin.Context, o, q, acceptedBidQty);
            }
            CheckBidLoad();
            //q.Update(RzWin.Context);
            //SaveAndCloseAllObjects();
            //dl.Refresh();
            //CompleteLoad();
        }
        private void mnuRemoveBid_Click(object sender, EventArgs e)
        {
            try
            {
                orddet_rfq o = (orddet_rfq)lvBids.GetSelectedObject();
                if (o == null)
                    return;
                RemoveBid(RzWin.Context, o);
            }
            catch (Exception ex)
            {
                RzWin.Leader.Error(ex.Message);
            }
        }
        private void mnuReq_Opening(object sender, CancelEventArgs e)
        {
            mnuSetUnSelected.Visible = false;
            mnuSetSelected.Visible = false;
            if (TheQuote != null)
            {
                if (TheQuote.isselected)
                    mnuSetUnSelected.Visible = true;
                else
                    mnuSetSelected.Visible = true;
            }
        }
        private void mnuSetSelected_Click(object sender, EventArgs e)
        {
            if (TheQuote == null)
                return;
            Item q = null;
            xDeal.CustomerHalf.Details.TryGetValue(TheQuote.unique_id, out q);
            if (q != null)
            {
                TheQuote = (orddet_quote)q;
                TheQuote.isselected = true;
                TheQuote.Update(RzWin.Context);
                //xDeal.Update(RzWin.Context);
                LoadReqQuoteLV();
            }
        }
        private void mnuSetUnSelected_Click(object sender, EventArgs e)
        {
            if (TheQuote == null)
                return;
            Item q = null;
            xDeal.CustomerHalf.Details.TryGetValue(TheQuote.unique_id, out q);
            if (q != null)
            {
                TheQuote = (orddet_quote)q;
                TheQuote.isselected = false;
                TheQuote.Update(RzWin.Context);
                //xDeal.Update(RzWin.Context);
                LoadReqQuoteLV();


            }
        }
        private void mnuSelectAll_Click(object sender, EventArgs e)
        {
            bool q = false;
            if (TheQuote != null)
                q = true;
            SelectAll(q, true);
        }
        private void mnuUnSelectAll_Click(object sender, EventArgs e)
        {
            bool q = false;
            if (TheQuote != null)
                q = true;
            SelectAll(q, false);
        }
        private void tmr_Tick(object sender, EventArgs e)
        {
            tmr.Stop();
            if (TheReq != null)
            {
                if (lvReqs.GetSelectedIDs().Count > 1)
                {
                    lvBids.Clear();
                    lvBids.Caption = "Bids";
                    return;
                }
                LoadBids(TheReq);
                return;
            }
            if (TheQuote != null)
            {
                if (lvQuotes.GetSelectedIDs().Count > 1)
                {
                    lvBids.Clear();
                    lvBids.Caption = "Bids";
                    return;
                }
                LoadBids(TheQuote);
                return;
            }
        }
        //KT - Refactored from RzSensible.  This was in the completeLoad_Company, I figured best to refactor to its own method.
        private void check_financials()
        {
            lblFinancials.Visible = false;
            //base.CompleteLoad_Company();
            if (xDeal != null)
            {
                if (Tools.Strings.StrExt(xDeal.customer_uid))
                {
                    company c = company.GetById(RzWin.Context, xDeal.customer_uid);
                    if (c != null)
                    {
                        if (!c.has_financials)
                        {
                            lblFinancials.Visible = true;
                            lblFinancials.BringToFront();
                        }
                    }
                }
            }
        }




        protected void CompleteSaveOpportunity()
        {
            //Variables
            bool lostChecked = ctl_isLost.zz_CheckValue;
            //string existingStage = xDeal.ClosureReason;
            string selectedReason = "";

            //Convert to the new stage names
            xDeal.opportunity_stage = RzWin.Context.TheSysRz.TheOrderLogic.GetAndSyncOpportunityStage(RzWin.Context, xDeal);
            //xDeal.opportunity_stage = RzWin.Context.TheSysRz.TheOrderLogic.ConvertToNewOpportunityStageName(xDeal.opportunity_stage);
            //string lostReason = ctl_opportunity_lost_reason.GetValue_String();
            bool reopen = false;
            if (lostChecked && xDeal.opportunity_stage != SM_Enums.OpportunityStage.sale_lost.ToString())
            {
                //Ensure RZ Opportunity marked Lost
                bool RzsuccessfullySetLost = RzWin.Context.TheSysRz.TheOrderLogic.SetOpportunityLost(RzWin.Context, xDeal, selectedReason, out selectedReason);
                if (!RzsuccessfullySetLost)
                {
                    RzWin.Leader.Error("Failed to set opportunity to lost.");
                    ctl_isLost.zz_CheckValue = false;
                    return;
                }
                //Mark the Hubspot Deal Lost
                if (TheHubspotDeal != null)
                {
                    //IF already lost, do nothing
                    if (TheHubspotDeal.properties.ContainsKey("dealstage"))
                    {
                        //If the dealstage is know, check if already closed to avoid unnecessary HS update, and possible workflow trigger
                        if (TheHubspotDeal.properties["dealstage"].value != HubspotApi.DealStage.sale_lost)
                            HubspotApi.Deals.SetDealLost(TheHubspotDeal.dealId, selectedReason, false);

                    }
                    else  //If the dealstage is not known, needs to be set to closed.
                        HubspotApi.Deals.SetDealLost(TheHubspotDeal.dealId, selectedReason, false);
                }
            }

            //Update the Deal Stage for the Rz Object
            gbOpportunityStage.Text = xDeal.opportunity_stage;
            CompleteLoadOpportunity();
        }


        private void ctlApproved_CheckChanged(object sender)
        {

            xDeal.is_approved = ctlApproved.GetValue_Boolean();
            xDeal.Update(RzWin.Context, true);

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
        }
        protected void timer_Tick(object sender, EventArgs e)
        {
            if (lblProblemCustomer.ForeColor == Color.Black)
                lblProblemCustomer.ForeColor = Color.Red;
            else
                lblProblemCustomer.ForeColor = Color.Black;
        }

        protected void GetOutstandingARAP()
        {
            double d = RzWin.Context.TheSysRz.TheCompanyLogic.CalculateOutstandingBalance_Company(RzWin.Context, CurrentCompany);
            if (d > 0)
                lblOutstandingInvoiceAmnt.Text = "Outstanding Balance: " + d.ToString("C");
            else
                lblOutstandingInvoiceAmnt.Visible = false;
        }

        private void ctl_is_oem_product_CheckChanged(object sender)
        {
            if (ctl_is_oem_product.zz_CheckValue == true)
            {
                ctl_oem_product_name.Visible = true;
                ctl_oem_product_qty.Visible = true;
            }
            else
            {
                ctl_oem_product_name.Visible = false;
                ctl_oem_product_qty.Visible = false;
            }
        }

        private void lvReqs_AboutToAction(object sender, ActArgs args)
        {
            string test = null;
        }


        private void btnCreateHubspotBatch_Click(object sender, EventArgs e)
        {
            RzWin.Leader.ManageHubspot(RzWin.Context, xDeal);
        }

        private void llblDealLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                VisitLink();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }


        private void llEditHubspotDeal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RzWin.Leader.ManageHubspot(RzWin.Context, xDeal);
        }


        private void VisitLink()
        {
            // Change the color of the link text by setting LinkVisited   
            // to true.  
            CompleteLoadHubspot();
            llblDealLink.LinkVisited = true;
            //Call the Process.Start method to open the default browser   
            //with a URL:           
            //if (TheHubspotDeal.dealId == 0)
            //    CompleteLoadHubspot();
            string hsDealURL = @"https://app.hubspot.com/sales/1878634/deal/" + TheHubspotDeal.dealId;
            System.Diagnostics.Process.Start(hsDealURL);
        }

        private void mnuCreateQuote_Click(object sender, EventArgs e)
        {
            if (CurrentCompany.is_locked)
                RzWin.Context.Leader.Tell("Customer is locked. Cannot create quote.");


            ArrayList quoteIds = lvQuotes.GetSelectedIDs();
            List<string> quoteIdList = new List<string>();
            foreach (string s in quoteIds)
                quoteIdList.Add(s);
            CreateQuote(quoteIdList);
        }

        private void lblAgent_Click(object sender, EventArgs e)
        {
            string strName = "";
            string strID = "";
            frmChooseUser.ChooseUserName(ref strID, ref strName, null, false);

            if (!Tools.Strings.StrExt(strID))
                return;
            NewMethod.n_user u = NewMethod.n_user.GetById(RzWin.Context, strID);
            if (u != null)
            {
                lblAgent.Text = u.Name;
                xDeal.base_mc_user_uid = u.unique_id;
                xDeal.agentname = u.name;
                //if (!string.IsNullOrEmpty(CurrentCompany.split_commission_agent_uid))//If this company has a split agent
                //    RzWin.Context.TheSysRz.TheQuoteLogic.SetSplitCommission(RzWin.Context, u.unique_id, xDeal, CurrentCompany.split_commission_agent_uid, CurrentCompany.split_commission_default_type);


                xDeal.Update(RzWin.Context);
            }
            LoadReqQuoteLV();
        }



        private void ctl_isLost_CheckChanged(object sender)
        {
            //ctl_opportunity_lost_reason.Enabled = ctl_isLost.zz_CheckValue;

        }

        private void llSplitAgent_Click(object sender, EventArgs e)
        {
            try
            {
                SplitCommission s = new SplitCommission();
                s.Text = "Set split commisison for all batch lines.";
                //s.CompleteLoad(RzWin.Context, xDeal.split_commission_agent_uid, xDeal.split_commission_type);
                s.isModal = true;
                s.CompleteLoad(RzWin.Context, xDeal);
                //https://www.youtube.com/watch?v=8aDsXyiBLsI
                Form scForm = new Form();
                scForm.Controls.Add(s);
                scForm.AutoSize = true;
                scForm.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                var result = scForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    split_commission sc = s.splitCommissionObject;
                    if (sc != null)
                        if (!string.IsNullOrEmpty(sc.unique_id))
                        {
                            xDeal.split_commission_ID = sc.unique_id;
                            xDeal.Update(RzWin.Context);
                        }
                    CompleteLoadSplitCommission();
                }
            }
            catch (Exception ex)
            {
                RzWin.Leader.Error(ex.Message);
            }


        }

        //private void CompleteSaveSplitCommisison()
        //{
        //    if (xDeal.split_commission_agent_uid != null && SplitCommissionType != null)
        //    {
        //        xDeal.split_commission_agent_name = CurrentSplitAgent.name;
        //        xDeal.split_commission_agent_uid = CurrentSplitAgent.unique_id;
        //        xDeal.split_commission_type = SplitCommissionType;

        //    }
        //    else
        //    {
        //        xDeal.split_commission_agent_name = "";
        //        xDeal.split_commission_agent_uid = "";
        //        xDeal.split_commission_type = "";
        //    }

        //    xDeal.Update(RzWin.Context);
        //    UpdateReqLinesForSplitAgent();
        //    LoadReqQuoteLV();
        //    CompleteLoadSplitCommission();
        //}
        //private void UpdateReqLinesForSplitAgent()
        //{
        //    List<orddet_quote> quoteList = xDeal.GetAllOrddetQuotes(RzWin.Context).Cast<orddet_quote>().ToList();
        //    foreach (orddet_quote q in quoteList)
        //    {
        //        if (CurrentSplitAgent != null && SplitCommissionType != null)
        //        {
        //            q.split_commission_agent_name = CurrentSplitAgent.name;
        //            q.split_commission_agent_uid = CurrentSplitAgent.unique_id;
        //            q.split_commission_type = SplitCommissionType;

        //        }
        //        else
        //        {
        //            q.split_commission_agent_uid = "";
        //            q.split_commission_agent_name = "";
        //            q.split_commission_type = "";
        //        }
        //        q.Update(RzWin.Context);
        //    }

        //}


        private void addGCATServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                AddGCATService();
                LoadReqQuoteLV();
            }
            catch (Exception ex)
            {
                RzWin.Context.Leader.Error(ex.Message);
            }


        }



        private void AddGCATService()
        {
            //Get the req to be tested
            orddet_quote reqBeingTested = null;
            //First see if there part in the lvReqs is selected (add from lvReqs)
            if (reqBeingTested == null)
                reqBeingTested = (orddet_quote)lvReqs.GetSelectedObject();
            //If still null, maybe user fired this from lvQuotes
            if (reqBeingTested == null)
                reqBeingTested = (orddet_quote)lvQuotes.GetSelectedObject();
            //If still null, invalid.
            if (reqBeingTested == null)
                throw new Exception("Please first add a req for the part number to be tested, including the target quantity.");

            //Use the req to attach a GCAT Bid and auto-accept.   
            //THis will create a new req, by duplicating the selected req            
            orddet_quote TheGCATReq = (orddet_quote)RzWin.Context.TheSysRz.TheLineLogic.CreateGCATLine(RzWin.Context, reqBeingTested);

            if (TheGCATReq != null)
            {
                //q.Update(RzWin.Context);
                TheReq = TheGCATReq;
                TheQuote = null;
                ShowObject(TheGCATReq);
            }


        }



    }
}
