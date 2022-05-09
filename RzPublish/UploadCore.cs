using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

using Tools;
using Core;
using NewMethod;
using Rz5;

namespace Rz5
{
    public class UploadCore
    {
        public static bool RunTests = true;
        public List<UploadFolder> FoldersList(ContextNM context)
        {
            List<UploadFolder> ret = new List<UploadFolder>();

            //UploadFolder sensible = new UploadFolder("Sensible", "Rz3_SensibleMicro", @"c:\Eternal\Code\", @"RzSensible\RzSensible.sln", @"c:\Eternal\Code\RzSensible\RzSensible.csproj", @"C:\Eternal\Code\RzSensible\bin\Release\", true, "sensible");
            //UploadFolder sensible = new UploadFolder("Sensible", "Rz3_SensibleMicro", @"c:\Eternal\RzWin\", @"RzSensible\RzSensible.sln", @"c:\Eternal\RzWin\RzSensible\RzSensible.csproj", @"C:\Eternal\RzWin\RzSensible\bin\Release\", true, "sensible");
            UploadFolder sensible = new UploadFolder("Sensible", "Rz3_SensibleMicro", @"c:\Eternal\RzWin\", @"RzWin.sln", @"c:\Eternal\RzWin\RzSensible\RzSensible.csproj", @"C:\Eternal\RzWin\RzSensible\bin\Release\", true, "sensible");


            sensible.FilesAddBaseNew();
            sensible.FilesAddSensibleDAL();
            sensible.FilesAddGoogleApis();
            sensible.FilesAddFonts();
            sensible.FilesAddHubspotApis();
            sensible.Files.Add(new UploadFile(sensible.Root + "bin\\Release\\", "Rz5.dll", sensible.Root + "Rz5\\Rz5.csproj"));
            //sensible.Files.Add(new UploadFile(sensible.Root + "RzSensible\\RzLoader\\bin\\Release\\", "RzInterfaceWin.dll", sensible.Root + "Rz5\\RzWin\\RzInterfaceWin.csproj"));
            sensible.Files.Add(new UploadFile(sensible.Root + "bin\\Release\\", "RzInterfaceWin.dll", sensible.Root + "RzInterfaceWin.csproj"));
            //sensible.Files.Add(new UploadFile(sensible.Root + "bin\\Release\\", "RzSensible.dll", sensible.Root + "RzSensible\\RzSensible.csproj"));
            //sensible.Files.Add(new UploadFile(sensible.Root + "bin\\Release\\", "RzSensibleWin.dll", sensible.Root + "RzSensible\\RzSensibleWin\\RzSensibleWin.csproj"));
            sensible.Files.Add(new UploadFile(sensible.Root + "RzLoader\\bin\\Release\\", "Rz4Loader.exe", sensible.Root + "RzSensible\\RzSensible\\RzLoader.csproj"));
            sensible.FilesAddSerilog();
            ret.Add(sensible);

            //UploadFolder sensibletest = new UploadFolder("SensibleTest", "Rz3_SensibleMicro", @"c:\Eternal\Code\", @"RzSensible\RzSensible.sln", @"c:\Eternal\Code\RzSensible\RzSensible.csproj", @"C:\Eternal\Code\RzSensible\bin\Release\", true, "sensibletest");
            UploadFolder sensibletest = new UploadFolder("SensibleTest", "Rz3_SensibleMicro", @"c:\Eternal\RzWin\", @"RzSensible\RzWin.sln", @"c:\Eternal\RzWin\RzSensible\RzSensible.csproj", @"C:\Eternal\RzWin\RzSensible\bin\Release\", true, "sensibletest");

            sensibletest.FilesAddBaseNew();
            sensibletest.FilesAddSensibleDAL();
            sensibletest.FilesAddGoogleApis();
            sensibletest.FilesAddFonts();
            sensibletest.FilesAddSerilog();
            sensibletest.FilesAddHubspotApis();
            sensibletest.Files.Add(new UploadFile(sensibletest.Root + "bin\\Release\\", "Rz5.dll", sensibletest.Root + "Rz5\\Rz5.csproj"));
            //sensibletest.Files.Add(new UploadFile(sensibletest.Root + "RzSensible\\RzLoader\\bin\\Release\\", "RzInterfaceWin.dll", sensibletest.Root + "Rz5\\RzWin\\RzInterfaceWin.csproj"));
            sensibletest.Files.Add(new UploadFile(sensibletest.Root + "bin\\Release\\", "RzInterfaceWin.dll", sensibletest.Root + "RzInterfaceWin.csproj"));
            //sensibletest.Files.Add(new UploadFile(sensibletest.Root + "bin\\Release\\", "RzSensible.dll", sensibletest.Root + "RzSensible\\RzSensible.csproj"));
            //sensibletest.Files.Add(new UploadFile(sensibletest.Root + "RzSensible\\RzSensibleWin\\bin\\Release\\", "RzSensibleWin.dll", sensible.Root + "RzSensible\\RzSensibleWin\\RzSensibleWin.csproj"));
            sensibletest.Files.Add(new UploadFile(sensibletest.Root + "\\RzLoader\\bin\\Release\\", "Rz4Loader.exe", sensibletest.Root + "RzSensible\\RzSensible\\RzLoader.csproj"));

            ret.Add(sensibletest);
            return ret;
        }

        private FTP ftplib;
        //public String FtpSite = "rzdist.sensiblemicro.com";
        //public String FtpUserName = "RzDist";
        //public String FtpPassword = "s3ns1bl3rZ";

        public bool Run(Context context, UploadFolder folder)
        {

            if (!IncrementAndBuild(context, folder))
                return false;
            if (folder.Testable && UploadCore.RunTests)
            {
                if (!TestSuccess((ContextRz)context, folder))
                    return false;
            }
            if (!Upload(context, folder))
                return false;
            return true;
        }
        private bool TestSuccess(ContextRz context, UploadFolder folder)
        {
            try
            {
                if (context == null)
                    return false;
                if (folder == null)
                    return false;
                string exe = "";
                foreach (UploadFile f in folder.Files)
                {
                    if (f.FileName.EndsWith(".exe"))
                    {
                        if (f.FileName.ToLower().StartsWith("peak"))
                            continue;
                        exe = f.FileName;
                        break;
                    }
                }
                if (!Tools.Strings.StrExt(exe))
                    return false;
                string path = Tools.Folder.ConditionFolderName(folder.BinPath) + exe;
                RemovePreviousLogs(folder);
                Tools.FileSystem.Shell(path, "-systemtest=" + context.Data.ServerName + "||" + context.Data.UserName + "||" + context.Data.UserPassword + "||" + folder.CompanyIdent + "Test||" + folder.CompanyIdent);
                bool success = false;
                while (true)
                {
                    System.Threading.Thread.Sleep(5000); //5 secs
                    string[] str = System.IO.Directory.GetFiles(Tools.Folder.ConditionFolderName(folder.BinPath), "*.success.txt");
                    if (str.Length > 0)
                    {
                        success = true;
                        break;
                    }
                    str = System.IO.Directory.GetFiles(Tools.Folder.ConditionFolderName(folder.BinPath), "*.fail.txt");
                    if (str.Length > 0)
                        break;
                }
                return success;
            }
            catch { }
            return false;
        }
        private void RemovePreviousLogs(UploadFolder folder)
        {
            try
            {
                string[] str = System.IO.Directory.GetFiles(Tools.Folder.ConditionFolderName(folder.BinPath), "*.success.txt");
                foreach (string s in str)
                {
                    Tools.Files.TryDeleteFile(s);
                }
            }
            catch { }
            try
            {
                string[] str = System.IO.Directory.GetFiles(Tools.Folder.ConditionFolderName(folder.BinPath), "*.fail.txt");
                foreach (string s in str)
                {
                    Tools.Files.TryDeleteFile(s);
                }
            }
            catch { }
        }
        public bool Upload(Context context, UploadFolder folder)
        {
            //for on-site
            //if (folder.Name == "CTG")
            //{
            //    String finalName = "";
            //    String uploadId = ZipEverything(context, folder, ref finalName);
            //    if (!Tools.Strings.StrExt(uploadId))
            //        return false;
            //    File.Copy(finalName, @"\\office.ctg\ctg\rz\Rz_Updates\" + Path.GetFileName(finalName));
            //    FileInfo fi = new FileInfo(finalName);
            //    String latest = LatestInfoCalc(folder, uploadId, fi);
            //    Tools.FileSystem.SaveFileAsString(@"\\office.ctg\ctg\rz\Rz_Updates\LatestVersion.txt", latest);
            //    context.TheLeader.ProgressUpdate(100);
            //    return true;
            //}

            ftplib = new FTP(UpdateDownloadCore.MainServer , UpdateDownloadCore.FtpUserName, UpdateDownloadCore.FtpPassword);
            try
            {
                ftplib.Connect();
            }
            catch (Exception ex)
            {
                context.TheLeader.Error("Connection Error: " + ex.Message);
                context.TheLeader.Tell("Connection Error: " + ex.Message);
                return false;
            }

            List<String> folders = new List<string>();
            folders.Add("Rz_UploadFolders");
            folders.Add("Rz4");
            //if (folder.Folder == "RzSensible")
            //    folders.Add("Rz3_SensibleMicro");
            //else
            //    folders.Add(folder.Folder);
            folders.Add("Publish");
            if (folder.Beta)
                folders.Add("beta");
            else if (folder.Test)
            {
                folders.Add("test");
            }
            else
                folders.Add("exec");

            foreach (String s in folders)
            {
                try { ftplib.MakeDir(s); }
                catch { }
                context.TheLeader.Comment("Switching to " + s);
                ftplib.ChangeDir(s);
            }

            try
            {
                ftplib.RemoveFile("LatestVersion.txt");
            }
            catch (Exception ex)
            {
                //context.Leader.Tell(ex.Message);
            }

            foreach (String file in ftplib.ListFileNames())
            {
                try
                {
                    context.TheLeader.CommentEllipse("Removing " + file);
                    ftplib.RemoveFile(file);
                }
                catch { }
            }
            try
            {
                UploadSingle(context, folder, ftplib);

                ftplib.Disconnect();
            }
            catch (Exception ex)
            {
                context.Leader.Tell(ex.Message);
                return false;
            }

            return true;
        }
        private void UploadSingle(Context context, UploadFolder folder, FTP ftplib)
        {
            String strFinalName = "";
            String strUploadID = ZipEverything(context, folder, ref strFinalName);
            if (!Tools.Strings.StrExt(strUploadID))
            {
                context.TheLeader.Error("Zip error");
                return;
            }

            String status = "";
            context.TheLeader.CommentEllipse("Sending " + strUploadID + ".zip");
            context.TheLeader.ProgressClear();
            progress_context = context;
            FTPProgressHandler h = new FTPProgressHandler(ActuallySetProgress);
            if (!ftplib.SendFile(strFinalName, ref status, h))
            {
                context.TheLeader.Error("Upload failed: " + status);
                context.TheLeader.ProgressClear();
                return;
            }

            ActuallySetProgress(100);
            h = null;
            FileInfo fi = new FileInfo(strFinalName);
            long remotelength = ftplib.GetFileSize(strUploadID + ".zip");
            if (remotelength != fi.Length)
            {
                context.TheLeader.Error("The remote file is " + remotelength.ToString() + " bytes, but the local file is " + fi.Length.ToString() + " bytes");
                return;
            }

            String LatestInfo = LatestInfoCalc(folder, strUploadID, fi);
            String strLi = "c:\\trash\\" + strUploadID + "\\LatestVersion.txt";
            Tools.Files.SaveFileAsString(strLi, LatestInfo);
            context.TheLeader.CommentEllipse("Uploading LatestVersion.txt");

            if (!ftplib.SendFile(strLi, ref status))
            {
                context.TheLeader.Error("Error uploading LatestVersion.txt: " + status);
                return;
            }

            try
            {
                String[] fil = Directory.GetFiles("c:\\trash\\" + strUploadID + "\\");
                foreach (String fi2 in fil)
                {
                    File.Delete(fi2);
                }
                Directory.Delete("c:\\trash\\" + strUploadID + "\\");

            }
            catch { }
            context.TheLeader.Comment("Done.");
        }
        String LatestInfoCalc(UploadFolder folder, String strUploadID, FileInfo fi)
        {
            String LatestInfo = "LatestVersion\r\nName:" + strUploadID + ".zip\r\nLength:" + fi.Length.ToString();
            foreach (UploadFile file in folder.Files)
            {
                String fn = Tools.Files.GetHighestFileName(file.FolderName, file.FileName);
                LatestInfo += "\r\nFile:" + fn;
                File.Delete("c:\\trash\\" + strUploadID + "\\" + fn);
            }
            return LatestInfo;
        }
        //for debugging files
        private String ZipEverything(Context context, UploadFolder folder, ref String strFinalName)
        {

            String strUploadID = DateTime.Now.Year.ToString() + Tools.Number.PadTwoDigits(DateTime.Now.Month.ToString()) + Tools.Number.PadTwoDigits(DateTime.Now.Day.ToString()) + Tools.Number.PadTwoDigits(DateTime.Now.Hour.ToString()) + Tools.Strings.GetNewID().Replace("-", "");
            String strFolder = "c:\\trash\\";
            if (!Directory.Exists(strFolder))
                Directory.CreateDirectory(strFolder);
            strFolder += strUploadID + "\\";
            if (!Directory.Exists(strFolder))
                Directory.CreateDirectory(strFolder);
            int i = -1;
            foreach (UploadFile file in folder.Files)
            {
                i++;
                if (Tools.Strings.StrCmp(file.FileName, "Rz4Loader.exe") && File.Exists(file.FolderName + Tools.Files.GetHighestFileName(file.FolderName, "RzLoader.exe")))
                {
                    if (File.Exists(file.FolderName + "Rz4Loader.exe"))
                        File.Delete(file.FolderName + "Rz4Loader.exe");

                    File.Copy(file.FolderName + "RzLoader.exe", file.FolderName + "Rz4Loader.exe");
                }

                String fn = Tools.Files.GetHighestFileName(file.FolderName, file.FileName);

                if (!File.Exists(file.FolderName + fn))
                {
                    context.TheLeader.Error("Error: File not found: " + file.FolderName + file.FileName);
                    return "";
                }

                context.TheLeader.Comment("Copying " + file.FileName);
                File.Copy(file.FolderName + fn, strFolder + fn);
            }

            strFinalName = "c:\\trash\\" + strUploadID + ".zip";
            context.TheLeader.CommentEllipse("Zipping");
            if (!Tools.Zip.ZipOneFolder(strFolder + "\\", "c:\\trash\\" + strUploadID + ".zip"))
            {
                context.TheLeader.Error("Zip failed.");
                return "";
            }

            return strUploadID;
        }
        Context progress_context;
        private void ActuallySetProgress(int i)
        {
            try
            {
                progress_context.TheLeader.ProgressUpdate(i);
            }
            catch { }
        }
        private void SendFile(ContextNM context, String strLocal, String strName)
        {
            ftplib.OpenUpload(strLocal, strName);
            context.TheLeader.CommentEllipse("Sending " + strLocal);

            int perc;
            while (ftplib.DoUpload() > 0)
            {
                perc = (int)(((ftplib.BytesTotal) * 100) / ftplib.FileSize);
                context.TheLeader.Comment("Upload: " + Tools.Number.LongFormat(ftplib.BytesTotal / 1024) + " / " + Tools.Number.LongFormat(ftplib.FileSize / 1024) + " ( " + perc.ToString() + "% )");
                context.TheLeader.ProgressUpdate(perc);
            }
        }
        public bool IncrementAndBuild(Context context, UploadFolder folder)
        {
            if (!Increment(context, folder))
                return false;
            string strConfig = "Release";
            string strBat = @"c:\Bilge\buildnm.bat";
            //string c = "cd C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\r\nMSBuild.exe " + folder.Root + folder.SolutionPath + " /p:Configuration=" + strConfig + " /p:Platform=\"Any CPU\"";  //roperty
            //string c = "cd C:\\Program Files (x86)\\MSBuild\\14.0\\Bin\\MSBuild.exe " + folder.Root + folder.SolutionPath + " /p:Configuration=" + strConfig + " /p:Platform=\"Any CPU\"";
            string c = @"C:\\Program Files(x86)\\MSBuild\\14.0\\Bin\\MSBuild.exe " + folder.Root + folder.SolutionPath + " /p:Configuration=" + strConfig + " /p:Platform=\"Any CPU\"";
            c += Environment.NewLine + @"cd c:\Bilge";
            //Tools.Files.SaveFileAsString(strBat, c);
            context.TheLeader.CommentEllipse("Building");
            string ret = "";
            if (!Tools.FileSystem.ShellAndViewOutput(strBat, "", ref ret, ""))
            {
                Tools.FileSystem.PopText(ret);
                return false;
            }
            if (Tools.Strings.HasString(ret, " 0 Error(s)"))
                return true;
            else
            {
                Tools.FileSystem.PopText(ret);
                return false;
            }
        }
        public bool Increment(Context context, UploadFolder folder)
        {
            int maj = 0;
            int min = 0;
            int rev = 0;
            int extra = 0;

            String ver = "";
            GetNMVersion(folder, ref maj, ref min, ref rev, ref extra, ref ver);

            String nmf = folder.Root + "NewMethod\\Properties\\AssemblyInfo.cs";
            //if( folder.NewMode )
            //    nmf = folder.Root + "NewMethod\\Properties\\AssemblyInfo.cs";

            if (!File.Exists(nmf))
                return false;

            String all = Tools.Files.OpenFileAsString(nmf);

            extra++;
            if (extra > 9)
            {
                extra = 0;
                rev++;
            }

            if (rev > 9)
            {
                rev = 0;
                min++;
            }

            if (min > 9)
            {
                min = 0;
                maj++;
            }

            String newver = maj.ToString() + "." + min.ToString() + "." + rev.ToString() + "." + extra.ToString();

            all = all.Replace("[assembly: AssemblyVersion(\"" + ver + "\")]", "[assembly: AssemblyVersion(\"" + newver + "\")]");
            all = all.Replace("[assembly: AssemblyFileVersion(\"" + ver + "\")]", "[assembly: AssemblyFileVersion(\"" + newver + "\")]");

            Tools.Files.SaveFileAsString(nmf, all);
            return true;
        }
        public void GetNMVersion(UploadFolder folder, ref int maj, ref int min, ref int rev, ref int extra, ref String ver)
        {
            String file = folder.Root + @"NewMethod\Properties\AssemblyInfo.cs";
            //if( folder.NewMode )
            //    file = folder.Root + @"NewMethod\Properties\AssemblyInfo.cs";

            if (!File.Exists(file))
                return;

            String all = Tools.Files.OpenFileAsString(file);

            ver = Tools.Strings.ParseDelimit(all, "[assembly: AssemblyVersion(\"", 2);
            ver = Tools.Strings.ParseDelimit(ver, "\"", 1);

            String[] nums = Tools.Strings.Split(ver, ".");
            maj = Int32.Parse(nums[0]);
            min = Int32.Parse(nums[1]);
            rev = Int32.Parse(nums[2]);
            extra = Int32.Parse(nums[3]);
        }
        //private List<UploadFile> RemoveOfficeInterop(UploadFolder f)
        //{
        //    List<UploadFile> l = new List<UploadFile>();
        //    foreach (UploadFile u in f.Files)
        //    {
        //        if (u.FileName == "OfficeInterop.dll")
        //            continue;
        //        l.Add(u);
        //    }
        //    return l;
        //}
    }
    public class UploadFolder
    {
        public String Name;
        public String Folder;
        public String Root;
        public String SolutionPath;
        public String TopProjectPath;
        public String BinPath;
        public String CompanyIdent = "";
        public List<UploadFile> Files = new List<UploadFile>();
        public bool Beta = false;
        public bool NewMode = false;
        public bool Testable = false;
        public bool Test = false;

        public UploadFolder(String name, String folder, String root, String solution_path, String top_project, String bin_path, bool testable, string ident)
        {
            Name = name;
            Folder = folder;
            Root = root;
            SolutionPath = solution_path;
            TopProjectPath = top_project;
            BinPath = bin_path;
            CompanyIdent = ident;
            Testable = testable;
        }
    
        public void FilesAddBaseNew()
        {
            NewMode = true;

            String SourceFolderName = "Release";
            //Core Rz Dependencies
            Files.Add(new UploadFile(Root + "Tools\\bin\\" + SourceFolderName + "\\", "Tools.dll", Root + "Tools\\Tools.csproj"));
            Files.Add(new UploadFile(Root + "Tools\\ToolsWin\\bin\\" + SourceFolderName + "\\", "ToolsWin.dll", Root + "Tools\\ToolsWin\\ToolsWin.csproj"));
            Files.Add(new UploadFile(Root + "NewMethod\\bin\\" + SourceFolderName + "\\", "NewMethod.dll", Root + "NewMethod\\NewMethod.csproj"));
            Files.Add(new UploadFile(Root + "NewMethod\\NewMethodWin\\bin\\" + SourceFolderName + "\\", "NewMethodWin.dll", Root + "NewMethod\\NewMethodWin\\NewMethodWin.csproj"));
            Files.Add(new UploadFile(Root + "Tie\\bin\\" + SourceFolderName + "\\", "Tie.dll", Root + "Tie\\Tie.csproj"));
            Files.Add(new UploadFile(Root + "Core\\bin\\" + SourceFolderName + "\\", "Core.dll", Root + "Core\\Core.csproj"));
            Files.Add(new UploadFile(Root + "Core\\CoreWin\\bin\\" + SourceFolderName + "\\", "CoreWin.dll", Root + "Core\\CoreWin\\CoreWin.csproj"));

            //Misc Existing DLLs            
            Files.Add(new UploadFile(Root + "dll\\", "AxInterop.SHDocVw.dll", ""));
            Files.Add(new UploadFile(Root + "dll\\", "Interop.SHDocVw.dll", ""));

            //PDF Generation - iText Sharp
            Files.Add(new UploadFile(Root + "dll\\", "itextsharp.dll", ""));
            //Quickbooks - actual file referenced in Rz Referecnex is Interop.QBFC13Lib.dll, this was probably never needed, not even a valid DLL to load. 
            //Files.Add(new UploadFile(Root + "bin\\", "QBFC13.dll", ""));
            //Zipping Library
            Files.Add(new UploadFile(Root + "dll\\", "ICSharpCode.SharpZipLib.dll", ""));
            //Bar Codes
            Files.Add(new UploadFile(Root + "dll\\", "BarcodeLib.dll", ""));
            ////KT 5-4-2016 MySql            
            //Files.Add(new UploadFile(Root + "dll\\", "MySql.Data.dll", ""));
            //KT 11-21-2019 - Somehow a newer version (8.0.18) of MySql is getting set, yet the fixed filed I keep in \dll is always 8.0.15
            //Changing path for this one so it will always publish what's being used in the debug environment.
            //Files.Add(new UploadFile("C:\\Eternal\\RzWin\\dll\\", "MySql.Data.dll", ""));
            Files.Add(new UploadFile(Root + "dll\\", "MySql.Data.dll", ""));

            //KT Office Interop:           
            Files.Add(new UploadFile(Root + "dll\\", "Interop.Outlook.dll", ""));
            Files.Add(new UploadFile(Root + "dll\\", "Interop.Word.dll", ""));

            //Excel / OpenXml
            Files.Add(new UploadFile(Root + "dll\\", "EPPlus.dll", ""));

            //Simple Impersonator
            //Files.Add(new UploadFile(Root + "dll\\", "SimpleImpersonation.dll", ""));

            //custom active directory impersonation.  Source:  https://ehikioya.com/active-directory-user-impersonation/
            // path to dev bin:  C:\Development\ad_impersonation\ad_impersonation\bin\Debug
            Files.Add(new UploadFile("C:\\Development\\ad_impersonation\\ad_impersonation\\bin\\Debug\\", "ad_impersonation.dll", ""));
            

        }


        internal void FilesAddGoogleApis()
        {

            Files.Add(new UploadFile("C:\\Eternal\\RzWin\\bin\\Release\\", "GmailAPI.dll", "C:\\Development\\GoogleApis\\GoogleApis\\GoogleApis.csproj"));
            Files.Add(new UploadFile("C:\\Eternal\\RzWin\\bin\\Release\\", "GmailAPI.pdb", "C:\\Development\\GoogleApis\\GoogleApis\\GoogleApis.csproj"));
            Files.Add(new UploadFile("C:\\Eternal\\RzWin\\bin\\Release\\", "Google.Apis.Gmail.v1.dll", "C:\\Development\\GoogleApis\\GoogleApis\\GoogleApis.csproj"));
            Files.Add(new UploadFile("C:\\Eternal\\RzWin\\bin\\Release\\", "Google.Apis.Gmail.v1.xml", "C:\\Development\\GoogleApis\\GoogleApis\\GoogleApis.csproj"));
            //Files.Add(new UploadFile("C:\\Eternal\\RzWin\\RzSensible\\bin\\Release\\", "client_secret.json", "C:\\Development\\GoogleApis\\GoogleApis\\GoogleApis.csproj"));
            Files.Add(new UploadFile("C:\\Eternal\\RzWin\\bin\\Release\\", "MimeKit.dll", "C:\\Development\\GoogleApis\\GoogleApis\\GoogleApis.csproj"));
            Files.Add(new UploadFile("C:\\Eternal\\RzWin\\bin\\Release\\", "MimeKit.xml", "C:\\Development\\GoogleApis\\GoogleApis\\GoogleApis.csproj"));
            Files.Add(new UploadFile("C:\\Eternal\\RzWin\\bin\\Release\\", "Google.Apis.Auth.dll", "C:\\Development\\GoogleApis\\GoogleApis\\GoogleApis.csproj"));
            Files.Add(new UploadFile("C:\\Eternal\\RzWin\\bin\\Release\\", "Google.Apis.Auth.xml", "C:\\Development\\GoogleApis\\GoogleApis\\GoogleApis.csproj"));
            Files.Add(new UploadFile("C:\\Eternal\\RzWin\\bin\\Release\\", "Google.Apis.dll", "C:\\Development\\GoogleApis\\GoogleApis\\GoogleApis.csproj"));
            Files.Add(new UploadFile("C:\\Eternal\\RzWin\\bin\\Release\\", "Google.Apis.xml", "C:\\Development\\GoogleApis\\GoogleApis\\GoogleApis.csproj"));
            Files.Add(new UploadFile("C:\\Eternal\\RzWin\\bin\\Release\\", "Google.Apis.Core.dll", "C:\\Development\\GoogleApis\\GoogleApis\\GoogleApis.csproj"));
            Files.Add(new UploadFile("C:\\Eternal\\RzWin\\bin\\Release\\", "Google.Apis.Core.xml", "C:\\Development\\GoogleApis\\GoogleApis\\GoogleApis.csproj"));
            Files.Add(new UploadFile("C:\\Eternal\\RzWin\\bin\\Release\\", "Newtonsoft.Json.dll", "C:\\Development\\GoogleApis\\GoogleApis\\GoogleApis.csproj"));
            Files.Add(new UploadFile("C:\\Eternal\\RzWin\\bin\\Release\\", "Newtonsoft.Json.xml", "C:\\Development\\GoogleApis\\GoogleApis\\GoogleApis.csproj"));
            Files.Add(new UploadFile("C:\\Eternal\\RzWin\\bin\\Release\\", "BouncyCastle.Crypto.dll", "C:\\Development\\GoogleApis\\GoogleApis\\GoogleApis.csproj"));

        }

        internal void FilesAddFonts()
        {

            Files.Add(new UploadFile("C:\\Eternal\\RzWin\\Rz5\\Fonts\\", "Montserrat-Bold.ttf", "")); //Hoping I don't need a "codefile" leaving last param blank.
            Files.Add(new UploadFile("C:\\Eternal\\RzWin\\Rz5\\Fonts\\", "Montserrat-Light.ttf", ""));
        }

        internal void FilesAddHubspotApis()
        {
            Files.Add(new UploadFile("C:\\Eternal\\RzWin\\Rz5\\bin\\Release\\", "HubspotApi.dll", "C:\\Development\\HubspotApi\\HubspotApi\\HubspotApi.csproj"));
            Files.Add(new UploadFile("C:\\Eternal\\RzWin\\Rz5\\bin\\Release\\", "HubspotApi.pdb", "C:\\Development\\HubspotApi\\HubspotApi\\HubspotApi.csproj"));

        }




        internal void FilesAddSensibleDAL()
        {
            Files.Add(new UploadFile("C:\\Eternal\\RzWin\\Rz5\\bin\\Release\\", "SensibleDAL.dll", "C:\\Development\\SensibleDAL\\SensibleDAL\\SensibleDAL.csproj"));
            Files.Add(new UploadFile("C:\\Eternal\\RzWin\\Rz5\\bin\\Release\\", "SensibleDAL.pdb", "C:\\Development\\SensibleDAL\\SensibleDAL\\SensibleDAL.csproj"));

        }

        internal void FilesAddSerilog()
        {
            //Serilog.dll
            //Serilog.Sinks.Console.dll
            //Serilog.Sinks.File.dll
            Files.Add(new UploadFile("C:\\Eternal\\RzWin\\Rz5\\bin\\Release\\", "Serilog.dll", ""));
            //Files.Add(new UploadFile("C:\\Eternal\\RzWin\\Rz5\\bin\\Release\\", "Serilog.Sinks.Console.dll", ""));
            //Files.Add(new UploadFile("C:\\Eternal\\RzWin\\Rz5\\bin\\Release\\", "Serilog.Sinks.File.dll", ""));
            Files.Add(new UploadFile("C:\\Eternal\\RzWin\\Rz5\\bin\\Release\\", "Serilog.Sinks.MSSqlServer.dll", ""));
            Files.Add(new UploadFile("C:\\Eternal\\RzWin\\Rz5\\bin\\Release\\", "Serilog.Sinks.PeriodicBatching.dll", ""));
        }
    }
    public class UploadFile
    {
        public String FolderName = "";
        public String FileName = "";
        public String CodeFile = "";
        public bool HasNewFile = false;

        public UploadFile(String strFolder, String strFile, String strCodeFile)
        {
            FolderName = strFolder;
            FileName = strFile;
            CodeFile = strCodeFile;
        }
    }
}
