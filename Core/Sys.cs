using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;

using Core.Display;
using Tools.Database;
using System.ComponentModel;
using System.Diagnostics;

namespace Core
{
    public class Sys
    {
        public Sys()
        {
            TheLogic = LogicCreate();
        }

        protected virtual Logic LogicCreate()
        {
            return new Logic();
        }

        public String CurrencySymbol = "$";

        public virtual String Name
        {
            get
            {
                return "Core";
            }
        }

        public IItem ItemGetByTag(Context x, ItemTag t)
        {
            return x.TheData.Create(x, t.ClassId, x.TheData.SelectRow(x, new QueryItem(t), null));  //, PropsGetByClass(t.ClassId)
        }

        //this may need to cache a full list or something on startup; this is going to be slow to do this loop every time
        //2012_04_15 cached now.  i can't believe this wasn't more of a performance drag than it was

        Dictionary<String, Type> ClassTypes = new Dictionary<string, Type>();
        public virtual Item ItemCreate(String classId)  //, ItemArgs args
        {
            Type classType = null;
            if (ClassTypes.ContainsKey(classId))
                classType = ClassTypes[classId];
            else
                classType = ClassTypeFind(classId);

            return (Item)Activator.CreateInstance(classType, new Object[] {  });  //args
        }

        Type ClassTypeFind(String classId)
        {
            List<Assembly> assys = AssemblyList();
            foreach (Assembly a in assys)
            {
                MemberInfo[] mems = a.GetExportedTypes();
                foreach (MemberInfo mem in mems)
                {
                    if (mem.Name == classId)
                    {
                        Type ret = (Type)mem;
                        ClassTypes.Add(classId, ret);
                        return ret;
                    }
                }
            }
            return null;
        }

        public bool isDesignMode()
        {
            bool ret = LicenseManager.UsageMode == LicenseUsageMode.Designtime || Debugger.IsAttached == true;
            return ret;
        }

        public List<Assembly> AssemblyList()
        {
            List<Assembly> ret = new List<Assembly>();
            AssemblyList(ret);
            return ret;
        }

        protected virtual void AssemblyList(List<Assembly> ret)
        {
            ret.Add(Assembly.GetExecutingAssembly());
        }

        public virtual Assembly AssemblyGetHere()
        {
            return Assembly.GetExecutingAssembly();
        }

        public CoreClassHandle CoreClassGet(String classId)
        {
            try
            {
                return CoreClasses[classId];
            }
            catch
            {
                return null;
            }
        }

        Dictionary<String, CoreClassHandle> m_CoreClasses = null;
        public Dictionary<String, CoreClassHandle> CoreClasses
        {
            get
            {
                if (m_CoreClasses == null)
                    CoreClassesCache();
                return m_CoreClasses;
            }
        }

        public List<CoreClassHandle> CoreClassesList()
        {
            List<CoreClassHandle> ret = new List<CoreClassHandle>();
            foreach (KeyValuePair<String, CoreClassHandle> k in CoreClasses)
            {
                ret.Add(k.Value);
            }
            return ret;
        }

        private void CoreClassesCache()
        {
            m_CoreClasses = new Dictionary<String, CoreClassHandle>();
            List<CoreClassHandle> ret = new List<CoreClassHandle>();
            List<Assembly> assys = AssemblyList();
            foreach (Assembly a in assys)
            {
                AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
                //a.ModuleResolve += new ModuleResolveEventHandler(a_ModuleResolve);
                MemberInfo[] mems = a.GetExportedTypes();
                AppDomain.CurrentDomain.AssemblyResolve -= new ResolveEventHandler(CurrentDomain_AssemblyResolve);
                //a.ModuleResolve -= new ModuleResolveEventHandler(a_ModuleResolve);
                foreach (MemberInfo mem in mems)
                {
                    Object[] attrs = mem.GetCustomAttributes(typeof(CoreClassAttribute), false);
                    if (attrs.Length > 0)
                    {
                        CoreClassAttribute attr = (CoreClassAttribute)attrs[0];
                        if (!m_CoreClasses.ContainsKey(attr.Name))
                        {
                            m_CoreClasses.Add(attr.Name, new CoreClassHandle(attr, (Type)mem));
                        }
                    }
                }
            }
        }

        Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return Assembly.LoadFrom(Tools.Folder.ConditionFolderName(Path.GetDirectoryName(args.RequestingAssembly.Location)) + Tools.Strings.ParseDelimit(args.Name, ",", 1) + ".dll");
        }

        //Module a_ModuleResolve(object sender, ResolveEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        public List<CoreClassAttribute> ClassesListExcludeSupport
        {
            get
            {
                List<CoreClassAttribute> ret = new List<CoreClassAttribute>();
                List<String> names = new List<string>();

                List<Assembly> assys = AssemblyList();
                foreach (Assembly a in assys)
                {
                    MemberInfo[] mems = a.GetExportedTypes();
                    foreach (MemberInfo mem in mems)
                    {
                        Object[] attrs = mem.GetCustomAttributes(typeof(CoreClassAttribute), false);
                        if (attrs.Length > 0)
                        {
                            CoreClassAttribute attr = (CoreClassAttribute)attrs[0];
                            if (!attr.SystemSupport)
                            {
                                if (!names.Contains(attr.Name))
                                {
                                    names.Add(attr.Name);
                                    ret.Add(attr);
                                }
                            }
                        }
                    }
                }
                return ret;
            }
        }

        public List<CoreVarAttribute> PropsGetByClass(String classId)
        {
            CoreClassHandle h = CoreClassGet(classId);
            return h.VarsGet();
        }

        //public virtual void A ctionHandle(Context context, ActArgs args)
        //{
        //    List<String> classes = args.TheItems.ClassIdsList(context);
        //    if (classes.Count == 1)
        //        ActionHandleClass(context, args, classes[0]);
        //}

        //public virtual void A ctionHandleClass(Context context, ActArgs args, String class_name)
        //{
        //}

        public virtual IItem ItemGetByQuery(Context x, String classId, Query q)
        {
            return x.TheData.Create(x, classId, x.TheData.SelectRow(x, q, null));
        }

        public virtual IView ViewCreate(Context x, ShowArgs args)
        {
            return null;
        }

        public virtual void ActStatic(Context x, ActArgs args) 
        {
            if (args.TheAct != null && args.TheAct.Handler != null)
                args.TheAct.Handler(x, args);
        }

        public void ActInstanceBeforeAfter(Context x, ActArgs args)
        {
            ActInstanceBefore(x, args);
            if (args.Handled)
                return;
            ActInstance(x, args);
            
            //we haven't implemented this flag rigourously
            //if (!args.Handled)
            //    return;

            ActInstanceAfter(x, args);
        }

        protected virtual void ActInstanceBefore(Context x, ActArgs args)
        {

        }

        //this is here so NM can override it and call the string-based handlers in the nObjects
        //actually this is good in general, as a centralized act handler point
        protected virtual void ActInstance(Context x, ActArgs args)  
        {
            if (args.TheAct != null && args.TheAct.Handler != null)
                args.TheAct.Handler(x, args);
        }

        protected virtual void ActInstanceAfter(Context x, ActArgs args)
        {

        }

        public virtual void ActsListStatic(Context x, ActSetup set)
        {

        }

        public virtual void ActsListInstance(Context x, ActSetup set)
        {
            if (set.ItemsHas(x))
            {
                ItemLogic.ActsListInstance(x, set);

                //changed this 2012_06_08
            //if (set.ItemsHas(x))
            //{
                List<String> classes = set.ClassIdsList(x);
                if (classes.Count == 1)
                    ActsListInstance(x, set, classes[0]);
                else if (classes.Count == 0)
                    return;
                else
                    x.TheLeader.Error("ActsList: ClassIdsList.count > 1 : Needs to be implemented");
            }
        }

        public virtual void ActsListInstance(Context x, ActSetup set, String classId)
        {

        }

        public virtual String CaptionGet(Context x)
        {
            return "";
        }

        //public virtual ProofLogic ProofCreate()
        //{
        //    return new ProofLogic();
        //}

        //public virtual ProveResult Prove(Context x)
        //{
        //    ProofLogic t = ProofCreate();
        //    ProveResult ret = ProofLogic.Prove(x);
        //    return ret;
        //}

        ItemLogic m_ItemLogic;
        public ItemLogic ItemLogic
        {
            get
            {
                if (m_ItemLogic == null)
                    m_ItemLogic = ItemLogicCreate();
                return m_ItemLogic;
            }
        }

        protected virtual ItemLogic ItemLogicCreate()
        {
            return new ItemLogic();
        }

        public Logic TheLogic;

        public Logic Logic
        {
            get
            {
                return TheLogic;
            }

            set
            {
                TheLogic = value;
            }
        }

        //experimenting with events
        public event DeltaHandler Changed;
        public void ChangedFire(Context x, ChangeArgs args)
        {
            if (Changed != null)
                Changed(x, args);
        }

        public List<CoreVarValAttribute> VarVals(String classId)
        {
            return CoreClassGet(classId).VarValsGet();
        }

        ProofLogic m_ProofLogic;
        public ProofLogic ProofLogic
        {
            get
            {
                if (m_ProofLogic == null)
                    m_ProofLogic = ProofLogicCreate();
                return m_ProofLogic;
            }
        }

        protected virtual ProofLogic ProofLogicCreate()
        {
            return new ProofLogic();
        }

        public virtual void FieldMaintenance(Context x)
        {
            DataSql.FieldMaintenance(x, (DataConnectionSqlServer)x.Data.Connection);
        }
    }

    public delegate void DeltaHandler(Context x, ChangeArgs args);
}
