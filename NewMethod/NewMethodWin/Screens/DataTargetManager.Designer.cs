namespace NewMethod
{
    partial class DataTargetManager
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
            this.dv = new NewMethod.view_data_target();
            this.lstTargets = new NewMethod.nList();
            this.SuspendLayout();
            // 
            // dv
            // 
            this.dv.DisconnectedMode = false;
            this.dv.Location = new System.Drawing.Point(8, 319);
            this.dv.Name = "dv";
            this.dv.Size = new System.Drawing.Size(695, 289);
            this.dv.TabIndex = 1;
            // 
            // lstTargets
            // 
            this.lstTargets.AddCaption = "Add New Data Target";
            this.lstTargets.AllowAdd = true;
            this.lstTargets.AllowDelete = true;
            this.lstTargets.Caption = "";
            this.lstTargets.ExtraClassInfo = "";
            this.lstTargets.Location = new System.Drawing.Point(8, 7);
            this.lstTargets.MultiSelect = true;
            this.lstTargets.Name = "lstTargets";
            this.lstTargets.Size = new System.Drawing.Size(717, 306);
            this.lstTargets.SuppressSelectionChanged = false;
            this.lstTargets.TabIndex = 0;
            this.lstTargets.ObjectClicked += new NewMethod.ObjectClickHandler(this.lstTargets_ObjectClicked);
            this.lstTargets.AboutToDelete += new NewMethod.ActionHandler(this.lstTargets_AboutToDelete);
            this.lstTargets.AboutToAdd += new NewMethod.AddHandler(this.lstTargets_AboutToAdd);
            // 
            // DataTargetManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dv);
            this.Controls.Add(this.lstTargets);
            this.Name = "DataTargetManager";
            this.Size = new System.Drawing.Size(777, 621);
            this.ResumeLayout(false);

        }

        #endregion

        private nList lstTargets;
        private view_data_target dv;
    }
}
