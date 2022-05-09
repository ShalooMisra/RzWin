namespace NewMethod.Chat
{
    partial class frmChatSession
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
            this.txtSend = new System.Windows.Forms.RichTextBox();
            this.cmdSend = new System.Windows.Forms.Button();
            this.wb = new NewMethod.nBrowser();
            this.SuspendLayout();
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(-1, 420);
            this.txtSend.Name = "txtSend";
            this.txtSend.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.txtSend.Size = new System.Drawing.Size(524, 96);
            this.txtSend.TabIndex = 0;
            this.txtSend.Text = "";
            this.txtSend.WordWrap = false;
            // 
            // cmdSend
            // 
            this.cmdSend.Location = new System.Drawing.Point(529, 420);
            this.cmdSend.Name = "cmdSend";
            this.cmdSend.Size = new System.Drawing.Size(82, 96);
            this.cmdSend.TabIndex = 2;
            this.cmdSend.Text = "Send";
            this.cmdSend.UseVisualStyleBackColor = true;
            this.cmdSend.Click += new System.EventHandler(this.cmdSend_Click);
            // 
            // wb
            // 
            this.wb.Location = new System.Drawing.Point(-1, 0);
            this.wb.Name = "wb";
            this.wb.Silent = false;
            this.wb.Size = new System.Drawing.Size(577, 414);
            this.wb.TabIndex = 3;
            // 
            // frmChatSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 535);
            this.Controls.Add(this.wb);
            this.Controls.Add(this.cmdSend);
            this.Controls.Add(this.txtSend);
            this.Name = "frmChatSession";
            this.Text = "Chat Session";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmChatSession_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtSend;
        private System.Windows.Forms.Button cmdSend;
        private nBrowser wb;
    }
}