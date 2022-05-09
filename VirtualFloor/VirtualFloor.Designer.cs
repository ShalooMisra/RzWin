//namespace Rz4.VirtualFloor
//{
//    partial class VirtualFloor
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
//                CompleteUnload();
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
//            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VirtualFloor));
//            this.pFloor = new System.Windows.Forms.Panel();
//            this.cmdSave = new System.Windows.Forms.Button();
//            this.IM24 = new System.Windows.Forms.ImageList(this.components);
//            this.tmrCheck = new System.Windows.Forms.Timer(this.components);
//            this.tmrLine = new System.Windows.Forms.Timer(this.components);
//            this.cmdAdd = new System.Windows.Forms.Button();
//            this.SuspendLayout();
//            // 
//            // pFloor
//            // 
//            this.pFloor.BackColor = System.Drawing.Color.White;
//            this.pFloor.Location = new System.Drawing.Point(145, 9);
//            this.pFloor.Name = "pFloor";
//            this.pFloor.Size = new System.Drawing.Size(711, 755);
//            this.pFloor.TabIndex = 0;
//            // 
//            // cmdSave
//            // 
//            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
//            this.cmdSave.ImageKey = "Save";
//            this.cmdSave.ImageList = this.IM24;
//            this.cmdSave.Location = new System.Drawing.Point(3, 3);
//            this.cmdSave.Name = "cmdSave";
//            this.cmdSave.Size = new System.Drawing.Size(136, 49);
//            this.cmdSave.TabIndex = 2;
//            this.cmdSave.Text = "Save This Floor Layout";
//            this.cmdSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
//            this.cmdSave.UseVisualStyleBackColor = true;
//            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
//            // 
//            // IM24
//            // 
//            this.IM24.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IM24.ImageStream")));
//            this.IM24.TransparentColor = System.Drawing.Color.Fuchsia;
//            this.IM24.Images.SetKeyName(0, "Clip");
//            this.IM24.Images.SetKeyName(1, "Note");
//            this.IM24.Images.SetKeyName(2, "Save");
//            this.IM24.Images.SetKeyName(3, "Delete");
//            this.IM24.Images.SetKeyName(4, "SaveExit");
//            this.IM24.Images.SetKeyName(5, "edit_menu");
//            this.IM24.Images.SetKeyName(6, "Add");
//            // 
//            // tmrCheck
//            // 
//            this.tmrCheck.Interval = 30000;
//            this.tmrCheck.Tick += new System.EventHandler(this.tmrCheck_Tick);
//            // 
//            // tmrLine
//            // 
//            this.tmrLine.Interval = 1000;
//            this.tmrLine.Tick += new System.EventHandler(this.tmrLine_Tick);
//            // 
//            // cmdAdd
//            // 
//            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
//            this.cmdAdd.ImageKey = "Add";
//            this.cmdAdd.ImageList = this.IM24;
//            this.cmdAdd.Location = new System.Drawing.Point(3, 58);
//            this.cmdAdd.Name = "cmdAdd";
//            this.cmdAdd.Size = new System.Drawing.Size(136, 49);
//            this.cmdAdd.TabIndex = 3;
//            this.cmdAdd.Text = "Add A Desk";
//            this.cmdAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
//            this.cmdAdd.UseVisualStyleBackColor = true;
//            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
//            // 
//            // VirtualFloor
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.Controls.Add(this.cmdAdd);
//            this.Controls.Add(this.cmdSave);
//            this.Controls.Add(this.pFloor);
//            this.Name = "VirtualFloor";
//            this.Size = new System.Drawing.Size(874, 786);
//            this.Resize += new System.EventHandler(this.VirtualFloor_Resize);
//            this.ResumeLayout(false);

//        }

//        #endregion

//        private System.Windows.Forms.Panel pFloor;
//        private System.Windows.Forms.Button cmdSave;
//        private System.Windows.Forms.Timer tmrCheck;
//        private System.Windows.Forms.Timer tmrLine;
//        public System.Windows.Forms.ImageList IM24;
//        private System.Windows.Forms.Button cmdAdd;
//    }
//}
