namespace NewMethod
{
    partial class nThrobber
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
            this.pbThrob = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbThrob)).BeginInit();
            this.SuspendLayout();
            // 
            // pbThrob
            // 
            this.pbThrob.Location = new System.Drawing.Point(0, 0);
            this.pbThrob.Name = "pbThrob";
            this.pbThrob.Size = new System.Drawing.Size(33, 27);
            this.pbThrob.TabIndex = 10;
            this.pbThrob.TabStop = false;
            // 
            // nThrobber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pbThrob);
            this.Name = "nThrobber";
            this.Size = new System.Drawing.Size(30, 27);
            ((System.ComponentModel.ISupportInitialize)(this.pbThrob)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbThrob;
    }
}
