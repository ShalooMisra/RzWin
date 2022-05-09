namespace NewMethod
{
    partial class nEdit_Modified
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
            this.lblCreated = new System.Windows.Forms.Label();
            this.lblModified = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).BeginInit();
            this.SuspendLayout();
            // 
            // picInfo
            // 
            this.picInfo.Location = new System.Drawing.Point(282, 0);
            // 
            // lblCreated
            // 
            this.lblCreated.AutoSize = true;
            this.lblCreated.Location = new System.Drawing.Point(10, 8);
            this.lblCreated.Name = "lblCreated";
            this.lblCreated.Size = new System.Drawing.Size(55, 13);
            this.lblCreated.TabIndex = 3;
            this.lblCreated.Text = "<created>";
            // 
            // lblModified
            // 
            this.lblModified.AutoSize = true;
            this.lblModified.Location = new System.Drawing.Point(10, 21);
            this.lblModified.Name = "lblModified";
            this.lblModified.Size = new System.Drawing.Size(58, 13);
            this.lblModified.TabIndex = 4;
            this.lblModified.Text = "<modified>";
            // 
            // nEdit_Modified
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.lblModified);
            this.Controls.Add(this.lblCreated);
            this.Name = "nEdit_Modified";
            this.Size = new System.Drawing.Size(298, 43);
            this.Resize += new System.EventHandler(this.nEdit_Modified_Resize);
            this.Controls.SetChildIndex(this.picInfo, 0);
            this.Controls.SetChildIndex(this.picError, 0);
            this.Controls.SetChildIndex(this.lblCreated, 0);
            this.Controls.SetChildIndex(this.lblCaption, 0);
            this.Controls.SetChildIndex(this.lblModified, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCreated;
        private System.Windows.Forms.Label lblModified;
    }
}
