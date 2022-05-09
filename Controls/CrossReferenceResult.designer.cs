namespace Rz5
{
    partial class CrossReferenceResult
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
            this.lv = new NewMethod.nList();
            this.wb = new ToolsWin.BrowserPlain();
            this.SuspendLayout();
            // 
            // lv
            // 
            this.lv.AddCaption = "Add New";
            this.lv.AllowActions = true;
            this.lv.AllowAdd = false;
            this.lv.AllowDelete = true;
            this.lv.AllowDeleteAlways = false;
            this.lv.AllowDrop = true;
            this.lv.AlternateConnection = null;
            this.lv.Caption = "";
            this.lv.CurrentTemplate = null;
            this.lv.ExtraClassInfo = "";
            this.lv.Location = new System.Drawing.Point(17, 10);
            this.lv.MultiSelect = true;
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(301, 148);
            this.lv.SuppressSelectionChanged = false;
            this.lv.TabIndex = 0;
            this.lv.zz_OpenColumnMenu = false;
            this.lv.zz_ShowAutoRefresh = true;
            this.lv.zz_ShowUnlimited = true;
            // 
            // wb
            // 
            this.wb.Location = new System.Drawing.Point(18, 175);
            this.wb.Name = "wb";
            this.wb.ShowControls = false;
            this.wb.Silent = false;
            this.wb.Size = new System.Drawing.Size(317, 101);
            this.wb.TabIndex = 1;
            // 
            // CrossReferenceResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.wb);
            this.Controls.Add(this.lv);
            this.Name = "CrossReferenceResult";
            this.Size = new System.Drawing.Size(399, 320);
            this.Resize += new System.EventHandler(this.CrossReferenceResult_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        public NewMethod.nList lv;
        public ToolsWin.BrowserPlain wb;

    }
}
