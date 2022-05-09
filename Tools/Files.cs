using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Reflection;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;
using System.Drawing;
using System.Xml;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Tools
{
    public partial class Files
    {
        public static String FilterFileNameTrash(String s)
        {
            return Tools.Strings.BulkReplace(s, Tools.Strings.GetTrashKeys());
        }
        public static String RelativeToAbsolute(String strRelative, String strFolder)
        {
            //..\..\Rz3_Common.csproj
            String[] aryFile = Tools.Strings.Split(strRelative, Path.DirectorySeparatorChar.ToString());
            int up = 0;
            String strFile = "";
            foreach (String s in aryFile)
            {
                if (s == "..")
                    up++;
                else
                    strFile += Path.DirectorySeparatorChar.ToString() + s;
            }
            String strf = strFolder;
            for (int j = 0; j < up; j++)
            {
                strf = Path.GetDirectoryName(strf);
            }
            if (strFile.StartsWith(Path.DirectorySeparatorChar.ToString()))
                strFile = Tools.Strings.Mid(strFile, 2);
            return Tools.Folder.ConditionFolderName(strf) + strFile;
        }
        public static String AbsoluteToRelative(String strFile, String strFolder)
        {
            String sf1 = Tools.Folder.ConditionFolderName(Path.GetDirectoryName(strFile));
            String sf2 = Tools.Folder.ConditionFolderName(strFolder);
            String[] a1 = Tools.Strings.Split(sf1, Path.DirectorySeparatorChar.ToString());
            String[] a2 = Tools.Strings.Split(sf2, Path.DirectorySeparatorChar.ToString());
            //get the common folders out of the way
            int i = a1.Length;
            if (a2.Length > i)
                i = a2.Length;
            ArrayList ar1 = new ArrayList();
            ArrayList ar2 = new ArrayList();
            bool same = true;
            for (int j = 0; j < i; j++)
            {
                String s1 = "";
                String s2 = "";
                if (!same || !Tools.Strings.StrCmp(a1[j], a2[j]))
                {
                    if (j < a1.Length)
                        s1 = a1[j];
                    if (Tools.Strings.StrExt(s1))
                        ar1.Add(s1);
                    if (j < a2.Length)
                        s2 = a2[j];
                    if (Tools.Strings.StrExt(s2))
                        ar2.Add(s2);
                    same = false;
                }
            }
            //a1 might be deeper than a2
            //  folder2\folder3\file.x
            //  folder5\<original>
            //back up as far as needed to get out of the original
            int back = ar2.Count;
            String strRet = "";
            for (int b = 0; b < back; b++)
            {
                strRet += ".." + Path.DirectorySeparatorChar.ToString();
            }
            //append what's left
            foreach (String s in ar1)
            {
                strRet += s + Path.DirectorySeparatorChar.ToString();
            }
            if (Tools.Strings.StrExt(strRet))
                strRet = Tools.Folder.ConditionFolderName(strRet);
            return strRet + Path.GetFileName(strFile);
        }

        public static String TranslateFileName(String f)
        {
            String r = f.Replace("|desktop|", Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)));
            r = r.Replace("|my_documents|", Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)));
            r = r.Replace("|my_music|", Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic)));
            r = r.Replace("|my_pictures|", Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)));
            r = r.Replace("|root_folder|", Tools.Folder.ConditionFolderName(Path.GetPathRoot(Tools.FileSystem.GetAppPath())));
            return r;
        }

        public static bool BinCpy(String strOriginal, String strNew)
        {
            try
            {
                FileInfo f = new FileInfo(strOriginal);
                BinaryWriter w = new BinaryWriter(new FileStream(strNew, FileMode.CreateNew, FileAccess.Write));
                BinaryReader r = new BinaryReader(new FileStream(strOriginal, FileMode.Open, FileAccess.Read));
                w.Write(r.ReadBytes(Convert.ToInt32(f.Length)));
                r.Close();
                r = null;
                w.Close();
                w = null;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static String GetFileNameNoExtention(String strFilePath)
        {
            try
            {
                Int32 i = strFilePath.LastIndexOf(".");
                String ss = Tools.Strings.Left(strFilePath, i);
                i = ss.LastIndexOf("\\") + 1;
                return Tools.Strings.Right(ss, ss.Length - i);
            }
            catch { return ""; }
        }

        public static bool SaveStringAsFile(String file_name, String data)
        {
            return SaveStringAsFile(file_name, data, false);
        }

        public static bool SaveStringAsFile(String file_name, String data, bool create_dir)
        {
            try
            {
                String folder = Path.GetDirectoryName(file_name);
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);


                System.IO.StreamWriter file = new System.IO.StreamWriter(file_name, false);
                file.Write(data);
                file.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool SaveFileAsString(String strFileName, String strData)
        {
            return Tools.FileSystem.SaveFileAsString(strFileName, strData);
        }
        public static bool CreateFileFromArrayList(String strFileName, ArrayList strData)
        {
            return Tools.FileSystem.CreateFileFromArrayList(strFileName, strData);
        }
        public static String OpenFileAsString(String strFile)
        {
            return Tools.FileSystem.OpenFileAsString(strFile);
        }

        public static bool HasFileName(String s)
        {
            return Tools.Strings.StrExt(System.IO.Path.GetFileName(s));
        }

        public static SortedList GetHighestFileCollection(String strFolder)
        {
            SortedList hold = new SortedList();
            if (!System.IO.Directory.Exists(strFolder))
                return hold;
            String strBase;
            NumberedFile nf;
            Int64 num;
            String[] files = System.IO.Directory.GetFiles(strFolder);
            foreach (String f in files)
            {
                String fl = System.IO.Path.GetFileName(f);
                strBase = Files.RemoveNumberedFileName(fl);
                num = GetFileNumber(fl);
                nf = (NumberedFile)hold[strBase.ToLower()];
                if (nf == null)
                {
                    nf = new NumberedFile();
                    nf.FileBase = strBase;
                    nf.FilePath = fl;
                    nf.HighestNumber = num;
                    hold.Add(nf.FileBase.ToLower(), nf);
                }
                else
                {
                    if (num > nf.HighestNumber)
                    {
                        nf.FilePath = fl;
                    }
                }
            }
            return hold;
        }
        public static String RemoveNumberedFileName(String strFile)
        {
            int mark;
            mark = strFile.IndexOf("__");
            if (mark >= 0)
                return Tools.Strings.Left(strFile, mark) + Path.GetExtension(strFile);
            else
                return strFile;
        }
        public static Int64 GetHighestFileNumber(String[] files, String strBaseName, ref String strActualName)
        {
            Int64 h = -1;
            String sh = "";
            foreach (String s in files)
            {
                String b = Files.RemoveNumberedFileName(System.IO.Path.GetFileName(s));
                if (Tools.Strings.StrCmp(b, strBaseName))
                {
                    Int64 v = GetFileNumber(s);
                    if (v > h)
                    {
                        h = v;
                        sh = s;
                    }
                }
            }
            strActualName = sh;
            return h;
        }
        public static String GetHighestFileName(String strFolder, String strBaseName)
        {
            String s = "";
            GetHighestFileNumber(strFolder, strBaseName, ref s);
            return s;
        }
        public static Int64 GetHighestFileNumber(String strFolder, String strBaseName)
        {
            String s = "";
            return GetHighestFileNumber(strFolder, strBaseName, ref s);
        }
        public static Int64 GetHighestFileNumber(String strFolder, String strBaseName, ref String strActualName)
        {
            String strBase;
            String strExt;
            String strHighest = "";
            strBase = Path.GetFileNameWithoutExtension(strBaseName);
            strExt = Path.GetExtension(strBaseName);
            if (strBase.IndexOf("__") > 0)
                strBase = Tools.Strings.ParseDelimit(strBase, "__", 1);
            //strActualName = "";
            Int64 highest = -1;
            Int64 number = 0;
            if (!System.IO.Directory.Exists(strFolder))
                return -1;
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(strFolder);
            System.IO.FileInfo[] files = di.GetFiles();
            String strName;
            for (int i = 0; i < files.Length; i++)
            {
                strName = files[i].Name;
                if ((strName.ToLower().StartsWith(strBase.ToLower() + "__") && strName.ToLower().EndsWith(strExt.ToLower())) || Tools.Strings.StrCmp(strName, strBase + strExt))
                {
                    number = GetFileNumber(strName);
                    if (number > highest)
                    {
                        highest = number;
                        strHighest = strName;
                    }
                }
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("Highest = ");
            sb.Append(highest);
            if (strActualName != null)
                strActualName = strHighest;
            return highest;
        }
        public static Int64 GetFileNumber(String strFileName)
        {
            String strBase = Path.GetFileNameWithoutExtension(strFileName);
            if (strBase.IndexOf("__") < 0)
                return 0;
            strBase = Tools.Strings.ParseDelimit(strBase, "__", 2);
            try
            {
                return System.Convert.ToInt64(strBase);
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        public static String GetFileName(String fullpath)
        {
            try
            {
                String[] hold = Tools.Strings.Split(fullpath, "\\");
                Int32 i = hold.Length - 1;
                return hold[i].Trim();
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static String GetFileExtention(String file)
        {
            try
            {
                String[] hold = Tools.Strings.Split(file, ".");
                Int32 i = hold.Length - 1;
                return hold[i].Trim();
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static String InsertNumberedFileName(String strName, Int64 num)
        {
            String strFile = Tools.Strings.Right(String.Concat("0000000", num.ToString()), 7);
            strFile = String.Concat(Path.GetFileNameWithoutExtension(strName), "__", strFile, Path.GetExtension(strName));
            return strFile;
        }
        public static String GetNextNumberedFileName(String strFolder, String strName)
        {
            Int64 current;
            String s = "";
            current = GetHighestFileNumber(strFolder, strName, ref s);
            current++;
            return InsertNumberedFileName(strName, current);
        }
        public static bool WriteTestFile(String strFolder)
        {
            String s = "";
            return WriteTestFile(strFolder, ref s);
        }
        public static bool WriteTestFile(String strFolder, ref String strCool)
        {
            String strID = Tools.Strings.GetNewID();
            String strFile = Tools.Folder.ConditionFolderName(strFolder) + strID + ".txt";
            Files.SaveFileAsString(strFile, "test");
            String strD = Files.OpenFileAsString(strFile);
            if (!Tools.Strings.StrCmp(strD, "test"))
                return false;
            try
            {
                System.IO.File.Delete(strFile);
            }
            catch (Exception ex)
            {
                strCool = ex.Message;
                return false;
            }
            return true;
        }
        public static ArrayList GetFileCollection(String strFolder, String strBase)
        {
            ArrayList r = new ArrayList();
            String[] s = System.IO.Directory.GetFiles(strFolder);
            foreach (String x in s)
            {
                String f = System.IO.Path.GetFileName(x);
                String b = RemoveNumberedFileName(f);
                if (Tools.Strings.StrCmp(b, strBase))
                {
                    r.Add(x);
                }
            }
            return r;
        }
        public static void TryDeleteFile(String strFile)
        {
            try
            {
                System.IO.File.Delete(strFile);
            }
            catch (Exception)
            {
            }
        }
        public static bool FileExists(string file)
        {
            try
            {
                if (!Tools.Strings.StrExt(file))
                    return false;
                return File.Exists(file);
            }
            catch { }
            return false;
        }
        public static void CopyFile(string file_location, string file_destination)
        {
            try
            {
                if (!FileExists(file_location))
                    return;
                string path = file_destination.Replace(GetFileName(file_destination), "").Trim();
                if (!Tools.Strings.StrExt(path))
                    return;
                if (!Tools.Folder.FolderExists(path))
                    return;
                File.Copy(file_location, file_destination);
            }
            catch { }
        }
        public static void CoalesceFileNames(ref ArrayList ary, String strFolder, String strExtension)
        {
            String[] files = System.IO.Directory.GetFiles(strFolder);
            foreach (String s in files)
            {
                if (s.ToLower().EndsWith(strExtension.ToLower()))
                    ary.Add(s);
            }
            String[] dirs = System.IO.Directory.GetDirectories(strFolder);
            foreach (String s in dirs)
            {
                if (!s.ToLower().EndsWith("\\projects"))
                    CoalesceFileNames(ref ary, s, strExtension);
            }
        }
        public static bool AppendLogFile(String strFile, String strLine)
        {
            try
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(strFile, true);
                file.WriteLine(strLine);
                file.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool OpenFileInDefaultViewer(String strFile)
        {
            string r = "";
            return OpenFileInDefaultViewer(strFile, ref r);
        }
        public static bool OpenFileInDefaultViewer(String strFile, ref string strCool)
        {
            try
            {
                System.Diagnostics.Process x = new System.Diagnostics.Process();
                x.StartInfo.FileName = strFile;
                x.StartInfo.Arguments = "";
                x.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                x.StartInfo.Verb = "open";
                x.StartInfo.UseShellExecute = true;
                x.Start();
                return true;
            }
            catch (Exception ee)
            {
                strCool = ee.Message;
                return false;
            }
        }
        public static bool FilesAreExactlyTheSame(string file1, string file2)
        {
            int file1byte;
            int file2byte;
            FileStream fs1;
            FileStream fs2;

            // Determine if the same file was referenced two times.
            if (file1 == file2)
            {
                // Return true to indicate that the files are the same.
                return true;
            }

            // Open the two files.
            fs1 = new FileStream(file1, FileMode.Open, FileAccess.Read);
            fs2 = new FileStream(file2, FileMode.Open, FileAccess.Read);

            // Check the file sizes. If they are not the same, the files 
            // are not the same.
            if (fs1.Length != fs2.Length)
            {
                // Close the file
                fs1.Close();
                fs2.Close();

                // Return false to indicate files are different
                return false;
            }

            // Read and compare a byte from each file until either a
            // non-matching set of bytes is found or until the end of
            // file1 is reached.
            do
            {
                // Read one byte from each file.
                file1byte = fs1.ReadByte();
                file2byte = fs2.ReadByte();
            }
            while ((file1byte == file2byte) && (file1byte != -1));

            // Close the files.
            fs1.Close();
            fs2.Close();

            // Return the success of the comparison. "file1byte" is 
            // equal to "file2byte" at this point only if the files are 
            // the same.
            return ((file1byte - file2byte) == 0);
        }
        public static String SpaceFormat(long l)
        {
            if (l > 1073741824)  //gb
            {
                Double gb = Math.Round(Convert.ToDouble(l) / 1073741824, 2);
                return gb.ToString() + "GB";
            }
            else if (l > 1048576)  //mb
            {
                Double mb = Math.Round(Convert.ToDouble(l) / 1048576, 2);
                return mb.ToString() + "MB";
            }
            else if (l > 1024)
            {
                Double kb = Math.Round(Convert.ToDouble(l) / 1024, 2);
                return kb.ToString() + "KB";
            }
            else
            {
                return Tools.Number.LongFormat(l) + "B";
            }
        }
        public static void MakeBackup(String f)
        {
            if (System.IO.File.Exists(f))
            {
                if (!Directory.Exists("c:\\trash\\bak\\"))
                    Directory.CreateDirectory("c:\\trash\\bak\\");

                String b = "c:\\trash\\bak\\" + System.IO.Path.GetFileNameWithoutExtension(f) + "_" + Convert.ToString(System.DateTime.Now.Year) + "_" + Convert.ToString(System.DateTime.Now.Month) + "_" + Convert.ToString(System.DateTime.Now.Day) + "_" + Convert.ToString(System.DateTime.Now.Hour) + "_" + Convert.ToString(System.DateTime.Now.Minute) + "_" + Convert.ToString(System.DateTime.Now.Second) + "_" + Tools.Strings.GetNewID() + System.IO.Path.GetExtension(f);
                System.IO.File.Copy(f, b);
            }
        }

        public static bool DownloadInternetFile(String strURL, String strLocalFile)
        {
            try
            {
                WebClient xClient = new WebClient();
                xClient.DownloadFile(strURL, strLocalFile);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public static void ExportDataTableToCsv(DataTable dt, string fileName, out string exportPath)
        {
            StringBuilder sb = new StringBuilder();
            exportPath = "";

            IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName);
            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in dt.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field =>
                  string.Concat("\"", field.ToString().Replace("\"", "\"\""), "\""));
                sb.AppendLine(string.Join(",", fields));
            }
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            exportPath = path + "\\" + fileName + ".csv";
            File.WriteAllText(exportPath, sb.ToString());

        }


    }
}
