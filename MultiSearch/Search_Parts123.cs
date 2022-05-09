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
    public partial class Search_Parts123 : MultiSearch.Search
    {
        public Search_Parts123(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = true;
            WebsiteName = "parts123";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        { 
            return "Parts123"; 
        }
        public override void InitWebsite()
        {
            base.InitWebsite();
            Navigate("http://www.parts123.com/PartFrame.asp?ZTM=cadefija&GHOME=www.parts123.com", true);
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("PART", strPartNumber))
			{
                if (ClickElement("a", "", "", "", "", wait, "", "", "javascript:SubmitIt()"))
                    IsAbleToSearch = true;
                else
                    SetStatusIconTimer(StatusIcon.Error);
			}
            FinishedSearch();
        }
    }
}