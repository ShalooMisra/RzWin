namespace NewMethod
{
    partial class AsyncWait
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

                if (pbThrob.Image != null)
                {
                    pbThrob.Image.Dispose();
                    pbThrob.Image = null;
                }
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
            this.gb = new System.Windows.Forms.GroupBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.pbThrob = new System.Windows.Forms.PictureBox();
            this.lblCaption = new System.Windows.Forms.Label();
            this.gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbThrob)).BeginInit();
            this.SuspendLayout();
            // 
            // gb
            // 
            this.gb.BackColor = System.Drawing.Color.White;
            this.gb.Controls.Add(this.cmdCancel);
            this.gb.Controls.Add(this.lblCaption);
            this.gb.Controls.Add(this.pbThrob);
            this.gb.Controls.Add(this.lblDuration);
            this.gb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb.Location = new System.Drawing.Point(0, 0);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(508, 393);
            this.gb.TabIndex = 0;
            this.gb.TabStop = false;
            // 
            // lblDuration
            // 
            this.lblDuration.ForeColor = System.Drawing.Color.Silver;
            this.lblDuration.Location = new System.Drawing.Point(56, 46);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(419, 133);
            this.lblDuration.TabIndex = 0;
            this.lblDuration.Text = "<duration>";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(6, 43);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(43, 22);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "Stop";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // pbThrob
            // 
            this.pbThrob.Location = new System.Drawing.Point(6, 15);
            this.pbThrob.Name = "pbThrob";
            this.pbThrob.Size = new System.Drawing.Size(39, 33);
            this.pbThrob.TabIndex = 2;
            this.pbThrob.TabStop = false;
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.ForeColor = System.Drawing.Color.Silver;
            this.lblCaption.Location = new System.Drawing.Point(40, 17);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(93, 24);
            this.lblCaption.TabIndex = 3;
            this.lblCaption.Text = "<caption>";
            // 
            // AsyncWait
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb);
            this.Name = "AsyncWait";
            this.Size = new System.Drawing.Size(508, 393);
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbThrob)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.PictureBox pbThrob;
        private System.Windows.Forms.Label lblCaption;
    }
}
