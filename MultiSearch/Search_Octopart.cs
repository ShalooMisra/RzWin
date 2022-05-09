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
    public partial class Search_Octopart : MultiSearch.Search
    {
        public Search_Octopart(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            WebsiteName = "octopart";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        {
            return "Octopart"; 
        }
        public override void InitWebsite()
        {
            Navigate("http://octopart.com/", false);
            base.InitWebsite();
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("q", strPartNumber))
            {
                if (ClickButton("", "Search", "", "submitbutton", wait))
                    IsAbleToSearch = true;
                else
                    SetStatusIconTimer(StatusIcon.Error);
            }
            FinishedSearch();
        }
    }
}
