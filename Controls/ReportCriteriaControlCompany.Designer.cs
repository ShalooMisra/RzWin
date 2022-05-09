namespace Rz5.Win.Controls
{
    partial class ReportCriteriaControlCompany
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
            this.company = new Rz5.CompanyStub();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // pic
            // 
            this.pic.BackgroundImage = global::RzInterfaceWin.Properties.Resources.PeopleSmall;
            // 
            // company
            // 
            this.company.Caption = "<caption>";
            this.company.Location = new System.Drawing.Point(29, 8);
            this.company.Name = "company";
            this.company.Size = new System.Drawing.Size(322, 50);
            this.company.TabIndex = 2;
            this.company.CompanyChangeFinished += new Rz5.ContactEventHandler(this.company_CompanyChangeFinished);
            this.company.ClearCompanyFinished += new Rz5.ContactEventHandler(this.company_ClearCompanyFinished);
            // 
            // ReportCriteriaControlCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.company);
            this.Name = "ReportCriteriaControlCompany";
            this.Size = new System.Drawing.Size(246, 58);
            this.Controls.SetChildIndex(this.pic, 0);
            this.Controls.SetChildIndex(this.company, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompanyStub company;
    }
}
