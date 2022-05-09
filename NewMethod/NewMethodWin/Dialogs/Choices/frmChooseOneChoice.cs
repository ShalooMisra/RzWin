using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ToolsWin;

namespace NewMethod
{
    public partial class frmChooseOneChoice : ToolsWin.Dialogs.OKCancel
    {
        public static String Choose(SysNewMethod xs, String list_name, String caption)
        {
            frmChooseOneChoice f = new frmChooseOneChoice();
            f.Init(xs, list_name, caption);
            f.ShowDialog();          
            String ret = f.SelectedChoice;
            try
            {
                f.Close();
                f.Dispose();
                f = null;
            }
            catch { }

            return ret;
        }

        public static String Choose(SysNewMethod xs, List<string> list, String caption)
        {
            frmChooseOneChoice f = new frmChooseOneChoice();
            f.Init(xs, list, caption);
            f.ShowDialog();
            String ret = f.SelectedChoice;
            try
            {
                f.Close();
                f.Dispose();
                f = null;
            }
            catch { }

            return ret;
        }

        public String SelectedChoice = "";
        private n_choices CurrentList;

        public frmChooseOneChoice()
        {
            InitializeComponent();
        }

        bool AutoOnMouse = true;
        public void Init(SysNewMethod xs, String list_name, String caption, FormStartPosition startPos = FormStartPosition.CenterScreen, bool allowAdd = false)
        {
            AutoOnMouse = false;
            StartPosition = startPos;
            base.Init();
            if (allowAdd)
                cmdAdd.Visible = NMWin.ContextDefault.CheckPermit(Permissions.ThePermits.ManageChoiceLists);
            else
                cmdAdd.Visible = false;
            lst.Items.Clear();
            ChoiceHandle h = n_choices.ChoiceHandleGet(NMWin.ContextDefault, list_name);

            foreach (String c in h.Choices)
            {
                lst.Items.Add(c);
            }
            lblCaption.Text = caption;
            this.Text = "";

            //AutoCompleteSource = AutoCompleteSource.ListItems;
            //ctl_target_manufacturer.GetCombo().AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        public void Init(SysNewMethod xs, List<string> theList, String caption, FormStartPosition startPos = FormStartPosition.CenterScreen, bool allowAdd = false)
        {
            AutoOnMouse = false;
            StartPosition = startPos;
            base.Init();
            if (allowAdd)
                cmdAdd.Visible = NMWin.ContextDefault.CheckPermit(Permissions.ThePermits.ManageChoiceLists);
            else
                cmdAdd.Visible = false;
            lst.Items.Clear();
            

            foreach (String c in theList)
            {
                lst.Items.Add(c);
            }
            lblCaption.Text = caption;
            this.Text = "";
        }

        //public void CompleteLoad(n_choices c, String strCaption)
        //{            
        //    CurrentList = c;
        //    //StartPosition = FormStartPosition.CenterScreen;
        //    //lst.Items.Clear();
        //    foreach (n_choice ch in c.AllChoices)
        //    {
        //        lst.Items.Add(ch.name);
        //    }
        //    lblCaption.Text = strCaption;

        //    cmdAdd.Visible = NMWin.ContextDefault.CheckPermit(Permissions.ThePermits.ManageChoiceLists);
        //}

        public override void Cancel()
        {
            SelectedChoice = "";
            base.Cancel();
        }


        public override void OK()
        {
            if (lst.SelectedItem == null)
                return;

            if (!Tools.Strings.StrExt(lst.SelectedItem.ToString()))
                return;

            SelectedChoice = lst.SelectedItem.ToString().Trim();
            base.OK();
        }

        private void lst_DoubleClick(object sender, EventArgs e)
        {
            OK();
        }

        private void frmChooseOneChoice_Activated(object sender, EventArgs e)
        {
            if (AutoOnMouse)
                ToolsWin.Screens.SetOnMouse(this);
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            String s = NMWin.Leader.AskForString("Please type the new list entry:", "", false, "New Entry");
            if (!Tools.Strings.StrExt(s))
                return;

            n_choice c = CurrentList.GetChoice(NMWin.ContextDefault, s);
            if (c != null)
            {
                NMWin.Leader.Tell("The entry '" + s + "' already exists in this list.");
                return;
            }

            CurrentList.AddChoice(NMWin.ContextDefault, s);
            SelectedChoice = s;
            this.Hide();
        }

        public override void DoResize()
        {
            base.DoResize();

            try
            {
                lst.Left = 0;
                lst.Height = pContents.ClientRectangle.Height - lst.Top;
                lst.Width = pContents.ClientRectangle.Width;
            }
            catch { }
        }

        private void frmChooseOneChoice_FormClosed(object sender, FormClosedEventArgs e)
        {
           // SelectedChoice = null;
        }

    }
}