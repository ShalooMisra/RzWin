namespace NewMethod
{
    partial class nEdit_List
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
            this.cboValue = new System.Windows.Forms.ComboBox();
            this.lblEdit = new System.Windows.Forms.LinkLabel();
            this.lblRefresh = new System.Windows.Forms.LinkLabel();
            this.cmdLink = new System.Windows.Forms.Button();
            this.mnu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editChoicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).BeginInit();
            this.mnu.SuspendLayout();
            this.SuspendLayout();
            // 
            // picInfo
            // 
            this.picInfo.Location = new System.Drawing.Point(220, 0);
            // 
            // cboValue
            // 
            this.cboValue.FormattingEnabled = true;
            this.cboValue.Location = new System.Drawing.Point(8, 20);
            this.cboValue.Name = "cboValue";
            this.cboValue.Size = new System.Drawing.Size(187, 21);
            this.cboValue.TabIndex = 3;
            this.cboValue.SelectedIndexChanged += new System.EventHandler(this.cboValue_SelectedIndexChanged);
            this.cboValue.TextChanged += new System.EventHandler(this.cboValue_TextChanged);
            this.cboValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboValue_KeyPress);
            this.cboValue.Resize += new System.EventHandler(this.cboValue_Resize);
            // 
            // lblEdit
            // 
            this.lblEdit.AutoSize = true;
            this.lblEdit.Location = new System.Drawing.Point(127, 5);
            this.lblEdit.Name = "lblEdit";
            this.lblEdit.Size = new System.Drawing.Size(24, 13);
            this.lblEdit.TabIndex = 4;
            this.lblEdit.TabStop = true;
            this.lblEdit.Text = "edit";
            this.lblEdit.Visible = false;
            this.lblEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblEdit_LinkClicked);
            // 
            // lblRefresh
            // 
            this.lblRefresh.AutoSize = true;
            this.lblRefresh.Location = new System.Drawing.Point(88, 5);
            this.lblRefresh.Name = "lblRefresh";
            this.lblRefresh.Size = new System.Drawing.Size(39, 13);
            this.lblRefresh.TabIndex = 5;
            this.lblRefresh.TabStop = true;
            this.lblRefresh.Text = "refresh";
            this.lblRefresh.Visible = false;
            this.lblRefresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRefresh_LinkClicked);
            // 
            // cmdLink
            // 
            this.cmdLink.BackColor = System.Drawing.Color.Transparent;
            this.cmdLink.Location = new System.Drawing.Point(115, 20);
            this.cmdLink.Name = "cmdLink";
            this.cmdLink.Size = new System.Drawing.Size(6, 7);
            this.cmdLink.TabIndex = 12;
            this.cmdLink.TabStop = false;
            this.toolTip1.SetToolTip(this.cmdLink, "Click For Options");
            this.cmdLink.UseVisualStyleBackColor = false;
            this.cmdLink.Visible = false;
            this.cmdLink.Click += new System.EventHandler(this.cmdLink_Click);
            // 
            // mnu
            // 
            this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editChoicesToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.mnu.Name = "mnu";
            this.mnu.Size = new System.Drawing.Size(144, 48);
            // 
            // editChoicesToolStripMenuItem
            // 
            this.editChoicesToolStripMenuItem.Name = "editChoicesToolStripMenuItem";
            this.editChoicesToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.editChoicesToolStripMenuItem.Text = "Edit Choices";
            this.editChoicesToolStripMenuItem.Click += new System.EventHandler(this.editChoicesToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // nEdit_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.cmdLink);
            this.Controls.Add(this.lblRefresh);
            this.Controls.Add(this.lblEdit);
            this.Controls.Add(this.cboValue);
            this.Name = "nEdit_List";
            this.Size = new System.Drawing.Size(236, 46);
            this.Resize += new System.EventHandler(this.nEdit_List_Resize);
            this.Controls.SetChildIndex(this.picInfo, 0);
            this.Controls.SetChildIndex(this.picError, 0);
            this.Controls.SetChildIndex(this.cboValue, 0);
            this.Controls.SetChildIndex(this.lblCaption, 0);
            this.Controls.SetChildIndex(this.lblEdit, 0);
            this.Controls.SetChildIndex(this.lblRefresh, 0);
            this.Controls.SetChildIndex(this.cmdLink, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).EndInit();
            this.mnu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip mnu;
        private System.Windows.Forms.ToolStripMenuItem editChoicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        public System.Windows.Forms.ComboBox cboValue;
        public System.Windows.Forms.LinkLabel lblEdit;
        public System.Windows.Forms.LinkLabel lblRefresh;
        public System.Windows.Forms.Button cmdLink;
    }
}
