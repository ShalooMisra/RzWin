using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiSearch
{
    public partial class Search_PartMiner : MultiSearch.Search
    {
        //Constructors
        public Search_PartMiner(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = true;
            WebsiteName = "partminer";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        { 
            return "PartMiner"; 
        }
        public override void InitWebsite()
        {
            Navigate("http://www.partminer.com/servlet/LoginFindIt", false);
            UserName_Name = "txtemailaddress";
            Password_Name = "txtpassword";
            LoginTag = "a";
            LoginHref = "javascript:onLogon()";
            LoginType = "img";
            base.InitWebsite();
            IsInitialized = true;
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);

			Navigate("http://www.partminer.com/servlet/LoginFindIt", true);

			if( SetTextBox("keyword", strPartNumber) )
			{
				if( ClickElement("img", "", "", "", "", wait, "images/button_submit.gif") )
                    IsAbleToSearch = true;
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

