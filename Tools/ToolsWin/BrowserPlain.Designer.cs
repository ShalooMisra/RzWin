using System.Runtime.InteropServices;

namespace ToolsWin
{
    partial class BrowserPlain
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
            //was this causing the studio crashes?
            //try
            //{
            //    if (disposing)
            //    {
            //        Marshal.Release(this.wb.Handle);
            //    }
            //}
            //catch { }

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
            this.pControls = new System.Windows.Forms.Panel();
            this.cmdForward = new System.Windows.Forms.Button();
            this.cmdBack = new System.Windows.Forms.Button();
            this.wb = new System.Windows.Forms.WebBrowser();
            this.cmdPrint = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.pControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // pControls
            // 
            this.pControls.BackColor = System.Drawing.Color.White;
            this.pControls.Controls.Add(this.cmdSave);
            this.pControls.Controls.Add(this.cmdPrint);
            this.pControls.Controls.Add(this.cmdForward);
            this.pControls.Controls.Add(this.cmdBack);
            this.pControls.Location = new System.Drawing.Point(3, 3);
            this.pControls.Name = "pControls";
            this.pControls.Size = new System.Drawing.Size(381, 45);
            this.pControls.TabIndex = 1;
            // 
            // cmdForward
            // 
            this.cmdForward.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cmdForward.Image = global::ToolsWin.Properties.Resources.next;
            this.cmdForward.Location = new System.Drawing.Point(51, 4);
            this.cmdForward.Name = "cmdForward";
            this.cmdForward.Size = new System.Drawing.Size(40, 37);
            this.cmdForward.TabIndex = 1;
            this.cmdForward.UseVisualStyleBackColor = false;
            this.cmdForward.Click += new System.EventHandler(this.cmdForward_Click);
            // 
            // cmdBack
            // 
            this.cmdBack.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cmdBack.Image = global::ToolsWin.Properties.Resources.back;
            this.cmdBack.Location = new System.Drawing.Point(5, 4);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(40, 37);
            this.cmdBack.TabIndex = 0;
            this.cmdBack.UseVisualStyleBackColor = false;
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            // 
            // wb
            // 
            this.wb.Location = new System.Drawing.Point(6, 53);
            this.wb.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb.Name = "wb";
            this.wb.Size = new System.Drawing.Size(680, 414);
            this.wb.TabIndex = 2;
            this.wb.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.wb_Navigated);
            this.wb.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.wb_Navigating);
            // 
            // cmdPrint
            // 
            this.cmdPrint.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cmdPrint.Image = global::ToolsWin.Properties.Resources.Print;
            this.cmdPrint.Location = new System.Drawing.Point(118, 4);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(40, 37);
            this.cmdPrint.TabIndex = 4;
            this.cmdPrint.UseVisualStyleBackColor = false;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cmdSave.Image = global::ToolsWin.Properties.Resources.save;
            this.cmdSave.Location = new System.Drawing.Point(164, 4);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(40, 37);
            this.cmdSave.TabIndex = 5;
            this.cmdSave.UseVisualStyleBackColor = false;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // BrowserPlain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.wb);
            this.Controls.Add(this.pControls);
            this.Name = "BrowserPlain";
            this.Size = new System.Drawing.Size(741, 474);
            this.Resize += new System.EventHandler(this.Browser_Resize);
            this.pControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pControls;
        private System.Windows.Forms.Button cmdBack;
        private System.Windows.Forms.Button cmdForward;
        private System.Windows.Forms.WebBrowser wb;
        private System.Windows.Forms.Button cmdPrint;
        private System.Windows.Forms.Button cmdSave;
    }
}
