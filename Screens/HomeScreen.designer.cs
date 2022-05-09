using NewMethod;

namespace Rz5
{
    partial class HomeScreen
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
            this.tv = new System.Windows.Forms.TreeView();
            this.lv = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.gbNSN = new System.Windows.Forms.GroupBox();
            this.txtNSNEnd = new NewMethod.nEdit_List();
            this.txtNSNStart = new NewMethod.nEdit_List();
            this.cmdSearchNSN = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.lstDetails = new NewMethod.nList();
            this.ctl_EndDate = new NewMethod.nEdit_Date();
            this.ctl_StartDate = new NewMethod.nEdit_Date();
            this.lst = new NewMethod.nList();
            this.gbNSN.SuspendLayout();
            this.SuspendLayout();
            // 
            // tv
            // 
            this.tv.Location = new System.Drawing.Point(3, 5);
            this.tv.Name = "tv";
            this.tv.Size = new System.Drawing.Size(203, 215);
            this.tv.TabIndex = 0;
            this.tv.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv_NodeMouseClick);
            this.tv.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tv_MouseDown);
            // 
            // lv
            // 
            this.lv.CheckBoxes = true;
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lv.Location = new System.Drawing.Point(3, 226);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(203, 149);
            this.lv.TabIndex = 2;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Agent";
            this.columnHeader1.Width = 177;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Location = new System.Drawing.Point(3, 380);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(203, 27);
            this.cmdRefresh.TabIndex = 3;
            this.cmdRefresh.Text = "Refresh";
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // gbNSN
            // 
            this.gbNSN.Controls.Add(this.txtNSNEnd);
            this.gbNSN.Controls.Add(this.txtNSNStart);
            this.gbNSN.Controls.Add(this.cmdSearchNSN);
            this.gbNSN.Location = new System.Drawing.Point(3, 413);
            this.gbNSN.Name = "gbNSN";
            this.gbNSN.Size = new System.Drawing.Size(447, 70);
            this.gbNSN.TabIndex = 44;
            this.gbNSN.TabStop = false;
            this.gbNSN.Text = "NSN Prefix Search";
            this.gbNSN.Visible = false;
            // 
            // txtNSNEnd
            // 
            this.txtNSNEnd.AllCaps = false;
            this.txtNSNEnd.AllowEdit = false;
            this.txtNSNEnd.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtNSNEnd.Bold = false;
            this.txtNSNEnd.Caption = "End NSN Range";
            this.txtNSNEnd.Changed = false;
            this.txtNSNEnd.ListName = null;
            this.txtNSNEnd.Location = new System.Drawing.Point(160, 16);
            this.txtNSNEnd.Name = "txtNSNEnd";
            this.txtNSNEnd.SimpleList = null;
            this.txtNSNEnd.Size = new System.Drawing.Size(151, 48);
            this.txtNSNEnd.TabIndex = 4;
            this.txtNSNEnd.UseParentBackColor = false;
            this.txtNSNEnd.zz_GlobalColor = System.Drawing.Color.Black;
            this.txtNSNEnd.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNSNEnd.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.txtNSNEnd.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNSNEnd.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.txtNSNEnd.zz_OriginalDesign = false;
            this.txtNSNEnd.zz_ShowNeedsSaveColor = true;
            this.txtNSNEnd.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.txtNSNEnd.zz_TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNSNEnd.zz_UseGlobalColor = false;
            this.txtNSNEnd.zz_UseGlobalFont = false;
            // 
            // txtNSNStart
            // 
            this.txtNSNStart.AllCaps = false;
            this.txtNSNStart.AllowEdit = false;
            this.txtNSNStart.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtNSNStart.Bold = false;
            this.txtNSNStart.Caption = "Start NSN Range";
            this.txtNSNStart.Changed = false;
            this.txtNSNStart.ListName = null;
            this.txtNSNStart.Location = new System.Drawing.Point(6, 16);
            this.txtNSNStart.Name = "txtNSNStart";
            this.txtNSNStart.SimpleList = null;
            this.txtNSNStart.Size = new System.Drawing.Size(151, 48);
            this.txtNSNStart.TabIndex = 3;
            this.txtNSNStart.UseParentBackColor = false;
            this.txtNSNStart.zz_GlobalColor = System.Drawing.Color.Black;
            this.txtNSNStart.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNSNStart.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.txtNSNStart.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNSNStart.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.txtNSNStart.zz_OriginalDesign = false;
            this.txtNSNStart.zz_ShowNeedsSaveColor = true;
            this.txtNSNStart.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.txtNSNStart.zz_TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNSNStart.zz_UseGlobalColor = false;
            this.txtNSNStart.zz_UseGlobalFont = false;
            // 
            // cmdSearchNSN
            // 
            this.cmdSearchNSN.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSearchNSN.Location = new System.Drawing.Point(313, 19);
            this.cmdSearchNSN.Name = "cmdSearchNSN";
            this.cmdSearchNSN.Size = new System.Drawing.Size(128, 47);
            this.cmdSearchNSN.TabIndex = 2;
            this.cmdSearchNSN.Text = "Search";
            this.cmdSearchNSN.UseVisualStyleBackColor = true;
            this.cmdSearchNSN.Click += new System.EventHandler(this.cmdSearchNSN_Click);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAll.Location = new System.Drawing.Point(3, 225);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(43, 19);
            this.chkAll.TabIndex = 45;
            this.chkAll.Text = "All";
            this.chkAll.UseVisualStyleBackColor = true;
            // 
            // lstDetails
            // 
            this.lstDetails.AddCaption = "Add New";
            this.lstDetails.AllowActions = true;
            this.lstDetails.AllowAdd = false;
            this.lstDetails.AllowDelete = true;
            this.lstDetails.AllowDeleteAlways = false;
            this.lstDetails.AllowDrop = true;
            this.lstDetails.AlternateConnection = null;
            this.lstDetails.Caption = "";
            this.lstDetails.CurrentTemplate = null;
            this.lstDetails.ExtraClassInfo = "";
            this.lstDetails.Location = new System.Drawing.Point(212, 225);
            this.lstDetails.MultiSelect = true;
            this.lstDetails.Name = "lstDetails";
            this.lstDetails.Size = new System.Drawing.Size(233, 118);
            this.lstDetails.SuppressSelectionChanged = false;
            this.lstDetails.TabIndex = 43;
            this.lstDetails.Visible = false;
            this.lstDetails.zz_OpenColumnMenu = false;
            this.lstDetails.zz_ShowAutoRefresh = true;
            this.lstDetails.zz_ShowUnlimited = true;
            // 
            // ctl_EndDate
            // 
            this.ctl_EndDate.AllowClear = true;
            this.ctl_EndDate.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_EndDate.Bold = false;
            this.ctl_EndDate.Caption = "End Date  ";
            this.ctl_EndDate.Changed = false;
            this.ctl_EndDate.Location = new System.Drawing.Point(247, 378);
            this.ctl_EndDate.Name = "ctl_EndDate";
            this.ctl_EndDate.Size = new System.Drawing.Size(203, 26);
            this.ctl_EndDate.SuppressEdit = false;
            this.ctl_EndDate.TabIndex = 42;
            this.ctl_EndDate.UseParentBackColor = false;
            this.ctl_EndDate.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_EndDate.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_EndDate.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_EndDate.zz_LabelFont = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_EndDate.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.Left;
            this.ctl_EndDate.zz_OriginalDesign = false;
            this.ctl_EndDate.zz_ShowNeedsSaveColor = false;
            this.ctl_EndDate.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_EndDate.zz_TextFont = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_EndDate.zz_UseGlobalColor = false;
            this.ctl_EndDate.zz_UseGlobalFont = false;
            // 
            // ctl_StartDate
            // 
            this.ctl_StartDate.AllowClear = true;
            this.ctl_StartDate.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_StartDate.Bold = false;
            this.ctl_StartDate.Caption = "Start Date ";
            this.ctl_StartDate.Changed = false;
            this.ctl_StartDate.Location = new System.Drawing.Point(247, 349);
            this.ctl_StartDate.Name = "ctl_StartDate";
            this.ctl_StartDate.Size = new System.Drawing.Size(203, 26);
            this.ctl_StartDate.SuppressEdit = false;
            this.ctl_StartDate.TabIndex = 41;
            this.ctl_StartDate.UseParentBackColor = false;
            this.ctl_StartDate.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_StartDate.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_StartDate.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_StartDate.zz_LabelFont = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_StartDate.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.Left;
            this.ctl_StartDate.zz_OriginalDesign = false;
            this.ctl_StartDate.zz_ShowNeedsSaveColor = false;
            this.ctl_StartDate.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_StartDate.zz_TextFont = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_StartDate.zz_UseGlobalColor = false;
            this.ctl_StartDate.zz_UseGlobalFont = false;
            // 
            // lst
            // 
            this.lst.AddCaption = "Add New";
            this.lst.AllowActions = true;
            this.lst.AllowAdd = false;
            this.lst.AllowDelete = true;
            this.lst.AllowDeleteAlways = false;
            this.lst.AllowDrop = true;
            this.lst.AlternateConnection = null;
            this.lst.Caption = "";
            this.lst.CurrentTemplate = null;
            this.lst.ExtraClassInfo = "";
            this.lst.Location = new System.Drawing.Point(212, 68);
            this.lst.MultiSelect = true;
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(233, 152);
            this.lst.SuppressSelectionChanged = false;
            this.lst.TabIndex = 1;
            this.lst.zz_OpenColumnMenu = false;
            this.lst.zz_ShowAutoRefresh = true;
            this.lst.zz_ShowUnlimited = true;
            // 
            // HomeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.gbNSN);
            this.Controls.Add(this.lstDetails);
            this.Controls.Add(this.ctl_EndDate);
            this.Controls.Add(this.ctl_StartDate);
            this.Controls.Add(this.cmdRefresh);
            this.Controls.Add(this.lv);
            this.Controls.Add(this.lst);
            this.Controls.Add(this.tv);
            this.Name = "HomeScreen";
            this.Size = new System.Drawing.Size(815, 606);
            this.Resize += new System.EventHandler(this.HomeScreen_Resize);
            this.gbNSN.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tv;
        private nList lst;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button cmdRefresh;
        private nEdit_Date ctl_StartDate;
        private nEdit_Date ctl_EndDate;
        private nList lstDetails;
        private System.Windows.Forms.GroupBox gbNSN;
        private System.Windows.Forms.Button cmdSearchNSN;
        private nEdit_List txtNSNEnd;
        private nEdit_List txtNSNStart;
        private System.Windows.Forms.CheckBox chkAll;
        public System.Windows.Forms.ListView lv;

    }
}
