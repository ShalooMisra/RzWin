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
    public partial class view_usernote : NewMethod.nView, IFocusControl
    {
        //Public Variables
        public usernote CurrentNote
        {
            get
            {
                return (usernote)GetCurrentObject();
            }
            //set
            //{
            //    SetCurrentObject(value);
            //}
        }
        //Private Variables
        private focus_item xItem = null;
        protected Dictionary<string, string> CC = new Dictionary<string, string>();
        RzHook xHook;
        //Constructors
        public view_usernote()
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

            ctlTime.SetValue(nTools.TimeFormat(CurrentNote.displaydate));
            ctlDate.SetValue(CurrentNote.displaydate);
            NMWin.LoadFormValues(this, CurrentNote);
            LoadObjects();

            user_by.Enabled = false;

            if (CurrentNote.is_pending)
            {
                user_for.Enabled = true;
                cmdDelete.Text = "Cancel";
                cmdSend.Visible = true;
                cmdPostpone.Visible = false;
                cmdReply.Visible = false;
                cmdForward.Visible = false;
                cmdSaveAndExit.Visible = false;
            }
            else
            {
                user_for.Enabled = RzWin.User.IsDeveloper();
                cmdDelete.Text = "Dismiss";
                cmdSend.Visible = false;
                cmdPostpone.Visible = true;
                cmdReply.Visible = true;
                cmdForward.Visible = true;
                cmdSaveAndExit.Visible = true;
            }

            ctl_extra_info.Visible = RzWin.User.IsDeveloper();

            CheckChat();
            CompanyShow();
        }
        public override void CompleteSave()
        {
            NMWin.GrabFormValues(this, CurrentNote);
            String strDate = nTools.DateFormat(ctlDate.GetValue_Date()) + " " + ctlTime.GetValue_String();
            if (Tools.Dates.IsDate(strDate))
                CurrentNote.displaydate = DateTime.Parse(strDate);
            else
                CurrentNote.displaydate = ctlDate.GetValue_Date();
            base.CompleteSave();
            CurrentNote.Update(RzWin.Context);
        }
        //Public Functions
        public void Init(usernote u, focus_item i)
        {
            Init(u);
            xItem = i;
        }
        public void LimitControls()
        {
            cmdSaveAndExit.Visible = false;
            cmdDelete.Visible = false;
        }
        //Private Functions
        private void DoResize()
        {
            try
            {
                fpButtons.Left = 0;
                fpButtons.Top = this.ClientRectangle.Height - fpButtons.Height;
                fpButtons.Width = this.ClientRectangle.Width;

                ctl_subjectstring.Width = ctl_current_status.Left - (10 + ctl_subjectstring.Left);

                ctl_notetext.Width = this.ClientRectangle.Width - (lv.Width + ctl_notetext.Left + 10);

                if (RzWin.User.IsDeveloper())
                {
                    ctl_notetext.Height = (this.ClientRectangle.Height - (ctl_notetext.Top + fpButtons.Height)) / 2;
                    ctl_extra_info.Left = ctl_notetext.Left;
                    ctl_extra_info.Width = ctl_notetext.Width;
                    ctl_extra_info.Top = ctl_notetext.Bottom;
                    ctl_extra_info.Height = ctl_notetext.Height;
                }
                else
                {
                    ctl_notetext.Height = this.ClientRectangle.Height - (ctl_notetext.Top + fpButtons.Height);
                }

                lv.Left = ctl_notetext.Right;
                lv.Top = ctl_notetext.Top;
                lv.Height = ctl_notetext.Height;

                //fc.Width = this.ClientRectangle.Width - fc.Left;
            }
            catch { }
        }
        private void CheckChat()
        {
            if (CurrentNote.by_mc_user_uid != RzWin.User.unique_id)
            {
                fc.Visible = true;
                fc.CompleteLoad(CurrentNote.by_mc_user_uid, CurrentNote.createdbyname);
            }
            else if (CurrentNote.for_mc_user_uid != RzWin.User.unique_id)
            {
                fc.Visible = true;
                fc.CompleteLoad(CurrentNote.for_mc_user_uid, CurrentNote.createdforname);
            }
            else
            {
                fc.Visible = false;
            }
        }
        private void LoadObjects()
        {
            lv.Items.Clear();

            ArrayList a = CurrentNote.LinkedObjects(RzWin.Context);

            foreach (filelink xLink in a)
            {
                ListViewItem l;
                if (Tools.Strings.StrExt(xLink.linkname))
                {
                    l = lv.Items.Add(xLink.linkname);
                }
                else
                {
                    l = lv.Items.Add(nTools.NiceFormat(xLink.objectclass2));
                }
                l.Tag = xLink;
            }
        }
        private void CompanyShow()
        {
            if (!Tools.Strings.StrExt(CurrentNote.companyname))
            {
                lblCompanyContact.Text = "";
                return;
            }

            if (!Tools.Strings.StrExt(CurrentNote.contactname))
            {
                lblCompanyContact.Text = CurrentNote.companyname;
                return;
            }

            lblCompanyContact.Text = CurrentNote.companyname + " / " + CurrentNote.contactname;
        }
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
        private void ShowLinkedItem()
        {
            try
            {
                ListViewItem l = lv.SelectedItems[0];
                filelink k = (filelink)l.Tag;
                nObject o = (nObject)RzWin.Context.GetById(k.objectclass2, k.objectid2);

                if (o == null)
                {
                    RzWin.Context.TheLeader.Tell("The linked information could not be found");
                    return;
                }
                
                if (o.ClassId == "orddet_line")
                {
                    //we need to decide on a default view for the lines
                    RzWin.Context.Show(new ShowArgsOrder(RzWin.Context, o, Enums.OrderType.Purchase));
                }
                else
                    RzWin.Context.Show(o);
            }
            catch (Exception ex)
            {
                RzWin.Context.TheLeader.Error(ex);
            }
        }
        protected virtual void AddRecipients()
        {
            try
            {
                CC = frmChooseUser_Multiple.Choose_IDs(RzWin.Context, this.ParentForm);
            }
            catch { }
        }
        private void SendCC(usernote n)
        {
            if (CC == null)
                return;
            foreach (KeyValuePair<string, string> kvp in CC)
            {
                usernote nn = (usernote)n.CloneValues(RzWin.Context);
                nn.for_mc_user_uid = kvp.Key;
                nn.createdforname = kvp.Value;
                nn.Insert(RzWin.Context);
                CreateAttachments(n, nn);
            }
        }
        private void CreateAttachments(usernote n_old, usernote n_new)
        {
            if (n_old == null)
                return;
            if (n_new == null)
                return;
            ArrayList a = RzWin.Context.QtC("filelink", "select * from filelink where objectid = '" + n_old.unique_id + "' and objectclass = 'usernote' and linktype = 'Note'");
            if (a == null)
                return;
            foreach (filelink f in a)
            {
                filelink ff = (filelink)f.CloneValues(RzWin.Context);
                ff.objectid = n_new.unique_id;
                ff.Insert(RzWin.Context);
            }
        }
        //Buttons
        private void cmdCC_Click(object sender, EventArgs e)
        {
            AddRecipients();
        }
        private void cmdSend_Click(object sender, EventArgs e)
        {
            CurrentNote.is_pending = false;
            CompleteSave();
            CurrentNote.Update(RzWin.Context);
            SendCC(CurrentNote);
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
            CheckChat();
        }
        private void user_for_DataChanged(GenericEvent e)
        {
            CheckChat();
        }
        private void lv_DoubleClick(object sender, EventArgs e)
        {
            ShowLinkedItem();
        }
        private void lblCompanyAssign_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CurrentNote.CompanyApply(RzWin.Context);
            CompanyShow();
        }
        //Menus
        private void mnuOpen_Click(object sender, EventArgs e)
        {
            ShowLinkedItem();
        }
    }
}

