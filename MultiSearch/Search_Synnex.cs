using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiSearch
{
    public partial class Search_Synnex : MultiSearch.Search
    {
        public Search_Synnex(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            WebsiteName = "synnex";
            ShowLogin = true;
            InitializeComponent();
        }
        //Public Functions
        public override String ToString() { return "Synnex"; }
        public override void InitWebsite()
        {
            Navigate("http://ec.synnex.com/ecexpress/login.html", false);
            IsInitialized = true;
            UserName_Name = "email";
            Password_Name = "password";
            LoginTag = "input";
            LoginValue = "Submit";
            LoginType = "submit";
            base.InitWebsite();
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            SetTextBox("criteriaContent", strPartNumber);
            ClickButton("", "Go", "directSearchSubmit", "", true);
        }

    }
}

