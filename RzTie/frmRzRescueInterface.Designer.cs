namespace Rz5
{
    partial class frmRzRescueInterface
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
            this.cmdBackUp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdBackUp
            // 
            this.cmdBackUp.Location = new System.Drawing.Point(12, 12);
            this.cmdBackUp.Name = "cmdBackUp";
            this.cmdBackUp.Size = new System.Drawing.Size(466, 23);
            this.cmdBackUp.TabIndex = 0;
            this.cmdBackUp.Text = "BackUp";
            this.cmdBackUp.UseVisualStyleBackColor = true;
            this.cmdBackUp.Click += new System.EventHandler(this.cmdBackUp_Click);
            // 
            // frmRzRescueInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 52);
            this.Controls.Add(this.cmdBackUp);
            this.Name = "frmRzRescueInterface";
            this.Text = "RzRescueInterface";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdBackUp;
    }
}