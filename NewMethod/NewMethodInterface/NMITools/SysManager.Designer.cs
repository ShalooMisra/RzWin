namespace NewMethod
{
    partial class SysManager
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
            this.gb = new System.Windows.Forms.GroupBox();
            this.lblOpen = new System.Windows.Forms.LinkLabel();
            this.fp = new System.Windows.Forms.FlowLayoutPanel();
            this.lblLastNM = new System.Windows.Forms.LinkLabel();
            this.gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb
            // 
            this.gb.BackColor = System.Drawing.Color.White;
            this.gb.Controls.Add(this.lblLastNM);
            this.gb.Controls.Add(this.lblOpen);
            this.gb.Location = new System.Drawing.Point(6, 4);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(394, 39);
            this.gb.TabIndex = 0;
            this.gb.TabStop = false;
            // 
            // lblOpen
            // 
            this.lblOpen.AutoSize = true;
            this.lblOpen.Location = new System.Drawing.Point(8, 16);
            this.lblOpen.Name = "lblOpen";
            this.lblOpen.Size = new System.Drawing.Size(31, 13);
            this.lblOpen.TabIndex = 0;
            this.lblOpen.TabStop = true;
            this.lblOpen.Text = "open";
            this.lblOpen.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblOpen_LinkClicked);
            // 
            // fp
            // 
            this.fp.BackColor = System.Drawing.Color.White;
            this.fp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fp.Location = new System.Drawing.Point(6, 49);
            this.fp.Name = "fp";
            this.fp.Size = new System.Drawing.Size(880, 714);
            this.fp.TabIndex = 1;
            // 
            // lblLastNM
            // 
            this.lblLastNM.AutoSize = true;
            this.lblLastNM.Location = new System.Drawing.Point(75, 16);
            this.lblLastNM.Name = "lblLastNM";
            this.lblLastNM.Size = new System.Drawing.Size(70, 13);
            this.lblLastNM.TabIndex = 1;
            this.lblLastNM.TabStop = true;
            this.lblLastNM.Text = "open last NM";
            this.lblLastNM.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLastNM_LinkClicked);
            // 
            // SysManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.fp);
            this.Controls.Add(this.gb);
            this.Name = "SysManager";
            this.Size = new System.Drawing.Size(889, 804);
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.FlowLayoutPanel fp;
        private System.Windows.Forms.LinkLabel lblOpen;
        private System.Windows.Forms.LinkLabel lblLastNM;
    }
}
