namespace NewMethod.Original.nEdits
{
    partial class nEdit_Picture
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
            this.pic = new System.Windows.Forms.PictureBox();
            this.lblSet = new System.Windows.Forms.LinkLabel();
            this.lblClear = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // picInfo
            // 
            this.picInfo.Location = new System.Drawing.Point(309, 0);
            // 
            // pic
            // 
            this.pic.Location = new System.Drawing.Point(8, 26);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(301, 155);
            this.pic.TabIndex = 3;
            this.pic.TabStop = false;
            // 
            // lblSet
            // 
            this.lblSet.AutoSize = true;
            this.lblSet.Location = new System.Drawing.Point(111, 4);
            this.lblSet.Name = "lblSet";
            this.lblSet.Size = new System.Drawing.Size(21, 13);
            this.lblSet.TabIndex = 4;
            this.lblSet.TabStop = true;
            this.lblSet.Text = "set";
            this.lblSet.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSet_LinkClicked);
            // 
            // lblClear
            // 
            this.lblClear.AutoSize = true;
            this.lblClear.Location = new System.Drawing.Point(132, 4);
            this.lblClear.Name = "lblClear";
            this.lblClear.Size = new System.Drawing.Size(30, 13);
            this.lblClear.TabIndex = 5;
            this.lblClear.TabStop = true;
            this.lblClear.Text = "clear";
            this.lblClear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblClear_LinkClicked);
            // 
            // nEdit_Picture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.lblClear);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.lblSet);
            this.Name = "nEdit_Picture";
            this.Size = new System.Drawing.Size(325, 196);
            this.Controls.SetChildIndex(this.lblSet, 0);
            this.Controls.SetChildIndex(this.pic, 0);
            this.Controls.SetChildIndex(this.lblCaption, 0);
            this.Controls.SetChildIndex(this.picInfo, 0);
            this.Controls.SetChildIndex(this.picError, 0);
            this.Controls.SetChildIndex(this.lblClear, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.LinkLabel lblSet;
        private System.Windows.Forms.LinkLabel lblClear;
    }
}
