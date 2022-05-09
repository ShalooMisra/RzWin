namespace Rz5
{
    partial class frmTermsPDFFileAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTermsPDFFileAdd));
            this.cmdView = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.txtTemplate = new NewMethod.nEdit_String();
            this.oFile = new System.Windows.Forms.OpenFileDialog();
            this.optInvoice = new System.Windows.Forms.RadioButton();
            this.optQuote = new System.Windows.Forms.RadioButton();
            this.optPurchase = new System.Windows.Forms.RadioButton();
            this.lv = new NewMethod.nList();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdView
            // 
            this.cmdView.Location = new System.Drawing.Point(148, 355);
            this.cmdView.Name = "cmdView";
            this.cmdView.Size = new System.Drawing.Size(135, 23);
            this.cmdView.TabIndex = 0;
            this.cmdView.Text = "View";
            this.cmdView.UseVisualStyleBackColor = true;
            this.cmdView.Click += new System.EventHandler(this.cmdViewInvoice_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(12, 355);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(135, 23);
            this.cmdAdd.TabIndex = 1;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAddInvoice_Click);
            // 
            // txtTemplate
            // 
            this.txtTemplate.AllCaps = false;
            this.txtTemplate.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtTemplate.Bold = false;
            this.txtTemplate.Caption = "Selected Template";
            this.txtTemplate.Changed = false;
            this.txtTemplate.IsEmail = false;
            this.txtTemplate.IsURL = false;
            this.txtTemplate.Location = new System.Drawing.Point(12, 35);
            this.txtTemplate.Name = "txtTemplate";
            this.txtTemplate.PasswordChar = '\0';
            this.txtTemplate.Size = new System.Drawing.Size(271, 40);
            this.txtTemplate.TabIndex = 2;
            this.txtTemplate.UseParentBackColor = false;
            this.txtTemplate.zz_Enabled = true;
            this.txtTemplate.zz_GlobalColor = System.Drawing.Color.Black;
            this.txtTemplate.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtTemplate.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.txtTemplate.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTemplate.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.txtTemplate.zz_OriginalDesign = true;
            this.txtTemplate.zz_ShowLinkButton = false;
            this.txtTemplate.zz_ShowNeedsSaveColor = true;
            this.txtTemplate.zz_Text = "";
            this.txtTemplate.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTemplate.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.txtTemplate.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTemplate.zz_UseGlobalColor = false;
            this.txtTemplate.zz_UseGlobalFont = false;
            // 
            // oFile
            // 
            this.oFile.FileName = "openFileDialog1";
            // 
            // optInvoice
            // 
            this.optInvoice.AutoSize = true;
            this.optInvoice.Location = new System.Drawing.Point(183, 12);
            this.optInvoice.Name = "optInvoice";
            this.optInvoice.Size = new System.Drawing.Size(60, 17);
            this.optInvoice.TabIndex = 9;
            this.optInvoice.Text = "Invoice";
            this.optInvoice.UseVisualStyleBackColor = true;
            this.optInvoice.CheckedChanged += new System.EventHandler(this.optInvoice_CheckedChanged);
            // 
            // optQuote
            // 
            this.optQuote.AutoSize = true;
            this.optQuote.Checked = true;
            this.optQuote.Location = new System.Drawing.Point(12, 12);
            this.optQuote.Name = "optQuote";
            this.optQuote.Size = new System.Drawing.Size(54, 17);
            this.optQuote.TabIndex = 10;
            this.optQuote.TabStop = true;
            this.optQuote.Text = "Quote";
            this.optQuote.UseVisualStyleBackColor = true;
            this.optQuote.CheckedChanged += new System.EventHandler(this.optQuote_CheckedChanged);
            // 
            // optPurchase
            // 
            this.optPurchase.AutoSize = true;
            this.optPurchase.Location = new System.Drawing.Point(78, 12);
            this.optPurchase.Name = "optPurchase";
            this.optPurchase.Size = new System.Drawing.Size(99, 17);
            this.optPurchase.TabIndex = 11;
            this.optPurchase.Text = "Purchase Order";
            this.optPurchase.UseVisualStyleBackColor = true;
            this.optPurchase.CheckedChanged += new System.EventHandler(this.optPurchase_CheckedChanged);
            // 
            // lv
            // 
            this.lv.AddCaption = "Add New";
            this.lv.AllowActions = true;
            this.lv.AllowAdd = false;
            this.lv.AllowDelete = true;
            this.lv.AllowDeleteAlways = false;
            this.lv.AllowDrop = true;
            this.lv.AlternateConnection = null;
            this.lv.Caption = "";
            this.lv.CurrentTemplate = null;
            this.lv.ExtraClassInfo = "";
            this.lv.Location = new System.Drawing.Point(12, 81);
            this.lv.MultiSelect = true;
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(271, 268);
            this.lv.SuppressSelectionChanged = false;
            this.lv.TabIndex = 12;
            this.lv.zz_OpenColumnMenu = false;
            this.lv.zz_OrderLineType = "";
            this.lv.zz_ShowAutoRefresh = true;
            this.lv.zz_ShowUnlimited = true;
            this.lv.AboutToThrow += new Core.ShowHandler(this.lv_AboutToThrow);
            this.lv.ObjectClicked += new NewMethod.ObjectClickHandler(this.lv_ObjectClicked);
            // 
            // cmdRemove
            // 
            this.cmdRemove.Location = new System.Drawing.Point(224, 35);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(59, 19);
            this.cmdRemove.TabIndex = 13;
            this.cmdRemove.Text = "Remove";
            this.cmdRemove.UseVisualStyleBackColor = true;
            this.cmdRemove.Visible = false;
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // frmTermsPDFFileAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 385);
            this.Controls.Add(this.cmdRemove);
            this.Controls.Add(this.lv);
            this.Controls.Add(this.optPurchase);
            this.Controls.Add(this.optQuote);
            this.Controls.Add(this.optInvoice);
            this.Controls.Add(this.txtTemplate);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.cmdView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTermsPDFFileAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Terms And Conditions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdView;
        private System.Windows.Forms.Button cmdAdd;
        private NewMethod.nEdit_String txtTemplate;
        private System.Windows.Forms.OpenFileDialog oFile;
        private System.Windows.Forms.RadioButton optInvoice;
        private System.Windows.Forms.RadioButton optQuote;
        private System.Windows.Forms.RadioButton optPurchase;
        private NewMethod.nList lv;
        private System.Windows.Forms.Button cmdRemove;
    }
}