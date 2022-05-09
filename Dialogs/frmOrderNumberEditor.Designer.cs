namespace Rz5
{
    partial class frmOrderNumberEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderNumberEditor));
            this.txtQuote = new NewMethod.nEdit_String();
            this.ud = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSO = new NewMethod.nEdit_String();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPO = new NewMethod.nEdit_String();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtInvoice = new NewMethod.nEdit_String();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtRMA = new NewMethod.nEdit_String();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtService = new NewMethod.nEdit_String();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtRFQ = new NewMethod.nEdit_String();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.txtVRMA = new NewMethod.nEdit_String();
            ((System.ComponentModel.ISupportInitialize)(this.ud)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtQuote
            // 
            this.txtQuote.AllCaps = false;
            this.txtQuote.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtQuote.Bold = false;
            this.txtQuote.Caption = "Next Order Number";
            this.txtQuote.Changed = false;
            this.txtQuote.IsEmail = false;
            this.txtQuote.IsURL = false;
            this.txtQuote.Location = new System.Drawing.Point(7, 20);
            this.txtQuote.Margin = new System.Windows.Forms.Padding(4);
            this.txtQuote.Name = "txtQuote";
            this.txtQuote.PasswordChar = '\0';
            this.txtQuote.Size = new System.Drawing.Size(265, 47);
            this.txtQuote.TabIndex = 0;
            this.txtQuote.UseParentBackColor = false;
            this.txtQuote.zz_Enabled = true;
            this.txtQuote.zz_GlobalColor = System.Drawing.Color.Black;
            this.txtQuote.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuote.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.txtQuote.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuote.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.txtQuote.zz_OriginalDesign = false;
            this.txtQuote.zz_ShowLinkButton = false;
            this.txtQuote.zz_ShowNeedsSaveColor = false;
            this.txtQuote.zz_Text = "";
            this.txtQuote.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtQuote.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.txtQuote.zz_TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuote.zz_UseGlobalColor = false;
            this.txtQuote.zz_UseGlobalFont = false;
            // 
            // ud
            // 
            this.ud.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ud.Location = new System.Drawing.Point(10, 32);
            this.ud.Name = "ud";
            this.ud.Size = new System.Drawing.Size(262, 26);
            this.ud.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Order Number Length";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Location = new System.Drawing.Point(2, 226);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(397, 28);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSave.Location = new System.Drawing.Point(455, 226);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(397, 28);
            this.cmdSave.TabIndex = 4;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtQuote);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 73);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Formal Quote";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSO);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox2.Location = new System.Drawing.Point(2, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 73);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sales Order";
            // 
            // txtSO
            // 
            this.txtSO.AllCaps = false;
            this.txtSO.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtSO.Bold = false;
            this.txtSO.Caption = "Next Order Number";
            this.txtSO.Changed = false;
            this.txtSO.IsEmail = false;
            this.txtSO.IsURL = false;
            this.txtSO.Location = new System.Drawing.Point(7, 20);
            this.txtSO.Margin = new System.Windows.Forms.Padding(4);
            this.txtSO.Name = "txtSO";
            this.txtSO.PasswordChar = '\0';
            this.txtSO.Size = new System.Drawing.Size(265, 47);
            this.txtSO.TabIndex = 0;
            this.txtSO.UseParentBackColor = false;
            this.txtSO.zz_Enabled = true;
            this.txtSO.zz_GlobalColor = System.Drawing.Color.Black;
            this.txtSO.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSO.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.txtSO.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSO.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.txtSO.zz_OriginalDesign = false;
            this.txtSO.zz_ShowLinkButton = false;
            this.txtSO.zz_ShowNeedsSaveColor = false;
            this.txtSO.zz_Text = "";
            this.txtSO.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSO.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.txtSO.zz_TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSO.zz_UseGlobalColor = false;
            this.txtSO.zz_UseGlobalFont = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtPO);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox3.Location = new System.Drawing.Point(287, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(280, 73);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Purchase Order";
            // 
            // txtPO
            // 
            this.txtPO.AllCaps = false;
            this.txtPO.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtPO.Bold = false;
            this.txtPO.Caption = "Next Order Number";
            this.txtPO.Changed = false;
            this.txtPO.IsEmail = false;
            this.txtPO.IsURL = false;
            this.txtPO.Location = new System.Drawing.Point(7, 20);
            this.txtPO.Margin = new System.Windows.Forms.Padding(6);
            this.txtPO.Name = "txtPO";
            this.txtPO.PasswordChar = '\0';
            this.txtPO.Size = new System.Drawing.Size(265, 47);
            this.txtPO.TabIndex = 0;
            this.txtPO.UseParentBackColor = false;
            this.txtPO.zz_Enabled = true;
            this.txtPO.zz_GlobalColor = System.Drawing.Color.Black;
            this.txtPO.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPO.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.txtPO.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPO.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.txtPO.zz_OriginalDesign = false;
            this.txtPO.zz_ShowLinkButton = false;
            this.txtPO.zz_ShowNeedsSaveColor = false;
            this.txtPO.zz_Text = "";
            this.txtPO.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPO.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.txtPO.zz_TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPO.zz_UseGlobalColor = false;
            this.txtPO.zz_UseGlobalFont = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtInvoice);
            this.groupBox4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox4.Location = new System.Drawing.Point(2, 147);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(280, 73);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Invoice";
            // 
            // txtInvoice
            // 
            this.txtInvoice.AllCaps = false;
            this.txtInvoice.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtInvoice.Bold = false;
            this.txtInvoice.Caption = "Next Order Number";
            this.txtInvoice.Changed = false;
            this.txtInvoice.IsEmail = false;
            this.txtInvoice.IsURL = false;
            this.txtInvoice.Location = new System.Drawing.Point(7, 20);
            this.txtInvoice.Margin = new System.Windows.Forms.Padding(4);
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.PasswordChar = '\0';
            this.txtInvoice.Size = new System.Drawing.Size(265, 47);
            this.txtInvoice.TabIndex = 0;
            this.txtInvoice.UseParentBackColor = false;
            this.txtInvoice.zz_Enabled = true;
            this.txtInvoice.zz_GlobalColor = System.Drawing.Color.Black;
            this.txtInvoice.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoice.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.txtInvoice.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoice.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.txtInvoice.zz_OriginalDesign = false;
            this.txtInvoice.zz_ShowLinkButton = false;
            this.txtInvoice.zz_ShowNeedsSaveColor = false;
            this.txtInvoice.zz_Text = "";
            this.txtInvoice.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtInvoice.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.txtInvoice.zz_TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoice.zz_UseGlobalColor = false;
            this.txtInvoice.zz_UseGlobalFont = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtRMA);
            this.groupBox5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox5.Location = new System.Drawing.Point(287, 75);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(280, 73);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "RMA";
            // 
            // txtRMA
            // 
            this.txtRMA.AllCaps = false;
            this.txtRMA.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtRMA.Bold = false;
            this.txtRMA.Caption = "Next Order Number";
            this.txtRMA.Changed = false;
            this.txtRMA.IsEmail = false;
            this.txtRMA.IsURL = false;
            this.txtRMA.Location = new System.Drawing.Point(7, 20);
            this.txtRMA.Margin = new System.Windows.Forms.Padding(4);
            this.txtRMA.Name = "txtRMA";
            this.txtRMA.PasswordChar = '\0';
            this.txtRMA.Size = new System.Drawing.Size(265, 47);
            this.txtRMA.TabIndex = 0;
            this.txtRMA.UseParentBackColor = false;
            this.txtRMA.zz_Enabled = true;
            this.txtRMA.zz_GlobalColor = System.Drawing.Color.Black;
            this.txtRMA.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRMA.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.txtRMA.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRMA.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.txtRMA.zz_OriginalDesign = false;
            this.txtRMA.zz_ShowLinkButton = false;
            this.txtRMA.zz_ShowNeedsSaveColor = false;
            this.txtRMA.zz_Text = "";
            this.txtRMA.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtRMA.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.txtRMA.zz_TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRMA.zz_UseGlobalColor = false;
            this.txtRMA.zz_UseGlobalFont = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtService);
            this.groupBox6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox6.Location = new System.Drawing.Point(287, 147);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(280, 73);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Service";
            // 
            // txtService
            // 
            this.txtService.AllCaps = false;
            this.txtService.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtService.Bold = false;
            this.txtService.Caption = "Next Order Number";
            this.txtService.Changed = false;
            this.txtService.IsEmail = false;
            this.txtService.IsURL = false;
            this.txtService.Location = new System.Drawing.Point(7, 20);
            this.txtService.Margin = new System.Windows.Forms.Padding(4);
            this.txtService.Name = "txtService";
            this.txtService.PasswordChar = '\0';
            this.txtService.Size = new System.Drawing.Size(265, 47);
            this.txtService.TabIndex = 0;
            this.txtService.UseParentBackColor = false;
            this.txtService.zz_Enabled = true;
            this.txtService.zz_GlobalColor = System.Drawing.Color.Black;
            this.txtService.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtService.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.txtService.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtService.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.txtService.zz_OriginalDesign = false;
            this.txtService.zz_ShowLinkButton = false;
            this.txtService.zz_ShowNeedsSaveColor = false;
            this.txtService.zz_Text = "";
            this.txtService.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtService.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.txtService.zz_TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtService.zz_UseGlobalColor = false;
            this.txtService.zz_UseGlobalFont = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtRFQ);
            this.groupBox7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox7.Location = new System.Drawing.Point(572, 2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(280, 73);
            this.groupBox7.TabIndex = 11;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "RFQ";
            // 
            // txtRFQ
            // 
            this.txtRFQ.AllCaps = false;
            this.txtRFQ.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtRFQ.Bold = false;
            this.txtRFQ.Caption = "Next Order Number";
            this.txtRFQ.Changed = false;
            this.txtRFQ.IsEmail = false;
            this.txtRFQ.IsURL = false;
            this.txtRFQ.Location = new System.Drawing.Point(7, 20);
            this.txtRFQ.Margin = new System.Windows.Forms.Padding(4);
            this.txtRFQ.Name = "txtRFQ";
            this.txtRFQ.PasswordChar = '\0';
            this.txtRFQ.Size = new System.Drawing.Size(265, 47);
            this.txtRFQ.TabIndex = 0;
            this.txtRFQ.UseParentBackColor = false;
            this.txtRFQ.zz_Enabled = true;
            this.txtRFQ.zz_GlobalColor = System.Drawing.Color.Black;
            this.txtRFQ.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRFQ.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.txtRFQ.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRFQ.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.txtRFQ.zz_OriginalDesign = false;
            this.txtRFQ.zz_ShowLinkButton = false;
            this.txtRFQ.zz_ShowNeedsSaveColor = false;
            this.txtRFQ.zz_Text = "";
            this.txtRFQ.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtRFQ.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.txtRFQ.zz_TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRFQ.zz_UseGlobalColor = false;
            this.txtRFQ.zz_UseGlobalFont = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.ud);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(572, 152);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 68);
            this.panel1.TabIndex = 12;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.txtVRMA);
            this.groupBox8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox8.Location = new System.Drawing.Point(572, 75);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(280, 73);
            this.groupBox8.TabIndex = 10;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Vendor RMA";
            // 
            // txtVRMA
            // 
            this.txtVRMA.AllCaps = false;
            this.txtVRMA.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtVRMA.Bold = false;
            this.txtVRMA.Caption = "Next Order Number";
            this.txtVRMA.Changed = false;
            this.txtVRMA.IsEmail = false;
            this.txtVRMA.IsURL = false;
            this.txtVRMA.Location = new System.Drawing.Point(7, 20);
            this.txtVRMA.Margin = new System.Windows.Forms.Padding(4);
            this.txtVRMA.Name = "txtVRMA";
            this.txtVRMA.PasswordChar = '\0';
            this.txtVRMA.Size = new System.Drawing.Size(265, 47);
            this.txtVRMA.TabIndex = 0;
            this.txtVRMA.UseParentBackColor = false;
            this.txtVRMA.zz_Enabled = true;
            this.txtVRMA.zz_GlobalColor = System.Drawing.Color.Black;
            this.txtVRMA.zz_GlobalFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVRMA.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.txtVRMA.zz_LabelFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVRMA.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.TopLeft;
            this.txtVRMA.zz_OriginalDesign = false;
            this.txtVRMA.zz_ShowLinkButton = false;
            this.txtVRMA.zz_ShowNeedsSaveColor = false;
            this.txtVRMA.zz_Text = "";
            this.txtVRMA.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtVRMA.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.txtVRMA.zz_TextFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVRMA.zz_UseGlobalColor = false;
            this.txtVRMA.zz_UseGlobalFont = false;
            // 
            // frmOrderNumberEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 256);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmOrderNumberEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order Number Editor";
            ((System.ComponentModel.ISupportInitialize)(this.ud)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected NewMethod.nEdit_String txtQuote;
        protected System.Windows.Forms.NumericUpDown ud;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Button cmdCancel;
        protected System.Windows.Forms.Button cmdSave;
        protected System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.GroupBox groupBox2;
        protected NewMethod.nEdit_String txtSO;
        protected System.Windows.Forms.GroupBox groupBox3;
        protected NewMethod.nEdit_String txtPO;
        protected System.Windows.Forms.GroupBox groupBox4;
        protected NewMethod.nEdit_String txtInvoice;
        protected System.Windows.Forms.GroupBox groupBox5;
        protected NewMethod.nEdit_String txtRMA;
        protected System.Windows.Forms.GroupBox groupBox6;
        protected NewMethod.nEdit_String txtService;
        protected System.Windows.Forms.GroupBox groupBox7;
        protected NewMethod.nEdit_String txtRFQ;
        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.GroupBox groupBox8;
        protected NewMethod.nEdit_String txtVRMA;

    }
}