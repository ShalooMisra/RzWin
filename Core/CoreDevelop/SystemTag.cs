using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using Core;

namespace CoreDevelop
{
    public class SystemTag
    {
        public String FileNameDll = "";
        public String FileNameSln = "";
        public String CodePath = "";

        public SystemTag(String file_dll, String file_sln, String code_path)
        {
            FileNameDll = file_dll;
            FileNameSln = file_sln;
            CodePath = code_path;
        }

        public String Name
        {
            get
            {
                return Path.GetFileNameWithoutExtension(FileNameDll);
            }
        }


        public String LastKnownGoodPath
        {
            get
            {
                return Tools.Folder.ConditionFolderName(Path.GetDirectoryName(FileNameDll)) + @"LKG\";
            }
        }

        public static List<SystemTag> Tags
        {
            get
            {
                List<SystemTag> ret = new List<SystemTag>();
                String s = Tools.FileSystem.OpenFileAsString(TagFile);
                String[] lines = Tools.Strings.SplitLines(Tools.Strings.KillBlankLines(s));
                foreach(String line in lines)
                {
                    String[] info = Tools.Strings.Split(line, "|");
                    if( info.Length == 3)
                    {
                        ret.Add(new SystemTag(info[0], info[1], info[2])); 
                    }
                }
                return ret;                
            }
        }

        public static bool TagSave(SystemTag t)
        {
            String all = Tools.FileSystem.OpenFileAsString(TagFile);
            String add = t.FileNameDll + "|" + t.FileNameSln + "|" + t.CodePath;
            if (all.ToLower().Contains(add.ToLower()))
                return true;

            if (all != "" && !all.EndsWith("\r\n"))
                all += "\r\n";
            all += add;
            return Tools.FileSystem.SaveFileAsString(TagFile, all);
        }

        public static String TagFile
        {
            get
            {
                return @"c:\Eternal\Code\Core\CoreDevelop\SystemTags.txt";
            }
        }

        public static SystemTag Create(Context context, String dll, String sln, String code)
        {
            StringBuilder sb =new StringBuilder();
            bool pass = true;
            if (!File.Exists(dll))
            {
                pass = false;
                sb.AppendLine("Choose a .dll file that exists");                
            }

            if (!File.Exists(sln))
            {
                pass = false;
                sb.AppendLine("Choose a .sln file that exists");
            }

            if (!Directory.Exists(code))
            {
                pass = false;
                sb.AppendLine("Choose a code folder that exists");
            }

            if (pass)
                return new SystemTag(dll, sln, code);
            else
            {
                context.TheLeader.Error(sb.ToString());
                return null;
            }
        }

        public static bool TagExists(SystemTag t)
        {
            foreach (SystemTag tag in Tags)
            {
                if (Tools.Strings.StrCmp(tag.FileNameDll, t.FileNameDll) && Tools.Strings.StrCmp(tag.FileNameSln, t.FileNameSln) && Tools.Strings.StrCmp(tag.CodePath, t.CodePath))
                    return true;
            }
            return false;
        }
    }
}
