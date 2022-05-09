namespace Rz5
{
    partial class frmFeedback
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
            this.lvFeedback = new NewMethod.nList();
            this.txtComments = new System.Windows.Forms.RichTextBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.cmdNew = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvFeedback
            // 
            this.lvFeedback.AddCaption = "Add New";
            this.lvFeedback.AllowActions = true;
            this.lvFeedback.AllowAdd = false;
            this.lvFeedback.AllowDelete = true;
            this.lvFeedback.AllowDeleteAlways = false;
            this.lvFeedback.AllowDrop = true;
            this.lvFeedback.AllowOnlyOpenDelete = false;
            this.lvFeedback.AlternateConnection = null;
            this.lvFeedback.BackColor = System.Drawing.Color.White;
            this.lvFeedback.Caption = "";
            this.lvFeedback.CurrentTemplate = null;
            this.lvFeedback.ExtraClassInfo = "";
            this.lvFeedback.Location = new System.Drawing.Point(3, 26);
            this.lvFeedback.MultiSelect = true;
            this.lvFeedback.Name = "lvFeedback";
            this.lvFeedback.Size = new System.Drawing.Size(526, 171);
            this.lvFeedback.SuppressSelectionChanged = false;
            this.lvFeedback.TabIndex = 0;
            this.lvFeedback.zz_OpenColumnMenu = false;
            this.lvFeedback.zz_OrderLineType = "";
            this.lvFeedback.zz_ShowAutoRefresh = true;
            this.lvFeedback.zz_ShowUnlimited = true;
            this.lvFeedback.AboutToThrow += new Core.ShowHandler(this.lvFeedback_AboutToThrow);
            // 
            // txtComments
            // 
            this.txtComments.Location = new System.Drawing.Point(3, 259);
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(526, 96);
            this.txtComments.TabIndex = 1;
            this.txtComments.Text = "";
            // 
            // cmdSave
            // 
            this.cmdSave.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSave.Image = global::RzInterfaceWin.Properties.Resources.saveHS;
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(436, 361);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(93, 32);
            this.cmdSave.TabIndex = 2;
            this.cmdSave.Text = "Save  ";
            this.cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.Items.AddRange(new object[] {
            "Positive",
            "Negative",
            "Neutral"});
            this.cboType.Location = new System.Drawing.Point(3, 218);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(526, 21);
            this.cboType.TabIndex = 3;
            // 
            // cmdNew
            // 
            this.cmdNew.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNew.Image = global::RzInterfaceWin.Properties.Resources.NewCardHS;
            this.cmdNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdNew.Location = new System.Drawing.Point(3, 361);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(93, 32);
            this.cmdNew.TabIndex = 4;
            this.cmdNew.Text = "New   ";
            this.cmdNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdNew.UseVisualStyleBackColor = true;
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-1, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "Feedback Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-1, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "Feedback Comments";
            // 
            // lblCompany
            // 
            this.lblCompany.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblCompany.Location = new System.Drawing.Point(-1, -3);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(535, 28);
            this.lblCompany.TabIndex = 7;
            this.lblCompany.Text = "Company Name";
            this.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmFeedback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 395);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdNew);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.lvFeedback);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmFeedback";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Feedback";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NewMethod.nList lvFeedback;
        private System.Windows.Forms.RichTextBox txtComments;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Button cmdNew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCompany;
    }
}