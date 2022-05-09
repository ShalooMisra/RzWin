using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace NewMethod
{
    public static class VersionUpdate
    {
        public static ArrayList GetVersions(String appName, String folderPrefix, String strRootFolder, String exeName)
        {
            ArrayList ret = new ArrayList();

            try
            {
                //Version v = Version.FromFolder(strName + ".exe", strRootFolder, "Root", false);
                //if (v != null)
                //    ret.Add(v);

                //check the subfolders of the parent folder
                String[] dirs = Directory.GetDirectories(strRootFolder, folderPrefix + "_*");

                foreach (String dir in dirs)
                {
                    Version v = Version.FromFolder(exeName, nTools.ConditionFolderName(dir), nTools.GetTopLevelFolderName(dir));
                    if (v != null)
                        ret.Add(v);
                }

                //if (Directory.Exists(strRootFolder + "exec\\"))
                //{
                //    Version v = Version.FromFolder(strName + ".exe", strRootFolder + "exec\\", "RootExec", false);
                //    if (v != null)
                //        ret.Add(v);
                //}

                ret.Sort();
            }
            catch
            {
                //nStatus.TellUserTemp("Error getting the version list: " + ex.Message); 
            }
            return ret;
        }

        //public static ArrayList GetVersions(String strName, String strRootFolder)
        //{
        //    ArrayList ret = new ArrayList();

        //    try
        //    {
        //        Version v = Version.FromFolder(strName + ".exe", strRootFolder, "Root");
        //        if (v != null)
        //            ret.Add(v);

        //        //check the subfolders of the parent folder
        //        String[] dirs = Directory.GetDirectories(strRootFolder, strName + "_*");

        //        foreach (String dir in dirs)
        //        {
        //            v = Version.FromFolder(strName + ".exe", Tools.Folder.ConditionFolderName(dir), Tools.Folder.GetTopLevelFolderName(dir));
        //            if (v != null)
        //                ret.Add(v);
        //        }

        //        if (Directory.Exists(strRootFolder + "exec\\"))
        //        {
        //            v = Version.FromFolder(strName + ".exe", strRootFolder + "exec\\", "RootExec");
        //            if (v != null)
        //                ret.Add(v);
        //        }

        //        ret.Sort();
        //    }
        //    catch (Exception ex) { context.TheLeader.Tell("Error getting the version list: " + ex.Message); }
        //    return ret;
        //}

        public static String InferLocalPath(String systemname)
        {
            String s = Tools.Folder.ConditionFolderName(Tools.FileSystem.GetAppPath());
            if (!Tools.Strings.StrCmp(Tools.Folder.GetTopLevelFolderName(s).Replace("2", "3"), Tools.Strings.ParseDelimit(systemname, "_", 1)))  //hack for rz2\exec folder
                s = Tools.Folder.ConditionFolderName(nTools.GetAppParentPath());

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

        public static Version FromFolder(String strExeName, String strFolder, String strID)
        {
            Version v = new Version();
            v.ExeName = nTools.GetHighestFileName(strFolder, strExeName);
            v.FolderPath = strFolder;

            if (!v.Exists)
                return null;

            v.VersionID = strID;
            v.GrabDate();
            return v;
        }

        public long VersionNumber
        {
            get
            {
                if (!File.Exists(FolderPath + ExeName))
                    return 0;

                FileVersionInfo info = FileVersionInfo.GetVersionInfo(FolderPath + "NewMethod.dll");
                return Tools.Misc.GetVersionNumber(info.FileMajorPart, info.FileMinorPart, info.FileBuildPart, info.FilePrivatePart);
            }
        }
    }
}
