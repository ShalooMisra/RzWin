using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Drawing;
using System.Xml;

namespace ToolsWin
{
    public partial class FileSystem
    {
        public static String ChooseAFile()
        {
            System.Windows.Forms.OpenFileDialog d = new System.Windows.Forms.OpenFileDialog();
            d.ShowDialog();
            String ret = d.FileName;
            try
            {
                d.Dispose();
                d = null;
            }
            catch { }
            return ret;
        }

        public static String ChooseAFolder(String start = "")
        {
            System.Windows.Forms.FolderBrowserDialog d = new System.Windows.Forms.FolderBrowserDialog();
            try
            {
                d.SelectedPath = start;
            }
            catch (Exception)
            {
            }
            d.ShowDialog();
            return d.SelectedPath;

        }

        public static String FileNameCreate(System.Windows.Forms.IWin32Window owner)
        {
            System.Windows.Forms.OpenFileDialog d = new System.Windows.Forms.OpenFileDialog();
            d.CheckFileExists = false;
            d.CheckPathExists = true;
            if (owner != null)
                d.ShowDialog(owner);
            else
                d.ShowDialog();
            return d.FileName;
        }


        public static String GetDesktopWallpaperFile()
        {
            try
            {
                //HKEY_CURRENT_USER\Control Panel\Desktop\Wallpaper
                Microsoft.Win32.RegistryKey ckey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", false);
                String s = ckey.GetValue("Wallpaper").ToString();
                if (!File.Exists(s))
                    return "";
                return s;
            }
            catch { return ""; }
        }
    }
}