namespace RzInterfaceWin.Screens
{
    partial class ProcessPayments
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
            this.top = new System.Windows.Forms.Panel();
            this.lvCreditMemo = new System.Windows.Forms.ListView();
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mnuCreditMemo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuOpenCreditMemo = new System.Windows.Forms.ToolStripMenuItem();
            this.pMethod = new System.Windows.Forms.Panel();
            this.optManualCheck = new System.Windows.Forms.RadioButton();
            this.optPrintCheck = new System.Windows.Forms.RadioButton();
            this.accountSelection = new RzInterfaceWin.Controls.AccountSelection();
            this.refreshButton = new System.Windows.Forms.Button();
            this.pVendor = new System.Windows.Forms.Panel();
            this.newBillButton = new System.Windows.Forms.Button();
            this.memo = new NewMethod.nEdit_String();
            this.openLabel = new System.Windows.Forms.Label();
            this.appliedLabel = new System.Windows.Forms.Label();
            this.warningLabel = new System.Windows.Forms.Label();
            this.paymentAmount = new NewMethod.nEdit_Money();
            this.totalBalanceLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cStub = new Rz5.CompanyStub();
            this.lv = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mnu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openThisOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.top.SuspendLayout();
            this.mnuCreditMemo.SuspendLayout();
            this.pMethod.SuspendLayout();
            this.pVendor.SuspendLayout();
            this.mnu.SuspendLayout();
            this.SuspendLayout();
            // 
            // top
            // 
            this.top.BackColor = System.Drawing.Color.White;
            this.top.Controls.Add(this.label1);
            this.top.Controls.Add(this.lvCreditMemo);
            this.top.Controls.Add(this.pMethod);
            this.top.Controls.Add(this.accountSelection);
            this.top.Controls.Add(this.refreshButton);
            this.top.Controls.Add(this.pVendor);
            this.top.Controls.Add(this.memo);
            this.top.Controls.Add(this.openLabel);
            this.top.Controls.Add(this.appliedLabel);
            this.top.Controls.Add(this.warningLabel);
            this.top.Controls.Add(this.paymentAmount);
            this.top.Controls.Add(this.totalBalanceLabel);
            this.top.Controls.Add(this.saveButton);
            this.top.Controls.Add(this.cStub);
            this.top.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.top.Location = new System.Drawing.Point(4, 4);
            this.top.Margin = new System.Windows.Forms.Padding(4);
            this.top.Name = "top";
            this.top.Size = new System.Drawing.Size(1373, 288);
            this.top.TabIndex = 2;
            // 
            // lvCreditMemo
            // 
            this.lvCreditMemo.CheckBoxes = true;
            this.lvCreditMemo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader14,
            this.columnHeader13,
            this.columnHeader15});
            this.lvCreditMemo.ContextMenuStrip = this.mnuCreditMemo;
            this.lvCreditMemo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvCreditMemo.FullRowSelect = true;
            this.lvCreditMemo.GridLines = true;
            this.lvCreditMemo.HideSelection = false;
            this.lvCreditMemo.Location = new System.Drawing.Point(965, 36);
            this.lvCreditMemo.Margin = new System.Windows.Forms.Padding(4);
            this.lvCreditMemo.Name = "lvCreditMemo";
            this.lvCreditMemo.Size = new System.Drawing.Size(395, 205);
            this.lvCreditMemo.TabIndex = 4;
            this.lvCreditMemo.UseCompatibleStateImageBehavior = false;
            this.lvCreditMemo.View = System.Windows.Forms.View.Details;
            this.lvCreditMemo.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvCreditMemo_ItemChecked);
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Date";
            this.columnHeader14.Width = 135;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Number";
            this.columnHeader13.Width = 94;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Amount";
            this.columnHeader15.Width = 134;
            // 
            // mnuCreditMemo
            // 
            this.mnuCreditMemo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuCreditMemo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenCreditMemo});
            this.mnuCreditMemo.Name = "mnu";
            this.mnuCreditMemo.Size = new System.Drawing.Size(213, 32);
            // 
            // mnuOpenCreditMemo
            // 
            this.mnuOpenCreditMemo.Name = "mnuOpenCreditMemo";
            this.mnuOpenCreditMemo.Size = new System.Drawing.Size(212, 28);
            this.mnuOpenCreditMemo.Text = "Open this order";
            this.mnuOpenCreditMemo.Click += new System.EventHandler(this.mnuOpenCreditMemo_Click);
            // 
            // pMethod
            // 
            this.pMethod.BackColor = System.Drawing.Color.White;
            this.pMethod.Controls.Add(this.optManualCheck);
            this.pMethod.Controls.Add(this.optPrintCheck);
            this.pMethod.Location = new System.Drawing.Point(292, 155);
            this.pMethod.Margin = new System.Windows.Forms.Padding(4);
            this.pMethod.Name = "pMethod";
            this.pMethod.Size = new System.Drawing.Size(194, 69);
            this.pMethod.TabIndex = 17;
            // 
            // optManualCheck
            // 
            this.optManualCheck.AutoSize = true;
            this.optManualCheck.Checked = true;
            this.optManualCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optManualCheck.Location = new System.Drawing.Point(9, 5);
            this.optManualCheck.Name = "optManualCheck";
            this.optManualCheck.Size = new System.Drawing.Size(186, 33);
            this.optManualCheck.TabIndex = 19;
            this.optManualCheck.TabStop = true;
            this.optManualCheck.Text = "Manual Check";
            this.optManualCheck.UseVisualStyleBackColor = true;
            // 
            // optPrintCheck
            // 
            this.optPrintCheck.AutoSize = true;
            this.optPrintCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optPrintCheck.Location = new System.Drawing.Point(9, 35);
            this.optPrintCheck.Name = "optPrintCheck";
            this.optPrintCheck.Size = new System.Drawing.Size(157, 33);
            this.optPrintCheck.TabIndex = 20;
            this.optPrintCheck.Text = "Print Check";
            this.optPrintCheck.UseVisualStyleBackColor = true;
            // 
            // accountSelection
            // 
            this.accountSelection.BackColor = System.Drawing.Color.White;
            this.accountSelection.Location = new System.Drawing.Point(472, 90);
            this.accountSelection.Margin = new System.Windows.Forms.Padding(4);
            this.accountSelection.Name = "accountSelection";
            this.accountSelection.Size = new System.Drawing.Size(313, 59);
            this.accountSelection.TabIndex = 18;
            this.accountSelection.AccountSelected += new RzInterfaceWin.Controls.AccountSelectedHandler(this.accountSelection_AccountSelected);
            // 
            // refreshButton
            // 
            this.refreshButton.BackgroundImage = global::RzInterfaceWin.Properties.Resources.RefreshBlue3;
            this.refreshButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.refreshButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshButton.Location = new System.Drawing.Point(793, 14);
            this.refreshButton.Margin = new System.Windows.Forms.Padding(4);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(81, 100);
            this.refreshButton.TabIndex = 17;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // pVendor
            // 
            this.pVendor.BackColor = System.Drawing.Color.White;
            this.pVendor.Controls.Add(this.newBillButton);
            this.pVendor.Location = new System.Drawing.Point(878, 10);
            this.pVendor.Margin = new System.Windows.Forms.Padding(4);
            this.pVendor.Name = "pVendor";
            this.pVendor.Size = new System.Drawing.Size(80, 108);
            this.pVendor.TabIndex = 16;
            // 
            // newBillButton
            // 
            this.newBillButton.BackgroundImage = global::RzInterfaceWin.Properties.Resources.plus;
            this.newBillButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.newBillButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newBillButton.Location = new System.Drawing.Point(4, 4);
            this.newBillButton.Margin = new System.Windows.Forms.Padding(4);
            this.newBillButton.Name = "newBillButton";
            this.newBillButton.Size = new System.Drawing.Size(68, 100);
            this.newBillButton.TabIndex = 2;
            this.newBillButton.Text = "New Bill";
            this.newBillButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.newBillButton.UseVisualStyleBackColor = true;
            this.newBillButton.Click += new System.EventHandler(this.newBillButton_Click);
            // 
            // memo
            // 
            this.memo.AllCaps = false;
            this.memo.BackColor = System.Drawing.Color.White;
            this.memo.Bold = false;
            this.memo.Caption = "Memo";
            this.memo.Changed = false;
            this.memo.IsEmail = false;
            this.memo.IsURL = false;
            this.memo.Location = new System.Drawing.Point(16, 89);
            this.memo.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.memo.Name = "memo";
            this.memo.PasswordChar = '\0';
            this.memo.Size = new System.Drawing.Size(452, 58);
            this.memo.TabIndex = 15;
            this.memo.UseParentBackColor = true;
            this.memo.zz_Enabled = true;
            this.memo.zz_GlobalColor = System.Drawing.Color.Black;
            this.memo.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.memo.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.memo.zz_LabelFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memo.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.memo.zz_OriginalDesign = false;
            this.memo.zz_ShowLinkButton = false;
            this.memo.zz_ShowNeedsSaveColor = true;
            this.memo.zz_Text = "";
            this.memo.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.memo.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.memo.zz_TextFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memo.zz_UseGlobalColor = false;
            this.memo.zz_UseGlobalFont = false;
            // 
            // openLabel
            // 
            this.openLabel.AutoSize = true;
            this.openLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openLabel.Location = new System.Drawing.Point(11, 246);
            this.openLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.openLabel.Name = "openLabel";
            this.openLabel.Size = new System.Drawing.Size(130, 24);
            this.openLabel.TabIndex = 14;
            this.openLabel.Text = "Open: $123.45";
            // 
            // appliedLabel
            // 
            this.appliedLabel.AutoSize = true;
            this.appliedLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appliedLabel.Location = new System.Drawing.Point(11, 220);
            this.appliedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.appliedLabel.Name = "appliedLabel";
            this.appliedLabel.Size = new System.Drawing.Size(150, 24);
            this.appliedLabel.TabIndex = 13;
            this.appliedLabel.Text = "Applied: $123.45";
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warningLabel.ForeColor = System.Drawing.Color.Maroon;
            this.warningLabel.Location = new System.Drawing.Point(576, 255);
            this.warningLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(187, 21);
            this.warningLabel.TabIndex = 12;
            this.warningLabel.Text = "this is a warning message";
            this.warningLabel.Visible = false;
            // 
            // paymentAmount
            // 
            this.paymentAmount.BackColor = System.Drawing.Color.White;
            this.paymentAmount.Bold = false;
            this.paymentAmount.Caption = "Payment Amount";
            this.paymentAmount.Changed = false;
            this.paymentAmount.EditCaption = false;
            this.paymentAmount.FullDecimal = false;
            this.paymentAmount.Location = new System.Drawing.Point(16, 155);
            this.paymentAmount.Margin = new System.Windows.Forms.Padding(5);
            this.paymentAmount.Name = "paymentAmount";
            this.paymentAmount.RoundNearestCent = false;
            this.paymentAmount.Size = new System.Drawing.Size(213, 58);
            this.paymentAmount.TabIndex = 5;
            this.paymentAmount.UseParentBackColor = true;
            this.paymentAmount.zz_Enabled = true;
            this.paymentAmount.zz_GlobalColor = System.Drawing.Color.Black;
            this.paymentAmount.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentAmount.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.paymentAmount.zz_LabelFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentAmount.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.paymentAmount.zz_OriginalDesign = false;
            this.paymentAmount.zz_ShowErrorColor = true;
            this.paymentAmount.zz_ShowNeedsSaveColor = true;
            this.paymentAmount.zz_Text = "";
            this.paymentAmount.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.paymentAmount.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.paymentAmount.zz_TextFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentAmount.zz_UseGlobalColor = false;
            this.paymentAmount.zz_UseGlobalFont = false;
            this.paymentAmount.DataChanged += new NewMethod.ChangeHandler(this.paymentAmount_DataChanged);
            // 
            // totalBalanceLabel
            // 
            this.totalBalanceLabel.AutoSize = true;
            this.totalBalanceLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalBalanceLabel.Location = new System.Drawing.Point(497, 47);
            this.totalBalanceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totalBalanceLabel.Name = "totalBalanceLabel";
            this.totalBalanceLabel.Size = new System.Drawing.Size(196, 24);
            this.totalBalanceLabel.TabIndex = 4;
            this.totalBalanceLabel.Text = "Total Balance: $123.45";
            // 
            // saveButton
            // 
            this.saveButton.BackgroundImage = global::RzInterfaceWin.Properties.Resources.GreenCheck;
            this.saveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.saveButton.Enabled = false;
            this.saveButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(503, 198);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(65, 80);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cStub
            // 
            this.cStub.Caption = "<caption>";
            this.cStub.Location = new System.Drawing.Point(16, 14);
            this.cStub.Margin = new System.Windows.Forms.Padding(5);
            this.cStub.Name = "cStub";
            this.cStub.Size = new System.Drawing.Size(364, 82);
            this.cStub.TabIndex = 2;
            this.cStub.ChangeCompany += new Rz5.ContactEventHandler(this.cStub_ChangeCompany);
            this.cStub.ClearCompany += new Rz5.ContactEventHandler(this.cStub_ClearCompany);
            // 
            // lv
            // 
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lv.ContextMenuStrip = this.mnu;
            this.lv.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv.FullRowSelect = true;
            this.lv.Location = new System.Drawing.Point(5, 329);
            this.lv.Margin = new System.Windows.Forms.Padding(4);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(1017, 194);
            this.lv.TabIndex = 3;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.DoubleClick += new System.EventHandler(this.lv_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Date";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Number";
            this.columnHeader2.Width = 119;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Reference";
            this.columnHeader3.Width = 134;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Total";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader4.Width = 101;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Outstanding";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader5.Width = 133;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Payment";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader6.Width = 137;
            // 
            // mnu
            // 
            this.mnu.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openThisOrderToolStripMenuItem});
            this.mnu.Name = "mnu";
            this.mnu.Size = new System.Drawing.Size(213, 32);
            this.mnu.Opening += new System.ComponentModel.CancelEventHandler(this.mnu_Opening);
            // 
            // openThisOrderToolStripMenuItem
            // 
            this.openThisOrderToolStripMenuItem.Name = "openThisOrderToolStripMenuItem";
            this.openThisOrderToolStripMenuItem.Size = new System.Drawing.Size(212, 28);
            this.openThisOrderToolStripMenuItem.Text = "Open this order";
            this.openThisOrderToolStripMenuItem.Click += new System.EventHandler(this.openThisOrderToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(961, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 25);
            this.label1.TabIndex = 19;
            this.label1.Text = "Credit Memos";
            // 
            // ProcessPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lv);
            this.Controls.Add(this.top);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ProcessPayments";
            this.Size = new System.Drawing.Size(1411, 660);
            this.Resize += new System.EventHandler(this.ProcessPayments_Resize);
            this.top.ResumeLayout(false);
            this.top.PerformLayout();
            this.mnuCreditMemo.ResumeLayout(false);
            this.pMethod.ResumeLayout(false);
            this.pMethod.PerformLayout();
            this.pVendor.ResumeLayout(false);
            this.mnu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel top;
        private Rz5.CompanyStub cStub;
        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ContextMenuStrip mnu;
        private System.Windows.Forms.ToolStripMenuItem openThisOrderToolStripMenuItem;
        private NewMethod.nEdit_Money paymentAmount;
        private System.Windows.Forms.Label totalBalanceLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label warningLabel;
        private System.Windows.Forms.Label appliedLabel;
        private System.Windows.Forms.Label openLabel;
        private NewMethod.nEdit_String memo;
        private System.Windows.Forms.Panel pVendor;
        private System.Windows.Forms.Button newBillButton;
        private System.Windows.Forms.Button refreshButton;
        private Controls.AccountSelection accountSelection;
        private System.Windows.Forms.RadioButton optPrintCheck;
        private System.Windows.Forms.RadioButton optManualCheck;
        private System.Windows.Forms.Panel pMethod;
        private System.Windows.Forms.ListView lvCreditMemo;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ContextMenuStrip mnuCreditMemo;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenCreditMemo;
        private System.Windows.Forms.Label label1;
    }
}
