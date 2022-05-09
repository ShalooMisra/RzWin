using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Xml;

namespace RzWinTools
{
    public static class RZDL
    {
        public static void ProcessRzDownload(string cmd, string file)
        {
            try
            {
                string folder = @"c:\bilge\";
                string folder2 = @"c:\bilge\" + Tools.Strings.GetNewID() + @"\";
                if (!Tools.Folder.FolderExists(folder))
                    Tools.Folder.MakeFolderExist(folder);
                if (!Tools.Files.FileExists(file))
                {
                    Tools.FileSystem.PopText("File: " + file + "\r\nDoes not exist.");
                    return;
                }
                string fn = Tools.Files.GetFileNameNoExtention(file);
                string proj = Tools.Strings.ParseDelimit(fn, "_", 1).Trim();
                Tools.Files.CopyFile(file, folder + fn + ".zip");
                Tools.Folder.MakeFolderExist(folder2);
                Tools.Zip.UnZipOneFile(folder + fn + ".zip", folder2);
                String[] files = System.IO.Directory.GetFiles(folder2, "*.zip");
                foreach (string f in files)
                {
                    string s = Tools.Strings.ParseDelimit(Tools.Files.GetFileNameNoExtention(f), "_", 1).Trim();
                    switch (s.ToLower())
                    {
                        case "auto":
                            ProcessRzFile(proj, f, FileType.Auto);
                            break;
                        case "items":
                            ProcessRzFile(proj, f, FileType.Items);
                            break;
                    }
                }
                Increment(proj);
                System.Windows.Forms.MessageBox.Show("Done.");
            }
            catch (Exception ee)
            {
                Tools.FileSystem.PopText("Error: " + ee.Message);
            }
        }
        private static void ProcessRzFile(string project, string f, FileType t)
        {
            try
            {
                string proj_loc = @"c:\Eternal\Code\" + project + @"\";
                string unzip_folder = Tools.Folder.GetFolderName(f);
                switch (t)
                {
                    case FileType.Auto:
                        proj_loc += @"Auto\";
                        unzip_folder = Tools.Folder.ConditionFolderName(unzip_folder) + @"Auto\";
                        break;
                    case FileType.Items:
                        proj_loc += @"Items\";
                        unzip_folder = Tools.Folder.ConditionFolderName(unzip_folder) + @"Items\";
                        break;
                }
                Tools.Folder.MakeFolderExist(unzip_folder);
                Tools.Zip.UnZipOneFile(f, unzip_folder);
                ArrayList add = new ArrayList();
                String[] files = System.IO.Directory.GetFiles(unzip_folder, "*.cs");
                foreach (string file in files)
                {
                    string raw_file = Tools.Files.GetFileName(file);
                    bool copy = true;
                    if (t == FileType.Items)
                    {
                        if (Tools.Files.FileExists(Tools.Folder.ConditionFolderName(proj_loc) + raw_file))
                            copy = false;
                    }
                    if (copy)
                    {
                        if (Tools.Files.FileExists(Tools.Folder.ConditionFolderName(proj_loc) + raw_file))
                            Tools.Files.TryDeleteFile(Tools.Folder.ConditionFolderName(proj_loc) + raw_file);
                        Tools.Files.CopyFile(file, Tools.Folder.ConditionFolderName(proj_loc) + raw_file);
                    }
                    add.Add(file);
                }
                UpdateProjectFile(add, project, t);
            }
            catch (Exception ee)
            {
                Tools.FileSystem.PopText("Error: " + ee.Message);
            }
        }
        private static void UpdateProjectFile(ArrayList files, string project, FileType t)
        {
            String projectFile = @"c:\Eternal\Code\" + project + @"\" + project + ".csproj";
            if (!File.Exists(projectFile))
                throw new Exception("Not found: " + projectFile);
            XmlDocument doc = new XmlDocument();
            doc.Load(projectFile);
            String nameSpace = "http://schemas.microsoft.com/developer/msbuild/2003";
            XmlNamespaceManager mgr = new XmlNamespaceManager(doc.NameTable);
            mgr.AddNamespace("x", nameSpace);
            XmlNode firstCompileNode = doc.SelectSingleNode("/x:Project/x:ItemGroup/x:Compile", mgr);
            XmlNode itemGroupNode = firstCompileNode.ParentNode;
            bool projectChanged = false;
            foreach (string s in files)
            {
                bool needs = true;
                String include = t.ToString() + "\\" + Tools.Files.GetFileName(s);
                foreach (XmlNode n in itemGroupNode.ChildNodes)
                {
                    if (n.Name == "Compile" && n.Attributes["Include"].Value == include)
                        needs = false;
                }
                if (needs)
                {
                    XmlNode newCompileNode = doc.CreateNode(XmlNodeType.Element, "Compile", nameSpace);
                    XmlAttribute newCompileNodeAttribute = doc.CreateAttribute("Include");
                    newCompileNodeAttribute.Value = include;
                    newCompileNode.Attributes.Append(newCompileNodeAttribute);
                    itemGroupNode.AppendChild(newCompileNode);
                    projectChanged = true;
                }
            }
            if (!projectChanged)
                return;
            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmlWriter = new XmlTextWriter(stringWriter);
            xmlWriter.Formatting = Formatting.Indented;
            doc.WriteTo(xmlWriter);
            xmlWriter.Flush();
            xmlWriter.Close();
            Tools.Files.SaveFileAsString(projectFile, stringWriter.ToString());
            stringWriter.Close();
            stringWriter = null;
        }
        private static bool Increment(string project)
        {
            String projectFile = @"c:\Eternal\Code\" + project + @"\Properties\AssemblyInfo.cs";
            if (!File.Exists(projectFile))
                throw new Exception("Not found: " + projectFile);
            int maj = 0;
            int min = 0;
            int rev = 0;
            int extra = 0;
            String ver = "";
            GetCurrentVersion(projectFile, ref maj, ref min, ref rev, ref extra, ref ver);
            String all = Tools.Files.OpenFileAsString(projectFile);
            extra++;
            if (extra > 9)
            {
                extra = 0;
                rev++;
            }
            if (rev > 9)
            {
                rev = 0;
                min++;
            }
            if (min > 9)
            {
                min = 0;
                maj++;
            }
            String newver = maj.ToString() + "." + min.ToString() + "." + rev.ToString() + "." + extra.ToString();
            all = all.Replace("[assembly: AssemblyVersion(\"" + ver + "\")]", "[assembly: AssemblyVersion(\"" + newver + "\")]");
            all = all.Replace("[assembly: AssemblyFileVersion(\"" + ver + "\")]", "[assembly: AssemblyFileVersion(\"" + newver + "\")]");
            Tools.Files.SaveFileAsString(projectFile, all);
            return true;
        }
        private static void GetCurrentVersion(string file, ref int maj, ref int min, ref int rev, ref int extra, ref String ver)
        {
            if (!File.Exists(file))
                return;
            String all = Tools.Files.OpenFileAsString(file);
            ver = Tools.Strings.ParseDelimit(all, "\r\n[assembly: AssemblyVersion(\"", 2);
            ver = Tools.Strings.ParseDelimit(ver, "\"", 1);
            String[] nums = Tools.Strings.Split(ver, ".");
            maj = Int32.Parse(nums[0]);
            min = Int32.Parse(nums[1]);
            rev = Int32.Parse(nums[2]);
            extra = Int32.Parse(nums[3]);
        }
        enum FileType
        {
            Auto = 0,
            Items = 1
        }
    }
}
