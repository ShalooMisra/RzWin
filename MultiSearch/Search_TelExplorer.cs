using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace MultiSearch
{
    public partial class Search_TelExplorer : MultiSearch.Search
    {
        public Search_TelExplorer(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = true;
            WebsiteName = "telexplorer";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString()
        {
            return "TelExplorer";
        }
        public override void InitWebsite()
        {
            Navigate("http://www.tel-explorer.com/Main_Page/Search/Multi_search.php", false);
            UserName_Name = "user";
            Password_Name = "pass";
            LoginTag = "BUTTON";
            LoginName = "submit";
            LoginType = "submit";
            LoginValue = "Log in";
            base.InitWebsite();
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            Navigate("http://www.tel-explorer.com/Main_Page/Search/Part_search.php", true);
            if (SetTextBox("part", strPartNumber))
            {
                if (ClickButton("", " Search ", "submit", "", true))
                    IsAbleToSearch = true;
                else
                    SetStatusIconTimer(StatusIcon.Error);
            }
            FinishedSearch();
        }
    }
}
