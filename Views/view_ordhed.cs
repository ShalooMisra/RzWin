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

using Tools;
using Core;
using NewMethod;

namespace Rz5
{
    public partial class view_ordhed : ViewPlusMenu  //, IChangeSubscriber
    {
        public ordhed CurrentOrder = null;
        private companyaddress AddressToWatch;
        private bool IsLoading = false;
        private bool bTermsChanged = false;
        bool invoiceclosed = false;
        public view_ordhed()
        { 
            InitializeComponent();
            //if(Rz3App.xLogic != null)
            //{
            //    if( Rz3App.xLogic.IsCTG )
            //        ts.TabPages.Remove(tabCreditCard);
            //}
        }
        public override void Init(Item item)
        {
            base.Init(item);
            CurrentOrder = (ordhed)GetCurrentObject();
            //CurrentOrder.xSys.RegisterNotifyClass(this, CurrentOrder.OrddetName);
            //CurrentOrder.xSys.RegisterNotifyClass(this, "companyaddress");
            //CurrentOrder.xSys.RegisterNotifyClass(this, "shippingaccount");
            //CurrentOrder.xSys.RegisterNotifyClass(this, "checkpayment");
            cboWhy.LoadList();
            cboReimburse.LoadList();
            cboVendReimburse.LoadList();
            if(CurrentOrder.OrderType != Rz5.Enums.OrderType.Invoice && CurrentOrder.OrderType != Rz5.Enums.OrderType.Purchase)
            {
                try
                {
                    ts.TabPages.Remove(pageDeductions);
                }
                catch { }
            }
            this.ctl_dockdate.Caption = "Dock Date";
            this.ctl_requireddate.Caption = "Required Date";
        }
        bool currency_first = true;
        public override void CompleteLoad()
        {
            if (nData.NullFilter_Boolean(RzWin.User.IGet("sales_assistant")))
            {
                ts.Enabled = false;
                gbTop.Enabled = false;
                gbTotals.Enabled = false;
            }

            //if (CurrentOrder == null)
            //    return false;
            ts.TabPages.Remove(pageEmails);
            ts.TabPages.Remove(tabCreditCard);
            ts.TabPages.Remove(tabProcurement);
            IsLoading = true;
            lblOrderNumber.Text = CurrentOrder.ordernumber;
                lblOrderType.Text = CurrentOrder.FriendlyOrderType;
            if (CurrentOrder.OrderType == Rz5.Enums.OrderType.RFQ)
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
            buyer.CurrentObject = CurrentOrder;
            buyer.CurrentIDField = "orderbuyerid";
            buyer.CurrentNameField = "buyername";
            buyer.SetUserName();
            //if(Rz3App.xLogic.IsCTG)
            //{
            //    ctl_for_stock.Enabled = Rz3App.xUser.SuperUser;
            //    lblSetForStock.Visible = ctl_for_stock.Visible;
            //    cmdCreditApproval.Visible = false;
            //}
            //else
            //{
                ctl_for_stock.Visible = false;
                lblSetForStock.Visible = false;
            //}
            switch(CurrentOrder.OrderDirection)
            {
                case Enums.OrderDirection.Outgoing:
                    cStub.Caption = "Customer";
                    break;
                default:
                    if (CurrentOrder.OrderType == Enums.OrderType.RMA)
                        cStub.Caption = "Customer";
                    else
                        cStub.Caption = "Vendor";
                    break;
            }
            //details

            details.Init(CurrentOrder.DetailArgsGet(RzWin.Context));
            
            //details.ExtraClassInfo = CurrentOrder.ordertype;
            //details.CurrentCollection = GetOrderDetailsForLV(); 
            //details.ShowTemplate("ORDERDETAIL" + CurrentOrder.ordertype, CurrentOrder.OrddetName, Rz3App.xUser.TemplateEditor);
            //details.RefreshFromCollection();
            
            cboWhy.ListName = "rma_reason";
            cboWhy.LoadList("rma_reason");
            
            cboReimburse.ListName = "reimburse_method_customer";
            cboReimburse.LoadList("reimburse_method_customer");

            cboVendReimburse.ListName = "reimburse_method_vendor";
            cboVendReimburse.LoadList("reimburse_method_vendor");

            ctl_isclosed.Enabled = RzWin.User.SuperUser || RzWin.User.AccountingIs || RzWin.Context.CheckPermit("Order:Edit:Can Close " + CurrentOrder.OrderType.ToString());
            ctl_isvoid.Enabled = RzWin.User.IsDeveloper() || RzWin.User.AccountingIs;
            ctl_isverified.Enabled = RzWin.User.SuperUser;
            ctl_onhold.Enabled = RzWin.User.IsDeveloper() || RzWin.User.AccountingIs;
            ctl_senttoqb.Enabled = RzWin.User.IsDeveloper() || RzWin.User.AccountingIs;
            ctl_packinginfo.SimpleList = "Ready To Ship";
            LoadNotify();
            ShowFees();
            CompleteLoad_Totals();
            if( CurrentOrder.isvoid )
                lblOrderType.ForeColor = System.Drawing.Color.Gray;
            else
                lblOrderType.ForeColor = System.Drawing.Color.Black;
            ctl_invoice_date.Visible = false;
            ctl_invoice_number.Visible = false;
            ctl_charged_amount.Visible = false;
            lblPaidAmount.Visible = true;
            Double dblProfit = 0;
            gbNotes_Sales.Visible = false;
            ctl_advanced_payment_made.Visible = false;
            switch(CurrentOrder.OrderType)
            {
                case Enums.OrderType.Quote:
                    //if(Rz3App.xLogic.IsAAT)
                    //{
                    //    ts.TabPages.Add(tabProcurement);
                    //    lvProcurement.ShowTemplate("formal_quote_prochistory", "nsn_history", Rz3App.xUser.TemplateEditor);
                    //    lvProcurement.ShowData("nsn_history", "the_req_uid in (" + GetReqIDs() + ")", "award_date", 200);
                    //}
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
                    ctl_invoice_date.Visible = RzWin.User.SuperUser || RzWin.User.AccountingIs;
                    ctl_invoice_number.Visible = RzWin.User.SuperUser || RzWin.User.AccountingIs;
                    break;
                case Enums.OrderType.Invoice:
                    ctl_shippingamount.Caption = "FREIGHT";
                    ctl_handlingamount.Caption = "BANK FEE";
                    ctl_charged_amount.Visible = RzWin.User.SuperUser || RzWin.User.AccountingIs;
                    break;
                case Enums.OrderType.RMA:
                    ctl_shippingamount.Caption = "INCOMING SHIPPING";
                    ctl_handlingamount.Caption = "OTHER";
                    cmdVendorRMA.Visible = true;
                    break;
                case Enums.OrderType.VendRMA:
                    ctl_shippingamount.Caption = "FREIGHT";
                    ctl_handlingamount.Caption = "BANK FEE";
                    ctl_orderreference.Caption = "Vendor RMA #";
                    ctl_invoice_date.Caption = "RTV Date";
                    ctl_invoice_date.Visible = RzWin.User.SuperUser || RzWin.User.AccountingIs;
                    ctl_invoice_number.Caption = "RTV Number";
                    ctl_invoice_number.Visible = RzWin.User.SuperUser || RzWin.User.AccountingIs;
                    break;
            }
            if (Tools.Strings.StrExt(RzWin.Logic.ShippingCaption))
                ctl_shippingamount.Caption = RzWin.Logic.ShippingCaption;
            if (Tools.Strings.StrExt(RzWin.Logic.HandlingCaption))
                ctl_handlingamount.Caption = RzWin.Logic.HandlingCaption;
            if (Tools.Strings.StrExt(RzWin.Logic.TaxCaption))
                ctl_taxamount.Caption = RzWin.Logic.TaxCaption;
            if(CurrentOrder.IsEitherKindOfRMA())
            {
                pageStatus.Text = "RMA Data";
                gbRMA.Visible = true;
                LoadRMAData();
                cmdVendorRMA.Visible = ( CurrentOrder.OrderType == Enums.OrderType.RMA );
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
            //authorization
            if (CurrentOrder.OrderType != Rz5.Enums.OrderType.Purchase)
            {
                lblAuthorized.Visible = false;
                ts.TabPages.Remove(pageAuthorize);
            }
            else
            {
                ShowAuthorized();
            }
            //if(Rz3App.xLogic.IsCTG)
            //{
            //    if(Rz3App.xUser.IsDeveloper())
            //    {
            //        cmdAuthorize.Enabled = true;
            //        ctl_is_authorized.Enabled = true;
            //        ctl_authorized_date.Enabled = true;
            //        ctl_authorized_number.Enabled = true;
            //    }
            //    else
            //    {
            //        switch(Rz3App.xUser.name.ToLower())
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
            base.CompleteLoad();
            IsLoading = false;
            cboCards.Width = cmdNTCUpdate.Right - cboCards.Left;            
            CheckVoid();
            if(nTools.IsTermsCreditCard(ctl_terms.GetValue_String()))
            {
                ts.TabPages.Add(tabCreditCard);
                NMWin.LoadFormValues(tabCreditCard, CurrentOrder);
                if(!Tools.Strings.StrExt(ctl_creditcardnumber.GetValue_String()))
                {
                    company c = CurrentOrder.CompanyVar.RefGet(RzWin.Context);
                    if(c != null)
                    {
                        NMWin.LoadFormValues(tabCreditCard, c);
                        NMWin.GrabFormValues(tabCreditCard, CurrentOrder);
                        CurrentOrder.Update(RzWin.Context);
                    }
                }
            }
            if(RzWin.User.super_user)
            {
                ctl_shipvia.AllowEdit = true;
                ctl_terms.AllowEdit = true;
            }
            PartPictureViewer.PictureAdded += new PictureAddedHandler(PartPictureViewer_PictureAdded);
            PartPictureViewer.PictureRemoved += new PictureRemovedHandler(PartPictureViewer_PictureRemoved);
            CheckPictureTab();
            if(xActions.IsDisabled())
            {
                xActions.Enabled = true;
                xActions.DisableExcept("|Print|Print PDF|Fax|Email|Make RMA|Links|Deal|View Order Batch|");
            }
            else
            {
                xActions.EnableDelete = CurrentOrder.CanBeDeletedBy(RzWin.Context);
            }
            lblASN.Visible = (CurrentOrder.OrderType == Rz5.Enums.OrderType.Invoice || CurrentOrder.OrderType == Rz5.Enums.OrderType.VendRMA);
            lblASN.Text = "advance shipment note";
            lblASN.Left = ctl_trackingnumber.Right - lblASN.Width;
            //if (Rz3App.xLogic.IsCTG)
            //{
            //    if (CurrentOrder.OrderType == Rz4.Enums.OrderType.Quote)
            //    {
            //        ctl_followup_date.Visible = true;
            //        ctl_followup_date.Top = ctl_dockdate.Top;
            //        ctl_followup_date.Left = ctl_dockdate.Right + 2;
            //        if (Rz3App.xLogic.IsCTG)
            //        {
            //            ctl_followup_date.Caption = "Follow-Up Date";
            //            ctl_followup_date.AllowClear = true;
            //        }
            //    }
            //}
            chkAutomaticASN.Visible = false; //((CurrentOrder.OrderType == Rz4.Enums.OrderType.Sales || CurrentOrder.OrderType == Rz4.Enums.OrderType.Invoice) && Rz3App.xLogic.IsCTG);
            invoiceclosed = (CurrentOrder.OrderType == Rz5.Enums.OrderType.Invoice) && CurrentOrder.isclosed;
        }


        private void LoadLinkedEmails()
        {
            lvLinkedEmails.ShowTemplate("view_linked_emails", "filelink", RzWin.User.TemplateEditor);
            lvLinkedEmails.ShowData("filelink", "objectclass = 'ordhed' and objectid = '" + CurrentOrder.unique_id + "' and linktype = 'email'", "", SysNewMethod.ListLimitDefault);
        }
        private void DisposeLinkedEmails()
        {
            this.lvLinkedEmails.AboutToThrow -= new Core.ShowHandler(this.lvLinkedEmails_AboutToThrow);
            this.lvLinkedEmails.AboutToAdd -= new NewMethod.AddHandler(this.lvLinkedEmails_AboutToAdd);
            this.lvLinkedEmails.FinishedFill -= new NewMethod.FillHandler(this.lvLinkedEmails_FinishedFill);
        }
        private void lvLinkedEmails_AboutToThrow(object sender, ShowArgs args)
        {
            try
            {
                args.Handled = true;
                filelink f = (filelink)lvLinkedEmails.GetSelectedObject();
                if (f == null)
                    return;
                f.LoadPictureData(RzWin.Context);
                String file = f.SaveDataAsFile();
                if (!File.Exists(file))
                    return;
                Tools.FileSystem.Shell(file);
            }
            catch (Exception)
            {
            }
        }
        private void lvLinkedEmails_AboutToAdd(object sender, AddArgs args)
        {
            MessageBox.Show("reorg");

            //try
            //{
            //    args.Handled = true;
            //    if (!Tools.Strings.StrExt(CurrentOrder.unique_id))
            //        return;
            //    DialogResult dr = oFile.ShowDialog();
            //    if (dr.Equals(DialogResult.Cancel))
            //        return;
            //    String[] files = oFile.FileNames;
            //    if (files.Length <= 0)
            //        return;
            //    foreach (String s in files)
            //    {
            //        if (!File.Exists(s))
            //            continue;
            //        if (!Tools.Strings.StrCmp(nTools.GetFileExtention(s), "msg"))
            //            continue;
            //        filelink f = new filelink(Rz3App.xSys);
            //        f.linkname = Tools.Strings.ParseDelimit(nTools.GetFileName(s), ".", 1);
            //        f.objectclass = "ordhed";
            //        f.objectid = CurrentOrder.unique_id;
            //        f.linktype = "email";
            //        f.ISave();
            //        f.SetDocDataByFile(s);
            //        f.SavePictureData();
            //        f.ISave();
            //    }
            //}
            //catch (Exception)
            //{
            //}
        }
        private void lvLinkedEmails_FinishedFill(object sender)
        {
            if (lvLinkedEmails.GetListViewControl().Items.Count > 0)
                pageEmails.Text = "Emails (" + lvLinkedEmails.GetListViewControl().Items.Count.ToString() + ")";
        }

        //joel; i looked for where this is overridden but i couldn't find it.  lets discuss this if it needs to go back in
        //public virtual Dictionary<string, nObject> GetOrderDetailsForLV()
        //{
        //    return CurrentOrder.AllDetails;
        //}
        
        void CompleteDispose()
        {
            try
            {
                //custom
                PartPictureViewer.PictureAdded -= new PictureAddedHandler(PartPictureViewer_PictureAdded);
                PartPictureViewer.PictureRemoved -= new PictureRemovedHandler(PartPictureViewer_PictureRemoved);
                //auto
                this.lblSetForStock.LinkClicked -= new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSetForStock_LinkClicked);
                this.ctl_onhold.CheckChanged -= new NewMethod.CheckChangedHandler(this.ctl_onhold_CheckChanged);
                this.lblOrderNumber.DoubleClick -= new System.EventHandler(this.lblOrderNumber_DoubleClick);
                this.ts.SelectedIndexChanged -= new System.EventHandler(this.ts_SelectedIndexChanged);
                this.lblChangeDate.LinkClicked -= new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblChangeDate_LinkClicked);
                this.cboReference.SelectedIndexChanged -= new System.EventHandler(this.cboReference_SelectedIndexChanged);
                this.cboReference.TextChanged -= new System.EventHandler(this.cboReference_TextChanged);
                this.cmdRefreshCompanyInfo.Click -= new System.EventHandler(this.cmdRefreshCompanyInfo_Click);
                this.cmdUpdateCompanyInfo.Click -= new System.EventHandler(this.cmdUpdateCompanyInfo_Click);
                this.ctl_shipvia.SelectionChanged -= new NewMethod.nEdit_List.SelectionChangedHandler(this.ctl_shipvia_SelectionChanged);
                this.ctl_terms.Load -= new System.EventHandler(this.ctl_terms_Load);
                this.ctl_terms.SelectionChanged -= new NewMethod.nEdit_List.SelectionChangedHandler(this.ctl_terms_SelectionChanged);
                this.ctl_terms.KeyBeingPressed -= new NewMethod.nEdit_List.GenericEventHandler(this.ctl_terms_KeyBeingPressed);
                this.cStub.ChangeCompany -= new ContactEventHandler(this.cStub_ChangeCompany);
                this.cStub.ChangeContact -= new ContactEventHandler(this.cStub_ChangeContact);
                this.lblASN.LinkClicked -= new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblASN_LinkClicked);
                this.cmdSwitchAddress.Click -= new System.EventHandler(this.cmdSwitchAddress_Click);
                this.lblAddNewShiping.LinkClicked -= new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAddNewShiping_LinkClicked);
                this.lblAddNewBilling.LinkClicked -= new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAddNewBilling_LinkClicked);
                this.cmdShipBill.Click -= new System.EventHandler(this.cmdShipBill_Click);
                this.cmdBillShip.Click -= new System.EventHandler(this.cmdBillShip_Click);
                this.cboBillingAddress.SelectionChanged -= new NewMethod.nEdit_List.SelectionChangedHandler(this.cboBillingAddress_SelectionChanged);
                this.cboShippingAddress.SelectionChanged -= new NewMethod.nEdit_List.SelectionChangedHandler(this.cboShippingAddress_SelectionChanged);
                this.ctl_packinginfo.Load -= new System.EventHandler(this.ctl_packinginfo_Load);
                this.cmdNTCUpdate.Click -= new System.EventHandler(this.cmdUpdateCompanyInfo_Click);
                this.cboCards.SelectionChanged -= new NewMethod.nEdit_List.SelectionChangedHandler(this.cboCards_SelectionChanged);
                this.cmdVendorRMA.Click -= new System.EventHandler(this.cmdVendorRMA_Click);
                this.lstHits.AboutToAdd -= new NewMethod.AddHandler(this.lstHits_AboutToAdd);
                this.cmdGrabCreditCardInfo.Click -= new System.EventHandler(this.cmdGrabCreditCardInfo_Click);
                this.cmdUpdateCustCreditCardInfo.Click -= new System.EventHandler(this.cmdUpdateCustCreditCardInfo_Click);
                this.lvProcurement.AboutToThrow -= new Core.ShowHandler(this.lvProcurement_AboutToThrow);
                this.optOther.CheckedChanged -= new System.EventHandler(this.optFeesOption_CheckedChanged);
                this.optFees.CheckedChanged -= new System.EventHandler(this.optFeesOption_CheckedChanged);
                this.details.AboutToAdd -= new NewMethod.AddHandler(this.details_AboutToAdd);
                this.dv.Accept -= new NewMethod.nDataViewAcceptHandler(this.dv_Accept);
                DisposeLinkedEmails();
            }
            catch
            {
            }
        }
        private void CheckPictureTab()
        {
            try
            {
                //Int64 i = Rz3App.SelectScalarInt64("select count(*) from partpicture where the_orddet_uid in (select unique_id from " + ordhed.MakeOrddetName(CurrentOrder.OrderType) + " where base_ordhed_uid = '" + CurrentOrder.unique_id + "')");
                Int64 i = RzWin.Logic.PictureData.GetScalar_Long("select count(*) from partpicture where the_ordhed_uid = '" + CurrentOrder.unique_id + "'");
                pagePictures.Text = "Attachments(" + i.ToString() + ")";
            }
            catch
            {
            }
        }
        private void CompleteLoad_OrderDate()
        {
            nlblorderdate.SetValue(nTools.DateFormat(CurrentOrder.orderdate));
            nlblordertime.SetValue(nTools.TimeFormat(CurrentOrder.orderdate));
        }
        protected override void DoResize()
        {
            try
            {
                base.DoResize();
                gbTotals.Left = AreaAvailable.Width - (gbTotals.Width + 10 );  //xMenu.Left - 
                gbTop.Width = ( gbTotals.Left - gbTop.Left ) - 5;
                ts.Width = gbTop.Width;
                details.Left = ts.Left;
                details.Top = ts.Bottom + 3;
                details.Height = ( this.ClientRectangle.Height - details.Top ) - 5;
                details.Width = gbTotals.Right - details.Left;
                ctl_internalcomment.Width = ( pageNotes.ClientRectangle.Width - ctl_internalcomment.Left ) - ctl_internalcomment.Left;
                ctl_printcomment.Width = ctl_internalcomment.Width;

                lblSaveThisOrder.Left = details.Left + (details.Width / 2) - (lblSaveThisOrder.Width / 2);
                lblSaveThisOrder.Top = details.Top + details.BottomBarTop;
            }
            catch(Exception)
            {
            }
        }
        public virtual void LoadCaptions()
        {
            if( CurrentOrder == null )
                return;
            SetCaption(ctl_shippingamount, CurrentOrder.shipping_caption, "Shipping");
            SetCaption(ctl_handlingamount, CurrentOrder.handling_caption, "Handling");
            //if (Rz3App.xLogic.IsNasco)
            //    SetCaption(ctl_taxamount, CurrentOrder.tax_caption, "CC Fee");
            //else
                SetCaption(ctl_taxamount, CurrentOrder.tax_caption, "Tax");
            SetCaption(ctl_subtract_1, CurrentOrder.subtract1_caption, "Subtract 1");
            SetCaption(ctl_subtract_2, CurrentOrder.subtract2_caption, "Subtract 2");
            SetCaption(ctl_subtract_3, CurrentOrder.subtract3_caption, "Subtract 3");
        }
        private void SaveCaptions()
        {
            if( CurrentOrder == null )
                return;
            CurrentOrder.shipping_caption = GetCaption(ctl_shippingamount, "Shipping");
            CurrentOrder.handling_caption = GetCaption(ctl_handlingamount, "Handling");
            CurrentOrder.tax_caption = GetCaption(ctl_taxamount, "Tax");
            CurrentOrder.subtract1_caption = GetCaption(ctl_subtract_1, "Subtract 1");
            CurrentOrder.subtract2_caption = GetCaption(ctl_subtract_2, "Subtract 2");
            CurrentOrder.subtract3_caption = GetCaption(ctl_subtract_3, "Subtract 3");
        }
        protected void SetCaption(nEdit lbl, String strIn, String strDefault)
        {
            if( Tools.Strings.StrExt(strIn) )
                lbl.Caption = strIn;
            else
                lbl.Caption = strDefault;
        }
        private String GetCaption(nEdit lbl, String strDefault)
        {
            if( Tools.Strings.StrCmp(lbl.Caption, strDefault) )
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
            if(c == null)
            {
                //clear the company stuff
                //if( Rz3App.xLogic.IsCTG )
                //    ctl_terms.ClearList();
                return;
            }
            LoadAddressLists(c);
            CompleteLoad_ShippingAccounts(c);
            //Terms
            switch(CurrentOrder.OrderDirection)
            {
                case Enums.OrderDirection.Outgoing:
                    //clear the list
                    //if(Rz3App.xLogic.IsCTG)
                    //{
                    //    ctl_terms.ClearList();
                    //    //LoadOutgoingTerms(c);
                    //}
                    LoadOutgoingTerms(c);
                    break;
                default:
                    LoadIncomingTerms(c);
                    break;
            }
            cboCards.ClearList();
            switch(CurrentOrder.OrderDirection)
            {
                case Enums.OrderDirection.Outgoing:
                    LoadOutgoingCards(c);
                    //if(!Rz3App.xLogic.IsCTG)
                    //{
                    //    ArrayList addys = CurrentOrder.QtC("companyaddress", "select top 2 * from companyaddress where base_company_uid = '" + CurrentOrder.CompanyVar.RefGet(RzWin.Context).unique_id + "' and (defaultbilling = 1 or defaultshipping = 1)");
                    //    foreach(companyaddress b in addys)
                    //    {
                    //        LoadAddress(b);
                    //    }
                    //}
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
            AddCard(RzWin.Logic.CreditCard_1);
            AddCard(RzWin.Logic.CreditCard_2);
            AddCard(RzWin.Logic.CreditCard_3);
            AddCard(RzWin.Logic.CreditCard_4);
        }
        private void AddCard(String card)
        {
            if( Tools.Strings.StrExt(card) )
                cboCards.Add(card);
        }
        public virtual void LoadOutgoingTerms(company c)
        {
            LoadDefaultTerms(Rz5.Enums.OrderDirection.Outgoing);
        }
        public virtual void LoadIncomingTerms(company c)
        {
            LoadDefaultTerms(Rz5.Enums.OrderDirection.Incoming);
        }
        private void LoadDefaultTerms(Enums.OrderDirection dir)
        {
            company c = CurrentOrder.CompanyVar.RefGet(RzWin.Context);
            if(c != null)
            {
                if (dir == Rz5.Enums.OrderDirection.Incoming)
                {
                    if( Tools.Strings.StrExt(c.qb_terms_v) )
                        ctl_terms.Add(c.qb_terms_v, true);
                    n_choices chs = RzWin.Context.Sys.GetChoicesByName("terms");
                    if(chs != null)
                    {
                        foreach(n_choice ch in chs.AllChoices)
                        {
                            ctl_terms.Add(ch.name, true);
                        }
                    }
                }
                else
                {
                    if( Tools.Strings.StrExt(c.qb_terms) )
                        ctl_terms.Add(c.qb_terms, true);
                }
            }
            ctl_terms.Add("COD", true);
            ctl_terms.Add("Credit Card", true);
            ctl_terms.Add("T/T in Advance", true);
            ctl_terms.Add("COD - Secured", true);
        }
        private void CompleteLoad_ShippingAccounts(company c)
        {
            ctl_shippingaccount.ClearList();
            if(c != null)
            {
                ArrayList a = RzWin.Context.SelectScalarArray("SELECT DISTINCT(ACCOUNTNUMBER) FROM shippingaccount WHERE accountnumber > '' and base_company_uid = '" + c.unique_id + "' ORDER BY ACCOUNTNUMBER");
                ctl_shippingaccount.AddFromArray(a);
            }
            ctl_shippingaccount.AddIfNotBlank(RzWin.Logic.InternalUPS);
            ctl_shippingaccount.AddIfNotBlank(RzWin.Logic.InternalFedex);
            ctl_shippingaccount.AddIfNotBlank(RzWin.Logic.InternalDHL);
            ctl_shippingaccount.AddIfNotBlank(RzWin.Logic.InternalOther);
            ctl_shippingaccount.AddIfNotBlank(RzWin.Context.GetSetting("dhl_account"));
        }
        public virtual void LoadAddressLists(company c)
        {
            if(c == null)
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
        public virtual void LoadAddressLists(companycontact c)
        {
            if(c.HasValidMailingAddress())
            {
                cboBillingAddress.Add("Contact address for " + c.contactname);
                cboShippingAddress.Add("Contact address for " + c.contactname);
            }
        }
        private void ConfigureScreen()
        {
            switch(CurrentOrder.OrderType)
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
        public virtual double GetOutstandingAmount()
        {
            return CurrentOrder.outstandingamount;
        }
        private void CompleteLoad_Totals()
        {
            CurrentOrder.CalculateAllAmounts(RzWin.Context);
            //lblTotal.Text = nTools.MoneyFormat(CurrentOrder.AmountTotal(RzWin.Context));
            lblSubTotal.Text = nTools.MoneyFormat(CurrentOrder.SubTotal(RzWin.Context));
            lblPaidAmount.Text = nTools.MoneyFormat(CurrentOrder.AmountPaid(RzWin.Context));
            double outs = GetOutstandingAmount(); 
            lblOutstanding.Text = nTools.MoneyFormat(outs);
            if (CurrentOrder.CanHaveTransactions())
            {
                if (outs <= 0 && CurrentOrder.AmountPaid(RzWin.Context) > 0)
                    lblPaid.Visible = true;
                else
                    lblPaid.Visible = false;
            }
            else
            {
                lblPaid.Visible = false;
            }
            Double dblProfit = 0;
            switch(CurrentOrder.OrderType)
            {
                case Enums.OrderType.Sales:
                    ShowProfit();
                    break;
            }
        }
        private void ShowProfit()
        {
            //lblPaidAmount.Visible = true;
            //Double dblProfit = CurrentOrder.CalcProfit(RzWin.Context, Rz3App.xLogic.IsNTC, false);
            //Double dblAll = CurrentOrder.CalcProfit(RzWin.Context, Rz3App.xLogic.IsNTC, true);
            //lblPaidAmount.Height = 144;
            //lblPaidAmount.Text = "Selected Profit: $ " + nTools.MoneyFormat(dblProfit) + "\r\nTotal Profit: $ " + nTools.MoneyFormat(dblAll);
            //if(Rz3App.xLogic.IsNasco)
            //{
            //    try
            //    {
            //        Double markup = dblAll;
            //        Double cost = CurrentOrder.ordertotal - dblAll;
            //        Double price = ( markup / cost ) * 100;
            //        String perc = String.Format("{0:F0}", price) + "%";
            //        lblPaidAmount.Height = 144;
            //        lblPaidAmount.Text = "Selected Profit: $ " + nTools.MoneyFormat(dblProfit) + "\r\nTotal Profit: $ " + nTools.MoneyFormat(dblAll) + "\r\nMarkUp Percent: " + perc;
            //    }
            //    catch
            //    { }
            //}
        }
        public override void CompleteSave()
        {
            //if( CurrentOrder == null )
            //    return false;
            try
            {
                SaveNotify();
                SaveCaptions();
                if (CurrentOrder.IsEitherKindOfRMA())
                    SaveRMAData();
                base.CompleteSave();
                if (CurrentOrder.OrderType == Rz5.Enums.OrderType.Invoice && !invoiceclosed && CurrentOrder.isclosed)
                    ((ordhed_new)CurrentOrder).CheckAutoASN(RzWin.Context);
            }
            catch(Exception)
            {

            }
        }
        private void CheckForNewShippingAccount()
        {
            try
            {
                if (CurrentOrder.OrderType == Rz5.Enums.OrderType.Purchase)
                    return;
                if (!Tools.Strings.StrExt(CurrentOrder.shippingaccount))
                    return;
                if (Tools.Strings.StrCmp(CurrentOrder.shippingaccount, "UPS:"))
                    return;
                if (Tools.Strings.StrCmp(CurrentOrder.shippingaccount, "Fedex:"))
                    return;
                String id = RzWin.Context.SelectScalarString("select unique_id from shippingaccount where base_company_uid = '" + CurrentOrder.base_company_uid + "' and accountnumber = '" + CurrentOrder.shippingaccount + "'");
                if (Tools.Strings.StrExt(id))
                    return;
                if (!RzWin.Leader.AskYesNo("Would you like to add '" + CurrentOrder.shippingaccount + "' as a shipping account to the company '" + CurrentOrder.companyname + "'?"))
                    return;
                shippingaccount s = shippingaccount.New(RzWin.Context);
                s.base_company_uid = CurrentOrder.base_company_uid;
                s.accountnumber = CurrentOrder.shippingaccount;
                s.Insert(RzWin.Context);
            }
            catch { }
        }
        private Boolean CheckForAddedCharges(ordhed original)
        {
            try
            {
                Boolean bChanged = false;
                //Shipping
                if(original.shippingamount != CurrentOrder.shippingamount)
                {
                    if(Tools.Strings.StrCmp(CurrentOrder.shippingdate.ToShortDateString(), "1/1/1900"))
                    {
                        CurrentOrder.shippingdate = DateTime.Now;
                        bChanged = true;
                    }
                }
                //Handling
                if(original.handlingamount != CurrentOrder.handlingamount)
                {
                    if(Tools.Strings.StrCmp(CurrentOrder.handlingdate.ToShortDateString(), "1/1/1900"))
                    {
                        CurrentOrder.handlingdate = DateTime.Now;
                        bChanged = true;
                    }
                }
                //Tax
                if(original.taxamount != CurrentOrder.taxamount)
                {
                    if(Tools.Strings.StrCmp(CurrentOrder.taxdate.ToShortDateString(), "1/1/1900"))
                    {
                        CurrentOrder.taxdate = DateTime.Now;
                        bChanged = true;
                    }
                }
                return bChanged;
            }
            catch(Exception)
            {
                return false;
            }
        }
        private void LoadNotify()
        {
            if( CurrentOrder == null )
                return;
            LoadCheckBox(CurrentOrder.legacycontact, chkConfirmShip);
            LoadCheckBox(CurrentOrder.legacycontact, chkConfirmReceive);
            LoadCheckBox(CurrentOrder.legacycontact, chkNotifyShip);
            LoadCheckBox(CurrentOrder.legacycontact, chkNotifyReceive);

            chkAutomaticASN.Checked = !Tools.Strings.HasString(CurrentOrder.legacycontact, "NOASN");
        }
        private void SaveNotify()
        {
            if( CurrentOrder == null )
                return;
            CurrentOrder.legacycontact = SaveCheckBox(chkConfirmShip);
            CurrentOrder.legacycontact = nTools.Trim(CurrentOrder.legacycontact + SaveCheckBox(chkConfirmReceive));
            CurrentOrder.legacycontact = nTools.Trim(CurrentOrder.legacycontact + SaveCheckBox(chkNotifyShip));
            CurrentOrder.legacycontact = nTools.Trim(CurrentOrder.legacycontact + SaveCheckBox(chkNotifyReceive));

            if (!chkAutomaticASN.Checked)
                CurrentOrder.legacycontact += "-NOASN";
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
            switch(args.ActionName.ToLower())
            {
                case "save":
                    ts.SelectedIndex = 0;
                    ApplyCreditCardHandlingAmount();;
                    CheckVoid();
                    break;
                case "importlines":
                    ImportDetailLines();
                    break;
            }
            base.FinishedAction(args);
        }
        private void ApplyCreditCardHandlingAmount()
        {
            //try
            //{
            //    if( !Rz3App.xLogic.IsAAT )
            //        return;
            //    if(Tools.Strings.StrCmp(ctl_terms.GetValue_String(), "credit card"))
            //    {
            //        Double amnt = CurrentOrder.ordertotal * 0.03;
            //        String a = amnt.ToString("###0.00");
            //        Double to = Double.Parse(a);
            //        CurrentOrder.handlingamount = to;
            //        ChangeArgs args = new ChangeArgs();
            //        args.InhibitNotify = true;
            //        CurrentOrder.ISave(RzWin.Context, args);
            //        CompleteLoad();
            //    }
            //}
            //catch(Exception)
            //{
            //}
        }
        private void ImportDetailLines()
        {
            try
            {
                if( CurrentOrder == null )
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

                //if (Rz3App.xLogic.IsPhoenix)  //Phoenix does not use this base file anymore
                //{
                //    dv.AddCommonField("internalcomment", "Serial #", "serial");
                //}
                dv.SetClass("orddet");
                dv.Clear();
                dv.Left = details.Left;
                dv.Width = details.Width;
                dv.Visible = true;
                dv.BringToFront();
            }
            catch(Exception)
            {
            }
        }
        private void cStub_ChangeCompany(GenericEvent e)
        {
            e.Handled = true;
            String strID = "";
            String strName = "";
            frmChooseCompany_Big.ChooseCompanyID(ref strID, ref strName, Enums.CompanySelectionType.Both, "Company");
            if(strID != CurrentOrder.base_company_uid)
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
                if(ts.TabPages.Contains(tabCreditCard))
                {
                    NMWin.LoadFormValues(tabCreditCard, c);
                    NMWin.GrabFormValues(tabCreditCard, CurrentOrder);
                    CurrentOrder.Update(RzWin.Context);
                }

                if (CurrentOrder.OrderType == Enums.OrderType.Purchase)
                {
                    ArrayList xs = c.VendorContactsGet(RzWin.Context);
                    if (xs.Count == 1)
                    {
                        companycontact cc = (companycontact)xs[0];
                        cStub.SetCompany(c.companyname, c.unique_id, cc.contactname, cc.unique_id);
                        cStub.ContactDisable();
                        CurrentOrder.AbsorbContact(RzWin.Context, cc);
                        CompleteLoad();
                        LoadAddressLists(c);
                    }
                    else
                    {
                        cStub.ContactEnable();
                    }
                }
            }
        }

        private void details_AboutToAdd(object sender, AddArgs args)
        {
            args.Handled = true;
            HandleCommand("add_new_detail");
        }
        private void AddNewDetail()
        {
            CurrentOrder.DetailAddWithChecks(RzWin.Context);
            details.RefreshFromCollection();
        }
        private void CreateTermsNoticeNote()
        {
            try
            {
                if( CurrentOrder == null )
                    return;
                if (CurrentOrder.OrderType != Rz5.Enums.OrderType.Invoice)
                    return;
                usernote n = null;
                if(Tools.Strings.StrExt(CurrentOrder.note_id))
                {
                    n = usernote.GetById(RzWin.Context, CurrentOrder.note_id);
                    if( n == null )
                        n = usernote.New(RzWin.Context);
                }
                else
                    n = usernote.New(RzWin.Context);
                if(!Tools.Strings.StrExt(CurrentOrder.terms) || !CurrentOrder.terms.ToLower().Contains("net"))
                {
                    n.Delete(RzWin.Context);
                    CurrentOrder.note_id = "";
                    CurrentOrder.Update(RzWin.Context);
                    return;
                }
                Int64 days = RzWin.Context.GetSettingInt64("terms_days_subtract");
                if(days <= 0)
                {
                    days = 5;
                    RzWin.Context.SetSettingInt64("terms_days_subtract", days);
                }
                n.shouldpopup = true;
                n.by_mc_user_uid = CurrentOrder.base_mc_user_uid;
                n.for_mc_user_uid = CurrentOrder.base_mc_user_uid;
                n.notetext = CurrentOrder.ToString() + " is close to it's pay due date. Contact " + CurrentOrder.companyname + " about this invoice.";
                n.CreateObjectLink(RzWin.Context, CurrentOrder, CurrentOrder.ToString());
                n.notetext = n.notetext.Trim();
                n.base_company_uid = CurrentOrder.base_company_uid;
                n.displaydate = GetTermsDate(days);
                n.Insert(RzWin.Context);
                if(Tools.Strings.StrExt(n.unique_id))
                {
                    CurrentOrder.note_id = n.unique_id;
                    CurrentOrder.Update(RzWin.Context);
                }
            }
            catch(Exception)
            {
            }
        }
        private DateTime GetTermsDate(Int64 days)
        {
            if( !Tools.Strings.StrExt(CurrentOrder.terms) )
                return DateTime.Now;
            String hold = CurrentOrder.terms.ToLower().Replace("net", "").Trim();
            if(hold.Contains("%"))
            {
                String[] str = Tools.Strings.Split(hold, " ");
                foreach(String s in str)
                {
                    if( s.Trim().Contains("%") )
                        continue;
                    if( !Tools.Strings.StrExt(s) )
                        continue;
                    hold = s.Trim();
                    break;
                }
            }
            if( !Tools.Number.IsNumeric(hold) )
                return DateTime.Now;
            Int32 dayz = Int32.Parse(hold);
            DateTime dt = CurrentOrder.orderdate.AddDays(dayz);
            dt = dt.AddDays((Double)days * -1);
            return dt;
        }
        private void UpdateCustomerShipAccount()
        {
            if (CurrentOrder == null)
                return;
            if (!Tools.Strings.StrExt(CurrentOrder.base_company_uid))
                return;
            string acnt = "";
            if (Tools.Strings.HasString(ctl_shipvia.GetValue_String(), "UPS"))
                acnt = RzWin.Context.SelectScalarString("select max(accountnumber) from shippingaccount where base_company_uid = '" + CurrentOrder.base_company_uid + "' and description like '%UPS%'");
            else if (Tools.Strings.HasString(ctl_shipvia.GetValue_String(), "FedEx"))
                acnt = RzWin.Context.SelectScalarString("select max(accountnumber) from shippingaccount where base_company_uid = '" + CurrentOrder.base_company_uid + "' and description like '%FedEx%'");
            else if (Tools.Strings.HasString(ctl_shipvia.GetValue_String(), "DHL"))
                acnt = RzWin.Context.SelectScalarString("select max(accountnumber) from shippingaccount where base_company_uid = '" + CurrentOrder.base_company_uid + "' and description like '%DHL%'");
            if (Tools.Strings.StrExt(acnt))
                ctl_shippingaccount.SetValue(acnt);
        }
        private void CheckVoid()
        {
            lblVoid.Visible = false;
            if( CurrentOrder == null )
                return;
            if( CurrentOrder.isvoid )
                lblVoid.Visible = true;
        }
        private void ShowFees()
        {
            if(!optFees.Checked)
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
                if(ary.Length > 2)
                {
                    switch(ary[2].Trim().ToLower().Replace(" ", ""))
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
                if(ary.Length > 3)
                {
                    switch(ary[3].Trim().ToLower().Replace(" ", ""))
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
                if(xVendRMA == null)
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
                xVendRMA = CurrentOrder.GetLinkedVendorRMA(RzWin.Context);
            if(xVendRMA == null)
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
                linkedRMA = ordrma.New(RzWin.Context);
                CurrentOrder.LinkedRMASet(linkedRMA);
                if (CurrentOrder.OrderType == Rz5.Enums.OrderType.RMA)
                    linkedRMA.rma_ordhed_uid = CurrentOrder.unique_id;
                else
                    linkedRMA.vendrma_ordhed_uid = CurrentOrder.unique_id;
                linkedRMA.Insert(RzWin.Context);

                //String strAll = (String)cboWhy.GetValue() + "\r\n" + (String)cboReimburse.GetValue() + "\r\n";
                //if( optShip.Checked )
                //{
                //    strAll += "Ship\r\n";
                //}
                //else if( optWarehouse.Checked )
                //{
                //    strAll += "Warehouse\r\n";
                //    if( CurrentOrder.OrderType == Enums.OrderType.RMA )
                //        CurrentOrder.isclosed = true;
                //}
                //else if( optNoReturn.Checked )
                //{
                //    strAll += "No Return\r\n";
                //    if( CurrentOrder.OrderType == Enums.OrderType.RMA )
                //        CurrentOrder.isclosed = true;
                //}
                //if (optReturn.Checked)
                //{
                //    strAll += "Return\r\n";
                //    CurrentOrder.no_return = false;
                //}
                //else if(optKeep.Checked)
                //{
                //    strAll += "Keep\r\n";
                //    CurrentOrder.no_return = true;
                //}
                //else if(optDiscard.Checked)
                //{
                //    strAll = strAll + "Discard\r\n";
                //    CurrentOrder.no_return = true;
                //}
                //CurrentOrder.rma_data = strAll;
            }
            linkedRMA.return_reason = (String)cboWhy.GetValue();
            linkedRMA.customer_reimbursed = (String)cboReimburse.GetValue();
            if( optShip.Checked )
                linkedRMA.current_status = "ship";
            else if( optWarehouse.Checked )
                linkedRMA.current_status = "warehouse";
            else if( optNoReturn.Checked )
                linkedRMA.current_status = "noreturn";
            else
                linkedRMA.current_status = "";
            if( optReturn.Checked )
                linkedRMA.planned_status = "return";
            else if( optKeep.Checked )
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
        private String GetReqIDs()
        {
            if( CurrentOrder == null )
                return "'<none>'";
            String build = "";


            RzWin.Context.TheLeader.Error("reorg");

            //ArrayList dets = CurrentOrder.GetDetailArray();
            //foreach(orddet od in dets)
            //{
            //    if(Tools.Strings.StrExt(od.req_uid))
            //    {
            //        if( Tools.Strings.StrExt(build) )
            //            build += ",'" + od.req_uid + "'";
            //        else
            //            build = "'" + od.req_uid + "'";
            //    }
            //}
            //if( !Tools.Strings.StrExt(build) )
            //    return "'<none>'";

            return build;
        }
        private void cmdVendorRMA_Click(object sender, EventArgs e)
        {
            RzWin.Context.TheLeader.Error("reorg");

            /*

            CompleteSave();
            CurrentOrder.ISave();
            String strActualRMA = "";
            String strCleanRMA = "";
            switch(cmdVendorRMA.Tag.ToString())
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
                    if(CurrentOrder.LinkedRMA != null)
                    {
                        CurrentOrder.LinkedRMA.vendrma_ordhed_uid = xVendRMA.unique_id;
                        CurrentOrder.LinkedRMA.ISave();
                    }
                    Dictionary<String, nObject> colVRMA = xVendRMA.AllDetails;
                    foreach(KeyValuePair<String, nObject> k in CurrentOrder.AllDetails)
                    {
                        foreach(KeyValuePair<String, nObject> l in colVRMA)
                        {
                            orddet xDetail = (orddet)k.Value;
                            orddet yDetail = (orddet)l.Value;
                            if(Tools.Strings.StrCmp(xDetail.fullpartnumber, yDetail.fullpartnumber))
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
            switch(cbo.GetValue_String().Trim().ToLower())
            {
                case "<local>":
                    txt.SetValue(RzWin.Logic.ShipToAddress);
                    break;
                case "<quickbooks>":
                    company c = CurrentOrder.CompanyVar.RefGet(RzWin.Context);
                    if( c != null )
                        txt.SetValue((String)c.IGet(strQBField));
                    break;
                default:
                    if(cbo.GetValue_String().StartsWith("Contact address for"))
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
                            txt.SetValue(a.GetAddressString(RzWin.Context));
                    }
                    break;
            }
        }
        private void ChangeDate()
        {
            if( !RzWin.User.SuperUser )
                return;
            DateTime d = frmChooseDate.ChooseDate(CurrentOrder.orderdate, "Choose a new order date:", this.ParentForm);
            if( !Tools.Dates.DateExists(d) )
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
            if (Tools.Strings.StrExt(ctl_shippingaccount.Text))
                return;
            if(CurrentOrder.OrderType == Enums.OrderType.Purchase)
            {
                String strText = (String)ctl_shipvia.GetValue();
                strText = strText.ToLower();
                if (Tools.Strings.HasString(strText, "UPS"))
                    ctl_shippingaccount.SetValue(RzWin.Logic.InternalUPS);
                else if (Tools.Strings.HasString(strText, "Fedex"))
                    ctl_shippingaccount.SetValue(RzWin.Logic.InternalFedex);
                else if (Tools.Strings.HasString(strText, "DHL"))
                    ctl_shippingaccount.SetValue(RzWin.Logic.InternalDHL);
            }
        }
        private void cStub_ChangeContact(GenericEvent e)
        {
            e.Handled = true;
            if( !Tools.Strings.StrExt(CurrentOrder.base_company_uid) )
                return;
            ArrayList xs = null;
            companycontact c = null;
            if (CurrentOrder.OrderType == Enums.OrderType.Purchase)
            {
                company comp = CurrentOrder.CompanyVar.RefGet(RzWin.Context);
                if( comp != null )
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
                frmChooseContact_Big.ChooseContactID(ref strID, ref strName, CurrentOrder.base_company_uid, "Contact", this.ParentForm);
                if(Tools.Strings.StrExt(strID))
                    c = companycontact.GetById(RzWin.Context, strID);
            }
            else
            {
                companycontact xc = frmChooseContact_Big.Choose(xs, "Choose A Vendor Contact");
                if (xc == null)
                    return;
                c = xc;
            }
            if( c == null )
                return;
            //check everything
            if (!CurrentOrder.CanAssignContact(RzWin.Context, c))
            {
                RzWin.Leader.Tell(c.ToString() + " cannot be assigned to this " + RzLogic.GetFriendlyOrderType(CurrentOrder.OrderType));
                return;
            }
            //2010_11_30  took this out after the 15th phone call about it
            //if(CurrentOrder.OrderDirection == Enums.OrderDirection.Outgoing)
            //{
            //    if(Rz3App.xLogic.IsCTG)
            //    {
            //        if(!c.HasValidMailingAddress() || !c.HasValidFaxNumber())
            //        {
            //            if(!Rz3App.xUser.IsDeveloper())
            //            {
            //                RzWin.Leader.Tell("Each contact involved in a sale needs to have a valid direct marketing address and a valid fax number.");
            //                CurrentOrder.Show(c);
            //                return;
            //            }
            //        }
            //    }
            //}
            CompleteSave();
            cStub.SetCompany(CurrentOrder.companyname, CurrentOrder.base_company_uid, c.contactname, c.unique_id);
            CurrentOrder.AbsorbContact(RzWin.Context, c);
            CompleteLoad();
            LoadAddressLists(c);
        }
        private void ctl_terms_SelectionChanged(GenericEvent e)
        {
            if( IsLoading )
                return;
            if(CurrentOrder.OrderType == Enums.OrderType.Sales || CurrentOrder.OrderType == Enums.OrderType.Invoice)
            {
                if( CurrentOrder.taxamount > 0 )
                    return;
                if(nTools.IsTermsTT((String)ctl_terms.GetValue()))
                {
                    Double d = (Double)ctl_handlingamount.GetValue();
                    if(d == 0)
                    {
                        if(RzWin.Leader.AskYesNo("Do you want to add the standard bank fee to this order?"))
                        {
                            //if(Rz3App.xLogic.IsCTG)
                            //{
                            //    ctl_handlingamount.SetValue(Convert.ToDouble(40));
                            //}
                            //else
                            //{
                                nDouble amnt = RzWin.Context.GetSettingDouble("default_bank_charge");
                                if(amnt == 0)
                                {
                                    amnt = 25;
                                    RzWin.Context.SetSettingDouble("default_bank_charge", amnt);
                                }
                                ctl_handlingamount.SetValue(amnt);
                            //}
                        }
                    }
                }
            }
            if(nTools.IsTermsCreditCard(ctl_terms.GetValue_String()))
            {
                if(!ts.TabPages.Contains(tabCreditCard))
                {
                    ts.TabPages.Add(tabCreditCard);
                    company c = CurrentOrder.CompanyVar.RefGet(RzWin.Context);
                    if(c != null)
                    {
                        NMWin.LoadFormValues(tabCreditCard, c);
                        NMWin.GrabFormValues(tabCreditCard, CurrentOrder);
                        CurrentOrder.Update(NMWin.ContextDefault);
                    }
                }
            }
            else
            {
                if( ts.TabPages.Contains(tabCreditCard) )
                    ts.TabPages.Remove(tabCreditCard);
            }
            if (CurrentOrder.OrderType == Rz5.Enums.OrderType.Purchase)
            {
                if(nTools.IsTermsCreditCard(ctl_terms.GetValue_String()))
                {
                    if (Tools.Strings.StrExt(CurrentOrder.CompanyVar.RefGet(RzWin.Context).cc_warning))
                    {
                        if (!RzWin.Leader.AskYesNo("This company has a credit card message attached from accounting:\r\n\r\n" + CurrentOrder.CompanyVar.RefGet(RzWin.Context).cc_warning + "\r\n\r\n\r\nDo you want to continue with these terms?"))
                        {
                            ctl_terms.GetCombo().SelectedIndex = 0; 
                            return;
                        }
                    }
                    if (CurrentOrder.CompanyVar.RefGet(RzWin.Context).cc_charge > 0)
                    {
                        ctl_taxamount.SetValue(CurrentOrder.CompanyVar.RefGet(RzWin.Context).cc_charge);
                    }
                }
            }
        }
        private nDouble GetOrderLineTotal()
        {
            MessageBox.Show("reorg");
            return 0;

            //try
            //{
            //    nDouble d = 0;
            //    ArrayList a = CurrentOrder.GetDetailCollection();
            //    foreach(orddet od in a)
            //    {
            //        d += od.quantityordered * od.unitprice;
            //    }
            //    return d;
            //}
            //catch
            //{
            //    return 0;
            //}
        }
        private void ctl_terms_KeyBeingPressed(GenericEvent e)
        {
            //if(Rz3App.xLogic.IsCTG)
            //{
            //    if( Rz3App.xUser.IsDeveloper() )
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
                switch(strClass.ToLower().Trim())
                {
                    case "companyaddress":
                        LoadAddressLists(CurrentOrder.CompanyVar.RefGet(RzWin.Context));
                        if( AddressToWatch != null )
                            LoadAddress(AddressToWatch);
                        break;
                    case "shippingaccount":
                        CompleteLoad_ShippingAccounts(CurrentOrder.CompanyVar.RefGet(RzWin.Context));
                        break;
                    case "checkpayment":
                        CompleteLoad_Totals();
                        break;
                    default:
                        if(strClass.ToLower().StartsWith("orddet"))
                        {
                            ArrayList a = new ArrayList();
                            foreach(orddet d in CurrentOrder.DetailsList(RzWin.Context))
                            {
                                if( d.Invalid )
                                    a.Add(d);
                            }
                            foreach(orddet d in a)
                            {
                                CurrentOrder.Details.RefsRemove(RzWin.Context, d);
                            }
                            details.ReDoSearch();
                            CompleteLoad_Totals();
                            FillInFromDetails();
                            //ApplyCreditCardHandlingAmount();
                        }
                        break;
                }
            }
            catch(Exception)
            {
            }
        }
        //public void NotifyChange(String strClass, bool adds)
        //{
        //    try
        //    {
        //        if(this.InvokeRequired)
        //        {
        //            HandleChangeNotification d = new HandleChangeNotification(NotifyChangeHandler);
        //            this.Invoke(d, new object[]{ strClass, adds });
        //        }
        //        else
        //        {
        //            NotifyChangeHandler(strClass, adds);
        //        }
        //    }
        //    catch(Exception)
        //    {
        //    }
        //}
        private void LoadAddress(companyaddress a)
        {
            if(a.defaultbilling)
            {
                if( !Tools.Strings.StrExt((String)ctl_billingaddress.GetValue()) )
                    ctl_billingaddress.SetValue(a.GetAddressString(RzWin.Context));
            }
            if(a.defaultshipping)
            {
                if( !Tools.Strings.StrExt((String)ctl_shippingaddress.GetValue()) )
                    ctl_shippingaddress.SetValue(a.GetAddressString(RzWin.Context));
            }
        }
        private void DoConvertToInvoice()
        {
            try
            {
                CurrentOrder.is_invoice = true;
                CurrentOrder.Update(RzWin.Context);
                CompleteLoad();
            }
            catch
            {
            }
        }
      
        public override void HandleCommand(string strCommand)
        {

            switch(strCommand.ToLower().Trim())
            {
                case "add_new_detail":
                    AddNewDetail();
                    break;
                case "converttoinvoice":
                    DoConvertToInvoice();
                    break;
                case "selectstock":
                    switch(CurrentOrder.OrderType)
                    {
                        case Rz5.Enums.OrderType.Sales:
                            if(!CurrentOrder.onhold && !RzWin.User.IsDeveloper())
                            {
                                RzWin.Leader.Tell("This order has already been completed, and cannot be added to.");
                                return;
                            }
                            break;
                    }
                    break;
            }
            base.HandleCommand(strCommand);
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
        private void cmdSwitchAddress_Click(object sender, EventArgs e)
        {
            String s = (String)ctl_billingaddress.GetValue();
            ctl_billingaddress.SetValue(ctl_shippingaddress.GetValue());
            ctl_shippingaddress.SetValue(s);
        }
        private void ctl_terms_Load(object sender, EventArgs e)
        {
        }
        private void ctl_packinginfo_Load(object sender, EventArgs e)
        {
        }
        private void FillInFromDetails()
        {
            //MessageBox.Show("reorg");
            //this is all going to be on the line and rolled up to the order, right?
            /*
            String strShip = "";
            DateTime dtRequired = Tools.Dates.GetNullDate();
            DateTime dtShip = Tools.Dates.GetNullDate();
            foreach(KeyValuePair<String, nObject> x in details.CurrentCollection)
            {
                orddet d = (orddet)x.Value;
                if( Tools.Dates.DateExists(d.requireddate) && !Tools.Dates.DateExists(dtRequired) )
                    dtRequired = d.requireddate;
                if( Tools.Dates.DateExists(d.shipdate) && !Tools.Dates.DateExists(dtShip) )
                    dtShip = d.shipdate;
                if( Tools.Strings.StrExt(d.shipvia) && !Tools.Strings.StrExt(strShip) )
                    strShip = d.shipvia;
                if( Tools.Dates.DateExists(dtRequired) && !Tools.Dates.DateExists(ctl_requireddate.GetValue_Date()) )
                    ctl_requireddate.SetValue(dtRequired);
                if( Tools.Dates.DateExists(dtShip) && !Tools.Dates.DateExists(ctl_dockdate.GetValue_Date()) )
                    ctl_dockdate.SetValue(dtShip);
                if( Tools.Strings.StrExt(strShip) && !Tools.Strings.StrExt((String)ctl_shipvia.GetValue()) )
                    ctl_shipvia.SetValue(strShip);
            }
             * */
        }
        private void ctl_is_government_CheckChanged(object sender)
        {
            if (CurrentOrder.OrderType == Rz5.Enums.OrderType.RFQ)
            {
                if((bool)ctl_is_government.GetValue())
                {
                    if( !Tools.Strings.HasString(ctl_orderreference.GetValue_String(), "PURCHASE ORDER TO PLACE") )
                        ctl_orderreference.SetValue(( ctl_orderreference.GetValue_String() + " PURCHASE ORDER TO PLACE" ).Trim());
                }
                else
                {
                    ctl_orderreference.SetValue(ctl_orderreference.GetValue_String().Replace("PURCHASE ORDER TO PLACE", "").Trim());
                }
                
            }
        }
        private void ts_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoResize();
            switch(ts.SelectedIndex)
            {
                case 5:
                    ShowPartPictures();
                    break;
                default:
                    if( ts.SelectedTab == pageDeductions )
                        CompleteLoad_Deductions();
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
        private void CompleteLoad_Deductions()
        {
            //try
            //{
            //    if (Rz3App.xLogic == null)  //this gets called by the designer sometimes
            //        return;
            //    Boolean add = false;
            //    add = Rz3App.xUser.SuperUser;
            //    lstHits.AllowAdd = add;
            //    lstHits.CurrentItems = CurrentOrder.GetHits();
            //    lstHits.ShowCollection("ordhit", "all_order_hits");
            //}
            //catch { }
        }
        //private void cmdAuthorize_Click(object sender, EventArgs e)
        //{
        //    CompleteSave();
        //    if(!CurrentOrder.is_authorized)
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
        //    ShowAuthorized();
        //}
        private void ShowAuthorized()
        {
            if(CurrentOrder.is_authorized)
            {
                lblAuthorized.Text = "Authorized on " + nTools.DateFormat(CurrentOrder.authorized_date) + "   [ " + Tools.Number.LongFormat(CurrentOrder.authorized_number) + " ]";
                lblAuthorized.Visible = true;
            }
            else
            {
                lblAuthorized.Text = "";
                lblAuthorized.Visible = false;
            }
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
                view_companyaddress cadd = new view_companyaddress();
                cadd.SetCurrentObject(ca);
                cadd.CompleteLoad();
                RzWin.Form.TabShow(cadd, "New Address");
                cadd.PasteAddress();
            }
            catch { }
        }
        private void dv_Accept()
        {
            RzWin.Context.TheLeader.Error("reorg");

            /*

            ArrayList a = dv.GetObjects();
            List<orddet> result = new List<orddet>();
            foreach(nObjectHolder h in a)
            {
                if(Tools.Strings.StrCmp(h.xObject.ClassName, "orddet"))
                {
                    orddet d = (orddet)h.xObject;
                    if(Tools.Strings.StrExt(d.fullpartnumber))
                    {
                        result.Add(CurrentOrder.LineCreate(d));
                    }
                }
            }

            if (Rz3App.xLogic.IsSelect)
            {
                if (RzWin.Leader.AskYesNo("Do you want to automatically create stock items for these parts and fill each line?"))
                {
                    foreach (orddet d in result)
                    {
                        partrecord p = d.CreateLinkedPartRecord(Rz3App.xMainForm.TheContextNM, Rz4.Enums.StockType.Stock);
                        p.quantity = d.quantityordered;

                        try
                        {
                            if (Rz3App.xLogic.IsSelect)
                            {
                                p.buyerid = CurrentOrder.orderbuyerid;
                                p.buyername = CurrentOrder.buyername;
                                p.companyname = CurrentOrder.companyname;
                                p.base_company_uid = CurrentOrder.base_company_uid;
                                if (CurrentOrder.OrderType == Rz4.Enums.OrderType.Purchase)
                                {
                                    p.vendorid = CurrentOrder.base_company_uid;
                                    p.vendorname = CurrentOrder.companyname;
                                }
                            }
                        }
                        catch { }


                        p.ISave();

                        d.quantityfilled = d.quantityordered;
                        d.ISave();
                    }
                }
            }

            LinesImported(result);

            CompleteLoad();
            dv.Visible = false;
             * 
             * */
        }

        public virtual void LinesImported(List<orddet> lines)
        {

        }

        private void cmdUpdateCompanyInfo_Click(object sender, EventArgs e)
        {
            company c = CurrentOrder.CompanyVar.RefGet(RzWin.Context);
            if(c == null)
            {
                RzWin.Context.TheLeader.TellTemp("Please select a company before continuing.");
                return;
            }
            if( Tools.Strings.StrExt(ctl_primaryphone.GetValue_String()) )
                c.primaryphone = ctl_primaryphone.GetValue_String();
            if( Tools.Strings.StrExt(ctl_primaryfax.GetValue_String()) )
                c.primaryfax = ctl_primaryfax.GetValue_String();
            if( Tools.Strings.StrExt(ctl_primaryemailaddress.GetValue_String()) )
                c.primaryemailaddress = ctl_primaryemailaddress.GetValue_String();
            try
            {
                c.Update(RzWin.Context);
            }
            catch
            {
                RzWin.Leader.Tell("The company " + c.companyname + " has been updated.\r\nPhone=" + c.primaryphone + "\r\nFax=" + c.primaryfax + "\r\nEmail=" + c.primaryemailaddress);
            }
        }
        private void cmdRefreshCompanyInfo_Click(object sender, EventArgs e)
        {
            company c = CurrentOrder.CompanyVar.RefGet(RzWin.Context);
            if(c == null)
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
        private void cboReference_SelectedIndexChanged(object sender, EventArgs e)
        {
            ctl_orderreference.SetValue(cboReference.Text);
        }
        private void lblSetForStock_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ctl_for_stock.SetValue(true);
        }
        private void lstHits_AboutToAdd(object sender, AddArgs args)
        {
            args.Handled = true;
            ordhit h = ordhit.New(RzWin.Context);
            h.the_ordhed_uid = CurrentOrder.unique_id;
            h.the_n_user_uid = RzWin.User.unique_id;
            //h.deduct_profit = true;
            h.LinkedOrder = CurrentOrder;
            h.Insert(RzWin.Context);
            CurrentOrder.GetHits(RzWin.Context).Add(h.unique_id, h);
            lstHits.RefreshFromCollection();
            RzWin.Context.Show(h);
        }
        private void cboReference_TextChanged(object sender, EventArgs e)
        {
            ctl_orderreference.SetValue(cboReference.Text);
        }
        private void cmdUpdateCustCreditCardInfo_Click(object sender, EventArgs e)
        {
            if( !RzWin.Leader.AskYesNo("This will overwrite any existing credit-card information on the company. Ok to continue?") )
                return;
            company c = CurrentOrder.CompanyVar.RefGet(RzWin.Context);
            if(c != null)
            {
                NMWin.GrabFormValues(tabCreditCard, c);
                c.Update(RzWin.Context);
            }
        }
        private void cmdGrabCreditCardInfo_Click(object sender, EventArgs e)
        {
            company c = CurrentOrder.CompanyVar.RefGet(RzWin.Context);
            if( c != null )
                NMWin.LoadFormValues(tabCreditCard, c);
        }
        private void lvProcurement_AboutToThrow(object sender, ShowArgs args)
        {
            args.Handled = true;
        }
        //private void CheckNascoAdd()
        //{
        //    try
        //    {
        //        MenuSetup s = new MenuSetup();
        //        s.TheItems.Add(CurrentOrder);
        //        RzWin.Context.xSys.MenuSetup(RzWin.Context, s);

        //        xActions.mnuActions = s;
        //        xActions.LoadMenus();
        //        if (CurrentOrder.OrderType != Rz4.Enums.OrderType.Sales)
        //        {
        //            if (CurrentOrder.OrderType == Rz4.Enums.OrderType.Purchase)
        //                //CheckForApprovalButton();
        //                return;
        //        }
        //        if(CurrentOrder.onhold)
        //        {
        //            ctl_onhold.Enabled = false;
        //            return;
        //        }
        //        else
        //            ctl_onhold.Enabled = true;
        //        CheckForApprovalButton();
        //    }
        //    catch
        //    {
        //    }
        //}
        //private void CheckWorldshipAdd()
        //{
        //    try
        //    {
        //        MenuSetup s = new MenuSetup();
        //        s.TheItems.Add(CurrentOrder);
        //        RzWin.Context.xSys.MenuSetup(RzWin.Context, s);
        //        //CurrentOrder.GetMenuSetup(CurrentOrder.ordertype, false, NewMethod.Enums.MenuType.Screen, null);
        //        //s.Add(Rz3App.xSys.GetMenuSetup(CurrentOrder));
        //        xActions.mnuActions = s;
        //        xActions.LoadMenus();
        //    }
        //    catch
        //    {
        //    }
        //}
        private void CheckForApprovalButton()
        {
            if (CurrentOrder.OrderType != Rz5.Enums.OrderType.Sales)
                return;
            cmdCreditApproval.Visible = false;
            ctl_credit_check_approved.Visible = false;
            n_team t = n_team.GetByName(RzWin.Context, "ORDER APPROVAL");
            if( t == null )
                return;
            ArrayList a = t.GetUserIDs(RzWin.Context);
            Boolean bFound = false;
            foreach(String str in a)
            {
                if(Tools.Strings.StrCmp(str, RzWin.User.unique_id))
                {
                    bFound = true;
                    break;
                }
            }
            if(bFound)
            {
                cmdCreditApproval.Text = "Approve Order";
                ctl_credit_check_approved.Caption = "Order Approved";
                if(CurrentOrder.credit_check_approved)
                {
                    cmdCreditApproval.Visible = false;
                    ctl_credit_check_approved.Visible = true;
                    ctl_credit_check_approved.BringToFront();
                }
                else
                {
                    cmdCreditApproval.Visible = true;
                    ctl_credit_check_approved.Visible = false;
                    cmdCreditApproval.BringToFront();
                }
            }
        }

        private void ctl_credit_check_approved_CheckChanged(object sender)
        {
            if( IsLoading )
                return;
            CompleteSave();
        }
        private void ctl_onhold_CheckChanged(object sender)
        {
            if( IsLoading )
                return;
            CompleteSave();
        }

        void PartPictureViewer_PictureAdded()
        {
            CheckPictureTab();
        }
        void PartPictureViewer_PictureRemoved()
        {
            CheckPictureTab();
        }
        private void lblOrderNumber_DoubleClick(object sender, EventArgs e)
        {
            RzWin.Context.TheLeader.Error("reorg");

            /*

            if (!Rz3App.xUser.CheckPermit("Orders:Numbering:ChangeOrderNumbers", true))
                return;

            String s = RzWin.Leader.AskForString("New order number", CurrentOrder.ordernumber, "New Number", this.ParentForm);
            if( !Tools.Strings.StrExt(s) )
                return;
            CurrentOrder.ordernumber = s;
            CurrentOrder.ISave();
            foreach(System.Collections.Generic.KeyValuePair<String, nObject> d in CurrentOrder.AllDetails)
            {
                orddet x = (orddet)d.Value;
                x.ordernumber = s;
                x.ISave();
            }
            lblOrderNumber.Text = s;
             * 
             * */
        }
        private void lblChangeDate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangeDate();
        }
        private void lblASN_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String x = lblASN.Text;
            String strName = "Advance " + CurrentOrder.OrderType.ToString() + " Shipment Notification";
            emailtemplate t = emailtemplate.GetByName(RzWin.Context, strName);
            if(t == null)
            {
                RzWin.Leader.Tell("Before using this feature, please create an email template named '" + strName + "'");
                return;
            }
            t.SendOrderEmail(RzWin.Context, CurrentOrder, false, "", false, true, false, "", "", "", "", "", true);
        }
        private void BlockAllChanges()
        {
            try
            {
                gbTop.Enabled = false;
                gbTotals.Enabled = false;
                details.AllowAdd = false;
                foreach (TabPage tp in ts.TabPages)
                {
                    if (tp.Name == "tabCreditCard")
                        continue;
                    foreach (Control c in tp.Controls)
                    {
                        c.Enabled = false;
                    }
                }
            }
            catch { }
        }
        private void lvLinkedEmails_DragDrop(object sender, DragEventArgs e)
        {
            String about = "Linking";
            try
            {
                about = "Getting Data Object";
                iwantedue.Windows.Forms.OutlookDataObject dataObject = new iwantedue.Windows.Forms.OutlookDataObject(e.Data);

                about = "Getting File Names";
                string[] filenames = (string[])dataObject.GetData("FileGroupDescriptor");

                about = "Getting File Streams";
                MemoryStream[] filestreams = (MemoryStream[])dataObject.GetData("FileContents");

                for (int fileIndex = 0; fileIndex < filenames.Length; fileIndex++)
                {
                    string filename = Tools.FileSystem.GetAppPath() + filenames[fileIndex];
                    about = "Getting " + filename;
                    MemoryStream filestream = filestreams[fileIndex];

                    about = "Creating the output file";
                    FileStream outputStream = File.Create(filename);
                    filestream.WriteTo(outputStream);
                    outputStream.Close();
                    filelink f = filelink.New(RzWin.Context);
                    f.linkname = Tools.Strings.ParseDelimit(nTools.GetFileName(filename), ".", 1);
                    f.objectclass = "ordhed";
                    f.objectid = CurrentOrder.unique_id;
                    f.linktype = "email";
                    f.Insert(RzWin.Context);
                    f.SetDocDataByFile(filename);
                    f.SavePictureData(RzWin.Context);
                    f.Update(RzWin.Context);
                    File.Delete(filename);
                }
            }
            catch(Exception ex)
            {
                RzWin.Leader.Tell("Error " + about + " : " + ex.Message);
            }
        }
        private void lvLinkedEmails_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void lvLinkedEmails_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void cmdPasteBill_Click(object sender, EventArgs e)
        {
            PasteBillTo();
        }

        private void lblSaveThisOrder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RzWin.Context.TheLeader.Error("reorg");

            /*

            if (!RzWin.Leader.AreYouSure("permanently save this line order"))
                return;

            ArrayList ids = details.GetAllIDs();
            int i = 1;
            foreach (String id in ids)
            {
                try
                {
                    orddet d = (orddet)CurrentOrder.AllDetails[id];
                    if (d != null)
                    {
                        d.linecode = i;
                        d.ISave();
                    }
                }
                catch { }

                i++;
            }

            CurrentOrder.GatherDetails();
            details.CurrentCollection = CurrentOrder.AllDetails;
            details.RefreshFromCollection();
            RzWin.Leader.Tell("Done.");
             * */
        }

        private void ctl_currencyname_Load(object sender, EventArgs e)
        {

        }

    }
}