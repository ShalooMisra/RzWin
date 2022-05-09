namespace Rz5.Focus
{
    partial class FocusItems
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
                    UnloadItems();
                    CompleteDispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FocusItems));
            this.lv = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mnu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuDone = new System.Windows.Forms.ToolStripMenuItem();
            this.fp = new System.Windows.Forms.FlowLayoutPanel();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.cmdClearAll = new System.Windows.Forms.Button();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lv
            // 
            this.lv.CheckBoxes = true;
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lv.ContextMenuStrip = this.mnu;
            this.lv.FullRowSelect = true;
            this.lv.Location = new System.Drawing.Point(3, 61);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(419, 578);
            this.lv.TabIndex = 0;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv_ItemChecked);
            this.lv.DoubleClick += new System.EventHandler(this.lv_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 116;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Description";
            this.columnHeader2.Width = 278;
            // 
            // mnu
            // 
            this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpen,
            this.toolStripSeparator1,
            this.mnuDone});
            this.mnu.Name = "mnu";
            this.mnu.Size = new System.Drawing.Size(104, 54);
            // 
            // mnuDone
            // 
            this.mnuDone.Name = "mnuDone";
            this.mnuDone.Size = new System.Drawing.Size(152, 22);
            this.mnuDone.Text = "&Done";
            this.mnuDone.Click += new System.EventHandler(this.mnuDone_Click);
            // 
            // fp
            // 
            this.fp.AutoScroll = true;
            this.fp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fp.Location = new System.Drawing.Point(428, 8);
            this.fp.Name = "fp";
            this.fp.Size = new System.Drawing.Size(682, 631);
            this.fp.TabIndex = 1;
            this.fp.WrapContents = false;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdRefresh.ImageIndex = 2;
            this.cmdRefresh.ImageList = this.il;
            this.cmdRefresh.Location = new System.Drawing.Point(3, 3);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(116, 52);
            this.cmdRefresh.TabIndex = 2;
            this.cmdRefresh.Text = "Refresh";
            this.cmdRefresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // il
            // 
            this.il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il.ImageStream")));
            this.il.TransparentColor = System.Drawing.Color.Magenta;
            this.il.Images.SetKeyName(0, "newtick");
            this.il.Images.SetKeyName(1, "closewindow");
            this.il.Images.SetKeyName(2, "refresh");
            // 
            // cmdClearAll
            // 
            this.cmdClearAll.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdClearAll.ImageIndex = 0;
            this.cmdClearAll.ImageList = this.il;
            this.cmdClearAll.Location = new System.Drawing.Point(129, 3);
            this.cmdClearAll.Name = "cmdClearAll";
            this.cmdClearAll.Size = new System.Drawing.Size(116, 52);
            this.cmdClearAll.TabIndex = 3;
            this.cmdClearAll.Text = "Clear All";
            this.cmdClearAll.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdClearAll.UseVisualStyleBackColor = true;
            this.cmdClearAll.Click += new System.EventHandler(this.cmdClearAll_Click);
            // 
            // mnuOpen
            // 
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(152, 22);
            this.mnuOpen.Text = "Open";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // FocusItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdClearAll);
            this.Controls.Add(this.cmdRefresh);
            this.Controls.Add(this.fp);
            this.Controls.Add(this.lv);
            this.Name = "FocusItems";
            this.Size = new System.Drawing.Size(1130, 658);
            this.Resize += new System.EventHandler(this.FocusItems_Resize);
            this.mnu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.FlowLayoutPanel fp;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.ContextMenuStrip mnu;
        private System.Windows.Forms.ToolStripMenuItem mnuDone;
        private System.Windows.Forms.Button cmdClearAll;
        private System.Windows.Forms.ImageList il;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}
