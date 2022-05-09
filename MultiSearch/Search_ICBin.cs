using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MultiSearch
{
    public partial class Search_ICBin : MultiSearch.Search
    {
        public Search_ICBin(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = true;
            WebsiteName = "icbin";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString()
        {
            return "ICBin";
        }
        public override void InitWebsite()
        {
            Navigate("http://www.icbin.com", false);
            UserName_Name = "login";
            Password_Name = "password";
            LoginTag = "INPUT";
            LoginHref = "/buttons/login-button.jpg";
            LoginType = "image";
            LoginValue = "submit";
            LoginName = "submit";
            base.InitWebsite();
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            Navigate("http://www.icbin.com/members/", true);
            if (SetTextBox("p", strPartNumber))
            {
                if (ClickElement("input", "", "Search", "", "search", true, "", "", ""))
                    IsAbleToSearch = true;
                else
                    SetStatusIconTimer(StatusIcon.Error);
            }
            FinishedSearch();
        }
    }
}
