namespace NewMethod
{
    partial class nTeams
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
                    if (ChangesMade && xSys != null)
                    {
                        xSys.CacheUsers(NMWin.ContextDefault);
                    }
                }
                catch (System.Exception)
                { }

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(nTeams));
            this.mnuTeam = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuNewTeam = new System.Windows.Forms.ToolStripMenuItem();
            this.sepTeam = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDeleteTeam = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddCaptain = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRemoveCaptain = new System.Windows.Forms.ToolStripMenuItem();
            this.sepMember = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAddMainStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRemoveMainStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEditPermissions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRemoveNegative = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRemoveAllPermissions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDeleteMember = new System.Windows.Forms.ToolStripMenuItem();
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.sc = new System.Windows.Forms.SplitContainer();
            this.gbPermissions = new System.Windows.Forms.GroupBox();
            this.cmdRemoveAll = new System.Windows.Forms.Button();
            this.cmdListPermissions = new System.Windows.Forms.Button();
            this.cmdPaste = new System.Windows.Forms.Button();
            this.tvPermit = new System.Windows.Forms.TreeView();
            this.mnuPermission = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdNewTeam = new System.Windows.Forms.Button();
            this.tv = new System.Windows.Forms.TreeView();
            this.lstUsers = new NewMethod.nList();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbx_show_inactive = new NewMethod.nEdit_Boolean();
            this.mnuTeam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sc)).BeginInit();
            this.sc.Panel1.SuspendLayout();
            this.sc.Panel2.SuspendLayout();
            this.sc.SuspendLayout();
            this.gbPermissions.SuspendLayout();
            this.mnuPermission.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuTeam
            // 
            this.mnuTeam.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewTeam,
            this.sepTeam,
            this.mnuDeleteTeam,
            this.mnuAddCaptain,
            this.mnuRemoveCaptain,
            this.sepMember,
            this.mnuAddMainStatus,
            this.mnuRemoveMainStatus,
            this.toolStripSeparator2,
            this.mnuEditPermissions,
            this.mnuRemoveNegative,
            this.mnuRemoveAllPermissions,
            this.toolStripSeparator1,
            this.mnuDeleteMember});
            this.mnuTeam.Name = "mnuTeam";
            this.mnuTeam.Size = new System.Drawing.Size(234, 248);
            this.mnuTeam.Opening += new System.ComponentModel.CancelEventHandler(this.mnuTeam_Opening);
            // 
            // mnuNewTeam
            // 
            this.mnuNewTeam.Name = "mnuNewTeam";
            this.mnuNewTeam.Size = new System.Drawing.Size(233, 22);
            this.mnuNewTeam.Text = "&New Team";
            this.mnuNewTeam.Click += new System.EventHandler(this.mnuNewTeam_Click);
            // 
            // sepTeam
            // 
            this.sepTeam.Name = "sepTeam";
            this.sepTeam.Size = new System.Drawing.Size(230, 6);
            // 
            // mnuDeleteTeam
            // 
            this.mnuDeleteTeam.Name = "mnuDeleteTeam";
            this.mnuDeleteTeam.Size = new System.Drawing.Size(233, 22);
            this.mnuDeleteTeam.Text = "&Delete";
            this.mnuDeleteTeam.Click += new System.EventHandler(this.mnuDeleteTeam_Click);
            // 
            // mnuAddCaptain
            // 
            this.mnuAddCaptain.Name = "mnuAddCaptain";
            this.mnuAddCaptain.Size = new System.Drawing.Size(233, 22);
            this.mnuAddCaptain.Text = "&Add Captain Status";
            this.mnuAddCaptain.Click += new System.EventHandler(this.mnuAddCaptain_Click);
            // 
            // mnuRemoveCaptain
            // 
            this.mnuRemoveCaptain.Name = "mnuRemoveCaptain";
            this.mnuRemoveCaptain.Size = new System.Drawing.Size(233, 22);
            this.mnuRemoveCaptain.Text = "&Remove Captain Status";
            this.mnuRemoveCaptain.Click += new System.EventHandler(this.mnuRemoveCaptain_Click);
            // 
            // sepMember
            // 
            this.sepMember.Name = "sepMember";
            this.sepMember.Size = new System.Drawing.Size(230, 6);
            // 
            // mnuAddMainStatus
            // 
            this.mnuAddMainStatus.Name = "mnuAddMainStatus";
            this.mnuAddMainStatus.Size = new System.Drawing.Size(233, 22);
            this.mnuAddMainStatus.Text = "Add Main Status";
            this.mnuAddMainStatus.Click += new System.EventHandler(this.mnuAddMainStatus_Click);
            // 
            // mnuRemoveMainStatus
            // 
            this.mnuRemoveMainStatus.Name = "mnuRemoveMainStatus";
            this.mnuRemoveMainStatus.Size = new System.Drawing.Size(233, 22);
            this.mnuRemoveMainStatus.Text = "Remove Main Status";
            this.mnuRemoveMainStatus.Click += new System.EventHandler(this.mnuRemoveMainStatus_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(230, 6);
            // 
            // mnuEditPermissions
            // 
            this.mnuEditPermissions.Name = "mnuEditPermissions";
            this.mnuEditPermissions.Size = new System.Drawing.Size(233, 22);
            this.mnuEditPermissions.Text = "Edit Permissions";
            this.mnuEditPermissions.Click += new System.EventHandler(this.mnuEditPermissions_Click);
            // 
            // mnuRemoveNegative
            // 
            this.mnuRemoveNegative.Name = "mnuRemoveNegative";
            this.mnuRemoveNegative.Size = new System.Drawing.Size(233, 22);
            this.mnuRemoveNegative.Text = "Remove &Negative Permissions";
            this.mnuRemoveNegative.Visible = false;
            this.mnuRemoveNegative.Click += new System.EventHandler(this.mnuRemoveNegative_Click);
            // 
            // mnuRemoveAllPermissions
            // 
            this.mnuRemoveAllPermissions.Name = "mnuRemoveAllPermissions";
            this.mnuRemoveAllPermissions.Size = new System.Drawing.Size(233, 22);
            this.mnuRemoveAllPermissions.Text = "Remove All Permissions";
            this.mnuRemoveAllPermissions.Visible = false;
            this.mnuRemoveAllPermissions.Click += new System.EventHandler(this.mnuRemoveAllPermissions_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(230, 6);
            // 
            // mnuDeleteMember
            // 
            this.mnuDeleteMember.Name = "mnuDeleteMember";
            this.mnuDeleteMember.Size = new System.Drawing.Size(233, 22);
            this.mnuDeleteMember.Text = "&Delete";
            this.mnuDeleteMember.Click += new System.EventHandler(this.mnuDeleteMember_Click);
            // 
            // il
            // 
            this.il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il.ImageStream")));
            this.il.TransparentColor = System.Drawing.Color.Transparent;
            this.il.Images.SetKeyName(0, "user.bmp");
            this.il.Images.SetKeyName(1, "team.bmp");
            this.il.Images.SetKeyName(2, "inactive_user.bmp");
            this.il.Images.SetKeyName(3, "captain_user.bmp");
            this.il.Images.SetKeyName(4, "super_user.bmp");
            // 
            // sc
            // 
            this.sc.Location = new System.Drawing.Point(3, 3);
            this.sc.Name = "sc";
            // 
            // sc.Panel1
            // 
            this.sc.Panel1.Controls.Add(this.lstUsers);
            this.sc.Panel1.Controls.Add(this.groupBox1);
            // 
            // sc.Panel2
            // 
            this.sc.Panel2.Controls.Add(this.gbPermissions);
            this.sc.Panel2.Controls.Add(this.cmdNewTeam);
            this.sc.Panel2.Controls.Add(this.tv);
            this.sc.Size = new System.Drawing.Size(873, 566);
            this.sc.SplitterDistance = 367;
            this.sc.TabIndex = 8;
            this.sc.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.sc_SplitterMoved);
            // 
            // gbPermissions
            // 
            this.gbPermissions.Controls.Add(this.cmdRemoveAll);
            this.gbPermissions.Controls.Add(this.cmdListPermissions);
            this.gbPermissions.Controls.Add(this.cmdPaste);
            this.gbPermissions.Controls.Add(this.tvPermit);
            this.gbPermissions.Location = new System.Drawing.Point(134, 22);
            this.gbPermissions.Name = "gbPermissions";
            this.gbPermissions.Size = new System.Drawing.Size(332, 485);
            this.gbPermissions.TabIndex = 12;
            this.gbPermissions.TabStop = false;
            this.gbPermissions.Text = "Permissions";
            this.gbPermissions.Visible = false;
            // 
            // cmdRemoveAll
            // 
            this.cmdRemoveAll.Location = new System.Drawing.Point(218, 372);
            this.cmdRemoveAll.Name = "cmdRemoveAll";
            this.cmdRemoveAll.Size = new System.Drawing.Size(91, 26);
            this.cmdRemoveAll.TabIndex = 3;
            this.cmdRemoveAll.Text = "Remove All";
            this.cmdRemoveAll.UseVisualStyleBackColor = true;
            this.cmdRemoveAll.Click += new System.EventHandler(this.cmdRemoveAll_Click);
            // 
            // cmdListPermissions
            // 
            this.cmdListPermissions.Location = new System.Drawing.Point(24, 372);
            this.cmdListPermissions.Name = "cmdListPermissions";
            this.cmdListPermissions.Size = new System.Drawing.Size(91, 26);
            this.cmdListPermissions.TabIndex = 2;
            this.cmdListPermissions.Text = "List";
            this.cmdListPermissions.UseVisualStyleBackColor = true;
            this.cmdListPermissions.Click += new System.EventHandler(this.cmdListPermissions_Click);
            // 
            // cmdPaste
            // 
            this.cmdPaste.Location = new System.Drawing.Point(121, 372);
            this.cmdPaste.Name = "cmdPaste";
            this.cmdPaste.Size = new System.Drawing.Size(91, 26);
            this.cmdPaste.TabIndex = 1;
            this.cmdPaste.Text = "Paste";
            this.cmdPaste.UseVisualStyleBackColor = true;
            this.cmdPaste.Click += new System.EventHandler(this.cmdPaste_Click);
            // 
            // tvPermit
            // 
            this.tvPermit.CheckBoxes = true;
            this.tvPermit.ContextMenuStrip = this.mnuPermission;
            this.tvPermit.Location = new System.Drawing.Point(6, 19);
            this.tvPermit.Name = "tvPermit";
            this.tvPermit.Size = new System.Drawing.Size(320, 347);
            this.tvPermit.TabIndex = 0;
            this.tvPermit.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvPermit_AfterCheck);
            this.tvPermit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvPermit_MouseDown);
            // 
            // mnuPermission
            // 
            this.mnuPermission.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCopy,
            this.mnuRemove});
            this.mnuPermission.Name = "mnuPermission";
            this.mnuPermission.Size = new System.Drawing.Size(167, 48);
            // 
            // mnuCopy
            // 
            this.mnuCopy.Name = "mnuCopy";
            this.mnuCopy.Size = new System.Drawing.Size(166, 22);
            this.mnuCopy.Text = "&Copy";
            this.mnuCopy.Click += new System.EventHandler(this.mnuCopy_Click);
            // 
            // mnuRemove
            // 
            this.mnuRemove.Name = "mnuRemove";
            this.mnuRemove.Size = new System.Drawing.Size(166, 22);
            this.mnuRemove.Text = "Explicitly &Remove";
            this.mnuRemove.Click += new System.EventHandler(this.mnuRemove_Click);
            // 
            // cmdNewTeam
            // 
            this.cmdNewTeam.Location = new System.Drawing.Point(34, 419);
            this.cmdNewTeam.Name = "cmdNewTeam";
            this.cmdNewTeam.Size = new System.Drawing.Size(133, 26);
            this.cmdNewTeam.TabIndex = 11;
            this.cmdNewTeam.Text = "&New Team";
            this.cmdNewTeam.UseVisualStyleBackColor = true;
            this.cmdNewTeam.Click += new System.EventHandler(this.mnuNewTeam_Click);
            // 
            // tv
            // 
            this.tv.AllowDrop = true;
            this.tv.ContextMenuStrip = this.mnuTeam;
            this.tv.ImageIndex = 0;
            this.tv.ImageList = this.il;
            this.tv.Location = new System.Drawing.Point(34, 16);
            this.tv.Name = "tv";
            this.tv.SelectedImageIndex = 0;
            this.tv.Size = new System.Drawing.Size(94, 397);
            this.tv.TabIndex = 7;
            this.tv.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv_NodeMouseDoubleClick);
            this.tv.DragDrop += new System.Windows.Forms.DragEventHandler(this.tv_DragDrop);
            this.tv.DragEnter += new System.Windows.Forms.DragEventHandler(this.tv_DragEnter);
            this.tv.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tv_MouseDown);
            // 
            // lstUsers
            // 
            this.lstUsers.AddCaption = "Add New User";
            this.lstUsers.AllowActions = true;
            this.lstUsers.AllowAdd = true;
            this.lstUsers.AllowDelete = true;
            this.lstUsers.AllowDeleteAlways = false;
            this.lstUsers.AllowDrop = true;
            this.lstUsers.AllowOnlyOpenDelete = false;
            this.lstUsers.AlternateConnection = null;
            this.lstUsers.BackColor = System.Drawing.Color.White;
            this.lstUsers.Caption = "Users";
            this.lstUsers.CurrentTemplate = null;
            this.lstUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstUsers.ExtraClassInfo = "";
            this.lstUsers.Location = new System.Drawing.Point(0, 50);
            this.lstUsers.MultiSelect = true;
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(367, 516);
            this.lstUsers.SuppressSelectionChanged = false;
            this.lstUsers.TabIndex = 14;
            this.lstUsers.zz_OpenColumnMenu = false;
            this.lstUsers.zz_OrderLineType = "";
            this.lstUsers.zz_ShowAutoRefresh = true;
            this.lstUsers.zz_ShowUnlimited = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbx_show_inactive);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 50);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // cbx_show_inactive
            // 
            this.cbx_show_inactive.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cbx_show_inactive.Bold = false;
            this.cbx_show_inactive.Caption = "Show Inactive";
            this.cbx_show_inactive.Changed = false;
            this.cbx_show_inactive.Location = new System.Drawing.Point(6, 19);
            this.cbx_show_inactive.Name = "cbx_show_inactive";
            this.cbx_show_inactive.Size = new System.Drawing.Size(94, 18);
            this.cbx_show_inactive.TabIndex = 12;
            this.cbx_show_inactive.UseParentBackColor = false;
            this.cbx_show_inactive.zz_CheckValue = false;
            this.cbx_show_inactive.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.cbx_show_inactive.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_show_inactive.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.cbx_show_inactive.zz_OriginalDesign = false;
            this.cbx_show_inactive.zz_ShowNeedsSaveColor = true;
            this.cbx_show_inactive.CheckChanged += new NewMethod.CheckChangedHandler(this.cbx_show_inactive_CheckChanged);
            // 
            // nTeams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sc);
            this.Name = "nTeams";
            this.Size = new System.Drawing.Size(951, 572);
            this.Resize += new System.EventHandler(this.nTeams_Resize);
            this.mnuTeam.ResumeLayout(false);
            this.sc.Panel1.ResumeLayout(false);
            this.sc.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sc)).EndInit();
            this.sc.ResumeLayout(false);
            this.gbPermissions.ResumeLayout(false);
            this.mnuPermission.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip mnuTeam;
        private System.Windows.Forms.ToolStripMenuItem mnuNewTeam;
        private System.Windows.Forms.ToolStripMenuItem mnuAddCaptain;
        private System.Windows.Forms.ToolStripMenuItem mnuRemoveCaptain;
        private System.Windows.Forms.ImageList il;
        private System.Windows.Forms.ToolStripSeparator sepTeam;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteTeam;
        private System.Windows.Forms.ToolStripSeparator sepMember;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteMember;
        private System.Windows.Forms.SplitContainer sc;
        private System.Windows.Forms.TreeView tv;
        private System.Windows.Forms.Button cmdNewTeam;
        private System.Windows.Forms.ToolStripMenuItem mnuAddMainStatus;
        private System.Windows.Forms.ToolStripMenuItem mnuRemoveMainStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuEditPermissions;
        private System.Windows.Forms.ToolStripMenuItem mnuRemoveAllPermissions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.GroupBox gbPermissions;
        private System.Windows.Forms.Button cmdPaste;
        private System.Windows.Forms.TreeView tvPermit;
        private System.Windows.Forms.ContextMenuStrip mnuPermission;
        private System.Windows.Forms.ToolStripMenuItem mnuCopy;
        private System.Windows.Forms.Button cmdListPermissions;
        private System.Windows.Forms.ToolStripMenuItem mnuRemove;
        private System.Windows.Forms.ToolStripMenuItem mnuRemoveNegative;
        private System.Windows.Forms.Button cmdRemoveAll;
        private System.Windows.Forms.GroupBox groupBox1;
        private nEdit_Boolean cbx_show_inactive;
        private nList lstUsers;
    }
}
