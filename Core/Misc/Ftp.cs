using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tools;

namespace Core
{
    public class Ftp : IDisposable
    {
        Context TheContext;

        public bool Send(Context x, String serverName, String userName, String userPassword, String localFile, String remoteName, List<String> folders)
        {
            TheContext = x;
            Tools.FTPProgressHandler prog = new FTPProgressHandler(Prog);
            Tools.FTPStatusHandler stat = new FTPStatusHandler(Stat);
            bool ret = Tools.FTP.SendFile(serverName, userName, userPassword, localFile, remoteName, prog, stat, folders);
            prog = null;
            stat = null;
            return ret;
        }

        void Prog(int p)
        {
            TheContext.TheLeader.ProgressUpdate(p);
        }

        void Stat(String s)
        {
            TheContext.TheLeader.Comment(s);
        }

        public void Dispose()
        {
            TheContext = null;
        }
    }
}
