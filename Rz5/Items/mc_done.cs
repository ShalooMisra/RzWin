using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Windows.Forms;
using NewMethod;

namespace Rz5
{
    //public delegate void DoneStatusHandler(Object sender, String status);
    public partial class mc_done : mc_done_auto   //, IStatusView
    {
        //public event DoneStatusHandler GotStatus;
        public TreeNode MyNode;
        public bool IsRunning = false;

        //Public Functions
        public long DurationSeconds
        {
            get
            {
                return Convert.ToInt64(DurationTimeSpan.TotalSeconds);
            }
        }
        public TimeSpan DurationTimeSpan
        {
            get
            {
                return end_date.Subtract(start_date);
            }
        }
        public String DurationText
        {
            get
            {
                TimeSpan t = DurationTimeSpan;

                if (t.TotalMinutes < 1)
                    return t.Seconds.ToString() + " seconds";
                else if (t.TotalHours < 1)
                    return t.Minutes.ToString() + " minutes";
                else if (t.TotalDays < 1)
                    return t.Hours.ToString() + " hours, " + t.Minutes.ToString() + " minutes";
                else
                    return t.Days.ToString() + " days, " + t.Hours.ToString() + " hours, " + t.Minutes.ToString() + " minutes";
            }
        }
        public String GetTreeCaption()
        {
            if (IsRunning)
                return "Running [Started " + nTools.DateFormat_ShortDateTime(this.start_date) + "]...";
            else
                return "Completed [" + nTools.DateFormat_ShortDateTime(this.end_date) + "   " + DurationText + "]";
        }
        public System.Drawing.Color GetTreeColor()
        {
            if( IsRunning )
                return System.Drawing.Color.DarkBlue;
            if (is_success)
                return System.Drawing.Color.Green;
            else
                return System.Drawing.Color.Red;
        }
        //public void SetStatusByIndex(Object sender, StatusArgs args)
        //{
        //    done_status += args.status + "\r\n";

        //    if (GotStatus != null)
        //        GotStatus(this, args.status);        
        //}
        //public void SetProgressByIndex(Object sender, ProgressArgs args) 
        //{ }
        //public void SetActivityByIndex(Object sender, ActivityArgs args) 
        //{ }
        //public void AddLine() 
        //{ }
        //public void RemoveLine() 
        //{ }
    }
}
