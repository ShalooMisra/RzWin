namespace Rz5
{
    partial class OrderTree
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
                CompleteDispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderTree));
            this.ctlName = new NewMethod.nEdit_String();
            this.spOrders = new System.Windows.Forms.SplitContainer();
            this.spReqs = new System.Windows.Forms.SplitContainer();
            this.spReqsQuotes = new System.Windows.Forms.SplitContainer();
            this.nList1 = new NewMethod.nList();
            this.lvReqs = new NewMethod.nList();
            this.mnuReq = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuSetSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSetUnSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUnSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewBid = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddStockBid = new System.Windows.Forms.ToolStripMenuItem();
            this.addGCATServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddToFQSO = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewQuoteStats = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRemoveQuote = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lvQuotes = new NewMethod.nList();
            this.cmdCreateSO = new System.Windows.Forms.Button();
            this.imButtons = new System.Windows.Forms.ImageList(this.components);
            this.cmdXL = new System.Windows.Forms.Button();
            this.cmdQuote = new System.Windows.Forms.Button();
            this.cmdImportReqs = new System.Windows.Forms.Button();
            this.cmdNewReq = new System.Windows.Forms.Button();
            this.spBids = new System.Windows.Forms.SplitContainer();
            this.lvBids = new NewMethod.nList();
            this.mnuBid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAcceptBid = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRemoveBid = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdNewStockBid = new System.Windows.Forms.Button();
            this.cmdNewBid = new System.Windows.Forms.Button();
            this.IM24 = new System.Windows.Forms.ImageList(this.components);
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.pLinks = new System.Windows.Forms.Panel();
            this.lnkAttachments = new System.Windows.Forms.LinkLabel();
            this.lblCompleteDelete = new System.Windows.Forms.LinkLabel();
            this.lnkPartReport = new System.Windows.Forms.LinkLabel();
            this.lblDeal = new System.Windows.Forms.LinkLabel();
            this.lblLinks = new System.Windows.Forms.LinkLabel();
            this.lblSearch = new System.Windows.Forms.LinkLabel();
            this.lnkUpdateStats = new System.Windows.Forms.LinkLabel();
            this.ctlNotes = new NewMethod.nEdit_Memo();
            this.ctlApproved = new NewMethod.nEdit_Boolean();
            this.cmdNote = new System.Windows.Forms.Button();
            this.cmdClip = new System.Windows.Forms.Button();
            this.cmdSaveAndExit = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.bgw = new System.ComponentModel.BackgroundWorker();
            this.throbber = new NewMethod.nThrobber();
            this.flOrders = new System.Windows.Forms.FlowLayoutPanel();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.lblFinancials = new System.Windows.Forms.Label();
            this.chkIsSourced = new NewMethod.nEdit_Boolean();
            this.lblProblemCustomer = new System.Windows.Forms.Label();
            this.lblOutstandingInvoiceAmnt = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ctl_oem_product_name = new System.Windows.Forms.ComboBox();
            this.ctl_oem_product_qty = new NewMethod.nEdit_Number();
            this.ctl_is_oem_product = new NewMethod.nEdit_Boolean();
            this.gbHubspot = new System.Windows.Forms.GroupBox();
            this.llEditHubspotDeal = new System.Windows.Forms.LinkLabel();
            this.llblDealLink = new System.Windows.Forms.LinkLabel();
            this.btnCreateHubspotBatch = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblAgent = new System.Windows.Forms.LinkLabel();
            this.gbOpportunityStage = new System.Windows.Forms.GroupBox();
            this.lblOppStage = new System.Windows.Forms.Label();
            this.ctl_isLost = new NewMethod.nEdit_Boolean();
            this.ctl_is_bom = new NewMethod.nEdit_Boolean();
            this.gbSplitAgent = new System.Windows.Forms.GroupBox();
            this.llSplitAgent = new System.Windows.Forms.LinkLabel();
            this.CompList = new Rz5.CompanyStub_PlusContact();
            this.dl = new Rz5.DealList();
            ((System.ComponentModel.ISupportInitialize)(this.spOrders)).BeginInit();
            this.spOrders.Panel1.SuspendLayout();
            this.spOrders.Panel2.SuspendLayout();
            this.spOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spReqs)).BeginInit();
            this.spReqs.Panel1.SuspendLayout();
            this.spReqs.Panel2.SuspendLayout();
            this.spReqs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spReqsQuotes)).BeginInit();
            this.spReqsQuotes.Panel1.SuspendLayout();
            this.spReqsQuotes.Panel2.SuspendLayout();
            this.spReqsQuotes.SuspendLayout();
            this.mnuReq.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spBids)).BeginInit();
            this.spBids.Panel1.SuspendLayout();
            this.spBids.Panel2.SuspendLayout();
            this.spBids.SuspendLayout();
            this.mnuBid.SuspendLayout();
            this.pLinks.SuspendLayout();
            this.flOrders.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbHubspot.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbOpportunityStage.SuspendLayout();
            this.gbSplitAgent.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctlName
            // 
            this.ctlName.AllCaps = false;
            this.ctlName.BackColor = System.Drawing.Color.White;
            this.ctlName.Bold = false;
            this.ctlName.Caption = "Batch Name";
            this.ctlName.Changed = false;
            this.ctlName.IsEmail = false;
            this.ctlName.IsURL = false;
            this.ctlName.Location = new System.Drawing.Point(4, 10);
            this.ctlName.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctlName.Name = "ctlName";
            this.ctlName.PasswordChar = '\0';
            this.ctlName.Size = new System.Drawing.Size(453, 21);
            this.ctlName.TabIndex = 1;
            this.ctlName.UseParentBackColor = true;
            this.ctlName.zz_Enabled = true;
            this.ctlName.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlName.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlName.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlName.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlName.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.Left;
            this.ctlName.zz_OriginalDesign = false;
            this.ctlName.zz_ShowLinkButton = false;
            this.ctlName.zz_ShowNeedsSaveColor = true;
            this.ctlName.zz_Text = "";
            this.ctlName.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlName.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlName.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlName.zz_UseGlobalColor = false;
            this.ctlName.zz_UseGlobalFont = false;
            // 
            // spOrders
            // 
            this.spOrders.BackColor = System.Drawing.Color.Navy;
            this.spOrders.Location = new System.Drawing.Point(4, 4);
            this.spOrders.Margin = new System.Windows.Forms.Padding(4);
            this.spOrders.Name = "spOrders";
            this.spOrders.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spOrders.Panel1
            // 
            this.spOrders.Panel1.Controls.Add(this.spReqs);
            // 
            // spOrders.Panel2
            // 
            this.spOrders.Panel2.Controls.Add(this.spBids);
            this.spOrders.Size = new System.Drawing.Size(1406, 559);
            this.spOrders.SplitterDistance = 406;
            this.spOrders.SplitterWidth = 5;
            this.spOrders.TabIndex = 7;
            this.spOrders.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.spOrders_SplitterMoved);
            // 
            // spReqs
            // 
            this.spReqs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spReqs.IsSplitterFixed = true;
            this.spReqs.Location = new System.Drawing.Point(0, 0);
            this.spReqs.Margin = new System.Windows.Forms.Padding(4);
            this.spReqs.Name = "spReqs";
            // 
            // spReqs.Panel1
            // 
            this.spReqs.Panel1.Controls.Add(this.spReqsQuotes);
            // 
            // spReqs.Panel2
            // 
            this.spReqs.Panel2.BackColor = System.Drawing.Color.White;
            this.spReqs.Panel2.Controls.Add(this.cmdCreateSO);
            this.spReqs.Panel2.Controls.Add(this.cmdXL);
            this.spReqs.Panel2.Controls.Add(this.cmdQuote);
            this.spReqs.Panel2.Controls.Add(this.cmdImportReqs);
            this.spReqs.Panel2.Controls.Add(this.cmdNewReq);
            this.spReqs.Size = new System.Drawing.Size(1406, 406);
            this.spReqs.SplitterDistance = 1294;
            this.spReqs.SplitterWidth = 5;
            this.spReqs.TabIndex = 1;
            // 
            // spReqsQuotes
            // 
            this.spReqsQuotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spReqsQuotes.Location = new System.Drawing.Point(0, 0);
            this.spReqsQuotes.Margin = new System.Windows.Forms.Padding(4);
            this.spReqsQuotes.Name = "spReqsQuotes";
            this.spReqsQuotes.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spReqsQuotes.Panel1
            // 
            this.spReqsQuotes.Panel1.Controls.Add(this.nList1);
            this.spReqsQuotes.Panel1.Controls.Add(this.lvReqs);
            // 
            // spReqsQuotes.Panel2
            // 
            this.spReqsQuotes.Panel2.Controls.Add(this.lvQuotes);
            this.spReqsQuotes.Size = new System.Drawing.Size(1294, 406);
            this.spReqsQuotes.SplitterDistance = 206;
            this.spReqsQuotes.SplitterWidth = 5;
            this.spReqsQuotes.TabIndex = 1;
            // 
            // nList1
            // 
            this.nList1.AddCaption = "Add New";
            this.nList1.AllowActions = true;
            this.nList1.AllowAdd = false;
            this.nList1.AllowDelete = true;
            this.nList1.AllowDeleteAlways = false;
            this.nList1.AllowDrop = true;
            this.nList1.AllowOnlyOpenDelete = false;
            this.nList1.AlternateConnection = null;
            this.nList1.BackColor = System.Drawing.Color.White;
            this.nList1.Caption = "";
            this.nList1.CurrentTemplate = null;
            this.nList1.ExtraClassInfo = "";
            this.nList1.Location = new System.Drawing.Point(92, 123);
            this.nList1.MultiSelect = true;
            this.nList1.Name = "nList1";
            this.nList1.Size = new System.Drawing.Size(8, 8);
            this.nList1.SuppressSelectionChanged = false;
            this.nList1.TabIndex = 1;
            this.nList1.zz_OpenColumnMenu = false;
            this.nList1.zz_OrderLineType = "";
            this.nList1.zz_ShowAutoRefresh = true;
            this.nList1.zz_ShowUnlimited = true;
            // 
            // lvReqs
            // 
            this.lvReqs.AddCaption = "Add New";
            this.lvReqs.AllowActions = false;
            this.lvReqs.AllowAdd = false;
            this.lvReqs.AllowDelete = true;
            this.lvReqs.AllowDeleteAlways = false;
            this.lvReqs.AllowDrop = true;
            this.lvReqs.AllowOnlyOpenDelete = false;
            this.lvReqs.AlternateConnection = null;
            this.lvReqs.BackColor = System.Drawing.Color.White;
            this.lvReqs.Caption = "";
            this.lvReqs.ContextMenuStrip = this.mnuReq;
            this.lvReqs.CurrentTemplate = null;
            this.lvReqs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvReqs.ExtraClassInfo = "";
            this.lvReqs.Location = new System.Drawing.Point(0, 0);
            this.lvReqs.Margin = new System.Windows.Forms.Padding(5);
            this.lvReqs.MultiSelect = true;
            this.lvReqs.Name = "lvReqs";
            this.lvReqs.Size = new System.Drawing.Size(1294, 206);
            this.lvReqs.SuppressSelectionChanged = false;
            this.lvReqs.TabIndex = 0;
            this.lvReqs.zz_OpenColumnMenu = false;
            this.lvReqs.zz_OrderLineType = "";
            this.lvReqs.zz_ShowAutoRefresh = true;
            this.lvReqs.zz_ShowUnlimited = true;
            this.lvReqs.AboutToThrow += new Core.ShowHandler(this.lvReqs_AboutToThrow);
            this.lvReqs.ObjectClicked += new NewMethod.ObjectClickHandler(this.lvReqs_ObjectClicked);
            this.lvReqs.AboutToAction += new NewMethod.ActionHandler(this.lvReqs_AboutToAction);
            // 
            // mnuReq
            // 
            this.mnuReq.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSetSelected,
            this.mnuSetUnSelected,
            this.mnuSelectAll,
            this.mnuUnSelectAll,
            this.mnuNewBid,
            this.mnuAddStockBid,
            this.addGCATServiceToolStripMenuItem,
            this.mnuAddToFQSO,
            this.mnuViewQuoteStats,
            this.toolStripSeparator1,
            this.mnuRemoveQuote,
            this.toolStripMenuItem1});
            this.mnuReq.Name = "mnuReq";
            this.mnuReq.Size = new System.Drawing.Size(190, 252);
            this.mnuReq.Opening += new System.ComponentModel.CancelEventHandler(this.mnuReq_Opening);
            // 
            // mnuSetSelected
            // 
            this.mnuSetSelected.Name = "mnuSetSelected";
            this.mnuSetSelected.Size = new System.Drawing.Size(189, 22);
            this.mnuSetSelected.Text = "Set To Selected";
            this.mnuSetSelected.Visible = false;
            this.mnuSetSelected.Click += new System.EventHandler(this.mnuSetSelected_Click);
            // 
            // mnuSetUnSelected
            // 
            this.mnuSetUnSelected.Name = "mnuSetUnSelected";
            this.mnuSetUnSelected.Size = new System.Drawing.Size(189, 22);
            this.mnuSetUnSelected.Text = "Set To UnSelected";
            this.mnuSetUnSelected.Visible = false;
            this.mnuSetUnSelected.Click += new System.EventHandler(this.mnuSetUnSelected_Click);
            // 
            // mnuSelectAll
            // 
            this.mnuSelectAll.Name = "mnuSelectAll";
            this.mnuSelectAll.Size = new System.Drawing.Size(189, 22);
            this.mnuSelectAll.Text = "Select All";
            this.mnuSelectAll.Click += new System.EventHandler(this.mnuSelectAll_Click);
            // 
            // mnuUnSelectAll
            // 
            this.mnuUnSelectAll.Name = "mnuUnSelectAll";
            this.mnuUnSelectAll.Size = new System.Drawing.Size(189, 22);
            this.mnuUnSelectAll.Text = "UnSelect All";
            this.mnuUnSelectAll.Click += new System.EventHandler(this.mnuUnSelectAll_Click);
            // 
            // mnuNewBid
            // 
            this.mnuNewBid.Name = "mnuNewBid";
            this.mnuNewBid.Size = new System.Drawing.Size(189, 22);
            this.mnuNewBid.Text = "Vendor Bid";
            this.mnuNewBid.Click += new System.EventHandler(this.mnuNewBid_Click);
            // 
            // mnuAddStockBid
            // 
            this.mnuAddStockBid.Name = "mnuAddStockBid";
            this.mnuAddStockBid.Size = new System.Drawing.Size(189, 22);
            this.mnuAddStockBid.Text = "Inventory / Excess Bid";
            this.mnuAddStockBid.Click += new System.EventHandler(this.mnuAddStockBid_Click);
            // 
            // addGCATServiceToolStripMenuItem
            // 
            this.addGCATServiceToolStripMenuItem.Name = "addGCATServiceToolStripMenuItem";
            this.addGCATServiceToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.addGCATServiceToolStripMenuItem.Text = "Add GCAT Service";
            this.addGCATServiceToolStripMenuItem.Click += new System.EventHandler(this.addGCATServiceToolStripMenuItem_Click);
            // 
            // mnuAddToFQSO
            // 
            this.mnuAddToFQSO.Name = "mnuAddToFQSO";
            this.mnuAddToFQSO.Size = new System.Drawing.Size(189, 22);
            this.mnuAddToFQSO.Text = "Add To FQ/SO";
            this.mnuAddToFQSO.Visible = false;
            this.mnuAddToFQSO.Click += new System.EventHandler(this.mnuAddToFQSO_Click);
            // 
            // mnuViewQuoteStats
            // 
            this.mnuViewQuoteStats.Name = "mnuViewQuoteStats";
            this.mnuViewQuoteStats.Size = new System.Drawing.Size(189, 22);
            this.mnuViewQuoteStats.Text = "View Quote Stats";
            this.mnuViewQuoteStats.Click += new System.EventHandler(this.mnuViewQuoteStats_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(186, 6);
            // 
            // mnuRemoveQuote
            // 
            this.mnuRemoveQuote.Name = "mnuRemoveQuote";
            this.mnuRemoveQuote.Size = new System.Drawing.Size(189, 22);
            this.mnuRemoveQuote.Text = "Remove this line";
            this.mnuRemoveQuote.Click += new System.EventHandler(this.mnuRemoveQuote_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(189, 22);
            this.toolStripMenuItem1.Text = "Create Quote";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.mnuCreateQuote_Click);
            // 
            // lvQuotes
            // 
            this.lvQuotes.AddCaption = "Add New";
            this.lvQuotes.AllowActions = false;
            this.lvQuotes.AllowAdd = false;
            this.lvQuotes.AllowDelete = true;
            this.lvQuotes.AllowDeleteAlways = false;
            this.lvQuotes.AllowDrop = true;
            this.lvQuotes.AllowOnlyOpenDelete = false;
            this.lvQuotes.AlternateConnection = null;
            this.lvQuotes.BackColor = System.Drawing.Color.White;
            this.lvQuotes.Caption = "";
            this.lvQuotes.ContextMenuStrip = this.mnuReq;
            this.lvQuotes.CurrentTemplate = null;
            this.lvQuotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvQuotes.ExtraClassInfo = "";
            this.lvQuotes.Location = new System.Drawing.Point(0, 0);
            this.lvQuotes.Margin = new System.Windows.Forms.Padding(5);
            this.lvQuotes.MultiSelect = true;
            this.lvQuotes.Name = "lvQuotes";
            this.lvQuotes.Size = new System.Drawing.Size(1294, 195);
            this.lvQuotes.SuppressSelectionChanged = false;
            this.lvQuotes.TabIndex = 1;
            this.lvQuotes.zz_OpenColumnMenu = false;
            this.lvQuotes.zz_OrderLineType = "";
            this.lvQuotes.zz_ShowAutoRefresh = true;
            this.lvQuotes.zz_ShowUnlimited = true;
            this.lvQuotes.AboutToThrow += new Core.ShowHandler(this.lvQuotes_AboutToThrow);
            this.lvQuotes.ObjectClicked += new NewMethod.ObjectClickHandler(this.lvQuotes_ObjectClicked);
            this.lvQuotes.FinishedFill += new NewMethod.FillHandler(this.lvQuotes_FinishedFill);
            // 
            // cmdCreateSO
            // 
            this.cmdCreateSO.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdCreateSO.ImageKey = "sales";
            this.cmdCreateSO.ImageList = this.imButtons;
            this.cmdCreateSO.Location = new System.Drawing.Point(5, 217);
            this.cmdCreateSO.Margin = new System.Windows.Forms.Padding(4);
            this.cmdCreateSO.Name = "cmdCreateSO";
            this.cmdCreateSO.Size = new System.Drawing.Size(95, 58);
            this.cmdCreateSO.TabIndex = 17;
            this.cmdCreateSO.Text = "Sales Order";
            this.cmdCreateSO.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdCreateSO.UseVisualStyleBackColor = true;
            this.cmdCreateSO.Visible = false;
            this.cmdCreateSO.Click += new System.EventHandler(this.cmdCreateSO_Click);
            // 
            // imButtons
            // 
            this.imButtons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imButtons.ImageStream")));
            this.imButtons.TransparentColor = System.Drawing.Color.Magenta;
            this.imButtons.Images.SetKeyName(0, "");
            this.imButtons.Images.SetKeyName(1, "new_req");
            this.imButtons.Images.SetKeyName(2, "new_bid");
            this.imButtons.Images.SetKeyName(3, "");
            this.imButtons.Images.SetKeyName(4, "");
            this.imButtons.Images.SetKeyName(5, "");
            this.imButtons.Images.SetKeyName(6, "");
            this.imButtons.Images.SetKeyName(7, "");
            this.imButtons.Images.SetKeyName(8, "");
            this.imButtons.Images.SetKeyName(9, "quote_enabled.bmp");
            this.imButtons.Images.SetKeyName(10, "excel");
            this.imButtons.Images.SetKeyName(11, "");
            this.imButtons.Images.SetKeyName(12, "stock");
            // 
            // cmdXL
            // 
            this.cmdXL.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdXL.ImageKey = "excel";
            this.cmdXL.ImageList = this.imButtons;
            this.cmdXL.Location = new System.Drawing.Point(5, 282);
            this.cmdXL.Margin = new System.Windows.Forms.Padding(4);
            this.cmdXL.Name = "cmdXL";
            this.cmdXL.Size = new System.Drawing.Size(95, 74);
            this.cmdXL.TabIndex = 16;
            this.cmdXL.Text = "Export To Excel";
            this.cmdXL.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdXL.UseVisualStyleBackColor = true;
            this.cmdXL.Click += new System.EventHandler(this.cmdXL_Click);
            // 
            // cmdQuote
            // 
            this.cmdQuote.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdQuote.ImageKey = "quote_enabled.bmp";
            this.cmdQuote.ImageList = this.imButtons;
            this.cmdQuote.Location = new System.Drawing.Point(5, 151);
            this.cmdQuote.Margin = new System.Windows.Forms.Padding(4);
            this.cmdQuote.Name = "cmdQuote";
            this.cmdQuote.Size = new System.Drawing.Size(95, 58);
            this.cmdQuote.TabIndex = 15;
            this.cmdQuote.Text = "Quote";
            this.cmdQuote.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdQuote.UseVisualStyleBackColor = true;
            this.cmdQuote.Click += new System.EventHandler(this.cmdQuote_Click);
            // 
            // cmdImportReqs
            // 
            this.cmdImportReqs.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdImportReqs.ImageKey = "new_req";
            this.cmdImportReqs.ImageList = this.imButtons;
            this.cmdImportReqs.Location = new System.Drawing.Point(5, 70);
            this.cmdImportReqs.Margin = new System.Windows.Forms.Padding(4);
            this.cmdImportReqs.Name = "cmdImportReqs";
            this.cmdImportReqs.Size = new System.Drawing.Size(95, 74);
            this.cmdImportReqs.TabIndex = 14;
            this.cmdImportReqs.Text = "Import Reqs";
            this.cmdImportReqs.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdImportReqs.UseVisualStyleBackColor = true;
            this.cmdImportReqs.Click += new System.EventHandler(this.cmdImportReqs_Click);
            // 
            // cmdNewReq
            // 
            this.cmdNewReq.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdNewReq.ImageKey = "new_req";
            this.cmdNewReq.ImageList = this.imButtons;
            this.cmdNewReq.Location = new System.Drawing.Point(5, 4);
            this.cmdNewReq.Margin = new System.Windows.Forms.Padding(4);
            this.cmdNewReq.Name = "cmdNewReq";
            this.cmdNewReq.Size = new System.Drawing.Size(95, 59);
            this.cmdNewReq.TabIndex = 13;
            this.cmdNewReq.Text = "New Req";
            this.cmdNewReq.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdNewReq.UseVisualStyleBackColor = true;
            this.cmdNewReq.Click += new System.EventHandler(this.cmdNewReq_Click);
            // 
            // spBids
            // 
            this.spBids.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spBids.IsSplitterFixed = true;
            this.spBids.Location = new System.Drawing.Point(0, 0);
            this.spBids.Margin = new System.Windows.Forms.Padding(4);
            this.spBids.Name = "spBids";
            // 
            // spBids.Panel1
            // 
            this.spBids.Panel1.Controls.Add(this.lvBids);
            // 
            // spBids.Panel2
            // 
            this.spBids.Panel2.BackColor = System.Drawing.Color.White;
            this.spBids.Panel2.Controls.Add(this.cmdNewStockBid);
            this.spBids.Panel2.Controls.Add(this.cmdNewBid);
            this.spBids.Size = new System.Drawing.Size(1406, 148);
            this.spBids.SplitterDistance = 1295;
            this.spBids.SplitterWidth = 5;
            this.spBids.TabIndex = 0;
            // 
            // lvBids
            // 
            this.lvBids.AddCaption = "Add New";
            this.lvBids.AllowActions = false;
            this.lvBids.AllowAdd = false;
            this.lvBids.AllowDelete = true;
            this.lvBids.AllowDeleteAlways = false;
            this.lvBids.AllowDrop = true;
            this.lvBids.AllowOnlyOpenDelete = false;
            this.lvBids.AlternateConnection = null;
            this.lvBids.BackColor = System.Drawing.Color.White;
            this.lvBids.Caption = "";
            this.lvBids.ContextMenuStrip = this.mnuBid;
            this.lvBids.CurrentTemplate = null;
            this.lvBids.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvBids.ExtraClassInfo = "";
            this.lvBids.Location = new System.Drawing.Point(0, 0);
            this.lvBids.Margin = new System.Windows.Forms.Padding(5);
            this.lvBids.MultiSelect = true;
            this.lvBids.Name = "lvBids";
            this.lvBids.Size = new System.Drawing.Size(1295, 148);
            this.lvBids.SuppressSelectionChanged = false;
            this.lvBids.TabIndex = 0;
            this.lvBids.zz_OpenColumnMenu = false;
            this.lvBids.zz_OrderLineType = "";
            this.lvBids.zz_ShowAutoRefresh = true;
            this.lvBids.zz_ShowUnlimited = true;
            this.lvBids.AboutToThrow += new Core.ShowHandler(this.lvBids_AboutToThrow);
            // 
            // mnuBid
            // 
            this.mnuBid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAcceptBid,
            this.toolStripSeparator2,
            this.mnuRemoveBid});
            this.mnuBid.Name = "mnuReq";
            this.mnuBid.Size = new System.Drawing.Size(180, 54);
            // 
            // mnuAcceptBid
            // 
            this.mnuAcceptBid.Name = "mnuAcceptBid";
            this.mnuAcceptBid.Size = new System.Drawing.Size(179, 22);
            this.mnuAcceptBid.Text = "Accept / Un-Accept";
            this.mnuAcceptBid.Click += new System.EventHandler(this.mnuAcceptBid_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(176, 6);
            // 
            // mnuRemoveBid
            // 
            this.mnuRemoveBid.Name = "mnuRemoveBid";
            this.mnuRemoveBid.Size = new System.Drawing.Size(179, 22);
            this.mnuRemoveBid.Text = "Remove this link";
            this.mnuRemoveBid.Click += new System.EventHandler(this.mnuRemoveBid_Click);
            // 
            // cmdNewStockBid
            // 
            this.cmdNewStockBid.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdNewStockBid.ImageKey = "stock";
            this.cmdNewStockBid.ImageList = this.imButtons;
            this.cmdNewStockBid.Location = new System.Drawing.Point(4, 70);
            this.cmdNewStockBid.Margin = new System.Windows.Forms.Padding(4);
            this.cmdNewStockBid.Name = "cmdNewStockBid";
            this.cmdNewStockBid.Size = new System.Drawing.Size(95, 74);
            this.cmdNewStockBid.TabIndex = 10;
            this.cmdNewStockBid.Text = "Inventory / Excess Bid";
            this.cmdNewStockBid.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdNewStockBid.UseVisualStyleBackColor = true;
            this.cmdNewStockBid.Click += new System.EventHandler(this.cmdNewStockBid_Click);
            // 
            // cmdNewBid
            // 
            this.cmdNewBid.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdNewBid.ImageKey = "new_bid";
            this.cmdNewBid.ImageList = this.imButtons;
            this.cmdNewBid.Location = new System.Drawing.Point(4, 4);
            this.cmdNewBid.Margin = new System.Windows.Forms.Padding(4);
            this.cmdNewBid.Name = "cmdNewBid";
            this.cmdNewBid.Size = new System.Drawing.Size(95, 59);
            this.cmdNewBid.TabIndex = 9;
            this.cmdNewBid.Text = "Vendor Bid";
            this.cmdNewBid.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdNewBid.UseVisualStyleBackColor = true;
            this.cmdNewBid.Click += new System.EventHandler(this.cmdNewBid_Click);
            // 
            // IM24
            // 
            this.IM24.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IM24.ImageStream")));
            this.IM24.TransparentColor = System.Drawing.Color.Fuchsia;
            this.IM24.Images.SetKeyName(0, "Clip");
            this.IM24.Images.SetKeyName(1, "Note");
            this.IM24.Images.SetKeyName(2, "Save");
            this.IM24.Images.SetKeyName(3, "Delete");
            this.IM24.Images.SetKeyName(4, "SaveExit");
            this.IM24.Images.SetKeyName(5, "import");
            this.IM24.Images.SetKeyName(6, "req_on_bid_import");
            this.IM24.Images.SetKeyName(7, "bid_import");
            this.IM24.Images.SetKeyName(8, "bid_on_req_import");
            this.IM24.Images.SetKeyName(9, "req_import");
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
            // pLinks
            // 
            this.pLinks.Controls.Add(this.lnkAttachments);
            this.pLinks.Controls.Add(this.lblCompleteDelete);
            this.pLinks.Controls.Add(this.lnkPartReport);
            this.pLinks.Controls.Add(this.lblDeal);
            this.pLinks.Controls.Add(this.lblLinks);
            this.pLinks.Controls.Add(this.lblSearch);
            this.pLinks.Controls.Add(this.lnkUpdateStats);
            this.pLinks.Location = new System.Drawing.Point(1286, 57);
            this.pLinks.Margin = new System.Windows.Forms.Padding(4);
            this.pLinks.Name = "pLinks";
            this.pLinks.Size = new System.Drawing.Size(157, 102);
            this.pLinks.TabIndex = 8;
            // 
            // lnkAttachments
            // 
            this.lnkAttachments.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkAttachments.Location = new System.Drawing.Point(4, 39);
            this.lnkAttachments.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkAttachments.Name = "lnkAttachments";
            this.lnkAttachments.Size = new System.Drawing.Size(131, 20);
            this.lnkAttachments.TabIndex = 4;
            this.lnkAttachments.TabStop = true;
            this.lnkAttachments.Text = "attachments >";
            this.lnkAttachments.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAttachments_LinkClicked);
            // 
            // lblCompleteDelete
            // 
            this.lblCompleteDelete.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompleteDelete.Location = new System.Drawing.Point(5, 87);
            this.lblCompleteDelete.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCompleteDelete.Name = "lblCompleteDelete";
            this.lblCompleteDelete.Size = new System.Drawing.Size(153, 20);
            this.lblCompleteDelete.TabIndex = 3;
            this.lblCompleteDelete.TabStop = true;
            this.lblCompleteDelete.Text = "complete delete >";
            this.lblCompleteDelete.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblCompleteDelete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCompleteDelete_LinkClicked);
            // 
            // lnkPartReport
            // 
            this.lnkPartReport.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkPartReport.Location = new System.Drawing.Point(4, 19);
            this.lnkPartReport.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkPartReport.Name = "lnkPartReport";
            this.lnkPartReport.Size = new System.Drawing.Size(117, 20);
            this.lnkPartReport.TabIndex = 2;
            this.lnkPartReport.TabStop = true;
            this.lnkPartReport.Text = "part report >";
            this.lnkPartReport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPartReport_LinkClicked);
            // 
            // lblDeal
            // 
            this.lblDeal.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeal.Location = new System.Drawing.Point(114, 26);
            this.lblDeal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDeal.Name = "lblDeal";
            this.lblDeal.Size = new System.Drawing.Size(44, 20);
            this.lblDeal.TabIndex = 1;
            this.lblDeal.TabStop = true;
            this.lblDeal.Text = "deal >";
            this.lblDeal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblDeal.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblDeal_LinkClicked);
            // 
            // lblLinks
            // 
            this.lblLinks.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLinks.Location = new System.Drawing.Point(114, 4);
            this.lblLinks.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLinks.Name = "lblLinks";
            this.lblLinks.Size = new System.Drawing.Size(44, 20);
            this.lblLinks.TabIndex = 0;
            this.lblLinks.TabStop = true;
            this.lblLinks.Text = "map >";
            this.lblLinks.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblLinks.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLinks_LinkClicked);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(4, 4);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(109, 15);
            this.lblSearch.TabIndex = 18;
            this.lblSearch.TabStop = true;
            this.lblSearch.Text = "find a part number";
            this.lblSearch.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSearch_LinkClicked);
            // 
            // lnkUpdateStats
            // 
            this.lnkUpdateStats.AutoSize = true;
            this.lnkUpdateStats.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkUpdateStats.Location = new System.Drawing.Point(4, 58);
            this.lnkUpdateStats.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkUpdateStats.Name = "lnkUpdateStats";
            this.lnkUpdateStats.Size = new System.Drawing.Size(122, 15);
            this.lnkUpdateStats.TabIndex = 20;
            this.lnkUpdateStats.TabStop = true;
            this.lnkUpdateStats.Text = "show quote statistics";
            this.lnkUpdateStats.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUpdateStats_LinkClicked);
            // 
            // ctlNotes
            // 
            this.ctlNotes.BackColor = System.Drawing.Color.White;
            this.ctlNotes.Bold = false;
            this.ctlNotes.Caption = "Notes";
            this.ctlNotes.Changed = false;
            this.ctlNotes.DateLines = false;
            this.ctlNotes.Location = new System.Drawing.Point(465, 43);
            this.ctlNotes.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctlNotes.Name = "ctlNotes";
            this.ctlNotes.Size = new System.Drawing.Size(415, 107);
            this.ctlNotes.TabIndex = 13;
            this.ctlNotes.UseParentBackColor = true;
            this.ctlNotes.zz_Enabled = true;
            this.ctlNotes.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlNotes.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlNotes.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlNotes.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNotes.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.Left;
            this.ctlNotes.zz_OriginalDesign = false;
            this.ctlNotes.zz_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ctlNotes.zz_ShowNeedsSaveColor = true;
            this.ctlNotes.zz_Text = "";
            this.ctlNotes.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNotes.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNotes.zz_UseGlobalColor = false;
            this.ctlNotes.zz_UseGlobalFont = false;
            // 
            // ctlApproved
            // 
            this.ctlApproved.BackColor = System.Drawing.Color.White;
            this.ctlApproved.Bold = false;
            this.ctlApproved.Caption = "Approved";
            this.ctlApproved.Changed = false;
            this.ctlApproved.Location = new System.Drawing.Point(890, 58);
            this.ctlApproved.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctlApproved.Name = "ctlApproved";
            this.ctlApproved.Size = new System.Drawing.Size(72, 18);
            this.ctlApproved.TabIndex = 14;
            this.ctlApproved.UseParentBackColor = false;
            this.ctlApproved.zz_CheckValue = false;
            this.ctlApproved.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlApproved.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlApproved.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctlApproved.zz_OriginalDesign = false;
            this.ctlApproved.zz_ShowNeedsSaveColor = true;
            this.ctlApproved.CheckChanged += new NewMethod.CheckChangedHandler(this.ctlApproved_CheckChanged);
            // 
            // cmdNote
            // 
            this.cmdNote.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdNote.ImageKey = "Note";
            this.cmdNote.ImageList = this.IM24;
            this.cmdNote.Location = new System.Drawing.Point(696, 4);
            this.cmdNote.Margin = new System.Windows.Forms.Padding(4);
            this.cmdNote.Name = "cmdNote";
            this.cmdNote.Size = new System.Drawing.Size(88, 39);
            this.cmdNote.TabIndex = 12;
            this.cmdNote.Text = "Note";
            this.cmdNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdNote.UseVisualStyleBackColor = true;
            this.cmdNote.Click += new System.EventHandler(this.cmdNote_Click);
            // 
            // cmdClip
            // 
            this.cmdClip.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClip.ImageKey = "Clip";
            this.cmdClip.ImageList = this.IM24;
            this.cmdClip.Location = new System.Drawing.Point(792, 4);
            this.cmdClip.Margin = new System.Windows.Forms.Padding(4);
            this.cmdClip.Name = "cmdClip";
            this.cmdClip.Size = new System.Drawing.Size(88, 39);
            this.cmdClip.TabIndex = 11;
            this.cmdClip.Text = "Clip";
            this.cmdClip.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdClip.UseVisualStyleBackColor = true;
            this.cmdClip.Click += new System.EventHandler(this.cmdClip_Click);
            // 
            // cmdSaveAndExit
            // 
            this.cmdSaveAndExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSaveAndExit.ImageKey = "SaveExit";
            this.cmdSaveAndExit.ImageList = this.IM24;
            this.cmdSaveAndExit.Location = new System.Drawing.Point(561, 4);
            this.cmdSaveAndExit.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSaveAndExit.Name = "cmdSaveAndExit";
            this.cmdSaveAndExit.Size = new System.Drawing.Size(127, 39);
            this.cmdSaveAndExit.TabIndex = 10;
            this.cmdSaveAndExit.Text = "Save & Exit";
            this.cmdSaveAndExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSaveAndExit.UseMnemonic = false;
            this.cmdSaveAndExit.UseVisualStyleBackColor = true;
            this.cmdSaveAndExit.Click += new System.EventHandler(this.cmdSaveAndExit_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.ImageKey = "Save";
            this.cmdSave.ImageList = this.IM24;
            this.cmdSave.Location = new System.Drawing.Point(465, 4);
            this.cmdSave.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(88, 39);
            this.cmdSave.TabIndex = 6;
            this.cmdSave.Text = "Save";
            this.cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // bgw
            // 
            this.bgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            this.bgw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted);
            // 
            // throbber
            // 
            this.throbber.BackColor = System.Drawing.Color.White;
            this.throbber.Location = new System.Drawing.Point(895, 122);
            this.throbber.Margin = new System.Windows.Forms.Padding(5);
            this.throbber.Name = "throbber";
            this.throbber.Size = new System.Drawing.Size(40, 33);
            this.throbber.TabIndex = 21;
            this.throbber.UseParentBackColor = false;
            // 
            // flOrders
            // 
            this.flOrders.AutoScroll = true;
            this.flOrders.Controls.Add(this.spOrders);
            this.flOrders.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flOrders.Location = new System.Drawing.Point(8, 158);
            this.flOrders.Margin = new System.Windows.Forms.Padding(4);
            this.flOrders.Name = "flOrders";
            this.flOrders.Size = new System.Drawing.Size(1435, 559);
            this.flOrders.TabIndex = 22;
            this.flOrders.WrapContents = false;
            // 
            // tmr
            // 
            this.tmr.Interval = 750;
            this.tmr.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // lblFinancials
            // 
            this.lblFinancials.BackColor = System.Drawing.Color.Red;
            this.lblFinancials.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFinancials.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinancials.ForeColor = System.Drawing.Color.White;
            this.lblFinancials.Location = new System.Drawing.Point(247, 32);
            this.lblFinancials.Name = "lblFinancials";
            this.lblFinancials.Size = new System.Drawing.Size(109, 20);
            this.lblFinancials.TabIndex = 52;
            this.lblFinancials.Text = "Need Financials";
            this.lblFinancials.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblFinancials.Visible = false;
            // 
            // chkIsSourced
            // 
            this.chkIsSourced.BackColor = System.Drawing.Color.White;
            this.chkIsSourced.Bold = false;
            this.chkIsSourced.Caption = "Sourced";
            this.chkIsSourced.Changed = false;
            this.chkIsSourced.Location = new System.Drawing.Point(967, 58);
            this.chkIsSourced.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.chkIsSourced.Name = "chkIsSourced";
            this.chkIsSourced.Size = new System.Drawing.Size(66, 18);
            this.chkIsSourced.TabIndex = 54;
            this.chkIsSourced.UseParentBackColor = false;
            this.chkIsSourced.zz_CheckValue = false;
            this.chkIsSourced.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.chkIsSourced.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.chkIsSourced.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.chkIsSourced.zz_OriginalDesign = false;
            this.chkIsSourced.zz_ShowNeedsSaveColor = true;
            this.chkIsSourced.CheckChanged += new NewMethod.CheckChangedHandler(this.chkIsSourced_CheckChanged);
            // 
            // lblProblemCustomer
            // 
            this.lblProblemCustomer.AutoSize = true;
            this.lblProblemCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProblemCustomer.ForeColor = System.Drawing.Color.Red;
            this.lblProblemCustomer.Location = new System.Drawing.Point(101, 33);
            this.lblProblemCustomer.Name = "lblProblemCustomer";
            this.lblProblemCustomer.Size = new System.Drawing.Size(140, 17);
            this.lblProblemCustomer.TabIndex = 56;
            this.lblProblemCustomer.Text = "Problem Customer";
            this.lblProblemCustomer.Visible = false;
            // 
            // lblOutstandingInvoiceAmnt
            // 
            this.lblOutstandingInvoiceAmnt.AutoSize = true;
            this.lblOutstandingInvoiceAmnt.BackColor = System.Drawing.Color.Yellow;
            this.lblOutstandingInvoiceAmnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutstandingInvoiceAmnt.ForeColor = System.Drawing.Color.Red;
            this.lblOutstandingInvoiceAmnt.Location = new System.Drawing.Point(247, 57);
            this.lblOutstandingInvoiceAmnt.Name = "lblOutstandingInvoiceAmnt";
            this.lblOutstandingInvoiceAmnt.Size = new System.Drawing.Size(61, 17);
            this.lblOutstandingInvoiceAmnt.TabIndex = 62;
            this.lblOutstandingInvoiceAmnt.Text = "<label>";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ctl_oem_product_name);
            this.groupBox1.Controls.Add(this.ctl_oem_product_qty);
            this.groupBox1.Controls.Add(this.ctl_is_oem_product);
            this.groupBox1.Location = new System.Drawing.Point(250, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 73);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "OEM Product";
            // 
            // ctl_oem_product_name
            // 
            this.ctl_oem_product_name.FormattingEnabled = true;
            this.ctl_oem_product_name.Location = new System.Drawing.Point(6, 46);
            this.ctl_oem_product_name.Name = "ctl_oem_product_name";
            this.ctl_oem_product_name.Size = new System.Drawing.Size(188, 21);
            this.ctl_oem_product_name.TabIndex = 69;
            this.ctl_oem_product_name.Visible = false;
            // 
            // ctl_oem_product_qty
            // 
            this.ctl_oem_product_qty.BackColor = System.Drawing.Color.Transparent;
            this.ctl_oem_product_qty.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ctl_oem_product_qty.Bold = false;
            this.ctl_oem_product_qty.Caption = "QTY:";
            this.ctl_oem_product_qty.Changed = false;
            this.ctl_oem_product_qty.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_oem_product_qty.Location = new System.Drawing.Point(111, 10);
            this.ctl_oem_product_qty.Name = "ctl_oem_product_qty";
            this.ctl_oem_product_qty.Size = new System.Drawing.Size(83, 35);
            this.ctl_oem_product_qty.TabIndex = 68;
            this.ctl_oem_product_qty.UseParentBackColor = false;
            this.ctl_oem_product_qty.Visible = false;
            this.ctl_oem_product_qty.zz_Enabled = true;
            this.ctl_oem_product_qty.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_oem_product_qty.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_oem_product_qty.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_oem_product_qty.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_oem_product_qty.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_oem_product_qty.zz_OriginalDesign = false;
            this.ctl_oem_product_qty.zz_ShowErrorColor = true;
            this.ctl_oem_product_qty.zz_ShowNeedsSaveColor = true;
            this.ctl_oem_product_qty.zz_Text = "";
            this.ctl_oem_product_qty.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_oem_product_qty.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_oem_product_qty.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_oem_product_qty.zz_UseGlobalColor = false;
            this.ctl_oem_product_qty.zz_UseGlobalFont = false;
            // 
            // ctl_is_oem_product
            // 
            this.ctl_is_oem_product.BackColor = System.Drawing.Color.White;
            this.ctl_is_oem_product.Bold = false;
            this.ctl_is_oem_product.Caption = "OEM Product?";
            this.ctl_is_oem_product.Changed = false;
            this.ctl_is_oem_product.Location = new System.Drawing.Point(5, 22);
            this.ctl_is_oem_product.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_is_oem_product.Name = "ctl_is_oem_product";
            this.ctl_is_oem_product.Size = new System.Drawing.Size(96, 18);
            this.ctl_is_oem_product.TabIndex = 64;
            this.ctl_is_oem_product.UseParentBackColor = false;
            this.ctl_is_oem_product.zz_CheckValue = false;
            this.ctl_is_oem_product.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_is_oem_product.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_is_oem_product.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_is_oem_product.zz_OriginalDesign = false;
            this.ctl_is_oem_product.zz_ShowNeedsSaveColor = true;
            this.ctl_is_oem_product.CheckChanged += new NewMethod.CheckChangedHandler(this.ctl_is_oem_product_CheckChanged);
            // 
            // gbHubspot
            // 
            this.gbHubspot.Controls.Add(this.llEditHubspotDeal);
            this.gbHubspot.Controls.Add(this.llblDealLink);
            this.gbHubspot.Controls.Add(this.btnCreateHubspotBatch);
            this.gbHubspot.Location = new System.Drawing.Point(890, 81);
            this.gbHubspot.Name = "gbHubspot";
            this.gbHubspot.Size = new System.Drawing.Size(132, 69);
            this.gbHubspot.TabIndex = 69;
            this.gbHubspot.TabStop = false;
            this.gbHubspot.Text = "HubSpot Deal";
            // 
            // llEditHubspotDeal
            // 
            this.llEditHubspotDeal.AutoSize = true;
            this.llEditHubspotDeal.Location = new System.Drawing.Point(52, 41);
            this.llEditHubspotDeal.Name = "llEditHubspotDeal";
            this.llEditHubspotDeal.Size = new System.Drawing.Size(36, 13);
            this.llEditHubspotDeal.TabIndex = 76;
            this.llEditHubspotDeal.TabStop = true;
            this.llEditHubspotDeal.Text = "<edit>";
            this.llEditHubspotDeal.UseWaitCursor = true;
            this.llEditHubspotDeal.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llEditHubspotDeal_LinkClicked);
            // 
            // llblDealLink
            // 
            this.llblDealLink.AutoSize = true;
            this.llblDealLink.Location = new System.Drawing.Point(51, 21);
            this.llblDealLink.Name = "llblDealLink";
            this.llblDealLink.Size = new System.Drawing.Size(51, 13);
            this.llblDealLink.TabIndex = 75;
            this.llblDealLink.TabStop = true;
            this.llblDealLink.Text = "<not set>";
            this.llblDealLink.UseWaitCursor = true;
            this.llblDealLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblDealLink_LinkClicked);
            // 
            // btnCreateHubspotBatch
            // 
            this.btnCreateHubspotBatch.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.btnCreateHubspotBatch.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateHubspotBatch.Image")));
            this.btnCreateHubspotBatch.Location = new System.Drawing.Point(8, 17);
            this.btnCreateHubspotBatch.Name = "btnCreateHubspotBatch";
            this.btnCreateHubspotBatch.Size = new System.Drawing.Size(40, 40);
            this.btnCreateHubspotBatch.TabIndex = 72;
            this.btnCreateHubspotBatch.UseVisualStyleBackColor = true;
            this.btnCreateHubspotBatch.UseWaitCursor = true;
            this.btnCreateHubspotBatch.Click += new System.EventHandler(this.btnCreateHubspotBatch_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblAgent);
            this.groupBox3.Location = new System.Drawing.Point(887, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(156, 35);
            this.groupBox3.TabIndex = 72;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Batch Agent";
            // 
            // lblAgent
            // 
            this.lblAgent.AutoSize = true;
            this.lblAgent.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgent.Location = new System.Drawing.Point(7, 16);
            this.lblAgent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAgent.Name = "lblAgent";
            this.lblAgent.Size = new System.Drawing.Size(71, 15);
            this.lblAgent.TabIndex = 17;
            this.lblAgent.TabStop = true;
            this.lblAgent.Text = "<Choose ...>";
            this.lblAgent.Click += new System.EventHandler(this.lblAgent_Click);
            // 
            // gbOpportunityStage
            // 
            this.gbOpportunityStage.Controls.Add(this.lblOppStage);
            this.gbOpportunityStage.Controls.Add(this.ctl_isLost);
            this.gbOpportunityStage.Location = new System.Drawing.Point(1028, 99);
            this.gbOpportunityStage.Name = "gbOpportunityStage";
            this.gbOpportunityStage.Size = new System.Drawing.Size(251, 51);
            this.gbOpportunityStage.TabIndex = 74;
            this.gbOpportunityStage.TabStop = false;
            this.gbOpportunityStage.Text = "Opportunity Stage:";
            // 
            // lblOppStage
            // 
            this.lblOppStage.AutoSize = true;
            this.lblOppStage.Location = new System.Drawing.Point(79, 23);
            this.lblOppStage.Name = "lblOppStage";
            this.lblOppStage.Size = new System.Drawing.Size(66, 13);
            this.lblOppStage.TabIndex = 69;
            this.lblOppStage.Text = "<opp stage>";
            // 
            // ctl_isLost
            // 
            this.ctl_isLost.BackColor = System.Drawing.Color.Transparent;
            this.ctl_isLost.Bold = false;
            this.ctl_isLost.Caption = "Lost";
            this.ctl_isLost.Changed = false;
            this.ctl_isLost.Location = new System.Drawing.Point(14, 19);
            this.ctl_isLost.Name = "ctl_isLost";
            this.ctl_isLost.Size = new System.Drawing.Size(46, 18);
            this.ctl_isLost.TabIndex = 68;
            this.ctl_isLost.UseParentBackColor = false;
            this.ctl_isLost.zz_CheckValue = false;
            this.ctl_isLost.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_isLost.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_isLost.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Left;
            this.ctl_isLost.zz_OriginalDesign = false;
            this.ctl_isLost.zz_ShowNeedsSaveColor = true;
            this.ctl_isLost.CheckChanged += new NewMethod.CheckChangedHandler(this.ctl_isLost_CheckChanged);
            // 
            // ctl_is_bom
            // 
            this.ctl_is_bom.BackColor = System.Drawing.Color.White;
            this.ctl_is_bom.Bold = false;
            this.ctl_is_bom.Caption = "Is BOM";
            this.ctl_is_bom.Changed = false;
            this.ctl_is_bom.Location = new System.Drawing.Point(1042, 58);
            this.ctl_is_bom.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_is_bom.Name = "ctl_is_bom";
            this.ctl_is_bom.Size = new System.Drawing.Size(61, 18);
            this.ctl_is_bom.TabIndex = 76;
            this.ctl_is_bom.UseParentBackColor = false;
            this.ctl_is_bom.zz_CheckValue = false;
            this.ctl_is_bom.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_is_bom.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_is_bom.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_is_bom.zz_OriginalDesign = false;
            this.ctl_is_bom.zz_ShowNeedsSaveColor = true;
            // 
            // gbSplitAgent
            // 
            this.gbSplitAgent.Controls.Add(this.llSplitAgent);
            this.gbSplitAgent.Location = new System.Drawing.Point(1049, 8);
            this.gbSplitAgent.Name = "gbSplitAgent";
            this.gbSplitAgent.Size = new System.Drawing.Size(156, 35);
            this.gbSplitAgent.TabIndex = 75;
            this.gbSplitAgent.TabStop = false;
            this.gbSplitAgent.Text = "Split Agent";
            // 
            // llSplitAgent
            // 
            this.llSplitAgent.AutoSize = true;
            this.llSplitAgent.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llSplitAgent.Location = new System.Drawing.Point(7, 16);
            this.llSplitAgent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llSplitAgent.Name = "llSplitAgent";
            this.llSplitAgent.Size = new System.Drawing.Size(71, 15);
            this.llSplitAgent.TabIndex = 17;
            this.llSplitAgent.TabStop = true;
            this.llSplitAgent.Text = "<Choose ...>";
            this.llSplitAgent.Click += new System.EventHandler(this.llSplitAgent_Click);
            // 
            // CompList
            // 
            this.CompList.BackColor = System.Drawing.Color.White;
            this.CompList.Caption = "Customer";
            this.CompList.Location = new System.Drawing.Point(3, 43);
            this.CompList.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.CompList.Name = "CompList";
            this.CompList.Size = new System.Drawing.Size(278, 107);
            this.CompList.TabIndex = 19;
            this.CompList.ContactChangeFinished += new Rz5.ContactEventHandler(this.CompList_ContactChangeFinished);
            this.CompList.CompanyChangeFinished += new Rz5.ContactEventHandler(this.CompList_CompanyChangeFinished);
            // 
            // dl
            // 
            this.dl.BackColor = System.Drawing.Color.LightGray;
            this.dl.Location = new System.Drawing.Point(8, 743);
            this.dl.Margin = new System.Windows.Forms.Padding(5);
            this.dl.Name = "dl";
            this.dl.Size = new System.Drawing.Size(273, 47);
            this.dl.TabIndex = 15;
            this.dl.MakePO += new Rz5.BidLineEventHandler(this.dl_MakePO);
            this.dl.GotResize += new System.EventHandler(this.dl_GotResize);
            // 
            // OrderTree
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ctl_is_bom);
            this.Controls.Add(this.gbSplitAgent);
            this.Controls.Add(this.gbOpportunityStage);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gbHubspot);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblOutstandingInvoiceAmnt);
            this.Controls.Add(this.lblProblemCustomer);
            this.Controls.Add(this.chkIsSourced);
            this.Controls.Add(this.lblFinancials);
            this.Controls.Add(this.flOrders);
            this.Controls.Add(this.throbber);
            this.Controls.Add(this.CompList);
            this.Controls.Add(this.dl);
            this.Controls.Add(this.ctlApproved);
            this.Controls.Add(this.ctlNotes);
            this.Controls.Add(this.cmdNote);
            this.Controls.Add(this.cmdClip);
            this.Controls.Add(this.cmdSaveAndExit);
            this.Controls.Add(this.pLinks);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.ctlName);
            this.Margin = new System.Windows.Forms.Padding(0, 7, 0, 7);
            this.Name = "OrderTree";
            this.Size = new System.Drawing.Size(1539, 799);
            this.Resize += new System.EventHandler(this.OrderTree_Resize);
            this.spOrders.Panel1.ResumeLayout(false);
            this.spOrders.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spOrders)).EndInit();
            this.spOrders.ResumeLayout(false);
            this.spReqs.Panel1.ResumeLayout(false);
            this.spReqs.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spReqs)).EndInit();
            this.spReqs.ResumeLayout(false);
            this.spReqsQuotes.Panel1.ResumeLayout(false);
            this.spReqsQuotes.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spReqsQuotes)).EndInit();
            this.spReqsQuotes.ResumeLayout(false);
            this.mnuReq.ResumeLayout(false);
            this.spBids.Panel1.ResumeLayout(false);
            this.spBids.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spBids)).EndInit();
            this.spBids.ResumeLayout(false);
            this.mnuBid.ResumeLayout(false);
            this.pLinks.ResumeLayout(false);
            this.pLinks.PerformLayout();
            this.flOrders.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.gbHubspot.ResumeLayout(false);
            this.gbHubspot.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbOpportunityStage.ResumeLayout(false);
            this.gbOpportunityStage.PerformLayout();
            this.gbSplitAgent.ResumeLayout(false);
            this.gbSplitAgent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList il;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.LinkLabel lblDeal;
        private System.Windows.Forms.LinkLabel lblLinks;
        private System.Windows.Forms.Button cmdSaveAndExit;
        private System.Windows.Forms.ImageList IM24;
        private System.Windows.Forms.Button cmdClip;
        private System.Windows.Forms.Button cmdNote;
        private NewMethod.nEdit_Memo ctlNotes;
        private NewMethod.nEdit_Boolean ctlApproved;
        private DealList dl;
        private System.Windows.Forms.LinkLabel lnkPartReport;
        private System.Windows.Forms.LinkLabel lblSearch;
        private System.Windows.Forms.LinkLabel lblCompleteDelete;
        private System.ComponentModel.BackgroundWorker bgw;
        private System.Windows.Forms.LinkLabel lnkUpdateStats;
        public NewMethod.nEdit_String ctlName;
        private System.Windows.Forms.LinkLabel lnkAttachments;
        protected System.Windows.Forms.Panel pLinks;
        protected System.Windows.Forms.SplitContainer spOrders;
        protected System.Windows.Forms.Button cmdNewStockBid;
        protected System.Windows.Forms.Button cmdNewBid;
        private System.Windows.Forms.ImageList imButtons;
        protected NewMethod.nList lvBids;
        protected System.Windows.Forms.SplitContainer spBids;
        protected System.Windows.Forms.SplitContainer spReqs;
        protected NewMethod.nList lvReqs;
        protected System.Windows.Forms.Button cmdCreateSO;
        protected System.Windows.Forms.Button cmdXL;
        protected System.Windows.Forms.Button cmdQuote;
        protected System.Windows.Forms.Button cmdImportReqs;
        protected System.Windows.Forms.Button cmdNewReq;
        protected System.Windows.Forms.SplitContainer spReqsQuotes;
        protected NewMethod.nList lvQuotes;
        protected System.Windows.Forms.FlowLayoutPanel flOrders;
        private System.Windows.Forms.ContextMenuStrip mnuReq;
        private System.Windows.Forms.ToolStripMenuItem mnuNewBid;
        private System.Windows.Forms.ToolStripMenuItem mnuAddStockBid;
        private System.Windows.Forms.ToolStripMenuItem mnuAddToFQSO;
        private System.Windows.Forms.ToolStripMenuItem mnuViewQuoteStats;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuRemoveQuote;
        private System.Windows.Forms.ContextMenuStrip mnuBid;
        private System.Windows.Forms.ToolStripMenuItem mnuAcceptBid;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuRemoveBid;
        private System.Windows.Forms.ToolStripMenuItem mnuSetSelected;
        private System.Windows.Forms.ToolStripMenuItem mnuSetUnSelected;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectAll;
        private System.Windows.Forms.ToolStripMenuItem mnuUnSelectAll;
        protected System.Windows.Forms.Timer tmr;
        protected NewMethod.nThrobber throbber;
        private System.Windows.Forms.Label lblFinancials;
        private NewMethod.nEdit_Boolean chkIsSourced;
        private System.Windows.Forms.Label lblProblemCustomer;
        private System.Windows.Forms.Label lblOutstandingInvoiceAmnt;
        private NewMethod.nList nList1;
        private System.Windows.Forms.GroupBox groupBox1;
        private NewMethod.nEdit_Boolean ctl_is_oem_product;
        private NewMethod.nEdit_Number ctl_oem_product_qty;
        private System.Windows.Forms.ComboBox ctl_oem_product_name;
        private System.Windows.Forms.GroupBox gbHubspot;
        private System.Windows.Forms.Button btnCreateHubspotBatch;
        private System.Windows.Forms.LinkLabel llblDealLink;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        public CompanyStub_PlusContact CompList;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.LinkLabel lblAgent;
        private System.Windows.Forms.GroupBox gbOpportunityStage;
        private NewMethod.nEdit_Boolean ctl_isLost;
        private System.Windows.Forms.Label lblOppStage;
        private System.Windows.Forms.LinkLabel llEditHubspotDeal;
        private System.Windows.Forms.ToolStripMenuItem addGCATServiceToolStripMenuItem;
        private NewMethod.nEdit_Boolean ctl_is_bom;
        private System.Windows.Forms.GroupBox gbSplitAgent;
        private System.Windows.Forms.LinkLabel llSplitAgent;
    }
}
