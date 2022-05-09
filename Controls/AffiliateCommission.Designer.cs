namespace RzInterfaceWin.Controls
{
    partial class AffiliateCommission
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
            this.gbAffiliate = new System.Windows.Forms.GroupBox();
            this.btnDeleteAffiliateID = new System.Windows.Forms.Button();
            this.btnSaveAffiliateID = new System.Windows.Forms.Button();
            this.ctl_affiliateID = new NewMethod.nEdit_String();
            this.gbAffiliate.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAffiliate
            // 
            this.gbAffiliate.Controls.Add(this.btnDeleteAffiliateID);
            this.gbAffiliate.Controls.Add(this.btnSaveAffiliateID);
            this.gbAffiliate.Controls.Add(this.ctl_affiliateID);
            this.gbAffiliate.Location = new System.Drawing.Point(3, 3);
            this.gbAffiliate.Name = "gbAffiliate";
            this.gbAffiliate.Size = new System.Drawing.Size(290, 92);
            this.gbAffiliate.TabIndex = 88;
            this.gbAffiliate.TabStop = false;
            this.gbAffiliate.Text = "Affiliate Commission";
            // 
            // btnDeleteAffiliateID
            // 
            this.btnDeleteAffiliateID.Location = new System.Drawing.Point(228, 58);
            this.btnDeleteAffiliateID.Name = "btnDeleteAffiliateID";
            this.btnDeleteAffiliateID.Size = new System.Drawing.Size(47, 26);
            this.btnDeleteAffiliateID.TabIndex = 84;
            this.btnDeleteAffiliateID.Text = "Delete";
            this.btnDeleteAffiliateID.UseVisualStyleBackColor = true;
            this.btnDeleteAffiliateID.Click += new System.EventHandler(this.btnDeleteAffiliateID_Click);
            // 
            // btnSaveAffiliateID
            // 
            this.btnSaveAffiliateID.Location = new System.Drawing.Point(14, 58);
            this.btnSaveAffiliateID.Name = "btnSaveAffiliateID";
            this.btnSaveAffiliateID.Size = new System.Drawing.Size(208, 26);
            this.btnSaveAffiliateID.TabIndex = 83;
            this.btnSaveAffiliateID.Text = "Save";
            this.btnSaveAffiliateID.UseVisualStyleBackColor = true;
            this.btnSaveAffiliateID.Click += new System.EventHandler(this.btnSaveAffiliateID_Click);
            // 
            // ctl_affiliateID
            // 
            this.ctl_affiliateID.AllCaps = false;
            this.ctl_affiliateID.BackColor = System.Drawing.Color.Transparent;
            this.ctl_affiliateID.Bold = false;
            this.ctl_affiliateID.Caption = "Affiliate ID:";
            this.ctl_affiliateID.Changed = true;
            this.ctl_affiliateID.IsEmail = false;
            this.ctl_affiliateID.IsURL = false;
            this.ctl_affiliateID.Location = new System.Drawing.Point(14, 16);
            this.ctl_affiliateID.Name = "ctl_affiliateID";
            this.ctl_affiliateID.PasswordChar = '\0';
            this.ctl_affiliateID.Size = new System.Drawing.Size(261, 35);
            this.ctl_affiliateID.TabIndex = 0;
            this.ctl_affiliateID.UseParentBackColor = false;
            this.ctl_affiliateID.zz_Enabled = true;
            this.ctl_affiliateID.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_affiliateID.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_affiliateID.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_affiliateID.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_affiliateID.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_affiliateID.zz_OriginalDesign = false;
            this.ctl_affiliateID.zz_ShowLinkButton = false;
            this.ctl_affiliateID.zz_ShowNeedsSaveColor = true;
            this.ctl_affiliateID.zz_Text = "N/A";
            this.ctl_affiliateID.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_affiliateID.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_affiliateID.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_affiliateID.zz_UseGlobalColor = false;
            this.ctl_affiliateID.zz_UseGlobalFont = false;
            // 
            // AffiliateCommissoin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbAffiliate);
            this.Name = "AffiliateCommissoin";
            this.Size = new System.Drawing.Size(298, 99);
            this.gbAffiliate.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAffiliate;
        private System.Windows.Forms.Button btnDeleteAffiliateID;
        private System.Windows.Forms.Button btnSaveAffiliateID;
        private NewMethod.nEdit_String ctl_affiliateID;
    }
}
