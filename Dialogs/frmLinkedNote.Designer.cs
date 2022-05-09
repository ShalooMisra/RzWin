namespace Rz5
{
    partial class frmLinkedNote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLinkedNote));
            this.lvNotes = new NewMethod.nList();
            this.RT = new System.Windows.Forms.RichTextBox();
            this.cmdNew = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvNotes
            // 
            this.lvNotes.AddCaption = "Add New";
            this.lvNotes.AllowAdd = false;
            this.lvNotes.Caption = "";
            this.lvNotes.ExtraClassInfo = "";
            this.lvNotes.Location = new System.Drawing.Point(3, 2);
            this.lvNotes.Name = "lvNotes";
            this.lvNotes.Size = new System.Drawing.Size(561, 159);
            this.lvNotes.TabIndex = 0;
            this.lvNotes.AboutToThrow += new Core.ShowHandler(this.lvNotes_AboutToThrow);
            // 
            // RT
            // 
            this.RT.Location = new System.Drawing.Point(3, 167);
            this.RT.Name = "RT";
            this.RT.Size = new System.Drawing.Size(561, 114);
            this.RT.TabIndex = 1;
            this.RT.Text = "";
            // 
            // cmdNew
            // 
            this.cmdNew.Location = new System.Drawing.Point(3, 287);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(110, 20);
            this.cmdNew.TabIndex = 2;
            this.cmdNew.Text = "New";
            this.cmdNew.UseVisualStyleBackColor = true;
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Location = new System.Drawing.Point(454, 287);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(110, 20);
            this.cmdExit.TabIndex = 3;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(235, 287);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(110, 20);
            this.cmdSave.TabIndex = 4;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // frmLinkedNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 310);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.cmdNew);
            this.Controls.Add(this.RT);
            this.Controls.Add(this.lvNotes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLinkedNote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Linked Notes";
            this.ResumeLayout(false);

        }

        #endregion

        private NewMethod.nList lvNotes;
        private System.Windows.Forms.RichTextBox RT;
        private System.Windows.Forms.Button cmdNew;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Button cmdSave;
    }
}