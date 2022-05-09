namespace RzInterfaceWin
{
    partial class ViewCreditMemo
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
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.postButton = new System.Windows.Forms.Button();
            this.tsDetails = new System.Windows.Forms.TabControl();
            this.tabLines = new System.Windows.Forms.TabPage();
            this.lblSaveThisOrder = new System.Windows.Forms.LinkLabel();
            this.details = new NewMethod.nList();
            this.tabAttachments = new System.Windows.Forms.TabPage();
            this.picview = new Rz5.PartPictureViewer();
            this.gbTotals = new System.Windows.Forms.GroupBox();
            this.ts = new System.Windows.Forms.TabControl();
            this.tabCompany = new System.Windows.Forms.TabPage();
            this.nlblorderdate = new NewMethod.Views.Edits.nEdit_Label();
            this.lblChangeDate = new System.Windows.Forms.LinkLabel();
            this.nlblordertime = new NewMethod.Views.Edits.nEdit_Label();
            this.cStub = new Rz5.CompanyStub_PlusContact();
            this.tabNotes = new System.Windows.Forms.TabPage();
            this.ctl_internalcomment = new NewMethod.nEdit_Memo();
            this.picVoid = new System.Windows.Forms.PictureBox();
            this.picOpen = new System.Windows.Forms.PictureBox();
            this.picHold = new System.Windows.Forms.PictureBox();
            this.picComplete = new System.Windows.Forms.PictureBox();
            this.picHeader = new System.Windows.Forms.PictureBox();
            this.pDetail = new System.Windows.Forms.Panel();
            this.expenseAccount = new NewMethod.nEdit_List();
            this.unitPrice = new NewMethod.nEdit_Money();
            this.saveDetailButton = new System.Windows.Forms.Button();
            this.quantity = new NewMethod.nEdit_Number();
            this.partNumber = new NewMethod.nEdit_String();
            this.tsDetails.SuspendLayout();
            this.tabLines.SuspendLayout();
            this.tabAttachments.SuspendLayout();
            this.ts.SuspendLayout();
            this.tabCompany.SuspendLayout();
            this.tabNotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVoid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOpen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picComplete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).BeginInit();
            this.pDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // xActions
            // 
            this.xActions.Location = new System.Drawing.Point(1053, 0);
            this.xActions.Size = new System.Drawing.Size(195, 580);
            // 
            // postButton
            // 
            this.postButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.postButton.Location = new System.Drawing.Point(497, 3);
            this.postButton.Name = "postButton";
            this.postButton.Size = new System.Drawing.Size(122, 49);
            this.postButton.TabIndex = 61;
            this.postButton.Text = "Post";
            this.postButton.UseVisualStyleBackColor = true;
            this.postButton.Click += new System.EventHandler(this.postButton_Click);
            // 
            // tsDetails
            // 
            this.tsDetails.Controls.Add(this.tabLines);
            this.tsDetails.Controls.Add(this.tabAttachments);
            this.tsDetails.Location = new System.Drawing.Point(-1, 187);
            this.tsDetails.Name = "tsDetails";
            this.tsDetails.SelectedIndex = 0;
            this.tsDetails.Size = new System.Drawing.Size(872, 304);
            this.tsDetails.TabIndex = 56;
            this.tsDetails.SelectedIndexChanged += new System.EventHandler(this.tsDetails_SelectedIndexChanged);
            // 
            // tabLines
            // 
            this.tabLines.Controls.Add(this.lblSaveThisOrder);
            this.tabLines.Controls.Add(this.details);
            this.tabLines.Location = new System.Drawing.Point(4, 25);
            this.tabLines.Name = "tabLines";
            this.tabLines.Padding = new System.Windows.Forms.Padding(3);
            this.tabLines.Size = new System.Drawing.Size(864, 275);
            this.tabLines.TabIndex = 0;
            this.tabLines.Text = "Lines";
            this.tabLines.UseVisualStyleBackColor = true;
            // 
            // lblSaveThisOrder
            // 
            this.lblSaveThisOrder.AutoSize = true;
            this.lblSaveThisOrder.Location = new System.Drawing.Point(211, 172);
            this.lblSaveThisOrder.Name = "lblSaveThisOrder";
            this.lblSaveThisOrder.Size = new System.Drawing.Size(226, 17);
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
            this.details.Location = new System.Drawing.Point(3, 3);
            this.details.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.details.MultiSelect = true;
            this.details.Name = "details";
            this.details.Size = new System.Drawing.Size(858, 269);
            this.details.SuppressSelectionChanged = false;
            this.details.TabIndex = 9;
            this.details.zz_OpenColumnMenu = false;
            this.details.zz_OrderLineType = "";
            this.details.zz_ShowAutoRefresh = true;
            this.details.zz_ShowUnlimited = true;
            this.details.AboutToThrow += new Core.ShowHandler(this.details_AboutToThrow);
            this.details.AboutToAdd += new NewMethod.AddHandler(this.details_AboutToAdd);
            // 
            // tabAttachments
            // 
            this.tabAttachments.Controls.Add(this.picview);
            this.tabAttachments.Location = new System.Drawing.Point(4, 25);
            this.tabAttachments.Name = "tabAttachments";
            this.tabAttachments.Size = new System.Drawing.Size(864, 275);
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
            this.picview.Name = "picview";
            this.picview.ShowFullScreenButton = true;
            this.picview.ShowPartNumberLink = false;
            this.picview.ShowPartSearch = false;
            this.picview.ShowZoomButton = true;
            this.picview.Size = new System.Drawing.Size(864, 275);
            this.picview.TabIndex = 1;
            this.picview.TemplateName = "PartPictureViewer";
            // 
            // gbTotals
            // 
            this.gbTotals.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTotals.Location = new System.Drawing.Point(481, 72);
            this.gbTotals.Name = "gbTotals";
            this.gbTotals.Size = new System.Drawing.Size(269, 109);
            this.gbTotals.TabIndex = 55;
            this.gbTotals.TabStop = false;
            this.gbTotals.Text = "Totals";
            // 
            // ts
            // 
            this.ts.Controls.Add(this.tabCompany);
            this.ts.Controls.Add(this.tabNotes);
            this.ts.Location = new System.Drawing.Point(-1, 52);
            this.ts.Name = "ts";
            this.ts.SelectedIndex = 0;
            this.ts.Size = new System.Drawing.Size(477, 129);
            this.ts.TabIndex = 53;
            // 
            // tabCompany
            // 
            this.tabCompany.Controls.Add(this.nlblorderdate);
            this.tabCompany.Controls.Add(this.lblChangeDate);
            this.tabCompany.Controls.Add(this.nlblordertime);
            this.tabCompany.Controls.Add(this.cStub);
            this.tabCompany.Location = new System.Drawing.Point(4, 25);
            this.tabCompany.Name = "tabCompany";
            this.tabCompany.Padding = new System.Windows.Forms.Padding(3);
            this.tabCompany.Size = new System.Drawing.Size(469, 100);
            this.tabCompany.TabIndex = 0;
            this.tabCompany.Text = "Company";
            this.tabCompany.UseVisualStyleBackColor = true;
            // 
            // nlblorderdate
            // 
            this.nlblorderdate.BackColor = System.Drawing.Color.Transparent;
            this.nlblorderdate.Bold = false;
            this.nlblorderdate.Caption = "Order Date";
            this.nlblorderdate.Changed = false;
            this.nlblorderdate.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nlblorderdate.Location = new System.Drawing.Point(325, 4);
            this.nlblorderdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nlblorderdate.Name = "nlblorderdate";
            this.nlblorderdate.Size = new System.Drawing.Size(108, 49);
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
            // lblChangeDate
            // 
            this.lblChangeDate.AutoSize = true;
            this.lblChangeDate.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeDate.Location = new System.Drawing.Point(340, 75);
            this.lblChangeDate.Name = "lblChangeDate";
            this.lblChangeDate.Size = new System.Drawing.Size(78, 17);
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
            this.nlblordertime.Location = new System.Drawing.Point(331, 47);
            this.nlblordertime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nlblordertime.Name = "nlblordertime";
            this.nlblordertime.Size = new System.Drawing.Size(96, 25);
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
            // cStub
            // 
            this.cStub.Caption = "Company";
            this.cStub.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cStub.Location = new System.Drawing.Point(3, 4);
            this.cStub.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cStub.Name = "cStub";
            this.cStub.Size = new System.Drawing.Size(252, 89);
            this.cStub.TabIndex = 1;
            this.cStub.ChangeContact += new Rz5.ContactEventHandler(this.cStub_ChangeContact);
            this.cStub.ChangeCompany += new Rz5.ContactEventHandler(this.cStub_ChangeCompany);
            // 
            // tabNotes
            // 
            this.tabNotes.Controls.Add(this.ctl_internalcomment);
            this.tabNotes.Location = new System.Drawing.Point(4, 25);
            this.tabNotes.Name = "tabNotes";
            this.tabNotes.Padding = new System.Windows.Forms.Padding(3);
            this.tabNotes.Size = new System.Drawing.Size(469, 100);
            this.tabNotes.TabIndex = 2;
            this.tabNotes.Text = "Notes";
            this.tabNotes.UseVisualStyleBackColor = true;
            // 
            // ctl_internalcomment
            // 
            this.ctl_internalcomment.BackColor = System.Drawing.Color.Transparent;
            this.ctl_internalcomment.Bold = false;
            this.ctl_internalcomment.Caption = "Internal Comment";
            this.ctl_internalcomment.Changed = false;
            this.ctl_internalcomment.DateLines = false;
            this.ctl_internalcomment.Location = new System.Drawing.Point(3, 6);
            this.ctl_internalcomment.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ctl_internalcomment.Name = "ctl_internalcomment";
            this.ctl_internalcomment.Size = new System.Drawing.Size(460, 91);
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
            // picVoid
            // 
            this.picVoid.BackColor = System.Drawing.Color.Transparent;
            this.picVoid.BackgroundImage = global::RzInterfaceWin.Properties.Resources.Void;
            this.picVoid.Location = new System.Drawing.Point(880, 202);
            this.picVoid.Name = "picVoid";
            this.picVoid.Size = new System.Drawing.Size(111, 44);
            this.picVoid.TabIndex = 60;
            this.picVoid.TabStop = false;
            this.picVoid.Visible = false;
            // 
            // picOpen
            // 
            this.picOpen.BackColor = System.Drawing.Color.Transparent;
            this.picOpen.BackgroundImage = global::RzInterfaceWin.Properties.Resources.Open;
            this.picOpen.Location = new System.Drawing.Point(880, 152);
            this.picOpen.Name = "picOpen";
            this.picOpen.Size = new System.Drawing.Size(126, 44);
            this.picOpen.TabIndex = 59;
            this.picOpen.TabStop = false;
            this.picOpen.Visible = false;
            // 
            // picHold
            // 
            this.picHold.BackColor = System.Drawing.Color.Transparent;
            this.picHold.BackgroundImage = global::RzInterfaceWin.Properties.Resources.Hold;
            this.picHold.Location = new System.Drawing.Point(880, 102);
            this.picHold.Name = "picHold";
            this.picHold.Size = new System.Drawing.Size(116, 44);
            this.picHold.TabIndex = 58;
            this.picHold.TabStop = false;
            this.picHold.Visible = false;
            // 
            // picComplete
            // 
            this.picComplete.BackColor = System.Drawing.Color.Transparent;
            this.picComplete.BackgroundImage = global::RzInterfaceWin.Properties.Resources.Complete;
            this.picComplete.Location = new System.Drawing.Point(880, 52);
            this.picComplete.Name = "picComplete";
            this.picComplete.Size = new System.Drawing.Size(162, 44);
            this.picComplete.TabIndex = 54;
            this.picComplete.TabStop = false;
            this.picComplete.Visible = false;
            // 
            // picHeader
            // 
            this.picHeader.BackColor = System.Drawing.Color.White;
            this.picHeader.BackgroundImage = global::RzInterfaceWin.Properties.Resources.BlueBar;
            this.picHeader.Location = new System.Drawing.Point(0, 0);
            this.picHeader.Name = "picHeader";
            this.picHeader.Size = new System.Drawing.Size(488, 50);
            this.picHeader.TabIndex = 57;
            this.picHeader.TabStop = false;
            this.picHeader.DoubleClick += new System.EventHandler(this.picHeader_DoubleClick);
            // 
            // pDetail
            // 
            this.pDetail.BackColor = System.Drawing.Color.White;
            this.pDetail.Controls.Add(this.expenseAccount);
            this.pDetail.Controls.Add(this.unitPrice);
            this.pDetail.Controls.Add(this.saveDetailButton);
            this.pDetail.Controls.Add(this.quantity);
            this.pDetail.Controls.Add(this.partNumber);
            this.pDetail.Location = new System.Drawing.Point(3, 495);
            this.pDetail.Name = "pDetail";
            this.pDetail.Size = new System.Drawing.Size(863, 67);
            this.pDetail.TabIndex = 62;
            this.pDetail.Visible = false;
            // 
            // expenseAccount
            // 
            this.expenseAccount.AllCaps = false;
            this.expenseAccount.AllowEdit = false;
            this.expenseAccount.BackColor = System.Drawing.Color.Transparent;
            this.expenseAccount.Bold = false;
            this.expenseAccount.Caption = "Account";
            this.expenseAccount.Changed = false;
            this.expenseAccount.ListName = null;
            this.expenseAccount.Location = new System.Drawing.Point(6, 6);
            this.expenseAccount.Margin = new System.Windows.Forms.Padding(4);
            this.expenseAccount.Name = "expenseAccount";
            this.expenseAccount.SimpleList = null;
            this.expenseAccount.Size = new System.Drawing.Size(298, 55);
            this.expenseAccount.TabIndex = 17;
            this.expenseAccount.UseParentBackColor = false;
            this.expenseAccount.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.expenseAccount.zz_GlobalColor = System.Drawing.Color.Black;
            this.expenseAccount.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.expenseAccount.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.expenseAccount.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F);
            this.expenseAccount.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.expenseAccount.zz_OriginalDesign = false;
            this.expenseAccount.zz_ShowNeedsSaveColor = true;
            this.expenseAccount.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.expenseAccount.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.expenseAccount.zz_UseGlobalColor = false;
            this.expenseAccount.zz_UseGlobalFont = false;
            // 
            // unitPrice
            // 
            this.unitPrice.BackColor = System.Drawing.Color.White;
            this.unitPrice.Bold = false;
            this.unitPrice.Caption = "Unit Price";
            this.unitPrice.Changed = false;
            this.unitPrice.EditCaption = false;
            this.unitPrice.FullDecimal = false;
            this.unitPrice.Location = new System.Drawing.Point(668, 5);
            this.unitPrice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.unitPrice.Name = "unitPrice";
            this.unitPrice.RoundNearestCent = false;
            this.unitPrice.Size = new System.Drawing.Size(82, 55);
            this.unitPrice.TabIndex = 16;
            this.unitPrice.UseParentBackColor = true;
            this.unitPrice.zz_Enabled = true;
            this.unitPrice.zz_GlobalColor = System.Drawing.Color.Black;
            this.unitPrice.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.unitPrice.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.unitPrice.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitPrice.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.unitPrice.zz_OriginalDesign = false;
            this.unitPrice.zz_ShowErrorColor = true;
            this.unitPrice.zz_ShowNeedsSaveColor = true;
            this.unitPrice.zz_Text = "";
            this.unitPrice.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.unitPrice.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.unitPrice.zz_TextFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitPrice.zz_UseGlobalColor = false;
            this.unitPrice.zz_UseGlobalFont = false;
            // 
            // saveDetailButton
            // 
            this.saveDetailButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveDetailButton.ImageKey = "Save";
            this.saveDetailButton.Location = new System.Drawing.Point(757, 19);
            this.saveDetailButton.Name = "saveDetailButton";
            this.saveDetailButton.Size = new System.Drawing.Size(43, 33);
            this.saveDetailButton.TabIndex = 15;
            this.saveDetailButton.Text = "OK";
            this.saveDetailButton.UseVisualStyleBackColor = true;
            this.saveDetailButton.Click += new System.EventHandler(this.saveDetailButton_Click);
            // 
            // quantity
            // 
            this.quantity.BackColor = System.Drawing.Color.White;
            this.quantity.Bold = false;
            this.quantity.Caption = "Quantity";
            this.quantity.Changed = false;
            this.quantity.CurrentType = Tools.Database.FieldType.Unknown;
            this.quantity.Location = new System.Drawing.Point(575, 5);
            this.quantity.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(86, 55);
            this.quantity.TabIndex = 14;
            this.quantity.UseParentBackColor = true;
            this.quantity.zz_Enabled = true;
            this.quantity.zz_GlobalColor = System.Drawing.Color.Black;
            this.quantity.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.quantity.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.quantity.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantity.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.quantity.zz_OriginalDesign = false;
            this.quantity.zz_ShowErrorColor = true;
            this.quantity.zz_ShowNeedsSaveColor = true;
            this.quantity.zz_Text = "";
            this.quantity.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.quantity.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.quantity.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.quantity.zz_UseGlobalColor = false;
            this.quantity.zz_UseGlobalFont = false;
            // 
            // partNumber
            // 
            this.partNumber.AllCaps = false;
            this.partNumber.BackColor = System.Drawing.Color.Transparent;
            this.partNumber.Bold = false;
            this.partNumber.Caption = "Item";
            this.partNumber.Changed = false;
            this.partNumber.IsEmail = false;
            this.partNumber.IsURL = false;
            this.partNumber.Location = new System.Drawing.Point(311, 6);
            this.partNumber.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.partNumber.Name = "partNumber";
            this.partNumber.PasswordChar = '\0';
            this.partNumber.Size = new System.Drawing.Size(257, 55);
            this.partNumber.TabIndex = 13;
            this.partNumber.UseParentBackColor = false;
            this.partNumber.zz_Enabled = true;
            this.partNumber.zz_GlobalColor = System.Drawing.Color.Black;
            this.partNumber.zz_GlobalFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partNumber.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.partNumber.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partNumber.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.partNumber.zz_OriginalDesign = false;
            this.partNumber.zz_ShowLinkButton = false;
            this.partNumber.zz_ShowNeedsSaveColor = true;
            this.partNumber.zz_Text = "";
            this.partNumber.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.partNumber.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.partNumber.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.partNumber.zz_UseGlobalColor = false;
            this.partNumber.zz_UseGlobalFont = false;
            // 
            // ViewCreditMemo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pDetail);
            this.Controls.Add(this.postButton);
            this.Controls.Add(this.picVoid);
            this.Controls.Add(this.picOpen);
            this.Controls.Add(this.picHold);
            this.Controls.Add(this.picComplete);
            this.Controls.Add(this.tsDetails);
            this.Controls.Add(this.gbTotals);
            this.Controls.Add(this.ts);
            this.Controls.Add(this.picHeader);
            this.Name = "ViewCreditMemo";
            this.Size = new System.Drawing.Size(1248, 580);
            this.Resize += new System.EventHandler(this.ViewCreditMemo_Resize);
            this.Controls.SetChildIndex(this.picHeader, 0);
            this.Controls.SetChildIndex(this.ts, 0);
            this.Controls.SetChildIndex(this.gbTotals, 0);
            this.Controls.SetChildIndex(this.tsDetails, 0);
            this.Controls.SetChildIndex(this.picComplete, 0);
            this.Controls.SetChildIndex(this.picHold, 0);
            this.Controls.SetChildIndex(this.picOpen, 0);
            this.Controls.SetChildIndex(this.picVoid, 0);
            this.Controls.SetChildIndex(this.postButton, 0);
            this.Controls.SetChildIndex(this.pDetail, 0);
            this.Controls.SetChildIndex(this.xActions, 0);
            this.tsDetails.ResumeLayout(false);
            this.tabLines.ResumeLayout(false);
            this.tabLines.PerformLayout();
            this.tabAttachments.ResumeLayout(false);
            this.ts.ResumeLayout(false);
            this.tabCompany.ResumeLayout(false);
            this.tabCompany.PerformLayout();
            this.tabNotes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picVoid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOpen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picComplete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).EndInit();
            this.pDetail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button postButton;
        private System.Windows.Forms.PictureBox picVoid;
        private System.Windows.Forms.PictureBox picOpen;
        private System.Windows.Forms.PictureBox picHold;
        private System.Windows.Forms.PictureBox picComplete;
        public System.Windows.Forms.TabControl tsDetails;
        protected System.Windows.Forms.TabPage tabLines;
        private System.Windows.Forms.LinkLabel lblSaveThisOrder;
        protected NewMethod.nList details;
        protected System.Windows.Forms.TabPage tabAttachments;
        private Rz5.PartPictureViewer picview;
        protected System.Windows.Forms.GroupBox gbTotals;
        public System.Windows.Forms.TabControl ts;
        public System.Windows.Forms.TabPage tabCompany;
        protected System.Windows.Forms.LinkLabel lblChangeDate;
        public NewMethod.Views.Edits.nEdit_Label nlblordertime;
        protected NewMethod.Views.Edits.nEdit_Label nlblorderdate;
        public Rz5.CompanyStub_PlusContact cStub;
        public System.Windows.Forms.TabPage tabNotes;
        protected NewMethod.nEdit_Memo ctl_internalcomment;
        protected System.Windows.Forms.PictureBox picHeader;
        private System.Windows.Forms.Panel pDetail;
        private NewMethod.nEdit_List expenseAccount;
        protected NewMethod.nEdit_Money unitPrice;
        private System.Windows.Forms.Button saveDetailButton;
        public NewMethod.nEdit_Number quantity;
        public NewMethod.nEdit_String partNumber;
    }
}
