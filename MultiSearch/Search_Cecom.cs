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
    public partial class Search_Cecom : MultiSearch.Search
    {
        public Search_Cecom(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = true;
            WebsiteName = "cecom";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        {
            return "Cecom"; 
        }
        public override void InitWebsite()
        {
            base.InitWebsite();
            Navigate("http://lrc3.monmouth.army.mil/nsn/index.cfm", true);
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            Navigate("http://lrc3.monmouth.army.mil/nsn/index.cfm", true);
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("NSN", strPartNumber))
			{
                if (ClickElement("input", "", "Submit", "", "", wait, ""))
                    IsAbleToSearch = true;
                else
                    SetStatusIconTimer(StatusIcon.Error);
			}
            FinishedSearch();
        }
    }
}