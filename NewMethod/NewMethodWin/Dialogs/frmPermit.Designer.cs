namespace NewMethod
{
    partial class frmPermit
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
            this.lblPermit = new System.Windows.Forms.Label();
            this.tv = new System.Windows.Forms.TreeView();
            this.mnuTeam = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuSetTeam = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdOK = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblTeams = new System.Windows.Forms.Label();
            this.lblUserAccount = new System.Windows.Forms.Label();
            this.chkUser = new System.Windows.Forms.CheckBox();
            this.cmdBlockUser = new System.Windows.Forms.Button();
            this.cmdBlockTeam = new System.Windows.Forms.Button();
            this.cmdAllowUser = new System.Windows.Forms.Button();
            this.cmdAllowTeam = new System.Windows.Forms.Button();
            this.chkFastSelect = new System.Windows.Forms.CheckBox();
            this.mnuBlockTeam = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTeam.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPermit
            // 
            this.lblPermit.Location = new System.Drawing.Point(6, 26);
            this.lblPermit.Name = "lblPermit";
            this.lblPermit.Size = new System.Drawing.Size(466, 13);
            this.lblPermit.TabIndex = 0;
            this.lblPermit.Text = "< permission section : permission category : permission name >";
            this.lblPermit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tv
            // 
            this.tv.CheckBoxes = true;
            this.tv.ContextMenuStrip = this.mnuTeam;
            this.tv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tv.Location = new System.Drawing.Point(4, 55);
            this.tv.Name = "tv";
            this.tv.ShowPlusMinus = false;
            this.tv.Size = new System.Drawing.Size(469, 250);
            this.tv.TabIndex = 1;
            this.tv.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tv_AfterCheck);
            this.tv.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tv_MouseDown);
            // 
            // mnuTeam
            // 
            this.mnuTeam.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSetTeam,
            this.mnuBlockTeam});
            this.mnuTeam.Name = "mnuTeam";
            this.mnuTeam.Size = new System.Drawing.Size(110, 48);
            // 
            // mnuSetTeam
            // 
            this.mnuSetTeam.Name = "mnuSetTeam";
            this.mnuSetTeam.Size = new System.Drawing.Size(109, 22);
            this.mnuSetTeam.Text = "&Set";
            this.mnuSetTeam.Click += new System.EventHandler(this.mnuSetTeam_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(9, 354);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(72, 94);
            this.cmdOK.TabIndex = 0;
            this.cmdOK.Text = "&OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // lblUser
            // 
            this.lblUser.Location = new System.Drawing.Point(30, 7);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(418, 13);
            this.lblUser.TabIndex = 3;
            this.lblUser.Text = "< user name >";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTeams
            // 
            this.lblTeams.AutoSize = true;
            this.lblTeams.Location = new System.Drawing.Point(6, 39);
            this.lblTeams.Name = "lblTeams";
            this.lblTeams.Size = new System.Drawing.Size(42, 13);
            this.lblTeams.TabIndex = 4;
            this.lblTeams.Text = "Teams:";
            // 
            // lblUserAccount
            // 
            this.lblUserAccount.AutoSize = true;
            this.lblUserAccount.Location = new System.Drawing.Point(6, 308);
            this.lblUserAccount.Name = "lblUserAccount";
            this.lblUserAccount.Size = new System.Drawing.Size(75, 13);
            this.lblUserAccount.TabIndex = 5;
            this.lblUserAccount.Text = "User Account:";
            // 
            // chkUser
            // 
            this.chkUser.AutoSize = true;
            this.chkUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUser.Location = new System.Drawing.Point(12, 324);
            this.chkUser.Name = "chkUser";
            this.chkUser.Size = new System.Drawing.Size(85, 24);
            this.chkUser.TabIndex = 6;
            this.chkUser.Text = "Allow.....";
            this.chkUser.UseVisualStyleBackColor = true;
            this.chkUser.CheckedChanged += new System.EventHandler(this.chkUser_CheckedChanged);
            // 
            // cmdBlockUser
            // 
            this.cmdBlockUser.BackColor = System.Drawing.Color.Red;
            this.cmdBlockUser.Location = new System.Drawing.Point(87, 354);
            this.cmdBlockUser.Name = "cmdBlockUser";
            this.cmdBlockUser.Size = new System.Drawing.Size(194, 44);
            this.cmdBlockUser.TabIndex = 2;
            this.cmdBlockUser.Text = "&Block User";
            this.cmdBlockUser.UseVisualStyleBackColor = false;
            // 
            // cmdBlockTeam
            // 
            this.cmdBlockTeam.BackColor = System.Drawing.Color.Red;
            this.cmdBlockTeam.Location = new System.Drawing.Point(287, 354);
            this.cmdBlockTeam.Name = "cmdBlockTeam";
            this.cmdBlockTeam.Size = new System.Drawing.Size(194, 44);
            this.cmdBlockTeam.TabIndex = 8;
            this.cmdBlockTeam.Text = "&Block Team";
            this.cmdBlockTeam.UseVisualStyleBackColor = false;
            this.cmdBlockTeam.Click += new System.EventHandler(this.cmdBlockTeam_Click);
            // 
            // cmdAllowUser
            // 
            this.cmdAllowUser.BackColor = System.Drawing.Color.Lime;
            this.cmdAllowUser.Location = new System.Drawing.Point(87, 404);
            this.cmdAllowUser.Name = "cmdAllowUser";
            this.cmdAllowUser.Size = new System.Drawing.Size(194, 44);
            this.cmdAllowUser.TabIndex = 1;
            this.cmdAllowUser.Text = "&Allow User";
            this.cmdAllowUser.UseVisualStyleBackColor = false;
            this.cmdAllowUser.Click += new System.EventHandler(this.cmdAllowUser_Click);
            // 
            // cmdAllowTeam
            // 
            this.cmdAllowTeam.BackColor = System.Drawing.Color.Lime;
            this.cmdAllowTeam.Enabled = false;
            this.cmdAllowTeam.Location = new System.Drawing.Point(287, 404);
            this.cmdAllowTeam.Name = "cmdAllowTeam";
            this.cmdAllowTeam.Size = new System.Drawing.Size(194, 44);
            this.cmdAllowTeam.TabIndex = 10;
            this.cmdAllowTeam.Text = "&Allow Team";
            this.cmdAllowTeam.UseVisualStyleBackColor = false;
            this.cmdAllowTeam.Click += new System.EventHandler(this.cmdAllowTeam_Click);
            // 
            // chkFastSelect
            // 
            this.chkFastSelect.AutoSize = true;
            this.chkFastSelect.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFastSelect.Checked = true;
            this.chkFastSelect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFastSelect.Location = new System.Drawing.Point(426, 308);
            this.chkFastSelect.Name = "chkFastSelect";
            this.chkFastSelect.Size = new System.Drawing.Size(46, 17);
            this.chkFastSelect.TabIndex = 11;
            this.chkFastSelect.Text = "Fast";
            this.chkFastSelect.UseVisualStyleBackColor = true;
            // 
            // mnuBlockTeam
            // 
            this.mnuBlockTeam.Name = "mnuBlockTeam";
            this.mnuBlockTeam.Size = new System.Drawing.Size(109, 22);
            this.mnuBlockTeam.Text = "&Block";
            this.mnuBlockTeam.Click += new System.EventHandler(this.mnuBlockTeam_Click);
            // 
            // frmPermit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 455);
            this.ControlBox = false;
            this.Controls.Add(this.chkFastSelect);
            this.Controls.Add(this.cmdAllowTeam);
            this.Controls.Add(this.cmdAllowUser);
            this.Controls.Add(this.cmdBlockTeam);
            this.Controls.Add(this.cmdBlockUser);
            this.Controls.Add(this.chkUser);
            this.Controls.Add(this.lblUserAccount);
            this.Controls.Add(this.lblTeams);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.tv);
            this.Controls.Add(this.lblPermit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPermit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Permission Manager";
            this.mnuTeam.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPermit;
        private System.Windows.Forms.TreeView tv;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblTeams;
        private System.Windows.Forms.Label lblUserAccount;
        private System.Windows.Forms.CheckBox chkUser;
        private System.Windows.Forms.Button cmdBlockUser;
        private System.Windows.Forms.Button cmdBlockTeam;
        private System.Windows.Forms.ContextMenuStrip mnuTeam;
        private System.Windows.Forms.ToolStripMenuItem mnuSetTeam;
        private System.Windows.Forms.Button cmdAllowUser;
        private System.Windows.Forms.Button cmdAllowTeam;
        private System.Windows.Forms.CheckBox chkFastSelect;
        private System.Windows.Forms.ToolStripMenuItem mnuBlockTeam;
    }
}