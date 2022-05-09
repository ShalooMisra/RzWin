using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Net;
using System.Collections;
using NewMethodx;
using OthersCodex;

namespace Tie
{
    public class VaultManager : TieDuty
    {
        public String EternalFolder = "";
        public List<EternalExtra> ExtraItems = new List<EternalExtra>();
        public List<EternalTarget> Targets = new List<EternalTarget>();

        public VaultManager(String strFile) : base(strFile)
        {

        }

        public override bool InitFromXml(XmlNode n)
        {
            EternalFolder = n.Attributes["EternalFolderPath"].Value;
            if (!Tools.Strings.StrExt(EternalFolder))
            {
                AddStatus("Blank eternal folder name");
                return false;
            }

            if (!Directory.Exists(EternalFolder))
            {
                AddStatus(EternalFolder + " does not exist");
                return false;
            }

            bool b = true;
            foreach (XmlNode nx in n.ChildNodes)
            {
                String type = "";
                try
                {
                    type = nx.Attributes["VaultItemType"].Value;
                }
                catch { }

                switch(type)
                {
                    case "EternalFTPTarget":
                        EternalFTPTarget ft = new EternalFTPTarget(this);
                        if (!ft.InitFromXml(nx))
                            b = false;
                        Targets.Add(ft);
                        break;
                    case "EternalLocalTarget":
                        EternalLocalTarget lt = new EternalLocalTarget(this);
                        if (!lt.InitFromXml(nx))
                            b = false;
                        Targets.Add(lt);
                        break;
                    case "SQLDatabase":
                        EternalSQLDatabase s = new EternalSQLDatabase(this);
                        if (!s.InitFromXml(nx))
                            b = false;
                        ExtraItems.Add(s);
                        break;
                    case "EternalThunderbirdFolder":
                        EternalThunderbirdFolder f = new EternalThunderbirdFolder(this);
                        if (!f.InitFromXml(nx))
                            b = false;
                        ExtraItems.Add(f);
                        break;
                }
            }
            return b;
        }

        public override void Do(ref bool success)
        {
            //this is already try/caught
            AddStatus("Preparing...");
            foreach (EternalExtra i in ExtraItems)
            {
                AddStatus("Preparing " + i.Name);
                if (!i.Prepare())
                {
                    AddStatus("Prepare failed on " + i.Name);
                    success = false;
                }
            }

            //do the exports
            foreach (EternalTarget t in Targets)
            {
                AddStatus("Sending to " + t.Name);
                if (!t.Export())
                    success = false;
            }

            foreach (EternalExtra i in ExtraItems)
            {
                if (!i.Finish())
                {
                    AddStatus("Finish failed on " + i.Name);
                    success = false;
                }
            }
        }
    }
    public abstract class EternalItem
    {
        public String Name = "";
        public VaultManager TheManager;

        public EternalItem(VaultManager m)
        {
            TheManager = m;
        }

        public virtual bool InitFromXml(XmlNode n)
        {
            Name = Tools.Xml.ReadXmlProp(n, "Name");
            return true;
        }
    }
    public abstract class EternalTarget : EternalItem
    {
        public EternalTarget(VaultManager m)
            : base(m)
        {

        }

        public abstract bool Export();
    }
    public class EternalFTPTarget : EternalTarget
    {
        public String FtpSite = "";
        public String FtpFolder = "";
        public String UserName = "";
        public String UserPassword = "";
        static int MaxErrors = 300;
        public EternalFTPTarget(VaultManager m)
            : base(m)
        {
        }
        public override bool InitFromXml(XmlNode n)
        {
            if (!base.InitFromXml(n))
                return false;
            FtpSite = Tools.Xml.ReadXmlProp(n, "FtpSite");
            FtpFolder = Tools.Xml.ReadXmlProp(n, "FtpFolder");
            UserName = Tools.Xml.ReadXmlProp(n, "UserName");
            UserPassword = Tools.Xml.ReadXmlProp(n, "UserPassword");
            return true;
        }
        public override bool Export()
        {
            for (int tryindex = 0; tryindex < 5; tryindex++)
            {
                if (Export(TheManager.EternalFolder, Tools.Dates.GetNowPathHMS()))
                    return true;

                int tenminutesinmilliseconds = 1000 * 60 * 10;

                System.Threading.Thread.Sleep((tryindex + 1) * tenminutesinmilliseconds);  //up to an hour of wait
            }
            return false;   
        }
        private bool MakeZipOrPatch(string strLocalFolder)
        {
            string ArchiveFolder = strLocalFolder + "LastBackUp\\";
            if (!Directory.Exists(ArchiveFolder))
                System.IO.Directory.CreateDirectory(ArchiveFolder);
            string[] files = System.IO.Directory.GetFiles(strLocalFolder, "*.bak");
            String strFile = files[0];
            String strZip = strFile.Replace(".bak", ".zip");
            String strPatch = strFile.Replace(".bak", ".pat");
            TheManager.AddStatus("Backup Complete; .zipping/patching");
            TheManager.AddStatus("strLocalFolder: " + strLocalFolder);
            TheManager.AddStatus("ArchiveFolder: " + ArchiveFolder);
            TheManager.AddStatus("strFile: " + strFile);
            TheManager.AddStatus("strZip: " + strZip);
            TheManager.AddStatus("strPatch: " + strPatch);
            if (CanSendPatch(ArchiveFolder, Tools.Files.GetFileName(strZip) + ".success.00000000", Tools.Files.GetFileName(strPatch) + ".success.00000000"))
            {
                TheManager.AddStatus("Patch file needed, CreatePatchFile()");
                if (CreatePatchFile(strFile, strPatch))
                {
                    TheManager.AddStatus("Patch complete; removing original.");
                    try
                    {
                        if (!Tools.Zip.ZipOneFile(strFile, strZip))
                        {
                            TheManager.AddStatus("Patch failed");
                            return false;
                        }
                        File.Delete(strFile);
                    }
                    catch (Exception ex)
                    {
                        TheManager.AddStatus("Error deleting original: " + ex.Message);
                    }
                    return true;
                }
                else
                {
                    TheManager.AddStatus("Patch failed");
                    return false;
                }
            }
            else
            {
                TheManager.AddStatus("Zip of backup needed, ZipOneFile() strFile = " + strFile + " strZip = " + strZip);
                if (Tools.Zip.ZipOneFile(strFile, strZip))
                {
                    TheManager.AddStatus("Zip complete; removing original.");
                    try
                    {
                        File.Delete(strFile);
                    }
                    catch (Exception ex)
                    {
                        TheManager.AddStatus("Error deleting original: " + ex.Message);
                    }
                    return true;
                }
                else
                {
                    TheManager.AddStatus("Zip failed");
                    return false;
                }
            }
        }
        public bool Export(String strLocalFolder, String strExtraName)
        {
            if (strLocalFolder.ToLower().Contains("sqlserverbackups"))
                MakeZipOrPatch(Tools.Folder.ConditionFolderName(TheManager.EternalFolder) + "SQLServerBackups\\");
            bool b = true;
            TheManager.AddStatus("Uploading " + strLocalFolder + " to " + FtpSite + "...");
            String strServer = FtpSite;
            if (!strServer.StartsWith("ftp://"))
                strServer = "ftp://" + strServer;
            if (!strServer.EndsWith("/"))
                strServer += "/";
            String strURI = strServer;
            if (Tools.Strings.StrExt(FtpFolder))
                strURI += FtpFolder + "/";

            try
            {
                FtpWebRequest mkrequest = (FtpWebRequest)WebRequest.Create(strURI);
                mkrequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                mkrequest.Credentials = new NetworkCredential(UserName, UserPassword);

                //just in case
                FtpWebResponse mkresponse = (FtpWebResponse)mkrequest.GetResponse();
                //if (mkresponse.StatusCode != FtpStatusCode.PathnameCreated)
                //{
                //    TheManager.AddStatus("Make Dir Returned " + mkresponse.StatusCode.ToString());
                //    mkresponse.Close();
                //    return false;
                //}

                mkresponse.Close();
            }
            catch (Exception ex1)
            {
                TheManager.AddStatus("RTE: " + ex1.Message);
                //return false;
            }

            if (Tools.Strings.StrExt(strExtraName))
                strURI += strExtraName + "/";
            TheManager.AddStatus("strURI = " + strURI);


            try
            {
                FtpWebRequest mkrequest = (FtpWebRequest)WebRequest.Create(strURI);
                mkrequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                mkrequest.Credentials = new NetworkCredential(UserName, UserPassword);
                
                FtpWebResponse mkresponse = (FtpWebResponse)mkrequest.GetResponse();
                if (mkresponse.StatusCode != FtpStatusCode.PathnameCreated)
                {
                    TheManager.AddStatus("Make Dir Returned " + mkresponse.StatusCode.ToString());
                    mkresponse.Close();
                    return false;
                }

                mkresponse.Close();
            }
            catch (Exception ex1)
            {
                TheManager.AddStatus("RTE: " + ex1.Message);
                return false;
            }

            String[] files = Directory.GetFiles(strLocalFolder);
            bool patch_only = GetPatchOnly(files);
            TheManager.AddStatus("GetPatchOnly() == " + patch_only.ToString());
            foreach (String file in files)
            {
                if (patch_only && !Tools.Strings.StrCmp(Tools.Files.GetFileExtention(file), "pat"))
                    continue;
                TheManager.AddStatus("About to send file: " + file + " to " + strURI);
                if (!SendFile(strURI, file))
                    b = false;
            }

            String[] dirs = Directory.GetDirectories(strLocalFolder);
            foreach (String dir in dirs)
            {
                String dn = Tools.Folder.GetTopLevelFolderName(dir);
                if (Tools.Strings.StrCmp(dn, "LastBackUp"))
                    continue;
                if (Tools.Strings.HasString(dn, "TieArchive__"))
                    continue;                    
                String dnx = strExtraName;
                if (Tools.Strings.StrExt(dnx))
                    dnx += "/";
                dnx += dn;
                if (!Export(dir, dnx))
                    return false;
            }

            return b;
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
        public bool CanSendPatch(String strFolder, String strFile, String strAltFile)
        {
            TheManager.AddStatus("Checking bool CanSendPatch()");
            if (!Tools.Strings.StrExt(strFolder))
                return false;
            if (!Tools.Folder.FolderExists(strFolder))
                return false;
            string[] files = System.IO.Directory.GetFiles(strFolder);
            if (files == null)
                return false;
            if (files.Length <= 0)
                return false;
            string s = files[0];
            if (!Tools.Strings.StrExt(s))
                return false;
            if (!Tools.Files.FileExists(s))
                return false;
            string id = Tools.Files.GetFileNameNoExtention(s);
            if (!Tools.Strings.StrExt(id))
                return false;
            String strServer = FtpSite;
            if (!strServer.StartsWith("ftp://"))
                strServer = "ftp://" + strServer;
            if (!strServer.EndsWith("/"))
                strServer += "/";
            if (Tools.Strings.StrExt(FtpFolder))
                strServer += FtpFolder + "/";
            TheManager.AddStatus("CanSendPatch still possible, checking for id in file: " + strServer + strFile);
            string id2 = Tools.Ftp.DownloadFTPString(strServer + strFile, UserName, UserPassword);
            if (!Tools.Strings.StrExt(id2))
            {
                id2 = Tools.Ftp.DownloadFTPString(strServer + strAltFile, UserName, UserPassword);
                if (!Tools.Strings.StrExt(id2))
                    return false;
            }
            if (!Tools.Strings.StrCmp(id, id2))
                return false;
            return true;
        }
        public bool CreatePatchFile(String strFile, String strPatch)
        {
            string ArchiveFolder = Tools.Folder.ConditionFolderName(Tools.Folder.GetFolderName(strFile)) + "LastBackUp\\";
            string[] files = System.IO.Directory.GetFiles(ArchiveFolder, "*.bak");
            string old_file = files[0];
            string cmd = " delta " + old_file + " " + strFile + " " + strPatch;
            System.Diagnostics.Process x = new System.Diagnostics.Process();
            x.StartInfo.FileName = Tools.Folder.ConditionFolderName(Tools.Folder.GetAppPath()) + "xdelta3.bat";
            x.StartInfo.Arguments = cmd;
            x.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            x.StartInfo.Verb = "open";
            x.StartInfo.UseShellExecute = true;
            x.Start();
            return true;
        }
        public bool SendFile(String strURI, String file)
        {
            String f = Path.GetFileName(file);
            String success = f + ".success";
            TheManager.AddStatus("Success file name : " + success);
            try
            {
                FtpWebRequest delrequest = (FtpWebRequest)WebRequest.Create(strURI + success);
                delrequest.Method = WebRequestMethods.Ftp.DeleteFile;
                delrequest.Credentials = new NetworkCredential(UserName, UserPassword);

                FtpWebResponse delresponse = (FtpWebResponse)delrequest.GetResponse();
                if (delresponse.StatusCode != FtpStatusCode.FileActionOK)
                {
                    TheManager.AddStatus("Delete success returned " + delresponse.StatusCode.ToString());
                    delresponse.Close();
                    return false;
                }

                delresponse.Close();
            }
            catch
            {
                //return false;
            }

            try
            {
                // Copy the contents of the file to the request stream.
                FileInfo fi = new FileInfo(file);
                BinaryReader r = new BinaryReader(new FileStream(file, FileMode.Open, FileAccess.Read));

                int chunksize = 1024 * 1024;
                long chunks = fi.Length / chunksize;
                int leftover = Convert.ToInt32(fi.Length % chunksize);

                for (int chunk = 0; chunk < chunks; chunk++)
                {
                    byte[] fileContents = r.ReadBytes(chunksize);

                    if (!SendChunk(f, strURI, chunk, fileContents))
                    {
                        TheManager.AddStatus("Failed to send chunk " + chunk.ToString() + " of " + chunks.ToString());
                        r.Close();
                        r = null;
                        return false;
                    }
                }

                if (leftover > 0)
                {
                    byte[] fileContents = r.ReadBytes(leftover);

                    if (!SendChunk(f, strURI, chunks, fileContents))
                    {
                        TheManager.AddStatus("Failed to send last chunk of " + chunks.ToString());
                        r.Close();
                        r = null;
                        return false;
                    }
                }

                r.Close();
                r = null;
            }
            catch(Exception exx)
            {
                TheManager.AddStatus("Error in FTPTarget.SendFile: " + exx.Message);
                return false;
            }

            //send the success file
            string id = Tools.Strings.GetNewID();
            TheManager.AddStatus("Sending success file : " + strURI + " using id : " + id);
            if (!SendChunk(success, strURI, 0, Encoding.ASCII.GetBytes(id)))
            {
                TheManager.AddStatus("Failed to send the success file: " + strURI);
                return false;
            }

            //rename .zip to id and store in lastbackup folder
            StoreLastBackUp(file, id);
            return true;
        }
        bool SendChunk(String f, String strURI, long chunk, Byte[] fileContents)
        {
            bool success = false;
            for (int tryindex = 0; tryindex < 100; tryindex++)
            {
                if (TrySendChunk(f, strURI, chunk, fileContents))
                {
                    success = true;
                    break;
                }

                System.Threading.Thread.Sleep((tryindex + 5) * 1000);
            }
            return success;
        }
        bool TrySendChunk(String f, String strURI, long chunk, Byte[] fileContents)
        {
            try
            {
                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(strURI + f + "." + Tools.Strings.Right("00000000" + chunk.ToString(), 8));
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(UserName, UserPassword);
                //request.ContentLength = fi.Length;
                request.ContentLength = fileContents.Length;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                //context.TheLeader.Comment("Upload chunk " + chunk.ToString() + " complete, status " + response.StatusDescription);
                response.Close();
                if (!response.StatusDescription.StartsWith("226"))
                {
                    TheManager.AddStatus("Transfer of chunk " + chunk.ToString() + " of " + f + " failed: " + response.StatusDescription);
                    return false;
                }
            }
            catch (Exception ex)
            {
                TheManager.AddStatus("Error FTPing " + f + ": " + ex.Message);
                return false;
            }
            return true;
        }
        void StoreLastBackUp(String file, String id)
        {
            TheManager.AddStatus("Storing last backup, file: " + file + " id: " + id);
            string filenoext = Tools.Files.GetFileNameNoExtention(file);
            file = Tools.Folder.ConditionFolderName(Tools.Folder.GetFolderName(file)) + filenoext + ".zip";
            string dest_folder = Tools.Folder.ConditionFolderName(Tools.Folder.GetFolderName(file)) + "LastBackUp\\";
            TheManager.AddStatus("StoreLastBackUp() dest_folder = " + dest_folder);
            Tools.Folder.FolderObliterate(dest_folder);
            Tools.Folder.MakeFolderExist(dest_folder);
            string dest = Tools.Folder.ConditionFolderName(dest_folder) + id + ".bak";
            Tools.Zip.UnZipOneFile(file, dest_folder);
            string[] files = System.IO.Directory.GetFiles(dest_folder);
            string bak_file = files[0];
            Tools.Files.CopyFile(bak_file, dest);
            Tools.Files.TryDeleteFile(bak_file);
            Tools.Files.TryDeleteFile(file);
            TheManager.AddStatus("Finished StoreLastBackUp()");  
        }
    }
    public class EternalLocalTarget : EternalTarget
    {
        public String LocalFolder = "";

        public EternalLocalTarget(VaultManager m)
            : base(m)
        {
        }

        public override bool InitFromXml(XmlNode n)
        {
            if (!base.InitFromXml(n))
                return false;

            LocalFolder = Tools.Xml.ReadXmlProp(n, "LocalFolder");
            return true;
        }

        public override bool Export()
        {
            return false;
        }
    }
    public abstract class EternalExtra : EternalItem
    {
        public EternalExtra(VaultManager m)
            : base(m)
        {
        }

        public abstract bool Prepare();
        public abstract bool Finish();
    }
    public class EternalSQLDatabase : EternalExtra
    {
        public String DatabaseUse = "";
        public Tools.Database.DataConnectionSqlServer TheTarget = new Tools.Database.DataConnectionSqlServer();
        //public nData TheTarget = new nData();

        public EternalSQLDatabase(VaultManager m)
            : base(m)
        {
        }

        public override bool InitFromXml(XmlNode n)
        {
            base.InitFromXml(n);
            //TheTarget.target_type = 2;
            DatabaseUse = Tools.Xml.ReadXmlProp(n, "DatabaseUse");
            Tools.Database.Key key = new Tools.Database.Key();
            key.ServerName = Tools.Xml.ReadXmlProp(n, "ServerName");
            key.DatabaseName = Tools.Xml.ReadXmlProp(n, "DatabaseName");
            key.UserName = Tools.Xml.ReadXmlProp(n, "UserName");
            key.UserPassword = Tools.Xml.ReadXmlProp(n, "UserPassword");
            TheTarget.Init(key);
            return true;
        }

        public override bool Finish()
        {
            if (!Tools.Strings.StrExt(TheTarget.TheKey.ServerName))
                return Tools.FileSystem.Shell("net start MSSQLSERVER", "", true, true);
            else
                return true;
        }

        public override bool Prepare()
        {
            if (!Tools.Strings.StrExt(TheTarget.TheKey.ServerName))
            {
                TheManager.AddStatus("Using Shell : net stop MSSQLSERVER");
                return Tools.FileSystem.Shell("net stop MSSQLSERVER", "", true, true);
            }
            else
            {
                TheManager.AddStatus("Backing Up: " + Tools.Folder.ConditionFolderName(TheManager.EternalFolder) + "SQLServerBackups\\");

                String dir = Tools.Folder.ConditionFolderName(TheManager.EternalFolder) + "SQLServerBackups\\";
                if (!Directory.Exists(dir))
                {
                    try
                    {
                        Directory.CreateDirectory(dir);
                    }
                    catch (Exception ex)
                    {
                        TheManager.AddStatus("Error: Could not create " + dir + ": " + ex.Message);
                    }
                }

                return Backup(dir);
            }
        }

        public bool Backup(String strFolder)
        {
            try
            {
                TheTarget.ConnectionStringSet();
                TheManager.AddStatus("TheTarget Connection String: " + TheTarget.ConnectionString);
                try { TheTarget.ConnectPossible(); }
                catch (Exception e)
                {
                    TheManager.AddStatus("Backup error: " + e.Message);
                    return false;
                }
                if (!Directory.Exists(strFolder))
                    System.IO.Directory.CreateDirectory(strFolder);
                String strFile = strFolder + TheTarget.TheKey.DatabaseName + "__as__" + DatabaseUse + ".bak";
                String strZip = strFile.Replace(".bak", ".zip");
                String strPatch = strFile.Replace(".bak", ".pat");
                TheManager.AddStatus("strFile = " + strFile);
                TheManager.AddStatus("strZip = " + strZip);
                TheManager.AddStatus("strPatch = " + strPatch);
                try
                {
                    if (File.Exists(strFile))
                    {
                        TheManager.AddStatus("Deleting existing strFile = " + strFile);
                        File.Delete(strFile);
                    }
                    if (File.Exists(strZip))
                    {
                        TheManager.AddStatus("Deleting existing strZip = " + strZip);
                        File.Delete(strZip);
                    }
                    if (File.Exists(strPatch))
                    {
                        TheManager.AddStatus("Deleting existing strPatch = " + strPatch);
                        File.Delete(strPatch);
                    }
                }
                catch (Exception ex)
                {
                    TheManager.AddStatus("Failed to remove previous backup copies: " + ex.Message);
                    return false;
                }
                String strSQL;
                strSQL = "EXEC sp_dropdevice '" + TheTarget.TheKey.DatabaseName + "_bak'";
                TheManager.AddStatus("Dropping backup device...");
                try { TheTarget.Execute(strSQL); }
                catch { }
                strSQL = "EXEC sp_addumpdevice 'disk', '" + TheTarget.TheKey.DatabaseName + "_bak', '" + strFile + "'";
                TheManager.AddStatus("Creating backup device...");
                try { TheTarget.Execute(strSQL); }
                catch { }
                strSQL = "BACKUP DATABASE " + TheTarget.TheKey.DatabaseName + " TO " + TheTarget.TheKey.DatabaseName + "_bak";
                TheManager.AddStatus("Running the backup...");
                try { TheTarget.Execute(strSQL); }
                catch(Exception e)
                {
                    TheManager.AddStatus("The backup failed: " + e.Message);
                    return false;
                }
                TheManager.AddStatus("The backup succeeded!");
                if (File.Exists(strFile))
                    TheManager.AddStatus("File Exists: " + strFile);
                else
                    TheManager.AddStatus("File does NOT Exist: " + strFile);
                return true;             
            }
            catch (Exception ex)
            {
                TheManager.AddStatus("Backup RTE: " + ex.Message + "\r\n\r\n" + ex.StackTrace.ToString());
                return false;
            }
        }

    }
    public class EternalThunderbirdFolder : EternalExtra
    {
        public String FolderPath = "";

        public EternalThunderbirdFolder(VaultManager m)
            : base(m)
        {
        }

        public override bool InitFromXml(XmlNode n)
        {
            base.InitFromXml(n);
            FolderPath = Tools.Xml.ReadXmlProp(n, "FolderPath");
            return true;
        }

        public override bool Prepare()
        {
            return true;
        }

        public override bool Finish()
        {
            throw new NotImplementedException();
        }
    }
}
