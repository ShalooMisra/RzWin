using System;
using System.Collections.Generic;
using System.Text;
using Tools.Database;

namespace Tools
{
    public partial class Dates
    {
        //Public Static Functions

        public static int HoursElapsedBusiness(DateTime start, DateTime end)
        {
            DateTime s = start;
            int hours = 0;
            while (s < end)
            {
                if (s.DayOfWeek != DayOfWeek.Saturday && s.DayOfWeek != DayOfWeek.Sunday)
                {
                    if (s.Hour >= 8 && s.Hour <= 16)
                    {
                        hours++;
                    }
                }

                s += TimeSpan.FromHours(1);
            }
            return hours;
        }

        public static DateTime AddWorkingDays(DateTime d, int add)
        {
            DateTime ret = d;
            int dx = 0;
            while (dx < add)
            {
                ret = ret.AddDays(1);
                switch (ret.DayOfWeek)
                {
                    case DayOfWeek.Saturday:
                    case DayOfWeek.Sunday:
                        continue;
                    default:

                        //holidays?

                        dx++;
                        break;
                }
            }
            return ret;
        }

        public static bool IsSameDay(DateTime d1, DateTime d2)
        {
            return (d1.Year == d2.Year) && (d1.Month == d2.Month) && (d1.Day == d2.Day);
        }

        public static bool IsLaterDay(DateTime possiblyLaterDate, DateTime compareDate)
        {
            return Tools.Dates.GetDayStart(possiblyLaterDate) > Tools.Dates.GetDayEnd(compareDate);  //if the very start of the second day is later than the end of the first day, its later
        }

        public static bool IsEarlierDay(DateTime possiblyEarlierDate, DateTime compareDate)
        {
            return Tools.Dates.GetDayEnd(possiblyEarlierDate) < Tools.Dates.GetDayStart(compareDate);  //if the very end of the first day is earlier than the start of the second day, its earlier
        }

        public static DateTime GetBlankDate()
        {
            return NullDate;
        }
        public static bool DateExists(DateTime d)
        {
            if( d == null )
                return false;
            return d > Tools.Dates.NullDateCompare;
        }
        public static String DateFormat(DateTime d)
        {
            if( Dates.DateExists(d) )
                return String.Format("{0:d}", d);
            else
                return "";
        }
        public static String TimeFormat(DateTime d)
        {
            if( Dates.DateExists(d) )
                return String.Format("{0:t}", d);
            else
                return "";
        }
        public static String TimeFormat24(DateTime d)
        {
            if (Dates.DateExists(d))
                return d.ToString("HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            else
                return "";
        }
        public static String TimeFormat24NoSeconds(DateTime d)
        {
            if (Dates.DateExists(d))
                return d.ToString("HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            else
                return "";
        }
        public static String TimeFormat_WithSeconds(DateTime d)
        {
            if( Dates.DateExists(d) )
                return String.Format("{0:T}", d);
            else
                return "";
        }
        public static String DateFormat_ShortDateTime(DateTime d)
        {
            if( Dates.DateExists(d) )
                return String.Format("{0:g}", d);
            else
                return "";
        }

        public static String DateFormatShortDateHour(DateTime d)
        {
            if (!Tools.Dates.DateExists(d))
                return "";

            String ret = d.Month.ToString() + "/" + d.Day.ToString() + " ";
            if (d.Hour == 12)
                ret += "12PM";
            else if( d.Hour == 0 )
                ret += "12AM";
            else if (d.Hour > 12)
                ret += (d.Hour - 12).ToString() + "PM";
            else
                ret += d.Hour.ToString() + "AM";
            return ret;
        }
        public static String DateFormatShortDateHourMinutes(DateTime d)
        {
            if (!Tools.Dates.DateExists(d))
                return "";

            String min = Tools.Strings.Right("0" + d.Minute.ToString(), 2);

            String ret = d.Month.ToString() + "/" + d.Day.ToString() + " ";
            if (d.Hour == 12)
                ret += "12:" + min + "PM";
            else if( d.Hour == 0 )
                ret += "12:" + min + "AM";
            else if (d.Hour > 12)
                ret += (d.Hour - 12).ToString() + ":" + min + "PM";
            else
                ret += d.Hour.ToString() + ":" + min + "AM";
            return ret;
        }

        public static String DateFormatShortDateHourMinutes24(DateTime d)
        {
            if (!Tools.Dates.DateExists(d))
                return "";

            String min = Tools.Strings.Right("0" + d.Minute.ToString(), 2);
            return d.Month.ToString() + "/" + d.Day.ToString() + " " + d.Hour.ToString() + ":" + min;
        }

        public static String DateFormat_Extra(DateTime d)
        {
            String strExtra = "";
            if( d > System.DateTime.Now )
                return Dates.DateFormat(d);
            TimeSpan t = System.DateTime.Now.Subtract(d);
            if( t.Days <= 0 )
                strExtra = " (today)";
            else if( t.Days <= 0 )
                strExtra = " (yesterday)";
            else if( t.Days < 100 )
                strExtra = " (" + t.Days.ToString() + " days ago)";
            else
                strExtra = "";
            return Dates.DateFormat(d) + strExtra;
        }

        public static string GetNowPathHMS()
        {
            return PathYMDHMS(DateTime.Now);
        }

        public static String PathYMDHMS(DateTime date)
        {
            String s = date.Year.ToString() + "_";

            if (date.Month <= 9)
                s += "0" + date.Month.ToString();
            else
                s += date.Month.ToString();

            s += "_";

            if (date.Day <= 9)
                s += "0" + date.Day.ToString();
            else
                s += date.Day.ToString();

            s += "_";

            if (date.Hour <= 9)
                s += "0" + date.Hour.ToString();
            else
                s += date.Hour.ToString();

            s += "_";

            if (date.Minute <= 9)
                s += "0" + date.Minute.ToString();
            else
                s += date.Minute.ToString();

            s += "_";

            if (date.Second <= 9)
                s += "0" + date.Second.ToString();
            else
                s += date.Second.ToString();

            return s;
        }

        public static String PathYMDHMSM(DateTime date)
        {
            String s = date.Year.ToString() + "_";

            if (date.Month <= 9)
                s += "0" + date.Month.ToString();
            else
                s += date.Month.ToString();

            s += "_";

            if (date.Day <= 9)
                s += "0" + date.Day.ToString();
            else
                s += date.Day.ToString();

            s += "_";

            if (date.Hour <= 9)
                s += "0" + date.Hour.ToString();
            else
                s += date.Hour.ToString();

            s += "_";

            if (date.Minute <= 9)
                s += "0" + date.Minute.ToString();
            else
                s += date.Minute.ToString();

            s += "_";

            if (date.Second <= 9)
                s += "0" + date.Second.ToString();
            else
                s += date.Second.ToString();

            s += "_" + Tools.Strings.Right("000" + date.Millisecond.ToString(), 3);

            return s;
        }

        public static DateTime ParseDateYMDHMSM(String dateString)
        {
            String[] split = dateString.Split("_".ToCharArray());
            return new DateTime(Int32.Parse(split[0]), Int32.Parse(split[1]), Int32.Parse(split[2]), Int32.Parse(split[3]), Int32.Parse(split[4]), Int32.Parse(split[5]), Int32.Parse(split[6]));
        }

        public static DateTime ParseDateYMDHMS(String dateString)
        {
            String[] split = dateString.Split("_".ToCharArray());
            return new DateTime(Int32.Parse(split[0]), Int32.Parse(split[1]), Int32.Parse(split[2]), Int32.Parse(split[3]), Int32.Parse(split[4]), Int32.Parse(split[5]));
        }

        public static DateTime BuildDate_YM(int year, int month)
        {
            try
            {
                return DateTime.Parse(month.ToString() + "/01/" + year.ToString());
            }
            catch(Exception)
            {
                return Dates.GetNullDate();
            }
        }

        public static DateTime NullDate = new DateTime(1900, 1, 1, 00, 00, 00);
        public static DateTime NullDateCompare = new DateTime(1900, 1, 2, 00, 00, 00);
        public static DateTime GetNullDate()
        {
            return NullDate;
        }
        public static DateTime ParseDate_YYYY_MM_DD(String s)
        {
            try
            {
                String[] ary = Tools.Strings.Split(s, "_");
                int year = Int32.Parse(ary[0]);
                int month = Int32.Parse(ary[1]);
                int day = Int32.Parse(ary[2]);
                return new DateTime(year, month, day);
            }
            catch(Exception)
            {
                return GetNullDate();
            }
        }
        public static String FormatHMS(int seconds)
        {
            return FormatHMS(Convert.ToInt64(seconds));
        }
        public static String FormatHMS(Double seconds)
        {
            return FormatHMS(Convert.ToInt64(seconds));
        }
        public static String FormatHMS(long seconds)
        {
            TimeSpan t = new TimeSpan(0, 0, Convert.ToInt32(seconds));
            String s = Tools.Strings.Right("00" + t.Minutes.ToString(), 2) + ":" + Tools.Strings.Right("00" + t.Seconds.ToString(), 2);
            if (t.Hours <= 0)
                return s;
            else
            {
                int hrs = t.Hours;
                if (t.Days > 0)
                    hrs += t.Days * 24;
                return Tools.Strings.Right("00" + hrs.ToString(), 2) + ":" + s;
            }
        }
        public static String FormatHM(long seconds)
        {
            TimeSpan t = new TimeSpan(0, 0, Convert.ToInt32(seconds));
            String s = Tools.Strings.Right("00" + t.Minutes.ToString(), 2);
            if( t.Hours <= 0 )
                return "0:" + s;
            else
                return t.Hours.ToString() + ":" + s;
        }
        public static String FormatDHMS(Double seconds)
        {
            return FormatDHMS(Convert.ToInt64(seconds));
        }

        public static String FormatDHM(int minutes)
        {
            TimeSpan t = new TimeSpan(0, minutes, 0);
            String s = "";
            if( t.Days > 0 )
                s += Convert.ToInt32(t.Days).ToString() + "d ";

            s += Tools.Strings.Right("00" + t.Hours.ToString(), 2) + ":" + Tools.Strings.Right("00" + t.Minutes.ToString(), 2);
            return s;
        }

        public static String FormatDHMLetter(int minutes)
        {
            TimeSpan t = new TimeSpan(0, minutes, 0);
            String s = "";
            if (t.Days > 0)
                s += Convert.ToInt32(t.Days).ToString() + "d ";

            if( t.Hours > 0 )
                s += t.Hours.ToString() + "h ";

            s += t.Minutes + "m";
            return s;
        }

        public static String FormatDHMS(long seconds)
        {
            TimeSpan t = new TimeSpan(0, 0, Convert.ToInt32(seconds));
            String s = "";
            if( t.Days > 0 )
                s += Convert.ToInt32(t.Days).ToString() + "d ";
            if( t.Hours > 0 )
                s += Tools.Strings.Right("00" + t.Hours.ToString(), 2) + ":";
            s += Tools.Strings.Right("00" + t.Minutes.ToString(), 2) + ":" + Tools.Strings.Right("00" + t.Seconds.ToString(), 2);
            return s;
        }
        public static DateTime GetRandomDate()
        {
            return RandomProvider.Next(DateTime.Now.Subtract(new TimeSpan(36500, 0, 0, 0)), DateTime.Now.Add(new TimeSpan(36500, 0, 0, 0)));
        }
        public static DateTime GetDate_ThisMonthStart()
        {
            return DateTime.Parse(DateTime.Now.Month.ToString() + "/01/" + DateTime.Now.Year.ToString());
        }
        public static String GetDateTimeString()
        {
            return DateTime.Now.Year.ToString() + "_" + Tools.Number.PadTwoDigits(DateTime.Now.Month.ToString()) + "_" + Tools.Number.PadTwoDigits(DateTime.Now.Day.ToString()) + "_" + Tools.Number.PadTwoDigits(DateTime.Now.Hour.ToString()) + "_" + Tools.Number.PadTwoDigits(DateTime.Now.Minute.ToString()) + "_" + Tools.Number.PadTwoDigits(DateTime.Now.Second.ToString());
        }
        public static bool IsDate(String s)
        {
            if( s == null )
                return false;
            if( !Tools.Strings.StrExt(s) )
                return false;
            try
            {
                DateTime d = DateTime.Parse(s);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        public static DateTime ConcatDateTime(DateTime d, String strTime)
        {
            try
            {
                return DateTime.Parse(Dates.DateFormat(d) + " " + strTime);
            }
            catch(Exception)
            {
                return d;
            }
        }
        public static String DateFormatWithTime(DateTime d)
        {
            return d.ToString();
        }

        public static String DateFormatWithTimeRegardlessOfWindowsSettings(DateTime d)
        {
            if (!Tools.Dates.DateExists(d))
                d = new DateTime(1900, 1, 1);

            int hour = d.Hour;
            String ampm = " AM";
            if (hour > 12)
            {
                hour -= 12;
                ampm = " PM";
            }
            else if (hour == 12) //AAAAAAAAA this was missing 2012_02_03
            {
                ampm = " PM";
            }
            else if (hour == 0)
            {
                hour = 12;
                ampm = " AM";
            }

            //2012_02_13  wow.  below used to be d.Hour.ToString, even with all of the above

            return DateFormatRegardlessOfWindowsSettings(d) + " " + hour + ":" + Tools.Strings.Right("0" + d.Minute.ToString(), 2) + ":" + Tools.Strings.Right("0" + d.Second.ToString(), 2) + ampm;
        }

       
        public static String DateFormatRegardlessOfWindowsSettings(DateTime d)
        {
            return d.Month.ToString() + "/" + d.Day.ToString() + "/" + d.Year.ToString();
        }
        public static String GetDateCaption(DateTime d)
        {
            DateTime x = new DateTime(d.Year, d.Month, d.Day);
            DateTime y = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            TimeSpan t = y.Subtract(x);
            if( t.TotalDays == 0 )
                return "Today";
            else if( t.TotalDays == 1 )
                return "Yesterday";
            else
                return d.Month.ToString() + "/" + d.Day.ToString();
        }

        public static DateTime GetQuarterStart(DateTime d)
        {
            switch(d.Month)
            {
                case 1:
                case 2:
                case 3:
                    return new DateTime(d.Year, 1, 1, 0, 0, 0);
                case 4:
                case 5:
                case 6:
                    return new DateTime(d.Year, 4, 1, 0, 0, 0);
                case 7:
                case 8:
                case 9:
                    return new DateTime(d.Year, 7, 1, 0, 0, 0);
                case 10:
                case 11:
                case 12:
                    return new DateTime(d.Year, 10, 1, 0, 0, 0);  //this used to be 12 instead of 10; wtf?
            }
            return GetNullDate();
        }
        public static DateTime GetQuarterStart(int year, int quarter)
        {
            switch(quarter)
            {
                case 1:
                    return new DateTime(year, 1, 1, 0, 0, 0);
                case 2:
                    return new DateTime(year, 4, 1, 0, 0, 0);
                case 3:
                    return new DateTime(year, 7, 1, 0, 0, 0);
                case 4:
                    return new DateTime(year, 12, 1, 0, 0, 0);
            }
            return GetNullDate();
        }
        public static DateTime GetQuarterEnd(DateTime d)
        {
            return GetQuarterEnd(d.Year, Dates.GetQuarter(d));
        }
        public static DateTime GetQuarterEnd(int year, int quarter)
        {
            switch(quarter)
            {
                case 1:
                    return GetMonthEnd(year, 3);
                case 2:
                    return GetMonthEnd(year, 6);
                case 3:
                    return GetMonthEnd(year, 9);
                case 4:
                    return GetMonthEnd(year, 12);
            }
            return GetNullDate();
        }
        public static DateTime GetDateByWeek(int year, int week)
        {
            DateTime d = DateTime.Parse("01/01/" + year.ToString());
            d += TimeSpan.FromDays(( week * 7 ) - 1);
            return d;
        }
        public static DateTime GetDateByQuarter(int year, int quarter)
        {
            switch(quarter)
            {
                case 1:
                    return DateTime.Parse("01/01/" + year.ToString());
                case 2:
                    return DateTime.Parse("04/01/" + year.ToString());
                case 3:
                    return DateTime.Parse("07/01/" + year.ToString());
                case 4:
                    return DateTime.Parse("10/01/" + year.ToString());
            }
            return GetNullDate();
        }

        public static DateTime GetDayStart(DateTime d)
        {
            try
            {
                return new DateTime(d.Year, d.Month, d.Day, 0, 0, 0);
            }
            catch(Exception)
            {
                return GetNullDate();
            }
        }
        public static DateTime GetDayEnd(DateTime d)
        {
            try
            {
                return new DateTime(d.Year, d.Month, d.Day, 23, 59, 59);
            }
            catch(Exception)
            {
                return GetNullDate();
            }
        }
        public static DateTime GetDayStart(int year, int month, int day)
        {
            try
            {
                return GetDayStart(DateTime.Parse(month.ToString() + "/" + day.ToString() + "/" + year.ToString()));
            }
            catch(Exception)
            {
                return GetNullDate();
            }
        }
        public static String GetMonthName(int month)
        {
            try
            {
                return System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.MonthNames[month - 1];
            }
            catch(Exception)
            {
                return "x";
            }
        }

        public static int GetMonthNumber(String name)
        {
            switch (name.ToLower())
            {
                case "january":
                    return 1;
                case "february":
                    return 2;
                case "march":
                    return 3;
                case "april":
                    return 4;
                case "may":
                    return 5;
                case "june":
                    return 6;
                case "july":
                    return 7;
                case "august":
                    return 8;
                case "september":
                    return 9;
                case "october":
                    return 10;
                case "november":
                    return 11;
                case "december":
                    return 12;
                default:
                    throw new Exception("Month name error: " + name);
            }
        }

        public static DateTime GetMonthStart(DateTime d)
        {
            try
            {
                return GetMonthStart(d.Year, d.Month);
            }
            catch(Exception)
            {
                return GetNullDate();
            }
        }
        public static DateTime GetMonthStart(int year, int month)
        {
            try
            {
                return new DateTime(year, month, 1, 0, 0, 0);
            }
            catch(Exception)
            {
                return GetNullDate();
            }
        }
        public static DateTime GetMonthEnd(DateTime d)
        {
            return GetMonthEnd(d.Year, d.Month);
        }
        public static DateTime GetMonthEnd(int year, int month)
        {
            return new DateTime(year, month, DateTime.DaysInMonth(year, month), 23, 59, 59);
        }
        public static DateTime GetPreviousMonthStart(DateTime d)
        {
            return GetMonthStart(SubtractOneMonth(d));
        }
        public static DateTime GetPreviousMonthEnd(DateTime d)
        {
            return GetMonthEnd(SubtractOneMonth(d));
        }
        public static DateTime GetYearStart(DateTime d)
        {
            return GetYearStart(d.Year);
        }
        public static DateTime GetYearStart(int year)
        {
            try
            {
                return new DateTime(year, 1, 1, 0, 0, 0);
            }
            catch (Exception)
            {
                return GetNullDate();
            }
        }
        public static DateTime GetYearEnd(int year)
        {
            try
            {
                return new DateTime(year, 12, 31, 23, 59, 59);
            }
            catch (Exception)
            {
                return GetNullDate();
            }
        }

        public static DateTime GetYearEnd(DateTime d)
        {
            try
            {
                return new DateTime(d.Year, 12, 31, 23, 59, 59);
            }
            catch (Exception)
            {
                return GetNullDate();
            }
        }

        public static String GetDay_2Digit(DateTime d)
        {
            String s = "00" + d.Day.ToString();
            return Tools.Strings.Right(s, 2);
        }
        public static String GetMonth_2Digit(DateTime d)
        {
            String s = "00" + d.Month.ToString();
            return Tools.Strings.Right(s, 2);
        }
        public static DateTime AddOneMonth(DateTime d)
        {
            try
            {
                int day = d.Day;
                int month = d.Month;
                int year = d.Year;
                month++;
                if(month > 12)
                {
                    month = 1;
                    year++;
                }

                //otherwise running this on like May 31 tries to return April 31
                if (day > 28)
                    day = 28;

                return DateTime.Parse(month.ToString() + "/" + day.ToString() + "/" + year.ToString());
            }
            catch(Exception)
            {
                return GetNullDate();
            }
        }
        public static DateTime SubtractOneMonth(DateTime d)
        {
            try
            {
                int day = d.Day;
                int month = d.Month;
                int year = d.Year;
                month--;
                if(month < 1)
                {
                    month = 12;
                    year--;
                }

                //otherwise running this on like May 31 tries to return April 31
                if (day > 28)
                    day = 28;

                return DateTime.Parse(month.ToString() + "/" + day.ToString() + "/" + year.ToString());
            }
            catch(Exception)
            {
                return GetNullDate();
            }
        }
        public static int GetQuarter(DateTime d)
        {
            switch(d.Month)
            {
                case 1:
                case 2:
                case 3:
                    return 1;
                case 4:
                case 5:
                case 6:
                    return 2;
                case 7:
                case 8:
                case 9:
                    return 3;
                case 10:
                case 11:
                case 12:
                    return 4;
                default:
                    return -1;
            }
        }
        public static int GetWeek(DateTime d)
        {
            if( d.Day <= 7 )
                return 1;
            else if( d.Day <= 14 )
                return 2;
            else if( d.Day <= 21 )
                return 3;
            else if( d.Day <= 28 )
                return 4;
            else
                return 5;
            //this is week in the month now, not week of the year
            //return System.Globalization.CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(d, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
        }
        public static int GetMonthEndDate(Int32 month, Int32 year)
        {
            switch(month)
            {
                case 1:    //Jan
                    return 31;
                case 2:    //Feb
                    if( DateTime.IsLeapYear(year) )
                        return 29;
                    else
                        return 28;
                case 3:    //March
                    return 31;
                case 4:    //April
                    return 30;
                case 5:    //May
                    return 31;
                case 6:    //June
                    return 30;
                case 7:    //July
                    return 31;
                case 8:    //Aug
                    return 31;
                case 9:    //Sept
                    return 30;
                case 10:    //Oct
                    return 31;
                case 11:    //Nov
                    return 30;
                case 12:    //Dec
                    return 31;
                default:
                    return 31;
            }
        }
        //public static DateTime GetStartDate(DateTime d, CubeInterval interval)
        //{
        //    switch (interval)
        //    {
        //        case Tools.CubeInterval.Year:
        //            return GetYearStart(d.Year);
        //        case Tools.CubeInterval.Quarter:
        //            return GetQuarterStart(d);
        //        case Tools.CubeInterval.Month:
        //            return GetMonthStart(d);
        //        case Tools.CubeInterval.Week:
        //            return GetWeekStart(d);
        //        case Tools.CubeInterval.Day:
        //            return GetDayStart(d);
        //        default:
        //            return d;
        //    }
        //}
        public static DateTime GetEndDate(DateTime d, CubeInterval interval)
        {
            switch (interval)
            {
                case Tools.CubeInterval.Year:
                    return GetYearEnd(d.Year);
                case Tools.CubeInterval.Quarter:
                    return GetQuarterEnd(d);
                case Tools.CubeInterval.Month:
                    return GetMonthEnd(d);
                case Tools.CubeInterval.Week:
                    return GetWeekEnd(d);
                case Tools.CubeInterval.Day:
                    return GetDayEnd(d);
                default:
                    return d;
            }
        }

        public static DateComponent GetWeekComponent(DateTime d)
        {
            int year = d.Year;
            int month = d.Month;

            int monday = GetFirstMonday(d);

            int day = d.Day - (monday - 1);
            if (day <= 0)
            {
                //previous month
                month--;
                if (month < 1)
                {
                    month = 12;
                    year--;
                }

                //the last week in the previous month
                return GetWeekComponent(new DateTime(year, month, DateTime.DaysInMonth(year, month)));
            }
            else
            {
                int week = 0;
                if( day <= 7 )
                    return new DateComponent(year, -1, month, 1, -1);
                else if( day <= 14 )
                    return new DateComponent(year, -1, month, 2, -1);
                else if (day <= 21)
                    return new DateComponent(year, -1, month, 3, -1);
                else if (day <= 28)
                    return new DateComponent(year, -1, month, 4, -1);
                else
                    return new DateComponent(year, -1, month, 5, -1);
            }
        }

        public static DateTime GetFriday(DateTime d)
        {
            while(d.DayOfWeek != DayOfWeek.Friday )
            {
                d = d.Add(TimeSpan.FromDays(1));
            }
            return GetDayEnd(d);
        }

        public static DateTime GetWeekStart(DateTime d)
        {
            try
            {
                DateComponent dc = GetWeekComponent(d);
                return GetWeekStart(dc.Year, dc.Month, dc.Week);
            }
            catch { return d; }
        }
        public static DateTime GetWeekStart(int year, int month, int week)
        {
            try
            {
                DateTime start = GetMonthStart(year, month);
                int monday = GetFirstMonday(start);

                int y = start.Year;
                int m = start.Month;
                int d = 0;
                switch (monday)
                {
                    case 1:
                        switch (week)
                        {
                            case 1:
                                d = 1;
                                break;
                            case 2:
                                d = 8;
                                break;
                            case 3:
                                d = 15;
                                break;
                            case 4:
                                d = 22;
                                break;
                            case 5:
                                d = 29;
                                break;
                        }
                        break;
                    case 2:
                        switch (week)
                        {
                            case 1:
                                d = 2;
                                break;
                            case 2:
                                d = 9;
                                break;
                            case 3:
                                d = 16;
                                break;
                            case 4:
                                d = 23;
                                break;
                            case 5:
                                d = 30;
                                break;
                        }
                        break;
                    case 3:
                        switch (week)
                        {
                            case 1:
                                d = 3;
                                break;
                            case 2:
                                d = 10;
                                break;
                            case 3:
                                d = 17;
                                break;
                            case 4:
                                d = 24;
                                break;
                            case 5:
                                d = 31;
                                break;
                        }
                        break;
                    case 4:
                        switch (week)
                        {
                            case 1:
                                d = 4;
                                break;
                            case 2:
                                d = 11;
                                break;
                            case 3:
                                d = 18;
                                break;
                            case 4:
                                d = 25;
                                break;
                            case 5:
                                d = 32;
                                break;
                        }
                        break;
                    case 5:
                        switch (week)
                        {
                            case 1:
                                d = 5;
                                break;
                            case 2:
                                d = 12;
                                break;
                            case 3:
                                d = 19;
                                break;
                            case 4:
                                d = 26;
                                break;
                            case 5:
                                d = 33;
                                break;
                        }
                        break;
                    case 6:
                        switch (week)
                        {
                            case 1:
                                d = 6;
                                break;
                            case 2:
                                d = 13;
                                break;
                            case 3:
                                d = 20;
                                break;
                            case 4:
                                d = 27;
                                break;
                            case 5:
                                d = 34;
                                break;
                        }
                        break;
                    case 7:
                        switch (week)
                        {
                            case 1:
                                d = 7;
                                break;
                            case 2:
                                d = 14;
                                break;
                            case 3:
                                d = 21;
                                break;
                            case 4:
                                d = 28;
                                break;
                            case 5:
                                d = 35;
                                break;
                        }
                        break;
                }

                if (d == 0)
                    return start;

                int dim = DateTime.DaysInMonth(y, m);
                if (d > dim)
                {
                    m++;
                    if (m > 12)
                    {
                        m = 1;
                        y++;
                    }
                    d -= dim;
                }

                return new DateTime(y, m, d, 0, 0, 0);
            }
            catch { return DateTime.Now; }
        }

        public static DateTime AddInterval(DateTime date, CubeInterval interval)
        {
            switch (interval)
            {
                case CubeInterval.Day:
                    return date.Add(TimeSpan.FromDays(1));
                case CubeInterval.Month:
                    int y = date.Year;
                    int m = date.Month;
                    m++;
                    if (m > 12)
                    {
                        m = 1;
                        y++;
                    }
                    return new DateTime(y, m, 1);
                case CubeInterval.Quarter:
                    int yq = date.Year;
                    int mq = date.Month;
                    mq += 3;
                    if (mq > 12)
                    {
                        mq = 1;
                        yq++;
                    }
                    return new DateTime(yq, mq, 1);
                case CubeInterval.Year:
                    return new DateTime(date.Year + 1, 1, 1);
                default:
                    throw new NotImplementedException();
            }
        }

        public static DateTime GetWeekEnd(DateTime d)
        {
            d = GetWeekStart(d);
            d = d.Add(TimeSpan.FromDays(6));
            return GetDayEnd(d);
        }

        public static DateTime RoundDayEnd(DateTime d)
        {
            d = d.AddHours(23 - d.Hour);
            d = d.AddMinutes(59 - d.Minute);
            d = d.AddSeconds(59 - d.Second);
            return d;
        }

        public static DateTime GetWeekEnd(int year, int month, int week)
        {
            return GetWeekEnd(GetWeekStart(year, month, week));
        }

        public static DateTime GetStartDate(DateTime d, CubeInterval interval)
        {
            switch (interval)
            {
                case Tools.CubeInterval.Day:
                    return GetDayStart(d);
                case Tools.CubeInterval.Week:
                    return GetWeekStart(d);
                case Tools.CubeInterval.Month:
                    return GetMonthStart(d);
                case Tools.CubeInterval.Quarter:
                    return GetQuarterStart(d);
                case Tools.CubeInterval.Year:
                    return GetYearStart(d);
            }
            return d;
        }

        public static int GetFirstMonday(DateTime d)
        {
            int monday = 0;
            switch (GetMonthStart(d).DayOfWeek)
            {
                case DayOfWeek.Monday:
                    monday = 1;
                    break;
                case DayOfWeek.Tuesday:
                    monday = 7;
                    break;
                case DayOfWeek.Wednesday:
                    monday = 6;
                    break;
                case DayOfWeek.Thursday:
                    monday = 5;
                    break;
                case DayOfWeek.Friday:
                    monday = 4;
                    break;
                case DayOfWeek.Saturday:
                    monday = 3;
                    break;
                case DayOfWeek.Sunday:
                    monday = 2;
                    break;
            }
            return monday;
        }

        public static String Ago(TimeSpan t)
        {
            if (t.TotalMinutes < 2)
                return "1 minute ago";
            else if (t.TotalMinutes < 60)
                return Convert.ToInt32(t.TotalMinutes).ToString() + " minutes ago";
            else if (t.TotalHours < 2)
                return "1 hour ago";
            else if (t.TotalHours < 24)
                return Convert.ToInt32(t.TotalHours).ToString() + " hours ago";
            else if (t.TotalDays < 2)
                return "1 day ago";
            else
                return Convert.ToInt32(t.TotalDays).ToString() + " days ago";
        }

        public class DateRange
        {
            public static String GetSQL(String strField, DateTime start, DateTime end, Tools.Database.ServerType type, bool include_time)
            {
                switch (type)
                {
                    case Tools.Database.ServerType.SqlMy:
                        if (include_time)
                        {
                            throw new NotImplementedException();  //this needs to be handled with options, as with sql server
                            //return " " + strField + " >= '" + DataConnectionSqlMy.DateFormat(start) + " " + nTools.TimeFormat24(start) + "' and " + strField + " <= '" + DataConnectionSqlMy.DateFormat(end) + " " + nTools.TimeFormat24(end) + "'";
                        }
                        else
                        {
                            if (!Tools.Dates.DateExists(start))
                                return " " + strField + " >= '" + DataConnectionSqlMy.DateFormat(DateTime.Parse("01/02/1900")) + " 00:00:00' and " + strField + " <= '" + DataConnectionSqlMy.DateFormat(end) + " 23:59:59'";
                            else if (!Tools.Dates.DateExists(end))
                                return " " + strField + " >= '" + DataConnectionSqlMy.DateFormat(start) + " 00:00:00' and " + strField + " <= '" + DataConnectionSqlMy.DateFormat(DateTime.Parse("21/31/9999")) + " 23:59:59'";
                            else
                                return " " + strField + " >= '" + DataConnectionSqlMy.DateFormat(start) + " 00:00:00' and " + strField + " <= '" + DataConnectionSqlMy.DateFormat(end) + " 23:59:59'";
                        }
                    default:
                        if (include_time)
                        {
                            if (!Tools.Dates.DateExists(start))
                                return " " + strField + " >= '1/2/1900' and " + strField + " <= cast('" + Tools.Dates.DateFormat(end) + " " + Tools.Dates.TimeFormat24(end) + "' as datetime)";
                            else if (!Tools.Dates.DateExists(end))
                                return " " + strField + " >= cast('" + Tools.Dates.DateFormat(start) + " " + Tools.Dates.TimeFormat24(start) + "' as datetime)";
                            else
                                return " " + strField + " between cast('" + Tools.Dates.DateFormat(start) + " " + Tools.Dates.TimeFormat24(start) + "' as datetime) and cast('" + Tools.Dates.DateFormat(end) + " " + Tools.Dates.TimeFormat24(end) + "' as datetime)";
                        }
                        else
                        {
                            if (!Tools.Dates.DateExists(start))
                                return " " + strField + " between cast('1/2/1900 12:00:00 am' as datetime) and cast('" + Tools.Dates.DateFormat(end) + " 11:59:59 pm' as datetime)";
                            else if (!Tools.Dates.DateExists(end))
                                return " " + strField + " between cast('" + Tools.Dates.DateFormat(start) + " 12:00:00 am' as datetime) and cast('12/31/9999 11:59:59 pm' as datetime)";
                            else
                                return " " + strField + " between cast('" + Tools.Dates.DateFormat(start) + " 12:00:00 am' as datetime) and cast('" + Tools.Dates.DateFormat(end) + " 11:59:59 pm' as datetime)";
                        }
                }
            }
            public static String GetSQLIncludingTime(String strField, DateTime start, DateTime end)
            {
                return " " + strField + " between cast('" + Tools.Dates.DateFormatWithTimeRegardlessOfWindowsSettings(start) + "' as datetime) and cast('" + Tools.Dates.DateFormatWithTimeRegardlessOfWindowsSettings(end) + "' as datetime)";
            }
            public static DateRange Tomorrow
            {
                get
                {
                    DateTime t = DateTime.Now.Add(TimeSpan.FromDays(1));
                    return new DateRange(t, t);
                }
            }
            public DateTime StartDate;
            public DateTime EndDate;
            public bool IncludesTime = false;
            public DateRange()
            {
                StartDate = Tools.Dates.NullDate;
                EndDate = Tools.Dates.NullDate;
            }
            public DateRange(DateTime start, DateTime end)
                : this(start, end, false)
            {

            }
            public DateRange(DateTime start, DateTime end, bool include_time)
            {
                StartDate = start;
                EndDate = end;
                IncludesTime = include_time;
            }
            public DateRange(DateRange d)
            {
                StartDate = d.StartDate;
                EndDate = d.EndDate;
            }
            public DateRange(String startDateString, String endDateString)
            {
                StartDate = DateTime.Parse(startDateString);
                EndDate = DateTime.Parse(endDateString);
            }
            public String GetSQL(String strField)
            {
                return GetSQL(strField, StartDate, EndDate, Tools.Database.ServerType.SqlServer, IncludesTime);
            }
            public String GetSQL(String strField, Tools.Database.ServerType type)
            {
                return GetSQL(strField, StartDate, EndDate, type, IncludesTime);
            }
            public String Caption
            {
                get
                {
                    return CaptionCalc("and");
                }
            }
            public String CaptionTo
            {
                get
                {
                    return CaptionCalc("To");
                }
            }
            public bool Valid
            {
                get
                {
                    return Tools.Dates.DateExists(StartDate) || Tools.Dates.DateExists(EndDate);
                }
            }
            String CaptionCalc(String separator)
            {
                if (!Valid)
                    return "";

                if (IncludesTime)
                    return StartDate.ToString() + " " + separator + " " + EndDate.ToString();
                else
                {
                    if (!Tools.Dates.DateExists(StartDate))
                        return "Before " + Tools.Dates.DateFormat(EndDate);

                    if (!Tools.Dates.DateExists(EndDate))
                        return "After " + Tools.Dates.DateFormat(StartDate);

                    if (StartDate.Year == EndDate.Year && StartDate.Month == EndDate.Month && StartDate.Day == EndDate.Day)
                        return Tools.Dates.DateFormat(StartDate);
                    else
                        return Tools.Dates.DateFormat(StartDate) + " " + separator + " " + Tools.Dates.DateFormat(EndDate);
                }
            }
            public bool IsMonthSpan()
            {
                if (!Valid)
                    return false;

                if (StartDate.Day != 1)
                    return false;
                if (StartDate.Month != EndDate.Month)
                    return false;
                if (StartDate.Year != EndDate.Year)
                    return false;

                return (EndDate.Day == Tools.Dates.GetMonthEnd(StartDate).Day);
            }
            public bool EndsToday
            {
                get
                {
                    if (!Valid)
                        return false;

                    TimeSpan t = DateTime.Now.Subtract(EndDate);
                    return Math.Abs(t.TotalDays) < 1;
                }
            }
            public bool IsThisMonthSoFar
            {
                get
                {
                    if (!Valid)
                        return false;

                    TimeSpan t = Tools.Dates.GetMonthStart(DateTime.Now).Subtract(StartDate);
                    if (Math.Abs(t.TotalDays) >= 1)
                        return false;

                    return EndsToday;
                }
            }
            public bool IsYearToDate
            {
                get
                {
                    DateRange ytd = YearToDate;
                    return Tools.Dates.IsSameDay(StartDate, ytd.StartDate) && Tools.Dates.IsSameDay(EndDate, ytd.EndDate);
                }
            }
            public bool Includes(DateTime d)
            {
                if (!Valid)
                    return false;

                if (!Tools.Dates.DateExists(d))
                    return false;

                return (!Tools.Dates.DateExists(StartDate) || d >= StartDate) && (!Tools.Dates.DateExists(EndDate) || d <= EndDate);
            }
            public int GetDays()
            {
                if (!Valid)
                    throw new Exception("Not a valid range");

                TimeSpan t = EndDate.Subtract(StartDate);
                return Convert.ToInt32(t.TotalDays);
            }
            public int GetWeekDays()
            {
                if (!Valid)
                    throw new Exception("Not a valid range");

                TimeSpan t = EndDate.Subtract(StartDate);
                int ds = Convert.ToInt32(t.TotalDays);
                int r = 0;

                for (int i = 0; i < ds; i++)
                {
                    DateTime d = StartDate.Add(TimeSpan.FromDays(i));
                    DayOfWeek dw = d.DayOfWeek;
                    if (dw != DayOfWeek.Saturday && dw != DayOfWeek.Sunday)
                        r++;
                }

                return r;
            }
            public static DateRange ThisMonth
            {
                get
                {
                    return new DateRange(Tools.Dates.GetMonthStart(DateTime.Now), Tools.Dates.GetMonthEnd(DateTime.Now));
                }
            }
            public static DateRange LastMonth
            {
                get
                {
                    DateTime d = Tools.Dates.GetMonthStart(DateTime.Now).Subtract(TimeSpan.FromDays(1));
                    return new DateRange(Tools.Dates.GetMonthStart(d), Tools.Dates.GetMonthEnd(d));
                }
            }
            public static DateRange LastYear
            {
                get
                {
                    DateTime d = new DateTime(DateTime.Now.Year - 1, 1, 1);
                    return new DateRange(Tools.Dates.GetYearStart(d), Tools.Dates.GetYearEnd(d));
                }
            }
            public static DateRange YesterdayThisMonth
            {
                get
                {
                    DateTime TheDate = DateTime.Now.Subtract(TimeSpan.FromDays(1));
                    return new DateRange(Tools.Dates.GetMonthStart(TheDate), Tools.Dates.GetMonthEnd(TheDate));
                }
            }
            public void SetStartTime(String s)
            {
                StartDate = DateTime.Parse(Tools.Dates.DateFormat(StartDate) + " " + s);
                IncludesTime = true;
            }
            public void SetEndTime(String s)
            {
                EndDate = DateTime.Parse(Tools.Dates.DateFormat(EndDate) + " " + s);
                IncludesTime = true;
            }
            public string GetBetweenSQL()
            {
                if (!Tools.Dates.DateExists(StartDate))
                    return " between cast('1/2/1900 00:00:00' as datetime) and cast('" + EndDate.ToShortDateString() + " 23:59:59' as datetime) ";
                else if (!Tools.Dates.DateExists(EndDate))
                    return " between cast('" + StartDate.ToShortDateString() + " 00:00:00' as datetime) and cast('12/31/9999 23:59:59' as datetime) ";
                else
                    return " between cast('" + StartDate.ToShortDateString() + " 00:00:00' as datetime) and cast('" + EndDate.ToShortDateString() + " 23:59:59' as datetime) ";
            }
            public static DateRange YearToDate
            {
                get
                {
                    return new DateRange(Tools.Dates.GetYearStart(DateTime.Now), DateTime.Now);
                }
            }
            public static DateRange MonthToDate
            {
                get
                {
                    return new DateRange(Tools.Dates.GetMonthStart(DateTime.Now), DateTime.Now);
                }
            }
            public static DateRange Today
            {
                get
                {
                    return new DateRange(DateTime.Now, DateTime.Now);
                }
            }
            public static DateRange None
            {
                get
                {
                    return new DateRange(Tools.Dates.NullDate, Tools.Dates.NullDate);
                }
            }

            
        }

    }
    public enum CubeInterval
    {
        Any = 0,
        Millisecond = 1,
        Second = 2,
        Minute = 3,
        Hour = 4,
        Day = 5,
        Week = 6,
        Month = 7,
        Quarter = 8,
        Year = 9,
        //Decade = 10,
        //Century = 11,
    }
    public class DateComponent
    {
        public int Year = -1;
        public int Quarter = -1;
        public int Month = -1;
        public int Week = -1;
        public int Day = -1;

        public DateComponent(int year, int quarter, int month, int week, int day)
        {
            Year = year;
            Quarter = quarter;
            Month = month;
            Week = week;
            Day = day;
        }

        public override string ToString()
        {
            String val = "";

            if (Year > -1)
            {
                if (val != "")
                    val += "_";

                val += "year_is_" + Year.ToString();
            }

            if (Quarter > -1)
            {
                if (val != "")
                    val += "_";

                val += "quarter_is_" + Quarter.ToString();
            }

            if (Month > -1)
            {
                if (val != "")
                    val += "_";

                val += "month_is_" + Month.ToString();
            }

            if (Week > -1)
            {
                if (val != "")
                    val += "_";

                val += "week_is_" + Week.ToString();
            }

            if (Day > -1)
            {
                if (val != "")
                    val += "_";

                val += "day_is_" + Day.ToString();
            }

            return val;
        }
    }
}
