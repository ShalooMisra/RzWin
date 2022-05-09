namespace RzSensible
{
    partial class ArAp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArAp));
            this.chkUseDate = new System.Windows.Forms.CheckBox();
            this.pDateRange = new System.Windows.Forms.Panel();
            this.cmdPast12 = new System.Windows.Forms.Button();
            this.cmdPast3 = new System.Windows.Forms.Button();
            this.dtEnd = new NewMethod.nEdit_Date();
            this.dtStart = new NewMethod.nEdit_Date();
            this.cmdAllInvoices = new System.Windows.Forms.Button();
            this.cmdAllPurchases = new System.Windows.Forms.Button();
            this.gb.SuspendLayout();
            this.gbTotals.SuspendLayout();
            this.pOrderOptions.SuspendLayout();
            this.pDateRange.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb
            // 
            this.gb.Controls.Add(this.cmdAllPurchases);
            this.gb.Controls.Add(this.cmdAllInvoices);
            this.gb.Controls.Add(this.pDateRange);
            this.gb.Controls.Add(this.chkUseDate);
            this.gb.Location = new System.Drawing.Point(2, 2);
            this.gb.Size = new System.Drawing.Size(1166, 70);
            this.gb.Controls.SetChildIndex(this.cmdRefresh, 0);
            this.gb.Controls.SetChildIndex(this.throb, 0);
            this.gb.Controls.SetChildIndex(this.optReceivable, 0);
            this.gb.Controls.SetChildIndex(this.optPayable, 0);
            this.gb.Controls.SetChildIndex(this.optBoth, 0);
            this.gb.Controls.SetChildIndex(this.compStub, 0);
            this.gb.Controls.SetChildIndex(this.pOrderOptions, 0);
            this.gb.Controls.SetChildIndex(this.chkUseDate, 0);
            this.gb.Controls.SetChildIndex(this.pDateRange, 0);
            this.gb.Controls.SetChildIndex(this.cmdAllInvoices, 0);
            this.gb.Controls.SetChildIndex(this.cmdAllPurchases, 0);
            // 
            // lv
            // 
            this.lv.Location = new System.Drawing.Point(2, 74);
            this.lv.Size = new System.Drawing.Size(409, 327);
            // 
            // gbTotals
            // 
            this.gbTotals.Location = new System.Drawing.Point(2, 437);
            this.gbTotals.Size = new System.Drawing.Size(1166, 111);
            // 
            // lvOrders
            // 
            this.lvOrders.Location = new System.Drawing.Point(413, 74);
            this.lvOrders.Size = new System.Drawing.Size(755, 327);
            // 
            // cmdExport
            // 
            this.cmdExport.Location = new System.Drawing.Point(2, 403);
            this.cmdExport.Size = new System.Drawing.Size(409, 32);
            // 
            // IMList
            // 
            this.IMList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IMList.ImageStream")));
            this.IMList.Images.SetKeyName(0, "excel");
            // 
            // cmdExport2
            // 
            this.cmdExport2.Location = new System.Drawing.Point(413, 403);
            this.cmdExport2.Size = new System.Drawing.Size(755, 32);
            // 
            // compStub
            // 
            this.compStub.Size = new System.Drawing.Size(248, 51);
            // 
            // chkUseDate
            // 
            this.chkUseDate.AutoSize = true;
            this.chkUseDate.Location = new System.Drawing.Point(656, 7);
            this.chkUseDate.Name = "chkUseDate";
            this.chkUseDate.Size = new System.Drawing.Size(106, 17);
            this.chkUseDate.TabIndex = 7;
            this.chkUseDate.Text = "Use Date Range";
            this.chkUseDate.UseVisualStyleBackColor = true;
            this.chkUseDate.CheckedChanged += new System.EventHandler(this.chkUseDate_CheckedChanged);
            // 
            // pDateRange
            // 
            this.pDateRange.BackColor = System.Drawing.Color.Gainsboro;
            this.pDateRange.Controls.Add(this.cmdPast12);
            this.pDateRange.Controls.Add(this.cmdPast3);
            this.pDateRange.Controls.Add(this.dtEnd);
            this.pDateRange.Controls.Add(this.dtStart);
            this.pDateRange.Enabled = false;
            this.pDateRange.Location = new System.Drawing.Point(656, 22);
            this.pDateRange.Name = "pDateRange";
            this.pDateRange.Size = new System.Drawing.Size(348, 45);
            this.pDateRange.TabIndex = 8;
            // 
            // cmdPast12
            // 
            this.cmdPast12.Location = new System.Drawing.Point(223, 22);
            this.cmdPast12.Name = "cmdPast12";
            this.cmdPast12.Size = new System.Drawing.Size(120, 19);
            this.cmdPast12.TabIndex = 3;
            this.cmdPast12.Text = "Past Twelve Months";
            this.cmdPast12.UseVisualStyleBackColor = true;
            this.cmdPast12.Click += new System.EventHandler(this.cmdPast12_Click);
            // 
            // cmdPast3
            // 
            this.cmdPast3.Location = new System.Drawing.Point(223, 2);
            this.cmdPast3.Name = "cmdPast3";
            this.cmdPast3.Size = new System.Drawing.Size(120, 19);
            this.cmdPast3.TabIndex = 2;
            this.cmdPast3.Text = "Past Three Months";
            this.cmdPast3.UseVisualStyleBackColor = true;
            this.cmdPast3.Click += new System.EventHandler(this.cmdPast3_Click);
            // 
            // dtEnd
            // 
            this.dtEnd.AllowClear = false;
            this.dtEnd.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.dtEnd.Bold = false;
            this.dtEnd.Caption = "End";
            this.dtEnd.Changed = false;
            this.dtEnd.Location = new System.Drawing.Point(112, 2);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(105, 41);
            this.dtEnd.SuppressEdit = false;
            this.dtEnd.TabIndex = 1;
            this.dtEnd.UseParentBackColor = false;
            this.dtEnd.zz_GlobalColor = System.Drawing.Color.Black;
            this.dtEnd.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dtEnd.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.dtEnd.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEnd.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopCenter;
            this.dtEnd.zz_OriginalDesign = false;
            this.dtEnd.zz_ShowNeedsSaveColor = true;
            this.dtEnd.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.dtEnd.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEnd.zz_UseGlobalColor = false;
            this.dtEnd.zz_UseGlobalFont = false;
            // 
            // dtStart
            // 
            this.dtStart.AllowClear = false;
            this.dtStart.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.dtStart.Bold = false;
            this.dtStart.Caption = "Start";
            this.dtStart.Changed = false;
            this.dtStart.Location = new System.Drawing.Point(3, 2);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(105, 41);
            this.dtStart.SuppressEdit = false;
            this.dtStart.TabIndex = 0;
            this.dtStart.UseParentBackColor = false;
            this.dtStart.zz_GlobalColor = System.Drawing.Color.Black;
            this.dtStart.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dtStart.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.dtStart.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStart.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopCenter;
            this.dtStart.zz_OriginalDesign = false;
            this.dtStart.zz_ShowNeedsSaveColor = true;
            this.dtStart.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.dtStart.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStart.zz_UseGlobalColor = false;
            this.dtStart.zz_UseGlobalFont = false;
            // 
            // cmdAllInvoices
            // 
            this.cmdAllInvoices.Location = new System.Drawing.Point(1010, 14);
            this.cmdAllInvoices.Name = "cmdAllInvoices";
            this.cmdAllInvoices.Size = new System.Drawing.Size(120, 26);
            this.cmdAllInvoices.TabIndex = 9;
            this.cmdAllInvoices.Text = "All Invoices";
            this.cmdAllInvoices.UseVisualStyleBackColor = true;
            this.cmdAllInvoices.Click += new System.EventHandler(this.cmdAllInvoices_Click);
            // 
            // cmdAllPurchases
            // 
            this.cmdAllPurchases.Location = new System.Drawing.Point(1010, 42);
            this.cmdAllPurchases.Name = "cmdAllPurchases";
            this.cmdAllPurchases.Size = new System.Drawing.Size(120, 26);
            this.cmdAllPurchases.TabIndex = 10;
            this.cmdAllPurchases.Text = "All Purchases";
            this.cmdAllPurchases.UseVisualStyleBackColor = true;
            this.cmdAllPurchases.Click += new System.EventHandler(this.cmdAllPurchases_Click);
            // 
            // ArAp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ArAp";
            this.Size = new System.Drawing.Size(1170, 550);
            this.Controls.SetChildIndex(this.gb, 0);
            this.Controls.SetChildIndex(this.lv, 0);
            this.Controls.SetChildIndex(this.gbTotals, 0);
            this.Controls.SetChildIndex(this.lvOrders, 0);
            this.Controls.SetChildIndex(this.cmdExport, 0);
            this.Controls.SetChildIndex(this.cmdExport2, 0);
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.gbTotals.ResumeLayout(false);
            this.gbTotals.PerformLayout();
            this.pOrderOptions.ResumeLayout(false);
            this.pOrderOptions.PerformLayout();
            this.pDateRange.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdAllPurchases;
        private System.Windows.Forms.Button cmdAllInvoices;
        private System.Windows.Forms.Panel pDateRange;
        private System.Windows.Forms.Button cmdPast12;
        private System.Windows.Forms.Button cmdPast3;
        private NewMethod.nEdit_Date dtEnd;
        private NewMethod.nEdit_Date dtStart;
        private System.Windows.Forms.CheckBox chkUseDate;
    }
}
