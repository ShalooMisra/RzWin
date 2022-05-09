using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data;
using Core.Display;
using Tools.Database;

namespace Core
{
    public class Item : IItem, IItems
    {
        public virtual String ClassId { get { return ""; } }

        String m_Uid = "";
        public virtual String Uid
        {
            get
            {
                return m_Uid;
            }

            set
            {
                m_Uid = value;
            }
        }

        //protected bool m_ValuesChanged = false;
        //public bool ValuesChanged
        //{
        //    get
        //    {
        //        return m_ValuesChanged;
        //    }
        //}

        //public void ValuesChangedSetDirect(bool value)
        //{
        //    m_ValuesChanged = value;
        //}

        //2011_10_22 this will go away, replaced with the delta system
        //so that the change events can be grouped and handled more efficiently
        //just left this in until we can confirm it isn't needed anymore

        //2012_03_17  taking this out.  if anything, this should be per-var

        //public void ValuesChangedSet(Context x, bool value)
        //{
        //    //is this where events should fire for changes?

        //    bool previous = m_ValuesChanged;
        //    m_ValuesChanged = value;

        //    if (previous && !m_ValuesChanged)
        //    {
        //        //at least fire the refresh event to show when something goes from 'changed' to 'not changed'
        //        if (Change != null)
        //        {
        //            Change(x, new ChangeArgs(ChangeType.Refresh), this);
        //        }                    
        //    }

        //    //if (!m_ValuesChanged)
        //    //{
        //    //    //set all of the contents to ValuesChanged = false;
        //    //    foreach (Item i in ContentsGetList())
        //    //    {
        //    //        i.ValuesChangedSet(x, false);
        //    //    }
        //    //}
        //}

        //public Item(ItemArgs a)
        //{
        //    ////a shouldn't ever be null, right?
        //    //if (a != null)
        //    //{
        //    ////for items that need to be instantiated but not saved
        //    //    Uid = a.Uid;
        //    //    //WatcherAdd(a.TheContext.TheData);
        //    //    //Vars = new Dictionary<String, Var>();
        //    //}
        //}

        //public Dictionary<String, Var> Vars;

        //public String Path
        //{
        //    get
        //    {
        //        if (Container == null)
        //            return Uid;
        //        else
        //            return Container.Path + "." + Uid;
        //    }
        //}

        public int CountGet(Context x)
        {
            return 1;
        }

        public List<IItem> AllGet(Context x)
        {
            List<IItem> ret = new List<IItem>();
            ret.Add(this);
            return ret;
        }

        public void Add(Context x, IItems items)
        {
            throw new Exception("Cannot add to a single item");
        }

        public void Clear(Context x)
        {
            throw new Exception("Cannot clear a single item");
        }

        public virtual bool Parse(String s)
        {
            return false;
        }

        public List<String> ClassIdsList(Context x)
        {
            List<String> ret = new List<String>();
            ret.Add(this.ClassId);
            return ret;
        }

        public List<String> ItemIdsList(Context x)
        {
            List<String> ret = new List<String>();
            ret.Add(this.Uid);
            return ret;
        }

        public String ItemIdFirstGet(Context x)
        {
            return this.Uid;
        }

        public IItem FirstGet(Context x)
        {
            return this;
        }

        public String Caption
        {
            get
            {
                return this.ToString();
            }
        }

        public int CountMax
        {
            get
            {
                return 1;
            }
        }

        public void GridFill(Context x, Display.IGridTarget target, GridColumnSource columnSource)
        {

            target.RowAdd(this, GridInfoGet(x, columnSource));
        }

        public String[] GridInfoGet(Context x, GridColumnSource columnSource)
        {
            String[] ary = new String[columnSource.DetailsGet(x).Count];
            int i = 0;
            foreach (GridColumnDetail d in columnSource.DetailsGet(x))
            {
                ary[i] = ContentRenderString(d.VarName);
                i++;
            }
            return ary;
        }

        public virtual String ContentRenderString(String contentId)
        {
            switch (contentId)
            {
                case "Uid":
                    return this.Uid;
                case "ToString":
                    return this.ToString();
                default:
                    Var value = VarGetByName(contentId);
                    if (value == null)
                        return "<null>";
                    else
                        return Convert.ToString(Tools.Data.NullFilterString(value.Value));
            }
        }

        public Var VarGetExact(String content_id)
        {
            try
            {
                return (Var)GetType().InvokeMember(content_id, BindingFlags.GetField | BindingFlags.GetProperty, null, this, null);
            }
            catch { return null; }
        }

        //public bool VarSetExact(Context x, String content_id, Object value)
        //{
        //    return VarSetExact(x, content_id, value);
        //}

        //what is this for?
        public void VarSetExact(Context x, String content_id, Object value)  //, bool changed
        {
            Var v = (Var)VarGetExact(content_id);
            if (v == null)
                throw new Exception("Value not found");
            v.Value = value;  //, changed);
        }

        public virtual Var VarGetByName(String name)
        {
            return (Var)VarGetExact(name + "Var");
        }

        //public List<Var> ContentsGetList()
        //{
        //    List<Item> ret = new List<Item>();
        //    MemberInfo[] members = GetType().FindMembers(MemberTypes.All, BindingFlags.Instance | BindingFlags.Public, new MemberFilter(FilterMembersByAttributeType), typeof(CoreVarAttribute));
        //    foreach (MemberInfo info in members)
        //    {
        //        ret.Add((Var)MemberItemGetExact(info.Name));
        //    }
        //    return ret;
        //}

        private static bool FilterMembersByAttributeType(MemberInfo info, object state)
        {
            Type desired_attribute_type = (Type)state;
            object[] attrs = info.GetCustomAttributes(desired_attribute_type, false);
            return (attrs.Length > 0);
        }

        public static void AttributesCache(Type t, AttributeCacheHandler handler)
        {
            //MethodInfo ac = t.GetMethod("AttributeCache", BindingFlags.Static | BindingFlags.Public);
            //if (ac == null)
            //    return;

            MemberInfo[] members = t.FindMembers(MemberTypes.All, BindingFlags.Instance | BindingFlags.Public, new MemberFilter(FilterMembersByAttributeType), typeof(CoreAttribute));
            foreach (MemberInfo info in members)
            {
                Object[] attrs = info.GetCustomAttributes(typeof(CoreAttribute), true);
                CoreAttribute attr = (CoreAttribute)attrs[0];
                handler(attr);
                //ac.Invoke(t, new object[] { attr });
            }
        }

        //public Var VarAdd(Var v)
        //{
        //    Vars.Add(v.TheVarAttribute.Name, v);
        //    return v;
        //}

        //this needs to be cached in a static collection in the base
        //2011_10_22 this is cached now (see methods above), so this should never be called
        //public CoreAttribute AttributeGet(String name)
        //{
        //    MemberInfo[] members = GetType().FindMembers(MemberTypes.All, BindingFlags.Instance | BindingFlags.Public, new MemberFilter(FilterMembersByAttributeType), typeof(CoreAttribute));
        //    foreach (MemberInfo info in members)
        //    {
        //        if (info.Name == name)
        //        {
        //            Object[] attrs = info.GetCustomAttributes(typeof(CoreAttribute), true);
        //            return (CoreAttribute)attrs[0];
        //        }
        //    }
        //    return null;
        //}

        ////attribute constructors can't take delegates, apparently.  why not?
        //public CoreActAttribute AttributeActGet(String name, ActHandler handler)
        //{
        //    CoreActAttribute a = (CoreActAttribute)AttributeGet(name);
        //    a.TheHandler = handler;
        //    return a;
        //}

        public List<VarVal> VarValsGet()
        {
            List<VarVal> ret = new List<VarVal>();
            foreach (Var v in VarsGet())
            {
                if (v is VarVal)
                    ret.Add((VarVal)v);
            }
            return ret;
        }

        List<Var> Vars;
        public List<Var> VarsGet()
        {
            if (Vars == null)
                Vars = VarsGetInitially();
            return Vars;
        }

        public virtual List<Var> VarsGetInitially()
        {
            return VarsGet(GetType());
        }

        public List<Var> VarsGet(Type t)
        {
            List<Var> ret = new List<Var>();
            MemberInfo[] members = t.FindMembers(MemberTypes.All, BindingFlags.Instance | BindingFlags.Public, new MemberFilter(FilterMembersByAttributeType), typeof(CoreVarAttribute));
            foreach (MemberInfo info in members)
            {
                ret.Add(this.VarGetExact(info.Name));
            }
            //ret.Sort();
            return ret;
        }

        ///////////////////////////////////////////////
        ////Member ATTRIBUTES get
        //public List<CoreMemberAttribute> MemberAttributesGet()
        //{
        //    return MemberAttributesGetByType(GetType());
        //}
        public List<CoreVarAttribute> VarAttributesGet()
        {
            return VarAttributesGet(GetType());
        }

        public static List<CoreVarAttribute> VarAttributesGet(Type t)
        {
            List<CoreVarAttribute> ret = new List<CoreVarAttribute>();
            MemberInfo[] members = t.FindMembers(MemberTypes.All, BindingFlags.Instance | BindingFlags.Public, new MemberFilter(FilterMembersByAttributeType), typeof(CoreVarAttribute));
            foreach (MemberInfo info in members)
            {
                Object[] attrs = info.GetCustomAttributes(typeof(CoreVarAttribute), true);
                ret.Add((CoreVarAttribute)attrs[0]);
            }
            ret.Sort();
            return ret;
        }

        public static List<CoreVarValAttribute> VarValAttributesGet(Type t)
        {
            List<CoreVarValAttribute> ret = new List<CoreVarValAttribute>();
            foreach (CoreVarAttribute v in VarAttributesGet(t))
            {
                if (v is CoreVarValAttribute)
                    ret.Add((CoreVarValAttribute)v);
            }
            return ret;
        }

        public virtual void Inserting(Context x)
        {
            if (InsertedIs)
                throw new Exception("Insert error: " + Uid);

            Uid = Tools.Strings.GetNewID();
            Updating(x);
        }

        public virtual void Inserted(Context x)
        {
            Changed = false;
        }

        public virtual void Updated(Context x)
        {
            Changed = false;
        }

        public virtual void Deleted(Context x)
        {
            Invalid = true;
        }

        public bool InsertedIs
        {
            get
            {
                return (Uid != "");
            }
        }

        //public virtual void Inserted(Context x, ChangeArgs args)
        //{
        //    //ValuesChangedSet(x, false);
        //    if (Change != null)
        //        Change(x, args, this);
        //}

        public virtual void Updating(Context x)
        {
            if (!InsertedIs)
                throw new Exception("Update error: Item not inserted");
        }

        //public virtual void Updated(Context x, ChangeArgs args)
        //{
        //    //ValuesChangedSet(x, false);
        //    if (Change != null)
        //        Change(x, args, this);
        //}

        public virtual void Deleting(Context x)
        {
            foreach (IVarRef r in VarRefsList)
            {
                if (r != null)
                    r.RefsRemoveAll(x);
            }
        }

        public List<IVarRef> VarRefsList  // virtual
        {
            get
            {
                List<IVarRef> ret = new List<IVarRef>();
                foreach (Var v in VarsGet())
                {
                    if (v is IVarRef)
                        ret.Add((IVarRef)v);
                }
                return ret;
            }
        }

        //public virtual void Deleted(Context x, ChangeArgs args)
        //{
        //    if (Change != null)
        //        Change(x, args, this);
        //}

        ////////////////////////////////////////////
        // Static Tools

        public static List<CoreVarAttribute> VarsCommonGet(Context x, IItems items)
        {
            if (items.ClassIdsList(x).Count == 1)
            {
                Item i = (Item)items.FirstGet(x);
                return i.VarAttributesGet();
            }

            Dictionary<String, CoreVarAttribute> ret = new Dictionary<String, CoreVarAttribute>();

            bool first = true;
            foreach (Item i in items.AllGet(x))
            {
                List<CoreVarAttribute> props = i.VarAttributesGet();
                if (first)
                {
                    first = false;
                    foreach (CoreVarAttribute a in props)
                    {
                        ret.Add(a.Name, a);
                    }
                }
                else
                {
                    List<String> remove = new List<string>();
                    foreach (KeyValuePair<String, CoreVarAttribute> k in ret)
                    {
                        bool has = false;
                        foreach (CoreVarAttribute a in props)
                        {
                            if (a.Name == k.Value.Name)
                            {
                                has = true;
                                continue;
                            }
                        }
                        if (!has)
                            remove.Add(k.Value.Name);
                    }

                    foreach (String r in remove)
                    {
                        ret.Remove(r);
                    }
                }
            }

            List<CoreVarAttribute> attr = new List<CoreVarAttribute>();
            foreach (KeyValuePair<String, CoreVarAttribute> k in ret)
            {
                attr.Add(k.Value);
            }

            return attr;
        }



        public List<Item> ListTo()
        {
            List<Item> ret = new List<Item>();
            ret.Add(this);
            return ret;
        }

        public Item Resolve(Context x)
        {
            return this;
        }

        public void AddNew(Context x, AddArgs args)
        {
            AddNewPossible(x, args);
            throw new Exception("Single items cannot be added to");
        }

        public bool AddNewPossible(Context x, AddArgs args)
        {
            args.LogAdd("Can't add");
            return false;
        }

        public bool IdIncludes(String id)
        {
            return (Uid == id);
        }

        public String ValGetString(String name)
        {
            return VarGetByName(name).ValueString;
        }

        public String TagString
        {
            get
            {
                return ClassId + ":" + Uid;
            }
        }

        //public event ChangeHandler Change;

        public virtual bool RemoveById(Context x, String id)
        {
            throw new NotImplementedException();
        }

        public IItem ByIdGet(Context x, String id)
        {
            if (id == Uid)
                return this;
            else
                return null;
        }

        public void ValSet(String prop, Object val)
        {
            Var v = VarGetByName(prop);
            if (v == null)
                throw new Exception(prop + " not found");
            if (v is VarVal && ((VarVal)v).TheValAttribute.Transactional)
                throw new Exception(prop + " can only be set within a transaction");
            v.Value = val;
        }

        public void ValSetFromString(String prop, String valString)
        {
            VarVal v = (VarVal)VarGetByName(prop);
            if (v == null)
                throw new Exception(prop + " not found");
            if (v.TheValAttribute.Transactional)
                throw new Exception(prop + " can only be set within a transaction");
            v.ValueSetFromString(valString);
        }

        public virtual Object ValGet(String prop)
        {
            Var v = VarGetByName(prop);
            if (v == null)
                throw new Exception(ClassId + "." + prop + " not found");
            return v.Value;
        }

        public bool AbsorbRow(Context x, DataRow r)
        {
            Uid = Tools.Data.NullFilterString(r[x.Data.UidField]);
            foreach (Var v in VarsGet())
            {
                try
                {
                    v.Absorb(x, r);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return true;
        }

        public bool Reordered { get { return false; } set { } }

        public override string ToString()
        {
            Var v = VarGetByName("Name");
            if (v == null)
                v = VarGetByName("name");
            if (v == null)
                return "";
            String ret = Tools.Data.NullFilterString(v.Value);
            if (ret == "")
                ret = "Item";

            return ret;
        }

        public virtual bool DeletePossible(Context x)
        {
            return true;
        }

        String m_TableName;
        public String TableName
        {
            get
            {
                if (m_TableName == null || m_TableName == "")
                    return ClassId;
                else
                    return m_TableName;
            }

            set
            {
                if (value != "" && value != null)
                    m_TableName = value;
                else
                    m_TableName = null;
            }
        }

        public virtual String InsertSql(Context x) { return x.TheData.InsertOneSql(x, this, TableName); }
        public virtual String UpdateSql(Context x) { return x.TheData.UpdateOneSql(x, this, TableName); }
        public virtual String DeleteSql(Context x) { return x.TheData.DeleteOneSql(x, this, TableName); }

        public bool Invalid = false;
        public void Invalidate(Context x)
        {
            x.TheLeader.ViewsClose(this);
            Uid = "invalid_" + Tools.Strings.GetNewID();
            Invalid = true;

        }

        public virtual bool Changed
        {
            set
            {
                foreach (Var v in VarsGet())
                {
                    v.Changed = value;
                }
            }

            get
            {
                foreach (Var v in VarsGet())
                {
                    if (v.Changed)
                        return true;
                }
                return false;
            }
        }

        public void DeleteFrom(Context x, DataConnection data)  //this isn't currently in the transaction system
        {
            Deleting(x);
            data.Execute(x.TheData.DeleteOneSql(x, this, ClassId));  //assumes that data is the same server type as x.TheData
            Deleted(x);
        }

        public void DeleteFrom(Context x, String table)  //this isn't currently in the transaction system
        {
            Deleting(x);
            x.Execute(x.TheData.DeleteOneSql(x, this, table));  //assumes that data is the same server type as x.TheData
            Deleted(x);
        }

        public void InsertTo(Context x, DataConnection data)  //this isn't currently in the transaction system
        {
            InsertTo(x, data, ClassId);
        }

        public void InsertTo(Context x, String table)  //this is in the transaction system
        {
            Inserting(x);
            InsertToAsIs(x, table);
            Inserted(x);
        }

        public void InsertToAsIs(Context x, String table)  //this is in the transaction system
        {
            x.TheDelta.Execute(x.TheData.InsertOneSql(x, this, table));
        }

        public void MoveTo(Context x, String table)  //this is in the transaction system
        {
            if (Uid == "")
                throw new Exception("Cannot move a non-inserted item");

            String originalId = Uid;
            Uid = "";
            Inserting(x);
            Uid = originalId;

            x.TheDelta.Execute(x.TheData.InsertOneSql(x, this, table));
            Inserted(x);
        }

        public void InsertTo(Context x, DataConnection data, String table)  //this isn't currently in the transaction system
        {
            if (x.TheDelta.TransactionMode)
                throw new Exception("The system is in transaction mode");

            Inserting(x);
            //kt 4-18-2016
            string st = data.GetServerType().ToString().ToLower();
            if (st == "sqlmy")
            {
                string executeSql = x.TheData.InsertOneSqlMy(x, this, table);
                data.Execute(executeSql);  //assumes that data is the same server type as x.TheData
            }
            else
            {
                data.Execute(x.TheData.InsertOneSql(x, this, table));  //assumes that data is the same server type as x.TheData
            }
            Inserted(x);
        }

        public void UpdateTo(Context x, String table)  //this is in the transaction system
        {
            Updating(x);
            x.TheDelta.Execute(x.TheData.UpdateOneSql(x, this, table));  //assumes that data is the same server type as x.TheData
            Updated(x);
        }

        public void UpdateTo(Context x, DataConnection data)
        {
            UpdateTo(x, data, ClassId);
        }

        public void UpdateTo(Context x, DataConnection data, String table)  //this isn't currently in the transaction system
        {
            if (x.TheDelta.TransactionMode)
                throw new Exception("The system is in transaction mode");

            Updating(x);
            string st = data.GetServerType().ToString().ToLower();
            //KT 4-18-2016 - Checking for mysql to properly handle syntax for different systems.
            if (st == "sqlmy")
            {
                string executeSql = x.TheData.UpdateOneSqlMy(x, this, table);
                data.Execute(executeSql);  //assumes that data is the same server type as x.TheData
                
            }
            else
            {
                data.Execute(x.TheData.UpdateOneSql(x, this, table));  //assumes that data is the same server type as x.TheData
            }
            Updated(x);
        }

        public void InsertWithExistingId(Context x)
        {
            x.Execute(x.TheData.InsertOneSql(x, this, ClassId));
            Inserted(x);
        }

        public void Insert(Context x)
        {
            x.Insert(this);
        }

        public void Update(Context x, bool inhibit_notify = false)
        {
            x.Update(this, inhibit_notify);
        }

        public void Delete(Context x)
        {
            x.Delete(this);
        }

        protected virtual void TransValueUpdate(Context x, String field, TransValueUpdateOp op, Double value)
        {
            if (!x.TheDelta.TransactionMode)
                throw new Exception("Must be in transaction mode");

            String sign = "+";
            if (op == TransValueUpdateOp.Subtract)
                sign = "-";

            x.Execute("update " + ClassId + " set " + field + " = isnull(" + field + ", 0) " + sign + " " + value.ToString() + " where " + x.Data.UidField + " = '" + Uid + "'");
        }
    }

    public enum TransValueUpdateOp
    {
        Add,
        Subtract,
    }

    public interface IItem : IItems  //, IChannel
    {
        String Uid { get; }
        String ClassId { get; }
        Item Resolve(Context x);
        void ValSet(String prop, Object val);
        Object ValGet(String prop);
        bool AbsorbRow(Context x, DataRow r);
        Var VarGetByName(String name);
        bool DeletePossible(Context x);

        void Inserting(Context x);
        void Updating(Context x);
        void Deleting(Context x);

        void Inserted(Context x);
        void Updated(Context x);
        void Deleted(Context x);

        String InsertSql(Context x);
        String UpdateSql(Context x);
        String DeleteSql(Context x);

        void Invalidate(Context x);
    }

    public delegate void AttributeCacheHandler(CoreAttribute attr);
}
