namespace Rz5
{
    partial class frmChooseCreditCharge
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
            this.cmd6 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmd3 = new System.Windows.Forms.Button();
            this.cmdWaive = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmd6
            // 
            this.cmd6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd6.Location = new System.Drawing.Point(6, 34);
            this.cmd6.Name = "cmd6";
            this.cmd6.Size = new System.Drawing.Size(519, 38);
            this.cmd6.TabIndex = 0;
            this.cmd6.Text = "6%";
            this.cmd6.UseVisualStyleBackColor = true;
            this.cmd6.Click += new System.EventHandler(this.cmd6_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(523, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please select the percent to be applied to this credit card order.";
            // 
            // cmd3
            // 
            this.cmd3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd3.Location = new System.Drawing.Point(6, 78);
            this.cmd3.Name = "cmd3";
            this.cmd3.Size = new System.Drawing.Size(519, 38);
            this.cmd3.TabIndex = 2;
            this.cmd3.Text = "3%";
            this.cmd3.UseVisualStyleBackColor = true;
            this.cmd3.Click += new System.EventHandler(this.cmd3_Click);
            // 
            // cmdWaive
            // 
            this.cmdWaive.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdWaive.Location = new System.Drawing.Point(6, 122);
            this.cmdWaive.Name = "cmdWaive";
            this.cmdWaive.Size = new System.Drawing.Size(519, 38);
            this.cmdWaive.TabIndex = 3;
            this.cmdWaive.Text = "Waive Fee";
            this.cmdWaive.UseVisualStyleBackColor = true;
            this.cmdWaive.Click += new System.EventHandler(this.cmdWaive_Click);
            // 
            // frmChooseCreditCharge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 167);
            this.Controls.Add(this.cmdWaive);
            this.Controls.Add(this.cmd3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmd6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmChooseCreditCharge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose Credit Charge Percent";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmd6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmd3;
        private System.Windows.Forms.Button cmdWaive;
    }
}