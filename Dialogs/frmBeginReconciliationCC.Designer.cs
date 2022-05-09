namespace RzInterfaceWin
{
    partial class frmBeginReconciliationCC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBeginReconciliationCC));
            this.lblLastReconciled = new System.Windows.Forms.Label();
            this.cmdClear = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdContinue = new System.Windows.Forms.Button();
            this.ctlFinanceAccount = new NewMethod.nEdit_List();
            this.ctlFinanceDate = new NewMethod.nEdit_Date();
            this.ctlFinanceCharge = new NewMethod.nEdit_Money();
            this.label4 = new System.Windows.Forms.Label();
            this.lblBeginAmount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ctlEndBalance = new NewMethod.nEdit_Money();
            this.ctlDate = new NewMethod.nEdit_Date();
            this.ctlAccount = new NewMethod.nEdit_List();
            this.SuspendLayout();
            // 
            // lblLastReconciled
            // 
            this.lblLastReconciled.AutoSize = true;
            this.lblLastReconciled.ForeColor = System.Drawing.Color.Blue;
            this.lblLastReconciled.Location = new System.Drawing.Point(11, 69);
            this.lblLastReconciled.Name = "lblLastReconciled";
            this.lblLastReconciled.Size = new System.Drawing.Size(209, 17);
            this.lblLastReconciled.TabIndex = 33;
            this.lblLastReconciled.Text = "last reconciled on MM/DD/YYYY";
            // 
            // cmdClear
            // 
            this.cmdClear.Location = new System.Drawing.Point(406, 165);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(145, 32);
            this.cmdClear.TabIndex = 32;
            this.cmdClear.Text = "Clear";
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(255, 165);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(145, 32);
            this.cmdCancel.TabIndex = 31;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdContinue
            // 
            this.cmdContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdContinue.Location = new System.Drawing.Point(557, 165);
            this.cmdContinue.Name = "cmdContinue";
            this.cmdContinue.Size = new System.Drawing.Size(145, 32);
            this.cmdContinue.TabIndex = 30;
            this.cmdContinue.Text = "Continue";
            this.cmdContinue.UseVisualStyleBackColor = true;
            this.cmdContinue.Click += new System.EventHandler(this.cmdContinue_Click);
            // 
            // ctlFinanceAccount
            // 
            this.ctlFinanceAccount.AllCaps = false;
            this.ctlFinanceAccount.AllowEdit = false;
            this.ctlFinanceAccount.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlFinanceAccount.Bold = false;
            this.ctlFinanceAccount.Caption = "Account";
            this.ctlFinanceAccount.Changed = false;
            this.ctlFinanceAccount.ListName = null;
            this.ctlFinanceAccount.Location = new System.Drawing.Point(390, 113);
            this.ctlFinanceAccount.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ctlFinanceAccount.Name = "ctlFinanceAccount";
            this.ctlFinanceAccount.SimpleList = null;
            this.ctlFinanceAccount.Size = new System.Drawing.Size(240, 43);
            this.ctlFinanceAccount.TabIndex = 28;
            this.ctlFinanceAccount.UseParentBackColor = false;
            this.ctlFinanceAccount.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctlFinanceAccount.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlFinanceAccount.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlFinanceAccount.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlFinanceAccount.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlFinanceAccount.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctlFinanceAccount.zz_OriginalDesign = false;
            this.ctlFinanceAccount.zz_ShowNeedsSaveColor = false;
            this.ctlFinanceAccount.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlFinanceAccount.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlFinanceAccount.zz_UseGlobalColor = false;
            this.ctlFinanceAccount.zz_UseGlobalFont = false;
            this.ctlFinanceAccount.DataChanged += new NewMethod.ChangeHandler(this.ctlFinanceAccount_DataChanged);
            // 
            // ctlFinanceDate
            // 
            this.ctlFinanceDate.AllowClear = false;
            this.ctlFinanceDate.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlFinanceDate.Bold = false;
            this.ctlFinanceDate.Caption = "Date";
            this.ctlFinanceDate.Changed = false;
            this.ctlFinanceDate.Location = new System.Drawing.Point(225, 115);
            this.ctlFinanceDate.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ctlFinanceDate.Name = "ctlFinanceDate";
            this.ctlFinanceDate.Size = new System.Drawing.Size(155, 41);
            this.ctlFinanceDate.SuppressEdit = false;
            this.ctlFinanceDate.TabIndex = 26;
            this.ctlFinanceDate.UseParentBackColor = false;
            this.ctlFinanceDate.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlFinanceDate.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlFinanceDate.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlFinanceDate.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlFinanceDate.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctlFinanceDate.zz_OriginalDesign = false;
            this.ctlFinanceDate.zz_ShowNeedsSaveColor = false;
            this.ctlFinanceDate.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlFinanceDate.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlFinanceDate.zz_UseGlobalColor = false;
            this.ctlFinanceDate.zz_UseGlobalFont = false;
            // 
            // ctlFinanceCharge
            // 
            this.ctlFinanceCharge.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlFinanceCharge.Bold = false;
            this.ctlFinanceCharge.Caption = "Finance Charge";
            this.ctlFinanceCharge.Changed = false;
            this.ctlFinanceCharge.EditCaption = false;
            this.ctlFinanceCharge.FullDecimal = false;
            this.ctlFinanceCharge.Location = new System.Drawing.Point(53, 115);
            this.ctlFinanceCharge.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctlFinanceCharge.Name = "ctlFinanceCharge";
            this.ctlFinanceCharge.RoundNearestCent = false;
            this.ctlFinanceCharge.Size = new System.Drawing.Size(163, 41);
            this.ctlFinanceCharge.TabIndex = 24;
            this.ctlFinanceCharge.UseParentBackColor = false;
            this.ctlFinanceCharge.zz_Enabled = true;
            this.ctlFinanceCharge.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlFinanceCharge.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlFinanceCharge.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlFinanceCharge.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlFinanceCharge.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctlFinanceCharge.zz_OriginalDesign = false;
            this.ctlFinanceCharge.zz_ShowErrorColor = true;
            this.ctlFinanceCharge.zz_ShowNeedsSaveColor = false;
            this.ctlFinanceCharge.zz_Text = "";
            this.ctlFinanceCharge.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctlFinanceCharge.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlFinanceCharge.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlFinanceCharge.zz_UseGlobalColor = false;
            this.ctlFinanceCharge.zz_UseGlobalFont = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 17);
            this.label4.TabIndex = 23;
            this.label4.Text = "Enter any finance charge.";
            // 
            // lblBeginAmount
            // 
            this.lblBeginAmount.AutoSize = true;
            this.lblBeginAmount.Location = new System.Drawing.Point(389, 51);
            this.lblBeginAmount.Name = "lblBeginAmount";
            this.lblBeginAmount.Size = new System.Drawing.Size(108, 17);
            this.lblBeginAmount.TabIndex = 22;
            this.lblBeginAmount.Text = "100,000,000.00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(389, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "Beginning Balance";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(612, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Select an account to reconcile, and then enter the ending balance from your accou" +
                "nt statement.";
            // 
            // ctlEndBalance
            // 
            this.ctlEndBalance.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlEndBalance.Bold = false;
            this.ctlEndBalance.Caption = "Ending Balance";
            this.ctlEndBalance.Changed = false;
            this.ctlEndBalance.EditCaption = false;
            this.ctlEndBalance.FullDecimal = false;
            this.ctlEndBalance.Location = new System.Drawing.Point(539, 27);
            this.ctlEndBalance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctlEndBalance.Name = "ctlEndBalance";
            this.ctlEndBalance.RoundNearestCent = false;
            this.ctlEndBalance.Size = new System.Drawing.Size(163, 41);
            this.ctlEndBalance.TabIndex = 19;
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
            // ctlDate
            // 
            this.ctlDate.AllowClear = false;
            this.ctlDate.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlDate.Bold = false;
            this.ctlDate.Caption = "Statement Date";
            this.ctlDate.Changed = false;
            this.ctlDate.Location = new System.Drawing.Point(226, 29);
            this.ctlDate.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ctlDate.Name = "ctlDate";
            this.ctlDate.Size = new System.Drawing.Size(155, 41);
            this.ctlDate.SuppressEdit = false;
            this.ctlDate.TabIndex = 18;
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
            // ctlAccount
            // 
            this.ctlAccount.AllCaps = false;
            this.ctlAccount.AllowEdit = false;
            this.ctlAccount.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlAccount.Bold = false;
            this.ctlAccount.Caption = "Account";
            this.ctlAccount.Changed = false;
            this.ctlAccount.ListName = null;
            this.ctlAccount.Location = new System.Drawing.Point(14, 27);
            this.ctlAccount.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ctlAccount.Name = "ctlAccount";
            this.ctlAccount.SimpleList = null;
            this.ctlAccount.Size = new System.Drawing.Size(202, 43);
            this.ctlAccount.TabIndex = 17;
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
            // frmBeginReconciliationCC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(715, 201);
            this.Controls.Add(this.lblLastReconciled);
            this.Controls.Add(this.cmdClear);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdContinue);
            this.Controls.Add(this.ctlFinanceAccount);
            this.Controls.Add(this.ctlFinanceDate);
            this.Controls.Add(this.ctlFinanceCharge);
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
            this.Name = "frmBeginReconciliationCC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Begin Reconciliation Credit Card";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLastReconciled;
        private System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdContinue;
        private NewMethod.nEdit_List ctlFinanceAccount;
        private NewMethod.nEdit_Date ctlFinanceDate;
        private NewMethod.nEdit_Money ctlFinanceCharge;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblBeginAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private NewMethod.nEdit_Money ctlEndBalance;
        private NewMethod.nEdit_Date ctlDate;
        private NewMethod.nEdit_List ctlAccount;
    }
}