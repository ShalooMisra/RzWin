namespace Rz5
{
    partial class frmQC
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
            CompleteDispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQC));
            this.fsw2 = new System.IO.FileSystemWatcher();
            this.pRight = new System.Windows.Forms.Panel();
            this.gbPictures = new System.Windows.Forms.GroupBox();
            this.lblLoadPics = new System.Windows.Forms.LinkLabel();
            this.lvPics = new System.Windows.Forms.ListView();
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.gbNewPicture = new System.Windows.Forms.GroupBox();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.pbNew = new System.Windows.Forms.PictureBox();
            this.lvNew = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fsw = new System.IO.FileSystemWatcher();
            this.mnu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.fsw2)).BeginInit();
            this.pRight.SuspendLayout();
            this.gbPictures.SuspendLayout();
            this.gbNewPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsw)).BeginInit();
            this.mnu.SuspendLayout();
            this.SuspendLayout();
            // 
            // fsw2
            // 
            this.fsw2.EnableRaisingEvents = true;
            this.fsw2.NotifyFilter = System.IO.NotifyFilters.LastWrite;
            this.fsw2.SynchronizingObject = this;
            this.fsw2.Changed += new System.IO.FileSystemEventHandler(this.fsw2_Changed);
            // 
            // pRight
            // 
            this.pRight.BackColor = System.Drawing.Color.White;
            this.pRight.Controls.Add(this.gbPictures);
            this.pRight.Controls.Add(this.gbNewPicture);
            this.pRight.Location = new System.Drawing.Point(736, 0);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(238, 492);
            this.pRight.TabIndex = 11;
            // 
            // gbPictures
            // 
            this.gbPictures.Controls.Add(this.lblLoadPics);
            this.gbPictures.Controls.Add(this.lvPics);
            this.gbPictures.Location = new System.Drawing.Point(3, 3);
            this.gbPictures.Name = "gbPictures";
            this.gbPictures.Size = new System.Drawing.Size(230, 312);
            this.gbPictures.TabIndex = 7;
            this.gbPictures.TabStop = false;
            this.gbPictures.Text = "Pictures";
            // 
            // lblLoadPics
            // 
            this.lblLoadPics.AutoSize = true;
            this.lblLoadPics.Location = new System.Drawing.Point(196, -1);
            this.lblLoadPics.Name = "lblLoadPics";
            this.lblLoadPics.Size = new System.Drawing.Size(27, 13);
            this.lblLoadPics.TabIndex = 1;
            this.lblLoadPics.TabStop = true;
            this.lblLoadPics.Text = "load";
            this.lblLoadPics.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLoadPics_LinkClicked);
            // 
            // lvPics
            // 
            this.lvPics.ContextMenuStrip = this.mnu;
            this.lvPics.LargeImageList = this.il;
            this.lvPics.Location = new System.Drawing.Point(9, 14);
            this.lvPics.Name = "lvPics";
            this.lvPics.Size = new System.Drawing.Size(218, 292);
            this.lvPics.TabIndex = 0;
            this.lvPics.UseCompatibleStateImageBehavior = false;
            // 
            // il
            // 
            this.il.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.il.ImageSize = new System.Drawing.Size(32, 32);
            this.il.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // gbNewPicture
            // 
            this.gbNewPicture.Controls.Add(this.cmdBrowse);
            this.gbNewPicture.Controls.Add(this.cmdAdd);
            this.gbNewPicture.Controls.Add(this.pbNew);
            this.gbNewPicture.Controls.Add(this.lvNew);
            this.gbNewPicture.Location = new System.Drawing.Point(0, 326);
            this.gbNewPicture.Name = "gbNewPicture";
            this.gbNewPicture.Size = new System.Drawing.Size(233, 165);
            this.gbNewPicture.TabIndex = 8;
            this.gbNewPicture.TabStop = false;
            this.gbNewPicture.Text = "New File";
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Location = new System.Drawing.Point(171, 135);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(57, 20);
            this.cmdBrowse.TabIndex = 3;
            this.cmdBrowse.Text = "Browse";
            this.cmdBrowse.UseVisualStyleBackColor = true;
            this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(171, 109);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(57, 20);
            this.cmdAdd.TabIndex = 2;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // pbNew
            // 
            this.pbNew.BackColor = System.Drawing.Color.White;
            this.pbNew.Location = new System.Drawing.Point(172, 52);
            this.pbNew.Name = "pbNew";
            this.pbNew.Size = new System.Drawing.Size(56, 54);
            this.pbNew.TabIndex = 1;
            this.pbNew.TabStop = false;
            // 
            // lvNew
            // 
            this.lvNew.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvNew.FullRowSelect = true;
            this.lvNew.Location = new System.Drawing.Point(9, 16);
            this.lvNew.Name = "lvNew";
            this.lvNew.Size = new System.Drawing.Size(157, 143);
            this.lvNew.TabIndex = 0;
            this.lvNew.UseCompatibleStateImageBehavior = false;
            this.lvNew.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File";
            this.columnHeader1.Width = 114;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Path";
            this.columnHeader2.Width = 78;
            // 
            // fsw
            // 
            this.fsw.EnableRaisingEvents = true;
            this.fsw.NotifyFilter = System.IO.NotifyFilters.LastWrite;
            this.fsw.SynchronizingObject = this;
            this.fsw.Changed += new System.IO.FileSystemEventHandler(this.fsw_Changed);
            // 
            // mnu
            // 
            this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDelete});
            this.mnu.Name = "mnu";
            this.mnu.Size = new System.Drawing.Size(108, 26);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(107, 22);
            this.mnuDelete.Text = "Delete";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // frmQC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 492);
            this.Controls.Add(this.pRight);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmQC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quality Control";
            ((System.ComponentModel.ISupportInitialize)(this.fsw2)).EndInit();
            this.pRight.ResumeLayout(false);
            this.gbPictures.ResumeLayout(false);
            this.gbPictures.PerformLayout();
            this.gbNewPicture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsw)).EndInit();
            this.mnu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.FileSystemWatcher fsw2;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.GroupBox gbPictures;
        private System.Windows.Forms.LinkLabel lblLoadPics;
        private System.Windows.Forms.ListView lvPics;
        private System.Windows.Forms.ImageList il;
        private System.Windows.Forms.GroupBox gbNewPicture;
        private System.Windows.Forms.Button cmdBrowse;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.PictureBox pbNew;
        private System.Windows.Forms.ListView lvNew;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.IO.FileSystemWatcher fsw;
        private System.Windows.Forms.ContextMenuStrip mnu;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
    }
}