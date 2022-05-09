namespace RzSensible
{
    partial class frmChooseIndustry
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
            this.ctl_industry_segment = new NewMethod.nEdit_List();
            this.cmdSelect = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctl_industry_segment
            // 
            this.ctl_industry_segment.AllCaps = false;
            this.ctl_industry_segment.AllowEdit = true;
            this.ctl_industry_segment.BackColor = System.Drawing.Color.Transparent;
            this.ctl_industry_segment.Bold = false;
            this.ctl_industry_segment.Caption = "Industry Segment";
            this.ctl_industry_segment.Changed = false;
            this.ctl_industry_segment.ListName = "industry_segment";
            this.ctl_industry_segment.Location = new System.Drawing.Point(2, 2);
            this.ctl_industry_segment.Name = "ctl_industry_segment";
            this.ctl_industry_segment.SimpleList = null;
            this.ctl_industry_segment.Size = new System.Drawing.Size(234, 53);
            this.ctl_industry_segment.TabIndex = 40;
            this.ctl_industry_segment.UseParentBackColor = true;
            this.ctl_industry_segment.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_industry_segment.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_industry_segment.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_industry_segment.zz_LabelFont = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_industry_segment.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_industry_segment.zz_OriginalDesign = false;
            this.ctl_industry_segment.zz_ShowNeedsSaveColor = true;
            this.ctl_industry_segment.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_industry_segment.zz_TextFont = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_industry_segment.zz_UseGlobalColor = false;
            this.ctl_industry_segment.zz_UseGlobalFont = false;
            // 
            // cmdSelect
            // 
            this.cmdSelect.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSelect.Location = new System.Drawing.Point(121, 61);
            this.cmdSelect.Name = "cmdSelect";
            this.cmdSelect.Size = new System.Drawing.Size(115, 28);
            this.cmdSelect.TabIndex = 41;
            this.cmdSelect.Text = "Select";
            this.cmdSelect.UseVisualStyleBackColor = true;
            this.cmdSelect.Click += new System.EventHandler(this.cmdSelect_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Location = new System.Drawing.Point(2, 61);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(115, 28);
            this.cmdCancel.TabIndex = 42;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmChooseIndustry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 96);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSelect);
            this.Controls.Add(this.ctl_industry_segment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmChooseIndustry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose Industry Segment";
            this.ResumeLayout(false);

        }

        #endregion

        private NewMethod.nEdit_List ctl_industry_segment;
        private System.Windows.Forms.Button cmdSelect;
        private System.Windows.Forms.Button cmdCancel;
    }
}