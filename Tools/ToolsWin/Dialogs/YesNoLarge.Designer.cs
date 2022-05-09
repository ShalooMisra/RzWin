namespace ToolsWin.Dialogs
{
    partial class YesNoLarge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YesNoLarge));
            this.RT = new System.Windows.Forms.RichTextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pOptions.SuspendLayout();
            this.pContents.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(142, 0);
            this.cmdOK.Size = new System.Drawing.Size(350, 58);
            this.cmdOK.Text = "&Yes";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(0, 0);
            this.cmdCancel.Text = "&No";
            // 
            // pOptions
            // 
            this.pOptions.Location = new System.Drawing.Point(0, 363);
            this.pOptions.Size = new System.Drawing.Size(492, 63);
            // 
            // pContents
            // 
            this.pContents.Controls.Add(this.lblTitle);
            this.pContents.Controls.Add(this.RT);
            this.pContents.Location = new System.Drawing.Point(0, 0);
            this.pContents.Size = new System.Drawing.Size(492, 363);
            // 
            // RT
            // 
            this.RT.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RT.Location = new System.Drawing.Point(3, 38);
            this.RT.Name = "RT";
            this.RT.Size = new System.Drawing.Size(489, 319);
            this.RT.TabIndex = 0;
            this.RT.Text = "";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(345, 24);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Are you sure about stuff and things?";
            // 
            // YesNoLarge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 426);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "YesNoLarge";
            this.Text = "Are you sure?";
            this.pOptions.ResumeLayout(false);
            this.pContents.ResumeLayout(false);
            this.pContents.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox RT;
        private System.Windows.Forms.Label lblTitle;
    }
}