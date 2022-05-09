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
    public partial class Search_Connxx : MultiSearch.Search
    {
        public Search_Connxx(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = true;
            WebsiteName = "connxx";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        {
            return "Connxx"; 
        }
        public override void InitWebsite()
        {
            base.InitWebsite();
            Navigate("http://www.connxx.com/part.asp", true);
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("partnumber", strPartNumber))
			{
                if (ClickElement("input", "", "Submit", "Submit", "", wait, ""))
                    IsAbleToSearch = true;
                else
                    SetStatusIconTimer(StatusIcon.Error);
            }
            FinishedSearch();
        }
    }
}