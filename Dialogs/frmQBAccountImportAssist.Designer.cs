namespace RzInterfaceWin
{
    partial class frmQBAccountImportAssist
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
            this.txtAcnt = new NewMethod.nEdit_String();
            this.txtAmnt = new NewMethod.nEdit_Money();
            this.cboAcnt = new NewMethod.nEdit_List();
            this.txtRef = new NewMethod.nEdit_String();
            this.dtDate = new NewMethod.nEdit_Date();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtAcnt
            // 
            this.txtAcnt.AllCaps = false;
            this.txtAcnt.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtAcnt.Bold = false;
            this.txtAcnt.Caption = "Parent Account";
            this.txtAcnt.Changed = false;
            this.txtAcnt.IsEmail = false;
            this.txtAcnt.IsURL = false;
            this.txtAcnt.Location = new System.Drawing.Point(14, 14);
            this.txtAcnt.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtAcnt.Name = "txtAcnt";
            this.txtAcnt.PasswordChar = '\0';
            this.txtAcnt.Size = new System.Drawing.Size(287, 41);
            this.txtAcnt.TabIndex = 0;
            this.txtAcnt.UseParentBackColor = false;
            this.txtAcnt.zz_Enabled = true;
            this.txtAcnt.zz_GlobalColor = System.Drawing.Color.Black;
            this.txtAcnt.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtAcnt.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.txtAcnt.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcnt.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.txtAcnt.zz_OriginalDesign = false;
            this.txtAcnt.zz_ShowLinkButton = false;
            this.txtAcnt.zz_ShowNeedsSaveColor = false;
            this.txtAcnt.zz_Text = "";
            this.txtAcnt.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtAcnt.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.txtAcnt.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcnt.zz_UseGlobalColor = false;
            this.txtAcnt.zz_UseGlobalFont = false;
            // 
            // txtAmnt
            // 
            this.txtAmnt.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtAmnt.Bold = false;
            this.txtAmnt.Caption = "Amount";
            this.txtAmnt.Changed = false;
            this.txtAmnt.EditCaption = false;
            this.txtAmnt.FullDecimal = false;
            this.txtAmnt.Location = new System.Drawing.Point(13, 64);
            this.txtAmnt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAmnt.Name = "txtAmnt";
            this.txtAmnt.RoundNearestCent = false;
            this.txtAmnt.Size = new System.Drawing.Size(288, 41);
            this.txtAmnt.TabIndex = 1;
            this.txtAmnt.UseParentBackColor = false;
            this.txtAmnt.zz_Enabled = true;
            this.txtAmnt.zz_GlobalColor = System.Drawing.Color.Black;
            this.txtAmnt.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtAmnt.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.txtAmnt.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmnt.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.txtAmnt.zz_OriginalDesign = false;
            this.txtAmnt.zz_ShowErrorColor = true;
            this.txtAmnt.zz_ShowNeedsSaveColor = false;
            this.txtAmnt.zz_Text = "";
            this.txtAmnt.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmnt.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.txtAmnt.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmnt.zz_UseGlobalColor = false;
            this.txtAmnt.zz_UseGlobalFont = false;
            // 
            // cboAcnt
            // 
            this.cboAcnt.AllCaps = false;
            this.cboAcnt.AllowEdit = false;
            this.cboAcnt.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cboAcnt.Bold = false;
            this.cboAcnt.Caption = "Child Account";
            this.cboAcnt.Changed = false;
            this.cboAcnt.ListName = null;
            this.cboAcnt.Location = new System.Drawing.Point(14, 114);
            this.cboAcnt.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cboAcnt.Name = "cboAcnt";
            this.cboAcnt.SimpleList = null;
            this.cboAcnt.Size = new System.Drawing.Size(584, 43);
            this.cboAcnt.TabIndex = 2;
            this.cboAcnt.UseParentBackColor = false;
            this.cboAcnt.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboAcnt.zz_GlobalColor = System.Drawing.Color.Black;
            this.cboAcnt.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cboAcnt.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.cboAcnt.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAcnt.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.cboAcnt.zz_OriginalDesign = false;
            this.cboAcnt.zz_ShowNeedsSaveColor = false;
            this.cboAcnt.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.cboAcnt.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAcnt.zz_UseGlobalColor = false;
            this.cboAcnt.zz_UseGlobalFont = false;
            // 
            // txtRef
            // 
            this.txtRef.AllCaps = false;
            this.txtRef.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtRef.Bold = false;
            this.txtRef.Caption = "Reference";
            this.txtRef.Changed = false;
            this.txtRef.IsEmail = false;
            this.txtRef.IsURL = false;
            this.txtRef.Location = new System.Drawing.Point(311, 14);
            this.txtRef.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtRef.Name = "txtRef";
            this.txtRef.PasswordChar = '\0';
            this.txtRef.Size = new System.Drawing.Size(287, 41);
            this.txtRef.TabIndex = 3;
            this.txtRef.UseParentBackColor = false;
            this.txtRef.zz_Enabled = true;
            this.txtRef.zz_GlobalColor = System.Drawing.Color.Black;
            this.txtRef.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtRef.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.txtRef.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRef.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.txtRef.zz_OriginalDesign = false;
            this.txtRef.zz_ShowLinkButton = false;
            this.txtRef.zz_ShowNeedsSaveColor = false;
            this.txtRef.zz_Text = "";
            this.txtRef.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtRef.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.txtRef.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRef.zz_UseGlobalColor = false;
            this.txtRef.zz_UseGlobalFont = false;
            // 
            // dtDate
            // 
            this.dtDate.AllowClear = false;
            this.dtDate.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.dtDate.Bold = false;
            this.dtDate.Caption = "Date";
            this.dtDate.Changed = false;
            this.dtDate.Location = new System.Drawing.Point(311, 64);
            this.dtDate.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(287, 41);
            this.dtDate.SuppressEdit = false;
            this.dtDate.TabIndex = 4;
            this.dtDate.UseParentBackColor = false;
            this.dtDate.zz_GlobalColor = System.Drawing.Color.Black;
            this.dtDate.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dtDate.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.dtDate.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.dtDate.zz_OriginalDesign = false;
            this.dtDate.zz_ShowNeedsSaveColor = false;
            this.dtDate.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.dtDate.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.zz_UseGlobalColor = false;
            this.dtDate.zz_UseGlobalFont = false;
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(488, 165);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(110, 28);
            this.cmdOK.TabIndex = 5;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(311, 165);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(110, 28);
            this.cmdCancel.TabIndex = 6;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmQBAccountImportAssist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 202);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.txtRef);
            this.Controls.Add(this.cboAcnt);
            this.Controls.Add(this.txtAmnt);
            this.Controls.Add(this.txtAcnt);
            this.Name = "frmQBAccountImportAssist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QBs Account Import Assistant";
            this.ResumeLayout(false);

        }

        #endregion

        private NewMethod.nEdit_String txtAcnt;
        private NewMethod.nEdit_Money txtAmnt;
        private NewMethod.nEdit_List cboAcnt;
        private NewMethod.nEdit_String txtRef;
        private NewMethod.nEdit_Date dtDate;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
    }
}