namespace RzInterfaceWin
{
    partial class ReconcileAccountCC
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
            this.pbLeft = new System.Windows.Forms.PictureBox();
            this.pbRight = new System.Windows.Forms.PictureBox();
            this.pbBottom = new System.Windows.Forms.PictureBox();
            this.pbTop = new System.Windows.Forms.PictureBox();
            this.lblCheckPay = new System.Windows.Forms.Label();
            this.lvPayments = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblPeriod = new System.Windows.Forms.Label();
            this.lvDeposits = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblDepCredit = new System.Windows.Forms.Label();
            this.cmdUnMarkAll = new System.Windows.Forms.Button();
            this.cmdMarkAll = new System.Windows.Forms.Button();
            this.pControls = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPayAmount = new System.Windows.Forms.Label();
            this.lblDepCount = new System.Windows.Forms.Label();
            this.lblDepAmount = new System.Windows.Forms.Label();
            this.lblPayCount = new System.Windows.Forms.Label();
            this.lblBeginBalance = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pResults = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.lblDifference = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.cmdReconcile = new System.Windows.Forms.Button();
            this.lblClearedBalance = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblEndBalance = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblFinanceAmount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).BeginInit();
            this.pControls.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbLeft
            // 
            this.pbLeft.BackColor = System.Drawing.Color.Black;
            this.pbLeft.Location = new System.Drawing.Point(384, 26);
            this.pbLeft.Margin = new System.Windows.Forms.Padding(4);
            this.pbLeft.Name = "pbLeft";
            this.pbLeft.Size = new System.Drawing.Size(16, 15);
            this.pbLeft.TabIndex = 44;
            this.pbLeft.TabStop = false;
            // 
            // pbRight
            // 
            this.pbRight.BackColor = System.Drawing.Color.Black;
            this.pbRight.Location = new System.Drawing.Point(384, 4);
            this.pbRight.Margin = new System.Windows.Forms.Padding(4);
            this.pbRight.Name = "pbRight";
            this.pbRight.Size = new System.Drawing.Size(16, 15);
            this.pbRight.TabIndex = 43;
            this.pbRight.TabStop = false;
            // 
            // pbBottom
            // 
            this.pbBottom.BackColor = System.Drawing.Color.Black;
            this.pbBottom.Location = new System.Drawing.Point(408, 4);
            this.pbBottom.Margin = new System.Windows.Forms.Padding(4);
            this.pbBottom.Name = "pbBottom";
            this.pbBottom.Size = new System.Drawing.Size(16, 15);
            this.pbBottom.TabIndex = 42;
            this.pbBottom.TabStop = false;
            // 
            // pbTop
            // 
            this.pbTop.BackColor = System.Drawing.Color.Black;
            this.pbTop.Location = new System.Drawing.Point(408, 26);
            this.pbTop.Margin = new System.Windows.Forms.Padding(4);
            this.pbTop.Name = "pbTop";
            this.pbTop.Size = new System.Drawing.Size(16, 15);
            this.pbTop.TabIndex = 41;
            this.pbTop.TabStop = false;
            // 
            // lblCheckPay
            // 
            this.lblCheckPay.AutoSize = true;
            this.lblCheckPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckPay.Location = new System.Drawing.Point(10, 30);
            this.lblCheckPay.Name = "lblCheckPay";
            this.lblCheckPay.Size = new System.Drawing.Size(68, 17);
            this.lblCheckPay.TabIndex = 45;
            this.lblCheckPay.Text = "Charges";
            // 
            // lvPayments
            // 
            this.lvPayments.CheckBoxes = true;
            this.lvPayments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvPayments.FullRowSelect = true;
            this.lvPayments.GridLines = true;
            this.lvPayments.Location = new System.Drawing.Point(10, 50);
            this.lvPayments.MultiSelect = false;
            this.lvPayments.Name = "lvPayments";
            this.lvPayments.Size = new System.Drawing.Size(590, 97);
            this.lvPayments.TabIndex = 46;
            this.lvPayments.UseCompatibleStateImageBehavior = false;
            this.lvPayments.View = System.Windows.Forms.View.Details;
            this.lvPayments.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvPayments_ItemChecked);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Date";
            this.columnHeader1.Width = 94;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Check/Ref. #";
            this.columnHeader2.Width = 96;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Payee";
            this.columnHeader3.Width = 235;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Amount";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader4.Width = 136;
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Location = new System.Drawing.Point(10, 11);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(167, 17);
            this.lblPeriod.TabIndex = 47;
            this.lblPeriod.Text = "For period: MM/DD/YYYY";
            // 
            // lvDeposits
            // 
            this.lvDeposits.CheckBoxes = true;
            this.lvDeposits.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lvDeposits.FullRowSelect = true;
            this.lvDeposits.GridLines = true;
            this.lvDeposits.Location = new System.Drawing.Point(608, 50);
            this.lvDeposits.MultiSelect = false;
            this.lvDeposits.Name = "lvDeposits";
            this.lvDeposits.Size = new System.Drawing.Size(590, 97);
            this.lvDeposits.TabIndex = 49;
            this.lvDeposits.UseCompatibleStateImageBehavior = false;
            this.lvDeposits.View = System.Windows.Forms.View.Details;
            this.lvDeposits.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvDeposits_ItemChecked);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Date";
            this.columnHeader5.Width = 94;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Check/Ref. #";
            this.columnHeader6.Width = 96;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Memo";
            this.columnHeader7.Width = 235;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Amount";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader8.Width = 136;
            // 
            // lblDepCredit
            // 
            this.lblDepCredit.AutoSize = true;
            this.lblDepCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepCredit.Location = new System.Drawing.Point(605, 30);
            this.lblDepCredit.Name = "lblDepCredit";
            this.lblDepCredit.Size = new System.Drawing.Size(212, 17);
            this.lblDepCredit.TabIndex = 48;
            this.lblDepCredit.Text = "Payments and Other Credits";
            // 
            // cmdUnMarkAll
            // 
            this.cmdUnMarkAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdUnMarkAll.Location = new System.Drawing.Point(3, 3);
            this.cmdUnMarkAll.Name = "cmdUnMarkAll";
            this.cmdUnMarkAll.Size = new System.Drawing.Size(129, 40);
            this.cmdUnMarkAll.TabIndex = 50;
            this.cmdUnMarkAll.Text = "Unmark All";
            this.cmdUnMarkAll.UseVisualStyleBackColor = true;
            this.cmdUnMarkAll.Click += new System.EventHandler(this.cmdUnMarkAll_Click);
            // 
            // cmdMarkAll
            // 
            this.cmdMarkAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMarkAll.Location = new System.Drawing.Point(138, 3);
            this.cmdMarkAll.Name = "cmdMarkAll";
            this.cmdMarkAll.Size = new System.Drawing.Size(129, 40);
            this.cmdMarkAll.TabIndex = 51;
            this.cmdMarkAll.Text = "Mark All";
            this.cmdMarkAll.UseVisualStyleBackColor = true;
            this.cmdMarkAll.Click += new System.EventHandler(this.cmdMarkAll_Click);
            // 
            // pControls
            // 
            this.pControls.Controls.Add(this.panel2);
            this.pControls.Controls.Add(this.pResults);
            this.pControls.Controls.Add(this.cmdUnMarkAll);
            this.pControls.Controls.Add(this.cmdMarkAll);
            this.pControls.Location = new System.Drawing.Point(12, 152);
            this.pControls.Name = "pControls";
            this.pControls.Size = new System.Drawing.Size(1186, 157);
            this.pControls.TabIndex = 52;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.lblPayAmount);
            this.panel2.Controls.Add(this.lblDepCount);
            this.panel2.Controls.Add(this.lblDepAmount);
            this.panel2.Controls.Add(this.lblPayCount);
            this.panel2.Controls.Add(this.lblBeginBalance);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Location = new System.Drawing.Point(3, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(503, 103);
            this.panel2.TabIndex = 64;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 17);
            this.label4.TabIndex = 54;
            this.label4.Text = "Beginning Balance";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(224, 17);
            this.label5.TabIndex = 55;
            this.label5.Text = "Items you have marked as cleared";
            // 
            // lblPayAmount
            // 
            this.lblPayAmount.Location = new System.Drawing.Point(256, 70);
            this.lblPayAmount.Name = "lblPayAmount";
            this.lblPayAmount.Size = new System.Drawing.Size(238, 17);
            this.lblPayAmount.TabIndex = 62;
            this.lblPayAmount.Text = "0.00";
            this.lblPayAmount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDepCount
            // 
            this.lblDepCount.Location = new System.Drawing.Point(13, 53);
            this.lblDepCount.Name = "lblDepCount";
            this.lblDepCount.Size = new System.Drawing.Size(40, 17);
            this.lblDepCount.TabIndex = 56;
            this.lblDepCount.Text = "0";
            this.lblDepCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDepAmount
            // 
            this.lblDepAmount.Location = new System.Drawing.Point(256, 53);
            this.lblDepAmount.Name = "lblDepAmount";
            this.lblDepAmount.Size = new System.Drawing.Size(238, 17);
            this.lblDepAmount.TabIndex = 61;
            this.lblDepAmount.Text = "0.00";
            this.lblDepAmount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblPayCount
            // 
            this.lblPayCount.Location = new System.Drawing.Point(13, 70);
            this.lblPayCount.Name = "lblPayCount";
            this.lblPayCount.Size = new System.Drawing.Size(40, 17);
            this.lblPayCount.TabIndex = 57;
            this.lblPayCount.Text = "0";
            this.lblPayCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblBeginBalance
            // 
            this.lblBeginBalance.Location = new System.Drawing.Point(256, 10);
            this.lblBeginBalance.Name = "lblBeginBalance";
            this.lblBeginBalance.Size = new System.Drawing.Size(238, 17);
            this.lblBeginBalance.TabIndex = 60;
            this.lblBeginBalance.Text = "0.00";
            this.lblBeginBalance.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(58, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(179, 17);
            this.label8.TabIndex = 58;
            this.label8.Text = "Deposits and Other Credits";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(58, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(148, 17);
            this.label9.TabIndex = 59;
            this.label9.Text = "Checks and Payments";
            // 
            // pResults
            // 
            this.pResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pResults.Controls.Add(this.label19);
            this.pResults.Controls.Add(this.lblDifference);
            this.pResults.Controls.Add(this.cmdCancel);
            this.pResults.Controls.Add(this.label17);
            this.pResults.Controls.Add(this.cmdReconcile);
            this.pResults.Controls.Add(this.lblClearedBalance);
            this.pResults.Controls.Add(this.label15);
            this.pResults.Controls.Add(this.lblEndBalance);
            this.pResults.Controls.Add(this.label11);
            this.pResults.Controls.Add(this.lblFinanceAmount);
            this.pResults.Location = new System.Drawing.Point(716, 31);
            this.pResults.Name = "pResults";
            this.pResults.Size = new System.Drawing.Size(465, 122);
            this.pResults.TabIndex = 63;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 56);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(73, 17);
            this.label19.TabIndex = 69;
            this.label19.Text = "Difference";
            // 
            // lblDifference
            // 
            this.lblDifference.Location = new System.Drawing.Point(213, 56);
            this.lblDifference.Name = "lblDifference";
            this.lblDifference.Size = new System.Drawing.Size(238, 17);
            this.lblDifference.TabIndex = 70;
            this.lblDifference.Text = "0.00";
            this.lblDifference.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Location = new System.Drawing.Point(187, 76);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(129, 40);
            this.cmdCancel.TabIndex = 52;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 39);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(112, 17);
            this.label17.TabIndex = 67;
            this.label17.Text = "Cleared Balance";
            // 
            // cmdReconcile
            // 
            this.cmdReconcile.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdReconcile.Location = new System.Drawing.Point(322, 76);
            this.cmdReconcile.Name = "cmdReconcile";
            this.cmdReconcile.Size = new System.Drawing.Size(129, 40);
            this.cmdReconcile.TabIndex = 53;
            this.cmdReconcile.Text = "Reconcile";
            this.cmdReconcile.UseVisualStyleBackColor = true;
            this.cmdReconcile.Click += new System.EventHandler(this.cmdReconcile_Click);
            // 
            // lblClearedBalance
            // 
            this.lblClearedBalance.Location = new System.Drawing.Point(213, 39);
            this.lblClearedBalance.Name = "lblClearedBalance";
            this.lblClearedBalance.Size = new System.Drawing.Size(238, 17);
            this.lblClearedBalance.TabIndex = 68;
            this.lblClearedBalance.Text = "0.00";
            this.lblClearedBalance.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(107, 17);
            this.label15.TabIndex = 65;
            this.label15.Text = "Ending Balance";
            // 
            // lblEndBalance
            // 
            this.lblEndBalance.Location = new System.Drawing.Point(213, 22);
            this.lblEndBalance.Name = "lblEndBalance";
            this.lblEndBalance.Size = new System.Drawing.Size(238, 17);
            this.lblEndBalance.TabIndex = 66;
            this.lblEndBalance.Text = "0.00";
            this.lblEndBalance.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 17);
            this.label11.TabIndex = 61;
            this.label11.Text = "Finance Charge";
            // 
            // lblFinanceAmount
            // 
            this.lblFinanceAmount.Location = new System.Drawing.Point(213, 4);
            this.lblFinanceAmount.Name = "lblFinanceAmount";
            this.lblFinanceAmount.Size = new System.Drawing.Size(238, 17);
            this.lblFinanceAmount.TabIndex = 62;
            this.lblFinanceAmount.Text = "0.00";
            this.lblFinanceAmount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ReconcileAccountCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pControls);
            this.Controls.Add(this.lvDeposits);
            this.Controls.Add(this.lblDepCredit);
            this.Controls.Add(this.lblPeriod);
            this.Controls.Add(this.lvPayments);
            this.Controls.Add(this.lblCheckPay);
            this.Controls.Add(this.pbLeft);
            this.Controls.Add(this.pbRight);
            this.Controls.Add(this.pbBottom);
            this.Controls.Add(this.pbTop);
            this.Name = "ReconcileAccountCC";
            this.Size = new System.Drawing.Size(1213, 316);
            this.Resize += new System.EventHandler(this.ReconcileAccount_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).EndInit();
            this.pControls.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pResults.ResumeLayout(false);
            this.pResults.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLeft;
        private System.Windows.Forms.PictureBox pbRight;
        private System.Windows.Forms.PictureBox pbBottom;
        private System.Windows.Forms.PictureBox pbTop;
        private System.Windows.Forms.Label lblCheckPay;
        private System.Windows.Forms.ListView lvPayments;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.ListView lvDeposits;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Label lblDepCredit;
        private System.Windows.Forms.Button cmdUnMarkAll;
        private System.Windows.Forms.Button cmdMarkAll;
        private System.Windows.Forms.Panel pControls;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPayAmount;
        private System.Windows.Forms.Label lblDepCount;
        private System.Windows.Forms.Label lblDepAmount;
        private System.Windows.Forms.Label lblPayCount;
        private System.Windows.Forms.Label lblBeginBalance;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel pResults;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblDifference;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button cmdReconcile;
        private System.Windows.Forms.Label lblClearedBalance;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblEndBalance;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblFinanceAmount;
    }
}
