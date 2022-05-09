namespace Rz3_Common
{
    partial class frmEMailTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEMailTest));
            this.gbOptions = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.optReq = new System.Windows.Forms.RadioButton();
            this.optOffer = new System.Windows.Forms.RadioButton();
            this.optSubject = new System.Windows.Forms.RadioButton();
            this.txtRecipientAddress = new NewMethod.nEdit_String();
            this.txtSenderAddress = new NewMethod.nEdit_String();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.txtBody = new System.Windows.Forms.RichTextBox();
            this.cmdProcess = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.gbOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbOptions
            // 
            this.gbOptions.Controls.Add(this.txtSubject);
            this.gbOptions.Controls.Add(this.txtSenderAddress);
            this.gbOptions.Controls.Add(this.txtRecipientAddress);
            this.gbOptions.Controls.Add(this.optSubject);
            this.gbOptions.Controls.Add(this.optOffer);
            this.gbOptions.Controls.Add(this.optReq);
            this.gbOptions.Controls.Add(this.label1);
            this.gbOptions.Location = new System.Drawing.Point(2, -3);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Size = new System.Drawing.Size(526, 182);
            this.gbOptions.TabIndex = 0;
            this.gbOptions.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(514, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter the text in the box below.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // optReq
            // 
            this.optReq.AutoSize = true;
            this.optReq.Checked = true;
            this.optReq.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optReq.Location = new System.Drawing.Point(12, 49);
            this.optReq.Name = "optReq";
            this.optReq.Size = new System.Drawing.Size(191, 23);
            this.optReq.TabIndex = 1;
            this.optReq.TabStop = true;
            this.optReq.Text = "Process As A Requirement";
            this.optReq.UseVisualStyleBackColor = true;
            // 
            // optOffer
            // 
            this.optOffer.AutoSize = true;
            this.optOffer.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optOffer.Location = new System.Drawing.Point(12, 84);
            this.optOffer.Name = "optOffer";
            this.optOffer.Size = new System.Drawing.Size(154, 23);
            this.optOffer.TabIndex = 2;
            this.optOffer.Text = "Process As An Offer";
            this.optOffer.UseVisualStyleBackColor = true;
            // 
            // optSubject
            // 
            this.optSubject.AutoSize = true;
            this.optSubject.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optSubject.Location = new System.Drawing.Point(12, 121);
            this.optSubject.Name = "optSubject";
            this.optSubject.Size = new System.Drawing.Size(209, 23);
            this.optSubject.TabIndex = 3;
            this.optSubject.Text = "Enter The Subject Line Below";
            this.optSubject.UseVisualStyleBackColor = true;
            // 
            // txtRecipientAddress
            // 
            this.txtRecipientAddress.AllCaps = false;
            this.txtRecipientAddress.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtRecipientAddress.Bold = false;
            this.txtRecipientAddress.Caption = "Recipient\'s Email Address";
            this.txtRecipientAddress.Changed = true;
            this.txtRecipientAddress.IsEmail = false;
            this.txtRecipientAddress.IsURL = false;
            this.txtRecipientAddress.Location = new System.Drawing.Point(263, 49);
            this.txtRecipientAddress.Name = "txtRecipientAddress";
            this.txtRecipientAddress.PasswordChar = '\0';
            this.txtRecipientAddress.Size = new System.Drawing.Size(257, 47);
            this.txtRecipientAddress.TabIndex = 4;
            this.txtRecipientAddress.UseParentBackColor = false;
            this.txtRecipientAddress.zz_Enabled = true;
            this.txtRecipientAddress.zz_GlobalColor = System.Drawing.Color.Black;
            this.txtRecipientAddress.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecipientAddress.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.txtRecipientAddress.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecipientAddress.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.txtRecipientAddress.zz_OriginalDesign = false;
            this.txtRecipientAddress.zz_ShowLinkButton = false;
            this.txtRecipientAddress.zz_ShowNeedsSaveColor = false;
            this.txtRecipientAddress.zz_Text = "recipient@recognin.com";
            this.txtRecipientAddress.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtRecipientAddress.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.txtRecipientAddress.zz_TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecipientAddress.zz_UseGlobalColor = false;
            this.txtRecipientAddress.zz_UseGlobalFont = true;
            // 
            // txtSenderAddress
            // 
            this.txtSenderAddress.AllCaps = false;
            this.txtSenderAddress.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtSenderAddress.Bold = false;
            this.txtSenderAddress.Caption = "Sender\'s Email Address";
            this.txtSenderAddress.Changed = true;
            this.txtSenderAddress.IsEmail = false;
            this.txtSenderAddress.IsURL = false;
            this.txtSenderAddress.Location = new System.Drawing.Point(263, 97);
            this.txtSenderAddress.Name = "txtSenderAddress";
            this.txtSenderAddress.PasswordChar = '\0';
            this.txtSenderAddress.Size = new System.Drawing.Size(257, 47);
            this.txtSenderAddress.TabIndex = 5;
            this.txtSenderAddress.UseParentBackColor = false;
            this.txtSenderAddress.zz_Enabled = true;
            this.txtSenderAddress.zz_GlobalColor = System.Drawing.Color.Black;
            this.txtSenderAddress.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenderAddress.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.txtSenderAddress.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenderAddress.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.txtSenderAddress.zz_OriginalDesign = false;
            this.txtSenderAddress.zz_ShowLinkButton = false;
            this.txtSenderAddress.zz_ShowNeedsSaveColor = false;
            this.txtSenderAddress.zz_Text = "sender@recognin.com";
            this.txtSenderAddress.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSenderAddress.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.txtSenderAddress.zz_TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenderAddress.zz_UseGlobalColor = false;
            this.txtSenderAddress.zz_UseGlobalFont = true;
            // 
            // txtSubject
            // 
            this.txtSubject.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubject.Location = new System.Drawing.Point(12, 150);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(508, 26);
            this.txtSubject.TabIndex = 6;
            // 
            // txtBody
            // 
            this.txtBody.Location = new System.Drawing.Point(2, 185);
            this.txtBody.Name = "txtBody";
            this.txtBody.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtBody.Size = new System.Drawing.Size(526, 152);
            this.txtBody.TabIndex = 1;
            this.txtBody.Text = "";
            // 
            // cmdProcess
            // 
            this.cmdProcess.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdProcess.Location = new System.Drawing.Point(2, 343);
            this.cmdProcess.Name = "cmdProcess";
            this.cmdProcess.Size = new System.Drawing.Size(238, 28);
            this.cmdProcess.TabIndex = 2;
            this.cmdProcess.Text = "&Process";
            this.cmdProcess.UseVisualStyleBackColor = true;
            this.cmdProcess.Click += new System.EventHandler(this.cmdProcess_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Location = new System.Drawing.Point(290, 343);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(238, 28);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmEMailTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 373);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdProcess);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.gbOptions);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEMailTest";
            this.Text = "EMail Test";
            this.gbOptions.ResumeLayout(false);
            this.gbOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbOptions;
        private System.Windows.Forms.Label label1;
        private NewMethod.nEdit_String txtSenderAddress;
        private NewMethod.nEdit_String txtRecipientAddress;
        private System.Windows.Forms.RadioButton optSubject;
        private System.Windows.Forms.RadioButton optOffer;
        private System.Windows.Forms.RadioButton optReq;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.RichTextBox txtBody;
        private System.Windows.Forms.Button cmdProcess;
        private System.Windows.Forms.Button cmdCancel;
    }
}