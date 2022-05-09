using System;
using System.Drawing;
using System.Windows.Forms;

using Core;

namespace NewMethod
{
    public partial class view_n_user : ViewPlusMenu // nView
    {
        public n_user CurrentUser;
        public view_n_user()
        {
            InitializeComponent();
        }

        public override void CompleteLoad()
        {
            CurrentUser = (n_user)GetCurrentObject();
            LoadSettings();
            NMWin.LoadFormValues(this, CurrentUser, null);

            LoadSalesGoalControls();

            LoadAssistantTo();



            LoadEmailClient();

            LoadHubspot();

            LoadLeaderBoardImage();




            cboCarrier.Text = CurrentUser.cell_carrier;

            base.CompleteLoad();
        }

        private void LoadLeaderBoardImage()
        {
            pbLeaderboardImage.SizeMode = PictureBoxSizeMode.Zoom;
            string url = CurrentUser.leaderboard_image_url;
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

        private void LoadEmailClient()
        {
            if (!string.IsNullOrEmpty(CurrentUser.email_client))
                ctl_email_client.SetValue(CurrentUser.email_client);
            else
                ctl_email_client.SetValue(Enums.EmailClient.Outlook);
        }

        private void LoadHubspot()
        {
            ctl_is_hubspot_enabled.zz_CheckValue = CurrentUser.is_hubspot_enabled;
        }

        private void SaveHubspot()
        {
            CurrentUser.is_hubspot_enabled = ctl_is_hubspot_enabled.zz_CheckValue;
        }



        private void SaveEmailClient()
        {
            string emailClient = Enums.EmailClient.Outlook.ToString();
            switch (ctl_email_client.GetValue_String().ToLower())
            {
                case "gmail":
                    {
                        emailClient = Enums.EmailClient.Gmail.ToString();
                        break;
                    }
                default:
                    {
                        emailClient = Enums.EmailClient.Outlook.ToString();
                        break;
                    }
            }

        }

        protected void LoadAssistantTo()
        {
            ctl_AssistantTo.CurrentObject = CurrentUser;
            ctl_AssistantTo.CurrentIDField = "assistant_to_uid";
            ctl_AssistantTo.CurrentNameField = "assistant_to_name";
            ctl_AssistantTo.SetUserName();
        }

        private void LoadSalesGoalControls()
        {
            ctl_commission_bogey.SetValue(((n_user)CurrentUser).commission_bogey);
            double commPercent = CurrentUser.commission_percent;
            ctl_commission_percent.SetValue(commPercent);
            chkViewAllAgentsCrossRef.Visible = false; //Checked = CurrentUser.GetSetting_Boolean("view_all_agents_in_crossref"); 
            ctl_monthly_quote_goal.SetValue(CurrentUser.monthly_quote_goal);
            ctl_monthly_booking_goal.SetValue(CurrentUser.monthly_booking_goal);
            ctl_monthly_invoiced_goal.SetValue(CurrentUser.monthly_invoiced_goal);
        }

        public override string GetCaption()
        {
            if (CurrentUser == null)
                return "";
            else
                return CurrentUser.name;
        }

        public override void CompleteSave()
        {
            CurrentUser.name = ctl_name.GetValue_String();

            //Password Save
            SaveUserPasswordHashAndSalt();
            SaveCommissionData();
            SaveSalesGoalData();




            n_user.CacheHouseAccounts(NMWin.ContextDefault);

            CurrentUser.cell_carrier = cboCarrier.Text;

            //if (Tools.Strings.StrExt(ctlChatSound.GetValue_String()))
            //{
            //    CurrentUser.SetSetting_Boolean(NMWin.ContextDefault, "use_chat_sound", true);
            //    CurrentUser.SetSetting(NMWin.ContextDefault, "chat_sound", ctlChatSound.GetValue_String());
            //}
            //else
            //    CurrentUser.SetSetting_Boolean(NMWin.ContextDefault, "use_chat_sound", false);
            SaveEmailClient();
            SaveHubspot();
            CurrentUser.SetLeaderboardImage(NMWin.ContextDefault, ctl_leaderboard_image_url.zz_Text);
            CurrentUser.Update(NMWin.ContextDefault);
            base.CompleteSave();
        }

        private void SaveSalesGoalData()
        {
            CurrentUser.monthly_quote_goal = Convert.ToDouble(ctl_monthly_quote_goal.GetValue());
            CurrentUser.monthly_booking_goal = Convert.ToDouble(ctl_monthly_booking_goal.GetValue());
            CurrentUser.monthly_quote_goal = Convert.ToDouble(ctl_monthly_quote_goal.GetValue());
        }

        private void SaveCommissionData()
        {
            long d = ctl_commission_percent.GetValue_Long();
            //(CurrentUser).commission_percent = ((double)d / (double)100);
            CurrentUser.commission_percent = (double)d;
            long b = ctl_commission_bogey.GetValue_Long();
            (CurrentUser).commission_bogey = ((double)b);
        }

        private void SaveUserPasswordHashAndSalt()
        {
            try
            {
                if (txtPassword.Changed)
                {

                    string pw = txtPassword.zz_Text.Trim();
                    NMWin.Sys.TheUserLogic.SaveUserPasswordHashAndSalt(NMWin.ContextDefault, CurrentUser, pw);
                    NMWin.Leader.Tell("Password updated successfully.");

                }
            }
            catch (Exception ex) { }


        }

        private void TestPasswordHashAndSalt()
        {
            string hash = CurrentUser.password_hash;
            string salt = CurrentUser.password_salt;
            if (string.IsNullOrEmpty(hash))
                throw new Exception("Invalid hash: (" + hash + ")");
            string testPW = txtTestPasswordHash.zz_Text.Trim();
            string currentPwHash = CurrentUser.password_hash;

            //Create a LoginIngo Object to pass to validation
            bool success = false;
            LoginInfo loginInfo = new LoginInfo();
            loginInfo.strUser = CurrentUser.login_name;
            loginInfo.strPassword = testPW;
            n_user u = NMWin.Sys.TheUserLogic.UserGetValidateByLoginHash(NMWin.ContextDefault, loginInfo, ref success);
            if (u != null)
                NMWin.Leader.Tell("Success, the password matches the hash!");
            else
                NMWin.Leader.Error("Fail, the password noes NOT match the hash!");
        }

        private void LoadSettings()
        {
            lvSettings.ShowTemplate("settings_per_user", "n_set", true);
            lvSettings.ShowData("n_set", "setting_key = '" + CurrentUser.unique_id + "'", "name");
        }

        private void lvSettings_AboutToAdd(object sender, AddArgs args)
        {
            args.Handled = true;

            String str = NMWin.Leader.AskForString("Setting name?", "", false, "Name");
            n_set s = n_set.New(NMWin.ContextDefault);
            s.name = str;
            s.setting_key = CurrentUser.unique_id;
            NMWin.ContextDefault.Insert(s);

            lvSettings.ReDoSearch();
        }

        private void cmdApply_Click(object sender, EventArgs e)
        {
            CompleteSave();
        }


        private void btnTestPasswordHash_Click(object sender, EventArgs e)
        {
            TestPasswordHashAndSalt();
        }
    }
}

