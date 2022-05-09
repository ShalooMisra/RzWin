using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;


using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace MultiSearch
{
    public partial class Search_Dibbs : MultiSearch.Search
    {
        public Search_Dibbs(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            WebsiteName = "dibbs";
            ShowLogin = true;
            InitializeComponent();
        }
        //Public Override Functions
        public override void InitWebsite()
        {
            CertificateOverride oCertOverride = new CertificateOverride();
            ServicePointManager.ServerCertificateValidationCallback = oCertOverride.RemoteCertificateValidationCallback;
            WebRequest oReq = System.Net.HttpWebRequest.Create("https://www.dibbs.bsm.dla.mil/RA/LogIn.asp");
            WebResponse oResp = oReq.GetResponse();
            System.IO.StreamReader oSRead = new System.IO.StreamReader(oResp.GetResponseStream());
            String cContent = oSRead.ReadToEnd();
            Add(cContent);
            //Navigate("https://www.dibbs.bsm.dla.mil/", false);
            IsInitialized = true;
            UserName_Name = "uid";
            Password_Name = "password";
            base.InitWebsite();
        }
        public override String ToString()
        { return "Dibbs"; }
        public override void EnterLoginInfo()
        {
            base.EnterLoginInfo();
            ClickButton("", "Submit &raquo;&raquo;", "", "", true);
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);

            if (SetTextBox("searchTerms", strPartNumber))
            {
                if (!ClickElement("input", "", "", "", "", wait, "/docs/IO/8807/img8807.gif"))
                {
                    if (ClickElement("input", "", "", "", "Image1", wait, ""))
                        IsAbleToSearch = true;
                }
                if (!IsAbleToSearch)
                {
                    if (ClickElement("input", "", "", "", "product-submit", true, "/docs/IO/9094/img9094.gif"))
                        IsAbleToSearch = true;
                }
            }
            else
                SetStatusIconTimer(StatusIcon.Error);
        }

        public void Add(String strHTML)
        {
            try
            {
                Navigate("about:blank", true);
                HtmlDocument xDoc = wb.Document;
                xDoc.Write(strHTML);
            }
            catch (Exception)
            { }
        }
        internal class CertificateOverride : System.Net.ICertificatePolicy
        {
            public CertificateOverride()
            {
            }
            public bool CheckValidationResult(ServicePoint srvPoint, X509Certificate certificate, WebRequest request, int certificateProblem)
            {
                return true;
            }
            public Boolean RemoteCertificateValidationCallback(Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            {
                return true;
            }
        }
    }
}
