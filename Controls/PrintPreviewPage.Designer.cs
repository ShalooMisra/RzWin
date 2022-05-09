namespace Rz5
{
    partial class PrintPreviewPage
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
            this.hs = new System.Windows.Forms.HScrollBar();
            this.vs = new System.Windows.Forms.VScrollBar();
            this.panel = new System.Windows.Forms.Panel();
            this.pg = new System.Windows.Forms.PictureBox();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pg)).BeginInit();
            this.SuspendLayout();
            // 
            // hs
            // 
            this.hs.Location = new System.Drawing.Point(4, 568);
            this.hs.Name = "hs";
            this.hs.Size = new System.Drawing.Size(481, 20);
            this.hs.TabIndex = 12;
            this.hs.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Do_Scroll);
            // 
            // vs
            // 
            this.vs.Location = new System.Drawing.Point(488, 4);
            this.vs.Name = "vs";
            this.vs.Size = new System.Drawing.Size(17, 561);
            this.vs.TabIndex = 10;
            this.vs.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Do_Scroll);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel.Controls.Add(this.pg);
            this.panel.Location = new System.Drawing.Point(1, 1);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(484, 564);
            this.panel.TabIndex = 11;
            // 
            // pg
            // 
            this.pg.BackColor = System.Drawing.Color.White;
            this.pg.Location = new System.Drawing.Point(3, 3);
            this.pg.Name = "pg";
            this.pg.Size = new System.Drawing.Size(389, 539);
            this.pg.TabIndex = 1;
            this.pg.TabStop = false;
            this.pg.Click += new System.EventHandler(this.pg_Click);
            this.pg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pg_MouseDown);
            this.pg.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pg_MouseClick);
            this.pg.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pg_MouseUp);
            // 
            // PrintPreviewPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hs);
            this.Controls.Add(this.vs);
            this.Controls.Add(this.panel);
            this.Name = "PrintPreviewPage";
            this.Size = new System.Drawing.Size(547, 604);
            this.Resize += new System.EventHandler(this.PrintPreviewPage_Resize);
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.HScrollBar hs;
        private System.Windows.Forms.VScrollBar vs;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.PictureBox pg;
    }
}
