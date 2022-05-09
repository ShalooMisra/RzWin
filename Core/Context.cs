using System;
using System.Collections.Generic;
using System.Text;

using Tools;
using Core;
using Tools.Database;
using System.Collections;
using System.Data;

namespace Core
{
    public class Context
    {
        SysHandle SysHandle = new SysHandle(null);
        public Sys TheSys
        {
            get
            {
                return SysHandle.Sys;
            }

            set
            {
                SysHandle.Sys = value;
            }
        }

        public Sys Sys
        {
            get
            {
                return SysHandle.Sys;
            }

            set
            {
                SysHandle.Sys = value;
            }
        }

        public Leader TheLeader;

        public Leader Leader
        {
            get
            {
                return TheLeader;
            }

            set
            {
                TheLeader = value;
            }
        }

        public Logic TheLogic
        {
            get
            {
                return TheSys.Logic;
            }
        }

        public LogicCore Logic
        {
            get
            {
                return (LogicCore)TheSys.Logic;
            }
        }

        public Delta TheDelta;

        public DataSql Data
        {
            get
            {
                return TheData;
            }

            set
            {
                TheData = value;
            }
        }

        public DataSql TheData;

        public Context()
        {
            TheDelta = new Delta(this);
        }

        public Context(Sys s, Leader l) : this()
        {
            TheSys = s;
            TheLeader = l;
        }

        public Context Clone()
        {
            Context ret = Create();

            if (ret.GetType().Name != GetType().Name)
                throw new Exception("Context type mis-match");

            Apply(ret);
            return ret;
        }

        public virtual Context Create()
        {
            return new Context();
        }

        public virtual void Apply(Context x)
        {
            x.SysHandle = SysHandle;
            x.TheLeader = TheLeader;
            x.TheData = TheData;

            //this needs to not be included; that's usually the reason for the clone
            //x.TheDelta = TheDelta;
        }

        public void LeaderRecreate()
        {
            Leader = Leader.Clone();
        }

        //the security is built into the context
        public bool Show(IItems items)
        {
            if (items == null)
                return false;

            ViewType t = ViewType.Unknown;

            if (items.CountGet(this) == 1)
                t = ViewType.SingleItem;

            return Show(new ShowArgs(this, t, items));
        }

        public virtual bool Show(ShowArgs args)
        {
            return TheLeader.Show(this, args);
        }

        //new stuff

        public Item Item(String classId)
        {
            return TheSys.ItemCreate(classId);  //, new ItemArgs(this)
        }

        public void Execute(String sql, ref long affected)
        {
            TheData.TheConnection.Execute(sql, ref affected);
        }

        public void Execute(String sql, bool failOK = false)
        {
            if (failOK)
            {
                if (TheDelta.TransactionMode)
                    throw new Exception("Transaction mode does not accept failOK");
                else
                    TheData.TheConnection.Execute(sql, FailOK: failOK);
            }
            else
                TheDelta.Execute(sql);
        }

        public String BeginTran()
        {
            return TheDelta.BeginTran();
        }

        public void CommitTran()
        {
            if (TheDelta.TransactionDepth != 1)
                throw new Exception("Not in a single layer transaction; need to pass in the Id");

            CommitTran(TheDelta.TransactionTop);
        }

        public void CommitTran(String tranId)
        {
            TheDelta.CommitTran(tranId);
        }

        //public void IgnoreTran()
        //{
        //    TheDelta.IgnoreTran();
        //}

        public void Insert(IItem i)
        {
            TheDelta.Insert(i);
        }

        public void Update(IItem i, bool inhibit_notify = false)
        {
            TheDelta.Update(i, inhibit_notify);
        }

        public void Delete(IItem i)
        {
            TheDelta.Delete(i);
        }

        public virtual void StructureCheck()
        {
            DataSql.StructureCheck(this, new List<Field>());
        }

        public virtual Item GetById(String classId, String uid)
        {
            return TheData.GetById(this, classId, uid);
        }

        public virtual Item GetById(String classId, String uid, String alternateTable)
        {
            return GetById(classId, uid, alternateTable, TheData.TheConnection);
        }

        public virtual Item GetById(String classId, String uid, String alternateTable, DataConnection alternateData)
        {
            return DataSql.GetById(this, classId, uid, TheData, alternateData, alternateTable);
        }

        public Item GetByName(String classId, String name, String extraSql = "")
        {
            return TheData.GetByName(this, classId, name, extraSql);
        }

        public ArrayList QtC(String classId, String sql)
        {
            return TheData.QtC(this, classId, sql);
        }

        public Item QtO(String classId, String sql)
        {
            return TheData.QtO(this, classId, sql);
        }

        public Item QtO(String classId, String sql, DataConnection data)
        {
            return DataSql.QtO(this, classId, sql, data);
        }

        public DataTable Select(String sql)
        {
            return TheData.Select(sql);
        }

        public string Filter(string sql)
        {
            return TheData.Filter(sql);
        }

        public String SelectScalarString(String sql)
        {
            return TheData.SelectScalarString(sql);
        }

        public bool SelectScalarBoolean(String sql)
        {
            return TheData.SelectScalarBoolean(sql);
        }

        public long SelectScalarInt64(String sql)
        {
            return TheData.TheConnection.ScalarInt64(sql);
        }

        public int SelectScalarInt32(String sql)
        {
            return TheData.TheConnection.ScalarInt32(sql);
        }

        public Double SelectScalarDouble(String sql)
        {
            return TheData.TheConnection.ScalarDouble(sql);
        }

        public DateTime SelectScalarDateTime(String sql)
        {
            return TheData.TheConnection.ScalarDateTime(sql);
        }

        public void Reorg()
        {
            TheLeader.Reorg();
        }

        public ArrayList SelectScalarArray(String sql)
        {
            return TheData.TheConnection.ScalarArray(sql);
        }

        //KT 
        public ArrayList SelectScalarArray_Int(String sql)
        {
            return TheData.TheConnection.ScalarArray_Integer(sql);
        }

        public List<String> SelectScalarList(String sql)
        {
            return TheData.TheConnection.ScalarList(sql);
        }

        public bool StatementExists(String sql)
        {
            return TheData.TheConnection.StatementExists(sql);
        }

        public bool TableExists(String table)
        {
            return TheData.TableExists(table);
        }

        public void Comment(String comment)
        {
            TheLeader.Comment(comment);
        }

        public void Error(String error)
        {
            TheLeader.Error(error);
        }

        public String ItemCaption(Item item)
        {
            string s = "";
            try { s = Tools.Strings.NiceFormat(item.ValGet("name").ToString()); }
            catch { }
            if (!Tools.Strings.StrExt(s))
            {
                List<CoreVarAttribute> vars = TheSys.PropsGetByClass(item.ClassId);
                foreach (CoreVarAttribute a in vars)
                {
                    if (!(a is CoreVarValAttribute))
                        continue;
                    CoreVarValAttribute v = (CoreVarValAttribute)a;
                    if (v.TheFieldType == FieldType.String)
                    {
                        try { s = Tools.Strings.NiceFormat(item.ValGet(v.Name).ToString()); }
                        catch { }
                        if (!Tools.Strings.StrExt(s))
                            s = "New " + Sys.CoreClassGet(item.ClassId).TheAttribute.Caption;
                        return s;
                    }
                }
            }
            if (!Tools.Strings.StrExt(s))
                return "New " + Sys.CoreClassGet(item.ClassId).TheAttribute.Caption;
            return s;
        }
    }

    public class SysHandle
    {
        public Sys Sys;
        public SysHandle(Sys sys)
        {
            Sys = sys;
        }
    }
}
