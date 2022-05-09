namespace RzInterfaceWin
{
    partial class frmAskNewAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAskNewAccount));
            this.ctlAccountType = new NewMethod.nEdit_List();
            this.ctlParentAccount = new NewMethod.nEdit_List();
            this.ctlAccountName = new NewMethod.nEdit_String();
            this.ctlAccountNumber = new NewMethod.nEdit_Number();
            this.cmdAccept = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctlAccountType
            // 
            this.ctlAccountType.AllCaps = false;
            this.ctlAccountType.AllowEdit = false;
            this.ctlAccountType.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlAccountType.Bold = false;
            this.ctlAccountType.Caption = "Account Type";
            this.ctlAccountType.Changed = false;
            this.ctlAccountType.ListName = null;
            this.ctlAccountType.Location = new System.Drawing.Point(5, 5);
            this.ctlAccountType.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ctlAccountType.Name = "ctlAccountType";
            this.ctlAccountType.SimpleList = resources.GetString("ctlAccountType.SimpleList");
            this.ctlAccountType.Size = new System.Drawing.Size(417, 50);
            this.ctlAccountType.TabIndex = 0;
            this.ctlAccountType.UseParentBackColor = false;
            this.ctlAccountType.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctlAccountType.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlAccountType.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlAccountType.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlAccountType.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlAccountType.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctlAccountType.zz_OriginalDesign = false;
            this.ctlAccountType.zz_ShowNeedsSaveColor = false;
            this.ctlAccountType.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlAccountType.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlAccountType.zz_UseGlobalColor = false;
            this.ctlAccountType.zz_UseGlobalFont = false;
            this.ctlAccountType.DataChanged += new NewMethod.ChangeHandler(this.ctlAccountType_DataChanged);
            // 
            // ctlParentAccount
            // 
            this.ctlParentAccount.AllCaps = false;
            this.ctlParentAccount.AllowEdit = false;
            this.ctlParentAccount.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlParentAccount.Bold = false;
            this.ctlParentAccount.Caption = "Sub-Account Of";
            this.ctlParentAccount.Changed = false;
            this.ctlParentAccount.ListName = null;
            this.ctlParentAccount.Location = new System.Drawing.Point(5, 109);
            this.ctlParentAccount.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ctlParentAccount.Name = "ctlParentAccount";
            this.ctlParentAccount.SimpleList = null;
            this.ctlParentAccount.Size = new System.Drawing.Size(417, 50);
            this.ctlParentAccount.TabIndex = 1;
            this.ctlParentAccount.UseParentBackColor = false;
            this.ctlParentAccount.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctlParentAccount.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlParentAccount.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlParentAccount.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlParentAccount.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlParentAccount.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctlParentAccount.zz_OriginalDesign = false;
            this.ctlParentAccount.zz_ShowNeedsSaveColor = false;
            this.ctlParentAccount.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlParentAccount.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlParentAccount.zz_UseGlobalColor = false;
            this.ctlParentAccount.zz_UseGlobalFont = false;
            this.ctlParentAccount.DataChanged += new NewMethod.ChangeHandler(this.ctlParentAccount_DataChanged);
            // 
            // ctlAccountName
            // 
            this.ctlAccountName.AllCaps = false;
            this.ctlAccountName.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlAccountName.Bold = false;
            this.ctlAccountName.Caption = "Account Name";
            this.ctlAccountName.Changed = false;
            this.ctlAccountName.IsEmail = false;
            this.ctlAccountName.IsURL = false;
            this.ctlAccountName.Location = new System.Drawing.Point(5, 58);
            this.ctlAccountName.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ctlAccountName.Name = "ctlAccountName";
            this.ctlAccountName.PasswordChar = '\0';
            this.ctlAccountName.Size = new System.Drawing.Size(255, 49);
            this.ctlAccountName.TabIndex = 2;
            this.ctlAccountName.UseParentBackColor = false;
            this.ctlAccountName.zz_Enabled = true;
            this.ctlAccountName.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlAccountName.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlAccountName.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlAccountName.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlAccountName.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctlAccountName.zz_OriginalDesign = false;
            this.ctlAccountName.zz_ShowLinkButton = false;
            this.ctlAccountName.zz_ShowNeedsSaveColor = false;
            this.ctlAccountName.zz_Text = "";
            this.ctlAccountName.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlAccountName.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlAccountName.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlAccountName.zz_UseGlobalColor = false;
            this.ctlAccountName.zz_UseGlobalFont = false;
            // 
            // ctlAccountNumber
            // 
            this.ctlAccountNumber.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlAccountNumber.Bold = false;
            this.ctlAccountNumber.Caption = "Account Number";
            this.ctlAccountNumber.Changed = false;
            this.ctlAccountNumber.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctlAccountNumber.Location = new System.Drawing.Point(270, 58);
            this.ctlAccountNumber.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ctlAccountNumber.Name = "ctlAccountNumber";
            this.ctlAccountNumber.Size = new System.Drawing.Size(152, 49);
            this.ctlAccountNumber.TabIndex = 3;
            this.ctlAccountNumber.UseParentBackColor = false;
            this.ctlAccountNumber.zz_Enabled = true;
            this.ctlAccountNumber.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlAccountNumber.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlAccountNumber.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlAccountNumber.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlAccountNumber.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctlAccountNumber.zz_OriginalDesign = false;
            this.ctlAccountNumber.zz_ShowErrorColor = true;
            this.ctlAccountNumber.zz_ShowNeedsSaveColor = false;
            this.ctlAccountNumber.zz_Text = "";
            this.ctlAccountNumber.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctlAccountNumber.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlAccountNumber.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlAccountNumber.zz_UseGlobalColor = false;
            this.ctlAccountNumber.zz_UseGlobalFont = false;
            // 
            // cmdAccept
            // 
            this.cmdAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAccept.Location = new System.Drawing.Point(297, 167);
            this.cmdAccept.Name = "cmdAccept";
            this.cmdAccept.Size = new System.Drawing.Size(124, 37);
            this.cmdAccept.TabIndex = 4;
            this.cmdAccept.Text = "Accept";
            this.cmdAccept.UseVisualStyleBackColor = true;
            this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(136, 167);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(124, 37);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.ctlAccountType);
            this.panel.Controls.Add(this.cmdCancel);
            this.panel.Controls.Add(this.ctlParentAccount);
            this.panel.Controls.Add(this.cmdAccept);
            this.panel.Controls.Add(this.ctlAccountName);
            this.panel.Controls.Add(this.ctlAccountNumber);
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(427, 208);
            this.panel.TabIndex = 6;
            // 
            // frmAskNewAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 208);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmAskNewAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Account";
            this.Resize += new System.EventHandler(this.frmAskNewAccount_Resize);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private NewMethod.nEdit_List ctlAccountType;
        private NewMethod.nEdit_List ctlParentAccount;
        private NewMethod.nEdit_String ctlAccountName;
        private NewMethod.nEdit_Number ctlAccountNumber;
        private System.Windows.Forms.Button cmdAccept;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Panel panel;
    }
}