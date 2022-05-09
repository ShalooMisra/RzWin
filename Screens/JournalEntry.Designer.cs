namespace RzInterfaceWin.Screens
{
    partial class JournalEntry
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
            this.top = new System.Windows.Forms.Panel();
            this.warningLabel = new System.Windows.Forms.Label();
            this.memo = new NewMethod.nEdit_String();
            this.entryDate = new NewMethod.nEdit_Date();
            this.saveButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.lv = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.edit = new System.Windows.Forms.Panel();
            this.okButton = new System.Windows.Forms.Button();
            this.creditEntry = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.debitEntry = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.accountSelection = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.top.SuspendLayout();
            this.edit.SuspendLayout();
            this.SuspendLayout();
            // 
            // top
            // 
            this.top.BackColor = System.Drawing.Color.White;
            this.top.Controls.Add(this.warningLabel);
            this.top.Controls.Add(this.memo);
            this.top.Controls.Add(this.entryDate);
            this.top.Controls.Add(this.saveButton);
            this.top.Controls.Add(this.clearButton);
            this.top.Location = new System.Drawing.Point(3, 3);
            this.top.Name = "top";
            this.top.Size = new System.Drawing.Size(988, 78);
            this.top.TabIndex = 3;
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warningLabel.ForeColor = System.Drawing.Color.Maroon;
            this.warningLabel.Location = new System.Drawing.Point(626, 49);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(149, 15);
            this.warningLabel.TabIndex = 11;
            this.warningLabel.Text = "this is a warning message";
            this.warningLabel.Visible = false;
            // 
            // memo
            // 
            this.memo.AllCaps = false;
            this.memo.BackColor = System.Drawing.Color.White;
            this.memo.Bold = false;
            this.memo.Caption = "Memo";
            this.memo.Changed = false;
            this.memo.IsEmail = false;
            this.memo.IsURL = false;
            this.memo.Location = new System.Drawing.Point(232, 20);
            this.memo.Name = "memo";
            this.memo.PasswordChar = '\0';
            this.memo.Size = new System.Drawing.Size(333, 48);
            this.memo.TabIndex = 10;
            this.memo.UseParentBackColor = true;
            this.memo.zz_Enabled = true;
            this.memo.zz_GlobalColor = System.Drawing.Color.Black;
            this.memo.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.memo.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.memo.zz_LabelFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memo.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.memo.zz_OriginalDesign = false;
            this.memo.zz_ShowLinkButton = false;
            this.memo.zz_ShowNeedsSaveColor = true;
            this.memo.zz_Text = "";
            this.memo.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.memo.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.memo.zz_TextFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memo.zz_UseGlobalColor = false;
            this.memo.zz_UseGlobalFont = false;
            this.memo.DataChanged += new NewMethod.ChangeHandler(this.memo_DataChanged);
            // 
            // entryDate
            // 
            this.entryDate.AllowClear = false;
            this.entryDate.BackColor = System.Drawing.Color.White;
            this.entryDate.Bold = false;
            this.entryDate.Caption = "Entry Date";
            this.entryDate.Changed = false;
            this.entryDate.Location = new System.Drawing.Point(60, 17);
            this.entryDate.Name = "entryDate";
            this.entryDate.Size = new System.Drawing.Size(166, 54);
            this.entryDate.SuppressEdit = false;
            this.entryDate.TabIndex = 2;
            this.entryDate.UseParentBackColor = true;
            this.entryDate.zz_GlobalColor = System.Drawing.Color.Black;
            this.entryDate.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.entryDate.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.entryDate.zz_LabelFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entryDate.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopLeft;
            this.entryDate.zz_OriginalDesign = false;
            this.entryDate.zz_ShowNeedsSaveColor = true;
            this.entryDate.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.entryDate.zz_TextFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entryDate.zz_UseGlobalColor = false;
            this.entryDate.zz_UseGlobalFont = false;
            this.entryDate.DataChanged += new NewMethod.ChangeHandler(this.entryDate_DataChanged);
            // 
            // saveButton
            // 
            this.saveButton.BackgroundImage = global::RzInterfaceWin.Properties.Resources.GreenCheck;
            this.saveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.saveButton.Enabled = false;
            this.saveButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(571, 3);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(49, 65);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.BackgroundImage = global::RzInterfaceWin.Properties.Resources.RefreshBlue3;
            this.clearButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.clearButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.Location = new System.Drawing.Point(3, 3);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(52, 65);
            this.clearButton.TabIndex = 0;
            this.clearButton.Text = "Reset";
            this.clearButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // lv
            // 
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader6,
            this.columnHeader7});
            this.lv.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv.FullRowSelect = true;
            this.lv.HideSelection = false;
            this.lv.Location = new System.Drawing.Point(3, 87);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(826, 426);
            this.lv.TabIndex = 2;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.DoubleClick += new System.EventHandler(this.lv_DoubleClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Account";
            this.columnHeader3.Width = 350;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Debit";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader6.Width = 128;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Credit";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader7.Width = 124;
            // 
            // edit
            // 
            this.edit.BackColor = System.Drawing.Color.Gainsboro;
            this.edit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edit.Controls.Add(this.okButton);
            this.edit.Controls.Add(this.creditEntry);
            this.edit.Controls.Add(this.label3);
            this.edit.Controls.Add(this.debitEntry);
            this.edit.Controls.Add(this.label2);
            this.edit.Controls.Add(this.accountSelection);
            this.edit.Controls.Add(this.label1);
            this.edit.Location = new System.Drawing.Point(6, 537);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(624, 71);
            this.edit.TabIndex = 4;
            this.edit.Visible = false;
            // 
            // okButton
            // 
            this.okButton.Enabled = false;
            this.okButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okButton.Location = new System.Drawing.Point(579, 18);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(36, 39);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // creditEntry
            // 
            this.creditEntry.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creditEntry.Location = new System.Drawing.Point(448, 31);
            this.creditEntry.Name = "creditEntry";
            this.creditEntry.Size = new System.Drawing.Size(122, 27);
            this.creditEntry.TabIndex = 5;
            this.creditEntry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.creditEntry.TextChanged += new System.EventHandler(this.creditEntry_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(444, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Credit:";
            // 
            // debitEntry
            // 
            this.debitEntry.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.debitEntry.Location = new System.Drawing.Point(320, 31);
            this.debitEntry.Name = "debitEntry";
            this.debitEntry.Size = new System.Drawing.Size(122, 27);
            this.debitEntry.TabIndex = 3;
            this.debitEntry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.debitEntry.TextChanged += new System.EventHandler(this.debitEntry_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(316, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Debit:";
            // 
            // accountSelection
            // 
            this.accountSelection.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountSelection.FormattingEnabled = true;
            this.accountSelection.Location = new System.Drawing.Point(9, 31);
            this.accountSelection.Name = "accountSelection";
            this.accountSelection.Size = new System.Drawing.Size(295, 27);
            this.accountSelection.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account:";
            // 
            // JournalEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.edit);
            this.Controls.Add(this.top);
            this.Controls.Add(this.lv);
            this.Name = "JournalEntry";
            this.Size = new System.Drawing.Size(1107, 666);
            this.Resize += new System.EventHandler(this.JournalEntry_Resize);
            this.top.ResumeLayout(false);
            this.top.PerformLayout();
            this.edit.ResumeLayout(false);
            this.edit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel top;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.ListView lv;
        private NewMethod.nEdit_Date entryDate;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private NewMethod.nEdit_String memo;
        private System.Windows.Forms.Panel edit;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox creditEntry;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox debitEntry;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox accountSelection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label warningLabel;
    }
}
