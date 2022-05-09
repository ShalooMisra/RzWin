namespace NewMethod.Forms
{
    partial class frmAddUser
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
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.ctl_name = new NewMethod.nEdit_String();
            this.ctl_phone_number = new NewMethod.nEdit_String();
            this.ctl_email = new NewMethod.nEdit_String();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(133, 435);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(100, 42);
            this.cmdOK.TabIndex = 0;
            this.cmdOK.Text = "&OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(31, 435);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(100, 42);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // ctl_name
            // 
            this.ctl_name.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_name.Bold = false;
            this.ctl_name.Caption = "Name";
            this.ctl_name.Changed = false;
            this.ctl_name.IsEmail = false;
            this.ctl_name.IsURL = false;
            this.ctl_name.Location = new System.Drawing.Point(7, 7);
            this.ctl_name.Name = "ctl_name";
            this.ctl_name.PasswordChar = '\0';
            this.ctl_name.Size = new System.Drawing.Size(249, 45);
            this.ctl_name.TabIndex = 2;
            this.ctl_name.UseParentBackColor = false;
            // 
            // ctl_phone_number
            // 
            this.ctl_phone_number.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_phone_number.Bold = false;
            this.ctl_phone_number.Caption = "Phone Number";
            this.ctl_phone_number.Changed = false;
            this.ctl_phone_number.IsEmail = false;
            this.ctl_phone_number.IsURL = false;
            this.ctl_phone_number.Location = new System.Drawing.Point(7, 145);
            this.ctl_phone_number.Name = "ctl_phone_number";
            this.ctl_phone_number.PasswordChar = '\0';
            this.ctl_phone_number.Size = new System.Drawing.Size(249, 45);
            this.ctl_phone_number.TabIndex = 3;
            this.ctl_phone_number.UseParentBackColor = false;
            // 
            // ctl_email
            // 
            this.ctl_email.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_email.Bold = false;
            this.ctl_email.Caption = "Phone Number";
            this.ctl_email.Changed = false;
            this.ctl_email.IsEmail = false;
            this.ctl_email.IsURL = false;
            this.ctl_email.Location = new System.Drawing.Point(7, 58);
            this.ctl_email.Name = "ctl_email";
            this.ctl_email.PasswordChar = '\0';
            this.ctl_email.Size = new System.Drawing.Size(249, 45);
            this.ctl_email.TabIndex = 4;
            this.ctl_email.UseParentBackColor = false;
            // 
            // frmAddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 489);
            this.Controls.Add(this.ctl_email);
            this.Controls.Add(this.ctl_phone_number);
            this.Controls.Add(this.ctl_name);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddUser";
            this.Text = "New User [Quick Add]";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private nEdit_String ctl_name;
        private nEdit_String ctl_phone_number;
        private nEdit_String ctl_email;
    }
}