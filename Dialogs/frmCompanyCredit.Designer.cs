namespace Rz5
{
    partial class frmCompanyCredit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompanyCredit));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.ctl_internal_comment = new NewMethod.nEdit_Memo();
            this.ctl_credit_name = new NewMethod.nEdit_List();
            this.ctl_credit_amount = new NewMethod.nEdit_Money();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(206, 128);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(286, 23);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(12, 99);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(186, 52);
            this.cmdAdd.TabIndex = 4;
            this.cmdAdd.Text = "Add / Update";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // ctl_internal_comment
            // 
            this.ctl_internal_comment.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_internal_comment.Bold = false;
            this.ctl_internal_comment.Caption = "Internal Comment";
            this.ctl_internal_comment.Changed = false;
            this.ctl_internal_comment.DateLines = false;
            this.ctl_internal_comment.Location = new System.Drawing.Point(206, 12);
            this.ctl_internal_comment.Name = "ctl_internal_comment";
            this.ctl_internal_comment.Size = new System.Drawing.Size(286, 110);
            this.ctl_internal_comment.TabIndex = 2;
            this.ctl_internal_comment.UseParentBackColor = false;
            this.ctl_internal_comment.zz_Enabled = true;
            this.ctl_internal_comment.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_internal_comment.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_internal_comment.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_internal_comment.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_internal_comment.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_internal_comment.zz_OriginalDesign = true;
            this.ctl_internal_comment.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_internal_comment.zz_ShowNeedsSaveColor = true;
            this.ctl_internal_comment.zz_Text = "";
            this.ctl_internal_comment.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_internal_comment.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_internal_comment.zz_UseGlobalColor = false;
            this.ctl_internal_comment.zz_UseGlobalFont = false;
            // 
            // ctl_credit_name
            // 
            this.ctl_credit_name.AllCaps = false;
            this.ctl_credit_name.AllowEdit = true;
            this.ctl_credit_name.BackColor = System.Drawing.Color.Transparent;
            this.ctl_credit_name.Bold = false;
            this.ctl_credit_name.Caption = "Description";
            this.ctl_credit_name.Changed = false;
            this.ctl_credit_name.ListName = "industry_segment";
            this.ctl_credit_name.Location = new System.Drawing.Point(13, 13);
            this.ctl_credit_name.Margin = new System.Windows.Forms.Padding(4);
            this.ctl_credit_name.Name = "ctl_credit_name";
            this.ctl_credit_name.SimpleList = "";
            this.ctl_credit_name.Size = new System.Drawing.Size(186, 38);
            this.ctl_credit_name.TabIndex = 0;
            this.ctl_credit_name.UseParentBackColor = false;
            this.ctl_credit_name.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctl_credit_name.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_credit_name.zz_GlobalFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_credit_name.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_credit_name.zz_LabelFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_credit_name.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_credit_name.zz_OriginalDesign = false;
            this.ctl_credit_name.zz_ShowNeedsSaveColor = true;
            this.ctl_credit_name.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_credit_name.zz_TextFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_credit_name.zz_UseGlobalColor = false;
            this.ctl_credit_name.zz_UseGlobalFont = false;
            // 
            // ctl_credit_amount
            // 
            this.ctl_credit_amount.BackColor = System.Drawing.Color.Transparent;
            this.ctl_credit_amount.Bold = false;
            this.ctl_credit_amount.Caption = "Credit Amount";
            this.ctl_credit_amount.Changed = false;
            this.ctl_credit_amount.EditCaption = false;
            this.ctl_credit_amount.FullDecimal = false;
            this.ctl_credit_amount.Location = new System.Drawing.Point(12, 58);
            this.ctl_credit_amount.Name = "ctl_credit_amount";
            this.ctl_credit_amount.RoundNearestCent = false;
            this.ctl_credit_amount.Size = new System.Drawing.Size(186, 35);
            this.ctl_credit_amount.TabIndex = 1;
            this.ctl_credit_amount.UseParentBackColor = false;
            this.ctl_credit_amount.zz_Enabled = true;
            this.ctl_credit_amount.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_credit_amount.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_credit_amount.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_credit_amount.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_credit_amount.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctl_credit_amount.zz_OriginalDesign = false;
            this.ctl_credit_amount.zz_ShowErrorColor = true;
            this.ctl_credit_amount.zz_ShowNeedsSaveColor = true;
            this.ctl_credit_amount.zz_Text = "";
            this.ctl_credit_amount.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_credit_amount.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_credit_amount.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_credit_amount.zz_UseGlobalColor = false;
            this.ctl_credit_amount.zz_UseGlobalFont = false;
            // 
            // frmCompanyCredit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 167);
            this.Controls.Add(this.ctl_internal_comment);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.ctl_credit_name);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.ctl_credit_amount);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCompanyCredit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company Credits";
            this.ResumeLayout(false);

        }

        #endregion

        private NewMethod.nEdit_List ctl_credit_name;
        private NewMethod.nEdit_Money ctl_credit_amount;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdAdd;
        private NewMethod.nEdit_Memo ctl_internal_comment;
    }
}