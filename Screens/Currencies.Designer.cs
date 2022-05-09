namespace RzInterfaceWin.Screens
{
    partial class Currencies
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
            this.lst = new NewMethod.nList();
            this.pInstance = new System.Windows.Forms.Panel();
            this.okButton = new System.Windows.Forms.Button();
            this.ctl_exchange_rate = new NewMethod.nEdit_Number();
            this.ctl_symbol = new NewMethod.nEdit_String();
            this.ctl_name = new NewMethod.nEdit_String();
            this.pTop = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.symbolLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.ts = new System.Windows.Forms.TabControl();
            this.tabCurrency = new System.Windows.Forms.TabPage();
            this.tabCurrencyConversion = new System.Windows.Forms.TabPage();
            this.wb = new ToolsWin.BrowserPlain();
            this.pInstance.SuspendLayout();
            this.pTop.SuspendLayout();
            this.ts.SuspendLayout();
            this.tabCurrency.SuspendLayout();
            this.tabCurrencyConversion.SuspendLayout();
            this.SuspendLayout();
            // 
            // lst
            // 
            this.lst.AddCaption = "Add New Currency";
            this.lst.AllowActions = true;
            this.lst.AllowAdd = true;
            this.lst.AllowDelete = true;
            this.lst.AllowDeleteAlways = false;
            this.lst.AllowDrop = true;
            this.lst.AllowOnlyOpenDelete = false;
            this.lst.AlternateConnection = null;
            this.lst.BackColor = System.Drawing.Color.White;
            this.lst.Caption = "Currencies";
            this.lst.CurrentTemplate = null;
            this.lst.ExtraClassInfo = "";
            this.lst.Location = new System.Drawing.Point(7, 102);
            this.lst.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.lst.MultiSelect = true;
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(617, 192);
            this.lst.SuppressSelectionChanged = false;
            this.lst.TabIndex = 0;
            this.lst.zz_OpenColumnMenu = false;
            this.lst.zz_OrderLineType = "";
            this.lst.zz_ShowAutoRefresh = true;
            this.lst.zz_ShowUnlimited = true;
            this.lst.AboutToThrow += new Core.ShowHandler(this.lst_AboutToThrow);
            this.lst.AboutToAdd += new NewMethod.AddHandler(this.lst_AboutToAdd);
            // 
            // pInstance
            // 
            this.pInstance.BackColor = System.Drawing.Color.White;
            this.pInstance.Controls.Add(this.okButton);
            this.pInstance.Controls.Add(this.ctl_exchange_rate);
            this.pInstance.Controls.Add(this.ctl_symbol);
            this.pInstance.Controls.Add(this.ctl_name);
            this.pInstance.Location = new System.Drawing.Point(7, 303);
            this.pInstance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pInstance.Name = "pInstance";
            this.pInstance.Size = new System.Drawing.Size(617, 54);
            this.pInstance.TabIndex = 1;
            this.pInstance.Visible = false;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(480, 7);
            this.okButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(89, 43);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // ctl_exchange_rate
            // 
            this.ctl_exchange_rate.BackColor = System.Drawing.Color.White;
            this.ctl_exchange_rate.Bold = false;
            this.ctl_exchange_rate.Caption = "Rate";
            this.ctl_exchange_rate.Changed = false;
            this.ctl_exchange_rate.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_exchange_rate.Location = new System.Drawing.Point(253, 4);
            this.ctl_exchange_rate.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_exchange_rate.Name = "ctl_exchange_rate";
            this.ctl_exchange_rate.Size = new System.Drawing.Size(103, 42);
            this.ctl_exchange_rate.TabIndex = 2;
            this.ctl_exchange_rate.UseParentBackColor = true;
            this.ctl_exchange_rate.zz_Enabled = true;
            this.ctl_exchange_rate.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_exchange_rate.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_exchange_rate.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_exchange_rate.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_exchange_rate.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_exchange_rate.zz_OriginalDesign = false;
            this.ctl_exchange_rate.zz_ShowErrorColor = true;
            this.ctl_exchange_rate.zz_ShowNeedsSaveColor = true;
            this.ctl_exchange_rate.zz_Text = "";
            this.ctl_exchange_rate.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_exchange_rate.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_exchange_rate.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_exchange_rate.zz_UseGlobalColor = false;
            this.ctl_exchange_rate.zz_UseGlobalFont = false;
            // 
            // ctl_symbol
            // 
            this.ctl_symbol.AllCaps = false;
            this.ctl_symbol.BackColor = System.Drawing.Color.White;
            this.ctl_symbol.Bold = false;
            this.ctl_symbol.Caption = "Symbol";
            this.ctl_symbol.Changed = false;
            this.ctl_symbol.IsEmail = false;
            this.ctl_symbol.IsURL = false;
            this.ctl_symbol.Location = new System.Drawing.Point(364, 4);
            this.ctl_symbol.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_symbol.Name = "ctl_symbol";
            this.ctl_symbol.PasswordChar = '\0';
            this.ctl_symbol.Size = new System.Drawing.Size(96, 42);
            this.ctl_symbol.TabIndex = 1;
            this.ctl_symbol.UseParentBackColor = true;
            this.ctl_symbol.zz_Enabled = true;
            this.ctl_symbol.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_symbol.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_symbol.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_symbol.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_symbol.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_symbol.zz_OriginalDesign = false;
            this.ctl_symbol.zz_ShowLinkButton = false;
            this.ctl_symbol.zz_ShowNeedsSaveColor = true;
            this.ctl_symbol.zz_Text = "";
            this.ctl_symbol.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_symbol.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_symbol.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_symbol.zz_UseGlobalColor = false;
            this.ctl_symbol.zz_UseGlobalFont = false;
            // 
            // ctl_name
            // 
            this.ctl_name.AllCaps = false;
            this.ctl_name.BackColor = System.Drawing.Color.White;
            this.ctl_name.Bold = false;
            this.ctl_name.Caption = "Name";
            this.ctl_name.Changed = false;
            this.ctl_name.IsEmail = false;
            this.ctl_name.IsURL = false;
            this.ctl_name.Location = new System.Drawing.Point(4, 4);
            this.ctl_name.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctl_name.Name = "ctl_name";
            this.ctl_name.PasswordChar = '\0';
            this.ctl_name.Size = new System.Drawing.Size(241, 42);
            this.ctl_name.TabIndex = 0;
            this.ctl_name.UseParentBackColor = true;
            this.ctl_name.zz_Enabled = true;
            this.ctl_name.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_name.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_name.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_name.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_name.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_name.zz_OriginalDesign = false;
            this.ctl_name.zz_ShowLinkButton = false;
            this.ctl_name.zz_ShowNeedsSaveColor = true;
            this.ctl_name.zz_Text = "";
            this.ctl_name.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_name.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_name.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_name.zz_UseGlobalColor = false;
            this.ctl_name.zz_UseGlobalFont = false;
            // 
            // pTop
            // 
            this.pTop.Controls.Add(this.label2);
            this.pTop.Controls.Add(this.label1);
            this.pTop.Controls.Add(this.symbolLabel);
            this.pTop.Controls.Add(this.nameLabel);
            this.pTop.Location = new System.Drawing.Point(7, 7);
            this.pTop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pTop.Name = "pTop";
            this.pTop.Size = new System.Drawing.Size(617, 86);
            this.pTop.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(4, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(289, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Base currency symbol:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(4, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Base currency name:";
            // 
            // symbolLabel
            // 
            this.symbolLabel.AutoSize = true;
            this.symbolLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.symbolLabel.Location = new System.Drawing.Point(319, 43);
            this.symbolLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.symbolLabel.Name = "symbolLabel";
            this.symbolLabel.Size = new System.Drawing.Size(29, 31);
            this.symbolLabel.TabIndex = 1;
            this.symbolLabel.Text = "$";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(319, 12);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(72, 31);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "USD";
            // 
            // ts
            // 
            this.ts.Controls.Add(this.tabCurrency);
            this.ts.Controls.Add(this.tabCurrencyConversion);
            this.ts.Location = new System.Drawing.Point(22, 13);
            this.ts.Name = "ts";
            this.ts.SelectedIndex = 0;
            this.ts.Size = new System.Drawing.Size(639, 390);
            this.ts.TabIndex = 3;
            // 
            // tabCurrency
            // 
            this.tabCurrency.Controls.Add(this.pTop);
            this.tabCurrency.Controls.Add(this.lst);
            this.tabCurrency.Controls.Add(this.pInstance);
            this.tabCurrency.Location = new System.Drawing.Point(4, 25);
            this.tabCurrency.Name = "tabCurrency";
            this.tabCurrency.Padding = new System.Windows.Forms.Padding(3);
            this.tabCurrency.Size = new System.Drawing.Size(631, 361);
            this.tabCurrency.TabIndex = 0;
            this.tabCurrency.Text = "Currency";
            this.tabCurrency.UseVisualStyleBackColor = true;
            // 
            // tabCurrencyConversion
            // 
            this.tabCurrencyConversion.Controls.Add(this.wb);
            this.tabCurrencyConversion.Location = new System.Drawing.Point(4, 25);
            this.tabCurrencyConversion.Name = "tabCurrencyConversion";
            this.tabCurrencyConversion.Padding = new System.Windows.Forms.Padding(3);
            this.tabCurrencyConversion.Size = new System.Drawing.Size(631, 361);
            this.tabCurrencyConversion.TabIndex = 1;
            this.tabCurrencyConversion.Text = "Currency Conversion";
            this.tabCurrencyConversion.UseVisualStyleBackColor = true;
            // 
            // wb
            // 
            this.wb.BackColor = System.Drawing.Color.White;
            this.wb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wb.Location = new System.Drawing.Point(3, 3);
            this.wb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.wb.Name = "wb";
            this.wb.ShowControls = false;
            this.wb.Silent = false;
            this.wb.Size = new System.Drawing.Size(625, 355);
            this.wb.TabIndex = 0;
            // 
            // Currencies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ts);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Currencies";
            this.Size = new System.Drawing.Size(1018, 463);
            this.Load += new System.EventHandler(this.Currencies_Load);
            this.Resize += new System.EventHandler(this.Currencies_Resize);
            this.pInstance.ResumeLayout(false);
            this.pTop.ResumeLayout(false);
            this.pTop.PerformLayout();
            this.ts.ResumeLayout(false);
            this.tabCurrency.ResumeLayout(false);
            this.tabCurrencyConversion.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private NewMethod.nList lst;
        private System.Windows.Forms.Panel pInstance;
        private System.Windows.Forms.Button okButton;
        private NewMethod.nEdit_Number ctl_exchange_rate;
        private NewMethod.nEdit_String ctl_symbol;
        private NewMethod.nEdit_String ctl_name;
        private System.Windows.Forms.Panel pTop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label symbolLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TabControl ts;
        private System.Windows.Forms.TabPage tabCurrency;
        private System.Windows.Forms.TabPage tabCurrencyConversion;
        private ToolsWin.BrowserPlain wb;
    }
}
