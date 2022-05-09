namespace CoreWin
{
    partial class Status
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
            this.nStatusView1 = new StatusView();
            this.txtStatus = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // nStatusView1
            // 
            this.nStatusView1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nStatusView1.Location = new System.Drawing.Point(9, 391);
            this.nStatusView1.Name = "nStatusView1";
            this.nStatusView1.Size = new System.Drawing.Size(333, 15);
            this.nStatusView1.TabIndex = 0;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(0, -2);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.txtStatus.Size = new System.Drawing.Size(353, 387);
            this.txtStatus.TabIndex = 1;
            this.txtStatus.Text = "";
            this.txtStatus.WordWrap = false;
            // 
            // frmStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 418);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.nStatusView1);
            this.Name = "frmStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Status";
            this.ResumeLayout(false);

        }

        #endregion

        private StatusView nStatusView1;
        private System.Windows.Forms.RichTextBox txtStatus;

    }
}