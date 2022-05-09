namespace Peak
{
    partial class VersionPane
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.cmdOpen = new System.Windows.Forms.Button();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblRemove = new System.Windows.Forms.LinkLabel();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.pbRight = new System.Windows.Forms.PictureBox();
            this.pbLeft = new System.Windows.Forms.PictureBox();
            this.pbBottom = new System.Windows.Forms.PictureBox();
            this.pbTop = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(55, 7);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(69, 20);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "<Name>";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(53, 29);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(94, 13);
            this.lblVersion.TabIndex = 10;
            this.lblVersion.Text = "Version: <version>";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(53, 44);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(69, 13);
            this.lblDate.TabIndex = 11;
            this.lblDate.Text = "Date: <date>";
            // 
            // cmdOpen
            // 
            this.cmdOpen.Location = new System.Drawing.Point(241, 10);
            this.cmdOpen.Name = "cmdOpen";
            this.cmdOpen.Size = new System.Drawing.Size(73, 63);
            this.cmdOpen.TabIndex = 12;
            this.cmdOpen.Text = "Open";
            this.cmdOpen.UseVisualStyleBackColor = true;
            this.cmdOpen.Click += new System.EventHandler(this.cmdOpen_Click);
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(53, 60);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(63, 13);
            this.lblSize.TabIndex = 13;
            this.lblSize.Text = "Size: <size>";
            // 
            // lblRemove
            // 
            this.lblRemove.AutoSize = true;
            this.lblRemove.Location = new System.Drawing.Point(6, 62);
            this.lblRemove.Name = "lblRemove";
            this.lblRemove.Size = new System.Drawing.Size(42, 13);
            this.lblRemove.TabIndex = 14;
            this.lblRemove.TabStop = true;
            this.lblRemove.Text = "remove";
            this.lblRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRemove_LinkClicked);
            // 
            // picIcon
            // 
            this.picIcon.BackgroundImage = global::Peak.Properties.Resources.RzMid;
            this.picIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picIcon.Location = new System.Drawing.Point(8, 7);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(43, 38);
            this.picIcon.TabIndex = 8;
            this.picIcon.TabStop = false;
            // 
            // pbRight
            // 
            this.pbRight.BackColor = System.Drawing.Color.Blue;
            this.pbRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbRight.Location = new System.Drawing.Point(320, 4);
            this.pbRight.Name = "pbRight";
            this.pbRight.Size = new System.Drawing.Size(4, 75);
            this.pbRight.TabIndex = 7;
            this.pbRight.TabStop = false;
            // 
            // pbLeft
            // 
            this.pbLeft.BackColor = System.Drawing.Color.Blue;
            this.pbLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbLeft.Location = new System.Drawing.Point(0, 4);
            this.pbLeft.Name = "pbLeft";
            this.pbLeft.Size = new System.Drawing.Size(4, 75);
            this.pbLeft.TabIndex = 6;
            this.pbLeft.TabStop = false;
            // 
            // pbBottom
            // 
            this.pbBottom.BackColor = System.Drawing.Color.Blue;
            this.pbBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbBottom.Location = new System.Drawing.Point(0, 79);
            this.pbBottom.Name = "pbBottom";
            this.pbBottom.Size = new System.Drawing.Size(324, 4);
            this.pbBottom.TabIndex = 5;
            this.pbBottom.TabStop = false;
            // 
            // pbTop
            // 
            this.pbTop.BackColor = System.Drawing.Color.Blue;
            this.pbTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbTop.Location = new System.Drawing.Point(0, 0);
            this.pbTop.Name = "pbTop";
            this.pbTop.Size = new System.Drawing.Size(324, 4);
            this.pbTop.TabIndex = 4;
            this.pbTop.TabStop = false;
            // 
            // VersionPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblRemove);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.cmdOpen);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picIcon);
            this.Controls.Add(this.pbRight);
            this.Controls.Add(this.pbLeft);
            this.Controls.Add(this.pbBottom);
            this.Controls.Add(this.pbTop);
            this.Name = "VersionPane";
            this.Size = new System.Drawing.Size(324, 83);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbRight;
        private System.Windows.Forms.PictureBox pbLeft;
        private System.Windows.Forms.PictureBox pbBottom;
        private System.Windows.Forms.PictureBox pbTop;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button cmdOpen;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.LinkLabel lblRemove;
    }
}
