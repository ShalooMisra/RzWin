namespace Rz5
{
    partial class CompanyMergeScreen
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
            this.lblInstruct2 = new System.Windows.Forms.Label();
            this.lblInstruct = new System.Windows.Forms.Label();
            this.m1 = new CompanyMerge();
            this.m2 = new CompanyMerge();
            this.m3 = new CompanyMerge();
            this.m4 = new CompanyMerge();
            this.m5 = new CompanyMerge();
            this.SuspendLayout();
            // 
            // lblInstruct2
            // 
            this.lblInstruct2.AutoSize = true;
            this.lblInstruct2.Location = new System.Drawing.Point(6, 34);
            this.lblInstruct2.Name = "lblInstruct2";
            this.lblInstruct2.Size = new System.Drawing.Size(842, 13);
            this.lblInstruct2.TabIndex = 6;
            this.lblInstruct2.Text = "Copy and paste information so that 1 company\'s data is correct.  Click \'Ignore\' t" +
                "o remove a company, and click \'Accept\' to merge the remaining companies with the" +
                " accepted one.";
            // 
            // lblInstruct
            // 
            this.lblInstruct.AutoSize = true;
            this.lblInstruct.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruct.Location = new System.Drawing.Point(3, 3);
            this.lblInstruct.Name = "lblInstruct";
            this.lblInstruct.Size = new System.Drawing.Size(240, 25);
            this.lblInstruct.TabIndex = 5;
            this.lblInstruct.Text = "Company Consolidation";
            // 
            // m1
            // 
            this.m1.Location = new System.Drawing.Point(3, 50);
            this.m1.Name = "m1";
            this.m1.Size = new System.Drawing.Size(872, 121);
            this.m1.TabIndex = 7;
            this.m1.Accept += new CompanyMerge.AcceptHandler(this.m_Accept);
            // 
            // m2
            // 
            this.m2.Location = new System.Drawing.Point(3, 177);
            this.m2.Name = "m2";
            this.m2.Size = new System.Drawing.Size(872, 121);
            this.m2.TabIndex = 8;
            this.m2.Accept += new CompanyMerge.AcceptHandler(this.m_Accept);
            // 
            // m3
            // 
            this.m3.Location = new System.Drawing.Point(3, 304);
            this.m3.Name = "m3";
            this.m3.Size = new System.Drawing.Size(872, 121);
            this.m3.TabIndex = 9;
            this.m3.Accept += new CompanyMerge.AcceptHandler(this.m_Accept);
            // 
            // m4
            // 
            this.m4.Location = new System.Drawing.Point(3, 431);
            this.m4.Name = "m4";
            this.m4.Size = new System.Drawing.Size(872, 121);
            this.m4.TabIndex = 10;
            this.m4.Accept += new CompanyMerge.AcceptHandler(this.m_Accept);
            // 
            // m5
            // 
            this.m5.Location = new System.Drawing.Point(3, 558);
            this.m5.Name = "m5";
            this.m5.Size = new System.Drawing.Size(872, 121);
            this.m5.TabIndex = 11;
            this.m5.Accept += new CompanyMerge.AcceptHandler(this.m_Accept);
            // 
            // CompanyMergeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m5);
            this.Controls.Add(this.m4);
            this.Controls.Add(this.m3);
            this.Controls.Add(this.m2);
            this.Controls.Add(this.m1);
            this.Controls.Add(this.lblInstruct2);
            this.Controls.Add(this.lblInstruct);
            this.Name = "CompanyMergeScreen";
            this.Size = new System.Drawing.Size(998, 685);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInstruct2;
        private System.Windows.Forms.Label lblInstruct;
        private CompanyMerge m1;
        private CompanyMerge m2;
        private CompanyMerge m3;
        private CompanyMerge m4;
        private CompanyMerge m5;
    }
}
