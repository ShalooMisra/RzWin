namespace NewMethod
{
    partial class NumericOption
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
            this.optRange = new System.Windows.Forms.RadioButton();
            this.optAtLeast = new System.Windows.Forms.RadioButton();
            this.optEquals = new System.Windows.Forms.RadioButton();
            this.ctl = new NewMethod.nEdit_List();
            this.SuspendLayout();
            // 
            // optRange
            // 
            this.optRange.AutoSize = true;
            this.optRange.Location = new System.Drawing.Point(119, 20);
            this.optRange.Name = "optRange";
            this.optRange.Size = new System.Drawing.Size(38, 17);
            this.optRange.TabIndex = 11;
            this.optRange.Text = "x-y";
            this.optRange.UseVisualStyleBackColor = true;
            // 
            // optAtLeast
            // 
            this.optAtLeast.AutoSize = true;
            this.optAtLeast.Location = new System.Drawing.Point(58, 20);
            this.optAtLeast.Name = "optAtLeast";
            this.optAtLeast.Size = new System.Drawing.Size(37, 17);
            this.optAtLeast.TabIndex = 10;
            this.optAtLeast.Text = ">=";
            this.optAtLeast.UseVisualStyleBackColor = true;
            // 
            // optEquals
            // 
            this.optEquals.AutoSize = true;
            this.optEquals.Checked = true;
            this.optEquals.Location = new System.Drawing.Point(5, 20);
            this.optEquals.Name = "optEquals";
            this.optEquals.Size = new System.Drawing.Size(31, 17);
            this.optEquals.TabIndex = 9;
            this.optEquals.TabStop = true;
            this.optEquals.Text = "=";
            this.optEquals.UseVisualStyleBackColor = true;
            // 
            // ctl
            // 
            this.ctl.AllCaps = false;
            this.ctl.AllowEdit = false;
            this.ctl.BackColor = System.Drawing.Color.White;
            this.ctl.Bold = false;
            this.ctl.Caption = "<caption>";
            this.ctl.Changed = false;
            this.ctl.ListName = null;
            this.ctl.Location = new System.Drawing.Point(5, 0);
            this.ctl.Name = "ctl";
            this.ctl.SimpleList = null;
            this.ctl.Size = new System.Drawing.Size(162, 22);
            this.ctl.TabIndex = 12;
            this.ctl.UseParentBackColor = true;
            this.ctl.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.Left;
            this.ctl.zz_OriginalDesign = false;
            this.ctl.zz_ShowNeedsSaveColor = true;
            this.ctl.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl.zz_UseGlobalColor = false;
            this.ctl.zz_UseGlobalFont = false;
            // 
            // NumericOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ctl);
            this.Controls.Add(this.optRange);
            this.Controls.Add(this.optAtLeast);
            this.Controls.Add(this.optEquals);
            this.Name = "NumericOption";
            this.Size = new System.Drawing.Size(170, 37);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton optRange;
        private System.Windows.Forms.RadioButton optAtLeast;
        private System.Windows.Forms.RadioButton optEquals;
        private nEdit_List ctl;
    }
}
