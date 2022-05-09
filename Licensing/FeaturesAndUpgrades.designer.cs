namespace Rz5
{
    partial class FeaturesAndUpgrades
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
            this.gbLicense = new System.Windows.Forms.GroupBox();
            this.lblApplyLicense = new System.Windows.Forms.LinkLabel();
            this.lblLicenseExpiration = new System.Windows.Forms.Label();
            this.lblExpiration = new System.Windows.Forms.Label();
            this.lblLicenseType = new System.Windows.Forms.Label();
            this.lblLicenseTypeCap = new System.Windows.Forms.Label();
            this.txtLicenseID = new System.Windows.Forms.TextBox();
            this.lblLicenseKeyCap = new System.Windows.Forms.Label();
            this.gb = new System.Windows.Forms.GroupBox();
            this.lblCurrentVersion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLatestVersion = new System.Windows.Forms.Label();
            this.lblLatestVersionCap = new System.Windows.Forms.Label();
            this.lblUpdate = new System.Windows.Forms.LinkLabel();
            this.status = new Tie.nEndlessStatusBox();
            this.wb = new ToolsWin.BrowserPlain();
            this.gbLicense.SuspendLayout();
            this.gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLicense
            // 
            this.gbLicense.Controls.Add(this.lblApplyLicense);
            this.gbLicense.Controls.Add(this.lblLicenseExpiration);
            this.gbLicense.Controls.Add(this.lblExpiration);
            this.gbLicense.Controls.Add(this.lblLicenseType);
            this.gbLicense.Controls.Add(this.lblLicenseTypeCap);
            this.gbLicense.Controls.Add(this.txtLicenseID);
            this.gbLicense.Controls.Add(this.lblLicenseKeyCap);
            this.gbLicense.Location = new System.Drawing.Point(0, 324);
            this.gbLicense.Name = "gbLicense";
            this.gbLicense.Size = new System.Drawing.Size(784, 77);
            this.gbLicense.TabIndex = 0;
            this.gbLicense.TabStop = false;
            this.gbLicense.Text = "Current License Status";
            // 
            // lblApplyLicense
            // 
            this.lblApplyLicense.AutoSize = true;
            this.lblApplyLicense.Location = new System.Drawing.Point(6, 57);
            this.lblApplyLicense.Name = "lblApplyLicense";
            this.lblApplyLicense.Size = new System.Drawing.Size(100, 13);
            this.lblApplyLicense.TabIndex = 7;
            this.lblApplyLicense.TabStop = true;
            this.lblApplyLicense.Text = "apply a new license";
            this.lblApplyLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblApplyLicense_LinkClicked);
            // 
            // lblLicenseExpiration
            // 
            this.lblLicenseExpiration.AutoSize = true;
            this.lblLicenseExpiration.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseExpiration.Location = new System.Drawing.Point(621, 34);
            this.lblLicenseExpiration.Name = "lblLicenseExpiration";
            this.lblLicenseExpiration.Size = new System.Drawing.Size(155, 24);
            this.lblLicenseExpiration.TabIndex = 5;
            this.lblLicenseExpiration.Text = "<expiration date>";
            // 
            // lblExpiration
            // 
            this.lblExpiration.AutoSize = true;
            this.lblExpiration.Location = new System.Drawing.Point(622, 18);
            this.lblExpiration.Name = "lblExpiration";
            this.lblExpiration.Size = new System.Drawing.Size(82, 13);
            this.lblExpiration.TabIndex = 4;
            this.lblExpiration.Text = "Expiration Date:";
            // 
            // lblLicenseType
            // 
            this.lblLicenseType.AutoSize = true;
            this.lblLicenseType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseType.Location = new System.Drawing.Point(437, 34);
            this.lblLicenseType.Name = "lblLicenseType";
            this.lblLicenseType.Size = new System.Drawing.Size(132, 24);
            this.lblLicenseType.TabIndex = 3;
            this.lblLicenseType.Text = "<license type>";
            // 
            // lblLicenseTypeCap
            // 
            this.lblLicenseTypeCap.AutoSize = true;
            this.lblLicenseTypeCap.Location = new System.Drawing.Point(438, 18);
            this.lblLicenseTypeCap.Name = "lblLicenseTypeCap";
            this.lblLicenseTypeCap.Size = new System.Drawing.Size(74, 13);
            this.lblLicenseTypeCap.TabIndex = 2;
            this.lblLicenseTypeCap.Text = "License Type:";
            // 
            // txtLicenseID
            // 
            this.txtLicenseID.BackColor = System.Drawing.Color.Gainsboro;
            this.txtLicenseID.Location = new System.Drawing.Point(6, 34);
            this.txtLicenseID.Name = "txtLicenseID";
            this.txtLicenseID.ReadOnly = true;
            this.txtLicenseID.Size = new System.Drawing.Size(404, 20);
            this.txtLicenseID.TabIndex = 1;
            // 
            // lblLicenseKeyCap
            // 
            this.lblLicenseKeyCap.AutoSize = true;
            this.lblLicenseKeyCap.Location = new System.Drawing.Point(6, 18);
            this.lblLicenseKeyCap.Name = "lblLicenseKeyCap";
            this.lblLicenseKeyCap.Size = new System.Drawing.Size(61, 13);
            this.lblLicenseKeyCap.TabIndex = 0;
            this.lblLicenseKeyCap.Text = "License ID:";
            // 
            // gb
            // 
            this.gb.Controls.Add(this.lblUpdate);
            this.gb.Controls.Add(this.lblLatestVersion);
            this.gb.Controls.Add(this.lblLatestVersionCap);
            this.gb.Controls.Add(this.lblCurrentVersion);
            this.gb.Controls.Add(this.label2);
            this.gb.Location = new System.Drawing.Point(0, 0);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(161, 87);
            this.gb.TabIndex = 2;
            this.gb.TabStop = false;
            this.gb.Text = "Version";
            // 
            // lblCurrentVersion
            // 
            this.lblCurrentVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentVersion.Location = new System.Drawing.Point(94, 12);
            this.lblCurrentVersion.Name = "lblCurrentVersion";
            this.lblCurrentVersion.Size = new System.Drawing.Size(60, 24);
            this.lblCurrentVersion.TabIndex = 5;
            this.lblCurrentVersion.Text = "10000";
            this.lblCurrentVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Current Version:";
            // 
            // lblLatestVersion
            // 
            this.lblLatestVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatestVersion.Location = new System.Drawing.Point(94, 36);
            this.lblLatestVersion.Name = "lblLatestVersion";
            this.lblLatestVersion.Size = new System.Drawing.Size(60, 24);
            this.lblLatestVersion.TabIndex = 7;
            this.lblLatestVersion.Text = "10000";
            this.lblLatestVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblLatestVersionCap
            // 
            this.lblLatestVersionCap.AutoSize = true;
            this.lblLatestVersionCap.Location = new System.Drawing.Point(7, 40);
            this.lblLatestVersionCap.Name = "lblLatestVersionCap";
            this.lblLatestVersionCap.Size = new System.Drawing.Size(77, 13);
            this.lblLatestVersionCap.TabIndex = 6;
            this.lblLatestVersionCap.Text = "Latest Version:";
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Location = new System.Drawing.Point(114, 60);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(40, 13);
            this.lblUpdate.TabIndex = 8;
            this.lblUpdate.TabStop = true;
            this.lblUpdate.Text = "update";
            this.lblUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblUpdate_LinkClicked);
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(0, 93);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(161, 225);
            this.status.TabIndex = 3;
            this.status.Text = "";
            // 
            // wb
            // 
            this.wb.Location = new System.Drawing.Point(167, 7);
            this.wb.Name = "wb";
            this.wb.Silent = false;
            this.wb.Size = new System.Drawing.Size(429, 311);
            this.wb.TabIndex = 1;
            this.wb.OnNavigate += new ToolsWin.OnNavigateHandler(this.wb_OnNavigate);
            // 
            // FeaturesAndUpgrades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.status);
            this.Controls.Add(this.gb);
            this.Controls.Add(this.wb);
            this.Controls.Add(this.gbLicense);
            this.Name = "FeaturesAndUpgrades";
            this.Size = new System.Drawing.Size(881, 499);
            this.Resize += new System.EventHandler(this.FeaturesAndUpgrades_Resize);
            this.gbLicense.ResumeLayout(false);
            this.gbLicense.PerformLayout();
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLicense;
        private System.Windows.Forms.Label lblLicenseExpiration;
        private System.Windows.Forms.Label lblExpiration;
        private System.Windows.Forms.Label lblLicenseType;
        private System.Windows.Forms.Label lblLicenseTypeCap;
        private System.Windows.Forms.TextBox txtLicenseID;
        private System.Windows.Forms.Label lblLicenseKeyCap;
        private System.Windows.Forms.LinkLabel lblApplyLicense;
        private ToolsWin.BrowserPlain wb;
        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.LinkLabel lblUpdate;
        private System.Windows.Forms.Label lblLatestVersion;
        private System.Windows.Forms.Label lblLatestVersionCap;
        private System.Windows.Forms.Label lblCurrentVersion;
        private System.Windows.Forms.Label label2;
        private Tie.nEndlessStatusBox status;
    }
}
