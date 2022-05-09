namespace TieServerTest
{
    partial class frmTest2
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
            this.cmdFTPTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdFTPTest
            // 
            this.cmdFTPTest.Location = new System.Drawing.Point(8, 5);
            this.cmdFTPTest.Name = "cmdFTPTest";
            this.cmdFTPTest.Size = new System.Drawing.Size(95, 37);
            this.cmdFTPTest.TabIndex = 0;
            this.cmdFTPTest.Text = "FTP Test";
            this.cmdFTPTest.UseVisualStyleBackColor = true;
            this.cmdFTPTest.Click += new System.EventHandler(this.cmdFTPTest_Click);
            // 
            // frmTest2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.cmdFTPTest);
            this.Name = "frmTest2";
            this.Text = "Tie Test";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdFTPTest;
    }
}