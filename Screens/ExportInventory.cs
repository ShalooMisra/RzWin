using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Core;
using NewMethod;
using Tools.Database;

namespace Rz5
{
    public partial class ExportInventory : UserControl, ICompleteLoad
    {
        //Private Variables
        private SysNewMethod xSys
        {
            get
            {
                return RzWin.Context.xSys;
            }
        }
        private exporttemplate xTemplate;
        private Boolean bShowATemplate = false;
        private int sColumnExcess = -1;
        private int sColumnConsigned = -1;
        private int sColumnOffers = -1;

        //Constructors
        public ExportInventory()
        {
            InitializeComponent();
        }
        //Public Functions
        public void CompleteLoad()
        {
            DoResize();
            ts2.TabPages.Remove(tabOffers);
            //if (Rz3App.xLogic.IsPMT)
            //{
            //    ts2.TabPages.Add(tabOffers);
            //    ctl_exportoffers.Visible = true;
            //    ctl_only_selected_offers.Visible = true;
            //}
            ctl_adqty.Visible = true;
            ctl_adpercent.Visible = true;
            lvTemplates.ShowTemplate("exportinvtemplateview", "exporttemplate", RzWin.User.TemplateEditor);
            bShowATemplate = true;
            LoadTemplates();
            LoadImportLists();
            LoadConsignmentLists();
            //if (Rz3App.xLogic.IsPMT)
            //    LoadOfferLists();
        }
        public void DoResize()
        {
            try
            {
                if(this.Width < 710)
                    this.Width = 710;
                if(this.Height < 378)
                    this.Height = 378;
                SetBorder();
                lvTemplates.Top = 3;
                lvTemplates.Left = 3;
                cmdExport.Left = lvTemplates.Left;
                cmdExport.Top = pbBottom.Top - (cmdExport.Height + 3);
                lvTemplates.Height = (cmdExport.Top - lvTemplates.Top) - 3;
                gbTemplate.Top = lvTemplates.Top;
                gbTemplate.Left = (pbRight.Left - gbTemplate.Width) - 3;
                TS.Left = gbTemplate.Left;
                TS.Top = chkAll.Bottom + 3;
                TS.Height = (pbBottom.Top - TS.Top) - 3;
                chkAll.Left = gbTemplate.Left;
                lvTemplates.Width = (gbTemplate.Left - lvTemplates.Left) - 3;
                cmdExport.Width = lvTemplates.Width;
                cmdNew.Top = (tabGeneral.ClientRectangle.Height - cmdNew.Height) - 3;
                cmdDelete.Top = cmdNew.Top;
                cmdSave.Top = cmdNew.Top;
                cmdRefresh.Top = cmdNew.Top;
                ctl_withcost.Top = (cmdDelete.Top - ctl_withcost.Height) - 2;
                ctl_only_selected_consign.Top = ctl_withcost.Top;
                ctl_only_selected.Top = ctl_withcost.Top;
                ts2.Height = (ctl_withcost.Top - ts2.Top) - 3;
                ts2.Width = tabGeneral.ClientRectangle.Width - (ts2.Left * 2);
                gbSQL.Width = tabSQL.ClientRectangle.Width - (gbSQL.Left * 2);
                cmdEnable.Width = gbSQL.Width;
                cmdEnable.Top = (tabSQL.ClientRectangle.Height - cmdEnable.Height) - 3;
                gbSQL.Height = (cmdEnable.Top - gbSQL.Top) - 3;
                ctl_only_selected_offers.Top = ctl_withcost.Top;
                lvTemplates.DoResize();
                lvColumns.DoResize(); 
            }
            catch (Exception)
            { }
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
            catch (Exception)
            { }
        }
        private void LoadTemplates()
        {
            lvTemplates.ShowData("exporttemplate", "", "exportname", 200);
        }
        private void LoadImportLists()
        {
            try
            {
                lvImports.Items.Clear();
                DataTable dt = RzWin.Context.Select("select distinct(isnull(importid,'')), isnull(companyname,''), isnull(date_created, getdate()) from partrecord where stocktype in ('oem', 'excess') group by importid, companyname, date_created");
                if (dt == null)
                    return;
                foreach (DataRow dr in dt.Rows)
                {
                    if (!Tools.Strings.StrExt(dr[0].ToString()))
                        continue;
                    ListViewItem xLst = lvImports.Items.Add(dr[1].ToString());
                    xLst.SubItems.Add(dr[0].ToString());
                    xLst.SubItems.Add(nData.NullFilter_DateTime(dr[2]).ToShortDateString());
                }
            }
            catch (Exception)
            { }
        }
        private void LoadConsignmentLists()
        {
            try
            {
                lvConsign.Items.Clear();
                DataTable dt = RzWin.Context.Select("select distinct(isnull(importid,'')), isnull(companyname,''), isnull(date_created, getdate()) from partrecord where stocktype in ('consign', 'consigned') group by importid, companyname, date_created");
                if (dt == null)
                    return;
                foreach (DataRow dr in dt.Rows)
                {
                    if (!Tools.Strings.StrExt(dr[0].ToString()))
                        continue;
                    ListViewItem xLst = lvConsign.Items.Add(dr[1].ToString());
                    xLst.SubItems.Add(dr[0].ToString());
                    xLst.SubItems.Add(nData.NullFilter_DateTime(dr[2]).ToShortDateString());
                }
            }
            catch (Exception)
            { }
        }
        private void NewTemplate()
        {
            xTemplate = exporttemplate.NewTemplate(RzWin.Context);
            //xTemplate.includeheader = true;
            //xTemplate.qtyabovezero = true;
            //xTemplate.pnlength = true;
            //xTemplate.exportstock = true;
            //xTemplate.exportconsigned = true;
            //xTemplate.exportexcess = true;
            //xTemplate.exportname = "New Export Template (" + DateTime.Now.ToShortDateString() + ")";
            //xTemplate.exportfile = "c:\\Export_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + "_" + ".csv";
            //xTemplate.templatename = "";
            //xTemplate.Insert(RzWin.Context);
            ShowTemplate();
        }
        private void ShowTemplate()
        {
            try
            {
                cmdExport.Text = "Run Export";
                if (xTemplate == null)
                    return;
                cmdExport.Text = "Run " + xTemplate.exportname + " Export";
                if (!SetColumnTemplate(xTemplate))
                {
                    RzWin.Leader.Tell("There was an error in setting up the columns for this export. Please reload this screen.");
                    return;
                }
                NMWin.LoadFormValues(this, xTemplate);
                SetImportLists();
                SetConsignmentLists();
                SetOffersLists();
                if (!Tools.Strings.StrExt(xTemplate.exportstring))
                    SetExportSQL();
            }
            catch(Exception)
            {}
        }
        private Boolean SetColumnTemplate(exporttemplate xt)
        {
            try
            {
                n_template t = null;
                if (xt == null)
                    return false;
                if (Tools.Strings.StrExt(xt.templatename))
                    t = n_template.GetByName(RzWin.Context, xt.templatename);
                if (t == null)
                {
                    t = exporttemplate.GetDefaultExportTemplate(RzWin.Context); //GetNewDefaultTemplate();
                    xt.templatename = t.template_name;
                    xt.Update(RzWin.Context);
                }
                if (t == null)
                    return false;
                lvColumns.ShowTemplate(t.template_name, "partrecord", RzWin.User.TemplateEditor);
                return true;
            }
            catch (Exception)
            { return false; }
        }
        private void ShowATemplate()
        {
            try
            {
                if (lvTemplates.GetListViewControl().Items.Count <= 0)
                {
                    NewTemplate();
                    return;
                }
                lvTemplates.SelectFirst(true);
            }
            catch (Exception)
            { }
        }
        private void SetImportLists()
        {
            try
            {
                Boolean bCheck = false;
                String imports = "";
                if (xTemplate.only_selected)
                {
                    if (!Tools.Strings.StrExt(xTemplate.exportonly))
                        return;
                    imports = xTemplate.exportonly;
                    bCheck = true;
                    CheckAllItems(false, lvImports);
                }
                else
                {
                    CheckAllItems(true, lvImports);
                    if (!Tools.Strings.StrExt(xTemplate.donotexport))
                        return;
                    imports = xTemplate.donotexport;
                }
                if (lvImports.Items.Count <= 0)
                    return;
                string[] s = Tools.Strings.Split(imports, "|~|");
                if (s.Length <= 0)
                    return;
                Dictionary<String, String> d = new Dictionary<string, string>(); 
                for (Int32 i = 0; i < s.Length; i++)
                {
                    if (!Tools.Strings.StrExt(s[i]))
                        continue;
                    try
                    {
                        d.Add(s[i], s[i]);
                    }
                    catch (Exception)
                    { }
                }
                if (d.Count > 0)
                {
                    foreach (ListViewItem xLst in lvImports.Items)
                    {
                        String str = "";
                        d.TryGetValue(xLst.SubItems[1].Text, out str);
                        if (Tools.Strings.StrExt(str))
                            xLst.Checked = bCheck;
                    }
                }
            }
            catch (Exception)
            { }
        }
        private void SetConsignmentLists()
        {
            try
            {
                Boolean bCheck = false;
                String imports = "";
                if (xTemplate.only_selected_consign)
                {
                    if (!Tools.Strings.StrExt(xTemplate.exportonly_consign))
                        return;
                    imports = xTemplate.exportonly_consign;
                    bCheck = true;
                    CheckAllItems(false, lvConsign);
                }
                else
                {
                    CheckAllItems(true, lvConsign);
                    if (!Tools.Strings.StrExt(xTemplate.donotexport_consign))
                        return;
                    imports = xTemplate.donotexport_consign;
                }
                if (lvConsign.Items.Count <= 0)
                    return;
                string[] s = Tools.Strings.Split(imports, "|~|");
                if (s.Length <= 0)
                    return;
                Dictionary<String, String> d = new Dictionary<string, string>();
                for (Int32 i = 0; i < s.Length; i++)
                {
                    if (!Tools.Strings.StrExt(s[i]))
                        continue;
                    try
                    {
                        d.Add(s[i], s[i]);
                    }
                    catch (Exception)
                    { }
                }
                if (d.Count > 0)
                {
                    foreach (ListViewItem xLst in lvConsign.Items)
                    {
                        String str = "";
                        d.TryGetValue(xLst.SubItems[1].Text, out str);
                        if (Tools.Strings.StrExt(str))
                            xLst.Checked = bCheck;
                    }
                }
            }
            catch (Exception)
            { }
        }
        private void SetOffersLists()
        {
            try
            {
                Boolean bCheck = false;
                String imports = "";
                if (xTemplate.only_selected_offers)
                {
                    if (!Tools.Strings.StrExt(xTemplate.exportonly_offers))
                        return;
                    imports = xTemplate.exportonly_offers;
                    bCheck = true;
                    CheckAllItems(false, lvOffers);
                }
                else
                {
                    CheckAllItems(true, lvOffers);
                    if (!Tools.Strings.StrExt(xTemplate.donotexport_offers))
                        return;
                    imports = xTemplate.donotexport_offers;
                }
                if (lvOffers.Items.Count <= 0)
                    return;
                string[] s = Tools.Strings.Split(imports, "|~|");
                if (s.Length <= 0)
                    return;
                Dictionary<String, String> d = new Dictionary<string, string>();
                for (Int32 i = 0; i < s.Length; i++)
                {
                    if (!Tools.Strings.StrExt(s[i]))
                        continue;
                    try
                    {
                        d.Add(s[i], s[i]);
                    }
                    catch (Exception)
                    { }
                }
                if (d.Count > 0)
                {
                    foreach (ListViewItem xLst in lvOffers.Items)
                    {
                        String str = "";
                        d.TryGetValue(xLst.SubItems[1].Text, out str);
                        if (Tools.Strings.StrExt(str))
                            xLst.Checked = bCheck;
                    }
                }
            }
            catch (Exception)
            { }
        }
        private void SetExportSQL()
        {
            try
            {
                if (Tools.Strings.StrExt(xTemplate.exportstring))
                    return;
                if (xTemplate.manualsql)
                    return;
                xTemplate.exportwhere = xTemplate.GetExportWhere(RzWin.Context, GetExportList(), GetImportExceptionList(), GetConsignList(), GetConsignExceptionList());
                xTemplate.fieldstring = GetColumnList(true);
                xTemplate.exportcaptions = GetColumnList(false);
                string group = "";
                if (exporttemplate.HasQtyField(GetColumnList(lvColumns)))
                    group = " group by " + exporttemplate.GetGroupByList(GetColumnList(lvColumns));
                if (Tools.Strings.StrExt(xTemplate.fieldstring))
                    xTemplate.exportstring = "select " + xTemplate.fieldstring + " from partrecord " + (Tools.Strings.StrExt(xTemplate.exportwhere) ? " where " + xTemplate.exportwhere : "") + group;
                xTemplate.Update(RzWin.Context);
                NMWin.LoadFormValues(gbSQL, xTemplate);
            }
            catch (Exception)
            { }
        }
        private void DeleteTemplate()
        {
            if (xTemplate == null)
                return;
            xTemplate.Delete(RzWin.Context);
            bShowATemplate = true;
        }
        private void SaveTemplate()
        {
            try
            {
                if (xTemplate == null)
                    return;
                if (!ctl_manualsql.GetValue_Boolean())
                {
                    if (!ctl_exportstock.GetValue_Boolean() && !ctl_exportexcess.GetValue_Boolean() && !ctl_exportoffers.GetValue_Boolean() && !ctl_exportconsigned.GetValue_Boolean())
                    {
                        RzWin.Leader.Tell("At least one stock type must be selected. Auto-selecting the stock option.");
                        ctl_exportstock.SetValue(true);
                    }
                }
                NMWin.GrabFormValues(this, xTemplate);
                xTemplate.donotexport = "";
                xTemplate.exportonly = "";
                xTemplate.donotexport_consign = "";
                xTemplate.exportonly_consign = "";
                xTemplate.donotexport_offers = "";
                xTemplate.exportonly_offers = "";
                if (!xTemplate.manualsql)
                {
                    if (xTemplate.exportexcess)
                    {
                        if (xTemplate.only_selected)
                        {
                            xTemplate.donotexport = "";
                            xTemplate.exportonly = GetShowList();
                        }
                        else
                        {
                            xTemplate.donotexport = GetNoShow();
                            xTemplate.exportonly = "";
                        }
                    }
                    if (xTemplate.exportconsigned)
                    {
                        if (xTemplate.only_selected_consign)
                        {
                            xTemplate.donotexport_consign = "";
                            xTemplate.exportonly_consign = GetConsignShowList();
                        }
                        else
                        {
                            xTemplate.donotexport_consign = GetConsignNoShow();
                            xTemplate.exportonly_consign = "";
                        }
                    }
                    xTemplate.exportwhere = xTemplate.GetExportWhere(RzWin.Context, GetExportList(), GetImportExceptionList(), GetConsignList(), GetConsignExceptionList());
                    xTemplate.fieldstring = GetColumnList(true);
                    xTemplate.exportcaptions = GetColumnList(false);
                    string group = "";
                    if (exporttemplate.HasQtyField(GetColumnList(lvColumns)))
                        group = " group by " + exporttemplate.GetGroupByList(GetColumnList(lvColumns));
                    if (Tools.Strings.StrExt(xTemplate.fieldstring))
                        xTemplate.exportstring = "select " + xTemplate.fieldstring + " from partrecord " + (Tools.Strings.StrExt(xTemplate.exportwhere) ? " where " + xTemplate.exportwhere : "") + group;
                }
                else
                {
                    xTemplate.donotexport = "";
                    xTemplate.exportonly = "";
                }

                try
                {
                    if (!Tools.Strings.StrExt(xTemplate.unique_id))
                        xTemplate.Insert(RzWin.Context);
                    else
                        xTemplate.Update(RzWin.Context);
                    RzWin.Leader.Tell("Saved.");
                }
                catch (Exception ee)
                {
                    RzWin.Leader.Tell("There was an error saving this template: " + ee.Message);
                }
                ShowTemplate();
            }
            catch (Exception)
            { }
        }


        private String GetNoShow()
        {
            String build = "";
            foreach (ListViewItem xLst in lvImports.Items)
            {
                if (!xLst.Checked)
                {
                    if (Tools.Strings.StrExt(xLst.SubItems[1].Text))
                        build += xLst.SubItems[1].Text + "|~|";
                }
            }
            build = build + build;
            return build;
        }
        private String GetShowList()
        {
            String build = "";
            foreach (ListViewItem xLst in lvImports.Items)
            {
                if (xLst.Checked)
                {
                    if (Tools.Strings.StrExt(xLst.SubItems[1].Text))
                        build += xLst.SubItems[1].Text + "|~|";
                }
            }
            return build;
        }
        private String GetConsignNoShow()
        {
            String build = "";
            foreach (ListViewItem xLst in lvConsign.Items)
            {
                if (!xLst.Checked)
                {
                    if (Tools.Strings.StrExt(xLst.SubItems[1].Text))
                        build += xLst.SubItems[1].Text + "|~|";
                }
            }
            build = build + build;
            return build;
        }
        private String GetConsignShowList()
        {
            String build = "";
            foreach (ListViewItem xLst in lvConsign.Items)
            {
                if (xLst.Checked)
                {
                    if (Tools.Strings.StrExt(xLst.SubItems[1].Text))
                        build += xLst.SubItems[1].Text + "|~|";
                }
            }
            return build;
        }

        //private String GetExportWhere(exporttemplate xTemplate, List<string> export_list, List<string> export_exception_list, List<string> consign_list, List<string> consign_exception_list)
        //{
        //    String sWhere = "";
        //    if (!xTemplate.HasStockType())
        //        return "";
        //    if (Tools.Strings.StrExt(xTemplate.exportonly) || Tools.Strings.StrExt(xTemplate.exportonly_consign))
        //        return GetExportWhereException();
        //    String build = "";
        //    if (xTemplate.exportstock)
        //        build = "'stock'";
        //    if (xTemplate.exportexcess)
        //    {
        //        if(Tools.Strings.StrExt(build))
        //            build += ", 'oem', 'excess'";
        //        else
        //            build = "'oem', 'excess'";
        //    }
        //    if (xTemplate.exportconsigned)
        //    {
        //        if (Tools.Strings.StrExt(build))
        //            build += ", 'consign', 'consigned'";
        //        else
        //            build = "'consign', 'consigned'";
        //    }
        //    sWhere = "stocktype in (" + build + ")";
        //    if (xTemplate.qtyabovezero)
        //        sWhere += " and (isnull(quantity, 0) - isnull(quantityallocated, 0)) > 0";
        //    if (xTemplate.pnlength)
        //        sWhere += " and len(isnull(fullpartnumber, '')) > 2";
        //    String lists = "";
        //    if (Tools.Strings.StrExt(xTemplate.donotexport))
        //        lists += GetImportExceptionList(); 
        //    else if (Tools.Strings.StrExt(xTemplate.exportonly))
        //        lists += GetExportList();
        //    if (Tools.Strings.StrExt(xTemplate.donotexport_consign))
        //        lists += GetConsignExceptionList();  //Tools.Strings.StrExt(lists)
        //    else if (Tools.Strings.StrExt(xTemplate.exportonly_consign))
        //        lists += GetConsignList(); //Tools.Strings.StrExt(lists)
        //    sWhere += lists;
        //    if (xTemplate.exportexcess && xTemplate.withcost)
        //        sWhere += " and isnull(cost, 0) > 0";
        //    return sWhere;
        //}
        //private String GetExportWhereException(exporttemplate xTemplate, List<string> export_list, List<string> export_exception_list, List<string> consign_list, List<string> consign_exception_list)
        //{
        //    String sWhere = "";
        //    if (xTemplate.exportstock)
        //    {                
        //        sWhere = " stocktype in ('stock')";
        //        if (xTemplate.qtyabovezero)
        //            sWhere += " and (isnull(quantity, 0) - isnull(quantityallocated, 0)) > 0";
        //        if (xTemplate.pnlength)
        //            sWhere += " and len(isnull(fullpartnumber, '')) > 2";
        //        if (xTemplate.exportexcess && xTemplate.withcost)
        //            sWhere += " and isnull(cost, 0) > 0 ";
        //    }
        //    if (xTemplate.exportexcess)
        //    {
        //        if (Tools.Strings.StrExt(sWhere))
        //            sWhere += " union select " + xTemplate.fieldstring + " from partrecord where ";
        //        sWhere += " stocktype in ('oem', 'excess')";
        //        if (xTemplate.qtyabovezero)
        //            sWhere += " and (isnull(quantity, 0) - isnull(quantityallocated, 0)) > 0";
        //        if (xTemplate.pnlength)
        //            sWhere += " and len(isnull(fullpartnumber, '')) > 2";
        //        if (xTemplate.exportexcess && xTemplate.withcost)
        //            sWhere += " and isnull(cost, 0) > 0 ";
        //        sWhere += GetExportList();
        //    }
        //    if (xTemplate.exportconsigned)
        //    {
        //        if (Tools.Strings.StrExt(sWhere))
        //            sWhere += " union select " + xTemplate.fieldstring + " from partrecord where ";
        //        sWhere += " stocktype in ('consign', 'consigned')";
        //        if (xTemplate.qtyabovezero)
        //            sWhere += " and (isnull(quantity, 0) - isnull(quantityallocated, 0)) > 0";
        //        if (xTemplate.pnlength)
        //            sWhere += " and len(isnull(fullpartnumber, '')) > 2";
        //        if (xTemplate.exportexcess && xTemplate.withcost)
        //            sWhere += " and isnull(cost, 0) > 0 ";
        //        sWhere += GetConsignList();
        //    }
        //    return sWhere;
        //}


        private  List<string> GetImportExceptionList()
        {
            List<string> l = new List<string>();
            foreach (ListViewItem xLst in lvImports.Items)
            {
                if (!xLst.Checked)
                    l.Add(xLst.SubItems[1].Text);
            }
            return l;
        }
        private List<string> GetExportList()
        {
            List<string> l = new List<string>();
            foreach (ListViewItem xLst in lvImports.Items)
            {
                if (xLst.Checked)
                    l.Add(xLst.SubItems[1].Text);
            }
            return l;
        }
        private List<string> GetConsignExceptionList()
        {
            List<string> l = new List<string>();
            foreach (ListViewItem xLst in lvConsign.Items)
            {
                if (!xLst.Checked)
                    l.Add(xLst.SubItems[1].Text);
            }
            return l;
        }
        private List<string> GetConsignList()
        {
            List<string> l = new List<string>();
            foreach (ListViewItem xLst in lvConsign.Items)
            {
                if (xLst.Checked)
                    l.Add(xLst.SubItems[1].Text);
            }
            return l;
        }


        private List<n_column> GetColumnList(nList lv)
        {
            List<n_column> l = new List<n_column>();
            if (lv.CurrentTemplate == null)
                return l;
            ArrayList a = lv.CurrentTemplate.GetColumnArray();
            if (a == null)
                return l;
            if (a.Count <= 0)
                return l;
            foreach (n_column c in a)
            {
                l.Add(c);
            }
            return l;
        }
        private String GetColumnList(Boolean TFieldsFCaptions)
        {
            return exporttemplate.GetColumnList(TFieldsFCaptions, GetColumnList(lvColumns));
        }
        private void CheckAllItems()
        {
            CheckAllItems(true);
        }
        private void CheckAllItems(Boolean bCheck)
        {
            CheckAllItems(true, lvImports);
        }
        private void CheckAllItems(Boolean bCheck, ListView lv)
        {
            try
            {
                foreach (ListViewItem xLst in lv.Items)
                {
                    xLst.Checked = bCheck;
                }
            }
            catch (Exception)
            { }
        }
        //Buttons
        private void cmdNew_Click(object sender, EventArgs e)
        {
            NewTemplate();
        }
        private void cmdEnable_Click(object sender, EventArgs e)
        {
            if (gbSQL.Enabled)
            {
                gbSQL.Enabled = false;
                cmdEnable.Text = "Enable";
            }
            else
            {
                gbSQL.Enabled = true;
                cmdEnable.Text = "Disable";
            }
        }
        private void cmdDelete_Click(object sender, EventArgs e)
        {
            DeleteTemplate();
        }
        private void cmdSave_Click(object sender, EventArgs e)
        {
            SaveTemplate();
        }
        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            LoadImportLists();
            SetImportLists();
        }
        private void cmdExport_Click(object sender, EventArgs e)
        {
            //if (xTemplate != null)
            //    xTemplate.ExportTemplate(RzWin.Context);
            if (xTemplate != null)
                bgExport.RunWorkerAsync(xTemplate);
        }
        //Control Events
        private void ExportInventory_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void ctl_exportexcess_CheckChanged(object sender)
        {
            //lvImports.Enabled = ctl_exportexcess.GetValue_Boolean(); 
        }
        private void ctl_exportconsigned_CheckChanged(object sender)
        {
            //lvConsign.Enabled = ctl_exportconsigned.GetValue_Boolean();
        }
        private void TS_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoResize();
        }
        private void lvTemplates_ObjectClicked(object sender, ObjectClickArgs args)
        {
            try
            {
                args.Handled = true;
                exporttemplate x = (exporttemplate)lvTemplates.GetSelectedObject();
                if (x != null)
                {
                    xTemplate = x;
                    ShowTemplate();
                }
            }
            catch (Exception)
            { }
        }
        private void lvTemplates_FinishedFill(object sender)
        {
            if (bShowATemplate)
            {
                bShowATemplate = false;
                ShowATemplate();
            }
        }
        private void lvTemplates_AboutToThrow(object sender, ShowArgs args)
        {
            args.Handled = true;
        }
        private void lvImports_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != sColumnExcess)
            {
                sColumnExcess = e.Column;
                lvImports.Sorting = SortOrder.Ascending;
            }
            else
            {
                if (lvImports.Sorting == SortOrder.Ascending)
                    lvImports.Sorting = SortOrder.Descending;
                else
                    lvImports.Sorting = SortOrder.Ascending;
            }
            FieldType t = FieldType.String;
            try
            {
                ColumnHeader c = lvImports.Columns[e.Column];
                if (c != null)
                {
                    if (c.TextAlign == HorizontalAlignment.Right)
                        t = FieldType.Double;
                    if (Tools.Strings.StrCmp(c.Text, "date"))
                        t = FieldType.DateTime;
                }
            }
            catch (Exception)
            { }
            lvImports.ListViewItemSorter = new NewMethod.ListViewItemComparer(e.Column, lvImports.Sorting, (Int32)t);
            lvImports.Sort();
        }
        private void lvConsign_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != sColumnConsigned)
            {
                sColumnConsigned = e.Column;
                lvConsign.Sorting = SortOrder.Ascending;
            }
            else
            {
                if (lvConsign.Sorting == SortOrder.Ascending)
                    lvConsign.Sorting = SortOrder.Descending;
                else
                    lvConsign.Sorting = SortOrder.Ascending;
            }
            FieldType t = FieldType.String;
            try
            {
                ColumnHeader c = lvConsign.Columns[e.Column];
                if (c != null)
                {
                    if (c.TextAlign == HorizontalAlignment.Right)
                        t = FieldType.Double;
                    if (Tools.Strings.StrCmp(c.Text, "date"))
                        t = FieldType.DateTime;
                }
            }
            catch (Exception)
            { }
            lvConsign.ListViewItemSorter = new NewMethod.ListViewItemComparer(e.Column, lvConsign.Sorting, (Int32)t);
            lvConsign.Sort();
        }
        private void lvOffers_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != sColumnOffers)
            {
                sColumnOffers = e.Column;
                lvOffers.Sorting = SortOrder.Ascending;
            }
            else
            {
                if (lvOffers.Sorting == SortOrder.Ascending)
                    lvOffers.Sorting = SortOrder.Descending;
                else
                    lvOffers.Sorting = SortOrder.Ascending;
            }
            FieldType t = FieldType.String;
            try
            {
                ColumnHeader c = lvOffers.Columns[e.Column];
                if (c != null)
                {
                    if (c.TextAlign == HorizontalAlignment.Right)
                        t = FieldType.Double;
                    if (Tools.Strings.StrCmp(c.Text, "date"))
                        t = FieldType.DateTime;
                }
            }
            catch (Exception)
            { }
            lvOffers.ListViewItemSorter = new NewMethod.ListViewItemComparer(e.Column, lvOffers.Sorting, (Int32)t);
            lvOffers.Sort();
        }
        private void chkAll_CheckChanged(object sender)
        {
            try
            {
                ListView lv = new ListView();
                if (ts2.SelectedTab == tabExcess)
                    lv = lvImports;
                if (ts2.SelectedTab == tabConsign)
                    lv = lvConsign;
                if (ts2.SelectedTab == tabOffers)
                    lv = lvOffers;
                Boolean bCheck = chkAll.GetValue_Boolean();
                foreach (ListViewItem xLst in lv.Items)
                {
                    xLst.Checked = bCheck;
                }
            }
            catch { }
        }
        //Background Workers
        private void bgExport_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e == null)
                return;
            exporttemplate xt;
            try
            {
                xt = (exporttemplate)e.Argument;
            }
            catch (Exception)
            { return; }
            if (xt == null)
                return;
            xt.ExportTemplate(RzWin.Context);
        }
        private void bgExport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //if (!Rz3App.xLogic.IsPMT)
            //    return;
            //Rz3App.RzWin.Context.Execute("drop table pmt_temp_inv", false, true);
        }
    }
}
