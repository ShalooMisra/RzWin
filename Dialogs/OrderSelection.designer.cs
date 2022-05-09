namespace Rz5.Win.Dialogs
{
    partial class OrderSelection
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
            this.optNew = new System.Windows.Forms.RadioButton();
            this.optUse = new System.Windows.Forms.RadioButton();
            this.of = new Rz5.Win.Controls.OrderFinder();
            this.pOptions.SuspendLayout();
            this.pContents.SuspendLayout();
            this.gbVRMA.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(142, 0);
            this.cmdOK.Size = new System.Drawing.Size(158, 58);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(0, 0);
            // 
            // pOptions
            // 
            this.pOptions.Location = new System.Drawing.Point(0, 245);
            this.pOptions.Size = new System.Drawing.Size(300, 63);
            // 
            // pContents
            // 
            this.pContents.Controls.Add(this.gbVRMA);
            this.pContents.Location = new System.Drawing.Point(0, 0);
            this.pContents.Size = new System.Drawing.Size(300, 245);
            // 
            // gbVRMA
            // 
            this.gbVRMA.Controls.Add(this.of);
            this.gbVRMA.Controls.Add(this.optNew);
            this.gbVRMA.Controls.Add(this.optUse);
            this.gbVRMA.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbVRMA.Location = new System.Drawing.Point(12, 2);
            this.gbVRMA.Name = "gbVRMA";
            this.gbVRMA.Size = new System.Drawing.Size(280, 235);
            this.gbVRMA.TabIndex = 4;
            this.gbVRMA.TabStop = false;
            // 
            // optNew
            // 
            this.optNew.AutoSize = true;
            this.optNew.Checked = true;
            this.optNew.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optNew.Location = new System.Drawing.Point(6, 22);
            this.optNew.Name = "optNew";
            this.optNew.Size = new System.Drawing.Size(192, 27);
            this.optNew.TabIndex = 3;
            this.optNew.TabStop = true;
            this.optNew.Text = "Create A New Invoice";
            this.optNew.UseVisualStyleBackColor = true;
            this.optNew.Click += new System.EventHandler(this.optNewVRMA_Click);
            // 
            // optUse
            // 
            this.optUse.AutoSize = true;
            this.optUse.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optUse.Location = new System.Drawing.Point(6, 46);
            this.optUse.Name = "optUse";
            this.optUse.Size = new System.Drawing.Size(220, 27);
            this.optUse.TabIndex = 4;
            this.optUse.Text = "Add To An Existing VRMA";
            this.optUse.UseVisualStyleBackColor = true;
            this.optUse.Click += new System.EventHandler(this.optUseVRMA_Click);
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
            // OrderSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 308);
            this.Name = "OrderSelection";
            this.Text = "Invoice Selection";
            this.pOptions.ResumeLayout(false);
            this.pContents.ResumeLayout(false);
            this.gbVRMA.ResumeLayout(false);
            this.gbVRMA.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbVRMA;
        private System.Windows.Forms.RadioButton optNew;
        private System.Windows.Forms.RadioButton optUse;
        private Controls.OrderFinder of;
    }
}