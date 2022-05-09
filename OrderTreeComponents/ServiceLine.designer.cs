using Tools.Database;
namespace Rz5
{
    partial class ServiceLine
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
            this.ctl_unitprice = new NewMethod.nEdit_Money();
            this.ctl_quantityordered = new NewMethod.nEdit_Number();
            this.ctl_internalcomment = new NewMethod.nEdit_Memo();
            this.ctl_fullpartnumber = new NewMethod.nEdit_List();
            this.ctl_description = new NewMethod.nEdit_String();
            this.lblContact = new System.Windows.Forms.Label();
            this.lblContactCap = new System.Windows.Forms.Label();
            this.lblVendor = new System.Windows.Forms.Label();
            this.lblCompanyCap = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctl_unitprice
            // 
            this.ctl_unitprice.BackColor = System.Drawing.Color.White;
            this.ctl_unitprice.Bold = true;
            this.ctl_unitprice.Caption = "Service Price";
            this.ctl_unitprice.Changed = false;
            this.ctl_unitprice.EditCaption = false;
            this.ctl_unitprice.FullDecimal = false;
            this.ctl_unitprice.Location = new System.Drawing.Point(150, 59);
            this.ctl_unitprice.Name = "ctl_unitprice";
            this.ctl_unitprice.RoundNearestCent = false;
            this.ctl_unitprice.Size = new System.Drawing.Size(115, 52);
            this.ctl_unitprice.TabIndex = 50;
            this.ctl_unitprice.UseParentBackColor = true;
            this.ctl_unitprice.zz_Enabled = true;
            this.ctl_unitprice.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_unitprice.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_unitprice.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_unitprice.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ctl_unitprice.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctl_unitprice.zz_OriginalDesign = true;
            this.ctl_unitprice.zz_ShowErrorColor = true;
            this.ctl_unitprice.zz_ShowNeedsSaveColor = true;
            this.ctl_unitprice.zz_Text = "";
            this.ctl_unitprice.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_unitprice.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_unitprice.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_unitprice.zz_UseGlobalColor = false;
            this.ctl_unitprice.zz_UseGlobalFont = false;
            // 
            // ctl_quantityordered
            // 
            this.ctl_quantityordered.BackColor = System.Drawing.Color.White;
            this.ctl_quantityordered.Bold = true;
            this.ctl_quantityordered.Caption = "Service Quantity";
            this.ctl_quantityordered.Changed = false;
            this.ctl_quantityordered.CurrentType = FieldType.Unknown;
            this.ctl_quantityordered.Location = new System.Drawing.Point(32, 59);
            this.ctl_quantityordered.Name = "ctl_quantityordered";
            this.ctl_quantityordered.Size = new System.Drawing.Size(112, 46);
            this.ctl_quantityordered.TabIndex = 49;
            this.ctl_quantityordered.UseParentBackColor = true;
            this.ctl_quantityordered.zz_Enabled = true;
            this.ctl_quantityordered.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_quantityordered.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_quantityordered.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_quantityordered.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ctl_quantityordered.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_quantityordered.zz_OriginalDesign = true;
            this.ctl_quantityordered.zz_ShowErrorColor = true;
            this.ctl_quantityordered.zz_ShowNeedsSaveColor = true;
            this.ctl_quantityordered.zz_Text = "";
            this.ctl_quantityordered.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_quantityordered.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_quantityordered.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_quantityordered.zz_UseGlobalColor = false;
            this.ctl_quantityordered.zz_UseGlobalFont = false;
            // 
            // ctl_internalcomment
            // 
            this.ctl_internalcomment.BackColor = System.Drawing.Color.White;
            this.ctl_internalcomment.Bold = false;
            this.ctl_internalcomment.Caption = "Notes";
            this.ctl_internalcomment.Changed = false;
            this.ctl_internalcomment.Location = new System.Drawing.Point(391, 79);
            this.ctl_internalcomment.Name = "ctl_internalcomment";
            this.ctl_internalcomment.Size = new System.Drawing.Size(342, 75);
            this.ctl_internalcomment.TabIndex = 48;
            this.ctl_internalcomment.UseParentBackColor = true;
            this.ctl_internalcomment.zz_Enabled = true;
            this.ctl_internalcomment.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_internalcomment.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_internalcomment.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_internalcomment.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_internalcomment.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_internalcomment.zz_OriginalDesign = true;
            this.ctl_internalcomment.zz_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ctl_internalcomment.zz_ShowNeedsSaveColor = true;
            this.ctl_internalcomment.zz_Text = "";
            this.ctl_internalcomment.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_internalcomment.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_internalcomment.zz_UseGlobalColor = false;
            this.ctl_internalcomment.zz_UseGlobalFont = false;
            // 
            // ctl_fullpartnumber
            // 
            this.ctl_fullpartnumber.AllowEdit = false;
            this.ctl_fullpartnumber.BackColor = System.Drawing.Color.White;
            this.ctl_fullpartnumber.Bold = true;
            this.ctl_fullpartnumber.Caption = "Service Name";
            this.ctl_fullpartnumber.Changed = false;
            this.ctl_fullpartnumber.ListName = "services";
            this.ctl_fullpartnumber.Location = new System.Drawing.Point(32, 9);
            this.ctl_fullpartnumber.Name = "ctl_fullpartnumber";
            this.ctl_fullpartnumber.SimpleList = null;
            this.ctl_fullpartnumber.Size = new System.Drawing.Size(353, 44);
            this.ctl_fullpartnumber.TabIndex = 52;
            this.ctl_fullpartnumber.UseParentBackColor = true;
            this.ctl_fullpartnumber.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_fullpartnumber.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_fullpartnumber.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_fullpartnumber.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ctl_fullpartnumber.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_fullpartnumber.zz_OriginalDesign = true;
            this.ctl_fullpartnumber.zz_ShowNeedsSaveColor = true;
            this.ctl_fullpartnumber.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_fullpartnumber.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_fullpartnumber.zz_UseGlobalColor = false;
            this.ctl_fullpartnumber.zz_UseGlobalFont = false;
            // 
            // ctl_description
            // 
            this.ctl_description.AllCaps = false;
            this.ctl_description.BackColor = System.Drawing.Color.White;
            this.ctl_description.Bold = true;
            this.ctl_description.Caption = "Description";
            this.ctl_description.Changed = false;
            this.ctl_description.IsEmail = false;
            this.ctl_description.IsURL = false;
            this.ctl_description.Location = new System.Drawing.Point(32, 111);
            this.ctl_description.Name = "ctl_description";
            this.ctl_description.PasswordChar = '\0';
            this.ctl_description.Size = new System.Drawing.Size(353, 41);
            this.ctl_description.TabIndex = 51;
            this.ctl_description.UseParentBackColor = true;
            this.ctl_description.zz_Enabled = true;
            this.ctl_description.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_description.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_description.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_description.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ctl_description.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_description.zz_OriginalDesign = true;
            this.ctl_description.zz_ShowLinkButton = false;
            this.ctl_description.zz_ShowNeedsSaveColor = true;
            this.ctl_description.zz_Text = "";
            this.ctl_description.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_description.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_description.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_description.zz_UseGlobalColor = false;
            this.ctl_description.zz_UseGlobalFont = false;
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContact.Location = new System.Drawing.Point(391, 56);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(150, 20);
            this.lblContact.TabIndex = 68;
            this.lblContact.Text = "Contact Name Here";
            // 
            // lblContactCap
            // 
            this.lblContactCap.AutoSize = true;
            this.lblContactCap.Location = new System.Drawing.Point(391, 44);
            this.lblContactCap.Name = "lblContactCap";
            this.lblContactCap.Size = new System.Drawing.Size(47, 13);
            this.lblContactCap.TabIndex = 67;
            this.lblContactCap.Text = "Contact:";
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendor.Location = new System.Drawing.Point(391, 19);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(146, 20);
            this.lblVendor.TabIndex = 66;
            this.lblVendor.Text = "Vendor Name Here";
            // 
            // lblCompanyCap
            // 
            this.lblCompanyCap.AutoSize = true;
            this.lblCompanyCap.Location = new System.Drawing.Point(391, 7);
            this.lblCompanyCap.Name = "lblCompanyCap";
            this.lblCompanyCap.Size = new System.Drawing.Size(83, 13);
            this.lblCompanyCap.TabIndex = 65;
            this.lblCompanyCap.Text = "Service Vendor:";
            // 
            // ServiceLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.lblContactCap);
            this.Controls.Add(this.lblVendor);
            this.Controls.Add(this.lblCompanyCap);
            this.Controls.Add(this.ctl_fullpartnumber);
            this.Controls.Add(this.ctl_description);
            this.Controls.Add(this.ctl_unitprice);
            this.Controls.Add(this.ctl_quantityordered);
            this.Controls.Add(this.ctl_internalcomment);
            this.Name = "ServiceLine";
            this.Size = new System.Drawing.Size(923, 160);
            this.Controls.SetChildIndex(this.ctl_internalcomment, 0);
            this.Controls.SetChildIndex(this.ctl_quantityordered, 0);
            this.Controls.SetChildIndex(this.ctl_unitprice, 0);
            this.Controls.SetChildIndex(this.ctl_description, 0);
            this.Controls.SetChildIndex(this.ctl_fullpartnumber, 0);
            this.Controls.SetChildIndex(this.lblCompanyCap, 0);
            this.Controls.SetChildIndex(this.lblVendor, 0);
            this.Controls.SetChildIndex(this.lblContactCap, 0);
            this.Controls.SetChildIndex(this.lblContact, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NewMethod.nEdit_Money ctl_unitprice;
        private NewMethod.nEdit_Number ctl_quantityordered;
        private NewMethod.nEdit_Memo ctl_internalcomment;
        private NewMethod.nEdit_List ctl_fullpartnumber;
        private NewMethod.nEdit_String ctl_description;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Label lblContactCap;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.Label lblCompanyCap;
    }
}
