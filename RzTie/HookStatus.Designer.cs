namespace Rz5.RzTie
{
    partial class HookStatus
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
                CompleteDispose();
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
            this.txtStatus = new Tie.nEndlessStatusBox();
            this.gb = new System.Windows.Forms.GroupBox();
            this.lblServerMessage = new System.Windows.Forms.Label();
            this.txtServerMessage = new System.Windows.Forms.TextBox();
            this.cmdSend = new System.Windows.Forms.Button();
            this.gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(38, 99);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(377, 368);
            this.txtStatus.TabIndex = 0;
            this.txtStatus.Text = "";
            // 
            // gb
            // 
            this.gb.Controls.Add(this.cmdSend);
            this.gb.Controls.Add(this.txtServerMessage);
            this.gb.Controls.Add(this.lblServerMessage);
            this.gb.Location = new System.Drawing.Point(5, 4);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(534, 43);
            this.gb.TabIndex = 1;
            this.gb.TabStop = false;
            // 
            // lblServerMessage
            // 
            this.lblServerMessage.AutoSize = true;
            this.lblServerMessage.Location = new System.Drawing.Point(6, 16);
            this.lblServerMessage.Name = "lblServerMessage";
            this.lblServerMessage.Size = new System.Drawing.Size(84, 13);
            this.lblServerMessage.TabIndex = 0;
            this.lblServerMessage.Text = "Server Message";
            // 
            // txtServerMessage
            // 
            this.txtServerMessage.Location = new System.Drawing.Point(96, 16);
            this.txtServerMessage.Name = "txtServerMessage";
            this.txtServerMessage.Size = new System.Drawing.Size(189, 20);
            this.txtServerMessage.TabIndex = 1;
            // 
            // cmdSend
            // 
            this.cmdSend.Location = new System.Drawing.Point(295, 15);
            this.cmdSend.Name = "cmdSend";
            this.cmdSend.Size = new System.Drawing.Size(80, 21);
            this.cmdSend.TabIndex = 2;
            this.cmdSend.Text = "Send";
            this.cmdSend.UseVisualStyleBackColor = true;
            this.cmdSend.Click += new System.EventHandler(this.cmdSend_Click);
            // 
            // HookStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb);
            this.Controls.Add(this.txtStatus);
            this.Name = "HookStatus";
            this.Size = new System.Drawing.Size(571, 524);
            this.Resize += new System.EventHandler(this.HookStatus_Resize);
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Tie.nEndlessStatusBox txtStatus;
        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.Button cmdSend;
        private System.Windows.Forms.TextBox txtServerMessage;
        private System.Windows.Forms.Label lblServerMessage;
    }
}
