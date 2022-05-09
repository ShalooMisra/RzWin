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
    public partial class Search_TelecomFinders : MultiSearch.Search
    {
        //Constructors
        public Search_TelecomFinders(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = true;
            WebsiteName = "telecomfinders";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString()
        {
            return "TelecomFinders";
        }
        public override void InitWebsite()
        {
            Navigate("https://www.telecomfinders.com/cgi/en/sign-in.prep", false);
            UserName_Name = "Session_Username";
            Password_Name = "Session_Password";
            base.InitWebsite();
            ClickButton("Sign In", "", "", "", true);
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            //Navigate("http://www.telecomfinders.com/cgi/en/buy.dashboard.read", true);
            if (SetTextBox("Q", strPartNumber))
            {
                if (ClickElement("a", "", "", "", "", true, "", "", "javascript:removeFreeTextSpecialChars('search_bar_criteria');toggleRecentSearchesDiv('recentSearchContainer','recentSearchDropDownArrow');document.getElementById('searchForm').submit()"))
                    IsAbleToSearch = true;
            }
            FinishedSearch();
        }
        public override void SetStatusIconTimer()
        {
            if (!HasSearched)
            {
                base.SetStatusIconTimer();
                return;
            }
            StatusIcon key = StatusIcon.Null;
            if (GetPageHTML(wb).ToLower().Contains("search results"))
                key = StatusIcon.Results;
            else if (GetPageHTML(wb).ToLower().Contains("is currently not in stock"))
                key = StatusIcon.NoResults;
            else
                key = StatusIcon.Error;//?
            base.SetStatusIconTimer(key);
        }
    }
}
