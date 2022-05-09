namespace NewMethod
{
    partial class nEdit_Date
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
            this.dt = new System.Windows.Forms.DateTimePicker();
            this.lbl = new System.Windows.Forms.LinkLabel();
            this.lblFixed = new System.Windows.Forms.Label();
            this.lblClear = new System.Windows.Forms.LinkLabel();
            this.cmdLink = new System.Windows.Forms.Button();
            this.mnu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pChanged = new System.Windows.Forms.Panel();
            this.lblNoDate = new System.Windows.Forms.TextBox();
            this.lblFixedDate = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).BeginInit();
            this.mnu.SuspendLayout();
            this.SuspendLayout();
            // 
            // picInfo
            // 
            this.picInfo.Location = new System.Drawing.Point(289, 0);
            // 
            // dt
            // 
            this.dt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt.Location = new System.Drawing.Point(8, 19);
            this.dt.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dt.Name = "dt";
            this.dt.Size = new System.Drawing.Size(244, 20);
            this.dt.TabIndex = 1;
            this.dt.ValueChanged += new System.EventHandler(this.dt_ValueChanged);
            this.dt.DropDown += new System.EventHandler(this.dt_DropDown);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(14, 25);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(90, 13);
            this.lbl.TabIndex = 2;
            this.lbl.TabStop = true;
            this.lbl.Text = "< click to select >";
            this.lbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_LinkClicked);
            // 
            // lblFixed
            // 
            this.lblFixed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFixed.Location = new System.Drawing.Point(8, 21);
            this.lblFixed.Name = "lblFixed";
            this.lblFixed.Size = new System.Drawing.Size(271, 18);
            this.lblFixed.TabIndex = 3;
            this.lblFixed.Text = "<>";
            // 
            // lblClear
            // 
            this.lblClear.AutoSize = true;
            this.lblClear.LinkColor = System.Drawing.Color.Purple;
            this.lblClear.Location = new System.Drawing.Point(11, 39);
            this.lblClear.Name = "lblClear";
            this.lblClear.Size = new System.Drawing.Size(30, 13);
            this.lblClear.TabIndex = 10;
            this.lblClear.TabStop = true;
            this.lblClear.Text = "clear";
            this.lblClear.Visible = false;
            this.lblClear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblClear_LinkClicked);
            // 
            // cmdLink
            // 
            this.cmdLink.BackColor = System.Drawing.Color.Transparent;
            this.cmdLink.Location = new System.Drawing.Point(149, 24);
            this.cmdLink.Name = "cmdLink";
            this.cmdLink.Size = new System.Drawing.Size(6, 7);
            this.cmdLink.TabIndex = 11;
            this.toolTip1.SetToolTip(this.cmdLink, "Click For Options");
            this.cmdLink.UseVisualStyleBackColor = false;
            this.cmdLink.Visible = false;
            this.cmdLink.Click += new System.EventHandler(this.cmdLink_Click);
            // 
            // mnu
            // 
            this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearDateToolStripMenuItem});
            this.mnu.Name = "mnu";
            this.mnu.Size = new System.Drawing.Size(129, 26);
            // 
            // clearDateToolStripMenuItem
            // 
            this.clearDateToolStripMenuItem.Name = "clearDateToolStripMenuItem";
            this.clearDateToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.clearDateToolStripMenuItem.Text = "Clear Date";
            this.clearDateToolStripMenuItem.Click += new System.EventHandler(this.clearDateToolStripMenuItem_Click);
            // 
            // pChanged
            // 
            this.pChanged.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pChanged.Location = new System.Drawing.Point(260, 24);
            this.pChanged.Name = "pChanged";
            this.pChanged.Size = new System.Drawing.Size(19, 18);
            this.pChanged.TabIndex = 15;
            this.pChanged.Visible = false;
            // 
            // lblNoDate
            // 
            this.lblNoDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNoDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblNoDate.Location = new System.Drawing.Point(17, 86);
            this.lblNoDate.Name = "lblNoDate";
            this.lblNoDate.Size = new System.Drawing.Size(126, 20);
            this.lblNoDate.TabIndex = 16;
            this.lblNoDate.Text = "< Click To Select >";
            this.lblNoDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lblNoDate.Click += new System.EventHandler(this.lblNoDate_Click);
            this.lblNoDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lbl_KeyPress);
            // 
            // lblFixedDate
            // 
            this.lblFixedDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFixedDate.Location = new System.Drawing.Point(149, 86);
            this.lblFixedDate.Name = "lblFixedDate";
            this.lblFixedDate.Size = new System.Drawing.Size(123, 20);
            this.lblFixedDate.TabIndex = 17;
            this.lblFixedDate.Text = "00/00/0000";
            this.lblFixedDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lblFixedDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lbl_KeyPress);
            // 
            // nEdit_Date
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.dt);
            this.Controls.Add(this.lblNoDate);
            this.Controls.Add(this.lblFixedDate);
            this.Controls.Add(this.pChanged);
            this.Controls.Add(this.cmdLink);
            this.Controls.Add(this.lblFixed);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.lblClear);
            this.Name = "nEdit_Date";
            this.Size = new System.Drawing.Size(305, 60);
            this.Resize += new System.EventHandler(this.nEdit_Date_Resize);
            this.Controls.SetChildIndex(this.lblClear, 0);
            this.Controls.SetChildIndex(this.lbl, 0);
            this.Controls.SetChildIndex(this.lblFixed, 0);
            this.Controls.SetChildIndex(this.picInfo, 0);
            this.Controls.SetChildIndex(this.picError, 0);
            this.Controls.SetChildIndex(this.lblCaption, 0);
            this.Controls.SetChildIndex(this.cmdLink, 0);
            this.Controls.SetChildIndex(this.pChanged, 0);
            this.Controls.SetChildIndex(this.lblFixedDate, 0);
            this.Controls.SetChildIndex(this.lblNoDate, 0);
            this.Controls.SetChildIndex(this.dt, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).EndInit();
            this.mnu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dt;
        private System.Windows.Forms.LinkLabel lbl;
        private System.Windows.Forms.Label lblFixed;
        private System.Windows.Forms.LinkLabel lblClear;
        private System.Windows.Forms.Button cmdLink;
        private System.Windows.Forms.ContextMenuStrip mnu;
        private System.Windows.Forms.ToolStripMenuItem clearDateToolStripMenuItem;
        private System.Windows.Forms.Panel pChanged;
        private System.Windows.Forms.TextBox lblNoDate;
        private System.Windows.Forms.TextBox lblFixedDate;
    }
}
