namespace Rz5.Win.Screens
{
    partial class Tasks
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
                InitUn();

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
            this.mnu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newSubFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pSearch = new System.Windows.Forms.Panel();
            this.lblUpdateAll = new System.Windows.Forms.LinkLabel();
            this.cmdPriorities = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.sp = new System.Windows.Forms.SplitContainer();
            this.cmdActivity = new System.Windows.Forms.Button();
            this.ctl_task_type = new NewMethod.nEdit_List();
            this.ctl_task_size = new NewMethod.nEdit_List();
            this.ctl_current_status = new NewMethod.nEdit_List();
            this.ctlTo = new NewMethod.nEdit_User();
            this.ctlFrom = new NewMethod.nEdit_User();
            this.lv = new NewMethod.nList();
            this.vf = new Win.Views.ViewFolder();
            this.mnu.SuspendLayout();
            this.pSearch.SuspendLayout();
            this.sp.Panel1.SuspendLayout();
            this.sp.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnu
            // 
            this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSubFolderToolStripMenuItem,
            this.toolStripSeparator1,
            this.deleteToolStripMenuItem});
            this.mnu.Name = "mnu";
            this.mnu.Size = new System.Drawing.Size(155, 54);
            // 
            // newSubFolderToolStripMenuItem
            // 
            this.newSubFolderToolStripMenuItem.Name = "newSubFolderToolStripMenuItem";
            this.newSubFolderToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.newSubFolderToolStripMenuItem.Text = "New SubFolder";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(151, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // pSearch
            // 
            this.pSearch.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pSearch.Controls.Add(this.cmdActivity);
            this.pSearch.Controls.Add(this.lblUpdateAll);
            this.pSearch.Controls.Add(this.ctl_task_type);
            this.pSearch.Controls.Add(this.ctl_task_size);
            this.pSearch.Controls.Add(this.ctl_current_status);
            this.pSearch.Controls.Add(this.cmdPriorities);
            this.pSearch.Controls.Add(this.ctlTo);
            this.pSearch.Controls.Add(this.ctlFrom);
            this.pSearch.Controls.Add(this.txtSearch);
            this.pSearch.Controls.Add(this.label2);
            this.pSearch.Controls.Add(this.cmdSearch);
            this.pSearch.Location = new System.Drawing.Point(3, 3);
            this.pSearch.Name = "pSearch";
            this.pSearch.Size = new System.Drawing.Size(727, 146);
            this.pSearch.TabIndex = 3;
            // 
            // lblUpdateAll
            // 
            this.lblUpdateAll.AutoSize = true;
            this.lblUpdateAll.Location = new System.Drawing.Point(451, 7);
            this.lblUpdateAll.Name = "lblUpdateAll";
            this.lblUpdateAll.Size = new System.Drawing.Size(56, 13);
            this.lblUpdateAll.TabIndex = 53;
            this.lblUpdateAll.TabStop = true;
            this.lblUpdateAll.Text = "Update All";
            this.lblUpdateAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblUpdateAll_LinkClicked);
            // 
            // cmdPriorities
            // 
            this.cmdPriorities.Location = new System.Drawing.Point(397, 69);
            this.cmdPriorities.Name = "cmdPriorities";
            this.cmdPriorities.Size = new System.Drawing.Size(111, 32);
            this.cmdPriorities.TabIndex = 8;
            this.cmdPriorities.Text = "Priorities";
            this.cmdPriorities.UseVisualStyleBackColor = true;
            this.cmdPriorities.Click += new System.EventHandler(this.cmdPriorities_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(8, 23);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(499, 21);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Search by task name or notes";
            // 
            // cmdSearch
            // 
            this.cmdSearch.Location = new System.Drawing.Point(514, 3);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(127, 51);
            this.cmdSearch.TabIndex = 3;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // sp
            // 
            this.sp.Location = new System.Drawing.Point(3, 3);
            this.sp.Name = "sp";
            this.sp.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sp.Panel1
            // 
            this.sp.Panel1.Controls.Add(this.pSearch);
            this.sp.Panel1.Controls.Add(this.lv);
            this.sp.Panel1.Controls.Add(this.vf);
            this.sp.Size = new System.Drawing.Size(903, 601);
            this.sp.SplitterDistance = 407;
            this.sp.TabIndex = 8;
            this.sp.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.sp_SplitterMoved);
            // 
            // cmdActivity
            // 
            this.cmdActivity.Location = new System.Drawing.Point(397, 102);
            this.cmdActivity.Name = "cmdActivity";
            this.cmdActivity.Size = new System.Drawing.Size(110, 32);
            this.cmdActivity.TabIndex = 54;
            this.cmdActivity.Text = "Activity";
            this.cmdActivity.UseVisualStyleBackColor = true;
            this.cmdActivity.Click += new System.EventHandler(this.cmdActivity_Click);
            // 
            // ctl_task_type
            // 
            this.ctl_task_type.AllCaps = false;
            this.ctl_task_type.AllowEdit = true;
            this.ctl_task_type.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ctl_task_type.Bold = false;
            this.ctl_task_type.Caption = "Type";
            this.ctl_task_type.Changed = false;
            this.ctl_task_type.ListName = "task_type";
            this.ctl_task_type.Location = new System.Drawing.Point(8, 107);
            this.ctl_task_type.Name = "ctl_task_type";
            this.ctl_task_type.SimpleList = null;
            this.ctl_task_type.Size = new System.Drawing.Size(99, 36);
            this.ctl_task_type.TabIndex = 52;
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
            // 
            // ctl_task_size
            // 
            this.ctl_task_size.AllCaps = false;
            this.ctl_task_size.AllowEdit = true;
            this.ctl_task_size.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ctl_task_size.Bold = false;
            this.ctl_task_size.Caption = "Size";
            this.ctl_task_size.Changed = false;
            this.ctl_task_size.ListName = "task_size";
            this.ctl_task_size.Location = new System.Drawing.Point(113, 107);
            this.ctl_task_size.Name = "ctl_task_size";
            this.ctl_task_size.SimpleList = null;
            this.ctl_task_size.Size = new System.Drawing.Size(99, 36);
            this.ctl_task_size.TabIndex = 51;
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
            // 
            // ctl_current_status
            // 
            this.ctl_current_status.AllCaps = false;
            this.ctl_current_status.AllowEdit = true;
            this.ctl_current_status.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ctl_current_status.Bold = false;
            this.ctl_current_status.Caption = "Status";
            this.ctl_current_status.Changed = false;
            this.ctl_current_status.ListName = "note_status";
            this.ctl_current_status.Location = new System.Drawing.Point(218, 107);
            this.ctl_current_status.Name = "ctl_current_status";
            this.ctl_current_status.SimpleList = null;
            this.ctl_current_status.Size = new System.Drawing.Size(99, 36);
            this.ctl_current_status.TabIndex = 50;
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
            // 
            // ctlTo
            // 
            this.ctlTo.AllowChange = true;
            this.ctlTo.AllowClear = true;
            this.ctlTo.AllowNew = false;
            this.ctlTo.AllowView = false;
            this.ctlTo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ctlTo.Bold = false;
            this.ctlTo.Caption = "To";
            this.ctlTo.Changed = false;
            this.ctlTo.Location = new System.Drawing.Point(244, 50);
            this.ctlTo.Name = "ctlTo";
            this.ctlTo.Size = new System.Drawing.Size(230, 55);
            this.ctlTo.TabIndex = 7;
            this.ctlTo.UseParentBackColor = true;
            this.ctlTo.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlTo.zz_LabelFont = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlTo.ChangeUser += new NewMethod.ChangeUserHandler(this.ctlTo_ChangeUser);
            this.ctlTo.ClearUser += new NewMethod.ClearUserHandler(this.ctlTo_ClearUser);
            // 
            // ctlFrom
            // 
            this.ctlFrom.AllowChange = true;
            this.ctlFrom.AllowClear = true;
            this.ctlFrom.AllowNew = false;
            this.ctlFrom.AllowView = false;
            this.ctlFrom.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ctlFrom.Bold = false;
            this.ctlFrom.Caption = "From";
            this.ctlFrom.Changed = false;
            this.ctlFrom.Location = new System.Drawing.Point(8, 50);
            this.ctlFrom.Name = "ctlFrom";
            this.ctlFrom.Size = new System.Drawing.Size(230, 55);
            this.ctlFrom.TabIndex = 6;
            this.ctlFrom.UseParentBackColor = true;
            this.ctlFrom.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlFrom.zz_LabelFont = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlFrom.ChangeUser += new NewMethod.ChangeUserHandler(this.ctlFrom_ChangeUser);
            this.ctlFrom.ClearUser += new NewMethod.ClearUserHandler(this.ctlFrom_ClearUser);
            // 
            // lv
            // 
            this.lv.AddCaption = "Add New";
            this.lv.AllowActions = true;
            this.lv.AllowAdd = false;
            this.lv.AllowDelete = true;
            this.lv.AllowDeleteAlways = false;
            this.lv.AllowDrop = true;
            this.lv.AlternateConnection = null;
            this.lv.Caption = "";
            this.lv.CurrentTemplate = null;
            this.lv.ExtraClassInfo = "";
            this.lv.Location = new System.Drawing.Point(2, 155);
            this.lv.MultiSelect = true;
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(640, 194);
            this.lv.SuppressSelectionChanged = false;
            this.lv.TabIndex = 6;
            this.lv.zz_OpenColumnMenu = false;
            this.lv.zz_ShowAutoRefresh = true;
            this.lv.zz_ShowUnlimited = true;
            this.lv.AboutToThrow += new Core.ShowHandler(this.lv_AboutToThrow);
            // 
            // vf
            // 
            this.vf.BackColor = System.Drawing.Color.White;
            this.vf.Location = new System.Drawing.Point(3, 155);
            this.vf.Name = "vf";
            this.vf.Size = new System.Drawing.Size(632, 344);
            this.vf.TabIndex = 7;
            this.vf.CloseRequest += new System.EventHandler(this.vf_CloseRequest);
            this.vf.AboutToThrow += new Core.ShowHandler(this.vf_AboutToThrow);
            // 
            // Tasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.sp);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Tasks";
            this.Size = new System.Drawing.Size(930, 627);
            this.Resize += new System.EventHandler(this.Tasks_Resize);
            this.mnu.ResumeLayout(false);
            this.pSearch.ResumeLayout(false);
            this.pSearch.PerformLayout();
            this.sp.Panel1.ResumeLayout(false);
            this.sp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected NewMethod.nList lv;
        protected Views.ViewFolder vf;
        protected System.Windows.Forms.ContextMenuStrip mnu;
        protected System.Windows.Forms.ToolStripMenuItem newSubFolderToolStripMenuItem;
        protected System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        protected System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        protected System.Windows.Forms.Panel pSearch;
        protected System.Windows.Forms.TextBox txtSearch;
        protected System.Windows.Forms.Button cmdSearch;
        protected NewMethod.nEdit_User ctlTo;
        protected NewMethod.nEdit_User ctlFrom;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.SplitContainer sp;
        protected System.Windows.Forms.Button cmdPriorities;
        protected NewMethod.nEdit_List ctl_task_type;
        protected NewMethod.nEdit_List ctl_task_size;
        protected NewMethod.nEdit_List ctl_current_status;
        protected System.Windows.Forms.LinkLabel lblUpdateAll;
        protected System.Windows.Forms.Button cmdActivity;
    }
}
