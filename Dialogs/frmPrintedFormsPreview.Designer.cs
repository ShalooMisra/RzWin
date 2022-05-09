namespace Rz5
{
    partial class frmPrintedFormsPreview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintedFormsPreview));
            this.bg = new System.ComponentModel.BackgroundWorker();
            this.ts = new System.Windows.Forms.TabControl();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.cmdPrint = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.designer = new Rz5.DesignOptions();
            this.Preview = new Rz5.PrintPreviewPage();
            this.SuspendLayout();
            // 
            // bg
            // 
            this.bg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_DoWork);
            this.bg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_RunWorkerCompleted);
            // 
            // ts
            // 
            this.ts.Location = new System.Drawing.Point(12, 12);
            this.ts.Name = "ts";
            this.ts.SelectedIndex = 0;
            this.ts.Size = new System.Drawing.Size(140, 34);
            this.ts.TabIndex = 0;
            this.ts.SelectedIndexChanged += new System.EventHandler(this.ts_SelectedIndexChanged);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.BackgroundImage = global::RzInterfaceWin.Properties.Resources.refresh;
            this.cmdRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRefresh.Location = new System.Drawing.Point(39, 67);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(25, 23);
            this.cmdRefresh.TabIndex = 21;
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // cmdPrint
            // 
            this.cmdPrint.Image = global::RzInterfaceWin.Properties.Resources.printersm;
            this.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPrint.Location = new System.Drawing.Point(70, 67);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(25, 23);
            this.cmdPrint.TabIndex = 20;
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Image = global::RzInterfaceWin.Properties.Resources.eventlogError;
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(101, 67);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(25, 23);
            this.cmdClose.TabIndex = 22;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Visible = false;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // designer
            // 
            this.designer.Location = new System.Drawing.Point(12, 194);
            this.designer.Name = "designer";
            this.designer.Size = new System.Drawing.Size(788, 295);
            this.designer.TabIndex = 23;
            this.designer.Load += new System.EventHandler(this.designer_Load);
            // 
            // Preview
            // 
            this.Preview.AlternateResize = true;
            this.Preview.Location = new System.Drawing.Point(12, 52);
            this.Preview.Name = "Preview";
            this.Preview.Size = new System.Drawing.Size(140, 84);
            this.Preview.TabIndex = 1;
            this.Preview.PreviewClick += new Rz5.PreviewClickHandler(this.Preview_PreviewClick);
            this.Preview.PreviewBox += new Rz5.PreviewBoxHandler(this.Preview_PreviewBox);
            // 
            // frmPrintedFormsPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 574);
            this.Controls.Add(this.designer);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdRefresh);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.Preview);
            this.Controls.Add(this.ts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPrintedFormsPreview";
            this.Text = "PrintedForms Preview";
            this.Resize += new System.EventHandler(this.frmPrintedFormsPreview_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bg;
        private System.Windows.Forms.TabControl ts;
        private PrintPreviewPage Preview;
        private System.Windows.Forms.Button cmdPrint;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.Button cmdClose;
        private DesignOptions designer;


    }
}