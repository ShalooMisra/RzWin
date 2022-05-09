namespace Tie
{
    partial class frmClientConnection
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
            this.xView = new Tie.EndView();
            this.SuspendLayout();
            // 
            // xView
            // 
            this.xView.Location = new System.Drawing.Point(3, 2);
            this.xView.Name = "xView";
            this.xView.Size = new System.Drawing.Size(433, 445);
            this.xView.TabIndex = 0;
            // 
            // frmClientConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 446);
            this.Controls.Add(this.xView);
            this.Name = "frmClientConnection";
            this.Text = "frmClientConnection";
            this.ResumeLayout(false);

        }

        #endregion

        private EndView xView;
    }
}