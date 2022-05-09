namespace RzInterfaceWin.Controls
{
    partial class nEdit_Currency
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
            this.picCurrency = new System.Windows.Forms.PictureBox();
            this.nameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCurrency)).BeginInit();
            this.SuspendLayout();
            // 
            // picCurrency
            // 
            this.picCurrency.BackColor = System.Drawing.Color.Red;
            this.picCurrency.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picCurrency.Location = new System.Drawing.Point(220, 22);
            this.picCurrency.Name = "picCurrency";
            this.picCurrency.Size = new System.Drawing.Size(16, 16);
            this.picCurrency.TabIndex = 5;
            this.picCurrency.TabStop = false;
            this.picCurrency.Click += new System.EventHandler(this.picCurrency_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(217, 8);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(30, 13);
            this.nameLabel.TabIndex = 6;
            this.nameLabel.Text = "USD";
            // 
            // nEdit_Currency
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.picCurrency);
            this.Name = "nEdit_Currency";
            this.Controls.SetChildIndex(this.txtValue, 0);
            this.Controls.SetChildIndex(this.picInfo, 0);
            this.Controls.SetChildIndex(this.picError, 0);
            this.Controls.SetChildIndex(this.lblCaption, 0);
            this.Controls.SetChildIndex(this.picCurrency, 0);
            this.Controls.SetChildIndex(this.nameLabel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCurrency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCurrency;
        private System.Windows.Forms.Label nameLabel;
    }
}
