namespace NewMethod
{
    partial class nSQLView
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
            this.tv = new System.Windows.Forms.TreeView();
            this.txt = new System.Windows.Forms.RichTextBox();
            this.gb = new System.Windows.Forms.GroupBox();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.cmdPreview = new System.Windows.Forms.Button();
            this.gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // tv
            // 
            this.tv.Location = new System.Drawing.Point(7, 98);
            this.tv.Name = "tv";
            this.tv.Size = new System.Drawing.Size(456, 558);
            this.tv.TabIndex = 0;
            // 
            // txt
            // 
            this.txt.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt.Location = new System.Drawing.Point(469, 98);
            this.txt.Name = "txt";
            this.txt.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.txt.Size = new System.Drawing.Size(301, 558);
            this.txt.TabIndex = 1;
            this.txt.Text = "";
            this.txt.WordWrap = false;
            // 
            // gb
            // 
            this.gb.Controls.Add(this.cmdPreview);
            this.gb.Controls.Add(this.txtPrefix);
            this.gb.Controls.Add(this.cmdRefresh);
            this.gb.Location = new System.Drawing.Point(3, 3);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(711, 89);
            this.gb.TabIndex = 2;
            this.gb.TabStop = false;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Location = new System.Drawing.Point(3, 11);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(101, 34);
            this.cmdRefresh.TabIndex = 0;
            this.cmdRefresh.Text = "Refresh";
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // txtPrefix
            // 
            this.txtPrefix.Location = new System.Drawing.Point(110, 11);
            this.txtPrefix.Multiline = true;
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPrefix.Size = new System.Drawing.Size(595, 74);
            this.txtPrefix.TabIndex = 1;
            this.txtPrefix.WordWrap = false;
            // 
            // cmdPreview
            // 
            this.cmdPreview.Location = new System.Drawing.Point(3, 51);
            this.cmdPreview.Name = "cmdPreview";
            this.cmdPreview.Size = new System.Drawing.Size(101, 34);
            this.cmdPreview.TabIndex = 2;
            this.cmdPreview.Text = "Preview";
            this.cmdPreview.UseVisualStyleBackColor = true;
            this.cmdPreview.Click += new System.EventHandler(this.cmdPreview_Click);
            // 
            // nSQLView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.tv);
            this.Name = "nSQLView";
            this.Size = new System.Drawing.Size(770, 659);
            this.Resize += new System.EventHandler(this.nSQLView_Resize);
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tv;
        private System.Windows.Forms.RichTextBox txt;
        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.Button cmdPreview;
        private System.Windows.Forms.TextBox txtPrefix;
    }
}
