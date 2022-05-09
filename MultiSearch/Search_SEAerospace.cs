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
    public partial class Search_SEAerospace : MultiSearch.Search
    {
        public Search_SEAerospace(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = true;
            WebsiteName = "seaerospace";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        {
            return "SEAerospace"; 
        }
        public override void InitWebsite()
        {
            base.InitWebsite();
            Navigate("http://www.seaerospace.com", true);
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("substring", strPartNumber))
			{
                if (ClickElement("img", "", "", "", "", wait, "images/search_button.gif?up1"))
                    IsAbleToSearch = true;
                else
                    SetStatusIconTimer(StatusIcon.Error);
            }
            FinishedSearch();
        }
    }
}