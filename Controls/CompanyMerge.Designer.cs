namespace Rz5
{
    partial class CompanyMerge
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
            this.gb = new System.Windows.Forms.GroupBox();
            this.ctl_companyname = new NewMethod.nEdit_String();
            this.ctl_primarycontact = new NewMethod.nEdit_String();
            this.ctl_qb_name = new NewMethod.nEdit_String();
            this.ctl_primaryphone = new NewMethod.nEdit_String();
            this.ctl_primaryfax = new NewMethod.nEdit_String();
            this.ctl_primaryemailaddress = new NewMethod.nEdit_String();
            this.cmdIgnore = new System.Windows.Forms.Button();
            this.cmdView = new System.Windows.Forms.Button();
            this.cmdAccept = new System.Windows.Forms.Button();
            this.gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb
            // 
            this.gb.Controls.Add(this.cmdIgnore);
            this.gb.Controls.Add(this.cmdView);
            this.gb.Controls.Add(this.cmdAccept);
            this.gb.Controls.Add(this.ctl_primaryemailaddress);
            this.gb.Controls.Add(this.ctl_primaryfax);
            this.gb.Controls.Add(this.ctl_primaryphone);
            this.gb.Controls.Add(this.ctl_qb_name);
            this.gb.Controls.Add(this.ctl_primarycontact);
            this.gb.Controls.Add(this.ctl_companyname);
            this.gb.Location = new System.Drawing.Point(5, 5);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(862, 112);
            this.gb.TabIndex = 0;
            this.gb.TabStop = false;
            this.gb.Text = "<caption>";
            // 
            // ctl_companyname
            // 
            this.ctl_companyname.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_companyname.Bold = false;
            this.ctl_companyname.Caption = "Company Name";
            this.ctl_companyname.Changed = false;
            this.ctl_companyname.Enabled = false;
            this.ctl_companyname.IsEmail = false;
            this.ctl_companyname.IsURL = false;
            this.ctl_companyname.Location = new System.Drawing.Point(6, 15);
            this.ctl_companyname.Name = "ctl_companyname";
            this.ctl_companyname.Size = new System.Drawing.Size(290, 42);
            this.ctl_companyname.TabIndex = 4;
            this.ctl_companyname.UseParentBackColor = false;
            // 
            // ctl_primarycontact
            // 
            this.ctl_primarycontact.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_primarycontact.Bold = false;
            this.ctl_primarycontact.Caption = "Contact Name";
            this.ctl_primarycontact.Changed = false;
            this.ctl_primarycontact.IsEmail = false;
            this.ctl_primarycontact.IsURL = false;
            this.ctl_primarycontact.Location = new System.Drawing.Point(302, 15);
            this.ctl_primarycontact.Name = "ctl_primarycontact";
            this.ctl_primarycontact.Size = new System.Drawing.Size(238, 42);
            this.ctl_primarycontact.TabIndex = 5;
            this.ctl_primarycontact.UseParentBackColor = false;
            // 
            // ctl_qb_name
            // 
            this.ctl_qb_name.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_qb_name.Bold = false;
            this.ctl_qb_name.Caption = "Quickbooks Name";
            this.ctl_qb_name.Changed = false;
            this.ctl_qb_name.IsEmail = false;
            this.ctl_qb_name.IsURL = false;
            this.ctl_qb_name.Location = new System.Drawing.Point(546, 15);
            this.ctl_qb_name.Name = "ctl_qb_name";
            this.ctl_qb_name.Size = new System.Drawing.Size(238, 42);
            this.ctl_qb_name.TabIndex = 6;
            this.ctl_qb_name.UseParentBackColor = false;
            // 
            // ctl_primaryphone
            // 
            this.ctl_primaryphone.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_primaryphone.Bold = false;
            this.ctl_primaryphone.Caption = "Phone";
            this.ctl_primaryphone.Changed = false;
            this.ctl_primaryphone.IsEmail = false;
            this.ctl_primaryphone.IsURL = false;
            this.ctl_primaryphone.Location = new System.Drawing.Point(6, 63);
            this.ctl_primaryphone.Name = "ctl_primaryphone";
            this.ctl_primaryphone.Size = new System.Drawing.Size(290, 42);
            this.ctl_primaryphone.TabIndex = 7;
            this.ctl_primaryphone.UseParentBackColor = false;
            // 
            // ctl_primaryfax
            // 
            this.ctl_primaryfax.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_primaryfax.Bold = false;
            this.ctl_primaryfax.Caption = "Fax";
            this.ctl_primaryfax.Changed = false;
            this.ctl_primaryfax.IsEmail = false;
            this.ctl_primaryfax.IsURL = false;
            this.ctl_primaryfax.Location = new System.Drawing.Point(302, 63);
            this.ctl_primaryfax.Name = "ctl_primaryfax";
            this.ctl_primaryfax.Size = new System.Drawing.Size(238, 42);
            this.ctl_primaryfax.TabIndex = 8;
            this.ctl_primaryfax.UseParentBackColor = false;
            // 
            // ctl_primaryemailaddress
            // 
            this.ctl_primaryemailaddress.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_primaryemailaddress.Bold = false;
            this.ctl_primaryemailaddress.Caption = "Email";
            this.ctl_primaryemailaddress.Changed = false;
            this.ctl_primaryemailaddress.IsEmail = true;
            this.ctl_primaryemailaddress.IsURL = false;
            this.ctl_primaryemailaddress.Location = new System.Drawing.Point(546, 64);
            this.ctl_primaryemailaddress.Name = "ctl_primaryemailaddress";
            this.ctl_primaryemailaddress.Size = new System.Drawing.Size(238, 42);
            this.ctl_primaryemailaddress.TabIndex = 9;
            this.ctl_primaryemailaddress.UseParentBackColor = false;
            // 
            // cmdIgnore
            // 
            this.cmdIgnore.Location = new System.Drawing.Point(791, 84);
            this.cmdIgnore.Name = "cmdIgnore";
            this.cmdIgnore.Size = new System.Drawing.Size(66, 21);
            this.cmdIgnore.TabIndex = 12;
            this.cmdIgnore.Text = "Ignore";
            this.cmdIgnore.UseVisualStyleBackColor = true;
            this.cmdIgnore.Click += new System.EventHandler(this.cmdIgnore_Click);
            // 
            // cmdView
            // 
            this.cmdView.Location = new System.Drawing.Point(790, 63);
            this.cmdView.Name = "cmdView";
            this.cmdView.Size = new System.Drawing.Size(66, 21);
            this.cmdView.TabIndex = 11;
            this.cmdView.Text = "View";
            this.cmdView.UseVisualStyleBackColor = true;
            this.cmdView.Click += new System.EventHandler(this.cmdView_Click);
            // 
            // cmdAccept
            // 
            this.cmdAccept.Location = new System.Drawing.Point(790, 16);
            this.cmdAccept.Name = "cmdAccept";
            this.cmdAccept.Size = new System.Drawing.Size(67, 41);
            this.cmdAccept.TabIndex = 10;
            this.cmdAccept.Text = "Accept";
            this.cmdAccept.UseVisualStyleBackColor = true;
            this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
            // 
            // CompanyMerge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb);
            this.Name = "CompanyMerge";
            this.Size = new System.Drawing.Size(873, 122);
            this.gb.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb;
        private NewMethod.nEdit_String ctl_primaryemailaddress;
        private NewMethod.nEdit_String ctl_primaryfax;
        private NewMethod.nEdit_String ctl_primaryphone;
        private NewMethod.nEdit_String ctl_qb_name;
        private NewMethod.nEdit_String ctl_primarycontact;
        private NewMethod.nEdit_String ctl_companyname;
        private System.Windows.Forms.Button cmdIgnore;
        private System.Windows.Forms.Button cmdView;
        private System.Windows.Forms.Button cmdAccept;
    }
}
