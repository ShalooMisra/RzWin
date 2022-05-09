using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

using NewMethodx;
using Tie;

using OthersCode;

namespace TiePin
{
    public partial class frmPins : Form
    {
        public TieTack CurrentTack = null;

        public frmPins()
        {
            InitializeComponent();
            pRemote.TrySetImage();
            pFile.TrySetImage();
            pSQL.TrySetImage();
            pClip.TrySetImage();
            pCommand.TrySetImage();
            pUser.TrySetImage();
        }

        public void CompleteLoad()
        {
            CompleteLoad(false, false);
        }

        public void CompleteLoad(bool install_if_missing, bool start_if_stopped)
        {
            ShowVersion();
            CheckVNCService();

            lvTacks.Items.Clear();
            lvTacks.BeginUpdate();
            try
            {
                ArrayList a = TieKnot.GetTackFolders();
                //if (a.Count == 0)
                //{
                //    String s = "Public tie connection";
                //    if (!TieTack.MakeTackFolderExist(s))
                //        return;
                //    a = TieKnot.GetTackFolders();
                //}

                foreach(String n in a)
                {
                    ListViewItem i = lvTacks.Items.Add(n);
                    i.Tag = i.Text;

                    long l = Tools.Files.GetHighestFileNumber(TieTack.GetTackFolderPath(n), "tiepin.exe");
                    String ls = "";
                    if (l > -1)
                        ls = Tools.Number.LongFormat(l);
                    i.SubItems.Add(ls);

                    if (CurrentTack == null)
                    {
                        CurrentTack = new TieTack();
                        CurrentTack.TackName = n;
                        CurrentTack.InitFromSettings();
                    }
                }
            }
            catch { }
            lvTacks.EndUpdate();

            if (CurrentTack == null)
                ClearTack();
            else
            {
                ShowTack();
            }

            CheckService(install_if_missing, start_if_stopped, false);
        }

        private void CheckService(bool install_if_missing, bool start_if_stopped, bool stop_if_started)
        {
            System.ServiceProcess.ServiceController controller = null;
            try
            {

                controller = GetServiceController();
                if (controller == null)
                {
                    if (install_if_missing)
                    {
                        gbService.Enabled = false;
                        lblInstall.Visible = false;
                        lblInstalled.ForeColor = Color.Gray;
                        lblInstalled.Text = "Installing...";
                        bg.RunWorkerAsync();
                        return;
                    }
                    else
                    {
                        lblStatus.Text = "";
                        gbService.Enabled = false;
                        lblInstall.Visible = true;
                        lblInstall.Text = "install";
                        lblInstalled.ForeColor = Color.Red;
                        lblInstalled.Text = "Not Installed";

                        lblStartStop.Visible = false;
                        lblStatus.Text = "";
                        return;
                    }
                }
                else
                {
                    gbService.Enabled = true;
                    lblInstall.Text = "uninstall";
                    lblInstall.Visible = true;
                    lblInstalled.Text = "Installed";
                    lblInstalled.ForeColor = Color.Green;
                }

                if (controller.Status == System.ServiceProcess.ServiceControllerStatus.Running)
                {
                    if (stop_if_started)
                    {
                        lblStatus.Text = "Stopping...";
                        controller.Stop();
                        controller.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(4));

                        controller.Close();
                        controller.Dispose();
                        controller = null;

                        CheckService(false, false, false);
                        return;
                    }

                    lblStartStop.Visible = true;
                    lblStartStop.Text = "stop";
                    lblStatus.Text = "Running";
                    lblStatus.ForeColor = Color.Green;
                }
                else
                {
                    if (start_if_stopped)
                    {
                        lblStatus.Text = "Starting...";
                        controller.Close();
                        controller.Dispose();
                        controller = null;

                        bgStart.RunWorkerAsync();

                        CheckService(false, false, false);
                        return;
                    }

                    lblStartStop.Visible = true;
                    lblStartStop.Text = "start";
                    lblStatus.Text = "Stopped";
                    lblStatus.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblStartStop.Visible = false;
                lblStatus.ForeColor = Color.Gray;
                lblStatus.Text = ex.Message;
            }
            finally
            {
                try
                {
                    controller.Close();
                    controller.Dispose();
                    controller = null;
                }
                catch{}
            }
        }

        private void CheckVNCService()
        {
            System.ServiceProcess.ServiceController controller = null;
            try
            {
                controller = GetVNCServiceController();
                if (controller == null)
                {
                    lblInstallVNC.Visible = true;
                    lblInstallVNC.Text = "install";
                    lblVNCStatus.ForeColor = Color.Red;
                    lblVNCStatus.Text = "Not Installed";
                    return;
                }
                else
                {
                    lblInstallVNC.Text = "uninstall";
                    lblInstallVNC.Visible = false;
                    lblVNCStatus.Text = "Installed";
                    lblVNCStatus.ForeColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                //lblStartStop.Visible = false;
                //lblStatus.ForeColor = Color.Gray;
                //lblStatus.Text = ex.Message;
            }
            finally
            {
                try
                {
                    controller.Close();
                    controller.Dispose();
                    controller = null;
                }
                catch { }
            }
        }

        private void ClearTack()
        {
            //txtRackAddress.Text = "";
            //txtRackPort.Text = "";
            //txtPassword.Text = "";

            pRemote.Disable();
            pFile.Disable();
            pSQL.Disable();
            pClip.Disable();
            pCommand.Disable();
            pUser.Disable();

            gbTack.Text = "<no pin is selected>";
            gbTack.Enabled = false;
        }

        private void ShowTack()
        {
            gbTack.Enabled = true;
            gbTack.Text = CurrentTack.TackName;
            
            //txtRackAddress.Text = CurrentTack.RackAddress;
            //txtRackPort.Text = CurrentTack.RackPort.ToString();
            //txtPassword.Text = CurrentTack.Password;

            pRemote.Enable();
            pFile.Enable();
            pSQL.Enable();
            pClip.Enable();
            pCommand.Enable();
            pUser.Enable();

            //txtSiteUserName.Text = Tools.Strings.ParseDelimit(CurrentTack.SiteCredentials, "|", 1);
            //txtSitePassword.Text = Tools.Strings.ParseDelimit(CurrentTack.SiteCredentials, "|", 2);

            txtDescription.Text = CurrentTack.Description;
            txtLicenseID.Text = CurrentTack.LicenseID;

            pRemote.IsChecked = CurrentTack.AllowRemoteView;
            pFile.IsChecked = CurrentTack.AllowFileView;
            pSQL.IsChecked = CurrentTack.AllowSQLView;
            pClip.IsChecked = CurrentTack.AllowClipView;
            pCommand.IsChecked = CurrentTack.AllowCommandView;
            pUser.IsChecked = CurrentTack.AllowUserView;

            foreach (ListViewItem i in lvTacks.Items)
            {
                i.Selected = (i.Text == CurrentTack.TackName);
            }
        }

        private bool SaveTack()
        {
            String strError = "";
            //if (!Tools.Strings.StrExt(txtRackAddress.Text))
            //    strError += "Please enter a rack address.\r\n";

            //if (!Tools.Number.IsNumeric(txtRackPort.Text))
            //    strError += "Please enter a rack port.\r\n";

            //if (!Tools.Strings.StrExt(txtPassword.Text))
            //    strError += "Please enter a connection password.\r\n";

            if (Tools.Strings.StrExt(strError))
            {
                MessageBox.Show(strError);
                return false;
            }

            //CurrentTack.RackAddress = txtRackAddress.Text;
            //CurrentTack.RackPort = Int32.Parse(txtRackPort.Text);
            //CurrentTack.Password = txtPassword.Text;

            //CurrentTack.SiteCredentials = txtSiteUserName.Text + "|" + txtSitePassword.Text;
            CurrentTack.Description = txtDescription.Text;

            CurrentTack.SendEncrypted = true;

            CurrentTack.AllowRemoteView = pRemote.IsChecked;
            CurrentTack.AllowFileView = pFile.IsChecked;
            CurrentTack.AllowSQLView = pSQL.IsChecked;
            CurrentTack.AllowClipView = pClip.IsChecked;
            CurrentTack.AllowCommandView = pCommand.IsChecked;
            CurrentTack.AllowUserView = pUser.IsChecked;
            CurrentTack.SaveSettings();

            return true;
        }

        private void cmdApply_Click(object sender, EventArgs e)
        {
            TieTack x = CurrentTack;
            if( !SaveTack() )
                return;
            CompleteLoad();
            CurrentTack = x;
            ShowTack();
        }

        private void lblAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String s = frmTackName.Enter(this, "");
            if (!Tools.Strings.StrExt(s))
                return;

            if (TieTack.TackFolderExists(s))
            {
                TellUser("The pin folder " + s + " is already taken.");
                return;
            }

            if (!TieTack.MakeTackFolderExist(s))
                return;

            CompleteLoad();
            SetCurrentTack(s);
        }

        private void TellUser(String s)
        {
            MessageBox.Show(s);
        }

        private void lvTacks_Click(object sender, EventArgs e)
        {
            String s = GetSelectedTackName();
            if (!Tools.Strings.StrExt(s))
                return;

            SetCurrentTack(s);
        }

        private void SetCurrentTack(String s)
        {
            CurrentTack = new TieTack();
            CurrentTack.TackName = s;
            CurrentTack.InitFromSettings();
            ShowTack();
        }

        private String GetSelectedTackName()
        {
            try
            {
                return (String)lvTacks.SelectedItems[0].Tag;
            }
            catch { return ""; }
        }

        private TieTack GetSelectedTack()
        {
            String s = GetSelectedTackName();
            if (!Tools.Strings.StrExt(s))
                return null;
            TieTack t = new TieTack();
            t.TackName = s;
            t.InitFromSettings();
            return t;
        }

        private void mnuDeleteTack_Click(object sender, EventArgs e)
        {
            String s = GetSelectedTackName();
            if (!Tools.Strings.StrExt(s))
                return;

            if (!TieTack.TackFolderExists(s))
            {
                TellUser("This pin folder doesn't exist.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete the pin '" + s + "'?", "Sure?", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            TieTack.DeleteTackFolder(s);
            CompleteLoad();
        }

        private void mnuRename_Click(object sender, EventArgs e)
        {
            String s = GetSelectedTackName();
            if (!Tools.Strings.StrExt(s))
                return;

            if (!TieTack.TackFolderExists(s))
            {
                TellUser("This pin folder doesn't exist.");
                return;
            }

            String n = frmTackName.Enter(this, s);
            if (!Tools.Strings.StrExt(n))
                return;

            if (n == s)
                return;

            if (TieTack.TackFolderExists(n))
            {
                TellUser("The folder '" + n + "' already exists.");
                return;
            }

            TieTack.RenameTackFolder(s, n);
            CompleteLoad();
            SetCurrentTack(n);
        }

        private void lblStartStop_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lblStartStop.Text == "start")
                CheckService(false, true, false);
            else
                CheckService(false, false, true);
        }

        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            InstallService();
        }

        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CheckService(false, true, false);
        }
        public static bool InstallService()
        {
            return InstallService("TieService");
        }
        public static bool InstallService(String name)
        {
            WindowsServiceInstallInfo wsInstallInfo = new WindowsServiceInstallInfo(name, "", TieKnot.KnotRootPath, name + ".exe", WindowsServiceAccountType.LocalSystem);

//    ("MyService", "desc", Directory.GetCurrentDirectory(), "MyService.exe",
//// WindowsServiceAccountType.User, @".\username", @"password");
////If install with network user:
////wsInstallInfo = new WindowsServiceInstallInfo
//    ("MyService", "desc", Directory.GetCurrentDirectory(), "MyService.exe",
//// WindowsServiceAccountType.User, @"networkdomain\username", @"password");
//wsInstallInfo = new WindowsServiceInstallInfo
//    ("MyService", "desc", Directory.GetCurrentDirectory(), "MyService.exe",
//WindowsServiceAccountType.User, @".\username", @"");


            WindowsServiceInstallUtil wsInstallUtil = new WindowsServiceInstallUtil(wsInstallInfo);
            //Log to see any error
            bool b = false;
            //if( nTools.IsDevelopmentMachinePlain() )
            //    b = wsInstallUtil.Install("C:\\" + name + "install.txt");
            //else
                b = wsInstallUtil.Install();

            if (b)
            {
                SetRegistryForDesktopInteraction(name);
            }

            return b;
        }
        private static void SetRegistryForDesktopInteraction()
        {
            SetRegistryForDesktopInteraction("TieService");
        }
        private static void SetRegistryForDesktopInteraction(String name)
        {
            Microsoft.Win32.RegistryKey ckey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\" + name, true);
            if(ckey != null)
            {
                // Ok now lets make sure the "Type" value is there, 
                //and then do our bitwise operation on it.
                if((Int32)ckey.GetValue("Type") != 0)
                {
                    Int32 v = (Int32)ckey.GetValue("Type");
                    v = Convert.ToInt32(v | 256);
                    ckey.SetValue("Type", (Object)v);
                }
            }
        }
        private bool UnInstallService()
        {
            return UnInstallService("TieService");
        }
        private bool UnInstallService(String name)
        {
            WindowsServiceInstallInfo wsInstallInfo = new WindowsServiceInstallInfo(name, "", TieKnot.KnotRootPath, name + ".exe", WindowsServiceAccountType.LocalSystem);
            WindowsServiceInstallUtil wsInstallUtil = new WindowsServiceInstallUtil(wsInstallInfo);
            return wsInstallUtil.Uninstall();
        }

        private void lblInstall_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lblInstall.Text == "install")
                InstallService();
            else
            {
                System.ServiceProcess.ServiceController controller = GetServiceController();
                if (controller == null)
                {
                    MessageBox.Show("The TieService does not appear to be installed.");
                    return;
                }

                if (controller.Status != System.ServiceProcess.ServiceControllerStatus.Stopped)
                {
                    try
                    {
                        controller.Stop();
                        controller.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(4));
                    }
                    catch { }
                }

                try
                {
                    controller.Close();
                    controller.Dispose();
                    controller = null;
                }
                catch { }

                UnInstallService();
            }
            CheckService(false, false, false);
        }
        public static System.ServiceProcess.ServiceController GetServiceController()
        {
            return GetServiceController("TieService");
        }
        public static System.ServiceProcess.ServiceController GetServiceController(String name)
        {
            System.ServiceProcess.ServiceController controller;
            try
            {
                controller = new System.ServiceProcess.ServiceController(name);
                String sn = controller.DisplayName;
            }
            catch { controller = null; }
            return controller;
        }

        private System.ServiceProcess.ServiceController GetVNCServiceController()
        {
            System.ServiceProcess.ServiceController controller;
            try
            {
                controller = new System.ServiceProcess.ServiceController("VNC Server Version 4");
                String sn = controller.DisplayName;
            }
            catch { controller = null; }
            return controller;
        }

        private void bgStart_DoWork(object sender, DoWorkEventArgs e)
        {
            StartService();
        }
        public static void StartService()
        {
            StartService("TieService");
        }
        public static void StartService(String name)
        {
            try
            {
                System.ServiceProcess.ServiceController controller = GetServiceController(name);
                if (controller == null)
                    return;

                controller.Start();
                controller.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Running, TimeSpan.FromSeconds(4));

                controller.Close();
                controller.Dispose();
                controller = null;
            }
            catch { }
        }

        private void bgStart_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CheckService(false, false, false);
        }

        private void lblWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tools.Files.OpenFileInDefaultViewer("www.newmethodsoftware.com");
        }

        private void lblNM_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //txtRackAddress.Text = "tie.newmethodsoftware.com";
            //txtRackPort.Text = "2950";
            //txtPassword.Text = "tiepass";

            String s = "Public tie connection";
            if (!TieTack.MakeTackFolderExist(s))
                return;

            TieTack t = new TieTack();
            t.TackName = s;
            t.InitFromSettings();

            t.RackAddress = "tie.newmethodsoftware.com";
            t.RackPort = 2950;
            t.Password = "tiepass";
            t.SaveSettings();

            CompleteLoad();
        }

        private void mnuStartTackWithMonitor_Click(object sender, EventArgs e)
        {
            TieTack t = GetSelectedTack();
            if (t == null)
                return;

            frmTackMonitor.ShowTack(t);

            String s = "";
            if (!t.ConnectWithPersistence(ref s))
                t.StartPersistence();
        }

        private void ShowVersion()
        {
            DateTime dtLast = TieKnot.GetLastUpdateCheck();
            long webversion = TieWeb.GetCurrentWebVersion();

            TieKnot t = new TieKnot();
            long currentversion = t.GetLatestOriginalVersion();

            lblVersion.Text = "Web: " + Tools.Number.LongFormat(webversion) + " / Local: " + Tools.Number.LongFormat(currentversion);
        }

        private void lblUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TieKnot t = new TieKnot();
            t.CheckForUpdates();
            ShowVersion();
        }

        private void lblInstallVNC_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InstallVNC();
        }

        private bool InstallVNC()
        {
            String strVNCFile = Tools.FileSystem.GetAppPath() + "RealVNC\\winvnc4.exe";
            if (!File.Exists(strVNCFile))
            {
                MessageBox.Show("The file '" + strVNCFile + "' could not be found.");
                return false;
            }

            //the defined password is: vncpassword

            String strRegFile = Tools.FileSystem.GetAppPath() + "RealVNC\\vncpwd.reg";
            if (!File.Exists(strRegFile))
            {
                MessageBox.Show("The file '" + strRegFile + "' could not be found.");
                return false;
            }

            String sb = "";

            if (!Tools.FileSystem.Shell(strVNCFile, "-register", true, true, ref sb))
            {
                MessageBox.Show("The registration process failed: " + sb);
                return false;
            }

            sb = "";
            if (!Tools.FileSystem.Shell("regedit", "/s \"" + strRegFile + "\"", true, true, ref sb))
            {
                MessageBox.Show("The authentication process failed: " + sb);
                return false;
            }

            sb = "";
            if (!Tools.FileSystem.Shell(strVNCFile, "-start", true, true, ref sb))
            {
                MessageBox.Show("Starting VNC failed: " + sb);
                return false;
            }

            CheckVNCService();
            return true;
        }

        private void lblPinvitation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                String invite = frmPinvitation.GetInvitationText(this);
                if (!Tools.Strings.StrExt(invite))
                    return;

                invite = OthersCodex.EncDec.Decrypt(invite, "recogninp");

                if (!invite.StartsWith("pinvitation"))
                {
                    MessageBox.Show("This doesn't appear to be a valid Pinvitation block.");
                    return;
                }

                invite = invite.Substring(11);

                XmlDocument d = new XmlDocument();
                d.LoadXml(invite);
                XmlNode n = d.SelectSingleNode("invitations/invitation[1]");

                String s = Tools.Xml.ReadXmlProp(n, "invitation_name");

                if (!Tools.Strings.StrExt(s))
                {
                    MessageBox.Show("There was a problem reading this invitation.");
                    return;
                }

                if (TieTack.TackFolderExists(s))
                {
                    String ns = s;
                    for(int i=0 ; i<1000 ; i++)
                    {
                        ns = s + "_" + i.ToString();
                        if (!TieTack.TackFolderExists(ns))
                        {
                            s = ns;
                            break;
                        }
                    }
                }

                if (!TieTack.MakeTackFolderExist(s))
                    return;

                TieTack t = new TieTack();
                t.TackName = s;
                t.InitFromSettings();

                t.RackAddress = Tools.Xml.ReadXmlProp(n, "rack_address");
                t.RackPort = Tools.Xml.ReadXmlProp_Integer(n, "rack_port");
                t.Password = Tools.Xml.ReadXmlProp(n, "rack_password");
                t.SiteCredentials = Tools.Xml.ReadXmlProp(n, "site_credentials");
                t.LicenseID = Tools.Xml.ReadXmlProp(n, "license_id");
                t.Description = Tools.Xml.ReadXmlProp(n, "description");

                t.SaveSettings();

                CurrentTack = t;
                CompleteLoad();
            }
            catch(Exception ex)
            {
                MessageBox.Show("There was an error: " + ex.Message);
            }
        }

        public static bool MakeTheServiceInstalledAndStarted(String name)
        {
            return MakeTheServiceInstalledAndStarted(true, name);
        }

        public static bool MakeTheServiceInstalledAndStarted()
        {
            return MakeTheServiceInstalledAndStarted(true, "TieService");
        }
        public static bool MakeTheServiceInstalledAndStarted(bool install_if_missing, String name)
        {
            System.ServiceProcess.ServiceController controller = null;
            try
            {

                controller = GetServiceController(name);
                if (controller == null)
                {
                    if( install_if_missing )
                    {
                        InstallService(name);
                        return MakeTheServiceInstalledAndStarted(false, name);
                    }
                    else
                        return false;
                }

                if (controller.Status != System.ServiceProcess.ServiceControllerStatus.Running)
                {
                    StartService(name);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool DeleteFromRegistry()
        {
            Microsoft.Win32.RegistryKey ckey;
            try
            {
                ckey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall", true);
                if (ckey != null)
                {
                    ckey.DeleteSubKey("804B4256-8784-4409-A150-FBFE459206D3", false);
                    ckey.DeleteSubKey("7AD28C88-E09C-41CF-8B60-20F0E6CC35F0", false);
                    ckey.DeleteSubKey("6524B408487890441A05BFEF5429603D", false);
                }
            }
            catch { }

            try
            {
                ckey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("HKEY_CLASSES_ROOT\\Installer\\Products", true);
                if (ckey != null)
                {
                    ckey.DeleteSubKey("804B4256-8784-4409-A150-FBFE459206D3", false);
                    ckey.DeleteSubKey("7AD28C88-E09C-41CF-8B60-20F0E6CC35F0", false);
                    ckey.DeleteSubKey("6524B408487890441A05BFEF5429603D", false);
                }
            }
            catch { }
            return true;
        }
    }
}