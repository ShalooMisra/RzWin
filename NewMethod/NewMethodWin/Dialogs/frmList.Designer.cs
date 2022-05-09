namespace NewMethod
{
    partial class frmList
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
            this.components = new System.ComponentModel.Container();
            this.xList = new NewMethod.nList();
            this.SuspendLayout();
            // 
            // xList
            // 
            this.xList.AddCaption = "Add New";
            this.xList.AllowAdd = false;
            this.xList.AllowDelete = true;
            this.xList.Caption = "";
            this.xList.ExtraClassInfo = "";
            this.xList.Location = new System.Drawing.Point(12, 12);
            this.xList.MultiSelect = true;
            this.xList.Name = "xList";
            this.xList.Size = new System.Drawing.Size(411, 355);
            this.xList.SuppressSelectionChanged = false;
            this.xList.TabIndex = 0;
            // 
            // frmList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 357);
            this.Controls.Add(this.xList);
            this.Name = "frmList";
            this.Text = "frmList";
            this.Resize += new System.EventHandler(this.frmList_Resize);
            this.Load += new System.EventHandler(this.frmList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private nList xList;
    }
}