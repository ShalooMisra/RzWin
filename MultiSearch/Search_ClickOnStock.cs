using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace MultiSearch
{
    public partial class Search_ClickOnStock : MultiSearch.Search
    {
        public Search_ClickOnStock(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            WebsiteName = "clickonstock";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        {
            return "ClickOnStock"; 
        }
        public override void InitWebsite()
        {
            Navigate("http://www.clickonstock.com/?partnumber=H1101", false);
            base.InitWebsite();
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("tbPartNumber", strPartNumber))
            {
                if (ClickElement("input", "", "ClickOnStock Search", "Button1", "Button1", true, ""))
                    IsAbleToSearch = true;
                else
                    SetStatusIconTimer(StatusIcon.Error);
            }
            else if (SetTextBox("TextBox5", strPartNumber))
            {
                if (ClickElement("input", "", "Search", "Button2", "Button2", true, ""))
                    IsAbleToSearch = true;
                else
                    SetStatusIconTimer(StatusIcon.Error);
            }
            FinishedSearch();
        }
    }
}
