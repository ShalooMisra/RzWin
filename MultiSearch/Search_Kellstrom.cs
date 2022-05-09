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
    public partial class Search_Kellstrom : MultiSearch.Search
    {
        public Search_Kellstrom(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = true;
            WebsiteName = "kellstrom";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        {
            return "Kellstrom"; 
        }
        public override void InitWebsite()
        {
            base.InitWebsite();
            Navigate("http://www.kellstromdirect.com//AuthFiles/Login.asp", true);
            UserName_Name = "txtUsername";
            Password_Name = "txtPassword";
            LoginTag = "input";
            LoginType = "image";
            LoginValue = "log in";
            LoginName = "btnSubmit";
        }
        public override void EnterLoginInfo()
        {
            base.EnterLoginInfo();
            WaitForDone();
            Navigate("http://www.kellstromdirect.com/tools/rfq/middlemulti.asp", true);
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            Navigate("http://www.kellstromdirect.com/tools/rfq/middlemulti.asp", true);
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("partnumber", strPartNumber))
			{
                if (ClickElement("input", "", "Search Inventory", "submit1", "submit1", wait, ""))
                    IsAbleToSearch = true;
                else
                    SetStatusIconTimer(StatusIcon.Error);
            }
            FinishedSearch();
        }
    }
}