using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Tools;
//using Tie;
using NewMethod;

namespace Rz5
{
    public partial class FeaturesAndUpgrades : UserControl
    {
        //Private Variables
        private ContextNM TheContext;

        //Constructors
        public FeaturesAndUpgrades()
        {
            InitializeComponent();
            gb.Visible = false;
            status.Visible = false;
        }
        //Public Functions
        public void CompleteLoad()
        {
            CompleteLoad(RzWin.Form.TheContextNM);
        }
        public void CompleteLoad(ContextNM x)
        {
            TheContext = x;
            ShowLicense();
            //if (RzLicense.LicenseType == LicenseTypes.Lite)
                wb.Navigate("http://www.recognin.com/BuyRz3Pro.asp");
            //else
            //    wb.Navigate("http://www.recognin.com/BuyRz3Pro.asp");
            long current = GetCurrentVersion();
            lblCurrentVersion.Text = Tools.Number.LongFormat(current);
            long latest = GetLatestVersion();
            lblLatestVersion.Text = Tools.Number.LongFormat(latest);
            lblUpdate.Visible = (current < latest);
        }
        public void DoResize()
        {
            try
            {
                //gb.Left = 0;
                //gb.Top = 0;

                //status.Left = 0;
                //status.Top = gb.Bottom;
                //status.Height = this.ClientRectangle.Height - (gbLicense.Height + status.Top);

                gbLicense.Top = this.ClientRectangle.Height - gbLicense.Height;
                gbLicense.Left = 0;
                gbLicense.Width = this.ClientRectangle.Width;

                wb.Left = 0;
                wb.Top = 0;
                wb.Width = this.ClientRectangle.Width - wb.Left;
                wb.Height = this.ClientRectangle.Height - gbLicense.Height;
            }
            catch { }
        }
        //Private Functions
        private void RunUpdate()
        {
            RzWin.Form.ShowVersionUpdate();
        }
        private long GetCurrentVersion()
        {
            return Tools.Files.GetHighestFileNumber(Tools.FileSystem.GetAppPath(), "rz3.exe");
        }
        private long GetLatestVersion()
        {
            String s = Tools.Strings.DownloadInternetString("http://www.newmethodsoftware.com/tierack.txt");
            if (!Tools.Strings.StrExt(s))
                return 0;
            try
            {
                return Int64.Parse(nTools.GetFirstLine(s));
            }
            catch { return 0; }
        }
        private void ShowLicense()
        {
            txtLicenseID.Text = RzLicense.LicenseID;
            lblLicenseType.Text = "Pro"; // RzLicense.LicenseType.ToString();
            lblLicenseExpiration.Text = "Never";
            lblLicenseExpiration.ForeColor = Color.Gray;
        }
        private void Do_ApplyLicense()
        {
            Do_ApplyLicense(RzWin.Form.TheContextNM);
        }
        private void Do_ApplyLicense(ContextNM x)
        {
            if (ToolsWin.Keyboard.GetControlAndShiftKeys())
            {
                if (RzLicense.ApplyNewLicense(RzWin.Context))  //LicenseTypes.Lite
                    ShowLicense();
                else
                    x.TheLeader.Tell("Error writing license");
                return;
            }
            else if (ToolsWin.Keyboard.GetControlKey())
            {
                if (RzLicense.ApplyNewLicense(RzWin.Context))  //LicenseTypes.Pro
                    ShowLicense();
                else
                    x.TheLeader.Tell("Error writing license");
                return;
            }
            else if (ToolsWin.Keyboard.GetShiftKey())
            {
                if (RzLicense.ApplyNewLicense(RzWin.Context))  //LicenseTypes.Custom
                    ShowLicense();
                else
                    x.TheLeader.Tell("Error writing license");
                return;
            }

            String s = x.TheLeader.AskForString("Please paste or enter the new license code", "", true);
            if (!Tools.Strings.StrExt(s))
                return;
            s = nTools.WebTrim(s.Trim().Replace("\r", "").Replace("\n", "").Replace("<br>", "")).Trim();

            if (s.StartsWith("Rz"))
            {
                String url = "http://www.recognin.com/licenses/" + s + ".txt";
                String dat = Tools.Strings.DownloadInternetString(url);
                if (!Tools.Strings.StrCmp(dat, "OK"))
                {
                    x.TheLeader.TellTemp("This license key doesn't appear to be available.  Please contact Recognin for assistance.");
                    return;
                }

                if (RzLicense.ApplyNewLicense(RzWin.Context))  //LicenseTypes.Pro
                {
                    ShowLicense();
                    nEmailMessage m = new nEmailMessage();
                    m.ToAddress = "register@recognin.com";
                    m.Subject = "Rz Registration " + s;
                    m.HTMLBody = s;
                    RzWin.Logic.SetFromNotification(m);
                    m.Send();
                }
                else
                    x.TheLeader.Tell("Error writing license");
                return;
            }
            else
            {
                if (RzLicense.IsValidLicense(s))
                {
                    RzLicense.ApplyNewLicense(RzWin.Context, s);
                    ShowLicense();
                }
                else
                {
                    x.TheLeader.Tell("The license code entered does not appear to be a valid Rz3 license.  Please be sure you're copying directly from a recognin email or web page and pasting into the box.");
                }
            }
        }
        //Control Events
        private void lblApplyLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Do_ApplyLicense();
        }
        private void wb_OnNavigate(GenericEvent e)
        {
            //if (e.Message.EndsWith("buy_now.htm"))
            //    return;
            //if (Tools.Strings.HasString(e.Message, "[DO_PURCHASE]"))
            //{
            //    e.Handled = true;
            //    LicenseTypes type = LicenseTypes.Pro;
            //    String ReferenceID = "";
            //    if (frmPurchase.ShowPurchaseConfirmation(type, ref ReferenceID, this.ParentForm))
            //    {
            //        if (!Tools.Strings.StrExt(ReferenceID))
            //            ReferenceID = Tools.Strings.GetNewID();
            //        RzLicense.ApplyNewLicense(ReferenceID, type);
            //        ShowLicense();
            //        TheContext.TheLeader.TellTemp("The Rz3 Pro license was applied, and will take effect the next time Rz3 is opened.");
            //    }
            //}
        }
        private void lblUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RunUpdate();
        }
        private void FeaturesAndUpgrades_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
    }
}
