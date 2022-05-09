namespace Rz5.Win.Controls
{
    partial class ReportCriteriaControl
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
            this.lblCaption = new System.Windows.Forms.Label();
            this.picTop = new System.Windows.Forms.PictureBox();
            this.pic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.Location = new System.Drawing.Point(32, 8);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(73, 19);
            this.lblCaption.TabIndex = 0;
            this.lblCaption.Text = "<caption>";
            // 
            // picTop
            // 
            this.picTop.BackColor = System.Drawing.Color.Silver;
            this.picTop.Location = new System.Drawing.Point(1, 1);
            this.picTop.Name = "picTop";
            this.picTop.Size = new System.Drawing.Size(183, 4);
            this.picTop.TabIndex = 1;
            this.picTop.TabStop = false;
            // 
            // pic
            // 
            this.pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic.Location = new System.Drawing.Point(2, 8);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(24, 24);
            this.pic.TabIndex = 2;
            this.pic.TabStop = false;
            // 
            // ReportCriteriaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pic);
            this.Controls.Add(this.picTop);
            this.Controls.Add(this.lblCaption);
            this.Name = "ReportCriteriaControl";
            this.Size = new System.Drawing.Size(203, 199);
            this.Resize += new System.EventHandler(this.ReportCriteriaControl_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.PictureBox picTop;
        protected System.Windows.Forms.PictureBox pic;
    }
}
