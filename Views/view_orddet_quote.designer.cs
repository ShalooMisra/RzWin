namespace Rz5
{
    partial class view_orddet_quote
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(view_orddet_quote));
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.oth = new OrderTreeComponents.OrderTreeHalfBid();
            this.dl = new DealList();
            this.lstBids = new NewMethod.nList();
            this.SuspendLayout();
            // 
            // xActions
            // 
            this.xActions.Location = new System.Drawing.Point(813, 0);
            this.xActions.Size = new System.Drawing.Size(192, 759);
            // 
            // il
            // 
            this.il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il.ImageStream")));
            this.il.TransparentColor = System.Drawing.Color.Magenta;
            this.il.Images.SetKeyName(0, "quote");
            this.il.Images.SetKeyName(1, "rfq");
            this.il.Images.SetKeyName(2, "service");
            this.il.Images.SetKeyName(3, "stock");
            this.il.Images.SetKeyName(4, "req");
            // 
            // oth
            // 
            this.oth.Location = new System.Drawing.Point(32, 468);
            this.oth.Name = "oth";
            this.oth.Size = new System.Drawing.Size(743, 89);
            this.oth.TabIndex = 38;
            this.oth.ObjectClicked += new OrderTreeObjectClickHandler(this.oth_ObjectClicked);
            // 
            // dl
            // 
            this.dl.BackColor = System.Drawing.Color.White;
            this.dl.Location = new System.Drawing.Point(30, 578);
            this.dl.Name = "dl";
            this.dl.Size = new System.Drawing.Size(742, 160);
            this.dl.TabIndex = 40;
            this.dl.ReloadRequest += new System.EventHandler(this.dl_ReloadRequest);
            this.dl.MakePO += new BidLineEventHandler(this.dl_MakePO);
            this.dl.SavedObject += new System.EventHandler(this.dl_SavedObject);
            this.dl.GotResize += new System.EventHandler(this.dl_GotResize);
            // 
            // lstBids
            // 
            this.lstBids.AddCaption = "Add New";
            this.lstBids.AllowActions = true;
            this.lstBids.AllowAdd = false;
            this.lstBids.AllowDelete = true;
            this.lstBids.AllowDeleteAlways = false;
            this.lstBids.AllowDrop = true;
            this.lstBids.AlternateConnection = null;
            this.lstBids.Caption = "Bids";
            this.lstBids.CurrentTemplate = null;
            this.lstBids.ExtraClassInfo = "";
            this.lstBids.Location = new System.Drawing.Point(30, 358);
            this.lstBids.MultiSelect = true;
            this.lstBids.Name = "lstBids";
            this.lstBids.Size = new System.Drawing.Size(739, 104);
            this.lstBids.SuppressSelectionChanged = false;
            this.lstBids.TabIndex = 41;
            this.lstBids.zz_OpenColumnMenu = false;
            this.lstBids.zz_ShowAutoRefresh = true;
            this.lstBids.zz_ShowUnlimited = true;
            this.lstBids.AboutToThrow += new Core.ShowHandler(this.lstBids_AboutToThrow);
            // 
            // view_orddet_quote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lstBids);
            this.Controls.Add(this.dl);
            this.Controls.Add(this.oth);
            this.Name = "view_orddet_quote";
            this.Size = new System.Drawing.Size(1005, 759);
            this.Controls.SetChildIndex(this.oth, 0);
            this.Controls.SetChildIndex(this.dl, 0);
            this.Controls.SetChildIndex(this.lstBids, 0);
            this.Controls.SetChildIndex(this.xActions, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList il;
        private DealList dl;
        protected OrderTreeComponents.OrderTreeHalfBid oth;
        protected NewMethod.nList lstBids;

    }
}
