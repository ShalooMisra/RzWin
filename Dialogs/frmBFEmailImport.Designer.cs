namespace Rz5
{
    partial class frmBFEmailImport
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
            this.cmdImport = new System.Windows.Forms.Button();
            this.lblUP = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ctl_search_value = new NewMethod.nEdit_String();
            this.cmdReset = new System.Windows.Forms.Button();
            this.wb2 = new ToolsWin.Browser();
            this.wb1 = new ToolsWin.Browser();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdImport
            // 
            this.cmdImport.Location = new System.Drawing.Point(1056, 706);
            this.cmdImport.Name = "cmdImport";
            this.cmdImport.Size = new System.Drawing.Size(320, 23);
            this.cmdImport.TabIndex = 2;
            this.cmdImport.Text = "Import";
            this.cmdImport.UseVisualStyleBackColor = true;
            this.cmdImport.Click += new System.EventHandler(this.cmdImport_Click);
            // 
            // lblUP
            // 
            this.lblUP.AutoSize = true;
            this.lblUP.Location = new System.Drawing.Point(352, 711);
            this.lblUP.Name = "lblUP";
            this.lblUP.Size = new System.Drawing.Size(158, 13);
            this.lblUP.TabIndex = 3;
            this.lblUP.Text = "User: mildredramsey PW: abarth";
            this.lblUP.Visible = false;
            this.lblUP.Click += new System.EventHandler(this.lblUP_Click);
            this.lblUP.DoubleClick += new System.EventHandler(this.lblUP_DoubleClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(4, 5);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.wb1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.wb2);
            this.splitContainer1.Size = new System.Drawing.Size(1372, 695);
            this.splitContainer1.SplitterDistance = 347;
            this.splitContainer1.TabIndex = 4;
            // 
            // ctl_search_value
            // 
            this.ctl_search_value.AllCaps = false;
            this.ctl_search_value.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_search_value.Bold = false;
            this.ctl_search_value.Caption = "Search Value";
            this.ctl_search_value.Changed = false;
            this.ctl_search_value.IsEmail = false;
            this.ctl_search_value.IsURL = false;
            this.ctl_search_value.Location = new System.Drawing.Point(12, 706);
            this.ctl_search_value.Name = "ctl_search_value";
            this.ctl_search_value.PasswordChar = '\0';
            this.ctl_search_value.Size = new System.Drawing.Size(223, 21);
            this.ctl_search_value.TabIndex = 1;
            this.ctl_search_value.UseParentBackColor = false;
            this.ctl_search_value.zz_Enabled = true;
            this.ctl_search_value.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_search_value.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_search_value.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_search_value.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_search_value.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.Left;
            this.ctl_search_value.zz_OriginalDesign = false;
            this.ctl_search_value.zz_ShowLinkButton = false;
            this.ctl_search_value.zz_ShowNeedsSaveColor = true;
            this.ctl_search_value.zz_Text = "";
            this.ctl_search_value.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_search_value.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_search_value.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_search_value.zz_UseGlobalColor = false;
            this.ctl_search_value.zz_UseGlobalFont = false;
            // 
            // cmdReset
            // 
            this.cmdReset.Location = new System.Drawing.Point(873, 706);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(154, 23);
            this.cmdReset.TabIndex = 5;
            this.cmdReset.Text = "Reset Search String";
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // wb2
            // 
            this.wb2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wb2.Location = new System.Drawing.Point(0, 0);
            this.wb2.Name = "wb2";
            this.wb2.ShowControls = false;
            this.wb2.Silent = false;
            this.wb2.Size = new System.Drawing.Size(1372, 344);
            this.wb2.TabIndex = 0;
            // 
            // wb1
            // 
            this.wb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wb1.Location = new System.Drawing.Point(0, 0);
            this.wb1.Name = "wb1";
            this.wb1.ShowControls = false;
            this.wb1.Silent = false;
            this.wb1.Size = new System.Drawing.Size(1372, 347);
            this.wb1.TabIndex = 1;
            // 
            // frmBFEmailImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 730);
            this.Controls.Add(this.cmdReset);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lblUP);
            this.Controls.Add(this.cmdImport);
            this.Controls.Add(this.ctl_search_value);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmBFEmailImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BrokerForum Email Import";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NewMethod.nEdit_String ctl_search_value;
        private System.Windows.Forms.Button cmdImport;
        private System.Windows.Forms.Label lblUP;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button cmdReset;
        private ToolsWin.Browser wb1;
        private ToolsWin.Browser wb2;
    }
}