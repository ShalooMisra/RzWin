namespace NewMethod
{
    partial class ViewEditPermissions
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
            this.cmdApply = new System.Windows.Forms.Button();
            this.lv = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblTeamUser = new System.Windows.Forms.Label();
            this.pe = new NewMethod.PermitEditor();
            this.SuspendLayout();
            // 
            // cmdApply
            // 
            this.cmdApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdApply.Location = new System.Drawing.Point(13, 343);
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(646, 47);
            this.cmdApply.TabIndex = 1;
            this.cmdApply.Text = "Apply";
            this.cmdApply.UseVisualStyleBackColor = true;
            this.cmdApply.Click += new System.EventHandler(this.cmdApply_Click);
            // 
            // lv
            // 
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lv.FullRowSelect = true;
            this.lv.GridLines = true;
            this.lv.HideSelection = false;
            this.lv.Location = new System.Drawing.Point(13, 41);
            this.lv.MultiSelect = false;
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(230, 296);
            this.lv.TabIndex = 2;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Agent";
            this.columnHeader1.Width = 198;
            // 
            // lblTeamUser
            // 
            this.lblTeamUser.BackColor = System.Drawing.Color.White;
            this.lblTeamUser.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTeamUser.Location = new System.Drawing.Point(13, 15);
            this.lblTeamUser.Name = "lblTeamUser";
            this.lblTeamUser.Size = new System.Drawing.Size(646, 23);
            this.lblTeamUser.TabIndex = 3;
            this.lblTeamUser.Text = "TEAMUSERNAME";
            this.lblTeamUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pe
            // 
            this.pe.Location = new System.Drawing.Point(249, 41);
            this.pe.Name = "pe";
            this.pe.Size = new System.Drawing.Size(410, 296);
            this.pe.TabIndex = 4;
            // 
            // ViewEditPermissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.pe);
            this.Controls.Add(this.lblTeamUser);
            this.Controls.Add(this.lv);
            this.Controls.Add(this.cmdApply);
            this.Name = "ViewEditPermissions";
            this.Size = new System.Drawing.Size(844, 525);
            this.Resize += new System.EventHandler(this.ViewEditPermissions_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdApply;
        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label lblTeamUser;
        private PermitEditor pe;
    }
}
