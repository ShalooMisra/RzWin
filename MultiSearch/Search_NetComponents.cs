using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiSearch
{
    public partial class Search_NetComponents : MultiSearch.Search
    {
        //Constructors
        public Search_NetComponents(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            DoCheckStockDate = true;
            SavePageData = true;
            ShowLogin = true;
            WebsiteName = "netcomponents";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() { return "NetComponents"; }
        public override void InitWebsite()
        {
            SuppressNewWindows = false;
            Navigate("http://www.netcomponents.com/search.htm", false);
            UserName_Name = "login";
            Password_Name = "pwd";
            SecondPassword_Name = "org";
            LoginTag = "input";
            LoginName = "SUBMITLOGIN";
            LoginValue = "Login";
            LoginType = "submit";
            base.InitWebsite();
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
			if( SetTextBox("pn1", strPartNumber) )
			{
				if( ClickButton("", "Search", "", "", wait) )
					IsAbleToSearch = true;
			}
			else
                SetStatusIconTimer(StatusIcon.Error);
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
            if (GetPageHTML(wb).ToLower().Contains("img/ratings/"))
                key = StatusIcon.Results;
            else if (GetPageHTML(wb).ToLower().Contains("0 line items found."))
                key = StatusIcon.NoResults;
            else
                key = StatusIcon.Error;//?
            base.SetStatusIconTimer(key);
        }
    }
}

