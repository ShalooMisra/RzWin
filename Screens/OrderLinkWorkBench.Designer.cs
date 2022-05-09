namespace Rz5.Win.Screens
{
    partial class OrderLinkWorkBench
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
            this.gbOptions = new System.Windows.Forms.GroupBox();
            this.dtEnd = new NewMethod.nEdit_Date();
            this.dtStart = new NewMethod.nEdit_Date();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.lv = new NewMethod.nList();
            this.ctl_Agent = new NewMethod.nEdit_User();
            this.gbOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbOptions
            // 
            this.gbOptions.Controls.Add(this.ctl_Agent);
            this.gbOptions.Controls.Add(this.cmdSearch);
            this.gbOptions.Controls.Add(this.dtEnd);
            this.gbOptions.Controls.Add(this.dtStart);
            this.gbOptions.Location = new System.Drawing.Point(7, 0);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Size = new System.Drawing.Size(182, 311);
            this.gbOptions.TabIndex = 0;
            this.gbOptions.TabStop = false;
            // 
            // dtEnd
            // 
            this.dtEnd.AllowClear = true;
            this.dtEnd.BackColor = System.Drawing.Color.White;
            this.dtEnd.Bold = false;
            this.dtEnd.Caption = "Order Date (End)";
            this.dtEnd.Changed = false;
            this.dtEnd.Location = new System.Drawing.Point(6, 160);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(108, 53);
            this.dtEnd.SuppressEdit = false;
            this.dtEnd.TabIndex = 4;
            this.dtEnd.UseParentBackColor = false;
            this.dtEnd.zz_GlobalColor = System.Drawing.Color.Black;
            this.dtEnd.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dtEnd.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.dtEnd.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtEnd.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.dtEnd.zz_OriginalDesign = true;
            this.dtEnd.zz_ShowNeedsSaveColor = true;
            this.dtEnd.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.dtEnd.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEnd.zz_UseGlobalColor = false;
            this.dtEnd.zz_UseGlobalFont = false;
            // 
            // dtStart
            // 
            this.dtStart.AllowClear = true;
            this.dtStart.BackColor = System.Drawing.Color.White;
            this.dtStart.Bold = false;
            this.dtStart.Caption = "Order Date (Start)";
            this.dtStart.Changed = false;
            this.dtStart.Location = new System.Drawing.Point(6, 92);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(108, 53);
            this.dtStart.SuppressEdit = false;
            this.dtStart.TabIndex = 5;
            this.dtStart.UseParentBackColor = false;
            this.dtStart.zz_GlobalColor = System.Drawing.Color.Black;
            this.dtStart.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dtStart.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.dtStart.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtStart.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.dtStart.zz_OriginalDesign = true;
            this.dtStart.zz_ShowNeedsSaveColor = true;
            this.dtStart.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.dtStart.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStart.zz_UseGlobalColor = false;
            this.dtStart.zz_UseGlobalFont = false;
            // 
            // cmdSearch
            // 
            this.cmdSearch.Location = new System.Drawing.Point(5, 12);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(172, 64);
            this.cmdSearch.TabIndex = 6;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
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
            this.lv.Location = new System.Drawing.Point(195, 7);
            this.lv.MultiSelect = true;
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(658, 304);
            this.lv.SuppressSelectionChanged = false;
            this.lv.TabIndex = 1;
            this.lv.zz_OpenColumnMenu = false;
            this.lv.zz_ShowAutoRefresh = true;
            this.lv.zz_ShowUnlimited = true;
            // 
            // ctl_Agent
            // 
            this.ctl_Agent.AllowChange = true;
            this.ctl_Agent.AllowClear = true;
            this.ctl_Agent.AllowNew = false;
            this.ctl_Agent.AllowView = false;
            this.ctl_Agent.BackColor = System.Drawing.Color.White;
            this.ctl_Agent.Bold = false;
            this.ctl_Agent.Caption = "Agent";
            this.ctl_Agent.Changed = false;
            this.ctl_Agent.Location = new System.Drawing.Point(6, 231);
            this.ctl_Agent.Name = "ctl_Agent";
            this.ctl_Agent.Size = new System.Drawing.Size(169, 51);
            this.ctl_Agent.TabIndex = 15;
            this.ctl_Agent.UseParentBackColor = false;
            this.ctl_Agent.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_Agent.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_Agent.ChangeUser += new NewMethod.ChangeUserHandler(this.ctl_Agent_ChangeUser);
            this.ctl_Agent.ClearUser += new NewMethod.ClearUserHandler(this.ctl_Agent_ClearUser);
            // 
            // OrderLinkWorkBench
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lv);
            this.Controls.Add(this.gbOptions);
            this.Name = "OrderLinkWorkBench";
            this.Size = new System.Drawing.Size(908, 615);
            this.Resize += new System.EventHandler(this.OrderLinkWorkBench_Resize);
            this.gbOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbOptions;
        private System.Windows.Forms.Button cmdSearch;
        private NewMethod.nEdit_Date dtEnd;
        private NewMethod.nEdit_Date dtStart;
        private NewMethod.nList lv;
        private NewMethod.nEdit_User ctl_Agent;
    }
}
