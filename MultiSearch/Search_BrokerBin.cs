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
    public partial class Search_BrokerBin : MultiSearch.Search
    {
        //Constructors
        public Search_BrokerBin(IMSDataProvider d) : base(d)
        {
            msData = d;
            ShowLogin = true;
            WebsiteName = "brokerbin";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString()
        {
            return "BrokerBin";
        }
        public override void InitWebsite()
        {
            Navigate("http://www.brokerbin.com", false);
            UserName_Name = "login";
            Password_Name = "password";
            LoginTag = "INPUT";
            LoginHref = "http://static2.brokerbin.com/bbin/images/gobtn.jpg";
            LoginType = "image";
            LoginValue = "Go";
            LoginName = "submit";
            base.InitWebsite();
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            Navigate("http://www.brokerbin.com/members/main.php?", true);
            if (SetTextBox("p", strPartNumber))
            {
                if (ClickButton("", "Search", "", "", true))
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
            if (GetPageHTML(wb).ToLower().Contains("id=cb-0"))
                key = StatusIcon.Results;
            else if (GetPageHTML(wb).ToLower().Contains("search returned 0 matches"))
                key = StatusIcon.NoResults;
            else
                key = StatusIcon.Error;//?
            base.SetStatusIconTimer(key);
        }
    }
}
