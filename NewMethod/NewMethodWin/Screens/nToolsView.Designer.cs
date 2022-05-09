namespace NewMethod
{
    partial class nToolsView
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
            this.gb = new System.Windows.Forms.GroupBox();
            this.lblDataTable = new System.Windows.Forms.LinkLabel();
            this.lblSQL = new System.Windows.Forms.LinkLabel();
            this.lblSystem = new System.Windows.Forms.Label();
            this.gbDatabase = new System.Windows.Forms.GroupBox();
            this.cmdSplitFirstName = new System.Windows.Forms.Button();
            this.cmdSplitRight = new System.Windows.Forms.Button();
            this.cmdSplitLeft = new System.Windows.Forms.Button();
            this.ctlDivider = new NewMethod.nEdit_String();
            this.ctlWhere = new NewMethod.nEdit_Memo();
            this.cmdStrip = new System.Windows.Forms.Button();
            this.cmdSplitEmailSuffix = new System.Windows.Forms.Button();
            this.ctlField2 = new NewMethod.nEdit_String();
            this.ctlField1 = new NewMethod.nEdit_String();
            this.ctlTable = new NewMethod.nEdit_String();
            this.cmdSplitEmailDomain = new System.Windows.Forms.Button();
            this.ctlTable2 = new NewMethod.nEdit_String();
            this.commonFieldsButton = new System.Windows.Forms.Button();
            this.gb.SuspendLayout();
            this.gbDatabase.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb
            // 
            this.gb.Controls.Add(this.lblDataTable);
            this.gb.Controls.Add(this.lblSQL);
            this.gb.Controls.Add(this.lblSystem);
            this.gb.Location = new System.Drawing.Point(0, 0);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(175, 590);
            this.gb.TabIndex = 0;
            this.gb.TabStop = false;
            // 
            // lblDataTable
            // 
            this.lblDataTable.AutoSize = true;
            this.lblDataTable.Location = new System.Drawing.Point(73, 59);
            this.lblDataTable.Name = "lblDataTable";
            this.lblDataTable.Size = new System.Drawing.Size(54, 13);
            this.lblDataTable.TabIndex = 2;
            this.lblDataTable.TabStop = true;
            this.lblDataTable.Text = "data table";
            // 
            // lblSQL
            // 
            this.lblSQL.AutoSize = true;
            this.lblSQL.Location = new System.Drawing.Point(73, 46);
            this.lblSQL.Name = "lblSQL";
            this.lblSQL.Size = new System.Drawing.Size(20, 13);
            this.lblSQL.TabIndex = 1;
            this.lblSQL.TabStop = true;
            this.lblSQL.Text = "sql";
            // 
            // lblSystem
            // 
            this.lblSystem.AutoSize = true;
            this.lblSystem.Location = new System.Drawing.Point(6, 16);
            this.lblSystem.Name = "lblSystem";
            this.lblSystem.Size = new System.Drawing.Size(35, 13);
            this.lblSystem.TabIndex = 0;
            this.lblSystem.Text = "label1";
            // 
            // gbDatabase
            // 
            this.gbDatabase.BackColor = System.Drawing.Color.White;
            this.gbDatabase.Controls.Add(this.commonFieldsButton);
            this.gbDatabase.Controls.Add(this.ctlTable2);
            this.gbDatabase.Controls.Add(this.cmdSplitFirstName);
            this.gbDatabase.Controls.Add(this.cmdSplitRight);
            this.gbDatabase.Controls.Add(this.cmdSplitLeft);
            this.gbDatabase.Controls.Add(this.ctlDivider);
            this.gbDatabase.Controls.Add(this.ctlWhere);
            this.gbDatabase.Controls.Add(this.cmdStrip);
            this.gbDatabase.Controls.Add(this.cmdSplitEmailSuffix);
            this.gbDatabase.Controls.Add(this.ctlField2);
            this.gbDatabase.Controls.Add(this.ctlField1);
            this.gbDatabase.Controls.Add(this.ctlTable);
            this.gbDatabase.Controls.Add(this.cmdSplitEmailDomain);
            this.gbDatabase.Location = new System.Drawing.Point(182, 8);
            this.gbDatabase.Name = "gbDatabase";
            this.gbDatabase.Size = new System.Drawing.Size(737, 511);
            this.gbDatabase.TabIndex = 1;
            this.gbDatabase.TabStop = false;
            this.gbDatabase.Text = "Database";
            // 
            // cmdSplitFirstName
            // 
            this.cmdSplitFirstName.Location = new System.Drawing.Point(14, 251);
            this.cmdSplitFirstName.Name = "cmdSplitFirstName";
            this.cmdSplitFirstName.Size = new System.Drawing.Size(286, 38);
            this.cmdSplitFirstName.TabIndex = 10;
            this.cmdSplitFirstName.Text = "Split First Name into Field 2";
            this.cmdSplitFirstName.UseVisualStyleBackColor = true;
            this.cmdSplitFirstName.Click += new System.EventHandler(this.cmdSplitFirstName_Click);
            // 
            // cmdSplitRight
            // 
            this.cmdSplitRight.Location = new System.Drawing.Point(160, 341);
            this.cmdSplitRight.Name = "cmdSplitRight";
            this.cmdSplitRight.Size = new System.Drawing.Size(140, 38);
            this.cmdSplitRight.TabIndex = 9;
            this.cmdSplitRight.Text = "Split Right Into";
            this.cmdSplitRight.UseVisualStyleBackColor = true;
            this.cmdSplitRight.Click += new System.EventHandler(this.cmdSplitRight_Click);
            // 
            // cmdSplitLeft
            // 
            this.cmdSplitLeft.Location = new System.Drawing.Point(14, 341);
            this.cmdSplitLeft.Name = "cmdSplitLeft";
            this.cmdSplitLeft.Size = new System.Drawing.Size(140, 38);
            this.cmdSplitLeft.TabIndex = 8;
            this.cmdSplitLeft.Text = "Split Left Into";
            this.cmdSplitLeft.UseVisualStyleBackColor = true;
            this.cmdSplitLeft.Click += new System.EventHandler(this.cmdSplitLeft_Click);
            // 
            // ctlDivider
            // 
            this.ctlDivider.AllCaps = false;
            this.ctlDivider.BackColor = System.Drawing.Color.White;
            this.ctlDivider.Bold = false;
            this.ctlDivider.Caption = "Divider";
            this.ctlDivider.Changed = false;
            this.ctlDivider.IsEmail = false;
            this.ctlDivider.IsURL = false;
            this.ctlDivider.Location = new System.Drawing.Point(14, 294);
            this.ctlDivider.Name = "ctlDivider";
            this.ctlDivider.PasswordChar = '\0';
            this.ctlDivider.Size = new System.Drawing.Size(269, 41);
            this.ctlDivider.TabIndex = 7;
            this.ctlDivider.UseParentBackColor = true;
            this.ctlDivider.zz_Enabled = true;
            this.ctlDivider.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlDivider.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlDivider.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlDivider.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlDivider.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctlDivider.zz_OriginalDesign = true;
            this.ctlDivider.zz_ShowLinkButton = false;
            this.ctlDivider.zz_ShowNeedsSaveColor = true;
            this.ctlDivider.zz_Text = "";
            this.ctlDivider.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlDivider.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlDivider.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlDivider.zz_UseGlobalColor = false;
            this.ctlDivider.zz_UseGlobalFont = false;
            // 
            // ctlWhere
            // 
            this.ctlWhere.BackColor = System.Drawing.Color.White;
            this.ctlWhere.Bold = false;
            this.ctlWhere.Caption = "Where";
            this.ctlWhere.Changed = false;
            this.ctlWhere.DateLines = false;
            this.ctlWhere.Location = new System.Drawing.Point(308, 19);
            this.ctlWhere.Name = "ctlWhere";
            this.ctlWhere.Size = new System.Drawing.Size(398, 225);
            this.ctlWhere.TabIndex = 6;
            this.ctlWhere.UseParentBackColor = true;
            this.ctlWhere.zz_Enabled = true;
            this.ctlWhere.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlWhere.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlWhere.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlWhere.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlWhere.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctlWhere.zz_OriginalDesign = false;
            this.ctlWhere.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctlWhere.zz_ShowNeedsSaveColor = true;
            this.ctlWhere.zz_Text = "";
            this.ctlWhere.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlWhere.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlWhere.zz_UseGlobalColor = false;
            this.ctlWhere.zz_UseGlobalFont = false;
            // 
            // cmdStrip
            // 
            this.cmdStrip.Location = new System.Drawing.Point(14, 207);
            this.cmdStrip.Name = "cmdStrip";
            this.cmdStrip.Size = new System.Drawing.Size(286, 38);
            this.cmdStrip.TabIndex = 5;
            this.cmdStrip.Text = "Strip Field1 into Field2";
            this.cmdStrip.UseVisualStyleBackColor = true;
            this.cmdStrip.Click += new System.EventHandler(this.cmdStrip_Click);
            // 
            // cmdSplitEmailSuffix
            // 
            this.cmdSplitEmailSuffix.Location = new System.Drawing.Point(160, 163);
            this.cmdSplitEmailSuffix.Name = "cmdSplitEmailSuffix";
            this.cmdSplitEmailSuffix.Size = new System.Drawing.Size(140, 38);
            this.cmdSplitEmailSuffix.TabIndex = 4;
            this.cmdSplitEmailSuffix.Text = "Split Email Suffix";
            this.cmdSplitEmailSuffix.UseVisualStyleBackColor = true;
            this.cmdSplitEmailSuffix.Click += new System.EventHandler(this.cmdSplitEmailSuffix_Click);
            // 
            // ctlField2
            // 
            this.ctlField2.AllCaps = false;
            this.ctlField2.BackColor = System.Drawing.Color.White;
            this.ctlField2.Bold = false;
            this.ctlField2.Caption = "Field 2";
            this.ctlField2.Changed = false;
            this.ctlField2.IsEmail = false;
            this.ctlField2.IsURL = false;
            this.ctlField2.Location = new System.Drawing.Point(14, 116);
            this.ctlField2.Name = "ctlField2";
            this.ctlField2.PasswordChar = '\0';
            this.ctlField2.Size = new System.Drawing.Size(269, 41);
            this.ctlField2.TabIndex = 3;
            this.ctlField2.UseParentBackColor = true;
            this.ctlField2.zz_Enabled = true;
            this.ctlField2.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlField2.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlField2.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlField2.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlField2.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctlField2.zz_OriginalDesign = true;
            this.ctlField2.zz_ShowLinkButton = false;
            this.ctlField2.zz_ShowNeedsSaveColor = true;
            this.ctlField2.zz_Text = "";
            this.ctlField2.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlField2.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlField2.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlField2.zz_UseGlobalColor = false;
            this.ctlField2.zz_UseGlobalFont = false;
            // 
            // ctlField1
            // 
            this.ctlField1.AllCaps = false;
            this.ctlField1.BackColor = System.Drawing.Color.White;
            this.ctlField1.Bold = false;
            this.ctlField1.Caption = "Field 1";
            this.ctlField1.Changed = false;
            this.ctlField1.IsEmail = false;
            this.ctlField1.IsURL = false;
            this.ctlField1.Location = new System.Drawing.Point(14, 69);
            this.ctlField1.Name = "ctlField1";
            this.ctlField1.PasswordChar = '\0';
            this.ctlField1.Size = new System.Drawing.Size(269, 41);
            this.ctlField1.TabIndex = 2;
            this.ctlField1.UseParentBackColor = true;
            this.ctlField1.zz_Enabled = true;
            this.ctlField1.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlField1.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlField1.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlField1.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlField1.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctlField1.zz_OriginalDesign = true;
            this.ctlField1.zz_ShowLinkButton = false;
            this.ctlField1.zz_ShowNeedsSaveColor = true;
            this.ctlField1.zz_Text = "";
            this.ctlField1.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlField1.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlField1.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlField1.zz_UseGlobalColor = false;
            this.ctlField1.zz_UseGlobalFont = false;
            // 
            // ctlTable
            // 
            this.ctlTable.AllCaps = false;
            this.ctlTable.BackColor = System.Drawing.Color.White;
            this.ctlTable.Bold = false;
            this.ctlTable.Caption = "Table";
            this.ctlTable.Changed = false;
            this.ctlTable.IsEmail = false;
            this.ctlTable.IsURL = false;
            this.ctlTable.Location = new System.Drawing.Point(13, 22);
            this.ctlTable.Name = "ctlTable";
            this.ctlTable.PasswordChar = '\0';
            this.ctlTable.Size = new System.Drawing.Size(269, 41);
            this.ctlTable.TabIndex = 1;
            this.ctlTable.UseParentBackColor = true;
            this.ctlTable.zz_Enabled = true;
            this.ctlTable.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlTable.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlTable.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlTable.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlTable.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctlTable.zz_OriginalDesign = true;
            this.ctlTable.zz_ShowLinkButton = false;
            this.ctlTable.zz_ShowNeedsSaveColor = true;
            this.ctlTable.zz_Text = "";
            this.ctlTable.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlTable.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlTable.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlTable.zz_UseGlobalColor = false;
            this.ctlTable.zz_UseGlobalFont = false;
            // 
            // cmdSplitEmailDomain
            // 
            this.cmdSplitEmailDomain.Location = new System.Drawing.Point(14, 163);
            this.cmdSplitEmailDomain.Name = "cmdSplitEmailDomain";
            this.cmdSplitEmailDomain.Size = new System.Drawing.Size(140, 38);
            this.cmdSplitEmailDomain.TabIndex = 0;
            this.cmdSplitEmailDomain.Text = "Split Email Domain";
            this.cmdSplitEmailDomain.UseVisualStyleBackColor = true;
            this.cmdSplitEmailDomain.Click += new System.EventHandler(this.cmdSplitEmailDomain_Click);
            // 
            // ctlTable2
            // 
            this.ctlTable2.AllCaps = false;
            this.ctlTable2.BackColor = System.Drawing.Color.White;
            this.ctlTable2.Bold = false;
            this.ctlTable2.Caption = "Table 2";
            this.ctlTable2.Changed = false;
            this.ctlTable2.IsEmail = false;
            this.ctlTable2.IsURL = false;
            this.ctlTable2.Location = new System.Drawing.Point(13, 385);
            this.ctlTable2.Name = "ctlTable2";
            this.ctlTable2.PasswordChar = '\0';
            this.ctlTable2.Size = new System.Drawing.Size(269, 41);
            this.ctlTable2.TabIndex = 11;
            this.ctlTable2.UseParentBackColor = true;
            this.ctlTable2.zz_Enabled = true;
            this.ctlTable2.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlTable2.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlTable2.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlTable2.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlTable2.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctlTable2.zz_OriginalDesign = true;
            this.ctlTable2.zz_ShowLinkButton = false;
            this.ctlTable2.zz_ShowNeedsSaveColor = true;
            this.ctlTable2.zz_Text = "";
            this.ctlTable2.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlTable2.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlTable2.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlTable2.zz_UseGlobalColor = false;
            this.ctlTable2.zz_UseGlobalFont = false;
            // 
            // commonFieldsButton
            // 
            this.commonFieldsButton.Location = new System.Drawing.Point(13, 432);
            this.commonFieldsButton.Name = "commonFieldsButton";
            this.commonFieldsButton.Size = new System.Drawing.Size(140, 38);
            this.commonFieldsButton.TabIndex = 12;
            this.commonFieldsButton.Text = "Common Fields";
            this.commonFieldsButton.UseVisualStyleBackColor = true;
            this.commonFieldsButton.Click += new System.EventHandler(this.commonFieldsButton_Click);
            // 
            // nToolsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbDatabase);
            this.Controls.Add(this.gb);
            this.Name = "nToolsView";
            this.Size = new System.Drawing.Size(1007, 609);
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.gbDatabase.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.LinkLabel lblDataTable;
        private System.Windows.Forms.LinkLabel lblSQL;
        private System.Windows.Forms.Label lblSystem;
        private System.Windows.Forms.GroupBox gbDatabase;
        private System.Windows.Forms.Button cmdSplitEmailDomain;
        private nEdit_String ctlField2;
        private nEdit_String ctlField1;
        private nEdit_String ctlTable;
        private System.Windows.Forms.Button cmdSplitEmailSuffix;
        private System.Windows.Forms.Button cmdStrip;
        private nEdit_Memo ctlWhere;
        private System.Windows.Forms.Button cmdSplitLeft;
        private nEdit_String ctlDivider;
        private System.Windows.Forms.Button cmdSplitRight;
        private System.Windows.Forms.Button cmdSplitFirstName;
        private System.Windows.Forms.Button commonFieldsButton;
        private nEdit_String ctlTable2;
    }
}
