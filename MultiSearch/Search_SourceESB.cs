using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiSearch
{
    public partial class Search_SourceESB : MultiSearch.Search
    {
        //Constructors
        public Search_SourceESB(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            DoCheckStockDate = true;
            ShowLogin = true;
            WebsiteName = "sourceesb";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() { return "SourceESB"; }
        public override void InitWebsite()
        {
            Navigate("http://www.sourceesb.com/", false);
            UserName_Name = "txtUserName";
            Password_Name = "pwdPassword";
            SecondPassword_Name = "";
            LoginTag = "input";
            LoginType = "image";
            LoginAlt = "Log In";
            base.InitWebsite();
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);

			if( SetTextBox("txtPartSearch", strPartNumber) )
			{
                if (!ClickElement("input", "", "", "", "", false, "images/btn-search.gif"))
                {
                    if( ClickElement("input", "", "", "", "", false, "images/home-btn-search.gif") )
                        IsAbleToSearch = true;
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
            if (GetPageHTML(wb).Replace(" ", "").ToLower().Contains("</span>part#/manufacturerand<span>"))
                key = StatusIcon.Results;
            else if (GetPageHTML(wb).Replace(" ", "").ToLower().Contains("distributor found"))
                key = StatusIcon.Results;
            else if (GetPageHTML(wb).Replace(" ", "").ToLower().Contains("<span>nopartnumbers/manufacturers</span>"))
                key = StatusIcon.NoResults;
            else
                key = StatusIcon.Error;//?
            base.SetStatusIconTimer(key);
        }
    }
}

