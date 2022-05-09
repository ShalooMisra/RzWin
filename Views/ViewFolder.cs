using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Core;
using NewMethod;

namespace Rz5.Win.Views
{
    public partial class ViewFolder : UserControl
    {
        public event EventHandler SizeChanged;

        usernote TheFolder;
        public ViewFolder()
        {
            InitializeComponent();
            lv.AllowDrag = true;
            lv.AllowDrop = true;
        }

        public void Init(usernote folder)
        {
            TheFolder = folder;
            lblCaption.Text = TheFolder.subjectstring;
            InitView();
        }

        //private void cmdSave_Click(object sender, EventArgs e)
        //{
        //    CompleteSave();
        //}

        //void CompleteSave()
        //{
        //    if( !TheFolder.FolderChangePossible(RzWin.Context, txtFolderName.Text) )
        //        return;

        //    TheFolder.subjectstring = txtFolderName.Text;
        //    TheFolder.Update(RzWin.Context);
        //}

        private void cmdNewFolder_Click(object sender, EventArgs e)
        {
            usernote n = TheFolder.FolderAdd(RzWin.Context);
            if (n != null)
            {
                tl.Insert(n);
            }
        }

        private void cmdNewTask_Click(object sender, EventArgs e)
        {
            usernote n = TheFolder.TaskAdd(RzWin.Context);
            if (n != null)
            {
                if (optScreens.Checked)
                    tl.Insert(n);
                else
                    lv.RefreshFromCollection();

                ShowArgs args = new ShowArgs(RzWin.Context, n);
                if( AboutToThrow != null )
                    AboutToThrow(RzWin.Context, args);
            }
        }

        void DoResize()
        {
            if (optList.Checked)
            {
                tl.Visible = false;
                lv.Visible = true;
                lv.Left = 0;
                lv.Width = this.ClientRectangle.Width;
                lv.Height = this.ClientRectangle.Height - lv.Top;
            }
            else
            {
                lv.Visible = false;
                tl.Visible = true;
                tl.Left = 0;
                tl.Width = this.ClientRectangle.Width;
                tl.Height = this.ClientRectangle.Height - tl.Top;
            }

            //this did the auto-expand thing    
            //this.Height = tl.Height + tl.Top;
            //tl.Width = this.ClientRectangle.Width - tl.Left;
        }

        private void tl_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                DoResize();
                if (SizeChanged != null)
                    SizeChanged(null, null);
            }
            catch { }
        }

        private void ViewFolder_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        private void optList_Click(object sender, EventArgs e)
        {
            InitView();
        }

        void InitView()
        {
            if (optList.Checked)
            {
                InitViewList();
            }
            else if (optScreens.Checked)
            {
                InitViewScreen();
            }

            DoResize();
        }

        void InitViewList()
        {
            tl.InitUn();
            lv.Init(TheFolder.TaskArgsGet(RzWin.Context));
        }

        void InitViewScreen()
        {
            lv.Clear();
            tl.Init(TheFolder.TasksGet(RzWin.Context));
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            //CompleteSave();
            SendCloseRequest();
        }

        public event EventHandler CloseRequest;
        void SendCloseRequest()
        {
            if (CloseRequest != null)
                CloseRequest(null, null);
        }

        public event ShowHandler AboutToThrow;

        private void lv_AboutToThrow(Context x, ShowArgs args)
        {
            if (AboutToThrow != null)
                AboutToThrow(x, args);
        }

        private void lv_DragDrop(object sender, DragEventArgs e)
        {
            ////dropped on note
            //usernote target = (usernote)lv.GetObjectByCoordinates(e.X, e.Y);
            //if (target == null)
            //    return;
            
            //ArrayList a = (ArrayList)e.Data.GetData(System.Type.GetType("System.Collections.ArrayList"));
            //if (a == null)
            //    return;
            //if (a.Count == 0)
            //    return;

            //foreach (usernote n in a)
            //{
            //    if (Tools.Strings.StrCmp(n.unique_id, target.unique_id))
            //        return;
            //}

            //TheFolder.TasksInsertBefore(RzWin.Context, a, target);
            //lv.Clear();
            //lv.RefreshFromCollection();
        }

        private void lv_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            TheFolder.TasksReCache(RzWin.Context);
            Init(TheFolder);
        }
    }
}
