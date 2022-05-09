namespace Rz5
{
    partial class HomePanelBatches
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
            this.cmdSearch = new System.Windows.Forms.Button();
            this.optAll = new System.Windows.Forms.RadioButton();
            this.optOpen = new System.Windows.Forms.RadioButton();
            this.optClosed = new System.Windows.Forms.RadioButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.ddlOppStage = new NewMethod.nEdit_List();
            this.SuspendLayout();
            // 
            // cmdSearch
            // 
            this.cmdSearch.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSearch.Location = new System.Drawing.Point(441, 4);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(151, 31);
            this.cmdSearch.TabIndex = 5;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // optAll
            // 
            this.optAll.AutoSize = true;
            this.optAll.Checked = true;
            this.optAll.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optAll.Location = new System.Drawing.Point(180, 40);
            this.optAll.Name = "optAll";
            this.optAll.Size = new System.Drawing.Size(44, 23);
            this.optAll.TabIndex = 6;
            this.optAll.TabStop = true;
            this.optAll.Text = "All";
            this.optAll.UseVisualStyleBackColor = true;
            // 
            // optOpen
            // 
            this.optOpen.AutoSize = true;
            this.optOpen.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optOpen.Location = new System.Drawing.Point(246, 40);
            this.optOpen.Name = "optOpen";
            this.optOpen.Size = new System.Drawing.Size(62, 23);
            this.optOpen.TabIndex = 7;
            this.optOpen.Text = "Open";
            this.optOpen.UseVisualStyleBackColor = true;
            // 
            // optClosed
            // 
            this.optClosed.AutoSize = true;
            this.optClosed.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optClosed.Location = new System.Drawing.Point(328, 40);
            this.optClosed.Name = "optClosed";
            this.optClosed.Size = new System.Drawing.Size(71, 23);
            this.optClosed.TabIndex = 8;
            this.optClosed.Text = "Closed";
            this.optClosed.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(229, 7);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(206, 27);
            this.txtSearch.TabIndex = 10;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(176, 10);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(52, 19);
            this.lblSearch.TabIndex = 9;
            this.lblSearch.Text = "Search";
            // 
            // ddlOppStage
            // 
            this.ddlOppStage.AllCaps = false;
            this.ddlOppStage.AllowEdit = false;
            this.ddlOppStage.BackColor = System.Drawing.SystemColors.Window;
            this.ddlOppStage.Bold = false;
            this.ddlOppStage.Caption = "Opportunity Stage";
            this.ddlOppStage.Changed = false;
            this.ddlOppStage.ListName = "OpportunityStages";
            this.ddlOppStage.Location = new System.Drawing.Point(405, 36);
            this.ddlOppStage.Name = "ddlOppStage";
            this.ddlOppStage.SimpleList = null;
            this.ddlOppStage.Size = new System.Drawing.Size(187, 46);
            this.ddlOppStage.TabIndex = 11;
            this.ddlOppStage.UseParentBackColor = false;
            this.ddlOppStage.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlOppStage.zz_GlobalColor = System.Drawing.Color.Black;
            this.ddlOppStage.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ddlOppStage.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ddlOppStage.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlOppStage.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ddlOppStage.zz_OriginalDesign = true;
            this.ddlOppStage.zz_ShowNeedsSaveColor = true;
            this.ddlOppStage.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ddlOppStage.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlOppStage.zz_UseGlobalColor = false;
            this.ddlOppStage.zz_UseGlobalFont = false;
            // 
            // HomePanelBatches
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ddlOppStage);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.optClosed);
            this.Controls.Add(this.optOpen);
            this.Controls.Add(this.optAll);
            this.Controls.Add(this.cmdSearch);
            this.Name = "HomePanelBatches";
            this.Size = new System.Drawing.Size(698, 84);
            this.Load += new System.EventHandler(this.HomePanelBatches_Load);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.optAll, 0);
            this.Controls.SetChildIndex(this.optOpen, 0);
            this.Controls.SetChildIndex(this.optClosed, 0);
            this.Controls.SetChildIndex(this.lblSearch, 0);
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.ddlOppStage, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.RadioButton optAll;
        private System.Windows.Forms.RadioButton optOpen;
        private System.Windows.Forms.RadioButton optClosed;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private NewMethod.nEdit_List ddlOppStage;
    }
}
