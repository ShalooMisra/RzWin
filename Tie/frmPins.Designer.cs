namespace TiePin
{
    partial class frmPins
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPins));
            this.lblAdd = new System.Windows.Forms.LinkLabel();
            this.lvTacks = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.mnuTack = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuStartTackWithMonitor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRename = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDeleteTack = new System.Windows.Forms.ToolStripMenuItem();
            this.gbTack = new System.Windows.Forms.GroupBox();
            this.cmdApply = new System.Windows.Forms.Button();
            this.pUser = new Tie.PinPermission();
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.pCommand = new Tie.PinPermission();
            this.pClip = new Tie.PinPermission();
            this.pSQL = new Tie.PinPermission();
            this.pFile = new Tie.PinPermission();
            this.pRemote = new Tie.PinPermission();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRack = new System.Windows.Forms.Label();
            this.gbService = new System.Windows.Forms.GroupBox();
            this.lblStartStop = new System.Windows.Forms.LinkLabel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.gbInstallation = new System.Windows.Forms.GroupBox();
            this.lblInstall = new System.Windows.Forms.LinkLabel();
            this.lblInstalled = new System.Windows.Forms.Label();
            this.bg = new System.ComponentModel.BackgroundWorker();
            this.bgStart = new System.ComponentModel.BackgroundWorker();
            this.lblWebsite = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblUpdate = new System.Windows.Forms.LinkLabel();
            this.gbRemoteView = new System.Windows.Forms.GroupBox();
            this.lblInstallVNC = new System.Windows.Forms.LinkLabel();
            this.lblVNCStatus = new System.Windows.Forms.Label();
            this.lblPinvitation = new System.Windows.Forms.LinkLabel();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtLicenseID = new System.Windows.Forms.TextBox();
            this.lblLicenseID = new System.Windows.Forms.Label();
            this.picPin = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mnuTack.SuspendLayout();
            this.gbTack.SuspendLayout();
            this.gbService.SuspendLayout();
            this.gbInstallation.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbRemoteView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.Location = new System.Drawing.Point(18, 200);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(25, 13);
            this.lblAdd.TabIndex = 1;
            this.lblAdd.TabStop = true;
            this.lblAdd.Text = "add";
            this.lblAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAdd_LinkClicked);
            // 
            // lvTacks
            // 
            this.lvTacks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvTacks.ContextMenuStrip = this.mnuTack;
            this.lvTacks.FullRowSelect = true;
            this.lvTacks.HideSelection = false;
            this.lvTacks.Location = new System.Drawing.Point(2, 230);
            this.lvTacks.Name = "lvTacks";
            this.lvTacks.Size = new System.Drawing.Size(213, 219);
            this.lvTacks.TabIndex = 2;
            this.lvTacks.UseCompatibleStateImageBehavior = false;
            this.lvTacks.View = System.Windows.Forms.View.Details;
            this.lvTacks.Click += new System.EventHandler(this.lvTacks_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Configured Pins";
            this.columnHeader1.Width = 136;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Version";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 67;
            // 
            // mnuTack
            // 
            this.mnuTack.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStartTackWithMonitor,
            this.mnuRename,
            this.toolStripSeparator1,
            this.mnuDeleteTack});
            this.mnuTack.Name = "mnuTack";
            this.mnuTack.Size = new System.Drawing.Size(164, 76);
            // 
            // mnuStartTackWithMonitor
            // 
            this.mnuStartTackWithMonitor.Name = "mnuStartTackWithMonitor";
            this.mnuStartTackWithMonitor.Size = new System.Drawing.Size(163, 22);
            this.mnuStartTackWithMonitor.Text = "&Start w/ Monitor";
            this.mnuStartTackWithMonitor.Click += new System.EventHandler(this.mnuStartTackWithMonitor_Click);
            // 
            // mnuRename
            // 
            this.mnuRename.Name = "mnuRename";
            this.mnuRename.Size = new System.Drawing.Size(163, 22);
            this.mnuRename.Text = "&Rename";
            this.mnuRename.Click += new System.EventHandler(this.mnuRename_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
            // 
            // mnuDeleteTack
            // 
            this.mnuDeleteTack.Name = "mnuDeleteTack";
            this.mnuDeleteTack.Size = new System.Drawing.Size(163, 22);
            this.mnuDeleteTack.Text = "&Delete";
            this.mnuDeleteTack.Click += new System.EventHandler(this.mnuDeleteTack_Click);
            // 
            // gbTack
            // 
            this.gbTack.Controls.Add(this.txtLicenseID);
            this.gbTack.Controls.Add(this.lblLicenseID);
            this.gbTack.Controls.Add(this.txtDescription);
            this.gbTack.Controls.Add(this.lblDescription);
            this.gbTack.Controls.Add(this.cmdApply);
            this.gbTack.Controls.Add(this.pUser);
            this.gbTack.Controls.Add(this.pCommand);
            this.gbTack.Controls.Add(this.pClip);
            this.gbTack.Controls.Add(this.pSQL);
            this.gbTack.Controls.Add(this.pFile);
            this.gbTack.Controls.Add(this.pRemote);
            this.gbTack.Controls.Add(this.label3);
            this.gbTack.Controls.Add(this.lblRack);
            this.gbTack.Location = new System.Drawing.Point(219, 74);
            this.gbTack.Name = "gbTack";
            this.gbTack.Size = new System.Drawing.Size(568, 375);
            this.gbTack.TabIndex = 4;
            this.gbTack.TabStop = false;
            this.gbTack.Text = "<no pin is selected>";
            // 
            // cmdApply
            // 
            this.cmdApply.Location = new System.Drawing.Point(185, 308);
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(192, 61);
            this.cmdApply.TabIndex = 10;
            this.cmdApply.Text = "Apply";
            this.cmdApply.UseVisualStyleBackColor = true;
            this.cmdApply.Click += new System.EventHandler(this.cmdApply_Click);
            // 
            // pUser
            // 
            this.pUser.BackColor = System.Drawing.Color.White;
            this.pUser.Caption = "UserView";
            this.pUser.Description = "Allows authenticated users to monitor this computer\'s level of desktop and proces" +
                "sor activity.";
            this.pUser.ImageKey = "user";
            this.pUser.ImageList = this.il;
            this.pUser.IsChecked = false;
            this.pUser.Location = new System.Drawing.Point(6, 262);
            this.pUser.Name = "pUser";
            this.pUser.Size = new System.Drawing.Size(549, 31);
            this.pUser.TabIndex = 51;
            // 
            // il
            // 
            this.il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il.ImageStream")));
            this.il.TransparentColor = System.Drawing.Color.Magenta;
            this.il.Images.SetKeyName(0, "clip");
            this.il.Images.SetKeyName(1, "command");
            this.il.Images.SetKeyName(2, "sql");
            this.il.Images.SetKeyName(3, "file");
            this.il.Images.SetKeyName(4, "user");
            this.il.Images.SetKeyName(5, "remote");
            // 
            // pCommand
            // 
            this.pCommand.BackColor = System.Drawing.Color.White;
            this.pCommand.Caption = "CommandView";
            this.pCommand.Description = "Allows authenticated users to access an interactive command-line interface on thi" +
                "s computer.";
            this.pCommand.ImageKey = "command";
            this.pCommand.ImageList = this.il;
            this.pCommand.IsChecked = false;
            this.pCommand.Location = new System.Drawing.Point(6, 231);
            this.pCommand.Name = "pCommand";
            this.pCommand.Size = new System.Drawing.Size(549, 31);
            this.pCommand.TabIndex = 50;
            // 
            // pClip
            // 
            this.pClip.BackColor = System.Drawing.Color.White;
            this.pClip.Caption = "ClipView";
            this.pClip.Description = "Allows authenticated users to view and modify the contents of this computer\'s cli" +
                "pboard.";
            this.pClip.ImageKey = "clip";
            this.pClip.ImageList = this.il;
            this.pClip.IsChecked = false;
            this.pClip.Location = new System.Drawing.Point(6, 200);
            this.pClip.Name = "pClip";
            this.pClip.Size = new System.Drawing.Size(549, 31);
            this.pClip.TabIndex = 49;
            // 
            // pSQL
            // 
            this.pSQL.BackColor = System.Drawing.Color.White;
            this.pSQL.Caption = "SQLView";
            this.pSQL.Description = "Allows authenticated users to access relational databases on this computer and ne" +
                "twork.";
            this.pSQL.ImageKey = "sql";
            this.pSQL.ImageList = this.il;
            this.pSQL.IsChecked = false;
            this.pSQL.Location = new System.Drawing.Point(6, 169);
            this.pSQL.Name = "pSQL";
            this.pSQL.Size = new System.Drawing.Size(549, 31);
            this.pSQL.TabIndex = 48;
            // 
            // pFile
            // 
            this.pFile.BackColor = System.Drawing.Color.White;
            this.pFile.Caption = "FileView";
            this.pFile.Description = "Allows authenticated users to copy, add, view, and remove files on this computer." +
                "";
            this.pFile.ImageKey = "file";
            this.pFile.ImageList = this.il;
            this.pFile.IsChecked = false;
            this.pFile.Location = new System.Drawing.Point(6, 138);
            this.pFile.Name = "pFile";
            this.pFile.Size = new System.Drawing.Size(549, 31);
            this.pFile.TabIndex = 47;
            // 
            // pRemote
            // 
            this.pRemote.BackColor = System.Drawing.Color.White;
            this.pRemote.Caption = "RemoteView";
            this.pRemote.Description = "Allows authenticated users to remotely view and control this computer\'s screen, m" +
                "ouse, and keyboard.";
            this.pRemote.ImageKey = "remote";
            this.pRemote.ImageList = this.il;
            this.pRemote.IsChecked = false;
            this.pRemote.Location = new System.Drawing.Point(7, 107);
            this.pRemote.Name = "pRemote";
            this.pRemote.Size = new System.Drawing.Size(549, 31);
            this.pRemote.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(553, 18);
            this.label3.TabIndex = 45;
            this.label3.Text = "Permissions";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRack
            // 
            this.lblRack.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lblRack.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRack.ForeColor = System.Drawing.Color.White;
            this.lblRack.Location = new System.Drawing.Point(5, 16);
            this.lblRack.Name = "lblRack";
            this.lblRack.Size = new System.Drawing.Size(553, 18);
            this.lblRack.TabIndex = 42;
            this.lblRack.Text = "Connection Settings";
            this.lblRack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbService
            // 
            this.gbService.Controls.Add(this.lblStartStop);
            this.gbService.Controls.Add(this.lblStatus);
            this.gbService.ForeColor = System.Drawing.Color.Peru;
            this.gbService.Location = new System.Drawing.Point(48, 98);
            this.gbService.Name = "gbService";
            this.gbService.Size = new System.Drawing.Size(165, 39);
            this.gbService.TabIndex = 5;
            this.gbService.TabStop = false;
            this.gbService.Text = "TieService Status";
            // 
            // lblStartStop
            // 
            this.lblStartStop.AutoSize = true;
            this.lblStartStop.Location = new System.Drawing.Point(6, 21);
            this.lblStartStop.Name = "lblStartStop";
            this.lblStartStop.Size = new System.Drawing.Size(27, 13);
            this.lblStartStop.TabIndex = 1;
            this.lblStartStop.TabStop = true;
            this.lblStartStop.Text = "start";
            this.lblStartStop.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblStartStop_LinkClicked);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStatus.Location = new System.Drawing.Point(52, 16);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(63, 16);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "<started>";
            // 
            // gbInstallation
            // 
            this.gbInstallation.Controls.Add(this.lblInstall);
            this.gbInstallation.Controls.Add(this.lblInstalled);
            this.gbInstallation.ForeColor = System.Drawing.Color.Peru;
            this.gbInstallation.Location = new System.Drawing.Point(48, 58);
            this.gbInstallation.Name = "gbInstallation";
            this.gbInstallation.Size = new System.Drawing.Size(165, 39);
            this.gbInstallation.TabIndex = 6;
            this.gbInstallation.TabStop = false;
            this.gbInstallation.Text = "TieService Installation";
            // 
            // lblInstall
            // 
            this.lblInstall.AutoSize = true;
            this.lblInstall.Location = new System.Drawing.Point(6, 21);
            this.lblInstall.Name = "lblInstall";
            this.lblInstall.Size = new System.Drawing.Size(33, 13);
            this.lblInstall.TabIndex = 1;
            this.lblInstall.TabStop = true;
            this.lblInstall.Text = "install";
            this.lblInstall.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblInstall_LinkClicked);
            // 
            // lblInstalled
            // 
            this.lblInstalled.AutoSize = true;
            this.lblInstalled.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstalled.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblInstalled.Location = new System.Drawing.Point(55, 16);
            this.lblInstalled.Name = "lblInstalled";
            this.lblInstalled.Size = new System.Drawing.Size(72, 16);
            this.lblInstalled.TabIndex = 0;
            this.lblInstalled.Text = "<installed>";
            // 
            // bg
            // 
            this.bg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_DoWork);
            this.bg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_RunWorkerCompleted);
            // 
            // bgStart
            // 
            this.bgStart.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgStart_DoWork);
            this.bgStart.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgStart_RunWorkerCompleted);
            // 
            // lblWebsite
            // 
            this.lblWebsite.AutoSize = true;
            this.lblWebsite.Location = new System.Drawing.Point(54, 43);
            this.lblWebsite.Name = "lblWebsite";
            this.lblWebsite.Size = new System.Drawing.Size(152, 13);
            this.lblWebsite.TabIndex = 8;
            this.lblWebsite.TabStop = true;
            this.lblWebsite.Text = "www.newmethodsoftware.com";
            this.lblWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblWebsite_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblVersion);
            this.groupBox1.Controls.Add(this.lblUpdate);
            this.groupBox1.ForeColor = System.Drawing.Color.Peru;
            this.groupBox1.Location = new System.Drawing.Point(48, 185);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 39);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Versions";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblVersion.Location = new System.Drawing.Point(42, 13);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(53, 13);
            this.lblVersion.TabIndex = 3;
            this.lblVersion.Text = "<version>";
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Location = new System.Drawing.Point(6, 23);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(40, 13);
            this.lblUpdate.TabIndex = 2;
            this.lblUpdate.TabStop = true;
            this.lblUpdate.Text = "update";
            this.lblUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblUpdate_LinkClicked);
            // 
            // gbRemoteView
            // 
            this.gbRemoteView.Controls.Add(this.lblInstallVNC);
            this.gbRemoteView.Controls.Add(this.lblVNCStatus);
            this.gbRemoteView.ForeColor = System.Drawing.Color.Peru;
            this.gbRemoteView.Location = new System.Drawing.Point(49, 143);
            this.gbRemoteView.Name = "gbRemoteView";
            this.gbRemoteView.Size = new System.Drawing.Size(165, 39);
            this.gbRemoteView.TabIndex = 6;
            this.gbRemoteView.TabStop = false;
            this.gbRemoteView.Text = "RealVNC Status";
            // 
            // lblInstallVNC
            // 
            this.lblInstallVNC.AutoSize = true;
            this.lblInstallVNC.Location = new System.Drawing.Point(6, 21);
            this.lblInstallVNC.Name = "lblInstallVNC";
            this.lblInstallVNC.Size = new System.Drawing.Size(33, 13);
            this.lblInstallVNC.TabIndex = 1;
            this.lblInstallVNC.TabStop = true;
            this.lblInstallVNC.Text = "install";
            this.lblInstallVNC.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblInstallVNC_LinkClicked);
            // 
            // lblVNCStatus
            // 
            this.lblVNCStatus.AutoSize = true;
            this.lblVNCStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVNCStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblVNCStatus.Location = new System.Drawing.Point(52, 16);
            this.lblVNCStatus.Name = "lblVNCStatus";
            this.lblVNCStatus.Size = new System.Drawing.Size(63, 16);
            this.lblVNCStatus.TabIndex = 0;
            this.lblVNCStatus.Text = "<started>";
            // 
            // lblPinvitation
            // 
            this.lblPinvitation.AutoSize = true;
            this.lblPinvitation.Location = new System.Drawing.Point(438, 59);
            this.lblPinvitation.Name = "lblPinvitation";
            this.lblPinvitation.Size = new System.Drawing.Size(100, 13);
            this.lblPinvitation.TabIndex = 42;
            this.lblPinvitation.TabStop = true;
            this.lblPinvitation.Text = "accept a pinvitation";
            this.lblPinvitation.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblPinvitation_LinkClicked);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(6, 42);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 52;
            this.lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(76, 39);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(478, 20);
            this.txtDescription.TabIndex = 53;
            // 
            // txtLicenseID
            // 
            this.txtLicenseID.Location = new System.Drawing.Point(76, 62);
            this.txtLicenseID.Name = "txtLicenseID";
            this.txtLicenseID.ReadOnly = true;
            this.txtLicenseID.Size = new System.Drawing.Size(478, 20);
            this.txtLicenseID.TabIndex = 55;
            // 
            // lblLicenseID
            // 
            this.lblLicenseID.AutoSize = true;
            this.lblLicenseID.Location = new System.Drawing.Point(6, 63);
            this.lblLicenseID.Name = "lblLicenseID";
            this.lblLicenseID.Size = new System.Drawing.Size(61, 13);
            this.lblLicenseID.TabIndex = 54;
            this.lblLicenseID.Text = "License ID:";
            // 
            // picPin
            // 
            this.picPin.BackgroundImage = global::Tie.Properties.Resources.pinvitation;
            this.picPin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picPin.Location = new System.Drawing.Point(446, 8);
            this.picPin.Name = "picPin";
            this.picPin.Size = new System.Drawing.Size(80, 60);
            this.picPin.TabIndex = 43;
            this.picPin.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Tie.Properties.Resources.tie_corner;
            this.pictureBox1.Location = new System.Drawing.Point(-8, -6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(202, 199);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // frmPins
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(792, 454);
            this.Controls.Add(this.gbRemoteView);
            this.Controls.Add(this.gbInstallation);
            this.Controls.Add(this.lblPinvitation);
            this.Controls.Add(this.picPin);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblAdd);
            this.Controls.Add(this.lvTacks);
            this.Controls.Add(this.lblWebsite);
            this.Controls.Add(this.gbService);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gbTack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPins";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tie Settings";
            this.mnuTack.ResumeLayout(false);
            this.gbTack.ResumeLayout(false);
            this.gbTack.PerformLayout();
            this.gbService.ResumeLayout(false);
            this.gbService.PerformLayout();
            this.gbInstallation.ResumeLayout(false);
            this.gbInstallation.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbRemoteView.ResumeLayout(false);
            this.gbRemoteView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblAdd;
        private System.Windows.Forms.ListView lvTacks;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ContextMenuStrip mnuTack;
        private System.Windows.Forms.ToolStripMenuItem mnuStartTackWithMonitor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteTack;
        private System.Windows.Forms.GroupBox gbTack;
        private System.Windows.Forms.Button cmdApply;
        private System.Windows.Forms.ToolStripMenuItem mnuRename;
        private System.Windows.Forms.GroupBox gbService;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.LinkLabel lblStartStop;
        private System.Windows.Forms.GroupBox gbInstallation;
        private System.Windows.Forms.LinkLabel lblInstall;
        private System.Windows.Forms.Label lblInstalled;
        private System.ComponentModel.BackgroundWorker bg;
        private System.ComponentModel.BackgroundWorker bgStart;
        private System.Windows.Forms.ImageList il;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel lblWebsite;
        private System.Windows.Forms.Label lblRack;
        private System.Windows.Forms.Label label3;
        private Tie.PinPermission pRemote;
        private Tie.PinPermission pClip;
        private Tie.PinPermission pSQL;
        private Tie.PinPermission pFile;
        private Tie.PinPermission pUser;
        private Tie.PinPermission pCommand;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel lblUpdate;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.GroupBox gbRemoteView;
        private System.Windows.Forms.LinkLabel lblInstallVNC;
        private System.Windows.Forms.Label lblVNCStatus;
        private System.Windows.Forms.LinkLabel lblPinvitation;
        private System.Windows.Forms.TextBox txtLicenseID;
        private System.Windows.Forms.Label lblLicenseID;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.PictureBox picPin;
    }
}

