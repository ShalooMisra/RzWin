using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace MultiSearch
{
    public partial class Search_Honeywell : MultiSearch.Search
    {
        public Search_Honeywell(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            WebsiteName = "honeywell";
            ShowLogin = true;
            InitializeComponent();
        }
        //Public Functions
        public override String ToString() { return "Honeywell"; }
        public override void InitWebsite()
        {
            Navigate("https://www.hpgparts.com/Login/j_login.jsp?logout=true", false);
            IsInitialized = true;
            UserName_Name = "username";
            Password_Name = "password";
            LoginTag = "a";
            LoginHref = "javascript:rememberUserName();document.login.submit();";
            LoginName = "Button_login";
            //LoginValue = "Login";
            //LoginType = "submit";
            base.InitWebsite();
            //if (msData.IsAAT)
            //    Timer1.Start();
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("part1", strPartNumber))
            {
                if (ClickLink("", "", "", "", true, "javascript:getPartSearchResults('part1')"))
                {
                    IsAbleToSearch = true;
                }
                else
                    SetStatusIconTimer(StatusIcon.Error);
            }
            else
                SetStatusIconTimer(StatusIcon.Error);
        }
        //Control Events
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (!Tools.Strings.StrExt(LastPartSearched))
                return;
            RunSearch(LastPartSearched, false);
        }
    }
}
