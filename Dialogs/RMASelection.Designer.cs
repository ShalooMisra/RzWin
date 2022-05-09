namespace Rz5.Win.Dialogs
{
    partial class RMASelection
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
            this.optNewRMA = new System.Windows.Forms.RadioButton();
            this.optUseRMA = new System.Windows.Forms.RadioButton();
            this.gbRMA = new System.Windows.Forms.GroupBox();
            this.pActionRMA = new System.Windows.Forms.Panel();
            this.optCreditRMA = new System.Windows.Forms.RadioButton();
            this.optReplacementRMA = new System.Windows.Forms.RadioButton();
            this.ofRMA = new Rz5.Win.Controls.OrderFinder();
            this.gbVRMA = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkUseVendorReplacement = new System.Windows.Forms.CheckBox();
            this.optCreditVendRMA = new System.Windows.Forms.RadioButton();
            this.optReplacementVendor = new System.Windows.Forms.RadioButton();
            this.ofVendRMA = new Rz5.Win.Controls.OrderFinder();
            this.optNewVRMA = new System.Windows.Forms.RadioButton();
            this.optUseVRMA = new System.Windows.Forms.RadioButton();
            this.chkVRMA = new System.Windows.Forms.CheckBox();
            this.chkRMA = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.pOptions.SuspendLayout();
            this.pContents.SuspendLayout();
            this.gbRMA.SuspendLayout();
            this.pActionRMA.SuspendLayout();
            this.gbVRMA.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(142, 0);
            this.cmdOK.Size = new System.Drawing.Size(440, 59);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(0, 0);
            // 
            // pOptions
            // 
            this.pOptions.Location = new System.Drawing.Point(0, 401);
            this.pOptions.Size = new System.Drawing.Size(582, 63);
            // 
            // pContents
            // 
            this.pContents.Controls.Add(this.txtQuantity);
            this.pContents.Controls.Add(this.label3);
            this.pContents.Controls.Add(this.chkVRMA);
            this.pContents.Controls.Add(this.chkRMA);
            this.pContents.Controls.Add(this.gbVRMA);
            this.pContents.Controls.Add(this.gbRMA);
            this.pContents.Location = new System.Drawing.Point(0, 0);
            this.pContents.Size = new System.Drawing.Size(582, 401);
            // 
            // optNewRMA
            // 
            this.optNewRMA.AutoSize = true;
            this.optNewRMA.Checked = true;
            this.optNewRMA.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optNewRMA.Location = new System.Drawing.Point(10, 22);
            this.optNewRMA.Name = "optNewRMA";
            this.optNewRMA.Size = new System.Drawing.Size(173, 27);
            this.optNewRMA.TabIndex = 0;
            this.optNewRMA.TabStop = true;
            this.optNewRMA.Text = "Create A New RMA";
            this.optNewRMA.UseVisualStyleBackColor = true;
            this.optNewRMA.Click += new System.EventHandler(this.optNewRMA_Click);
            // 
            // optUseRMA
            // 
            this.optUseRMA.AutoSize = true;
            this.optUseRMA.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optUseRMA.Location = new System.Drawing.Point(10, 46);
            this.optUseRMA.Name = "optUseRMA";
            this.optUseRMA.Size = new System.Drawing.Size(209, 27);
            this.optUseRMA.TabIndex = 1;
            this.optUseRMA.Text = "Add To An Existing RMA";
            this.optUseRMA.UseVisualStyleBackColor = true;
            this.optUseRMA.Click += new System.EventHandler(this.optUseRMA_Click);
            // 
            // gbRMA
            // 
            this.gbRMA.Controls.Add(this.pActionRMA);
            this.gbRMA.Controls.Add(this.ofRMA);
            this.gbRMA.Controls.Add(this.optNewRMA);
            this.gbRMA.Controls.Add(this.optUseRMA);
            this.gbRMA.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRMA.Location = new System.Drawing.Point(10, 57);
            this.gbRMA.Name = "gbRMA";
            this.gbRMA.Size = new System.Drawing.Size(279, 339);
            this.gbRMA.TabIndex = 3;
            this.gbRMA.TabStop = false;
            // 
            // pActionRMA
            // 
            this.pActionRMA.Controls.Add(this.optCreditRMA);
            this.pActionRMA.Controls.Add(this.optReplacementRMA);
            this.pActionRMA.Location = new System.Drawing.Point(9, 221);
            this.pActionRMA.Name = "pActionRMA";
            this.pActionRMA.Size = new System.Drawing.Size(249, 95);
            this.pActionRMA.TabIndex = 3;
            // 
            // optCreditRMA
            // 
            this.optCreditRMA.AutoSize = true;
            this.optCreditRMA.Checked = true;
            this.optCreditRMA.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optCreditRMA.Location = new System.Drawing.Point(13, 3);
            this.optCreditRMA.Name = "optCreditRMA";
            this.optCreditRMA.Size = new System.Drawing.Size(201, 27);
            this.optCreditRMA.TabIndex = 3;
            this.optCreditRMA.TabStop = true;
            this.optCreditRMA.Text = "Apply Customer Credit";
            this.optCreditRMA.UseVisualStyleBackColor = true;
            this.optCreditRMA.CheckedChanged += new System.EventHandler(this.optCreditRMA_CheckedChanged);
            // 
            // optReplacementRMA
            // 
            this.optReplacementRMA.AutoSize = true;
            this.optReplacementRMA.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optReplacementRMA.Location = new System.Drawing.Point(13, 47);
            this.optReplacementRMA.Name = "optReplacementRMA";
            this.optReplacementRMA.Size = new System.Drawing.Size(169, 27);
            this.optReplacementRMA.TabIndex = 2;
            this.optReplacementRMA.Text = "Replacement / IHS";
            this.optReplacementRMA.UseVisualStyleBackColor = true;
            this.optReplacementRMA.CheckedChanged += new System.EventHandler(this.optReplacementRMA_CheckedChanged);
            // 
            // ofRMA
            // 
            this.ofRMA.BackColor = System.Drawing.Color.White;
            this.ofRMA.Location = new System.Drawing.Point(7, 78);
            this.ofRMA.Margin = new System.Windows.Forms.Padding(4);
            this.ofRMA.Name = "ofRMA";
            this.ofRMA.Size = new System.Drawing.Size(265, 150);
            this.ofRMA.TabIndex = 2;
            // 
            // gbVRMA
            // 
            this.gbVRMA.Controls.Add(this.panel1);
            this.gbVRMA.Controls.Add(this.ofVendRMA);
            this.gbVRMA.Controls.Add(this.optNewVRMA);
            this.gbVRMA.Controls.Add(this.optUseVRMA);
            this.gbVRMA.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbVRMA.Location = new System.Drawing.Point(295, 57);
            this.gbVRMA.Name = "gbVRMA";
            this.gbVRMA.Size = new System.Drawing.Size(280, 339);
            this.gbVRMA.TabIndex = 4;
            this.gbVRMA.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkUseVendorReplacement);
            this.panel1.Controls.Add(this.optCreditVendRMA);
            this.panel1.Controls.Add(this.optReplacementVendor);
            this.panel1.Location = new System.Drawing.Point(7, 220);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(249, 113);
            this.panel1.TabIndex = 6;
            // 
            // chkUseVendorReplacement
            // 
            this.chkUseVendorReplacement.Checked = true;
            this.chkUseVendorReplacement.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseVendorReplacement.Location = new System.Drawing.Point(13, 58);
            this.chkUseVendorReplacement.Name = "chkUseVendorReplacement";
            this.chkUseVendorReplacement.Size = new System.Drawing.Size(223, 52);
            this.chkUseVendorReplacement.TabIndex = 4;
            this.chkUseVendorReplacement.Text = "Use the vendor replacement for the customer replacement";
            this.chkUseVendorReplacement.UseVisualStyleBackColor = true;
            // 
            // optCreditVendRMA
            // 
            this.optCreditVendRMA.AutoSize = true;
            this.optCreditVendRMA.Checked = true;
            this.optCreditVendRMA.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optCreditVendRMA.Location = new System.Drawing.Point(13, 3);
            this.optCreditVendRMA.Name = "optCreditVendRMA";
            this.optCreditVendRMA.Size = new System.Drawing.Size(196, 27);
            this.optCreditVendRMA.TabIndex = 3;
            this.optCreditVendRMA.TabStop = true;
            this.optCreditVendRMA.Text = "Receive Vendor Credit";
            this.optCreditVendRMA.UseVisualStyleBackColor = true;
            this.optCreditVendRMA.CheckedChanged += new System.EventHandler(this.optCreditVendRMA_CheckedChanged);
            // 
            // optReplacementVendor
            // 
            this.optReplacementVendor.AutoSize = true;
            this.optReplacementVendor.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optReplacementVendor.Location = new System.Drawing.Point(13, 28);
            this.optReplacementVendor.Name = "optReplacementVendor";
            this.optReplacementVendor.Size = new System.Drawing.Size(196, 27);
            this.optReplacementVendor.TabIndex = 2;
            this.optReplacementVendor.Text = "Expect A Replacement";
            this.optReplacementVendor.UseVisualStyleBackColor = true;
            this.optReplacementVendor.CheckedChanged += new System.EventHandler(this.optReplacementVendor_CheckedChanged);
            // 
            // ofVendRMA
            // 
            this.ofVendRMA.BackColor = System.Drawing.Color.White;
            this.ofVendRMA.Location = new System.Drawing.Point(7, 76);
            this.ofVendRMA.Margin = new System.Windows.Forms.Padding(4);
            this.ofVendRMA.Name = "ofVendRMA";
            this.ofVendRMA.Size = new System.Drawing.Size(266, 152);
            this.ofVendRMA.TabIndex = 5;
            // 
            // optNewVRMA
            // 
            this.optNewVRMA.AutoSize = true;
            this.optNewVRMA.Checked = true;
            this.optNewVRMA.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optNewVRMA.Location = new System.Drawing.Point(6, 22);
            this.optNewVRMA.Name = "optNewVRMA";
            this.optNewVRMA.Size = new System.Drawing.Size(184, 27);
            this.optNewVRMA.TabIndex = 3;
            this.optNewVRMA.TabStop = true;
            this.optNewVRMA.Text = "Create A New VRMA";
            this.optNewVRMA.UseVisualStyleBackColor = true;
            this.optNewVRMA.Click += new System.EventHandler(this.optNewVRMA_Click);
            // 
            // optUseVRMA
            // 
            this.optUseVRMA.AutoSize = true;
            this.optUseVRMA.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optUseVRMA.Location = new System.Drawing.Point(6, 46);
            this.optUseVRMA.Name = "optUseVRMA";
            this.optUseVRMA.Size = new System.Drawing.Size(220, 27);
            this.optUseVRMA.TabIndex = 4;
            this.optUseVRMA.Text = "Add To An Existing VRMA";
            this.optUseVRMA.UseVisualStyleBackColor = true;
            this.optUseVRMA.Click += new System.EventHandler(this.optUseVRMA_Click);
            // 
            // chkVRMA
            // 
            this.chkVRMA.AutoSize = true;
            this.chkVRMA.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkVRMA.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVRMA.Location = new System.Drawing.Point(295, 42);
            this.chkVRMA.Name = "chkVRMA";
            this.chkVRMA.Size = new System.Drawing.Size(159, 23);
            this.chkVRMA.TabIndex = 6;
            this.chkVRMA.Text = "Make a Vendor RMA";
            this.chkVRMA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkVRMA.UseVisualStyleBackColor = true;
            this.chkVRMA.Click += new System.EventHandler(this.chkVRMA_Click);
            // 
            // chkRMA
            // 
            this.chkRMA.AutoSize = true;
            this.chkRMA.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRMA.Checked = true;
            this.chkRMA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRMA.Enabled = false;
            this.chkRMA.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRMA.Location = new System.Drawing.Point(13, 42);
            this.chkRMA.Name = "chkRMA";
            this.chkRMA.Size = new System.Drawing.Size(118, 23);
            this.chkRMA.TabIndex = 7;
            this.chkRMA.Text = "Make an RMA";
            this.chkRMA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRMA.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "RMA Quantity:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(142, 6);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(71, 31);
            this.txtQuantity.TabIndex = 9;
            this.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // RMASelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 464);
            this.Name = "RMASelection";
            this.Text = "RMA Selection";
            this.pOptions.ResumeLayout(false);
            this.pContents.ResumeLayout(false);
            this.pContents.PerformLayout();
            this.gbRMA.ResumeLayout(false);
            this.gbRMA.PerformLayout();
            this.pActionRMA.ResumeLayout(false);
            this.pActionRMA.PerformLayout();
            this.gbVRMA.ResumeLayout(false);
            this.gbVRMA.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkVRMA;
        private System.Windows.Forms.CheckBox chkRMA;
        private System.Windows.Forms.GroupBox gbVRMA;
        private System.Windows.Forms.RadioButton optNewVRMA;
        private System.Windows.Forms.RadioButton optUseVRMA;
        private System.Windows.Forms.GroupBox gbRMA;
        private System.Windows.Forms.RadioButton optNewRMA;
        private System.Windows.Forms.RadioButton optUseRMA;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label3;
        private Controls.OrderFinder ofVendRMA;
        private Controls.OrderFinder ofRMA;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkUseVendorReplacement;
        private System.Windows.Forms.RadioButton optCreditVendRMA;
        private System.Windows.Forms.RadioButton optReplacementVendor;
        private System.Windows.Forms.Panel pActionRMA;
        private System.Windows.Forms.RadioButton optCreditRMA;
        private System.Windows.Forms.RadioButton optReplacementRMA;
    }
}