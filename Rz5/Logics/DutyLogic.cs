using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

using Tools;
using Core;
using NewMethod;

namespace Rz5
{
    public class DutyLogic
    {
        public event ThreadDoneHandler DutyStarted;
        public event ThreadDoneHandler DutyComplete;

        public DutyLogic()
        {
        }

        ~DutyLogic()
        {
            DutiesLoadUn();
        }

        public int DutyIntervalMilliseconds
        {
            get
            {
                return 30000;
            }
        }

        public List<mc_duty> Duties;


        ArrayList Threads = new ArrayList();
        ArrayList RunningHandles = new ArrayList();

        public void DutiesLoad(ContextRz context)
        {
            DutiesLoadUn();

            DoneTrim(context);

            try
            {
                String s = "";
                if (context.TheData.FieldExists("mc_duty", "version_12"))
                    s = "select * from mc_duty where isnull(version_12, 0) = 0 order by duty_name ";
                else
                    s = "select * from mc_duty order by duty_name";

                Duties = GetDutyCollection(context, s);
            }
            catch (Exception)
            { }            
        }

        public void DoneTrim(ContextRz context)
        {
            context.TheLeader.CommentEllipse("Trimming the duty log");
            context.Execute("delete from mc_done where date_created <= '" + DateTime.Now.Subtract(TimeSpan.FromDays(20)) + "'");
        }

        public void DutiesLoadCheck(ContextRz context)
        {
            if (Duties == null)
                DutiesLoad(context);
        }

        void DutiesLoadUn()
        {
            try
            {
                if (Duties != null)
                    Duties.Clear();
                Duties = null;
            }
            catch { }
        }

        protected virtual List<mc_duty> GetDutyCollection(ContextRz context, string s)
        {
            List<mc_duty> ret = new List<mc_duty>();
            foreach (mc_duty d in context.QtC("mc_duty", s))
            {
                ret.Add(d);
                d.CacheRecentDone(context);
            }
            return ret;
        }

        public void CheckAll(ContextRz context)
        {
            Check(context, Duties);
        }

        public void Check(ContextRz context, List<mc_duty> duties_to_check)
        {
            try
            {
                //this is to do it all in 1 thread to avoid having to lock()
                ArrayList remove = new ArrayList();
                ArrayList handles = new ArrayList(RunningHandles);


                foreach (DutyRunHandle h in handles)
                {
                    if (h.Completed)
                        remove.Add(h);
                    else
                    {
                        if (h.d.IsStalled(h.StartTime))  //if its still running when its overdue it needs to be cancelled
                        {
                            context.TheLeader.CommentEllipse(h.d.duty_name + " is stalled: cancelling");
                            CancelStalledDuty(h);
                            remove.Add(h);
                        }
                    }
                }

                foreach (DutyRunHandle h in remove)
                {
                    RunningHandles.Remove(h);
                }

                foreach (mc_duty d in duties_to_check)
                {
                    if (d.duty_name.ToLower().Contains("rzrescue"))
                    {
                        ;
                    }

                    if (!d.is_disabled && d.OverdueAndNotRunning)
                    {
                        try
                        {
                            RunDuty(context, d);
                        }
                        catch (Exception ex)
                        {
                            context.TheLeader.Error("Error running " + d.duty_name + ": " + ex.Message);
                            if( d.CurrentDone != null )
                            {
                                d.CurrentDone.done_status += "\r\n" + "Error running " + d.duty_name + ": " + ex.Message;
                                d.CurrentDone.Update(context);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                context.TheLeader.Error("RTE Checking Duties: " + ex.Message);
            }
        }

        DateTime LastStallCheck = DateTime.Now;
        void CheckForStalledDuties()
        {
        }

        void CancelStalledDuty(DutyRunHandle dh)
        {
            try
            {
                ContextRz xrz = (ContextRz)dh.TheContext;

                dh.TheContext.TheLeader.CommentEllipse("Killing the stalled duty " + dh.d.duty_name);

                nEmailMessage m = new nEmailMessage();
                m.HTMLBody = "<font color=red><h2>" + dh.d.duty_name + " About To Stall Report</h2></font><br><hr>" + dh.d.duty_name + " was started at " + dh.StartTime.ToString() + " and is about to be stopped at " + DateTime.Now.ToString();
                m.ToAddress = "dutyfailures@recognin.com";
                m.ToName = "Duty About To Stall";
                m.Subject = dh.d.duty_name + " About To Stall Report";
                xrz.Logic.SetFromNotification(m);
                m.Send();

                try
                {
                    dh.t.Abort();
                    dh.t = null;
                }
                catch { }

                //all of the completed stuff that won't run otherwise
                mc_duty d = dh.d;
                d.CurrentDone.done_status += "Duty stalled.\r\n";
                d.CurrentDone.is_success = false;
                d.last_run = System.DateTime.Now;
                dh.TheContext.Update(d);

                d.CurrentDone.IsRunning = false;
                d.CurrentDone.end_date = System.DateTime.Now;
                dh.TheContext.Update(d.CurrentDone);

                if (DutyComplete != null)
                    DutyComplete(dh);

                dh.TheContext.TheLeader.Comment("Killed the stalled duty " + dh.d.duty_name);

                m = new nEmailMessage();
                m.HTMLBody = "<font color=red><h2>" + dh.d.duty_name + " Stall Report</h2></font><br><hr>" + dh.d.duty_name + " was started at " + dh.StartTime.ToString() + " and was stopped at " + DateTime.Now.ToString();
                m.ToAddress = "dutyfailures@recognin.com";
                m.ToName = "Duty Stalled";
                m.Subject = dh.d.duty_name + " Stall Report";
                xrz.Logic.SetFromNotification(m);
                m.Send();
            }
            catch (Exception ex)
            {
                dh.TheContext.TheLeader.Comment("RTE cancelling a stalled duty: " + ex.Message);
            }
        }

        public mc_done RunDuty(ContextRz context, mc_duty d)
        {
            context.TheLeader.CommentEllipse("Running " + d.duty_name);

            d.InitDutyObject(context);
            mc_done done = d.AddDone(context);
            done.start_date = System.DateTime.Now;
            done.IsRunning = true;

            d.CurrentDone = done;
            d.IsRunning = true;
            
            Thread t = new Thread(new ParameterizedThreadStart(w_DoWork));
            t.SetApartmentState(ApartmentState.STA);

            DutyRunHandle dh = new DutyRunHandle(context);
            dh.d = d;
            dh.t = t;

            RunningHandles.Add(dh);

            if (DutyStarted != null)
            {
                dh.done = done;
                DutyStarted(dh);
            }

            t.Start(dh);
            return done;
        }

        void w_DoWork(object x)
        {
            DutyRunHandle dh = (DutyRunHandle)x;
            mc_duty d = dh.d;

            ContextRz xrz = (ContextRz)dh.TheContext;
            ContextRz q = (ContextRz)xrz.Clone();
            q.LeaderRecreate();
            q.Leader.HtmlInit();
            Leader dlh = (Leader)q.Leader;

            try
            {                
                dh.TheContext.TheLeader.CommentEllipse("------------------ running " + d.duty_name + " on the actual thread");

                
                q.xUser = (NewMethod.n_user)dh.TheContext.xSys.Users.GetByName("RzSystem");
                if (q.xUser == null)
                    q.xUser = dh.TheContext.xUser;

                try
                {
                    d.DutyObject.RunDuty(q);

                    if( dlh.ErrorsOccurred )
                        DutyFailedHandle(dh.TheContext, dlh, d);
                    else
                    {
                        d.CurrentDone.is_success = true;
                        dh.TheContext.TheLeader.Comment(dlh.Html);
                        dh.TheContext.TheLeader.Comment(d.duty_name + " completed successfully");
                        d.CurrentDone.done_status = dlh.Html;
                    }
                }
                catch (Exception exx)
                {
                    dlh.Error("RTE in w_DoWork: " + exx.Message);
                    DutyFailedHandle(dh.TheContext, dlh, d);
                }
            }
            catch (Exception ex)
            {
                dlh.Error("RTE in w_DoWork: " + ex.Message);
                DutyFailedHandle(dh.TheContext, dlh, d);
            }

            try
            {
                d.last_run = System.DateTime.Now;
                dh.TheContext.Update(d);

                d.CurrentDone.IsRunning = false;
                d.CurrentDone.end_date = System.DateTime.Now;
                dh.TheContext.Update(d.CurrentDone);

                n_set.SetSetting_Date(dh.TheContext, "last_duty_run", System.DateTime.Now);
                xrz.Logic.MarkConcern(dh.TheContext, "Duty_Run");

                dh.TheContext.TheLeader.Comment("------------------ finished " + d.duty_name);

                dh.Completed = true;
                d.IsRunning = false;

                if (DutyComplete != null)
                    DutyComplete(dh);
            }
            catch { }
        }

        void DutyFailedHandle(ContextRz context, Leader dlh, mc_duty d)
        {
            d.CurrentDone.done_status = dlh.Html;
            d.CurrentDone.done_status += "<br>Duty failed.\r\n";
            d.CurrentDone.is_success = false;
            d.IsRunning = false;  //OMG how was this ever left out!?!  2011_07_12
            context.TheLeader.Comment(d.duty_name + " failed");
            d.NotifyRecogninOfFailure(context, dlh);
        }

        //public void LogClear()
        //{
        //    lock (LogFileSyncRoot)
        //    {
        //        try
        //        {
        //            File.Delete(LogFile);
        //        }
        //        catch { }
        //    }
        //}

        //public static String LogFile = "c:\\rz_duty_monitor.txt";
        //public static Object LogFileSyncRoot = new Object();
        //public static void WriteLog(String s)
        //{
        //    try
        //    {
        //        lock (LogFileSyncRoot)
        //        {
        //            FileStream f = new FileStream(LogFile, FileMode.Append, FileAccess.Write);
        //            StreamWriter w = new StreamWriter(f);
        //            w.WriteLine(DateTime.Now.ToString() + "  :  " + s);
        //            w.Close();
        //            w.Dispose();
        //            w = null;
        //            f.Close();
        //            f.Dispose();
        //            f = null;
        //        }
        //    }
        //    catch { }
        //}

        public void RunUnattendedPermanently(ContextRz context)
        {
            try
            {
                //run the duty monitor checking on this thread
                context.TheSysRz.TheDutyLogic.DutiesLoadCheck(context);
                int interval = context.TheSysRz.TheDutyLogic.DutyIntervalMilliseconds;

                while (true)
                {
                    System.Threading.Thread.Sleep(interval);
                    CheckAll(context);
                }
            }
            catch (Exception ex)
            {
                context.TheLeader.Error(ex);
            }
        }

        public virtual nDuty DutyObjectCreate(String name)
        {
            switch(name.ToLower().Trim())
            {
                case "stock export":
                    return new Duty_StockExport();
                case "excess export":
                    return new Duty_ExcessExport();
                case "truncate database log":
                    return new Duty_TruncateDatabaseLog();
                case "stock exports/uploads":
                case "stock export and upload":
                    return new Duty_StockExportAndUpload();
                case "reindex database":
                    return new Duty_ReindexDatabase();
                case "backup database":
                    return new Duty_BackUpDB();
                case "rte":
                    return new Duty_RTE();
                case "rzrescue":
                    return new RzRescueDuty();
                case "rzlink":
                    return new RzLinkDuty();
                case "droptemptables":
                    return new Duties.DropTempTables();
                case "calculate stats":
                    return new Duty_CalculateStats();
                case "closebooks":
                    return new Duties.Duty_CloseBooks();
                default:
                    return new nDuty(name, name);
            }
        }

        public virtual LeaderServiceRz DutyLeaderCreate()
        {
            return new LeaderServiceRz();
        }
    }

    public delegate void ThreadDoneHandler(DutyRunHandle dh);
}
