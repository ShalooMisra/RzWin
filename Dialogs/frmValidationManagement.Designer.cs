namespace RzInterfaceWin.Dialogs
{
    partial class frmValidationManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmValidationManagement));
            this.btnResolve = new System.Windows.Forms.Button();
            this.btnShowValidationForm = new System.Windows.Forms.Button();
            this.ctl_validation_stage = new NewMethod.nEdit_List();
            this.SuspendLayout();
            // 
            // btnResolve
            // 
            this.btnResolve.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResolve.ForeColor = System.Drawing.Color.Red;
            this.btnResolve.Location = new System.Drawing.Point(294, 3);
            this.btnResolve.Margin = new System.Windows.Forms.Padding(4);
            this.btnResolve.Name = "btnResolve";
            this.btnResolve.Size = new System.Drawing.Size(50, 57);
            this.btnResolve.TabIndex = 75;
            this.btnResolve.Text = "⚠✔";
            this.btnResolve.UseVisualStyleBackColor = true;
            this.btnResolve.Click += new System.EventHandler(this.btnResolve_Click);
            // 
            // btnShowValidationForm
            // 
            this.btnShowValidationForm.BackgroundImage = global::RzInterfaceWin.Properties.Resources.form_input_checkbox;
            this.btnShowValidationForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowValidationForm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnShowValidationForm.Location = new System.Drawing.Point(239, 3);
            this.btnShowValidationForm.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowValidationForm.Name = "btnShowValidationForm";
            this.btnShowValidationForm.Size = new System.Drawing.Size(47, 57);
            this.btnShowValidationForm.TabIndex = 73;
            this.btnShowValidationForm.UseVisualStyleBackColor = true;
            this.btnShowValidationForm.Click += new System.EventHandler(this.btnShowValidationForm_Click);
            // 
            // ctl_validation_stage
            // 
            this.ctl_validation_stage.AllCaps = false;
            this.ctl_validation_stage.AllowEdit = false;
            this.ctl_validation_stage.BackColor = System.Drawing.Color.Transparent;
            this.ctl_validation_stage.Bold = false;
            this.ctl_validation_stage.Caption = "Stage";
            this.ctl_validation_stage.Changed = false;
            this.ctl_validation_stage.ListName = "validation_stage";
            this.ctl_validation_stage.Location = new System.Drawing.Point(16, 15);
            this.ctl_validation_stage.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_validation_stage.Name = "ctl_validation_stage";
            this.ctl_validation_stage.SimpleList = null;
            this.ctl_validation_stage.Size = new System.Drawing.Size(212, 44);
            this.ctl_validation_stage.TabIndex = 74;
            this.ctl_validation_stage.UseParentBackColor = false;
            this.ctl_validation_stage.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctl_validation_stage.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_validation_stage.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_validation_stage.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_validation_stage.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_validation_stage.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_validation_stage.zz_OriginalDesign = false;
            this.ctl_validation_stage.zz_ShowNeedsSaveColor = true;
            this.ctl_validation_stage.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_validation_stage.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_validation_stage.zz_UseGlobalColor = false;
            this.ctl_validation_stage.zz_UseGlobalFont = false;
            this.ctl_validation_stage.SelectionChanged += new NewMethod.nEdit_List.SelectionChangedHandler(this.ctl_validation_stage_SelectionChanged);
            // 
            // frmValidationManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 84);
            this.Controls.Add(this.btnResolve);
            this.Controls.Add(this.btnShowValidationForm);
            this.Controls.Add(this.ctl_validation_stage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmValidationManagement";
            this.Text = "Validation Management";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnResolve;
        private System.Windows.Forms.Button btnShowValidationForm;
        private NewMethod.nEdit_List ctl_validation_stage;
    }
}