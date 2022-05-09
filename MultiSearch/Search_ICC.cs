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
    public partial class Search_ICC : MultiSearch.Search
    {
        public Search_ICC(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = true;
            WebsiteName = "icc";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        {
            return "ICC"; 
        }
        public override void InitWebsite()
        {
            base.InitWebsite();
            Navigate("http://www.connecticc.com/Default.aspx?Page=My%20Account%20Profile", true);
            UserName_Name = "txtEmail";
            Password_Name = "txtPassword";
            LoginTag = "input";
            LoginType = "image";
            LoginSrc = "customer/incoco/images/buttons/submit_b.gif";
            LoginName = "SubmitLogon_Content";
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("SearchText_1", strPartNumber))
			{
                if (ClickElement("input", "", "", "ButtonSearch", "", wait, "/customer/incoco/images/buttons/search_b.gif"))
                    IsAbleToSearch = true;
                else
                    SetStatusIconTimer(StatusIcon.Error);
			}
            FinishedSearch();
        }
    }
}