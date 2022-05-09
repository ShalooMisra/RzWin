using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//http://www.parthunter.com/home.aspx
//ID : axel@arrowtronic.com 
//Password : alexandre1

namespace MultiSearch
{
    public partial class Search_Parthunter : MultiSearch.Search
    {
        public Search_Parthunter(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = true;
            WebsiteName = "parthunter";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        {
            return "Parthunter"; 
        }
        public override void InitWebsite()
        {
            Navigate("http://www.parthunter.com/", false);
            UserName_Name = "username";
            Password_Name = "password";
            LoginType = "image";
            LoginTag = "input";
            LoginSrc = "images/en/submit.gif"; //src
            base.InitWebsite();
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("Partnumbers", strPartNumber))
			{
                if (ClickElement("input", "", "", "allAvailable", "allAvailable", wait, "images/en/aavailable.gif"))
                    IsAbleToSearch = true;
                else
                    SetStatusIconTimer(StatusIcon.Error);
			}
            FinishedSearch();
        }
    }
}
