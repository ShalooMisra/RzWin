using Tools.Database;
namespace Rz5
{
    partial class TopCustomersReport
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
            this.optRankBySale = new System.Windows.Forms.RadioButton();
            this.optRankBySaleVolume = new System.Windows.Forms.RadioButton();
            this.ctl_Results = new NewMethod.nEdit_Number();
            this.gbOptions.SuspendLayout();
            this.panelAgent.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbOptions
            // 
            this.gbOptions.Controls.Add(this.ctl_Results);
            this.gbOptions.Controls.Add(this.optRankBySaleVolume);
            this.gbOptions.Controls.Add(this.optRankBySale);
            this.gbOptions.Controls.SetChildIndex(this.optRankBySale, 0);
            this.gbOptions.Controls.SetChildIndex(this.dtStart, 0);
            this.gbOptions.Controls.SetChildIndex(this.dtEnd, 0);
            this.gbOptions.Controls.SetChildIndex(this.lblCaption, 0);
            this.gbOptions.Controls.SetChildIndex(this.cmdView, 0);
            this.gbOptions.Controls.SetChildIndex(this.cboOrderBy, 0);
            this.gbOptions.Controls.SetChildIndex(this.lblOrderBy, 0);
            this.gbOptions.Controls.SetChildIndex(this.panelAgent, 0);
            this.gbOptions.Controls.SetChildIndex(this.optRankBySaleVolume, 0);
            this.gbOptions.Controls.SetChildIndex(this.ctl_Results, 0);
            // 
            // optRankBySale
            // 
            this.optRankBySale.AutoSize = true;
            this.optRankBySale.Checked = true;
            this.optRankBySale.Location = new System.Drawing.Point(10, 298);
            this.optRankBySale.Name = "optRankBySale";
            this.optRankBySale.Size = new System.Drawing.Size(90, 17);
            this.optRankBySale.TabIndex = 14;
            this.optRankBySale.TabStop = true;
            this.optRankBySale.Text = "Rank By Sale";
            this.optRankBySale.UseVisualStyleBackColor = true;
            // 
            // optRankBySaleVolume
            // 
            this.optRankBySaleVolume.AutoSize = true;
            this.optRankBySaleVolume.Location = new System.Drawing.Point(10, 321);
            this.optRankBySaleVolume.Name = "optRankBySaleVolume";
            this.optRankBySaleVolume.Size = new System.Drawing.Size(128, 17);
            this.optRankBySaleVolume.TabIndex = 15;
            this.optRankBySaleVolume.Text = "Rank By Sale Volume";
            this.optRankBySaleVolume.UseVisualStyleBackColor = true;
            // 
            // ctl_Results
            // 
            this.ctl_Results.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_Results.Bold = false;
            this.ctl_Results.Caption = "Result Limit";
            this.ctl_Results.Changed = true;
            this.ctl_Results.CurrentType = FieldType.Unknown;
            this.ctl_Results.Location = new System.Drawing.Point(10, 257);
            this.ctl_Results.Name = "ctl_Results";
            this.ctl_Results.Size = new System.Drawing.Size(170, 35);
            this.ctl_Results.TabIndex = 16;
            this.ctl_Results.UseParentBackColor = false;
            this.ctl_Results.zz_Enabled = true;
            this.ctl_Results.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_Results.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_Results.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_Results.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_Results.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_Results.zz_OriginalDesign = false;
            this.ctl_Results.zz_ShowErrorColor = true;
            this.ctl_Results.zz_ShowNeedsSaveColor = false;
            this.ctl_Results.zz_Text = "10";
            this.ctl_Results.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_Results.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_Results.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_Results.zz_UseGlobalColor = false;
            this.ctl_Results.zz_UseGlobalFont = false;
            // 
            // TopCustomersReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "TopCustomersReport";
            this.gbOptions.ResumeLayout(false);
            this.gbOptions.PerformLayout();
            this.panelAgent.ResumeLayout(false);
            this.panelAgent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton optRankBySale;
        private System.Windows.Forms.RadioButton optRankBySaleVolume;
        private NewMethod.nEdit_Number ctl_Results;
    }
}
