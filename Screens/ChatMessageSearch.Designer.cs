namespace Rz5
{
    partial class ChatMessageSearch
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
            this.lv = new NewMethod.nList();
            this.ctl_search = new NewMethod.nEdit_String();
            this.gbOptions.SuspendLayout();
            this.panelAgent.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbOptions
            // 
            this.gbOptions.Controls.Add(this.ctl_search);
            this.gbOptions.Size = new System.Drawing.Size(193, 573);
            this.gbOptions.Controls.SetChildIndex(this.cmdView, 0);
            this.gbOptions.Controls.SetChildIndex(this.ctl_search, 0);
            this.gbOptions.Controls.SetChildIndex(this.lblOrderBy, 0);
            this.gbOptions.Controls.SetChildIndex(this.cboOrderBy, 0);
            this.gbOptions.Controls.SetChildIndex(this.dtStart, 0);
            this.gbOptions.Controls.SetChildIndex(this.dtEnd, 0);
            this.gbOptions.Controls.SetChildIndex(this.lblCaption, 0);
            this.gbOptions.Controls.SetChildIndex(this.panelAgent, 0);
            // 
            // cmdView
            // 
            this.cmdView.Location = new System.Drawing.Point(11, 217);
            this.cmdView.Size = new System.Drawing.Size(166, 28);
            // 
            // dtEnd
            // 
            this.dtEnd.Size = new System.Drawing.Size(177, 35);
            this.dtEnd.zz_OriginalDesign = false;
            this.dtEnd.zz_ShowNeedsSaveColor = false;
            // 
            // dtStart
            // 
            this.dtStart.Size = new System.Drawing.Size(177, 35);
            this.dtStart.zz_OriginalDesign = false;
            this.dtStart.zz_ShowNeedsSaveColor = false;
            // 
            // lblOrderBy
            // 
            this.lblOrderBy.Location = new System.Drawing.Point(12, 355);
            // 
            // cboOrderBy
            // 
            this.cboOrderBy.Location = new System.Drawing.Point(11, 381);
            // 
            // wb
            // 
            this.wb.Size = new System.Drawing.Size(603, 520);
            // 
            // gb
            // 
            this.gb.Location = new System.Drawing.Point(193, 520);
            this.gb.Size = new System.Drawing.Size(603, 53);
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
            this.lv.Location = new System.Drawing.Point(212, 16);
            this.lv.MultiSelect = true;
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(564, 489);
            this.lv.SuppressSelectionChanged = false;
            this.lv.TabIndex = 4;
            this.lv.zz_OpenColumnMenu = false;
            this.lv.zz_ShowAutoRefresh = true;
            this.lv.zz_ShowUnlimited = true;
            // 
            // ctl_search
            // 
            this.ctl_search.AllCaps = false;
            this.ctl_search.BackColor = System.Drawing.Color.Transparent;
            this.ctl_search.Bold = false;
            this.ctl_search.Caption = "Search Text";
            this.ctl_search.Changed = false;
            this.ctl_search.IsEmail = false;
            this.ctl_search.IsURL = false;
            this.ctl_search.Location = new System.Drawing.Point(11, 175);
            this.ctl_search.Name = "ctl_search";
            this.ctl_search.PasswordChar = '\0';
            this.ctl_search.Size = new System.Drawing.Size(166, 35);
            this.ctl_search.TabIndex = 14;
            this.ctl_search.UseParentBackColor = false;
            this.ctl_search.zz_Enabled = true;
            this.ctl_search.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_search.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_search.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_search.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_search.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_search.zz_OriginalDesign = false;
            this.ctl_search.zz_ShowLinkButton = false;
            this.ctl_search.zz_ShowNeedsSaveColor = false;
            this.ctl_search.zz_Text = "";
            this.ctl_search.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_search.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_search.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_search.zz_UseGlobalColor = false;
            this.ctl_search.zz_UseGlobalFont = false;
            // 
            // ChatMessageSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lv);
            this.Name = "ChatMessageSearch";
            this.Size = new System.Drawing.Size(796, 573);
            this.Controls.SetChildIndex(this.wb, 0);
            this.Controls.SetChildIndex(this.gb, 0);
            this.Controls.SetChildIndex(this.gbOptions, 0);
            this.Controls.SetChildIndex(this.lv, 0);
            this.gbOptions.ResumeLayout(false);
            this.gbOptions.PerformLayout();
            this.panelAgent.ResumeLayout(false);
            this.panelAgent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private NewMethod.nList lv;
        private NewMethod.nEdit_String ctl_search;
    }
}
