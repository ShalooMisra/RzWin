using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Tools;
using Tools.Database;
using Core;

namespace Core
{
    public class DataSql : DataStore
    {
        public String ServerName
        {
            get
            {
                return TheConnection.TheKey.ServerName;
            }
        }

        public String DatabaseName
        {
            get
            {
                return TheConnection.TheKey.DatabaseName;
            }
        }

        public String UserName
        {
            get
            {
                return TheConnection.TheKey.UserName;
            }
        }

        public String UserPassword
        {
            get
            {
                return TheConnection.TheKey.UserPassword;
            }
        }

        public void DropTable(String table)
        {
            TheConnection.DropTable(table);
        }

        public bool TableExists(String table)
        {
            return TheConnection.TableExists(table);
        }

        public bool FieldExists(String table, String field)
        {
            return TheConnection.FieldExists(table, field);
        }

        public static void StructureCheckClass(Context x, CoreClassHandle h, String table)
        {
            StructureCheckClass(x, x.Data.Connection, h, table, new List<Field>());
        }

        public static void StructureCheckClass(Context x, DataConnection data, String table)
        {
            StructureCheckClass(x, data, x.Sys.CoreClassGet(table), table, new List<Field>());
        }

        public static void StructureCheck(Context x, List<Field> extraFields)
        {
            StructureCheck(x, x.Data.Connection, extraFields);
        }

        public static void StructureCheck(Context x, DataConnection dataConnection, List<Field> extraFields)
        {
            List<CoreClassHandle> classes = x.Sys.CoreClassesList();
            x.Leader.ProgressStart(classes.Count);
            foreach (CoreClassHandle h in classes)
            {
                StructureCheckClass(x, dataConnection, h, h.Name, extraFields);
                x.Leader.ProgressAdd();
            }
            x.Leader.ProgressEnd();
        }

        public static void StructureCheckClass(Context x, DataConnection connection, CoreClassHandle h, String table)
        {
            StructureCheckClass(x, connection, h, table, new List<Field>());
        }

        public static void StructureCheckClass(Context x, DataConnection connection, CoreClassHandle h, String table, List<Field> extraFields)
        {
            if (connection.ViewIs(table))
                return;

            List<Field> fields = new List<Field>();
            fields.Add(x.Data.UniqueIdField);  //this is the only place where the explicit datastore object is needed.  right now its assumed to be x.Data

            foreach (Field f in extraFields)
            {
                fields.Add(f);
            }

            AppendClassFields(x, h, fields);

            if (!connection.TableExists(table))
                connection.TableCreate(table, fields);
            else
                connection.FieldsMakeExist(table, fields);
        }

        static void AppendClassFields(Context x, CoreClassHandle h, List<Field> fields)
        {
            foreach (CoreVarAttribute attr in Item.VarAttributesGet(h.TheType))
            {
                attr.FieldsAppend(fields);
            }

            String baseName = Tools.Data.NullFilterString(h.TheAttribute.BaseClass);
            switch (baseName)
            {
                case "":
                case "Core.Item":
                    break;
                default:

                    String baseClassNameOnly = baseName;
                    if (baseClassNameOnly.Contains("."))
                        baseClassNameOnly = Tools.Strings.ParseDelimit(baseClassNameOnly, ".", 2);

                    //this won't prevent all infinite loops but will prevent some
                    if (h.Name == baseClassNameOnly)
                        return;
                    CoreClassHandle baseHandle = x.Sys.CoreClassGet(baseClassNameOnly);
                    if (baseHandle != null)
                        AppendClassFields(x, baseHandle, fields);
                    break;
            }
        }

        //Public Variables
        public DataConnection TheConnection;

        public DataConnection Connection
        {
            get
            {
                return TheConnection;
            }
        }

        public DataKeySql TheKeySql
        {
            get
            {
                return (DataKeySql)TheKey;
            }
        }
        //Private Variables
        public Tools.Database.Field UniqueIdField
        {
            get
            {
                Tools.Database.Field ret = new Tools.Database.Field(UidField, FieldType.String, 256);
                ret.Unique = true;
                //ret.Required = true;
                return ret;
            }
        }

        //Constructors
        public DataSql()
        {
            UidField = "unique_id";
        }
        public DataSql(String serverName, String userName, String password, String databaseName, ServerType serverType) : this()
        {
            DataKeySql key = new DataKeySql();
            key.ServerNameVar.Value = serverName;
            key.UserNameVar.Value = userName;
            key.UserPasswordVar.Value = password;
            key.DatabaseNameVar.Value = databaseName;
            key.ServerTypeVar.Value = serverType;
            Init(null, key);
        }
        //Public virtual Functions
        //public virtual void InsertItem(Context x, IItem i)
        //{
        //    TheConnection.Execute(InsertOneSql(x, (Item)i, i.ClassId));
        //}
        //public virtual void UpdateItem(Context x, IItem i)
        //{
        //    Item iu = (Item)i;
        //    //if (iu.ValuesChanged)
        //    //{
        //        TheConnection.Execute(UpdateOneSql(x, iu, iu.ClassId));
        //    //}
        //}
        //public virtual void DeleteItem(Context x, IItem i)
        //{
        //    TheConnection.Execute(DeleteOneSql(x, (Item)i, i.ClassId));
        //}
        //Public Override Functions
        public override void Init(Context x, DataKey key)
        {
            TheConnection = null;
            base.Init(x, key);

            TheConnection = DataConnection.Create(TheKeySql.ServerTypeVar.ValueEnum);
            TheConnection.Init(TheKeySql.KeyConnection);
        }

        public override DataTable Select(string sql)
        {
            return TheConnection.Select(sql);
        }

        public override string Filter(string term)
        {
            return TheConnection.SyntaxFilter(term);
        }

        //public override void InsertItems(Context x, IItems items)
        //{
        //    base.InsertItems(x, items);
        //    foreach (IItem i in items.AllGet(x))
        //    {
        //        InsertItem(x, i);
        //    }
        //}
        //public override void UpdateItems(Context x, IItems items)
        //{
        //    base.UpdateItems(x, items);
        //    foreach (IItem i in items.AllGet(x))
        //    {
        //        UpdateItem(x, i);
        //    }
        //}
        //public override void DeleteItems(Context x, IItems items)
        //{
        //    base.DeleteItems(x, items);
        //    foreach (IItem i in items.AllGet(x))
        //    {
        //        DeleteItem(x, i);
        //    }
        //}
        public override DataTable TableGet(string table)
        {
            return TheConnection.Select("select * from " + table);
        }
        public override DataTable Select(Context x, Query q, IItems items)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select");
            if (q.Fields != null)
            {
                if (q.Fields.Count > 0)
                {
                    List<String> fields = new List<string>();
                    foreach (QueryField f in q.Fields)
                    {
                        fields.Add(f.NameFullAlias);
                    }
                    sb.Append(Tools.Strings.CommaSeparateBlanksIgnore(fields));
                }
                else
                {
                    sb.Append(" *");
                }
            }
            else
            {
                sb.Append(" *");
            }
            sb.Append(FromRender(q));
            sb.Append(WhereRender(x, q, items));
            sb.Append(GroupRender(q));
            sb.Append(OrderRender(q));
            //SqlArgs args = new SqlArgs();
            //DataTable ret = TheConnection.Select(sb.ToString(), args);
            //if (!args.Passed)
            //    x.TheLeader.Error("Sql Error: " + sb.ToString() + "\r\n" + args.Message);
            DataTable ret = null;
            try { ret = TheConnection.Select(sb.ToString()); }
            catch (Exception e)
            { x.TheLeader.Error("Sql Error: " + sb.ToString() + "\r\n" + e.Message); }
            return ret;
        }
        public override int Count(Context x, Query q)
        {
            return TheConnection.ScalarInt32("select count(*)" + FromRender(q) + WhereRender(x, q, null) + GroupRender(q));
        }
        public override int Count(Context x, Query q, IItems items)
        {
            return TheConnection.ScalarInt32("select count(*)" + FromRender(q) + WhereRender(x, q, items) + GroupRender(q));
        }
        public override string FieldConvert(string s)
        {
            switch (s)
            {
                case "Uid":
                    return "unique_id";
                case "DateCreated":
                    return "date_created";
                case "DateModified":
                    return "date_modified";
                case "GridColor":
                    return "grid_color";
                case "IconIndex":
                    return "icon_index";
                default:
                    return base.FieldConvert(s);
            }
        }
        public override bool TableClear(string table)
        {
            try { TheConnection.Execute("truncate table " + table); }
            catch { return false; }
            return true;
        }
        public override List<string> DatabasesList()
        {
            return StringList("select name from [master].[dbo].sysdatabases order by name");
        }
        public override void DatabaseDelete(string database)
        {
            //base.DatabaseDelete(database);
            TheConnection.Execute("use master\r\ndrop database " + database);
        }
        //Public Functions

        public String InsertOneSql(Context x, Item i, String table)
        {
            return InsertOneSql(x, i, table, "", "");
        }

        //KT 4-18-2016 - Insert for MySQL
        public String InsertOneSqlMy(Context x, Item i, String table)
        {
            return InsertOneSqlMy(x, i, table, "", "");
        }

        public string InsertOneSql(Context x, Item i, String table, String extraFields, String extraValues)
        {


            //KT 4-19-2016 conveneince variable to hold system type
            //string st = x.TheData.TheSys.ToString().ToLower();

            if (i.Uid == "")
                throw new Exception("Insert error: no Uid");

            StringBuilder sbFields = new StringBuilder();
            StringBuilder sbValues = new StringBuilder();
            sbFields.Append(UidField);
            sbValues.Append("'" + TheConnection.SyntaxFilter(i.Uid) + "'");
            List<FieldValue> vals = new List<FieldValue>();
            foreach (CoreVarAttribute attr in i.VarAttributesGet())

            {
                Var prop = i.VarGetByName(attr.Name);
                foreach (FieldValue v in prop.FieldValuesGet(x, false))
                {


                    sbFields.Append(", ");
                    sbFields.Append(TheConnection.FieldName(v));
                    sbValues.Append(", ");
                    sbValues.Append(TheConnection.FieldValue(v));
                }
            }
            string sql = "insert into [" + table + "] ( " + sbFields.ToString() + extraFields + " ) values ( " + sbValues.ToString() + extraValues + " )";
            return sql;
        }

        //KT 4-19-2016 - Insert For MySQL
        public string InsertOneSqlMy(Context x, Item i, String table, String extraFields, String extraValues)
        {

            DataConnectionSqlMy mySqlDataConnection = new DataConnectionSqlMy();
            //KT 4-19-2016 conveneince variable to hold system type
            //string st = x.TheData.TheSys.ToString().ToLower();

            if (i.Uid == "")
                throw new Exception("Insert error: no Uid");

            StringBuilder sbFields = new StringBuilder();
            StringBuilder sbValues = new StringBuilder();
            sbFields.Append(UidField);
            sbValues.Append("'" + mySqlDataConnection.SyntaxFilter(i.Uid) + "'");
            List<FieldValue> vals = new List<FieldValue>();
            foreach (CoreVarAttribute attr in i.VarAttributesGet())

            {
                Var prop = i.VarGetByName(attr.Name);
                foreach (FieldValue v in prop.FieldValuesGet(x, false))
                {


                    sbFields.Append(", ");

                    //KT 4-19-2016 - Handle MYSQL fieldNames (don't addbrackets)

                    //if (st == "sqlmy")
                    //    sbFields.Append(v);
                    //else
                    sbFields.Append(mySqlDataConnection.FieldNameMy(v));

                    sbValues.Append(", ");
                    sbValues.Append(mySqlDataConnection.FieldValueMy(v));
                }
            }
            return "insert into " + table + " ( " + sbFields.ToString() + extraFields + " ) values ( " + sbValues.ToString() + extraValues + " )";
        }

        public String UpdateOneSql(Context x, Item i, String table)
        {
           
            StringBuilder sbFields = new StringBuilder();
            StringBuilder sbValues = new StringBuilder();
            bool first = true;
            bool changed = false;
            List<String> fields = new List<string>();
            foreach (Var v in i.VarsGet())
            {
                if (!v.Changed)
                    continue;

                if (v is VarVal && ((VarVal)v).TheValAttribute.Transactional)
                    continue;

                if (v.Changed)
                {
                    foreach (FieldValue fv in v.FieldValuesGet(x, true))
                    {
                        //this check shouldn't have to be done
                        if (fields.Contains(fv.Name.ToLower()))
                            continue;
                        fields.Add(fv.Name.ToLower());

                        if (!first)
                            sbFields.Append(", ");
                        sbFields.Append(TheConnection.FieldValueRenderEquals(fv));
                        first = false;
                        changed = true;
                    }
                }
            }

            if (changed)
                return "update " + table + " set " + sbFields.ToString() + " where " + UidField + " = '" + TheConnection.SyntaxFilter(i.Uid) + "'";
            else
                return "";
        }
        //KT 4-19-2016 - Update For MySQL
        public String UpdateOneSqlMy(Context x, Item i, String table)
        {
            DataConnection mysqlDataConnection = new DataConnectionSqlMy();
            StringBuilder sbFields = new StringBuilder();
            StringBuilder sbValues = new StringBuilder();
            bool first = true;
            bool changed = false;
            List<String> fields = new List<string>();
            foreach (Var v in i.VarsGet())
            {
                if (!v.Changed)
                    continue;

                if (v is VarVal && ((VarVal)v).TheValAttribute.Transactional)
                    continue;

                if (v.Changed)
                {
                    foreach (FieldValue fv in v.FieldValuesGet(x, true))
                    {
                        //this check shouldn't have to be done
                        if (fields.Contains(fv.Name.ToLower()))
                            continue;
                        fields.Add(fv.Name.ToLower());

                        if (!first)
                            sbFields.Append(", ");
                        sbFields.Append(mysqlDataConnection.FieldValueRenderEqualsMy(fv));
                        first = false;
                        changed = true;
                    }
                }
            }

            if (changed)
                return "update " + table + " set " + sbFields.ToString() + " where " + UidField + " = '" + mysqlDataConnection.SyntaxFilter(i.Uid) + "'";
            else
                return "";
        }
        public String DeleteOneSql(Context x, Item i, String table)
        {
            return "delete from " + table + " where " + UidField + " =  '" + TheConnection.SyntaxFilter(i.Uid) + "'";
        }
        public String FromRender(Query q)
        {
            StringBuilder ret = new StringBuilder();
            ret.Append(" from " + q.TableMain.Name);
            if (Tools.Strings.StrExt(q.TableMain.Alias) && q.TableMain.Name != q.TableMain.Alias)
                ret.Append(" " + q.TableMain.Alias);

            //joins


            return ret.ToString();
        }
        public String WhereRender(Context x, Query q, IItems items)//where needs to be an actual expression
        {
            String ret = q.WhereRender(x, items, new ExpressionBuilderSql(TheConnection));
            if (ret == "")
                return "";

            return " where " + ret;
        }
        public String GroupRender(Query q)
        {
            if (q.GroupBy == null)
                return "";

            if (q.GroupBy.Count == 0)
                return "";

            List<String> groups = new List<string>();
            foreach (QueryField f in q.GroupBy)
            {
                groups.Add(f.NameFull);
            }

            return " group by " + Tools.Strings.CommaSeparateBlanksIgnore(groups);
        }
        public String OrderRender(Query q)
        {
            if (q.OrderBy == null)
                return "";

            if (q.OrderBy.Count == 0)
                return "";

            List<String> orders = new List<string>();
            foreach (QueryOrder o in q.OrderBy)
            {
                if (o.Desc)
                    orders.Add(o.TheField.NameFull + " desc");
                else
                    orders.Add(o.TheField.NameFull);
            }

            return " order by " + Tools.Strings.CommaSeparateBlanksIgnore(orders);
        }
        public List<String> StringList(String sql)
        {
            DataTable d = TheConnection.Select(sql);
            List<String> ret = new List<string>();
            foreach (DataRow r in d.Rows)
            {
                ret.Add(Tools.Data.NullFilterString(r[0]));
            }
            return ret;
        }
        //public override bool Create(Context x)
        //{
        //    SqlArgs args = new SqlArgs();
        //    if (TheConnection.DatabaseCreate(TheKeySql.KeyConnection, args))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        x.TheLeader.Error("Database create error: " + args.Message);
        //        return false;
        //    }
        //}
        //Tools.Database.Field FieldGet(CoreVarAttribute a)
        //{
        //    FieldType t = FieldType.String;
        //    //switch()
        //    //{
        //    //    case:
        //    //}
        //    return new Field(a.Name, t);
        //}
        //public String LogicRender(String where)
        //{
        //    if( where == null )
        //        return "";
        //    if (where == "")
        //        return "";
        //    return " " + where; 
        //}

        public String SelectScalarString(String sql)
        {
            return TheConnection.ScalarString(sql);
        }

        public bool SelectScalarBoolean(String sql)
        {
            return TheConnection.ScalarBoolean(sql);
        }

        public Object SelectScalar(String sql, FieldType type)
        {
            return TheConnection.Scalar(sql, type);
        }

        public ArrayList SelectScalarArray(String sql)
        {
            return TheConnection.ScalarArray(sql);
        }

        public int SelectScalarInt32(String sql)
        {
            return TheConnection.ScalarInt32(sql);
        }

        public double SelectScalarDouble(String sql)
        {
            return TheConnection.ScalarDouble(sql);
        }

        public void RenameField(String table, String fieldNameFrom, String fieldNameTo)
        {
            TheConnection.RenameField(table, fieldNameFrom, fieldNameTo);
        }

        public List<CoreVarValAttribute> GetFieldArray_Prop(String strTable)
        {
            List<CoreVarValAttribute> a = new List<CoreVarValAttribute>();
            DataTable t = Select(String.Concat("select top 1 * from ", strTable));
            if (t == null)
                return a;
            CoreVarValAttribute p;
            for (int i = 0; i < t.Columns.Count; i++)
            {
                p = new CoreVarValAttribute(t.Columns[i].ColumnName, DataConnectionSqlServer.ConvertColumnTypeToFieldType(t.Columns[i]), t.Columns[i].MaxLength);
                a.Add(p);
            }
            return a;
        }

        //query tools

        public Item GetById(Context x, String classId, String uid, String alternateTable = "")
        {
            return GetById(x, classId, uid, this, TheConnection, alternateTable);
        }
        public static Item GetById(Context x, String classId, String uid, DataStore store, DataConnection data, String alternateTable = "")
        {
            if (!Tools.Strings.StrExt(classId) || !Tools.Strings.StrExt(uid))
                return null;

            return GetByWhere(x, classId, data, store.UidField + " = '" + uid + "'", alternateTable);
        }

        public Item GetByWhere(Context x, String classId, String where, String alternateTable = "")
        {
            return GetByWhere(x, classId, TheConnection, where, alternateTable);
        }

        public static Item GetByWhere(Context x, String classId, DataConnection data, String where, String alternateTable = "")
        {
            String table = classId;
            if (Tools.Strings.StrExt(alternateTable))
                table = alternateTable;

            Item ret = QtO(x, classId, "select * from " + table + " where " + where, data);
            if (ret == null)
                return null;

            if (Tools.Strings.StrExt(alternateTable))
                ret.TableName = alternateTable;

            return ret;
        }

        public Item GetByName(Context x, String classId, String name, String extraSql = "")
        {
            String where = "name = '" + Filter(name) + "'";
            if (Tools.Strings.StrExt(extraSql))
                where += " and " + extraSql;
            return GetByWhere(x, classId, where);
        }

        public Item QtO(Context x, String classId, String sql)
        {
            return QtO(x, classId, sql, TheConnection);
        }

        public static Item QtO(Context x, String classId, String sql, DataConnection data)
        {
            ArrayList a = QtC(x, classId, sql, data);
            if (a.Count == 0)
                return null;
            else
                return (Item)a[0];
        }

        public ArrayList QtC(Context x, String classId, String sql)
        {
            return QtC(x, classId, sql, TheConnection);
        }

        public static ArrayList QtC(Context x, String classId, String sql, DataConnection data)
        {
            ArrayList a = new ArrayList();
            DataTable t = data.Select(sql);

            if (t == null)
                throw new Exception("Query failed");

            if (t.Rows.Count <= 0)
                return a;

            Item item;
            foreach (DataRow r in t.Rows)
            {
                item = x.Item(classId);
                if (item == null)
                    throw new Exception("Item creation failed");

                try
                {
                    item.AbsorbRow(x, r);
                }
                catch (Exception ex)
                {
                    x.TheLeader.Error(ex);
                    throw ex;
                }
                a.Add(item);
            }
            return a;
        }

        public ItemsInstance QtI(Context x, String classId, String sql)
        {
            ArrayList a = QtC(x, classId, sql);
            ItemsInstance ret = new ItemsInstance();
            foreach (IItem i in a)
            {
                ret.Add(x, i);
            }
            return ret;
        }

        public Dictionary<String, Item> QtD(Context x, String classId, String sql)
        {
            return QtD(x, classId, sql, TheConnection);
        }

        public static Dictionary<String, Item> QtD(Context x, String classId, String sql, DataConnection data)
        {
            ArrayList a = QtC(x, classId, sql, data);
            Dictionary<String, Item> ret = new Dictionary<string, Item>();
            foreach (Item o in a)
            {
                ret.Add(o.Uid, o);
            }
            return ret;
        }

        public ArrayList ScalarArray(String sql)
        {
            return TheConnection.ScalarArray(sql);
        }

        public void FieldMakeExist(String table, Field field)
        {
            TheConnection.FieldMakeExist(table, field);
        }

        public long Execute(String sql, bool failOK = false)
        {
            long affected = 0;
            TheConnection.Execute(sql, ref affected, failOK);
            return affected;
        }

        public bool StatementExists(String sql)
        {
            return TheConnection.StatementExists(sql);
        }

        public static void FieldMaintenance(Context x, DataConnectionSqlServer connection)
        {
            foreach (CoreClassHandle h in x.Sys.CoreClassesList())
            {
                if (h.TheAttribute.Abstract)
                    continue;

                if (connection.IsView(h.Name))
                    continue;

                FieldMaintenance(x, connection, h);
            }
        }

        public static void FieldMaintenance(Context x, DataConnectionSqlServer connection, CoreClassHandle h)
        {
            FieldMaintenance(x, connection, h, h.Name);
        }
        public static void FieldMaintenance(Context x, DataConnectionSqlServer connection, CoreClassHandle h, String tableName)
        {

            foreach (CoreVarValAttribute a in h.VarValsGet())
            {
                int type = connection.ScalarInt32("select syscolumns.xtype from syscolumns inner join sysobjects on sysobjects.id = syscolumns.id where sysobjects.name = '" + tableName + "' and syscolumns.name = '" + a.Name + "'");
                switch (a.TheFieldType)
                {
                    case FieldType.String:
                        if (a.TheFieldLength > 20)
                        {
                            int len = connection.ScalarInt32("select length from syscolumns inner join sysobjects on sysobjects.id = syscolumns.id where syscolumns.xtype <> 35 and syscolumns.length <> 16 and sysobjects.name = '" + tableName + "' and syscolumns.name = '" + a.Name + "'");
                            if (len > 0 && len != 16) //otherwise it wasn't found, right?
                            {
                                if (len < a.TheFieldLength)
                                {
                                    x.Leader.Comment("Widening " + h.Name + "." + a.Name);
                                    connection.Execute("alter table " + tableName + " alter column " + a.Name + " varchar(" + a.TheFieldLength.ToString() + ")");
                                }
                            }
                        }
                        break;
                    case FieldType.Text:
                        if (type != 35)
                        {
                            x.Leader.Comment("Converting " + tableName + "." + a.Name + " to text");
                            connection.Execute("alter table " + tableName + " alter column " + a.Name + " text");
                        }
                        break;
                    case FieldType.Int32:
                        if (type != 56)
                        {
                            x.Leader.Comment("Converting " + tableName + "." + a.Name + " to int");
                            connection.Execute("alter table " + tableName + " alter column " + a.Name + " int");
                        }
                        break;
                    case FieldType.Int64:
                        if (type != 127)
                        {
                            x.Leader.Comment("Converting " + tableName + "." + a.Name + " to bigint");
                            connection.Execute("alter table " + tableName + " alter column " + a.Name + " bigint");
                        }
                        break;
                    case FieldType.Double:
                        if (type != 62)
                        {
                            x.Leader.Comment("Converting " + tableName + "." + a.Name + " to float");
                            connection.Execute("alter table " + tableName + " alter column " + a.Name + " float");
                        }
                        break;
                    case FieldType.Boolean:
                        if (type != 104)
                        {
                            x.Leader.Comment("Converting " + tableName + "." + a.Name + " to bit");
                            connection.Execute("alter table " + tableName + " alter column " + a.Name + " bit");
                        }
                        break;
                }
            }
        }
    }

    public class ExpressionBuilderSql : ExpressionBuilder
    {
        DataConnection TheConnection;
        public ExpressionBuilderSql(DataConnection connection)
        {
            TheConnection = connection;
        }
        public override void AddFieldUid()
        {
            Add("unique_id");
        }
        public override void AddFormatString(string s)
        {
            Add("'" + TheConnection.SyntaxFilter(s) + "'");
        }
    }
}
