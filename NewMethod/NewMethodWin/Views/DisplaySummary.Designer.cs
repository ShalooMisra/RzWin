namespace NewMethod.Grids
{
    partial class DisplaySummary
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
            this.lv = new System.Windows.Forms.ListView();
            this.pOptions = new System.Windows.Forms.Panel();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.sp = new System.Windows.Forms.SplitContainer();
            this.details = new NewMethod.nList();
            this.pOptions.SuspendLayout();
            this.sp.Panel1.SuspendLayout();
            this.sp.Panel2.SuspendLayout();
            this.sp.SuspendLayout();
            this.SuspendLayout();
            // 
            // lv
            // 
            this.lv.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv.FullRowSelect = true;
            this.lv.GridLines = true;
            this.lv.Location = new System.Drawing.Point(58, 12);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(452, 177);
            this.lv.TabIndex = 0;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lv_MouseDown);
            // 
            // pOptions
            // 
            this.pOptions.Controls.Add(this.cmdRefresh);
            this.pOptions.Location = new System.Drawing.Point(6, 5);
            this.pOptions.Name = "pOptions";
            this.pOptions.Size = new System.Drawing.Size(91, 418);
            this.pOptions.TabIndex = 1;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRefresh.Location = new System.Drawing.Point(8, 12);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(74, 34);
            this.cmdRefresh.TabIndex = 0;
            this.cmdRefresh.Text = "Refresh";
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // sp
            // 
            this.sp.Location = new System.Drawing.Point(119, 5);
            this.sp.Name = "sp";
            this.sp.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sp.Panel1
            // 
            this.sp.Panel1.Controls.Add(this.lv);
            // 
            // sp.Panel2
            // 
            this.sp.Panel2.Controls.Add(this.details);
            this.sp.Size = new System.Drawing.Size(610, 438);
            this.sp.SplitterDistance = 216;
            this.sp.TabIndex = 2;
            this.sp.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.sp_SplitterMoved);
            // 
            // details
            // 
            this.details.AddCaption = "Add New";
            this.details.AllowActions = true;
            this.details.AllowAdd = false;
            this.details.AllowDelete = true;
            this.details.AllowDeleteAlways = false;
            this.details.AllowDrop = true;
            this.details.AlternateConnection = null;
            this.details.Caption = "";
            this.details.CurrentTemplate = null;
            this.details.ExtraClassInfo = "";
            this.details.Location = new System.Drawing.Point(10, 7);
            this.details.MultiSelect = true;
            this.details.Name = "details";
            this.details.Size = new System.Drawing.Size(586, 191);
            this.details.SuppressSelectionChanged = false;
            this.details.TabIndex = 0;
            this.details.zz_OpenColumnMenu = false;
            this.details.zz_ShowAutoRefresh = true;
            this.details.zz_ShowUnlimited = true;
            // 
            // DisplaySummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.sp);
            this.Controls.Add(this.pOptions);
            this.Name = "DisplaySummary";
            this.Size = new System.Drawing.Size(746, 460);
            this.Resize += new System.EventHandler(this.DisplaySummary_Resize);
            this.pOptions.ResumeLayout(false);
            this.sp.Panel1.ResumeLayout(false);
            this.sp.Panel2.ResumeLayout(false);
            this.sp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.Panel pOptions;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.SplitContainer sp;
        private nList details;
    }
}
