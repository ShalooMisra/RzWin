using NewMethod;

namespace Rz5
{
    partial class frmPostpone
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
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdTwoWeeks = new System.Windows.Forms.Button();
            this.cmdoneHour = new System.Windows.Forms.Button();
            this.cmdTwoHours = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmdOneMonth = new System.Windows.Forms.Button();
            this.cmdTwoMonths = new System.Windows.Forms.Button();
            this.cmdOneDay = new System.Windows.Forms.Button();
            this.cmdTwoDays = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(9, 330);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(108, 28);
            this.cmdCancel.TabIndex = 0;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdTwoWeeks
            // 
            this.cmdTwoWeeks.Location = new System.Drawing.Point(9, 200);
            this.cmdTwoWeeks.Name = "cmdTwoWeeks";
            this.cmdTwoWeeks.Size = new System.Drawing.Size(108, 28);
            this.cmdTwoWeeks.TabIndex = 1;
            this.cmdTwoWeeks.Text = "Two Weeks";
            this.cmdTwoWeeks.UseVisualStyleBackColor = true;
            this.cmdTwoWeeks.Click += new System.EventHandler(this.cmdTwoWeeks_Click);
            // 
            // cmdoneHour
            // 
            this.cmdoneHour.Location = new System.Drawing.Point(9, 12);
            this.cmdoneHour.Name = "cmdoneHour";
            this.cmdoneHour.Size = new System.Drawing.Size(108, 28);
            this.cmdoneHour.TabIndex = 2;
            this.cmdoneHour.Text = "One Hour";
            this.cmdoneHour.UseVisualStyleBackColor = true;
            this.cmdoneHour.Click += new System.EventHandler(this.cmdoneHour_Click);
            // 
            // cmdTwoHours
            // 
            this.cmdTwoHours.Location = new System.Drawing.Point(9, 46);
            this.cmdTwoHours.Name = "cmdTwoHours";
            this.cmdTwoHours.Size = new System.Drawing.Size(108, 28);
            this.cmdTwoHours.TabIndex = 3;
            this.cmdTwoHours.Text = "Two Hours";
            this.cmdTwoHours.UseVisualStyleBackColor = true;
            this.cmdTwoHours.Click += new System.EventHandler(this.cmdTwoHours_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 166);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "One Week";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdOneMonth
            // 
            this.cmdOneMonth.Location = new System.Drawing.Point(10, 243);
            this.cmdOneMonth.Name = "cmdOneMonth";
            this.cmdOneMonth.Size = new System.Drawing.Size(108, 28);
            this.cmdOneMonth.TabIndex = 5;
            this.cmdOneMonth.Text = "One Month";
            this.cmdOneMonth.UseVisualStyleBackColor = true;
            this.cmdOneMonth.Click += new System.EventHandler(this.cmdOneMonth_Click);
            // 
            // cmdTwoMonths
            // 
            this.cmdTwoMonths.Location = new System.Drawing.Point(9, 277);
            this.cmdTwoMonths.Name = "cmdTwoMonths";
            this.cmdTwoMonths.Size = new System.Drawing.Size(108, 28);
            this.cmdTwoMonths.TabIndex = 6;
            this.cmdTwoMonths.Text = "Two Months";
            this.cmdTwoMonths.UseVisualStyleBackColor = true;
            this.cmdTwoMonths.Click += new System.EventHandler(this.cmdTwoMonths_Click);
            // 
            // cmdOneDay
            // 
            this.cmdOneDay.Location = new System.Drawing.Point(9, 88);
            this.cmdOneDay.Name = "cmdOneDay";
            this.cmdOneDay.Size = new System.Drawing.Size(108, 28);
            this.cmdOneDay.TabIndex = 8;
            this.cmdOneDay.Text = "One Day";
            this.cmdOneDay.UseVisualStyleBackColor = true;
            this.cmdOneDay.Click += new System.EventHandler(this.cmdOneDay_Click);
            // 
            // cmdTwoDays
            // 
            this.cmdTwoDays.Location = new System.Drawing.Point(9, 122);
            this.cmdTwoDays.Name = "cmdTwoDays";
            this.cmdTwoDays.Size = new System.Drawing.Size(108, 28);
            this.cmdTwoDays.TabIndex = 7;
            this.cmdTwoDays.Text = "Two Days";
            this.cmdTwoDays.UseVisualStyleBackColor = true;
            this.cmdTwoDays.Click += new System.EventHandler(this.cmdTwoDays_Click);
            // 
            // frmPostpone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(129, 365);
            this.ControlBox = false;
            this.Controls.Add(this.cmdOneDay);
            this.Controls.Add(this.cmdTwoDays);
            this.Controls.Add(this.cmdTwoMonths);
            this.Controls.Add(this.cmdOneMonth);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdTwoHours);
            this.Controls.Add(this.cmdoneHour);
            this.Controls.Add(this.cmdTwoWeeks);
            this.Controls.Add(this.cmdCancel);
            this.Name = "frmPostpone";
            this.Text = "Postpone";
            this.Activated += new System.EventHandler(this.frmPostpone_Activated);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdTwoWeeks;
        private System.Windows.Forms.Button cmdoneHour;
        private System.Windows.Forms.Button cmdTwoHours;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cmdOneMonth;
        private System.Windows.Forms.Button cmdTwoMonths;
        private System.Windows.Forms.Button cmdOneDay;
        private System.Windows.Forms.Button cmdTwoDays;
    }
}