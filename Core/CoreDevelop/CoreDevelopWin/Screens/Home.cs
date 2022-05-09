using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Core;
using CoreDevelop;
using CoreWin;
using System.Xml;

namespace CoreDevelopWin.Screens
{
    public partial class Home : UserControl
    {
        //Private Variables
        private Dock TheDock = new Dock();
        private BoxSys xCurrentSys = null;
        private BoxSys CurrentSys
        {
            get
            {
                return xCurrentSys;
            }
            set
            {
                xCurrentSys = value;
                if (xCurrentSys == null)
                    cmdAdd.Enabled = false;
                else
                    cmdAdd.Enabled = true;
            }
        }
        private BoxClass xCurrentClass = null;
        private BoxClass CurrentClass
        {
            get
            {
                return xCurrentClass;
            }
            set
            {
                xCurrentClass = value;
                if (xCurrentClass == null)
                    cmdAddProp.Enabled = false;
                else
                    cmdAddProp.Enabled = true;
            }
        }
        //Constructors
        public Home()
        {
            InitializeComponent();
        }
        //Public Functions
        public void Init()
        {
            DockShow();
        }
        //Private Functions
        private void DockShow()
        {
            lvSys.Items.Clear();
            foreach (KeyValuePair<String, BoxSys> k in TheDock.Boxes)
            {
                ListViewItem i = lvSys.Items.Add(k.Value.Name);
                i.Tag = k.Value;
                i.SubItems.Add(k.Value.Classes.Count.ToString());
            }
        }
        private void SysShow(BoxSys s, BoxClass bc = null)
        {
            CurrentSys = s;
            lvClasses.Items.Clear();
            foreach (KeyValuePair<String, BoxClass> k in s.Classes)
            {
                ListViewItem i = lvClasses.Items.Add(k.Value.TheClassAttribute.Name);
                i.Tag = k.Value;
                i.SubItems.Add(k.Value.VarCountNoRefs().ToString());
                i.SubItems.Add(k.Value.RefCount().ToString());
            }
            lvClasses.SelectedItems.Clear();
            foreach (ListViewItem i in lvClasses.Items)
            {
                if (bc == null)
                {
                    i.Selected = true;
                    i.EnsureVisible();
                    return;
                }
                if(i.Tag == bc)
                {
                    i.Selected = true;
                    i.EnsureVisible();
                    return;
                }
            }
        }
        private void ClassShow(BoxClass c)
        {
            CurrentClass = c;
            lvVars.Items.Clear();
            lvVars.SuspendLayout();
            lvRelates.Items.Clear();
            lvRelates.SuspendLayout();
            try
            {
                foreach (KeyValuePair<String, BoxVar> k in c.Vars)
                {
                    ListViewItem i = null;
                    if (k.Value.TheAttribute is CoreVarRefAttribute)
                    { 
                        CoreVarRefAttribute a = (CoreVarRefAttribute)k.Value.TheAttribute;
                        i = lvRelates.Items.Add(a.Name);
                        i.SubItems.Add(((a is CoreVarRefManyAttribute) ? "Many" : "Single"));
                        i.SubItems.Add(a.ReverseName);
                        i.SubItems.Add("Single");
                    }
                    else
                        i = lvVars.Items.Add(k.Value.TheAttribute.Name);
                    i.Tag = k.Value;
                }
            }
            catch { }
            lvVars.ResumeLayout();
            lvRelates.ResumeLayout();
        }
        private bool MemberVarAdd(Type t)
        {
            //if (CurrentClass == null)
            //    return false;

            //return CurrentClass.VarAdd(Startup.TheContext, new ClassExpandArgs( t) != null;
            return false;
        }
        private BoxClass SelectedClassGet()
        {
            try
            {
                return (BoxClass)lvClasses.SelectedItems[0].Tag;
            }
            catch
            {
                return null;
            }
        }
        private BoxVar SelectedPropGet()
        {
            try
            {
                return (BoxVar)lvVars.SelectedItems[0].Tag;
            }
            catch
            {
                return null;
            }
        }
        private BoxVar SelectedRefGet()
        {
            try
            {
                return (BoxVar)lvRelates.SelectedItems[0].Tag;
            }
            catch
            {
                return null;
            }
        }
        private void CreateNewSystem()
        {
            Startup.TheContext.TheLeader.Tell("Please select the system's solution file.");
            string snl = ToolsWin.FileSystem.ChooseAFile();
            if (!Tools.Files.FileExists(snl))
            {
                Startup.TheContext.TheLeader.Tell("File: " + snl + " could not be located.");
                return;
            }
            Startup.TheContext.TheLeader.Tell("Please select the system's compiled .dll file.");
            string dll = ToolsWin.FileSystem.ChooseAFile();
            if (!Tools.Files.FileExists(dll))
            {
                Startup.TheContext.TheLeader.Tell("File: " + dll + " could not be located.");
                return;
            }
            string code = Tools.Folder.GetFolderName(snl);
            SystemTag t = SystemTag.Create(Startup.TheContext, dll, snl, code);
            if (t == null)
                return;
            if (SystemTag.TagExists(t))
            {
                Startup.TheContext.TheLeader.Tell("This system already appears in the list.");
                return;
            }
            SystemTag.TagSave(t);
            CheckCreateFolders(t);
            CheckCreateSystemFile(t);
            Startup.TheContext.TheLeader.Tell("System Created, opening solution. Please compile and load project to add objects.");
            Tools.FileSystem.Shell(t.FileNameSln);
        }
        private void AddFolderToProject(string project, string folder)
        {
            if (!Tools.Strings.StrExt(project))
                return;
            if (!Tools.Files.FileExists(project))
                return;
            if (!Tools.Strings.StrExt(folder))
                return;
            if (!Tools.Folder.FolderExists(folder))
                return;
            bool has_folders = false;
            string file_guts = Tools.Files.OpenFileAsString(project);
            if (file_guts.ToLower().Contains("<folder include"))
                has_folders = true;
            bool wrote_folders = false;
            StringBuilder sb = new StringBuilder();
            string[] guts = Tools.Strings.Split(file_guts, "\r\n");
            foreach (string s in guts)
            {
                sb.AppendLine(s);
                if (!has_folders && Tools.Strings.StrCmp(s, "</ItemGroup>") && !wrote_folders)
                {
                    sb.AppendLine("<ItemGroup>");
                    sb.AppendLine("  <Folder Include=\"" + Tools.Folder.GetTopLevelFolderName(folder) + "\\\" />");
                    sb.AppendLine("</ItemGroup>");
                    wrote_folders = true;
                    continue;
                }
                if (has_folders && s.ToLower().Trim().StartsWith("<folder include") && !wrote_folders)
                {
                    sb.AppendLine("  <Folder Include=\"" + Tools.Folder.GetTopLevelFolderName(folder) + "\\\" />");
                    wrote_folders = true;
                    continue;
                }
            }
            Tools.Files.SaveStringAsFile(project, sb.ToString());
        }
        private void CheckCreateFolders(SystemTag t)
        {
            string auto_folder = Tools.Folder.ConditionFolderName(t.CodePath) + "Auto\\";
            string item_folder = Tools.Folder.ConditionFolderName(t.CodePath) + "Items\\";
            string project = Tools.Folder.ConditionFolderName(t.CodePath) + t.Name + ".csproj";
            if (!Tools.Files.FileExists(project))
                return;
            if (!Tools.Folder.FolderExists(auto_folder))
            {
                Tools.Folder.MakeFolderExist(auto_folder);
                AddFolderToProject(project, auto_folder);
            }
            if (!Tools.Folder.FolderExists(item_folder))
            {
                Tools.Folder.MakeFolderExist(item_folder);
                AddFolderToProject(project, item_folder);
            }
        }
        private void CheckCreateSystemFile(SystemTag t)
        {
            string file = Tools.Folder.ConditionFolderName(t.CodePath) + "Auto\\Sys" + t.Name + "Base.cs";
            string file2 = Tools.Folder.ConditionFolderName(t.CodePath) + "Sys" + t.Name + ".cs";
            if (Tools.Files.FileExists(file))
                return;
            BoxSys ret = new BoxSys(Startup.TheContext, t);
            Startup.TheContext.TheDeltaDevelop.WriteSystem(ret);
            AddFileToProject(t, file, "Auto\\");
            AddFileToProject(t, file2, "");
        }
        private void AddFileToProject(SystemTag t, string file, string sub_folder)
        {
            string project = Tools.Folder.ConditionFolderName(t.CodePath) + t.Name + ".csproj";
            bool has_files = false;
            string file_guts = Tools.Files.OpenFileAsString(project);
            if (file_guts.ToLower().Contains("<compile include=\"" + sub_folder.ToLower() + Tools.Files.GetFileName(file).ToLower() + "\" />"))
                return;
            if (file_guts.ToLower().Contains("<compile include"))
                has_files = true;
            bool wrote_files = false;
            StringBuilder sb = new StringBuilder();
            string[] guts = Tools.Strings.Split(file_guts, "\r\n");
            foreach (string s in guts)
            {
                sb.AppendLine(s);
                if (!has_files && Tools.Strings.StrCmp(s, "</ItemGroup>") && !wrote_files)
                {
                    sb.AppendLine("<ItemGroup>");
                    sb.AppendLine("  <Compile Include=\"" + sub_folder + Tools.Files.GetFileName(file) + "\" />");
                    sb.AppendLine("</ItemGroup>");
                    wrote_files = true;
                    continue;
                }
                if (has_files && s.ToLower().Trim().StartsWith("<compile include") && !wrote_files)
                {
                    sb.AppendLine("  <Compile Include=\"" + sub_folder + Tools.Files.GetFileName(file) + "\" />");
                    wrote_files = true;
                    continue;
                }
            }
            Tools.Files.SaveStringAsFile(project, sb.ToString());
        }
        private void WriteSystem()
        {
            if (CurrentSys == null)
                return;
            Startup.TheContext.TheDeltaDevelop.WriteSystem(CurrentSys);
        }
        private void WriteClass()
        {
            if (CurrentClass == null)
                return;
            Startup.TheContext.TheDeltaDevelop.WriteClass(CurrentClass);
        }
        //Buttons
        private void cmdLoad_Click(object sender, EventArgs e)
        {
            SystemTag t = Dialogs.TagChooser.Choose();
            if (t == null)
                return;
            SystemTag.TagSave(t);
            if (bgw.IsBusy)
                return;
            lblLoad.Visible = true;
            bgw.RunWorkerAsync(t);
        }
        private void cmdNew_Click(object sender, EventArgs e)
        {
            CreateNewSystem();
        }
        private void cmdWriteAll_Click(object sender, EventArgs e)
        {
            WriteSystem();
            foreach (ListViewItem xlst in lvClasses.Items)
            {
                lvClasses.SelectedItems.Clear();
                xlst.Selected = true;
                xlst.EnsureVisible();
                WriteClass();
            }
            Startup.TheContext.TheLeader.Tell("Done.");
        }
        private void cmdWrite_Click(object sender, EventArgs e)
        {
            WriteClass();
            Startup.TheContext.TheLeader.Tell("Done.");
        }
        private void cmdWriteSys_Click(object sender, EventArgs e)
        {
            WriteSystem();
            Startup.TheContext.TheLeader.Tell("Done.");
        }
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (CurrentSys == null)
                return;
            BoxClass bc = CurrentSys.ClassAdd(Startup.TheContext);
            if (bc != null)
            {
                BoxSys s = CurrentSys;
                DockShow();
                SysShow(s, bc);
            }
        }
        private void cmdAddProp_Click(object sender, EventArgs e)
        {
            //PropChooser p = new PropChooser();
            //p.ShowDialog();
            //bool success = false;
            //if (p.OneToMany)
            //{
            //    if (CurrentClass.RelateOneToManyAdd(Startup.TheContext) != null)
            //        success = true;
            //}
            //else if (p.OneToOne)
            //{
            //    if (CurrentClass.RelateOneToOneAdd(Startup.TheContext) != null)
            //        success = true;
            //}
            //if (p.TheType == null && !success)
            //    return;
            //if (!success && MemberVarAdd(p.TheType))
            //    success = true;
            //if (success)
            //    SysShow(CurrentSys, CurrentClass);                
        }
        private void cmdImportNM_Click(object sender, EventArgs e)
        {
            String name = CoreDevelopWin.Startup.TheContext.TheLeader.AskForString("System name");
            if (!Tools.Strings.StrExt(name))
                return;
            if (!CoreDevelopWin.Startup.TheContext.TheLeader.AreYouSure("import from " + name))
                return;

        }
        //Control Events
        private void lvSysClick()
        {
            try
            {
                BoxSys s = (BoxSys)lvSys.SelectedItems[0].Tag;
                if (s == null)
                    return;
                SysShow(s);
            }
            catch { }
        }
        private void lvClassesClick()
        {
            try
            {
                BoxClass c = (BoxClass)lvClasses.SelectedItems[0].Tag;
                if (c == null)
                    return;
                ClassShow(c);
            }
            catch { }
        }
        private void lvVarsClick()
        {
            try
            {
                BoxVar m = (BoxVar)lvVars.SelectedItems[0].Tag;
                String s = m.Name;
            }
            catch { }
        }
        private void lvSys_Click(object sender, EventArgs e)
        {
            lvSysClick();
        }
        private void lvClasses_Click(object sender, EventArgs e)
        {
            lvClassesClick();
        }
        private void lvVars_Click(object sender, EventArgs e)
        {
            lvVarsClick();
        }
        private void lvSys_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvSysClick();
        }
        private void lvClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvClassesClick();
        }
        private void lvVars_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvVarsClick();
        }
        //Menus
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if( CurrentSys == null )
                    return;
                BoxClass b = SelectedClassGet();
                if( b == null )
                    return;
                if (!Startup.TheContext.TheLeader.AreYouSure("delete " + b.Name))
                    return;
                CurrentSys.ClassRemove(Startup.TheContext, b);
                this.SysShow(CurrentSys);
            }
            catch { }
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (CurrentSys == null)
            {
                Startup.TheContext.TheLeader.Tell("You must select a system first.");
                return;
            }
            if (CurrentSys.TheTag == null)
            {
                Startup.TheContext.TheLeader.Tell("This system has a null tag.");
                return;
            }
            if (!Tools.Strings.StrExt(CurrentSys.TheTag.FileNameSln))
            {
                Startup.TheContext.TheLeader.Tell("This system has blank solution filename.");
                return;
            }
            if (!Tools.Files.FileExists(CurrentSys.TheTag.FileNameSln))
            {
                Startup.TheContext.TheLeader.Tell("This system's solution file does not exist in this path: " + CurrentSys.TheTag.FileNameSln);
                return;
            }
            Tools.FileSystem.Shell(CurrentSys.TheTag.FileNameSln);
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentClass == null)
                    return;
                BoxVar v = SelectedPropGet();
                if (v == null)
                    return;
                if (!Startup.TheContext.TheLeader.AreYouSure("delete " + v.Name))
                    return;
                CurrentClass.VarRemove(Startup.TheContext, v);
                this.SysShow(CurrentSys, CurrentClass);
            }
            catch { }
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentClass == null)
                    return;
                BoxVar v = SelectedRefGet();
                if (v == null)
                    return;
                if (!Startup.TheContext.TheLeader.AreYouSure("delete " + v.Name))
                    return;
                CurrentClass.VarRemove(Startup.TheContext, v);
                this.SysShow(CurrentSys, CurrentClass);
            }
            catch { }
        }
        //Background Workers
        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            SystemTag t = (SystemTag)e.Argument;
            TheDock.Load(Startup.TheContext, t);
            e.Result = t;
        }
        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DockShow();
            lblLoad.Visible = false;
            SystemTag t = (SystemTag)e.Result;
            if (t == null)
                return;
            lvSys.SelectedItems.Clear();
            foreach (ListViewItem xLst in lvSys.Items)
            {
                if (Tools.Strings.StrCmp(xLst.Text, t.Name))
                {
                    xLst.Selected = true;
                    xLst.EnsureVisible();
                }
            }
        }

        private void lblParse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            XmlDocument d = new XmlDocument();

            //BoxSys s = new BoxSys("NewMethod");
            //s.TheTag = new SystemTag(@"c:\eternal\code\NewMethod\bin\Debug\NewMethod.dll", @"c:\eternal\code\NewMethod\NewMethod.sln", @"c:\eternal\code\NewMethod\");
            //d.Load(@"c:\eternal\code\NewMethod\NewMethod.xml");

            //BoxSys s = new BoxSys("Rz4");
            //s.TheTag = new SystemTag(@"c:\eternal\code\Rz4\bin\Debug\Rz4.dll", @"c:\eternal\code\Rz4\Rz4.sln", @"c:\eternal\code\Rz4\");
            //d.Load(@"c:\eternal\code\Rz4\Rz4.xml");

            //BoxSys s = new BoxSys("RzRecognin");
            //s.TheTag = new SystemTag(@"c:\eternal\code\RzRecognin\bin\Debug\RzRecognin.dll", @"c:\eternal\code\RzRecognin\RzRecognin.sln", @"c:\eternal\code\RzRecognin\");
            //d.Load(@"c:\eternal\code\RzRecognin\RzRecognin.xml");

            //BoxSys s = new BoxSys("RzPhoenix");
            //s.TheTag = new SystemTag(@"c:\eternal\code\RzPhoenix\bin\Debug\RzPhoenix.dll", @"c:\eternal\code\RzPhoenix\RzPhoenix.sln", @"c:\eternal\code\RzPhoenix\");
            //d.Load(@"c:\eternal\code\RzPhoenix\RzPhoenix.xml");

            //BoxSys s = new BoxSys("RzCTG");
            //s.TheTag = new SystemTag(@"c:\eternal\code\RzCTG\bin\Debug\RzCTG.dll", @"c:\eternal\code\RzCTG\RzCTG.sln", @"c:\eternal\code\RzCTG\");
            //d.Load(@"c:\eternal\code\RzCTG\RzCTG.xml");

            //BoxSys s = new BoxSys("RzGlobal");
            //s.TheTag = new SystemTag(@"c:\eternal\code\RzGlobal\bin\Debug\RzGlobal.dll", @"c:\eternal\code\RzGlobal\RzGlobal.sln", @"c:\eternal\code\RzGlobal\");
            //d.Load(@"c:\eternal\code\RzGlobal\RzGlobal.xml");

            BoxSys s = new BoxSys("RzSensible");
            s.TheTag = new SystemTag(@"c:\eternal\code\RzSensible\bin\Debug\RzSensible.dll", @"c:\eternal\code\RzSensible\RzSensible.sln", @"c:\eternal\code\RzSensible\");
            d.Load(@"c:\eternal\code\RzSensible\RzSensible.xml");

            Dictionary<String, BoxClass> classes = new Dictionary<string, BoxClass>();

            foreach (XmlNode o in d.SelectNodes("objects/object"))
            {
                switch (o.Attributes["class"].Value)
                {
                    case "n_class":

                        String uid = PropGet(o, "unique_id");
                        String name = PropGet(o, "class_name");
                        CoreClassAttribute a = new CoreClassAttribute(name);
                        a.BaseClass = "NewMethod.nObject";
                        BoxClass c = new BoxClass(s, a);
                      
                        classes.Add(uid, c);

                        break;
                    case "n_prop":

                        String classId = PropGet(o, "the_n_class_uid");

                        if (!Tools.Strings.StrExt(classId))
                            throw new Exception("Class id not found");

                        if(!classes.ContainsKey(classId)) 
                            throw new Exception("Class not found");

                        String pname = PropGet(o, "name");

                        switch (pname)
                        {
                            case "unique_id":
                            case "date_created":
                            case "date_modified":
                            case "grid_color":
                            case "icon_index":
                                continue;
                        }

                        BoxClass bc = classes[classId];

                        if (bc.VarContainsAnyCase(pname))
                            continue;

                        bc.VarAdd(Startup.TheContext, VarValParse(o, pname));
                        break;
                }
            }

            foreach(KeyValuePair<String, BoxClass> bc in classes)
            {
                //String file = bc.Value.CodeBaseFileFind();
                //if (File.Exists(file))
                //{
                //    String contents = Tools.Files.OpenFileAsString(file);
                //    foreach (BoxVar bv in bc.Value.VarsList)
                //    {
                //        CodeBuilder cb = new CodeBuilder();
                //        bv.TheAttribute.RenderDeclare(cb);
                //        String definition = cb.ToString();

                //        String replace = ((CoreVarValAttribute)bv.TheAttribute).RenderDeclareExtraVarValNamed(true);
                //        if (Tools.Strings.StrExt(replace))
                //        {
                //            String original = definition.Replace(replace, ((CoreVarValAttribute)bv.TheAttribute).RenderDeclareExtraVarValNamed(false));
                //            contents = contents.Replace(original, definition);
                //        }
                //    }
                //    Tools.Files.SaveStringAsFile(file, contents);
                //}
                bc.Value.Write();
            }

            Startup.TheContext.TheLeader.Tell("Done");
        
        }

        BoxVar VarValParse(XmlNode o, String name)
        {
            String type = PropGet(o, "property_type");


        //public enum DataType
        //{
        //    Unknown = -1,
        //    Any = 0,
        //    String = 1,
        //    Integer = 2,
        //    Long = 3,
        //    Float = 4,
        //    Date = 5,
        //    Boolean = 6,
        //    Memo = 7,
        //    List = 8,
        //    Picture = 9,
        //    Document = 10,
        //    Object = 11,
        //    Blob = 12,
        //    Data = 13,
        //}

            String typeName = "String";
            switch(type)
            {
                case "2":
                    typeName = "Int32";
                    break;
                case "3":
                    typeName = "Int64";
                    break;
                case "4":
                    typeName = "Double";
                    break;
                case "5":
                    typeName = "DateTime";
                    break;
                case "6":
                    typeName = "Boolean";
                    break;
                case "7":
                    typeName = "Text";
                    break;
                case "9":
                case "10":
                case "12":
                case "13":
                    typeName = "Blob";
                    break;
            }

            CoreVarValAttribute ret = new CoreVarValAttribute(name, typeName);

            String caption = PropGet(o, "property_tag");
            String length = PropGet(o, "property_length");
            String order = PropGet(o, "property_order");

            ret.Caption = caption;
            ret.TheFieldLength = Int32.Parse(length);
            ret.Importance = Int32.Parse(order);

            return new BoxVar(ret);
        }

        String PropGet(XmlNode n, String prop)
        {
            foreach (XmlNode p in n.SelectNodes("properties/property"))
            {
                if (p.ChildNodes[0].InnerText == prop)
                    return p.ChildNodes[1].InnerText;
            }
            return "";
        }
    }
}
