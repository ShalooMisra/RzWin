using NewMethod;

namespace Rz5
{
    partial class WebReport_User_Date
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebReport_User_Date));
            this.gbOptions = new System.Windows.Forms.GroupBox();
            this.panelAgent = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cboAgent = new System.Windows.Forms.ComboBox();
            this.lblOrderBy = new System.Windows.Forms.Label();
            this.cboOrderBy = new System.Windows.Forms.ComboBox();
            this.cmdView = new System.Windows.Forms.Button();
            this.lblCaption = new System.Windows.Forms.Label();
            this.dtEnd = new NewMethod.nEdit_Date();
            this.dtStart = new NewMethod.nEdit_Date();
            this.ilReportImages = new System.Windows.Forms.ImageList(this.components);
            this.gb.SuspendLayout();
            this.gbOptions.SuspendLayout();
            this.panelAgent.SuspendLayout();
            this.SuspendLayout();
            // 
            // wb
            // 
            this.wb.Location = new System.Drawing.Point(0, 0);
            this.wb.Size = new System.Drawing.Size(639, 464);
            this.wb.OnNavigate += new ToolsWin.OnNavigateHandler(this.wb_OnNavigate);
            // 
            // gb
            // 
            this.gb.Location = new System.Drawing.Point(0, 464);
            this.gb.Size = new System.Drawing.Size(639, 53);
            // 
            // gbOptions
            // 
            this.gbOptions.BackColor = System.Drawing.Color.White;
            this.gbOptions.Controls.Add(this.panelAgent);
            this.gbOptions.Controls.Add(this.lblOrderBy);
            this.gbOptions.Controls.Add(this.cboOrderBy);
            this.gbOptions.Controls.Add(this.cmdView);
            this.gbOptions.Controls.Add(this.lblCaption);
            this.gbOptions.Controls.Add(this.dtEnd);
            this.gbOptions.Controls.Add(this.dtStart);
            this.gbOptions.Location = new System.Drawing.Point(21, 17);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Size = new System.Drawing.Size(193, 413);
            this.gbOptions.TabIndex = 2;
            this.gbOptions.TabStop = false;
            this.gbOptions.Text = "Options";
            // 
            // panelAgent
            // 
            this.panelAgent.Controls.Add(this.label1);
            this.panelAgent.Controls.Add(this.cboAgent);
            this.panelAgent.Location = new System.Drawing.Point(11, 128);
            this.panelAgent.Name = "panelAgent";
            this.panelAgent.Size = new System.Drawing.Size(166, 42);
            this.panelAgent.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Agent / Team";
            // 
            // cboAgent
            // 
            this.cboAgent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgent.FormattingEnabled = true;
            this.cboAgent.Location = new System.Drawing.Point(4, 17);
            this.cboAgent.Name = "cboAgent";
            this.cboAgent.Size = new System.Drawing.Size(157, 21);
            this.cboAgent.TabIndex = 10;
            this.cboAgent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboAgent_KeyPress);
            // 
            // lblOrderBy
            // 
            this.lblOrderBy.AutoSize = true;
            this.lblOrderBy.Location = new System.Drawing.Point(15, 212);
            this.lblOrderBy.Name = "lblOrderBy";
            this.lblOrderBy.Size = new System.Drawing.Size(48, 13);
            this.lblOrderBy.TabIndex = 12;
            this.lblOrderBy.Text = "Order By";
            this.lblOrderBy.Visible = false;
            // 
            // cboOrderBy
            // 
            this.cboOrderBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrderBy.FormattingEnabled = true;
            this.cboOrderBy.Location = new System.Drawing.Point(10, 230);
            this.cboOrderBy.Name = "cboOrderBy";
            this.cboOrderBy.Size = new System.Drawing.Size(170, 21);
            this.cboOrderBy.TabIndex = 11;
            this.cboOrderBy.Visible = false;
            // 
            // cmdView
            // 
            this.cmdView.Location = new System.Drawing.Point(39, 175);
            this.cmdView.Name = "cmdView";
            this.cmdView.Size = new System.Drawing.Size(113, 28);
            this.cmdView.TabIndex = 9;
            this.cmdView.Text = "View";
            this.cmdView.UseVisualStyleBackColor = true;
            this.cmdView.Click += new System.EventHandler(this.cmdView_Click);
            // 
            // lblCaption
            // 
            this.lblCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.Location = new System.Drawing.Point(15, 16);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(169, 23);
            this.lblCaption.TabIndex = 8;
            this.lblCaption.Text = "<name>";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtEnd
            // 
            this.dtEnd.AllowClear = false;
            this.dtEnd.BackColor = System.Drawing.Color.White;
            this.dtEnd.Bold = false;
            this.dtEnd.Caption = "End Date";
            this.dtEnd.Changed = false;
            this.dtEnd.Location = new System.Drawing.Point(10, 83);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(177, 41);
            this.dtEnd.SuppressEdit = false;
            this.dtEnd.TabIndex = 7;
            this.dtEnd.UseParentBackColor = true;
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
            this.dtStart.AllowClear = false;
            this.dtStart.BackColor = System.Drawing.Color.White;
            this.dtStart.Bold = false;
            this.dtStart.Caption = "Start Date";
            this.dtStart.Changed = false;
            this.dtStart.Location = new System.Drawing.Point(10, 37);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(177, 41);
            this.dtStart.SuppressEdit = false;
            this.dtStart.TabIndex = 6;
            this.dtStart.UseParentBackColor = true;
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
            // ilReportImages
            // 
            this.ilReportImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilReportImages.ImageStream")));
            this.ilReportImages.TransparentColor = System.Drawing.Color.Transparent;
            this.ilReportImages.Images.SetKeyName(0, "orange-question-mark.png");
            // 
            // WebReport_User_Date
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.gbOptions);
            this.Name = "WebReport_User_Date";
            this.Size = new System.Drawing.Size(639, 517);
            this.Controls.SetChildIndex(this.gb, 0);
            this.Controls.SetChildIndex(this.wb, 0);
            this.Controls.SetChildIndex(this.gbOptions, 0);
            this.gb.ResumeLayout(false);
            this.gbOptions.ResumeLayout(false);
            this.gbOptions.PerformLayout();
            this.panelAgent.ResumeLayout(false);
            this.panelAgent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox gbOptions;
        public System.Windows.Forms.Button cmdView;
        public System.Windows.Forms.Label lblCaption;
        public nEdit_Date dtEnd;
        public nEdit_Date dtStart;
        public System.Windows.Forms.Label lblOrderBy;
        public System.Windows.Forms.ComboBox cboOrderBy;
        public System.Windows.Forms.ComboBox cboAgent;
        protected System.Windows.Forms.Panel panelAgent;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList ilReportImages;
    }
}
