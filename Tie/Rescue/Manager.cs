using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;

namespace Tie.Rescue
{
    public class RzRescueManager
    {
        public static String RootFolder = @"c:\RzRescue\";

        //Public Variables
        public List<RzRescueDatabase> Databases = new List<RzRescueDatabase>();

        //Public Functions
        public void RunRescue()
        {
            //status.SetStatus("Starting RzRescue [" + DateTime.Now.ToString() + "]");
            //status.SetStatus("___________________________________________________");

            StringBuilder status = new StringBuilder();

            try
            {
                CheckForDeltaFile();
            }
            catch { }

            bool ret = true;
            foreach (RzRescueDatabase d in Databases)
            {
                try
                {
                    d.Rescue();
                }
                catch(Exception ex)
                {
                    status.AppendLine("Failed to Rescue " + d.Database + ": " + ex.Message);
                    ret = false;
                }
            }

            if (!ret)
                throw new Exception("RunRescue failed: " + status.ToString());
        }
        //Private Functions
        private void CheckForDeltaFile()  //RzRescueStatus status
        {
            //status.SetStatus("Checking For Delta File...");
            string file_exe = Tools.Folder.ConditionFolderName(Tools.Folder.GetAppPath()) + "xdelta30q.exe";
            string file_bat = Tools.Folder.ConditionFolderName(Tools.Folder.GetAppPath()) + "xdelta3.bat";
            //status.SetStatus("file_exe = " + file_exe);
            //status.SetStatus("file_bat = " + file_bat);
            if (Tools.Files.FileExists(file_exe) && Tools.Files.FileExists(file_bat))
                return;

            if (!Tools.Files.FileExists(file_exe))
            {
                if (!Tools.Ftp.GetFileFTPDotNet("ftp://www.recognin.com/RzRescue/Xdelta/xdelta30q.exe", file_exe, null, null, "recognin2", "Rec0gnin!", 0))
                    throw new Exception("Download " + file_exe + " failed");

                CreateBatchFile(file_exe);
            }
            else if (!Tools.Files.FileExists(file_bat))
                CreateBatchFile(file_exe);
        }
        private void CreateBatchFile(string file)
        {
            string file_bat = Tools.Folder.ConditionFolderName(Tools.Folder.GetAppPath()) + "xdelta3.bat";

            Tools.Files.TryDeleteFile(file_bat);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("@echo off");
            sb.AppendLine("rem Set filename and/or path to xdelta3");
            sb.AppendLine("set XDELTA_EXE=\"" + file + "\"");
            sb.AppendLine();
            sb.AppendLine("if \"%1\"==\"\" goto :NOARGS");
            sb.AppendLine("IF /I \"%1\"==\"delta\" goto :XDELTA");
            sb.AppendLine("IF /I \"%1\"==\"patch\" goto :XPATCH");
            sb.AppendLine("echo xdelta3: unknown arguments");
            sb.AppendLine("goto :EXIT");
            sb.AppendLine();
            sb.AppendLine(":XPATCH");
            sb.AppendLine("if \"%3\"==\"\" echo xdelta3: usage xdelta3 patch DELTA_FILE OLD_FILE [DECODED_FILE] && goto exit");
            sb.AppendLine("if \"%5\"==\"\" %XDELTA_EXE% -d -vfs \"%3\" \"%2\" \"%4\" && goto exit");
            sb.AppendLine("if \"%4\"==\"\" %XDELTA_EXE% -d -vfs \"%3\" \"%2\" && goto exit");
            sb.AppendLine("echo xdelta3: usage xdelta3 patch DELTA_FILE OLD_FILE [DECODED_FILE] && goto exit");
            sb.AppendLine("goto exit");
            sb.AppendLine(":XDELTA");
            sb.AppendLine();
            sb.AppendLine("if \"%3\"==\"\" echo xdelta3: usage xdelta3 delta OLD_FILE NEW_FILE [DELTA_OUT_FILE] && goto exit");
            sb.AppendLine("if \"%2\"==\"\" echo xdelta3: usage xdelta3 delta OLD_FILE NEW_FILE [DELTA_OUT_FILE] && goto exit");
            sb.AppendLine("if \"%4\"==\"\" %XDELTA_EXE% -9 -S djw -e -vfs \"%2\" \"%3\" \"%3.xdp\" && goto exit");
            sb.AppendLine("%XDELTA_EXE% -9 -S djw -e -vfs \"%2\" \"%3\" \"%4\"");
            sb.AppendLine("goto exit");
            sb.AppendLine();
            sb.AppendLine(":NOARGS");
            sb.AppendLine("echo xdelta3: usage xdelta3 delta OLD_FILE NEW_FILE [DELTA_OUT_FILE]");
            sb.AppendLine("echo xdelta3: usage xdelta3 patch DELTA_FILE OLD_FILE [DECODED_FILE]");
            sb.AppendLine();
            sb.AppendLine("goto :EXIT");
            sb.AppendLine(":EXIT");

            if (!Tools.Files.SaveFileAsString(file_bat, sb.ToString()))
                throw new Exception("Failed to save delta batch file " + file_bat);
        }
    }

    public class FtpInfo
    {
        public String Server = "";
        public String Folder = "";
        public String User = "";
        public String Password = "";

        public String ServerPathName
        {
            get
            {
                return Tools.Strings.FilterTrash(Server);
            }
        }

        public String Uri
        {
            get
            {
                String ret = Server;
                if (!ret.StartsWith("ftp://"))
                    ret = "ftp://" + ret;
                if (!ret.EndsWith("/"))
                    ret += "/";

                if (Tools.Strings.StrExt(Folder))
                    ret += Folder + "/";

                return ret;
            }
        }

        public String UriOriginal = "";
        public bool PushFolder(String folder)
        {
            if (!Tools.Strings.StrExt(UriOriginal))
                UriOriginal = Uri;

            if (Tools.Strings.StrExt(Folder))
                Folder += "/";

            Folder += folder;

            try
            {
                FtpWebRequest mkrequest = (FtpWebRequest)WebRequest.Create(Uri);
                mkrequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                mkrequest.Credentials = new NetworkCredential(User, Password);
                FtpWebResponse mkresponse = (FtpWebResponse)mkrequest.GetResponse();
                mkresponse.Close();                
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
