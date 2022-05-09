namespace NewMethod.Chat
{
    partial class frmChatWindow
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
            this.btnSendData = new System.Windows.Forms.Button();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbChat = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEndChat = new System.Windows.Forms.Button();
            this.rtbMessages = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSendData
            // 
            this.btnSendData.Location = new System.Drawing.Point(3, 0);
            this.btnSendData.Name = "btnSendData";
            this.btnSendData.Size = new System.Drawing.Size(130, 23);
            this.btnSendData.TabIndex = 1;
            this.btnSendData.Text = "Send";
            this.btnSendData.UseVisualStyleBackColor = true;
            this.btnSendData.Click += new System.EventHandler(this.btnSendData_Click);
            // 
            // btnSendFile
            // 
            this.btnSendFile.Location = new System.Drawing.Point(3, 26);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(130, 23);
            this.btnSendFile.TabIndex = 2;
            this.btnSendFile.Text = "Send File";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Messages:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tbChat);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 209);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(602, 81);
            this.panel1.TabIndex = 15;
            // 
            // tbChat
            // 
            this.tbChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbChat.Location = new System.Drawing.Point(0, 0);
            this.tbChat.Multiline = true;
            this.tbChat.Name = "tbChat";
            this.tbChat.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbChat.Size = new System.Drawing.Size(460, 77);
            this.tbChat.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnEndChat);
            this.panel2.Controls.Add(this.btnSendData);
            this.panel2.Controls.Add(this.btnSendFile);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(460, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(138, 77);
            this.panel2.TabIndex = 15;
            // 
            // btnEndChat
            // 
            this.btnEndChat.Location = new System.Drawing.Point(3, 55);
            this.btnEndChat.Name = "btnEndChat";
            this.btnEndChat.Size = new System.Drawing.Size(130, 23);
            this.btnEndChat.TabIndex = 3;
            this.btnEndChat.Text = "End";
            this.btnEndChat.UseVisualStyleBackColor = true;
            this.btnEndChat.Click += new System.EventHandler(this.btnEndChat_Click);
            // 
            // rtbMessages
            // 
            this.rtbMessages.AutoWordSelection = true;
            this.rtbMessages.BackColor = System.Drawing.SystemColors.Info;
            this.rtbMessages.DetectUrls = false;
            this.rtbMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMessages.Location = new System.Drawing.Point(0, 13);
            this.rtbMessages.Name = "rtbMessages";
            this.rtbMessages.ReadOnly = true;
            this.rtbMessages.Size = new System.Drawing.Size(602, 196);
            this.rtbMessages.TabIndex = 16;
            this.rtbMessages.Text = "";
            // 
            // frmChatWindow
            // 
            this.AcceptButton = this.btnSendData;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 290);
            this.Controls.Add(this.rtbMessages);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "frmChatWindow";
            this.Text = "Chatting with";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRemoting_FormClosing);
            this.Load += new System.EventHandler(this.frmChatWindow_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendData;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnEndChat;
        private System.Windows.Forms.RichTextBox rtbMessages;
        private System.Windows.Forms.TextBox tbChat;
    }
}

