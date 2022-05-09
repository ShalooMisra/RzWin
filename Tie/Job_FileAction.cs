using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Win32;

using NewMethodx;

namespace Tie
{
    public class Job_FileAction : TieJob
    {
        TieMessage OriginalMessage;
        TieMessage ReturnMessage;

        public String OriginalName = "";
        public ArrayList OriginalNames = null;
        public String NewName = "";
        public String ActionType = "";
        public bool RegistryMode = false;

        public Job_FileAction(TieEnd e)
            : base(e)
        {
            Name = "File Action";
        }

        public override void Do()
        {
            try
            {
                BeforeDo();

                if( RegistryMode )
                    OriginalMessage = new TieMessage(xEnd.GetSessionFrom(), "registry_action_request", TargetSession);
                else
                    OriginalMessage = new TieMessage(xEnd.GetSessionFrom(), "file_action_request", TargetSession);
                OriginalMessage.JobID = this.UniqueID;
                OriginalMessage.ContentString = GenerateContent();

                AddLog("Sending " + ActionType + " request...");
                Send(OriginalMessage);
            }
            catch (Exception)
            { }
        }

        public override void GotMessage(TieMessage m)
        {
            try
            {
                switch (m.FunctionName)
                {
                    case "file_action_request":
                        TieMessage reply = new TieMessage(xEnd.GetSessionFrom(), "file_action_result", TargetSession);
                        reply.JobID = m.JobID;
                        reply.ToSession = m.FromSession;

                        OriginalName = Tools.Xml.ReadXmlProp(m.ContentNode, "original_name");
                        OriginalNames = ParseFileNameList(Tools.Xml.ReadXmlProp(m.ContentNode, "original_names"));
                        NewName = Tools.Xml.ReadXmlProp(m.ContentNode, "new_name");
                        ActionType = Tools.Xml.ReadXmlProp(m.ContentNode, "action_type");

                        OriginalName = TranslateFileName(OriginalName);
                        NewName = TranslateFileName(NewName);

                        switch (ActionType.ToLower())
                        {
                            case "file_copy":
                                reply.ContentString = CopyFile();
                                break;
                            case "file_move":
                                reply.ContentString = MoveFile();
                                break;
                            case "file_delete":
                                reply.ContentString = DeleteFile();
                                break;
                            case "file_open":
                                reply.ContentString = OpenFile();
                                break;

                            //case "folder_copy":
                            //    break;
                            //case "folder_move":
                            //    break;
                            //case "folder_delete":
                            //    break;
                        }

                        xEnd.Send(reply);
                        break;

                    case "file_action_result":
                        ReturnMessage = m;
                        AddLog("Received response...");

                        ResultStatus = Tools.Xml.ReadXmlProp(ReturnMessage.ContentNode, "command_result");
                        Success = true;

                        AddLog(ResultStatus);
                        AfterDo();
                        break;
                    case "registry_action_request":
                        TieMessage replyr = new TieMessage(xEnd.GetSessionFrom(), "file_action_result", TargetSession);
                        replyr.JobID = m.JobID;
                        replyr.ToSession = m.FromSession;

                        OriginalName = Tools.Xml.ReadXmlProp(m.ContentNode, "original_name");
                        OriginalNames = ParseFileNameList(Tools.Xml.ReadXmlProp(m.ContentNode, "original_names"));
                        NewName = Tools.Xml.ReadXmlProp(m.ContentNode, "new_name");
                        ActionType = Tools.Xml.ReadXmlProp(m.ContentNode, "action_type");

                        switch (ActionType.ToLower())
                        {
                            //case "file_copy":
                            //    reply.ContentString = CopyFile();
                            //    break;
                            //case "file_move":
                            //    reply.ContentString = MoveFile();
                            //    break;
                            case "file_delete":
                                replyr.ContentString = DeleteRegistryEntry();
                                break;
                            //case "file_open":
                            //    reply.ContentString = OpenFile();
                            //    break;

                            //case "folder_copy":
                            //    break;
                            //case "folder_move":
                            //    break;
                            //case "folder_delete":
                            //    break;
                        }

                        xEnd.Send(replyr);
                        break;
                    case "registry_action_response":
                        break;
                    default:
                        base.GotMessage(m);
                        break;
                }
            }
            catch (Exception ex)
            {
                AddLog("File Action Error: " + ex.Message);
            }
        }

        public ArrayList ParseFileNameList(String s)
        {
            String[] ary = Tools.Strings.Split(s, "|file|break|");
            ArrayList r = new ArrayList();
            foreach(String l in ary)
            {
                if( Tools.Strings.StrExt(l) )
                    r.Add(l);
            }
            return r;
        }

        public String BuildFileNameList(ArrayList a)
        {
            if (a == null)
                return "";
            StringBuilder sb = new StringBuilder();
            foreach (String s in a)
            {
                sb.Append(s + "|file|break|");
            }
            return sb.ToString();
        }

        public String CopyFile()
        {
            try
            {
                if( !File.Exists(OriginalName) )
                    return Tools.Xml.BuildXmlProp("command_result", "Error: File " + OriginalName + " not found.");

                if (File.Exists(NewName))
                    return Tools.Xml.BuildXmlProp("command_result", "Error: File " + NewName + " already exists.");

                File.Copy(OriginalName, NewName);
                return Tools.Xml.BuildXmlProp("command_result", "Success: File copied.");
            
            }
            catch (Exception ex)
            {
                return Tools.Xml.BuildXmlProp("command_result", "Copy Error: " + ex.Message);
            }
        }

        //public String CopyFolder()
        //{
        //    try
        //    {
        //        if (!Directory.Exists(OriginalName))
        //            return Tools.Xml.BuildXmlProp("command_result", "Error: Folder " + OriginalName + " not found.");

        //        if (File.Exists(NewName))
        //            return Tools.Xml.BuildXmlProp("command_result", "Error: File " + NewName + " already exists.");

        //        File.Copy(OriginalName, NewName);
        //        return Tools.Xml.BuildXmlProp("command_result", "Success: File copied.");

        //    }
        //    catch (Exception ex)
        //    {
        //        return Tools.Xml.BuildXmlProp("command_result", "xError: " + ex.Message);
        //    }
        //}

        public String MoveFile()
        {
            try
            {
                if (!File.Exists(OriginalName))
                    return Tools.Xml.BuildXmlProp("command_result", "Error: File " + OriginalName + " not found.");

                if (File.Exists(NewName))
                    return Tools.Xml.BuildXmlProp("command_result", "Error: File " + NewName + " already exists.");

                File.Move(OriginalName, NewName);
                return Tools.Xml.BuildXmlProp("command_result", "Success: File moved.");

            }
            catch (Exception ex)
            {
                return Tools.Xml.BuildXmlProp("command_result", "Move Error: " + ex.Message);
            }
        }

        public String DeleteFile()
        {
            try
            {
                ArrayList a = GetOriginalFileNameArray();
                if( a.Count == 0 )
                    return Tools.Xml.BuildXmlProp("command_result", "Error: no file names found.");

                int done = 0;
                StringBuilder se = new StringBuilder();

                foreach (String s in a)
                {
                    if (Tools.Strings.StrExt(s))
                    {
                        if (!File.Exists(s))
                            se.AppendLine("Error: File " + s + " not found.");
                        else
                        {
                            try
                            {
                                File.Delete(s);
                            }
                            catch (Exception ex)
                            {
                                se.AppendLine("Error deleting " + s + ": " + ex.Message);
                            }
                        }
                    }
                }

                if( Tools.Strings.StrExt(se.ToString()) )
                    return Tools.Xml.BuildXmlProp("command_result", "Error:\r\n\r\n" + se.ToString());
                else
                    return Tools.Xml.BuildXmlProp("command_result", "Success: " + Tools.Number.LongFormat(done) + " file(s) deleted.");

            }
            catch (Exception ex)
            {
                return Tools.Xml.BuildXmlProp("command_result", "Delete Error: " + ex.Message);
            }
        }

        public String DeleteRegistryEntry()
        {
            try
            {
                ArrayList a = GetOriginalFileNameArray();
                if (a.Count == 0)
                    return Tools.Xml.BuildXmlProp("command_result", "Error: no file names found.");

                int done = 0;
                StringBuilder se = new StringBuilder();

                foreach (String s in a)
                {
                    if (Tools.Strings.StrExt(s))
                    {
                        String strParentKey = "";
                        String strItemName = "";

                        String[] split = Tools.Strings.Split(s, "\\");
                        List<String> remaining = new List<String>();
                        foreach(String line in split)
                        {
                            if( Tools.Strings.StrExt(line) )
                                remaining.Add(line);
                        }
                        int i = 0;
                        foreach(String line in remaining)
                        {
                            if( i < remaining.Count - 1)
                            {
                                if( Tools.Strings.StrExt(strParentKey) )
                                    strParentKey += "\\";
                                strParentKey += line;
                            }
                            else
                                strItemName = line;
                            i++;
                        }

                        if( !Tools.Strings.StrExt(strParentKey) || !Tools.Strings.StrExt(strItemName) )
                        {
                        se.AppendLine("Error: Registry Key " + strParentKey + " - " + strItemName + " not found.");
                        }
                        else
                        {
                            RegistryKey k;
                            if( strItemName.StartsWith("value:") )
                            {
                                strItemName = Tools.Strings.ParseDelimit(strItemName, "value:", 2).Trim();
                                k = Job_Files.GetRegistryKey(strParentKey);
                                if (k == null)
                                    se.AppendLine("Error: Registry Key " + s + " not found.");
                                else
                                {
                                    try
                                    {
                                        k.DeleteValue(strItemName);
                                    }
                                    catch(Exception ex)
                                    {
                                        se.Append("Error deleteing " + strItemName + ": " + ex.Message);
                                    }
                                }

                            }
                            else
                            {
                                k = Job_Files.GetRegistryKey(strParentKey);
                                if (k == null)
                                    se.AppendLine("Error: Registry Key " + s + " not found.");
                                else
                                {
                                    try
                                    {
                                        k.DeleteSubKey(strItemName);
                                    }
                                    catch (Exception ex)
                                    {
                                        se.AppendLine("Error deleting " + s + ": " + ex.Message);
                                    }
                                }
                            }
                        }
                    }
                }

                if (Tools.Strings.StrExt(se.ToString()))
                    return Tools.Xml.BuildXmlProp("command_result", "Error:\r\n\r\n" + se.ToString());
                else
                    return Tools.Xml.BuildXmlProp("command_result", "Success: " + Tools.Number.LongFormat(done) + " file(s) deleted.");

            }
            catch (Exception ex)
            {
                return Tools.Xml.BuildXmlProp("command_result", "Delete Error: " + ex.Message);
            }
        }

        public ArrayList GetOriginalFileNameArray()
        {
            ArrayList r = new ArrayList();
            if (Tools.Strings.StrExt(OriginalName))
                r.Add(OriginalName);

            foreach (String s in OriginalNames)
            {
                r.Add(s);
            }

            return r;
        }

        public String OpenFile()
        {
            try
            {
                if (!File.Exists(OriginalName))
                    return Tools.Xml.BuildXmlProp("command_result", "Error: File " + OriginalName + " not found.");

                if( Tools.Files.OpenFileInDefaultViewer(OriginalName) )
                    return Tools.Xml.BuildXmlProp("command_result", "Success: File opened.");
                else
                    return Tools.Xml.BuildXmlProp("command_result", "Error.");
            }
            catch (Exception ex)
            {
                return Tools.Xml.BuildXmlProp("command_result", "Open Error: " + ex.Message);
            }
        }

        public String GenerateContent()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Tools.Xml.BuildXmlProp("original_name", OriginalName));
            sb.Append(Tools.Xml.BuildXmlProp("original_names", BuildFileNameList(OriginalNames)));
            sb.Append(Tools.Xml.BuildXmlProp("new_name", NewName));
            sb.Append(Tools.Xml.BuildXmlProp("action_type", ActionType));
            return sb.ToString();
        }
    }
}
