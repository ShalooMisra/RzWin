using System;
using System.Collections;
using System.Text;
using System.Data;

namespace NewMethod
{
    public partial class nCube
    {
        //old style
        public static void CubeATable(ContextNM x, String strTable, String strName, String strDateField, String strVolumeField, String strUserIDField)
        {
            DateTime LastCubeDate;
            TimeSpan t;

            x.TheLeader.StartPopStatus();
            x.TheLeader.Comment("Cubing " + strTable);

            LastCubeDate = n_set.GetSetting_Date(x, "last_cube_date_byday_" + strName + "_" + strTable);
            t = DateTime.Now.Subtract(LastCubeDate);
            if (t.TotalHours > 0)
                CubeATable_Day(x, strTable, strName, strDateField, strVolumeField, strUserIDField);

            x.TheLeader.Comment("Done.");
            x.TheLeader.StopPopStatus();
        }

        //old style
        public static void CubeATable_Day(ContextNM x, String strTable, String strName, String strDateField, String strVolumeField, String strUserIDField)
        {
            String strTempTable;

            DateTime LastCubeDate = n_set.GetSetting_Date(x, "last_cube_date_byday_" + strName + "_" + strTable);
            if (Tools.Dates.DateExists(LastCubeDate))
            {
                LastCubeDate.Subtract(TimeSpan.FromDays(1));
            }

            LastCubeDate = nTools.GetDayStart(LastCubeDate);

            strTempTable = "temp_cube_" + strName + "_" + strTable;
            x.TheData.TheConnection.DropTable(strTempTable);

            x.TheLeader.Comment("Selecting new data...");
            if (Tools.Dates.DateExists(LastCubeDate))
                x.Execute("select * into " + strTempTable + " from " + strTable + " where " + strDateField + " > cast('" + LastCubeDate.ToString() + "' as datetime)");
            else
                x.Execute("select * into " + strTempTable + " from " + strTable);

            n_set.SetSetting_Date(x, "last_cube_date_byday_" + strName + "_" + strTable, DateTime.Now);

            //split up the dates
            //context.TheLeader.Comment("Searching dates...");
            x.Execute("alter table " + strTempTable + " add unique_year int, unique_month int, unique_day int, unique_hour int");
            x.Execute("update " + strTempTable + " set unique_year = datepart(year, " + strDateField + ")");
            x.Execute("update " + strTempTable + " set unique_month = datepart(month, " + strDateField + ")");
            x.Execute("update " + strTempTable + " set unique_day = datepart(day, " + strDateField + ")");
            x.Execute("update " + strTempTable + " set unique_hour = datepart(hour, " + strDateField + ")");

            //get all of the days involved in the entire table
            DataTable dx = x.Select("select distinct(unique_year) from " + strTempTable + " order by unique_year");

            if (nTools.DataTableExists(dx))
            {
                //nStatus.UpChannel();
                //context.TheLeader.StartPercent(dx.Rows.Count);
                foreach (DataRow rx in dx.Rows)
                {
                    DataTable dy = x.Select("select distinct(unique_month) from " + strTempTable + " where unique_year = " + rx["unique_year"].ToString() + " order by unique_month");
                    if (nTools.DataTableExists(dy))
                    {
                        //nStatus.UpChannel();
                        //context.TheLeader.StartPercent(dy.Rows.Count);
                        foreach (DataRow ry in dy.Rows)
                        {
                            DataTable dz = x.Select("select distinct(unique_day) from " + strTempTable + " where unique_year = " + rx["unique_year"].ToString() + " and unique_month = " + ry["unique_month"].ToString() + " order by unique_day");
                            if (nTools.DataTableExists(dz))
                            {
                                //nStatus.UpChannel();
                                //context.TheLeader.StartPercent(dz.Rows.Count);
                                foreach (DataRow rz in dz.Rows)
                                {
                                    String strCubeTable = "cube_" + strName + "_" + strTable + "_byday_" + Tools.Strings.Right("0000" + rx[0].ToString(), 4) + "_" + Tools.Strings.Right("00" + ry[0].ToString(), 2) + "_" + Tools.Strings.Right("00" + rz[0].ToString(), 2);
                                    //context.TheLeader.Comment("Filling " + strCubeTable + "...");

                                    //delete the table if it is already there
                                    x.TheData.TheConnection.DropTable(strCubeTable);

                                    //create the new table
                                    //insert the totals for every user

                                    //xData.DoExecute "select distinct( " & strUserIDField & " ) as base_mc_user_uid into " & strCubeTable & " from " & strTable & " where unique_year = " & Trim(CStr(xAction.Fields("unique_year").Value)) & " and unique_month = " & Trim(CStr(yAction.Fields("unique_month").Value)) & " and unique_day = " & Trim(CStr(yAction.Fields("unique_day").Value))
                                    x.Execute("select " + strUserIDField + " as base_mc_user_uid, sum(" + strVolumeField + ") as total_volume, count(unique_id) as total_count, unique_hour as hour_index into " + strCubeTable + " from " + strTempTable + " where isnull(" + strUserIDField + ", '') > '' and unique_year = " + rx["unique_year"].ToString() + " and unique_month = " + ry["unique_month"].ToString() + " and unique_day = " + rz[0].ToString() + "  group by " + strUserIDField + ", unique_hour");
                                    //context.TheLeader.AddPercent();
                                }
                                //nStatus.DownChannel();
                            }
                            //context.TheLeader.AddPercent();
                        }
                        //nStatus.DownChannel();
                    }
                    //context.TheLeader.AddPercent();
                }
                //nStatus.DownChannel();
            }
        }

        //old style
        public static ArrayList OrderByVolume(ContextNM context, ArrayList x, String strTable)
        {
            String strTemp = "temp_" + Tools.Strings.GetNewID();
            context.Execute("create table " + strTemp + "( total_volume int, base_mc_user_uid varchar(50))");
            foreach (String s in x)
            {
                context.Execute("insert into " + strTemp + "( total_volume, base_mc_user_uid ) values ( 0, '" + context.TheData.Filter(s) + "')");
            }
            context.Execute("update " + strTemp + " set total_volume = (select sum(total_volume) from " + strTable + " where base_mc_user_uid = " + strTemp + ".base_mc_user_uid)");
            ArrayList r = context.TheData.SelectScalarArray("select base_mc_user_uid from " + strTemp + " order by total_volume desc");
            context.Execute("drop table " + strTemp);
            return r;
        }
    }
}