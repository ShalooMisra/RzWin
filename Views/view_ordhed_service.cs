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
    public partial class view_ordhed_service : ViewPlusMenu  //, IChangeSubscriber
    {
        public ordhed CurrentOrder;
        private companyaddress AddressToWatch;
        private bool IsLoading = false;

        public view_ordhed_service()
        {
            InitializeComponent();
        }

        public override void Init(Item item)
        {
            base.Init(item);
            CurrentOrder = (ordhed)GetCurrentObject();
            //RzWin.Context.RegisterNotifyClass(this, "orddet");
            //CurrentOrder.xSys.RegisterNotifyClass(this, "orddet_service");
            //CurrentOrder.xSys.RegisterNotifyClass(this, "companyaddress");
            //CurrentOrder.xSys.RegisterNotifyClass(this, "shippingaccount");
            cboWhy.LoadList();
            cboReimburse.LoadList();
            cboVendReimburse.LoadList();
        }

        public override void CompleteLoad()
        {
            IsLoading = true;
            lblOrderNumber.Text = CurrentOrder.ordernumber;
            lblOrderType.Text = CurrentOrder.FriendlyOrderType;

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

            CompleteLoad_Details();

            cboWhy.ListName = "rma_reason";
            cboReimburse.ListName = "reimburse_method_customer";
            cboVendReimburse.ListName = "reimburse_method_vendor";

            if( Tools.Strings.StrExt(RzWin.Logic.ShippingCaption) )
                ctl_shippingamount.Caption = RzWin.Logic.ShippingCaption;

            if( Tools.Strings.StrExt(RzWin.Logic.HandlingCaption) )
                ctl_handlingamount.Caption = RzWin.Logic.HandlingCaption;

            if( Tools.Strings.StrExt(RzWin.Logic.TaxCaption) )
                ctl_taxamount.Caption = RzWin.Logic.TaxCaption;

            ctl_isclosed.Enabled = RzWin.User.SuperUser;
            ctl_isvoid.Enabled = RzWin.User.SuperUser;
            ctl_onhold.Enabled = RzWin.User.SuperUser;
            ctl_senttoqb.Enabled = RzWin.User.SuperUser;
            ctl_senttoqb_invoice.Enabled = RzWin.User.SuperUser;

            ctl_packinginfo.SimpleList = "Ready To Ship";

            LoadNotify();
            ShowFees();
            CompleteLoad_Totals();

            if( CurrentOrder.isvoid )
                lblOrderType.ForeColor = System.Drawing.Color.Gray;
            else
                lblOrderType.ForeColor = System.Drawing.Color.Black;

            lblPaidAmount.Visible = true;

            Double dblProfit = 0;

            gbNotes_Sales.Visible = false;
            ctl_advanced_payment_made.Visible = false;
            switch( CurrentOrder.OrderType )
            {
                case Enums.OrderType.Quote:
                    ctl_shippingamount.Caption = "FREIGHT";
                    ctl_handlingamount.Caption = "BANK FEE";
                    lblPaidAmount.Visible = true;
                    lblOutstanding.Visible = false;
                    break;
                case Enums.OrderType.Sales:
                    gbNotes_Sales.Visible = true;
                    ctl_advanced_payment_made.Visible = true;
                    ctl_advanced_payment_made.Caption = "Advance Payment Received";
                    ctl_shippingamount.Caption = "FREIGHT";
                    ctl_handlingamount.Caption = "BANK FEE";
                    lblPaidAmount.Visible = true;
                    lblOutstanding.Visible = false;
                    break;
                case Enums.OrderType.Purchase:
                    ctl_advanced_payment_made.Visible = true;
                    ctl_advanced_payment_made.Caption = "Advance Payment Sent";
                    ctl_shippingamount.Caption = "INCOMING SHIPPING";
                    ctl_handlingamount.Caption = "OTHER";
                    break;
                case Enums.OrderType.Invoice:
                    ctl_shippingamount.Caption = "FREIGHT";
                    ctl_handlingamount.Caption = "BANK FEE";
                    break;
                case Enums.OrderType.RMA:
                    ctl_shippingamount.Caption = "INCOMING SHIPPING";
                    ctl_handlingamount.Caption = "OTHER";
                    cmdVendorRMA.Visible = true;
                    break;
                case Enums.OrderType.VendRMA:
                    ctl_shippingamount.Caption = "FREIGHT";
                    ctl_handlingamount.Caption = "BANK FEE";
                    break;
            }

            if( CurrentOrder.IsEitherKindOfRMA() )
            {
                pageStatus.Text = "RMA Data";
                gbRMA.Visible = true;
                LoadRMAData();
                cmdVendorRMA.Visible = (CurrentOrder.OrderType == Enums.OrderType.RMA);
            }
            else
            {
                pageStatus.Text = "Status";
                gbRMA.Visible = false;
            }

            //if (!Rz3App.xUser.CheckPermit("orders:edit:edit" + CurrentOrder.ordertype))
            //    DisableControls();

            LoadCaptions();
            CompleteLoad_Company(CurrentOrder.CompanyVar.RefGet(RzWin.Context));

            if (!CurrentOrder.onhold && !RzWin.User.SuperUser)
            {
                cmdAddService.Enabled = false;
                cmdSelectStock.Enabled = false;
            }
            else
            {
                cmdAddService.Enabled = true;
                cmdSelectStock.Enabled = true;
            }

            base.CompleteLoad();
            ctl_senttoqb.Caption = "Sent To QBs";
            ctl_senttoqb_invoice.Visible = false;
            //if (Rz3App.xLogic.IsNasco)
            //{
            //    ctl_senttoqb.Caption = "QBs As Bill";
            //    ctl_senttoqb_invoice.Caption = "QBs As Invoice";
            //    ctl_senttoqb_invoice.Visible = true;
            //    //CheckNascoAdd();
            //}

            //if (Rz3App.xLogic.IsCTG)
            //{
            //    if (Rz3App.xUser.IsDeveloper())
            //    {
            //        cmdAuthorize.Enabled = true;
            //        ctl_is_authorized.Enabled = true;
            //        ctl_authorized_date.Enabled = true;
            //        ctl_authorized_number.Enabled = true;
            //    }
            //    else
            //    {
            //        switch (Rz3App.xUser.name.ToLower())
            //        {
            //            case "joe santora":
            //            case "john mclaughlin":
            //                cmdAuthorize.Enabled = true;
            //                break;
            //            default:
            //                cmdAuthorize.Enabled = false;
            //                break;
            //        }
            //    }
            //}
            //else
            //{
                cmdAuthorize.Enabled = RzWin.User.SuperUser;
            //} 
            
            IsLoading = false;


        }

        //private void CheckNascoAdd()
        //{
        //    try
        //    {
        //        MenuSetup s = new MenuSetup();
        //        s.TheItems.Add(CurrentOrder);
        //        RzWin.Context.xSys.MenuSetup(RzWin.Context, s);
                
        //        //ummm... lets refactor whatever is going on here
        //        RzWin.Context.TheSysRz.TheOrderLogic.MenuSetupOrdHed(RzWin.Context, null);
        //        //s.Add(Rz3App.xSys.GetMenuSetup(RzWin.Context, CurrentOrder));
                
        //        xActions.mnuActions = s;
        //        xActions.LoadMenus();
        //    }
        //    catch
        //    {
        //    }
        //}

        private void CompleteLoad_Details()
        {
            RzWin.Context.TheLeader.Error("reorg");

            ////details
            //details.ExtraClassInfo = CurrentOrder.ordertype;
            //details.CurrentCollection = CurrentOrder.PartDetails;
            //details.ShowTemplate("ORDERDETAIL" + CurrentOrder.ordertype, "orddet", Rz3App.xUser.TemplateEditor);
            //details.RefreshFromCollection();

            //services.ExtraClassInfo = CurrentOrder.ordertype;
            //services.CurrentCollection = CurrentOrder.ServiceDetails;
            //services.ShowTemplate("ORDERDETAIL" + CurrentOrder.ordertype + "-services", "orddet", Rz3App.xUser.TemplateEditor);
            //services.RefreshFromCollection();
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
                base.DoResize();
                gbTotals.Left = xActions.Left - (gbTotals.Width + 10);
                gbTop.Width = (gbTotals.Left - gbTop.Left) - 5;
                ts.Width = gbTop.Width;

                gbDetails.Left = ts.Left;
                gbDetails.Top = ts.Bottom + 3;
                gbDetails.Width = ((gbTotals.Right - details.Left) / 2);

                cmdSelectStock.Left = (gbDetails.ClientRectangle.Width / 2) - (cmdSelectStock.Width / 2);
                cmdAddService.Left = (gbServices.ClientRectangle.Width / 2) - (cmdAddService.Width / 2);

                gbServices.Left = gbDetails.Right;
                gbServices.Top = gbDetails.Top;
                gbServices.Width = gbDetails.Width;

                details.Left = ts.Left;
                details.Top = gbDetails.Bottom + 3;
                details.Height = (this.ClientRectangle.Height - details.Top);
                details.Width = ((gbTotals.Right - details.Left) / 2);

                services.Top = details.Top;
                services.Left = details.Right;
                services.Height = details.Height;
                services.Width = details.Width;                 
            }
            catch (Exception)
            { }
        }

        public virtual void LoadCaptions()
        {
            if (CurrentOrder == null)
                return;

            SetCaption(ctl_shippingamount, CurrentOrder.shipping_caption, "Shipping");
            SetCaption(ctl_handlingamount, CurrentOrder.handling_caption, "Handling");
            SetCaption(ctl_taxamount, CurrentOrder.tax_caption, "Tax");
            SetCaption(ctl_subtract_1, CurrentOrder.subtract1_caption, "Subtract 1");
            SetCaption(ctl_subtract_2, CurrentOrder.subtract2_caption, "Subtract 2");
            SetCaption(ctl_subtract_3, CurrentOrder.subtract3_caption, "Subtract 3");
        }

        private void SaveCaptions()
        {
            if (CurrentOrder == null)
                return;

            CurrentOrder.shipping_caption = GetCaption(ctl_shippingamount, "Shipping");
            CurrentOrder.handling_caption = GetCaption(ctl_handlingamount, "Handling");
            CurrentOrder.tax_caption = GetCaption(ctl_taxamount, "Tax");
            CurrentOrder.subtract1_caption = GetCaption(ctl_subtract_1, "Subtract 1");
            CurrentOrder.subtract2_caption = GetCaption(ctl_subtract_2, "Subtract 2");
            CurrentOrder.subtract3_caption = GetCaption(ctl_subtract_3, "Subtract 3");
        }

        private void SetCaption(nEdit lbl, String strIn, String strDefault)
        {
            if( Tools.Strings.StrExt(strIn) )
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

        //this is only going to access the screen,
        //not set any property of the order
        //and not do any checking at all
        private void CompleteLoad_Company(company c)
        {
            if( c == null )
                c = CurrentOrder.CompanyVar.RefGet(RzWin.Context);

            if( c == null )
            {
                //clear the company stuff
                return;
            }

            LoadAddressLists(c);
            CompleteLoad_ShippingAccounts(c);

            cboCards.ClearList();

            switch( CurrentOrder.OrderDirection )
            {
                case Enums.OrderDirection.Outgoing:
                    LoadOutgoingCards(c);
                    break;
                case Enums.OrderDirection.Incoming:
                    LoadIncomingCards(c);
                    break;
            }
        }

        public virtual void LoadOutgoingCards(company c)
        {
            cboCards.AddFromArray(Tools.Strings.Split(c.creditcardnumber, ","));
        }

        public virtual void LoadIncomingCards(company c)
        {

        }

        private void CompleteLoad_ShippingAccounts(company c)
        {
            ctl_shippingaccount.ClearList();

            if (c != null)
            {
                ArrayList a = RzWin.Context.SelectScalarArray("SELECT DISTINCT(ACCOUNTNUMBER) FROM shippingaccount WHERE accountnumber > '' and base_company_uid = '" + c.unique_id + "' ORDER BY ACCOUNTNUMBER");
                ctl_shippingaccount.AddFromArray(a);
            }

            ctl_shippingaccount.AddIfNotBlank(RzWin.Logic.InternalUPS);
            ctl_shippingaccount.AddIfNotBlank(RzWin.Logic.InternalFedex);
            ctl_shippingaccount.AddIfNotBlank(RzWin.Context.GetSetting("dhl_account"));
        }

        public virtual void LoadAddressLists(company c)
        {
            if (c == null)
            {
                cboShippingAddress.ClearList();
                cboBillingAddress.ClearList();
                return;
            }

            //Addresses
            ArrayList a = RzWin.Context.SelectScalarArray("SELECT DISTINCT(DESCRIPTION) FROM companyaddress WHERE description > '' and base_company_uid = '" + c.unique_id + "' ORDER BY DESCRIPTION");

            cboShippingAddress.ClearList();
            cboShippingAddress.AddFromArray(a);
            cboShippingAddress.Add("<local>");

            cboBillingAddress.ClearList();
            cboBillingAddress.AddFromArray(a);
            cboBillingAddress.Add("<local>");

        }

        private void ConfigureScreen()
        {
            switch( CurrentOrder.OrderType )
            {
                case Enums.OrderType.Quote:
                    ctl_shippingamount.Visible = false;
                    ctl_handlingamount.Visible = false;
                    ctl_taxamount.Visible = false;
                    lblPaidAmount.Visible = false;
                    lblOutstanding.Visible = false;
                    break;
                case Enums.OrderType.Sales:
                    ctl_shippingamount.Visible = true;
                    ctl_handlingamount.Visible = true;
                    ctl_taxamount.Visible = true;
                    break;

            }
        }

        private void CompleteLoad_Totals()
        {
            CurrentOrder.CalculateAllAmounts(RzWin.Context);
            lblTotal.Text = nTools.MoneyFormat(CurrentOrder.ordertotal);
            lblSubTotal.Text = nTools.MoneyFormat(CurrentOrder.SubTotal(RzWin.Context));
            lblPaidAmount.Text = nTools.MoneyFormat(CurrentOrder.AmountPaid(RzWin.Context));
            lblOutstanding.Text = nTools.MoneyFormat(CurrentOrder.outstandingamount);
            
            if( CurrentOrder.CanHaveTransactions() )
            {
                if( CurrentOrder.outstandingamount <= 0 )
                    lblPaid.Visible = true;
                else
                    lblPaid.Visible = false;
            }
            else
            {
                lblPaid.Visible = false;
            }
        }

        public override void CompleteSave()
        {
            SaveNotify();
            SaveCaptions();

            if (CurrentOrder.IsEitherKindOfRMA())
                SaveRMAData();

            //CurrentOrder.UpdateDetailsVoid(RzWin.Context, CurrentOrder.isvoid);

            base.CompleteSave();
        }

        private void LoadNotify()
        {
            if (CurrentOrder == null)
                return;

            LoadCheckBox(CurrentOrder.legacycontact, chkConfirmShip);
            LoadCheckBox(CurrentOrder.legacycontact, chkConfirmReceive);
            LoadCheckBox(CurrentOrder.legacycontact, chkNotifyShip);
            LoadCheckBox(CurrentOrder.legacycontact, chkNotifyReceive);
        }

        private void SaveNotify()
        {
            if (CurrentOrder == null)
                return;

            CurrentOrder.legacycontact = SaveCheckBox(chkConfirmShip);
            CurrentOrder.legacycontact = nTools.Trim(CurrentOrder.legacycontact + SaveCheckBox(chkConfirmReceive));
            CurrentOrder.legacycontact = nTools.Trim(CurrentOrder.legacycontact + SaveCheckBox(chkNotifyShip));
            CurrentOrder.legacycontact = nTools.Trim(CurrentOrder.legacycontact + SaveCheckBox(chkNotifyReceive));
        }

        private void LoadCheckBox(String strData, CheckBox xBox)
        {
            xBox.Checked = Tools.Strings.HasString(strData, xBox.Tag.ToString());
        }

        private String SaveCheckBox(CheckBox xBox)
        {
            if( xBox.Checked )
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
                case "importlines":
                    ImportDetailLines();
                    break;
            }

            base.FinishedAction(args);
        }

        private void ImportDetailLines()
        {
            try
            {
                if (CurrentOrder == null)
                    return;
                dv.CompleteLoad();
                dv.SetAcceptCaption("Import These Lines");
                dv.AddCommonField("fullpartnumber", "Part Number", "part|number", true);
                dv.AddCommonField("quantityordered", "Quantity", "qty|quantity|quanity");
                dv.AddCommonField("manufacturer", "Manufacturer", "mfg|mfr|manufacturer|brand");
                dv.AddCommonField("datecode", "Date Code", "dc|datecode");
                dv.AddCommonField("unitprice", "Price", "targetprice|price");
                dv.AddCommonField("unitcost", "Cost", "cost");
                dv.AddCommonField("alternatepart", "Alternate Part #", "alternate|internal");
                dv.SetClass("orddet");
                dv.Clear();
                dv.Left = details.Left;
                dv.Width = details.Width; 
                dv.Visible = true;
                dv.BringToFront();
            }
            catch (Exception)
            { }
        }

        private void cStub_ChangeCompany(GenericEvent e)
        {
            e.Handled = true;

            String strID = "";
            String strName = "";
            frmChooseCompany_Big.ChooseCompanyID(ref strID, ref strName, Enums.CompanySelectionType.Both, "Company");

            if( strID != CurrentOrder.base_company_uid )
            {
                ctl_primaryphone.SetValue("");
                ctl_primaryfax.SetValue("");
                ctl_primaryemailaddress.SetValue("");
                CurrentOrder.contactname = "";

                company c = company.GetById(RzWin.Context, strID);
                if( c == null )
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
            RzWin.Context.TheLeader.TellTemp("Please use 'Select Stock' to add items to this service order.");
        }

        private void ShowFees()
        {
            if( !optFees.Checked )
            {
                ctl_subtract_1.Visible = true;
                ctl_subtract_2.Visible = true;
                ctl_subtract_3.Visible = true;
                ctl_shippingamount.Visible = false;
                ctl_handlingamount.Visible = false;
                ctl_taxamount.Visible = false;
            }
            else
            {
                ctl_subtract_1.Visible = false;
                ctl_subtract_2.Visible = false;
                ctl_subtract_3.Visible = false;
                ctl_shippingamount.Visible = true;
                ctl_handlingamount.Visible = true;
                ctl_taxamount.Visible = true;
            }
        }

        public void LoadRMAData()
        {

            optShip.Checked = false;
            optWarehouse.Checked = false;
            optNoReturn.Checked = false;

            optReturn.Checked = false;
            optKeep.Checked = false;
            optDiscard.Checked = false;

            ordhed xVendRMA = null;

            ordrma linkedRMA = CurrentOrder.LinkedRMAGet(RzWin.Context);

            if (linkedRMA == null)
            {
                String[] ary = Tools.Strings.Split(CurrentOrder.rma_data, "\r\n");
                cboWhy.SetValue(ary[0]);
                if( ary.Length > 1 )
                    cboReimburse.SetValue(ary[1]);

                if (ary.Length > 2)
                {
                    switch (ary[2].Trim().ToLower().Replace(" ", ""))
                    {
                        case "ship":
                            optShip.Checked = true;
                            break;
                        case "warehouse":
                            optWarehouse.Checked = true;
                            break;
                        case "noreturn":
                            optNoReturn.Checked = true;
                            break;
                    }
                }

                if (ary.Length > 3)
                {
                    switch (ary[3].Trim().ToLower().Replace(" ", ""))
                    {
                        case "return":
                            optReturn.Checked = true;
                            break;
                        case "keep":
                            optKeep.Checked = true;
                            break;
                        case "discard":
                            optDiscard.Checked = true;
                            break;
                        case "noreturn":
                            optDiscard.Checked = true;
                            break;
                    }
                }

                xVendRMA = CurrentOrder.GetLinkedVendorRMA(RzWin.Context);
                if( xVendRMA == null )
                {
                    cmdVendorRMA.Text = "Create A Vendor RMA";
                    cmdVendorRMA.Tag = "";
                }
                else
                {
                    cmdVendorRMA.Text = "Edit Vendor RMA " + xVendRMA.ordernumber;
                    cmdVendorRMA.Tag = xVendRMA.KeyID;
                }
            }
            else
            {
                cboWhy.SetValue(linkedRMA.return_reason);
                cboReimburse.SetValue(linkedRMA.customer_reimbursed);

                switch (linkedRMA.current_status.ToLower().Trim().Replace(" ", ""))
                {
                    case "ship":
                        optShip.Checked = true;
                        break;
                    case "warehouse":
                        optWarehouse.Checked = true;
                        break;
                    case "noreturn":
                        optNoReturn.Checked = true;
                        break;
                }

                switch (linkedRMA.planned_status.ToLower().Trim().Replace(" ", ""))
                {
                    case "return":
                        optReturn.Checked = true;
                        break;
                    case "keep":
                        optKeep.Checked = true;
                        break;
                    case "discard":
                        optDiscard.Checked = true;
                        break;
                    case "no return":
                        optDiscard.Checked = true;
                        break;
                }

                if (linkedRMA.customer_refund)
                    optYesCustomer.Checked = true;
                else
                    optNoCustomer.Checked = true;

                cboVendReimburse.SetValue(linkedRMA.vendor_reimbursed);

                if (linkedRMA.vendor_refund)
                    optYesVendor.Checked = true;
                else
                    optNoVendor.Checked = true;
            }

            if( xVendRMA != null )
                xVendRMA= CurrentOrder.GetLinkedVendorRMA(RzWin.Context);

            if( xVendRMA == null )
            {
                cmdVendorRMA.Text = "Create A Vendor RMA";
                cmdVendorRMA.Tag = "";
            }
            else
            {
                cmdVendorRMA.Text = "Edit Vendor RMA " + xVendRMA.ordernumber;
                cmdVendorRMA.Tag = xVendRMA.KeyID;
            }
        }

        public void SaveRMAData()
        {
            ordrma linkedRMA = CurrentOrder.LinkedRMAGet(RzWin.Context);
            if (linkedRMA == null)
            {
                String strAll = (String)cboWhy.GetValue() + "\r\n" + (String)cboReimburse.GetValue() + "\r\n";
                if( optShip.Checked )
                {
                    strAll += "Ship\r\n";
                }
                else if( optWarehouse.Checked )
                {
                    strAll += "Warehouse\r\n";
                    if( CurrentOrder.OrderType == Enums.OrderType.RMA )
                        CurrentOrder.isclosed = true;
                }
                else if( optNoReturn.Checked )
                {
                    strAll += "No Return\r\n";
                    if( CurrentOrder.OrderType == Enums.OrderType.RMA )
                        CurrentOrder.isclosed = true;
                }

                if (optReturn.Checked)
                {
                    strAll += "Return\r\n";
                    CurrentOrder.no_return = false;
                }
                else if(optKeep.Checked)
                {
                    strAll += "Keep\r\n";
                    CurrentOrder.no_return = true;
                }
                else if(optDiscard.Checked)
                {
                    strAll = strAll + "Discard\r\n";
                    CurrentOrder.no_return = true;
                }

                CurrentOrder.rma_data = strAll;
            }
            else
            {
                linkedRMA.return_reason = (String)cboWhy.GetValue();
                linkedRMA.customer_reimbursed = (String)cboReimburse.GetValue();

                if (optShip.Checked)
                    linkedRMA.current_status = "ship";
                else if (optWarehouse.Checked)
                    linkedRMA.current_status = "warehouse";
                else if (optNoReturn.Checked)
                    linkedRMA.current_status = "noreturn";
                else
                    linkedRMA.current_status = "";

                if (optReturn.Checked)
                    linkedRMA.planned_status = "return";
                else if(optKeep.Checked)
                    linkedRMA.planned_status = "keep";
                else if( optDiscard.Checked )
                    linkedRMA.planned_status = "discard";
                else
                    linkedRMA.planned_status = "";

                linkedRMA.customer_refund = optYesCustomer.Checked;
                linkedRMA.vendor_reimbursed = (String)cboVendReimburse.GetValue();
                linkedRMA.vendor_refund = optYesVendor.Checked;
                linkedRMA.Update(RzWin.Context); 
            }
        }

        private void cmdVendorRMA_Click(object sender, EventArgs e)
        {
            MessageBox.Show("reorg");

            /*

            CompleteSave();
            CurrentOrder.ISave();
            
            String strActualRMA = "";
            String strCleanRMA = "";

            switch( cmdVendorRMA.Tag.ToString() )
            {
                case "":
                    if( !RzWin.Leader.AskYesNo("Do you want to create a new Vendor RMA?") )
                        return;

                    strActualRMA = CurrentOrder.rma_data;
                    cboReimburse.Text = "";
                    SaveRMAData();
                    strCleanRMA = CurrentOrder.rma_data;
                    CurrentOrder.rma_data = strActualRMA;
                    LoadRMAData();

                    ordhed xVendRMA = CurrentOrder.MakeLinkedVendorRMA(Rz3App.xMainForm.TheContextNM, this.ParentForm);
                    if( xVendRMA == null )
                        return;

                    xVendRMA.rma_data = strCleanRMA;
                    xVendRMA.ISave();
                    if( CurrentOrder.LinkedRMA != null )
                    {
                        CurrentOrder.LinkedRMA.vendrma_ordhed_uid = xVendRMA.unique_id;
                        CurrentOrder.LinkedRMA.ISave();
                    }

                    Dictionary<String, nObject> colVRMA = xVendRMA.AllDetails;
                    foreach( KeyValuePair<String, nObject> k in CurrentOrder.AllDetails )
                    {
                        foreach(KeyValuePair<String, nObject> l in colVRMA )
                        {
                            orddet xDetail = (orddet)k.Value;
                            orddet yDetail = (orddet)l.Value;
                            if( Tools.Strings.StrCmp(xDetail.fullpartnumber, yDetail.fullpartnumber) )
                            {
                                if( optReturn.Checked )
                                    yDetail.quantityordered = xDetail.quantityordered;
                                else
                                    yDetail.quantityordered = 0;

                                yDetail.Update(RzWin.Context);
                            }
                        }
                    }

                    CurrentOrder.Show(xVendRMA);
                    break;
                default:
                    CurrentOrder.xSys.ThrowByKey(cmdVendorRMA.Tag.ToString());
                    break;
            }
             * 
             * */
        }

        private void cboBillingAddress_SelectionChanged(GenericEvent e)
        {
            SetAddress(cboBillingAddress, ctl_billingaddress, "qb_billing");
        }

        private void cboShippingAddress_SelectionChanged(GenericEvent e)
        {
            SetAddress(cboShippingAddress, ctl_shippingaddress, "qb_shiping");
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
                    if( a != null )
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

        private void optFeesOption_CheckedChanged(object sender, EventArgs e)
        {
            ShowFees();
        }

        private void cmdBillShip_Click(object sender, EventArgs e)
        {
            ctl_shippingaddress.SetValue(ctl_billingaddress.GetValue());
        }

        private void cmdShipBill_Click(object sender, EventArgs e)
        {
            ctl_billingaddress.SetValue(ctl_shippingaddress.GetValue());
        }

        private void ctl_shipvia_SelectionChanged(GenericEvent e)
        {
            
            if( Tools.Strings.StrExt(ctl_shippingaccount.Text) )
                return;

            if( CurrentOrder.OrderType == Enums.OrderType.Purchase )
            {
                String strText = (String)ctl_shipvia.GetValue();
                strText = strText.ToLower();

                if( Tools.Strings.HasString(strText, "UPS") )
                    ctl_shippingaccount.SetValue(RzWin.Logic.InternalUPS);
                else if( Tools.Strings.HasString(strText, "Fedex") )
                    ctl_shippingaccount.SetValue(RzWin.Logic.InternalFedex);
            }
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

                if (CurrentOrder.OrderDirection == Enums.OrderDirection.Outgoing && CurrentOrder.OrderType != Enums.OrderType.Service)
                {
                    //if (Rz3App.xLogic.IsCTG)
                    //{
                    //    if (!c.HasValidMailingAddress() || !c.HasValidFaxNumber())
                    //    {
                    //        if (!!Rz3App.xUser.IsDeveloper())
                    //        {
                    //            RzWin.Leader.Tell("Each contact involved in a sale needs to have a valid direct marketing address and a valid fax number.");
                    //            CurrentOrder.Show(c);
                    //            return;
                    //        }
                    //    }
                    //}
                }

                CompleteSave();
                cStub.SetCompany(CurrentOrder.companyname, CurrentOrder.base_company_uid, strName, strID);
                CurrentOrder.AbsorbContact(RzWin.Context, c);
                CompleteLoad();
            }
        }

        private void ctl_terms_KeyBeingPressed(GenericEvent e)
        {
            //if (Rz3App.xLogic.IsCTG)
            //{
            //    if (!Rz3App.xUser.IsDeveloper())
            //        return;

            //    RzWin.Context.TheLeader.TellTemp("Please contact accounting and request that the proper terms be assigned to this account.");
            //    e.Handled = true;
            //}
        }

        private void cboCards_SelectionChanged(GenericEvent e)
        {
            if( CurrentOrder.OrderDirection == Enums.OrderDirection.Outgoing )
                ctl_internalcomment.SetValue((String)cboCards.GetValue() + "\r\n" + (String)ctl_internalcomment.GetValue());
            else
                ctl_printcomment.SetValue((String)cboCards.GetValue() + "\r\n" + (String)ctl_printcomment.GetValue());
        }

        public void NotifyChangeHandler(String strClass, bool adds)
        {
            try
            {
                switch (strClass.ToLower().Trim())
                {
                    case "orddet":
                    case "orddet_service":

                        ArrayList a = new ArrayList();
                        foreach (orddet d in CurrentOrder.DetailsList(RzWin.Context))
                        {
                            if (d.Invalid)
                                a.Add(d);
                        }

                        foreach (orddet d in a)
                        {
                            CurrentOrder.Details.RefsRemove(RzWin.Context, d);
                        }

                        CompleteLoad_Details();
                        CompleteLoad_Totals();
                        //FillInFromDetails();
                        break;
                    case "companyaddress":

                        LoadAddressLists(CurrentOrder.CompanyVar.RefGet(RzWin.Context));

                        if (AddressToWatch != null)
                            LoadAddress(AddressToWatch);

                        break;
                    case "shippingaccount":
                        CompleteLoad_ShippingAccounts(CurrentOrder.CompanyVar.RefGet(RzWin.Context));
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

        private void LoadAddress(companyaddress a)
        {
            if (a.defaultbilling)
                ctl_billingaddress.SetValue(a.GetAddressString(RzWin.Context));

            if (a.defaultshipping)
                ctl_shippingaddress.SetValue(a.GetAddressString(RzWin.Context));
        }

        public override void HandleView(string strView)
        {
            base.HandleView(strView);

            switch (strView.ToLower().Trim())
            {
                case "links":
                    CurrentOrder.ShowMap(RzWin.Context);
                    break;
                case "deal":
                    //foreach (KeyValuePair<String, nObject> KeyValuePair in CurrentOrder.AllDetails)
                    //{
                    //    orddet d = (orddet)KeyValuePair.Value;
                    //    ;
                    //}
                    CurrentOrder.ShowDeal(RzWin.Context);
                    break;
            }
        }

        private void lblAddNewBilling_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddAddress("Billing",  true, false);
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

        private void cmdSwitchAddress_Click(object sender, EventArgs e)
        {
            String s = (String)ctl_billingaddress.GetValue();
            ctl_billingaddress.SetValue(ctl_shippingaddress.GetValue());
            ctl_shippingaddress.SetValue(s);
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

            foreach(KeyValuePair<String, nObject> x in details.CurrentCollection)
            {
                orddet d = (orddet)x.Value;
                if (Tools.Dates.DateExists(d.requireddate) && !Tools.Dates.DateExists(dtRequired))
                    dtRequired = d.requireddate;

                if (Tools.Dates.DateExists(d.shipdate) && !Tools.Dates.DateExists(dtShip))
                    dtShip = d.shipdate;

                if (Tools.Strings.StrExt(d.shipvia) && !Tools.Strings.StrExt(strShip))
                    strShip = d.shipvia;

                if( Tools.Dates.DateExists(dtRequired) && !Tools.Dates.DateExists(ctl_requireddate.GetValue_Date()) )
                    ctl_requireddate.SetValue(dtRequired);

                if (Tools.Dates.DateExists(dtShip) && !Tools.Dates.DateExists(ctl_dockdate.GetValue_Date()))
                    ctl_dockdate.SetValue(dtShip);

                if (Tools.Strings.StrExt(strShip) && !Tools.Strings.StrExt((String)ctl_shipvia.GetValue()))
                    ctl_shipvia.SetValue(strShip);
            }
             * 
             * */
        }

        private void ts_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ts.SelectedIndex)
            {
                case 5:
                    ShowPartPictures();
                    break;

            }
        }

        private void ShowPartPictures()
        {
            //picview.Top = 0;
            //picview.Left = 0;
            //picview.Width = pagePictures.ClientRectangle.Width;
            //picview.Height = pagePictures.ClientRectangle.Height;
            picview.DoResize();
            picview.CompleteLoad();
            picview.LoadViewBy(CurrentOrder);
            picview.Caption = "Pictures for " + CurrentOrder.ToString();
        }

        private void dv_Accept()
        {
            MessageBox.Show("reorg");
            return;

            //ArrayList a = dv.GetObjects();
            //foreach (nObjectHolder h in a)
            //{
            //    if (Tools.Strings.StrCmp(h.xObject.ClassName, "orddet"))
            //    {
            //        orddet d = (orddet)h.xObject;
            //        if (Tools.Strings.StrExt(d.fullpartnumber))
            //        {
            //            CurrentOrder.LineCreate(d);
            //        }
            //    }
            //}
            //CompleteLoad();
        }

        private void cmdUpdateCompanyInfo_Click(object sender, EventArgs e)
        {
            company c = CurrentOrder.CompanyVar.RefGet(RzWin.Context);
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

            c.Update(RzWin.Context);
        }

        private void cmdRefreshCompanyInfo_Click(object sender, EventArgs e)
        {
            company c = CurrentOrder.CompanyVar.RefGet(RzWin.Context);
            if (c == null)
            {
                RzWin.Context.TheLeader.TellTemp("Please select a company before continuing.");
                return;
            }
            CompleteSave();
            CurrentOrder.AbsorbCompany(RzWin.Context, c);
            CurrentOrder.Update(RzWin.Context);
            CompleteLoad();
            CompleteLoad_Company(c);
        }

        private void cmdAddService_Click(object sender, EventArgs e)
        {
            RzWin.Context.TheLeader.Error("reorg");

            //if (CurrentOrder.isclosed)
            //{
            //    RzWin.Leader.Tell("This order is closed, and cannot be added to.");
            //    return;
            //}

            //if (CurrentOrder.ReadyToShip && !Rz3App.xUser.IsDeveloper())
            //{
            //    RzWin.Leader.Tell("This order has already been marked 'Ready To Ship', and cannot be added to.");
            //    return;
            //}

            //orddet d = CurrentOrder.LineCreate();
            //d.is_service = true;
            //d.ISave();
            //CurrentOrder.Show(d);
        }

        //private void cmdSelectStock_Click(object sender, EventArgs e)
        //{
        //    if (Rz3App.xLogic.IsPhoenix)
        //    {
        //        orddet d = CurrentOrder.LineCreate(RzWin.Context);
        //        d.ISave();
        //        Rz3App.Show(d);
        //    }
        //    else
        //        HandleCommand("selectstock");
        //}

        //private void cmdAuthorize_Click(object sender, EventArgs e)
        //{
        //    CompleteSave();
        //    if (!CurrentOrder.is_authorized)
        //    {
        //        CurrentOrder.Authorize();
        //        cmdAuthorize.Text = "Un-Authorize";
        //    }
        //    else
        //    {
        //        CurrentOrder.UnAuthorize();
        //        cmdAuthorize.Text = "Authorize";
        //    }
        //    ctl_is_authorized.SetValue(CurrentOrder.is_authorized);
        //    ctl_authorized_date.SetValue(CurrentOrder.authorized_date);
        //    ctl_authorized_number.SetValue(CurrentOrder.authorized_number);
        //    CurrentOrder.ISave();
        //    //ShowAuthorized();
        //}
    }
}

