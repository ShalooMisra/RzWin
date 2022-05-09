//namespace Rz4.VirtualFloor
//{
//    partial class ActivityReport
//    {
//        /// <summary> 
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary> 
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Component Designer generated code

//        /// <summary> 
//        /// Required method for Designer support - do not modify 
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.components = new System.ComponentModel.Container();
//            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActivityReport));
//            this.picActivity = new System.Windows.Forms.PictureBox();
//            this.cmdGo = new System.Windows.Forms.Button();
//            this.il = new System.Windows.Forms.ImageList(this.components);
//            this.optAll = new System.Windows.Forms.RadioButton();
//            this.optSelected = new System.Windows.Forms.RadioButton();
//            this.lvActivityTypes = new System.Windows.Forms.ListView();
//            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
//            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
//            this.lv = new System.Windows.Forms.ListView();
//            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
//            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
//            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
//            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
//            this.throb = new NewMethod.nThrobber();
//            this.bg = new System.ComponentModel.BackgroundWorker();
//            ((System.ComponentModel.ISupportInitialize)(this.picActivity)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // picActivity
//            // 
//            this.picActivity.Location = new System.Drawing.Point(3, 3);
//            this.picActivity.Name = "picActivity";
//            this.picActivity.Size = new System.Drawing.Size(247, 207);
//            this.picActivity.TabIndex = 0;
//            this.picActivity.TabStop = false;
//            // 
//            // cmdGo
//            // 
//            this.cmdGo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
//            this.cmdGo.ImageKey = "refresh";
//            this.cmdGo.ImageList = this.il;
//            this.cmdGo.Location = new System.Drawing.Point(60, 216);
//            this.cmdGo.Name = "cmdGo";
//            this.cmdGo.Size = new System.Drawing.Size(130, 49);
//            this.cmdGo.TabIndex = 2;
//            this.cmdGo.Text = "Report";
//            this.cmdGo.UseVisualStyleBackColor = true;
//            this.cmdGo.Click += new System.EventHandler(this.cmdGo_Click);
//            // 
//            // il
//            // 
//            this.il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il.ImageStream")));
//            this.il.TransparentColor = System.Drawing.Color.Magenta;
//            this.il.Images.SetKeyName(0, "refresh");
//            // 
//            // optAll
//            // 
//            this.optAll.AutoSize = true;
//            this.optAll.Checked = true;
//            this.optAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.optAll.Location = new System.Drawing.Point(13, 271);
//            this.optAll.Name = "optAll";
//            this.optAll.Size = new System.Drawing.Size(176, 24);
//            this.optAll.TabIndex = 3;
//            this.optAll.TabStop = true;
//            this.optAll.Text = "All Activity On <date>";
//            this.optAll.UseVisualStyleBackColor = true;
//            // 
//            // optSelected
//            // 
//            this.optSelected.AutoSize = true;
//            this.optSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.optSelected.Location = new System.Drawing.Point(13, 301);
//            this.optSelected.Name = "optSelected";
//            this.optSelected.Size = new System.Drawing.Size(189, 24);
//            this.optSelected.TabIndex = 4;
//            this.optSelected.Text = "Selected Activity Types";
//            this.optSelected.UseVisualStyleBackColor = true;
//            // 
//            // lvActivityTypes
//            // 
//            this.lvActivityTypes.CheckBoxes = true;
//            this.lvActivityTypes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
//            this.columnHeader1,
//            this.columnHeader2});
//            this.lvActivityTypes.Location = new System.Drawing.Point(3, 336);
//            this.lvActivityTypes.Name = "lvActivityTypes";
//            this.lvActivityTypes.Size = new System.Drawing.Size(247, 237);
//            this.lvActivityTypes.TabIndex = 5;
//            this.lvActivityTypes.UseCompatibleStateImageBehavior = false;
//            this.lvActivityTypes.View = System.Windows.Forms.View.Details;
//            // 
//            // columnHeader1
//            // 
//            this.columnHeader1.Text = "Type";
//            this.columnHeader1.Width = 136;
//            // 
//            // columnHeader2
//            // 
//            this.columnHeader2.Text = "Count";
//            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
//            this.columnHeader2.Width = 83;
//            // 
//            // lv
//            // 
//            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
//            this.columnHeader3,
//            this.columnHeader4,
//            this.columnHeader5,
//            this.columnHeader6});
//            this.lv.Location = new System.Drawing.Point(258, 6);
//            this.lv.Name = "lv";
//            this.lv.Size = new System.Drawing.Size(778, 595);
//            this.lv.TabIndex = 6;
//            this.lv.UseCompatibleStateImageBehavior = false;
//            this.lv.View = System.Windows.Forms.View.Details;
//            // 
//            // columnHeader3
//            // 
//            this.columnHeader3.Text = "Time";
//            // 
//            // columnHeader4
//            // 
//            this.columnHeader4.Text = "Activity";
//            this.columnHeader4.Width = 162;
//            // 
//            // columnHeader5
//            // 
//            this.columnHeader5.Text = "Description";
//            this.columnHeader5.Width = 459;
//            // 
//            // columnHeader6
//            // 
//            this.columnHeader6.Text = "Value";
//            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
//            this.columnHeader6.Width = 82;
//            // 
//            // throb
//            // 
//            this.throb.BackColor = System.Drawing.Color.Maroon;
//            this.throb.Location = new System.Drawing.Point(201, 225);
//            this.throb.Name = "throb";
//            this.throb.Size = new System.Drawing.Size(49, 39);
//            this.throb.TabIndex = 7;
//            this.throb.UseParentBackColor = false;
//            // 
//            // bg
//            // 
//            this.bg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_DoWork);
//            this.bg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_RunWorkerCompleted);
//            // 
//            // ActivityReport
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.BackColor = System.Drawing.Color.White;
//            this.Controls.Add(this.throb);
//            this.Controls.Add(this.lv);
//            this.Controls.Add(this.lvActivityTypes);
//            this.Controls.Add(this.optSelected);
//            this.Controls.Add(this.optAll);
//            this.Controls.Add(this.cmdGo);
//            this.Controls.Add(this.picActivity);
//            this.Name = "ActivityReport";
//            this.Size = new System.Drawing.Size(1094, 602);
//            this.Resize += new System.EventHandler(this.ActivityReport_Resize);
//            ((System.ComponentModel.ISupportInitialize)(this.picActivity)).EndInit();
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }

//        #endregion

//        private System.Windows.Forms.PictureBox picActivity;
//        private System.Windows.Forms.Button cmdGo;
//        private System.Windows.Forms.ImageList il;
//        private System.Windows.Forms.RadioButton optAll;
//        private System.Windows.Forms.RadioButton optSelected;
//        private System.Windows.Forms.ListView lvActivityTypes;
//        private System.Windows.Forms.ColumnHeader columnHeader1;
//        private System.Windows.Forms.ColumnHeader columnHeader2;
//        private System.Windows.Forms.ListView lv;
//        private System.Windows.Forms.ColumnHeader columnHeader3;
//        private System.Windows.Forms.ColumnHeader columnHeader4;
//        private System.Windows.Forms.ColumnHeader columnHeader5;
//        private System.Windows.Forms.ColumnHeader columnHeader6;
//        private NewMethod.nThrobber throb;
//        private System.ComponentModel.BackgroundWorker bg;

//    }
//}
