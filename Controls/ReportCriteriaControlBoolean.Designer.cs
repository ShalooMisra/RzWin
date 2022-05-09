namespace Rz5.Win.Controls
{
    partial class ReportCriteriaControlBoolean
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
            this.chkValue = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // chkValue
            // 
            this.chkValue.AutoSize = true;
            this.chkValue.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkValue.Location = new System.Drawing.Point(32, 10);
            this.chkValue.Name = "chkValue";
            this.chkValue.Size = new System.Drawing.Size(56, 19);
            this.chkValue.TabIndex = 3;
            this.chkValue.Text = "Value";
            this.chkValue.UseVisualStyleBackColor = true;
            this.chkValue.Click += new System.EventHandler(this.chkValue_Click);
            // 
            // ReportCriteriaControlBoolean
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkValue);
            this.Name = "ReportCriteriaControlBoolean";
            this.Size = new System.Drawing.Size(203, 42);
            this.Controls.SetChildIndex(this.pic, 0);
            this.Controls.SetChildIndex(this.chkValue, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkValue;
    }
}
