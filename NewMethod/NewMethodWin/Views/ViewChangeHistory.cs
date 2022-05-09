using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core;

namespace NewMethod
{
    public partial class ViewChangeHistory : UserControl
    {
        ContextNM TheContext;
        ItemTag TheItem;
        ChangeHistoryInfo Info;

        //Constructors
        public ViewChangeHistory()
        {
            InitializeComponent();
        }
        //Public functionds
        public void CompleteLoad(ContextNM x, ItemTag i)
        {
            TheContext = x;
            TheItem = i;
            DataTable changes = null;
            Info = TheContext.xSys.GetChangeHistory(TheContext, TheItem, ref changes, null);
            LoadLV();
            Search();
        }
        //Private Functions
        private void ShowChangeHistory(List<String> show_props)
        {
            DataTable changes = null;
            wb.ReloadWB();
            Info = TheContext.xSys.GetChangeHistory(TheContext, TheItem, ref changes, show_props);
            wb.Add(Info.TheHTML.ToString());
        }
        private void LoadLV()
        {
            lv.Items.Clear();
            lv.SuspendLayout();
            try
            {
                List<CoreVarValAttribute> lst = new List<CoreVarValAttribute>();
                if (chkOnlyChanged.Checked)
                    lst = Info.TheProps;
                else
                    lst = TheContext.TheSys.CoreClassGet(TheItem.ClassId).VarValsGet();
                TheContext.xSys.SortList(ref lst);
                foreach (CoreVarValAttribute v in lst)
                {
                    if (TheContext.xSys.IsIDProp(TheContext, v))
                        continue;
                    if (TheContext.xSys.IsIgnoreProp(TheContext, v))
                        continue;
                    ListViewItem xlst = lv.Items.Add(v.Caption);
                    xlst.Tag = v.Name;
                    xlst.Checked = true;
                }
            }
            catch { }
            lv.ResumeLayout();
        }
        private void DoResize()
        {
            try
            {
                pCriteria.Height = this.ClientRectangle.Height - pCriteria.Top - 10;
                lv.Height = pCriteria.Height - lv.Height - 10;
                wb.Width = this.ClientRectangle.Width - wb.Left - 10;
                wb.Height = pCriteria.Height;
            }
            catch { }
        }
        private void Search()
        {
            List<String> show_props = new List<String>();
            foreach (ListViewItem xLst in lv.CheckedItems)
            {
                show_props.Add(xLst.Tag.ToString());
            }
            if (show_props.Count <= 0)
                show_props = null;
            ShowChangeHistory(show_props);
        }
        private void CheckUnCheck(bool check)
        {
            foreach (ListViewItem xLst in lv.Items)
            {
                xLst.Checked = check;
            }
        }
        //Buttons
        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            Search();
        }
        //Control Events
        private void ViewChangeHistory_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            CheckUnCheck(chk.Checked);
        }
        private void chkOnlyChanged_CheckedChanged(object sender, EventArgs e)
        {
            LoadLV();
        }
    }
}
