namespace Rz5
{
    partial class frmOEMProduct
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
            this.ctl_oem_product_name = new NewMethod.nEdit_String();
            this.ctl_oem_product_description = new NewMethod.nEdit_Memo();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ctl_base_price = new NewMethod.nEdit_Money();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctl_oem_product_name
            // 
            this.ctl_oem_product_name.AllCaps = false;
            this.ctl_oem_product_name.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_oem_product_name.Bold = false;
            this.ctl_oem_product_name.Caption = "Product Name";
            this.ctl_oem_product_name.Changed = false;
            this.ctl_oem_product_name.IsEmail = false;
            this.ctl_oem_product_name.IsURL = false;
            this.ctl_oem_product_name.Location = new System.Drawing.Point(13, 13);
            this.ctl_oem_product_name.Name = "ctl_oem_product_name";
            this.ctl_oem_product_name.PasswordChar = '\0';
            this.ctl_oem_product_name.Size = new System.Drawing.Size(200, 35);
            this.ctl_oem_product_name.TabIndex = 0;
            this.ctl_oem_product_name.UseParentBackColor = false;
            this.ctl_oem_product_name.zz_Enabled = true;
            this.ctl_oem_product_name.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_oem_product_name.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_oem_product_name.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_oem_product_name.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_oem_product_name.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_oem_product_name.zz_OriginalDesign = false;
            this.ctl_oem_product_name.zz_ShowLinkButton = false;
            this.ctl_oem_product_name.zz_ShowNeedsSaveColor = true;
            this.ctl_oem_product_name.zz_Text = "";
            this.ctl_oem_product_name.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_oem_product_name.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_oem_product_name.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_oem_product_name.zz_UseGlobalColor = false;
            this.ctl_oem_product_name.zz_UseGlobalFont = false;
            // 
            // ctl_oem_product_description
            // 
            this.ctl_oem_product_description.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_oem_product_description.Bold = false;
            this.ctl_oem_product_description.Caption = "Description";
            this.ctl_oem_product_description.Changed = false;
            this.ctl_oem_product_description.DateLines = false;
            this.ctl_oem_product_description.Location = new System.Drawing.Point(12, 54);
            this.ctl_oem_product_description.Name = "ctl_oem_product_description";
            this.ctl_oem_product_description.Size = new System.Drawing.Size(389, 65);
            this.ctl_oem_product_description.TabIndex = 1;
            this.ctl_oem_product_description.UseParentBackColor = false;
            this.ctl_oem_product_description.zz_Enabled = true;
            this.ctl_oem_product_description.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_oem_product_description.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_oem_product_description.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_oem_product_description.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_oem_product_description.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_oem_product_description.zz_OriginalDesign = false;
            this.ctl_oem_product_description.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_oem_product_description.zz_ShowNeedsSaveColor = true;
            this.ctl_oem_product_description.zz_Text = "";
            this.ctl_oem_product_description.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_oem_product_description.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_oem_product_description.zz_UseGlobalColor = false;
            this.ctl_oem_product_description.zz_UseGlobalFont = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 192);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(208, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(226, 192);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(121, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ctl_base_price
            // 
            this.ctl_base_price.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_base_price.Bold = false;
            this.ctl_base_price.Caption = "Base Price";
            this.ctl_base_price.Changed = false;
            this.ctl_base_price.EditCaption = false;
            this.ctl_base_price.FullDecimal = false;
            this.ctl_base_price.Location = new System.Drawing.Point(12, 135);
            this.ctl_base_price.Name = "ctl_base_price";
            this.ctl_base_price.RoundNearestCent = false;
            this.ctl_base_price.Size = new System.Drawing.Size(120, 35);
            this.ctl_base_price.TabIndex = 4;
            this.ctl_base_price.UseParentBackColor = false;
            this.ctl_base_price.zz_Enabled = true;
            this.ctl_base_price.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_base_price.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_base_price.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_base_price.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_base_price.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctl_base_price.zz_OriginalDesign = false;
            this.ctl_base_price.zz_ShowErrorColor = true;
            this.ctl_base_price.zz_ShowNeedsSaveColor = true;
            this.ctl_base_price.zz_Text = "";
            this.ctl_base_price.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_base_price.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_base_price.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_base_price.zz_UseGlobalColor = false;
            this.ctl_base_price.zz_UseGlobalFont = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnDelete.Location = new System.Drawing.Point(353, 192);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(66, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmOEMProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 234);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.ctl_base_price);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ctl_oem_product_description);
            this.Controls.Add(this.ctl_oem_product_name);
            this.Name = "frmOEMProduct";
            this.Text = "frmOEMProduct";
            this.ResumeLayout(false);

        }

        #endregion

        private NewMethod.nEdit_String ctl_oem_product_name;
        private NewMethod.nEdit_Memo ctl_oem_product_description;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private NewMethod.nEdit_Money ctl_base_price;
        private System.Windows.Forms.Button btnDelete;
    }
}