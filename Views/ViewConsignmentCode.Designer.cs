using Tools.Database;
namespace Rz5.Views
{
    partial class ViewConsignmentCode
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
            this.ctl_code_name = new NewMethod.nEdit_String();
            this.ctl_payout_percent = new NewMethod.nEdit_Number();
            this.ctl_description = new NewMethod.nEdit_String();
            this.ctl_keep_percent = new NewMethod.nEdit_Number();
            this.vendor = new Rz5.CompanyStub_PlusContact();
            this.ctl_is_stock = new NewMethod.nEdit_Boolean();
            this.ctl_notes = new NewMethod.nEdit_Memo();
            this.ctl_consignment_bogey = new NewMethod.nEdit_Number();
            this.SuspendLayout();
            // 
            // xActions
            // 
            this.xActions.Location = new System.Drawing.Point(771, 0);
            this.xActions.Size = new System.Drawing.Size(148, 390);
            // 
            // ctl_code_name
            // 
            this.ctl_code_name.AllCaps = false;
            this.ctl_code_name.BackColor = System.Drawing.Color.White;
            this.ctl_code_name.Bold = false;
            this.ctl_code_name.Caption = "Consignment Code Name";
            this.ctl_code_name.Changed = false;
            this.ctl_code_name.Enabled = false;
            this.ctl_code_name.IsEmail = false;
            this.ctl_code_name.IsURL = false;
            this.ctl_code_name.Location = new System.Drawing.Point(4, 4);
            this.ctl_code_name.Name = "ctl_code_name";
            this.ctl_code_name.PasswordChar = '\0';
            this.ctl_code_name.Size = new System.Drawing.Size(315, 35);
            this.ctl_code_name.TabIndex = 9;
            this.ctl_code_name.UseParentBackColor = true;
            this.ctl_code_name.zz_Enabled = true;
            this.ctl_code_name.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_code_name.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_code_name.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_code_name.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_code_name.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_code_name.zz_OriginalDesign = false;
            this.ctl_code_name.zz_ShowLinkButton = false;
            this.ctl_code_name.zz_ShowNeedsSaveColor = true;
            this.ctl_code_name.zz_Text = "";
            this.ctl_code_name.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_code_name.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_code_name.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_code_name.zz_UseGlobalColor = false;
            this.ctl_code_name.zz_UseGlobalFont = false;
            // 
            // ctl_payout_percent
            // 
            this.ctl_payout_percent.BackColor = System.Drawing.Color.White;
            this.ctl_payout_percent.Bold = false;
            this.ctl_payout_percent.Caption = "Payout Percent";
            this.ctl_payout_percent.Changed = false;
            this.ctl_payout_percent.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_payout_percent.Location = new System.Drawing.Point(4, 45);
            this.ctl_payout_percent.Name = "ctl_payout_percent";
            this.ctl_payout_percent.Size = new System.Drawing.Size(149, 35);
            this.ctl_payout_percent.TabIndex = 10;
            this.ctl_payout_percent.UseParentBackColor = true;
            this.ctl_payout_percent.zz_Enabled = true;
            this.ctl_payout_percent.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_payout_percent.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_payout_percent.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_payout_percent.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_payout_percent.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_payout_percent.zz_OriginalDesign = false;
            this.ctl_payout_percent.zz_ShowErrorColor = true;
            this.ctl_payout_percent.zz_ShowNeedsSaveColor = true;
            this.ctl_payout_percent.zz_Text = "";
            this.ctl_payout_percent.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_payout_percent.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_payout_percent.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_payout_percent.zz_UseGlobalColor = false;
            this.ctl_payout_percent.zz_UseGlobalFont = false;
            this.ctl_payout_percent.DataChanged += new NewMethod.ChangeHandler(this.ctl_payout_percent_DataChanged);
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
            this.ctl_description.Location = new System.Drawing.Point(3, 133);
            this.ctl_description.Name = "ctl_description";
            this.ctl_description.PasswordChar = '\0';
            this.ctl_description.Size = new System.Drawing.Size(315, 35);
            this.ctl_description.TabIndex = 11;
            this.ctl_description.UseParentBackColor = true;
            this.ctl_description.zz_Enabled = true;
            this.ctl_description.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_description.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_description.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_description.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_description.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_description.zz_OriginalDesign = false;
            this.ctl_description.zz_ShowLinkButton = false;
            this.ctl_description.zz_ShowNeedsSaveColor = true;
            this.ctl_description.zz_Text = "";
            this.ctl_description.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_description.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_description.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_description.zz_UseGlobalColor = false;
            this.ctl_description.zz_UseGlobalFont = false;
            // 
            // ctl_keep_percent
            // 
            this.ctl_keep_percent.BackColor = System.Drawing.Color.White;
            this.ctl_keep_percent.Bold = false;
            this.ctl_keep_percent.Caption = "Keep Percent";
            this.ctl_keep_percent.Changed = false;
            this.ctl_keep_percent.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_keep_percent.Enabled = false;
            this.ctl_keep_percent.Location = new System.Drawing.Point(169, 45);
            this.ctl_keep_percent.Name = "ctl_keep_percent";
            this.ctl_keep_percent.Size = new System.Drawing.Size(149, 35);
            this.ctl_keep_percent.TabIndex = 12;
            this.ctl_keep_percent.UseParentBackColor = true;
            this.ctl_keep_percent.zz_Enabled = true;
            this.ctl_keep_percent.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_keep_percent.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_keep_percent.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_keep_percent.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_keep_percent.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_keep_percent.zz_OriginalDesign = false;
            this.ctl_keep_percent.zz_ShowErrorColor = true;
            this.ctl_keep_percent.zz_ShowNeedsSaveColor = true;
            this.ctl_keep_percent.zz_Text = "";
            this.ctl_keep_percent.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_keep_percent.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_keep_percent.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_keep_percent.zz_UseGlobalColor = false;
            this.ctl_keep_percent.zz_UseGlobalFont = false;
            // 
            // vendor
            // 
            this.vendor.BackColor = System.Drawing.Color.White;
            this.vendor.Caption = "Vendor";
            this.vendor.Location = new System.Drawing.Point(337, 4);
            this.vendor.Name = "vendor";
            this.vendor.Size = new System.Drawing.Size(315, 87);
            this.vendor.TabIndex = 13;
            // 
            // ctl_is_stock
            // 
            this.ctl_is_stock.BackColor = System.Drawing.Color.White;
            this.ctl_is_stock.Bold = false;
            this.ctl_is_stock.Caption = "Stock";
            this.ctl_is_stock.Changed = false;
            this.ctl_is_stock.Location = new System.Drawing.Point(337, 99);
            this.ctl_is_stock.Name = "ctl_is_stock";
            this.ctl_is_stock.Size = new System.Drawing.Size(54, 18);
            this.ctl_is_stock.TabIndex = 14;
            this.ctl_is_stock.UseParentBackColor = true;
            this.ctl_is_stock.Visible = false;
            this.ctl_is_stock.zz_CheckValue = false;
            this.ctl_is_stock.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_is_stock.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_is_stock.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_is_stock.zz_OriginalDesign = false;
            this.ctl_is_stock.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_notes
            // 
            this.ctl_notes.BackColor = System.Drawing.Color.White;
            this.ctl_notes.Bold = false;
            this.ctl_notes.Caption = "Notes";
            this.ctl_notes.Changed = false;
            this.ctl_notes.DateLines = false;
            this.ctl_notes.Location = new System.Drawing.Point(3, 184);
            this.ctl_notes.Name = "ctl_notes";
            this.ctl_notes.Size = new System.Drawing.Size(314, 170);
            this.ctl_notes.TabIndex = 15;
            this.ctl_notes.UseParentBackColor = true;
            this.ctl_notes.zz_Enabled = true;
            this.ctl_notes.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_notes.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_notes.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_notes.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_notes.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_notes.zz_OriginalDesign = false;
            this.ctl_notes.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_notes.zz_ShowNeedsSaveColor = true;
            this.ctl_notes.zz_Text = "";
            this.ctl_notes.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_notes.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_notes.zz_UseGlobalColor = false;
            this.ctl_notes.zz_UseGlobalFont = false;
            // 
            // ctl_consignment_bogey
            // 
            this.ctl_consignment_bogey.BackColor = System.Drawing.Color.White;
            this.ctl_consignment_bogey.Bold = false;
            this.ctl_consignment_bogey.Caption = "Consignment Bogey";
            this.ctl_consignment_bogey.Changed = false;
            this.ctl_consignment_bogey.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_consignment_bogey.Location = new System.Drawing.Point(4, 86);
            this.ctl_consignment_bogey.Name = "ctl_consignment_bogey";
            this.ctl_consignment_bogey.Size = new System.Drawing.Size(314, 35);
            this.ctl_consignment_bogey.TabIndex = 16;
            this.ctl_consignment_bogey.UseParentBackColor = true;
            this.ctl_consignment_bogey.zz_Enabled = true;
            this.ctl_consignment_bogey.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_consignment_bogey.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_consignment_bogey.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_consignment_bogey.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_consignment_bogey.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_consignment_bogey.zz_OriginalDesign = false;
            this.ctl_consignment_bogey.zz_ShowErrorColor = true;
            this.ctl_consignment_bogey.zz_ShowNeedsSaveColor = true;
            this.ctl_consignment_bogey.zz_Text = "";
            this.ctl_consignment_bogey.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_consignment_bogey.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_consignment_bogey.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_consignment_bogey.zz_UseGlobalColor = false;
            this.ctl_consignment_bogey.zz_UseGlobalFont = false;
            // 
            // ViewConsignmentCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctl_consignment_bogey);
            this.Controls.Add(this.ctl_notes);
            this.Controls.Add(this.ctl_is_stock);
            this.Controls.Add(this.vendor);
            this.Controls.Add(this.ctl_keep_percent);
            this.Controls.Add(this.ctl_code_name);
            this.Controls.Add(this.ctl_payout_percent);
            this.Controls.Add(this.ctl_description);
            this.Name = "ViewConsignmentCode";
            this.Size = new System.Drawing.Size(919, 390);
            this.Controls.SetChildIndex(this.ctl_description, 0);
            this.Controls.SetChildIndex(this.ctl_payout_percent, 0);
            this.Controls.SetChildIndex(this.ctl_code_name, 0);
            this.Controls.SetChildIndex(this.ctl_keep_percent, 0);
            this.Controls.SetChildIndex(this.vendor, 0);
            this.Controls.SetChildIndex(this.ctl_is_stock, 0);
            this.Controls.SetChildIndex(this.ctl_notes, 0);
            this.Controls.SetChildIndex(this.ctl_consignment_bogey, 0);
            this.Controls.SetChildIndex(this.xActions, 0);
            this.ResumeLayout(false);

        }

        #endregion

        protected NewMethod.nEdit_String ctl_code_name;
        protected NewMethod.nEdit_Number ctl_payout_percent;
        protected NewMethod.nEdit_String ctl_description;
        protected NewMethod.nEdit_Number ctl_keep_percent;
        public CompanyStub_PlusContact vendor;
        protected NewMethod.nEdit_Boolean ctl_is_stock;
        protected NewMethod.nEdit_Memo ctl_notes;
        protected NewMethod.nEdit_Number ctl_consignment_bogey;
    }
}
