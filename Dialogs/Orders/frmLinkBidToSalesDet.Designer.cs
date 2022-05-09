namespace RzInterfaceWin.Dialogs
{
    partial class frmLinkBidToSalesDet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLinkBidToSalesDet));
            this.lv = new NewMethod.nList();
            this.SuspendLayout();
            // 
            // lv
            // 
            this.lv.AddCaption = "Link Selected Bid";
            this.lv.AllowActions = true;
            this.lv.AllowAdd = true;
            this.lv.AllowDelete = true;
            this.lv.AllowDeleteAlways = false;
            this.lv.AllowDrop = true;
            this.lv.AlternateConnection = null;
            this.lv.Caption = "";
            this.lv.CurrentTemplate = null;
            this.lv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv.ExtraClassInfo = "";
            this.lv.Location = new System.Drawing.Point(0, 0);
            this.lv.MultiSelect = true;
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(614, 307);
            this.lv.SuppressSelectionChanged = false;
            this.lv.TabIndex = 0;
            this.lv.zz_OpenColumnMenu = false;
            this.lv.zz_ShowAutoRefresh = true;
            this.lv.zz_ShowUnlimited = true;
            this.lv.AboutToThrow += new Core.ShowHandler(this.lv_AboutToThrow);
            this.lv.AboutToAdd += new NewMethod.AddHandler(this.lv_AboutToAdd);
            // 
            // frmLinkBidToSalesDet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 307);
            this.Controls.Add(this.lv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmLinkBidToSalesDet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Link Bid To Sale";
            this.ResumeLayout(false);

        }

        #endregion

        private NewMethod.nList lv;
    }
}