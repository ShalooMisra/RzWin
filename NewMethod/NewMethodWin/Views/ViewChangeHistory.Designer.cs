namespace NewMethod
{
    partial class ViewChangeHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewChangeHistory));
            this.pCriteria = new System.Windows.Forms.Panel();
            this.chk = new System.Windows.Forms.CheckBox();
            this.lv = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.IM24 = new System.Windows.Forms.ImageList(this.components);
            this.wb = new ToolsWin.BrowserPlain();
            this.chkOnlyChanged = new System.Windows.Forms.CheckBox();
            this.pCriteria.SuspendLayout();
            this.SuspendLayout();
            // 
            // pCriteria
            // 
            this.pCriteria.Controls.Add(this.lv);
            this.pCriteria.Controls.Add(this.chkOnlyChanged);
            this.pCriteria.Controls.Add(this.chk);
            this.pCriteria.Controls.Add(this.cmdRefresh);
            this.pCriteria.Location = new System.Drawing.Point(4, 4);
            this.pCriteria.Margin = new System.Windows.Forms.Padding(4);
            this.pCriteria.Name = "pCriteria";
            this.pCriteria.Size = new System.Drawing.Size(316, 240);
            this.pCriteria.TabIndex = 0;
            // 
            // chk
            // 
            this.chk.AutoSize = true;
            this.chk.Checked = true;
            this.chk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk.Location = new System.Drawing.Point(12, 85);
            this.chk.Name = "chk";
            this.chk.Size = new System.Drawing.Size(163, 25);
            this.chk.TabIndex = 2;
            this.chk.Text = "Check/UnCheck All";
            this.chk.UseVisualStyleBackColor = true;
            this.chk.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // lv
            // 
            this.lv.CheckBoxes = true;
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lv.FullRowSelect = true;
            this.lv.GridLines = true;
            this.lv.HideSelection = false;
            this.lv.Location = new System.Drawing.Point(12, 108);
            this.lv.Margin = new System.Windows.Forms.Padding(4);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(294, 121);
            this.lv.TabIndex = 1;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Property Name";
            this.columnHeader1.Width = 263;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdRefresh.ImageKey = "refresh";
            this.cmdRefresh.ImageList = this.IM24;
            this.cmdRefresh.Location = new System.Drawing.Point(12, 4);
            this.cmdRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(294, 61);
            this.cmdRefresh.TabIndex = 0;
            this.cmdRefresh.Text = "Refresh";
            this.cmdRefresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // IM24
            // 
            this.IM24.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IM24.ImageStream")));
            this.IM24.TransparentColor = System.Drawing.Color.Fuchsia;
            this.IM24.Images.SetKeyName(0, "refresh");
            // 
            // wb
            // 
            this.wb.BackColor = System.Drawing.Color.White;
            this.wb.Location = new System.Drawing.Point(330, 4);
            this.wb.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.wb.Name = "wb";
            this.wb.ShowControls = false;
            this.wb.Silent = false;
            this.wb.Size = new System.Drawing.Size(301, 240);
            this.wb.TabIndex = 2;
            // 
            // chkOnlyChanged
            // 
            this.chkOnlyChanged.AutoSize = true;
            this.chkOnlyChanged.Checked = true;
            this.chkOnlyChanged.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOnlyChanged.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOnlyChanged.Location = new System.Drawing.Point(12, 64);
            this.chkOnlyChanged.Name = "chkOnlyChanged";
            this.chkOnlyChanged.Size = new System.Drawing.Size(203, 25);
            this.chkOnlyChanged.TabIndex = 3;
            this.chkOnlyChanged.Text = "Only Changed Properties";
            this.chkOnlyChanged.UseVisualStyleBackColor = true;
            this.chkOnlyChanged.CheckedChanged += new System.EventHandler(this.chkOnlyChanged_CheckedChanged);
            // 
            // ViewChangeHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.wb);
            this.Controls.Add(this.pCriteria);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ViewChangeHistory";
            this.Size = new System.Drawing.Size(638, 250);
            this.Resize += new System.EventHandler(this.ViewChangeHistory_Resize);
            this.pCriteria.ResumeLayout(false);
            this.pCriteria.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pCriteria;
        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.ImageList IM24;
        private ToolsWin.BrowserPlain wb;
        private System.Windows.Forms.CheckBox chk;
        private System.Windows.Forms.CheckBox chkOnlyChanged;
    }
}
