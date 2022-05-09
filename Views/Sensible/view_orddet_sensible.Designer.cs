namespace RzSensible
{
    partial class view_orddet_sensible
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
            this.ctl_rohs_info = new NewMethod.nEdit_List();
            this.lnkBidFromBatch = new System.Windows.Forms.LinkLabel();
            this.gb.SuspendLayout();
            this.tabBids.SuspendLayout();
            this.pageInfo.SuspendLayout();
            this.ts.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb
            // 
            this.gb.Controls.Add(this.lnkBidFromBatch);
            this.gb.Controls.SetChildIndex(this.cStub, 0);
            this.gb.Controls.SetChildIndex(this.buyer, 0);
            this.gb.Controls.SetChildIndex(this.ctl_unitcost, 0);
            this.gb.Controls.SetChildIndex(this.cmdQuotes, 0);
            this.gb.Controls.SetChildIndex(this.lblOriginalVendor, 0);
            this.gb.Controls.SetChildIndex(this.lblChooseVendorContact, 0);
            this.gb.Controls.SetChildIndex(this.ctl_vendorcontactname, 0);
            this.gb.Controls.SetChildIndex(this.lblChooseVendor, 0);
            this.gb.Controls.SetChildIndex(this.lnkBidFromBatch, 0);
            // 
            // cStub
            // 
            this.cStub.Size = new System.Drawing.Size(256, 56);
            // 
            // ctl_vendorcontactname
            // 
            this.ctl_vendorcontactname.zz_Enabled = true;
            // 
            // pageInfo
            // 
            this.pageInfo.Controls.Add(this.ctl_rohs_info);
            this.pageInfo.Controls.SetChildIndex(this.ctl_fullpartnumber, 0);
            this.pageInfo.Controls.SetChildIndex(this.ctl_manufacturer, 0);
            this.pageInfo.Controls.SetChildIndex(this.ctl_internalpartnumber, 0);
            this.pageInfo.Controls.SetChildIndex(this.ctl_description, 0);
            this.pageInfo.Controls.SetChildIndex(this.gb, 0);
            this.pageInfo.Controls.SetChildIndex(this.ctl_rohs_info, 0);
            // 
            // ctl_rohs_info
            // 
            this.ctl_rohs_info.AllCaps = false;
            this.ctl_rohs_info.AllowEdit = true;
            this.ctl_rohs_info.BackColor = System.Drawing.Color.Transparent;
            this.ctl_rohs_info.Bold = false;
            this.ctl_rohs_info.Caption = "RoHS";
            this.ctl_rohs_info.Changed = false;
            this.ctl_rohs_info.ListName = "rohs_info";
            this.ctl_rohs_info.Location = new System.Drawing.Point(391, 22);
            this.ctl_rohs_info.Name = "ctl_rohs_info";
            this.ctl_rohs_info.SimpleList = null;
            this.ctl_rohs_info.Size = new System.Drawing.Size(99, 22);
            this.ctl_rohs_info.TabIndex = 99;
            this.ctl_rohs_info.UseParentBackColor = false;
            this.ctl_rohs_info.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_rohs_info.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_rohs_info.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_rohs_info.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_rohs_info.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.Left;
            this.ctl_rohs_info.zz_OriginalDesign = false;
            this.ctl_rohs_info.zz_ShowNeedsSaveColor = true;
            this.ctl_rohs_info.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_rohs_info.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_rohs_info.zz_UseGlobalColor = false;
            this.ctl_rohs_info.zz_UseGlobalFont = false;
            // 
            // lnkBidFromBatch
            // 
            this.lnkBidFromBatch.AutoSize = true;
            this.lnkBidFromBatch.Location = new System.Drawing.Point(249, 16);
            this.lnkBidFromBatch.Name = "lnkBidFromBatch";
            this.lnkBidFromBatch.Size = new System.Drawing.Size(124, 13);
            this.lnkBidFromBatch.TabIndex = 36;
            this.lnkBidFromBatch.TabStop = true;
            this.lnkBidFromBatch.Text = "<choose bid from batch>";
            this.lnkBidFromBatch.Visible = false;
            this.lnkBidFromBatch.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBidFromBatch_LinkClicked);
            // 
            // view_orddet_sensible
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "view_orddet_sensible";
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.tabBids.ResumeLayout(false);
            this.pageInfo.ResumeLayout(false);
            this.pageInfo.PerformLayout();
            this.ts.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private NewMethod.nEdit_List ctl_rohs_info;
        private System.Windows.Forms.LinkLabel lnkBidFromBatch;
    }
}
