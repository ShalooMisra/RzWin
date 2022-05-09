namespace Rz5
{
    partial class ProcessControlView
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
            this.GB = new System.Windows.Forms.GroupBox();
            this.VS = new System.Windows.Forms.VScrollBar();
            this.cmdOptions = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GB
            // 
            this.GB.ForeColor = System.Drawing.Color.Black;
            this.GB.Location = new System.Drawing.Point(3, 17);
            this.GB.Name = "GB";
            this.GB.Size = new System.Drawing.Size(152, 99);
            this.GB.TabIndex = 0;
            this.GB.TabStop = false;
            // 
            // VS
            // 
            this.VS.LargeChange = 1;
            this.VS.Location = new System.Drawing.Point(169, 29);
            this.VS.Maximum = 0;
            this.VS.Name = "VS";
            this.VS.Size = new System.Drawing.Size(14, 42);
            this.VS.TabIndex = 1;
            this.VS.Scroll += new System.Windows.Forms.ScrollEventHandler(this.VS_Scroll);
            // 
            // cmdOptions
            // 
            this.cmdOptions.BackColor = System.Drawing.Color.Blue;
            this.cmdOptions.Location = new System.Drawing.Point(230, 60);
            this.cmdOptions.Name = "cmdOptions";
            this.cmdOptions.Size = new System.Drawing.Size(14, 11);
            this.cmdOptions.TabIndex = 2;
            this.cmdOptions.UseVisualStyleBackColor = false;
            // 
            // lblCount
            // 
            this.lblCount.BackColor = System.Drawing.Color.Black;
            this.lblCount.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.Color.White;
            this.lblCount.Location = new System.Drawing.Point(172, 93);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(28, 13);
            this.lblCount.TabIndex = 3;
            this.lblCount.Text = "000";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ProcessControlView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.cmdOptions);
            this.Controls.Add(this.VS);
            this.Controls.Add(this.GB);
            this.Name = "ProcessControlView";
            this.Size = new System.Drawing.Size(309, 175);
            this.Resize += new System.EventHandler(this.ProcessControlView_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GB;
        private System.Windows.Forms.VScrollBar VS;
        private System.Windows.Forms.Button cmdOptions;
        private System.Windows.Forms.Label lblCount;
    }
}
