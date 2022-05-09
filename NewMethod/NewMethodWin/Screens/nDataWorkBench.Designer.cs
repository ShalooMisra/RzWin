namespace NewMethod
{
    partial class nDataWorkBench
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
            this.components = new System.ComponentModel.Container();
            this.gbLeft = new System.Windows.Forms.GroupBox();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.cmdAddFile = new System.Windows.Forms.Button();
            this.lvTables = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.mnuTables = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCombine = new System.Windows.Forms.ToolStripMenuItem();
            this.throb = new NewMethod.nThrobber();
            this.bg = new System.ComponentModel.BackgroundWorker();
            this.sb = new NewMethod.nStatusBox();
            this.dv = new NewMethod.nDataView();
            this.bgCombine = new System.ComponentModel.BackgroundWorker();
            this.gbLeft.SuspendLayout();
            this.mnuTables.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLeft
            // 
            this.gbLeft.Controls.Add(this.pb);
            this.gbLeft.Controls.Add(this.cmdAddFile);
            this.gbLeft.Controls.Add(this.lvTables);
            this.gbLeft.Controls.Add(this.throb);
            this.gbLeft.Location = new System.Drawing.Point(4, 6);
            this.gbLeft.Name = "gbLeft";
            this.gbLeft.Size = new System.Drawing.Size(160, 565);
            this.gbLeft.TabIndex = 0;
            this.gbLeft.TabStop = false;
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(7, 14);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(112, 14);
            this.pb.TabIndex = 3;
            // 
            // cmdAddFile
            // 
            this.cmdAddFile.Location = new System.Drawing.Point(7, 37);
            this.cmdAddFile.Name = "cmdAddFile";
            this.cmdAddFile.Size = new System.Drawing.Size(147, 32);
            this.cmdAddFile.TabIndex = 1;
            this.cmdAddFile.Text = "Add A File";
            this.cmdAddFile.UseVisualStyleBackColor = true;
            this.cmdAddFile.Click += new System.EventHandler(this.cmdAddFile_Click);
            // 
            // lvTables
            // 
            this.lvTables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvTables.ContextMenuStrip = this.mnuTables;
            this.lvTables.FullRowSelect = true;
            this.lvTables.Location = new System.Drawing.Point(9, 75);
            this.lvTables.Name = "lvTables";
            this.lvTables.Size = new System.Drawing.Size(145, 479);
            this.lvTables.TabIndex = 0;
            this.lvTables.UseCompatibleStateImageBehavior = false;
            this.lvTables.View = System.Windows.Forms.View.Details;
            this.lvTables.DoubleClick += new System.EventHandler(this.lvTables_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 77;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Count";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 50;
            // 
            // mnuTables
            // 
            this.mnuTables.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCombine});
            this.mnuTables.Name = "mnuTables";
            this.mnuTables.Size = new System.Drawing.Size(124, 26);
            // 
            // mnuCombine
            // 
            this.mnuCombine.Name = "mnuCombine";
            this.mnuCombine.Size = new System.Drawing.Size(123, 22);
            this.mnuCombine.Text = "Combine";
            this.mnuCombine.Click += new System.EventHandler(this.mnuCombine_Click);
            // 
            // throb
            // 
            this.throb.BackColor = System.Drawing.Color.White;
            this.throb.Location = new System.Drawing.Point(125, 10);
            this.throb.Name = "throb";
            this.throb.Size = new System.Drawing.Size(27, 25);
            this.throb.TabIndex = 2;
            this.throb.UseParentBackColor = false;
            // 
            // bg
            // 
            this.bg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_DoWork);
            this.bg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_RunWorkerCompleted);
            // 
            // sb
            // 
            this.sb.Location = new System.Drawing.Point(6, 580);
            this.sb.Name = "sb";
            this.sb.Size = new System.Drawing.Size(738, 75);
            this.sb.TabIndex = 2;
            this.sb.Text = "";
            // 
            // dv
            // 
            this.dv.AlwaysDisableAccept = false;
            this.dv.BackColor = System.Drawing.Color.White;
            this.dv.DisableAutoMatching = false;
            this.dv.HideOptions = true;
            this.dv.Location = new System.Drawing.Point(173, 10);
            this.dv.Name = "dv";
            this.dv.Size = new System.Drawing.Size(584, 561);
            this.dv.TabIndex = 1;
            // 
            // bgCombine
            // 
            this.bgCombine.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgCombine_DoWork);
            this.bgCombine.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgCombine_RunWorkerCompleted);
            // 
            // nDataWorkBench
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sb);
            this.Controls.Add(this.dv);
            this.Controls.Add(this.gbLeft);
            this.Name = "nDataWorkBench";
            this.Size = new System.Drawing.Size(758, 680);
            this.Resize += new System.EventHandler(this.nDataWorkBench_Resize);
            this.gbLeft.ResumeLayout(false);
            this.mnuTables.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLeft;
        private System.Windows.Forms.ListView lvTables;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private nDataView dv;
        private System.Windows.Forms.Button cmdAddFile;
        private nThrobber throb;
        private System.Windows.Forms.ProgressBar pb;
        private nStatusBox sb;
        private System.ComponentModel.BackgroundWorker bg;
        private System.Windows.Forms.ContextMenuStrip mnuTables;
        private System.Windows.Forms.ToolStripMenuItem mnuCombine;
        private System.ComponentModel.BackgroundWorker bgCombine;
    }
}
