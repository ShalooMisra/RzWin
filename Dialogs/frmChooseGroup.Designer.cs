namespace Rz5
{
    partial class frmChooseGroup
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
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.lv = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbNew = new System.Windows.Forms.GroupBox();
            this.lblAdd = new System.Windows.Forms.LinkLabel();
            this.ctlName = new NewMethod.nEdit_String();
            this.mnu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbNew.SuspendLayout();
            this.mnu.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(5, 515);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(151, 32);
            this.cmdCancel.TabIndex = 0;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(162, 515);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(263, 32);
            this.cmdOK.TabIndex = 1;
            this.cmdOK.Text = "&OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // lv
            // 
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lv.ContextMenuStrip = this.mnu;
            this.lv.FullRowSelect = true;
            this.lv.GridLines = true;
            this.lv.HideSelection = false;
            this.lv.Location = new System.Drawing.Point(-2, -1);
            this.lv.MultiSelect = false;
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(435, 439);
            this.lv.TabIndex = 2;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.SelectedIndexChanged += new System.EventHandler(this.lv_SelectedIndexChanged);
            this.lv.DoubleClick += new System.EventHandler(this.lv_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 424;
            // 
            // gbNew
            // 
            this.gbNew.BackColor = System.Drawing.Color.White;
            this.gbNew.Controls.Add(this.lblAdd);
            this.gbNew.Controls.Add(this.ctlName);
            this.gbNew.Location = new System.Drawing.Point(2, 444);
            this.gbNew.Name = "gbNew";
            this.gbNew.Size = new System.Drawing.Size(431, 65);
            this.gbNew.TabIndex = 3;
            this.gbNew.TabStop = false;
            this.gbNew.Text = "New Group";
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.Location = new System.Drawing.Point(349, 14);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(74, 13);
            this.lblAdd.TabIndex = 4;
            this.lblAdd.TabStop = true;
            this.lblAdd.Text = "add this group";
            this.lblAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAdd_LinkClicked);
            // 
            // ctlName
            // 
            this.ctlName.AllCaps = false;
            this.ctlName.BackColor = System.Drawing.Color.White;
            this.ctlName.Bold = false;
            this.ctlName.Caption = "Name";
            this.ctlName.Changed = false;
            this.ctlName.IsEmail = false;
            this.ctlName.IsURL = false;
            this.ctlName.Location = new System.Drawing.Point(3, 14);
            this.ctlName.Name = "ctlName";
            this.ctlName.PasswordChar = '\0';
            this.ctlName.Size = new System.Drawing.Size(422, 41);
            this.ctlName.TabIndex = 0;
            this.ctlName.UseParentBackColor = true;
            this.ctlName.zz_Enabled = true;
            this.ctlName.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlName.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlName.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlName.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlName.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctlName.zz_OriginalDesign = true;
            this.ctlName.zz_ShowLinkButton = false;
            this.ctlName.zz_ShowNeedsSaveColor = true;
            this.ctlName.zz_Text = "";
            this.ctlName.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlName.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlName.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlName.zz_UseGlobalColor = false;
            this.ctlName.zz_UseGlobalFont = false;
            // 
            // mnu
            // 
            this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.mnu.Name = "mnu";
            this.mnu.Size = new System.Drawing.Size(153, 48);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // frmChooseGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(437, 551);
            this.ControlBox = false;
            this.Controls.Add(this.gbNew);
            this.Controls.Add(this.lv);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.Name = "frmChooseGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Group Selector";
            this.gbNew.ResumeLayout(false);
            this.gbNew.PerformLayout();
            this.mnu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox gbNew;
        private NewMethod.nEdit_String ctlName;
        private System.Windows.Forms.LinkLabel lblAdd;
        private System.Windows.Forms.ContextMenuStrip mnu;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}