using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Windows.Forms;

using Tools;
using NewMethod;
using System.Threading;
using Core;

namespace Rz5
{
    public partial class mc_duty : mc_duty_auto
    {
        public ArrayList AllDone = new ArrayList();
        public TreeNode MyNode;
        public bool IsRunning = false;
        public nDuty DutyObject;
        public mc_done CurrentDone;

        //Public Virtual Functions
        public void InitDutyObject(ContextRz context)
        {
            DutyObject = ((SysRz5)context.TheSys).TheDutyLogic.DutyObjectCreate(function_name);
            DutyObject.TheDuty = this;
        }
        //Public Functions
        public mc_done AddDone(ContextRz context)
        {
            mc_done d = mc_done.New(context);
            d.base_mc_duty_uid = this.unique_id;
            d.start_date = DateTime.Now;  //added 2013_03_14 troubleshooting the rzrescue problem
            context.Insert(d);

            if (AllDone != null)
                AllDone.Add(d);

            return d;
        }
        public bool OverdueAndNotRunning
        {
            get
            {
                if (IsRunning)
                    return false;

                return Overdue;
            }
        }
        public bool Overdue
        {
            get
            {
                //this was making stalled duties never run
                //if (IsRunning)
                //    return false;

                if (duty_interval <= 0)
                    return false;

                if (Tools.Strings.StrExt(ideal_weekday))
                {
                    DayOfWeek w = DateTime.Now.DayOfWeek;
                    switch (ideal_weekday.ToString().Trim().ToLower())
                    {
                        case "monday":
                            w = DayOfWeek.Monday;
                            break;
                        case "tuesday":
                            w = DayOfWeek.Tuesday;
                            break;
                        case "wednesday":
                            w = DayOfWeek.Wednesday;
                            break;
                        case "thursday":
                            w = DayOfWeek.Thursday;
                            break;
                        case "friday":
                            w = DayOfWeek.Friday;
                            break;
                        case "saturday":
                            w = DayOfWeek.Saturday;
                            break;
                        case "sunday":
                            w = DayOfWeek.Sunday;
                            break;
                        default:
                            //just let it run if there's something there that's not a valid day
                            break;
                    }

                    if (DateTime.Now.DayOfWeek != w)
                        return false;
                }

                if (duty_interval < 1440)
                    return (GetMinutesSinceLastRun() > duty_interval);
                else
                {
                    //ideal_hour = 17;
                    //ideal_minute = 30;

                    if( ideal_hour <= 0 )
                        return (GetMinutesSinceLastRun() > duty_interval);


                    //2010_02_10
                    //changed so that these daily duties never run when its not their ideal time, even if they're overdue
                    //otherwise intensive processes run during the day after a problem or restart

                    //get the ideal time on this day
                    //DateTime ideal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, ideal_hour, ideal_minute, 0);

                    ////only run it the first time this mark is passed
                    //return DateTime.Now > ideal && (DateTime.Now.Subtract(ideal).TotalMinutes <= 90);

                    //2010_02_17    of course now it runs continuously for 90 minutes after its time.  lets try again.

                    //this assumes at most often a daily process
                    //so lets take, say 3 hours off the interval and see if its been run in that time
                    long adj_int = duty_interval - (60 * 3);

                    if (GetMinutesSinceLastRun() < adj_int)
                        return false;

                    //get the ideal time on this day
                    DateTime ideal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, ideal_hour, ideal_minute, 0);

                    //now, if its later than 90 minutes after the ideal time, don't run
                    if( DateTime.Now.Subtract(ideal).TotalMinutes > 90 )
                        return false;

                    //only run it the first time this mark is passed
                    return DateTime.Now > ideal;
                 }
            }
        }
        public bool IsStalled(DateTime last_start)
        {
            if (!IsRunning)
                return false;

            if (duty_interval <= 0)
                return false;

            if (duty_interval >= 1440)
                return false;

            if (ideal_hour > 0)
                return false;
           
            return DateTime.Now.Subtract(last_start).TotalMinutes > (duty_interval + 1);  //1 interval only
        }
        public Int64 GetMinutesSinceLastRun()
        {
            TimeSpan t = System.DateTime.Now.Subtract(last_run);
            return Convert.ToInt64(t.TotalMinutes);
        }
        public Int64 GetMinutesUntilNextRun()
        {
            if( !Tools.Dates.DateExists(last_run) )
                return 0;
            TimeSpan t = last_run.Add(TimeSpan.FromMinutes(duty_interval)).Subtract(System.DateTime.Now);
            return Convert.ToInt64(t.TotalMinutes);
        }
        public Int64 GetSecondsUntilNextRun()
        {
            if (!Tools.Dates.DateExists(last_run))
                return 0;
            TimeSpan t = last_run.Add(TimeSpan.FromMinutes(duty_interval)).Subtract(System.DateTime.Now);
            return Convert.ToInt64(t.TotalSeconds);
        }
        public String DutyInterval
        {
            get
            {
                TimeSpan t = TimeSpan.FromMinutes(duty_interval);
                if (t.TotalHours < 1)
                    return "Every " + t.TotalMinutes.ToString() + " minutes";
                else if( t.TotalDays < 1 )
                    return "Every " + t.TotalHours.ToString() + " hours";
                else
                    return "Every " + t.TotalDays.ToString() + " days";
            }
        }
        public void CacheRecentDone(ContextRz context)
        {
            AllDone = context.QtC("mc_done", "select top 10 * from mc_done where base_mc_duty_uid = '" + unique_id + "' order by start_date desc");
            AllDone.Reverse();
        }
        public DateTime GetRecentStartDate()
        {
            DateTime dtStart = DateTime.Now.Subtract(TimeSpan.FromDays(1));
            if (duty_interval == 0 || is_disabled)
                return nTools.GetBlankDate();
            if (duty_interval < 60)
                dtStart = DateTime.Now.Subtract(TimeSpan.FromHours(2));
            else if (duty_interval < (12 * 60))
                dtStart = DateTime.Now.Subtract(TimeSpan.FromDays(1));
            else if (duty_interval < (12 * 60 * 2))
                dtStart = DateTime.Now.Subtract(TimeSpan.FromDays(4));
            else
                dtStart = DateTime.Now.Subtract(TimeSpan.FromDays(10));
            return dtStart;
        }
        public String GetTreeCaption()
        {
            return duty_name + " [" + DutyInterval + "] Last: " + nTools.DateFormat_ShortDateTime(last_run); 
        }
        public System.Drawing.Color GetTreeColor()
        {
            if (IsRunning)
                return System.Drawing.Color.DarkBlue;
            else if (this.is_disabled)
                return System.Drawing.Color.Gray;
            else
                return System.Drawing.Color.Blue;
        }
        public bool NotifyRecogninOfFailure(ContextRz context, Leader dlh)  //not sure if dlh = context.Leader
        {
            nEmailMessage m = new nEmailMessage();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<font color=red><h2>" + Tools.Strings.NiceFormat(context.Logic.CompanyIdentifier) + " - " + duty_name + " Failure Report</h2></font><br><hr>");
            foreach(String s in dlh.ErrorList)
            {
                sb.AppendLine("<br>" + s);
            }

            sb.AppendLine("<br><hr><br>Log:<br>" + dlh.Html);

            m.HTMLBody = sb.ToString();
            //if (Rz3App.xLogic.IsAAT)
            //    return true;
            //else
                m.ToAddress = "dutyfailures@recognin.com";
            //m.AddExtraRecipient("joel@recognin.com");
            m.ToName = "Duty Failure - " + Tools.Strings.NiceFormat(context.Logic.CompanyIdentifier);
            m.Subject = duty_name + " Failure Report - " + Tools.Strings.NiceFormat(context.Logic.CompanyIdentifier);
            context.Logic.SetFromNotification(m);
            return m.Send();
        }
    }

    public class DutyRunHandle
    {
        public DutyRunHandle(ContextRz context)
        {
            TheContext = context;
        }

        public ContextRz TheContext;
        public Thread t;
        public mc_duty d;
        public DateTime StartTime = DateTime.Now;
        public bool Completed = false;
        public mc_done done;
    }
}
