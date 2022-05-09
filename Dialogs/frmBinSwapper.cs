using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace Rz5
{
    public partial class frmBinSwapper : Form
    {
        //Private Variables
        private SysNewMethod xSys
        {
            get
            {
                return RzWin.Context.Sys;
            }
        }

        //Constructors
        public frmBinSwapper()
        {
            InitializeComponent();
        }
        //Public Functions
        public bool CompleteLoad()
        {
            lvResults.ShowTemplate("binswapper_lvview", "partrecord", RzWin.User.TemplateEditor);
            return true;
        }
        //Private Functions
        private void RunSearch()
        {
            if (!Tools.Strings.StrExt(ctl_binsearch.GetValue_String()))
            {
                RzWin.Leader.Tell("You need to enter a value into the search section before doing a search.");
                return;
            }
            lvResults.ShowData("partrecord", "location like '" + ctl_binsearch.GetValue_String() + "%'", "fullpartnumber", 200);
        }
        private void SwapBins()
        {
            if (!Tools.Strings.StrExt(ctl_binswap.GetValue_String()))
            {
                RzWin.Leader.Tell("You need to enter a value into the swap section before doing a search.");
                return;
            }
            if (!RzWin.Leader.AskYesNo("Are you sure you want to update the parts in the results list with the bin location '" + ctl_binswap.GetValue_String() + "'?"))
                return;
            RunSwap(ctl_binswap.GetValue_String());
        }
        private void RunSwap(string swapto)
        {
            if (!Tools.Strings.StrExt(swapto))
                return;
            ListView lv = lvResults.GetListViewControl();
            if (lv == null)
                return;
            ArrayList a = new ArrayList();
            foreach (ListViewItem xLst in lv.Items)
            {
                string id = xLst.Tag.ToString();
                if (!Tools.Strings.StrExt(id))
                    continue;
                a.Add(id);
            }
            string inn = nTools.GetIn(a);
            if (!Tools.Strings.StrExt(inn))
                return;

            RzWin.Context.Execute("update partrecord set location = '" + RzWin.Context.Filter(swapto) + "' where unique_id in (" + inn + ")");
            RzWin.Leader.Tell("Swapped!");
            lvResults.ShowData("partrecord", "location like '" + swapto + "%'", "fullpartnumber", 200);
        }
        //Buttons
        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RunSearch();
        }
        private void cmdSwap_Click(object sender, EventArgs e)
        {
            SwapBins();
        }
    }
}
