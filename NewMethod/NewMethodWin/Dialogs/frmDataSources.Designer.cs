namespace NewMethod
{
    partial class frmDataSources
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
            this.components = new System.ComponentModel.Container();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.gb = new System.Windows.Forms.GroupBox();
            this.ctl_database_name = new NewMethod.nEdit_String();
            this.cmdApply = new System.Windows.Forms.Button();
            this.cmdTestConnect = new System.Windows.Forms.Button();
            this.ctl_command_string = new NewMethod.nEdit_Memo();
            this.ctl_user_password = new NewMethod.nEdit_String();
            this.ctl_user_name = new NewMethod.nEdit_String();
            this.ctl_server_name = new NewMethod.nEdit_String();
            this.ctl_name = new NewMethod.nEdit_String();
            this.label1 = new System.Windows.Forms.Label();
            this.optSQLServer = new System.Windows.Forms.RadioButton();
            this.lv = new NewMethod.nList();
            this.optMySQL = new System.Windows.Forms.RadioButton();
            this.gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(82, 515);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(148, 43);
            this.cmdOK.TabIndex = 0;
            this.cmdOK.Text = "&OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(455, 515);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(148, 43);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // gb
            // 
            this.gb.Controls.Add(this.optMySQL);
            this.gb.Controls.Add(this.ctl_database_name);
            this.gb.Controls.Add(this.cmdApply);
            this.gb.Controls.Add(this.cmdTestConnect);
            this.gb.Controls.Add(this.ctl_command_string);
            this.gb.Controls.Add(this.ctl_user_password);
            this.gb.Controls.Add(this.ctl_user_name);
            this.gb.Controls.Add(this.ctl_server_name);
            this.gb.Controls.Add(this.ctl_name);
            this.gb.Controls.Add(this.label1);
            this.gb.Controls.Add(this.optSQLServer);
            this.gb.Location = new System.Drawing.Point(5, 243);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(672, 266);
            this.gb.TabIndex = 3;
            this.gb.TabStop = false;
            // 
            // ctl_database_name
            // 
            this.ctl_database_name.AllCaps = false;
            this.ctl_database_name.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_database_name.Bold = false;
            this.ctl_database_name.Caption = "Database Name";
            this.ctl_database_name.Changed = false;
            this.ctl_database_name.IsEmail = false;
            this.ctl_database_name.IsURL = false;
            this.ctl_database_name.Location = new System.Drawing.Point(231, 60);
            this.ctl_database_name.Name = "ctl_database_name";
            this.ctl_database_name.PasswordChar = '\0';
            this.ctl_database_name.Size = new System.Drawing.Size(195, 46);
            this.ctl_database_name.TabIndex = 11;
            this.ctl_database_name.UseParentBackColor = false;
            this.ctl_database_name.zz_Enabled = true;
            this.ctl_database_name.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_database_name.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_database_name.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_database_name.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
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
            // cmdApply
            // 
            this.cmdApply.Location = new System.Drawing.Point(439, 10);
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(108, 20);
            this.cmdApply.TabIndex = 10;
            this.cmdApply.Text = "Apply";
            this.cmdApply.UseVisualStyleBackColor = true;
            this.cmdApply.Click += new System.EventHandler(this.cmdApply_Click);
            // 
            // cmdTestConnect
            // 
            this.cmdTestConnect.Location = new System.Drawing.Point(558, 112);
            this.cmdTestConnect.Name = "cmdTestConnect";
            this.cmdTestConnect.Size = new System.Drawing.Size(108, 20);
            this.cmdTestConnect.TabIndex = 9;
            this.cmdTestConnect.Text = "Test Connect";
            this.cmdTestConnect.UseVisualStyleBackColor = true;
            this.cmdTestConnect.Click += new System.EventHandler(this.cmdTestConnect_Click);
            // 
            // ctl_command_string
            // 
            this.ctl_command_string.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_command_string.Bold = false;
            this.ctl_command_string.Caption = "Query String";
            this.ctl_command_string.Changed = false;
            this.ctl_command_string.Location = new System.Drawing.Point(8, 112);
            this.ctl_command_string.Name = "ctl_command_string";
            this.ctl_command_string.Size = new System.Drawing.Size(657, 148);
            this.ctl_command_string.TabIndex = 8;
            this.ctl_command_string.UseParentBackColor = false;
            this.ctl_command_string.zz_Enabled = true;
            this.ctl_command_string.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_command_string.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_command_string.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_command_string.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctl_command_string.zz_LabelLocation = NewMethod.nEdit_Memo.LabelLocations.TopLeft;
            this.ctl_command_string.zz_OriginalDesign = true;
            this.ctl_command_string.zz_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ctl_command_string.zz_ShowNeedsSaveColor = true;
            this.ctl_command_string.zz_Text = "";
            this.ctl_command_string.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_command_string.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_command_string.zz_UseGlobalColor = false;
            this.ctl_command_string.zz_UseGlobalFont = false;
            // 
            // ctl_user_password
            // 
            this.ctl_user_password.AllCaps = false;
            this.ctl_user_password.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_user_password.Bold = false;
            this.ctl_user_password.Caption = "Password";
            this.ctl_user_password.Changed = false;
            this.ctl_user_password.IsEmail = false;
            this.ctl_user_password.IsURL = false;
            this.ctl_user_password.Location = new System.Drawing.Point(553, 60);
            this.ctl_user_password.Name = "ctl_user_password";
            this.ctl_user_password.PasswordChar = '\0';
            this.ctl_user_password.Size = new System.Drawing.Size(112, 46);
            this.ctl_user_password.TabIndex = 7;
            this.ctl_user_password.UseParentBackColor = false;
            this.ctl_user_password.zz_Enabled = true;
            this.ctl_user_password.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_user_password.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_user_password.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_user_password.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
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
            // ctl_user_name
            // 
            this.ctl_user_name.AllCaps = false;
            this.ctl_user_name.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_user_name.Bold = false;
            this.ctl_user_name.Caption = "User Name";
            this.ctl_user_name.Changed = false;
            this.ctl_user_name.IsEmail = false;
            this.ctl_user_name.IsURL = false;
            this.ctl_user_name.Location = new System.Drawing.Point(432, 60);
            this.ctl_user_name.Name = "ctl_user_name";
            this.ctl_user_name.PasswordChar = '\0';
            this.ctl_user_name.Size = new System.Drawing.Size(115, 46);
            this.ctl_user_name.TabIndex = 6;
            this.ctl_user_name.UseParentBackColor = false;
            this.ctl_user_name.zz_Enabled = true;
            this.ctl_user_name.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_user_name.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_user_name.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_user_name.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
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
            // ctl_server_name
            // 
            this.ctl_server_name.AllCaps = false;
            this.ctl_server_name.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_server_name.Bold = false;
            this.ctl_server_name.Caption = "Server Name";
            this.ctl_server_name.Changed = false;
            this.ctl_server_name.IsEmail = false;
            this.ctl_server_name.IsURL = false;
            this.ctl_server_name.Location = new System.Drawing.Point(7, 60);
            this.ctl_server_name.Name = "ctl_server_name";
            this.ctl_server_name.PasswordChar = '\0';
            this.ctl_server_name.Size = new System.Drawing.Size(218, 46);
            this.ctl_server_name.TabIndex = 3;
            this.ctl_server_name.UseParentBackColor = false;
            this.ctl_server_name.zz_Enabled = true;
            this.ctl_server_name.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_server_name.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_server_name.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_server_name.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
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
            // ctl_name
            // 
            this.ctl_name.AllCaps = false;
            this.ctl_name.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_name.Bold = false;
            this.ctl_name.Caption = "Name";
            this.ctl_name.Changed = false;
            this.ctl_name.IsEmail = false;
            this.ctl_name.IsURL = false;
            this.ctl_name.Location = new System.Drawing.Point(7, 10);
            this.ctl_name.Name = "ctl_name";
            this.ctl_name.PasswordChar = '\0';
            this.ctl_name.Size = new System.Drawing.Size(540, 44);
            this.ctl_name.TabIndex = 2;
            this.ctl_name.UseParentBackColor = false;
            this.ctl_name.zz_Enabled = true;
            this.ctl_name.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_name.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_name.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_name.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(559, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Source Type:";
            // 
            // optSQLServer
            // 
            this.optSQLServer.AutoSize = true;
            this.optSQLServer.Checked = true;
            this.optSQLServer.Location = new System.Drawing.Point(571, 29);
            this.optSQLServer.Name = "optSQLServer";
            this.optSQLServer.Size = new System.Drawing.Size(80, 17);
            this.optSQLServer.TabIndex = 0;
            this.optSQLServer.Text = "SQL Server";
            this.optSQLServer.UseVisualStyleBackColor = true;
            // 
            // lv
            // 
            this.lv.AddCaption = "Add New Source";
            this.lv.AllowActions = true;
            this.lv.AllowAdd = true;
            this.lv.AllowDelete = true;
            this.lv.Caption = "";
            this.lv.ExtraClassInfo = "";
            this.lv.Location = new System.Drawing.Point(-1, -2);
            this.lv.MultiSelect = true;
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(678, 239);
            this.lv.SuppressSelectionChanged = false;
            this.lv.TabIndex = 2;
            this.lv.zz_ShowAutoRefresh = true;
            this.lv.zz_ShowUnlimited = true;
            this.lv.Load += new System.EventHandler(this.lv_Load);
            this.lv.AboutToThrow += new Core.ShowHandler(this.lv_AboutToThrow);
            this.lv.AboutToAdd += new NewMethod.AddHandler(this.lv_AboutToAdd);
            // 
            // optMySQL
            // 
            this.optMySQL.AutoSize = true;
            this.optMySQL.Location = new System.Drawing.Point(571, 44);
            this.optMySQL.Name = "optMySQL";
            this.optMySQL.Size = new System.Drawing.Size(60, 17);
            this.optMySQL.TabIndex = 12;
            this.optMySQL.Text = "MySQL";
            this.optMySQL.UseVisualStyleBackColor = true;
            // 
            // frmDataSources
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 570);
            this.Controls.Add(this.gb);
            this.Controls.Add(this.lv);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDataSources";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Sources";
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private nList lv;
        private System.Windows.Forms.GroupBox gb;
        private nEdit_String ctl_user_name;
        private nEdit_String ctl_server_name;
        private nEdit_String ctl_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton optSQLServer;
        private nEdit_String ctl_user_password;
        private nEdit_Memo ctl_command_string;
        private System.Windows.Forms.Button cmdTestConnect;
        private System.Windows.Forms.Button cmdApply;
        private nEdit_String ctl_database_name;
        private System.Windows.Forms.RadioButton optMySQL;
    }
}