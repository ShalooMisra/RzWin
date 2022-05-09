namespace RzSensible
{
    partial class ViewQualityControl
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
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.pRight = new System.Windows.Forms.Panel();
            this.gbPictures = new System.Windows.Forms.GroupBox();
            this.lblLoadPics = new System.Windows.Forms.LinkLabel();
            this.lvPics = new System.Windows.Forms.ListView();
            this.gbNewPicture = new System.Windows.Forms.GroupBox();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.pbNew = new System.Windows.Forms.PictureBox();
            this.lvNew = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fsw2 = new System.IO.FileSystemWatcher();
            this.fsw = new System.IO.FileSystemWatcher();
            this.gbROHS.SuspendLayout();
            this.gbTestInfo.SuspendLayout();
            this.gbStatus.SuspendLayout();
            this.gbLeadFreePassFail.SuspendLayout();
            this.pRight.SuspendLayout();
            this.gbPictures.SuspendLayout();
            this.gbNewPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsw2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsw)).BeginInit();
            this.SuspendLayout();
            // 
            // ctl_internalcomment
            // 
            this.ctl_internalcomment.Location = new System.Drawing.Point(518, 354);
            this.ctl_internalcomment.zz_Enabled = true;
            // 
            // lblAddLog
            // 
            this.lblAddLog.Location = new System.Drawing.Point(706, 354);
            // 
            // lblViewNotes
            // 
            this.lblViewNotes.Location = new System.Drawing.Point(658, 354);
            // 
            // gbROHS
            // 
            this.gbROHS.Location = new System.Drawing.Point(517, 110);
            // 
            // gbTestInfo
            // 
            this.gbTestInfo.Location = new System.Drawing.Point(517, 209);
            // 
            // ctl_processor_name
            // 
            this.ctl_processor_name.Location = new System.Drawing.Point(517, 86);
            // 
            // insCerts
            // 
            this.insCerts.Size = new System.Drawing.Size(510, 45);
            // 
            // insCertsMatch
            // 
            this.insCertsMatch.Location = new System.Drawing.Point(269, 39);
            this.insCertsMatch.Size = new System.Drawing.Size(241, 30);
            // 
            // gbStatus
            // 
            this.gbStatus.Location = new System.Drawing.Point(516, -1);
            // 
            // xActions
            // 
            this.xActions.Location = new System.Drawing.Point(979, 0);
            this.xActions.Size = new System.Drawing.Size(144, 709);
            // 
            // il
            // 
            this.il.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.il.ImageSize = new System.Drawing.Size(32, 32);
            this.il.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pRight
            // 
            this.pRight.BackColor = System.Drawing.Color.White;
            this.pRight.Controls.Add(this.gbPictures);
            this.pRight.Controls.Add(this.gbNewPicture);
            this.pRight.Location = new System.Drawing.Point(738, 3);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(238, 492);
            this.pRight.TabIndex = 33;
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
            // 
            // lvPics
            // 
            this.lvPics.LargeImageList = this.il;
            this.lvPics.Location = new System.Drawing.Point(9, 14);
            this.lvPics.Name = "lvPics";
            this.lvPics.Size = new System.Drawing.Size(218, 292);
            this.lvPics.TabIndex = 0;
            this.lvPics.UseCompatibleStateImageBehavior = false;
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
            // fsw2
            // 
            this.fsw2.EnableRaisingEvents = true;
            this.fsw2.NotifyFilter = System.IO.NotifyFilters.LastWrite;
            this.fsw2.SynchronizingObject = this;
            // 
            // fsw
            // 
            this.fsw.EnableRaisingEvents = true;
            this.fsw.NotifyFilter = System.IO.NotifyFilters.LastWrite;
            this.fsw.SynchronizingObject = this;
            // 
            // ViewQualityControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pRight);
            this.Name = "ViewQualityControl";
            this.Size = new System.Drawing.Size(1123, 709);
            this.Controls.SetChildIndex(this.insCerts, 0);
            this.Controls.SetChildIndex(this.ctl_internalcomment, 0);
            this.Controls.SetChildIndex(this.lblAddLog, 0);
            this.Controls.SetChildIndex(this.insCertsMatch, 0);
            this.Controls.SetChildIndex(this.lblViewNotes, 0);
            this.Controls.SetChildIndex(this.gbStatus, 0);
            this.Controls.SetChildIndex(this.gbROHS, 0);
            this.Controls.SetChildIndex(this.gbTestInfo, 0);
            this.Controls.SetChildIndex(this.ctl_processor_name, 0);
            this.Controls.SetChildIndex(this.cmdTesting, 0);
            this.Controls.SetChildIndex(this.pRight, 0);
            this.Controls.SetChildIndex(this.xActions, 0);
            this.gbROHS.ResumeLayout(false);
            this.gbTestInfo.ResumeLayout(false);
            this.gbStatus.ResumeLayout(false);
            this.gbLeadFreePassFail.ResumeLayout(false);
            this.gbLeadFreePassFail.PerformLayout();
            this.pRight.ResumeLayout(false);
            this.gbPictures.ResumeLayout(false);
            this.gbPictures.PerformLayout();
            this.gbNewPicture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsw2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList il;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.GroupBox gbPictures;
        private System.Windows.Forms.LinkLabel lblLoadPics;
        private System.Windows.Forms.ListView lvPics;
        private System.Windows.Forms.GroupBox gbNewPicture;
        private System.Windows.Forms.Button cmdBrowse;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.PictureBox pbNew;
        private System.Windows.Forms.ListView lvNew;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.IO.FileSystemWatcher fsw2;
        private System.IO.FileSystemWatcher fsw;

    }
}
