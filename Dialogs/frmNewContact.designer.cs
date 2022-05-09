using NewMethod;

namespace Rz5
{
    partial class frmNewContact
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
            this.gbCompany = new System.Windows.Forms.GroupBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            this.lblFax = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.gbContacts = new System.Windows.Forms.GroupBox();
            this.lstContacts = new NewMethod.nList();
            this.lblNewContact = new System.Windows.Forms.Label();
            this.txtNewContact = new System.Windows.Forms.TextBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.gbCompany.SuspendLayout();
            this.gbContacts.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCompany
            // 
            this.gbCompany.Controls.Add(this.lblEmail);
            this.gbCompany.Controls.Add(this.lblContact);
            this.gbCompany.Controls.Add(this.lblFax);
            this.gbCompany.Controls.Add(this.lblPhone);
            this.gbCompany.Controls.Add(this.lblCompanyName);
            this.gbCompany.Location = new System.Drawing.Point(7, 7);
            this.gbCompany.Name = "gbCompany";
            this.gbCompany.Size = new System.Drawing.Size(483, 99);
            this.gbCompany.TabIndex = 0;
            this.gbCompany.TabStop = false;
            this.gbCompany.Text = "Company";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(18, 78);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(43, 13);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "<email>";
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Location = new System.Drawing.Point(18, 39);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(55, 13);
            this.lblContact.TabIndex = 3;
            this.lblContact.Text = "<contact>";
            // 
            // lblFax
            // 
            this.lblFax.AutoSize = true;
            this.lblFax.Location = new System.Drawing.Point(18, 65);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(33, 13);
            this.lblFax.TabIndex = 2;
            this.lblFax.Text = "<fax>";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(18, 52);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(49, 13);
            this.lblPhone.TabIndex = 1;
            this.lblPhone.Text = "<phone>";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.Location = new System.Drawing.Point(17, 19);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(135, 20);
            this.lblCompanyName.TabIndex = 0;
            this.lblCompanyName.Text = "<company name>";
            // 
            // gbContacts
            // 
            this.gbContacts.Controls.Add(this.lstContacts);
            this.gbContacts.Location = new System.Drawing.Point(9, 115);
            this.gbContacts.Name = "gbContacts";
            this.gbContacts.Size = new System.Drawing.Size(480, 293);
            this.gbContacts.TabIndex = 1;
            this.gbContacts.TabStop = false;
            this.gbContacts.Text = "Contacts";
            // 
            // lstContacts
            // 
            this.lstContacts.Location = new System.Drawing.Point(9, 19);
            this.lstContacts.Name = "lstContacts";
            this.lstContacts.Size = new System.Drawing.Size(469, 268);
            this.lstContacts.TabIndex = 0;
            // 
            // lblNewContact
            // 
            this.lblNewContact.AutoSize = true;
            this.lblNewContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewContact.Location = new System.Drawing.Point(8, 426);
            this.lblNewContact.Name = "lblNewContact";
            this.lblNewContact.Size = new System.Drawing.Size(167, 20);
            this.lblNewContact.TabIndex = 2;
            this.lblNewContact.Text = "New Contact Name:";
            // 
            // txtNewContact
            // 
            this.txtNewContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewContact.Location = new System.Drawing.Point(12, 446);
            this.txtNewContact.Name = "txtNewContact";
            this.txtNewContact.Size = new System.Drawing.Size(473, 26);
            this.txtNewContact.TabIndex = 3;
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(45, 482);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(111, 23);
            this.cmdOK.TabIndex = 4;
            this.cmdOK.Text = "&OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(312, 482);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(111, 23);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmNewContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 514);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.txtNewContact);
            this.Controls.Add(this.lblNewContact);
            this.Controls.Add(this.gbContacts);
            this.Controls.Add(this.gbCompany);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewContact";
            this.Text = "New Contacts";
            this.gbCompany.ResumeLayout(false);
            this.gbCompany.PerformLayout();
            this.gbContacts.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCompany;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Label lblFax;
        private System.Windows.Forms.GroupBox gbContacts;
        private System.Windows.Forms.Label lblNewContact;
        private System.Windows.Forms.TextBox txtNewContact;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private nList lstContacts;
    }
}