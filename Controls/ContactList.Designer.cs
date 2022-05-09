using NewMethod;

namespace Rz5
{
    partial class ContactList
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
            this.cbo = new System.Windows.Forms.ComboBox();
            this.lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbo
            // 
            this.cbo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo.FormattingEnabled = true;
            this.cbo.Location = new System.Drawing.Point(0, 17);
            this.cbo.Name = "cbo";
            this.cbo.Size = new System.Drawing.Size(272, 28);
            this.cbo.TabIndex = 4;
            this.cbo.SelectedValueChanged += new System.EventHandler(this.cbo_SelectedValueChanged);
            // 
            // lbl
            // 
            this.lbl.Location = new System.Drawing.Point(0, 0);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(85, 14);
            this.lbl.TabIndex = 5;
            this.lbl.Text = "Contact";
            // 
            // ContactList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.cbo);
            this.Name = "ContactList";
            this.Size = new System.Drawing.Size(351, 48);
            this.Resize += new System.EventHandler(this.ContactList_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbo;
        private System.Windows.Forms.Label lbl;
    }
}
