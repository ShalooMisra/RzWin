using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.Xml;
using System.IO;

using Tools.Database;
using Core;
using Core.Display;

namespace NewMethod
{
    public partial class SysNewMethod
    {        
        public static ArrayList Clipboard;
        //public static frmIconChooser xChooseIcon;
        public static String version_string;
        public static bool ExplicitLayoutSave = false;
        
        //Public Vars
        //public Tools.Database.DataConnectionSqlServer xData
        //{
        //    get
        //    {
        //        return (Tools.Database.DataConnectionSqlServer)ContextDefault.TheData.TheConnection;
        //    }
        //}

        public DataTable UserList;
        public System.Windows.Forms.ImageList icons;
        public bool IsPlaceHolder = false;
        public nArray TeamTree = new nArray();
        public int highest_majorversion = 0;
        public int highest_minorversion = 0;
        public int highest_revision = 0;
        public int highest_private = 0;

        //Properties
        //private String m_DatabaseAlias = "";
        //public String DatabaseAlias
        //{
        //    set
        //    {
        //        m_DatabaseAlias = value;
        //    }
        //}
        //public String DatabaseName
        //{
        //    get
        //    {
        //        if (Tools.Strings.StrExt(m_DatabaseAlias))
        //            return m_DatabaseAlias;
        //        else
        //            return Name;
        //    }
        //}
        //Public Events
        //public event ShowHandler DefaultShowHandler;
        //static n_sys()
        //{
        //    //if (Tools.Misc.IsDevelopmentMachine())
        //    //    FlashPath = "c:\\eternal\\code\\NewMethod\\flash\\";
        //    //else
        //    //    FlashPath = Tools.FileSystem.GetAppPath() + "flash\\";
        //    //if (!System.IO.Directory.Exists(FlashPath))
        //    //    FlashPath = nTools.GetAppParentPath() + "flash\\";
        //}
        //public static void HandleActionNM(Context context, ActArgs args)
        //{
        //    foreach (Core.IItem x in args.TheItems.AllGet(context))
        //    {
        //        ActArgs argsx = new ActArgs(args.ActionName);
        //        argsx.TheContext = context;  //temporary
        //        ((nObject)x).HandleAction(argsx);
        //    }
        //}

        //public static void CacheFlash()
        //{
        //    AllFlash = new SortedList();
        //    SortedList h = nTools.GetHighestFileCollection(n_sys.FlashPath);
        //    foreach (DictionaryEntry d in h)
        //    {
        //        NumberedFile n = (NumberedFile)d.Value;
        //        AllFlash.Add(n.FileBase.ToLower(), n.FilePath);
        //    }
        //}
        //public static string GetFlashFile(String strBase)
        //{
        //    if (!strBase.ToLower().EndsWith(".swf"))
        //        strBase = strBase + ".swf";
        //    String s;
        //    if (AllFlash == null)
        //    {
        //        s = nTools.GetHighestFileName(FlashPath, strBase);
        //    }
        //    else
        //    {
        //        s = (String)AllFlash[strBase.ToLower()];
        //    }
        //    if (Tools.Strings.StrExt(s))
        //        return FlashPath + s;
        //    else
        //        return "";
        //}
        public static String ParseKeyID(String strKey)
        {
            return Tools.Strings.ParseDelimit(strKey, ":", 2);
        }
        public static String ParseKeyClass(String strKey)
        {
            return Tools.Strings.ParseDelimit(strKey, ":", 1);
        }
        //Public Virtual Functions
        //public virtual nObject MakeObject(string strClass)
        //{
        //    return (nObject)ContextDefault.Item(strClass);
        //}

        //public virtual nObject MakeObject(String strClass, n_sys s)
        //{
        //    //foreach (n_sys xs in xStructure.ParentSystems.All)
        //    //{
        //    //    nObject o = xs.MakeObject(strClass, s);
        //    //    if (o != null)
        //    //        return o;
        //    //}

        //    //if (this.HasClass(strClass))
        //    //    return this.MakeBlankInstance(strClass, s);
        //    //else
        //        return null;
        //}

        //public virtual nObject MakeObject(String strClass, n_sys s, nObject o)
        //{
        //    //if (s.IsSoft(strClass))
        //    //    o.AddSoftProps();
        //    return o;
        //}

        //public virtual nSearch GetSearch(String strClass, String strExtra)
        //{
        //    //nSearch s = GetSoftSearch(strClass, strExtra);
        //    //if (s != null)
        //    //    return s;
        //    //if (ParentSystem != null)
        //    //    return ParentSystem.GetSearch(strClass, strExtra);
        //    return null;
        //}
        //public virtual void ThrowObjectUp(ShowArgs args)
        //{
        //    ContextDefault.Show(args);
        //    //return SysNewMethod.ContextDefault.TheLeader.Show(SysNewMethod.ContextDefault, args);
        //}

        //public virtual void SetStatus(String s, ActivityType t)
        //{
        //}
        //public virtual void AfterThrow(nObject o)
        //{
        //}
        public virtual String GetHTMLList_SQL(ContextNM context, String strCaption, String strClass, String strSQL)
        {
            return GetHTMLList_SQL(context, strCaption, strClass, strSQL, "#0000FF", "#C0C0C0", "#00CCFF", "#99FF99", "#66FFFF");
        }
        public virtual String GetHTMLList_SQL(ContextNM context, String strCaption, String strClass, String strSQL, String strBorderColor, String strBorderColorLight, String strBorderColorDark, String RowColor1, String RowColor2)
        {
            DataTable d = context.Select(strSQL);
            if (!Tools.Data.DataTableExists(d))
                return "";
            //String[] aryAlign = Tools.Strings.Split(strAlign, "|");
            //String[] aryFormat = Tools.Strings.Split(strFormat, "|");
            StringBuilder sb = new StringBuilder();
            sb.Append("<br><table border=\"3\" cellpadding=\"2\" width=\"100%\" bordercolor=\"" + strBorderColor + "\" bordercolorlight=\"" + strBorderColorLight + "\" bordercolordark=\"" + strBorderColorDark + "\">");
            sb.Append("  <tr>");
            sb.Append("    <td colspan=\"" + (d.Columns.Count - 1).ToString() + "\" bgcolor=\"#C0C0C0\"><font face=\"Arial\" color=\"#FFFFFF\" size=\"4\">" + strCaption + "</font></td>");
            sb.Append(" </tr>");
            bool b = true;
            foreach (DataRow r in d.Rows)
            {
                String strColor = RowColor1;
                if (!b)
                    strColor = RowColor2;
                sb.Append("  <tr>");
                for (int i = 1; i < d.Columns.Count; i++)
                {
                    sb.Append("    <td bgcolor=\"" + strColor + "\">");
                    if (i == 1)
                        sb.Append("<a href=\"http://show_object.rzl?" + strClass + ":" + nData.NullFilter_String(r[0]) + "\">");
                    sb.Append("<font face=\"Arial\" size=\"2\">" + nData.NullFilter_String(r[i]) + "</font>");
                    if (i == 1)
                        sb.Append("</a>");
                    sb.Append("</td>");
                }
                b = !b;
                sb.Append("  </tr>");
            }
            sb.Append("</table>");
            return sb.ToString();
        }
        //public virtual ArrayList GetCubes()
        //{
        //    return new ArrayList();
        //}
        //public virtual bool Cube()
        //{
        //    ArrayList a = GetCubes();
        //    foreach (nCube c in a)
        //    {
        //        c.Calculate(true);
        //    }
        //    return true;
        //}
        //public virtual nData GetCubeData()
        //{
        //    return new nData(new n_data_target(xData.target_type, xData.server_name, xData.database_name + "_Cube", xData.user_name, xData.user_password));
        //}
        //public virtual void SendNote(ContextNM context, nObject xObject)
        //{
        //}
        public virtual String[] GetActiveClasses()
        {
            String[] s = Tools.Strings.Split(" ", " ");
            return s;
        }
        public virtual nCube GetCubeByName(String strName)
        {
            return null;
        }
        public virtual String MixWithWord(ContextNM context, nObject n, String wordfile, Boolean bShow, Boolean bSaveAndReturn, ArrayList aPayLoad, String pay)
        {
            return "";
        }
        public virtual String MixPictureWithWord(String pic_filename, String pic_alttext, String wordfile, Boolean bShow, Boolean bSaveAndReturn)
        {
            return "";
        }
        public virtual void AddClipObject(nObject o)
        {
            throw new Exception("Needs AddClipObject override.");
        }
        //public virtual String GetExtraClassInfo(String strClass, String strID)
        //{
        //    return "";
        //}
        public virtual ArrayList GetMainProperties(String strClass)
        {
            return null;
        }
        public virtual ArrayList GetMainSearchProperties(String strClass)
        {
            return null;
        }
        //public virtual String GetFriendlyClassName(nObject o)
        //{
        //    return o.GetClass().TheAttribute.Caption;  // nTools.NiceFormat(o.ClassId.Replace("n_", ""));
        //}
        public virtual bool RunVersionUpdate()
        {
            return RunVersionUpdate(false);
        }
        public virtual bool RunVersionUpdate(bool auto_run)
        {
            //frmUpdate xForm = new frmUpdate();
            //xForm.CompleteLoad(this);
            //xForm.Show();
            //if (auto_run)
            //    xForm.RunUpdate();
            //return true;
            return false;
        }
        //public virtual void RunNext()
        //{
        //    throw new NotImplementedException("n_sys.RunNext");
        //}
        //public virtual String GetMainFolder()
        //{
        //    if (Tools.FileSystem.GetAppPath().ToLower().StartsWith("c:\\eternal\\code"))
        //        return "c:\\program files\\Recognin Technologies\\" + this.system_name + "\\";
        //    else
        //    {
        //        if (Tools.FileSystem.GetAppPath().ToLower().EndsWith("\\exec\\"))
        //            return nTools.GetAppParentPath();
        //        else
        //            return Tools.FileSystem.GetAppPath();
        //    }
        //}

        //public virtual void ShowSQL(String strSQL)
        //{
        //    if (xMainForm != null)
        //        xMainForm.ShowQuery(strSQL);
        //}
        //public virtual XmlDocument GetXMLStructure()
        //{
        //    return null;
        //}

        //public virtual String ApplicationName()
        //{
        //    return "NewMethod";
        //}

        //Public Functions
        public bool Init(TreeNode xNode, String strName, bool AutoLoadSubSystems)
        {
            SystemLoadArgs args = new SystemLoadArgs(strName);
            args.auto_load_subsystems = AutoLoadSubSystems;
            return Init(xNode, args);
        }
        public bool Init(TreeNode xNode, SystemLoadArgs args)
        {
            //context.TheLeader.Comment("Initializing " + this.system_name);
            //ArrayList UpdatedRelates = new ArrayList();
            //this.system_name = args.Name;

            //if (args.SkipDataConnection)
            //    context.TheLeader.Comment("Skipping data connection");
            //else
            //{
            //    context.TheLeader.Comment("Data setup, using database " + DatabaseName);
            //    xData = new nData(n_data_target.dTargetType, n_data_target.dServerName, DatabaseName, n_data_target.dUserName, n_data_target.dPassword, n_data_target.dAbsoluteConnectionString);
            //}

            //bool bc = true;
            //if (n_sys.DisconnectedMode)
            //    bc = false;
            //else
            //    bc = xData.CanConnect();
            //if (!bc)
            //{
            //    if (!n_sys.UseXmlStructure)
            //    {
            //        context.TheLeader.Comment("Data connection failed.");
            //        return false;
            //    }
            //}
            //else
            //{
            //    context.TheLeader.Comment("Connection check passed.");
            //    xData.CheckBigIntDisabled();
            //    xData.CheckVarcahrMaxDisabled();
            //}
            //if (n_sys.UseXmlStructure)
            //{
            //    context.TheLeader.Comment("Initializing from XML...");
            //    if (!AbsorbXmlStructure())
            //    {
            //        context.TheLeader.Comment("Structure init failed.");
            //        return false;
            //    }
            //}
            ////handle this after the XML system is in place
            ////Run a strcuture update
            //bool ForceParentUpdate = false;
            ////if (n_sys.CheckStructureUpdate)
            ////{
            ////    AbsorbUpdateFile("c:\\");
            ////    ForceParentUpdate = true;
            ////}
            //CacheRelates();
            //if (this.ParentSystem != null)
            //{
            //    if (!UseXmlStructure)    //update the system table, just in case it has changed
            //    {
            //        context.TheLeader.Comment("Updating the system table...");
            //        MakeClassDataStructure(this.ParentSystem.GetClassByName("n_sys"));
            //    }
            //    //let the parent system latch on to the relates
            //    try
            //    {
            //        context.TheLeader.Comment("Linking child relates...");
            //        ParentSystem.LinkChildRelates(this, UpdatedRelates);
            //    }
            //    catch (Exception)
            //    {
            //    }
            //}
            //DataTable t = null;
            //if (!n_sys.UseXmlStructure && bc)
            //    t = xData.Select("select * from n_sys where system_index = 0");
            //if (!Tools.Data.DataTableExists(t))
            //{
            //    this.xSys = this;
            //    this.system_name = args.Name;
            //    this.system_index = 0;
            //    if (!n_sys.UseXmlStructure && bc)
            //        this.ISave();
            //}
            //else
            //{
            //    this.ICreate(this, t.Rows[0]);
            //}
            //IsPlaceHolder = false;
            //context.TheLeader.Comment("Continuing init on " + this.system_name);
            //if (bc)
            //{
            //    context.TheLeader.Comment("Checking parent update");
            //    if (ForceParentUpdate)
            //        DoParentUpdate(args);
            //    else
            //        CheckParentUpdate(args);
            //}
            //if (xNode != null)
            //{
            //    //Node Setup
            //    MyNode = xNode.Nodes.Add(this.system_name);
            //    MyNode.Tag = this;
            //    MyClassNode = MyNode.Nodes.Add("Classes");
            //    MyClassNode.Tag = this;
            //    MySystemNode = MyNode.Nodes.Add("Systems");
            //    MySystemNode.Tag = this;
            //}
            //CacheIcons();
            //ClassesByName = new SortedList();
            //ClassesByID = new SortedList();
            //ArrayList classes = GetInitialClassArray();
            //if (classes.Count == 0)
            //    return true;
            //context.TheLeader.Comment("Initializing classes");
            //foreach (n_class c in classes)
            //{
            //    AbsorbClass(c);
            //    if (UseXmlStructure)
            //        c.InitFromArray(MyClassNode, XmlProperty, XmlAction);
            //    else
            //        c.InitFromDatabase(MyClassNode);
            //    //nObject o = this.MakeObject(c.class_name);
            //    //AbsorbClass(c);
            //    //if (o.Hard)
            //    //{
            //    //    //o.xSys = this;
            //    //    //o.Init();
            //    //    //c.PropsByName = o.GetProps();
            //    //    //c.InferOrderedProps();
            //    //    c.InitFromDatabase(MyClassNode);
            //    //}
            //    //else
            //    //{
            //    //   c.InitFromDatabase(MyClassNode);
            //    //}
            //}
            ////relates
            //context.TheLeader.Comment("Initializing relates");
            //foreach (DictionaryEntry d in ClassesByName)
            //{
            //    n_class c = (n_class)d.Value;
            //    c.InitRelates();
            //}
            //context.TheLeader.Comment("Updating relates");
            //foreach (n_relate ur in UpdatedRelates)
            //{
            //    ur.UpdateMyNodes();
            //}
            ////not quite yet
            //////methods
            ////context.TheLeader.Comment("Initializing methods");
            ////foreach (DictionaryEntry d in ClassesByName)
            ////{
            ////    c = (n_class)d.Value;
            ////    c.InitMethsFromDatabase();
            ////}
            //SystemsByName = new SortedList();
            //LoadedSystems = new SortedList();
            //if (bc)
            //{
            //    //choices
            //    context.TheLeader.Comment("Initializing choices");
            //    this.CacheChoices();
            //    foreach (DictionaryEntry d in ClassesByName)
            //    {
            //        n_class c = (n_class)d.Value;
            //        c.InitChoices();
            //    }
            //    //users
            //    CacheUsers();
            //    //teams
            //    FillTeamTree();
            //    //load the systems
            //    ArrayList a = this.QtC("n_sys", "select * from n_sys where system_index > 0");
            //    TreeNode n;
            //    bool sysex = false;
            //    bool thisex = false;
            //    foreach (nObject nob in a)
            //    {
            //        n_sys s = (n_sys)nob;
            //        if (s.is_expanded)
            //            sysex = true;
            //        thisex = s.is_expanded;
            //        s.IsPlaceHolder = true;
            //        AbsorbSystem(s);
            //        if (args.auto_load_subsystems && s.is_loaded)
            //        {
            //            s = this.LoadSystem(s, args.auto_load_subsystems);
            //            if (thisex)
            //                s.MyNode.Expand();
            //        }
            //    }
            //    if (sysex && MySystemNode != null)
            //        MySystemNode.Expand();
            //    if (MyNode != null && (this.is_expanded || Tools.Strings.StrCmp(this.system_name, "NewMethod")))
            //    {
            //        MyNode.Expand();
            //    }
            //    if (ForceParentUpdate)
            //    {
            //        MakeDataStructure(args);
            //    }
            //}
            //else
            //{
            //    UsersByName = new SortedList();
            //    UsersByID = new SortedList();
            //    TeamTree = new SortedList();
            //    TeamsByID = new SortedList();
            //}
            //return true;

            return false;
        }
        public void CacheRelates()
        {
            //context.TheLeader.Comment("Caching relates...");
            //AllRelates = new SortedList();
            //ArrayList a;
            //if (n_sys.UseXmlStructure)
            //{
            //    a = XmlRelate;
            //}
            //else
            //{
            //    a = QtC("n_relate", "select * from n_relate");
            //}
            //foreach (n_relate r in a)
            //{
            //    try
            //    {
            //        AllRelates.Add(r.unique_id, r);
            //    }
            //    catch (Exception)
            //    {
            //    }
            //}
        }
        public void CacheIcons()
        {
            icons = new System.Windows.Forms.ImageList();
            String strGraphicsPath = Tools.FileSystem.GetAppPath() + "Graphics\\";
            if (Tools.Misc.IsDevelopmentMachine() && !System.IO.Directory.Exists(strGraphicsPath))
                strGraphicsPath = "c:\\eternal\\code\\newmethod\\graphics\\";
            try
            {
                icons.Images.Add(new System.Drawing.Icon(strGraphicsPath + "cloud.ico"));
                icons.Images.Add(new System.Drawing.Icon(strGraphicsPath + "earth.ico"));
                icons.Images.Add(new System.Drawing.Icon(strGraphicsPath + "fire.ico"));
                icons.Images.Add(new System.Drawing.Icon(strGraphicsPath + "litening.ico"));
                icons.Images.Add(new System.Drawing.Icon(strGraphicsPath + "calendar.ico"));
                icons.Images.Add(new System.Drawing.Icon(strGraphicsPath + "plane.ico"));
                icons.Images.Add(new System.Drawing.Icon(strGraphicsPath + "dollar.ico"));
            }
            catch (Exception)
            {
            }
        }

        //public void UpdateAllChildSystems()
        //{
        //    foreach (n_sys s in ChildSystems.All)
        //    {
        //        UpdateChildSystem(s);
        //        s.UpdateAllChildSystems();
        //    }
        //}
        public void UpdateChildSystem(SysNewMethod s)
        {
            MessageBox.Show("sysreorg");
            //SystemLoadArgs args = new SystemLoadArgs(s.system_name);
            //args.SystemObject = s;
            //UpdateChildSystem(s, args);
        }
        public void UpdateChildSystem(SysNewMethod s, SystemLoadArgs args)
        {

            MessageBox.Show("sysreorg");
            ////how should this be handled now?
            ////if (this.ParentSystem != null)
            ////    ParentSystem.UpdateChildSystem(s, args);

            //bool recall = false;
            //nData recall_data = null;
            //if (args.recall)
            //{
            //    recall_data = new nData(args.recall_target);
            //    recall = recall_data.CanConnect();
            //}
            ////copy all of the table structures to the new system
            //n_class c;
            //foreach (DictionaryEntry d in xStructure.Classes.AllByName)
            //{
            //    c = (n_class)d.Value;
            //    s.MakeClassDataStructure(c);
            //    //update the recall structure also
            //    if (recall)
            //        s.MakeClassDataStructure(c, recall_data, true);
            //}
            //s.SetParentUpdate();
            //s.SetStructureChanged();
        }

        //not needed?
        //public void UnloadSystem(n_sys s)
        //{
        //    if (s.MyNode != null)
        //        s.MyNode.Parent.Nodes.Remove(s.MyNode);
        //    //un-link all of the relationships
        //    s.UnLinkChildRelates(s);
        //    this.xData.Execute("update n_sys set is_loaded = 0 where system_name = '" + s.system_name + "'");
        //    s.is_loaded = false;
        //    s.ISave();
        //    LoadedSystems.Remove(s.system_name);
        //    SystemsByName.Remove(s.system_name);
        //    n_sys p = (n_sys)this.QtO("n_sys", "select * from n_sys where system_name = '" + s.system_name + "'");
        //    if (p != null)
        //    {
        //        p.IsPlaceHolder = true;
        //        this.AbsorbSystem(p);
        //    }
        //}
        //public ArrayList GetAllByClass(String strClass)
        //{
        //    if (InstanceSaveType == StructureType.XmlStructure)
        //    {
        //        String[] files = Directory.GetFiles(n_sys.StaticDataPath, strClass + "__*.nmo");
        //        ArrayList a = new ArrayList();
        //        foreach (String s in files)
        //        {
        //            nObject x = MakeObject(strClass);
        //            x.CreateFromXml(s);
        //            a.Add(x);
        //        }
        //        return a;
        //    }
        //    else
        //    {
        //        return QtC(strClass, "select * from " + strClass);
        //    }
        //}

        //public Dictionary<String, nObject> GetAllByClassD(String strClass)
        //{
        //    Dictionary<String, nObject> ret = new Dictionary<string, nObject>();
        //    ArrayList a = GetAllByClass(strClass);
        //    foreach (nObject n in a)
        //    {
        //        if (Tools.Strings.StrExt(n.unique_id))
        //            ret.Add(n.unique_id, n);
        //        else
        //        {
        //            ;
        //        }
        //    }
        //    return ret;
        //}

        //public String GetUIDByIndex_Xml(String strClass, int index)
        //{
        //    String[] files = Directory.GetFiles(SysNewMethod.StaticDataPath, strClass + "__*.nmo");
        //    ArrayList a = new ArrayList();
        //    int i = 0;
        //    String r = "";
        //    foreach (String s in files)
        //    {
        //        r = Tools.Strings.ParseDelimit(System.IO.Path.GetFileNameWithoutExtension(s), "__", 2);

        //        if (i == index)
        //            break;

        //        i++;
        //    }
        //    return r;
        //}
        //public int GetNextSystemOrder()
        //{
        //    MessageBox.Show("sysreorg");
        //    int i = 0;
        //    //n_sys w;
        //    //if (ChildSystems.Count == 0)
        //    //    return 1;
        //    //foreach (n_sys s in ChildSystems.All)
        //    //{
        //    //    if (s.system_index > i)
        //    //    {
        //    //        w = s;
        //    //        i = s.system_index;
        //    //    }
        //    //}
        //    //i++;
        //    return i;
        //}
        //public void RemoveSystem(n_sys s)
        //{
        //    if (s.MyNode != null)
        //        this.MySystemNode.Nodes.Remove(s.MyNode);
        //    this.xData.Execute("delete from n_sys where system_name = '" + s.system_name + "'");
        //    try
        //    {
        //        this.SystemsByName.Remove(s);
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    try
        //    {
        //        this.LoadedSystems.Remove(s.system_name);
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    s.xData.RenameDatabase(s.system_name + "_" + nTools.GetDateTimeString());
        //}

        //public bool MakeDataStructure()
        //{
        //    return MakeDataStructure(new SystemLoadArgs());
        //}
        //public bool MakeDataStructure(SystemLoadArgs args)
        //{
        //    bool recall = false;
        //    nData recall_connection = null;
        //    if (args.recall)
        //    {
        //        recall_connection = new nData(args.recall_target);
        //        recall = recall_connection.ConnectPossible();
        //    }
        //    foreach (DictionaryEntry c in xStructure.Classes.AllByName)
        //    {
        //        MakeClassDataStructure((n_class)c.Value);
        //        if (recall)
        //            MakeClassDataStructure((n_class)c.Value, recall_connection, true);
        //    }
        //    return true;
        //}
        //public bool MakeClassDataStructure(n_class c)
        //{
        //    //foreach (nData d in InstanceDataConnections)
        //    //{
        //        if (!MakeClassDataStructure(c, xData, false, ""))
        //            return false;
        //    //}
        //    return true;
        //}
        //public bool MakeClassDataStructure(n_class c, String strTable)
        //{
        //    return MakeClassDataStructure(c, xData, false, strTable);
        //}
        //public bool MakeClassDataStructure(n_class c, nData nd)
        //{
        //    return MakeClassDataStructure(c, nd, false);
        //}
        //public bool MakeClassDataStructure(n_class c, nData nd, bool recall)
        //{
        //    return MakeClassDataStructure(c, nd, recall, "");
        //}
        //public bool MakeClassDataStructure(n_class c, nData nd, bool recall, String strTable)
        //{
        //    if (!nd.ConnectPossible())
        //        return false;
        //    bool b = false;
        //    if (!Tools.Strings.StrExt(strTable))
        //        strTable = c.class_name;
        //    if (nd.IsView(strTable))
        //        return true;
        //    b = nd.MakeTableExist(strTable);
        //    SortedList ps = c.CoalesceProps();
        //    n_prop p;
        //    StringBuilder s = new StringBuilder();
        //    s.Append("select top 1 icon_index, grid_color, date_created, date_modified");

        //    if (recall)
        //    {
        //        s.Append(", recall_date, recall_user_uid, recall_user_name, recall_machine_name, recall_type, recall_version, recall_uid");
        //    }

        //    foreach (DictionaryEntry d in ps)
        //    {
        //        p = (n_prop)d.Value;
        //        s.Append(", " + p.name);
        //    }
        //    s.Append(" from " + strTable);
        //    if (!nd.StatementPasses(s.ToString()))
        //    {
        //        context.TheLeader.Comment("Updating structure on " + strTable + "...");
        //        foreach (DictionaryEntry d in ps)
        //        {
        //            p = (n_prop)d.Value;
        //            b = nd.MakeFieldExist(strTable, p.name, p.property_type, p.property_length);
        //        }
        //        b = nd.MakeFieldExist(strTable, "grid_color", (Int32)FieldType.Int32, 4);
        //        b = nd.MakeFieldExist(strTable, "icon_index", (Int32)FieldType.Int32, 4);
        //        b = nd.MakeFieldExist(strTable, "date_created", (Int32)FieldType.DateTime, 8);
        //        b = nd.MakeFieldExist(strTable, "date_modified", (Int32)FieldType.DateTime, 8);
        //        if (recall)
        //        {
        //            b = nd.MakeFieldExist(strTable, "recall_date", (Int32)FieldType.DateTime, 8);
        //            b = nd.MakeFieldExist(strTable, "recall_user_uid", (Int32)FieldType.String, 50);
        //            b = nd.MakeFieldExist(strTable, "recall_user_name", (Int32)FieldType.String, 255);
        //            b = nd.MakeFieldExist(strTable, "recall_machine_name", (Int32)FieldType.String, 255);
        //            b = nd.MakeFieldExist(strTable, "recall_type", (Int32)FieldType.Int32, 8);
        //            b = nd.MakeFieldExist(strTable, "recall_version", (Int32)FieldType.String, 255);
        //            if (!nd.FieldExists(strTable, "recall_uid"))
        //            {
        //                context.TheLeader.Comment("Adding recall uid on " + strTable + "...");
        //                b = nd.MakeFieldExist(strTable, "recall_uid", (Int32)FieldType.String, 255);
        //                nd.Execute("update " + strTable + " set recall_uid = cast(newid() as varchar(255)) where recall_uid is null");
        //            }
        //        }
        //    }
        //    return b;
        //}

        //deprecated
        //public bool MakeChildLoaded(String strName)
        //{
        //    return MakeChildLoaded(new SystemLoadArgs(strName));
        //}
        //public bool MakeChildLoaded(String strName, String strAlias)
        //{
        //    return MakeChildLoaded(new SystemLoadArgs(strName, strAlias));
        //}
        //public bool MakeChildLoaded(SystemLoadArgs args)
        //{
        //    n_sys s = (n_sys)this.SystemsByName[args.Name];
        //    if (s != null)
        //    {
        //        n_sys l = (n_sys)this.LoadedSystems[args.Name];
        //        if (l != null)
        //            return true;
        //        s.DatabaseAlias = args.Alias;
        //        if (args.SystemObject == null)
        //        {
        //            args.SystemObject = s;
        //        }
        //        else
        //        {
        //            args.SystemObject.MyNode = s.MyNode;
        //            args.SystemObject.DatabaseAlias = args.Alias;
        //            s.MyNode = null;
        //        }
        //        args.auto_load_subsystems = false;
        //        l = this.LoadSystem(args);
        //        return (l != null);
        //    }
        //    n_sys r;
        //    foreach (DictionaryEntry d in LoadedSystems)
        //    {
        //        r = (n_sys)d.Value;
        //        if (r.MakeChildLoaded(args))
        //            return true;
        //    }
        //    if (args.SystemObject == null)
        //        return false;
        //    args.SystemObject.DatabaseAlias = args.Alias;
        //    args.auto_load_subsystems = false;
        //    n_sys xl = this.LoadSystem(args);
        //    return (xl != null);
        //    return false;
        //}

        //public n_class GetClassByName_Up(String strClass)
        //{
        //    try
        //    {
        //        n_class c = (n_class)ClassesByName[strClass.ToLower()];
        //        if (ParentSystem == null)
        //        {
        //            return c;
        //        }
        //        else
        //        {
        //            if (c == null)
        //                return null;

        //            n_class pc = ParentSystem.GetClassByName_Up(strClass);
        //            if (pc == null)
        //                return c;
        //            else
        //                return pc;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //}

        //public virtual CoreClassHandle GetClassByName(String strClass)
        //{
        //    return SysNewMethod.ContextDefault.TheSys.CoreClassGet(strClass);
        //}

        //public virtual n_class GetClassByID(String strID)
        //{
        //    try
        //    {
        //        n_class c = (n_class)xStructure.Classes.GetByID(strID);
        //        if (c != null)
        //            return c;

        //        ////parents/supporting systems
        //        //if (ParentSystems != null)
        //        //{
        //        //    foreach (n_sys xs in ParentSystems.All)
        //        //    {
        //        //        c = xs.GetClassByID(strID);
        //        //        if (c != null)
        //        //            return c;
        //        //    }
        //        //}

        //        return null;
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //}

        //public bool AbsorbClass(n_class c)
        //{
        //    xStructure.Classes.Add(c);
        //    xStructure.xRefresh.Refresh();
        //    return true;
        //}

        //deprecated
        //public n_sys AddNewSystem(String strName)
        //{
        //    return AddNewSystem(strName, "");
        //}
        //public n_sys AddNewSystem(String strName, String strAlias)
        //{
        //    //data
        //    if (!xData.CreateDatabase(strName))
        //        return null;
        //    n_sys s = new n_sys(this);
        //    s.system_name = strName;
        //    s.system_index = this.GetNextSystemOrder();
        //    s.parent_update = System.DateTime.Now;
        //    s.DatabaseAlias = strAlias;
        //    s.ISave();
        //    s.ParentSystem = this;
        //    //create the nParentSystem table
        //    s.xData = new nData(n_data_target.dTargetType, n_data_target.dServerName, strName, n_data_target.dUserName, n_data_target.dPassword);
        //    s.xData.Execute("create table nParentSystem(unique_id varchar(50), name varchar(255))");
        //    s.xData.Execute("insert into nParentSystem(unique_id, name) values ('" + Tools.Strings.GetNewID() + "', '" + this.system_name + "')");
        //    this.UpdateChildSystem(s);
        //    //file structure
        //    String r = s.GetRootFolder();
        //    nTools.MakeFolderExist(r);
        //    System.IO.Directory.CreateDirectory(r + "Forms\\");
        //    System.IO.Directory.CreateDirectory(r + "Systems\\");
        //    System.IO.Directory.CreateDirectory(r + "Views\\");
        //    System.IO.Directory.CreateDirectory(r + "iObjects\\");
        //    System.IO.Directory.CreateDirectory(r + "iObjects\\Auto\\");
        //    String st = r + "iObjects\\n_sys_" + s.system_name + ".cs";
        //    String o = Tools.Files.OpenFileAsString("c:\\new_method\\template\\NewSystem.cs").Replace("<system_name>", s.system_name);
        //    Tools.Files.SaveFileAsString(st, o);
        //    //it isn't inserted into program.cs yet, so that it can continue to be soft
        //    this.AbsorbSystem(s);
        //    //can't do this, because the new system code file isn't even loaded yet
        //    //maybe load it with a 'soft' n_sys object?
        //    this.LoadSystem(s, false);
        //    s.MyNode.ExpandAll();
        //    return s;
        //}
        //public n_sys LoadSystem(n_sys s, bool AutoLoadSubSystems)
        //{
        //    SystemLoadArgs args = new SystemLoadArgs(s.system_name);
        //    args.auto_load_subsystems = AutoLoadSubSystems;
        //    args.SystemObject = s;
        //    return LoadSystem(args);
        //}
        //public n_sys LoadSystem(SystemLoadArgs args)
        //{
        //    if (LoadedSystems == null)
        //        LoadedSystems = new SortedList();
        //    context.TheLeader.Comment("Loading " + args.Name);
        //    if (args.SystemObject.MyNode != null)
        //        args.SystemObject.MyNode.Parent.Nodes.Remove(args.SystemObject.MyNode);
        //    //set this system as 'loaded' in this's database
        //    if (xData.CanConnect())
        //        this.xData.Execute("update n_sys set is_loaded = 1 where system_name = '" + args.SystemObject.system_name + "'");
        //    if (args.SystemObject.xSys != null)
        //    {
        //        args.SystemObject.is_loaded = true;
        //        if (args.SystemObject.xData != null)
        //        {
        //            if (args.SystemObject.xData.CanConnect())
        //                args.SystemObject.ISave();
        //        }
        //    }
        //    //throw new NotImplementedException("System selection in Program or similar");
        //    n_sys a = args.SystemObject;
        //    a.DatabaseAlias = args.SystemObject.DatabaseName;
        //    a.ParentSystem = this;
        //    LoadedSystems.Add(a.system_name, a);
        //    //switch the args to use the a system
        //    args.Name = a.system_name;
        //    args.SystemObject = a;
        //    if (a.Init(MySystemNode, args))
        //    {
        //        if (a.MyNode != null)
        //            a.MyNode.ForeColor = System.Drawing.Color.Blue;
        //        a.icons = this.icons;
        //    }
        //    else
        //    {
        //        LoadedSystems.Remove(a.system_name);
        //        SystemsByName.Remove(a.system_name);
        //        args.SystemObject.IsPlaceHolder = true;
        //        this.AbsorbSystem(args.SystemObject);
        //        return args.SystemObject;
        //    }
        //    return a;
        //}
        //public String GetClassID(String strClassName)
        //{
        //    try
        //    {
        //        return (GetClassByName(strClassName).unique_id);
        //    }
        //    catch (Exception e)
        //    {
        //    }
        //    return "";
        //}
        //public String GetRootFolder()
        //{
        //    return n_sys.GetRootFolder(system_name);
        //}




        //public nObject GetByName(String strClass, String strNameField, String strNameValue)
        //{
        //    return GetByName(strClass, strNameField, strNameValue, "");
        //}
        //public nObject GetByName(String strClass, String strNameField, String strNameValue, String AltTableName)
        //{
        //    return GetByName(strClass, strNameField, strNameValue, AltTableName, xData);
        //}
        //public virtual nObject GetByName(String strClass, String strNameField, String strNameValue, String AltTableName, nData xd)
        //{
        //    //if (DisconnectedMode)
        //    //    return null;
        //        //return GetByID_FromXml(strClass, strNameValue);
        //    if (xd == null)
        //        xd = xData;
        //    String table = strClass;
        //    if (Tools.Strings.StrExt(AltTableName))
        //        table = AltTableName;
        //    if (Tools.Strings.StrExt(strClass) && Tools.Strings.StrExt(strNameValue))
        //    {
        //        nObject o = QtO(xd, strClass, "select * from " + table + " where " + strNameField + " = '" + strNameValue + "'");
        //        if (o != null)
        //            o.TableName = AltTableName;
        //        return o;
        //    }
        //    else
        //        return null;
        //}

        //public nObject GetByID_FromXml(String strClass, String strID)
        //{
        //    nObject x = MakeObject(strClass);
        //    if (x == null)
        //        return null;
        //    x.unique_id = strID;
        //    if (!x.CreateFromXml())
        //        return null;
        //    return x;
        //}


        //public List<CoreVarValAttribute> GetPropsByClass(String classId)
        //{
        //    try
        //    {
        //        return SysNewMethod.ContextDefault.TheSys.CoreClassGet(classId).VarValsGet();
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        //public SortedList GetPropsByClass(String strClass)
        //{
        //    //try
        //    //{
        //    //    n_class c = this.GetClassByName(strClass);
        //    //    return c.PropsInOrder;
        //    //}
        //    //catch (Exception e)
        //    //{
        //    //}
        //    //return null;
        //    //why would this not be appropriate?
        //    return CoalescePropsByClass(strClass);
        //}
        //public SortedList GetPropsByNameByClass(String strClass)
        //{
        //    try
        //    {
        //        n_class c = this.GetClassByName(strClass);
        //        return c.Props.AllByName;
        //    }
        //    catch (Exception e)
        //    {
        //        nError.HandleError(e);
        //    }
        //    return null;
        //}
        //public SortedList CoalescePropsByClass(String strName)
        //{
        //    return CoalescePropsByClass(strName, "", "", false, false);
        //}
        //public SortedList CoalescePropsByClass(String strName, String strExcludeNamespace, String strExcludeClass, bool bPropertyTag, bool IncludeSys)
        //{
        //    n_class c = GetClassByName(strName);
        //    if (c == null)
        //        return new SortedList();
        //    return c.CoalesceProps(strExcludeNamespace, strExcludeClass, bPropertyTag, IncludeSys);
        //}
        //public SortedList CoalesceClasses()
        //{
        //    SortedList l = new SortedList();
        //    this.CoalesceClasses(l);
        //    return l;
        //}
        //public SortedList CoalesceUniqueClasses()
        //{
        //    SortedList l = new SortedList();
        //    this.CoalesceUniqueClasses(l);
        //    return l;
        //}
        public n_choices GetChoicesByID(String strID)
        {
            if (AllChoices == null)
                return null;

            n_choices c = (n_choices)AllChoices.GetByID(strID);
            if (c == null)
            {
                //foreach (n_sys xs in ParentSystems.All)
                //{
                //    c = xs.GetChoicesByID(strID);
                //    if (c != null)
                //        return c;
                //}
                return null;
            }
            else
                return c;
        }
        public n_choices GetChoicesByName(String strName)
        {
            if (AllChoices == null)
                return null;

            n_choices c = (n_choices)AllChoices.GetByName(strName);
            if (c == null)
            {
                //foreach (n_sys xs in ParentSystems.All)
                //{
                //    c = xs.GetChoicesByID(strName);
                //    if (c != null)
                //        return c;
                //}
                return null;
            }
            else
                return c;
        }
        //public n_relate GetRelateByClass(string strClass, string strRelateName, string strRelatedClass)
        //{
        //    n_class c = GetClassByName(strClass);
        //    if (c == null)
        //        return null;
        //    return c.GetRelateByName(strRelateName, this.GetClassID(strRelatedClass));
        //}
        //public nView GetSoftView(String strClass, String strExtra)
        //{
        //    n_form f = (n_form)QtO("n_form", "select top 1 * from n_form where the_n_class_uid = '" + GetClassID(strClass) + "'");
        //    if (f == null)
        //        return null;
        //    nView v = new nView();
        //    v.CurrentForm = f;
        //    return v;
        //}

        //needed?
        //public n_sys GetLoadedChild(String strName)
        //{
        //    n_sys s = (n_sys)LoadedSystems[strName];
        //    if (s != null)
        //        return s;
        //    s = (n_sys)SystemsByName[strName];
        //    if (s != null)
        //        return s;
        //    n_sys r;
        //    foreach (DictionaryEntry d in LoadedSystems)
        //    {
        //        s = (n_sys)d.Value;
        //        r = s.GetLoadedChild(strName);
        //        if (r != null)
        //            return r;
        //    }
        //    return null;
        //}

        //these don't make sense in the new context
        //public Stack GatherParentStack()
        //{
        //    Stack s = new Stack();
        //    AddParentStack(s);
        //    return s;
        //}
        //public Int32 GetHeight()
        //{
        //    if (ParentSystems.Count == 0)
        //        return 0;
        //    else
        //    {
        //        int i = 0;
        //        foreach (n_sys xs in ParentSystems.All)
        //        {
        //            int h = xs.GetHeight();
        //            if (h > i)
        //                i = h; 
        //        }
        //        return i;
        //    }
        //}
        //public String GetClassName(String strID)
        //{
        //    n_class c = this.GetClassByID(strID);
        //    if (c == null)
        //        return "";
        //    else
        //        return c.class_name;
        //}
        //public nObject MakeBlankInstance(String strClass, n_sys s)
        //{
        //    //'this' is the classes owner, and s is where the instance will be stored
        //    nObject o = new nObject(s);
        //    o.ClassName = strClass;
        //    o.CreateBlank(s);
        //    return o;
        //}
        //public virtual void ThrowObjectUp(nObject xObject)
        //{
        //    if (xObject == null)
        //        return;
        //    ThrowObjectUp(new ShowArgs(SysNewMethod.ContextDefault, xObject));
        //}
        //public virtual void ViewLogs(ContextNM x, nObject o)
        //{
        //    if (x == null)
        //        return;
        //    if (o == null)
        //        return;
        //    MessageBox.Show("reorg");
        //    //x.xSys.ThrowObjectList("n_log", o.GetLogWhere(), "date_created", "object_logs", 200, "Logs");
        //}
        //public virtual n_log AddLog(ContextNM x, nObject o)
        //{
        //    if (x == null)
        //        return null;
        //    if (o == null)
        //        return null;
        //    String s = nStatus.InputMessageBoxMultiLine("Log Info:", "", "Log Info", null);
        //    if (!Tools.Strings.StrExt(s))
        //        return null;
        //    return o.AddLog(x, s, true);
        //}
        public virtual bool ViewChangeHistory(ContextNM x, nObject o)
        {
            if (x == null)
                return false;
            if (o == null)
                return false;

            ShowArgs args = new ShowArgs(x, o);
            args.ShowChanges = true;
            return x.Show(args);

            //return x.xSys.Show(new ShowArgs(o, false, false, false, true, false, ""));
        }


        //public void ThrowObjectList(String strClass, String strWhere, String strOrder, String strTemplate, long limit, String strCaption)
        //{
        //    if (DefaultShowHandler != null)
        //    {
        //        DefaultShowHandler(this, new ShowArgs(this, strClass, strWhere, strOrder, strTemplate, limit, strCaption));
        //    }
        //    else if( xMainForm != null )
        //    {
        //        xMainForm.ShowHandler(this, new ShowArgs(this, strClass, strWhere, strOrder, strTemplate, limit, strCaption));
        //    }
        //}


        //how should this work now?
        //public void CheckParentUpdate(SystemLoadArgs args)
        //{
        //    if (ParentSystem == null)
        //        return;
        //    if (n_sys.UseXmlStructure && !Tools.Misc.IsDevelopmentMachine())
        //    {
        //        if (xData.CanConnect())
        //        {
        //            //check the latest version
        //            long last = GetSetting_Long("last_structure_version");
        //            if (GetVersionNumber() > last)
        //            {
        //                DoParentUpdate(args);
        //                SetSetting_Long("last_structure_version", GetVersionNumber());
        //            }
        //        }
        //    }
        //    else
        //    {
        //        bool b = false;
        //        if (!Tools.Dates.DateExists(ParentSystem.structure_changed))
        //            b = true;
        //        if (!Tools.Dates.DateExists(this.parent_update))
        //            b = true;
        //        if (ParentSystem.structure_changed > this.parent_update)
        //            b = true;
        //        if (b)
        //            DoParentUpdate(args);
        //    }
        //}
        //public void DoParentUpdate(SystemLoadArgs args)
        //{
        //    if (ParentSystem == null)
        //        return;
        //    ParentSystem.UpdateChildSystem(this, args);
        //}
        //public bool IsSoft(String strClass)
        //{
        //    n_class c = GetClassByName(strClass);
        //    if (c == null)
        //        return false;
        //    else
        //        return c.is_soft;
        //}
        public void SetNeedsUpdate()
        {
            MessageBox.Show("sysreorg");
            //this.SetStructureChanged();
            //n_class c;
            //foreach (DictionaryEntry d in xStructure.Classes.AllByName)
            //{
            //    c = (n_class)d.Value;
            //    c.SetSoft();
            //}
        }
        //public void RelateTwoClasses(n_class parent, n_class child, String strName, Boolean order, Enums.RelationshipType type)
        //{
        //    //check the child object for the parent's uid field
        //    String s = strName + "_" + parent.class_name + "_uid";
        //    child.SetSoft();
        //    if (type == Enums.RelationshipType.ParentChild)
        //    {
        //        if (!child.HasProp(s))
        //        {
        //            n_prop p = new n_prop(child.xSys);
        //            p.property_length = 255;
        //            p.name = s;
        //            p.property_tag = nTools.NiceFormat(p.name);
        //            p.property_type = (Int32)FieldType.String;
        //            p.property_order = child.GetNextRelatePropOrder();
        //            p.the_n_class_uid = child.unique_id;
        //            p.is_soft = true;
        //            p.ISave();
        //            child.AbsorbProperty(p);
        //            child.MakeFieldExist(p);
        //            child.SetChanged(true);
        //        }
        //        //Check the child object's order property
        //        if (order)
        //        {
        //            s = strName + "_" + parent.class_name + "_order";
        //            if (!child.HasProp(s))
        //            {
        //                n_prop p = new n_prop(child.xSys);
        //                p.property_length = 8;
        //                p.name = s;
        //                p.property_tag = nTools.NiceFormat(p.name);
        //                p.property_type = (Int32)FieldType.Int64;
        //                p.is_soft = true;
        //                child.AbsorbNewProperty(p, false);
        //            }
        //        }
        //    }
        //    //make the relationship
        //    n_relate r = new n_relate(this);
        //    r.name = strName;
        //    r.left_n_class_uid = parent.unique_id;
        //    r.left_class_name = parent.class_name;
        //    r.right_n_class_uid = child.unique_id;
        //    r.right_class_name = child.class_name;
        //    r.is_order = order;
        //    r.RelateType = type;
        //    r.ISave();

        //    //add it to each class
        //    parent.AbsorbRelate(r);
        //    child.AbsorbRelate(r);
        //    if (type == NewMethod.Enums.RelationshipType.Inherit)
        //    {
        //        //make sure that the derived class
        //        //and all of the derived class's derived classes
        //        //have the new field
        //        parent.MakeAllFieldsExist();

        //    }
        //}
        //public bool HasClass(String strName)
        //{
        //    if (xStructure.Classes.HasName(strName))
        //        return true;

        //    //foreach (n_sys xs in ParentSystems.All)
        //    //{
        //    //    if (xs.HasClass(strName))
        //    //        return true;
        //    //}

        //    return false;
        //}

        //pending review
        //public void RemoveRelate(n_relate r)
        //{
        //    if (r.LeftClass != null)
        //        r.LeftClass.RemoveChildRelate(r);
        //    if (r.RightClass != null)
        //        r.RightClass.RemoveParentRelate(r);
        //    AllRelates.Remove(r.unique_id);
        //    r.IDelete();
        //}

        //not needed
        //public void SetExpanded(bool ex)
        //{
        //    if (ParentSystem == null)
        //        return;
        //    ParentSystem.xData.Execute("update n_sys set is_expanded = " + nData.BoolFilter(ex) + " where system_name = '" + this.system_name + "'");
        //}

        //handled by structure now
        //public void LinkChildRelates(n_sys childsys, ArrayList UpdatedRelates)
        //{
        //    n_class c;
        //    foreach (DictionaryEntry d in xStructure.Classes.AllByName)
        //    {
        //        c = (n_class)d.Value;
        //        c.InitRelatesFromSystem(childsys, UpdatedRelates);
        //    }
        //    if (ParentSystem != null)
        //        ParentSystem.LinkChildRelates(childsys, UpdatedRelates);
        //}
        //public void UnLinkChildRelates(n_sys childsys)
        //{
        //    n_class c;
        //    foreach (DictionaryEntry d in xStructure.Classes.AllByName)
        //    {
        //        c = (n_class)d.Value;
        //        c.UnInitRelatesFromSystem(childsys);
        //    }
        //    if (ParentSystem != null)
        //        ParentSystem.UnLinkChildRelates(childsys);
        //}

        public bool Backup()
        {
            MessageBox.Show("sysreorg");
            //String s = this.system_name + "_";
            return false;
        }

        //public void AddParentStack(Stack s)
        //{
        //    s.Push(this);
        //    if (this.ParentSystem != null)
        //        ParentSystem.AddParentStack(s);
        //}
        //public bool CompileCompleteDatabase()
        //{
        //    if (ParentSystem == null)
        //    {
        //        context.TheLeader.Error("The NewMethod system, or a system with no parent, cannot be compiled into a complete database.");
        //        return false;
        //    }
        //    String strName = this.system_name + "_Complete";
        //    if (xData.DatabaseExists(strName))
        //    {
        //        context.TheLeader.Error("The database '" + strName + " already exists.");
        //        return false;
        //    }
        //    nData d = new nData(this.xData);
        //    if (!d.CreateDatabase(strName))
        //    {
        //        return false;
        //    }
        //    nData data = new nData(this.xData);
        //    data.ReTargetDatabase(strName);
        //    if (!data.CanConnect())
        //    {
        //        context.TheLeader.Error("Can't connect to " + strName + "'");
        //        return false;
        //    }
        //    Stack s = this.GatherParentStack();
        //    if (s.Count == 0)
        //        return true;
        //    n_sys sy;
        //    ArrayList a = new ArrayList();
        //    context.TheLeader.StartPercent(s.Count);
        //    int j = s.Count;
        //    for (int i = 0; i < j; i++)
        //    {
        //        sy = (n_sys)s.Pop();
        //        context.TheLeader.Comment("Compiling " + sy.system_name);
        //        nStatus.UpChannel();
        //        if (!sy.InsertIntoDatabase(data, Tools.Strings.StrCmp(sy.system_name, this.system_name)))
        //        {
        //            nStatus.DownChannel();
        //            nStatus.StopPercent();
        //            return false;
        //        }
        //        nStatus.DownChannel();
        //        context.TheLeader.AddPercent();
        //    }
        //    nStatus.StopPercent();
        //    context.TheLeader.Comment("Database compiling of " + this.system_name + " is complete.");
        //    return true;
        //}
        //public bool InsertIntoDatabase(nData dest, bool include_sys)
        //{
        //    if (xStructure.Classes.Count == 0)
        //        return true;

        //    n_class c;
        //    SortedList cs = this.CoalesceClasses();
        //    context.TheLeader.StartPercent(cs.Count);
        //    foreach (DictionaryEntry d in cs)
        //    {
        //        c = (n_class)d.Value;
        //        if (!Tools.Strings.StrCmp(c.class_name, "n_sys") || include_sys)
        //        {
        //            context.TheLeader.Comment("Inserting " + c.class_name);
        //            c.CreateMyOwnDataStructure(dest);
        //            if (!dest.Execute("insert into " + c.class_name + " (" + c.GetFieldList() + ") select " + c.GetFieldList() + " from " + xData.database_name + ".dbo." + c.class_name))
        //            {
        //                nStatus.StopPercent();
        //                return false;
        //            }
        //        }
        //        context.TheLeader.AddPercent();
        //    }
        //    nStatus.StopPercent();
        //    return true;
        //}

        //public void CoalesceClasses(SortedList l)
        //{
        //    n_class c;
        //    foreach (DictionaryEntry d in xStructure.Classes.AllByName)
        //    {
        //        c = (n_class)d.Value;
        //        if (!c.is_abstract)
        //        {
        //            if( !l.Contains(c.unique_id) )
        //                l.Add(c.unique_id, c);
        //        }
        //    }

        //    //foreach (n_sys xs in ParentSystems.All)
        //    //{
        //    //    xs.CoalesceClasses(l);
        //    //}
        //}
        //public void CoalesceUniqueClasses(SortedList l)
        //{
        //    n_class c;
        //    foreach (DictionaryEntry d in xStructure.Classes.AllByName)
        //    {
        //        try
        //        {
        //            c = (n_class)d.Value;
        //            if (!c.is_abstract)
        //                l.Add(c.class_name, c);
        //        }
        //        catch (Exception)
        //        {
        //        }
        //    }

        //    //foreach (n_sys xs in ParentSystems.All)
        //    //{
        //    //    xs.CoalesceUniqueClasses(l);
        //    //}
        //}

        public String TranslateUserNameToID(String name)
        {
            return Users.NameToID(name);
        }
        public String TranslateUserIDToName(String id)
        {
            try
            {
                return ((n_user)Users.GetByID(id)).name;
            }
            catch { return ""; }
        }
        public String TranslateTeamIDToName(String id)
        {
            if (Teams == null)
                return "";

            return Teams.IDToName(id);
        }
        public String TranslateTeamNameToID(String strName)
        {
            return Teams.NameToID(strName);
        }
        public void FillTeamTree(ContextNM x)
        {
            Teams = new nArray();
            TeamTree = new nArray();
            ArrayList l = x.QtC("n_team", "select * from n_team where isnull(the_n_team_uid, '') = '' order by name");
            foreach (n_team t in l)
            {
                AbsorbTeam(t);
                t.FillTeamTree(x, null, Teams);
            }
        }
        public nArray CollectMembershipsByUser(String strUserID)
        {
            nArray a = new nArray();
            foreach (n_team t in TeamTree.All)
            {
                t.CollectMembershipsByUser(strUserID, a);
            }
            return a;
        }
        public void AbsorbTeam(n_team t)
        {
            Teams.Add(t);
            TeamTree.Add(t);
        }
        public void RemoveTeam(n_team t)
        {
            Teams.Remove(t);
            TeamTree.Remove(t);
        }
        public void CacheTeamPermits(ContextNM x)
        {
            foreach (n_team t in Teams.All)
            {
                t.CachePermits(x);
            }
        }
        public void SetUpdateFolder(ContextNM x, String strFolder)
        {
            n_set.SetSetting(x, "update_folder", strFolder);
        }
        public void CheckHighestVersion(ContextNM x)
        {
            Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            highest_majorversion = n_set.GetSetting_Integer(x, "highest_majorversion_ex");
            highest_minorversion = n_set.GetSetting_Integer(x, "highest_minorversion_ex");
            highest_revision = n_set.GetSetting_Integer(x, "highest_revision_ex");
            highest_private = n_set.GetSetting_Integer(x, "highest_private_ex");
            x.TheLeader.Comment("CheckHighestVersion : " + highest_majorversion.ToString() + "." + highest_minorversion.ToString() + "." + highest_revision.ToString() + "." + highest_private.ToString());
        }
        public void SetHighestVersion(ContextNM x)
        {
            Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            n_set.SetSetting_Integer(x, "highest_majorversion_ex", fvi.ProductMajorPart);
            n_set.SetSetting_Integer(x, "highest_minorversion_ex", fvi.ProductMinorPart);
            n_set.SetSetting_Integer(x, "highest_revision_ex", fvi.ProductBuildPart);
            n_set.SetSetting_Integer(x, "highest_private_ex", fvi.ProductPrivatePart);
            CheckHighestVersion(x);
        }
        public void SetMinVersion(ContextNM x)
        {
            Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            long min = Tools.Misc.GetVersionNumber(Tools.ToolsNM.AssemblyNM);
            if (!x.TheLeader.AreYouSure("set the minimum version for this system at " + min.ToString()))
                return;
            n_set.SetSetting_Long(x, "minimum_system_version", min);
        }
        public String GetHighestVersion()
        {
            return highest_majorversion.ToString() + "." + highest_minorversion.ToString() + "." + highest_revision.ToString() + "." + highest_private.ToString();
        }
        public String GetUpdateFolder(ContextNM x)
        {
            return n_set.GetSetting(x, "update_folder");
        }

        public nObject GetByKey(ContextNM x, String strKey)
        {
            String strClass = Tools.Strings.ParseDelimit(strKey, ":", 1);
            String strID = Tools.Strings.ParseDelimit(strKey, ":", 2);
            return (nObject)x.GetById(strClass, strID);
        }
        public void ThrowByKey(ContextNM x, String strKey)
        {
            x.Show(GetByKey(x, strKey));
        }

        public long GetVersionNumber()
        {
            Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            return (Convert.ToInt64(fvi.ProductMajorPart) * 100000) + (Convert.ToInt64(fvi.ProductMinorPart) * 100) + fvi.ProductBuildPart;
        }
        
        private Boolean CustomerInList(ContextNM x, String list)
        {
            if (!Tools.Strings.StrExt(list))
                return false;
            String comp = n_set.GetSetting(x, "company_identifier");
            if (!Tools.Strings.StrExt(comp))
                return false;
            String[] split = Tools.Strings.Split(list, ",");
            foreach (String s in split)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                if (Tools.Strings.StrCmp(s, comp))
                    return true;
            }
            return false;
        }

        public virtual nArray GetCubeUsers()
        {
            return Users;
        }

        public virtual nArray GetCubeTeams()
        {
            return Teams;
        }

        public bool TextUserByName(String name, String text)
        {
            n_user u = (n_user)Users.GetByName(name);
            if (u != null)
                return u.TextSend(text);
            else
                return false;
        }

        public IItem ItemGetByTag(Context x, ItemTag t)
        {
            return x.GetById(t.ClassId, t.Uid);
        }

        public static void UpdateAllByClass(ContextNM x, String class_name, bool silent = false)
        {
            ArrayList a = x.TheData.SelectScalarArray("select unique_id from " + class_name);
            int count = 0;
            int process = 0;
            foreach (String s in a)
            {
                process++;
                x.TheLeader.Comment("Updating " + class_name + " record " + process.ToString() + " of " + a.Count.ToString());
                nObject instance = (nObject)x.GetById(class_name, s);
                if (instance != null)
                {
                    instance.Changed = true;
                    x.Update(instance);
                    count++;
                }
            }
            if (!silent)
                x.TheLeader.Tell("Done: " + Tools.Strings.PluralizePhrase("instance", count) + " updated");
        }

        //public void A ctionHandle(Context context, ActArgs args)
        //{

        //}

        //public virtual void A ctionHandleClass(Context context, ActArgs args, String class_name)
        //{
        //    HandleActionNM((ContextNM)context, args);
        //}

        //public static void HandleActionNM(ContextNM context, ActArgs args)
        //{
        //    foreach (IItem i in args.TheItems.AllGet(context))
        //    {
        //        nObject x = (nObject)i;
        //        x.HandleAction(args);
        //        //x.HandleAction(context, args.ActionName.Replace(" ", "").ToLower());
        //    }
        //    //this has to be here or everything gets done twice
        //    args.Handled = true;
        //}


        //public virtual bool Init(nData xd)
        //{
        //    xStructure = new nStructure(this);

        //    foreach (String n in SystemNames)
        //    {
        //        StructureHandle h = new StructureHandle();
        //        h.HandleType = StructureType.XmlStructure;
        //        h.EmbeddedResource = true;
        //        h.XmlFileName = n + "." + n + ".xml";
        //        xStructure.InitFromHandle(h, null);
        //    }

        //    xStructure.AbsorbRelates();

        //    xData = xd;
        //    return true;
        //}

        //public XmlDocument GetXmlByName(String name)
        //{
        //    foreach (Assembly a in AssemblyList() )
        //    {
        //        Stream s = a.GetManifestResourceStream(name);
        //        if (s != null)
        //        {
        //            XmlDocument xdoc = new XmlDocument();
        //            StreamReader reader = new StreamReader(s);
        //            xdoc.LoadXml(reader.ReadToEnd());
        //            reader.Close();
        //            return xdoc;
        //        }
        //    }
        //    return null;
        //}

        ////instance

        //IRefreshable m_xLine = null;
        //public IRefreshable xLine
        //{
        //    get
        //    {
        //        return m_xLine;
        //    }
        //    set
        //    {
        //        if (m_xLine != null)
        //            xStructure.xRefresh.Remove(m_xLine);

        //        m_xLine = value;

        //        xStructure.xRefresh.Add(m_xLine);
        //    }
        //}

        //public static void SetField(ContextNM context, IItems items, String field)
        //{
        //    List<IItem> l = items.AllGet(context);

        //    String val = context.TheLeader.AskForString("New " + Tools.Strings.NiceFormat(field) + ":").ToUpper();
        //    if (!Tools.Strings.StrExt(val))
        //        return;

        //    if (!context.TheLeader.AreYouSure("set " + Tools.Strings.PluralizePhrase("line", l.Count) + " to " + Tools.Strings.NiceFormat(field) + " " + val))
        //        return;

        //    context.TheLeader.StartPopStatus("Setting " + Tools.Strings.NiceFormat(field) + " to " + val);

        //    foreach (IItem p in l)
        //    {
        //        p.ValSet(field, val);
        //        context.TheDelta.Update(context, p);
        //        context.TheLeader.Comment("Set " + p.ToString());
        //    }

        //    context.TheLeader.Comment("Done");
        //    context.TheLeader.StopPopStatus(false);
        //}

        //public static void SetFieldDouble(ContextNM context, IItems items, String field)
        //{
        //    List<IItem> l = items.AllGet(context);

        //    bool cancel = false;
        //    Double val = context.TheLeader.AskForDouble("New " + Tools.Strings.NiceFormat(field) + ":", 0, "New Value", ref cancel);
        //    if (cancel)
        //        return;

        //    if (!context.TheLeader.AreYouSure("set " + Tools.Strings.PluralizePhrase("line", l.Count) + " to " + Tools.Strings.NiceFormat(field) + " " + val.ToString()))
        //        return;

        //    context.TheLeader.StartPopStatus("Setting " + Tools.Strings.NiceFormat(field) + " to " + val);

        //    foreach (IItem p in l)
        //    {
        //        p.ValSet(field, val);
        //        context.TheDelta.Update(context, p);
        //        context.TheLeader.Comment("Set " + p.ToString());
        //    }

        //    context.TheLeader.Comment("Done");
        //    context.TheLeader.StopPopStatus(false);
        //}

        //public virtual String InstallFolderPrefix
        //{
        //    get
        //    {
        //        return system_name;
        //    }
        //}
    }
    //public delegate n_sys MakeSystemHandler(String strName);
}
