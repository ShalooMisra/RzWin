namespace Rz5.Win.Views
{
    partial class ViewFolder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewFolder));
            this.cmdNewTask = new System.Windows.Forms.Button();
            this.optList = new System.Windows.Forms.RadioButton();
            this.optScreens = new System.Windows.Forms.RadioButton();
            this.lv = new NewMethod.nList();
            this.cmdClose = new System.Windows.Forms.Button();
            this.tl = new Rz5.Win.Controls.TaskList();
            this.lblCaption = new System.Windows.Forms.Label();
            this.pFolder = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pFolder)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdNewTask
            // 
            this.cmdNewTask.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNewTask.Location = new System.Drawing.Point(75, 36);
            this.cmdNewTask.Name = "cmdNewTask";
            this.cmdNewTask.Size = new System.Drawing.Size(127, 28);
            this.cmdNewTask.TabIndex = 8;
            this.cmdNewTask.Text = "New Task";
            this.cmdNewTask.UseVisualStyleBackColor = true;
            this.cmdNewTask.Click += new System.EventHandler(this.cmdNewTask_Click);
            // 
            // optList
            // 
            this.optList.AutoSize = true;
            this.optList.Checked = true;
            this.optList.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optList.Location = new System.Drawing.Point(287, 33);
            this.optList.Name = "optList";
            this.optList.Size = new System.Drawing.Size(89, 19);
            this.optList.TabIndex = 42;
            this.optList.TabStop = true;
            this.optList.Text = "View As List";
            this.optList.UseVisualStyleBackColor = true;
            this.optList.Click += new System.EventHandler(this.optList_Click);
            // 
            // optScreens
            // 
            this.optScreens.AutoSize = true;
            this.optScreens.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optScreens.Location = new System.Drawing.Point(287, 49);
            this.optScreens.Name = "optScreens";
            this.optScreens.Size = new System.Drawing.Size(112, 19);
            this.optScreens.TabIndex = 43;
            this.optScreens.Text = "View As Screens";
            this.optScreens.UseVisualStyleBackColor = true;
            this.optScreens.Click += new System.EventHandler(this.optList_Click);
            // 
            // lv
            // 
            this.lv.AddCaption = "Add New";
            this.lv.AllowActions = true;
            this.lv.AllowAdd = false;
            this.lv.AllowDelete = true;
            this.lv.AllowDeleteAlways = false;
            this.lv.AllowDrop = true;
            this.lv.AllowOnlyOpenDelete = false;
            this.lv.AlternateConnection = null;
            this.lv.Caption = "";
            this.lv.CurrentTemplate = null;
            this.lv.ExtraClassInfo = "";
            this.lv.Location = new System.Drawing.Point(9, 74);
            this.lv.MultiSelect = true;
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(820, 332);
            this.lv.SuppressSelectionChanged = false;
            this.lv.TabIndex = 44;
            this.lv.zz_OpenColumnMenu = false;
            this.lv.zz_OrderLineType = "";
            this.lv.zz_ShowAutoRefresh = true;
            this.lv.zz_ShowUnlimited = true;
            this.lv.AboutToThrow += new Core.ShowHandler(this.lv_AboutToThrow);
            this.lv.DragDrop += new NewMethod.nListItemDragDropHandler(this.lv_DragDrop);
            this.lv.DragOver += new NewMethod.nListItemDragDropHandler(this.lv_DragOver);
            // 
            // cmdClose
            // 
            this.cmdClose.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.Location = new System.Drawing.Point(208, 36);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(73, 28);
            this.cmdClose.TabIndex = 45;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // tl
            // 
            this.tl.BackColor = System.Drawing.Color.White;
            this.tl.Location = new System.Drawing.Point(9, 70);
            this.tl.Name = "tl";
            this.tl.RemainThisSize = false;
            this.tl.Size = new System.Drawing.Size(925, 167);
            this.tl.TabIndex = 6;
            this.tl.SizeChanged += new System.EventHandler(this.tl_SizeChanged);
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.Location = new System.Drawing.Point(71, 3);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(64, 23);
            this.lblCaption.TabIndex = 4;
            this.lblCaption.Text = "Folder:";
            // 
            // pFolder
            // 
            this.pFolder.Image = ((System.Drawing.Image)(resources.GetObject("pFolder.Image")));
            this.pFolder.Location = new System.Drawing.Point(3, 3);
            this.pFolder.Name = "pFolder";
            this.pFolder.Size = new System.Drawing.Size(62, 61);
            this.pFolder.TabIndex = 46;
            this.pFolder.TabStop = false;
            // 
            // ViewFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pFolder);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.lv);
            this.Controls.Add(this.optScreens);
            this.Controls.Add(this.optList);
            this.Controls.Add(this.cmdNewTask);
            this.Controls.Add(this.tl);
            this.Controls.Add(this.lblCaption);
            this.Name = "ViewFolder";
            this.Size = new System.Drawing.Size(939, 508);
            this.Resize += new System.EventHandler(this.ViewFolder_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pFolder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.TaskList tl;
        private System.Windows.Forms.Button cmdNewTask;
        private System.Windows.Forms.RadioButton optList;
        private System.Windows.Forms.RadioButton optScreens;
        private NewMethod.nList lv;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.PictureBox pFolder;
    }
}
