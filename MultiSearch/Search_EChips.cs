using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiSearch
{
    public partial class Search_EChips : MultiSearch.Search
    {
        //Constructors
        public Search_EChips(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            DoCheckStockDate = true;
            ShowLogin = true;
            WebsiteName = "echips";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() { return "EChips"; }
        public override void InitWebsite()
        {
            Navigate("http://www.echipsonline.com/", false);  //i know that 4 w's isn't right, but it works.  WTF?
            UserName_Name = "ctl00$txtUsername";
            Password_Name = "ctl00$txtPassword";
            SecondPassword_Name = "";
            LoginTag = "input";
            LoginType = "submit";
            LoginValue = "Logon";
            base.InitWebsite();
        }
        public override void DocumentReallyComplete()
        {
            if (IsInitialized && !IsAbleToSearch)
            {
                int z;
                if( ClickElement("IMG", "", "", "", "", false, "/media/images/ico-search-0.gif") )
                    z = 0;
            }
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);

			bool y = false;
			if( SetTextBox("PartNum", strPartNumber) )
			{
				if( !ClickElement("input", "", "", "", "", false, "search-again.gif"))
				{
                    if (!ClickElement("input", "", "     Search     ", "submit2", "", wait, ""))
                        SetStatusIconTimer(StatusIcon.Error);
                    else
                    {
                        IsAbleToSearch = true;
                    }
				}
                else
                {
                    IsAbleToSearch = true;
                }
			}
			else
                SetStatusIconTimer(StatusIcon.Error);
        }
        public override void SetStatusIconTimer()
        {
            if (!HasSearched)
            {
                base.SetStatusIconTimer();
                return;
            }
            StatusIcon key = StatusIcon.Null;
            if (GetPageHTML(wb).ToLower().Contains("X"))
                key = StatusIcon.Results;
            else if (GetPageHTML(wb).ToLower().Contains("X"))
                key = StatusIcon.NoResults;
            else
                key = StatusIcon.Error;//?
            base.SetStatusIconTimer(key);
        }
    }
}

