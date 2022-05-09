namespace RzInterfaceWin.Views
{
    partial class Account
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
            this.ctl_name = new NewMethod.nEdit_String();
            this.label1 = new System.Windows.Forms.Label();
            this.typeList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.changeSetLabel = new System.Windows.Forms.LinkLabel();
            this.parentLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.subAccountList = new NewMethod.nList();
            this.ctl_number = new NewMethod.nEdit_Number();
            this.builtInLabel = new System.Windows.Forms.Label();
            this.ctl_description = new NewMethod.nEdit_String();
            this.pExtra_Bank = new System.Windows.Forms.Panel();
            this.bankStartingBalance = new System.Windows.Forms.Button();
            this.routingNumber = new NewMethod.nEdit_String();
            this.bankAccountNumber = new NewMethod.nEdit_String();
            this.lnkEditNumber = new System.Windows.Forms.LinkLabel();
            this.pExtra_CC = new System.Windows.Forms.Panel();
            this.ccStartingBalance = new System.Windows.Forms.Button();
            this.ccNumber = new NewMethod.nEdit_String();
            this.groupBox1.SuspendLayout();
            this.pExtra_Bank.SuspendLayout();
            this.pExtra_CC.SuspendLayout();
            this.SuspendLayout();
            // 
            // xActions
            // 
            this.xActions.Location = new System.Drawing.Point(1294, 0);
            this.xActions.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.xActions.Size = new System.Drawing.Size(195, 710);
            // 
            // ctl_name
            // 
            this.ctl_name.AllCaps = false;
            this.ctl_name.BackColor = System.Drawing.Color.White;
            this.ctl_name.Bold = false;
            this.ctl_name.Caption = "Name";
            this.ctl_name.Changed = false;
            this.ctl_name.IsEmail = false;
            this.ctl_name.IsURL = false;
            this.ctl_name.Location = new System.Drawing.Point(13, 11);
            this.ctl_name.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_name.Name = "ctl_name";
            this.ctl_name.PasswordChar = '\0';
            this.ctl_name.Size = new System.Drawing.Size(359, 58);
            this.ctl_name.TabIndex = 9;
            this.ctl_name.UseParentBackColor = true;
            this.ctl_name.zz_Enabled = true;
            this.ctl_name.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_name.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_name.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_name.zz_LabelFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_name.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_name.zz_OriginalDesign = false;
            this.ctl_name.zz_ShowLinkButton = false;
            this.ctl_name.zz_ShowNeedsSaveColor = true;
            this.ctl_name.zz_Text = "";
            this.ctl_name.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_name.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_name.zz_TextFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_name.zz_UseGlobalColor = false;
            this.ctl_name.zz_UseGlobalFont = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 78);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "Type";
            // 
            // typeList
            // 
            this.typeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeList.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeList.FormattingEnabled = true;
            this.typeList.Items.AddRange(new object[] {
            "Bank",
            "Accounts Receivable",
            "Other Current Assets",
            "Fixed Assets",
            "Other Assets",
            "Accounts Payable",
            "Credit Card",
            "Other Current Liabilities",
            "Long Term Liabilities",
            "Equity",
            "Cost Of Goods Sold",
            "Income",
            "Expense"});
            this.typeList.Location = new System.Drawing.Point(13, 105);
            this.typeList.Margin = new System.Windows.Forms.Padding(4);
            this.typeList.Name = "typeList";
            this.typeList.Size = new System.Drawing.Size(357, 32);
            this.typeList.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(380, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "Category";
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryLabel.Location = new System.Drawing.Point(380, 110);
            this.categoryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(101, 29);
            this.categoryLabel.TabIndex = 13;
            this.categoryLabel.Text = "Category";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.changeSetLabel);
            this.groupBox1.Controls.Add(this.parentLabel);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, 158);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(580, 89);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parent Account";
            // 
            // changeSetLabel
            // 
            this.changeSetLabel.AutoSize = true;
            this.changeSetLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeSetLabel.Location = new System.Drawing.Point(39, 57);
            this.changeSetLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.changeSetLabel.Name = "changeSetLabel";
            this.changeSetLabel.Size = new System.Drawing.Size(59, 21);
            this.changeSetLabel.TabIndex = 15;
            this.changeSetLabel.TabStop = true;
            this.changeSetLabel.Text = "change";
            this.changeSetLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.changeSetLabel_LinkClicked);
            // 
            // parentLabel
            // 
            this.parentLabel.AutoSize = true;
            this.parentLabel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parentLabel.Location = new System.Drawing.Point(37, 28);
            this.parentLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.parentLabel.Name = "parentLabel";
            this.parentLabel.Size = new System.Drawing.Size(227, 29);
            this.parentLabel.TabIndex = 14;
            this.parentLabel.Text = "Parent Account Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 319);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 24);
            this.label3.TabIndex = 15;
            this.label3.Text = "Sub-Accounts";
            // 
            // subAccountList
            // 
            this.subAccountList.AddCaption = "Add New";
            this.subAccountList.AllowActions = true;
            this.subAccountList.AllowAdd = true;
            this.subAccountList.AllowDelete = true;
            this.subAccountList.AllowDeleteAlways = false;
            this.subAccountList.AllowDrop = true;
            this.subAccountList.AllowOnlyOpenDelete = false;
            this.subAccountList.AlternateConnection = null;
            this.subAccountList.BackColor = System.Drawing.Color.White;
            this.subAccountList.Caption = "";
            this.subAccountList.CurrentTemplate = null;
            this.subAccountList.ExtraClassInfo = "";
            this.subAccountList.Location = new System.Drawing.Point(11, 346);
            this.subAccountList.Margin = new System.Windows.Forms.Padding(5);
            this.subAccountList.MultiSelect = true;
            this.subAccountList.Name = "subAccountList";
            this.subAccountList.Size = new System.Drawing.Size(573, 346);
            this.subAccountList.SuppressSelectionChanged = false;
            this.subAccountList.TabIndex = 16;
            this.subAccountList.zz_OpenColumnMenu = false;
            this.subAccountList.zz_OrderLineType = "";
            this.subAccountList.zz_ShowAutoRefresh = true;
            this.subAccountList.zz_ShowUnlimited = true;
            this.subAccountList.AboutToAdd += new NewMethod.AddHandler(this.subAccountList_AboutToAdd);
            // 
            // ctl_number
            // 
            this.ctl_number.BackColor = System.Drawing.Color.White;
            this.ctl_number.Bold = false;
            this.ctl_number.Caption = "Number";
            this.ctl_number.Changed = false;
            this.ctl_number.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_number.Location = new System.Drawing.Point(380, 11);
            this.ctl_number.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_number.Name = "ctl_number";
            this.ctl_number.Size = new System.Drawing.Size(204, 58);
            this.ctl_number.TabIndex = 17;
            this.ctl_number.UseParentBackColor = true;
            this.ctl_number.zz_Enabled = false;
            this.ctl_number.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_number.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_number.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_number.zz_LabelFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_number.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_number.zz_OriginalDesign = false;
            this.ctl_number.zz_ShowErrorColor = true;
            this.ctl_number.zz_ShowNeedsSaveColor = true;
            this.ctl_number.zz_Text = "";
            this.ctl_number.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_number.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_number.zz_TextFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_number.zz_UseGlobalColor = false;
            this.ctl_number.zz_UseGlobalFont = false;
            // 
            // builtInLabel
            // 
            this.builtInLabel.AutoSize = true;
            this.builtInLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.builtInLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.builtInLabel.Location = new System.Drawing.Point(151, 11);
            this.builtInLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.builtInLabel.Name = "builtInLabel";
            this.builtInLabel.Size = new System.Drawing.Size(120, 21);
            this.builtInLabel.TabIndex = 18;
            this.builtInLabel.Text = "Built-In Account";
            // 
            // ctl_description
            // 
            this.ctl_description.AllCaps = false;
            this.ctl_description.BackColor = System.Drawing.Color.White;
            this.ctl_description.Bold = false;
            this.ctl_description.Caption = "Description";
            this.ctl_description.Changed = false;
            this.ctl_description.IsEmail = false;
            this.ctl_description.IsURL = false;
            this.ctl_description.Location = new System.Drawing.Point(4, 256);
            this.ctl_description.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_description.Name = "ctl_description";
            this.ctl_description.PasswordChar = '\0';
            this.ctl_description.Size = new System.Drawing.Size(580, 58);
            this.ctl_description.TabIndex = 19;
            this.ctl_description.UseParentBackColor = true;
            this.ctl_description.zz_Enabled = true;
            this.ctl_description.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_description.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_description.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_description.zz_LabelFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_description.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_description.zz_OriginalDesign = false;
            this.ctl_description.zz_ShowLinkButton = false;
            this.ctl_description.zz_ShowNeedsSaveColor = true;
            this.ctl_description.zz_Text = "";
            this.ctl_description.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_description.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_description.zz_TextFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_description.zz_UseGlobalColor = false;
            this.ctl_description.zz_UseGlobalFont = false;
            // 
            // pExtra_Bank
            // 
            this.pExtra_Bank.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.pExtra_Bank.BackColor = System.Drawing.Color.White;
            this.pExtra_Bank.Controls.Add(this.bankStartingBalance);
            this.pExtra_Bank.Controls.Add(this.routingNumber);
            this.pExtra_Bank.Controls.Add(this.bankAccountNumber);
            this.pExtra_Bank.Location = new System.Drawing.Point(597, 0);
            this.pExtra_Bank.Margin = new System.Windows.Forms.Padding(4);
            this.pExtra_Bank.Name = "pExtra_Bank";
            this.pExtra_Bank.Size = new System.Drawing.Size(449, 201);
            this.pExtra_Bank.TabIndex = 20;
            // 
            // bankStartingBalance
            // 
            this.bankStartingBalance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bankStartingBalance.Location = new System.Drawing.Point(79, 145);
            this.bankStartingBalance.Margin = new System.Windows.Forms.Padding(4);
            this.bankStartingBalance.Name = "bankStartingBalance";
            this.bankStartingBalance.Size = new System.Drawing.Size(277, 44);
            this.bankStartingBalance.TabIndex = 12;
            this.bankStartingBalance.Text = "Set Starting Balance";
            this.bankStartingBalance.UseVisualStyleBackColor = true;
            this.bankStartingBalance.Click += new System.EventHandler(this.bankStartingBalance_Click);
            // 
            // routingNumber
            // 
            this.routingNumber.AllCaps = false;
            this.routingNumber.BackColor = System.Drawing.Color.White;
            this.routingNumber.Bold = false;
            this.routingNumber.Caption = "Routing #";
            this.routingNumber.Changed = false;
            this.routingNumber.IsEmail = false;
            this.routingNumber.IsURL = false;
            this.routingNumber.Location = new System.Drawing.Point(9, 79);
            this.routingNumber.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.routingNumber.Name = "routingNumber";
            this.routingNumber.PasswordChar = '\0';
            this.routingNumber.Size = new System.Drawing.Size(408, 58);
            this.routingNumber.TabIndex = 11;
            this.routingNumber.UseParentBackColor = true;
            this.routingNumber.zz_Enabled = true;
            this.routingNumber.zz_GlobalColor = System.Drawing.Color.Black;
            this.routingNumber.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.routingNumber.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.routingNumber.zz_LabelFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.routingNumber.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.routingNumber.zz_OriginalDesign = false;
            this.routingNumber.zz_ShowLinkButton = false;
            this.routingNumber.zz_ShowNeedsSaveColor = true;
            this.routingNumber.zz_Text = "";
            this.routingNumber.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.routingNumber.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.routingNumber.zz_TextFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.routingNumber.zz_UseGlobalColor = false;
            this.routingNumber.zz_UseGlobalFont = false;
            // 
            // bankAccountNumber
            // 
            this.bankAccountNumber.AllCaps = false;
            this.bankAccountNumber.BackColor = System.Drawing.Color.White;
            this.bankAccountNumber.Bold = false;
            this.bankAccountNumber.Caption = "Bank Account #";
            this.bankAccountNumber.Changed = false;
            this.bankAccountNumber.IsEmail = false;
            this.bankAccountNumber.IsURL = false;
            this.bankAccountNumber.Location = new System.Drawing.Point(9, 11);
            this.bankAccountNumber.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.bankAccountNumber.Name = "bankAccountNumber";
            this.bankAccountNumber.PasswordChar = '\0';
            this.bankAccountNumber.Size = new System.Drawing.Size(408, 58);
            this.bankAccountNumber.TabIndex = 10;
            this.bankAccountNumber.UseParentBackColor = true;
            this.bankAccountNumber.zz_Enabled = true;
            this.bankAccountNumber.zz_GlobalColor = System.Drawing.Color.Black;
            this.bankAccountNumber.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bankAccountNumber.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.bankAccountNumber.zz_LabelFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bankAccountNumber.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.bankAccountNumber.zz_OriginalDesign = false;
            this.bankAccountNumber.zz_ShowLinkButton = false;
            this.bankAccountNumber.zz_ShowNeedsSaveColor = true;
            this.bankAccountNumber.zz_Text = "";
            this.bankAccountNumber.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bankAccountNumber.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.bankAccountNumber.zz_TextFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bankAccountNumber.zz_UseGlobalColor = false;
            this.bankAccountNumber.zz_UseGlobalFont = false;
            // 
            // lnkEditNumber
            // 
            this.lnkEditNumber.AutoSize = true;
            this.lnkEditNumber.Location = new System.Drawing.Point(537, 15);
            this.lnkEditNumber.Name = "lnkEditNumber";
            this.lnkEditNumber.Size = new System.Drawing.Size(47, 17);
            this.lnkEditNumber.TabIndex = 21;
            this.lnkEditNumber.TabStop = true;
            this.lnkEditNumber.Text = "<edit>";
            this.lnkEditNumber.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEditNumber_LinkClicked);
            // 
            // pExtra_CC
            // 
            this.pExtra_CC.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.pExtra_CC.BackColor = System.Drawing.Color.White;
            this.pExtra_CC.Controls.Add(this.ccStartingBalance);
            this.pExtra_CC.Controls.Add(this.ccNumber);
            this.pExtra_CC.Location = new System.Drawing.Point(597, 0);
            this.pExtra_CC.Margin = new System.Windows.Forms.Padding(4);
            this.pExtra_CC.Name = "pExtra_CC";
            this.pExtra_CC.Size = new System.Drawing.Size(449, 134);
            this.pExtra_CC.TabIndex = 21;
            // 
            // ccStartingBalance
            // 
            this.ccStartingBalance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ccStartingBalance.Location = new System.Drawing.Point(79, 79);
            this.ccStartingBalance.Margin = new System.Windows.Forms.Padding(4);
            this.ccStartingBalance.Name = "ccStartingBalance";
            this.ccStartingBalance.Size = new System.Drawing.Size(277, 44);
            this.ccStartingBalance.TabIndex = 12;
            this.ccStartingBalance.Text = "Set Starting Balance";
            this.ccStartingBalance.UseVisualStyleBackColor = true;
            this.ccStartingBalance.Click += new System.EventHandler(this.ccStartingBalance_Click);
            // 
            // ccNumber
            // 
            this.ccNumber.AllCaps = false;
            this.ccNumber.BackColor = System.Drawing.Color.White;
            this.ccNumber.Bold = false;
            this.ccNumber.Caption = "Credit Card #";
            this.ccNumber.Changed = false;
            this.ccNumber.IsEmail = false;
            this.ccNumber.IsURL = false;
            this.ccNumber.Location = new System.Drawing.Point(9, 11);
            this.ccNumber.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ccNumber.Name = "ccNumber";
            this.ccNumber.PasswordChar = '\0';
            this.ccNumber.Size = new System.Drawing.Size(408, 58);
            this.ccNumber.TabIndex = 10;
            this.ccNumber.UseParentBackColor = true;
            this.ccNumber.zz_Enabled = true;
            this.ccNumber.zz_GlobalColor = System.Drawing.Color.Black;
            this.ccNumber.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ccNumber.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ccNumber.zz_LabelFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ccNumber.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ccNumber.zz_OriginalDesign = false;
            this.ccNumber.zz_ShowLinkButton = false;
            this.ccNumber.zz_ShowNeedsSaveColor = true;
            this.ccNumber.zz_Text = "";
            this.ccNumber.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ccNumber.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ccNumber.zz_TextFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ccNumber.zz_UseGlobalColor = false;
            this.ccNumber.zz_UseGlobalFont = false;
            // 
            // Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pExtra_CC);
            this.Controls.Add(this.lnkEditNumber);
            this.Controls.Add(this.pExtra_Bank);
            this.Controls.Add(this.ctl_description);
            this.Controls.Add(this.builtInLabel);
            this.Controls.Add(this.ctl_number);
            this.Controls.Add(this.subAccountList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.typeList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctl_name);
            this.Margin = new System.Windows.Forms.Padding(12, 9, 12, 9);
            this.Name = "Account";
            this.Size = new System.Drawing.Size(1489, 710);
            this.Controls.SetChildIndex(this.ctl_name, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.typeList, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.categoryLabel, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.subAccountList, 0);
            this.Controls.SetChildIndex(this.ctl_number, 0);
            this.Controls.SetChildIndex(this.builtInLabel, 0);
            this.Controls.SetChildIndex(this.ctl_description, 0);
            this.Controls.SetChildIndex(this.pExtra_Bank, 0);
            this.Controls.SetChildIndex(this.xActions, 0);
            this.Controls.SetChildIndex(this.lnkEditNumber, 0);
            this.Controls.SetChildIndex(this.pExtra_CC, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pExtra_Bank.ResumeLayout(false);
            this.pExtra_CC.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NewMethod.nEdit_String ctl_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox typeList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel changeSetLabel;
        private System.Windows.Forms.Label parentLabel;
        private System.Windows.Forms.Label label3;
        private NewMethod.nList subAccountList;
        private NewMethod.nEdit_Number ctl_number;
        private System.Windows.Forms.Label builtInLabel;
        private NewMethod.nEdit_String ctl_description;
        private System.Windows.Forms.Panel pExtra_Bank;
        private System.Windows.Forms.Button bankStartingBalance;
        private NewMethod.nEdit_String routingNumber;
        private NewMethod.nEdit_String bankAccountNumber;
        private System.Windows.Forms.LinkLabel lnkEditNumber;
        private System.Windows.Forms.Panel pExtra_CC;
        private System.Windows.Forms.Button ccStartingBalance;
        private NewMethod.nEdit_String ccNumber;
    }
}
