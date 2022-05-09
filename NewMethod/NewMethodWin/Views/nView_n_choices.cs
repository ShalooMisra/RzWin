using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Core;

namespace NewMethod
{
    public partial class nView_n_choices : nView
    {
        public CoreVarValAttribute CurrentProp;

        public nView_n_choices()
        {
            InitializeComponent();
            //lvChoices.AboutToThrow += new ShowHandler(this.HandleThrow);
        }

        protected override void InitUn()
        {
            //n_choices.UpdateThisList = null;
            n_choices.UpdateThisListView = null;
            base.InitUn();
        }

        public n_choices CurrentChoices
        {
            get
            {
                return (n_choices)base.GetCurrentObject();
            }
            //set
            //{
            //    if (value is nObject)
            //    {
            //        base.SetCurrentObject(value);
            //        CompleteLoad();
            //    }
            //}
        }

        public override void CompleteLoad()
        {
            txtName.Text = CurrentChoices.name;
            //txtClassTag.Text = GetCurrentObject().class_tag;
            //chkNeedsUpdate.Checked = GetCurrentObject().needs_update;
            txtName.Enabled = true;
            if (Tools.Strings.StrExt(txtName.Text))
                txtName.Enabled = false;
            ShowChoices();


            base.CompleteLoad();
        }

        public void ShowChoices()
        {
            lvChoices.AsyncMode = false;
            lvChoices.ShowTemplate("choices_choice", "n_choice", true);
            lvChoices.ShowData("n_choice", "the_n_choices_uid = '" + CurrentChoices.unique_id + "'", "the_n_choices_order");
        }

        private void nView_n_choices_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        public virtual void DoResize()
        {
            try
            {
                lvChoices.Width = this.ClientRectangle.Width - lvChoices.Left;
                lvChoices.Height = this.ClientRectangle.Height - lvChoices.Top;
            }
            catch (Exception)
            { }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            CompleteSaveAndUpdate();
            n_choices.CacheChoiceList(NMWin.ContextDefault, CurrentChoices.name);

            CurrentChoices.ChoicesChangedFire();
            //if (n_choices.UpdateThisList != null)
            //    n_choices.UpdateThisList.ListRefresh();
            if (n_choices.UpdateThisListView != null)
            {
                if (n_choices.UpdateThisListView is IUpdateListView)
                    ((IUpdateListView)n_choices.UpdateThisListView).RefreshList();
            }
        }

        public override void CompleteSave()
        {
            CurrentChoices.name = txtName.Text;
            base.CompleteSave();
        }

        private void lvChoices_AboutToAdd(object sender, AddArgs args)
        {
            args.Handled = true;
            n_choice c = CurrentChoices.AddNew_the_n_choice(NMWin.ContextDefault);
            NMWin.ContextDefault.Insert(c);

            NMWin.ContextDefault.Show(c);
        }

        private void cmdPaste_Click(object sender, EventArgs e)
        {
            String s = NMWin.Leader.AskForPaste();
            if (!Tools.Strings.StrExt(s))
                return;

            AddStringChoices(s);
        }

        private void cmdRemoveAll_Click(object sender, EventArgs e)
        {
            if (!NMWin.Leader.AreYouSure("delete these choices"))
                return;

            CurrentChoices.DeleteChoices(NMWin.ContextDefault);
            ShowChoices();
        }

        private void cmdAlphabetize_Click(object sender, EventArgs e)
        {
            CurrentChoices.AlphabetizeChoices(NMWin.ContextDefault);
            ShowChoices();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            String s = NMWin.Leader.AskForString("New choices:", "", true, "Choices");
            if (!Tools.Strings.StrExt(s))
                return;

            AddStringChoices(s);
        }

        protected virtual void AddStringChoices(String s)
        {
            s = s.Replace("\r\n", "\n");
            String[] ary = s.Split("\n".ToCharArray());

            foreach (String st in ary)
            {
                CurrentChoices.AddChoice(NMWin.ContextDefault, st, false);
            }
            CurrentChoices.CacheChoiceList(NMWin.ContextDefault);
            ShowChoices();
        }

        private void cmdUp_Click(object sender, EventArgs e)
        {
            MoveSelected(-1);
        }

        private void cmdDown_Click(object sender, EventArgs e)
        {
            MoveSelected(1);
        }

        private void MoveSelected(long m)
        {
            n_choice c = (n_choice)lvChoices.GetSelectedObject();

            if (c == null)
                return;

            long n = c.the_n_choices_order + m;
            if (n < 0)
                return;

            ArrayList a = CurrentChoices.Get_the_n_choice_collection(NMWin.ContextDefault);

            foreach (n_choice ch in a)
            {
                if (ch.the_n_choices_order == n) //the one to switch with
                {
                    ch.the_n_choices_order = c.the_n_choices_order;
                    NMWin.ContextDefault.Update(ch);

                    c.the_n_choices_order = n;
                    NMWin.ContextDefault.Update(c);
                }
            }

            ShowChoices();
            //System.Threading.Thread.Sleep(500);
            lvChoices.HighlightByID(c.unique_id);
        }

        private void cmdSplit_Click(object sender, EventArgs e)
        {
            if (!NMWin.Leader.AreYouSure("split all of these entries by commas"))
                return;

            CurrentChoices.SplitChoices(NMWin.ContextDefault, ",");
            CompleteLoad();
        }

        
    }
}

