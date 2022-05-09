namespace NewMethod
{
    partial class frmConversionOptions
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
            this.lblInstruct = new System.Windows.Forms.Label();
            this.optCancel = new System.Windows.Forms.RadioButton();
            this.optDelete = new System.Windows.Forms.RadioButton();
            this.optConvert = new System.Windows.Forms.RadioButton();
            this.cboOptions = new System.Windows.Forms.ComboBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblInstruct
            // 
            this.lblInstruct.Location = new System.Drawing.Point(4, 5);
            this.lblInstruct.Name = "lblInstruct";
            this.lblInstruct.Size = new System.Drawing.Size(343, 50);
            this.lblInstruct.TabIndex = 0;
            this.lblInstruct.Text = "<instructions>";
            this.lblInstruct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // optCancel
            // 
            this.optCancel.AutoSize = true;
            this.optCancel.Checked = true;
            this.optCancel.Location = new System.Drawing.Point(7, 69);
            this.optCancel.Name = "optCancel";
            this.optCancel.Size = new System.Drawing.Size(148, 17);
            this.optCancel.TabIndex = 1;
            this.optCancel.TabStop = true;
            this.optCancel.Text = "Cancel the entire process.";
            this.optCancel.UseVisualStyleBackColor = true;
            // 
            // optDelete
            // 
            this.optDelete.AutoSize = true;
            this.optDelete.Location = new System.Drawing.Point(7, 92);
            this.optDelete.Name = "optDelete";
            this.optDelete.Size = new System.Drawing.Size(220, 17);
            this.optDelete.TabIndex = 2;
            this.optDelete.Text = "Delete  the items that can\'t be converted.";
            this.optDelete.UseVisualStyleBackColor = true;
            // 
            // optConvert
            // 
            this.optConvert.AutoSize = true;
            this.optConvert.Location = new System.Drawing.Point(7, 116);
            this.optConvert.Name = "optConvert";
            this.optConvert.Size = new System.Drawing.Size(205, 17);
            this.optConvert.TabIndex = 3;
            this.optConvert.Text = "Change the non-convertible values to:";
            this.optConvert.UseVisualStyleBackColor = true;
            this.optConvert.CheckedChanged += new System.EventHandler(this.optConvert_CheckedChanged);
            // 
            // cboOptions
            // 
            this.cboOptions.FormattingEnabled = true;
            this.cboOptions.Location = new System.Drawing.Point(218, 115);
            this.cboOptions.Name = "cboOptions";
            this.cboOptions.Size = new System.Drawing.Size(120, 21);
            this.cboOptions.TabIndex = 4;
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(95, 151);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(160, 50);
            this.cmdOK.TabIndex = 5;
            this.cmdOK.Text = "&OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // frmConversionOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 211);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cboOptions);
            this.Controls.Add(this.optConvert);
            this.Controls.Add(this.optDelete);
            this.Controls.Add(this.optCancel);
            this.Controls.Add(this.lblInstruct);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConversionOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conversion Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInstruct;
        private System.Windows.Forms.RadioButton optCancel;
        private System.Windows.Forms.RadioButton optDelete;
        private System.Windows.Forms.RadioButton optConvert;
        private System.Windows.Forms.ComboBox cboOptions;
        private System.Windows.Forms.Button cmdOK;
    }
}