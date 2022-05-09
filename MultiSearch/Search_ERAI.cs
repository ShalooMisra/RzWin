using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiSearch
{
    public partial class Search_ERAI : MultiSearch.Search
    {
        public Search_ERAI(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = true;
            WebsiteName = "erai";
            InitializeComponent();
        }

        public override String ToString() { return "ERAI"; }

        public override void InitWebsite()
        {
            Navigate("http://www.erai.com/", false);
            UserName_Name = "Login_ID";
            Password_Name = "Login_Password";
            base.InitWebsite();
        }

        public override void EnterLoginInfo()
        {
            base.EnterLoginInfo();
            ClickElement("input", "", "", "", "", true, "/images2/loginbtn.gif");
        }

        public override void RunSearch(String strPartNumber, bool wait)
        {
            //base.RunSearch(strPartNumber, wait);
            //if (SetTextBox("ItemDesc", strPartNumber))
            //{
            //    if (ClickElement("input", "", "Search", "", "", wait, ""))
            //        IsAbleToSearch = true;
            //}
            //else
            //{
            //    SetError();
            //}
        }
    }
}

