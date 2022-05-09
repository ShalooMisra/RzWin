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
    public partial class Search_McMaster : MultiSearch.Search
    {
        public Search_McMaster(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = true;
            WebsiteName = "mcmaster";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        {
            return "McMaster"; 
        }
        public override void InitWebsite()
        {
            base.InitWebsite();
            Navigate("http://www.mcmaster.com", true);
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("searchstring", strPartNumber))
			{
                if (ClickElement("img", "", "", "", "", wait, "/gfx/findoff1.gif?ver=2", "Submit your search", ""))
                    IsAbleToSearch = true;
                else
                    SetStatusIconTimer(StatusIcon.Error);
            }
            FinishedSearch();
        }
    }
}