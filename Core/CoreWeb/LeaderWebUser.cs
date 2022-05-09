using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Drawing;
using System.Threading;

using Tools;
using Core;
using System.IO;

namespace CoreWeb
{
    public static class DialogDiv
    {
        public static DialogDivDimensions DivDimensions = null;
    }
    public class LeaderWebUser : Leader
    {
        public System.Web.SessionState.HttpSessionState Session;
        public System.Web.HttpRequest Request;
        public System.Web.HttpResponse Response;
        public Page Page;
        public List<ItemTag> ItemsNewWindow = new List<ItemTag>();
        public bool PageIsDialog = false;
        public ManualResetEvent ActionReset;
        public void Flow()
        {
            ActionReset.Set();
        }
        public ViewHandle TheViewHandle;
        public AsyncScreenHandle ScreenHandle;

        public LeaderWebUser(System.Web.SessionState.HttpSessionState session, ViewHandle viewHandle, AsyncScreenHandle screenHandle)
            : this(session)
        {
            TheViewHandle = viewHandle;
            ScreenHandle = screenHandle;
        }
        public LeaderWebUser(System.Web.SessionState.HttpSessionState session)
        {
            Session = session;
        }
        public virtual String ViewPageGet(Context context, String class_name, String item_id)
        {
            return "~/Views/ViewDefault.aspx";
        }
        public static List<String> ItemIdsParse(String ids)
        {
            List<String> ret = new List<string>();
            if (ids == null)
                return ret;
            
            String[] idarray = Tools.Strings.Split(ids, "|");
            foreach (String idline in idarray)
            {
                String id = idline;
                if (Tools.Strings.HasString(id, "_dot_"))
                    id = Tools.Strings.ParseDelimit(id, "_dot_", 2);

                if (Tools.Strings.StrExt(id))
                    ret.Add(id);
            }
            return ret;
        }        
        public override bool Show(Context x, ShowArgs args)
        {
            foreach (IItem i in args.TheItems.AllGet(x))
            {
                if (Request == null || Response == null)
                {
                    String screenCreateUrl = ScreenCreateUrl(x, args);  //needs to pass on the args
                    if (!Tools.Strings.StrExt(screenCreateUrl))
                    {
                        x.TheLeader.Tell("No display found");
                        return false;
                    }                 
                    TheViewHandle.ScriptsToRun.Add("window.open('" + screenCreateUrl + "');");
                    //TheViewHandle.Flow();
                }
                else
                {
                    if (args.TheViewTarget == ViewTarget.New && ((Response != null && Response.IsRequestBeingRedirected) || (Request != null && !Tools.Strings.HasString(Request.Path, "Process.aspx"))))
                    {
                        if (PageIsDialog)
                        {
                            ShowInPage(x, args, i);
                            PageIsDialog = false;
                        }
                        else
                            ItemsNewWindow.Add(new ItemTag(i));
                    }
                    else
                    {
                        ShowInPage(x, args, args.TheItems);
                    }
                }
            }
            return true;
        }
        public String ScreenCreateUrl(Context x, IItem i)
        {
            return ScreenCreateUrl(x, new ShowArgs(x, i));
        }
        public String ScreenCreateUrl(Context x, ShowArgs args)
        {
            Screen screen = ScreenCreate(x, args);
            if (screen == null)
                return "";

            //ViewOrdHedInvoice s = new ViewOrdHedInvoice(x, testInvoice);
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, screen));
            return "View.aspx?screenId=" + screen.Uid;
        }
        public virtual Screen ScreenCreate(Context x, ShowArgs args)
        {
            return null;
        }
        public void ShowInPage(Context x, ShowArgs args, IItems items)
        {
            IItem item = (IItem)items.FirstGet(x);
            Response.ClearHeaders();
            Response.ClearContent();
            Response.Clear();
            Response.Redirect(ViewUrlGet(x, item, args.AdditionalIDs));
        }

        public override void ShowHtml(Context x, string caption, string html)
        {
            //base.ShowHtml(caption, html);
            ScreenShowNewWindow(x, new HtmlScreen(caption, html));
        }

        public String ViewUrlGet(Context context, IItem item)
        {
            return ViewUrlGet(context, item, null);
        }
        public String ViewUrlGet(Context context, IItem item, Dictionary<string, string> aditional_ids)
        {
            String s = ViewPageGet(context, item.ClassId, item.Uid) + "?id=" + item.Uid;
            if (aditional_ids != null)
            {
                if (aditional_ids.Count > 0)
                {
                    foreach (KeyValuePair<string, string> kvp in aditional_ids)
                    {
                        s += "&" + kvp.Key + "=" + kvp.Value;
                    }
                }
            }
            return s;
        }
        public String ViewUrlGet(Context context, String ClassId, String Uid, Dictionary<string, string> aditional_ids)
        {
            String s = ViewPageGet(context, ClassId, Uid) + "?id=" + Uid;
            if (aditional_ids != null)
            {
                if (aditional_ids.Count > 0)
                {
                    foreach (KeyValuePair<string, string> kvp in aditional_ids)
                    {
                        s += "&" + kvp.Key + "=" + kvp.Value;
                    }
                }
            }
            return s;
        }
        public String ViewUrlGet(Context context, String ClassId, String Uid)
        {
            return ViewPageGet(context, ClassId, Uid) + "?id=" + Uid;
        }
        public virtual void HandleAction(Context x, ItemTag item, string action)
        {

        }
        public override void Start(Context context, Trail t)
        {
            Session["trail_" + t.Uid] = t;
            base.Start(context, t);
        }
        public override bool Follow(Context context, Stop stop)
        {
            if (stop is StopAreYouSure)
            {
                Response.Redirect("~/Dialogs/AreYouSure.aspx?trail_id=" + stop.TheTrail.Uid + "&stop_id=" + stop.Uid);
                return false;
            }
            else if (stop is StopYesNo)
            {
                Response.Redirect("~/Dialogs/AreYouSure.aspx?trail_id=" + stop.TheTrail.Uid + "&stop_id=" + stop.Uid);
                return false;
            }
            else
                return false;
        }
        public override void ShowList(Context context, string caption, List<IItem> items)
        {
            //base.ShowList(context, caption, items);

            if (items.Count == 1)
            {
                Show(context, new ShowArgs(context, items[0]));
                return;
            }

            String id = Tools.Strings.GetNewID();
            ItemListHandle h = new ItemListHandle();
            h.Caption = caption;
            h.Items = items;
            Session["list_" + id] = h;

            Response.Redirect("/ItemList.aspx?id=" + id);
        }
        public override void TrailCanceled(Context context, Trail trail)
        {
            base.TrailCanceled(context, trail);
            Response.Redirect("/TrailStatus.aspx?id=" + trail.Uid);
        }
        public String ActivityRender(Context context, Page page)
        {
            StringBuilder sb = new StringBuilder();

            //items to show
            List<ItemTag> temp = new List<ItemTag>(ItemsNewWindow);

            lock (ItemsNewWindow)
            {
                ItemsNewWindow.Clear();
            }

            foreach (ItemTag t in temp)
            {
                sb.AppendLine("window.open('" + page.ResolveUrl(ViewUrlGet(context, t)) + "', '_blank');");
            }

            return sb.ToString();
        }
        public override bool AreYouSure(string ask)
        {
            return AskYesNo("Are you sure you want to " + ask + "?");
        }
        public override bool AskYesNo(string ask)
        {
            if (TheViewHandle == null)
                return base.AskYesNo(ask);

            //add a handle to a static list
            WebThreadHandleYesNo h = new WebThreadHandleYesNo(this, ask);
            WebThreads.Add(h.Uid, h);

            TheViewHandle.ScriptsToRun.Add(h.Script);
            //TheViewHandle.Flow();
            Flow();

            //WebControlReset.Set();

            h.TheEvent.WaitOne();

            return h.Yes;
        }
        public override string AskForString(string prompt, string default_value, bool multi_line, string caption)
        {
            if (TheViewHandle == null)
                return base.AskForString(prompt, default_value, multi_line, caption);

            //add a handle to a static list
            WebThreadHandleAskString h = new WebThreadHandleAskString(this, prompt, default_value, multi_line);
            WebThreads.Add(h.Uid, h);

            TheViewHandle.ScriptsToRun.Add(h.Script);
            //TheViewHandle.Flow();
            Flow();

            h.TheEvent.WaitOne();  //may want a long timeout here, in case the browser's x is clicked, etc.

            return h.Result;
        }
        public override DateTime AskForDate(String caption, DateTime default_value)
        {
            if (TheViewHandle == null)
                return base.AskForDate(caption, default_value);
            WebThreadHandleAskDate h = new WebThreadHandleAskDate(this, caption, default_value);
            WebThreads.Add(h.Uid, h);
            TheViewHandle.ScriptsToRun.Add(h.Script);
            //TheViewHandle.Flow();
            Flow();
            h.TheEvent.WaitOne();
            if (h.Canceled)
                return Tools.Dates.GetNullDate();
            else
                return h.Result;
        }
        public override DateTime AskForDate(String caption, DateTime default_value, bool show_time = false)
        {
            if (TheViewHandle == null)
                return base.AskForDate(caption, default_value, show_time);
            WebThreadHandleAskDate h = new WebThreadHandleAskDate(this, caption, default_value, show_time);
            WebThreads.Add(h.Uid, h);
            TheViewHandle.ScriptsToRun.Add(h.Script);
            //TheViewHandle.Flow();
            Flow();
            h.TheEvent.WaitOne();
            if (h.Canceled)
                return Tools.Dates.GetNullDate();
            else
                return h.Result;
        }
        public override int AskForInt32(String caption, int default_value, String title, ref bool cancelled)
        {
            if (TheViewHandle == null)
                return base.AskForInt32(caption, default_value, title, ref cancelled);
            WebThreadHandleAskInt32 h = new WebThreadHandleAskInt32(this, caption, default_value);
            WebThreads.Add(h.Uid, h);
            TheViewHandle.ScriptsToRun.Add(h.Script);
            //TheViewHandle.Flow();
            Flow();
            h.TheEvent.WaitOne();
            cancelled = h.Canceled;
            return h.Result;
        }
        public override Double AskForDouble(String caption, Double default_value, String title, ref bool cancelled)
        {
            if (TheViewHandle == null)
                return base.AskForDouble(caption, default_value, title, ref cancelled);
            WebThreadHandleAskDouble h = new WebThreadHandleAskDouble(this, caption, default_value);
            WebThreads.Add(h.Uid, h);
            TheViewHandle.ScriptsToRun.Add(h.Script);
            //TheViewHandle.Flow();
            Flow();
            h.TheEvent.WaitOne();
            cancelled = h.Canceled;
            return h.Result;
        }
        public override String AskForFile(string caption)
        {
            if (TheViewHandle == null)
                return base.AskForFile(caption);
            WebThreadHandleAskFile h = new WebThreadHandleAskFile(this, caption);
            WebThreads.Add(h.Uid, h);
            TheViewHandle.ScriptsToRun.Add(h.Script);
            Flow();
            //TheViewHandle.Flow();
            h.TheEvent.WaitOne();
            return h.Result;
        }
        public override String AskForStringFromArray(String prompt, String default_value, List<String> a)
        {
            if (TheViewHandle == null)
                return base.AskForStringFromArray(prompt, default_value, a);
            WebThreadHandleAskList h = new WebThreadHandleAskList(this, prompt, default_value, a);
            WebThreads.Add(h.Uid, h);
            TheViewHandle.ScriptsToRun.Add(h.Script);
            Flow();
            //TheViewHandle.Flow();
            h.TheEvent.WaitOne();
            return h.Result;
        }
        public override string ChooseBetweenStrings(string caption, List<string> choices)
        {
            return AskForStringFromArray(caption, "", choices);
        }
        public override void Tell(string tell)
        {
            if (TheViewHandle == null)
            {
                base.Tell(tell);
                return;
            }

            TheViewHandle.ScriptsToRun.Add("alert('" + tell.Replace("'", "") + "');");
        }
        public void ScreenShow(Context x, Screen s)
        {
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, s));
            ViewHandleRedirect(s.Uid);
        }
        public void ScreenShowNewWindow(Context x, Screen s)
        {
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, s));
            OpenNewWindow("View.aspx?screenId=" + s.Uid);
        }
        void OpenNewWindow(String url)
        {
            TheViewHandle.ScriptsToRun.Add("window.open('" + url + "');");
        }
        public void ViewHandleRedirect(string id)
        {
            if (TheViewHandle == null)
                throw new Exception("No view handle");
            TheViewHandle.ScriptsToRun.Add("Redirect('View.aspx?screenId=" + id + "');");
        }
        public void ScreenShow(Context x, HttpResponse response, Screen s)
        {
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, s));
            response.Redirect("View.aspx?screenId=" + s.Uid);
        }
        public override void FileShow(string file)
        {
            //base.FileShow(file);
            if (TheViewHandle != null)
            {
                TheViewHandle.FilesToDownload.Add(file);
                //TheViewHandle.Flow();
            }
        }
        public static Dictionary<String, WebThreadHandle> WebThreads = new Dictionary<string, WebThreadHandle>();
        public override void BrowseUrl(string url)
        {
            //base.BrowseUrl(url);
            if (TheViewHandle != null)
            {
                TheViewHandle.ScriptsToRun.Add("window.open('" + url + "');");
                //TheViewHandle.Flow();
            }
        }
        public static String DialogSetup
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("$('#dialog_div').parent().css('left', ($(window).width() / 2) - ($('#dialog_div').parent().outerWidth(true) / 2));");
                sb.AppendLine("$('#dialog_div').parent().css('top', ($(window).height() / 2) - ($('#dialog_div').parent().outerHeight(true) / 2));");

                return sb.ToString();
            }
        }

        public DialogResult ShowModalDialog(DialogScreen dialog)
        {
            if (TheViewHandle == null)
                throw new Exception("Needs view handle");

            //add a handle to a static list
            WebThreadHandleDialog h = new WebThreadHandleDialog(this, dialog, TheViewHandle);
            WebThreads.Add(h.Uid, h);

            TheViewHandle.ScriptsToRun.Add(h.Script);
            Flow();

            h.TheEvent.WaitOne();  //may want a long timeout here, in case the browser's x is clicked, etc.
            return h.Result;
        }
    }

    public class DialogResult
    {
        public bool Success = true;
    }

    public class WebThreadHandle
    {
        public String Uid = Tools.Strings.GetNewID();
        public ManualResetEvent TheEvent;
        public HttpRequest TheRequest;
        public bool Canceled
        {
            get
            {
                if (TheRequest == null)
                    return false;

                String canceled = "";

                try
                {
                    canceled = Tools.Data.NullFilterString(TheRequest["canceled"]);
                }
                catch { }

                if (canceled == null)
                    return false;

                if (canceled == "true")
                    return true;

                return false;
            }
        }
        public LeaderWebUser Leader;

        public WebThreadHandle(LeaderWebUser leader)
        {
            TheEvent = new ManualResetEvent(false);
            Leader = leader;            
        }

        public virtual String Render(Context x, ref String after)
        {
            after = "";
            return Render(x);
        }

        public virtual String Render(Context x)
        {
            return "(not implemented)";
        }
        public virtual String Caption
        {
            get
            {
                return "";
            }
        }
        public virtual String Script
        {
            get
            {                
                return "Ask('" + Uid + "', '" + Tools.Html.AlertFilter(Caption) + "');";
            }
        }
    }
    public class WebThreadHandleYesNo : WebThreadHandle
    {
        public String Ask;

        public WebThreadHandleYesNo(LeaderWebUser leader, String ask)
            : base(leader)
        {
            Ask = ask;
        }
        public bool Yes
        {
            get
            {
                try
                {
                    return Tools.Strings.StrCmp(TheRequest["answer"], "yes");
                }
                catch { return false; }
            }
        }
        public override string Caption
        {
            get
            {
                return Ask;  //  + "?" the question mark is already in the string
            }
        }
        public override string Render(Context x)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<input type=\"button\" id=\"no_" + Uid + "\" value=\"No\" onclick=\"Reply('" + Uid + "', [{name: 'answer', value: 'no'}]);\">&nbsp;&nbsp;&nbsp;&nbsp;<input type=\"button\" value=\"Yes\" id=\"yes_" + Uid + "\" onclick=\"Reply('" + Uid + "', [{name: 'answer', value: 'yes'}]);\">");
            sb.AppendLine("<script type=\"text/javascript\">");
            sb.AppendLine("$('#dialog_div').dialog({ height: 200, width: 400 });buttonize('yes_" + Uid + "', 'Ok.png'); buttonize('no_" + Uid + "', 'Cancel.png');");
            sb.AppendLine(LeaderWebUser.DialogSetup);
            sb.AppendLine("</script>");
            return sb.ToString();
        }
    }
    public class WebThreadHandleAskString : WebThreadHandle
    {
        public String Prompt;
        public String DefaultValue;
        public bool MultiLine;

        public WebThreadHandleAskString(LeaderWebUser leader, String ask, String defaultValue, bool multiLine)
            : base(leader)
        {
            Prompt = ask;
            DefaultValue = defaultValue;
            MultiLine = multiLine;
        }
        public String Result
        {
            get
            {
                try
                {
                    return TheRequest["result"];
                }
                catch { return ""; }
            }
        }
        public override string Caption
        {
            get
            {
                return Prompt;
            }
        }
        public override string Render(Context x)
        {
            StringBuilder sb = new StringBuilder();
            String id = "x" + Tools.Strings.GetNewID();
            if (MultiLine)
                sb.Append("<textarea style=\"width: 450px; height: 200px\" id=\"" + id + "\">" + HttpUtility.HtmlEncode(DefaultValue) + "</textarea>");
            else
                sb.Append("<input type=\"text\" style=\"width: 350px\" id=\"" + id + "\" value=\"" + HttpUtility.HtmlEncode(DefaultValue) + "\" onKeyDown=\"if(event.keyCode == 13) $('#ok_" + Uid + "').click();\">");
            sb.Append("<br><br><input id=\"cancel_" + Uid + "\" type=\"button\" value=\"Cancel\" onclick=\"Reply('" + Uid + "', [{name: 'result', value: ''}]);\">&nbsp;&nbsp;&nbsp;&nbsp;<input id=\"ok_" + Uid + "\" type=\"button\" value=\"OK\" onclick=\"Reply('" + Uid + "', [{name: 'result', value: $('#" + id + "').val()}]);\">");
            sb.Append("<script type=\"text/javascript\">");

            if (MultiLine)
                sb.AppendLine("$('#dialog_div').dialog({ height: 370, width: 490 }); ");
            else
                sb.AppendLine("$('#dialog_div').dialog({ height: 170, width: 400 });");

            sb.Append("buttonize('ok_" + Uid + "', 'greencheck.png'); buttonize('cancel_" + Uid + "', 'redxmid.png'); $('#" + id + "').focus().select();</script>");
            return sb.ToString();
        }
    }

    public class WebThreadHandleDialog : WebThreadHandle
    {
        public DialogScreen Dialog;
        public ViewHandle ParentView;
        public DialogResult Result = new DialogResult();

        public WebThreadHandleDialog(LeaderWebUser leader, DialogScreen dialog, ViewHandle parentView)
            : base(leader)
        {
            Dialog = dialog;
            ParentView = parentView;
            dialog.ParentView = parentView;
            dialog.ThreadHandle = this;
        }

        public override string Caption
        {
            get
            {
                return Dialog.Title(null);
            }
        }

        public override string Render(Context x, ref String after)
        {
            AsyncScreenHandle dialogHandle = new AsyncScreenHandle(x, Dialog);
            AsyncScreenHandle.ActiveHandleAdd(dialogHandle);
            ViewHandle dialogView = new ViewHandle(ParentView.Uid, Dialog, Leader.Session.SessionID);
            Dialog.ViewAdd(x, dialogView);

            StringBuilder sb = new StringBuilder();
            Dialog.Render(x, sb, Dialog, dialogView, Leader.Session, Leader.Page);
            after = Dialog.AfterHtml;
            dialogView.LastChangeCheck = DateTime.Now;
            return sb.ToString();
        }
    }

    public class WebThreadHandleAskDate : WebThreadHandle
    {
        public String Prompt;
        public DateTime DefaultValue;
        private String ID = "";
        private Boolean ShowTime = true;

        public WebThreadHandleAskDate(LeaderWebUser leader, String ask, DateTime defaultValue, bool show_time = true)
            : base(leader)
        {
            Prompt = ask;
            DefaultValue = defaultValue;
            ShowTime = show_time;
        }
        public DateTime Result
        {
            get
            {
                try
                {
                    string date = TheRequest["result"];
                    DateTime dt = Tools.Dates.GetBlankDate();
                    try { dt = DateTime.Parse(date); }
                    catch { }
                    return dt;
                }
                catch { return Tools.Dates.GetBlankDate(); }
            }
        }
        public override string Caption
        {
            get
            {
                return Prompt;
            }
        }
        public override string Render(Context x)
        {
            StringBuilder sb = new StringBuilder();
            CreateInputID();
            sb.Append("<input type=\"text\" id=\"date_" + ID + "\" value=\"" + DefaultValue.ToString() + "\">");
            sb.Append("<br><br><input type=\"button\" id=\"cancel_" + Uid + "\" value=\"Cancel\" onclick=\"Reply('" + Uid + "', [{name: 'canceled', value: 'true'}]);\">&nbsp;&nbsp;&nbsp;&nbsp;<input type=\"button\" id=\"ok_" + Uid + "\" value=\"OK\" onclick=\"Reply('" + Uid + "', [{name: 'result', value: $('#date_" + ID + "').val()}]);\">");
            if (ShowTime)
                sb.AppendLine("<script type=\"text/javascript\"> buttonize('ok_" + Uid + "', 'Ok.png'); buttonize('cancel_" + Uid + "', 'Cancel.png'); $('#date_" + ID + "').datetimepicker({ampm: true,hourMin: 0,hourMax: 23}); $('#date_" + ID + "').datetimepicker('setDate', (new Date(" + DefaultValue.Year.ToString() + ", " + (DefaultValue.Month - 1).ToString() + ", " + DefaultValue.Day.ToString() + ", " + DefaultValue.Hour.ToString() + ", " + DefaultValue.Minute.ToString() + ")) );  </script>");
            else
                sb.AppendLine("<script type=\"text/javascript\"> buttonize('ok_" + Uid + "', 'Ok.png'); buttonize('cancel_" + Uid + "', 'Cancel.png'); $('#date_" + ID + "').datepicker(); $('#date_" + ID + "').datepicker('setDate', (new Date(" + DefaultValue.Year.ToString() + ", " + (DefaultValue.Month - 1).ToString() + ", " + DefaultValue.Day.ToString() + ")) );  </script>");
            return sb.ToString();
        }
        public override String Script
        {
            get
            {
                CreateInputID();
                return "Ask('" + Uid + "', '" + Tools.Html.AlertFilter(Caption) + "', '" + ID + "');";
            }
        }
        private void CreateInputID()
        {
            if (!Tools.Strings.StrExt(ID))
                ID = "x" + Tools.Strings.GetNewID();
        }
    }
    public class WebThreadHandleAskInt32 : WebThreadHandle
    {
        public String Prompt;
        public int DefaultValue;

        public WebThreadHandleAskInt32(LeaderWebUser leader, String ask, int defaultValue)
            : base(leader)
        {
            Prompt = ask;
            DefaultValue = defaultValue;
        }
        public int Result
        {
            get
            {
                try
                {
                    string integer = TheRequest["result"];
                    int integerValue = 0;
                    try { integerValue = Int32.Parse(integer); }
                    catch { }
                    return integerValue;
                }
                catch { return 0; }
            }
        }
        public override string Caption
        {
            get
            {
                return Prompt;
            }
        }
        public override string Render(Context x)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<input type=\"text\" id=\"txt" + Uid + "\" value=\"" + DefaultValue.ToString() + "\">");
            sb.Append("<br><input type=\"button\" value=\"Cancel\" onclick=\"Reply('" + Uid + "', [{name: 'result', value: ''}, {name: 'canceled', value: 'true'}]);\">&nbsp;&nbsp;&nbsp;&nbsp;<input type=\"button\" value=\"OK\" onclick=\"Reply('" + Uid + "', [{name: 'result', value: $('#txt" + Uid + "').val()}]);\">");
            return sb.ToString();
        }
    }
    public class WebThreadHandleAskDouble : WebThreadHandle
    {
        public String Prompt;
        public Double DefaultValue;

        public WebThreadHandleAskDouble(LeaderWebUser leader, String ask, Double defaultValue)
            : base(leader)
        {
            Prompt = ask;
            DefaultValue = defaultValue;
        }
        public Double Result
        {
            get
            {
                try
                {
                    string dbl = TheRequest["result"];
                    Double dblValue = 0;
                    try { dblValue = Double.Parse(dbl); }
                    catch { }
                    return dblValue;
                }
                catch { return 0; }
            }
        }
        public override string Caption
        {
            get
            {
                return Prompt;
            }
        }
        public override string Render(Context x)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<input type=\"text\" id=\"txt" + Uid + "\" value=\"" + DefaultValue.ToString() + "\">");
            sb.Append("<br><input type=\"button\" value=\"Cancel\" onclick=\"Reply('" + Uid + "', [{name: 'result', value: ''}, {name: 'canceled', value: 'true'}]);\">&nbsp;&nbsp;&nbsp;&nbsp;<input type=\"button\" value=\"OK\" onclick=\"Reply('" + Uid + "', [{name: 'result', value: $('#txt" + Uid + "').val()}]);\">");
            return sb.ToString();
        }
    }
    public class WebThreadHandleAskFile : WebThreadHandle
    {
        public String Prompt;

        public WebThreadHandleAskFile(LeaderWebUser leader, String ask)
            : base(leader)
        {
            Prompt = ask;
        }
        public String Result
        {
            get
            {
                try
                {
                    if( TheRequest.Files.Count == 0 )
                        return "";
                    HttpPostedFile f = TheRequest.Files[0];
                    String folder = TheRequest.MapPath("~/Bilge/");
                    if( !Directory.Exists(folder) )
                        Directory.CreateDirectory(folder);
                    String name = Tools.Folder.ConditionFolderName(folder) + "temp_" + Tools.Strings.GetNewID() + Path.GetExtension(f.FileName);
                    f.SaveAs(name);
                    return name;
                }
                catch { return ""; }
            }
        }
        public override string Caption
        {
            get
            {
                return Prompt;
            }
        }
        public override string Render(Context x)
        {
            StringBuilder sb = new StringBuilder();
            String id = "x" + Tools.Strings.GetNewID();

            sb.AppendLine("<form id=\"uploadForm\" method=\"post\" enctype=\"multipart/form-data\" action=\"Action.aspx\" target=\"iframe-post-form\">");
            sb.AppendLine("<input type=\"hidden\" name=\"askId\" value=\"" + Uid + "\"/>");
            sb.Append("<input type=\"file\" name=\"fileUpload\">");
            sb.Append("<br><br><input id=\"cancel_" + Uid + "\" type=\"button\" value=\"Cancel\" onclick=\"Reply('" + Uid + "', [{name: 'result', value: ''}]);\">&nbsp;&nbsp;&nbsp;&nbsp;<input id=\"ok_" + Uid + "\" type=\"button\" value=\"OK\" onclick=\"$('#uploadForm').submit(); AskDialogClose();\">");
            sb.AppendLine("</form>");
            sb.Append("<script type=\"text/javascript\">");
            sb.AppendLine("$('#dialog_div').dialog({ height: 170, width: 400 });");
            sb.Append("buttonize('ok_" + Uid + "', 'greencheck.png'); buttonize('cancel_" + Uid + "', 'redxmid.png'); $('#" + id + "').focus().select(); iframePostForm('uploadForm');</script>");
            //sb.Append(LeaderWebUser.DialogSetup);
            return sb.ToString();
        }
    }
    public class WebThreadHandleAskList : WebThreadHandle
    {
        public String Prompt;
        private List<String> List;
        private String ID = "";
        String DefaultValue = "";

        public WebThreadHandleAskList(LeaderWebUser leader, String ask, String defaultValue, List<String> list)
            : base(leader)
        {
            Prompt = ask;
            List = list;
            DefaultValue = defaultValue;
        }
        public String Result
        {
            get
            {
                try
                {
                    return Tools.Html.FilterInput(TheRequest["result"]);
                }
                catch { return ""; }
            }
        }
        public override string Caption
        {
            get
            {
                return Prompt;
            }
        }
        public override string Render(Context x)
        {
            StringBuilder sb = new StringBuilder();
            ID = "x" + Tools.Strings.GetNewID();
            sb.AppendLine("<select id=\"" + ID + "\" name=\"" + ID + "\" style=\"width: 285px;\" ><option></option>");
            bool found = false;
            if (List == null)
                List = new List<String>();
            foreach (string s in List)
            {
                string sel = "";
                if (Tools.Strings.StrCmp(s, DefaultValue))
                {
                    sel = "selected";
                    found = true;
                }
                sb.AppendLine("<option " + sel + ">" + HttpUtility.HtmlEncode(s) + "</option>");
            }
            if (!found && Tools.Strings.StrExt(DefaultValue))
                sb.AppendLine("<option selected>" + HttpUtility.HtmlEncode(DefaultValue) + "</option>");
            sb.AppendLine("</select>");
            sb.Append("<br><br><input type=\"button\" id=\"cancel_" + Uid + "\" value=\"Cancel\" onclick=\"Reply('" + Uid + "', [{name: 'cancel', value: 'Y'}]);\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type=\"button\" id=\"ok_" + Uid + "\" value=\"OK\" onclick=\"Reply('" + Uid + "', [{name: 'result', value: $('#" + ID + "').val()}]);\">");
            sb.AppendLine("<script type=\"text/javascript\">$('#dialog_div').dialog({ height: 200, width: 320 }); buttonize('ok_" + Uid + "', 'Ok.png'); buttonize('cancel_" + Uid + "', 'Cancel.png');</script>");
            return sb.ToString();
        }
    }
    public class Message
    {
        public String TheText;
        public Color TheColor;

        public Message(String text, Color color)
        {
            TheText = text;
            TheColor = color;
        }
    }
    public class ItemListHandle
    {
        public String Caption;
        public List<IItem> Items;
    }

    public class DialogDivDimensions
    {
        public int Height = 0;
        public int Width = 0;

        public DialogDivDimensions(int height, int width)
        {
            Height = height;
            Width = width;
        }
    }
}
