namespace Rz5
{
    partial class RzReports
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
            this.gbReports = new System.Windows.Forms.GroupBox();
            this.optReqsByAgent = new System.Windows.Forms.RadioButton();
            this.optQuotesByAgent = new System.Windows.Forms.RadioButton();
            this.optInvoiceByAgent = new System.Windows.Forms.RadioButton();
            this.optTopCusts = new System.Windows.Forms.RadioButton();
            this.optTopVendors = new System.Windows.Forms.RadioButton();
            this.optTopHotParts = new System.Windows.Forms.RadioButton();
            this.gbOptions.SuspendLayout();
            this.panelAgent.SuspendLayout();
            this.gb.SuspendLayout();
            this.gbReports.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbOptions
            // 
            this.gbOptions.Controls.Add(this.gbReports);
            this.gbOptions.Controls.SetChildIndex(this.cmdView, 0);
            this.gbOptions.Controls.SetChildIndex(this.gbReports, 0);
            this.gbOptions.Controls.SetChildIndex(this.dtStart, 0);
            this.gbOptions.Controls.SetChildIndex(this.dtEnd, 0);
            this.gbOptions.Controls.SetChildIndex(this.lblCaption, 0);
            this.gbOptions.Controls.SetChildIndex(this.cboOrderBy, 0);
            this.gbOptions.Controls.SetChildIndex(this.lblOrderBy, 0);
            this.gbOptions.Controls.SetChildIndex(this.panelAgent, 0);
            // 
            // cmdView
            // 
            this.cmdView.Location = new System.Drawing.Point(10, 376);
            this.cmdView.Size = new System.Drawing.Size(174, 28);
            // 
            // dtEnd
            // 
            this.dtEnd.zz_OriginalDesign = false;
            // 
            // dtStart
            // 
            this.dtStart.zz_OriginalDesign = false;
            // 
            // lblOrderBy
            // 
            this.lblOrderBy.Location = new System.Drawing.Point(207, 168);
            // 
            // cboOrderBy
            // 
            this.cboOrderBy.Location = new System.Drawing.Point(202, 186);
            // 
            // cboAgent
            // 
            this.cboAgent.Size = new System.Drawing.Size(166, 21);
            // 
            // panelAgent
            // 
            this.panelAgent.Location = new System.Drawing.Point(10, 127);
            this.panelAgent.Size = new System.Drawing.Size(174, 42);
            // 
            // gbReports
            // 
            this.gbReports.Controls.Add(this.optTopHotParts);
            this.gbReports.Controls.Add(this.optTopVendors);
            this.gbReports.Controls.Add(this.optTopCusts);
            this.gbReports.Controls.Add(this.optInvoiceByAgent);
            this.gbReports.Controls.Add(this.optQuotesByAgent);
            this.gbReports.Controls.Add(this.optReqsByAgent);
            this.gbReports.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbReports.Location = new System.Drawing.Point(10, 172);
            this.gbReports.Name = "gbReports";
            this.gbReports.Size = new System.Drawing.Size(174, 198);
            this.gbReports.TabIndex = 14;
            this.gbReports.TabStop = false;
            this.gbReports.Text = "All Reports";
            // 
            // optReqsByAgent
            // 
            this.optReqsByAgent.AutoSize = true;
            this.optReqsByAgent.Checked = true;
            this.optReqsByAgent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.optReqsByAgent.Location = new System.Drawing.Point(10, 25);
            this.optReqsByAgent.Name = "optReqsByAgent";
            this.optReqsByAgent.Size = new System.Drawing.Size(128, 23);
            this.optReqsByAgent.TabIndex = 0;
            this.optReqsByAgent.TabStop = true;
            this.optReqsByAgent.Text = "Reqs By Agent";
            this.optReqsByAgent.UseVisualStyleBackColor = true;
            // 
            // optQuotesByAgent
            // 
            this.optQuotesByAgent.AutoSize = true;
            this.optQuotesByAgent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.optQuotesByAgent.Location = new System.Drawing.Point(10, 54);
            this.optQuotesByAgent.Name = "optQuotesByAgent";
            this.optQuotesByAgent.Size = new System.Drawing.Size(141, 23);
            this.optQuotesByAgent.TabIndex = 1;
            this.optQuotesByAgent.TabStop = true;
            this.optQuotesByAgent.Text = "Quotes By Agent";
            this.optQuotesByAgent.UseVisualStyleBackColor = true;
            // 
            // optInvoiceByAgent
            // 
            this.optInvoiceByAgent.AutoSize = true;
            this.optInvoiceByAgent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.optInvoiceByAgent.Location = new System.Drawing.Point(10, 83);
            this.optInvoiceByAgent.Name = "optInvoiceByAgent";
            this.optInvoiceByAgent.Size = new System.Drawing.Size(149, 23);
            this.optInvoiceByAgent.TabIndex = 2;
            this.optInvoiceByAgent.TabStop = true;
            this.optInvoiceByAgent.Text = "Invoices By Agent";
            this.optInvoiceByAgent.UseVisualStyleBackColor = true;
            // 
            // optTopCusts
            // 
            this.optTopCusts.AutoSize = true;
            this.optTopCusts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.optTopCusts.Location = new System.Drawing.Point(10, 112);
            this.optTopCusts.Name = "optTopCusts";
            this.optTopCusts.Size = new System.Drawing.Size(140, 23);
            this.optTopCusts.TabIndex = 3;
            this.optTopCusts.TabStop = true;
            this.optTopCusts.Text = "Top 5 Customers";
            this.optTopCusts.UseVisualStyleBackColor = true;
            // 
            // optTopVendors
            // 
            this.optTopVendors.AutoSize = true;
            this.optTopVendors.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.optTopVendors.Location = new System.Drawing.Point(10, 141);
            this.optTopVendors.Name = "optTopVendors";
            this.optTopVendors.Size = new System.Drawing.Size(123, 23);
            this.optTopVendors.TabIndex = 4;
            this.optTopVendors.TabStop = true;
            this.optTopVendors.Text = "Top 5 Vendors";
            this.optTopVendors.UseVisualStyleBackColor = true;
            // 
            // optTopHotParts
            // 
            this.optTopHotParts.AutoSize = true;
            this.optTopHotParts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.optTopHotParts.Location = new System.Drawing.Point(10, 169);
            this.optTopHotParts.Name = "optTopHotParts";
            this.optTopHotParts.Size = new System.Drawing.Size(132, 23);
            this.optTopHotParts.TabIndex = 5;
            this.optTopHotParts.TabStop = true;
            this.optTopHotParts.Text = "Top 5 Hot Parts";
            this.optTopHotParts.UseVisualStyleBackColor = true;
            // 
            // RzReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "RzReports";
            this.gbOptions.ResumeLayout(false);
            this.gbOptions.PerformLayout();
            this.panelAgent.ResumeLayout(false);
            this.panelAgent.PerformLayout();
            this.gb.ResumeLayout(false);
            this.gbReports.ResumeLayout(false);
            this.gbReports.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbReports;
        private System.Windows.Forms.RadioButton optTopHotParts;
        private System.Windows.Forms.RadioButton optTopVendors;
        private System.Windows.Forms.RadioButton optTopCusts;
        private System.Windows.Forms.RadioButton optInvoiceByAgent;
        private System.Windows.Forms.RadioButton optQuotesByAgent;
        private System.Windows.Forms.RadioButton optReqsByAgent;
    }
}
