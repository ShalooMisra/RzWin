using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Tools;
using NewMethod;

namespace Rz5
{
    public partial class Login : Form
    {
        public bool CloseOnAccept = false;
        protected LoginInfo xInfo;
        protected bool LoginComplete = false;

        private frmNewPassword xnp;
        private bool bl1 = false;
        private bool br1 = false;


        public Login()
        {
            InitializeComponent();
            ToolsWin.Screens.ShowDownTo(this, sv);
            ToolsWin.Screens.ShowOverTo(this, pLogin);
            //this.Width = 359;
            //this.Height = 485;
        }

        void DisposeLogin()
        {
            NMWin.ContextDefault.Leader.StatusSet -= new Core.StatusSetHandler(Leader_StatusSet);
            NMWin.ContextDefault.Leader.ProgressSet -= new Core.ProgressSetHandler(Leader_ProgressSet);
        }

        //Public Functions
        public virtual void CompleteLoad(LoginInfo info, bool IncludeStatus, bool ShowWelcome)
        {
            NMWin.ContextDefault.Leader.StatusSet += new Core.StatusSetHandler(Leader_StatusSet);
            NMWin.ContextDefault.Leader.ProgressSet += new Core.ProgressSetHandler(Leader_ProgressSet);

            xInfo = info;
            //nStatus.RegisterStatusView(sv);

            if (ShowWelcome)
            {
                pLogin.Visible = false;
                pWelcome.Visible = true;

                pWelcome.Left = 0;
                pWelcome.Top = 0;

                DoResize(IncludeStatus);

            }
            else
            {
                //xInfo.GetAutoLogin(RzWin.Context, 

                pLogin.Visible = true;
                pWelcome.Visible = false;

                txtUser.Text = xInfo.strUser;

                if (Tools.Strings.StrExt(txtUser.Text))
                    txtPassword.Focus();
                else
                    txtUser.Focus();

                if (Tools.Strings.StrExt(xInfo.ErrorMessage))
                {
                    lblError.Visible = true;
                    lblError.Text = xInfo.ErrorMessage;
                }
                else
                {
                    lblError.Visible = false;
                }

                picLeft.Visible = xInfo.UserProblem;
                picRight.Visible = xInfo.PasswordProblem;

                DoResize(IncludeStatus);
            }
        }

        void Leader_ProgressSet(int percent)
        {
            sv.SetProgressByIndex(this, new CoreWin.ProgressArgs(0, percent));
        }

        void Leader_StatusSet(string s, Color c)
        {
            try
            {
                sv.SetStatusByIndex(this, new CoreWin.StatusArgs(0, s));
            }
            catch
            {
                ;
            }
        }

        protected void ClickCancel()
        {
            xInfo.IsCancelled = true;
            xInfo.IsReady = true;
            this.Close();
        }

        public virtual void DoResize(bool IncludeStatus)
        {
            try
            {
                sv.Visible = IncludeStatus;
                loginComplete1.DoResize();
                if (IncludeStatus)
                {
                    //this.Height = 490;  // 516;
                    ToolsWin.Screens.ShowDownTo(this, sv);
                }
                else
                {
                    //this.Height = 470; // 469;
                    ToolsWin.Screens.ShowDownTo(this, pWelcome);

                }
            }
            catch { }
        }
        //KT - Main Event handler for the login button
        protected virtual void ClickLogin()
        {
            //if (!Tools.Strings.StrCmp(Password, "jeesh") && !Tools.Strings.StrExt(UserName))
            if (!Tools.Strings.StrExt(UserName))
            {
                ShowUserAlert("Please enter your user name.");
                return;
            }
            xInfo.IsCancelled = false;
            xInfo.strUser = UserName;
            xInfo.strPassword = Password;
            xInfo.IsReady = true;
            LoginComplete = true;

            if (CloseOnAccept)
                Close();
            else
            {
                LoginCompleteShow();
            }
        }


        private void frmLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (Convert.ToInt32(e.KeyChar))
            {
                case 27: //esc
                    e.Handled = true;
                    ClickCancel();
                    break;
            }
        }

        protected virtual void ShowUserAlert(String s)
        {
            lblError.Text = s;
            lblError.Visible = true;
            picRight.Visible = false;
            picLeft.Visible = false;
            loginComplete1.Visible = false;
            cmdOK.Enabled = true;
        }
        private void ShowNewPassword()
        {
            xnp = new frmNewPassword();
            xnp.GotInfo += new GotInfoHandler(HandlePasswordChange);
            xnp.Show();
            xnp.SetOnMouse();
            loginComplete1.Visible = false;
            cmdOK.Enabled = true;
        }
        //private void HandleGotInfo(Object sender, GotInfoArgs e)
        //{
        //    txtPassword.Text = e.OldPassword;
        //    xInfo.strRequestedPassword = e.NewPassword;

        //    picLeft.Visible = false;
        //    picRight.Visible = false;
        //    lblError.Visible = true;
        //    lblError.Text = "Your new password will be activated after this login.";
        //    xnp.Close();
        //}

        private void HandlePasswordChange(Object sender, GotInfoArgs e)
        {
            //At this point, user has confirmed the new password, twice, thus a match.  Update hash and salt, ask user to login with new PW.

            string oldPw = e.OldPassword.Trim();
            //We're passing in the xInfo (LoginInfo) need to set the password to the old password for successful check.
            xInfo.strPassword = oldPw;
            bool success = false;
            n_user u = (n_user)NMWin.Sys.TheUserLogic.UserGetValidateByLoginHash(NMWin.ContextDefault, xInfo, ref success);
            if (u == null)
            {
                ShowUserAlert("Invalid User.");
                return;
            }            

            bool matchesCurrentStoredPassword = Tools.Crypto.PasswordHasher.ValidatePasswordHash(oldPw, u.password_hash);
            if (!matchesCurrentStoredPassword)
            {

                lblError.Text = "Old password does not match.";


            }
            else
            {
                ShowUserAlert("Password reset successful.");
                //Since the old password was valid, replace the salt and hash based on this new password.
                string newPw = e.NewPassword.Trim();
                NMWin.Sys.TheUserLogic.SaveUserPasswordHashAndSalt(NMWin.ContextDefault, u, newPw);
                u.Update(NMWin.ContextDefault);

            }


            picLeft.Visible = false;
            picRight.Visible = false;
            lblError.Visible = true;

            xnp.Close();
        }

        protected virtual void LoginCompleteShow()
        {
            loginComplete1.BringToFront();
            loginComplete1.Visible = true;
            cmdOK.Enabled = false;
        }

        //private Boolean CheckForComplete()
        //{
        //    nStatusLine sl = sv.GetLineByIndex(0);
        //    String currentstat = sl.lblStatus.Text;
        //    if (Tools.Strings.StrCmp(currentstat, "ready.") && LoginComplete)
        //        return true;
        //    return false;
        //}
        //Buttons
        private void cmdOK_Click(object sender, EventArgs e)
        {
            ClickLogin();
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            ClickCancel();
            loginComplete1.Visible = false;
        }
        //Control Events
        //KT - This looks like where the TextChanged event that fires as soon as the correct password is in place.
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            //if (Tools.Strings.StrCmp(txtPassword.Text, "jeesh"))
            //{
            //    ClickLogin();
            //}
        }
        //KT - Some secret right-click way to bypass login?
        private void lblPassword_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (bl1)
                {
                    br1 = true;
                    return;
                }
            }
            else
            {
                if (!bl1)
                {
                    bl1 = true;
                    return;
                }

                if (br1)
                {
                    //txtPassword.Text = "jeesh";
                    ClickLogin();
                }
            }
        }
        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                e.Handled = true;
                ClickLogin();
            }
        }
        //KT - Event handler for the login label?
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                e.Handled = true;
                ClickLogin();
            }

            //if (Tools.Strings.StrCmp(txtPassword.Text, "jeesh"))
            //    ClickLogin();
        }
        private void lnkNewPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowNewPassword();
        }

        public virtual void CheckFocus()
        {
            try
            {
                if (Tools.Strings.StrExt(txtUser.Text))
                    txtPassword.Focus();
                else
                    txtUser.Focus();
            }
            catch { }
        }

        protected virtual string UserName
        {
            get
            {
                return txtUser.Text;
            }
        }

        protected virtual string Password
        {
            get
            {
                return txtPassword.Text;
            }
        }

        private void ctl_DataChanged(GenericEvent e)
        {
            CheckEnable();
        }

        void CheckEnable()
        {
            cmdOKFirst.Enabled = false;

            if (!Tools.Strings.StrExt(ctlCompanyName.GetValue_String()))
                return;

            if (!Tools.Strings.StrExt(ctlFullName.GetValue_String()))
                return;

            if (!Tools.Strings.StrExt(ctlLogin.GetValue_String()))
                return;

            if (!Tools.Strings.StrExt(ctlPassword.GetValue_String()))
                return;

            cmdOKFirst.Enabled = true;
        }

        private void cmdOKFirst_Click(object sender, EventArgs e)
        {
            if (ctlPassword.GetValue_String() != ctlPassword2.GetValue_String())
            {
                RzWin.Leader.Tell("Please make sure that the password you entered matches the confirmation password.");
                return;
            }

            NewMethod.n_user u = NewMethod.n_user.New(RzWin.Context);
            u.name = ctlFullName.GetValue_String();
            u.login_name = ctlLogin.GetValue_String();
            u.login_password = ctlPassword.GetValue_String();
            u.email_address = ctlEmail.GetValue_String();
            u.super_user = true;
            u.template_editor = true;
            u.Insert(RzWin.Context);

            u.SetSetting_Boolean(RzWin.Context, "show_intro_screen", true);

            RzWin.Context.xSys.CacheUsers(RzWin.Context);
            RzWin.Logic.CacheSalesPeople(RzWin.Context);
            //Rz3App.CacheAssignedAgents();

            OwnerSettings.SetValue(RzWin.Context, OwnerSettingField.owner_companyname, ctlCompanyName.GetValue_String());
            OwnerSettings.SetValue(RzWin.Context, OwnerSettingField.owner_address1, ctlAddress1.GetValue_String());
            OwnerSettings.SetValue(RzWin.Context, OwnerSettingField.owner_address2, ctlAddress2.GetValue_String());
            OwnerSettings.SetValue(RzWin.Context, OwnerSettingField.owner_city, ctlCity.GetValue_String());
            OwnerSettings.SetValue(RzWin.Context, OwnerSettingField.owner_state, ctlState.GetValue_String());
            OwnerSettings.SetValue(RzWin.Context, OwnerSettingField.owner_zip, ctlZip.GetValue_String());
            OwnerSettings.SetValue(RzWin.Context, OwnerSettingField.owner_phone, ctlPhone.GetValue_String());
            OwnerSettings.SetValue(RzWin.Context, OwnerSettingField.owner_fax, ctlFax.GetValue_String());

            txtUser.Text = u.login_name;
            txtPassword.Text = u.login_password;
            ClickLogin();
        }
        //KT - This picture box exists outside oft he main login frame, if you widen it in designer, you will see it.
        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (!RzWin.Leader.AreYouSure("clear and log in"))
                return;

            OwnerSettings.SetValue(RzWin.Context, OwnerSettingField.owner_companyname, "");
            OwnerSettings.SetValue(RzWin.Context, OwnerSettingField.owner_address1, "");
            OwnerSettings.SetValue(RzWin.Context, OwnerSettingField.owner_address2, "");
            OwnerSettings.SetValue(RzWin.Context, OwnerSettingField.owner_city, "");
            OwnerSettings.SetValue(RzWin.Context, OwnerSettingField.owner_state, "");
            OwnerSettings.SetValue(RzWin.Context, OwnerSettingField.owner_zip, "");
            OwnerSettings.SetValue(RzWin.Context, OwnerSettingField.owner_phone, "");
            OwnerSettings.SetValue(RzWin.Context, OwnerSettingField.owner_fax, "");

            //txtPassword.Text = "jeesh";
            ClickLogin();
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            //nStatus.UnRegisterStatusView(sv);
        }

        delegate void CloseAndDisposeHandler();
        public void CloseAndDispose()
        {
            if (InvokeRequired)
                Invoke(new CloseAndDisposeHandler(ActuallyCloseAndDispose));
            else
                ActuallyCloseAndDispose();
        }

        public void ActuallyCloseAndDispose()
        {
            try
            {
                this.Close();
                this.Dispose();
            }
            catch { }
        }
        //KT - Denotes the admin login?
        public void AdminLogin()
        {
            //txtPassword.Text = "jeesh";
            ClickLogin();
        }
    }
}