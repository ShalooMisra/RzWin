namespace Rz5.Reports
{
    partial class ConsignmentReport
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsignmentReport));
            this.cboSuppliers = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdPDF = new System.Windows.Forms.Button();
            this.cmdPO = new System.Windows.Forms.Button();
            this.lblDateParameter = new System.Windows.Forms.Label();
            this.cboViewBy = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pbHelp = new System.Windows.Forms.PictureBox();
            this.lblViewBy = new System.Windows.Forms.Label();
            this.ilReportImages = new System.Windows.Forms.ImageList(this.components);
            this.gbOptions.SuspendLayout();
            this.panelAgent.SuspendLayout();
            this.gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp)).BeginInit();
            this.SuspendLayout();
            // 
            // gbOptions
            // 
            this.gbOptions.Controls.Add(this.pbHelp);
            this.gbOptions.Controls.Add(this.lblViewBy);
            this.gbOptions.Controls.Add(this.cboViewBy);
            this.gbOptions.Controls.Add(this.lblDateParameter);
            this.gbOptions.Controls.Add(this.cmdPO);
            this.gbOptions.Controls.Add(this.cboSuppliers);
            this.gbOptions.Controls.Add(this.label2);
            this.gbOptions.Controls.SetChildIndex(this.label2, 0);
            this.gbOptions.Controls.SetChildIndex(this.cboSuppliers, 0);
            this.gbOptions.Controls.SetChildIndex(this.cmdPO, 0);
            this.gbOptions.Controls.SetChildIndex(this.lblDateParameter, 0);
            this.gbOptions.Controls.SetChildIndex(this.cboViewBy, 0);
            this.gbOptions.Controls.SetChildIndex(this.lblViewBy, 0);
            this.gbOptions.Controls.SetChildIndex(this.pbHelp, 0);
            this.gbOptions.Controls.SetChildIndex(this.cmdView, 0);
            this.gbOptions.Controls.SetChildIndex(this.lblOrderBy, 0);
            this.gbOptions.Controls.SetChildIndex(this.cboOrderBy, 0);
            this.gbOptions.Controls.SetChildIndex(this.panelAgent, 0);
            this.gbOptions.Controls.SetChildIndex(this.dtStart, 0);
            this.gbOptions.Controls.SetChildIndex(this.dtEnd, 0);
            this.gbOptions.Controls.SetChildIndex(this.lblCaption, 0);
            // 
            // cmdView
            // 
            this.cmdView.Location = new System.Drawing.Point(10, 226);
            this.cmdView.Size = new System.Drawing.Size(177, 28);
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
            this.lblOrderBy.Location = new System.Drawing.Point(18, 433);
            // 
            // cboOrderBy
            // 
            this.cboOrderBy.Location = new System.Drawing.Point(10, 391);
            // 
            // panelAgent
            // 
            this.panelAgent.Location = new System.Drawing.Point(14, 343);
            this.panelAgent.Visible = false;
            // 
            // wb
            // 
            this.wb.Size = new System.Drawing.Size(863, 464);
            this.wb.OnNavigate += new ToolsWin.OnNavigateHandler(this.wb_OnNavigate);
            // 
            // gb
            // 
            this.gb.Controls.Add(this.cmdPDF);
            this.gb.Size = new System.Drawing.Size(863, 53);
            this.gb.Controls.SetChildIndex(this.cmdPDF, 0);
            this.gb.Controls.SetChildIndex(this.cmdExport, 0);
            // 
            // cboSuppliers
            // 
            this.cboSuppliers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSuppliers.FormattingEnabled = true;
            this.cboSuppliers.Location = new System.Drawing.Point(10, 199);
            this.cboSuppliers.Name = "cboSuppliers";
            this.cboSuppliers.Size = new System.Drawing.Size(177, 21);
            this.cboSuppliers.TabIndex = 14;
            this.cboSuppliers.SelectedIndexChanged += new System.EventHandler(this.cboSuppliers_SelectedIndexChanged);
            this.cboSuppliers.SelectedValueChanged += new System.EventHandler(this.cboSuppliers_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Consignment Suppliers";
            // 
            // cmdPDF
            // 
            this.cmdPDF.Location = new System.Drawing.Point(483, 11);
            this.cmdPDF.Name = "cmdPDF";
            this.cmdPDF.Size = new System.Drawing.Size(75, 19);
            this.cmdPDF.TabIndex = 8;
            this.cmdPDF.Text = "PDF";
            this.cmdPDF.UseVisualStyleBackColor = true;
            this.cmdPDF.Visible = false;
            this.cmdPDF.Click += new System.EventHandler(this.cmdPDF_Click);
            // 
            // cmdPO
            // 
            this.cmdPO.Location = new System.Drawing.Point(10, 260);
            this.cmdPO.Name = "cmdPO";
            this.cmdPO.Size = new System.Drawing.Size(177, 31);
            this.cmdPO.TabIndex = 16;
            this.cmdPO.Text = "Send To Purchase Order";
            this.cmdPO.UseVisualStyleBackColor = true;
            this.cmdPO.Click += new System.EventHandler(this.cmdPO_Click);
            // 
            // lblDateParameter
            // 
            this.lblDateParameter.AutoSize = true;
            this.lblDateParameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateParameter.Location = new System.Drawing.Point(57, 136);
            this.lblDateParameter.Name = "lblDateParameter";
            this.lblDateParameter.Size = new System.Drawing.Size(72, 13);
            this.lblDateParameter.TabIndex = 19;
            this.lblDateParameter.Text = "<date param>";
            // 
            // cboViewBy
            // 
            this.cboViewBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboViewBy.FormattingEnabled = true;
            this.cboViewBy.Location = new System.Drawing.Point(10, 151);
            this.cboViewBy.Name = "cboViewBy";
            this.cboViewBy.Size = new System.Drawing.Size(177, 21);
            this.cboViewBy.TabIndex = 20;
            this.cboViewBy.SelectedIndexChanged += new System.EventHandler(this.cboViewBy_SelectedIndexChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 0;
            this.toolTip1.AutoPopDelay = 0;
            this.toolTip1.InitialDelay = 0;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 0;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "\"View By\" Description:";
            // 
            // pbHelp
            // 
            this.pbHelp.Location = new System.Drawing.Point(170, 131);
            this.pbHelp.Name = "pbHelp";
            this.pbHelp.Size = new System.Drawing.Size(16, 16);
            this.pbHelp.TabIndex = 3;
            this.pbHelp.TabStop = false;
            this.toolTip1.SetToolTip(this.pbHelp, "Help!!");
            this.pbHelp.MouseHover += new System.EventHandler(this.pbHelp_MouseHover);
            // 
            // lblViewBy
            // 
            this.lblViewBy.AutoSize = true;
            this.lblViewBy.Location = new System.Drawing.Point(7, 136);
            this.lblViewBy.Name = "lblViewBy";
            this.lblViewBy.Size = new System.Drawing.Size(45, 13);
            this.lblViewBy.TabIndex = 21;
            this.lblViewBy.Text = "View By";
            // 
            // ilReportImages
            // 
            this.ilReportImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilReportImages.ImageStream")));
            this.ilReportImages.TransparentColor = System.Drawing.Color.Transparent;
            this.ilReportImages.Images.SetKeyName(0, "orange-question-mark.png");
            // 
            // ConsignmentReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ConsignmentReport";
            this.Size = new System.Drawing.Size(1056, 517);
            this.gbOptions.ResumeLayout(false);
            this.gbOptions.PerformLayout();
            this.panelAgent.ResumeLayout(false);
            this.panelAgent.PerformLayout();
            this.gb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSuppliers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdPDF;
        private System.Windows.Forms.Button cmdPO;
        private System.Windows.Forms.Label lblDateParameter;
        private System.Windows.Forms.ComboBox cboViewBy;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblViewBy;
        private System.Windows.Forms.ImageList ilReportImages;
        private System.Windows.Forms.PictureBox pbHelp;
    }
}
