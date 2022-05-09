using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NewMethod;
using Tie;

namespace Rz5
{
    public partial class frmRzTieServer : Form
    {
        public static frmRzTieServer ServerForm;
        public static Eye ServerEye;

        public static void CheckStartTieServer(ContextRz context)
        {
            CheckStartTieServer(context, false);
        }
        public static void CheckStartTieServer(ContextRz context, bool hide)
        {
            if (ServerEye == null)
            {
                ServerEye = new Eye();
            }

            if (!IsServerFormValid())
            {
                ServerForm = new frmRzTieServer();
                ServerForm.Show();
                ServerForm.CompleteLoad(RzWin.Context.Sys);
                if (hide)
                    ServerForm.WindowState = FormWindowState.Minimized;
            }
        }
        public static bool IsServerFormValid()
        {
            if (ServerForm == null)
                return false;

            try
            {
                if (!ServerForm.ShowInTaskbar)
                    ServerForm.ShowInTaskbar = true;
                ServerForm.Show();

                if (ServerForm.WindowState == FormWindowState.Minimized)
                    ServerForm.WindowState = FormWindowState.Normal;

                return true;
            }
            catch { return false; }
        }

        public static void StopTieServer()
        {
            if (ServerEye != null)
            {
                try
                {
                    ServerEye.StopListening(false);
                    ServerEye = null;
                }
                catch { }
            }
        }

        public SysRz5 xSys;

        public frmRzTieServer()
        {
            InitializeComponent();
        }

        public void CompleteLoad(SysRz5 xs)
        {
            xSys = xs;            
            ctlServerName.SetValue(RzWin.Context.GetSetting("tie_server_name"));
            ctlPort.SetValue(RzWin.Context.GetSettingInt32("tie_server_port"));
            ctlUseHook.SetValue(RzWin.Context.GetSettingBoolean("use_hook"));
            ctlPassword.SetValue(RzWin.Context.GetSetting("tie_password"));

            ApplySettings();

            xEye.SetEye(ServerEye);
            
            xEye.ShowCaption();

            if (ctlUseHook.GetValue_Boolean())
            {
                if (ServerEye.CurrentState == EyeState.Closed)
                    ServerEye.StartListening();
                else
                    xEye.ReShowConnections();
            }
        }

        private void ApplySettings()
        {
            ServerEye.EyePort = ctlPort.GetValue_Integer();
            ServerEye.Password = ctlPassword.GetValue_String();
            ServerEye.SendEncrypted = true;
            xEye.ShowCaption();
        }

        private void cmdApply_Click(object sender, EventArgs e)
        {
            RzWin.Context.SetSetting("tie_server_name", ctlServerName.GetValue_String());
            RzWin.Context.SetSettingInt32("tie_server_port", ctlPort.GetValue_Integer());
            RzWin.Context.SetSettingBoolean("use_hook", ctlUseHook.GetValue_Boolean());
            RzWin.Context.SetSetting("tie_password", ctlPassword.GetValue_String());
            ApplySettings();
        }
    }
}