using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace MultiSearch
{
    public partial class Search_BrokerNet : MultiSearch.Search
    {
        public Search_BrokerNet(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = true;
            WebsiteName = "brokernet";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString()
        {
            return "BrokerNet";
        }
        public override void InitWebsite()
        {
            Navigate("http://www.brokernet.com", false);
            UserName_Name = "ctl00$ContentHeader$BrokerNetHead$txtUserName";
            Password_Name = "ctl00$ContentHeader$BrokerNetHead$txtpassword";
            LoginTag = "INPUT";
            LoginName = "ctl00$ContentHeader$BrokerNetHead$btnLogin";
            base.InitWebsite();
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            Navigate("http://www.brokernet.com/Members/Search.aspx?vw=parts", true);
            if (SetTextBox("ctlByParts$ctlByPartsSearch$txtPartNumbers", strPartNumber))
            {
                if (ClickElement("BUTTON", "", "", "", "ctlByParts_ctlByPartsSearch_btn_search", true, ""))
                    IsAbleToSearch = true;
                else
                    SetStatusIconTimer(StatusIcon.Error);
            }
            FinishedSearch();
        }
    }
}
