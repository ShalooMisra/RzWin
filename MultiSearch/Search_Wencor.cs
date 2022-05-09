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
    public partial class Search_Wencor : MultiSearch.Search
    {
        public Search_Wencor(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = true;
            WebsiteName = "wencor";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        { 
            return "Wencor"; 
        }
        public override void InitWebsite()
        {
            base.InitWebsite();
            Navigate("https://www.wencor.com/webcatalog/generalinfo.cgi", true);
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            Navigate("https://www.wencor.com/webcatalog/generalinfo.cgi", true);
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("power_search", strPartNumber))
			{
                if (ClickElement("input", "", "Power Search", "submit", "", wait, ""))
                    IsAbleToSearch = true;
                else
                    SetStatusIconTimer(StatusIcon.Error);
			}
            FinishedSearch();
        }
    }
}
