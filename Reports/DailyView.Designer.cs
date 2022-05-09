namespace Rz5.Reports
{
    partial class DailyView
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
            this.gbHeader = new System.Windows.Forms.GroupBox();
            this.fp = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // gbHeader
            // 
            this.gbHeader.Location = new System.Drawing.Point(6, 5);
            this.gbHeader.Name = "gbHeader";
            this.gbHeader.Size = new System.Drawing.Size(578, 76);
            this.gbHeader.TabIndex = 0;
            this.gbHeader.TabStop = false;
            this.gbHeader.Text = "Stats For <day>";
            // 
            // fp
            // 
            this.fp.Location = new System.Drawing.Point(10, 92);
            this.fp.Name = "fp";
            this.fp.Size = new System.Drawing.Size(724, 468);
            this.fp.TabIndex = 1;
            // 
            // DailyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.fp);
            this.Controls.Add(this.gbHeader);
            this.Name = "DailyView";
            this.Size = new System.Drawing.Size(819, 610);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbHeader;
        private System.Windows.Forms.FlowLayoutPanel fp;
    }
}
