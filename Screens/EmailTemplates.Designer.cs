using NewMethod;

namespace Rz5
{
    partial class EmailTemplates
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
            this.lvTemplates = new NewMethod.nList();
            this.cmdNew = new System.Windows.Forms.Button();
            this.TheView = new view_emailtemplate();
            this.SuspendLayout();
            // 
            // lvTemplates
            // 
            this.lvTemplates.AddCaption = "Add New";
            this.lvTemplates.AllowAdd = false;
            this.lvTemplates.AllowDelete = true;
            this.lvTemplates.Caption = "";
            this.lvTemplates.ExtraClassInfo = "";
            this.lvTemplates.Location = new System.Drawing.Point(5, 33);
            this.lvTemplates.MultiSelect = true;
            this.lvTemplates.Name = "lvTemplates";
            this.lvTemplates.Size = new System.Drawing.Size(264, 523);
            this.lvTemplates.SuppressSelectionChanged = false;
            this.lvTemplates.TabIndex = 0;
            this.lvTemplates.ObjectClicked += new NewMethod.ObjectClickHandler(this.lvTemplates_ObjectClicked);
            // 
            // cmdNew
            // 
            this.cmdNew.Location = new System.Drawing.Point(5, 6);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(264, 21);
            this.cmdNew.TabIndex = 15;
            this.cmdNew.Text = "New Template";
            this.cmdNew.UseVisualStyleBackColor = true;
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // TheView
            // 
            this.TheView.BackColor = System.Drawing.Color.White;
            this.TheView.Location = new System.Drawing.Point(275, 8);
            this.TheView.Name = "TheView";
            this.TheView.Size = new System.Drawing.Size(637, 548);
            this.TheView.TabIndex = 1;
            // 
            // EmailTemplates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdNew);
            this.Controls.Add(this.TheView);
            this.Controls.Add(this.lvTemplates);
            this.Name = "EmailTemplates";
            this.Size = new System.Drawing.Size(803, 572);
            this.Resize += new System.EventHandler(this.EmailTemplates_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private NewMethod.nList lvTemplates;
        private view_emailtemplate TheView;
        private System.Windows.Forms.Button cmdNew;
    }
}
