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
    public partial class Search_UltimateAviation : MultiSearch.Search
    {
        public Search_UltimateAviation(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = true;
            WebsiteName = "ultimateaviation";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        {
            return "UltimateAviation"; 
        }
        public override void InitWebsite()
        {
            base.InitWebsite();
            Navigate("http://ultimateaviationsolutions.com", true);
        }
        public override void EnterLoginInfo()
        {
            SetTextBox("txtUser", xLogin.username);
            SetTextBox("txtPass", xLogin.password);
            //ClickElement("input", "", "Login", "submit", "submit", true, "imagenes/login.jpg");
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("txtSearch1", strPartNumber))
			{
                if (ClickElement("img", "", "", "", "", wait, "imagenes/search/go.jpg"))
                    IsAbleToSearch = true;
                else
                    SetStatusIconTimer(StatusIcon.Error);
			}
            FinishedSearch();
        }
    }
}