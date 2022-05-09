namespace ConnectionManager
{
    partial class ConnectionManagerPanel
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.lblRequstLiveSupport = new System.Windows.Forms.LinkLabel();
            this.lblRecogninDotCom = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(289, 100);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(103, 23);
            this.cancelButton.TabIndex = 38;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(392, 100);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(103, 23);
            this.nextButton.TabIndex = 37;
            this.nextButton.Text = "Next >>";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // lblRequstLiveSupport
            // 
            this.lblRequstLiveSupport.AutoSize = true;
            this.lblRequstLiveSupport.LinkArea = new System.Windows.Forms.LinkArea(76, 17);
            this.lblRequstLiveSupport.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblRequstLiveSupport.Location = new System.Drawing.Point(275, 0);
            this.lblRequstLiveSupport.Name = "lblRequstLiveSupport";
            this.lblRequstLiveSupport.Size = new System.Drawing.Size(223, 17);
            this.lblRequstLiveSupport.TabIndex = 36;
            this.lblRequstLiveSupport.Text = "Have questions? We\'re always glad to help!";
            this.lblRequstLiveSupport.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblRequstLiveSupport.UseCompatibleTextRendering = true;
            // 
            // lblRecogninDotCom
            // 
            this.lblRecogninDotCom.AutoSize = true;
            this.lblRecogninDotCom.Location = new System.Drawing.Point(282, 17);
            this.lblRecogninDotCom.Name = "lblRecogninDotCom";
            this.lblRecogninDotCom.Size = new System.Drawing.Size(212, 13);
            this.lblRecogninDotCom.TabIndex = 39;
            this.lblRecogninDotCom.TabStop = true;
            this.lblRecogninDotCom.Text = "Visit www.recognin.com for our contact info";
            this.lblRecogninDotCom.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRecogninDotCom_LinkClicked);
            // 
            // ConnectionManagerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblRecogninDotCom);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.lblRequstLiveSupport);
            this.Name = "ConnectionManagerPanel";
            this.Size = new System.Drawing.Size(504, 130);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Button cancelButton;
        protected System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.LinkLabel lblRequstLiveSupport;
        private System.Windows.Forms.LinkLabel lblRecogninDotCom;
    }
}
