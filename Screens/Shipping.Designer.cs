namespace Rz5.Win.Screens
{
    partial class Shipping
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
            this.pTop = new System.Windows.Forms.Panel();
            this.dt2 = new System.Windows.Forms.DateTimePicker();
            this.dt1 = new System.Windows.Forms.DateTimePicker();
            this.optBetween = new System.Windows.Forms.RadioButton();
            this.optAfter = new System.Windows.Forms.RadioButton();
            this.optBefore = new System.Windows.Forms.RadioButton();
            this.optOn = new System.Windows.Forms.RadioButton();
            this.optAllDates = new System.Windows.Forms.RadioButton();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.hReceive = new Rz5.Win.Controls.ShippingScreenHalf();
            this.hShip = new Rz5.Win.Controls.ShippingScreenHalf();
            this.pTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pTop
            // 
            this.pTop.Controls.Add(this.dt2);
            this.pTop.Controls.Add(this.dt1);
            this.pTop.Controls.Add(this.optBetween);
            this.pTop.Controls.Add(this.optAfter);
            this.pTop.Controls.Add(this.optBefore);
            this.pTop.Controls.Add(this.optOn);
            this.pTop.Controls.Add(this.optAllDates);
            this.pTop.Controls.Add(this.cmdRefresh);
            this.pTop.Location = new System.Drawing.Point(313, 25);
            this.pTop.Name = "pTop";
            this.pTop.Size = new System.Drawing.Size(321, 120);
            this.pTop.TabIndex = 2;
            // 
            // dt2
            // 
            this.dt2.CustomFormat = "M/d/yyyy";
            this.dt2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt2.Location = new System.Drawing.Point(203, 77);
            this.dt2.Name = "dt2";
            this.dt2.Size = new System.Drawing.Size(111, 27);
            this.dt2.TabIndex = 5;
            this.dt2.Visible = false;
            // 
            // dt1
            // 
            this.dt1.CustomFormat = "M/d/yyyy";
            this.dt1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt1.Location = new System.Drawing.Point(203, 44);
            this.dt1.Name = "dt1";
            this.dt1.Size = new System.Drawing.Size(111, 27);
            this.dt1.TabIndex = 3;
            this.dt1.Visible = false;
            // 
            // optBetween
            // 
            this.optBetween.AutoSize = true;
            this.optBetween.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optBetween.Location = new System.Drawing.Point(103, 96);
            this.optBetween.Name = "optBetween";
            this.optBetween.Size = new System.Drawing.Size(114, 23);
            this.optBetween.TabIndex = 10;
            this.optBetween.Text = "Due Between";
            this.optBetween.UseVisualStyleBackColor = true;
            this.optBetween.CheckedChanged += new System.EventHandler(this.optAllDates_CheckedChanged);
            // 
            // optAfter
            // 
            this.optAfter.AutoSize = true;
            this.optAfter.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optAfter.Location = new System.Drawing.Point(103, 77);
            this.optAfter.Name = "optAfter";
            this.optAfter.Size = new System.Drawing.Size(89, 23);
            this.optAfter.TabIndex = 9;
            this.optAfter.Text = "Due After";
            this.optAfter.UseVisualStyleBackColor = true;
            this.optAfter.CheckedChanged += new System.EventHandler(this.optAllDates_CheckedChanged);
            // 
            // optBefore
            // 
            this.optBefore.AutoSize = true;
            this.optBefore.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optBefore.Location = new System.Drawing.Point(103, 58);
            this.optBefore.Name = "optBefore";
            this.optBefore.Size = new System.Drawing.Size(100, 23);
            this.optBefore.TabIndex = 8;
            this.optBefore.Text = "Due Before";
            this.optBefore.UseVisualStyleBackColor = true;
            this.optBefore.CheckedChanged += new System.EventHandler(this.optAllDates_CheckedChanged);
            // 
            // optOn
            // 
            this.optOn.AutoSize = true;
            this.optOn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optOn.Location = new System.Drawing.Point(103, 40);
            this.optOn.Name = "optOn";
            this.optOn.Size = new System.Drawing.Size(76, 23);
            this.optOn.TabIndex = 7;
            this.optOn.Text = "Due On";
            this.optOn.UseVisualStyleBackColor = true;
            this.optOn.CheckedChanged += new System.EventHandler(this.optAllDates_CheckedChanged);
            // 
            // optAllDates
            // 
            this.optAllDates.AutoSize = true;
            this.optAllDates.Checked = true;
            this.optAllDates.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optAllDates.Location = new System.Drawing.Point(11, 40);
            this.optAllDates.Name = "optAllDates";
            this.optAllDates.Size = new System.Drawing.Size(86, 23);
            this.optAllDates.TabIndex = 6;
            this.optAllDates.TabStop = true;
            this.optAllDates.Text = "All Dates";
            this.optAllDates.UseVisualStyleBackColor = true;
            this.optAllDates.CheckedChanged += new System.EventHandler(this.optAllDates_CheckedChanged);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRefresh.Location = new System.Drawing.Point(6, 3);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(312, 37);
            this.cmdRefresh.TabIndex = 0;
            this.cmdRefresh.Text = "Refresh";
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // hReceive
            // 
            this.hReceive.BackColor = System.Drawing.Color.White;
            this.hReceive.Location = new System.Drawing.Point(52, 50);
            this.hReceive.Name = "hReceive";
            this.hReceive.Size = new System.Drawing.Size(378, 386);
            this.hReceive.TabIndex = 1;
            // 
            // hShip
            // 
            this.hShip.BackColor = System.Drawing.Color.White;
            this.hShip.Location = new System.Drawing.Point(436, 50);
            this.hShip.Name = "hShip";
            this.hShip.Size = new System.Drawing.Size(378, 386);
            this.hShip.TabIndex = 0;
            // 
            // Shipping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pTop);
            this.Controls.Add(this.hReceive);
            this.Controls.Add(this.hShip);
            this.Name = "Shipping";
            this.Size = new System.Drawing.Size(966, 516);
            this.Resize += new System.EventHandler(this.ShippingScreen_Resize);
            this.pTop.ResumeLayout(false);
            this.pTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ShippingScreenHalf hShip;
        private Controls.ShippingScreenHalf hReceive;
        protected System.Windows.Forms.RadioButton optBetween;
        protected System.Windows.Forms.RadioButton optAfter;
        protected System.Windows.Forms.RadioButton optBefore;
        protected System.Windows.Forms.RadioButton optOn;
        protected System.Windows.Forms.RadioButton optAllDates;
        protected System.Windows.Forms.DateTimePicker dt2;
        protected System.Windows.Forms.DateTimePicker dt1;
        protected System.Windows.Forms.Panel pTop;
        protected System.Windows.Forms.Button cmdRefresh;
    }
}
