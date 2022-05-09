namespace Rz5
{
    partial class SettingsPanel
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
            this.gbOrders = new System.Windows.Forms.GroupBox();
            this.cmdRestoreTemplates = new System.Windows.Forms.Button();
            this.cmdConvertTemplates = new System.Windows.Forms.Button();
            this.cmdShowOriginalTables = new System.Windows.Forms.Button();
            this.cmdHideOriginalTables = new System.Windows.Forms.Button();
            this.cmdDropViews = new System.Windows.Forms.Button();
            this.cmdCreateViews = new System.Windows.Forms.Button();
            this.cmdConvertToDistributed = new System.Windows.Forms.Button();
            this.chkDistributedOrders = new System.Windows.Forms.CheckBox();
            this.gbUpdates = new System.Windows.Forms.GroupBox();
            this.cmdApplyUpdates = new System.Windows.Forms.Button();
            this.ctlUpdateFolder = new NewMethod.nEdit_String();
            this.chkUpdateFromNetwork = new System.Windows.Forms.CheckBox();
            this.gbCreditCards = new System.Windows.Forms.GroupBox();
            this.ctlCC4 = new NewMethod.nEdit_String();
            this.ctlCC3 = new NewMethod.nEdit_String();
            this.ctlCC2 = new NewMethod.nEdit_String();
            this.ctlCC1 = new NewMethod.nEdit_String();
            this.cmdApplyCC = new System.Windows.Forms.Button();
            this.gbFax = new System.Windows.Forms.GroupBox();
            this.ctlFaxPrefix = new NewMethod.nEdit_String();
            this.ctlFaxIP = new NewMethod.nEdit_String();
            this.cmdApplyFax = new System.Windows.Forms.Button();
            this.gbMergedQuotes = new System.Windows.Forms.GroupBox();
            this.cmdCreateDealCompanies = new System.Windows.Forms.Button();
            this.cmdUpdateBatchLinks = new System.Windows.Forms.Button();
            this.cmdQuoteIDs = new System.Windows.Forms.Button();
            this.cmdReqBatches = new System.Windows.Forms.Button();
            this.cmdMergeReqs = new System.Windows.Forms.Button();
            this.cmdSeparateQuotes = new System.Windows.Forms.Button();
            this.cmdSeparateBids = new System.Windows.Forms.Button();
            this.chkMergedQuotes = new System.Windows.Forms.CheckBox();
            this.cmdUPSWorldship = new System.Windows.Forms.Button();
            this.cmdInsertUPSServices = new System.Windows.Forms.Button();
            this.chkQBsPosting = new System.Windows.Forms.CheckBox();
            this.gbOrders.SuspendLayout();
            this.gbUpdates.SuspendLayout();
            this.gbCreditCards.SuspendLayout();
            this.gbFax.SuspendLayout();
            this.gbMergedQuotes.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbOrders
            // 
            this.gbOrders.Controls.Add(this.cmdRestoreTemplates);
            this.gbOrders.Controls.Add(this.cmdConvertTemplates);
            this.gbOrders.Controls.Add(this.cmdShowOriginalTables);
            this.gbOrders.Controls.Add(this.cmdHideOriginalTables);
            this.gbOrders.Controls.Add(this.cmdDropViews);
            this.gbOrders.Controls.Add(this.cmdCreateViews);
            this.gbOrders.Controls.Add(this.cmdConvertToDistributed);
            this.gbOrders.Controls.Add(this.chkDistributedOrders);
            this.gbOrders.Location = new System.Drawing.Point(3, 3);
            this.gbOrders.Name = "gbOrders";
            this.gbOrders.Size = new System.Drawing.Size(623, 78);
            this.gbOrders.TabIndex = 0;
            this.gbOrders.TabStop = false;
            this.gbOrders.Text = "Orders";
            // 
            // cmdRestoreTemplates
            // 
            this.cmdRestoreTemplates.Location = new System.Drawing.Point(480, 49);
            this.cmdRestoreTemplates.Name = "cmdRestoreTemplates";
            this.cmdRestoreTemplates.Size = new System.Drawing.Size(135, 22);
            this.cmdRestoreTemplates.TabIndex = 7;
            this.cmdRestoreTemplates.Text = "Restore Templates";
            this.cmdRestoreTemplates.UseVisualStyleBackColor = true;
            this.cmdRestoreTemplates.Click += new System.EventHandler(this.cmdRestoreTemplates_Click);
            // 
            // cmdConvertTemplates
            // 
            this.cmdConvertTemplates.Location = new System.Drawing.Point(480, 24);
            this.cmdConvertTemplates.Name = "cmdConvertTemplates";
            this.cmdConvertTemplates.Size = new System.Drawing.Size(135, 22);
            this.cmdConvertTemplates.TabIndex = 6;
            this.cmdConvertTemplates.Text = "Convert Templates";
            this.cmdConvertTemplates.UseVisualStyleBackColor = true;
            this.cmdConvertTemplates.Click += new System.EventHandler(this.cmdConvertTemplates_Click);
            // 
            // cmdShowOriginalTables
            // 
            this.cmdShowOriginalTables.Location = new System.Drawing.Point(339, 49);
            this.cmdShowOriginalTables.Name = "cmdShowOriginalTables";
            this.cmdShowOriginalTables.Size = new System.Drawing.Size(135, 22);
            this.cmdShowOriginalTables.TabIndex = 5;
            this.cmdShowOriginalTables.Text = "Show Original";
            this.cmdShowOriginalTables.UseVisualStyleBackColor = true;
            this.cmdShowOriginalTables.Click += new System.EventHandler(this.cmdShowOriginalTables_Click);
            // 
            // cmdHideOriginalTables
            // 
            this.cmdHideOriginalTables.Location = new System.Drawing.Point(339, 24);
            this.cmdHideOriginalTables.Name = "cmdHideOriginalTables";
            this.cmdHideOriginalTables.Size = new System.Drawing.Size(135, 22);
            this.cmdHideOriginalTables.TabIndex = 4;
            this.cmdHideOriginalTables.Text = "Hide Original";
            this.cmdHideOriginalTables.UseVisualStyleBackColor = true;
            this.cmdHideOriginalTables.Click += new System.EventHandler(this.cmdHideOriginalTables_Click);
            // 
            // cmdDropViews
            // 
            this.cmdDropViews.Location = new System.Drawing.Point(198, 49);
            this.cmdDropViews.Name = "cmdDropViews";
            this.cmdDropViews.Size = new System.Drawing.Size(135, 22);
            this.cmdDropViews.TabIndex = 3;
            this.cmdDropViews.Text = "Drop Views";
            this.cmdDropViews.UseVisualStyleBackColor = true;
            this.cmdDropViews.Click += new System.EventHandler(this.cmdDropViews_Click);
            // 
            // cmdCreateViews
            // 
            this.cmdCreateViews.Location = new System.Drawing.Point(198, 24);
            this.cmdCreateViews.Name = "cmdCreateViews";
            this.cmdCreateViews.Size = new System.Drawing.Size(135, 22);
            this.cmdCreateViews.TabIndex = 2;
            this.cmdCreateViews.Text = "Create Views";
            this.cmdCreateViews.UseVisualStyleBackColor = true;
            this.cmdCreateViews.Click += new System.EventHandler(this.cmdCreateViews_Click);
            // 
            // cmdConvertToDistributed
            // 
            this.cmdConvertToDistributed.Location = new System.Drawing.Point(6, 41);
            this.cmdConvertToDistributed.Name = "cmdConvertToDistributed";
            this.cmdConvertToDistributed.Size = new System.Drawing.Size(186, 30);
            this.cmdConvertToDistributed.TabIndex = 1;
            this.cmdConvertToDistributed.Text = "Convert Order System";
            this.cmdConvertToDistributed.UseVisualStyleBackColor = true;
            this.cmdConvertToDistributed.Click += new System.EventHandler(this.cmdConvertToDistributed_Click);
            // 
            // chkDistributedOrders
            // 
            this.chkDistributedOrders.AutoSize = true;
            this.chkDistributedOrders.Location = new System.Drawing.Point(6, 18);
            this.chkDistributedOrders.Name = "chkDistributedOrders";
            this.chkDistributedOrders.Size = new System.Drawing.Size(201, 19);
            this.chkDistributedOrders.TabIndex = 0;
            this.chkDistributedOrders.Text = "Use the distributed order system";
            this.chkDistributedOrders.UseVisualStyleBackColor = true;
            this.chkDistributedOrders.CheckedChanged += new System.EventHandler(this.chkDistributedOrders_CheckedChanged);
            // 
            // gbUpdates
            // 
            this.gbUpdates.Controls.Add(this.cmdApplyUpdates);
            this.gbUpdates.Controls.Add(this.ctlUpdateFolder);
            this.gbUpdates.Controls.Add(this.chkUpdateFromNetwork);
            this.gbUpdates.Location = new System.Drawing.Point(3, 166);
            this.gbUpdates.Name = "gbUpdates";
            this.gbUpdates.Size = new System.Drawing.Size(480, 87);
            this.gbUpdates.TabIndex = 1;
            this.gbUpdates.TabStop = false;
            this.gbUpdates.Text = "Updates";
            // 
            // cmdApplyUpdates
            // 
            this.cmdApplyUpdates.Location = new System.Drawing.Point(400, 20);
            this.cmdApplyUpdates.Name = "cmdApplyUpdates";
            this.cmdApplyUpdates.Size = new System.Drawing.Size(72, 22);
            this.cmdApplyUpdates.TabIndex = 2;
            this.cmdApplyUpdates.Text = "Apply";
            this.cmdApplyUpdates.UseVisualStyleBackColor = true;
            this.cmdApplyUpdates.Click += new System.EventHandler(this.cmdApplyUpdates_Click);
            // 
            // ctlUpdateFolder
            // 
            this.ctlUpdateFolder.AllCaps = false;
            this.ctlUpdateFolder.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlUpdateFolder.Bold = false;
            this.ctlUpdateFolder.Caption = "Update Folder";
            this.ctlUpdateFolder.Changed = false;
            this.ctlUpdateFolder.IsEmail = false;
            this.ctlUpdateFolder.IsURL = false;
            this.ctlUpdateFolder.Location = new System.Drawing.Point(4, 43);
            this.ctlUpdateFolder.Name = "ctlUpdateFolder";
            this.ctlUpdateFolder.PasswordChar = '\0';
            this.ctlUpdateFolder.Size = new System.Drawing.Size(468, 42);
            this.ctlUpdateFolder.TabIndex = 1;
            this.ctlUpdateFolder.UseParentBackColor = false;
            this.ctlUpdateFolder.zz_Enabled = true;
            this.ctlUpdateFolder.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlUpdateFolder.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlUpdateFolder.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlUpdateFolder.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlUpdateFolder.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctlUpdateFolder.zz_OriginalDesign = true;
            this.ctlUpdateFolder.zz_ShowLinkButton = false;
            this.ctlUpdateFolder.zz_ShowNeedsSaveColor = true;
            this.ctlUpdateFolder.zz_Text = "";
            this.ctlUpdateFolder.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlUpdateFolder.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlUpdateFolder.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlUpdateFolder.zz_UseGlobalColor = false;
            this.ctlUpdateFolder.zz_UseGlobalFont = false;
            // 
            // chkUpdateFromNetwork
            // 
            this.chkUpdateFromNetwork.AutoSize = true;
            this.chkUpdateFromNetwork.Location = new System.Drawing.Point(6, 20);
            this.chkUpdateFromNetwork.Name = "chkUpdateFromNetwork";
            this.chkUpdateFromNetwork.Size = new System.Drawing.Size(189, 19);
            this.chkUpdateFromNetwork.TabIndex = 0;
            this.chkUpdateFromNetwork.Text = "Update from the local network";
            this.chkUpdateFromNetwork.UseVisualStyleBackColor = true;
            // 
            // gbCreditCards
            // 
            this.gbCreditCards.Controls.Add(this.ctlCC4);
            this.gbCreditCards.Controls.Add(this.ctlCC3);
            this.gbCreditCards.Controls.Add(this.ctlCC2);
            this.gbCreditCards.Controls.Add(this.ctlCC1);
            this.gbCreditCards.Controls.Add(this.cmdApplyCC);
            this.gbCreditCards.Location = new System.Drawing.Point(3, 259);
            this.gbCreditCards.Name = "gbCreditCards";
            this.gbCreditCards.Size = new System.Drawing.Size(480, 217);
            this.gbCreditCards.TabIndex = 2;
            this.gbCreditCards.TabStop = false;
            this.gbCreditCards.Text = "Credit Cards";
            // 
            // ctlCC4
            // 
            this.ctlCC4.AllCaps = false;
            this.ctlCC4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlCC4.Bold = false;
            this.ctlCC4.Caption = "Credit Card 4";
            this.ctlCC4.Changed = false;
            this.ctlCC4.IsEmail = false;
            this.ctlCC4.IsURL = false;
            this.ctlCC4.Location = new System.Drawing.Point(8, 166);
            this.ctlCC4.Name = "ctlCC4";
            this.ctlCC4.PasswordChar = '\0';
            this.ctlCC4.Size = new System.Drawing.Size(390, 43);
            this.ctlCC4.TabIndex = 7;
            this.ctlCC4.UseParentBackColor = false;
            this.ctlCC4.zz_Enabled = true;
            this.ctlCC4.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlCC4.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlCC4.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlCC4.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlCC4.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctlCC4.zz_OriginalDesign = true;
            this.ctlCC4.zz_ShowLinkButton = false;
            this.ctlCC4.zz_ShowNeedsSaveColor = true;
            this.ctlCC4.zz_Text = "";
            this.ctlCC4.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlCC4.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlCC4.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlCC4.zz_UseGlobalColor = false;
            this.ctlCC4.zz_UseGlobalFont = false;
            // 
            // ctlCC3
            // 
            this.ctlCC3.AllCaps = false;
            this.ctlCC3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlCC3.Bold = false;
            this.ctlCC3.Caption = "Credit Card 3";
            this.ctlCC3.Changed = false;
            this.ctlCC3.IsEmail = false;
            this.ctlCC3.IsURL = false;
            this.ctlCC3.Location = new System.Drawing.Point(6, 117);
            this.ctlCC3.Name = "ctlCC3";
            this.ctlCC3.PasswordChar = '\0';
            this.ctlCC3.Size = new System.Drawing.Size(390, 43);
            this.ctlCC3.TabIndex = 6;
            this.ctlCC3.UseParentBackColor = false;
            this.ctlCC3.zz_Enabled = true;
            this.ctlCC3.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlCC3.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlCC3.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlCC3.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlCC3.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctlCC3.zz_OriginalDesign = true;
            this.ctlCC3.zz_ShowLinkButton = false;
            this.ctlCC3.zz_ShowNeedsSaveColor = true;
            this.ctlCC3.zz_Text = "";
            this.ctlCC3.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlCC3.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlCC3.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlCC3.zz_UseGlobalColor = false;
            this.ctlCC3.zz_UseGlobalFont = false;
            // 
            // ctlCC2
            // 
            this.ctlCC2.AllCaps = false;
            this.ctlCC2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlCC2.Bold = false;
            this.ctlCC2.Caption = "Credit Card 2";
            this.ctlCC2.Changed = false;
            this.ctlCC2.IsEmail = false;
            this.ctlCC2.IsURL = false;
            this.ctlCC2.Location = new System.Drawing.Point(6, 68);
            this.ctlCC2.Name = "ctlCC2";
            this.ctlCC2.PasswordChar = '\0';
            this.ctlCC2.Size = new System.Drawing.Size(390, 43);
            this.ctlCC2.TabIndex = 5;
            this.ctlCC2.UseParentBackColor = false;
            this.ctlCC2.zz_Enabled = true;
            this.ctlCC2.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlCC2.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlCC2.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlCC2.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlCC2.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctlCC2.zz_OriginalDesign = true;
            this.ctlCC2.zz_ShowLinkButton = false;
            this.ctlCC2.zz_ShowNeedsSaveColor = true;
            this.ctlCC2.zz_Text = "";
            this.ctlCC2.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlCC2.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlCC2.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlCC2.zz_UseGlobalColor = false;
            this.ctlCC2.zz_UseGlobalFont = false;
            // 
            // ctlCC1
            // 
            this.ctlCC1.AllCaps = false;
            this.ctlCC1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlCC1.Bold = false;
            this.ctlCC1.Caption = "Credit Card 1";
            this.ctlCC1.Changed = false;
            this.ctlCC1.IsEmail = false;
            this.ctlCC1.IsURL = false;
            this.ctlCC1.Location = new System.Drawing.Point(6, 19);
            this.ctlCC1.Name = "ctlCC1";
            this.ctlCC1.PasswordChar = '\0';
            this.ctlCC1.Size = new System.Drawing.Size(390, 43);
            this.ctlCC1.TabIndex = 4;
            this.ctlCC1.UseParentBackColor = false;
            this.ctlCC1.zz_Enabled = true;
            this.ctlCC1.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlCC1.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlCC1.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlCC1.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlCC1.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctlCC1.zz_OriginalDesign = true;
            this.ctlCC1.zz_ShowLinkButton = false;
            this.ctlCC1.zz_ShowNeedsSaveColor = true;
            this.ctlCC1.zz_Text = "";
            this.ctlCC1.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlCC1.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlCC1.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlCC1.zz_UseGlobalColor = false;
            this.ctlCC1.zz_UseGlobalFont = false;
            // 
            // cmdApplyCC
            // 
            this.cmdApplyCC.Location = new System.Drawing.Point(402, 19);
            this.cmdApplyCC.Name = "cmdApplyCC";
            this.cmdApplyCC.Size = new System.Drawing.Size(72, 22);
            this.cmdApplyCC.TabIndex = 3;
            this.cmdApplyCC.Text = "Apply";
            this.cmdApplyCC.UseVisualStyleBackColor = true;
            this.cmdApplyCC.Click += new System.EventHandler(this.cmdApplyCC_Click);
            // 
            // gbFax
            // 
            this.gbFax.Controls.Add(this.ctlFaxPrefix);
            this.gbFax.Controls.Add(this.ctlFaxIP);
            this.gbFax.Controls.Add(this.cmdApplyFax);
            this.gbFax.Location = new System.Drawing.Point(3, 482);
            this.gbFax.Name = "gbFax";
            this.gbFax.Size = new System.Drawing.Size(482, 75);
            this.gbFax.TabIndex = 3;
            this.gbFax.TabStop = false;
            this.gbFax.Text = "Fax";
            // 
            // ctlFaxPrefix
            // 
            this.ctlFaxPrefix.AllCaps = false;
            this.ctlFaxPrefix.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlFaxPrefix.Bold = false;
            this.ctlFaxPrefix.Caption = "Fax Prefix #";
            this.ctlFaxPrefix.Changed = true;
            this.ctlFaxPrefix.IsEmail = false;
            this.ctlFaxPrefix.IsURL = false;
            this.ctlFaxPrefix.Location = new System.Drawing.Point(297, 13);
            this.ctlFaxPrefix.Name = "ctlFaxPrefix";
            this.ctlFaxPrefix.PasswordChar = '\0';
            this.ctlFaxPrefix.Size = new System.Drawing.Size(99, 22);
            this.ctlFaxPrefix.TabIndex = 7;
            this.ctlFaxPrefix.UseParentBackColor = false;
            this.ctlFaxPrefix.zz_Enabled = true;
            this.ctlFaxPrefix.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlFaxPrefix.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlFaxPrefix.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlFaxPrefix.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlFaxPrefix.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.Left;
            this.ctlFaxPrefix.zz_OriginalDesign = false;
            this.ctlFaxPrefix.zz_ShowLinkButton = false;
            this.ctlFaxPrefix.zz_ShowNeedsSaveColor = true;
            this.ctlFaxPrefix.zz_Text = "";
            this.ctlFaxPrefix.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlFaxPrefix.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlFaxPrefix.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlFaxPrefix.zz_UseGlobalColor = false;
            this.ctlFaxPrefix.zz_UseGlobalFont = false;
            // 
            // ctlFaxIP
            // 
            this.ctlFaxIP.AllCaps = false;
            this.ctlFaxIP.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlFaxIP.Bold = false;
            this.ctlFaxIP.Caption = "Fax Server Name or IP";
            this.ctlFaxIP.Changed = false;
            this.ctlFaxIP.IsEmail = false;
            this.ctlFaxIP.IsURL = false;
            this.ctlFaxIP.Location = new System.Drawing.Point(8, 19);
            this.ctlFaxIP.Name = "ctlFaxIP";
            this.ctlFaxIP.PasswordChar = '\0';
            this.ctlFaxIP.Size = new System.Drawing.Size(390, 43);
            this.ctlFaxIP.TabIndex = 6;
            this.ctlFaxIP.UseParentBackColor = false;
            this.ctlFaxIP.zz_Enabled = true;
            this.ctlFaxIP.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlFaxIP.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlFaxIP.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlFaxIP.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlFaxIP.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctlFaxIP.zz_OriginalDesign = true;
            this.ctlFaxIP.zz_ShowLinkButton = false;
            this.ctlFaxIP.zz_ShowNeedsSaveColor = true;
            this.ctlFaxIP.zz_Text = "";
            this.ctlFaxIP.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlFaxIP.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlFaxIP.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlFaxIP.zz_UseGlobalColor = false;
            this.ctlFaxIP.zz_UseGlobalFont = false;
            // 
            // cmdApplyFax
            // 
            this.cmdApplyFax.Location = new System.Drawing.Point(402, 13);
            this.cmdApplyFax.Name = "cmdApplyFax";
            this.cmdApplyFax.Size = new System.Drawing.Size(72, 49);
            this.cmdApplyFax.TabIndex = 5;
            this.cmdApplyFax.Text = "Apply";
            this.cmdApplyFax.UseVisualStyleBackColor = true;
            this.cmdApplyFax.Click += new System.EventHandler(this.cmdApplyFax_Click);
            // 
            // gbMergedQuotes
            // 
            this.gbMergedQuotes.Controls.Add(this.cmdCreateDealCompanies);
            this.gbMergedQuotes.Controls.Add(this.cmdUpdateBatchLinks);
            this.gbMergedQuotes.Controls.Add(this.cmdQuoteIDs);
            this.gbMergedQuotes.Controls.Add(this.cmdReqBatches);
            this.gbMergedQuotes.Controls.Add(this.cmdMergeReqs);
            this.gbMergedQuotes.Controls.Add(this.cmdSeparateQuotes);
            this.gbMergedQuotes.Controls.Add(this.cmdSeparateBids);
            this.gbMergedQuotes.Controls.Add(this.chkMergedQuotes);
            this.gbMergedQuotes.Location = new System.Drawing.Point(3, 87);
            this.gbMergedQuotes.Name = "gbMergedQuotes";
            this.gbMergedQuotes.Size = new System.Drawing.Size(763, 73);
            this.gbMergedQuotes.TabIndex = 4;
            this.gbMergedQuotes.TabStop = false;
            this.gbMergedQuotes.Text = "Quotes";
            // 
            // cmdCreateDealCompanies
            // 
            this.cmdCreateDealCompanies.Location = new System.Drawing.Point(622, 43);
            this.cmdCreateDealCompanies.Name = "cmdCreateDealCompanies";
            this.cmdCreateDealCompanies.Size = new System.Drawing.Size(135, 22);
            this.cmdCreateDealCompanies.TabIndex = 10;
            this.cmdCreateDealCompanies.Text = "Create Deal Companies";
            this.cmdCreateDealCompanies.UseVisualStyleBackColor = true;
            this.cmdCreateDealCompanies.Click += new System.EventHandler(this.cmdCreateDealCompanies_Click);
            // 
            // cmdUpdateBatchLinks
            // 
            this.cmdUpdateBatchLinks.Location = new System.Drawing.Point(480, 42);
            this.cmdUpdateBatchLinks.Name = "cmdUpdateBatchLinks";
            this.cmdUpdateBatchLinks.Size = new System.Drawing.Size(135, 22);
            this.cmdUpdateBatchLinks.TabIndex = 9;
            this.cmdUpdateBatchLinks.Text = "Update Batch Links";
            this.cmdUpdateBatchLinks.UseVisualStyleBackColor = true;
            this.cmdUpdateBatchLinks.Click += new System.EventHandler(this.cmdUpdateBatchLinks_Click);
            // 
            // cmdQuoteIDs
            // 
            this.cmdQuoteIDs.Location = new System.Drawing.Point(198, 14);
            this.cmdQuoteIDs.Name = "cmdQuoteIDs";
            this.cmdQuoteIDs.Size = new System.Drawing.Size(135, 22);
            this.cmdQuoteIDs.TabIndex = 8;
            this.cmdQuoteIDs.Text = "Set Quote IDs";
            this.cmdQuoteIDs.UseVisualStyleBackColor = true;
            this.cmdQuoteIDs.Click += new System.EventHandler(this.cmdQuoteIDs_Click);
            // 
            // cmdReqBatches
            // 
            this.cmdReqBatches.Location = new System.Drawing.Point(480, 14);
            this.cmdReqBatches.Name = "cmdReqBatches";
            this.cmdReqBatches.Size = new System.Drawing.Size(135, 22);
            this.cmdReqBatches.TabIndex = 7;
            this.cmdReqBatches.Text = "Convert Req Batches";
            this.cmdReqBatches.UseVisualStyleBackColor = true;
            this.cmdReqBatches.Click += new System.EventHandler(this.cmdReqBatches_Click);
            // 
            // cmdMergeReqs
            // 
            this.cmdMergeReqs.Location = new System.Drawing.Point(339, 42);
            this.cmdMergeReqs.Name = "cmdMergeReqs";
            this.cmdMergeReqs.Size = new System.Drawing.Size(135, 22);
            this.cmdMergeReqs.TabIndex = 6;
            this.cmdMergeReqs.Text = "Convert Reqs";
            this.cmdMergeReqs.UseVisualStyleBackColor = true;
            this.cmdMergeReqs.Click += new System.EventHandler(this.cmdMergeReqs_Click);
            // 
            // cmdSeparateQuotes
            // 
            this.cmdSeparateQuotes.Location = new System.Drawing.Point(339, 14);
            this.cmdSeparateQuotes.Name = "cmdSeparateQuotes";
            this.cmdSeparateQuotes.Size = new System.Drawing.Size(135, 22);
            this.cmdSeparateQuotes.TabIndex = 5;
            this.cmdSeparateQuotes.Text = "Separate Quotes";
            this.cmdSeparateQuotes.UseVisualStyleBackColor = true;
            this.cmdSeparateQuotes.Click += new System.EventHandler(this.cmdSeparateQuotes_Click);
            // 
            // cmdSeparateBids
            // 
            this.cmdSeparateBids.Location = new System.Drawing.Point(621, 15);
            this.cmdSeparateBids.Name = "cmdSeparateBids";
            this.cmdSeparateBids.Size = new System.Drawing.Size(135, 22);
            this.cmdSeparateBids.TabIndex = 4;
            this.cmdSeparateBids.Text = "Separate Bids";
            this.cmdSeparateBids.UseVisualStyleBackColor = true;
            this.cmdSeparateBids.Click += new System.EventHandler(this.cmdSeparateBids_Click);
            // 
            // chkMergedQuotes
            // 
            this.chkMergedQuotes.AutoSize = true;
            this.chkMergedQuotes.Location = new System.Drawing.Point(6, 19);
            this.chkMergedQuotes.Name = "chkMergedQuotes";
            this.chkMergedQuotes.Size = new System.Drawing.Size(195, 19);
            this.chkMergedQuotes.TabIndex = 1;
            this.chkMergedQuotes.Text = "Use the merged quotes system";
            this.chkMergedQuotes.UseVisualStyleBackColor = true;
            this.chkMergedQuotes.CheckedChanged += new System.EventHandler(this.chkMergedQuotes_CheckedChanged);
            // 
            // cmdUPSWorldship
            // 
            this.cmdUPSWorldship.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdUPSWorldship.Location = new System.Drawing.Point(489, 174);
            this.cmdUPSWorldship.Name = "cmdUPSWorldship";
            this.cmdUPSWorldship.Size = new System.Drawing.Size(277, 29);
            this.cmdUPSWorldship.TabIndex = 6;
            this.cmdUPSWorldship.Text = "UPS Worldship";
            this.cmdUPSWorldship.UseVisualStyleBackColor = true;
            this.cmdUPSWorldship.Click += new System.EventHandler(this.cmdUPSWorldship_Click);
            // 
            // cmdInsertUPSServices
            // 
            this.cmdInsertUPSServices.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdInsertUPSServices.Location = new System.Drawing.Point(489, 209);
            this.cmdInsertUPSServices.Name = "cmdInsertUPSServices";
            this.cmdInsertUPSServices.Size = new System.Drawing.Size(277, 29);
            this.cmdInsertUPSServices.TabIndex = 7;
            this.cmdInsertUPSServices.Text = "Display UPS Types";
            this.cmdInsertUPSServices.UseVisualStyleBackColor = true;
            this.cmdInsertUPSServices.Click += new System.EventHandler(this.cmdInsertUPSServices_Click);
            // 
            // chkQBsPosting
            // 
            this.chkQBsPosting.AutoSize = true;
            this.chkQBsPosting.Location = new System.Drawing.Point(489, 259);
            this.chkQBsPosting.Name = "chkQBsPosting";
            this.chkQBsPosting.Size = new System.Drawing.Size(135, 19);
            this.chkQBsPosting.TabIndex = 8;
            this.chkQBsPosting.Text = "Enable QBs Posting";
            this.chkQBsPosting.UseVisualStyleBackColor = true;
            this.chkQBsPosting.CheckedChanged += new System.EventHandler(this.chkQBsPosting_CheckedChanged);
            // 
            // SettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkQBsPosting);
            this.Controls.Add(this.cmdInsertUPSServices);
            this.Controls.Add(this.cmdUPSWorldship);
            this.Controls.Add(this.gbMergedQuotes);
            this.Controls.Add(this.gbFax);
            this.Controls.Add(this.gbCreditCards);
            this.Controls.Add(this.gbUpdates);
            this.Controls.Add(this.gbOrders);
            this.Name = "SettingsPanel";
            this.Size = new System.Drawing.Size(1111, 667);
            this.gbOrders.ResumeLayout(false);
            this.gbOrders.PerformLayout();
            this.gbUpdates.ResumeLayout(false);
            this.gbUpdates.PerformLayout();
            this.gbCreditCards.ResumeLayout(false);
            this.gbFax.ResumeLayout(false);
            this.gbMergedQuotes.ResumeLayout(false);
            this.gbMergedQuotes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbOrders;
        private System.Windows.Forms.Button cmdConvertToDistributed;
        private System.Windows.Forms.CheckBox chkDistributedOrders;
        private System.Windows.Forms.Button cmdDropViews;
        private System.Windows.Forms.Button cmdCreateViews;
        private System.Windows.Forms.Button cmdShowOriginalTables;
        private System.Windows.Forms.Button cmdHideOriginalTables;
        private System.Windows.Forms.GroupBox gbUpdates;
        private System.Windows.Forms.CheckBox chkUpdateFromNetwork;
        private System.Windows.Forms.Button cmdApplyUpdates;
        private NewMethod.nEdit_String ctlUpdateFolder;
        private System.Windows.Forms.GroupBox gbCreditCards;
        private NewMethod.nEdit_String ctlCC3;
        private NewMethod.nEdit_String ctlCC2;
        private NewMethod.nEdit_String ctlCC1;
        private System.Windows.Forms.Button cmdApplyCC;
        private System.Windows.Forms.Button cmdRestoreTemplates;
        private System.Windows.Forms.Button cmdConvertTemplates;
        private System.Windows.Forms.GroupBox gbFax;
        private NewMethod.nEdit_String ctlFaxIP;
        private System.Windows.Forms.Button cmdApplyFax;
        private System.Windows.Forms.GroupBox gbMergedQuotes;
        private System.Windows.Forms.CheckBox chkMergedQuotes;
        private System.Windows.Forms.Button cmdMergeReqs;
        private System.Windows.Forms.Button cmdSeparateQuotes;
        private System.Windows.Forms.Button cmdSeparateBids;
        private System.Windows.Forms.Button cmdReqBatches;
        private System.Windows.Forms.Button cmdQuoteIDs;
        private System.Windows.Forms.Button cmdUpdateBatchLinks;
        private System.Windows.Forms.Button cmdCreateDealCompanies;
        private System.Windows.Forms.Button cmdUPSWorldship;
        private System.Windows.Forms.Button cmdInsertUPSServices;
        private NewMethod.nEdit_String ctlFaxPrefix;
        private NewMethod.nEdit_String ctlCC4;
        private System.Windows.Forms.CheckBox chkQBsPosting;
    }
}
