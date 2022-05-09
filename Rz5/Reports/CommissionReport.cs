using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewMethod;
using Core;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;

namespace Rz5.Reports
{
    public class CommissionReport : Rz5.Report
    {
        //Protected Variables
        protected ReportTotal TotalsTitle;
        protected ReportTotal TotalSales;
        protected ReportTotal TotalFees;
        protected ReportTotal TotalCost;
        protected ReportTotal TotalGP;
        protected ReportTotal TotalNP;
        //KT - Total Paid Column
        protected ReportTotal TotalPaid;
        //KT - Total Commision (All Users)
        protected ReportTotal TotalComm;
        protected ReportTotal TotalBogey;
        protected ReportTotal GrossComm;
        protected ReportTotal NetComm;
        protected ReportTotal TotInvoiceCredits;
        //KT Payroll Deductions
        public DateTime StartDate;
        public DateTime EndDate;
        private DataTable dtPayrollDeductions = new DataTable();
        protected ReportTotal TotalPayrollDeductions;
        //protected double Bogey;
        //KT variable to hold Invoice Credits
        public double TotalInvoiceCredits;



        public CommissionReport(ContextRz context)
            : base(context)
        {

        }

        //public LinkLabel AddRegularPayCalendarLinkLabel()
        //{
        //    LinkLabel llRegularPaycalendar = new LinkLabel();
        //    llRegularPaycalendar.Text = "Sensible Regular Pay Calendar";
        //    llRegularPaycalendar.LinkClicked += new LinkLabelLinkClickedEventHandler(llPayCalendar_LinkClicked);
        //    return llRegularPaycalendar;
        //}

        public LinkLabel AddCommissionScheduleLinkLabel()
        {
            LinkLabel llCommissionSchedule = new LinkLabel();
            llCommissionSchedule.Text = "Sensible Commission Schedule";
            llCommissionSchedule.LinkClicked += new LinkLabelLinkClickedEventHandler(llCommisionSchedule_LinkClicked);
            return llCommissionSchedule;
        }
        //private void llPayCalendar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    System.Diagnostics.Process.Start(@"https://calendar.google.com/calendar/embed?src=sensiblemicro.com_l0dh02oo6cqa2sqdpve5m7rffs%40group.calendar.google.com&ctz=America%2FNew_York");
        //}

        private void llCommisionSchedule_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //System.Diagnostics.Process.Start(@"https://docs.google.com/document/d/1rADR9Df087jaYSOoMqYK97VIhl5N0OguNkIXEdE-uJk/edit?usp=sharing");
            System.Diagnostics.Process.Start(@"https://sites.google.com/sensiblemicro.com/intranet/yearly-pay-calendar");
        }


        protected override void InitColumns(Context context)
        {
            ColumnAdd(new ReportColumn("Company"));
            ColumnAdd(new ReportColumn("Sale#", ColumnAlignment.Left));
            ColumnAdd(new ReportColumn("Invoice#"));
            ColumnAdd(new ReportColumn("Pay Date"));
            ColumnAdd(new ReportColumn("Amnt Paid", ColumnAlignment.Right));
            ColumnAdd(new ReportColumn("Total Price", ColumnAlignment.Right));
            ColumnAdd(new ReportColumn("Deductions", ColumnAlignment.Right));
            ColumnAdd(new ReportColumn("Total Cost", ColumnAlignment.Right));
            ColumnAdd(new ReportColumn("Gross Profit", ColumnAlignment.Right));
            ColumnAdd(new ReportColumn("Net Profit", ColumnAlignment.Right));
            ColumnAdd(new ReportColumn("Net Percent %", ColumnAlignment.Right));
            ColumnAdd(new ReportColumn("Comm %", ColumnAlignment.Center));
            ColumnAdd(new ReportColumn("Line Comm", ColumnAlignment.Center));


        }
        public override void CalculateLines(Context context, ReportArgs args)
        {
            try
            {
                ContextRz x = (ContextRz)context;
                CommissionReportArgs argsx = (CommissionReportArgs)args;
                base.CalculateLines(context, args);
                //KT Refactored from RzSensible
                Caption = Title + " " + args.ToString();
                Lines.Clear();
                InitTotals();
                Sections.Clear();

                //This will contain ALL Commissionable Items.
                DataTable combinedCommissionDt = new DataTable();
                //This will contain normal Commissionable Items.
                //Variable for the sections
                CommissionReportSectionUser userSection = null;
                DataTable regularCommissionDt = GetCommissionDatatable(x, argsx);
                if (regularCommissionDt != null && regularCommissionDt.Rows.Count > 0)
                    AddRegularCommissionRows(x, argsx, regularCommissionDt, userSection);
                //This will create new rows for thei datatable, set to the split agent info.
                DataTable splitCommissionDt = GetSplitCommissionDatatable(x, argsx, regularCommissionDt);
                if (splitCommissionDt != null && splitCommissionDt.Rows.Count > 0)
                    AddSplitLineToReportSection(x, argsx, splitCommissionDt, userSection);

                //List Acquisition DataTable
                DataTable lsitAcquisitionDt = GetListAcquisitionDatatable(x, argsx, regularCommissionDt);
                if (lsitAcquisitionDt != null && lsitAcquisitionDt.Rows.Count > 0)
                    AddListAcquisitionLineToReportSection(x, argsx, lsitAcquisitionDt, userSection);


                //CommissionDt.Merge(splitCommissionDt);

                //*******************MAYBE KEEP SEPARATE DATATABLES, THAT WAY EACH CAN HAVE OWN LOGIC, AND ADD USERSECTIONS SEPARATELY!!  //




                //Payroll Deductions
                dtPayrollDeductions = x.Sys.TheProfitLogic.GetPayRollDeductionDataTable(x, argsx.Range.TheRange.StartDate, argsx.Range.TheRange.EndDate, argsx);

                //Loop through and get any payroll deductions.
                foreach (DataRow r in dtPayrollDeductions.Rows)
                {
                    //CommissionReportSectionUser userSection = null;
                    ReportLine pdl = new ReportLine();
                    pdl.Set(0, "Payroll Deductions:");
                    pdl.ForeColor = Color.Red;

                    //If the collection of users already contains a record for this user_uid, add it to that user section
                    if (Sections.ContainsKey(Tools.Data.NullFilterString(r["seller_uid"])))
                        userSection = (CommissionReportSectionUser)Sections[Tools.Data.NullFilterString(r["seller_uid"])];
                    else
                    {//If the collection of users does not contains a record for this user_uid, creat new user section
                        string id = Tools.Data.NullFilterString(r["seller_uid"]);
                        string name = Tools.Data.NullFilterString(r["seller_name"]);
                        userSection = (CommissionReportSectionUser)x.Sys.TheProfitLogic.GetCommissionReportSectionUser(x, id, name, argsx.Range.TheRange.StartDate, argsx.Range.TheRange.EndDate);
                        Sections.Add(Tools.Data.NullFilterString(r["seller_uid"]), userSection);
                    }
                    userSection.Lines.Add(pdl);
                    userSection.PayrollDeductionLineAdd(x, this, r);
                }





                //KT This loops through and calcs the totals for each Users
                foreach (ReportSection s in Sections.Values)//EAch ReportSection is a "User"
                {

                    //This needs to be a CommissionReportSectionUser, since we're looping through the users to calc the totals.
                    if (!(s is CommissionReportSectionUser))
                        continue;
                    CommissionReportSectionUser ss = (CommissionReportSectionUser)s;
                    TotalSales.Value += ss.TotalSales.Value;
                    TotalFees.Value += ss.TotalFees.Value;
                    TotalCost.Value += ss.TotalCost.Value;
                    TotalNP.Value += ss.TotalNP.Value;
                    //Totals Variables that get set after line calcs:
                    ss.TotalBogey.Value = x.Sys.TheProfitLogic.GetBogey(x, ss.UserID);
                    TotalBogey.Value = ss.TotalBogey.Value;
                    ss.TotalPayrollDeductions.Value = GetPayrollDeductionsValue(x, ss);
                    //KT Invoice Credits Applied
                    ss.TotalInvoiceCredits = x.Sys.TheProfitLogic.GetOrderCredits(x, ss.InvoiceIDsForUser);
                    ss.TotInvoiceCredits.Value += ss.TotalInvoiceCredits;
                    TotInvoiceCredits.Value += ss.TotInvoiceCredits.Value;
                    ss.TotalNP.Value -= ss.TotInvoiceCredits.Value;
                    TotalNP.Value -= ss.TotInvoiceCredits.Value;
                    ss.NetComm.Value = x.Sys.TheProfitLogic.calc_TotalNetCommission(x, ss.CommissionData, TotalBogey.Value, ss.TotalInvoiceCredits, ss.UserID, ss.TotalPayrollDeductions.Value);
                    GrossComm.Value += ss.GrossComm.Value;
                    TotalPayrollDeductions.Value += ss.TotalPayrollDeductions.Value;
                    NetComm.Value += ss.NetComm.Value;
                }


            }
            catch (Exception ex)
            {
                context.Leader.Tell(ex.Message);
            }

            //End REfactor Block
        }

        private void AddSplitLineToReportSection(ContextRz x, CommissionReportArgs argsx, DataTable splitCommissinDataTable, CommissionReportSectionUser userSection)
        {
            foreach (DataRow r in splitCommissinDataTable.Rows)
            {
                //Variables
                string splitAgentID = "";
                string splitAgentName = "";
                double splitPercent = 0;
                //customer
                string customerName = Tools.Data.NullFilterString(r["companyname"]);
                if (SingleUserOmit(argsx, r, SM_Enums.SplitCommissionType.standard_split))
                    continue;
                //Seller Information
                string seller_id = Tools.Data.NullFilterString(r["base_mc_user_uid"]);
                string seller_name = Tools.Data.NullFilterString(r["agentName"]);


                //Split Object ID
                string splitCommissionID = Tools.Data.NullFilterString(r["split_commission_ID"]);
                split_commission sc = null;

                if (!string.IsNullOrEmpty(splitCommissionID))
                    sc = split_commission.GetById(x, splitCommissionID);
                if (sc == null)
                    return;

                splitAgentID = sc.split_commission_agent_id;
                splitAgentName = sc.split_commission_agent;
                splitPercent = sc.split_commission_percent;


                //Sections              
                //Set the section ID 
                string sectionUserID = splitAgentID;
                string sectionUserName = splitAgentName;

                //Add or update this into the Sections object
                if (Sections.ContainsKey(sectionUserID))
                    userSection = (CommissionReportSectionUser)Sections[sectionUserID];
                else if (!string.IsNullOrEmpty(sectionUserID))
                {
                    //If the collection of users does not contains a record for this user_uid, creat new user section
                    //Only add a section for known agents, else there will be a section with ALL lines again, associated with no agent.  Also see below for handling the lines.
                    userSection = (CommissionReportSectionUser)x.Sys.TheProfitLogic.GetCommissionReportSectionUser(x, sectionUserID, sectionUserName, argsx.Range.TheRange.StartDate, argsx.Range.TheRange.EndDate);
                    Sections.Add(sectionUserID, userSection);
                }

                //Add this commissionLine to the proper userSection.
                //This is clunky, but whgen no agentID I need to not add the line, similar to above when adding a userSection
                if (!string.IsNullOrEmpty(sectionUserID))
                    userSection.CommissionLineAdd(x, this, r, sectionUserID, SM_Enums.SplitCommissionType.standard_split.ToString());
            }
        }


        private void AddListAcquisitionLineToReportSection(ContextRz x, CommissionReportArgs argsx, DataTable lsitAcquisitionDt, CommissionReportSectionUser userSection)
        {
            //Sections
            string sectionUserID = "";
            string sectionUserName = "";

            foreach (DataRow r in lsitAcquisitionDt.Rows)
            {
                //List Acquisition
                if (SingleUserOmit(argsx, r, SM_Enums.SplitCommissionType.list_acquisition))
                    continue;
                string listAcquisitionAgentID = Tools.Data.NullFilterString(r["list_acquisition_agent_uid"]);
                string listAcquisitionAgentName = Tools.Data.NullFilterString(r["list_acquisition_agent"]);
                if (!string.IsNullOrEmpty(listAcquisitionAgentID))
                {
                    sectionUserID = listAcquisitionAgentID;
                    sectionUserName = listAcquisitionAgentName;
                }

                //Sections  
                if (Sections.ContainsKey(sectionUserID))
                    userSection = (CommissionReportSectionUser)Sections[sectionUserID];
                else if (!string.IsNullOrEmpty(sectionUserID))
                {
                    //If the collection of users does not contains a record for this user_uid, creat new user section
                    //Only add a section for known agents, else there will be a section with ALL lines again, associated with no agent.  Also see below for handling the lines.
                    userSection = (CommissionReportSectionUser)x.Sys.TheProfitLogic.GetCommissionReportSectionUser(x, sectionUserID, sectionUserName, argsx.Range.TheRange.StartDate, argsx.Range.TheRange.EndDate);
                    Sections.Add(sectionUserID, userSection);
                }

                //Add this commissionLine to the proper userSection.
                //This is clunky, but whgen no agentID I need to not add the line, similar to above when adding a userSection
                if (!string.IsNullOrEmpty(sectionUserID))
                    userSection.CommissionLineAdd(x, this, r, sectionUserID, SM_Enums.SplitCommissionType.list_acquisition.ToString());


            }
        }


        private void AddRegularCommissionRows(ContextRz x, CommissionReportArgs argsx, DataTable CommissionDt, CommissionReportSectionUser userSection)
        {
            //AddSplitCommissionData(context, argsx, d);
            if (Tools.Data.DataTableExists(CommissionDt))
            {
                foreach (DataRow r in CommissionDt.Rows)
                {
                    if (!SingleUserOmit(argsx, r))
                        AddCommissionLineToSection(x, argsx, r, userSection);
                }

            }
        }

        private void AddCommissionLineToSection(ContextRz x, CommissionReportArgs argsx, DataRow r, CommissionReportSectionUser userSection)
        {

            //agent ID can morph between teh actual line agent adn the split agent.  This is used to differentiate the "userSection"
            string sectionAgentID = Tools.Data.NullFilterString(r["base_mc_user_uid"]);
            string sectionAgentName = Tools.Data.NullFilterString(r["agentName"]);




            //CommissionReportSectionUser userSection = null;
            //Add or update this into the Sections object
            if (Sections.ContainsKey(sectionAgentID))
                userSection = (CommissionReportSectionUser)Sections[sectionAgentID];
            else//If the collection of users does not contains a record for this user_uid, creat new user section
            {
                //Only add a section for known agents, else there will be a section with ALL lines again, associated with no agent.  Also see below for handling the lines.
                if (!string.IsNullOrEmpty(sectionAgentID))
                {

                    userSection = (CommissionReportSectionUser)x.Sys.TheProfitLogic.GetCommissionReportSectionUser(x, sectionAgentID, sectionAgentName, argsx.Range.TheRange.StartDate, argsx.Range.TheRange.EndDate);
                    Sections.Add(sectionAgentID, userSection);
                }

            }

            //Add this commissionLine to the proper userSection.
            //This is clunky, but whgen no agentID I need to not add the line, similar to above when adding a userSection
            if (!string.IsNullOrEmpty(sectionAgentID))
                userSection.CommissionLineAdd(x, this, r, sectionAgentID);
        }


        private bool SingleUserOmit(CommissionReportArgs argsx, DataRow r, SM_Enums.SplitCommissionType type = SM_Enums.SplitCommissionType.standard_split)
        {

            //This will make sure in case teh split agent is the same as the seller, that we don't create a split for commission report.  IF they are same, it's not a split.  I.e. phil may sell his own aquired parts.
            string selectedAgentID = "";
            if (argsx.Agent.AgentIds.Count > 0)
                selectedAgentID = argsx.Agent.AgentIds[0];

            //IF no selected agent, we don't omit, return false
            if (string.IsNullOrEmpty(selectedAgentID))
                return false;
            //variables for debugging
            string customerName = Tools.Data.NullFilterString(r["companyname"]);

            switch (type)
            {
                //case SM_Enums.SplitCommissionType.standard_split:
                //    {
                //        //For Split Commission we omit if the split_agent_id != split_agent_id
                //        string split_agent_id = Tools.Data.NullFilterString(r["split_commission_agent_uid"]);
                //        return (split_agent_id != selectedAgentID);
                //    }
                case SM_Enums.SplitCommissionType.list_acquisition:
                    {
                        //For List Acquisition we omit if the list_acquisiton_id != selectedUserId
                        string list_agent_id = Tools.Data.NullFilterString(r["list_acquisition_agent_uid"]);
                        return (list_agent_id != selectedAgentID);
                    }
                default:
                    {
                        //For Standard we omit if the seller != selected user ID
                        string seller_id = Tools.Data.NullFilterString(r["base_mc_user_uid"]);
                        return (seller_id != selectedAgentID);
                    }
            }
        }

        private DataTable GetListAcquisitionDatatable(ContextRz x, CommissionReportArgs argsx, DataTable regularCommissionDt)
        {
            DataTable ret = regularCommissionDt.Clone();
            foreach (DataRow row in regularCommissionDt.Rows)
            {
                DataRow newRow = ret.NewRow();
                var sourceRow = row;
                newRow.ItemArray = sourceRow.ItemArray.Clone() as object[];

                //customer
                string customerName = Tools.Data.NullFilterString(row["companyname"]);
                //original seller
                string seller_id = Tools.Data.NullFilterString(row["base_mc_user_uid"]);
                //list acquisition agent
                string list_acquisition_agent_uid = Tools.Data.NullFilterString(row["list_acquisition_agent_uid"]);
                string list_acquisition_agent = Tools.Data.NullFilterString(row["list_acquisition_agent"]);

                if (!string.IsNullOrEmpty(list_acquisition_agent_uid))
                {
                    if (seller_id != list_acquisition_agent_uid)//Only Add if the split seller isn't also the list_acquisition_agent
                    {
                        //newRow["agentname"] = list_acquisition_agent;
                        //newRow["base_mc_user_uid"] = list_acquisition_agent_uid;
                        //newRow["split_commission_type"] = "list_agent_row";
                        ret.Rows.Add(newRow);
                    }
                }
            }



            return ret;
        }



        private DataTable GetSplitCommissionDatatable(ContextRz x, CommissionReportArgs argsx, DataTable dtCommissionLines)
        {
            //basically just swap split_commission agent_name with a foreach loop?
            //Clone the column structure, not the data.
            DataTable ret = dtCommissionLines.Clone();
            foreach (DataRow row in dtCommissionLines.Rows)
            {
                string split_CommissionID = Tools.Data.NullFilterString(row["split_commission_ID"]);
                if (string.IsNullOrEmpty(split_CommissionID))
                    continue;
                split_commission sc = split_commission.GetById(x, split_CommissionID);
                if (sc == null)
                    continue;
                DataRow newRow = ret.NewRow();

                var sourceRow = row;
                newRow.ItemArray = sourceRow.ItemArray.Clone() as object[];

                //carry the variables for readability
                //customer
                string customerName = Tools.Data.NullFilterString(row["companyname"]);
                string seller_name = Tools.Data.NullFilterString(row["agentname"]);
                //split commission
                string split_agent_id = sc.split_commission_agent_id;
                string split_agent_name = sc.split_commission_agent;


                //swap the names and id
                if (!string.IsNullOrEmpty(split_agent_id))
                {
                    newRow["agentname"] = split_agent_name;
                    newRow["base_mc_user_uid"] = split_agent_id;
                    //string split_type = Tools.Data.NullFilterString(row["split_commission_type"]);
                    //newRow["split_commission_type"] = split_type;
                    ret.Rows.Add(newRow);
                }
            }

            return ret;
        }

        private DataTable GetCommissionDatatable(ContextRz x, CommissionReportArgs argsx, bool isSplit = false)
        {
            //KT 3-28-2016 - Customer Credits (ordhits) I think is incorrect above, it's not working out to match excel.  In DB these should always be positive, and only add ordhits to fees if deduct profit = 1
            // String sql = "select orddet_line.unique_id,orddet_line.customer_name as companyname, ordhed_invoice.base_company_uid,ordhed_invoice.base_mc_user_uid,ordhed_invoice.unique_id as order_id,ordhed_invoice.agentname,ordhed_invoice.buyername,ordhed_invoice.orderdate,ordhed_invoice.ordernumber,orddet_line.datecode,orddet_line.manufacturer,orddet_line.fullpartnumber,(select max(checkpayment.transdate) from checkpayment where checkpayment.transtype = 'payment' and checkpayment.base_ordhed_uid = orddet_line.orderid_invoice) as paydate,isnull((select sum(checkpayment.transamount) from checkpayment where checkpayment.transtype = 'payment' and checkpayment.base_ordhed_uid = orddet_line.orderid_invoice),0) as payamount,(select ordhed_invoice.ordertotal from ordhed_invoice where ordhed_invoice.unique_id = orddet_line.orderid_invoice) as ordertotal,orddet_line.quantity,orddet_line.unit_price,(orddet_line.quantity * orddet_line.unit_price) as total_sales,orddet_line.unit_cost,isnull(((select sum(amount) from profit_deduction where orddet_line.unique_id = profit_deduction.the_orddet_line_uid)),0)  + (orddet_line.rma_subtraction + orddet_line.service_cost) + isnull((select sum(hit_amount) from ordhit where the_ordhed_uid = orderid_invoice AND deduct_profit = 1), 0) as fees,(orddet_line.quantity * orddet_line.unit_cost) as total_cost,((orddet_line.quantity * orddet_line.unit_price) - (orddet_line.quantity * orddet_line.unit_cost)) as gp,orddet_line.stocktype, (select isnull(override_stock_commission, 0) from ordhed_invoice where unique_id = orddet_line.orderid_invoice) as [override_stock_commission]  from orddet_line inner join ordhed_invoice on orddet_line.orderid_invoice = ordhed_invoice.unique_id where isnull(ordhed_invoice.isvoid,0) = 0 and len(isnull(ordhed_invoice.unique_id,'')) > 0";
            //Removing ordits from above, it a header level prop, and it's being calced at the line level, causing amount to be repeated for each line, when it should be once per invoice.
            //String sql = "select orddet_line.unique_id,orddet_line.customer_name as companyname,orddet_line.status, ordhed_invoice.base_company_uid,ordhed_invoice.base_mc_user_uid,ordhed_invoice.unique_id as order_id,ordhed_invoice.agentname,ordhed_invoice.buyername,ordhed_invoice.orderdate,ordhed_invoice.ordernumber,orddet_line.datecode,orddet_line.manufacturer,orddet_line.fullpartnumber,(select max(checkpayment.transdate) from checkpayment where checkpayment.transtype = 'payment' and checkpayment.base_ordhed_uid = orddet_line.orderid_invoice) as paydate,isnull((select sum(checkpayment.transamount) from checkpayment where checkpayment.transtype = 'payment' and checkpayment.base_ordhed_uid = orddet_line.orderid_invoice),0) as payamount,(select ordhed_invoice.ordertotal from ordhed_invoice where ordhed_invoice.unique_id = orddet_line.orderid_invoice) as ordertotal,orddet_line.quantity,orddet_line.unit_price,(orddet_line.quantity * orddet_line.unit_price) as total_sales,orddet_line.unit_cost,isnull(((select sum(amount) from profit_deduction where orddet_line.unique_id = profit_deduction.the_orddet_line_uid)),0)  + (orddet_line.rma_subtraction + orddet_line.service_cost) as fees,(orddet_line.quantity * orddet_line.unit_cost) as total_cost,((orddet_line.quantity * orddet_line.unit_price) - (orddet_line.quantity * orddet_line.unit_cost)) as gp,orddet_line.stocktype, (select isnull(override_stock_commission, 0) from ordhed_invoice where unique_id = orddet_line.orderid_invoice) as [override_stock_commission]  from orddet_line inner join ordhed_invoice on orddet_line.orderid_invoice = ordhed_invoice.unique_id where isnull(ordhed_invoice.isvoid,0) = 0 and len(isnull(ordhed_invoice.unique_id,'')) > 0";
            //Adding split commission:
            String sql = "select orddet_line.split_commission_ID, orddet_line.affiliate_id, orddet_line.list_acquisition_agent_uid, orddet_line.list_acquisition_agent, orddet_line.split_commission_agent_name , orddet_line.split_commission_agent_uid,orddet_line.split_commission_type,  orddet_line.unique_id,orddet_line.customer_name as companyname,orddet_line.status, ordhed_invoice.base_company_uid,ordhed_invoice.base_mc_user_uid,ordhed_invoice.unique_id as order_id,ordhed_invoice.agentname,ordhed_invoice.buyername,ordhed_invoice.orderdate,ordhed_invoice.ordernumber,orddet_line.datecode,orddet_line.manufacturer,orddet_line.fullpartnumber,(select max(checkpayment.transdate) from checkpayment where checkpayment.transtype = 'payment' and checkpayment.base_ordhed_uid = orddet_line.orderid_invoice) as paydate,isnull((select sum(checkpayment.transamount) from checkpayment where checkpayment.transtype = 'payment' and checkpayment.base_ordhed_uid = orddet_line.orderid_invoice),0) as payamount,(select ordhed_invoice.ordertotal from ordhed_invoice where ordhed_invoice.unique_id = orddet_line.orderid_invoice) as ordertotal,orddet_line.quantity,orddet_line.unit_price,(orddet_line.quantity * orddet_line.unit_price) as total_sales,orddet_line.unit_cost,isnull(((select sum(amount) from profit_deduction where orddet_line.unique_id = profit_deduction.the_orddet_line_uid)),0)  + (orddet_line.rma_subtraction + orddet_line.service_cost) as fees,(orddet_line.quantity * orddet_line.unit_cost) as total_cost,((orddet_line.quantity * orddet_line.unit_price) - (orddet_line.quantity * orddet_line.unit_cost)) as gp,orddet_line.stocktype, (select isnull(override_stock_commission, 0) from ordhed_invoice where unique_id = orddet_line.orderid_invoice) as [override_stock_commission]  from orddet_line inner join ordhed_invoice on orddet_line.orderid_invoice = ordhed_invoice.unique_id left join split_commission on orddet_line.split_commission_ID = split_commission.unique_id  where isnull(ordhed_invoice.isvoid,0) = 0 and len(isnull(ordhed_invoice.unique_id,'')) > 0";

            if (argsx.Range.Exists())
            //KT - Use Paydate instead of ordhed_invoice.orderdate                
            {
                sql += " and " + argsx.Range.TheRange.GetSQL("(select max(checkpayment.transdate) from checkpayment where checkpayment.transtype = 'payment' and checkpayment.base_ordhed_uid = orddet_line.orderid_invoice and checkpayment.transamount > 0) ");
                StartDate = argsx.Range.TheRange.StartDate;
                EndDate = argsx.Range.TheRange.EndDate;

            }

            //Query for particular agent
            if (argsx.Agent.Exists())
            {
                sql += " and (isnull(ordhed_invoice.base_mc_user_uid, '') in ( " + Tools.Data.GetIn(argsx.Agent.AgentIds) + " )   " +
                    " or isnull(orddet_line.list_acquisition_agent_uid, '') in (" + Tools.Data.GetIn(argsx.Agent.AgentIds) + ") " +
                    " or isnull(split_commission.split_commission_agent_id, '') in (" + Tools.Data.GetIn(argsx.Agent.AgentIds) + ") " +
                    ") ";


            }

            //KT - Toggle to only show Fully Paid Invoices
            if (argsx.PaidFullOnly.Exists())
            {
                if (argsx.PaidFullOnly.Value != true)
                    sql += " AND CAST(isnull((select sum(checkpayment.transamount) from checkpayment where checkpayment.transtype = 'payment' AND checkpayment.base_ordhed_uid = orddet_line.orderid_invoice),0) as decimal) >= CAST((ordertotal)as decimal)  - isnull((select SUM(abs(hit_amount)) from ordhit where the_ordhed_uid = orddet_line.orderid_invoice AND deduct_profit = 1), 0)";
            }

            //Single agent or all agents
            if (!x.xUser.SuperUser && !x.CheckPermit(Permissions.ThePermits.ViewAllUsersOnReports))
                sql += " and (ordhed_invoice.base_mc_user_uid = '" + x.xUser.unique_id + "' or (isnull(split_commission.split_commission_agent_id, '') in ( " + Tools.Data.GetIn(argsx.Agent.AgentIds) + " )) or (isnull(orddet_line.list_acquisition_agent_uid, '') in ( " + Tools.Data.GetIn(argsx.Agent.AgentIds) + " ))   ) ";
            //group by
            sql += " group by ordhed_invoice.unique_id,orddet_line.unique_id, orddet_line.service_cost, orddet_line.customer_name,ordhed_invoice.base_mc_user_uid,ordhed_invoice.agentname,ordhed_invoice.buyername,ordhed_invoice.orderdate,ordhed_invoice.ordernumber,orddet_line.datecode,orddet_line.manufacturer,orddet_line.fullpartnumber,orddet_line.orderid_invoice,orddet_line.quantity,orddet_line.unit_price,orddet_line.unit_cost,ordhed_invoice.base_company_uid,orddet_line.rma_subtraction,orddet_line.stocktype, orddet_line.status, orddet_line.split_commission_type, orddet_line.split_commission_agent_name , orddet_line.split_commission_agent_uid, orddet_line.list_acquisition_agent_uid, orddet_line.list_acquisition_agent,orddet_line.affiliate_id, orddet_line.split_commission_ID";
            //order by
            sql += " order by ordhed_invoice.base_mc_user_uid,ordhed_invoice.ordernumber,ordhed_invoice.base_company_uid";

            DataTable d = x.Data.Select(sql);
            return d;
        }



        private double GetPayrollDeductionsValue(ContextRz x, CommissionReportSectionUser cUser)
        {
            double d = 0;
            d = dtPayrollDeductions.AsEnumerable().Where(y => y.Field<string>("seller_uid") == cUser.UserID).Sum(ss => ss.Field<double>("amount"));


            return d;

        }
        private double GetPayrollDeductionsForUser(string seller_uid)
        {
            double ret = 0;

            return ret;

        }



        public override string Title
        {
            get
            {
                return "Commission Report (*Personal and Confidential*)";
            }
        }
        public override ReportArgs ArgsCreate(Context context)
        {
            return new CommissionReportArgs((ContextRz)context);
        }


        protected override void InitTotals() //This is the Aggregate totals for all users
        {
            // This is the totals for all users
            base.InitTotals();

            //Total Sales
            TotalSales = new ReportTotal(""); //Total Sales
            //TotalSales.Overline = 1;
            TotalSales.CaptionColumn = 1;
            //TotalSales.ValueColumn = 2;    
            TotalSales.CombineCaptionValue = true;
            TotalSales.Caption = "Total Sales:" + Environment.NewLine;
            Totals.Add(TotalSales);

            //Total Cost
            TotalCost = new ReportTotal(""); //Total Cost
            //TotalCost.Overline = 1;
            TotalCost.CaptionColumn = 2;
            //TotalCost.ValueColumn = 4;         
            TotalCost.CombineCaptionValue = true;
            TotalCost.Caption = "Total Cost:" + Environment.NewLine;
            Totals.Add(TotalCost);

            //Total Fees = Total Deductions
            TotalFees = new ReportTotal("Total Deduct:"); //Total Fees
            TotalFees.CaptionColumn = 3;
            TotalFees.CombineCaptionValue = true;
            Totals.Add(TotalFees);

            //Payroll Deductions (RMA / PD Deductions)
            TotalPayrollDeductions = new ReportTotal("");
            //TotalPayrollDeductions.Overline = 1;
            TotalPayrollDeductions.CaptionColumn = 4;
            //TotalPayrollDeductions.ValueColumn = 8;
            TotalPayrollDeductions.Caption = "Payroll Deds:";
            TotalPayrollDeductions.CombineCaptionValue = true;
            Totals.Add(TotalPayrollDeductions);


            //Total NP
            TotalNP = new ReportTotal(""); //Total NP
            //TotalNP.Overline = 1;
            TotalNP.CaptionColumn = 5;
            //TotalNP.ValueColumn = 6;            
            TotalNP.Caption = "Total NP:" + Environment.NewLine;
            TotalNP.CombineCaptionValue = true;
            Totals.Add(TotalNP);


            //Gross Commission
            GrossComm = new ReportTotal(""); //Total Commission
            //GrossComm.Overline = 1;
            //GrossComm.ValueColumn = 6;
            GrossComm.CaptionColumn = 6;
            GrossComm.Caption = "Gross Comm:";
            GrossComm.CombineCaptionValue = true;
            Totals.Add(GrossComm);


            //Total Bogey
            TotalBogey = new ReportTotal(""); //Total NP            
            TotalBogey.CaptionColumn = 7;
            TotalBogey.Caption = "Bogey:" + Environment.NewLine;
            TotalBogey.CombineCaptionValue = true;
            Totals.Add(TotalBogey);



            //Total Invoice Credits Applied
            TotInvoiceCredits = new ReportTotal("");
            //TotalPayrollDeductions.Overline = 1;
            TotInvoiceCredits.CaptionColumn = 8;
            TotInvoiceCredits.Caption = "Inv Credits:" + Environment.NewLine;
            TotInvoiceCredits.CombineCaptionValue = true;
            Totals.Add(TotInvoiceCredits);

            //Net Commission
            NetComm = new ReportTotal(""); //Total Commission
            //NetComm.Overline = 1;
            //NetComm.ValueColumn = 10;
            NetComm.CaptionColumn = 9;
            NetComm.CombineCaptionValue = true;
            NetComm.Caption = "Net Comm:" + Environment.NewLine;
            Totals.Add(NetComm);
        }
    }
    public class CommissionReportArgs : ReportArgs
    {
        //Public Variables
        public ReportCriteriaDateRange Range;
        public ReportCriteriaAgent Agent;
        //KT Adding Toggle for Paid in Full
        public ReportCriteriaBoolean PaidFullOnly;

        //Constructors
        public CommissionReportArgs(ContextRz context)
            : base(context)
        {
            Range = new ReportCriteriaDateRange("Payment Date");
            Criteria.Add(Range);
            Range.TheRange = Tools.Dates.DateRange.ThisMonth;
            Range.DefaultOption = "This Month";
            Agent = new ReportCriteriaAgent("Agent");
            Criteria.Add(Agent);
            ////KT Adding Toggle for Paid in Full
            PaidFullOnly = new ReportCriteriaBoolean("Include Partially Paid", "", "");
            Criteria.Add(PaidFullOnly);




        }



    }



    public class CommissionReportSectionUser : ReportSection
    {
        public String UserID = "";
        public String UserName = "";
        public List<string> InvoiceIDsForUser = new List<string>();


        public ReportTotal TotalsTitle;
        public ReportTotal TotalSales;
        public ReportTotal TotalFees;
        public ReportTotal TotalCost;
        public ReportTotal TotalGP;
        public ReportTotal TotalNP;
        //KT
        public ReportTotal TotalPaid;
        public ReportTotal TotalComm;
        public ReportTotal TotalBogey;
        public ReportTotal GrossComm;
        public ReportTotal NetComm;
        public ReportTotal TotInvoiceCredits;
        public double TotalStockNP;
        public double TotalBuyNP;
        public double TotalStockComm;
        public double TotalBuyComm;
        //public double Commission_Percent = 0;
        public ReportTotal TotalPayrollDeductions;

        //KT variable to hold Invoice Credits
        public double TotalInvoiceCredits;

        public DateTime StartDate;
        public DateTime EndDate;






        //public double commission_bogey;
        public double Bogey;

        public Dictionary<string, double> HeaderPayments = new Dictionary<string, double>();


        public DataTable CommissionData = new DataTable();

        public CommissionReportSectionUser(ContextRz context, String user_id, String user_name, DateTime start_date, DateTime end_date) // These Totals are for each individual User
        {//this is the Per User Section

            //Totals Title
            TotalsTitle = new ReportTotal("");
            TotalsTitle.CaptionColumn = 0;
            TotalsTitle.Caption = "Totals for " + user_name + ":";
            Totals.Add(TotalsTitle);

            //Total Sales
            TotalSales = new ReportTotal(""); //Total Sales
            //TotalSales.Overline = 1;
            TotalSales.CaptionColumn = 1;
            //TotalSales.ValueColumn = 2;    
            TotalSales.CombineCaptionValue = true;
            TotalSales.Caption = "Total Sales:" + Environment.NewLine;
            Totals.Add(TotalSales);

            //Total Cost
            TotalCost = new ReportTotal(""); //Total Cost
            //TotalCost.Overline = 1;
            TotalCost.CaptionColumn = 2;
            //TotalCost.ValueColumn = 4;         
            TotalCost.CombineCaptionValue = true;
            TotalCost.Caption = "Total Cost:" + Environment.NewLine;
            Totals.Add(TotalCost);

            //Total Fees = Total Deductions
            TotalFees = new ReportTotal("Total Deduct:"); //Total Fees
            TotalFees.CaptionColumn = 3;
            TotalFees.CombineCaptionValue = true;
            Totals.Add(TotalFees);

            //Payroll Deductions (RMA / PD Deductions)
            TotalPayrollDeductions = new ReportTotal("");
            //TotalPayrollDeductions.Overline = 1;
            TotalPayrollDeductions.CaptionColumn = 4;
            //TotalPayrollDeductions.ValueColumn = 8;
            TotalPayrollDeductions.Caption = "Payroll Deds:";
            TotalPayrollDeductions.CombineCaptionValue = true;
            Totals.Add(TotalPayrollDeductions);

            //Total NP
            TotalNP = new ReportTotal(""); //Total NP
            //TotalNP.Overline = 1;
            TotalNP.CaptionColumn = 5;
            //TotalNP.ValueColumn = 6;            
            TotalNP.Caption = "Total NP:" + Environment.NewLine;
            TotalNP.CombineCaptionValue = true;
            Totals.Add(TotalNP);


            //Gross Commission
            GrossComm = new ReportTotal(""); //Total Commission
            //GrossComm.Overline = 1;
            //GrossComm.ValueColumn = 6;
            GrossComm.CaptionColumn = 6;
            GrossComm.Caption = "Gross Comm:";
            GrossComm.CombineCaptionValue = true;
            Totals.Add(GrossComm);


            //Total Bogey
            //Just Used to hold the user's bogey for total aggregate
            TotalBogey = new ReportTotal(""); //Total NP            
            TotalBogey.CaptionColumn = 7;
            TotalBogey.Caption = "Bogey:" + Environment.NewLine;
            TotalBogey.CombineCaptionValue = true;
            Totals.Add(TotalBogey);



            //Total Invoice Credits Applied
            TotInvoiceCredits = new ReportTotal("");
            //TotalPayrollDeductions.Overline = 1;
            TotInvoiceCredits.CaptionColumn = 8;
            TotInvoiceCredits.Caption = "Inv Credits:" + Environment.NewLine;
            TotInvoiceCredits.CombineCaptionValue = true;
            Totals.Add(TotInvoiceCredits);

            //Net Commission
            NetComm = new ReportTotal(""); //Total Commission
            //NetComm.Overline = 1;
            //NetComm.ValueColumn = 10;
            NetComm.CaptionColumn = 9;
            NetComm.CombineCaptionValue = true;
            NetComm.Caption = "Net Comm:" + Environment.NewLine;
            Totals.Add(NetComm);


            //Setup the Commisison DataTable
            CommissionData.Clear();
            CommissionData.Columns.Add("NetProfit", typeof(double));
            CommissionData.Columns.Add("CommPercent", typeof(double));
            CommissionData.Columns.Add("LineID", typeof(string));
            CommissionData.Columns.Add("affiliate_id", typeof(string));


        }
        //KT Refactored from RzSensible


        public virtual void CommissionLineAdd(ContextRz context, Rz5.Reports.CommissionReport c, DataRow dr, string sectionUserID, string splitType = null)
        {
            if (dr == null)
                return;
            //KT we used to set UserID and UserNAme based on the dr, but after adding split commisison, this can cause the sectionName to be overridden by the split agent.
            //Now using a variable to keep track of the sectionUserID.
            n_user u = n_user.GetById(context, sectionUserID);
            if (u != null)
            {
                UserID = u.unique_id;
                UserName = u.Name;
            }
            else
            {
                //In case we have employees that are not still in N_user table (Legacy)
                UserID = nData.NullFilter_String(dr["base_mc_user_uid"]);
                UserName = nData.NullFilter_String(dr["agentName"]);
            }
            string affiliate_id = nData.NullFilter_String(dr["affiliate_id"]);
            string lineUID = nData.NullFilter_String(dr["unique_id"]);
            string order_uid = nData.NullFilter_String(dr["order_id"]);
            string invoiceNumber = nData.NullFilter_String(dr["ordernumber"]);
            string companyname = nData.NullFilter_String(dr["companyname"]);
            //Maintain List of Invoice ID's
            if (!InvoiceIDsForUser.Contains(order_uid))
                InvoiceIDsForUser.Add(order_uid);
            string comp_uid = nData.NullFilter_String(dr["base_company_uid"]);
            string comp_name = nData.NullFilter_String(dr["companyname"]);
            string buyer_name = nData.NullFilter_String(dr["buyername"]);
            string order_date = FilterDate(nData.NullFilter_DateTime(dr["orderdate"]));
            string order_number = nData.NullFilter_String(dr["ordernumber"]);
            string date_code = nData.NullFilter_String(dr["datecode"]);
            string mfg = nData.NullFilter_String(dr["manufacturer"]);
            string partnumber = nData.NullFilter_String(dr["fullpartnumber"]);
            string pay_date = FilterDate(nData.NullFilter_DateTime(dr["paydate"]));
            string pay_amount = Tools.Number.MoneyFormat_2_6(nData.NullFilter_Double(dr["payamount"]));
            if (!HeaderPayments.ContainsKey(order_uid))
            {
                HeaderPayments.Add(order_uid, nData.NullFilter_Double(dr["payamount"]));
            }
            string qty = nData.NullFilter_Int64(dr["quantity"]).ToString();
            string price = Tools.Number.MoneyFormat_2_6(nData.NullFilter_Double(dr["unit_price"]));
            string cost = Tools.Number.MoneyFormat_2_6(nData.NullFilter_Double(dr["unit_cost"]));
            double fees = nData.NullFilter_Double(dr["fees"]);
            double total_cost = nData.NullFilter_Double(dr["total_cost"]);
            double total_sales = nData.NullFilter_Double(dr["total_sales"]);

            //KT 9-21-2017 simpler method of defiving gp /np, more in line with other calculation variables
            string status = nData.NullFilter_String(dr["status"]);
            if (status.ToLower() == Enums.OrderLineStatus.Scrapped.ToString().ToLower() || status.ToLower() == Enums.OrderLineStatus.Quarantined.ToString().ToLower())
                total_sales = 0;
            double gp = total_sales - total_cost;
            double np = gp - fees;
            string fees_s = Tools.Number.MoneyFormat_2_6(fees);
            string total_sales_s = Tools.Number.MoneyFormat_2_6(total_sales);
            string total_cost_s = Tools.Number.MoneyFormat_2_6(total_cost);
            string net_s = Tools.Number.MoneyFormat_2_6(np);
            string gp_s = Tools.Number.MoneyFormat_2_6(gp);
            int gp_perc = 0;
            try { gp_perc = ((int)((gp / total_sales) * 100)); }
            catch { }
            if (gp_perc < 0)
                gp_perc = 0;
            string gp_perc_s = gp_perc.ToString() + "%";

            ordhed_sales s = (ordhed_sales)context.QtO("ordhed_sales", "select * from ordhed_sales where unique_id = (select distinct orderid_sales from orddet_line where LEN(isnull(orderid_sales, '')) > 0 and orderid_invoice = '" + order_uid + "')");
            string orderid_sales;
            string ordernumber_sales;

            if (s == null)
            {
                ordernumber_sales = "No Sale Found";
                orderid_sales = "No Sale Found";
            }
            else
            {
                ordernumber_sales = s.ordernumber;
                orderid_sales = s.unique_id;
            }

            //Invoice Credits
            string invoiceCredits = Tools.Number.MoneyFormat_2_6(context.Sys.TheProfitLogic.GetOrderCredits(context, new List<string>() { order_uid }));


            //Commission             
            double invoiceCommPerc = GetInvoiceCommissionPercent(context, dr, sectionUserID, splitType);
            //Ajust for affiliate sales -- Commenting since this may not need to be a profit report thing.  We doing it based on deductions.
            //double affiliateCommissionPercent = .05, not needed if handling as a deduction;
            //if (!string.IsNullOrEmpty(affiliate_id))
            //    invoiceCommPerc = (invoiceCommPerc - affiliateCommissionPercent);

            double linecommission = np * invoiceCommPerc;

            //CommissionData.Rows.Add(np, invoiceCommPerc, lineUID, affiliate_id);
            CommissionData.Rows.Add(np, invoiceCommPerc, lineUID);


            string strCommissionPercentString = invoiceCommPerc.ToString();
            if (!string.IsNullOrEmpty(affiliate_id))
                strCommissionPercentString = strCommissionPercentString + "(a)";
            string comm_s = Tools.Number.MoneyFormat_2_6(linecommission);
            double margin = (gp / total_sales) * 100;
            double netprofit = (np / total_cost) * 100;
            string margin_s = context.Sys.TheOrderLogic.GetMarginNetPercent(gp, total_sales);
            string netpercent_s = context.Sys.TheOrderLogic.GetMarginNetPercent(np, total_cost);

            //Line Layout
            ReportLine l = new ReportLine();
            l.Set(0, comp_name, new ItemTag("company", comp_uid)); //Company Name
            l.Set(1, ordernumber_sales, new ItemTag("ordhed_sales", orderid_sales)); // Sale
            l.Set(2, order_number, new ItemTag("ordhed_invoice", order_uid)); //Invoice
            l.Set(3, pay_date);//Pay Date
            l.Set(4, context.TheSys.CurrencySymbol + pay_amount);//Pay Amount
            l.Set(5, context.TheSys.CurrencySymbol + total_sales_s);//Total Price            
            l.Set(6, context.TheSys.CurrencySymbol + fees_s);//Deductions
            l.Set(7, context.TheSys.CurrencySymbol + total_cost_s);//Total Cost           
            l.Set(8, context.TheSys.CurrencySymbol + gp_s); //Gross Profit
            l.Set(9, context.TheSys.CurrencySymbol + np.ToString());//Net Profit
            l.Set(10, netpercent_s); //Net Percent           
            l.Set(11, strCommissionPercentString); //Commisison Percent
            l.Set(12, context.TheSys.CurrencySymbol + comm_s); //Gross Commission

            //Add the line
            Lines.Add(l);

            //Invoice Credit Sub-Line
            if (Convert.ToDecimal(invoiceCredits) > 0)
            {
                ReportLine subLine = new ReportLine();
                subLine.ForeColor = Color.Red;
                subLine.Set(2, "Credits: " + invoiceCredits);
                //Add the subLine
                Lines.Add(subLine);
            }

            //Get Totals
            TotalSales.Value += total_sales;
            TotalFees.Value += fees;
            TotalCost.Value += total_cost;
            GrossComm.Value += linecommission;
            TotalNP.Value += np;

        }

        //private double GetUserCommissionPercent(ContextRz context, DataRow dr)
        //{
        //    //This one is user-centric, and ignores the Invoice Percent.
        //    //Linda seems to be using this in her calcs.
        //    double ret = 0;
        //    string agentID = nData.NullFilter_String(dr["base_mc_user_uid"]);
        //    string agentName = nData.NullFilter_String(dr["agentname"]);
        //    string order_uid = nData.NullFilter_String(dr["order_id"]);
        //    string partNumber = nData.NullFilter_String(dr["fullpartnumber"]);
        //    string stocktype = nData.NullFilter_String(dr["stocktype"]);
        //    string SplitAgentUID = nData.NullFilter_String(dr["split_commission_agent_uid"]);
        //    string SplitLineUID = nData.NullFilter_String(dr["unique_id"]);
        //    bool overrride_stock_comm = nData.NullFilter_Boolean(dr["override_stock_commission"]);

        //    //Current User's Commission Percent
        //    n_user u = n_user.GetById(context, agentID);
        //    if (u == null)
        //        throw new Exception("An Rz User account could not be foud for: " + agentName + "(" + agentID + ")");
        //    //if(u.commission_percent <= 0)
        //    //    throw new Exception("Commission Percent is less <= 0 percent for: " + agentName + "(" + agentID + ")");
        //    ret = u.commission_percent;


        //    //Per Joe and Fred, GCAT should be full commish, even though stock            
        //    if (!partNumber.ToLower().Contains("gcat"))
        //    {
        //        ////Stock lines are 10% unless overriden                
        //        if (stocktype == "Stock" || stocktype == "Consign")
        //        {
        //            if (!overrride_stock_comm && agentName != "Phil Scott")//Phil Scott, and potentially all disty sales should get their standard commission rate regardless of stocktype == stock.
        //                ret = .1;
        //        }
        //    }

        //    if (!string.IsNullOrEmpty(SplitAgentUID))
        //    {
        //        ret = context.TheSysRz.TheProfitLogic.GetSplitCommission(context, SplitLineUID, SplitAgentUID, ret);

        //    }

        //    return ret;
        //}

        private double GetInvoiceCommissionPercent(ContextRz context, DataRow dr, string sectionUserID, string splitType = null)
        {
            double InvoiceCommissionPercent = 0;
            string order_uid = nData.NullFilter_String(dr["order_id"]);
            string partNumber = nData.NullFilter_String(dr["fullpartnumber"]);
            string stocktype = nData.NullFilter_String(dr["stocktype"]);
            bool overrride_stock_comm = nData.NullFilter_Boolean(dr["override_stock_commission"]);
            string agentName = nData.NullFilter_String(dr["agentname"]);            
            string companyName = nData.NullFilter_String(dr["CompanyName"]);
            //Current Invoice's commission percent
            InvoiceCommissionPercent = context.SelectScalarDouble("select commission_percent from ordhed_invoice where unique_id = '" + order_uid + "'");
         
            //Per Joe and Fred, GCAT should be full commish, even though stock            
            if (!partNumber.ToLower().Contains("gcat"))
            {
                ////Stock lines are 10% unless overriden                
                if (stocktype == "Stock" || stocktype == "Consign")
                {
                    if (!overrride_stock_comm && agentName != "Phil Scott")//Phil Scott, and potentially all disty sales should get their standard commission rate regardless of stocktype == stock.
                        InvoiceCommissionPercent = .1;
                }
            }

            //Get Split commission if present, return 0 if no split            
            double standardSplit = context.TheSysRz.TheProfitLogic.GetStandardSplitCommission(context, dr);
            double listAcquisitionSplit = context.TheSysRz.TheProfitLogic.GetListAcquisitionSplitPercentage(context, dr);

            if (splitType == SM_Enums.SplitCommissionType.standard_split.ToString())
                return standardSplit;
            else if (splitType == SM_Enums.SplitCommissionType.list_acquisition.ToString())
                return listAcquisitionSplit;
            else           

            //Return Overall invoice commission minus any splits (splits can be zero)
            return InvoiceCommissionPercent - standardSplit - listAcquisitionSplit;


        }

        public virtual void PayrollDeductionLineAdd(ContextRz context, CommissionReport c, DataRow dr)
        {
            if (dr == null)
                return;
            //Customer
            string cust_name = nData.NullFilter_String(dr["customer_name"]);
            string cust_uid = nData.NullFilter_String(dr["customer_uid"]);
            //Sales Order
            string ordernumber_sales = nData.NullFilter_String(dr["ordernumber_sales"]);
            string orderid_sales = nData.NullFilter_String(dr["orderid_sales"]);
            //Invoice
            string ordernumber_invoice = nData.NullFilter_String(dr["ordernumber_invoice"]);
            string orderid_invoice = nData.NullFilter_String(dr["orderid_invoice"]);
            //PayRoll Deduction
            string pd_date = FilterDate(nData.NullFilter_DateTime(dr["date_created"]));
            string pd_name = nData.NullFilter_String(dr["name"]);
            string pd_desc = nData.NullFilter_String(dr["description"]);
            string pd_amount = Tools.Number.MoneyFormat_2_6(nData.NullFilter_Double(dr["amount"]));

            //Line Layout
            ReportLine l = new ReportLine();
            l.Set(0, cust_name, new ItemTag("company", cust_uid)); //Company Name
            l.Set(1, ordernumber_sales, new ItemTag("ordhed_sales", orderid_sales)); // Sale
            l.Set(2, ordernumber_invoice, new ItemTag("ordhed_invoice", orderid_invoice)); //Invoice
            l.Set(3, pd_date);//Pay Date                     
            l.Set(4, context.TheSys.CurrencySymbol + pd_amount);//Deductions               
            l.Set(5, pd_name); //Gross Profit
            l.Set(8, pd_desc); //Net Percent   

            //Add the lines
            Lines.Add(l);
        }

        ////KT Calculate the sum of the unique HeaderPayments
        public double calc_TotalPaid(Dictionary<string, double> HeaderPayments2)
        {
            double TotalPaid = Convert.ToDouble(HeaderPayments2.Sum(p => p.Value));
            return TotalPaid;
        }

        protected string FilterDate(DateTime d)
        {
            if (d == null)
                return "&nbsp;";
            if (!Tools.Dates.DateExists(d))
                return "&nbsp;";
            return d.ToShortDateString();
        }


    }

}
