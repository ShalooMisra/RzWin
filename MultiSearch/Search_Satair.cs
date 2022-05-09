using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiSearch
{
    public partial class Search_Satair : MultiSearch.Search
    {
        public Search_Satair(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = true;
            WebsiteName = "satair";
            InitializeComponent();
        }

        public override String ToString() { return "Satair"; }

        public override void InitWebsite()
        {
            Navigate("http://ecom.satair.com/direct/login/login.jsp", false);
            UserName_Name = "edtName";
            Password_Name = "edtPassword";
            base.InitWebsite();
        }

        protected override void EnterAutoLoginInfo()
        {

        }

        public override void EnterLoginInfo()
        {
            base.EnterLoginInfo();
            if (ClickButton("", " Login ", "btnLogin", "", true))
            {
                while (wb.IsBusy) { Application.DoEvents(); }
                ClickLink("", "", "", "", true, "http://ecom.satair.com/direct/order/order.jsp?action=new&sec=quote");
            }
        }

        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("partno", strPartNumber))
            {
                SetTextBox("qty", "1");
                if (ClickButton("", "Enter", "btnEnter", "", wait))
                    IsAbleToSearch = true;
            }
            else
                SetStatusIconTimer(StatusIcon.Error);
        }
    }
}

