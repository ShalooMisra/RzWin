namespace NewMethod
{
    partial class nWorkBench
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
            this.cmdImportDataSources = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdImportDataSources
            // 
            this.cmdImportDataSources.Location = new System.Drawing.Point(5, 6);
            this.cmdImportDataSources.Name = "cmdImportDataSources";
            this.cmdImportDataSources.Size = new System.Drawing.Size(148, 22);
            this.cmdImportDataSources.TabIndex = 0;
            this.cmdImportDataSources.Text = "Import Local Data Sources";
            this.cmdImportDataSources.UseVisualStyleBackColor = true;
            this.cmdImportDataSources.Click += new System.EventHandler(this.cmdImportDataSources_Click);
            // 
            // nWorkBench
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdImportDataSources);
            this.Name = "nWorkBench";
            this.Size = new System.Drawing.Size(467, 454);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdImportDataSources;
    }
}
