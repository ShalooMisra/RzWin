using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public class nStatusTarget
    {
        public SetStatusDelegate status;
        public SetProgressDelegate progress;
        //public SetStateDelegate state;

        public Control control;

        public nStatusTarget()
        {

        }

        public nStatusTarget(SetStatusDelegate s, SetProgressDelegate p, Control c)  //, SetStateDelegate t
        {
            status = s;
            progress = p;
            //state = t;
            control = c;
        }

        public void SetStatus(String s)
        {
            if( status == null )
                return;

            if (control == null)
                ActuallySetStatus(s);

            if (control.InvokeRequired)
                control.Invoke(new SetStatusDelegate(ActuallySetStatus), new object[] { s });
            else
                ActuallySetStatus(s);
        }

        public void ActuallySetStatus(String s)
        {
            if (status != null)
                status(s);
        }

        public long TotalProgress = 0;
        public long CurrentProgress = 0;

        public void StartProgress(int total)
        {
            TotalProgress = total;
            CurrentProgress = 0;
            SetProgress(0);
        }

        public void AddProgress()
        {
            CurrentProgress++;
            SetProgress(Convert.ToInt32(nTools.CalcPercent(TotalProgress, CurrentProgress)));
        }

        public void ClearProgress()
        {
            TotalProgress = 0;
            CurrentProgress = 0;
            SetProgress(0);
        }

        public void SetProgress(int p)
        {
            if (progress == null)
                return;

            if (control == null)
                ActuallySetProgress(p);

            if (control.InvokeRequired)
                control.Invoke(new SetProgressDelegate(ActuallySetProgress), new object[] { p });
            else
                ActuallySetProgress(p);
        }

        public void ActuallySetProgress(int p)
        {
            if (progress != null)
                progress(p);
        }

        //public void SetState(StatusStateType t)
        //{
        //    if (state == null)
        //        return;

        //    if (control == null)
        //        ActuallySetState(t);

        //    if (control.InvokeRequired)
        //        control.Invoke(new SetStateDelegate(ActuallySetState), new object[] { t });
        //    else
        //        ActuallySetState(t);
        //}

        //public void ActuallySetState(StatusStateType t)
        //{
        //    if (state != null)
        //        state(t);
        //}
    }
}
