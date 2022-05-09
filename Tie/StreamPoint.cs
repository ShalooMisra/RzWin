using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Net;

using OthersCodex;
using NewMethodx;

namespace Tie
{
    public enum StreamPointType
    {
        None = 0,
        File = 1,
        SQL = 2,
        FTP = 3,
        HTTP = 4,
        UNCFolder = 5,        
    }

    public class StreamPoint
    {
        public static int TrivialLocalFileSize = (1024 * 1024 * 2);
        public static int TrivialInternetFileSize = (1024 * 2);

        public static StreamPoint Parse(XmlNode n)
        {
            int t = Tools.Xml.ReadXmlProp_Integer(n, "the_type");
            StreamPoint p = GetPointByType((StreamPointType)t);
            if( p != null )
                p.AbsorbXml(n);
            return p;
        }

        public static StreamPoint GetPointByType(StreamPointType t)
        {
            switch (t)
            {
                case StreamPointType.File:
                    return new StreamPoint_File();
                case StreamPointType.FTP:
                    return new StreamPoint_FTP();
                case StreamPointType.HTTP:
                    return new StreamPoint_HTTP();
                default:
                    return null;
            }
        }

        public virtual String Caption
        {
            get
            {
                return "";
            }
        }

        public StreamPointType TheType;
        public StreamPoint(StreamPointType t)
        {
            TheType = t;
        }

        public virtual void AbsorbXml(XmlNode n)
        {
            try
            {


            }
            catch { }
        }

        public virtual String GetXml()
        {
            return Tools.Xml.BuildXmlProp("the_type", ((int)TheType).ToString());
        }

        public virtual bool IsValid(String context, ref String s)
        {
            if (TheType == StreamPointType.None)
            {
                s = "The " + context + " type is 'none'";
                return false;
            }
            else
                return true;
        }

        public virtual bool CopyTo(StreamPoint d, StreamProgressHandler progress, StreamStatusHandler status, ref String message)
        {
            message = "CopyTo was not overridden.";
            return false;
        }

        public bool ArchiveFile(String strFile, ref String s)
        {
            try
            {
                File.Move(strFile, Tools.Folder.ConditionFolderName(Path.GetDirectoryName(strFile)) + GetArchiveFileName(strFile));
                return true;
            }
            catch (Exception ex)
            {
                s = ex.Message;
                return false;
            }
        }

        public String GetArchiveFileName(String strFile)
        {
            return Path.GetFileNameWithoutExtension(strFile) + "_bak_" + Tools.Strings.GetNewID().Replace("-", "") + Path.GetExtension(strFile) + ".streambackup";
        }

        public StreamProgressHandler TheProgressDelegate;
        public void FTPProgressCallback(int i)
        {
            if (TheProgressDelegate != null)
                TheProgressDelegate(i);
        }

        public StreamStatusHandler TheStatusDelegate;
        public void FTPStatusCallback(String s)
        {
            if (TheStatusDelegate != null)
                TheStatusDelegate(s);
        }

    }

    public class StreamPoint_File : StreamPoint
    {
        public String FileName = "";

        public StreamPoint_File()
            : base(StreamPointType.File)
        {

        }

        public override String Caption
        {
            get
            {
                return "File [" + FileName + "]";
            }
        }

        public override void AbsorbXml(XmlNode n)
        {
            FileName = Tools.Xml.ReadXmlProp(n, "file_name");
            base.AbsorbXml(n);
        }

        public override string GetXml()
        {
            return base.GetXml() + Tools.Xml.BuildXmlProp("file_name", FileName);
        }

        public override bool IsValid(String context, ref string s)
        {
            if (!Tools.Strings.StrExt(FileName))
            {
                s = "The " + context + " file name is blank";
                return false;
            }
            return true;
        }

        public override bool CopyTo(StreamPoint d, StreamProgressHandler progress, StreamStatusHandler status, ref string message)
        {
            switch (d.TheType)
            {
                case StreamPointType.File:
                    return CopyToFile((StreamPoint_File)d, progress, status, ref message);
                case StreamPointType.FTP:
                    return CopyToFTP((StreamPoint_FTP)d, progress, status, ref message);
            }
            return false;
        }

        public bool CopyToFile(StreamPoint_File dest, StreamProgressHandler progress, StreamStatusHandler status, ref string message)
        {
            try
            {
                if (!File.Exists(FileName))
                {
                    message = "The source file " + FileName + " does not exist.";
                    return false;
                }

                if (File.Exists(dest.FileName))
                {
                    String s = "";
                    if (!ArchiveFile(dest.FileName, ref s))
                    {
                        message = "The destination file " + dest.FileName + " already exists, and cannot be archived: " + s;
                        return false;
                    }
                }

                FileInfo f = new FileInfo(FileName);
                if (f.Length < StreamPoint.TrivialLocalFileSize)
                    File.Copy(FileName, dest.FileName);
                else
                {
                    TheProgressDelegate = progress;
                    CopyFileWithProgress(FileName, dest.FileName);
                }

                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        private void CopyFileWithProgress(String strSource, String strDest)
        {
            OthersCodex.CopyEx.CopyEngine Eng = new OthersCodex.CopyEx.CopyEngine(strSource, strDest);
            Eng.CpEvHandler += new OthersCodex.CopyEx.CopyEventHandler(this.onCopyInProgress);
            Eng.CopyFiles();
        }

        private void onCopyInProgress(OthersCodex.CopyEx.CopyEngine Sender, OthersCodex.CopyEx.CopyEngine.CopyEventArgs e)
        {
            try
            {
                if (TheProgressDelegate != null)
                    TheProgressDelegate(Convert.ToInt32(e.CurrentPercent));
            }
            catch { }
        }

        public bool CopyToFTP(StreamPoint_FTP dest, StreamProgressHandler progress, StreamStatusHandler status, ref string message)
        {
            try
            {
                if (!File.Exists(FileName))
                {
                    message = "The source file " + FileName + " does not exist.";
                    return false;
                }

                Tools.FTP ftp = new Tools.FTP(dest.FTPSite, dest.FTPPort, dest.FTPUser, dest.FTPPassword);
                try
                {
                    ftp.Connect();
                }
                catch (Exception ex)
                {
                    message = "FTP connect failed to " + dest.FTPSite + ": " + ex.Message;
                    return false;
                }

                //switch to the folder
                if (!ftp.MoveCurrentFolder(dest.FTPFolder))
                {
                    message = "FTP error changing to " + dest.FTPFolder;
                    return false;
                }

                if (ftp.HasFile(dest.FileName))
                {
                    if (status != null)
                        status("Archiving existing copy of " + dest.FileName);

                    try
                    {
                        ftp.RenameFile(dest.FileName, GetArchiveFileName(dest.FileName));
                    }
                    catch (Exception exc)
                    {
                        if (status != null)
                            status("The existing copy of " + dest.FileName + " could not be archived: " + exc.Message);
                        return false;
                    }
                }

                TheProgressDelegate = progress;
                TheStatusDelegate = status;
                bool b = Tools.FTP.SendFile(ftp, FileName, dest.FileName + ".streamtemp", new Tools.FTPProgressHandler(FTPProgressCallback), new Tools.FTPStatusHandler(FTPStatusCallback), new List<String>());

                if (!b)  //sometimes for a big file it goes up fine, but times out getting the success response
                {
                    try
                    {
                        ftp.Disconnect();
                        ftp.Connect();

                        long l = ftp.GetFileSize(dest.FileName + ".streamtemp");
                        FileInfo fi = new FileInfo(FileName);

                        if (l > 0 && l == fi.Length)
                            b = true;
                    }
                    catch
                    {
                        //b still=false
                    }

                }

                if (b)
                {
                    try
                    {
                        ftp.RenameFile(dest.FileName + ".streamtemp", dest.FileName);
                    }
                    catch { }
                    if (progress != null)
                        progress(100);
                }
                else
                {
                    try
                    {
                        ftp.RemoveFile(dest.FileName + ".streamtemp");
                    }
                    catch { }
                }

                ftp.Disconnect();
                ftp = null;
                return b;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }
    }

    public class StreamPoint_FTP : StreamPoint
    {
        public String FTPSite = "";
        public String FTPFolder = "";
        public String FTPUser = "";
        public String FTPPassword = "";
        public String FileName = "";
        public int FTPPort = 21;

        public StreamPoint_FTP()
            : base(StreamPointType.FTP)
        {

        }

        public override String Caption
        {
            get
            {
                return "FTP [" + FTPSite + "/" + FTPFolder + "/" + FileName + "]";
            }
        }

        public override void AbsorbXml(XmlNode n)
        {
            FTPSite = Tools.Xml.ReadXmlProp(n, "ftp_site");
            FTPFolder = Tools.Xml.ReadXmlProp(n, "ftp_folder");
            FTPUser = Tools.Xml.ReadXmlProp(n, "ftp_user");
            FTPPassword = Tools.Xml.ReadXmlProp(n, "ftp_password");
            FileName = Tools.Xml.ReadXmlProp(n, "file_name");
            FTPPort = Tools.Xml.ReadXmlProp_Integer(n, "port");
            if (FTPPort == 0)
                FTPPort = 21;

            base.AbsorbXml(n);
        }

        public override string GetXml()
        {
            StringBuilder sb = new StringBuilder(base.GetXml());
            sb.Append(Tools.Xml.BuildXmlProp("ftp_site", FTPSite));
            sb.Append(Tools.Xml.BuildXmlProp("ftp_folder", FTPFolder));
            sb.Append(Tools.Xml.BuildXmlProp("ftp_user", FTPUser));
            sb.Append(Tools.Xml.BuildXmlProp("ftp_password", FTPPassword));
            sb.Append(Tools.Xml.BuildXmlProp("file_name", FileName));

            if( FTPPort > 0 )
                sb.Append(Tools.Xml.BuildXmlProp("port", FTPPort));

            return sb.ToString();
        }

        public override bool IsValid(String context, ref string s)
        {
            if (!Tools.Strings.StrExt(FileName))
            {
                s = "The " + context + " file name is blank";
                return false;
            }

            if (!Tools.Strings.StrExt(FTPSite))
            {
                s = "The " + context + " FTP site is blank";
                return false;
            }

            return true;
        }

        public override bool CopyTo(StreamPoint d, StreamProgressHandler progress, StreamStatusHandler status, ref string message)
        {
            switch (d.TheType)
            {
                case StreamPointType.File:
                    return CopyToFile((StreamPoint_File)d, progress, status, ref message);
                //case StreamPointType.FTP:
                //    return CopyToFTP((StreamPoint_FTP)d, progress, status, ref message);
            }
            return false;
        }


        public bool CopyToFile(StreamPoint_File dest, StreamProgressHandler progress, StreamStatusHandler status, ref string message)
        {
            try
            {
                if (File.Exists(dest.FileName))
                {
                    String s = "";
                    if (!ArchiveFile(dest.FileName, ref s))
                    {
                        message = dest.FileName + " already exists and could not be archived: " + s;
                        return false;
                    }
                }

                Tools.FTP ftp = new Tools.FTP(FTPSite, FTPPort, FTPUser, FTPPassword);
                try
                {
                    ftp.Connect();
                }
                catch (Exception ex)
                {
                    message = "FTP connect failed to " + FTPSite + ": " + ex.Message;
                    return false;
                }

                //switch to the folder
                if (!ftp.MoveCurrentFolder(FTPFolder))
                {
                    message = "FTP error changing to " + FTPFolder;
                    return false;
                }

                if (!ftp.HasFile(FileName))
                {
                    if (status != null)
                        status("The file " + FileName + " doesn't appear to exist.");

                    ftp.Disconnect();
                    ftp = null;

                    return false;
                }

                TheProgressDelegate = progress;
                bool b = Tools.FTP.GetFile(ftp, FileName, dest.FileName + ".streamtemp", new Tools.FTPProgressHandler(FTPProgressCallback), null);

                if (b)
                {
                    try
                    {
                        File.Move(dest.FileName + ".streamtemp", dest.FileName);
                    }
                    catch { }
                    if (progress != null)
                        progress(100);
                }
                else
                {
                    try
                    {
                        File.Delete(dest.FileName + ".streamtemp");
                    }
                    catch { }
                }

                ftp.Disconnect();
                ftp = null;
                return b;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

    }

    public class StreamPoint_HTTP : StreamPoint
    {
        public String URL = "";

        public StreamPoint_HTTP()
            : base(StreamPointType.HTTP)
        {

        }

        public override String Caption
        {
            get
            {
                return "HTTP [" + URL + "]";
            }
        }

        public override void AbsorbXml(XmlNode n)
        {
            URL = Tools.Xml.ReadXmlProp(n, "url");
            base.AbsorbXml(n);
        }

        public override string GetXml()
        {
            return base.GetXml() + Tools.Xml.BuildXmlProp("url", URL);
        }

        public override bool IsValid(String context, ref string s)
        {
            if (!Tools.Strings.StrExt(URL))
            {
                s = "The " + context + " url is blank.";
                return false;
            }
            return true;
        }

        public override bool CopyTo(StreamPoint d, StreamProgressHandler progress, StreamStatusHandler status, ref string message)
        {
            switch (d.TheType)
            {
                case StreamPointType.File:
                    return CopyToFile((StreamPoint_File)d, progress, status, ref message);
                //case StreamPointType.FTP:
                //    return CopyToFTP((StreamPoint_FTP)d, progress, status, ref message);
            }
            return false;
        }

        public bool CopyToFile(StreamPoint_File dest, StreamProgressHandler progress, StreamStatusHandler status, ref string message)
        {
            try
            {
                if (File.Exists(dest.FileName))
                {
                    String s = "";
                    if (!ArchiveFile(dest.FileName, ref s))
                    {
                        message = dest.FileName + " already exists and could not be archived: " + s;
                        return false;
                    }
                }

                TheProgressDelegate = progress;
                WebClient xClient = new WebClient();
                xClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(xClient_DownloadProgressChanged);

                bool b = false;
                try
                {
                    xClient.DownloadFile(this.URL, dest.FileName + ".streamtemp");
                    b = true;
                }
                catch (Exception ex)
                {

                }
                if (b)
                {
                    //check for the 404 message

                    try
                    {
                        File.Move(dest.FileName + ".streamtemp", dest.FileName);
                    }
                    catch { }

                    if (progress != null)
                        progress(100);
                }
                else
                {
                    try
                    {
                        File.Delete(dest.FileName + ".streamtemp");
                    }
                    catch { }
                }

                try
                {
                    xClient.Dispose();
                    xClient = null;
                }
                catch { }

                return b;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        void xClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                TheProgressDelegate(e.ProgressPercentage);
            }
            catch { }
        }
    }
}
