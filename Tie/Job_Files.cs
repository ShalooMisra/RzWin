using System;
using System.Collections;
using System.Text;
using System.IO;
using Microsoft.Win32;

using NewMethodx;

namespace Tie
{
    public class Job_Files : TieJob
    {
        TieMessage OriginalMessage;
        TieMessage ReturnMessage;

        public bool RegistryMode = false;

        public Job_Files(TieEnd e)
            : base(e)
        {
            Name = "Files";
        }

        public override void Do()
        {
            try
            {
                BeforeDo();

                if (RegistryMode)
                {
                    OriginalMessage = new TieMessage(xEnd.GetSessionFrom(), "registry_section_request", TargetSession);
                    AddLog("Sending registry request...");
                }
                else
                {
                    OriginalMessage = new TieMessage(xEnd.GetSessionFrom(), "drives_request", TargetSession);
                    AddLog("Sending drives request...");
                }
                if (!Send(OriginalMessage))
                {
                    ;
                }
            }
            catch (Exception)
            { }
        }

        public override void GotMessage(TieMessage m)
        {
            try
            {
                TieMessage reply;
                switch (m.FunctionName)
                {
                    case "drives_request":
                        ReturnMessage = m;
                        AddLog("Received drives request...");

                        reply = GetReply(m);
                        reply.FunctionName = "drives_response";
                        reply.ContentString = "<drives>" + GetDriveList() + "</drives>";
                        Send(reply);
                        break;
                    case "registry_section_request":
                        ReturnMessage = m;
                        AddLog("Received registry section request...");

                        reply = GetReply(m);
                        reply.FunctionName = "registry_section_response";
                        reply.ContentString = "<registrysections>" + GetRegistrySectionList() + "</registrysections>";
                        Send(reply);
                        break;
                    case "files_request":
                        ReturnMessage = m;
                        AddLog("Received files request...");

                        String strFolder = Tools.Xml.ReadXmlProp(ReturnMessage.ContentNode, "folder_path");
                        strFolder = TranslateFileName(strFolder);

                        reply = GetReply(m);
                        reply.FunctionName = "files_response";
                        reply.ContentString = Tools.Xml.BuildXmlProp("folder_path", strFolder) + "<folders>" + GetFolderList(strFolder) + "</folders><files>" + GetFileList(strFolder) + "</files>";
                        Send(reply);
                        break;
                    case "registry_folders_request":
                        ReturnMessage = m;
                        AddLog("Received registry folders request...");

                        String strRegFolder = Tools.Xml.ReadXmlProp(ReturnMessage.ContentNode, "folder_path");
                        reply = GetReply(m);
                        reply.FunctionName = "registry_folders_response";
                        reply.ContentString = Tools.Xml.BuildXmlProp("folder_path", strRegFolder) + "<folders>" + GetRegistryFolderList(strRegFolder) + "</folders><registryvalues>" + GetRegistryValueList(strRegFolder) + "</registryvalues>";
                        Send(reply);
                        break;

                    case "drives_response":
                    case "files_response":
                    case "registry_section_response":
                    case "registry_folders_response":
                        FireGotMessageEvent(m);
                        break;
                    default:
                        base.GotMessage(m);
                        break;
                }
            }
            catch (Exception ex)
            {
                AddLog("Files Error: " + ex.Message);
            }
        }

        public void RequestFiles(String strPath)
        {
            TieMessage reply = new TieMessage(xEnd.GetSessionFrom(), "files_request", TargetSession);
            if( !strPath.EndsWith("\\") )
                strPath = Tools.Folder.ConditionFolderName(strPath);
            reply.ContentString = Tools.Xml.BuildXmlProp("folder_path", strPath);
            Send(reply);
        }

        public void RequestRegistryFolders(String strPath)
        {
            TieMessage reply = new TieMessage(xEnd.GetSessionFrom(), "registry_folders_request", TargetSession);
            if (!strPath.EndsWith("\\"))
                strPath = Tools.Folder.ConditionFolderName(strPath);
            reply.ContentString = Tools.Xml.BuildXmlProp("folder_path", strPath);
            Send(reply);
        }

        private String GetRegistrySectionList()
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                sb.Append("<registrysection>");
                sb.Append(Tools.Xml.BuildXmlProp("name", Registry.ClassesRoot.Name));
                sb.Append("</registrysection>");
                sb.Append("<registrysection>");
                sb.Append(Tools.Xml.BuildXmlProp("name", Registry.CurrentConfig.Name));
                sb.Append("</registrysection>");
                sb.Append("<registrysection>");
                sb.Append(Tools.Xml.BuildXmlProp("name", Registry.CurrentUser.Name));
                sb.Append("</registrysection>");
                sb.Append("<registrysection>");
                sb.Append(Tools.Xml.BuildXmlProp("name", Registry.LocalMachine.Name));
                sb.Append("</registrysection>");
                sb.Append("<registrysection>");
                sb.Append(Tools.Xml.BuildXmlProp("name", Registry.Users.Name));
                sb.Append("</registrysection>");
            }
            catch { }
            return sb.ToString();
        }

        private String GetDriveList()
        {
            StringBuilder sb = new StringBuilder();

            AddSpecialFolder(sb, Environment.SpecialFolder.Desktop);
            AddSpecialFolder(sb, Environment.SpecialFolder.MyDocuments);

            DriveInfo[] ary = System.IO.DriveInfo.GetDrives();
            try
            {
                foreach (DriveInfo f in ary)
                {
                    if (f.DriveType == DriveType.Network)
                    {
                        //remove this, and just track if there are any net drives
                        //if so, use the WMI after this loop to get the net shares and details

                        sb.Append("<drive>");
                        try
                        {
                            sb.Append(Tools.Xml.BuildXmlProp("name", f.Name));
                            sb.Append(Tools.Xml.BuildXmlProp("drive_type", f.DriveType.ToString()));
                            //sb.Append(Tools.Xml.BuildXmlProp("total_size", f.TotalSize.ToString()));
                            //sb.Append(Tools.Xml.BuildXmlProp("total_freespace", f.TotalFreeSpace.ToString()));                        
                        }
                        catch { }
                        sb.Append("</drive>");
                    }
                    else
                    {
                        if (f.IsReady)
                        {
                            sb.Append("<drive>");
                            try
                            {
                                sb.Append(Tools.Xml.BuildXmlProp("name", f.Name));
                                sb.Append(Tools.Xml.BuildXmlProp("drive_type", f.DriveType.ToString()));
                                sb.Append(Tools.Xml.BuildXmlProp("volume_label", f.VolumeLabel));
                                sb.Append(Tools.Xml.BuildXmlProp("total_size", f.TotalSize.ToString()));
                                sb.Append(Tools.Xml.BuildXmlProp("total_freespace", f.TotalFreeSpace.ToString()));
                            }
                            catch { }
                            sb.Append("</drive>");
                        }
                        else
                        {
                            ;
                        }
                    }
                }
            }
            catch
            {
            }
            return sb.ToString();
        }

        private void AddSpecialFolder(StringBuilder sb, System.Environment.SpecialFolder sf)
        {
            String spec = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(sf));
            if (Directory.Exists(spec))
            {
                sb.Append("<drive>");
                try
                {
                    sb.Append(Tools.Xml.BuildXmlProp("name", sf.ToString()));
                    sb.Append(Tools.Xml.BuildXmlProp("volume_label", sf.ToString()));
                    sb.Append(Tools.Xml.BuildXmlProp("drive_type", "folder"));
                    sb.Append(Tools.Xml.BuildXmlProp("folder_path", spec));
                }
                catch { }
                sb.Append("</drive>");
            }
        }

        private String GetFolderList(String strPath)
        {
            try
            {
                if (!Tools.Strings.StrExt(strPath))
                    return "";

                StringBuilder sb = new StringBuilder();
                String[] ary = Directory.GetDirectories(strPath);
                foreach (String s in ary)
                {
                    sb.Append("<folder>");
                    sb.Append(Tools.Xml.BuildXmlProp("name", Tools.Folder.GetTopLevelFolderName(s)));
                    sb.Append("</folder>");
                }
                return sb.ToString();
            }
            catch { return ""; }
        }

        private String GetRegistryValueList(String strPath)
        {
            try
            {
                if (!Tools.Strings.StrExt(strPath))
                    return "";

                StringBuilder sb = new StringBuilder();
                RegistryKey k = GetRegistryKey(strPath);
                if (k == null)
                    return "";

                string[] SubKeys = k.GetValueNames();
                foreach (String vstr in SubKeys)
                {			//subkey value name
                    String strName = vstr;
                    object robj = k.GetValue(vstr, typeof(string));
                    String vstring = "";
                    String vtype = "";
                    GetTypeAndValue(robj, ref vtype, ref vstring);
                    if (vstr == "")
                        strName = "Default";

                    sb.Append("<registryvalue>");
                    sb.Append(Tools.Xml.BuildXmlProp("name", vstr));
                    sb.Append(Tools.Xml.BuildXmlProp("valuetype", vtype));
                    sb.Append(Tools.Xml.BuildXmlProp("valuestring", vstring));
                    sb.Append("</registryvalue>");
                }

                return sb.ToString();
            }
            catch { return ""; }
        }



        //-------------------------------------------------------
        void GetTypeAndValue(object robj, ref String Type, ref String Value)
        {
            Value = robj.ToString();    //get object value 
            Type = robj.GetType().ToString();  //get object type
            Type = Type.Substring(7, Type.Length - 7); //strip off "System."

            if (Type == "Byte[]")
            {
                Value = "";
                byte[] Bytes = (byte[])robj;
                foreach (byte bt in Bytes)
                {
                    string hexval = bt.ToString();
                    if (hexval == "") hexval = "0";
                    Value = Value + hexval + " ";
                }
            }
        }

        private String GetRegistryFolderList(String strPath)
        {
            try
            {
                if (!Tools.Strings.StrExt(strPath))
                    return "";

                StringBuilder sb = new StringBuilder();
                RegistryKey k = GetRegistryKey(strPath);
                if (k == null)
                    return "";
                string[] sknames = k.GetSubKeyNames();
                foreach (String str in sknames)
                {
                    sb.Append("<folder>");
                    sb.Append(Tools.Xml.BuildXmlProp("name", str));
                    sb.Append("</folder>");
                }
                return sb.ToString();
            }
            catch { return ""; }
        }

        public static RegistryKey GetRegistryKey(String s)
        {
            RegistryKey k = CheckKey(s, Registry.ClassesRoot);
            if( k != null )
                return k;

            k = CheckKey(s, Registry.CurrentConfig);
            if (k != null)
                return k;

            k = CheckKey(s, Registry.CurrentUser);
            if (k != null)
                return k;

            k = CheckKey(s, Registry.LocalMachine);
            if (k != null)
                return k;

            k = CheckKey(s, Registry.Users);
            if (k != null)
                return k;

            return null;
        }

        static RegistryKey CheckKey(String s, RegistryKey k)
        {
            if (s.StartsWith(k.Name))
            {
                if (s == k.Name + "\\")
                    return k;

                try
                {
                    return k.OpenSubKey(Tools.Strings.Mid(s, k.Name.Length + 2), true);
                }
                catch(Exception ex)
                {
                    return null;
                }
            }
            else
                return null;
        }

        private String GetFileList(String strPath)
        {
            try
            {
                if (!Tools.Strings.StrExt(strPath))
                    return "";

                StringBuilder sb = new StringBuilder();
                String[] ary = Directory.GetFiles(strPath);
                foreach (String s in ary)
                {
                    FileInfo f = new FileInfo(s);

                    sb.Append("<file>");
                    sb.Append(Tools.Xml.BuildXmlProp("name", Path.GetFileName(s)));
                    sb.Append(Tools.Xml.BuildXmlProp("length", f.Length.ToString()));
                    sb.Append(Tools.Xml.BuildXmlProp("last_write", f.LastWriteTime.ToString()));
                    sb.Append("</file>");
                }
                return sb.ToString();
            }
            catch { return ""; }
        }
    }
}
