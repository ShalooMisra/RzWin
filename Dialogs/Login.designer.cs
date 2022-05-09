using NewMethod;
using CoreWin;

namespace Rz5
{
    partial class Login
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
            if (disposing)
                DisposeLogin();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.txtChange1 = new System.Windows.Forms.TextBox();
            this.txtChange2 = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.lnkNewPassword = new System.Windows.Forms.LinkLabel();
            this.pLogin = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.loginComplete1 = new Rz5.LoginComplete();
            this.picRight = new System.Windows.Forms.PictureBox();
            this.picLeft = new System.Windows.Forms.PictureBox();
            this.pWelcome = new System.Windows.Forms.Panel();
            this.ctlEmail = new NewMethod.nEdit_String();
            this.ctlPassword2 = new NewMethod.nEdit_String();
            this.ctlPassword = new NewMethod.nEdit_String();
            this.ctlLogin = new NewMethod.nEdit_String();
            this.ctlFullName = new NewMethod.nEdit_String();
            this.ctlZip = new NewMethod.nEdit_String();
            this.ctlState = new NewMethod.nEdit_String();
            this.ctlCity = new NewMethod.nEdit_String();
            this.ctlAddress2 = new NewMethod.nEdit_String();
            this.ctlAddress1 = new NewMethod.nEdit_String();
            this.ctlFax = new NewMethod.nEdit_String();
            this.ctlPhone = new NewMethod.nEdit_String();
            this.ctlCompanyName = new NewMethod.nEdit_String();
            this.cmdCancelFirst = new System.Windows.Forms.Button();
            this.cmdOKFirst = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.sv = new CoreWin.StatusView();
            this.pLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeft)).BeginInit();
            this.pWelcome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(12, 340);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(158, 20);
            this.txtUser.TabIndex = 0;
            this.txtUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUser_KeyPress);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(175, 340);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(161, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // cmdOK
            // 
            this.cmdOK.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOK.Location = new System.Drawing.Point(98, 371);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(239, 38);
            this.cmdOK.TabIndex = 2;
            this.cmdOK.Text = "&Login";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Location = new System.Drawing.Point(12, 371);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(82, 38);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // txtChange1
            // 
            this.txtChange1.Location = new System.Drawing.Point(13, 427);
            this.txtChange1.Name = "txtChange1";
            this.txtChange1.Size = new System.Drawing.Size(154, 20);
            this.txtChange1.TabIndex = 5;
            this.txtChange1.Visible = false;
            // 
            // txtChange2
            // 
            this.txtChange2.Location = new System.Drawing.Point(173, 427);
            this.txtChange2.Name = "txtChange2";
            this.txtChange2.Size = new System.Drawing.Size(154, 20);
            this.txtChange2.TabIndex = 6;
            this.txtChange2.Visible = false;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(8, 319);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(66, 15);
            this.lblUser.TabIndex = 7;
            this.lblUser.Text = "User Name";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(172, 319);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(61, 15);
            this.lblPassword.TabIndex = 8;
            this.lblPassword.Text = "Password";
            this.lblPassword.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblPassword_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 440);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "New Password";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(208, 440);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Confirm New Password";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label2.Visible = false;
            // 
            // lblError
            // 
            this.lblError.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(11, 303);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(331, 16);
            this.lblError.TabIndex = 13;
            this.lblError.Text = "<error>";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblError.Visible = false;
            // 
            // lnkNewPassword
            // 
            this.lnkNewPassword.AutoSize = true;
            this.lnkNewPassword.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkNewPassword.Location = new System.Drawing.Point(259, 317);
            this.lnkNewPassword.Name = "lnkNewPassword";
            this.lnkNewPassword.Size = new System.Drawing.Size(90, 13);
            this.lnkNewPassword.TabIndex = 16;
            this.lnkNewPassword.TabStop = true;
            this.lnkNewPassword.Text = "Change Password";
            this.lnkNewPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNewPassword_LinkClicked);
            // 
            // pLogin
            // 
            this.pLogin.Controls.Add(this.pictureBox2);
            this.pLogin.Controls.Add(this.loginComplete1);
            this.pLogin.Controls.Add(this.lnkNewPassword);
            this.pLogin.Controls.Add(this.picRight);
            this.pLogin.Controls.Add(this.picLeft);
            this.pLogin.Controls.Add(this.lblError);
            this.pLogin.Controls.Add(this.txtUser);
            this.pLogin.Controls.Add(this.lblPassword);
            this.pLogin.Controls.Add(this.txtPassword);
            this.pLogin.Controls.Add(this.lblUser);
            this.pLogin.Controls.Add(this.cmdCancel);
            this.pLogin.Controls.Add(this.cmdOK);
            this.pLogin.Location = new System.Drawing.Point(0, 0);
            this.pLogin.Name = "pLogin";
            this.pLogin.Size = new System.Drawing.Size(354, 415);
            this.pLogin.TabIndex = 21;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::RzInterfaceWin.Properties.Resources.SMC_Logo_Main;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(20, 28);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(312, 269);
            this.pictureBox2.TabIndex = 24;
            this.pictureBox2.TabStop = false;
            // 
            // loginComplete1
            // 
            this.loginComplete1.ForeColor = System.Drawing.Color.DarkGray;
            this.loginComplete1.Location = new System.Drawing.Point(0, 299);
            this.loginComplete1.Margin = new System.Windows.Forms.Padding(4);
            this.loginComplete1.Name = "loginComplete1";
            this.loginComplete1.Size = new System.Drawing.Size(354, 70);
            this.loginComplete1.TabIndex = 19;
            this.loginComplete1.Visible = false;
            // 
            // picRight
            // 
            this.picRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picRight.BackgroundImage")));
            this.picRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picRight.Location = new System.Drawing.Point(320, 299);
            this.picRight.Name = "picRight";
            this.picRight.Size = new System.Drawing.Size(16, 20);
            this.picRight.TabIndex = 15;
            this.picRight.TabStop = false;
            this.picRight.Visible = false;
            // 
            // picLeft
            // 
            this.picLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picLeft.BackgroundImage")));
            this.picLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLeft.Location = new System.Drawing.Point(11, 299);
            this.picLeft.Name = "picLeft";
            this.picLeft.Size = new System.Drawing.Size(16, 20);
            this.picLeft.TabIndex = 14;
            this.picLeft.TabStop = false;
            this.picLeft.Visible = false;
            // 
            // pWelcome
            // 
            this.pWelcome.Controls.Add(this.ctlEmail);
            this.pWelcome.Controls.Add(this.ctlPassword2);
            this.pWelcome.Controls.Add(this.ctlPassword);
            this.pWelcome.Controls.Add(this.ctlLogin);
            this.pWelcome.Controls.Add(this.ctlFullName);
            this.pWelcome.Controls.Add(this.ctlZip);
            this.pWelcome.Controls.Add(this.ctlState);
            this.pWelcome.Controls.Add(this.ctlCity);
            this.pWelcome.Controls.Add(this.ctlAddress2);
            this.pWelcome.Controls.Add(this.ctlAddress1);
            this.pWelcome.Controls.Add(this.ctlFax);
            this.pWelcome.Controls.Add(this.ctlPhone);
            this.pWelcome.Controls.Add(this.ctlCompanyName);
            this.pWelcome.Controls.Add(this.cmdCancelFirst);
            this.pWelcome.Controls.Add(this.cmdOKFirst);
            this.pWelcome.Controls.Add(this.label3);
            this.pWelcome.Controls.Add(this.lblWelcome);
            this.pWelcome.Controls.Add(this.pictureBox1);
            this.pWelcome.Location = new System.Drawing.Point(403, 15);
            this.pWelcome.Name = "pWelcome";
            this.pWelcome.Size = new System.Drawing.Size(347, 387);
            this.pWelcome.TabIndex = 22;
            // 
            // ctlEmail
            // 
            this.ctlEmail.AllCaps = false;
            this.ctlEmail.BackColor = System.Drawing.Color.White;
            this.ctlEmail.Bold = false;
            this.ctlEmail.Caption = "Email Address";
            this.ctlEmail.Changed = false;
            this.ctlEmail.IsEmail = false;
            this.ctlEmail.IsURL = false;
            this.ctlEmail.Location = new System.Drawing.Point(12, 327);
            this.ctlEmail.Margin = new System.Windows.Forms.Padding(5);
            this.ctlEmail.Name = "ctlEmail";
            this.ctlEmail.PasswordChar = '\0';
            this.ctlEmail.Size = new System.Drawing.Size(319, 21);
            this.ctlEmail.TabIndex = 19;
            this.ctlEmail.UseParentBackColor = false;
            this.ctlEmail.zz_Enabled = true;
            this.ctlEmail.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlEmail.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlEmail.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlEmail.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlEmail.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.Right;
            this.ctlEmail.zz_OriginalDesign = false;
            this.ctlEmail.zz_ShowLinkButton = false;
            this.ctlEmail.zz_ShowNeedsSaveColor = true;
            this.ctlEmail.zz_Text = "";
            this.ctlEmail.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlEmail.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlEmail.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlEmail.zz_UseGlobalColor = false;
            this.ctlEmail.zz_UseGlobalFont = false;
            this.ctlEmail.DataChanged += new NewMethod.ChangeHandler(this.ctl_DataChanged);
            // 
            // ctlPassword2
            // 
            this.ctlPassword2.AllCaps = false;
            this.ctlPassword2.BackColor = System.Drawing.Color.White;
            this.ctlPassword2.Bold = false;
            this.ctlPassword2.Caption = "Confirm Pwd";
            this.ctlPassword2.Changed = false;
            this.ctlPassword2.IsEmail = false;
            this.ctlPassword2.IsURL = false;
            this.ctlPassword2.Location = new System.Drawing.Point(182, 300);
            this.ctlPassword2.Margin = new System.Windows.Forms.Padding(5);
            this.ctlPassword2.Name = "ctlPassword2";
            this.ctlPassword2.PasswordChar = '*';
            this.ctlPassword2.Size = new System.Drawing.Size(142, 21);
            this.ctlPassword2.TabIndex = 18;
            this.ctlPassword2.UseParentBackColor = false;
            this.ctlPassword2.zz_Enabled = true;
            this.ctlPassword2.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlPassword2.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlPassword2.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlPassword2.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlPassword2.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.Right;
            this.ctlPassword2.zz_OriginalDesign = false;
            this.ctlPassword2.zz_ShowLinkButton = false;
            this.ctlPassword2.zz_ShowNeedsSaveColor = true;
            this.ctlPassword2.zz_Text = "";
            this.ctlPassword2.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlPassword2.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlPassword2.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlPassword2.zz_UseGlobalColor = false;
            this.ctlPassword2.zz_UseGlobalFont = false;
            this.ctlPassword2.DataChanged += new NewMethod.ChangeHandler(this.ctl_DataChanged);
            // 
            // ctlPassword
            // 
            this.ctlPassword.AllCaps = false;
            this.ctlPassword.BackColor = System.Drawing.Color.White;
            this.ctlPassword.Bold = false;
            this.ctlPassword.Caption = "Your Password";
            this.ctlPassword.Changed = false;
            this.ctlPassword.IsEmail = false;
            this.ctlPassword.IsURL = false;
            this.ctlPassword.Location = new System.Drawing.Point(12, 301);
            this.ctlPassword.Margin = new System.Windows.Forms.Padding(5);
            this.ctlPassword.Name = "ctlPassword";
            this.ctlPassword.PasswordChar = '*';
            this.ctlPassword.Size = new System.Drawing.Size(153, 21);
            this.ctlPassword.TabIndex = 17;
            this.ctlPassword.UseParentBackColor = false;
            this.ctlPassword.zz_Enabled = true;
            this.ctlPassword.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlPassword.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlPassword.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlPassword.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlPassword.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.Right;
            this.ctlPassword.zz_OriginalDesign = false;
            this.ctlPassword.zz_ShowLinkButton = false;
            this.ctlPassword.zz_ShowNeedsSaveColor = true;
            this.ctlPassword.zz_Text = "";
            this.ctlPassword.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlPassword.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlPassword.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlPassword.zz_UseGlobalColor = false;
            this.ctlPassword.zz_UseGlobalFont = false;
            this.ctlPassword.DataChanged += new NewMethod.ChangeHandler(this.ctl_DataChanged);
            // 
            // ctlLogin
            // 
            this.ctlLogin.AllCaps = false;
            this.ctlLogin.BackColor = System.Drawing.Color.White;
            this.ctlLogin.Bold = false;
            this.ctlLogin.Caption = "Login Name";
            this.ctlLogin.Changed = false;
            this.ctlLogin.IsEmail = false;
            this.ctlLogin.IsURL = false;
            this.ctlLogin.Location = new System.Drawing.Point(12, 275);
            this.ctlLogin.Margin = new System.Windows.Forms.Padding(5);
            this.ctlLogin.Name = "ctlLogin";
            this.ctlLogin.PasswordChar = '\0';
            this.ctlLogin.Size = new System.Drawing.Size(310, 21);
            this.ctlLogin.TabIndex = 16;
            this.ctlLogin.UseParentBackColor = false;
            this.ctlLogin.zz_Enabled = true;
            this.ctlLogin.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlLogin.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlLogin.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlLogin.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlLogin.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.Right;
            this.ctlLogin.zz_OriginalDesign = false;
            this.ctlLogin.zz_ShowLinkButton = false;
            this.ctlLogin.zz_ShowNeedsSaveColor = true;
            this.ctlLogin.zz_Text = "";
            this.ctlLogin.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlLogin.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlLogin.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlLogin.zz_UseGlobalColor = false;
            this.ctlLogin.zz_UseGlobalFont = false;
            this.ctlLogin.DataChanged += new NewMethod.ChangeHandler(this.ctl_DataChanged);
            // 
            // ctlFullName
            // 
            this.ctlFullName.AllCaps = false;
            this.ctlFullName.BackColor = System.Drawing.Color.White;
            this.ctlFullName.Bold = false;
            this.ctlFullName.Caption = "Your Full Name";
            this.ctlFullName.Changed = false;
            this.ctlFullName.IsEmail = false;
            this.ctlFullName.IsURL = false;
            this.ctlFullName.Location = new System.Drawing.Point(12, 250);
            this.ctlFullName.Margin = new System.Windows.Forms.Padding(5);
            this.ctlFullName.Name = "ctlFullName";
            this.ctlFullName.PasswordChar = '\0';
            this.ctlFullName.Size = new System.Drawing.Size(325, 21);
            this.ctlFullName.TabIndex = 15;
            this.ctlFullName.UseParentBackColor = false;
            this.ctlFullName.zz_Enabled = true;
            this.ctlFullName.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlFullName.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlFullName.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlFullName.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlFullName.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.Right;
            this.ctlFullName.zz_OriginalDesign = false;
            this.ctlFullName.zz_ShowLinkButton = false;
            this.ctlFullName.zz_ShowNeedsSaveColor = true;
            this.ctlFullName.zz_Text = "";
            this.ctlFullName.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlFullName.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlFullName.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlFullName.zz_UseGlobalColor = false;
            this.ctlFullName.zz_UseGlobalFont = false;
            this.ctlFullName.DataChanged += new NewMethod.ChangeHandler(this.ctl_DataChanged);
            // 
            // ctlZip
            // 
            this.ctlZip.AllCaps = false;
            this.ctlZip.BackColor = System.Drawing.Color.White;
            this.ctlZip.Bold = false;
            this.ctlZip.Caption = "City, State, Zip";
            this.ctlZip.Changed = false;
            this.ctlZip.IsEmail = false;
            this.ctlZip.IsURL = false;
            this.ctlZip.Location = new System.Drawing.Point(176, 223);
            this.ctlZip.Margin = new System.Windows.Forms.Padding(5);
            this.ctlZip.Name = "ctlZip";
            this.ctlZip.PasswordChar = '\0';
            this.ctlZip.Size = new System.Drawing.Size(158, 21);
            this.ctlZip.TabIndex = 14;
            this.ctlZip.UseParentBackColor = false;
            this.ctlZip.zz_Enabled = true;
            this.ctlZip.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlZip.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlZip.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlZip.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlZip.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.Right;
            this.ctlZip.zz_OriginalDesign = false;
            this.ctlZip.zz_ShowLinkButton = false;
            this.ctlZip.zz_ShowNeedsSaveColor = true;
            this.ctlZip.zz_Text = "";
            this.ctlZip.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlZip.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlZip.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlZip.zz_UseGlobalColor = false;
            this.ctlZip.zz_UseGlobalFont = false;
            // 
            // ctlState
            // 
            this.ctlState.AllCaps = false;
            this.ctlState.BackColor = System.Drawing.Color.White;
            this.ctlState.Bold = false;
            this.ctlState.Caption = "";
            this.ctlState.Changed = false;
            this.ctlState.IsEmail = false;
            this.ctlState.IsURL = false;
            this.ctlState.Location = new System.Drawing.Point(127, 223);
            this.ctlState.Margin = new System.Windows.Forms.Padding(5);
            this.ctlState.Name = "ctlState";
            this.ctlState.PasswordChar = '\0';
            this.ctlState.Size = new System.Drawing.Size(43, 21);
            this.ctlState.TabIndex = 13;
            this.ctlState.UseParentBackColor = false;
            this.ctlState.zz_Enabled = true;
            this.ctlState.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlState.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlState.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlState.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlState.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.Right;
            this.ctlState.zz_OriginalDesign = false;
            this.ctlState.zz_ShowLinkButton = false;
            this.ctlState.zz_ShowNeedsSaveColor = true;
            this.ctlState.zz_Text = "";
            this.ctlState.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlState.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlState.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlState.zz_UseGlobalColor = false;
            this.ctlState.zz_UseGlobalFont = false;
            // 
            // ctlCity
            // 
            this.ctlCity.AllCaps = false;
            this.ctlCity.BackColor = System.Drawing.Color.White;
            this.ctlCity.Bold = false;
            this.ctlCity.Caption = "";
            this.ctlCity.Changed = false;
            this.ctlCity.IsEmail = false;
            this.ctlCity.IsURL = false;
            this.ctlCity.Location = new System.Drawing.Point(12, 223);
            this.ctlCity.Margin = new System.Windows.Forms.Padding(5);
            this.ctlCity.Name = "ctlCity";
            this.ctlCity.PasswordChar = '\0';
            this.ctlCity.Size = new System.Drawing.Size(108, 21);
            this.ctlCity.TabIndex = 12;
            this.ctlCity.UseParentBackColor = false;
            this.ctlCity.zz_Enabled = true;
            this.ctlCity.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlCity.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlCity.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlCity.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlCity.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.Right;
            this.ctlCity.zz_OriginalDesign = false;
            this.ctlCity.zz_ShowLinkButton = false;
            this.ctlCity.zz_ShowNeedsSaveColor = true;
            this.ctlCity.zz_Text = "";
            this.ctlCity.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlCity.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlCity.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlCity.zz_UseGlobalColor = false;
            this.ctlCity.zz_UseGlobalFont = false;
            // 
            // ctlAddress2
            // 
            this.ctlAddress2.AllCaps = false;
            this.ctlAddress2.BackColor = System.Drawing.Color.White;
            this.ctlAddress2.Bold = false;
            this.ctlAddress2.Caption = "Address Line 2";
            this.ctlAddress2.Changed = false;
            this.ctlAddress2.IsEmail = false;
            this.ctlAddress2.IsURL = false;
            this.ctlAddress2.Location = new System.Drawing.Point(12, 196);
            this.ctlAddress2.Margin = new System.Windows.Forms.Padding(5);
            this.ctlAddress2.Name = "ctlAddress2";
            this.ctlAddress2.PasswordChar = '\0';
            this.ctlAddress2.Size = new System.Drawing.Size(323, 21);
            this.ctlAddress2.TabIndex = 11;
            this.ctlAddress2.UseParentBackColor = false;
            this.ctlAddress2.zz_Enabled = true;
            this.ctlAddress2.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlAddress2.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlAddress2.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlAddress2.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlAddress2.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.Right;
            this.ctlAddress2.zz_OriginalDesign = false;
            this.ctlAddress2.zz_ShowLinkButton = false;
            this.ctlAddress2.zz_ShowNeedsSaveColor = true;
            this.ctlAddress2.zz_Text = "";
            this.ctlAddress2.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlAddress2.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlAddress2.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlAddress2.zz_UseGlobalColor = false;
            this.ctlAddress2.zz_UseGlobalFont = false;
            // 
            // ctlAddress1
            // 
            this.ctlAddress1.AllCaps = false;
            this.ctlAddress1.BackColor = System.Drawing.Color.White;
            this.ctlAddress1.Bold = false;
            this.ctlAddress1.Caption = "Address Line 1";
            this.ctlAddress1.Changed = false;
            this.ctlAddress1.IsEmail = false;
            this.ctlAddress1.IsURL = false;
            this.ctlAddress1.Location = new System.Drawing.Point(12, 169);
            this.ctlAddress1.Margin = new System.Windows.Forms.Padding(5);
            this.ctlAddress1.Name = "ctlAddress1";
            this.ctlAddress1.PasswordChar = '\0';
            this.ctlAddress1.Size = new System.Drawing.Size(322, 21);
            this.ctlAddress1.TabIndex = 10;
            this.ctlAddress1.UseParentBackColor = false;
            this.ctlAddress1.zz_Enabled = true;
            this.ctlAddress1.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlAddress1.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlAddress1.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlAddress1.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlAddress1.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.Right;
            this.ctlAddress1.zz_OriginalDesign = false;
            this.ctlAddress1.zz_ShowLinkButton = false;
            this.ctlAddress1.zz_ShowNeedsSaveColor = true;
            this.ctlAddress1.zz_Text = "";
            this.ctlAddress1.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlAddress1.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlAddress1.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlAddress1.zz_UseGlobalColor = false;
            this.ctlAddress1.zz_UseGlobalFont = false;
            // 
            // ctlFax
            // 
            this.ctlFax.AllCaps = false;
            this.ctlFax.BackColor = System.Drawing.Color.White;
            this.ctlFax.Bold = false;
            this.ctlFax.Caption = "Fax #";
            this.ctlFax.Changed = false;
            this.ctlFax.IsEmail = false;
            this.ctlFax.IsURL = false;
            this.ctlFax.Location = new System.Drawing.Point(173, 142);
            this.ctlFax.Margin = new System.Windows.Forms.Padding(5);
            this.ctlFax.Name = "ctlFax";
            this.ctlFax.PasswordChar = '\0';
            this.ctlFax.Size = new System.Drawing.Size(117, 21);
            this.ctlFax.TabIndex = 9;
            this.ctlFax.UseParentBackColor = false;
            this.ctlFax.zz_Enabled = true;
            this.ctlFax.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlFax.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlFax.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlFax.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlFax.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.Right;
            this.ctlFax.zz_OriginalDesign = false;
            this.ctlFax.zz_ShowLinkButton = false;
            this.ctlFax.zz_ShowNeedsSaveColor = true;
            this.ctlFax.zz_Text = "";
            this.ctlFax.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlFax.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlFax.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlFax.zz_UseGlobalColor = false;
            this.ctlFax.zz_UseGlobalFont = false;
            // 
            // ctlPhone
            // 
            this.ctlPhone.AllCaps = false;
            this.ctlPhone.BackColor = System.Drawing.Color.White;
            this.ctlPhone.Bold = false;
            this.ctlPhone.Caption = "Phone #";
            this.ctlPhone.Changed = false;
            this.ctlPhone.IsEmail = false;
            this.ctlPhone.IsURL = false;
            this.ctlPhone.Location = new System.Drawing.Point(12, 142);
            this.ctlPhone.Margin = new System.Windows.Forms.Padding(5);
            this.ctlPhone.Name = "ctlPhone";
            this.ctlPhone.PasswordChar = '\0';
            this.ctlPhone.Size = new System.Drawing.Size(140, 21);
            this.ctlPhone.TabIndex = 8;
            this.ctlPhone.UseParentBackColor = false;
            this.ctlPhone.zz_Enabled = true;
            this.ctlPhone.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlPhone.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlPhone.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlPhone.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlPhone.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.Right;
            this.ctlPhone.zz_OriginalDesign = false;
            this.ctlPhone.zz_ShowLinkButton = false;
            this.ctlPhone.zz_ShowNeedsSaveColor = true;
            this.ctlPhone.zz_Text = "";
            this.ctlPhone.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlPhone.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlPhone.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlPhone.zz_UseGlobalColor = false;
            this.ctlPhone.zz_UseGlobalFont = false;
            // 
            // ctlCompanyName
            // 
            this.ctlCompanyName.AllCaps = false;
            this.ctlCompanyName.BackColor = System.Drawing.Color.White;
            this.ctlCompanyName.Bold = false;
            this.ctlCompanyName.Caption = "Company Name";
            this.ctlCompanyName.Changed = false;
            this.ctlCompanyName.IsEmail = false;
            this.ctlCompanyName.IsURL = false;
            this.ctlCompanyName.Location = new System.Drawing.Point(12, 115);
            this.ctlCompanyName.Margin = new System.Windows.Forms.Padding(5);
            this.ctlCompanyName.Name = "ctlCompanyName";
            this.ctlCompanyName.PasswordChar = '\0';
            this.ctlCompanyName.Size = new System.Drawing.Size(326, 21);
            this.ctlCompanyName.TabIndex = 7;
            this.ctlCompanyName.UseParentBackColor = false;
            this.ctlCompanyName.zz_Enabled = true;
            this.ctlCompanyName.zz_GlobalColor = System.Drawing.Color.Black;
            this.ctlCompanyName.zz_GlobalFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ctlCompanyName.zz_LabelColor = System.Drawing.SystemColors.ControlText;
            this.ctlCompanyName.zz_LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlCompanyName.zz_LabelLocation = NewMethod.nEdit_String.LabelLocations.Right;
            this.ctlCompanyName.zz_OriginalDesign = false;
            this.ctlCompanyName.zz_ShowLinkButton = false;
            this.ctlCompanyName.zz_ShowNeedsSaveColor = true;
            this.ctlCompanyName.zz_Text = "";
            this.ctlCompanyName.zz_TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ctlCompanyName.zz_TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlCompanyName.zz_TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlCompanyName.zz_UseGlobalColor = false;
            this.ctlCompanyName.zz_UseGlobalFont = false;
            this.ctlCompanyName.DataChanged += new NewMethod.ChangeHandler(this.ctl_DataChanged);
            // 
            // cmdCancelFirst
            // 
            this.cmdCancelFirst.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancelFirst.Location = new System.Drawing.Point(12, 354);
            this.cmdCancelFirst.Name = "cmdCancelFirst";
            this.cmdCancelFirst.Size = new System.Drawing.Size(81, 28);
            this.cmdCancelFirst.TabIndex = 6;
            this.cmdCancelFirst.Text = "&Cancel";
            this.cmdCancelFirst.UseVisualStyleBackColor = true;
            this.cmdCancelFirst.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOKFirst
            // 
            this.cmdOKFirst.Enabled = false;
            this.cmdOKFirst.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOKFirst.Location = new System.Drawing.Point(99, 354);
            this.cmdOKFirst.Name = "cmdOKFirst";
            this.cmdOKFirst.Size = new System.Drawing.Size(235, 28);
            this.cmdOKFirst.TabIndex = 5;
            this.cmdOKFirst.Text = "&OK";
            this.cmdOKFirst.UseVisualStyleBackColor = true;
            this.cmdOKFirst.Click += new System.EventHandler(this.cmdOKFirst_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(220, 73);
            this.label3.TabIndex = 2;
            this.label3.Text = "Please take a moment to fill in some details about your company, and to create a " +
    "new username and password for you to use within Rz4";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(70, 7);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(98, 22);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome!";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::RzInterfaceWin.Properties.Resources.RzMid;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(223, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(116, 98);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            // 
            // sv
            // 
            this.sv.BackColor = System.Drawing.Color.White;
            this.sv.Location = new System.Drawing.Point(12, 420);
            this.sv.Margin = new System.Windows.Forms.Padding(4);
            this.sv.Name = "sv";
            this.sv.Size = new System.Drawing.Size(324, 40);
            this.sv.TabIndex = 2;
            // 
            // Login
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(357, 469);
            this.ControlBox = false;
            this.Controls.Add(this.pWelcome);
            this.Controls.Add(this.pLogin);
            this.Controls.Add(this.sv);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtChange1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtChange2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rz Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLogin_FormClosed);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmLogin_KeyPress);
            this.pLogin.ResumeLayout(false);
            this.pLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeft)).EndInit();
            this.pWelcome.ResumeLayout(false);
            this.pWelcome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TextBox txtUser;
        protected System.Windows.Forms.TextBox txtPassword;
        protected StatusView sv;
        protected System.Windows.Forms.Button cmdOK;
        protected System.Windows.Forms.Button cmdCancel;
        protected System.Windows.Forms.TextBox txtChange1;
        protected System.Windows.Forms.TextBox txtChange2;
        protected System.Windows.Forms.Label lblUser;
        protected System.Windows.Forms.Label lblPassword;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Label lblError;
        protected System.Windows.Forms.PictureBox picLeft;
        protected System.Windows.Forms.PictureBox picRight;
        protected System.Windows.Forms.LinkLabel lnkNewPassword;
        protected LoginComplete loginComplete1;
        protected System.Windows.Forms.Panel pLogin;
        protected System.Windows.Forms.Panel pWelcome;
        protected System.Windows.Forms.PictureBox pictureBox1;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Label lblWelcome;
        protected nEdit_String ctlCity;
        protected nEdit_String ctlAddress2;
        protected nEdit_String ctlAddress1;
        protected nEdit_String ctlFax;
        protected nEdit_String ctlPhone;
        protected nEdit_String ctlCompanyName;
        protected System.Windows.Forms.Button cmdCancelFirst;
        protected System.Windows.Forms.Button cmdOKFirst;
        protected nEdit_String ctlEmail;
        protected nEdit_String ctlPassword2;
        protected nEdit_String ctlPassword;
        protected nEdit_String ctlLogin;
        protected nEdit_String ctlFullName;
        protected nEdit_String ctlZip;
        protected nEdit_String ctlState;
        protected System.Windows.Forms.PictureBox pictureBox2;
    }
}