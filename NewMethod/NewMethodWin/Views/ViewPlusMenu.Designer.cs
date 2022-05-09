
namespace NewMethod
{
    partial class ViewPlusMenu
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.xActions = new NewMethod.nActionMenu();
            this.SuspendLayout();
            // 
            // xActions
            // 
            this.xActions.BackColor = System.Drawing.Color.White;
            this.xActions.EnableDelete = false;
            this.xActions.Location = new System.Drawing.Point(494, 45);
            this.xActions.Name = "xActions";
            this.xActions.Size = new System.Drawing.Size(144, 291);
            this.xActions.TabIndex = 8;
            this.xActions.ActionClick += new NewMethod.FlashClickHandler(this.xActions_ActionClick);
            // 
            // ViewPlusMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.xActions);
            this.Name = "ViewPlusMenu";
            this.Size = new System.Drawing.Size(699, 438);
            this.Controls.SetChildIndex(this.xActions, 0);
            this.ResumeLayout(false);

        }

        #endregion

        public nActionMenu xActions;
    }
}
