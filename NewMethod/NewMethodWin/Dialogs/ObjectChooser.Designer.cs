namespace NewMethod.Win.Dialogs
{
    partial class ObjectChooser
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
            this.lv = new NewMethod.nList();
            this.pContents.SuspendLayout();
            this.SuspendLayout();
            // 
            // pContents
            // 
            this.pContents.Controls.Add(this.lv);
            this.pContents.Location = new System.Drawing.Point(0, 0);
            this.pContents.Size = new System.Drawing.Size(693, 485);
            // 
            // lv
            // 
            this.lv.AddCaption = "Add New";
            this.lv.AllowActions = true;
            this.lv.AllowAdd = false;
            this.lv.AllowDelete = true;
            this.lv.AllowDeleteAlways = false;
            this.lv.AllowDrop = true;
            this.lv.AlternateConnection = null;
            this.lv.Caption = "";
            this.lv.CurrentTemplate = null;
            this.lv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv.ExtraClassInfo = "";
            this.lv.Location = new System.Drawing.Point(0, 0);
            this.lv.MultiSelect = true;
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(693, 485);
            this.lv.SuppressSelectionChanged = false;
            this.lv.TabIndex = 0;
            this.lv.zz_OpenColumnMenu = false;
            this.lv.zz_ShowAutoRefresh = true;
            this.lv.zz_ShowUnlimited = true;
            this.lv.AboutToThrow += new Core.ShowHandler(this.lv_AboutToThrow);
            // 
            // ObjectChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 548);
            this.Name = "ObjectChooser";
            this.Text = "Item Selection";
            this.pContents.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private nList lv;
    }
}