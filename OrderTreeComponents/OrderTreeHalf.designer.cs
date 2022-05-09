namespace Rz5
{
    partial class OrderTreeHalf
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
            if (disposing)
                InitUn();

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderTreeHalf));
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.tv = new System.Windows.Forms.TreeView();
            this.mnuTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddStock = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddService = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDuplicate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewCompany = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewContact = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuote = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddToSO = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddToFQSO = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAccept = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCreateAllPOs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAttachDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuoteStats = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrintAgent = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrintPurchasing = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ilSmall = new System.Windows.Forms.ImageList(this.components);
            this.cmdImportReverse = new System.Windows.Forms.Button();
            this.cmdImport = new System.Windows.Forms.Button();
            this.cmdNew = new System.Windows.Forms.Button();
            this.cmdQuote = new System.Windows.Forms.Button();
            this.cmdXL = new System.Windows.Forms.Button();
            this.cmdCreateSO = new System.Windows.Forms.Button();
            this.mnuTree.SuspendLayout();
            this.SuspendLayout();
            // 
            // il
            // 
            this.il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il.ImageStream")));
            this.il.TransparentColor = System.Drawing.Color.Magenta;
            this.il.Images.SetKeyName(0, "save24_h.bmp");
            this.il.Images.SetKeyName(1, "new_req");
            this.il.Images.SetKeyName(2, "new_bid");
            this.il.Images.SetKeyName(3, "req");
            this.il.Images.SetKeyName(4, "bid");
            this.il.Images.SetKeyName(5, "req_on_bid_import");
            this.il.Images.SetKeyName(6, "bid_import");
            this.il.Images.SetKeyName(7, "bid_on_req_import");
            this.il.Images.SetKeyName(8, "req_import");
            this.il.Images.SetKeyName(9, "quote_enabled.bmp");
            this.il.Images.SetKeyName(10, "excel");
            this.il.Images.SetKeyName(11, "sales");
            // 
            // tv
            // 
            this.tv.ContextMenuStrip = this.mnuTree;
            this.tv.ImageIndex = 0;
            this.tv.ImageList = this.ilSmall;
            this.tv.Location = new System.Drawing.Point(3, 0);
            this.tv.Name = "tv";
            this.tv.SelectedImageIndex = 0;
            this.tv.Size = new System.Drawing.Size(523, 489);
            this.tv.TabIndex = 6;
            this.tv.Click += new System.EventHandler(this.tv_Click);
            this.tv.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tv_MouseDown);
            // 
            // mnuTree
            // 
            this.mnuTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddDetail,
            this.mnuAddStock,
            this.mnuAddService,
            this.mnuDuplicate,
            this.mnuViewCompany,
            this.mnuViewContact,
            this.mnuShow,
            this.mnuQuote,
            this.mnuOrder,
            this.mnuAddToSO,
            this.mnuAddToFQSO,
            this.mnuAccept,
            this.mnuCreateAllPOs,
            this.mnuAttachDetail,
            this.mnuCut,
            this.mnuPaste,
            this.mnuQuoteStats,
            this.mnuPrint,
            this.toolStripSeparator1,
            this.mnuDelete});
            this.mnuTree.Name = "mnuTree";
            this.mnuTree.Size = new System.Drawing.Size(182, 450);
            this.mnuTree.Opening += new System.ComponentModel.CancelEventHandler(this.mnuTree_Opening);
            // 
            // mnuAddDetail
            // 
            this.mnuAddDetail.Name = "mnuAddDetail";
            this.mnuAddDetail.Size = new System.Drawing.Size(181, 22);
            this.mnuAddDetail.Text = "&Add Detail";
            this.mnuAddDetail.Click += new System.EventHandler(this.mnuAddDetail_Click);
            // 
            // mnuAddStock
            // 
            this.mnuAddStock.Name = "mnuAddStock";
            this.mnuAddStock.Size = new System.Drawing.Size(181, 22);
            this.mnuAddStock.Text = "Add Stock";
            this.mnuAddStock.Click += new System.EventHandler(this.mnuAddStock_Click);
            // 
            // mnuAddService
            // 
            this.mnuAddService.Name = "mnuAddService";
            this.mnuAddService.Size = new System.Drawing.Size(181, 22);
            this.mnuAddService.Text = "Add Service";
            this.mnuAddService.Click += new System.EventHandler(this.mnuAddService_Click);
            // 
            // mnuDuplicate
            // 
            this.mnuDuplicate.Name = "mnuDuplicate";
            this.mnuDuplicate.Size = new System.Drawing.Size(181, 22);
            this.mnuDuplicate.Text = "D&uplicate";
            this.mnuDuplicate.Click += new System.EventHandler(this.mnuDuplicate_Click);
            // 
            // mnuViewCompany
            // 
            this.mnuViewCompany.Name = "mnuViewCompany";
            this.mnuViewCompany.Size = new System.Drawing.Size(181, 22);
            this.mnuViewCompany.Text = "<view company>";
            this.mnuViewCompany.Click += new System.EventHandler(this.mnuViewCompany_Click);
            // 
            // mnuViewContact
            // 
            this.mnuViewContact.Name = "mnuViewContact";
            this.mnuViewContact.Size = new System.Drawing.Size(181, 22);
            this.mnuViewContact.Text = "<view contact>";
            this.mnuViewContact.Click += new System.EventHandler(this.mnuViewContact_Click);
            // 
            // mnuShow
            // 
            this.mnuShow.Name = "mnuShow";
            this.mnuShow.Size = new System.Drawing.Size(181, 22);
            this.mnuShow.Text = "Show/Hide";
            this.mnuShow.Click += new System.EventHandler(this.mnuShow_Click);
            // 
            // mnuQuote
            // 
            this.mnuQuote.Name = "mnuQuote";
            this.mnuQuote.Size = new System.Drawing.Size(181, 22);
            this.mnuQuote.Text = "Create A Quote";
            this.mnuQuote.Click += new System.EventHandler(this.mnuQuote_Click);
            // 
            // mnuOrder
            // 
            this.mnuOrder.Name = "mnuOrder";
            this.mnuOrder.Size = new System.Drawing.Size(181, 22);
            this.mnuOrder.Text = "Create A Sales Order";
            this.mnuOrder.Click += new System.EventHandler(this.mnuOrder_Click);
            // 
            // mnuAddToSO
            // 
            this.mnuAddToSO.Name = "mnuAddToSO";
            this.mnuAddToSO.Size = new System.Drawing.Size(181, 22);
            this.mnuAddToSO.Text = "Add to Sales Order";
            this.mnuAddToSO.Click += new System.EventHandler(this.mnuAddToSO_Click);
            // 
            // mnuAddToFQSO
            // 
            this.mnuAddToFQSO.Name = "mnuAddToFQSO";
            this.mnuAddToFQSO.Size = new System.Drawing.Size(181, 22);
            this.mnuAddToFQSO.Text = "Add To FQ/SO";
            this.mnuAddToFQSO.Visible = false;
            this.mnuAddToFQSO.Click += new System.EventHandler(this.mnuAddToFQSO_Click);
            // 
            // mnuAccept
            // 
            this.mnuAccept.Name = "mnuAccept";
            this.mnuAccept.Size = new System.Drawing.Size(181, 22);
            this.mnuAccept.Text = "Accept";
            this.mnuAccept.Click += new System.EventHandler(this.mnuAccept_Click);
            // 
            // mnuCreateAllPOs
            // 
            this.mnuCreateAllPOs.Name = "mnuCreateAllPOs";
            this.mnuCreateAllPOs.Size = new System.Drawing.Size(181, 22);
            this.mnuCreateAllPOs.Text = "Create All POs";
            this.mnuCreateAllPOs.Click += new System.EventHandler(this.mnuCreateAllPOs_Click);
            // 
            // mnuAttachDetail
            // 
            this.mnuAttachDetail.Name = "mnuAttachDetail";
            this.mnuAttachDetail.Size = new System.Drawing.Size(181, 22);
            this.mnuAttachDetail.Text = "Attach Detail";
            this.mnuAttachDetail.Click += new System.EventHandler(this.mnuAttachDetail_Click);
            // 
            // mnuCut
            // 
            this.mnuCut.Name = "mnuCut";
            this.mnuCut.Size = new System.Drawing.Size(181, 22);
            this.mnuCut.Text = "Cut";
            this.mnuCut.Click += new System.EventHandler(this.mnuCut_Click);
            // 
            // mnuPaste
            // 
            this.mnuPaste.Name = "mnuPaste";
            this.mnuPaste.Size = new System.Drawing.Size(181, 22);
            this.mnuPaste.Text = "Paste";
            this.mnuPaste.Click += new System.EventHandler(this.mnuPaste_Click);
            // 
            // mnuQuoteStats
            // 
            this.mnuQuoteStats.Name = "mnuQuoteStats";
            this.mnuQuoteStats.Size = new System.Drawing.Size(181, 22);
            this.mnuQuoteStats.Text = "View Quote Stats";
            this.mnuQuoteStats.Visible = false;
            this.mnuQuoteStats.Click += new System.EventHandler(this.mnuQuoteStats_Click);
            // 
            // mnuPrint
            // 
            this.mnuPrint.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPrintAgent,
            this.mnuPrintPurchasing});
            this.mnuPrint.Name = "mnuPrint";
            this.mnuPrint.Size = new System.Drawing.Size(181, 22);
            this.mnuPrint.Text = "Print";
            // 
            // mnuPrintAgent
            // 
            this.mnuPrintAgent.Name = "mnuPrintAgent";
            this.mnuPrintAgent.Size = new System.Drawing.Size(181, 22);
            this.mnuPrintAgent.Text = "Print For Agent";
            this.mnuPrintAgent.Click += new System.EventHandler(this.mnuPrintAgent_Click);
            // 
            // mnuPrintPurchasing
            // 
            this.mnuPrintPurchasing.Name = "mnuPrintPurchasing";
            this.mnuPrintPurchasing.Size = new System.Drawing.Size(181, 22);
            this.mnuPrintPurchasing.Text = "Print For Purchasing";
            this.mnuPrintPurchasing.Click += new System.EventHandler(this.mnuPrintPurchasing_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(181, 22);
            this.mnuDelete.Text = "&Delete";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // ilSmall
            // 
            this.ilSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilSmall.ImageStream")));
            this.ilSmall.TransparentColor = System.Drawing.Color.Fuchsia;
            this.ilSmall.Images.SetKeyName(0, "quote_enabled");
            this.ilSmall.Images.SetKeyName(1, "req_enabled");
            this.ilSmall.Images.SetKeyName(2, "person");
            this.ilSmall.Images.SetKeyName(3, "quote_disabled");
            this.ilSmall.Images.SetKeyName(4, "req_disabled");
            this.ilSmall.Images.SetKeyName(5, "people");
            this.ilSmall.Images.SetKeyName(6, "bid_enabled");
            this.ilSmall.Images.SetKeyName(7, "rfq_disabled");
            this.ilSmall.Images.SetKeyName(8, "rfq_enabled");
            this.ilSmall.Images.SetKeyName(9, "bid_disabled");
            this.ilSmall.Images.SetKeyName(10, "bid_enabled_accepted");
            this.ilSmall.Images.SetKeyName(11, "stock");
            this.ilSmall.Images.SetKeyName(12, "service_person");
            this.ilSmall.Images.SetKeyName(13, "service");
            this.ilSmall.Images.SetKeyName(14, "bid_canceled");
            // 
            // cmdImportReverse
            // 
            this.cmdImportReverse.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdImportReverse.ImageKey = "new_req";
            this.cmdImportReverse.ImageList = this.il;
            this.cmdImportReverse.Location = new System.Drawing.Point(455, 294);
            this.cmdImportReverse.Name = "cmdImportReverse";
            this.cmdImportReverse.Size = new System.Drawing.Size(71, 60);
            this.cmdImportReverse.TabIndex = 9;
            this.cmdImportReverse.Text = "Import Bids On Reqs";
            this.cmdImportReverse.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdImportReverse.UseVisualStyleBackColor = true;
            this.cmdImportReverse.Visible = false;
            // 
            // cmdImport
            // 
            this.cmdImport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdImport.ImageKey = "new_req";
            this.cmdImport.ImageList = this.il;
            this.cmdImport.Location = new System.Drawing.Point(455, 56);
            this.cmdImport.Name = "cmdImport";
            this.cmdImport.Size = new System.Drawing.Size(71, 60);
            this.cmdImport.TabIndex = 8;
            this.cmdImport.Text = "Import Reqs";
            this.cmdImport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdImport.UseVisualStyleBackColor = true;
            this.cmdImport.Click += new System.EventHandler(this.cmdImport_Click);
            // 
            // cmdNew
            // 
            this.cmdNew.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdNew.ImageKey = "new_req";
            this.cmdNew.ImageList = this.il;
            this.cmdNew.Location = new System.Drawing.Point(455, 2);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(71, 48);
            this.cmdNew.TabIndex = 7;
            this.cmdNew.Text = "New Req";
            this.cmdNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdNew.UseVisualStyleBackColor = true;
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // cmdQuote
            // 
            this.cmdQuote.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdQuote.ImageKey = "quote_enabled.bmp";
            this.cmdQuote.ImageList = this.il;
            this.cmdQuote.Location = new System.Drawing.Point(455, 122);
            this.cmdQuote.Name = "cmdQuote";
            this.cmdQuote.Size = new System.Drawing.Size(71, 47);
            this.cmdQuote.TabIndex = 10;
            this.cmdQuote.Text = "Quote";
            this.cmdQuote.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdQuote.UseVisualStyleBackColor = true;
            this.cmdQuote.Visible = false;
            this.cmdQuote.Click += new System.EventHandler(this.cmdQuote_Click);
            // 
            // cmdXL
            // 
            this.cmdXL.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdXL.ImageKey = "excel";
            this.cmdXL.ImageList = this.il;
            this.cmdXL.Location = new System.Drawing.Point(455, 228);
            this.cmdXL.Name = "cmdXL";
            this.cmdXL.Size = new System.Drawing.Size(71, 60);
            this.cmdXL.TabIndex = 11;
            this.cmdXL.Text = "Export To Excel";
            this.cmdXL.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdXL.UseVisualStyleBackColor = true;
            this.cmdXL.Click += new System.EventHandler(this.cmdXL_Click);
            // 
            // cmdCreateSO
            // 
            this.cmdCreateSO.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdCreateSO.ImageKey = "sales";
            this.cmdCreateSO.ImageList = this.il;
            this.cmdCreateSO.Location = new System.Drawing.Point(455, 175);
            this.cmdCreateSO.Name = "cmdCreateSO";
            this.cmdCreateSO.Size = new System.Drawing.Size(71, 47);
            this.cmdCreateSO.TabIndex = 12;
            this.cmdCreateSO.Text = "Sales Order";
            this.cmdCreateSO.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdCreateSO.UseVisualStyleBackColor = true;
            this.cmdCreateSO.Visible = false;
            this.cmdCreateSO.Click += new System.EventHandler(this.cmdCreateSO_Click);
            // 
            // OrderTreeHalf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdCreateSO);
            this.Controls.Add(this.cmdXL);
            this.Controls.Add(this.cmdQuote);
            this.Controls.Add(this.cmdImport);
            this.Controls.Add(this.cmdImportReverse);
            this.Controls.Add(this.cmdNew);
            this.Controls.Add(this.tv);
            this.Name = "OrderTreeHalf";
            this.Size = new System.Drawing.Size(542, 504);
            this.Resize += new System.EventHandler(this.OrderTreeHalf_Resize);
            this.mnuTree.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList il;
        private System.Windows.Forms.ImageList ilSmall;
        protected System.Windows.Forms.Button cmdNew;
        protected System.Windows.Forms.TreeView tv;
        protected System.Windows.Forms.Button cmdImport;
        protected System.Windows.Forms.Button cmdImportReverse;
        protected System.Windows.Forms.Button cmdQuote;
        protected System.Windows.Forms.Button cmdXL;
        protected System.Windows.Forms.ContextMenuStrip mnuTree;
        protected System.Windows.Forms.ToolStripMenuItem mnuAddDetail;
        protected System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        protected System.Windows.Forms.ToolStripMenuItem mnuDelete;
        protected System.Windows.Forms.ToolStripMenuItem mnuViewCompany;
        protected System.Windows.Forms.ToolStripMenuItem mnuViewContact;
        protected System.Windows.Forms.ToolStripMenuItem mnuShow;
        protected System.Windows.Forms.ToolStripMenuItem mnuQuote;
        protected System.Windows.Forms.ToolStripMenuItem mnuAccept;
        protected System.Windows.Forms.ToolStripMenuItem mnuOrder;
        protected System.Windows.Forms.ToolStripMenuItem mnuAddStock;
        protected System.Windows.Forms.ToolStripMenuItem mnuAddService;
        protected System.Windows.Forms.ToolStripMenuItem mnuCreateAllPOs;
        protected System.Windows.Forms.ToolStripMenuItem mnuAttachDetail;
        protected System.Windows.Forms.ToolStripMenuItem mnuCut;
        protected System.Windows.Forms.ToolStripMenuItem mnuPaste;
        protected System.Windows.Forms.ToolStripMenuItem mnuDuplicate;
        protected System.Windows.Forms.Button cmdCreateSO;
        protected System.Windows.Forms.ToolStripMenuItem mnuAddToSO;
        protected System.Windows.Forms.ToolStripMenuItem mnuQuoteStats;
        public System.Windows.Forms.ToolStripMenuItem mnuPrint;
        public System.Windows.Forms.ToolStripMenuItem mnuPrintAgent;
        public System.Windows.Forms.ToolStripMenuItem mnuPrintPurchasing;
        protected System.Windows.Forms.ToolStripMenuItem mnuAddToFQSO;
    }
}
