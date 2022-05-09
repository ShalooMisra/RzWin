using NewMethod;

namespace Rz5
{
    partial class OrderSearch
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
                CompleteDispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderSearch));
            this.tsOrders = new System.Windows.Forms.TabControl();
            this.tabSearch = new System.Windows.Forms.TabPage();
            this.lvSearch = new NewMethod.nList();
            this.tabRFQs = new System.Windows.Forms.TabPage();
            this.lvRFQs = new NewMethod.nList();
            this.tabFormalQuotes = new System.Windows.Forms.TabPage();
            this.lvFormalQuotes = new NewMethod.nList();
            this.tabSalesOrders = new System.Windows.Forms.TabPage();
            this.lvSalesOrders = new NewMethod.nList();
            this.tabPurchases = new System.Windows.Forms.TabPage();
            this.lvPurchases = new NewMethod.nList();
            this.tabInvoices = new System.Windows.Forms.TabPage();
            this.lvInvoices = new NewMethod.nList();
            this.tabRMAs = new System.Windows.Forms.TabPage();
            this.lvRMAs = new NewMethod.nList();
            this.tabVendorRMAs = new System.Windows.Forms.TabPage();
            this.lvVendorRMAs = new NewMethod.nList();
            this.tabService = new System.Windows.Forms.TabPage();
            this.lvService = new NewMethod.nList();
            this.pOptions = new System.Windows.Forms.Panel();
            this.chkUnlimited = new System.Windows.Forms.CheckBox();
            this.tsOptions = new System.Windows.Forms.TabControl();
            this.pageCompany = new System.Windows.Forms.TabPage();
            this.ctl_PoConfirmed = new NewMethod.nEdit_List();
            this.chkUnderpaid = new System.Windows.Forms.CheckBox();
            this.bar_lower = new System.Windows.Forms.PictureBox();
            this.ctl_opportunity_stage = new NewMethod.nEdit_List();
            this.ddlInvoiceStatus = new NewMethod.nEdit_List();
            this.chkConsignOnly = new System.Windows.Forms.CheckBox();
            this.optVoid = new System.Windows.Forms.RadioButton();
            this.chkOpenQuotes = new System.Windows.Forms.CheckBox();
            this.gbType = new System.Windows.Forms.GroupBox();
            this.optService = new System.Windows.Forms.RadioButton();
            this.optVendorRMA = new System.Windows.Forms.RadioButton();
            this.optRMA = new System.Windows.Forms.RadioButton();
            this.optInvoice = new System.Windows.Forms.RadioButton();
            this.optPurchase = new System.Windows.Forms.RadioButton();
            this.optSales = new System.Windows.Forms.RadioButton();
            this.optQuote = new System.Windows.Forms.RadioButton();
            this.optRFQ = new System.Windows.Forms.RadioButton();
            this.optAllTypes = new System.Windows.Forms.RadioButton();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.ctl_ContactName = new NewMethod.nEdit_String();
            this.ctl_PhoneFaxEmail = new NewMethod.nEdit_String();
            this.ctl_OrderDateEnd = new NewMethod.nEdit_Date();
            this.ctl_OrderNumber = new NewMethod.nEdit_String();
            this.ctl_CompanyType = new NewMethod.nEdit_List();
            this.optAll = new System.Windows.Forms.RadioButton();
            this.optClosed = new System.Windows.Forms.RadioButton();
            this.optOpen = new System.Windows.Forms.RadioButton();
            this.ctl_OrderDateStart = new NewMethod.nEdit_Date();
            this.ctl_PartInternalNumber = new NewMethod.nEdit_String();
            this.ctl_Tracking = new NewMethod.nEdit_String();
            this.ctl_CompanyName = new NewMethod.nEdit_String();
            this.ctl_Agent = new NewMethod.nEdit_User();
            this.tabOptions = new System.Windows.Forms.TabPage();
            this.lstFilters = new System.Windows.Forms.CheckedListBox();
            this.lblFilters = new System.Windows.Forms.Label();
            this.IMList = new System.Windows.Forms.ImageList(this.components);
            this.cmdClear = new System.Windows.Forms.Button();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.bgw = new System.ComponentModel.BackgroundWorker();
            this.wb = new ToolsWin.Browser();
            this.throb = new NewMethod.nThrobber();
            this.rbTrackingOnly = new System.Windows.Forms.RadioButton();
            this.dtRange = new Rz5.Win.Controls.ReportCriteriaControlDateRange();
            this.tsOrders.SuspendLayout();
            this.tabSearch.SuspendLayout();
            this.tabRFQs.SuspendLayout();
            this.tabFormalQuotes.SuspendLayout();
            this.tabSalesOrders.SuspendLayout();
            this.tabPurchases.SuspendLayout();
            this.tabInvoices.SuspendLayout();
            this.tabRMAs.SuspendLayout();
            this.tabVendorRMAs.SuspendLayout();
            this.tabService.SuspendLayout();
            this.pOptions.SuspendLayout();
            this.tsOptions.SuspendLayout();
            this.pageCompany.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar_lower)).BeginInit();
            this.gbType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.tabOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsOrders
            // 
            this.tsOrders.Controls.Add(this.tabSearch);
            this.tsOrders.Controls.Add(this.tabRFQs);
            this.tsOrders.Controls.Add(this.tabFormalQuotes);
            this.tsOrders.Controls.Add(this.tabSalesOrders);
            this.tsOrders.Controls.Add(this.tabPurchases);
            this.tsOrders.Controls.Add(this.tabInvoices);
            this.tsOrders.Controls.Add(this.tabRMAs);
            this.tsOrders.Controls.Add(this.tabVendorRMAs);
            this.tsOrders.Controls.Add(this.tabService);
            this.tsOrders.Location = new System.Drawing.Point(253, 54);
            this.tsOrders.Name = "tsOrders";
            this.tsOrders.SelectedIndex = 0;
            this.tsOrders.Size = new System.Drawing.Size(640, 362);
            this.tsOrders.TabIndex = 2;
            this.tsOrders.SelectedIndexChanged += new System.EventHandler(this.TS_SelectedIndexChanged);
            // 
            // tabSearch
            // 
            this.tabSearch.Controls.Add(this.lvSearch);
            this.tabSearch.Location = new System.Drawing.Point(4, 22);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Size = new System.Drawing.Size(632, 336);
            this.tabSearch.TabIndex = 1;
            this.tabSearch.Text = "Search Results";
            this.tabSearch.UseVisualStyleBackColor = true;
            // 
            // lvSearch
            // 
            this.lvSearch.AddCaption = "Add New";
            this.lvSearch.AllowActions = true;
            this.lvSearch.AllowAdd = false;
            this.lvSearch.AllowDelete = true;
            this.lvSearch.AllowDeleteAlways = false;
            this.lvSearch.AllowDrop = true;
            this.lvSearch.AllowOnlyOpenDelete = false;
            this.lvSearch.AlternateConnection = null;
            this.lvSearch.BackColor = System.Drawing.Color.White;
            this.lvSearch.Caption = "";
            this.lvSearch.CurrentTemplate = null;
            this.lvSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSearch.ExtraClassInfo = "";
            this.lvSearch.Location = new System.Drawing.Point(0, 0);
            this.lvSearch.MultiSelect = true;
            this.lvSearch.Name = "lvSearch";
            this.lvSearch.Size = new System.Drawing.Size(632, 336);
            this.lvSearch.SuppressSelectionChanged = false;
            this.lvSearch.TabIndex = 0;
            this.lvSearch.zz_OpenColumnMenu = false;
            this.lvSearch.zz_OrderLineType = "";
            this.lvSearch.zz_ShowAutoRefresh = true;
            this.lvSearch.zz_ShowUnlimited = true;
            // 
            // tabRFQs
            // 
            this.tabRFQs.Controls.Add(this.lvRFQs);
            this.tabRFQs.Location = new System.Drawing.Point(4, 22);
            this.tabRFQs.Name = "tabRFQs";
            this.tabRFQs.Size = new System.Drawing.Size(632, 336);
            this.tabRFQs.TabIndex = 8;
            this.tabRFQs.Text = "Bids";
            this.tabRFQs.UseVisualStyleBackColor = true;
            // 
            // lvRFQs
            // 
            this.lvRFQs.AddCaption = "Add New";
            this.lvRFQs.AllowActions = true;
            this.lvRFQs.AllowAdd = false;
            this.lvRFQs.AllowDelete = true;
            this.lvRFQs.AllowDeleteAlways = false;
            this.lvRFQs.AllowDrop = true;
            this.lvRFQs.AllowOnlyOpenDelete = false;
            this.lvRFQs.AlternateConnection = null;
            this.lvRFQs.BackColor = System.Drawing.Color.White;
            this.lvRFQs.Caption = "";
            this.lvRFQs.CurrentTemplate = null;
            this.lvRFQs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRFQs.ExtraClassInfo = "";
            this.lvRFQs.Location = new System.Drawing.Point(0, 0);
            this.lvRFQs.MultiSelect = true;
            this.lvRFQs.Name = "lvRFQs";
            this.lvRFQs.Size = new System.Drawing.Size(632, 336);
            this.lvRFQs.SuppressSelectionChanged = false;
            this.lvRFQs.TabIndex = 6;
            this.lvRFQs.zz_OpenColumnMenu = false;
            this.lvRFQs.zz_OrderLineType = "";
            this.lvRFQs.zz_ShowAutoRefresh = true;
            this.lvRFQs.zz_ShowUnlimited = true;
            // 
            // tabFormalQuotes
            // 
            this.tabFormalQuotes.Controls.Add(this.lvFormalQuotes);
            this.tabFormalQuotes.Location = new System.Drawing.Point(4, 22);
            this.tabFormalQuotes.Name = "tabFormalQuotes";
            this.tabFormalQuotes.Size = new System.Drawing.Size(632, 336);
            this.tabFormalQuotes.TabIndex = 2;
            this.tabFormalQuotes.Text = "Formal Quotes";
            this.tabFormalQuotes.UseVisualStyleBackColor = true;
            // 
            // lvFormalQuotes
            // 
            this.lvFormalQuotes.AddCaption = "Add New";
            this.lvFormalQuotes.AllowActions = true;
            this.lvFormalQuotes.AllowAdd = false;
            this.lvFormalQuotes.AllowDelete = true;
            this.lvFormalQuotes.AllowDeleteAlways = false;
            this.lvFormalQuotes.AllowDrop = true;
            this.lvFormalQuotes.AllowOnlyOpenDelete = false;
            this.lvFormalQuotes.AlternateConnection = null;
            this.lvFormalQuotes.BackColor = System.Drawing.Color.White;
            this.lvFormalQuotes.Caption = "";
            this.lvFormalQuotes.CurrentTemplate = null;
            this.lvFormalQuotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFormalQuotes.ExtraClassInfo = "";
            this.lvFormalQuotes.Location = new System.Drawing.Point(0, 0);
            this.lvFormalQuotes.MultiSelect = true;
            this.lvFormalQuotes.Name = "lvFormalQuotes";
            this.lvFormalQuotes.Size = new System.Drawing.Size(632, 336);
            this.lvFormalQuotes.SuppressSelectionChanged = false;
            this.lvFormalQuotes.TabIndex = 2;
            this.lvFormalQuotes.zz_OpenColumnMenu = false;
            this.lvFormalQuotes.zz_OrderLineType = "";
            this.lvFormalQuotes.zz_ShowAutoRefresh = true;
            this.lvFormalQuotes.zz_ShowUnlimited = true;
            // 
            // tabSalesOrders
            // 
            this.tabSalesOrders.Controls.Add(this.lvSalesOrders);
            this.tabSalesOrders.Location = new System.Drawing.Point(4, 22);
            this.tabSalesOrders.Name = "tabSalesOrders";
            this.tabSalesOrders.Size = new System.Drawing.Size(632, 336);
            this.tabSalesOrders.TabIndex = 3;
            this.tabSalesOrders.Text = "Sales Orders";
            this.tabSalesOrders.UseVisualStyleBackColor = true;
            // 
            // lvSalesOrders
            // 
            this.lvSalesOrders.AddCaption = "Add New";
            this.lvSalesOrders.AllowActions = true;
            this.lvSalesOrders.AllowAdd = false;
            this.lvSalesOrders.AllowDelete = true;
            this.lvSalesOrders.AllowDeleteAlways = false;
            this.lvSalesOrders.AllowDrop = true;
            this.lvSalesOrders.AllowOnlyOpenDelete = false;
            this.lvSalesOrders.AlternateConnection = null;
            this.lvSalesOrders.BackColor = System.Drawing.Color.White;
            this.lvSalesOrders.Caption = "";
            this.lvSalesOrders.CurrentTemplate = null;
            this.lvSalesOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSalesOrders.ExtraClassInfo = "";
            this.lvSalesOrders.Location = new System.Drawing.Point(0, 0);
            this.lvSalesOrders.MultiSelect = true;
            this.lvSalesOrders.Name = "lvSalesOrders";
            this.lvSalesOrders.Size = new System.Drawing.Size(632, 336);
            this.lvSalesOrders.SuppressSelectionChanged = false;
            this.lvSalesOrders.TabIndex = 3;
            this.lvSalesOrders.zz_OpenColumnMenu = false;
            this.lvSalesOrders.zz_OrderLineType = "";
            this.lvSalesOrders.zz_ShowAutoRefresh = true;
            this.lvSalesOrders.zz_ShowUnlimited = true;
            this.lvSalesOrders.AboutToThrow += new Core.ShowHandler(this.lvSalesOrders_AboutToThrow);
            // 
            // tabPurchases
            // 
            this.tabPurchases.Controls.Add(this.lvPurchases);
            this.tabPurchases.Location = new System.Drawing.Point(4, 22);
            this.tabPurchases.Name = "tabPurchases";
            this.tabPurchases.Size = new System.Drawing.Size(632, 336);
            this.tabPurchases.TabIndex = 4;
            this.tabPurchases.Text = "POs";
            this.tabPurchases.UseVisualStyleBackColor = true;
            // 
            // lvPurchases
            // 
            this.lvPurchases.AddCaption = "Add New";
            this.lvPurchases.AllowActions = true;
            this.lvPurchases.AllowAdd = false;
            this.lvPurchases.AllowDelete = true;
            this.lvPurchases.AllowDeleteAlways = false;
            this.lvPurchases.AllowDrop = true;
            this.lvPurchases.AllowOnlyOpenDelete = false;
            this.lvPurchases.AlternateConnection = null;
            this.lvPurchases.BackColor = System.Drawing.Color.White;
            this.lvPurchases.Caption = "";
            this.lvPurchases.CurrentTemplate = null;
            this.lvPurchases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPurchases.ExtraClassInfo = "";
            this.lvPurchases.Location = new System.Drawing.Point(0, 0);
            this.lvPurchases.MultiSelect = true;
            this.lvPurchases.Name = "lvPurchases";
            this.lvPurchases.Size = new System.Drawing.Size(632, 336);
            this.lvPurchases.SuppressSelectionChanged = false;
            this.lvPurchases.TabIndex = 4;
            this.lvPurchases.zz_OpenColumnMenu = false;
            this.lvPurchases.zz_OrderLineType = "";
            this.lvPurchases.zz_ShowAutoRefresh = true;
            this.lvPurchases.zz_ShowUnlimited = true;
            // 
            // tabInvoices
            // 
            this.tabInvoices.Controls.Add(this.lvInvoices);
            this.tabInvoices.Location = new System.Drawing.Point(4, 22);
            this.tabInvoices.Name = "tabInvoices";
            this.tabInvoices.Size = new System.Drawing.Size(632, 336);
            this.tabInvoices.TabIndex = 5;
            this.tabInvoices.Text = "Invoices";
            this.tabInvoices.UseVisualStyleBackColor = true;
            // 
            // lvInvoices
            // 
            this.lvInvoices.AddCaption = "Add New";
            this.lvInvoices.AllowActions = true;
            this.lvInvoices.AllowAdd = false;
            this.lvInvoices.AllowDelete = true;
            this.lvInvoices.AllowDeleteAlways = false;
            this.lvInvoices.AllowDrop = true;
            this.lvInvoices.AllowOnlyOpenDelete = false;
            this.lvInvoices.AlternateConnection = null;
            this.lvInvoices.BackColor = System.Drawing.Color.White;
            this.lvInvoices.Caption = "";
            this.lvInvoices.CurrentTemplate = null;
            this.lvInvoices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvInvoices.ExtraClassInfo = "";
            this.lvInvoices.Location = new System.Drawing.Point(0, 0);
            this.lvInvoices.MultiSelect = true;
            this.lvInvoices.Name = "lvInvoices";
            this.lvInvoices.Size = new System.Drawing.Size(632, 336);
            this.lvInvoices.SuppressSelectionChanged = false;
            this.lvInvoices.TabIndex = 5;
            this.lvInvoices.zz_OpenColumnMenu = false;
            this.lvInvoices.zz_OrderLineType = "";
            this.lvInvoices.zz_ShowAutoRefresh = true;
            this.lvInvoices.zz_ShowUnlimited = true;
            // 
            // tabRMAs
            // 
            this.tabRMAs.Controls.Add(this.lvRMAs);
            this.tabRMAs.Location = new System.Drawing.Point(4, 22);
            this.tabRMAs.Name = "tabRMAs";
            this.tabRMAs.Size = new System.Drawing.Size(632, 336);
            this.tabRMAs.TabIndex = 6;
            this.tabRMAs.Text = "RMAs";
            this.tabRMAs.UseVisualStyleBackColor = true;
            // 
            // lvRMAs
            // 
            this.lvRMAs.AddCaption = "Add New";
            this.lvRMAs.AllowActions = true;
            this.lvRMAs.AllowAdd = false;
            this.lvRMAs.AllowDelete = true;
            this.lvRMAs.AllowDeleteAlways = false;
            this.lvRMAs.AllowDrop = true;
            this.lvRMAs.AllowOnlyOpenDelete = false;
            this.lvRMAs.AlternateConnection = null;
            this.lvRMAs.BackColor = System.Drawing.Color.White;
            this.lvRMAs.Caption = "";
            this.lvRMAs.CurrentTemplate = null;
            this.lvRMAs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRMAs.ExtraClassInfo = "";
            this.lvRMAs.Location = new System.Drawing.Point(0, 0);
            this.lvRMAs.MultiSelect = true;
            this.lvRMAs.Name = "lvRMAs";
            this.lvRMAs.Size = new System.Drawing.Size(632, 336);
            this.lvRMAs.SuppressSelectionChanged = false;
            this.lvRMAs.TabIndex = 5;
            this.lvRMAs.zz_OpenColumnMenu = false;
            this.lvRMAs.zz_OrderLineType = "";
            this.lvRMAs.zz_ShowAutoRefresh = true;
            this.lvRMAs.zz_ShowUnlimited = true;
            // 
            // tabVendorRMAs
            // 
            this.tabVendorRMAs.Controls.Add(this.lvVendorRMAs);
            this.tabVendorRMAs.Location = new System.Drawing.Point(4, 22);
            this.tabVendorRMAs.Name = "tabVendorRMAs";
            this.tabVendorRMAs.Size = new System.Drawing.Size(632, 336);
            this.tabVendorRMAs.TabIndex = 7;
            this.tabVendorRMAs.Text = "Vendor RMAs";
            this.tabVendorRMAs.UseVisualStyleBackColor = true;
            // 
            // lvVendorRMAs
            // 
            this.lvVendorRMAs.AddCaption = "Add New";
            this.lvVendorRMAs.AllowActions = true;
            this.lvVendorRMAs.AllowAdd = false;
            this.lvVendorRMAs.AllowDelete = true;
            this.lvVendorRMAs.AllowDeleteAlways = false;
            this.lvVendorRMAs.AllowDrop = true;
            this.lvVendorRMAs.AllowOnlyOpenDelete = false;
            this.lvVendorRMAs.AlternateConnection = null;
            this.lvVendorRMAs.BackColor = System.Drawing.Color.White;
            this.lvVendorRMAs.Caption = "";
            this.lvVendorRMAs.CurrentTemplate = null;
            this.lvVendorRMAs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvVendorRMAs.ExtraClassInfo = "";
            this.lvVendorRMAs.Location = new System.Drawing.Point(0, 0);
            this.lvVendorRMAs.MultiSelect = true;
            this.lvVendorRMAs.Name = "lvVendorRMAs";
            this.lvVendorRMAs.Size = new System.Drawing.Size(632, 336);
            this.lvVendorRMAs.SuppressSelectionChanged = false;
            this.lvVendorRMAs.TabIndex = 6;
            this.lvVendorRMAs.zz_OpenColumnMenu = false;
            this.lvVendorRMAs.zz_OrderLineType = "";
            this.lvVendorRMAs.zz_ShowAutoRefresh = true;
            this.lvVendorRMAs.zz_ShowUnlimited = true;
            // 
            // tabService
            // 
            this.tabService.Controls.Add(this.lvService);
            this.tabService.Location = new System.Drawing.Point(4, 22);
            this.tabService.Name = "tabService";
            this.tabService.Size = new System.Drawing.Size(632, 336);
            this.tabService.TabIndex = 9;
            this.tabService.Text = "Service";
            this.tabService.UseVisualStyleBackColor = true;
            // 
            // lvService
            // 
            this.lvService.AddCaption = "Add New";
            this.lvService.AllowActions = true;
            this.lvService.AllowAdd = false;
            this.lvService.AllowDelete = true;
            this.lvService.AllowDeleteAlways = false;
            this.lvService.AllowDrop = true;
            this.lvService.AllowOnlyOpenDelete = false;
            this.lvService.AlternateConnection = null;
            this.lvService.BackColor = System.Drawing.Color.White;
            this.lvService.Caption = "";
            this.lvService.CurrentTemplate = null;
            this.lvService.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvService.ExtraClassInfo = "";
            this.lvService.Location = new System.Drawing.Point(0, 0);
            this.lvService.MultiSelect = true;
            this.lvService.Name = "lvService";
            this.lvService.Size = new System.Drawing.Size(632, 336);
            this.lvService.SuppressSelectionChanged = false;
            this.lvService.TabIndex = 8;
            this.lvService.zz_OpenColumnMenu = false;
            this.lvService.zz_OrderLineType = "";
            this.lvService.zz_ShowAutoRefresh = true;
            this.lvService.zz_ShowUnlimited = true;
            // 
            // pOptions
            // 
            this.pOptions.Controls.Add(this.chkUnlimited);
            this.pOptions.Controls.Add(this.tsOptions);
            this.pOptions.Controls.Add(this.cmdClear);
            this.pOptions.Controls.Add(this.cmdSearch);
            this.pOptions.Location = new System.Drawing.Point(7, 8);
            this.pOptions.Name = "pOptions";
            this.pOptions.Size = new System.Drawing.Size(243, 782);
            this.pOptions.TabIndex = 3;
            // 
            // chkUnlimited
            // 
            this.chkUnlimited.AutoSize = true;
            this.chkUnlimited.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkUnlimited.Location = new System.Drawing.Point(169, 50);
            this.chkUnlimited.Name = "chkUnlimited";
            this.chkUnlimited.Size = new System.Drawing.Size(69, 17);
            this.chkUnlimited.TabIndex = 19;
            this.chkUnlimited.Text = "Unlimited";
            this.chkUnlimited.UseVisualStyleBackColor = true;
            this.chkUnlimited.Visible = false;
            // 
            // tsOptions
            // 
            this.tsOptions.Controls.Add(this.pageCompany);
            this.tsOptions.Controls.Add(this.tabOptions);
            this.tsOptions.ImageList = this.IMList;
            this.tsOptions.Location = new System.Drawing.Point(3, 46);
            this.tsOptions.Name = "tsOptions";
            this.tsOptions.SelectedIndex = 0;
            this.tsOptions.Size = new System.Drawing.Size(237, 733);
            this.tsOptions.TabIndex = 20;
            // 
            // pageCompany
            // 
            this.pageCompany.BackColor = System.Drawing.Color.White;
            this.pageCompany.Controls.Add(this.rbTrackingOnly);
            this.pageCompany.Controls.Add(this.ctl_PoConfirmed);
            this.pageCompany.Controls.Add(this.chkUnderpaid);
            this.pageCompany.Controls.Add(this.bar_lower);
            this.pageCompany.Controls.Add(this.ctl_opportunity_stage);
            this.pageCompany.Controls.Add(this.ddlInvoiceStatus);
            this.pageCompany.Controls.Add(this.chkConsignOnly);
            this.pageCompany.Controls.Add(this.optVoid);
            this.pageCompany.Controls.Add(this.dtRange);
            this.pageCompany.Controls.Add(this.chkOpenQuotes);
            this.pageCompany.Controls.Add(this.gbType);
            this.pageCompany.Controls.Add(this.pictureBox3);
            this.pageCompany.Controls.Add(this.ctl_ContactName);
            this.pageCompany.Controls.Add(this.ctl_PhoneFaxEmail);
            this.pageCompany.Controls.Add(this.ctl_OrderDateEnd);
            this.pageCompany.Controls.Add(this.ctl_OrderNumber);
            this.pageCompany.Controls.Add(this.ctl_CompanyType);
            this.pageCompany.Controls.Add(this.optAll);
            this.pageCompany.Controls.Add(this.optClosed);
            this.pageCompany.Controls.Add(this.optOpen);
            this.pageCompany.Controls.Add(this.ctl_OrderDateStart);
            this.pageCompany.Controls.Add(this.ctl_PartInternalNumber);
            this.pageCompany.Controls.Add(this.ctl_Tracking);
            this.pageCompany.Controls.Add(this.ctl_CompanyName);
            this.pageCompany.Controls.Add(this.ctl_Agent);
            this.pageCompany.ImageKey = "criteria_sm.bmp";
            this.pageCompany.Location = new System.Drawing.Point(4, 23);
            this.pageCompany.Name = "pageCompany";
            this.pageCompany.Padding = new System.Windows.Forms.Padding(3);
            this.pageCompany.Size = new System.Drawing.Size(229, 706);
            this.pageCompany.TabIndex = 0;
            this.pageCompany.Text = "Criteria";
            // 
            // ctl_PoConfirmed
            // 
            this.ctl_PoConfirmed.AllCaps = false;
            this.ctl_PoConfirmed.AllowEdit = false;
            this.ctl_PoConfirmed.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_PoConfirmed.Bold = false;
            this.ctl_PoConfirmed.Caption = "Show Confirmed POs";
            this.ctl_PoConfirmed.Changed = false;
            this.ctl_PoConfirmed.ListName = "showConfirmedPOs";
            this.ctl_PoConfirmed.Location = new System.Drawing.Point(4, 628);
            this.ctl_PoConfirmed.Name = "ctl_PoConfirmed";
            this.ctl_PoConfirmed.SimpleList = null;
            this.ctl_PoConfirmed.Size = new System.Drawing.Size(222, 46);
            this.ctl_PoConfirmed.TabIndex = 38;
            this.ctl_PoConfirmed.UseParentBackColor = false;
            this.ctl_PoConfirmed.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctl_PoConfirmed.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_PoConfirmed.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_PoConfirmed.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_PoConfirmed.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_PoConfirmed.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_PoConfirmed.zz_OriginalDesign = true;
            this.ctl_PoConfirmed.zz_ShowNeedsSaveColor = true;
            this.ctl_PoConfirmed.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_PoConfirmed.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_PoConfirmed.zz_UseGlobalColor = false;
            this.ctl_PoConfirmed.zz_UseGlobalFont = false;
            // 
            // chkUnderpaid
            // 
            this.chkUnderpaid.AutoSize = true;
            this.chkUnderpaid.Location = new System.Drawing.Point(144, 455);
            this.chkUnderpaid.Name = "chkUnderpaid";
            this.chkUnderpaid.Size = new System.Drawing.Size(79, 17);
            this.chkUnderpaid.TabIndex = 28;
            this.chkUnderpaid.Text = "Under Paid";
            this.chkUnderpaid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkUnderpaid.UseVisualStyleBackColor = true;
            this.chkUnderpaid.Visible = false;
            this.chkUnderpaid.CheckedChanged += new System.EventHandler(this.chkUnderpaid_CheckedChanged);
            // 
            // bar_lower
            // 
            this.bar_lower.BackColor = System.Drawing.Color.Black;
            this.bar_lower.Location = new System.Drawing.Point(3, 524);
            this.bar_lower.Name = "bar_lower";
            this.bar_lower.Size = new System.Drawing.Size(223, 1);
            this.bar_lower.TabIndex = 37;
            this.bar_lower.TabStop = false;
            // 
            // ctl_opportunity_stage
            // 
            this.ctl_opportunity_stage.AllCaps = false;
            this.ctl_opportunity_stage.AllowEdit = false;
            this.ctl_opportunity_stage.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_opportunity_stage.Bold = false;
            this.ctl_opportunity_stage.Caption = "Opportunity Stage";
            this.ctl_opportunity_stage.Changed = false;
            this.ctl_opportunity_stage.ListName = "opportunity_stage_list";
            this.ctl_opportunity_stage.Location = new System.Drawing.Point(3, 576);
            this.ctl_opportunity_stage.Name = "ctl_opportunity_stage";
            this.ctl_opportunity_stage.SimpleList = null;
            this.ctl_opportunity_stage.Size = new System.Drawing.Size(222, 46);
            this.ctl_opportunity_stage.TabIndex = 36;
            this.ctl_opportunity_stage.UseParentBackColor = false;
            this.ctl_opportunity_stage.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctl_opportunity_stage.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_opportunity_stage.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_opportunity_stage.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_opportunity_stage.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_opportunity_stage.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_opportunity_stage.zz_OriginalDesign = true;
            this.ctl_opportunity_stage.zz_ShowNeedsSaveColor = true;
            this.ctl_opportunity_stage.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_opportunity_stage.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_opportunity_stage.zz_UseGlobalColor = false;
            this.ctl_opportunity_stage.zz_UseGlobalFont = false;
            // 
            // ddlInvoiceStatus
            // 
            this.ddlInvoiceStatus.AllCaps = false;
            this.ddlInvoiceStatus.AllowEdit = false;
            this.ddlInvoiceStatus.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ddlInvoiceStatus.Bold = false;
            this.ddlInvoiceStatus.Caption = "Paid Status";
            this.ddlInvoiceStatus.Changed = false;
            this.ddlInvoiceStatus.ListName = null;
            this.ddlInvoiceStatus.Location = new System.Drawing.Point(3, 529);
            this.ddlInvoiceStatus.Name = "ddlInvoiceStatus";
            this.ddlInvoiceStatus.SimpleList = null;
            this.ddlInvoiceStatus.Size = new System.Drawing.Size(223, 46);
            this.ddlInvoiceStatus.TabIndex = 34;
            this.ddlInvoiceStatus.UseParentBackColor = false;
            this.ddlInvoiceStatus.Visible = false;
            this.ddlInvoiceStatus.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlInvoiceStatus.zz_GlobalColor = System.Drawing.Color.Black;
            this.ddlInvoiceStatus.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ddlInvoiceStatus.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ddlInvoiceStatus.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ddlInvoiceStatus.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ddlInvoiceStatus.zz_OriginalDesign = true;
            this.ddlInvoiceStatus.zz_ShowNeedsSaveColor = true;
            this.ddlInvoiceStatus.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ddlInvoiceStatus.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ddlInvoiceStatus.zz_UseGlobalColor = false;
            this.ddlInvoiceStatus.zz_UseGlobalFont = false;
            // 
            // chkConsignOnly
            // 
            this.chkConsignOnly.AutoSize = true;
            this.chkConsignOnly.Location = new System.Drawing.Point(4, 455);
            this.chkConsignOnly.Name = "chkConsignOnly";
            this.chkConsignOnly.Size = new System.Drawing.Size(111, 17);
            this.chkConsignOnly.TabIndex = 33;
            this.chkConsignOnly.Text = "Consignment Only";
            this.chkConsignOnly.UseVisualStyleBackColor = true;
            this.chkConsignOnly.CheckedChanged += new System.EventHandler(this.chkConsignOnly_CheckedChanged);
            // 
            // optVoid
            // 
            this.optVoid.AutoSize = true;
            this.optVoid.Location = new System.Drawing.Point(150, 308);
            this.optVoid.Name = "optVoid";
            this.optVoid.Size = new System.Drawing.Size(46, 17);
            this.optVoid.TabIndex = 30;
            this.optVoid.Text = "Void";
            this.optVoid.UseVisualStyleBackColor = true;
            // 
            // chkOpenQuotes
            // 
            this.chkOpenQuotes.AutoSize = true;
            this.chkOpenQuotes.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkOpenQuotes.Location = new System.Drawing.Point(108, 146);
            this.chkOpenQuotes.Name = "chkOpenQuotes";
            this.chkOpenQuotes.Size = new System.Drawing.Size(111, 17);
            this.chkOpenQuotes.TabIndex = 29;
            this.chkOpenQuotes.Text = "Quotes w/o Sales";
            this.chkOpenQuotes.UseVisualStyleBackColor = true;
            this.chkOpenQuotes.Visible = false;
            // 
            // gbType
            // 
            this.gbType.Controls.Add(this.optService);
            this.gbType.Controls.Add(this.optVendorRMA);
            this.gbType.Controls.Add(this.optRMA);
            this.gbType.Controls.Add(this.optInvoice);
            this.gbType.Controls.Add(this.optPurchase);
            this.gbType.Controls.Add(this.optSales);
            this.gbType.Controls.Add(this.optQuote);
            this.gbType.Controls.Add(this.optRFQ);
            this.gbType.Controls.Add(this.optAllTypes);
            this.gbType.Location = new System.Drawing.Point(4, 76);
            this.gbType.Name = "gbType";
            this.gbType.Size = new System.Drawing.Size(218, 64);
            this.gbType.TabIndex = 19;
            this.gbType.TabStop = false;
            this.gbType.Text = "Type";
            // 
            // optService
            // 
            this.optService.AutoSize = true;
            this.optService.Location = new System.Drawing.Point(73, 45);
            this.optService.Name = "optService";
            this.optService.Size = new System.Drawing.Size(61, 17);
            this.optService.TabIndex = 26;
            this.optService.Text = "Service";
            this.optService.UseVisualStyleBackColor = true;
            this.optService.CheckedChanged += new System.EventHandler(this.optType_CheckedChanged);
            // 
            // optVendorRMA
            // 
            this.optVendorRMA.AutoSize = true;
            this.optVendorRMA.Location = new System.Drawing.Point(146, 45);
            this.optVendorRMA.Name = "optVendorRMA";
            this.optVendorRMA.Size = new System.Drawing.Size(55, 17);
            this.optVendorRMA.TabIndex = 25;
            this.optVendorRMA.Text = "vRMA";
            this.optVendorRMA.UseVisualStyleBackColor = true;
            this.optVendorRMA.CheckedChanged += new System.EventHandler(this.optType_CheckedChanged);
            // 
            // optRMA
            // 
            this.optRMA.AutoSize = true;
            this.optRMA.Location = new System.Drawing.Point(146, 29);
            this.optRMA.Name = "optRMA";
            this.optRMA.Size = new System.Drawing.Size(49, 17);
            this.optRMA.TabIndex = 24;
            this.optRMA.Text = "RMA";
            this.optRMA.UseVisualStyleBackColor = true;
            this.optRMA.CheckedChanged += new System.EventHandler(this.optType_CheckedChanged);
            // 
            // optInvoice
            // 
            this.optInvoice.AutoSize = true;
            this.optInvoice.Location = new System.Drawing.Point(146, 13);
            this.optInvoice.Name = "optInvoice";
            this.optInvoice.Size = new System.Drawing.Size(60, 17);
            this.optInvoice.TabIndex = 23;
            this.optInvoice.Text = "Invoice";
            this.optInvoice.UseVisualStyleBackColor = true;
            this.optInvoice.CheckedChanged += new System.EventHandler(this.optType_CheckedChanged);
            // 
            // optPurchase
            // 
            this.optPurchase.AutoSize = true;
            this.optPurchase.Location = new System.Drawing.Point(73, 29);
            this.optPurchase.Name = "optPurchase";
            this.optPurchase.Size = new System.Drawing.Size(70, 17);
            this.optPurchase.TabIndex = 22;
            this.optPurchase.Text = "Purchase";
            this.optPurchase.UseVisualStyleBackColor = true;
            this.optPurchase.CheckedChanged += new System.EventHandler(this.optType_CheckedChanged);
            // 
            // optSales
            // 
            this.optSales.AutoSize = true;
            this.optSales.Location = new System.Drawing.Point(73, 13);
            this.optSales.Name = "optSales";
            this.optSales.Size = new System.Drawing.Size(51, 17);
            this.optSales.TabIndex = 21;
            this.optSales.Text = "Sales";
            this.optSales.UseVisualStyleBackColor = true;
            this.optSales.CheckedChanged += new System.EventHandler(this.optType_CheckedChanged);
            // 
            // optQuote
            // 
            this.optQuote.AutoSize = true;
            this.optQuote.Location = new System.Drawing.Point(6, 45);
            this.optQuote.Name = "optQuote";
            this.optQuote.Size = new System.Drawing.Size(54, 17);
            this.optQuote.TabIndex = 20;
            this.optQuote.Text = "Quote";
            this.optQuote.UseVisualStyleBackColor = true;
            this.optQuote.CheckedChanged += new System.EventHandler(this.optType_CheckedChanged);
            // 
            // optRFQ
            // 
            this.optRFQ.AutoSize = true;
            this.optRFQ.Location = new System.Drawing.Point(6, 29);
            this.optRFQ.Name = "optRFQ";
            this.optRFQ.Size = new System.Drawing.Size(40, 17);
            this.optRFQ.TabIndex = 19;
            this.optRFQ.Text = "Bid";
            this.optRFQ.UseVisualStyleBackColor = true;
            this.optRFQ.CheckedChanged += new System.EventHandler(this.optType_CheckedChanged);
            // 
            // optAllTypes
            // 
            this.optAllTypes.AutoSize = true;
            this.optAllTypes.Checked = true;
            this.optAllTypes.Location = new System.Drawing.Point(6, 13);
            this.optAllTypes.Name = "optAllTypes";
            this.optAllTypes.Size = new System.Drawing.Size(36, 17);
            this.optAllTypes.TabIndex = 2;
            this.optAllTypes.TabStop = true;
            this.optAllTypes.Text = "All";
            this.optAllTypes.UseVisualStyleBackColor = true;
            this.optAllTypes.CheckedChanged += new System.EventHandler(this.optType_CheckedChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Black;
            this.pictureBox3.Location = new System.Drawing.Point(0, 448);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(223, 1);
            this.pictureBox3.TabIndex = 17;
            this.pictureBox3.TabStop = false;
            // 
            // ctl_ContactName
            // 
            this.ctl_ContactName.AllCaps = false;
            this.ctl_ContactName.BackColor = System.Drawing.Color.White;
            this.ctl_ContactName.Bold = false;
            this.ctl_ContactName.Caption = "Contact Name";
            this.ctl_ContactName.Changed = false;
            this.ctl_ContactName.IsEmail = false;
            this.ctl_ContactName.IsURL = false;
            this.ctl_ContactName.Location = new System.Drawing.Point(0, 330);
            this.ctl_ContactName.Name = "ctl_ContactName";
            this.ctl_ContactName.PasswordChar = '\0';
            this.ctl_ContactName.Size = new System.Drawing.Size(223, 41);
            this.ctl_ContactName.TabIndex = 6;
            this.ctl_ContactName.UseParentBackColor = true;
            this.ctl_ContactName.zz_Enabled = true;
            this.ctl_ContactName.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_ContactName.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_ContactName.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_ContactName.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_ContactName.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_ContactName.zz_OriginalDesign = true;
            this.ctl_ContactName.zz_ShowLinkButton = false;
            this.ctl_ContactName.zz_ShowNeedsSaveColor = false;
            this.ctl_ContactName.zz_Text = "";
            this.ctl_ContactName.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_ContactName.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_ContactName.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_ContactName.zz_UseGlobalColor = false;
            this.ctl_ContactName.zz_UseGlobalFont = false;
            this.ctl_ContactName.Load += new System.EventHandler(this.ctl_ContactName_Load);
            // 
            // ctl_PhoneFaxEmail
            // 
            this.ctl_PhoneFaxEmail.AllCaps = false;
            this.ctl_PhoneFaxEmail.BackColor = System.Drawing.Color.White;
            this.ctl_PhoneFaxEmail.Bold = false;
            this.ctl_PhoneFaxEmail.Caption = "Phone / Fax / Email";
            this.ctl_PhoneFaxEmail.Changed = false;
            this.ctl_PhoneFaxEmail.IsEmail = false;
            this.ctl_PhoneFaxEmail.IsURL = false;
            this.ctl_PhoneFaxEmail.Location = new System.Drawing.Point(0, 366);
            this.ctl_PhoneFaxEmail.Name = "ctl_PhoneFaxEmail";
            this.ctl_PhoneFaxEmail.PasswordChar = '\0';
            this.ctl_PhoneFaxEmail.Size = new System.Drawing.Size(223, 41);
            this.ctl_PhoneFaxEmail.TabIndex = 7;
            this.ctl_PhoneFaxEmail.UseParentBackColor = true;
            this.ctl_PhoneFaxEmail.zz_Enabled = true;
            this.ctl_PhoneFaxEmail.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_PhoneFaxEmail.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_PhoneFaxEmail.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_PhoneFaxEmail.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_PhoneFaxEmail.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_PhoneFaxEmail.zz_OriginalDesign = true;
            this.ctl_PhoneFaxEmail.zz_ShowLinkButton = false;
            this.ctl_PhoneFaxEmail.zz_ShowNeedsSaveColor = false;
            this.ctl_PhoneFaxEmail.zz_Text = "";
            this.ctl_PhoneFaxEmail.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_PhoneFaxEmail.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_PhoneFaxEmail.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_PhoneFaxEmail.zz_UseGlobalColor = false;
            this.ctl_PhoneFaxEmail.zz_UseGlobalFont = false;
            this.ctl_PhoneFaxEmail.Load += new System.EventHandler(this.ctl_PhoneFaxEmail_Load);
            // 
            // ctl_OrderDateEnd
            // 
            this.ctl_OrderDateEnd.AllowClear = true;
            this.ctl_OrderDateEnd.BackColor = System.Drawing.Color.White;
            this.ctl_OrderDateEnd.Bold = false;
            this.ctl_OrderDateEnd.Caption = "Order Date (End)";
            this.ctl_OrderDateEnd.Changed = false;
            this.ctl_OrderDateEnd.Location = new System.Drawing.Point(118, 143);
            this.ctl_OrderDateEnd.Name = "ctl_OrderDateEnd";
            this.ctl_OrderDateEnd.Size = new System.Drawing.Size(108, 53);
            this.ctl_OrderDateEnd.SuppressEdit = false;
            this.ctl_OrderDateEnd.TabIndex = 2;
            this.ctl_OrderDateEnd.UseParentBackColor = false;
            this.ctl_OrderDateEnd.Visible = false;
            this.ctl_OrderDateEnd.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_OrderDateEnd.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_OrderDateEnd.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_OrderDateEnd.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_OrderDateEnd.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctl_OrderDateEnd.zz_OriginalDesign = true;
            this.ctl_OrderDateEnd.zz_ShowNeedsSaveColor = true;
            this.ctl_OrderDateEnd.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_OrderDateEnd.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_OrderDateEnd.zz_UseGlobalColor = false;
            this.ctl_OrderDateEnd.zz_UseGlobalFont = false;
            // 
            // ctl_OrderNumber
            // 
            this.ctl_OrderNumber.AllCaps = false;
            this.ctl_OrderNumber.BackColor = System.Drawing.Color.White;
            this.ctl_OrderNumber.Bold = false;
            this.ctl_OrderNumber.Caption = "Order / CustomerPO / DealID";
            this.ctl_OrderNumber.Changed = false;
            this.ctl_OrderNumber.IsEmail = false;
            this.ctl_OrderNumber.IsURL = false;
            this.ctl_OrderNumber.Location = new System.Drawing.Point(3, -3);
            this.ctl_OrderNumber.Name = "ctl_OrderNumber";
            this.ctl_OrderNumber.PasswordChar = '\0';
            this.ctl_OrderNumber.Size = new System.Drawing.Size(223, 44);
            this.ctl_OrderNumber.TabIndex = 0;
            this.ctl_OrderNumber.UseParentBackColor = false;
            this.ctl_OrderNumber.zz_Enabled = true;
            this.ctl_OrderNumber.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_OrderNumber.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_OrderNumber.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_OrderNumber.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_OrderNumber.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_OrderNumber.zz_OriginalDesign = true;
            this.ctl_OrderNumber.zz_ShowLinkButton = false;
            this.ctl_OrderNumber.zz_ShowNeedsSaveColor = false;
            this.ctl_OrderNumber.zz_Text = "";
            this.ctl_OrderNumber.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_OrderNumber.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_OrderNumber.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_OrderNumber.zz_UseGlobalColor = false;
            this.ctl_OrderNumber.zz_UseGlobalFont = false;
            // 
            // ctl_CompanyType
            // 
            this.ctl_CompanyType.AllCaps = false;
            this.ctl_CompanyType.AllowEdit = false;
            this.ctl_CompanyType.BackColor = System.Drawing.Color.White;
            this.ctl_CompanyType.Bold = false;
            this.ctl_CompanyType.Caption = "Company Type";
            this.ctl_CompanyType.Changed = false;
            this.ctl_CompanyType.ListName = null;
            this.ctl_CompanyType.Location = new System.Drawing.Point(0, 402);
            this.ctl_CompanyType.Name = "ctl_CompanyType";
            this.ctl_CompanyType.SimpleList = "OEM|DIST|Non-OEM|Non-Dist";
            this.ctl_CompanyType.Size = new System.Drawing.Size(223, 41);
            this.ctl_CompanyType.TabIndex = 8;
            this.ctl_CompanyType.UseParentBackColor = true;
            this.ctl_CompanyType.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_CompanyType.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_CompanyType.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_CompanyType.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_CompanyType.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_CompanyType.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_CompanyType.zz_OriginalDesign = true;
            this.ctl_CompanyType.zz_ShowNeedsSaveColor = true;
            this.ctl_CompanyType.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_CompanyType.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_CompanyType.zz_UseGlobalColor = false;
            this.ctl_CompanyType.zz_UseGlobalFont = false;
            this.ctl_CompanyType.Load += new System.EventHandler(this.ctl_CompanyType_Load);
            // 
            // optAll
            // 
            this.optAll.AutoSize = true;
            this.optAll.Checked = true;
            this.optAll.Location = new System.Drawing.Point(4, 308);
            this.optAll.Name = "optAll";
            this.optAll.Size = new System.Drawing.Size(36, 17);
            this.optAll.TabIndex = 8;
            this.optAll.TabStop = true;
            this.optAll.Text = "All";
            this.optAll.UseVisualStyleBackColor = true;
            // 
            // optClosed
            // 
            this.optClosed.AutoSize = true;
            this.optClosed.Location = new System.Drawing.Point(90, 308);
            this.optClosed.Name = "optClosed";
            this.optClosed.Size = new System.Drawing.Size(57, 17);
            this.optClosed.TabIndex = 7;
            this.optClosed.Text = "Closed";
            this.optClosed.UseVisualStyleBackColor = true;
            // 
            // optOpen
            // 
            this.optOpen.AutoSize = true;
            this.optOpen.Location = new System.Drawing.Point(40, 308);
            this.optOpen.Name = "optOpen";
            this.optOpen.Size = new System.Drawing.Size(51, 17);
            this.optOpen.TabIndex = 6;
            this.optOpen.Text = "Open";
            this.optOpen.UseVisualStyleBackColor = true;
            // 
            // ctl_OrderDateStart
            // 
            this.ctl_OrderDateStart.AllowClear = true;
            this.ctl_OrderDateStart.BackColor = System.Drawing.Color.White;
            this.ctl_OrderDateStart.Bold = false;
            this.ctl_OrderDateStart.Caption = "Order Date (Start)";
            this.ctl_OrderDateStart.Changed = false;
            this.ctl_OrderDateStart.Location = new System.Drawing.Point(3, 143);
            this.ctl_OrderDateStart.Name = "ctl_OrderDateStart";
            this.ctl_OrderDateStart.Size = new System.Drawing.Size(108, 53);
            this.ctl_OrderDateStart.SuppressEdit = false;
            this.ctl_OrderDateStart.TabIndex = 3;
            this.ctl_OrderDateStart.UseParentBackColor = false;
            this.ctl_OrderDateStart.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_OrderDateStart.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_OrderDateStart.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_OrderDateStart.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_OrderDateStart.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctl_OrderDateStart.zz_OriginalDesign = true;
            this.ctl_OrderDateStart.zz_ShowNeedsSaveColor = true;
            this.ctl_OrderDateStart.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_OrderDateStart.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_OrderDateStart.zz_UseGlobalColor = false;
            this.ctl_OrderDateStart.zz_UseGlobalFont = false;
            this.ctl_OrderDateStart.DataChanged += new NewMethod.ChangeHandler(this.ctl_OrderDateStart_DataChanged);
            // 
            // ctl_PartInternalNumber
            // 
            this.ctl_PartInternalNumber.AllCaps = false;
            this.ctl_PartInternalNumber.BackColor = System.Drawing.Color.White;
            this.ctl_PartInternalNumber.Bold = false;
            this.ctl_PartInternalNumber.Caption = "PartNumber/Internal#";
            this.ctl_PartInternalNumber.Changed = false;
            this.ctl_PartInternalNumber.IsEmail = false;
            this.ctl_PartInternalNumber.IsURL = false;
            this.ctl_PartInternalNumber.Location = new System.Drawing.Point(0, 229);
            this.ctl_PartInternalNumber.Name = "ctl_PartInternalNumber";
            this.ctl_PartInternalNumber.PasswordChar = '\0';
            this.ctl_PartInternalNumber.Size = new System.Drawing.Size(223, 41);
            this.ctl_PartInternalNumber.TabIndex = 4;
            this.ctl_PartInternalNumber.UseParentBackColor = false;
            this.ctl_PartInternalNumber.zz_Enabled = true;
            this.ctl_PartInternalNumber.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_PartInternalNumber.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_PartInternalNumber.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_PartInternalNumber.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_PartInternalNumber.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_PartInternalNumber.zz_OriginalDesign = true;
            this.ctl_PartInternalNumber.zz_ShowLinkButton = false;
            this.ctl_PartInternalNumber.zz_ShowNeedsSaveColor = false;
            this.ctl_PartInternalNumber.zz_Text = "";
            this.ctl_PartInternalNumber.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_PartInternalNumber.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_PartInternalNumber.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_PartInternalNumber.zz_UseGlobalColor = false;
            this.ctl_PartInternalNumber.zz_UseGlobalFont = false;
            // 
            // ctl_Tracking
            // 
            this.ctl_Tracking.AllCaps = false;
            this.ctl_Tracking.BackColor = System.Drawing.Color.White;
            this.ctl_Tracking.Bold = false;
            this.ctl_Tracking.Caption = "Tracking Number";
            this.ctl_Tracking.Changed = false;
            this.ctl_Tracking.IsEmail = false;
            this.ctl_Tracking.IsURL = false;
            this.ctl_Tracking.Location = new System.Drawing.Point(0, 266);
            this.ctl_Tracking.Name = "ctl_Tracking";
            this.ctl_Tracking.PasswordChar = '\0';
            this.ctl_Tracking.Size = new System.Drawing.Size(144, 44);
            this.ctl_Tracking.TabIndex = 5;
            this.ctl_Tracking.UseParentBackColor = false;
            this.ctl_Tracking.zz_Enabled = true;
            this.ctl_Tracking.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_Tracking.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_Tracking.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_Tracking.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_Tracking.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_Tracking.zz_OriginalDesign = true;
            this.ctl_Tracking.zz_ShowLinkButton = false;
            this.ctl_Tracking.zz_ShowNeedsSaveColor = false;
            this.ctl_Tracking.zz_Text = "";
            this.ctl_Tracking.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_Tracking.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_Tracking.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_Tracking.zz_UseGlobalColor = false;
            this.ctl_Tracking.zz_UseGlobalFont = false;
            // 
            // ctl_CompanyName
            // 
            this.ctl_CompanyName.AllCaps = false;
            this.ctl_CompanyName.BackColor = System.Drawing.Color.White;
            this.ctl_CompanyName.Bold = false;
            this.ctl_CompanyName.Caption = "Company Name";
            this.ctl_CompanyName.Changed = false;
            this.ctl_CompanyName.IsEmail = false;
            this.ctl_CompanyName.IsURL = false;
            this.ctl_CompanyName.Location = new System.Drawing.Point(3, 35);
            this.ctl_CompanyName.Name = "ctl_CompanyName";
            this.ctl_CompanyName.PasswordChar = '\0';
            this.ctl_CompanyName.Size = new System.Drawing.Size(223, 41);
            this.ctl_CompanyName.TabIndex = 1;
            this.ctl_CompanyName.UseParentBackColor = true;
            this.ctl_CompanyName.zz_Enabled = true;
            this.ctl_CompanyName.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_CompanyName.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_CompanyName.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_CompanyName.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_CompanyName.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_CompanyName.zz_OriginalDesign = true;
            this.ctl_CompanyName.zz_ShowLinkButton = false;
            this.ctl_CompanyName.zz_ShowNeedsSaveColor = false;
            this.ctl_CompanyName.zz_Text = "";
            this.ctl_CompanyName.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_CompanyName.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_CompanyName.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_CompanyName.zz_UseGlobalColor = false;
            this.ctl_CompanyName.zz_UseGlobalFont = false;
            // 
            // ctl_Agent
            // 
            this.ctl_Agent.AllowChange = true;
            this.ctl_Agent.AllowClear = false;
            this.ctl_Agent.AllowNew = false;
            this.ctl_Agent.AllowView = false;
            this.ctl_Agent.BackColor = System.Drawing.Color.White;
            this.ctl_Agent.Bold = false;
            this.ctl_Agent.Caption = "Agent";
            this.ctl_Agent.Changed = false;
            this.ctl_Agent.Location = new System.Drawing.Point(3, 468);
            this.ctl_Agent.Name = "ctl_Agent";
            this.ctl_Agent.Size = new System.Drawing.Size(223, 54);
            this.ctl_Agent.TabIndex = 14;
            this.ctl_Agent.UseParentBackColor = false;
            this.ctl_Agent.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_Agent.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_Agent.ChangeUser += new NewMethod.ChangeUserHandler(this.ctl_Agent_ChangeUser);
            this.ctl_Agent.Load += new System.EventHandler(this.ctl_Agent_Load);
            // 
            // tabOptions
            // 
            this.tabOptions.Controls.Add(this.lstFilters);
            this.tabOptions.Controls.Add(this.lblFilters);
            this.tabOptions.ImageKey = "options_sm.bmp";
            this.tabOptions.Location = new System.Drawing.Point(4, 23);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabOptions.Size = new System.Drawing.Size(229, 706);
            this.tabOptions.TabIndex = 3;
            this.tabOptions.Text = "Options";
            this.tabOptions.UseVisualStyleBackColor = true;
            // 
            // lstFilters
            // 
            this.lstFilters.CheckOnClick = true;
            this.lstFilters.FormattingEnabled = true;
            this.lstFilters.Location = new System.Drawing.Point(9, 25);
            this.lstFilters.Name = "lstFilters";
            this.lstFilters.Size = new System.Drawing.Size(204, 454);
            this.lstFilters.TabIndex = 1;
            // 
            // lblFilters
            // 
            this.lblFilters.AutoSize = true;
            this.lblFilters.Location = new System.Drawing.Point(6, 3);
            this.lblFilters.Name = "lblFilters";
            this.lblFilters.Size = new System.Drawing.Size(210, 13);
            this.lblFilters.TabIndex = 0;
            this.lblFilters.Text = "Filters (Check and click \'Search>\' to view)::";
            // 
            // IMList
            // 
            this.IMList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IMList.ImageStream")));
            this.IMList.TransparentColor = System.Drawing.Color.Fuchsia;
            this.IMList.Images.SetKeyName(0, "add_sm.bmp");
            this.IMList.Images.SetKeyName(1, "clear_sm.bmp");
            this.IMList.Images.SetKeyName(2, "new_sm.bmp");
            this.IMList.Images.SetKeyName(3, "orders_sm.bmp");
            this.IMList.Images.SetKeyName(4, "partsearch_sm.bmp");
            this.IMList.Images.SetKeyName(5, "people_sm.bmp");
            this.IMList.Images.SetKeyName(6, "search_sm.bmp");
            this.IMList.Images.SetKeyName(7, "criteria_sm.bmp");
            this.IMList.Images.SetKeyName(8, "options_sm.bmp");
            // 
            // cmdClear
            // 
            this.cmdClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClear.ImageKey = "clear_sm.bmp";
            this.cmdClear.ImageList = this.IMList;
            this.cmdClear.Location = new System.Drawing.Point(3, 3);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(78, 42);
            this.cmdClear.TabIndex = 18;
            this.cmdClear.Text = "Clear";
            this.cmdClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // cmdSearch
            // 
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSearch.ImageKey = "search_sm.bmp";
            this.cmdSearch.ImageList = this.IMList;
            this.cmdSearch.Location = new System.Drawing.Point(87, 3);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(153, 42);
            this.cmdSearch.TabIndex = 17;
            this.cmdSearch.Text = "Search >";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // bgw
            // 
            this.bgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            this.bgw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted);
            // 
            // wb
            // 
            this.wb.Location = new System.Drawing.Point(322, 720);
            this.wb.Name = "wb";
            this.wb.ShowBackButton = false;
            this.wb.ShowControls = false;
            this.wb.Silent = false;
            this.wb.Size = new System.Drawing.Size(741, 70);
            this.wb.TabIndex = 6;
            // 
            // throb
            // 
            this.throb.BackColor = System.Drawing.Color.Maroon;
            this.throb.Location = new System.Drawing.Point(285, 763);
            this.throb.Margin = new System.Windows.Forms.Padding(4);
            this.throb.Name = "throb";
            this.throb.Size = new System.Drawing.Size(30, 27);
            this.throb.TabIndex = 5;
            this.throb.UseParentBackColor = false;
            this.throb.Visible = false;
            // 
            // rbTrackingOnly
            // 
            this.rbTrackingOnly.AutoSize = true;
            this.rbTrackingOnly.Location = new System.Drawing.Point(150, 285);
            this.rbTrackingOnly.Name = "rbTrackingOnly";
            this.rbTrackingOnly.Size = new System.Drawing.Size(65, 17);
            this.rbTrackingOnly.TabIndex = 39;
            this.rbTrackingOnly.Text = "Trk Only";
            this.rbTrackingOnly.UseVisualStyleBackColor = true;
            // 
            // dtRange
            // 
            this.dtRange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dtRange.Location = new System.Drawing.Point(3, 142);
            this.dtRange.Margin = new System.Windows.Forms.Padding(5);
            this.dtRange.Name = "dtRange";
            this.dtRange.Size = new System.Drawing.Size(219, 90);
            this.dtRange.TabIndex = 6;
            // 
            // OrderSearch
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.wb);
            this.Controls.Add(this.throb);
            this.Controls.Add(this.pOptions);
            this.Controls.Add(this.tsOrders);
            this.Location = new System.Drawing.Point(1, 1);
            this.Name = "OrderSearch";
            this.Size = new System.Drawing.Size(1204, 790);
            this.Resize += new System.EventHandler(this.OrderSearch_Resize);
            this.tsOrders.ResumeLayout(false);
            this.tabSearch.ResumeLayout(false);
            this.tabRFQs.ResumeLayout(false);
            this.tabFormalQuotes.ResumeLayout(false);
            this.tabSalesOrders.ResumeLayout(false);
            this.tabPurchases.ResumeLayout(false);
            this.tabInvoices.ResumeLayout(false);
            this.tabRMAs.ResumeLayout(false);
            this.tabVendorRMAs.ResumeLayout(false);
            this.tabService.ResumeLayout(false);
            this.pOptions.ResumeLayout(false);
            this.pOptions.PerformLayout();
            this.tsOptions.ResumeLayout(false);
            this.pageCompany.ResumeLayout(false);
            this.pageCompany.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar_lower)).EndInit();
            this.gbType.ResumeLayout(false);
            this.gbType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.tabOptions.ResumeLayout(false);
            this.tabOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public nList lvSearch;
        public nList lvFormalQuotes;
        public nList lvPurchases;
        public nList lvInvoices;
        public nList lvRMAs;
        public nList lvVendorRMAs;
        public nList lvRFQs;
        public nList lvService;
        public System.Windows.Forms.TabControl tsOrders;
        public nList lvSalesOrders;
        public System.Windows.Forms.TabPage tabSearch;
        public System.Windows.Forms.TabPage tabFormalQuotes;
        public System.Windows.Forms.TabPage tabSalesOrders;
        public System.Windows.Forms.TabPage tabPurchases;
        public System.Windows.Forms.TabPage tabInvoices;
        public System.Windows.Forms.TabPage tabRMAs;
        public System.Windows.Forms.TabPage tabVendorRMAs;
        public System.Windows.Forms.TabPage tabRFQs;
        public System.Windows.Forms.TabPage tabService;
        private System.Windows.Forms.CheckBox chkUnlimited;
        protected System.Windows.Forms.TabControl tsOptions;
        protected System.Windows.Forms.TabPage pageCompany;
        private System.Windows.Forms.GroupBox gbType;
        protected nEdit_Date ctl_OrderDateEnd;
        protected nEdit_String ctl_OrderNumber;
        protected nEdit_Date ctl_OrderDateStart;
        protected nEdit_String ctl_PartInternalNumber;
        protected nEdit_String ctl_CompanyName;
        protected System.Windows.Forms.TabPage tabOptions;
        private System.Windows.Forms.CheckedListBox lstFilters;
        private System.Windows.Forms.Label lblFilters;
        private System.Windows.Forms.ImageList IMList;
        private System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.Button cmdSearch;
        protected System.Windows.Forms.CheckBox chkOpenQuotes;
        protected nEdit_User ctl_Agent;
        protected nEdit_String ctl_ContactName;
        protected nEdit_String ctl_PhoneFaxEmail;
        protected nEdit_List ctl_CompanyType;
        protected System.Windows.Forms.RadioButton optAll;
        protected System.Windows.Forms.RadioButton optClosed;
        protected System.Windows.Forms.RadioButton optOpen;
        protected nEdit_String ctl_Tracking;
        protected System.Windows.Forms.Panel pOptions;
        protected System.Windows.Forms.RadioButton optService;
        protected System.Windows.Forms.RadioButton optVendorRMA;
        protected System.Windows.Forms.RadioButton optRMA;
        protected System.Windows.Forms.RadioButton optInvoice;
        protected System.Windows.Forms.RadioButton optPurchase;
        protected System.Windows.Forms.RadioButton optSales;
        protected System.Windows.Forms.RadioButton optQuote;
        protected System.Windows.Forms.RadioButton optRFQ;
        protected System.Windows.Forms.RadioButton optAllTypes;
        private nThrobber throb;
        private System.ComponentModel.BackgroundWorker bgw;
        private ToolsWin.Browser wb;
        private Win.Controls.ReportCriteriaControlDateRange dtRange;
        protected System.Windows.Forms.RadioButton optVoid;
        protected System.Windows.Forms.CheckBox chkUnderpaid;
        private nEdit_List ddlInvoiceStatus;
        private System.Windows.Forms.CheckBox chkConsignOnly;
        private nEdit_List ctl_opportunity_stage;
        protected System.Windows.Forms.PictureBox bar_lower;
        protected System.Windows.Forms.PictureBox pictureBox3;
        private nEdit_List ctl_PoConfirmed;
        protected System.Windows.Forms.RadioButton rbTrackingOnly;
    }
}
