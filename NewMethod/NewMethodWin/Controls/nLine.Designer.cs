namespace NewMethod
{
    partial class nLine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(nLine));
            this.IM24 = new System.Windows.Forms.ImageList(this.components);
            this.cmdClip = new System.Windows.Forms.Button();
            this.cmdNotes = new System.Windows.Forms.Button();
            this.cmdSaveExit = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.pCommands = new System.Windows.Forms.Panel();
            this.pic = new System.Windows.Forms.PictureBox();
            this.picLeft = new System.Windows.Forms.PictureBox();
            this.picRight = new System.Windows.Forms.PictureBox();
            this.picTop = new System.Windows.Forms.PictureBox();
            this.picBottom = new System.Windows.Forms.PictureBox();
            this.imExpand = new System.Windows.Forms.ImageList(this.components);
            this.picExpand = new System.Windows.Forms.PictureBox();
            this.pCommands.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExpand)).BeginInit();
            this.SuspendLayout();
            // 
            // IM24
            // 
            this.IM24.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IM24.ImageStream")));
            this.IM24.TransparentColor = System.Drawing.Color.Fuchsia;
            this.IM24.Images.SetKeyName(0, "Clip");
            this.IM24.Images.SetKeyName(1, "Note");
            this.IM24.Images.SetKeyName(2, "Save");
            this.IM24.Images.SetKeyName(3, "Delete");
            this.IM24.Images.SetKeyName(4, "SaveExit");
            // 
            // cmdClip
            // 
            this.cmdClip.ImageKey = "Clip";
            this.cmdClip.ImageList = this.IM24;
            this.cmdClip.Location = new System.Drawing.Point(53, 44);
            this.cmdClip.Name = "cmdClip";
            this.cmdClip.Size = new System.Drawing.Size(44, 33);
            this.cmdClip.TabIndex = 7;
            this.cmdClip.UseVisualStyleBackColor = true;
            this.cmdClip.Click += new System.EventHandler(this.cmdClip_Click);
            // 
            // cmdNotes
            // 
            this.cmdNotes.ImageKey = "Note";
            this.cmdNotes.ImageList = this.IM24;
            this.cmdNotes.Location = new System.Drawing.Point(3, 44);
            this.cmdNotes.Name = "cmdNotes";
            this.cmdNotes.Size = new System.Drawing.Size(44, 33);
            this.cmdNotes.TabIndex = 6;
            this.cmdNotes.UseVisualStyleBackColor = true;
            this.cmdNotes.Click += new System.EventHandler(this.cmdNotes_Click);
            // 
            // cmdSaveExit
            // 
            this.cmdSaveExit.ImageKey = "SaveExit";
            this.cmdSaveExit.ImageList = this.IM24;
            this.cmdSaveExit.Location = new System.Drawing.Point(53, 5);
            this.cmdSaveExit.Name = "cmdSaveExit";
            this.cmdSaveExit.Size = new System.Drawing.Size(44, 33);
            this.cmdSaveExit.TabIndex = 5;
            this.cmdSaveExit.UseVisualStyleBackColor = true;
            this.cmdSaveExit.Click += new System.EventHandler(this.cmdSaveExit_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSave.ImageKey = "Save";
            this.cmdSave.ImageList = this.IM24;
            this.cmdSave.Location = new System.Drawing.Point(3, 5);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(44, 33);
            this.cmdSave.TabIndex = 4;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.ImageKey = "Delete";
            this.cmdDelete.ImageList = this.IM24;
            this.cmdDelete.Location = new System.Drawing.Point(31, 83);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(44, 33);
            this.cmdDelete.TabIndex = 8;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // pCommands
            // 
            this.pCommands.Controls.Add(this.cmdClip);
            this.pCommands.Controls.Add(this.cmdNotes);
            this.pCommands.Controls.Add(this.cmdSave);
            this.pCommands.Controls.Add(this.cmdSaveExit);
            this.pCommands.Controls.Add(this.cmdDelete);
            this.pCommands.Location = new System.Drawing.Point(551, 3);
            this.pCommands.Name = "pCommands";
            this.pCommands.Size = new System.Drawing.Size(103, 124);
            this.pCommands.TabIndex = 9;
            // 
            // pic
            // 
            this.pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pic.Location = new System.Drawing.Point(2, 2);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(24, 132);
            this.pic.TabIndex = 10;
            this.pic.TabStop = false;
            // 
            // picLeft
            // 
            this.picLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.picLeft.Location = new System.Drawing.Point(0, 0);
            this.picLeft.Name = "picLeft";
            this.picLeft.Size = new System.Drawing.Size(2, 137);
            this.picLeft.TabIndex = 11;
            this.picLeft.TabStop = false;
            // 
            // picRight
            // 
            this.picRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.picRight.Location = new System.Drawing.Point(663, 0);
            this.picRight.Name = "picRight";
            this.picRight.Size = new System.Drawing.Size(2, 137);
            this.picRight.TabIndex = 12;
            this.picRight.TabStop = false;
            // 
            // picTop
            // 
            this.picTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.picTop.Location = new System.Drawing.Point(2, 0);
            this.picTop.Name = "picTop";
            this.picTop.Size = new System.Drawing.Size(661, 2);
            this.picTop.TabIndex = 13;
            this.picTop.TabStop = false;
            // 
            // picBottom
            // 
            this.picBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.picBottom.Location = new System.Drawing.Point(2, 135);
            this.picBottom.Name = "picBottom";
            this.picBottom.Size = new System.Drawing.Size(661, 2);
            this.picBottom.TabIndex = 14;
            this.picBottom.TabStop = false;
            // 
            // imExpand
            // 
            this.imExpand.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imExpand.ImageStream")));
            this.imExpand.TransparentColor = System.Drawing.Color.Magenta;
            this.imExpand.Images.SetKeyName(0, "up");
            this.imExpand.Images.SetKeyName(1, "down");
            // 
            // picExpand
            // 
            this.picExpand.BackColor = System.Drawing.Color.White;
            this.picExpand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picExpand.Location = new System.Drawing.Point(6, 111);
            this.picExpand.Name = "picExpand";
            this.picExpand.Size = new System.Drawing.Size(20, 20);
            this.picExpand.TabIndex = 15;
            this.picExpand.TabStop = false;
            this.picExpand.Click += new System.EventHandler(this.picExpand_Click);
            // 
            // nLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picExpand);
            this.Controls.Add(this.picBottom);
            this.Controls.Add(this.picTop);
            this.Controls.Add(this.picRight);
            this.Controls.Add(this.picLeft);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.pCommands);
            this.Name = "nLine";
            this.Size = new System.Drawing.Size(665, 137);
            this.Resize += new System.EventHandler(this.nLine_Resize);
            this.pCommands.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExpand)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList IM24;
        private System.Windows.Forms.Button cmdClip;
        private System.Windows.Forms.Button cmdNotes;
        private System.Windows.Forms.Button cmdSaveExit;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.PictureBox picLeft;
        private System.Windows.Forms.PictureBox picRight;
        private System.Windows.Forms.PictureBox picTop;
        private System.Windows.Forms.PictureBox picBottom;
        private System.Windows.Forms.ImageList imExpand;
        private System.Windows.Forms.PictureBox picExpand;
        protected System.Windows.Forms.Panel pCommands;
    }
}
