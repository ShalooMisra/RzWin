namespace RzInterfaceWin.Dialogs
{
    partial class frmCustomerTermsValidation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerTermsValidation));
            this.gbRequirements = new System.Windows.Forms.GroupBox();
            this.lblCompanyTitle = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.txtTermsRestrictions = new System.Windows.Forms.TextBox();
            this.gbDescription = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.gbRequirements.SuspendLayout();
            this.gbDescription.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbRequirements
            // 
            this.gbRequirements.Controls.Add(this.txtTermsRestrictions);
            this.gbRequirements.Location = new System.Drawing.Point(16, 54);
            this.gbRequirements.Name = "gbRequirements";
            this.gbRequirements.Size = new System.Drawing.Size(442, 175);
            this.gbRequirements.TabIndex = 8;
            this.gbRequirements.TabStop = false;
            this.gbRequirements.Text = "Terms, Requirements, Restrictions";
            // 
            // lblCompanyTitle
            // 
            this.lblCompanyTitle.AutoSize = true;
            this.lblCompanyTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyTitle.Location = new System.Drawing.Point(13, 20);
            this.lblCompanyTitle.Name = "lblCompanyTitle";
            this.lblCompanyTitle.Size = new System.Drawing.Size(84, 20);
            this.lblCompanyTitle.TabIndex = 7;
            this.lblCompanyTitle.Text = "Company: ";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.Location = new System.Drawing.Point(103, 20);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(144, 20);
            this.lblCompanyName.TabIndex = 5;
            this.lblCompanyName.Text = "<companyname>";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(16, 431);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(442, 46);
            this.btnConfirm.TabIndex = 9;
            this.btnConfirm.Text = "Confirm Customer Restrictions";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // txtTermsRestrictions
            // 
            this.txtTermsRestrictions.Enabled = false;
            this.txtTermsRestrictions.Location = new System.Drawing.Point(6, 19);
            this.txtTermsRestrictions.Multiline = true;
            this.txtTermsRestrictions.Name = "txtTermsRestrictions";
            this.txtTermsRestrictions.Size = new System.Drawing.Size(430, 148);
            this.txtTermsRestrictions.TabIndex = 5;
            // 
            // gbDescription
            // 
            this.gbDescription.Controls.Add(this.txtDescription);
            this.gbDescription.Location = new System.Drawing.Point(17, 235);
            this.gbDescription.Name = "gbDescription";
            this.gbDescription.Size = new System.Drawing.Size(442, 175);
            this.gbDescription.TabIndex = 11;
            this.gbDescription.TabStop = false;
            this.gbDescription.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Enabled = false;
            this.txtDescription.Location = new System.Drawing.Point(6, 19);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(430, 148);
            this.txtDescription.TabIndex = 5;
            // 
            // frmCustomerTermsValidation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 485);
            this.Controls.Add(this.gbDescription);
            this.Controls.Add(this.gbRequirements);
            this.Controls.Add(this.lblCompanyTitle);
            this.Controls.Add(this.lblCompanyName);
            this.Controls.Add(this.btnConfirm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCustomerTermsValidation";
            this.Text = "Customer Restrictions:";
            this.gbRequirements.ResumeLayout(false);
            this.gbRequirements.PerformLayout();
            this.gbDescription.ResumeLayout(false);
            this.gbDescription.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbRequirements;
        private System.Windows.Forms.Label lblCompanyTitle;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TextBox txtTermsRestrictions;
        private System.Windows.Forms.GroupBox gbDescription;
        private System.Windows.Forms.TextBox txtDescription;
    }
}