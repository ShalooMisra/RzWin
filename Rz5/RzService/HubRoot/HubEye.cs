using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Runtime.Remoting;
using System.IO;

using Tie;

namespace HubRoot
{
    public class HubEye : MarshalByRefObject
    {
        public Tie.Eye ServerEye = null;

        void AddLog(String s)
        {
            HubRoot.Program.AddLog(s);
        }

        public void Start(int port, String password)
        {
            AddLog("Starting...");
            try
            {
                ServerEye = new Eye();
                ServerEye.EyePort = port;
                ServerEye.Password = password;
                ServerEye.SendEncrypted = true;
                ServerEye.StartListening();
                HubRoot.Program.AddLog("Listening on port " + ServerEye.EyePort.ToString() + "...");
            }
            catch (Exception ex)
            {
                AddLog("Start Error: " + ex.Message);
            }
            AddLog("Started.");
        }

        public void Stop()
        {
            AddLog("Stopping...");
            try
            {
                ServerEye.StopListening(true);
                ServerEye.DisconnectClients(false, false, true);
                ServerEye = null;
            }
            catch (Exception ex)
            {
                AddLog("Stop error: " + ex.Message);
            }
            AddLog("Stopped.");
        }
    }
}
