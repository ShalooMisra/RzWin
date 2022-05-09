namespace CoreWin
{
    partial class TabStripCore
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
            if (disposing)
            {
                InitUn();
            }

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabStripCore));
            this.cmdCloseTab = new System.Windows.Forms.Button();
            this.mnuTab = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCloseAllButThis = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLockUnlock = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveAsPicture = new System.Windows.Forms.ToolStripMenuItem();
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.ts = new DraggableTabControl.DraggableTabControl();
            this.mnuTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCloseTab
            // 
            this.cmdCloseTab.Image = ((System.Drawing.Image)(resources.GetObject("cmdCloseTab.Image")));
            this.cmdCloseTab.Location = new System.Drawing.Point(846, 20);
            this.cmdCloseTab.Name = "cmdCloseTab";
            this.cmdCloseTab.Size = new System.Drawing.Size(20, 20);
            this.cmdCloseTab.TabIndex = 51;
            this.cmdCloseTab.UseVisualStyleBackColor = true;
            this.cmdCloseTab.Click += new System.EventHandler(this.cmdCloseTab_Click);
            // 
            // mnuTab
            // 
            this.mnuTab.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuClose,
            this.mnuCloseAllButThis,
            this.mnuLockUnlock,
            this.mnuSaveAsPicture});
            this.mnuTab.Name = "mnuTab";
            this.mnuTab.Size = new System.Drawing.Size(168, 92);
            this.mnuTab.Opening += new System.ComponentModel.CancelEventHandler(this.mnuTab_Opening);
            // 
            // mnuClose
            // 
            this.mnuClose.Name = "mnuClose";
            this.mnuClose.Size = new System.Drawing.Size(167, 22);
            this.mnuClose.Text = "&Close";
            this.mnuClose.Click += new System.EventHandler(this.mnuClose_Click);
            // 
            // mnuCloseAllButThis
            // 
            this.mnuCloseAllButThis.Name = "mnuCloseAllButThis";
            this.mnuCloseAllButThis.Size = new System.Drawing.Size(167, 22);
            this.mnuCloseAllButThis.Text = "Close &All But This";
            this.mnuCloseAllButThis.Click += new System.EventHandler(this.mnuCloseAllButThis_Click);
            // 
            // mnuLockUnlock
            // 
            this.mnuLockUnlock.Name = "mnuLockUnlock";
            this.mnuLockUnlock.Size = new System.Drawing.Size(167, 22);
            this.mnuLockUnlock.Text = "&Lock/UnLock Tab";
            this.mnuLockUnlock.Click += new System.EventHandler(this.mnuLockUnlock_Click);
            // 
            // mnuSaveAsPicture
            // 
            this.mnuSaveAsPicture.Name = "mnuSaveAsPicture";
            this.mnuSaveAsPicture.Size = new System.Drawing.Size(167, 22);
            this.mnuSaveAsPicture.Text = "&Save as a Picture";
            this.mnuSaveAsPicture.Visible = false;
            this.mnuSaveAsPicture.Click += new System.EventHandler(this.mnuSaveAsPicture_Click);
            // 
            // il
            // 
            this.il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il.ImageStream")));
            this.il.TransparentColor = System.Drawing.Color.Magenta;
            this.il.Images.SetKeyName(0, "blank");
            this.il.Images.SetKeyName(1, "lock");
            this.il.Images.SetKeyName(2, "Update");
            // 
            // ts
            // 
            this.ts.AllowDrop = true;
            this.ts.ContextMenuStrip = this.mnuTab;
            this.ts.ImageList = this.il;
            this.ts.Location = new System.Drawing.Point(13, 44);
            this.ts.Name = "ts";
            this.ts.SelectedIndex = 0;
            this.ts.Size = new System.Drawing.Size(853, 492);
            this.ts.TabIndex = 52;
            this.ts.SelectedIndexChanged += new System.EventHandler(this.ts_SelectedIndexChanged);
            this.ts.MouseLeave += new System.EventHandler(this.ts_MouseLeave);
            this.ts.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ts_MouseMove);
            // 
            // TabStripCore
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.ts);
            this.Controls.Add(this.cmdCloseTab);
            this.Name = "TabStripCore";
            this.Size = new System.Drawing.Size(906, 570);
            this.Resize += new System.EventHandler(this.TabStripCore_Resize);
            this.mnuTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdCloseTab;
        private DraggableTabControl.DraggableTabControl ts;
        public System.Windows.Forms.ContextMenuStrip mnuTab;
        private System.Windows.Forms.ToolStripMenuItem mnuClose;
        private System.Windows.Forms.ToolStripMenuItem mnuCloseAllButThis;
        private System.Windows.Forms.ToolStripMenuItem mnuLockUnlock;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveAsPicture;
        private System.Windows.Forms.ImageList il;
    }
}
