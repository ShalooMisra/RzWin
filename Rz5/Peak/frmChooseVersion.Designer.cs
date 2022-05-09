namespace Peak
{
    partial class frmChooseVersion
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
                CompleteDispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChooseVersion));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.fp = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCompleteDelete = new System.Windows.Forms.LinkLabel();
            this.lblLatestVersion = new System.Windows.Forms.Label();
            this.lblPrevious = new System.Windows.Forms.Label();
            this.vp = new Peak.VersionPane();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(2, 417);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(365, 44);
            this.cmdCancel.TabIndex = 0;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // fp
            // 
            this.fp.AutoScroll = true;
            this.fp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fp.Location = new System.Drawing.Point(2, 188);
            this.fp.Name = "fp";
            this.fp.Size = new System.Drawing.Size(365, 207);
            this.fp.TabIndex = 1;
            this.fp.WrapContents = false;
            // 
            // lblCompleteDelete
            // 
            this.lblCompleteDelete.AutoSize = true;
            this.lblCompleteDelete.Location = new System.Drawing.Point(75, 162);
            this.lblCompleteDelete.Name = "lblCompleteDelete";
            this.lblCompleteDelete.Size = new System.Drawing.Size(210, 13);
            this.lblCompleteDelete.TabIndex = 2;
            this.lblCompleteDelete.TabStop = true;
            this.lblCompleteDelete.Text = "Completely remove all but the latest version";
            this.lblCompleteDelete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCompleteDelete_LinkClicked);
            // 
            // lblLatestVersion
            // 
            this.lblLatestVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatestVersion.Location = new System.Drawing.Point(2, 7);
            this.lblLatestVersion.Name = "lblLatestVersion";
            this.lblLatestVersion.Size = new System.Drawing.Size(365, 33);
            this.lblLatestVersion.TabIndex = 4;
            this.lblLatestVersion.Text = "Latest Version:";
            this.lblLatestVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPrevious
            // 
            this.lblPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrevious.Location = new System.Drawing.Point(2, 129);
            this.lblPrevious.Name = "lblPrevious";
            this.lblPrevious.Size = new System.Drawing.Size(365, 33);
            this.lblPrevious.TabIndex = 5;
            this.lblPrevious.Text = "Previous Versions:";
            this.lblPrevious.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // vp
            // 
            this.vp.BackColor = System.Drawing.Color.White;
            this.vp.Location = new System.Drawing.Point(2, 43);
            this.vp.Name = "vp";
            this.vp.Size = new System.Drawing.Size(324, 83);
            this.vp.TabIndex = 3;
            this.vp.VersionSelected += new System.EventHandler(this.p_VersionSelected);
            // 
            // frmChooseVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(369, 464);
            this.Controls.Add(this.vp);
            this.Controls.Add(this.lblPrevious);
            this.Controls.Add(this.lblLatestVersion);
            this.Controls.Add(this.lblCompleteDelete);
            this.Controls.Add(this.fp);
            this.Controls.Add(this.cmdCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChooseVersion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rz Versions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.FlowLayoutPanel fp;
        private System.Windows.Forms.LinkLabel lblCompleteDelete;
        private VersionPane vp;
        private System.Windows.Forms.Label lblLatestVersion;
        private System.Windows.Forms.Label lblPrevious;
    }
}