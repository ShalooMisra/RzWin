namespace Tie
{
    partial class PinPermission
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
            this.lbl = new System.Windows.Forms.Label();
            this.pic = new System.Windows.Forms.PictureBox();
            this.chk = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lbl.Location = new System.Drawing.Point(26, 2);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(523, 17);
            this.lbl.TabIndex = 42;
            this.lbl.Text = "<description>";
            // 
            // pic
            // 
            this.pic.Location = new System.Drawing.Point(0, 4);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(24, 24);
            this.pic.TabIndex = 41;
            this.pic.TabStop = false;
            // 
            // chk
            // 
            this.chk.AutoSize = true;
            this.chk.Location = new System.Drawing.Point(28, 14);
            this.chk.Name = "chk";
            this.chk.Size = new System.Drawing.Size(59, 17);
            this.chk.TabIndex = 40;
            this.chk.Text = "Enable";
            this.chk.UseVisualStyleBackColor = true;
            // 
            // PinPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pic);
            this.Controls.Add(this.chk);
            this.Controls.Add(this.lbl);
            this.Name = "PinPermission";
            this.Size = new System.Drawing.Size(733, 32);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.CheckBox chk;
    }
}
