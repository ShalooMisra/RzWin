namespace Rz5.Win.Screens
{
    partial class ImportInventoryScreen
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
            this.components = new System.ComponentModel.Container();
            this.ts = new System.Windows.Forms.TabControl();
            this.pageNewItems = new System.Windows.Forms.TabPage();
            this.gb = new System.Windows.Forms.GroupBox();
            this.ctl_purchase_orders = new NewMethod.nEdit_List();
            this.ctl_consigncodes = new NewMethod.nEdit_List();
            this.optMaster = new System.Windows.Forms.RadioButton();
            this.chooseuser = new NewMethod.nEdit_User();
            this.txtImportName = new NewMethod.nEdit_String();
            this.cStub = new Rz5.CompanyStub_PlusContact();
            this.optExcess = new System.Windows.Forms.RadioButton();
            this.optConsignment = new System.Windows.Forms.RadioButton();
            this.optStock = new System.Windows.Forms.RadioButton();
            this.dv = new NewMethod.nDataView();
            this.pagePast = new System.Windows.Forms.TabPage();
            this.gbPast = new System.Windows.Forms.GroupBox();
            this.cmdUpdateAllLists = new System.Windows.Forms.Button();
            this.cmdDeleteOfferImport = new System.Windows.Forms.Button();
            this.throb = new NewMethod.nThrobber();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.lblPastStatus = new System.Windows.Forms.Label();
            this.PastItems = new NewMethod.nList();
            this.lvPastImports = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mnuPast = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCount = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRename = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditNotes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSetAgent = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuArchive = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mergeListsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReport = new System.Windows.Forms.ToolStripMenuItem();
            this.partCrossReferenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pageExports = new System.Windows.Forms.TabPage();
            this.gbOneExport = new System.Windows.Forms.GroupBox();
            this.ctl_exportstring = new NewMethod.nEdit_Memo();
            this.ctl_exporttotext = new NewMethod.nEdit_Boolean();
            this.ctl_exportfile = new NewMethod.nEdit_String();
            this.ctl_exportname = new NewMethod.nEdit_String();
            this.cmdApply = new System.Windows.Forms.Button();
            this.cmdCloseExport = new System.Windows.Forms.Button();
            this.gbExports = new System.Windows.Forms.GroupBox();
            this.throbExport = new NewMethod.nThrobber();
            this.cmdNew = new System.Windows.Forms.Button();
            this.lvExports = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mnuExports = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuRunExport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenLastExportFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDeleteExport = new System.Windows.Forms.ToolStripMenuItem();
            this.bgImport = new System.ComponentModel.BackgroundWorker();
            this.bgList = new System.ComponentModel.BackgroundWorker();
            this.bgExport = new System.ComponentModel.BackgroundWorker();
            this.bgMergeImports = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bgwUpdate = new System.ComponentModel.BackgroundWorker();
            this.bwIndex = new System.ComponentModel.BackgroundWorker();
            this.optOffers = new System.Windows.Forms.RadioButton();
            this.ts.SuspendLayout();
            this.pageNewItems.SuspendLayout();
            this.gb.SuspendLayout();
            this.pagePast.SuspendLayout();
            this.gbPast.SuspendLayout();
            this.mnuPast.SuspendLayout();
            this.pageExports.SuspendLayout();
            this.gbOneExport.SuspendLayout();
            this.gbExports.SuspendLayout();
            this.mnuExports.SuspendLayout();
            this.SuspendLayout();
            // 
            // ts
            // 
            this.ts.Controls.Add(this.pageNewItems);
            this.ts.Controls.Add(this.pagePast);
            this.ts.Controls.Add(this.pageExports);
            this.ts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ts.Location = new System.Drawing.Point(0, 0);
            this.ts.Name = "ts";
            this.ts.SelectedIndex = 0;
            this.ts.Size = new System.Drawing.Size(975, 544);
            this.ts.TabIndex = 1;
            this.ts.SelectedIndexChanged += new System.EventHandler(this.ts_SelectedIndexChanged);
            // 
            // pageNewItems
            // 
            this.pageNewItems.BackColor = System.Drawing.Color.White;
            this.pageNewItems.Controls.Add(this.gb);
            this.pageNewItems.Controls.Add(this.dv);
            this.pageNewItems.Location = new System.Drawing.Point(4, 22);
            this.pageNewItems.Name = "pageNewItems";
            this.pageNewItems.Padding = new System.Windows.Forms.Padding(3);
            this.pageNewItems.Size = new System.Drawing.Size(967, 518);
            this.pageNewItems.TabIndex = 0;
            this.pageNewItems.Text = "New Items";
            // 
            // gb
            // 
            this.gb.BackColor = System.Drawing.Color.White;
            this.gb.Controls.Add(this.optOffers);
            this.gb.Controls.Add(this.ctl_purchase_orders);
            this.gb.Controls.Add(this.ctl_consigncodes);
            this.gb.Controls.Add(this.optMaster);
            this.gb.Controls.Add(this.chooseuser);
            this.gb.Controls.Add(this.txtImportName);
            this.gb.Controls.Add(this.cStub);
            this.gb.Controls.Add(this.optExcess);
            this.gb.Controls.Add(this.optConsignment);
            this.gb.Controls.Add(this.optStock);
            this.gb.Location = new System.Drawing.Point(6, 6);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(955, 112);
            this.gb.TabIndex = 1;
            this.gb.TabStop = false;
            this.gb.Text = "Stock, Consignment, and Excess Import";
            // 
            // ctl_purchase_orders
            // 
            this.ctl_purchase_orders.AllCaps = false;
            this.ctl_purchase_orders.AllowEdit = false;
            this.ctl_purchase_orders.BackColor = System.Drawing.Color.Transparent;
            this.ctl_purchase_orders.Bold = false;
            this.ctl_purchase_orders.Caption = "Purchase Orders";
            this.ctl_purchase_orders.Changed = false;
            this.ctl_purchase_orders.ListName = null;
            this.ctl_purchase_orders.Location = new System.Drawing.Point(6, 37);
            this.ctl_purchase_orders.Name = "ctl_purchase_orders";
            this.ctl_purchase_orders.SimpleList = null;
            this.ctl_purchase_orders.Size = new System.Drawing.Size(181, 36);
            this.ctl_purchase_orders.TabIndex = 8;
            this.ctl_purchase_orders.UseParentBackColor = false;
            this.ctl_purchase_orders.Visible = false;
            this.ctl_purchase_orders.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_purchase_orders.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_purchase_orders.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_purchase_orders.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_purchase_orders.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_purchase_orders.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_purchase_orders.zz_OriginalDesign = false;
            this.ctl_purchase_orders.zz_ShowNeedsSaveColor = false;
            this.ctl_purchase_orders.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_purchase_orders.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_purchase_orders.zz_UseGlobalColor = false;
            this.ctl_purchase_orders.zz_UseGlobalFont = false;
            // 
            // ctl_consigncodes
            // 
            this.ctl_consigncodes.AllCaps = false;
            this.ctl_consigncodes.AllowEdit = false;
            this.ctl_consigncodes.BackColor = System.Drawing.Color.Transparent;
            this.ctl_consigncodes.Bold = false;
            this.ctl_consigncodes.Caption = "Consignment Code";
            this.ctl_consigncodes.Changed = false;
            this.ctl_consigncodes.ListName = null;
            this.ctl_consigncodes.Location = new System.Drawing.Point(189, 37);
            this.ctl_consigncodes.Name = "ctl_consigncodes";
            this.ctl_consigncodes.SimpleList = null;
            this.ctl_consigncodes.Size = new System.Drawing.Size(181, 36);
            this.ctl_consigncodes.TabIndex = 7;
            this.ctl_consigncodes.UseParentBackColor = false;
            this.ctl_consigncodes.Visible = false;
            this.ctl_consigncodes.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_consigncodes.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_consigncodes.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_consigncodes.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_consigncodes.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_consigncodes.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_consigncodes.zz_OriginalDesign = false;
            this.ctl_consigncodes.zz_ShowNeedsSaveColor = false;
            this.ctl_consigncodes.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_consigncodes.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_consigncodes.zz_UseGlobalColor = false;
            this.ctl_consigncodes.zz_UseGlobalFont = false;
            // 
            // optMaster
            // 
            this.optMaster.AutoSize = true;
            this.optMaster.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optMaster.Location = new System.Drawing.Point(294, 15);
            this.optMaster.Name = "optMaster";
            this.optMaster.Size = new System.Drawing.Size(76, 24);
            this.optMaster.TabIndex = 6;
            this.optMaster.TabStop = true;
            this.optMaster.Text = "Master";
            this.optMaster.UseVisualStyleBackColor = true;
            // 
            // chooseuser
            // 
            this.chooseuser.AllowChange = true;
            this.chooseuser.AllowClear = false;
            this.chooseuser.AllowNew = false;
            this.chooseuser.AllowView = false;
            this.chooseuser.BackColor = System.Drawing.Color.White;
            this.chooseuser.Bold = false;
            this.chooseuser.Caption = "Agent Name";
            this.chooseuser.Changed = false;
            this.chooseuser.Location = new System.Drawing.Point(457, 19);
            this.chooseuser.Margin = new System.Windows.Forms.Padding(5);
            this.chooseuser.Name = "chooseuser";
            this.chooseuser.Size = new System.Drawing.Size(201, 54);
            this.chooseuser.TabIndex = 5;
            this.chooseuser.UseParentBackColor = true;
            this.chooseuser.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.chooseuser.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.chooseuser.ChangeUser += new NewMethod.ChangeUserHandler(this.chooseuser_ChangeUser);
            // 
            // txtImportName
            // 
            this.txtImportName.AllCaps = false;
            this.txtImportName.BackColor = System.Drawing.Color.White;
            this.txtImportName.Bold = false;
            this.txtImportName.Caption = "Import Name";
            this.txtImportName.Changed = false;
            this.txtImportName.IsEmail = false;
            this.txtImportName.IsURL = false;
            this.txtImportName.Location = new System.Drawing.Point(6, 67);
            this.txtImportName.Margin = new System.Windows.Forms.Padding(5);
            this.txtImportName.Name = "txtImportName";
            this.txtImportName.PasswordChar = '\0';
            this.txtImportName.Size = new System.Drawing.Size(579, 41);
            this.txtImportName.TabIndex = 4;
            this.txtImportName.UseParentBackColor = true;
            this.txtImportName.zz_Enabled = true;
            this.txtImportName.zz_GlobalColor = System.Drawing.Color.Black;
            this.txtImportName.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtImportName.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.txtImportName.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtImportName.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.txtImportName.zz_OriginalDesign = true;
            this.txtImportName.zz_ShowLinkButton = false;
            this.txtImportName.zz_ShowNeedsSaveColor = true;
            this.txtImportName.zz_Text = "";
            this.txtImportName.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtImportName.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.txtImportName.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImportName.zz_UseGlobalColor = false;
            this.txtImportName.zz_UseGlobalFont = false;
            // 
            // cStub
            // 
            this.cStub.Caption = "Vendor";
            this.cStub.Location = new System.Drawing.Point(664, 18);
            this.cStub.Margin = new System.Windows.Forms.Padding(5);
            this.cStub.Name = "cStub";
            this.cStub.Size = new System.Drawing.Size(284, 88);
            this.cStub.TabIndex = 3;
            this.cStub.CompanyChangeFinished += new Rz5.ContactEventHandler(this.cStub_CompanyChangeFinished);
            // 
            // optExcess
            // 
            this.optExcess.AutoSize = true;
            this.optExcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optExcess.Location = new System.Drawing.Point(210, 15);
            this.optExcess.Name = "optExcess";
            this.optExcess.Size = new System.Drawing.Size(78, 24);
            this.optExcess.TabIndex = 2;
            this.optExcess.TabStop = true;
            this.optExcess.Text = "Excess";
            this.optExcess.UseVisualStyleBackColor = true;
            this.optExcess.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
            // 
            // optConsignment
            // 
            this.optConsignment.AutoSize = true;
            this.optConsignment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optConsignment.Location = new System.Drawing.Point(82, 15);
            this.optConsignment.Name = "optConsignment";
            this.optConsignment.Size = new System.Drawing.Size(121, 24);
            this.optConsignment.TabIndex = 1;
            this.optConsignment.TabStop = true;
            this.optConsignment.Text = "Consignment";
            this.optConsignment.UseVisualStyleBackColor = true;
            this.optConsignment.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
            // 
            // optStock
            // 
            this.optStock.AutoSize = true;
            this.optStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optStock.Location = new System.Drawing.Point(6, 15);
            this.optStock.Name = "optStock";
            this.optStock.Size = new System.Drawing.Size(68, 24);
            this.optStock.TabIndex = 0;
            this.optStock.TabStop = true;
            this.optStock.Text = "Stock";
            this.optStock.UseVisualStyleBackColor = true;
            this.optStock.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
            // 
            // dv
            // 
            this.dv.AlwaysDisableAccept = false;
            this.dv.BackColor = System.Drawing.Color.White;
            this.dv.DisableAutoMatching = false;
            this.dv.HideOptions = false;
            this.dv.Location = new System.Drawing.Point(6, 124);
            this.dv.Margin = new System.Windows.Forms.Padding(4);
            this.dv.Name = "dv";
            this.dv.Size = new System.Drawing.Size(701, 238);
            this.dv.TabIndex = 0;
            this.dv.Accept += new NewMethod.nDataViewAcceptHandler(this.dv_Accept);
            this.dv.BeforeImport += new NewMethod.nDataViewImportHandler(this.dv_BeforeImport);
            // 
            // pagePast
            // 
            this.pagePast.BackColor = System.Drawing.Color.White;
            this.pagePast.Controls.Add(this.gbPast);
            this.pagePast.Controls.Add(this.PastItems);
            this.pagePast.Controls.Add(this.lvPastImports);
            this.pagePast.Location = new System.Drawing.Point(4, 22);
            this.pagePast.Name = "pagePast";
            this.pagePast.Padding = new System.Windows.Forms.Padding(3);
            this.pagePast.Size = new System.Drawing.Size(967, 518);
            this.pagePast.TabIndex = 1;
            this.pagePast.Text = "Past Imports";
            // 
            // gbPast
            // 
            this.gbPast.BackColor = System.Drawing.Color.White;
            this.gbPast.Controls.Add(this.cmdUpdateAllLists);
            this.gbPast.Controls.Add(this.cmdDeleteOfferImport);
            this.gbPast.Controls.Add(this.throb);
            this.gbPast.Controls.Add(this.cmdRefresh);
            this.gbPast.Controls.Add(this.lblPastStatus);
            this.gbPast.Location = new System.Drawing.Point(3, 6);
            this.gbPast.Name = "gbPast";
            this.gbPast.Size = new System.Drawing.Size(741, 42);
            this.gbPast.TabIndex = 10;
            this.gbPast.TabStop = false;
            // 
            // cmdUpdateAllLists
            // 
            this.cmdUpdateAllLists.Location = new System.Drawing.Point(486, 12);
            this.cmdUpdateAllLists.Name = "cmdUpdateAllLists";
            this.cmdUpdateAllLists.Size = new System.Drawing.Size(113, 27);
            this.cmdUpdateAllLists.TabIndex = 17;
            this.cmdUpdateAllLists.Text = "Update All Lists";
            this.toolTip1.SetToolTip(this.cmdUpdateAllLists, "Update All Lists Colors");
            this.cmdUpdateAllLists.UseVisualStyleBackColor = true;
            this.cmdUpdateAllLists.Click += new System.EventHandler(this.cmdUpdateAllLists_Click);
            // 
            // cmdDeleteOfferImport
            // 
            this.cmdDeleteOfferImport.Location = new System.Drawing.Point(605, 12);
            this.cmdDeleteOfferImport.Name = "cmdDeleteOfferImport";
            this.cmdDeleteOfferImport.Size = new System.Drawing.Size(130, 27);
            this.cmdDeleteOfferImport.TabIndex = 12;
            this.cmdDeleteOfferImport.Text = "Delete An Offer Import";
            this.cmdDeleteOfferImport.UseVisualStyleBackColor = true;
            this.cmdDeleteOfferImport.Click += new System.EventHandler(this.cmdDeleteOfferImport_Click);
            // 
            // throb
            // 
            this.throb.BackColor = System.Drawing.Color.White;
            this.throb.Location = new System.Drawing.Point(136, 9);
            this.throb.Margin = new System.Windows.Forms.Padding(4);
            this.throb.Name = "throb";
            this.throb.Size = new System.Drawing.Size(30, 27);
            this.throb.TabIndex = 11;
            this.throb.UseParentBackColor = false;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Location = new System.Drawing.Point(6, 10);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(127, 27);
            this.cmdRefresh.TabIndex = 8;
            this.cmdRefresh.Text = "View Past Imports";
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // lblPastStatus
            // 
            this.lblPastStatus.AutoSize = true;
            this.lblPastStatus.Location = new System.Drawing.Point(172, 26);
            this.lblPastStatus.Name = "lblPastStatus";
            this.lblPastStatus.Size = new System.Drawing.Size(47, 13);
            this.lblPastStatus.TabIndex = 10;
            this.lblPastStatus.Text = "<status>";
            // 
            // PastItems
            // 
            this.PastItems.AddCaption = "Add New";
            this.PastItems.AllowActions = true;
            this.PastItems.AllowAdd = false;
            this.PastItems.AllowDelete = true;
            this.PastItems.AllowDeleteAlways = false;
            this.PastItems.AllowDrop = true;
            this.PastItems.AllowOnlyOpenDelete = false;
            this.PastItems.AlternateConnection = null;
            this.PastItems.BackColor = System.Drawing.Color.White;
            this.PastItems.Caption = "";
            this.PastItems.CurrentTemplate = null;
            this.PastItems.ExtraClassInfo = "";
            this.PastItems.Location = new System.Drawing.Point(524, 54);
            this.PastItems.Margin = new System.Windows.Forms.Padding(4);
            this.PastItems.MultiSelect = true;
            this.PastItems.Name = "PastItems";
            this.PastItems.Size = new System.Drawing.Size(283, 129);
            this.PastItems.SuppressSelectionChanged = false;
            this.PastItems.TabIndex = 9;
            this.PastItems.Visible = false;
            this.PastItems.zz_OpenColumnMenu = false;
            this.PastItems.zz_OrderLineType = "";
            this.PastItems.zz_ShowAutoRefresh = true;
            this.PastItems.zz_ShowUnlimited = true;
            // 
            // lvPastImports
            // 
            this.lvPastImports.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.columnHeader5,
            this.columnHeader1,
            this.columnHeader4});
            this.lvPastImports.ContextMenuStrip = this.mnuPast;
            this.lvPastImports.FullRowSelect = true;
            this.lvPastImports.Location = new System.Drawing.Point(3, 54);
            this.lvPastImports.Name = "lvPastImports";
            this.lvPastImports.Size = new System.Drawing.Size(515, 117);
            this.lvPastImports.TabIndex = 8;
            this.lvPastImports.UseCompatibleStateImageBehavior = false;
            this.lvPastImports.View = System.Windows.Forms.View.Details;
            this.lvPastImports.Visible = false;
            this.lvPastImports.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvPastImports_ColumnClick);
            // 
            // colName
            // 
            this.colName.Text = "Import Name";
            this.colName.Width = 188;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Vendor";
            this.columnHeader5.Width = 137;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Count";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader1.Width = 74;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Notes";
            this.columnHeader4.Width = 90;
            // 
            // mnuPast
            // 
            this.mnuPast.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCount,
            this.mnuViewList,
            this.mnuRename,
            this.mnuEditNotes,
            this.mnuSetAgent,
            this.mnuExport,
            this.toolStripSeparator1,
            this.mnuArchive,
            this.mnuDelete,
            this.mergeListsToolStripMenuItem,
            this.mnuReport,
            this.partCrossReferenceToolStripMenuItem});
            this.mnuPast.Name = "mnuPast";
            this.mnuPast.Size = new System.Drawing.Size(183, 252);
            // 
            // mnuCount
            // 
            this.mnuCount.Name = "mnuCount";
            this.mnuCount.Size = new System.Drawing.Size(182, 22);
            this.mnuCount.Text = "&Count";
            this.mnuCount.Click += new System.EventHandler(this.mnuCount_Click);
            // 
            // mnuViewList
            // 
            this.mnuViewList.Name = "mnuViewList";
            this.mnuViewList.Size = new System.Drawing.Size(182, 22);
            this.mnuViewList.Text = "&View List";
            this.mnuViewList.Click += new System.EventHandler(this.mnuViewList_Click);
            // 
            // mnuRename
            // 
            this.mnuRename.Name = "mnuRename";
            this.mnuRename.Size = new System.Drawing.Size(182, 22);
            this.mnuRename.Text = "&Rename";
            this.mnuRename.Click += new System.EventHandler(this.mnuRename_Click);
            // 
            // mnuEditNotes
            // 
            this.mnuEditNotes.Name = "mnuEditNotes";
            this.mnuEditNotes.Size = new System.Drawing.Size(182, 22);
            this.mnuEditNotes.Text = "Edit Notes";
            this.mnuEditNotes.Click += new System.EventHandler(this.mnuEditNotes_Click);
            // 
            // mnuSetAgent
            // 
            this.mnuSetAgent.Name = "mnuSetAgent";
            this.mnuSetAgent.Size = new System.Drawing.Size(182, 22);
            this.mnuSetAgent.Text = "Set &Agent Name";
            this.mnuSetAgent.Click += new System.EventHandler(this.mnuSetAgent_Click);
            // 
            // mnuExport
            // 
            this.mnuExport.Name = "mnuExport";
            this.mnuExport.Size = new System.Drawing.Size(182, 22);
            this.mnuExport.Text = "&Export";
            this.mnuExport.Click += new System.EventHandler(this.mnuExport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(179, 6);
            // 
            // mnuArchive
            // 
            this.mnuArchive.Name = "mnuArchive";
            this.mnuArchive.Size = new System.Drawing.Size(182, 22);
            this.mnuArchive.Text = "&Archive";
            this.mnuArchive.Click += new System.EventHandler(this.mnuArchive_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(182, 22);
            this.mnuDelete.Text = "&Delete";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // mergeListsToolStripMenuItem
            // 
            this.mergeListsToolStripMenuItem.Name = "mergeListsToolStripMenuItem";
            this.mergeListsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.mergeListsToolStripMenuItem.Text = "Merge Lists";
            this.mergeListsToolStripMenuItem.Click += new System.EventHandler(this.mergeListsToolStripMenuItem_Click);
            // 
            // mnuReport
            // 
            this.mnuReport.Name = "mnuReport";
            this.mnuReport.Size = new System.Drawing.Size(182, 22);
            this.mnuReport.Text = "Re&port";
            this.mnuReport.Click += new System.EventHandler(this.mnuReport_Click);
            // 
            // partCrossReferenceToolStripMenuItem
            // 
            this.partCrossReferenceToolStripMenuItem.Name = "partCrossReferenceToolStripMenuItem";
            this.partCrossReferenceToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.partCrossReferenceToolStripMenuItem.Text = "Part Cross Reference";
            this.partCrossReferenceToolStripMenuItem.Click += new System.EventHandler(this.partCrossReferenceToolStripMenuItem_Click);
            // 
            // pageExports
            // 
            this.pageExports.BackColor = System.Drawing.Color.White;
            this.pageExports.Controls.Add(this.gbOneExport);
            this.pageExports.Controls.Add(this.gbExports);
            this.pageExports.Controls.Add(this.lvExports);
            this.pageExports.Location = new System.Drawing.Point(4, 22);
            this.pageExports.Name = "pageExports";
            this.pageExports.Padding = new System.Windows.Forms.Padding(3);
            this.pageExports.Size = new System.Drawing.Size(967, 518);
            this.pageExports.TabIndex = 2;
            this.pageExports.Text = "Exports";
            // 
            // gbOneExport
            // 
            this.gbOneExport.Controls.Add(this.ctl_exportstring);
            this.gbOneExport.Controls.Add(this.ctl_exporttotext);
            this.gbOneExport.Controls.Add(this.ctl_exportfile);
            this.gbOneExport.Controls.Add(this.ctl_exportname);
            this.gbOneExport.Controls.Add(this.cmdApply);
            this.gbOneExport.Controls.Add(this.cmdCloseExport);
            this.gbOneExport.Location = new System.Drawing.Point(70, 288);
            this.gbOneExport.Name = "gbOneExport";
            this.gbOneExport.Size = new System.Drawing.Size(894, 216);
            this.gbOneExport.TabIndex = 2;
            this.gbOneExport.TabStop = false;
            // 
            // ctl_exportstring
            // 
            this.ctl_exportstring.BackColor = System.Drawing.Color.Transparent;
            this.ctl_exportstring.Bold = false;
            this.ctl_exportstring.Caption = "Query String";
            this.ctl_exportstring.Changed = false;
            this.ctl_exportstring.DateLines = false;
            this.ctl_exportstring.Location = new System.Drawing.Point(9, 63);
            this.ctl_exportstring.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_exportstring.Name = "ctl_exportstring";
            this.ctl_exportstring.Size = new System.Drawing.Size(783, 147);
            this.ctl_exportstring.TabIndex = 5;
            this.ctl_exportstring.UseParentBackColor = true;
            this.ctl_exportstring.zz_Enabled = true;
            this.ctl_exportstring.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_exportstring.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_exportstring.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_exportstring.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_exportstring.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_exportstring.zz_OriginalDesign = true;
            this.ctl_exportstring.zz_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ctl_exportstring.zz_ShowNeedsSaveColor = true;
            this.ctl_exportstring.zz_Text = "";
            this.ctl_exportstring.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_exportstring.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_exportstring.zz_UseGlobalColor = false;
            this.ctl_exportstring.zz_UseGlobalFont = false;
            // 
            // ctl_exporttotext
            // 
            this.ctl_exporttotext.BackColor = System.Drawing.Color.Transparent;
            this.ctl_exporttotext.Bold = false;
            this.ctl_exporttotext.Caption = "Use Plain Text";
            this.ctl_exporttotext.Changed = false;
            this.ctl_exporttotext.Location = new System.Drawing.Point(468, 7);
            this.ctl_exporttotext.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_exporttotext.Name = "ctl_exporttotext";
            this.ctl_exporttotext.Size = new System.Drawing.Size(95, 18);
            this.ctl_exporttotext.TabIndex = 3;
            this.ctl_exporttotext.UseParentBackColor = true;
            this.ctl_exporttotext.zz_CheckValue = false;
            this.ctl_exporttotext.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_exporttotext.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_exporttotext.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_exporttotext.zz_OriginalDesign = false;
            this.ctl_exporttotext.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_exportfile
            // 
            this.ctl_exportfile.AllCaps = false;
            this.ctl_exportfile.BackColor = System.Drawing.Color.Transparent;
            this.ctl_exportfile.Bold = false;
            this.ctl_exportfile.Caption = "Export File Location";
            this.ctl_exportfile.Changed = false;
            this.ctl_exportfile.IsEmail = false;
            this.ctl_exportfile.IsURL = false;
            this.ctl_exportfile.Location = new System.Drawing.Point(283, 16);
            this.ctl_exportfile.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_exportfile.Name = "ctl_exportfile";
            this.ctl_exportfile.PasswordChar = '\0';
            this.ctl_exportfile.Size = new System.Drawing.Size(303, 51);
            this.ctl_exportfile.TabIndex = 4;
            this.ctl_exportfile.UseParentBackColor = true;
            this.ctl_exportfile.zz_Enabled = true;
            this.ctl_exportfile.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_exportfile.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_exportfile.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_exportfile.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_exportfile.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_exportfile.zz_OriginalDesign = true;
            this.ctl_exportfile.zz_ShowLinkButton = false;
            this.ctl_exportfile.zz_ShowNeedsSaveColor = true;
            this.ctl_exportfile.zz_Text = "";
            this.ctl_exportfile.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_exportfile.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_exportfile.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_exportfile.zz_UseGlobalColor = false;
            this.ctl_exportfile.zz_UseGlobalFont = false;
            // 
            // ctl_exportname
            // 
            this.ctl_exportname.AllCaps = false;
            this.ctl_exportname.BackColor = System.Drawing.Color.Transparent;
            this.ctl_exportname.Bold = false;
            this.ctl_exportname.Caption = "Name";
            this.ctl_exportname.Changed = false;
            this.ctl_exportname.IsEmail = false;
            this.ctl_exportname.IsURL = false;
            this.ctl_exportname.Location = new System.Drawing.Point(8, 16);
            this.ctl_exportname.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_exportname.Name = "ctl_exportname";
            this.ctl_exportname.PasswordChar = '\0';
            this.ctl_exportname.Size = new System.Drawing.Size(269, 51);
            this.ctl_exportname.TabIndex = 2;
            this.ctl_exportname.UseParentBackColor = true;
            this.ctl_exportname.zz_Enabled = true;
            this.ctl_exportname.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_exportname.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_exportname.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_exportname.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_exportname.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_exportname.zz_OriginalDesign = true;
            this.ctl_exportname.zz_ShowLinkButton = false;
            this.ctl_exportname.zz_ShowNeedsSaveColor = true;
            this.ctl_exportname.zz_Text = "";
            this.ctl_exportname.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_exportname.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_exportname.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_exportname.zz_UseGlobalColor = false;
            this.ctl_exportname.zz_UseGlobalFont = false;
            // 
            // cmdApply
            // 
            this.cmdApply.Location = new System.Drawing.Point(592, 28);
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(124, 21);
            this.cmdApply.TabIndex = 1;
            this.cmdApply.Text = "Apply";
            this.cmdApply.UseVisualStyleBackColor = true;
            this.cmdApply.Click += new System.EventHandler(this.cmdApply_Click);
            // 
            // cmdCloseExport
            // 
            this.cmdCloseExport.Location = new System.Drawing.Point(722, 28);
            this.cmdCloseExport.Name = "cmdCloseExport";
            this.cmdCloseExport.Size = new System.Drawing.Size(26, 20);
            this.cmdCloseExport.TabIndex = 0;
            this.cmdCloseExport.Text = "x";
            this.cmdCloseExport.UseVisualStyleBackColor = true;
            this.cmdCloseExport.Click += new System.EventHandler(this.cmdCloseExport_Click);
            // 
            // gbExports
            // 
            this.gbExports.Controls.Add(this.throbExport);
            this.gbExports.Controls.Add(this.cmdNew);
            this.gbExports.Location = new System.Drawing.Point(6, 6);
            this.gbExports.Name = "gbExports";
            this.gbExports.Size = new System.Drawing.Size(58, 499);
            this.gbExports.TabIndex = 1;
            this.gbExports.TabStop = false;
            // 
            // throbExport
            // 
            this.throbExport.BackColor = System.Drawing.Color.White;
            this.throbExport.Location = new System.Drawing.Point(8, 46);
            this.throbExport.Margin = new System.Windows.Forms.Padding(4);
            this.throbExport.Name = "throbExport";
            this.throbExport.Size = new System.Drawing.Size(42, 30);
            this.throbExport.TabIndex = 1;
            this.throbExport.UseParentBackColor = false;
            // 
            // cmdNew
            // 
            this.cmdNew.Location = new System.Drawing.Point(6, 12);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(45, 25);
            this.cmdNew.TabIndex = 0;
            this.cmdNew.Text = "New";
            this.cmdNew.UseVisualStyleBackColor = true;
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // lvExports
            // 
            this.lvExports.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader6,
            this.columnHeader7});
            this.lvExports.ContextMenuStrip = this.mnuExports;
            this.lvExports.FullRowSelect = true;
            this.lvExports.Location = new System.Drawing.Point(70, 6);
            this.lvExports.MultiSelect = false;
            this.lvExports.Name = "lvExports";
            this.lvExports.Size = new System.Drawing.Size(816, 276);
            this.lvExports.TabIndex = 0;
            this.lvExports.UseCompatibleStateImageBehavior = false;
            this.lvExports.View = System.Windows.Forms.View.Details;
            this.lvExports.Click += new System.EventHandler(this.lvExports_Click);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 139;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "File";
            this.columnHeader3.Width = 148;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Type";
            this.columnHeader6.Width = 97;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Query";
            this.columnHeader7.Width = 426;
            // 
            // mnuExports
            // 
            this.mnuExports.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRunExport,
            this.mnuOpenLastExportFile,
            this.toolStripSeparator2,
            this.mnuDeleteExport});
            this.mnuExports.Name = "mnuExports";
            this.mnuExports.Size = new System.Drawing.Size(185, 76);
            // 
            // mnuRunExport
            // 
            this.mnuRunExport.Name = "mnuRunExport";
            this.mnuRunExport.Size = new System.Drawing.Size(184, 22);
            this.mnuRunExport.Text = "&Run";
            this.mnuRunExport.Click += new System.EventHandler(this.mnuRunExport_Click);
            // 
            // mnuOpenLastExportFile
            // 
            this.mnuOpenLastExportFile.Name = "mnuOpenLastExportFile";
            this.mnuOpenLastExportFile.Size = new System.Drawing.Size(184, 22);
            this.mnuOpenLastExportFile.Text = "&Open Last Export File";
            this.mnuOpenLastExportFile.Click += new System.EventHandler(this.mnuOpenLastExportFile_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(181, 6);
            // 
            // mnuDeleteExport
            // 
            this.mnuDeleteExport.Name = "mnuDeleteExport";
            this.mnuDeleteExport.Size = new System.Drawing.Size(184, 22);
            this.mnuDeleteExport.Text = "&Delete";
            this.mnuDeleteExport.Click += new System.EventHandler(this.mnuDeleteExport_Click);
            // 
            // bgImport
            // 
            this.bgImport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgImport_DoWork);
            this.bgImport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgImport_RunWorkerCompleted);
            // 
            // bgList
            // 
            this.bgList.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgList_DoWork);
            this.bgList.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgList_RunWorkerCompleted);
            // 
            // bgExport
            // 
            this.bgExport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgExport_DoWork);
            this.bgExport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgExport_RunWorkerCompleted);
            // 
            // bgMergeImports
            // 
            this.bgMergeImports.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgMergeImports_DoWork);
            this.bgMergeImports.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgMergeImports_RunWorkerCompleted);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // bgwUpdate
            // 
            this.bgwUpdate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwUpdate_DoWork);
            this.bgwUpdate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwUpdate_RunWorkerCompleted);
            // 
            // bwIndex
            // 
            this.bwIndex.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwIndex_DoWork);
            this.bwIndex.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwIndex_RunWorkerCompleted);
            // 
            // optOffers
            // 
            this.optOffers.AutoSize = true;
            this.optOffers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optOffers.Location = new System.Drawing.Point(376, 15);
            this.optOffers.Name = "optOffers";
            this.optOffers.Size = new System.Drawing.Size(63, 24);
            this.optOffers.TabIndex = 9;
            this.optOffers.TabStop = true;
            this.optOffers.Text = "Offer";
            this.optOffers.UseVisualStyleBackColor = true;
            // 
            // ImportInventoryScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ts);
            this.Name = "ImportInventoryScreen";
            this.Size = new System.Drawing.Size(975, 544);
            this.Resize += new System.EventHandler(this.PartsImport_Resize);
            this.ts.ResumeLayout(false);
            this.pageNewItems.ResumeLayout(false);
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.pagePast.ResumeLayout(false);
            this.gbPast.ResumeLayout(false);
            this.gbPast.PerformLayout();
            this.mnuPast.ResumeLayout(false);
            this.pageExports.ResumeLayout(false);
            this.gbOneExport.ResumeLayout(false);
            this.gbExports.ResumeLayout(false);
            this.mnuExports.ResumeLayout(false);
            this.ResumeLayout(false);

}

        #endregion

        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ToolStripMenuItem mnuCount;
        private System.Windows.Forms.ToolStripMenuItem mnuViewList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private NewMethod.nThrobber throb;
        private System.Windows.Forms.ToolStripMenuItem mnuSetAgent;
        private System.Windows.Forms.ToolStripMenuItem mnuRename;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ToolStripMenuItem mnuRunExport;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenLastExportFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteExport;
        private NewMethod.nThrobber throbExport;
        private System.Windows.Forms.ToolStripMenuItem mnuExport;
        private System.Windows.Forms.ToolStripMenuItem mergeListsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuReport;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ToolStripMenuItem mnuEditNotes;
        private System.Windows.Forms.ToolStripMenuItem partCrossReferenceToolStripMenuItem;
        public NewMethod.nDataView dv;
        public System.Windows.Forms.GroupBox gb;
        public NewMethod.nEdit_User chooseuser;
        public NewMethod.nEdit_String txtImportName;
        public System.Windows.Forms.RadioButton optExcess;
        public System.Windows.Forms.RadioButton optStock;
        public CompanyStub_PlusContact cStub;
        public System.Windows.Forms.RadioButton optConsignment;
        public System.ComponentModel.BackgroundWorker bgImport;
        public System.ComponentModel.BackgroundWorker bgList;
        public System.Windows.Forms.ContextMenuStrip mnuPast;
        public System.Windows.Forms.ContextMenuStrip mnuExports;
        public System.ComponentModel.BackgroundWorker bgExport;
        public System.ComponentModel.BackgroundWorker bgMergeImports;
        public System.Windows.Forms.ToolTip toolTip1;
        public System.ComponentModel.BackgroundWorker bgwUpdate;
        public System.Windows.Forms.GroupBox gbPast;
        public NewMethod.nList PastItems;
        public System.Windows.Forms.ListView lvPastImports;
        public System.Windows.Forms.Button cmdRefresh;
        public System.Windows.Forms.Label lblPastStatus;
        public System.Windows.Forms.ListView lvExports;
        public System.Windows.Forms.GroupBox gbOneExport;
        public System.Windows.Forms.Button cmdCloseExport;
        public System.Windows.Forms.GroupBox gbExports;
        public System.Windows.Forms.Button cmdApply;
        public NewMethod.nEdit_String ctl_exportfile;
        public NewMethod.nEdit_Boolean ctl_exporttotext;
        public NewMethod.nEdit_String ctl_exportname;
        public NewMethod.nEdit_Memo ctl_exportstring;
        public System.Windows.Forms.Button cmdNew;
        public System.Windows.Forms.Button cmdDeleteOfferImport;
        public System.Windows.Forms.Button cmdUpdateAllLists;
        public System.Windows.Forms.ToolStripMenuItem mnuArchive;
        public System.Windows.Forms.TabControl ts;
        public System.Windows.Forms.TabPage pageNewItems;
        public System.Windows.Forms.TabPage pagePast;
        public System.Windows.Forms.TabPage pageExports;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        public System.ComponentModel.BackgroundWorker bwIndex;
        public System.Windows.Forms.RadioButton optMaster;
        private NewMethod.nEdit_List ctl_consigncodes;
        private NewMethod.nEdit_List ctl_purchase_orders;
        public System.Windows.Forms.RadioButton optOffers;
    }
}
