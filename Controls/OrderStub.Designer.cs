using NewMethod;

namespace Rz5
{
    partial class OrderStub
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
            this.components = new System.ComponentModel.Container();
            this.pbLeft = new System.Windows.Forms.PictureBox();
            this.pbRight = new System.Windows.Forms.PictureBox();
            this.pbBottom = new System.Windows.Forms.PictureBox();
            this.pbTop = new System.Windows.Forms.PictureBox();
            this.lblOrder = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblAgent = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.mnu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCompanyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblIncomplete = new System.Windows.Forms.Label();
            this.lblVoid = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.mnuAuthorize = new System.Windows.Forms.ToolStripMenuItem();
            this.lblAuthorized = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).BeginInit();
            this.mnu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbLeft
            // 
            this.pbLeft.BackColor = System.Drawing.Color.Black;
            this.pbLeft.Location = new System.Drawing.Point(220, 177);
            this.pbLeft.Name = "pbLeft";
            this.pbLeft.Size = new System.Drawing.Size(12, 12);
            this.pbLeft.TabIndex = 28;
            this.pbLeft.TabStop = false;
            // 
            // pbRight
            // 
            this.pbRight.BackColor = System.Drawing.Color.Black;
            this.pbRight.Location = new System.Drawing.Point(220, 159);
            this.pbRight.Name = "pbRight";
            this.pbRight.Size = new System.Drawing.Size(12, 12);
            this.pbRight.TabIndex = 27;
            this.pbRight.TabStop = false;
            // 
            // pbBottom
            // 
            this.pbBottom.BackColor = System.Drawing.Color.Black;
            this.pbBottom.Location = new System.Drawing.Point(238, 159);
            this.pbBottom.Name = "pbBottom";
            this.pbBottom.Size = new System.Drawing.Size(12, 12);
            this.pbBottom.TabIndex = 26;
            this.pbBottom.TabStop = false;
            // 
            // pbTop
            // 
            this.pbTop.BackColor = System.Drawing.Color.Black;
            this.pbTop.Location = new System.Drawing.Point(238, 177);
            this.pbTop.Name = "pbTop";
            this.pbTop.Size = new System.Drawing.Size(12, 12);
            this.pbTop.TabIndex = 25;
            this.pbTop.TabStop = false;
            // 
            // lblOrder
            // 
            this.lblOrder.BackColor = System.Drawing.Color.Transparent;
            this.lblOrder.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrder.ForeColor = System.Drawing.Color.Green;
            this.lblOrder.Location = new System.Drawing.Point(3, 0);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(164, 18);
            this.lblOrder.TabIndex = 29;
            this.lblOrder.Text = "INVOICE";
            this.lblOrder.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblOrder.Click += new System.EventHandler(this.lblOrder_Click);
            // 
            // lblCompany
            // 
            this.lblCompany.BackColor = System.Drawing.Color.Transparent;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.ForeColor = System.Drawing.Color.Blue;
            this.lblCompany.Location = new System.Drawing.Point(3, 21);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(164, 15);
            this.lblCompany.TabIndex = 30;
            this.lblCompany.Text = "INVOICE";
            this.lblCompany.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblCompany.Click += new System.EventHandler(this.lblCompany_Click);
            // 
            // lblAgent
            // 
            this.lblAgent.BackColor = System.Drawing.Color.Transparent;
            this.lblAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgent.ForeColor = System.Drawing.Color.Red;
            this.lblAgent.Location = new System.Drawing.Point(3, 36);
            this.lblAgent.Name = "lblAgent";
            this.lblAgent.Size = new System.Drawing.Size(164, 15);
            this.lblAgent.TabIndex = 31;
            this.lblAgent.Text = "INVOICE";
            this.lblAgent.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblAgent.Click += new System.EventHandler(this.lblAgent_Click);
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Black;
            this.lblDate.Location = new System.Drawing.Point(3, 50);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(164, 15);
            this.lblDate.TabIndex = 32;
            this.lblDate.Text = "INVOICE";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblDate.Click += new System.EventHandler(this.lblDate_Click);
            // 
            // mnu
            // 
            this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewOrderToolStripMenuItem,
            this.viewCompanyToolStripMenuItem,
            this.printOrderToolStripMenuItem,
            this.mnuAuthorize});
            this.mnu.Name = "mnu";
            this.mnu.Size = new System.Drawing.Size(155, 92);
            // 
            // viewOrderToolStripMenuItem
            // 
            this.viewOrderToolStripMenuItem.Name = "viewOrderToolStripMenuItem";
            this.viewOrderToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.viewOrderToolStripMenuItem.Text = "View Order";
            this.viewOrderToolStripMenuItem.Click += new System.EventHandler(this.viewOrderToolStripMenuItem_Click);
            // 
            // viewCompanyToolStripMenuItem
            // 
            this.viewCompanyToolStripMenuItem.Name = "viewCompanyToolStripMenuItem";
            this.viewCompanyToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.viewCompanyToolStripMenuItem.Text = "View Company";
            this.viewCompanyToolStripMenuItem.Click += new System.EventHandler(this.viewCompanyToolStripMenuItem_Click);
            // 
            // printOrderToolStripMenuItem
            // 
            this.printOrderToolStripMenuItem.Name = "printOrderToolStripMenuItem";
            this.printOrderToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.printOrderToolStripMenuItem.Text = "Print Order";
            this.printOrderToolStripMenuItem.Click += new System.EventHandler(this.printOrderToolStripMenuItem_Click);
            // 
            // lblIncomplete
            // 
            this.lblIncomplete.BackColor = System.Drawing.Color.Gainsboro;
            this.lblIncomplete.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIncomplete.ForeColor = System.Drawing.Color.Maroon;
            this.lblIncomplete.Location = new System.Drawing.Point(152, 1);
            this.lblIncomplete.Name = "lblIncomplete";
            this.lblIncomplete.Size = new System.Drawing.Size(17, 18);
            this.lblIncomplete.TabIndex = 33;
            this.lblIncomplete.Text = "I";
            this.lblIncomplete.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip1.SetToolTip(this.lblIncomplete, "Order Is Incomplete");
            this.lblIncomplete.Visible = false;
            // 
            // lblVoid
            // 
            this.lblVoid.BackColor = System.Drawing.Color.Gainsboro;
            this.lblVoid.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoid.ForeColor = System.Drawing.Color.Navy;
            this.lblVoid.Location = new System.Drawing.Point(152, 0);
            this.lblVoid.Name = "lblVoid";
            this.lblVoid.Size = new System.Drawing.Size(17, 18);
            this.lblVoid.TabIndex = 34;
            this.lblVoid.Text = "V";
            this.lblVoid.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip1.SetToolTip(this.lblVoid, "Order Is Void");
            this.lblVoid.Visible = false;
            // 
            // mnuAuthorize
            // 
            this.mnuAuthorize.Name = "mnuAuthorize";
            this.mnuAuthorize.Size = new System.Drawing.Size(154, 22);
            this.mnuAuthorize.Text = "Authorize";
            this.mnuAuthorize.Visible = false;
            // 
            // lblAuthorized
            // 
            this.lblAuthorized.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblAuthorized.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthorized.ForeColor = System.Drawing.Color.White;
            this.lblAuthorized.Location = new System.Drawing.Point(152, 19);
            this.lblAuthorized.Name = "lblAuthorized";
            this.lblAuthorized.Size = new System.Drawing.Size(17, 18);
            this.lblAuthorized.TabIndex = 35;
            this.lblAuthorized.Text = "A";
            this.lblAuthorized.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip1.SetToolTip(this.lblAuthorized, "Authorized");
            this.lblAuthorized.Visible = false;
            // 
            // OrderStub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ContextMenuStrip = this.mnu;
            this.Controls.Add(this.lblAuthorized);
            this.Controls.Add(this.lblVoid);
            this.Controls.Add(this.lblIncomplete);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.lblAgent);
            this.Controls.Add(this.lblOrder);
            this.Controls.Add(this.pbLeft);
            this.Controls.Add(this.pbRight);
            this.Controls.Add(this.pbBottom);
            this.Controls.Add(this.pbTop);
            this.Controls.Add(this.lblDate);
            this.Name = "OrderStub";
            this.Size = new System.Drawing.Size(170, 89);
            this.Click += new System.EventHandler(this.OrderStub_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).EndInit();
            this.mnu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLeft;
        private System.Windows.Forms.PictureBox pbRight;
        private System.Windows.Forms.PictureBox pbBottom;
        private System.Windows.Forms.PictureBox pbTop;
        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblAgent;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ContextMenuStrip mnu;
        private System.Windows.Forms.ToolStripMenuItem viewOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewCompanyToolStripMenuItem;
        private System.Windows.Forms.Label lblIncomplete;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblVoid;
        private System.Windows.Forms.ToolStripMenuItem printOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAuthorize;
        private System.Windows.Forms.Label lblAuthorized;

    }
}
