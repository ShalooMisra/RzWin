namespace ConnectionManager
{
    partial class SQLExpCheckDialog
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
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.gbLocal = new System.Windows.Forms.GroupBox();
            this.cpDatabase = new ConnectionManager.CheckPoint();
            this.cpLocalConnection = new ConnectionManager.CheckPoint();
            this.cpServer = new ConnectionManager.CheckPoint();
            this.gbRemote = new System.Windows.Forms.GroupBox();
            this.cpConnectExternal = new ConnectionManager.CheckPoint();
            this.bgIsInstalled = new System.ComponentModel.BackgroundWorker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtDatabaseName = new System.Windows.Forms.TextBox();
            this.lblDatabaseName = new System.Windows.Forms.Label();
            this.bgRemoteConnection = new System.ComponentModel.BackgroundWorker();
            this.cmdOpenRz3 = new System.Windows.Forms.Button();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.lblComplete = new System.Windows.Forms.Label();
            this.pic = new System.Windows.Forms.PictureBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.gbLocal.SuspendLayout();
            this.gbRemote.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(3, 138);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(98, 20);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.Text = "sa";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(2, 122);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(63, 13);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "User Name:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(121, 138);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(98, 20);
            this.txtPassword.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password:";
            // 
            // cmdOK
            // 
            this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOK.Location = new System.Drawing.Point(97, 210);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(122, 41);
            this.cmdOK.TabIndex = 3;
            this.cmdOK.Text = "&Save";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(1, 221);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(88, 23);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // gbLocal
            // 
            this.gbLocal.Controls.Add(this.cpDatabase);
            this.gbLocal.Controls.Add(this.cpLocalConnection);
            this.gbLocal.Controls.Add(this.cpServer);
            this.gbLocal.Location = new System.Drawing.Point(234, 113);
            this.gbLocal.Name = "gbLocal";
            this.gbLocal.Size = new System.Drawing.Size(509, 260);
            this.gbLocal.TabIndex = 18;
            this.gbLocal.TabStop = false;
            this.gbLocal.Text = "Local Connection Help";
            // 
            // cpDatabase
            // 
            this.cpDatabase.BackColor = System.Drawing.Color.White;
            this.cpDatabase.Location = new System.Drawing.Point(7, 176);
            this.cpDatabase.Name = "cpDatabase";
            this.cpDatabase.Size = new System.Drawing.Size(492, 75);
            this.cpDatabase.TabIndex = 19;
            this.cpDatabase.LinkClicked += new ConnectionManager.CheckPointLinkClickHandler(this.cpDatabase_LinkClicked);
            // 
            // cpLocalConnection
            // 
            this.cpLocalConnection.BackColor = System.Drawing.Color.White;
            this.cpLocalConnection.Location = new System.Drawing.Point(7, 93);
            this.cpLocalConnection.Name = "cpLocalConnection";
            this.cpLocalConnection.Size = new System.Drawing.Size(492, 70);
            this.cpLocalConnection.TabIndex = 18;
            this.cpLocalConnection.Load += new System.EventHandler(this.cpLocalConnection_Load);
            // 
            // cpServer
            // 
            this.cpServer.BackColor = System.Drawing.Color.White;
            this.cpServer.Location = new System.Drawing.Point(6, 19);
            this.cpServer.Name = "cpServer";
            this.cpServer.Size = new System.Drawing.Size(492, 68);
            this.cpServer.TabIndex = 17;
            // 
            // gbRemote
            // 
            this.gbRemote.Controls.Add(this.cpConnectExternal);
            this.gbRemote.Location = new System.Drawing.Point(235, 112);
            this.gbRemote.Name = "gbRemote";
            this.gbRemote.Size = new System.Drawing.Size(508, 97);
            this.gbRemote.TabIndex = 19;
            this.gbRemote.TabStop = false;
            this.gbRemote.Text = "External Conection Help";
            // 
            // cpConnectExternal
            // 
            this.cpConnectExternal.BackColor = System.Drawing.Color.White;
            this.cpConnectExternal.Location = new System.Drawing.Point(5, 19);
            this.cpConnectExternal.Name = "cpConnectExternal";
            this.cpConnectExternal.Size = new System.Drawing.Size(497, 71);
            this.cpConnectExternal.TabIndex = 17;
            // 
            // bgIsInstalled
            // 
            this.bgIsInstalled.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgIsInstalled_DoWork);
            this.bgIsInstalled.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgIsInstalled_RunWorkerCompleted);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(238, 65);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 13);
            this.lblStatus.TabIndex = 20;
            this.lblStatus.Text = "<status>";
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.Location = new System.Drawing.Point(3, 184);
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.Size = new System.Drawing.Size(216, 20);
            this.txtDatabaseName.TabIndex = 22;
            // 
            // lblDatabaseName
            // 
            this.lblDatabaseName.AutoSize = true;
            this.lblDatabaseName.Location = new System.Drawing.Point(2, 168);
            this.lblDatabaseName.Name = "lblDatabaseName";
            this.lblDatabaseName.Size = new System.Drawing.Size(87, 13);
            this.lblDatabaseName.TabIndex = 21;
            this.lblDatabaseName.Text = "Database Name:";
            // 
            // bgRemoteConnection
            // 
            this.bgRemoteConnection.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgRemoteConnection_DoWork);
            this.bgRemoteConnection.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgRemoteConnection_RunWorkerCompleted);
            // 
            // cmdOpenRz3
            // 
            this.cmdOpenRz3.Location = new System.Drawing.Point(1, 323);
            this.cmdOpenRz3.Name = "cmdOpenRz3";
            this.cmdOpenRz3.Size = new System.Drawing.Size(218, 48);
            this.cmdOpenRz3.TabIndex = 23;
            this.cmdOpenRz3.Text = "&Open Rz3";
            this.cmdOpenRz3.UseVisualStyleBackColor = true;
            this.cmdOpenRz3.Visible = false;
            this.cmdOpenRz3.Click += new System.EventHandler(this.cmdOpenRz3_Click);
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(5, 84);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(342, 18);
            this.pb.TabIndex = 24;
            // 
            // il
            // 
            this.il.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.il.ImageSize = new System.Drawing.Size(16, 16);
            this.il.TransparentColor = System.Drawing.Color.Magenta;
            // 
            // lblComplete
            // 
            this.lblComplete.AutoSize = true;
            this.lblComplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComplete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblComplete.Location = new System.Drawing.Point(92, 279);
            this.lblComplete.Name = "lblComplete";
            this.lblComplete.Size = new System.Drawing.Size(122, 25);
            this.lblComplete.TabIndex = 26;
            this.lblComplete.Text = "Connected!";
            this.lblComplete.Click += new System.EventHandler(this.lblComplete_Click);
            // 
            // pic
            // 
            this.pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic.Location = new System.Drawing.Point(20, 262);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(56, 55);
            this.pic.TabIndex = 25;
            this.pic.TabStop = false;
            this.pic.Click += new System.EventHandler(this.pic_Click);
            // 
            // picLogo
            // 
            this.picLogo.BackgroundImage = global::ConnectionManager.Properties.Resources.recognin_logo;
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picLogo.Location = new System.Drawing.Point(5, 7);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(223, 71);
            this.picLogo.TabIndex = 12;
            this.picLogo.TabStop = false;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(353, 81);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(82, 24);
            this.cancelButton.TabIndex = 27;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // SQLExpCheckDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(440, 110);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.gbLocal);
            this.Controls.Add(this.lblComplete);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.cmdOpenRz3);
            this.Controls.Add(this.txtDatabaseName);
            this.Controls.Add(this.lblDatabaseName);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.gbRemote);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblUserName);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SQLExpCheckDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmConnect_KeyPress);
            this.gbLocal.ResumeLayout(false);
            this.gbRemote.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.PictureBox picLogo;
        private CheckPoint cpServer;
        private System.Windows.Forms.GroupBox gbLocal;
        private System.Windows.Forms.GroupBox gbRemote;
        private CheckPoint cpConnectExternal;
        private System.ComponentModel.BackgroundWorker bgIsInstalled;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtDatabaseName;
        private System.Windows.Forms.Label lblDatabaseName;
        private System.ComponentModel.BackgroundWorker bgRemoteConnection;
        private System.Windows.Forms.Button cmdOpenRz3;
        private CheckPoint cpLocalConnection;
        private CheckPoint cpDatabase;
        private System.Windows.Forms.ProgressBar pb;
        private System.Windows.Forms.ImageList il;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Label lblComplete;
        private System.Windows.Forms.Button cancelButton;
    }
}

