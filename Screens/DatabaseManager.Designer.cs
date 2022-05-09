namespace Rz5
{
    partial class DatabaseManager
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
            this.gb = new System.Windows.Forms.GroupBox();
            this.cmdCreateIndexes = new System.Windows.Forms.Button();
            this.cmdDropIndexes = new System.Windows.Forms.Button();
            this.throb = new NewMethod.nThrobber();
            this.cmdTruncate = new System.Windows.Forms.Button();
            this.cmdReindex = new System.Windows.Forms.Button();
            this.cmdShrink = new System.Windows.Forms.Button();
            this.cmdChooseSource = new System.Windows.Forms.Button();
            this.lblSource = new System.Windows.Forms.Label();
            this.cmdLoadTempTables = new System.Windows.Forms.Button();
            this.gbTemp = new System.Windows.Forms.GroupBox();
            this.cmdDropTemp = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmdNone = new System.Windows.Forms.Button();
            this.cmdAll = new System.Windows.Forms.Button();
            this.lvTemp = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bg = new System.ComponentModel.BackgroundWorker();
            this.gbBackup = new System.Windows.Forms.GroupBox();
            this.cmdCrucialRestore = new System.Windows.Forms.Button();
            this.cmdCrucialBackup = new System.Windows.Forms.Button();
            this.ctlFileName = new NewMethod.nEdit_String();
            this.lblLocation = new System.Windows.Forms.LinkLabel();
            this.lblFolderCap = new System.Windows.Forms.Label();
            this.cmdBackup = new System.Windows.Forms.Button();
            this.sb = new System.Windows.Forms.StatusStrip();
            this.lblStatusLine = new System.Windows.Forms.ToolStripStatusLabel();
            this.gb.SuspendLayout();
            this.gbTemp.SuspendLayout();
            this.gbBackup.SuspendLayout();
            this.sb.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb
            // 
            this.gb.Controls.Add(this.cmdCreateIndexes);
            this.gb.Controls.Add(this.cmdDropIndexes);
            this.gb.Controls.Add(this.throb);
            this.gb.Controls.Add(this.cmdTruncate);
            this.gb.Controls.Add(this.cmdReindex);
            this.gb.Controls.Add(this.cmdShrink);
            this.gb.Controls.Add(this.cmdChooseSource);
            this.gb.Controls.Add(this.lblSource);
            this.gb.Location = new System.Drawing.Point(6, 4);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(230, 644);
            this.gb.TabIndex = 0;
            this.gb.TabStop = false;
            this.gb.Text = "Options";
            // 
            // cmdCreateIndexes
            // 
            this.cmdCreateIndexes.Location = new System.Drawing.Point(11, 261);
            this.cmdCreateIndexes.Name = "cmdCreateIndexes";
            this.cmdCreateIndexes.Size = new System.Drawing.Size(213, 31);
            this.cmdCreateIndexes.TabIndex = 9;
            this.cmdCreateIndexes.Text = "Create Indexes";
            this.cmdCreateIndexes.UseVisualStyleBackColor = true;
            this.cmdCreateIndexes.Click += new System.EventHandler(this.cmdCreateIndexes_Click);
            // 
            // cmdDropIndexes
            // 
            this.cmdDropIndexes.Location = new System.Drawing.Point(11, 335);
            this.cmdDropIndexes.Name = "cmdDropIndexes";
            this.cmdDropIndexes.Size = new System.Drawing.Size(213, 31);
            this.cmdDropIndexes.TabIndex = 6;
            this.cmdDropIndexes.Text = "Drop Indexes";
            this.cmdDropIndexes.UseVisualStyleBackColor = true;
            this.cmdDropIndexes.Click += new System.EventHandler(this.cmdDropIndexes_Click);
            // 
            // throb
            // 
            this.throb.BackColor = System.Drawing.Color.Red;
            this.throb.Location = new System.Drawing.Point(189, 80);
            this.throb.Name = "throb";
            this.throb.Size = new System.Drawing.Size(35, 31);
            this.throb.TabIndex = 2;
            this.throb.UseParentBackColor = false;
            // 
            // cmdTruncate
            // 
            this.cmdTruncate.Location = new System.Drawing.Point(11, 187);
            this.cmdTruncate.Name = "cmdTruncate";
            this.cmdTruncate.Size = new System.Drawing.Size(213, 31);
            this.cmdTruncate.TabIndex = 5;
            this.cmdTruncate.Text = "Truncate the Log";
            this.cmdTruncate.UseVisualStyleBackColor = true;
            this.cmdTruncate.Click += new System.EventHandler(this.cmdTruncate_Click);
            // 
            // cmdReindex
            // 
            this.cmdReindex.Location = new System.Drawing.Point(11, 298);
            this.cmdReindex.Name = "cmdReindex";
            this.cmdReindex.Size = new System.Drawing.Size(213, 31);
            this.cmdReindex.TabIndex = 4;
            this.cmdReindex.Text = "Reindex";
            this.cmdReindex.UseVisualStyleBackColor = true;
            this.cmdReindex.Click += new System.EventHandler(this.cmdReindex_Click);
            // 
            // cmdShrink
            // 
            this.cmdShrink.Location = new System.Drawing.Point(11, 224);
            this.cmdShrink.Name = "cmdShrink";
            this.cmdShrink.Size = new System.Drawing.Size(213, 31);
            this.cmdShrink.TabIndex = 3;
            this.cmdShrink.Text = "Shrink";
            this.cmdShrink.UseVisualStyleBackColor = true;
            this.cmdShrink.Click += new System.EventHandler(this.cmdShrink_Click);
            // 
            // cmdChooseSource
            // 
            this.cmdChooseSource.Location = new System.Drawing.Point(11, 127);
            this.cmdChooseSource.Name = "cmdChooseSource";
            this.cmdChooseSource.Size = new System.Drawing.Size(213, 54);
            this.cmdChooseSource.TabIndex = 0;
            this.cmdChooseSource.Text = "Choose Another Data Source";
            this.cmdChooseSource.UseVisualStyleBackColor = true;
            this.cmdChooseSource.Click += new System.EventHandler(this.cmdChooseSource_Click);
            // 
            // lblSource
            // 
            this.lblSource.Location = new System.Drawing.Point(6, 17);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(218, 94);
            this.lblSource.TabIndex = 1;
            this.lblSource.Text = "<current source>";
            // 
            // cmdLoadTempTables
            // 
            this.cmdLoadTempTables.Location = new System.Drawing.Point(6, 19);
            this.cmdLoadTempTables.Name = "cmdLoadTempTables";
            this.cmdLoadTempTables.Size = new System.Drawing.Size(198, 54);
            this.cmdLoadTempTables.TabIndex = 3;
            this.cmdLoadTempTables.Text = "List Potentially Removable Tables";
            this.cmdLoadTempTables.UseVisualStyleBackColor = true;
            this.cmdLoadTempTables.Click += new System.EventHandler(this.cmdLoadTempTables_Click);
            // 
            // gbTemp
            // 
            this.gbTemp.Controls.Add(this.cmdDropTemp);
            this.gbTemp.Controls.Add(this.lblStatus);
            this.gbTemp.Controls.Add(this.cmdLoadTempTables);
            this.gbTemp.Controls.Add(this.cmdNone);
            this.gbTemp.Controls.Add(this.cmdAll);
            this.gbTemp.Controls.Add(this.lvTemp);
            this.gbTemp.Location = new System.Drawing.Point(242, 101);
            this.gbTemp.Name = "gbTemp";
            this.gbTemp.Size = new System.Drawing.Size(695, 547);
            this.gbTemp.TabIndex = 1;
            this.gbTemp.TabStop = false;
            this.gbTemp.Text = "Potentially Removable Tables";
            // 
            // cmdDropTemp
            // 
            this.cmdDropTemp.Location = new System.Drawing.Point(218, 19);
            this.cmdDropTemp.Name = "cmdDropTemp";
            this.cmdDropTemp.Size = new System.Drawing.Size(198, 54);
            this.cmdDropTemp.TabIndex = 4;
            this.cmdDropTemp.Text = "Remove Selected Tables";
            this.cmdDropTemp.UseVisualStyleBackColor = true;
            this.cmdDropTemp.Visible = false;
            this.cmdDropTemp.Click += new System.EventHandler(this.cmdDropTemp_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(11, 76);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 13);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "<status>";
            // 
            // cmdNone
            // 
            this.cmdNone.Location = new System.Drawing.Point(218, 95);
            this.cmdNone.Name = "cmdNone";
            this.cmdNone.Size = new System.Drawing.Size(198, 21);
            this.cmdNone.TabIndex = 2;
            this.cmdNone.Text = "None";
            this.cmdNone.UseVisualStyleBackColor = true;
            this.cmdNone.Click += new System.EventHandler(this.cmdNone_Click);
            // 
            // cmdAll
            // 
            this.cmdAll.Location = new System.Drawing.Point(6, 95);
            this.cmdAll.Name = "cmdAll";
            this.cmdAll.Size = new System.Drawing.Size(198, 21);
            this.cmdAll.TabIndex = 1;
            this.cmdAll.Text = "All";
            this.cmdAll.UseVisualStyleBackColor = true;
            this.cmdAll.Click += new System.EventHandler(this.cmdAll_Click);
            // 
            // lvTemp
            // 
            this.lvTemp.CheckBoxes = true;
            this.lvTemp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvTemp.Location = new System.Drawing.Point(8, 122);
            this.lvTemp.Name = "lvTemp";
            this.lvTemp.Size = new System.Drawing.Size(407, 379);
            this.lvTemp.TabIndex = 0;
            this.lvTemp.UseCompatibleStateImageBehavior = false;
            this.lvTemp.View = System.Windows.Forms.View.Details;
            this.lvTemp.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvTemp_ItemChecked);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Table Name";
            this.columnHeader1.Width = 262;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Date Created";
            this.columnHeader2.Width = 115;
            // 
            // bg
            // 
            this.bg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_DoWork);
            this.bg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_RunWorkerCompleted);
            // 
            // gbBackup
            // 
            this.gbBackup.Controls.Add(this.cmdCrucialRestore);
            this.gbBackup.Controls.Add(this.cmdCrucialBackup);
            this.gbBackup.Controls.Add(this.ctlFileName);
            this.gbBackup.Controls.Add(this.lblLocation);
            this.gbBackup.Controls.Add(this.lblFolderCap);
            this.gbBackup.Controls.Add(this.cmdBackup);
            this.gbBackup.Location = new System.Drawing.Point(242, 4);
            this.gbBackup.Name = "gbBackup";
            this.gbBackup.Size = new System.Drawing.Size(733, 91);
            this.gbBackup.TabIndex = 2;
            this.gbBackup.TabStop = false;
            this.gbBackup.Text = "Backup";
            // 
            // cmdCrucialRestore
            // 
            this.cmdCrucialRestore.Location = new System.Drawing.Point(553, 40);
            this.cmdCrucialRestore.Name = "cmdCrucialRestore";
            this.cmdCrucialRestore.Size = new System.Drawing.Size(142, 39);
            this.cmdCrucialRestore.TabIndex = 5;
            this.cmdCrucialRestore.Text = "Crucial Restore";
            this.cmdCrucialRestore.UseVisualStyleBackColor = true;
            this.cmdCrucialRestore.Click += new System.EventHandler(this.cmdCrucialRestore_Click);
            // 
            // cmdCrucialBackup
            // 
            this.cmdCrucialBackup.Location = new System.Drawing.Point(405, 40);
            this.cmdCrucialBackup.Name = "cmdCrucialBackup";
            this.cmdCrucialBackup.Size = new System.Drawing.Size(142, 39);
            this.cmdCrucialBackup.TabIndex = 4;
            this.cmdCrucialBackup.Text = "Crucial Backup";
            this.cmdCrucialBackup.UseVisualStyleBackColor = true;
            this.cmdCrucialBackup.Click += new System.EventHandler(this.cmdCrucialBackup_Click);
            // 
            // ctlFileName
            // 
            this.ctlFileName.AllCaps = false;
            this.ctlFileName.BackColor = System.Drawing.Color.White;
            this.ctlFileName.Bold = false;
            this.ctlFileName.Caption = "File Name:";
            this.ctlFileName.Changed = false;
            this.ctlFileName.IsEmail = false;
            this.ctlFileName.IsURL = false;
            this.ctlFileName.Location = new System.Drawing.Point(11, 37);
            this.ctlFileName.Name = "ctlFileName";
            this.ctlFileName.PasswordChar = '\0';
            this.ctlFileName.Size = new System.Drawing.Size(240, 52);
            this.ctlFileName.TabIndex = 3;
            this.ctlFileName.UseParentBackColor = false;
            this.ctlFileName.zz_Enabled = true;
            this.ctlFileName.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlFileName.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlFileName.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlFileName.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctlFileName.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctlFileName.zz_OriginalDesign = true;
            this.ctlFileName.zz_ShowLinkButton = false;
            this.ctlFileName.zz_ShowNeedsSaveColor = true;
            this.ctlFileName.zz_Text = "";
            this.ctlFileName.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlFileName.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlFileName.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlFileName.zz_UseGlobalColor = false;
            this.ctlFileName.zz_UseGlobalFont = false;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(97, 17);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(84, 13);
            this.lblLocation.TabIndex = 2;
            this.lblLocation.TabStop = true;
            this.lblLocation.Text = "<backup folder>";
            this.lblLocation.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLocation_LinkClicked);
            // 
            // lblFolderCap
            // 
            this.lblFolderCap.AutoSize = true;
            this.lblFolderCap.Location = new System.Drawing.Point(11, 19);
            this.lblFolderCap.Name = "lblFolderCap";
            this.lblFolderCap.Size = new System.Drawing.Size(83, 13);
            this.lblFolderCap.TabIndex = 1;
            this.lblFolderCap.Text = "Folder Location:";
            // 
            // cmdBackup
            // 
            this.cmdBackup.Location = new System.Drawing.Point(257, 40);
            this.cmdBackup.Name = "cmdBackup";
            this.cmdBackup.Size = new System.Drawing.Size(142, 39);
            this.cmdBackup.TabIndex = 0;
            this.cmdBackup.Text = "Full Backup";
            this.cmdBackup.UseVisualStyleBackColor = true;
            this.cmdBackup.Click += new System.EventHandler(this.cmdBackup_Click);
            // 
            // sb
            // 
            this.sb.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusLine});
            this.sb.Location = new System.Drawing.Point(0, 642);
            this.sb.Name = "sb";
            this.sb.Size = new System.Drawing.Size(999, 22);
            this.sb.TabIndex = 3;
            this.sb.Text = "statusStrip1";
            // 
            // lblStatusLine
            // 
            this.lblStatusLine.Name = "lblStatusLine";
            this.lblStatusLine.Size = new System.Drawing.Size(54, 17);
            this.lblStatusLine.Text = "<status>";
            // 
            // DatabaseManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.sb);
            this.Controls.Add(this.gbBackup);
            this.Controls.Add(this.gbTemp);
            this.Controls.Add(this.gb);
            this.Name = "DatabaseManager";
            this.Size = new System.Drawing.Size(999, 664);
            this.Resize += new System.EventHandler(this.DatabaseManager_Resize);
            this.gb.ResumeLayout(false);
            this.gbTemp.ResumeLayout(false);
            this.gbTemp.PerformLayout();
            this.gbBackup.ResumeLayout(false);
            this.gbBackup.PerformLayout();
            this.sb.ResumeLayout(false);
            this.sb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Button cmdChooseSource;
        private System.Windows.Forms.GroupBox gbTemp;
        private NewMethod.nThrobber throb;
        private System.Windows.Forms.ListView lvTemp;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button cmdLoadTempTables;
        private System.ComponentModel.BackgroundWorker bg;
        private System.Windows.Forms.Button cmdAll;
        private System.Windows.Forms.Button cmdNone;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button cmdDropTemp;
        private System.Windows.Forms.Button cmdReindex;
        private System.Windows.Forms.Button cmdShrink;
        private System.Windows.Forms.GroupBox gbBackup;
        private NewMethod.nEdit_String ctlFileName;
        private System.Windows.Forms.LinkLabel lblLocation;
        private System.Windows.Forms.Label lblFolderCap;
        private System.Windows.Forms.Button cmdBackup;
        private System.Windows.Forms.Button cmdTruncate;
        private System.Windows.Forms.StatusStrip sb;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusLine;
        private System.Windows.Forms.Button cmdCrucialBackup;
        private System.Windows.Forms.Button cmdCrucialRestore;
        private System.Windows.Forms.Button cmdDropIndexes;
        private System.Windows.Forms.Button cmdCreateIndexes;
    }
}
