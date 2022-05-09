using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using NewMethodx;

namespace Tie
{

    public delegate void StreamProgressHandler(int progress);
    public delegate void StreamStatusHandler(String status);
    public delegate void StreamEventHandler(TieStream s, String message);

    public class TieStream
    {

        public event StreamProgressHandler GotActualProgress;
        public event StreamProgressHandler GotSteppedProgress;
        public event StreamStatusHandler GotStatus;
        public event StreamEventHandler StreamCompleted;
        public event StreamEventHandler StreamFailed;

        public int CompletedPercent = 0;
        public String LastStatus = "";
        public bool Started = false;
        public bool Completed = false;
        public bool Success = false;
        public DateTime StartTime;

        public void FireAllProgress(int progress)
        {
            FireGotActualProgress(progress);
            FireGotSteppedProgress(progress);
        }

        public void FireGotActualProgress(int progress)
        {
            CompletedPercent = progress;
            if (GotActualProgress != null)
                GotActualProgress(progress);
        }

        public void FireGotSteppedProgress(int progress)
        {
            CompletedPercent = progress;
            if (GotSteppedProgress != null)
                GotSteppedProgress(progress);
        }

        public void FireGotStatus(String status)
        {
            LastStatus = status;
            if (GotStatus != null)
                GotStatus(status);
        }

        public void FireStreamCompleted()
        {
            if (StreamCompleted != null)
                StreamCompleted(this, "");
        }

        public void FireStreamFailed(String message)
        {
            if (StreamFailed != null)
                StreamFailed(this, message);
        }

        public StreamPoint SourcePoint;
        public StreamPoint DestPoint;

        public void RunStream()
        {

        }

        public void ReRun()
        {
            CompletedPercent = 0;
            Success = false;
            Completed = false;
            LastStatus = "";
            BeginStream();
        }

        public bool HasValidPoints(ref String error)
        {
            if (!SourcePoint.IsValid("source", ref error))
                return false;

            if (!DestPoint.IsValid("destination", ref error))
                return false;

            if (DestPoint.TheType == StreamPointType.HTTP)
            {
                error = "The destination type cannot be HTTP";
                return false;
            }
            return true;
        }

        public int ElapsedSeconds
        {
            get
            {
                TimeSpan t = DateTime.Now.Subtract(StartTime);
                return Convert.ToInt32(t.TotalSeconds);
            }
        }

        public String Caption
        {
            get
            {
                return "Stream: " + SourcePoint.Caption + " -> " + DestPoint.Caption;
            }
        }

        Thread StreamThread = null;

        public void BeginStream()
        {
            if (StreamThread != null)
            {
                CancelStream();
            }

            StartTime = DateTime.Now;
            Started = true;
            Completed = false;
            Success = false;
            StreamThread = new Thread(new ThreadStart(BeginStreamOnThread));
            StreamThread.SetApartmentState(ApartmentState.STA);
            StreamThread.Start();
        }

        public void GotRawStatus(String s)
        {
            FireGotStatus(s);
        }

        public int lastprogressvalue = 0;
        public DateTime lastprogresstime;
        public void GotRawProgress(int p)
        {
            FireGotActualProgress(p);

            //only send 20 percent or after 2 seconds

            int diff = Math.Abs(p - lastprogressvalue);
            bool b = diff > 20;
            if (!b)
            {
                TimeSpan t = DateTime.Now.Subtract(lastprogresstime);
                if (t.TotalSeconds > 2)
                    b = true;
            }

            if (b)
            {
                lastprogressvalue = p;
                lastprogresstime = DateTime.Now;
                FireGotSteppedProgress(p);
            }
        }

        public void BeginStreamOnThread()
        {
            lastprogressvalue = 0;
            lastprogresstime = Tools.Dates.GetNullDate();

            String s = "";
            if (SourcePoint.CopyTo(DestPoint, new StreamProgressHandler(GotRawProgress), new StreamStatusHandler(GotRawStatus), ref s))
            {
                Completed = true;
                Success = true;
                FireStreamCompleted();
            }
            else
            {
                Completed = true;
                Success = false;
                FireStreamFailed(s);
            }
        }

        public void CancelStream()
        {
            try
            {
                if (StreamThread == null)
                    return;

                StreamThread.Abort();
                StreamThread = null;
            }
            catch { }
        }

    }
}
