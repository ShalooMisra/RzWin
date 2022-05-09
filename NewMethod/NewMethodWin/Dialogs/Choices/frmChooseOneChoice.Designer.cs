namespace NewMethod
{
    partial class frmChooseOneChoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChooseOneChoice));
            this.lst = new System.Windows.Forms.ListBox();
            this.lblCaption = new System.Windows.Forms.Label();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.pOptions.SuspendLayout();
            this.pContents.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(142, 0);
            this.cmdOK.Size = new System.Drawing.Size(276, 58);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(0, 0);
            // 
            // pOptions
            // 
            this.pOptions.Location = new System.Drawing.Point(0, 416);
            this.pOptions.Size = new System.Drawing.Size(418, 63);
            // 
            // pContents
            // 
            this.pContents.Controls.Add(this.lblCaption);
            this.pContents.Controls.Add(this.lst);
            this.pContents.Controls.Add(this.cmdAdd);
            this.pContents.Location = new System.Drawing.Point(0, 0);
            this.pContents.Size = new System.Drawing.Size(418, 416);
            // 
            // lst
            // 
            this.lst.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst.FormattingEnabled = true;
            this.lst.ItemHeight = 20;
            this.lst.Location = new System.Drawing.Point(3, 35);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(386, 364);
            this.lst.TabIndex = 0;
            this.lst.DoubleClick += new System.EventHandler(this.lst_DoubleClick);
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.Location = new System.Drawing.Point(5, 9);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(79, 20);
            this.lblCaption.TabIndex = 3;
            this.lblCaption.Text = "<caption>";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAdd.Location = new System.Drawing.Point(300, 2);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(101, 27);
            this.cmdAdd.TabIndex = 4;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // frmChooseOneChoice
            // 
            this.ClientSize = new System.Drawing.Size(418, 479);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChooseOneChoice";
            this.Text = "List";
            this.Activated += new System.EventHandler(this.frmChooseOneChoice_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmChooseOneChoice_FormClosed);
            this.pOptions.ResumeLayout(false);
            this.pContents.ResumeLayout(false);
            this.pContents.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lst;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Button cmdAdd;
    }
}