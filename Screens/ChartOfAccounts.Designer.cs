namespace RzInterfaceWin.Screens
{
    partial class ChartOfAccounts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartOfAccounts));
            this.lv = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mnu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.accountReportMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.editAccountMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.addASubAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteAccountMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.top = new System.Windows.Forms.Panel();
            this.pSearch = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.mnu.SuspendLayout();
            this.top.SuspendLayout();
            this.pSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // lv
            // 
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader5});
            this.lv.ContextMenuStrip = this.mnu;
            this.lv.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv.FullRowSelect = true;
            this.lv.HideSelection = false;
            this.lv.Location = new System.Drawing.Point(4, 100);
            this.lv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(1100, 619);
            this.lv.SmallImageList = this.il;
            this.lv.TabIndex = 0;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_ColumnClick);
            this.lv.DoubleClick += new System.EventHandler(this.lv_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 294;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Number";
            this.columnHeader2.Width = 98;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Type";
            this.columnHeader4.Width = 191;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Balance";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader5.Width = 147;
            // 
            // mnu
            // 
            this.mnu.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountReportMenu,
            this.editAccountMenu,
            this.addASubAccountToolStripMenuItem,
            this.toolStripSeparator1,
            this.deleteAccountMenu});
            this.mnu.Name = "mnu";
            this.mnu.Size = new System.Drawing.Size(288, 122);
            this.mnu.Opening += new System.ComponentModel.CancelEventHandler(this.mnu_Opening);
            // 
            // accountReportMenu
            // 
            this.accountReportMenu.Name = "accountReportMenu";
            this.accountReportMenu.Size = new System.Drawing.Size(287, 28);
            this.accountReportMenu.Text = "Report on account name";
            this.accountReportMenu.Click += new System.EventHandler(this.accountReportMenu_Click);
            // 
            // editAccountMenu
            // 
            this.editAccountMenu.Name = "editAccountMenu";
            this.editAccountMenu.Size = new System.Drawing.Size(287, 28);
            this.editAccountMenu.Text = "Edit account name";
            this.editAccountMenu.Click += new System.EventHandler(this.editAccountMenu_Click);
            // 
            // addASubAccountToolStripMenuItem
            // 
            this.addASubAccountToolStripMenuItem.Name = "addASubAccountToolStripMenuItem";
            this.addASubAccountToolStripMenuItem.Size = new System.Drawing.Size(287, 28);
            this.addASubAccountToolStripMenuItem.Text = "Add a Sub-Account";
            this.addASubAccountToolStripMenuItem.Click += new System.EventHandler(this.addASubAccountToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(284, 6);
            // 
            // deleteAccountMenu
            // 
            this.deleteAccountMenu.Name = "deleteAccountMenu";
            this.deleteAccountMenu.Size = new System.Drawing.Size(287, 28);
            this.deleteAccountMenu.Text = "Delete account name";
            this.deleteAccountMenu.Click += new System.EventHandler(this.deleteAccountMenu_Click);
            // 
            // il
            // 
            this.il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il.ImageStream")));
            this.il.TransparentColor = System.Drawing.Color.Transparent;
            this.il.Images.SetKeyName(0, "Asset");
            this.il.Images.SetKeyName(1, "Equity");
            this.il.Images.SetKeyName(2, "Expense");
            this.il.Images.SetKeyName(3, "Income");
            this.il.Images.SetKeyName(4, "Liability");
            this.il.Images.SetKeyName(5, "Other");
            // 
            // top
            // 
            this.top.Controls.Add(this.pSearch);
            this.top.Controls.Add(this.addButton);
            this.top.Controls.Add(this.refreshButton);
            this.top.Location = new System.Drawing.Point(4, 4);
            this.top.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.top.Name = "top";
            this.top.Size = new System.Drawing.Size(1033, 89);
            this.top.TabIndex = 1;
            // 
            // pSearch
            // 
            this.pSearch.Controls.Add(this.label1);
            this.pSearch.Controls.Add(this.searchBox);
            this.pSearch.Location = new System.Drawing.Point(605, 5);
            this.pSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pSearch.Name = "pSearch";
            this.pSearch.Size = new System.Drawing.Size(364, 78);
            this.pSearch.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search (enter all or part of an account name)";
            // 
            // searchBox
            // 
            this.searchBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBox.Location = new System.Drawing.Point(27, 41);
            this.searchBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(299, 32);
            this.searchBox.TabIndex = 0;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // addButton
            // 
            this.addButton.BackgroundImage = global::RzInterfaceWin.Properties.Resources.plus;
            this.addButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.addButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Location = new System.Drawing.Point(93, 4);
            this.addButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(68, 80);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add";
            this.addButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.BackgroundImage = global::RzInterfaceWin.Properties.Resources.RefreshBlue3;
            this.refreshButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.refreshButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshButton.Location = new System.Drawing.Point(4, 4);
            this.refreshButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(81, 80);
            this.refreshButton.TabIndex = 0;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // ChartOfAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.top);
            this.Controls.Add(this.lv);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ChartOfAccounts";
            this.Size = new System.Drawing.Size(1281, 832);
            this.Resize += new System.EventHandler(this.ChartOfAccounts_Resize);
            this.mnu.ResumeLayout(false);
            this.top.ResumeLayout(false);
            this.pSearch.ResumeLayout(false);
            this.pSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.Panel top;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ContextMenuStrip mnu;
        private System.Windows.Forms.ToolStripMenuItem addASubAccountToolStripMenuItem;
        private System.Windows.Forms.ImageList il;
        private System.Windows.Forms.ToolStripMenuItem accountReportMenu;
        private System.Windows.Forms.ToolStripMenuItem editAccountMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel pSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.ToolStripMenuItem deleteAccountMenu;
    }
}
