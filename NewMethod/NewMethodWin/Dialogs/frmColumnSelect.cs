using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Core;
using Tools.Database;
using System.Collections.Generic;

namespace NewMethod
{
    public partial class frmColumnSelect : Form
    {
        public SysNewMethod xSys;
        public InList CurrentList;
        private CoreClassHandle CurrentClass;
        //private n_relate CurrentRelate;
        private n_column CurrentColumn;
        bool bInhibitChecks = true;

        public frmColumnSelect()
        {
            InitializeComponent();
        }
        //Public Functions
        public void CompleteLoad()
        {
            this.Icon = Tools.Style.StyleCurrent.IconFormDefault;
            this.Text = "Editing Template " + CurrentList.CurrentTemplate.template_name;
            ClearColumn();
            CurrentClass = NMWin.ContextDefault.TheSys.CoreClassGet(CurrentList.CurrentTemplate.class_name.ToLower());
            tv.BeginUpdate();
            tv.Nodes.Clear();
            TreeNode n = tv.Nodes.Add(CurrentClass.Name);
            LoadProps();
        }
        void LoadProps()
        {   
            bInhibitChecks = true;

            lv.Items.Clear();
            foreach (CoreVarValAttribute p in CurrentClass.VarValsGet())
            {
                ListViewItem xLst = lv.Items.Add(p.Name);
                xLst.SubItems.Add(p.Caption);
                xLst.SubItems.Add(p.TheFieldType.ToString());
                xLst.Tag = p;
                xLst.Checked = CurrentList.CurrentTemplate.HasColumn(p.Name, "", "");
            }
            xTime.Start();
        }
        public void ClearImprops()
        {
            bool b = false;
            //ArrayList to_delete = new ArrayList();

            SortedList hold = new SortedList(CurrentList.CurrentTemplate.AllColumns);

            foreach (DictionaryEntry d in hold)
            {
                n_column col = (n_column)d.Value;
                if (!Tools.Strings.StrExt(col.relate_class))
                {

                    CoreVarValAttribute p = null;
                    
                    try
                    { p = CurrentClass.VarValGet(col.field_name.ToLower()); }
                    catch{}

                    if (p == null)
                    {
                        CurrentList.CurrentTemplate.RemoveColumnByPropName(NMWin.ContextDefault, col.field_name.ToLower());
                        //to_delete.Add(col);
                        b = true;
                    }
                }
            }

            //foreach (n_column col in to_delete)
            //{
            //    col.Delete(NMWin.ContextDefault);
            //}

            if (b)
                UpdateList();
        }
        //Private Functions
        private void LoadRelates()
        {
            //tv.BeginUpdate();
            //tv.Nodes.Clear();
            //TreeNode n = tv.Nodes.Add(CurrentClass.Name);
            //n.Tag = new tu_RelateHolder(cl, null, false);

            //TreeNode tr;
            //n_class cr;
            //foreach (n_relate r in cl.CoalesceParentRelates())
            //{
            //    if (r.relate_type == (Int32)Enums.RelationshipType.ParentChild)
            //    {
            //        if (r.LeftClass != null)
            //        {
            //            //cr = r.LeftClass;
            //            cr = xSys.GetClassByName(r.LeftClass.class_name);

            //            tr = n.Nodes.Add(r.name + " : " + cr.class_name);
            //            tr.Tag = new tu_RelateHolder(cr, r, true);
            //        }
            //    }
            //}

            //foreach (n_relate r in cl.ChildRelates.All)
            //{
            //    if (r.relate_type == (Int32)Enums.RelationshipType.ParentChild)
            //    {
            //        //cr = r.RightClass;
            //        cr = xSys.GetClassByName(r.RightClass.class_name);

            //        tr = n.Nodes.Add(r.name + " : " + cr.class_name);
            //        tr.Tag = new tu_RelateHolder(cr, r, false);
            //    }
            //}


            //foreach (n_relate r in cl.BaseClassRelates.All)
            //{
            //    try
            //    {
            //        if (r.relate_type == (Int32)Enums.RelationshipType.Inherit)
            //        {
            //            cr = r.LeftClass;
            //            tr = n.Nodes.Add(r.name + " : " + cr.class_name);
            //            tr.Tag = new tu_RelateHolder(cr, r, false);
            //        }
            //    }
            //    catch { }
            //}

            tv.ExpandAll();
            tv.EndUpdate();
        }
        private void ClearColumn()
        {
            CurrentColumn = null;
            gbColumn.Visible = false;
        }
        private void LoadColumn(n_column c)
        {
            CurrentColumn = c;
            gbColumn.Visible = true;
            txtCaption.SetValue(c.column_caption);
            cboFormat.Visible = true;
            switch (c.data_type)
            {
                case (Int32)FieldType.Int32:
                    cboFormat.SimpleList = "Comma Separated [{0:###,###,##0}]|General [{0:G}]|Number [{0:N}]|Percent [{1:P}]|Hexadecimal [{0:X}]|HH:MM:SS [HMS]";
                    chkTranslateEnum.Visible = c.is_enum;
                    break;
                case (Int32)FieldType.Int64:
                    cboFormat.SimpleList = "Comma Separated [{0:###,###,##0}]|General [{0:G}]|Number [{0:N}]|Percent [{1:P}]|Hexadecimal [{0:X}]|HH:MM:SS [HMS]";
                    break;
                case (Int32)FieldType.Double:
                    cboFormat.SimpleList = "Comma Separated [{0:###,###,##0}]|2 Places Currency [CURRENCY2]|2-6 Places Currency [CURRENCY6]|2 Places [{0:###,###,##0.00}]|2-4 Places [{0:###,###,##0.00##}]|2-6 Places [{0:###,###,##0.00####}]|4 Places [{0:###,###,##0.0000}]|Currency [{0:C}]|General [{0:G}]|Number [{0:N}]|Percent [{1:P}]|Hexadecimal [{0:X}]";
                    break;
                case (Int32)FieldType.DateTime:
                    cboFormat.SimpleList = "Long Date [{0:D}]|Small Date [{0:d}]|Small Date Time [{0:M/d hh:mm}]|Small Time [{0:t}]|Long Date Small Time [{0:g}]";
                    break;
                case (Int32)FieldType.Boolean:
                    cboFormat.SimpleList = "Y/N [YN]";
                    break;
                default:
                    cboFormat.Visible = false;
                    break;
            }

            chkEntryField.SetValue(c.is_entry_field);
            cboFormat.SetValue(c.column_format);

            alignmentSelection.SelectedIndex = alignmentSelection.FindString(c.TextAlign.ToString());
        }
        private void SaveColumn()
        {
            if (CurrentColumn == null)
                return;
            CurrentColumn.column_caption = (String)txtCaption.GetValue();
            if (Tools.Strings.HasString((String)cboFormat.GetValue(), "["))
                CurrentColumn.column_format = Tools.Strings.ParseDelimit((String)cboFormat.GetValue(), "[", 2).Replace("]", "");
            else
                CurrentColumn.column_format = (String)cboFormat.GetValue();
            CurrentColumn.translate_enum = chkTranslateEnum.GetValue_Boolean();
            CurrentColumn.is_entry_field = chkEntryField.GetValue_Boolean();
            CurrentColumn.TextAlign = (HorizontalAlignment)Enum.Parse(typeof(HorizontalAlignment), alignmentSelection.Text);
            chkTranslateEnum.ClearInfo();
            NMWin.ContextDefault.Update(CurrentColumn);
            UpdateList();
        }
        private void UpdateList()
        {
            if (chkInhibit.Checked)
                return;

            CurrentList.ShowCurrentTemplate();
            CurrentList.ReDoSearch(true);
        }
        //Buttons
        private void cmdOK_Click(object sender, EventArgs e)
        {

            this.Close();
        }
        private void cmdClearAll_Click(object sender, EventArgs e)
        {
            if (!NMWin.Leader.AreYouSure("remove all columns from this template"))
                return;

            CurrentList.Clear();
            CurrentList.CurrentTemplate.RemoveAllColumns(NMWin.ContextDefault);

            UpdateList();
        }
        private void cmdClearImprops_Click(object sender, EventArgs e)
        {
            ClearImprops();
        }
        private void cmdApply_Click(object sender, EventArgs e)
        {
            SaveColumn();
        }
        private void cmdDate_Click(object sender, EventArgs e)
        {
            if (CurrentColumn == null)
                return;

            CurrentColumn.data_type = (Int32)FieldType.DateTime;
            NMWin.ContextDefault.Update(CurrentColumn);
        }
        private void cmdCopy_Click(object sender, EventArgs e)
        {
            n_template.CopiedTemplate = CurrentList.CurrentTemplate;
        }
        private void cmdPaste_Click(object sender, EventArgs e)
        {
            if (n_template.CopiedTemplate == null)
                return;
            else
            {
                if (!NMWin.Leader.AreYouSure("replace this column layout with another"))
                    return;

                PasteTemplate(n_template.CopiedTemplate);
            }
        }
        private void PasteTemplate(n_template t)
        {
            CurrentList.CurrentTemplate.RemoveAllColumns(NMWin.ContextDefault);
            CurrentList.CurrentTemplate.AbsorbColumns(NMWin.ContextDefault, t);
            CompleteLoad();
            UpdateList();

        }
        private void cmdDefault_Click(object sender, EventArgs e)
        {
            if (!NMWin.Leader.AreYouSure("remove all columns from this template and add the default columns"))
                return;

            CurrentList.Clear();
            CurrentList.CurrentTemplate.RemoveAllColumns(NMWin.ContextDefault);
            CurrentList.CurrentTemplate.CreateDefaultColumns(NMWin.ContextDefault);

            UpdateList();
        }
        //Control Events
        private void lv_Click(object sender, EventArgs e)
        {
            ClearColumn();
            ListViewItem i;
            try
            {
                i = lv.SelectedItems[0];
            }
            catch (Exception)
            { return; }
            if (i == null)
                return;

            CoreVarValAttribute p = (CoreVarValAttribute)i.Tag;
            n_column c;
            
            //if (CurrentRelate == null)
            //{
                c = CurrentList.CurrentTemplate.GetColumn(p.Name, "", "");
            //}
            //else
            //{
            //    if (CurrentRelate.RelateType == NewMethod.Enums.RelationshipType.Inherit)
            //    {
            //        c = CurrentList.CurrentTemplate.GetColumn(p.name, "", "");
            //    }
            //    else
            //    {
            //        c = CurrentList.CurrentTemplate.GetColumn(p.name, CurrentRelate.LeftClass.class_name, CurrentRelate.name);
            //        if (c == null)
            //            c = CurrentList.CurrentTemplate.GetColumn(p.name, CurrentRelate.RightClass.class_name, CurrentRelate.name);
            //    }
            //}
            if (c != null)
                LoadColumn(c);
        }
        private void lv_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (bInhibitChecks)
                return;
            if (e.Item.Checked)
            {
                //add it
                CurrentList.CurrentTemplate.AddColumnByProp(NMWin.ContextDefault, CurrentClass, (CoreVarValAttribute)e.Item.Tag);
            }
            else
            {
                //remove it
                CurrentList.CurrentTemplate.RemoveColumnByProp(NMWin.ContextDefault, (CoreVarValAttribute)e.Item.Tag);
            }
            UpdateList();
        }
        private void xTime_Tick(object sender, EventArgs e)
        {
            xTime.Stop();
            bInhibitChecks = false;
        }
        private void tv_Click(object sender, EventArgs e)
        {
            //TreeNode n = tv.SelectedNode;
            //if (n == null)
            //    return;

            //try
            //{
            //    tu_RelateHolder h = (tu_RelateHolder)n.Tag;
            //    CurrentClass = h.c;
            //    CurrentRelate = h.r;
            //    LoadProps(CurrentClass);
            //}
            //catch (Exception) { }
        }
        private void tv_MouseDown(object sender, MouseEventArgs e)
        {
            tv.SelectedNode = tv.GetNodeAt(new Point(e.X, e.Y));
        }
        private void cmdChoose_Click(object sender, EventArgs e)
        {
            ArrayList a = NMWin.Data.GetScalarArray ("select class_name + '|' + name from n_template where class_name > '' and name > '' order by class_name, name");
            String s = ToolsWin.Dialogs.ChooseFromArray.Choose(a, "Original template", false);
            if (!Tools.Strings.StrExt(s))
                return;

            String sc = Tools.Strings.ParseDelimit(s, "|", 1);
            String sn = Tools.Strings.ParseDelimit(s, "|", 2);

            n_template t = n_template.GetByName(NMWin.ContextDefault, sn);
            if (t == null)
            {
                NMWin.Leader.Tell("Template '" + sn + "' was not found.");
                return;
            }

            if (!NMWin.Leader.AreYouSure("replace this template"))
                return;

            t.GatherColumns(NMWin.ContextDefault);
            PasteTemplate(t);

        }
        private void cmdClass_Click(object sender, EventArgs e)
        {
            String strClass = NMWin.Leader.AskForString("Class Name", CurrentList.CurrentTemplate.class_name, false, "Class Name");
            CoreClassHandle c = NMWin.ContextDefault.TheSys.CoreClassGet(strClass);
            if (c == null)
                return;
            CurrentList.CurrentTemplate.the_n_class_uid = "";
            CurrentList.CurrentTemplate.class_name = c.Name;
            NMWin.ContextDefault.Update(CurrentList.CurrentTemplate);
            CompleteLoad();
        }
    }
    //public class tu_RelateHolder
    //{
    //    public n_class c;
    //    public n_relate r;
    //    public bool parent;

    //    public tu_RelateHolder(n_class cl, n_relate re, bool p)
    //    {
    //        c = cl;
    //        r = re;
    //        parent = p;
    //    }
    //}
}