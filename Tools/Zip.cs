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
using ICSharpCode.SharpZipLib.Zip;

namespace Tools
{
    public partial class Zip
    {
        //Public Static Functions
        public static bool ZipOneFile(String strFileName, String strZipName)
        {
            try
            {
                ZipOutputStream s = new ZipOutputStream(File.Create(strZipName));
                FileStream fs = File.OpenRead(strFileName);
                ZipEntry entry = new ZipEntry(Path.GetFileName(strFileName));
                entry.DateTime = DateTime.Now;
                entry.Size = fs.Length;
                s.PutNextEntry(entry);
                Int64 total;
                Int32 chunksize;
                Int64 chunks;
                Int32 leftover;
                chunksize = 4096;
                total = fs.Length;
                chunks = total / chunksize;
                leftover = Convert.ToInt32(total % Convert.ToInt64(chunksize));
                for (int ch = 0; ch < chunks; ch++)
                {
                    byte[] buffer = new byte[chunksize];
                    fs.Read(buffer, 0, chunksize);
                    s.Write(buffer, 0, buffer.Length);
                }
                if (leftover > 0)
                {
                    byte[] buffer = new byte[leftover];
                    fs.Read(buffer, 0, leftover);
                    s.Write(buffer, 0, buffer.Length);
                }
                fs.Close();
                s.Finish();
                s.Close();
                s = null;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool UnZipOneFile(String strZipName, String strFolder)
        {
            String err = "";
            return UnZipOneFile(strZipName, strFolder, ref err);
        }

        public static bool UnZipOneFile(String strZipName, String strFolder, ref String err)
        {
            try
            {
                ICSharpCode.SharpZipLib.Zip.FastZip f = new ICSharpCode.SharpZipLib.Zip.FastZip();
                f.ExtractZip(strZipName, strFolder, "");
                f = null;
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public static bool UnZipOneFileOverwrite(String strZipName, String strFolder)
        {
            ICSharpCode.SharpZipLib.Zip.FastZip f = new ICSharpCode.SharpZipLib.Zip.FastZip();
            f.ExtractZip(strZipName, strFolder, FastZip.Overwrite.Always, null, "", "", false);
            f = null;
            return true;
        }

        public static bool ZipFolder(String FolderPath, String SavePath, String ZipName)
        {
            try
            {
                FolderPath = Tools.Folder.ConditionFolderName(FolderPath);
                SavePath = Tools.Folder.ConditionFolderName(SavePath);
                ZipName = ZipName.Replace(".zip", "").Replace(".ZIP", "");
                string[] filenames = Directory.GetFiles(FolderPath, "*.*", SearchOption.AllDirectories);
                using (ZipOutputStream s = new ZipOutputStream(File.Create(SavePath + ZipName + ".zip")))
                {
                    s.SetLevel(9); // 0-9, 9 being the highest compression
                    byte[] buffer = new byte[4096];
                    foreach (string file in filenames)
                    {
                        ZipEntry entry = new ZipEntry(Path.GetFileName(file));
                        entry.DateTime = DateTime.Now;
                        s.PutNextEntry(entry);
                        using (FileStream fs = File.OpenRead(file))
                        {
                            int sourceBytes;
                            do
                            {
                                sourceBytes = fs.Read(buffer, 0, buffer.Length);
                                s.Write(buffer, 0, sourceBytes);
                            }
                            while (sourceBytes > 0);
                        }
                    }
                    s.Finish();
                    s.Close();
                }
                //context.TheLeader.Comment("Zip file " + SavePath + ZipName + ".zip was created.");
                return true;
            }
            catch
            {
                //MessageBox.Show(ex.Message.ToString(), "Zip Operation Error");
                return false;
            }
        }

        public static bool ZipOneFolder(String strSourceFolder, String strDestFile)
        {
            try
            {
                ZipOutputStream s = new ZipOutputStream(File.Create(strDestFile));
                bool b = AddToZipFile(strSourceFolder, s, strSourceFolder);
                s.Finish();
                s.Close();
                return b;
            }
            catch
            {
                return false;
            }
        }

        public static bool AddToZipFile(String strFolder, ZipOutputStream z, String strBase)
        {
            try
            {
                int i = 0;
                String[] files = Directory.GetFiles(strFolder);
                foreach (String s in files)
                {
                    FileStream fs = File.OpenRead(s);
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    ZipEntry entry = new ZipEntry(Tools.Strings.Right(s, s.Length - strBase.Length));
                    entry.DateTime = DateTime.Now;
                    //entry.IsCrypted = true;
                    entry.Size = fs.Length;
                    fs.Close();
                    //crc.Reset();
                    //crc.Update(buffer);
                    //entry.Crc = crc.Value;
                    z.PutNextEntry(entry);
                    z.Write(buffer, 0, buffer.Length);
                    i++;
                }

                i = 0;
                String[] folders = Directory.GetDirectories(strFolder);
                //if (progress)
                //    context.TheLeader.StartPercent(folders.Length);
                foreach (String s in folders)
                {
                    AddToZipFile(s, z, strBase);  //, (progress && folders.Length == 1)

                    i++;
                    //if (progress)
                    //    context.TheLeader.AddPercent();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
