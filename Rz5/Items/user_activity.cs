//using System;
//using System.Collections.Generic;
//using System.Collections;
//using System.Text;
//using System.Data;
//using System.Threading;

//using NewMethod;
//using Tie;
//using Tools.Database;
//using Core;

//namespace Rz4
//{
//    public partial class user_activity : user_activity_auto
//    {
//        public override string ToString()
//        {
//            return name + " " + activity_type + " " + description;
//        }


//        public bool IsToday
//        {
//            get
//            {
//                return (date_created.Year == DateTime.Now.Year) && (date_created.Month == DateTime.Now.Month) && (date_created.Day == DateTime.Now.Day);
//            }
//        }

//        public static void AddActivity(ContextRz x, String strName, String strDescription, companycontact c)
//        {

//            user_activity a = user_activity.New(x);
//            a.the_n_user_uid = x.xUser.unique_id;
//            a.user_name = x.xUser.name;
//            a.name = strName;
//            a.description = strDescription;
//            a.instance_id = x.Logic.InstanceID;

//            if (c != null)
//            {
//                a.the_companycontact_uid = c.unique_id;
//                a.contact_caption = c.ToString();
//            }

//            x.Insert(a);
//        }

//        public static DataConnectionSqlServer ActivityData = null;
//        public static bool TrackActivity = true;
//        //public static ArrayList ActivityThreads = new ArrayList();

//        public static void AddActivity(ContextRz context, String strName, String strDescription, String strType, Double dblValue, nObject x)
//        {
//            AddActivity(context, context.xUser.unique_id, strName, strDescription, strType, dblValue, x);
//        }
//        public static void AddActivity(ContextRz context, String strUserID, String strName, String strDescription, String strType, Double dblValue, nObject xObject)
//        {
//            try
//            {
//                ArrayList a = new ArrayList();
//                a.Add(xObject);
//                AddActivity(context, strUserID, strName, strDescription, strType, dblValue, a);
//            }
//            catch { }
//        }
//        public static void AddActivity(ContextRz context, String strUserID, String strName, String strDescription, String strType, Double dblValue, ArrayList objects)
//        {
//            context.Reorg();
//            try
//            {

//                if (!TrackActivity)
//                    return;

//                user_activity a = user_activity.New(context);
//                a.the_n_user_uid = strUserID;
//                a.user_name = context.xSys.TranslateUserIDToName(strUserID);
//                a.name = strName;
//                a.description = strDescription;
//                a.activity_type = strType;
//                a.activity_value = dblValue;
//                a.date_created = DateTime.Now;  //needed because its used before its saved
//                a.date_modified = DateTime.Now;
//                a.unique_id = Tools.Strings.GetNewID();
//                a.instance_id = context.Logic.InstanceID;

//                foreach (nObject x in objects)
//                {
//                    if (x != null)
//                    {
//                        if (a.link_list != "")
//                            a.link_list += "\r\n";
//                        a.link_list += x.ClassId + ":" + x.unique_id + ":" + x.ToString();
//                    }
//                }

//                //Rz3App.xHook.HandleActivity(a);

//                Thread t = new Thread(new ParameterizedThreadStart(ActuallyAddActivity));
//                t.SetApartmentState(ApartmentState.STA);

//                //lock(ActivityThreads.SyncRoot)
//                //{
//                //    ActivityThreads.Add(t);
//                //}

//                ActivityParameters p = new ActivityParameters();
//                p.TheContext = context;
//                p.TheActivity = a;
//                t.Start(p);
//            }
//            catch { }
//        }

//        public static ArrayList ActivityTableNames = new ArrayList();
//        public static void ActuallyAddActivity(Object x)
//        {

//            try
//            {
//                ContextRz context = ((ActivityParameters)x).TheContext;
//                user_activity a = ((ActivityParameters)x).TheActivity;

//                CheckActivityData(context);
//                if (!TrackActivity)
//                    return;

//                String strTable = GetActivityTableName(a.the_n_user_uid);
//                bool clearandcreate = false;
//                lock (ActivityTableNames)
//                {
//                    if (!ActivityTableNames.Contains(strTable))
//                    {
//                        clearandcreate = true;
//                        ActivityTableNames.Add(strTable);
//                    }
//                }

//                if (clearandcreate)
//                {
//                    CoreClassAttribute c = context.xSys.GetClassByName("user_activity");
//                    if (c == null)
//                        return;

//                    if (!context.xSys.MakeClassDataStructure(c, ActivityData, false, strTable))
//                        return;

//                    ClearPastTables(context, a.the_n_user_uid);
//                }

//                String s = a.BuildSaveSQL(context, strTable);
//                ActivityData.Execute(s, true);

//                if (context.xHook.IsConnected())
//                {
//                    TieMessage m = new TieMessage("<UserID=" + context.xUser.unique_id + ", MachineID=" + context.xHook.MachineID + ">", "user_activity", "<all>");

//                    StringBuilder sb = new StringBuilder();
//                    sb.Append(Tools.Xml.BuildXmlProp("ActivityID", a.unique_id));
//                    sb.Append(Tools.Xml.BuildXmlProp("ActivityUserID", a.the_n_user_uid));
//                    m.ContentString = sb.ToString();
//                    context.xHook.Send(m);
//                }
//            }
//            catch { }
//        }

//        public static void CheckActivityData(ContextNM x)
//        {
//            if (ActivityData == null)
//            {
//                //ActivityData = x.xSys.GetCubeData();
//                if (ActivityData == null)
//                {
//                    TrackActivity = false;
//                    return;
//                }

//                if (!ActivityData.ConnectPossible())
//                {
//                    TrackActivity = false;
//                    return;
//                }
//            }
//        }

//        public static String GetActivityTableName(String strUserID)
//        {
//            return GetActivityTableName(strUserID, DateTime.Now);
//        }
//        public static String GetActivityTableName(String strUserID, DateTime d)
//        {
//            return "user_activity_" + Tools.Strings.FilterTrash(strUserID).Replace("_", "") + "_year_" + d.Year.ToString() + "_month_" + d.Month.ToString() + "_day_" + d.Day.ToString();
//        }

//        public static void ClearPastTables(ContextNM x, String strUserID)
//        {
//            x.Reorg();
//            //String strLook = "user_activity_" + Tools.Strings.FilterTrash(strUserID) + "_";
//            //ArrayList a = ActivityData.GetScalarArray("select name from sysobjects where left(name, " + strLook.Length.ToString() + ") = '" + strLook + "'");
//            //n_class c = x.xSys.GetClassByName("user_activity");
//            //foreach (String s in a)
//            //{
//            //    try
//            //    {
//            //        String[] ary = Tools.Strings.Split(s, "_");
//            //        int year = Int32.Parse(ary[4]);
//            //        int month = Int32.Parse(ary[6]);
//            //        int day = Int32.Parse(ary[8]);
//            //        DateTime d = new DateTime(year, month, day);
//            //        TimeSpan t = DateTime.Now.Subtract(d);
//            //        if (t.TotalDays > 10)
//            //        {
//            //            ActivityData.DropTable(s);
//            //        }
//            //        else
//            //        {
//            //            if (c != null)
//            //            {
//            //                //update it so that ICreate won't fail if fields are added
//            //                x.xSys.MakeClassDataStructure(c, ActivityData, false, s);
//            //            }
//            //        }
//            //    }
//            //    catch{}
//            //}
//        }

//        public static user_activity GetByIDAndUser(ContextNM x, String strActivityID, String strUserID)
//        {
//            try
//            {
//                CheckActivityData(x);
//                if (!TrackActivity)
//                    return null;

//                DataTable d = ActivityData.GetDataTable("select * from " + GetActivityTableName(strUserID) + " where unique_id = '" + strActivityID + "'", true);
//                if (!Tools.Data.DataTableExists(d))
//                    return null;

//                user_activity a = user_activity.New(x);
//                a.AbsorbRow(x, d.Rows[0]);
//                return a;
//            }
//            catch { return null; }
//        }

//        public static ArrayList GetByUser(ContextNM x, String strUserID, DateTime when)
//        {
//            ArrayList ret = new ArrayList();
//            try
//            {
//                CheckActivityData(x);
//                if (!TrackActivity)
//                    return ret;
//                DataTable d = ActivityData.GetDataTable("select * from " + GetActivityTableName(strUserID, when) + " order by date_created", true);
//                if (!Tools.Data.DataTableExists(d))
//                    return ret;
//                foreach (DataRow r in d.Rows)
//                {
//                    user_activity a = user_activity.New(x);
//                    a.AbsorbRow(x, r);
//                    ret.Add(a);
//                }
//            }
//            catch { return null; }
//            return ret;
//        }
//    }

//    public delegate void ActivityMonitorHandler(user_activity a);
//    public interface IActivityMonitor
//    {
//        void ActuallyHandleActivity(user_activity a);
//        object Invoke(Delegate method, params object[] args);
//    }

//    public class ActivityParameters
//    {
//        public ContextRz TheContext;
//        public user_activity TheActivity;
//    }
//}
