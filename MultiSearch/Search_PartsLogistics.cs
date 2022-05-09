using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//http://www.partslogistics.com
//USERNAME axel@arrowtronic.com
//PASSWORD 12345678

namespace MultiSearch
{
    public partial class Search_PartsLogistics : MultiSearch.Search
    {
        public Search_PartsLogistics(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = true;
            WebsiteName = "partslogistics";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        {
            return "PartsLogistics"; 
        }
        public override void InitWebsite()
        {
            Navigate("http://www.partslogistics.com/", false);
            UserName_Name = "loginid";
            Password_Name = "password";
            LoginTag = "a";
            LoginHref = "javascript:document.loginForm.submit();";
            LoginAlt = "Log In";
            base.InitWebsite();
            Navigate("http://www.partslogistics.com/?domain=partslogistics", false);
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("criteria", strPartNumber))
			{
                if (ClickElement("input", "", "", "", "", wait, "/images/btn/go2.gif", "Search", ""))
                    IsAbleToSearch = true;
                else
                    SetStatusIconTimer(StatusIcon.Error);
			}
            FinishedSearch();
        }


    }
}
