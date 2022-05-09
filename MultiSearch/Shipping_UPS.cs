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
    public partial class Shipping_UPS : MultiSearch.Search
    {
        protected ToolsWin.HtmlWin.LoginInfo loginInfo = new ToolsWin.HtmlWin.LoginInfo()
        {
            Username = "stevevoxx",
            Password = "doublev1",
            UsernameInputControl = "document.LoginPage.elements[\"bean.uid\"]",
            PasswordInputControl = "document.LoginPage.elements[\"bean.password\"]",
            LoginCommitControl = "document.LoginPage.elements[\"LOG IN\"].id"
        };

        public Shipping_UPS(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = true;
            WebsiteName = "ups";
            InitializeComponent();
        }

        public override String ToString()
        {
            return "UPS";
        }

        public override void InitWebsite()
        {
            base.InitWebsite();
            this.cmdPOstOffers.Visible = false;
            Navigate("https://www.ups.com/myups/login", true);
            ExecuteLoginScript();
        }

        private void ExecuteLoginScript()
        {
            string function = ToolsWin.HtmlWin.ScriptLogin(this.loginInfo, "submitToSSOLogin();", this.wb);
            this.wb.Document.InvokeScript(function);
            this.cmdLogin.Enabled = true;
        }

        protected override void cmdPOstOffers_Click(object sender, EventArgs e)
        {
            this.cmdLogin.Enabled = false;
        }

        protected override void cmdMainPage_Click(object sender, EventArgs e)
        {
            InitWebsite();
            this.cmdLogin.Enabled = true;
        }

        protected override void cmdLogin_Click(object sender, EventArgs e)
        {
            ExecuteLoginScript();
        }
    }
}
