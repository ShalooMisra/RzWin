namespace Rz5.Win.Dialogs
{
    partial class OrderLineChooser
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
            this.components = new System.ComponentModel.Container();
            this.pHeader = new System.Windows.Forms.Panel();
            this.lblOrderCapExtra = new System.Windows.Forms.Label();
            this.lblOrderCap = new System.Windows.Forms.Label();
            this.lvLines = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mnu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pOptions.SuspendLayout();
            this.pContents.SuspendLayout();
            this.pHeader.SuspendLayout();
            this.mnu.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(142, 0);
            this.cmdOK.Size = new System.Drawing.Size(676, 58);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(0, 0);
            // 
            // pOptions
            // 
            this.pOptions.Location = new System.Drawing.Point(0, 592);
            this.pOptions.Size = new System.Drawing.Size(818, 63);
            // 
            // pContents
            // 
            this.pContents.Controls.Add(this.lvLines);
            this.pContents.Controls.Add(this.pHeader);
            this.pContents.Location = new System.Drawing.Point(0, 0);
            this.pContents.Size = new System.Drawing.Size(818, 592);
            // 
            // pHeader
            // 
            this.pHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pHeader.Controls.Add(this.lblOrderCapExtra);
            this.pHeader.Controls.Add(this.lblOrderCap);
            this.pHeader.Location = new System.Drawing.Point(2, 2);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(816, 102);
            this.pHeader.TabIndex = 0;
            // 
            // lblOrderCapExtra
            // 
            this.lblOrderCapExtra.AutoSize = true;
            this.lblOrderCapExtra.BackColor = System.Drawing.Color.Transparent;
            this.lblOrderCapExtra.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderCapExtra.ForeColor = System.Drawing.Color.Gray;
            this.lblOrderCapExtra.Location = new System.Drawing.Point(14, 35);
            this.lblOrderCapExtra.Name = "lblOrderCapExtra";
            this.lblOrderCapExtra.Size = new System.Drawing.Size(75, 57);
            this.lblOrderCapExtra.TabIndex = 1;
            this.lblOrderCapExtra.Text = "Customer:\r\nAgent:\r\nSupport:";
            // 
            // lblOrderCap
            // 
            this.lblOrderCap.AutoSize = true;
            this.lblOrderCap.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderCap.Location = new System.Drawing.Point(13, 9);
            this.lblOrderCap.Name = "lblOrderCap";
            this.lblOrderCap.Size = new System.Drawing.Size(180, 26);
            this.lblOrderCap.TabIndex = 0;
            this.lblOrderCap.Text = "Sales Order 123456";
            // 
            // lvLines
            // 
            this.lvLines.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lvLines.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvLines.FullRowSelect = true;
            this.lvLines.HideSelection = false;
            this.lvLines.Location = new System.Drawing.Point(2, 105);
            this.lvLines.Name = "lvLines";
            this.lvLines.Size = new System.Drawing.Size(813, 485);
            this.lvLines.TabIndex = 1;
            this.lvLines.UseCompatibleStateImageBehavior = false;
            this.lvLines.View = System.Windows.Forms.View.Details;
            this.lvLines.Click += new System.EventHandler(this.lvLines_Click);
            this.lvLines.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvLines_MouseUp);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Pec";
            this.columnHeader1.Width = 110;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Quantity";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 114;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Type";
            this.columnHeader4.Width = 84;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Lot";
            this.columnHeader5.Width = 88;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Vendor";
            this.columnHeader6.Width = 140;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Going To...";
            this.columnHeader7.Width = 162;
            // 
            // mnu
            // 
            this.mnu.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newOrderToolStripMenuItem});
            this.mnu.Name = "mnu";
            this.mnu.Size = new System.Drawing.Size(149, 28);
            // 
            // newOrderToolStripMenuItem
            // 
            this.newOrderToolStripMenuItem.Name = "newOrderToolStripMenuItem";
            this.newOrderToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.newOrderToolStripMenuItem.Text = "New Order";
            this.newOrderToolStripMenuItem.Click += new System.EventHandler(this.NewOrder_Click);
            // 
            // OrderLineChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 655);
            this.Name = "OrderLineChooser";
            this.Text = "OrderLineChooser";
            this.Controls.SetChildIndex(this.pOptions, 0);
            this.Controls.SetChildIndex(this.pContents, 0);
            this.pOptions.ResumeLayout(false);
            this.pContents.ResumeLayout(false);
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            this.mnu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvLines;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Label lblOrderCapExtra;
        private System.Windows.Forms.Label lblOrderCap;
        private System.Windows.Forms.ContextMenuStrip mnu;
        private System.Windows.Forms.ToolStripMenuItem newOrderToolStripMenuItem;
    }
}