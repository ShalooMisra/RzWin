namespace RzInterfaceWin
{
    partial class frmPrintChecks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintChecks));
            this.cboAccount = new NewMethod.nEdit_List();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtNumber = new NewMethod.nEdit_Number();
            this.panel = new System.Windows.Forms.Panel();
            this.lv = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdSelectNone = new System.Windows.Forms.Button();
            this.cmdSelectAll = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboAccount
            // 
            this.cboAccount.AllCaps = false;
            this.cboAccount.AllowEdit = false;
            this.cboAccount.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cboAccount.Bold = false;
            this.cboAccount.Caption = "Bank Account";
            this.cboAccount.Changed = false;
            this.cboAccount.ListName = null;
            this.cboAccount.Location = new System.Drawing.Point(7, 2);
            this.cboAccount.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cboAccount.Name = "cboAccount";
            this.cboAccount.SimpleList = null;
            this.cboAccount.Size = new System.Drawing.Size(436, 43);
            this.cboAccount.TabIndex = 0;
            this.cboAccount.UseParentBackColor = false;
            this.cboAccount.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAccount.zz_GlobalColor = System.Drawing.Color.Black;
            this.cboAccount.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cboAccount.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.cboAccount.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAccount.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.cboAccount.zz_OriginalDesign = false;
            this.cboAccount.zz_ShowNeedsSaveColor = false;
            this.cboAccount.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.cboAccount.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAccount.zz_UseGlobalColor = false;
            this.cboAccount.zz_UseGlobalFont = false;
            this.cboAccount.DataChanged += new NewMethod.ChangeHandler(this.cboAccount_DataChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select checks to print, then click OK.";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(4, 70);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(234, 17);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "There are 0 Checks to print for 0.00";
            // 
            // txtNumber
            // 
            this.txtNumber.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtNumber.Bold = false;
            this.txtNumber.Caption = "First Check Number";
            this.txtNumber.Changed = false;
            this.txtNumber.CurrentType = Tools.Database.FieldType.Unknown;
            this.txtNumber.Location = new System.Drawing.Point(453, 5);
            this.txtNumber.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(157, 41);
            this.txtNumber.TabIndex = 4;
            this.txtNumber.UseParentBackColor = false;
            this.txtNumber.zz_Enabled = true;
            this.txtNumber.zz_GlobalColor = System.Drawing.Color.Black;
            this.txtNumber.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtNumber.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.txtNumber.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumber.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.txtNumber.zz_OriginalDesign = false;
            this.txtNumber.zz_ShowErrorColor = true;
            this.txtNumber.zz_ShowNeedsSaveColor = false;
            this.txtNumber.zz_Text = "";
            this.txtNumber.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumber.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.txtNumber.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumber.zz_UseGlobalColor = false;
            this.txtNumber.zz_UseGlobalFont = false;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.lv);
            this.panel.Controls.Add(this.cmdSelectNone);
            this.panel.Controls.Add(this.cmdSelectAll);
            this.panel.Controls.Add(this.cmdCancel);
            this.panel.Controls.Add(this.cmdOK);
            this.panel.Controls.Add(this.cboAccount);
            this.panel.Controls.Add(this.txtNumber);
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.lblStatus);
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(616, 256);
            this.panel.TabIndex = 5;
            // 
            // lv
            // 
            this.lv.CheckBoxes = true;
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lv.FullRowSelect = true;
            this.lv.GridLines = true;
            this.lv.HideSelection = false;
            this.lv.Location = new System.Drawing.Point(7, 90);
            this.lv.MultiSelect = false;
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(461, 161);
            this.lv.TabIndex = 9;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv_ItemChecked);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Date";
            this.columnHeader1.Width = 85;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Payee";
            this.columnHeader2.Width = 214;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Amount";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 132;
            // 
            // cmdSelectNone
            // 
            this.cmdSelectNone.Location = new System.Drawing.Point(474, 213);
            this.cmdSelectNone.Name = "cmdSelectNone";
            this.cmdSelectNone.Size = new System.Drawing.Size(136, 38);
            this.cmdSelectNone.TabIndex = 8;
            this.cmdSelectNone.Text = "SelectNone";
            this.cmdSelectNone.UseVisualStyleBackColor = true;
            this.cmdSelectNone.Click += new System.EventHandler(this.cmdSelectNone_Click);
            // 
            // cmdSelectAll
            // 
            this.cmdSelectAll.Location = new System.Drawing.Point(474, 172);
            this.cmdSelectAll.Name = "cmdSelectAll";
            this.cmdSelectAll.Size = new System.Drawing.Size(136, 38);
            this.cmdSelectAll.TabIndex = 7;
            this.cmdSelectAll.Text = "Select All";
            this.cmdSelectAll.UseVisualStyleBackColor = true;
            this.cmdSelectAll.Click += new System.EventHandler(this.cmdSelectAll_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(474, 132);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(136, 38);
            this.cmdCancel.TabIndex = 6;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(474, 90);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(136, 38);
            this.cmdOK.TabIndex = 5;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // frmPrintChecks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 258);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPrintChecks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Print Checks";
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private NewMethod.nEdit_List cboAccount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStatus;
        private NewMethod.nEdit_Number txtNumber;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.Button cmdSelectNone;
        private System.Windows.Forms.Button cmdSelectAll;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}