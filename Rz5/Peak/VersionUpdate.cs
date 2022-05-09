using System;
using System.Collections;
using System.Text;
using System.IO;

// this file is duplicated in RzDutyService

namespace NewMethod
{
    public static class VersionUpdate
    {
        public static ArrayList GetVersions(String appName, String folderPrefix, String strRootFolder, bool include_missing_exe)
        {
            ArrayList ret = new ArrayList();

            try
            {
                //Version v = Version.FromFolder(strName + ".exe", strRootFolder, "Root", false);
                //if (v != null)
                //    ret.Add(v);

                //fix the folder name issue

                //if (DirectoryVisible(strRootFolder))
                //{
                //    foreach (String dir in Directory.GetDirectories(strRootFolder))
                //    {
                //        String name = Tools.Folder.GetTopLevelFolderName(dir).ToLower();
                //        if (name.StartsWith("rzctg_") || name.StartsWith("rzphoenix_") || name.StartsWith("rztjr_") || name.StartsWith("rzsensible_") || name.StartsWith("rzforte_") || name.StartsWith("rznec_"))
                //        {
                //            Directory.Move(dir, Tools.Folder.ConditionFolderName(Path.GetDirectoryName(dir)) + "Rz4_" + Tools.Strings.ParseDelimit(name, "_", 2));
                //        }
                //    }
                //System.Security.AccessControl.DirectorySecurity ds = Directory.GetAccessControl(strRootFolder);
                //Directory.GetAccessControl(strRootFolder);

                //check the subfolders of the parent folder
                //if (!strRootFolder.ToLower().Contains("(x86)"))
                //    strRootFolder += @" (x86)";

                //Instantiate the Version
                Version v = new Version();
                //Check if in debug
                bool isDebug = false;
                //isDebug = isDeBugEnv();
                if (isDebug)
                {
                    string path = @"C:\Eternal\RzWin\RzLoader\bin\Debug";


                    v = Version.FromFolder(appName + "Loader.exe", Tools.Folder.ConditionFolderName(path), Tools.Folder.GetTopLevelFolderName(path), include_missing_exe);
                    if (v != null)
                    {
                        ret.Add(v);
                        return ret;
                    }

                }
                else
                {
                    //set folder to \Sensibleimcro\Rz
                    string initialInstallPath = strRootFolder+ @"\Rz";
                    v = Version.FromFolder(appName + "Loader.exe", Tools.Folder.ConditionFolderName(initialInstallPath), Tools.Folder.GetTopLevelFolderName(initialInstallPath), include_missing_exe);
                    if (v != null)
                        ret.Add(v);

                    //Next loop through the folders @ \Sensibleimcro\Rz for newer versions
                    String[] dirs = Directory.GetDirectories(strRootFolder, folderPrefix + "_*");

                    foreach (String dir in dirs)
                    {

                        v = Version.FromFolder(appName + "Loader.exe", Tools.Folder.ConditionFolderName(dir), Tools.Folder.GetTopLevelFolderName(dir), include_missing_exe);
                        if (v != null)
                            ret.Add(v);
                        else
                        {
                            v = Version.FromFolder("RzLoader.exe", Tools.Folder.ConditionFolderName(dir), Tools.Folder.GetTopLevelFolderName(dir), include_missing_exe);
                            if (v != null)
                                ret.Add(v);
                        }
                    }
                }





                //If this is empty, Rz was not found.
                ret.Sort();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                //nStatus.TellUserTemp("Error getting the version list: " + ex.Message); 
            }
            return ret;
        }

        private static bool isDevMachine()
        {
            if (Environment.MachineName == "6WS9PV1")
                if (Directory.Exists(@"c:\Eternal\RzWin"))
                    return true;
            return false;
        }

        public static bool DirectoryVisible(string path)
        {
            try
            {
                Directory.GetAccessControl(path);
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static String InferLocalPath(String systemname)
        {
            String s = Tools.Folder.ConditionFolderName(Tools.Folder.GetAppPath());
            if (!Tools.Strings.StrCmp(Tools.Folder.GetTopLevelFolderName(s).Replace("2", "3"), Tools.Strings.ParseDelimit(systemname, "_", 1)))  //hack for rz2\exec folder
                s = Tools.Folder.ConditionFolderName(Tools.Folder.GetAppParentPath());

            return s;
        }
    }

    public class Version : IComparable
    {
        public String FolderPath = "";
        public String ExeName = "";
        public String VersionID = "";
        public DateTime VersionDate = Tools.Dates.GetNullDate();

        public void GrabDate()
        {
            try
            {
                FileInfo f = new FileInfo(FolderPath + ExeName);
                VersionDate = f.CreationTime;
                f = null;
            }
            catch
            {
                VersionDate = Tools.Dates.GetNullDate();
            }
        }

        public bool Exists
        {
            get
            {
                return File.Exists(FolderPath + ExeName);
            }
        }

        public int CompareTo(Object x)
        {
            try
            {
                Version v = (Version)x;
                return VersionDate.CompareTo(v.VersionDate);
            }
            catch
            {
                return 0;
            }
        }

        public long CalcSizeInMB()
        {
            try
            {
                long ret = 0;
                String[] files = Directory.GetFiles(FolderPath);
                foreach (String s in files)
                {
                    FileInfo f = new FileInfo(s);
                    ret += f.Length;
                    f = null;
                }
                return ret / (1024 * 1024);
            }
            catch
            {
                return 0;
            }
        }

        public static Version FromFolder(String strExeName, String strFolder, String strID, bool ignore_missing)
        {
            Version v = new Version();
            v.ExeName = strExeName;
            v.FolderPath = strFolder;
            v.VersionID = strID;

            if (!ignore_missing)
            {
                if (!v.Exists)
                    return null;

                v.GrabDate();
            }
            else
            {
                DirectoryInfo di = new DirectoryInfo(strFolder);
                v.VersionDate = di.CreationTime;
                di = null;
            }

            return v;
        }

        public bool Obliterate(StringBuilder sb)
        {
            try
            {
                return ObliterateFolder(FolderPath, sb);
            }
            catch
            {
                return false;
            }
        }

        bool ObliterateFolder(String strFolder, StringBuilder sb)
        {
            String[] dirs = Directory.GetDirectories(strFolder);
            foreach (String d in dirs)
            {
                ObliterateFolder(d, sb);
            }

            String[] files = Directory.GetFiles(strFolder);
            foreach (String f in files)
            {
                try
                {
                    switch (Path.GetExtension(f).ToLower())
                    {
                        case ".mdf":
                        case ".ldf":
                        case "mdf":
                        case "ldf":
                            sb.AppendLine("Skipping " + f + " in " + strFolder);
                            break;
                        default:
                            File.Delete(f);
                            sb.AppendLine("Deleted " + f + " from " + strFolder);
                            break;
                    }
                }
                catch (Exception fex)
                {
                    sb.AppendLine("Can't delete " + f + ": " + fex.Message);
                }
            }

            files = Directory.GetFiles(strFolder);
            if (files.Length == 0)
            {
                try
                {
                    Directory.Delete(strFolder);
                    sb.AppendLine("Deleted " + strFolder);
                }
                catch (Exception dex)
                {
                    sb.AppendLine("Can't delete " + strFolder + ": " + dex.Message);
                }
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("FolderPath: " + FolderPath);
            sb.AppendLine("ExeName: " + ExeName);
            sb.AppendLine("VersionID: " + VersionID);
            sb.AppendLine("VersionDate: " + VersionDate.ToString());
            return sb.ToString();
        }

    }
}
