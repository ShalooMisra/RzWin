namespace Rz5
{
    partial class StockEvaluator
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
            this.gbOptions = new System.Windows.Forms.GroupBox();
            this.chkOnlyTotals = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAllocated = new System.Windows.Forms.CheckBox();
            this.chkExcess = new System.Windows.Forms.CheckBox();
            this.chkConsign = new System.Windows.Forms.CheckBox();
            this.chkStock = new System.Windows.Forms.CheckBox();
            this.chkInventory = new System.Windows.Forms.CheckBox();
            this.chkPurchases = new System.Windows.Forms.CheckBox();
            this.chkSales = new System.Windows.Forms.CheckBox();
            this.chkBids = new System.Windows.Forms.CheckBox();
            this.chkReqs = new System.Windows.Forms.CheckBox();
            this.chkExcel = new System.Windows.Forms.CheckBox();
            this.cmdGo = new System.Windows.Forms.Button();
            this.txtLists = new System.Windows.Forms.TextBox();
            this.lblLists = new System.Windows.Forms.Label();
            this.rt = new System.Windows.Forms.RichTextBox();
            this.gb.SuspendLayout();
            this.gbOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // wb
            // 
            this.wb.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.wb.Size = new System.Drawing.Size(1295, 823);
            // 
            // gb
            // 
            this.gb.Location = new System.Drawing.Point(0, 823);
            this.gb.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.gb.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.gb.Size = new System.Drawing.Size(1295, 65);
            // 
            // gbOptions
            // 
            this.gbOptions.Controls.Add(this.chkOnlyTotals);
            this.gbOptions.Controls.Add(this.label1);
            this.gbOptions.Controls.Add(this.chkAllocated);
            this.gbOptions.Controls.Add(this.chkExcess);
            this.gbOptions.Controls.Add(this.chkConsign);
            this.gbOptions.Controls.Add(this.chkStock);
            this.gbOptions.Controls.Add(this.chkInventory);
            this.gbOptions.Controls.Add(this.chkPurchases);
            this.gbOptions.Controls.Add(this.chkSales);
            this.gbOptions.Controls.Add(this.chkBids);
            this.gbOptions.Controls.Add(this.chkReqs);
            this.gbOptions.Controls.Add(this.chkExcel);
            this.gbOptions.Controls.Add(this.cmdGo);
            this.gbOptions.Controls.Add(this.txtLists);
            this.gbOptions.Controls.Add(this.lblLists);
            this.gbOptions.Controls.Add(this.rt);
            this.gbOptions.Location = new System.Drawing.Point(31, 58);
            this.gbOptions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbOptions.Size = new System.Drawing.Size(219, 540);
            this.gbOptions.TabIndex = 3;
            this.gbOptions.TabStop = false;
            this.gbOptions.Text = "Options";
            // 
            // chkOnlyTotals
            // 
            this.chkOnlyTotals.AutoSize = true;
            this.chkOnlyTotals.Location = new System.Drawing.Point(11, 103);
            this.chkOnlyTotals.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkOnlyTotals.Name = "chkOnlyTotals";
            this.chkOnlyTotals.Size = new System.Drawing.Size(102, 21);
            this.chkOnlyTotals.TabIndex = 15;
            this.chkOnlyTotals.Text = "Only Totals";
            this.chkOnlyTotals.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 123);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "Matching:";
            // 
            // chkAllocated
            // 
            this.chkAllocated.AutoSize = true;
            this.chkAllocated.Checked = true;
            this.chkAllocated.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllocated.Location = new System.Drawing.Point(29, 325);
            this.chkAllocated.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkAllocated.Name = "chkAllocated";
            this.chkAllocated.Size = new System.Drawing.Size(88, 21);
            this.chkAllocated.TabIndex = 12;
            this.chkAllocated.Text = "Allocated";
            this.chkAllocated.UseVisualStyleBackColor = true;
            // 
            // chkExcess
            // 
            this.chkExcess.AutoSize = true;
            this.chkExcess.Checked = true;
            this.chkExcess.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExcess.Location = new System.Drawing.Point(29, 303);
            this.chkExcess.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkExcess.Name = "chkExcess";
            this.chkExcess.Size = new System.Drawing.Size(74, 21);
            this.chkExcess.TabIndex = 11;
            this.chkExcess.Text = "Excess";
            this.chkExcess.UseVisualStyleBackColor = true;
            // 
            // chkConsign
            // 
            this.chkConsign.AutoSize = true;
            this.chkConsign.Checked = true;
            this.chkConsign.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConsign.Location = new System.Drawing.Point(29, 281);
            this.chkConsign.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkConsign.Name = "chkConsign";
            this.chkConsign.Size = new System.Drawing.Size(81, 21);
            this.chkConsign.TabIndex = 10;
            this.chkConsign.Text = "Consign";
            this.chkConsign.UseVisualStyleBackColor = true;
            // 
            // chkStock
            // 
            this.chkStock.AutoSize = true;
            this.chkStock.Checked = true;
            this.chkStock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStock.Location = new System.Drawing.Point(28, 258);
            this.chkStock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkStock.Name = "chkStock";
            this.chkStock.Size = new System.Drawing.Size(65, 21);
            this.chkStock.TabIndex = 9;
            this.chkStock.Text = "Stock";
            this.chkStock.UseVisualStyleBackColor = true;
            // 
            // chkInventory
            // 
            this.chkInventory.AutoSize = true;
            this.chkInventory.Checked = true;
            this.chkInventory.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInventory.Location = new System.Drawing.Point(11, 236);
            this.chkInventory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkInventory.Name = "chkInventory";
            this.chkInventory.Size = new System.Drawing.Size(88, 21);
            this.chkInventory.TabIndex = 8;
            this.chkInventory.Text = "Inventory";
            this.chkInventory.UseVisualStyleBackColor = true;
            // 
            // chkPurchases
            // 
            this.chkPurchases.AutoSize = true;
            this.chkPurchases.Checked = true;
            this.chkPurchases.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPurchases.Location = new System.Drawing.Point(11, 214);
            this.chkPurchases.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkPurchases.Name = "chkPurchases";
            this.chkPurchases.Size = new System.Drawing.Size(97, 21);
            this.chkPurchases.TabIndex = 7;
            this.chkPurchases.Text = "Purchases";
            this.chkPurchases.UseVisualStyleBackColor = true;
            // 
            // chkSales
            // 
            this.chkSales.AutoSize = true;
            this.chkSales.Checked = true;
            this.chkSales.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSales.Location = new System.Drawing.Point(11, 193);
            this.chkSales.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkSales.Name = "chkSales";
            this.chkSales.Size = new System.Drawing.Size(65, 21);
            this.chkSales.TabIndex = 6;
            this.chkSales.Text = "Sales";
            this.chkSales.UseVisualStyleBackColor = true;
            // 
            // chkBids
            // 
            this.chkBids.AutoSize = true;
            this.chkBids.Checked = true;
            this.chkBids.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBids.Location = new System.Drawing.Point(11, 171);
            this.chkBids.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkBids.Name = "chkBids";
            this.chkBids.Size = new System.Drawing.Size(57, 21);
            this.chkBids.TabIndex = 5;
            this.chkBids.Text = "Bids";
            this.chkBids.UseVisualStyleBackColor = true;
            // 
            // chkReqs
            // 
            this.chkReqs.AutoSize = true;
            this.chkReqs.Checked = true;
            this.chkReqs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReqs.Location = new System.Drawing.Point(11, 150);
            this.chkReqs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkReqs.Name = "chkReqs";
            this.chkReqs.Size = new System.Drawing.Size(63, 21);
            this.chkReqs.TabIndex = 4;
            this.chkReqs.Text = "Reqs";
            this.chkReqs.UseVisualStyleBackColor = true;
            // 
            // chkExcel
            // 
            this.chkExcel.AutoSize = true;
            this.chkExcel.Location = new System.Drawing.Point(11, 80);
            this.chkExcel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkExcel.Name = "chkExcel";
            this.chkExcel.Size = new System.Drawing.Size(63, 21);
            this.chkExcel.TabIndex = 3;
            this.chkExcel.Text = "Excel";
            this.chkExcel.UseVisualStyleBackColor = true;
            // 
            // cmdGo
            // 
            this.cmdGo.Location = new System.Drawing.Point(7, 20);
            this.cmdGo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdGo.Name = "cmdGo";
            this.cmdGo.Size = new System.Drawing.Size(205, 53);
            this.cmdGo.TabIndex = 2;
            this.cmdGo.Text = "Go >";
            this.cmdGo.UseVisualStyleBackColor = true;
            this.cmdGo.Click += new System.EventHandler(this.cmdGo_Click);
            // 
            // txtLists
            // 
            this.txtLists.Location = new System.Drawing.Point(7, 373);
            this.txtLists.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLists.Multiline = true;
            this.txtLists.Name = "txtLists";
            this.txtLists.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLists.Size = new System.Drawing.Size(203, 84);
            this.txtLists.TabIndex = 1;
            this.txtLists.WordWrap = false;
            // 
            // lblLists
            // 
            this.lblLists.AutoSize = true;
            this.lblLists.Location = new System.Drawing.Point(8, 354);
            this.lblLists.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLists.Name = "lblLists";
            this.lblLists.Size = new System.Drawing.Size(37, 17);
            this.lblLists.TabIndex = 0;
            this.lblLists.Text = "Lists";
            // 
            // rt
            // 
            this.rt.Location = new System.Drawing.Point(7, 373);
            this.rt.Name = "rt";
            this.rt.Size = new System.Drawing.Size(203, 121);
            this.rt.TabIndex = 16;
            this.rt.Text = "";
            this.rt.Visible = false;
            // 
            // StockEvaluator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbOptions);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "StockEvaluator";
            this.Size = new System.Drawing.Size(971, 722);
            this.Controls.SetChildIndex(this.wb, 0);
            this.Controls.SetChildIndex(this.gb, 0);
            this.Controls.SetChildIndex(this.gbOptions, 0);
            this.gb.ResumeLayout(false);
            this.gbOptions.ResumeLayout(false);
            this.gbOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbOptions;
        private System.Windows.Forms.Button cmdGo;
        private System.Windows.Forms.TextBox txtLists;
        private System.Windows.Forms.Label lblLists;
        private System.Windows.Forms.CheckBox chkExcel;
        private System.Windows.Forms.CheckBox chkReqs;
        private System.Windows.Forms.CheckBox chkPurchases;
        private System.Windows.Forms.CheckBox chkSales;
        private System.Windows.Forms.CheckBox chkBids;
        private System.Windows.Forms.CheckBox chkInventory;
        private System.Windows.Forms.CheckBox chkAllocated;
        private System.Windows.Forms.CheckBox chkExcess;
        private System.Windows.Forms.CheckBox chkConsign;
        private System.Windows.Forms.CheckBox chkStock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkOnlyTotals;
        private System.Windows.Forms.RichTextBox rt;
    }
}
