using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Diagnostics;

using ICSharpCode.SharpZipLib.Zip;

using Tools;

namespace Tie
{
    public delegate void KnotStatusHandler(String status);

    public class TieKnot
    {
        public static int CheckIntervalSeconds = 30;
        public static DateTime LastUpdateCheckDate = Tools.Dates.GetNullDate();

        public static String KnotRootPath
        {
            get
            {
                try
                {
                    //if (nTools.IsDevelopmentMachinePlain())
                    //    return "C:\\Program Files\\NewMethod Software\\TieService\\";
                    //else
                    //{
                        //this way it can be called from the running pin or the knot and still return correctly
                        String s = Tools.FileSystem.GetAppPath();
                        String t = Tools.Folder.GetTopLevelFolderName(s);
                        if (t.ToLower().StartsWith("tack_"))
                            return Tools.FileSystem.GetAppParentPath();
                        else
                            return s;
                    //}
                }
                catch (Exception ex)
                {
                    return "";
                }
            }
        }

        public static ArrayList GetTackFolders()
        {
            try
            {
                ArrayList a = new ArrayList();
                String[] folders = Directory.GetDirectories(KnotRootPath);
                foreach (String s in folders)
                {
                    String f = Tools.Folder.GetTopLevelFolderName(s);
                    if (TieTack.IsTackFolderName(f))
                    {
                        a.Add(TieTack.GetTackNameFromFolder(f));
                    }
                }
                return a;
            }
            catch { return new ArrayList(); }
        }

        public String MakePinPathExist(String strTackName)
        {
            try
            {
                CheckPinUpdate(strTackName);
                return KnotRootPath + TieTack.GetTackFolderName(strTackName) + "\\" + Tools.Files.GetHighestFileName(KnotRootPath + TieTack.GetTackFolderName(strTackName) + "\\", "tiepin.exe");
            }
            catch
            {
                return "";
            }
        }

        public void CheckPinUpdate(String strTackName)
        {
            ArrayList copied = new ArrayList();
            try
            {
                //what if this happens to run during a server update?...
                //'latestoriginal' (no s) is the name of the live folder on each client.  if that isn't there, its in the middle of an update
                String strFolder = KnotRootPath + "latestoriginal\\";
                if (!Directory.Exists(strFolder))
                    return;

                String strTackFolder = KnotRootPath + TieTack.GetTackFolderName(strTackName) + "\\";
                if (!Directory.Exists(strTackFolder))
                    return;

                String[] files = Directory.GetFiles(strFolder);
                
                foreach (String file in files)
                {
                    String strNew = strTackFolder + Path.GetFileName(file);
                    //long fn = nTools.GetFileNumber(file);
                    //long fc = Tools.Files.GetHighestFileNumber(strTackFolder, nTools.RemoveNumberedFileName(Path.GetFileName(file)));

                    if (!File.Exists(strNew))
                    {
                        FireSetStatus("Updating " + strNew);
                        File.Copy(file, strNew);
                        copied.Add(strNew);
                    }
                }
            }
            catch (Exception ex)
            {
                FireSetStatus("Error in CheckPinUpdate-Rolling Back: " + ex.Message);
                //remove copied files to avoid mis-matched exe/dll pairs
                foreach (String s in copied)
                {
                    try
                    {
                        File.Delete(s);
                    }
                    catch { }
                }
            }
        }

        public static Process GetRunningPin(String strTackName)
        {
            try
            {
                Process[] ary = Process.GetProcesses();
                foreach (Process p in ary)
                {
                    try
                    {
                        if (Tools.Strings.HasString(p.MainModule.FileName, strTackName + "\\tiepin"))
                            return p;
                    }
                    catch { }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public static DateTime GetLastUpdateCheck()
        {
            try
            {
                String s = Tools.Files.OpenFileAsString(KnotRootPath + "last_update_check.txt");
                if (!Tools.Strings.StrExt(s))
                    return Tools.Dates.GetNullDate();

                if (!Tools.Dates.IsDate(s))
                    return Tools.Dates.GetNullDate();

                return DateTime.Parse(s);
            }
            catch
            {
                return Tools.Dates.GetNullDate();
            }
        }

        public static void SetLastUpdateCheck()
        {
            try
            {
                LastUpdateCheckDate = DateTime.Now;
                Tools.Files.SaveFileAsString(KnotRootPath + "last_update_check.txt", DateTime.Now.ToString());
            }
            catch
            {
            }
        }

        public event KnotStatusHandler SetStatus;
        public System.Threading.Timer timer;

        public void FireSetStatus(String s)
        {
            try
            {
                if (SetStatus != null)
                    SetStatus(s);
            }
            catch { }
        }

        public void CheckPinsPersistently()
        {
            try
            {
                timer = new System.Threading.Timer(new System.Threading.TimerCallback(timer_tick));
                timer.Change(CheckIntervalSeconds * 1000, CheckIntervalSeconds * 1000);
                CheckPins();
            }
            catch (Exception ex)
            {
                FireSetStatus("Error in CheckPinsPersistently: " + ex.Message);
            }
        }

        public void StopPersistence()
        {
            try
            {
                FireSetStatus("Stopping persistence...");
                if (timer != null)
                {
                    timer.Change(-1, -1);
                    timer = null;
                }
            }
            catch (Exception ex)
            {
                FireSetStatus("Error in StopPersistence: " + ex.Message);
            }
        }

        public void timer_tick(Object x)
        {
            CheckPins();
        }

        public void CheckPins()
        {
            try
            {
                TimeSpan t = DateTime.Now.Subtract(LastUpdateCheckDate);
                if (t.TotalHours > 4)
                {
                    //check the file
                    LastUpdateCheckDate = GetLastUpdateCheck();
                    t = DateTime.Now.Subtract(LastUpdateCheckDate);
                    if (t.TotalHours > 4)
                    {
                        CheckForUpdates();
                    }
                }

                ArrayList a = GetTackFolders();
                if (a.Count == 0)
                {
                    FireSetStatus("No configured pins were found.");
                    return;
                }

                FireSetStatus("Checking " + Tools.Number.LongFormat(a.Count) + " pins...");
                foreach (String s in a)
                {
                    CheckOnePin(s);
                }
                FireSetStatus("Checking complete.");
            }
            catch (Exception ex)
            {
                FireSetStatus("Error in CheckPins: " + ex.Message);
            }
        }

        public void CheckForUpdates()
        {
            SetLastUpdateCheck();
            if( UpdateIsNeeded() )
                DownloadUpdates();
        }

        public bool UpdateIsNeeded()
        {
            try
            {
                FireSetStatus("Checking for updates...");
                long l = GetLatestOriginalVersion();
                long w = TieWeb.GetCurrentWebVersion();
                return (l < w);
            }
            catch (Exception ex)
            {
                FireSetStatus("Error in UpdateIsNeeded: " + ex.Message);
                return false;
            }
        }

        public bool DownloadUpdates()
        {
            try
            {
                FireSetStatus("Downloading updates...");

                //recreate the folder
                String strFolder = KnotRootPath + "LatestOriginal\\";  // the 's' is now a flag, so that if another instance runs a pin update, it will know to skip until this update is done
                if (Directory.Exists(strFolder))
                    Directory.Move(strFolder, KnotRootPath + "LatestOriginal_" + Tools.Dates.GetDateTimeString() + "\\");

                //Directory.CreateDirectory(strFolder);  this will be done by unzipping the zip file

                String strFile = KnotRootPath + "tie.zip";
                if (File.Exists(strFile))
                    File.Delete(strFile);

                FireSetStatus("Downloading zip");
                if (!Tools.Files.DownloadInternetFile(TieWeb.TieZipURL, strFile))
                {
                    FireSetStatus("Error downloading zip.");
                    return false;
                }

                try
                {
                    FireSetStatus("Unzipping " + strFile);
                    FastZipEvents events = new FastZipEvents();
                    events.ProcessFile += new ICSharpCode.SharpZipLib.Core.ProcessFileDelegate(ProcessFileHandler);
                    ICSharpCode.SharpZipLib.Zip.FastZip f = new ICSharpCode.SharpZipLib.Zip.FastZip(events);
                    f.ExtractZip(strFile, KnotRootPath, "");
                    f = null;
                    events = null;
                }
                catch (Exception ze)
                {
                    FireSetStatus("Error unzipping " + strFile + ": " + ze.Message);
                    return false;
                }

                try
                {
                    Directory.Move(KnotRootPath + "LatestOriginals\\", KnotRootPath + "LatestOriginal\\");
                }
                catch (Exception exc)
                {
                    FireSetStatus("Error renaming LatestOriginals: " + exc.Message);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                FireSetStatus("Error in DownloadUpdates: " + ex.Message);
                return false;
            }
        }

        private void ProcessFileHandler(Object sender, ICSharpCode.SharpZipLib.Core.ScanEventArgs args)
        {
            try
            {
                FireSetStatus("Unzipping " + args.Name);
            }
            catch { }
        }

        public long GetLatestOriginalVersion()
        {
            try
            {
                String strFolder = TieKnot.KnotRootPath + "LatestOriginal\\";
                if (!Directory.Exists(strFolder))
                    return 0;

                String s = "";
                long l = Tools.Files.GetHighestFileNumber(strFolder, "tiepin.exe", ref s);
                return l;
            }
            catch (Exception ex)
            {
                FireSetStatus("Error in GetLatestOriginalVersion: " + ex.Message);
                return 0;
            }
        }

        public bool CheckOnePin(String strTackName)
        {
            try
            {
                FireSetStatus("Checking " + strTackName + "...");
                //make sure it has a TiePin executable

                //see if its running
                Process p = GetRunningPin(strTackName);
                if (p == null)    //start it
                {
                    String strPinPath = MakePinPathExist(strTackName);
                    if (!File.Exists(strPinPath))
                    {
                        FireSetStatus("No pin was found for " + strTackName);
                        return false;
                    }

                    FireSetStatus("Starting " + strTackName + " at " + strPinPath);

                    try
                    {
                        Tools.FileSystem.ShellSilently(strPinPath);
                    }
                    catch (Exception ex2)
                    {
                        FireSetStatus("Error starting " + strPinPath + " : " + ex2.Message);
                    }
                }
                else              //check its last ping
                {
                    String strPingFileName = TieTack.GetTackFolderPath(strTackName) + "last_ping.txt";
                    if (!File.Exists(strPingFileName))
                    {
                        //kill the process
                        FireSetStatus("Killing " + strTackName + " [missing ping file]");
                        KillPinProcess(p);
                        return false;
                    }

                    String s = Tools.Files.OpenFileAsString(strPingFileName);
                    try
                    {
                        DateTime t = DateTime.Parse(s);
                        TimeSpan ts = DateTime.Now.Subtract(t);
                        if (ts.TotalSeconds > TieKnot.CheckIntervalSeconds * 20)
                        {
                            FireSetStatus("Killing " + strTackName + " [ping way overdue]");
                            KillPinProcess(p);  //stuck somehow
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        FireSetStatus("Killing " + strTackName + " [Error: " + ex.Message + "]");
                        KillPinProcess(p);
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                FireSetStatus("Error in CheckOnePin: " + ex.Message);
                return false;
            }
        }

        private void KillPinProcess(Process p)
        {
            try
            {
                p.Kill();
                p.Dispose();
                p = null;
            }
            catch { }
        }
    }
}
