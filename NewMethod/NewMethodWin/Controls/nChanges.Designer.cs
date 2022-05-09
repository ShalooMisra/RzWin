namespace NewMethod
{
    partial class nChanges
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
            this.lv = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.sp = new System.Windows.Forms.SplitContainer();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.mnuRecall = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.wb = new ToolsWin.BrowserPlain();
            this.wb2 = new ToolsWin.BrowserPlain();
            this.sp.Panel1.SuspendLayout();
            this.sp.Panel2.SuspendLayout();
            this.sp.SuspendLayout();
            this.mnuRecall.SuspendLayout();
            this.SuspendLayout();
            // 
            // lv
            // 
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lv.ContextMenuStrip = this.mnuRecall;
            this.lv.FullRowSelect = true;
            this.lv.Location = new System.Drawing.Point(566, 0);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(224, 592);
            this.lv.TabIndex = 1;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.Click += new System.EventHandler(this.lv_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Date";
            this.columnHeader1.Width = 58;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "User";
            this.columnHeader2.Width = 47;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Machine";
            this.columnHeader3.Width = 61;
            // 
            // sp
            // 
            this.sp.Location = new System.Drawing.Point(17, 18);
            this.sp.Name = "sp";
            this.sp.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sp.Panel1
            // 
            this.sp.Panel1.Controls.Add(this.wb);
            // 
            // sp.Panel2
            // 
            this.sp.Panel2.Controls.Add(this.wb2);
            this.sp.Size = new System.Drawing.Size(514, 391);
            this.sp.SplitterDistance = 231;
            this.sp.TabIndex = 2;
            this.sp.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.sp_SplitterMoved);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Version";
            // 
            // mnuRecall
            // 
            this.mnuRecall.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRestore});
            this.mnuRecall.Name = "mnuRecall";
            this.mnuRecall.Size = new System.Drawing.Size(124, 26);
            // 
            // mnuRestore
            // 
            this.mnuRestore.Name = "mnuRestore";
            this.mnuRestore.Size = new System.Drawing.Size(123, 22);
            this.mnuRestore.Text = "&Restore";
            this.mnuRestore.Click += new System.EventHandler(this.mnuRestore_Click);
            // 
            // wb
            // 
            this.wb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wb.Location = new System.Drawing.Point(0, 0);
            this.wb.Name = "wb";
            this.wb.Silent = false;
            this.wb.Size = new System.Drawing.Size(514, 231);
            this.wb.TabIndex = 0;
            // 
            // wb2
            // 
            this.wb2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wb2.Location = new System.Drawing.Point(0, 0);
            this.wb2.Name = "wb2";
            this.wb2.Silent = false;
            this.wb2.Size = new System.Drawing.Size(514, 156);
            this.wb2.TabIndex = 1;
            // 
            // nChanges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sp);
            this.Controls.Add(this.lv);
            this.Name = "nChanges";
            this.Size = new System.Drawing.Size(806, 598);
            this.Resize += new System.EventHandler(this.nChanges_Resize);
            this.sp.Panel1.ResumeLayout(false);
            this.sp.Panel2.ResumeLayout(false);
            this.sp.ResumeLayout(false);
            this.mnuRecall.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ToolsWin.BrowserPlain wb;
        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.SplitContainer sp;
        private ToolsWin.BrowserPlain wb2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ContextMenuStrip mnuRecall;
        private System.Windows.Forms.ToolStripMenuItem mnuRestore;
    }
}
