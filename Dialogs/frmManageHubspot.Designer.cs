namespace NewMethod
{
    partial class frmManageHubspot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageHubspot));
            this.lblHSObjectTypeLabel = new System.Windows.Forms.Label();
            this.lblHSObjectIDLabel = new System.Windows.Forms.Label();
            this.txtObjectID = new System.Windows.Forms.TextBox();
            this.llHSObjectName = new System.Windows.Forms.LinkLabel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pbHSLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbHSLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHSObjectTypeLabel
            // 
            this.lblHSObjectTypeLabel.AutoSize = true;
            this.lblHSObjectTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHSObjectTypeLabel.Location = new System.Drawing.Point(115, 13);
            this.lblHSObjectTypeLabel.Name = "lblHSObjectTypeLabel";
            this.lblHSObjectTypeLabel.Size = new System.Drawing.Size(240, 24);
            this.lblHSObjectTypeLabel.TabIndex = 0;
            this.lblHSObjectTypeLabel.Text = "<Hubspot Object Name>";
            // 
            // lblHSObjectIDLabel
            // 
            this.lblHSObjectIDLabel.AutoSize = true;
            this.lblHSObjectIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHSObjectIDLabel.Location = new System.Drawing.Point(115, 51);
            this.lblHSObjectIDLabel.Name = "lblHSObjectIDLabel";
            this.lblHSObjectIDLabel.Size = new System.Drawing.Size(186, 24);
            this.lblHSObjectIDLabel.TabIndex = 1;
            this.lblHSObjectIDLabel.Text = "Hubspot Object ID:";
            // 
            // txtObjectID
            // 
            this.txtObjectID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObjectID.Location = new System.Drawing.Point(343, 48);
            this.txtObjectID.Name = "txtObjectID";
            this.txtObjectID.Size = new System.Drawing.Size(180, 29);
            this.txtObjectID.TabIndex = 3;
            // 
            // llHSObjectName
            // 
            this.llHSObjectName.AutoSize = true;
            this.llHSObjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llHSObjectName.Location = new System.Drawing.Point(339, 13);
            this.llHSObjectName.Name = "llHSObjectName";
            this.llHSObjectName.Size = new System.Drawing.Size(79, 24);
            this.llHSObjectName.TabIndex = 6;
            this.llHSObjectName.TabStop = true;
            this.llHSObjectName.Text = "<None>";
            this.llHSObjectName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llHSObjectName_LinkClicked);
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = global::RzInterfaceWin.Properties.Resources.error;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.Location = new System.Drawing.Point(599, 54);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(38, 36);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = global::RzInterfaceWin.Properties.Resources.saveHS_32;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.Location = new System.Drawing.Point(546, 54);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(38, 36);
            this.btnSave.TabIndex = 4;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pbHSLogo
            // 
            this.pbHSLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbHSLogo.BackgroundImage")));
            this.pbHSLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbHSLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbHSLogo.InitialImage")));
            this.pbHSLogo.Location = new System.Drawing.Point(7, 3);
            this.pbHSLogo.Name = "pbHSLogo";
            this.pbHSLogo.Size = new System.Drawing.Size(90, 90);
            this.pbHSLogo.TabIndex = 7;
            this.pbHSLogo.TabStop = false;
            // 
            // frmManageHubspot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 99);
            this.Controls.Add(this.pbHSLogo);
            this.Controls.Add(this.llHSObjectName);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtObjectID);
            this.Controls.Add(this.lblHSObjectIDLabel);
            this.Controls.Add(this.lblHSObjectTypeLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmManageHubspot";
            this.Text = "Manage Hubspot";
            ((System.ComponentModel.ISupportInitialize)(this.pbHSLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHSObjectTypeLabel;
        private System.Windows.Forms.Label lblHSObjectIDLabel;
        private System.Windows.Forms.TextBox txtObjectID;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.LinkLabel llHSObjectName;
        private System.Windows.Forms.PictureBox pbHSLogo;
    }
}