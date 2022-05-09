using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NewMethod;
using Core;

namespace Rz5
{
    //fullpartnumber
    //quantity
    //manufacturer
    //datecode
    //alloc
    //buytype
    //cost
    //low price
    //price
    //leadtime
    //userdata1
    //notes
    //vendor
    //boxcode
    //boxnumber
    //altpart
    //altqty
    //confirmeddate
    //datecreated
    //importid
    //companyphone
    //stocktype
    public partial class search_soft : nSearch
    {
        Dictionary<Int32, nSearchCriteria> dControls = new Dictionary<Int32, nSearchCriteria>();
        ArrayList aFieldsOriginal = new ArrayList();
        ArrayList aFieldsAlpha = new ArrayList();

        public search_soft()
        {
            InitializeComponent();
        }
        //Public Functions
        public override void CompleteLoad(CoreClassHandle c)
        {
            base.CompleteLoad(c);
            FriendlyName = "PartRecord";
            DoResize();
            LoadSearchableFields();
            ClearCriteria();
            DisplayFields();
        }
        public override void DoResize()
        {
            try
            {
                SetBorder();
                lv.Top = pbTop.Bottom + 2;
                lv.Left = pbLeft.Right + 2;
                vs.Left = (pbRight.Left - vs.Width) - 2;
                gb.Top = lv.Top - 2;
                vs.Top = gb.Top;
                vs.Height = gb.Bottom - vs.Top;
                gb.Left = (vs.Left - gb.Width) - 2;
                lv.Width = (gb.Left - lv.Left) - 3;
                optAlpha.Top = lv.Bottom;
                optLogical.Top = optAlpha.Top;
                cmdSearch.Top = gb.Bottom + 3;
                cmdSearch.Left = lv.Left;
                cmdSearch.Width = vs.Right - cmdSearch.Left;
            }
            catch (Exception)
            { }
        }
        public override String GetWhere()
        {
            String s = "";
            foreach (KeyValuePair<Int32, nSearchCriteria> kvp in dControls)
            {
                String hold = "";
                try { hold = ((nSearchCriteria)kvp.Value).GetWhere(); }
                catch { }
                if (!Tools.Strings.StrExt(hold))
                    continue;
                if (Tools.Strings.StrExt(s))
                    s += hold;
                else
                    s += hold.Replace(" and ", " ");
            }
            return s;
        }
        //Private Functions
        private void SetBorder()
        {
            try
            {
                pbTop.Top = 0;
                pbTop.Left = -5;
                pbTop.Height = 2;
                pbTop.Width = this.Width + 5;
                pbTop.BringToFront();

                pbBottom.Top = this.Height - 2;
                pbBottom.Left = -5;
                pbBottom.Height = 3;
                pbBottom.Width = this.Width + 5;
                pbBottom.BringToFront();

                pbLeft.Top = -5;
                pbLeft.Left = 0;
                pbLeft.Height = this.Height + 5;
                pbLeft.Width = 2;
                pbLeft.BringToFront();

                pbRight.Top = -5;
                pbRight.Left = this.Width - 2;
                pbRight.Height = this.Height + 5;
                pbRight.Width = 2;
                pbRight.BringToFront();
            }
            catch
            { }
        }
        private void LoadSearchableFields()
        {
            aFieldsOriginal = xSys.GetMainSearchProperties(CurrentClass.Name);
            aFieldsAlpha = xSys.GetMainSearchProperties(CurrentClass.Name);
            aFieldsAlpha.Sort();
        }
        private void DisplayFields()
        {
            lv.Items.Clear();
            ListViewItem xLst;
            ArrayList fields = null;
            if (optAlpha.Checked)
            {
                if (aFieldsAlpha == null)
                    return;
                if (aFieldsAlpha.Count <= 0)
                    return;
                fields = aFieldsAlpha;
            }
            else
            {
                if (aFieldsOriginal == null)
                    return;
                if (aFieldsOriginal.Count <= 0)
                    return;
                fields = aFieldsOriginal;
            }
            if (fields == null)
                return;
            if (fields.Count <= 0)
                return;
            foreach (String s in fields)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                CoreVarValAttribute p = CurrentClass.VarValGet(s.ToLower().Trim());
                if (p == null)
                    continue;
                xLst = lv.Items.Add(p.Caption);
                xLst.Tag = p;
            }
        }
        private void ClearCriteria()
        {
            gb.Controls.Clear();
            SetScrollBar();
        }
        private void SetScrollBar()
        {
            Int32 i = gb.Controls.Count - 4;
            if (i <= 0)
            {
                vs.Value = 0;
                vs.Maximum = 0;
                return;
            }
            vs.Maximum = i;
            vs.Value = 0;
        }
        private void SetFieldCriteria(CoreVarValAttribute p, Boolean bAdd)
        {
            try
            {
                if (p == null)
                    return;
                nSearchCriteria ctrl = new nSearchCriteria();
                if (!bAdd)
                {
                    foreach (KeyValuePair<Int32, nSearchCriteria> kvp in dControls)
                    {
                        nSearchCriteria c = (nSearchCriteria)kvp.Value;
                        if (c.CurrentProp == null)
                            continue;
                        if (!Tools.Strings.StrCmp(c.CurrentProp.Name, p.Name))
                            continue;
                        dControls.Remove(kvp.Key);
                        break;
                    }
                    Dictionary<Int32, nSearchCriteria> dHold = new Dictionary<Int32, nSearchCriteria>();
                    foreach (KeyValuePair<Int32, nSearchCriteria> kvp in dControls)
                    {
                        Int32 i = dHold.Count + 1;
                        dHold.Add(i, kvp.Value);
                    }
                    dControls = dHold;
                    LoadFieldCriteria();
                }
                else
                {
                    Int32 i = dControls.Count + 1;
                    ctrl.CompleteLoad(p);
                    dControls.Add(i, ctrl);
                    LoadFieldCriteria();
                }
            }
            catch (Exception)
            { }
        }
        private void LoadFieldCriteria()
        {
            try
            {
                gb.Controls.Clear();
                nSearchCriteria ctrl;
                for (Int32 x = 1; x <= dControls.Count; x++)
                {
                    if (x - 1 >= vs.Value && x <= vs.Value + 4)
                    {
                        dControls.TryGetValue(x, out ctrl);
                        SetViewableControl(ctrl);
                    }
                }
                SetScrollBar();
            }
            catch (Exception)
            { }
        }
        private void SetViewableControl(nSearchCriteria ctrl)
        {
            try
            {
                Int32 iTopMargin = 15;
                Int32 iLeftMargin = 5;
                Int32 index;
                index = gb.Controls.Count + 1;
                if (index == 1)
                {
                    ((Control)ctrl).Top = iTopMargin;
                    ((Control)ctrl).Left = iLeftMargin;
                    ((Control)ctrl).Width = gb.Width - (iLeftMargin * 2);
                }
                else
                {
                    Control c = GetControlByIndex(gb.Controls.Count);
                    if (c != null)
                    {
                        ((Control)ctrl).Top = c.Bottom + 5;
                        ((Control)ctrl).Left = iLeftMargin;
                        ((Control)ctrl).Width = gb.Width - (iLeftMargin * 2);
                    }
                }
                ((Control)ctrl).Height = (Int32)55;
                ((Control)ctrl).Visible = true;
                ctrl.DoResize();
                gb.Controls.Add(((Control)ctrl));
            }
            catch (Exception)
            { }
        }
        private Control GetControlByIndex(Int32 index)
        {
            Int32 x = 0;
            Control ctrl = null;
            foreach (Control c in gb.Controls)
            {
                x++;
                ctrl = c;
                if (x == index)
                    return ctrl;
            }
            return null;
        }
        //Buttons
        private void cmdSearch_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close(); 
        }
        //Control Events
        private void search_soft_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void lv_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            try
            {
                ListViewItem xLst = (ListViewItem)e.Item;
                if (xLst == null)
                    return;
                CoreVarValAttribute p = (CoreVarValAttribute)xLst.Tag;
                if (p == null)
                    return;
                SetFieldCriteria(p, xLst.Checked);
            }
            catch (Exception)
            { }
        }
        private void optAlpha_CheckedChanged(object sender, EventArgs e)
        {
            DisplayFields();
        }
        private void optLogical_CheckedChanged(object sender, EventArgs e)
        {
            DisplayFields();
        }
    }
}
