namespace RzInterfaceWin
{
    partial class frmNewBudget
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewBudget));
            this.udYear = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.optScratch = new System.Windows.Forms.RadioButton();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.optPrevData = new System.Windows.Forms.RadioButton();
            this.cmdFinish = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.udYear)).BeginInit();
            this.SuspendLayout();
            // 
            // udYear
            // 
            this.udYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udYear.Location = new System.Drawing.Point(117, 81);
            this.udYear.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.udYear.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.udYear.Name = "udYear";
            this.udYear.Size = new System.Drawing.Size(157, 30);
            this.udYear.TabIndex = 0;
            this.udYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.udYear.Value = new decimal(new int[] {
            2014,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Create a New Budget";
            // 
            // optScratch
            // 
            this.optScratch.AutoSize = true;
            this.optScratch.Checked = true;
            this.optScratch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optScratch.Location = new System.Drawing.Point(12, 124);
            this.optScratch.Name = "optScratch";
            this.optScratch.Size = new System.Drawing.Size(262, 28);
            this.optScratch.TabIndex = 2;
            this.optScratch.TabStop = true;
            this.optScratch.Text = "Create budget from scratch.";
            this.optScratch.UseVisualStyleBackColor = true;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Location = new System.Drawing.Point(178, 276);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(111, 40);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(366, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Begin by specifying the year for the new budget.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(396, 34);
            this.label3.TabIndex = 5;
            this.label3.Text = "This option lets you manually enter amounts for each account\r\nthat you want to tr" +
                "ack.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(413, 34);
            this.label4.TabIndex = 6;
            this.label4.Text = "This option automatically enters the monthly totals from last year\r\nfor each acco" +
                "unt in this budget.";
            // 
            // optPrevData
            // 
            this.optPrevData.AutoSize = true;
            this.optPrevData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optPrevData.Location = new System.Drawing.Point(12, 201);
            this.optPrevData.Name = "optPrevData";
            this.optPrevData.Size = new System.Drawing.Size(422, 28);
            this.optPrevData.TabIndex = 7;
            this.optPrevData.Text = "Create budget from previous year\'s actual data.";
            this.optPrevData.UseVisualStyleBackColor = true;
            // 
            // cmdFinish
            // 
            this.cmdFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFinish.Location = new System.Drawing.Point(322, 276);
            this.cmdFinish.Name = "cmdFinish";
            this.cmdFinish.Size = new System.Drawing.Size(111, 40);
            this.cmdFinish.TabIndex = 8;
            this.cmdFinish.Text = "Finish";
            this.cmdFinish.UseVisualStyleBackColor = true;
            this.cmdFinish.Click += new System.EventHandler(this.cmdFinish_Click);
            // 
            // frmNewBudget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 325);
            this.Controls.Add(this.cmdFinish);
            this.Controls.Add(this.optPrevData);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.optScratch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.udYear);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmNewBudget";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Budget";
            ((System.ComponentModel.ISupportInitialize)(this.udYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown udYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton optScratch;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton optPrevData;
        private System.Windows.Forms.Button cmdFinish;
    }
}