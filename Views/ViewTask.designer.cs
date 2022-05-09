namespace Rz5
{
    partial class ViewTask
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewTask));
            this.user_for = new NewMethod.nEdit_User();
            this.user_by = new NewMethod.nEdit_User();
            this.mnuLink = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.ctl_notetext = new NewMethod.nEdit_Memo();
            this.IM24 = new System.Windows.Forms.ImageList(this.components);
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdSaveAndExit = new System.Windows.Forms.Button();
            this.ctl_subjectstring = new NewMethod.nEdit_String();
            this.ctl_current_status = new NewMethod.nEdit_List();
            this.pTop = new System.Windows.Forms.PictureBox();
            this.pBottom = new System.Windows.Forms.PictureBox();
            this.pLeft = new System.Windows.Forms.PictureBox();
            this.pRight = new System.Windows.Forms.PictureBox();
            this.imExpand = new System.Windows.Forms.ImageList(this.components);
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.imPic = new System.Windows.Forms.ImageList(this.components);
            this.picSize = new System.Windows.Forms.PictureBox();
            this.picStatus = new System.Windows.Forms.PictureBox();
            this.ctl_task_size = new NewMethod.nEdit_List();
            this.ctl_task_type = new NewMethod.nEdit_List();
            this.lblAttachments = new System.Windows.Forms.LinkLabel();
            this.lblTagsLink = new System.Windows.Forms.LinkLabel();
            this.lblTags = new System.Windows.Forms.Label();
            this.mnuLink.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // user_for
            // 
            this.user_for.AllowChange = true;
            this.user_for.AllowClear = false;
            this.user_for.AllowNew = false;
            this.user_for.AllowView = false;
            this.user_for.BackColor = System.Drawing.Color.White;
            this.user_for.Bold = false;
            this.user_for.Caption = "To";
            this.user_for.Changed = false;
            this.user_for.Location = new System.Drawing.Point(223, 52);
            this.user_for.Name = "user_for";
            this.user_for.Size = new System.Drawing.Size(190, 56);
            this.user_for.TabIndex = 3;
            this.user_for.UseParentBackColor = true;
            this.user_for.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.user_for.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.user_for.DataChanged += new NewMethod.ChangeHandler(this.user_for_DataChanged);
            // 
            // user_by
            // 
            this.user_by.AllowChange = true;
            this.user_by.AllowClear = false;
            this.user_by.AllowNew = false;
            this.user_by.AllowView = false;
            this.user_by.BackColor = System.Drawing.Color.White;
            this.user_by.Bold = false;
            this.user_by.Caption = "From";
            this.user_by.Changed = false;
            this.user_by.Enabled = false;
            this.user_by.Location = new System.Drawing.Point(9, 47);
            this.user_by.Name = "user_by";
            this.user_by.Size = new System.Drawing.Size(187, 53);
            this.user_by.TabIndex = 2;
            this.user_by.UseParentBackColor = true;
            this.user_by.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.user_by.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.user_by.DataChanged += new NewMethod.ChangeHandler(this.user_by_DataChanged);
            // 
            // mnuLink
            // 
            this.mnuLink.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpen});
            this.mnuLink.Name = "mnuLink";
            this.mnuLink.Size = new System.Drawing.Size(104, 26);
            // 
            // mnuOpen
            // 
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(103, 22);
            this.mnuOpen.Text = "&Open";
            // 
            // ctl_notetext
            // 
            this.ctl_notetext.BackColor = System.Drawing.Color.White;
            this.ctl_notetext.Bold = false;
            this.ctl_notetext.Caption = "Notes";
            this.ctl_notetext.Changed = false;
            this.ctl_notetext.DateLines = false;
            this.ctl_notetext.Location = new System.Drawing.Point(9, 106);
            this.ctl_notetext.Name = "ctl_notetext";
            this.ctl_notetext.Size = new System.Drawing.Size(619, 104);
            this.ctl_notetext.TabIndex = 0;
            this.ctl_notetext.UseParentBackColor = true;
            this.ctl_notetext.zz_Enabled = true;
            this.ctl_notetext.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_notetext.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_notetext.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_notetext.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_notetext.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_notetext.zz_OriginalDesign = true;
            this.ctl_notetext.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_notetext.zz_ShowNeedsSaveColor = true;
            this.ctl_notetext.zz_Text = "";
            this.ctl_notetext.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_notetext.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_notetext.zz_UseGlobalColor = false;
            this.ctl_notetext.zz_UseGlobalFont = false;
            // 
            // IM24
            // 
            this.IM24.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IM24.ImageStream")));
            this.IM24.TransparentColor = System.Drawing.Color.Fuchsia;
            this.IM24.Images.SetKeyName(0, "Clip");
            this.IM24.Images.SetKeyName(1, "Note");
            this.IM24.Images.SetKeyName(2, "Save");
            this.IM24.Images.SetKeyName(3, "Delete");
            this.IM24.Images.SetKeyName(4, "SaveExit");
            this.IM24.Images.SetKeyName(5, "edit_menu");
            this.IM24.Images.SetKeyName(6, "mail");
            this.IM24.Images.SetKeyName(7, "print");
            this.IM24.Images.SetKeyName(8, "calendar");
            this.IM24.Images.SetKeyName(9, "reply");
            this.IM24.Images.SetKeyName(10, "forward");
            // 
            // cmdDelete
            // 
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.ImageIndex = 3;
            this.cmdDelete.ImageList = this.IM24;
            this.cmdDelete.Location = new System.Drawing.Point(634, 191);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(34, 36);
            this.cmdDelete.TabIndex = 16;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdSaveAndExit
            // 
            this.cmdSaveAndExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSaveAndExit.ImageIndex = 2;
            this.cmdSaveAndExit.ImageList = this.IM24;
            this.cmdSaveAndExit.Location = new System.Drawing.Point(634, 5);
            this.cmdSaveAndExit.Name = "cmdSaveAndExit";
            this.cmdSaveAndExit.Size = new System.Drawing.Size(68, 36);
            this.cmdSaveAndExit.TabIndex = 24;
            this.cmdSaveAndExit.Text = "Save";
            this.cmdSaveAndExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSaveAndExit.UseMnemonic = false;
            this.cmdSaveAndExit.UseVisualStyleBackColor = true;
            this.cmdSaveAndExit.Click += new System.EventHandler(this.cmdSaveAndExit_Click);
            // 
            // ctl_subjectstring
            // 
            this.ctl_subjectstring.AllCaps = false;
            this.ctl_subjectstring.BackColor = System.Drawing.Color.White;
            this.ctl_subjectstring.Bold = false;
            this.ctl_subjectstring.Caption = "Name";
            this.ctl_subjectstring.Changed = false;
            this.ctl_subjectstring.IsEmail = false;
            this.ctl_subjectstring.IsURL = false;
            this.ctl_subjectstring.Location = new System.Drawing.Point(149, 6);
            this.ctl_subjectstring.Name = "ctl_subjectstring";
            this.ctl_subjectstring.PasswordChar = '\0';
            this.ctl_subjectstring.Size = new System.Drawing.Size(333, 35);
            this.ctl_subjectstring.TabIndex = 28;
            this.ctl_subjectstring.UseParentBackColor = true;
            this.ctl_subjectstring.zz_Enabled = true;
            this.ctl_subjectstring.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_subjectstring.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_subjectstring.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_subjectstring.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_subjectstring.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_subjectstring.zz_OriginalDesign = false;
            this.ctl_subjectstring.zz_ShowLinkButton = false;
            this.ctl_subjectstring.zz_ShowNeedsSaveColor = true;
            this.ctl_subjectstring.zz_Text = "";
            this.ctl_subjectstring.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_subjectstring.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_subjectstring.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_subjectstring.zz_UseGlobalColor = false;
            this.ctl_subjectstring.zz_UseGlobalFont = false;
            // 
            // ctl_current_status
            // 
            this.ctl_current_status.AllCaps = false;
            this.ctl_current_status.AllowEdit = true;
            this.ctl_current_status.BackColor = System.Drawing.Color.White;
            this.ctl_current_status.Bold = false;
            this.ctl_current_status.Caption = "Status";
            this.ctl_current_status.Changed = false;
            this.ctl_current_status.ListName = "note_status";
            this.ctl_current_status.Location = new System.Drawing.Point(488, 47);
            this.ctl_current_status.Name = "ctl_current_status";
            this.ctl_current_status.SimpleList = null;
            this.ctl_current_status.Size = new System.Drawing.Size(99, 36);
            this.ctl_current_status.TabIndex = 30;
            this.ctl_current_status.UseParentBackColor = true;
            this.ctl_current_status.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_current_status.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_current_status.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_current_status.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_current_status.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_current_status.zz_OriginalDesign = false;
            this.ctl_current_status.zz_ShowNeedsSaveColor = true;
            this.ctl_current_status.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_current_status.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_current_status.zz_UseGlobalColor = false;
            this.ctl_current_status.zz_UseGlobalFont = false;
            this.ctl_current_status.DataChanged += new NewMethod.ChangeHandler(this.ctl_task_size_DataChanged);
            // 
            // pTop
            // 
            this.pTop.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.pTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTop.Location = new System.Drawing.Point(0, 0);
            this.pTop.Name = "pTop";
            this.pTop.Size = new System.Drawing.Size(919, 3);
            this.pTop.TabIndex = 34;
            this.pTop.TabStop = false;
            // 
            // pBottom
            // 
            this.pBottom.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.pBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pBottom.Location = new System.Drawing.Point(0, 233);
            this.pBottom.Name = "pBottom";
            this.pBottom.Size = new System.Drawing.Size(919, 3);
            this.pBottom.TabIndex = 35;
            this.pBottom.TabStop = false;
            // 
            // pLeft
            // 
            this.pLeft.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.pLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeft.Location = new System.Drawing.Point(0, 3);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(3, 230);
            this.pLeft.TabIndex = 36;
            this.pLeft.TabStop = false;
            // 
            // pRight
            // 
            this.pRight.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.pRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pRight.Location = new System.Drawing.Point(916, 3);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(3, 230);
            this.pRight.TabIndex = 37;
            this.pRight.TabStop = false;
            // 
            // imExpand
            // 
            this.imExpand.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imExpand.ImageStream")));
            this.imExpand.TransparentColor = System.Drawing.Color.Magenta;
            this.imExpand.Images.SetKeyName(0, "up");
            this.imExpand.Images.SetKeyName(1, "down");
            // 
            // picIcon
            // 
            this.picIcon.BackColor = System.Drawing.Color.White;
            this.picIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picIcon.Location = new System.Drawing.Point(3, 3);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(35, 35);
            this.picIcon.TabIndex = 41;
            this.picIcon.TabStop = false;
            // 
            // imPic
            // 
            this.imPic.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imPic.ImageStream")));
            this.imPic.TransparentColor = System.Drawing.Color.Transparent;
            this.imPic.Images.SetKeyName(0, "gear");
            this.imPic.Images.SetKeyName(1, "done");
            this.imPic.Images.SetKeyName(2, "readytotest");
            this.imPic.Images.SetKeyName(3, "large");
            this.imPic.Images.SetKeyName(4, "small");
            // 
            // picSize
            // 
            this.picSize.BackColor = System.Drawing.Color.White;
            this.picSize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picSize.Location = new System.Drawing.Point(593, 6);
            this.picSize.Name = "picSize";
            this.picSize.Size = new System.Drawing.Size(35, 35);
            this.picSize.TabIndex = 43;
            this.picSize.TabStop = false;
            // 
            // picStatus
            // 
            this.picStatus.BackColor = System.Drawing.Color.White;
            this.picStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picStatus.Location = new System.Drawing.Point(593, 47);
            this.picStatus.Name = "picStatus";
            this.picStatus.Size = new System.Drawing.Size(35, 35);
            this.picStatus.TabIndex = 44;
            this.picStatus.TabStop = false;
            // 
            // ctl_task_size
            // 
            this.ctl_task_size.AllCaps = false;
            this.ctl_task_size.AllowEdit = true;
            this.ctl_task_size.BackColor = System.Drawing.Color.White;
            this.ctl_task_size.Bold = false;
            this.ctl_task_size.Caption = "Size";
            this.ctl_task_size.Changed = false;
            this.ctl_task_size.ListName = "task_size";
            this.ctl_task_size.Location = new System.Drawing.Point(488, 5);
            this.ctl_task_size.Name = "ctl_task_size";
            this.ctl_task_size.SimpleList = null;
            this.ctl_task_size.Size = new System.Drawing.Size(99, 36);
            this.ctl_task_size.TabIndex = 48;
            this.ctl_task_size.UseParentBackColor = true;
            this.ctl_task_size.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_task_size.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_task_size.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_task_size.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_task_size.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_task_size.zz_OriginalDesign = false;
            this.ctl_task_size.zz_ShowNeedsSaveColor = true;
            this.ctl_task_size.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_task_size.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_task_size.zz_UseGlobalColor = false;
            this.ctl_task_size.zz_UseGlobalFont = false;
            this.ctl_task_size.DataChanged += new NewMethod.ChangeHandler(this.ctl_task_size_DataChanged);
            // 
            // ctl_task_type
            // 
            this.ctl_task_type.AllCaps = false;
            this.ctl_task_type.AllowEdit = true;
            this.ctl_task_type.BackColor = System.Drawing.Color.White;
            this.ctl_task_type.Bold = false;
            this.ctl_task_type.Caption = "Type";
            this.ctl_task_type.Changed = false;
            this.ctl_task_type.ListName = "task_type";
            this.ctl_task_type.Location = new System.Drawing.Point(44, 6);
            this.ctl_task_type.Name = "ctl_task_type";
            this.ctl_task_type.SimpleList = null;
            this.ctl_task_type.Size = new System.Drawing.Size(99, 36);
            this.ctl_task_type.TabIndex = 49;
            this.ctl_task_type.UseParentBackColor = true;
            this.ctl_task_type.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_task_type.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_task_type.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_task_type.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_task_type.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_task_type.zz_OriginalDesign = false;
            this.ctl_task_type.zz_ShowNeedsSaveColor = true;
            this.ctl_task_type.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_task_type.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_task_type.zz_UseGlobalColor = false;
            this.ctl_task_type.zz_UseGlobalFont = false;
            this.ctl_task_type.DataChanged += new NewMethod.ChangeHandler(this.ctl_task_size_DataChanged);
            // 
            // lblAttachments
            // 
            this.lblAttachments.AutoSize = true;
            this.lblAttachments.Location = new System.Drawing.Point(489, 95);
            this.lblAttachments.Name = "lblAttachments";
            this.lblAttachments.Size = new System.Drawing.Size(78, 13);
            this.lblAttachments.TabIndex = 50;
            this.lblAttachments.TabStop = true;
            this.lblAttachments.Text = "Attachments: 0";
            this.lblAttachments.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAttachments_LinkClicked);
            // 
            // lblTagsLink
            // 
            this.lblTagsLink.AutoSize = true;
            this.lblTagsLink.Location = new System.Drawing.Point(11, 213);
            this.lblTagsLink.Name = "lblTagsLink";
            this.lblTagsLink.Size = new System.Drawing.Size(34, 13);
            this.lblTagsLink.TabIndex = 51;
            this.lblTagsLink.TabStop = true;
            this.lblTagsLink.Text = "Tags:";
            this.lblTagsLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblTagsLink_LinkClicked);
            // 
            // lblTags
            // 
            this.lblTags.AutoSize = true;
            this.lblTags.Location = new System.Drawing.Point(51, 214);
            this.lblTags.Name = "lblTags";
            this.lblTags.Size = new System.Drawing.Size(39, 13);
            this.lblTags.TabIndex = 52;
            this.lblTags.Text = "<tags>";
            // 
            // ViewTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblTags);
            this.Controls.Add(this.lblTagsLink);
            this.Controls.Add(this.lblAttachments);
            this.Controls.Add(this.ctl_task_type);
            this.Controls.Add(this.ctl_task_size);
            this.Controls.Add(this.picStatus);
            this.Controls.Add(this.picSize);
            this.Controls.Add(this.picIcon);
            this.Controls.Add(this.cmdSaveAndExit);
            this.Controls.Add(this.pRight);
            this.Controls.Add(this.pLeft);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.pBottom);
            this.Controls.Add(this.pTop);
            this.Controls.Add(this.ctl_current_status);
            this.Controls.Add(this.ctl_notetext);
            this.Controls.Add(this.user_for);
            this.Controls.Add(this.user_by);
            this.Controls.Add(this.ctl_subjectstring);
            this.Name = "ViewTask";
            this.Size = new System.Drawing.Size(919, 236);
            this.Resize += new System.EventHandler(this.view_usernote_Resize);
            this.Controls.SetChildIndex(this.ctl_subjectstring, 0);
            this.Controls.SetChildIndex(this.user_by, 0);
            this.Controls.SetChildIndex(this.user_for, 0);
            this.Controls.SetChildIndex(this.ctl_notetext, 0);
            this.Controls.SetChildIndex(this.ctl_current_status, 0);
            this.Controls.SetChildIndex(this.pTop, 0);
            this.Controls.SetChildIndex(this.pBottom, 0);
            this.Controls.SetChildIndex(this.cmdDelete, 0);
            this.Controls.SetChildIndex(this.pLeft, 0);
            this.Controls.SetChildIndex(this.pRight, 0);
            this.Controls.SetChildIndex(this.cmdSaveAndExit, 0);
            this.Controls.SetChildIndex(this.picIcon, 0);
            this.Controls.SetChildIndex(this.picSize, 0);
            this.Controls.SetChildIndex(this.picStatus, 0);
            this.Controls.SetChildIndex(this.ctl_task_size, 0);
            this.Controls.SetChildIndex(this.ctl_task_type, 0);
            this.Controls.SetChildIndex(this.lblAttachments, 0);
            this.Controls.SetChildIndex(this.lblTagsLink, 0);
            this.Controls.SetChildIndex(this.lblTags, 0);
            this.mnuLink.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ImageList IM24;
        private System.Windows.Forms.ContextMenuStrip mnuLink;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.PictureBox pTop;
        private System.Windows.Forms.PictureBox pBottom;
        private System.Windows.Forms.PictureBox pLeft;
        private System.Windows.Forms.PictureBox pRight;
        private System.Windows.Forms.ImageList imExpand;
        private System.Windows.Forms.ImageList imPic;
        protected NewMethod.nEdit_User user_for;
        protected NewMethod.nEdit_User user_by;
        protected NewMethod.nEdit_Memo ctl_notetext;
        protected System.Windows.Forms.Button cmdDelete;
        protected NewMethod.nEdit_String ctl_subjectstring;
        protected NewMethod.nEdit_List ctl_current_status;
        protected System.Windows.Forms.Button cmdSaveAndExit;
        protected System.Windows.Forms.PictureBox picIcon;
        protected System.Windows.Forms.PictureBox picSize;
        protected System.Windows.Forms.PictureBox picStatus;
        protected NewMethod.nEdit_List ctl_task_size;
        protected NewMethod.nEdit_List ctl_task_type;
        protected System.Windows.Forms.LinkLabel lblAttachments;
        protected System.Windows.Forms.LinkLabel lblTagsLink;
        protected System.Windows.Forms.Label lblTags;
    }
}
