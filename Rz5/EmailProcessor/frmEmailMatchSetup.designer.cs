namespace Rz3_Common
{
    partial class frmEmailMatchSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmailMatchSetup));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.optFull = new System.Windows.Forms.RadioButton();
            this.optFull50 = new System.Windows.Forms.RadioButton();
            this.optBase = new System.Windows.Forms.RadioButton();
            this.optStripped = new System.Windows.Forms.RadioButton();
            this.optTrunced = new System.Windows.Forms.RadioButton();
            this.optCustom = new System.Windows.Forms.RadioButton();
            this.txtCustom = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cmdApply = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(644, 102);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose one of the options below to determine the criteria that Rz3 will use to ma" +
                "tch incoming requirements with your list of stock, consignments, and availibilit" +
                "ies.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlText;
            this.pictureBox1.Location = new System.Drawing.Point(12, 112);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(644, 2);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 35);
            this.label2.TabIndex = 2;
            this.label2.Text = "High Quality";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 314);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 35);
            this.label3.TabIndex = 3;
            this.label3.Text = "High Volume";
            // 
            // optFull
            // 
            this.optFull.AutoSize = true;
            this.optFull.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optFull.Location = new System.Drawing.Point(18, 164);
            this.optFull.Name = "optFull";
            this.optFull.Size = new System.Drawing.Size(529, 23);
            this.optFull.TabIndex = 4;
            this.optFull.Text = "Match by the full part number, and only match parts with a quantity of 500 or mor" +
                "e.";
            this.optFull.UseVisualStyleBackColor = true;
            // 
            // optFull50
            // 
            this.optFull50.AutoSize = true;
            this.optFull50.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optFull50.Location = new System.Drawing.Point(18, 193);
            this.optFull50.Name = "optFull50";
            this.optFull50.Size = new System.Drawing.Size(521, 23);
            this.optFull50.TabIndex = 5;
            this.optFull50.Text = "Match by the full part number, and only match parts with a quantity of 50 or more" +
                ".";
            this.optFull50.UseVisualStyleBackColor = true;
            // 
            // optBase
            // 
            this.optBase.AutoSize = true;
            this.optBase.Checked = true;
            this.optBase.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optBase.Location = new System.Drawing.Point(18, 222);
            this.optBase.Name = "optBase";
            this.optBase.Size = new System.Drawing.Size(232, 23);
            this.optBase.TabIndex = 6;
            this.optBase.TabStop = true;
            this.optBase.Text = "Match by the whole base number.";
            this.optBase.UseVisualStyleBackColor = true;
            // 
            // optStripped
            // 
            this.optStripped.AutoSize = true;
            this.optStripped.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optStripped.Location = new System.Drawing.Point(18, 251);
            this.optStripped.Name = "optStripped";
            this.optStripped.Size = new System.Drawing.Size(541, 23);
            this.optStripped.TabIndex = 7;
            this.optStripped.Text = "Match by the base number, stripped of any non-standard characters (such as ^][{}-" +
                ").";
            this.optStripped.UseVisualStyleBackColor = true;
            // 
            // optTrunced
            // 
            this.optTrunced.AutoSize = true;
            this.optTrunced.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optTrunced.Location = new System.Drawing.Point(18, 280);
            this.optTrunced.Name = "optTrunced";
            this.optTrunced.Size = new System.Drawing.Size(563, 23);
            this.optTrunced.TabIndex = 8;
            this.optTrunced.Text = "Match by the base number, truncated after any non-standard characters (such as ^]" +
                "[{}-).\r\n";
            this.optTrunced.UseVisualStyleBackColor = true;
            // 
            // optCustom
            // 
            this.optCustom.AutoSize = true;
            this.optCustom.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optCustom.Location = new System.Drawing.Point(18, 355);
            this.optCustom.Name = "optCustom";
            this.optCustom.Size = new System.Drawing.Size(74, 23);
            this.optCustom.TabIndex = 9;
            this.optCustom.Text = "Custom";
            this.optCustom.UseVisualStyleBackColor = true;
            // 
            // txtCustom
            // 
            this.txtCustom.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustom.Location = new System.Drawing.Point(98, 353);
            this.txtCustom.Name = "txtCustom";
            this.txtCustom.Size = new System.Drawing.Size(558, 26);
            this.txtCustom.TabIndex = 10;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlText;
            this.pictureBox2.Location = new System.Drawing.Point(12, 311);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(644, 2);
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // cmdApply
            // 
            this.cmdApply.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdApply.Location = new System.Drawing.Point(12, 389);
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(316, 35);
            this.cmdApply.TabIndex = 12;
            this.cmdApply.Text = "&Apply";
            this.cmdApply.UseVisualStyleBackColor = true;
            this.cmdApply.Click += new System.EventHandler(this.cmdApply_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Location = new System.Drawing.Point(340, 389);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(316, 35);
            this.cmdCancel.TabIndex = 13;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmEmailMatchSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 429);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdApply);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txtCustom);
            this.Controls.Add(this.optCustom);
            this.Controls.Add(this.optTrunced);
            this.Controls.Add(this.optStripped);
            this.Controls.Add(this.optBase);
            this.Controls.Add(this.optFull50);
            this.Controls.Add(this.optFull);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmEmailMatchSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Email Match Setup";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton optFull;
        private System.Windows.Forms.RadioButton optFull50;
        private System.Windows.Forms.RadioButton optBase;
        private System.Windows.Forms.RadioButton optStripped;
        private System.Windows.Forms.RadioButton optTrunced;
        private System.Windows.Forms.RadioButton optCustom;
        private System.Windows.Forms.TextBox txtCustom;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button cmdApply;
        private System.Windows.Forms.Button cmdCancel;
    }
}