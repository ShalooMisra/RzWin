namespace Rz5.Views
{
    partial class view_phonecall
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
            this.wb = new ToolsWin.Browser();
            this.SuspendLayout();
            // 
            // xActions
            // 
            this.xActions.Location = new System.Drawing.Point(749, 0);
            this.xActions.Size = new System.Drawing.Size(192, 601);
            // 
            // wb
            // 
            this.wb.Location = new System.Drawing.Point(9, 103);
            this.wb.Name = "wb";
            this.wb.ShowControls = false;
            this.wb.Silent = false;
            this.wb.Size = new System.Drawing.Size(695, 438);
            this.wb.TabIndex = 37;
            // 
            // view_phonecall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.wb);
            this.Name = "view_phonecall";
            this.Size = new System.Drawing.Size(941, 601);
            this.Controls.SetChildIndex(this.wb, 0);
            this.Controls.SetChildIndex(this.xActions, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private ToolsWin.Browser wb;
    }
}
