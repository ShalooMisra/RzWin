using NewMethod;
using Tools.Database;

namespace Rz5
{
    partial class view_ordhed
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                CompleteDispose();
                components.Dispose();
            }

            try
            {
                CurrentOrder = null;
                //RzWin.Context.xSys.UnRegisterNotifyClass(this);
            }
            catch (System.Exception) { }

            try
            {
                base.Dispose(disposing);
            }
            catch (System.Exception)
            { }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(view_ordhed));
            this.gbTop = new System.Windows.Forms.GroupBox();
            this.ctl_certs_required = new NewMethod.nEdit_Boolean();
            this.ctl_credit_check_approved = new NewMethod.nEdit_Boolean();
            this.cmdCreditApproval = new System.Windows.Forms.Button();
            this.lblSetForStock = new System.Windows.Forms.LinkLabel();
            this.ctl_for_stock = new NewMethod.nEdit_Boolean();
            this.ctl_is_government = new NewMethod.nEdit_Boolean();
            this.ctl_is_confirmed = new NewMethod.nEdit_Boolean();
            this.lblAuthorized = new System.Windows.Forms.Label();
            this.ctl_c_of_c = new NewMethod.nEdit_Boolean();
            this.ctl_isvoid = new NewMethod.nEdit_Boolean();
            this.ctl_isclosed = new NewMethod.nEdit_Boolean();
            this.ctl_senttoqb = new NewMethod.nEdit_Boolean();
            this.ctl_isverified = new NewMethod.nEdit_Boolean();
            this.ctl_onhold = new NewMethod.nEdit_Boolean();
            this.lblOrderType = new System.Windows.Forms.Label();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.ctl_credit_approve_agent = new NewMethod.Views.Edits.nEdit_Label();
            this.ts = new System.Windows.Forms.TabControl();
            this.pageCompany = new System.Windows.Forms.TabPage();
            this.buyer = new NewMethod.nEdit_User();
            this.ctl_orderreference = new NewMethod.nEdit_String();
            this.chkAutomaticASN = new System.Windows.Forms.CheckBox();
            this.lblChangeDate = new System.Windows.Forms.LinkLabel();
            this.lblVoid = new System.Windows.Forms.Label();
            this.nlblordertime = new NewMethod.Views.Edits.nEdit_Label();
            this.nlblorderdate = new NewMethod.Views.Edits.nEdit_Label();
            this.cboReference = new System.Windows.Forms.ComboBox();
            this.cmdRefreshCompanyInfo = new System.Windows.Forms.Button();
            this.cmdUpdateCompanyInfo = new System.Windows.Forms.Button();
            this.ctl_shipvia = new NewMethod.nEdit_List();
            this.ctl_terms = new NewMethod.nEdit_List();
            this.ctl_soreference = new NewMethod.nEdit_String();
            this.ctl_dockdate = new NewMethod.nEdit_Date();
            this.ctl_requireddate = new NewMethod.nEdit_Date();
            this.ctl_primaryphone = new NewMethod.nEdit_String();
            this.ctl_primaryfax = new NewMethod.nEdit_String();
            this.ctl_primaryemailaddress = new NewMethod.nEdit_String();
            this.agent = new NewMethod.nEdit_User();
            this.cStub = new Rz5.CompanyStub_PlusContact();
            this.ctl_followup_date = new NewMethod.nEdit_Date();
            this.pageAddress = new System.Windows.Forms.TabPage();
            this.lblASN = new System.Windows.Forms.LinkLabel();
            this.ctl_trackingnumber = new NewMethod.nEdit_Memo();
            this.cmdPasteBill = new System.Windows.Forms.Button();
            this.ctl_orderfob = new NewMethod.nEdit_List();
            this.cmdSwitchAddress = new System.Windows.Forms.Button();
            this.lblAddNewShiping = new System.Windows.Forms.LinkLabel();
            this.lblAddNewBilling = new System.Windows.Forms.LinkLabel();
            this.cmdShipBill = new System.Windows.Forms.Button();
            this.cmdBillShip = new System.Windows.Forms.Button();
            this.ctl_shippingaddress = new NewMethod.nEdit_Memo();
            this.ctl_billingaddress = new NewMethod.nEdit_Memo();
            this.cboBillingAddress = new NewMethod.nEdit_List();
            this.cboShippingAddress = new NewMethod.nEdit_List();
            this.ctl_shippingname = new NewMethod.nEdit_String();
            this.ctl_billingname = new NewMethod.nEdit_String();
            this.ctl_packinginfo = new NewMethod.nEdit_List();
            this.ctl_shippingaccount = new NewMethod.nEdit_List();
            this.ctl_freightbilling = new NewMethod.nEdit_List();
            this.pageNotes = new System.Windows.Forms.TabPage();
            this.cmdNTCUpdate = new System.Windows.Forms.Button();
            this.ctl_qualitycontrol = new NewMethod.nEdit_String();
            this.gbNotes_Sales = new System.Windows.Forms.GroupBox();
            this.ctl_showonwarehouse = new NewMethod.nEdit_Boolean();
            this.ctl_isflipdeal = new NewMethod.nEdit_Boolean();
            this.ctl_isproforma = new NewMethod.nEdit_Boolean();
            this.ctl_has_issue = new NewMethod.nEdit_Boolean();
            this.ctl_advanced_payment_made = new NewMethod.nEdit_Boolean();
            this.ctl_printcomment = new NewMethod.nEdit_Memo();
            this.ctl_internalcomment = new NewMethod.nEdit_Memo();
            this.cboCards = new NewMethod.nEdit_List();
            this.pageStatus = new System.Windows.Forms.TabPage();
            this.gbRMA = new System.Windows.Forms.GroupBox();
            this.cmdVendorRMA = new System.Windows.Forms.Button();
            this.gbGo = new System.Windows.Forms.GroupBox();
            this.optDiscard = new System.Windows.Forms.RadioButton();
            this.optKeep = new System.Windows.Forms.RadioButton();
            this.optReturn = new System.Windows.Forms.RadioButton();
            this.gbStatus = new System.Windows.Forms.GroupBox();
            this.optNoReturn = new System.Windows.Forms.RadioButton();
            this.optWarehouse = new System.Windows.Forms.RadioButton();
            this.optShip = new System.Windows.Forms.RadioButton();
            this.gbVendor = new System.Windows.Forms.GroupBox();
            this.optNoVendor = new System.Windows.Forms.RadioButton();
            this.optYesVendor = new System.Windows.Forms.RadioButton();
            this.cboVendReimburse = new NewMethod.nEdit_List();
            this.gbCustomer = new System.Windows.Forms.GroupBox();
            this.optNoCustomer = new System.Windows.Forms.RadioButton();
            this.optYesCustomer = new System.Windows.Forms.RadioButton();
            this.cboReimburse = new NewMethod.nEdit_List();
            this.cboWhy = new NewMethod.nEdit_List();
            this.pageNotify = new System.Windows.Forms.TabPage();
            this.chkNotifyReceive = new System.Windows.Forms.CheckBox();
            this.chkNotifyShip = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkConfirmReceive = new System.Windows.Forms.CheckBox();
            this.chkConfirmShip = new System.Windows.Forms.CheckBox();
            this.lblConfirmations = new System.Windows.Forms.Label();
            this.pagePictures = new System.Windows.Forms.TabPage();
            this.picview = new Rz5.PartPictureViewer();
            this.pageAuthorize = new System.Windows.Forms.TabPage();
            this.cmdAuthorize = new System.Windows.Forms.Button();
            this.ctl_authorized_number = new NewMethod.nEdit_Number();
            this.ctl_authorized_date = new NewMethod.nEdit_Date();
            this.ctl_is_authorized = new NewMethod.nEdit_Boolean();
            this.pageDeductions = new System.Windows.Forms.TabPage();
            this.lstHits = new NewMethod.nList();
            this.pageEmails = new System.Windows.Forms.TabPage();
            this.lvLinkedEmails = new NewMethod.nList();
            this.tabCreditCard = new System.Windows.Forms.TabPage();
            this.ctl_securitycode = new NewMethod.nEdit_String();
            this.cmdGrabCreditCardInfo = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdUpdateCustCreditCardInfo = new System.Windows.Forms.Button();
            this.ctl_nameoncard = new NewMethod.nEdit_String();
            this.ctl_cardbillingzip = new NewMethod.nEdit_String();
            this.ctl_cardbillingaddr = new NewMethod.nEdit_String();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ctl_expiration_year = new NewMethod.nEdit_Number();
            this.ctl_expiration_month = new NewMethod.nEdit_Number();
            this.ctl_creditcardtype = new NewMethod.nEdit_List();
            this.ctl_creditcardnumber = new NewMethod.nEdit_String();
            this.tabProcurement = new System.Windows.Forms.TabPage();
            this.lvProcurement = new NewMethod.nList();
            this.gbTotals = new System.Windows.Forms.GroupBox();
            this.ctl_invoice_number = new NewMethod.nEdit_String();
            this.lblTotal = new System.Windows.Forms.Label();
            this.ctl_taxamount = new NewMethod.nEdit_Money();
            this.ctl_handlingamount = new NewMethod.nEdit_Money();
            this.ctl_shippingamount = new NewMethod.nEdit_Money();
            this.ctl_charged_amount = new NewMethod.nEdit_Money();
            this.ctl_invoice_date = new NewMethod.nEdit_Date();
            this.lblPaid = new System.Windows.Forms.Label();
            this.lblOutstanding = new System.Windows.Forms.Label();
            this.lblPaidAmount = new System.Windows.Forms.Label();
            this.ctl_subtract_3 = new NewMethod.nEdit_Money();
            this.ctl_subtract_2 = new NewMethod.nEdit_Money();
            this.ctl_subtract_1 = new NewMethod.nEdit_Money();
            this.optOther = new System.Windows.Forms.RadioButton();
            this.optFees = new System.Windows.Forms.RadioButton();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.details = new NewMethod.nList();
            this.dv = new NewMethod.nDataView();
            this.oFile = new System.Windows.Forms.OpenFileDialog();
            this.lblSaveThisOrder = new System.Windows.Forms.LinkLabel();
            this.gbTop.SuspendLayout();
            this.ts.SuspendLayout();
            this.pageCompany.SuspendLayout();
            this.pageAddress.SuspendLayout();
            this.pageNotes.SuspendLayout();
            this.gbNotes_Sales.SuspendLayout();
            this.pageStatus.SuspendLayout();
            this.gbRMA.SuspendLayout();
            this.gbGo.SuspendLayout();
            this.gbStatus.SuspendLayout();
            this.gbVendor.SuspendLayout();
            this.gbCustomer.SuspendLayout();
            this.pageNotify.SuspendLayout();
            this.pagePictures.SuspendLayout();
            this.pageAuthorize.SuspendLayout();
            this.pageDeductions.SuspendLayout();
            this.pageEmails.SuspendLayout();
            this.tabCreditCard.SuspendLayout();
            this.tabProcurement.SuspendLayout();
            this.gbTotals.SuspendLayout();
            this.SuspendLayout();
            // 
            // xActions
            // 
            this.xActions.Location = new System.Drawing.Point(1393, 0);
            this.xActions.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.xActions.Size = new System.Drawing.Size(148, 807);
            // 
            // gbTop
            // 
            this.gbTop.BackColor = System.Drawing.Color.White;
            this.gbTop.Controls.Add(this.ctl_certs_required);
            this.gbTop.Controls.Add(this.ctl_credit_check_approved);
            this.gbTop.Controls.Add(this.cmdCreditApproval);
            this.gbTop.Controls.Add(this.lblSetForStock);
            this.gbTop.Controls.Add(this.ctl_for_stock);
            this.gbTop.Controls.Add(this.ctl_is_government);
            this.gbTop.Controls.Add(this.ctl_is_confirmed);
            this.gbTop.Controls.Add(this.lblAuthorized);
            this.gbTop.Controls.Add(this.ctl_c_of_c);
            this.gbTop.Controls.Add(this.ctl_isvoid);
            this.gbTop.Controls.Add(this.ctl_isclosed);
            this.gbTop.Controls.Add(this.ctl_senttoqb);
            this.gbTop.Controls.Add(this.ctl_isverified);
            this.gbTop.Controls.Add(this.ctl_onhold);
            this.gbTop.Controls.Add(this.lblOrderType);
            this.gbTop.Controls.Add(this.lblOrderNumber);
            this.gbTop.Controls.Add(this.ctl_credit_approve_agent);
            this.gbTop.Location = new System.Drawing.Point(4, 33);
            this.gbTop.Margin = new System.Windows.Forms.Padding(4);
            this.gbTop.Name = "gbTop";
            this.gbTop.Padding = new System.Windows.Forms.Padding(4);
            this.gbTop.Size = new System.Drawing.Size(772, 91);
            this.gbTop.TabIndex = 6;
            this.gbTop.TabStop = false;
            // 
            // ctl_certs_required
            // 
            this.ctl_certs_required.BackColor = System.Drawing.Color.White;
            this.ctl_certs_required.Bold = false;
            this.ctl_certs_required.Caption = "Certs Req.";
            this.ctl_certs_required.Changed = false;
            this.ctl_certs_required.Location = new System.Drawing.Point(669, 36);
            this.ctl_certs_required.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_certs_required.Name = "ctl_certs_required";
            this.ctl_certs_required.Size = new System.Drawing.Size(76, 18);
            this.ctl_certs_required.TabIndex = 32;
            this.ctl_certs_required.TabStop = false;
            this.ctl_certs_required.UseParentBackColor = true;
            this.ctl_certs_required.zz_CheckValue = false;
            this.ctl_certs_required.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_certs_required.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_certs_required.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_certs_required.zz_OriginalDesign = false;
            this.ctl_certs_required.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_credit_check_approved
            // 
            this.ctl_credit_check_approved.BackColor = System.Drawing.Color.White;
            this.ctl_credit_check_approved.Bold = false;
            this.ctl_credit_check_approved.Caption = "Credit Check Approved";
            this.ctl_credit_check_approved.Changed = false;
            this.ctl_credit_check_approved.Enabled = false;
            this.ctl_credit_check_approved.Location = new System.Drawing.Point(453, 65);
            this.ctl_credit_check_approved.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_credit_check_approved.Name = "ctl_credit_check_approved";
            this.ctl_credit_check_approved.Size = new System.Drawing.Size(130, 13);
            this.ctl_credit_check_approved.TabIndex = 31;
            this.ctl_credit_check_approved.UseParentBackColor = false;
            this.ctl_credit_check_approved.Visible = false;
            this.ctl_credit_check_approved.zz_CheckValue = false;
            this.ctl_credit_check_approved.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_credit_check_approved.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_credit_check_approved.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_credit_check_approved.zz_OriginalDesign = false;
            this.ctl_credit_check_approved.zz_ShowNeedsSaveColor = false;
            // 
            // cmdCreditApproval
            // 
            this.cmdCreditApproval.Location = new System.Drawing.Point(0, 0);
            this.cmdCreditApproval.Margin = new System.Windows.Forms.Padding(4);
            this.cmdCreditApproval.Name = "cmdCreditApproval";
            this.cmdCreditApproval.Size = new System.Drawing.Size(100, 28);
            this.cmdCreditApproval.TabIndex = 33;
            // 
            // lblSetForStock
            // 
            this.lblSetForStock.AutoSize = true;
            this.lblSetForStock.Location = new System.Drawing.Point(693, 15);
            this.lblSetForStock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSetForStock.Name = "lblSetForStock";
            this.lblSetForStock.Size = new System.Drawing.Size(53, 13);
            this.lblSetForStock.TabIndex = 29;
            this.lblSetForStock.TabStop = true;
            this.lblSetForStock.Text = "For Stock";
            this.lblSetForStock.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSetForStock_LinkClicked);
            // 
            // ctl_for_stock
            // 
            this.ctl_for_stock.BackColor = System.Drawing.Color.White;
            this.ctl_for_stock.Bold = false;
            this.ctl_for_stock.Caption = "";
            this.ctl_for_stock.Changed = false;
            this.ctl_for_stock.Location = new System.Drawing.Point(669, 11);
            this.ctl_for_stock.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_for_stock.Name = "ctl_for_stock";
            this.ctl_for_stock.Size = new System.Drawing.Size(19, 18);
            this.ctl_for_stock.TabIndex = 28;
            this.ctl_for_stock.TabStop = false;
            this.ctl_for_stock.UseParentBackColor = true;
            this.ctl_for_stock.zz_CheckValue = false;
            this.ctl_for_stock.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_for_stock.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_for_stock.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_for_stock.zz_OriginalDesign = false;
            this.ctl_for_stock.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_is_government
            // 
            this.ctl_is_government.BackColor = System.Drawing.Color.White;
            this.ctl_is_government.Bold = false;
            this.ctl_is_government.Caption = "Govt";
            this.ctl_is_government.Changed = false;
            this.ctl_is_government.Location = new System.Drawing.Point(333, 38);
            this.ctl_is_government.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_is_government.Name = "ctl_is_government";
            this.ctl_is_government.Size = new System.Drawing.Size(49, 18);
            this.ctl_is_government.TabIndex = 25;
            this.ctl_is_government.TabStop = false;
            this.ctl_is_government.UseParentBackColor = true;
            this.ctl_is_government.zz_CheckValue = false;
            this.ctl_is_government.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_is_government.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_is_government.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_is_government.zz_OriginalDesign = false;
            this.ctl_is_government.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_is_confirmed
            // 
            this.ctl_is_confirmed.BackColor = System.Drawing.Color.White;
            this.ctl_is_confirmed.Bold = false;
            this.ctl_is_confirmed.Caption = "Is Conf";
            this.ctl_is_confirmed.Changed = false;
            this.ctl_is_confirmed.Location = new System.Drawing.Point(589, 11);
            this.ctl_is_confirmed.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_is_confirmed.Name = "ctl_is_confirmed";
            this.ctl_is_confirmed.Size = new System.Drawing.Size(59, 18);
            this.ctl_is_confirmed.TabIndex = 24;
            this.ctl_is_confirmed.TabStop = false;
            this.ctl_is_confirmed.UseParentBackColor = true;
            this.ctl_is_confirmed.zz_CheckValue = false;
            this.ctl_is_confirmed.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_is_confirmed.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_is_confirmed.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_is_confirmed.zz_OriginalDesign = false;
            this.ctl_is_confirmed.zz_ShowNeedsSaveColor = true;
            // 
            // lblAuthorized
            // 
            this.lblAuthorized.AutoSize = true;
            this.lblAuthorized.ForeColor = System.Drawing.Color.Red;
            this.lblAuthorized.Location = new System.Drawing.Point(11, 14);
            this.lblAuthorized.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAuthorized.Name = "lblAuthorized";
            this.lblAuthorized.Size = new System.Drawing.Size(68, 13);
            this.lblAuthorized.TabIndex = 23;
            this.lblAuthorized.Text = "<authorized>";
            // 
            // ctl_c_of_c
            // 
            this.ctl_c_of_c.BackColor = System.Drawing.Color.Transparent;
            this.ctl_c_of_c.Bold = false;
            this.ctl_c_of_c.Caption = "C of C";
            this.ctl_c_of_c.Changed = false;
            this.ctl_c_of_c.Location = new System.Drawing.Point(589, 34);
            this.ctl_c_of_c.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_c_of_c.Name = "ctl_c_of_c";
            this.ctl_c_of_c.Size = new System.Drawing.Size(55, 18);
            this.ctl_c_of_c.TabIndex = 22;
            this.ctl_c_of_c.TabStop = false;
            this.ctl_c_of_c.UseParentBackColor = true;
            this.ctl_c_of_c.zz_CheckValue = false;
            this.ctl_c_of_c.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_c_of_c.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_c_of_c.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_c_of_c.zz_OriginalDesign = false;
            this.ctl_c_of_c.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_isvoid
            // 
            this.ctl_isvoid.BackColor = System.Drawing.Color.White;
            this.ctl_isvoid.Bold = false;
            this.ctl_isvoid.Caption = "Void";
            this.ctl_isvoid.Changed = false;
            this.ctl_isvoid.Location = new System.Drawing.Point(500, 36);
            this.ctl_isvoid.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_isvoid.Name = "ctl_isvoid";
            this.ctl_isvoid.Size = new System.Drawing.Size(47, 18);
            this.ctl_isvoid.TabIndex = 7;
            this.ctl_isvoid.TabStop = false;
            this.ctl_isvoid.UseParentBackColor = true;
            this.ctl_isvoid.zz_CheckValue = false;
            this.ctl_isvoid.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_isvoid.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_isvoid.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_isvoid.zz_OriginalDesign = false;
            this.ctl_isvoid.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_isclosed
            // 
            this.ctl_isclosed.BackColor = System.Drawing.Color.White;
            this.ctl_isclosed.Bold = false;
            this.ctl_isclosed.Caption = "Closed";
            this.ctl_isclosed.Changed = false;
            this.ctl_isclosed.Location = new System.Drawing.Point(500, 12);
            this.ctl_isclosed.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_isclosed.Name = "ctl_isclosed";
            this.ctl_isclosed.Size = new System.Drawing.Size(58, 18);
            this.ctl_isclosed.TabIndex = 6;
            this.ctl_isclosed.TabStop = false;
            this.ctl_isclosed.UseParentBackColor = true;
            this.ctl_isclosed.zz_CheckValue = false;
            this.ctl_isclosed.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_isclosed.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_isclosed.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_isclosed.zz_OriginalDesign = false;
            this.ctl_isclosed.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_senttoqb
            // 
            this.ctl_senttoqb.BackColor = System.Drawing.Color.White;
            this.ctl_senttoqb.Bold = false;
            this.ctl_senttoqb.Caption = "QB";
            this.ctl_senttoqb.Changed = false;
            this.ctl_senttoqb.Location = new System.Drawing.Point(413, 38);
            this.ctl_senttoqb.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_senttoqb.Name = "ctl_senttoqb";
            this.ctl_senttoqb.Size = new System.Drawing.Size(41, 18);
            this.ctl_senttoqb.TabIndex = 5;
            this.ctl_senttoqb.TabStop = false;
            this.ctl_senttoqb.UseParentBackColor = true;
            this.ctl_senttoqb.zz_CheckValue = false;
            this.ctl_senttoqb.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_senttoqb.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_senttoqb.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_senttoqb.zz_OriginalDesign = false;
            this.ctl_senttoqb.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_isverified
            // 
            this.ctl_isverified.BackColor = System.Drawing.Color.White;
            this.ctl_isverified.Bold = false;
            this.ctl_isverified.Caption = "Verified";
            this.ctl_isverified.Changed = false;
            this.ctl_isverified.Location = new System.Drawing.Point(413, 12);
            this.ctl_isverified.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_isverified.Name = "ctl_isverified";
            this.ctl_isverified.Size = new System.Drawing.Size(61, 18);
            this.ctl_isverified.TabIndex = 4;
            this.ctl_isverified.TabStop = false;
            this.ctl_isverified.UseParentBackColor = true;
            this.ctl_isverified.zz_CheckValue = false;
            this.ctl_isverified.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_isverified.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_isverified.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_isverified.zz_OriginalDesign = false;
            this.ctl_isverified.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_onhold
            // 
            this.ctl_onhold.BackColor = System.Drawing.Color.White;
            this.ctl_onhold.Bold = false;
            this.ctl_onhold.Caption = "Hold";
            this.ctl_onhold.Changed = false;
            this.ctl_onhold.Location = new System.Drawing.Point(333, 12);
            this.ctl_onhold.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_onhold.Name = "ctl_onhold";
            this.ctl_onhold.Size = new System.Drawing.Size(48, 18);
            this.ctl_onhold.TabIndex = 3;
            this.ctl_onhold.TabStop = false;
            this.ctl_onhold.UseParentBackColor = true;
            this.ctl_onhold.zz_CheckValue = false;
            this.ctl_onhold.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_onhold.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_onhold.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_onhold.zz_OriginalDesign = false;
            this.ctl_onhold.zz_ShowNeedsSaveColor = true;
            this.ctl_onhold.CheckChanged += new NewMethod.CheckChangedHandler(this.ctl_onhold_CheckChanged);
            // 
            // lblOrderType
            // 
            this.lblOrderType.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderType.Location = new System.Drawing.Point(8, 27);
            this.lblOrderType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrderType.Name = "lblOrderType";
            this.lblOrderType.Size = new System.Drawing.Size(317, 27);
            this.lblOrderType.TabIndex = 1;
            this.lblOrderType.Text = "<order type>";
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderNumber.Location = new System.Drawing.Point(8, 57);
            this.lblOrderNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(317, 27);
            this.lblOrderNumber.TabIndex = 0;
            this.lblOrderNumber.Text = "<order number>";
            this.lblOrderNumber.DoubleClick += new System.EventHandler(this.lblOrderNumber_DoubleClick);
            // 
            // ctl_credit_approve_agent
            // 
            this.ctl_credit_approve_agent.BackColor = System.Drawing.Color.Transparent;
            this.ctl_credit_approve_agent.Bold = false;
            this.ctl_credit_approve_agent.Caption = "";
            this.ctl_credit_approve_agent.Changed = false;
            this.ctl_credit_approve_agent.Location = new System.Drawing.Point(521, 62);
            this.ctl_credit_approve_agent.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_credit_approve_agent.Name = "ctl_credit_approve_agent";
            this.ctl_credit_approve_agent.Size = new System.Drawing.Size(244, 20);
            this.ctl_credit_approve_agent.TabIndex = 30;
            this.ctl_credit_approve_agent.UseParentBackColor = false;
            this.ctl_credit_approve_agent.Visible = false;
            this.ctl_credit_approve_agent.zz_CaptionLabelBackColor = System.Drawing.Color.Transparent;
            this.ctl_credit_approve_agent.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_credit_approve_agent.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_credit_approve_agent.zz_LabelColor = System.Drawing.Color.Navy;
            this.ctl_credit_approve_agent.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_credit_approve_agent.zz_LabelLocation = NewMethod.Views.Edits.nEdit_Label.LabelLocations.TopLeft;
            this.ctl_credit_approve_agent.zz_OriginalDesign = false;
            this.ctl_credit_approve_agent.zz_Text = "<>";
            this.ctl_credit_approve_agent.zz_TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctl_credit_approve_agent.zz_TextColor = System.Drawing.SystemColors.ControlText;
            this.ctl_credit_approve_agent.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_credit_approve_agent.zz_UseGlobalColor = false;
            this.ctl_credit_approve_agent.zz_UseGlobalFont = false;
            this.ctl_credit_approve_agent.zz_ValueLabelBackColor = System.Drawing.Color.Transparent;
            // 
            // ts
            // 
            this.ts.Controls.Add(this.pageCompany);
            this.ts.Controls.Add(this.pageAddress);
            this.ts.Controls.Add(this.pageNotes);
            this.ts.Controls.Add(this.pageStatus);
            this.ts.Controls.Add(this.pageNotify);
            this.ts.Controls.Add(this.pagePictures);
            this.ts.Controls.Add(this.pageAuthorize);
            this.ts.Controls.Add(this.pageDeductions);
            this.ts.Controls.Add(this.pageEmails);
            this.ts.Controls.Add(this.tabCreditCard);
            this.ts.Controls.Add(this.tabProcurement);
            this.ts.Location = new System.Drawing.Point(11, 132);
            this.ts.Margin = new System.Windows.Forms.Padding(4);
            this.ts.Name = "ts";
            this.ts.SelectedIndex = 0;
            this.ts.Size = new System.Drawing.Size(1163, 353);
            this.ts.TabIndex = 7;
            this.ts.SelectedIndexChanged += new System.EventHandler(this.ts_SelectedIndexChanged);
            // 
            // pageCompany
            // 
            this.pageCompany.Controls.Add(this.buyer);
            this.pageCompany.Controls.Add(this.ctl_orderreference);
            this.pageCompany.Controls.Add(this.chkAutomaticASN);
            this.pageCompany.Controls.Add(this.lblChangeDate);
            this.pageCompany.Controls.Add(this.lblVoid);
            this.pageCompany.Controls.Add(this.nlblordertime);
            this.pageCompany.Controls.Add(this.nlblorderdate);
            this.pageCompany.Controls.Add(this.cboReference);
            this.pageCompany.Controls.Add(this.cmdRefreshCompanyInfo);
            this.pageCompany.Controls.Add(this.cmdUpdateCompanyInfo);
            this.pageCompany.Controls.Add(this.ctl_shipvia);
            this.pageCompany.Controls.Add(this.ctl_terms);
            this.pageCompany.Controls.Add(this.ctl_soreference);
            this.pageCompany.Controls.Add(this.ctl_dockdate);
            this.pageCompany.Controls.Add(this.ctl_requireddate);
            this.pageCompany.Controls.Add(this.ctl_primaryphone);
            this.pageCompany.Controls.Add(this.ctl_primaryfax);
            this.pageCompany.Controls.Add(this.ctl_primaryemailaddress);
            this.pageCompany.Controls.Add(this.agent);
            this.pageCompany.Controls.Add(this.cStub);
            this.pageCompany.Controls.Add(this.ctl_followup_date);
            this.pageCompany.Location = new System.Drawing.Point(4, 22);
            this.pageCompany.Margin = new System.Windows.Forms.Padding(4);
            this.pageCompany.Name = "pageCompany";
            this.pageCompany.Padding = new System.Windows.Forms.Padding(4);
            this.pageCompany.Size = new System.Drawing.Size(1155, 327);
            this.pageCompany.TabIndex = 0;
            this.pageCompany.Text = "Company";
            this.pageCompany.UseVisualStyleBackColor = true;
            // 
            // buyer
            // 
            this.buyer.AllowChange = true;
            this.buyer.AllowClear = false;
            this.buyer.AllowNew = false;
            this.buyer.AllowView = false;
            this.buyer.BackColor = System.Drawing.Color.Transparent;
            this.buyer.Bold = false;
            this.buyer.Caption = "Buyer";
            this.buyer.Changed = false;
            this.buyer.Location = new System.Drawing.Point(531, 69);
            this.buyer.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.buyer.Name = "buyer";
            this.buyer.Size = new System.Drawing.Size(291, 68);
            this.buyer.TabIndex = 13;
            this.buyer.UseParentBackColor = true;
            this.buyer.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.buyer.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            // 
            // ctl_orderreference
            // 
            this.ctl_orderreference.AllCaps = false;
            this.ctl_orderreference.BackColor = System.Drawing.Color.Transparent;
            this.ctl_orderreference.Bold = false;
            this.ctl_orderreference.Caption = "PO Reference";
            this.ctl_orderreference.Changed = false;
            this.ctl_orderreference.IsEmail = false;
            this.ctl_orderreference.IsURL = false;
            this.ctl_orderreference.Location = new System.Drawing.Point(9, 265);
            this.ctl_orderreference.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_orderreference.Name = "ctl_orderreference";
            this.ctl_orderreference.PasswordChar = '\0';
            this.ctl_orderreference.Size = new System.Drawing.Size(137, 57);
            this.ctl_orderreference.TabIndex = 6;
            this.ctl_orderreference.UseParentBackColor = true;
            this.ctl_orderreference.zz_Enabled = true;
            this.ctl_orderreference.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_orderreference.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_orderreference.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_orderreference.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_orderreference.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_orderreference.zz_OriginalDesign = true;
            this.ctl_orderreference.zz_ShowLinkButton = false;
            this.ctl_orderreference.zz_ShowNeedsSaveColor = true;
            this.ctl_orderreference.zz_Text = "";
            this.ctl_orderreference.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_orderreference.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_orderreference.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_orderreference.zz_UseGlobalColor = false;
            this.ctl_orderreference.zz_UseGlobalFont = false;
            // 
            // chkAutomaticASN
            // 
            this.chkAutomaticASN.AutoSize = true;
            this.chkAutomaticASN.Location = new System.Drawing.Point(769, 23);
            this.chkAutomaticASN.Margin = new System.Windows.Forms.Padding(4);
            this.chkAutomaticASN.Name = "chkAutomaticASN";
            this.chkAutomaticASN.Size = new System.Drawing.Size(126, 17);
            this.chkAutomaticASN.TabIndex = 25;
            this.chkAutomaticASN.Text = "Send Automatic ASN";
            this.chkAutomaticASN.UseVisualStyleBackColor = true;
            // 
            // lblChangeDate
            // 
            this.lblChangeDate.AutoSize = true;
            this.lblChangeDate.Location = new System.Drawing.Point(387, 78);
            this.lblChangeDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChangeDate.Name = "lblChangeDate";
            this.lblChangeDate.Size = new System.Drawing.Size(67, 13);
            this.lblChangeDate.TabIndex = 23;
            this.lblChangeDate.TabStop = true;
            this.lblChangeDate.Text = "change date";
            this.lblChangeDate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblChangeDate_LinkClicked);
            // 
            // lblVoid
            // 
            this.lblVoid.AutoSize = true;
            this.lblVoid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblVoid.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoid.ForeColor = System.Drawing.Color.Red;
            this.lblVoid.Location = new System.Drawing.Point(373, 97);
            this.lblVoid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVoid.Name = "lblVoid";
            this.lblVoid.Size = new System.Drawing.Size(88, 32);
            this.lblVoid.TabIndex = 20;
            this.lblVoid.Text = "VOID";
            this.lblVoid.Visible = false;
            // 
            // nlblordertime
            // 
            this.nlblordertime.AutoScroll = true;
            this.nlblordertime.BackColor = System.Drawing.Color.Transparent;
            this.nlblordertime.Bold = false;
            this.nlblordertime.Caption = "";
            this.nlblordertime.Changed = false;
            this.nlblordertime.Location = new System.Drawing.Point(368, 52);
            this.nlblordertime.Margin = new System.Windows.Forms.Padding(5);
            this.nlblordertime.Name = "nlblordertime";
            this.nlblordertime.Size = new System.Drawing.Size(128, 20);
            this.nlblordertime.TabIndex = 19;
            this.nlblordertime.UseParentBackColor = false;
            this.nlblordertime.zz_CaptionLabelBackColor = System.Drawing.Color.Transparent;
            this.nlblordertime.zz_GlobalColor = System.Drawing.Color.Black;
            this.nlblordertime.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nlblordertime.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.nlblordertime.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nlblordertime.zz_LabelLocation = NewMethod.Views.Edits.nEdit_Label.LabelLocations.TopCenter;
            this.nlblordertime.zz_OriginalDesign = false;
            this.nlblordertime.zz_Text = "00:00:00 PM";
            this.nlblordertime.zz_TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.nlblordertime.zz_TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.nlblordertime.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nlblordertime.zz_UseGlobalColor = false;
            this.nlblordertime.zz_UseGlobalFont = false;
            this.nlblordertime.zz_ValueLabelBackColor = System.Drawing.Color.Transparent;
            // 
            // nlblorderdate
            // 
            this.nlblorderdate.BackColor = System.Drawing.Color.Transparent;
            this.nlblorderdate.Bold = false;
            this.nlblorderdate.Caption = "Order Date";
            this.nlblorderdate.Changed = false;
            this.nlblorderdate.Location = new System.Drawing.Point(367, 6);
            this.nlblorderdate.Margin = new System.Windows.Forms.Padding(5);
            this.nlblorderdate.Name = "nlblorderdate";
            this.nlblorderdate.Size = new System.Drawing.Size(163, 40);
            this.nlblorderdate.TabIndex = 18;
            this.nlblorderdate.UseParentBackColor = false;
            this.nlblorderdate.zz_CaptionLabelBackColor = System.Drawing.Color.Transparent;
            this.nlblorderdate.zz_GlobalColor = System.Drawing.Color.Black;
            this.nlblorderdate.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nlblorderdate.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.nlblorderdate.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nlblorderdate.zz_LabelLocation = NewMethod.Views.Edits.nEdit_Label.LabelLocations.TopCenter;
            this.nlblorderdate.zz_OriginalDesign = false;
            this.nlblorderdate.zz_Text = "00/00/0000";
            this.nlblorderdate.zz_TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.nlblorderdate.zz_TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.nlblorderdate.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nlblorderdate.zz_UseGlobalColor = false;
            this.nlblorderdate.zz_UseGlobalFont = false;
            this.nlblorderdate.zz_ValueLabelBackColor = System.Drawing.Color.Transparent;
            // 
            // cboReference
            // 
            this.cboReference.FormattingEnabled = true;
            this.cboReference.Location = new System.Drawing.Point(9, 287);
            this.cboReference.Margin = new System.Windows.Forms.Padding(4);
            this.cboReference.Name = "cboReference";
            this.cboReference.Size = new System.Drawing.Size(136, 21);
            this.cboReference.TabIndex = 17;
            this.cboReference.Visible = false;
            this.cboReference.SelectedIndexChanged += new System.EventHandler(this.cboReference_SelectedIndexChanged);
            this.cboReference.TextChanged += new System.EventHandler(this.cboReference_TextChanged);
            // 
            // cmdRefreshCompanyInfo
            // 
            this.cmdRefreshCompanyInfo.Location = new System.Drawing.Point(116, 159);
            this.cmdRefreshCompanyInfo.Margin = new System.Windows.Forms.Padding(4);
            this.cmdRefreshCompanyInfo.Name = "cmdRefreshCompanyInfo";
            this.cmdRefreshCompanyInfo.Size = new System.Drawing.Size(185, 26);
            this.cmdRefreshCompanyInfo.TabIndex = 16;
            this.cmdRefreshCompanyInfo.Text = "Refresh Company Info";
            this.cmdRefreshCompanyInfo.UseVisualStyleBackColor = true;
            this.cmdRefreshCompanyInfo.Click += new System.EventHandler(this.cmdRefreshCompanyInfo_Click);
            // 
            // cmdUpdateCompanyInfo
            // 
            this.cmdUpdateCompanyInfo.Location = new System.Drawing.Point(116, 210);
            this.cmdUpdateCompanyInfo.Margin = new System.Windows.Forms.Padding(4);
            this.cmdUpdateCompanyInfo.Name = "cmdUpdateCompanyInfo";
            this.cmdUpdateCompanyInfo.Size = new System.Drawing.Size(185, 26);
            this.cmdUpdateCompanyInfo.TabIndex = 15;
            this.cmdUpdateCompanyInfo.Text = "Update Company Info";
            this.cmdUpdateCompanyInfo.UseVisualStyleBackColor = true;
            this.cmdUpdateCompanyInfo.Click += new System.EventHandler(this.cmdUpdateCompanyInfo_Click);
            // 
            // ctl_shipvia
            // 
            this.ctl_shipvia.AllCaps = false;
            this.ctl_shipvia.AllowEdit = false;
            this.ctl_shipvia.BackColor = System.Drawing.Color.Transparent;
            this.ctl_shipvia.Bold = false;
            this.ctl_shipvia.Caption = "Ship Via";
            this.ctl_shipvia.Changed = false;
            this.ctl_shipvia.ListName = "shipvia";
            this.ctl_shipvia.Location = new System.Drawing.Point(459, 271);
            this.ctl_shipvia.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_shipvia.Name = "ctl_shipvia";
            this.ctl_shipvia.SimpleList = null;
            this.ctl_shipvia.Size = new System.Drawing.Size(293, 36);
            this.ctl_shipvia.TabIndex = 10;
            this.ctl_shipvia.UseParentBackColor = true;
            this.ctl_shipvia.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_shipvia.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_shipvia.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_shipvia.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_shipvia.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_shipvia.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_shipvia.zz_OriginalDesign = false;
            this.ctl_shipvia.zz_ShowNeedsSaveColor = true;
            this.ctl_shipvia.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_shipvia.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_shipvia.zz_UseGlobalColor = false;
            this.ctl_shipvia.zz_UseGlobalFont = false;
            this.ctl_shipvia.SelectionChanged += new NewMethod.nEdit_List.SelectionChangedHandler(this.ctl_shipvia_SelectionChanged);
            // 
            // ctl_terms
            // 
            this.ctl_terms.AllCaps = false;
            this.ctl_terms.AllowEdit = false;
            this.ctl_terms.BackColor = System.Drawing.Color.Transparent;
            this.ctl_terms.Bold = false;
            this.ctl_terms.Caption = "Terms";
            this.ctl_terms.Changed = false;
            this.ctl_terms.ListName = "terms";
            this.ctl_terms.Location = new System.Drawing.Point(276, 271);
            this.ctl_terms.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_terms.Name = "ctl_terms";
            this.ctl_terms.SimpleList = null;
            this.ctl_terms.Size = new System.Drawing.Size(175, 36);
            this.ctl_terms.TabIndex = 8;
            this.ctl_terms.UseParentBackColor = true;
            this.ctl_terms.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_terms.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_terms.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_terms.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_terms.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_terms.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_terms.zz_OriginalDesign = false;
            this.ctl_terms.zz_ShowNeedsSaveColor = true;
            this.ctl_terms.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_terms.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_terms.zz_UseGlobalColor = false;
            this.ctl_terms.zz_UseGlobalFont = false;
            this.ctl_terms.SelectionChanged += new NewMethod.nEdit_List.SelectionChangedHandler(this.ctl_terms_SelectionChanged);
            this.ctl_terms.KeyBeingPressed += new NewMethod.nEdit_List.GenericEventHandler(this.ctl_terms_KeyBeingPressed);
            this.ctl_terms.Load += new System.EventHandler(this.ctl_terms_Load);
            // 
            // ctl_soreference
            // 
            this.ctl_soreference.AllCaps = false;
            this.ctl_soreference.BackColor = System.Drawing.Color.Transparent;
            this.ctl_soreference.Bold = false;
            this.ctl_soreference.Caption = "Sales Reference";
            this.ctl_soreference.Changed = false;
            this.ctl_soreference.IsEmail = false;
            this.ctl_soreference.IsURL = false;
            this.ctl_soreference.Location = new System.Drawing.Point(152, 265);
            this.ctl_soreference.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_soreference.Name = "ctl_soreference";
            this.ctl_soreference.PasswordChar = '\0';
            this.ctl_soreference.Size = new System.Drawing.Size(116, 57);
            this.ctl_soreference.TabIndex = 7;
            this.ctl_soreference.UseParentBackColor = true;
            this.ctl_soreference.zz_Enabled = true;
            this.ctl_soreference.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_soreference.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_soreference.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_soreference.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_soreference.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_soreference.zz_OriginalDesign = true;
            this.ctl_soreference.zz_ShowLinkButton = false;
            this.ctl_soreference.zz_ShowNeedsSaveColor = true;
            this.ctl_soreference.zz_Text = "";
            this.ctl_soreference.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_soreference.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_soreference.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_soreference.zz_UseGlobalColor = false;
            this.ctl_soreference.zz_UseGlobalFont = false;
            // 
            // ctl_dockdate
            // 
            this.ctl_dockdate.AllowClear = false;
            this.ctl_dockdate.BackColor = System.Drawing.Color.Transparent;
            this.ctl_dockdate.Bold = false;
            this.ctl_dockdate.Caption = "Dock Date";
            this.ctl_dockdate.Changed = false;
            this.ctl_dockdate.Location = new System.Drawing.Point(537, 194);
            this.ctl_dockdate.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_dockdate.Name = "ctl_dockdate";
            this.ctl_dockdate.Size = new System.Drawing.Size(213, 46);
            this.ctl_dockdate.SuppressEdit = false;
            this.ctl_dockdate.TabIndex = 11;
            this.ctl_dockdate.UseParentBackColor = true;
            this.ctl_dockdate.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_dockdate.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_dockdate.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_dockdate.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_dockdate.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopCenter;
            this.ctl_dockdate.zz_OriginalDesign = false;
            this.ctl_dockdate.zz_ShowNeedsSaveColor = true;
            this.ctl_dockdate.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_dockdate.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_dockdate.zz_UseGlobalColor = false;
            this.ctl_dockdate.zz_UseGlobalFont = false;
            // 
            // ctl_requireddate
            // 
            this.ctl_requireddate.AllowClear = false;
            this.ctl_requireddate.BackColor = System.Drawing.Color.Transparent;
            this.ctl_requireddate.Bold = false;
            this.ctl_requireddate.Caption = "Required Date";
            this.ctl_requireddate.Changed = false;
            this.ctl_requireddate.Location = new System.Drawing.Point(316, 194);
            this.ctl_requireddate.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_requireddate.Name = "ctl_requireddate";
            this.ctl_requireddate.Size = new System.Drawing.Size(213, 46);
            this.ctl_requireddate.SuppressEdit = false;
            this.ctl_requireddate.TabIndex = 5;
            this.ctl_requireddate.UseParentBackColor = true;
            this.ctl_requireddate.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_requireddate.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_requireddate.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_requireddate.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_requireddate.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopCenter;
            this.ctl_requireddate.zz_OriginalDesign = false;
            this.ctl_requireddate.zz_ShowNeedsSaveColor = true;
            this.ctl_requireddate.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_requireddate.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_requireddate.zz_UseGlobalColor = false;
            this.ctl_requireddate.zz_UseGlobalFont = false;
            // 
            // ctl_primaryphone
            // 
            this.ctl_primaryphone.AllCaps = false;
            this.ctl_primaryphone.BackColor = System.Drawing.Color.Transparent;
            this.ctl_primaryphone.Bold = false;
            this.ctl_primaryphone.Caption = "Phone";
            this.ctl_primaryphone.Changed = false;
            this.ctl_primaryphone.IsEmail = false;
            this.ctl_primaryphone.IsURL = false;
            this.ctl_primaryphone.Location = new System.Drawing.Point(9, 107);
            this.ctl_primaryphone.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_primaryphone.Name = "ctl_primaryphone";
            this.ctl_primaryphone.PasswordChar = '\0';
            this.ctl_primaryphone.Size = new System.Drawing.Size(292, 52);
            this.ctl_primaryphone.TabIndex = 2;
            this.ctl_primaryphone.UseParentBackColor = true;
            this.ctl_primaryphone.zz_Enabled = true;
            this.ctl_primaryphone.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_primaryphone.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_primaryphone.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_primaryphone.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_primaryphone.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_primaryphone.zz_OriginalDesign = true;
            this.ctl_primaryphone.zz_ShowLinkButton = false;
            this.ctl_primaryphone.zz_ShowNeedsSaveColor = true;
            this.ctl_primaryphone.zz_Text = "";
            this.ctl_primaryphone.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_primaryphone.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_primaryphone.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_primaryphone.zz_UseGlobalColor = false;
            this.ctl_primaryphone.zz_UseGlobalFont = false;
            // 
            // ctl_primaryfax
            // 
            this.ctl_primaryfax.AllCaps = false;
            this.ctl_primaryfax.BackColor = System.Drawing.Color.Transparent;
            this.ctl_primaryfax.Bold = false;
            this.ctl_primaryfax.Caption = "Fax";
            this.ctl_primaryfax.Changed = false;
            this.ctl_primaryfax.IsEmail = false;
            this.ctl_primaryfax.IsURL = false;
            this.ctl_primaryfax.Location = new System.Drawing.Point(9, 160);
            this.ctl_primaryfax.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_primaryfax.Name = "ctl_primaryfax";
            this.ctl_primaryfax.PasswordChar = '\0';
            this.ctl_primaryfax.Size = new System.Drawing.Size(292, 50);
            this.ctl_primaryfax.TabIndex = 3;
            this.ctl_primaryfax.UseParentBackColor = true;
            this.ctl_primaryfax.zz_Enabled = true;
            this.ctl_primaryfax.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_primaryfax.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_primaryfax.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_primaryfax.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_primaryfax.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_primaryfax.zz_OriginalDesign = true;
            this.ctl_primaryfax.zz_ShowLinkButton = false;
            this.ctl_primaryfax.zz_ShowNeedsSaveColor = true;
            this.ctl_primaryfax.zz_Text = "";
            this.ctl_primaryfax.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_primaryfax.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_primaryfax.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_primaryfax.zz_UseGlobalColor = false;
            this.ctl_primaryfax.zz_UseGlobalFont = false;
            // 
            // ctl_primaryemailaddress
            // 
            this.ctl_primaryemailaddress.AllCaps = false;
            this.ctl_primaryemailaddress.BackColor = System.Drawing.Color.Transparent;
            this.ctl_primaryemailaddress.Bold = false;
            this.ctl_primaryemailaddress.Caption = "Email";
            this.ctl_primaryemailaddress.Changed = false;
            this.ctl_primaryemailaddress.IsEmail = false;
            this.ctl_primaryemailaddress.IsURL = false;
            this.ctl_primaryemailaddress.Location = new System.Drawing.Point(9, 212);
            this.ctl_primaryemailaddress.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_primaryemailaddress.Name = "ctl_primaryemailaddress";
            this.ctl_primaryemailaddress.PasswordChar = '\0';
            this.ctl_primaryemailaddress.Size = new System.Drawing.Size(292, 59);
            this.ctl_primaryemailaddress.TabIndex = 4;
            this.ctl_primaryemailaddress.UseParentBackColor = true;
            this.ctl_primaryemailaddress.zz_Enabled = true;
            this.ctl_primaryemailaddress.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_primaryemailaddress.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_primaryemailaddress.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_primaryemailaddress.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_primaryemailaddress.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_primaryemailaddress.zz_OriginalDesign = true;
            this.ctl_primaryemailaddress.zz_ShowLinkButton = false;
            this.ctl_primaryemailaddress.zz_ShowNeedsSaveColor = true;
            this.ctl_primaryemailaddress.zz_Text = "";
            this.ctl_primaryemailaddress.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_primaryemailaddress.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_primaryemailaddress.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_primaryemailaddress.zz_UseGlobalColor = false;
            this.ctl_primaryemailaddress.zz_UseGlobalFont = false;
            // 
            // agent
            // 
            this.agent.AllowChange = true;
            this.agent.AllowClear = false;
            this.agent.AllowNew = false;
            this.agent.AllowView = false;
            this.agent.BackColor = System.Drawing.Color.Transparent;
            this.agent.Bold = false;
            this.agent.Caption = "Agent";
            this.agent.Changed = false;
            this.agent.Location = new System.Drawing.Point(531, 7);
            this.agent.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.agent.Name = "agent";
            this.agent.Size = new System.Drawing.Size(291, 80);
            this.agent.TabIndex = 13;
            this.agent.UseParentBackColor = true;
            this.agent.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.agent.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            // 
            // cStub
            // 
            this.cStub.Caption = "Company Name";
            this.cStub.Location = new System.Drawing.Point(4, 5);
            this.cStub.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.cStub.Name = "cStub";
            this.cStub.Size = new System.Drawing.Size(449, 126);
            this.cStub.TabIndex = 1;
            this.cStub.ChangeContact += new Rz5.ContactEventHandler(this.cStub_ChangeContact);
            this.cStub.ChangeCompany += new Rz5.ContactEventHandler(this.cStub_ChangeCompany);
            // 
            // ctl_followup_date
            // 
            this.ctl_followup_date.AllowClear = false;
            this.ctl_followup_date.BackColor = System.Drawing.Color.Transparent;
            this.ctl_followup_date.Bold = false;
            this.ctl_followup_date.Caption = "Last Follow Up";
            this.ctl_followup_date.Changed = false;
            this.ctl_followup_date.Location = new System.Drawing.Point(540, 194);
            this.ctl_followup_date.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_followup_date.Name = "ctl_followup_date";
            this.ctl_followup_date.Size = new System.Drawing.Size(213, 46);
            this.ctl_followup_date.SuppressEdit = false;
            this.ctl_followup_date.TabIndex = 24;
            this.ctl_followup_date.UseParentBackColor = true;
            this.ctl_followup_date.Visible = false;
            this.ctl_followup_date.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_followup_date.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_followup_date.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_followup_date.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_followup_date.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopCenter;
            this.ctl_followup_date.zz_OriginalDesign = false;
            this.ctl_followup_date.zz_ShowNeedsSaveColor = true;
            this.ctl_followup_date.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_followup_date.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_followup_date.zz_UseGlobalColor = false;
            this.ctl_followup_date.zz_UseGlobalFont = false;
            // 
            // pageAddress
            // 
            this.pageAddress.Controls.Add(this.lblASN);
            this.pageAddress.Controls.Add(this.ctl_trackingnumber);
            this.pageAddress.Controls.Add(this.cmdPasteBill);
            this.pageAddress.Controls.Add(this.ctl_orderfob);
            this.pageAddress.Controls.Add(this.cmdSwitchAddress);
            this.pageAddress.Controls.Add(this.lblAddNewShiping);
            this.pageAddress.Controls.Add(this.lblAddNewBilling);
            this.pageAddress.Controls.Add(this.cmdShipBill);
            this.pageAddress.Controls.Add(this.cmdBillShip);
            this.pageAddress.Controls.Add(this.ctl_shippingaddress);
            this.pageAddress.Controls.Add(this.ctl_billingaddress);
            this.pageAddress.Controls.Add(this.cboBillingAddress);
            this.pageAddress.Controls.Add(this.cboShippingAddress);
            this.pageAddress.Controls.Add(this.ctl_shippingname);
            this.pageAddress.Controls.Add(this.ctl_billingname);
            this.pageAddress.Controls.Add(this.ctl_packinginfo);
            this.pageAddress.Controls.Add(this.ctl_shippingaccount);
            this.pageAddress.Controls.Add(this.ctl_freightbilling);
            this.pageAddress.Location = new System.Drawing.Point(4, 22);
            this.pageAddress.Margin = new System.Windows.Forms.Padding(4);
            this.pageAddress.Name = "pageAddress";
            this.pageAddress.Padding = new System.Windows.Forms.Padding(4);
            this.pageAddress.Size = new System.Drawing.Size(192, 74);
            this.pageAddress.TabIndex = 1;
            this.pageAddress.Text = "Address";
            this.pageAddress.UseVisualStyleBackColor = true;
            // 
            // lblASN
            // 
            this.lblASN.AutoSize = true;
            this.lblASN.Location = new System.Drawing.Point(679, 201);
            this.lblASN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblASN.Name = "lblASN";
            this.lblASN.Size = new System.Drawing.Size(48, 13);
            this.lblASN.TabIndex = 46;
            this.lblASN.TabStop = true;
            this.lblASN.Text = "add new";
            this.lblASN.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblASN_LinkClicked);
            // 
            // ctl_trackingnumber
            // 
            this.ctl_trackingnumber.BackColor = System.Drawing.Color.Transparent;
            this.ctl_trackingnumber.Bold = false;
            this.ctl_trackingnumber.Caption = "Tracking Number(s)";
            this.ctl_trackingnumber.Changed = false;
            this.ctl_trackingnumber.DateLines = false;
            this.ctl_trackingnumber.Location = new System.Drawing.Point(375, 202);
            this.ctl_trackingnumber.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_trackingnumber.Name = "ctl_trackingnumber";
            this.ctl_trackingnumber.Size = new System.Drawing.Size(368, 65);
            this.ctl_trackingnumber.TabIndex = 48;
            this.ctl_trackingnumber.UseParentBackColor = false;
            this.ctl_trackingnumber.zz_Enabled = true;
            this.ctl_trackingnumber.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_trackingnumber.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_trackingnumber.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_trackingnumber.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_trackingnumber.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_trackingnumber.zz_OriginalDesign = false;
            this.ctl_trackingnumber.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_trackingnumber.zz_ShowNeedsSaveColor = true;
            this.ctl_trackingnumber.zz_Text = "";
            this.ctl_trackingnumber.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_trackingnumber.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_trackingnumber.zz_UseGlobalColor = false;
            this.ctl_trackingnumber.zz_UseGlobalFont = false;
            // 
            // cmdPasteBill
            // 
            this.cmdPasteBill.Location = new System.Drawing.Point(268, 64);
            this.cmdPasteBill.Margin = new System.Windows.Forms.Padding(4);
            this.cmdPasteBill.Name = "cmdPasteBill";
            this.cmdPasteBill.Size = new System.Drawing.Size(61, 28);
            this.cmdPasteBill.TabIndex = 47;
            this.cmdPasteBill.Text = "Paste";
            this.cmdPasteBill.UseVisualStyleBackColor = true;
            this.cmdPasteBill.Click += new System.EventHandler(this.cmdPasteBill_Click);
            // 
            // ctl_orderfob
            // 
            this.ctl_orderfob.AllCaps = false;
            this.ctl_orderfob.AllowEdit = true;
            this.ctl_orderfob.BackColor = System.Drawing.Color.Transparent;
            this.ctl_orderfob.Bold = false;
            this.ctl_orderfob.Caption = "FOB";
            this.ctl_orderfob.Changed = false;
            this.ctl_orderfob.ListName = "orderfob";
            this.ctl_orderfob.Location = new System.Drawing.Point(204, 270);
            this.ctl_orderfob.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_orderfob.Name = "ctl_orderfob";
            this.ctl_orderfob.SimpleList = null;
            this.ctl_orderfob.Size = new System.Drawing.Size(156, 36);
            this.ctl_orderfob.TabIndex = 45;
            this.ctl_orderfob.UseParentBackColor = true;
            this.ctl_orderfob.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_orderfob.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_orderfob.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_orderfob.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_orderfob.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_orderfob.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_orderfob.zz_OriginalDesign = false;
            this.ctl_orderfob.zz_ShowNeedsSaveColor = true;
            this.ctl_orderfob.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_orderfob.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_orderfob.zz_UseGlobalColor = false;
            this.ctl_orderfob.zz_UseGlobalFont = false;
            // 
            // cmdSwitchAddress
            // 
            this.cmdSwitchAddress.Location = new System.Drawing.Point(344, 169);
            this.cmdSwitchAddress.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSwitchAddress.Name = "cmdSwitchAddress";
            this.cmdSwitchAddress.Size = new System.Drawing.Size(48, 28);
            this.cmdSwitchAddress.TabIndex = 27;
            this.cmdSwitchAddress.Text = "<>";
            this.cmdSwitchAddress.UseVisualStyleBackColor = true;
            this.cmdSwitchAddress.Click += new System.EventHandler(this.cmdSwitchAddress_Click);
            // 
            // lblAddNewShiping
            // 
            this.lblAddNewShiping.AutoSize = true;
            this.lblAddNewShiping.Location = new System.Drawing.Point(411, 70);
            this.lblAddNewShiping.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddNewShiping.Name = "lblAddNewShiping";
            this.lblAddNewShiping.Size = new System.Drawing.Size(48, 13);
            this.lblAddNewShiping.TabIndex = 26;
            this.lblAddNewShiping.TabStop = true;
            this.lblAddNewShiping.Text = "add new";
            this.lblAddNewShiping.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAddNewShiping_LinkClicked);
            // 
            // lblAddNewBilling
            // 
            this.lblAddNewBilling.AutoSize = true;
            this.lblAddNewBilling.Location = new System.Drawing.Point(8, 69);
            this.lblAddNewBilling.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddNewBilling.Name = "lblAddNewBilling";
            this.lblAddNewBilling.Size = new System.Drawing.Size(48, 13);
            this.lblAddNewBilling.TabIndex = 25;
            this.lblAddNewBilling.TabStop = true;
            this.lblAddNewBilling.Text = "add new";
            this.lblAddNewBilling.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAddNewBilling_LinkClicked);
            // 
            // cmdShipBill
            // 
            this.cmdShipBill.Location = new System.Drawing.Point(344, 133);
            this.cmdShipBill.Margin = new System.Windows.Forms.Padding(4);
            this.cmdShipBill.Name = "cmdShipBill";
            this.cmdShipBill.Size = new System.Drawing.Size(48, 28);
            this.cmdShipBill.TabIndex = 17;
            this.cmdShipBill.Text = "<";
            this.cmdShipBill.UseVisualStyleBackColor = true;
            this.cmdShipBill.Click += new System.EventHandler(this.cmdShipBill_Click);
            // 
            // cmdBillShip
            // 
            this.cmdBillShip.Location = new System.Drawing.Point(344, 101);
            this.cmdBillShip.Margin = new System.Windows.Forms.Padding(4);
            this.cmdBillShip.Name = "cmdBillShip";
            this.cmdBillShip.Size = new System.Drawing.Size(48, 28);
            this.cmdBillShip.TabIndex = 16;
            this.cmdBillShip.Text = ">";
            this.cmdBillShip.UseVisualStyleBackColor = true;
            this.cmdBillShip.Click += new System.EventHandler(this.cmdBillShip_Click);
            // 
            // ctl_shippingaddress
            // 
            this.ctl_shippingaddress.BackColor = System.Drawing.Color.Transparent;
            this.ctl_shippingaddress.Bold = false;
            this.ctl_shippingaddress.Caption = "";
            this.ctl_shippingaddress.Changed = false;
            this.ctl_shippingaddress.DateLines = false;
            this.ctl_shippingaddress.Location = new System.Drawing.Point(408, 69);
            this.ctl_shippingaddress.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_shippingaddress.Name = "ctl_shippingaddress";
            this.ctl_shippingaddress.Size = new System.Drawing.Size(335, 129);
            this.ctl_shippingaddress.TabIndex = 19;
            this.ctl_shippingaddress.UseParentBackColor = true;
            this.ctl_shippingaddress.zz_Enabled = true;
            this.ctl_shippingaddress.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_shippingaddress.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_shippingaddress.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_shippingaddress.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_shippingaddress.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_shippingaddress.zz_OriginalDesign = true;
            this.ctl_shippingaddress.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_shippingaddress.zz_ShowNeedsSaveColor = true;
            this.ctl_shippingaddress.zz_Text = "";
            this.ctl_shippingaddress.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_shippingaddress.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_shippingaddress.zz_UseGlobalColor = false;
            this.ctl_shippingaddress.zz_UseGlobalFont = false;
            // 
            // ctl_billingaddress
            // 
            this.ctl_billingaddress.BackColor = System.Drawing.Color.Transparent;
            this.ctl_billingaddress.Bold = false;
            this.ctl_billingaddress.Caption = "";
            this.ctl_billingaddress.Changed = false;
            this.ctl_billingaddress.DateLines = false;
            this.ctl_billingaddress.Location = new System.Drawing.Point(8, 69);
            this.ctl_billingaddress.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_billingaddress.Name = "ctl_billingaddress";
            this.ctl_billingaddress.Size = new System.Drawing.Size(321, 129);
            this.ctl_billingaddress.TabIndex = 16;
            this.ctl_billingaddress.UseParentBackColor = true;
            this.ctl_billingaddress.zz_Enabled = true;
            this.ctl_billingaddress.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_billingaddress.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_billingaddress.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_billingaddress.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_billingaddress.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_billingaddress.zz_OriginalDesign = true;
            this.ctl_billingaddress.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_billingaddress.zz_ShowNeedsSaveColor = true;
            this.ctl_billingaddress.zz_Text = "";
            this.ctl_billingaddress.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_billingaddress.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_billingaddress.zz_UseGlobalColor = false;
            this.ctl_billingaddress.zz_UseGlobalFont = false;
            // 
            // cboBillingAddress
            // 
            this.cboBillingAddress.AllCaps = false;
            this.cboBillingAddress.AllowEdit = false;
            this.cboBillingAddress.BackColor = System.Drawing.Color.Transparent;
            this.cboBillingAddress.Bold = false;
            this.cboBillingAddress.Caption = "Billing Address";
            this.cboBillingAddress.Changed = false;
            this.cboBillingAddress.ListName = null;
            this.cboBillingAddress.Location = new System.Drawing.Point(8, 34);
            this.cboBillingAddress.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.cboBillingAddress.Name = "cboBillingAddress";
            this.cboBillingAddress.SimpleList = null;
            this.cboBillingAddress.Size = new System.Drawing.Size(359, 22);
            this.cboBillingAddress.TabIndex = 15;
            this.cboBillingAddress.UseParentBackColor = true;
            this.cboBillingAddress.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboBillingAddress.zz_GlobalColor = System.Drawing.Color.Black;
            this.cboBillingAddress.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cboBillingAddress.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.cboBillingAddress.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboBillingAddress.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.Left;
            this.cboBillingAddress.zz_OriginalDesign = false;
            this.cboBillingAddress.zz_ShowNeedsSaveColor = true;
            this.cboBillingAddress.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.cboBillingAddress.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBillingAddress.zz_UseGlobalColor = false;
            this.cboBillingAddress.zz_UseGlobalFont = false;
            this.cboBillingAddress.SelectionChanged += new NewMethod.nEdit_List.SelectionChangedHandler(this.cboBillingAddress_SelectionChanged);
            // 
            // cboShippingAddress
            // 
            this.cboShippingAddress.AllCaps = false;
            this.cboShippingAddress.AllowEdit = false;
            this.cboShippingAddress.BackColor = System.Drawing.Color.Transparent;
            this.cboShippingAddress.Bold = false;
            this.cboShippingAddress.Caption = "Shipping Address";
            this.cboShippingAddress.Changed = false;
            this.cboShippingAddress.ListName = null;
            this.cboShippingAddress.Location = new System.Drawing.Point(401, 33);
            this.cboShippingAddress.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.cboShippingAddress.Name = "cboShippingAddress";
            this.cboShippingAddress.SimpleList = null;
            this.cboShippingAddress.Size = new System.Drawing.Size(335, 22);
            this.cboShippingAddress.TabIndex = 18;
            this.cboShippingAddress.UseParentBackColor = true;
            this.cboShippingAddress.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboShippingAddress.zz_GlobalColor = System.Drawing.Color.Black;
            this.cboShippingAddress.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cboShippingAddress.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.cboShippingAddress.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboShippingAddress.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.Left;
            this.cboShippingAddress.zz_OriginalDesign = false;
            this.cboShippingAddress.zz_ShowNeedsSaveColor = true;
            this.cboShippingAddress.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.cboShippingAddress.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboShippingAddress.zz_UseGlobalColor = false;
            this.cboShippingAddress.zz_UseGlobalFont = false;
            this.cboShippingAddress.SelectionChanged += new NewMethod.nEdit_List.SelectionChangedHandler(this.cboShippingAddress_SelectionChanged);
            // 
            // ctl_shippingname
            // 
            this.ctl_shippingname.AllCaps = false;
            this.ctl_shippingname.BackColor = System.Drawing.Color.Transparent;
            this.ctl_shippingname.Bold = false;
            this.ctl_shippingname.Caption = "Shipping Name";
            this.ctl_shippingname.Changed = false;
            this.ctl_shippingname.IsEmail = false;
            this.ctl_shippingname.IsURL = false;
            this.ctl_shippingname.Location = new System.Drawing.Point(401, 4);
            this.ctl_shippingname.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_shippingname.Name = "ctl_shippingname";
            this.ctl_shippingname.PasswordChar = '\0';
            this.ctl_shippingname.Size = new System.Drawing.Size(335, 21);
            this.ctl_shippingname.TabIndex = 17;
            this.ctl_shippingname.UseParentBackColor = true;
            this.ctl_shippingname.zz_Enabled = true;
            this.ctl_shippingname.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_shippingname.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_shippingname.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_shippingname.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_shippingname.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.Left;
            this.ctl_shippingname.zz_OriginalDesign = false;
            this.ctl_shippingname.zz_ShowLinkButton = false;
            this.ctl_shippingname.zz_ShowNeedsSaveColor = true;
            this.ctl_shippingname.zz_Text = "";
            this.ctl_shippingname.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_shippingname.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_shippingname.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_shippingname.zz_UseGlobalColor = false;
            this.ctl_shippingname.zz_UseGlobalFont = false;
            // 
            // ctl_billingname
            // 
            this.ctl_billingname.AllCaps = false;
            this.ctl_billingname.BackColor = System.Drawing.Color.Transparent;
            this.ctl_billingname.Bold = false;
            this.ctl_billingname.Caption = "Billing Name";
            this.ctl_billingname.Changed = false;
            this.ctl_billingname.IsEmail = false;
            this.ctl_billingname.IsURL = false;
            this.ctl_billingname.Location = new System.Drawing.Point(8, 5);
            this.ctl_billingname.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_billingname.Name = "ctl_billingname";
            this.ctl_billingname.PasswordChar = '\0';
            this.ctl_billingname.Size = new System.Drawing.Size(359, 21);
            this.ctl_billingname.TabIndex = 14;
            this.ctl_billingname.UseParentBackColor = true;
            this.ctl_billingname.zz_Enabled = true;
            this.ctl_billingname.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_billingname.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_billingname.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_billingname.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_billingname.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.Left;
            this.ctl_billingname.zz_OriginalDesign = false;
            this.ctl_billingname.zz_ShowLinkButton = false;
            this.ctl_billingname.zz_ShowNeedsSaveColor = true;
            this.ctl_billingname.zz_Text = "";
            this.ctl_billingname.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_billingname.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_billingname.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_billingname.zz_UseGlobalColor = false;
            this.ctl_billingname.zz_UseGlobalFont = false;
            // 
            // ctl_packinginfo
            // 
            this.ctl_packinginfo.AllCaps = false;
            this.ctl_packinginfo.AllowEdit = false;
            this.ctl_packinginfo.BackColor = System.Drawing.Color.Transparent;
            this.ctl_packinginfo.Bold = false;
            this.ctl_packinginfo.Caption = "Packing Info";
            this.ctl_packinginfo.Changed = false;
            this.ctl_packinginfo.ListName = "";
            this.ctl_packinginfo.Location = new System.Drawing.Point(375, 262);
            this.ctl_packinginfo.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_packinginfo.Name = "ctl_packinginfo";
            this.ctl_packinginfo.SimpleList = null;
            this.ctl_packinginfo.Size = new System.Drawing.Size(368, 50);
            this.ctl_packinginfo.TabIndex = 24;
            this.ctl_packinginfo.UseParentBackColor = true;
            this.ctl_packinginfo.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_packinginfo.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_packinginfo.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_packinginfo.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_packinginfo.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_packinginfo.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_packinginfo.zz_OriginalDesign = true;
            this.ctl_packinginfo.zz_ShowNeedsSaveColor = true;
            this.ctl_packinginfo.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_packinginfo.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_packinginfo.zz_UseGlobalColor = false;
            this.ctl_packinginfo.zz_UseGlobalFont = false;
            this.ctl_packinginfo.Load += new System.EventHandler(this.ctl_packinginfo_Load);
            // 
            // ctl_shippingaccount
            // 
            this.ctl_shippingaccount.AllCaps = false;
            this.ctl_shippingaccount.AllowEdit = true;
            this.ctl_shippingaccount.BackColor = System.Drawing.Color.Transparent;
            this.ctl_shippingaccount.Bold = false;
            this.ctl_shippingaccount.Caption = "Shipping Account";
            this.ctl_shippingaccount.Changed = false;
            this.ctl_shippingaccount.ListName = "shippingaccount";
            this.ctl_shippingaccount.Location = new System.Drawing.Point(8, 268);
            this.ctl_shippingaccount.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_shippingaccount.Name = "ctl_shippingaccount";
            this.ctl_shippingaccount.SimpleList = null;
            this.ctl_shippingaccount.Size = new System.Drawing.Size(188, 36);
            this.ctl_shippingaccount.TabIndex = 21;
            this.ctl_shippingaccount.UseParentBackColor = true;
            this.ctl_shippingaccount.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_shippingaccount.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_shippingaccount.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_shippingaccount.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_shippingaccount.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_shippingaccount.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_shippingaccount.zz_OriginalDesign = false;
            this.ctl_shippingaccount.zz_ShowNeedsSaveColor = true;
            this.ctl_shippingaccount.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_shippingaccount.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_shippingaccount.zz_UseGlobalColor = false;
            this.ctl_shippingaccount.zz_UseGlobalFont = false;
            // 
            // ctl_freightbilling
            // 
            this.ctl_freightbilling.AllCaps = false;
            this.ctl_freightbilling.AllowEdit = true;
            this.ctl_freightbilling.BackColor = System.Drawing.Color.Transparent;
            this.ctl_freightbilling.Bold = false;
            this.ctl_freightbilling.Caption = "Freight Billing";
            this.ctl_freightbilling.Changed = false;
            this.ctl_freightbilling.ListName = "freightbilling";
            this.ctl_freightbilling.Location = new System.Drawing.Point(8, 212);
            this.ctl_freightbilling.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_freightbilling.Name = "ctl_freightbilling";
            this.ctl_freightbilling.SimpleList = null;
            this.ctl_freightbilling.Size = new System.Drawing.Size(352, 36);
            this.ctl_freightbilling.TabIndex = 20;
            this.ctl_freightbilling.UseParentBackColor = true;
            this.ctl_freightbilling.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_freightbilling.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_freightbilling.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_freightbilling.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_freightbilling.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_freightbilling.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_freightbilling.zz_OriginalDesign = false;
            this.ctl_freightbilling.zz_ShowNeedsSaveColor = true;
            this.ctl_freightbilling.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_freightbilling.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_freightbilling.zz_UseGlobalColor = false;
            this.ctl_freightbilling.zz_UseGlobalFont = false;
            // 
            // pageNotes
            // 
            this.pageNotes.Controls.Add(this.cmdNTCUpdate);
            this.pageNotes.Controls.Add(this.ctl_qualitycontrol);
            this.pageNotes.Controls.Add(this.gbNotes_Sales);
            this.pageNotes.Controls.Add(this.ctl_printcomment);
            this.pageNotes.Controls.Add(this.ctl_internalcomment);
            this.pageNotes.Controls.Add(this.cboCards);
            this.pageNotes.Location = new System.Drawing.Point(4, 22);
            this.pageNotes.Margin = new System.Windows.Forms.Padding(4);
            this.pageNotes.Name = "pageNotes";
            this.pageNotes.Padding = new System.Windows.Forms.Padding(4);
            this.pageNotes.Size = new System.Drawing.Size(192, 74);
            this.pageNotes.TabIndex = 2;
            this.pageNotes.Text = "Notes";
            this.pageNotes.UseVisualStyleBackColor = true;
            // 
            // cmdNTCUpdate
            // 
            this.cmdNTCUpdate.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNTCUpdate.Location = new System.Drawing.Point(417, 12);
            this.cmdNTCUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.cmdNTCUpdate.Name = "cmdNTCUpdate";
            this.cmdNTCUpdate.Size = new System.Drawing.Size(339, 30);
            this.cmdNTCUpdate.TabIndex = 43;
            this.cmdNTCUpdate.Text = "Update Company Info";
            this.cmdNTCUpdate.UseVisualStyleBackColor = true;
            this.cmdNTCUpdate.Visible = false;
            this.cmdNTCUpdate.Click += new System.EventHandler(this.cmdUpdateCompanyInfo_Click);
            // 
            // ctl_qualitycontrol
            // 
            this.ctl_qualitycontrol.AllCaps = false;
            this.ctl_qualitycontrol.BackColor = System.Drawing.Color.Transparent;
            this.ctl_qualitycontrol.Bold = false;
            this.ctl_qualitycontrol.Caption = "Quality Control";
            this.ctl_qualitycontrol.Changed = false;
            this.ctl_qualitycontrol.IsEmail = false;
            this.ctl_qualitycontrol.IsURL = false;
            this.ctl_qualitycontrol.Location = new System.Drawing.Point(413, 49);
            this.ctl_qualitycontrol.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_qualitycontrol.Name = "ctl_qualitycontrol";
            this.ctl_qualitycontrol.PasswordChar = '\0';
            this.ctl_qualitycontrol.Size = new System.Drawing.Size(263, 35);
            this.ctl_qualitycontrol.TabIndex = 33;
            this.ctl_qualitycontrol.UseParentBackColor = false;
            this.ctl_qualitycontrol.zz_Enabled = true;
            this.ctl_qualitycontrol.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_qualitycontrol.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_qualitycontrol.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_qualitycontrol.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_qualitycontrol.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_qualitycontrol.zz_OriginalDesign = false;
            this.ctl_qualitycontrol.zz_ShowLinkButton = false;
            this.ctl_qualitycontrol.zz_ShowNeedsSaveColor = true;
            this.ctl_qualitycontrol.zz_Text = "";
            this.ctl_qualitycontrol.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_qualitycontrol.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_qualitycontrol.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_qualitycontrol.zz_UseGlobalColor = false;
            this.ctl_qualitycontrol.zz_UseGlobalFont = false;
            // 
            // gbNotes_Sales
            // 
            this.gbNotes_Sales.Controls.Add(this.ctl_showonwarehouse);
            this.gbNotes_Sales.Controls.Add(this.ctl_isflipdeal);
            this.gbNotes_Sales.Controls.Add(this.ctl_isproforma);
            this.gbNotes_Sales.Controls.Add(this.ctl_has_issue);
            this.gbNotes_Sales.Controls.Add(this.ctl_advanced_payment_made);
            this.gbNotes_Sales.Location = new System.Drawing.Point(4, 38);
            this.gbNotes_Sales.Margin = new System.Windows.Forms.Padding(4);
            this.gbNotes_Sales.Name = "gbNotes_Sales";
            this.gbNotes_Sales.Padding = new System.Windows.Forms.Padding(4);
            this.gbNotes_Sales.Size = new System.Drawing.Size(405, 62);
            this.gbNotes_Sales.TabIndex = 31;
            this.gbNotes_Sales.TabStop = false;
            // 
            // ctl_showonwarehouse
            // 
            this.ctl_showonwarehouse.BackColor = System.Drawing.Color.Transparent;
            this.ctl_showonwarehouse.Bold = false;
            this.ctl_showonwarehouse.Caption = "Warehouse Visible";
            this.ctl_showonwarehouse.Changed = false;
            this.ctl_showonwarehouse.Location = new System.Drawing.Point(105, 11);
            this.ctl_showonwarehouse.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_showonwarehouse.Name = "ctl_showonwarehouse";
            this.ctl_showonwarehouse.Size = new System.Drawing.Size(114, 18);
            this.ctl_showonwarehouse.TabIndex = 30;
            this.ctl_showonwarehouse.UseParentBackColor = true;
            this.ctl_showonwarehouse.zz_CheckValue = false;
            this.ctl_showonwarehouse.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_showonwarehouse.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_showonwarehouse.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_showonwarehouse.zz_OriginalDesign = false;
            this.ctl_showonwarehouse.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_isflipdeal
            // 
            this.ctl_isflipdeal.BackColor = System.Drawing.Color.Transparent;
            this.ctl_isflipdeal.Bold = false;
            this.ctl_isflipdeal.Caption = "Flip Deal";
            this.ctl_isflipdeal.Changed = false;
            this.ctl_isflipdeal.Location = new System.Drawing.Point(7, 11);
            this.ctl_isflipdeal.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_isflipdeal.Name = "ctl_isflipdeal";
            this.ctl_isflipdeal.Size = new System.Drawing.Size(67, 18);
            this.ctl_isflipdeal.TabIndex = 28;
            this.ctl_isflipdeal.UseParentBackColor = true;
            this.ctl_isflipdeal.zz_CheckValue = false;
            this.ctl_isflipdeal.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_isflipdeal.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_isflipdeal.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_isflipdeal.zz_OriginalDesign = false;
            this.ctl_isflipdeal.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_isproforma
            // 
            this.ctl_isproforma.BackColor = System.Drawing.Color.Transparent;
            this.ctl_isproforma.Bold = false;
            this.ctl_isproforma.Caption = "Proforma";
            this.ctl_isproforma.Changed = false;
            this.ctl_isproforma.Location = new System.Drawing.Point(7, 33);
            this.ctl_isproforma.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_isproforma.Name = "ctl_isproforma";
            this.ctl_isproforma.Size = new System.Drawing.Size(68, 18);
            this.ctl_isproforma.TabIndex = 29;
            this.ctl_isproforma.UseParentBackColor = true;
            this.ctl_isproforma.zz_CheckValue = false;
            this.ctl_isproforma.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_isproforma.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_isproforma.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_isproforma.zz_OriginalDesign = false;
            this.ctl_isproforma.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_has_issue
            // 
            this.ctl_has_issue.BackColor = System.Drawing.Color.Transparent;
            this.ctl_has_issue.Bold = false;
            this.ctl_has_issue.Caption = "Has Issue";
            this.ctl_has_issue.Changed = false;
            this.ctl_has_issue.Location = new System.Drawing.Point(300, 11);
            this.ctl_has_issue.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_has_issue.Name = "ctl_has_issue";
            this.ctl_has_issue.Size = new System.Drawing.Size(73, 18);
            this.ctl_has_issue.TabIndex = 31;
            this.ctl_has_issue.UseParentBackColor = true;
            this.ctl_has_issue.zz_CheckValue = false;
            this.ctl_has_issue.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_has_issue.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_has_issue.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_has_issue.zz_OriginalDesign = false;
            this.ctl_has_issue.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_advanced_payment_made
            // 
            this.ctl_advanced_payment_made.BackColor = System.Drawing.Color.Transparent;
            this.ctl_advanced_payment_made.Bold = false;
            this.ctl_advanced_payment_made.Caption = "Advance Payment Received";
            this.ctl_advanced_payment_made.Changed = false;
            this.ctl_advanced_payment_made.Location = new System.Drawing.Point(105, 33);
            this.ctl_advanced_payment_made.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_advanced_payment_made.Name = "ctl_advanced_payment_made";
            this.ctl_advanced_payment_made.Size = new System.Drawing.Size(162, 18);
            this.ctl_advanced_payment_made.TabIndex = 32;
            this.ctl_advanced_payment_made.UseParentBackColor = true;
            this.ctl_advanced_payment_made.zz_CheckValue = false;
            this.ctl_advanced_payment_made.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_advanced_payment_made.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_advanced_payment_made.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_advanced_payment_made.zz_OriginalDesign = false;
            this.ctl_advanced_payment_made.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_printcomment
            // 
            this.ctl_printcomment.BackColor = System.Drawing.Color.Transparent;
            this.ctl_printcomment.Bold = false;
            this.ctl_printcomment.Caption = "Print Comment";
            this.ctl_printcomment.Changed = false;
            this.ctl_printcomment.DateLines = false;
            this.ctl_printcomment.Location = new System.Drawing.Point(4, 191);
            this.ctl_printcomment.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_printcomment.Name = "ctl_printcomment";
            this.ctl_printcomment.Size = new System.Drawing.Size(752, 119);
            this.ctl_printcomment.TabIndex = 27;
            this.ctl_printcomment.UseParentBackColor = true;
            this.ctl_printcomment.zz_Enabled = true;
            this.ctl_printcomment.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_printcomment.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_printcomment.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_printcomment.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_printcomment.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_printcomment.zz_OriginalDesign = false;
            this.ctl_printcomment.zz_ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ctl_printcomment.zz_ShowNeedsSaveColor = true;
            this.ctl_printcomment.zz_Text = "";
            this.ctl_printcomment.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_printcomment.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_printcomment.zz_UseGlobalColor = false;
            this.ctl_printcomment.zz_UseGlobalFont = false;
            // 
            // ctl_internalcomment
            // 
            this.ctl_internalcomment.BackColor = System.Drawing.Color.Transparent;
            this.ctl_internalcomment.Bold = false;
            this.ctl_internalcomment.Caption = "Internal Comment";
            this.ctl_internalcomment.Changed = false;
            this.ctl_internalcomment.DateLines = false;
            this.ctl_internalcomment.Location = new System.Drawing.Point(4, 100);
            this.ctl_internalcomment.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_internalcomment.Name = "ctl_internalcomment";
            this.ctl_internalcomment.Size = new System.Drawing.Size(752, 89);
            this.ctl_internalcomment.TabIndex = 26;
            this.ctl_internalcomment.UseParentBackColor = true;
            this.ctl_internalcomment.zz_Enabled = true;
            this.ctl_internalcomment.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_internalcomment.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_internalcomment.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_internalcomment.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_internalcomment.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_internalcomment.zz_OriginalDesign = false;
            this.ctl_internalcomment.zz_ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ctl_internalcomment.zz_ShowNeedsSaveColor = true;
            this.ctl_internalcomment.zz_Text = "";
            this.ctl_internalcomment.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_internalcomment.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_internalcomment.zz_UseGlobalColor = false;
            this.ctl_internalcomment.zz_UseGlobalFont = false;
            // 
            // cboCards
            // 
            this.cboCards.AllCaps = false;
            this.cboCards.AllowEdit = false;
            this.cboCards.BackColor = System.Drawing.Color.Transparent;
            this.cboCards.Bold = false;
            this.cboCards.Caption = "Credit Cards";
            this.cboCards.Changed = false;
            this.cboCards.ListName = null;
            this.cboCards.Location = new System.Drawing.Point(4, 12);
            this.cboCards.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.cboCards.Name = "cboCards";
            this.cboCards.SimpleList = null;
            this.cboCards.Size = new System.Drawing.Size(405, 22);
            this.cboCards.TabIndex = 25;
            this.cboCards.UseParentBackColor = true;
            this.cboCards.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboCards.zz_GlobalColor = System.Drawing.Color.Black;
            this.cboCards.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cboCards.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.cboCards.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboCards.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.Left;
            this.cboCards.zz_OriginalDesign = false;
            this.cboCards.zz_ShowNeedsSaveColor = true;
            this.cboCards.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.cboCards.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCards.zz_UseGlobalColor = false;
            this.cboCards.zz_UseGlobalFont = false;
            this.cboCards.SelectionChanged += new NewMethod.nEdit_List.SelectionChangedHandler(this.cboCards_SelectionChanged);
            // 
            // pageStatus
            // 
            this.pageStatus.Controls.Add(this.gbRMA);
            this.pageStatus.Location = new System.Drawing.Point(4, 22);
            this.pageStatus.Margin = new System.Windows.Forms.Padding(4);
            this.pageStatus.Name = "pageStatus";
            this.pageStatus.Padding = new System.Windows.Forms.Padding(4);
            this.pageStatus.Size = new System.Drawing.Size(192, 74);
            this.pageStatus.TabIndex = 4;
            this.pageStatus.Text = "Status";
            this.pageStatus.UseVisualStyleBackColor = true;
            // 
            // gbRMA
            // 
            this.gbRMA.BackColor = System.Drawing.Color.White;
            this.gbRMA.Controls.Add(this.cmdVendorRMA);
            this.gbRMA.Controls.Add(this.gbGo);
            this.gbRMA.Controls.Add(this.gbStatus);
            this.gbRMA.Controls.Add(this.gbVendor);
            this.gbRMA.Controls.Add(this.cboVendReimburse);
            this.gbRMA.Controls.Add(this.gbCustomer);
            this.gbRMA.Controls.Add(this.cboReimburse);
            this.gbRMA.Controls.Add(this.cboWhy);
            this.gbRMA.Location = new System.Drawing.Point(8, 7);
            this.gbRMA.Margin = new System.Windows.Forms.Padding(4);
            this.gbRMA.Name = "gbRMA";
            this.gbRMA.Padding = new System.Windows.Forms.Padding(4);
            this.gbRMA.Size = new System.Drawing.Size(744, 310);
            this.gbRMA.TabIndex = 0;
            this.gbRMA.TabStop = false;
            // 
            // cmdVendorRMA
            // 
            this.cmdVendorRMA.Location = new System.Drawing.Point(360, 255);
            this.cmdVendorRMA.Margin = new System.Windows.Forms.Padding(4);
            this.cmdVendorRMA.Name = "cmdVendorRMA";
            this.cmdVendorRMA.Size = new System.Drawing.Size(361, 34);
            this.cmdVendorRMA.TabIndex = 41;
            this.cmdVendorRMA.Text = "Vendor RMA";
            this.cmdVendorRMA.UseVisualStyleBackColor = true;
            this.cmdVendorRMA.Click += new System.EventHandler(this.cmdVendorRMA_Click);
            // 
            // gbGo
            // 
            this.gbGo.Controls.Add(this.optDiscard);
            this.gbGo.Controls.Add(this.optKeep);
            this.gbGo.Controls.Add(this.optReturn);
            this.gbGo.Location = new System.Drawing.Point(360, 138);
            this.gbGo.Margin = new System.Windows.Forms.Padding(4);
            this.gbGo.Name = "gbGo";
            this.gbGo.Padding = new System.Windows.Forms.Padding(4);
            this.gbGo.Size = new System.Drawing.Size(361, 90);
            this.gbGo.TabIndex = 17;
            this.gbGo.TabStop = false;
            this.gbGo.Text = "Where will these parts eventually go?";
            // 
            // optDiscard
            // 
            this.optDiscard.AutoSize = true;
            this.optDiscard.Location = new System.Drawing.Point(31, 65);
            this.optDiscard.Margin = new System.Windows.Forms.Padding(4);
            this.optDiscard.Name = "optDiscard";
            this.optDiscard.Size = new System.Drawing.Size(151, 17);
            this.optDiscard.TabIndex = 40;
            this.optDiscard.TabStop = true;
            this.optDiscard.Text = "The parts will be discarded";
            this.optDiscard.UseVisualStyleBackColor = true;
            // 
            // optKeep
            // 
            this.optKeep.AutoSize = true;
            this.optKeep.Location = new System.Drawing.Point(31, 44);
            this.optKeep.Margin = new System.Windows.Forms.Padding(4);
            this.optKeep.Name = "optKeep";
            this.optKeep.Size = new System.Drawing.Size(179, 17);
            this.optKeep.TabIndex = 39;
            this.optKeep.TabStop = true;
            this.optKeep.Text = "The parts will remain in our stock";
            this.optKeep.UseVisualStyleBackColor = true;
            // 
            // optReturn
            // 
            this.optReturn.AutoSize = true;
            this.optReturn.Location = new System.Drawing.Point(31, 23);
            this.optReturn.Margin = new System.Windows.Forms.Padding(4);
            this.optReturn.Name = "optReturn";
            this.optReturn.Size = new System.Drawing.Size(191, 17);
            this.optReturn.TabIndex = 38;
            this.optReturn.TabStop = true;
            this.optReturn.Text = "The parts will be sent to the vendor";
            this.optReturn.UseVisualStyleBackColor = true;
            // 
            // gbStatus
            // 
            this.gbStatus.Controls.Add(this.optNoReturn);
            this.gbStatus.Controls.Add(this.optWarehouse);
            this.gbStatus.Controls.Add(this.optShip);
            this.gbStatus.Location = new System.Drawing.Point(360, 36);
            this.gbStatus.Margin = new System.Windows.Forms.Padding(4);
            this.gbStatus.Name = "gbStatus";
            this.gbStatus.Padding = new System.Windows.Forms.Padding(4);
            this.gbStatus.Size = new System.Drawing.Size(361, 91);
            this.gbStatus.TabIndex = 16;
            this.gbStatus.TabStop = false;
            this.gbStatus.Text = "What is the current status of the parts?";
            // 
            // optNoReturn
            // 
            this.optNoReturn.AutoSize = true;
            this.optNoReturn.Location = new System.Drawing.Point(31, 65);
            this.optNoReturn.Margin = new System.Windows.Forms.Padding(4);
            this.optNoReturn.Name = "optNoReturn";
            this.optNoReturn.Size = new System.Drawing.Size(162, 17);
            this.optNoReturn.TabIndex = 37;
            this.optNoReturn.TabStop = true;
            this.optNoReturn.Text = "The parts will not be returned";
            this.optNoReturn.UseVisualStyleBackColor = true;
            // 
            // optWarehouse
            // 
            this.optWarehouse.AutoSize = true;
            this.optWarehouse.Location = new System.Drawing.Point(31, 44);
            this.optWarehouse.Margin = new System.Windows.Forms.Padding(4);
            this.optWarehouse.Name = "optWarehouse";
            this.optWarehouse.Size = new System.Drawing.Size(172, 17);
            this.optWarehouse.TabIndex = 36;
            this.optWarehouse.TabStop = true;
            this.optWarehouse.Text = "The parts are in our warehouse";
            this.optWarehouse.UseVisualStyleBackColor = true;
            // 
            // optShip
            // 
            this.optShip.AutoSize = true;
            this.optShip.Location = new System.Drawing.Point(31, 23);
            this.optShip.Margin = new System.Windows.Forms.Padding(4);
            this.optShip.Name = "optShip";
            this.optShip.Size = new System.Drawing.Size(198, 17);
            this.optShip.TabIndex = 35;
            this.optShip.TabStop = true;
            this.optShip.Text = "The parts will be shipped back to us.";
            this.optShip.UseVisualStyleBackColor = true;
            // 
            // gbVendor
            // 
            this.gbVendor.Controls.Add(this.optNoVendor);
            this.gbVendor.Controls.Add(this.optYesVendor);
            this.gbVendor.Location = new System.Drawing.Point(12, 255);
            this.gbVendor.Margin = new System.Windows.Forms.Padding(4);
            this.gbVendor.Name = "gbVendor";
            this.gbVendor.Padding = new System.Windows.Forms.Padding(4);
            this.gbVendor.Size = new System.Drawing.Size(284, 50);
            this.gbVendor.TabIndex = 15;
            this.gbVendor.TabStop = false;
            this.gbVendor.Text = "Does the vendor owe us a refund?";
            // 
            // optNoVendor
            // 
            this.optNoVendor.AutoSize = true;
            this.optNoVendor.Location = new System.Drawing.Point(159, 23);
            this.optNoVendor.Margin = new System.Windows.Forms.Padding(4);
            this.optNoVendor.Name = "optNoVendor";
            this.optNoVendor.Size = new System.Drawing.Size(39, 17);
            this.optNoVendor.TabIndex = 34;
            this.optNoVendor.TabStop = true;
            this.optNoVendor.Text = "No";
            this.optNoVendor.UseVisualStyleBackColor = true;
            // 
            // optYesVendor
            // 
            this.optYesVendor.AutoSize = true;
            this.optYesVendor.Location = new System.Drawing.Point(52, 22);
            this.optYesVendor.Margin = new System.Windows.Forms.Padding(4);
            this.optYesVendor.Name = "optYesVendor";
            this.optYesVendor.Size = new System.Drawing.Size(43, 17);
            this.optYesVendor.TabIndex = 33;
            this.optYesVendor.TabStop = true;
            this.optYesVendor.Text = "Yes";
            this.optYesVendor.UseVisualStyleBackColor = true;
            // 
            // cboVendReimburse
            // 
            this.cboVendReimburse.AllCaps = false;
            this.cboVendReimburse.AllowEdit = false;
            this.cboVendReimburse.BackColor = System.Drawing.Color.Transparent;
            this.cboVendReimburse.Bold = false;
            this.cboVendReimburse.Caption = "How will we be reimbursed?";
            this.cboVendReimburse.Changed = false;
            this.cboVendReimburse.ListName = "reimburse_method_vendor";
            this.cboVendReimburse.Location = new System.Drawing.Point(12, 198);
            this.cboVendReimburse.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.cboVendReimburse.Name = "cboVendReimburse";
            this.cboVendReimburse.SimpleList = "";
            this.cboVendReimburse.Size = new System.Drawing.Size(324, 60);
            this.cboVendReimburse.TabIndex = 32;
            this.cboVendReimburse.UseParentBackColor = true;
            this.cboVendReimburse.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboVendReimburse.zz_GlobalColor = System.Drawing.Color.Black;
            this.cboVendReimburse.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cboVendReimburse.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.cboVendReimburse.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboVendReimburse.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.cboVendReimburse.zz_OriginalDesign = true;
            this.cboVendReimburse.zz_ShowNeedsSaveColor = true;
            this.cboVendReimburse.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.cboVendReimburse.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboVendReimburse.zz_UseGlobalColor = false;
            this.cboVendReimburse.zz_UseGlobalFont = false;
            // 
            // gbCustomer
            // 
            this.gbCustomer.Controls.Add(this.optNoCustomer);
            this.gbCustomer.Controls.Add(this.optYesCustomer);
            this.gbCustomer.Location = new System.Drawing.Point(12, 145);
            this.gbCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.gbCustomer.Name = "gbCustomer";
            this.gbCustomer.Padding = new System.Windows.Forms.Padding(4);
            this.gbCustomer.Size = new System.Drawing.Size(284, 50);
            this.gbCustomer.TabIndex = 30;
            this.gbCustomer.TabStop = false;
            this.gbCustomer.Text = "Is the customer due a refund?";
            // 
            // optNoCustomer
            // 
            this.optNoCustomer.AutoSize = true;
            this.optNoCustomer.Location = new System.Drawing.Point(159, 23);
            this.optNoCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.optNoCustomer.Name = "optNoCustomer";
            this.optNoCustomer.Size = new System.Drawing.Size(39, 17);
            this.optNoCustomer.TabIndex = 31;
            this.optNoCustomer.TabStop = true;
            this.optNoCustomer.Text = "No";
            this.optNoCustomer.UseVisualStyleBackColor = true;
            // 
            // optYesCustomer
            // 
            this.optYesCustomer.AutoSize = true;
            this.optYesCustomer.Location = new System.Drawing.Point(52, 22);
            this.optYesCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.optYesCustomer.Name = "optYesCustomer";
            this.optYesCustomer.Size = new System.Drawing.Size(43, 17);
            this.optYesCustomer.TabIndex = 30;
            this.optYesCustomer.TabStop = true;
            this.optYesCustomer.Text = "Yes";
            this.optYesCustomer.UseVisualStyleBackColor = true;
            // 
            // cboReimburse
            // 
            this.cboReimburse.AllCaps = false;
            this.cboReimburse.AllowEdit = false;
            this.cboReimburse.BackColor = System.Drawing.Color.Transparent;
            this.cboReimburse.Bold = false;
            this.cboReimburse.Caption = "How should the customer be reimbursed?";
            this.cboReimburse.Changed = false;
            this.cboReimburse.ListName = "reimburse_method_customer";
            this.cboReimburse.Location = new System.Drawing.Point(8, 82);
            this.cboReimburse.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.cboReimburse.Name = "cboReimburse";
            this.cboReimburse.SimpleList = "";
            this.cboReimburse.Size = new System.Drawing.Size(365, 36);
            this.cboReimburse.TabIndex = 29;
            this.cboReimburse.UseParentBackColor = true;
            this.cboReimburse.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboReimburse.zz_GlobalColor = System.Drawing.Color.Black;
            this.cboReimburse.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cboReimburse.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.cboReimburse.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboReimburse.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.cboReimburse.zz_OriginalDesign = false;
            this.cboReimburse.zz_ShowNeedsSaveColor = true;
            this.cboReimburse.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.cboReimburse.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboReimburse.zz_UseGlobalColor = false;
            this.cboReimburse.zz_UseGlobalFont = false;
            // 
            // cboWhy
            // 
            this.cboWhy.AllCaps = false;
            this.cboWhy.AllowEdit = false;
            this.cboWhy.BackColor = System.Drawing.Color.Transparent;
            this.cboWhy.Bold = false;
            this.cboWhy.Caption = "Why are these parts being returned?";
            this.cboWhy.Changed = false;
            this.cboWhy.ListName = "rma_reason";
            this.cboWhy.Location = new System.Drawing.Point(8, 23);
            this.cboWhy.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.cboWhy.Name = "cboWhy";
            this.cboWhy.SimpleList = "";
            this.cboWhy.Size = new System.Drawing.Size(324, 36);
            this.cboWhy.TabIndex = 28;
            this.cboWhy.UseParentBackColor = true;
            this.cboWhy.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboWhy.zz_GlobalColor = System.Drawing.Color.Black;
            this.cboWhy.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cboWhy.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.cboWhy.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboWhy.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.cboWhy.zz_OriginalDesign = false;
            this.cboWhy.zz_ShowNeedsSaveColor = true;
            this.cboWhy.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.cboWhy.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboWhy.zz_UseGlobalColor = false;
            this.cboWhy.zz_UseGlobalFont = false;
            // 
            // pageNotify
            // 
            this.pageNotify.Controls.Add(this.chkNotifyReceive);
            this.pageNotify.Controls.Add(this.chkNotifyShip);
            this.pageNotify.Controls.Add(this.label1);
            this.pageNotify.Controls.Add(this.chkConfirmReceive);
            this.pageNotify.Controls.Add(this.chkConfirmShip);
            this.pageNotify.Controls.Add(this.lblConfirmations);
            this.pageNotify.Location = new System.Drawing.Point(4, 22);
            this.pageNotify.Margin = new System.Windows.Forms.Padding(4);
            this.pageNotify.Name = "pageNotify";
            this.pageNotify.Padding = new System.Windows.Forms.Padding(4);
            this.pageNotify.Size = new System.Drawing.Size(192, 74);
            this.pageNotify.TabIndex = 5;
            this.pageNotify.Text = "Notify";
            this.pageNotify.UseVisualStyleBackColor = true;
            // 
            // chkNotifyReceive
            // 
            this.chkNotifyReceive.AutoSize = true;
            this.chkNotifyReceive.Location = new System.Drawing.Point(43, 164);
            this.chkNotifyReceive.Margin = new System.Windows.Forms.Padding(4);
            this.chkNotifyReceive.Name = "chkNotifyReceive";
            this.chkNotifyReceive.Size = new System.Drawing.Size(260, 17);
            this.chkNotifyReceive.TabIndex = 54;
            this.chkNotifyReceive.Tag = "NotifyReceive";
            this.chkNotifyReceive.Text = "Notify the sales agent when this order is received.";
            this.chkNotifyReceive.UseVisualStyleBackColor = true;
            // 
            // chkNotifyShip
            // 
            this.chkNotifyShip.AutoSize = true;
            this.chkNotifyShip.Location = new System.Drawing.Point(43, 142);
            this.chkNotifyShip.Margin = new System.Windows.Forms.Padding(4);
            this.chkNotifyShip.Name = "chkNotifyShip";
            this.chkNotifyShip.Size = new System.Drawing.Size(233, 17);
            this.chkNotifyShip.TabIndex = 53;
            this.chkNotifyShip.Tag = "NotifyShip";
            this.chkNotifyShip.Text = "Notify the sales agent when this order ships.";
            this.chkNotifyShip.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 101);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(659, 41);
            this.label1.TabIndex = 3;
            this.label1.Text = "Notifications: These options will automatically notify the sales agent when the a" +
    "ssociated action is taken.";
            // 
            // chkConfirmReceive
            // 
            this.chkConfirmReceive.AutoSize = true;
            this.chkConfirmReceive.Location = new System.Drawing.Point(43, 69);
            this.chkConfirmReceive.Margin = new System.Windows.Forms.Padding(4);
            this.chkConfirmReceive.Name = "chkConfirmReceive";
            this.chkConfirmReceive.Size = new System.Drawing.Size(307, 17);
            this.chkConfirmReceive.TabIndex = 52;
            this.chkConfirmReceive.Tag = "ConfirmReceive";
            this.chkConfirmReceive.Text = "Confirm with the sales agent when these parts are received.";
            this.chkConfirmReceive.UseVisualStyleBackColor = true;
            // 
            // chkConfirmShip
            // 
            this.chkConfirmShip.AutoSize = true;
            this.chkConfirmShip.Location = new System.Drawing.Point(43, 48);
            this.chkConfirmShip.Margin = new System.Windows.Forms.Padding(4);
            this.chkConfirmShip.Name = "chkConfirmShip";
            this.chkConfirmShip.Size = new System.Drawing.Size(267, 17);
            this.chkConfirmShip.TabIndex = 51;
            this.chkConfirmShip.Tag = "ConfirmShip";
            this.chkConfirmShip.Text = "Confirm with the sales agent before this order ships.";
            this.chkConfirmShip.UseVisualStyleBackColor = true;
            // 
            // lblConfirmations
            // 
            this.lblConfirmations.Location = new System.Drawing.Point(8, 11);
            this.lblConfirmations.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConfirmations.Name = "lblConfirmations";
            this.lblConfirmations.Size = new System.Drawing.Size(659, 41);
            this.lblConfirmations.TabIndex = 0;
            this.lblConfirmations.Text = "Confirmations: These options require the warehouse staff to contact the sales age" +
    "nt before performing the associated action.";
            // 
            // pagePictures
            // 
            this.pagePictures.Controls.Add(this.picview);
            this.pagePictures.Location = new System.Drawing.Point(4, 22);
            this.pagePictures.Margin = new System.Windows.Forms.Padding(4);
            this.pagePictures.Name = "pagePictures";
            this.pagePictures.Padding = new System.Windows.Forms.Padding(4);
            this.pagePictures.Size = new System.Drawing.Size(192, 74);
            this.pagePictures.TabIndex = 6;
            this.pagePictures.Text = "Attachments";
            this.pagePictures.UseVisualStyleBackColor = true;
            // 
            // picview
            // 
            this.picview.BackColor = System.Drawing.Color.White;
            this.picview.Caption = "Rz4 PictureViewer";
            this.picview.DisablePartLink = false;
            this.picview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picview.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.picview.Location = new System.Drawing.Point(4, 4);
            this.picview.Margin = new System.Windows.Forms.Padding(4);
            this.picview.Name = "picview";
            this.picview.ShowFullScreenButton = true;
            this.picview.ShowPartNumberLink = false;
            this.picview.ShowPartSearch = false;
            this.picview.ShowZoomButton = true;
            this.picview.Size = new System.Drawing.Size(360, 66);
            this.picview.TabIndex = 0;
            this.picview.TemplateName = "PartPictureViewer";
            // 
            // pageAuthorize
            // 
            this.pageAuthorize.Controls.Add(this.cmdAuthorize);
            this.pageAuthorize.Controls.Add(this.ctl_authorized_number);
            this.pageAuthorize.Controls.Add(this.ctl_authorized_date);
            this.pageAuthorize.Controls.Add(this.ctl_is_authorized);
            this.pageAuthorize.Location = new System.Drawing.Point(4, 22);
            this.pageAuthorize.Margin = new System.Windows.Forms.Padding(4);
            this.pageAuthorize.Name = "pageAuthorize";
            this.pageAuthorize.Padding = new System.Windows.Forms.Padding(4);
            this.pageAuthorize.Size = new System.Drawing.Size(192, 74);
            this.pageAuthorize.TabIndex = 7;
            this.pageAuthorize.Text = "Authorization";
            this.pageAuthorize.UseVisualStyleBackColor = true;
            // 
            // cmdAuthorize
            // 
            this.cmdAuthorize.Location = new System.Drawing.Point(11, 169);
            this.cmdAuthorize.Margin = new System.Windows.Forms.Padding(4);
            this.cmdAuthorize.Name = "cmdAuthorize";
            this.cmdAuthorize.Size = new System.Drawing.Size(169, 36);
            this.cmdAuthorize.TabIndex = 3;
            this.cmdAuthorize.Text = "Authorize";
            this.cmdAuthorize.UseVisualStyleBackColor = true;
            // 
            // ctl_authorized_number
            // 
            this.ctl_authorized_number.BackColor = System.Drawing.Color.Transparent;
            this.ctl_authorized_number.Bold = false;
            this.ctl_authorized_number.Caption = "Authorization Number";
            this.ctl_authorized_number.Changed = false;
            this.ctl_authorized_number.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_authorized_number.Enabled = false;
            this.ctl_authorized_number.Location = new System.Drawing.Point(11, 113);
            this.ctl_authorized_number.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_authorized_number.Name = "ctl_authorized_number";
            this.ctl_authorized_number.Size = new System.Drawing.Size(169, 58);
            this.ctl_authorized_number.TabIndex = 2;
            this.ctl_authorized_number.UseParentBackColor = true;
            this.ctl_authorized_number.zz_Enabled = true;
            this.ctl_authorized_number.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_authorized_number.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_authorized_number.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_authorized_number.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_authorized_number.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_authorized_number.zz_OriginalDesign = true;
            this.ctl_authorized_number.zz_ShowErrorColor = true;
            this.ctl_authorized_number.zz_ShowNeedsSaveColor = true;
            this.ctl_authorized_number.zz_Text = "";
            this.ctl_authorized_number.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_authorized_number.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_authorized_number.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_authorized_number.zz_UseGlobalColor = false;
            this.ctl_authorized_number.zz_UseGlobalFont = false;
            // 
            // ctl_authorized_date
            // 
            this.ctl_authorized_date.AllowClear = false;
            this.ctl_authorized_date.BackColor = System.Drawing.Color.Transparent;
            this.ctl_authorized_date.Bold = false;
            this.ctl_authorized_date.Caption = "Authorized Date";
            this.ctl_authorized_date.Changed = false;
            this.ctl_authorized_date.Enabled = false;
            this.ctl_authorized_date.Location = new System.Drawing.Point(8, 49);
            this.ctl_authorized_date.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_authorized_date.Name = "ctl_authorized_date";
            this.ctl_authorized_date.Size = new System.Drawing.Size(172, 66);
            this.ctl_authorized_date.SuppressEdit = false;
            this.ctl_authorized_date.TabIndex = 1;
            this.ctl_authorized_date.UseParentBackColor = true;
            this.ctl_authorized_date.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_authorized_date.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_authorized_date.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_authorized_date.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_authorized_date.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctl_authorized_date.zz_OriginalDesign = true;
            this.ctl_authorized_date.zz_ShowNeedsSaveColor = true;
            this.ctl_authorized_date.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_authorized_date.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_authorized_date.zz_UseGlobalColor = false;
            this.ctl_authorized_date.zz_UseGlobalFont = false;
            // 
            // ctl_is_authorized
            // 
            this.ctl_is_authorized.BackColor = System.Drawing.Color.Transparent;
            this.ctl_is_authorized.Bold = false;
            this.ctl_is_authorized.Caption = "Authorized";
            this.ctl_is_authorized.Changed = false;
            this.ctl_is_authorized.Enabled = false;
            this.ctl_is_authorized.Location = new System.Drawing.Point(8, 9);
            this.ctl_is_authorized.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_is_authorized.Name = "ctl_is_authorized";
            this.ctl_is_authorized.Size = new System.Drawing.Size(76, 18);
            this.ctl_is_authorized.TabIndex = 0;
            this.ctl_is_authorized.UseParentBackColor = true;
            this.ctl_is_authorized.zz_CheckValue = false;
            this.ctl_is_authorized.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_is_authorized.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_is_authorized.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_is_authorized.zz_OriginalDesign = false;
            this.ctl_is_authorized.zz_ShowNeedsSaveColor = true;
            // 
            // pageDeductions
            // 
            this.pageDeductions.Controls.Add(this.lstHits);
            this.pageDeductions.Location = new System.Drawing.Point(4, 22);
            this.pageDeductions.Margin = new System.Windows.Forms.Padding(4);
            this.pageDeductions.Name = "pageDeductions";
            this.pageDeductions.Padding = new System.Windows.Forms.Padding(4);
            this.pageDeductions.Size = new System.Drawing.Size(192, 74);
            this.pageDeductions.TabIndex = 8;
            this.pageDeductions.Text = "Deductions";
            this.pageDeductions.UseVisualStyleBackColor = true;
            // 
            // lstHits
            // 
            this.lstHits.AddCaption = "Add New Deduction";
            this.lstHits.AllowActions = true;
            this.lstHits.AllowAdd = true;
            this.lstHits.AllowDelete = true;
            this.lstHits.AllowDeleteAlways = false;
            this.lstHits.AllowDrop = true;
            this.lstHits.AllowOnlyOpenDelete = false;
            this.lstHits.AlternateConnection = null;
            this.lstHits.BackColor = System.Drawing.Color.White;
            this.lstHits.Caption = "";
            this.lstHits.CurrentTemplate = null;
            this.lstHits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstHits.ExtraClassInfo = "";
            this.lstHits.Location = new System.Drawing.Point(4, 4);
            this.lstHits.Margin = new System.Windows.Forms.Padding(5);
            this.lstHits.MultiSelect = true;
            this.lstHits.Name = "lstHits";
            this.lstHits.Size = new System.Drawing.Size(184, 66);
            this.lstHits.SuppressSelectionChanged = false;
            this.lstHits.TabIndex = 0;
            this.lstHits.zz_OpenColumnMenu = false;
            this.lstHits.zz_OrderLineType = "";
            this.lstHits.zz_ShowAutoRefresh = false;
            this.lstHits.zz_ShowUnlimited = false;
            this.lstHits.AboutToAdd += new NewMethod.AddHandler(this.lstHits_AboutToAdd);
            // 
            // pageEmails
            // 
            this.pageEmails.Controls.Add(this.lvLinkedEmails);
            this.pageEmails.Location = new System.Drawing.Point(4, 22);
            this.pageEmails.Margin = new System.Windows.Forms.Padding(4);
            this.pageEmails.Name = "pageEmails";
            this.pageEmails.Size = new System.Drawing.Size(192, 74);
            this.pageEmails.TabIndex = 9;
            this.pageEmails.Text = "Emails";
            this.pageEmails.UseVisualStyleBackColor = true;
            // 
            // lvLinkedEmails
            // 
            this.lvLinkedEmails.AddCaption = "Add Email";
            this.lvLinkedEmails.AllowActions = true;
            this.lvLinkedEmails.AllowAdd = false;
            this.lvLinkedEmails.AllowDelete = true;
            this.lvLinkedEmails.AllowDeleteAlways = false;
            this.lvLinkedEmails.AllowDrop = true;
            this.lvLinkedEmails.AllowOnlyOpenDelete = false;
            this.lvLinkedEmails.AlternateConnection = null;
            this.lvLinkedEmails.BackColor = System.Drawing.Color.White;
            this.lvLinkedEmails.Caption = "";
            this.lvLinkedEmails.CurrentTemplate = null;
            this.lvLinkedEmails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLinkedEmails.ExtraClassInfo = "";
            this.lvLinkedEmails.Location = new System.Drawing.Point(0, 0);
            this.lvLinkedEmails.Margin = new System.Windows.Forms.Padding(5);
            this.lvLinkedEmails.MultiSelect = true;
            this.lvLinkedEmails.Name = "lvLinkedEmails";
            this.lvLinkedEmails.Size = new System.Drawing.Size(192, 74);
            this.lvLinkedEmails.SuppressSelectionChanged = false;
            this.lvLinkedEmails.TabIndex = 0;
            this.lvLinkedEmails.zz_OpenColumnMenu = false;
            this.lvLinkedEmails.zz_OrderLineType = "";
            this.lvLinkedEmails.zz_ShowAutoRefresh = true;
            this.lvLinkedEmails.zz_ShowUnlimited = true;
            this.lvLinkedEmails.AboutToThrow += new Core.ShowHandler(this.lvLinkedEmails_AboutToThrow);
            this.lvLinkedEmails.AboutToAdd += new NewMethod.AddHandler(this.lvLinkedEmails_AboutToAdd);
            this.lvLinkedEmails.FinishedFill += new NewMethod.FillHandler(this.lvLinkedEmails_FinishedFill);
            this.lvLinkedEmails.DragDrop += new NewMethod.nListItemDragDropHandler(this.lvLinkedEmails_DragDrop);
            this.lvLinkedEmails.DragEnter += new NewMethod.nListItemDragDropHandler(this.lvLinkedEmails_DragEnter);
            this.lvLinkedEmails.DragOver += new NewMethod.nListItemDragDropHandler(this.lvLinkedEmails_DragOver);
            // 
            // tabCreditCard
            // 
            this.tabCreditCard.Controls.Add(this.ctl_securitycode);
            this.tabCreditCard.Controls.Add(this.cmdGrabCreditCardInfo);
            this.tabCreditCard.Controls.Add(this.label4);
            this.tabCreditCard.Controls.Add(this.cmdUpdateCustCreditCardInfo);
            this.tabCreditCard.Controls.Add(this.ctl_nameoncard);
            this.tabCreditCard.Controls.Add(this.ctl_cardbillingzip);
            this.tabCreditCard.Controls.Add(this.ctl_cardbillingaddr);
            this.tabCreditCard.Controls.Add(this.label3);
            this.tabCreditCard.Controls.Add(this.label2);
            this.tabCreditCard.Controls.Add(this.ctl_expiration_year);
            this.tabCreditCard.Controls.Add(this.ctl_expiration_month);
            this.tabCreditCard.Controls.Add(this.ctl_creditcardtype);
            this.tabCreditCard.Controls.Add(this.ctl_creditcardnumber);
            this.tabCreditCard.Location = new System.Drawing.Point(4, 22);
            this.tabCreditCard.Margin = new System.Windows.Forms.Padding(4);
            this.tabCreditCard.Name = "tabCreditCard";
            this.tabCreditCard.Size = new System.Drawing.Size(192, 74);
            this.tabCreditCard.TabIndex = 10;
            this.tabCreditCard.Text = "Credit Card Info";
            this.tabCreditCard.UseVisualStyleBackColor = true;
            // 
            // ctl_securitycode
            // 
            this.ctl_securitycode.AllCaps = false;
            this.ctl_securitycode.BackColor = System.Drawing.Color.Transparent;
            this.ctl_securitycode.Bold = false;
            this.ctl_securitycode.Caption = "Security Code";
            this.ctl_securitycode.Changed = false;
            this.ctl_securitycode.IsEmail = false;
            this.ctl_securitycode.IsURL = false;
            this.ctl_securitycode.Location = new System.Drawing.Point(377, 105);
            this.ctl_securitycode.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_securitycode.Name = "ctl_securitycode";
            this.ctl_securitycode.PasswordChar = '\0';
            this.ctl_securitycode.Size = new System.Drawing.Size(176, 47);
            this.ctl_securitycode.TabIndex = 37;
            this.ctl_securitycode.UseParentBackColor = true;
            this.ctl_securitycode.zz_Enabled = true;
            this.ctl_securitycode.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_securitycode.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_securitycode.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_securitycode.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_securitycode.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_securitycode.zz_OriginalDesign = false;
            this.ctl_securitycode.zz_ShowLinkButton = false;
            this.ctl_securitycode.zz_ShowNeedsSaveColor = true;
            this.ctl_securitycode.zz_Text = "";
            this.ctl_securitycode.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_securitycode.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_securitycode.zz_TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_securitycode.zz_UseGlobalColor = false;
            this.ctl_securitycode.zz_UseGlobalFont = false;
            // 
            // cmdGrabCreditCardInfo
            // 
            this.cmdGrabCreditCardInfo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGrabCreditCardInfo.Location = new System.Drawing.Point(427, 279);
            this.cmdGrabCreditCardInfo.Margin = new System.Windows.Forms.Padding(4);
            this.cmdGrabCreditCardInfo.Name = "cmdGrabCreditCardInfo";
            this.cmdGrabCreditCardInfo.Size = new System.Drawing.Size(329, 36);
            this.cmdGrabCreditCardInfo.TabIndex = 44;
            this.cmdGrabCreditCardInfo.Text = "Load Card Info From Company";
            this.cmdGrabCreditCardInfo.UseVisualStyleBackColor = true;
            this.cmdGrabCreditCardInfo.Click += new System.EventHandler(this.cmdGrabCreditCardInfo_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Location = new System.Drawing.Point(4, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(752, 38);
            this.label4.TabIndex = 46;
            this.label4.Text = resources.GetString("label4.Text");
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmdUpdateCustCreditCardInfo
            // 
            this.cmdUpdateCustCreditCardInfo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdUpdateCustCreditCardInfo.Location = new System.Drawing.Point(4, 279);
            this.cmdUpdateCustCreditCardInfo.Margin = new System.Windows.Forms.Padding(4);
            this.cmdUpdateCustCreditCardInfo.Name = "cmdUpdateCustCreditCardInfo";
            this.cmdUpdateCustCreditCardInfo.Size = new System.Drawing.Size(415, 36);
            this.cmdUpdateCustCreditCardInfo.TabIndex = 43;
            this.cmdUpdateCustCreditCardInfo.Text = "Update Customer Credit Card Information";
            this.cmdUpdateCustCreditCardInfo.UseVisualStyleBackColor = true;
            this.cmdUpdateCustCreditCardInfo.Click += new System.EventHandler(this.cmdUpdateCustCreditCardInfo_Click);
            // 
            // ctl_nameoncard
            // 
            this.ctl_nameoncard.AllCaps = false;
            this.ctl_nameoncard.BackColor = System.Drawing.Color.Transparent;
            this.ctl_nameoncard.Bold = false;
            this.ctl_nameoncard.Caption = "Name On Card";
            this.ctl_nameoncard.Changed = false;
            this.ctl_nameoncard.IsEmail = false;
            this.ctl_nameoncard.IsURL = false;
            this.ctl_nameoncard.Location = new System.Drawing.Point(4, 161);
            this.ctl_nameoncard.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_nameoncard.Name = "ctl_nameoncard";
            this.ctl_nameoncard.PasswordChar = '\0';
            this.ctl_nameoncard.Size = new System.Drawing.Size(752, 47);
            this.ctl_nameoncard.TabIndex = 40;
            this.ctl_nameoncard.UseParentBackColor = true;
            this.ctl_nameoncard.zz_Enabled = true;
            this.ctl_nameoncard.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_nameoncard.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_nameoncard.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_nameoncard.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_nameoncard.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_nameoncard.zz_OriginalDesign = false;
            this.ctl_nameoncard.zz_ShowLinkButton = false;
            this.ctl_nameoncard.zz_ShowNeedsSaveColor = true;
            this.ctl_nameoncard.zz_Text = "";
            this.ctl_nameoncard.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_nameoncard.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_nameoncard.zz_TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_nameoncard.zz_UseGlobalColor = false;
            this.ctl_nameoncard.zz_UseGlobalFont = false;
            // 
            // ctl_cardbillingzip
            // 
            this.ctl_cardbillingzip.AllCaps = false;
            this.ctl_cardbillingzip.BackColor = System.Drawing.Color.Transparent;
            this.ctl_cardbillingzip.Bold = false;
            this.ctl_cardbillingzip.Caption = "Card Billing Zip";
            this.ctl_cardbillingzip.Changed = false;
            this.ctl_cardbillingzip.IsEmail = false;
            this.ctl_cardbillingzip.IsURL = false;
            this.ctl_cardbillingzip.Location = new System.Drawing.Point(561, 218);
            this.ctl_cardbillingzip.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_cardbillingzip.Name = "ctl_cardbillingzip";
            this.ctl_cardbillingzip.PasswordChar = '\0';
            this.ctl_cardbillingzip.Size = new System.Drawing.Size(195, 47);
            this.ctl_cardbillingzip.TabIndex = 42;
            this.ctl_cardbillingzip.UseParentBackColor = true;
            this.ctl_cardbillingzip.zz_Enabled = true;
            this.ctl_cardbillingzip.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_cardbillingzip.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_cardbillingzip.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_cardbillingzip.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_cardbillingzip.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_cardbillingzip.zz_OriginalDesign = false;
            this.ctl_cardbillingzip.zz_ShowLinkButton = false;
            this.ctl_cardbillingzip.zz_ShowNeedsSaveColor = true;
            this.ctl_cardbillingzip.zz_Text = "";
            this.ctl_cardbillingzip.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_cardbillingzip.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_cardbillingzip.zz_TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_cardbillingzip.zz_UseGlobalColor = false;
            this.ctl_cardbillingzip.zz_UseGlobalFont = false;
            // 
            // ctl_cardbillingaddr
            // 
            this.ctl_cardbillingaddr.AllCaps = false;
            this.ctl_cardbillingaddr.BackColor = System.Drawing.Color.Transparent;
            this.ctl_cardbillingaddr.Bold = false;
            this.ctl_cardbillingaddr.Caption = "Card Billing Address";
            this.ctl_cardbillingaddr.Changed = false;
            this.ctl_cardbillingaddr.IsEmail = false;
            this.ctl_cardbillingaddr.IsURL = false;
            this.ctl_cardbillingaddr.Location = new System.Drawing.Point(4, 218);
            this.ctl_cardbillingaddr.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_cardbillingaddr.Name = "ctl_cardbillingaddr";
            this.ctl_cardbillingaddr.PasswordChar = '\0';
            this.ctl_cardbillingaddr.Size = new System.Drawing.Size(549, 47);
            this.ctl_cardbillingaddr.TabIndex = 41;
            this.ctl_cardbillingaddr.UseParentBackColor = true;
            this.ctl_cardbillingaddr.zz_Enabled = true;
            this.ctl_cardbillingaddr.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_cardbillingaddr.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_cardbillingaddr.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_cardbillingaddr.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_cardbillingaddr.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_cardbillingaddr.zz_OriginalDesign = false;
            this.ctl_cardbillingaddr.zz_ShowLinkButton = false;
            this.ctl_cardbillingaddr.zz_ShowNeedsSaveColor = true;
            this.ctl_cardbillingaddr.zz_Text = "";
            this.ctl_cardbillingaddr.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_cardbillingaddr.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_cardbillingaddr.zz_TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_cardbillingaddr.zz_UseGlobalColor = false;
            this.ctl_cardbillingaddr.zz_UseGlobalFont = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(631, 130);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 26);
            this.label3.TabIndex = 41;
            this.label3.Text = "/";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(584, 103);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 19);
            this.label2.TabIndex = 40;
            this.label2.Text = "Expiration Date";
            // 
            // ctl_expiration_year
            // 
            this.ctl_expiration_year.BackColor = System.Drawing.Color.Transparent;
            this.ctl_expiration_year.Bold = false;
            this.ctl_expiration_year.Caption = "";
            this.ctl_expiration_year.Changed = true;
            this.ctl_expiration_year.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_expiration_year.Location = new System.Drawing.Point(664, 128);
            this.ctl_expiration_year.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_expiration_year.Name = "ctl_expiration_year";
            this.ctl_expiration_year.Size = new System.Drawing.Size(92, 28);
            this.ctl_expiration_year.TabIndex = 39;
            this.ctl_expiration_year.UseParentBackColor = false;
            this.ctl_expiration_year.zz_Enabled = true;
            this.ctl_expiration_year.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_expiration_year.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_expiration_year.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_expiration_year.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_expiration_year.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_expiration_year.zz_OriginalDesign = false;
            this.ctl_expiration_year.zz_ShowErrorColor = true;
            this.ctl_expiration_year.zz_ShowNeedsSaveColor = true;
            this.ctl_expiration_year.zz_Text = "";
            this.ctl_expiration_year.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ctl_expiration_year.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_expiration_year.zz_TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_expiration_year.zz_UseGlobalColor = false;
            this.ctl_expiration_year.zz_UseGlobalFont = false;
            // 
            // ctl_expiration_month
            // 
            this.ctl_expiration_month.BackColor = System.Drawing.Color.Transparent;
            this.ctl_expiration_month.Bold = false;
            this.ctl_expiration_month.Caption = "";
            this.ctl_expiration_month.Changed = true;
            this.ctl_expiration_month.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_expiration_month.Location = new System.Drawing.Point(561, 128);
            this.ctl_expiration_month.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_expiration_month.Name = "ctl_expiration_month";
            this.ctl_expiration_month.Size = new System.Drawing.Size(57, 28);
            this.ctl_expiration_month.TabIndex = 38;
            this.ctl_expiration_month.UseParentBackColor = false;
            this.ctl_expiration_month.zz_Enabled = true;
            this.ctl_expiration_month.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_expiration_month.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_expiration_month.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_expiration_month.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_expiration_month.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_expiration_month.zz_OriginalDesign = false;
            this.ctl_expiration_month.zz_ShowErrorColor = true;
            this.ctl_expiration_month.zz_ShowNeedsSaveColor = true;
            this.ctl_expiration_month.zz_Text = "";
            this.ctl_expiration_month.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ctl_expiration_month.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_expiration_month.zz_TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_expiration_month.zz_UseGlobalColor = false;
            this.ctl_expiration_month.zz_UseGlobalFont = false;
            // 
            // ctl_creditcardtype
            // 
            this.ctl_creditcardtype.AllCaps = false;
            this.ctl_creditcardtype.AllowEdit = true;
            this.ctl_creditcardtype.BackColor = System.Drawing.Color.Transparent;
            this.ctl_creditcardtype.Bold = false;
            this.ctl_creditcardtype.Caption = "Credit Card Type";
            this.ctl_creditcardtype.Changed = false;
            this.ctl_creditcardtype.ListName = "creditcardtypes";
            this.ctl_creditcardtype.Location = new System.Drawing.Point(3, 103);
            this.ctl_creditcardtype.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_creditcardtype.Name = "ctl_creditcardtype";
            this.ctl_creditcardtype.SimpleList = null;
            this.ctl_creditcardtype.Size = new System.Drawing.Size(367, 48);
            this.ctl_creditcardtype.TabIndex = 36;
            this.ctl_creditcardtype.UseParentBackColor = false;
            this.ctl_creditcardtype.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_creditcardtype.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_creditcardtype.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_creditcardtype.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_creditcardtype.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_creditcardtype.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_creditcardtype.zz_OriginalDesign = false;
            this.ctl_creditcardtype.zz_ShowNeedsSaveColor = true;
            this.ctl_creditcardtype.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_creditcardtype.zz_TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_creditcardtype.zz_UseGlobalColor = false;
            this.ctl_creditcardtype.zz_UseGlobalFont = false;
            // 
            // ctl_creditcardnumber
            // 
            this.ctl_creditcardnumber.AllCaps = false;
            this.ctl_creditcardnumber.BackColor = System.Drawing.Color.Transparent;
            this.ctl_creditcardnumber.Bold = false;
            this.ctl_creditcardnumber.Caption = "Credit Card Number";
            this.ctl_creditcardnumber.Changed = false;
            this.ctl_creditcardnumber.IsEmail = false;
            this.ctl_creditcardnumber.IsURL = false;
            this.ctl_creditcardnumber.Location = new System.Drawing.Point(4, 47);
            this.ctl_creditcardnumber.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_creditcardnumber.Name = "ctl_creditcardnumber";
            this.ctl_creditcardnumber.PasswordChar = '\0';
            this.ctl_creditcardnumber.Size = new System.Drawing.Size(752, 47);
            this.ctl_creditcardnumber.TabIndex = 35;
            this.ctl_creditcardnumber.UseParentBackColor = true;
            this.ctl_creditcardnumber.zz_Enabled = true;
            this.ctl_creditcardnumber.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_creditcardnumber.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_creditcardnumber.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_creditcardnumber.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_creditcardnumber.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_creditcardnumber.zz_OriginalDesign = false;
            this.ctl_creditcardnumber.zz_ShowLinkButton = false;
            this.ctl_creditcardnumber.zz_ShowNeedsSaveColor = true;
            this.ctl_creditcardnumber.zz_Text = "";
            this.ctl_creditcardnumber.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_creditcardnumber.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_creditcardnumber.zz_TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_creditcardnumber.zz_UseGlobalColor = false;
            this.ctl_creditcardnumber.zz_UseGlobalFont = false;
            // 
            // tabProcurement
            // 
            this.tabProcurement.Controls.Add(this.lvProcurement);
            this.tabProcurement.Location = new System.Drawing.Point(4, 22);
            this.tabProcurement.Margin = new System.Windows.Forms.Padding(4);
            this.tabProcurement.Name = "tabProcurement";
            this.tabProcurement.Size = new System.Drawing.Size(192, 74);
            this.tabProcurement.TabIndex = 11;
            this.tabProcurement.Text = "Procurement History";
            this.tabProcurement.UseVisualStyleBackColor = true;
            // 
            // lvProcurement
            // 
            this.lvProcurement.AddCaption = "Add New";
            this.lvProcurement.AllowActions = true;
            this.lvProcurement.AllowAdd = false;
            this.lvProcurement.AllowDelete = true;
            this.lvProcurement.AllowDeleteAlways = false;
            this.lvProcurement.AllowDrop = true;
            this.lvProcurement.AllowOnlyOpenDelete = false;
            this.lvProcurement.AlternateConnection = null;
            this.lvProcurement.BackColor = System.Drawing.Color.White;
            this.lvProcurement.Caption = "";
            this.lvProcurement.CurrentTemplate = null;
            this.lvProcurement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProcurement.ExtraClassInfo = "";
            this.lvProcurement.Location = new System.Drawing.Point(0, 0);
            this.lvProcurement.Margin = new System.Windows.Forms.Padding(5);
            this.lvProcurement.MultiSelect = true;
            this.lvProcurement.Name = "lvProcurement";
            this.lvProcurement.Size = new System.Drawing.Size(192, 74);
            this.lvProcurement.SuppressSelectionChanged = false;
            this.lvProcurement.TabIndex = 0;
            this.lvProcurement.zz_OpenColumnMenu = false;
            this.lvProcurement.zz_OrderLineType = "";
            this.lvProcurement.zz_ShowAutoRefresh = false;
            this.lvProcurement.zz_ShowUnlimited = false;
            this.lvProcurement.AboutToThrow += new Core.ShowHandler(this.lvProcurement_AboutToThrow);
            // 
            // gbTotals
            // 
            this.gbTotals.BackColor = System.Drawing.Color.White;
            this.gbTotals.Controls.Add(this.ctl_invoice_number);
            this.gbTotals.Controls.Add(this.lblTotal);
            this.gbTotals.Controls.Add(this.ctl_taxamount);
            this.gbTotals.Controls.Add(this.ctl_handlingamount);
            this.gbTotals.Controls.Add(this.ctl_shippingamount);
            this.gbTotals.Controls.Add(this.ctl_charged_amount);
            this.gbTotals.Controls.Add(this.ctl_invoice_date);
            this.gbTotals.Controls.Add(this.lblPaid);
            this.gbTotals.Controls.Add(this.lblOutstanding);
            this.gbTotals.Controls.Add(this.lblPaidAmount);
            this.gbTotals.Controls.Add(this.ctl_subtract_3);
            this.gbTotals.Controls.Add(this.ctl_subtract_2);
            this.gbTotals.Controls.Add(this.ctl_subtract_1);
            this.gbTotals.Controls.Add(this.optOther);
            this.gbTotals.Controls.Add(this.optFees);
            this.gbTotals.Controls.Add(this.lblSubTotal);
            this.gbTotals.Location = new System.Drawing.Point(789, 32);
            this.gbTotals.Margin = new System.Windows.Forms.Padding(4);
            this.gbTotals.Name = "gbTotals";
            this.gbTotals.Padding = new System.Windows.Forms.Padding(4);
            this.gbTotals.Size = new System.Drawing.Size(208, 446);
            this.gbTotals.TabIndex = 8;
            this.gbTotals.TabStop = false;
            // 
            // ctl_invoice_number
            // 
            this.ctl_invoice_number.AllCaps = false;
            this.ctl_invoice_number.BackColor = System.Drawing.Color.White;
            this.ctl_invoice_number.Bold = false;
            this.ctl_invoice_number.Caption = "Invoice Number";
            this.ctl_invoice_number.Changed = false;
            this.ctl_invoice_number.IsEmail = false;
            this.ctl_invoice_number.IsURL = false;
            this.ctl_invoice_number.Location = new System.Drawing.Point(12, 386);
            this.ctl_invoice_number.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_invoice_number.Name = "ctl_invoice_number";
            this.ctl_invoice_number.PasswordChar = '\0';
            this.ctl_invoice_number.Size = new System.Drawing.Size(189, 53);
            this.ctl_invoice_number.TabIndex = 51;
            this.ctl_invoice_number.UseParentBackColor = true;
            this.ctl_invoice_number.zz_Enabled = true;
            this.ctl_invoice_number.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_invoice_number.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_invoice_number.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_invoice_number.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_invoice_number.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_invoice_number.zz_OriginalDesign = true;
            this.ctl_invoice_number.zz_ShowLinkButton = false;
            this.ctl_invoice_number.zz_ShowNeedsSaveColor = true;
            this.ctl_invoice_number.zz_Text = "";
            this.ctl_invoice_number.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_invoice_number.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_invoice_number.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_invoice_number.zz_UseGlobalColor = false;
            this.ctl_invoice_number.zz_UseGlobalFont = false;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(9, 226);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(192, 27);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "100,000,000.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ctl_taxamount
            // 
            this.ctl_taxamount.BackColor = System.Drawing.Color.White;
            this.ctl_taxamount.Bold = false;
            this.ctl_taxamount.Caption = "Tax";
            this.ctl_taxamount.Changed = false;
            this.ctl_taxamount.EditCaption = true;
            this.ctl_taxamount.FullDecimal = false;
            this.ctl_taxamount.Location = new System.Drawing.Point(7, 172);
            this.ctl_taxamount.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_taxamount.Name = "ctl_taxamount";
            this.ctl_taxamount.RoundNearestCent = false;
            this.ctl_taxamount.Size = new System.Drawing.Size(193, 53);
            this.ctl_taxamount.TabIndex = 46;
            this.ctl_taxamount.UseParentBackColor = true;
            this.ctl_taxamount.zz_Enabled = true;
            this.ctl_taxamount.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_taxamount.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_taxamount.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_taxamount.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_taxamount.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctl_taxamount.zz_OriginalDesign = true;
            this.ctl_taxamount.zz_ShowErrorColor = true;
            this.ctl_taxamount.zz_ShowNeedsSaveColor = true;
            this.ctl_taxamount.zz_Text = "";
            this.ctl_taxamount.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_taxamount.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_taxamount.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_taxamount.zz_UseGlobalColor = false;
            this.ctl_taxamount.zz_UseGlobalFont = false;
            // 
            // ctl_handlingamount
            // 
            this.ctl_handlingamount.BackColor = System.Drawing.Color.White;
            this.ctl_handlingamount.Bold = false;
            this.ctl_handlingamount.Caption = "Bank Fee";
            this.ctl_handlingamount.Changed = false;
            this.ctl_handlingamount.EditCaption = true;
            this.ctl_handlingamount.FullDecimal = false;
            this.ctl_handlingamount.Location = new System.Drawing.Point(5, 118);
            this.ctl_handlingamount.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_handlingamount.Name = "ctl_handlingamount";
            this.ctl_handlingamount.RoundNearestCent = false;
            this.ctl_handlingamount.Size = new System.Drawing.Size(193, 54);
            this.ctl_handlingamount.TabIndex = 45;
            this.ctl_handlingamount.UseParentBackColor = true;
            this.ctl_handlingamount.zz_Enabled = true;
            this.ctl_handlingamount.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_handlingamount.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_handlingamount.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_handlingamount.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_handlingamount.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctl_handlingamount.zz_OriginalDesign = true;
            this.ctl_handlingamount.zz_ShowErrorColor = true;
            this.ctl_handlingamount.zz_ShowNeedsSaveColor = true;
            this.ctl_handlingamount.zz_Text = "";
            this.ctl_handlingamount.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_handlingamount.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_handlingamount.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_handlingamount.zz_UseGlobalColor = false;
            this.ctl_handlingamount.zz_UseGlobalFont = false;
            // 
            // ctl_shippingamount
            // 
            this.ctl_shippingamount.BackColor = System.Drawing.Color.White;
            this.ctl_shippingamount.Bold = false;
            this.ctl_shippingamount.Caption = "Freight";
            this.ctl_shippingamount.Changed = false;
            this.ctl_shippingamount.EditCaption = true;
            this.ctl_shippingamount.FullDecimal = false;
            this.ctl_shippingamount.Location = new System.Drawing.Point(5, 65);
            this.ctl_shippingamount.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_shippingamount.Name = "ctl_shippingamount";
            this.ctl_shippingamount.RoundNearestCent = false;
            this.ctl_shippingamount.Size = new System.Drawing.Size(193, 54);
            this.ctl_shippingamount.TabIndex = 44;
            this.ctl_shippingamount.UseParentBackColor = true;
            this.ctl_shippingamount.zz_Enabled = true;
            this.ctl_shippingamount.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_shippingamount.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_shippingamount.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_shippingamount.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_shippingamount.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctl_shippingamount.zz_OriginalDesign = true;
            this.ctl_shippingamount.zz_ShowErrorColor = true;
            this.ctl_shippingamount.zz_ShowNeedsSaveColor = true;
            this.ctl_shippingamount.zz_Text = "";
            this.ctl_shippingamount.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_shippingamount.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_shippingamount.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_shippingamount.zz_UseGlobalColor = false;
            this.ctl_shippingamount.zz_UseGlobalFont = false;
            // 
            // ctl_charged_amount
            // 
            this.ctl_charged_amount.BackColor = System.Drawing.Color.White;
            this.ctl_charged_amount.Bold = false;
            this.ctl_charged_amount.Caption = "Charged Amount";
            this.ctl_charged_amount.Changed = false;
            this.ctl_charged_amount.EditCaption = false;
            this.ctl_charged_amount.FullDecimal = false;
            this.ctl_charged_amount.Location = new System.Drawing.Point(11, 380);
            this.ctl_charged_amount.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_charged_amount.Name = "ctl_charged_amount";
            this.ctl_charged_amount.RoundNearestCent = false;
            this.ctl_charged_amount.Size = new System.Drawing.Size(193, 52);
            this.ctl_charged_amount.TabIndex = 11;
            this.ctl_charged_amount.UseParentBackColor = true;
            this.ctl_charged_amount.zz_Enabled = true;
            this.ctl_charged_amount.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_charged_amount.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_charged_amount.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_charged_amount.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_charged_amount.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctl_charged_amount.zz_OriginalDesign = true;
            this.ctl_charged_amount.zz_ShowErrorColor = true;
            this.ctl_charged_amount.zz_ShowNeedsSaveColor = true;
            this.ctl_charged_amount.zz_Text = "";
            this.ctl_charged_amount.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_charged_amount.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_charged_amount.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_charged_amount.zz_UseGlobalColor = false;
            this.ctl_charged_amount.zz_UseGlobalFont = false;
            // 
            // ctl_invoice_date
            // 
            this.ctl_invoice_date.AllowClear = false;
            this.ctl_invoice_date.BackColor = System.Drawing.Color.White;
            this.ctl_invoice_date.Bold = false;
            this.ctl_invoice_date.Caption = "Invoice Date";
            this.ctl_invoice_date.Changed = false;
            this.ctl_invoice_date.Location = new System.Drawing.Point(15, 334);
            this.ctl_invoice_date.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_invoice_date.Name = "ctl_invoice_date";
            this.ctl_invoice_date.Size = new System.Drawing.Size(149, 53);
            this.ctl_invoice_date.SuppressEdit = false;
            this.ctl_invoice_date.TabIndex = 50;
            this.ctl_invoice_date.UseParentBackColor = true;
            this.ctl_invoice_date.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_invoice_date.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_invoice_date.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_invoice_date.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_invoice_date.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctl_invoice_date.zz_OriginalDesign = true;
            this.ctl_invoice_date.zz_ShowNeedsSaveColor = true;
            this.ctl_invoice_date.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_invoice_date.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_invoice_date.zz_UseGlobalColor = false;
            this.ctl_invoice_date.zz_UseGlobalFont = false;
            // 
            // lblPaid
            // 
            this.lblPaid.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblPaid.Location = new System.Drawing.Point(8, 331);
            this.lblPaid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPaid.Name = "lblPaid";
            this.lblPaid.Size = new System.Drawing.Size(192, 27);
            this.lblPaid.TabIndex = 9;
            this.lblPaid.Text = "Paid";
            this.lblPaid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOutstanding
            // 
            this.lblOutstanding.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutstanding.Location = new System.Drawing.Point(9, 304);
            this.lblOutstanding.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOutstanding.Name = "lblOutstanding";
            this.lblOutstanding.Size = new System.Drawing.Size(192, 27);
            this.lblOutstanding.TabIndex = 8;
            this.lblOutstanding.Text = "100,000,000.00";
            this.lblOutstanding.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPaidAmount
            // 
            this.lblPaidAmount.BackColor = System.Drawing.Color.White;
            this.lblPaidAmount.Location = new System.Drawing.Point(9, 252);
            this.lblPaidAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPaidAmount.Name = "lblPaidAmount";
            this.lblPaidAmount.Size = new System.Drawing.Size(192, 52);
            this.lblPaidAmount.TabIndex = 7;
            this.lblPaidAmount.Text = "100,000,000.00";
            this.lblPaidAmount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ctl_subtract_3
            // 
            this.ctl_subtract_3.BackColor = System.Drawing.Color.White;
            this.ctl_subtract_3.Bold = false;
            this.ctl_subtract_3.Caption = "Subtract 3";
            this.ctl_subtract_3.Changed = false;
            this.ctl_subtract_3.EditCaption = true;
            this.ctl_subtract_3.FullDecimal = false;
            this.ctl_subtract_3.Location = new System.Drawing.Point(8, 178);
            this.ctl_subtract_3.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_subtract_3.Name = "ctl_subtract_3";
            this.ctl_subtract_3.RoundNearestCent = false;
            this.ctl_subtract_3.Size = new System.Drawing.Size(193, 52);
            this.ctl_subtract_3.TabIndex = 49;
            this.ctl_subtract_3.UseParentBackColor = true;
            this.ctl_subtract_3.zz_Enabled = true;
            this.ctl_subtract_3.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_subtract_3.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_subtract_3.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_subtract_3.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_subtract_3.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctl_subtract_3.zz_OriginalDesign = true;
            this.ctl_subtract_3.zz_ShowErrorColor = true;
            this.ctl_subtract_3.zz_ShowNeedsSaveColor = true;
            this.ctl_subtract_3.zz_Text = "";
            this.ctl_subtract_3.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_subtract_3.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_subtract_3.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_subtract_3.zz_UseGlobalColor = false;
            this.ctl_subtract_3.zz_UseGlobalFont = false;
            // 
            // ctl_subtract_2
            // 
            this.ctl_subtract_2.BackColor = System.Drawing.Color.White;
            this.ctl_subtract_2.Bold = false;
            this.ctl_subtract_2.Caption = "Subtract 2";
            this.ctl_subtract_2.Changed = false;
            this.ctl_subtract_2.EditCaption = true;
            this.ctl_subtract_2.FullDecimal = false;
            this.ctl_subtract_2.Location = new System.Drawing.Point(7, 124);
            this.ctl_subtract_2.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_subtract_2.Name = "ctl_subtract_2";
            this.ctl_subtract_2.RoundNearestCent = false;
            this.ctl_subtract_2.Size = new System.Drawing.Size(193, 52);
            this.ctl_subtract_2.TabIndex = 48;
            this.ctl_subtract_2.UseParentBackColor = true;
            this.ctl_subtract_2.zz_Enabled = true;
            this.ctl_subtract_2.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_subtract_2.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_subtract_2.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_subtract_2.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_subtract_2.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctl_subtract_2.zz_OriginalDesign = true;
            this.ctl_subtract_2.zz_ShowErrorColor = true;
            this.ctl_subtract_2.zz_ShowNeedsSaveColor = true;
            this.ctl_subtract_2.zz_Text = "";
            this.ctl_subtract_2.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_subtract_2.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_subtract_2.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_subtract_2.zz_UseGlobalColor = false;
            this.ctl_subtract_2.zz_UseGlobalFont = false;
            // 
            // ctl_subtract_1
            // 
            this.ctl_subtract_1.BackColor = System.Drawing.Color.White;
            this.ctl_subtract_1.Bold = false;
            this.ctl_subtract_1.Caption = "Subtract 1";
            this.ctl_subtract_1.Changed = false;
            this.ctl_subtract_1.EditCaption = true;
            this.ctl_subtract_1.FullDecimal = false;
            this.ctl_subtract_1.Location = new System.Drawing.Point(5, 70);
            this.ctl_subtract_1.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_subtract_1.Name = "ctl_subtract_1";
            this.ctl_subtract_1.RoundNearestCent = false;
            this.ctl_subtract_1.Size = new System.Drawing.Size(193, 52);
            this.ctl_subtract_1.TabIndex = 47;
            this.ctl_subtract_1.UseParentBackColor = true;
            this.ctl_subtract_1.zz_Enabled = true;
            this.ctl_subtract_1.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_subtract_1.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_subtract_1.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_subtract_1.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_subtract_1.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctl_subtract_1.zz_OriginalDesign = true;
            this.ctl_subtract_1.zz_ShowErrorColor = true;
            this.ctl_subtract_1.zz_ShowNeedsSaveColor = true;
            this.ctl_subtract_1.zz_Text = "";
            this.ctl_subtract_1.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_subtract_1.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_subtract_1.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_subtract_1.zz_UseGlobalColor = false;
            this.ctl_subtract_1.zz_UseGlobalFont = false;
            // 
            // optOther
            // 
            this.optOther.AutoSize = true;
            this.optOther.Location = new System.Drawing.Point(105, 46);
            this.optOther.Margin = new System.Windows.Forms.Padding(4);
            this.optOther.Name = "optOther";
            this.optOther.Size = new System.Drawing.Size(61, 17);
            this.optOther.TabIndex = 43;
            this.optOther.Text = "Options";
            this.optOther.UseVisualStyleBackColor = true;
            this.optOther.CheckedChanged += new System.EventHandler(this.optFeesOption_CheckedChanged);
            // 
            // optFees
            // 
            this.optFees.AutoSize = true;
            this.optFees.Checked = true;
            this.optFees.Location = new System.Drawing.Point(20, 46);
            this.optFees.Margin = new System.Windows.Forms.Padding(4);
            this.optFees.Name = "optFees";
            this.optFees.Size = new System.Drawing.Size(48, 17);
            this.optFees.TabIndex = 42;
            this.optFees.TabStop = true;
            this.optFees.Text = "Fees";
            this.optFees.UseVisualStyleBackColor = true;
            this.optFees.CheckedChanged += new System.EventHandler(this.optFeesOption_CheckedChanged);
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.Location = new System.Drawing.Point(7, 15);
            this.lblSubTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(192, 27);
            this.lblSubTotal.TabIndex = 0;
            this.lblSubTotal.Text = "100,000,000.00";
            this.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // details
            // 
            this.details.AddCaption = "Add New Line Item";
            this.details.AllowActions = true;
            this.details.AllowAdd = true;
            this.details.AllowDelete = true;
            this.details.AllowDeleteAlways = false;
            this.details.AllowDrop = true;
            this.details.AllowOnlyOpenDelete = false;
            this.details.AlternateConnection = null;
            this.details.BackColor = System.Drawing.Color.White;
            this.details.Caption = "";
            this.details.CurrentTemplate = null;
            this.details.ExtraClassInfo = "";
            this.details.Location = new System.Drawing.Point(11, 486);
            this.details.Margin = new System.Windows.Forms.Padding(5);
            this.details.MultiSelect = true;
            this.details.Name = "details";
            this.details.Size = new System.Drawing.Size(920, 192);
            this.details.SuppressSelectionChanged = false;
            this.details.TabIndex = 9;
            this.details.zz_OpenColumnMenu = false;
            this.details.zz_OrderLineType = "";
            this.details.zz_ShowAutoRefresh = true;
            this.details.zz_ShowUnlimited = true;
            this.details.AboutToAdd += new NewMethod.AddHandler(this.details_AboutToAdd);
            // 
            // dv
            // 
            this.dv.AlwaysDisableAccept = false;
            this.dv.BackColor = System.Drawing.Color.White;
            this.dv.DisableAutoMatching = false;
            this.dv.HideOptions = false;
            this.dv.Location = new System.Drawing.Point(11, 400);
            this.dv.Margin = new System.Windows.Forms.Padding(5);
            this.dv.Name = "dv";
            this.dv.Size = new System.Drawing.Size(987, 278);
            this.dv.TabIndex = 10;
            this.dv.Visible = false;
            this.dv.Accept += new NewMethod.nDataViewAcceptHandler(this.dv_Accept);
            // 
            // oFile
            // 
            this.oFile.Multiselect = true;
            // 
            // lblSaveThisOrder
            // 
            this.lblSaveThisOrder.AutoSize = true;
            this.lblSaveThisOrder.Location = new System.Drawing.Point(1023, 497);
            this.lblSaveThisOrder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSaveThisOrder.Name = "lblSaveThisOrder";
            this.lblSaveThisOrder.Size = new System.Drawing.Size(167, 13);
            this.lblSaveThisOrder.TabIndex = 37;
            this.lblSaveThisOrder.TabStop = true;
            this.lblSaveThisOrder.Text = "<permanently save this line order>";
            this.lblSaveThisOrder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSaveThisOrder_LinkClicked);
            // 
            // view_ordhed
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dv);
            this.Controls.Add(this.lblSaveThisOrder);
            this.Controls.Add(this.gbTotals);
            this.Controls.Add(this.ts);
            this.Controls.Add(this.details);
            this.Controls.Add(this.gbTop);
            this.Margin = new System.Windows.Forms.Padding(12, 9, 12, 9);
            this.Name = "view_ordhed";
            this.Size = new System.Drawing.Size(1541, 807);
            this.Controls.SetChildIndex(this.gbTop, 0);
            this.Controls.SetChildIndex(this.details, 0);
            this.Controls.SetChildIndex(this.ts, 0);
            this.Controls.SetChildIndex(this.gbTotals, 0);
            this.Controls.SetChildIndex(this.lblSaveThisOrder, 0);
            this.Controls.SetChildIndex(this.xActions, 0);
            this.Controls.SetChildIndex(this.dv, 0);
            this.gbTop.ResumeLayout(false);
            this.gbTop.PerformLayout();
            this.ts.ResumeLayout(false);
            this.pageCompany.ResumeLayout(false);
            this.pageCompany.PerformLayout();
            this.pageAddress.ResumeLayout(false);
            this.pageAddress.PerformLayout();
            this.pageNotes.ResumeLayout(false);
            this.gbNotes_Sales.ResumeLayout(false);
            this.pageStatus.ResumeLayout(false);
            this.gbRMA.ResumeLayout(false);
            this.gbGo.ResumeLayout(false);
            this.gbGo.PerformLayout();
            this.gbStatus.ResumeLayout(false);
            this.gbStatus.PerformLayout();
            this.gbVendor.ResumeLayout(false);
            this.gbVendor.PerformLayout();
            this.gbCustomer.ResumeLayout(false);
            this.gbCustomer.PerformLayout();
            this.pageNotify.ResumeLayout(false);
            this.pageNotify.PerformLayout();
            this.pagePictures.ResumeLayout(false);
            this.pageAuthorize.ResumeLayout(false);
            this.pageDeductions.ResumeLayout(false);
            this.pageEmails.ResumeLayout(false);
            this.tabCreditCard.ResumeLayout(false);
            this.tabCreditCard.PerformLayout();
            this.tabProcurement.ResumeLayout(false);
            this.gbTotals.ResumeLayout(false);
            this.gbTotals.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOrderType;
        private System.Windows.Forms.Label lblOrderNumber;
        private nEdit_Boolean ctl_isverified;
        private nEdit_Boolean ctl_isclosed;
        protected nEdit_Boolean ctl_senttoqb;
        protected nEdit_List ctl_terms;
        protected nEdit_List cboBillingAddress;
        protected nEdit_List cboShippingAddress;
        private nEdit_String ctl_shippingname;
        private nEdit_String ctl_billingname;
        private nEdit_Memo ctl_shippingaddress;
        private nEdit_Memo ctl_billingaddress;
        private nEdit_List ctl_packinginfo;
        private nEdit_Memo ctl_printcomment;
        protected nEdit_List cboCards;
        private nEdit_Money ctl_subtract_3;
        private nEdit_Money ctl_subtract_2;
        private nEdit_Money ctl_subtract_1;
        private nEdit_Money ctl_charged_amount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblConfirmations;
        protected nList details;
        private System.Windows.Forms.RadioButton optNoVendor;
        private System.Windows.Forms.RadioButton optYesVendor;
        private System.Windows.Forms.RadioButton optNoCustomer;
        private System.Windows.Forms.RadioButton optYesCustomer;
        private System.Windows.Forms.Button cmdShipBill;
        private System.Windows.Forms.Button cmdBillShip;
        private System.Windows.Forms.LinkLabel lblAddNewShiping;
        private System.Windows.Forms.LinkLabel lblAddNewBilling;
        private System.Windows.Forms.Button cmdSwitchAddress;
        private PartPictureViewer picview;
        private nEdit_Boolean ctl_c_of_c;
        private nEdit_Date ctl_authorized_date;
        private nEdit_Boolean ctl_is_authorized;
        private System.Windows.Forms.Button cmdAuthorize;
        private nEdit_Number ctl_authorized_number;
        private System.Windows.Forms.Label lblAuthorized;
        private nEdit_Boolean ctl_isproforma;
        private nEdit_Boolean ctl_isflipdeal;
        private nEdit_Boolean ctl_showonwarehouse;
        private System.Windows.Forms.GroupBox gbNotes_Sales;
        private nEdit_Boolean ctl_has_issue;
        private nEdit_Boolean ctl_is_confirmed;
        private nEdit_Boolean ctl_advanced_payment_made;
        private nDataView dv;
        private nList lstHits;
        private nEdit_String ctl_qualitycontrol;
        private System.Windows.Forms.Button cmdNTCUpdate;
        private nList lvLinkedEmails;
        private System.Windows.Forms.OpenFileDialog oFile;
        private nEdit_String ctl_nameoncard;
        private nEdit_String ctl_cardbillingzip;
        private nEdit_String ctl_cardbillingaddr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private nEdit_Number ctl_expiration_year;
        private nEdit_Number ctl_expiration_month;
        private nEdit_List ctl_creditcardtype;
        private nEdit_String ctl_creditcardnumber;
        private System.Windows.Forms.Button cmdUpdateCustCreditCardInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdGrabCreditCardInfo;
        private nList lvProcurement;
        private nEdit_String ctl_securitycode;
        private nEdit_Boolean ctl_is_government;
        private System.Windows.Forms.Button cmdCreditApproval;
        private nEdit_Boolean ctl_for_stock;
        private System.Windows.Forms.LinkLabel lblSetForStock;
        private NewMethod.Views.Edits.nEdit_Label ctl_credit_approve_agent;
        private System.Windows.Forms.LinkLabel lblASN;
        private nEdit_Boolean ctl_credit_check_approved;
        public System.Windows.Forms.TabControl ts;
        public System.Windows.Forms.TabPage pageCompany;
        public nEdit_Boolean ctl_onhold;
        public nEdit_List ctl_shippingaccount;
        public System.Windows.Forms.TabPage pageAddress;
        public System.Windows.Forms.TabPage pageNotes;
        public System.Windows.Forms.TabPage pageStatus;
        public System.Windows.Forms.TabPage pageNotify;
        public System.Windows.Forms.TabPage pagePictures;
        public System.Windows.Forms.TabPage pageAuthorize;
        public System.Windows.Forms.TabPage pageDeductions;
        public System.Windows.Forms.TabPage pageEmails;
        public System.Windows.Forms.TabPage tabCreditCard;
        public System.Windows.Forms.TabPage tabProcurement;
        private System.Windows.Forms.Button cmdPasteBill;
        protected CompanyStub_PlusContact cStub;
        protected nEdit_String ctl_primaryemailaddress;
        protected nEdit_String ctl_primaryfax;
        protected nEdit_String ctl_primaryphone;
        protected nEdit_List ctl_shipvia;
        protected nEdit_String ctl_orderreference;
        protected nEdit_String ctl_soreference;
        protected System.Windows.Forms.Button cmdRefreshCompanyInfo;
        protected System.Windows.Forms.Button cmdUpdateCompanyInfo;
        protected NewMethod.Views.Edits.nEdit_Label nlblorderdate;
        protected NewMethod.Views.Edits.nEdit_Label nlblordertime;
        protected System.Windows.Forms.Label lblVoid;
        protected System.Windows.Forms.LinkLabel lblChangeDate;
        protected nEdit_User buyer;
        protected nEdit_User agent;
        protected nEdit_Date ctl_dockdate;
        protected nEdit_Date ctl_requireddate;
        protected nEdit_Date ctl_followup_date;
        protected System.Windows.Forms.CheckBox chkAutomaticASN;
        protected nEdit_Memo ctl_internalcomment;
        protected nEdit_Boolean ctl_isvoid;
        private System.Windows.Forms.LinkLabel lblSaveThisOrder;
        public nEdit_List ctl_orderfob;
        protected System.Windows.Forms.GroupBox gbRMA;
        protected System.Windows.Forms.Button cmdVendorRMA;
        protected System.Windows.Forms.GroupBox gbGo;
        protected System.Windows.Forms.GroupBox gbStatus;
        protected System.Windows.Forms.GroupBox gbVendor;
        protected nEdit_List cboVendReimburse;
        protected System.Windows.Forms.GroupBox gbCustomer;
        protected nEdit_List cboReimburse;
        protected nEdit_List cboWhy;
        public System.Windows.Forms.RadioButton optDiscard;
        public System.Windows.Forms.RadioButton optKeep;
        public System.Windows.Forms.RadioButton optReturn;
        public System.Windows.Forms.RadioButton optNoReturn;
        public System.Windows.Forms.RadioButton optWarehouse;
        public System.Windows.Forms.RadioButton optShip;
        protected System.Windows.Forms.CheckBox chkConfirmReceive;
        protected System.Windows.Forms.CheckBox chkNotifyReceive;
        protected System.Windows.Forms.CheckBox chkNotifyShip;
        protected System.Windows.Forms.CheckBox chkConfirmShip;
        protected System.Windows.Forms.ComboBox cboReference;
        //protected CurrencySelector ctl_currencyname;
        protected nEdit_Boolean ctl_certs_required;
        protected System.Windows.Forms.GroupBox gbTop;
        public System.Windows.Forms.GroupBox gbTotals;
        private nEdit_Memo ctl_trackingnumber;
        public nEdit_List ctl_freightbilling;
        public nEdit_Money ctl_taxamount;
        public nEdit_Money ctl_handlingamount;
        public nEdit_Money ctl_shippingamount;
        public System.Windows.Forms.Label lblPaidAmount;
        public System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.RadioButton optOther;
        public System.Windows.Forms.RadioButton optFees;
        public System.Windows.Forms.Label lblSubTotal;
        public System.Windows.Forms.Label lblPaid;
        public System.Windows.Forms.Label lblOutstanding;
        public nEdit_Date ctl_invoice_date;
        public nEdit_String ctl_invoice_number;
    }
}
