using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Drawing;
using NewMethod;

namespace Rz5
{
    public partial class virtual_desk : virtual_desk_auto
    {
        //public ArrayList RecentActivity = new ArrayList();
        //public DateTime ActivityDay = DateTime.Now;
        //public DateTime LastActivity = Tools.Dates.GetNullDate();

        //public Dictionary<String, ActivityHandle> Activities;
        //public List<TimeSlice> TimeSlices;

        //public void GatherRecentActivity(ContextNM x)
        //{
        //    TimeSlices = new List<TimeSlice>();
        //    for (int i = 0; i < 120; i++)
        //    {
        //        TimeSlices.Add(new TimeSlice());
        //    }
        //    Activities = new Dictionary<string, ActivityHandle>();
        //    switch (JobType)
        //    {
        //        case JobType.Sales:
        //            Activities.Add("phonecall", new ActivityHandle("Phone Time", "phonecall", FieldType.Int64, NewMethod.Enums.CubeDataDisplayType.Seconds));
        //            Activities.Add("soldprofit", new ActivityHandle("Profit Sold", "soldprofit", FieldType.Double, NewMethod.Enums.CubeDataDisplayType.BigDollars));
        //            Activities.Add("shippedprofit", new ActivityHandle("Profit Shipped", "shippedprofit", FieldType.Double, NewMethod.Enums.CubeDataDisplayType.BigDollars));
        //            break;
        //        case JobType.Warehouse:
        //            Activities.Add("pick", new ActivityHandle("Lines Picked", "pick", FieldType.Int64, NewMethod.Enums.CubeDataDisplayType.Any));
        //            Activities.Add("receive", new ActivityHandle("Lines Received", "receive", FieldType.Int64, NewMethod.Enums.CubeDataDisplayType.Any));
        //            break;
        //        case JobType.Accounting:
        //            Activities.Add("qbtransfer", new ActivityHandle("QB Transfers", "qbtransfer", FieldType.Int64, NewMethod.Enums.CubeDataDisplayType.Any));
        //            break;
        //    }

        //    DateTime d = DateTime.Now.Subtract(TimeSpan.FromDays(1));
        //    AddActivity(user_activity.GetByUser(x, the_n_user_uid, d));
        //    AddActivity(user_activity.GetByUser(x, the_n_user_uid, DateTime.Now));
        //}

        //public int CalculateX(int width)
        //{
        //    return Convert.ToInt32(width * (Convert.ToDouble(x_location) / 100));
        //}

        //public int CalculateY(int height)
        //{
        //    return Convert.ToInt32(height * (Convert.ToDouble(y_location) / 100));
        //}

        //public void SavePosition(int width, int height, int x, int y)
        //{
        //    x_location = nTools.CalcPercent(width, x);
        //    y_location = nTools.CalcPercent(height, y);
        //    ISave();
        //}

        //public void AddActivity(ArrayList all)
        //{
        //    foreach (user_activity a in all)
        //    {
        //        AddActivity(a);
        //    }
        //}

        //public void AddActivity(user_activity a)
        //{
        //    if ((a.date_created.Year > ActivityDay.Year) || (a.date_created.Month > ActivityDay.Month) || (a.date_created.Day > ActivityDay.Day))
        //    {
        //        ActivityDay = DateTime.Now;
        //        ClearValues();
        //    }

        //    if (a.activity_type != "phonecall")
        //    {
        //        ;
        //    }

        //    RecentActivity.Add(a);
        //    if (a.IsToday)
        //    {
        //        if (Activities.ContainsKey(a.activity_type.ToLower()))
        //        {
        //            ActivityHandle h = Activities[a.activity_type.ToLower()];
        //            h.Value += a.activity_value;
        //            h.TodaysActivities.Add(a);
        //        }
        //    }

        //    switch (a.activity_type.ToLower())
        //    {
        //        case "shippedprofit":
        //            break;
        //        default:
        //            if (a.date_created > LastActivity)
        //                LastActivity = a.date_created;

        //            if (a.IsToday)
        //            {
        //                TimeSpan t = a.date_created.Subtract(new DateTime(a.date_created.Year, a.date_created.Month, a.date_created.Day, 7, 0, 0));
        //                int slot = Convert.ToInt32(t.TotalMinutes) / 6;
        //                if (slot >= 0 && slot < TimeSlices.Count)
        //                    TimeSlices[slot].Value++;
        //            }

        //            break;
        //    }
        //}

        //public JobType JobType
        //{
        //    get
        //    {
        //        switch (job_desc.ToLower())
        //        {
        //            case "warehouse":
        //                return JobType.Warehouse;
        //            case "accounting":
        //                return JobType.Accounting;
        //            default:
        //                return JobType.Sales;
        //        }
        //    }

        //    set
        //    {
        //        job_desc = value.ToString();
        //        ISave();
        //    }
        //}

        //public void ClearValues()
        //{
        //    foreach (TimeSlice t in TimeSlices)
        //    {
        //        t.Value = 0;

        //    }

        //    foreach (KeyValuePair<String, ActivityHandle> kvp in Activities)
        //    {
        //        kvp.Value.Value = 0;
        //        kvp.Value.TodaysActivities.Clear();
        //    }
        //}
    }

    //public class ActivityHandle
    //{
    //    public String Caption = "";
    //    public Double Value = 0;
    //    public String Key = "";
    //    public NewMethod.Enums.DataType ValueType;
    //    public NewMethod.Enums.CubeDataDisplayType ValueDisplay = NewMethod.Enums.CubeDataDisplayType.Any;
    //    public ArrayList TodaysActivities = new ArrayList();

    //    public ActivityHandle(String caption, String key, NewMethod.Enums.DataType valuetype, NewMethod.Enums.CubeDataDisplayType valuedisplay)
    //    {
    //        Caption = caption;
    //        Key = key;
    //        ValueType = valuetype;
    //        ValueDisplay = valuedisplay;
    //    }

    //    public nCubeSummary GetTodaysSummary()
    //    {
    //        nCubeSummary sum = new nCubeSummary();
    //        nCubeSeries ser = new nCubeSeries();
    //        ser.Name = Caption;
    //        ser.DisplayType = ValueDisplay;
    //        ser.xStyle = new nCubeSummaryStyle();
    //        //ser.xStyle.SeriesType = Dundas.Charting.WinControl.SeriesChartType.Line;
    //        ser.xStyle.Color = Color.Blue;
    //        sum.Series.Add(ser);

    //        int mark = 0;
    //        int placeholder = 0;
    //        Double total = 0;
    //        DateTime seven = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 0, 0);
    //        for (int i = 1; i <= 720; i++)
    //        {
    //            DateTime xd = seven.Add(TimeSpan.FromMinutes(i));
    //            for (int p = placeholder; p < TodaysActivities.Count; p++)
    //            {
    //                user_activity a = (user_activity)TodaysActivities[p];

    //                if (a.date_created < xd)
    //                {
    //                    total += a.activity_value;
    //                    placeholder++;
    //                }
    //                else
    //                {
    //                    break;
    //                }
    //            }


    //            if (mark >= 29)
    //            {
    //                nCubePoint p = new nCubePoint();
    //                p.Value = total;

    //                p.Name = nTools.TimeFormat(xd);
    //                mark = 0;
    //                ser.AllPoints.Add(p);
    //            }
    //            else
    //                mark++;

    //            if (xd > DateTime.Now)
    //                break;
    //        }

    //        return sum;
    //    }
    //}

    public class TimeSlice
    {
        public int Value = 0;
        public Color Color
        {
            get
            {
                switch (Value)
                {
                    case 0:
                        return Color.White;
                    case 1:
                        return Color.LightBlue;
                    case 2:
                        return Color.Blue;
                    case 3:
                        return Color.BlueViolet;
                    case 4:
                        return Color.Navy;
                    case 5:
                        return Color.DarkBlue;
                    default:
                        return Color.Red;
                }
            }
        }
    }

    public enum JobType
    {
        Sales = 0,
        Warehouse = 1,
        Accounting = 2,
    }

}
