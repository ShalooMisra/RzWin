using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace MultiSearch
{
    public partial class Search_Airliance : MultiSearch.Search
    {
        public Search_Airliance(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = true;
            WebsiteName = "airliance";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        {
            return "Airliance"; 
        }
        public override void InitWebsite()
        {
            base.InitWebsite();
            Navigate("http://sales.airliance.com/user/", true);
            UserName_Name = "ID";
            Password_Name = "pwd";
            LoginTag = "input";
            LoginType = "image";
            LoginValue = "Submit";
            LoginName = "submit1";
            LoginAlt = "Submit";
            LoginSrc = "/images/submit.jpg";
        }
        public override void EnterLoginInfo()
        {
            base.EnterLoginInfo();
            WaitForDone();
            Navigate("http://sales.airliance.com/user/search.asp", true);
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            Navigate("http://sales.airliance.com/user/search.asp", true);
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("query", strPartNumber))
			{
                if (ClickElement("input", "", "Quick Search", "submit2", "", wait, "/images/quick_search.jpg"))
                    IsAbleToSearch = true;
                else
                    SetStatusIconTimer(StatusIcon.Error);
			}
            FinishedSearch();
        }
    }
}