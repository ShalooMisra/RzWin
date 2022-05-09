using Tools.Database;
namespace Rz5.Win.Controls
{
    partial class Packing
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
            this.gbPack = new System.Windows.Forms.GroupBox();
            this.ctl_PackPackaging = new NewMethod.nEdit_List();
            this.ctl_PackCondition = new NewMethod.nEdit_List();
            this.ctl_PackLocation = new NewMethod.nEdit_String();
            this.ctl_PackMFG = new NewMethod.nEdit_String();
            this.ctl_PackQuantity = new NewMethod.nEdit_Number();
            this.ctl_PackDC = new NewMethod.nEdit_String();
            this.txtSplitAlert = new System.Windows.Forms.TextBox();
            this.ctl_PackLotNum = new NewMethod.nEdit_String();
            this.ctl_PackBoxNum = new NewMethod.nEdit_String();
            this.cmdPackOK = new System.Windows.Forms.Button();
            this.lvPack = new NewMethod.nList();
            this.gbPack.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPack
            // 
            this.gbPack.BackColor = System.Drawing.Color.White;
            this.gbPack.Controls.Add(this.ctl_PackPackaging);
            this.gbPack.Controls.Add(this.ctl_PackCondition);
            this.gbPack.Controls.Add(this.ctl_PackLocation);
            this.gbPack.Controls.Add(this.ctl_PackMFG);
            this.gbPack.Controls.Add(this.ctl_PackQuantity);
            this.gbPack.Controls.Add(this.ctl_PackDC);
            this.gbPack.Controls.Add(this.txtSplitAlert);
            this.gbPack.Controls.Add(this.ctl_PackLotNum);
            this.gbPack.Controls.Add(this.ctl_PackBoxNum);
            this.gbPack.Controls.Add(this.cmdPackOK);
            this.gbPack.Location = new System.Drawing.Point(3, 295);
            this.gbPack.Name = "gbPack";
            this.gbPack.Size = new System.Drawing.Size(574, 196);
            this.gbPack.TabIndex = 3;
            this.gbPack.TabStop = false;
            // 
            // ctl_PackPackaging
            // 
            this.ctl_PackPackaging.AllCaps = false;
            this.ctl_PackPackaging.AllowEdit = false;
            this.ctl_PackPackaging.BackColor = System.Drawing.Color.Transparent;
            this.ctl_PackPackaging.Bold = false;
            this.ctl_PackPackaging.Caption = "Packaging";
            this.ctl_PackPackaging.Changed = false;
            this.ctl_PackPackaging.ListName = "packaging";
            this.ctl_PackPackaging.Location = new System.Drawing.Point(6, 115);
            this.ctl_PackPackaging.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_PackPackaging.Name = "ctl_PackPackaging";
            this.ctl_PackPackaging.SimpleList = null;
            this.ctl_PackPackaging.Size = new System.Drawing.Size(120, 44);
            this.ctl_PackPackaging.TabIndex = 19;
            this.ctl_PackPackaging.UseParentBackColor = false;
            this.ctl_PackPackaging.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_PackPackaging.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_PackPackaging.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_PackPackaging.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_PackPackaging.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_PackPackaging.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_PackPackaging.zz_OriginalDesign = false;
            this.ctl_PackPackaging.zz_ShowNeedsSaveColor = true;
            this.ctl_PackPackaging.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_PackPackaging.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_PackPackaging.zz_UseGlobalColor = false;
            this.ctl_PackPackaging.zz_UseGlobalFont = false;
            // 
            // ctl_PackCondition
            // 
            this.ctl_PackCondition.AllCaps = false;
            this.ctl_PackCondition.AllowEdit = false;
            this.ctl_PackCondition.BackColor = System.Drawing.Color.Transparent;
            this.ctl_PackCondition.Bold = false;
            this.ctl_PackCondition.Caption = "Condition";
            this.ctl_PackCondition.Changed = false;
            this.ctl_PackCondition.ListName = "condition";
            this.ctl_PackCondition.Location = new System.Drawing.Point(389, 65);
            this.ctl_PackCondition.Margin = new System.Windows.Forms.Padding(5);
            this.ctl_PackCondition.Name = "ctl_PackCondition";
            this.ctl_PackCondition.SimpleList = null;
            this.ctl_PackCondition.Size = new System.Drawing.Size(120, 44);
            this.ctl_PackCondition.TabIndex = 18;
            this.ctl_PackCondition.UseParentBackColor = false;
            this.ctl_PackCondition.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_PackCondition.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_PackCondition.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_PackCondition.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_PackCondition.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_PackCondition.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_PackCondition.zz_OriginalDesign = false;
            this.ctl_PackCondition.zz_ShowNeedsSaveColor = true;
            this.ctl_PackCondition.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_PackCondition.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_PackCondition.zz_UseGlobalColor = false;
            this.ctl_PackCondition.zz_UseGlobalFont = false;
            // 
            // ctl_PackLocation
            // 
            this.ctl_PackLocation.AllCaps = false;
            this.ctl_PackLocation.BackColor = System.Drawing.Color.White;
            this.ctl_PackLocation.Bold = false;
            this.ctl_PackLocation.Caption = "Location";
            this.ctl_PackLocation.Changed = true;
            this.ctl_PackLocation.IsEmail = false;
            this.ctl_PackLocation.IsURL = false;
            this.ctl_PackLocation.Location = new System.Drawing.Point(132, 115);
            this.ctl_PackLocation.Name = "ctl_PackLocation";
            this.ctl_PackLocation.PasswordChar = '\0';
            this.ctl_PackLocation.Size = new System.Drawing.Size(120, 44);
            this.ctl_PackLocation.TabIndex = 20;
            this.ctl_PackLocation.UseParentBackColor = true;
            this.ctl_PackLocation.zz_Enabled = true;
            this.ctl_PackLocation.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_PackLocation.zz_GlobalFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_PackLocation.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_PackLocation.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_PackLocation.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_PackLocation.zz_OriginalDesign = false;
            this.ctl_PackLocation.zz_ShowLinkButton = false;
            this.ctl_PackLocation.zz_ShowNeedsSaveColor = true;
            this.ctl_PackLocation.zz_Text = "";
            this.ctl_PackLocation.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_PackLocation.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_PackLocation.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_PackLocation.zz_UseGlobalColor = false;
            this.ctl_PackLocation.zz_UseGlobalFont = false;
            // 
            // ctl_PackMFG
            // 
            this.ctl_PackMFG.AllCaps = false;
            this.ctl_PackMFG.BackColor = System.Drawing.Color.White;
            this.ctl_PackMFG.Bold = false;
            this.ctl_PackMFG.Caption = "Manufacturer";
            this.ctl_PackMFG.Changed = true;
            this.ctl_PackMFG.IsEmail = false;
            this.ctl_PackMFG.IsURL = false;
            this.ctl_PackMFG.Location = new System.Drawing.Point(132, 65);
            this.ctl_PackMFG.Name = "ctl_PackMFG";
            this.ctl_PackMFG.PasswordChar = '\0';
            this.ctl_PackMFG.Size = new System.Drawing.Size(120, 44);
            this.ctl_PackMFG.TabIndex = 16;
            this.ctl_PackMFG.UseParentBackColor = true;
            this.ctl_PackMFG.zz_Enabled = true;
            this.ctl_PackMFG.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_PackMFG.zz_GlobalFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_PackMFG.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_PackMFG.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_PackMFG.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_PackMFG.zz_OriginalDesign = false;
            this.ctl_PackMFG.zz_ShowLinkButton = false;
            this.ctl_PackMFG.zz_ShowNeedsSaveColor = true;
            this.ctl_PackMFG.zz_Text = "";
            this.ctl_PackMFG.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_PackMFG.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_PackMFG.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_PackMFG.zz_UseGlobalColor = false;
            this.ctl_PackMFG.zz_UseGlobalFont = false;
            // 
            // ctl_PackQuantity
            // 
            this.ctl_PackQuantity.BackColor = System.Drawing.Color.White;
            this.ctl_PackQuantity.Bold = false;
            this.ctl_PackQuantity.Caption = "Quantity";
            this.ctl_PackQuantity.Changed = false;
            this.ctl_PackQuantity.CurrentType = Tools.Database.FieldType.Unknown;
            this.ctl_PackQuantity.Location = new System.Drawing.Point(6, 65);
            this.ctl_PackQuantity.Name = "ctl_PackQuantity";
            this.ctl_PackQuantity.Size = new System.Drawing.Size(120, 44);
            this.ctl_PackQuantity.TabIndex = 14;
            this.ctl_PackQuantity.UseParentBackColor = true;
            this.ctl_PackQuantity.zz_Enabled = true;
            this.ctl_PackQuantity.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_PackQuantity.zz_GlobalFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_PackQuantity.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_PackQuantity.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_PackQuantity.zz_LabelLocation = NewMethod.nEdit_Number.LabelLocations.TopLeft;
            this.ctl_PackQuantity.zz_OriginalDesign = false;
            this.ctl_PackQuantity.zz_ShowErrorColor = true;
            this.ctl_PackQuantity.zz_ShowNeedsSaveColor = true;
            this.ctl_PackQuantity.zz_Text = "";
            this.ctl_PackQuantity.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_PackQuantity.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_PackQuantity.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_PackQuantity.zz_UseGlobalColor = false;
            this.ctl_PackQuantity.zz_UseGlobalFont = false;
            // 
            // ctl_PackDC
            // 
            this.ctl_PackDC.AllCaps = false;
            this.ctl_PackDC.BackColor = System.Drawing.Color.White;
            this.ctl_PackDC.Bold = false;
            this.ctl_PackDC.Caption = "Date Code";
            this.ctl_PackDC.Changed = true;
            this.ctl_PackDC.IsEmail = false;
            this.ctl_PackDC.IsURL = false;
            this.ctl_PackDC.Location = new System.Drawing.Point(263, 65);
            this.ctl_PackDC.Name = "ctl_PackDC";
            this.ctl_PackDC.PasswordChar = '\0';
            this.ctl_PackDC.Size = new System.Drawing.Size(120, 44);
            this.ctl_PackDC.TabIndex = 17;
            this.ctl_PackDC.UseParentBackColor = true;
            this.ctl_PackDC.zz_Enabled = true;
            this.ctl_PackDC.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_PackDC.zz_GlobalFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_PackDC.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_PackDC.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_PackDC.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_PackDC.zz_OriginalDesign = false;
            this.ctl_PackDC.zz_ShowLinkButton = false;
            this.ctl_PackDC.zz_ShowNeedsSaveColor = true;
            this.ctl_PackDC.zz_Text = "";
            this.ctl_PackDC.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_PackDC.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_PackDC.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_PackDC.zz_UseGlobalColor = false;
            this.ctl_PackDC.zz_UseGlobalFont = false;
            // 
            // txtSplitAlert
            // 
            this.txtSplitAlert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSplitAlert.Location = new System.Drawing.Point(6, 19);
            this.txtSplitAlert.Multiline = true;
            this.txtSplitAlert.Name = "txtSplitAlert";
            this.txtSplitAlert.Size = new System.Drawing.Size(562, 37);
            this.txtSplitAlert.TabIndex = 40;
            this.txtSplitAlert.Text = "**If you need to split this qty, please delete any existing packs, close the line" +
    " item, and split the item on the order prior to receiving the line.";
            // 
            // ctl_PackLotNum
            // 
            this.ctl_PackLotNum.AllCaps = false;
            this.ctl_PackLotNum.BackColor = System.Drawing.Color.White;
            this.ctl_PackLotNum.Bold = false;
            this.ctl_PackLotNum.Caption = "Lot Number";
            this.ctl_PackLotNum.Changed = true;
            this.ctl_PackLotNum.IsEmail = false;
            this.ctl_PackLotNum.IsURL = false;
            this.ctl_PackLotNum.Location = new System.Drawing.Point(389, 115);
            this.ctl_PackLotNum.Name = "ctl_PackLotNum";
            this.ctl_PackLotNum.PasswordChar = '\0';
            this.ctl_PackLotNum.Size = new System.Drawing.Size(120, 44);
            this.ctl_PackLotNum.TabIndex = 21;
            this.ctl_PackLotNum.UseParentBackColor = true;
            this.ctl_PackLotNum.Visible = false;
            this.ctl_PackLotNum.zz_Enabled = true;
            this.ctl_PackLotNum.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_PackLotNum.zz_GlobalFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_PackLotNum.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_PackLotNum.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_PackLotNum.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_PackLotNum.zz_OriginalDesign = false;
            this.ctl_PackLotNum.zz_ShowLinkButton = false;
            this.ctl_PackLotNum.zz_ShowNeedsSaveColor = true;
            this.ctl_PackLotNum.zz_Text = "";
            this.ctl_PackLotNum.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_PackLotNum.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_PackLotNum.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_PackLotNum.zz_UseGlobalColor = false;
            this.ctl_PackLotNum.zz_UseGlobalFont = false;
            // 
            // ctl_PackBoxNum
            // 
            this.ctl_PackBoxNum.AllCaps = false;
            this.ctl_PackBoxNum.BackColor = System.Drawing.Color.White;
            this.ctl_PackBoxNum.Bold = false;
            this.ctl_PackBoxNum.Caption = "Box Number";
            this.ctl_PackBoxNum.Changed = true;
            this.ctl_PackBoxNum.IsEmail = false;
            this.ctl_PackBoxNum.IsURL = false;
            this.ctl_PackBoxNum.Location = new System.Drawing.Point(263, 115);
            this.ctl_PackBoxNum.Name = "ctl_PackBoxNum";
            this.ctl_PackBoxNum.PasswordChar = '\0';
            this.ctl_PackBoxNum.Size = new System.Drawing.Size(120, 44);
            this.ctl_PackBoxNum.TabIndex = 20;
            this.ctl_PackBoxNum.UseParentBackColor = true;
            this.ctl_PackBoxNum.Visible = false;
            this.ctl_PackBoxNum.zz_Enabled = true;
            this.ctl_PackBoxNum.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_PackBoxNum.zz_GlobalFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_PackBoxNum.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_PackBoxNum.zz_LabelFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_PackBoxNum.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_PackBoxNum.zz_OriginalDesign = false;
            this.ctl_PackBoxNum.zz_ShowLinkButton = false;
            this.ctl_PackBoxNum.zz_ShowNeedsSaveColor = true;
            this.ctl_PackBoxNum.zz_Text = "";
            this.ctl_PackBoxNum.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_PackBoxNum.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_PackBoxNum.zz_TextFont = new System.Drawing.Font("Calibri", 12F);
            this.ctl_PackBoxNum.zz_UseGlobalColor = false;
            this.ctl_PackBoxNum.zz_UseGlobalFont = false;
            // 
            // cmdPackOK
            // 
            this.cmdPackOK.Location = new System.Drawing.Point(515, 95);
            this.cmdPackOK.Name = "cmdPackOK";
            this.cmdPackOK.Size = new System.Drawing.Size(53, 44);
            this.cmdPackOK.TabIndex = 22;
            this.cmdPackOK.Text = "OK";
            this.cmdPackOK.UseVisualStyleBackColor = true;
            this.cmdPackOK.Click += new System.EventHandler(this.cmdPackOK_Click);
            // 
            // lvPack
            // 
            this.lvPack.AddCaption = "Add New";
            this.lvPack.AllowActions = true;
            this.lvPack.AllowAdd = false;
            this.lvPack.AllowDelete = true;
            this.lvPack.AllowDeleteAlways = false;
            this.lvPack.AllowDrop = true;
            this.lvPack.AllowOnlyOpenDelete = false;
            this.lvPack.AlternateConnection = null;
            this.lvPack.BackColor = System.Drawing.Color.White;
            this.lvPack.Caption = "";
            this.lvPack.CurrentTemplate = null;
            this.lvPack.ExtraClassInfo = "";
            this.lvPack.Location = new System.Drawing.Point(3, 3);
            this.lvPack.MultiSelect = true;
            this.lvPack.Name = "lvPack";
            this.lvPack.Size = new System.Drawing.Size(574, 286);
            this.lvPack.SuppressSelectionChanged = false;
            this.lvPack.TabIndex = 2;
            this.lvPack.zz_OpenColumnMenu = false;
            this.lvPack.zz_OrderLineType = "";
            this.lvPack.zz_ShowAutoRefresh = true;
            this.lvPack.zz_ShowUnlimited = true;
            this.lvPack.AboutToThrow += new Core.ShowHandler(this.lvPack_AboutToThrow);
            this.lvPack.AboutToAdd += new NewMethod.AddHandler(this.lvPack_AboutToAdd);
            this.lvPack.AboutToAction += new NewMethod.ActionHandler(this.lvPack_AboutToAction);
            this.lvPack.FinishedAction += new NewMethod.ActionHandler(this.lvPack_FinishedAction);
            // 
            // Packing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbPack);
            this.Controls.Add(this.lvPack);
            this.Name = "Packing";
            this.Size = new System.Drawing.Size(735, 561);
            this.Resize += new System.EventHandler(this.Packing_Resize);
            this.gbPack.ResumeLayout(false);
            this.gbPack.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public NewMethod.nEdit_Number ctl_PackQuantity;
        public NewMethod.nEdit_String ctl_PackDC;
        public NewMethod.nList lvPack;
        public NewMethod.nEdit_String ctl_PackMFG;
        public NewMethod.nEdit_String ctl_PackBoxNum;
        public NewMethod.nEdit_String ctl_PackLocation;
        public NewMethod.nEdit_String ctl_PackLotNum;
        public System.Windows.Forms.GroupBox gbPack;
        public System.Windows.Forms.Button cmdPackOK;
        private System.Windows.Forms.TextBox txtSplitAlert;
        public NewMethod.nEdit_List ctl_PackCondition;
        public NewMethod.nEdit_List ctl_PackPackaging;
    }
}
