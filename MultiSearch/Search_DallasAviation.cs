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
    public partial class Search_DallasAviation : MultiSearch.Search
    {
        public Search_DallasAviation(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = true;
            WebsiteName = "dallasaviation";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        {
            return "DallasAviation"; 
        }
        public override void InitWebsite()
        {
            base.InitWebsite();
            Navigate("http://catalog.ilsmart.com/6471/home.asp", true);
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("s.PartNumber", strPartNumber))
            {
                if (ClickElement("input", "", "", "Search", "", wait, "/pol/images/A16M/F1936CD4CF8A446288F166741CCBC008.gif", "Search", ""))
                    IsAbleToSearch = true;
                else
                    SetStatusIconTimer(StatusIcon.Error);
			}
            FinishedSearch();
        }
    }
}