using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiSearch
{
    public partial class Search_SMWeb : MultiSearch.Search
    {
        public Search_SMWeb(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = true;
            WebsiteName = "smweb";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        { 
            return "SMWeb"; 
        }
        public override void InitWebsite()
        {
            Navigate("https://smweb.componentcontrol.com/StockMarket/LoadLogin.do;jsessionid=D69B549C35BE29A9A6C499E80E5A0C8C", false);
            UserName_Name = "username";
            Password_Name = "password";
            SecondPassword_Name = "";
            LoginTag = "input";
            LoginType = "submit";
            LoginValue = "Login";
            base.InitWebsite();
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            if (!SetTextBox("partNumber", strPartNumber))
            {
                SetStatusIconTimer(StatusIcon.Error);
                FinishedSearch();
                return;
            }
            if (!ClickButton("Search", "Search", "Search", "", true))
            {
                SetStatusIconTimer(StatusIcon.Error);
                FinishedSearch();
                return;
            }
            IsAbleToSearch = true;
            FinishedSearch();
        }
    }
}

