using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Core;
using NewMethod;

namespace Rz5
{
    public partial class frmLinkedNote : Form
    {
        SysNewMethod xSys
        {
            get
            {
                return RzWin.Context.Sys;
            }
        }
        public String ObjectName;
        public String ObjectID;
        public linkednote xNote;

        public frmLinkedNote()
        {
            InitializeComponent();
        }
        public void CompleteLoad(String obj_name, String obj_id)
        {
            ObjectName = obj_name;
            ObjectID = obj_id;
            if (ObjectName.Length <= 0)
                return;
            if (ObjectID.Length <= 0)
                return;
            xNote = linkednote.New(RzWin.Context);
            lvNotes.ShowTemplate("AllUserLinkedNotes", "linkednote", true);  
            DoResize();
            LoadNotes();
        }
        public void DoResize()
        {
            lvNotes.DoResize();
        }
        public void DoFocus()
        {
            RT.Focus();
        }
        public void ShowNote(linkednote l)
        {
            xNote = l;
            RT.Text = xNote.linked_note;
        }
        //Private Functions
        private void LoadNotes()
        {
            lvNotes.ShowData("linkednote", "object_uid = '" + ObjectID + "' and objectname = '" + ObjectName + "'", "date_created desc", SysNewMethod.ListLimitDefault);
        }
        private void CreateNewNote()
        {
            DialogResult dr = MessageBox.Show("You are about to create a new note. All changes to this one will be lost. Ok to continue?", "Add Note", MessageBoxButtons.YesNo);
            if (dr.Equals(DialogResult.No))
                return;
            xNote = linkednote.New(RzWin.Context);
            RT.Text = "";
            RT.Focus();
        }
        private void SaveCurrentNote()
        {
            if (RT.Text.Length <= 0)
                return;
            xNote.object_uid = ObjectID;
            xNote.objectname = ObjectName;
            xNote.linked_note = RT.Text.Trim();
            if( xNote.Uid == "" )
                xNote.Insert(RzWin.Context);
            else
                xNote.Update(RzWin.Context);
        }
        //Buttons
        private void cmdNew_Click(object sender, EventArgs e)
        {
            CreateNewNote();
        }
        private void cmdSave_Click(object sender, EventArgs e)
        {
            SaveCurrentNote();
        }
        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
        private void lvNotes_AboutToThrow(object sender, ShowArgs args)
        {
            args.Handled = true;
            linkednote l = (linkednote)lvNotes.GetSelectedObject();
            if (l == null)
                return;
            ShowNote(l);
        }
    }
}