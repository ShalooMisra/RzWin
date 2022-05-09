namespace NewMethod
{
    partial class PermitEditor
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
            this.pbLeft = new System.Windows.Forms.PictureBox();
            this.pbRight = new System.Windows.Forms.PictureBox();
            this.pbBottom = new System.Windows.Forms.PictureBox();
            this.pbTop = new System.Windows.Forms.PictureBox();
            this.tv = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).BeginInit();
            this.SuspendLayout();
            // 
            // pbLeft
            // 
            this.pbLeft.BackColor = System.Drawing.Color.Black;
            this.pbLeft.Location = new System.Drawing.Point(77, 70);
            this.pbLeft.Name = "pbLeft";
            this.pbLeft.Size = new System.Drawing.Size(10, 10);
            this.pbLeft.TabIndex = 20;
            this.pbLeft.TabStop = false;
            // 
            // pbRight
            // 
            this.pbRight.BackColor = System.Drawing.Color.Black;
            this.pbRight.Location = new System.Drawing.Point(77, 54);
            this.pbRight.Name = "pbRight";
            this.pbRight.Size = new System.Drawing.Size(10, 10);
            this.pbRight.TabIndex = 19;
            this.pbRight.TabStop = false;
            // 
            // pbBottom
            // 
            this.pbBottom.BackColor = System.Drawing.Color.Black;
            this.pbBottom.Location = new System.Drawing.Point(93, 54);
            this.pbBottom.Name = "pbBottom";
            this.pbBottom.Size = new System.Drawing.Size(10, 10);
            this.pbBottom.TabIndex = 18;
            this.pbBottom.TabStop = false;
            // 
            // pbTop
            // 
            this.pbTop.BackColor = System.Drawing.Color.Black;
            this.pbTop.Location = new System.Drawing.Point(93, 70);
            this.pbTop.Name = "pbTop";
            this.pbTop.Size = new System.Drawing.Size(10, 10);
            this.pbTop.TabIndex = 17;
            this.pbTop.TabStop = false;
            // 
            // tv
            // 
            this.tv.CheckBoxes = true;
            this.tv.Location = new System.Drawing.Point(12, 14);
            this.tv.Name = "tv";
            this.tv.Size = new System.Drawing.Size(121, 97);
            this.tv.TabIndex = 21;
            // 
            // PermitEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbLeft);
            this.Controls.Add(this.pbRight);
            this.Controls.Add(this.pbBottom);
            this.Controls.Add(this.pbTop);
            this.Controls.Add(this.tv);
            this.Name = "PermitEditor";
            this.Size = new System.Drawing.Size(146, 124);
            this.Resize += new System.EventHandler(this.PermitEditor_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLeft;
        private System.Windows.Forms.PictureBox pbRight;
        private System.Windows.Forms.PictureBox pbBottom;
        private System.Windows.Forms.PictureBox pbTop;
        public System.Windows.Forms.TreeView tv;
    }
}
