using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Xml;
using System.Threading;

using NewMethodx;

namespace Tie
{
    public delegate void PrepareCompleteHandler(Job_EternalCheck xJob, String strFile, long lngSize);
    public delegate void PedestalUploadCompleteHandler(Job_EternalCheck xJob);

    public class Job_EternalCheck : TieJob
    {
        public event PrepareCompleteHandler PrepareComplete;
        public event PedestalUploadCompleteHandler PedestalUploadComplete;

        public EternalItemHandle ItemHandle;
        public String CheckID = "";
        public String BackupFolderPath = "";
        public String BackupPayloadFile = "";

        DateTime UploadStartTime = DateTime.Now;

        public Job_EternalCheck(TieEnd e)
            : base(e)
        {
            Name = "EternalCheck";
        }

        public override void Do()
        {
            try
            {
                CheckID = Tools.Strings.GetNewID().Replace("-", "");
                BeforeDo();

                TieMessage m = new TieMessage(xEnd.GetSessionFrom(), "eternal_check_request", TargetSession);
                m.ContentString = ItemHandle.GetAsXml() + Tools.Xml.BuildXmlProp("check_id", CheckID) + Tools.Xml.BuildXmlProp("backup_folder_path", BackupFolderPath);
                AddLog("Sending eternal check request...");
                if (!Send(m))
                {
                    ;
                }
            }
            catch (Exception)
            { }
        }

        public override void GotMessage(TieMessage m)
        {
            try
            {
                TieMessage reply;
                switch (m.FunctionName)
                {
                    case "eternal_check_request":
                        AddLog("Received eternal check request...");

                        ItemHandle = new EternalItemHandle();
                        ItemHandle.AbsorbXml(m.ContentNode);
                        CheckID = Tools.Xml.ReadXmlProp(m.ContentNode, "check_id");

                        if (!Tools.Strings.StrExt(CheckID))
                            CheckID = Tools.Strings.GetNewID().Replace("-", "");

                        BackupFolderPath = Tools.Xml.ReadXmlProp(m.ContentNode, "backup_folder_path");
                        PrepareItem();

                        break;
                    case "beginning_prepare":

                        //GotStatus(
                        break;

                    case "prepare_failed":
                        Completed = true;
                        Success = false;
                        AfterDo();
                        String s = Tools.Xml.ReadXmlProp(m.ContentNode, "error_message");
                        AddLog("Prepare failed: " + s);
                        break;
                    case "prepare_complete":
                        String strFile = Tools.Xml.ReadXmlProp(m.ContentNode, "file_name");
                        long lngSize = Tools.Xml.ReadXmlProp_Long(m.ContentNode, "file_size");
                        AddLog("Prepare complete: " + strFile);
                        if (PrepareComplete != null)
                            PrepareComplete(this, strFile, lngSize);
                        break;
                    case "pedestal_upload_request":
                        HandlePedestalUploadRequest(m.ContentNode);
                        break;
                    case "pedestal_upload_complete":
                        if (PedestalUploadComplete != null)
                            PedestalUploadComplete(this);
                        break;
                    default:
                        base.GotMessage(m);
                        break;
                }
            }
            catch (Exception ex)
            {
                AddLog("EternalCheck Error: " + ex.Message);
            }
        }

        public void HandlePedestalUploadRequest(XmlNode n)
        {
            UploadStartTime = DateTime.Now;

            if( !Tools.Strings.StrExt(BackupPayloadFile) || !File.Exists(BackupPayloadFile) )
            {
                SendGenericError("The backup payload file '" + BackupPayloadFile + "' could not be found.");
                return;
            }

            ArrayList a = ParsePedestals(n);

            if( a.Count == 0 )
            {
                SendGenericError("No pedestals were found in the request");
                return;
            }

            foreach (StreamPoint_FTP f in a)
            {
                try
                {
                    SendStatus("Uploading to " + f.FTPSite);
                    SendProgress(0);

                    StreamPoint_File file = new StreamPoint_File();
                    file.FileName = BackupPayloadFile;

                    TieStream stream = new TieStream();
                    stream.SourcePoint = file;

                    f.FileName = Path.GetFileName(BackupPayloadFile);
                    stream.DestPoint = f;

                    stream.GotSteppedProgress += new StreamProgressHandler(stream_GotSteppedProgress);
                    stream.GotStatus += new StreamStatusHandler(stream_GotStatus);
                    stream.StreamCompleted += new StreamEventHandler(stream_StreamCompleted);
                    stream.StreamFailed += new StreamEventHandler(stream_StreamFailed);
                    stream.BeginStream();
                    
                }
                catch (Exception ex)
                {
                    SendGenericError("There was an error uploading to " + f.FTPSite + ": " + ex.Message);
                }
            }

            //SimpleReply("pedestal_upload_complete", "status_message", "complete");
        }

        void stream_StreamFailed(TieStream s, string message)
        {
            Cleanup();

            SendStatus("Upload to " + s.DestPoint.Caption + " failed: " + message);
            SendProgress(0);
        }

        void stream_StreamCompleted(TieStream s, string message)
        {
            long secs = 0;
            try
            {
                TimeSpan t = DateTime.Now.Subtract(UploadStartTime);
                secs = Convert.ToInt64(t.TotalSeconds);
            }
            catch{}

            Cleanup();

            if (Tools.Strings.StrExt(message))
                SendStatus("Upload to " + s.DestPoint.Caption + " complete in " + Tools.Dates.FormatHMS(secs) + ": " + message);
            else
                SendStatus("Upload to " + s.DestPoint.Caption + " complete in " + Tools.Dates.FormatHMS(secs));


            SendProgress(100);
        }

        void Cleanup()
        {
            //delete the payload file
            if (File.Exists(BackupPayloadFile))
            {
                try
                {
                    File.Delete(BackupPayloadFile);
                    SendStatus("Temp file " + BackupPayloadFile + " deleted.");
                }
                catch (Exception ex)
                {
                    SendStatus("Temp file " + BackupPayloadFile + " delete failed: " + ex.Message);
                }
            }
        }

        void stream_GotStatus(string status)
        {
            SendStatus(status);
        }

        void stream_GotSteppedProgress(int progress)
        {
            SendProgress(progress);
        }

        Thread PrepareThread;

        public void PrepareItem()
        {
            if (PrepareThread != null)
            {
                try
                {
                    PrepareThread.Abort();
                }
                catch { }
            }

            PrepareThread = new Thread(new ThreadStart(PrepareItemOnThread));
            PrepareThread.SetApartmentState(ApartmentState.STA);
            PrepareThread.Start();
        }

        public void PrepareItemOnThread()
        {
            TieMessage reply = GetReply();
            reply.FunctionName = "beginning_prepare";
            Send(reply);

            switch (ItemHandle.TheType)
            {
                case  EternalItemType.Database:
                    PrepareDatabase();
                    break;
                case EternalItemType.Folder:
                    PrepareFolder();
                    break;
            }

        }

        public bool PrepareFolder()
        {
            try
            {
                if( !Directory.Exists(ItemHandle.FolderPath) )
                {
                    SimpleReply("prepare_failed", "error_message", "folder not found");
                    return false;
                }

                CheckCreateBackupFolder();
                String strZip = Tools.Folder.ConditionFolderName(BackupFolderPath) + "bk_" + ItemHandle.Caption + "_" + Tools.Folder.GetNowPath() + "_" + CheckID + ".zip";

                SendStatus("Zipping " + ItemHandle.FolderPath);

                if (!Tools.Zip.ZipOneFolder(ItemHandle.FolderPath, strZip))
                {
                    SimpleReply("prepare_failed", "error_message", "zip process failed");
                    return false;
                }

                FileInfo i;
                try
                {
                    i = new FileInfo(strZip);
                }
                catch (Exception ex2)
                {
                    SimpleReply("prepare_failed", "error_message", "RTE: " + ex2.Message);
                    return false;
                }

                BackupPayloadFile = strZip;
                SendPrepareComplete(strZip, i.Length);
                i = null;
                return true;
            }
            catch (Exception ex)
            {
                SimpleReply("prepare_failed", "error_message", "RTE: " + ex.Message);
                return false;
            }
        }

        public void PrepareDatabase()
        {
            try
            {
                //nData d = new nData();
                //d.target_type = (int)Tools.Database.ServerType.SqlServer;
                //d.server_name = ItemHandle.ServerName;
                //d.database_name = ItemHandle.DatabaseName;
                //d.user_name = ItemHandle.UserName;
                //d.user_password = ItemHandle.Password;
                //d.SetConnectionString();
                Tools.Database.DataConnectionSqlServer d = new Tools.Database.DataConnectionSqlServer();
                Tools.Database.Key key = new Tools.Database.Key();
                key.ServerName = ItemHandle.ServerName;
                key.DatabaseName = ItemHandle.DatabaseName;
                key.UserName = ItemHandle.UserName;
                key.UserPassword = ItemHandle.Password;
                d.Init(key);
                //String ss = "";
                //if (!d.ConnectPossible(ref ss))
                //{
                //    SimpleReply("prepare_failed", "error_message", ss);
                //    return;
                //}
                try { d.ConnectPossible(); }
                catch (Exception e)
                { 
                    SimpleReply("prepare_failed", "error_message", e.Message);
                    return;
                }
                SendStatus("Connected to " + d.TheKey.ServerName + "/" + d.TheKey.DatabaseName);
                CheckCreateBackupFolder();
                //get the size and make sure it will fit
                long datasize = d.GetDataSizeBytes();
                DriveInfo di = new DriveInfo(Path.GetPathRoot(BackupFolderPath));
                if (di.AvailableFreeSpace < (datasize * 1.5))  //has to handle the backup plus the zip file
                {
                    SimpleReply("prepare_failed", "error_message", BackupFolderPath + " has only " + Tools.Number.LongFormat(di.AvailableFreeSpace) + " available, and needs " + Tools.Number.LongFormat(datasize));
                    return;
                }
                di = null;
                SendStatus("Marking the check id " + CheckID);
                //mark it with the check id
                d.Execute("drop table " + EternalItemHandle.EternalTableCheckName);
                try { d.Execute("create table " + EternalItemHandle.EternalTableCheckName + " ( check_id varchar(255) )"); }
                catch (Exception e)
                {
                    SimpleReply("prepare_failed", "error_message", "creating the check table failed: " + e.Message);
                    return;
                }
                try { d.Execute("insert into " + EternalItemHandle.EternalTableCheckName + " ( check_id ) values ( '" + CheckID + "' ) "); }
                catch (Exception e)
                {
                    SimpleReply("prepare_failed", "error_message", "filling the check table failed: " + e.Message);
                    return;
                }
                //back it up
                String strBase = Tools.Folder.ConditionFolderName(BackupFolderPath) + "bk_" + d.TheKey.ServerName + "_" + d.TheKey.DatabaseName + "_" + Tools.Folder.GetNowPath() + "_" + CheckID;
                String strFile = strBase + ".bak";
                String strZip = strBase + ".zip";
                if (File.Exists(strFile))
                {
                    SimpleReply("prepare_failed", "error_message", "the file " + strFile + " already exists.");
                    return;
                }
                try
                {
                    SendStatus("Shrinking...");
                    d.Shrink();
                }
                catch { }
                SendStatus("Backing up...");
                try { d.Backup(ref strFile); }
                catch(Exception e)
                {
                    SimpleReply("prepare_failed", "error_message", "Backup failed: " + e.Message);
                    return;
                }
                if (!File.Exists(strFile))
                {
                    SimpleReply("prepare_failed", "error_message", "file " + strFile + " wasn't found");
                    return;
                }
                //zip it
                SendStatus("Zipping...");
                if (!Tools.Zip.ZipOneFile(strFile, strZip))
                {
                    SimpleReply("prepare_failed", "error_message", "zipping " + strFile + " failed");
                    return;
                }
                //delete the .bak file
                try
                {
                    File.Delete(strFile);
                    SendStatus("Zip complete: deleted temp file " + strFile);
                }
                catch (Exception exd)
                {
                    SendStatus("Zip complete: temp .bak delete failed: " + exd.Message);
                }
                long filesize = 0;
                try
                {
                    FileInfo fi = new FileInfo(strZip);
                    filesize = fi.Length;
                    fi = null;
                }
                catch (Exception ex)
                {
                    SimpleReply("prepare_failed", "error_message", "getting FileInfo on " + strZip + " failed: " + ex.Message);
                    return;
                }
                BackupPayloadFile = strZip;
                SendPrepareComplete(strZip, filesize);
            }
            catch (Exception ex)
            {
                SimpleReply("prepare_failed", "error_message", "RTE: " + ex.Message);
            }
        }

        public void SendPrepareComplete(String strFile, long size)
        {
            TieMessage reply = GetReply();
            reply.FunctionName = "prepare_complete";
            reply.ContentString = Tools.Xml.BuildXmlProp("file_name", strFile) + Tools.Xml.BuildXmlProp("file_size", size);
            Send(reply);
        }

        public void CheckCreateBackupFolder()
        {
            if (!Tools.Strings.StrExt(BackupFolderPath) || !Directory.Exists(BackupFolderPath))
            {
                //get the folder to back up to
                //if (nTools.IsDevelopmentMachinePlain())
                //    BackupFolderPath = "c:\\eternal\\data\\tierack\\backup\\";
                //else
                    BackupFolderPath = Tools.FileSystem.GetAppPath() + "backup\\";

                if (!Directory.Exists(BackupFolderPath))
                    Directory.CreateDirectory(BackupFolderPath);
            }
        }

        public void SendPedestalUploadRequest(ArrayList ftp_points)
        {
            TieMessage rep = new TieMessage(xEnd.GetSessionFrom(), "pedestal_upload_request", TargetSession);

            StringBuilder sb = new StringBuilder("<pedestals>");
            foreach(StreamPoint_FTP f in ftp_points)
            {
                sb.AppendLine("<pedestal>");
                sb.AppendLine(f.GetXml());
                sb.AppendLine("</pedestal>");
            }
            sb.AppendLine("</pedestals>");
            rep.ContentString = sb.ToString();
            Send(rep);
        }

        public ArrayList ParsePedestals(XmlNode n)
        {
            ArrayList a = new ArrayList();

            try
            {
                XmlNodeList l = n.SelectNodes("pedestals/pedestal");
                foreach (XmlNode fn in l)
                {
                    try
                    {
                        StreamPoint_FTP f = new StreamPoint_FTP();
                        f.AbsorbXml(fn);
                        a.Add(f);
                    }
                    catch { }
                }
            }
            catch { }

            return a;
        }
    }
}
