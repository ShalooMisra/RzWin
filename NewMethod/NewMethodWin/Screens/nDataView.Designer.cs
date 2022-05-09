namespace NewMethod
{
    partial class nDataView
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
                HideThrobber();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(nDataView));
            this.gb = new System.Windows.Forms.GroupBox();
            this.cmdExportToCsv = new System.Windows.Forms.Button();
            this.cmdHide = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdSelectFile = new System.Windows.Forms.Button();
            this.IM24 = new System.Windows.Forms.ImageList(this.components);
            this.cmdExcelImport = new System.Windows.Forms.Button();
            this.cmdImportFromCSV = new System.Windows.Forms.Button();
            this.cmdImportFromDBF = new System.Windows.Forms.Button();
            this.chkAutoMatch = new System.Windows.Forms.CheckBox();
            this.chkShared = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRequired = new System.Windows.Forms.Label();
            this.cmdClear = new System.Windows.Forms.Button();
            this.cmdAccept = new System.Windows.Forms.Button();
            this.mnuLines = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.bgExcel = new System.ComponentModel.BackgroundWorker();
            this.gbTop = new System.Windows.Forms.GroupBox();
            this.cmdSetColumns = new System.Windows.Forms.Button();
            this.cmdClearColumns = new System.Windows.Forms.Button();
            this.lblProcess = new System.Windows.Forms.LinkLabel();
            this.lblRename = new System.Windows.Forms.LinkLabel();
            this.lblTableName = new System.Windows.Forms.LinkLabel();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.throb = new NewMethod.nThrobber();
            this.lblItems = new System.Windows.Forms.Label();
            this.lv = new ManagedControls.ManagedListView();
            this.mnuData = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCountSpecificValue = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCountSpecificBlank = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCountSpecificOther = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteBlank = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteOther = new System.Windows.Forms.ToolStripMenuItem();
            this.truncateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTruncateSpace = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTruncateColon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTruncateSemicolon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTruncateOther = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSplitSpace = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSplitColon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSplitSemicolon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSplitSlash = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSplitOther = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAppend = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAppendNoSeparator = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAppendWithSpace = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWithCustom = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSplitEmailDomain = new System.Windows.Forms.ToolStripMenuItem();
            this.splitIntoColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSplitColumnsComma = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSplitColumnsOther = new System.Windows.Forms.ToolStripMenuItem();
            this.properlyCaseContactNamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spacifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSplitContactFirstName = new System.Windows.Forms.ToolStripMenuItem();
            this.gb.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.mnuLines.SuspendLayout();
            this.gbTop.SuspendLayout();
            this.mnuData.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb
            // 
            this.gb.Controls.Add(this.cmdExportToCsv);
            this.gb.Controls.Add(this.cmdHide);
            this.gb.Controls.Add(this.groupBox1);
            this.gb.Controls.Add(this.chkAutoMatch);
            this.gb.Controls.Add(this.chkShared);
            this.gb.Controls.Add(this.label1);
            this.gb.Controls.Add(this.lblRequired);
            this.gb.Controls.Add(this.cmdClear);
            this.gb.Controls.Add(this.cmdAccept);
            this.gb.Location = new System.Drawing.Point(4, 3);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(155, 464);
            this.gb.TabIndex = 0;
            this.gb.TabStop = false;
            // 
            // cmdExportToCsv
            // 
            this.cmdExportToCsv.Location = new System.Drawing.Point(6, 86);
            this.cmdExportToCsv.Name = "cmdExportToCsv";
            this.cmdExportToCsv.Size = new System.Drawing.Size(145, 23);
            this.cmdExportToCsv.TabIndex = 12;
            this.cmdExportToCsv.Text = "Export To .csv";
            this.cmdExportToCsv.UseVisualStyleBackColor = true;
            this.cmdExportToCsv.Click += new System.EventHandler(this.cmdExportToCsv_Click);
            // 
            // cmdHide
            // 
            this.cmdHide.Location = new System.Drawing.Point(6, 109);
            this.cmdHide.Name = "cmdHide";
            this.cmdHide.Size = new System.Drawing.Size(66, 24);
            this.cmdHide.TabIndex = 11;
            this.cmdHide.Text = "Close";
            this.cmdHide.UseVisualStyleBackColor = true;
            this.cmdHide.Click += new System.EventHandler(this.cmdHide_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdSelectFile);
            this.groupBox1.Controls.Add(this.cmdExcelImport);
            this.groupBox1.Controls.Add(this.cmdImportFromCSV);
            this.groupBox1.Controls.Add(this.cmdImportFromDBF);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(145, 75);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Import From";
            // 
            // cmdSelectFile
            // 
            this.cmdSelectFile.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSelectFile.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdSelectFile.ImageKey = "Search";
            this.cmdSelectFile.ImageList = this.IM24;
            this.cmdSelectFile.Location = new System.Drawing.Point(6, 17);
            this.cmdSelectFile.Name = "cmdSelectFile";
            this.cmdSelectFile.Size = new System.Drawing.Size(132, 51);
            this.cmdSelectFile.TabIndex = 9;
            this.cmdSelectFile.Text = "Open File For Import";
            this.cmdSelectFile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdSelectFile.UseVisualStyleBackColor = true;
            this.cmdSelectFile.Click += new System.EventHandler(this.cmdSelectFile_Click);
            // 
            // IM24
            // 
            this.IM24.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IM24.ImageStream")));
            this.IM24.TransparentColor = System.Drawing.Color.Fuchsia;
            this.IM24.Images.SetKeyName(0, "Search");
            // 
            // cmdExcelImport
            // 
            this.cmdExcelImport.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExcelImport.Location = new System.Drawing.Point(6, 18);
            this.cmdExcelImport.Name = "cmdExcelImport";
            this.cmdExcelImport.Size = new System.Drawing.Size(59, 24);
            this.cmdExcelImport.TabIndex = 0;
            this.cmdExcelImport.Text = "XLS";
            this.cmdExcelImport.UseVisualStyleBackColor = true;
            this.cmdExcelImport.Click += new System.EventHandler(this.cmdExcelImport_Click);
            // 
            // cmdImportFromCSV
            // 
            this.cmdImportFromCSV.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdImportFromCSV.Location = new System.Drawing.Point(79, 44);
            this.cmdImportFromCSV.Name = "cmdImportFromCSV";
            this.cmdImportFromCSV.Size = new System.Drawing.Size(59, 24);
            this.cmdImportFromCSV.TabIndex = 2;
            this.cmdImportFromCSV.Text = "CSV";
            this.cmdImportFromCSV.UseVisualStyleBackColor = true;
            this.cmdImportFromCSV.Click += new System.EventHandler(this.cmdImportFromCSV_Click);
            // 
            // cmdImportFromDBF
            // 
            this.cmdImportFromDBF.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdImportFromDBF.Location = new System.Drawing.Point(6, 44);
            this.cmdImportFromDBF.Name = "cmdImportFromDBF";
            this.cmdImportFromDBF.Size = new System.Drawing.Size(59, 24);
            this.cmdImportFromDBF.TabIndex = 3;
            this.cmdImportFromDBF.Text = "DBF";
            this.cmdImportFromDBF.UseVisualStyleBackColor = true;
            this.cmdImportFromDBF.Click += new System.EventHandler(this.cmdImportFromDBF_Click);
            // 
            // chkAutoMatch
            // 
            this.chkAutoMatch.AutoSize = true;
            this.chkAutoMatch.Checked = true;
            this.chkAutoMatch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoMatch.Enabled = false;
            this.chkAutoMatch.Location = new System.Drawing.Point(12, 194);
            this.chkAutoMatch.Name = "chkAutoMatch";
            this.chkAutoMatch.Size = new System.Drawing.Size(117, 17);
            this.chkAutoMatch.TabIndex = 9;
            this.chkAutoMatch.Text = "Use Auto Matching";
            this.chkAutoMatch.UseVisualStyleBackColor = true;
            // 
            // chkShared
            // 
            this.chkShared.AutoSize = true;
            this.chkShared.Checked = true;
            this.chkShared.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShared.Location = new System.Drawing.Point(12, 217);
            this.chkShared.Name = "chkShared";
            this.chkShared.Size = new System.Drawing.Size(114, 17);
            this.chkShared.TabIndex = 7;
            this.chkShared.Text = "Use Shared Folder";
            this.chkShared.UseVisualStyleBackColor = true;
            this.chkShared.CheckedChanged += new System.EventHandler(this.chkShared_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Advanced:";
            // 
            // lblRequired
            // 
            this.lblRequired.AutoSize = true;
            this.lblRequired.Location = new System.Drawing.Point(9, 237);
            this.lblRequired.Name = "lblRequired";
            this.lblRequired.Size = new System.Drawing.Size(53, 13);
            this.lblRequired.TabIndex = 5;
            this.lblRequired.Text = "Required:";
            // 
            // cmdClear
            // 
            this.cmdClear.Location = new System.Drawing.Point(85, 109);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(66, 24);
            this.cmdClear.TabIndex = 4;
            this.cmdClear.Text = "Clear";
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // cmdAccept
            // 
            this.cmdAccept.Location = new System.Drawing.Point(6, 133);
            this.cmdAccept.Name = "cmdAccept";
            this.cmdAccept.Size = new System.Drawing.Size(145, 38);
            this.cmdAccept.TabIndex = 1;
            this.cmdAccept.Text = "<Accept>";
            this.cmdAccept.UseVisualStyleBackColor = true;
            this.cmdAccept.Visible = false;
            this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
            // 
            // mnuLines
            // 
            this.mnuLines.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRemove});
            this.mnuLines.Name = "mnuLines";
            this.mnuLines.Size = new System.Drawing.Size(118, 26);
            // 
            // mnuRemove
            // 
            this.mnuRemove.Name = "mnuRemove";
            this.mnuRemove.Size = new System.Drawing.Size(117, 22);
            this.mnuRemove.Text = "&Remove";
            this.mnuRemove.Click += new System.EventHandler(this.mnuRemove_Click);
            // 
            // mnu
            // 
            this.mnu.Name = "mnu";
            this.mnu.Size = new System.Drawing.Size(61, 4);
            // 
            // bgExcel
            // 
            this.bgExcel.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgExcel_DoWork);
            this.bgExcel.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgExcel_RunWorkerCompleted);
            // 
            // gbTop
            // 
            this.gbTop.Controls.Add(this.cmdSetColumns);
            this.gbTop.Controls.Add(this.cmdClearColumns);
            this.gbTop.Controls.Add(this.lblProcess);
            this.gbTop.Controls.Add(this.lblRename);
            this.gbTop.Controls.Add(this.lblTableName);
            this.gbTop.Controls.Add(this.pb);
            this.gbTop.Controls.Add(this.lblStatus);
            this.gbTop.Controls.Add(this.throb);
            this.gbTop.Controls.Add(this.lblItems);
            this.gbTop.Location = new System.Drawing.Point(165, 3);
            this.gbTop.Name = "gbTop";
            this.gbTop.Size = new System.Drawing.Size(809, 41);
            this.gbTop.TabIndex = 2;
            this.gbTop.TabStop = false;
            // 
            // cmdSetColumns
            // 
            this.cmdSetColumns.Location = new System.Drawing.Point(649, 7);
            this.cmdSetColumns.Name = "cmdSetColumns";
            this.cmdSetColumns.Size = new System.Drawing.Size(93, 19);
            this.cmdSetColumns.TabIndex = 14;
            this.cmdSetColumns.Text = "Set Columns";
            this.cmdSetColumns.UseVisualStyleBackColor = true;
            this.cmdSetColumns.Visible = false;
            this.cmdSetColumns.Click += new System.EventHandler(this.cmdSetColumns_Click);
            // 
            // cmdClearColumns
            // 
            this.cmdClearColumns.Location = new System.Drawing.Point(550, 7);
            this.cmdClearColumns.Name = "cmdClearColumns";
            this.cmdClearColumns.Size = new System.Drawing.Size(93, 19);
            this.cmdClearColumns.TabIndex = 13;
            this.cmdClearColumns.Text = "Clear Columns";
            this.cmdClearColumns.UseVisualStyleBackColor = true;
            this.cmdClearColumns.Visible = false;
            this.cmdClearColumns.Click += new System.EventHandler(this.cmdClearColumns_Click);
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.Location = new System.Drawing.Point(406, 9);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(56, 13);
            this.lblProcess.TabIndex = 13;
            this.lblProcess.TabStop = true;
            this.lblProcess.Text = "<process>";
            this.lblProcess.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblProcess_LinkClicked);
            // 
            // lblRename
            // 
            this.lblRename.AutoSize = true;
            this.lblRename.Location = new System.Drawing.Point(406, 25);
            this.lblRename.Name = "lblRename";
            this.lblRename.Size = new System.Drawing.Size(54, 13);
            this.lblRename.TabIndex = 12;
            this.lblRename.TabStop = true;
            this.lblRename.Text = "<rename>";
            this.lblRename.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRename_LinkClicked);
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.Location = new System.Drawing.Point(466, 25);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(71, 13);
            this.lblTableName.TabIndex = 11;
            this.lblTableName.TabStop = true;
            this.lblTableName.Text = "<table name>";
            this.lblTableName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblTableName_LinkClicked);
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(31, 25);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(165, 12);
            this.pb.TabIndex = 7;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(28, 9);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 13);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "<status>";
            // 
            // throb
            // 
            this.throb.BackColor = System.Drawing.Color.White;
            this.throb.Location = new System.Drawing.Point(6, 9);
            this.throb.Name = "throb";
            this.throb.Size = new System.Drawing.Size(31, 26);
            this.throb.TabIndex = 10;
            this.throb.UseParentBackColor = false;
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.Location = new System.Drawing.Point(202, 24);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(43, 13);
            this.lblItems.TabIndex = 9;
            this.lblItems.Text = "<items>";
            // 
            // lv
            // 
            this.lv.ContextMenuStrip = this.mnuLines;
            this.lv.FullRowSelect = true;
            this.lv.Location = new System.Drawing.Point(165, 52);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(477, 390);
            this.lv.TabIndex = 1;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_ColumnClick);
            // 
            // mnuData
            // 
            this.mnuData.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCountSpecificValue,
            this.toolStripMenuItem1,
            this.truncateToolStripMenuItem,
            this.aToolStripMenuItem,
            this.mnuAppend,
            this.mnuSplitEmailDomain,
            this.mnuSplitContactFirstName,
            this.splitIntoColumnsToolStripMenuItem,
            this.properlyCaseContactNamesToolStripMenuItem,
            this.spacifyToolStripMenuItem});
            this.mnuData.Name = "mnuData";
            this.mnuData.Size = new System.Drawing.Size(289, 246);
            // 
            // mnuCountSpecificValue
            // 
            this.mnuCountSpecificValue.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCountSpecificBlank,
            this.mnuCountSpecificOther});
            this.mnuCountSpecificValue.Name = "mnuCountSpecificValue";
            this.mnuCountSpecificValue.Size = new System.Drawing.Size(288, 22);
            this.mnuCountSpecificValue.Text = "Count rows with a specific column value";
            // 
            // mnuCountSpecificBlank
            // 
            this.mnuCountSpecificBlank.Name = "mnuCountSpecificBlank";
            this.mnuCountSpecificBlank.Size = new System.Drawing.Size(124, 22);
            this.mnuCountSpecificBlank.Text = "&Blank[]";
            this.mnuCountSpecificBlank.Click += new System.EventHandler(this.mnuCountSpecificBlank_Click);
            // 
            // mnuCountSpecificOther
            // 
            this.mnuCountSpecificOther.Name = "mnuCountSpecificOther";
            this.mnuCountSpecificOther.Size = new System.Drawing.Size(124, 22);
            this.mnuCountSpecificOther.Text = "&Other [...]";
            this.mnuCountSpecificOther.Click += new System.EventHandler(this.mnuCountSpecificOther_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDeleteBlank,
            this.mnuDeleteOther});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(288, 22);
            this.toolStripMenuItem1.Text = "Delete rows with a specific column value";
            // 
            // mnuDeleteBlank
            // 
            this.mnuDeleteBlank.Name = "mnuDeleteBlank";
            this.mnuDeleteBlank.Size = new System.Drawing.Size(124, 22);
            this.mnuDeleteBlank.Text = "Blank []";
            this.mnuDeleteBlank.Click += new System.EventHandler(this.mnuDeleteBlank_Click);
            // 
            // mnuDeleteOther
            // 
            this.mnuDeleteOther.Name = "mnuDeleteOther";
            this.mnuDeleteOther.Size = new System.Drawing.Size(124, 22);
            this.mnuDeleteOther.Text = "Other [...]";
            this.mnuDeleteOther.Click += new System.EventHandler(this.mnuDeleteOther_Click);
            // 
            // truncateToolStripMenuItem
            // 
            this.truncateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTruncateSpace,
            this.mnuTruncateColon,
            this.mnuTruncateSemicolon,
            this.mnuTruncateOther});
            this.truncateToolStripMenuItem.Name = "truncateToolStripMenuItem";
            this.truncateToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.truncateToolStripMenuItem.Text = "Truncate after";
            // 
            // mnuTruncateSpace
            // 
            this.mnuTruncateSpace.Name = "mnuTruncateSpace";
            this.mnuTruncateSpace.Size = new System.Drawing.Size(144, 22);
            this.mnuTruncateSpace.Text = "Space [ ]";
            this.mnuTruncateSpace.Click += new System.EventHandler(this.mnuTruncateSpace_Click);
            // 
            // mnuTruncateColon
            // 
            this.mnuTruncateColon.Name = "mnuTruncateColon";
            this.mnuTruncateColon.Size = new System.Drawing.Size(144, 22);
            this.mnuTruncateColon.Text = "Colon [:]";
            this.mnuTruncateColon.Click += new System.EventHandler(this.mnuTruncateColon_Click);
            // 
            // mnuTruncateSemicolon
            // 
            this.mnuTruncateSemicolon.Name = "mnuTruncateSemicolon";
            this.mnuTruncateSemicolon.Size = new System.Drawing.Size(144, 22);
            this.mnuTruncateSemicolon.Text = "Semicolon [;]";
            this.mnuTruncateSemicolon.Click += new System.EventHandler(this.mnuTruncateSemicolon_Click);
            // 
            // mnuTruncateOther
            // 
            this.mnuTruncateOther.Name = "mnuTruncateOther";
            this.mnuTruncateOther.Size = new System.Drawing.Size(144, 22);
            this.mnuTruncateOther.Text = "&Other [...]";
            this.mnuTruncateOther.Click += new System.EventHandler(this.mnuTruncateOther_Click);
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSplitSpace,
            this.mnuSplitColon,
            this.mnuSplitSemicolon,
            this.mnuSplitSlash,
            this.mnuSplitOther});
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.aToolStripMenuItem.Text = "Split right";
            // 
            // mnuSplitSpace
            // 
            this.mnuSplitSpace.Name = "mnuSplitSpace";
            this.mnuSplitSpace.Size = new System.Drawing.Size(144, 22);
            this.mnuSplitSpace.Text = "Space [ ]";
            this.mnuSplitSpace.Click += new System.EventHandler(this.mnuSplitSpace_Click);
            // 
            // mnuSplitColon
            // 
            this.mnuSplitColon.Name = "mnuSplitColon";
            this.mnuSplitColon.Size = new System.Drawing.Size(144, 22);
            this.mnuSplitColon.Text = "Colon [:]";
            this.mnuSplitColon.Click += new System.EventHandler(this.mnuSplitColon_Click);
            // 
            // mnuSplitSemicolon
            // 
            this.mnuSplitSemicolon.Name = "mnuSplitSemicolon";
            this.mnuSplitSemicolon.Size = new System.Drawing.Size(144, 22);
            this.mnuSplitSemicolon.Text = "Semicolon [;]";
            this.mnuSplitSemicolon.Click += new System.EventHandler(this.mnuSplitSemicolon_Click);
            // 
            // mnuSplitSlash
            // 
            this.mnuSplitSlash.Name = "mnuSplitSlash";
            this.mnuSplitSlash.Size = new System.Drawing.Size(144, 22);
            this.mnuSplitSlash.Text = "Slash [/]";
            this.mnuSplitSlash.Click += new System.EventHandler(this.mnuSplitSlash_Click);
            // 
            // mnuSplitOther
            // 
            this.mnuSplitOther.Name = "mnuSplitOther";
            this.mnuSplitOther.Size = new System.Drawing.Size(144, 22);
            this.mnuSplitOther.Text = "&Other [...]";
            this.mnuSplitOther.Click += new System.EventHandler(this.mnuSplitOther_Click);
            // 
            // mnuAppend
            // 
            this.mnuAppend.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAppendNoSeparator,
            this.mnuAppendWithSpace,
            this.mnuWithCustom});
            this.mnuAppend.Name = "mnuAppend";
            this.mnuAppend.Size = new System.Drawing.Size(288, 22);
            this.mnuAppend.Text = "Append a column";
            // 
            // mnuAppendNoSeparator
            // 
            this.mnuAppendNoSeparator.Name = "mnuAppendNoSeparator";
            this.mnuAppendNoSeparator.Size = new System.Drawing.Size(142, 22);
            this.mnuAppendNoSeparator.Text = "&No separator";
            this.mnuAppendNoSeparator.Click += new System.EventHandler(this.mnuAppendNoSeparator_Click);
            // 
            // mnuAppendWithSpace
            // 
            this.mnuAppendWithSpace.Name = "mnuAppendWithSpace";
            this.mnuAppendWithSpace.Size = new System.Drawing.Size(142, 22);
            this.mnuAppendWithSpace.Text = "&Space";
            this.mnuAppendWithSpace.Click += new System.EventHandler(this.mnuAppendWithSpace_Click);
            // 
            // mnuWithCustom
            // 
            this.mnuWithCustom.Name = "mnuWithCustom";
            this.mnuWithCustom.Size = new System.Drawing.Size(142, 22);
            this.mnuWithCustom.Text = "&Custom [...]";
            this.mnuWithCustom.Click += new System.EventHandler(this.mnuWithCustom_Click);
            // 
            // mnuSplitEmailDomain
            // 
            this.mnuSplitEmailDomain.Name = "mnuSplitEmailDomain";
            this.mnuSplitEmailDomain.Size = new System.Drawing.Size(288, 22);
            this.mnuSplitEmailDomain.Text = "Split Email Domain";
            this.mnuSplitEmailDomain.Click += new System.EventHandler(this.mnuSplitEmailDomain_Click);
            // 
            // splitIntoColumnsToolStripMenuItem
            // 
            this.splitIntoColumnsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSplitColumnsComma,
            this.mnuSplitColumnsOther});
            this.splitIntoColumnsToolStripMenuItem.Name = "splitIntoColumnsToolStripMenuItem";
            this.splitIntoColumnsToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.splitIntoColumnsToolStripMenuItem.Text = "Split Into Columns";
            // 
            // mnuSplitColumnsComma
            // 
            this.mnuSplitColumnsComma.Name = "mnuSplitColumnsComma";
            this.mnuSplitColumnsComma.Size = new System.Drawing.Size(117, 22);
            this.mnuSplitColumnsComma.Text = "Comma";
            this.mnuSplitColumnsComma.Click += new System.EventHandler(this.mnuSplitColumnsComma_Click);
            // 
            // mnuSplitColumnsOther
            // 
            this.mnuSplitColumnsOther.Name = "mnuSplitColumnsOther";
            this.mnuSplitColumnsOther.Size = new System.Drawing.Size(117, 22);
            this.mnuSplitColumnsOther.Text = "Other";
            this.mnuSplitColumnsOther.Click += new System.EventHandler(this.mnuSplitColumnsOther_Click);
            // 
            // properlyCaseContactNamesToolStripMenuItem
            // 
            this.properlyCaseContactNamesToolStripMenuItem.Name = "properlyCaseContactNamesToolStripMenuItem";
            this.properlyCaseContactNamesToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.properlyCaseContactNamesToolStripMenuItem.Text = "Properly Case Contact Names";
            this.properlyCaseContactNamesToolStripMenuItem.Click += new System.EventHandler(this.properlyCaseContactNamesToolStripMenuItem_Click);
            // 
            // spacifyToolStripMenuItem
            // 
            this.spacifyToolStripMenuItem.Name = "spacifyToolStripMenuItem";
            this.spacifyToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.spacifyToolStripMenuItem.Text = "Trim Double Spaces";
            this.spacifyToolStripMenuItem.Click += new System.EventHandler(this.spacifyToolStripMenuItem_Click);
            // 
            // mnuSplitContactFirstName
            // 
            this.mnuSplitContactFirstName.Name = "mnuSplitContactFirstName";
            this.mnuSplitContactFirstName.Size = new System.Drawing.Size(288, 22);
            this.mnuSplitContactFirstName.Text = "Split Contact First Name";
            this.mnuSplitContactFirstName.Click += new System.EventHandler(this.mnuSplitContactFirstName_Click);
            // 
            // nDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gb);
            this.Controls.Add(this.lv);
            this.Controls.Add(this.gbTop);
            this.Name = "nDataView";
            this.Size = new System.Drawing.Size(1114, 480);
            this.Resize += new System.EventHandler(this.nDataView_Resize);
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.mnuLines.ResumeLayout(false);
            this.gbTop.ResumeLayout(false);
            this.gbTop.PerformLayout();
            this.mnuData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb;
        private ManagedControls.ManagedListView lv;
        private System.Windows.Forms.Button cmdExcelImport;
        private System.Windows.Forms.ContextMenuStrip mnu;
        private System.Windows.Forms.Button cmdAccept;
        private System.Windows.Forms.ContextMenuStrip mnuLines;
        private System.Windows.Forms.ToolStripMenuItem mnuRemove;
        private System.Windows.Forms.Button cmdImportFromCSV;
        private System.Windows.Forms.Button cmdImportFromDBF;
        private System.ComponentModel.BackgroundWorker bgExcel;
        private System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.GroupBox gbTop;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ProgressBar pb;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.Label lblRequired;
        private nThrobber throb;
        private System.Windows.Forms.CheckBox chkShared;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAutoMatch;
        private System.Windows.Forms.LinkLabel lblTableName;
        private System.Windows.Forms.LinkLabel lblRename;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdHide;
        private System.Windows.Forms.ContextMenuStrip mnuData;
        private System.Windows.Forms.ToolStripMenuItem mnuCountSpecificValue;
        private System.Windows.Forms.ToolStripMenuItem mnuCountSpecificBlank;
        private System.Windows.Forms.ToolStripMenuItem truncateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuTruncateSpace;
        private System.Windows.Forms.ToolStripMenuItem mnuTruncateColon;
        private System.Windows.Forms.ToolStripMenuItem mnuTruncateSemicolon;
        private System.Windows.Forms.ToolStripMenuItem mnuTruncateOther;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuSplitSpace;
        private System.Windows.Forms.ToolStripMenuItem mnuSplitColon;
        private System.Windows.Forms.ToolStripMenuItem mnuSplitSemicolon;
        private System.Windows.Forms.ToolStripMenuItem mnuSplitSlash;
        private System.Windows.Forms.ToolStripMenuItem mnuSplitOther;
        private System.Windows.Forms.ToolStripMenuItem mnuCountSpecificOther;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteBlank;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteOther;
        private System.Windows.Forms.ToolStripMenuItem mnuAppend;
        private System.Windows.Forms.Button cmdExportToCsv;
        private System.Windows.Forms.ToolStripMenuItem mnuAppendNoSeparator;
        private System.Windows.Forms.ToolStripMenuItem mnuAppendWithSpace;
        private System.Windows.Forms.ToolStripMenuItem mnuWithCustom;
        private System.Windows.Forms.ToolStripMenuItem mnuSplitEmailDomain;
        private System.Windows.Forms.LinkLabel lblProcess;
        private System.Windows.Forms.ToolStripMenuItem splitIntoColumnsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuSplitColumnsComma;
        private System.Windows.Forms.ToolStripMenuItem mnuSplitColumnsOther;
        private System.Windows.Forms.ToolStripMenuItem properlyCaseContactNamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spacifyToolStripMenuItem;
        private System.Windows.Forms.Button cmdSelectFile;
        private System.Windows.Forms.ImageList IM24;
        private System.Windows.Forms.Button cmdClearColumns;
        private System.Windows.Forms.Button cmdSetColumns;
        private System.Windows.Forms.ToolStripMenuItem mnuSplitContactFirstName;
    }
}
