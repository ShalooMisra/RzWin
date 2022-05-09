namespace NewMethod
{
    partial class nEmailMessageView
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
            this.wb = new ToolsWin.Browser();
            this.lblSubject = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.lblToAddress = new System.Windows.Forms.Label();
            this.lblToName = new System.Windows.Forms.Label();
            this.lblFromName = new System.Windows.Forms.Label();
            this.lblFromAddress = new System.Windows.Forms.Label();
            this.lblServerName = new System.Windows.Forms.Label();
            this.lblServerPort = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // wb
            // 
            this.wb.Location = new System.Drawing.Point(8, 153);
            this.wb.Name = "wb";
            this.wb.Silent = false;
            this.wb.Size = new System.Drawing.Size(609, 459);
            this.wb.TabIndex = 0;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(5, 111);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(43, 13);
            this.lblSubject.TabIndex = 1;
            this.lblSubject.Text = "Subject";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(8, 127);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(609, 20);
            this.txtSubject.TabIndex = 2;
            // 
            // lblToAddress
            // 
            this.lblToAddress.AutoSize = true;
            this.lblToAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToAddress.Location = new System.Drawing.Point(4, 9);
            this.lblToAddress.Name = "lblToAddress";
            this.lblToAddress.Size = new System.Drawing.Size(242, 20);
            this.lblToAddress.TabIndex = 3;
            this.lblToAddress.Text = "To Address: mike@recognin.com";
            // 
            // lblToName
            // 
            this.lblToName.AutoSize = true;
            this.lblToName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToName.Location = new System.Drawing.Point(4, 28);
            this.lblToName.Name = "lblToName";
            this.lblToName.Size = new System.Drawing.Size(188, 20);
            this.lblToName.TabIndex = 4;
            this.lblToName.Text = "To Name: Recognin Tech";
            // 
            // lblFromName
            // 
            this.lblFromName.AutoSize = true;
            this.lblFromName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromName.Location = new System.Drawing.Point(4, 80);
            this.lblFromName.Name = "lblFromName";
            this.lblFromName.Size = new System.Drawing.Size(186, 20);
            this.lblFromName.TabIndex = 6;
            this.lblFromName.Text = "From Name: Source Test";
            // 
            // lblFromAddress
            // 
            this.lblFromAddress.AutoSize = true;
            this.lblFromAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromAddress.Location = new System.Drawing.Point(4, 61);
            this.lblFromAddress.Name = "lblFromAddress";
            this.lblFromAddress.Size = new System.Drawing.Size(276, 20);
            this.lblFromAddress.TabIndex = 5;
            this.lblFromAddress.Text = "From Address: source@recognin.com";
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerName.Location = new System.Drawing.Point(352, 9);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(239, 20);
            this.lblServerName.TabIndex = 7;
            this.lblServerName.Text = "Server Name: mail.whatever.com";
            // 
            // lblServerPort
            // 
            this.lblServerPort.AutoSize = true;
            this.lblServerPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerPort.Location = new System.Drawing.Point(352, 29);
            this.lblServerPort.Name = "lblServerPort";
            this.lblServerPort.Size = new System.Drawing.Size(114, 20);
            this.lblServerPort.TabIndex = 8;
            this.lblServerPort.Text = "Server Port: 25";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(352, 49);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(169, 20);
            this.lblUserName.TabIndex = 9;
            this.lblUserName.Text = "User Name: u1234565";
            // 
            // nEmailMessageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblServerPort);
            this.Controls.Add(this.lblServerName);
            this.Controls.Add(this.lblFromName);
            this.Controls.Add(this.lblFromAddress);
            this.Controls.Add(this.lblToName);
            this.Controls.Add(this.lblToAddress);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.wb);
            this.Name = "nEmailMessageView";
            this.Size = new System.Drawing.Size(633, 630);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolsWin.Browser wb;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label lblToAddress;
        private System.Windows.Forms.Label lblToName;
        private System.Windows.Forms.Label lblFromName;
        private System.Windows.Forms.Label lblFromAddress;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.Label lblServerPort;
        private System.Windows.Forms.Label lblUserName;
    }
}
