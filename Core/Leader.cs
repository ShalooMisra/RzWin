using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Reflection;

using Tools;
using Core.Display;

namespace Core
{
    public class Leader : ILeader
    {
        public bool TestMode = false;
        bool HtmlMode = false;

        public List<String> ErrorList = new List<string>();
        public bool ErrorsOccurred = false;

        StringBuilder sb;
        public void HtmlInit()
        {
            sb = new StringBuilder();
            HtmlMode = true;
        }

        public String Html
        {
            get
            {
                if (sb == null)
                    return "";
                else
                    return sb.ToString();
            }
        }

        public void Error(String s)
        {
            Error(s, false);
        }

        public virtual void Error(String s, bool hide_message)
        {
            if (hide_message)
                Comment("Error: " + s, InfoGrade.Negative);
            else
                Tell(s);

            if (HtmlMode)
            {
                ErrorsOccurred = true;
                ErrorList.Add(s);
                sb.AppendLine("<br><b><font color=\"red\">" + Tools.Html.ConvertTextToHTML(s) + "</font></b>");
            }
        }

        public void Error(Exception ex)
        {
            Error("Error in " + Tools.Strings.GetFirstLine(ex.StackTrace) + ": " + ex.Message);
        }

        public void Error(String location, String message)
        {
            Error("Error in " + location + ": " + message);
        }

        public bool NotifyIgnore = false;
        public virtual void Notify(String note)
        {
            if (NotifyIgnore)
                return;

            TellTemp(note);
        }

        public virtual void Clear()
        {
            if( HtmlMode )
                sb = new StringBuilder();
        }

        public virtual void Done()
        {
            Comment("Done");
        }

        public long ProgressTotal = -1;
        public long ProgressCurrent = -1;

        public Double ProgressPercent
        {
            get
            {
                if (ProgressTotal <= 0 || ProgressCurrent <= 0)
                    return 0;

                return Tools.Number.CalcPercent(Convert.ToDouble(ProgressTotal), Convert.ToDouble(ProgressCurrent));
            }

            set
            {

            }
        }

        public virtual void ProgressStart(long total, String start = "")
        {
            ProgressTotal = total;
            ProgressCurrent = 0;
            Comment(start);
        }

        public virtual void ProgressEnd()
        {
            ProgressEnd("Done.", InfoGrade.Neutral);
        }

        public virtual void ProgressEnd(long passed, long failed)
        {
            InfoGrade g = InfoGrade.Positive;
            if (failed > 0)
                g = InfoGrade.Negative;
            ProgressEnd("Done: " + passed.ToString() + " passed, " + failed.ToString() + " failed.", g);
        }

        public virtual void ProgressEnd(String comment, InfoGrade info_grade)
        {
            ProgressAdd(comment, info_grade, ProgressTotal - ProgressCurrent);  //force it to 100%
            ProgressCurrent = -1;
            ProgressTotal = -1;
        }

        public virtual void ProgressAdd()
        {
            ProgressAdd("");
        }

        public virtual void ProgressAdd(String comment)
        {
            ProgressAdd(comment, InfoGrade.Neutral, 1);
        }

        public virtual void ProgressAdd(String comment, InfoGrade info_grade)
        {
            ProgressAdd(comment, info_grade, 1);
        }

        public virtual void ProgressAdd(String comment, InfoGrade info_grade, long add)
        {
            try
            {
                if (comment != "")
                    Comment(comment, info_grade);

                ProgressCurrent += add;
                ProgressUpdate(Convert.ToInt32(Tools.Number.CalcPercent(ProgressTotal, ProgressCurrent)));
            }
            catch { }
        }

        public event StatusSetHandler StatusSet;
        public event ProgressSetHandler ProgressSet;

        public virtual void ProgressUpdate(int percent)
        {
            if (ProgressSet != null)
                ProgressSet(percent);
        }

        public virtual void ProgressClear()
        {
            ProgressUpdate(0);
        }

        public void Comment(String comment)
        {
            Comment(comment, Color.Gray);
        }

        public void Comment(String comment, InfoGrade grade)
        {
            switch (grade)
            {
                case InfoGrade.Positive:
                    Comment(comment, Color.Green);
                    break;
                case InfoGrade.Negative:
                    Comment(comment, Color.Red);
                    break;
                default:
                    Comment(comment, Color.Gray);
                    break;
            }
        }

        public virtual void Comment(String comment, Color color)
        {
            try
            {
                if (StatusSet != null)
                    StatusSet(comment, color);
            }
            catch
            {
                ;
            }

            if( HtmlMode )
                sb.AppendLine("<br><font color=\"" + Tools.Html.GetHTMLColor(color.ToArgb()) + "\">" + Tools.Html.ConvertTextToHTML(comment) + "</font>");
        }

        public void CommentEllipse(String comment)
        {
            Comment(comment + "...");
        }

        public String AskForString(String caption)
        {
            return AskForString(caption, "", false);
        }
      
        public String AskForString(String prompt, String default_value)
        {
            return AskForString(prompt, default_value, false);
        }

        public String AskForString(String prompt, String default_value, bool multi_line)
        {
            return AskForString(prompt, default_value, multi_line, prompt);
        }
        
        public virtual String AskForString(String prompt, String default_value, string caption)
        {
            return AskForString(prompt, default_value, false, caption);
        }

        public virtual String AskForString(String prompt, String default_value, bool multi_line, string caption)
        {
            throw new NotImplementedException();
        }
        public Int32 AskForInt32(String caption, int default_value, String title)
        {
            bool cancel = false;
            return AskForInt32(caption, default_value, title, ref cancel);
        }

        public virtual Int32 AskForInt32(String caption, int default_value, String title, ref bool cancelled)
        {
            cancelled = true;
            Error("AskForInt32 isnt implemented");
            return 0;
        }

        public virtual Double AskForDouble(String caption, Double default_value, String title, ref bool cancelled)
        {
            cancelled = true;
            Error("AskForDouble isnt implemented");
            return 0;
        }

        public virtual DateTime AskForDate(String caption, DateTime default_value)
        {
            return Tools.Dates.GetNullDate();
        }

        public virtual DateTime AskForDate(String caption, DateTime default_value, bool show_time = true)
        {
            return Tools.Dates.GetNullDate();
        }

        public virtual DateTime AskForDate(String caption, DateTime start,Dictionary<string, string> properties)
        {
            return Tools.Dates.GetNullDate();
        }


        public virtual String AskForFile(String caption)
        {
            throw new NotImplementedException();
        }

        public virtual String AskForStringFromArray(String prompt, String default_value, List<String> a)
        {
            Error("AskForStringFromArray isn't implemented");
            return "";
        }

        public virtual bool AreYouSure(String ask)
        {
            Comment("Are you sure " + ask + "?");
            return FastForwardMode;
        }

        public virtual bool AskYesNo(String ask)
        {
            Comment(ask);
            return FastForwardMode;
        }


        //KT      
        public virtual bool AskYesNoLarge(String ask, string title)
        {
            Comment(ask);
            return FastForwardMode;
        }

        public virtual bool OkCancelFormatting(string title, string body)
        {
            Comment(title);
            return FastForwardMode;
        }

        public bool SuggestionsIgnore = false;
        public virtual bool SuggestYesNo(String ask)
        {
            if (SuggestionsIgnore)
                return false;

            return AskYesNo(ask);
        }

        public Object ChooseFromObjects(List<Object> objects)
        {
            return ChooseFromObjects(objects, null);
        }

        public virtual Object ChooseFromObjects(List<Object> objects, Object auto_choose)
        {
            return null;
        }

        public virtual void Tell(String tell)
        {
            Comment(tell);
        }

        public virtual void TellTemp(String tell)
        {
            Comment(tell);
        }

        public virtual void ShowText(String text)
        {

        }

        public virtual String AskForFolder()
        {
            throw new NotImplementedException();
        }

        public virtual String ChooseBetweenStrings(String caption, List<String> choices)
        {
            throw new NotImplementedException();
        }

        public String ChooseBetweenStrings(String caption, String[] choices)
        {
            List<String> strings = new List<string>();
            foreach (String s in choices)
            {
                strings.Add(s);
            }
            return ChooseBetweenStrings(caption, strings);
        }

        public void ShowNoRight()
        {
            ShowNoRight("");
        }
        public void ShowNoRight(String s)
        {
            if (Tools.Strings.StrExt(s))
                Error("This system is not configured to access this function: " + s);
            else
                Error("This system is not configured to access this function.");
        }

        //public bool Show(Context x, IItem item)
        //{
        //    ItemsInstance instance = new ItemsInstance();
        //    instance.Add( x, item);
        //    return Show(x, instance);
        //}

        public virtual bool Show(Context x, ShowArgs args)
        {
            return false;
        }

        public virtual void Start(Context context, Trail t)
        {
            Follow(context, t);
        }

        public virtual void Follow(Context context, Trail t)
        {
            if (t.CanceledIs)
            {
                TrailCanceled(context, t);
                return;
            }

            foreach (Stop s in t.StopsList)
            {
                if (t.CanceledIs)
                {
                    TrailCanceled(context, t);
                    return;
                }

                if (!s.CompleteIs)
                {
                    s.Prepare(context);
                    if (!s.CompleteIs)
                    {
                        if (!Follow(context, s))
                        {
                            return;
                        }
                    }
                }
            }

            if (!t.CanceledIs)
                t.Finished(context);
        }

        public virtual bool Follow(Context context, Stop stop)
        {
            return false;
        }

        public virtual void ShowList(Context context, String caption, List<IItem> items)
        {
            foreach (IItem i in items)
            {
                Show(context, new ShowArgs(context, i));
            }
        }

        public virtual void TrailCanceled(Context context, Trail trail)
        {

        }

        public virtual List<DisplayHandle> DisplayHandlesList
        {
            get
            {
                List<DisplayHandle> ret = new List<DisplayHandle>();
                return ret;
            }
        }

        public virtual void ViewsClose(IItem item)
        {

        }

        public virtual void ViewsCloseAll()
        {

        }

        public virtual IItem ItemShownByTag(Context x, ItemTag t)
        {
            return null;
        }

        public virtual void StartPopStatus(String initial_status = "")
        {
        }

        public virtual void StopPopStatus(bool leaveWindowOpen = true)
        {

        }

        public virtual IView ViewCreate(Context x, ShowArgs args)
        {
            return null;
        }

        public virtual void ShowHtml(Context x, String caption, String html)
        {

        }

        public virtual void FolderShow(String folder)
        {

        }

        public virtual void FileShow(String file)
        {

        }

        protected StringBuilder FastForwardLog;
        public bool FastForwardMode = false;
        public void FastForwardStart()
        {
            FastForwardLog = new StringBuilder();
            FastForwardMode = true;
            NotifyIgnore = true;
            SuggestionsIgnore = true;
        }

        public String FastForwardEnd()
        {
            String ret = FastForwardLog.ToString();
            FastForwardEnd(false);
            return ret;
        }

        public void FastForwardEnd(bool showLog)
        {
            FastForwardMode = false;
            if (showLog)
            {
                if( Tools.Strings.StrExt(FastForwardLog.ToString()) )
                    ShowText(FastForwardLog.ToString());
            }
        }

        public virtual Color ChooseColor(Color start, ref bool cancel)
        {
            cancel = true;
            return start;
        }

        public ImageHandle ChooseImage(ref bool noneSelected)
        {
            return ChooseImage(IconsList(), ref noneSelected);
        }

        public virtual ImageHandle ChooseImage(List<ImageHandle> images, ref bool noneSelected)
        {
            return null;
        }

        public virtual void IconsAppend(List<ImageHandle> icons)
        {
        }

        List<ImageHandle> Icons;
        public List<ImageHandle> IconsList()
        {
            if (Icons == null)
            {
                Icons = new List<ImageHandle>();
                IconsAppend(Icons);
            }
            return Icons;
        }

        //public virtual String ExportFolder
        //{
        //    get
        //    {
        //        return "";
        //    }
        //}

        //public virtual void ShowFile(String file)
        //{

        //}

        public void Reorg()
        {
            Error("Reorg");
        }

        public virtual void CloseProgram()
        {
            throw new NotImplementedException("Close Program");
        }

        public virtual void ShowSql(String sql)
        {
            throw new NotImplementedException("Close Program");
        }

        public virtual String AskForPaste()
        {
            return AskForString("", "", true);
        }

        public virtual void BrowseUrl(String url)
        {

        }

        public virtual string ChooseOneString(Context x, String caption, List<String> choices)
        {
            throw new NotImplementedException("ChooseOneString");
        }

        public virtual String GetClipboardText()
        {
            throw new NotImplementedException("GetClipboardText");
        }

        public virtual void SetClipboardText(String text)
        {
            throw new NotImplementedException("SetClipboardText");
        }

        public virtual string ChooseAFile()
        {
            throw new NotImplementedException("ChooseAFile");
        }

        //public virtual String ShowHtml(String caption, String html)
        //{
        //    throw new NotImplementedException("ShowHtml");
        //}

        public virtual String BilgePath(Context x)
        {
            return @"c:\bilge\";
        }

        public Leader Clone()
        {
            Leader ret = (Leader)Activator.CreateInstance(GetType());
            Apply(ret);
            return ret;
        }

        protected virtual void Apply(Leader leader)
        {

        }
    }


    //public class LeaderEvent : Leader
    //{
    //    public event StatusSetHandler StatusSet;
    //    public event ProgressSetHandler ProgressSet;

    //    public override void Comment(string comment, Color color)
    //    {
    //        base.Comment(comment, color);
    //        if (StatusSet != null)
    //            StatusSet(comment, color);
    //    }

    //    public override void ProgressUpdate(int percent)
    //    {
    //        base.ProgressUpdate(percent);
    //        if (ProgressSet != null)
    //            ProgressSet(percent);
    //    }
    //}

    public class LeaderText : Leader
    {
        StringBuilder sb = new StringBuilder();

        public String Text
        {
            get
            {
                return sb.ToString();
            }
        }

        public override void Clear()
        {
            base.Clear();
            sb = new StringBuilder();
        }

        public override void Comment(string comment, System.Drawing.Color color)
        {
            base.Comment(comment, color);
            sb.AppendLine(comment);
        }

        public override void Error(String s, bool hide_message)
        {
            sb.AppendLine("Error: " + s);
        }
    }

    public delegate void StatusSetHandler(String s, Color c);
    public delegate void ProgressSetHandler(int percent);

    public enum InfoGrade
    {
        Neutral = 0,
        Positive = 1,
        Negative = 2,
    }

    public enum ViewType
    {
        Unknown = 0,
        SingleItem = 1,         //plain view
        Wide = 2,           //full width, minimal height
        Tall = 3,           //full height, minimal width
        Box = 4,            //thumbnail version of normal
        Line = 5,           //control as a vertical list of lines
        Point = 6,          //just a dot
        ListControls = 7,   //vertical list of controls
        ListGrid = 8,       //nList-style grid
    }

    public enum ViewTarget
    {
        New = 0,
        Same = 1,
    }

    public delegate void ShowHandler(Context x, ShowArgs args);

    public class ShowArgs
    {
        public Dictionary<string, string> AdditionalIDs = new Dictionary<string, string>(); 
        public ViewType TheViewType = ViewType.Unknown;
        public ViewTarget TheViewTarget = ViewTarget.New;

        public String ClassId;
        public IItems TheItems;

        //NM stuff that should be re-considered
        public IView ViewUsed;
        public bool ShowChanges = false;
        public bool Handled = false;
        public bool ShowModal = false;
        public String ExtraData = "";
        //public bool ShowDefault = false;
        public bool DisableEdit = false;
        public bool ForceReshow = false;

        public ShowArgs()
        {

        }

        public ShowArgs(String class_id)
        {
            ClassId = class_id;
            TheViewType = ViewType.SingleItem;
        }

        public ShowArgs(Context x, ViewType t, IItems items)
        {
            TheViewType = t;
            TheItems = items;
            ClassId = items.FirstGet(x).ClassId;
        }

        public ShowArgs(ViewType t)
        {
            TheViewType = t;
        }

        public ShowArgs(ViewTarget t)
        {
            TheViewTarget = t;
        }

        public ShowArgs(Context context, IItems items)
        {
            ClassId = items.FirstGet(context).ClassId;
            TheItems = items;
            TheViewType = ViewType.SingleItem;
        }
    }

    public class DisplayHandle
    {
        public IItem TheItem;
        public Object TheDisplayObject;
    }

    public interface ILeader
    {
        void Comment(String comment);
        void CommentEllipse(String comment);
        void StartPopStatus(String start);
        void StopPopStatus(bool leaveFormOpen);
        bool AreYouSure(String sure);
        void Tell(String tell);
        void Error(String error);
        void Error(Exception error);
        bool AskYesNo(String ask);
        //KT
        bool AskYesNoLarge(String ask, string title);
        bool OkCancelFormatting(string title, string body);
        String AskForString(String prompt);
        String AskForString(String prompt, String default_value);
        String AskForString(String prompt, String default_value, string caption);
        String AskForString(String prompt, String default_value, bool multi_line, string caption);
        Int32 AskForInt32(String caption, int default_value, String title);
        void BrowseUrl(String url);
        void ProgressStart(long total, String start = "");
        void ProgressEnd();
        void ProgressAdd();
        string ChooseOneString(Context x, String caption, List<String> choices);
        String GetClipboardText();
        void SetClipboardText(String text);
        string ChooseAFile();
        void ShowHtml(Context x, String caption, String html);
        String AskForFile(String caption);
        String BilgePath(Context x);
        void ShowText(String text);
        void HtmlInit();
        String Html { get; }
        DateTime AskForDate(String caption, DateTime default_value);
        DateTime AskForDate(String caption, DateTime default_value, bool show_time = false);
        DateTime AskForDate(String caption, DateTime start,  Dictionary<string, string> properties);
        Double AskForDouble(String caption, Double default_value, String title, ref bool cancelled);
    }
}
