using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Net;
using System.Collections;

using NewMethodx;
using OthersCodex;

namespace Tie.Rescue
{
    public class RzRescueDatabase
    {
        //Public Variables
        public string Server = "";
        public string Database = "";
        public string User = "";
        public string Password = "";
        public string Use = "Rz";
        public string BackupId = "";

        public List<FtpInfo> Sites = new List<FtpInfo>();

        //Private Variables
        //private nData TheData;
        private Tools.Database.DataConnection TheData;

        public RzRescueDatabase()
        {
        }

        public void Rescue()
        {
            String uniqueFile = BackUp();

            bool success = true;
            StringBuilder status = new StringBuilder();

            //hit each ftp site, even if one fails
            foreach (FtpInfo ftp in Sites)
            {
                try
                {
                    ftp.PushFolder(Database);
                    ftp.PushFolder(BackupId);
                    UploadPersistently(uniqueFile, ftp);
                }
                catch (Exception ex)
                {
                    success = false;
                    status.AppendLine("FTP failed: " + ftp.Server + " " + ex.Message);
                }
            }
            
            Archive();

            if (!success)
                throw new Exception("Rescue failed: " + status.ToString());
        }

        public void UploadPersistently(String uniqueFile, FtpInfo ftpInfo)
        {
            //status.SetStatus("Runing Upload DB[" + Database + "]...");

            String error = "";
            for (int tryindex = 0; tryindex < 5; tryindex++)
            {
                int i = tryindex + 1;
                //status.SetStatus("TryIndex: " + i.ToString());

                try
                {
                    Upload(uniqueFile, ftpInfo);
                    return;
                }
                catch (Exception ex)
                {
                    int tenminutesinmilliseconds = 1000 * 60 * 10;
                    System.Threading.Thread.Sleep((tryindex + 1) * tenminutesinmilliseconds);
                    error = ex.Message;
                }
            }

            throw new Exception("UploadPersistently Failed " + ftpInfo.Server + " : " + error);
        }

        //Private Functions
        private void PrepData()
        {
            //status.SetStatus("Preparing Data...");
            Tools.Database.Key k = new Tools.Database.Key();
            k.DatabaseName = Database;
            k.ServerName = Server;
            k.UserName = User;
            k.UserPassword = Password;
            TheData = new Tools.Database.DataConnectionSqlServer();
            TheData.Init(k);
            //status.SetStatus("Using connection: " + TheData.ConnectionString);
            string s = "";
            if( !TheData.ConnectPossible(ref s) )
                throw new Exception("Data connection error (" + TheData.ConnectionString + ") : " + s);
        }

        private void PrepFolder(String dir)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            else
            {
                String[] files = Directory.GetFiles(dir);
                foreach (String file in files)
                {
                    String sf = Path.GetFileName(file).ToLower();
                    if (sf.StartsWith(FileNameRoot.ToLower()))
                    {
                        File.Delete(file);
                    }
                }
            }
        }

        public String BackUp()
        {
            BackupId = Tools.Dates.GetNowPathHMS();

            PrepData();
            PrepFolder(DatabaseFolder);

            String strFile = BackupFile;            
            TheData.Backup(ref strFile);
            return strFile;
        }

        //private bool GetURI(RzRescueStatus status, FtpInfo ftpInfo, string strExtraName, ref string strURI)
        //{
        //    strURI = ftpInfo.Uri;
        //    try
        //    {
        //        FtpWebRequest mkrequest = (FtpWebRequest)WebRequest.Create(strURI);
        //        mkrequest.Method = WebRequestMethods.Ftp.MakeDirectory;
        //        mkrequest.Credentials = new NetworkCredential(ftpInfo.User, ftpInfo.Password);
        //        FtpWebResponse mkresponse = (FtpWebResponse)mkrequest.GetResponse();
        //        mkresponse.Close();
        //    }
        //    catch (Exception ex1)
        //    {
        //        status.SetStatus("Error in Upload (making directory[" + strURI + "]) : " + ex1.Message);
        //        status.AddSummaryLine("Upload", false, "Error in Upload (making directory[" + strURI + "]) : " + ex1.Message);
        //    }
        //    if (Tools.Strings.StrExt(Database))
        //        strURI += Database + "/";
        //    try
        //    {
        //        FtpWebRequest mkrequest = (FtpWebRequest)WebRequest.Create(strURI);
        //        mkrequest.Method = WebRequestMethods.Ftp.MakeDirectory;
        //        mkrequest.Credentials = new NetworkCredential(ftpInfo.User, ftpInfo.Password);
        //        FtpWebResponse mkresponse = (FtpWebResponse)mkrequest.GetResponse();
        //        mkresponse.Close();
        //    }
        //    catch (Exception ex1)
        //    {
        //        status.SetStatus("Error in Upload (making directory[" + strURI + "]) : " + ex1.Message);
        //        status.AddSummaryLine("Upload", false, "Error in Upload (making directory[" + strURI + "]) : " + ex1.Message);
        //    }
        //    if (Tools.Strings.StrExt(strExtraName))
        //        strURI += strExtraName + "/";
        //    status.SetStatus("strURI = " + strURI);
        //    try
        //    {
        //        FtpWebRequest mkrequest = (FtpWebRequest)WebRequest.Create(strURI);
        //        mkrequest.Method = WebRequestMethods.Ftp.MakeDirectory;
        //        mkrequest.Credentials = new NetworkCredential(ftpInfo.User, ftpInfo.Password);
        //        FtpWebResponse mkresponse = (FtpWebResponse)mkrequest.GetResponse();
        //        if (mkresponse.StatusCode != FtpStatusCode.PathnameCreated)
        //        {
        //            status.SetStatus("Make Dir Returned " + mkresponse.StatusCode.ToString());
        //            mkresponse.Close();
        //            return false;
        //        }
        //        mkresponse.Close();
        //    }
        //    catch (Exception ex1)
        //    {
        //        status.SetStatus("Error in Upload (making directory[" + strURI + "]) : " + ex1.Message);
        //        status.AddSummaryLine("Upload", false, "Error in Upload (making directory[" + strURI + "]) : " + ex1.Message);
        //        return false;
        //    }
        //    return true;
        //}

        private void Upload(String uniqueFile, FtpInfo ftpInfo)
        {
            String fileToSend = "";

            MakeZipOrPatch(uniqueFile, ftpInfo, ref fileToSend);

            if (!File.Exists(fileToSend))
                throw new Exception("FileToSend missing: " + fileToSend);

            SendFile(ftpInfo, fileToSend);
        }
        private void MakeZipOrPatch(String uniqueFile, FtpInfo ftpInfo, ref string fileToSend)
        {
            PrepFolder(SiteFolder(ftpInfo));

            //status.SetStatus("Backup Complete; .zipping/patching");
            //status.SetStatus("DatabaseFolder: " + DatabaseFolder);
            //status.SetStatus("ArchiveFolder: " + ArchiveFolder);
            //status.SetStatus("UniqueFile: " + uniqueFile);
            //status.SetStatus("ZipFile: " + ZipFile(ftpInfo));
            //status.SetStatus("PatchPatch: " + PatchFile(ftpInfo));
            
            if (CanSendPatch(ftpInfo) )
            {
                CreatePatchFile(uniqueFile, ftpInfo);
                String patchFile = PatchFile(ftpInfo);
                String zipFile = ZipFile(ftpInfo);
                if (!Tools.Zip.ZipOneFile(patchFile, zipFile))
                    throw new Exception("Patch zip failed on : " + patchFile + " to " + zipFile);

                fileToSend = zipFile;  // ZipFile(ftpInfo);
            }
            else
            {
                //status.SetStatus("Zip of backup needed, ZipOneFile() strFile = " + BackupFile + " strZip = " + ZipFile(ftpInfo));
                String zipFile = ZipFile(ftpInfo);
                if (Tools.Zip.ZipOneFile(BackupFile, zipFile))
                    fileToSend = zipFile;
                else
                    throw new Exception("Zip failed on " + BackupFile + " to " + zipFile);
            }
        }

        private bool CanSendPatch(FtpInfo ftpInfo)
        {
            //status.SetStatus("Checking bool CanSendPatch()");
            
            if (!Tools.Files.FileExists(ArchiveFileLast))
                return false;
            
            FileInfo info = new FileInfo(ArchiveFileLast);

            //RzRescue\PhoenixRoot\Phoenix\Rz3\LastBackUp

            long lastRemoteSuccessSize = Tools.Ftp.GetFileSize(ftpInfo.UriOriginal + Database + "/LastBackUp/" + Path.GetFileName(ArchiveFileLast), ftpInfo.User, ftpInfo.Password);
            return (lastRemoteSuccessSize == info.Length);
        }
        private void CreatePatchFile(String uniqueFile, FtpInfo ftpInfo)
        {
            string cmd = " delta " + ArchiveFileLast + " " + BackupFile + " " + PatchFile(ftpInfo);
            System.Diagnostics.Process x = new System.Diagnostics.Process();
            x.StartInfo.FileName = Tools.Folder.ConditionFolderName(Tools.Folder.GetAppPath()) + "xdelta3.bat";
            x.StartInfo.Arguments = cmd;
            x.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            x.StartInfo.Verb = "open";
            x.StartInfo.UseShellExecute = true;
            x.Start();
                
            //xdelta still had the patch file open without this
            x.WaitForExit();
            x.Dispose();
            x = null;
        }
        private bool GetPatchOnly(string[] files)
        {
            foreach (string s in files)
            {
                string ext = Tools.Files.GetFileExtention(s);
                if (Tools.Strings.StrCmp(ext, "pat"))
                    return true;
            }
            return false;
        }
        private void SendFile(FtpInfo ftpInfo, String fileToSend)
        {
            String fileName = Path.GetFileName(fileToSend);
            String success = fileName + ".success";
            try
            {
                FtpWebRequest delrequest = (FtpWebRequest)WebRequest.Create(ftpInfo.Uri + success);
                delrequest.Method = WebRequestMethods.Ftp.DeleteFile;
                delrequest.Credentials = new NetworkCredential(ftpInfo.User, ftpInfo.Password);
                FtpWebResponse delresponse = (FtpWebResponse)delrequest.GetResponse();
                FtpStatusCode response = delresponse.StatusCode;
                delresponse.Close();
            }
            catch{}
                
            //if (response != FtpStatusCode.FileActionOK)
            //    throw new Exception("Delete success returned " + response.ToString());

            FileInfo fi = new FileInfo(fileToSend);
            BinaryReader r = new BinaryReader(new FileStream(fileToSend, FileMode.Open, FileAccess.Read));

            bool successFlag = true;
            String errorMessage = "";
            try
            {
                int chunksize = 1024 * 1024;
                long chunks = fi.Length / chunksize;
                int leftover = Convert.ToInt32(fi.Length % chunksize);
                for (long chunk = 0; chunk < chunks; chunk++)
                {
                    byte[] fileContents = r.ReadBytes(chunksize);
                    SendChunk(ftpInfo, fileName, chunk, fileContents);
                }
                if (leftover > 0)
                {
                    byte[] fileContents = r.ReadBytes(leftover);
                    SendChunk(ftpInfo, fileName, chunks, fileContents);
                }
            }
            catch (Exception ex)
            {
                successFlag = false;
                errorMessage = ex.Message;
            }

            //need to close this regardless of failure above
            r.Close();
            r = null;

            if (!successFlag)
                throw new Exception(errorMessage);

            //status.SetStatus("Sending success file : " + success + " using id : " + BackupId);
            SendChunk(ftpInfo, success, 0, Encoding.ASCII.GetBytes(BackupId));
        }

        private void SendChunk(FtpInfo ftpInfo, String fileName, long chunk, Byte[] fileContents)
        {
            String error = "";
            for (int tryindex = 0; tryindex < 100; tryindex++)
            {
                try
                {
                    TrySendChunk(ftpInfo, fileName, chunk, fileContents);
                    return;
                }
                catch(Exception ex)
                {
                    error = ex.Message;
                }
                System.Threading.Thread.Sleep((tryindex + 5) * 1000);
            }
            throw new Exception("SendChunk failed " + fileName + " " + ftpInfo.Server + " " + error);
        }

        private void TrySendChunk(FtpInfo ftpInfo, String fileName, long chunk, Byte[] fileContents)
        {
            //2013_03_14 i wasn't sure the best way to do this.  the problem is that if an exception happens on Write, where its most likely, the request and streams never get closed
            //that should probably be re-arranged but this order of operations has been working and i don't want to change it so i added these flags to maintain the exception change

            bool success = true;
            String error = "";

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpInfo.Uri + fileName + "." + Tools.Strings.Right("00000000" + chunk.ToString(), 8));
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(ftpInfo.User, ftpInfo.Password);
                request.ContentLength = fileContents.Length;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                
                //status.SetStatus("Upload chunk " + chunk.ToString() + " complete, status " + response.StatusDescription);
                
                response.Close();
                if (!response.StatusDescription.StartsWith("226"))
                {
                    success = false;
                    error = "Transfer of chunk " + chunk.ToString() + " of " + fileName + " failed: " + response.StatusDescription;
                }
            }
            catch (Exception ex)
            {
                success = false;
                error = ex.Message;
            }

            if (!success)
                throw new Exception(error);
        }
        //private void StoreLastBackUp(String file, String id)
        //{
        //    status.SetStatus("Storing last backup, file: " + file + " id: " + id);
        //    string filenoext = Tools.Files.GetFileNameNoExtention(file);
        //    file = Tools.Folder.ConditionFolderName(Tools.Folder.GetFolderName(file)) + filenoext + ".zip";
        //    string dest_folder = Tools.Folder.ConditionFolderName(Tools.Folder.GetFolderName(file)) + "LastBackUp\\";
        //    status.SetStatus("StoreLastBackUp() dest_folder = " + dest_folder);
        //    Tools.Folder.FolderObliterate(dest_folder);
        //    Tools.Folder.MakeFolderExist(dest_folder);
        //    string dest = Tools.Folder.ConditionFolderName(dest_folder) + id + ".bak";
        //    Tools.Zip.UnZipOneFile(file, dest_folder);
        //    string[] files = System.IO.Directory.GetFiles(dest_folder);
        //    string bak_file = files[0];
        //    Tools.Files.CopyFile(bak_file, dest);
        //    Tools.Files.TryDeleteFile(bak_file);
        //    Tools.Files.TryDeleteFile(file);
        //    status.SetStatus("Finished StoreLastBackUp()");
        //}

        public void Archive()
        {
            //if (!PrepFolder(status, ArchiveFolder))
            //    return false;

            if (Directory.Exists(ArchiveFolder))
                Tools.Folder.FolderObliterate(ArchiveFolder);  //needs to remove everything, not just matching files, to remove old backups
            else
                Directory.CreateDirectory(ArchiveFolder);

            File.Move(BackupFile, ArchiveFileNext(BackupFile));
        }

        public String DatabaseFolder
        {
            get
            {
                return Tools.Folder.ConditionFolderName(Tie.Rescue.RzRescueManager.RootFolder) + Database + @"\";
            }
        }

        public String FileNameRoot
        {
            get
            {
                return TheData.TheKey.DatabaseName + "__as__" + Use;
                //return TheData.database_name + "__as__" + Use;
            }
        }

        public String ArchiveFolder
        {
            get
            {
                return DatabaseFolder + @"LastBackUp\";
            }
        }

        public String ArchiveFileLast
        {
            get
            {
                try
                {
                    String[] files = Directory.GetFiles(ArchiveFolder, "*.bak");
                    if (files.Length == 0)
                        return "";
                    else
                        return files[0];
                }
                catch { return ""; }
            }
        }

        public String ArchiveFileNext(String currentFile)
        {
            return ArchiveFolder + Path.GetFileName(currentFile);
        }

        public String BackupFile
        {
            get
            {
                return DatabaseFolder + BackupFileRoot + ".bak";
            }
        }

        public String BackupFileRoot
        {
            get
            {
                return FileNameRoot + "_UID_" + BackupId;
            }
        }

        public String SiteFolder(FtpInfo ftpInfo)
        {
            return DatabaseFolder + ftpInfo.ServerPathName + @"\";
        }

        public String PatchFile(FtpInfo ftpInfo)
        {
            return SiteFolder(ftpInfo) + BackupFileRoot + ".pat";
        }

        public String ZipFile(FtpInfo ftpInfo)
        {
            return SiteFolder(ftpInfo) + BackupFileRoot + ".zip";
        }
    }
}
