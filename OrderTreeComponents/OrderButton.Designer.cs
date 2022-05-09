namespace Rz5
{
    partial class OrderButton
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
            this.cmd = new System.Windows.Forms.Button();
            this.picLeft = new System.Windows.Forms.PictureBox();
            this.picRight = new System.Windows.Forms.PictureBox();
            this.picBottom = new System.Windows.Forms.PictureBox();
            this.picTop = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTop)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.Location = new System.Drawing.Point(41, 14);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(95, 15);
            this.lbl.TabIndex = 5;
            this.lbl.Text = "Sales Orders [24]";
            // 
            // cmd
            // 
            this.cmd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmd.Location = new System.Drawing.Point(5, 4);
            this.cmd.Name = "cmd";
            this.cmd.Size = new System.Drawing.Size(34, 34);
            this.cmd.TabIndex = 6;
            this.cmd.UseVisualStyleBackColor = true;
            this.cmd.Click += new System.EventHandler(this.cmd_Click);
            // 
            // picLeft
            // 
            this.picLeft.BackColor = System.Drawing.Color.Red;
            this.picLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.picLeft.Location = new System.Drawing.Point(0, 2);
            this.picLeft.Name = "picLeft";
            this.picLeft.Size = new System.Drawing.Size(2, 38);
            this.picLeft.TabIndex = 4;
            this.picLeft.TabStop = false;
            // 
            // picRight
            // 
            this.picRight.BackColor = System.Drawing.Color.Red;
            this.picRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.picRight.Location = new System.Drawing.Point(140, 2);
            this.picRight.Name = "picRight";
            this.picRight.Size = new System.Drawing.Size(2, 38);
            this.picRight.TabIndex = 3;
            this.picRight.TabStop = false;
            // 
            // picBottom
            // 
            this.picBottom.BackColor = System.Drawing.Color.Red;
            this.picBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.picBottom.Location = new System.Drawing.Point(0, 40);
            this.picBottom.Name = "picBottom";
            this.picBottom.Size = new System.Drawing.Size(142, 2);
            this.picBottom.TabIndex = 2;
            this.picBottom.TabStop = false;
            // 
            // picTop
            // 
            this.picTop.BackColor = System.Drawing.Color.Red;
            this.picTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.picTop.Location = new System.Drawing.Point(0, 0);
            this.picTop.Name = "picTop";
            this.picTop.Size = new System.Drawing.Size(142, 2);
            this.picTop.TabIndex = 1;
            this.picTop.TabStop = false;
            // 
            // OrderButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cmd);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.picLeft);
            this.Controls.Add(this.picRight);
            this.Controls.Add(this.picBottom);
            this.Controls.Add(this.picTop);
            this.Name = "OrderButton";
            this.Size = new System.Drawing.Size(142, 42);
            ((System.ComponentModel.ISupportInitialize)(this.picLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picTop;
        private System.Windows.Forms.PictureBox picBottom;
        private System.Windows.Forms.PictureBox picRight;
        private System.Windows.Forms.PictureBox picLeft;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Button cmd;
    }
}
