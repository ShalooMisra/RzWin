using Tools.Database;
namespace Rz5
{
    partial class view_usernote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(view_usernote));
            this.user_for = new NewMethod.nEdit_User();
            this.user_by = new NewMethod.nEdit_User();
            this.ctlTime = new NewMethod.nEdit_String();
            this.ctl_isclosed = new NewMethod.nEdit_Boolean();
            this.ctl_shouldpopup = new NewMethod.nEdit_Boolean();
            this.ctlDate = new NewMethod.nEdit_Date();
            this.lv = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mnuLink = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.ctl_notetext = new NewMethod.nEdit_Memo();
            this.cmdPrint = new System.Windows.Forms.Button();
            this.IM24 = new System.Windows.Forms.ImageList(this.components);
            this.cmdSaveAndExit = new System.Windows.Forms.Button();
            this.cmdSend = new System.Windows.Forms.Button();
            this.cmdForward = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdReply = new System.Windows.Forms.Button();
            this.cmdPostpone = new System.Windows.Forms.Button();
            this.fpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.ctl_subjectstring = new NewMethod.nEdit_String();
            this.ctl_extra_info = new NewMethod.nEdit_Memo();
            this.ctl_current_status = new NewMethod.nEdit_List();
            this.ctl_importance = new NewMethod.nEdit_Number();
            this.fc = new Rz5.Focus.FocusChat();
            this.lblCompanyAssign = new System.Windows.Forms.LinkLabel();
            this.lblCompanyContact = new System.Windows.Forms.Label();
            this.cmdCC = new System.Windows.Forms.Button();
            this.mnuLink.SuspendLayout();
            this.fpButtons.SuspendLayout();
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
            this.user_for.Location = new System.Drawing.Point(372, -4);
            this.user_for.Name = "user_for";
            this.user_for.Size = new System.Drawing.Size(245, 56);
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
            this.user_by.Location = new System.Drawing.Point(191, -4);
            this.user_by.Name = "user_by";
            this.user_by.Size = new System.Drawing.Size(245, 53);
            this.user_by.TabIndex = 2;
            this.user_by.UseParentBackColor = true;
            this.user_by.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.user_by.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.user_by.DataChanged += new NewMethod.ChangeHandler(this.user_by_DataChanged);
            // 
            // ctlTime
            // 
            this.ctlTime.AllCaps = false;
            this.ctlTime.BackColor = System.Drawing.Color.White;
            this.ctlTime.Bold = false;
            this.ctlTime.Caption = "Time";
            this.ctlTime.Changed = false;
            this.ctlTime.IsEmail = false;
            this.ctlTime.IsURL = false;
            this.ctlTime.Location = new System.Drawing.Point(15, 48);
            this.ctlTime.Name = "ctlTime";
            this.ctlTime.PasswordChar = '\0';
            this.ctlTime.Size = new System.Drawing.Size(119, 21);
            this.ctlTime.TabIndex = 12;
            this.ctlTime.UseParentBackColor = true;
            this.ctlTime.zz_Enabled = true;
            this.ctlTime.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlTime.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlTime.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlTime.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctlTime.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.Left;
            this.ctlTime.zz_OriginalDesign = false;
            this.ctlTime.zz_ShowLinkButton = false;
            this.ctlTime.zz_ShowNeedsSaveColor = true;
            this.ctlTime.zz_Text = "";
            this.ctlTime.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlTime.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlTime.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlTime.zz_UseGlobalColor = false;
            this.ctlTime.zz_UseGlobalFont = false;
            // 
            // ctl_isclosed
            // 
            this.ctl_isclosed.BackColor = System.Drawing.Color.White;
            this.ctl_isclosed.Bold = false;
            this.ctl_isclosed.Caption = "Closed?";
            this.ctl_isclosed.Changed = false;
            this.ctl_isclosed.Location = new System.Drawing.Point(321, 66);
            this.ctl_isclosed.Name = "ctl_isclosed";
            this.ctl_isclosed.Size = new System.Drawing.Size(64, 18);
            this.ctl_isclosed.TabIndex = 11;
            this.ctl_isclosed.UseParentBackColor = true;
            this.ctl_isclosed.zz_CheckValue = false;
            this.ctl_isclosed.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_isclosed.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_isclosed.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_isclosed.zz_OriginalDesign = false;
            this.ctl_isclosed.zz_ShowNeedsSaveColor = true;
            // 
            // ctl_shouldpopup
            // 
            this.ctl_shouldpopup.BackColor = System.Drawing.Color.White;
            this.ctl_shouldpopup.Bold = false;
            this.ctl_shouldpopup.Caption = "Pop Up?";
            this.ctl_shouldpopup.Changed = false;
            this.ctl_shouldpopup.Location = new System.Drawing.Point(241, 66);
            this.ctl_shouldpopup.Name = "ctl_shouldpopup";
            this.ctl_shouldpopup.Size = new System.Drawing.Size(68, 18);
            this.ctl_shouldpopup.TabIndex = 10;
            this.ctl_shouldpopup.UseParentBackColor = true;
            this.ctl_shouldpopup.zz_CheckValue = false;
            this.ctl_shouldpopup.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_shouldpopup.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_shouldpopup.zz_LabelLocation = NewMethod.nEdit_Boolean.LabelLocations.Right;
            this.ctl_shouldpopup.zz_OriginalDesign = false;
            this.ctl_shouldpopup.zz_ShowNeedsSaveColor = true;
            // 
            // ctlDate
            // 
            this.ctlDate.AllowClear = false;
            this.ctlDate.BackColor = System.Drawing.Color.White;
            this.ctlDate.Bold = false;
            this.ctlDate.Caption = "Date";
            this.ctlDate.Changed = false;
            this.ctlDate.Location = new System.Drawing.Point(3, -3);
            this.ctlDate.Name = "ctlDate";
            this.ctlDate.Size = new System.Drawing.Size(182, 53);
            this.ctlDate.SuppressEdit = false;
            this.ctlDate.TabIndex = 9;
            this.ctlDate.UseParentBackColor = true;
            this.ctlDate.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlDate.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlDate.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlDate.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctlDate.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.ctlDate.zz_OriginalDesign = true;
            this.ctlDate.zz_ShowNeedsSaveColor = true;
            this.ctlDate.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlDate.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlDate.zz_UseGlobalColor = false;
            this.ctlDate.zz_UseGlobalFont = false;
            // 
            // lv
            // 
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lv.ContextMenuStrip = this.mnuLink;
            this.lv.Location = new System.Drawing.Point(666, 104);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(250, 119);
            this.lv.TabIndex = 14;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.DoubleClick += new System.EventHandler(this.lv_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Linked Information";
            this.columnHeader1.Width = 240;
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
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // ctl_notetext
            // 
            this.ctl_notetext.BackColor = System.Drawing.Color.White;
            this.ctl_notetext.Bold = false;
            this.ctl_notetext.Caption = "Note";
            this.ctl_notetext.Changed = false;
            this.ctl_notetext.DateLines = false;
            this.ctl_notetext.Location = new System.Drawing.Point(3, 116);
            this.ctl_notetext.Name = "ctl_notetext";
            this.ctl_notetext.Size = new System.Drawing.Size(644, 70);
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
            // cmdPrint
            // 
            this.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPrint.ImageIndex = 7;
            this.cmdPrint.ImageList = this.IM24;
            this.cmdPrint.Location = new System.Drawing.Point(251, 3);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(118, 36);
            this.cmdPrint.TabIndex = 17;
            this.cmdPrint.Text = "Print";
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
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
            // cmdSaveAndExit
            // 
            this.cmdSaveAndExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSaveAndExit.ImageIndex = 4;
            this.cmdSaveAndExit.ImageList = this.IM24;
            this.cmdSaveAndExit.Location = new System.Drawing.Point(127, 3);
            this.cmdSaveAndExit.Name = "cmdSaveAndExit";
            this.cmdSaveAndExit.Size = new System.Drawing.Size(118, 36);
            this.cmdSaveAndExit.TabIndex = 24;
            this.cmdSaveAndExit.Text = "Save & Exit";
            this.cmdSaveAndExit.UseMnemonic = false;
            this.cmdSaveAndExit.UseVisualStyleBackColor = true;
            this.cmdSaveAndExit.Click += new System.EventHandler(this.cmdSaveAndExit_Click);
            // 
            // cmdSend
            // 
            this.cmdSend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSend.ImageIndex = 6;
            this.cmdSend.ImageList = this.IM24;
            this.cmdSend.Location = new System.Drawing.Point(3, 3);
            this.cmdSend.Name = "cmdSend";
            this.cmdSend.Size = new System.Drawing.Size(118, 36);
            this.cmdSend.TabIndex = 15;
            this.cmdSend.Text = "Send";
            this.cmdSend.UseVisualStyleBackColor = true;
            this.cmdSend.Click += new System.EventHandler(this.cmdSend_Click);
            // 
            // cmdForward
            // 
            this.cmdForward.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdForward.ImageIndex = 10;
            this.cmdForward.ImageList = this.IM24;
            this.cmdForward.Location = new System.Drawing.Point(623, 3);
            this.cmdForward.Name = "cmdForward";
            this.cmdForward.Size = new System.Drawing.Size(118, 36);
            this.cmdForward.TabIndex = 20;
            this.cmdForward.Text = "Forward";
            this.cmdForward.UseVisualStyleBackColor = true;
            this.cmdForward.Click += new System.EventHandler(this.cmdForward_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.ImageIndex = 3;
            this.cmdDelete.ImageList = this.IM24;
            this.cmdDelete.Location = new System.Drawing.Point(747, 3);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(118, 36);
            this.cmdDelete.TabIndex = 16;
            this.cmdDelete.Text = "Cancel";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdReply
            // 
            this.cmdReply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdReply.ImageIndex = 9;
            this.cmdReply.ImageList = this.IM24;
            this.cmdReply.Location = new System.Drawing.Point(499, 3);
            this.cmdReply.Name = "cmdReply";
            this.cmdReply.Size = new System.Drawing.Size(118, 36);
            this.cmdReply.TabIndex = 19;
            this.cmdReply.Text = "Reply";
            this.cmdReply.UseVisualStyleBackColor = true;
            this.cmdReply.Click += new System.EventHandler(this.cmdReply_Click);
            // 
            // cmdPostpone
            // 
            this.cmdPostpone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPostpone.ImageIndex = 8;
            this.cmdPostpone.ImageList = this.IM24;
            this.cmdPostpone.Location = new System.Drawing.Point(375, 3);
            this.cmdPostpone.Name = "cmdPostpone";
            this.cmdPostpone.Size = new System.Drawing.Size(118, 36);
            this.cmdPostpone.TabIndex = 18;
            this.cmdPostpone.Text = "Postpone";
            this.cmdPostpone.UseVisualStyleBackColor = true;
            this.cmdPostpone.Click += new System.EventHandler(this.cmdPostpone_Click);
            // 
            // fpButtons
            // 
            this.fpButtons.Controls.Add(this.cmdSend);
            this.fpButtons.Controls.Add(this.cmdSaveAndExit);
            this.fpButtons.Controls.Add(this.cmdPrint);
            this.fpButtons.Controls.Add(this.cmdPostpone);
            this.fpButtons.Controls.Add(this.cmdReply);
            this.fpButtons.Controls.Add(this.cmdForward);
            this.fpButtons.Controls.Add(this.cmdDelete);
            this.fpButtons.Location = new System.Drawing.Point(16, 229);
            this.fpButtons.Name = "fpButtons";
            this.fpButtons.Size = new System.Drawing.Size(884, 44);
            this.fpButtons.TabIndex = 27;
            // 
            // ctl_subjectstring
            // 
            this.ctl_subjectstring.AllCaps = false;
            this.ctl_subjectstring.BackColor = System.Drawing.Color.White;
            this.ctl_subjectstring.Bold = false;
            this.ctl_subjectstring.Caption = "Subject";
            this.ctl_subjectstring.Changed = false;
            this.ctl_subjectstring.IsEmail = false;
            this.ctl_subjectstring.IsURL = false;
            this.ctl_subjectstring.Location = new System.Drawing.Point(3, 76);
            this.ctl_subjectstring.Name = "ctl_subjectstring";
            this.ctl_subjectstring.PasswordChar = '\0';
            this.ctl_subjectstring.Size = new System.Drawing.Size(438, 35);
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
            // ctl_extra_info
            // 
            this.ctl_extra_info.BackColor = System.Drawing.Color.White;
            this.ctl_extra_info.Bold = false;
            this.ctl_extra_info.Caption = "Extra Info";
            this.ctl_extra_info.Changed = false;
            this.ctl_extra_info.DateLines = false;
            this.ctl_extra_info.Location = new System.Drawing.Point(3, 192);
            this.ctl_extra_info.Name = "ctl_extra_info";
            this.ctl_extra_info.Size = new System.Drawing.Size(644, 31);
            this.ctl_extra_info.TabIndex = 29;
            this.ctl_extra_info.UseParentBackColor = true;
            this.ctl_extra_info.zz_Enabled = true;
            this.ctl_extra_info.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_extra_info.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_extra_info.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_extra_info.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_extra_info.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_extra_info.zz_OriginalDesign = true;
            this.ctl_extra_info.zz_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ctl_extra_info.zz_ShowNeedsSaveColor = true;
            this.ctl_extra_info.zz_Text = "";
            this.ctl_extra_info.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_extra_info.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_extra_info.zz_UseGlobalColor = false;
            this.ctl_extra_info.zz_UseGlobalFont = false;
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
            this.ctl_current_status.Location = new System.Drawing.Point(460, 75);
            this.ctl_current_status.Name = "ctl_current_status";
            this.ctl_current_status.SimpleList = null;
            this.ctl_current_status.Size = new System.Drawing.Size(135, 36);
            this.ctl_current_status.TabIndex = 30;
            this.ctl_current_status.UseParentBackColor = true;
            this.ctl_current_status.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
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
            // 
            // ctl_importance
            // 
            this.ctl_importance.BackColor = System.Drawing.Color.White;
            this.ctl_importance.Bold = false;
            this.ctl_importance.Caption = "Rank";
            this.ctl_importance.Changed = false;
            this.ctl_importance.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_importance.Location = new System.Drawing.Point(601, 75);
            this.ctl_importance.Name = "ctl_importance";
            this.ctl_importance.Size = new System.Drawing.Size(58, 35);
            this.ctl_importance.TabIndex = 31;
            this.ctl_importance.UseParentBackColor = true;
            this.ctl_importance.zz_Enabled = true;
            this.ctl_importance.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_importance.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_importance.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_importance.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_importance.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_importance.zz_OriginalDesign = false;
            this.ctl_importance.zz_ShowErrorColor = true;
            this.ctl_importance.zz_ShowNeedsSaveColor = true;
            this.ctl_importance.zz_Text = "";
            this.ctl_importance.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_importance.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_importance.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_importance.zz_UseGlobalColor = false;
            this.ctl_importance.zz_UseGlobalFont = false;
            // 
            // fc
            // 
            this.fc.Location = new System.Drawing.Point(609, 3);
            this.fc.Name = "fc";
            this.fc.Size = new System.Drawing.Size(308, 66);
            this.fc.TabIndex = 26;
            // 
            // lblCompanyAssign
            // 
            this.lblCompanyAssign.AutoSize = true;
            this.lblCompanyAssign.Location = new System.Drawing.Point(668, 87);
            this.lblCompanyAssign.Name = "lblCompanyAssign";
            this.lblCompanyAssign.Size = new System.Drawing.Size(111, 13);
            this.lblCompanyAssign.TabIndex = 32;
            this.lblCompanyAssign.TabStop = true;
            this.lblCompanyAssign.Text = "Assign To A Company";
            this.lblCompanyAssign.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCompanyAssign_LinkClicked);
            // 
            // lblCompanyContact
            // 
            this.lblCompanyContact.AutoSize = true;
            this.lblCompanyContact.Location = new System.Drawing.Point(668, 70);
            this.lblCompanyContact.Name = "lblCompanyContact";
            this.lblCompanyContact.Size = new System.Drawing.Size(62, 13);
            this.lblCompanyContact.TabIndex = 33;
            this.lblCompanyContact.Text = "<company>";
            // 
            // cmdCC
            // 
            this.cmdCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCC.Location = new System.Drawing.Point(555, -1);
            this.cmdCC.Name = "cmdCC";
            this.cmdCC.Size = new System.Drawing.Size(62, 17);
            this.cmdCC.TabIndex = 34;
            this.cmdCC.Text = "Add Recipient";
            this.cmdCC.UseVisualStyleBackColor = true;
            this.cmdCC.Click += new System.EventHandler(this.cmdCC_Click);
            // 
            // view_usernote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cmdCC);
            this.Controls.Add(this.lblCompanyContact);
            this.Controls.Add(this.lblCompanyAssign);
            this.Controls.Add(this.ctl_importance);
            this.Controls.Add(this.ctl_current_status);
            this.Controls.Add(this.ctl_extra_info);
            this.Controls.Add(this.fpButtons);
            this.Controls.Add(this.ctl_isclosed);
            this.Controls.Add(this.ctl_shouldpopup);
            this.Controls.Add(this.fc);
            this.Controls.Add(this.lv);
            this.Controls.Add(this.ctl_notetext);
            this.Controls.Add(this.ctlTime);
            this.Controls.Add(this.ctlDate);
            this.Controls.Add(this.user_for);
            this.Controls.Add(this.user_by);
            this.Controls.Add(this.ctl_subjectstring);
            this.Name = "view_usernote";
            this.Size = new System.Drawing.Size(919, 278);
            this.Resize += new System.EventHandler(this.view_usernote_Resize);
            this.mnuLink.ResumeLayout(false);
            this.fpButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NewMethod.nEdit_User user_by;
        private NewMethod.nEdit_String ctlTime;
        private NewMethod.nEdit_Boolean ctl_isclosed;
        private NewMethod.nEdit_Boolean ctl_shouldpopup;
        private NewMethod.nEdit_Date ctlDate;
        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private NewMethod.nEdit_Memo ctl_notetext;
        private System.Windows.Forms.Button cmdSend;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdPrint;
        private System.Windows.Forms.Button cmdPostpone;
        private System.Windows.Forms.Button cmdReply;
        private System.Windows.Forms.Button cmdForward;
        private System.Windows.Forms.Button cmdSaveAndExit;
        public System.Windows.Forms.ImageList IM24;
        private Focus.FocusChat fc;
        private System.Windows.Forms.FlowLayoutPanel fpButtons;
        private System.Windows.Forms.ContextMenuStrip mnuLink;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private NewMethod.nEdit_String ctl_subjectstring;
        private NewMethod.nEdit_Memo ctl_extra_info;
        private NewMethod.nEdit_List ctl_current_status;
        private NewMethod.nEdit_Number ctl_importance;
        private System.Windows.Forms.LinkLabel lblCompanyAssign;
        private System.Windows.Forms.Label lblCompanyContact;
        private System.Windows.Forms.Button cmdCC;
        protected NewMethod.nEdit_User user_for;
    }
}
