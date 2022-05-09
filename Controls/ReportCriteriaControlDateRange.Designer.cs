namespace Rz5.Win.Controls
{
    partial class ReportCriteriaControlDateRange
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
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.cboDate = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // pic
            // 
            this.pic.BackgroundImage = global::RzInterfaceWin.Properties.Resources.Calendar;
            // 
            // dtStart
            // 
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStart.Location = new System.Drawing.Point(7, 60);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(84, 20);
            this.dtStart.TabIndex = 5;
            this.dtStart.Visible = false;
            this.dtStart.ValueChanged += new System.EventHandler(this.dtStart_ValueChanged);
            // 
            // dtEnd
            // 
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEnd.Location = new System.Drawing.Point(105, 60);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(84, 20);
            this.dtEnd.TabIndex = 7;
            this.dtEnd.Visible = false;
            this.dtEnd.ValueChanged += new System.EventHandler(this.dtEnd_ValueChanged);
            // 
            // cboDate
            // 
            this.cboDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDate.FormattingEnabled = true;
            this.cboDate.Location = new System.Drawing.Point(13, 32);
            this.cboDate.Name = "cboDate";
            this.cboDate.Size = new System.Drawing.Size(170, 21);
            this.cboDate.TabIndex = 8;
            this.cboDate.SelectedValueChanged += new System.EventHandler(this.cboDate_SelectedValueChanged);
            // 
            // ReportCriteriaControlDateRange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboDate);
            this.Controls.Add(this.dtEnd);
            this.Controls.Add(this.dtStart);
            this.Name = "ReportCriteriaControlDateRange";
            this.Size = new System.Drawing.Size(203, 84);
            this.Controls.SetChildIndex(this.pic, 0);
            this.Controls.SetChildIndex(this.dtStart, 0);
            this.Controls.SetChildIndex(this.dtEnd, 0);
            this.Controls.SetChildIndex(this.cboDate, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.ComboBox cboDate;

    }
}
