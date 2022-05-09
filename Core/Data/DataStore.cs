using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tools.Database;

namespace Core
{
    public class DataStore // : IWatcher
    {
        public Sys TheSys;
        public DataKey TheKey = null;
        public String UidField = "Uid";
        public virtual void Init(Context x, DataKey key)
        {
            TheKey = key;
        }


        

        //public virtual bool Inserting(Context x, IItems items)
        //{
        //    ChangeArgs args = new ChangeArgs(ChangeType.Add);
        //    foreach (IItem i in items.AllGet(x))
        //    {
        //        ((Item)i).Inserting(x, args);
        //    }
        //    DataCache.ChangeFire(x, args, items);

        //    if (!args.Success)
        //        return false;

        //    return Updating(x, items);
        //}

        //public virtual bool Insert(Context x, IItems items)
        //{
        //    return true;
        //}

        //public virtual bool Inserted(Context x, IItems items)
        //{
        //    ChangeArgs args = new ChangeArgs(ChangeType.Add);
        //    foreach (IItem i in items.AllGet(x))
        //    {
        //        ((Item)i).Inserted(x, args);
        //    }
        //    DataCache.ChangeFire(x, args, items);
        //    return args.Success;
        //}

        //public virtual bool Updating(Context x, IItems items)
        //{
        //    ChangeArgs args = new ChangeArgs(ChangeType.Update);
        //    foreach (IItem i in items.AllGet(x))
        //    {
        //        ((Item)i).Updating(x, args);
        //    }
        //    DataCache.ChangeFire(x, args, items);
        //    return args.Success;
        //}

        //public virtual bool Update(Context x, IItems items)
        //{
        //    return true;
        //}

        //public virtual bool Updated(Context x, IItems items)
        //{
        //    ChangeArgs args = new ChangeArgs(ChangeType.Update);
        //    foreach (IItem i in items.AllGet(x))
        //    {
        //        ((Item)i).Updated(x, args);
        //    }
        //    DataCache.ChangeFire(x, args, items);
        //    return args.Success;
        //}

        //public virtual bool Deleting(Context x, IItems items)
        //{
        //    ChangeArgs args = new ChangeArgs(ChangeType.Remove);
        //    foreach (IItem i in items.AllGet(x))
        //    {
        //        ((Item)i).Deleting(x, args);
        //    }
        //    DataCache.ChangeFire(x, args, items);
        //    return args.Success;
        //}

        //public virtual bool Delete(Context x, IItems items)
        //{
        //    return true;
        //}

        //public virtual bool Deleted(Context x, IItems items)
        //{
        //    ChangeArgs args = new ChangeArgs(ChangeType.Remove);
        //    foreach (IItem i in items.AllGet(x))
        //    {
        //        ((Item)i).Deleted(x, args);
        //    }
        //    DataCache.ChangeFire(x, args, items);
        //    return args.Success;
        //}

        //public virtual void InsertItems(Context x, IItems items)
        //{

        //}

        //public virtual void UpdateItems(Context x, IItems items)
        //{

        //}

        //public virtual void DeleteItems(Context x, IItems items)
        //{

        //}

        //public void Insert(Context x, IChannel c)
        //{
        //    InsertItems(x, (IItems)c);
        //}

        //public void Update(Context x, IChannel c)
        //{
        //    UpdateItems(x, (IItems)c);
        //}

        //public void Delete(Context x, IChannel c)
        //{
        //    DeleteItems(x, (IItems)c);
        //}

        //public virtual void Change(Context x, List<IChannel> insert, List<IChannel> update, List<IChannel> delete)
        //{
        //    foreach (IChannel c in insert)
        //    {
        //        Insert(x, (IItem)c);
        //    }

        //    foreach (IChannel c in update)
        //    {
        //        Update(x, (IItem)c);
        //    }

        //    foreach (IChannel c in delete)
        //    {
        //        Delete(x, (IItem)c);
        //    }
        //}

        public DataTable Select(Context x, Query q)
        {
            return Select(x, q, null);
        }

        public virtual DataTable Select(Context x, Query q, IItems items)
        {
            return null;
        }

        public DataRow SelectRow(Context x, Query q, IItems items)
        {
            DataTable d = Select(x, q, items);
            if (!Tools.Data.DataTableExists(d))
                return null;
            return d.Rows[0];
        }

        public virtual DataTable Select(String sql)
        {
            return null;
        }

        public virtual String Filter(String term)
        {
            throw new NotImplementedException();
        }

        public virtual ItemsInstance SelectInstances(Context x, QueryClass q)
        {
            return SelectInstances(x, q, null);
        }

        public virtual ItemsInstance SelectInstances(Context x, QueryClass q, IItems items)
        {
            //CoreClassHandle h = ((Sys)x.TheSys).CoreClassGet(q.ClassId);
            //if (h == null)
            //{
            //    x.TheLeader.Error("Class " + q.ClassId + " was not found");
            //    return null;
            //}

            ItemsInstance ret = new ItemsInstance();
            if (q == null)
                return ret;

            DataTable d = Select(x, q, items);
            if (!Tools.Data.DataTableExists(d))
                return ret;
            foreach (DataRow r in d.Rows)
            {
                ret.AddSingle(Create(x, q.ClassId, r));  //, h.VarsGet()
            }
            return ret;
        }

        public virtual ItemsInstance SelectAllClass(Context x, String classId)
        {
            //CoreClassHandle h = ((Sys)x.TheSys).CoreClassGet(classId);
            //if (h == null)
            //{
            //    x.TheLeader.Error("Class " + classId + " was not found");
            //    return null;
            //}

            DataTable d = TableGet(classId);
            if (d == null)
                throw new Exception("Table " + classId + " was not found");

            //x.TheDelta.Apply(x);
            
            //String id = x.BeginTran();

            ItemsInstance ret = new ItemsInstance();
            foreach (DataRow r in d.Rows)
            {
                ret.AddSingle(Create(x, classId, r));  //, attrs
            }

            //x.IgnoreTran();

            return ret;
        }

        public virtual IItem Create(Context x, String classId, DataRow r)  //, List<CoreVarAttribute> attrs
        {
            if (r == null)
                return null;

            //happens in absorbrow now
            //String uid = Tools.Data.NullFilterString(r[this.UidField]);

            //if we're going to support alternate classes, this is where it could be
            //2012_03_17 this was an interesting idea.  maybe this is the best way, but it was only used for the spots and they're not Items anymore
            //String otherClassId = "";

            //try
            //{
            //    otherClassId = Tools.Data.NullFilterString(r["alternate_class_id"]);
            //}
            //catch { }

            IItem i = null;
            //if( otherClassId == "" )
                i = (IItem)x.TheSys.ItemCreate(classId);  //, new ItemArgs(x, uid)
            //else
            //    i = (IItem)x.TheSys.ItemCreate(otherClassId, new ItemArgs(x, uid));

            
            i.AbsorbRow(x, r);
            return i;
        }

        public virtual DataTable TableGet(String table)
        {
            throw new NotImplementedException("TableGet not implemented");
        }

        public virtual int Count(Context x, Query q)
        {
            throw new NotImplementedException("Count not implemented");
        }

        public virtual int Count(Context x, Query q, IItems items)
        {
            throw new NotImplementedException("Count not implemented");
        }

        public virtual String FieldConvert(String s)
        {
            return s;
        }

        public virtual bool TableClear(String table)
        {
            throw new NotImplementedException("TableClear not implemented");
        }

        public virtual List<String> DatabasesList()
        {
            throw new NotImplementedException("DatabasesList not implemented");
        }

        public virtual void DatabaseDelete(String database)
        {
            throw new NotImplementedException("DatabaseDelete not implemented");
        }
    }

    public class ChangeArgs
    {
        List<Item> InsertedItems;
        List<Item> UpdatedItems;
        List<Item> DeletedItems;

        public ChangeArgs()
        {

        }

        public ChangeArgs(Item inserted, Item updated, Item deleted)
        {
            Add(inserted, updated, deleted);
        }

        public void Add(ChangeArgs args)
        {
            if (args.InsertedItems != null)
            {
                if (InsertedItems == null)
                    InsertedItems = new List<Item>();
                InsertedItems.AddRange(args.InsertedItems);
            }

            if (args.UpdatedItems != null)
            {
                if (UpdatedItems == null)
                    UpdatedItems = new List<Item>();
                UpdatedItems.AddRange(args.UpdatedItems);
            }

            if (args.DeletedItems != null)
            {
                if (DeletedItems == null)
                    DeletedItems = new List<Item>();
                DeletedItems.AddRange(args.DeletedItems);
            }
        }

        public List<Item> Inserted()
        {
            if (InsertedItems == null)
                return new List<Item>();
            else
                return InsertedItems;
        }

        public List<Item> Updated()
        {
            if (UpdatedItems == null)
                return new List<Item>();
            else
                return UpdatedItems;
        }

        public List<Item> Deleted()
        {
            if (DeletedItems == null)
                return new List<Item>();
            else
                return DeletedItems;
        }

        public void Add(Item inserted, Item updated, Item deleted)
        {
            if (inserted != null)
            {
                if( InsertedItems == null )
                    InsertedItems = new List<Item>();
                InsertedItems.Add(inserted);
            }

            if (updated != null)
            {
                if( UpdatedItems == null )
                    UpdatedItems = new List<Item>();
                UpdatedItems.Add(updated);
            }

            if (deleted != null)
            {
                if( DeletedItems == null )
                    DeletedItems = new List<Item>();
                DeletedItems.Add(deleted);
            }
        }

        public void AddInserted(Item i)
        {
            Add(i, null, null);
        }

        public void AddUpdated(Item i)
        {
            Add(null, i, null);
        }

        public void AddDeleted(Item i)
        {
            Add(null, null, i);
        }

        public List<String> Classes
        {
            get
            {
                List<String> ret = new List<string>();

                if (InsertedItems != null)
                {
                    foreach (Item i in InsertedItems)
                    {
                        if (!ret.Contains(i.ClassId))
                            ret.Add(i.ClassId);
                    }
                }

                if (UpdatedItems != null)
                {
                    foreach (Item i in UpdatedItems)
                    {
                        if (!ret.Contains(i.ClassId))
                            ret.Add(i.ClassId);
                    }
                }

                if (DeletedItems != null)
                {
                    foreach (Item i in DeletedItems)
                    {
                        if (!ret.Contains(i.ClassId))
                            ret.Add(i.ClassId);
                    }
                }

                return ret;
            }
        }

        public bool Id(String uid)
        {
            if (IdInserted(uid))
                return true;

            if (IdUpdated(uid))
                return true;

            if (IdDeleted(uid))
                return true;

            return false;
        }

        public bool IdInserted(String uid)
        {
            return Id(uid, InsertedItems);
        }

        public bool IdUpdated(String uid)
        {
            return Id(uid, UpdatedItems);
        }

        public bool IdDeleted(String uid)
        {
            return Id(uid, DeletedItems);
        }

        bool Id(String uid, List<Item> items)
        {
            if (items == null)
                return false;

            foreach (Item i in items)
            {
                if (i.Uid == uid)
                    return true;
            }
            return false;
        }
    }

    //public class ChangeArgs
    //{
    //    public bool Allow = true;
    //    public bool Success = true;
    //    public StringBuilder Log = new StringBuilder();
    //    public bool RequestIs = false;
    //    public ChangeType TheType;
    //    public bool InhibitNotify = false;
    //    public bool SuppressErrorMessage = false;
    //    public bool Silent = false;
    //    public bool UpdateDetails = true;  //this is for things like orders updating order lines; true by default, but it can be turned off
    //    //public bool PreserveId = false;

    //    public ChangeArgs()
    //    {

    //    }

    //    public ChangeArgs(ChangeType type)
    //    {
    //        TheType = type;
    //    }
    //}

    //public delegate void ChangeHandler(Context x, ChangeArgs args, IItems items);

    //public enum ChangeType
    //{
    //    Update = 0,
    //    Add = 1,
    //    Remove = 2,
    //    Refresh = 3,
    //}
}
