using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Tools;
using NewMethodx;
using Tie;

using OthersCodex;
using ICSharpCode.SharpZipLib.Zip;

namespace TieManager
{
    public partial class frmTieManager : Form
    {
        public ArrayList TieFiles;
        public long LiveVersion = 0;
        public long CurrentWebVersion = 0;

        public frmTieManager()
        {
            InitializeComponent();
        }

        public void CompleteLoad()
        {
            TieWeb.SetSitePassword("NewMeth0d");

            TieFiles = new ArrayList();
            TieFile f = AddFile("tiepin.exe", "c:\\eternal\\code\\tie\\tiepin\\bin\\release\\", "series");
            AddFile("tie.dll", "c:\\eternal\\code\\tie\\tiepin\\bin\\release\\", "static");
            AddFile("ICSharpCode.SharpZipLib.dll", "c:\\eternal\\code\\tie\\tiepin\\bin\\release\\", "static");
            AddFile("Tools.dll", "c:\\eternal\\code\\tie\\tiepin\\bin\\release\\", "static");

            ShowFiles();

            CurrentWebVersion = TieWeb.GetCurrentWebVersion();
            lblCurrentSite.Text = Tools.Number.LongFormat(CurrentWebVersion);
            LiveVersion = f.LiveVersion;
            lblLiveVersion.Text = Tools.Number.LongFormat(LiveVersion);
            cmdUpdateTie.Enabled = CurrentWebVersion < LiveVersion;
        }

        private TieFile AddFile(String strName, String strFolder, String strType)
        {
            TieFile f = new TieFile();
            f.FileName = strName;
            f.FolderName = strFolder;
            f.FileType = strType;
            String s = "";
            f.LiveVersion = Tools.Files.GetHighestFileNumber(strFolder, strName, ref s);

            TieFiles.Add(f);
            return f;
        }

        public void ShowFiles()
        {
            lv.Items.Clear();
            foreach (TieFile f in TieFiles)
            {
                ListViewItem i = lv.Items.Add(f.FileName);
                i.SubItems.Add(f.FileType);
                i.SubItems.Add(Tools.Number.LongFormat(f.LiveVersion));
                i.SubItems.Add(f.FolderName);
                i.Tag = f;
            }
        }

        private void cmdUpdateTie_Click(object sender, EventArgs e)
        {
            UpdateTie();
        }

        public bool UpdateTie()
        {
            if( LiveVersion <= CurrentWebVersion )
            {
                SetStatus("The live version appears to be equal to or lower than the web version.");
                return false;
            }

            SetStatus("Updating Tie..");

            //recreate the folder
            String strFolder = Tools.FileSystem.GetAppPath() + "LatestOriginals\\";
            if( Directory.Exists(strFolder) )
                Directory.Move(strFolder, Tools.FileSystem.GetAppPath() + "LatestOriginals_" + Tools.Dates.GetDateTimeString() + "\\");

            Directory.CreateDirectory(strFolder);

            //copy out the files, renaming them
            foreach (TieFile f in TieFiles)
            {
                String strSource = "";
                String strDest = "";
                if (f.FileType == "series")
                {
                    String h = Tools.Files.GetHighestFileName(f.FolderName, f.FileName);
                    if( !Tools.Strings.StrExt(h) )
                    {
                        SetStatus("The highest file for " + f.FileName + " was not found.");
                        return false;
                    }

                    long l = Tools.Files.GetFileNumber(h);
                    if( l != LiveVersion )
                    {
                        SetStatus("The highest file for " + f.FileName + " has number " + l.ToString() + ", but the live version appears to be " + LiveVersion.ToString());
                        return false;
                    }

                    strSource = h;
                    strDest = h;
                }
                else
                {
                    strSource = f.FileName;
                    strDest = f.FileName;
                }

                SetStatus("Copying " + strSource + "...");
                File.Copy(f.FolderName + strSource, strFolder + strDest);
            }

            //clear the previous zip
            String strZipFile = Tools.FileSystem.GetAppPath() + "tie.zip";
            if (File.Exists(strZipFile))
                File.Delete(strZipFile);

            //zip them
            ZipOutputStream s = new ZipOutputStream(File.Create(strZipFile));

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(LiveVersion.ToString());

            String[] files = Directory.GetFiles(strFolder);
            foreach (String file in files)
            {
                SetStatus("Zipping " + Path.GetFileName(file));

                FileStream fs = File.OpenRead(file);
                sb.AppendLine(Path.GetFileName(file) + "\t" + fs.Length.ToString());

                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                //needs to have the folder name
                ZipEntry entry = new ZipEntry("LatestOriginals\\" + Path.GetFileName(file));
                entry.DateTime = DateTime.Now;
                //entry.IsCrypted = true;
                entry.Size = fs.Length;
                fs.Close();
                //crc.Reset();
                //crc.Update(buffer);
                //entry.Crc = crc.Value;
                s.PutNextEntry(entry);
                s.Write(buffer, 0, buffer.Length);
            }

            s.Finish();
            s.Close();

            FTPProgressHandler progress = new FTPProgressHandler(FTPProgress);
            FTPStatusHandler status = new FTPStatusHandler(FTPStatus);

            FTP ftplib = TieWeb.GetFTPConnection(status);
            if( ftplib == null )
                return false;

            //remove the tie.txt file
            SetStatus("Removing previous tie.txt");
            TieWeb.DeleteTieText(ftplib);

            //upload the zip
            SetStatus("Uploading " + strZipFile);
            //FTPProgress.
            TieWeb.SetTieZip(ftplib, strZipFile, progress, status);

            //set the tie.txt file
            TieWeb.SetTieText(sb.ToString(), progress, status);

            CompleteLoad();

            SetStatus("Update complete");
            return true;
        }

        public void FTPStatus(String status)
        {
            SetStatus(status);
        }

        public void FTPProgress(int progress)
        {
            pb.Value = progress;
        }

        public void SetStatus(String status)
        {
            txt.AppendText(status + "\n");
            txt.ScrollToCaret();
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            CompleteLoad();
        }
    }

    public class TieFile
    {
        public String FileName;
        public String FolderName;
        public String FileType;
        public long LiveVersion;
    }
}