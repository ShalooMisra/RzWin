namespace RzInterfaceWin.Screens
{
    partial class Deposits
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
            this.top = new System.Windows.Forms.Panel();
            this.bankAccount = new RzInterfaceWin.Controls.AccountSelection();
            this.pExtra = new System.Windows.Forms.Panel();
            this.newPaymentButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.memo = new NewMethod.nEdit_String();
            this.warningLabel = new System.Windows.Forms.Label();
            this.totalDepositLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.lv = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.top.SuspendLayout();
            this.pExtra.SuspendLayout();
            this.SuspendLayout();
            // 
            // top
            // 
            this.top.BackColor = System.Drawing.Color.White;
            this.top.Controls.Add(this.bankAccount);
            this.top.Controls.Add(this.pExtra);
            this.top.Controls.Add(this.memo);
            this.top.Controls.Add(this.warningLabel);
            this.top.Controls.Add(this.totalDepositLabel);
            this.top.Controls.Add(this.saveButton);
            this.top.Location = new System.Drawing.Point(3, 3);
            this.top.Name = "top";
            this.top.Size = new System.Drawing.Size(926, 119);
            this.top.TabIndex = 3;
            // 
            // bankAccount
            // 
            this.bankAccount.BackColor = System.Drawing.Color.White;
            this.bankAccount.Location = new System.Drawing.Point(3, 7);
            this.bankAccount.Name = "bankAccount";
            this.bankAccount.Size = new System.Drawing.Size(236, 50);
            this.bankAccount.TabIndex = 21;
            this.bankAccount.AccountSelected += new RzInterfaceWin.Controls.AccountSelectedHandler(this.bankAccount_AccountSelected);
            // 
            // pExtra
            // 
            this.pExtra.Controls.Add(this.newPaymentButton);
            this.pExtra.Controls.Add(this.refreshButton);
            this.pExtra.Location = new System.Drawing.Point(626, 9);
            this.pExtra.Name = "pExtra";
            this.pExtra.Size = new System.Drawing.Size(135, 75);
            this.pExtra.TabIndex = 20;
            // 
            // newPaymentButton
            // 
            this.newPaymentButton.BackgroundImage = global::RzInterfaceWin.Properties.Resources.plus;
            this.newPaymentButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.newPaymentButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPaymentButton.Location = new System.Drawing.Point(4, 3);
            this.newPaymentButton.Name = "newPaymentButton";
            this.newPaymentButton.Size = new System.Drawing.Size(52, 66);
            this.newPaymentButton.TabIndex = 20;
            this.newPaymentButton.Text = "New";
            this.newPaymentButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.newPaymentButton.UseVisualStyleBackColor = true;
            this.newPaymentButton.Click += new System.EventHandler(this.newPaymentButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.BackgroundImage = global::RzInterfaceWin.Properties.Resources.RefreshBlue3;
            this.refreshButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.refreshButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshButton.Location = new System.Drawing.Point(62, 3);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(61, 66);
            this.refreshButton.TabIndex = 19;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
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
            this.memo.Location = new System.Drawing.Point(10, 63);
            this.memo.Name = "memo";
            this.memo.PasswordChar = '\0';
            this.memo.Size = new System.Drawing.Size(335, 44);
            this.memo.TabIndex = 15;
            this.memo.UseParentBackColor = true;
            this.memo.zz_Enabled = true;
            this.memo.zz_GlobalColor = System.Drawing.Color.Black;
            this.memo.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.memo.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.memo.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.memo.DataChanged += new NewMethod.ChangeHandler(memo_DataChanged);
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warningLabel.ForeColor = System.Drawing.Color.Maroon;
            this.warningLabel.Location = new System.Drawing.Point(412, 96);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(149, 15);
            this.warningLabel.TabIndex = 12;
            this.warningLabel.Text = "this is a warning message";
            this.warningLabel.Visible = false;
            // 
            // totalDepositLabel
            // 
            this.totalDepositLabel.AutoSize = true;
            this.totalDepositLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalDepositLabel.Location = new System.Drawing.Point(267, 24);
            this.totalDepositLabel.Name = "totalDepositLabel";
            this.totalDepositLabel.Size = new System.Drawing.Size(155, 19);
            this.totalDepositLabel.TabIndex = 4;
            this.totalDepositLabel.Text = "Total Deposit: $123.45";
            // 
            // saveButton
            // 
            this.saveButton.BackgroundImage = global::RzInterfaceWin.Properties.Resources.GreenCheck;
            this.saveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.saveButton.Enabled = false;
            this.saveButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(357, 46);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(49, 65);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // lv
            // 
            this.lv.CheckBoxes = true;
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader5});
            this.lv.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv.FullRowSelect = true;
            this.lv.Location = new System.Drawing.Point(3, 128);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(926, 446);
            this.lv.TabIndex = 4;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv_ItemChecked);
            this.lv.DoubleClick += new System.EventHandler(this.lv_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Date";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Company";
            this.columnHeader2.Width = 222;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Memo";
            this.columnHeader3.Width = 238;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Amount";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader5.Width = 132;
            // 
            // Deposits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lv);
            this.Controls.Add(this.top);
            this.Name = "Deposits";
            this.Size = new System.Drawing.Size(1013, 615);
            this.Resize += new System.EventHandler(this.Deposits_Resize);
            this.top.ResumeLayout(false);
            this.top.PerformLayout();
            this.pExtra.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel top;
        private NewMethod.nEdit_String memo;
        private System.Windows.Forms.Label warningLabel;
        private System.Windows.Forms.Label totalDepositLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Panel pExtra;
        private System.Windows.Forms.Button newPaymentButton;
        private Controls.AccountSelection bankAccount;
    }
}
