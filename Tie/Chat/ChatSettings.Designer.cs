namespace NewMethod.Chat
{
    partial class ChatSettings
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
            this.chkUseChat = new System.Windows.Forms.CheckBox();
            this.lblChatServer = new System.Windows.Forms.Label();
            this.txtChatServer = new System.Windows.Forms.TextBox();
            this.cmdReInit = new System.Windows.Forms.Button();
            this.chkUseChatSound = new System.Windows.Forms.CheckBox();
            this.txtChatSound = new System.Windows.Forms.TextBox();
            this.lblChatSound = new System.Windows.Forms.Label();
            this.cmdBrowseSound = new System.Windows.Forms.Button();
            this.cmdPlay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkUseChat
            // 
            this.chkUseChat.AutoSize = true;
            this.chkUseChat.Location = new System.Drawing.Point(6, 13);
            this.chkUseChat.Name = "chkUseChat";
            this.chkUseChat.Size = new System.Drawing.Size(129, 17);
            this.chkUseChat.TabIndex = 0;
            this.chkUseChat.Text = "Use The Chat System";
            this.chkUseChat.UseVisualStyleBackColor = true;
            this.chkUseChat.CheckedChanged += new System.EventHandler(this.chkUseChat_CheckedChanged);
            // 
            // lblChatServer
            // 
            this.lblChatServer.AutoSize = true;
            this.lblChatServer.Location = new System.Drawing.Point(3, 43);
            this.lblChatServer.Name = "lblChatServer";
            this.lblChatServer.Size = new System.Drawing.Size(66, 13);
            this.lblChatServer.TabIndex = 1;
            this.lblChatServer.Text = "Chat Server:";
            // 
            // txtChatServer
            // 
            this.txtChatServer.Location = new System.Drawing.Point(6, 59);
            this.txtChatServer.Name = "txtChatServer";
            this.txtChatServer.Size = new System.Drawing.Size(180, 20);
            this.txtChatServer.TabIndex = 2;
            this.txtChatServer.TextChanged += new System.EventHandler(this.txtChatServer_TextChanged);
            // 
            // cmdReInit
            // 
            this.cmdReInit.Location = new System.Drawing.Point(6, 85);
            this.cmdReInit.Name = "cmdReInit";
            this.cmdReInit.Size = new System.Drawing.Size(179, 33);
            this.cmdReInit.TabIndex = 3;
            this.cmdReInit.Text = "Re-Initialize";
            this.cmdReInit.UseVisualStyleBackColor = true;
            this.cmdReInit.Click += new System.EventHandler(this.cmdReInit_Click);
            // 
            // chkUseChatSound
            // 
            this.chkUseChatSound.AutoSize = true;
            this.chkUseChatSound.Location = new System.Drawing.Point(6, 150);
            this.chkUseChatSound.Name = "chkUseChatSound";
            this.chkUseChatSound.Size = new System.Drawing.Size(183, 17);
            this.chkUseChatSound.TabIndex = 4;
            this.chkUseChatSound.Text = "Play a sound when a chat arrives";
            this.chkUseChatSound.UseVisualStyleBackColor = true;
            this.chkUseChatSound.CheckedChanged += new System.EventHandler(this.chkUseChatSound_CheckedChanged);
            // 
            // txtChatSound
            // 
            this.txtChatSound.Location = new System.Drawing.Point(9, 188);
            this.txtChatSound.Name = "txtChatSound";
            this.txtChatSound.Size = new System.Drawing.Size(180, 20);
            this.txtChatSound.TabIndex = 6;
            this.txtChatSound.TextChanged += new System.EventHandler(this.txtChatSound_TextChanged);
            // 
            // lblChatSound
            // 
            this.lblChatSound.AutoSize = true;
            this.lblChatSound.Location = new System.Drawing.Point(6, 172);
            this.lblChatSound.Name = "lblChatSound";
            this.lblChatSound.Size = new System.Drawing.Size(66, 13);
            this.lblChatSound.TabIndex = 5;
            this.lblChatSound.Text = "Chat Sound:";
            // 
            // cmdBrowseSound
            // 
            this.cmdBrowseSound.Location = new System.Drawing.Point(195, 187);
            this.cmdBrowseSound.Name = "cmdBrowseSound";
            this.cmdBrowseSound.Size = new System.Drawing.Size(38, 21);
            this.cmdBrowseSound.TabIndex = 7;
            this.cmdBrowseSound.Text = "...";
            this.cmdBrowseSound.UseVisualStyleBackColor = true;
            this.cmdBrowseSound.Click += new System.EventHandler(this.cmdBrowseSound_Click);
            // 
            // cmdPlay
            // 
            this.cmdPlay.Location = new System.Drawing.Point(239, 188);
            this.cmdPlay.Name = "cmdPlay";
            this.cmdPlay.Size = new System.Drawing.Size(41, 21);
            this.cmdPlay.TabIndex = 8;
            this.cmdPlay.Text = "Play";
            this.cmdPlay.UseVisualStyleBackColor = true;
            this.cmdPlay.Click += new System.EventHandler(this.cmdPlay_Click);
            // 
            // ChatSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdPlay);
            this.Controls.Add(this.cmdBrowseSound);
            this.Controls.Add(this.txtChatSound);
            this.Controls.Add(this.lblChatSound);
            this.Controls.Add(this.chkUseChatSound);
            this.Controls.Add(this.cmdReInit);
            this.Controls.Add(this.txtChatServer);
            this.Controls.Add(this.lblChatServer);
            this.Controls.Add(this.chkUseChat);
            this.Name = "ChatSettings";
            this.Size = new System.Drawing.Size(514, 407);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkUseChat;
        private System.Windows.Forms.Label lblChatServer;
        private System.Windows.Forms.TextBox txtChatServer;
        private System.Windows.Forms.Button cmdReInit;
        private System.Windows.Forms.CheckBox chkUseChatSound;
        private System.Windows.Forms.TextBox txtChatSound;
        private System.Windows.Forms.Label lblChatSound;
        private System.Windows.Forms.Button cmdBrowseSound;
        private System.Windows.Forms.Button cmdPlay;
    }
}
