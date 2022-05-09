using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;

namespace Tools
{
    public partial class Folder
    {
        //Public Static Functions
        public static String ConditionFolderName(String s)
        {
            return Tools.FileSystem.ConditionFolderName(s);
        }
        public static String FilterPath(String s)
        {
            return s.Replace("|", "\\");
        }
        public static String GetTopLevelFolderName(String s)
        {
            String[] ary = Tools.Strings.Split(s, "\\");
            if (s.EndsWith("\\"))
                return ary[ary.Length - 2];
            else
                return ary[ary.Length - 1];
        }
        public static String GetFolderName(String strFilePath)
        {
            try
            {
                Int32 i = strFilePath.LastIndexOf("\\");
                return Folder.ConditionFolderName(Tools.Strings.Left(strFilePath, i)).Trim();
            }
            catch { return ""; }
        }

        public static String GetParentFolder(String path)
        {
            path = path.Trim();
            if (path.EndsWith(@"\"))
                path = path.Substring(0, path.Length - 1);
            return ConditionFolderName(Directory.GetParent(path).FullName);
        }

        public static void MakeFolderExist(String f)
        {
            try
            {
                System.IO.Directory.CreateDirectory(f);
            }
            catch (Exception e)
            {
            }
        }
        public static string[] GetFolders(String strPath)
        {
            return System.IO.Directory.GetDirectories(strPath);
        }
        public static string[] GetFolders(String strPath, String strSearchPattern)
        {
            return System.IO.Directory.GetDirectories(strPath, strSearchPattern);
        }
        public static string[] GetFolders(String strPath, String strSearchPattern, SearchOption so)
        {
            return System.IO.Directory.GetDirectories(strPath, strSearchPattern, so);
        }
        public static string GetNowPath()
        {
            String s = DateTime.Now.Year.ToString() + "_";
            if (DateTime.Now.Month <= 9)
                s += "0" + DateTime.Now.Month.ToString();
            else
                s += DateTime.Now.Month.ToString();
            s += "_";
            if (DateTime.Now.Day <= 9)
                s += "0" + DateTime.Now.Day.ToString();
            else
                s += DateTime.Now.Day.ToString();

            return s;
        }
        public static string GetNowPathPlusTime()
        {
            return GetNowPath() + "_" + Tools.Strings.Right("0" + DateTime.Now.Hour.ToString(), 2) + "_" + Tools.Strings.Right("0" + DateTime.Now.Minute.ToString(), 2) + "_" + Tools.Strings.Right("0" + DateTime.Now.Second.ToString(), 2) + "_" + Tools.Strings.Right("000" + DateTime.Now.Millisecond.ToString(), 4);
        }
        public static String GetDriveLetter()
        {
            return Tools.Strings.ParseDelimit(GetAppPath(), "\\", 1).Replace(":", "");
        }
        public static String GetAppPath()
        {
            return Tools.FileSystem.GetAppPath();
        }
        public static void TryUnlockFolder(String strFolder)
        {
            Tools.FileSystem.ExploreFolder(strFolder);
            //Tools.FilesShell("explorer", strFolder);
            //return;
        }
        public static bool FolderExists(string folder)
        {
            return Directory.Exists(folder);
        }
        public static bool ExploreFolder(String strFolder)
        {
            return Tools.FileSystem.ExploreFolder(strFolder);
            //try
            //{
            //    String ex = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.System)) + "explorer";
            //    System.Diagnostics.Process x = new System.Diagnostics.Process();
            //    x.StartInfo.FileName = strFolder;
            //    x.StartInfo.Arguments = "";
            //    x.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            //    x.StartInfo.UseShellExecute = true;
            //    x.Start();
            //    return true;
            //}
            //catch (Exception)
            //{
            //    return false;
            //}
        }
        public static bool SoftUpdateFolder(String strSource, String strDest)
        {
            String[] files = Directory.GetFiles(strSource);
            foreach (String file in files)
            {
                try
                {
                    String df = Folder.ConditionFolderName(strDest) + Path.GetFileName(file);
                    if (!File.Exists(df))
                        File.Copy(file, df);
                }
                catch
                {
                    return false;
                }
            }
            String[] dirs = Directory.GetDirectories(strSource);
            foreach (String dir in dirs)
            {
                try
                {
                    String dd = Folder.ConditionFolderName(strDest) + GetTopLevelFolderName(dir);
                    if (!Directory.Exists(dd))
                        Directory.CreateDirectory(dd);
                    if (!SoftUpdateFolder(dir, dd))
                        return false;
                }
                catch
                {
                }
            }
            return true;
        }
        public static ArrayList GetFileCollection(String strFolder, String strSearchPattern)
        {
            ArrayList r = new ArrayList();
            String[] s = System.IO.Directory.GetFiles(strFolder, strSearchPattern);
            foreach (String x in s)
            {
                r.Add(x);
            }
            return r;
        }
        public static bool FolderObliterate(String folder)
        {
            bool ret = true;
            foreach (String dir in Directory.GetDirectories(folder))
            {
                if (!FolderObliterate(dir))
                    ret = false;
                try
                {
                    Directory.Delete(dir);
                }
                catch { ret = false; }
            }

            foreach (String file in Directory.GetFiles(folder))
            {
                try
                {
                    File.Delete(file);
                }
                catch { ret = false; }
            }

            return ret;
        }

        public static bool Copy(String from, String to)
        {
            foreach (String file in Directory.GetFiles(from))
            {
                try
                {
                    File.Copy(Tools.Folder.ConditionFolderName(from) + Path.GetFileName(file), Tools.Folder.ConditionFolderName(to) + Path.GetFileName(file));
                }
                catch { return false; }
            }

            foreach (String dir in Directory.GetDirectories(from))
            {
                String to_sub = Tools.Folder.ConditionFolderName(to) + Tools.Folder.GetTopLevelFolderName(dir) + @"\";

                if (!Directory.Exists(to_sub))
                    Directory.CreateDirectory(to_sub);

                if (!Copy(dir, to_sub))
                    return false;
            }

            return true;
        }

        public static bool DeleteOldFilesRecurse(String folder, DateTime cutoff)
        {
            foreach (String file in Directory.GetFiles(folder))
            {
                try
                {
                    FileInfo f = new FileInfo(file);
                    if (f.CreationTime < cutoff)
                        File.Delete(file);
                }
                catch { return false; }
            }

            foreach (String dir in Directory.GetDirectories(folder))
            {
                if (!DeleteOldFilesRecurse(dir, cutoff))
                    return false;
            }

            return true;
        }

        public static void OpenUNCShare(String share, String user, String password)
        {
            ExtremeMirror.PinvokeWindowsNetworking.connectToRemote(share, user, password);
        }
    }
}

namespace ExtremeMirror
{
	public class PinvokeWindowsNetworking
	{
		#region Consts
		const int RESOURCE_CONNECTED = 0x00000001;
		const int RESOURCE_GLOBALNET = 0x00000002;
		const int RESOURCE_REMEMBERED = 0x00000003;

		const int RESOURCETYPE_ANY = 0x00000000;
		const int RESOURCETYPE_DISK = 0x00000001;
		const int RESOURCETYPE_PRINT = 0x00000002;

		const int RESOURCEDISPLAYTYPE_GENERIC = 0x00000000;
		const int RESOURCEDISPLAYTYPE_DOMAIN = 0x00000001;
		const int RESOURCEDISPLAYTYPE_SERVER = 0x00000002;
		const int RESOURCEDISPLAYTYPE_SHARE = 0x00000003;
		const int RESOURCEDISPLAYTYPE_FILE = 0x00000004;
		const int RESOURCEDISPLAYTYPE_GROUP = 0x00000005;

		const int RESOURCEUSAGE_CONNECTABLE = 0x00000001;
		const int RESOURCEUSAGE_CONTAINER = 0x00000002;


		const int CONNECT_INTERACTIVE = 0x00000008;
		const int CONNECT_PROMPT = 0x00000010;
		const int CONNECT_REDIRECT = 0x00000080;
		const int CONNECT_UPDATE_PROFILE = 0x00000001;
		const int CONNECT_COMMANDLINE = 0x00000800;
		const int CONNECT_CMD_SAVECRED = 0x00001000;

		const int CONNECT_LOCALDRIVE = 0x00000100;
		#endregion

		#region Errors
		const int NO_ERROR = 0;

		const int ERROR_ACCESS_DENIED = 5;
		const int ERROR_ALREADY_ASSIGNED = 85;
		const int ERROR_BAD_DEVICE = 1200;
		const int ERROR_BAD_NET_NAME = 67;
		const int ERROR_BAD_PROVIDER = 1204;
		const int ERROR_CANCELLED = 1223;
		const int ERROR_EXTENDED_ERROR = 1208;
		const int ERROR_INVALID_ADDRESS = 487;
		const int ERROR_INVALID_PARAMETER = 87;
		const int ERROR_INVALID_PASSWORD = 1216;
		const int ERROR_MORE_DATA = 234;
		const int ERROR_NO_MORE_ITEMS = 259;
		const int ERROR_NO_NET_OR_BAD_PATH = 1203;
		const int ERROR_NO_NETWORK = 1222;

		const int ERROR_BAD_PROFILE = 1206;
		const int ERROR_CANNOT_OPEN_PROFILE = 1205;
		const int ERROR_DEVICE_IN_USE = 2404;
		const int ERROR_NOT_CONNECTED = 2250;
		const int ERROR_OPEN_FILES  = 2401;

		private struct ErrorClass 
		{
			public int num;
			public string message;
			public ErrorClass(int num, string message) 
			{
				this.num = num;
				this.message = message;
			}
		}


		// Created with excel formula:
		// ="new ErrorClass("&A1&", """&PROPER(SUBSTITUTE(MID(A1,7,LEN(A1)-6), "_", " "))&"""), "
		private static ErrorClass[] ERROR_LIST = new ErrorClass[] {
			new ErrorClass(ERROR_ACCESS_DENIED, "Error: Access Denied"), 
			new ErrorClass(ERROR_ALREADY_ASSIGNED, "Error: Already Assigned"), 
			new ErrorClass(ERROR_BAD_DEVICE, "Error: Bad Device"), 
			new ErrorClass(ERROR_BAD_NET_NAME, "Error: Bad Net Name"), 
			new ErrorClass(ERROR_BAD_PROVIDER, "Error: Bad Provider"), 
			new ErrorClass(ERROR_CANCELLED, "Error: Cancelled"), 
			new ErrorClass(ERROR_EXTENDED_ERROR, "Error: Extended Error"), 
			new ErrorClass(ERROR_INVALID_ADDRESS, "Error: Invalid Address"), 
			new ErrorClass(ERROR_INVALID_PARAMETER, "Error: Invalid Parameter"), 
			new ErrorClass(ERROR_INVALID_PASSWORD, "Error: Invalid Password"), 
			new ErrorClass(ERROR_MORE_DATA, "Error: More Data"), 
			new ErrorClass(ERROR_NO_MORE_ITEMS, "Error: No More Items"), 
			new ErrorClass(ERROR_NO_NET_OR_BAD_PATH, "Error: No Net Or Bad Path"), 
			new ErrorClass(ERROR_NO_NETWORK, "Error: No Network"), 
			new ErrorClass(ERROR_BAD_PROFILE, "Error: Bad Profile"), 
			new ErrorClass(ERROR_CANNOT_OPEN_PROFILE, "Error: Cannot Open Profile"), 
			new ErrorClass(ERROR_DEVICE_IN_USE, "Error: Device In Use"), 
			new ErrorClass(ERROR_EXTENDED_ERROR, "Error: Extended Error"), 
			new ErrorClass(ERROR_NOT_CONNECTED, "Error: Not Connected"), 
			new ErrorClass(ERROR_OPEN_FILES, "Error: Open Files"), 
		};

		private static string getErrorForNumber(int errNum) 
		{
			foreach (ErrorClass er in ERROR_LIST) 
			{
				if (er.num == errNum) return er.message;
			}
			return "Error: Unknown, " + errNum;
		}
		#endregion

		[DllImport("Mpr.dll")] private static extern int WNetUseConnection(
			IntPtr hwndOwner,
			NETRESOURCE lpNetResource,
			string lpPassword,
			string lpUserID,
			int dwFlags,
			string lpAccessName,
			string lpBufferSize,
			string lpResult
		);

		[DllImport("Mpr.dll")] private static extern int WNetCancelConnection2(
			string lpName,
			int dwFlags,
			bool fForce
		);

		[StructLayout(LayoutKind.Sequential)] private class NETRESOURCE
		{ 
			public int dwScope = 0;
			public int dwType = 0;
			public int dwDisplayType = 0;
			public int dwUsage = 0;
			public string lpLocalName = "";
			public string lpRemoteName = "";
			public string lpComment = "";
			public string lpProvider = "";
		}


		public static string connectToRemote(string remoteUNC, string username, string password) 
		{
			return connectToRemote(remoteUNC, username, password, false);
		}

		public static string connectToRemote(string remoteUNC, string username, string password, bool promptUser) 
		{
			NETRESOURCE nr = new NETRESOURCE();
			nr.dwType = RESOURCETYPE_DISK;
			nr.lpRemoteName = remoteUNC;
			//			nr.lpLocalName = "F:";

			int ret;
			if (promptUser) 
				ret = WNetUseConnection(IntPtr.Zero, nr, "", "", CONNECT_INTERACTIVE | CONNECT_PROMPT, null, null, null);
			else 
				ret = WNetUseConnection(IntPtr.Zero, nr, password, username, 0, null, null, null);

			if (ret == NO_ERROR) return null;
			return getErrorForNumber(ret);
		}

		public static string disconnectRemote(string remoteUNC) 
		{
			int ret = WNetCancelConnection2(remoteUNC, CONNECT_UPDATE_PROFILE, false);
			if (ret == NO_ERROR) return null;
			return getErrorForNumber(ret);
		}
	}
}
