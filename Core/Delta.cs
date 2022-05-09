using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Delta
    {
        public Context Context;

        public Delta(Context x)
        {
            Context = x;
        }

        public void Execute(String sql)
        {
            if (tranMode)
                tranTasks.Add(new TranTaskSql(sql));
            else
                ExecuteNow(sql);
        }

        long ExecuteNow(String sql)
        {
            long affectedRows = 0;
            Context.TheData.TheConnection.Execute(sql, ref affectedRows);
            return affectedRows;
        }

        public void Insert(Context x, IItems items)
        {
            foreach (IItem i in items.AllGet(x))
            {
                Insert(i);
            }
        }
        public void Insert(IItem item)
        {
            if (tranMode)
            {
                lock (tranTasks)
                {
                    item.Inserting(Context);
                    tranTasks.Add(new TranTaskItem(Context, item, ItemTransType.Insert));
                }
            }
            else
            {
                item.Inserting(Context);
                long affected = ExecuteNow(item.InsertSql(Context));
                if (affected != 1)
                    throw new Exception("Insert affected " + affected.ToString() + " rows");
                item.Inserted(Context);
                Change(Context, new ChangeArgs((Item)item, null, null));
            }
        }

        public void Update(Context x, IItems items)
        {
            foreach (IItem i in items.AllGet(x))
            {
                Update(i);
            }
        }
        public void Update(IItem item, bool inhibit_notify = false)
        {
            if (item.Uid == "")
                throw new Exception("Item not saved");

            if (tranMode)
            {
                lock (tranTasks)
                {
                    if (DeletedIds.Contains(item.Uid))
                        throw new Exception(item.Uid + " already being deleted");

                    //this whole concept opens the possibility for 1 specific problem:
                    //begintrans
                    //insert(x)
                    //execute(delete from xtable where d = y)
                    //x.d = y
                    //update(x)
                    //since x would be inserted with d=y because of the delta handling, the execute would delete it, when the code clearly intended the delete to happen first
                    //should that just be turned off?
                    //2012_05_26 turning it off - the sequential consistency from code is more important than the extra sql statement
                    //if (InsertedIds.Contains(item.Uid))
                    //    return;  //will be handled on insert

                    item.Updating(Context);
                    tranTasks.Add(new TranTaskItem(Context, item, ItemTransType.Update));
                    UpdatedIds.Add(item.Uid);
                }
            }
            else
            {
                item.Updating(Context);
                String updateSql = item.UpdateSql(Context);
                if (updateSql != "")
                {
                    long affected = ExecuteNow(updateSql);
                    if (affected != 1)
                        throw new Exception("Update affected " + affected.ToString() + " rows");
                    item.Updated(Context);
                    if (!inhibit_notify)
                        Change(Context, new ChangeArgs(null, (Item)item, null));
                }
            }
        }

        public void Delete(Context x, IItems items)
        {
            foreach (IItem i in items.AllGet(x))
            {
                Delete(i);
            }
        }
        public void Delete(IItem item)
        {
            if (tranMode)
            {
                lock (tranTasks)
                {
                    if (DeletedIds.Contains(item.Uid))
                        throw new Exception(item.Uid + " already being deleted");

                    item.Deleting(Context);
                    tranTasks.Add(new TranTaskItem(Context, item, ItemTransType.Delete));
                    DeletedIds.Add(item.Uid);
                }
            }
            else
            {
                item.Deleting(Context);
                long affected = ExecuteNow(item.DeleteSql(Context));
                if (affected != 1)
                    throw new Exception("Delete removed " + affected.ToString() + " rows");
                item.Deleted(Context);
                Change(Context, new ChangeArgs(null, null, (Item)item));
            }
        }


        //change sets

        Stack<string> changeStack = new Stack<string>();  //use this as the lock for changes
        ChangeArgs changeCache;

        public void Change(Context x, ChangeArgs args)
        {
            if (changeCache == null)
                Context.Sys.ChangedFire(x, args);
            else
                changeCache.Add(args);
        }

        public String StartChangeCache()
        {
            lock (changeStack)
            {
                String id = Tools.Strings.GetNewID();
                changeStack.Push(id);

                if (changeCache == null)
                    changeCache = new ChangeArgs();

                return id;
            }
        }

        public void EndChangeCache(Context x, String id)
        {
            lock (changeStack)
            {
                if (changeStack.Peek() != id)
                    throw new Exception("Change cache mis-match");

                changeStack.Pop();
                if (changeStack.Count == 0)
                {
                    ChangeArgs args = changeCache;
                    changeCache = null;
                    Change(x, args);
                }
            }
        }

        //transactions

        Stack<string> tranStack = new Stack<string>();  //use this as the lock for all tran lists
        List<TranTask> tranTasks = new List<TranTask>();

        public bool TransactionMode
        {
            get
            {
                return tranMode;
            }
        }

        public int TransactionDepth
        {
            get
            {
                lock (tranStack)
                {
                    return tranStack.Count;
                }
            }
        }

        public String TransactionTop
        {
            get
            {
                lock (tranStack)
                {
                    return tranStack.Peek();
                }
            }
        }


        bool tranMode = false;
        List<String> UpdatedIds = new List<string>();
        List<String> InsertedIds = new List<string>();
        List<String> DeletedIds = new List<string>();

        public string BeginTran()
        {
            string ret = Tools.Strings.GetNewID();
            lock (tranStack)
            {
                tranStack.Push(ret);

                if (!tranMode)
                {
                    tranMode = true;
                    tranTasks = new List<TranTask>();
                }
            }
            return ret;
        }

        public void CommitTran(String tranId)
        {
            lock (tranStack)
            {
                if (!tranMode)
                    throw new Exception("Not in trans mode");

                if (tranStack.Peek() != tranId)
                    throw new Exception("Tran id mis-match");

                tranStack.Pop();

                if (tranStack.Count > 0)
                    return;

                StringBuilder sb = new StringBuilder();

                lock (tranTasks)
                {
                    foreach (TranTask t in tranTasks)
                    {
                        sb.AppendLine(t.Sql(Context));
                    }

                    if (!Tools.Strings.StrExt(sb.ToString()))
                    {
                        ;
                    }

                    try
                    {
                        Context.TheData.TheConnection.ExecuteTransaction(sb.ToString());

                        InsertedIds.Clear();
                        UpdatedIds.Clear();
                        DeletedIds.Clear();

                        ChangeArgs args = new ChangeArgs();

                        try
                        {
                            foreach (TranTask t in tranTasks)
                            {
                                if (t is TranTaskItem)
                                {
                                    TranTaskItem ti = (TranTaskItem)t;
                                    switch (ti.ChangeType)
                                    {
                                        case ItemTransType.Insert:
                                            ti.Item.Inserted(Context);
                                            args.AddInserted((Item)ti.Item);
                                            break;
                                        case ItemTransType.Update:
                                            ti.Item.Updated(Context);
                                            args.AddUpdated((Item)ti.Item);
                                            break;
                                        case ItemTransType.Delete:
                                            ti.Item.Deleted(Context);
                                            args.AddDeleted((Item)ti.Item);
                                            break;
                                    }
                                }
                            }
                        }
                        catch { }

                        Change(Context, args);  //one single, consolidated change event
                    }
                    catch (Exception ex)
                    {
                        foreach (TranTask t in tranTasks)
                        {
                            if (t is TranTaskItem)
                            {
                                TranTaskItem ti = (TranTaskItem)t;
                                ti.Item.Invalidate(Context);
                            }
                        }

                        TranModeClear();
                        throw new Exception("Transaction error: " + ex.Message + "\r\n\r\n" + sb.ToString());
                    }

                    TranModeClear();
                }
            }
        }

        void TranModeClear()
        {
            tranTasks.Clear();
            tranMode = false;
        }
    }

    abstract class TranTask
    {
        public abstract String Sql(Context x);
    }

    class TranTaskItem : TranTask
    {
        public IItem Item;
        public ItemTransType ChangeType;
        String sql = "";

        public TranTaskItem(Context x, IItem item, ItemTransType type)
        {
            Item = item;
            ChangeType = type;

            String changeSql = "";

            //caching the sql right now; its more db intense but more consistent from sequential code
            switch (ChangeType)
            {
                case ItemTransType.Insert:
                    changeSql = Item.InsertSql(x);
                    break;
                case ItemTransType.Update:
                    changeSql = Item.UpdateSql(x);
                    break;
                case ItemTransType.Delete:
                    changeSql = Item.DeleteSql(x);
                    break;
                default:
                    throw new Exception("Invalid change type");
            }

            if (Tools.Strings.StrExt(changeSql))
                sql += changeSql + RaiseErrorIfNot1;
        }

        static String RaiseErrorIfNot1 = "\r\nif @@ROWCOUNT <> 1 RAISERROR('Wrong number affected', 11, 1) ";  //severity 11 is apparently the min to actually break the process

        public override String Sql(Context x)
        {
            return sql;
        }
    }

    class TranTaskSql : TranTask
    {
        String sql;

        public TranTaskSql(string s)
        {
            sql = s;
        }

        public override String Sql(Context x)
        {
            return sql;
        }
    }

    enum ItemTransType
    {
        Insert,
        Update,
        Delete
    }

    //class DeltaHandle
    //{
    //    public IWatcher Watcher;
    //    public List<IChannel> Insert = new List<IChannel>();
    //    public List<IChannel> Update = new List<IChannel>();
    //    public List<IChannel> Delete = new List<IChannel>();
    //}
}
