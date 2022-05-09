namespace NewMethod
{
    partial class nClip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(nClip));
            this.sc = new System.Windows.Forms.SplitContainer();
            this.chkBlock = new System.Windows.Forms.CheckBox();
            this.tv = new System.Windows.Forms.TreeView();
            this.mnuClip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuRename = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.sepNewFolder = new System.Windows.Forms.ToolStripSeparator();
            this.mnuNewFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClearItems = new System.Windows.Forms.ToolStripMenuItem();
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.lblRefresh = new System.Windows.Forms.LinkLabel();
            this.wb = new ToolsWin.BrowserPlain();
            this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
            this.sc.Panel1.SuspendLayout();
            this.sc.Panel2.SuspendLayout();
            this.sc.SuspendLayout();
            this.mnuClip.SuspendLayout();
            this.SuspendLayout();
            // 
            // sc
            // 
            this.sc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc.Location = new System.Drawing.Point(0, 0);
            this.sc.Name = "sc";
            // 
            // sc.Panel1
            // 
            this.sc.Panel1.Controls.Add(this.chkBlock);
            this.sc.Panel1.Controls.Add(this.tv);
            // 
            // sc.Panel2
            // 
            this.sc.Panel2.Controls.Add(this.lblRefresh);
            this.sc.Panel2.Controls.Add(this.wb);
            this.sc.Size = new System.Drawing.Size(623, 483);
            this.sc.SplitterDistance = 496;
            this.sc.TabIndex = 1;
            this.sc.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.sc_SplitterMoved);
            // 
            // chkBlock
            // 
            this.chkBlock.AutoSize = true;
            this.chkBlock.Location = new System.Drawing.Point(9, 457);
            this.chkBlock.Name = "chkBlock";
            this.chkBlock.Size = new System.Drawing.Size(129, 17);
            this.chkBlock.TabIndex = 2;
            this.chkBlock.Text = "Enable Auto Tracking";
            this.chkBlock.UseVisualStyleBackColor = true;
            this.chkBlock.CheckedChanged += new System.EventHandler(this.chkBlock_CheckedChanged);
            // 
            // tv
            // 
            this.tv.AllowDrop = true;
            this.tv.ContextMenuStrip = this.mnuClip;
            this.tv.ImageIndex = 0;
            this.tv.ImageList = this.il;
            this.tv.Location = new System.Drawing.Point(0, 0);
            this.tv.Name = "tv";
            this.tv.SelectedImageIndex = 0;
            this.tv.Size = new System.Drawing.Size(473, 450);
            this.tv.TabIndex = 1;
            this.tv.DragDrop += new System.Windows.Forms.DragEventHandler(this.tv_DragDrop);
            this.tv.DragOver += new System.Windows.Forms.DragEventHandler(this.tv_DragOver);
            this.tv.DoubleClick += new System.EventHandler(this.tv_DoubleClick);
            this.tv.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tv_AfterLabelEdit);
            this.tv.DragEnter += new System.Windows.Forms.DragEventHandler(this.tv_DragEnter);
            this.tv.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tv_ItemDrag);
            this.tv.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tv_MouseDown);
            this.tv.Click += new System.EventHandler(this.tv_Click);
            // 
            // mnuClip
            // 
            this.mnuClip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRename,
            this.mnuRefresh,
            this.mnuOpen,
            this.sepNewFolder,
            this.mnuNewFolder,
            this.toolStripSeparator2,
            this.mnuDelete,
            this.mnuClearItems});
            this.mnuClip.Name = "mnuClip";
            this.mnuClip.Size = new System.Drawing.Size(190, 148);
            this.mnuClip.Opening += new System.ComponentModel.CancelEventHandler(this.mnuClip_Opening);
            // 
            // mnuRename
            // 
            this.mnuRename.Name = "mnuRename";
            this.mnuRename.Size = new System.Drawing.Size(189, 22);
            this.mnuRename.Text = "&Rename";
            this.mnuRename.Click += new System.EventHandler(this.mnuRename_Click);
            // 
            // mnuRefresh
            // 
            this.mnuRefresh.Name = "mnuRefresh";
            this.mnuRefresh.Size = new System.Drawing.Size(189, 22);
            this.mnuRefresh.Text = "Re&fresh the Caption";
            this.mnuRefresh.Click += new System.EventHandler(this.mnuRefresh_Click);
            // 
            // mnuOpen
            // 
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(189, 22);
            this.mnuOpen.Text = "&Open";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // sepNewFolder
            // 
            this.sepNewFolder.Name = "sepNewFolder";
            this.sepNewFolder.Size = new System.Drawing.Size(186, 6);
            // 
            // mnuNewFolder
            // 
            this.mnuNewFolder.Name = "mnuNewFolder";
            this.mnuNewFolder.Size = new System.Drawing.Size(189, 22);
            this.mnuNewFolder.Text = "&New Folder";
            this.mnuNewFolder.Click += new System.EventHandler(this.mnuNewFolder_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(186, 6);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(189, 22);
            this.mnuDelete.Text = "&Delete from Clipboard";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // mnuClearItems
            // 
            this.mnuClearItems.Name = "mnuClearItems";
            this.mnuClearItems.Size = new System.Drawing.Size(189, 22);
            this.mnuClearItems.Text = "&Clear Items";
            this.mnuClearItems.Click += new System.EventHandler(this.mnuClearItems_Click);
            // 
            // il
            // 
            this.il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il.ImageStream")));
            this.il.TransparentColor = System.Drawing.Color.Transparent;
            this.il.Images.SetKeyName(0, "search4files.ico");
            this.il.Images.SetKeyName(1, "folderopen.ico");
            this.il.Images.SetKeyName(2, "document.ico");
            this.il.Images.SetKeyName(3, "security.ico");
            this.il.Images.SetKeyName(4, "globe.ico");
            this.il.Images.SetKeyName(5, "newfolder.ico");
            // 
            // lblRefresh
            // 
            this.lblRefresh.AutoSize = true;
            this.lblRefresh.Location = new System.Drawing.Point(4, 421);
            this.lblRefresh.Name = "lblRefresh";
            this.lblRefresh.Size = new System.Drawing.Size(44, 13);
            this.lblRefresh.TabIndex = 1;
            this.lblRefresh.TabStop = true;
            this.lblRefresh.Text = "Refresh";
            this.lblRefresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRefresh_LinkClicked);
            // 
            // wb
            // 
            this.wb.Location = new System.Drawing.Point(2, 15);
            this.wb.Name = "wb";
            this.wb.ShowControls = false;
            this.wb.Silent = false;
            this.wb.Size = new System.Drawing.Size(88, 397);
            this.wb.TabIndex = 0;
            this.wb.OnNavigate += new ToolsWin.OnNavigateHandler(this.wb_OnNavigate);
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Interval = 8000;
            this.tmrRefresh.Tick += new System.EventHandler(this.tmrRefresh_Tick);
            // 
            // nClip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sc);
            this.Name = "nClip";
            this.Size = new System.Drawing.Size(623, 483);
            this.Resize += new System.EventHandler(this.nClip_Resize);
            this.sc.Panel1.ResumeLayout(false);
            this.sc.Panel1.PerformLayout();
            this.sc.Panel2.ResumeLayout(false);
            this.sc.Panel2.PerformLayout();
            this.sc.ResumeLayout(false);
            this.mnuClip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sc;
        private System.Windows.Forms.TreeView tv;
        private ToolsWin.BrowserPlain wb;
        private System.Windows.Forms.ContextMenuStrip mnuClip;
        private System.Windows.Forms.ToolStripMenuItem mnuRename;
        private System.Windows.Forms.ToolStripMenuItem mnuRefresh;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripSeparator sepNewFolder;
        private System.Windows.Forms.ToolStripMenuItem mnuNewFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ImageList il;
        private System.Windows.Forms.ToolStripMenuItem mnuClearItems;
        private System.Windows.Forms.LinkLabel lblRefresh;
        private System.Windows.Forms.Timer tmrRefresh;
        private System.Windows.Forms.CheckBox chkBlock;

    }
}
