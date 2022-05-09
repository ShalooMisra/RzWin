using System;
using System.Collections.Generic;
using System.Text;

using NewMethodx;

using OthersCodex;

namespace Tie
{
    public class TieWeb
    {
        public static String TieTextURL = "http://www.newmethodsoftware.com/tie.txt";
        public static String TieZipURL = "http://www.newmethodsoftware.com/tie.zip";

        private static String TieSite = "www.newmethodsoftware.com";
        private static String TieSiteUser = "newmethodlogin";
        private static String TieSitePassword = "";

        public static void SetSitePassword(String p)
        {
            TieSitePassword = p;
        }

        public static long GetCurrentWebVersion()
        {
            String s = GetTieText();
            if (!Tools.Strings.StrExt(s))
                return 0;

            s = Tools.Strings.ParseDelimit(s, "\r\n", 1);

            if (Tools.Number.IsNumeric(s))
                return Int64.Parse(s);
            else
                return 0;
        }

        public static String GetTieText()
        {
            return Tools.Strings.DownloadInternetFileAsString(TieTextURL);
        }

        public static bool SetTieText(String s, Tools.FTPProgressHandler progress, Tools.FTPStatusHandler status)
        {
            if( !Tools.Files.SaveFileAsString("c:\\tie.txt", s))
                return false;

            return Tools.FTP.SendFile(TieSite, TieSiteUser, TieSitePassword, "c:\\tie.txt", "tie.txt", progress, status, new List<String>());
        }

        public static Tools.FTP GetFTPConnection(Tools.FTPStatusHandler status)
        {
            Tools.FTP ftplib = new Tools.FTP(TieSite, TieSiteUser, TieSitePassword);

            try
            {
                if (status != null)
                    status("Connected to " + TieSite);

                return ftplib;
                
            }
            catch (Exception ex)
            {
                if (status != null)
                    status("Connection Error: " + ex.Message);

                return null;
            }
        }

        public static bool DeleteTieText(Tools.FTP ftplib)
        {
            try
            {
                ftplib.RemoveFile("tie.txt");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool SetTieZip(Tools.FTP ftplib, String strZipFile, Tools.FTPProgressHandler progress, Tools.FTPStatusHandler status)
        {
            try
            {
                ftplib.RemoveFile("tie.zip");
            }
            catch
            {}
            return Tools.FTP.SendFile(ftplib, strZipFile, "tie.zip", progress, status, new List<String>());
        }
    }
}
