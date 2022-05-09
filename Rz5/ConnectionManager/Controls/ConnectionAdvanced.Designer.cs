namespace ConnectionManager
{
    partial class ConnectionAdvanced
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionAdvanced));
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtDatabaseName = new System.Windows.Forms.TextBox();
            this.lblDatabaseName = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bgIsInstalled = new System.ComponentModel.BackgroundWorker();
            this.bgRemoteConnection = new System.ComponentModel.BackgroundWorker();
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.lnkRestore = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(6, 17);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(214, 20);
            this.txtServer.TabIndex = 39;
            this.txtServer.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.Location = new System.Drawing.Point(4, 106);
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.Size = new System.Drawing.Size(216, 20);
            this.txtDatabaseName.TabIndex = 46;
            this.txtDatabaseName.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // lblDatabaseName
            // 
            this.lblDatabaseName.AutoSize = true;
            this.lblDatabaseName.Location = new System.Drawing.Point(3, 90);
            this.lblDatabaseName.Name = "lblDatabaseName";
            this.lblDatabaseName.Size = new System.Drawing.Size(87, 13);
            this.lblDatabaseName.TabIndex = 45;
            this.lblDatabaseName.Text = "Database Name:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(122, 60);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(98, 20);
            this.txtPassword.TabIndex = 42;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "Password:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(4, 60);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(98, 20);
            this.txtUserName.TabIndex = 41;
            this.txtUserName.Text = "sa";
            this.txtUserName.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(3, 44);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(63, 13);
            this.lblUserName.TabIndex = 43;
            this.lblUserName.Text = "User Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Server Name:";
            // 
            // il
            // 
            this.il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il.ImageStream")));
            this.il.TransparentColor = System.Drawing.Color.Magenta;
            this.il.Images.SetKeyName(0, "Unknown");
            this.il.Images.SetKeyName(1, "done");
            this.il.Images.SetKeyName(2, "warning");
            // 
            // lnkRestore
            // 
            this.lnkRestore.AutoSize = true;
            this.lnkRestore.Location = new System.Drawing.Point(127, 90);
            this.lnkRestore.Name = "lnkRestore";
            this.lnkRestore.Size = new System.Drawing.Size(93, 13);
            this.lnkRestore.TabIndex = 47;
            this.lnkRestore.TabStop = true;
            this.lnkRestore.Text = "Restore Database";
            this.lnkRestore.Visible = false;
            this.lnkRestore.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRestore_LinkClicked);
            // 
            // ConnectionAdvanced
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.lnkRestore);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.txtDatabaseName);
            this.Controls.Add(this.lblDatabaseName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.label1);
            this.Name = "ConnectionAdvanced";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblUserName, 0);
            this.Controls.SetChildIndex(this.txtUserName, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtPassword, 0);
            this.Controls.SetChildIndex(this.lblDatabaseName, 0);
            this.Controls.SetChildIndex(this.txtDatabaseName, 0);
            this.Controls.SetChildIndex(this.txtServer, 0);
            this.Controls.SetChildIndex(this.lnkRestore, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtDatabaseName;
        private System.Windows.Forms.Label lblDatabaseName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker bgIsInstalled;
        private System.ComponentModel.BackgroundWorker bgRemoteConnection;
        private System.Windows.Forms.ImageList il;
        private System.Windows.Forms.LinkLabel lnkRestore;
    }
}
