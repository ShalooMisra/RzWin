using NewMethod;

namespace Rz5
{
    partial class PhoneReport
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
            this.lv = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pageDetail = new System.Windows.Forms.TabPage();
            this.cmdPrint = new System.Windows.Forms.Button();
            this.cmdTestCall = new System.Windows.Forms.Button();
            this.cmdExtensions = new System.Windows.Forms.Button();
            this.pageSummary = new System.Windows.Forms.TabPage();
            this.cmdShowInIE = new System.Windows.Forms.Button();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.wb = new ToolsWin.BrowserPlain();
            this.ts = new System.Windows.Forms.TabControl();
            this.pageWeekly = new System.Windows.Forms.TabPage();
            this.pageYearly = new System.Windows.Forms.TabPage();
            this.gbOptions = new System.Windows.Forms.GroupBox();
            this.cmdChooseDate = new System.Windows.Forms.Button();
            this.Excel = new System.Windows.Forms.Button();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.gbParams = new System.Windows.Forms.GroupBox();
            this.gbCompanyType = new System.Windows.Forms.GroupBox();
            this.optOnlyDist = new System.Windows.Forms.RadioButton();
            this.optOnlyOEM = new System.Windows.Forms.RadioButton();
            this.optAllTypes = new System.Windows.Forms.RadioButton();
            this.chkOnlyInfo = new System.Windows.Forms.CheckBox();
            this.gbDirection = new System.Windows.Forms.GroupBox();
            this.optOut = new System.Windows.Forms.RadioButton();
            this.optIn = new System.Windows.Forms.RadioButton();
            this.optInOut = new System.Windows.Forms.RadioButton();
            this.cmdList = new System.Windows.Forms.Button();
            this.chkOnlyProspects = new System.Windows.Forms.CheckBox();
            this.chkOnlyCustomers = new System.Windows.Forms.CheckBox();
            this.chkGroupByAgent = new System.Windows.Forms.CheckBox();
            this.cmdNow = new System.Windows.Forms.Button();
            this.cboTeams = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.optHorizontal = new System.Windows.Forms.RadioButton();
            this.optVertical = new System.Windows.Forms.RadioButton();
            this.cmdPrevious = new System.Windows.Forms.Button();
            this.cmdNext = new System.Windows.Forms.Button();
            this.cmdGo = new System.Windows.Forms.Button();
            this.lblChartOND = new System.Windows.Forms.LinkLabel();
            this.lblChartTime = new System.Windows.Forms.LinkLabel();
            this.lblRefreshTotals = new System.Windows.Forms.LinkLabel();
            this.lblApplyCalls = new System.Windows.Forms.LinkLabel();
            this.throb = new NewMethod.nThrobber();
            this.cmdRecalc = new System.Windows.Forms.Button();
            this.lblSummary = new System.Windows.Forms.Label();
            this.tsTime = new System.Windows.Forms.TabControl();
            this.tabDay = new System.Windows.Forms.TabPage();
            this.bgSummary = new System.ComponentModel.BackgroundWorker();
            this.bgYearly = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdNextMonth = new System.Windows.Forms.Button();
            this.cmdThisMonth = new System.Windows.Forms.Button();
            this.cmdLastMonth = new System.Windows.Forms.Button();
            this.dtStart = new NewMethod.nEdit_Date();
            this.dtEnd = new NewMethod.nEdit_Date();
            this.ts.SuspendLayout();
            this.gbOptions.SuspendLayout();
            this.gbParams.SuspendLayout();
            this.gbCompanyType.SuspendLayout();
            this.gbDirection.SuspendLayout();
            this.tsTime.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lv
            // 
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lv.FullRowSelect = true;
            this.lv.HideSelection = false;
            this.lv.Location = new System.Drawing.Point(11, 555);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(197, 91);
            this.lv.TabIndex = 12;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.SelectedIndexChanged += new System.EventHandler(this.lv_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 81;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Time";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 39;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "O, ND";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 47;
            // 
            // pageDetail
            // 
            this.pageDetail.Location = new System.Drawing.Point(4, 22);
            this.pageDetail.Name = "pageDetail";
            this.pageDetail.Padding = new System.Windows.Forms.Padding(3);
            this.pageDetail.Size = new System.Drawing.Size(469, 4);
            this.pageDetail.TabIndex = 0;
            this.pageDetail.Text = "Detail";
            this.pageDetail.UseVisualStyleBackColor = true;
            // 
            // cmdPrint
            // 
            this.cmdPrint.Location = new System.Drawing.Point(11, 687);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(90, 22);
            this.cmdPrint.TabIndex = 13;
            this.cmdPrint.Text = "&Print";
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // cmdTestCall
            // 
            this.cmdTestCall.Location = new System.Drawing.Point(115, 734);
            this.cmdTestCall.Name = "cmdTestCall";
            this.cmdTestCall.Size = new System.Drawing.Size(89, 20);
            this.cmdTestCall.TabIndex = 17;
            this.cmdTestCall.Text = "Test Call";
            this.cmdTestCall.UseVisualStyleBackColor = true;
            this.cmdTestCall.Click += new System.EventHandler(this.cmdTestCall_Click);
            // 
            // cmdExtensions
            // 
            this.cmdExtensions.Enabled = false;
            this.cmdExtensions.Location = new System.Drawing.Point(114, 710);
            this.cmdExtensions.Name = "cmdExtensions";
            this.cmdExtensions.Size = new System.Drawing.Size(90, 22);
            this.cmdExtensions.TabIndex = 16;
            this.cmdExtensions.Text = "&Extensions";
            this.cmdExtensions.UseVisualStyleBackColor = true;
            // 
            // pageSummary
            // 
            this.pageSummary.Location = new System.Drawing.Point(4, 22);
            this.pageSummary.Name = "pageSummary";
            this.pageSummary.Padding = new System.Windows.Forms.Padding(3);
            this.pageSummary.Size = new System.Drawing.Size(469, 4);
            this.pageSummary.TabIndex = 1;
            this.pageSummary.Text = "Summary";
            this.pageSummary.UseVisualStyleBackColor = true;
            // 
            // cmdShowInIE
            // 
            this.cmdShowInIE.Enabled = false;
            this.cmdShowInIE.Location = new System.Drawing.Point(12, 710);
            this.cmdShowInIE.Name = "cmdShowInIE";
            this.cmdShowInIE.Size = new System.Drawing.Size(90, 22);
            this.cmdShowInIE.TabIndex = 15;
            this.cmdShowInIE.Text = "&Show In IE";
            this.cmdShowInIE.UseVisualStyleBackColor = true;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Location = new System.Drawing.Point(114, 686);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(90, 22);
            this.cmdRefresh.TabIndex = 14;
            this.cmdRefresh.Text = "&Refresh";
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // wb
            // 
            this.wb.BackColor = System.Drawing.Color.White;
            this.wb.Location = new System.Drawing.Point(230, 40);
            this.wb.Name = "wb";
            this.wb.ShowControls = false;
            this.wb.Silent = false;
            this.wb.Size = new System.Drawing.Size(477, 490);
            this.wb.TabIndex = 5;
            this.wb.OnNavigate2 += new ToolsWin.OnNavigate2HandlerPlain(this.wb_OnNavigate2);
            // 
            // ts
            // 
            this.ts.Controls.Add(this.pageDetail);
            this.ts.Controls.Add(this.pageSummary);
            this.ts.Controls.Add(this.pageWeekly);
            this.ts.Controls.Add(this.pageYearly);
            this.ts.Location = new System.Drawing.Point(230, 12);
            this.ts.Name = "ts";
            this.ts.SelectedIndex = 0;
            this.ts.Size = new System.Drawing.Size(477, 30);
            this.ts.TabIndex = 4;
            this.ts.SelectedIndexChanged += new System.EventHandler(this.ts_SelectedIndexChanged);
            // 
            // pageWeekly
            // 
            this.pageWeekly.Location = new System.Drawing.Point(4, 22);
            this.pageWeekly.Name = "pageWeekly";
            this.pageWeekly.Padding = new System.Windows.Forms.Padding(3);
            this.pageWeekly.Size = new System.Drawing.Size(469, 4);
            this.pageWeekly.TabIndex = 2;
            this.pageWeekly.Text = "Weekly Overview";
            this.pageWeekly.UseVisualStyleBackColor = true;
            // 
            // pageYearly
            // 
            this.pageYearly.Location = new System.Drawing.Point(4, 22);
            this.pageYearly.Name = "pageYearly";
            this.pageYearly.Padding = new System.Windows.Forms.Padding(3);
            this.pageYearly.Size = new System.Drawing.Size(469, 4);
            this.pageYearly.TabIndex = 3;
            this.pageYearly.Text = "Yearly Overview";
            this.pageYearly.UseVisualStyleBackColor = true;
            // 
            // gbOptions
            // 
            this.gbOptions.AutoSize = true;
            this.gbOptions.Controls.Add(this.cmdChooseDate);
            this.gbOptions.Controls.Add(this.Excel);
            this.gbOptions.Controls.Add(this.txtDate);
            this.gbOptions.Controls.Add(this.gbParams);
            this.gbOptions.Controls.Add(this.lblChartOND);
            this.gbOptions.Controls.Add(this.lblChartTime);
            this.gbOptions.Controls.Add(this.lblRefreshTotals);
            this.gbOptions.Controls.Add(this.lblApplyCalls);
            this.gbOptions.Controls.Add(this.throb);
            this.gbOptions.Controls.Add(this.cmdRecalc);
            this.gbOptions.Controls.Add(this.cmdTestCall);
            this.gbOptions.Controls.Add(this.cmdExtensions);
            this.gbOptions.Controls.Add(this.cmdShowInIE);
            this.gbOptions.Controls.Add(this.cmdRefresh);
            this.gbOptions.Controls.Add(this.cmdPrint);
            this.gbOptions.Controls.Add(this.lv);
            this.gbOptions.Controls.Add(this.lblSummary);
            this.gbOptions.Controls.Add(this.tsTime);
            this.gbOptions.Location = new System.Drawing.Point(5, 5);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Size = new System.Drawing.Size(217, 806);
            this.gbOptions.TabIndex = 3;
            this.gbOptions.TabStop = false;
            // 
            // cmdChooseDate
            // 
            this.cmdChooseDate.Location = new System.Drawing.Point(15, 49);
            this.cmdChooseDate.Name = "cmdChooseDate";
            this.cmdChooseDate.Size = new System.Drawing.Size(28, 20);
            this.cmdChooseDate.TabIndex = 36;
            this.cmdChooseDate.Text = "...";
            this.cmdChooseDate.UseVisualStyleBackColor = true;
            this.cmdChooseDate.Visible = false;
            // 
            // Excel
            // 
            this.Excel.Enabled = false;
            this.Excel.Location = new System.Drawing.Point(13, 666);
            this.Excel.Name = "Excel";
            this.Excel.Size = new System.Drawing.Size(88, 20);
            this.Excel.TabIndex = 31;
            this.Excel.Text = "Excel";
            this.Excel.UseVisualStyleBackColor = true;
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(10, 68);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(50, 20);
            this.txtDate.TabIndex = 33;
            this.txtDate.Text = "txtDateHidden";
            this.txtDate.Visible = false;
            // 
            // gbParams
            // 
            this.gbParams.Controls.Add(this.gbCompanyType);
            this.gbParams.Controls.Add(this.chkOnlyInfo);
            this.gbParams.Controls.Add(this.gbDirection);
            this.gbParams.Controls.Add(this.cmdList);
            this.gbParams.Controls.Add(this.chkOnlyProspects);
            this.gbParams.Controls.Add(this.chkOnlyCustomers);
            this.gbParams.Controls.Add(this.chkGroupByAgent);
            this.gbParams.Controls.Add(this.cmdNow);
            this.gbParams.Controls.Add(this.cboTeams);
            this.gbParams.Controls.Add(this.label1);
            this.gbParams.Controls.Add(this.optHorizontal);
            this.gbParams.Controls.Add(this.optVertical);
            this.gbParams.Controls.Add(this.cmdPrevious);
            this.gbParams.Controls.Add(this.cmdNext);
            this.gbParams.Controls.Add(this.cmdGo);
            this.gbParams.Location = new System.Drawing.Point(1, 281);
            this.gbParams.Name = "gbParams";
            this.gbParams.Size = new System.Drawing.Size(208, 268);
            this.gbParams.TabIndex = 6;
            this.gbParams.TabStop = false;
            // 
            // gbCompanyType
            // 
            this.gbCompanyType.Controls.Add(this.optOnlyDist);
            this.gbCompanyType.Controls.Add(this.optOnlyOEM);
            this.gbCompanyType.Controls.Add(this.optAllTypes);
            this.gbCompanyType.Location = new System.Drawing.Point(6, 177);
            this.gbCompanyType.Name = "gbCompanyType";
            this.gbCompanyType.Size = new System.Drawing.Size(192, 34);
            this.gbCompanyType.TabIndex = 40;
            this.gbCompanyType.TabStop = false;
            this.gbCompanyType.Text = "Company Type";
            // 
            // optOnlyDist
            // 
            this.optOnlyDist.AutoSize = true;
            this.optOnlyDist.Location = new System.Drawing.Point(145, 13);
            this.optOnlyDist.Name = "optOnlyDist";
            this.optOnlyDist.Size = new System.Drawing.Size(43, 17);
            this.optOnlyDist.TabIndex = 2;
            this.optOnlyDist.Text = "Dist";
            this.optOnlyDist.UseVisualStyleBackColor = true;
            // 
            // optOnlyOEM
            // 
            this.optOnlyOEM.AutoSize = true;
            this.optOnlyOEM.Location = new System.Drawing.Point(75, 13);
            this.optOnlyOEM.Name = "optOnlyOEM";
            this.optOnlyOEM.Size = new System.Drawing.Size(66, 17);
            this.optOnlyOEM.TabIndex = 1;
            this.optOnlyOEM.Text = "Non-Dist";
            this.optOnlyOEM.UseVisualStyleBackColor = true;
            // 
            // optAllTypes
            // 
            this.optAllTypes.AutoSize = true;
            this.optAllTypes.Checked = true;
            this.optAllTypes.Location = new System.Drawing.Point(20, 13);
            this.optAllTypes.Name = "optAllTypes";
            this.optAllTypes.Size = new System.Drawing.Size(36, 17);
            this.optAllTypes.TabIndex = 0;
            this.optAllTypes.TabStop = true;
            this.optAllTypes.Text = "All";
            this.optAllTypes.UseVisualStyleBackColor = true;
            // 
            // chkOnlyInfo
            // 
            this.chkOnlyInfo.AutoSize = true;
            this.chkOnlyInfo.Location = new System.Drawing.Point(5, 121);
            this.chkOnlyInfo.Name = "chkOnlyInfo";
            this.chkOnlyInfo.Size = new System.Drawing.Size(93, 17);
            this.chkOnlyInfo.TabIndex = 41;
            this.chkOnlyInfo.Text = "Only With Info";
            this.chkOnlyInfo.UseVisualStyleBackColor = true;
            // 
            // gbDirection
            // 
            this.gbDirection.Controls.Add(this.optOut);
            this.gbDirection.Controls.Add(this.optIn);
            this.gbDirection.Controls.Add(this.optInOut);
            this.gbDirection.Location = new System.Drawing.Point(6, 141);
            this.gbDirection.Name = "gbDirection";
            this.gbDirection.Size = new System.Drawing.Size(192, 34);
            this.gbDirection.TabIndex = 39;
            this.gbDirection.TabStop = false;
            this.gbDirection.Text = "Direction";
            // 
            // optOut
            // 
            this.optOut.AutoSize = true;
            this.optOut.Location = new System.Drawing.Point(145, 13);
            this.optOut.Name = "optOut";
            this.optOut.Size = new System.Drawing.Size(42, 17);
            this.optOut.TabIndex = 2;
            this.optOut.Text = "Out";
            this.optOut.UseVisualStyleBackColor = true;
            // 
            // optIn
            // 
            this.optIn.AutoSize = true;
            this.optIn.Location = new System.Drawing.Point(75, 13);
            this.optIn.Name = "optIn";
            this.optIn.Size = new System.Drawing.Size(34, 17);
            this.optIn.TabIndex = 1;
            this.optIn.Text = "In";
            this.optIn.UseVisualStyleBackColor = true;
            // 
            // optInOut
            // 
            this.optInOut.AutoSize = true;
            this.optInOut.Checked = true;
            this.optInOut.Location = new System.Drawing.Point(20, 13);
            this.optInOut.Name = "optInOut";
            this.optInOut.Size = new System.Drawing.Size(36, 17);
            this.optInOut.TabIndex = 0;
            this.optInOut.TabStop = true;
            this.optInOut.Text = "All";
            this.optInOut.UseVisualStyleBackColor = true;
            // 
            // cmdList
            // 
            this.cmdList.Location = new System.Drawing.Point(112, 95);
            this.cmdList.Name = "cmdList";
            this.cmdList.Size = new System.Drawing.Size(85, 20);
            this.cmdList.TabIndex = 38;
            this.cmdList.Text = "List";
            this.cmdList.UseVisualStyleBackColor = true;
            this.cmdList.Click += new System.EventHandler(this.cmdList_Click);
            // 
            // chkOnlyProspects
            // 
            this.chkOnlyProspects.AutoSize = true;
            this.chkOnlyProspects.Location = new System.Drawing.Point(5, 100);
            this.chkOnlyProspects.Name = "chkOnlyProspects";
            this.chkOnlyProspects.Size = new System.Drawing.Size(97, 17);
            this.chkOnlyProspects.TabIndex = 37;
            this.chkOnlyProspects.Text = "Only Prospects";
            this.chkOnlyProspects.UseVisualStyleBackColor = true;
            // 
            // chkOnlyCustomers
            // 
            this.chkOnlyCustomers.AutoSize = true;
            this.chkOnlyCustomers.Location = new System.Drawing.Point(6, 79);
            this.chkOnlyCustomers.Name = "chkOnlyCustomers";
            this.chkOnlyCustomers.Size = new System.Drawing.Size(99, 17);
            this.chkOnlyCustomers.TabIndex = 36;
            this.chkOnlyCustomers.Text = "Only Customers";
            this.chkOnlyCustomers.UseVisualStyleBackColor = true;
            // 
            // chkGroupByAgent
            // 
            this.chkGroupByAgent.AutoSize = true;
            this.chkGroupByAgent.Location = new System.Drawing.Point(6, 59);
            this.chkGroupByAgent.Name = "chkGroupByAgent";
            this.chkGroupByAgent.Size = new System.Drawing.Size(101, 17);
            this.chkGroupByAgent.TabIndex = 35;
            this.chkGroupByAgent.Text = "Group By Agent";
            this.chkGroupByAgent.UseVisualStyleBackColor = true;
            // 
            // cmdNow
            // 
            this.cmdNow.Location = new System.Drawing.Point(112, 67);
            this.cmdNow.Name = "cmdNow";
            this.cmdNow.Size = new System.Drawing.Size(85, 22);
            this.cmdNow.TabIndex = 34;
            this.cmdNow.Text = "Now";
            this.cmdNow.UseVisualStyleBackColor = true;
            this.cmdNow.Click += new System.EventHandler(this.cmdNow_Click);
            // 
            // cboTeams
            // 
            this.cboTeams.FormattingEnabled = true;
            this.cboTeams.Location = new System.Drawing.Point(4, 237);
            this.cboTeams.Name = "cboTeams";
            this.cboTeams.Size = new System.Drawing.Size(198, 21);
            this.cboTeams.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Teams:";
            // 
            // optHorizontal
            // 
            this.optHorizontal.AutoSize = true;
            this.optHorizontal.Location = new System.Drawing.Point(6, 38);
            this.optHorizontal.Name = "optHorizontal";
            this.optHorizontal.Size = new System.Drawing.Size(72, 17);
            this.optHorizontal.TabIndex = 31;
            this.optHorizontal.Text = "Horizontal";
            this.optHorizontal.UseVisualStyleBackColor = true;
            // 
            // optVertical
            // 
            this.optVertical.AutoSize = true;
            this.optVertical.Checked = true;
            this.optVertical.Location = new System.Drawing.Point(6, 19);
            this.optVertical.Name = "optVertical";
            this.optVertical.Size = new System.Drawing.Size(60, 17);
            this.optVertical.TabIndex = 30;
            this.optVertical.TabStop = true;
            this.optVertical.Text = "Vertical";
            this.optVertical.UseVisualStyleBackColor = true;
            // 
            // cmdPrevious
            // 
            this.cmdPrevious.Location = new System.Drawing.Point(50, -20);
            this.cmdPrevious.Name = "cmdPrevious";
            this.cmdPrevious.Size = new System.Drawing.Size(93, 20);
            this.cmdPrevious.TabIndex = 29;
            this.cmdPrevious.Text = "< Previous";
            this.cmdPrevious.UseVisualStyleBackColor = true;
            // 
            // cmdNext
            // 
            this.cmdNext.Location = new System.Drawing.Point(156, -20);
            this.cmdNext.Name = "cmdNext";
            this.cmdNext.Size = new System.Drawing.Size(93, 20);
            this.cmdNext.TabIndex = 28;
            this.cmdNext.Text = "Next>";
            this.cmdNext.UseVisualStyleBackColor = true;
            // 
            // cmdGo
            // 
            this.cmdGo.Location = new System.Drawing.Point(109, 20);
            this.cmdGo.Name = "cmdGo";
            this.cmdGo.Size = new System.Drawing.Size(93, 44);
            this.cmdGo.TabIndex = 27;
            this.cmdGo.Text = "Go >>";
            this.cmdGo.UseVisualStyleBackColor = true;
            this.cmdGo.Click += new System.EventHandler(this.cmdGo_Click);
            // 
            // lblChartOND
            // 
            this.lblChartOND.AutoSize = true;
            this.lblChartOND.Location = new System.Drawing.Point(142, 666);
            this.lblChartOND.Name = "lblChartOND";
            this.lblChartOND.Size = new System.Drawing.Size(65, 13);
            this.lblChartOND.TabIndex = 30;
            this.lblChartOND.TabStop = true;
            this.lblChartOND.Text = "Chart O, ND";
            this.lblChartOND.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblChartOND_LinkClicked);
            // 
            // lblChartTime
            // 
            this.lblChartTime.AutoSize = true;
            this.lblChartTime.Location = new System.Drawing.Point(150, 649);
            this.lblChartTime.Name = "lblChartTime";
            this.lblChartTime.Size = new System.Drawing.Size(58, 13);
            this.lblChartTime.TabIndex = 29;
            this.lblChartTime.TabStop = true;
            this.lblChartTime.Text = "Chart Time";
            this.lblChartTime.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblChartTime_LinkClicked);
            // 
            // lblRefreshTotals
            // 
            this.lblRefreshTotals.AutoSize = true;
            this.lblRefreshTotals.Location = new System.Drawing.Point(12, 649);
            this.lblRefreshTotals.Name = "lblRefreshTotals";
            this.lblRefreshTotals.Size = new System.Drawing.Size(76, 13);
            this.lblRefreshTotals.TabIndex = 28;
            this.lblRefreshTotals.TabStop = true;
            this.lblRefreshTotals.Text = "Refresh Totals";
            this.lblRefreshTotals.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRefreshTotals_LinkClicked);
            // 
            // lblApplyCalls
            // 
            this.lblApplyCalls.Location = new System.Drawing.Point(12, 760);
            this.lblApplyCalls.Name = "lblApplyCalls";
            this.lblApplyCalls.Size = new System.Drawing.Size(190, 30);
            this.lblApplyCalls.TabIndex = 27;
            this.lblApplyCalls.TabStop = true;
            this.lblApplyCalls.Text = "Apply calls based on a time span and extension.";
            this.lblApplyCalls.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblApplyCalls_LinkClicked);
            // 
            // throb
            // 
            this.throb.BackColor = System.Drawing.Color.Red;
            this.throb.Location = new System.Drawing.Point(181, 10);
            this.throb.Name = "throb";
            this.throb.Size = new System.Drawing.Size(28, 25);
            this.throb.TabIndex = 21;
            this.throb.UseParentBackColor = false;
            // 
            // cmdRecalc
            // 
            this.cmdRecalc.Location = new System.Drawing.Point(13, 734);
            this.cmdRecalc.Name = "cmdRecalc";
            this.cmdRecalc.Size = new System.Drawing.Size(89, 20);
            this.cmdRecalc.TabIndex = 19;
            this.cmdRecalc.Text = "Recalc";
            this.cmdRecalc.UseVisualStyleBackColor = true;
            this.cmdRecalc.Click += new System.EventHandler(this.cmdRecalc_Click);
            // 
            // lblSummary
            // 
            this.lblSummary.Location = new System.Drawing.Point(7, 49);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(173, 46);
            this.lblSummary.TabIndex = 1;
            this.lblSummary.Text = "<summary>";
            this.lblSummary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tsTime
            // 
            this.tsTime.Controls.Add(this.tabDay);
            this.tsTime.Location = new System.Drawing.Point(6, 16);
            this.tsTime.Name = "tsTime";
            this.tsTime.SelectedIndex = 0;
            this.tsTime.Size = new System.Drawing.Size(179, 27);
            this.tsTime.TabIndex = 0;
            // 
            // tabDay
            // 
            this.tabDay.Location = new System.Drawing.Point(4, 22);
            this.tabDay.Name = "tabDay";
            this.tabDay.Padding = new System.Windows.Forms.Padding(3);
            this.tabDay.Size = new System.Drawing.Size(171, 1);
            this.tabDay.TabIndex = 0;
            this.tabDay.Text = "Day";
            this.tabDay.UseVisualStyleBackColor = true;
            // 
            // bgSummary
            // 
            this.bgSummary.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgSummary_DoWork);
            this.bgSummary.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgSummary_RunWorkerCompleted);
            // 
            // bgYearly
            // 
            this.bgYearly.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgYearly_DoWork);
            this.bgYearly.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgYearly_RunWorkerCompleted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdNextMonth);
            this.groupBox1.Controls.Add(this.cmdThisMonth);
            this.groupBox1.Controls.Add(this.cmdLastMonth);
            this.groupBox1.Controls.Add(this.dtStart);
            this.groupBox1.Controls.Add(this.dtEnd);
            this.groupBox1.Location = new System.Drawing.Point(4, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 178);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // cmdNextMonth
            // 
            this.cmdNextMonth.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNextMonth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdNextMonth.ImageKey = "date";
            this.cmdNextMonth.Location = new System.Drawing.Point(5, 146);
            this.cmdNextMonth.Name = "cmdNextMonth";
            this.cmdNextMonth.Size = new System.Drawing.Size(201, 25);
            this.cmdNextMonth.TabIndex = 38;
            this.cmdNextMonth.Text = "Next Month";
            this.cmdNextMonth.UseVisualStyleBackColor = true;
            this.cmdNextMonth.Click += new System.EventHandler(this.cmdNextMonth_Click);
            // 
            // cmdThisMonth
            // 
            this.cmdThisMonth.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdThisMonth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdThisMonth.ImageKey = "date";
            this.cmdThisMonth.Location = new System.Drawing.Point(5, 120);
            this.cmdThisMonth.Name = "cmdThisMonth";
            this.cmdThisMonth.Size = new System.Drawing.Size(201, 25);
            this.cmdThisMonth.TabIndex = 37;
            this.cmdThisMonth.Text = "This Month";
            this.cmdThisMonth.UseVisualStyleBackColor = true;
            this.cmdThisMonth.Click += new System.EventHandler(this.cmdThisMonth_Click);
            // 
            // cmdLastMonth
            // 
            this.cmdLastMonth.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLastMonth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdLastMonth.ImageKey = "date";
            this.cmdLastMonth.Location = new System.Drawing.Point(5, 93);
            this.cmdLastMonth.Name = "cmdLastMonth";
            this.cmdLastMonth.Size = new System.Drawing.Size(201, 25);
            this.cmdLastMonth.TabIndex = 36;
            this.cmdLastMonth.Text = "Last Month";
            this.cmdLastMonth.UseVisualStyleBackColor = true;
            this.cmdLastMonth.Click += new System.EventHandler(this.cmdLastMonth_Click);
            // 
            // dtStart
            // 
            this.dtStart.AllowClear = false;
            this.dtStart.BackColor = System.Drawing.Color.White;
            this.dtStart.Bold = false;
            this.dtStart.Caption = "Start Date";
            this.dtStart.Changed = false;
            this.dtStart.Location = new System.Drawing.Point(6, 9);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(201, 41);
            this.dtStart.SuppressEdit = false;
            this.dtStart.TabIndex = 34;
            this.dtStart.UseParentBackColor = true;
            this.dtStart.zz_GlobalColor = System.Drawing.Color.Black;
            this.dtStart.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dtStart.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.dtStart.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtStart.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.dtStart.zz_OriginalDesign = false;
            this.dtStart.zz_ShowNeedsSaveColor = true;
            this.dtStart.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.dtStart.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStart.zz_UseGlobalColor = false;
            this.dtStart.zz_UseGlobalFont = false;
            // 
            // dtEnd
            // 
            this.dtEnd.AllowClear = false;
            this.dtEnd.BackColor = System.Drawing.Color.White;
            this.dtEnd.Bold = false;
            this.dtEnd.Caption = "End Date";
            this.dtEnd.Changed = false;
            this.dtEnd.Location = new System.Drawing.Point(5, 56);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(201, 41);
            this.dtEnd.SuppressEdit = false;
            this.dtEnd.TabIndex = 35;
            this.dtEnd.UseParentBackColor = true;
            this.dtEnd.zz_GlobalColor = System.Drawing.Color.Black;
            this.dtEnd.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dtEnd.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.dtEnd.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtEnd.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.dtEnd.zz_OriginalDesign = false;
            this.dtEnd.zz_ShowNeedsSaveColor = true;
            this.dtEnd.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.dtEnd.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEnd.zz_UseGlobalColor = false;
            this.dtEnd.zz_UseGlobalFont = false;
            // 
            // PhoneReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.wb);
            this.Controls.Add(this.ts);
            this.Controls.Add(this.gbOptions);
            this.Name = "PhoneReport";
            this.Size = new System.Drawing.Size(1147, 804);
            this.Click += new System.EventHandler(this.cmdGo_Click);
            this.Resize += new System.EventHandler(this.PhoneReport_Resize);
            this.ts.ResumeLayout(false);
            this.gbOptions.ResumeLayout(false);
            this.gbOptions.PerformLayout();
            this.gbParams.ResumeLayout(false);
            this.gbParams.PerformLayout();
            this.gbCompanyType.ResumeLayout(false);
            this.gbCompanyType.PerformLayout();
            this.gbDirection.ResumeLayout(false);
            this.gbDirection.PerformLayout();
            this.tsTime.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage pageDetail;
        private System.Windows.Forms.TabPage pageSummary;
        private System.Windows.Forms.TabPage tabDay;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TabPage pageWeekly;
        private System.ComponentModel.BackgroundWorker bgSummary;
        private System.Windows.Forms.TabPage pageYearly;
        private System.ComponentModel.BackgroundWorker bgYearly;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        public System.Windows.Forms.ListView lv;
        public System.Windows.Forms.Button cmdPrint;
        public System.Windows.Forms.Button cmdTestCall;
        public System.Windows.Forms.Button cmdExtensions;
        public System.Windows.Forms.Button cmdShowInIE;
        public System.Windows.Forms.Button cmdRefresh;
        public ToolsWin.BrowserPlain wb;
        public System.Windows.Forms.TabControl ts;
        public System.Windows.Forms.Label lblSummary;
        public System.Windows.Forms.TabControl tsTime;
        public System.Windows.Forms.Button cmdRecalc;
        public nThrobber throb;
        public System.Windows.Forms.LinkLabel lblApplyCalls;
        public System.Windows.Forms.LinkLabel lblChartTime;
        public System.Windows.Forms.LinkLabel lblRefreshTotals;
        public System.Windows.Forms.LinkLabel lblChartOND;
        public System.Windows.Forms.GroupBox gbOptions;
        private System.Windows.Forms.GroupBox gbParams;
        public System.Windows.Forms.GroupBox gbCompanyType;
        private System.Windows.Forms.RadioButton optOnlyDist;
        protected System.Windows.Forms.RadioButton optOnlyOEM;
        protected System.Windows.Forms.RadioButton optAllTypes;
        public System.Windows.Forms.CheckBox chkOnlyInfo;
        public System.Windows.Forms.GroupBox gbDirection;
        private System.Windows.Forms.RadioButton optOut;
        protected System.Windows.Forms.RadioButton optIn;
        protected System.Windows.Forms.RadioButton optInOut;
        public System.Windows.Forms.Button cmdList;
        public System.Windows.Forms.CheckBox chkOnlyProspects;
        public System.Windows.Forms.CheckBox chkOnlyCustomers;
        public System.Windows.Forms.CheckBox chkGroupByAgent;
        public System.Windows.Forms.Button cmdNow;
        public System.Windows.Forms.ComboBox cboTeams;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.RadioButton optHorizontal;
        public System.Windows.Forms.RadioButton optVertical;
        public System.Windows.Forms.Button cmdPrevious;
        public System.Windows.Forms.Button cmdNext;
        public System.Windows.Forms.Button cmdGo;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button cmdChooseDate;
        private nEdit_Date dtStart;
        private nEdit_Date dtEnd;
        public System.Windows.Forms.TextBox txtDate;
        public System.Windows.Forms.Button Excel;
        private System.Windows.Forms.Button cmdNextMonth;
        private System.Windows.Forms.Button cmdThisMonth;
        private System.Windows.Forms.Button cmdLastMonth;
    }
}
