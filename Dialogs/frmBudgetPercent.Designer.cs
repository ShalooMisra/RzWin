namespace RzInterfaceWin
{
    partial class frmBudgetPercent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBudgetPercent));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.optIncrease = new System.Windows.Forms.RadioButton();
            this.optDecrease = new System.Windows.Forms.RadioButton();
            this.ctl_percent = new NewMethod.nEdit_Money();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(247, 66);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(122, 33);
            this.cmdCancel.TabIndex = 0;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOK.Location = new System.Drawing.Point(384, 66);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(122, 33);
            this.cmdOK.TabIndex = 1;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // optIncrease
            // 
            this.optIncrease.AutoSize = true;
            this.optIncrease.Checked = true;
            this.optIncrease.Location = new System.Drawing.Point(12, 12);
            this.optIncrease.Name = "optIncrease";
            this.optIncrease.Size = new System.Drawing.Size(410, 21);
            this.optIncrease.TabIndex = 3;
            this.optIncrease.TabStop = true;
            this.optIncrease.Text = "Increase each monthly amount in this row by this percentage";
            this.optIncrease.UseVisualStyleBackColor = true;
            // 
            // optDecrease
            // 
            this.optDecrease.AutoSize = true;
            this.optDecrease.Location = new System.Drawing.Point(12, 39);
            this.optDecrease.Name = "optDecrease";
            this.optDecrease.Size = new System.Drawing.Size(417, 21);
            this.optDecrease.TabIndex = 5;
            this.optDecrease.Text = "Decrease each monthly amount in this row by this percentage";
            this.optDecrease.UseVisualStyleBackColor = true;
            // 
            // ctl_percent
            // 
            this.ctl_percent.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_percent.Bold = false;
            this.ctl_percent.Caption = "";
            this.ctl_percent.Changed = false;
            this.ctl_percent.EditCaption = false;
            this.ctl_percent.FullDecimal = false;
            this.ctl_percent.Location = new System.Drawing.Point(439, 24);
            this.ctl_percent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctl_percent.Name = "ctl_percent";
            this.ctl_percent.RoundNearestCent = false;
            this.ctl_percent.Size = new System.Drawing.Size(67, 24);
            this.ctl_percent.TabIndex = 6;
            this.ctl_percent.UseParentBackColor = false;
            this.ctl_percent.zz_Enabled = true;
            this.ctl_percent.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_percent.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_percent.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_percent.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_percent.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctl_percent.zz_OriginalDesign = false;
            this.ctl_percent.zz_ShowErrorColor = true;
            this.ctl_percent.zz_ShowNeedsSaveColor = false;
            this.ctl_percent.zz_Text = "";
            this.ctl_percent.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_percent.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_percent.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_percent.zz_UseGlobalColor = false;
            this.ctl_percent.zz_UseGlobalFont = false;
            // 
            // frmBudgetPercent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 108);
            this.Controls.Add(this.ctl_percent);
            this.Controls.Add(this.optDecrease);
            this.Controls.Add(this.optIncrease);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBudgetPercent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Budget Percent";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.RadioButton optIncrease;
        private System.Windows.Forms.RadioButton optDecrease;
        private NewMethod.nEdit_Money ctl_percent;
    }
}