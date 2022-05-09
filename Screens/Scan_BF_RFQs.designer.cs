namespace Rz5
{
    partial class Scan_BF_RFQs
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
            this.sb = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.sp = new System.Windows.Forms.SplitContainer();
            this.wb = new ToolsWin.Browser();
            this.ts = new System.Windows.Forms.TabControl();
            this.pageResult = new System.Windows.Forms.TabPage();
            this.lvReqs = new NewMethod.nList();
            this.lv = new NewMethod.nList();
            this.wb2 = new ToolsWin.Browser();
            this.pageSearch = new System.Windows.Forms.TabPage();
            this.lvParts = new NewMethod.nList();
            this.pb = new System.Windows.Forms.PictureBox();
            this.gb = new System.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.cmdMatch = new System.Windows.Forms.Button();
            this.cmdNavigateToPurchaseInbox = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdScan = new System.Windows.Forms.Button();
            this.sb.SuspendLayout();
            this.sp.Panel1.SuspendLayout();
            this.sp.Panel2.SuspendLayout();
            this.sp.SuspendLayout();
            this.ts.SuspendLayout();
            this.pageResult.SuspendLayout();
            this.pageSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // sb
            // 
            this.sb.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.sb.Location = new System.Drawing.Point(0, 865);
            this.sb.Name = "sb";
            this.sb.Size = new System.Drawing.Size(971, 22);
            this.sb.TabIndex = 7;
            this.sb.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(54, 17);
            this.lblStatus.Text = "<status>";
            // 
            // sp
            // 
            this.sp.Location = new System.Drawing.Point(3, 3);
            this.sp.Name = "sp";
            this.sp.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sp.Panel1
            // 
            this.sp.Panel1.Controls.Add(this.wb);
            // 
            // sp.Panel2
            // 
            this.sp.Panel2.Controls.Add(this.ts);
            this.sp.Panel2.Controls.Add(this.pb);
            this.sp.Panel2.Controls.Add(this.gb);
            this.sp.Size = new System.Drawing.Size(1015, 845);
            this.sp.SplitterDistance = 211;
            this.sp.TabIndex = 13;
            this.sp.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.sp_SplitterMoved);
            // 
            // wb
            // 
            this.wb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wb.Location = new System.Drawing.Point(0, 0);
            this.wb.Name = "wb";
            this.wb.ShowControls = false;
            this.wb.Silent = true;
            this.wb.Size = new System.Drawing.Size(1015, 211);
            this.wb.TabIndex = 5;
            // 
            // ts
            // 
            this.ts.Controls.Add(this.pageResult);
            this.ts.Controls.Add(this.pageSearch);
            this.ts.Location = new System.Drawing.Point(187, 117);
            this.ts.Name = "ts";
            this.ts.SelectedIndex = 0;
            this.ts.Size = new System.Drawing.Size(669, 398);
            this.ts.TabIndex = 14;
            // 
            // pageResult
            // 
            this.pageResult.Controls.Add(this.lvReqs);
            this.pageResult.Controls.Add(this.lv);
            this.pageResult.Controls.Add(this.wb2);
            this.pageResult.Location = new System.Drawing.Point(4, 22);
            this.pageResult.Name = "pageResult";
            this.pageResult.Padding = new System.Windows.Forms.Padding(3);
            this.pageResult.Size = new System.Drawing.Size(661, 372);
            this.pageResult.TabIndex = 0;
            this.pageResult.Text = "Result";
            this.pageResult.UseVisualStyleBackColor = true;
            // 
            // lvReqs
            // 
            this.lvReqs.AddCaption = "Add New";
            this.lvReqs.AllowActions = true;
            this.lvReqs.AllowAdd = false;
            this.lvReqs.AllowDelete = true;
            this.lvReqs.AllowDeleteAlways = false;
            this.lvReqs.AllowDrop = true;
            this.lvReqs.AlternateConnection = null;
            this.lvReqs.Caption = "";
            this.lvReqs.CurrentTemplate = null;
            this.lvReqs.ExtraClassInfo = "";
            this.lvReqs.Location = new System.Drawing.Point(196, 54);
            this.lvReqs.MultiSelect = true;
            this.lvReqs.Name = "lvReqs";
            this.lvReqs.Size = new System.Drawing.Size(154, 78);
            this.lvReqs.SuppressSelectionChanged = false;
            this.lvReqs.TabIndex = 9;
            this.lvReqs.zz_OpenColumnMenu = false;
            this.lvReqs.zz_ShowAutoRefresh = true;
            this.lvReqs.zz_ShowUnlimited = true;
            this.lvReqs.ObjectClicked += new NewMethod.ObjectClickHandler(this.lvReqs_ObjectClicked);
            // 
            // lv
            // 
            this.lv.AddCaption = "Add New";
            this.lv.AllowActions = true;
            this.lv.AllowAdd = false;
            this.lv.AllowDelete = true;
            this.lv.AllowDeleteAlways = false;
            this.lv.AllowDrop = true;
            this.lv.AlternateConnection = null;
            this.lv.Caption = "";
            this.lv.CurrentTemplate = null;
            this.lv.ExtraClassInfo = "";
            this.lv.Location = new System.Drawing.Point(179, 15);
            this.lv.MultiSelect = true;
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(342, 163);
            this.lv.SuppressSelectionChanged = false;
            this.lv.TabIndex = 6;
            this.lv.zz_OpenColumnMenu = false;
            this.lv.zz_ShowAutoRefresh = true;
            this.lv.zz_ShowUnlimited = true;
            // 
            // wb2
            // 
            this.wb2.Location = new System.Drawing.Point(8, 4);
            this.wb2.Name = "wb2";
            this.wb2.ShowControls = false;
            this.wb2.Silent = true;
            this.wb2.Size = new System.Drawing.Size(264, 78);
            this.wb2.TabIndex = 8;
            // 
            // pageSearch
            // 
            this.pageSearch.Controls.Add(this.lvParts);
            this.pageSearch.Location = new System.Drawing.Point(4, 22);
            this.pageSearch.Name = "pageSearch";
            this.pageSearch.Padding = new System.Windows.Forms.Padding(3);
            this.pageSearch.Size = new System.Drawing.Size(661, 372);
            this.pageSearch.TabIndex = 1;
            this.pageSearch.Text = "Search";
            this.pageSearch.UseVisualStyleBackColor = true;
            // 
            // lvParts
            // 
            this.lvParts.AddCaption = "Add New";
            this.lvParts.AllowActions = true;
            this.lvParts.AllowAdd = false;
            this.lvParts.AllowDelete = true;
            this.lvParts.AllowDeleteAlways = false;
            this.lvParts.AllowDrop = true;
            this.lvParts.AlternateConnection = null;
            this.lvParts.Caption = "";
            this.lvParts.CurrentTemplate = null;
            this.lvParts.ExtraClassInfo = "";
            this.lvParts.Location = new System.Drawing.Point(3, 3);
            this.lvParts.MultiSelect = true;
            this.lvParts.Name = "lvParts";
            this.lvParts.Size = new System.Drawing.Size(655, 259);
            this.lvParts.SuppressSelectionChanged = false;
            this.lvParts.TabIndex = 1;
            this.lvParts.zz_OpenColumnMenu = false;
            this.lvParts.zz_ShowAutoRefresh = true;
            this.lvParts.zz_ShowUnlimited = true;
            // 
            // pb
            // 
            this.pb.BackColor = System.Drawing.Color.Blue;
            this.pb.Location = new System.Drawing.Point(377, 4);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(101, 4);
            this.pb.TabIndex = 13;
            this.pb.TabStop = false;
            // 
            // gb
            // 
            this.gb.Controls.Add(this.txtSearch);
            this.gb.Controls.Add(this.cmdSearch);
            this.gb.Controls.Add(this.cmdMatch);
            this.gb.Controls.Add(this.cmdNavigateToPurchaseInbox);
            this.gb.Controls.Add(this.cmdSave);
            this.gb.Controls.Add(this.cmdScan);
            this.gb.Location = new System.Drawing.Point(13, 15);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(169, 360);
            this.gb.TabIndex = 4;
            this.gb.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(13, 218);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(145, 20);
            this.txtSearch.TabIndex = 8;
            // 
            // cmdSearch
            // 
            this.cmdSearch.Location = new System.Drawing.Point(11, 243);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(147, 26);
            this.cmdSearch.TabIndex = 7;
            this.cmdSearch.Text = "Part Search";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // cmdMatch
            // 
            this.cmdMatch.Location = new System.Drawing.Point(7, 277);
            this.cmdMatch.Name = "cmdMatch";
            this.cmdMatch.Size = new System.Drawing.Size(156, 25);
            this.cmdMatch.TabIndex = 3;
            this.cmdMatch.Text = "Match To RFQs";
            this.cmdMatch.UseVisualStyleBackColor = true;
            this.cmdMatch.Visible = false;
            this.cmdMatch.Click += new System.EventHandler(this.cmdMatch_Click);
            // 
            // cmdNavigateToPurchaseInbox
            // 
            this.cmdNavigateToPurchaseInbox.Location = new System.Drawing.Point(7, 19);
            this.cmdNavigateToPurchaseInbox.Name = "cmdNavigateToPurchaseInbox";
            this.cmdNavigateToPurchaseInbox.Size = new System.Drawing.Size(156, 55);
            this.cmdNavigateToPurchaseInbox.TabIndex = 2;
            this.cmdNavigateToPurchaseInbox.Text = "Navigate To Purchase Inbox";
            this.cmdNavigateToPurchaseInbox.UseVisualStyleBackColor = true;
            this.cmdNavigateToPurchaseInbox.Visible = false;
            this.cmdNavigateToPurchaseInbox.Click += new System.EventHandler(this.cmdNavigateToPurchaseInbox_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(6, 163);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(156, 52);
            this.cmdSave.TabIndex = 1;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdScan
            // 
            this.cmdScan.Location = new System.Drawing.Point(7, 102);
            this.cmdScan.Name = "cmdScan";
            this.cmdScan.Size = new System.Drawing.Size(156, 55);
            this.cmdScan.TabIndex = 0;
            this.cmdScan.Text = "Scan";
            this.cmdScan.UseVisualStyleBackColor = true;
            this.cmdScan.Click += new System.EventHandler(this.cmdScan_Click);
            // 
            // Scan_BF_RFQs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sp);
            this.Controls.Add(this.sb);
            this.Name = "Scan_BF_RFQs";
            this.Size = new System.Drawing.Size(971, 887);
            this.Resize += new System.EventHandler(this.Scan_BF_RFQs_Resize);
            this.sb.ResumeLayout(false);
            this.sb.PerformLayout();
            this.sp.Panel1.ResumeLayout(false);
            this.sp.Panel2.ResumeLayout(false);
            this.sp.ResumeLayout(false);
            this.ts.ResumeLayout(false);
            this.pageResult.ResumeLayout(false);
            this.pageSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip sb;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private NewMethod.nList lv;
        private ToolsWin.Browser wb;
        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdScan;
        private ToolsWin.Browser wb2;
        private System.Windows.Forms.Button cmdNavigateToPurchaseInbox;
        private System.Windows.Forms.Button cmdMatch;
        private NewMethod.nList lvReqs;
        private System.Windows.Forms.SplitContainer sp;
        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.TabControl ts;
        private System.Windows.Forms.TabPage pageResult;
        private System.Windows.Forms.TabPage pageSearch;
        private NewMethod.nList lvParts;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button cmdSearch;
    }
}
