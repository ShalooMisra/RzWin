namespace ConnectionManager
{
    partial class CheckPoint
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckPoint));
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.picCheck = new System.Windows.Forms.PictureBox();
            this.lblCaption = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblLink = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // il
            // 
            this.il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il.ImageStream")));
            this.il.TransparentColor = System.Drawing.Color.Magenta;
            this.il.Images.SetKeyName(0, "Unknown");
            this.il.Images.SetKeyName(1, "done");
            this.il.Images.SetKeyName(2, "warning");
            // 
            // picCheck
            // 
            this.picCheck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picCheck.Location = new System.Drawing.Point(3, 6);
            this.picCheck.Name = "picCheck";
            this.picCheck.Size = new System.Drawing.Size(24, 24);
            this.picCheck.TabIndex = 0;
            this.picCheck.TabStop = false;
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.Location = new System.Drawing.Point(38, 4);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(63, 13);
            this.lblCaption.TabIndex = 1;
            this.lblCaption.Text = "<caption>";
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(38, 19);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(457, 50);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "<message>";
            // 
            // lblLink
            // 
            this.lblLink.Location = new System.Drawing.Point(195, 0);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(300, 12);
            this.lblLink.TabIndex = 3;
            this.lblLink.TabStop = true;
            this.lblLink.Text = "<link>";
            this.lblLink.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLink_LinkClicked);
            // 
            // CheckPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.picCheck);
            this.Controls.Add(this.lblLink);
            this.Name = "CheckPoint";
            this.Size = new System.Drawing.Size(502, 76);
            ((System.ComponentModel.ISupportInitialize)(this.picCheck)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCheck;
        private System.Windows.Forms.ImageList il;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.LinkLabel lblLink;
    }
}
