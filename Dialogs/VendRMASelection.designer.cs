namespace Rz5.Win.Dialogs
{
    partial class VendRMASelection
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
            this.gbVRMA = new System.Windows.Forms.GroupBox();
            this.chkReplacement = new System.Windows.Forms.CheckBox();
            this.of = new Rz5.Win.Controls.OrderFinder();
            this.optNewVRMA = new System.Windows.Forms.RadioButton();
            this.optUseVRMA = new System.Windows.Forms.RadioButton();
            this.chkVRMA = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.pOptions.SuspendLayout();
            this.pContents.SuspendLayout();
            this.gbVRMA.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(142, 0);
            this.cmdOK.Size = new System.Drawing.Size(158, 59);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(0, 0);
            // 
            // pOptions
            // 
            this.pOptions.Location = new System.Drawing.Point(0, 331);
            this.pOptions.Size = new System.Drawing.Size(300, 63);
            // 
            // pContents
            // 
            this.pContents.Controls.Add(this.txtQuantity);
            this.pContents.Controls.Add(this.label3);
            this.pContents.Controls.Add(this.chkVRMA);
            this.pContents.Controls.Add(this.gbVRMA);
            this.pContents.Location = new System.Drawing.Point(0, 0);
            this.pContents.Size = new System.Drawing.Size(300, 331);
            // 
            // gbVRMA
            // 
            this.gbVRMA.Controls.Add(this.chkReplacement);
            this.gbVRMA.Controls.Add(this.of);
            this.gbVRMA.Controls.Add(this.optNewVRMA);
            this.gbVRMA.Controls.Add(this.optUseVRMA);
            this.gbVRMA.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbVRMA.Location = new System.Drawing.Point(12, 57);
            this.gbVRMA.Name = "gbVRMA";
            this.gbVRMA.Size = new System.Drawing.Size(280, 268);
            this.gbVRMA.TabIndex = 4;
            this.gbVRMA.TabStop = false;
            // 
            // chkReplacement
            // 
            this.chkReplacement.AutoSize = true;
            this.chkReplacement.Location = new System.Drawing.Point(11, 241);
            this.chkReplacement.Name = "chkReplacement";
            this.chkReplacement.Size = new System.Drawing.Size(240, 23);
            this.chkReplacement.TabIndex = 6;
            this.chkReplacement.Text = "Vendor is sending a replacement";
            this.chkReplacement.UseVisualStyleBackColor = true;
            // 
            // of
            // 
            this.of.BackColor = System.Drawing.Color.White;
            this.of.Location = new System.Drawing.Point(7, 78);
            this.of.Margin = new System.Windows.Forms.Padding(4);
            this.of.Name = "of";
            this.of.Size = new System.Drawing.Size(263, 146);
            this.of.TabIndex = 5;
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
            this.chkVRMA.Location = new System.Drawing.Point(12, 42);
            this.chkVRMA.Name = "chkVRMA";
            this.chkVRMA.Size = new System.Drawing.Size(159, 23);
            this.chkVRMA.TabIndex = 6;
            this.chkVRMA.Text = "Make a Vendor RMA";
            this.chkVRMA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkVRMA.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Vendor RMA Quantity:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(201, 6);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(71, 31);
            this.txtQuantity.TabIndex = 9;
            this.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // VendRMASelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 394);
            this.Name = "VendRMASelection";
            this.Text = "Vendor RMA Selection";
            this.pOptions.ResumeLayout(false);
            this.pContents.ResumeLayout(false);
            this.pContents.PerformLayout();
            this.gbVRMA.ResumeLayout(false);
            this.gbVRMA.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkVRMA;
        private System.Windows.Forms.GroupBox gbVRMA;
        private System.Windows.Forms.RadioButton optNewVRMA;
        private System.Windows.Forms.RadioButton optUseVRMA;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label3;
        private Controls.OrderFinder of;
        private System.Windows.Forms.CheckBox chkReplacement;
    }
}