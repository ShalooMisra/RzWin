using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using Tools;
using ToolsWin;
using Core;
using Core.Display;
using CoreWin;

namespace CoreWin
{
    public class LeaderWinUser : Leader
    {
        MainForm m_TheMainForm = null;
        public virtual MainForm TheMainForm
        {
            get
            {
                return m_TheMainForm;
            }
            set
            {
                m_TheMainForm = value;
            }
        }

        public LeaderWinUser()
        {

        }

        public LeaderWinUser(MainForm f)
        {
            TheMainForm = f;            
        }

        protected override void Apply(Leader leader)
        {
            base.Apply(leader);
            ((LeaderWinUser)leader).TheMainForm = TheMainForm;
        }

        public override string AskForFile(string caption)
        {
            //return base.AskForFile(caption);
            return ToolsWin.FileSystem.ChooseAFile();
        }

        public override void Error(string s, bool hide_message)
        {
            if (FastForwardMode || hide_message)
                Comment("Error: " + s);
            else
                ToolsWin.Dialogs.Tell.TellModal(null, "Error", s);
        }

        public override string AskForString(string prompt, string default_value, bool multi_line, String caption)
        {
            ToolsWin.Dialogs.Ask f = new ToolsWin.Dialogs.Ask();
            if (multi_line)
                f.SetMultiLine();
            f.Init();
            f.SetPrompt(prompt);
            f.SetText(default_value);
            f.SetCaption(caption);
            f.CloseOnEnter = true;
            f.ShowDialog();

            String ret = f.ReturnString;

            try
            {
                f.Close();
                f.Dispose();
                f = null;
            }
            catch { }

            return ret;
        }

        public override bool AreYouSure(string ask)
        {
            if (FastForwardMode)
            {
                Comment("Answering Yes to " + ask);
                return true;
            }
            else
                return ToolsWin.Dialogs.AreYouSure.Ask(null, ask);
        }

        public override bool AskYesNo(string ask)
        {
            if (FastForwardMode)
            {
                Comment("Answering Yes to " + ask);
                return true;
            }
            else
                return ToolsWin.Dialogs.YesNo.Ask(ask);
        }

        public override bool AskYesNoLarge(string ask, string title)
        {
            if (FastForwardMode)
            {
                Comment("Answering Yes to " + ask);
                return true;
            }
            else
                return ToolsWin.Dialogs.YesNoLarge.AskLarge(ask, title);
        }

        //public override bool OkCancelFormatting(string body, string title, int height = 300, int width = 500, string OKText = "OK", string CancelText = "Cancel")
        public override bool OkCancelFormatting(string body, string title)
        {
            if (FastForwardMode)
            {
                Comment("Answering Yes to " + title);
                return true;
            }
            else
                return ToolsWin.Dialogs.OkCancelFormatting.AskOkCancel(body, title);
        }

        public override void Tell(String tell)
        {
            if (FastForwardMode)
                Comment(tell);
            else
                ToolsWin.Dialogs.Tell.TellModal(null, "", tell);
        }

        public override void TellTemp(String tell)
        {
            if (FastForwardMode)
                Comment(tell);
            else
                ToolsWin.Dialogs.Tell.TellTemp(null, "", tell, 5);
        }

        public override void ShowText(string text)
        {
            Tools.FileSystem.PopText(text);
        }

        public override string AskForFolder()
        {
            return ToolsWin.FileSystem.ChooseAFolder();
        }

        public override string ChooseBetweenStrings(String caption, List<String> choices)
        {
            System.Collections.ArrayList ary = new System.Collections.ArrayList();
            foreach (String s in choices)
            {
                ary.Add(s);
            }
            return ToolsWin.Dialogs.ChooseFromArray.Choose(ary, caption, false, null);
        }

        public override int AskForInt32(string prompt, int default_value, string title, ref bool cancelled)
        {
            String sq = ToolsWin.Dialogs.Ask.AskString(false, prompt, default_value.ToString(), title, null);
            if (!Tools.Number.IsNumeric(sq))
            {
                cancelled = true;
                return 0;
            }

            try
            {
                return Int32.Parse(sq);
            }
            catch
            {
                cancelled = true;
                return 0;
            }
        }

        public override double AskForDouble(string caption, double default_value, string title, ref bool cancelled)
        {
            String sq = ToolsWin.Dialogs.Ask.AskString(false, caption, default_value.ToString(), title, null);
            if (!Tools.Number.IsNumeric(sq))
            {
                cancelled = true;
                return 0;
            }

            try
            {
                return Double.Parse(sq);
            }
            catch
            {
                cancelled = true;
                return 0;
            }
        }

        public override DateTime AskForDate(String caption, DateTime default_value, bool show_time = true)
        {
            return ToolsWin.Dialogs.DateTimeChooser.Choose(default_value, caption, show_time);
        }

        public override DateTime AskForDate(string caption, DateTime default_value)
        {
            return ToolsWin.Dialogs.DateTimeChooser.Choose(default_value, caption);
        }

        public override DateTime AskForDate(String caption, DateTime start,  Dictionary<string, string> properties)
        {
            //ToolsWin.Dialogs.DateTimeChooser dtc = new ToolsWin.Dialogs.DateTimeChooser();
            //return dtc.Choose(start,caption, properties);//Since static methods can't affect controls, I have to instantiate this to set labels, etc.
            return ToolsWin.Dialogs.DateTimeChooser.Choose(caption, start,  properties);
        }

        public override IView ViewCreate(Context x, ShowArgs args)
        {
            if (args.TheItems == null)
            {
                x.TheLeader.Error("No items were found to create this view");
                return null;
            }

            return null;

            //switch (args.TheViewType)
            //{
            //    case ViewType.ListGrid:
            //        //ViewGrid g = new ViewGrid();
            //        ViewGridSimple g = new ViewGridSimple();
            //        g.TheColumnSource = new Core.Display.GridColumnSourceInfer(args.TheItems);
            //        return g;
            //}

            //if ( args.TheItems.CountMax == 1)
            //{
            //    //return the default screen for an item
            //    return new ViewItemSimple();
            //}
            //else
            //{
            //    ViewGrid g = new ViewGrid();
            //    g.TheColumnSource = new Core.Display.GridColumnSourceInfer(args.TheItems);
            //    return g;
            //    //List<String> classes = items.ClassIdsList(x);
            //    //if (classes.Count == 1)
            //    //{
            //    //    //return an nList
            //    //}
            //    //else
            //    //{
            //    //    //return the default screen for multi item types
            //    //}
            //}
            //return null;
        }

        public override bool Show(Context x, ShowArgs args)
        {
            //activate the existing tab if its already there
            if (args.TheViewType == ViewType.SingleItem)
            {
                IItem i = args.TheItems.FirstGet(x);
                if (TheMainForm.TabCheckShow(i.Uid) != null)
                    return true;
            }

            //ViewItems v = (ViewItems)ViewCreate(x, new ShowArgs(x, args.TheViewType, args.TheItems));
            //if (v != null)
            //{
            //    TabPageCore tab = TheMainForm.TabShow(v, args.TheItems.Caption, (args.TheViewType == ViewType.SingleItem) ? args.TheItems.FirstGet(x).Uid : "");
            //    if (args.TheViewType == ViewType.SingleItem)
            //    {
            //        tab.TheItem = args.TheItems.FirstGet(x);
            //        tab.TheView = v;
            //    }
            //    return v.Init(x, args.TheItems);
            //}
            //else
                return base.Show(x, args);
        }

        public override bool Follow(Context context, Stop stop)
        {
            if (stop is StopAreYouSure)
            {
                bool ays = AreYouSure(((StopAreYouSure)stop).Message);
                ((StopAreYouSure)stop).Answer(ays);
                return ays;
            }
            else if (stop is StopYesNo)
            {
                bool ays = ToolsWin.Dialogs.YesNo.Ask(((StopYesNo)stop).Message);
                ((StopYesNo)stop).Answer(ays);
                return ays;
            }
            else
                return false;
        }

        public override List<DisplayHandle> DisplayHandlesList
        {
            get
            {
                List<DisplayHandle> ret = base.DisplayHandlesList;
                if (TheMainForm != null)
                {
                    foreach (TabPageCore tab in TheMainForm.TabsList)
                    {
                        DisplayHandle h = new DisplayHandle();
                        h.TheItem = tab.TheItem;
                        h.TheDisplayObject = tab.TheView;
                        ret.Add(h);
                    }
                }
                return ret;
            }
        }

        public override IItem ItemShownByTag(Context x, ItemTag t)
        {
            if (TheMainForm == null)
                return null;

            return TheMainForm.ItemShownByTag(x, t);
        }

        public override void ViewsClose(IItem item)
        {
            base.ViewsClose(item);
            if (TheMainForm != null)
                TheMainForm.TabCloseByID(item.Uid);
        }

        public override void ViewsCloseAll()
        {
            base.ViewsCloseAll();
            if (TheMainForm != null)
                TheMainForm.TabsCloseUnlocked();
        }

        public override void Comment(string comment, System.Drawing.Color color)
        {
            base.Comment(comment, color);

            try
            {
                if (StatusForm != null)
                    StatusForm.SetStatus(comment);
            }
            catch
            {
                ;
            }

            if (FastForwardMode)
                FastForwardLog.AppendLine(comment);
        }

        //Status
        private static Status z_StatusForm = null;
        public static Status StatusForm
        {
            set
            {
                z_StatusForm = value;
            }
            get
            {
                return z_StatusForm;
            }
        }

        public override void StartPopStatus(String initial_status = "")
        {
            if (StartPopStatus())
            {
                if (Tools.Strings.StrExt(initial_status))
                    Comment(initial_status);
            }
        }

        public bool StartPopStatus()
        {
            if (StatusForm != null)
                return false;

            try
            {
                if (TheMainForm != null)
                    TheMainForm.Invoke(new StartPopStatusHandler(ActuallyStartPopStatus));
                else
                    ActuallyStartPopStatus();
            }
            catch { }

            return true;
        }

        delegate void StartPopStatusHandler();
        void ActuallyStartPopStatus()
        {
            StatusForm = new Status();
            StatusForm.Show();

            System.Windows.Forms.Application.DoEvents();
            System.Windows.Forms.Application.DoEvents();
        }

        delegate void StopPopStatusHandler(bool leaveWindowOpen);
        public override void StopPopStatus(bool leaveWindowOpen = true)
        {
            base.StopPopStatus(leaveWindowOpen);

            if (StatusForm != null)
            {
                if (TheMainForm != null)
                    TheMainForm.Invoke(new StopPopStatusHandler(ActuallyStopPopStatus), new object[] { leaveWindowOpen });
                else
                    ActuallyStopPopStatus(leaveWindowOpen);
                StatusForm = null;
            }
        }

        void ActuallyStopPopStatus(bool leaveWindowOpen)
        {
            if (!leaveWindowOpen)
                StatusForm.Close();
        }

        public override void ProgressUpdate(int percent)
        {
            try
            {
                base.ProgressUpdate(percent);
                if (StatusForm != null)
                    StatusForm.SetProgress(percent);
            }
            catch
            {
                ;
            }
        }

        public override void FolderShow(String folder)
        {
            Tools.Folder.ExploreFolder(folder);
        }

        public override Color ChooseColor(System.Drawing.Color start, ref bool cancel)
        {
            ColorDialog c = new ColorDialog();
            c.Color = start;
            c.FullOpen = true;
            cancel = (c.ShowDialog() == DialogResult.Cancel);
            Color ret = c.Color;
            
            try
            {
                c.Dispose();
                c = null;
            }
            catch { }
            return ret;
        }

        public override ImageHandle ChooseImage(List<ImageHandle> images, ref bool noneSelected)
        {
            return ToolsWin.Dialogs.ImageChooser.Choose(images, ref noneSelected);
        }

        //public override string ExportFolder
        //{
        //    get
        //    {
        //        return Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + @"Exports\";
        //    }
        //}

        //public override void ShowFile(string file)
        //{
        //    //base.ShowFile(file);
        //    Tools.FileSystem.Shell(file);
        //}

        public override void FileShow(string file)
        {
            //base.FileShow(file);
            Tools.FileSystem.Shell(file);
        }

        public override void CloseProgram()
        {
            TheMainForm.CompleteClose();
        }

        public override void BrowseUrl(string url)
        {
            ToolsWin.WebWin.BrowseWebAddress(url);
        }

        public override string ChooseOneString(Context x, String caption, List<String> choices)
        {
            return ToolsWin.Dialogs.ChooseFromArray.Choose(choices, caption);
        }

        public override string GetClipboardText()
        {
            return ToolsWin.Clipboard.GetClipText();
        }

        public override void SetClipboardText(String text)
        {
            ToolsWin.Clipboard.SetClip(text);
        }

        public override string ChooseAFile()
        {
            return ToolsWin.FileSystem.ChooseAFile();
        }

        public override void ShowHtml(Context x, string caption, string html)
        {
            Browser b = new Browser();
            TheMainForm.TabShow(b, caption);
            b.ReloadWB();
            b.Add(html);
        }
    }
}
