namespace ToolsWin.Dialogs
{
    partial class YesNo
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
            this.lblAsk = new System.Windows.Forms.Label();
            this.cmdIgnore = new System.Windows.Forms.Button();
            this.pOptions.SuspendLayout();
            this.pContents.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(142, 0);
            this.cmdOK.Size = new System.Drawing.Size(338, 58);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(0, 0);
            // 
            // pOptions
            // 
            this.pOptions.Location = new System.Drawing.Point(0, 123);
            this.pOptions.Size = new System.Drawing.Size(480, 63);
            // 
            // pContents
            // 
            this.pContents.Controls.Add(this.lblAsk);
            this.pContents.Location = new System.Drawing.Point(0, 0);
            this.pContents.Size = new System.Drawing.Size(480, 123);
            // 
            // lblAsk
            // 
            this.lblAsk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAsk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsk.Location = new System.Drawing.Point(0, 0);
            this.lblAsk.Name = "lblAsk";
            this.lblAsk.Size = new System.Drawing.Size(480, 123);
            this.lblAsk.TabIndex = 1;
            this.lblAsk.Text = "<ask>";
            this.lblAsk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdIgnore
            // 
            this.cmdIgnore.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdIgnore.Location = new System.Drawing.Point(300, 2);
            this.cmdIgnore.Name = "cmdIgnore";
            this.cmdIgnore.Size = new System.Drawing.Size(179, 21);
            this.cmdIgnore.TabIndex = 4;
            this.cmdIgnore.Text = "Yes; Don\'t Ask Me Again";
            this.cmdIgnore.UseVisualStyleBackColor = true;
            this.cmdIgnore.Visible = false;
            this.cmdIgnore.Click += new System.EventHandler(this.cmdIgnore_Click);
            // 
            // YesNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 186);
            this.Controls.Add(this.cmdIgnore);
            this.Name = "YesNo";
            this.Text = "YesNo";
            this.Controls.SetChildIndex(this.pOptions, 0);
            this.Controls.SetChildIndex(this.pContents, 0);
            this.Controls.SetChildIndex(this.cmdIgnore, 0);
            this.pOptions.ResumeLayout(false);
            this.pContents.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblAsk;
        private System.Windows.Forms.Button cmdIgnore;
    }
}