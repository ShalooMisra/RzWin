namespace NewMethod
{
    partial class frmSysFinder
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
            this.ctlSysName = new NewMethod.nEdit_List();
            this.lblXML = new System.Windows.Forms.LinkLabel();
            this.lblDatabase = new System.Windows.Forms.LinkLabel();
            this.ctlServerName = new NewMethod.nEdit_List();
            this.ctlUser = new NewMethod.nEdit_List();
            this.ctlPassword = new NewMethod.nEdit_List();
            this.lvSystems = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.bg = new System.ComponentModel.BackgroundWorker();
            this.lblCheck = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // ctlSysName
            // 
            this.ctlSysName.AllCaps = false;
            this.ctlSysName.AllowEdit = false;
            this.ctlSysName.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlSysName.Bold = false;
            this.ctlSysName.Caption = "System Name";
            this.ctlSysName.Changed = false;
            this.ctlSysName.ListName = null;
            this.ctlSysName.Location = new System.Drawing.Point(2, 3);
            this.ctlSysName.Name = "ctlSysName";
            this.ctlSysName.SimpleList = "NewMethod|Rz3_Common|Rz3|Rz3_CTG|AccountABle|Bank";
            this.ctlSysName.Size = new System.Drawing.Size(225, 44);
            this.ctlSysName.TabIndex = 0;
            this.ctlSysName.UseParentBackColor = false;
            this.ctlSysName.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlSysName.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlSysName.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlSysName.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlSysName.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctlSysName.zz_OriginalDesign = true;
            this.ctlSysName.zz_ShowNeedsSaveColor = true;
            this.ctlSysName.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlSysName.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlSysName.zz_UseGlobalColor = false;
            this.ctlSysName.zz_UseGlobalFont = false;
            this.ctlSysName.DataChanged += new NewMethod.ChangeHandler(this.ctlSysName_DataChanged);
            // 
            // lblXML
            // 
            this.lblXML.AutoSize = true;
            this.lblXML.Location = new System.Drawing.Point(243, 25);
            this.lblXML.Name = "lblXML";
            this.lblXML.Size = new System.Drawing.Size(34, 13);
            this.lblXML.TabIndex = 1;
            this.lblXML.TabStop = true;
            this.lblXML.Text = "<xml>";
            this.lblXML.Visible = false;
            this.lblXML.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblXML_LinkClicked);
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(243, 77);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(63, 13);
            this.lblDatabase.TabIndex = 2;
            this.lblDatabase.TabStop = true;
            this.lblDatabase.Text = "<database>";
            this.lblDatabase.Visible = false;
            this.lblDatabase.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblDatabase_LinkClicked);
            // 
            // ctlServerName
            // 
            this.ctlServerName.AllCaps = false;
            this.ctlServerName.AllowEdit = false;
            this.ctlServerName.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlServerName.Bold = false;
            this.ctlServerName.Caption = "Server Name";
            this.ctlServerName.Changed = false;
            this.ctlServerName.ListName = null;
            this.ctlServerName.Location = new System.Drawing.Point(2, 60);
            this.ctlServerName.Name = "ctlServerName";
            this.ctlServerName.SimpleList = "71.251.105.34 [NEWMETHOD1]|DEVELOPMENT-2|VANBURGH02|V4";
            this.ctlServerName.Size = new System.Drawing.Size(225, 44);
            this.ctlServerName.TabIndex = 3;
            this.ctlServerName.UseParentBackColor = false;
            this.ctlServerName.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlServerName.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlServerName.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlServerName.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlServerName.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctlServerName.zz_OriginalDesign = true;
            this.ctlServerName.zz_ShowNeedsSaveColor = true;
            this.ctlServerName.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlServerName.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlServerName.zz_UseGlobalColor = false;
            this.ctlServerName.zz_UseGlobalFont = false;
            this.ctlServerName.DataChanged += new NewMethod.ChangeHandler(this.ctlServerName_DataChanged);
            // 
            // ctlUser
            // 
            this.ctlUser.AllCaps = false;
            this.ctlUser.AllowEdit = false;
            this.ctlUser.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlUser.Bold = false;
            this.ctlUser.Caption = "User";
            this.ctlUser.Changed = false;
            this.ctlUser.ListName = null;
            this.ctlUser.Location = new System.Drawing.Point(2, 110);
            this.ctlUser.Name = "ctlUser";
            this.ctlUser.SimpleList = "";
            this.ctlUser.Size = new System.Drawing.Size(96, 44);
            this.ctlUser.TabIndex = 4;
            this.ctlUser.UseParentBackColor = false;
            this.ctlUser.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlUser.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlUser.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlUser.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlUser.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctlUser.zz_OriginalDesign = true;
            this.ctlUser.zz_ShowNeedsSaveColor = true;
            this.ctlUser.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlUser.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlUser.zz_UseGlobalColor = false;
            this.ctlUser.zz_UseGlobalFont = false;
            // 
            // ctlPassword
            // 
            this.ctlPassword.AllCaps = false;
            this.ctlPassword.AllowEdit = false;
            this.ctlPassword.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlPassword.Bold = false;
            this.ctlPassword.Caption = "Password";
            this.ctlPassword.Changed = false;
            this.ctlPassword.ListName = null;
            this.ctlPassword.Location = new System.Drawing.Point(116, 110);
            this.ctlPassword.Name = "ctlPassword";
            this.ctlPassword.SimpleList = "";
            this.ctlPassword.Size = new System.Drawing.Size(111, 44);
            this.ctlPassword.TabIndex = 5;
            this.ctlPassword.UseParentBackColor = false;
            this.ctlPassword.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlPassword.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlPassword.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlPassword.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlPassword.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctlPassword.zz_OriginalDesign = true;
            this.ctlPassword.zz_ShowNeedsSaveColor = true;
            this.ctlPassword.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlPassword.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlPassword.zz_UseGlobalColor = false;
            this.ctlPassword.zz_UseGlobalFont = false;
            // 
            // lvSystems
            // 
            this.lvSystems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvSystems.Location = new System.Drawing.Point(4, 159);
            this.lvSystems.Name = "lvSystems";
            this.lvSystems.Size = new System.Drawing.Size(541, 138);
            this.lvSystems.TabIndex = 6;
            this.lvSystems.UseCompatibleStateImageBehavior = false;
            this.lvSystems.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 529;
            // 
            // bg
            // 
            this.bg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_DoWork);
            this.bg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_RunWorkerCompleted);
            // 
            // lblCheck
            // 
            this.lblCheck.AutoSize = true;
            this.lblCheck.Location = new System.Drawing.Point(240, 141);
            this.lblCheck.Name = "lblCheck";
            this.lblCheck.Size = new System.Drawing.Size(37, 13);
            this.lblCheck.TabIndex = 7;
            this.lblCheck.TabStop = true;
            this.lblCheck.Text = "check";
            this.lblCheck.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCheck_LinkClicked);
            // 
            // frmSysFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 304);
            this.Controls.Add(this.lblCheck);
            this.Controls.Add(this.lvSystems);
            this.Controls.Add(this.ctlPassword);
            this.Controls.Add(this.ctlUser);
            this.Controls.Add(this.ctlServerName);
            this.Controls.Add(this.lblDatabase);
            this.Controls.Add(this.lblXML);
            this.Controls.Add(this.ctlSysName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSysFinder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "System Finder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private nEdit_List ctlSysName;
        private System.Windows.Forms.LinkLabel lblXML;
        private System.Windows.Forms.LinkLabel lblDatabase;
        private nEdit_List ctlServerName;
        private nEdit_List ctlUser;
        private nEdit_List ctlPassword;
        private System.Windows.Forms.ListView lvSystems;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.ComponentModel.BackgroundWorker bg;
        private System.Windows.Forms.LinkLabel lblCheck;
    }
}