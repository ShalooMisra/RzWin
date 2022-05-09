using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Xml;

using Core;
using System.Data;

namespace CoreDevelop
{
    public class BoxSys : Box
    {
        public static String HoldRoot = @"c:\Bilge\CoreDevelop\";
        public static String BilgePath = @"c:\Bilge\";

        string InitName = "";
        public override String Name
        {
            get
            {
                if (TheAttribute != null)
                    return TheAttribute.Name;
                return InitName;
            }
        }

        public static void HoldClear()
        {
            foreach (String dir in Directory.GetDirectories(HoldRoot))
            {
                if (dir.StartsWith("Holding_"))
                {
                    String del = Tools.Folder.ConditionFolderName(dir) + "delete_at_will.txt";
                    if (File.Exists(del))
                    {
                        if (Tools.Folder.FolderObliterate(dir))
                            Directory.Delete(dir);
                    }
                }

                if (dir == "CodeArchive")
                {
                    Tools.Folder.DeleteOldFilesRecurse(dir, DateTime.Now.Subtract(TimeSpan.FromDays(31)));
                }
            }
        }

        public String ClassCaption(String classId)
        {
            if (Classes.ContainsKey(classId))
                return Classes[classId].TheAttribute.Caption;
            else
                return null;
        }

        public void Rename(String newName)
        {
            String oldName = Name;
            String oldFolder = TheTag.CodePath;
            String oldDll = TheTag.FileNameDll;
            String oldSln = TheTag.FileNameSln;
            String oldProj = TheTag.CodePath + Name + ".csproj";

            TheTag.CodePath = TheTag.CodePath.Replace(@"\" + TheAttribute.Name + @"\", @"\" + newName + @"\");
            TheTag.FileNameDll = TheTag.FileNameDll.Replace(@"\" + TheAttribute.Name + @"\", @"\" + newName + @"\");
            TheTag.FileNameSln = TheTag.FileNameSln.Replace(@"\" + TheAttribute.Name + @"\", @"\" + newName + @"\").Replace(TheAttribute.Name + ".sln", newName + ".sln");
            
            TheAttribute.Name = newName;
            TheAttribute.Caption = newName;

            //rename the directory
            Directory.CreateDirectory(TheTag.CodePath);
            File.Copy(oldSln, TheTag.FileNameSln);

            File.Copy(oldProj, TheTag.CodePath + Name + ".csproj");

            String slnText = Tools.Files.OpenFileAsString(TheTag.FileNameSln);
            slnText = slnText.Replace(" = \"" + oldName + "\", \"" + oldName + ".csproj\",", " = \"" + newName + "\", \"" + newName + ".csproj\",");
            Tools.Files.SaveStringAsFile(TheTag.FileNameSln, slnText);

            String projText = Tools.Files.OpenFileAsString(TheTag.CodePath + Name + ".csproj");
            projText = projText.Replace("<RootNamespace>" + oldName + "</RootNamespace>", "<RootNamespace>" + newName + "</RootNamespace>");
            projText = projText.Replace("<AssemblyName>" + oldName + "</AssemblyName>", "<AssemblyName>" + newName + "</AssemblyName>");
            projText = projText.Replace("<Compile Include=\"Auto\\Sys" + oldName + "_auto.cs\" />", "<Compile Include=\"Auto\\Sys" + newName + "_auto.cs\" />");
            projText = projText.Replace("<Compile Include=\"Sys" + oldName + ".cs\" />", "<Compile Include=\"Sys" + newName + ".cs\" />");
            Tools.Files.SaveStringAsFile(TheTag.CodePath + Name + ".csproj", projText);

            Directory.CreateDirectory(TheTag.CodePath + @"Properties\");
            File.Copy(oldFolder + @"Properties\AssemblyInfo.cs", TheTag.CodePath + @"Properties\AssemblyInfo.cs");
            String propText = Tools.Files.OpenFileAsString(TheTag.CodePath + @"Properties\AssemblyInfo.cs");
            propText = propText.Replace("[assembly: AssemblyTitle(\"" + oldName + "\")]", "[assembly: AssemblyTitle(\"" + newName + "\")]");
            Tools.Files.SaveStringAsFile(TheTag.CodePath + @"Properties\AssemblyInfo.cs", propText);

            Directory.CreateDirectory(TheTag.CodePath + @"Auto\");
            Write();
        }

        public void Duplicate(String uid)
        {
            String oldFolder = TheTag.CodePath;
        }

        public SystemTag TheTag;
        public Assembly TheAssembly;

        public BoxSys(Context context, SystemTag t, bool build = true)
            : this(Path.GetFileNameWithoutExtension(t.FileNameDll))
        {            
            TheTag = t;
            Load((ContextDevelop)context, build);
        }

        public BoxSys(String name)
            : base(null)
        {
            InitName = name;
        }

        String LoadSession = "";
        String HoldFolder = "";
        bool LKGMode = false;
        String LKGFolder = "";
        public bool Load(ContextDevelop context, bool build = true)
        {
            //it must build, or the .dll can't be loaded with whatever changes might be in the source, but not in the compiled .dll
            LKGMode = false;
            if (!Directory.Exists(TheTag.LastKnownGoodPath) || !Tools.Files.FileExists(TheTag.LastKnownGoodPath + Tools.Files.GetFileName(TheTag.FileNameDll)))
                build = true;
            if (build)
            {
                if (!BuildSln(context))
                {
                    if (!Directory.Exists(TheTag.LastKnownGoodPath))
                    {
                        context.TheLeader.Tell("No last known good configuration was found");
                        return false;
                    }
                    if (context.TheLeader.AskYesNo("A last known good configuration was found for " + TheTag.Name + ".  Do you want to load it?"))
                        LKGMode = true;
                    else
                        return false;
                }
            }
            else
                LKGMode = true;           
            //move to a holding area
            LoadSession = "Holding_" + TheTag.Name + "_" + Tools.Dates.GetNowPathHMS() + "_" + Tools.Strings.GetNewID();
            HoldFolder = HoldRoot + LoadSession + @"\";
            String hold_file = HoldFolder + Path.GetFileName(TheTag.FileNameDll);
            context.TheLeader.Tell("hold_file : " + hold_file);
            Directory.CreateDirectory(HoldFolder);
            String use_dll = TheTag.FileNameDll;
            if (LKGMode)
                use_dll = TheTag.LastKnownGoodPath + Path.GetFileName(TheTag.FileNameDll);
            File.Copy(use_dll, hold_file);


            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);


            try
            {
                TheAssembly = Assembly.LoadFile(hold_file);  //TheTag.FileNameDll
                SystemLoad(TheAssembly);
                ClassesLoad(context, TheAssembly);
            }
            catch (Exception ex)
            {
                context.TheLeader.Error("Load error: " + ex.Message);
                BoxSys.WriteLog("ClassesLoad(context, TheAssembly); ERROR: " + ex.Message);
            }


            AppDomain.CurrentDomain.AssemblyResolve -= new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            if (!LKGMode)
            {
                //copy this as the LKG
                String lkg = TheTag.LastKnownGoodPath;
                if (!Directory.Exists(lkg))
                    Directory.CreateDirectory(lkg);
                else
                    Tools.Folder.FolderObliterate(lkg);
                Tools.Folder.Copy(HoldFolder, lkg);
            }
            Tools.FileSystem.SaveFileAsString(HoldFolder + "delete_at_will.txt", "delete");
            return true;
        }

        Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            //find the referenced .dll, and move it, and return the temp name    
            String original_file = "";
            if (LKGMode)
                original_file = TheTag.LastKnownGoodPath + Tools.Strings.ParseDelimit(args.Name, ",", 1).Trim() + ".dll";
            else
                original_file = Path.GetDirectoryName(TheTag.FileNameDll) + @"\" + Tools.Strings.ParseDelimit(args.Name, ",", 1).Trim() + ".dll";
            String hold_file = HoldFolder + Path.GetFileName(original_file);
            if (!File.Exists(hold_file))
                File.Copy(original_file, hold_file);
            return Assembly.LoadFile(hold_file);
        }

        void SystemLoad(Assembly assembly)
        {
            Type[] ts = assembly.GetTypes();
            foreach (Type t in ts)
            {
                Object[] attrs = t.GetCustomAttributes(typeof(CoreSysAttribute), false);  //should this be inherit or not?
                if (attrs.Length > 0)
                {
                    CoreSysAttribute attr = (CoreSysAttribute)attrs[0];

                    switch (t.BaseType.FullName)
                    {
                        case "Core.Sys":
                            break;
                        default:
                            attr.BaseSystem = t.BaseType.FullName;
                            break;
                    }

                    this.TheAttribute = attr;
                    break;
                }
            }
        }

        public Dictionary<String, BoxClass> Classes = new Dictionary<string, BoxClass>();
        void ClassesLoad(ContextDevelop context, Assembly assembly)
        {
            context.TheDeltaDevelop.WriteSystem(this);
            Type[] ts = assembly.GetTypes();
            foreach (Type t in ts)
            {
                Object[] attrs = t.GetCustomAttributes(typeof(CoreClassAttribute), false);  //should this be inherit or not?
                if (attrs.Length > 0)
                {
                    CoreClassAttribute attr = (CoreClassAttribute)attrs[0];
                    switch (t.BaseType.FullName)
                    {
                        case "Core.Item":
                            break;
                        default:
                            attr.BaseClass = t.BaseType.FullName;
                            break;
                    }
                    BoxSys.WriteLog("ClassAdd " + t.ToString());                
                    ClassAdd(context, new BoxClass(this, attr, t, assembly));
                }
            }
        }
        public static void WriteLog(string write)
        {
            string logfile = @"c:\bilge\logfile\log.txt";
            StringBuilder sb = new StringBuilder();
            string add = "";
            if (Tools.Files.FileExists(logfile))
                add = Tools.Files.OpenFileAsString(logfile);
            if (Tools.Strings.StrExt(add))
                sb.AppendLine(add);
            sb.AppendLine(write);
            Tools.Files.SaveFileAsString(logfile, sb.ToString());
        }
        public void ClassAdd(ContextDevelop context, BoxClass c)
        {
            c.TheClassAttribute.SysName = this.Name;
            Classes.Add(c.Name, c);
            context.TheDeltaDevelop.WriteClass(c);
        }

        public void ClassRemove(ContextDevelop context, BoxClass c)
        {
            Classes.Remove(c.Name);
            c.Write(true);
            context.TheDeltaDevelop.WriteSystem(this);
        }

        public bool BuildSln(Context context)
        {
            String strConfig = "Debug";

            String strBat = Tools.Folder.ConditionFolderName(Tools.Folder.GetParentFolder(TheTag.FileNameSln)) + "build.bat";  //moved to the solution folder; otherwise simultaneous builds could happen
            String c = "cd C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\r\nMSBuild.exe " + TheTag.FileNameSln + " /p:Configuration=" + strConfig + " /p:Platform=\"Any CPU\"";  //roperty
            Tools.Files.SaveFileAsString(strBat, c);

            String ret = "";
            if (!Tools.FileSystem.ShellAndViewOutput(strBat, "", ref ret, ""))
            {
                Tools.FileSystem.PopText(ret);
                context.TheLeader.Error("Build batch run on " + TheTag.FileNameSln + " failed");
                Tools.FileSystem.SaveFileAsString(@"c:\Test\build_err_" + Tools.Strings.GetNewID() + ".txt", ret);
                return false;
            }

            if (Tools.Strings.HasString(ret, " 0 Error(s)"))
                return true;
            else
            {
                Tools.FileSystem.PopText(ret);
                context.TheLeader.Error("Build result on " + TheTag.FileNameSln + " failed");
                Tools.FileSystem.SaveFileAsString(@"c:\Test\build_err_" + Tools.Strings.GetNewID() + ".txt", ret);
                return false;
            }
        }

        public void Write()
        {
            String code_file = CodeBaseFileFind();
            String code_data = Render();

            if (File.Exists(code_file))
            {
                String folder = @"c:\Bilge\CoreDevelop\CodeArchive\";
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                folder += Name + @"\";
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                String archive_name = folder + Path.GetFileNameWithoutExtension(code_file) + "_" + Tools.Folder.GetNowPathPlusTime() + ".cs";
                try { File.Copy(code_file, archive_name); }
                catch (Exception ee)
                { string ss = ee.Message; }
            }

            String parentFolder = Path.GetDirectoryName(code_file);
            if( !Directory.Exists(parentFolder) )
                Directory.CreateDirectory(parentFolder);

            //if( !Tools.Files.SaveFileAsString(code_file, code_data) )
            //    throw new Exception("File save failed on " + code_file);


            try
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(code_file, false);
                file.Write(code_data);
                file.Close();
            }
            catch (Exception ee)
            {
                throw new Exception("File save failed on " + code_file + " : " + ee.Message);
            }


            //check to create the editable file
            LiveFileCheck();
        }

        void LiveFileCheck()
        {
            String live = CodeLiveFileFind();
            if (!File.Exists(live))
            {
                CodeBuilder cb = new CodeBuilder();

                cb.AppendLine("using System;");
                cb.AppendLine("using System.Collections.Generic;");
                cb.AppendLine("using System.Text;");
                cb.AppendLine("");
                cb.AppendLine("using Core;");
                cb.AppendLine("");
                cb.AppendLine("namespace " + Name + "");
                cb.AppendLine("{");
                cb.AppendLine("    public class Sys" + Name + " : Sys" + Name + "_auto");
                cb.AppendLine("    {");
                cb.AppendLine("");
                cb.AppendLine("    }");
                cb.AppendLine("}");

                Tools.Files.SaveStringAsFile(live, cb.ToString(), true);
            }
        }

        public String CodeBaseFileFind()
        {
            return Tools.Folder.ConditionFolderName(TheTag.CodePath) + @"Auto\Sys" + Name + "_auto.cs";
        }

        public String CodeLiveFileFind()
        {
            return Tools.Folder.ConditionFolderName(TheTag.CodePath) + "Sys" + Name + ".cs";
        }

        public String Render()
        {
            CodeBuilder cb = new CodeBuilder();
            //Using
            cb.AppendLine("using System;");
            cb.AppendLine("using System.Collections.Generic;");
            cb.AppendLine("using System.Text;");
            cb.AppendLine("using System.Reflection;");
            cb.AppendLine("");
            cb.AppendLine("using Core;");
            cb.AppendLine("");
            cb.AppendLine("namespace " + Name + "");
            cb.AppendLine("{");
            if (TheAttribute != null)
                TheAttribute.RenderDeclare(cb);
            else
            {
                cb.AppendLine("    [CoreSys(\"" + Name + "\")]");
                cb.AppendLine("    public class Sys" + Name + "_auto : Sys");
            }
            cb.AppendLine("    {");
            //foreach (BoxClass c in ClassesList)
            //{
            //    if (c.TheClassAttribute.LowestLevelIs)
            //    {
            //        cb.AppendLine("        " + c.Name + "Logic m_The" + c.Name + "Logic = null;");
            //        cb.AppendLine("        public " + c.Name + "Logic The" + c.Name + "Logic");
            //        cb.AppendLine("        {");
            //        cb.AppendLine("            get");
            //        cb.AppendLine("            {");
            //        cb.AppendLine("                if (m_The" + c.Name + "Logic == null)");
            //        cb.AppendLine("                    m_The" + c.Name + "Logic = " + c.Name + "LogicCreate();");
            //        cb.AppendLine("                return m_The" + c.Name + "Logic;");
            //        cb.AppendLine("            }");
            //        cb.AppendLine("        }");
            //        cb.AppendLine("");
            //        cb.AppendLine("        protected virtual " + c.Name + "Logic " + c.Name + "LogicCreate()");
            //        cb.AppendLine("        {");
            //        cb.AppendLine("            return new " + c.Name + "Logic();");
            //        cb.AppendLine("        }");
            //    }
            //}
            //cb.AppendLine("");
            cb.AppendLine("        protected override void AssemblyList(List<Assembly> ret)");
            cb.AppendLine("        {");
            cb.AppendLine("            ret.Add(Assembly.GetExecutingAssembly());");
            cb.AppendLine("            base.AssemblyList(ret);");
            cb.AppendLine("        }");
            cb.AppendLine("    }");
            cb.AppendLine("}");
            return cb.ToString();
        }

        //public void ProjectActionRequest(String verb, String file)
        //{
        //    String folder = @"c:\Bilge\CoreDevelop";

        //}

        public List<BoxClass> ClassesList
        {
            get
            {
                List<BoxClass> ret = new List<BoxClass>();
                foreach (KeyValuePair<String, BoxClass> k in Classes)
                {
                    ret.Add(k.Value);
                }
                return ret;
            }
        }

        public List<String> ClassCaptionsList
        {
            get
            {
                List<String> ret = new List<String>();
                foreach (KeyValuePair<String, BoxClass> k in Classes)
                {
                    ret.Add(k.Value.TheClassAttribute.Caption);
                }
                return ret;
            }
        }

        public BoxClass ClassGet(String name)
        {
            if (!Tools.Strings.StrExt(name))
                return null;
            foreach (KeyValuePair<String, BoxClass> k in Classes)
            {
                if (!Tools.Strings.StrCmp(k.Key, name))
                    continue;
                return k.Value;
            }
            return null;
        }

        public BoxClass ClassGetByCaption(String caption)
        {
            if (!Tools.Strings.StrExt(caption))
                return null;
            foreach (KeyValuePair<String, BoxClass> k in Classes)
            {
                if (!Tools.Strings.StrCmp(k.Value.TheClassAttribute.Caption, caption))
                    continue;
                return k.Value;
            }
            return null;
        }

        public BoxClass ClassAdd(ContextDevelop context)
        {
            String caption = context.TheLeader.AskForString("Class name");
            if (!Tools.Strings.StrExt(caption))
                return null;

            return ClassAdd(context, Tools.Strings.FilterTrash(caption), caption);
        }

        public BoxClass ClassAdd(ContextDevelop context, String name, String caption)
        {
            name = MakeValidIdentifierClass(name);
            if (!ClassNameValid(context, name))
                throw new Exception("Invalid class name");
            CoreClassAttribute attr = new CoreClassAttribute(name);
            attr.Importance = Classes.Count;
            BoxClass ret = new BoxClass(this, attr);
            ClassAdd(context, ret);
            ret.TheAttribute.Caption = Tools.Strings.NiceFormat(caption);
            return ret;
        }

        public bool ClassNameValid(Context context, String name)
        {
            if (!Tools.Strings.StrExt(name))
            {
                context.TheLeader.Error("Blank name");
                return false;
            }

            return true;
        }

        public bool WriteNewSln(ContextDevelop context)
        {
            if (!Directory.Exists(TheTag.CodePath))
                Directory.CreateDirectory(TheTag.CodePath);

            String id = Tools.Strings.GetNewID();

            Write();

            //make the .sln file
            String sln = Tools.Files.OpenFileAsString(BoxSys.TemplateSolutionPath);
            sln = sln.Replace("<CoreDevelopSolutionName>", this.Name);
            sln = sln.Replace("<CoreDevelopProjectId>", id);
            Tools.Files.SaveFileAsString(TheTag.FileNameSln, sln);            

            String proj = Tools.Files.OpenFileAsString(BoxSys.TemplateProjectPath);
            proj = proj.Replace("<CoreDevelopSolutionName>", this.Name);
            proj = proj.Replace("<CoreDevelopProjectId>", Tools.Strings.GetNewID());

            //<CoreDevelopClasses>
            //    <Compile Include="Sys<CoreDevelopSolutionName>.cs" />

            StringBuilder sb = new StringBuilder();
            bool first = true;
            foreach (BoxClass c in ClassesList)
            {
                c.Write();

                if (!first)
                    sb.Append("\r\n");

                sb.AppendLine("<Compile Include=\"Auto\\" + c.Name + "_auto.cs\" />");
                sb.Append("<Compile Include=\"Items\\" + c.Name + ".cs\" />");

                first = false;
            }

            proj = proj.Replace("<CoreDevelopClasses>", sb.ToString());
            proj = proj.Replace("<OtherReferences>", OtherReferencesRender());

            Tools.Files.SaveFileAsString(TheTag.CodePath + Name + ".csproj", proj);

            String assembly_info = Tools.Files.OpenFileAsString(BoxSys.TemplateAssemblyInfoPath);
            assembly_info = assembly_info.Replace("<CoreDevelopSolutionName>", this.Name);
            Tools.Files.SaveStringAsFile(TheTag.CodePath + @"Properties\AssemblyInfo.cs", assembly_info, true);

            return true;
        }

        public void UpdateProjectFiles(ContextDevelop context)
        {
            String projectFile = TheTag.CodePath + Name + ".csproj";
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

            //remove deleted classes

            List<XmlNode> nodes = new List<XmlNode>();
            foreach (XmlNode n in itemGroupNode.ChildNodes)
            {
                nodes.Add(n);
            }

            foreach (XmlNode n in nodes)
            {
                if (n.Name != "Compile")
                    continue;

                String include = "";
                try
                { include = n.Attributes["Include"].Value; }
                catch { continue; }

                if (include.StartsWith(@"Items\") || include.StartsWith(@"Auto\"))
                {
                    String className = Tools.Strings.ParseDelimit(include, @"\", 2);
                    if (className.EndsWith("_auto.cs"))
                        className = Tools.Strings.ParseDelimit(className, "_auto.cs", 1);
                    else
                        className = Tools.Strings.ParseDelimit(className, ".cs", 1);

                    if (className == "Sys" + Name)
                        continue;


                    BoxClass cls = ClassGet(className);
                    if (cls == null)
                    {
                        itemGroupNode.RemoveChild(n);
                        projectChanged = true;
                    }
                }
            }

            foreach (BoxClass c in ClassesList)
            {
                c.Write();

                bool needsAuto = true;
                String includeAuto = @"Auto\" + c.Name + "_auto.cs";

                bool needsEditable = true;
                String includeEditable = @"Items\" + c.Name + ".cs";

                foreach (XmlNode n in itemGroupNode.ChildNodes)
                {
                    if (n.Name == "Compile" && n.Attributes["Include"].Value == includeAuto)
                        needsAuto = false;

                    if (n.Name == "Compile" && n.Attributes["Include"].Value == includeEditable)
                        needsEditable = false;
                }

                if (needsAuto)
                {
                    XmlNode newCompileNode = doc.CreateNode(XmlNodeType.Element, "Compile", nameSpace);
                    XmlAttribute newCompileNodeAttribute = doc.CreateAttribute("Include");
                    newCompileNodeAttribute.Value = includeAuto;
                    newCompileNode.Attributes.Append(newCompileNodeAttribute);
                    itemGroupNode.AppendChild(newCompileNode);
                    projectChanged = true;
                }

                if (needsEditable)
                {
                    XmlNode newCompileNode = doc.CreateNode(XmlNodeType.Element, "Compile", nameSpace);
                    XmlAttribute newCompileNodeAttribute = doc.CreateAttribute("Include");
                    newCompileNodeAttribute.Value = includeEditable;
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

        public BoxClass ClassChoose(ContextDevelop context, BoxClass from)
        {
            String name = context.ClassChoose(context, this, from);
            if (!Tools.Strings.StrExt(name))
                return null;
            if (!Classes.ContainsKey(name))
                return null;
            return Classes[name];
        }

        public List<ProjectReference> OtherReferences = new List<ProjectReference>();
        public String OtherReferencesRender()
        {
            StringBuilder sb = new StringBuilder();

            foreach (ProjectReference r in OtherReferences)
            {
                sb.AppendLine("    <Reference Include=\"" + r.Name + "\">\r\n      <HintPath>" + r.Path + "</HintPath>\r\n    </Reference>");
            }

            return sb.ToString();
        }

        public static String TemplateSolutionPath = @"c:\Eternal\Code\Core\CoreDevelop\Templates\Solution.sln";
        public static String TemplateProjectPath = @"c:\Eternal\Code\Core\CoreDevelop\Templates\Project.csproj";
        public static String TemplateAssemblyInfoPath = @"c:\Eternal\Code\Core\CoreDevelop\Templates\AssemblyInfo.cs";

        public static void SetTemplatePath(String folder)
        {
            TemplateSolutionPath = Tools.Folder.ConditionFolderName(folder) + Path.GetFileName(TemplateSolutionPath);
            TemplateProjectPath = Tools.Folder.ConditionFolderName(folder) + Path.GetFileName(TemplateProjectPath);
            TemplateAssemblyInfoPath = Tools.Folder.ConditionFolderName(folder) + Path.GetFileName(TemplateAssemblyInfoPath);
        }

        static Microsoft.CSharp.CSharpCodeProvider codeProvider;
        public static String MakeValidIdentifier(String ident)
        {
            if (!Tools.Strings.StrExt(ident))
                throw new Exception("Blank identifier");

            if (codeProvider == null)
                codeProvider = new Microsoft.CSharp.CSharpCodeProvider();

            ident = Tools.Strings.FilterTrashExceptUnderscore(ident);

            //must be a valid c# and sql identifier
            int i = 0;
            while (!codeProvider.IsValidIdentifier(ident) || IsSqlKeyword(ident))
            {
                ident = "x" + ident;  //pre-pend the x to cover for numeric strings
                i++;

                if (i > 5)
                    throw new Exception("Identifier error: " + ident);
            }

            return ident;
        }

        public static String MakeValidIdentifierClass(String ident)
        {
            if( !Tools.Strings.StrExt(ident) )
                return "c" + Tools.Strings.GetNewID();

            String ret = MakeValidIdentifier(ident);
            if (ret.ToLower().EndsWith("base"))
                ret = ret + "x";
            return ret;
        }

        public static String MakeValidIdentifierVar(String ident)
        {
            if (!Tools.Strings.StrExt(ident))
                return "v" + Tools.Strings.GetNewID();

            String ret = MakeValidIdentifier(ident);
            if (ret.ToLower().EndsWith("var"))
                ret = ret + "x";
            return ret;
        }

        const String SqlKeywords = "|ABSOLUTE|ACTION|ADA|ADD|ADMIN|AFTER|AGGREGATE|ALIAS|ALL|ALLOCATE|ALTER|AND|ANY|ARE|ARRAY|AS|ASC|ASENSITIVE|ASSERTION|ASYMMETRIC|AT|ATOMIC|AUTHORIZATION|AVG|BACKUP|BEFORE|BEGIN|BETWEEN|BINARY|BIT|BIT_LENGTH|BLOB|BOOLEAN|BOTH|BREADTH|BREAK|BROWSE|BULK|BY|CALL|CALLED|CARDINALITY|CASCADE|CASCADED|CASE|CAST|CATALOG|CHAR|CHAR_LENGTH|CHARACTER|CHARACTER_LENGTH|CHECK|CHECKPOINT|CLASS|CLOB|CLOSE|CLUSTERED|COALESCE|COLLATE|COLLATION|COLLECT|COLUMN|COMMIT|COMPLETION|COMPUTE|CONDITION|CONNECT|CONNECTION|CONSTRAINT|CONSTRAINTS|CONSTRUCTOR|CONTAINS|CONTAINSTABLE|CONTINUE|CONVERT|CORR|CORRESPONDING|COUNT|COVAR_POP|COVAR_SAMP|CREATE|CROSS|CUBE|CUME_DIST|CURRENT|CURRENT_CATALOG|CURRENT_DATE|CURRENT_DEFAULT_TRANSFORM_GROUP|CURRENT_PATH|CURRENT_ROLE|CURRENT_SCHEMA|CURRENT_TIME|CURRENT_TIMESTAMP|CURRENT_TRANSFORM_GROUP_FOR_TYPE|CURRENT_USER|CURSOR|CYCLE|DATA|DATABASE|DATE|DAY|DBCC|DEALLOCATE|DEC|DECIMAL|DECLARE|DEFAULT|DEFERRABLE|DEFERRED|DELETE|DENY|DEPTH|DEREF|DESC|DESCRIBE|DESCRIPTOR|DESTROY|DESTRUCTOR|DETERMINISTIC|DIAGNOSTICS|DICTIONARY|DISCONNECT|DISK|DISTINCT|DISTRIBUTED|DOMAIN|DOUBLE|DROP|DUMP|DYNAMIC|EACH|ELEMENT|ELSE|END|END-EXEC|EQUALS|ERRLVL|ESCAPE|EVERY|EXCEPT|EXCEPTION|EXEC|EXECUTE|EXISTS|EXIT|EXTERNAL|EXTRACT|FALSE|FETCH|FILE|FILLFACTOR|FILTER|FIRST|FLOAT|FOR|FOREIGN|FORTRAN|FOUND|FREE|FREETEXT|FREETEXTTABLE|FROM|FULL|FULLTEXTTABLE|FUNCTION|FUSION|GENERAL|GET|GLOBAL|GO|GOTO|GRANT|GROUP|GROUPING|HAVING|HOLD|HOLDLOCK|HOST|HOUR|IDENTITY|IDENTITY_INSERT|IDENTITYCOL|IF|IGNORE|IMMEDIATE|IN|INCLUDE|INDEX|INDICATOR|INITIALIZE|INITIALLY|INNER|INOUT|INPUT|INSENSITIVE|INSERT|INT|INTEGER|INTERSECT|INTERSECTION|INTERVAL|INTO|IS|ISOLATION|ITERATE|JOIN|KEY|KILL|LANGUAGE|LARGE|LAST|LATERAL|LEADING|LEFT|LESS|LEVEL|LIKE|LIKE_REGEX|LIMIT|LINENO|LN|LOAD|LOCAL|LOCALTIME|LOCALTIMESTAMP|LOCATOR|LOWER|MAP|MATCH|MAX|MEMBER|MERGE|METHOD|MIN|MINUTE|MOD|MODIFIES|MODIFY|MODULE|MONTH|MULTISET|NAMES|NATIONAL|NATURAL|NCHAR|NCLOB|NEW|NEXT|NO|NOCHECK|NONCLUSTERED|NONE|NORMALIZE|NOT|NULL|NULLIF|NUMERIC|OBJECT|OCCURRENCES_REGEX|OCTET_LENGTH|OF|OFF|OFFSETS|OLD|ON|ONLY|OPEN|OPENDATASOURCE|OPENQUERY|OPENROWSET|OPENXML|OPERATION|OPTION|OR|ORDER|ORDINALITY|OUT|OUTER|OUTPUT|OVER|OVERLAPS|OVERLAY|PAD|PARAMETER|PARAMETERS|PARTIAL|PARTITION|PASCAL|PATH|PERCENT|PERCENT_RANK|PERCENTILE_CONT|PERCENTILE_DISC|PIVOT|PLAN|POSITION|POSITION_REGEX|POSTFIX|PRECISION|PREFIX|PREORDER|PREPARE|PRESERVE|PRIMARY|PRINT|PRIOR|PRIVILEGES|PROC|PROCEDURE|PUBLIC|RAISERROR|RANGE|READ|READS|READTEXT|REAL|RECONFIGURE|RECURSIVE|REF|REFERENCES|REFERENCING|REGR_AVGX|REGR_AVGY|REGR_COUNT|REGR_INTERCEPT|REGR_R2|REGR_SLOPE|REGR_SXX|REGR_SXY|REGR_SYY|RELATIVE|RELEASE|REPLICATION|RESTORE|RESTRICT|RESULT|RETURN|RETURNS|REVERT|REVOKE|RIGHT|ROLE|ROLLBACK|ROLLUP|ROUTINE|ROW|ROWCOUNT|ROWGUIDCOL|ROWS|RULE|SAVE|SAVEPOINT|SCHEMA|SCOPE|SCROLL|SEARCH|SECOND|SECTION|SECURITYAUDIT|SELECT|SEMANTICKEYPHRASETABLE|SEMANTICSIMILARITYDETAILSTABLE|SEMANTICSIMILARITYTABLE|SENSITIVE|SEQUENCE|SESSION|SESSION_USER|SET|SETS|SETUSER|SHUTDOWN|SIMILAR|SIZE|SMALLINT|SOME|SPACE|SPECIFIC|SPECIFICTYPE|SQL|SQLCA|SQLCODE|SQLERROR|SQLEXCEPTION|SQLSTATE|SQLWARNING|START|STATE|STATEMENT|STATIC|STATISTICS|STDDEV_POP|STDDEV_SAMP|STRUCTURE|SUBMULTISET|SUBSTRING|SUBSTRING_REGEX|SUM|SYMMETRIC|SYSTEM|SYSTEM_USER|TABLE|TABLESAMPLE|TEMPORARY|TERMINATE|TEXTSIZE|THAN|THEN|TIME|TIMESTAMP|TIMEZONE_HOUR|TIMEZONE_MINUTE|TO|TOP|TRAILING|TRAN|TRANSACTION|TRANSLATE|TRANSLATE_REGEX|TRANSLATION|TREAT|TRIGGER|TRIM|TRUE|TRUNCATE|TRY_CONVERT|TSEQUAL|UESCAPE|UNDER|UNION|UNIQUE|UNKNOWN|UNNEST|UNPIVOT|UPDATE|UPDATETEXT|UPPER|USAGE|USE|USER|USING|VALUE|VALUES|VAR_POP|VAR_SAMP|VARCHAR|VARIABLE|VARYING|VIEW|WAITFOR|WHEN|WHENEVER|WHERE|WHILE|WIDTH_BUCKET|WINDOW|WITH|WITHIN|WITHIN GROUP|WITHOUT|WORK|WRITE|WRITETEXT|XMLAGG|XMLATTRIBUTES|XMLBINARY|XMLCAST|XMLCOMMENT|XMLCONCAT|XMLDOCUMENT|XMLELEMENT|XMLEXISTS|XMLFOREST|XMLITERATE|XMLNAMESPACES|XMLPARSE|XMLPI|XMLQUERY|XMLSERIALIZE|XMLTABLE|XMLTEXT|XMLVALIDATE|YEAR|ZONE|";

        public static bool IsSqlKeyword(String ident)
        {
            return SqlKeywords.Contains("|" + ident.ToUpper() + "|");
        }

        public bool ClassContainsAnyCase(String name, String caption)  //does not allow case mixing
        {
            foreach(BoxClass c in this.ClassesList)
            {
                if (Tools.Strings.StrCmp(c.Name, name) || ( caption != "" && Tools.Strings.StrCmp(c.TheAttribute.Caption, caption)))
                    return true;
            }
            return false;
        }

        public String AbsorbDataFile(Context x, ContextDevelop structure, string localPath, string class_name = "")
        {
            switch (Path.GetExtension(localPath).ToLower())
            {
                case ".csv":
                    return AbsorbDataFileCsv(x, structure, localPath, class_name);
                case ".xls":
                    return AbsorbDataFileExcel(x, structure, localPath, class_name);
                case ".xlsx":
                    return AbsorbDataFileExcelXml(x, structure, localPath, class_name);
                default:
                    return "";
            }
        }
        public String AbsorbDataFileCsv(Context x, ContextDevelop structure, String path, string class_name = "")
        {
            List<String> lines = Tools.Strings.SplitLinesList(Tools.Files.OpenFileAsString(path));
            String heading = lines[0];
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < lines.Count; i++)
            {
                if (!Tools.Strings.StrExt(lines[i]))
                    continue;
                sb.AppendLine(lines[i]);
            }
            if (!Tools.Strings.StrExt(sb.ToString()))
                return "";
            Tools.Files.SaveStringAsFile(path, sb.ToString());
            String table = "";
            if (!x.Data.Connection.ImportDelimitedFileToTable(path, ',', ref table))
                return "";
            List<String> headings = new List<string>();
            bool inQuotes = false;
            String current = "";
            foreach (Char ch in heading.ToCharArray())
            {
                if( ch == '\"' )
                    inQuotes = !inQuotes;
                else if( ch != ',' || inQuotes )
                    current += ch;
                else if( ch == ',')
                {
                    headings.Add(current.Trim());
                    current = "";
                }
            }
            if (Tools.Strings.StrExt(current))
                headings.Add(current.Trim());
            String name = Path.GetFileNameWithoutExtension(path);
            if (Tools.Strings.StrExt(class_name))
                name = class_name;
            BoxClass c = null;
            try
            {
                c = ClassAdd(structure, name.ToLower(), name);
            }
            catch (Exception ee)
            {
                if (Tools.Strings.StrCmp(ee.Message, "An item with the same key has already been added."))
                {
                    x.TheLeader.Tell("A list named [" + name + "] already exists and cannot be created. Skipping...");
                    return name;
                }
            }
            c.TheClassAttribute.MenuItem = true;
            int index = 0;
            List<String> headingsUsed = new List<string>();
            foreach (DataColumn col in x.Select("select top 1 * from " + table).Columns)
            {
                String colHeading = "Detail " + index.ToString();
                if (index < headings.Count)
                    colHeading = headings[index];
                int counter = 1;
                String headingBase = colHeading;
                while( headingsUsed.Contains(colHeading.ToLower()) )
                {
                    colHeading = headingBase + " " + counter.ToString();
                    counter++;
                }
                headingsUsed.Add(colHeading.ToLower());
                String fieldName = BoxSys.MakeValidIdentifier(colHeading.ToLower());
                x.TheData.Connection.RenameField(table, col.Caption, fieldName);
                BoxVar v = c.VarAdd(structure, new ClassExpandArgs(fieldName, colHeading, Tools.Database.FieldType.String));
                if (index == 0)
                    v.TheVarAttribute.SearchCriteria = true;
                index++;
            }
            x.Execute("alter table " + table + " add unique_id varchar(256)");
            x.Execute("update " + table + " set " + x.Data.UidField + " = cast(newid() as varchar(256))");
            x.Data.Connection.RenameTable(table, c.TheClassAttribute.Name);
            return c.TheClassAttribute.Name;
        }
        public String AbsorbDataFileExcel(Context x, ContextDevelop structure, String path, string class_name = "")
        {
            string return_class = "";
            string folder = CheckUnZipFolder(path);
            ToolsOffice.ExcelOffice.Excel2CSV(x, path, folder);
            string[] files = Directory.GetFiles(folder, "*.csv");
            foreach (string f in files)
            {
                if (!Tools.Files.FileExists(f))
                    continue;
                if (!Tools.Strings.StrExt(Tools.Files.OpenFileAsString(f)))
                    continue;
                String name = Tools.Files.GetFileNameNoExtention(f).Replace(Tools.Files.GetFileNameNoExtention(path) + "_", "").Trim();
                if (!Tools.Strings.StrExt(return_class))
                    return_class = name;
                AbsorbDataFileCsv(x, structure, f, name);
            }
            return return_class;
        }
        public String AbsorbDataFileExcelXml(Context x, ContextDevelop structure, String path, string class_name = "")
        {
            string return_class = "";
            string folder = CheckUnZipFolder(path);
            ToolsOffice.ExcelOffice.SplitExcelXml(path, folder);
            string[] files = Directory.GetFiles(folder, "*.csv");
            foreach (string f in files)
            {
                if (!Tools.Files.FileExists(f))
                    continue;
                if (!Tools.Strings.StrExt(Tools.Files.OpenFileAsString(f)))
                    continue;
                String name = Tools.Files.GetFileNameNoExtention(f).Replace(Tools.Files.GetFileNameNoExtention(path).Replace("_", "") + "_", "").Trim();
                if (!Tools.Strings.StrExt(return_class))
                    return_class = name;
                AbsorbDataFileCsv(x, structure, f, name);
            }
            return return_class;
        }
        private string CheckUnZipFolder(string path)
        {
            string folder = Tools.Folder.ConditionFolderName(Tools.Folder.GetFolderName(path)) + "csv_files\\";
            if (Tools.Folder.FolderExists(folder))
                Tools.Folder.FolderObliterate(folder);            
            Tools.Folder.MakeFolderExist(folder);
            return folder;
        }
    }
    public class ProjectReference
    {
        public String Name;
        public String Path;
    }
}