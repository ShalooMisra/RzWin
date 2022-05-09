namespace NewMethod
{
    partial class nActionMenu
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
            if (disposing)
                CompleteDispose();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(nActionMenu));
            this.pButtons = new System.Windows.Forms.Panel();
            this.cmdNotes = new System.Windows.Forms.Button();
            this.IM24 = new System.Windows.Forms.ImageList(this.components);
            this.cmdSaveExit = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.pDelete = new System.Windows.Forms.Panel();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.pLinks = new System.Windows.Forms.FlowLayoutPanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pLeft = new System.Windows.Forms.PictureBox();
            this.pButtons.SuspendLayout();
            this.pDelete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pLeft)).BeginInit();
            this.SuspendLayout();
            // 
            // pButtons
            // 
            this.pButtons.BackColor = System.Drawing.Color.White;
            this.pButtons.Controls.Add(this.cmdNotes);
            this.pButtons.Controls.Add(this.cmdSaveExit);
            this.pButtons.Controls.Add(this.cmdSave);
            this.pButtons.Location = new System.Drawing.Point(4, 4);
            this.pButtons.Margin = new System.Windows.Forms.Padding(4);
            this.pButtons.Name = "pButtons";
            this.pButtons.Size = new System.Drawing.Size(186, 48);
            this.pButtons.TabIndex = 34;
            // 
            // cmdNotes
            // 
            this.cmdNotes.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNotes.ImageKey = "Note";
            this.cmdNotes.ImageList = this.IM24;
            this.cmdNotes.Location = new System.Drawing.Point(125, 4);
            this.cmdNotes.Margin = new System.Windows.Forms.Padding(4);
            this.cmdNotes.Name = "cmdNotes";
            this.cmdNotes.Size = new System.Drawing.Size(60, 41);
            this.cmdNotes.TabIndex = 2;
            this.toolTip1.SetToolTip(this.cmdNotes, "New Note");
            this.cmdNotes.UseVisualStyleBackColor = true;
            this.cmdNotes.Click += new System.EventHandler(this.cmdNotes_Click);
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
            this.IM24.Images.SetKeyName(5, "edit_menu");
            // 
            // cmdSaveExit
            // 
            this.cmdSaveExit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSaveExit.ImageKey = "SaveExit";
            this.cmdSaveExit.ImageList = this.IM24;
            this.cmdSaveExit.Location = new System.Drawing.Point(64, 4);
            this.cmdSaveExit.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSaveExit.Name = "cmdSaveExit";
            this.cmdSaveExit.Size = new System.Drawing.Size(59, 41);
            this.cmdSaveExit.TabIndex = 1;
            this.toolTip1.SetToolTip(this.cmdSaveExit, "Save And Exit");
            this.cmdSaveExit.UseVisualStyleBackColor = true;
            this.cmdSaveExit.Click += new System.EventHandler(this.cmdSaveExit_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSave.ImageKey = "Save";
            this.cmdSave.ImageList = this.IM24;
            this.cmdSave.Location = new System.Drawing.Point(3, 4);
            this.cmdSave.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(59, 41);
            this.cmdSave.TabIndex = 0;
            this.toolTip1.SetToolTip(this.cmdSave, "Save");
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // pDelete
            // 
            this.pDelete.BackColor = System.Drawing.Color.White;
            this.pDelete.Controls.Add(this.cmdDelete);
            this.pDelete.Location = new System.Drawing.Point(4, 345);
            this.pDelete.Margin = new System.Windows.Forms.Padding(4);
            this.pDelete.Name = "pDelete";
            this.pDelete.Size = new System.Drawing.Size(185, 64);
            this.pDelete.TabIndex = 36;
            // 
            // cmdDelete
            // 
            this.cmdDelete.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdDelete.ImageKey = "Delete";
            this.cmdDelete.ImageList = this.IM24;
            this.cmdDelete.Location = new System.Drawing.Point(3, 4);
            this.cmdDelete.Margin = new System.Windows.Forms.Padding(4);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(179, 58);
            this.cmdDelete.TabIndex = 3;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.cmdDelete, "Delete");
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // pLinks
            // 
            this.pLinks.AutoScroll = true;
            this.pLinks.BackColor = System.Drawing.Color.White;
            this.pLinks.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pLinks.Location = new System.Drawing.Point(6, 59);
            this.pLinks.Margin = new System.Windows.Forms.Padding(4);
            this.pLinks.Name = "pLinks";
            this.pLinks.Size = new System.Drawing.Size(181, 278);
            this.pLinks.TabIndex = 84;
            this.pLinks.WrapContents = false;
            // 
            // pLeft
            // 
            this.pLeft.BackColor = System.Drawing.Color.LightGray;
            this.pLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeft.Location = new System.Drawing.Point(0, 0);
            this.pLeft.Margin = new System.Windows.Forms.Padding(4);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(1, 482);
            this.pLeft.TabIndex = 37;
            this.pLeft.TabStop = false;
            // 
            // nActionMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pLinks);
            this.Controls.Add(this.pLeft);
            this.Controls.Add(this.pDelete);
            this.Controls.Add(this.pButtons);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "nActionMenu";
            this.Size = new System.Drawing.Size(191, 482);
            this.Resize += new System.EventHandler(this.nActionMenu_Resize);
            this.pButtons.ResumeLayout(false);
            this.pDelete.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pLeft)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pButtons;
        private System.Windows.Forms.Panel pDelete;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdSaveExit;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button cmdDelete;
        public System.Windows.Forms.FlowLayoutPanel pLinks;
        public System.Windows.Forms.ImageList IM24;
        private System.Windows.Forms.PictureBox pLeft;
        public System.Windows.Forms.Button cmdNotes;
    }
}
