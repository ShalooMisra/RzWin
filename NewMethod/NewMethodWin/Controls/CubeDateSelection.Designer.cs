namespace NewMethod
{
    partial class CubeDateSelection
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
            this.gb = new System.Windows.Forms.GroupBox();
            this.cmdChoose = new System.Windows.Forms.Button();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.cmdNext = new System.Windows.Forms.Button();
            this.cmdPrevious = new System.Windows.Forms.Button();
            this.optByYear = new System.Windows.Forms.RadioButton();
            this.optByQuarter = new System.Windows.Forms.RadioButton();
            this.optByMonth = new System.Windows.Forms.RadioButton();
            this.optByWeek = new System.Windows.Forms.RadioButton();
            this.optByDay = new System.Windows.Forms.RadioButton();
            this.gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb
            // 
            this.gb.Controls.Add(this.cmdChoose);
            this.gb.Controls.Add(this.cmdRefresh);
            this.gb.Controls.Add(this.lblCurrent);
            this.gb.Controls.Add(this.cmdNext);
            this.gb.Controls.Add(this.cmdPrevious);
            this.gb.Controls.Add(this.optByYear);
            this.gb.Controls.Add(this.optByQuarter);
            this.gb.Controls.Add(this.optByMonth);
            this.gb.Controls.Add(this.optByWeek);
            this.gb.Controls.Add(this.optByDay);
            this.gb.Location = new System.Drawing.Point(3, 3);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(595, 99);
            this.gb.TabIndex = 2;
            this.gb.TabStop = false;
            // 
            // cmdChoose
            // 
            this.cmdChoose.Location = new System.Drawing.Point(365, 73);
            this.cmdChoose.Name = "cmdChoose";
            this.cmdChoose.Size = new System.Drawing.Size(61, 20);
            this.cmdChoose.TabIndex = 9;
            this.cmdChoose.Text = "Choose";
            this.cmdChoose.UseVisualStyleBackColor = true;
            this.cmdChoose.Click += new System.EventHandler(this.cmdChoose_Click);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Location = new System.Drawing.Point(298, 73);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(61, 20);
            this.cmdRefresh.TabIndex = 8;
            this.cmdRefresh.Text = "Refresh";
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // lblCurrent
            // 
            this.lblCurrent.Location = new System.Drawing.Point(306, 30);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(106, 28);
            this.lblCurrent.TabIndex = 7;
            this.lblCurrent.Text = "<current>";
            this.lblCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdNext
            // 
            this.cmdNext.Location = new System.Drawing.Point(418, 31);
            this.cmdNext.Name = "cmdNext";
            this.cmdNext.Size = new System.Drawing.Size(126, 28);
            this.cmdNext.TabIndex = 6;
            this.cmdNext.Text = "Next >";
            this.cmdNext.UseVisualStyleBackColor = true;
            this.cmdNext.Click += new System.EventHandler(this.cmdNext_Click);
            // 
            // cmdPrevious
            // 
            this.cmdPrevious.Location = new System.Drawing.Point(174, 31);
            this.cmdPrevious.Name = "cmdPrevious";
            this.cmdPrevious.Size = new System.Drawing.Size(126, 28);
            this.cmdPrevious.TabIndex = 5;
            this.cmdPrevious.Text = "<  Previous";
            this.cmdPrevious.UseVisualStyleBackColor = true;
            this.cmdPrevious.Click += new System.EventHandler(this.cmdPrevious_Click);
            // 
            // optByYear
            // 
            this.optByYear.AutoSize = true;
            this.optByYear.Location = new System.Drawing.Point(6, 77);
            this.optByYear.Name = "optByYear";
            this.optByYear.Size = new System.Drawing.Size(62, 17);
            this.optByYear.TabIndex = 4;
            this.optByYear.Text = "By Year";
            this.optByYear.UseVisualStyleBackColor = true;
            this.optByYear.CheckedChanged += new System.EventHandler(this.optBy_CheckedChanged);
            // 
            // optByQuarter
            // 
            this.optByQuarter.AutoSize = true;
            this.optByQuarter.Location = new System.Drawing.Point(6, 59);
            this.optByQuarter.Name = "optByQuarter";
            this.optByQuarter.Size = new System.Drawing.Size(75, 17);
            this.optByQuarter.TabIndex = 3;
            this.optByQuarter.Text = "By Quarter";
            this.optByQuarter.UseVisualStyleBackColor = true;
            this.optByQuarter.CheckedChanged += new System.EventHandler(this.optBy_CheckedChanged);
            // 
            // optByMonth
            // 
            this.optByMonth.AutoSize = true;
            this.optByMonth.Location = new System.Drawing.Point(6, 42);
            this.optByMonth.Name = "optByMonth";
            this.optByMonth.Size = new System.Drawing.Size(70, 17);
            this.optByMonth.TabIndex = 2;
            this.optByMonth.Text = "By Month";
            this.optByMonth.UseVisualStyleBackColor = true;
            this.optByMonth.CheckedChanged += new System.EventHandler(this.optBy_CheckedChanged);
            // 
            // optByWeek
            // 
            this.optByWeek.AutoSize = true;
            this.optByWeek.Location = new System.Drawing.Point(6, 26);
            this.optByWeek.Name = "optByWeek";
            this.optByWeek.Size = new System.Drawing.Size(69, 17);
            this.optByWeek.TabIndex = 1;
            this.optByWeek.Text = "By Week";
            this.optByWeek.UseVisualStyleBackColor = true;
            this.optByWeek.CheckedChanged += new System.EventHandler(this.optBy_CheckedChanged);
            // 
            // optByDay
            // 
            this.optByDay.AutoSize = true;
            this.optByDay.Checked = true;
            this.optByDay.Location = new System.Drawing.Point(6, 10);
            this.optByDay.Name = "optByDay";
            this.optByDay.Size = new System.Drawing.Size(59, 17);
            this.optByDay.TabIndex = 0;
            this.optByDay.TabStop = true;
            this.optByDay.Text = "By Day";
            this.optByDay.UseVisualStyleBackColor = true;
            this.optByDay.CheckedChanged += new System.EventHandler(this.optBy_CheckedChanged);
            // 
            // CubeDateSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb);
            this.Name = "CubeDateSelection";
            this.Size = new System.Drawing.Size(604, 109);
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.Button cmdChoose;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.Button cmdNext;
        private System.Windows.Forms.Button cmdPrevious;
        private System.Windows.Forms.RadioButton optByYear;
        private System.Windows.Forms.RadioButton optByQuarter;
        private System.Windows.Forms.RadioButton optByMonth;
        private System.Windows.Forms.RadioButton optByWeek;
        private System.Windows.Forms.RadioButton optByDay;
    }
}
