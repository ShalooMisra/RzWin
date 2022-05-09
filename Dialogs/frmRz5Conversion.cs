using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rz5;
using Core;
using NewMethod;
using System.Collections;
using Tools.Database;

namespace RzInterfaceWin
{
    public partial class frmRz5Conversion : Form
    {
        //Private Variables
        private List<Rz5ConversionPanel> Panels = new List<Rz5ConversionPanel>();
        private DateTime Start = Tools.Dates.GetBlankDate();
        private ImportRz5 ImportLogic = new ImportRz5();

        //Constructors
        public frmRz5Conversion()
        {
            InitializeComponent();
        }
        //Private Functions
        private void Import()
        {
            if (bgw.IsBusy)
                return;
            Start = DateTime.Now;
            ClearExistingPanels();
            if (!RzWin.Context.TheLeader.AreYouSure("delete ALL OF THE orddet_line info in the system now"))
                return;
            bgw.RunWorkerAsync("prep");
        }
        private void ClearExistingPanels()
        {
            Panels = new List<Rz5ConversionPanel>();
            fPanel.Controls.Clear();
        }
        //Conversion Functions
        private void PrepRz5Conversion()
        {
            Core.Leader leader = new Core.Leader();
            Context context = RzWin.Context.Clone();
            context.TheLeader = leader;
            leader.StatusSet += new StatusSetHandler(SetStatusPrep);
            context.TheLeader.Comment("Doing Structure Update");
            RzWin.Context.xSys.UpdateDataStructure((ContextNM)context, true);
            context.TheLeader.Comment("Doing Field Maintenance");
            RzWin.Context.Sys.FieldMaintenance(context);
            context.TheLeader.Comment("Doing Rz5 Conversion Prep");
            ImportLogic.ImportPrep((ContextRz)context);
            leader.StatusSet -= new StatusSetHandler(SetStatusPrep);
        }
        private void LoadOrddetLineProcesses()
        {
            ClearExistingPanels();
            DataTable dt = RzWin.Context.Select("select distinct(year(orderdate)) as orderdate from orddet_sales where year(orderdate) > 1900 order by orderdate desc");
            foreach (DataRow dr in dt.Rows)
            {
                int year = Tools.Data.NullFilterInteger(dr["orderdate"]);
                Rz5ConversionPanel p = new Rz5ConversionPanel();
                p.Init(ImportLogic, year);
                Panels.Add(p);
                fPanel.Controls.Add(p);
            }
            foreach (Rz5ConversionPanel p in Panels)
            {
                p.BeginConversion();
            }
        }
        private void FinishRz5Conversion()
        {
            Core.Leader leader = new Core.Leader();
            Context context = RzWin.Context.Clone();
            context.TheLeader = leader;
            leader.StatusSet += new StatusSetHandler(SetStatusFinish);
            context.TheLeader.Comment("Doing Rz5 Conversion Finish");
            ImportLogic.ImportFinish((ContextRz)context);         
            leader.StatusSet -= new StatusSetHandler(SetStatusFinish);
        }
        private void ReSaveRz5Conversion()
        {
            //Core.Leader leader = new Core.Leader();
            //Context context = RzWin.Context.Clone();
            //context.TheLeader = leader;
            //leader.StatusSet += new StatusSetHandler(SetStatusReSave);
            //context.TheLeader.Comment("Doing Rz5 Conversion ReSave");
            //ImportLogic.ResSaveAllOrderInstances((ContextRz)context);
            //leader.StatusSet -= new StatusSetHandler(SetStatusReSave);
        }
        //Status Events
        private void SetStatusPrep(string s, Color c)
        {
            if (this.InvokeRequired)
            {
                SetStatusDelegate d = new SetStatusDelegate(SetStatusPrepActually);
                this.Invoke(d, new object[] { s });
            }
            else
                SetStatusPrepActually(s);
        }
        private void SetStatusPrepActually(string s)
        {
            if (rtPrep.TextLength >= 5000)
                rtPrep.Text = "";
            rtPrep.Text = s + "\r\n" + rtPrep.Text;
        }
        private void SetStatusFinish(string s, Color c)
        {
            if (this.InvokeRequired)
            {
                SetStatusDelegate d = new SetStatusDelegate(SetStatusFinishActually);
                this.Invoke(d, new object[] { s });
            }
            else
                SetStatusFinishActually(s);
        }
        private void SetStatusFinishActually(string s)
        {
            if (rtFinish.TextLength >= 5000)
                rtFinish.Text = "";
            rtFinish.Text = s + "\r\n" + rtFinish.Text;
        }
        private void SetStatusReSave(string s, Color c)
        {
            if (this.InvokeRequired)
            {
                SetStatusDelegate d = new SetStatusDelegate(SetStatusReSaveActually);
                this.Invoke(d, new object[] { s });
            }
            else
                SetStatusReSaveActually(s);
        }
        private void SetStatusReSaveActually(string s)
        {
            if (rtReSave.TextLength >= 5000)
                rtReSave.Text = "";
            rtReSave.Text = s + "\r\n" + rtReSave.Text;
        }
        //Buttons
        private void cmdConvert_Click(object sender, EventArgs e)
        {
            Import();
        }
        private void cmdReSave_Click(object sender, EventArgs e)
        {
            Start = DateTime.Now;
            ClearExistingPanels();
            Rz5ConversionPanel p = new Rz5ConversionPanel();
            p.Init(ImportLogic, "ordhed_quote");
            Panels.Add(p);
            fPanel.Controls.Add(p);
            p = new Rz5ConversionPanel();
            p.Init(ImportLogic, "ordhed_rfq");
            Panels.Add(p);
            fPanel.Controls.Add(p);
            p = new Rz5ConversionPanel();
            p.Init(ImportLogic, "ordhed_sales");
            Panels.Add(p);
            fPanel.Controls.Add(p);
            p = new Rz5ConversionPanel();
            p.Init(ImportLogic, "ordhed_purchase");
            Panels.Add(p);
            fPanel.Controls.Add(p);
            p = new Rz5ConversionPanel();
            p.Init(ImportLogic, "ordhed_invoice");
            Panels.Add(p);
            fPanel.Controls.Add(p);
            p = new Rz5ConversionPanel();
            p.Init(ImportLogic, "ordhed_rma");
            Panels.Add(p);
            fPanel.Controls.Add(p);
            p = new Rz5ConversionPanel();
            p.Init(ImportLogic, "ordhed_vendrma");
            Panels.Add(p);
            fPanel.Controls.Add(p);
            p = new Rz5ConversionPanel();
            p.Init(ImportLogic, "ordhed_service");
            Panels.Add(p);
            fPanel.Controls.Add(p);
            foreach (Rz5ConversionPanel pp in Panels)
            {
                pp.BeginReSave();
            }
            timer1.Start();
        }
        //Control Events
        private void timer1_Tick(object sender, EventArgs e)
        {
            bool is_done = true;
            foreach (Rz5ConversionPanel p in Panels)
            {
                if (!p.IsFinished)
                {
                    is_done = false;
                    break;
                }
            }
            if (is_done)
            {
                timer1.Stop();
                bgw.RunWorkerAsync("finish");
            }
        }
        //Background Workers
        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            switch (e.Argument.ToString().ToLower())
            {
                case "prep":
                    PrepRz5Conversion();
                    e.Result = "prep";
                    break;
                case "finish":
                    FinishRz5Conversion();
                    e.Result = "finish";
                    break;
                case "resave":
                    ReSaveRz5Conversion();
                    e.Result = "done";
                    break;
                default:
                    break;
            }
        }
        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            switch (e.Result.ToString().ToLower())
            {
                case "prep":
                    LoadOrddetLineProcesses();
                    timer1.Start();
                    break;
                case "finish":
                    //bgw.RunWorkerAsync("resave");
                    //break;
                case "done":
                    TimeSpan span = DateTime.Now - Start;
                    string total_time = "Days: " + span.Days.ToString() + ", Hours: " + span.Hours.ToString() + ", Minutes: " + span.Minutes.ToString();
                    RzWin.Context.TheLeader.Tell("Rz5 Conversion Complete/r/nTotal Time: " + total_time);
                    break;
                default:
                    break;
            }
        }

        private void cmdReIndex_Click(object sender, EventArgs e)
        {
            if (!RzWin.Context.TheLeader.AreYouSure("you want to reindex the database"))
                return;
            RzWin.Context.TheLeader.StartPopStatus();
            try { ImportLogic.ReindexDatabase(RzWin.Context); }
            catch (Exception ee) { RzWin.Context.TheLeader.Comment("Error: " + ee.Message); }
            RzWin.Context.TheLeader.Comment("Done.");
            RzWin.Context.TheLeader.StopPopStatus(true);
        }
    }
    public class ImportRz5
    {
        //Private Variables
        private List<String> DetailTables
        {
            get
            {
                List<String> ret = new List<string>();
                ret.Add("orddet_sales");
                ret.Add("orddet_purchase");
                ret.Add("orddet_service");
                ret.Add("orddet_invoice");
                ret.Add("orddet_rma");
                ret.Add("orddet_vendrma");
                return ret;
            }
        }
        private List<FieldSwitch> FieldSwitches
        {
            get
            {
                List<FieldSwitch> ret = new List<FieldSwitch>();
                ret.Add(new FieldSwitch("orddet_sales", "unitprice", "unit_price"));
                ret.Add(new FieldSwitch("orddet_invoice", "unitprice", "unit_price"));
                ret.Add(new FieldSwitch("orddet_rma", "unitprice", "unit_price"));
                ret.Add(new FieldSwitch("orddet_vendrma", "unitprice", "unit_price"));
                ret.Add(new FieldSwitch("orddet_purchase", "unitprice", "unit_cost"));
                ret.Add(new FieldSwitch("orddet_sales", "extendedorder", "total_price"));
                ret.Add(new FieldSwitch("orddet_invoice", "extendedorder", "total_price"));
                ret.Add(new FieldSwitch("orddet_rma", "extendedorder", "total_price"));
                ret.Add(new FieldSwitch("orddet_vendrma", "extendedorder", "total_price"));
                ret.Add(new FieldSwitch("orddet_service", "extendedorder", "service_cost"));
                ret.Add(new FieldSwitch("orddet_purchase", "extendedorder", "total_cost"));
                ret.Add(new FieldSwitch("orddet_sales", "extendedfilled", "total_price"));
                ret.Add(new FieldSwitch("orddet_invoice", "extendedfilled", "total_price"));
                ret.Add(new FieldSwitch("orddet_rma", "extendedfilled", "total_price"));
                ret.Add(new FieldSwitch("orddet_vendrma", "extendedfilled", "total_price"));
                ret.Add(new FieldSwitch("orddet_service", "extendedfilled", "total_price"));
                ret.Add(new FieldSwitch("orddet_purchase", "extendedfilled", "total_cost"));
                ret.Add(new FieldSwitch("orddet_sales", "vendorname", "vendor_name"));
                ret.Add(new FieldSwitch("orddet_invoice", "vendorname", "vendor_name"));
                ret.Add(new FieldSwitch("orddet_rma", "vendorname", "vendor_name"));
                ret.Add(new FieldSwitch("orddet_vendrma", "vendorname", "vendor_name"));
                ret.Add(new FieldSwitch("orddet_service", "vendorname", "vendor_name"));
                ret.Add(new FieldSwitch("orddet_purchase", "companyname", "vendor_name"));
                ret.Add(new FieldSwitch("orddet_sales", "companyname", "customer_name"));
                ret.Add(new FieldSwitch("orddet_invoice", "companyname", "customer_name"));
                ret.Add(new FieldSwitch("orddet_rma", "companyname", "customer_name"));
                ret.Add(new FieldSwitch("orddet_vendrma", "companyname", "customer_name"));
                ret.Add(new FieldSwitch("orddet_service", "companyname", "customer_name"));
                ret.Add(new FieldSwitch("orddet_purchase", "vendorname", "customer_name"));
                ret.Add(new FieldSwitch("orddet_sales", "unitcost", "unit_cost"));
                ret.Add(new FieldSwitch("orddet_invoice", "unitcost", "unit_cost"));
                ret.Add(new FieldSwitch("orddet_rma", "unitcost", "unit_cost"));
                ret.Add(new FieldSwitch("orddet_vendrma", "unitcost", "unit_cost"));
                ret.Add(new FieldSwitch("orddet_service", "unitcost", "unit_cost"));
                foreach (String s in DetailTables)
                {
                    ret.Add(new FieldSwitch(s, "quantityordered", "quantity"));
                    ret.Add(new FieldSwitch(s, "quantityfilled", "quantity"));
                    ret.Add(new FieldSwitch(s, "linecode", "linecode_" + Tools.Strings.ParseDelimit(s, "_", 2).ToLower()));
                }
                return ret;
            }
        }

        //Public Functions
        public void ImportPrep(ContextRz context)
        {
            DateTime start = DateTime.Now;
            context.TheLeader.CommentEllipse("Starting the import process");
            bool recall = context.xSys.Recall;
            if (recall)
                context.xSys.Recall = false;
            bool ret = true;
            context.TheLeader.CommentEllipse("Showing detail tables");
            if (!ShowDetailTables(context))
                ret = false;
            context.TheLeader.CommentEllipse("Switching template fields");
            SwitchTemplateFields(context);
            ResetReorgFlags(context);
            context.TheLeader.Comment("Reindexing Order Tables");
            ReindexOrderTables(context);
            context.Execute("truncate table orddet_line");
            DataSql.StructureCheckClass(context, context.TheSys.CoreClassGet("partrecord"), "shipped_stock");
            context.TheLeader.Comment("Updating Part Records");
            UpdatePartRecords(context);
            context.TheLeader.Comment("Updating Line Templates");
            UpdateLineTemplates(context);
            ordhed.DropOrderViews(context);
            ordhed.CreateOrderViews(context);
            if (recall)
                context.xSys.Recall = true;
            TimeSpan span = DateTime.Now - start;
            string total_time = "Days: " + span.Days.ToString() + ", Hours: " + span.Hours.ToString() + ", Minutes: " + span.Minutes.ToString();
            if (!ret)
                throw new Exception("The import prep failed: " + total_time);
            context.TheLeader.Comment("Done: " + total_time);
        }
        public string ImportOrddetLines(ContextRz context, int year)
        {
            DateTime start = DateTime.Now;
            context.TheLeader.CommentEllipse("Starting the import process");
            bool recall = context.xSys.Recall;
            if (recall)
                context.xSys.Recall = false;
            bool ret = true;
            if (!ImportDetailLines(context, year))
                ret = false;
            if (recall)
                context.xSys.Recall = true;
            TimeSpan span = DateTime.Now - start;
            string total_time = "Days: " + span.Days.ToString() + ", Hours: " + span.Hours.ToString() + ", Minutes: " + span.Minutes.ToString();
            if (!ret)
                throw new Exception("The import failed: " + total_time);
            context.TheLeader.Comment("Done: " + total_time);
            return total_time;
        }
        public void ImportFinish(ContextRz context)
        {
            DateTime start = DateTime.Now;
            context.TheLeader.Comment("Starting the finish process");
            bool recall = context.xSys.Recall;
            if (recall)
                context.xSys.Recall = false;
            bool ret = true;
            context.TheLeader.Comment("Importing Services");
            if (!ImportServices(context))
                ret = false;
            context.TheLeader.Comment("Importing Deductions");
            ImportDeductions(context, Tools.Dates.NullDate, Rz5.Enums.OrderType.Invoice);
            ImportDeductions(context, Tools.Dates.NullDate, Rz5.Enums.OrderType.Purchase);
            ImportDeductions(context, Tools.Dates.NullDate, Rz5.Enums.OrderType.Service);
            ReOrderDetailLines(context);
            //context.TheLeader.Comment("Reindexing Database");
            //ReindexDatabase(context);
            if (!HideDetailTables(context))
                ret = false;
            if (recall)
                context.xSys.Recall = true;
            TimeSpan span = DateTime.Now - start;
            string total_time = "Days: " + span.Days.ToString() + ", Hours: " + span.Hours.ToString() + ", Minutes: " + span.Minutes.ToString();
            if (!ret)
                throw new Exception("The import failed: " + total_time);
            context.TheLeader.Comment("Done: " + total_time);
        }
        public void ResSaveAllOrderInstances(ContextRz context, string order_type)
        {
            //ReSave To Update Colors
            context.TheLeader.Comment("ReSaving [" + order_type + "]");
            try
            {
                SysNewMethod.UpdateAllByClass(context, order_type, true);
                context.TheLeader.Comment("Finished ReSaving [" + order_type + "]");
            }
            catch (Exception ee)
            {
                context.TheLeader.Comment("Error: " + ee.Message);
            }
        }
        //Private Functions
        private bool ShowDetailTables(ContextRz context)
        {
            context.TheLeader.CommentEllipse("Showing detail tables");
            foreach (String s in DetailTables)
            {
                if (!ShowDetailTable(context, s))
                    return false;
            }
            return true;
        }
        private bool ShowDetailTable(ContextRz context, String table)
        {
            if (context.TableExists(table))
                return true;
            if (!context.TableExists(table + "_bak_reorg"))
                return true;
            if (!context.TheData.TheConnection.RenameTable(table + "_bak_reorg", table))
            {
                context.TheLeader.Error("Failed to show " + table);
                return false;
            }
            else
                return true;
        }
        private void SwitchTemplateFields(ContextRz context)
        {
            String q = "update n_column set field_name = lower(field_name)";
            context.Execute(q);
            q = "update n_template set class_name = lower(class_name)";
            context.Execute(q);
            q = "delete from n_column where field_name = 'quantityordered' and exists ( select * from n_column x where x.field_name = 'quantityfilled' and the_n_template_uid = n_column.the_n_template_uid )";
            context.Execute(q);
            foreach (FieldSwitch s in FieldSwitches)
            {
                String sql = "update x set x.field_name = '" + s.FieldNew + "' from n_column x inner join n_template t on t.unique_id = x.the_n_template_uid where x.field_name = '" + s.FieldOld + "' and ( t.class_name = '" + s.Table + "' or t.class_name = 'orddet_line' )";
                context.Execute(sql);
            }
            foreach (String table in DetailTables)
            {
                q = "delete x from n_column x inner join n_template y on y.unique_id = x.the_n_template_uid where x.field_name = 'isselected' and y.class_name = '" + table + "'";
                context.Execute(q);
                context.Execute("update n_template set class_name = 'orddet_line' where class_name = '" + table + "'");
            }
        }
        private void ResetReorgFlags(ContextRz context)
        {
            foreach (String s in DetailTables)
            {
                context.TheData.TheConnection.FieldMakeExist(s, new Field("reorg_import_flag", FieldType.Boolean));
                context.Execute("update " + s + " set reorg_import_flag = 0");
            }
        }
        private string LinkSingleLine(ContextRz context, orddet_line l, String type, String old_order_id)
        {
            ArrayList order_ids = context.SelectScalarArray("select orderid2 from ordlnk where orderid1 = '" + old_order_id + "' and ordertype2 = '" + type + "'");
            if (order_ids.Count > 0)
            {
                DataTable d = context.Select("select * from orddet_" + type + " where isnull(reorg_import_flag, 0) = 0 and fullpartnumber = '" + context.Filter(l.fullpartnumber) + "' and base_ordhed_uid in (" + Tools.Data.GetIn(order_ids) + ")");//and quantityordered = " + l.quantity.ToString() + "
                if (Tools.Data.DataTableExists(d))
                {
                    if (d.Rows.Count == 1)
                    {
                        DataRow rp = d.Rows[0];
                        AbsorbLine(context, l, type, rp);
                        string return_id = "";
                        try { return_id = Tools.Data.NullFilterString(rp["base_ordhed_uid"]); }
                        catch { }
                        return return_id;
                    }
                    else
                    {
                        string deal_id2 = context.SelectScalarString("select base_dealdetail_uid from orddet_sales where unique_id = '" + l.legacyid_sales + "'");
                        if (!Tools.Strings.StrExt(deal_id2))
                            return "";
                        foreach (DataRow dr in d.Rows)
                        {
                            string deal_id = Tools.Data.NullFilterString(dr["base_dealdetail_uid"]);
                            if (!Tools.Strings.StrExt(deal_id))
                                continue;
                            if (!Tools.Strings.StrCmp(deal_id, deal_id2))
                                continue;
                            AbsorbLine(context, l, type, dr);
                            string return_id = "";
                            try { return_id = Tools.Data.NullFilterString(dr["base_ordhed_uid"]); }
                            catch { }
                            return return_id;
                        }
                        return "";
                    }
                }
            }
            return "";
        }
        private bool ImportServices(ContextRz context)
        {
            String table = "orddet_service";
            if (!context.TableExists(table))
                table = "orddet_service_bak";
            DataTable d = context.Select("select * from " + table + " where isnull(is_service, 0) = 1 order by ordernumber");
            foreach (DataRow r in d.Rows)
            {
                String ordernumber = Tools.Data.NullFilterString(r["ordernumber"]);
                String service_name = Tools.Data.NullFilterString(r["fullpartnumber"]);
                //try to get it by part, if they used the part number as the service name
                orddet_line l = (orddet_line)context.QtO("orddet_line", "select top 1 * from orddet_line where fullpartnumber = '" + context.Filter(service_name) + "' and ordernumber_service = '" + context.Filter(ordernumber) + "'");
                if (l == null)
                    l = (orddet_line)context.QtO("orddet_line", "select top 1 * from orddet_line where ordernumber_service = '" + context.Filter(ordernumber) + "'");
                if (l != null)
                {
                    service_line sl = l.ServiceLines.RefAddNew(context);
                    sl.service_name = service_name;
                    sl.quantity = Tools.Data.NullFilterIntegerFromIntOrLong(r["quantityordered"]);
                    sl.unit_cost = Tools.Data.NullFilterDouble(r["unitprice"]);
                    context.Update(sl);
                    context.Update(l);
                }
            }
            return true;
        }
        private bool HideDetailTables(ContextRz context)
        {
            context.TheLeader.CommentEllipse("Hiding detail tables");
            foreach (String s in DetailTables)
            {
                if (!HideDetailTable(context, s))
                    return false;
            }
            //context.Execute("drop view orddet", true);
            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine("create view [dbo].[orddet] as ");
            //sb.AppendLine("select unique_id, stocktype, boxnum, ordernumber, ordertype, isinstock, stockid, quantityordered, quantityfilled, quantitystocked, fullpartnumber, datecode, manufacturer, condition, partsetup, partsperpack, base_ordhed_uid, packaging, alternatepart, category, extendedordercurr, extendedorder, extendedfilled, extendedfilledcurr, totalpricecurr, totalprice, unitprice, unitpricecurr, unitcostcurr, unitcost, lineprofit, vendor_company_uid, lineprofitcurr, linecode, printedas, legacyvendorname, base_mc_user_uid, legacystockid, stocktable, location, userid, legacyusername, polinkcount, internalpartnumber, base_division_uid, prefix, basenumber, basenumberstripped, basenumbertrunced, isselected, delivery, vendorname, shipdate, orderdate, quantitypurchased, base_dealdetail_uid, companyname, agentname, quantitybacked, hasbeenpicked, hasbeenallocated, description, requireddate, quantitycancelled, ponumber, leadtime, minimumquantity, lotnumber, country, qbid, alternatepart_01, alternatepart_02, alternatepart_03, alternatepart_04, buytype, base_dealheader_uid, buyername, totalvalue, buyerid, dockdate, shipvia, base_company_uid, internalcomment, vendorcontactid, vendorcontactname, buyinid, linkid, shippingamount, freightcost, servicecost, grossprofit, nopo, referencenumber, isscheduled, stockvalue, base_companycontact_uid, filldate, fillnote, fillagentname, should_purchase, vendorid, assemblyname, sales_orddet_uid, alternatepartstripped, market_email_date, isverified, iscomplete, isvoid, is_service, mfg_certifications, extra_services, original_stock_id, unit_of_measure, original_vendor_name, line_paid, line_note, has_cofc, is_accepted, contactname, req_uid, opportunityindex, internalstripped, vendor_po, quicknote, warranty_period, is_removedfromque, abs_type, invoice_date, status_notes, target_quantity, target_price, rohs, vendor_date_paid, vendor_shipping_account, vendor_tracking_number, vendor_shipping_cost, vendor_other_cost, consignment_code, consignment_percent, date_created, date_modified, grid_color, icon_index from orddet_rfq ");
            //sb.AppendLine("union all ");
            //sb.AppendLine("select unique_id, stocktype, boxnum, ordernumber, ordertype, isinstock, stockid, quantityordered, quantityfilled, quantitystocked, fullpartnumber, datecode, manufacturer, condition, partsetup, partsperpack, base_ordhed_uid, packaging, alternatepart, category, extendedordercurr, extendedorder, extendedfilled, extendedfilledcurr, totalpricecurr, totalprice, unitprice, unitpricecurr, unitcostcurr, unitcost, lineprofit, vendor_company_uid, lineprofitcurr, linecode, printedas, legacyvendorname, base_mc_user_uid, legacystockid, stocktable, location, userid, legacyusername, polinkcount, internalpartnumber, base_division_uid, prefix, basenumber, basenumberstripped, basenumbertrunced, isselected, delivery, vendorname, shipdate, orderdate, quantitypurchased, base_dealdetail_uid, companyname, agentname, quantitybacked, hasbeenpicked, hasbeenallocated, description, requireddate, quantitycancelled, ponumber, leadtime, minimumquantity, lotnumber, country, qbid, alternatepart_01, alternatepart_02, alternatepart_03, alternatepart_04, buytype, base_dealheader_uid, buyername, totalvalue, buyerid, dockdate, shipvia, base_company_uid, internalcomment, vendorcontactid, vendorcontactname, buyinid, linkid, shippingamount, freightcost, servicecost, grossprofit, nopo, referencenumber, isscheduled, stockvalue, base_companycontact_uid, filldate, fillnote, fillagentname, should_purchase, vendorid, assemblyname, sales_orddet_uid, alternatepartstripped, market_email_date, isverified, iscomplete, isvoid, is_service, mfg_certifications, extra_services, original_stock_id, unit_of_measure, original_vendor_name, line_paid, line_note, has_cofc, is_accepted, contactname, req_uid, opportunityindex, internalstripped, vendor_po, quicknote, warranty_period, is_removedfromque, abs_type, invoice_date, status_notes, target_quantity, target_price, rohs, vendor_date_paid, vendor_shipping_account, vendor_tracking_number, vendor_shipping_cost, vendor_other_cost, consignment_code, consignment_percent, date_created, date_modified, grid_color, icon_index from orddet_quote ");
            //context.Execute(sb.ToString());
            return true;
        }
        private bool HideDetailTable(ContextRz context, String table)
        {
            if (!context.TableExists(table))
                return true;
            if (!context.TheData.TheConnection.RenameTable(table, table + "_bak_reorg"))
            {
                context.TheLeader.Error("Failed to hide " + table);
                return false;
            }
            else
                return true;
        }
        private void ImportDeductions(ContextRz context, DateTime start_cutoff)
        {
            context.TheLeader.StartPopStatus("Importing charges...");
            ImportDeductions(context, start_cutoff, Rz5.Enums.OrderType.Invoice);
            ImportDeductions(context, start_cutoff, Rz5.Enums.OrderType.Purchase);
            ImportDeductions(context, start_cutoff, Rz5.Enums.OrderType.Service);
            context.TheLeader.Comment("Done.");
            context.TheLeader.StopPopStatus(true);
        }
        private bool ImportDetailLines(ContextRz context, int year)
        {
            try
            {
                DateTime start = DateTime.Now;
                context.TheLeader.CommentEllipse("Importing " + start.ToString());
                ArrayList sales_ids = context.SelectScalarArray("select unique_id from orddet_sales where year(orderdate) = " + year.ToString() + " order by orderdate desc");
                context.TheLeader.ProgressStart(sales_ids.Count, "Sales loop");
                context.TheLeader.Comment("Found " + sales_ids.Count.ToString() + " sales lines to convert");
                int i = 1;
                foreach (String id in sales_ids)
                {
                    context.TheLeader.Comment("Sales Order " + i.ToString() + " of " + sales_ids.Count.ToString());
                    i++;
                    DataTable d = context.Select("select * from orddet_sales where unique_id = '" + id + "'");
                    ImportDetailLineSales(context, d.Rows[0]);
                    context.TheLeader.ProgressAdd("");
                }
                context.TheLeader.Comment("Importing non-linked...");
                ImportDetailLines(context, "purchase", year);
                ImportDetailLines(context, "invoice", year);
                ImportDetailLines(context, "rma", year);
                ImportDetailLines(context, "vendrma", year);
                ImportDetailLines(context, "service", year);
                context.TheLeader.Comment("Done: " + Tools.Number.LongFormat(DateTime.Now.Subtract(start).TotalMinutes) + " minutes");
                return true;
            }
            catch (Exception ex)
            {
                context.TheLeader.Error(ex);
                return false;
            }
        }
        private void ImportDetailLineSales(ContextRz context, DataRow r)
        {
            try
            {
                orddet_line l = orddet_line.New(context);
                l.Status = Rz5.Enums.OrderLineStatus.Hold;
                l.Insert(context);
                foreach (DataColumn c in r.Table.Columns)
                {
                    switch (c.Caption)
                    {
                        case "unique_id":
                        case "status":
                            break;
                        default:
                            if (c.Caption == "shipdate")
                            {
                                Object x = r["shipdate"];
                                if (x != null && x != DBNull.Value)
                                {
                                    l.ship_date_due = nData.NullFilter_DateTime(x);
                                    l.ship_date_next = nData.NullFilter_DateTime(x);
                                }
                                break;
                            }
                            if (c.Caption == "requireddate")
                            {
                                Object x = r["requireddate"];
                                if (x != null && x != DBNull.Value)
                                {
                                    context.TheSysRz.TheLineLogic.SetInitialLineDockDates(l, nData.NullFilter_DateTime(x));                                    
                                }
                                    
                                break;
                            }
                            try
                            {
                                Object x = r[c.Caption];
                                if (x != null && x != DBNull.Value)
                                    l.ISet(c.Caption, x);
                            }
                            catch { }
                            break;
                    }
                }
                l.quantity = Tools.Data.NullFilterIntegerFromIntOrLong(r["quantityordered"]);
                l.unit_price = Tools.Data.NullFilterDouble(r["unitprice"]);
                l.unit_cost = Tools.Data.NullFilterDouble(r["unitcost"]);
                l.internal_customer = l.internalpartnumber;
                l.vendor_uid = Tools.Data.NullFilterString(r["vendorid"]);
                if (!Tools.Strings.StrExt(l.vendor_uid))
                    l.vendor_uid = Tools.Data.NullFilterString(r["vendor_company_uid"]);
                l.vendor_name = Tools.Data.NullFilterString(r["vendorname"]);
                l.vendor_contact_uid = Tools.Data.NullFilterString(r["vendorcontactid"]);
                l.vendor_contact_name = Tools.Data.NullFilterString(r["vendorcontactname"]);
                l.customer_uid = Tools.Data.NullFilterString(r["base_company_uid"]);
                l.customer_name = Tools.Data.NullFilterString(r["companyname"]);
                l.customer_contact_uid = Tools.Data.NullFilterString(r["base_companycontact_uid"]);
                l.customer_contact_name = Tools.Data.NullFilterString(r["contactname"]);
                if (l.StockType == Rz5.Enums.StockType.Buy && Tools.Strings.StrExt(l.vendor_uid))
                    l.needs_purchasing = true;
                string order_id = Tools.Data.NullFilterString(r["base_ordhed_uid"]);
                if (Tools.Strings.StrExt(order_id))
                {
                    l.shipvia_invoice = context.SelectScalarString("select shipvia from ordhed_sales where unique_id = '" + order_id + "'");
                    l.shippingaccount_invoice = context.SelectScalarString("select shippingaccount from ordhed_sales where unique_id = '" + order_id + "'");
                    string seller_id = context.SelectScalarString("select base_mc_user_uid from ordhed_sales where unique_id = '" + order_id + "'");
                    n_user u = null;
                    if (Tools.Strings.StrExt(seller_id))
                        u = n_user.GetById(context, seller_id);
                    if (u != null)
                    {
                        l.seller_uid = u.unique_id;
                        l.seller_name = u.name;
                    }
                    string buyer_id = context.SelectScalarString("select orderbuyerid from ordhed_sales where unique_id = '" + order_id + "'");
                    u = null;
                    if (Tools.Strings.StrExt(buyer_id))
                        u = n_user.GetById(context, buyer_id);
                    if (u != null)
                    {
                        l.buyer_uid = u.unique_id;
                        l.buyer_name = u.name;
                    }
                }
                else
                {
                    context.Leader.Comment("Error!");
                }
                AbsorbLine(context, l, "sales", r);
                TimeSpan t = DateTime.Now.Subtract(l.orderdate_sales);
                string po_numb = LinkSingleLine(context, l, "purchase", order_id);
                string invoice = LinkSingleLine(context, l, "invoice", order_id);
                if (Tools.Strings.StrExt(invoice))
                    LinkSingleLine(context, l, "rma", invoice);
                if (Tools.Strings.StrExt(po_numb))
                    LinkSingleLine(context, l, "vendrma", po_numb);
                LinkSingleLine(context, l, "service", order_id);
                if (Tools.Strings.StrExt(po_numb))
                    LinkSingleLine(context, l, "service", po_numb);
                l.Update(context);
            }
            catch (Exception ex)
            {
                context.TheLeader.Error(ex.Message);
            }
        }
        private void AbsorbLine(ContextRz context, orddet_line l, String type, DataRow r)
        {
            l.ISet("orderid_" + type, Tools.Data.NullFilterString(r["base_ordhed_uid"]));
            l.ISet("ordernumber_" + type, Tools.Data.NullFilterString(r["ordernumber"]));
            l.ISet("orderdate_" + type, Tools.Data.NullFilterDate(r["orderdate"]));
            l.ISet("linecode_" + type, Tools.Data.NullFilterIntegerFromIntOrLong(r["linecode"]));
            l.ISet("legacyid_" + type, Tools.Data.NullFilterString(r["unique_id"]));
            pack p = null;
            DateTime req = Tools.Dates.GetBlankDate();
            DateTime ship = Tools.Dates.GetBlankDate();
            switch (type)
            {
                case "purchase":
                    l.Status = Rz5.Enums.OrderLineStatus.Buy;
                    l.was_purchase = true;
                    l.quantity_unpacked = Tools.Data.NullFilterIntegerFromIntOrLong(r["quantityfilled"]);
                    l.datecode_purchase = Tools.Data.NullFilterString(r["datecode"]);
                    if (!Tools.Strings.StrExt(l.internalpart_vendor))
                        l.internalpart_vendor = Tools.Data.NullFilterString(r["internalpartnumber"]);
                    req = Tools.Data.NullFilterDate(r["requireddate"]);
                    ship = Tools.Data.NullFilterDate(r["shipdate"]);
                    if (Tools.Dates.DateExists(req))
                        l.receive_date_due = req;
                    if (Tools.Dates.DateExists(ship) && ship > req)
                        l.receive_date_due = ship;
                    l.receive_date_next = l.receive_date_due;
                    if (l.quantity_unpacked > 0 && l.quantity_unpacked == l.quantity)
                    {
                        l.was_received = true;
                        l.Status = Rz5.Enums.OrderLineStatus.Open;
                    }
                    if (l.quantity_unpacked > 0)
                    {
                        p = (pack)l.PacksInVar.RefAddNewItem(context);
                        p.quantity = l.quantity_unpacked;
                        p.fullpartnumber = l.fullpartnumber;
                        p.Update(context);
                    }
                    l.shipvia_purchase = context.SelectScalarString("select shipvia from ordhed_purchase where unique_id = '" + l.orderid_purchase + "'");
                    l.shippingaccount_purchase = context.SelectScalarString("select shippingaccount from ordhed_purchase where unique_id = '" + l.orderid_purchase + "'");
                    l.tracking_purchase = context.SelectScalarString("select trackingnumber from ordhed_purchase where unique_id = '" + l.orderid_purchase + "'");
                    break;
                case "invoice":
                    l.Status = Rz5.Enums.OrderLineStatus.Packing;
                    l.was_invoice = true;
                    l.quantity_packed = Tools.Data.NullFilterIntegerFromIntOrLong(r["quantityfilled"]);
                    if (!Tools.Strings.StrExt(l.internal_customer))
                        l.internal_customer = Tools.Data.NullFilterString(r["internalpartnumber"]);
                    req = Tools.Data.NullFilterDate(r["requireddate"]);
                    ship = Tools.Data.NullFilterDate(r["shipdate"]);
                    if (!Tools.Dates.DateExists(l.ship_date_due))
                        l.ship_date_due = ship;
                    if (!Tools.Dates.DateExists(l.customer_dock_date))
                    {
                        context.TheSysRz.TheLineLogic.SetInitialLineDockDates(l,req);                        
                    }
                       
                    if (l.quantity_packed > 0 && l.quantity_packed == l.quantity)
                    {
                        l.was_shipped = true;
                        l.Status = Rz5.Enums.OrderLineStatus.Shipped;
                    }
                    if (l.quantity_packed > 0)
                    {
                        p = (pack)l.PacksOutVar.RefAddNewItem(context);
                        p.quantity = l.quantity_packed;
                        p.fullpartnumber = l.fullpartnumber;
                        p.Update(context);
                    }
                    l.shipvia_invoice = context.SelectScalarString("select shipvia from ordhed_invoice where unique_id = '" + l.orderid_invoice + "'");
                    l.shippingaccount_invoice = context.SelectScalarString("select shippingaccount from ordhed_invoice where unique_id = '" + l.orderid_invoice + "'");
                    l.tracking_invoice = context.SelectScalarString("select trackingnumber from ordhed_invoice where unique_id = '" + l.orderid_invoice + "'");
                    break;
                case "rma":
                    l.Status = Rz5.Enums.OrderLineStatus.RMA_Receiving;
                    l.was_rma = true;
                    l.quantity_unpacked_rma = Tools.Data.NullFilterIntegerFromIntOrLong(r["quantityfilled"]);
                    if (!Tools.Strings.StrExt(l.internal_customer))
                        l.internal_customer = Tools.Data.NullFilterString(r["internalpartnumber"]);
                    req = Tools.Data.NullFilterDate(r["requireddate"]);
                    ship = Tools.Data.NullFilterDate(r["shipdate"]);
                    if (Tools.Dates.DateExists(req))
                        l.receive_date_rma_due = req;
                    if (Tools.Dates.DateExists(ship) && ship > req)
                        l.receive_date_rma_due = ship;
                    l.receive_date_next = l.receive_date_rma_due;
                    if (l.quantity_unpacked_rma > 0 && l.quantity_unpacked_rma == l.quantity)
                    {
                        l.was_rma_received = true;
                        l.Status = Rz5.Enums.OrderLineStatus.RMA_Received;
                    }
                    if (l.quantity_unpacked_rma > 0)
                    {
                        p = (pack)l.PacksRMAVar.RefAddNewItem(context);
                        p.quantity = l.quantity_unpacked_rma;
                        p.fullpartnumber = l.fullpartnumber;
                        p.Update(context);
                    }
                    l.shipvia_rma = context.SelectScalarString("select shipvia from ordhed_rma where unique_id = '" + l.orderid_rma + "'");
                    l.shippingaccount_rma = context.SelectScalarString("select shippingaccount from ordhed_rma where unique_id = '" + l.orderid_rma + "'");
                    l.tracking_rma = context.SelectScalarString("select trackingnumber from ordhed_rma where unique_id = '" + l.orderid_rma + "'");
                    break;
                case "vendrma":
                    l.Status = Rz5.Enums.OrderLineStatus.Vendor_RMA_Packing;
                    l.was_vendrma = true;
                    l.quantity_packed_vendrma = Tools.Data.NullFilterIntegerFromIntOrLong(r["quantityfilled"]);
                    if (!Tools.Strings.StrExt(l.internalpart_vendor))
                        l.internalpart_vendor = Tools.Data.NullFilterString(r["internalpartnumber"]);
                    ship = Tools.Data.NullFilterDate(r["shipdate"]);
                    req = Tools.Data.NullFilterDate(r["requireddate"]);
                    if (Tools.Dates.DateExists(req))
                        l.ship_date_vendrma_due = req;
                    if (Tools.Dates.DateExists(ship) && ship < req)
                        l.ship_date_vendrma_due = ship;
                    l.ship_date_next = l.ship_date_vendrma_due;
                    if (l.quantity_packed_vendrma > 0 && l.quantity_packed_vendrma == l.quantity)
                    {
                        l.was_vendrma_shipped = true;
                        l.Status = Rz5.Enums.OrderLineStatus.Vendor_RMA_Shipped;
                    }
                    if (l.quantity_packed_vendrma > 0)
                    {
                        p = (pack)l.PacksVendRMAVar.RefAddNewItem(context);
                        p.quantity = l.quantity_packed_vendrma;
                        p.fullpartnumber = l.fullpartnumber;
                        p.Update(context);
                    }
                    l.shipvia_vendrma = context.SelectScalarString("select shipvia from ordhed_vendrma where unique_id = '" + l.orderid_vendrma + "'");
                    l.shippingaccount_vendrma = context.SelectScalarString("select shippingaccount from ordhed_vendrma where unique_id = '" + l.orderid_vendrma + "'");
                    l.tracking_vendrma = context.SelectScalarString("select trackingnumber from ordhed_vendrma where unique_id = '" + l.orderid_vendrma + "'");
                    break;
                case "service":
                    l.was_service_out = true;
                    if (l.Status == Rz5.Enums.OrderLineStatus.Hold || l.Status == Rz5.Enums.OrderLineStatus.Any)
                        l.Status = Rz5.Enums.OrderLineStatus.Out_For_Service;
                    l.quantity_packed_service = l.quantity;
                    if (l.quantity_packed_service > 0)
                    {
                        p = (pack)l.PacksOutServiceVar.RefAddNewItem(context);
                        p.quantity = l.quantity_packed_service;
                        p.fullpartnumber = l.fullpartnumber;
                        p.Update(context);
                    }
                    l.quantity_unpacked_service = Tools.Data.NullFilterIntegerFromIntOrLong(r["quantityfilled"]);
                    if (l.quantity_unpacked_service > 0)
                    {
                        if (l.Status == Rz5.Enums.OrderLineStatus.Out_For_Service)
                            l.Status = Rz5.Enums.OrderLineStatus.Received_From_Service;
                        l.was_service_in = true;
                        p = (pack)l.PacksInServiceVar.RefAddNewItem(context);
                        p.quantity = l.quantity;
                        p.fullpartnumber = l.fullpartnumber;
                        p.Update(context);
                    }
                    ordhed_service ser = ordhed_service.GetById(context, l.orderid_service);
                    if (ser != null)
                    {
                        l.service_vendor_uid = ser.base_company_uid;
                        l.service_vendor_name = ser.companyname;
                        l.service_vendor_contact_uid = ser.base_companycontact_uid;
                        l.service_vendor_contact_name = ser.contactname;
                        l.service_agent_uid = ser.base_mc_user_uid;
                        l.service_agent_name = ser.agentname;
                        l.ship_date_service_due = ser.dockdate;
                        l.receive_date_service_due = ser.dockdate;
                        l.shippingaccount_service_out = ser.shippingaccount;
                        l.shippingaccount_service_in = ser.shippingaccount;
                        l.shipvia_service_out = ser.shipvia;
                        l.shipvia_service_in = ser.freightbilling;
                        l.tracking_service_out = ser.trackingnumber;
                        l.tracking_service_in = context.SelectScalarString("select salesreference from ordhed_service where unique_id = '" + l.orderid_service + "'");
                    }
                    break;
            }
            context.Execute("update orddet_" + type + " set reorg_import_flag = 1 where unique_id = '" + Tools.Data.NullFilterString(r["unique_id"]) + "'");
            ((SysRz5)context.xSys).TheImportLogic.ImportRz3AbsorbLineExtra(l, r, type);
        }
        private void ImportDetailLines(ContextRz context, String type, int year)
        {
            context.TheLeader.Comment("Importing " + type + "...");
            ArrayList ids = context.SelectScalarArray("select unique_id from orddet_" + type + " where year(orderdate) = " + year.ToString() + " and isnull(reorg_import_flag, 0) = 0 and ( ordertype <> 'service' or isnull(is_service, 0) = 0 ) order by orderdate desc");
            context.TheLeader.ProgressStart(ids.Count, "");
            context.TheLeader.Comment("Found " + ids.Count.ToString() + " " + type + " lines to convert");
            int i = 1;
            foreach (String id in ids)
            {
                context.TheLeader.Comment("Processing " + i.ToString() + " of " + ids.Count.ToString());
                i++;
                DataTable d = context.Select("select * from orddet_" + type + " where unique_id = '" + id + "'");
                DataRow r = d.Rows[0];
                orddet_line l = orddet_line.New(context);
                l.Insert(context);
                foreach (DataColumn c in d.Columns)
                {
                    switch (c.Caption)
                    {
                        case "unique_id":
                        case "status":
                            break;
                        default:
                            try
                            {
                                Object x = r[c.Caption];
                                if (x != null && x != DBNull.Value)
                                    l.ISet(c.Caption, x);
                            }
                            catch { }
                            break;
                    }
                }
                l.quantity = Tools.Data.NullFilterIntegerFromIntOrLong(r["quantityordered"]);
                string order_id = Tools.Data.NullFilterString(r["base_ordhed_uid"]);
                string seller_id = context.SelectScalarString("select base_mc_user_uid from ordhed_" + type + " where unique_id = '" + order_id + "'");
                n_user u = null;
                if (Tools.Strings.StrExt(seller_id))
                    u = n_user.GetById(context, seller_id);
                if (u != null)
                {
                    l.seller_uid = u.unique_id;
                    l.seller_name = u.name;
                }
                string buyer_id = context.SelectScalarString("select orderbuyerid from ordhed_" + type + " where unique_id = '" + order_id + "'");
                u = null;
                if (Tools.Strings.StrExt(buyer_id))
                    u = n_user.GetById(context, buyer_id);
                if (u != null)
                {
                    l.buyer_uid = u.unique_id;
                    l.buyer_name = u.name;
                }
                switch (type)
                {
                    case "purchase":
                        l.unit_cost = Tools.Data.NullFilterDouble(r["unitprice"]);
                        l.unit_price = Tools.Data.NullFilterDouble(r["unitcost"]);
                        l.vendor_uid = Tools.Data.NullFilterString(r["base_company_uid"]);
                        l.vendor_name = Tools.Data.NullFilterString(r["companyname"]);
                        l.vendor_contact_uid = Tools.Data.NullFilterString(r["base_companycontact_uid"]);
                        l.vendor_contact_name = Tools.Data.NullFilterString(r["contactname"]);
                        l.customer_uid = Tools.Data.NullFilterString(r["vendor_company_uid"]);
                        l.customer_name = Tools.Data.NullFilterString(r["vendorname"]);
                        l.customer_contact_uid = Tools.Data.NullFilterString(r["vendorcontactid"]);
                        l.customer_contact_name = Tools.Data.NullFilterString(r["vendorcontactname"]);
                        l.datecode_purchase = Tools.Data.NullFilterString(r["datecode"]);
                        break;
                    case "invoice":
                        l.unit_price = Tools.Data.NullFilterDouble(r["unitprice"]);
                        l.unit_cost = Tools.Data.NullFilterDouble(r["unitcost"]);
                        l.vendor_uid = Tools.Data.NullFilterString(r["vendorid"]);
                        l.vendor_name = Tools.Data.NullFilterString(r["vendorname"]);
                        l.vendor_contact_uid = Tools.Data.NullFilterString(r["vendorcontactid"]);
                        l.vendor_contact_name = Tools.Data.NullFilterString(r["vendorcontactname"]);
                        l.customer_uid = Tools.Data.NullFilterString(r["base_company_uid"]);
                        l.customer_name = Tools.Data.NullFilterString(r["companyname"]);
                        l.customer_contact_uid = Tools.Data.NullFilterString(r["base_companycontact_uid"]);
                        l.customer_contact_name = Tools.Data.NullFilterString(r["contactname"]);
                        break;
                    case "rma":
                        l.unit_cost = Tools.Data.NullFilterDouble(r["unitcost"]);
                        l.unit_price_rma = Tools.Data.NullFilterDouble(r["unitprice"]);
                        l.vendor_uid = Tools.Data.NullFilterString(r["vendor_company_uid"]);
                        l.vendor_name = Tools.Data.NullFilterString(r["vendorname"]);
                        l.vendor_contact_uid = Tools.Data.NullFilterString(r["vendorcontactid"]);
                        l.vendor_contact_name = Tools.Data.NullFilterString(r["vendorcontactname"]);
                        l.customer_uid = Tools.Data.NullFilterString(r["base_company_uid"]);
                        l.customer_name = Tools.Data.NullFilterString(r["companyname"]);
                        l.customer_contact_uid = Tools.Data.NullFilterString(r["base_companycontact_uid"]);
                        l.customer_contact_name = Tools.Data.NullFilterString(r["contactname"]);
                        break;
                    case "vendrma":
                        l.unit_cost = Tools.Data.NullFilterDouble(r["unitcost"]);
                        l.unit_price_vendrma = Tools.Data.NullFilterDouble(r["unitprice"]);
                        l.vendor_uid = Tools.Data.NullFilterString(r["base_company_uid"]);
                        l.vendor_name = Tools.Data.NullFilterString(r["companyname"]);
                        l.vendor_contact_uid = Tools.Data.NullFilterString(r["base_companycontact_uid"]);
                        l.vendor_contact_name = Tools.Data.NullFilterString(r["contactname"]);
                        l.customer_uid = Tools.Data.NullFilterString(r["vendor_company_uid"]);
                        l.customer_name = Tools.Data.NullFilterString(r["vendorname"]);
                        l.customer_contact_uid = Tools.Data.NullFilterString(r["vendorcontactid"]);
                        l.customer_contact_name = Tools.Data.NullFilterString(r["vendorcontactname"]);
                        break;
                    case "service":
                        l.unit_cost = Tools.Data.NullFilterDouble(r["unitcost"]);
                        l.unit_price = Tools.Data.NullFilterDouble(r["unitprice"]);
                        break;
                    default:
                        break;
                }
                AbsorbLine(context, l, type, r);
                l.Update(context);
                context.TheLeader.ProgressAdd("");
            }
        }
        private void ImportDeductions(ContextRz context, DateTime start_cutoff, Rz5.Enums.OrderType t)
        {
            String sql = "select unique_id from ordhed_" + t.ToString().ToLower() + " where ( isnull(subtract_1, 0) > 0 or isnull(subtract_2, 0) > 0 or isnull(subtract_3, 0) > 0 )";
            if (Tools.Dates.DateExists(start_cutoff))
                sql += " and orderdate >= '" + Tools.Dates.DateFormat(start_cutoff) + "'";
            sql += " order by orderdate";
            ArrayList a = context.SelectScalarArray(sql);
            if (a.Count == 0)
            {
                context.TheLeader.Comment("No " + t.ToString() + " orders found");
                return;
            }
            context.TheLeader.ProgressStart(a.Count, "Found " + a.Count.ToString() + " " + t.ToString() + " orders");
            foreach (String id in a)
            {
                ordhed_new n = (ordhed_new)context.GetById("ordhed_" + t.ToString().ToLower(), id);
                if (n == null)
                {
                    context.TheLeader.Error("Not found: " + t.ToString() + "." + id);
                    continue;
                }
                orddet_line l = (orddet_line)n.DetailsVar.RefsGetAsItems(context).FirstGet(context);
                if (l == null)
                {
                    context.TheLeader.Comment("No lines on " + n.ToString());
                    continue;
                }
                if (n.subtract_1 > 0 && !l.DeductionHas(context, n.subtract1_caption, n.subtract_1))
                {
                    profit_deduction d = l.DeductionsVar.RefAddNew(context);
                    d.name = n.subtract1_caption;
                    d.amount = n.subtract_1;
                    context.TheDelta.Update(context, d);
                }
                if (n.subtract_2 > 0 && !l.DeductionHas(context, n.subtract2_caption, n.subtract_2))
                {
                    profit_deduction d = l.DeductionsVar.RefAddNew(context);
                    d.name = n.subtract2_caption;
                    d.amount = n.subtract_2;
                    context.TheDelta.Update(context, d);
                }
                if (n.subtract_3 > 0 && !l.DeductionHas(context, n.subtract3_caption, n.subtract_3))
                {
                    profit_deduction d = l.DeductionsVar.RefAddNew(context);
                    d.name = n.subtract3_caption;
                    d.amount = n.subtract_3;
                    context.TheDelta.Update(context, d);
                }
                context.TheLeader.ProgressAdd("");
            }
            context.TheLeader.ProgressEnd();
        }
        private void UpdatePartRecords(ContextRz context)
        {
            context.Execute("update partrecord set stocktype = 'Stock' where stocktype = 'buy'");
            context.Execute("update partrecord set grid_color = -16776961 where stocktype = 'stock'");
            context.Execute("update partrecord set grid_color = -16744448 where stocktype = 'consign'");
            context.Execute("update partrecord set grid_color = -65536 where stocktype = 'excess'");            //Export excel file of partrecords that are stock but have a zero quantity
            string sql = "select unique_id,quantity,fullpartnumber,manufacturer,datecode,location,boxnum,price,cost,vendorname from partrecord where stocktype = 'stock' and isnull(quantity,0) <= 0 order by fullpartnumber";
            string file = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)) + "ZeroStock.xls";
            if (Tools.Files.FileExists(file))
                Tools.Files.TryDeleteFile(file);
            Tools.Data.SqlToExcel(context.Data.TheConnection, sql, file, false);
        }
        private void ReOrderDetailLines(ContextRz context)
        {
            context.TheLeader.Comment("ReOrdering Detail Lines");
            int o = 0;
            //Sales
            ArrayList a = context.SelectScalarArray("select distinct(orderid_sales) from orddet_line where len(isnull(orderid_sales, '')) > 0");
            foreach (string s in a)
            {
                o++;
                context.TheLeader.Comment("Lines Sales Order " + o.ToString() + " of " + a.Count.ToString());
                if (!Tools.Strings.StrExt(s))
                    continue;
                ArrayList b = context.SelectScalarArray("select unique_id from orddet_line where orderid_sales = '" + s + "' order by linecode_sales asc");
                int i = 1;
                foreach (string ss in b)
                {
                    context.Execute("update orddet_line set linecode_sales = " + i.ToString() + " where unique_id = '" + ss + "'");
                    i++;
                }
            }
            //Purchase
            o = 0;
            a = context.SelectScalarArray("select distinct(orderid_purchase) from orddet_line where len(isnull(orderid_purchase, '')) > 0");
            foreach (string s in a)
            {
                o++;
                context.TheLeader.Comment("Lines Purchase Order " + o.ToString() + " of " + a.Count.ToString());
                if (!Tools.Strings.StrExt(s))
                    continue;
                ArrayList b = context.SelectScalarArray("select unique_id from orddet_line where orderid_purchase = '" + s + "' order by linecode_purchase asc");
                int i = 1;
                foreach (string ss in b)
                {
                    context.Execute("update orddet_line set linecode_purchase = " + i.ToString() + " where unique_id = '" + ss + "'");
                    i++;
                }
            }
            //Invoice
            o = 0;
            a = context.SelectScalarArray("select distinct(orderid_invoice) from orddet_line where len(isnull(orderid_invoice, '')) > 0");
            foreach (string s in a)
            {
                o++;
                context.TheLeader.Comment("Lines Invoice " + o.ToString() + " of " + a.Count.ToString());
                if (!Tools.Strings.StrExt(s))
                    continue;
                ArrayList b = context.SelectScalarArray("select unique_id from orddet_line where orderid_invoice = '" + s + "' order by linecode_invoice asc");
                int i = 1;
                foreach (string ss in b)
                {
                    context.Execute("update orddet_line set linecode_invoice = " + i.ToString() + " where unique_id = '" + ss + "'");
                    i++;
                }
            }
            //RMA
            o = 0;
            a = context.SelectScalarArray("select distinct(orderid_rma) from orddet_line where len(isnull(orderid_rma, '')) > 0");
            foreach (string s in a)
            {
                o++;
                context.TheLeader.Comment("Lines RMA " + o.ToString() + " of " + a.Count.ToString());
                if (!Tools.Strings.StrExt(s))
                    continue;
                ArrayList b = context.SelectScalarArray("select unique_id from orddet_line where orderid_rma = '" + s + "' order by linecode_rma asc");
                int i = 1;
                foreach (string ss in b)
                {
                    context.Execute("update orddet_line set linecode_rma = " + i.ToString() + " where unique_id = '" + ss + "'");
                    i++;
                }
            }
            //VendRMA
            o = 0;
            a = context.SelectScalarArray("select distinct(orderid_vendrma) from orddet_line where len(isnull(orderid_vendrma, '')) > 0");
            foreach (string s in a)
            {
                o++;
                context.TheLeader.Comment("Lines VendRMA " + o.ToString() + " of " + a.Count.ToString());
                if (!Tools.Strings.StrExt(s))
                    continue;
                ArrayList b = context.SelectScalarArray("select unique_id from orddet_line where orderid_vendrma = '" + s + "' order by linecode_vendrma asc");
                int i = 1;
                foreach (string ss in b)
                {
                    context.Execute("update orddet_line set linecode_vendrma = " + i.ToString() + " where unique_id = '" + ss + "'");
                    i++;
                }
            }
            //Service
            o = 0;
            a = context.SelectScalarArray("select distinct(orderid_service) from orddet_line where len(isnull(orderid_service, '')) > 0");
            foreach (string s in a)
            {
                o++;
                context.TheLeader.Comment("Lines Service " + o.ToString() + " of " + a.Count.ToString());
                if (!Tools.Strings.StrExt(s))
                    continue;
                ArrayList b = context.SelectScalarArray("select unique_id from orddet_line where orderid_service = '" + s + "' order by linecode_service asc");
                int i = 1;
                foreach (string ss in b)
                {
                    context.Execute("update orddet_line set linecode_service = " + i.ToString() + " where unique_id = '" + ss + "'");
                    i++;
                }
            }
        }
        private void UpdateLineTemplates(ContextRz context)
        {
            //PartSearch Screen
            UpdateSalesSearch(context);
            UpdateBuySearch(context);
            UpdateRMASearch(context);
            UpdateVendRMASearch(context);
            //Company Screen
            UpdateCompDetailsAll(context);
            UpdateCompDetailsSales(context);
            UpdateCompDetailsPurchase(context);
            UpdateCompDetailsInvoice(context);
            UpdateCompDetailsRMA(context);
            UpdateCompDetailsVRMA(context);
            UpdateCompDetailsService(context);
            //Order Screens
            UpdateOrderScreenInvoice(context);
            UpdateOrderScreenPurchase(context);
            UpdateOrderScreenRMA(context);
            UpdateOrderScreenVendRMA(context);
            UpdateOrderScreenSales(context);
            UpdateOrderScreenService(context);
            //Ship Screen
            UpdateShipScreenReceive(context);
            UpdateShipScreenShipping(context);
            //Ar/Ap
            UpdateARAP(context);
            //Print Templates
            UpdatePrintTemplates(context);
        }
        private void UpdatePrintTemplates(ContextRz context)
        {
            UpdatePrintTemplatesSales(context);
            UpdatePrintTemplatesPurchase(context);
            UpdatePrintTemplatesInvoice(context);
            UpdatePrintTemplatesRMA(context);
            UpdatePrintTemplatesVendRMA(context);
        }
        private void UpdatePrintTemplatesVendRMA(ContextRz context)
        {
            //Print Templates VendRMA
            ArrayList a = context.SelectScalarArray("select unique_id from printheader where ordertype = 'vendrma'");
            foreach (string s in a)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                string id = context.SelectScalarString("select unique_id from n_template where template_name = '" + s + "'");
                if (Tools.Strings.StrExt(id))
                {
                    context.Execute("delete from n_template where unique_id = '" + id + "'");
                    context.Execute("delete from n_column where the_n_template_uid = '" + id + "'");
                }
                n_template t = CreateTemplate(context, s);
                n_column c = new n_column();
                c.field_name = "ship_date_vendrma_due";
                c.column_caption = "Ship Date";
                c.column_width = 8;
                c.column_alignment = 2;
                c.column_order = 0;
                c.column_format = "{0:d}";
                c.data_type = 5;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "shipvia_vendrma";
                c.column_caption = "ShipVia";
                c.column_width = 12;
                c.column_alignment = 0;
                c.column_order = 1;
                c.column_format = "";
                c.data_type = 1;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "quantity";
                c.column_caption = "Quantity";
                c.column_width = 8;
                c.column_alignment = 1;
                c.column_order = 2;
                c.column_format = "{0:G}";
                c.data_type = 2;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "fullpartnumber";
                c.column_caption = "Part Number";
                c.column_width = 21;
                c.column_alignment = 0;
                c.column_order = 3;
                c.column_format = "";
                c.data_type = 1;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "internal_vendor";
                c.column_caption = "Internal #";
                c.column_width = 13;
                c.column_alignment = 0;
                c.column_order = 4;
                c.column_format = "";
                c.data_type = 1;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "manufacturer";
                c.column_caption = "MFG";
                c.column_width = 9;
                c.column_alignment = 0;
                c.column_order = 5;
                c.column_format = "";
                c.data_type = 1;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "datecode";
                c.column_caption = "D/C";
                c.column_width = 6;
                c.column_alignment = 0;
                c.column_order = 6;
                c.column_format = "";
                c.data_type = 1;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "unit_price_vendrma";
                c.column_caption = "Price";
                c.column_width = 10;
                c.column_alignment = 1;
                c.column_order = 7;
                c.column_format = "CURRENCY6";
                c.data_type = 4;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "total_price_vendrma";
                c.column_caption = "Total";
                c.column_width = 11;
                c.column_alignment = 1;
                c.column_order = 8;
                c.column_format = "CURRENCY6";
                c.data_type = 4;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
            }
        }
        private void UpdatePrintTemplatesRMA(ContextRz context)
        {
            //Print Templates RMA
            ArrayList a = context.SelectScalarArray("select unique_id from printheader where ordertype = 'rma'");
            foreach (string s in a)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                string id = context.SelectScalarString("select unique_id from n_template where template_name = '" + s + "'");
                if (Tools.Strings.StrExt(id))
                {
                    context.Execute("delete from n_template where unique_id = '" + id + "'");
                    context.Execute("delete from n_column where the_n_template_uid = '" + id + "'");
                }
                n_template t = CreateTemplate(context, s);
                n_column c = new n_column();
                c.field_name = "receive_date_rma_due";
                c.column_caption = "Date Due";
                c.column_width = 8;
                c.column_alignment = 2;
                c.column_order = 0;
                c.column_format = "{0:d}";
                c.data_type = 5;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "shipvia_rma";
                c.column_caption = "ShipVia";
                c.column_width = 14;
                c.column_alignment = 0;
                c.column_order = 1;
                c.column_format = "";
                c.data_type = 1;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "quantity";
                c.column_caption = "Quantity";
                c.column_width = 8;
                c.column_alignment = 1;
                c.column_order = 2;
                c.column_format = "{0:G}";
                c.data_type = 2;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "fullpartnumber";
                c.column_caption = "Part Number";
                c.column_width = 24;
                c.column_alignment = 0;
                c.column_order = 3;
                c.column_format = "";
                c.data_type = 1;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "internal_customer";
                c.column_caption = "Internal #";
                c.column_width = 13;
                c.column_alignment = 0;
                c.column_order = 4;
                c.column_format = "";
                c.data_type = 1;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "manufacturer";
                c.column_caption = "MFG";
                c.column_width = 9;
                c.column_alignment = 0;
                c.column_order = 5;
                c.column_format = "";
                c.data_type = 1;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "datecode";
                c.column_caption = "D/C";
                c.column_width = 6;
                c.column_alignment = 0;
                c.column_order = 6;
                c.column_format = "";
                c.data_type = 1;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "unit_price_rma";
                c.column_caption = "Price";
                c.column_width = 8;
                c.column_alignment = 1;
                c.column_order = 7;
                c.column_format = "CURRENCY6";
                c.data_type = 4;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "total_price_rma";
                c.column_caption = "Total";
                c.column_width = 10;
                c.column_alignment = 1;
                c.column_order = 8;
                c.column_format = "CURRENCY6";
                c.data_type = 4;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
            }
        }
        private void UpdatePrintTemplatesInvoice(ContextRz context)
        {
            //Print Templates Invoice
            ArrayList a = context.SelectScalarArray("select unique_id from printheader where ordertype = 'invoice'");
            foreach (string s in a)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                string id = context.SelectScalarString("select unique_id from n_template where template_name = '" + s + "'");
                if (Tools.Strings.StrExt(id))
                {
                    context.Execute("delete from n_template where unique_id = '" + id + "'");
                    context.Execute("delete from n_column where the_n_template_uid = '" + id + "'");
                }
                n_template t = CreateTemplate(context, s);
                n_column c = new n_column();
                c.field_name = "quantity_packed";
                c.column_caption = "Quantity";
                c.column_width = 10;
                c.column_alignment = 1;
                c.column_order = 0;
                c.column_format = "{0:G}";
                c.data_type = 2;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "fullpartnumber";
                c.column_caption = "Part Number";
                c.column_width = 27;
                c.column_alignment = 0;
                c.column_order = 1;
                c.column_format = "";
                c.data_type = 1;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "internal_customer";
                c.column_caption = "Internal #";
                c.column_width = 18;
                c.column_alignment = 0;
                c.column_order = 2;
                c.column_format = "";
                c.data_type = 1;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "manufacturer";
                c.column_caption = "MFG";
                c.column_width = 16;
                c.column_alignment = 0;
                c.column_order = 3;
                c.column_format = "";
                c.data_type = 1;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "datecode";
                c.column_caption = "D/C";
                c.column_width = 8;
                c.column_alignment = 0;
                c.column_order = 4;
                c.column_format = "";
                c.data_type = 1;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "unit_price";
                c.column_caption = "Price";
                c.column_width = 9;
                c.column_alignment = 1;
                c.column_order = 5;
                c.column_format = "CURRENCY6";
                c.data_type = 4;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "total_price";
                c.column_caption = "Total";
                c.column_width = 10;
                c.column_alignment = 1;
                c.column_order = 6;
                c.column_format = "CURRENCY6";
                c.data_type = 4;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
            }
        }
        private void UpdatePrintTemplatesPurchase(ContextRz context)
        {
            //Print Templates Purchase
            ArrayList a = context.SelectScalarArray("select unique_id from printheader where ordertype = 'purchase'");
            foreach (string s in a)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                string id = context.SelectScalarString("select unique_id from n_template where template_name = '" + s + "'");
                if (Tools.Strings.StrExt(id))
                {
                    context.Execute("delete from n_template where unique_id = '" + id + "'");
                    context.Execute("delete from n_column where the_n_template_uid = '" + id + "'");
                }
                n_template t = CreateTemplate(context, s);
                n_column c = new n_column();
                c.field_name = "receive_date_due";
                c.column_caption = "Dock Date";
                c.column_width = 10;
                c.column_alignment = 2;
                c.column_order = 0;
                c.column_format = "{0:d}";
                c.data_type = 5;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "shipvia_purchase";
                c.column_caption = "ShipVia";
                c.column_width = 13;
                c.column_alignment = 0;
                c.column_order = 1;
                c.column_format = "";
                c.data_type = 1;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "quantity";
                c.column_caption = "Quantity";
                c.column_width = 8;
                c.column_alignment = 1;
                c.column_order = 2;
                c.column_format = "{0:G}";
                c.data_type = 2;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "fullpartnumber";
                c.column_caption = "Part Number";
                c.column_width = 22;
                c.column_alignment = 0;
                c.column_order = 3;
                c.column_format = "";
                c.data_type = 1;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "internal_vendor";
                c.column_caption = "Internal #";
                c.column_width = 11;
                c.column_alignment = 0;
                c.column_order = 4;
                c.column_format = "";
                c.data_type = 1;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "manufacturer";
                c.column_caption = "MFG";
                c.column_width = 10;
                c.column_alignment = 0;
                c.column_order = 5;
                c.column_format = "";
                c.data_type = 1;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "datecode_purchase";
                c.column_caption = "D/C";
                c.column_width = 6;
                c.column_alignment = 0;
                c.column_order = 6;
                c.column_format = "";
                c.data_type = 1;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "unit_cost";
                c.column_caption = "Price";
                c.column_width = 8;
                c.column_alignment = 1;
                c.column_order = 7;
                c.column_format = "CURRENCY6";
                c.data_type = 4;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "total_cost";
                c.column_caption = "Total";
                c.column_width = 10;
                c.column_alignment = 1;
                c.column_order = 8;
                c.column_format = "CURRENCY6";
                c.data_type = 4;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
            }
        }
        private void UpdatePrintTemplatesSales(ContextRz context)
        {
            //Print Templates Sales
            ArrayList a = context.SelectScalarArray("select unique_id from printheader where ordertype = 'sales'");
            foreach (string s in a)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                string id = context.SelectScalarString("select unique_id from n_template where template_name = '" + s + "'");
                if (Tools.Strings.StrExt(id))
                {
                    context.Execute("delete from n_template where unique_id = '" + id + "'");
                    context.Execute("delete from n_column where the_n_template_uid = '" + id + "'");
                }
                n_template t = CreateTemplate(context, s);
                n_column c = new n_column();
                c.field_name = "ship_date_due";
                c.column_caption = "Ship Date";
                c.column_width = 8;
                c.column_alignment = 2;
                c.column_order = 0;
                c.column_format = "{0:d}";
                c.data_type = 5;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "shipvia_invoice";
                c.column_caption = "ShipVia";
                c.column_width = 13;
                c.column_alignment = 0;
                c.column_order = 1;
                c.column_format = "";
                c.data_type = 1;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "quantity";
                c.column_caption = "Quantity";
                c.column_width = 7;
                c.column_alignment = 1;
                c.column_order = 2;
                c.column_format = "{0:G}";
                c.data_type = 2;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "fullpartnumber";
                c.column_caption = "Part Number";
                c.column_width = 24;
                c.column_alignment = 0;
                c.column_order = 3;
                c.column_format = "";
                c.data_type = 1;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "internal_customer";
                c.column_caption = "Internal #";
                c.column_width = 12;
                c.column_alignment = 0;
                c.column_order = 4;
                c.column_format = "";
                c.data_type = 1;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "manufacturer";
                c.column_caption = "MFG";
                c.column_width = 9;
                c.column_alignment = 0;
                c.column_order = 5;
                c.column_format = "";
                c.data_type = 1;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "datecode";
                c.column_caption = "D/C";
                c.column_width = 7;
                c.column_alignment = 0;
                c.column_order = 6;
                c.column_format = "";
                c.data_type = 1;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "unit_price";
                c.column_caption = "Price";
                c.column_width = 9;
                c.column_alignment = 1;
                c.column_order = 7;
                c.column_format = "CURRENCY6";
                c.data_type = 4;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
                c = new n_column();
                c.field_name = "total_price";
                c.column_caption = "Total";
                c.column_width = 9;
                c.column_alignment = 1;
                c.column_order = 8;
                c.column_format = "CURRENCY6";
                c.data_type = 4;
                c.the_n_template_uid = t.unique_id;
                c.Insert(context);
            }
        }
        private void UpdateARAP(ContextRz context)
        {
            //Ship Screen Receive
            string id = context.SelectScalarString("select unique_id from n_template where template_name = 'arap_order_lines2'");
            if (Tools.Strings.StrExt(id))
            {
                context.Execute("delete from n_template where unique_id = '" + id + "'");
                context.Execute("delete from n_column where the_n_template_uid = '" + id + "'");
            }
            n_template t = CreateTemplate(context, "arap_order_lines2");
            n_column c = new n_column();
            c.field_name = "quantity";
            c.column_caption = "Quantity";
            c.column_width = 9;
            c.column_alignment = 1;
            c.column_order = 0;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "fullpartnumber";
            c.column_caption = "Part Number";
            c.column_width = 20;
            c.column_alignment = 0;
            c.column_order = 1;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "internal_customer";
            c.column_caption = "Internal #";
            c.column_width = 15;
            c.column_alignment = 0;
            c.column_order = 2;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "manufacturer";
            c.column_caption = "MFG";
            c.column_width = 16;
            c.column_alignment = 0;
            c.column_order = 3;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "datecode";
            c.column_caption = "D/C";
            c.column_width = 7;
            c.column_alignment = 0;
            c.column_order = 4;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "unit_cost";
            c.column_caption = "Cost";
            c.column_width = 8;
            c.column_alignment = 1;
            c.column_order = 5;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "unit_price";
            c.column_caption = "Price";
            c.column_width = 10;
            c.column_alignment = 1;
            c.column_order = 6;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "total_price";
            c.column_caption = "Total";
            c.column_width = 12;
            c.column_alignment = 1;
            c.column_order = 7;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
        }
        private void UpdateShipScreenReceive(ContextRz context)
        {
            //Ship Screen Receive
            string id = context.SelectScalarString("select unique_id from n_template where template_name = 'LinesReceiving'");
            if (Tools.Strings.StrExt(id))
            {
                context.Execute("delete from n_template where unique_id = '" + id + "'");
                context.Execute("delete from n_column where the_n_template_uid = '" + id + "'");
            }
            n_template t = CreateTemplate(context, "LinesReceiving");
            n_column c = new n_column();
            c.field_name = "receive_date_due";
            c.column_caption = "Date Due";
            c.column_width = 11;
            c.column_alignment = 2;
            c.column_order = 0;
            c.column_format = "{0:d}";
            c.data_type = 5;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "ordernumber_purchase";
            c.column_caption = "PO #";
            c.column_width = 8;
            c.column_alignment = 0;
            c.column_order = 1;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "ordernumber_rma";
            c.column_caption = "RMA #";
            c.column_width = 8;
            c.column_alignment = 0;
            c.column_order = 2;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "ordernumber_service";
            c.column_caption = "Service #";
            c.column_width = 8;
            c.column_alignment = 0;
            c.column_order = 3;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity";
            c.column_caption = "Qty";
            c.column_width = 8;
            c.column_alignment = 1;
            c.column_order = 4;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "fullpartnumber";
            c.column_caption = "Part Number";
            c.column_width = 20;
            c.column_alignment = 0;
            c.column_order = 5;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "vendor_name";
            c.column_caption = "Vendor";
            c.column_width = 34;
            c.column_alignment = 0;
            c.column_order = 6;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
        }
        private void UpdateShipScreenShipping(ContextRz context)
        {
            //Ship Screen Shipping
            string id = context.SelectScalarString("select unique_id from n_template where template_name = 'LinesShipping'");
            if (Tools.Strings.StrExt(id))
            {
                context.Execute("delete from n_template where unique_id = '" + id + "'");
                context.Execute("delete from n_column where the_n_template_uid = '" + id + "'");
            }
            n_template t = CreateTemplate(context, "LinesShipping");
            n_column c = new n_column();
            c.field_name = "ship_date_due";
            c.column_caption = "Ship Date";
            c.column_width = 12;
            c.column_alignment = 2;
            c.column_order = 0;
            c.column_format = "{0:d}";
            c.data_type = 5;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "ordernumber_sales";
            c.column_caption = "Sales #";
            c.column_width = 8;
            c.column_alignment = 0;
            c.column_order = 1;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "ordernumber_vendrma";
            c.column_caption = "VendRMA #";
            c.column_width = 9;
            c.column_alignment = 0;
            c.column_order = 2;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "ordernumber_service";
            c.column_caption = "Service #";
            c.column_width = 8;
            c.column_alignment = 0;
            c.column_order = 3;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity";
            c.column_caption = "Qty";
            c.column_width = 8;
            c.column_alignment = 1;
            c.column_order = 4;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "fullpartnumber";
            c.column_caption = "Part Number";
            c.column_width = 23;
            c.column_alignment = 0;
            c.column_order = 5;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "customer_name";
            c.column_caption = "Customer";
            c.column_width = 29;
            c.column_alignment = 0;
            c.column_order = 6;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
        }
        private void UpdateSalesSearch(ContextRz context)
        {
            //PartSearch Sales Tab
            string id = context.SelectScalarString("select unique_id from n_template where template_name = 'SALESSEARCHnew'");
            if (Tools.Strings.StrExt(id))
            {
                context.Execute("delete from n_template where unique_id = '" + id + "'");
                context.Execute("delete from n_column where the_n_template_uid = '" + id + "'");
            }
            n_template t = CreateTemplate(context, "SALESSEARCHnew");
            n_column c = new n_column();
            c.field_name = "orderdate_sales";
            c.column_caption = "Sales Date";
            c.column_width = 5;
            c.column_alignment = 2;
            c.column_order = 0;
            c.column_format = "{0:d}";
            c.data_type = 5;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "ordernumber_sales";
            c.column_caption = "Sales #";
            c.column_width = 5;
            c.column_alignment = 0;
            c.column_order = 1;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "orderdate_invoice";
            c.column_caption = "Invoice Date";
            c.column_width = 5;
            c.column_alignment = 2;
            c.column_order = 2;
            c.column_format = "{0:d}";
            c.data_type = 5;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "ordernumber_invoice";
            c.column_caption = "Invoice #";
            c.column_width = 5;
            c.column_alignment = 0;
            c.column_order = 3;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "fullpartnumber";
            c.column_caption = "Part Number";
            c.column_width = 10;
            c.column_alignment = 0;
            c.column_order = 4;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "manufacturer";
            c.column_caption = "MFG";
            c.column_width = 5;
            c.column_alignment = 0;
            c.column_order = 5;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "datecode";
            c.column_caption = "D/C";
            c.column_width = 4;
            c.column_alignment = 0;
            c.column_order = 6;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "internal_customer";
            c.column_caption = "Internal";
            c.column_width = 10;
            c.column_alignment = 0;
            c.column_order = 7;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity";
            c.column_caption = "Quantity";
            c.column_width = 5;
            c.column_alignment = 1;
            c.column_order = 8;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity_unpacked";
            c.column_caption = "UnPacked";
            c.column_width = 5;
            c.column_alignment = 1;
            c.column_order = 9;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity_packed";
            c.column_caption = "Packed";
            c.column_width = 5;
            c.column_alignment = 1;
            c.column_order = 10;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "unit_cost";
            c.column_caption = "Cost";
            c.column_width = 5;
            c.column_alignment = 1;
            c.column_order = 11;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "unit_price";
            c.column_caption = "Price";
            c.column_width = 4;
            c.column_alignment = 1;
            c.column_order = 12;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "customer_name";
            c.column_caption = "Customer";
            c.column_width = 19;
            c.column_alignment = 0;
            c.column_order = 13;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "status";
            c.column_caption = "Status";
            c.column_width = 6;
            c.column_alignment = 0;
            c.column_order = 14;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
        }
        private void UpdateBuySearch(ContextRz context)
        {
            //PartSearch Purchase Tab
            string id = context.SelectScalarString("select unique_id from n_template where template_name = 'BUYSEARCHnew'");
            if (Tools.Strings.StrExt(id))
            {
                context.Execute("delete from n_template where unique_id = '" + id + "'");
                context.Execute("delete from n_column where the_n_template_uid = '" + id + "'");
            }
            n_template t = CreateTemplate(context, "BUYSEARCHnew");
            n_column c = new n_column();
            c.field_name = "orderdate_purchase";
            c.column_caption = "Purchase Date";
            c.column_width = 6;
            c.column_alignment = 2;
            c.column_order = 0;
            c.column_format = "{0:d}";
            c.data_type = 5;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "ordernumber_purchase";
            c.column_caption = "Purchase #";
            c.column_width = 5;
            c.column_alignment = 0;
            c.column_order = 1;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "fullpartnumber";
            c.column_caption = "Part Number";
            c.column_width = 15;
            c.column_alignment = 0;
            c.column_order = 2;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "internal_vendor";
            c.column_caption = "Internal";
            c.column_width = 10;
            c.column_alignment = 0;
            c.column_order = 3;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "manufacturer";
            c.column_caption = "MFG";
            c.column_width = 9;
            c.column_alignment = 0;
            c.column_order = 4;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "datecode_purchase";
            c.column_caption = "D/C";
            c.column_width = 4;
            c.column_alignment = 0;
            c.column_order = 5;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity";
            c.column_caption = "Quantity";
            c.column_width = 5;
            c.column_alignment = 1;
            c.column_order = 6;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity_unpacked";
            c.column_caption = "UnPacked";
            c.column_width = 5;
            c.column_alignment = 1;
            c.column_order = 7;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "unit_cost";
            c.column_caption = "Price";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 8;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "total_cost";
            c.column_caption = "Total";
            c.column_width = 7;
            c.column_alignment = 1;
            c.column_order = 9;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "status";
            c.column_caption = "Status";
            c.column_width = 6;
            c.column_alignment = 0;
            c.column_order = 10;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "vendor_name";
            c.column_caption = "Vendor";
            c.column_width = 20;
            c.column_alignment = 0;
            c.column_order = 11;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
        }
        private void UpdateRMASearch(ContextRz context)
        {
            //PartSearch RMA Tab
            string id = context.SelectScalarString("select unique_id from n_template where template_name = 'rmasearchnew'");
            if (Tools.Strings.StrExt(id))
            {
                context.Execute("delete from n_template where unique_id = '" + id + "'");
                context.Execute("delete from n_column where the_n_template_uid = '" + id + "'");
            }
            n_template t = CreateTemplate(context, "rmasearchnew");
            n_column c = new n_column();
            c.field_name = "orderdate_rma";
            c.column_caption = "RMA Date";
            c.column_width = 6;
            c.column_alignment = 2;
            c.column_order = 0;
            c.column_format = "{0:d}";
            c.data_type = 5;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "ordernumber_rma";
            c.column_caption = "RMA #";
            c.column_width = 5;
            c.column_alignment = 0;
            c.column_order = 1;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "fullpartnumber";
            c.column_caption = "Part Number";
            c.column_width = 16;
            c.column_alignment = 0;
            c.column_order = 2;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "internal_customer";
            c.column_caption = "Internal #";
            c.column_width = 11;
            c.column_alignment = 0;
            c.column_order = 3;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "manufacturer";
            c.column_caption = "MFG";
            c.column_width = 8;
            c.column_alignment = 0;
            c.column_order = 4;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "datecode";
            c.column_caption = "D/C";
            c.column_width = 5;
            c.column_alignment = 0;
            c.column_order = 5;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity";
            c.column_caption = "Quantity";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 6;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity_unpacked_rma";
            c.column_caption = "UnPacked";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 7;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "unit_price_rma";
            c.column_caption = "Price";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 8;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "total_price_rma";
            c.column_caption = "Total";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 9;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "status";
            c.column_caption = "Status";
            c.column_width = 7;
            c.column_alignment = 0;
            c.column_order = 10;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "customer_name";
            c.column_caption = "Customer";
            c.column_width = 16;
            c.column_alignment = 0;
            c.column_order = 11;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
        }
        private void UpdateVendRMASearch(ContextRz context)
        {
            //PartSearch VendRMA Tab
            string id = context.SelectScalarString("select unique_id from n_template where template_name = 'vendrmasearchnew'");
            if (Tools.Strings.StrExt(id))
            {
                context.Execute("delete from n_template where unique_id = '" + id + "'");
                context.Execute("delete from n_column where the_n_template_uid = '" + id + "'");
            }
            n_template t = CreateTemplate(context, "vendrmasearchnew");
            n_column c = new n_column();
            c.field_name = "orderdate_vendrma";
            c.column_caption = "VRMA Date";
            c.column_width = 6;
            c.column_alignment = 2;
            c.column_order = 0;
            c.column_format = "{0:d}";
            c.data_type = 5;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "ordernumber_vendrma";
            c.column_caption = "VRMA #";
            c.column_width = 5;
            c.column_alignment = 0;
            c.column_order = 1;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "fullpartnumber";
            c.column_caption = "Part Number";
            c.column_width = 16;
            c.column_alignment = 0;
            c.column_order = 2;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "internal_vendor";
            c.column_caption = "Internal #";
            c.column_width = 11;
            c.column_alignment = 0;
            c.column_order = 3;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "manufacturer";
            c.column_caption = "MFG";
            c.column_width = 8;
            c.column_alignment = 0;
            c.column_order = 4;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "datecode";
            c.column_caption = "D/C";
            c.column_width = 5;
            c.column_alignment = 0;
            c.column_order = 5;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity";
            c.column_caption = "Quantity";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 6;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity_packed_vendrma";
            c.column_caption = "Packed";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 7;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "unit_price_vendrma";
            c.column_caption = "Price";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 8;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "total_price_vendrma";
            c.column_caption = "Total";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 9;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "status";
            c.column_caption = "Status";
            c.column_width = 7;
            c.column_alignment = 0;
            c.column_order = 10;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "vendor_name";
            c.column_caption = "Vendor";
            c.column_width = 16;
            c.column_alignment = 0;
            c.column_order = 11;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
        }
        private void UpdateCompDetailsAll(ContextRz context)
        {
            //Company Details All
            string id = context.SelectScalarString("select unique_id from n_template where template_name = 'COMPANYORDERDETAILS_all'");
            if (Tools.Strings.StrExt(id))
            {
                context.Execute("delete from n_template where unique_id = '" + id + "'");
                context.Execute("delete from n_column where the_n_template_uid = '" + id + "'");
            }
            n_template t = CreateTemplate(context, "COMPANYORDERDETAILS_all");
            n_column c = new n_column();
            c.field_name = "fullpartnumber";
            c.column_caption = "Part Number";
            c.column_width = 17;
            c.column_alignment = 0;
            c.column_order = 0;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "internal_customer";
            c.column_caption = "Internal #";
            c.column_width = 12;
            c.column_alignment = 0;
            c.column_order = 1;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "manufacturer";
            c.column_caption = "MFG";
            c.column_width = 8;
            c.column_alignment = 0;
            c.column_order = 2;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "datecode";
            c.column_caption = "D/C";
            c.column_width = 5;
            c.column_alignment = 0;
            c.column_order = 3;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity";
            c.column_caption = "Quantity";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 4;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity_unpacked";
            c.column_caption = "UnPacked";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 5;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity_packed";
            c.column_caption = "Packed";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 6;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "status";
            c.column_caption = "Status";
            c.column_width = 7;
            c.column_alignment = 0;
            c.column_order = 7;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "unit_cost";
            c.column_caption = "Cost";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 8;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "unit_price";
            c.column_caption = "Price";
            c.column_width = 5;
            c.column_alignment = 1;
            c.column_order = 9;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "total_price";
            c.column_caption = "Total";
            c.column_width = 7;
            c.column_alignment = 1;
            c.column_order = 10;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "vendor_name";
            c.column_caption = "Vendor";
            c.column_width = 13;
            c.column_alignment = 0;
            c.column_order = 11;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
        }
        private void UpdateCompDetailsSales(ContextRz context)
        {
            //Company Details Sales
            string id = context.SelectScalarString("select unique_id from n_template where template_name = 'COMPANYORDERDETAILS_sales'");
            if (Tools.Strings.StrExt(id))
            {
                context.Execute("delete from n_template where unique_id = '" + id + "'");
                context.Execute("delete from n_column where the_n_template_uid = '" + id + "'");
            }
            n_template t = CreateTemplate(context, "COMPANYORDERDETAILS_sales");
            n_column c = new n_column();
            c.field_name = "orderdate_sales";
            c.column_caption = "Date";
            c.column_width = 7;
            c.column_alignment = 2;
            c.column_order = 0;
            c.column_format = "{0:d}";
            c.data_type = 5;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "ordernumber_sales";
            c.column_caption = "Order";
            c.column_width = 5;
            c.column_alignment = 0;
            c.column_order = 1;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "fullpartnumber";
            c.column_caption = "Part Number";
            c.column_width = 15;
            c.column_alignment = 0;
            c.column_order = 2;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "internal_customer";
            c.column_caption = "Internal #";
            c.column_width = 10;
            c.column_alignment = 0;
            c.column_order = 3;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "manufacturer";
            c.column_caption = "MFG";
            c.column_width = 10;
            c.column_alignment = 0;
            c.column_order = 4;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "datecode";
            c.column_caption = "D/C";
            c.column_width = 4;
            c.column_alignment = 0;
            c.column_order = 5;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity";
            c.column_caption = "Quantity";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 6;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity_unpacked";
            c.column_caption = "UnPacked";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 7;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity_packed";
            c.column_caption = "Packed";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 8;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "unit_cost";
            c.column_caption = "Cost";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 9;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "unit_price";
            c.column_caption = "Price";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 10;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "total_price";
            c.column_caption = "Total";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 11;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "vendor_name";
            c.column_caption = "Vendor";
            c.column_width = 11;
            c.column_alignment = 0;
            c.column_order = 12;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
        }
        private void UpdateCompDetailsPurchase(ContextRz context)
        {
            //Company Details Purchase
            string id = context.SelectScalarString("select unique_id from n_template where template_name = 'COMPANYORDERDETAILS_purchase'");
            if (Tools.Strings.StrExt(id))
            {
                context.Execute("delete from n_template where unique_id = '" + id + "'");
                context.Execute("delete from n_column where the_n_template_uid = '" + id + "'");
            }
            n_template t = CreateTemplate(context, "COMPANYORDERDETAILS_purchase");
            n_column c = new n_column();
            c.field_name = "orderdate_purchase";
            c.column_caption = "Date";
            c.column_width = 7;
            c.column_alignment = 2;
            c.column_order = 0;
            c.column_format = "{0:d}";
            c.data_type = 5;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "ordernumber_purchase";
            c.column_caption = "Order";
            c.column_width = 6;
            c.column_alignment = 0;
            c.column_order = 1;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "fullpartnumber";
            c.column_caption = "Part Number";
            c.column_width = 17;
            c.column_alignment = 0;
            c.column_order = 2;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "internal_vendor";
            c.column_caption = "Internal #";
            c.column_width = 11;
            c.column_alignment = 0;
            c.column_order = 3;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "manufacturer";
            c.column_caption = "MFG";
            c.column_width = 8;
            c.column_alignment = 0;
            c.column_order = 4;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "datecode_purchase";
            c.column_caption = "D/C";
            c.column_width = 5;
            c.column_alignment = 0;
            c.column_order = 5;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity";
            c.column_caption = "Quantity";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 6;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity_unpacked";
            c.column_caption = "UnPacked";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 7;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "unit_cost";
            c.column_caption = "Price";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 8;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "total_cost";
            c.column_caption = "Total";
            c.column_width = 7;
            c.column_alignment = 1;
            c.column_order = 9;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "customer_name";
            c.column_caption = "Customer";
            c.column_width = 19;
            c.column_alignment = 0;
            c.column_order = 10;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
        }
        private void UpdateCompDetailsInvoice(ContextRz context)
        {
            //Company Details Invoice
            string id = context.SelectScalarString("select unique_id from n_template where template_name = 'COMPANYORDERDETAILS_invoice'");
            if (Tools.Strings.StrExt(id))
            {
                context.Execute("delete from n_template where unique_id = '" + id + "'");
                context.Execute("delete from n_column where the_n_template_uid = '" + id + "'");
            }
            n_template t = CreateTemplate(context, "COMPANYORDERDETAILS_invoice");
            n_column c = new n_column();
            c.field_name = "orderdate_invoice";
            c.column_caption = "Date";
            c.column_width = 7;
            c.column_alignment = 2;
            c.column_order = 0;
            c.column_format = "{0:d}";
            c.data_type = 5;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "ordernumber_invoice";
            c.column_caption = "Order";
            c.column_width = 6;
            c.column_alignment = 0;
            c.column_order = 1;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "fullpartnumber";
            c.column_caption = "Part Number";
            c.column_width = 19;
            c.column_alignment = 0;
            c.column_order = 2;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "internal_customer";
            c.column_caption = "Internal #";
            c.column_width = 10;
            c.column_alignment = 0;
            c.column_order = 3;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "manufacturer";
            c.column_caption = "MFG";
            c.column_width = 10;
            c.column_alignment = 0;
            c.column_order = 4;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "datecode";
            c.column_caption = "D/C";
            c.column_width = 4;
            c.column_alignment = 0;
            c.column_order = 5;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity";
            c.column_caption = "Quantity";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 6;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity_packed";
            c.column_caption = "Packed";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 7;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "unit_price";
            c.column_caption = "Price";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 8;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "total_price";
            c.column_caption = "Total";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 9;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "vendor_name";
            c.column_caption = "Vendor";
            c.column_width = 18;
            c.column_alignment = 0;
            c.column_order = 10;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
        }
        private void UpdateCompDetailsRMA(ContextRz context)
        {
            //Company Details RMA
            string id = context.SelectScalarString("select unique_id from n_template where template_name = 'COMPANYORDERDETAILS_rma'");
            if (Tools.Strings.StrExt(id))
            {
                context.Execute("delete from n_template where unique_id = '" + id + "'");
                context.Execute("delete from n_column where the_n_template_uid = '" + id + "'");
            }
            n_template t = CreateTemplate(context, "COMPANYORDERDETAILS_rma");
            n_column c = new n_column();
            c.field_name = "orderdate_rma";
            c.column_caption = "Date";
            c.column_width = 7;
            c.column_alignment = 2;
            c.column_order = 0;
            c.column_format = "{0:d}";
            c.data_type = 5;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "ordernumber_rma";
            c.column_caption = "Order";
            c.column_width = 6;
            c.column_alignment = 0;
            c.column_order = 1;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "fullpartnumber";
            c.column_caption = "Part Number";
            c.column_width = 16;
            c.column_alignment = 0;
            c.column_order = 2;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "internal_customer";
            c.column_caption = "Internal #";
            c.column_width = 11;
            c.column_alignment = 0;
            c.column_order = 3;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "manufacturer";
            c.column_caption = "MFG";
            c.column_width = 8;
            c.column_alignment = 0;
            c.column_order = 4;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "datecode";
            c.column_caption = "D/C";
            c.column_width = 5;
            c.column_alignment = 0;
            c.column_order = 5;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity";
            c.column_caption = "Quantity";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 6;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity_unpacked_rma";
            c.column_caption = "UnPacked";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 7;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "unit_price_rma";
            c.column_caption = "Price";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 8;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "total_price_rma";
            c.column_caption = "Total";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 9;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "vendor_name";
            c.column_caption = "Vendor";
            c.column_width = 20;
            c.column_alignment = 0;
            c.column_order = 10;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
        }
        private void UpdateCompDetailsVRMA(ContextRz context)
        {
            //Company Details VRMA
            string id = context.SelectScalarString("select unique_id from n_template where template_name = 'COMPANYORDERDETAILS_vendrma'");
            if (Tools.Strings.StrExt(id))
            {
                context.Execute("delete from n_template where unique_id = '" + id + "'");
                context.Execute("delete from n_column where the_n_template_uid = '" + id + "'");
            }
            n_template t = CreateTemplate(context, "COMPANYORDERDETAILS_vendrma");
            n_column c = new n_column();
            c.field_name = "orderdate_vendrma";
            c.column_caption = "Date";
            c.column_width = 8;
            c.column_alignment = 2;
            c.column_order = 0;
            c.column_format = "{0:d}";
            c.data_type = 5;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "ordernumber_vendrma";
            c.column_caption = "Order";
            c.column_width = 6;
            c.column_alignment = 0;
            c.column_order = 1;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "fullpartnumber";
            c.column_caption = "Part Number";
            c.column_width = 16;
            c.column_alignment = 0;
            c.column_order = 2;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "internal_vendor";
            c.column_caption = "Internal #";
            c.column_width = 11;
            c.column_alignment = 0;
            c.column_order = 3;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "manufacturer";
            c.column_caption = "MFG";
            c.column_width = 8;
            c.column_alignment = 0;
            c.column_order = 4;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "datecode";
            c.column_caption = "D/C";
            c.column_width = 5;
            c.column_alignment = 0;
            c.column_order = 5;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity";
            c.column_caption = "Quantity";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 6;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity_packed_vendrma";
            c.column_caption = "Packed";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 7;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "unit_price_vendrma";
            c.column_caption = "Price";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 8;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "total_price_vendrma";
            c.column_caption = "Total";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 9;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "customer_name";
            c.column_caption = "Customer";
            c.column_width = 20;
            c.column_alignment = 0;
            c.column_order = 10;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
        }
        private void UpdateCompDetailsService(ContextRz context)
        {
            //Company Details Service
            string id = context.SelectScalarString("select unique_id from n_template where template_name = 'COMPANYORDERDETAILS_service'");
            if (Tools.Strings.StrExt(id))
            {
                context.Execute("delete from n_template where unique_id = '" + id + "'");
                context.Execute("delete from n_column where the_n_template_uid = '" + id + "'");
            }
            n_template t = CreateTemplate(context, "COMPANYORDERDETAILS_service");
            n_column c = new n_column();
            c.field_name = "orderdate_service";
            c.column_caption = "Date";
            c.column_width = 7;
            c.column_alignment = 2;
            c.column_order = 0;
            c.column_format = "{0:d}";
            c.data_type = 5;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "ordernumber_service";
            c.column_caption = "Order";
            c.column_width = 5;
            c.column_alignment = 0;
            c.column_order = 1;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "fullpartnumber";
            c.column_caption = "Part Number";
            c.column_width = 18;
            c.column_alignment = 0;
            c.column_order = 2;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "internal_customer";
            c.column_caption = "Internal #";
            c.column_width = 12;
            c.column_alignment = 0;
            c.column_order = 3;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "manufacturer";
            c.column_caption = "MFG";
            c.column_width = 7;
            c.column_alignment = 0;
            c.column_order = 4;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "datecode";
            c.column_caption = "D/C";
            c.column_width = 5;
            c.column_alignment = 0;
            c.column_order = 5;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity";
            c.column_caption = "Quantity";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 6;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity_packed_service";
            c.column_caption = "Packed";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 7;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity_unpacked_service";
            c.column_caption = "UnPacked";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 8;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "vendor_name";
            c.column_caption = "Vendor";
            c.column_width = 14;
            c.column_alignment = 0;
            c.column_order = 9;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "customer_name";
            c.column_caption = "Customer";
            c.column_width = 12;
            c.column_alignment = 0;
            c.column_order = 10;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
        }
        private void UpdateOrderScreenInvoice(ContextRz context)
        {
            //Order Screen Invoice
            string id = context.SelectScalarString("select unique_id from n_template where template_name = 'ORDERDETAILInvoice'");
            if (Tools.Strings.StrExt(id))
            {
                context.Execute("delete from n_template where unique_id = '" + id + "'");
                context.Execute("delete from n_column where the_n_template_uid = '" + id + "'");
            }
            n_template t = CreateTemplate(context, "ORDERDETAILInvoice");
            n_column c = new n_column();
            c.field_name = "linecode_invoice";
            c.column_caption = "Line";
            c.column_width = 3;
            c.column_alignment = 1;
            c.column_order = 0;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "status";
            c.column_caption = "Status";
            c.column_width = 11;
            c.column_alignment = 0;
            c.column_order = 1;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "fullpartnumber";
            c.column_caption = "Part Number";
            c.column_width = 18;
            c.column_alignment = 0;
            c.column_order = 2;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "internal_customer";
            c.column_caption = "Internal #";
            c.column_width = 12;
            c.column_alignment = 0;
            c.column_order = 3;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "manufacturer";
            c.column_caption = "MFG";
            c.column_width = 10;
            c.column_alignment = 0;
            c.column_order = 4;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "datecode";
            c.column_caption = "D/C";
            c.column_width = 4;
            c.column_alignment = 0;
            c.column_order = 5;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity";
            c.column_caption = "Quantity";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 6;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity_packed";
            c.column_caption = "Packed";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 7;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "unit_price";
            c.column_caption = "Price";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 8;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "total_price";
            c.column_caption = "Total";
            c.column_width = 7;
            c.column_alignment = 1;
            c.column_order = 9;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "vendor_name";
            c.column_caption = "Vendor";
            c.column_width = 15;
            c.column_alignment = 0;
            c.column_order = 10;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
        }
        private void UpdateOrderScreenPurchase(ContextRz context)
        {
            //Order Screen Invoice
            string id = context.SelectScalarString("select unique_id from n_template where template_name = 'ORDERDETAILPurchase'");
            if (Tools.Strings.StrExt(id))
            {
                context.Execute("delete from n_template where unique_id = '" + id + "'");
                context.Execute("delete from n_column where the_n_template_uid = '" + id + "'");
            }
            n_template t = CreateTemplate(context, "ORDERDETAILPurchase");
            n_column c = new n_column();
            c.field_name = "linecode_purchase";
            c.column_caption = "Line";
            c.column_width = 3;
            c.column_alignment = 1;
            c.column_order = 0;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "status";
            c.column_caption = "Status";
            c.column_width = 9;
            c.column_alignment = 0;
            c.column_order = 1;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "fullpartnumber";
            c.column_caption = "Part Number";
            c.column_width = 16;
            c.column_alignment = 0;
            c.column_order = 2;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "internal_vendor";
            c.column_caption = "Internal #";
            c.column_width = 11;
            c.column_alignment = 0;
            c.column_order = 3;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "manufacturer";
            c.column_caption = "MFG";
            c.column_width = 12;
            c.column_alignment = 0;
            c.column_order = 4;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "datecode_purchase";
            c.column_caption = "D/C";
            c.column_width = 4;
            c.column_alignment = 0;
            c.column_order = 5;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity";
            c.column_caption = "Quantity";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 6;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity_unpacked";
            c.column_caption = "UnPacked";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 7;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "unit_cost";
            c.column_caption = "Price";
            c.column_width = 5;
            c.column_alignment = 1;
            c.column_order = 8;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "total_cost";
            c.column_caption = "Total";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 9;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "customer_name";
            c.column_caption = "Customer";
            c.column_width = 20;
            c.column_alignment = 0;
            c.column_order = 10;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
        }
        private void UpdateOrderScreenRMA(ContextRz context)
        {
            //Order Screen RMA
            string id = context.SelectScalarString("select unique_id from n_template where template_name = 'ORDERDETAILRMA'");
            if (Tools.Strings.StrExt(id))
            {
                context.Execute("delete from n_template where unique_id = '" + id + "'");
                context.Execute("delete from n_column where the_n_template_uid = '" + id + "'");
            }
            n_template t = CreateTemplate(context, "ORDERDETAILRMA");
            n_column c = new n_column();
            c.field_name = "linecode_rma";
            c.column_caption = "Line";
            c.column_width = 4;
            c.column_alignment = 1;
            c.column_order = 0;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "status";
            c.column_caption = "Status";
            c.column_width = 9;
            c.column_alignment = 0;
            c.column_order = 1;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "fullpartnumber";
            c.column_caption = "Part Number";
            c.column_width = 16;
            c.column_alignment = 0;
            c.column_order = 2;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "internal_customer";
            c.column_caption = "Internal #";
            c.column_width = 12;
            c.column_alignment = 0;
            c.column_order = 3;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "manufacturer";
            c.column_caption = "MFG";
            c.column_width = 12;
            c.column_alignment = 0;
            c.column_order = 4;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "datecode";
            c.column_caption = "D/C";
            c.column_width = 4;
            c.column_alignment = 0;
            c.column_order = 5;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity";
            c.column_caption = "Quantity";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 6;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity_unpacked_rma";
            c.column_caption = "UnPacked";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 7;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "unit_price_rma";
            c.column_caption = "Price";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 8;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "total_price_rma";
            c.column_caption = "Total";
            c.column_width = 7;
            c.column_alignment = 1;
            c.column_order = 9;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "vendor_name";
            c.column_caption = "Vendor";
            c.column_width = 16;
            c.column_alignment = 0;
            c.column_order = 10;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
        }
        private void UpdateOrderScreenVendRMA(ContextRz context)
        {
            //Order Screen VendRMA
            string id = context.SelectScalarString("select unique_id from n_template where template_name = 'ORDERDETAILVENDRMA'");
            if (Tools.Strings.StrExt(id))
            {
                context.Execute("delete from n_template where unique_id = '" + id + "'");
                context.Execute("delete from n_column where the_n_template_uid = '" + id + "'");
            }
            n_template t = CreateTemplate(context, "ORDERDETAILVENDRMA");
            n_column c = new n_column();
            c.field_name = "linecode_vendrma";
            c.column_caption = "Line";
            c.column_width = 4;
            c.column_alignment = 1;
            c.column_order = 0;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "status";
            c.column_caption = "Status";
            c.column_width = 9;
            c.column_alignment = 0;
            c.column_order = 1;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "fullpartnumber";
            c.column_caption = "Part Number";
            c.column_width = 17;
            c.column_alignment = 0;
            c.column_order = 2;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "internal_vendor";
            c.column_caption = "Internal #";
            c.column_width = 15;
            c.column_alignment = 0;
            c.column_order = 3;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "manufacturer";
            c.column_caption = "MFG";
            c.column_width = 12;
            c.column_alignment = 0;
            c.column_order = 4;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "datecode";
            c.column_caption = "D/C";
            c.column_width = 4;
            c.column_alignment = 0;
            c.column_order = 5;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity";
            c.column_caption = "Quantity";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 6;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity_packed_vendrma";
            c.column_caption = "Packed";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 7;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "unit_price_vendrma";
            c.column_caption = "Price";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 8;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "total_price_vendrma";
            c.column_caption = "Total";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 9;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "customer_name";
            c.column_caption = "Customer";
            c.column_width = 12;
            c.column_alignment = 0;
            c.column_order = 10;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
        }
        private void UpdateOrderScreenSales(ContextRz context)
        {
            //Order Screen Sales
            string id = context.SelectScalarString("select unique_id from n_template where template_name = 'ORDERDETAILsales'");
            if (Tools.Strings.StrExt(id))
            {
                context.Execute("delete from n_template where unique_id = '" + id + "'");
                context.Execute("delete from n_column where the_n_template_uid = '" + id + "'");
            }
            n_template t = CreateTemplate(context, "ORDERDETAILsales");
            n_column c = new n_column();
            c.field_name = "linecode_sales";
            c.column_caption = "Line";
            c.column_width = 4;
            c.column_alignment = 1;
            c.column_order = 0;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "status";
            c.column_caption = "Status";
            c.column_width = 8;
            c.column_alignment = 0;
            c.column_order = 1;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "ship_date_due";
            c.column_caption = "Ship Date";
            c.column_width = 5;
            c.column_alignment = 2;
            c.column_order = 2;
            c.column_format = "{0:d}";
            c.data_type = 5;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "fullpartnumber";
            c.column_caption = "Part Number";
            c.column_width = 13;
            c.column_alignment = 0;
            c.column_order = 3;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "internal_customer";
            c.column_caption = "Internal #";
            c.column_width = 9;
            c.column_alignment = 0;
            c.column_order = 4;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "manufacturer";
            c.column_caption = "MFG";
            c.column_width = 8;
            c.column_alignment = 0;
            c.column_order = 5;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "datecode";
            c.column_caption = "D/C";
            c.column_width = 4;
            c.column_alignment = 0;
            c.column_order = 6;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity";
            c.column_caption = "Quantity";
            c.column_width = 5;
            c.column_alignment = 1;
            c.column_order = 7;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity_unpacked";
            c.column_caption = "UnPacked";
            c.column_width = 5;
            c.column_alignment = 1;
            c.column_order = 8;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity_packed";
            c.column_caption = "Packed";
            c.column_width = 5;
            c.column_alignment = 1;
            c.column_order = 9;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "unit_cost";
            c.column_caption = "Cost";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 10;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "unit_price";
            c.column_caption = "Price";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 11;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "total_price";
            c.column_caption = "Total";
            c.column_width = 6;
            c.column_alignment = 1;
            c.column_order = 12;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "vendor_name";
            c.column_caption = "Vendor";
            c.column_width = 13;
            c.column_alignment = 0;
            c.column_order = 13;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
        }
        private void UpdateOrderScreenService(ContextRz context)
        {
            //Order Screen Service
            string id = context.SelectScalarString("select unique_id from n_template where template_name = 'ORDERDETAILservice'");
            if (Tools.Strings.StrExt(id))
            {
                context.Execute("delete from n_template where unique_id = '" + id + "'");
                context.Execute("delete from n_column where the_n_template_uid = '" + id + "'");
            }
            n_template t = CreateTemplate(context, "ORDERDETAILservice");
            n_column c = new n_column();
            c.field_name = "linecode_service";
            c.column_caption = "Line";
            c.column_width = 4;
            c.column_alignment = 1;
            c.column_order = 0;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "status";
            c.column_caption = "Status";
            c.column_width = 9;
            c.column_alignment = 0;
            c.column_order = 1;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "fullpartnumber";
            c.column_caption = "Part Number";
            c.column_width = 14;
            c.column_alignment = 0;
            c.column_order = 2;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "internal_customer";
            c.column_caption = "Internal #";
            c.column_width = 12;
            c.column_alignment = 0;
            c.column_order = 3;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "manufacturer";
            c.column_caption = "MFG";
            c.column_width = 10;
            c.column_alignment = 0;
            c.column_order = 4;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "datecode";
            c.column_caption = "D/C";
            c.column_width = 5;
            c.column_alignment = 0;
            c.column_order = 5;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity";
            c.column_caption = "Quantity";
            c.column_width = 5;
            c.column_alignment = 1;
            c.column_order = 6;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity_unpacked_service";
            c.column_caption = "UnPacked";
            c.column_width = 5;
            c.column_alignment = 1;
            c.column_order = 7;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "quantity_packed_service";
            c.column_caption = "Packed";
            c.column_width = 5;
            c.column_alignment = 1;
            c.column_order = 8;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "unit_cost";
            c.column_caption = "Cost";
            c.column_width = 5;
            c.column_alignment = 1;
            c.column_order = 9;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "unit_price";
            c.column_caption = "Price";
            c.column_width = 5;
            c.column_alignment = 1;
            c.column_order = 10;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "total_price";
            c.column_caption = "Total";
            c.column_width = 5;
            c.column_alignment = 1;
            c.column_order = 11;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "vendor_name";
            c.column_caption = "Vendor";
            c.column_width = 14;
            c.column_alignment = 0;
            c.column_order = 12;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            //Order Screen Service Lines
            id = context.SelectScalarString("select unique_id from n_template where template_name = 'servicelines'");
            if (Tools.Strings.StrExt(id))
            {
                context.Execute("delete from n_template where unique_id = '" + id + "'");
                context.Execute("delete from n_column where the_n_template_uid = '" + id + "'");
            }
            t = CreateTemplate(context, "servicelines");
            c = new n_column();
            c.field_name = "quantity";
            c.column_caption = "Quantity";
            c.column_width = 8;
            c.column_alignment = 1;
            c.column_order = 0;
            c.column_format = "{0:G}";
            c.data_type = 2;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "service_name";
            c.column_caption = "Service";
            c.column_width = 68;
            c.column_alignment = 0;
            c.column_order = 1;
            c.column_format = "";
            c.data_type = 1;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "unit_cost";
            c.column_caption = "Price";
            c.column_width = 11;
            c.column_alignment = 1;
            c.column_order = 2;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
            c = new n_column();
            c.field_name = "total_cost";
            c.column_caption = "Total";
            c.column_width = 11;
            c.column_alignment = 1;
            c.column_order = 3;
            c.column_format = "CURRENCY6";
            c.data_type = 4;
            c.the_n_template_uid = t.unique_id;
            c.Insert(context);
        }
        private n_template CreateTemplate(ContextRz context, string name)
        {
            n_template t = new n_template();
            t.template_name = name;
            t.class_name = "orddet_line";
            t.use_gridlines = true;
            t.Insert(context);
            return t;
        }
        public void ReindexDatabase(ContextRz context)
        {
            try
            {
                ArrayList a = context.SelectScalarArray("select distinct(table_name) from information_schema.tables where table_name not like 'sys%' and table_name <>'dtproperties' and table_type = 'base table' order by table_name asc");
                if (a == null)
                    return;
                if (a.Count <= 0)
                    return;
                foreach (string s in a)
                {
                    if (!Tools.Strings.StrExt(s))
                        continue;
                    context.TheLeader.Comment("Reindexing: " + s);
                    context.Execute("DBCC DBREINDEX('" + s + "',' ',0)");
                }
            }
            catch { }
        }
        private void ReindexOrderTables(ContextRz context)
        {
            try
            {
                ArrayList a = context.SelectScalarArray("select distinct(table_name) from information_schema.tables where table_name not like 'sys%' and table_name <>'dtproperties' and table_type = 'base table' order by table_name asc");
                if (a == null)
                    return;
                if (a.Count <= 0)
                    return;
                foreach (string s in a)
                {
                    if (!Tools.Strings.StrExt(s))
                        continue;
                    if (s.ToLower().StartsWith("ordhed") || s.ToLower().StartsWith("orddet"))
                    {
                        context.TheLeader.Comment("Reindexing: " + s);
                        context.Execute("DBCC DBREINDEX('" + s + "',' ',0)");
                    }
                }
            }
            catch { }
        }
    }
    class FieldSwitch
    {
        public String Table;
        public String FieldOld;
        public String FieldNew;

        public FieldSwitch(String field_old, String field_new)
            : this("", field_old, field_new)
        {

        }
        public FieldSwitch(String table, String field_old, String field_new)
        {
            Table = table;
            FieldOld = field_old;
            FieldNew = field_new;
        }
    }
}
