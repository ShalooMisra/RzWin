using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Reflection;
using System.IO;
using System.Drawing;

using Tools;
using Core;
using Tools.Database;

namespace NewMethod
{
    public partial class SysNewMethod : SysNM_auto
    {
        ////this needs to be factored out
        //public CoreWin.MainForm xMainForm
        //{
        //    get
        //    {
        //        return ((CoreWin.LeaderWinUser)ContextDefault.TheLeader).TheMainForm;
        //    }
        //}

        //public static ContextNM ContextDefault = null;
        public static int ListLimitDefault = 200;

        public bool InstanceInit(ContextNM context)
        {
            CacheUsers(context);
            CacheChoices(context);
            Permissions.InitPermits(context);
            return true;
        }

        public nArray Users = new nArray();
        public nArray Teams = new nArray();
        //public n_user xUser;

        public virtual void CacheUsers(ContextNM x)
        {
            Users = new nArray();
            ArrayList a = x.QtC("n_user", "select * from n_user where isnull(name, '') > '' order by name");
            Users.Add(a);

            UserList = x.Select("select top 1 '' as unique_id, '' as name from n_user union select isnull(unique_id, '') as unique_id, isnull(name, '') as name from n_user where isnull(is_inactive, 0) = 0 and isnull(name, '') > '' order by name");
        }

        public nArray AllChoices = new nArray();
        public void CacheChoices(ContextNM context)
        {
            AllChoices = new nArray();
            AllChoices.Add(context.QtC("n_choices", "select * from n_choices order by name"));
            foreach (n_choices c in AllChoices.All)
            {
                c.CacheChoiceList(context);
            }
        }

        public override Assembly AssemblyGetHere()
        {
            return Assembly.GetExecutingAssembly();
        }
        protected override void AssemblyList(List<Assembly> ret)
        {
            ret.Add(Assembly.GetExecutingAssembly());
            base.AssemblyList(ret);
        }

        public override void ActsListInstance(Context x, ActSetup set, String classId)
        {
            base.ActsListInstance(x, set, classId);
    
            //this is set using the super user flag in the base call
            //mnu.BlockDelete = false;
            //base.GetMenuSetup(context, strClass, strExtra, multiple, mnu);

            switch (classId.ToLower())
            {
                case "n_user":
                    TheUserLogic.ActsListInstance(x, set);
                    break;
                case "n_set":
                    TheSettingLogic.ActsListInstance(x, set);
                    break;
                //case "code_solution":
                //    mnu.Add("Parse");
                //    mnu.AddSeparator();
                //    mnu.Add("Write To Disk - Text");
                //    mnu.Add("Write To Disk - Build");
                //    mnu.Add("Link");
                //    mnu.Add("View");
                //    mnu.AddSeparator();
                //    mnu.Add("Obliterate");
                //    break;
                //case "code_file":
                //    mnu.Add("Parse");
                //    mnu.Add("Parse and Save");
                //    mnu.Add("Build Tree And View");
                //    mnu.Add("Build Public Tree And View");
                //    mnu.Add("Inspect");
                //    mnu.Add("Query Cadms");
                //    mnu.Add("Link");
                //    break;
                //case "n_path":
                //    mnu.Add("Close");
                //    mnu.Add("Reopen All Steps");
                //    mnu.Add("View The Main Item");
                //    break;
                //case "n_step":
                //    mnu.Add("Mark As Complete");
                //    mnu.Add("View The Main Item");
                //    break;
                //case "n_class":
                //    mnu.Add("Copy Classes");
                //    break;
            }
        }
        //public override ArrayList GetMainProperties(String strClass)
        //{
        //    switch (strClass.ToLower())
        //    {
        //        case "n_class":
        //            return nTools.SplitArray("name|login_name|phone_number|phone_ext|email_address", "|");
        //        default:
        //            return base.GetMainProperties(strClass);
        //    }
        //}
        //public void InspectCode(String strCode)
        //{
        //    //NewMethod.CadmParsing.ParseInspector i = new NewMethod.CadmParsing.ParseInspector();
        //    //CadmEngine.xSys.xMainForm.TabShow(i, "Parse Inspector");
        //    //i.SetText(strCode);
        //}
        //public override n_step StepCreate(String type)
        //{
        //    switch (type.ToLower())
        //    {
        //        case "Step":
        //        default:
        //            return new n_step(this);
        //    }
        //}
        //public override void StepTypesList(List<String> types)
        //{
        //    types.Add("Step");
        //}

        PermitLogic m_PermitLogic;
        public PermitLogic ThePermitLogic
        {
            get
            {
                if (m_PermitLogic == null)
                    m_PermitLogic = PermitLogicCreate();
                return m_PermitLogic;
            }
        }
        protected virtual PermitLogic PermitLogicCreate()
        {
            return new PermitLogic();
        }
        ListViewLogic m_ListViewLogic;
        public ListViewLogic TheListViewLogic
        {
            get
            {
                if (m_ListViewLogic == null)
                    m_ListViewLogic = ListViewLogicCreate();
                return m_ListViewLogic;
            }
        }
        protected virtual ListViewLogic ListViewLogicCreate()
        {
            return new ListViewLogic();
        }
        SettingLogic m_SettingLogic;
        public SettingLogic TheSettingLogic
        {
            get
            {
                if (m_SettingLogic == null)
                    m_SettingLogic = SettingLogicCreate();
                return m_SettingLogic;
            }
        }
        protected virtual SettingLogic SettingLogicCreate()
        {
            return new SettingLogic();
        }

        protected override Core.ItemLogic ItemLogicCreate()
        {
            //return base.ItemLogicCreate();
            return new ItemLogic();
        }

        

        UserLogic m_UserLogic = null;
        public UserLogic TheUserLogic
        {
            get
            {
                if (m_UserLogic == null)
                    m_UserLogic = UserLogicCreate();

                return m_UserLogic;
            }

            set
            {
                m_UserLogic = value;
            }
        }

        public virtual UserLogic UserLogicCreate()
        {
            return new UserLogic();
        }

        protected override void ActInstanceBefore(Context x, ActArgs args)
        {
            base.ActInstanceBefore(x, args);
            ActInstanceRecallLog(x, args);
        }

        protected override void ActInstance(Context x, ActArgs args)
        {
            base.ActInstance(x, args);
            if (args.Handled)
                return;

            SysNewMethod.ActInstanceNM(x, args);
        }

        public static void ActInstanceNM(Context x, ActArgs args)
        {
            if (args.TheAct == null || args.TheAct.Handler == null)
            {
                args.TheContext = x;
                foreach (nObject n in args.TheItems.AllGet(x))
                {
                    n.HandleAction(args);
                }
                args.Handled = true;
            }
        }

        public static void ActInstanceRecallLog(Context x, ActArgs args)
        {
            ContextNM xnm = (ContextNM)x;
            if (xnm.xSys.Recall)
            {
                foreach (IItem i in args.TheItems.AllGet(x))
                {
                    xnm.xSys.RecallActionLog(i, args.ActionName, xnm.xUser);
                }
            }
        }

        public void RecallLogAction(Context x, Item item, String action)
        {
            ContextNM xnm = (ContextNM)x;
            if (xnm.xSys.Recall)
                xnm.xSys.RecallActionLog(item, action, xnm.xUser);
        }

        public virtual void UpdateDataStructure(ContextNM context, bool suppress_status)
        {
            UpdateDataStructure(context, (DataConnectionSqlServer)context.TheData.TheConnection, suppress_status, false);
            if (Recall)
                UpdateDataStructure(context, RecallConnection, suppress_status, true);
        }

        public virtual void UpdateDataStructure(ContextNM context, DataConnectionSqlServer data, bool suppress_status, bool recall)
        {
            try
            {
                if (!suppress_status)
                    context.TheLeader.StartPopStatus();

                List<CoreClassHandle> l = CoreClassesList();
                context.TheLeader.ProgressStart(l.Count);                

                List<Field> extraFields = new List<Field>();
                if( recall )
                {
                    extraFields.Add(new Field("recall_date", FieldType.DateTime));

                }

                foreach (CoreClassHandle h in l)
                {
                    //the data store is always TheData; that's where the knowlege of the unique id field comes from.
                    //data is the actual data connection
                    
                    DataSql.StructureCheckClass(context, data, h, h.Name, extraFields);
                    context.TheLeader.ProgressAdd();
                }


                //Refactored from SysSensible.cs 12-5-2018
                Core.CoreClassHandle c = context.xSys.CoreClassGet("orddet");
                if (c != null)
                    Core.DataSql.StructureCheckClass(context, c, "orddet_line_canceled");
                c = context.xSys.CoreClassGet("orddet_line");
                if (c != null)
                    Core.DataSql.StructureCheckClass(context, c, "orddet_line_canceled");


                context.TheLeader.Comment("Done.");

                if (!suppress_status)
                    context.TheLeader.StopPopStatus();
            }
            catch (Exception ex)
            {
                context.TheLeader.Error(ex.Message);
            }
        }

        public void RecallActionLog(Core.IItem i, String actionName, n_user u)
        {
            switch (actionName.ToLower().Trim())
            {
                case "":
                case "viewchangehistory":
                case "open":
                    break;
                default:
                    String sql = "insert into " + i.ClassId + " (unique_id, recall_user_name, recall_user_uid, recall_date, recall_machine_name, recall_action_id ) values ('" + i.Uid + "', '" + RecallConnection.Filter(u.name) + "', '" + RecallConnection.Filter(u.unique_id) + "', getdate(), '" + Environment.MachineName + "', '" + RecallConnection.Filter(actionName) + "' )";
                    RecallConnection.ExecuteAsync(sql, "Change tracking action", FailOK: false);
                    break;
            }
        }

        //void MakeRecallActionTableExist(CoreClassAttribute c, nData d)
        //{
        //    String table = c.Name + "_recall_action_log";
        //    if (!d.TableExists(table))
        //    {
        //        d.Execute("create table " + table + " ( unique_id varchar(255), recall_user_name varchar(255), recall_user_id varchar(255), recall_date varchar(255), recall_machine_name varchar(255), action_id varchar(255) )");
        //        d.Execute("create clustered index unique_index on " + table + " (unique_id, recall_date)");
        //    }
        //}

        public virtual void SendNote(ContextNM context, nObject xObject)
        {
        }

        public virtual String InstallFolderPrefix
        {
            get
            {
                return Name;
            }
        }

        public void StructureCheckRecall(ContextNM context)
        {
            List<Field> recallFields = new List<Field>();
            recallFields.Add(new Field("recall_date", FieldType.DateTime));            
            recallFields.Add(new Field("recall_user_uid", FieldType.String, 256));
            recallFields.Add(new Field("recall_user_name", FieldType.String, 256));
            recallFields.Add(new Field("recall_machine_name", FieldType.String, 256));
            recallFields.Add(new Field("recall_type", FieldType.Int32));
            recallFields.Add(new Field("recall_version", FieldType.String, 256));
            recallFields.Add(new Field("recall_uid", FieldType.String, 256));
            recallFields.Add(new Field("recall_action_id", FieldType.String, 256));

            DataSql.StructureCheck(context, RecallConnection, recallFields);
            //DataSql.FieldMaintenance(context, RecallConnection);
        }

        public override void FieldMaintenance(Context x)
        {
            base.FieldMaintenance(x);
            DataConnectionSqlServer connection = (DataConnectionSqlServer)x.Data.Connection;
            foreach (CoreClassHandle h in x.Sys.CoreClassesList())
            {
                if (h.TheAttribute.Abstract)
                    continue;
                if (connection.IsView(h.Name))
                    continue;
                if (Tools.Strings.StrCmp("partrecord", h.Name))
                {
                    if (x.TableExists("shipped_stock"))
                    {
                        h.TheAttribute.Name = "shipped_stock";
                        DataSql.FieldMaintenance(x, connection, h);
                    }
                }
            }


            CoreClassHandle cchh = x.Sys.CoreClassGet("orddet_line");
            DataSql.FieldMaintenance(x, (DataConnectionSqlServer)x.Data.Connection, cchh, "orddet_line_canceled");



            if (Recall)
                DataSql.FieldMaintenance(x, RecallConnection);
               }

        //public virtual nSearch GetSearch(String strClass, String strExtra)
        //{
        //    throw new NotImplementedException("GetSearch not implemented");
        //}
    }
}
