namespace NewMethod
{
    partial class nEdit_String
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
            this.txtValue = new System.Windows.Forms.TextBox();
            this.cmdLink = new System.Windows.Forms.Button();
            this.mnu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDomain = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).BeginInit();
            this.mnu.SuspendLayout();
            this.SuspendLayout();
            // 
            // picInfo
            // 
            this.picInfo.Location = new System.Drawing.Point(98, 0);
            // 
            // txtValue
            // 
            this.txtValue.BackColor = System.Drawing.SystemColors.Window;
            this.txtValue.Location = new System.Drawing.Point(6, 20);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(100, 20);
            this.txtValue.TabIndex = 3;
            this.txtValue.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
            this.txtValue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtValue_KeyUp);
            this.txtValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValue_KeyPress);
            // 
            // cmdLink
            // 
            this.cmdLink.BackColor = System.Drawing.Color.Transparent;
            this.cmdLink.Location = new System.Drawing.Point(98, 17);
            this.cmdLink.Name = "cmdLink";
            this.cmdLink.Size = new System.Drawing.Size(6, 7);
            this.cmdLink.TabIndex = 4;
            this.toolTip1.SetToolTip(this.cmdLink, "Click For Options");
            this.cmdLink.UseVisualStyleBackColor = false;
            this.cmdLink.Visible = false;
            this.cmdLink.Click += new System.EventHandler(this.cmdLink_Click);
            // 
            // mnu
            // 
            this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEmail,
            this.mnuDomain});
            this.mnu.Name = "mnu";
            this.mnu.Size = new System.Drawing.Size(150, 48);
            // 
            // mnuEmail
            // 
            this.mnuEmail.Name = "mnuEmail";
            this.mnuEmail.Size = new System.Drawing.Size(149, 22);
            this.mnuEmail.Text = "Send Email To";
            this.mnuEmail.Click += new System.EventHandler(this.mnuEmail_Click);
            // 
            // mnuDomain
            // 
            this.mnuDomain.Name = "mnuDomain";
            this.mnuDomain.Size = new System.Drawing.Size(149, 22);
            this.mnuDomain.Text = "View";
            this.mnuDomain.Click += new System.EventHandler(this.mnuDomain_Click);
            // 
            // nEdit_String
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.cmdLink);
            this.Controls.Add(this.txtValue);
            this.Name = "nEdit_String";
            this.Size = new System.Drawing.Size(114, 40);
            this.Resize += new System.EventHandler(this.nEdit_String_Resize);
            this.Controls.SetChildIndex(this.txtValue, 0);
            this.Controls.SetChildIndex(this.cmdLink, 0);
            this.Controls.SetChildIndex(this.picInfo, 0);
            this.Controls.SetChildIndex(this.picError, 0);
            this.Controls.SetChildIndex(this.lblCaption, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).EndInit();
            this.mnu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Button cmdLink;
        private System.Windows.Forms.ContextMenuStrip mnu;
        private System.Windows.Forms.ToolStripMenuItem mnuEmail;
        private System.Windows.Forms.ToolStripMenuItem mnuDomain;
    }
}
