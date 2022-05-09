using System;
using System.Collections;
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
    public partial class frmUserNote : Form
    {
        public usernote CurrentNote;

        public frmUserNote()
        {
            InitializeComponent();
            this.Icon = RzWin.Form.Icon;
        }

        public void CompleteLoad()
        {
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
        }

        private void LoadObjects()
        {
            MessageBox.Show("reorg");
            //lv.Items.Clear();

            //ArrayList a = CurrentNote.QtC("filelink", "SELECT * FROM filelink WHERE OBJECTID = '" + CurrentNote.unique_id + "'");

            //foreach(filelink xLink in a)
            //{
            //    ListViewItem l;
            //    if( Tools.Strings.StrExt(xLink.linkname) )
            //    {
            //        l = lv.Items.Add(xLink.linkname);
            //    }
            //    else
            //    {
            //        l = lv.Items.Add(nTools.NiceFormat(xLink.objectclass2));
            //    }
            //    l.Tag = xLink;
            //}
        }

        public void CompleteSave()
        {
            NMWin.GrabFormValues(this, CurrentNote);

            String strDate = nTools.DateFormat(ctlDate.GetValue_Date()) + " " + ctlTime.GetValue_String();
            if (Tools.Dates.IsDate(strDate))
                CurrentNote.displaydate = DateTime.Parse(strDate);
            else
                CurrentNote.displaydate = ctlDate.GetValue_Date();
        }

        //public void LoadFlash()
        //{
        //    if (CurrentNote.is_pending)        //send
        //        xFlash.SetMovie("note_send");
        //    else
        //        xFlash.SetMovie("note_receive");
        //}

        private void xFlash_ButtonClick(object sender, FlashClickArgs args)
        {
            switch (args.strButton.ToLower())
            {
                case "send":
                    CurrentNote.is_pending = false;
                    CompleteSave();
                    CurrentNote.Update(RzWin.Context);
                    this.Close();
                    if (((ContextRz)RzWin.Context).xHook != null)
                        ((ContextRz)RzWin.Context).xHook.SuggestNoteCheck(CurrentNote.for_mc_user_uid);
                    break;
                case "cancel":
                    if( !RzWin.Leader.AreYouSure("delete this note") )
                        return;
                    CurrentNote.Delete(RzWin.Context);
                    this.Close();
                    break;
                case "saveandexit":
                    CompleteSave();
                    CurrentNote.Update(RzWin.Context);
                    this.Close();
                    break;
                case "print":
                    CompleteSave();
                    Browser b = new Browser();
                    b.ShowControls = true;
                    RzWin.Form.TabShow(b, CurrentNote.subjectstring);
                    b.SetHTML(CurrentNote.GetClipHTML(RzWin.Context));
                    break;
                default:
                    CompleteSave();
                    CurrentNote.Update(RzWin.Context);

                    ActArgs a = new ActArgs(args.strButton);
                    a.TheContext = RzWin.Context;
                    CurrentNote.HandleAction(a);
                    if( a.ShouldClose )
                        this.Close();
                    else
                        CompleteLoad();

                    break;                    
            }
        }

        private void lv_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ListViewItem l = lv.SelectedItems[0];
                filelink k = (filelink)l.Tag;
                nObject o = (nObject)RzWin.Context.GetById(k.objectclass2, k.objectid2);

                if (o == null)
                    return;

                RzWin.Context.Show(o);
            }
            catch (Exception)
            {}
        }

        private void lv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}