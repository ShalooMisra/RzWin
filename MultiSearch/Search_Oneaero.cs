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
    public partial class Search_Oneaero : MultiSearch.Search
    {
        public Search_Oneaero(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = true;
            WebsiteName = "oneaero";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        { 
            return "Oneaero"; 
        }
        public override void InitWebsite()
        {
            Navigate("https://oneaero.com/", false);
            UserName_Name = "user_id";
            Password_Name = "password";
            SecondPassword_Name = "";
            LoginTag = "input";
            LoginType = "submit";
            LoginValue = "Logon";
            LoginText = "";
            base.InitWebsite();
        }
        public override void EnterLoginInfo()
        {
            SetTextBox("user_id", xLogin.username);
            SetTextBox("password", xLogin.password);
            ClickElement("input", "", "Login", "", "", true, "");
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("search", strPartNumber))
			{
                if (ClickElement("input", "", "Find Parts", "", "", wait,""))
                    IsAbleToSearch = true;
                else
                    SetStatusIconTimer(StatusIcon.Error);
			}
            FinishedSearch();
        }
    }
}