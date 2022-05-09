using System;
using System.Collections;
using System.IO;

using Tools;

namespace NewMethod
{
    public class UpdateDownloadCore
    {
        //KT Setting Main to .local - the other won't resolve when usiong VPN and Split-Tunneling
        public static String AlternateServer = "rzdist.sensiblemicro.com";
        public static String MainServer = "rzdist.sensiblemicro.local";
        public static String FtpUserName = "RzDist";
        public static String FtpPassword = "s3ns1bl3rZ";



        //Public Events
        public event SetStatusDelegate GotStatus;
        public event SetProgressDelegate GotProgress;
        //Public Variables
        public ContextNM TheContext;
        public String FolderName;
        public UpdateType CurrentUpdateType = UpdateType.None;
        public String RemotePath;
        public String LocalPath;
        public String DisclaimerUrl;
        public String publish_name;
        //Private Variables
        private FTP ftplib;
        private String selected_server = "";

        //Public Functions
        public bool Init(ContextNM context, UpdateType t, String disclaimerpage, String folder_name, bool alternate_source)
        {
            //String tempFtpUserName = Tools.Strings.DownloadInternetString("http://www.recognin.com/ftpuser.txt");
            //if (Tools.Strings.StrExt(tempFtpUserName))
            //{
            //    SetStatus("Found user account");
            //    FtpUserName = tempFtpUserName;
            //}
            
            TheContext = context;
            FolderName = folder_name;
            CurrentUpdateType = t;
            DisclaimerUrl = disclaimerpage;
            //local path options
            ////KT File Folder Creation test:
            //string appDataPath = Environment.GetEnvironmentVariable("LocalAppData")+ @"\Sensible Micro Corporation\";
            //string appDataPath = @"C:\ProgramData\Sensible Micro Corporation\";
            //string appDataPath = @"C:\ProgramData\Sensible Micro Corporation\";
            //string appDataPath = @"%LocalAppData%\Sensible Micro Corporation\";
            //string appDataPath = @"C:\Program Files (x86)\Sensible Micro Corporation\";
            // string installPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)+ @"\Sensible Micro Corporation\";
            string installPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\Sensible Micro Corporation\";

            switch (CurrentUpdateType)
            {
                case UpdateType.ServerToWorkstation:
                case UpdateType.WebToWorkstation:
                    {
                        //if (Tools.Misc.IsDevelopmentMachine() && Tools.FileSystem.GetAppPath().ToLower().StartsWith(@"c:\eternal\code\")) 

                        //if (Tools.Misc.IsDevelopmentMachine() && Tools.FileSystem.GetAppPath().ToLower().StartsWith(@"c:\eternal\rzwin\"))
                        //     LocalPath = @"c:\Program Files (x86)\Sensible Micro Corporation\";
                        //else
                        //    LocalPath = VersionUpdate.InferLocalPath(FolderName);

                        //KT can I use AppDataPath, regardless of dev machine for updates?
                        LocalPath = installPath;
                        break;
                    }                   
                case UpdateType.WebToServer:
                    if (Tools.Misc.IsDevelopmentMachine())
                        LocalPath = "c:\\trash\\RzUpdateTest\\";
                    else
                        LocalPath = n_set.GetSetting(TheContext, "update_folder");
                    break;
            }

            SetSource(alternate_source);

            return true;
        }
        public void SetSource(bool alternate_source)
        {
            switch (CurrentUpdateType)
            {
                case UpdateType.ServerToWorkstation:
                    //if (Tools.Misc.IsDevelopmentMachine())
                    //    RemotePath = "c:\\trash\\RzUpdateTest\\";
                    //else
                    RemotePath = n_set.GetSetting(TheContext, "update_folder");
                    break;
                case UpdateType.WebToWorkstation:
                case UpdateType.WebToServer:
                    if (alternate_source)
                        RemotePath = AlternateServer + "/Rz_UploadFolders/" + FolderName + "/Publish/";
                    else
                        RemotePath = MainServer + "/Rz_UploadFolders/" + FolderName + "/Publish/";
                    break;
            }
        }
        public bool CheckFileFolderCreation()
        {
            //string path = "";
            //path = Tools.Folder.ConditionFolderName(Tools.Folder.GetAppPath());
            //path = @"%LocalAppData%\Sensible Micro Corporation\";
            FileInfo file = new FileInfo(LocalPath);
            file.Directory.Create(); // If the directory already exists, this method does nothing.       
            if (!CheckFileCreation(LocalPath))
            {
                return false;
            }
            if (!CheckFolderCreation(LocalPath))
            {
                return false;
            }
            return true;
        }
        //IF a new version is available, this is where Rz downloads that version
        public bool RunUpdate(ContextNM context, bool alternate, bool beta, bool test)
        {
           
            String LatestInfo = "";
            string strServer = null;
            if (alternate)
                strServer = AlternateServer;
            else
                strServer = MainServer;
            //String strServer = MainServer;            
            //if (Tools.Strings.StrExt(selected_server))
            //    strServer = selected_server;
            //else if (alternate)
            //    strServer = "mike.recognin.com";
            if (test)
            {
               
                publish_name = "test";
            }
            else if (beta)
            {
                publish_name = "beta";
            }
            else
            {
                publish_name = "exec";
            }

            switch (CurrentUpdateType)
            {
                case UpdateType.WebToServer:
                case UpdateType.WebToWorkstation:
                    //AAAAAAA  this didn't have the Rz_UploadFolders part; WTF?
                    LatestInfo = Tools.Ftp.DownloadFTPString("ftp://" + strServer + "/Rz_UploadFolders/" + FolderName + "/Publish/" + publish_name + "/LatestVersion.txt", FtpUserName, FtpPassword);
                    break;
                case UpdateType.ServerToWorkstation:
                    LatestInfo = Tools.Files.OpenFileAsString(RemotePath + "LatestVersion.txt");
                    break;
                default:
                    SetStatus("Unknown update type.");
                    return false;
            }
            if (LatestInfo.StartsWith("LatestVersion"))
                return DownloadNewVersionFtp(context, LatestInfo, strServer, publish_name);
            else
            {
                SetStatus("No version update is available.");
                return false;
            }
        }
        public void OpenLatestVersion()
        {
            SetStatus("Opening the latest version...");
            LoginInfo.SetAutoLogin(TheContext.xUser.login_name, TheContext.xUser.login_password);
            Tools.FileSystem.Shell(LocalPath + "peak.exe", "-latestonly");
        }
        public void SetLocalPath()
        {
            LocalPath = VersionUpdate.InferLocalPath(FolderName);
            CurrentUpdateType = UpdateType.WebToServer;
        }
        //This is where Rz checks to see if there is a new version
        public bool NewVersionAvailable(ref string status)
        {
            bool v = true;
            String LatestInfo = "";
            String strServer = MainServer;
            String publish_name = "";
            if (Tools.Strings.StrExt(selected_server))
                strServer = selected_server;
            //To ensure the "test" system only looks for new updates in the "test" folder, I have to find a way to identigy what database I am looking at here, and set "publish_name" accordingly:
            if (TheContext.Data.DatabaseName == "Rz3_Test")
            {
                publish_name = "test";
            }
            else
            {
                publish_name = "exec";
            }
            


            switch (CurrentUpdateType)
            {
                case UpdateType.WebToServer:
                case UpdateType.WebToWorkstation:
                    LatestInfo = Tools.Ftp.DownloadFTPString("ftp://" + strServer + "/Rz_UploadFolders/" + FolderName + "/Publish/" + publish_name + "/LatestVersion.txt", FtpUserName, FtpPassword);
                    break;
                case UpdateType.ServerToWorkstation:
                    LatestInfo = Tools.Files.OpenFileAsString(RemotePath + "LatestVersion.txt");
                    break;
                default:
                    status = "Unknown update type.";
                    return false;
            }
            String strLatest = "";
            if (LatestInfo.StartsWith("LatestVersion"))
            {
                int length = 0;
                String[] ary = Tools.Strings.SplitLines(LatestInfo);
                foreach (String s in ary)
                {
                    if (s.StartsWith("Name:"))
                        strLatest = Path.GetFileNameWithoutExtension(Tools.Strings.ParseDelimit(s, ":", 2));
                    else if (s.StartsWith("Length:"))
                        length = Int32.Parse(Tools.Strings.ParseDelimit(s, ":", 2));
                }
                if (!Tools.Strings.StrExt(strLatest) || length == 0)
                {
                    status = "No version update is available.";
                    return false;
                }
                String CompletedVersions = "";
                switch (CurrentUpdateType)
                {
                    case UpdateType.WebToServer:
                        if (File.Exists(LocalPath + strLatest + ".zip"))
                        {
                            status = "This server already has the latest version; no update is needed [Ref: " + strLatest + "].";
                            return false;
                        }
                        break;
                    case UpdateType.ServerToWorkstation:
                    case UpdateType.WebToWorkstation:
                        {
                            //Kt craete the appdata folder if it doesn't exist.
                            System.IO.FileInfo file = new System.IO.FileInfo(LocalPath);
                            file.Directory.Create(); // If the directory already exists, this method does nothing.                            

                            if (!Tools.OperatingSystem.CheckReadWrite(LocalPath))
                            {
                                status = "This workstation's current setup apparently doesn't allow file changes in '" + LocalPath + "'. Before updating, please configure the permissions needed to add and change files in this folder.\r\nFor Vista workstations, this can often be done simply by turning off the User Account Control system.";
                                return false;
                            }
                            CompletedVersions = Tools.Files.OpenFileAsString(LocalPath + "InstalledVersions.txt");
                            if (Tools.Strings.HasString(CompletedVersions, "<" + strLatest + ">"))
                            {
                                status = "This workstation already has the latest version; no update is needed [Ref: " + strLatest + "].";
                                return false;
                            }
                            break;
                        }
                        
                }
            }
            else
            {
                status = "No version update is available.";
                return false;
            }
            status = "New version available [Ref: " + strLatest + "].";
            return v;
        }

        public bool NewVersionDownloaded(ref string status)
        {
            ArrayList a = VersionUpdate.GetVersions("Rz", "Rz4", LocalPath, "Rz4Loader.exe");
            foreach (Version v in a)
            {
                long versionNumber = v.VersionNumber;
                if (versionNumber > Tools.Misc.GetVersionNumber(Tools.ToolsNM.AssemblyNM))
                {
                    status = "New version downloaded and available: " + versionNumber.ToString();
                    return true;
                }
            }
            return false;
        }

        //Private Functions
        private void SetStatus(String s)
        {
            if (GotStatus != null)
                GotStatus(s);
        }
        private void SetProgress(int progress)
        {
            if (GotProgress != null)
                GotProgress(progress);
        }
        public bool CheckFileCreation(string path)
        {
            string f = Tools.Strings.GetNewID() + ".txt";
            Tools.Files.SaveFileAsString(path + f, "test");
            if (!Tools.Files.FileExists(path + f))
                return false;
            Tools.Files.TryDeleteFile(path + f);
            return true;
        }
        private bool CheckFolderCreation(string path)
        {
            string f = "test\\";
            Tools.Folder.MakeFolderExist(path + f);
            if (!Tools.Folder.FolderExists(path + f))
                return false;
            Tools.Folder.FolderObliterate(path + f);
            return true;
        }
        private bool DownloadNewVersionFtp(ContextNM context, String latest, String server, String publish_name)
        {
            String report = "";
            bool pass = true;
            String strLatest = "";
            int length = 0;

            String[] ary = Tools.Strings.SplitLines(latest);
            foreach (String s in ary)
            {
                if (s.StartsWith("Name:"))
                    strLatest = Path.GetFileNameWithoutExtension(Tools.Strings.ParseDelimit(s, ":", 2));
                else if (s.StartsWith("Length:"))
                    length = Int32.Parse(Tools.Strings.ParseDelimit(s, ":", 2));
            }
            if (!Tools.Strings.StrExt(strLatest) || length == 0)
            {
                SetStatus("No version update is available.");
                return false;
            }

            String CompletedVersions = "";
            switch (CurrentUpdateType)
            {
                case UpdateType.WebToServer:
                    if (File.Exists(LocalPath + strLatest + ".zip"))
                    {
                        SetStatus("This server already has the latest version; no update is needed [Ref: " + strLatest + "].");
                        return false;
                    }
                    break;
                case UpdateType.ServerToWorkstation:
                case UpdateType.WebToWorkstation:
                    if (!Tools.OperatingSystem.CheckReadWrite(LocalPath))
                    {
                        SetStatus("This workstation's current setup apparently doesn't allow file changes in '" + LocalPath + "'.  Before updating, please configure the permissions needed to add and change files in this folder.  For Vista workstations, this can often be done simply by turning off the User Account Control system.");
                        return false;
                    }
                    CompletedVersions = Tools.Files.OpenFileAsString(LocalPath + "InstalledVersions.txt");
                    if (Tools.Strings.HasString(CompletedVersions, "<" + strLatest + ">"))
                    {
                        SetStatus("This workstation already has the latest version; no update is needed [Ref: " + strLatest + "].");
                        return false;
                    }

                    //if( previous.Count == 0 && Tools.Folder.GetTopLevelFolderName(Tools.FileSystem.GetAppPath()).StartsWith("Rz3_") )
                    //    previous.Add( Version.FromFolder("Rz3.exe", Tools.Folder.ConditionFolderName(Tools.FileSystem.GetAppPath()), Tools.Folder.GetTopLevelFolderName(Tools.FileSystem.GetAppPath())));

                    break;
            }
            SetStatus("Downloading the latest version...");
            SetProgress(0);
            switch (CurrentUpdateType)
            {
                case UpdateType.WebToServer:
                case UpdateType.WebToWorkstation:

                    ftplib = new FTP(server, FtpUserName, FtpPassword);  //"www.recognin.com"
                    ftplib.Connect();

                    //AAAAAAA  this didn't have the Rz_UploadFolders part EITHER

                    SetStatus("Changing to Rz_UploadFolders/" + FolderName + "/Publish/" + publish_name);
                    ftplib.ChangeDir("Rz_UploadFolders");
                    ftplib.ChangeDir(FolderName);
                    ftplib.ChangeDir("Publish");
                    ftplib.ChangeDir(publish_name);
                    break;
            }
            String strFolder = "";
            String strLocal = "";
            switch (CurrentUpdateType)
            {
                case UpdateType.WebToServer:
                    strFolder = LocalPath;
                    strLocal = strFolder + strLatest + ".zip";

                    if (!Tools.Ftp.GetFileFTPDotNet("ftp://" + server + "/Rz_UploadFolders/" + FolderName + "/Publish/" + publish_name + "/" + strLatest + ".zip", strLocal, new FTPProgressHandler(SetProgress), null, FtpUserName, FtpPassword, length))
                    {
                        SetStatus("There was an error downloading the update.");
                        ftplib.Disconnect();
                        SetProgress(0);
                        try
                        {
                            if (File.Exists(strLocal))
                                File.Delete(strLocal);
                        }
                        catch { }
                        SetProgress(0);
                        return false;
                    }
                    Tools.Files.SaveFileAsString(strFolder + "LatestVersion.txt", latest);
                    SetProgress(100);
                    break;
                case UpdateType.ServerToWorkstation:
                case UpdateType.WebToWorkstation:

                    //2011_11_27  wtf?  system_name is not Rz4 for Rz4 companies
                    //strFolder = LocalPath + SysNewMethod.ContextDefault.xSys.system_name + "_" + strLatest + "\\";  //switched from Rz3 2011_06_05

                    //KT The Local Folder path that files get downloaded to:
                    strFolder = LocalPath + context.xSys.InstallFolderPrefix + "_" + strLatest + "\\";

                    //KT The Local file path that gets created
                    strLocal = strFolder + strLatest + ".zip";
                    Directory.CreateDirectory(strFolder);
                    if(!Directory.Exists(strFolder))
                        throw new Exception ("Directory not successfully created: "+ strFolder);

                    switch (CurrentUpdateType)
                    {
                        case UpdateType.WebToWorkstation:
                            if (!Tools.Ftp.GetFileFTP(ftplib, strLatest + ".zip", strLocal, new FTPProgressHandler(SetProgress), null))
                            {
                                SetStatus("There was an error downloading the update.");
                                SetProgress(0);
                                return false;
                            }
                            ftplib.Disconnect();
                            SetProgress(100);
                            break;
                        case UpdateType.ServerToWorkstation:
                            try
                            {
                                File.Copy(RemotePath + strLatest + ".zip", strLocal, false);
                            }
                            catch (Exception ex)
                            {
                                SetStatus("Copy error: " + ex.Message);
                                return false;
                            }
                            break;
                    }
                    SetStatus("Verifying...");
                    FileInfo fi = new FileInfo(strLocal);
                    if (fi.Length != length)
                    {
                        SetStatus("The update was downloaded, but the file could not be verified.  Please try again.");
                        try
                        {
                            if (File.Exists(strLocal))
                                File.Delete(strLocal);
                        }
                        catch { }
                        return false;
                    }

                    if (!UnzipAndImport(context, strLocal, strFolder, ref CompletedVersions, strLatest))
                        return false;

                    File.Delete(strLocal);  //this was in the UnzipAndImport logic before

                    break;
            }
            SetStatus("Done.");

            return true;
        }
        ArrayList PreviousGet()
        {
            ArrayList previous = VersionUpdate.GetVersions("Rz4", "Rz4", LocalPath, "Rz4Loader.exe");
            if (previous.Count == 0)
                previous = VersionUpdate.GetVersions("Rz3", "Rz3", LocalPath, "Rz3.exe");
            return previous;
        }
        public bool UnzipAndImport(ContextNM context, String strLocal, String strFolder, ref String CompletedVersions, String strLatest)
        {
            ArrayList previous = PreviousGet();  //this needs to be first, or it will pick up the unzipped version

            SetStatus("Unzipping the Update...");
            try
            {
                String err = "";
                if (!Tools.Zip.UnZipOneFile(strLocal, strFolder, ref err))
                {
                    SetStatus("Unzipping the update was not successful");
                    return false;
                }
            }
            catch (Exception ex)
            {
                context.TheLeader.Tell("Error: " + ex.Message);
                return false;
            }
            SetStatus("Unzip complete");


            if (previous.Count > 0)
            {
                Version pv = (Version)previous[previous.Count - 1];
                String[] livefiles = Directory.GetFiles(pv.FolderPath);
                String[] files = Directory.GetFiles(strFolder);

                foreach (String live in livefiles)
                {
                    switch (Path.GetFileName(live).ToLower())
                    {
                        case "installedversions.txt":
                        case "peak.exe":
                        case "systray.dll":
                        case "vbflash.ocx":
                            break;
                        default:
                            switch (Path.GetExtension(live).ToLower())
                            {
                                case ".dllz":
                                case ".exez":
                                case ".dll_new":
                                case ".xml_new":
                                    try
                                    {
                                        SetStatus("Removing " + live);
                                        File.Delete(live);
                                    }
                                    catch { }
                                    break;
                                case ".htm":
                                case ".html":
                                case ".zip":
                                    break;
                                default:
                                    bool exists = false;
                                    foreach (String file in files)
                                    {
                                        if (Tools.Strings.StrCmp(nTools.RemoveNumberedFileName(Path.GetFileName(file)), nTools.RemoveNumberedFileName(Path.GetFileName(live))))
                                        {
                                            exists = true;
                                            break;
                                        }
                                    }

                                    if (!exists)
                                    {
                                        try
                                        {
                                            File.Copy(live, strFolder + Path.GetFileName(live));
                                            SetStatus("Copied " + live);
                                        }
                                        catch (Exception ex)
                                        {
                                            SetStatus("Failed to copy " + live + ": " + ex.Message);
                                        }
                                    }
                                    break;
                            }
                            break;
                    }
                }
            }
            String strPeak = strFolder + "peak.exe";
            if (File.Exists(strPeak))
            {
                try
                {
                    if (File.Exists(LocalPath + "peak.exe"))
                        File.Delete(LocalPath + "peak.exe");
                    File.Copy(strPeak, LocalPath + "peak.exe");
                }
                catch (Exception peakex)
                {
                    SetStatus("Failed to update peak.exe: " + peakex.Message);
                }
                try
                {
                    if (Directory.Exists(LocalPath + "exec\\"))
                    {
                        if (File.Exists(LocalPath + "exec\\peak.exe"))
                            File.Delete(LocalPath + "exec\\peak.exe");
                        File.Copy(strPeak, LocalPath + "exec\\peak.exe");
                    }
                }
                catch (Exception peakex)
                {
                    SetStatus("Failed to update peak.exe: " + peakex.Message);
                }
                try
                {
                    File.Delete(strPeak);
                }
                catch { }
            }
            CompletedVersions += "\r\n<" + strLatest + "> on " + DateTime.Now.ToString();
            Tools.Files.SaveFileAsString(LocalPath + "InstalledVersions.txt", CompletedVersions);

            return true;
        }
    }

    public enum UpdateType
    {
        None = 0,
        WebToWorkstation = 1,
        WebToServer = 2,
        ServerToWorkstation = 3,
        DatabaseToWorkstation = 4,
    }
}
