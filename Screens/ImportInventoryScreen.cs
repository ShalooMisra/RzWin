using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;
using System.IO;
using System.Linq;
using Tools;
using NewMethod;
using System.Collections.Generic;


/* Base import inventory screen. Inherit from this for customers that need added controls or a change in the display
 * The ImportInventory class holds the main logic for running the import, outside of the display classes. Inherit from 
 * this object and create a passback in Rz3Logic so you can override funtions in it to achieve different desired effects
*/

namespace Rz5.Win.Screens
{
    public partial class ImportInventoryScreen : UserControl, IImportInventoryScreen
    {
        //Protected Virtual Variables
        public string SelectedTableName
        {
            get
            {
                return this.Invoke(new TableHandler(SelectedTableNameActuallyGet)).ToString();
            }
        }
        private delegate String TableHandler();
        //Protected Variables
        protected RzLogic TheLogic;
        protected ImportInventory TheImportLogic;

        //Constructors
        public ImportInventoryScreen()
        {
            InitializeComponent();
        }
        //Public Virtual Functions
        public virtual void CompleteLoad(Enums.StockType t)
        {   //Loads the control and TheImportLogic
            TheLogic = RzWin.Context.TheLogicRz;
            TheImportLogic = TheLogic.GetImportInventoryLogic();
            TheImportLogic.Init(t);
            DoResize();
            SetControls();
            ts.TabPages.Remove(pageExports);


            //KT refactored from RzSensible
            ctl_consigncodes.cboValue.DropDownStyle = ComboBoxStyle.DropDownList;
            ctl_purchase_orders.cboValue.DropDownStyle = ComboBoxStyle.DropDownList;
            if (t == Rz5.Enums.StockType.Consign)
                LoadConsignCodes();

        }
        public virtual void DoResize()
        {
            try
            {
                gb.Left = 0;
                gb.Width = pageNewItems.ClientRectangle.Width;
                gb.Top = 0;
                dv.Left = 0;
                dv.Top = gb.Bottom;
                dv.Width = pageNewItems.ClientRectangle.Width;
                dv.Height = pageNewItems.ClientRectangle.Height - dv.Top;
                gbPast.Width = pagePast.ClientRectangle.Width;
                gbPast.Left = 0;
                gbPast.Top = 0;
                cmdDeleteOfferImport.Left = gbPast.ClientRectangle.Width - (cmdDeleteOfferImport.Width + 20);
                lvPastImports.Left = 0;
                lvPastImports.Height = pagePast.ClientRectangle.Height - (lvPastImports.Top + 0);
                PastItems.Left = lvPastImports.Right;
                PastItems.Top = lvPastImports.Top;
                PastItems.Height = pagePast.ClientRectangle.Height - (PastItems.Top + 0);
                PastItems.Width = pagePast.ClientRectangle.Width - PastItems.Left;
                gbExports.Left = 0;
                gbExports.Top = 0;
                gbExports.Height = pageExports.ClientRectangle.Height;
                lvExports.Left = gbExports.Right;
                lvExports.Top = 0;
                lvExports.Width = pageExports.ClientRectangle.Width - lvExports.Left;
                if (TheImportLogic.CurrentExport == null)
                {
                    gbOneExport.Visible = false;
                    lvExports.Height = pageExports.ClientRectangle.Height;
                }
                else
                {
                    gbOneExport.Visible = true;
                    lvExports.Height = pageExports.ClientRectangle.Height - gbOneExport.Height;
                    gbOneExport.Left = gbExports.Right;
                    gbOneExport.Top = lvExports.Bottom;
                    gbOneExport.Width = pageExports.ClientRectangle.Width - gbOneExport.Left;
                    ctl_exportstring.Width = gbOneExport.ClientRectangle.Width - (ctl_exportstring.Left * 2);
                }
            }
            catch { }
        }
        //Protected Virtual Functions
        protected virtual string SelectedTableNameActuallyGet()
        {   //Override to add other functionality or send a different table name
            return "partrecord";
        }



        protected virtual void SetControls()
        {   //Handles setting up the controls and in overrides, extra customer specific controls on their screen.
            dv.Visible = true;
            //LoadCustomerSpecificPlugin();//this is only for AAT
            SetCaption();
            chooseuser.SetUserName(RzWin.Context.xUser.name);
            dv.CompleteLoad();
            dv.AddCommonField("fullpartnumber", "Part Number", TheImportLogic.PartNumberAliases, true);
            dv.AddCommonField("quantity", "Quantity", TheImportLogic.QuantityAliases, true);
            dv.AddCommonField("manufacturer", "Manufacturer", TheImportLogic.ManufacturerAliases);
            dv.AddCommonField("datecode", "Date Code", TheImportLogic.DateCodeAliases);
            dv.AddCommonField("price", "Price", TheImportLogic.PriceAliases);
            dv.AddCommonField("cost", "Cost", TheImportLogic.CostAliases);
            dv.AddCommonField("alternatepart", "Alternate Part #", TheImportLogic.AlternatePartAliases);
            dv.AddCommonField("description", "Description", TheImportLogic.DescriptionAliases);
            dv.AddCommonField("packaging", "Packaging", TheImportLogic.PackagingAliases);
            //if (TheLogic.IsPhoenix)   //Phoenix has their own copy of this screen that handles this already
            //    dv.AddCommonField("serial", "Serial Number", "serial", false);
            dv.SetClass("partrecord");

            //KT this switch is apparently important. Without it system ignores selected stocktype
            //This is because it relies on the "CheckChanged" event whick won't fire suring file selection without this
            switch (TheImportLogic.CurrentType)
            {
                case Enums.StockType.Consign:
                    optConsignment.Checked = true;
                    break;
                case Enums.StockType.Excess:
                    optExcess.Checked = true;
                    break;
            }
            SetImportName();
            dv.Clear();
        }
        protected virtual void SetCaption()
        {   //Set nDataView caption, can be overridden
            dv.SetAcceptCaption("Import These Items As " + TheImportLogic.CurrentType.ToString());
        }
        protected virtual void SetImportName()
        {   //Set txtImportName value, can be overridden
            txtImportName.SetValue(TheImportLogic.GetImportName(RzWin.Context, chooseuser.GetUserName(), cStub.GetCompanyName()));

            //////KT Refactored from RzSensible
            //if (optConsignment.Checked)
            //    ConsignmentImportSetup();


        }


        //KT Refactored from RzSensible
        public void ConsignmentImportSetup()
        {
            TheImportLogic.consignmentCode = ctl_consigncodes.GetValue_String();
        }

        private void LoadPurchaseOrders()
        {
            ctl_purchase_orders.ClearList();
            if (!Tools.Strings.StrExt(cStub.CompanyID))
            {
                ctl_purchase_orders.Visible = false;
                return;
            }


            //ArrayList a = RzWin.Context.Data.SelectScalarArray("select distinct(ordernumber) from ordhed_purchase where base_company_uid = '" + cStub.CompanyID + "' order by orderdate DESC");
            ArrayList poIds = RzWin.Context.QtC("ordhed_purchase", "select * from ordhed_purchase where base_company_uid = '" + cStub.CompanyID + "' order by orderdate DESC");
            List<ordhed_purchase> poList = poIds.Cast<ordhed_purchase>().ToList();
            if (poIds == null)
                return;
            if (poIds.Count <= 0)
            {
                if (RzWin.Context.xUserRz.SuperUser)
                {
                    string fakePONumber = RzWin.Context.Leader.AskForString("Super User:  Would you like to associate with a fake PO for testing purposes?");
                    if (string.IsNullOrEmpty(fakePONumber))
                        return;
                    string new_po_id = Guid.NewGuid().ToString();
                    ordhed_purchase fakePO = new ordhed_purchase();
                    fakePO.ordernumber = fakePONumber;
                    fakePO.unique_id = new_po_id;
                    poList.Add(fakePO);

                }
            }
            string po_numbers = "";
            foreach (string s in poList.Select(s => s.ordernumber))
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                if (Tools.Strings.StrExt(po_numbers))
                    po_numbers += "|";
                po_numbers += s;
            }
            ctl_purchase_orders.SimpleList = po_numbers;
            ctl_purchase_orders.Visible = !string.IsNullOrEmpty(po_numbers);

        }

        private void LoadConsignCodes()
        {
            ctl_consigncodes.ClearList();
            if (!Tools.Strings.StrExt(cStub.CompanyID))
                return;
            ArrayList a = RzWin.Context.Data.SelectScalarArray("select distinct(code_name) from consignment_code where vendor_uid = '" + cStub.CompanyID + "' order by code_name");
            if (a == null)
                return;
            if (a.Count <= 0)
                return;
            string build = "";
            foreach (string s in a)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                if (Tools.Strings.StrExt(build))
                    build += "|";
                build += s;
            }
            ctl_consigncodes.SimpleList = build;
        }
        //private void optConsignment_CheckedChanged(object sender, EventArgs e)
        //{
        //    ctl_consigncodes.Visible = optConsignment.Checked;
        //}
        private void opt_CheckedChanged(object sender, EventArgs e)
        {
            if (optStock.Checked)
            {
                TheImportLogic.CurrentType = Enums.StockType.Stock;
                LoadPurchaseOrders();
            }
            else
                ctl_purchase_orders.Visible = false;

            if (optConsignment.Checked)
            {
                TheImportLogic.CurrentType = Enums.StockType.Consign;
                ctl_consigncodes.Visible = true;
                LoadConsignCodes();

            }
            else
                ctl_consigncodes.Visible = false;

            if (optExcess.Checked)
                TheImportLogic.CurrentType = Enums.StockType.Excess;
            if (optMaster.Checked)
                TheImportLogic.CurrentType = Enums.StockType.Master;
            else if (optOffers.Checked)
                TheImportLogic.CurrentType = Enums.StockType.Offers;
            //else if (optOffers.Checked)
            //    TheImportLogic.CurrentType = Enums.StockType.Offers;
            cStub.Visible = (TheImportLogic.CurrentType != Enums.StockType.Master);

            //SetControls();
            SetCaption();
            SetImportName();
        }


        private void cStub_CompanyChangeFinished(Tools.GenericEvent e)
        {
            if (optConsignment.Checked)
                LoadConsignCodes();
            else
                ctl_consigncodes.Visible = false;
            if (optStock.Checked)
                LoadPurchaseOrders();
            else
                ctl_purchase_orders.Visible = false;
            SetImportName();
        }



        private void cStub_ClearCompanyFinished(Tools.GenericEvent e)
        {
            LoadConsignCodes();
            LoadPurchaseOrders();
        }

        //KT End RzSensible Refactor


        protected virtual string GetPastImportType()
        {   //Returns what to search in past imports section. Override adds to this value.
            return "list";
        }
        protected virtual void SetDeleteCaption()
        {   //Set cmdDeleteOfferImport caption, can be overridden
            cmdDeleteOfferImport.Text = "Delete An Offer Import";
        }
        protected virtual ImportInventory.DeleteArgs GetDeleteArgs()
        {   //Gets default DeleteArgs, can be overridden.
            return new ImportInventory.DeleteArgs();
        }
        protected virtual string GetPastItemsAltTableName()
        {   //Gets AltTableName for past imports search, can be overridden.
            return "partrecord";
        }
        protected virtual void CheckPriority()
        {   //Gets ImportPriority, override to change value, used by Iconix
            TheImportLogic.ImportPriority = 0;
        }
        protected virtual void LoadCustomerSpecificPlugin()
        {
            //Written by Eric for AAT's version. In the override it adds extra controls.
        }
        //Public Functions
        public void ShowThrobber()
        {
            throb.ShowThrobber();
        }
        public void HideThrobber()
        {
            throb.HideThrobber();
        }
        //Protected Functions
        protected void RefreshPast()
        {   //Reloads the Past import listview (starts the bgw thread)
            if (bgList.IsBusy)
            {
                RzWin.Context.TheLeader.Tell("The system is still loading past imports. Please wait until it has finished.");
                return;
            }
            if (!TheImportLogic.bPast)
            {
                lvPastImports.Visible = true;
                PastItems.Visible = true;
                cmdRefresh.Text = "Refresh";
                PastItems.ShowTemplate("past_import_parts", "partrecord", RzWin.Context.xUser.TemplateEditor);
                TheImportLogic.bPast = true;
            }
            ShowThrobber();
            lvPastImports.Items.Clear();
            DoResize();
            String type = GetPastImportType();
            bgList.RunWorkerAsync(type);
        }
        protected void GrabSelectedImports()
        {
            TheImportLogic.SelectedIDs = new ArrayList();
            try
            {
                if (lvPastImports.SelectedItems.Count == 0)
                    return;
                foreach (ListViewItem i in lvPastImports.SelectedItems)
                {
                    TheImportLogic.SelectedIDs.Add(i.Text);
                }
            }
            catch { }
        }

        //Private Functions
        private void StartImport()
        {   //Starts the import process bgw.
            if (bgImport.IsBusy)
            {
                RzWin.Context.TheLeader.Tell("The system is still importing files. Please wait until it has finished.");
                return;
            }
            dv.SetStatus("Importing...");

            AsyncTable = dv.CurrentTable;
            AsyncName = txtImportName.GetValue_String();
            AsyncUserName = chooseuser.GetUserName();
            AsyncCompanyId = cStub.GetCompanyID();
            AsyncContactId = cStub.GetContactID();

            if (optStock.Checked)
            {
                string poID = RzWin.Context.SelectScalarString("select unique_id from ordhed_purchase where ordernumber = '" + ctl_purchase_orders.GetValue_String() + "'");
                if (poID == null)
                    throw new Exception("Purhcase order could not be identified, possible due to a change of the order number.  Please contact IT for resolution.");
                ordhed_purchase po = null;
                if (!string.IsNullOrEmpty(poID))
                {
                    po = (ordhed_purchase)RzWin.Context.QtO("ordhed_purchase", "select * from ordhed_purchase where unique_id = '" + poID + "'");
                    if (po == null)
                        throw new Exception("Could not locate the selected purchase order, import cannot proceed");
                    //ImportInventory v = TheImportLogic;
                    TheImportLogic.buy_purchase_id = poID;
                    TheImportLogic.buy_purchase_ordernumber = po.ordernumber;
                    TheImportLogic.companyName = cStub.CurrentCompanyName;
                    TheImportLogic.base_company_uid = cStub.CurrentCompanyID;
                }


            }
            if (optConsignment.Checked)
            {
                ConsignmentImportSetup();
            }

            dv.ShowThrobber();
            dv.DisableAccept();
            bgImport.RunWorkerAsync();
        }
        private void CheckLoadExports()
        {
            if (TheImportLogic.Exports == null)
            {
                TheImportLogic.LoadExports(RzWin.Context);
                ShowExports();
            }
        }
        private void ShowExports()
        {
            lvExports.Items.Clear();
            lvExports.BeginUpdate();
            try
            {
                foreach (exporttemplate x in TheImportLogic.Exports)
                {
                    ListViewItem i = lvExports.Items.Add(x.exportname);
                    i.SubItems.Add(x.exportfile);
                    if (x.exporttotext)
                        i.SubItems.Add(".csv");
                    else
                        i.SubItems.Add(".xls");
                    i.SubItems.Add(x.exportstring);
                    i.Tag = x;
                }
            }
            catch { }
            lvExports.EndUpdate();
        }
        private void LoadOneExport(exporttemplate x)
        {
            TheImportLogic.CurrentExport = x;
            NMWin.LoadFormValues(gbOneExport, TheImportLogic.CurrentExport);
            DoResize();
        }
        private void SaveExport()
        {
            if (TheImportLogic.CurrentExport == null)
                return;
            NMWin.GrabFormValues(gbOneExport, TheImportLogic.CurrentExport);
            TheImportLogic.CurrentExport.Update(RzWin.Context);
            TheImportLogic.LoadExports(RzWin.Context);
            ShowExports();
        }
        private void RefreshPastList()
        {
            TheImportLogic.refreshpastlist = false;
            lvPastImports.Items.Clear();
            lvPastImports.BeginUpdate();
            try
            {
                if (Tools.Data.DataTableExists(TheImportLogic.dtPast))
                {
                    foreach (DataRow r in TheImportLogic.dtPast.Rows)
                    {
                        String importid = nData.NullFilter_String(r[0].ToString());
                        ListViewItem i = lvPastImports.Items.Add(importid);
                        try
                        {
                            if (nData.NullFilter_Boolean(r["is_telecom"]))
                                i.ForeColor = Color.Blue;
                        }
                        catch { i.ForeColor = Color.Green; }
                        //importid
                        i.SubItems.Add(nData.NullFilter_String(r[1].ToString()));
                        //Vendor Name
                        i.SubItems.Add(Tools.Number.LongFormat(nData.NullFilter_Int64(r[2])));
                        //StockType
                        i.SubItems.Add(nData.NullFilter_String(r[3]));
                        import_summary s = (import_summary)RzWin.Context.QtO("import_summary", "select * from import_summary where importid = '" + RzWin.Context.Filter(importid) + "'");
                        if (s != null)
                        {
                            i.Tag = s;
                            i.SubItems.Add(s.importnotes);
                        }
                        else
                            TheImportLogic.AddPastItemNoSummary(r, i);
                    }
                    DataRow[] rows = TheImportLogic.dtPast.Select("", "total_count desc");
                    int j = 0;
                    foreach (DataRow r in rows)
                    {
                        j++;
                        if (j > 20)
                            break;
                    }
                }
            }
            catch (Exception ex) { string error = ex.Message; }
            lvPastImports.EndUpdate();
        }
        private exporttemplate GetSelectedExport()
        {
            try
            {
                ListViewItem i = lvExports.SelectedItems[0];
                if (i == null)
                    return null;
                return (exporttemplate)i.Tag;
            }
            catch { }
            return null;
        }
        private void ExportSelectedImports()
        {
            if (bgExport.IsBusy)
            {
                RzWin.Context.TheLeader.Tell("The system is still exporting parts. Please wait until it has finished.");
                return;
            }
            GrabSelectedImports();
            if (TheImportLogic.SelectedIDs.Count <= 0)
                return;
            String table = GetPastItemsAltTableName();
            String strSQL = "select companyname as [Company], companycontactname as [Contact], companyemailaddress as [Email], fullpartnumber as [Part], quantity as [Quantity], manufacturer as [Manufacturer], datecode as [Date Code] from " + table + " where importid in (" + nTools.GetIn(TheImportLogic.SelectedIDs) + ") order by companyname, fullpartnumber, quantity";
            throbExport.ShowThrobber();
            bgExport.RunWorkerAsync(strSQL);
        }
        private void RunPartCrossReference()
        {
            ((LeaderWinUserRz)RzWin.Context.Leader).RunPartCrossReference(RzWin.Context, lvPastImports.SelectedItems);
        }
        private void UpdateAllLists()
        {
            if (lvPastImports.Items.Count <= 0)
                return;
            if (bgwUpdate.IsBusy)
                return;
            ArrayList a = new ArrayList();
            foreach (ListViewItem xLst in lvPastImports.Items)
            {
                a.Add(xLst.Text);
            }
            bgwUpdate.RunWorkerAsync(a);
        }
        private void ReIndexCheck()
        {
            //if (!RzWin.Context.TheLeader.AskYesNo("Would you like Rz to reorganize the Rz database to optimize performance.  This is an expensive operation, only use if you have imported more than 1000 lines."))
            //    return;
            //if (bwIndex.IsBusy)
            //    return;
            //RzWin.Context.TheLeader.StartPopStatus("ReIndexing Part Table...");
            //bwIndex.RunWorkerAsync();
        }
        //Buttons
        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            RefreshPast();
        }
        private void cmdDeleteOfferImport_Click(object sender, EventArgs e)
        {
            ImportInventory.DeleteArgs d = GetDeleteArgs();
            ArrayList a = RzWin.Context.SelectScalarArray("select distinct(importid) from " + d.delete_from + " where importid > '' order by importid");
            if (a.Count <= 0)
            {
                RzWin.Context.TheLeader.Tell("No " + d.delete_caption + " imports are available to be deleted.");
                return;
            }
            ArrayList delete_ids = frmChooseMultipleChoices.ChooseFromArray(a, "Imports to Delete");
            if (delete_ids.Count == 0)
                return;
            String where = " importid in ( " + nTools.GetIn(delete_ids) + " ) ";
            long l = RzWin.Context.SelectScalarInt64("select count(*) from " + d.delete_from + " where " + where);
            if (l <= 0)
            {
                RzWin.Context.TheLeader.Tell("The selected imports appear to have no lines.");
                return;
            }
            if (!RzWin.Context.TheLeader.AskYesNo("Are you sure you want to delete " + Tools.Number.LongFormat(l) + " " + d.delete_caption + " lines?"))
                return;

            RzWin.Context.Data.Connection.Execute("delete from " + d.delete_from + " where " + where, ref l);
            RzWin.Context.TheLeader.Tell("Done: " + Tools.Number.LongFormat(l) + " rows were deleted.");
        }
        private void cmdUpdateAllLists_Click(object sender, EventArgs e)
        {
            UpdateAllLists();
        }
        private void cmdApply_Click(object sender, EventArgs e)
        {
            SaveExport();
        }
        private void cmdCloseExport_Click(object sender, EventArgs e)
        {
            SaveExport();
            TheImportLogic.CurrentExport = null;
            DoResize();
        }
        private void cmdNew_Click(object sender, EventArgs e)
        {
            LoadOneExport(TheImportLogic.AddNewExport(RzWin.Context));
            TheImportLogic.LoadExports(RzWin.Context);
            ShowExports();
        }
        //Control Events
        private void dv_Accept()
        {
            if (dv.Count <= 0)
                return;
            if (optConsignment.Checked)
                if (string.IsNullOrEmpty(ctl_consigncodes.GetValue_String()))
                {
                    RzWin.Leader.Tell("Plese select a consignment code before importing as consignment");
                    return;
                }
            if (optStock.Checked)
            {
                if (string.IsNullOrEmpty(cStub.GetCompanyID()))
                {
                    RzWin.Leader.Tell("Plese select a Company before importing Stock");
                    return;
                }
                if (string.IsNullOrEmpty(ctl_purchase_orders.GetValue_String()))
                {
                    RzWin.Leader.Tell("Plese select a Purchase Order before importing Stock");
                    return;
                }

            }

            if (!RzWin.Context.TheLeader.AskYesNo("Are you sure you want to import " + Tools.Number.LongFormat(dv.Count) + " items as " + TheImportLogic.CurrentType.ToString()))
                return;
            CheckPriority();
            StartImport();
        }
        private void dv_BeforeImport()
        {
            SetImportName();
        }
        private void PartsImport_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        private void chooseuser_ChangeUser(GenericEvent e)
        {
            NewMethod.n_user u = NewMethod.n_user.Choose(RzWin.Context, RzWin.Context.xUser.SuperUser);
            if (u != null)
                chooseuser.SetUserName(u.name);
            SetImportName();
        }
        private void ts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ts.SelectedIndex == 2)
                CheckLoadExports();
            DoResize();
        }
        private void lvExports_Click(object sender, EventArgs e)
        {
            exporttemplate x = GetSelectedExport();
            if (x == null)
                return;
            LoadOneExport(x);
        }
        private void lvPastImports_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != TheImportLogic.sortColumn)
            {
                TheImportLogic.sortColumn = e.Column;
                lvPastImports.Sorting = SortOrder.Ascending;
            }
            else
            {
                if (lvPastImports.Sorting == SortOrder.Ascending)
                    lvPastImports.Sorting = SortOrder.Descending;
                else
                    lvPastImports.Sorting = SortOrder.Ascending;
            }
            int t = 1;
            if (e.Column == 2)
                t = 3;
            this.lvPastImports.ListViewItemSorter = new ListViewItemComparer(e.Column, lvPastImports.Sorting, t);
            lvPastImports.Sort();
        }
        //Background Workers
        nDataTable AsyncTable;
        String AsyncName;
        String AsyncUserName;
        String AsyncCompanyId;
        String AsyncContactId;
        private void bgImport_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //this is cross thread
                //e.Result = TheImportLogic.RunImport(dv, txtImportName.GetValue_String(), chooseuser.GetUserName(), cStub.GetCompanyID(), cStub.GetContactID());
                TheImportLogic.RunImport(RzWin.Context, AsyncTable, AsyncName, AsyncUserName, AsyncCompanyId, AsyncContactId);
                e.Result = true;
            }
            catch(Exception ex)
            {
                RzWin.Context.Error(ex.Message);
            }
            
        }
        private void bgImport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dv.ShowTable();
            dv.HideThrobber();
            dv.AllowAccept();
            ReIndexCheck();
        }
        private void bgList_DoWork(object sender, DoWorkEventArgs e)
        {
            long l = 0;
            switch (e.Argument.ToString())
            {
                case "delete":
                    TheImportLogic.DeleteSelected(RzWin.Context, TheImportLogic.SelectedIDs, SelectedTableName, ref l);
                    TheImportLogic.refreshpastlist = true;
                    e.Result = "Done: " + Tools.Number.LongFormat(l) + " items were deleted.";
                    TheImportLogic.CalcPast(RzWin.Context, "", ref l);
                    break;
                case "archive":
                    TheImportLogic.ArchiveSelected(RzWin.Context, TheImportLogic.SelectedIDs, SelectedTableName, ref l);
                    TheImportLogic.refreshpastlist = true;
                    e.Result = "Done: " + Tools.Number.LongFormat(l) + " items were archived.";
                    TheImportLogic.CalcPast(RzWin.Context, "", ref l);
                    break;
                case "count":
                    l = TheImportLogic.CountSelected(RzWin.Context, TheImportLogic.SelectedIDs, SelectedTableName);
                    e.Result = "There are " + Tools.Number.LongFormat(l) + " item(s) associated with the selected import(s).";
                    break;
                default:
                    TheImportLogic.CalcPast(RzWin.Context, e.Argument.ToString(), ref l);
                    TheImportLogic.refreshpastlist = true;
                    e.Result = Tools.Number.LongFormat(l) + " Import(s)";
                    break;
            }
        }
        private void bgList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (TheImportLogic.refreshpastlist)
                RefreshPastList();
            lblPastStatus.Text = e.Result.ToString();
            HideThrobber();
        }
        private void bgExport_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                exporttemplate x = (exporttemplate)e.Argument;
                x.RunSimpleExport(RzWin.Context, true);
            }
            catch (Exception)
            {
                try
                {
                    String s = e.Argument.ToString();
                    Tools.Data.SqlToExcel(RzWin.Context.Data.Connection, s);
                }
                catch (Exception)
                {
                }
            }
        }
        private void bgExport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throbExport.HideThrobber();
        }
        private void bgwUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            ShowThrobber();
            ArrayList a = (ArrayList)e.Argument;
            if (a == null)
                return;
            foreach (string s in a)
            {
                if (!Tools.Strings.StrExt(s))
                    return;
                partrecord p = partrecord.GetById(RzWin.Context, s);
                if (p != null)
                    TheImportLogic.UpdateList(RzWin.Context, p);
            }
        }
        private void bgwUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HideThrobber();
            RefreshPast();
            RzWin.Leader.Comment("Done.");
        }
        private void bgMergeImports_DoWork(object sender, DoWorkEventArgs e)
        {
            ShowThrobber();
            if (!TheImportLogic.AllSameVendors(RzWin.Context))
            {
                RzWin.Context.TheLeader.Tell("One or more of the companies linked to the imports selected are different. In order to merge lists together the imports must be from the same supplier.");
                return;
            }
            String main = "";
            foreach (String s in TheImportLogic.SelectedIDs)
            {
                if (!Tools.Strings.StrExt(main))
                    main = s;
                else
                    RzWin.Context.Execute("update partrecord set importid = '" + main + "' where importid = '" + RzWin.Context.Filter(s) + "'");
            }
        }
        private void bgMergeImports_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HideThrobber();
            RefreshPast();
            RzWin.Leader.Comment("Done.");
        }
        private void bwIndex_DoWork(object sender, DoWorkEventArgs e)
        {
            ShowThrobber();
            RzWin.Context.TheData.TheConnection.ReindexTable("partrecord");
        }
        private void bwIndex_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HideThrobber();
            RzWin.Context.TheLeader.Comment("Done.");
            RzWin.Context.TheLeader.StopPopStatus();
        }
        //Menus
        private void mnuViewList_Click(object sender, EventArgs e)
        {
            PastItems.Clear();
            GrabSelectedImports();
            if (TheImportLogic.SelectedIDs.Count <= 0)
                return;
            String s = nTools.GetIn(TheImportLogic.SelectedIDs);
            if (!Tools.Strings.StrExt(s))
                return;
            PastItems.AlternateTableName = GetPastItemsAltTableName();
            PastItems.ShowData("partrecord", "isnull(importid, '') in (" + s + ")", "importid, fullpartnumber");
        }
        private void mnuCount_Click(object sender, EventArgs e)
        {
            if (bgList.IsBusy)
            {
                RzWin.Context.TheLeader.Tell("The system is still loading past imports. Please wait until it has finished.");
                return;
            }
            GrabSelectedImports();
            if (TheImportLogic.SelectedIDs.Count <= 0)
                return;
            ShowThrobber();
            bgList.RunWorkerAsync("count");
        }
        private void mnuArchive_Click(object sender, EventArgs e)
        {
            if (bgList.IsBusy)
            {
                RzWin.Context.TheLeader.Tell("The system is still loading past imports. Please wait until it has finished.");
                return;
            }
            PastItems.Clear();
            GrabSelectedImports();
            if (TheImportLogic.SelectedIDs.Count <= 0)
                return;
            Int64 count = TheImportLogic.CountSelected(RzWin.Context, TheImportLogic.SelectedIDs, SelectedTableName);
            if (!RzWin.Context.TheLeader.AskYesNo("Are you sure you want to archive " + Tools.Number.LongFormat(TheImportLogic.SelectedIDs.Count) + " import(s) containing " + Tools.Number.LongFormat(count) + " item(s)"))
                return;
            ShowThrobber();
            bgList.RunWorkerAsync("archive");
        }
        private void mnuDelete_Click(object sender, EventArgs e)
        {
            if (bgList.IsBusy)
            {
                RzWin.Context.TheLeader.Tell("The system is still loading past imports. Please wait until it has finished.");
                return;
            }
            PastItems.Clear();
            GrabSelectedImports();
            if (TheImportLogic.SelectedIDs.Count <= 0)
                return;
            Int64 count = TheImportLogic.CountSelected(RzWin.Context, TheImportLogic.SelectedIDs, SelectedTableName);
            if (!RzWin.Context.TheLeader.AskYesNo("Are you sure you want to delete " + Tools.Number.LongFormat(TheImportLogic.SelectedIDs.Count) + " import(s) containing " + Tools.Number.LongFormat(count) + " item(s)"))
                return;
            ShowThrobber();
            bgList.RunWorkerAsync("delete");
            //if e.id exists 

        }
        private void mnuSetAgent_Click(object sender, EventArgs e)
        {
            GrabSelectedImports();
            if (TheImportLogic.SelectedIDs.Count <= 0)
                return;
            String strName = "";
            String strID = "";
            frmChooseUser.ChooseUserName(ref strID, ref strName, null, RzWin.Context.xUser.SuperUser);
            if (!Tools.Strings.StrExt(strName))
                return;
            Int64 count = TheImportLogic.CountSelected(RzWin.Context, TheImportLogic.SelectedIDs, SelectedTableName);
            if (!RzWin.Context.TheLeader.AskYesNo("Are you sure you want to set the agent name on " + Tools.Number.LongFormat(TheImportLogic.SelectedIDs.Count) + " import(s) containing " + Tools.Number.LongFormat(count) + " item(s) to '" + strName + "'"))
                return;
            ShowThrobber();
            String strIn = nTools.GetIn(TheImportLogic.SelectedIDs);
            if (Tools.Strings.HasString(strIn, "''"))
                return;
            String table = GetPastItemsAltTableName();
            RzWin.Context.Execute("update " + table + " set agentname = '" + RzWin.Context.Filter(strName) + "' where isnull(importid, '') in (" + strIn + ")");
            RzWin.Context.TheLeader.TellTemp("Done.");
            HideThrobber();
        }
        private void mnuRename_Click(object sender, EventArgs e)
        {
            GrabSelectedImports();
            if (TheImportLogic.SelectedIDs.Count <= 0)
                return;
            if (TheImportLogic.SelectedIDs.Count > 1)
            {
                RzWin.Context.TheLeader.Tell("Only 1 import can be renamed at a time.");
                return;
            }
            String strName = RzWin.Context.TheLeader.AskForString("New Name", TheImportLogic.SelectedIDs[0].ToString(), false);
            if (!Tools.Strings.StrExt(strName))
                return;
            String table = GetPastItemsAltTableName();
            if (RzWin.Context.SelectScalarInt64("select count(*) from " + table + " where importid = '" + RzWin.Context.Filter(strName) + "'") > 0)
            {
                RzWin.Context.TheLeader.Tell("There already appears to be an import named '" + strName + "'.");
                return;
            }
            Int64 count = TheImportLogic.CountSelected(RzWin.Context, TheImportLogic.SelectedIDs, SelectedTableName);
            if (!RzWin.Context.TheLeader.AskYesNo("Are you sure you want to change the import name on import '" + TheImportLogic.SelectedIDs[0].ToString() + "' to '" + strName + "'"))
                return;
            ShowThrobber();
            String strIn = nTools.GetIn(TheImportLogic.SelectedIDs);
            if (Tools.Strings.HasString(strIn, "''"))
                return;
            RzWin.Context.Execute("update " + table + " set importid = '" + RzWin.Context.Filter(strName) + "' where isnull(importid, '') in (" + strIn + ")");
            RefreshPast();
            RzWin.Context.TheLeader.TellTemp("Done.");
            HideThrobber();
        }
        private void mnuOpenLastExportFile_Click(object sender, EventArgs e)
        {
            exporttemplate x = GetSelectedExport();
            if (x == null)
                return;
            Tools.Files.OpenFileInDefaultViewer(x.exportfile);
        }
        private void mnuDeleteExport_Click(object sender, EventArgs e)
        {
            exporttemplate x = GetSelectedExport();
            if (x == null)
                return;
            if (!RzWin.Context.TheLeader.AskYesNo("Are you sure you want to delete export '" + x.exportname + "'"))
                return;
            x.Delete(RzWin.Context);
            if (TheImportLogic.CurrentExport != null)
            {
                //clear the current export if it was the one deleted
                if (Tools.Strings.StrCmp(TheImportLogic.CurrentExport.unique_id, x.unique_id))
                {
                    TheImportLogic.CurrentExport = null;
                    DoResize();
                }
            }
            TheImportLogic.LoadExports(RzWin.Context);
            ShowExports();
        }
        private void mnuRunExport_Click(object sender, EventArgs e)
        {
            if (bgExport.IsBusy)
            {
                RzWin.Context.TheLeader.Tell("The system is still exporting parts. Please wait until it has finished.");
                return;
            }
            exporttemplate x = GetSelectedExport();
            if (x == null)
                return;
            throbExport.ShowThrobber();
            bgExport.RunWorkerAsync(x);
        }
        private void mnuExport_Click(object sender, EventArgs e)
        {
            ExportSelectedImports();
        }
        private void mergeListsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GrabSelectedImports();
            if (TheImportLogic.SelectedIDs.Count <= 0)
                return;
            if (bgMergeImports.IsBusy)
                return;
            bgMergeImports.RunWorkerAsync();
        }
        private void mnuReport_Click(object sender, EventArgs e)
        {
            GrabSelectedImports();
            if (TheImportLogic.SelectedIDs.Count <= 0)
                return;
            StockEvaluator ev = new StockEvaluator();
            RzWin.Form.TabShow(ev, "Item Evaluator");
            ev.CompleteStructure();
            ev.SetListNames(TheImportLogic.SelectedIDs);
        }
        private void mnuEditNotes_Click(object sender, EventArgs e)
        {
            ListViewItem i = null;
            try
            {
                i = lvPastImports.SelectedItems[0];
                if (i == null)
                    return;
            }
            catch { return; }
            import_summary s = (import_summary)i.Tag;
            if (s == null)
            {
                s = import_summary.New(RzWin.Context);
                s.importid = i.Text;
                s.Insert(RzWin.Context);
                i.Tag = s;
            }
            bool has = Tools.Strings.StrExt(s.importnotes);
            s.importnotes = RzWin.Context.TheLeader.AskForString("Notes", s.importnotes, true);
            if (has && !Tools.Strings.StrExt(s.importnotes))
            {
                RzWin.Context.TheLeader.Tell("Please enter at least the word 'blank' to remove all notes.");
                return;
            }
            s.Update(RzWin.Context);
            if (i.SubItems.Count == 2)
                i.SubItems.Add("");
            i.SubItems[2].Text = s.importnotes;
        }
        private void partCrossReferenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunPartCrossReference();
        }


    }
    public interface IImportInventoryScreen
    {
        void CompleteLoad(Enums.StockType t);

    }
}