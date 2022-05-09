namespace NewMethod
{
    partial class nActionLink
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
                CompleteDispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(nActionLink));
            this.lbl = new System.Windows.Forms.Label();
            this.ps = new System.Windows.Forms.PictureBox();
            this.IM16 = new System.Windows.Forms.ImageList(this.components);
            this.lblDescription = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ps)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.ForeColor = System.Drawing.Color.Blue;
            this.lbl.Location = new System.Drawing.Point(8, 0);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(34, 13);
            this.lbl.TabIndex = 2;
            this.lbl.Text = "<val>";
            this.lbl.Click += new System.EventHandler(this.lbl_Click);
            this.lbl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.x_MouseDown);
            this.lbl.MouseEnter += new System.EventHandler(this.x_MouseEnter);
            this.lbl.MouseLeave += new System.EventHandler(this.x_MouseLeave);
            this.lbl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.x_MouseUp);
            // 
            // ps
            // 
            this.ps.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ps.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ps.Location = new System.Drawing.Point(0, 4);
            this.ps.Name = "ps";
            this.ps.Size = new System.Drawing.Size(8, 8);
            this.ps.TabIndex = 0;
            this.ps.TabStop = false;
            this.ps.Click += new System.EventHandler(this.ps_Click);
            this.ps.MouseDown += new System.Windows.Forms.MouseEventHandler(this.x_MouseDown);
            this.ps.MouseEnter += new System.EventHandler(this.x_MouseEnter);
            this.ps.MouseLeave += new System.EventHandler(this.x_MouseLeave);
            this.ps.MouseUp += new System.Windows.Forms.MouseEventHandler(this.x_MouseUp);
            // 
            // IM16
            // 
            this.IM16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IM16.ImageStream")));
            this.IM16.TransparentColor = System.Drawing.Color.Fuchsia;
            this.IM16.Images.SetKeyName(0, "action");
            this.IM16.Images.SetKeyName(1, "action_hover");
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.ForeColor = System.Drawing.Color.DarkGray;
            this.lblDescription.Location = new System.Drawing.Point(18, 20);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(53, 13);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "<tag line>";
            // 
            // nActionLink
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.ps);
            this.Controls.Add(this.lbl);
            this.Name = "nActionLink";
            this.Size = new System.Drawing.Size(76, 34);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.x_MouseDown);
            this.MouseEnter += new System.EventHandler(this.x_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.x_MouseLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.x_MouseUp);
            this.Resize += new System.EventHandler(this.nActionLink_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.ps)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ps;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.ImageList IM16;
        private System.Windows.Forms.Label lblDescription;
    }
}
