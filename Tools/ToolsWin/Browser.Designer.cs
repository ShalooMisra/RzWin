using System.Runtime.InteropServices;

namespace ToolsWin
{
    partial class Browser
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Browser));
            this.wb = new AxSHDocVw.AxWebBrowser();
            this.pControls = new System.Windows.Forms.Panel();
            this.cmdSave = new System.Windows.Forms.Button();
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.cmdPrint = new System.Windows.Forms.Button();
            this.cmdForward = new System.Windows.Forms.Button();
            this.cmdBack = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.wb)).BeginInit();
            this.pControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // wb
            // 
            this.wb.Enabled = true;
            this.wb.Location = new System.Drawing.Point(21, 68);
            this.wb.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wb.OcxState")));
            this.wb.Size = new System.Drawing.Size(552, 474);
            this.wb.TabIndex = 0;
            this.wb.NewWindow3 += new AxSHDocVw.DWebBrowserEvents2_NewWindow3EventHandler(this.wb_NewWindow3);
            this.wb.StatusTextChange += new AxSHDocVw.DWebBrowserEvents2_StatusTextChangeEventHandler(this.wb_StatusTextChange);
            this.wb.ProgressChange += new AxSHDocVw.DWebBrowserEvents2_ProgressChangeEventHandler(this.wb_ProgressChange);
            this.wb.BeforeNavigate2 += new AxSHDocVw.DWebBrowserEvents2_BeforeNavigate2EventHandler(this.wb_BeforeNavigate2);
            this.wb.NewWindow2 += new AxSHDocVw.DWebBrowserEvents2_NewWindow2EventHandler(this.wb_NewWindow2);
            this.wb.NavigateComplete2 += new AxSHDocVw.DWebBrowserEvents2_NavigateComplete2EventHandler(this.wb_NavigateComplete2);
            this.wb.DocumentComplete += new AxSHDocVw.DWebBrowserEvents2_DocumentCompleteEventHandler(this.wb_DocumentComplete);
            // 
            // pControls
            // 
            this.pControls.Controls.Add(this.cmdSave);
            this.pControls.Controls.Add(this.cmdPrint);
            this.pControls.Controls.Add(this.cmdForward);
            this.pControls.Controls.Add(this.cmdBack);
            this.pControls.Location = new System.Drawing.Point(3, 3);
            this.pControls.Name = "pControls";
            this.pControls.Size = new System.Drawing.Size(381, 37);
            this.pControls.TabIndex = 1;
            // 
            // cmdSave
            // 
            this.cmdSave.BackColor = System.Drawing.Color.White;
            this.cmdSave.ImageKey = "save";
            this.cmdSave.ImageList = this.il;
            this.cmdSave.Location = new System.Drawing.Point(155, 4);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(35, 32);
            this.cmdSave.TabIndex = 3;
            this.cmdSave.UseVisualStyleBackColor = false;
            this.cmdSave.Visible = false;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // il
            // 
            this.il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il.ImageStream")));
            this.il.TransparentColor = System.Drawing.Color.Magenta;
            this.il.Images.SetKeyName(0, "print.bmp");
            this.il.Images.SetKeyName(1, "save");
            this.il.Images.SetKeyName(2, "back");
            // 
            // cmdPrint
            // 
            this.cmdPrint.BackColor = System.Drawing.Color.White;
            this.cmdPrint.ImageKey = "print.bmp";
            this.cmdPrint.ImageList = this.il;
            this.cmdPrint.Location = new System.Drawing.Point(3, 2);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(35, 32);
            this.cmdPrint.TabIndex = 2;
            this.cmdPrint.UseVisualStyleBackColor = false;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // cmdForward
            // 
            this.cmdForward.BackColor = System.Drawing.Color.White;
            this.cmdForward.Location = new System.Drawing.Point(82, 2);
            this.cmdForward.Name = "cmdForward";
            this.cmdForward.Size = new System.Drawing.Size(35, 32);
            this.cmdForward.TabIndex = 1;
            this.cmdForward.UseVisualStyleBackColor = false;
            this.cmdForward.Visible = false;
            this.cmdForward.Click += new System.EventHandler(this.cmdForward_Click);
            // 
            // cmdBack
            // 
            this.cmdBack.BackColor = System.Drawing.Color.White;
            this.cmdBack.ImageKey = "back";
            this.cmdBack.ImageList = this.il;
            this.cmdBack.Location = new System.Drawing.Point(41, 2);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(35, 32);
            this.cmdBack.TabIndex = 0;
            this.cmdBack.UseVisualStyleBackColor = false;
            this.cmdBack.Visible = false;
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            // 
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pControls);
            this.Controls.Add(this.wb);
            this.Name = "Browser";
            this.Size = new System.Drawing.Size(741, 474);
            this.Resize += new System.EventHandler(this.Browser_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.wb)).EndInit();
            this.pControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public AxSHDocVw.AxWebBrowser wb;
        private System.Windows.Forms.Panel pControls;
        private System.Windows.Forms.Button cmdBack;
        private System.Windows.Forms.Button cmdForward;
        private System.Windows.Forms.Button cmdPrint;
        private System.Windows.Forms.ImageList il;
        private System.Windows.Forms.Button cmdSave;
        private System.IO.Ports.SerialPort serialPort1;
    }
}
