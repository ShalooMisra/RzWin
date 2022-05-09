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
    public partial class Search_Hawker : MultiSearch.Search
    {
        public Search_Hawker(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = true;
            WebsiteName = "hawker";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        {
            return "Hawker"; 
        }
        public override void InitWebsite()
        {
            Navigate("http://www.hawkerbeechcraft.com/rapid/Default.aspx", false);
            UserName_Name = "txtUsername";
            Password_Name = "txtPassword";
            LoginTag = "img";
            LoginSrc = "/App_Themes/rapid_MainTheme/tools_arrows.gif";
            LoginAlt = "Sign On";
            base.InitWebsite();
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("part_descrip", strPartNumber))
			{
                if (ClickElement("input", "", "", "enter", "Image2", wait, ""))
                    IsAbleToSearch = true;
                else
                    SetStatusIconTimer(StatusIcon.Error);
            }
            FinishedSearch();
        }
    }
}

