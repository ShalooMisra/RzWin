using System;

namespace Tie
{
    partial class EyeView
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
                if (CurrentEye != null)
                {
                    CurrentEye.ConnectionAdded -= new ConnectionChangeHandler(CurrentEye_ConnectionAdded);
                    CurrentEye.ConnectionUpdated -= new ConnectionChangeHandler(CurrentEye_ConnectionUpdated);
                    CurrentEye.ConnectionLost -= new ConnectionChangeHandler(CurrentEye_ConnectionLost);
                    CurrentEye.GotStatus += new EyeStatusHandler(CurrentEye_GotStatus);
                }

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
            this.lv = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.mnuConnection = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuTrack = new System.Windows.Forms.ToolStripMenuItem();
            this.viewLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPermanentlyDrop = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdOpen = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdCloseFast = new System.Windows.Forms.Button();
            this.cmdDropAll = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.chkFlaky = new System.Windows.Forms.CheckBox();
            this.txtStatus = new Tie.nEndlessStatusBox();
            this.lblCaption = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.mnuConnection.SuspendLayout();
            this.SuspendLayout();
            // 
            // lv
            // 
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader1,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lv.ContextMenuStrip = this.mnuConnection;
            this.lv.FullRowSelect = true;
            this.lv.Location = new System.Drawing.Point(8, 168);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(807, 146);
            this.lv.TabIndex = 3;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.DoubleClick += new System.EventHandler(this.lv_DoubleClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Machine";
            this.columnHeader2.Width = 93;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Last Ping";
            this.columnHeader3.Width = 134;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Status";
            this.columnHeader4.Width = 103;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "SessionID";
            this.columnHeader1.Width = 103;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "IP";
            this.columnHeader5.Width = 82;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Application";
            this.columnHeader6.Width = 89;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Version";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "User";
            // 
            // mnuConnection
            // 
            this.mnuConnection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTrack,
            this.viewLogsToolStripMenuItem,
            this.toolStripSeparator1,
            this.mnuPermanentlyDrop});
            this.mnuConnection.Name = "mnuConnection";
            this.mnuConnection.Size = new System.Drawing.Size(172, 76);
            this.mnuConnection.Opening += new System.ComponentModel.CancelEventHandler(this.mnuConnection_Opening);
            // 
            // mnuTrack
            // 
            this.mnuTrack.CheckOnClick = true;
            this.mnuTrack.Name = "mnuTrack";
            this.mnuTrack.Size = new System.Drawing.Size(171, 22);
            this.mnuTrack.Text = "&Track";
            this.mnuTrack.Click += new System.EventHandler(this.mnuTrack_Click);
            // 
            // viewLogsToolStripMenuItem
            // 
            this.viewLogsToolStripMenuItem.Name = "viewLogsToolStripMenuItem";
            this.viewLogsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.viewLogsToolStripMenuItem.Text = "View &Logs";
            this.viewLogsToolStripMenuItem.Click += new System.EventHandler(this.viewLogsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(168, 6);
            // 
            // mnuPermanentlyDrop
            // 
            this.mnuPermanentlyDrop.Name = "mnuPermanentlyDrop";
            this.mnuPermanentlyDrop.Size = new System.Drawing.Size(171, 22);
            this.mnuPermanentlyDrop.Text = "&Permanently Drop";
            this.mnuPermanentlyDrop.Click += new System.EventHandler(this.mnuPermanentlyDrop_Click);
            // 
            // cmdOpen
            // 
            this.cmdOpen.Location = new System.Drawing.Point(3, 46);
            this.cmdOpen.Name = "cmdOpen";
            this.cmdOpen.Size = new System.Drawing.Size(134, 22);
            this.cmdOpen.TabIndex = 5;
            this.cmdOpen.Text = "Open";
            this.cmdOpen.UseVisualStyleBackColor = true;
            this.cmdOpen.Click += new System.EventHandler(this.cmdOpen_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(3, 89);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(134, 22);
            this.cmdClose.TabIndex = 6;
            this.cmdClose.Text = "Close [notify]";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdCloseFast
            // 
            this.cmdCloseFast.Location = new System.Drawing.Point(3, 111);
            this.cmdCloseFast.Name = "cmdCloseFast";
            this.cmdCloseFast.Size = new System.Drawing.Size(134, 22);
            this.cmdCloseFast.TabIndex = 7;
            this.cmdCloseFast.Text = "Close [fast]";
            this.cmdCloseFast.UseVisualStyleBackColor = true;
            this.cmdCloseFast.Click += new System.EventHandler(this.cmdCloseFast_Click);
            // 
            // cmdDropAll
            // 
            this.cmdDropAll.Location = new System.Drawing.Point(3, 68);
            this.cmdDropAll.Name = "cmdDropAll";
            this.cmdDropAll.Size = new System.Drawing.Size(134, 22);
            this.cmdDropAll.TabIndex = 8;
            this.cmdDropAll.Text = "Drop All Clients";
            this.cmdDropAll.UseVisualStyleBackColor = true;
            this.cmdDropAll.Click += new System.EventHandler(this.cmdDropAll_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(5, 7);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(132, 39);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "<status>";
            // 
            // tmr
            // 
            this.tmr.Interval = 1000;
            this.tmr.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // chkFlaky
            // 
            this.chkFlaky.AutoSize = true;
            this.chkFlaky.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFlaky.Location = new System.Drawing.Point(86, 32);
            this.chkFlaky.Name = "chkFlaky";
            this.chkFlaky.Size = new System.Drawing.Size(51, 17);
            this.chkFlaky.TabIndex = 14;
            this.chkFlaky.Text = "Flaky";
            this.chkFlaky.UseVisualStyleBackColor = true;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(143, 24);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(672, 138);
            this.txtStatus.TabIndex = 4;
            this.txtStatus.Text = "";
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Location = new System.Drawing.Point(143, 7);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(54, 13);
            this.lblCaption.TabIndex = 15;
            this.lblCaption.Text = "<caption>";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(51, 138);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(57, 20);
            this.txtPort.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Port:";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Credentials";
            // 
            // EyeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.cmdCloseFast);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.cmdDropAll);
            this.Controls.Add(this.lv);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdOpen);
            this.Controls.Add(this.chkFlaky);
            this.Controls.Add(this.lblStatus);
            this.Name = "EyeView";
            this.Size = new System.Drawing.Size(819, 317);
            this.Resize += new System.EventHandler(this.EyeView_Resize);
            this.mnuConnection.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private Tie.nEndlessStatusBox txtStatus;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button cmdOpen;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdCloseFast;
        private System.Windows.Forms.Button cmdDropAll;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Timer tmr;
        private System.Windows.Forms.CheckBox chkFlaky;
        private System.Windows.Forms.ContextMenuStrip mnuConnection;
        private System.Windows.Forms.ToolStripMenuItem mnuTrack;
        private System.Windows.Forms.ToolStripMenuItem viewLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuPermanentlyDrop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader9;
    }
}
