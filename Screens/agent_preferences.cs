using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewMethod;
using System.Collections;
using NewMethod.Enums;
using System.Net;
using System.IO;

namespace Rz5
{
    public partial class agent_preferences : UserControl
    {
        public agent_preferences()
        {
            InitializeComponent();
        }

        n_user CurrentAgent;
        ContextRz x;
        frmNewPassword frmNewPW;


        public void CompleteLoad()
        {
            x = RzWin.Context;
            CurrentAgent = (n_user)RzWin.Context.xUser;
            NMWin.LoadFormValues(this, CurrentAgent, null);
            LoadAgentInformation();
            LoadAgentSettings();
            DoResize();
        }

        private void LoadAgentInformation()
        {
            //Get list of teams
            // If team like "Management Team"
            //then Manager = Management Team Manager
            //Else Manager = Joe Mar
            if (CurrentAgent == null)
                return;


            lblNameValue.Text = !string.IsNullOrEmpty(CurrentAgent.name) ? CurrentAgent.name : "Not Set";
            lblEmailValue.Text = !string.IsNullOrEmpty(CurrentAgent.email_address) ? CurrentAgent.email_address : "Not Set";
            lblExtValue.Text = !string.IsNullOrEmpty(CurrentAgent.phone_ext) ? CurrentAgent.phone_ext : "Not Set";

            if (CurrentAgent.MainTeam == null)
                lblMainTeamValue.Text = CurrentAgent.MainTeam != null ? (CurrentAgent.MainTeam.name ?? "Not Set") : "Not Set";

            List<n_team> CurrentAgentTeams = n_team.GetAllTeamsForUser(x, CurrentAgent.unique_id);
            if (CurrentAgentTeams.Count == 0)
                lblManagerValue.Text = "No Teams Set";
            else
            {
                ArrayList ManagerList = CurrentAgent.GetCaptainUsers(x);
                if (ManagerList.Count == 0)
                    lblManagerValue.Text = "Joe Mar";
                else
                    lblManagerValue.Text = string.Join(",", ManagerList);
            }



        }



        private void LoadAgentSettings()
        {
            LoadEmailClient();
            LoadLeaderBoardImage();
        }

        public void CompleteSave()
        {
            try
            {
                SetEmailClient();                
                CurrentAgent.SetLeaderboardImage(RzWin.Context, ctl_leaderboard_image_url.zz_Text);               
                CurrentAgent.Update(RzWin.Context);
                LoadLeaderBoardImage();
                //RzWin.Context.Leader.Tell("Successfully updated agent preferences.");
            }
            catch (Exception ex)
            {
                RzWin.Context.Leader.Error(ex);
            }

        }

        
        private void LoadLeaderBoardImage()
        {

            pbLeaderboardImage.SizeMode = PictureBoxSizeMode.Zoom;
            string url = CurrentAgent.leaderboard_image_url;
            if (!string.IsNullOrEmpty(url))
                try
                {
                    Image i = Tools.Picture.CreateImageFromUrl(url);
                    pbLeaderboardImage.Image = i;

                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Parameter is not valid"))
                        NMWin.ContextDefault.Leader.Error("There was an error displaying the image URL you requested." + Environment.NewLine + Environment.NewLine + "URL: " + url + Environment.NewLine + Environment.NewLine + "  If your image url is really long, consider using a url shortener like \"goo.gl\".  Loading Default Image.");
                    else
                        NMWin.ContextDefault.Leader.Error(ex.Message);
                }

        }

        public void DoResize()
        {
            try
            {
            }
            catch
            {
            }
        }

        private void LoadEmailClient()
        {
            if (!string.IsNullOrEmpty(CurrentAgent.email_client))
                ctl_email_client.SetValue(CurrentAgent.email_client);
            else
                ctl_email_client.SetValue(EmailClient.Outlook);
        }

        private void SetEmailClient()
        {
            string emailClient = ctl_email_client.GetValue_String().ToLower();
            switch (emailClient)
            {
                case "gmail":
                    {
                        emailClient = EmailClient.Gmail.ToString();
                        break;
                    }
                case "outlook":
                    {
                        emailClient = EmailClient.Outlook.ToString();
                        break;
                    }
                default:
                    {
                        emailClient = EmailClient.Generic.ToString();
                        break;
                    }
            }

            CurrentAgent.email_client = emailClient;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CompleteSave();
        }

        private void lnkNewPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                ShowPasswordChange();                
            }
            catch(Exception ex)
            {
                RzWin.Leader.Error(ex.Message);
            }
            
        }

        private void ShowPasswordChange()
        {
           
            Login frmLogin = new Login();
            frmNewPW = new frmNewPassword();
            frmNewPW = new frmNewPassword();
            frmNewPW.GotInfo += new GotInfoHandler(HandlePasswordChange);
            frmNewPW.Show();
            frmNewPW.SetOnMouse();
            

        }

        private void HandlePasswordChange(Object sender, GotInfoArgs e)
        {
            //At this point, user has confirmed the new password, twice, thus a match.  Update hash and salt, ask user to login with new PW.

            string oldPw = e.OldPassword.Trim();
            //We're passing in the xInfo (LoginInfo) need to set the password to the old password for successful check.
            LoginInfo loginInfo = new LoginInfo();
            loginInfo.strUser = RzWin.User.name;
            loginInfo.strPassword = oldPw;
            bool oldPasswordMatches = false;
            n_user u = (n_user)NMWin.Sys.TheUserLogic.UserGetValidateByLoginHash(NMWin.ContextDefault, loginInfo, ref oldPasswordMatches);
            if (u == null)
            {
                //ShowUserAlert("Invalid User.");
                ShowUserAlert(loginInfo.ErrorMessage);
                return;
            }
            //bool matchesCurrentStoredPassword = Tools.Crypto.PasswordHasher.ValidateHashedAndSaltedPassword(oldPw, u.password_hash, u.password_salt);
            if (!oldPasswordMatches) 
                ShowUserAlert("Old password does not match.");            
            else
            {
                
                //Since the old password was valid, replace the salt and hash based on this new password.
                string newPw = e.NewPassword.Trim();
                NMWin.Sys.TheUserLogic.SaveUserPasswordHashAndSalt(NMWin.ContextDefault, u, newPw);
                u.Update(NMWin.ContextDefault);
                ShowUserAlert("Password reset successful.");
            }

            frmNewPW.Close();
        }

        private void ShowUserAlert(string alertMsg)
        {
            RzWin.Leader.Tell(alertMsg);
        }
    }
}
