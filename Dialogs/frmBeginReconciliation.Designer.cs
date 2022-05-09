namespace RzInterfaceWin
{
    partial class frmBeginReconciliation
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBeginReconciliation));
            this.ctlAccount = new NewMethod.nEdit_List();
            this.ctlDate = new NewMethod.nEdit_Date();
            this.ctlEndBalance = new NewMethod.nEdit_Money();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBeginAmount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ctlServiceCharge = new NewMethod.nEdit_Money();
            this.ctlInterestEarned = new NewMethod.nEdit_Money();
            this.ctlServiceDate = new NewMethod.nEdit_Date();
            this.ctlInterestDate = new NewMethod.nEdit_Date();
            this.ctlServiceAccount = new NewMethod.nEdit_List();
            this.ctlInterestAccount = new NewMethod.nEdit_List();
            this.cmdContinue = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdClear = new System.Windows.Forms.Button();
            this.lblLastReconciled = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctlAccount
            // 
            this.ctlAccount.AllCaps = false;
            this.ctlAccount.AllowEdit = false;
            this.ctlAccount.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlAccount.Bold = false;
            this.ctlAccount.Caption = "Account";
            this.ctlAccount.Changed = false;
            this.ctlAccount.ListName = null;
            this.ctlAccount.Location = new System.Drawing.Point(15, 31);
            this.ctlAccount.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ctlAccount.Name = "ctlAccount";
            this.ctlAccount.SimpleList = null;
            this.ctlAccount.Size = new System.Drawing.Size(202, 43);
            this.ctlAccount.TabIndex = 0;
            this.ctlAccount.UseParentBackColor = false;
            this.ctlAccount.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctlAccount.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlAccount.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlAccount.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlAccount.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlAccount.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctlAccount.zz_OriginalDesign = false;
            this.ctlAccount.zz_ShowNeedsSaveColor = false;
            this.ctlAccount.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlAccount.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlAccount.zz_UseGlobalColor = false;
            this.ctlAccount.zz_UseGlobalFont = false;
            this.ctlAccount.DataChanged += new NewMethod.ChangeHandler(this.ctlAccount_DataChanged);
            // 
            // ctlDate
            // 
            this.ctlDate.AllowClear = false;
            this.ctlDate.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlDate.Bold = false;
            this.ctlDate.Caption = "Statement Date";
            this.ctlDate.Changed = false;
            this.ctlDate.Location = new System.Drawing.Point(227, 33);
            this.ctlDate.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ctlDate.Name = "ctlDate";
            this.ctlDate.Size = new System.Drawing.Size(155, 41);
            this.ctlDate.SuppressEdit = false;
            this.ctlDate.TabIndex = 1;
            this.ctlDate.UseParentBackColor = false;
            this.ctlDate.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlDate.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlDate.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlDate.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlDate.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctlDate.zz_OriginalDesign = false;
            this.ctlDate.zz_ShowNeedsSaveColor = false;
            this.ctlDate.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlDate.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlDate.zz_UseGlobalColor = false;
            this.ctlDate.zz_UseGlobalFont = false;
            // 
            // ctlEndBalance
            // 
            this.ctlEndBalance.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlEndBalance.Bold = false;
            this.ctlEndBalance.Caption = "Ending Balance";
            this.ctlEndBalance.Changed = false;
            this.ctlEndBalance.EditCaption = false;
            this.ctlEndBalance.FullDecimal = false;
            this.ctlEndBalance.Location = new System.Drawing.Point(540, 31);
            this.ctlEndBalance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctlEndBalance.Name = "ctlEndBalance";
            this.ctlEndBalance.RoundNearestCent = false;
            this.ctlEndBalance.Size = new System.Drawing.Size(163, 41);
            this.ctlEndBalance.TabIndex = 2;
            this.ctlEndBalance.UseParentBackColor = false;
            this.ctlEndBalance.zz_Enabled = true;
            this.ctlEndBalance.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlEndBalance.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlEndBalance.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlEndBalance.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlEndBalance.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctlEndBalance.zz_OriginalDesign = false;
            this.ctlEndBalance.zz_ShowErrorColor = true;
            this.ctlEndBalance.zz_ShowNeedsSaveColor = false;
            this.ctlEndBalance.zz_Text = "";
            this.ctlEndBalance.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctlEndBalance.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlEndBalance.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlEndBalance.zz_UseGlobalColor = false;
            this.ctlEndBalance.zz_UseGlobalFont = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(612, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select an account to reconcile, and then enter the ending balance from your accou" +
                "nt statement.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(390, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Beginning Balance";
            // 
            // lblBeginAmount
            // 
            this.lblBeginAmount.AutoSize = true;
            this.lblBeginAmount.Location = new System.Drawing.Point(390, 55);
            this.lblBeginAmount.Name = "lblBeginAmount";
            this.lblBeginAmount.Size = new System.Drawing.Size(108, 17);
            this.lblBeginAmount.TabIndex = 5;
            this.lblBeginAmount.Text = "100,000,000.00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(287, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Enter any service charge or interest earned.";
            // 
            // ctlServiceCharge
            // 
            this.ctlServiceCharge.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlServiceCharge.Bold = false;
            this.ctlServiceCharge.Caption = "Service Charge";
            this.ctlServiceCharge.Changed = false;
            this.ctlServiceCharge.EditCaption = false;
            this.ctlServiceCharge.FullDecimal = false;
            this.ctlServiceCharge.Location = new System.Drawing.Point(54, 119);
            this.ctlServiceCharge.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctlServiceCharge.Name = "ctlServiceCharge";
            this.ctlServiceCharge.RoundNearestCent = false;
            this.ctlServiceCharge.Size = new System.Drawing.Size(163, 41);
            this.ctlServiceCharge.TabIndex = 7;
            this.ctlServiceCharge.UseParentBackColor = false;
            this.ctlServiceCharge.zz_Enabled = true;
            this.ctlServiceCharge.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlServiceCharge.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlServiceCharge.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlServiceCharge.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlServiceCharge.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctlServiceCharge.zz_OriginalDesign = false;
            this.ctlServiceCharge.zz_ShowErrorColor = true;
            this.ctlServiceCharge.zz_ShowNeedsSaveColor = false;
            this.ctlServiceCharge.zz_Text = "";
            this.ctlServiceCharge.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctlServiceCharge.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlServiceCharge.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlServiceCharge.zz_UseGlobalColor = false;
            this.ctlServiceCharge.zz_UseGlobalFont = false;
            // 
            // ctlInterestEarned
            // 
            this.ctlInterestEarned.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlInterestEarned.Bold = false;
            this.ctlInterestEarned.Caption = "Interest Earned";
            this.ctlInterestEarned.Changed = false;
            this.ctlInterestEarned.EditCaption = false;
            this.ctlInterestEarned.FullDecimal = false;
            this.ctlInterestEarned.Location = new System.Drawing.Point(54, 168);
            this.ctlInterestEarned.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctlInterestEarned.Name = "ctlInterestEarned";
            this.ctlInterestEarned.RoundNearestCent = false;
            this.ctlInterestEarned.Size = new System.Drawing.Size(163, 41);
            this.ctlInterestEarned.TabIndex = 8;
            this.ctlInterestEarned.UseParentBackColor = false;
            this.ctlInterestEarned.zz_Enabled = true;
            this.ctlInterestEarned.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlInterestEarned.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlInterestEarned.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlInterestEarned.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlInterestEarned.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctlInterestEarned.zz_OriginalDesign = false;
            this.ctlInterestEarned.zz_ShowErrorColor = true;
            this.ctlInterestEarned.zz_ShowNeedsSaveColor = false;
            this.ctlInterestEarned.zz_Text = "";
            this.ctlInterestEarned.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctlInterestEarned.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlInterestEarned.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlInterestEarned.zz_UseGlobalColor = false;
            this.ctlInterestEarned.zz_UseGlobalFont = false;
            // 
            // ctlServiceDate
            // 
            this.ctlServiceDate.AllowClear = false;
            this.ctlServiceDate.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlServiceDate.Bold = false;
            this.ctlServiceDate.Caption = "Date";
            this.ctlServiceDate.Changed = false;
            this.ctlServiceDate.Location = new System.Drawing.Point(226, 119);
            this.ctlServiceDate.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ctlServiceDate.Name = "ctlServiceDate";
            this.ctlServiceDate.Size = new System.Drawing.Size(155, 41);
            this.ctlServiceDate.SuppressEdit = false;
            this.ctlServiceDate.TabIndex = 9;
            this.ctlServiceDate.UseParentBackColor = false;
            this.ctlServiceDate.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlServiceDate.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlServiceDate.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlServiceDate.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlServiceDate.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctlServiceDate.zz_OriginalDesign = false;
            this.ctlServiceDate.zz_ShowNeedsSaveColor = false;
            this.ctlServiceDate.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlServiceDate.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlServiceDate.zz_UseGlobalColor = false;
            this.ctlServiceDate.zz_UseGlobalFont = false;
            // 
            // ctlInterestDate
            // 
            this.ctlInterestDate.AllowClear = false;
            this.ctlInterestDate.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlInterestDate.Bold = false;
            this.ctlInterestDate.Caption = "Date";
            this.ctlInterestDate.Changed = false;
            this.ctlInterestDate.Location = new System.Drawing.Point(226, 168);
            this.ctlInterestDate.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ctlInterestDate.Name = "ctlInterestDate";
            this.ctlInterestDate.Size = new System.Drawing.Size(155, 41);
            this.ctlInterestDate.SuppressEdit = false;
            this.ctlInterestDate.TabIndex = 10;
            this.ctlInterestDate.UseParentBackColor = false;
            this.ctlInterestDate.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlInterestDate.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlInterestDate.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlInterestDate.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlInterestDate.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctlInterestDate.zz_OriginalDesign = false;
            this.ctlInterestDate.zz_ShowNeedsSaveColor = false;
            this.ctlInterestDate.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlInterestDate.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlInterestDate.zz_UseGlobalColor = false;
            this.ctlInterestDate.zz_UseGlobalFont = false;
            // 
            // ctlServiceAccount
            // 
            this.ctlServiceAccount.AllCaps = false;
            this.ctlServiceAccount.AllowEdit = false;
            this.ctlServiceAccount.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlServiceAccount.Bold = false;
            this.ctlServiceAccount.Caption = "Account";
            this.ctlServiceAccount.Changed = false;
            this.ctlServiceAccount.ListName = null;
            this.ctlServiceAccount.Location = new System.Drawing.Point(391, 117);
            this.ctlServiceAccount.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ctlServiceAccount.Name = "ctlServiceAccount";
            this.ctlServiceAccount.SimpleList = null;
            this.ctlServiceAccount.Size = new System.Drawing.Size(240, 43);
            this.ctlServiceAccount.TabIndex = 11;
            this.ctlServiceAccount.UseParentBackColor = false;
            this.ctlServiceAccount.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctlServiceAccount.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlServiceAccount.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlServiceAccount.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlServiceAccount.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlServiceAccount.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctlServiceAccount.zz_OriginalDesign = false;
            this.ctlServiceAccount.zz_ShowNeedsSaveColor = false;
            this.ctlServiceAccount.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlServiceAccount.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlServiceAccount.zz_UseGlobalColor = false;
            this.ctlServiceAccount.zz_UseGlobalFont = false;
            this.ctlServiceAccount.DataChanged += new NewMethod.ChangeHandler(this.ctlServiceAccount_DataChanged);
            // 
            // ctlInterestAccount
            // 
            this.ctlInterestAccount.AllCaps = false;
            this.ctlInterestAccount.AllowEdit = false;
            this.ctlInterestAccount.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlInterestAccount.Bold = false;
            this.ctlInterestAccount.Caption = "Account";
            this.ctlInterestAccount.Changed = false;
            this.ctlInterestAccount.ListName = null;
            this.ctlInterestAccount.Location = new System.Drawing.Point(391, 166);
            this.ctlInterestAccount.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ctlInterestAccount.Name = "ctlInterestAccount";
            this.ctlInterestAccount.SimpleList = null;
            this.ctlInterestAccount.Size = new System.Drawing.Size(240, 43);
            this.ctlInterestAccount.TabIndex = 12;
            this.ctlInterestAccount.UseParentBackColor = false;
            this.ctlInterestAccount.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctlInterestAccount.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlInterestAccount.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlInterestAccount.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlInterestAccount.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlInterestAccount.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctlInterestAccount.zz_OriginalDesign = false;
            this.ctlInterestAccount.zz_ShowNeedsSaveColor = false;
            this.ctlInterestAccount.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlInterestAccount.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlInterestAccount.zz_UseGlobalColor = false;
            this.ctlInterestAccount.zz_UseGlobalFont = false;
            this.ctlInterestAccount.DataChanged += new NewMethod.ChangeHandler(this.ctlInterestAccount_DataChanged);
            // 
            // cmdContinue
            // 
            this.cmdContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdContinue.Location = new System.Drawing.Point(558, 217);
            this.cmdContinue.Name = "cmdContinue";
            this.cmdContinue.Size = new System.Drawing.Size(145, 32);
            this.cmdContinue.TabIndex = 13;
            this.cmdContinue.Text = "Continue";
            this.cmdContinue.UseVisualStyleBackColor = true;
            this.cmdContinue.Click += new System.EventHandler(this.cmdContinue_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(256, 217);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(145, 32);
            this.cmdCancel.TabIndex = 14;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdClear
            // 
            this.cmdClear.Location = new System.Drawing.Point(407, 217);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(145, 32);
            this.cmdClear.TabIndex = 15;
            this.cmdClear.Text = "Clear";
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // lblLastReconciled
            // 
            this.lblLastReconciled.AutoSize = true;
            this.lblLastReconciled.ForeColor = System.Drawing.Color.Blue;
            this.lblLastReconciled.Location = new System.Drawing.Point(12, 73);
            this.lblLastReconciled.Name = "lblLastReconciled";
            this.lblLastReconciled.Size = new System.Drawing.Size(209, 17);
            this.lblLastReconciled.TabIndex = 16;
            this.lblLastReconciled.Text = "last reconciled on MM/DD/YYYY";
            // 
            // frmBeginReconciliation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 255);
            this.Controls.Add(this.lblLastReconciled);
            this.Controls.Add(this.cmdClear);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdContinue);
            this.Controls.Add(this.ctlInterestAccount);
            this.Controls.Add(this.ctlServiceAccount);
            this.Controls.Add(this.ctlInterestDate);
            this.Controls.Add(this.ctlServiceDate);
            this.Controls.Add(this.ctlInterestEarned);
            this.Controls.Add(this.ctlServiceCharge);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblBeginAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctlEndBalance);
            this.Controls.Add(this.ctlDate);
            this.Controls.Add(this.ctlAccount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmBeginReconciliation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Begin Reconciliation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NewMethod.nEdit_List ctlAccount;
        private NewMethod.nEdit_Date ctlDate;
        private NewMethod.nEdit_Money ctlEndBalance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblBeginAmount;
        private System.Windows.Forms.Label label4;
        private NewMethod.nEdit_Money ctlServiceCharge;
        private NewMethod.nEdit_Money ctlInterestEarned;
        private NewMethod.nEdit_Date ctlServiceDate;
        private NewMethod.nEdit_Date ctlInterestDate;
        private NewMethod.nEdit_List ctlServiceAccount;
        private NewMethod.nEdit_List ctlInterestAccount;
        private System.Windows.Forms.Button cmdContinue;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.Label lblLastReconciled;
    }
}