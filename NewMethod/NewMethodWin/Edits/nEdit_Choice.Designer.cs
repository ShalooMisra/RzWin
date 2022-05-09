namespace NewMethod
{
    partial class nEdit_Choice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(nEdit_Choice));
            this.LinkLabel = new System.Windows.Forms.LinkLabel();
            this.cboValue = new System.Windows.Forms.ComboBox();
            this.IM16 = new System.Windows.Forms.ImageList(this.components);
            this.pWeb = new System.Windows.Forms.PictureBox();
            this.pEmail = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pWeb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pEmail)).BeginInit();
            this.SuspendLayout();
            // 
            // picInfo
            // 
            this.picInfo.Location = new System.Drawing.Point(352, 0);
            // 
            // LinkLabel
            // 
            this.LinkLabel.Location = new System.Drawing.Point(89, 9);
            this.LinkLabel.Name = "LinkLabel";
            this.LinkLabel.Size = new System.Drawing.Size(266, 14);
            this.LinkLabel.TabIndex = 2;
            this.LinkLabel.TabStop = true;
            this.LinkLabel.Text = "LinkLabel";
            this.LinkLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.LinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_LinkClicked);
            // 
            // cboValue
            // 
            this.cboValue.FormattingEnabled = true;
            this.cboValue.Location = new System.Drawing.Point(8, 28);
            this.cboValue.Name = "cboValue";
            this.cboValue.Size = new System.Drawing.Size(347, 21);
            this.cboValue.TabIndex = 3;
            this.cboValue.Resize += new System.EventHandler(this.cboValue_Resize);
            this.cboValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboValue_KeyPress);
            this.cboValue.TextChanged += new System.EventHandler(this.cboValue_TextChanged);
            // 
            // IM16
            // 
            this.IM16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IM16.ImageStream")));
            this.IM16.TransparentColor = System.Drawing.Color.Fuchsia;
            this.IM16.Images.SetKeyName(0, "web");
            this.IM16.Images.SetKeyName(1, "email");
            // 
            // pWeb
            // 
            this.pWeb.BackColor = System.Drawing.Color.White;
            this.pWeb.Location = new System.Drawing.Point(109, 69);
            this.pWeb.Name = "pWeb";
            this.pWeb.Size = new System.Drawing.Size(17, 16);
            this.pWeb.TabIndex = 4;
            this.pWeb.TabStop = false;
            this.pWeb.Visible = false;
            this.pWeb.Click += new System.EventHandler(this.pWeb_Click);
            // 
            // pEmail
            // 
            this.pEmail.BackColor = System.Drawing.Color.White;
            this.pEmail.Location = new System.Drawing.Point(63, 69);
            this.pEmail.Name = "pEmail";
            this.pEmail.Size = new System.Drawing.Size(17, 19);
            this.pEmail.TabIndex = 5;
            this.pEmail.TabStop = false;
            this.pEmail.Visible = false;
            this.pEmail.Click += new System.EventHandler(this.pEmail_Click);
            // 
            // nEdit_Choice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.pEmail);
            this.Controls.Add(this.pWeb);
            this.Controls.Add(this.cboValue);
            this.Controls.Add(this.LinkLabel);
            this.Name = "nEdit_Choice";
            this.Size = new System.Drawing.Size(368, 96);
            this.Resize += new System.EventHandler(this.nEdit_Choice_Resize);
            this.Controls.SetChildIndex(this.lblCaption, 0);
            this.Controls.SetChildIndex(this.picInfo, 0);
            this.Controls.SetChildIndex(this.picError, 0);
            this.Controls.SetChildIndex(this.LinkLabel, 0);
            this.Controls.SetChildIndex(this.cboValue, 0);
            this.Controls.SetChildIndex(this.pWeb, 0);
            this.Controls.SetChildIndex(this.pEmail, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pWeb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pEmail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel LinkLabel;
        private System.Windows.Forms.ComboBox cboValue;
        private System.Windows.Forms.ImageList IM16;
        private System.Windows.Forms.PictureBox pWeb;
        private System.Windows.Forms.PictureBox pEmail;
    }
}
