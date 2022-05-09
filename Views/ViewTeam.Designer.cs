namespace Rz5
{
    partial class ViewTeam
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
            this.cmdApply = new System.Windows.Forms.Button();
            this.lv = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblTeam = new System.Windows.Forms.Label();
            this.chkAllowExport = new System.Windows.Forms.CheckBox();
            this.chkViewAllOrders = new System.Windows.Forms.CheckBox();
            this.chkViewAllComps = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkDeleteAllItems = new System.Windows.Forms.CheckBox();
            this.chkAllowedToViewOrderLinks = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdApply
            // 
            this.cmdApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdApply.Location = new System.Drawing.Point(252, 163);
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(310, 47);
            this.cmdApply.TabIndex = 1;
            this.cmdApply.Text = "Apply";
            this.cmdApply.UseVisualStyleBackColor = true;
            this.cmdApply.Click += new System.EventHandler(this.cmdApply_Click);
            // 
            // lv
            // 
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lv.FullRowSelect = true;
            this.lv.GridLines = true;
            this.lv.HideSelection = false;
            this.lv.Location = new System.Drawing.Point(10, 51);
            this.lv.MultiSelect = false;
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(230, 159);
            this.lv.TabIndex = 2;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Agent";
            this.columnHeader1.Width = 198;
            // 
            // lblTeam
            // 
            this.lblTeam.BackColor = System.Drawing.Color.White;
            this.lblTeam.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTeam.Location = new System.Drawing.Point(6, 16);
            this.lblTeam.Name = "lblTeam";
            this.lblTeam.Size = new System.Drawing.Size(556, 23);
            this.lblTeam.TabIndex = 3;
            this.lblTeam.Text = "TEAMNAME";
            this.lblTeam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkAllowExport
            // 
            this.chkAllowExport.AutoSize = true;
            this.chkAllowExport.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllowExport.Location = new System.Drawing.Point(252, 44);
            this.chkAllowExport.Name = "chkAllowExport";
            this.chkAllowExport.Size = new System.Drawing.Size(194, 28);
            this.chkAllowExport.TabIndex = 4;
            this.chkAllowExport.Text = "Allowed To Export";
            this.chkAllowExport.UseVisualStyleBackColor = true;
            // 
            // chkViewAllOrders
            // 
            this.chkViewAllOrders.AutoSize = true;
            this.chkViewAllOrders.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkViewAllOrders.Location = new System.Drawing.Point(252, 67);
            this.chkViewAllOrders.Name = "chkViewAllOrders";
            this.chkViewAllOrders.Size = new System.Drawing.Size(272, 28);
            this.chkViewAllOrders.TabIndex = 5;
            this.chkViewAllOrders.Text = "Allowed To View All Orders";
            this.chkViewAllOrders.UseVisualStyleBackColor = true;
            // 
            // chkViewAllComps
            // 
            this.chkViewAllComps.AutoSize = true;
            this.chkViewAllComps.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkViewAllComps.Location = new System.Drawing.Point(252, 90);
            this.chkViewAllComps.Name = "chkViewAllComps";
            this.chkViewAllComps.Size = new System.Drawing.Size(310, 28);
            this.chkViewAllComps.TabIndex = 6;
            this.chkViewAllComps.Text = "Allowed To View All Companies";
            this.chkViewAllComps.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAllowedToViewOrderLinks);
            this.groupBox1.Controls.Add(this.chkDeleteAllItems);
            this.groupBox1.Controls.Add(this.lblTeam);
            this.groupBox1.Controls.Add(this.chkViewAllComps);
            this.groupBox1.Controls.Add(this.lv);
            this.groupBox1.Controls.Add(this.chkViewAllOrders);
            this.groupBox1.Controls.Add(this.cmdApply);
            this.groupBox1.Controls.Add(this.chkAllowExport);
            this.groupBox1.Location = new System.Drawing.Point(16, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(569, 217);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // chkDeleteAllItems
            // 
            this.chkDeleteAllItems.AutoSize = true;
            this.chkDeleteAllItems.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDeleteAllItems.Location = new System.Drawing.Point(252, 113);
            this.chkDeleteAllItems.Name = "chkDeleteAllItems";
            this.chkDeleteAllItems.Size = new System.Drawing.Size(273, 28);
            this.chkDeleteAllItems.TabIndex = 7;
            this.chkDeleteAllItems.Text = "Allowed To Delete All Items";
            this.chkDeleteAllItems.UseVisualStyleBackColor = true;
            // 
            // chkAllowedToViewOrderLinks
            // 
            this.chkAllowedToViewOrderLinks.AutoSize = true;
            this.chkAllowedToViewOrderLinks.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllowedToViewOrderLinks.Location = new System.Drawing.Point(252, 136);
            this.chkAllowedToViewOrderLinks.Name = "chkAllowedToViewOrderLinks";
            this.chkAllowedToViewOrderLinks.Size = new System.Drawing.Size(289, 28);
            this.chkAllowedToViewOrderLinks.TabIndex = 8;
            this.chkAllowedToViewOrderLinks.Text = "Allowed To View Order Links";
            this.chkAllowedToViewOrderLinks.UseVisualStyleBackColor = true;
            // 
            // ViewTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.groupBox1);
            this.Name = "ViewTeam";
            this.Size = new System.Drawing.Size(696, 525);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdApply;
        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label lblTeam;
        private System.Windows.Forms.CheckBox chkAllowExport;
        private System.Windows.Forms.CheckBox chkViewAllOrders;
        private System.Windows.Forms.CheckBox chkViewAllComps;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkDeleteAllItems;
        private System.Windows.Forms.CheckBox chkAllowedToViewOrderLinks;
    }
}
