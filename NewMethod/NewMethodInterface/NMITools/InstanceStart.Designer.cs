namespace NewMethod
{
    partial class InstanceStart
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
            this.fp = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // fp
            // 
            this.fp.AutoScroll = true;
            this.fp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fp.Location = new System.Drawing.Point(0, 0);
            this.fp.Name = "fp";
            this.fp.Size = new System.Drawing.Size(681, 627);
            this.fp.TabIndex = 0;
            // 
            // InstanceStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fp);
            this.Name = "InstanceStart";
            this.Size = new System.Drawing.Size(681, 627);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel fp;
    }
}
