using NewMethod;

namespace Rz5
{
    partial class CompanyContactList
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
            this.companies = new CompanyList();
            this.contacts = new ContactList();
            this.SuspendLayout();
            // 
            // companies
            // 
            this.companies.BackColor = System.Drawing.Color.White;
            this.companies.Location = new System.Drawing.Point(0, 3);
            this.companies.Name = "companies";
            this.companies.Size = new System.Drawing.Size(387, 59);
            this.companies.TabIndex = 0;
            this.companies.CompanyClicked += new CompanyEvent(this.companies_CompanyClicked);
            // 
            // contacts
            // 
            this.contacts.Location = new System.Drawing.Point(0, 59);
            this.contacts.Name = "contacts";
            this.contacts.Size = new System.Drawing.Size(297, 45);
            this.contacts.TabIndex = 1;
            // 
            // CompanyContactList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contacts);
            this.Controls.Add(this.companies);
            this.Name = "CompanyContactList";
            this.Size = new System.Drawing.Size(514, 211);
            this.Resize += new System.EventHandler(this.CompanyContactList_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private CompanyList companies;
        private ContactList contacts;
    }
}
