namespace ToolsWin.Dialogs
{
    partial class DateTimeChooser
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
            this.cal = new System.Windows.Forms.MonthCalendar();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.pTime = new System.Windows.Forms.Panel();
            this.pnlLineDetails = new System.Windows.Forms.Panel();
            this.lblPartTitle = new System.Windows.Forms.Label();
            this.lblQtyTitle = new System.Windows.Forms.Label();
            this.lblLineCodeTitle = new System.Windows.Forms.Label();
            this.lblQtyValue = new System.Windows.Forms.Label();
            this.lblLineCodeValue = new System.Windows.Forms.Label();
            this.lblPartValue = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pOptions.SuspendLayout();
            this.pContents.SuspendLayout();
            this.pTime.SuspendLayout();
            this.pnlLineDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(142, 0);
            this.cmdOK.Margin = new System.Windows.Forms.Padding(5);
            this.cmdOK.Size = new System.Drawing.Size(100, 59);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(0, 0);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(5);
            // 
            // pOptions
            // 
            this.pOptions.Location = new System.Drawing.Point(0, 292);
            this.pOptions.Size = new System.Drawing.Size(242, 63);
            // 
            // pContents
            // 
            this.pContents.Controls.Add(this.lblTitle);
            this.pContents.Controls.Add(this.pnlLineDetails);
            this.pContents.Controls.Add(this.pTime);
            this.pContents.Controls.Add(this.cal);
            this.pContents.Location = new System.Drawing.Point(0, 0);
            this.pContents.Margin = new System.Windows.Forms.Padding(4);
            this.pContents.Size = new System.Drawing.Size(242, 292);
            // 
            // cal
            // 
            this.cal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cal.Location = new System.Drawing.Point(8, 76);
            this.cal.Name = "cal";
            this.cal.TabIndex = 1;
            this.cal.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.cal_DateSelected);
            // 
            // txtTime
            // 
            this.txtTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime.Location = new System.Drawing.Point(72, 4);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(121, 29);
            this.txtTime.TabIndex = 2;
            this.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(19, 10);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(47, 20);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "Time:";
            // 
            // pTime
            // 
            this.pTime.Controls.Add(this.txtTime);
            this.pTime.Controls.Add(this.lblTime);
            this.pTime.Location = new System.Drawing.Point(8, 244);
            this.pTime.Name = "pTime";
            this.pTime.Size = new System.Drawing.Size(227, 39);
            this.pTime.TabIndex = 4;
            // 
            // pnlLineDetails
            // 
            this.pnlLineDetails.Controls.Add(this.lblPartTitle);
            this.pnlLineDetails.Controls.Add(this.lblQtyTitle);
            this.pnlLineDetails.Controls.Add(this.lblLineCodeTitle);
            this.pnlLineDetails.Controls.Add(this.lblQtyValue);
            this.pnlLineDetails.Controls.Add(this.lblLineCodeValue);
            this.pnlLineDetails.Controls.Add(this.lblPartValue);
            this.pnlLineDetails.Location = new System.Drawing.Point(8, 26);
            this.pnlLineDetails.Name = "pnlLineDetails";
            this.pnlLineDetails.Size = new System.Drawing.Size(227, 48);
            this.pnlLineDetails.TabIndex = 5;
            // 
            // lblPartTitle
            // 
            this.lblPartTitle.AutoSize = true;
            this.lblPartTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartTitle.Location = new System.Drawing.Point(4, 5);
            this.lblPartTitle.Name = "lblPartTitle";
            this.lblPartTitle.Size = new System.Drawing.Size(34, 13);
            this.lblPartTitle.TabIndex = 12;
            this.lblPartTitle.Text = "Part:";
            // 
            // lblQtyTitle
            // 
            this.lblQtyTitle.AutoSize = true;
            this.lblQtyTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtyTitle.Location = new System.Drawing.Point(95, 26);
            this.lblQtyTitle.Name = "lblQtyTitle";
            this.lblQtyTitle.Size = new System.Drawing.Size(36, 13);
            this.lblQtyTitle.TabIndex = 11;
            this.lblQtyTitle.Text = "QTY:";
            // 
            // lblLineCodeTitle
            // 
            this.lblLineCodeTitle.AutoSize = true;
            this.lblLineCodeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLineCodeTitle.Location = new System.Drawing.Point(4, 26);
            this.lblLineCodeTitle.Name = "lblLineCodeTitle";
            this.lblLineCodeTitle.Size = new System.Drawing.Size(35, 13);
            this.lblLineCodeTitle.TabIndex = 10;
            this.lblLineCodeTitle.Text = "Line:";
            // 
            // lblQtyValue
            // 
            this.lblQtyValue.AutoSize = true;
            this.lblQtyValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtyValue.Location = new System.Drawing.Point(133, 26);
            this.lblQtyValue.Name = "lblQtyValue";
            this.lblQtyValue.Size = new System.Drawing.Size(73, 13);
            this.lblQtyValue.TabIndex = 9;
            this.lblQtyValue.Text = "<123456789>";
            // 
            // lblLineCodeValue
            // 
            this.lblLineCodeValue.AutoSize = true;
            this.lblLineCodeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLineCodeValue.Location = new System.Drawing.Point(39, 26);
            this.lblLineCodeValue.Name = "lblLineCodeValue";
            this.lblLineCodeValue.Size = new System.Drawing.Size(37, 13);
            this.lblLineCodeValue.TabIndex = 8;
            this.lblLineCodeValue.Text = "<123>";
            // 
            // lblPartValue
            // 
            this.lblPartValue.AutoSize = true;
            this.lblPartValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartValue.Location = new System.Drawing.Point(39, 5);
            this.lblPartValue.Name = "lblPartValue";
            this.lblPartValue.Size = new System.Drawing.Size(85, 13);
            this.lblPartValue.TabIndex = 7;
            this.lblPartValue.Text = "<fullpartnumber>";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(5, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(75, 17);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "<lblTitle>";
            // 
            // DateTimeChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 355);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "DateTimeChooser";
            this.Text = "Date Selection";
            this.Activated += new System.EventHandler(this.DateTimeChooser_Activated);
            this.pOptions.ResumeLayout(false);
            this.pContents.ResumeLayout(false);
            this.pContents.PerformLayout();
            this.pTime.ResumeLayout(false);
            this.pTime.PerformLayout();
            this.pnlLineDetails.ResumeLayout(false);
            this.pnlLineDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.MonthCalendar cal;
        private System.Windows.Forms.Panel pTime;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlLineDetails;
        private System.Windows.Forms.Label lblPartTitle;
        private System.Windows.Forms.Label lblQtyTitle;
        private System.Windows.Forms.Label lblLineCodeTitle;
        private System.Windows.Forms.Label lblQtyValue;
        private System.Windows.Forms.Label lblLineCodeValue;
        private System.Windows.Forms.Label lblPartValue;
    }
}