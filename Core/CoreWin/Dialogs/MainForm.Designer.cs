namespace CoreWin
{
    partial class MainForm
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
            if (disposing)
            {
                InitUn();
            }

            if (disposing && (components != null))
            {
                components.Dispose();
            }

            try
            {
                base.Dispose(disposing);
            }
            catch { }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tools = new System.Windows.Forms.ToolStrip();
            this.cmdBack = new System.Windows.Forms.ToolStripButton();
            this.sb = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.il24 = new System.Windows.Forms.ImageList(this.components);
            this.mnuViewAllSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.ts = new CoreWin.TabStripCore();
            this.tools.SuspendLayout();
            this.sb.SuspendLayout();
            this.SuspendLayout();
            // 
            // tools
            // 
            this.tools.BackColor = System.Drawing.Color.White;
            this.tools.Dock = System.Windows.Forms.DockStyle.None;
            this.tools.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tools.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdBack});
            this.tools.Location = new System.Drawing.Point(0, 3);
            this.tools.Name = "tools";
            this.tools.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tools.Size = new System.Drawing.Size(85, 31);
            this.tools.TabIndex = 54;
            this.tools.Text = "toolStrip1";
            // 
            // cmdBack
            // 
            this.cmdBack.Image = ((System.Drawing.Image)(resources.GetObject("cmdBack.Image")));
            this.cmdBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.cmdBack.Size = new System.Drawing.Size(78, 28);
            this.cmdBack.Text = "&Back";
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            // 
            // sb
            // 
            this.sb.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.sb.Location = new System.Drawing.Point(0, 582);
            this.sb.Name = "sb";
            this.sb.Size = new System.Drawing.Size(879, 22);
            this.sb.TabIndex = 55;
            this.sb.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(54, 17);
            this.lblStatus.Text = "<status>";
            // 
            // il24
            // 
            this.il24.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il24.ImageStream")));
            this.il24.TransparentColor = System.Drawing.Color.Magenta;
            this.il24.Images.SetKeyName(0, "Exit");
            this.il24.Images.SetKeyName(1, "Back");
            this.il24.Images.SetKeyName(2, "SQL");
            this.il24.Images.SetKeyName(3, "Import");
            this.il24.Images.SetKeyName(4, "Tools");
            this.il24.Images.SetKeyName(5, "Table");
            this.il24.Images.SetKeyName(6, "Target");
            // 
            // mnuViewAllSettings
            // 
            this.mnuViewAllSettings.Name = "mnuViewAllSettings";
            this.mnuViewAllSettings.Size = new System.Drawing.Size(32, 19);
            // 
            // ts
            // 
            this.ts.AllowTabPictures = false;
            this.ts.Location = new System.Drawing.Point(154, 122);
            this.ts.Name = "ts";
            this.ts.Size = new System.Drawing.Size(449, 285);
            this.ts.TabIndex = 56;
            this.ts.TabAdded += new CoreWin.TabStripCoreEventHandler(this.ts_TabAdded);
            this.ts.TabRemoved += new CoreWin.TabStripCoreEventHandler(this.ts_TabRemoved);
            this.ts.TabChanged += new CoreWin.TabStripCoreEventHandler(this.ts_TabChanged);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(879, 604);
            this.Controls.Add(this.ts);
            this.Controls.Add(this.sb);
            this.Controls.Add(this.tools);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_Soft_FormClosing);
            this.Resize += new System.EventHandler(this.frmMain_Soft_Resize);
            this.tools.ResumeLayout(false);
            this.tools.PerformLayout();
            this.sb.ResumeLayout(false);
            this.sb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStripButton cmdBack;
        public System.Windows.Forms.StatusStrip sb;
        public System.Windows.Forms.ToolStripStatusLabel lblStatus;
        public System.Windows.Forms.ToolStrip tools;
        private System.Windows.Forms.ToolStripMenuItem mnuViewAllSettings;
        protected TabStripCore ts;
        public System.Windows.Forms.ImageList il24;
    }
}
