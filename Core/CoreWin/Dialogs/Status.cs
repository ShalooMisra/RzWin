using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CoreWin
{
    public partial class Status : Form
    {
        public Status()
        {
            InitializeComponent();
            if( Tools.Style.StyleCurrent != null )
                this.Icon = Tools.Style.StyleCurrent.IconFormDefault;
        }

        delegate void SetStatusArgsHandler(String status);        
        
        public void SetStatus(String status)
        {
            if (InvokeRequired)
                Invoke(new SetStatusArgsHandler(ActuallySetStatus), new Object[] { status });
            else
                ActuallySetStatus(status);
        }
        public void ActuallySetStatus(String status)
        {
            txtStatus.Text = status + "\r\n" + Tools.Strings.Left(txtStatus.Text, 4000);
            this.Refresh();
            txtStatus.Refresh();
            System.Windows.Forms.Application.DoEvents();
            System.Windows.Forms.Application.DoEvents();
            System.Windows.Forms.Application.DoEvents();
            System.Windows.Forms.Application.DoEvents();

        }

        public void SetProgress(int p)
        {
            if (InvokeRequired)
                Invoke(new ProgressHandler(ActuallySetProgress), new Object[] { null, new ProgressArgs(0, p) });
            else
                ActuallySetProgress(null, new ProgressArgs(0, p));
        }

        public void ActuallySetProgress(Object sender, ProgressArgs args)
        {
            try
            {
                nStatusView1.SetProgressByIndex(null, args);
                System.Windows.Forms.Application.DoEvents();
                System.Windows.Forms.Application.DoEvents();
                System.Windows.Forms.Application.DoEvents();
                System.Windows.Forms.Application.DoEvents();
            }
            catch { }
        }

        public void PopText()
        {
            Tools.FileSystem.PopText(txtStatus.Text);
        }
    }

    public class StatusArgs
    {
        public String status;
        public Int32 index;

        public StatusArgs(Int32 i, String s)
        {
            index = i;
            status = s;
        }
    }

    public class ProgressArgs
    {
        public Int32 progress;
        public Int32 index;

        public ProgressArgs(Int32 i, Int32 percent)
        {
            index = i;
            progress = percent;
        }

    }

    public class ActivityArgs
    {
        public ActivityType activity;
        public Int32 index;

        public ActivityArgs(Int32 i, ActivityType t)
        {
            index = i;
            activity = t;
        }
    }

    public delegate void StatusHandler(Object sender, StatusArgs args);
    public delegate void ProgressHandler(Object sender, ProgressArgs args);

    public enum ActivityType
    {
        None = 0,
        Saving = 1,
        Updating = 2,
        Searching = 3,
        Deleting = 4,
    }

    public enum StatusMode
    {
        Normal = 1,
        NoModal = 2,
    }
}