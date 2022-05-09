namespace Tie
{
    partial class EndView
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
                try
                {
                    CurrentEnd.GotStatus -= new TieEndStatusHandler(CurrentEnd_GotStatus);
                    CurrentEnd.JobStatusChanged -= new JobStatusChangeHandler(CurrentEnd_JobStatusChanged);
                    CurrentEnd.JobLogAdded -= new JobLogAddedHandler(CurrentEnd_JobLogAdded);
                    CurrentEnd.JobFinished -= new JobStatusHandler(CurrentEnd_JobFinished);
                }
                catch { }

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
            this.lblLogs = new System.Windows.Forms.LinkLabel();
            this.lblClear = new System.Windows.Forms.LinkLabel();
            this.chkTrack = new System.Windows.Forms.CheckBox();
            this.lblCheck = new System.Windows.Forms.LinkLabel();
            this.lblDone = new System.Windows.Forms.Label();
            this.lvDone = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.lvToDo = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.lblAdd = new System.Windows.Forms.LinkLabel();
            this.lblToDo = new System.Windows.Forms.Label();
            this.txtStatus = new Tie.nEndlessStatusBox();
            this.gbCurrent = new System.Windows.Forms.GroupBox();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.lblLast = new System.Windows.Forms.Label();
            this.gbLast = new System.Windows.Forms.GroupBox();
            this.tmrJobs = new System.Windows.Forms.Timer(this.components);
            this.mnuJobs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuTestJob = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEchoJob = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIPConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVNC = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVNCMike = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVNCJoel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVNCOther = new System.Windows.Forms.ToolStripMenuItem();
            this.chkAutoEcho = new System.Windows.Forms.CheckBox();
            this.chkAutoCheck = new System.Windows.Forms.CheckBox();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.picStatus = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTargetSession = new System.Windows.Forms.Label();
            this.lvRunning = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.lblRunning = new System.Windows.Forms.Label();
            this.lblAddRunning = new System.Windows.Forms.LinkLabel();
            this.mnuRunningJobs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fileExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUpdateOriginals = new System.Windows.Forms.ToolStripMenuItem();
            this.gbCurrent.SuspendLayout();
            this.gbLast.SuspendLayout();
            this.mnuJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).BeginInit();
            this.mnuRunningJobs.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLogs
            // 
            this.lblLogs.AutoSize = true;
            this.lblLogs.Location = new System.Drawing.Point(4, 34);
            this.lblLogs.Name = "lblLogs";
            this.lblLogs.Size = new System.Drawing.Size(26, 13);
            this.lblLogs.TabIndex = 36;
            this.lblLogs.TabStop = true;
            this.lblLogs.Text = "logs";
            this.lblLogs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLogs_LinkClicked);
            // 
            // lblClear
            // 
            this.lblClear.AutoSize = true;
            this.lblClear.Location = new System.Drawing.Point(224, 107);
            this.lblClear.Name = "lblClear";
            this.lblClear.Size = new System.Drawing.Size(30, 13);
            this.lblClear.TabIndex = 35;
            this.lblClear.TabStop = true;
            this.lblClear.Text = "clear";
            this.lblClear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblClear_LinkClicked);
            // 
            // chkTrack
            // 
            this.chkTrack.AutoSize = true;
            this.chkTrack.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTrack.Location = new System.Drawing.Point(376, 34);
            this.chkTrack.Name = "chkTrack";
            this.chkTrack.Size = new System.Drawing.Size(54, 17);
            this.chkTrack.TabIndex = 34;
            this.chkTrack.Text = "Track";
            this.chkTrack.UseVisualStyleBackColor = true;
            this.chkTrack.CheckedChanged += new System.EventHandler(this.chkTrack_CheckedChanged);
            // 
            // lblCheck
            // 
            this.lblCheck.AutoSize = true;
            this.lblCheck.Location = new System.Drawing.Point(260, 107);
            this.lblCheck.Name = "lblCheck";
            this.lblCheck.Size = new System.Drawing.Size(37, 13);
            this.lblCheck.TabIndex = 33;
            this.lblCheck.TabStop = true;
            this.lblCheck.Text = "check";
            this.lblCheck.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCheck_LinkClicked);
            // 
            // lblDone
            // 
            this.lblDone.AutoSize = true;
            this.lblDone.Location = new System.Drawing.Point(146, 106);
            this.lblDone.Name = "lblDone";
            this.lblDone.Size = new System.Drawing.Size(33, 13);
            this.lblDone.TabIndex = 29;
            this.lblDone.Text = "Done";
            // 
            // lvDone
            // 
            this.lvDone.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.lvDone.FullRowSelect = true;
            this.lvDone.Location = new System.Drawing.Point(140, 123);
            this.lvDone.Name = "lvDone";
            this.lvDone.Size = new System.Drawing.Size(157, 122);
            this.lvDone.TabIndex = 28;
            this.lvDone.UseCompatibleStateImageBehavior = false;
            this.lvDone.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            this.columnHeader3.Width = 76;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Result";
            this.columnHeader4.Width = 72;
            // 
            // lvToDo
            // 
            this.lvToDo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lvToDo.FullRowSelect = true;
            this.lvToDo.Location = new System.Drawing.Point(10, 123);
            this.lvToDo.Name = "lvToDo";
            this.lvToDo.Size = new System.Drawing.Size(124, 123);
            this.lvToDo.TabIndex = 26;
            this.lvToDo.UseCompatibleStateImageBehavior = false;
            this.lvToDo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 112;
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.Location = new System.Drawing.Point(106, 107);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(25, 13);
            this.lblAdd.TabIndex = 32;
            this.lblAdd.TabStop = true;
            this.lblAdd.Text = "add";
            this.lblAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAdd_LinkClicked);
            // 
            // lblToDo
            // 
            this.lblToDo.AutoSize = true;
            this.lblToDo.Location = new System.Drawing.Point(7, 106);
            this.lblToDo.Name = "lblToDo";
            this.lblToDo.Size = new System.Drawing.Size(37, 13);
            this.lblToDo.TabIndex = 27;
            this.lblToDo.Text = "To Do";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(4, 49);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(426, 52);
            this.txtStatus.TabIndex = 25;
            this.txtStatus.Text = "";
            // 
            // gbCurrent
            // 
            this.gbCurrent.Controls.Add(this.lblCurrent);
            this.gbCurrent.Location = new System.Drawing.Point(7, 252);
            this.gbCurrent.Name = "gbCurrent";
            this.gbCurrent.Size = new System.Drawing.Size(172, 186);
            this.gbCurrent.TabIndex = 30;
            this.gbCurrent.TabStop = false;
            this.gbCurrent.Text = "Current";
            // 
            // lblCurrent
            // 
            this.lblCurrent.Location = new System.Drawing.Point(6, 16);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(161, 167);
            this.lblCurrent.TabIndex = 0;
            this.lblCurrent.Text = "<current>";
            // 
            // lblLast
            // 
            this.lblLast.Location = new System.Drawing.Point(6, 16);
            this.lblLast.Name = "lblLast";
            this.lblLast.Size = new System.Drawing.Size(234, 167);
            this.lblLast.TabIndex = 0;
            this.lblLast.Text = "<last>";
            // 
            // gbLast
            // 
            this.gbLast.Controls.Add(this.lblLast);
            this.gbLast.Location = new System.Drawing.Point(185, 252);
            this.gbLast.Name = "gbLast";
            this.gbLast.Size = new System.Drawing.Size(245, 186);
            this.gbLast.TabIndex = 31;
            this.gbLast.TabStop = false;
            this.gbLast.Text = "Last";
            // 
            // tmrJobs
            // 
            this.tmrJobs.Interval = 1000;
            this.tmrJobs.Tick += new System.EventHandler(this.tmrJobs_Tick);
            // 
            // mnuJobs
            // 
            this.mnuJobs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTestJob,
            this.mnuEchoJob,
            this.mnuIPConfig,
            this.mnuVNC,
            this.mnuUpdateOriginals});
            this.mnuJobs.Name = "mnuJobs";
            this.mnuJobs.Size = new System.Drawing.Size(165, 136);
            // 
            // mnuTestJob
            // 
            this.mnuTestJob.Name = "mnuTestJob";
            this.mnuTestJob.Size = new System.Drawing.Size(164, 22);
            this.mnuTestJob.Text = "&Test";
            this.mnuTestJob.Click += new System.EventHandler(this.mnuTestJob_Click);
            // 
            // mnuEchoJob
            // 
            this.mnuEchoJob.Name = "mnuEchoJob";
            this.mnuEchoJob.Size = new System.Drawing.Size(164, 22);
            this.mnuEchoJob.Text = "&Echo";
            this.mnuEchoJob.Click += new System.EventHandler(this.mnuEchoJob_Click);
            // 
            // mnuIPConfig
            // 
            this.mnuIPConfig.Name = "mnuIPConfig";
            this.mnuIPConfig.Size = new System.Drawing.Size(164, 22);
            this.mnuIPConfig.Text = "&IPconfig";
            this.mnuIPConfig.Click += new System.EventHandler(this.mnuIPConfig_Click);
            // 
            // mnuVNC
            // 
            this.mnuVNC.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVNCMike,
            this.mnuVNCJoel,
            this.mnuVNCOther});
            this.mnuVNC.Name = "mnuVNC";
            this.mnuVNC.Size = new System.Drawing.Size(164, 22);
            this.mnuVNC.Text = "&VNC";
            // 
            // mnuVNCMike
            // 
            this.mnuVNCMike.Name = "mnuVNCMike";
            this.mnuVNCMike.Size = new System.Drawing.Size(183, 22);
            this.mnuVNCMike.Text = "&mike.recognin.com";
            this.mnuVNCMike.Click += new System.EventHandler(this.mnuVNCMike_Click);
            // 
            // mnuVNCJoel
            // 
            this.mnuVNCJoel.Name = "mnuVNCJoel";
            this.mnuVNCJoel.Size = new System.Drawing.Size(183, 22);
            this.mnuVNCJoel.Text = "&joel.wektortech.com";
            this.mnuVNCJoel.Click += new System.EventHandler(this.mnuVNCJoel_Click);
            // 
            // mnuVNCOther
            // 
            this.mnuVNCOther.Name = "mnuVNCOther";
            this.mnuVNCOther.Size = new System.Drawing.Size(183, 22);
            this.mnuVNCOther.Text = "&other...";
            this.mnuVNCOther.Click += new System.EventHandler(this.mnuVNCOther_Click);
            // 
            // chkAutoEcho
            // 
            this.chkAutoEcho.AutoSize = true;
            this.chkAutoEcho.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAutoEcho.Location = new System.Drawing.Point(167, 34);
            this.chkAutoEcho.Name = "chkAutoEcho";
            this.chkAutoEcho.Size = new System.Drawing.Size(76, 17);
            this.chkAutoEcho.TabIndex = 38;
            this.chkAutoEcho.Text = "Auto Echo";
            this.chkAutoEcho.UseVisualStyleBackColor = true;
            // 
            // chkAutoCheck
            // 
            this.chkAutoCheck.AutoSize = true;
            this.chkAutoCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAutoCheck.Location = new System.Drawing.Point(261, 34);
            this.chkAutoCheck.Name = "chkAutoCheck";
            this.chkAutoCheck.Size = new System.Drawing.Size(107, 17);
            this.chkAutoCheck.TabIndex = 37;
            this.chkAutoCheck.Text = "Auto Check Jobs";
            this.chkAutoCheck.UseVisualStyleBackColor = true;
            this.chkAutoCheck.CheckedChanged += new System.EventHandler(this.chkAutoCheck_CheckedChanged);
            // 
            // tmr
            // 
            this.tmr.Interval = 1000;
            this.tmr.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // picStatus
            // 
            this.picStatus.Location = new System.Drawing.Point(410, 0);
            this.picStatus.Name = "picStatus";
            this.picStatus.Size = new System.Drawing.Size(23, 20);
            this.picStatus.TabIndex = 39;
            this.picStatus.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(3, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(425, 27);
            this.lblStatus.TabIndex = 40;
            this.lblStatus.Text = "<status>";
            // 
            // lblTargetSession
            // 
            this.lblTargetSession.AutoSize = true;
            this.lblTargetSession.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblTargetSession.Location = new System.Drawing.Point(36, 35);
            this.lblTargetSession.Name = "lblTargetSession";
            this.lblTargetSession.Size = new System.Drawing.Size(84, 13);
            this.lblTargetSession.TabIndex = 41;
            this.lblTargetSession.Text = "<target session>";
            // 
            // lvRunning
            // 
            this.lvRunning.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvRunning.FullRowSelect = true;
            this.lvRunning.Location = new System.Drawing.Point(303, 123);
            this.lvRunning.Name = "lvRunning";
            this.lvRunning.Size = new System.Drawing.Size(125, 122);
            this.lvRunning.TabIndex = 42;
            this.lvRunning.UseCompatibleStateImageBehavior = false;
            this.lvRunning.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 114;
            // 
            // lblRunning
            // 
            this.lblRunning.AutoSize = true;
            this.lblRunning.Location = new System.Drawing.Point(303, 107);
            this.lblRunning.Name = "lblRunning";
            this.lblRunning.Size = new System.Drawing.Size(47, 13);
            this.lblRunning.TabIndex = 43;
            this.lblRunning.Text = "Running";
            // 
            // lblAddRunning
            // 
            this.lblAddRunning.AutoSize = true;
            this.lblAddRunning.Location = new System.Drawing.Point(400, 107);
            this.lblAddRunning.Name = "lblAddRunning";
            this.lblAddRunning.Size = new System.Drawing.Size(25, 13);
            this.lblAddRunning.TabIndex = 44;
            this.lblAddRunning.TabStop = true;
            this.lblAddRunning.Text = "add";
            this.lblAddRunning.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAddRunning_LinkClicked);
            // 
            // mnuRunningJobs
            // 
            this.mnuRunningJobs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileExplorerToolStripMenuItem,
            this.transferFileToolStripMenuItem});
            this.mnuRunningJobs.Name = "mnuRunningJobs";
            this.mnuRunningJobs.Size = new System.Drawing.Size(146, 48);
            // 
            // fileExplorerToolStripMenuItem
            // 
            this.fileExplorerToolStripMenuItem.Name = "fileExplorerToolStripMenuItem";
            this.fileExplorerToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.fileExplorerToolStripMenuItem.Text = "&File Explorer";
            // 
            // transferFileToolStripMenuItem
            // 
            this.transferFileToolStripMenuItem.Name = "transferFileToolStripMenuItem";
            this.transferFileToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.transferFileToolStripMenuItem.Text = "&Transfer File";
            // 
            // mnuUpdateOriginals
            // 
            this.mnuUpdateOriginals.Name = "mnuUpdateOriginals";
            this.mnuUpdateOriginals.Size = new System.Drawing.Size(164, 22);
            this.mnuUpdateOriginals.Text = "Update Originals";
            this.mnuUpdateOriginals.Click += new System.EventHandler(this.mnuUpdateOriginals_Click);
            // 
            // EndView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblAddRunning);
            this.Controls.Add(this.lblRunning);
            this.Controls.Add(this.lvRunning);
            this.Controls.Add(this.lblTargetSession);
            this.Controls.Add(this.lblLogs);
            this.Controls.Add(this.picStatus);
            this.Controls.Add(this.lblClear);
            this.Controls.Add(this.lblCheck);
            this.Controls.Add(this.lblDone);
            this.Controls.Add(this.lvDone);
            this.Controls.Add(this.lvToDo);
            this.Controls.Add(this.lblAdd);
            this.Controls.Add(this.lblToDo);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.gbCurrent);
            this.Controls.Add(this.gbLast);
            this.Controls.Add(this.chkTrack);
            this.Controls.Add(this.chkAutoCheck);
            this.Controls.Add(this.chkAutoEcho);
            this.Controls.Add(this.lblStatus);
            this.Name = "EndView";
            this.Size = new System.Drawing.Size(433, 444);
            this.gbCurrent.ResumeLayout(false);
            this.gbLast.ResumeLayout(false);
            this.mnuJobs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).EndInit();
            this.mnuRunningJobs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblLogs;
        private System.Windows.Forms.LinkLabel lblClear;
        private System.Windows.Forms.CheckBox chkTrack;
        private System.Windows.Forms.LinkLabel lblCheck;
        private System.Windows.Forms.Label lblDone;
        private System.Windows.Forms.ListView lvDone;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView lvToDo;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.LinkLabel lblAdd;
        private System.Windows.Forms.Label lblToDo;
        private Tie.nEndlessStatusBox txtStatus;
        private System.Windows.Forms.GroupBox gbCurrent;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.Label lblLast;
        private System.Windows.Forms.GroupBox gbLast;
        private System.Windows.Forms.Timer tmrJobs;
        private System.Windows.Forms.ContextMenuStrip mnuJobs;
        private System.Windows.Forms.ToolStripMenuItem mnuTestJob;
        private System.Windows.Forms.ToolStripMenuItem mnuEchoJob;
        private System.Windows.Forms.ToolStripMenuItem mnuIPConfig;
        private System.Windows.Forms.ToolStripMenuItem mnuVNC;
        private System.Windows.Forms.ToolStripMenuItem mnuVNCMike;
        private System.Windows.Forms.ToolStripMenuItem mnuVNCJoel;
        private System.Windows.Forms.ToolStripMenuItem mnuVNCOther;
        private System.Windows.Forms.CheckBox chkAutoEcho;
        private System.Windows.Forms.CheckBox chkAutoCheck;
        private System.Windows.Forms.Timer tmr;
        private System.Windows.Forms.PictureBox picStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTargetSession;
        private System.Windows.Forms.ListView lvRunning;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label lblRunning;
        private System.Windows.Forms.LinkLabel lblAddRunning;
        private System.Windows.Forms.ContextMenuStrip mnuRunningJobs;
        private System.Windows.Forms.ToolStripMenuItem fileExplorerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transferFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuUpdateOriginals;
    }
}
