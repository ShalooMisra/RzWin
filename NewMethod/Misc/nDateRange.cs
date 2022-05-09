//using System;
//using System.Collections.Generic;
//using System.Text;
//using Tools.Database;

//namespace NewMethod
//{
//    public class nDateRange
//    {
//        public static String GetSQL(String strField, DateTime start, DateTime end, Enums.ServerTypes type, bool include_time)
//        {
//            switch (type)
//            {
//                case NewMethod.Enums.ServerTypes.MySQL:
//                    if (include_time)
//                    {
//                        throw new NotImplementedException();  //this needs to be handled with options, as with sql server
//                        //return " " + strField + " >= '" + DataConnectionSqlMy.DateFormat(start) + " " + nTools.TimeFormat24(start) + "' and " + strField + " <= '" + DataConnectionSqlMy.DateFormat(end) + " " + nTools.TimeFormat24(end) + "'";
//                    }
//                    else
//                    {
//                        if (!Tools.Dates.DateExists(start))
//                            return " " + strField + " >= '" + DataConnectionSqlMy.DateFormat(DateTime.Parse("01/02/1900")) + " 00:00:00' and " + strField + " <= '" + DataConnectionSqlMy.DateFormat(end) + " 23:59:59'";
//                        else if (!Tools.Dates.DateExists(end))
//                            return " " + strField + " >= '" + DataConnectionSqlMy.DateFormat(start) + " 00:00:00' and " + strField + " <= '" + DataConnectionSqlMy.DateFormat(DateTime.Parse("21/31/9999")) + " 23:59:59'";
//                        else
//                            return " " + strField + " >= '" + DataConnectionSqlMy.DateFormat(start) + " 00:00:00' and " + strField + " <= '" + DataConnectionSqlMy.DateFormat(end) + " 23:59:59'";
//                    }
//                default:
//                    if (include_time)
//                    {
//                        if (!Tools.Dates.DateExists(start))
//                            return " " + strField + " >= '1/2/1900' and " + strField + " <= cast('" + nTools.DateFormat(end) + " " + nTools.TimeFormat24(end) + "' as datetime)";
//                        else if (!Tools.Dates.DateExists(end))
//                            return " " + strField + " >= cast('" + nTools.DateFormat(start) + " " + nTools.TimeFormat24(start) + "' as datetime)";
//                        else
//                            return " " + strField + " between cast('" + nTools.DateFormat(start) + " " + nTools.TimeFormat24(start) + "' as datetime) and cast('" + nTools.DateFormat(end) + " " + nTools.TimeFormat24(end) + "' as datetime)";
//                    }
//                    else
//                    {
//                        if (!Tools.Dates.DateExists(start))
//                            return " " + strField + " between cast('1/2/1900 12:00:00 am' as datetime) and cast('" + nTools.DateFormat(end) + " 11:59:59 pm' as datetime)";
//                        else if (!Tools.Dates.DateExists(end))
//                            return " " + strField + " between cast('" + nTools.DateFormat(start) + " 12:00:00 am' as datetime) and cast('12/31/9999 11:59:59 pm' as datetime)";
//                        else
//                            return " " + strField + " between cast('" + nTools.DateFormat(start) + " 12:00:00 am' as datetime) and cast('" + nTools.DateFormat(end) + " 11:59:59 pm' as datetime)";
//                    }
//            }
//        }
//        public static String GetSQLIncludingTime(String strField, DateTime start, DateTime end)
//        {
//            return " " + strField + " between cast('" + Tools.Dates.DateFormatWithTimeRegardlessOfWindowsSettings(start) + "' as datetime) and cast('" + Tools.Dates.DateFormatWithTimeRegardlessOfWindowsSettings(end) + "' as datetime)";
//        }
//        public static nDateRange Tomorrow
//        {
//            get
//            {
//                DateTime t = DateTime.Now.Add(TimeSpan.FromDays(1));
//                return new nDateRange(t, t);
//            }
//        }
//        public DateTime StartDate;
//        public DateTime EndDate;
//        public bool IncludesTime = false;
//        public nDateRange()
//        {
//            StartDate = Tools.Dates.NullDate;
//            EndDate = Tools.Dates.NullDate;
//        }
//        public nDateRange(DateTime start, DateTime end)
//            : this(start, end, false)
//        {

//        }
//        public nDateRange(DateTime start, DateTime end, bool include_time)
//        {
//            StartDate = start;
//            EndDate = end;
//            IncludesTime = include_time;
//        }
//        public nDateRange(nDateRange d)
//        {
//            StartDate = d.StartDate;
//            EndDate = d.EndDate;
//        }
//        public nDateRange(String startDateString, String endDateString)
//        {
//            StartDate = DateTime.Parse(startDateString);
//            EndDate = DateTime.Parse(endDateString);
//        }
//        public String GetSQL(String strField)
//        {
//            return GetSQL(strField, StartDate, EndDate, Enums.ServerTypes.SQLServer, IncludesTime);
//        }
//        public String GetSQL(String strField, Enums.ServerTypes type)
//        {
//            return GetSQL(strField, StartDate, EndDate, type, IncludesTime);
//        }
//        public String Caption
//        {
//            get
//            {
//                return CaptionCalc("and");
//            }
//        }
//        public String CaptionTo
//        {
//            get
//            {
//                return CaptionCalc("To");
//            }
//        }
//        public bool Valid
//        {
//            get
//            {
//                return Tools.Dates.DateExists(StartDate) || Tools.Dates.DateExists(EndDate);
//            }
//        }
//        String CaptionCalc(String separator)
//        {
//            if (!Valid)
//                return "";

//            if (IncludesTime)
//                return StartDate.ToString() + " " + separator + " " + EndDate.ToString();
//            else
//            {
//                if (!Tools.Dates.DateExists(StartDate))
//                    return "Before " + nTools.DateFormat(EndDate);

//                if (!Tools.Dates.DateExists(EndDate))
//                    return "After " + nTools.DateFormat(StartDate);

//                if (StartDate.Year == EndDate.Year && StartDate.Month == EndDate.Month && StartDate.Day == EndDate.Day)
//                    return nTools.DateFormat(StartDate);
//                else
//                    return nTools.DateFormat(StartDate) + " " + separator + " " + nTools.DateFormat(EndDate);
//            }
//        }
//        public bool IsMonthSpan()
//        {
//            if (!Valid)
//                return false;

//            if (StartDate.Day != 1)
//                return false;
//            if (StartDate.Month != EndDate.Month)
//                return false;
//            if (StartDate.Year != EndDate.Year)
//                return false;

//            return (EndDate.Day == nTools.GetMonthEnd(StartDate).Day);
//        }
//        public bool EndsToday
//        {
//            get
//            {
//                if (!Valid)
//                    return false;

//                TimeSpan t = DateTime.Now.Subtract(EndDate);
//                return Math.Abs(t.TotalDays) < 1;
//            }
//        }
//        public bool IsThisMonthSoFar
//        {
//            get
//            {
//                if (!Valid)
//                    return false;

//                TimeSpan t = nTools.GetMonthStart(DateTime.Now).Subtract(StartDate);
//                if (Math.Abs(t.TotalDays) >= 1)
//                    return false;

//                return EndsToday;
//            }
//        }
//        public bool IsYearToDate
//        {
//            get
//            {
//                nDateRange ytd = YearToDate;
//                return Tools.Dates.IsSameDay(StartDate, ytd.StartDate) && Tools.Dates.IsSameDay(EndDate, ytd.EndDate);
//            }
//        }
//        public bool Includes(DateTime d)
//        {
//            if (!Valid)
//                return false;

//            if (!Tools.Dates.DateExists(d))
//                return false;

//            return (!Tools.Dates.DateExists(StartDate) || d >= StartDate) && (!Tools.Dates.DateExists(EndDate) || d <= EndDate);
//        }
//        public int GetDays()
//        {
//            if (!Valid)
//                throw new Exception("Not a valid range");

//            TimeSpan t = EndDate.Subtract(StartDate);
//            return Convert.ToInt32(t.TotalDays);
//        }
//        public int GetWeekDays()
//        {
//            if (!Valid)
//                throw new Exception("Not a valid range");

//            TimeSpan t = EndDate.Subtract(StartDate);
//            int ds = Convert.ToInt32(t.TotalDays);
//            int r = 0;

//            for (int i = 0; i < ds; i++)
//            {
//                DateTime d = StartDate.Add(TimeSpan.FromDays(i));
//                DayOfWeek dw = d.DayOfWeek;
//                if (dw != DayOfWeek.Saturday && dw != DayOfWeek.Sunday)
//                    r++;
//            }

//            return r;
//        }
//        public static nDateRange ThisMonth
//        {
//            get
//            {
//                return new nDateRange(nTools.GetMonthStart(DateTime.Now), nTools.GetMonthEnd(DateTime.Now));
//            }
//        }
//        public static nDateRange LastMonth
//        {
//            get
//            {
//                DateTime d = Tools.Dates.GetMonthStart(DateTime.Now).Subtract(TimeSpan.FromDays(1));
//                return new nDateRange(nTools.GetMonthStart(d), nTools.GetMonthEnd(d));
//            }
//        }
//        public static nDateRange LastYear
//        {
//            get
//            {
//                DateTime d = new DateTime(DateTime.Now.Year - 1, 1, 1);
//                return new nDateRange(nTools.GetYearStart(d), nTools.GetYearEnd(d));
//            }
//        }
//        public static nDateRange YesterdayThisMonth
//        {
//            get
//            {
//                DateTime TheDate = DateTime.Now.Subtract(TimeSpan.FromDays(1));
//                return new nDateRange(nTools.GetMonthStart(TheDate), nTools.GetMonthEnd(TheDate));
//            }
//        }
//        public void SetStartTime(String s)
//        {
//            StartDate = DateTime.Parse(nTools.DateFormat(StartDate) + " " + s);
//            IncludesTime = true;
//        }
//        public void SetEndTime(String s)
//        {
//            EndDate = DateTime.Parse(nTools.DateFormat(EndDate) + " " + s);
//            IncludesTime = true;
//        }
//        public string GetBetweenSQL()
//        {
//            if (!Tools.Dates.DateExists(StartDate))
//                return " between cast('1/2/1900 00:00:00' as datetime) and cast('" + EndDate.ToShortDateString() + " 23:59:59' as datetime) ";
//            else if (!Tools.Dates.DateExists(EndDate))
//                return " between cast('" + StartDate.ToShortDateString() + " 00:00:00' as datetime) and cast('12/31/9999 23:59:59' as datetime) ";
//            else
//                return " between cast('" + StartDate.ToShortDateString() + " 00:00:00' as datetime) and cast('" + EndDate.ToShortDateString() + " 23:59:59' as datetime) ";
//        }
//        public static nDateRange YearToDate
//        {
//            get
//            {
//                return new nDateRange(Tools.Dates.GetYearStart(DateTime.Now), DateTime.Now);
//            }
//        }
//        public static nDateRange MonthToDate
//        {
//            get
//            {
//                return new nDateRange(Tools.Dates.GetMonthStart(DateTime.Now), DateTime.Now);
//            }
//        }
//        public static nDateRange Today
//        {
//            get
//            {
//                return new nDateRange(DateTime.Now, DateTime.Now);
//            }
//        }
//        public static nDateRange None
//        {
//            get
//            {
//                return new nDateRange(Tools.Dates.NullDate, Tools.Dates.NullDate);
//            }
//        }
//    }
//}
