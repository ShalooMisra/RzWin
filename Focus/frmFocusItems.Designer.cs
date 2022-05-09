namespace Rz5.Focus
{
    partial class frmFocusItems
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFocusItems));
            this.lblCaption = new System.Windows.Forms.Label();
            this.lblViewAll = new System.Windows.Forms.LinkLabel();
            this.cmdClose = new System.Windows.Forms.Button();
            this.pbRight = new System.Windows.Forms.PictureBox();
            this.pbLeft = new System.Windows.Forms.PictureBox();
            this.pbBottom = new System.Windows.Forms.PictureBox();
            this.pbTop = new System.Windows.Forms.PictureBox();
            this.picbar = new System.Windows.Forms.PictureBox();
            this.cmdMinimize = new System.Windows.Forms.Button();
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.xTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.Location = new System.Drawing.Point(8, 8);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(79, 20);
            this.lblCaption.TabIndex = 0;
            this.lblCaption.Text = "<caption>";
            // 
            // lblViewAll
            // 
            this.lblViewAll.AutoSize = true;
            this.lblViewAll.Location = new System.Drawing.Point(190, 7);
            this.lblViewAll.Name = "lblViewAll";
            this.lblViewAll.Size = new System.Drawing.Size(42, 13);
            this.lblViewAll.TabIndex = 1;
            this.lblViewAll.TabStop = true;
            this.lblViewAll.Text = "view all";
            this.lblViewAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblViewAll_LinkClicked);
            // 
            // cmdClose
            // 
            this.cmdClose.ImageKey = "close";
            this.cmdClose.ImageList = this.il;
            this.cmdClose.Location = new System.Drawing.Point(403, 3);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(32, 31);
            this.cmdClose.TabIndex = 2;
            this.xTip.SetToolTip(this.cmdClose, "Close");
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // pbRight
            // 
            this.pbRight.BackColor = System.Drawing.Color.Blue;
            this.pbRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbRight.Location = new System.Drawing.Point(435, 4);
            this.pbRight.Name = "pbRight";
            this.pbRight.Size = new System.Drawing.Size(4, 335);
            this.pbRight.TabIndex = 7;
            this.pbRight.TabStop = false;
            // 
            // pbLeft
            // 
            this.pbLeft.BackColor = System.Drawing.Color.Blue;
            this.pbLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbLeft.Location = new System.Drawing.Point(0, 4);
            this.pbLeft.Name = "pbLeft";
            this.pbLeft.Size = new System.Drawing.Size(4, 335);
            this.pbLeft.TabIndex = 6;
            this.pbLeft.TabStop = false;
            // 
            // pbBottom
            // 
            this.pbBottom.BackColor = System.Drawing.Color.Blue;
            this.pbBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbBottom.Location = new System.Drawing.Point(0, 339);
            this.pbBottom.Name = "pbBottom";
            this.pbBottom.Size = new System.Drawing.Size(439, 4);
            this.pbBottom.TabIndex = 5;
            this.pbBottom.TabStop = false;
            // 
            // pbTop
            // 
            this.pbTop.BackColor = System.Drawing.Color.Blue;
            this.pbTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbTop.Location = new System.Drawing.Point(0, 0);
            this.pbTop.Name = "pbTop";
            this.pbTop.Size = new System.Drawing.Size(439, 4);
            this.pbTop.TabIndex = 4;
            this.pbTop.TabStop = false;
            // 
            // picbar
            // 
            this.picbar.BackColor = System.Drawing.Color.Blue;
            this.picbar.Location = new System.Drawing.Point(0, 33);
            this.picbar.Name = "picbar";
            this.picbar.Size = new System.Drawing.Size(439, 4);
            this.picbar.TabIndex = 8;
            this.picbar.TabStop = false;
            // 
            // cmdMinimize
            // 
            this.cmdMinimize.ImageKey = "minimize";
            this.cmdMinimize.ImageList = this.il;
            this.cmdMinimize.Location = new System.Drawing.Point(372, 3);
            this.cmdMinimize.Name = "cmdMinimize";
            this.cmdMinimize.Size = new System.Drawing.Size(32, 31);
            this.cmdMinimize.TabIndex = 9;
            this.xTip.SetToolTip(this.cmdMinimize, "Minimize");
            this.cmdMinimize.UseVisualStyleBackColor = true;
            this.cmdMinimize.Click += new System.EventHandler(this.cmdMinimize_Click);
            // 
            // il
            // 
            this.il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il.ImageStream")));
            this.il.TransparentColor = System.Drawing.Color.Magenta;
            this.il.Images.SetKeyName(0, "close");
            this.il.Images.SetKeyName(1, "minimize");
            // 
            // frmFocusItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(439, 343);
            this.Controls.Add(this.picbar);
            this.Controls.Add(this.pbRight);
            this.Controls.Add(this.pbLeft);
            this.Controls.Add(this.pbBottom);
            this.Controls.Add(this.pbTop);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.lblViewAll);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.cmdMinimize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmFocusItems";
            this.ShowInTaskbar = false;
            this.Text = "Items";
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.LinkLabel lblViewAll;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.PictureBox pbRight;
        private System.Windows.Forms.PictureBox pbLeft;
        private System.Windows.Forms.PictureBox pbBottom;
        private System.Windows.Forms.PictureBox pbTop;
        private System.Windows.Forms.PictureBox picbar;
        private System.Windows.Forms.Button cmdMinimize;
        private System.Windows.Forms.ImageList il;
        private System.Windows.Forms.ToolTip xTip;
    }
}