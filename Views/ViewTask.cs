using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Tools;
using ToolsWin;
using Core;
using NewMethod;

namespace Rz5
{
    public partial class ViewTask : NewMethod.nView
    {
        //Public Variables
        public usernote CurrentNote
        {
            get
            {
                return (usernote)GetCurrentObject();
            }
        }
        //Private Variables

        
        //Constructors
        public ViewTask()
        {
            InitializeComponent();
        }
        //Public Override Functions
        public override void CompleteLoad()
        {
            base.CompleteLoad();

            user_by.CurrentObject = CurrentNote;
            user_by.CurrentIDField = "by_mc_user_uid";
            user_by.CurrentNameField = "createdbyname";
            user_by.SetUserName();

            user_for.CurrentObject = CurrentNote;
            user_for.CurrentIDField = "for_mc_user_uid";
            user_for.CurrentNameField = "createdforname";
            user_for.SetUserName();

            //ctlDate.SetValue(CurrentNote.displaydate);
            NMWin.LoadFormValues(this, CurrentNote);
            //ctl_task_type.LoadList();

            user_by.Enabled = true;
            SummaryShow();

            //if (!Tools.Strings.StrExt(CurrentNote.subjectstring))
                IsExpanded = true;
            //else
            //    IsExpanded = false;

                AttachmentsLoad();

            ShowExpanded();
            ShowTags();
            DoResize();
        }
        public override void CompleteSave()
        {
            NMWin.GrabFormValues(this, CurrentNote);
            //CurrentNote.displaydate = ctlDate.GetValue_Date();

            SummaryShow();

            ctl_notetext.ClearInfo();
            ctl_task_type.ClearInfo();
            ctl_task_size.ClearInfo();
            ctl_current_status.ClearInfo();
            ctl_subjectstring.ClearInfo();

            base.CompleteSave();
        }


        //Public Functions
        public void Init(usernote u)
        {
            SetCurrentObject(u);
            //Init(u);            
        }
        public void LimitControls()
        {
            cmdSaveAndExit.Visible = false;
            cmdDelete.Visible = false;
        }
        //Private Functions
        protected override void DoResize()
        {
            try
            {
                //if (IsExpanded)
                //{
                //    this.Height = 236;
                //}
                //else
                //{
                //    this.Height = 66;
                //}
            }
            catch { }
        }

        //private void LoadObjects()
        //{
        //    lv.Items.Clear();

        //    ArrayList a = CurrentNote.QtC("filelink", "SELECT * FROM filelink WHERE OBJECTID = '" + CurrentNote.unique_id + "'");

        //    foreach (filelink xLink in a)
        //    {
        //        ListViewItem l;
        //        if (Tools.Strings.StrExt(xLink.linkname))
        //        {
        //            l = lv.Items.Add(xLink.linkname);
        //        }
        //        else
        //        {
        //            l = lv.Items.Add(nTools.NiceFormat(xLink.objectclass2));
        //        }
        //        l.Tag = xLink;
        //    }
        //}

        private void DoAction(String s)
        {
            CompleteSave();
            ActArgs args = new ActArgs(RzWin.Form.TheContextNM, s);
            CurrentNote.HandleAction(args);
            if (args.ShouldClose)
                SendCloseRequest();
            else
                CompleteLoad();
        }
        //private void ShowLinkedItem()
        //{
        //    try
        //    {
        //        ListViewItem l = lv.SelectedItems[0];
        //        filelink k = (filelink)l.Tag;
        //        nObject o = CurrentNote.GetById(k.objectclass2, k.objectid2);

        //        if (o == null)
        //            return;

        //        CurrentNote.Show(o);
        //    }
        //    catch (Exception)
        //    { }
        //}
        //Buttons
        private void cmdSend_Click(object sender, EventArgs e)
        {
            CurrentNote.is_pending = false;
            CompleteSave();
            CurrentNote.Update(RzWin.Context);

            if (((ContextRz)RzWin.Context).xHook != null)
                ((ContextRz)RzWin.Context).xHook.SuggestNoteCheck(CurrentNote.for_mc_user_uid);

            SendCloseRequest();
            DisableControls();

        }
        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (!RzWin.Leader.AreYouSure("delete this note"))
                return;
            CurrentNote.Delete(RzWin.Context);
            SendCloseRequest();
            DisableControls();
        }
        private void cmdPrint_Click(object sender, EventArgs e)
        {
            CompleteSave();
            Browser b = new Browser();
            b.ShowControls = true;
            RzWin.Form.TabShow(b, CurrentNote.subjectstring);
            b.SetHTML(CurrentNote.GetClipHTML(RzWin.Context));
        }
        private void cmdSaveAndExit_Click(object sender, EventArgs e)
        {
            CompleteSave();
            SendCloseRequest();
        }
        private void cmdPostpone_Click(object sender, EventArgs e)
        {
            DoAction("postpone");
        }
        private void cmdReply_Click(object sender, EventArgs e)
        {
            DoAction("reply");
        }
        private void cmdForward_Click(object sender, EventArgs e)
        {
            DoAction("forward");
        }
        //Control Events
        private void view_usernote_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void user_by_DataChanged(GenericEvent e)
        {
            //CheckChat();
        }
        private void user_for_DataChanged(GenericEvent e)
        {
            //CheckChat();
        }
        //private void lv_DoubleClick(object sender, EventArgs e)
        //{
        //    ShowLinkedItem();
        //}


        bool IsExpanded = true;
        public virtual void ShowExpanded()
        {
            //if( IsExpanded )
            //    picExpand.BackgroundImage = imExpand.Images["up"];
            //else
            //    picExpand.BackgroundImage = imExpand.Images["down"];

            pLeft.BringToFront();
            pTop.BringToFront();
            pRight.BringToFront();
            pBottom.BringToFront();
        }

        private void picExpand_Click(object sender, EventArgs e)
        {
            IsExpanded = !IsExpanded;

            if (!IsExpanded)
            {
                CompleteSave();
            }

            ShowExpanded();
            DoResize();
        }

        void SummaryShow()
        {
            //lblName.Text = CurrentNote.subjectstring;
            //lblNotes.Text = CurrentNote.notetext;
            //lblAssignedFrom.Text = CurrentNote.createdbyname;
            //lblAssignedTo.Text = CurrentNote.createdforname;

            Image i = ImageGet(ctl_task_type.GetValue_String());
            if (i != null)
                picIcon.BackgroundImage = i;
            else
                picIcon.BackgroundImage = imPic.Images["gear"];

            i = ImageGet(ctl_task_size.GetValue_String());
            if (i != null)
            {
                picSize.Visible = true;
                picSize.BackgroundImage = i;
            }
            else
                picSize.Visible = false;

            //lblSize.Text = Tools.Strings.NiceFormat(CurrentNote.task_size);

            i = ImageGet(ctl_current_status.GetValue_String());
            if (i != null)
            {
                picStatus.Visible = true;
                picStatus.BackgroundImage = i;
            }
            else
                picStatus.Visible = false;

            //lblStatus.Text = Tools.Strings.NiceFormat(CurrentNote.current_status);
        }

        protected virtual Image ImageGet(String name)
        {
            name = name.Replace(" ", "").ToLower();
            if (imPic.Images.ContainsKey(name))
                return imPic.Images[name];
            else
                return null;
        }

        private void ctl_task_size_DataChanged(GenericEvent e)
        {
            //CompleteSave();
            SummaryShow();
        }

        private void lblAttachments_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CurrentNote.AttachmentsShow(RzWin.Context);
            AttachmentsLoad();
        }

        void AttachmentsLoad()
        {
            lblAttachments.Text = "Attachments: " + CurrentNote.attachment_count.ToString();
        }

        void ShowTags()
        {
            lblTags.Text = Tools.Strings.CommaSeparateBlanksIgnore(CurrentNote.TagsNotNamed);
        }

        private void lblTagsLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Win.Dialogs.TagEditor.Edit(CurrentNote);
            ShowTags();
        }
    }
}

