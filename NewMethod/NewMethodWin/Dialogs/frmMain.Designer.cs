namespace NewMethod
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.SuspendLayout();
            // 
            // il24
            // 
            this.il24.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il24.ImageStream")));
            this.il24.Images.SetKeyName(0, "Exit");
            this.il24.Images.SetKeyName(1, "Back");
            this.il24.Images.SetKeyName(2, "SQL");
            this.il24.Images.SetKeyName(3, "Import");
            this.il24.Images.SetKeyName(4, "Tools");
            this.il24.Images.SetKeyName(5, "Table");
            this.il24.Images.SetKeyName(6, "Target");
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 604);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}