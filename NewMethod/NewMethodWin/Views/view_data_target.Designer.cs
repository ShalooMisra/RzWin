namespace NewMethod
{
    partial class view_data_target
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
            this.lblApply = new System.Windows.Forms.LinkLabel();
            this.ctl_name = new NewMethod.nEdit_String();
            this.ctl_server_name = new NewMethod.nEdit_String();
            this.ctl_database_name = new NewMethod.nEdit_String();
            this.ctl_user_name = new NewMethod.nEdit_String();
            this.ctl_user_password = new NewMethod.nEdit_String();
            this.lblTest = new System.Windows.Forms.LinkLabel();
            this.lblCreateDatabase = new System.Windows.Forms.LinkLabel();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.throb = new NewMethod.nThrobber();
            this.bgTest = new System.ComponentModel.BackgroundWorker();
            this.bgCreate = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // lblApply
            // 
            this.lblApply.AutoSize = true;
            this.lblApply.Location = new System.Drawing.Point(453, 0);
            this.lblApply.Name = "lblApply";
            this.lblApply.Size = new System.Drawing.Size(32, 13);
            this.lblApply.TabIndex = 1;
            this.lblApply.TabStop = true;
            this.lblApply.Text = "apply";
            this.lblApply.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblApply_LinkClicked);
            // 
            // ctl_name
            // 
            this.ctl_name.AllCaps = false;
            this.ctl_name.BackColor = System.Drawing.Color.White;
            this.ctl_name.Bold = false;
            this.ctl_name.Caption = "Name";
            this.ctl_name.Changed = false;
            this.ctl_name.IsEmail = false;
            this.ctl_name.IsURL = false;
            this.ctl_name.Location = new System.Drawing.Point(3, 6);
            this.ctl_name.Name = "ctl_name";
            this.ctl_name.PasswordChar = '\0';
            this.ctl_name.Size = new System.Drawing.Size(238, 40);
            this.ctl_name.TabIndex = 2;
            this.ctl_name.UseParentBackColor = true;
            this.ctl_name.zz_Enabled = true;
            this.ctl_name.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_name.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_name.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_name.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_name.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_name.zz_OriginalDesign = true;
            this.ctl_name.zz_ShowLinkButton = false;
            this.ctl_name.zz_ShowNeedsSaveColor = true;
            this.ctl_name.zz_Text = "";
            this.ctl_name.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_name.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_name.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_name.zz_UseGlobalColor = false;
            this.ctl_name.zz_UseGlobalFont = false;
            // 
            // ctl_server_name
            // 
            this.ctl_server_name.AllCaps = false;
            this.ctl_server_name.BackColor = System.Drawing.Color.White;
            this.ctl_server_name.Bold = false;
            this.ctl_server_name.Caption = "Server";
            this.ctl_server_name.Changed = false;
            this.ctl_server_name.IsEmail = false;
            this.ctl_server_name.IsURL = false;
            this.ctl_server_name.Location = new System.Drawing.Point(3, 52);
            this.ctl_server_name.Name = "ctl_server_name";
            this.ctl_server_name.PasswordChar = '\0';
            this.ctl_server_name.Size = new System.Drawing.Size(238, 40);
            this.ctl_server_name.TabIndex = 3;
            this.ctl_server_name.UseParentBackColor = true;
            this.ctl_server_name.zz_Enabled = true;
            this.ctl_server_name.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_server_name.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_server_name.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_server_name.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_server_name.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_server_name.zz_OriginalDesign = true;
            this.ctl_server_name.zz_ShowLinkButton = false;
            this.ctl_server_name.zz_ShowNeedsSaveColor = true;
            this.ctl_server_name.zz_Text = "";
            this.ctl_server_name.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_server_name.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_server_name.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_server_name.zz_UseGlobalColor = false;
            this.ctl_server_name.zz_UseGlobalFont = false;
            // 
            // ctl_database_name
            // 
            this.ctl_database_name.AllCaps = false;
            this.ctl_database_name.BackColor = System.Drawing.Color.White;
            this.ctl_database_name.Bold = false;
            this.ctl_database_name.Caption = "Database";
            this.ctl_database_name.Changed = false;
            this.ctl_database_name.IsEmail = false;
            this.ctl_database_name.IsURL = false;
            this.ctl_database_name.Location = new System.Drawing.Point(247, 52);
            this.ctl_database_name.Name = "ctl_database_name";
            this.ctl_database_name.PasswordChar = '\0';
            this.ctl_database_name.Size = new System.Drawing.Size(238, 40);
            this.ctl_database_name.TabIndex = 4;
            this.ctl_database_name.UseParentBackColor = true;
            this.ctl_database_name.zz_Enabled = true;
            this.ctl_database_name.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_database_name.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_database_name.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_database_name.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_database_name.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_database_name.zz_OriginalDesign = true;
            this.ctl_database_name.zz_ShowLinkButton = false;
            this.ctl_database_name.zz_ShowNeedsSaveColor = true;
            this.ctl_database_name.zz_Text = "";
            this.ctl_database_name.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_database_name.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_database_name.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_database_name.zz_UseGlobalColor = false;
            this.ctl_database_name.zz_UseGlobalFont = false;
            // 
            // ctl_user_name
            // 
            this.ctl_user_name.AllCaps = false;
            this.ctl_user_name.BackColor = System.Drawing.Color.White;
            this.ctl_user_name.Bold = false;
            this.ctl_user_name.Caption = "User Name";
            this.ctl_user_name.Changed = false;
            this.ctl_user_name.IsEmail = false;
            this.ctl_user_name.IsURL = false;
            this.ctl_user_name.Location = new System.Drawing.Point(3, 98);
            this.ctl_user_name.Name = "ctl_user_name";
            this.ctl_user_name.PasswordChar = '\0';
            this.ctl_user_name.Size = new System.Drawing.Size(238, 40);
            this.ctl_user_name.TabIndex = 5;
            this.ctl_user_name.UseParentBackColor = true;
            this.ctl_user_name.zz_Enabled = true;
            this.ctl_user_name.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_user_name.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_user_name.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_user_name.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_user_name.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_user_name.zz_OriginalDesign = true;
            this.ctl_user_name.zz_ShowLinkButton = false;
            this.ctl_user_name.zz_ShowNeedsSaveColor = true;
            this.ctl_user_name.zz_Text = "";
            this.ctl_user_name.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_user_name.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_user_name.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_user_name.zz_UseGlobalColor = false;
            this.ctl_user_name.zz_UseGlobalFont = false;
            // 
            // ctl_user_password
            // 
            this.ctl_user_password.AllCaps = false;
            this.ctl_user_password.BackColor = System.Drawing.Color.White;
            this.ctl_user_password.Bold = false;
            this.ctl_user_password.Caption = "Password";
            this.ctl_user_password.Changed = false;
            this.ctl_user_password.IsEmail = false;
            this.ctl_user_password.IsURL = false;
            this.ctl_user_password.Location = new System.Drawing.Point(247, 98);
            this.ctl_user_password.Name = "ctl_user_password";
            this.ctl_user_password.PasswordChar = '\0';
            this.ctl_user_password.Size = new System.Drawing.Size(238, 40);
            this.ctl_user_password.TabIndex = 6;
            this.ctl_user_password.UseParentBackColor = true;
            this.ctl_user_password.zz_Enabled = true;
            this.ctl_user_password.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_user_password.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_user_password.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_user_password.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_user_password.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_user_password.zz_OriginalDesign = true;
            this.ctl_user_password.zz_ShowLinkButton = false;
            this.ctl_user_password.zz_ShowNeedsSaveColor = true;
            this.ctl_user_password.zz_Text = "";
            this.ctl_user_password.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_user_password.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_user_password.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_user_password.zz_UseGlobalColor = false;
            this.ctl_user_password.zz_UseGlobalFont = false;
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.Location = new System.Drawing.Point(458, 19);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(24, 13);
            this.lblTest.TabIndex = 7;
            this.lblTest.TabStop = true;
            this.lblTest.Text = "test";
            this.lblTest.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblTest_LinkClicked);
            // 
            // lblCreateDatabase
            // 
            this.lblCreateDatabase.AutoSize = true;
            this.lblCreateDatabase.Location = new System.Drawing.Point(445, 52);
            this.lblCreateDatabase.Name = "lblCreateDatabase";
            this.lblCreateDatabase.Size = new System.Drawing.Size(37, 13);
            this.lblCreateDatabase.TabIndex = 8;
            this.lblCreateDatabase.TabStop = true;
            this.lblCreateDatabase.Text = "create";
            this.lblCreateDatabase.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCreateDatabase_LinkClicked);
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(4, 149);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtStatus.Size = new System.Drawing.Size(481, 88);
            this.txtStatus.TabIndex = 9;
            this.txtStatus.WordWrap = false;
            // 
            // throb
            // 
            this.throb.BackColor = System.Drawing.Color.Maroon;
            this.throb.Location = new System.Drawing.Point(407, 16);
            this.throb.Name = "throb";
            this.throb.Size = new System.Drawing.Size(33, 30);
            this.throb.TabIndex = 10;
            this.throb.UseParentBackColor = false;
            // 
            // bgTest
            // 
            this.bgTest.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgTest_DoWork);
            this.bgTest.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgTest_RunWorkerCompleted);
            // 
            // bgCreate
            // 
            this.bgCreate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgCreate_DoWork);
            this.bgCreate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgCreate_RunWorkerCompleted);
            // 
            // view_data_target
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.throb);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lblCreateDatabase);
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.ctl_user_password);
            this.Controls.Add(this.ctl_user_name);
            this.Controls.Add(this.ctl_database_name);
            this.Controls.Add(this.ctl_server_name);
            this.Controls.Add(this.lblApply);
            this.Controls.Add(this.ctl_name);
            this.Name = "view_data_target";
            this.Size = new System.Drawing.Size(496, 240);
            this.Resize += new System.EventHandler(this.view_data_target_Resize);
            this.Controls.SetChildIndex(this.ctl_name, 0);
            this.Controls.SetChildIndex(this.lblApply, 0);
            this.Controls.SetChildIndex(this.ctl_server_name, 0);
            this.Controls.SetChildIndex(this.ctl_database_name, 0);
            this.Controls.SetChildIndex(this.ctl_user_name, 0);
            this.Controls.SetChildIndex(this.ctl_user_password, 0);
            this.Controls.SetChildIndex(this.lblTest, 0);
            this.Controls.SetChildIndex(this.lblCreateDatabase, 0);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.throb, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblApply;
        private nEdit_String ctl_name;
        private nEdit_String ctl_server_name;
        private nEdit_String ctl_database_name;
        private nEdit_String ctl_user_name;
        private nEdit_String ctl_user_password;
        private System.Windows.Forms.LinkLabel lblTest;
        private System.Windows.Forms.LinkLabel lblCreateDatabase;
        private System.Windows.Forms.TextBox txtStatus;
        private nThrobber throb;
        private System.ComponentModel.BackgroundWorker bgTest;
        private System.ComponentModel.BackgroundWorker bgCreate;
    }
}
