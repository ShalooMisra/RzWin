using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;

using Tools;
using Core;
using NewMethod;
using Enums = Rz5.Enums;
using shippingaccount = Rz5.shippingaccount;
using ordhed = Rz5.ordhed;
using companyaddress = Rz5.companyaddress;
using companycontact = Rz5.companycontact;
using usernote = Rz5.usernote;
using orddet = Rz5.orddet;
using companycredit = Rz5.companycredit;
using SensibleDAL;
using HubspotApis;
using SensibleDAL.dbml;

namespace Rz5
{
    public partial class ViewHeader : ViewPlusMenu   //, IChangeSubscriber
    {
        //Public Variables
        public ordhed CurrentOrder
        {
            get
            {
                return (ordhed)GetCurrentObject();
            }
            set
            {
                SetCurrentObject(value);
            }
        }
        public company CurrentCompany
        {
            get
            {
                return (company)CurrentOrder.CompanyVar.RefGet(RzWin.Context);
            }
            set
            {
                SetCurrentObject(value);
            }
        }



        //Private Variables
        private Rz5.companyaddress AddressToWatch;
        private NewMethod.n_user OrderAgent;
        private bool IsLoading = false;
        private int action_index;
        Bitmap OriginalHeader = null;
        //Bitmap CurrentHeader = null;
        //Constrcutors
        HubspotApi.Deal TheHubspotDeal;


        public ViewHeader()
        {
            InitializeComponent();

            throb1.BackColor = Color.White;
            throb2.BackColor = Color.White;
            Rz5.PartPictureViewer.PictureAdded += new Rz5.PictureAddedHandler(PartPictureViewer_PictureAdded);
            Rz5.PartPictureViewer.PictureRemoved += new Rz5.PictureRemovedHandler(PartPictureViewer_PictureRemoved);
            picHeader.BackColor = Color.White;
        }





        protected override void InitUn()
        {
            base.InitUn();
            try
            {
                OriginalHeader.Dispose();
                OriginalHeader = null;
            }
            catch { }
        }
        //Public Virtual Functions
        public virtual void LoadAddressLists(company c)
        {
            if (c == null)
            {
                cboShippingAddress.ClearList();
                cboBillingAddress.ClearList();
                return;
            }
            //Addresses
            //KT 9-21-2015 - Removed "distinct" from the query so all addresses are returned, even if same description (i.e. billing, billing)
            //ArrayList a = RzWin.Context.SelectScalarArray("SELECT DISTINCT(DESCRIPTION) FROM companyaddress WHERE description > '' and base_company_uid = '" + c.unique_id + "' ORDER BY DESCRIPTION");
            ArrayList a = RzWin.Context.SelectScalarArray("SELECT DESCRIPTION FROM companyaddress WHERE description > '' and base_company_uid = '" + c.unique_id + "' ORDER BY DESCRIPTION");

            cboShippingAddress.ClearList();
            cboShippingAddress.AddFromArray(a);
            cboShippingAddress.Add("<local>");
            //KT add our custom PO shipping addresses
            if (CurrentOrder.OrderType == Enums.OrderType.Purchase)
            {
                cboShippingAddress.Add("<White Horse [China]>");
                cboShippingAddress.Add("<White Horse [Hong Kong]>");
                //cboShippingAddress.Add("<Retronix Ltd>");
                cboShippingAddress.Add("<Emporium Services Aps>");
            }

            cboBillingAddress.ClearList();
            cboBillingAddress.AddFromArray(a);
            cboBillingAddress.Add("<local>");
        }
        public virtual void LoadAddressLists(Rz5.companycontact c)
        {
            if (c.HasValidMailingAddress())
            {
                cboBillingAddress.Add("Contact address for " + c.contactname);
                cboShippingAddress.Add("Contact address for " + c.contactname);
            }
        }
        //Public Override Function
        public override void Init(Item item)
        {
            base.Init(item);
            //RzWin.Context.xSys.RegisterNotifyClass(this, "orddet_line");
            //RzWin.Context.xSys.RegisterNotifyClass(this, "orddet_quote");
            //RzWin.Context.xSys.RegisterNotifyClass(this, "companyaddress");
        }
        bool rendered = false;
        public override void CompleteLoad()
        {
            //Controls, Delete Button, etc.
            base.CompleteLoad();

            agent.UserVarName = "Agent222";
            IsLoading = true;

            try
            {
                if (!rendered)
                {
                    RenderHeaderBar();
                    rendered = true;
                }
            }
            catch { }
            OrderAgent = NewMethod.n_user.GetById(RzWin.Context, CurrentOrder.base_mc_user_uid);



            //Load the "Actions Needed to Complete" report box
            //LoadCompletionReport();this is now inside LoadMissingProperties
            CurrentOrder.LoadMissingProperties(RzWin.Context);

            LoadCompletionReport();

            //Set the Current Order Object for the Agent Control
            LoadCompanyControl();

            //Set the Current Order Object for the Company Control
            LoadAgentControl();

            //Load Details
            LoadDetails();

            //Load Totals - This takes a long time.
            CompleteLoad_Totals();

            //Load Company Specific Data (address, etc)
            CompleteLoad_Company((company)CurrentOrder.CompanyVar.RefGet(RzWin.Context));

            //This takes a long time too
            CompleteLoadAttachments();
            CompleteLoadActionsMenu();
            CompleteLoad_Status();
            CompleteLoadOrderButtons();


            CompleteLoadProblemCompanyAlert();
            GetOutstandingARAP();
            CompleteLoad_Dates();
            CompleteLoad_ShipAccounts();
            CompleteLoad_Shipping();
            CompleteLoadOtherTabs();
            CompleteLoadHubspot();
            lblSaveThisOrder.BringToFront();
            lblSaveThisOrder.Visible = false;
            picComplete.BringToFront();
            IsLoading = false;
        }

        private void CompleteLoadOrderButtons()
        {          
            //ResizeforNewIcons(cmdAction1);
            //ResizeforNewIcons(cmdAction2);
        }

        private void CompleteLoadHubspot()
        {
            llEditHubspotDeal.Visible = false;
            //Update the deal to the API before loading - This is important to make sure deals get updated as they progress from, for example, batch to Formal quote.  Sets the new name, etc.
            //if (OrderAgent != null)
            //    if (OrderAgent.is_hubspot_enabled)
            //        TheHubspotDeal = RzWin.Context.TheSysRz.TheOrderLogic.UpdateHubspotDeal(RzWin.Context, CurrentOrder);
            //Load Control
            TheHubspotDeal = RzWin.Context.TheSysRz.TheOrderLogic.LoadHubspotDealControls(RzWin.Context, gbHubspot, llblDealLink, CurrentOrder);
            if (TheHubspotDeal != null)
                llEditHubspotDeal.Visible = (RzWin.Context.CheckPermit(Permissions.ThePermits.CanManageHubspot));


        }




        public void LoadCompletionReport()
        {

            //KT IMPORTANT!!! I played with only calling this once, within ViewHeader.LoadMissingProperties.  I started bumping into cross threading issues, so I need to call it from the 
            //Sort of expaination:  the Buttons on Orders work via the "Backgroubd Worker" thread (Worker Thread).  That thread calls LoadMissingProperties(), which in turn used to call LoadCompletionReport, which
            //Interacts with controls (Main Thread).  THis is not allowed.  I could probably remove the calls to controls, and save this into a variable on ViewHeader, then call it on loadStatus or something, but for now this will do.
            try
            {
                if (CurrentOrder.OrderType == Enums.OrderType.Purchase)
                    if (!ShowCompletionReport())
                        return;


                rtReport.Text = "";
                string reportText = "";
                //LoadMissingProperties();
                //gbReport.Visible = false;

                foreach (KeyValuePair<nObject, List<string>> kvp in CurrentOrder.MissingPropertiesList)
                {
                    foreach (string s in kvp.Value)
                        reportText += RzWin.Context.TheSysRz.TheOrderLogic.GetFriendlyReportText(RzWin.Context, kvp.Key, s) + Environment.NewLine;
                }
                if (!string.IsNullOrEmpty(reportText))
                {

                    gbReport.Visible = true;
                    rtReport.Text = reportText;
                    gbReport.BringToFront();

                }
            }
            catch (Exception ex)
            {
                RzWin.Context.Error(ex.Message + Environment.NewLine + Environment.NewLine + "Inner Exception:" + Environment.NewLine + ex.InnerException);
            }
        }

        private bool ShowCompletionReport()
        {
            bool ret = false;
            switch (CurrentOrder.OrderType)
            {
                case Enums.OrderType.Purchase:
                    {
                        ordhed_purchase p = (ordhed_purchase)CurrentOrder;
                        if (p.is_consign)
                            ret = false;
                        else
                            ret = true;
                        break;
                    }
                case Enums.OrderType.RMA:
                case Enums.OrderType.VendRMA:
                case Enums.OrderType.Service:
                case Enums.OrderType.Invoice:
                case Enums.OrderType.RFQ:
                    ret = false;
                    break;
                default:
                    ret = true;
                    break;


            }
            return ret;
        }

        //private void AddMissingLogicsToMissingProperties(ContextRz context, List<string> missingLogics)
        //{
        //    if (CurrentOrder.MissingPropertiesList.ContainsKey(CurrentOrder))
        //    {
        //        CurrentOrder.MissingPropertiesList[CurrentOrder].AddRange(missingLogics);

        //    }
        //    else
        //        CurrentOrder.MissingPropertiesList.Add(CurrentOrder, missingLogics);



        //}

        private void CompleteLoadActionsMenu()
        {
            if (xActions.IsDisabled())
            {
                xActions.Enabled = true;
                xActions.DisableExcept("|Print|Print PDF|Fax|Email|Make RMA|Links|Deal|View Order Batch|");


            }
            else
            {
                xActions.EnableDelete = CurrentOrder.CanBeDeletedBy(RzWin.Context);
            }
        }

        private void LoadDetails()
        {
            details.CurrentVar = CurrentOrder.Details;
            details.Init(CurrentOrder.DetailArgsGet(RzWin.Context));
        }

        private void LoadCompanyControl()
        {
            cStub.CurrentObject = CurrentOrder;
            cStub.CompanyIDField = "base_company_uid";
            cStub.CompanyNameField = "companyname";
            cStub.ContactIDField = "base_companycontact_uid";
            cStub.ContactNameField = "contactname";
            cStub.SetCompany();
        }

        private void LoadAgentControl()
        {
            agent.CurrentObject = CurrentOrder;
            agent.CurrentIDField =
            agent.CurrentIDField = "base_mc_user_uid";
            agent.CurrentNameField = "agentname";
            agent.SetUserName();
        }

        private void CompleteLoadOtherTabs()
        {
            if (CurrentOrder.OrderType == Enums.OrderType.Invoice || CurrentOrder.OrderType == Enums.OrderType.VendRMA)
                LoadCreditCharges();
            else
                ts.TabPages.Remove(tabCreditsCharges);


            //KT 11-30-2015 - CompanyCredits
            if (CurrentOrder.OrderType == Enums.OrderType.Purchase || CurrentOrder.OrderType == Enums.OrderType.Service || CurrentOrder.OrderType == Enums.OrderType.RMA || CurrentOrder.OrderType == Enums.OrderType.Invoice)
            {
                if (CurrentCompany != null)
                    LoadCompanyCredits();
                else
                    ts.TabPages.Remove(tabCompanyCredits);
            }
            else
                ts.TabPages.Remove(tabCompanyCredits);
        }

        private void ResizeforNewIcons(Button btn)
        {
            try
            {
                btn.Width = 120;
                btn.Height = 120;
                btn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                //Resize the background image to fit the button (If exists)

                Panel gb = gbAction1;
                if (btn.Name == "cmdAction2")
                    gb = gbAction2;
                //Get the Image Key, resize on fly to match button            
                if (!string.IsNullOrEmpty(btn.ImageKey))
                {
                    Bitmap b = new Bitmap(this.ilActions.Images[btn.ImageKey]);
                    var pic = new Bitmap(b, new Size(btn.Width - 2, btn.Height - 2));
                    btn.BackgroundImage = pic;
                    btn.ImageKey = null;

                }
            }
            catch (Exception ex)
            {

            }


        }


        void RenderHeaderBar()
        {
            if (OriginalHeader == null)
                OriginalHeader = new Bitmap(picHeader.BackgroundImage);

            //CurrentHeader = new Bitmap(OriginalHeader, new Size(OriginalHeader.Width, OriginalHeader.Height));

            Graphics g = Graphics.FromImage(OriginalHeader);
            g.DrawString(CurrentOrder.FriendlyOrderType + " " + CurrentOrder.ordernumber, new Font("Calibri", 20.0F, FontStyle.Bold), Brushes.White, new Point(8, 8));
            g.Dispose();
            g = null;

            picHeader.BackgroundImage = OriginalHeader;
        }

        public override void CompleteSave()
        {
            //Grabs the form values (ctl_)
            base.CompleteSave();

            //should this completeload everything?
            //KT 8-27-2015 - I didn't write the abotve,  but I concur.  However
            CompleteLoad_Status();
            //CompleteLoad_Company(CurrentOrder.CompanyVar.RefGet(RzWin.Context));
            //CompleteLoad_Totals();
            //CheckForCompanyCredits();

            CompleteSaveOpportunity();
            //CompleteSaveHubspot();

            //Delay!!
            CompleteSaveAgentInformation();

            
        }

        private void CompleteSaveAgentInformation()
        {
            //IF company or agent changed, update Order and line agent as well as splits on save.
            //use CurrentCompany for agent and splits
            //NewMethod.n_user companyAgent = null;
            NewMethod.n_user theAgent = null;
            if (CurrentCompany != null)
                if (CurrentCompany.agentname.ToLower() == "vendor")
                    return;

            switch (CurrentOrder.OrderType)
            {
                case Enums.OrderType.Sales:
                case Enums.OrderType.Quote:
                    {
                        //When no company set yet, just return
                        if (CurrentCompany == null)
                            return;


                        //Check for Company Agent
                        theAgent = NewMethod.n_user.GetById(RzWin.Context, CurrentCompany.base_mc_user_uid);
                        if (theAgent == null)
                            throw new Exception(CurrentCompany.companyname + " is currently associated with a user (" + CurrentCompany.agentname + ") that no longer exists.  Please update the company owner before proceeding with a sale.");
                        if (theAgent.name == "House")
                            throw new Exception("'House' is not a valid sales agent. Please assign this company to sales agent. ");
                        if (theAgent.name == "Vendor")
                            theAgent = NewMethod.n_user.GetByName(RzWin.Context, agent.GetUserName());

                        break;

                    }
                default:
                    {
                        theAgent = NewMethod.n_user.GetByName(RzWin.Context, agent.GetUserName());
                        break;
                    }


            }
            if (theAgent == null)
            {
                theAgent = NewMethod.n_user.GetById(RzWin.Context, CurrentOrder.base_mc_user_uid);
                return;
                //throw new Exception("Alert, the agent on this order (" + agent.GetUserName() + ") is not a valid Rz User.  The Company may still be assigned to a new user.  Please correct the agent for this order to proceed.");
            }


            CurrentOrder.agentname = theAgent.name;
            if (CurrentOrder.base_mc_user_uid != theAgent.unique_id)
            {
                //CurrentOrder.base_mc_user_uid = theAgent.unique_id;
                //Delay
                CurrentOrder.AgentVar.RefSet(RzWin.Context, theAgent, false);
                // Upodate Header
                //CurrentOrder.Update(RzWin.Context);
                //Udpate Lines
                SetLinesAgents(theAgent);
                //Update Splits
                //SetSplitAgents();
            }





        }

        //private void SetSplitAgents()
        //{
        //    try
        //    {


        //        switch (CurrentOrder.OrderType)
        //        {
        //            case Enums.OrderType.Quote:
        //                {
        //                    foreach (orddet_quote q in CurrentOrder.DetailsList(RzWin.Context))
        //                    {
        //                        //NewMethod.n_user splitAgent = NewMethod.n_user.GetById(RzWin.Context, CurrentCompany.split_commission_agent_uid);
        //                        //RzWin.Context.TheSysRz.TheProfitLogic.SetSplitCommissionForObject(RzWin.Context, q, splitAgent, CurrentCompany.split_commission_default_type);
        //                    }
        //                    break;
        //                }
        //            case Enums.OrderType.Sales:
        //                {
        //                    if (CurrentCompany == null)
        //                        return;
        //                    if (string.IsNullOrEmpty(CurrentCompany.split_commission_agent_uid))
        //                        return;
        //                    foreach (orddet_line l in CurrentOrder.DetailsList(RzWin.Context))
        //                    {

        //                        //NewMethod.n_user splitAgent = NewMethod.n_user.GetById(RzWin.Context, CurrentCompany.split_commission_agent_uid);
        //                        //RzWin.Context.TheSysRz.TheProfitLogic.SetSplitCommissionForObject(RzWin.Context, l, splitAgent, CurrentCompany.split_commission_default_type);
        //                    }
        //                    break;
        //                }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        RzWin.Context.Error("Error setting split agents: " + ex.Message);
        //    }




        //}

        private void CompleteSaveOpportunity()
        {

            CurrentOrder.opportunity_stage = RzWin.Context.TheSysRz.TheOrderLogic.GetAndSyncOpportunityStage(RzWin.Context, CurrentOrder);


        }

        //public void CompleteSaveHubspot(bool CreateDealIfNotExist = false)
        //{

        //    if (OrderAgent == null)
        //        return;
        //    if (!OrderAgent.is_hubspot_enabled)
        //        return;

        //    try
        //    {
        //        //CompleteLoadHubspot();
        //        Dictionary<string, string> props = null;
        //        //Hubspot only syncs from sales related ordheds (invoice, sales).
        //        //During the sync, the Sales Order values are uses, as therein lies the buld of Sensible Profit Logic
        //        if (CurrentOrder.OrderType != Enums.OrderType.Sales && CurrentOrder.OrderType != Enums.OrderType.Invoice && CurrentOrder.OrderType != Enums.OrderType.Quote)
        //            return;

        //        //Initial Hubspot Sync
        //        TheHubspotDeal = SensibleDAL.HubspotLogic.GetAndSyncRelatedHubspotID(CurrentOrder);


        //        if (TheHubspotDeal == null)
        //        {    //Create the deal if desired               
        //            //Ignore in test system.
        //            if (Strings.HasString(RzWin.Context.Data.DatabaseName, "test"))
        //                return;
        //            //Omit Kevin
        //            if (RzWin.Context.xUser.Name == "Kevin Till")
        //                return;
        //            //don't make Hubspot Deals when testing as ken
        //            if (!RzWin.Context.xUser.is_hubspot_enabled)
        //                return;
        //            if (RzWin.Context.Leader.AskYesNo("There doesn't appear to be a Hubspot Deal associated with this order.  Would you like to create it now?"))
        //            {
        //                string contactID = cStub.ContactID;
        //                string contactEmail = null;
        //                //Get the contact for this deal
        //                companycontact c = companycontact.GetById(RzWin.Context, contactID);
        //                if (c == null)
        //                    throw new Exception("Cannot create deal:  Null companycontactcontact.");
        //                //Confirm valid email address for deal contact
        //                if (!Email.IsEmailAddress(c.primaryemailaddress))
        //                {
        //                    //Ask the user for a better email
        //                    contactEmail = RzWin.Leader.AskForString(c.primaryemailaddress + " is not a valid email address.  Please correct it before proceeding.");
        //                    //If the email is still invalid, throw exception
        //                    if (!Email.IsEmailAddress(contactEmail))
        //                        throw new Exception(c.primaryemailaddress + " is not a valid email address.");
        //                    //We have a valid email, offer to update in in Rz, and create a deal.
        //                    if (RzWin.Leader.AskYesNo("Would you like to update the contact's email address to " + contactEmail + "?"))
        //                    {
        //                        c.primaryemailaddress = contactEmail.Trim().ToLower();
        //                        c.Update(RzWin.Context);
        //                    }
        //                }

        //                //Build Properties for this order
        //                //props = RzWin.Context.TheSysRz.TheOrderLogic.GenerateHubspotProperties(RzWin.Context, CurrentOrder);
        //                //Create the Hubspot Deal
        //                TheHubspotDeal = RzWin.Context.TheSysRz.TheOrderLogic.CreateHubspotDeal(RzWin.Context, CurrentOrder);
        //                if (TheHubspotDeal == null)
        //                    RzWin.Context.Error("There was a problem creating the hubspot deal for the contact " + contactEmail);
        //            }

        //        }
        //        else
        //        {//Update the deal.

        //            long dealID = TheHubspotDeal.dealId;
        //            if (dealID <= 0)
        //            {
        //                //RzWin.Leader.Error("Invalid DealID. (" + dealID + ")");
        //                return;
        //            }
        //            TheHubspotDeal = RzWin.Context.TheSysRz.TheOrderLogic.UpdateHubspotDeal(RzWin.Context, CurrentOrder);
        //        }




        //        //There may have been a deal assigned at some point, deal may have been deleted in Hubspot.  Since not found on load, let's remove that reference:
        //        if (TheHubspotDeal == null)
        //        {
        //            //Check Associated DealHeader and related Quotes for HubID
        //            //Clear any bad Deal References
        //            if (CurrentOrder.hubspot_deal_id > 0)
        //            {
        //                CurrentOrder.hubspot_deal_id = 0;
        //                CurrentOrder.Update(RzWin.Context);
        //            }

        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        RzWin.Context.Leader.Error(ex.Message);
        //    }

        //}


        //Public Functions
        public void NotifyChangeHandler(String strClass, bool adds)
        {
            ChangeHandler(strClass, adds);
        }
        public void NotifyChange(String strClass, bool adds)
        {
            Change(strClass, adds);
        }
        public void AddAddress(String strName, bool billing, bool shipping)
        {
            if (CurrentOrder.CompanyVar.RefGet(RzWin.Context) == null)
            {
                RzWin.Leader.Tell("Please choose a company before adding an address.");
                return;
            }
            companyaddress c = companyaddress.New(RzWin.Context);
            c.description = strName;
            c.defaultbilling = billing;
            c.defaultshipping = shipping;
            c.base_company_uid = CurrentOrder.CompanyVar.RefGet(RzWin.Context).unique_id;
            c.Insert(RzWin.Context);
            AddressToWatch = c;
            RzWin.Context.Show(c);
        }
        //Protected Virtual Functions
        protected virtual void ChangeHandler(String strClass, bool adds)
        {
            try
            {
                switch (strClass.ToLower().Trim())
                {
                    case "companyaddress":
                        LoadAddressLists((company)CurrentOrder.CompanyVar.RefGet(RzWin.Context));
                        if (AddressToWatch != null)
                            LoadAddress(AddressToWatch);
                        break;
                    default:
                        if (strClass.ToLower().StartsWith("orddet"))
                        {
                            details.RefreshFromCollection();
                            CurrentOrder.Update(RzWin.Context);
                            CompleteLoad_Totals();
                            CompleteLoad_Status();
                            CompleteLoad_Shipping();
                            CompleteLoad_ShipAccounts();
                        }
                        break;
                }
            }
            catch { }
        }
        protected virtual void Change(String strClass, bool adds)
        {
            //try
            //{
            //    if (this.InvokeRequired)
            //    {
            //        HandleChangeNotification d = new HandleChangeNotification(ChangeHandler);
            //        this.Invoke(d, new object[] { strClass, adds });
            //    }
            //    else
            //    {
            //        ChangeHandler(strClass, adds);
            //    }
            //}
            //catch (Exception)
            //{
            //}
        }
        protected virtual void CompleteLoad_Status()
        {
            //lblStatus.Visible = true;
            gbTotals.BringToFront();
            gbAction1.Visible = false;
            gbAction2.Visible = false;
            switch (CurrentOrder.OrderType)
            {
                //Only showing the "Fix button" for Sales, Quotes, since a pack mistake could cause a prop to go away (i.e. if you forget to click "condition" in the pack)
                //And in these cases, I don't want fix to fix it, I want them to correct it manually or by editing the pack.
                case Enums.OrderType.Quote:
                case Enums.OrderType.Sales:
                case Enums.OrderType.Purchase:
                    //case Enums.OrderType.Invoice:
                    //case Enums.OrderType.RMA:
                    //case Enums.OrderType.VendRMA:
                    btnFixComplete.Visible = true;
                    break;
                default:
                    btnFixComplete.Visible = false;
                    break;

            }

            bool isQbAdded = IsQbAdded();
            gbAddedToQb.Visible = isQbAdded;


            if (CurrentOrder.isvoid)
            {
                WriteStatus("Void");
                //lblStatus.Text = "VOID";
                //lblStatus.BackColor = Color.Gainsboro;
                //lblStatus.ForeColor = Color.DarkGray;
            }
            else if (CurrentOrder.isclosed)
            {
                WriteStatus("Complete");
                //lblStatus.Text = "CLOSED";
                //lblStatus.BackColor = Color.LightBlue;
                //lblStatus.ForeColor = Color.DarkBlue;
            }
            else if (CurrentOrder.onhold)
            {
                WriteStatus("Hold");
                //lblStatus.Text = "HOLD";
                //lblStatus.BackColor = Color.MistyRose;
                //lblStatus.ForeColor = Color.Red;
            }
            else
            {
                WriteStatus("Open");
                //lblStatus.Text = "OPEN";
                //lblStatus.BackColor = Color.LightGreen;
                //lblStatus.ForeColor = Color.DarkGreen;
            }

            //if (CurrentOrder.isvoid)
            //    lblOrderType.ForeColor = System.Drawing.Color.Gray;
            //else
            //    lblOrderType.ForeColor = System.Drawing.Color.Black;



        }

        protected bool IsQbAdded()
        {
            bool ret = false;
            if (!string.IsNullOrEmpty(CurrentOrder.qb_order_TxnID))
                ret = true; // != null = true = added
            return ret;
        }



        protected virtual void SetShipVia()
        {

        }
        protected virtual void SetShipAccounts()
        {

        }
        void WriteStatus(String status)
        {
            try
            {
                Bitmap m = null;

                switch (status.ToLower().Trim())
                {
                    case "complete":
                        m = new Bitmap(picComplete.BackgroundImage);
                        break;
                    case "hold":
                        m = new Bitmap(picHold.BackgroundImage);
                        break;
                    case "open":
                        m = new Bitmap(picOpen.BackgroundImage);
                        break;
                    case "void":
                        m = new Bitmap(picVoid.BackgroundImage);
                        break;
                    default:
                        return;
                }


                Bitmap use = new Bitmap(OriginalHeader);
                Graphics g = Graphics.FromImage(use);
                g.DrawImage(m, new Point(use.Width - (m.Width + 8), 3));
                g.Dispose();
                g = null;
                picHeader.BackgroundImage = use;
            }
            catch { }
        }
        protected virtual void CompleteLoad_Dates()
        {
            nlblorderdate.SetValue(nTools.DateFormat(CurrentOrder.orderdate));
            nlblordertime.SetValue(nTools.TimeFormat(CurrentOrder.orderdate));
        }
        protected virtual void CompleteLoad_Totals()
        {

        }
        protected virtual void CompleteLoad_Company(company c)
        {//this is only going to access the screen, not set any property of the order and not do any checking at all


            //Company Address
            LoadAddressLists(c);
        }
        protected virtual void CompleteLoad_Shipping()
        {
            ctl_shipvia.SetValue(CurrentOrder.shipvia);
            ctl_shippingaccount.SetValue(CurrentOrder.shippingaccount);
        }
        protected virtual void CompleteLoad_ShipAccounts()
        {
            ctl_shippingaccount.ClearList();
            if (CurrentOrder == null)
                return;
            if (CurrentCompany == null)
                return;


            //Include this order's current (possibly manual) ship address in otheraddresses
            Dictionary<string, string> otherShippingAddresses = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(CurrentOrder.shippingaccount))
                otherShippingAddresses.Add(CurrentOrder.shippingaccount, "Other");

            //If EMporium Partners PO, don't add their addresses, they will already be there.            
            bool includeEmporium = (CurrentOrder.OrderType == Enums.OrderType.Purchase && CurrentCompany.unique_id != "c75d3d332e0849ab8794fba5a8a921f6");


            Dictionary<string, string> dict = null;
            if (CurrentCompany != null)
                dict = SensibleDAL.ShippingLogic.LoadShippingAccountDictionary(CurrentCompany.unique_id, otherShippingAddresses, includeEmporium);

            if (dict != null)
                ctl_shippingaccount.AddFromDictionary(dict);
            //On the header, we want to display the Value as well since the DDL acts more like a "Label" for what the user is choosing.
            string displayValue = dict.Where(w => w.Key == CurrentOrder.shippingaccount).Select(s => s.Key + " (" + s.Value + ")").FirstOrDefault();
            if (!string.IsNullOrEmpty(displayValue))
                ctl_shippingaccount.SetValue(displayValue);


        }
        protected virtual void Action1()
        {

        }
        protected virtual void Action2()
        {

        }
        protected virtual void Action1Complete()
        {
            throb1.HideThrobber();
            cmdAction1.Enabled = true;
        }
        protected virtual void Action2Complete()
        {
            throb2.HideThrobber();
            cmdAction2.Enabled = true;
        }
        //Protected Override Functions
        protected override void DoResize()
        {
            try
            {
                base.DoResize();

                tsDetails.Left = ts.Left;
                tsDetails.Top = ts.Bottom + 3;
                tsDetails.Height = (this.ClientRectangle.Height - tsDetails.Top) - 5;
                tsDetails.Width = AreaAvailable.Width - tsDetails.Left;

                details.Left = 0;
                details.Width = tabLines.ClientRectangle.Width;
                details.Top = 0;
                details.Height = tabLines.ClientRectangle.Height;

                lblSaveThisOrder.Left = details.Left + (details.Width / 2) - (lblSaveThisOrder.Width / 2);
                lblSaveThisOrder.Top = details.Top + details.BottomBarTop;
            }
            catch (Exception)
            {
            }
        }
        private void CompleteDispose()
        {
            try
            {
                //custom
                Rz5.PartPictureViewer.PictureAdded -= new Rz5.PictureAddedHandler(PartPictureViewer_PictureAdded);
                Rz5.PartPictureViewer.PictureRemoved -= new Rz5.PictureRemovedHandler(PartPictureViewer_PictureRemoved);
                //auto
                this.ts.SelectedIndexChanged -= new System.EventHandler(this.ts_SelectedIndexChanged);
                this.lblChangeDate.LinkClicked -= new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblChangeDate_LinkClicked);
                this.cStub.ChangeCompany -= new Rz5.ContactEventHandler(this.cStub_ChangeCompany);
                this.cStub.ChangeContact -= new Rz5.ContactEventHandler(this.cStub_ChangeContact);
                this.cmdSwitchAddress.Click -= new System.EventHandler(this.cmdSwitchAddress_Click);
                this.lblAddNewShiping.LinkClicked -= new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAddNewShiping_LinkClicked);
                this.lblAddNewBilling.LinkClicked -= new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAddNewBilling_LinkClicked);
                this.cmdShipBill.Click -= new System.EventHandler(this.cmdShipBill_Click);
                this.cmdBillShip.Click -= new System.EventHandler(this.cmdBillShip_Click);
                this.cboBillingAddress.SelectionChanged -= new NewMethod.nEdit_List.SelectionChangedHandler(this.cboBillingAddress_SelectionChanged);
                this.cboShippingAddress.SelectionChanged -= new NewMethod.nEdit_List.SelectionChangedHandler(this.cboShippingAddress_SelectionChanged);
                this.details.AboutToAdd -= new NewMethod.AddHandler(this.details_AboutToAdd);
            }
            catch
            {
            }
        }
        private void CompleteLoadAttachments()
        {
            try
            {
                //Int64 i = RzWin.Context.SelectScalarInt64("select count(*) from partpicture where the_orddet_uid in (select unique_id from " + ordhed.MakeOrddetName(CurrentOrder.OrderType) + " where base_ordhed_uid = '" + CurrentOrder.unique_id + "')");
                Int64 i = CurrentOrder.PictureCount(RzWin.Context);
                tabAttachments.Text = "Attachments(" + i.ToString() + ")";
            }
            catch
            {
            }
        }
        private void SetAddress(nEdit_List cbo, nEdit_Memo txt, String strQBField)
        {
            //KT moved this out of a condition below, so it would be available to all logic branches
            company c = (company)CurrentOrder.CompanyVar.RefGet(RzWin.Context);
            switch (cbo.GetValue_String().Trim().ToLower())
            {
                case "<local>":
                    if (cbo.lblCaption.Text.ToLower().Contains("billing"))
                        ctl_billingname.SetValue(OwnerSettings.GetValue(RzWin.Context, OwnerSettingField.owner_companyname));
                    else
                        ctl_shippingname.SetValue(OwnerSettings.GetValue(RzWin.Context, OwnerSettingField.owner_companyname));
                    if (Tools.Strings.StrExt(RzWin.Context.TheLogicRz.ShipToAddress))
                        txt.SetValue(RzWin.Context.TheLogicRz.ShipToAddress);
                    else
                        txt.SetValue(OwnerSettings.GetAddressBlock(RzWin.Context));
                    break;
                case "<quickbooks>":

                    if (c != null)
                        txt.SetValue((String)c.IGet(strQBField));
                    break;
                //case "<white horse [china]>":
                //    ctl_shippingname.SetValue("White Horse Laboratories [China]");
                //    //txt.SetValue("Suite 809, Dynamic World Building" + Environment.NewLine + "Futian District, Shenzhen" + Environment.NewLine + "China" + Environment.NewLine + "Contact: Zhang Xiaoqin" + Environment.NewLine + "Phone: +86 755-8374-1887");
                //    txt.SetValue("4A Technology Building H, Gang Zhi Long Science Park" + Environment.NewLine + "Heping East Road," + Environment.NewLine + "Longhua,Shenzhen, Guangdong," + Environment.NewLine + "People's Republic of China 518109" + Environment.NewLine + "Contact: Ou Ling / Scarlett" + Environment.NewLine + "Phone: +86 (755) 8358-4884");
                //    break;
                case "<white horse [china]>":
                    {

                        ctl_shippingname.SetValue("White Horse Laboratories (Shenzhen) Ltd.");
                        string whiteHorseAddress = "";
                        whiteHorseAddress += "4A Building H, Gang Zhi Long Science Park" + Environment.NewLine;
                        whiteHorseAddress += "No. 6 Qinglong Road, Qinghua Community," + Environment.NewLine;
                        whiteHorseAddress += "Longhua District" + Environment.NewLine;
                        whiteHorseAddress += "Shenzhen, Guangdong, China";
                        //whiteHorseAddress += Environment.NewLine + "Contact: Ou Ling / Scarlett";
                        //whiteHorseAddress += Environment.NewLine + "Phone: +86 (755) 8358-4884";
                        txt.SetValue(whiteHorseAddress);
                    }

                    //ctl_shippingname.SetValue("White Horse Laboratories (Shenzhen) Ltd.");
                    //txt.SetValue("4A Building H, Gang Zhi Long Science Park"
                    //    + Environment.NewLine + "No. 6 Qinglong Road, Qinghua Community,"
                    //    + Environment.NewLine + "Longhua District,"
                    //    + Environment.NewLine + "Shenzhen, Guangdong, China");
                    //+ Environment.NewLine + "People's Republic of China 518109" 
                    //+ Environment.NewLine + "Contact: Ou Ling / Scarlett" + Environment.NewLine + "Phone: +86 (755) 8358-4884");
                    break;
                case "<white horse [hong kong]>":
                    ctl_shippingname.SetValue("White Horse Laboratories [Hong Kong]");
                    //txt.SetValue("FLAT/RM 905  9/F" + Environment.NewLine + "TSUEN WAN INDUSTRIAL CENTRE" + Environment.NewLine + "220-248 TEXACO ROAD" + Environment.NewLine + "TSUEN WAN NT" + Environment.NewLine + "Contact: Scarlett Guo" + Environment.NewLine + "Phone: +86 755-8374-7489");
                    txt.SetValue("Flat /Rm 905 9/F, Tsuen Wan Industrial Centre" + Environment.NewLine + "220-248 Texaco Rd" + Environment.NewLine + "Tsuen Wan" + "Hong Kong" + Environment.NewLine + "Contact: Scarlett Guo" + Environment.NewLine + "Phone: +86 755-8374-7489");
                    break;
                case "<retronix ltd>":
                    ctl_shippingname.SetValue("Retronix Ltd");
                    txt.SetValue("North Caldeen Road" + Environment.NewLine + "Coatbridge" + Environment.NewLine + "ML5 4EF" + Environment.NewLine + "Scotland" + Environment.NewLine + "Phone: +44 0-1236-433345");
                    break;
                case "<emporium services aps>":
                    ctl_shippingname.SetValue("Emporium Services Aps");
                    txt.SetValue("Sensible Micro, C/O Emporium Services Aps" + Environment.NewLine + "VAT#  2983-0207" + Environment.NewLine + "Horskatten 18" + Environment.NewLine + "2630, Taastrup" + Environment.NewLine + "Denmark" + Environment.NewLine + "Phone: +44 208-339-2565");
                    break;






                default:
                    if (cbo.GetValue_String().StartsWith("Contact address for"))
                    {
                        String contactname = Tools.Strings.ParseDelimit(cbo.GetValue_String(), "Contact address for", 2).Trim();
                        if (!Tools.Strings.StrCmp(contactname, CurrentOrder.ContactVar.RefGet(RzWin.Context).contactname))
                        {
                            RzWin.Leader.Tell("This doesn't appear to be the same contact that's assigned to this order.");
                            return;
                        }
                        txt.SetValue(CurrentOrder.ContactVar.RefGet(RzWin.Context).BuildAddress());
                    }
                    else if (cbo.GetValue_String().ToLower().StartsWith("address option"))
                    {
                        txt.SetValue(RzWin.Context.GetSetting(cbo.GetValue_String()));
                    }
                    else
                    {
                        companyaddress a = companyaddress.GetByDescription(RzWin.Context, CurrentOrder.base_company_uid, cbo.GetValue_String());

                        if (a != null)
                        {
                            if (cbo.lblCaption.Text.ToLower().Contains("billing"))
                            {
                                ctl_billingname.SetValue(c.companyname);

                                //KT 9-4-2015
                                //If there is a primary address (check the primary address checkbox, needs to be only one allowed to be "primary", and that matches the choice selected, then get primary
                                //Is the above even useful, why determine primary unless it's on load of a new sales order to save time? (which it may be, actually that may be ther reason, just for initial sales order load)
                                //If it doesn't match, just use whatever user chose
                                if (txt.zz_Text.Length == 0) // If there isn't already an address in there, set default (i./e. New Sales Order created)
                                {
                                    if (!Tools.Strings.StrExt(c.GetPrimaryBillingAddressString(RzWin.Context)))
                                        txt.SetValue_String("There is no default billing address assigned to this company, please choose from the list above.  To prevent this in the future, please set a default billing address on the company record -> Addresses tab");
                                    else
                                        txt.SetValue(c.GetPrimaryBillingAddressString(RzWin.Context));
                                }
                                else
                                {
                                    txt.SetValue(a.GetAddressString(RzWin.Context));
                                }

                            }
                            else
                            {
                                ctl_shippingname.SetValue(c.companyname);
                                if (!Tools.Strings.StrExt(c.GetPrimaryShippingAddressString(RzWin.Context)))
                                    txt.SetValue_String("There is no default shipping address assigned to this company, please choose from the list above.  To prevent this in the future, please set a default shipping address on the company record -> Addresses tab");
                                else
                                    txt.SetValue(a.GetAddressString(RzWin.Context));
                                //KT update the primary fax on the order to the company's priamry phone and fax - this supports the ship to field of the printed PO
                                CurrentOrder.primaryphone = c.primaryphone;
                                CurrentOrder.primaryfax = c.primaryfax;
                            }

                        }
                        else
                            RzWin.Context.Leader.Tell("We don't seem to have an address that maps to '" + cbo.GetValue_String() + "'.  Please make sure this address is specified under Company -> Addresses.");
                    }
                    break;
            }
        }
        private void ChangeDate()
        {
            //if (!RzWin.Context.xUser.SuperUser)
            //    return;
            CurrentOrder.DateChange(RzWin.Context);  //this is centralized and maintains the dates on the lines also
                                                     //CompleteLoad_Dates();
            //CompleteSave();
            //CompleteLoad();
        }
        private void LoadAddress(companyaddress a)
        {
            if (a.defaultbilling)
            {
                if (!Tools.Strings.StrExt((String)ctl_billingaddress.GetValue()))
                    ctl_billingaddress.SetValue(a.GetAddressString(RzWin.Context));
            }
            if (a.defaultshipping)
            {
                if (!Tools.Strings.StrExt((String)ctl_shippingaddress.GetValue()))
                    ctl_shippingaddress.SetValue(a.GetAddressString(RzWin.Context));
            }
        }
        private void ShowAttachments()
        {
            picview.DoResize();
            picview.CompleteLoad();
            picview.LoadViewBy(CurrentOrder);
            picview.Caption = "Attachments for " + CurrentOrder.ToString();
        }
        private void PasteBillTo()
        {
            try
            {
                if (!Tools.Strings.StrExt(CurrentOrder.base_company_uid))
                    return;
                companyaddress ca = companyaddress.New(RzWin.Context);
                ca.defaultbilling = true;
                ca.base_company_uid = CurrentOrder.base_company_uid;
                ca.Insert(RzWin.Context);
                Rz5.view_companyaddress cadd = new Rz5.view_companyaddress();
                cadd.SetCurrentObject(ca);
                cadd.CompleteLoad();
                ((LeaderWinUserRz)RzWin.Context.TheLeaderRz).TheRzForm.TabShow(cadd, "New Address");
                cadd.PasteAddress();
            }
            catch { }
        }
        private void BlockAllChanges()
        {
            try
            {
                //gbTop.Enabled = false;
                details.AllowAdd = false;
                foreach (TabPage tp in ts.TabPages)
                {
                    foreach (Control c in tp.Controls)
                    {
                        c.Enabled = false;
                    }
                }
            }
            catch { }
        }
        //Buttons
        private void cmdBillShip_Click(object sender, EventArgs e)
        {
            ctl_shippingaddress.SetValue(ctl_billingaddress.GetValue());
        }
        private void cmdShipBill_Click(object sender, EventArgs e)
        {
            ctl_billingaddress.SetValue(ctl_shippingaddress.GetValue());
        }
        private void cmdUpdateCompanyInfo_Click(object sender, EventArgs e)
        {
            company c = (company)CurrentOrder.CompanyVar.RefGet(RzWin.Context);
            if (c == null)
            {
                RzWin.Context.TheLeader.TellTemp("Please select a company before continuing.");
                return;
            }
            if (Tools.Strings.StrExt(ctl_primaryphone.GetValue_String()))
                c.primaryphone = ctl_primaryphone.GetValue_String();
            if (Tools.Strings.StrExt(ctl_primaryfax.GetValue_String()))
                c.primaryfax = ctl_primaryfax.GetValue_String();
            if (Tools.Strings.StrExt(ctl_primaryemailaddress.GetValue_String()))
                c.primaryemailaddress = ctl_primaryemailaddress.GetValue_String();
            try
            {
                c.Update(RzWin.Context);
            }
            catch { }

            RzWin.Leader.Tell("The company " + c.companyname + " has been updated.\r\nPhone=" + c.primaryphone + "\r\nFax=" + c.primaryfax + "\r\nEmail=" + c.primaryemailaddress);
        }
        private void cmdRefreshCompanyInfo_Click(object sender, EventArgs e)
        {
            company c = (company)CurrentOrder.CompanyVar.RefGet(RzWin.Context);
            if (c == null)
            {
                RzWin.Context.TheLeader.TellTemp("Please select a company before continuing.");
                return;
            }
            CompleteSave();
            CurrentOrder.AbsorbCompany(RzWin.Context, c);
            CurrentOrder.Update(RzWin.Context);
            //KT 8-27-2015 - Is this completeload redundant, especially since another completeload() happens in the following method
            //CompleteLoad();
            //KT 8-27-2015 - Is this completeload redundant, especially since another completeloadCompany() happens in the above method
            CompleteLoad_Company(c);
        }
        private void cmdSwitchAddress_Click(object sender, EventArgs e)
        {
            String s = (String)ctl_billingaddress.GetValue();
            ctl_billingaddress.SetValue(ctl_shippingaddress.GetValue());
            ctl_shippingaddress.SetValue(s);
        }
        private void cmdPasteBill_Click(object sender, EventArgs e)
        {
            PasteBillTo();
        }
        private void cmdAction1_Click(object sender, EventArgs e)
        {
            if (bg.IsBusy)
                return;

            cmdAction1.Enabled = false;

            CompleteSave();
            IsLoading = true;
            throb1.ShowThrobber();
            action_index = 1;
            bg.RunWorkerAsync();
        }
        private void cmdAction2_Click(object sender, EventArgs e)
        {
            if (bg.IsBusy)
                return;

            cmdAction2.Enabled = false;

            CompleteSave();
            IsLoading = true;
            throb2.ShowThrobber();
            action_index = 2;
            bg.RunWorkerAsync();
        }
        private void cmdSetShipVia_Click(object sender, EventArgs e)
        {
            SetShipVia();
        }
        private void cmdSetShipAccounts_Click(object sender, EventArgs e)
        {
            SetShipAccounts();
        }
        //Control Events
        protected virtual void ChangeCompany(GenericEvent e)
        {
            e.Handled = true;
            String strID = "";
            String strName = "";
            Rz5.frmChooseCompany_Big.ChooseCompanyID(ref strID, ref strName, Enums.CompanySelectionType.Both, "Company");
            company c = company.GetById(RzWin.Context, strID);
            if (CurrentOrder.OrderType == Enums.OrderType.Purchase || CurrentOrder.OrderType == Enums.OrderType.Service)
            {
                //Confirm it's an approved Vendor
                List<string> approvedMessages = new List<string>();
                if (!RzWin.Context.TheSysRz.TheOrderLogic.CheckVendorApprovalStatus(RzWin.Context, CurrentOrder, approvedMessages, c, false))
                {
                    string strMessages = string.Join(Environment.NewLine, approvedMessages);
                    RzWin.Leader.Error("Sorry, " + c.companyname + " is not approved for purchase for the following reasons: " + Environment.NewLine + Environment.NewLine + strMessages);
                    cStub.Clear();
                    return;
                }
            }

            if (strID != CurrentOrder.base_company_uid)
            {
                ctl_primaryphone.SetValue("");
                ctl_primaryfax.SetValue("");
                ctl_primaryemailaddress.SetValue("");
                CurrentOrder.contactname = "";

                if (c == null)
                    return;
                if (!CurrentOrder.CanAssignCompany(RzWin.Context, c))
                    return;
                CompleteSave();
                CurrentOrder.AbsorbCompany(RzWin.Context, c);
                CurrentOrder.Update(RzWin.Context);
                //KT 8-27-15 is this completeload necessary, since it got fired in the COmpleteSave() above?
                //CompleteLoad();
                //Is this CompleteLoadCompany reduntant since it happens int he above CompleteLoad() method as well?
                //CompleteLoad_Company(c);
                if (CurrentOrder.OrderType == Enums.OrderType.Purchase)
                {
                    //Confirm it's an approved Vendor
                    List<string> approvedMessages = new List<string>();
                    if (!RzWin.Context.TheSysRz.TheOrderLogic.CheckVendorApprovalStatus(RzWin.Context, CurrentOrder, approvedMessages, c, false))
                    {
                        string strMessages = string.Join(Environment.NewLine, approvedMessages);
                        RzWin.Leader.Error("Sorry, " + c.companyname + " is not approved for purchase for the following reasons: " + Environment.NewLine + Environment.NewLine + strMessages);
                        return;
                    }


                    ArrayList xs = c.VendorContactsGet(RzWin.Context);
                    if (xs.Count == 1)
                    {
                        companycontact cc = (companycontact)xs[0];
                        cStub.SetCompany(c.companyname, c.unique_id, cc.contactname, cc.unique_id);
                        cStub.ContactDisable();
                        CurrentOrder.AbsorbContact(RzWin.Context, cc);
                        //KT Is this completeload necessary?  Might be if it refreshes the contacts, will test
                        CompleteLoad();
                        LoadAddressLists(c);
                    }
                    else
                        cStub.ContactEnable();
                }
            }
        }


        protected virtual void ChangeContact(GenericEvent e)
        {
            e.Handled = true;
            if (!Tools.Strings.StrExt(CurrentOrder.base_company_uid))
                return;
            ArrayList xs = null;
            companycontact c = null;
            if (CurrentOrder.OrderType == Enums.OrderType.Purchase)
            {
                company comp = (company)CurrentOrder.CompanyVar.RefGet(RzWin.Context);
                if (comp != null)
                    xs = comp.VendorContactsGet(RzWin.Context);
            }
            String strID = "";
            String strName = "";
            bool choose = false;
            if (xs == null)
                choose = true;
            else
            {
                if (xs.Count == 0)
                    choose = true;
            }
            if (choose)
            {
                Rz5.frmChooseContact_Big.ChooseContactID(ref strID, ref strName, CurrentOrder.base_company_uid, "Contact", this.ParentForm);
                if (Tools.Strings.StrExt(strID))
                    c = companycontact.GetById(RzWin.Context, strID);
            }
            else
            {
                companycontact xc = Rz5.frmChooseContact_Big.Choose(xs, "Choose A Vendor Contact");
                if (xc == null)
                    return;
                c = xc;
            }
            if (c == null)
                return;
            //check everything
            if (!CurrentOrder.CanAssignContact(RzWin.Context, c))
            {
                RzWin.Leader.Tell(c.ToString() + " cannot be assigned to this " + Rz5.RzLogic.GetFriendlyOrderType(CurrentOrder.OrderType));
                return;
            }
            CompleteSave();
            cStub.SetCompany(CurrentOrder.companyname, CurrentOrder.base_company_uid, c.contactname, c.unique_id);
            CurrentOrder.AbsorbContact(RzWin.Context, c);
            //KT might be unneccessary, however, leaving is since it's base CompleteLoad, and thus not loading totals, etc.
            //CompleteLoad();
            LoadAddressLists(c);
        }

        //KT
        private void SetLinesAgents(NewMethod.n_user CompanyAgent)
        {
            //KT Set Seller_name to match agent name on Sales Order
            string currentAgentID = CompanyAgent.unique_id;
            string currentAgentName = CompanyAgent.name;
            //ContextRz context = RzWin.Context;  

            switch (CurrentOrder.OrderType)
            {
                case Enums.OrderType.Service://Certain orer types, like service orders may be in a shipping agen't name, don't want to update the line with that.
                    return;
                case Enums.OrderType.Quote:
                    SetLInesAgentOrddet_quote(currentAgentID, currentAgentName);
                    break;
                default:
                    SetLinesAgentOrddet_line(currentAgentID, currentAgentName);
                    break;
            }

            //RzWin.Context.TheSysRz.TheLineLogic.SetLinesAgents(RzWin.Context, CurrentOrder.DetailsList(RzWin.Context), CurrentOrder);
            //CurrentOrder.Update(RzWin.Context);
            if (CurrentOrder.OrderType == Enums.OrderType.Purchase)
            {
                ordhed_purchase po = (ordhed_purchase)CurrentOrder;
                if (!po.is_consign)//These can have MANY lines, don't need to check line agent, like the other more mutable orddet_lines
                    RzWin.Context.TheSysRz.TheLineLogic.SetLinesAgents(RzWin.Context, CurrentOrder.DetailsList(RzWin.Context), CurrentOrder);
                //test
            }



        }

        private void SetLinesAgentOrddet_line(string currentAgentID, string currentAgentName)
        {
            foreach (orddet_line l in CurrentOrder.DetailsList(RzWin.Context))
            {
                if (l.seller_name != currentAgentName || l.seller_uid != currentAgentID)
                {
                    l.seller_name = currentAgentName;
                    l.seller_uid = currentAgentID;
                    l.Update(RzWin.Context);
                }
            }
        }

        private void SetLInesAgentOrddet_quote(string currentAgentID, string currentAgentName)
        {
            foreach (orddet_quote q in CurrentOrder.DetailsList(RzWin.Context))
            {
                if (q.agentname != currentAgentName || q.base_mc_user_uid != currentAgentID)
                {
                    q.agentname = currentAgentName;
                    q.base_mc_user_uid = currentAgentID;
                    q.Update(RzWin.Context);
                }
            }
        }



        private void cStub_ChangeCompany(GenericEvent e)
        {
            ChangeCompany(e);
        }
        private void cStub_ChangeContact(GenericEvent e)
        {
            ChangeContact(e);
        }
        private void details_AboutToAdd(object sender, AddArgs args)
        {
            //If User doesn't have add lines permission, leader.tell "Please User Order Batch"                   
            if (CurrentOrder.OrderType == Enums.OrderType.Sales)
            {
                if (RzWin.Leader.AskYesNo("Are you adding a GCAT line to this order?"))
                {
                    args.Handled = true;
                    RzWin.Context.Error("Please right-click the line item you wish to send for GCAT testing.");
                    return;
                    //AddGCATSalesLine();
                }
                else if (!RzWin.Context.CheckPermit(Permissions.ThePermits.AddManualSalesLines))
                {
                    RzWin.Context.Leader.Tell("It is not possible to add lines directly to the sales order, please use the order batch feature 'Add to FQ/SO' instead");
                    args.Handled = true;
                    return;
                }
                else
                {
                    DetailAdd();
                    args.Handled = true;
                    return;
                }
            }
            else if (!RzWin.Context.CheckPermit("permit_AddManualSalesLines"))
            {
                RzWin.Context.Leader.Tell("It is not possible to add lines directly to the sales order, please use the order batch feature 'Add to FQ/SO' instead");
                args.Handled = true;
                return;
            }
            else
            {
                DetailAdd();
                args.Handled = true;
                return;
            }
            //else if (RzWin.Context.CheckPermit("AddManualSalesLines"))
            //{
            //    DetailAdd();
            //    args.Handled = true;
            //}          
            //DetailAdd();
            //args.Handled = true;





        }

        //private void AddGCATSalesLine()
        //{
        //    ordhed_sales sale = (ordhed_sales)CurrentOrder;

        //    orddet_line lineBeingTested = (orddet_line)RzWin.Context.TheSysRz.TheLineLogic.GetGCATSalesLineToBeTested(RzWin.Context, sale);
        //    if (lineBeingTested == null)
        //    {
        //        RzWin.Leader.Error("You must select a line on this order for GCAT service.");
        //        return;
        //    }

        //    orddet_line gcatLine = (orddet_line)RzWin.Context.TheSysRz.TheLineLogic.CreateGCATLine(RzWin.Context, lineBeingTested);
        //    return;
        //}

        protected virtual void DetailAdd()
        {
            //CompleteSave();
            CurrentOrder.DetailAddWithChecks(RzWin.Context);
            details.RefreshFromCollection();
            CurrentOrder.Update(RzWin.Context);
            CompleteLoad_Status();
        }
        private void cboBillingAddress_SelectionChanged(GenericEvent e)
        {
            SetAddress(cboBillingAddress, ctl_billingaddress, "qb_billing");
        }
        private void cboShippingAddress_SelectionChanged(GenericEvent e)
        {
            SetAddress(cboShippingAddress, ctl_shippingaddress, "qb_shiping");
        }
        private void lblAddNewBilling_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddAddress("Billing", true, false);
        }
        private void lblAddNewShiping_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddAddress("Shipping", false, true);
        }
        private void lblChangeDate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangeDate();
        }
        private void lblSaveThisOrder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!RzWin.Leader.AreYouSure("permanently save this line order"))
                return;
            ArrayList ids = details.GetAllIDs();
            int i = 1;
            foreach (String id in ids)
            {
                try
                {
                    orddet_line d = (orddet_line)CurrentOrder.Details.ByIdGet(RzWin.Context, id);
                    if (d != null)
                    {
                        d.LineCodeSet(CurrentOrder.OrderType, i);
                        d.Update(RzWin.Context);
                    }
                }
                catch { }
                i++;
            }
            RzWin.Leader.Tell("Done.");
        }
        private void ctl_terms_Load(object sender, EventArgs e)
        {
        }
        private void ctl_packinginfo_Load(object sender, EventArgs e)
        {
        }
        private void ts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //2011_06_01  had to take this out; it makes the screen flicker noticeably
            //this needs to just do the resize logic on whatever needs to be resized, rather than the whole screen
            //DoResize();
        }
        private void tsDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tsDetails.SelectedTab == tabAttachments)
                ShowAttachments();
        }
        private void PartPictureViewer_PictureAdded()
        {

            CompleteLoadAttachments();
        }
        private void PartPictureViewer_PictureRemoved()
        {
            CompleteLoadAttachments();
        }
        //Background Workers
        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            switch (action_index)
            {
                case 1:
                    Action1();
                    break;
                case 2:
                    Action2();
                    break;
            }
        }
        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IsLoading = false;
            CompleteLoad();

            switch (action_index)
            {
                case 1:
                    Action1Complete();
                    break;
                case 2:
                    Action2Complete();
                    break;
            }

        }
        protected void HeaderSet(String name)
        {
            System.Reflection.Assembly thisExe;
            thisExe = System.Reflection.Assembly.GetExecutingAssembly();
            System.IO.Stream file =
                thisExe.GetManifestResourceStream("Rz4." + name);
            picHeader.Image = Image.FromStream(file);
        }
        private void details_FinishedFill(object sender)
        {
            if (IsLoading)
                return;
            //KT 8-27-2015 - Experimenting with not doing this to improve load times
            CompleteLoad_Totals();
            CompleteLoad_Status();
            CompleteLoad_Shipping();
        }
        private void picHeader_DoubleClick(object sender, EventArgs e)
        {
            CompleteSave();
            CurrentOrder.NumberChange(RzWin.Context);
            RenderHeaderBar();
        }
        private void details_AboutToThrow(Context x, ShowArgs args)
        {

            string test = "";
            //KT 8-27-2015 -Not sure why opening any line should run the completeSave routine. 
            //CompleteSave();
        }

        private void details_FinishedAction(object sender, ActArgs args)
        {
            //Refresh the line section, if any new lines added.
            //CurrentOrder.Update(RzWin.Context);

            string actionVariable = args.ActionName;
            if (actionVariable.ToLower().Contains("switchto"))
                actionVariable = "statusswitch";

            nList List = (nList)sender;
            ArrayList lines = List.GetSelectedObjects();

            switch (actionVariable.ToLower())
            {
                case "scrap/quarantine":
                    UpdateOrderStatus(lines);
                    //CurrentOrder.Update(RzWin.Context);
                    break;
                case "statusswitch":
                    //CurrentOrder.Update(RzWin.Context);
                    UpdateOrderStatus(lines);
                    break;

            }

        }

        private void UpdateOrderStatus(ArrayList LineIDs)
        {
            Context x = RzWin.Context;
            ShowArgs t = null;
            // This has been very tricky to cross-update RMA and corresponding VENDRMA
            // For now the only solution that works is to close this and related RMA order,  Update Current Order, Get related rma or vrma, update that, Then SHOW both tabs.  Only when I show the
            // tabs do we get the update in the UI.
            // Note that if you immediately close the UI (see commented out code below) the UI will have the wrong value again when you access it in the system.
            CurrentOrder.Update(x);
            //x.Leader.ViewsClose(CurrentOrder);
            foreach (orddet_line l in LineIDs)
            {
                switch (CurrentOrder.OrderType.ToString().ToLower())
                {
                    case "vendrma":
                        {
                            //ordhed_rma rma = ordhed_rma.GetById(x, l.orderid_rma);
                            ordhed_rma rma = (ordhed_rma)l.RMAVar.RefGet(x);
                            if (rma != null)
                            {
                                //x.Leader.ViewsClose(CurrentOrder);
                                // x.Leader.ViewsClose(rma);//close the view, so when I reopen it it gets loaded again.
                                if (!rma.DetailsVar.Initialized)
                                    rma.DetailsVar.Init(x);
                                rma.Update(x);

                                //t = new ShowArgs(NMWin.ContextDefault, rma);
                                // if (!t.Handled)                              
                                // NMWin.ContextDefault.Show(t);
                                //x.Leader.ViewsClose(rma);

                            }
                            break;
                        }
                    case "rma":
                        {
                            //ordhed_vendrma vrma = ordhed_vendrma.GetById(x, l.orderid_vendrma);
                            ordhed_vendrma vrma = (ordhed_vendrma)l.VendRMAVar.RefGet(x);
                            if (vrma != null)
                            {
                                // x.Leader.ViewsClose(CurrentOrder);
                                // x.Leader.ViewsClose(vrma);
                                if (!vrma.DetailsVar.Initialized)
                                    vrma.DetailsVar.Init(x);
                                vrma.Update(x);

                                // t = new ShowArgs(NMWin.ContextDefault, vrma);
                                //if (!t.Handled)
                                //    NMWin.ContextDefault.Show(t);
                                //x.Leader.ViewsClose(vrma);

                            }
                            break;

                        }
                }
            }
            NMWin.ContextDefault.Show(new ShowArgs(NMWin.ContextDefault, CurrentOrder));
        }

        private void details_AboutToAction(object sender, ActArgs args)
        {
            string test = "";
            //KT 10-1-2015 - this is just to catch the cancellation process to see what happens to deductions.
            //RzWin.Leader.Tell("Debug Cancellation and effect on orddet_line.");            
        }


        private void LoadCompanyCredits()
        {
            switch (CurrentOrder.OrderType)
            {
                case Enums.OrderType.Purchase:
                case Enums.OrderType.Service:
                case Enums.OrderType.RMA:
                case Enums.OrderType.Invoice:
                    {
                        btnAddCredit.Visible = true;
                        break;
                    }
                default:
                    btnAddCredit.Visible = false;
                    break;
            }

            CheckForCompanyCredits();
            //SUMCompanyCreditsTab();
            ListArgs args = new ListArgs(RzWin.Context);
            args.TheClass = "companycredit";
            args.TheLimit = 200;
            args.AddCaption = "Add New Vendor Credit";
            args.TheOrder = "date_created desc";
            args.TheTable = "companycredit";
            args.TheTemplate = "companycredit";
            //args.TheWhere = "base_company_uid = '" +CurrentOrder.base_company_uid+ "' AND (is_applied = '' || base_company_uid = '" + CurrentOrder.base_company_uid + "')";
            if (cbxShowUsedCredits.Checked)
            {
                args.TheWhere = "base_company_uid = '" + CurrentOrder.base_company_uid + "'";
            }
            else
            {
                args.TheWhere = "base_company_uid = '" + CurrentOrder.base_company_uid + "' AND (is_applied = '' OR applied_to_order_uid = '" + CurrentOrder.unique_id + "' )";
            }

            //if (!RzWin.Context.Sys.ThePermitLogic.CheckPermit(RzWin.Context, NewMethod.Permissions.ThePermits.AddOtherChargeCredit, RzWin.Context.xUser))
            args.AddAllow = false;
            nListCompanyCredits.ShowData(args);


        }

        private void lvCompanyCredits_AboutToAdd(object sender, Core.AddArgs args)
        {
            if (!RzWin.Leader.AskYesNo("Are you Adding a new Company Credit?  (Click NO if you are applying credit to the order)"))
            {
                RzWin.Context.TheLeaderRz.ChooseCompanyCredit(RzWin.Context, CurrentCompany, CurrentOrder);
                //CompleteLoad_Totals();
            }
            else
            {
                args.Handled = true;
                AddCompanyCredits();
                CurrentOrder.CompanyCreditVar.UpdateAll(RzWin.Context);
            }

        }

        private void lvCompanyCredits_AboutToThrow(Core.Context x, Core.ShowArgs args)
        {

        }


        private void AddCompanyCredits()
        {
            if (CurrentCompany != null)
            {
                try
                {
                    companycredit c = CurrentOrder.CompanyCreditVar.RefAddNew(Rz5.RzWin.Context);
                    c.base_company_uid = CurrentOrder.base_company_uid;
                    c.ordernumber = CurrentOrder.ordernumber;
                    c.companyname = CurrentOrder.companyname;
                    c.Update(RzWin.Context);
                    frmCompanyCredit f = new frmCompanyCredit();
                    f.CompleteLoad(RzWin.Context, c, CurrentOrder);
                    f.ShowDialog();

                    // CurrentOrder.CompanyCreditVar.UpdateAll(RzWin.Context);
                }
                catch (Exception ex)
                {
                    RzWin.Leader.Error(ex);
                }
            }
            else
                RzWin.Context.Leader.Tell("There is no company assigned to this order.  Cannot create a company credit.");
        }


        private void EditCompanyCredits()
        {
            try
            {
                if (nListCompanyCredits.GetSelectedObjects().Count == 0)
                {
                    RzWin.Context.Leader.Error("Please Choose a CompanyCredit to Edit");
                    return;
                }
                foreach (companycredit c in nListCompanyCredits.GetSelectedObjects())
                {
                    Rz5.companycredit credit = Rz5.companycredit.GetById(RzWin.Context, c.unique_id);
                    frmCompanyCredit f = new frmCompanyCredit();
                    f.CompleteLoad(RzWin.Context, credit, CurrentOrder);
                    f.ShowDialog();
                }

            }
            catch (Exception ex)
            {

                RzWin.Leader.Error(ex);

            }
            CompleteLoad();
        }



        private void SUMCompanyCreditsTab()
        {
            try
            {
                double i = RzWin.Context.SelectScalarDouble("select SUM(creditamount) from companycredit where is_applied = '' AND base_company_uid ='" + CurrentOrder.base_company_uid + "'");
                tabCompanyCredits.Text = "Unused Credits(" + RzWin.Context.Sys.CurrencySymbol + Tools.Number.MoneyFormat(i) + ")"; //get a SUM of vendor Credits

            }
            catch
            {

            }
        }


        private void CheckForCompanyCredits()
        {
            //KT - Does this vendor have any outstanding credit?   
            if (CurrentCompany != null)
            {
                double i = RzWin.Context.SelectScalarDouble("select SUM(creditamount) from companycredit where is_applied = '' AND base_company_uid ='" + CurrentCompany.unique_id + "'");
                if (i != 0)
                {
                    lblCompanyCreditAlert.Visible = true;
                    lblCompanyCreditAlert.Text = "Available Credit: " + RzWin.Context.Sys.CurrencySymbol + Tools.Number.MoneyFormat(i);
                    lblCompanyCreditAlert.BringToFront();
                    lblCompanyCreditAlert.ForeColor = Color.Red;

                }
                else
                {
                    lblCompanyCreditAmount.Visible = false;
                    lblCompanyCreditAlert.Visible = false;
                }
            }
            SUMCompanyCreditsTab();

        }

        protected void CompleteLoadProblemCompanyAlert()
        {
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Enabled = false;
            timer.Start();
            if (CurrentCompany != null)
            {
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
        }
        protected void timer_Tick(object sender, EventArgs e)
        {
            if (lblProblemCustomer.ForeColor == Color.Black)
                lblProblemCustomer.ForeColor = Color.Red;
            else
                lblProblemCustomer.ForeColor = Color.Black;
        }




        //KT Company Credits
        private void CompleteLoad_Credits()
        {
            LoadCompanyCreditsLabel();
        }

        private void LoadCompanyCreditsLabel()
        {
            lblCompanyCreditAlert.Text = RzWin.Context.TheSys.CurrencySymbol + " 0.00";
            lblCompanyCreditAmount.Text = RzWin.Context.TheSys.CurrencySymbol + " 0.00";
            if (CurrentOrder == null)
                return;
            double credit = 0;
            foreach (companycredit c in CurrentOrder.CompanyCreditVar.RefsList(RzWin.Context))
            {
                if (c.is_applied != "1")
                    credit += c.creditamount;
            }
            if (credit != 0)
            {
                lblCompanyCreditAmount.Text = RzWin.Context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(credit);
            }
            else
            {
                lblCompanyCreditAmount.Visible = false;
                lblCompanyCreditAlert.Visible = false;
            }

        }

        private void ShowCredit(companycredit c)
        {
            try
            {
                frmCompanyCredit cf = new frmCompanyCredit();
                cf.ShowDialog();
            }
            catch { }
        }



        private void btnAddCredit_Click(object sender, EventArgs e)
        {
            AddCompanyCredits();
            CheckForCompanyCredits();
        }

        private void btnAssignCredit_Click(object sender, EventArgs e)
        {
            if (nListCompanyCredits.GetSelectedCount() > 0)
                assignCredit();
            else
                RzWin.Leader.Tell("Please select one or more credits from the list to assign to this PO.");
        }


        protected void assignCredit()
        {

            ArrayList xList = nListCompanyCredits.GetSelectedObjects();
            foreach (companycredit c in xList)
            {
                if (c.is_applied == "1")
                {
                    if (RzWin.Context.TheLeader.AskYesNo("Are you sure you want to unassign the credit(s) from " + CurrentOrder.OrderType + " order: " + c.applied_to_order + " ?"))
                    {
                        c.applied_to_order = "";
                        c.applied_to_order_uid = "";
                        c.is_applied = "";
                        c.Update(RzWin.Context);
                        CurrentOrder.CompanyCreditVar.RefsRemove(RzWin.Context, c);
                        CurrentOrder.CompanyCreditVar.Changed = true;
                    }
                }
                else
                {
                    if (RzWin.Context.TheLeader.AskYesNo("Are you sure you want assign the credit(s) to " + CurrentOrder.OrderType + " order: " + CurrentOrder.ordernumber + " ?"))
                    {
                        c.applied_to_order = CurrentOrder.ordernumber;
                        c.applied_to_order_uid = CurrentOrder.unique_id;
                        c.is_applied = "1";
                        c.Update(RzWin.Context);
                        CurrentOrder.CompanyCreditVar.RefsAdd(RzWin.Context, c);
                        CurrentOrder.CompanyCreditVar.Changed = true;

                    }
                }
            }
            CurrentOrder.Update(RzWin.Context);
            CompleteLoad_Totals();
            LoadCompanyCredits();
        }



        private void btnEditCredit_Click(object sender, EventArgs e)
        {
            EditCompanyCredits();
            CheckForCompanyCredits();
        }

        private void cbxShowUsedCredits_CheckedChanged(object sender, EventArgs e)
        {

            LoadCompanyCredits();
        }

        private void nListCompanyCredits_FinishedFill(object sender)
        {
            CheckForCompanyCredits();
        }

        private void nListCompanyCredits_AboutToAction(object sender, ActArgs args)
        {
            args.Handled = true;
            if (args.ActionName.ToLower() == "delete")
            {
                if (RzWin.Context.Leader.AskYesNo("Are you sure you want to delete this credit?"))
                {
                    ArrayList SelectedDeductions = nListCompanyCredits.GetSelectedObjects();
                    foreach (companycredit c in nListCompanyCredits.GetSelectedObjects())
                    {
                        //CurrentOrder.CompanyCreditVar.m_TheItems.Remove(RzWin.Context, c);                        
                        c.Delete(RzWin.Context);
                    }
                    CompleteLoad_Totals();
                }

            }
        }

        protected void GetOutstandingARAP()
        {
            double d = 0;
            if (CurrentCompany != null)
            {
                d = RzWin.Context.TheSysRz.TheCompanyLogic.CalculateOutstandingBalance_Company(RzWin.Context, CurrentCompany);
                //d = Math.Round(d, 2); -- the MoneyFormat below will correctly handle the rounding.  This throws it off.
                if (d > 0)
                    lblOutstandingInvoiceAmnt.Text = "Outstanding Invoices: " + Tools.Number.MoneyFormat(d).ToString();
                else
                    lblOutstandingInvoiceAmnt.Visible = false;
            }
        }

        private void LoadCreditCharges()
        {
            ListArgs args = new ListArgs(RzWin.Context);
            args.TheClass = "ordhit";
            args.TheLimit = 200;
            args.AddCaption = "Add Credit/Charge";
            args.TheOrder = "date_created desc";
            args.TheTable = "ordhit";
            args.TheTemplate = "ordhit";
            args.TheWhere = "the_ordhed_uid = '" + CurrentOrder.unique_id + "'";
            if (!RzWin.Context.Sys.ThePermitLogic.CheckPermit(RzWin.Context, NewMethod.Permissions.ThePermits.AddOtherChargeCredit, RzWin.Context.xUser))
                args.AddAllow = false;
            else
                args.AddAllow = true;
            lvCreditCharges.ShowData(args);
        }

        private void AddCreditCharges()
        {
            try
            {
                Rz5.ordhit h = Rz5.ordhit.New(RzWin.Context);
                h.the_ordhed_uid = CurrentOrder.unique_id;
                h.ordhit_order = CurrentOrder.ordernumber;
                //h.deduct_profit = true;
                frmCreditCharge c = new frmCreditCharge();
                c.CompleteLoad(RzWin.Context, h);
                c.ShowDialog();
            }
            catch { }
        }


        private void ShowCreditCharges()
        {
            try
            {
                Rz5.ordhit h = (Rz5.ordhit)lvCreditCharges.GetSelectedObject();
                frmCreditCharge c = new frmCreditCharge();
                c.CompleteLoad(RzWin.Context, h);
                c.ShowDialog();
            }
            catch { }
        }

        private void lvCreditCharges_AboutToAdd(object sender, Core.AddArgs args)
        {
            args.Handled = true;
            AddCreditCharges();
            CompleteLoad_Totals();
        }

        private void lvCreditCharges_AboutToThrow(Core.Context x, Core.ShowArgs args)
        {
            args.Handled = true;
            ShowCreditCharges();
        }

        private void lvCreditCharges_FinishedAction(object sender, ActArgs args)
        {
            CompleteLoad_Totals();
        }

        private void btnFixComplete_Click(object sender, EventArgs e)
        {
            CurrentOrder.LoadMissingProperties(RzWin.Context, true);
            LoadCompletionReport();
            CompleteLoad_Status();//Handle Group Box Visibility, etc.
            CompleteLoadOrderButtons();

        }



        private void btnHubspot_Click(object sender, EventArgs e)
        {
            RzWin.Leader.ManageHubspot(RzWin.Context, CurrentOrder);
        }

        private void llblDealLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenHubspotDealLink();
        }

        private void OpenHubspotDealLink()
        {
            if (TheHubspotDeal == null)
                return;
            if (TheHubspotDeal.dealId <= 0)
                return;
            string hsDealURL = @"https://app.hubspot.com/sales/1878634/deal/" + TheHubspotDeal.dealId;
            Process.Start(hsDealURL);
        }

        private void ctl_donotemail_CheckChanged(object sender)
        {

        }

        private void cmdChangeCompany_Click_2(object sender, EventArgs e)
        {

        }

        private void btnCheckCreditLimit_Click(object sender, EventArgs e)
        {

        }

        private void ctl_testing_restriction_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ctl_packaging_requirements_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ctl_date_code_restriction_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ctl_delete_archives_CheckChanged(object sender)
        {

        }

        private void optArchive_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void optNoArchive_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void optToDelete_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void optToArchive_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lblClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void lblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void lblNotifyAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void llEditHubspotDeal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RzWin.Leader.ManageHubspot(RzWin.Context, CurrentOrder);
        }


        //private bool CreateHubspotDeal()
        //{
        //    bool ret = false;
        //    if (CurrentOrder.hubspot_deal_id == 0) // No Deal Exists
        //    { }

        //    //Check if active Contact
        //    companycontact c = companycontact.GetById(RzWin.Context, CurrentOrder.base_mc_user_uid);
        //    if (c == null)
        //        return false;
        //    string contactEmail = c.primaryemailaddress.ToLower().Trim();
        //    //Check contact email
        //    if (string.IsNullOrEmpty(contactEmail))
        //        return false;
        //    //Check valid Contact email format
        //    if (!Tools.Email.IsEmailAddress(contactEmail))
        //        return false;
        //    bool existsInHs = CurrentOrder.hubspot_deal_id > 0;

        //    //Get the contact from Hubspot
        //    HubspotApi.Contact hsContact = HubspotApi.GetContactByEmail(contactEmail);
        //    //Check for null contact
        //    if (hsContact == null)
        //    {
        //        RzWin.Context.Error("Contact not found in Hubspot. (" + contactEmail + ")");
        //        return false;
        //    }

        //    //Create the deal passing in the order object, from that we'll get the companycontact object, which we can use the email to get the hubspot contact, which will also have company association data
        //    HubspotLogic.CreateDealFromRzOrder(CurrentOrder.unique_id);



        //    return ret;
        //}
    }


}