using System;
using System.Collections;
using System.Text;
using System.IO;

namespace NewMethod
{

    //public class nStatus
    //{

    //    //public static event StatusHandler SetStatus;
    //    //public static event ProgressHandler SetProgress;

    //    public static bool PopStatus;
    //    public static Int32 CurrentChannel;
    //    public static nChannel TheChannel;
    //    public static Stack AllChannels;
    //    public static ArrayList StatusViews;
    //    public static bool Tracing;
    //    public static ArrayList Traces;
    //    public static ArrayList LogStrings;
    //    //public static Int64 LastTraceTime;
    //    //public static String LastTraceText;
    //    public static nTrace CurrentTrace;
    //    public static StatusMode CurrentMode = StatusMode.Normal;

    //    static bool UseLogFile = false;
    //    static System.IO.StreamWriter LogFile;
    //    static String LogFileName = "";

    //    static nStatus()
    //    {
    //        Reset();
    //    }

    //    public static void RegisterStatusView(IStatusView v)
    //    {
    //        if (StatusViews == null)
    //            StatusViews = new ArrayList();

    //        StatusViews.Add(v);
    //    }

    //    public static void UnRegisterStatusView(IStatusView v)
    //    {
    //        try
    //        {
    //            StatusViews.Remove(v);
    //        }
    //        catch (Exception)
    //        { }
    //    }

    //    public static void SetStatus(String s)
    //    {
    //        SetStatus(null, new StatusArgs(0, s));
    //    }

    //    public static void SetStatus(Object s, StatusArgs a)
    //    {
    //        if (StatusViews != null)
    //        {
    //            try
    //            {
    //                foreach (IStatusView v in StatusViews)
    //                {
    //                    v.SetStatusByIndex(s, a);
    //                }
    //            }
    //            catch (Exception)
    //            { }
    //        }

    //        if (SysNewMethod.ContextDefault != null)
    //        {
    //            if( SysNewMethod.ContextDefault.TheLeader != null )
    //                SysNewMethod.ContextDefault.TheLeader.Comment(a.status);
    //        }

    //        //SysNewMethod.ContextDefault.TheLeader.Comment(a.status);
    //        //try
    //        //{
    //        //    if (StatusViews != null)
    //        //    {
    //        //        try
    //        //        {
    //        //            foreach (IStatusView v in StatusViews)
    //        //            {
    //        //                v.SetStatusByIndex(s, a);
    //        //            }
    //        //        }
    //        //        catch (Exception)
    //        //        { }
    //        //    }

    //        //    if (Tracing)
    //        //        AddTrace(a.status);

    //        if (UseLogFile)
    //            WriteLogFile(a.status);

    //        //    foreach (LogString ls in LogStrings)
    //        //    {
    //        //        ls.AddLine(a.status);
    //        //    }

    //        //    if (nStatus.StatusForm != null)
    //        //        nStatus.StatusForm.SetStatus(a);
    //        //}
    //        //catch { }
    //    }

    //    public static void Error(String s)
    //    {
    //        TellUser(s);
    //    }

    //    public static void SetProgress(Int32 progress)
    //    {
    //        SetProgress(null, new ProgressArgs(0, progress));
    //        //SetProgress(null, new ProgressArgs(CurrentChannel, progress));
    //    }

    //    public static void SetProgress(Object s, ProgressArgs a)
    //    {
    //        if (StatusViews != null)
    //        {
    //            try
    //            {
    //                foreach (IStatusView v in StatusViews)
    //                {
    //                    v.SetProgressByIndex(s, a);
    //                }
    //            }
    //            catch (Exception)
    //            { }
    //        }

    //        if (SysNewMethod.ContextDefault != null)
    //            SysNewMethod.ContextDefault.TheLeader.ProgressUpdate(a.progress);
    //    }

    //    public static void Reset()
    //    {
    //        PopStatus = false;
    //        Tracing = false;
    //        CurrentChannel = 0;

    //        TheChannel = new nChannel();
    //        TheChannel.ChannelIndex = 0;

    //        AllChannels = new Stack();
    //        AllChannels.Push(TheChannel);
    //        LogStrings = new ArrayList();
    //        Clear();
    //    }

    //    public static void Clear()
    //    {
    //        SetStatus(null, new StatusArgs(CurrentChannel, ""));
    //        SetProgress(null, new ProgressArgs(CurrentChannel, 0));
    //    }


    //    public static void UpChannel()
    //    {
    //        CurrentChannel++;
    //        nChannel xChannel = new nChannel();
    //        xChannel.ChannelIndex = CurrentChannel;
    //        xChannel.CurrentProgress = 0;
    //        xChannel.TotalProgress = 0;
    //        AllChannels.Push(xChannel);
    //        TheChannel = xChannel;

    //        if (StatusViews != null)
    //        {
    //            foreach (IStatusView v in StatusViews)
    //            {
    //                v.AddLine();
    //            }
    //        }
    //    }

    //    public static void DownChannel()
    //    {
    //        Clear();
    //        if (AllChannels.Count > 0)
    //            AllChannels.Pop();

    //        CurrentChannel--;
    //        if (CurrentChannel < 0)
    //            TellUser("Status Undervalue");
    //        else
    //            TheChannel = (nChannel)AllChannels.Peek();

    //        if (StatusViews != null)
    //        {
    //            foreach (IStatusView v in StatusViews)
    //            {
    //                v.RemoveLine();
    //            }
    //        }
    //    }

    //    public static void StartPercent(Int64 total)
    //    {
    //        TheChannel.TotalProgress = total;
    //        TheChannel.CurrentProgress = 0;
    //        SetProgress(0);
    //    }

    //    public static void StopPercent()
    //    {
    //        SetProgress(0);
    //    }

    //    public static void AddPercent()
    //    {
    //        TheChannel.CurrentProgress++;
    //        SetPercent();
    //    }

    //    public static void SetPercent()
    //    {
    //        int intPercent = 0;

    //        if (TheChannel.CurrentProgress > 0)
    //        {
    //            try
    //            {
    //                intPercent = Convert.ToInt32((Convert.ToDouble(TheChannel.CurrentProgress) / Convert.ToDouble(TheChannel.TotalProgress)) * 100);
    //            }
    //            catch { }
    //        }
    //        else
    //        {
    //            intPercent = 0;
    //        }
    //        SetProgress(null, new ProgressArgs(CurrentChannel, intPercent));
    //    }

    //    public static String GetPaste(System.Windows.Forms.IWin32Window owner)
    //    {
    //        return ToolsWin.Dialogs.Paste.AskForPaste();
    //    }

    //    public static String InputMessageBox(String strPrompt, String strDefault, String strCaption, System.Windows.Forms.IWin32Window owner)
    //    {
    //        return ToolsWin.Dialogs.Ask.AskString(false, strPrompt, strDefault, strCaption, owner);
    //    }

    //    public static String InputMessageBoxMultiLine(String strPrompt, String strDefault, String strCaption, System.Windows.Forms.IWin32Window owner)
    //    {
    //        return ToolsWin.Dialogs.Ask.AskString(true, strPrompt, strDefault, strCaption, owner);
    //    }

    //    public static bool AreYouSure()
    //    {
    //        return AreYouSure("continue");
    //    }

    //    public static bool AreYouSure(String message)
    //    {
    //        return AreYouSure(message, null, "");
    //    }

    //    public static bool AreYouSure(String message, System.Windows.Forms.IWin32Window owner)
    //    {
    //        return AreYouSure(message, owner, "");
    //    }

    //    public static bool AreYouSure(String message, System.Windows.Forms.IWin32Window owner, String strExtra)
    //    {
    //        String s = message;
    //        if (Tools.Strings.StrExt(strExtra))
    //            s += "\r\n\r\n\r\n" + strExtra;

    //        if (CurrentMode == StatusMode.Normal)
    //        {
    //            return ToolsWin.Dialogs.AreYouSure.Ask(owner, s);
    //            //return System.Windows.Forms.MessageBox.Show(owner, s, "Sure?", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes;
    //        }
    //        else
    //            return AskUser_YesNo_Temp(s);
    //    }

    //    public static void TellUser(string p)
    //    {
    //        if (CurrentMode == StatusMode.Normal)
    //            System.Windows.Forms.MessageBox.Show(p);
    //        else
    //        {
    //            //TellUserTemp(p);
    //            WriteLogFile(p);
    //            SetStatus(p);
    //        }
    //    }
    //    public static void TellSaved()
    //    {
    //        TellUser("Saved.");
    //    }
    //    //public static void TellUserTemp(string p)
    //    //{
    //    //    TellUserTemp(p, null);
    //    //}
    //    //public static void TellUserTemp(string p, System.Windows.Forms.IWin32Window owner)
    //    //{
    //    //    ToolsWin.Dialogs.Tell.TellTemp(owner, "", p, 4);
    //    //    //Tell xForm = new Tell();
    //    //    //xForm.SetCaption(p);
    //    //    //xForm.ShowDialog(owner);
    //    //}

    //    public static bool AskUser_YesNo(String strAsk)
    //    {
    //        return SysNewMethod.ContextDefault.TheLeader.AskYesNo(strAsk);
    //        //if (CurrentMode == StatusMode.Normal)
    //        //    return ToolsWin.Dialogs.YesNo.Ask(strAsk);
    //        //else
    //        //    return AskUser_YesNo_Temp(strAsk);

    //        //                return (System.Windows.Forms.MessageBox.Show(strAsk, "", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes);

    //    }

    //    public static bool AskUser_YesNo_Temp(String strAsk)
    //    {
    //        frmAskTemp xForm = new frmAskTemp();
    //        xForm.CompleteLoad(strAsk);
    //        xForm.ShowDialog();
    //        bool b = xForm.Answer;
    //        xForm.Close();
    //        xForm.Dispose();
    //        xForm = null;
    //        return b;
    //    }

    //    public static System.Windows.Forms.DialogResult AskUser_YesNoCancel(String strAsk)
    //    {
    //        return System.Windows.Forms.MessageBox.Show(strAsk, "", System.Windows.Forms.MessageBoxButtons.YesNoCancel);
    //    }

    //    public static int AskUser_Integer(String strPrompt, System.Windows.Forms.IWin32Window owner)
    //    {
    //        return AskUser_Integer(strPrompt, 0, owner);
    //    }
    //    public static int AskUser_Integer(String strPrompt, Int32 default_value, System.Windows.Forms.IWin32Window owner)
    //    {
    //        String v = "";
    //        if (default_value > 0)
    //            v = default_value.ToString();
    //        String s = context.TheLeader.AskForString(strPrompt, v, "", owner);
    //        try
    //        {
    //            return Convert.ToInt32(s);
    //        }
    //        catch (Exception)
    //        {
    //            return 0;
    //        }
    //    }

    //    public static String AskUser_String(String strPrompt, System.Windows.Forms.IWin32Window owner)
    //    {
    //        return AskUser_String(strPrompt, "", owner);
    //    }
    //    public static String AskUser_String(String strPrompt, String default_value, System.Windows.Forms.IWin32Window owner)
    //    {
    //        String v = "";
    //        if (Tools.Strings.StrExt(default_value))
    //            v = default_value;
    //        String s = context.TheLeader.AskForString(strPrompt, v, "", owner);
    //        return s;
    //    }


    //    public static long AskUser_Long(String strPrompt, long default_val, System.Windows.Forms.IWin32Window owner)
    //    {
    //        String s = context.TheLeader.AskForString(strPrompt, default_val.ToString(), "", owner);
    //        try
    //        {
    //            return Convert.ToInt64(s);
    //        }
    //        catch (Exception)
    //        {
    //            return 0;
    //        }
    //    }

    //    public static n_choices ChooseAChoice(SysNewMethod s)
    //    {
    //        frmChooseChoice xForm = new frmChooseChoice();
    //        xForm.xSys = s;
    //        xForm.LoadChoices();
    //        xForm.ShowDialog();
    //        return xForm.SelectedChoices;
    //    }

    //    public static void StartTrace()
    //    {
    //        Tracing = true;
    //        Traces = new ArrayList();
    //        CurrentTrace = null;
    //        AddTrace("Trace Started");
    //    }

    //    public static void AddTrace(String s)
    //    {
    //        if (CurrentTrace != null)
    //            CurrentTrace.End = Tools.Misc.GetTicks();

    //        nTrace t = new nTrace();
    //        t.Start = Tools.Misc.GetTicks();
    //        t.End = 0;
    //        t.Status = s;
    //        Traces.Add(t);
    //        CurrentTrace = t;
    //    }

    //    public static void StopTrace()
    //    {
    //        Tracing = false;
    //        StringBuilder s = new StringBuilder();

    //        if (CurrentTrace != null)
    //            CurrentTrace.End = Tools.Misc.GetTicks();

    //        foreach (nTrace t in Traces)
    //        {
    //            s.AppendLine(t.ToString());
    //        }
    //        Tools.FileSystem.PopText(s.ToString());
    //    }

    //    public static void NeedImplement(String s)
    //    {
    //        TellUser("Please notify Recognin that " + s + " needs to be implemented.");
    //    }

    //    public static void ShowNoRight()
    //    {
    //        ShowNoRight("");
    //    }
    //    public static void ShowNoRight(String s)
    //    {
    //        if (Tools.Strings.StrExt(s))
    //            context.TheLeader.Error("This system is not configured to access this function: " + s);
    //        else
    //            context.TheLeader.Error("This system is not configured to access this function.");
    //    }

    //    public static void StartLogFile()
    //    {
    //        String s = Tools.FileSystem.GetAppPath() + "status.txt";
    //        StartLogFile(s);
    //    }

    //    public static void StartNamedDatedLogFile(String strName)
    //    {
    //        String s = Tools.Folder.ConditionFolderName(nTools.GetAppParentPath()) + "Logs\\";  // 2009_11_30 used to be app path, but that doesn't work with the named folder system
    //        if (!Directory.Exists(s))
    //            Directory.CreateDirectory(s);

    //        s += strName + "_" + Tools.Folder.GetNowPath() + ".log";
    //        StartLogFile(s);
    //    }

    //    public static void StartLogFile(String strFile)
    //    {
    //        try
    //        {
    //            if (System.IO.File.Exists(strFile))
    //                nTools.TryDeleteFile(strFile);

    //            LogFileName = strFile;
    //            LogFile = new System.IO.StreamWriter(LogFileName, false);
    //            LogFile.WriteLine(System.DateTime.Now.ToString() + "  :  Start.");
    //            LogFile.Close();
    //            UseLogFile = true;
    //        }
    //        catch  //don't require write access to the folder...
    //        {
    //            LogFileName = "";
    //            UseLogFile = false;
    //        }
    //    }

    //    public static void StopLogFile()
    //    {
    //        UseLogFile = false;
    //        LogFileName = "";
    //        if (LogFile != null)
    //            LogFile.Close();
    //    }

    //    public static void WriteLogFile(String s)
    //    {
    //        try
    //        {
    //            if (!Tools.Strings.StrExt(LogFileName))
    //                LogFileName = "c:\\RzLog.txt";

    //            LogFile = new System.IO.StreamWriter(LogFileName, true);
    //            LogFile.WriteLine(System.DateTime.Now.ToString() + "  :  " + s);
    //            LogFile.Close();
    //        }
    //        catch { }
    //    }

    //    public static void Done()
    //    {
    //        Done("");
    //    }

    //    public static void Done(String s)
    //    {
    //        if (Tools.Strings.StrExt(s))
    //            context.TheLeader.Tell("Done: " + s);
    //        else
    //            context.TheLeader.Tell("Done.");
    //    }


    //    public static bool TryStartPopStatus()
    //    {
    //        //if (StatusForm != null)
    //        //    return false;

    //        //return StartPopStatus();
    //        return StartPopStatus();
    //    }

    //    public static bool StartPopStatus(String initial_status)
    //    {
    //        SysNewMethod.ContextDefault.TheLeader.StartPopStatus(initial_status);
    //        return true;
    //    }

    //    public static bool StartPopStatus()
    //    {
    //        SysNewMethod.ContextDefault.TheLeader.StartPopStatus("");
    //        return true;
    //    }

    //    public static void StopPopStatus()
    //    {
    //        StopPopStatus(false);
    //    }

    //    public static void StopPopStatus(bool LeaveFormOpen)
    //    {
    //        SysNewMethod.ContextDefault.TheLeader.StopPopStatus(LeaveFormOpen);
    //    }

    //    public static void StartLogString(String strName)
    //    {
    //        LogString l = new LogString(strName);
    //        LogStrings.Add(l);
    //    }

    //    public static String StopLogString(String strName)
    //    {
    //        LogString l = GetLogString(strName);
    //        if (l == null)
    //            return "";

    //        LogStrings.Remove(l);
    //        return l.sb.ToString();
    //    }

    //    public static LogString GetLogString(String strName)
    //    {
    //        foreach (LogString ls in LogStrings)
    //        {
    //            if (Tools.Strings.StrCmp(ls.Name, strName))
    //                return ls;
    //        }
    //        return null;
    //    }
    //}

    //public class nChannel
    //{
    //    public Int32 ChannelIndex;
    //    public Int64 TotalProgress;
    //    public Int64 CurrentProgress;
    //}

    //public class nTrace
    //{
    //    public String Status;
    //    public Int64 Start;
    //    public Int64 End;

    //    public override string ToString()
    //    {
    //        Int64 d = End - Start;
    //        return d.ToString() + " : " + Status;
    //    }
    //}


    //public class LogString
    //{
    //    public String Name;
    //    public StringBuilder sb = new StringBuilder();

    //    public LogString(String s)
    //    {
    //        Name = s;
    //    }

    //    public void AddLine(String s)
    //    {
    //        sb.AppendLine(s);
    //    }
    //}

    //public enum StatusStateType
    //{
    //    Done = 0,
    //    Working = 1,
    //    Error = 2,
    //}

    public delegate void SetStatusDelegate(String s);
    public delegate void SetProgressDelegate(int i);
    //public delegate void SetStateDelegate(StatusStateType t);
}
