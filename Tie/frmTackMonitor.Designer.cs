namespace Tie
{
    partial class frmTackMonitor
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
            this.xMon = new Tie.TackMonitor();
            this.SuspendLayout();
            // 
            // xMon
            // 
            this.xMon.BackColor = System.Drawing.Color.White;
            this.xMon.Location = new System.Drawing.Point(1, -1);
            this.xMon.Name = "xMon";
            this.xMon.Size = new System.Drawing.Size(638, 204);
            this.xMon.TabIndex = 0;
            // 
            // frmTackMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 203);
            this.Controls.Add(this.xMon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTackMonitor";
            this.Text = "Pin Monitor";
            this.ResumeLayout(false);

        }

        #endregion

        private TackMonitor xMon;
    }
}