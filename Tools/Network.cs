using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace Tools
{
    public static class Network
    {
        public static String GetLocalIP()
        {
            try
            {
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress i in ipHostInfo.AddressList)
                {
                    if( i.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork )
                        return i.ToString();
                }
                return "0.0.0.0";
            }
            catch
            {
                return "0.0.0.0";
            }
        }
    }
}
