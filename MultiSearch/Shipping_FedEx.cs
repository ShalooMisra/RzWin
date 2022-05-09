using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using NewMethod;

namespace MultiSearch
{
    public partial class Shipping_FedEx : MultiSearch.Search
    {
        protected ToolsWin.HtmlWin.LoginInfo loginInfo = new ToolsWin.HtmlWin.LoginInfo()
        {
            Username = "stevevasi",
            Password = "doublev1",
            UsernameInputControl = "document.loginForm.username",
            PasswordInputControl = "document.loginForm.password",
            LoginCommitControl = "login"
        };

        public Shipping_FedEx(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = true;
            WebsiteName = "fedex";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        { 
            return "FedEx"; 
        }

        public override void InitWebsite()
        {
            base.InitWebsite();
            this.cmdPOstOffers.TextAlign = ContentAlignment.MiddleRight;
            Size size = new Size(12, 12);
            this.cmdPOstOffers.Image = new Bitmap(this.cmdPOstOffers.Image, size);
            this.cmdPOstOffers.Text = "Make Label";            
            this.cmdPOstOffers.Visible = true;
            this.cmdPOstOffers.Enabled = true;
            Navigate("http://www.fedex.com/us/pckgenvlp/fcl/manage/myfedex/", true);
            ExecuteLoginScript();
        }

        private void ExecuteLoginScript()
        {
            string function = ToolsWin.HtmlWin.ScriptLogin(this.loginInfo, "", this.wb);
            this.wb.Document.InvokeScript(function);
            this.cmdLogin.Enabled = true;
        }

        protected override void cmdPOstOffers_Click(object sender, EventArgs e)
        {
            GoToQuickLabel();
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

        private void GoToQuickLabel()
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                using (var reader = new StreamReader(assembly.GetManifestResourceStream("MultiSearch.ShippingSites.ShippingStandaloneCode.htm")))
                {
                    this.wb.DocumentText = reader.ReadToEnd();
                    this.wb.Refresh();
                    
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            };
        }
    }
}
