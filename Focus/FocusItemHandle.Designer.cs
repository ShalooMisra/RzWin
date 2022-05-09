namespace Rz5.Focus
{
    partial class FocusItemHandle
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FocusItemHandle));
            this.cmdDone = new System.Windows.Forms.Button();
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.pic = new System.Windows.Forms.PictureBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.IM24 = new System.Windows.Forms.ImageList(this.components);
            this.pbRight = new System.Windows.Forms.PictureBox();
            this.pbLeft = new System.Windows.Forms.PictureBox();
            this.pbBottom = new System.Windows.Forms.PictureBox();
            this.pbTop = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdDone
            // 
            this.cmdDone.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdDone.ImageIndex = 0;
            this.cmdDone.ImageList = this.il;
            this.cmdDone.Location = new System.Drawing.Point(10, 89);
            this.cmdDone.Name = "cmdDone";
            this.cmdDone.Size = new System.Drawing.Size(77, 45);
            this.cmdDone.TabIndex = 4;
            this.cmdDone.Text = "Done";
            this.cmdDone.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdDone.UseVisualStyleBackColor = true;
            this.cmdDone.Click += new System.EventHandler(this.cmdDone_Click);
            // 
            // il
            // 
            this.il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il.ImageStream")));
            this.il.TransparentColor = System.Drawing.Color.Magenta;
            this.il.Images.SetKeyName(0, "newtick");
            this.il.Images.SetKeyName(1, "closewindow");
            // 
            // pic
            // 
            this.pic.Location = new System.Drawing.Point(7, 6);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(24, 24);
            this.pic.TabIndex = 3;
            this.pic.TabStop = false;
            // 
            // cmdClose
            // 
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdClose.ImageIndex = 4;
            this.cmdClose.ImageList = this.IM24;
            this.cmdClose.Location = new System.Drawing.Point(10, 33);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(77, 50);
            this.cmdClose.TabIndex = 5;
            this.cmdClose.Text = "Save / Close";
            this.cmdClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // IM24
            // 
            this.IM24.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IM24.ImageStream")));
            this.IM24.TransparentColor = System.Drawing.Color.Fuchsia;
            this.IM24.Images.SetKeyName(0, "Clip");
            this.IM24.Images.SetKeyName(1, "Note");
            this.IM24.Images.SetKeyName(2, "Save");
            this.IM24.Images.SetKeyName(3, "Delete");
            this.IM24.Images.SetKeyName(4, "SaveExit");
            this.IM24.Images.SetKeyName(5, "edit_menu");
            // 
            // pbRight
            // 
            this.pbRight.BackColor = System.Drawing.Color.Blue;
            this.pbRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbRight.Location = new System.Drawing.Point(595, 4);
            this.pbRight.Name = "pbRight";
            this.pbRight.Size = new System.Drawing.Size(4, 156);
            this.pbRight.TabIndex = 11;
            this.pbRight.TabStop = false;
            // 
            // pbLeft
            // 
            this.pbLeft.BackColor = System.Drawing.Color.Blue;
            this.pbLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbLeft.Location = new System.Drawing.Point(0, 4);
            this.pbLeft.Name = "pbLeft";
            this.pbLeft.Size = new System.Drawing.Size(4, 156);
            this.pbLeft.TabIndex = 10;
            this.pbLeft.TabStop = false;
            // 
            // pbBottom
            // 
            this.pbBottom.BackColor = System.Drawing.Color.Blue;
            this.pbBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbBottom.Location = new System.Drawing.Point(0, 160);
            this.pbBottom.Name = "pbBottom";
            this.pbBottom.Size = new System.Drawing.Size(599, 4);
            this.pbBottom.TabIndex = 9;
            this.pbBottom.TabStop = false;
            // 
            // pbTop
            // 
            this.pbTop.BackColor = System.Drawing.Color.Blue;
            this.pbTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbTop.Location = new System.Drawing.Point(0, 0);
            this.pbTop.Name = "pbTop";
            this.pbTop.Size = new System.Drawing.Size(599, 4);
            this.pbTop.TabIndex = 8;
            this.pbTop.TabStop = false;
            // 
            // FocusItemHandle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pbRight);
            this.Controls.Add(this.pbLeft);
            this.Controls.Add(this.pbBottom);
            this.Controls.Add(this.pbTop);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDone);
            this.Controls.Add(this.pic);
            this.Name = "FocusItemHandle";
            this.Size = new System.Drawing.Size(599, 164);
            this.Resize += new System.EventHandler(this.FocusItemHandle_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Button cmdDone;
        private System.Windows.Forms.ImageList il;
        private System.Windows.Forms.Button cmdClose;
        public System.Windows.Forms.ImageList IM24;
        private System.Windows.Forms.PictureBox pbRight;
        private System.Windows.Forms.PictureBox pbLeft;
        private System.Windows.Forms.PictureBox pbBottom;
        private System.Windows.Forms.PictureBox pbTop;
    }
}
