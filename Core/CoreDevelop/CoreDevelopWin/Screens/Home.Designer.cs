namespace CoreDevelopWin.Screens
{
    partial class Home
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
            this.lvSys = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mnuSystem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lblSysCap = new System.Windows.Forms.Label();
            this.cmdLoad = new System.Windows.Forms.Button();
            this.lblClassesCap = new System.Windows.Forms.Label();
            this.lvClasses = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mnuClass = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblVariableCap = new System.Windows.Forms.Label();
            this.lvVars = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mnuProp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdWrite = new System.Windows.Forms.Button();
            this.cmdWriteSys = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdImportNM = new System.Windows.Forms.Button();
            this.cmdNew = new System.Windows.Forms.Button();
            this.bgw = new System.ComponentModel.BackgroundWorker();
            this.lblLoad = new System.Windows.Forms.Label();
            this.cmdWriteAll = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdAddProp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lvRelates = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mnuRelate = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.lblParse = new System.Windows.Forms.LinkLabel();
            this.mnuSystem.SuspendLayout();
            this.mnuClass.SuspendLayout();
            this.mnuProp.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.mnuRelate.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvSys
            // 
            this.lvSys.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvSys.ContextMenuStrip = this.mnuSystem;
            this.lvSys.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvSys.FullRowSelect = true;
            this.lvSys.GridLines = true;
            this.lvSys.HideSelection = false;
            this.lvSys.Location = new System.Drawing.Point(3, 28);
            this.lvSys.Name = "lvSys";
            this.lvSys.Size = new System.Drawing.Size(265, 436);
            this.lvSys.TabIndex = 0;
            this.lvSys.UseCompatibleStateImageBehavior = false;
            this.lvSys.View = System.Windows.Forms.View.Details;
            this.lvSys.SelectedIndexChanged += new System.EventHandler(this.lvSys_SelectedIndexChanged);
            this.lvSys.Click += new System.EventHandler(this.lvSys_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 183;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Classes";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 71;
            // 
            // mnuSystem
            // 
            this.mnuSystem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.mnuSystem.Name = "mnuClass";
            this.mnuSystem.Size = new System.Drawing.Size(104, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.toolStripMenuItem1.Text = "&Open";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // lblSysCap
            // 
            this.lblSysCap.AutoSize = true;
            this.lblSysCap.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSysCap.Location = new System.Drawing.Point(2, 6);
            this.lblSysCap.Name = "lblSysCap";
            this.lblSysCap.Size = new System.Drawing.Size(62, 19);
            this.lblSysCap.TabIndex = 1;
            this.lblSysCap.Text = "Systems";
            // 
            // cmdLoad
            // 
            this.cmdLoad.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLoad.Location = new System.Drawing.Point(3, 470);
            this.cmdLoad.Name = "cmdLoad";
            this.cmdLoad.Size = new System.Drawing.Size(199, 33);
            this.cmdLoad.TabIndex = 2;
            this.cmdLoad.Text = "Load/Add Existing";
            this.cmdLoad.UseVisualStyleBackColor = true;
            this.cmdLoad.Click += new System.EventHandler(this.cmdLoad_Click);
            // 
            // lblClassesCap
            // 
            this.lblClassesCap.AutoSize = true;
            this.lblClassesCap.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassesCap.Location = new System.Drawing.Point(270, 6);
            this.lblClassesCap.Name = "lblClassesCap";
            this.lblClassesCap.Size = new System.Drawing.Size(59, 19);
            this.lblClassesCap.TabIndex = 4;
            this.lblClassesCap.Text = "Classes";
            // 
            // lvClasses
            // 
            this.lvClasses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader10});
            this.lvClasses.ContextMenuStrip = this.mnuClass;
            this.lvClasses.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvClasses.FullRowSelect = true;
            this.lvClasses.GridLines = true;
            this.lvClasses.HideSelection = false;
            this.lvClasses.Location = new System.Drawing.Point(274, 28);
            this.lvClasses.Name = "lvClasses";
            this.lvClasses.Size = new System.Drawing.Size(308, 436);
            this.lvClasses.TabIndex = 3;
            this.lvClasses.UseCompatibleStateImageBehavior = false;
            this.lvClasses.View = System.Windows.Forms.View.Details;
            this.lvClasses.SelectedIndexChanged += new System.EventHandler(this.lvClasses_SelectedIndexChanged);
            this.lvClasses.Click += new System.EventHandler(this.lvClasses_Click);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            this.columnHeader3.Width = 168;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Vars";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader4.Width = 65;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Relates";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader10.Width = 65;
            // 
            // mnuClass
            // 
            this.mnuClass.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.mnuClass.Name = "mnuClass";
            this.mnuClass.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "&Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // lblVariableCap
            // 
            this.lblVariableCap.AutoSize = true;
            this.lblVariableCap.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVariableCap.Location = new System.Drawing.Point(584, 6);
            this.lblVariableCap.Name = "lblVariableCap";
            this.lblVariableCap.Size = new System.Drawing.Size(69, 19);
            this.lblVariableCap.TabIndex = 6;
            this.lblVariableCap.Text = "Variables";
            // 
            // lvVars
            // 
            this.lvVars.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5});
            this.lvVars.ContextMenuStrip = this.mnuProp;
            this.lvVars.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvVars.FullRowSelect = true;
            this.lvVars.GridLines = true;
            this.lvVars.HideSelection = false;
            this.lvVars.Location = new System.Drawing.Point(588, 28);
            this.lvVars.Name = "lvVars";
            this.lvVars.Size = new System.Drawing.Size(228, 436);
            this.lvVars.TabIndex = 5;
            this.lvVars.UseCompatibleStateImageBehavior = false;
            this.lvVars.View = System.Windows.Forms.View.Details;
            this.lvVars.SelectedIndexChanged += new System.EventHandler(this.lvVars_SelectedIndexChanged);
            this.lvVars.Click += new System.EventHandler(this.lvVars_Click);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Name";
            this.columnHeader5.Width = 219;
            // 
            // mnuProp
            // 
            this.mnuProp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.mnuProp.Name = "mnuClass";
            this.mnuProp.Size = new System.Drawing.Size(108, 26);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem2.Text = "&Delete";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // cmdWrite
            // 
            this.cmdWrite.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdWrite.Location = new System.Drawing.Point(6, 56);
            this.cmdWrite.Name = "cmdWrite";
            this.cmdWrite.Size = new System.Drawing.Size(412, 33);
            this.cmdWrite.TabIndex = 8;
            this.cmdWrite.Text = "Write";
            this.cmdWrite.UseVisualStyleBackColor = true;
            this.cmdWrite.Click += new System.EventHandler(this.cmdWrite_Click);
            // 
            // cmdWriteSys
            // 
            this.cmdWriteSys.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdWriteSys.Location = new System.Drawing.Point(6, 17);
            this.cmdWriteSys.Name = "cmdWriteSys";
            this.cmdWriteSys.Size = new System.Drawing.Size(412, 33);
            this.cmdWriteSys.TabIndex = 10;
            this.cmdWriteSys.Text = "Write Sys";
            this.cmdWriteSys.UseVisualStyleBackColor = true;
            this.cmdWriteSys.Click += new System.EventHandler(this.cmdWriteSys_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Enabled = false;
            this.cmdAdd.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAdd.Location = new System.Drawing.Point(274, 470);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(308, 33);
            this.cmdAdd.TabIndex = 11;
            this.cmdAdd.Text = "Add Class";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdImportNM
            // 
            this.cmdImportNM.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdImportNM.Location = new System.Drawing.Point(274, 509);
            this.cmdImportNM.Name = "cmdImportNM";
            this.cmdImportNM.Size = new System.Drawing.Size(268, 33);
            this.cmdImportNM.TabIndex = 15;
            this.cmdImportNM.Text = "Import From NM";
            this.cmdImportNM.UseVisualStyleBackColor = true;
            this.cmdImportNM.Visible = false;
            this.cmdImportNM.Click += new System.EventHandler(this.cmdImportNM_Click);
            // 
            // cmdNew
            // 
            this.cmdNew.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNew.Location = new System.Drawing.Point(208, 470);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(60, 33);
            this.cmdNew.TabIndex = 16;
            this.cmdNew.Text = "New";
            this.cmdNew.UseVisualStyleBackColor = true;
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // bgw
            // 
            this.bgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            this.bgw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted);
            // 
            // lblLoad
            // 
            this.lblLoad.AutoSize = true;
            this.lblLoad.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoad.ForeColor = System.Drawing.Color.DarkRed;
            this.lblLoad.Location = new System.Drawing.Point(182, 3);
            this.lblLoad.Name = "lblLoad";
            this.lblLoad.Size = new System.Drawing.Size(86, 23);
            this.lblLoad.TabIndex = 18;
            this.lblLoad.Text = "Loading...";
            this.lblLoad.Visible = false;
            // 
            // cmdWriteAll
            // 
            this.cmdWriteAll.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdWriteAll.Location = new System.Drawing.Point(6, 95);
            this.cmdWriteAll.Name = "cmdWriteAll";
            this.cmdWriteAll.Size = new System.Drawing.Size(412, 33);
            this.cmdWriteAll.TabIndex = 17;
            this.cmdWriteAll.Text = "Write All";
            this.cmdWriteAll.UseVisualStyleBackColor = true;
            this.cmdWriteAll.Click += new System.EventHandler(this.cmdWriteAll_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdWriteSys);
            this.groupBox1.Controls.Add(this.cmdWrite);
            this.groupBox1.Controls.Add(this.cmdWriteAll);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 12F);
            this.groupBox1.Location = new System.Drawing.Point(822, 366);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 137);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Write";
            // 
            // cmdAddProp
            // 
            this.cmdAddProp.Enabled = false;
            this.cmdAddProp.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddProp.Location = new System.Drawing.Point(588, 470);
            this.cmdAddProp.Name = "cmdAddProp";
            this.cmdAddProp.Size = new System.Drawing.Size(228, 33);
            this.cmdAddProp.TabIndex = 21;
            this.cmdAddProp.Text = "Add Prop/Relate";
            this.cmdAddProp.UseVisualStyleBackColor = true;
            this.cmdAddProp.Click += new System.EventHandler(this.cmdAddProp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(818, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 19);
            this.label1.TabIndex = 23;
            this.label1.Text = "Relates";
            // 
            // lvRelates
            // 
            this.lvRelates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lvRelates.ContextMenuStrip = this.mnuRelate;
            this.lvRelates.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvRelates.FullRowSelect = true;
            this.lvRelates.GridLines = true;
            this.lvRelates.HideSelection = false;
            this.lvRelates.Location = new System.Drawing.Point(822, 28);
            this.lvRelates.Name = "lvRelates";
            this.lvRelates.Size = new System.Drawing.Size(424, 332);
            this.lvRelates.TabIndex = 22;
            this.lvRelates.UseCompatibleStateImageBehavior = false;
            this.lvRelates.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Name";
            this.columnHeader6.Width = 148;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Type";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Reverse";
            this.columnHeader8.Width = 147;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Type";
            // 
            // mnuRelate
            // 
            this.mnuRelate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3});
            this.mnuRelate.Name = "mnuClass";
            this.mnuRelate.Size = new System.Drawing.Size(153, 48);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem3.Text = "&Delete";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // lblParse
            // 
            this.lblParse.AutoSize = true;
            this.lblParse.Location = new System.Drawing.Point(1212, 6);
            this.lblParse.Name = "lblParse";
            this.lblParse.Size = new System.Drawing.Size(34, 13);
            this.lblParse.TabIndex = 24;
            this.lblParse.TabStop = true;
            this.lblParse.Text = "Parse";
            this.lblParse.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblParse_LinkClicked);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblParse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvRelates);
            this.Controls.Add(this.cmdAddProp);
            this.Controls.Add(this.lblLoad);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdImportNM);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.lvVars);
            this.Controls.Add(this.cmdNew);
            this.Controls.Add(this.lblClassesCap);
            this.Controls.Add(this.lblVariableCap);
            this.Controls.Add(this.lvClasses);
            this.Controls.Add(this.cmdLoad);
            this.Controls.Add(this.lblSysCap);
            this.Controls.Add(this.lvSys);
            this.Name = "Home";
            this.Size = new System.Drawing.Size(1395, 557);
            this.mnuSystem.ResumeLayout(false);
            this.mnuClass.ResumeLayout(false);
            this.mnuProp.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.mnuRelate.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvSys;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label lblSysCap;
        private System.Windows.Forms.Button cmdLoad;
        private System.Windows.Forms.Label lblClassesCap;
        private System.Windows.Forms.ListView lvClasses;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label lblVariableCap;
        private System.Windows.Forms.ListView lvVars;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button cmdWrite;
        private System.Windows.Forms.Button cmdWriteSys;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.ContextMenuStrip mnuClass;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Button cmdImportNM;
        private System.Windows.Forms.Button cmdNew;
        private System.Windows.Forms.ContextMenuStrip mnuSystem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.ComponentModel.BackgroundWorker bgw;
        private System.Windows.Forms.Label lblLoad;
        private System.Windows.Forms.Button cmdWriteAll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdAddProp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvRelates;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ContextMenuStrip mnuProp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ContextMenuStrip mnuRelate;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.LinkLabel lblParse;
    }
}
