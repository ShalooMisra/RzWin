namespace NewMethod
{
    partial class ClassInstanceLine
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
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.lblClassName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblList = new System.Windows.Forms.LinkLabel();
            this.lblAdd = new System.Windows.Forms.LinkLabel();
            this.lblSysName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // picIcon
            // 
            this.picIcon.Location = new System.Drawing.Point(3, 8);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(20, 20);
            this.picIcon.TabIndex = 0;
            this.picIcon.TabStop = false;
            // 
            // lblClassName
            // 
            this.lblClassName.AutoSize = true;
            this.lblClassName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassName.Location = new System.Drawing.Point(25, 6);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(107, 20);
            this.lblClassName.TabIndex = 1;
            this.lblClassName.Text = "<class name>";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.ForeColor = System.Drawing.Color.DarkGray;
            this.lblDescription.Location = new System.Drawing.Point(36, 27);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(53, 13);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "<tag line>";
            // 
            // lblList
            // 
            this.lblList.AutoSize = true;
            this.lblList.Location = new System.Drawing.Point(39, 60);
            this.lblList.Name = "lblList";
            this.lblList.Size = new System.Drawing.Size(19, 13);
            this.lblList.TabIndex = 3;
            this.lblList.TabStop = true;
            this.lblList.Text = "list";
            this.lblList.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblList_LinkClicked);
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.Location = new System.Drawing.Point(64, 60);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(25, 13);
            this.lblAdd.TabIndex = 4;
            this.lblAdd.TabStop = true;
            this.lblAdd.Text = "add";
            this.lblAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAdd_LinkClicked);
            // 
            // lblSysName
            // 
            this.lblSysName.AutoSize = true;
            this.lblSysName.ForeColor = System.Drawing.Color.DarkGray;
            this.lblSysName.Location = new System.Drawing.Point(36, 43);
            this.lblSysName.Name = "lblSysName";
            this.lblSysName.Size = new System.Drawing.Size(63, 13);
            this.lblSysName.TabIndex = 5;
            this.lblSysName.Text = "<sys name>";
            // 
            // ClassInstanceLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSysName);
            this.Controls.Add(this.lblAdd);
            this.Controls.Add(this.lblList);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblClassName);
            this.Controls.Add(this.picIcon);
            this.Name = "ClassInstanceLine";
            this.Size = new System.Drawing.Size(280, 75);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Label lblClassName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.LinkLabel lblList;
        private System.Windows.Forms.LinkLabel lblAdd;
        private System.Windows.Forms.Label lblSysName;
    }
}
