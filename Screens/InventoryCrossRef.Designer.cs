namespace Rz5
{
    partial class InventoryCrossRef
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
            this.gbOptions = new System.Windows.Forms.GroupBox();
            this.btnDetailEmail = new System.Windows.Forms.Button();
            this.dtPartsAddedAfterDate = new NewMethod.nEdit_Date();
            this.btnSummaryEmail = new System.Windows.Forms.Button();
            this.pAgents = new System.Windows.Forms.Panel();
            this.lblAgents = new System.Windows.Forms.Label();
            this.lblClearAgents = new System.Windows.Forms.LinkLabel();
            this.lblChooseAgents = new System.Windows.Forms.LinkLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.optBoth = new System.Windows.Forms.RadioButton();
            this.optReqQuotes = new System.Windows.Forms.RadioButton();
            this.optSales = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkOffers = new System.Windows.Forms.CheckBox();
            this.cbxAlternates = new System.Windows.Forms.CheckBox();
            this.chkExcess = new System.Windows.Forms.CheckBox();
            this.chkStock = new System.Windows.Forms.CheckBox();
            this.chkConsign = new System.Windows.Forms.CheckBox();
            this.dtEnd = new NewMethod.nEdit_Date();
            this.cmdView = new System.Windows.Forms.Button();
            this.dtStart = new NewMethod.nEdit_Date();
            this.ts = new System.Windows.Forms.TabControl();
            this.tabReqsQuotes = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvQuotes = new NewMethod.nList();
            this.lvQuoteParts = new NewMethod.nList();
            this.tabSales = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lvSales = new NewMethod.nList();
            this.lvSalesParts = new NewMethod.nList();
            this.bgw = new System.ComponentModel.BackgroundWorker();
            this.pbTop = new System.Windows.Forms.PictureBox();
            this.pbBottom = new System.Windows.Forms.PictureBox();
            this.pbRight = new System.Windows.Forms.PictureBox();
            this.pbLeft = new System.Windows.Forms.PictureBox();
            this.pnlMatchType = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.rbExact = new System.Windows.Forms.RadioButton();
            this.rbFuzzy = new System.Windows.Forms.RadioButton();
            this.gbOptions.SuspendLayout();
            this.pAgents.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.ts.SuspendLayout();
            this.tabReqsQuotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).BeginInit();
            this.pnlMatchType.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbOptions
            // 
            this.gbOptions.Controls.Add(this.pnlMatchType);
            this.gbOptions.Controls.Add(this.btnDetailEmail);
            this.gbOptions.Controls.Add(this.dtPartsAddedAfterDate);
            this.gbOptions.Controls.Add(this.btnSummaryEmail);
            this.gbOptions.Controls.Add(this.pAgents);
            this.gbOptions.Controls.Add(this.panel2);
            this.gbOptions.Controls.Add(this.panel1);
            this.gbOptions.Controls.Add(this.dtEnd);
            this.gbOptions.Controls.Add(this.cmdView);
            this.gbOptions.Controls.Add(this.dtStart);
            this.gbOptions.Location = new System.Drawing.Point(13, 16);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Size = new System.Drawing.Size(217, 533);
            this.gbOptions.TabIndex = 38;
            this.gbOptions.TabStop = false;
            // 
            // btnDetailEmail
            // 
            this.btnDetailEmail.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetailEmail.Location = new System.Drawing.Point(7, 452);
            this.btnDetailEmail.Name = "btnDetailEmail";
            this.btnDetailEmail.Size = new System.Drawing.Size(201, 31);
            this.btnDetailEmail.TabIndex = 49;
            this.btnDetailEmail.Text = "Customer Email";
            this.btnDetailEmail.UseVisualStyleBackColor = true;
            this.btnDetailEmail.Click += new System.EventHandler(this.btnCustomerEmail_Click);
            // 
            // dtPartsAddedAfterDate
            // 
            this.dtPartsAddedAfterDate.AllowClear = false;
            this.dtPartsAddedAfterDate.BackColor = System.Drawing.Color.White;
            this.dtPartsAddedAfterDate.Bold = false;
            this.dtPartsAddedAfterDate.Caption = "Parts added after:";
            this.dtPartsAddedAfterDate.Changed = false;
            this.dtPartsAddedAfterDate.Location = new System.Drawing.Point(6, 270);
            this.dtPartsAddedAfterDate.Margin = new System.Windows.Forms.Padding(5);
            this.dtPartsAddedAfterDate.Name = "dtPartsAddedAfterDate";
            this.dtPartsAddedAfterDate.Size = new System.Drawing.Size(202, 50);
            this.dtPartsAddedAfterDate.SuppressEdit = false;
            this.dtPartsAddedAfterDate.TabIndex = 48;
            this.dtPartsAddedAfterDate.UseParentBackColor = true;
            this.dtPartsAddedAfterDate.zz_GlobalColor = System.Drawing.Color.Black;
            this.dtPartsAddedAfterDate.zz_GlobalFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPartsAddedAfterDate.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.dtPartsAddedAfterDate.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPartsAddedAfterDate.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.dtPartsAddedAfterDate.zz_OriginalDesign = false;
            this.dtPartsAddedAfterDate.zz_ShowNeedsSaveColor = true;
            this.dtPartsAddedAfterDate.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.dtPartsAddedAfterDate.zz_TextFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPartsAddedAfterDate.zz_UseGlobalColor = false;
            this.dtPartsAddedAfterDate.zz_UseGlobalFont = false;
            // 
            // btnSummaryEmail
            // 
            this.btnSummaryEmail.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSummaryEmail.Location = new System.Drawing.Point(5, 416);
            this.btnSummaryEmail.Name = "btnSummaryEmail";
            this.btnSummaryEmail.Size = new System.Drawing.Size(201, 31);
            this.btnSummaryEmail.TabIndex = 47;
            this.btnSummaryEmail.Text = "Summary Email";
            this.btnSummaryEmail.UseVisualStyleBackColor = true;
            this.btnSummaryEmail.Click += new System.EventHandler(this.btnSummaryEmail_Click);
            // 
            // pAgents
            // 
            this.pAgents.BackColor = System.Drawing.Color.Gainsboro;
            this.pAgents.Controls.Add(this.lblAgents);
            this.pAgents.Controls.Add(this.lblClearAgents);
            this.pAgents.Controls.Add(this.lblChooseAgents);
            this.pAgents.Location = new System.Drawing.Point(6, 328);
            this.pAgents.Name = "pAgents";
            this.pAgents.Size = new System.Drawing.Size(202, 44);
            this.pAgents.TabIndex = 46;
            // 
            // lblAgents
            // 
            this.lblAgents.AutoSize = true;
            this.lblAgents.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgents.Location = new System.Drawing.Point(3, 1);
            this.lblAgents.Name = "lblAgents";
            this.lblAgents.Size = new System.Drawing.Size(51, 18);
            this.lblAgents.TabIndex = 46;
            this.lblAgents.Text = "Agents";
            // 
            // lblClearAgents
            // 
            this.lblClearAgents.AutoSize = true;
            this.lblClearAgents.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClearAgents.Location = new System.Drawing.Point(161, 1);
            this.lblClearAgents.Name = "lblClearAgents";
            this.lblClearAgents.Size = new System.Drawing.Size(38, 18);
            this.lblClearAgents.TabIndex = 48;
            this.lblClearAgents.TabStop = true;
            this.lblClearAgents.Text = "clear";
            this.lblClearAgents.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblClearAgents_LinkClicked);
            // 
            // lblChooseAgents
            // 
            this.lblChooseAgents.AutoSize = true;
            this.lblChooseAgents.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseAgents.Location = new System.Drawing.Point(3, 21);
            this.lblChooseAgents.Name = "lblChooseAgents";
            this.lblChooseAgents.Size = new System.Drawing.Size(172, 18);
            this.lblChooseAgents.TabIndex = 47;
            this.lblChooseAgents.TabStop = true;
            this.lblChooseAgents.Text = "<click to choose agent list>";
            this.lblChooseAgents.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblChooseAgents_LinkClicked);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.optBoth);
            this.panel2.Controls.Add(this.optReqQuotes);
            this.panel2.Controls.Add(this.optSales);
            this.panel2.Location = new System.Drawing.Point(6, 176);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(202, 35);
            this.panel2.TabIndex = 45;
            // 
            // optBoth
            // 
            this.optBoth.AutoSize = true;
            this.optBoth.Checked = true;
            this.optBoth.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optBoth.Location = new System.Drawing.Point(5, 4);
            this.optBoth.Name = "optBoth";
            this.optBoth.Size = new System.Drawing.Size(47, 17);
            this.optBoth.TabIndex = 44;
            this.optBoth.TabStop = true;
            this.optBoth.Text = "Both";
            this.optBoth.UseVisualStyleBackColor = true;
            // 
            // optReqQuotes
            // 
            this.optReqQuotes.AutoSize = true;
            this.optReqQuotes.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optReqQuotes.Location = new System.Drawing.Point(60, 4);
            this.optReqQuotes.Name = "optReqQuotes";
            this.optReqQuotes.Size = new System.Drawing.Size(86, 17);
            this.optReqQuotes.TabIndex = 41;
            this.optReqQuotes.Text = "Reqs/Quotes";
            this.optReqQuotes.UseVisualStyleBackColor = true;
            // 
            // optSales
            // 
            this.optSales.AutoSize = true;
            this.optSales.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optSales.Location = new System.Drawing.Point(151, 3);
            this.optSales.Name = "optSales";
            this.optSales.Size = new System.Drawing.Size(48, 17);
            this.optSales.TabIndex = 43;
            this.optSales.Text = "Sales";
            this.optSales.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.chkOffers);
            this.panel1.Controls.Add(this.cbxAlternates);
            this.panel1.Controls.Add(this.chkExcess);
            this.panel1.Controls.Add(this.chkStock);
            this.panel1.Controls.Add(this.chkConsign);
            this.panel1.Location = new System.Drawing.Point(6, 118);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(202, 50);
            this.panel1.TabIndex = 42;
            // 
            // chkOffers
            // 
            this.chkOffers.AutoSize = true;
            this.chkOffers.Checked = true;
            this.chkOffers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOffers.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOffers.Location = new System.Drawing.Point(5, 26);
            this.chkOffers.Name = "chkOffers";
            this.chkOffers.Size = new System.Drawing.Size(60, 19);
            this.chkOffers.TabIndex = 47;
            this.chkOffers.Text = "Offers";
            this.chkOffers.UseVisualStyleBackColor = true;
            // 
            // cbxAlternates
            // 
            this.cbxAlternates.AutoSize = true;
            this.cbxAlternates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxAlternates.Location = new System.Drawing.Point(69, 28);
            this.cbxAlternates.Name = "cbxAlternates";
            this.cbxAlternates.Size = new System.Drawing.Size(127, 17);
            this.cbxAlternates.TabIndex = 46;
            this.cbxAlternates.Text = "Search Alternates";
            this.cbxAlternates.UseVisualStyleBackColor = true;
            // 
            // chkExcess
            // 
            this.chkExcess.AutoSize = true;
            this.chkExcess.Checked = true;
            this.chkExcess.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExcess.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExcess.Location = new System.Drawing.Point(141, 4);
            this.chkExcess.Name = "chkExcess";
            this.chkExcess.Size = new System.Drawing.Size(60, 19);
            this.chkExcess.TabIndex = 44;
            this.chkExcess.Text = "Excess";
            this.chkExcess.UseVisualStyleBackColor = true;
            // 
            // chkStock
            // 
            this.chkStock.AutoSize = true;
            this.chkStock.Checked = true;
            this.chkStock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStock.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStock.Location = new System.Drawing.Point(5, 4);
            this.chkStock.Name = "chkStock";
            this.chkStock.Size = new System.Drawing.Size(55, 19);
            this.chkStock.TabIndex = 40;
            this.chkStock.Text = "Stock";
            this.chkStock.UseVisualStyleBackColor = true;
            // 
            // chkConsign
            // 
            this.chkConsign.AutoSize = true;
            this.chkConsign.Checked = true;
            this.chkConsign.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConsign.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkConsign.Location = new System.Drawing.Point(60, 4);
            this.chkConsign.Name = "chkConsign";
            this.chkConsign.Size = new System.Drawing.Size(82, 19);
            this.chkConsign.TabIndex = 43;
            this.chkConsign.Text = "Consigned";
            this.chkConsign.UseVisualStyleBackColor = true;
            // 
            // dtEnd
            // 
            this.dtEnd.AllowClear = false;
            this.dtEnd.BackColor = System.Drawing.Color.White;
            this.dtEnd.Bold = false;
            this.dtEnd.Caption = "End Date";
            this.dtEnd.Changed = false;
            this.dtEnd.Location = new System.Drawing.Point(5, 65);
            this.dtEnd.Margin = new System.Windows.Forms.Padding(5);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(202, 50);
            this.dtEnd.SuppressEdit = false;
            this.dtEnd.TabIndex = 39;
            this.dtEnd.UseParentBackColor = true;
            this.dtEnd.zz_GlobalColor = System.Drawing.Color.Black;
            this.dtEnd.zz_GlobalFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEnd.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.dtEnd.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEnd.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.dtEnd.zz_OriginalDesign = false;
            this.dtEnd.zz_ShowNeedsSaveColor = true;
            this.dtEnd.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.dtEnd.zz_TextFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEnd.zz_UseGlobalColor = false;
            this.dtEnd.zz_UseGlobalFont = false;
            // 
            // cmdView
            // 
            this.cmdView.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdView.Location = new System.Drawing.Point(6, 379);
            this.cmdView.Name = "cmdView";
            this.cmdView.Size = new System.Drawing.Size(201, 31);
            this.cmdView.TabIndex = 38;
            this.cmdView.Text = "View";
            this.cmdView.UseVisualStyleBackColor = true;
            this.cmdView.Click += new System.EventHandler(this.cmdView_Click);
            // 
            // dtStart
            // 
            this.dtStart.AllowClear = false;
            this.dtStart.BackColor = System.Drawing.Color.White;
            this.dtStart.Bold = false;
            this.dtStart.Caption = "Start Date";
            this.dtStart.Changed = false;
            this.dtStart.Location = new System.Drawing.Point(5, 14);
            this.dtStart.Margin = new System.Windows.Forms.Padding(5);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(202, 50);
            this.dtStart.SuppressEdit = false;
            this.dtStart.TabIndex = 37;
            this.dtStart.UseParentBackColor = true;
            this.dtStart.zz_GlobalColor = System.Drawing.Color.Black;
            this.dtStart.zz_GlobalFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStart.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.dtStart.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStart.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.dtStart.zz_OriginalDesign = false;
            this.dtStart.zz_ShowNeedsSaveColor = true;
            this.dtStart.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.dtStart.zz_TextFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStart.zz_UseGlobalColor = false;
            this.dtStart.zz_UseGlobalFont = false;
            // 
            // ts
            // 
            this.ts.Controls.Add(this.tabReqsQuotes);
            this.ts.Controls.Add(this.tabSales);
            this.ts.Location = new System.Drawing.Point(267, 16);
            this.ts.Name = "ts";
            this.ts.SelectedIndex = 0;
            this.ts.Size = new System.Drawing.Size(540, 405);
            this.ts.TabIndex = 39;
            // 
            // tabReqsQuotes
            // 
            this.tabReqsQuotes.Controls.Add(this.splitContainer1);
            this.tabReqsQuotes.Location = new System.Drawing.Point(4, 22);
            this.tabReqsQuotes.Name = "tabReqsQuotes";
            this.tabReqsQuotes.Padding = new System.Windows.Forms.Padding(3);
            this.tabReqsQuotes.Size = new System.Drawing.Size(532, 379);
            this.tabReqsQuotes.TabIndex = 0;
            this.tabReqsQuotes.Text = "Reqs/Quotes";
            this.tabReqsQuotes.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvQuotes);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvQuoteParts);
            this.splitContainer1.Size = new System.Drawing.Size(526, 373);
            this.splitContainer1.SplitterDistance = 251;
            this.splitContainer1.TabIndex = 0;
            // 
            // lvQuotes
            // 
            this.lvQuotes.AddCaption = "Add New";
            this.lvQuotes.AllowActions = true;
            this.lvQuotes.AllowAdd = false;
            this.lvQuotes.AllowDelete = true;
            this.lvQuotes.AllowDeleteAlways = false;
            this.lvQuotes.AllowDrop = true;
            this.lvQuotes.AllowOnlyOpenDelete = false;
            this.lvQuotes.AlternateConnection = null;
            this.lvQuotes.BackColor = System.Drawing.Color.White;
            this.lvQuotes.Caption = "";
            this.lvQuotes.CurrentTemplate = null;
            this.lvQuotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvQuotes.ExtraClassInfo = "";
            this.lvQuotes.Location = new System.Drawing.Point(0, 0);
            this.lvQuotes.Margin = new System.Windows.Forms.Padding(4);
            this.lvQuotes.MultiSelect = true;
            this.lvQuotes.Name = "lvQuotes";
            this.lvQuotes.Size = new System.Drawing.Size(526, 251);
            this.lvQuotes.SuppressSelectionChanged = false;
            this.lvQuotes.TabIndex = 0;
            this.lvQuotes.zz_OpenColumnMenu = false;
            this.lvQuotes.zz_OrderLineType = "";
            this.lvQuotes.zz_ShowAutoRefresh = true;
            this.lvQuotes.zz_ShowUnlimited = true;
            this.lvQuotes.ObjectClicked += new NewMethod.ObjectClickHandler(this.lvQuotes_ObjectClicked);
            // 
            // lvQuoteParts
            // 
            this.lvQuoteParts.AddCaption = "Add New";
            this.lvQuoteParts.AllowActions = true;
            this.lvQuoteParts.AllowAdd = false;
            this.lvQuoteParts.AllowDelete = true;
            this.lvQuoteParts.AllowDeleteAlways = false;
            this.lvQuoteParts.AllowDrop = true;
            this.lvQuoteParts.AllowOnlyOpenDelete = false;
            this.lvQuoteParts.AlternateConnection = null;
            this.lvQuoteParts.BackColor = System.Drawing.Color.White;
            this.lvQuoteParts.Caption = "";
            this.lvQuoteParts.CurrentTemplate = null;
            this.lvQuoteParts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvQuoteParts.ExtraClassInfo = "";
            this.lvQuoteParts.Location = new System.Drawing.Point(0, 0);
            this.lvQuoteParts.Margin = new System.Windows.Forms.Padding(4);
            this.lvQuoteParts.MultiSelect = true;
            this.lvQuoteParts.Name = "lvQuoteParts";
            this.lvQuoteParts.Size = new System.Drawing.Size(526, 118);
            this.lvQuoteParts.SuppressSelectionChanged = false;
            this.lvQuoteParts.TabIndex = 1;
            this.lvQuoteParts.zz_OpenColumnMenu = false;
            this.lvQuoteParts.zz_OrderLineType = "";
            this.lvQuoteParts.zz_ShowAutoRefresh = true;
            this.lvQuoteParts.zz_ShowUnlimited = true;
            // 
            // tabSales
            // 
            this.tabSales.Controls.Add(this.splitContainer2);
            this.tabSales.Location = new System.Drawing.Point(4, 22);
            this.tabSales.Name = "tabSales";
            this.tabSales.Padding = new System.Windows.Forms.Padding(3);
            this.tabSales.Size = new System.Drawing.Size(532, 379);
            this.tabSales.TabIndex = 1;
            this.tabSales.Text = "Sales";
            this.tabSales.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lvSales);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lvSalesParts);
            this.splitContainer2.Size = new System.Drawing.Size(526, 373);
            this.splitContainer2.SplitterDistance = 247;
            this.splitContainer2.TabIndex = 1;
            // 
            // lvSales
            // 
            this.lvSales.AddCaption = "Add New";
            this.lvSales.AllowActions = true;
            this.lvSales.AllowAdd = false;
            this.lvSales.AllowDelete = true;
            this.lvSales.AllowDeleteAlways = false;
            this.lvSales.AllowDrop = true;
            this.lvSales.AllowOnlyOpenDelete = false;
            this.lvSales.AlternateConnection = null;
            this.lvSales.BackColor = System.Drawing.Color.White;
            this.lvSales.Caption = "";
            this.lvSales.CurrentTemplate = null;
            this.lvSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSales.ExtraClassInfo = "";
            this.lvSales.Location = new System.Drawing.Point(0, 0);
            this.lvSales.Margin = new System.Windows.Forms.Padding(4);
            this.lvSales.MultiSelect = true;
            this.lvSales.Name = "lvSales";
            this.lvSales.Size = new System.Drawing.Size(526, 247);
            this.lvSales.SuppressSelectionChanged = false;
            this.lvSales.TabIndex = 0;
            this.lvSales.zz_OpenColumnMenu = false;
            this.lvSales.zz_OrderLineType = "sales";
            this.lvSales.zz_ShowAutoRefresh = true;
            this.lvSales.zz_ShowUnlimited = true;
            this.lvSales.AboutToThrow += new Core.ShowHandler(this.lvSales_AboutToThrow);
            this.lvSales.ObjectClicked += new NewMethod.ObjectClickHandler(this.lvSales_ObjectClicked);
            // 
            // lvSalesParts
            // 
            this.lvSalesParts.AddCaption = "Add New";
            this.lvSalesParts.AllowActions = true;
            this.lvSalesParts.AllowAdd = false;
            this.lvSalesParts.AllowDelete = true;
            this.lvSalesParts.AllowDeleteAlways = false;
            this.lvSalesParts.AllowDrop = true;
            this.lvSalesParts.AllowOnlyOpenDelete = false;
            this.lvSalesParts.AlternateConnection = null;
            this.lvSalesParts.BackColor = System.Drawing.Color.White;
            this.lvSalesParts.Caption = "";
            this.lvSalesParts.CurrentTemplate = null;
            this.lvSalesParts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSalesParts.ExtraClassInfo = "";
            this.lvSalesParts.Location = new System.Drawing.Point(0, 0);
            this.lvSalesParts.Margin = new System.Windows.Forms.Padding(4);
            this.lvSalesParts.MultiSelect = true;
            this.lvSalesParts.Name = "lvSalesParts";
            this.lvSalesParts.Size = new System.Drawing.Size(526, 122);
            this.lvSalesParts.SuppressSelectionChanged = false;
            this.lvSalesParts.TabIndex = 1;
            this.lvSalesParts.zz_OpenColumnMenu = false;
            this.lvSalesParts.zz_OrderLineType = "";
            this.lvSalesParts.zz_ShowAutoRefresh = true;
            this.lvSalesParts.zz_ShowUnlimited = true;
            // 
            // bgw
            // 
            this.bgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            this.bgw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted);
            // 
            // pbTop
            // 
            this.pbTop.BackColor = System.Drawing.Color.Black;
            this.pbTop.Location = new System.Drawing.Point(747, 456);
            this.pbTop.Name = "pbTop";
            this.pbTop.Size = new System.Drawing.Size(12, 12);
            this.pbTop.TabIndex = 33;
            this.pbTop.TabStop = false;
            // 
            // pbBottom
            // 
            this.pbBottom.BackColor = System.Drawing.Color.Black;
            this.pbBottom.Location = new System.Drawing.Point(747, 438);
            this.pbBottom.Name = "pbBottom";
            this.pbBottom.Size = new System.Drawing.Size(12, 12);
            this.pbBottom.TabIndex = 34;
            this.pbBottom.TabStop = false;
            // 
            // pbRight
            // 
            this.pbRight.BackColor = System.Drawing.Color.Black;
            this.pbRight.Location = new System.Drawing.Point(729, 438);
            this.pbRight.Name = "pbRight";
            this.pbRight.Size = new System.Drawing.Size(12, 12);
            this.pbRight.TabIndex = 35;
            this.pbRight.TabStop = false;
            // 
            // pbLeft
            // 
            this.pbLeft.BackColor = System.Drawing.Color.Black;
            this.pbLeft.Location = new System.Drawing.Point(729, 456);
            this.pbLeft.Name = "pbLeft";
            this.pbLeft.Size = new System.Drawing.Size(12, 12);
            this.pbLeft.TabIndex = 36;
            this.pbLeft.TabStop = false;
            // 
            // pnlMatchType
            // 
            this.pnlMatchType.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlMatchType.Controls.Add(this.label1);
            this.pnlMatchType.Controls.Add(this.rbExact);
            this.pnlMatchType.Controls.Add(this.rbFuzzy);
            this.pnlMatchType.Location = new System.Drawing.Point(7, 215);
            this.pnlMatchType.Name = "pnlMatchType";
            this.pnlMatchType.Size = new System.Drawing.Size(202, 47);
            this.pnlMatchType.TabIndex = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Match Type:";
            // 
            // rbExact
            // 
            this.rbExact.AutoSize = true;
            this.rbExact.Checked = true;
            this.rbExact.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbExact.Location = new System.Drawing.Point(5, 23);
            this.rbExact.Name = "rbExact";
            this.rbExact.Size = new System.Drawing.Size(49, 17);
            this.rbExact.TabIndex = 46;
            this.rbExact.TabStop = true;
            this.rbExact.Text = "Exact";
            this.rbExact.UseVisualStyleBackColor = true;
            // 
            // rbFuzzy
            // 
            this.rbFuzzy.AutoSize = true;
            this.rbFuzzy.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFuzzy.Location = new System.Drawing.Point(60, 23);
            this.rbFuzzy.Name = "rbFuzzy";
            this.rbFuzzy.Size = new System.Drawing.Size(49, 17);
            this.rbFuzzy.TabIndex = 45;
            this.rbFuzzy.Text = "Fuzzy";
            this.rbFuzzy.UseVisualStyleBackColor = true;
            // 
            // InventoryCrossRef
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ts);
            this.Controls.Add(this.gbOptions);
            this.Controls.Add(this.pbLeft);
            this.Controls.Add(this.pbRight);
            this.Controls.Add(this.pbBottom);
            this.Controls.Add(this.pbTop);
            this.Name = "InventoryCrossRef";
            this.Size = new System.Drawing.Size(870, 601);
            this.Resize += new System.EventHandler(this.InventoryCrossRef_Resize);
            this.gbOptions.ResumeLayout(false);
            this.pAgents.ResumeLayout(false);
            this.pAgents.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ts.ResumeLayout(false);
            this.tabReqsQuotes.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabSales.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).EndInit();
            this.pnlMatchType.ResumeLayout(false);
            this.pnlMatchType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        protected NewMethod.nEdit_Date dtStart;
        private System.Windows.Forms.GroupBox gbOptions;
        private System.Windows.Forms.TabControl ts;
        private System.Windows.Forms.TabPage tabReqsQuotes;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private NewMethod.nList lvQuotes;
        private NewMethod.nList lvQuoteParts;
        private System.Windows.Forms.TabPage tabSales;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private NewMethod.nList lvSales;
        private NewMethod.nList lvSalesParts;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkExcess;
        private System.Windows.Forms.CheckBox chkStock;
        private System.Windows.Forms.CheckBox chkConsign;
        private System.Windows.Forms.RadioButton optReqQuotes;
        protected NewMethod.nEdit_Date dtEnd;
        protected System.Windows.Forms.Button cmdView;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton optBoth;
        private System.Windows.Forms.RadioButton optSales;
        private System.ComponentModel.BackgroundWorker bgw;
        private System.Windows.Forms.Panel pAgents;
        public System.Windows.Forms.Label lblAgents;
        public System.Windows.Forms.LinkLabel lblClearAgents;
        public System.Windows.Forms.LinkLabel lblChooseAgents;
        private System.Windows.Forms.CheckBox cbxAlternates;
        private System.Windows.Forms.CheckBox chkOffers;
        protected NewMethod.nEdit_Date dtPartsAddedAfterDate;
        protected System.Windows.Forms.Button btnSummaryEmail;
        protected System.Windows.Forms.Button btnDetailEmail;
        private System.Windows.Forms.PictureBox pbTop;
        private System.Windows.Forms.PictureBox pbBottom;
        private System.Windows.Forms.PictureBox pbRight;
        private System.Windows.Forms.PictureBox pbLeft;
        private System.Windows.Forms.Panel pnlMatchType;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbExact;
        private System.Windows.Forms.RadioButton rbFuzzy;
    }
}
