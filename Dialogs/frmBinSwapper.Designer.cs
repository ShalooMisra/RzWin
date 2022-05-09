namespace Rz5
{
    partial class frmBinSwapper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBinSwapper));
            this.lvResults = new NewMethod.nList();
            this.ctl_binsearch = new NewMethod.nEdit_String();
            this.ctl_binswap = new NewMethod.nEdit_String();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.cmdSwap = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lvResults
            // 
            this.lvResults.AddCaption = "Add New";
            this.lvResults.AllowActions = true;
            this.lvResults.AllowAdd = false;
            this.lvResults.AllowDelete = true;
            this.lvResults.Caption = "";
            this.lvResults.ExtraClassInfo = "";
            this.lvResults.Location = new System.Drawing.Point(12, 141);
            this.lvResults.MultiSelect = true;
            this.lvResults.Name = "lvResults";
            this.lvResults.Size = new System.Drawing.Size(752, 250);
            this.lvResults.SuppressSelectionChanged = false;
            this.lvResults.TabIndex = 0;
            this.lvResults.zz_ShowAutoRefresh = true;
            this.lvResults.zz_ShowUnlimited = true;
            // 
            // ctl_binsearch
            // 
            this.ctl_binsearch.AllCaps = false;
            this.ctl_binsearch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_binsearch.Bold = false;
            this.ctl_binsearch.Caption = "Bin To Search For";
            this.ctl_binsearch.Changed = false;
            this.ctl_binsearch.IsEmail = false;
            this.ctl_binsearch.IsURL = false;
            this.ctl_binsearch.Location = new System.Drawing.Point(12, 63);
            this.ctl_binsearch.Name = "ctl_binsearch";
            this.ctl_binsearch.PasswordChar = '\0';
            this.ctl_binsearch.Size = new System.Drawing.Size(368, 53);
            this.ctl_binsearch.TabIndex = 1;
            this.ctl_binsearch.UseParentBackColor = false;
            this.ctl_binsearch.zz_Enabled = true;
            this.ctl_binsearch.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_binsearch.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_binsearch.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_binsearch.zz_LabelFont = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_binsearch.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopCenter;
            this.ctl_binsearch.zz_OriginalDesign = false;
            this.ctl_binsearch.zz_ShowLinkButton = false;
            this.ctl_binsearch.zz_ShowNeedsSaveColor = true;
            this.ctl_binsearch.zz_Text = "";
            this.ctl_binsearch.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_binsearch.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_binsearch.zz_TextFont = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_binsearch.zz_UseGlobalColor = false;
            this.ctl_binsearch.zz_UseGlobalFont = false;
            // 
            // ctl_binswap
            // 
            this.ctl_binswap.AllCaps = false;
            this.ctl_binswap.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctl_binswap.Bold = false;
            this.ctl_binswap.Caption = "Bin To Swap To";
            this.ctl_binswap.Changed = false;
            this.ctl_binswap.IsEmail = false;
            this.ctl_binswap.IsURL = false;
            this.ctl_binswap.Location = new System.Drawing.Point(396, 63);
            this.ctl_binswap.Name = "ctl_binswap";
            this.ctl_binswap.PasswordChar = '\0';
            this.ctl_binswap.Size = new System.Drawing.Size(368, 53);
            this.ctl_binswap.TabIndex = 2;
            this.ctl_binswap.UseParentBackColor = false;
            this.ctl_binswap.zz_Enabled = true;
            this.ctl_binswap.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_binswap.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_binswap.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_binswap.zz_LabelFont = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_binswap.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopCenter;
            this.ctl_binswap.zz_OriginalDesign = false;
            this.ctl_binswap.zz_ShowLinkButton = false;
            this.ctl_binswap.zz_ShowNeedsSaveColor = true;
            this.ctl_binswap.zz_Text = "";
            this.ctl_binswap.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_binswap.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_binswap.zz_TextFont = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_binswap.zz_UseGlobalColor = false;
            this.ctl_binswap.zz_UseGlobalFont = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(756, 42);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bin Location Swapper";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlText;
            this.pictureBox1.Location = new System.Drawing.Point(12, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(752, 2);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Search Results";
            // 
            // cmdSearch
            // 
            this.cmdSearch.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSearch.Location = new System.Drawing.Point(12, 397);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(368, 32);
            this.cmdSearch.TabIndex = 6;
            this.cmdSearch.Text = "Search Bin Location";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // cmdSwap
            // 
            this.cmdSwap.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSwap.Location = new System.Drawing.Point(396, 397);
            this.cmdSwap.Name = "cmdSwap";
            this.cmdSwap.Size = new System.Drawing.Size(368, 32);
            this.cmdSwap.TabIndex = 7;
            this.cmdSwap.Text = "Swap Bin Location";
            this.cmdSwap.UseVisualStyleBackColor = true;
            this.cmdSwap.Click += new System.EventHandler(this.cmdSwap_Click);
            // 
            // frmBinSwapper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 437);
            this.Controls.Add(this.cmdSwap);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctl_binswap);
            this.Controls.Add(this.ctl_binsearch);
            this.Controls.Add(this.lvResults);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmBinSwapper";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bin Swapper";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NewMethod.nList lvResults;
        private NewMethod.nEdit_String ctl_binsearch;
        private NewMethod.nEdit_String ctl_binswap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.Button cmdSwap;
    }
}