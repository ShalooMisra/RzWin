namespace Rz5
{
    partial class SplitCommission
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
            this.gbStandardSplit = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.gb_split_agent = new System.Windows.Forms.GroupBox();
            this.lblAgent = new System.Windows.Forms.LinkLabel();
            this.btnSave = new System.Windows.Forms.Button();
            this.ctl_split_commission_amnt = new NewMethod.nEdit_Number();
            this.lblMaxSplitLabel = new System.Windows.Forms.Label();
            this.lblCurrentSplitLabel = new System.Windows.Forms.Label();
            this.lblListAquisitionLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStandardSplit = new System.Windows.Forms.Label();
            this.lblListAquisition = new System.Windows.Forms.Label();
            this.lblMaxSplit = new System.Windows.Forms.Label();
            this.lblCurrentSplit = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ctl_ListAcquisitionAgent = new NewMethod.nEdit_String();
            this.ctl_split_type = new NewMethod.nEdit_List();
            this.gbStandardSplit.SuspendLayout();
            this.gb_split_agent.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbStandardSplit
            // 
            this.gbStandardSplit.BackColor = System.Drawing.Color.Transparent;
            this.gbStandardSplit.Controls.Add(this.ctl_split_type);
            this.gbStandardSplit.Controls.Add(this.btnDelete);
            this.gbStandardSplit.Controls.Add(this.gb_split_agent);
            this.gbStandardSplit.Controls.Add(this.btnSave);
            this.gbStandardSplit.Controls.Add(this.ctl_split_commission_amnt);
            this.gbStandardSplit.Location = new System.Drawing.Point(13, 74);
            this.gbStandardSplit.Name = "gbStandardSplit";
            this.gbStandardSplit.Size = new System.Drawing.Size(394, 108);
            this.gbStandardSplit.TabIndex = 77;
            this.gbStandardSplit.TabStop = false;
            this.gbStandardSplit.Text = "Split Commission";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(277, 73);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(84, 26);
            this.btnDelete.TabIndex = 82;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // gb_split_agent
            // 
            this.gb_split_agent.Controls.Add(this.lblAgent);
            this.gb_split_agent.Location = new System.Drawing.Point(24, 28);
            this.gb_split_agent.Name = "gb_split_agent";
            this.gb_split_agent.Size = new System.Drawing.Size(147, 35);
            this.gb_split_agent.TabIndex = 81;
            this.gb_split_agent.TabStop = false;
            this.gb_split_agent.Text = "Split Agent";
            // 
            // lblAgent
            // 
            this.lblAgent.AutoSize = true;
            this.lblAgent.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgent.Location = new System.Drawing.Point(7, 16);
            this.lblAgent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAgent.Name = "lblAgent";
            this.lblAgent.Size = new System.Drawing.Size(71, 15);
            this.lblAgent.TabIndex = 17;
            this.lblAgent.TabStop = true;
            this.lblAgent.Text = "<Choose ...>";
            this.lblAgent.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAgent_LinkClicked);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(24, 73);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(147, 26);
            this.btnSave.TabIndex = 78;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ctl_split_commission_amnt
            // 
            this.ctl_split_commission_amnt.BackColor = System.Drawing.Color.Transparent;
            this.ctl_split_commission_amnt.Bold = false;
            this.ctl_split_commission_amnt.Caption = "Split Percent";
            this.ctl_split_commission_amnt.Changed = true;
            this.ctl_split_commission_amnt.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_split_commission_amnt.Location = new System.Drawing.Point(304, 18);
            this.ctl_split_commission_amnt.Name = "ctl_split_commission_amnt";
            this.ctl_split_commission_amnt.Size = new System.Drawing.Size(84, 48);
            this.ctl_split_commission_amnt.TabIndex = 79;
            this.ctl_split_commission_amnt.UseParentBackColor = false;
            this.ctl_split_commission_amnt.zz_Enabled = true;
            this.ctl_split_commission_amnt.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_split_commission_amnt.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_split_commission_amnt.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_split_commission_amnt.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_split_commission_amnt.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_split_commission_amnt.zz_OriginalDesign = true;
            this.ctl_split_commission_amnt.zz_ShowErrorColor = true;
            this.ctl_split_commission_amnt.zz_ShowNeedsSaveColor = true;
            this.ctl_split_commission_amnt.zz_Text = "";
            this.ctl_split_commission_amnt.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_split_commission_amnt.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_split_commission_amnt.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_split_commission_amnt.zz_UseGlobalColor = false;
            this.ctl_split_commission_amnt.zz_UseGlobalFont = false;
            // 
            // lblMaxSplitLabel
            // 
            this.lblMaxSplitLabel.AutoSize = true;
            this.lblMaxSplitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxSplitLabel.Location = new System.Drawing.Point(198, 17);
            this.lblMaxSplitLabel.Name = "lblMaxSplitLabel";
            this.lblMaxSplitLabel.Size = new System.Drawing.Size(83, 17);
            this.lblMaxSplitLabel.TabIndex = 78;
            this.lblMaxSplitLabel.Text = "Max. Split:";
            // 
            // lblCurrentSplitLabel
            // 
            this.lblCurrentSplitLabel.AutoSize = true;
            this.lblCurrentSplitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentSplitLabel.Location = new System.Drawing.Point(10, 17);
            this.lblCurrentSplitLabel.Name = "lblCurrentSplitLabel";
            this.lblCurrentSplitLabel.Size = new System.Drawing.Size(104, 17);
            this.lblCurrentSplitLabel.TabIndex = 79;
            this.lblCurrentSplitLabel.Text = "Current Split:";
            // 
            // lblListAquisitionLabel
            // 
            this.lblListAquisitionLabel.AutoSize = true;
            this.lblListAquisitionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListAquisitionLabel.Location = new System.Drawing.Point(198, 42);
            this.lblListAquisitionLabel.Name = "lblListAquisitionLabel";
            this.lblListAquisitionLabel.Size = new System.Drawing.Size(106, 17);
            this.lblListAquisitionLabel.TabIndex = 80;
            this.lblListAquisitionLabel.Text = "List Acquisition:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 81;
            this.label1.Text = "Standard Split:";
            // 
            // lblStandardSplit
            // 
            this.lblStandardSplit.AutoSize = true;
            this.lblStandardSplit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStandardSplit.Location = new System.Drawing.Point(120, 42);
            this.lblStandardSplit.Name = "lblStandardSplit";
            this.lblStandardSplit.Size = new System.Drawing.Size(28, 17);
            this.lblStandardSplit.TabIndex = 82;
            this.lblStandardSplit.Text = "0%";
            // 
            // lblListAquisition
            // 
            this.lblListAquisition.AutoSize = true;
            this.lblListAquisition.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListAquisition.Location = new System.Drawing.Point(310, 42);
            this.lblListAquisition.Name = "lblListAquisition";
            this.lblListAquisition.Size = new System.Drawing.Size(28, 17);
            this.lblListAquisition.TabIndex = 83;
            this.lblListAquisition.Text = "0%";
            // 
            // lblMaxSplit
            // 
            this.lblMaxSplit.AutoSize = true;
            this.lblMaxSplit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxSplit.Location = new System.Drawing.Point(287, 17);
            this.lblMaxSplit.Name = "lblMaxSplit";
            this.lblMaxSplit.Size = new System.Drawing.Size(28, 17);
            this.lblMaxSplit.TabIndex = 84;
            this.lblMaxSplit.Text = "0%";
            // 
            // lblCurrentSplit
            // 
            this.lblCurrentSplit.AutoSize = true;
            this.lblCurrentSplit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentSplit.Location = new System.Drawing.Point(120, 16);
            this.lblCurrentSplit.Name = "lblCurrentSplit";
            this.lblCurrentSplit.Size = new System.Drawing.Size(28, 17);
            this.lblCurrentSplit.TabIndex = 85;
            this.lblCurrentSplit.Text = "0%";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.lblCurrentSplit);
            this.groupBox1.Controls.Add(this.lblListAquisitionLabel);
            this.groupBox1.Controls.Add(this.lblMaxSplit);
            this.groupBox1.Controls.Add(this.lblListAquisition);
            this.groupBox1.Controls.Add(this.lblStandardSplit);
            this.groupBox1.Controls.Add(this.lblMaxSplitLabel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 254);
            this.groupBox1.TabIndex = 86;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Commissions";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ctl_ListAcquisitionAgent);
            this.groupBox2.Location = new System.Drawing.Point(13, 185);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(242, 62);
            this.groupBox2.TabIndex = 88;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "List Acquisition";
            // 
            // ctl_ListAcquisitionAgent
            // 
            this.ctl_ListAcquisitionAgent.AllCaps = false;
            this.ctl_ListAcquisitionAgent.BackColor = System.Drawing.Color.Transparent;
            this.ctl_ListAcquisitionAgent.Bold = false;
            this.ctl_ListAcquisitionAgent.Caption = "List Acquisition Agent (View Only)";
            this.ctl_ListAcquisitionAgent.Changed = true;
            this.ctl_ListAcquisitionAgent.Enabled = false;
            this.ctl_ListAcquisitionAgent.IsEmail = false;
            this.ctl_ListAcquisitionAgent.IsURL = false;
            this.ctl_ListAcquisitionAgent.Location = new System.Drawing.Point(14, 21);
            this.ctl_ListAcquisitionAgent.Name = "ctl_ListAcquisitionAgent";
            this.ctl_ListAcquisitionAgent.PasswordChar = '\0';
            this.ctl_ListAcquisitionAgent.Size = new System.Drawing.Size(222, 35);
            this.ctl_ListAcquisitionAgent.TabIndex = 1;
            this.ctl_ListAcquisitionAgent.UseParentBackColor = false;
            this.ctl_ListAcquisitionAgent.zz_Enabled = true;
            this.ctl_ListAcquisitionAgent.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_ListAcquisitionAgent.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_ListAcquisitionAgent.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_ListAcquisitionAgent.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_ListAcquisitionAgent.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_ListAcquisitionAgent.zz_OriginalDesign = false;
            this.ctl_ListAcquisitionAgent.zz_ShowLinkButton = false;
            this.ctl_ListAcquisitionAgent.zz_ShowNeedsSaveColor = true;
            this.ctl_ListAcquisitionAgent.zz_Text = "N/A";
            this.ctl_ListAcquisitionAgent.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_ListAcquisitionAgent.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_ListAcquisitionAgent.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_ListAcquisitionAgent.zz_UseGlobalColor = false;
            this.ctl_ListAcquisitionAgent.zz_UseGlobalFont = false;
            // 
            // ctl_split_type
            // 
            this.ctl_split_type.AllCaps = false;
            this.ctl_split_type.AllowEdit = false;
            this.ctl_split_type.BackColor = System.Drawing.Color.Transparent;
            this.ctl_split_type.Bold = false;
            this.ctl_split_type.Caption = "Split Type";
            this.ctl_split_type.Changed = false;
            this.ctl_split_type.ListName = "SplitCommissionType";
            this.ctl_split_type.Location = new System.Drawing.Point(177, 24);
            this.ctl_split_type.Name = "ctl_split_type";
            this.ctl_split_type.SimpleList = null;
            this.ctl_split_type.Size = new System.Drawing.Size(114, 36);
            this.ctl_split_type.TabIndex = 83;
            this.ctl_split_type.UseParentBackColor = false;
            this.ctl_split_type.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_split_type.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_split_type.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_split_type.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_split_type.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_split_type.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_split_type.zz_OriginalDesign = false;
            this.ctl_split_type.zz_ShowNeedsSaveColor = true;
            this.ctl_split_type.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_split_type.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_split_type.zz_UseGlobalColor = false;
            this.ctl_split_type.zz_UseGlobalFont = false;
            this.ctl_split_type.SelectionChanged += new NewMethod.nEdit_List.SelectionChangedHandler(this.ctl_split_type_SelectionChanged);
            // 
            // SplitCommission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbStandardSplit);
            this.Controls.Add(this.lblCurrentSplitLabel);
            this.Controls.Add(this.groupBox1);
            this.Name = "SplitCommission";
            this.Size = new System.Drawing.Size(416, 256);
            this.gbStandardSplit.ResumeLayout(false);
            this.gb_split_agent.ResumeLayout(false);
            this.gb_split_agent.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbStandardSplit;
        private NewMethod.nEdit_Number ctl_split_commission_amnt;
        private System.Windows.Forms.GroupBox gb_split_agent;
        private System.Windows.Forms.LinkLabel lblAgent;
        private System.Windows.Forms.Label lblMaxSplitLabel;
        private System.Windows.Forms.Label lblCurrentSplitLabel;
        private System.Windows.Forms.Label lblListAquisitionLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStandardSplit;
        private System.Windows.Forms.Label lblListAquisition;
        private System.Windows.Forms.Label lblMaxSplit;
        private System.Windows.Forms.Label lblCurrentSplit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private NewMethod.nEdit_String ctl_ListAcquisitionAgent;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private NewMethod.nEdit_List ctl_split_type;
    }
}
