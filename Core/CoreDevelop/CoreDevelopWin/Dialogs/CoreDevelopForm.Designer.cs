namespace CoreDevelopWin.Dialogs
{
    partial class CoreDevelopForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CoreDevelopForm));
            this.SuspendLayout();
            // 
            // ts
            // 
            this.ts.Location = new System.Drawing.Point(0, 31);
            this.ts.Size = new System.Drawing.Size(1266, 770);
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
            // CoreDevelopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 823);
            this.Name = "CoreDevelopForm";
            this.Text = "CoreDevelopForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}