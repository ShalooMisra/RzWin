using NewMethod;

namespace Rz5
{
    partial class ViewHeader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewHeader));
            this.throb1 = new NewMethod.nThrobber();
            this.lblLineStatus1 = new System.Windows.Forms.Label();
            this.gbTotals = new System.Windows.Forms.GroupBox();
            this.throb2 = new NewMethod.nThrobber();
            this.lblLineStatus2 = new System.Windows.Forms.Label();
            this.bg = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmdSetShipVia = new System.Windows.Forms.Button();
            this.cmdSetShipAccounts = new System.Windows.Forms.Button();
            this.cmdBillShip = new System.Windows.Forms.Button();
            this.cmdShipBill = new System.Windows.Forms.Button();
            this.cmdSwitchAddress = new System.Windows.Forms.Button();
            this.lblProblemCustomer = new System.Windows.Forms.Label();
            this.gbAction1 = new System.Windows.Forms.Panel();
            this.cmdAction1 = new System.Windows.Forms.Button();
            this.ilActions = new System.Windows.Forms.ImageList(this.components);
            this.gbAction2 = new System.Windows.Forms.Panel();
            this.cmdAction2 = new System.Windows.Forms.Button();
            this.tabAttachments = new System.Windows.Forms.TabPage();
            this.picview = new Rz5.PartPictureViewer();
            this.tabLines = new System.Windows.Forms.TabPage();
            this.lblSaveThisOrder = new System.Windows.Forms.LinkLabel();
            this.details = new NewMethod.nList();
            this.tsDetails = new System.Windows.Forms.TabControl();
            this.gbReport = new System.Windows.Forms.GroupBox();
            this.btnFixComplete = new System.Windows.Forms.Button();
            this.rtReport = new System.Windows.Forms.RichTextBox();
            this.gbAddedToQb = new System.Windows.Forms.GroupBox();
            this.pbQbAdded = new System.Windows.Forms.PictureBox();
            this.gbHubspot = new System.Windows.Forms.GroupBox();
            this.llEditHubspotDeal = new System.Windows.Forms.LinkLabel();
            this.llblDealLink = new System.Windows.Forms.LinkLabel();
            this.btnHubspot = new System.Windows.Forms.Button();
            this.picVoid = new System.Windows.Forms.PictureBox();
            this.picOpen = new System.Windows.Forms.PictureBox();
            this.picHold = new System.Windows.Forms.PictureBox();
            this.picComplete = new System.Windows.Forms.PictureBox();
            this.picHeader = new System.Windows.Forms.PictureBox();
            this.tabCreditsCharges = new System.Windows.Forms.TabPage();
            this.lvCreditCharges = new NewMethod.nList();
            this.tabCompanyCredits = new System.Windows.Forms.TabPage();
            this.cbxShowUsedCredits = new System.Windows.Forms.CheckBox();
            this.btnAssignCredit = new System.Windows.Forms.Button();
            this.btnEditCredit = new System.Windows.Forms.Button();
            this.btnAddCredit = new System.Windows.Forms.Button();
            this.nListCompanyCredits = new NewMethod.nList();
            this.tabNotes = new System.Windows.Forms.TabPage();
            this.ctl_printcomment = new NewMethod.nEdit_Memo();
            this.ctl_internalcomment = new NewMethod.nEdit_Memo();
            this.tabOther = new System.Windows.Forms.TabPage();
            this.ctl_is_confirmed = new NewMethod.nEdit_Boolean();
            this.ctl_senttoqb = new NewMethod.nEdit_Boolean();
            this.tabShipping = new System.Windows.Forms.TabPage();
            this.ctl_trackingnumber = new NewMethod.nEdit_Memo();
            this.lvAccount = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvShipVia = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctl_shippingaccount = new NewMethod.nEdit_List();
            this.ctl_shipvia = new NewMethod.nEdit_List();
            this.tabAddress = new System.Windows.Forms.TabPage();
            this.cmdPasteBill = new System.Windows.Forms.Button();
            this.lblAddNewShiping = new System.Windows.Forms.LinkLabel();
            this.lblAddNewBilling = new System.Windows.Forms.LinkLabel();
            this.ctl_shippingaddress = new NewMethod.nEdit_Memo();
            this.ctl_billingaddress = new NewMethod.nEdit_Memo();
            this.cboBillingAddress = new NewMethod.nEdit_List();
            this.cboShippingAddress = new NewMethod.nEdit_List();
            this.ctl_shippingname = new NewMethod.nEdit_String();
            this.ctl_billingname = new NewMethod.nEdit_String();
            this.tabCompany = new System.Windows.Forms.TabPage();
            this.agent = new NewMethod.nEdit_User();
            this.lblOutstandingInvoiceAmnt = new System.Windows.Forms.Label();
            this.lblCompanyCreditAmount = new System.Windows.Forms.Label();
            this.lblCompanyCreditAlert = new System.Windows.Forms.Label();
            this.lblChangeDate = new System.Windows.Forms.LinkLabel();
            this.nlblordertime = new NewMethod.Views.Edits.nEdit_Label();
            this.nlblorderdate = new NewMethod.Views.Edits.nEdit_Label();
            this.ctl_primaryphone = new NewMethod.nEdit_String();
            this.ctl_primaryfax = new NewMethod.nEdit_String();
            this.ctl_primaryemailaddress = new NewMethod.nEdit_String();
            this.cStub = new Rz5.CompanyStub_PlusContact();
            this.ts = new System.Windows.Forms.TabControl();
            this.gbAction1.SuspendLayout();
            this.gbAction2.SuspendLayout();
            this.tabAttachments.SuspendLayout();
            this.tabLines.SuspendLayout();
            this.tsDetails.SuspendLayout();
            this.gbReport.SuspendLayout();
            this.gbAddedToQb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbQbAdded)).BeginInit();
            this.gbHubspot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVoid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOpen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picComplete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).BeginInit();
            this.tabCreditsCharges.SuspendLayout();
            this.tabCompanyCredits.SuspendLayout();
            this.tabNotes.SuspendLayout();
            this.tabOther.SuspendLayout();
            this.tabShipping.SuspendLayout();
            this.tabAddress.SuspendLayout();
            this.tabCompany.SuspendLayout();
            this.ts.SuspendLayout();
            this.SuspendLayout();
            // 
            // xActions
            // 
            this.xActions.Location = new System.Drawing.Point(1347, 0);
            this.xActions.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.xActions.Size = new System.Drawing.Size(148, 945);
            // 
            // throb1
            // 
            this.throb1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.throb1.Location = new System.Drawing.Point(135, 5);
            this.throb1.Margin = new System.Windows.Forms.Padding(5);
            this.throb1.Name = "throb1";
            this.throb1.Size = new System.Drawing.Size(22, 22);
            this.throb1.TabIndex = 24;
            this.throb1.UseParentBackColor = false;
            // 
            // lblLineStatus1
            // 
            this.lblLineStatus1.AutoSize = true;
            this.lblLineStatus1.Location = new System.Drawing.Point(4, 130);
            this.lblLineStatus1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLineStatus1.Name = "lblLineStatus1";
            this.lblLineStatus1.Size = new System.Drawing.Size(69, 13);
            this.lblLineStatus1.TabIndex = 23;
            this.lblLineStatus1.Text = "Status Line 1";
            // 
            // gbTotals
            // 
            this.gbTotals.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTotals.Location = new System.Drawing.Point(645, 209);
            this.gbTotals.Margin = new System.Windows.Forms.Padding(4);
            this.gbTotals.Name = "gbTotals";
            this.gbTotals.Padding = new System.Windows.Forms.Padding(4);
            this.gbTotals.Size = new System.Drawing.Size(393, 134);
            this.gbTotals.TabIndex = 40;
            this.gbTotals.TabStop = false;
            this.gbTotals.Text = "Totals";
            // 
            // throb2
            // 
            this.throb2.BackColor = System.Drawing.Color.Blue;
            this.throb2.Location = new System.Drawing.Point(151, 5);
            this.throb2.Margin = new System.Windows.Forms.Padding(5);
            this.throb2.Name = "throb2";
            this.throb2.Size = new System.Drawing.Size(22, 22);
            this.throb2.TabIndex = 25;
            this.throb2.UseParentBackColor = false;
            // 
            // lblLineStatus2
            // 
            this.lblLineStatus2.AutoSize = true;
            this.lblLineStatus2.Location = new System.Drawing.Point(24, 130);
            this.lblLineStatus2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLineStatus2.Name = "lblLineStatus2";
            this.lblLineStatus2.Size = new System.Drawing.Size(69, 13);
            this.lblLineStatus2.TabIndex = 23;
            this.lblLineStatus2.Text = "Status Line 2";
            // 
            // bg
            // 
            this.bg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_DoWork);
            this.bg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_RunWorkerCompleted);
            // 
            // cmdSetShipVia
            // 
            this.cmdSetShipVia.Location = new System.Drawing.Point(273, 21);
            this.cmdSetShipVia.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSetShipVia.Name = "cmdSetShipVia";
            this.cmdSetShipVia.Size = new System.Drawing.Size(25, 32);
            this.cmdSetShipVia.TabIndex = 5;
            this.toolTip1.SetToolTip(this.cmdSetShipVia, "Click to apply shipvia to all lines.");
            this.cmdSetShipVia.UseVisualStyleBackColor = true;
            this.cmdSetShipVia.Click += new System.EventHandler(this.cmdSetShipVia_Click);
            // 
            // cmdSetShipAccounts
            // 
            this.cmdSetShipAccounts.Location = new System.Drawing.Point(581, 21);
            this.cmdSetShipAccounts.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSetShipAccounts.Name = "cmdSetShipAccounts";
            this.cmdSetShipAccounts.Size = new System.Drawing.Size(25, 32);
            this.cmdSetShipAccounts.TabIndex = 6;
            this.toolTip1.SetToolTip(this.cmdSetShipAccounts, "Click to apply account to all lines.");
            this.cmdSetShipAccounts.UseVisualStyleBackColor = true;
            this.cmdSetShipAccounts.Click += new System.EventHandler(this.cmdSetShipAccounts_Click);
            // 
            // cmdBillShip
            // 
            this.cmdBillShip.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBillShip.Location = new System.Drawing.Point(295, 113);
            this.cmdBillShip.Margin = new System.Windows.Forms.Padding(4);
            this.cmdBillShip.Name = "cmdBillShip";
            this.cmdBillShip.Size = new System.Drawing.Size(36, 37);
            this.cmdBillShip.TabIndex = 16;
            this.cmdBillShip.Text = ">";
            this.toolTip1.SetToolTip(this.cmdBillShip, "Click to make Shipping Address same as Billing Address");
            this.cmdBillShip.UseVisualStyleBackColor = true;
            this.cmdBillShip.Click += new System.EventHandler(this.cmdBillShip_Click);
            // 
            // cmdShipBill
            // 
            this.cmdShipBill.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdShipBill.Location = new System.Drawing.Point(295, 160);
            this.cmdShipBill.Margin = new System.Windows.Forms.Padding(4);
            this.cmdShipBill.Name = "cmdShipBill";
            this.cmdShipBill.Size = new System.Drawing.Size(36, 37);
            this.cmdShipBill.TabIndex = 17;
            this.cmdShipBill.Text = "<";
            this.toolTip1.SetToolTip(this.cmdShipBill, "Click to make Billing Address same as Shipping Address");
            this.cmdShipBill.UseVisualStyleBackColor = true;
            this.cmdShipBill.Click += new System.EventHandler(this.cmdShipBill_Click);
            // 
            // cmdSwitchAddress
            // 
            this.cmdSwitchAddress.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSwitchAddress.Location = new System.Drawing.Point(295, 206);
            this.cmdSwitchAddress.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSwitchAddress.Name = "cmdSwitchAddress";
            this.cmdSwitchAddress.Size = new System.Drawing.Size(36, 37);
            this.cmdSwitchAddress.TabIndex = 27;
            this.cmdSwitchAddress.Text = "<>";
            this.toolTip1.SetToolTip(this.cmdSwitchAddress, "Click to swap Addresses");
            this.cmdSwitchAddress.UseVisualStyleBackColor = true;
            this.cmdSwitchAddress.Click += new System.EventHandler(this.cmdSwitchAddress_Click);
            // 
            // lblProblemCustomer
            // 
            this.lblProblemCustomer.AutoSize = true;
            this.lblProblemCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProblemCustomer.ForeColor = System.Drawing.Color.Red;
            this.lblProblemCustomer.Location = new System.Drawing.Point(7, 98);
            this.lblProblemCustomer.Name = "lblProblemCustomer";
            this.lblProblemCustomer.Size = new System.Drawing.Size(108, 13);
            this.lblProblemCustomer.TabIndex = 54;
            this.lblProblemCustomer.Text = "Problem Customer";
            this.toolTip1.SetToolTip(this.lblProblemCustomer, "See Management / Accounting for Resolution");
            this.lblProblemCustomer.Visible = false;
            // 
            // gbAction1
            // 
            this.gbAction1.Controls.Add(this.lblLineStatus1);
            this.gbAction1.Controls.Add(this.cmdAction1);
            this.gbAction1.Controls.Add(this.throb1);
            this.gbAction1.Location = new System.Drawing.Point(694, 4);
            this.gbAction1.Margin = new System.Windows.Forms.Padding(4);
            this.gbAction1.Name = "gbAction1";
            this.gbAction1.Size = new System.Drawing.Size(165, 154);
            this.gbAction1.TabIndex = 42;
            // 
            // cmdAction1
            // 
            this.cmdAction1.BackColor = System.Drawing.Color.White;
            this.cmdAction1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdAction1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.cmdAction1.FlatAppearance.BorderSize = 0;
            this.cmdAction1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAction1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAction1.ImageList = this.ilActions;
            this.cmdAction1.Location = new System.Drawing.Point(8, 4);
            this.cmdAction1.Margin = new System.Windows.Forms.Padding(4);
            this.cmdAction1.Name = "cmdAction1";
            this.cmdAction1.Size = new System.Drawing.Size(120, 120);
            this.cmdAction1.TabIndex = 22;
            this.cmdAction1.UseVisualStyleBackColor = false;
            this.cmdAction1.Click += new System.EventHandler(this.cmdAction1_Click);
            // 
            // ilActions
            // 
            this.ilActions.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilActions.ImageStream")));
            this.ilActions.TransparentColor = System.Drawing.Color.Transparent;
            this.ilActions.Images.SetKeyName(0, "SalesOrderActive.png");
            this.ilActions.Images.SetKeyName(1, "StartShipment");
            this.ilActions.Images.SetKeyName(2, "PutAway");
            this.ilActions.Images.SetKeyName(3, "SalesOrder");
            this.ilActions.Images.SetKeyName(4, "Ship");
            this.ilActions.Images.SetKeyName(5, "CreateSale.png");
            this.ilActions.Images.SetKeyName(6, "orange-question-mark-icon-png-clip-art-30.png");
            this.ilActions.Images.SetKeyName(7, "PutAway.png");
            this.ilActions.Images.SetKeyName(8, "Ship.png");
            this.ilActions.Images.SetKeyName(9, "StartShipment.png");
            this.ilActions.Images.SetKeyName(10, "SalesOrderActiveNew.png");
            this.ilActions.Images.SetKeyName(11, "ValidateQuote.png");
            this.ilActions.Images.SetKeyName(12, "TurnInQuote.png");
            // 
            // gbAction2
            // 
            this.gbAction2.Controls.Add(this.lblLineStatus2);
            this.gbAction2.Controls.Add(this.cmdAction2);
            this.gbAction2.Controls.Add(this.throb2);
            this.gbAction2.Location = new System.Drawing.Point(866, 4);
            this.gbAction2.Margin = new System.Windows.Forms.Padding(4);
            this.gbAction2.Name = "gbAction2";
            this.gbAction2.Size = new System.Drawing.Size(165, 154);
            this.gbAction2.TabIndex = 43;
            // 
            // cmdAction2
            // 
            this.cmdAction2.BackColor = System.Drawing.Color.White;
            this.cmdAction2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdAction2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.cmdAction2.FlatAppearance.BorderSize = 0;
            this.cmdAction2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAction2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAction2.ImageList = this.ilActions;
            this.cmdAction2.Location = new System.Drawing.Point(8, 4);
            this.cmdAction2.Margin = new System.Windows.Forms.Padding(0);
            this.cmdAction2.Name = "cmdAction2";
            this.cmdAction2.Size = new System.Drawing.Size(120, 120);
            this.cmdAction2.TabIndex = 26;
            this.cmdAction2.UseVisualStyleBackColor = false;
            this.cmdAction2.Click += new System.EventHandler(this.cmdAction2_Click);
            // 
            // tabAttachments
            // 
            this.tabAttachments.Controls.Add(this.picview);
            this.tabAttachments.Location = new System.Drawing.Point(4, 22);
            this.tabAttachments.Margin = new System.Windows.Forms.Padding(4);
            this.tabAttachments.Name = "tabAttachments";
            this.tabAttachments.Size = new System.Drawing.Size(1155, 448);
            this.tabAttachments.TabIndex = 1;
            this.tabAttachments.Text = "Attachments";
            this.tabAttachments.UseVisualStyleBackColor = true;
            // 
            // picview
            // 
            this.picview.BackColor = System.Drawing.Color.White;
            this.picview.Caption = "Rz4 PictureViewer";
            this.picview.DisablePartLink = false;
            this.picview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picview.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.picview.Location = new System.Drawing.Point(0, 0);
            this.picview.Margin = new System.Windows.Forms.Padding(4);
            this.picview.Name = "picview";
            this.picview.ShowFullScreenButton = true;
            this.picview.ShowPartNumberLink = false;
            this.picview.ShowPartSearch = false;
            this.picview.ShowZoomButton = true;
            this.picview.Size = new System.Drawing.Size(1155, 448);
            this.picview.TabIndex = 1;
            this.picview.TemplateName = "PartPictureViewer";
            // 
            // tabLines
            // 
            this.tabLines.Controls.Add(this.lblSaveThisOrder);
            this.tabLines.Controls.Add(this.details);
            this.tabLines.Location = new System.Drawing.Point(4, 22);
            this.tabLines.Margin = new System.Windows.Forms.Padding(4);
            this.tabLines.Name = "tabLines";
            this.tabLines.Padding = new System.Windows.Forms.Padding(4);
            this.tabLines.Size = new System.Drawing.Size(1155, 448);
            this.tabLines.TabIndex = 0;
            this.tabLines.Text = "Lines";
            this.tabLines.UseVisualStyleBackColor = true;
            // 
            // lblSaveThisOrder
            // 
            this.lblSaveThisOrder.AutoSize = true;
            this.lblSaveThisOrder.Location = new System.Drawing.Point(281, 212);
            this.lblSaveThisOrder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSaveThisOrder.Name = "lblSaveThisOrder";
            this.lblSaveThisOrder.Size = new System.Drawing.Size(167, 13);
            this.lblSaveThisOrder.TabIndex = 37;
            this.lblSaveThisOrder.TabStop = true;
            this.lblSaveThisOrder.Text = "<permanently save this line order>";
            this.lblSaveThisOrder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSaveThisOrder_LinkClicked);
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
            this.details.Dock = System.Windows.Forms.DockStyle.Fill;
            this.details.ExtraClassInfo = "";
            this.details.Location = new System.Drawing.Point(4, 4);
            this.details.Margin = new System.Windows.Forms.Padding(5);
            this.details.MultiSelect = true;
            this.details.Name = "details";
            this.details.Size = new System.Drawing.Size(1147, 440);
            this.details.SuppressSelectionChanged = false;
            this.details.TabIndex = 9;
            this.details.zz_OpenColumnMenu = false;
            this.details.zz_OrderLineType = "";
            this.details.zz_ShowAutoRefresh = true;
            this.details.zz_ShowUnlimited = true;
            this.details.AboutToThrow += new Core.ShowHandler(this.details_AboutToThrow);
            this.details.AboutToAdd += new NewMethod.AddHandler(this.details_AboutToAdd);
            this.details.FinishedFill += new NewMethod.FillHandler(this.details_FinishedFill);
            this.details.AboutToAction += new NewMethod.ActionHandler(this.details_AboutToAction);
            this.details.FinishedAction += new NewMethod.ActionHandler(this.details_FinishedAction);
            // 
            // tsDetails
            // 
            this.tsDetails.Controls.Add(this.tabLines);
            this.tsDetails.Controls.Add(this.tabAttachments);
            this.tsDetails.Location = new System.Drawing.Point(3, 351);
            this.tsDetails.Margin = new System.Windows.Forms.Padding(4);
            this.tsDetails.Name = "tsDetails";
            this.tsDetails.SelectedIndex = 0;
            this.tsDetails.Size = new System.Drawing.Size(1163, 474);
            this.tsDetails.TabIndex = 41;
            this.tsDetails.SelectedIndexChanged += new System.EventHandler(this.tsDetails_SelectedIndexChanged);
            // 
            // gbReport
            // 
            this.gbReport.Controls.Add(this.btnFixComplete);
            this.gbReport.Controls.Add(this.rtReport);
            this.gbReport.Font = new System.Drawing.Font("Calibri", 12F);
            this.gbReport.Location = new System.Drawing.Point(1067, 181);
            this.gbReport.Name = "gbReport";
            this.gbReport.Size = new System.Drawing.Size(268, 185);
            this.gbReport.TabIndex = 43;
            this.gbReport.TabStop = false;
            this.gbReport.Text = "Actions Needed To Complete";
            this.gbReport.Visible = false;
            // 
            // btnFixComplete
            // 
            this.btnFixComplete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFixComplete.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.btnFixComplete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFixComplete.Location = new System.Drawing.Point(205, 0);
            this.btnFixComplete.Name = "btnFixComplete";
            this.btnFixComplete.Size = new System.Drawing.Size(57, 21);
            this.btnFixComplete.TabIndex = 1;
            this.btnFixComplete.Text = "Fix";
            this.btnFixComplete.UseVisualStyleBackColor = true;
            this.btnFixComplete.Click += new System.EventHandler(this.btnFixComplete_Click);
            // 
            // rtReport
            // 
            this.rtReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtReport.Location = new System.Drawing.Point(3, 23);
            this.rtReport.Name = "rtReport";
            this.rtReport.Size = new System.Drawing.Size(262, 159);
            this.rtReport.TabIndex = 0;
            this.rtReport.Text = "";
            // 
            // gbAddedToQb
            // 
            this.gbAddedToQb.Controls.Add(this.pbQbAdded);
            this.gbAddedToQb.Location = new System.Drawing.Point(515, 9);
            this.gbAddedToQb.Name = "gbAddedToQb";
            this.gbAddedToQb.Size = new System.Drawing.Size(47, 56);
            this.gbAddedToQb.TabIndex = 49;
            this.gbAddedToQb.TabStop = false;
            this.gbAddedToQb.Visible = false;
            // 
            // pbQbAdded
            // 
            this.pbQbAdded.Image = ((System.Drawing.Image)(resources.GetObject("pbQbAdded.Image")));
            this.pbQbAdded.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbQbAdded.InitialImage")));
            this.pbQbAdded.Location = new System.Drawing.Point(5, 10);
            this.pbQbAdded.Name = "pbQbAdded";
            this.pbQbAdded.Size = new System.Drawing.Size(40, 40);
            this.pbQbAdded.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbQbAdded.TabIndex = 50;
            this.pbQbAdded.TabStop = false;
            // 
            // gbHubspot
            // 
            this.gbHubspot.Controls.Add(this.llEditHubspotDeal);
            this.gbHubspot.Controls.Add(this.llblDealLink);
            this.gbHubspot.Controls.Add(this.btnHubspot);
            this.gbHubspot.Location = new System.Drawing.Point(566, 2);
            this.gbHubspot.Name = "gbHubspot";
            this.gbHubspot.Size = new System.Drawing.Size(122, 63);
            this.gbHubspot.TabIndex = 70;
            this.gbHubspot.TabStop = false;
            this.gbHubspot.Text = "HubSpot Deal";
            // 
            // llEditHubspotDeal
            // 
            this.llEditHubspotDeal.AutoSize = true;
            this.llEditHubspotDeal.Location = new System.Drawing.Point(51, 41);
            this.llEditHubspotDeal.Name = "llEditHubspotDeal";
            this.llEditHubspotDeal.Size = new System.Drawing.Size(36, 13);
            this.llEditHubspotDeal.TabIndex = 77;
            this.llEditHubspotDeal.TabStop = true;
            this.llEditHubspotDeal.Text = "<edit>";
            this.llEditHubspotDeal.UseWaitCursor = true;
            this.llEditHubspotDeal.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llEditHubspotDeal_LinkClicked);
            // 
            // llblDealLink
            // 
            this.llblDealLink.AutoSize = true;
            this.llblDealLink.Location = new System.Drawing.Point(51, 19);
            this.llblDealLink.Name = "llblDealLink";
            this.llblDealLink.Size = new System.Drawing.Size(51, 13);
            this.llblDealLink.TabIndex = 75;
            this.llblDealLink.TabStop = true;
            this.llblDealLink.Text = "<not set>";
            this.llblDealLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblDealLink_LinkClicked);
            // 
            // btnHubspot
            // 
            this.btnHubspot.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.btnHubspot.Image = ((System.Drawing.Image)(resources.GetObject("btnHubspot.Image")));
            this.btnHubspot.Location = new System.Drawing.Point(8, 17);
            this.btnHubspot.Name = "btnHubspot";
            this.btnHubspot.Size = new System.Drawing.Size(40, 40);
            this.btnHubspot.TabIndex = 72;
            this.btnHubspot.UseVisualStyleBackColor = true;
            this.btnHubspot.Click += new System.EventHandler(this.btnHubspot_Click);
            // 
            // picVoid
            // 
            this.picVoid.BackColor = System.Drawing.Color.Transparent;
            this.picVoid.BackgroundImage = global::RzInterfaceWin.Properties.Resources.Void;
            this.picVoid.Location = new System.Drawing.Point(1176, 558);
            this.picVoid.Margin = new System.Windows.Forms.Padding(4);
            this.picVoid.Name = "picVoid";
            this.picVoid.Size = new System.Drawing.Size(159, 138);
            this.picVoid.TabIndex = 47;
            this.picVoid.TabStop = false;
            this.picVoid.Visible = false;
            // 
            // picOpen
            // 
            this.picOpen.BackColor = System.Drawing.Color.Transparent;
            this.picOpen.BackgroundImage = global::RzInterfaceWin.Properties.Resources.Open;
            this.picOpen.Location = new System.Drawing.Point(1176, 496);
            this.picOpen.Margin = new System.Windows.Forms.Padding(4);
            this.picOpen.Name = "picOpen";
            this.picOpen.Size = new System.Drawing.Size(159, 54);
            this.picOpen.TabIndex = 46;
            this.picOpen.TabStop = false;
            this.picOpen.Visible = false;
            // 
            // picHold
            // 
            this.picHold.BackColor = System.Drawing.Color.Transparent;
            this.picHold.BackgroundImage = global::RzInterfaceWin.Properties.Resources.Hold;
            this.picHold.Location = new System.Drawing.Point(1176, 435);
            this.picHold.Margin = new System.Windows.Forms.Padding(4);
            this.picHold.Name = "picHold";
            this.picHold.Size = new System.Drawing.Size(159, 54);
            this.picHold.TabIndex = 45;
            this.picHold.TabStop = false;
            this.picHold.Visible = false;
            // 
            // picComplete
            // 
            this.picComplete.BackColor = System.Drawing.Color.Transparent;
            this.picComplete.BackgroundImage = global::RzInterfaceWin.Properties.Resources.Complete;
            this.picComplete.Location = new System.Drawing.Point(1176, 373);
            this.picComplete.Margin = new System.Windows.Forms.Padding(4);
            this.picComplete.Name = "picComplete";
            this.picComplete.Size = new System.Drawing.Size(159, 54);
            this.picComplete.TabIndex = 24;
            this.picComplete.TabStop = false;
            this.picComplete.Visible = false;
            // 
            // picHeader
            // 
            this.picHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.picHeader.Location = new System.Drawing.Point(1, 0);
            this.picHeader.Margin = new System.Windows.Forms.Padding(4);
            this.picHeader.Name = "picHeader";
            this.picHeader.Size = new System.Drawing.Size(488, 50);
            this.picHeader.TabIndex = 44;
            this.picHeader.TabStop = false;
            this.picHeader.DoubleClick += new System.EventHandler(this.picHeader_DoubleClick);
            // 
            // tabCreditsCharges
            // 
            this.tabCreditsCharges.Controls.Add(this.lvCreditCharges);
            this.tabCreditsCharges.Location = new System.Drawing.Point(4, 22);
            this.tabCreditsCharges.Name = "tabCreditsCharges";
            this.tabCreditsCharges.Padding = new System.Windows.Forms.Padding(3);
            this.tabCreditsCharges.Size = new System.Drawing.Size(192, 74);
            this.tabCreditsCharges.TabIndex = 6;
            this.tabCreditsCharges.Text = "Discounts/Charges";
            this.tabCreditsCharges.UseVisualStyleBackColor = true;
            // 
            // lvCreditCharges
            // 
            this.lvCreditCharges.AddCaption = "Add New";
            this.lvCreditCharges.AllowActions = true;
            this.lvCreditCharges.AllowAdd = true;
            this.lvCreditCharges.AllowDelete = true;
            this.lvCreditCharges.AllowDeleteAlways = false;
            this.lvCreditCharges.AllowDrop = true;
            this.lvCreditCharges.AllowOnlyOpenDelete = false;
            this.lvCreditCharges.AlternateConnection = null;
            this.lvCreditCharges.BackColor = System.Drawing.Color.White;
            this.lvCreditCharges.Caption = "";
            this.lvCreditCharges.CurrentTemplate = null;
            this.lvCreditCharges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCreditCharges.ExtraClassInfo = "";
            this.lvCreditCharges.Location = new System.Drawing.Point(3, 3);
            this.lvCreditCharges.Margin = new System.Windows.Forms.Padding(4);
            this.lvCreditCharges.MultiSelect = true;
            this.lvCreditCharges.Name = "lvCreditCharges";
            this.lvCreditCharges.Size = new System.Drawing.Size(186, 68);
            this.lvCreditCharges.SuppressSelectionChanged = false;
            this.lvCreditCharges.TabIndex = 3;
            this.lvCreditCharges.zz_OpenColumnMenu = false;
            this.lvCreditCharges.zz_OrderLineType = "";
            this.lvCreditCharges.zz_ShowAutoRefresh = true;
            this.lvCreditCharges.zz_ShowUnlimited = true;
            this.lvCreditCharges.AboutToThrow += new Core.ShowHandler(this.lvCreditCharges_AboutToThrow);
            this.lvCreditCharges.AboutToAdd += new NewMethod.AddHandler(this.lvCreditCharges_AboutToAdd);
            this.lvCreditCharges.FinishedAction += new NewMethod.ActionHandler(this.lvCreditCharges_FinishedAction);
            // 
            // tabCompanyCredits
            // 
            this.tabCompanyCredits.Controls.Add(this.cbxShowUsedCredits);
            this.tabCompanyCredits.Controls.Add(this.btnAssignCredit);
            this.tabCompanyCredits.Controls.Add(this.btnEditCredit);
            this.tabCompanyCredits.Controls.Add(this.btnAddCredit);
            this.tabCompanyCredits.Controls.Add(this.nListCompanyCredits);
            this.tabCompanyCredits.Location = new System.Drawing.Point(4, 22);
            this.tabCompanyCredits.Name = "tabCompanyCredits";
            this.tabCompanyCredits.Padding = new System.Windows.Forms.Padding(3);
            this.tabCompanyCredits.Size = new System.Drawing.Size(192, 74);
            this.tabCompanyCredits.TabIndex = 5;
            this.tabCompanyCredits.Text = "Company Credits";
            this.tabCompanyCredits.UseVisualStyleBackColor = true;
            // 
            // cbxShowUsedCredits
            // 
            this.cbxShowUsedCredits.AutoSize = true;
            this.cbxShowUsedCredits.Location = new System.Drawing.Point(183, 231);
            this.cbxShowUsedCredits.Name = "cbxShowUsedCredits";
            this.cbxShowUsedCredits.Size = new System.Drawing.Size(149, 17);
            this.cbxShowUsedCredits.TabIndex = 10;
            this.cbxShowUsedCredits.Text = "Show All Company Credits";
            this.cbxShowUsedCredits.UseVisualStyleBackColor = true;
            this.cbxShowUsedCredits.CheckedChanged += new System.EventHandler(this.cbxShowUsedCredits_CheckedChanged);
            // 
            // btnAssignCredit
            // 
            this.btnAssignCredit.Location = new System.Drawing.Point(517, 227);
            this.btnAssignCredit.Name = "btnAssignCredit";
            this.btnAssignCredit.Size = new System.Drawing.Size(105, 23);
            this.btnAssignCredit.TabIndex = 9;
            this.btnAssignCredit.Text = "Assign/Unassign";
            this.btnAssignCredit.UseVisualStyleBackColor = true;
            this.btnAssignCredit.Click += new System.EventHandler(this.btnAssignCredit_Click);
            // 
            // btnEditCredit
            // 
            this.btnEditCredit.Location = new System.Drawing.Point(88, 227);
            this.btnEditCredit.Name = "btnEditCredit";
            this.btnEditCredit.Size = new System.Drawing.Size(75, 23);
            this.btnEditCredit.TabIndex = 8;
            this.btnEditCredit.Text = "Edit";
            this.btnEditCredit.UseVisualStyleBackColor = true;
            this.btnEditCredit.Click += new System.EventHandler(this.btnEditCredit_Click);
            // 
            // btnAddCredit
            // 
            this.btnAddCredit.Location = new System.Drawing.Point(7, 227);
            this.btnAddCredit.Name = "btnAddCredit";
            this.btnAddCredit.Size = new System.Drawing.Size(75, 23);
            this.btnAddCredit.TabIndex = 7;
            this.btnAddCredit.Text = "Add";
            this.btnAddCredit.UseVisualStyleBackColor = true;
            this.btnAddCredit.Click += new System.EventHandler(this.btnAddCredit_Click);
            // 
            // nListCompanyCredits
            // 
            this.nListCompanyCredits.AddCaption = "Add New";
            this.nListCompanyCredits.AllowActions = true;
            this.nListCompanyCredits.AllowAdd = false;
            this.nListCompanyCredits.AllowDelete = true;
            this.nListCompanyCredits.AllowDeleteAlways = false;
            this.nListCompanyCredits.AllowDrop = true;
            this.nListCompanyCredits.AllowOnlyOpenDelete = false;
            this.nListCompanyCredits.AlternateConnection = null;
            this.nListCompanyCredits.BackColor = System.Drawing.Color.White;
            this.nListCompanyCredits.Caption = "";
            this.nListCompanyCredits.CurrentTemplate = null;
            this.nListCompanyCredits.ExtraClassInfo = "";
            this.nListCompanyCredits.Location = new System.Drawing.Point(7, 7);
            this.nListCompanyCredits.MultiSelect = true;
            this.nListCompanyCredits.Name = "nListCompanyCredits";
            this.nListCompanyCredits.Size = new System.Drawing.Size(615, 215);
            this.nListCompanyCredits.SuppressSelectionChanged = false;
            this.nListCompanyCredits.TabIndex = 6;
            this.nListCompanyCredits.zz_OpenColumnMenu = false;
            this.nListCompanyCredits.zz_OrderLineType = "";
            this.nListCompanyCredits.zz_ShowAutoRefresh = true;
            this.nListCompanyCredits.zz_ShowUnlimited = true;
            this.nListCompanyCredits.AboutToAdd += new NewMethod.AddHandler(this.lvCompanyCredits_AboutToAdd);
            this.nListCompanyCredits.FinishedFill += new NewMethod.FillHandler(this.nListCompanyCredits_FinishedFill);
            this.nListCompanyCredits.AboutToAction += new NewMethod.ActionHandler(this.nListCompanyCredits_AboutToAction);
            // 
            // tabNotes
            // 
            this.tabNotes.Controls.Add(this.ctl_printcomment);
            this.tabNotes.Controls.Add(this.ctl_internalcomment);
            this.tabNotes.Location = new System.Drawing.Point(4, 22);
            this.tabNotes.Margin = new System.Windows.Forms.Padding(4);
            this.tabNotes.Name = "tabNotes";
            this.tabNotes.Padding = new System.Windows.Forms.Padding(4);
            this.tabNotes.Size = new System.Drawing.Size(192, 74);
            this.tabNotes.TabIndex = 2;
            this.tabNotes.Text = "Notes";
            this.tabNotes.UseVisualStyleBackColor = true;
            // 
            // ctl_printcomment
            // 
            this.ctl_printcomment.BackColor = System.Drawing.Color.Transparent;
            this.ctl_printcomment.Bold = false;
            this.ctl_printcomment.Caption = "Print Comment";
            this.ctl_printcomment.Changed = false;
            this.ctl_printcomment.DateLines = false;
            this.ctl_printcomment.Location = new System.Drawing.Point(4, 132);
            this.ctl_printcomment.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_printcomment.Name = "ctl_printcomment";
            this.ctl_printcomment.Size = new System.Drawing.Size(613, 114);
            this.ctl_printcomment.TabIndex = 27;
            this.ctl_printcomment.UseParentBackColor = true;
            this.ctl_printcomment.zz_Enabled = true;
            this.ctl_printcomment.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_printcomment.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_printcomment.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_printcomment.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_printcomment.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_printcomment.zz_OriginalDesign = false;
            this.ctl_printcomment.zz_ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ctl_printcomment.zz_ShowNeedsSaveColor = true;
            this.ctl_printcomment.zz_Text = "";
            this.ctl_printcomment.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_printcomment.zz_TextFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.ctl_internalcomment.Location = new System.Drawing.Point(4, 7);
            this.ctl_internalcomment.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_internalcomment.Name = "ctl_internalcomment";
            this.ctl_internalcomment.Size = new System.Drawing.Size(613, 114);
            this.ctl_internalcomment.TabIndex = 26;
            this.ctl_internalcomment.UseParentBackColor = true;
            this.ctl_internalcomment.zz_Enabled = true;
            this.ctl_internalcomment.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_internalcomment.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_internalcomment.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_internalcomment.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_internalcomment.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_internalcomment.zz_OriginalDesign = false;
            this.ctl_internalcomment.zz_ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ctl_internalcomment.zz_ShowNeedsSaveColor = true;
            this.ctl_internalcomment.zz_Text = "";
            this.ctl_internalcomment.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_internalcomment.zz_TextFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_internalcomment.zz_UseGlobalColor = false;
            this.ctl_internalcomment.zz_UseGlobalFont = false;
            // 
            // tabOther
            // 
            this.tabOther.Controls.Add(this.ctl_is_confirmed);
            this.tabOther.Controls.Add(this.ctl_senttoqb);
            this.tabOther.Location = new System.Drawing.Point(4, 22);
            this.tabOther.Margin = new System.Windows.Forms.Padding(4);
            this.tabOther.Name = "tabOther";
            this.tabOther.Size = new System.Drawing.Size(192, 74);
            this.tabOther.TabIndex = 4;
            this.tabOther.Text = "Other";
            this.tabOther.UseVisualStyleBackColor = true;
            // 
            // ctl_is_confirmed
            // 
            this.ctl_is_confirmed.BackColor = System.Drawing.Color.White;
            this.ctl_is_confirmed.Bold = false;
            this.ctl_is_confirmed.Caption = "Is Confirmed";
            this.ctl_is_confirmed.Changed = false;
            this.ctl_is_confirmed.Location = new System.Drawing.Point(229, 9);
            this.ctl_is_confirmed.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_is_confirmed.Name = "ctl_is_confirmed";
            this.ctl_is_confirmed.Size = new System.Drawing.Size(84, 18);
            this.ctl_is_confirmed.TabIndex = 7;
            this.ctl_is_confirmed.TabStop = false;
            this.ctl_is_confirmed.UseParentBackColor = true;
            this.ctl_is_confirmed.zz_CheckValue = false;
            this.ctl_is_confirmed.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_is_confirmed.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_is_confirmed.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_is_confirmed.zz_OriginalDesign = false;
            this.ctl_is_confirmed.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_senttoqb
            // 
            this.ctl_senttoqb.BackColor = System.Drawing.Color.White;
            this.ctl_senttoqb.Bold = false;
            this.ctl_senttoqb.Caption = "Sent To QuickBooks";
            this.ctl_senttoqb.Changed = false;
            this.ctl_senttoqb.Location = new System.Drawing.Point(9, 9);
            this.ctl_senttoqb.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_senttoqb.Name = "ctl_senttoqb";
            this.ctl_senttoqb.Size = new System.Drawing.Size(125, 18);
            this.ctl_senttoqb.TabIndex = 6;
            this.ctl_senttoqb.TabStop = false;
            this.ctl_senttoqb.UseParentBackColor = true;
            this.ctl_senttoqb.zz_CheckValue = false;
            this.ctl_senttoqb.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_senttoqb.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_senttoqb.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_senttoqb.zz_OriginalDesign = false;
            this.ctl_senttoqb.zz_ShowNeedsSaveColor = true;
            // 
            // tabShipping
            // 
            this.tabShipping.Controls.Add(this.cmdSetShipAccounts);
            this.tabShipping.Controls.Add(this.cmdSetShipVia);
            this.tabShipping.Controls.Add(this.ctl_trackingnumber);
            this.tabShipping.Controls.Add(this.lvAccount);
            this.tabShipping.Controls.Add(this.lvShipVia);
            this.tabShipping.Controls.Add(this.ctl_shippingaccount);
            this.tabShipping.Controls.Add(this.ctl_shipvia);
            this.tabShipping.Location = new System.Drawing.Point(4, 22);
            this.tabShipping.Margin = new System.Windows.Forms.Padding(4);
            this.tabShipping.Name = "tabShipping";
            this.tabShipping.Size = new System.Drawing.Size(192, 74);
            this.tabShipping.TabIndex = 3;
            this.tabShipping.Text = "Shipping Info";
            this.tabShipping.UseVisualStyleBackColor = true;
            // 
            // ctl_trackingnumber
            // 
            this.ctl_trackingnumber.BackColor = System.Drawing.Color.White;
            this.ctl_trackingnumber.Bold = false;
            this.ctl_trackingnumber.Caption = "Tracking Numbers";
            this.ctl_trackingnumber.Changed = false;
            this.ctl_trackingnumber.DateLines = false;
            this.ctl_trackingnumber.Location = new System.Drawing.Point(13, 161);
            this.ctl_trackingnumber.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_trackingnumber.Name = "ctl_trackingnumber";
            this.ctl_trackingnumber.Size = new System.Drawing.Size(593, 82);
            this.ctl_trackingnumber.TabIndex = 4;
            this.ctl_trackingnumber.UseParentBackColor = false;
            this.ctl_trackingnumber.zz_Enabled = false;
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
            // lvAccount
            // 
            this.lvAccount.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.lvAccount.FullRowSelect = true;
            this.lvAccount.GridLines = true;
            this.lvAccount.HideSelection = false;
            this.lvAccount.Location = new System.Drawing.Point(321, 60);
            this.lvAccount.Margin = new System.Windows.Forms.Padding(4);
            this.lvAccount.MultiSelect = false;
            this.lvAccount.Name = "lvAccount";
            this.lvAccount.Size = new System.Drawing.Size(284, 99);
            this.lvAccount.TabIndex = 3;
            this.lvAccount.UseCompatibleStateImageBehavior = false;
            this.lvAccount.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Line";
            this.columnHeader3.Width = 45;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Account";
            this.columnHeader4.Width = 141;
            // 
            // lvShipVia
            // 
            this.lvShipVia.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvShipVia.FullRowSelect = true;
            this.lvShipVia.GridLines = true;
            this.lvShipVia.HideSelection = false;
            this.lvShipVia.Location = new System.Drawing.Point(13, 60);
            this.lvShipVia.Margin = new System.Windows.Forms.Padding(4);
            this.lvShipVia.MultiSelect = false;
            this.lvShipVia.Name = "lvShipVia";
            this.lvShipVia.Size = new System.Drawing.Size(284, 99);
            this.lvShipVia.TabIndex = 2;
            this.lvShipVia.UseCompatibleStateImageBehavior = false;
            this.lvShipVia.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Line";
            this.columnHeader1.Width = 45;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Ship Via";
            this.columnHeader2.Width = 141;
            // 
            // ctl_shippingaccount
            // 
            this.ctl_shippingaccount.AllCaps = false;
            this.ctl_shippingaccount.AllowEdit = false;
            this.ctl_shippingaccount.BackColor = System.Drawing.Color.White;
            this.ctl_shippingaccount.Bold = false;
            this.ctl_shippingaccount.Caption = "Ship Account";
            this.ctl_shippingaccount.Changed = false;
            this.ctl_shippingaccount.ListName = "";
            this.ctl_shippingaccount.Location = new System.Drawing.Point(321, 4);
            this.ctl_shippingaccount.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_shippingaccount.Name = "ctl_shippingaccount";
            this.ctl_shippingaccount.SimpleList = null;
            this.ctl_shippingaccount.Size = new System.Drawing.Size(252, 40);
            this.ctl_shippingaccount.TabIndex = 1;
            this.ctl_shippingaccount.UseParentBackColor = false;
            this.ctl_shippingaccount.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_shippingaccount.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_shippingaccount.zz_GlobalFont = new System.Drawing.Font("Calibri", 9.75F);
            this.ctl_shippingaccount.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_shippingaccount.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F);
            this.ctl_shippingaccount.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_shippingaccount.zz_OriginalDesign = false;
            this.ctl_shippingaccount.zz_ShowNeedsSaveColor = true;
            this.ctl_shippingaccount.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_shippingaccount.zz_TextFont = new System.Drawing.Font("Calibri", 9.75F);
            this.ctl_shippingaccount.zz_UseGlobalColor = false;
            this.ctl_shippingaccount.zz_UseGlobalFont = false;
            // 
            // ctl_shipvia
            // 
            this.ctl_shipvia.AllCaps = false;
            this.ctl_shipvia.AllowEdit = false;
            this.ctl_shipvia.BackColor = System.Drawing.Color.White;
            this.ctl_shipvia.Bold = false;
            this.ctl_shipvia.Caption = "Ship Via";
            this.ctl_shipvia.Changed = false;
            this.ctl_shipvia.ListName = "shipvia";
            this.ctl_shipvia.Location = new System.Drawing.Point(13, 4);
            this.ctl_shipvia.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_shipvia.Name = "ctl_shipvia";
            this.ctl_shipvia.SimpleList = null;
            this.ctl_shipvia.Size = new System.Drawing.Size(252, 40);
            this.ctl_shipvia.TabIndex = 0;
            this.ctl_shipvia.UseParentBackColor = false;
            this.ctl_shipvia.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_shipvia.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_shipvia.zz_GlobalFont = new System.Drawing.Font("Calibri", 9.75F);
            this.ctl_shipvia.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_shipvia.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F);
            this.ctl_shipvia.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_shipvia.zz_OriginalDesign = false;
            this.ctl_shipvia.zz_ShowNeedsSaveColor = true;
            this.ctl_shipvia.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_shipvia.zz_TextFont = new System.Drawing.Font("Calibri", 9.75F);
            this.ctl_shipvia.zz_UseGlobalColor = false;
            this.ctl_shipvia.zz_UseGlobalFont = false;
            // 
            // tabAddress
            // 
            this.tabAddress.Controls.Add(this.cmdPasteBill);
            this.tabAddress.Controls.Add(this.cmdSwitchAddress);
            this.tabAddress.Controls.Add(this.lblAddNewShiping);
            this.tabAddress.Controls.Add(this.lblAddNewBilling);
            this.tabAddress.Controls.Add(this.cmdShipBill);
            this.tabAddress.Controls.Add(this.cmdBillShip);
            this.tabAddress.Controls.Add(this.ctl_shippingaddress);
            this.tabAddress.Controls.Add(this.ctl_billingaddress);
            this.tabAddress.Controls.Add(this.cboBillingAddress);
            this.tabAddress.Controls.Add(this.cboShippingAddress);
            this.tabAddress.Controls.Add(this.ctl_shippingname);
            this.tabAddress.Controls.Add(this.ctl_billingname);
            this.tabAddress.Location = new System.Drawing.Point(4, 22);
            this.tabAddress.Margin = new System.Windows.Forms.Padding(4);
            this.tabAddress.Name = "tabAddress";
            this.tabAddress.Padding = new System.Windows.Forms.Padding(4);
            this.tabAddress.Size = new System.Drawing.Size(192, 74);
            this.tabAddress.TabIndex = 1;
            this.tabAddress.Text = "Address";
            this.tabAddress.UseVisualStyleBackColor = true;
            // 
            // cmdPasteBill
            // 
            this.cmdPasteBill.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPasteBill.Location = new System.Drawing.Point(233, 64);
            this.cmdPasteBill.Margin = new System.Windows.Forms.Padding(4);
            this.cmdPasteBill.Name = "cmdPasteBill";
            this.cmdPasteBill.Size = new System.Drawing.Size(61, 31);
            this.cmdPasteBill.TabIndex = 47;
            this.cmdPasteBill.Text = "Paste";
            this.cmdPasteBill.UseVisualStyleBackColor = true;
            this.cmdPasteBill.Click += new System.EventHandler(this.cmdPasteBill_Click);
            // 
            // lblAddNewShiping
            // 
            this.lblAddNewShiping.AutoSize = true;
            this.lblAddNewShiping.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddNewShiping.Location = new System.Drawing.Point(327, 76);
            this.lblAddNewShiping.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddNewShiping.Name = "lblAddNewShiping";
            this.lblAddNewShiping.Size = new System.Drawing.Size(53, 15);
            this.lblAddNewShiping.TabIndex = 26;
            this.lblAddNewShiping.TabStop = true;
            this.lblAddNewShiping.Text = "add new";
            this.lblAddNewShiping.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAddNewShiping_LinkClicked);
            // 
            // lblAddNewBilling
            // 
            this.lblAddNewBilling.AutoSize = true;
            this.lblAddNewBilling.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddNewBilling.Location = new System.Drawing.Point(4, 76);
            this.lblAddNewBilling.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddNewBilling.Name = "lblAddNewBilling";
            this.lblAddNewBilling.Size = new System.Drawing.Size(53, 15);
            this.lblAddNewBilling.TabIndex = 25;
            this.lblAddNewBilling.TabStop = true;
            this.lblAddNewBilling.Text = "add new";
            this.lblAddNewBilling.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAddNewBilling_LinkClicked);
            // 
            // ctl_shippingaddress
            // 
            this.ctl_shippingaddress.BackColor = System.Drawing.Color.Transparent;
            this.ctl_shippingaddress.Bold = false;
            this.ctl_shippingaddress.Caption = "";
            this.ctl_shippingaddress.Changed = false;
            this.ctl_shippingaddress.DateLines = false;
            this.ctl_shippingaddress.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_shippingaddress.Location = new System.Drawing.Point(331, 98);
            this.ctl_shippingaddress.Margin = new System.Windows.Forms.Padding(7);
            this.ctl_shippingaddress.Name = "ctl_shippingaddress";
            this.ctl_shippingaddress.Size = new System.Drawing.Size(291, 149);
            this.ctl_shippingaddress.TabIndex = 19;
            this.ctl_shippingaddress.UseParentBackColor = true;
            this.ctl_shippingaddress.zz_Enabled = true;
            this.ctl_shippingaddress.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_shippingaddress.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_shippingaddress.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_shippingaddress.zz_LabelFont = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_shippingaddress.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_shippingaddress.zz_OriginalDesign = false;
            this.ctl_shippingaddress.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_shippingaddress.zz_ShowNeedsSaveColor = true;
            this.ctl_shippingaddress.zz_Text = "";
            this.ctl_shippingaddress.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_shippingaddress.zz_TextFont = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.ctl_billingaddress.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_billingaddress.Location = new System.Drawing.Point(4, 98);
            this.ctl_billingaddress.Margin = new System.Windows.Forms.Padding(7);
            this.ctl_billingaddress.Name = "ctl_billingaddress";
            this.ctl_billingaddress.Size = new System.Drawing.Size(291, 149);
            this.ctl_billingaddress.TabIndex = 16;
            this.ctl_billingaddress.UseParentBackColor = true;
            this.ctl_billingaddress.zz_Enabled = true;
            this.ctl_billingaddress.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_billingaddress.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_billingaddress.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_billingaddress.zz_LabelFont = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_billingaddress.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_billingaddress.zz_OriginalDesign = false;
            this.ctl_billingaddress.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_billingaddress.zz_ShowNeedsSaveColor = true;
            this.ctl_billingaddress.zz_Text = "";
            this.ctl_billingaddress.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_billingaddress.zz_TextFont = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.cboBillingAddress.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBillingAddress.ListName = null;
            this.cboBillingAddress.Location = new System.Drawing.Point(4, 33);
            this.cboBillingAddress.Margin = new System.Windows.Forms.Padding(7);
            this.cboBillingAddress.Name = "cboBillingAddress";
            this.cboBillingAddress.SimpleList = null;
            this.cboBillingAddress.Size = new System.Drawing.Size(291, 22);
            this.cboBillingAddress.TabIndex = 15;
            this.cboBillingAddress.UseParentBackColor = true;
            this.cboBillingAddress.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboBillingAddress.zz_GlobalColor = System.Drawing.Color.Black;
            this.cboBillingAddress.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cboBillingAddress.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.cboBillingAddress.zz_LabelFont = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBillingAddress.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.Left;
            this.cboBillingAddress.zz_OriginalDesign = false;
            this.cboBillingAddress.zz_ShowNeedsSaveColor = true;
            this.cboBillingAddress.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.cboBillingAddress.zz_TextFont = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.cboShippingAddress.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboShippingAddress.ListName = null;
            this.cboShippingAddress.Location = new System.Drawing.Point(331, 37);
            this.cboShippingAddress.Margin = new System.Windows.Forms.Padding(7);
            this.cboShippingAddress.Name = "cboShippingAddress";
            this.cboShippingAddress.SimpleList = null;
            this.cboShippingAddress.Size = new System.Drawing.Size(287, 22);
            this.cboShippingAddress.TabIndex = 18;
            this.cboShippingAddress.UseParentBackColor = true;
            this.cboShippingAddress.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboShippingAddress.zz_GlobalColor = System.Drawing.Color.Black;
            this.cboShippingAddress.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cboShippingAddress.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.cboShippingAddress.zz_LabelFont = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboShippingAddress.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.Left;
            this.cboShippingAddress.zz_OriginalDesign = false;
            this.cboShippingAddress.zz_ShowNeedsSaveColor = true;
            this.cboShippingAddress.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.cboShippingAddress.zz_TextFont = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboShippingAddress.zz_UseGlobalColor = false;
            this.cboShippingAddress.zz_UseGlobalFont = false;
            this.cboShippingAddress.SelectionChanged += new NewMethod.nEdit_List.SelectionChangedHandler(this.cboShippingAddress_SelectionChanged);
            // 
            // ctl_shippingname
            // 
            this.ctl_shippingname.AllCaps = false;
            this.ctl_shippingname.BackColor = System.Drawing.Color.Transparent;
            this.ctl_shippingname.Bold = false;
            this.ctl_shippingname.Caption = "Shipping Name     ";
            this.ctl_shippingname.Changed = false;
            this.ctl_shippingname.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_shippingname.IsEmail = false;
            this.ctl_shippingname.IsURL = false;
            this.ctl_shippingname.Location = new System.Drawing.Point(331, 7);
            this.ctl_shippingname.Margin = new System.Windows.Forms.Padding(7);
            this.ctl_shippingname.Name = "ctl_shippingname";
            this.ctl_shippingname.PasswordChar = '\0';
            this.ctl_shippingname.Size = new System.Drawing.Size(287, 22);
            this.ctl_shippingname.TabIndex = 17;
            this.ctl_shippingname.UseParentBackColor = true;
            this.ctl_shippingname.zz_Enabled = true;
            this.ctl_shippingname.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_shippingname.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_shippingname.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_shippingname.zz_LabelFont = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_shippingname.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.Left;
            this.ctl_shippingname.zz_OriginalDesign = false;
            this.ctl_shippingname.zz_ShowLinkButton = false;
            this.ctl_shippingname.zz_ShowNeedsSaveColor = true;
            this.ctl_shippingname.zz_Text = "";
            this.ctl_shippingname.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_shippingname.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_shippingname.zz_TextFont = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_shippingname.zz_UseGlobalColor = false;
            this.ctl_shippingname.zz_UseGlobalFont = false;
            // 
            // ctl_billingname
            // 
            this.ctl_billingname.AllCaps = false;
            this.ctl_billingname.BackColor = System.Drawing.Color.Transparent;
            this.ctl_billingname.Bold = false;
            this.ctl_billingname.Caption = "Billing Name     ";
            this.ctl_billingname.Changed = false;
            this.ctl_billingname.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_billingname.IsEmail = false;
            this.ctl_billingname.IsURL = false;
            this.ctl_billingname.Location = new System.Drawing.Point(4, 4);
            this.ctl_billingname.Margin = new System.Windows.Forms.Padding(7);
            this.ctl_billingname.Name = "ctl_billingname";
            this.ctl_billingname.PasswordChar = '\0';
            this.ctl_billingname.Size = new System.Drawing.Size(291, 22);
            this.ctl_billingname.TabIndex = 14;
            this.ctl_billingname.UseParentBackColor = true;
            this.ctl_billingname.zz_Enabled = true;
            this.ctl_billingname.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_billingname.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_billingname.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_billingname.zz_LabelFont = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_billingname.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.Left;
            this.ctl_billingname.zz_OriginalDesign = false;
            this.ctl_billingname.zz_ShowLinkButton = false;
            this.ctl_billingname.zz_ShowNeedsSaveColor = true;
            this.ctl_billingname.zz_Text = "";
            this.ctl_billingname.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_billingname.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_billingname.zz_TextFont = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_billingname.zz_UseGlobalColor = false;
            this.ctl_billingname.zz_UseGlobalFont = false;
            // 
            // tabCompany
            // 
            this.tabCompany.Controls.Add(this.agent);
            this.tabCompany.Controls.Add(this.lblOutstandingInvoiceAmnt);
            this.tabCompany.Controls.Add(this.lblProblemCustomer);
            this.tabCompany.Controls.Add(this.lblCompanyCreditAmount);
            this.tabCompany.Controls.Add(this.lblCompanyCreditAlert);
            this.tabCompany.Controls.Add(this.lblChangeDate);
            this.tabCompany.Controls.Add(this.nlblordertime);
            this.tabCompany.Controls.Add(this.nlblorderdate);
            this.tabCompany.Controls.Add(this.ctl_primaryphone);
            this.tabCompany.Controls.Add(this.ctl_primaryfax);
            this.tabCompany.Controls.Add(this.ctl_primaryemailaddress);
            this.tabCompany.Controls.Add(this.cStub);
            this.tabCompany.Location = new System.Drawing.Point(4, 22);
            this.tabCompany.Margin = new System.Windows.Forms.Padding(4);
            this.tabCompany.Name = "tabCompany";
            this.tabCompany.Padding = new System.Windows.Forms.Padding(4);
            this.tabCompany.Size = new System.Drawing.Size(628, 256);
            this.tabCompany.TabIndex = 0;
            this.tabCompany.Text = "Company";
            this.tabCompany.UseVisualStyleBackColor = true;
            // 
            // agent
            // 
            this.agent.AllowChange = true;
            this.agent.AllowClear = false;
            this.agent.AllowNew = false;
            this.agent.AllowView = false;
            this.agent.BackColor = System.Drawing.Color.Transparent;
            this.agent.Bold = false;
            this.agent.Caption = "Sales Agent";
            this.agent.Changed = false;
            this.agent.Location = new System.Drawing.Point(368, 7);
            this.agent.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.agent.Name = "agent";
            this.agent.Size = new System.Drawing.Size(144, 49);
            this.agent.TabIndex = 13;
            this.agent.UseParentBackColor = true;
            this.agent.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.agent.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // lblOutstandingInvoiceAmnt
            // 
            this.lblOutstandingInvoiceAmnt.AutoSize = true;
            this.lblOutstandingInvoiceAmnt.BackColor = System.Drawing.Color.Yellow;
            this.lblOutstandingInvoiceAmnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutstandingInvoiceAmnt.ForeColor = System.Drawing.Color.Red;
            this.lblOutstandingInvoiceAmnt.Location = new System.Drawing.Point(283, 98);
            this.lblOutstandingInvoiceAmnt.Name = "lblOutstandingInvoiceAmnt";
            this.lblOutstandingInvoiceAmnt.Size = new System.Drawing.Size(48, 13);
            this.lblOutstandingInvoiceAmnt.TabIndex = 63;
            this.lblOutstandingInvoiceAmnt.Text = "<label>";
            // 
            // lblCompanyCreditAmount
            // 
            this.lblCompanyCreditAmount.AutoSize = true;
            this.lblCompanyCreditAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyCreditAmount.ForeColor = System.Drawing.Color.Red;
            this.lblCompanyCreditAmount.Location = new System.Drawing.Point(231, 98);
            this.lblCompanyCreditAmount.Name = "lblCompanyCreditAmount";
            this.lblCompanyCreditAmount.Size = new System.Drawing.Size(41, 13);
            this.lblCompanyCreditAmount.TabIndex = 53;
            this.lblCompanyCreditAmount.Text = "label1";
            this.lblCompanyCreditAmount.Visible = false;
            // 
            // lblCompanyCreditAlert
            // 
            this.lblCompanyCreditAlert.AutoSize = true;
            this.lblCompanyCreditAlert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyCreditAlert.ForeColor = System.Drawing.Color.Red;
            this.lblCompanyCreditAlert.Location = new System.Drawing.Point(121, 99);
            this.lblCompanyCreditAlert.Name = "lblCompanyCreditAlert";
            this.lblCompanyCreditAlert.Size = new System.Drawing.Size(104, 13);
            this.lblCompanyCreditAlert.TabIndex = 52;
            this.lblCompanyCreditAlert.Text = "Credit Available: ";
            this.lblCompanyCreditAlert.Visible = false;
            // 
            // lblChangeDate
            // 
            this.lblChangeDate.AutoSize = true;
            this.lblChangeDate.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeDate.Location = new System.Drawing.Point(279, 77);
            this.lblChangeDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChangeDate.Name = "lblChangeDate";
            this.lblChangeDate.Size = new System.Drawing.Size(65, 13);
            this.lblChangeDate.TabIndex = 23;
            this.lblChangeDate.TabStop = true;
            this.lblChangeDate.Text = "change date";
            this.lblChangeDate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblChangeDate_LinkClicked);
            // 
            // nlblordertime
            // 
            this.nlblordertime.AutoScroll = true;
            this.nlblordertime.BackColor = System.Drawing.Color.Transparent;
            this.nlblordertime.Bold = false;
            this.nlblordertime.Caption = "";
            this.nlblordertime.Changed = false;
            this.nlblordertime.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nlblordertime.Location = new System.Drawing.Point(264, 52);
            this.nlblordertime.Margin = new System.Windows.Forms.Padding(5);
            this.nlblordertime.Name = "nlblordertime";
            this.nlblordertime.Size = new System.Drawing.Size(92, 20);
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
            this.nlblordertime.zz_TextFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.nlblorderdate.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nlblorderdate.Location = new System.Drawing.Point(264, 7);
            this.nlblorderdate.Margin = new System.Windows.Forms.Padding(5);
            this.nlblorderdate.Name = "nlblorderdate";
            this.nlblorderdate.Size = new System.Drawing.Size(92, 39);
            this.nlblorderdate.TabIndex = 18;
            this.nlblorderdate.UseParentBackColor = false;
            this.nlblorderdate.zz_CaptionLabelBackColor = System.Drawing.Color.Transparent;
            this.nlblorderdate.zz_GlobalColor = System.Drawing.Color.Black;
            this.nlblorderdate.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nlblorderdate.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.nlblorderdate.zz_LabelFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nlblorderdate.zz_LabelLocation = NewMethod.Views.Edits.nEdit_Label.LabelLocations.TopCenter;
            this.nlblorderdate.zz_OriginalDesign = false;
            this.nlblorderdate.zz_Text = "00/00/0000";
            this.nlblorderdate.zz_TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.nlblorderdate.zz_TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.nlblorderdate.zz_TextFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nlblorderdate.zz_UseGlobalColor = false;
            this.nlblorderdate.zz_UseGlobalFont = false;
            this.nlblorderdate.zz_ValueLabelBackColor = System.Drawing.Color.Transparent;
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
            this.ctl_primaryphone.Location = new System.Drawing.Point(8, 128);
            this.ctl_primaryphone.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_primaryphone.Name = "ctl_primaryphone";
            this.ctl_primaryphone.PasswordChar = '\0';
            this.ctl_primaryphone.Size = new System.Drawing.Size(200, 28);
            this.ctl_primaryphone.TabIndex = 2;
            this.ctl_primaryphone.UseParentBackColor = true;
            this.ctl_primaryphone.zz_Enabled = true;
            this.ctl_primaryphone.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_primaryphone.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_primaryphone.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_primaryphone.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_primaryphone.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.Left;
            this.ctl_primaryphone.zz_OriginalDesign = false;
            this.ctl_primaryphone.zz_ShowLinkButton = false;
            this.ctl_primaryphone.zz_ShowNeedsSaveColor = true;
            this.ctl_primaryphone.zz_Text = "";
            this.ctl_primaryphone.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_primaryphone.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_primaryphone.zz_TextFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_primaryphone.zz_UseGlobalColor = false;
            this.ctl_primaryphone.zz_UseGlobalFont = false;
            // 
            // ctl_primaryfax
            // 
            this.ctl_primaryfax.AllCaps = false;
            this.ctl_primaryfax.BackColor = System.Drawing.Color.Transparent;
            this.ctl_primaryfax.Bold = false;
            this.ctl_primaryfax.Caption = "Fax     ";
            this.ctl_primaryfax.Changed = false;
            this.ctl_primaryfax.IsEmail = false;
            this.ctl_primaryfax.IsURL = false;
            this.ctl_primaryfax.Location = new System.Drawing.Point(8, 169);
            this.ctl_primaryfax.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_primaryfax.Name = "ctl_primaryfax";
            this.ctl_primaryfax.PasswordChar = '\0';
            this.ctl_primaryfax.Size = new System.Drawing.Size(200, 28);
            this.ctl_primaryfax.TabIndex = 3;
            this.ctl_primaryfax.UseParentBackColor = true;
            this.ctl_primaryfax.zz_Enabled = true;
            this.ctl_primaryfax.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_primaryfax.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_primaryfax.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_primaryfax.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_primaryfax.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.Left;
            this.ctl_primaryfax.zz_OriginalDesign = false;
            this.ctl_primaryfax.zz_ShowLinkButton = false;
            this.ctl_primaryfax.zz_ShowNeedsSaveColor = true;
            this.ctl_primaryfax.zz_Text = "";
            this.ctl_primaryfax.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_primaryfax.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_primaryfax.zz_TextFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_primaryfax.zz_UseGlobalColor = false;
            this.ctl_primaryfax.zz_UseGlobalFont = false;
            // 
            // ctl_primaryemailaddress
            // 
            this.ctl_primaryemailaddress.AllCaps = false;
            this.ctl_primaryemailaddress.BackColor = System.Drawing.Color.Transparent;
            this.ctl_primaryemailaddress.Bold = false;
            this.ctl_primaryemailaddress.Caption = "Email ";
            this.ctl_primaryemailaddress.Changed = false;
            this.ctl_primaryemailaddress.IsEmail = false;
            this.ctl_primaryemailaddress.IsURL = false;
            this.ctl_primaryemailaddress.Location = new System.Drawing.Point(8, 211);
            this.ctl_primaryemailaddress.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_primaryemailaddress.Name = "ctl_primaryemailaddress";
            this.ctl_primaryemailaddress.PasswordChar = '\0';
            this.ctl_primaryemailaddress.Size = new System.Drawing.Size(200, 28);
            this.ctl_primaryemailaddress.TabIndex = 4;
            this.ctl_primaryemailaddress.UseParentBackColor = true;
            this.ctl_primaryemailaddress.zz_Enabled = true;
            this.ctl_primaryemailaddress.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_primaryemailaddress.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_primaryemailaddress.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_primaryemailaddress.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_primaryemailaddress.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.Left;
            this.ctl_primaryemailaddress.zz_OriginalDesign = false;
            this.ctl_primaryemailaddress.zz_ShowLinkButton = false;
            this.ctl_primaryemailaddress.zz_ShowNeedsSaveColor = true;
            this.ctl_primaryemailaddress.zz_Text = "";
            this.ctl_primaryemailaddress.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_primaryemailaddress.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_primaryemailaddress.zz_TextFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_primaryemailaddress.zz_UseGlobalColor = false;
            this.ctl_primaryemailaddress.zz_UseGlobalFont = false;
            // 
            // cStub
            // 
            this.cStub.Caption = "Customer";
            this.cStub.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cStub.Location = new System.Drawing.Point(4, 5);
            this.cStub.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cStub.Name = "cStub";
            this.cStub.Size = new System.Drawing.Size(250, 110);
            this.cStub.TabIndex = 1;
            this.cStub.ChangeContact += new Rz5.ContactEventHandler(this.cStub_ChangeContact);
            this.cStub.ChangeCompany += new Rz5.ContactEventHandler(this.cStub_ChangeCompany);
            // 
            // ts
            // 
            this.ts.Controls.Add(this.tabCompany);
            this.ts.Controls.Add(this.tabAddress);
            this.ts.Controls.Add(this.tabShipping);
            this.ts.Controls.Add(this.tabOther);
            this.ts.Controls.Add(this.tabNotes);
            this.ts.Controls.Add(this.tabCompanyCredits);
            this.ts.Controls.Add(this.tabCreditsCharges);
            this.ts.Location = new System.Drawing.Point(3, 63);
            this.ts.Margin = new System.Windows.Forms.Padding(4);
            this.ts.Name = "ts";
            this.ts.SelectedIndex = 0;
            this.ts.Size = new System.Drawing.Size(636, 282);
            this.ts.TabIndex = 7;
            this.ts.SelectedIndexChanged += new System.EventHandler(this.ts_SelectedIndexChanged);
            // 
            // ViewHeader
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbHubspot);
            this.Controls.Add(this.gbAddedToQb);
            this.Controls.Add(this.gbReport);
            this.Controls.Add(this.picVoid);
            this.Controls.Add(this.picOpen);
            this.Controls.Add(this.picHold);
            this.Controls.Add(this.picComplete);
            this.Controls.Add(this.gbAction2);
            this.Controls.Add(this.tsDetails);
            this.Controls.Add(this.gbTotals);
            this.Controls.Add(this.gbAction1);
            this.Controls.Add(this.ts);
            this.Controls.Add(this.picHeader);
            this.Margin = new System.Windows.Forms.Padding(12, 9, 12, 9);
            this.Name = "ViewHeader";
            this.Size = new System.Drawing.Size(1495, 945);
            this.Controls.SetChildIndex(this.picHeader, 0);
            this.Controls.SetChildIndex(this.ts, 0);
            this.Controls.SetChildIndex(this.gbAction1, 0);
            this.Controls.SetChildIndex(this.gbTotals, 0);
            this.Controls.SetChildIndex(this.tsDetails, 0);
            this.Controls.SetChildIndex(this.gbAction2, 0);
            this.Controls.SetChildIndex(this.picComplete, 0);
            this.Controls.SetChildIndex(this.picHold, 0);
            this.Controls.SetChildIndex(this.picOpen, 0);
            this.Controls.SetChildIndex(this.picVoid, 0);
            this.Controls.SetChildIndex(this.gbReport, 0);
            this.Controls.SetChildIndex(this.gbAddedToQb, 0);
            this.Controls.SetChildIndex(this.xActions, 0);
            this.Controls.SetChildIndex(this.gbHubspot, 0);
            this.gbAction1.ResumeLayout(false);
            this.gbAction1.PerformLayout();
            this.gbAction2.ResumeLayout(false);
            this.gbAction2.PerformLayout();
            this.tabAttachments.ResumeLayout(false);
            this.tabLines.ResumeLayout(false);
            this.tabLines.PerformLayout();
            this.tsDetails.ResumeLayout(false);
            this.gbReport.ResumeLayout(false);
            this.gbAddedToQb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbQbAdded)).EndInit();
            this.gbHubspot.ResumeLayout(false);
            this.gbHubspot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVoid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOpen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picComplete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).EndInit();
            this.tabCreditsCharges.ResumeLayout(false);
            this.tabCompanyCredits.ResumeLayout(false);
            this.tabCompanyCredits.PerformLayout();
            this.tabNotes.ResumeLayout(false);
            this.tabOther.ResumeLayout(false);
            this.tabShipping.ResumeLayout(false);
            this.tabAddress.ResumeLayout(false);
            this.tabAddress.PerformLayout();
            this.tabCompany.ResumeLayout(false);
            this.tabCompany.PerformLayout();
            this.ts.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker bg;
        protected System.Windows.Forms.Button cmdAction1;
        protected System.Windows.Forms.Label lblLineStatus1;
        protected System.Windows.Forms.Label lblLineStatus2;
        protected nThrobber throb1;
        protected nThrobber throb2;
        protected System.Windows.Forms.GroupBox gbTotals;
        private System.Windows.Forms.ToolTip toolTip1;
        protected System.Windows.Forms.Panel gbAction1;
        protected System.Windows.Forms.Panel gbAction2;
        protected System.Windows.Forms.Button cmdAction2;
        private System.Windows.Forms.ImageList ilActions;
        protected System.Windows.Forms.PictureBox picHeader;
        private System.Windows.Forms.PictureBox picComplete;
        private System.Windows.Forms.PictureBox picHold;
        private System.Windows.Forms.PictureBox picOpen;
        private System.Windows.Forms.PictureBox picVoid;
        protected System.Windows.Forms.TabPage tabAttachments;
        private PartPictureViewer picview;
        protected System.Windows.Forms.TabPage tabLines;
        private System.Windows.Forms.LinkLabel lblSaveThisOrder;
        protected nList details;
        public System.Windows.Forms.TabControl tsDetails;
        protected System.Windows.Forms.GroupBox gbReport;
        protected System.Windows.Forms.RichTextBox rtReport;
        public System.Windows.Forms.Button btnFixComplete;
        private System.Windows.Forms.GroupBox gbAddedToQb;
        private System.Windows.Forms.PictureBox pbQbAdded;
        private System.Windows.Forms.GroupBox gbHubspot;
        private System.Windows.Forms.LinkLabel llblDealLink;
        private System.Windows.Forms.Button btnHubspot;
        private System.Windows.Forms.TabPage tabCreditsCharges;
        private nList lvCreditCharges;
        private System.Windows.Forms.TabPage tabCompanyCredits;
        private System.Windows.Forms.CheckBox cbxShowUsedCredits;
        private System.Windows.Forms.Button btnAssignCredit;
        private System.Windows.Forms.Button btnEditCredit;
        private System.Windows.Forms.Button btnAddCredit;
        private nList nListCompanyCredits;
        public System.Windows.Forms.TabPage tabNotes;
        protected nEdit_Memo ctl_printcomment;
        protected nEdit_Memo ctl_internalcomment;
        protected System.Windows.Forms.TabPage tabOther;
        protected nEdit_Boolean ctl_is_confirmed;
        protected nEdit_Boolean ctl_senttoqb;
        protected System.Windows.Forms.TabPage tabShipping;
        protected System.Windows.Forms.Button cmdSetShipAccounts;
        protected System.Windows.Forms.Button cmdSetShipVia;
        protected nEdit_Memo ctl_trackingnumber;
        protected System.Windows.Forms.ListView lvAccount;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        protected System.Windows.Forms.ListView lvShipVia;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        protected nEdit_List ctl_shippingaccount;
        protected nEdit_List ctl_shipvia;
        public System.Windows.Forms.TabPage tabAddress;
        protected System.Windows.Forms.Button cmdPasteBill;
        protected System.Windows.Forms.Button cmdSwitchAddress;
        protected System.Windows.Forms.LinkLabel lblAddNewShiping;
        protected System.Windows.Forms.LinkLabel lblAddNewBilling;
        protected System.Windows.Forms.Button cmdShipBill;
        protected System.Windows.Forms.Button cmdBillShip;
        protected nEdit_Memo ctl_shippingaddress;
        protected nEdit_Memo ctl_billingaddress;
        protected nEdit_List cboBillingAddress;
        protected nEdit_List cboShippingAddress;
        protected nEdit_String ctl_shippingname;
        protected nEdit_String ctl_billingname;
        public System.Windows.Forms.TabPage tabCompany;
        public nEdit_User agent;
        private System.Windows.Forms.Label lblOutstandingInvoiceAmnt;
        private System.Windows.Forms.Label lblProblemCustomer;
        private System.Windows.Forms.Label lblCompanyCreditAmount;
        private System.Windows.Forms.Label lblCompanyCreditAlert;
        protected System.Windows.Forms.LinkLabel lblChangeDate;
        public NewMethod.Views.Edits.nEdit_Label nlblordertime;
        protected NewMethod.Views.Edits.nEdit_Label nlblorderdate;
        public nEdit_String ctl_primaryphone;
        public nEdit_String ctl_primaryfax;
        public nEdit_String ctl_primaryemailaddress;
        public CompanyStub_PlusContact cStub;
        public System.Windows.Forms.TabControl ts;
        private System.Windows.Forms.LinkLabel llEditHubspotDeal;
    }
}
