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

namespace Rz5
{
    public partial class view_ordhed_rfq : ViewPlusMenu  //, IChangeSubscriber
    {
        public ordhed CurrentOrder
        {
            get
            {
                return (ordhed)TheItem;
            }
        }
        private companyaddress AddressToWatch;
        private bool IsLoading = false;

        public view_ordhed_rfq()
        {
            InitializeComponent();
        }

        public override void Init(Item item)
        {
            base.Init(item);
            //CurrentOrder.xSys.RegisterNotifyClass(this, "orddet");
            //CurrentOrder.xSys.RegisterNotifyClass(this, "orddet_rfq");
        }

        public override void CompleteLoad()
        {
            IsLoading = true;
            lblOrderNumber.Text = CurrentOrder.ordernumber;
            lblOrderType.Text = CurrentOrder.FriendlyOrderType;

            if (CurrentOrder.OrderType == Enums.OrderType.RFQ)
                ctl_is_government.Caption = "Have PO";
            else
                ctl_is_government.Caption = "Is Govt.";

            CompleteLoad_OrderDate();

            cStub.CurrentObject = CurrentOrder;
            cStub.CompanyIDField = "base_company_uid";
            cStub.CompanyNameField = "companyname";
            cStub.ContactIDField = "base_companycontact_uid";
            cStub.ContactNameField = "contactname";
            cStub.SetCompany();

            agent.CurrentObject = CurrentOrder;
            agent.CurrentIDField = "base_mc_user_uid";
            agent.CurrentNameField = "agentname";
            agent.SetUserName();

            switch (CurrentOrder.OrderDirection)
            {
                case Enums.OrderDirection.Outgoing:
                    cStub.Caption = "Customer";
                    break;
                default:
                    cStub.Caption = "Vendor";
                    break;
            }

            //details
            details.ExtraClassInfo = CurrentOrder.ordertype;
            //details.CurrentCollection = CurrentOrder.AllDetails;
            details.CurrentItems = CurrentOrder.DetailsAsItems(RzWin.Context);
            details.ShowTemplate("ORDERDETAIL" + CurrentOrder.ordertype, "orddet", RzWin.User.TemplateEditor);
            details.RefreshFromCollection();

            LoadNotify();

            if (CurrentOrder.isvoid)
                lblOrderType.ForeColor = System.Drawing.Color.Gray;
            else
                lblOrderType.ForeColor = System.Drawing.Color.Black;

            Double dblProfit = 0;

            if (!RzWin.Context.CheckPermit("orders:edit:edit" + CurrentOrder.ordertype))
                DisableControls();

            LoadCaptions();
            CompleteLoad_Company(CurrentOrder.CompanyVar.RefGet(RzWin.Context));

            base.CompleteLoad();
            IsLoading = false;
        }

        private void CompleteLoad_OrderDate()
        {
            lblOrderDate.Text = nTools.DateFormat(CurrentOrder.orderdate);
            lblOrderTime.Text = nTools.TimeFormat(CurrentOrder.orderdate);
        }

        protected override void DoResize()
        {
            try
            {
                details.Left = 0;
                details.Height = this.ClientRectangle.Height - details.Top;
                details.Width = this.ClientRectangle.Width - 300;
                base.DoResize();
            }
            catch (Exception)
            { }
        }

        public virtual void LoadCaptions()
        {
            if (CurrentOrder == null)
                return;
        }

        private void SaveCaptions()
        {
            if (CurrentOrder == null)
                return;
        }

        private void SetCaption(nEdit lbl, String strIn, String strDefault)
        {
            if (Tools.Strings.StrExt(strIn))
                lbl.Caption = strIn;
            else
                lbl.Caption = strDefault;
        }

        private String GetCaption(nEdit lbl, String strDefault)
        {
            if (Tools.Strings.StrCmp(lbl.Caption, strDefault))
                return "";
            else
                return lbl.Caption;
        }

        private void ChangeEditStringsToCaps()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    SetAllCaps(c);
                }
            }
            catch (Exception ee)
            { }
        }

        private void SetAllCaps(Control c)
        {
            try
            {
                if (c == null)
                    return;
                nEdit_String str = null;
                try { str = (nEdit_String)c; }
                catch { }
                if (str == null)
                {
                    foreach (Control cc in c.Controls)
                    {
                        SetAllCaps(cc);
                    }
                    return;
                }
                str.AllCaps = true;
            }
            catch (Exception ee)
            { }
        }

        //this is only going to access the screen,
        //not set any property of the order
        //and not do any checking at all
        private void CompleteLoad_Company(company c)
        {
            if (c == null)
                c = CurrentOrder.CompanyVar.RefGet(RzWin.Context);

            if (c == null)
            {
                //clear the company stuff
                return;
            }
        }


        public override void CompleteSave()
        {
            //if (CurrentOrder == null)
            //    return false;

            SaveNotify();
            SaveCaptions();

            //CurrentOrder.UpdateDetailsVoid(RzWin.Context, CurrentOrder.isvoid);

            base.CompleteSave();
        }

        private void LoadNotify()
        {
            if (CurrentOrder == null)
                return;
        }

        private void SaveNotify()
        {
            if (CurrentOrder == null)
                return;
        }

        private void LoadCheckBox(String strData, CheckBox xBox)
        {
            xBox.Checked = Tools.Strings.HasString(strData, xBox.Tag.ToString());
        }

        private String SaveCheckBox(CheckBox xBox)
        {
            if (xBox.Checked)
                return xBox.Tag.ToString();
            else
                return "";
        }

        public override void FinishedAction(ActArgs args)
        {
            switch (args.ActionName.ToLower())
            {
                case "save":
                    ts.SelectedIndex = 0;
                    break;
            }

            base.FinishedAction(args);
        }

        private void cStub_ChangeCompany(GenericEvent e)
        {
            e.Handled = true;

            String strID = "";
            String strName = "";
            frmChooseCompany_Big.ChooseCompanyID(ref strID, ref strName, Enums.CompanySelectionType.Both, "Company");

            if (strID != CurrentOrder.base_company_uid)
            {
                ctl_primaryphone.SetValue("");
                ctl_primaryfax.SetValue("");
                ctl_primaryemailaddress.SetValue("");
                CurrentOrder.contactname = "";

                company c = company.GetById(RzWin.Context, strID);
                if (c == null)
                    return;

                if (!CurrentOrder.CanAssignCompany(RzWin.Context, c))
                    return;

                CompleteSave();
                CurrentOrder.AbsorbCompany(RzWin.Context, c);
                CurrentOrder.Update(RzWin.Context);
                CompleteLoad();
                CompleteLoad_Company(c);
            }
        }

        private void details_AboutToAdd(object sender, AddArgs args)
        {
            MessageBox.Show("reorg");

            /*

            args.Handled = true;

            if (CurrentOrder.isclosed)
            {
                RzWin.Leader.Tell("This order is closed, and cannot be added to.");
                return;
            }

            if (CurrentOrder.ReadyToShip && !Rz3App.xUser.IsDeveloper())
            {
                RzWin.Leader.Tell("This order has already been marked 'Ready To Ship', and cannot be added to.");
                return;
            }

            Enums.StockType t = Enums.StockType.Any;
            switch (CurrentOrder.OrderType)
            {
                case Enums.OrderType.Purchase:
                    t = ordhed.AskForStockType("What type of purchase is this?", this.ParentForm);
                    if (t == Enums.StockType.Any)
                        return;
                    break;
            }

            orddet d = CurrentOrder.LineCreate();

            switch (CurrentOrder.OrderType)
            {
                case Enums.OrderType.Purchase:
                    d.CreateLinkedPartRecord(Rz3App.xMainForm.TheContextNM, t, true, CurrentOrder.unique_id, "");
                    break;
            }

            if (CurrentOrder.OrderDirection == Enums.OrderDirection.Incoming)
            {
                d.base_mc_user_uid = CurrentOrder.orderbuyerid;
                d.buyerid = CurrentOrder.orderbuyerid;
            }
            else
            {
                d.base_mc_user_uid = CurrentOrder.base_mc_user_uid;
                d.buyerid = CurrentOrder.orderbuyerid;
            }

            d.ISave();
            CurrentOrder.Show(d);
             * 
             * */
        }



        private void SetAddress(nEdit_List cbo, nEdit_Memo txt, String strQBField)
        {
            switch (cbo.Text.Trim().ToLower())
            {
                case "<local>":
                    txt.Text = RzWin.Logic.ShipToAddress;
                    break;
                case "<quickbooks>":
                    company c = CurrentOrder.CompanyVar.RefGet(RzWin.Context);
                    if (c != null)
                        txt.Text = (String)c.IGet(strQBField);
                    break;
                default:
                    companyaddress a = companyaddress.GetByDescription(RzWin.Context, CurrentOrder.base_company_uid, (String)cbo.GetValue());
                    if (a != null)
                        txt.SetValue(a.GetAddressString(RzWin.Context));
                    break;
            }
        }

        private void lblOrderDate_DoubleClick(object sender, EventArgs e)
        {
            if (!RzWin.User.SuperUser)
                return;

            DateTime d = frmChooseDate.ChooseDate(CurrentOrder.orderdate, "Choose a new order date:", this.ParentForm);
            if (!Tools.Dates.DateExists(d))
                return;

            CurrentOrder.orderdate = d;
            CompleteLoad_OrderDate();

        }

        private void cStub_ChangeContact(GenericEvent e)
        {
            e.Handled = true;

            if (!Tools.Strings.StrExt(CurrentOrder.base_company_uid))
                return;

            String strID = "";
            String strName = "";
            frmChooseContact_Big.ChooseContactID(ref strID, ref strName, CurrentOrder.base_company_uid, "Contact", this.ParentForm);

            if (Tools.Strings.StrExt(strID))
            {
                companycontact c = companycontact.GetById(RzWin.Context, strID);
                if (c == null)
                    return;

                //check everything
                if (!CurrentOrder.CanAssignContact(RzWin.Context, c))
                {
                    RzWin.Leader.Tell(c.ToString() + " cannot be assigned to this " + RzLogic.GetFriendlyOrderType(CurrentOrder.OrderType));
                    return;
                }

                if (CurrentOrder.OrderDirection == Enums.OrderDirection.Outgoing)
                {
                    if ((!c.HasValidMailingAddress()) && (!RzWin.User.IsDeveloper()))
                    {
                        RzWin.Leader.Tell("Each contact involved in a sale needs to have a valid direct marketing address.");
                        RzWin.Context.Show(c);
                        return;
                    }
                }

                CompleteSave();
                cStub.SetCompany(CurrentOrder.companyname, CurrentOrder.base_company_uid, strName, strID);
                CurrentOrder.AbsorbContact(RzWin.Context, c);
                CompleteLoad();
            }
        }

        public void NotifyChangeHandler(String strClass, bool adds)
        {
            try
            {
                switch (strClass.ToLower().Trim())
                {
                    case "orddet":
                    case "orddet_rfq":
                        RzWin.Context.TheLeader.Error("reorg");
                        //ArrayList a = new ArrayList();
                        //foreach (System.Collections.Generic.KeyValuePair<String, nObject> k in CurrentOrder.AllDetails)
                        //{
                        //    if (k.Value.isdel)
                        //        a.Add(k.Value);
                        //}

                        //foreach (orddet d in a)
                        //{
                        //    CurrentOrder.AllDetails.Remove(d.unique_id);
                        //}

                        //details.ReDoSearch();
                        //FillInFromDetails();
                        break;
                }
            }
            catch (Exception)
            { }
        }

        //public void NotifyChange(String strClass, bool adds)
        //{
        //    try
        //    {
        //        if (this.InvokeRequired)
        //        {
        //            HandleChangeNotification d = new HandleChangeNotification(NotifyChangeHandler);
        //            this.Invoke(d, new object[] { strClass, adds });
        //        }
        //        else
        //        {
        //            NotifyChangeHandler(strClass, adds);
        //        }
        //    }
        //    catch (Exception)
        //    { }
        //}

        public override void HandleView(string strView)
        {
            base.HandleView(strView);

            switch (strView.ToLower().Trim())
            {
                case "links":
                    CurrentOrder.ShowMap(RzWin.Context);
                    break;
                case "deal":
                    CurrentOrder.ShowDeal(RzWin.Form.TheContextNM);
                    break;
            }
        }

        private void lblAddNewBilling_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddAddress("Billing", true, false);
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

        private void lblAddNewShiping_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddAddress("Shipping", false, true);
        }

        private void ctl_terms_Load(object sender, EventArgs e)
        {
        }

        private void ctl_packinginfo_Load(object sender, EventArgs e)
        {

        }

        private void FillInFromDetails()
        {
            MessageBox.Show("reorg");

            /*
            String strShip = "";
            DateTime dtRequired = Tools.Dates.GetNullDate();
            DateTime dtShip = Tools.Dates.GetNullDate();

            foreach (KeyValuePair<String, nObject> x in details.CurrentCollection)
            {
                orddet d = (orddet)x.Value;
                if (Tools.Dates.DateExists(d.requireddate) && !Tools.Dates.DateExists(dtRequired))
                    dtRequired = d.requireddate;

                if (Tools.Dates.DateExists(d.shipdate) && !Tools.Dates.DateExists(dtShip))
                    dtShip = d.shipdate;

                if (Tools.Strings.StrExt(d.shipvia) && !Tools.Strings.StrExt(strShip))
                    strShip = d.shipvia;
            }
             * */
        }

        private void ctl_is_government_CheckChanged(object sender)
        {
            //String strMessage = "PO IN HAND";
            //if (Rz3App.xLogic.IsCTG)
            //{
            //    if (CurrentOrder.OrderType == Enums.OrderType.RFQ)
            //    {
            //        if ((bool)ctl_is_government.GetValue())
            //        {
            //            if (!Tools.Strings.HasString(CurrentOrder.orderreference, "PURCHASE ORDER TO PLACE"))
            //                CurrentOrder.orderreference += " PURCHASE ORDER TO PLACE";
            //        }
            //        else
            //        {
            //            CurrentOrder.orderreference = CurrentOrder.orderreference.Replace("PURCHASE ORDER TO PLACE", "").Trim();
            //        }
            //    }
            //}
            //else if( Rz3App.xLogic.IsPhoenix)  //Phoenix uses Rz4.ViewHeaderRFQ now and not this file
            //{
            //    if (CurrentOrder.OrderType == Enums.OrderType.RFQ)
            //    {
            //        if ((bool)ctl_is_government.GetValue())
            //        {
            //            if (!Tools.Strings.HasString(CurrentOrder.orderreference, "PO IN HAND"))
            //                CurrentOrder.orderreference += " PO IN HAND";
            //        }
            //        else
            //        {
            //            CurrentOrder.orderreference = CurrentOrder.orderreference.Replace("PO IN HAND", "").Trim();
            //        }
            //    }
            //}
        }

        private void ctl_onhold_Load(object sender, EventArgs e)
        {

        }
    }
}

