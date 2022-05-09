using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NewMethod;
using Tools;
using CoreWin;
using System.Linq;
using SensibleDAL;
using System.Threading.Tasks;

namespace Rz5
{
    public partial class ReqLine : RzLine, IReqLine
    {
        //Public Variables
        public orddet_quote CurrentReq;

        public int ExpandedHeight = 311;
        //Public Events
        public event ReqLineEventHandler ReceiveBid;
        public bool CommandsVisible
        {
            get
            {
                return pCommands.Visible;
            }
            set
            {
                pCommands.Visible = value;
            }
        }
        //public bool Enabled
        //{
        //    get 
        //    { 
        //        return this.Enabled; 
        //    }
        //    set 
        //    {
        //        this.Enabled = value;
        //    }
        //}
        //Constructors
        public ReqLine()
        {
            InitializeComponent();
            try
            {
                OriginalHeight = ctl_alternatepart.Bottom + 6;
            }
            catch
            {
            }
        }
        //Public Virtual Functions
        public virtual void CompleteLoad(orddet_quote r, Image i, bool IsInBatchScreen)
        {
            //KT Refactored from RzSenible
            ctl_rohs_info.SimpleList = "";
            ctl_rohs_info.ListName = "rohs_info";
            ctl_rohs_info.LoadList(true);
            //KT End Refactor


            //lblChangeAgent.Visible = !IsInBatchScreen;
            //lblChangeCustomer.Visible = !IsInBatchScreen;
            CurrentReq = r;
            //if (Rz3App.xLogic.IsPhoenix)  //Phoenix version handles this already
            //{
            //    ctl_warranty_period.Visible = true;
            //    ctl_description.Width = ctl_target_manufacturer.Width;
            //    ctl_warranty_period.LoadList(true);
            //}
            //else
            //{
            //ctl_warranty_period.Visible = false;
            //ctl_description.Width = ctl_manufacturer.Right - ctl_description.Left;
            //}
            ctl_source.LoadList(true);
            CurrentObject = CurrentReq;
            NMWin.LoadFormValues(this, CurrentReq);

            //<reorg>
            //lstOptions.CustomMenuOptions = new ArrayList();
            //lstOptions.CustomMenuOptions.Add("Delete");

            ShowProfit();
            ShowAgent();
            //lblPurchasing.Text = CurrentReq.vendorname;
            //if (Tools.Strings.StrExt(CurrentReq.vendorcontactname))
            //{
            //    if (Tools.Strings.StrExt(lblPurchasing.Text))
            //        lblPurchasing.Text += "\r\n";
            //    lblPurchasing.Text += CurrentReq.vendorcontactname;
            //}
            SetImage(i);
            SetColor(orddet_quote.QuoteColor);
            ShowExpanded();
            ShowHeaderInfo();
            //if (Rz3App.xLogic.IsPhoenix)   //Phoenix version handles this already
            //    ctl_internalpartnumber.Caption = "Customer Part Number";
            ctl_target_delivery.LoadList(true);
            ctl_delivery.LoadList(true);
            ctl_target_quantity.SetValue(CurrentReq.target_quantity);
            LoadCompany();
            ctl_target_price.Caption = RzWin.Logic.TargetPriceCaption;
            IsExpanded = false;
            lblReceiveBid.Visible = (ReceiveBid != null);
            LoadOptions();
            sc1.CompleteLoad(RzWin.Context, CurrentReq);

            RzWin.Sys.ThePartLogic.LoadManufacturerDropDown(RzWin.Context, ctl_target_manufacturer);
            ctl_target_manufacturer.SetValue(CurrentReq.target_manufacturer);
            RzWin.Sys.ThePartLogic.LoadManufacturerDropDown(RzWin.Context, ctl_manufacturer);
            ctl_manufacturer.SetValue(CurrentReq.manufacturer);





            DoExpand();
        }

        public override void InitUn()
        {
            try
            {
                CurrentReq = null;
                //lstOptions.Clear();
                //lstOptions.Dispose();
                //lstOptions = null;
            }
            catch { }

            base.InitUn();
        }


        public override void CompleteSave()
        {
            try
            {

                //KT
                base.CompleteSave();



                //Part Number
                string partNumber = ctl_fullpartnumber.GetValue_String();
                if (string.IsNullOrEmpty(partNumber))
                    throw new Exception("You must enter a part number.");
                CurrentReq.fullpartnumber = partNumber.Replace(" ", "").Trim().ToUpper();

                //Target QTY
                long targetQty = ctl_target_quantity.GetValue_Integer();
                if (targetQty <= 0)
                    throw new Exception("You must enter a target quantity.");
                CurrentReq.target_quantity = ctl_target_quantity.GetValue_Integer();

                //Manufacturer     
                CompleteSaveManufacturer();




                if (!Strings.StrExt(ctl_source.GetValue_String()))
                    ctl_source.SetValue("Not Set");


                CurrentReq.Update(RzWin.Context);


                //Update the Order Batch to trigger hubspot Sync
                if (!string.IsNullOrEmpty(partNumber))
                {
                    if (Parent.Parent is OrderTree)
                    {
                        OrderTree ot = (OrderTree)Parent.Parent;
                        ot.LoadReqQuoteLV();//Update the reqQuote lv to get teh new req in there, then that will trigger deal create, this way it happens when saving req, not just when saving batch.
                        ot.CompleteSave();
                        ot.CompleteLoad();
                    }
                }


                CompleteLoad(CurrentReq, null, true);
            }
            catch (Exception ex)
            {
                RzWin.Leader.Error(ex.Message);
            }
        }

        private void CompleteSaveManufacturer()
        {
            //Save MFG if OTHER, and ask user to confirm if adding to list.
            string lookupMFg = "";
            string selectedTargetMfg = ctl_target_manufacturer.GetValue_String().Trim().ToUpper();
            if (selectedTargetMfg == "OTHER" || string.IsNullOrEmpty(selectedTargetMfg))
            {
                lookupMFg = RzWin.Context.TheSysRz.ThePartLogic.GetManufacturerMatchString(RzWin.Context, CurrentReq.fullpartnumber.Trim().ToUpper());
                if (!string.IsNullOrEmpty(lookupMFg))
                    selectedTargetMfg = lookupMFg;
            }
            CurrentReq.target_manufacturer = selectedTargetMfg;


            //selectedTargetMfg = RzWin.Context.TheSysRz.ThePartLogic.GetManufacturerMatchString(RzWin.Context, CurrentReq.fullpartnumber.Trim().ToUpper());
            //CurrentReq.target_manufacturer = selectedTargetMfg;

            string selectedQuoteMfg = ctl_manufacturer.GetValue_String().Trim().ToUpper();
            if (selectedQuoteMfg == "OTHER")
            {
                lookupMFg = RzWin.Context.TheSysRz.ThePartLogic.GetManufacturerMatchString(RzWin.Context, CurrentReq.fullpartnumber.Trim().ToUpper());
                if (!string.IsNullOrEmpty(lookupMFg))
                    selectedQuoteMfg = lookupMFg;
            }
            CurrentReq.manufacturer = selectedQuoteMfg;




        }


        public override bool HideControlBox
        {
            get
            {
                return base.HideControlBox;
            }
            set
            {
                base.HideControlBox = value;
                lblReceiveBid.Visible = !base.HideControlBox;
            }
        }
        public override void DoResize()
        {
            try
            {
                //CommandLeft = lblFQuote.Right;
                base.DoResize();
            }
            catch { }
        }
        public override void ShowExpanded()
        {
            base.ShowExpanded();
            if (IsExpanded)
                this.Height = ExpandedHeight;
            else
                this.Height = OriginalHeight;
        }
        public override void ReSetFocus()
        {
            if (!Tools.Strings.StrExt(ctl_fullpartnumber.GetValue_String()))
                ctl_fullpartnumber.SetFocusSelectAll();
            else
                ctl_quantityordered.SetFocusSelectAll();
        }
        //Public Functions
        public void ShowHeaderInfo()
        {
            try
            {
                //if (CurrentReq.OrderObject(RzWin.Context) == null)
                //    lblFQuote.Text = nTools.DateFormat(CurrentReq.orderdate) + " - Not Transmitted";
                //else
                //    lblFQuote.Text = "Quote " + CurrentReq.OrderObject(RzWin.Context).ordernumber + " " + nTools.DateFormat(CurrentReq.OrderObject(RzWin.Context).orderdate);
            }
            catch { }
        }
        public void UpdateCostAndProfit()
        {
            if (ctl_unitcost.GetValue_Double() == 0 && CurrentReq.unitcost == 0)
                ctl_unitcost.SetValue(CurrentReq.unitcost);
            ShowProfit();
        }
        public void HideOptions()
        {
            //lstOptions.Visible = false;
            lblAdd.Visible = false;
        }
        //Private Functions
        private void LoadOptions()
        {
            try
            {
                if (CurrentReq == null)
                    return;
                ListArgs args = new ListArgs(RzWin.Context);
                args.AddAllow = false;
                args.TheCaption = "Price / Quantity Options";
                args.TheClass = "orddet_quote";
                args.TheLimit = 200;
                args.TheOrder = "linecode";
                args.TheTable = "orddet_quote";
                args.TheTemplate = "orddet_quote_options";
                args.TheWhere = "option_orddet_quote_uid = '" + CurrentReq.unique_id + "'";
                //lstOptions.ShowData(args);
            }
            catch { }
        }
        private void LoadCompany()
        {
            //lblCustomer.Text = (CurrentReq.companyname + "    " + CurrentReq.contactname).Trim();
        }
        protected void ShowProfit()
        {
            Double d = CurrentReq.lineprofit;
            if (d == 0)
            {
                lblProfit.Text = RzWin.Context.TheSys.CurrencySymbol + "0.00";
                lblProfit.Visible = true;
            }
            else
            {
                lblProfit.Text = RzWin.Context.TheSys.CurrencySymbol + nTools.MoneyFormat(d);
                lblProfit.Visible = true;
            }
        }
        private void ShowAgent()
        {
            //lblAgentName.Text = CurrentReq.agentname;
        }
        //KT Refactored from RzSensible
        private void EnterQty()
        {
            bool cancel = false;
            int q = RzWin.Context.TheLeader.AskForInt32("Please enter the quote quantity below.", ctl_quantityordered.GetValue_Integer(), "Change Qty", ref cancel);
            if (cancel)
                return;
            ctl_quantityordered.SetValue(q);
            CompleteSave();
        }
        private void cmdEnterQty_Click(object sender, EventArgs e)
        {
            EnterQty();
        }


        //Buttons
        private void cmdPartSearch_Click(object sender, EventArgs e)
        {
            String part = ctl_fullpartnumber.GetValue_String();
            if (!Tools.Strings.StrExt(part))
                return;
            RzWin.Context.TheSysRz.ThePartLogic.PartSearchShow(RzWin.Context, new PartSearchShowArgs(part));
            //Rz3App.xMainForm.Focus();
        }
        private void cmdMultiSearch_Click(object sender, EventArgs e)
        {
            String part = ctl_fullpartnumber.GetValue_String();
            if (!Tools.Strings.StrExt(part))
                return;
            RzWin.Form.ShowMultiSearch(part);
            RzWin.Form.Focus();
        }
        //Control Events
        private void lblAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int q = ctl_quantityordered.GetValue_Integer();
            if (q == 0)
            {
                RzWin.Leader.Tell("This requirement has not been quoted yet. Please enter a quote quantity before adding options.");
                return;
            }
            Double p = ctl_unitprice.GetValue_Double();
            if (p == 0)
            {
                RzWin.Leader.Tell("This requirement has not been quoted yet. Please enter a quote price before adding options.");
                return;
            }
            CurrentReq.AddOneOption(RzWin.Context, q, p, ctl_manufacturer.GetValue_String(), ctl_datecode.GetValue_String(), ctl_condition.GetValue_String(), ctl_delivery.GetValue_String());
            LoadOptions();
        }
        private void lblReceiveBid_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CompleteSave();
            if (ReceiveBid != null)
                ReceiveBid(this);
        }
        private void ctl_alternatepart_02_Load(object sender, EventArgs e)
        {
        }
        private void lblViewCompany_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RzWin.Context.Show(CurrentReq.CompanyObjectGet(RzWin.Context));
        }
        private void lblViewContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RzWin.Context.Show(CurrentReq.ContactObjectGet(RzWin.Context));
        }
        private void lblPictures_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        private void lblChangeAgent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CurrentReq.OrderObject(RzWin.Context) != null)
            {
                RzWin.Form.TheContextNM.TheLeader.Tell("This item is already attached to a formal quote.  To change the agent or customer, change the agent or customer on the formal quote");
                return;
            }

            dealheader dh = CurrentReq.GetDealHeader(RzWin.Form.TheContextNM);
            ArrayList reqs = null;
            if (dh != null)
            {
                reqs = dh.ReqsGetAll(RzWin.Context);
                if (reqs.Count > 1)
                {
                    if (!RzWin.Leader.AreYouSure("change the agent on this and the " + Tools.Strings.PluralizePhrase("other requirement", (reqs.Count - 1)) + " in this batch"))
                        return;
                }
            }
            else
            {
                reqs = new ArrayList();
            }

            orddet_quote remove = null;
            foreach (orddet_quote q in reqs)
            {
                if (q.unique_id == CurrentReq.unique_id)
                    remove = q;
            }

            if (remove != null)
                reqs.Remove(remove);

            reqs.Add(CurrentReq);

            n_user u = (n_user)NewMethod.n_user.Choose(RzWin.Context, RzWin.Logic.SalesPeople, false);
            if (u == null)
                return;

            foreach (orddet_quote r in reqs)
            {
                r.UserObjectSet(u);
                //r.base_mc_user_uid = u.unique_id;
                //r.agentname = u.name;
                r.Update(RzWin.Context);
            }
            ShowAgent();

            if (dh != null)
            {
                dh.base_mc_user_uid = u.unique_id;
                dh.agentname = u.name;
                dh.Update(RzWin.Context);
            }
        }
        private void lblChangeCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CurrentReq.OrderObject(RzWin.Context) != null)
            {
                RzWin.Form.TheContextNM.TheLeader.Tell("This item is already attached to a formal quote.  To change the agent or customer, change the agent or customer on the formal quote");
                return;
            }

            dealheader dh = CurrentReq.GetDealHeader(RzWin.Form.TheContextNM);
            ArrayList reqs = null;
            if (dh != null)
            {
                reqs = dh.ReqsGetAll(RzWin.Context);
                if (reqs.Count > 1)
                {
                    if (!RzWin.Leader.AreYouSure("change the agent on this and the " + Tools.Strings.PluralizePhrase("other requirement", (reqs.Count - 1)) + " in this batch"))
                        return;
                }
            }
            else
            {
                reqs = new ArrayList();
            }

            orddet_quote remove = null;
            foreach (orddet_quote q in reqs)
            {
                if (q.unique_id == CurrentReq.unique_id)
                    remove = q;
            }

            if (remove != null)
                reqs.Remove(remove);

            reqs.Add(CurrentReq);

            if (CurrentReq.SwitchCompany(RzWin.Context, this.ParentForm))
            {
                //ShowContact();
                foreach (orddet_quote q in reqs)
                {
                    if (!Tools.Strings.StrCmp(q.unique_id, CurrentReq.unique_id))
                    {
                        q.base_company_uid = CurrentReq.base_company_uid;
                        q.companyname = CurrentReq.companyname;
                        q.base_companycontact_uid = CurrentReq.base_companycontact_uid;
                        q.contactname = CurrentReq.contactname;
                        q.abs_type = CurrentReq.abs_type;
                        q.Update(RzWin.Context);
                    }
                }

                if (dh != null)
                {
                    dh.customer_uid = CurrentReq.base_company_uid;
                    dh.customer_name = CurrentReq.companyname;
                    dh.contact_uid = CurrentReq.base_companycontact_uid;
                    dh.contact_name = CurrentReq.contactname;
                    dh.Update(RzWin.Context);
                }

                CurrentReq.Update(RzWin.Context);

                LoadCompany();
                FireReloadRequest();
            }
        }

        private void btnReqWizard_Click(object sender, EventArgs e)
        {
            //Run the ReqWizard.
            //Gather Pertinent Details via popups if missing.
            //List<orddet> reqList = new List<orddet>();
            //reqList.Add(CurrentReq);

            //if (RzWin.Context.TheSysRz.TheReqLogic.CheckReqData(RzWin.Context, reqList).Count > 0)
            //{

            if (RzWin.Context.TheSysRz.TheOrderLogic.GetMissingPropertiesForObject(RzWin.Context, CurrentReq, true).Count == 0)
            {

                RzWin.Context.Leader.Tell("Lookin Good!  All information for your Req seems to be present!");

            }
            this.CompleteLoad(CurrentReq, null, true);




        }
    }
    public interface IReqLine : InLine
    {
        bool CommandsVisible { get; set; }
        void CompleteLoad(orddet_quote r, Image i, bool IsInBatchScreen);
        event ReqLineEventHandler ReceiveBid;
        void UpdateCostAndProfit();
        void ShowHeaderInfo();
        bool Enabled { get; set; }
    }
    public delegate void ReqLineEventHandler(IReqLine l);
}