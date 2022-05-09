namespace Rz5
{
    partial class CommissionReportScreen
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbOptions.SuspendLayout();
            this.panelAgent.SuspendLayout();
            this.gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbOptions
            // 
            this.gbOptions.Controls.Add(this.groupBox1);
            this.gbOptions.Controls.SetChildIndex(this.dtStart, 0);
            this.gbOptions.Controls.SetChildIndex(this.dtEnd, 0);
            this.gbOptions.Controls.SetChildIndex(this.lblCaption, 0);
            this.gbOptions.Controls.SetChildIndex(this.cmdView, 0);
            this.gbOptions.Controls.SetChildIndex(this.cboOrderBy, 0);
            this.gbOptions.Controls.SetChildIndex(this.lblOrderBy, 0);
            this.gbOptions.Controls.SetChildIndex(this.panelAgent, 0);
            this.gbOptions.Controls.SetChildIndex(this.groupBox1, 0);
            // 
            // wb
            // 
            this.wb.OnNavigate += new ToolsWin.OnNavigateHandler(this.wb_OnNavigate);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(10, 273);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(174, 100);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Links";
            // 
            // CommissionReportScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CommissionReportScreen";
            this.gbOptions.ResumeLayout(false);
            this.gbOptions.PerformLayout();
            this.panelAgent.ResumeLayout(false);
            this.panelAgent.PerformLayout();
            this.gb.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
    }
}
