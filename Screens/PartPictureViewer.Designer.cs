namespace Rz5
{
    partial class PartPictureViewer
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
                CompleteDispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PartPictureViewer));
            this.lblFileName = new System.Windows.Forms.Label();
            this.lblComments = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.txtComments = new System.Windows.Forms.RichTextBox();
            this.lblPartNumber = new System.Windows.Forms.LinkLabel();
            this.mnu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdFullScreen = new System.Windows.Forms.Button();
            this.cmdZoom = new System.Windows.Forms.Button();
            this.picPicture = new System.Windows.Forms.PictureBox();
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdUpdatePicture = new System.Windows.Forms.Button();
            this.cmdDeletePicture = new System.Windows.Forms.Button();
            this.cmdAddPicture = new System.Windows.Forms.Button();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.oFile = new System.Windows.Forms.OpenFileDialog();
            this.cmdUnZoom = new System.Windows.Forms.Button();
            this.picZoomView = new System.Windows.Forms.PictureBox();
            this.chkAutoWatch = new System.Windows.Forms.CheckBox();
            this.fsw = new System.IO.FileSystemWatcher();
            this.sFile = new System.Windows.Forms.SaveFileDialog();
            this.cmdGrab = new System.Windows.Forms.Button();
            this.lnkDefaultPath = new System.Windows.Forms.LinkLabel();
            this.pOptions = new System.Windows.Forms.Panel();
            this.lblLinks = new System.Windows.Forms.Label();
            this.lvPictures = new NewMethod.nList();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.mnu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPicture)).BeginInit();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picZoomView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsw)).BeginInit();
            this.pOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.Location = new System.Drawing.Point(4, 9);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(77, 15);
            this.lblFileName.TabIndex = 21;
            this.lblFileName.Text = "Attachment :";
            // 
            // lblComments
            // 
            this.lblComments.AutoSize = true;
            this.lblComments.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComments.Location = new System.Drawing.Point(322, 7);
            this.lblComments.Name = "lblComments";
            this.lblComments.Size = new System.Drawing.Size(75, 15);
            this.lblComments.TabIndex = 22;
            this.lblComments.Text = "Description:";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(83, 7);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(184, 22);
            this.txtFileName.TabIndex = 23;
            // 
            // txtComments
            // 
            this.txtComments.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComments.Location = new System.Drawing.Point(325, 25);
            this.txtComments.Name = "txtComments";
            this.txtComments.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtComments.Size = new System.Drawing.Size(219, 61);
            this.txtComments.TabIndex = 24;
            this.txtComments.Text = "";
            // 
            // lblPartNumber
            // 
            this.lblPartNumber.ActiveLinkColor = System.Drawing.Color.Black;
            this.lblPartNumber.ContextMenuStrip = this.mnu;
            this.lblPartNumber.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartNumber.LinkColor = System.Drawing.Color.Black;
            this.lblPartNumber.Location = new System.Drawing.Point(31, 10);
            this.lblPartNumber.Name = "lblPartNumber";
            this.lblPartNumber.Size = new System.Drawing.Size(417, 29);
            this.lblPartNumber.TabIndex = 29;
            this.lblPartNumber.TabStop = true;
            this.lblPartNumber.Text = "PARTNUMBER";
            this.lblPartNumber.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblPartNumber.VisitedLinkColor = System.Drawing.Color.Black;
            this.lblPartNumber.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblPartNumber_LinkClicked);
            // 
            // mnu
            // 
            this.mnu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.mnu.Name = "menu";
            this.mnu.Size = new System.Drawing.Size(103, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItem1.Text = "Copy";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // cmdFullScreen
            // 
            this.cmdFullScreen.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFullScreen.Image = ((System.Drawing.Image)(resources.GetObject("cmdFullScreen.Image")));
            this.cmdFullScreen.Location = new System.Drawing.Point(439, 42);
            this.cmdFullScreen.Name = "cmdFullScreen";
            this.cmdFullScreen.Size = new System.Drawing.Size(29, 23);
            this.cmdFullScreen.TabIndex = 32;
            this.cmdFullScreen.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdFullScreen.UseVisualStyleBackColor = true;
            this.cmdFullScreen.Click += new System.EventHandler(this.cmdFullScreen_Click);
            // 
            // cmdZoom
            // 
            this.cmdZoom.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdZoom.Image = ((System.Drawing.Image)(resources.GetObject("cmdZoom.Image")));
            this.cmdZoom.Location = new System.Drawing.Point(404, 42);
            this.cmdZoom.Name = "cmdZoom";
            this.cmdZoom.Size = new System.Drawing.Size(29, 23);
            this.cmdZoom.TabIndex = 31;
            this.cmdZoom.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdZoom.UseVisualStyleBackColor = true;
            this.cmdZoom.Click += new System.EventHandler(this.cmdZoom_Click);
            // 
            // picPicture
            // 
            this.picPicture.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.picPicture.ContextMenuStrip = this.menu;
            this.picPicture.Location = new System.Drawing.Point(252, 42);
            this.picPicture.Name = "picPicture";
            this.picPicture.Size = new System.Drawing.Size(216, 149);
            this.picPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPicture.TabIndex = 0;
            this.picPicture.TabStop = false;
            this.picPicture.DoubleClick += new System.EventHandler(this.picPicture_DoubleClick);
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSave,
            this.mnuEmail,
            this.mnuOpen});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(125, 70);
            // 
            // mnuSave
            // 
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(124, 22);
            this.mnuSave.Text = "Save As..";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // mnuEmail
            // 
            this.mnuEmail.Name = "mnuEmail";
            this.mnuEmail.Size = new System.Drawing.Size(124, 22);
            this.mnuEmail.Text = "Email To..";
            this.mnuEmail.Click += new System.EventHandler(this.mnuEmail_Click);
            // 
            // mnuOpen
            // 
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(124, 22);
            this.mnuOpen.Text = "&Open";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // cmdUpdatePicture
            // 
            this.cmdUpdatePicture.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdUpdatePicture.ForeColor = System.Drawing.Color.Blue;
            this.cmdUpdatePicture.Image = ((System.Drawing.Image)(resources.GetObject("cmdUpdatePicture.Image")));
            this.cmdUpdatePicture.Location = new System.Drawing.Point(523, 230);
            this.cmdUpdatePicture.Name = "cmdUpdatePicture";
            this.cmdUpdatePicture.Size = new System.Drawing.Size(50, 47);
            this.cmdUpdatePicture.TabIndex = 28;
            this.cmdUpdatePicture.Text = "Save";
            this.cmdUpdatePicture.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmdUpdatePicture.UseVisualStyleBackColor = true;
            this.cmdUpdatePicture.Visible = false;
            this.cmdUpdatePicture.Click += new System.EventHandler(this.cmdUpdatePicture_Click);
            // 
            // cmdDeletePicture
            // 
            this.cmdDeletePicture.Enabled = false;
            this.cmdDeletePicture.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDeletePicture.ForeColor = System.Drawing.Color.Blue;
            this.cmdDeletePicture.Image = ((System.Drawing.Image)(resources.GetObject("cmdDeletePicture.Image")));
            this.cmdDeletePicture.Location = new System.Drawing.Point(7, 39);
            this.cmdDeletePicture.Name = "cmdDeletePicture";
            this.cmdDeletePicture.Size = new System.Drawing.Size(111, 47);
            this.cmdDeletePicture.TabIndex = 27;
            this.cmdDeletePicture.Text = "Delete Selected";
            this.cmdDeletePicture.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmdDeletePicture.UseVisualStyleBackColor = true;
            this.cmdDeletePicture.Click += new System.EventHandler(this.cmdDeletePicture_Click);
            // 
            // cmdAddPicture
            // 
            this.cmdAddPicture.AllowDrop = true;
            this.cmdAddPicture.Enabled = false;
            this.cmdAddPicture.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddPicture.ForeColor = System.Drawing.Color.Blue;
            this.cmdAddPicture.Image = ((System.Drawing.Image)(resources.GetObject("cmdAddPicture.Image")));
            this.cmdAddPicture.Location = new System.Drawing.Point(124, 40);
            this.cmdAddPicture.Name = "cmdAddPicture";
            this.cmdAddPicture.Size = new System.Drawing.Size(189, 47);
            this.cmdAddPicture.TabIndex = 26;
            this.cmdAddPicture.Text = "New";
            this.cmdAddPicture.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmdAddPicture.UseVisualStyleBackColor = true;
            this.cmdAddPicture.Visible = false;
            this.cmdAddPicture.Click += new System.EventHandler(this.cmdAddPicture_Click);
            this.cmdAddPicture.DragDrop += new System.Windows.Forms.DragEventHandler(this.cmdAddPicture_DragDrop);
            this.cmdAddPicture.DragOver += new System.Windows.Forms.DragEventHandler(this.cmdAddPicture_DragOver);
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBrowse.Image = ((System.Drawing.Image)(resources.GetObject("cmdBrowse.Image")));
            this.cmdBrowse.Location = new System.Drawing.Point(273, 5);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(29, 21);
            this.cmdBrowse.TabIndex = 25;
            this.cmdBrowse.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdBrowse.UseVisualStyleBackColor = true;
            this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // oFile
            // 
            this.oFile.Multiselect = true;
            // 
            // cmdUnZoom
            // 
            this.cmdUnZoom.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdUnZoom.Image = ((System.Drawing.Image)(resources.GetObject("cmdUnZoom.Image")));
            this.cmdUnZoom.Location = new System.Drawing.Point(439, 14);
            this.cmdUnZoom.Name = "cmdUnZoom";
            this.cmdUnZoom.Size = new System.Drawing.Size(29, 23);
            this.cmdUnZoom.TabIndex = 33;
            this.cmdUnZoom.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdUnZoom.UseVisualStyleBackColor = true;
            this.cmdUnZoom.Visible = false;
            this.cmdUnZoom.Click += new System.EventHandler(this.cmdUnZoom_Click);
            // 
            // picZoomView
            // 
            this.picZoomView.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.picZoomView.ContextMenuStrip = this.menu;
            this.picZoomView.Location = new System.Drawing.Point(397, 9);
            this.picZoomView.Name = "picZoomView";
            this.picZoomView.Size = new System.Drawing.Size(36, 30);
            this.picZoomView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picZoomView.TabIndex = 34;
            this.picZoomView.TabStop = false;
            this.picZoomView.Visible = false;
            // 
            // chkAutoWatch
            // 
            this.chkAutoWatch.AutoSize = true;
            this.chkAutoWatch.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutoWatch.ForeColor = System.Drawing.Color.Gray;
            this.chkAutoWatch.Location = new System.Drawing.Point(252, 190);
            this.chkAutoWatch.Name = "chkAutoWatch";
            this.chkAutoWatch.Size = new System.Drawing.Size(79, 18);
            this.chkAutoWatch.TabIndex = 35;
            this.chkAutoWatch.Text = "AutoWatch";
            this.chkAutoWatch.UseVisualStyleBackColor = true;
            this.chkAutoWatch.CheckedChanged += new System.EventHandler(this.chkAutoWatch_CheckedChanged);
            // 
            // fsw
            // 
            this.fsw.EnableRaisingEvents = true;
            this.fsw.NotifyFilter = System.IO.NotifyFilters.FileName;
            this.fsw.SynchronizingObject = this;
            this.fsw.Created += new System.IO.FileSystemEventHandler(this.fsw_Created);
            // 
            // sFile
            // 
            this.sFile.Filter = "JPG Files|*.jpg";
            this.sFile.Title = "Save As..";
            // 
            // cmdGrab
            // 
            this.cmdGrab.Location = new System.Drawing.Point(335, 191);
            this.cmdGrab.Name = "cmdGrab";
            this.cmdGrab.Size = new System.Drawing.Size(133, 22);
            this.cmdGrab.TabIndex = 36;
            this.cmdGrab.Text = "Grab";
            this.cmdGrab.UseVisualStyleBackColor = true;
            this.cmdGrab.Visible = false;
            this.cmdGrab.Click += new System.EventHandler(this.cmdGrab_Click);
            // 
            // lnkDefaultPath
            // 
            this.lnkDefaultPath.ActiveLinkColor = System.Drawing.Color.Black;
            this.lnkDefaultPath.AutoSize = true;
            this.lnkDefaultPath.ContextMenuStrip = this.mnu;
            this.lnkDefaultPath.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkDefaultPath.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lnkDefaultPath.LinkColor = System.Drawing.Color.Blue;
            this.lnkDefaultPath.Location = new System.Drawing.Point(273, 23);
            this.lnkDefaultPath.Name = "lnkDefaultPath";
            this.lnkDefaultPath.Size = new System.Drawing.Size(40, 14);
            this.lnkDefaultPath.TabIndex = 37;
            this.lnkDefaultPath.TabStop = true;
            this.lnkDefaultPath.Text = "<path>";
            this.lnkDefaultPath.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip1.SetToolTip(this.lnkDefaultPath, "Click to set the folder you want to have watched for new attachments.");
            this.lnkDefaultPath.Visible = false;
            this.lnkDefaultPath.VisitedLinkColor = System.Drawing.Color.Black;
            this.lnkDefaultPath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDefaultPath_LinkClicked);
            // 
            // pOptions
            // 
            this.pOptions.BackColor = System.Drawing.Color.White;
            this.pOptions.Controls.Add(this.lblLinks);
            this.pOptions.Controls.Add(this.cmdDeletePicture);
            this.pOptions.Controls.Add(this.cmdBrowse);
            this.pOptions.Controls.Add(this.cmdAddPicture);
            this.pOptions.Controls.Add(this.txtComments);
            this.pOptions.Controls.Add(this.lnkDefaultPath);
            this.pOptions.Controls.Add(this.lblFileName);
            this.pOptions.Controls.Add(this.lblComments);
            this.pOptions.Controls.Add(this.txtFileName);
            this.pOptions.Location = new System.Drawing.Point(29, 283);
            this.pOptions.Name = "pOptions";
            this.pOptions.Size = new System.Drawing.Size(651, 107);
            this.pOptions.TabIndex = 38;
            // 
            // lblLinks
            // 
            this.lblLinks.AutoSize = true;
            this.lblLinks.Location = new System.Drawing.Point(7, 89);
            this.lblLinks.Name = "lblLinks";
            this.lblLinks.Size = new System.Drawing.Size(0, 15);
            this.lblLinks.TabIndex = 38;
            // 
            // lvPictures
            // 
            this.lvPictures.AddCaption = "Add New";
            this.lvPictures.AllowActions = false;
            this.lvPictures.AllowAdd = false;
            this.lvPictures.AllowDelete = true;
            this.lvPictures.AllowDeleteAlways = false;
            this.lvPictures.AllowDrop = true;
            this.lvPictures.AllowOnlyOpenDelete = false;
            this.lvPictures.AlternateConnection = null;
            this.lvPictures.BackColor = System.Drawing.Color.White;
            this.lvPictures.Caption = "";
            this.lvPictures.CurrentTemplate = null;
            this.lvPictures.ExtraClassInfo = "";
            this.lvPictures.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvPictures.Location = new System.Drawing.Point(12, 42);
            this.lvPictures.Margin = new System.Windows.Forms.Padding(4);
            this.lvPictures.MultiSelect = true;
            this.lvPictures.Name = "lvPictures";
            this.lvPictures.Size = new System.Drawing.Size(224, 166);
            this.lvPictures.SuppressSelectionChanged = false;
            this.lvPictures.TabIndex = 30;
            this.lvPictures.zz_OpenColumnMenu = false;
            this.lvPictures.zz_OrderLineType = "";
            this.lvPictures.zz_ShowAutoRefresh = true;
            this.lvPictures.zz_ShowUnlimited = true;
            this.lvPictures.AboutToThrow += new Core.ShowHandler(this.lvPictures_AboutToThrow);
            this.lvPictures.ObjectClicked += new NewMethod.ObjectClickHandler(this.lvPictures_ObjectClicked);
            this.lvPictures.FinishedFill += new NewMethod.FillHandler(this.lvPictures_FinishedFill);
            // 
            // PartPictureViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cmdUpdatePicture);
            this.Controls.Add(this.pOptions);
            this.Controls.Add(this.cmdGrab);
            this.Controls.Add(this.picZoomView);
            this.Controls.Add(this.cmdUnZoom);
            this.Controls.Add(this.cmdFullScreen);
            this.Controls.Add(this.cmdZoom);
            this.Controls.Add(this.picPicture);
            this.Controls.Add(this.lvPictures);
            this.Controls.Add(this.lblPartNumber);
            this.Controls.Add(this.chkAutoWatch);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PartPictureViewer";
            this.Size = new System.Drawing.Size(718, 473);
            this.Resize += new System.EventHandler(this.PartPictureViewer_Resize);
            this.mnu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPicture)).EndInit();
            this.menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picZoomView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsw)).EndInit();
            this.pOptions.ResumeLayout(false);
            this.pOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog oFile;
        private System.IO.FileSystemWatcher fsw;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripMenuItem mnuEmail;
        private System.Windows.Forms.SaveFileDialog sFile;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ContextMenuStrip mnu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        protected System.Windows.Forms.Label lblFileName;
        protected System.Windows.Forms.Label lblComments;
        protected System.Windows.Forms.TextBox txtFileName;
        protected System.Windows.Forms.RichTextBox txtComments;
        protected System.Windows.Forms.Button cmdBrowse;
        protected System.Windows.Forms.Button cmdAddPicture;
        protected System.Windows.Forms.Button cmdDeletePicture;
        protected System.Windows.Forms.Button cmdUpdatePicture;
        protected System.Windows.Forms.LinkLabel lblPartNumber;
        protected NewMethod.nList lvPictures;
        protected System.Windows.Forms.PictureBox picPicture;
        protected System.Windows.Forms.Button cmdZoom;
        protected System.Windows.Forms.Button cmdFullScreen;
        protected System.Windows.Forms.Button cmdUnZoom;
        protected System.Windows.Forms.PictureBox picZoomView;
        protected System.Windows.Forms.CheckBox chkAutoWatch;
        protected System.Windows.Forms.Button cmdGrab;
        protected System.Windows.Forms.LinkLabel lnkDefaultPath;
        protected System.Windows.Forms.Panel pOptions;
        protected System.Windows.Forms.Label lblLinks;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
