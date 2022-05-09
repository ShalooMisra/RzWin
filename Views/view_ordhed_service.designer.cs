using NewMethod;
using Tools.Database;

namespace Rz5
{
    partial class view_ordhed_service
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
            this.gbTop = new System.Windows.Forms.GroupBox();
            this.ctl_senttoqb_invoice = new NewMethod.nEdit_Boolean();
            this.ctl_onhold = new NewMethod.nEdit_Boolean();
            this.ctl_isvoid = new NewMethod.nEdit_Boolean();
            this.ctl_isclosed = new NewMethod.nEdit_Boolean();
            this.ctl_senttoqb = new NewMethod.nEdit_Boolean();
            this.lblOrderType = new System.Windows.Forms.Label();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.ts = new System.Windows.Forms.TabControl();
            this.pageCompany = new System.Windows.Forms.TabPage();
            this.ctl_terms = new NewMethod.nEdit_List();
            this.ctl_salesreference = new NewMethod.nEdit_String();
            this.ctl_freightbilling = new NewMethod.nEdit_List();
            this.ctl_trackingnumber = new NewMethod.nEdit_String();
            this.ctl_shipvia = new NewMethod.nEdit_List();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.ctl_dockdate = new NewMethod.nEdit_Date();
            this.ctl_requireddate = new NewMethod.nEdit_Date();
            this.ctl_primaryphone = new NewMethod.nEdit_String();
            this.ctl_primaryfax = new NewMethod.nEdit_String();
            this.ctl_primaryemailaddress = new NewMethod.nEdit_String();
            this.agent = new NewMethod.nEdit_User();
            this.cStub = new CompanyStub_PlusContact();
            this.lblOrderTime = new System.Windows.Forms.Label();
            this.pageAddress = new System.Windows.Forms.TabPage();
            this.ctl_drop_ship_address = new NewMethod.nEdit_Memo();
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
            this.pageNotes = new System.Windows.Forms.TabPage();
            this.gbNotes_Sales = new System.Windows.Forms.GroupBox();
            this.ctl_showonwarehouse = new NewMethod.nEdit_Boolean();
            this.ctl_isflipdeal = new NewMethod.nEdit_Boolean();
            this.ctl_isproforma = new NewMethod.nEdit_Boolean();
            this.ctl_has_issue = new NewMethod.nEdit_Boolean();
            this.ctl_printcomment = new NewMethod.nEdit_Memo();
            this.ctl_internalcomment = new NewMethod.nEdit_Memo();
            this.cboCards = new NewMethod.nEdit_List();
            this.ctl_advanced_payment_made = new NewMethod.nEdit_Boolean();
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
            this.picview = new PartPictureViewer();
            this.pageAuthorization = new System.Windows.Forms.TabPage();
            this.cmdAuthorize = new System.Windows.Forms.Button();
            this.ctl_authorized_number = new NewMethod.nEdit_Number();
            this.ctl_authorized_date = new NewMethod.nEdit_Date();
            this.ctl_is_authorized = new NewMethod.nEdit_Boolean();
            this.gbTotals = new System.Windows.Forms.GroupBox();
            this.ctl_invoice_number = new NewMethod.nEdit_String();
            this.ctl_invoice_date = new NewMethod.nEdit_Date();
            this.lblTotal = new System.Windows.Forms.Label();
            this.ctl_taxamount = new NewMethod.nEdit_Money();
            this.ctl_handlingamount = new NewMethod.nEdit_Money();
            this.ctl_shippingamount = new NewMethod.nEdit_Money();
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
            this.services = new NewMethod.nList();
            this.gbDetails = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdSelectStock = new System.Windows.Forms.Button();
            this.lblInstructDetails = new System.Windows.Forms.Label();
            this.gbServices = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdAddService = new System.Windows.Forms.Button();
            this.lblServices = new System.Windows.Forms.Label();
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
            this.pageAuthorization.SuspendLayout();
            this.gbTotals.SuspendLayout();
            this.gbDetails.SuspendLayout();
            this.gbServices.SuspendLayout();
            this.SuspendLayout();
            // 
            // xActions
            // 
            this.xActions.Location = new System.Drawing.Point(902, 0);
            this.xActions.Size = new System.Drawing.Size(192, 682);
            // 
            // gbTop
            // 
            this.gbTop.BackColor = System.Drawing.Color.White;
            this.gbTop.Controls.Add(this.ctl_senttoqb_invoice);
            this.gbTop.Controls.Add(this.ctl_onhold);
            this.gbTop.Controls.Add(this.ctl_isvoid);
            this.gbTop.Controls.Add(this.ctl_isclosed);
            this.gbTop.Controls.Add(this.ctl_senttoqb);
            this.gbTop.Controls.Add(this.lblOrderType);
            this.gbTop.Controls.Add(this.lblOrderNumber);
            this.gbTop.Location = new System.Drawing.Point(3, 27);
            this.gbTop.Name = "gbTop";
            this.gbTop.Size = new System.Drawing.Size(579, 74);
            this.gbTop.TabIndex = 6;
            this.gbTop.TabStop = false;
            // 
            // ctl_senttoqb_invoice
            // 
            this.ctl_senttoqb_invoice.BackColor = System.Drawing.Color.White;
            this.ctl_senttoqb_invoice.Bold = false;
            this.ctl_senttoqb_invoice.Caption = "QBs As Invoice";
            this.ctl_senttoqb_invoice.Changed = false;
            this.ctl_senttoqb_invoice.Location = new System.Drawing.Point(324, 44);
            this.ctl_senttoqb_invoice.Name = "ctl_senttoqb_invoice";
            this.ctl_senttoqb_invoice.Size = new System.Drawing.Size(99, 18);
            this.ctl_senttoqb_invoice.TabIndex = 8;
            this.ctl_senttoqb_invoice.UseParentBackColor = true;
            this.ctl_senttoqb_invoice.zz_CheckValue = false;
            this.ctl_senttoqb_invoice.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_senttoqb_invoice.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_senttoqb_invoice.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_senttoqb_invoice.zz_OriginalDesign = false;
            this.ctl_senttoqb_invoice.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_onhold
            // 
            this.ctl_onhold.BackColor = System.Drawing.Color.White;
            this.ctl_onhold.Bold = false;
            this.ctl_onhold.Caption = "On Hold";
            this.ctl_onhold.Changed = false;
            this.ctl_onhold.Location = new System.Drawing.Point(225, 22);
            this.ctl_onhold.Name = "ctl_onhold";
            this.ctl_onhold.Size = new System.Drawing.Size(65, 18);
            this.ctl_onhold.TabIndex = 3;
            this.ctl_onhold.UseParentBackColor = true;
            this.ctl_onhold.zz_CheckValue = false;
            this.ctl_onhold.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_onhold.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_onhold.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_onhold.zz_OriginalDesign = false;
            this.ctl_onhold.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_isvoid
            // 
            this.ctl_isvoid.BackColor = System.Drawing.Color.White;
            this.ctl_isvoid.Bold = false;
            this.ctl_isvoid.Caption = "Void";
            this.ctl_isvoid.Changed = false;
            this.ctl_isvoid.Location = new System.Drawing.Point(517, 22);
            this.ctl_isvoid.Name = "ctl_isvoid";
            this.ctl_isvoid.Size = new System.Drawing.Size(47, 18);
            this.ctl_isvoid.TabIndex = 7;
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
            this.ctl_isclosed.Location = new System.Drawing.Point(440, 22);
            this.ctl_isclosed.Name = "ctl_isclosed";
            this.ctl_isclosed.Size = new System.Drawing.Size(58, 18);
            this.ctl_isclosed.TabIndex = 6;
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
            this.ctl_senttoqb.Caption = "QBs As Bill";
            this.ctl_senttoqb.Changed = false;
            this.ctl_senttoqb.Location = new System.Drawing.Point(324, 21);
            this.ctl_senttoqb.Name = "ctl_senttoqb";
            this.ctl_senttoqb.Size = new System.Drawing.Size(77, 18);
            this.ctl_senttoqb.TabIndex = 5;
            this.ctl_senttoqb.UseParentBackColor = true;
            this.ctl_senttoqb.zz_CheckValue = false;
            this.ctl_senttoqb.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_senttoqb.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_senttoqb.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_senttoqb.zz_OriginalDesign = false;
            this.ctl_senttoqb.zz_ShowNeedsSaveColor = true;
            // 
            // lblOrderType
            // 
            this.lblOrderType.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderType.Location = new System.Drawing.Point(6, 22);
            this.lblOrderType.Name = "lblOrderType";
            this.lblOrderType.Size = new System.Drawing.Size(234, 22);
            this.lblOrderType.TabIndex = 1;
            this.lblOrderType.Text = "<order type>";
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderNumber.Location = new System.Drawing.Point(6, 46);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(234, 22);
            this.lblOrderNumber.TabIndex = 0;
            this.lblOrderNumber.Text = "<order number>";
            // 
            // ts
            // 
            this.ts.Controls.Add(this.pageCompany);
            this.ts.Controls.Add(this.pageAddress);
            this.ts.Controls.Add(this.pageNotes);
            this.ts.Controls.Add(this.pageStatus);
            this.ts.Controls.Add(this.pageNotify);
            this.ts.Controls.Add(this.pagePictures);
            this.ts.Controls.Add(this.pageAuthorization);
            this.ts.Location = new System.Drawing.Point(8, 106);
            this.ts.Name = "ts";
            this.ts.SelectedIndex = 0;
            this.ts.Size = new System.Drawing.Size(717, 287);
            this.ts.TabIndex = 7;
            this.ts.SelectedIndexChanged += new System.EventHandler(this.ts_SelectedIndexChanged);
            // 
            // pageCompany
            // 
            this.pageCompany.Controls.Add(this.ctl_terms);
            this.pageCompany.Controls.Add(this.ctl_salesreference);
            this.pageCompany.Controls.Add(this.ctl_freightbilling);
            this.pageCompany.Controls.Add(this.ctl_trackingnumber);
            this.pageCompany.Controls.Add(this.ctl_shipvia);
            this.pageCompany.Controls.Add(this.lblOrderDate);
            this.pageCompany.Controls.Add(this.ctl_dockdate);
            this.pageCompany.Controls.Add(this.ctl_requireddate);
            this.pageCompany.Controls.Add(this.ctl_primaryphone);
            this.pageCompany.Controls.Add(this.ctl_primaryfax);
            this.pageCompany.Controls.Add(this.ctl_primaryemailaddress);
            this.pageCompany.Controls.Add(this.agent);
            this.pageCompany.Controls.Add(this.cStub);
            this.pageCompany.Controls.Add(this.lblOrderTime);
            this.pageCompany.Location = new System.Drawing.Point(4, 22);
            this.pageCompany.Name = "pageCompany";
            this.pageCompany.Padding = new System.Windows.Forms.Padding(3);
            this.pageCompany.Size = new System.Drawing.Size(709, 261);
            this.pageCompany.TabIndex = 0;
            this.pageCompany.Text = "Company";
            this.pageCompany.UseVisualStyleBackColor = true;
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
            this.ctl_terms.Location = new System.Drawing.Point(457, 220);
            this.ctl_terms.Name = "ctl_terms";
            this.ctl_terms.SimpleList = null;
            this.ctl_terms.Size = new System.Drawing.Size(131, 36);
            this.ctl_terms.TabIndex = 27;
            this.ctl_terms.UseParentBackColor = true;
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
            // 
            // ctl_salesreference
            // 
            this.ctl_salesreference.AllCaps = false;
            this.ctl_salesreference.BackColor = System.Drawing.Color.Transparent;
            this.ctl_salesreference.Bold = false;
            this.ctl_salesreference.Caption = "Tracking Number - In";
            this.ctl_salesreference.Changed = false;
            this.ctl_salesreference.IsEmail = false;
            this.ctl_salesreference.IsURL = false;
            this.ctl_salesreference.Location = new System.Drawing.Point(232, 215);
            this.ctl_salesreference.Name = "ctl_salesreference";
            this.ctl_salesreference.PasswordChar = '\0';
            this.ctl_salesreference.Size = new System.Drawing.Size(219, 41);
            this.ctl_salesreference.TabIndex = 26;
            this.ctl_salesreference.UseParentBackColor = true;
            this.ctl_salesreference.zz_Enabled = true;
            this.ctl_salesreference.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_salesreference.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_salesreference.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_salesreference.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_salesreference.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_salesreference.zz_OriginalDesign = true;
            this.ctl_salesreference.zz_ShowLinkButton = false;
            this.ctl_salesreference.zz_ShowNeedsSaveColor = true;
            this.ctl_salesreference.zz_Text = "";
            this.ctl_salesreference.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_salesreference.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_salesreference.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_salesreference.zz_UseGlobalColor = false;
            this.ctl_salesreference.zz_UseGlobalFont = false;
            // 
            // ctl_freightbilling
            // 
            this.ctl_freightbilling.AllCaps = false;
            this.ctl_freightbilling.AllowEdit = false;
            this.ctl_freightbilling.BackColor = System.Drawing.Color.Transparent;
            this.ctl_freightbilling.Bold = false;
            this.ctl_freightbilling.Caption = "Ship Via - In";
            this.ctl_freightbilling.Changed = false;
            this.ctl_freightbilling.ListName = "shipvia";
            this.ctl_freightbilling.Location = new System.Drawing.Point(232, 174);
            this.ctl_freightbilling.Name = "ctl_freightbilling";
            this.ctl_freightbilling.SimpleList = null;
            this.ctl_freightbilling.Size = new System.Drawing.Size(219, 48);
            this.ctl_freightbilling.TabIndex = 25;
            this.ctl_freightbilling.UseParentBackColor = true;
            this.ctl_freightbilling.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_freightbilling.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_freightbilling.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_freightbilling.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_freightbilling.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_freightbilling.zz_OriginalDesign = true;
            this.ctl_freightbilling.zz_ShowNeedsSaveColor = true;
            this.ctl_freightbilling.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_freightbilling.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_freightbilling.zz_UseGlobalColor = false;
            this.ctl_freightbilling.zz_UseGlobalFont = false;
            // 
            // ctl_trackingnumber
            // 
            this.ctl_trackingnumber.AllCaps = false;
            this.ctl_trackingnumber.BackColor = System.Drawing.Color.Transparent;
            this.ctl_trackingnumber.Bold = false;
            this.ctl_trackingnumber.Caption = "Tracking Number - Out";
            this.ctl_trackingnumber.Changed = false;
            this.ctl_trackingnumber.IsEmail = false;
            this.ctl_trackingnumber.IsURL = false;
            this.ctl_trackingnumber.Location = new System.Drawing.Point(7, 215);
            this.ctl_trackingnumber.Name = "ctl_trackingnumber";
            this.ctl_trackingnumber.PasswordChar = '\0';
            this.ctl_trackingnumber.Size = new System.Drawing.Size(219, 41);
            this.ctl_trackingnumber.TabIndex = 24;
            this.ctl_trackingnumber.UseParentBackColor = true;
            this.ctl_trackingnumber.zz_Enabled = true;
            this.ctl_trackingnumber.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_trackingnumber.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_trackingnumber.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_trackingnumber.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_trackingnumber.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_trackingnumber.zz_OriginalDesign = true;
            this.ctl_trackingnumber.zz_ShowLinkButton = false;
            this.ctl_trackingnumber.zz_ShowNeedsSaveColor = true;
            this.ctl_trackingnumber.zz_Text = "";
            this.ctl_trackingnumber.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_trackingnumber.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_trackingnumber.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_trackingnumber.zz_UseGlobalColor = false;
            this.ctl_trackingnumber.zz_UseGlobalFont = false;
            // 
            // ctl_shipvia
            // 
            this.ctl_shipvia.AllCaps = false;
            this.ctl_shipvia.AllowEdit = false;
            this.ctl_shipvia.BackColor = System.Drawing.Color.Transparent;
            this.ctl_shipvia.Bold = false;
            this.ctl_shipvia.Caption = "Ship Via - Out";
            this.ctl_shipvia.Changed = false;
            this.ctl_shipvia.ListName = "shipvia";
            this.ctl_shipvia.Location = new System.Drawing.Point(7, 174);
            this.ctl_shipvia.Name = "ctl_shipvia";
            this.ctl_shipvia.SimpleList = null;
            this.ctl_shipvia.Size = new System.Drawing.Size(219, 48);
            this.ctl_shipvia.TabIndex = 17;
            this.ctl_shipvia.UseParentBackColor = true;
            this.ctl_shipvia.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_shipvia.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_shipvia.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_shipvia.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_shipvia.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_shipvia.zz_OriginalDesign = true;
            this.ctl_shipvia.zz_ShowNeedsSaveColor = true;
            this.ctl_shipvia.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_shipvia.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_shipvia.zz_UseGlobalColor = false;
            this.ctl_shipvia.zz_UseGlobalFont = false;
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderDate.Location = new System.Drawing.Point(455, 109);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(107, 22);
            this.lblOrderDate.TabIndex = 13;
            this.lblOrderDate.Text = "<date>";
            this.lblOrderDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOrderDate.DoubleClick += new System.EventHandler(this.lblOrderDate_DoubleClick);
            // 
            // ctl_dockdate
            // 
            this.ctl_dockdate.AllowClear = false;
            this.ctl_dockdate.BackColor = System.Drawing.Color.Transparent;
            this.ctl_dockdate.Bold = false;
            this.ctl_dockdate.Caption = "Dock Date";
            this.ctl_dockdate.Changed = false;
            this.ctl_dockdate.Location = new System.Drawing.Point(457, 63);
            this.ctl_dockdate.Name = "ctl_dockdate";
            this.ctl_dockdate.Size = new System.Drawing.Size(110, 50);
            this.ctl_dockdate.SuppressEdit = false;
            this.ctl_dockdate.TabIndex = 11;
            this.ctl_dockdate.UseParentBackColor = true;
            this.ctl_dockdate.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_dockdate.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_dockdate.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_dockdate.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_dockdate.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctl_dockdate.zz_OriginalDesign = true;
            this.ctl_dockdate.zz_ShowNeedsSaveColor = true;
            this.ctl_dockdate.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_dockdate.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.ctl_requireddate.Location = new System.Drawing.Point(341, 63);
            this.ctl_requireddate.Name = "ctl_requireddate";
            this.ctl_requireddate.Size = new System.Drawing.Size(110, 50);
            this.ctl_requireddate.SuppressEdit = false;
            this.ctl_requireddate.TabIndex = 5;
            this.ctl_requireddate.UseParentBackColor = true;
            this.ctl_requireddate.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_requireddate.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_requireddate.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_requireddate.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_requireddate.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctl_requireddate.zz_OriginalDesign = true;
            this.ctl_requireddate.zz_ShowNeedsSaveColor = true;
            this.ctl_requireddate.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_requireddate.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.ctl_primaryphone.Location = new System.Drawing.Point(7, 87);
            this.ctl_primaryphone.Name = "ctl_primaryphone";
            this.ctl_primaryphone.PasswordChar = '\0';
            this.ctl_primaryphone.Size = new System.Drawing.Size(219, 42);
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
            this.ctl_primaryfax.Location = new System.Drawing.Point(7, 130);
            this.ctl_primaryfax.Name = "ctl_primaryfax";
            this.ctl_primaryfax.PasswordChar = '\0';
            this.ctl_primaryfax.Size = new System.Drawing.Size(219, 41);
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
            this.ctl_primaryemailaddress.Location = new System.Drawing.Point(232, 129);
            this.ctl_primaryemailaddress.Name = "ctl_primaryemailaddress";
            this.ctl_primaryemailaddress.PasswordChar = '\0';
            this.ctl_primaryemailaddress.Size = new System.Drawing.Size(219, 46);
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
            this.agent.Location = new System.Drawing.Point(346, 7);
            this.agent.Name = "agent";
            this.agent.Size = new System.Drawing.Size(218, 65);
            this.agent.TabIndex = 13;
            this.agent.UseParentBackColor = true;
            this.agent.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.agent.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            // 
            // cStub
            // 
            this.cStub.Caption = "Service Vendor";
            this.cStub.Location = new System.Drawing.Point(3, 4);
            this.cStub.Name = "cStub";
            this.cStub.Size = new System.Drawing.Size(337, 102);
            this.cStub.TabIndex = 1;
            this.cStub.ChangeContact += new ContactEventHandler(this.cStub_ChangeContact);
            this.cStub.ChangeCompany += new ContactEventHandler(this.cStub_ChangeCompany);
            // 
            // lblOrderTime
            // 
            this.lblOrderTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderTime.Location = new System.Drawing.Point(455, 131);
            this.lblOrderTime.Name = "lblOrderTime";
            this.lblOrderTime.Size = new System.Drawing.Size(107, 22);
            this.lblOrderTime.TabIndex = 14;
            this.lblOrderTime.Text = "<time>";
            this.lblOrderTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pageAddress
            // 
            this.pageAddress.Controls.Add(this.ctl_drop_ship_address);
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
            this.pageAddress.Location = new System.Drawing.Point(4, 22);
            this.pageAddress.Name = "pageAddress";
            this.pageAddress.Padding = new System.Windows.Forms.Padding(3);
            this.pageAddress.Size = new System.Drawing.Size(709, 261);
            this.pageAddress.TabIndex = 1;
            this.pageAddress.Text = "Address";
            this.pageAddress.UseVisualStyleBackColor = true;
            // 
            // ctl_drop_ship_address
            // 
            this.ctl_drop_ship_address.BackColor = System.Drawing.Color.Transparent;
            this.ctl_drop_ship_address.Bold = false;
            this.ctl_drop_ship_address.Caption = "Drop Ship Address";
            this.ctl_drop_ship_address.Changed = false;
            this.ctl_drop_ship_address.DateLines = false;
            this.ctl_drop_ship_address.Location = new System.Drawing.Point(512, 6);
            this.ctl_drop_ship_address.Name = "ctl_drop_ship_address";
            this.ctl_drop_ship_address.Size = new System.Drawing.Size(191, 206);
            this.ctl_drop_ship_address.TabIndex = 28;
            this.ctl_drop_ship_address.UseParentBackColor = true;
            this.ctl_drop_ship_address.zz_Enabled = true;
            this.ctl_drop_ship_address.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_drop_ship_address.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_drop_ship_address.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_drop_ship_address.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_drop_ship_address.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_drop_ship_address.zz_OriginalDesign = true;
            this.ctl_drop_ship_address.zz_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ctl_drop_ship_address.zz_ShowNeedsSaveColor = true;
            this.ctl_drop_ship_address.zz_Text = "";
            this.ctl_drop_ship_address.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_drop_ship_address.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_drop_ship_address.zz_UseGlobalColor = false;
            this.ctl_drop_ship_address.zz_UseGlobalFont = false;
            // 
            // cmdSwitchAddress
            // 
            this.cmdSwitchAddress.Location = new System.Drawing.Point(237, 188);
            this.cmdSwitchAddress.Name = "cmdSwitchAddress";
            this.cmdSwitchAddress.Size = new System.Drawing.Size(36, 23);
            this.cmdSwitchAddress.TabIndex = 27;
            this.cmdSwitchAddress.Text = "<>";
            this.cmdSwitchAddress.UseVisualStyleBackColor = true;
            this.cmdSwitchAddress.Click += new System.EventHandler(this.cmdSwitchAddress_Click);
            // 
            // lblAddNewShiping
            // 
            this.lblAddNewShiping.AutoSize = true;
            this.lblAddNewShiping.Location = new System.Drawing.Point(283, 108);
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
            this.lblAddNewBilling.Location = new System.Drawing.Point(6, 108);
            this.lblAddNewBilling.Name = "lblAddNewBilling";
            this.lblAddNewBilling.Size = new System.Drawing.Size(48, 13);
            this.lblAddNewBilling.TabIndex = 25;
            this.lblAddNewBilling.TabStop = true;
            this.lblAddNewBilling.Text = "add new";
            this.lblAddNewBilling.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAddNewBilling_LinkClicked);
            // 
            // cmdShipBill
            // 
            this.cmdShipBill.Location = new System.Drawing.Point(237, 159);
            this.cmdShipBill.Name = "cmdShipBill";
            this.cmdShipBill.Size = new System.Drawing.Size(36, 23);
            this.cmdShipBill.TabIndex = 17;
            this.cmdShipBill.Text = "<";
            this.cmdShipBill.UseVisualStyleBackColor = true;
            this.cmdShipBill.Click += new System.EventHandler(this.cmdShipBill_Click);
            // 
            // cmdBillShip
            // 
            this.cmdBillShip.Location = new System.Drawing.Point(237, 133);
            this.cmdBillShip.Name = "cmdBillShip";
            this.cmdBillShip.Size = new System.Drawing.Size(36, 23);
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
            this.ctl_shippingaddress.Location = new System.Drawing.Point(279, 106);
            this.ctl_shippingaddress.Name = "ctl_shippingaddress";
            this.ctl_shippingaddress.Size = new System.Drawing.Size(227, 105);
            this.ctl_shippingaddress.TabIndex = 19;
            this.ctl_shippingaddress.UseParentBackColor = true;
            this.ctl_shippingaddress.zz_Enabled = true;
            this.ctl_shippingaddress.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_shippingaddress.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_shippingaddress.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_shippingaddress.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_shippingaddress.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_shippingaddress.zz_OriginalDesign = true;
            this.ctl_shippingaddress.zz_ScrollBars = System.Windows.Forms.ScrollBars.None;
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
            this.ctl_billingaddress.Location = new System.Drawing.Point(7, 106);
            this.ctl_billingaddress.Name = "ctl_billingaddress";
            this.ctl_billingaddress.Size = new System.Drawing.Size(227, 105);
            this.ctl_billingaddress.TabIndex = 16;
            this.ctl_billingaddress.UseParentBackColor = true;
            this.ctl_billingaddress.zz_Enabled = true;
            this.ctl_billingaddress.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_billingaddress.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_billingaddress.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_billingaddress.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_billingaddress.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_billingaddress.zz_OriginalDesign = true;
            this.ctl_billingaddress.zz_ScrollBars = System.Windows.Forms.ScrollBars.None;
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
            this.cboBillingAddress.Location = new System.Drawing.Point(6, 56);
            this.cboBillingAddress.Name = "cboBillingAddress";
            this.cboBillingAddress.SimpleList = null;
            this.cboBillingAddress.Size = new System.Drawing.Size(225, 47);
            this.cboBillingAddress.TabIndex = 15;
            this.cboBillingAddress.UseParentBackColor = true;
            this.cboBillingAddress.zz_GlobalColor = System.Drawing.Color.Black;
            this.cboBillingAddress.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cboBillingAddress.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.cboBillingAddress.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboBillingAddress.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.cboBillingAddress.zz_OriginalDesign = true;
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
            this.cboShippingAddress.Location = new System.Drawing.Point(279, 56);
            this.cboShippingAddress.Name = "cboShippingAddress";
            this.cboShippingAddress.SimpleList = null;
            this.cboShippingAddress.Size = new System.Drawing.Size(227, 47);
            this.cboShippingAddress.TabIndex = 18;
            this.cboShippingAddress.UseParentBackColor = true;
            this.cboShippingAddress.zz_GlobalColor = System.Drawing.Color.Black;
            this.cboShippingAddress.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cboShippingAddress.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.cboShippingAddress.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboShippingAddress.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.cboShippingAddress.zz_OriginalDesign = true;
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
            this.ctl_shippingname.Location = new System.Drawing.Point(279, 8);
            this.ctl_shippingname.Name = "ctl_shippingname";
            this.ctl_shippingname.PasswordChar = '\0';
            this.ctl_shippingname.Size = new System.Drawing.Size(227, 48);
            this.ctl_shippingname.TabIndex = 17;
            this.ctl_shippingname.UseParentBackColor = true;
            this.ctl_shippingname.zz_Enabled = true;
            this.ctl_shippingname.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_shippingname.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_shippingname.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_shippingname.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_shippingname.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_shippingname.zz_OriginalDesign = true;
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
            this.ctl_billingname.Location = new System.Drawing.Point(6, 8);
            this.ctl_billingname.Name = "ctl_billingname";
            this.ctl_billingname.PasswordChar = '\0';
            this.ctl_billingname.Size = new System.Drawing.Size(225, 48);
            this.ctl_billingname.TabIndex = 14;
            this.ctl_billingname.UseParentBackColor = true;
            this.ctl_billingname.zz_Enabled = true;
            this.ctl_billingname.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_billingname.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_billingname.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_billingname.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_billingname.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_billingname.zz_OriginalDesign = true;
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
            this.ctl_packinginfo.Location = new System.Drawing.Point(279, 214);
            this.ctl_packinginfo.Name = "ctl_packinginfo";
            this.ctl_packinginfo.SimpleList = null;
            this.ctl_packinginfo.Size = new System.Drawing.Size(227, 41);
            this.ctl_packinginfo.TabIndex = 24;
            this.ctl_packinginfo.UseParentBackColor = true;
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
            this.ctl_shippingaccount.AllowEdit = false;
            this.ctl_shippingaccount.BackColor = System.Drawing.Color.Transparent;
            this.ctl_shippingaccount.Bold = false;
            this.ctl_shippingaccount.Caption = "Shipping Account";
            this.ctl_shippingaccount.Changed = false;
            this.ctl_shippingaccount.ListName = "shippingaccount";
            this.ctl_shippingaccount.Location = new System.Drawing.Point(7, 213);
            this.ctl_shippingaccount.Name = "ctl_shippingaccount";
            this.ctl_shippingaccount.SimpleList = null;
            this.ctl_shippingaccount.Size = new System.Drawing.Size(224, 42);
            this.ctl_shippingaccount.TabIndex = 21;
            this.ctl_shippingaccount.UseParentBackColor = true;
            this.ctl_shippingaccount.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_shippingaccount.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_shippingaccount.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_shippingaccount.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_shippingaccount.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_shippingaccount.zz_OriginalDesign = true;
            this.ctl_shippingaccount.zz_ShowNeedsSaveColor = true;
            this.ctl_shippingaccount.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_shippingaccount.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_shippingaccount.zz_UseGlobalColor = false;
            this.ctl_shippingaccount.zz_UseGlobalFont = false;
            // 
            // pageNotes
            // 
            this.pageNotes.Controls.Add(this.gbNotes_Sales);
            this.pageNotes.Controls.Add(this.ctl_printcomment);
            this.pageNotes.Controls.Add(this.ctl_internalcomment);
            this.pageNotes.Controls.Add(this.cboCards);
            this.pageNotes.Controls.Add(this.ctl_advanced_payment_made);
            this.pageNotes.Location = new System.Drawing.Point(4, 22);
            this.pageNotes.Name = "pageNotes";
            this.pageNotes.Padding = new System.Windows.Forms.Padding(3);
            this.pageNotes.Size = new System.Drawing.Size(709, 261);
            this.pageNotes.TabIndex = 2;
            this.pageNotes.Text = "Notes";
            this.pageNotes.UseVisualStyleBackColor = true;
            // 
            // gbNotes_Sales
            // 
            this.gbNotes_Sales.Controls.Add(this.ctl_showonwarehouse);
            this.gbNotes_Sales.Controls.Add(this.ctl_isflipdeal);
            this.gbNotes_Sales.Controls.Add(this.ctl_isproforma);
            this.gbNotes_Sales.Controls.Add(this.ctl_has_issue);
            this.gbNotes_Sales.Location = new System.Drawing.Point(317, 6);
            this.gbNotes_Sales.Name = "gbNotes_Sales";
            this.gbNotes_Sales.Size = new System.Drawing.Size(247, 50);
            this.gbNotes_Sales.TabIndex = 31;
            this.gbNotes_Sales.TabStop = false;
            // 
            // ctl_showonwarehouse
            // 
            this.ctl_showonwarehouse.BackColor = System.Drawing.Color.Transparent;
            this.ctl_showonwarehouse.Bold = false;
            this.ctl_showonwarehouse.Caption = "Warehouse Visible";
            this.ctl_showonwarehouse.Changed = false;
            this.ctl_showonwarehouse.Location = new System.Drawing.Point(108, 5);
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
            this.ctl_isflipdeal.Location = new System.Drawing.Point(5, 5);
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
            this.ctl_isproforma.Location = new System.Drawing.Point(5, 24);
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
            this.ctl_has_issue.Location = new System.Drawing.Point(108, 25);
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
            // ctl_printcomment
            // 
            this.ctl_printcomment.BackColor = System.Drawing.Color.Transparent;
            this.ctl_printcomment.Bold = false;
            this.ctl_printcomment.Caption = "Print Comment";
            this.ctl_printcomment.Changed = false;
            this.ctl_printcomment.DateLines = false;
            this.ctl_printcomment.Location = new System.Drawing.Point(317, 72);
            this.ctl_printcomment.Name = "ctl_printcomment";
            this.ctl_printcomment.Size = new System.Drawing.Size(247, 183);
            this.ctl_printcomment.TabIndex = 27;
            this.ctl_printcomment.UseParentBackColor = true;
            this.ctl_printcomment.zz_Enabled = true;
            this.ctl_printcomment.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_printcomment.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_printcomment.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_printcomment.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_printcomment.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_printcomment.zz_OriginalDesign = true;
            this.ctl_printcomment.zz_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ctl_printcomment.zz_ShowNeedsSaveColor = true;
            this.ctl_printcomment.zz_Text = "";
            this.ctl_printcomment.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_printcomment.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.ctl_internalcomment.Location = new System.Drawing.Point(7, 72);
            this.ctl_internalcomment.Name = "ctl_internalcomment";
            this.ctl_internalcomment.Size = new System.Drawing.Size(304, 183);
            this.ctl_internalcomment.TabIndex = 26;
            this.ctl_internalcomment.UseParentBackColor = true;
            this.ctl_internalcomment.zz_Enabled = true;
            this.ctl_internalcomment.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_internalcomment.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_internalcomment.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_internalcomment.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_internalcomment.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_internalcomment.zz_OriginalDesign = true;
            this.ctl_internalcomment.zz_ScrollBars = System.Windows.Forms.ScrollBars.None;
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
            this.cboCards.Location = new System.Drawing.Point(7, 6);
            this.cboCards.Name = "cboCards";
            this.cboCards.SimpleList = null;
            this.cboCards.Size = new System.Drawing.Size(304, 50);
            this.cboCards.TabIndex = 25;
            this.cboCards.UseParentBackColor = true;
            this.cboCards.zz_GlobalColor = System.Drawing.Color.Black;
            this.cboCards.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cboCards.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.cboCards.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboCards.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.cboCards.zz_OriginalDesign = true;
            this.cboCards.zz_ShowNeedsSaveColor = true;
            this.cboCards.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.cboCards.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCards.zz_UseGlobalColor = false;
            this.cboCards.zz_UseGlobalFont = false;
            this.cboCards.SelectionChanged += new NewMethod.nEdit_List.SelectionChangedHandler(this.cboCards_SelectionChanged);
            // 
            // ctl_advanced_payment_made
            // 
            this.ctl_advanced_payment_made.BackColor = System.Drawing.Color.Transparent;
            this.ctl_advanced_payment_made.Bold = false;
            this.ctl_advanced_payment_made.Caption = "Advance Payment Received";
            this.ctl_advanced_payment_made.Changed = false;
            this.ctl_advanced_payment_made.Location = new System.Drawing.Point(322, 50);
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
            // pageStatus
            // 
            this.pageStatus.Controls.Add(this.gbRMA);
            this.pageStatus.Location = new System.Drawing.Point(4, 22);
            this.pageStatus.Name = "pageStatus";
            this.pageStatus.Padding = new System.Windows.Forms.Padding(3);
            this.pageStatus.Size = new System.Drawing.Size(709, 261);
            this.pageStatus.TabIndex = 4;
            this.pageStatus.Text = "Status";
            this.pageStatus.UseVisualStyleBackColor = true;
            // 
            // gbRMA
            // 
            this.gbRMA.Controls.Add(this.cmdVendorRMA);
            this.gbRMA.Controls.Add(this.gbGo);
            this.gbRMA.Controls.Add(this.gbStatus);
            this.gbRMA.Controls.Add(this.gbVendor);
            this.gbRMA.Controls.Add(this.cboVendReimburse);
            this.gbRMA.Controls.Add(this.gbCustomer);
            this.gbRMA.Controls.Add(this.cboReimburse);
            this.gbRMA.Controls.Add(this.cboWhy);
            this.gbRMA.Location = new System.Drawing.Point(6, 6);
            this.gbRMA.Name = "gbRMA";
            this.gbRMA.Size = new System.Drawing.Size(558, 252);
            this.gbRMA.TabIndex = 0;
            this.gbRMA.TabStop = false;
            // 
            // cmdVendorRMA
            // 
            this.cmdVendorRMA.Location = new System.Drawing.Point(296, 214);
            this.cmdVendorRMA.Name = "cmdVendorRMA";
            this.cmdVendorRMA.Size = new System.Drawing.Size(204, 28);
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
            this.gbGo.Location = new System.Drawing.Point(266, 118);
            this.gbGo.Name = "gbGo";
            this.gbGo.Size = new System.Drawing.Size(271, 87);
            this.gbGo.TabIndex = 17;
            this.gbGo.TabStop = false;
            this.gbGo.Text = "Where will these parts eventually go?";
            // 
            // optDiscard
            // 
            this.optDiscard.AutoSize = true;
            this.optDiscard.Location = new System.Drawing.Point(23, 53);
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
            this.optKeep.Location = new System.Drawing.Point(23, 36);
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
            this.optReturn.Location = new System.Drawing.Point(23, 19);
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
            this.gbStatus.Location = new System.Drawing.Point(266, 25);
            this.gbStatus.Name = "gbStatus";
            this.gbStatus.Size = new System.Drawing.Size(271, 87);
            this.gbStatus.TabIndex = 16;
            this.gbStatus.TabStop = false;
            this.gbStatus.Text = "What is the current status of the parts?";
            // 
            // optNoReturn
            // 
            this.optNoReturn.AutoSize = true;
            this.optNoReturn.Location = new System.Drawing.Point(23, 53);
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
            this.optWarehouse.Location = new System.Drawing.Point(23, 36);
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
            this.optShip.Location = new System.Drawing.Point(23, 19);
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
            this.gbVendor.Location = new System.Drawing.Point(9, 207);
            this.gbVendor.Name = "gbVendor";
            this.gbVendor.Size = new System.Drawing.Size(213, 41);
            this.gbVendor.TabIndex = 15;
            this.gbVendor.TabStop = false;
            this.gbVendor.Text = "Does the vendor owe us a refund?";
            // 
            // optNoVendor
            // 
            this.optNoVendor.AutoSize = true;
            this.optNoVendor.Location = new System.Drawing.Point(119, 19);
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
            this.optYesVendor.Location = new System.Drawing.Point(39, 18);
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
            this.cboVendReimburse.Location = new System.Drawing.Point(9, 161);
            this.cboVendReimburse.Name = "cboVendReimburse";
            this.cboVendReimburse.SimpleList = "";
            this.cboVendReimburse.Size = new System.Drawing.Size(243, 49);
            this.cboVendReimburse.TabIndex = 32;
            this.cboVendReimburse.UseParentBackColor = true;
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
            this.gbCustomer.Location = new System.Drawing.Point(9, 118);
            this.gbCustomer.Name = "gbCustomer";
            this.gbCustomer.Size = new System.Drawing.Size(213, 41);
            this.gbCustomer.TabIndex = 30;
            this.gbCustomer.TabStop = false;
            this.gbCustomer.Text = "Is the customer due a refund?";
            // 
            // optNoCustomer
            // 
            this.optNoCustomer.AutoSize = true;
            this.optNoCustomer.Location = new System.Drawing.Point(119, 19);
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
            this.optYesCustomer.Location = new System.Drawing.Point(39, 18);
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
            this.cboReimburse.Location = new System.Drawing.Point(6, 67);
            this.cboReimburse.Name = "cboReimburse";
            this.cboReimburse.SimpleList = "";
            this.cboReimburse.Size = new System.Drawing.Size(243, 49);
            this.cboReimburse.TabIndex = 29;
            this.cboReimburse.UseParentBackColor = true;
            this.cboReimburse.zz_GlobalColor = System.Drawing.Color.Black;
            this.cboReimburse.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cboReimburse.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.cboReimburse.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboReimburse.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.cboReimburse.zz_OriginalDesign = true;
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
            this.cboWhy.Location = new System.Drawing.Point(6, 19);
            this.cboWhy.Name = "cboWhy";
            this.cboWhy.SimpleList = "";
            this.cboWhy.Size = new System.Drawing.Size(243, 49);
            this.cboWhy.TabIndex = 28;
            this.cboWhy.UseParentBackColor = true;
            this.cboWhy.zz_GlobalColor = System.Drawing.Color.Black;
            this.cboWhy.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cboWhy.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.cboWhy.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboWhy.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.cboWhy.zz_OriginalDesign = true;
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
            this.pageNotify.Name = "pageNotify";
            this.pageNotify.Padding = new System.Windows.Forms.Padding(3);
            this.pageNotify.Size = new System.Drawing.Size(709, 261);
            this.pageNotify.TabIndex = 5;
            this.pageNotify.Text = "Notify";
            this.pageNotify.UseVisualStyleBackColor = true;
            // 
            // chkNotifyReceive
            // 
            this.chkNotifyReceive.AutoSize = true;
            this.chkNotifyReceive.Location = new System.Drawing.Point(32, 179);
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
            this.chkNotifyShip.Location = new System.Drawing.Point(32, 156);
            this.chkNotifyShip.Name = "chkNotifyShip";
            this.chkNotifyShip.Size = new System.Drawing.Size(233, 17);
            this.chkNotifyShip.TabIndex = 53;
            this.chkNotifyShip.Tag = "NotifyShip";
            this.chkNotifyShip.Text = "Notify the sales agent when this order ships.";
            this.chkNotifyShip.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(494, 33);
            this.label1.TabIndex = 3;
            this.label1.Text = "Notifications: These options will automatically notify the sales agent when the a" +
                "ssociated action is taken.";
            // 
            // chkConfirmReceive
            // 
            this.chkConfirmReceive.AutoSize = true;
            this.chkConfirmReceive.Location = new System.Drawing.Point(32, 73);
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
            this.chkConfirmShip.Location = new System.Drawing.Point(32, 50);
            this.chkConfirmShip.Name = "chkConfirmShip";
            this.chkConfirmShip.Size = new System.Drawing.Size(267, 17);
            this.chkConfirmShip.TabIndex = 51;
            this.chkConfirmShip.Tag = "ConfirmShip";
            this.chkConfirmShip.Text = "Confirm with the sales agent before this order ships.";
            this.chkConfirmShip.UseVisualStyleBackColor = true;
            // 
            // lblConfirmations
            // 
            this.lblConfirmations.Location = new System.Drawing.Point(6, 13);
            this.lblConfirmations.Name = "lblConfirmations";
            this.lblConfirmations.Size = new System.Drawing.Size(494, 33);
            this.lblConfirmations.TabIndex = 0;
            this.lblConfirmations.Text = "Confirmations: These options require the warehouse staff to contact the sales age" +
                "nt before performing the associated action.";
            // 
            // pagePictures
            // 
            this.pagePictures.Controls.Add(this.picview);
            this.pagePictures.Location = new System.Drawing.Point(4, 22);
            this.pagePictures.Name = "pagePictures";
            this.pagePictures.Padding = new System.Windows.Forms.Padding(3);
            this.pagePictures.Size = new System.Drawing.Size(709, 261);
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
            this.picview.Location = new System.Drawing.Point(3, 3);
            this.picview.Name = "picview";
            this.picview.ShowFullScreenButton = true;
            this.picview.ShowPartNumberLink = false;
            this.picview.ShowPartSearch = false;
            this.picview.ShowZoomButton = true;
            this.picview.Size = new System.Drawing.Size(360, 68);
            this.picview.TabIndex = 0;
            this.picview.TemplateName = "PartPictureViewer";
            // 
            // pageAuthorization
            // 
            this.pageAuthorization.Controls.Add(this.cmdAuthorize);
            this.pageAuthorization.Controls.Add(this.ctl_authorized_number);
            this.pageAuthorization.Controls.Add(this.ctl_authorized_date);
            this.pageAuthorization.Controls.Add(this.ctl_is_authorized);
            this.pageAuthorization.Location = new System.Drawing.Point(4, 22);
            this.pageAuthorization.Name = "pageAuthorization";
            this.pageAuthorization.Padding = new System.Windows.Forms.Padding(3);
            this.pageAuthorization.Size = new System.Drawing.Size(709, 261);
            this.pageAuthorization.TabIndex = 7;
            this.pageAuthorization.Text = "Authorization";
            this.pageAuthorization.UseVisualStyleBackColor = true;
            // 
            // cmdAuthorize
            // 
            this.cmdAuthorize.Location = new System.Drawing.Point(8, 137);
            this.cmdAuthorize.Name = "cmdAuthorize";
            this.cmdAuthorize.Size = new System.Drawing.Size(127, 29);
            this.cmdAuthorize.TabIndex = 7;
            this.cmdAuthorize.Text = "Authorize";
            this.cmdAuthorize.UseVisualStyleBackColor = true;
            // 
            // ctl_authorized_number
            // 
            this.ctl_authorized_number.BackColor = System.Drawing.Color.Transparent;
            this.ctl_authorized_number.Bold = false;
            this.ctl_authorized_number.Caption = "Authorization Number";
            this.ctl_authorized_number.Changed = false;
            this.ctl_authorized_number.CurrentType = FieldType.Unknown;
            this.ctl_authorized_number.Enabled = false;
            this.ctl_authorized_number.Location = new System.Drawing.Point(8, 92);
            this.ctl_authorized_number.Name = "ctl_authorized_number";
            this.ctl_authorized_number.Size = new System.Drawing.Size(127, 47);
            this.ctl_authorized_number.TabIndex = 6;
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
            this.ctl_authorized_date.Location = new System.Drawing.Point(6, 40);
            this.ctl_authorized_date.Name = "ctl_authorized_date";
            this.ctl_authorized_date.Size = new System.Drawing.Size(129, 54);
            this.ctl_authorized_date.SuppressEdit = false;
            this.ctl_authorized_date.TabIndex = 5;
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
            this.ctl_is_authorized.Location = new System.Drawing.Point(6, 7);
            this.ctl_is_authorized.Name = "ctl_is_authorized";
            this.ctl_is_authorized.Size = new System.Drawing.Size(76, 18);
            this.ctl_is_authorized.TabIndex = 4;
            this.ctl_is_authorized.UseParentBackColor = true;
            this.ctl_is_authorized.zz_CheckValue = false;
            this.ctl_is_authorized.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_is_authorized.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_is_authorized.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_is_authorized.zz_OriginalDesign = false;
            this.ctl_is_authorized.zz_ShowNeedsSaveColor = true;
            // 
            // gbTotals
            // 
            this.gbTotals.BackColor = System.Drawing.Color.White;
            this.gbTotals.Controls.Add(this.ctl_invoice_number);
            this.gbTotals.Controls.Add(this.ctl_invoice_date);
            this.gbTotals.Controls.Add(this.lblTotal);
            this.gbTotals.Controls.Add(this.ctl_taxamount);
            this.gbTotals.Controls.Add(this.ctl_handlingamount);
            this.gbTotals.Controls.Add(this.ctl_shippingamount);
            this.gbTotals.Controls.Add(this.lblPaid);
            this.gbTotals.Controls.Add(this.lblOutstanding);
            this.gbTotals.Controls.Add(this.lblPaidAmount);
            this.gbTotals.Controls.Add(this.ctl_subtract_3);
            this.gbTotals.Controls.Add(this.ctl_subtract_2);
            this.gbTotals.Controls.Add(this.ctl_subtract_1);
            this.gbTotals.Controls.Add(this.optOther);
            this.gbTotals.Controls.Add(this.optFees);
            this.gbTotals.Controls.Add(this.lblSubTotal);
            this.gbTotals.Location = new System.Drawing.Point(731, 27);
            this.gbTotals.Name = "gbTotals";
            this.gbTotals.Size = new System.Drawing.Size(156, 362);
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
            this.ctl_invoice_number.Location = new System.Drawing.Point(8, 312);
            this.ctl_invoice_number.Name = "ctl_invoice_number";
            this.ctl_invoice_number.PasswordChar = '\0';
            this.ctl_invoice_number.Size = new System.Drawing.Size(142, 44);
            this.ctl_invoice_number.TabIndex = 53;
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
            // ctl_invoice_date
            // 
            this.ctl_invoice_date.AllowClear = false;
            this.ctl_invoice_date.BackColor = System.Drawing.Color.White;
            this.ctl_invoice_date.Bold = false;
            this.ctl_invoice_date.Caption = "Invoice Date";
            this.ctl_invoice_date.Changed = false;
            this.ctl_invoice_date.Location = new System.Drawing.Point(9, 270);
            this.ctl_invoice_date.Name = "ctl_invoice_date";
            this.ctl_invoice_date.Size = new System.Drawing.Size(112, 43);
            this.ctl_invoice_date.SuppressEdit = false;
            this.ctl_invoice_date.TabIndex = 52;
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
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(7, 189);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(144, 22);
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
            this.ctl_taxamount.Location = new System.Drawing.Point(5, 145);
            this.ctl_taxamount.Name = "ctl_taxamount";
            this.ctl_taxamount.RoundNearestCent = false;
            this.ctl_taxamount.Size = new System.Drawing.Size(145, 43);
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
            this.ctl_handlingamount.Location = new System.Drawing.Point(4, 101);
            this.ctl_handlingamount.Name = "ctl_handlingamount";
            this.ctl_handlingamount.RoundNearestCent = false;
            this.ctl_handlingamount.Size = new System.Drawing.Size(145, 44);
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
            this.ctl_shippingamount.Location = new System.Drawing.Point(4, 57);
            this.ctl_shippingamount.Name = "ctl_shippingamount";
            this.ctl_shippingamount.RoundNearestCent = false;
            this.ctl_shippingamount.Size = new System.Drawing.Size(145, 44);
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
            // lblPaid
            // 
            this.lblPaid.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblPaid.Location = new System.Drawing.Point(6, 255);
            this.lblPaid.Name = "lblPaid";
            this.lblPaid.Size = new System.Drawing.Size(144, 22);
            this.lblPaid.TabIndex = 9;
            this.lblPaid.Text = "Paid";
            this.lblPaid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOutstanding
            // 
            this.lblOutstanding.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutstanding.Location = new System.Drawing.Point(7, 233);
            this.lblOutstanding.Name = "lblOutstanding";
            this.lblOutstanding.Size = new System.Drawing.Size(144, 22);
            this.lblOutstanding.TabIndex = 8;
            this.lblOutstanding.Text = "100,000,000.00";
            this.lblOutstanding.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPaidAmount
            // 
            this.lblPaidAmount.Location = new System.Drawing.Point(7, 211);
            this.lblPaidAmount.Name = "lblPaidAmount";
            this.lblPaidAmount.Size = new System.Drawing.Size(144, 22);
            this.lblPaidAmount.TabIndex = 7;
            this.lblPaidAmount.Text = "100,000,000.00";
            this.lblPaidAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ctl_subtract_3
            // 
            this.ctl_subtract_3.BackColor = System.Drawing.Color.White;
            this.ctl_subtract_3.Bold = false;
            this.ctl_subtract_3.Caption = "Subtract 3";
            this.ctl_subtract_3.Changed = false;
            this.ctl_subtract_3.EditCaption = true;
            this.ctl_subtract_3.FullDecimal = false;
            this.ctl_subtract_3.Location = new System.Drawing.Point(6, 145);
            this.ctl_subtract_3.Name = "ctl_subtract_3";
            this.ctl_subtract_3.RoundNearestCent = false;
            this.ctl_subtract_3.Size = new System.Drawing.Size(145, 42);
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
            this.ctl_subtract_2.Location = new System.Drawing.Point(5, 101);
            this.ctl_subtract_2.Name = "ctl_subtract_2";
            this.ctl_subtract_2.RoundNearestCent = false;
            this.ctl_subtract_2.Size = new System.Drawing.Size(145, 42);
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
            this.ctl_subtract_1.Location = new System.Drawing.Point(4, 57);
            this.ctl_subtract_1.Name = "ctl_subtract_1";
            this.ctl_subtract_1.RoundNearestCent = false;
            this.ctl_subtract_1.Size = new System.Drawing.Size(145, 42);
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
            this.optOther.Location = new System.Drawing.Point(79, 37);
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
            this.optFees.Location = new System.Drawing.Point(15, 37);
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
            this.lblSubTotal.Location = new System.Drawing.Point(5, 12);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(144, 22);
            this.lblSubTotal.TabIndex = 0;
            this.lblSubTotal.Text = "100,000,000.00";
            this.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // details
            // 
            this.details.AddCaption = "Add New Line Item";
            this.details.AllowActions = true;
            this.details.AllowAdd = false;
            this.details.AllowDelete = true;
            this.details.AllowDeleteAlways = false;
            this.details.AllowDrop = true;
            this.details.AlternateConnection = null;
            this.details.Caption = "";
            this.details.CurrentTemplate = null;
            this.details.ExtraClassInfo = "";
            this.details.Location = new System.Drawing.Point(8, 488);
            this.details.MultiSelect = true;
            this.details.Name = "details";
            this.details.Size = new System.Drawing.Size(386, 116);
            this.details.SuppressSelectionChanged = false;
            this.details.TabIndex = 9;
            this.details.zz_OpenColumnMenu = false;
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
            this.dv.Location = new System.Drawing.Point(8, 345);
            this.dv.Name = "dv";
            this.dv.Size = new System.Drawing.Size(740, 203);
            this.dv.TabIndex = 10;
            this.dv.Visible = false;
            this.dv.Accept += new NewMethod.nDataViewAcceptHandler(this.dv_Accept);
            // 
            // services
            // 
            this.services.AddCaption = "Add A New Service";
            this.services.AllowActions = true;
            this.services.AllowAdd = false;
            this.services.AllowDelete = true;
            this.services.AllowDeleteAlways = false;
            this.services.AllowDrop = true;
            this.services.AlternateConnection = null;
            this.services.Caption = "";
            this.services.CurrentTemplate = null;
            this.services.ExtraClassInfo = "";
            this.services.Location = new System.Drawing.Point(400, 503);
            this.services.MultiSelect = true;
            this.services.Name = "services";
            this.services.Size = new System.Drawing.Size(386, 101);
            this.services.SuppressSelectionChanged = false;
            this.services.TabIndex = 11;
            this.services.zz_OpenColumnMenu = false;
            this.services.zz_ShowAutoRefresh = true;
            this.services.zz_ShowUnlimited = true;
            // 
            // gbDetails
            // 
            this.gbDetails.Controls.Add(this.label3);
            this.gbDetails.Controls.Add(this.cmdSelectStock);
            this.gbDetails.Controls.Add(this.lblInstructDetails);
            this.gbDetails.Location = new System.Drawing.Point(8, 395);
            this.gbDetails.Name = "gbDetails";
            this.gbDetails.Size = new System.Drawing.Size(373, 80);
            this.gbDetails.TabIndex = 12;
            this.gbDetails.TabStop = false;
            this.gbDetails.Text = "Inventory Lines Being Sent On This Order";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(327, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Click \'Add Inventory Item\' to add inventory lines to this service order.";
            // 
            // cmdSelectStock
            // 
            this.cmdSelectStock.Location = new System.Drawing.Point(99, 17);
            this.cmdSelectStock.Name = "cmdSelectStock";
            this.cmdSelectStock.Size = new System.Drawing.Size(178, 23);
            this.cmdSelectStock.TabIndex = 1;
            this.cmdSelectStock.Text = "Add Inventory Item";
            this.cmdSelectStock.UseVisualStyleBackColor = true;
            // 
            // lblInstructDetails
            // 
            this.lblInstructDetails.AutoSize = true;
            this.lblInstructDetails.Location = new System.Drawing.Point(8, 43);
            this.lblInstructDetails.Name = "lblInstructDetails";
            this.lblInstructDetails.Size = new System.Drawing.Size(277, 13);
            this.lblInstructDetails.TabIndex = 0;
            this.lblInstructDetails.Text = "These lines represent the parts being sent out for service.";
            // 
            // gbServices
            // 
            this.gbServices.Controls.Add(this.label2);
            this.gbServices.Controls.Add(this.cmdAddService);
            this.gbServices.Controls.Add(this.lblServices);
            this.gbServices.Location = new System.Drawing.Point(387, 395);
            this.gbServices.Name = "gbServices";
            this.gbServices.Size = new System.Drawing.Size(373, 80);
            this.gbServices.TabIndex = 13;
            this.gbServices.TabStop = false;
            this.gbServices.Text = "Services Being Performed";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Click \'Add Service\' to add a type of service.";
            // 
            // cmdAddService
            // 
            this.cmdAddService.Location = new System.Drawing.Point(99, 17);
            this.cmdAddService.Name = "cmdAddService";
            this.cmdAddService.Size = new System.Drawing.Size(178, 23);
            this.cmdAddService.TabIndex = 1;
            this.cmdAddService.Text = "Add Service";
            this.cmdAddService.UseVisualStyleBackColor = true;
            this.cmdAddService.Click += new System.EventHandler(this.cmdAddService_Click);
            // 
            // lblServices
            // 
            this.lblServices.AutoSize = true;
            this.lblServices.Location = new System.Drawing.Point(8, 43);
            this.lblServices.Name = "lblServices";
            this.lblServices.Size = new System.Drawing.Size(236, 13);
            this.lblServices.TabIndex = 0;
            this.lblServices.Text = "This list represents the services being performed.";
            // 
            // view_ordhed_service
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbTop);
            this.Controls.Add(this.gbServices);
            this.Controls.Add(this.gbDetails);
            this.Controls.Add(this.services);
            this.Controls.Add(this.details);
            this.Controls.Add(this.ts);
            this.Controls.Add(this.gbTotals);
            this.Controls.Add(this.dv);
            this.Name = "view_ordhed_service";
            this.Size = new System.Drawing.Size(1094, 682);
            this.Controls.SetChildIndex(this.dv, 0);
            this.Controls.SetChildIndex(this.gbTotals, 0);
            this.Controls.SetChildIndex(this.ts, 0);
            this.Controls.SetChildIndex(this.details, 0);
            this.Controls.SetChildIndex(this.services, 0);
            this.Controls.SetChildIndex(this.gbDetails, 0);
            this.Controls.SetChildIndex(this.gbServices, 0);
            this.Controls.SetChildIndex(this.xActions, 0);
            this.Controls.SetChildIndex(this.gbTop, 0);
            this.gbTop.ResumeLayout(false);
            this.ts.ResumeLayout(false);
            this.pageCompany.ResumeLayout(false);
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
            this.pageAuthorization.ResumeLayout(false);
            this.gbTotals.ResumeLayout(false);
            this.gbTotals.PerformLayout();
            this.gbDetails.ResumeLayout(false);
            this.gbDetails.PerformLayout();
            this.gbServices.ResumeLayout(false);
            this.gbServices.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTop;
        private System.Windows.Forms.Label lblOrderType;
        private System.Windows.Forms.Label lblOrderNumber;
        private nEdit_Boolean ctl_onhold;
        private nEdit_Boolean ctl_isvoid;
        private nEdit_Boolean ctl_isclosed;
        private nEdit_Boolean ctl_senttoqb;
        private System.Windows.Forms.TabPage pageCompany;
        private CompanyStub_PlusContact cStub;
        private System.Windows.Forms.TabPage pageAddress;
        private System.Windows.Forms.TabPage pageNotes;
        private System.Windows.Forms.TabPage pageStatus;
        private System.Windows.Forms.TabPage pageNotify;
        private nEdit_User agent;
        private nEdit_String ctl_primaryemailaddress;
        private nEdit_String ctl_primaryfax;
        private nEdit_String ctl_primaryphone;
        private nEdit_Date ctl_dockdate;
        private nEdit_Date ctl_requireddate;
        private System.Windows.Forms.Label lblOrderTime;
        private System.Windows.Forms.Label lblOrderDate;
        protected nEdit_List cboBillingAddress;
        protected nEdit_List cboShippingAddress;
        private nEdit_String ctl_shippingname;
        private nEdit_String ctl_billingname;
        private nEdit_Memo ctl_shippingaddress;
        private nEdit_Memo ctl_billingaddress;
        private nEdit_List ctl_packinginfo;
        private nEdit_List ctl_shippingaccount;
        private nEdit_Memo ctl_printcomment;
        private nEdit_Memo ctl_internalcomment;
        protected nEdit_List cboCards;
        private System.Windows.Forms.GroupBox gbTotals;
        private System.Windows.Forms.Label lblPaidAmount;
        private System.Windows.Forms.Label lblTotal;
        private nEdit_Money ctl_subtract_3;
        private nEdit_Money ctl_subtract_2;
        private nEdit_Money ctl_subtract_1;
        private System.Windows.Forms.RadioButton optOther;
        private System.Windows.Forms.RadioButton optFees;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label lblPaid;
        private System.Windows.Forms.Label lblOutstanding;
        private System.Windows.Forms.CheckBox chkNotifyReceive;
        private System.Windows.Forms.CheckBox chkNotifyShip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkConfirmReceive;
        private System.Windows.Forms.CheckBox chkConfirmShip;
        private System.Windows.Forms.Label lblConfirmations;
        private nEdit_Money ctl_taxamount;
        private nEdit_Money ctl_handlingamount;
        private nEdit_Money ctl_shippingamount;
        private nList details;
        private System.Windows.Forms.GroupBox gbRMA;
        private System.Windows.Forms.Button cmdVendorRMA;
        private System.Windows.Forms.GroupBox gbGo;
        private System.Windows.Forms.RadioButton optDiscard;
        private System.Windows.Forms.RadioButton optKeep;
        private System.Windows.Forms.RadioButton optReturn;
        private System.Windows.Forms.GroupBox gbStatus;
        private System.Windows.Forms.RadioButton optNoReturn;
        private System.Windows.Forms.RadioButton optWarehouse;
        private System.Windows.Forms.RadioButton optShip;
        private System.Windows.Forms.GroupBox gbVendor;
        private System.Windows.Forms.RadioButton optNoVendor;
        private System.Windows.Forms.RadioButton optYesVendor;
        private nEdit_List cboVendReimburse;
        private System.Windows.Forms.GroupBox gbCustomer;
        private System.Windows.Forms.RadioButton optNoCustomer;
        private System.Windows.Forms.RadioButton optYesCustomer;
        private nEdit_List cboReimburse;
        private nEdit_List cboWhy;
        private System.Windows.Forms.Button cmdShipBill;
        private System.Windows.Forms.Button cmdBillShip;
        private System.Windows.Forms.LinkLabel lblAddNewShiping;
        private System.Windows.Forms.LinkLabel lblAddNewBilling;
        private System.Windows.Forms.Button cmdSwitchAddress;
        private System.Windows.Forms.TabPage pagePictures;
        private PartPictureViewer picview;
        private nEdit_Boolean ctl_isproforma;
        private nEdit_Boolean ctl_isflipdeal;
        private nEdit_Boolean ctl_showonwarehouse;
        private System.Windows.Forms.GroupBox gbNotes_Sales;
        private nEdit_Boolean ctl_has_issue;
        private nEdit_Boolean ctl_advanced_payment_made;
        private nDataView dv;
        private nEdit_String ctl_trackingnumber;
        private nEdit_List ctl_shipvia;
        private nEdit_String ctl_salesreference;
        private nEdit_List ctl_freightbilling;
        private nList services;
        private System.Windows.Forms.GroupBox gbDetails;
        private System.Windows.Forms.Button cmdSelectStock;
        private System.Windows.Forms.Label lblInstructDetails;
        private System.Windows.Forms.GroupBox gbServices;
        private System.Windows.Forms.Button cmdAddService;
        private System.Windows.Forms.Label lblServices;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private nEdit_String ctl_invoice_number;
        private nEdit_Date ctl_invoice_date;
        private nEdit_Memo ctl_drop_ship_address;
        protected nEdit_List ctl_terms;
        private nEdit_Boolean ctl_senttoqb_invoice;
        private System.Windows.Forms.TabPage pageAuthorization;
        private System.Windows.Forms.Button cmdAuthorize;
        private nEdit_Number ctl_authorized_number;
        private nEdit_Date ctl_authorized_date;
        private nEdit_Boolean ctl_is_authorized;
        protected System.Windows.Forms.TabControl ts;
    }
}
