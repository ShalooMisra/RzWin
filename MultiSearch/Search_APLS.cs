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
    public partial class Search_APLS : MultiSearch.Search
    {
        public Search_APLS(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            WebsiteName = "apls";
            ShowLogin = true;
            InitializeComponent();
        }
        //Public Functions
        public override String ToString() 
        { return "APLS"; }
        public override void InitWebsite()
        {
            Navigate("https://www.apls.com/entrance/login.cfm", false);
            IsInitialized = true;
            UserName_Name = "username";
            Password_Name = "password";
            LoginTag = "input";
            LoginValue = "Log in";
            LoginType = "Submit";
            base.InitWebsite();
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            SetTextBox("search_val", strPartNumber);
            ClickButton("", "Search", "Submit35694534", "", true); 
        }
    }
}
