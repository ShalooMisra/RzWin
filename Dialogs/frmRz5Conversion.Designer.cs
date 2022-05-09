namespace RzInterfaceWin
{
    partial class frmRz5Conversion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRz5Conversion));
            this.fPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.cmdPrep = new System.Windows.Forms.Button();
            this.bgw = new System.ComponentModel.BackgroundWorker();
            this.rtPrep = new System.Windows.Forms.RichTextBox();
            this.rtFinish = new System.Windows.Forms.RichTextBox();
            this.rtReSave = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cmdReSave = new System.Windows.Forms.Button();
            this.cmdReIndex = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fPanel
            // 
            this.fPanel.AutoScroll = true;
            this.fPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.fPanel.Location = new System.Drawing.Point(13, 131);
            this.fPanel.Name = "fPanel";
            this.fPanel.Size = new System.Drawing.Size(727, 260);
            this.fPanel.TabIndex = 0;
            this.fPanel.WrapContents = false;
            // 
            // cmdPrep
            // 
            this.cmdPrep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPrep.Location = new System.Drawing.Point(12, 397);
            this.cmdPrep.Name = "cmdPrep";
            this.cmdPrep.Size = new System.Drawing.Size(728, 29);
            this.cmdPrep.TabIndex = 1;
            this.cmdPrep.Text = "Convert";
            this.cmdPrep.UseVisualStyleBackColor = true;
            this.cmdPrep.Click += new System.EventHandler(this.cmdConvert_Click);
            // 
            // bgw
            // 
            this.bgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            this.bgw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted);
            // 
            // rtPrep
            // 
            this.rtPrep.Location = new System.Drawing.Point(12, 29);
            this.rtPrep.Name = "rtPrep";
            this.rtPrep.Size = new System.Drawing.Size(230, 96);
            this.rtPrep.TabIndex = 2;
            this.rtPrep.Text = "";
            // 
            // rtFinish
            // 
            this.rtFinish.Location = new System.Drawing.Point(262, 29);
            this.rtFinish.Name = "rtFinish";
            this.rtFinish.Size = new System.Drawing.Size(229, 96);
            this.rtFinish.TabIndex = 3;
            this.rtFinish.Text = "";
            // 
            // rtReSave
            // 
            this.rtReSave.Location = new System.Drawing.Point(511, 29);
            this.rtReSave.Name = "rtReSave";
            this.rtReSave.Size = new System.Drawing.Size(229, 67);
            this.rtReSave.TabIndex = 4;
            this.rtReSave.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Rz5 Conversion Preparation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(507, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(237, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Rz5 Conversion ReSave Ord";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(258, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Rz5 Conversion Finish Up";
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cmdReSave
            // 
            this.cmdReSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdReSave.Location = new System.Drawing.Point(511, 96);
            this.cmdReSave.Name = "cmdReSave";
            this.cmdReSave.Size = new System.Drawing.Size(158, 29);
            this.cmdReSave.TabIndex = 9;
            this.cmdReSave.Text = "ReSave";
            this.cmdReSave.UseVisualStyleBackColor = true;
            this.cmdReSave.Click += new System.EventHandler(this.cmdReSave_Click);
            // 
            // cmdReIndex
            // 
            this.cmdReIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdReIndex.Location = new System.Drawing.Point(675, 96);
            this.cmdReIndex.Name = "cmdReIndex";
            this.cmdReIndex.Size = new System.Drawing.Size(65, 29);
            this.cmdReIndex.TabIndex = 10;
            this.cmdReIndex.Text = "Index";
            this.cmdReIndex.UseVisualStyleBackColor = true;
            this.cmdReIndex.Click += new System.EventHandler(this.cmdReIndex_Click);
            // 
            // frmRz5Conversion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(752, 435);
            this.Controls.Add(this.cmdReIndex);
            this.Controls.Add(this.cmdReSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtReSave);
            this.Controls.Add(this.rtFinish);
            this.Controls.Add(this.rtPrep);
            this.Controls.Add(this.cmdPrep);
            this.Controls.Add(this.fPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmRz5Conversion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rz5 Conversion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel fPanel;
        private System.Windows.Forms.Button cmdPrep;
        private System.ComponentModel.BackgroundWorker bgw;
        private System.Windows.Forms.RichTextBox rtPrep;
        private System.Windows.Forms.RichTextBox rtFinish;
        private System.Windows.Forms.RichTextBox rtReSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button cmdReSave;
        private System.Windows.Forms.Button cmdReIndex;
    }
}