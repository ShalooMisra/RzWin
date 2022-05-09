namespace ToolsWin.Dialogs
{
    partial class Paste
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
            this.txtPaste = new System.Windows.Forms.TextBox();
            this.pContents.SuspendLayout();
            this.SuspendLayout();
            // 
            // pContents
            // 
            this.pContents.Controls.Add(this.txtPaste);
            this.pContents.Location = new System.Drawing.Point(0, 0);
            this.pContents.Size = new System.Drawing.Size(547, 483);
            // 
            // txtPaste
            // 
            this.txtPaste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPaste.Location = new System.Drawing.Point(0, 0);
            this.txtPaste.Multiline = true;
            this.txtPaste.Name = "txtPaste";
            this.txtPaste.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPaste.Size = new System.Drawing.Size(547, 483);
            this.txtPaste.TabIndex = 2;
            // 
            // Paste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 546);
            this.Name = "Paste";
            this.Text = "Text Entry";
            this.pContents.ResumeLayout(false);
            this.pContents.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtPaste;
    }
}