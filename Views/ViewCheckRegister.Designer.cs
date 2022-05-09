namespace RzInterfaceWin
{
    partial class ViewCheckRegister
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
            this.pbLeft = new System.Windows.Forms.PictureBox();
            this.pbRight = new System.Windows.Forms.PictureBox();
            this.pbBottom = new System.Windows.Forms.PictureBox();
            this.pbTop = new System.Windows.Forms.PictureBox();
            this.pTop = new System.Windows.Forms.Panel();
            this.dtEnd = new NewMethod.nEdit_Date();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.dtStart = new NewMethod.nEdit_Date();
            this.ctl_amnt = new NewMethod.nEdit_Money();
            this.ctl_memo = new NewMethod.nEdit_String();
            this.ctl_ref = new NewMethod.nEdit_String();
            this.ctl_payee = new NewMethod.nEdit_List();
            this.pBottom = new System.Windows.Forms.Panel();
            this.cmdRecord = new System.Windows.Forms.Button();
            this.ctlDeposit = new NewMethod.nEdit_Money();
            this.ctlPayment = new NewMethod.nEdit_Money();
            this.ctlMemo = new NewMethod.nEdit_String();
            this.ctlAccount = new NewMethod.nEdit_List();
            this.ctlRef = new NewMethod.nEdit_String();
            this.ctlPayee = new NewMethod.nEdit_List();
            this.ctlDate = new NewMethod.nEdit_Date();
            this.wb = new ToolsWin.BrowserPlain();
            this.bgw = new System.ComponentModel.BackgroundWorker();
            this.throb = new NewMethod.nThrobber();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).BeginInit();
            this.pTop.SuspendLayout();
            this.pBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbLeft
            // 
            this.pbLeft.BackColor = System.Drawing.Color.Black;
            this.pbLeft.Location = new System.Drawing.Point(23, 351);
            this.pbLeft.Margin = new System.Windows.Forms.Padding(4);
            this.pbLeft.Name = "pbLeft";
            this.pbLeft.Size = new System.Drawing.Size(16, 15);
            this.pbLeft.TabIndex = 40;
            this.pbLeft.TabStop = false;
            // 
            // pbRight
            // 
            this.pbRight.BackColor = System.Drawing.Color.Black;
            this.pbRight.Location = new System.Drawing.Point(23, 329);
            this.pbRight.Margin = new System.Windows.Forms.Padding(4);
            this.pbRight.Name = "pbRight";
            this.pbRight.Size = new System.Drawing.Size(16, 15);
            this.pbRight.TabIndex = 39;
            this.pbRight.TabStop = false;
            // 
            // pbBottom
            // 
            this.pbBottom.BackColor = System.Drawing.Color.Black;
            this.pbBottom.Location = new System.Drawing.Point(47, 329);
            this.pbBottom.Margin = new System.Windows.Forms.Padding(4);
            this.pbBottom.Name = "pbBottom";
            this.pbBottom.Size = new System.Drawing.Size(16, 15);
            this.pbBottom.TabIndex = 38;
            this.pbBottom.TabStop = false;
            // 
            // pbTop
            // 
            this.pbTop.BackColor = System.Drawing.Color.Black;
            this.pbTop.Location = new System.Drawing.Point(47, 351);
            this.pbTop.Margin = new System.Windows.Forms.Padding(4);
            this.pbTop.Name = "pbTop";
            this.pbTop.Size = new System.Drawing.Size(16, 15);
            this.pbTop.TabIndex = 37;
            this.pbTop.TabStop = false;
            // 
            // pTop
            // 
            this.pTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pTop.Controls.Add(this.dtEnd);
            this.pTop.Controls.Add(this.cmdSearch);
            this.pTop.Controls.Add(this.dtStart);
            this.pTop.Controls.Add(this.ctl_amnt);
            this.pTop.Controls.Add(this.ctl_memo);
            this.pTop.Controls.Add(this.ctl_ref);
            this.pTop.Controls.Add(this.ctl_payee);
            this.pTop.Location = new System.Drawing.Point(23, 17);
            this.pTop.Name = "pTop";
            this.pTop.Size = new System.Drawing.Size(1342, 52);
            this.pTop.TabIndex = 41;
            // 
            // dtEnd
            // 
            this.dtEnd.AllowClear = false;
            this.dtEnd.BackColor = System.Drawing.Color.Transparent;
            this.dtEnd.Bold = false;
            this.dtEnd.Caption = "End Date";
            this.dtEnd.Changed = false;
            this.dtEnd.Location = new System.Drawing.Point(182, 5);
            this.dtEnd.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(167, 41);
            this.dtEnd.SuppressEdit = false;
            this.dtEnd.TabIndex = 45;
            this.dtEnd.UseParentBackColor = false;
            this.dtEnd.zz_GlobalColor = System.Drawing.Color.Black;
            this.dtEnd.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dtEnd.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.dtEnd.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEnd.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopCenter;
            this.dtEnd.zz_OriginalDesign = false;
            this.dtEnd.zz_ShowNeedsSaveColor = false;
            this.dtEnd.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.dtEnd.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEnd.zz_UseGlobalColor = false;
            this.dtEnd.zz_UseGlobalFont = false;
            // 
            // cmdSearch
            // 
            this.cmdSearch.Location = new System.Drawing.Point(1237, 5);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(94, 41);
            this.cmdSearch.TabIndex = 4;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // dtStart
            // 
            this.dtStart.AllowClear = false;
            this.dtStart.BackColor = System.Drawing.Color.Transparent;
            this.dtStart.Bold = false;
            this.dtStart.Caption = "Start Date";
            this.dtStart.Changed = false;
            this.dtStart.Location = new System.Drawing.Point(5, 5);
            this.dtStart.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(167, 41);
            this.dtStart.SuppressEdit = false;
            this.dtStart.TabIndex = 44;
            this.dtStart.UseParentBackColor = false;
            this.dtStart.zz_GlobalColor = System.Drawing.Color.Black;
            this.dtStart.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dtStart.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.dtStart.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStart.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopCenter;
            this.dtStart.zz_OriginalDesign = false;
            this.dtStart.zz_ShowNeedsSaveColor = false;
            this.dtStart.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.dtStart.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStart.zz_UseGlobalColor = false;
            this.dtStart.zz_UseGlobalFont = false;
            // 
            // ctl_amnt
            // 
            this.ctl_amnt.BackColor = System.Drawing.Color.Transparent;
            this.ctl_amnt.Bold = false;
            this.ctl_amnt.Caption = "Amount";
            this.ctl_amnt.Changed = false;
            this.ctl_amnt.EditCaption = false;
            this.ctl_amnt.FullDecimal = false;
            this.ctl_amnt.Location = new System.Drawing.Point(793, 5);
            this.ctl_amnt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctl_amnt.Name = "ctl_amnt";
            this.ctl_amnt.RoundNearestCent = false;
            this.ctl_amnt.Size = new System.Drawing.Size(137, 41);
            this.ctl_amnt.TabIndex = 3;
            this.ctl_amnt.UseParentBackColor = false;
            this.ctl_amnt.zz_Enabled = true;
            this.ctl_amnt.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_amnt.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_amnt.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_amnt.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_amnt.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctl_amnt.zz_OriginalDesign = false;
            this.ctl_amnt.zz_ShowErrorColor = true;
            this.ctl_amnt.zz_ShowNeedsSaveColor = false;
            this.ctl_amnt.zz_Text = "";
            this.ctl_amnt.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctl_amnt.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_amnt.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_amnt.zz_UseGlobalColor = false;
            this.ctl_amnt.zz_UseGlobalFont = false;
            // 
            // ctl_memo
            // 
            this.ctl_memo.AllCaps = false;
            this.ctl_memo.BackColor = System.Drawing.Color.Transparent;
            this.ctl_memo.Bold = false;
            this.ctl_memo.Caption = "Memo";
            this.ctl_memo.Changed = false;
            this.ctl_memo.IsEmail = false;
            this.ctl_memo.IsURL = false;
            this.ctl_memo.Location = new System.Drawing.Point(939, 5);
            this.ctl_memo.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ctl_memo.Name = "ctl_memo";
            this.ctl_memo.PasswordChar = '\0';
            this.ctl_memo.Size = new System.Drawing.Size(290, 41);
            this.ctl_memo.TabIndex = 2;
            this.ctl_memo.UseParentBackColor = false;
            this.ctl_memo.zz_Enabled = true;
            this.ctl_memo.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_memo.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_memo.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_memo.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_memo.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_memo.zz_OriginalDesign = false;
            this.ctl_memo.zz_ShowLinkButton = false;
            this.ctl_memo.zz_ShowNeedsSaveColor = false;
            this.ctl_memo.zz_Text = "";
            this.ctl_memo.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_memo.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_memo.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_memo.zz_UseGlobalColor = false;
            this.ctl_memo.zz_UseGlobalFont = false;
            // 
            // ctl_ref
            // 
            this.ctl_ref.AllCaps = false;
            this.ctl_ref.BackColor = System.Drawing.Color.Transparent;
            this.ctl_ref.Bold = false;
            this.ctl_ref.Caption = "Number/Ref.";
            this.ctl_ref.Changed = false;
            this.ctl_ref.IsEmail = false;
            this.ctl_ref.IsURL = false;
            this.ctl_ref.Location = new System.Drawing.Point(650, 5);
            this.ctl_ref.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ctl_ref.Name = "ctl_ref";
            this.ctl_ref.PasswordChar = '\0';
            this.ctl_ref.Size = new System.Drawing.Size(134, 41);
            this.ctl_ref.TabIndex = 1;
            this.ctl_ref.UseParentBackColor = false;
            this.ctl_ref.zz_Enabled = true;
            this.ctl_ref.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_ref.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_ref.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_ref.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_ref.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctl_ref.zz_OriginalDesign = false;
            this.ctl_ref.zz_ShowLinkButton = false;
            this.ctl_ref.zz_ShowNeedsSaveColor = false;
            this.ctl_ref.zz_Text = "";
            this.ctl_ref.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctl_ref.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_ref.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_ref.zz_UseGlobalColor = false;
            this.ctl_ref.zz_UseGlobalFont = false;
            // 
            // ctl_payee
            // 
            this.ctl_payee.AllCaps = false;
            this.ctl_payee.AllowEdit = false;
            this.ctl_payee.BackColor = System.Drawing.Color.Transparent;
            this.ctl_payee.Bold = false;
            this.ctl_payee.Caption = "Payee/Name";
            this.ctl_payee.Changed = false;
            this.ctl_payee.ListName = null;
            this.ctl_payee.Location = new System.Drawing.Point(359, 3);
            this.ctl_payee.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ctl_payee.Name = "ctl_payee";
            this.ctl_payee.SimpleList = null;
            this.ctl_payee.Size = new System.Drawing.Size(281, 43);
            this.ctl_payee.TabIndex = 0;
            this.ctl_payee.UseParentBackColor = false;
            this.ctl_payee.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctl_payee.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctl_payee.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctl_payee.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctl_payee.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_payee.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctl_payee.zz_OriginalDesign = false;
            this.ctl_payee.zz_ShowNeedsSaveColor = false;
            this.ctl_payee.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctl_payee.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctl_payee.zz_UseGlobalColor = false;
            this.ctl_payee.zz_UseGlobalFont = false;
            // 
            // pBottom
            // 
            this.pBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBottom.Controls.Add(this.cmdRecord);
            this.pBottom.Controls.Add(this.ctlDeposit);
            this.pBottom.Controls.Add(this.ctlPayment);
            this.pBottom.Controls.Add(this.ctlMemo);
            this.pBottom.Controls.Add(this.ctlAccount);
            this.pBottom.Controls.Add(this.ctlRef);
            this.pBottom.Controls.Add(this.ctlPayee);
            this.pBottom.Controls.Add(this.ctlDate);
            this.pBottom.Location = new System.Drawing.Point(23, 231);
            this.pBottom.Name = "pBottom";
            this.pBottom.Size = new System.Drawing.Size(1342, 92);
            this.pBottom.TabIndex = 42;
            // 
            // cmdRecord
            // 
            this.cmdRecord.Location = new System.Drawing.Point(1237, 5);
            this.cmdRecord.Name = "cmdRecord";
            this.cmdRecord.Size = new System.Drawing.Size(94, 53);
            this.cmdRecord.TabIndex = 46;
            this.cmdRecord.Text = "Record";
            this.cmdRecord.UseVisualStyleBackColor = true;
            this.cmdRecord.Click += new System.EventHandler(this.cmdRecord_Click);
            // 
            // ctlDeposit
            // 
            this.ctlDeposit.BackColor = System.Drawing.Color.Transparent;
            this.ctlDeposit.Bold = false;
            this.ctlDeposit.Caption = "Deposit";
            this.ctlDeposit.Changed = false;
            this.ctlDeposit.EditCaption = false;
            this.ctlDeposit.FullDecimal = false;
            this.ctlDeposit.Location = new System.Drawing.Point(1073, 5);
            this.ctlDeposit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctlDeposit.Name = "ctlDeposit";
            this.ctlDeposit.RoundNearestCent = false;
            this.ctlDeposit.Size = new System.Drawing.Size(161, 41);
            this.ctlDeposit.TabIndex = 51;
            this.ctlDeposit.UseParentBackColor = false;
            this.ctlDeposit.zz_Enabled = true;
            this.ctlDeposit.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlDeposit.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlDeposit.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlDeposit.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlDeposit.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctlDeposit.zz_OriginalDesign = false;
            this.ctlDeposit.zz_ShowErrorColor = true;
            this.ctlDeposit.zz_ShowNeedsSaveColor = false;
            this.ctlDeposit.zz_Text = "";
            this.ctlDeposit.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctlDeposit.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlDeposit.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlDeposit.zz_UseGlobalColor = false;
            this.ctlDeposit.zz_UseGlobalFont = false;
            this.ctlDeposit.DataChanged += new NewMethod.ChangeHandler(this.ctlDeposit_DataChanged);
            // 
            // ctlPayment
            // 
            this.ctlPayment.BackColor = System.Drawing.Color.Transparent;
            this.ctlPayment.Bold = false;
            this.ctlPayment.Caption = "Payment";
            this.ctlPayment.Changed = false;
            this.ctlPayment.EditCaption = false;
            this.ctlPayment.FullDecimal = false;
            this.ctlPayment.Location = new System.Drawing.Point(904, 5);
            this.ctlPayment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctlPayment.Name = "ctlPayment";
            this.ctlPayment.RoundNearestCent = false;
            this.ctlPayment.Size = new System.Drawing.Size(161, 41);
            this.ctlPayment.TabIndex = 50;
            this.ctlPayment.UseParentBackColor = false;
            this.ctlPayment.zz_Enabled = true;
            this.ctlPayment.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlPayment.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlPayment.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlPayment.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlPayment.zz_LabelLocation = NewMethod.nEdit_Money.LabelLocations.TopLeft;
            this.ctlPayment.zz_OriginalDesign = false;
            this.ctlPayment.zz_ShowErrorColor = true;
            this.ctlPayment.zz_ShowNeedsSaveColor = false;
            this.ctlPayment.zz_Text = "";
            this.ctlPayment.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctlPayment.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlPayment.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlPayment.zz_UseGlobalColor = false;
            this.ctlPayment.zz_UseGlobalFont = false;
            this.ctlPayment.DataChanged += new NewMethod.ChangeHandler(this.ctlPayment_DataChanged);
            // 
            // ctlMemo
            // 
            this.ctlMemo.AllCaps = false;
            this.ctlMemo.BackColor = System.Drawing.Color.Transparent;
            this.ctlMemo.Bold = false;
            this.ctlMemo.Caption = "Memo";
            this.ctlMemo.Changed = false;
            this.ctlMemo.IsEmail = false;
            this.ctlMemo.IsURL = false;
            this.ctlMemo.Location = new System.Drawing.Point(5, 47);
            this.ctlMemo.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ctlMemo.Name = "ctlMemo";
            this.ctlMemo.PasswordChar = '\0';
            this.ctlMemo.Size = new System.Drawing.Size(1326, 41);
            this.ctlMemo.TabIndex = 46;
            this.ctlMemo.UseParentBackColor = false;
            this.ctlMemo.zz_Enabled = true;
            this.ctlMemo.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlMemo.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlMemo.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlMemo.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlMemo.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctlMemo.zz_OriginalDesign = false;
            this.ctlMemo.zz_ShowLinkButton = false;
            this.ctlMemo.zz_ShowNeedsSaveColor = false;
            this.ctlMemo.zz_Text = "";
            this.ctlMemo.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlMemo.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlMemo.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlMemo.zz_UseGlobalColor = false;
            this.ctlMemo.zz_UseGlobalFont = false;
            // 
            // ctlAccount
            // 
            this.ctlAccount.AllCaps = false;
            this.ctlAccount.AllowEdit = false;
            this.ctlAccount.BackColor = System.Drawing.Color.Transparent;
            this.ctlAccount.Bold = false;
            this.ctlAccount.Caption = "Account";
            this.ctlAccount.Changed = false;
            this.ctlAccount.ListName = null;
            this.ctlAccount.Location = new System.Drawing.Point(614, 3);
            this.ctlAccount.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ctlAccount.Name = "ctlAccount";
            this.ctlAccount.SimpleList = null;
            this.ctlAccount.Size = new System.Drawing.Size(281, 43);
            this.ctlAccount.TabIndex = 49;
            this.ctlAccount.UseParentBackColor = false;
            this.ctlAccount.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctlAccount.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlAccount.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlAccount.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlAccount.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlAccount.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctlAccount.zz_OriginalDesign = false;
            this.ctlAccount.zz_ShowNeedsSaveColor = false;
            this.ctlAccount.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlAccount.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlAccount.zz_UseGlobalColor = false;
            this.ctlAccount.zz_UseGlobalFont = false;
            // 
            // ctlRef
            // 
            this.ctlRef.AllCaps = false;
            this.ctlRef.BackColor = System.Drawing.Color.Transparent;
            this.ctlRef.Bold = false;
            this.ctlRef.Caption = "Number/Ref.";
            this.ctlRef.Changed = false;
            this.ctlRef.IsEmail = false;
            this.ctlRef.IsURL = false;
            this.ctlRef.Location = new System.Drawing.Point(179, 5);
            this.ctlRef.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ctlRef.Name = "ctlRef";
            this.ctlRef.PasswordChar = '\0';
            this.ctlRef.Size = new System.Drawing.Size(134, 41);
            this.ctlRef.TabIndex = 48;
            this.ctlRef.UseParentBackColor = false;
            this.ctlRef.zz_Enabled = true;
            this.ctlRef.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlRef.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlRef.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlRef.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlRef.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.ctlRef.zz_OriginalDesign = false;
            this.ctlRef.zz_ShowLinkButton = false;
            this.ctlRef.zz_ShowNeedsSaveColor = false;
            this.ctlRef.zz_Text = "";
            this.ctlRef.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlRef.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlRef.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlRef.zz_UseGlobalColor = false;
            this.ctlRef.zz_UseGlobalFont = false;
            // 
            // ctlPayee
            // 
            this.ctlPayee.AllCaps = false;
            this.ctlPayee.AllowEdit = false;
            this.ctlPayee.BackColor = System.Drawing.Color.Transparent;
            this.ctlPayee.Bold = false;
            this.ctlPayee.Caption = "Payee/Name";
            this.ctlPayee.Changed = false;
            this.ctlPayee.ListName = null;
            this.ctlPayee.Location = new System.Drawing.Point(323, 3);
            this.ctlPayee.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ctlPayee.Name = "ctlPayee";
            this.ctlPayee.SimpleList = null;
            this.ctlPayee.Size = new System.Drawing.Size(281, 43);
            this.ctlPayee.TabIndex = 47;
            this.ctlPayee.UseParentBackColor = false;
            this.ctlPayee.zz_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ctlPayee.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlPayee.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlPayee.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlPayee.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlPayee.zz_LabelLocation = NewMethod.nEdit_List.LabelLocations.TopLeft;
            this.ctlPayee.zz_OriginalDesign = false;
            this.ctlPayee.zz_ShowNeedsSaveColor = false;
            this.ctlPayee.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlPayee.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlPayee.zz_UseGlobalColor = false;
            this.ctlPayee.zz_UseGlobalFont = false;
            // 
            // ctlDate
            // 
            this.ctlDate.AllowClear = false;
            this.ctlDate.BackColor = System.Drawing.Color.Transparent;
            this.ctlDate.Bold = false;
            this.ctlDate.Caption = "Date";
            this.ctlDate.Changed = false;
            this.ctlDate.Location = new System.Drawing.Point(5, 5);
            this.ctlDate.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ctlDate.Name = "ctlDate";
            this.ctlDate.Size = new System.Drawing.Size(167, 41);
            this.ctlDate.SuppressEdit = false;
            this.ctlDate.TabIndex = 45;
            this.ctlDate.UseParentBackColor = false;
            this.ctlDate.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlDate.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlDate.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlDate.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlDate.zz_LabelLocation = NewMethod.nEdit_Date.LabelLocations.TopCenter;
            this.ctlDate.zz_OriginalDesign = false;
            this.ctlDate.zz_ShowNeedsSaveColor = false;
            this.ctlDate.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlDate.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlDate.zz_UseGlobalColor = false;
            this.ctlDate.zz_UseGlobalFont = false;
            // 
            // wb
            // 
            this.wb.BackColor = System.Drawing.Color.White;
            this.wb.Location = new System.Drawing.Point(23, 76);
            this.wb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.wb.Name = "wb";
            this.wb.ShowControls = false;
            this.wb.Silent = false;
            this.wb.Size = new System.Drawing.Size(1342, 148);
            this.wb.TabIndex = 43;
            this.wb.OnNavigate2 += new ToolsWin.OnNavigate2HandlerPlain(this.wb_OnNavigate2);
            // 
            // bgw
            // 
            this.bgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            this.bgw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted);
            // 
            // throb
            // 
            this.throb.BackColor = System.Drawing.Color.White;
            this.throb.Location = new System.Drawing.Point(26, 76);
            this.throb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.throb.Name = "throb";
            this.throb.Size = new System.Drawing.Size(40, 33);
            this.throb.TabIndex = 0;
            this.throb.UseParentBackColor = false;
            // 
            // ViewCheckRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.throb);
            this.Controls.Add(this.pTop);
            this.Controls.Add(this.wb);
            this.Controls.Add(this.pBottom);
            this.Controls.Add(this.pbLeft);
            this.Controls.Add(this.pbRight);
            this.Controls.Add(this.pbBottom);
            this.Controls.Add(this.pbTop);
            this.Name = "ViewCheckRegister";
            this.Size = new System.Drawing.Size(1698, 383);
            this.Resize += new System.EventHandler(this.ViewCheckRegister_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).EndInit();
            this.pTop.ResumeLayout(false);
            this.pBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLeft;
        private System.Windows.Forms.PictureBox pbRight;
        private System.Windows.Forms.PictureBox pbBottom;
        private System.Windows.Forms.PictureBox pbTop;
        private System.Windows.Forms.Panel pTop;
        private System.Windows.Forms.Panel pBottom;
        private ToolsWin.BrowserPlain wb;
        private System.Windows.Forms.Button cmdSearch;
        private NewMethod.nEdit_Money ctl_amnt;
        private NewMethod.nEdit_String ctl_memo;
        private NewMethod.nEdit_String ctl_ref;
        private NewMethod.nEdit_List ctl_payee;
        private System.ComponentModel.BackgroundWorker bgw;
        private NewMethod.nThrobber throb;
        private NewMethod.nEdit_Date dtEnd;
        private NewMethod.nEdit_Date dtStart;
        private System.Windows.Forms.Button cmdRecord;
        private NewMethod.nEdit_Money ctlDeposit;
        private NewMethod.nEdit_Money ctlPayment;
        private NewMethod.nEdit_String ctlMemo;
        private NewMethod.nEdit_List ctlAccount;
        private NewMethod.nEdit_String ctlRef;
        private NewMethod.nEdit_List ctlPayee;
        private NewMethod.nEdit_Date ctlDate;
    }
}
