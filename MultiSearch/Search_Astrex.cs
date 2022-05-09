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
    public partial class Search_Astrex : MultiSearch.Search
    {
        public Search_Astrex(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = true;
            WebsiteName = "astrex";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        {
            return "Astrex"; 
        }
        public override void InitWebsite()
        {
            base.InitWebsite();
            Navigate("http://www.astrex.net/PartSearch.asp", true);
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("PartNo", strPartNumber))
			{
                if (ClickElement("input", "", "Search", "submit", "", wait, ""))
                    IsAbleToSearch = true;
                else
                    SetStatusIconTimer(StatusIcon.Error);
            }
            FinishedSearch();
        }
    }
}