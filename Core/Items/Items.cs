using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Core.Display;

namespace Core
{
    public interface IItems
    {
        List<IItem> AllGet(Context x);
        IItem FirstGet(Context x);
        int CountGet(Context x);
        List<String> ClassIdsList(Context x);
        bool IdIncludes(String id);
        String ItemIdFirstGet(Context x);
        List<String> ItemIdsList(Context x);
        String Caption { get; }
        IItem ByIdGet(Context x, String id);
        bool RemoveById(Context x, String id);

        int CountMax { get; }
        void Add(Context x, IItems items);
        void AddNew(Context x, AddArgs args);
        bool AddNewPossible(Context x, AddArgs args);
        void Clear(Context x);
        void GridFill(Context x, Display.IGridTarget target, Display.GridColumnSource columnSource);
        //event ChangeHandler Change;
        //bool Reordered { get; set; }
    }

    public class ItemsInstance : IItems
    {
        //public event ChangeHandler Change;

        protected bool m_Reordered = false;
        public bool Reordered { set { m_Reordered = value; } get { return m_Reordered; } }

        //protected void ChangeFire(Context x, ChangeArgs args, IItems items)
        //{
        //    if (Change != null)
        //        Change(x, args, items);
        //}

        public ItemsInstance()
        {

        }

        public ItemsInstance(Context x, List<IItem> items)
        {
            foreach (Item i in items)
            {
                Add(x, i);
            }
        }

        public ItemsInstance(Context x, IItems items)
        {
            Add(x, items);
        }

        protected Dictionary<String, IItem> m_AllById = new Dictionary<String, IItem>();
        public List<IItem> All
        {
            get
            {
                List<IItem> ret = new List<IItem>();
                foreach (KeyValuePair<String, IItem> k in m_AllById)
                {
                    ret.Add(k.Value);
                }
                return ret;
            }
        }

        public List<IItem> AllGet(Context x)
        {
            List<IItem> ret = new List<IItem>();
            foreach (IItem i in All)
            {
                ret.Add(i);
            }
            return ret;
        }

        public List<IItem> AllGetItem()
        {
            List<IItem> ret = new List<IItem>();
            foreach (KeyValuePair<String, IItem> k in m_AllById)
            {
                ret.Add(k.Value);
            }
            return ret;
        }

        public IItem ByIdGet(Context x, String id)
        {
            if (m_AllById.ContainsKey(id))
                return m_AllById[id];
            else
                return null;
        }

        public bool ContainsId(Context x, String id)
        {
            return m_AllById.ContainsKey(id);
        }

        public virtual void Add(Context x, IItems items)
        {
            foreach (IItem i in items.AllGet(x))
            {
                if (!Tools.Strings.StrExt(i.Uid))
                    throw new Exception("Missing Uid in RefAdd");

                if (!m_AllById.ContainsKey(i.Uid))
                    m_AllById.Add(i.Uid, i);
                //if (m_AllById.ContainsKey(i.Uid))
                //{
                //    //should this be an exception?
                //    x.TheLeader.Tell("Duplicate key warning");
                //}
                //else
                //    m_AllById.Add(i.Uid, i);
            }
        }

        public bool MoveAfter(IItem move, IItem after)
        {
            List<IItem> items = All;
            m_AllById.Clear();
            bool found = false;
            bool moved = false;
            foreach (IItem i in items)
            {
                if (i == move)
                {
                    //skip it
                    found = true;
                }
                else if (i == after)
                {
                    moved = true;
                    m_AllById.Add(after.Uid, after);
                    m_AllById.Add(move.Uid, move);
                    Reordered = true;
                }
                else
                {
                    m_AllById.Add(i.Uid, i);
                }
            }

            if (found && !moved)
                m_AllById.Add(move.Uid, move);

            return moved;
        }

        //this is not watched
        public virtual void AddSingle(IItem i)
        {
            m_AllById.Add(i.Uid, i);
        }

        public int Count
        {
            get
            {
                return m_AllById.Count;
            }
        }

        public int CountGet(Context x)
        {
            return Count;
        }

        public IItem this[String key]
        {
            get
            {
                return m_AllById[key];
            }
        }

        public IItem this[int index]
        {
            get
            {
                int x = 0;
                foreach (KeyValuePair<String, IItem> k in m_AllById)
                {
                    if (x == index)
                        return k.Value;
                    x++;
                }
                return null;
            }
        }

        public void Clear(Context x)
        {
            Remove(x, this);
            m_AllById.Clear();
        }

        public virtual void Remove(Context x, IItems items)
        {
            foreach (IItem i in items.AllGet(x))
            {
                m_AllById.Remove(i.Uid);
            }
        }

        public bool RemoveById(Context x, String id)
        {
            if( !m_AllById.ContainsKey(id) )
                return false;

            m_AllById.Remove(id);

            return true;
        }

        public void GridFill(Context x, Display.IGridTarget target, Display.GridColumnSource columnSource)
        {
            foreach (KeyValuePair<String, IItem> k in m_AllById)
            {
                k.Value.GridFill(x, target, columnSource);
            }
        }

        public static ItemsInstance ToItems(Context x, ICollection<Item> items)
        {
            ItemsInstance ret = new ItemsInstance();
            foreach (IItem i in items)
            {
                ret.Add(x, i);
            }
            return ret;
        }

        public List<String> ClassIdsList(Context x)
        {
            List<String> ret = new List<String>();
            foreach (KeyValuePair<String, IItem> k in m_AllById)
            {
                if (!ret.Contains(k.Value.ClassId))
                    ret.Add(k.Value.ClassId);
            }
            return ret;
        }

        public List<String> ItemIdsList(Context x)
        {
            List<String> ret = new List<String>();
            foreach (KeyValuePair<String, IItem> k in m_AllById)
            {
                ret.Add(k.Value.Uid);
            }
            return ret;
        }

        public String ItemIdFirstGet(Context x)
        {
            List<String> ret = new List<String>();
            foreach (KeyValuePair<String, IItem> k in m_AllById)
            {
                return k.Value.Uid;
            }
            return "";
        }

        public IItem FirstGet(Context x)  //just here with the context to meet the interface requirement
        {
            return First;
        }

        public IItem First
        {
            get
            {
                if (m_AllById.Count == 0)
                    return null;
                else
                {
                    foreach (KeyValuePair<String, IItem> k in m_AllById)
                    {
                        return k.Value;
                    }

                    return null;
                }
            }
        }

        public String Caption
        {
            get
            {
                switch (m_AllById.Count)
                {
                    case 1:
                        return IndexByGet(0).ToString();
                    case 2:
                        return IndexByGet(0).ToString() + ", " + IndexByGet(1).ToString();
                    default:
                        return Tools.Strings.PluralizePhrase("Item", m_AllById.Count);
                }
            }
        }

        //there's got to be a better way.  maybe keeping a list by index in addition to the dictionary?
        public IItem IndexByGet(int index)
        {
            int x = 0;
            foreach (KeyValuePair<String, IItem> k in m_AllById)
            {
                if (x == index)
                    return k.Value;
                x++;
            }
            return null;
        }

        public int CountMax
        {
            get
            {
                return 0;
            }
        }

        //all of this adding stuff should be in the varref, not the itemsinstance
        public event AddHandler AddingNew;
        public void AddNew(Context x, AddArgs args)
        {
            if (AddingNew != null)
                AddingNew(x, args);

            AddNewPossible(x, args); //to populate the args
            throw new NotImplementedException();

            //this needs to be added, with a dialog to choose the class, etc
        }

        public event AddHandler AddingNewPossible;
        public bool AddNewPossible(Context x, AddArgs args)
        {
            if (AddingNewPossible != null)
                return AddingNewPossible(x, args);

            args.LogAdd("Can't add to ItemsInstance");
            return false;
        }

        public bool IdIncludes(String id)
        {
            return m_AllById.ContainsKey(id);
        }
    }

    //public class ItemsInstanceWatched : ItemsInstance
    //{
    //    ~ItemsInstanceWatched()
    //    {
    //        Detach(All);
    //    }

    //    public override bool Add(Context x, IItems items)
    //    {
    //        if (!base.Add(x, items))
    //            return false;

    //        List<IItem> l = new List<IItem>();
    //        foreach (IItem i in items.AllGet(x))
    //        {
    //            l.Add((IItem)i);
    //        }

    //        Attach(l);
    //        return true;
    //    }

    //    public override void Remove(Context x, IItems items)
    //    {
    //        base.Remove(x, items);
    //        List<IItem> l = new List<IItem>();
    //        foreach (IItem i in items.AllGet(x))
    //        {
    //            l.Add((IItem)i);
    //        }

    //        Detach(l);
    //    }

    //    void Attach(List<IItem> items)
    //    {
    //        foreach (IItem i in items)
    //        {
    //            i.Change += new ChangeHandler(i_Change);
    //        }
    //    }

    //    void Detach(List<IItem> items)
    //    {
    //        foreach (IItem i in items)
    //        {
    //            i.Change -= new ChangeHandler(i_Change);
    //        }
    //    }


    //    void i_Change(Context x, ChangeArgs args, IItems items)
    //    {
    //        if (args.RequestIs)
    //            return;

    //        //if (args.TheType == ChangeType.Remove)
    //        //{
    //            ChangeFire(x, new ChangeArgs(args.TheType), items);
    //        //}
    //    }

    //    public override void AddSingle(IItem i)
    //    {
    //        //throw new NotImplementedException("AddSingle can't be called on ItemsInstanceWatched");
    //        base.AddSingle(i);
    //        List<IItem> items = new List<IItem>();
    //        items.Add(i);
    //        Attach(items);
    //    }

    //    public void ClearDirect()
    //    {
    //        m_AllById.Clear();
    //    }

    //    public bool RemoveById(Context x, String id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IItem ByIdGet(Context x, String id)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}


    public class ItemsQuery : IItems
    {
        public Query TheQuery;
        //public event ChangeHandler Change;

        public bool Reordered { get { return false; } set { } }

        //protected void ChangeFire(Context x, ChangeArgs args, IItems items)
        //{
        //    if (Change != null)
        //        Change(x, args, items);
        //}

        public ItemsQuery(Query q)
        {
            TheQuery = q;
            //DataCache.Change += new ChangeHandler(DataCache_Change);
        }

        ~ItemsQuery()
        {
            //DataCache.Change -= new ChangeHandler(DataCache_Change);
        }

        //protected virtual void DataCache_Change(Context x, ChangeArgs args, IItems items)
        //{
        //    //ideally, this would use the logic in TheQuery to see if the item matches, and pass it on if it does
        //}

        public int CountGet(Context x)
        {
            return x.TheData.Count(x, TheQuery, null);
        }

        public virtual List<IItem> AllGet(Context x)
        {
            throw new NotImplementedException("Gets can't be called on ItemsQuery; no class");
        }

        public virtual void Add(Context x, IItems items)
        {
            throw new Exception("Items cannot be added to a query list");
        }

        public void Clear(Context x)
        {
            throw new Exception("Query lists cannot be cleared");
        }

        public virtual List<String> ClassIdsList(Context x)
        {
            return new List<string>();
        }

        public IItem FirstGet(Context x)
        {
            throw new NotImplementedException("Gets can't be called on ItemsQuery; no class");
        }

        public String Caption
        {
            get
            {
                return TheQuery.Caption;
            }
        }

        public void GridFill(Context x, Display.IGridTarget target, Display.GridColumnSource columnSource)
        {
            try
            {
                DataTable data = x.TheData.Select(x, TheQuery, null);  //this is where the columns can come in
                if (!Tools.Data.DataTableExists(data))
                    return;

                foreach (DataRow r in data.Rows)
                {
                    String[] ary = new String[columnSource.DetailsGet(x).Count];
                    int i = 0;
                    foreach (GridColumnDetail d in columnSource.DetailsGet(x))
                    {
                        String field = x.TheData.FieldConvert(d.VarName);
                        ary[i] = Convert.ToString(Tools.Data.NullFilterString(r[field]));
                        i++;
                    }
                    target.RowAdd(TagCreate(r), ary);
                }
            }
            catch (Exception ex)
            {
                x.TheLeader.Error(ex);
            }
        }

        protected virtual ItemTag TagCreate(DataRow r)
        {
            return ItemTag.NullTag;
        }

        public int CountMax
        {
            get
            {
                return 0;
            }
        }

        public virtual void AddNew(Context x, AddArgs args)
        {
            AddNewPossible(x, args);
            throw new NotImplementedException();
        }

        public virtual bool AddNewPossible(Context x, AddArgs args)
        {
            args.LogAdd("Can't add");
            return false;
        }

        public bool IdIncludes(String id)
        {
            return false;  //this needs to be implemented
        }

        public List<String> ItemIdsList(Context x)
        {
            throw new NotImplementedException("Ni");
        }

        public String ItemIdFirstGet(Context x)
        {
            throw new NotImplementedException("Ni");
        }

        public bool RemoveById(Context x, String id)
        {
            throw new NotImplementedException();
        }

        public IItem ByIdGet(Context x, String id)
        {
            throw new NotImplementedException();
        }
    }

    public class ItemsQueryClass : ItemsQuery
    {
        public String ClassId;

        public ItemsQueryClass(String classId)
            : this(new QueryClass(classId), classId)
        {

        }

        public ItemsQueryClass(Query q, String classId) : base(q)
        {
            ClassId = classId;
        }

        protected override ItemTag TagCreate(DataRow r)
        {
            return new ItemTag(ClassId, (String)r["unique_id"], ClassId);
        }

        //protected override void DataCache_Change(Context x, ChangeArgs args, IItems items)
        //{
        //    base.DataCache_Change(x, args, items);
        //    if (items.ClassIdsList(x).Contains(ClassId))
        //    {
        //        //currently there isn't a solid way to compare the added items with the criteria to see if it should actually go in the list
        //        if (args.TheType == ChangeType.Add)
        //        {
        //            ChangeFire(x, new ChangeArgs(ChangeType.Refresh), null);
        //        }
        //        else
        //            ChangeFire(x, args, items);
        //    }
        //}

        public override List<string> ClassIdsList(Context x)
        {
            List<String> ret = new List<string>();
            ret.Add(ClassId);
            return ret;
        }

        public override bool AddNewPossible(Context x, AddArgs args)
        {
            return true;
        }

        public override void AddNew(Context x, AddArgs args)
        {
            List<IItem> added = new List<IItem>();
            for (int a = 0; a < args.AddCount; a++)
            {
                added.Add(AddNewOne(x));
            }
            args.Added = added;
        }

        public Item AddNewOne(Context x)
        {
            Item i = (Item)x.TheSys.ItemCreate(ClassId);  //, new ItemArgs(x)
            x.TheDelta.Insert(x, i);
            return i;
        }

        //public bool RemoveById(Context x, String id)
        //{
        //    throw new NotImplementedException();
        //}

        //public IItem ByIdGet(Context x, String id)
        //{
        //    throw new NotImplementedException();
        //}

    }

    //public class ItemsCriteriaLink : ItemsCriteria
    //{
    //    public String LinkId = "";
    //    public String LinkType = "";
    //    public ItemsCriteriaLink(String link_id, String link_type)
    //    {
    //        LinkId = link_id;
    //        LinkType = link_type;
    //    }
    //}

    public class ItemsTags : IItems
    {
        //public event ChangeHandler Change;

        public bool Reordered { get { return false; } set { } }

        protected List<ItemTag> Tags = new List<ItemTag>();
        public int CountGet(Context x)
        {
            return 0;
        }

        public List<IItem> AllGet(Context x)
        {
            List<IItem> ret = new List<IItem>();
            foreach (ItemTag t in Tags)
            {
                ret.Add(x.TheSys.ItemGetByTag(x, t));
                //ret.Add(x.TheSystem.ItemGetByTag(x, t));
            }
            return ret;
        }

        public void Add(Context x, IItems items)
        {
            foreach (Item i in items.AllGet(x))
            {
                Tags.Add(new ItemTag(i));
            }
        }

        public void Clear(Context x)
        {

        }

        public List<String> ClassIdsList(Context x)
        {
            List<String> ret = new List<String>();
            foreach (ItemTag t in Tags)
            {
                if (!ret.Contains(t.ClassId))
                    ret.Add(t.ClassId);
            }
            return ret;
        }

        public List<String> ItemIdsList(Context x)
        {
            List<String> ret = new List<String>();
            foreach (ItemTag t in Tags)
            {                
                ret.Add(t.Uid);
            }
            return ret;
        }

        public String ItemIdFirstGet(Context x)
        {
            foreach (ItemTag t in Tags)
            {
                return t.Uid;
            }
            return null;
        }

        public IItem FirstGet(Context x)
        {
            foreach (ItemTag t in Tags)
            {
                return x.TheSys.ItemGetByTag(x, t);
            }
            return null;
        }

        public String Caption
        {
            get
            {
                return Tools.Strings.PluralizePhrase("Item", Tags.Count);
            }
        }

        public void GridFill(Context x, Display.IGridTarget target, Display.GridColumnSource columnSource)
        {
            foreach (ItemTag t in Tags)
            {
                t.GridFill(x, target, columnSource);
            }
        }

        public int CountMax
        {
            get
            {
                return 0;
            }
        }

        public void AddNew(Context x, AddArgs args)
        {
            AddNewPossible(x, args);
            throw new NotImplementedException();
        }

        public bool AddNewPossible(Context x, AddArgs args)
        {
            args.LogAdd("Can't add");
            return false;
        }

        public bool IdIncludes(String id)
        {
            foreach (ItemTag t in Tags)
            {
                if (t.Uid == id)
                    return true;
            }
            return false;
        }

        public bool RemoveById(Context x, String id)
        {
            throw new NotImplementedException();
        }

        public IItem ByIdGet(Context x, String id)
        {
            throw new NotImplementedException();
        }
    }

    public class ItemTag : IItem
    {
        //public event ChangeHandler Change;

        public bool Valid
        {
            get
            {
                if (!Tools.Strings.StrExt(Uid))
                    return false;

                if (!Tools.Strings.StrExt(ClassId))
                    return false;

                return true;
            }
        }

        String m_ClassId = "";
        public String ClassId
        {
            get
            {
                return m_ClassId;
            }

            set
            {
                m_ClassId = value;
            }
        }
        
        String m_Uid = "";
        public String Uid
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

        String m_ItemTarget = "";
        public String ItemTarget
        {
            get
            {
                if (!Tools.Strings.StrExt(m_ItemTarget))
                    m_ItemTarget = ClassId;
                return m_ItemTarget;
            }

            set
            {
                m_ItemTarget = value;
            }
        }

        public ItemTag(String classid, String uid) : this(classid, uid, classid)
        {

        }

        public ItemTag(String classid, String uid, String item_target)
        {
            ClassId = classid;
            Uid = uid;
            ItemTarget = item_target;
        }

        public ItemTag(IItem item)
        {
            ClassId = item.ClassId;
            Uid = item.Uid;
        }

        public String Caption
        {
            get
            {
                return ToString();
            }
        }

        public List<String> ClassIdsList(Context x)
        {
            List<String> ret = new List<string>();
            ret.Add(ClassId);
            return ret;
        }

        public List<String> ItemIdsList(Context x)
        {
            List<String> ret = new List<string>();
            ret.Add(Uid);
            return ret;
        }

        public String ItemIdFirstGet(Context x)
        {
            return Uid;
        }

        public void Clear(Context x)
        {

        }

        public void Add(Context x, IItems items)
        {
            throw new NotImplementedException();
        }

        public int CountGet(Context x)
        {
            return 1;
        }

        public IItem FirstGet(Context x)
        {
            if (x.TheSys == null)
                return null;
            return x.TheSys.ItemGetByTag(x, this);
        }

        public List<IItem> AllGet(Context x)
        {
            List<IItem> ret = new List<IItem>();
            ret.Add(x.TheSys.ItemGetByTag(x, this));
            return ret;
        }

        public void GridFill(Context x, Display.IGridTarget target, Display.GridColumnSource columnSource)
        {
            IItem i = x.TheSys.ItemGetByTag(x, this);
            if (i == null)
                target.RowAdd(null, columnSource.NullRow);
            else
                i.GridFill(x, target, columnSource);
        }

        //public ItemsContents ContentsGet(Context x)
        //{
        //    IItem i = x.TheSys.ItemGetByTag(x, this);
        //    if (i == null)
        //        return new ItemsContents();
        //    else
        //        return i.ContentsGet(x);
        //}

        public int CountMax
        {
            get
            {
                return 1;
            }
        }

        public static ItemTag m_NullTag = new ItemTag("not_a_class", "not_an_id", "not_a_class");
        public static ItemTag NullTag
        {
            get
            {
                return m_NullTag;
            }
        }

        public static ItemTag FromTagString(String tag)
        {
            String class_name = Tools.Strings.ParseDelimit(tag, ":", 1);
            String id = Tools.Strings.ParseDelimit(tag, ":", 2);
            return new ItemTag(class_name, id, class_name);
        }

        public Item Resolve(Context x)
        {
            return (Item)x.TheSys.ItemGetByTag(x, this);
        }

        public void AddNew(Context x, AddArgs args)
        {
            AddNewPossible(x, args);
            throw new NotImplementedException();
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

        public bool RemoveById(Context x, String id)
        {
            throw new NotImplementedException();
        }

        public IItem ByIdGet(Context x, String id)
        {
            throw new NotImplementedException();
        }

        public void ValSet(String prop, Object val)
        {
            throw new NotImplementedException();
        }

        public Object ValGet(String prop)
        {
            throw new NotImplementedException();
        }

        public bool AbsorbRow(Context x, DataRow r)
        {
            throw new NotImplementedException();
        }

        public Var VarGetByName(String name)
        {
            throw new NotImplementedException();
        }

        public void ValuesChangedSet(Context x, bool value)
        {
            throw new NotImplementedException();
        }

        public String Path
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void ValuesChangedSetDirect(bool value)
        {
            throw new NotImplementedException();
        }

        public bool Reordered { get { return false; } set { } }

        public void Inserting(Context x) { }
        public void Updating(Context x) { }
        public void Deleting(Context x) { }

        //public List<IWatcher> WatchersList { get { return new List<IWatcher>(); } }
        //public void WatcherAdd(IWatcher w) {}
        //public void WatcherRemove(IWatcher w) {}
        public bool InsertedIs { get { return false; } }
        public bool DeletePossible(Context x) { return false; }

        public void Inserted(Context x)
        {
        }

        public void Updated(Context x)
        {
        }

        public void Deleted(Context x)
        {
        }

        public void Invalidate(Context x) { Uid = "invalid_" + Tools.Strings.GetNewID(); }

        public String InsertSql(Context x)
        {
            throw new NotImplementedException();
        }

        public String UpdateSql(Context x)
        {
            throw new NotImplementedException();
        }

        public String DeleteSql(Context x)
        {
            throw new NotImplementedException();
        }
    }

    public class AddArgs : PossibleArgs
    {
        public int AddCount = 1;
        public List<IItem> Added;
        public bool Handled = false;

        public AddArgs() : base(-1)
        {

        }
    }

    public delegate bool AddHandler(Context x, AddArgs args);
}
