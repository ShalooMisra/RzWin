namespace ConnectionManager
{
    partial class ConnectionTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionTest));
            this.label4 = new System.Windows.Forms.Label();
            this.lblExplanation = new System.Windows.Forms.Label();
            this.cmdTryAgain = new System.Windows.Forms.Button();
            this.lblReset = new System.Windows.Forms.LinkLabel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.bg = new System.ComponentModel.BackgroundWorker();
            this.cancelButton = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(231, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(315, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "Rz Information Connection Help";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblExplanation
            // 
            this.lblExplanation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExplanation.Location = new System.Drawing.Point(12, 83);
            this.lblExplanation.Name = "lblExplanation";
            this.lblExplanation.Size = new System.Drawing.Size(530, 62);
            this.lblExplanation.TabIndex = 15;
            this.lblExplanation.Text = "Testing the Rz connection...";
            // 
            // cmdTryAgain
            // 
            this.cmdTryAgain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdTryAgain.Location = new System.Drawing.Point(274, 157);
            this.cmdTryAgain.Name = "cmdTryAgain";
            this.cmdTryAgain.Size = new System.Drawing.Size(103, 23);
            this.cmdTryAgain.TabIndex = 16;
            this.cmdTryAgain.Text = "Try Again";
            this.cmdTryAgain.UseVisualStyleBackColor = true;
            this.cmdTryAgain.Click += new System.EventHandler(this.cmdTryAgain_Click);
            // 
            // lblReset
            // 
            this.lblReset.AutoSize = true;
            this.lblReset.Location = new System.Drawing.Point(74, 227);
            this.lblReset.Name = "lblReset";
            this.lblReset.Size = new System.Drawing.Size(411, 13);
            this.lblReset.TabIndex = 17;
            this.lblReset.TabStop = true;
            this.lblReset.Text = "For Administrators: Click here to delete the Rz data connection settings and star" +
    "t over.";
            this.lblReset.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblReset_LinkClicked);
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(9, 183);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(533, 44);
            this.lblMessage.TabIndex = 18;
            this.lblMessage.Text = "<message>";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bg
            // 
            this.bg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_DoWork);
            this.bg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_RunWorkerCompleted);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(165, 157);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(103, 23);
            this.cancelButton.TabIndex = 43;
            this.cancelButton.Text = "Exit";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // picLogo
            // 
            this.picLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picLogo.BackgroundImage")));
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picLogo.InitialImage = null;
            this.picLogo.Location = new System.Drawing.Point(3, 2);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(89, 67);
            this.picLogo.TabIndex = 44;
            this.picLogo.TabStop = false;
            // 
            // ConnectionTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(554, 248);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblReset);
            this.Controls.Add(this.cmdTryAgain);
            this.Controls.Add(this.lblExplanation);
            this.Controls.Add(this.label4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectionTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rz Connection Assistance";
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblExplanation;
        private System.Windows.Forms.Button cmdTryAgain;
        private System.Windows.Forms.LinkLabel lblReset;
        private System.Windows.Forms.Label lblMessage;
        private System.ComponentModel.BackgroundWorker bg;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.PictureBox picLogo;
    }
}