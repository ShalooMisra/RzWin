namespace Rz5.Win.Screens
{
    partial class PartSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PartSearch));
            this.pHeader = new System.Windows.Forms.Panel();
            this.chkOffers = new System.Windows.Forms.CheckBox();
            this.chkMaster = new System.Windows.Forms.CheckBox();
            this.lblExtraCriteria = new System.Windows.Forms.LinkLabel();
            this.chkOnlyThisComp = new System.Windows.Forms.CheckBox();
            this.pCompanyOptions = new System.Windows.Forms.Panel();
            this.cmdQuotes = new System.Windows.Forms.Button();
            this.cmdPurchases = new System.Windows.Forms.Button();
            this.cmdSales = new System.Windows.Forms.Button();
            this.pAllocated = new System.Windows.Forms.Panel();
            this.lblAlloc = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAvail = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.optDescription = new System.Windows.Forms.RadioButton();
            this.optMfg = new System.Windows.Forms.RadioButton();
            this.optPartNumber = new System.Windows.Forms.RadioButton();
            this.lblRecent = new System.Windows.Forms.LinkLabel();
            this.cmdMultiSearch = new System.Windows.Forms.Button();
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.chkConsign = new System.Windows.Forms.CheckBox();
            this.chkExcess = new System.Windows.Forms.CheckBox();
            this.cmdBid = new System.Windows.Forms.Button();
            this.chkStock = new System.Windows.Forms.CheckBox();
            this.pSearchType = new System.Windows.Forms.Panel();
            this.optExact = new System.Windows.Forms.RadioButton();
            this.optFuzzy = new System.Windows.Forms.RadioButton();
            this.optStandard = new System.Windows.Forms.RadioButton();
            this.cmdQuote = new System.Windows.Forms.Button();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.ilPics = new System.Windows.Forms.ImageList(this.components);
            this.CompList = new Rz5.CompanyStub_PlusContact();
            this.txtPartNumber = new NewMethod.nEntryBox();
            this.ts = new System.Windows.Forms.TabControl();
            this.tabParts = new System.Windows.Forms.TabPage();
            this.pSummary = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblExcess = new System.Windows.Forms.Label();
            this.lblConsign = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.Result_Parts = new NewMethod.nList();
            this.tabQuotes = new System.Windows.Forms.TabPage();
            this.gbQuotes = new System.Windows.Forms.GroupBox();
            this.optReceivingBids = new System.Windows.Forms.RadioButton();
            this.optGivingQuotes = new System.Windows.Forms.RadioButton();
            this.optAllQuotes = new System.Windows.Forms.RadioButton();
            this.Result_Quotes = new NewMethod.nList();
            this.tabSales = new System.Windows.Forms.TabPage();
            this.Result_Sales = new NewMethod.nList();
            this.tabPurchase = new System.Windows.Forms.TabPage();
            this.Result_Purchase = new NewMethod.nList();
            this.tabPictures = new System.Windows.Forms.TabPage();
            this.cmdPictureSwitch = new System.Windows.Forms.Button();
            this.throbPics = new NewMethod.nThrobber();
            this.lvPictures = new System.Windows.Forms.ListView();
            this.mnuPic = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabRMA = new System.Windows.Forms.TabPage();
            this.Result_RMA = new NewMethod.nList();
            this.optVendorRMA = new System.Windows.Forms.RadioButton();
            this.optCustomerRMA = new System.Windows.Forms.RadioButton();
            this.tabShipped = new System.Windows.Forms.TabPage();
            this.lvShipped = new NewMethod.nList();
            this.tabRzCommunity = new System.Windows.Forms.TabPage();
            this.lvRzCommunity = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mnuCommunity = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.bgSummary = new System.ComponentModel.BackgroundWorker();
            this.bgMaster = new System.ComponentModel.BackgroundWorker();
            this.bgPics = new System.ComponentModel.BackgroundWorker();
            this.lblOffers = new System.Windows.Forms.Label();
            this.pHeader.SuspendLayout();
            this.pCompanyOptions.SuspendLayout();
            this.pAllocated.SuspendLayout();
            this.pSearchType.SuspendLayout();
            this.ts.SuspendLayout();
            this.tabParts.SuspendLayout();
            this.pSummary.SuspendLayout();
            this.tabQuotes.SuspendLayout();
            this.gbQuotes.SuspendLayout();
            this.tabSales.SuspendLayout();
            this.tabPurchase.SuspendLayout();
            this.tabPictures.SuspendLayout();
            this.mnuPic.SuspendLayout();
            this.tabRMA.SuspendLayout();
            this.tabShipped.SuspendLayout();
            this.tabRzCommunity.SuspendLayout();
            this.mnuCommunity.SuspendLayout();
            this.SuspendLayout();
            // 
            // pHeader
            // 
            this.pHeader.Controls.Add(this.chkOffers);
            this.pHeader.Controls.Add(this.chkMaster);
            this.pHeader.Controls.Add(this.lblExtraCriteria);
            this.pHeader.Controls.Add(this.chkOnlyThisComp);
            this.pHeader.Controls.Add(this.pCompanyOptions);
            this.pHeader.Controls.Add(this.pAllocated);
            this.pHeader.Controls.Add(this.optDescription);
            this.pHeader.Controls.Add(this.optMfg);
            this.pHeader.Controls.Add(this.optPartNumber);
            this.pHeader.Controls.Add(this.lblRecent);
            this.pHeader.Controls.Add(this.cmdMultiSearch);
            this.pHeader.Controls.Add(this.chkConsign);
            this.pHeader.Controls.Add(this.chkExcess);
            this.pHeader.Controls.Add(this.cmdBid);
            this.pHeader.Controls.Add(this.chkStock);
            this.pHeader.Controls.Add(this.pSearchType);
            this.pHeader.Controls.Add(this.cmdQuote);
            this.pHeader.Controls.Add(this.cmdSearch);
            this.pHeader.Controls.Add(this.CompList);
            this.pHeader.Controls.Add(this.txtPartNumber);
            this.pHeader.Location = new System.Drawing.Point(6, 6);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(951, 122);
            this.pHeader.TabIndex = 0;
            // 
            // chkOffers
            // 
            this.chkOffers.AutoSize = true;
            this.chkOffers.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOffers.ForeColor = System.Drawing.Color.Purple;
            this.chkOffers.Location = new System.Drawing.Point(223, 90);
            this.chkOffers.Name = "chkOffers";
            this.chkOffers.Size = new System.Drawing.Size(60, 19);
            this.chkOffers.TabIndex = 63;
            this.chkOffers.Text = "Offers";
            this.chkOffers.UseVisualStyleBackColor = true;
            // 
            // chkMaster
            // 
            this.chkMaster.AutoSize = true;
            this.chkMaster.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMaster.ForeColor = System.Drawing.Color.DarkOrange;
            this.chkMaster.Location = new System.Drawing.Point(230, 65);
            this.chkMaster.Name = "chkMaster";
            this.chkMaster.Size = new System.Drawing.Size(65, 19);
            this.chkMaster.TabIndex = 62;
            this.chkMaster.Text = "Master";
            this.chkMaster.UseVisualStyleBackColor = true;
            this.chkMaster.Visible = false;
            // 
            // lblExtraCriteria
            // 
            this.lblExtraCriteria.AutoSize = true;
            this.lblExtraCriteria.Location = new System.Drawing.Point(330, 8);
            this.lblExtraCriteria.Name = "lblExtraCriteria";
            this.lblExtraCriteria.Size = new System.Drawing.Size(64, 13);
            this.lblExtraCriteria.TabIndex = 61;
            this.lblExtraCriteria.TabStop = true;
            this.lblExtraCriteria.Text = "extra criteria";
            this.lblExtraCriteria.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblExtraCriteria_LinkClicked);
            // 
            // chkOnlyThisComp
            // 
            this.chkOnlyThisComp.AutoSize = true;
            this.chkOnlyThisComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOnlyThisComp.Location = new System.Drawing.Point(790, 6);
            this.chkOnlyThisComp.Name = "chkOnlyThisComp";
            this.chkOnlyThisComp.Size = new System.Drawing.Size(134, 17);
            this.chkOnlyThisComp.TabIndex = 60;
            this.chkOnlyThisComp.Text = "Only This Company";
            this.chkOnlyThisComp.UseVisualStyleBackColor = true;
            // 
            // pCompanyOptions
            // 
            this.pCompanyOptions.Controls.Add(this.cmdQuotes);
            this.pCompanyOptions.Controls.Add(this.cmdPurchases);
            this.pCompanyOptions.Controls.Add(this.cmdSales);
            this.pCompanyOptions.Location = new System.Drawing.Point(416, 83);
            this.pCompanyOptions.Name = "pCompanyOptions";
            this.pCompanyOptions.Size = new System.Drawing.Size(232, 38);
            this.pCompanyOptions.TabIndex = 58;
            // 
            // cmdQuotes
            // 
            this.cmdQuotes.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdQuotes.Location = new System.Drawing.Point(3, 1);
            this.cmdQuotes.Name = "cmdQuotes";
            this.cmdQuotes.Size = new System.Drawing.Size(71, 25);
            this.cmdQuotes.TabIndex = 55;
            this.cmdQuotes.Text = "Quotes";
            this.cmdQuotes.UseVisualStyleBackColor = true;
            this.cmdQuotes.Click += new System.EventHandler(this.cmdQuotes_Click);
            // 
            // cmdPurchases
            // 
            this.cmdPurchases.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPurchases.Location = new System.Drawing.Point(150, 1);
            this.cmdPurchases.Name = "cmdPurchases";
            this.cmdPurchases.Size = new System.Drawing.Size(80, 25);
            this.cmdPurchases.TabIndex = 57;
            this.cmdPurchases.Text = "Purchases";
            this.cmdPurchases.UseVisualStyleBackColor = true;
            this.cmdPurchases.Click += new System.EventHandler(this.cmdPurchases_Click);
            // 
            // cmdSales
            // 
            this.cmdSales.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSales.Location = new System.Drawing.Point(76, 1);
            this.cmdSales.Name = "cmdSales";
            this.cmdSales.Size = new System.Drawing.Size(71, 25);
            this.cmdSales.TabIndex = 56;
            this.cmdSales.Text = "Sales";
            this.cmdSales.UseVisualStyleBackColor = true;
            this.cmdSales.Click += new System.EventHandler(this.cmdSales_Click);
            // 
            // pAllocated
            // 
            this.pAllocated.BackColor = System.Drawing.Color.Gainsboro;
            this.pAllocated.Controls.Add(this.lblAlloc);
            this.pAllocated.Controls.Add(this.label1);
            this.pAllocated.Controls.Add(this.label2);
            this.pAllocated.Controls.Add(this.label3);
            this.pAllocated.Controls.Add(this.lblAvail);
            this.pAllocated.Controls.Add(this.lblTotal);
            this.pAllocated.Location = new System.Drawing.Point(455, 83);
            this.pAllocated.Name = "pAllocated";
            this.pAllocated.Size = new System.Drawing.Size(189, 38);
            this.pAllocated.TabIndex = 53;
            this.pAllocated.Visible = false;
            // 
            // lblAlloc
            // 
            this.lblAlloc.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlloc.Location = new System.Drawing.Point(61, 13);
            this.lblAlloc.Name = "lblAlloc";
            this.lblAlloc.Size = new System.Drawing.Size(65, 22);
            this.lblAlloc.TabIndex = 7;
            this.lblAlloc.TabStop = true;
            this.lblAlloc.Text = "<alloc>";
            this.lblAlloc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAlloc.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAlloc_LinkClicked);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(126, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Available";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(64, -1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Allocated";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(3, -1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Total";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAvail
            // 
            this.lblAvail.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvail.ForeColor = System.Drawing.Color.Blue;
            this.lblAvail.Location = new System.Drawing.Point(125, 16);
            this.lblAvail.Name = "lblAvail";
            this.lblAvail.Size = new System.Drawing.Size(59, 19);
            this.lblAvail.TabIndex = 3;
            this.lblAvail.Text = "<avail>";
            this.lblAvail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Blue;
            this.lblTotal.Location = new System.Drawing.Point(3, 16);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(56, 19);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "<total>";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // optDescription
            // 
            this.optDescription.AutoSize = true;
            this.optDescription.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optDescription.Location = new System.Drawing.Point(126, 4);
            this.optDescription.Name = "optDescription";
            this.optDescription.Size = new System.Drawing.Size(88, 19);
            this.optDescription.TabIndex = 50;
            this.optDescription.TabStop = true;
            this.optDescription.Text = "Description";
            this.optDescription.UseVisualStyleBackColor = true;
            // 
            // optMfg
            // 
            this.optMfg.AutoSize = true;
            this.optMfg.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optMfg.Location = new System.Drawing.Point(74, 4);
            this.optMfg.Name = "optMfg";
            this.optMfg.Size = new System.Drawing.Size(46, 19);
            this.optMfg.TabIndex = 47;
            this.optMfg.Text = "Mfg";
            this.optMfg.UseVisualStyleBackColor = true;
            // 
            // optPartNumber
            // 
            this.optPartNumber.AutoSize = true;
            this.optPartNumber.Checked = true;
            this.optPartNumber.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optPartNumber.Location = new System.Drawing.Point(11, 4);
            this.optPartNumber.Name = "optPartNumber";
            this.optPartNumber.Size = new System.Drawing.Size(57, 19);
            this.optPartNumber.TabIndex = 46;
            this.optPartNumber.TabStop = true;
            this.optPartNumber.Text = "Part #";
            this.optPartNumber.UseVisualStyleBackColor = true;
            // 
            // lblRecent
            // 
            this.lblRecent.AutoSize = true;
            this.lblRecent.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecent.Location = new System.Drawing.Point(220, 6);
            this.lblRecent.Name = "lblRecent";
            this.lblRecent.Size = new System.Drawing.Size(93, 15);
            this.lblRecent.TabIndex = 43;
            this.lblRecent.TabStop = true;
            this.lblRecent.Text = "recent searches";
            this.lblRecent.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRecent_LinkClicked);
            // 
            // cmdMultiSearch
            // 
            this.cmdMultiSearch.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMultiSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdMultiSearch.ImageKey = "multisearch";
            this.cmdMultiSearch.ImageList = this.il;
            this.cmdMultiSearch.Location = new System.Drawing.Point(418, 26);
            this.cmdMultiSearch.Name = "cmdMultiSearch";
            this.cmdMultiSearch.Size = new System.Drawing.Size(94, 52);
            this.cmdMultiSearch.TabIndex = 38;
            this.cmdMultiSearch.Text = "MultiSearch";
            this.cmdMultiSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdMultiSearch.UseVisualStyleBackColor = true;
            this.cmdMultiSearch.Click += new System.EventHandler(this.cmdMultiSearch_Click);
            // 
            // il
            // 
            this.il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il.ImageStream")));
            this.il.TransparentColor = System.Drawing.Color.Magenta;
            this.il.Images.SetKeyName(0, "quote");
            this.il.Images.SetKeyName(1, "select");
            this.il.Images.SetKeyName(2, "multisearch");
            this.il.Images.SetKeyName(3, "bid");
            // 
            // chkConsign
            // 
            this.chkConsign.AutoSize = true;
            this.chkConsign.Checked = true;
            this.chkConsign.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConsign.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkConsign.ForeColor = System.Drawing.Color.DarkGreen;
            this.chkConsign.Location = new System.Drawing.Point(74, 92);
            this.chkConsign.Name = "chkConsign";
            this.chkConsign.Size = new System.Drawing.Size(68, 19);
            this.chkConsign.TabIndex = 37;
            this.chkConsign.Text = "Consign";
            this.chkConsign.UseVisualStyleBackColor = true;
            // 
            // chkExcess
            // 
            this.chkExcess.AutoSize = true;
            this.chkExcess.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExcess.ForeColor = System.Drawing.Color.Crimson;
            this.chkExcess.Location = new System.Drawing.Point(157, 92);
            this.chkExcess.Name = "chkExcess";
            this.chkExcess.Size = new System.Drawing.Size(60, 19);
            this.chkExcess.TabIndex = 36;
            this.chkExcess.Text = "Excess";
            this.chkExcess.UseVisualStyleBackColor = true;
            // 
            // cmdBid
            // 
            this.cmdBid.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBid.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdBid.ImageKey = "bid";
            this.cmdBid.ImageList = this.il;
            this.cmdBid.Location = new System.Drawing.Point(584, 26);
            this.cmdBid.Name = "cmdBid";
            this.cmdBid.Size = new System.Drawing.Size(60, 51);
            this.cmdBid.TabIndex = 33;
            this.cmdBid.Text = "Bid";
            this.cmdBid.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdBid.UseVisualStyleBackColor = true;
            this.cmdBid.Click += new System.EventHandler(this.cmdBid_Click);
            // 
            // chkStock
            // 
            this.chkStock.AutoSize = true;
            this.chkStock.Checked = true;
            this.chkStock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStock.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStock.ForeColor = System.Drawing.Color.Blue;
            this.chkStock.Location = new System.Drawing.Point(5, 92);
            this.chkStock.Name = "chkStock";
            this.chkStock.Size = new System.Drawing.Size(55, 19);
            this.chkStock.TabIndex = 35;
            this.chkStock.Text = "Stock";
            this.chkStock.UseVisualStyleBackColor = true;
            // 
            // pSearchType
            // 
            this.pSearchType.BackColor = System.Drawing.Color.Gainsboro;
            this.pSearchType.Controls.Add(this.optExact);
            this.pSearchType.Controls.Add(this.optFuzzy);
            this.pSearchType.Controls.Add(this.optStandard);
            this.pSearchType.Location = new System.Drawing.Point(5, 60);
            this.pSearchType.Name = "pSearchType";
            this.pSearchType.Size = new System.Drawing.Size(221, 27);
            this.pSearchType.TabIndex = 34;
            // 
            // optExact
            // 
            this.optExact.AutoSize = true;
            this.optExact.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optExact.Location = new System.Drawing.Point(160, 4);
            this.optExact.Name = "optExact";
            this.optExact.Size = new System.Drawing.Size(54, 19);
            this.optExact.TabIndex = 2;
            this.optExact.Text = "Exact";
            this.optExact.UseVisualStyleBackColor = true;
            // 
            // optFuzzy
            // 
            this.optFuzzy.AutoSize = true;
            this.optFuzzy.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optFuzzy.Location = new System.Drawing.Point(91, 4);
            this.optFuzzy.Name = "optFuzzy";
            this.optFuzzy.Size = new System.Drawing.Size(54, 19);
            this.optFuzzy.TabIndex = 1;
            this.optFuzzy.Text = "Fuzzy";
            this.optFuzzy.UseVisualStyleBackColor = true;
            // 
            // optStandard
            // 
            this.optStandard.AutoSize = true;
            this.optStandard.Checked = true;
            this.optStandard.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optStandard.Location = new System.Drawing.Point(6, 4);
            this.optStandard.Name = "optStandard";
            this.optStandard.Size = new System.Drawing.Size(75, 19);
            this.optStandard.TabIndex = 0;
            this.optStandard.TabStop = true;
            this.optStandard.Text = "Standard";
            this.optStandard.UseVisualStyleBackColor = true;
            // 
            // cmdQuote
            // 
            this.cmdQuote.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdQuote.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdQuote.ImageKey = "quote";
            this.cmdQuote.ImageList = this.il;
            this.cmdQuote.Location = new System.Drawing.Point(518, 26);
            this.cmdQuote.Name = "cmdQuote";
            this.cmdQuote.Size = new System.Drawing.Size(60, 52);
            this.cmdQuote.TabIndex = 32;
            this.cmdQuote.Text = "Quote";
            this.cmdQuote.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdQuote.UseVisualStyleBackColor = true;
            this.cmdQuote.Click += new System.EventHandler(this.cmdQuote_Click);
            // 
            // cmdSearch
            // 
            this.cmdSearch.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdSearch.ImageKey = "Search.jpg";
            this.cmdSearch.ImageList = this.ilPics;
            this.cmdSearch.Location = new System.Drawing.Point(319, 26);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(94, 79);
            this.cmdSearch.TabIndex = 30;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // ilPics
            // 
            this.ilPics.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilPics.ImageStream")));
            this.ilPics.TransparentColor = System.Drawing.Color.Transparent;
            this.ilPics.Images.SetKeyName(0, "Search.jpg");
            // 
            // CompList
            // 
            this.CompList.BackColor = System.Drawing.Color.White;
            this.CompList.Caption = "Company";
            this.CompList.Location = new System.Drawing.Point(650, 6);
            this.CompList.Margin = new System.Windows.Forms.Padding(5);
            this.CompList.Name = "CompList";
            this.CompList.Size = new System.Drawing.Size(315, 87);
            this.CompList.TabIndex = 29;
            this.CompList.ClearContact += new Rz5.ContactEventHandler(this.CompList_ClearContact);
            this.CompList.ContactChangeFinished += new Rz5.ContactEventHandler(this.CompList_ContactChangeFinished);
            this.CompList.ClearCompany += new Rz5.ContactEventHandler(this.CompList_ClearCompany);
            this.CompList.CompanyChangeFinished += new Rz5.ContactEventHandler(this.CompList_CompanyChangeFinished);
            // 
            // txtPartNumber
            // 
            this.txtPartNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPartNumber.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPartNumber.Location = new System.Drawing.Point(4, 27);
            this.txtPartNumber.Name = "txtPartNumber";
            this.txtPartNumber.Size = new System.Drawing.Size(309, 31);
            this.txtPartNumber.TabIndex = 28;
            this.txtPartNumber.GetEnter += new System.Windows.Forms.KeyPressEventHandler(this.txtPartNumber_GetEnter);
            // 
            // ts
            // 
            this.ts.Controls.Add(this.tabParts);
            this.ts.Controls.Add(this.tabQuotes);
            this.ts.Controls.Add(this.tabSales);
            this.ts.Controls.Add(this.tabPurchase);
            this.ts.Controls.Add(this.tabPictures);
            this.ts.Controls.Add(this.tabRMA);
            this.ts.Controls.Add(this.tabShipped);
            this.ts.Controls.Add(this.tabRzCommunity);
            this.ts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ts.Location = new System.Drawing.Point(7, 125);
            this.ts.Name = "ts";
            this.ts.SelectedIndex = 0;
            this.ts.Size = new System.Drawing.Size(950, 336);
            this.ts.TabIndex = 2;
            this.ts.SelectedIndexChanged += new System.EventHandler(this.ts_SelectedIndexChanged);
            // 
            // tabParts
            // 
            this.tabParts.Controls.Add(this.pSummary);
            this.tabParts.Controls.Add(this.Result_Parts);
            this.tabParts.Location = new System.Drawing.Point(4, 22);
            this.tabParts.Name = "tabParts";
            this.tabParts.Padding = new System.Windows.Forms.Padding(3);
            this.tabParts.Size = new System.Drawing.Size(942, 310);
            this.tabParts.TabIndex = 0;
            this.tabParts.Text = "Parts";
            this.tabParts.UseVisualStyleBackColor = true;
            // 
            // pSummary
            // 
            this.pSummary.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pSummary.Controls.Add(this.lblOffers);
            this.pSummary.Controls.Add(this.label4);
            this.pSummary.Controls.Add(this.lblExcess);
            this.pSummary.Controls.Add(this.lblConsign);
            this.pSummary.Controls.Add(this.lblStock);
            this.pSummary.Location = new System.Drawing.Point(6, 280);
            this.pSummary.Name = "pSummary";
            this.pSummary.Size = new System.Drawing.Size(699, 24);
            this.pSummary.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkOrange;
            this.label4.Location = new System.Drawing.Point(530, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "<MASTER>";
            // 
            // lblExcess
            // 
            this.lblExcess.AutoSize = true;
            this.lblExcess.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExcess.ForeColor = System.Drawing.Color.Crimson;
            this.lblExcess.Location = new System.Drawing.Point(260, 2);
            this.lblExcess.Name = "lblExcess";
            this.lblExcess.Size = new System.Drawing.Size(72, 19);
            this.lblExcess.TabIndex = 2;
            this.lblExcess.Text = "<EXCESS>";
            // 
            // lblConsign
            // 
            this.lblConsign.AutoSize = true;
            this.lblConsign.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsign.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblConsign.Location = new System.Drawing.Point(125, 2);
            this.lblConsign.Name = "lblConsign";
            this.lblConsign.Size = new System.Drawing.Size(86, 19);
            this.lblConsign.TabIndex = 1;
            this.lblConsign.Text = "<CONSIGN>";
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.ForeColor = System.Drawing.Color.Blue;
            this.lblStock.Location = new System.Drawing.Point(3, 2);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(68, 19);
            this.lblStock.TabIndex = 0;
            this.lblStock.Text = "<STOCK>";
            // 
            // Result_Parts
            // 
            this.Result_Parts.AddCaption = "Add New";
            this.Result_Parts.AllowActions = true;
            this.Result_Parts.AllowAdd = false;
            this.Result_Parts.AllowDelete = true;
            this.Result_Parts.AllowDeleteAlways = false;
            this.Result_Parts.AllowDrop = true;
            this.Result_Parts.AllowOnlyOpenDelete = false;
            this.Result_Parts.AlternateConnection = null;
            this.Result_Parts.BackColor = System.Drawing.Color.White;
            this.Result_Parts.Caption = "Stock, Consignments, And Excess";
            this.Result_Parts.CurrentTemplate = null;
            this.Result_Parts.ExtraClassInfo = "";
            this.Result_Parts.Location = new System.Drawing.Point(3, 3);
            this.Result_Parts.Margin = new System.Windows.Forms.Padding(4);
            this.Result_Parts.MultiSelect = true;
            this.Result_Parts.Name = "Result_Parts";
            this.Result_Parts.Size = new System.Drawing.Size(936, 252);
            this.Result_Parts.SuppressSelectionChanged = false;
            this.Result_Parts.TabIndex = 2;
            this.Result_Parts.zz_OpenColumnMenu = false;
            this.Result_Parts.zz_OrderLineType = "";
            this.Result_Parts.zz_ShowAutoRefresh = true;
            this.Result_Parts.zz_ShowUnlimited = true;
            this.Result_Parts.FinishedFill += new NewMethod.FillHandler(this.Result_Parts_FinishedFill);
            // 
            // tabQuotes
            // 
            this.tabQuotes.Controls.Add(this.gbQuotes);
            this.tabQuotes.Controls.Add(this.Result_Quotes);
            this.tabQuotes.Location = new System.Drawing.Point(4, 22);
            this.tabQuotes.Name = "tabQuotes";
            this.tabQuotes.Padding = new System.Windows.Forms.Padding(3);
            this.tabQuotes.Size = new System.Drawing.Size(942, 310);
            this.tabQuotes.TabIndex = 3;
            this.tabQuotes.Text = "Quotes";
            this.tabQuotes.UseVisualStyleBackColor = true;
            // 
            // gbQuotes
            // 
            this.gbQuotes.Controls.Add(this.optReceivingBids);
            this.gbQuotes.Controls.Add(this.optGivingQuotes);
            this.gbQuotes.Controls.Add(this.optAllQuotes);
            this.gbQuotes.Location = new System.Drawing.Point(6, 6);
            this.gbQuotes.Name = "gbQuotes";
            this.gbQuotes.Size = new System.Drawing.Size(350, 31);
            this.gbQuotes.TabIndex = 11;
            this.gbQuotes.TabStop = false;
            this.gbQuotes.Text = "Options";
            // 
            // optReceivingBids
            // 
            this.optReceivingBids.AutoSize = true;
            this.optReceivingBids.Location = new System.Drawing.Point(225, 12);
            this.optReceivingBids.Name = "optReceivingBids";
            this.optReceivingBids.Size = new System.Drawing.Size(106, 17);
            this.optReceivingBids.TabIndex = 2;
            this.optReceivingBids.Text = "Only Vendor Bids";
            this.optReceivingBids.UseVisualStyleBackColor = true;
            // 
            // optGivingQuotes
            // 
            this.optGivingQuotes.AutoSize = true;
            this.optGivingQuotes.Location = new System.Drawing.Point(74, 12);
            this.optGivingQuotes.Name = "optGivingQuotes";
            this.optGivingQuotes.Size = new System.Drawing.Size(130, 17);
            this.optGivingQuotes.TabIndex = 1;
            this.optGivingQuotes.Text = "Only Customer Quotes";
            this.optGivingQuotes.UseVisualStyleBackColor = true;
            // 
            // optAllQuotes
            // 
            this.optAllQuotes.AutoSize = true;
            this.optAllQuotes.Checked = true;
            this.optAllQuotes.Location = new System.Drawing.Point(20, 12);
            this.optAllQuotes.Name = "optAllQuotes";
            this.optAllQuotes.Size = new System.Drawing.Size(36, 17);
            this.optAllQuotes.TabIndex = 0;
            this.optAllQuotes.TabStop = true;
            this.optAllQuotes.Text = "All";
            this.optAllQuotes.UseVisualStyleBackColor = true;
            // 
            // Result_Quotes
            // 
            this.Result_Quotes.AddCaption = "Add New";
            this.Result_Quotes.AllowActions = true;
            this.Result_Quotes.AllowAdd = false;
            this.Result_Quotes.AllowDelete = true;
            this.Result_Quotes.AllowDeleteAlways = false;
            this.Result_Quotes.AllowDrop = true;
            this.Result_Quotes.AllowOnlyOpenDelete = false;
            this.Result_Quotes.AlternateConnection = null;
            this.Result_Quotes.BackColor = System.Drawing.Color.White;
            this.Result_Quotes.Caption = "";
            this.Result_Quotes.CurrentTemplate = null;
            this.Result_Quotes.ExtraClassInfo = "";
            this.Result_Quotes.Location = new System.Drawing.Point(6, 41);
            this.Result_Quotes.Margin = new System.Windows.Forms.Padding(4);
            this.Result_Quotes.MultiSelect = true;
            this.Result_Quotes.Name = "Result_Quotes";
            this.Result_Quotes.Size = new System.Drawing.Size(493, 151);
            this.Result_Quotes.SuppressSelectionChanged = false;
            this.Result_Quotes.TabIndex = 10;
            this.Result_Quotes.zz_OpenColumnMenu = false;
            this.Result_Quotes.zz_OrderLineType = "";
            this.Result_Quotes.zz_ShowAutoRefresh = true;
            this.Result_Quotes.zz_ShowUnlimited = true;
            // 
            // tabSales
            // 
            this.tabSales.Controls.Add(this.Result_Sales);
            this.tabSales.Location = new System.Drawing.Point(4, 22);
            this.tabSales.Name = "tabSales";
            this.tabSales.Padding = new System.Windows.Forms.Padding(3);
            this.tabSales.Size = new System.Drawing.Size(942, 310);
            this.tabSales.TabIndex = 4;
            this.tabSales.Text = "Sales";
            this.tabSales.UseVisualStyleBackColor = true;
            // 
            // Result_Sales
            // 
            this.Result_Sales.AddCaption = "Add New";
            this.Result_Sales.AllowActions = true;
            this.Result_Sales.AllowAdd = false;
            this.Result_Sales.AllowDelete = false;
            this.Result_Sales.AllowDeleteAlways = false;
            this.Result_Sales.AllowDrop = true;
            this.Result_Sales.AllowOnlyOpenDelete = false;
            this.Result_Sales.AlternateConnection = null;
            this.Result_Sales.BackColor = System.Drawing.Color.White;
            this.Result_Sales.Caption = "";
            this.Result_Sales.CurrentTemplate = null;
            this.Result_Sales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Result_Sales.ExtraClassInfo = "";
            this.Result_Sales.Location = new System.Drawing.Point(3, 3);
            this.Result_Sales.Margin = new System.Windows.Forms.Padding(4);
            this.Result_Sales.MultiSelect = true;
            this.Result_Sales.Name = "Result_Sales";
            this.Result_Sales.Size = new System.Drawing.Size(936, 304);
            this.Result_Sales.SuppressSelectionChanged = false;
            this.Result_Sales.TabIndex = 1;
            this.Result_Sales.zz_OpenColumnMenu = false;
            this.Result_Sales.zz_OrderLineType = "";
            this.Result_Sales.zz_ShowAutoRefresh = true;
            this.Result_Sales.zz_ShowUnlimited = true;
            this.Result_Sales.AboutToThrow += new Core.ShowHandler(this.Result_Sales_AboutToThrow);
            // 
            // tabPurchase
            // 
            this.tabPurchase.Controls.Add(this.Result_Purchase);
            this.tabPurchase.Location = new System.Drawing.Point(4, 22);
            this.tabPurchase.Name = "tabPurchase";
            this.tabPurchase.Padding = new System.Windows.Forms.Padding(3);
            this.tabPurchase.Size = new System.Drawing.Size(942, 310);
            this.tabPurchase.TabIndex = 5;
            this.tabPurchase.Text = "Purchases";
            this.tabPurchase.UseVisualStyleBackColor = true;
            // 
            // Result_Purchase
            // 
            this.Result_Purchase.AddCaption = "Add New";
            this.Result_Purchase.AllowActions = true;
            this.Result_Purchase.AllowAdd = false;
            this.Result_Purchase.AllowDelete = false;
            this.Result_Purchase.AllowDeleteAlways = false;
            this.Result_Purchase.AllowDrop = true;
            this.Result_Purchase.AllowOnlyOpenDelete = false;
            this.Result_Purchase.AlternateConnection = null;
            this.Result_Purchase.BackColor = System.Drawing.Color.White;
            this.Result_Purchase.Caption = "";
            this.Result_Purchase.CurrentTemplate = null;
            this.Result_Purchase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Result_Purchase.ExtraClassInfo = "";
            this.Result_Purchase.Location = new System.Drawing.Point(3, 3);
            this.Result_Purchase.Margin = new System.Windows.Forms.Padding(4);
            this.Result_Purchase.MultiSelect = true;
            this.Result_Purchase.Name = "Result_Purchase";
            this.Result_Purchase.Size = new System.Drawing.Size(936, 304);
            this.Result_Purchase.SuppressSelectionChanged = false;
            this.Result_Purchase.TabIndex = 1;
            this.Result_Purchase.zz_OpenColumnMenu = false;
            this.Result_Purchase.zz_OrderLineType = "";
            this.Result_Purchase.zz_ShowAutoRefresh = true;
            this.Result_Purchase.zz_ShowUnlimited = true;
            this.Result_Purchase.AboutToThrow += new Core.ShowHandler(this.Result_Purchase_AboutToThrow);
            // 
            // tabPictures
            // 
            this.tabPictures.Controls.Add(this.cmdPictureSwitch);
            this.tabPictures.Controls.Add(this.throbPics);
            this.tabPictures.Controls.Add(this.lvPictures);
            this.tabPictures.Location = new System.Drawing.Point(4, 22);
            this.tabPictures.Name = "tabPictures";
            this.tabPictures.Size = new System.Drawing.Size(942, 310);
            this.tabPictures.TabIndex = 7;
            this.tabPictures.Text = "Pictures";
            this.tabPictures.UseVisualStyleBackColor = true;
            // 
            // cmdPictureSwitch
            // 
            this.cmdPictureSwitch.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPictureSwitch.Location = new System.Drawing.Point(819, 32);
            this.cmdPictureSwitch.Name = "cmdPictureSwitch";
            this.cmdPictureSwitch.Size = new System.Drawing.Size(97, 33);
            this.cmdPictureSwitch.TabIndex = 2;
            this.cmdPictureSwitch.Text = "Switch View";
            this.cmdPictureSwitch.UseVisualStyleBackColor = true;
            this.cmdPictureSwitch.Click += new System.EventHandler(this.cmdPictureSwitch_Click);
            // 
            // throbPics
            // 
            this.throbPics.BackColor = System.Drawing.Color.Maroon;
            this.throbPics.Location = new System.Drawing.Point(6, 12);
            this.throbPics.Margin = new System.Windows.Forms.Padding(4);
            this.throbPics.Name = "throbPics";
            this.throbPics.Size = new System.Drawing.Size(30, 27);
            this.throbPics.TabIndex = 1;
            this.throbPics.UseParentBackColor = false;
            // 
            // lvPictures
            // 
            this.lvPictures.ContextMenuStrip = this.mnuPic;
            this.lvPictures.FullRowSelect = true;
            this.lvPictures.LargeImageList = this.ilPics;
            this.lvPictures.Location = new System.Drawing.Point(3, 3);
            this.lvPictures.Name = "lvPictures";
            this.lvPictures.Size = new System.Drawing.Size(936, 304);
            this.lvPictures.TabIndex = 0;
            this.lvPictures.UseCompatibleStateImageBehavior = false;
            this.lvPictures.DoubleClick += new System.EventHandler(this.lvPictures_DoubleClick);
            // 
            // mnuPic
            // 
            this.mnuPic.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.emailToolStripMenuItem});
            this.mnuPic.Name = "mnuPic";
            this.mnuPic.Size = new System.Drawing.Size(104, 70);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveAsToolStripMenuItem.Text = "Save";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // emailToolStripMenuItem
            // 
            this.emailToolStripMenuItem.Name = "emailToolStripMenuItem";
            this.emailToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.emailToolStripMenuItem.Text = "Email";
            this.emailToolStripMenuItem.Click += new System.EventHandler(this.emailToolStripMenuItem_Click);
            // 
            // tabRMA
            // 
            this.tabRMA.Controls.Add(this.Result_RMA);
            this.tabRMA.Controls.Add(this.optVendorRMA);
            this.tabRMA.Controls.Add(this.optCustomerRMA);
            this.tabRMA.Location = new System.Drawing.Point(4, 22);
            this.tabRMA.Name = "tabRMA";
            this.tabRMA.Padding = new System.Windows.Forms.Padding(3);
            this.tabRMA.Size = new System.Drawing.Size(942, 310);
            this.tabRMA.TabIndex = 10;
            this.tabRMA.Text = "RMAs";
            this.tabRMA.UseVisualStyleBackColor = true;
            // 
            // Result_RMA
            // 
            this.Result_RMA.AddCaption = "Add New";
            this.Result_RMA.AllowActions = true;
            this.Result_RMA.AllowAdd = false;
            this.Result_RMA.AllowDelete = false;
            this.Result_RMA.AllowDeleteAlways = false;
            this.Result_RMA.AllowDrop = true;
            this.Result_RMA.AllowOnlyOpenDelete = false;
            this.Result_RMA.AlternateConnection = null;
            this.Result_RMA.BackColor = System.Drawing.Color.White;
            this.Result_RMA.Caption = "";
            this.Result_RMA.CurrentTemplate = null;
            this.Result_RMA.ExtraClassInfo = "";
            this.Result_RMA.Location = new System.Drawing.Point(3, 24);
            this.Result_RMA.Margin = new System.Windows.Forms.Padding(4);
            this.Result_RMA.MultiSelect = true;
            this.Result_RMA.Name = "Result_RMA";
            this.Result_RMA.Size = new System.Drawing.Size(671, 254);
            this.Result_RMA.SuppressSelectionChanged = false;
            this.Result_RMA.TabIndex = 2;
            this.Result_RMA.zz_OpenColumnMenu = false;
            this.Result_RMA.zz_OrderLineType = "";
            this.Result_RMA.zz_ShowAutoRefresh = true;
            this.Result_RMA.zz_ShowUnlimited = true;
            this.Result_RMA.AboutToThrow += new Core.ShowHandler(this.Result_RMA_AboutToThrow);
            // 
            // optVendorRMA
            // 
            this.optVendorRMA.AutoSize = true;
            this.optVendorRMA.Location = new System.Drawing.Point(146, 5);
            this.optVendorRMA.Name = "optVendorRMA";
            this.optVendorRMA.Size = new System.Drawing.Size(91, 17);
            this.optVendorRMA.TabIndex = 1;
            this.optVendorRMA.Text = "Vendor RMAs";
            this.optVendorRMA.UseVisualStyleBackColor = true;
            // 
            // optCustomerRMA
            // 
            this.optCustomerRMA.AutoSize = true;
            this.optCustomerRMA.Checked = true;
            this.optCustomerRMA.Location = new System.Drawing.Point(7, 5);
            this.optCustomerRMA.Name = "optCustomerRMA";
            this.optCustomerRMA.Size = new System.Drawing.Size(101, 17);
            this.optCustomerRMA.TabIndex = 0;
            this.optCustomerRMA.TabStop = true;
            this.optCustomerRMA.Text = "Customer RMAs";
            this.optCustomerRMA.UseVisualStyleBackColor = true;
            // 
            // tabShipped
            // 
            this.tabShipped.Controls.Add(this.lvShipped);
            this.tabShipped.Location = new System.Drawing.Point(4, 22);
            this.tabShipped.Name = "tabShipped";
            this.tabShipped.Padding = new System.Windows.Forms.Padding(3);
            this.tabShipped.Size = new System.Drawing.Size(942, 310);
            this.tabShipped.TabIndex = 12;
            this.tabShipped.Text = "Shipped";
            this.tabShipped.UseVisualStyleBackColor = true;
            // 
            // lvShipped
            // 
            this.lvShipped.AddCaption = "Add New";
            this.lvShipped.AllowActions = true;
            this.lvShipped.AllowAdd = false;
            this.lvShipped.AllowDelete = true;
            this.lvShipped.AllowDeleteAlways = false;
            this.lvShipped.AllowDrop = true;
            this.lvShipped.AllowOnlyOpenDelete = false;
            this.lvShipped.AlternateConnection = null;
            this.lvShipped.BackColor = System.Drawing.Color.White;
            this.lvShipped.Caption = "";
            this.lvShipped.CurrentTemplate = null;
            this.lvShipped.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvShipped.ExtraClassInfo = "";
            this.lvShipped.Location = new System.Drawing.Point(3, 3);
            this.lvShipped.Margin = new System.Windows.Forms.Padding(4);
            this.lvShipped.MultiSelect = true;
            this.lvShipped.Name = "lvShipped";
            this.lvShipped.Size = new System.Drawing.Size(936, 304);
            this.lvShipped.SuppressSelectionChanged = false;
            this.lvShipped.TabIndex = 2;
            this.lvShipped.zz_OpenColumnMenu = false;
            this.lvShipped.zz_OrderLineType = "";
            this.lvShipped.zz_ShowAutoRefresh = true;
            this.lvShipped.zz_ShowUnlimited = true;
            // 
            // tabRzCommunity
            // 
            this.tabRzCommunity.Controls.Add(this.lvRzCommunity);
            this.tabRzCommunity.Location = new System.Drawing.Point(4, 22);
            this.tabRzCommunity.Name = "tabRzCommunity";
            this.tabRzCommunity.Size = new System.Drawing.Size(942, 310);
            this.tabRzCommunity.TabIndex = 13;
            this.tabRzCommunity.Text = "RzCommunity";
            this.tabRzCommunity.UseVisualStyleBackColor = true;
            // 
            // lvRzCommunity
            // 
            this.lvRzCommunity.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lvRzCommunity.ContextMenuStrip = this.mnuCommunity;
            this.lvRzCommunity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRzCommunity.FullRowSelect = true;
            this.lvRzCommunity.GridLines = true;
            this.lvRzCommunity.HideSelection = false;
            this.lvRzCommunity.Location = new System.Drawing.Point(0, 0);
            this.lvRzCommunity.MultiSelect = false;
            this.lvRzCommunity.Name = "lvRzCommunity";
            this.lvRzCommunity.Size = new System.Drawing.Size(942, 310);
            this.lvRzCommunity.TabIndex = 0;
            this.lvRzCommunity.UseCompatibleStateImageBehavior = false;
            this.lvRzCommunity.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "PartNumber";
            this.columnHeader1.Width = 175;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Quantity";
            this.columnHeader2.Width = 74;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Manufacturer";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Date Code";
            this.columnHeader4.Width = 65;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Condition";
            this.columnHeader5.Width = 82;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Packaging";
            this.columnHeader6.Width = 91;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Description";
            this.columnHeader7.Width = 153;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Vendor";
            this.columnHeader8.Width = 175;
            // 
            // mnuCommunity
            // 
            this.mnuCommunity.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEmail});
            this.mnuCommunity.Name = "mnuCommunity";
            this.mnuCommunity.Size = new System.Drawing.Size(104, 26);
            // 
            // mnuEmail
            // 
            this.mnuEmail.Name = "mnuEmail";
            this.mnuEmail.Size = new System.Drawing.Size(103, 22);
            this.mnuEmail.Text = "&Email";
            this.mnuEmail.Click += new System.EventHandler(this.mnuEmail_Click);
            // 
            // bgPics
            // 
            this.bgPics.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgPics_DoWork);
            this.bgPics.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgPics_RunWorkerCompleted);
            // 
            // lblOffers
            // 
            this.lblOffers.AutoSize = true;
            this.lblOffers.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOffers.ForeColor = System.Drawing.Color.Purple;
            this.lblOffers.Location = new System.Drawing.Point(376, 2);
            this.lblOffers.Name = "lblOffers";
            this.lblOffers.Size = new System.Drawing.Size(74, 19);
            this.lblOffers.TabIndex = 4;
            this.lblOffers.Text = "<OFFERS>";
            // 
            // PartSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ts);
            this.Controls.Add(this.pHeader);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PartSearch";
            this.Size = new System.Drawing.Size(980, 677);
            this.Resize += new System.EventHandler(this.PartSearch_Resize);
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            this.pCompanyOptions.ResumeLayout(false);
            this.pAllocated.ResumeLayout(false);
            this.pSearchType.ResumeLayout(false);
            this.pSearchType.PerformLayout();
            this.ts.ResumeLayout(false);
            this.tabParts.ResumeLayout(false);
            this.pSummary.ResumeLayout(false);
            this.pSummary.PerformLayout();
            this.tabQuotes.ResumeLayout(false);
            this.gbQuotes.ResumeLayout(false);
            this.gbQuotes.PerformLayout();
            this.tabSales.ResumeLayout(false);
            this.tabPurchase.ResumeLayout(false);
            this.tabPictures.ResumeLayout(false);
            this.mnuPic.ResumeLayout(false);
            this.tabRMA.ResumeLayout(false);
            this.tabRMA.PerformLayout();
            this.tabShipped.ResumeLayout(false);
            this.tabRzCommunity.ResumeLayout(false);
            this.mnuCommunity.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.RadioButton optMfg;
        protected System.Windows.Forms.RadioButton optPartNumber;
        protected System.Windows.Forms.LinkLabel lblRecent;
        protected System.Windows.Forms.Button cmdMultiSearch;
        private System.Windows.Forms.ImageList il;
        protected System.Windows.Forms.CheckBox chkConsign;
        protected System.Windows.Forms.CheckBox chkExcess;
        protected System.Windows.Forms.Button cmdBid;
        protected System.Windows.Forms.CheckBox chkStock;
        protected System.Windows.Forms.Panel pSearchType;
        protected System.Windows.Forms.Button cmdQuote;
        protected System.Windows.Forms.Button cmdSearch;
        protected NewMethod.nEntryBox txtPartNumber;
        public System.Windows.Forms.TabControl ts;
        protected System.Windows.Forms.TabPage tabParts;
        protected NewMethod.nList Result_Parts;
        protected System.Windows.Forms.TabPage tabQuotes;
        protected NewMethod.nList Result_Purchase;
        private System.Windows.Forms.TabPage tabPictures;
        protected NewMethod.nList Result_RMA;
        private System.Windows.Forms.RadioButton optVendorRMA;
        private System.Windows.Forms.RadioButton optCustomerRMA;
        private System.Windows.Forms.TabPage tabShipped;
        private NewMethod.nList lvShipped;
        protected NewMethod.nList Result_Quotes;
        protected System.Windows.Forms.GroupBox gbQuotes;
        private System.Windows.Forms.RadioButton optReceivingBids;
        private System.Windows.Forms.RadioButton optGivingQuotes;
        private System.Windows.Forms.RadioButton optAllQuotes;
        private System.Windows.Forms.Panel pSummary;
        private System.Windows.Forms.Label lblExcess;
        private System.Windows.Forms.Label lblConsign;
        private System.Windows.Forms.Label lblStock;
        private System.ComponentModel.BackgroundWorker bgSummary;
        private System.ComponentModel.BackgroundWorker bgMaster;
        private System.Windows.Forms.ListView lvPictures;
        private System.Windows.Forms.ImageList ilPics;
        private NewMethod.nThrobber throbPics;
        private System.ComponentModel.BackgroundWorker bgPics;
        private System.Windows.Forms.ContextMenuStrip mnuPic;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        protected System.Windows.Forms.Panel pAllocated;
        private System.Windows.Forms.Label lblAvail;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.LinkLabel lblAlloc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        protected System.Windows.Forms.TabPage tabRMA;
        protected System.Windows.Forms.Panel pHeader;
        protected System.Windows.Forms.TabPage tabRzCommunity;
        protected System.Windows.Forms.ListView lvRzCommunity;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        protected System.Windows.Forms.ContextMenuStrip mnuCommunity;
        protected System.Windows.Forms.ToolStripMenuItem mnuEmail;
        private System.Windows.Forms.Button cmdPictureSwitch;
        protected NewMethod.nList Result_Sales;
        protected System.Windows.Forms.TabPage tabSales;
        protected System.Windows.Forms.TabPage tabPurchase;
        protected System.Windows.Forms.RadioButton optDescription;
        protected System.Windows.Forms.Button cmdPurchases;
        protected System.Windows.Forms.Button cmdSales;
        protected System.Windows.Forms.Button cmdQuotes;
        protected System.Windows.Forms.Panel pCompanyOptions;
        protected System.Windows.Forms.RadioButton optExact;
        protected System.Windows.Forms.RadioButton optFuzzy;
        protected System.Windows.Forms.RadioButton optStandard;
        protected CompanyStub_PlusContact CompList;
        private System.Windows.Forms.CheckBox chkOnlyThisComp;
        private System.Windows.Forms.LinkLabel lblExtraCriteria;
        protected System.Windows.Forms.CheckBox chkMaster;
        private System.Windows.Forms.Label label4;
        protected System.Windows.Forms.CheckBox chkOffers;
        private System.Windows.Forms.Label lblOffers;
    }
}
