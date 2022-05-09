namespace Rz5
{
    partial class Upload
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
            this.pb = new System.Windows.Forms.ProgressBar();
            this.sb = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmdUpload = new System.Windows.Forms.Button();
            this.lblCurrentFile = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.optAlternate = new System.Windows.Forms.RadioButton();
            this.optRecognin = new System.Windows.Forms.RadioButton();
            this.chkBeta = new System.Windows.Forms.CheckBox();
            this.bg = new System.ComponentModel.BackgroundWorker();
            this.lv = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.lvProject = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pMainstream = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.throb = new NewMethod.nThrobber();
            this.bgMcLovinClient = new System.ComponentModel.BackgroundWorker();
            this.sb.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pMainstream.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(3, 580);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(647, 23);
            this.pb.TabIndex = 1;
            // 
            // sb
            // 
            this.sb.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.sb.Location = new System.Drawing.Point(0, 606);
            this.sb.Name = "sb";
            this.sb.Size = new System.Drawing.Size(1154, 22);
            this.sb.TabIndex = 2;
            this.sb.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(54, 17);
            this.lblStatus.Text = "<status>";
            // 
            // cmdUpload
            // 
            this.cmdUpload.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdUpload.Location = new System.Drawing.Point(321, 51);
            this.cmdUpload.Name = "cmdUpload";
            this.cmdUpload.Size = new System.Drawing.Size(260, 59);
            this.cmdUpload.TabIndex = 4;
            this.cmdUpload.Text = "Upload";
            this.cmdUpload.UseVisualStyleBackColor = true;
            this.cmdUpload.Click += new System.EventHandler(this.cmdUpload_Click);
            // 
            // lblCurrentFile
            // 
            this.lblCurrentFile.AutoSize = true;
            this.lblCurrentFile.Location = new System.Drawing.Point(3, 564);
            this.lblCurrentFile.Name = "lblCurrentFile";
            this.lblCurrentFile.Size = new System.Drawing.Size(32, 13);
            this.lblCurrentFile.TabIndex = 7;
            this.lblCurrentFile.Text = "<file>";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.Controls.Add(this.optAlternate);
            this.panel3.Controls.Add(this.optRecognin);
            this.panel3.Location = new System.Drawing.Point(324, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(189, 21);
            this.panel3.TabIndex = 18;
            // 
            // optAlternate
            // 
            this.optAlternate.AutoSize = true;
            this.optAlternate.Location = new System.Drawing.Point(108, 3);
            this.optAlternate.Name = "optAlternate";
            this.optAlternate.Size = new System.Drawing.Size(67, 17);
            this.optAlternate.TabIndex = 1;
            this.optAlternate.Text = "Alternate";
            this.optAlternate.UseVisualStyleBackColor = true;
            // 
            // optRecognin
            // 
            this.optRecognin.AutoSize = true;
            this.optRecognin.Checked = true;
            this.optRecognin.Location = new System.Drawing.Point(3, 2);
            this.optRecognin.Name = "optRecognin";
            this.optRecognin.Size = new System.Drawing.Size(69, 17);
            this.optRecognin.TabIndex = 0;
            this.optRecognin.TabStop = true;
            this.optRecognin.Text = "Main Site";
            this.optRecognin.UseVisualStyleBackColor = true;
            // 
            // chkBeta
            // 
            this.chkBeta.AutoSize = true;
            this.chkBeta.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBeta.Location = new System.Drawing.Point(324, 5);
            this.chkBeta.Name = "chkBeta";
            this.chkBeta.Size = new System.Drawing.Size(58, 23);
            this.chkBeta.TabIndex = 21;
            this.chkBeta.Text = "Beta";
            this.chkBeta.UseVisualStyleBackColor = true;
            // 
            // bg
            // 
            this.bg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_DoWork);
            this.bg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_RunWorkerCompleted);
            // 
            // lv
            // 
            this.lv.CheckBoxes = true;
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lv.FullRowSelect = true;
            this.lv.GridLines = true;
            this.lv.Location = new System.Drawing.Point(3, 52);
            this.lv.MultiSelect = false;
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(247, 329);
            this.lv.TabIndex = 22;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Company";
            this.columnHeader1.Width = 222;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAll.Location = new System.Drawing.Point(3, 37);
            this.chkAll.Name = "chkAll";
            this.chkAll.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkAll.Size = new System.Drawing.Size(121, 17);
            this.chkAll.TabIndex = 23;
            this.chkAll.Text = "Check/UnCheck All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // lvProject
            // 
            this.lvProject.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lvProject.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvProject.Location = new System.Drawing.Point(0, 7);
            this.lvProject.Name = "lvProject";
            this.lvProject.Size = new System.Drawing.Size(315, 372);
            this.lvProject.TabIndex = 24;
            this.lvProject.UseCompatibleStateImageBehavior = false;
            this.lvProject.View = System.Windows.Forms.View.Details;
            this.lvProject.Click += new System.EventHandler(this.lvProject_Click);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Project";
            this.columnHeader2.Width = 304;
            // 
            // pMainstream
            // 
            this.pMainstream.Controls.Add(this.label1);
            this.pMainstream.Controls.Add(this.lv);
            this.pMainstream.Controls.Add(this.chkAll);
            this.pMainstream.Location = new System.Drawing.Point(324, 116);
            this.pMainstream.Name = "pMainstream";
            this.pMainstream.Size = new System.Drawing.Size(257, 384);
            this.pMainstream.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 32);
            this.label1.TabIndex = 24;
            this.label1.Text = "Mainstream SubProjects";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // throb
            // 
            this.throb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.throb.Location = new System.Drawing.Point(544, 17);
            this.throb.Margin = new System.Windows.Forms.Padding(4);
            this.throb.Name = "throb";
            this.throb.Size = new System.Drawing.Size(30, 27);
            this.throb.TabIndex = 26;
            this.throb.UseParentBackColor = false;
            // 
            // Upload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.throb);
            this.Controls.Add(this.pMainstream);
            this.Controls.Add(this.lvProject);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblCurrentFile);
            this.Controls.Add(this.cmdUpload);
            this.Controls.Add(this.sb);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.chkBeta);
            this.Name = "Upload";
            this.Size = new System.Drawing.Size(1154, 628);
            this.sb.ResumeLayout(false);
            this.sb.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pMainstream.ResumeLayout(false);
            this.pMainstream.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pb;
        private System.Windows.Forms.StatusStrip sb;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Button cmdUpload;
        private System.Windows.Forms.Label lblCurrentFile;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton optAlternate;
        private System.Windows.Forms.RadioButton optRecognin;
        private System.Windows.Forms.CheckBox chkBeta;
        private System.ComponentModel.BackgroundWorker bg;
        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.ListView lvProject;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Panel pMainstream;
        private System.Windows.Forms.Label label1;
        private NewMethod.nThrobber throb;
        private System.ComponentModel.BackgroundWorker bgMcLovinClient;
    }
}

