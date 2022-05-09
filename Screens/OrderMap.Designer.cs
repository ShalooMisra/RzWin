using NewMethod;

namespace Rz5
{
    partial class OrderMap
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
            this.pic = new System.Windows.Forms.PictureBox();
            this.pContents = new System.Windows.Forms.Panel();
            this.lvOrders = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pOptions = new System.Windows.Forms.Panel();
            this.chkIncludeVoid = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.pContents.SuspendLayout();
            this.pOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pic
            // 
            this.pic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic.Location = new System.Drawing.Point(0, 0);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(427, 472);
            this.pic.TabIndex = 0;
            this.pic.TabStop = false;
            // 
            // pContents
            // 
            this.pContents.Controls.Add(this.pic);
            this.pContents.Location = new System.Drawing.Point(248, 17);
            this.pContents.Name = "pContents";
            this.pContents.Size = new System.Drawing.Size(427, 472);
            this.pContents.TabIndex = 1;
            // 
            // lvOrders
            // 
            this.lvOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvOrders.FullRowSelect = true;
            this.lvOrders.Location = new System.Drawing.Point(0, 3);
            this.lvOrders.Name = "lvOrders";
            this.lvOrders.Size = new System.Drawing.Size(242, 308);
            this.lvOrders.TabIndex = 2;
            this.lvOrders.UseCompatibleStateImageBehavior = false;
            this.lvOrders.View = System.Windows.Forms.View.Details;
            this.lvOrders.DoubleClick += new System.EventHandler(this.lvOrders_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Number";
            this.columnHeader1.Width = 57;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Type";
            this.columnHeader2.Width = 58;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Date";
            this.columnHeader3.Width = 62;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Company";
            this.columnHeader4.Width = 111;
            // 
            // pOptions
            // 
            this.pOptions.Controls.Add(this.chkIncludeVoid);
            this.pOptions.Location = new System.Drawing.Point(3, 342);
            this.pOptions.Name = "pOptions";
            this.pOptions.Size = new System.Drawing.Size(240, 22);
            this.pOptions.TabIndex = 6;
            // 
            // chkIncludeVoid
            // 
            this.chkIncludeVoid.AutoSize = true;
            this.chkIncludeVoid.Location = new System.Drawing.Point(3, 3);
            this.chkIncludeVoid.Name = "chkIncludeVoid";
            this.chkIncludeVoid.Size = new System.Drawing.Size(119, 17);
            this.chkIncludeVoid.TabIndex = 0;
            this.chkIncludeVoid.Text = "Include Void Orders";
            this.chkIncludeVoid.UseVisualStyleBackColor = true;
            this.chkIncludeVoid.Click += new System.EventHandler(this.chkIncludeVoid_Click);
            // 
            // OrderMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pOptions);
            this.Controls.Add(this.lvOrders);
            this.Controls.Add(this.pContents);
            this.Name = "OrderMap";
            this.Size = new System.Drawing.Size(827, 515);
            this.Resize += new System.EventHandler(this.OrderMap_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.pContents.ResumeLayout(false);
            this.pOptions.ResumeLayout(false);
            this.pOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Panel pContents;
        private System.Windows.Forms.ListView lvOrders;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Panel pOptions;
        private System.Windows.Forms.CheckBox chkIncludeVoid;
    }
}
