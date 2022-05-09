using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace Rz5
{
    public partial class Scan_BF_RFQs : UserControl, ICompleteLoad 
    {
        //Private Variables
        private ContextRz TheContext
        {
            get
            {
                return RzWin.Context;
            }
        }
        private SysRz5 xSys
        {
            get
            {
                return RzWin.Context.Sys;
            }
        }
        private Boolean RFQs = false;
        private Dictionary<String, orddet_rfq> dMatched = new Dictionary<string, orddet_rfq>();
        private Dictionary<String, ArrayList> dSessions = new Dictionary<String, ArrayList>();

        //Constructors
        public Scan_BF_RFQs()
        {
            InitializeComponent();
        }
        public Scan_BF_RFQs(Boolean bRFQ)
        {
            InitializeComponent();
            RFQs = bRFQ;
        }
        //Public Functions
        public void CompleteLoad()
        {
            if (RFQs)
            {
                cmdScan.Text = "Scan RFQs";
                ShowLV();
                cmdNavigateToPurchaseInbox.Visible = false;
                cmdSave.Visible = false;
                cmdMatch.Visible = false;
            }
            else
            {
                cmdScan.Text = "Scan Bids";
                lv.Visible = true;
                lv.BringToFront();
                lvReqs.Visible = false;
            }
            wb.Navigate("www.brokerforum.com");
            //if (Rz3App.xLogic.IsAAT)
            //    DoBFLogin();
            lv.ShowTemplate("brokerforum_quotes", "orddet_rfq", RzWin.User.TemplateEditor);
            lvReqs.ShowTemplate("brokerforum_rfqs2", "orddet_quote", RzWin.User.TemplateEditor);
            ClearQuotes();
            lv.InhibitNotify();
            SetStatus("");
            wb.WaitForDone();
            cmdScan.Enabled = true;
            lvParts.ShowTemplate("PARTSEARCH", "partrecord", RzWin.User.TemplateEditor);
        }
        public void DoResize()
        {
            try
            {
                sp.Top = 0;
                sp.Left = 0;
                sp.Width = this.ClientRectangle.Width;
                sp.Height = this.ClientRectangle.Height - sb.Height;

                gb.Top = 0;
                gb.Left = 0;
                gb.Height = sp.Panel2.ClientRectangle.Height;

                ts.Top = pb.Height;
                ts.Left = gb.Right;
                ts.Height = sp.Panel2.ClientRectangle.Height;
                ts.Width = sp.Panel2.ClientRectangle.Width - ts.Left;

                wb2.Top = 0;
                wb2.Left = 0;
                wb2.Width = pageResult.ClientRectangle.Width - gb.Width;
                
                lv.Top = wb2.Bottom;
                lv.Left = 0;
                lv.Width = pageResult.ClientRectangle.Width;
                lv.Height = pageResult.ClientRectangle.Height - lv.Top;

                pb.Left = 0;
                pb.Top = 0;
                pb.Width = sp.Panel2.ClientRectangle.Width;

                lvReqs.Top = lv.Top;
                lvReqs.Left = lv.Left;
                lvReqs.Width = lv.Width;
                lvReqs.Height = lv.Height;

                lvParts.Left = 0;
                lvParts.Top = 0;
                lvParts.Width = pageSearch.ClientRectangle.Width;
                lvParts.Height = pageSearch.ClientRectangle.Height;

            }
            catch { }
        }
        //Private Functions
        private Boolean DoBFLogin()
        {
            try
            {
                multisearch_login m = multisearch_login.GetById(RzWin.Context, RzWin.Context.SelectScalarString("select unique_id from multisearch_login where isnull(website,'') = 'brokerforum' and isnull(is_companyinfo,0) = 1"));
                if (m == null)
                    return false;
                if (RFQs)
                {
                    if (wb.GetDocument().body.innerText.Contains("Manage Sales and Prepare Quotations"))
                        return true;
                }
                else
                {
                    if (wb.GetDocument().body.innerText.Contains("Manage Purchases and Receive Quotations"))
                        return true;
                }
                if (!wb.SetTextBox("Session_Username", m.username))
                    return false;
                if (!wb.SetTextBox("Session_Password", m.password))
                    return false;
                if (!wb.ClickElement("a", "Log In", "Logon", "", "", true))
                    return false;
                if (wb.SetTextBox("Session_Username", m.username))
                    return false;
                if (RFQs)
                {
                    wb.Navigate("http://www.brokerforum.com/bf?en/DESKTOP.PRESENTATION/OPEN_DESKTOP_VIEW/SALES_INBOX");
                    wb.WaitForDone();
                }
                else
                {
                    wb.Navigate("http://www.brokerforum.com/bfrfqman?/DESKTOP.PRESENTATION/OPEN_DESKTOP_VIEW/PURCHASES_INBOX");
                    wb.WaitForDone();
                }
                return true;
            }
            catch (Exception ee)
            {
                RzWin.Leader.Tell("Error: " + ee.Message);
                return false;
            }
        }
        private void ShowLV()
        {
            lv.Visible = false;
            lvReqs.Visible = true;
            lvReqs.BringToFront();
        }
        private void ClearQuotes()
        {
            //RzWin.Context.TheLeader.Error("reorg");
            lv.CurrentItems = null; //?
            //lv.CurrentItems.Clear(TheContext); //?
            lv.CollectionMode = true;
            lv.RefreshFromCollection();
        }
        private void MatchToRFQs()
        {
            //frmMatchToRFQs xMatch = new frmMatchToRFQs();
            //xMatch.CompleteLoad(xSys, "", lv.GetObjectsByColor(Color.Red));
            //xMatch.ShowDialog();
            //dMatched = xMatch.aMatched;
            //if (dMatched.Count > 0)
            //{
            //    SaveBids(true);
            //    dMatched = new Dictionary<string, orddet_quote>();
            //}
        }
        private void SetStatus(String status)
        {
            RzWin.Leader.Comment(status);
            lblStatus.Text = status;
            sb.Refresh();
        }
        private Boolean NavigateToPurchaseInbox()
        {
            wb.Navigate("http://www.brokerforum.com/bfrfqman?/DESKTOP.PRESENTATION/OPEN_DESKTOP_VIEW/PURCHASES_INBOX");
            wb.WaitForDone();
            try
            {
                Boolean b = wb.GetDocument().url.Equals("http://www.brokerforum.com/bfrfqman?/DESKTOP.PRESENTATION/OPEN_DESKTOP_VIEW/PURCHASES_INBOX");
                return b;
            }
            catch (Exception)
            { return false; }
        }
        private Boolean DoScan()
        {
            try
            {
                SetStatus("Starting scan...");
                ClearQuotes();
                if (!IsPurchasePage())
                {
                    RzWin.Leader.Tell("This is not the 'Manage Purchases and Receive Quotations' page. You can get there from the button on the left after logging into Brokerforum.");
                    SetStatus("This is not the 'Manage Purchases and Receive Quotations' page. You can get there from the button on the left after logging into Brokerforum.");
                    return false;
                }
                Boolean b = ParseTables();
                SetStatus("Done.");
                return b;
            }
            catch (Exception ex)
            {
                RzWin.Leader.Tell("There was an error scanning this page: " + ex.Message);
                SetStatus("There was an error scanning this page: " + ex.Message);
                return false;
            }
        }
        private Boolean DoRFQScan()
        {
            SetStatus("Starting scan...");
            ClearQuotes();
            if (!IsRFQPage())
            {
                RzWin.Leader.Tell("This is not the 'Manage Sales and Prepare Quotations' page. You can get there from the button on the left after logging into Brokerforum.");
                SetStatus("This is not the 'Manage Sales and Prepare Quotations' page. You can get there from the button on the left after logging into Brokerforum.");
                return false;
            }
            Boolean b = ParseRFQTables();
            //Set LV to show the reqbatches
            if (dSessions.Count > 0)
            {
                lvReqs.ShowData("orddet_quote", GetReqWhere(), "orddet_quote.companyname", SysNewMethod.ListLimitDefault);
            }
            SetStatus("Done.");
            return b;
        }
        private Boolean IsPurchasePage()
        {
            String body = wb.GetDocument().body.innerHTML;
            if (body.Contains("Manage Purchases and Receive Quotations") && body.Contains("Sales Inbox"))
                return true;
            return false;
        }
        private Boolean IsRFQPage()
        {
            String body = wb.GetDocument().body.innerHTML;
            //Tools.FileSystem.PopText(body);
            if (body.Contains("Manage Sales and Prepare Quotations") && body.Contains("Purchases Inbox"))
                return true;
            return false;
        }
        private Boolean ParseTables()
        {
            try
            {
                StringBuilder sTable = new StringBuilder();
                foreach (mshtml.IHTMLElement e in wb.GetDocument().all)
                {
                    if (Tools.Strings.StrCmp(e.tagName, "table"))
                    {
                        mshtml.HTMLTable t = (mshtml.HTMLTable)e;
                        if (t.innerText != null)
                        {
                            if (t.innerText.Contains("They Show:") && t.innerText.Contains("From:"))
                            {
                                if (sTable.Length > 0)
                                {
                                    wb2.ReloadWB();
                                    wb2.Add(sTable.ToString());
                                    wb2.Refresh();
                                    ScanOneCompany();
                                    sTable = new StringBuilder();
                                    sTable.Append("<TABLE>" + t.innerHTML + "</TABLE>");
                                }
                                else
                                {
                                    sTable.Append("<TABLE>" + t.innerHTML + "</TABLE>");
                                }
                            }
                            else if (t.innerText.Contains("They Show:") && !(t.innerText.Contains("From:")))
                            {
                                sTable.Append("<TABLE>" + t.innerHTML + "</TABLE>");
                            }
                        }
                    }
                }
                if (sTable.Length > 0)
                {
                    wb2.ReloadWB();
                    wb2.Add(sTable.ToString());
                    wb2.Refresh();
                    ScanOneCompany();
                    sTable = new StringBuilder();
                }
                return true;
            }
            catch (Exception)
            { return false; }
        }
        private Boolean ParseRFQTables()
        {
            try
            {
                StringBuilder sTable = new StringBuilder();
                foreach (mshtml.IHTMLElement e in wb.GetDocument().all)
                {
                    if (Tools.Strings.StrCmp(e.tagName, "table"))
                    {
                        mshtml.HTMLTable t = (mshtml.HTMLTable)e;
                        if (t.innerText != null)
                        {
                            if (t.innerText.Contains("You Show:") && t.innerText.Contains("From:"))
                            {
                                if (sTable.Length > 0)
                                {
                                    wb2.ReloadWB();
                                    wb2.Add(sTable.ToString());
                                    wb2.Refresh();
                                    ScanOneCompanyRFQ();
                                    sTable = new StringBuilder();
                                    sTable.Append("<TABLE>" + t.innerHTML + "</TABLE>");
                                }
                                else
                                {
                                    sTable.Append("<TABLE>" + t.innerHTML + "</TABLE>");
                                }
                            }
                            else if (t.innerText.Contains("You Show:") && !(t.innerText.Contains("From:")))
                            {
                                sTable.Append("<TABLE>" + t.innerHTML + "</TABLE>");
                            }
                        }
                    }
                }
                if (sTable.Length > 0)
                {
                    wb2.ReloadWB();
                    wb2.Add(sTable.ToString());
                    wb2.Refresh();
                    ScanOneCompanyRFQ();
                    sTable = new StringBuilder();
                }
                return true;
            }
            catch (Exception)
            { return false; }
        }
        private orddet_rfq GetCompanyHeaderInfo()
        {
            try
            {
                foreach (mshtml.IHTMLElement e in wb2.GetDocument().all)
                {
                    if (Tools.Strings.StrCmp(e.tagName, "table"))
                    {
                        mshtml.HTMLTable t = (mshtml.HTMLTable)e;
                        if (t.innerText.Contains("From:"))
                        {
                            foreach (mshtml.HTMLTableRow r in t.rows)
                            {
                                if (!(r.innerText == null))
                                {
                                    if (r.innerText.Contains("From:"))
                                    {
                                        orddet_rfq q = orddet_rfq.New(RzWin.Context);
                                        String parse = "";
                                        for (Int32 i = 0; i < r.cells.length; i++)
                                        {
                                            parse = ParseCellText(r, i);
                                            if (parse.Contains("Phone:"))
                                                break;
                                        }
                                        q.companyname = GetCompanyName(parse);
                                        q.contactname = GetContactName(parse);
                                        q.original_vendor_name = GetPhone(parse); //userdata_03
                                        q.status = GetFax(parse); //userdata_04
                                        return q;
                                    }
                                }
                            }
                        }
                    }
                }
                return null;
            }
            catch { return null; }
        }
        private orddet_quote GetCompanyRFQHeaderInfo(ContextNM context)
        {
            try
            {
                foreach (mshtml.IHTMLElement e in wb2.GetDocument().all)
                {
                    if (Tools.Strings.StrCmp(e.tagName, "table"))
                    {
                        mshtml.HTMLTable t = (mshtml.HTMLTable)e;
                        if (t.innerText.Contains("From:"))
                        {
                            foreach (mshtml.HTMLTableRow r in t.rows)
                            {
                                if (!(r.innerText == null))
                                {
                                    if (r.innerText.Contains("From:"))
                                    {
                                        orddet_quote rfq = (orddet_quote)context.Item("orddet_quote");
                                        String parse = "";
                                        for (Int32 i = 0; i < r.cells.length; i++)
                                        {
                                            parse = ParseCellText(r, i);
                                            if (parse.Contains("Phone:"))
                                                break;
                                        }
                                        rfq.companyname = GetCompanyName(parse);
                                        rfq.contactname = GetContactName(parse);
                                        rfq.original_vendor_name = GetPhone(parse); //companyphone
                                        rfq.status = GetFax(parse); //companyfax
                                        return rfq;
                                    }
                                }
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception)
            { return null; }
        }
        private Boolean ScanOneCompany()
        {
            //RzWin.Context.TheLeader.Error("reorg");
            //return false;
            orddet_rfq xMainQuote = null;
            orddet_rfq xQuote = null;
            orddet_quote xReq = null;
            Boolean bOffer = false;
            xMainQuote = GetCompanyHeaderInfo();
            if (xMainQuote == null)
                return false;
            try
            {
                foreach (mshtml.IHTMLElement e in wb2.GetDocument().all)
                {
                    if (Tools.Strings.StrCmp(e.tagName, "table"))
                    {
                        mshtml.HTMLTable t = (mshtml.HTMLTable)e;
                        foreach (mshtml.HTMLTableRow r in t.rows)
                        {
                            if (!(r.innerText == null))
                            {
                                mshtml.IHTMLElement cell = GetCell(r, 1);
                                if (cell == null)
                                    goto NxT;
                                if (cell.innerText != null)
                                {
                                    switch (cell.innerText.ToLower().Trim())
                                    {
                                        case "you need:":
                                            xReq = orddet_quote.New(RzWin.Context);
                                            xReq.fullpartnumber = ParseCellText(r, 4);
                                            xReq.target_quantity = Convert.ToInt32(ParseCellLong(r, 7));
                                            xReq.manufacturer = ParseCellText(r, 5);
                                            xReq.datecode = ParseCellText(r, 6);
                                            xReq.target_price = ParseCellDouble(r, 8);
                                            xReq.ordernumber = ParseCellText(r, 3);//ReqDate (was user_defined)
                                            bOffer = false;
                                            break;
                                        case "they offer:":
                                            //MessageBox.Show("reorg");                                            
                                            xQuote = orddet_rfq.New(RzWin.Context);
                                            xQuote.status_notes = "Scan_BF_RFQs"; //source
                                            xQuote.companyname = xMainQuote.companyname;
                                            xQuote.contactname = xMainQuote.contactname;
                                            xQuote.original_vendor_name = xMainQuote.original_vendor_name; //userdata_03
                                            xQuote.status = xMainQuote.status; //userdata_04
                                            xQuote.fullpartnumber = ParseCellText(r, 4);
                                            if (!Tools.Strings.StrExt(xQuote.fullpartnumber))
                                                xQuote.fullpartnumber = xReq.fullpartnumber;
                                            xQuote.quantityordered = Convert.ToInt32(ParseCellLong(r, 7));
                                            xQuote.manufacturer = ParseCellText(r, 5);
                                            xQuote.datecode = ParseCellText(r, 6);
                                            xQuote.unitprice = ParseCellDouble(r, 8);
                                            xQuote.ordernumber = ParseCellText(r, 3); //QuoteDate (was userdata_01)
                                            bOffer = true;                                           
                                            break;
                                        case "note:":
                                            if (bOffer)
                                                xQuote.quicknote = ParseCellText(r, 3);
                                            else
                                                xReq.description = ParseCellText(r, 3);
                                            break;
                                        case "terms:":
                                            if (bOffer)
                                                xQuote.warranty_period = ParseCellText(r, 3); //userdata_02
                                            else
                                                xReq.warranty_period = ParseCellText(r, 3); //userdefined_1
                                            break;
                                    }
                                }
                            }
                        NxT: ;
                        }
                        if (xQuote != null)
                        {
                            xQuote.MyReq = xReq;
                            AddBid(xQuote);
                        }
                    }
                }
                return true;
            }
            catch { return false; }
        }
        private Boolean ScanOneCompanyRFQ()
        {
            //RzWin.Context.TheLeader.Error("reorg");
            //return false;
            orddet_quote xMainReq = GetCompanyRFQHeaderInfo(RzWin.Context);
            orddet_quote rfq = (orddet_quote)RzWin.Context.Item("orddet_quote");
            if (xMainReq == null)
            {
                RzWin.Leader.Tell("This rfq has no company information! Cannot Import.");
                return false;
            }
            try
            {
                foreach (mshtml.IHTMLElement e in wb2.GetDocument().all)
                {
                    if (Tools.Strings.StrCmp(e.tagName, "table"))
                    {
                        mshtml.HTMLTable t = (mshtml.HTMLTable)e;
                        foreach (mshtml.HTMLTableRow r in t.rows)
                        {
                            if (r.innerText != null)
                            {
                                if (r.innerText.Contains("From:") && r.innerText.Contains("Phone:") && r.innerText.Contains("Fax:"))
                                    continue;
                                mshtml.IHTMLElement cell = GetCell(r, 1);
                                if (cell == null)
                                    continue;
                                if (cell.innerText == null)
                                    continue;
                                if (!Tools.Strings.StrExt(cell.innerText))
                                    continue;
                                if (cell.innerText.Contains("Note:"))
                                {
                                    rfq.internalcomment = ParseCellText(r, 3).Trim();
                                    continue;
                                }
                                if (cell.innerText.Contains("Terms:"))
                                {
                                    rfq.description = ParseCellText(r, 3).Trim();
                                    continue;
                                }
                                if (cell.innerText.Contains("You Show:"))
                                {
                                    rfq.alternatepart = ParseCellText(r, 4).Trim();
                                    if (Tools.Strings.StrExt(rfq.alternatepart))
                                        rfq.alternatepartstripped = PartObject.StripPart(rfq.alternatepart);
                                    continue;
                                }
                                if (!cell.innerText.Contains("They Need:"))
                                    continue;
                                rfq.fullpartnumber = ParseCellText(r, 4).Trim();
                                String number = ParseCellText(r, 7).Trim();
                                if (!Tools.Number.IsNumeric(number))
                                    number = "0";
                                rfq.quantityordered = Int32.Parse(number);
                                rfq.manufacturer = ParseCellText(r, 5).Trim();
                                rfq.datecode = ParseCellText(r, 6).Trim();
                                number = ParseCellText(r, 8).Trim();
                                if (!Tools.Number.IsNumeric(number))
                                    number = "0";
                                rfq.target_price = Double.Parse(number);
                                String date = GetDateString(ParseCellText(r, 3).Trim());
                                if (Tools.Dates.IsDate(date))
                                {
                                    rfq.orderdate = DateTime.Parse(date);
                                }
                                else
                                {
                                    rfq.orderdate = DateTime.Now;
                                }
                                rfq.date_created = rfq.orderdate;
                                rfq.source = "Brokerforum_Scan Broker RFQ";
                            }
                        }
                        rfq.companyname = xMainReq.companyname;
                        rfq.contactname = xMainReq.contactname;
                        rfq.original_vendor_name = xMainReq.original_vendor_name; //companyphone
                        rfq.status = xMainReq.status; //companyfax
                        rfq.base_mc_user_uid = RzWin.User.unique_id;
                        if (Tools.Strings.StrExt(rfq.companyname))
                            rfq.base_company_uid = TryAddCompany(rfq);
                        if (Tools.Strings.StrExt(rfq.base_company_uid) && Tools.Strings.StrExt(rfq.fullpartnumber) && rfq.quantityordered > 0)
                        {
                            rfq.Insert(RzWin.Context);
                            AddToReqBatch(rfq);
                            rfq = (orddet_quote)RzWin.Context.Item("orddet_quote");
                        }
                        else
                        {
                            RzWin.Leader.Tell("There was an error pulling in this req.\r\nCompanyName: " + rfq.companyname + "\r\nCompanyID: " + rfq.base_company_uid + "\r\nPartNumber: " + rfq.fullpartnumber + "\r\nTargetQty: " + rfq.target_quantity);
                            return false;
                        }
                    }
                }
                return true;
            }
            catch { return false; }
        }
        private String GetDateString(String date)
        {
            try
            {
                String hold = date;
                String days = "";
                String hours = "";
                String mins = "";
                if (date.Contains("d"))
                {
                    days = Tools.Strings.ParseDelimit(date, "d", 1).Trim();
                    hold = Tools.Strings.ParseDelimit(date, "d", 2).Trim();
                }
                if (date.Contains("h"))
                {
                    hours = Tools.Strings.ParseDelimit(hold, "h", 1).Trim();
                    hold = Tools.Strings.ParseDelimit(hold, "h", 2).Trim();
                }
                if (date.Contains("m"))
                {
                    mins = Tools.Strings.ParseDelimit(hold, "m", 1).Trim();
                }
                TimeSpan tSpan = new TimeSpan();
                Int32 totalmins = 0;
                if (Tools.Strings.StrExt(days))
                {
                    if (Tools.Number.IsNumeric(days))
                    {
                        Int32 d = Int32.Parse(days);
                        tSpan = new TimeSpan(d, 0, 0, 0);
                        totalmins += (Int32)tSpan.TotalMinutes;
                    }
                }
                if (Tools.Strings.StrExt(hours))
                {
                    if (Tools.Number.IsNumeric(hours))
                    {
                        Int32 h = Int32.Parse(hours);
                        tSpan = new TimeSpan(0, h, 0, 0);
                        totalmins += (Int32)tSpan.TotalMinutes;
                    }
                }
                if (Tools.Strings.StrExt(mins))
                {
                    if (Tools.Number.IsNumeric(mins))
                    {
                        Int32 m = Int32.Parse(mins);
                        tSpan = new TimeSpan(0, 0, m, 0);
                        totalmins += (Int32)tSpan.TotalMinutes;
                    }
                }
                tSpan = new TimeSpan(0, totalmins, 0);
                DateTime dTime = DateTime.Now;
                dTime = dTime.Subtract(tSpan);
                return dTime.ToString();
            }
            catch (Exception)
            { return ""; }
        }
        private String GetCompanyName(String sIn)
        {
            String j = Tools.Strings.Split(sIn, ", Phone:")[0].ToString().Trim();
            String[] s = Tools.Strings.Split(j, ",");
            String b = "";
            for (Int32 i = 1; i < s.Length; i++)
            {
                if (i == 1)
                    b = s[i].ToString();
                else
                    b = b + "," + s[i].ToString();
            }
            if (Tools.Strings.HasString(b, "country:"))
                b = Tools.Strings.ParseDelimit(b, ", Country:", 1).Trim();
            return b.Trim();
        }
        private String GetContactName(String sIn)
        {
            String j = Tools.Strings.Split(sIn, ", Phone:")[0].ToString().Trim();
            return Tools.Strings.Split(j, ",")[0].ToString().Trim();
        }
        private String GetPhone(String sIn)
        {
            String j = Tools.Strings.Split(sIn, ", Phone:")[1].ToString().Trim();
            return Tools.Strings.Split(j, ", Fax:")[0].ToString().Trim();
        }
        private String GetFax(String sIn)
        {
            String j = Tools.Strings.Split(sIn, ", Phone:")[1].ToString().Trim();
            return Tools.Strings.Split(j, ", Fax:")[1].ToString().Trim();
        }
        private void AddBid(orddet_rfq b)
        {
            //RzWin.Context.TheLeader.Error("reorg");
            if (!Tools.Strings.StrExt(b.unique_id))
                b.unique_id = Tools.Strings.GetNewID();
            if (lv.CurrentItems == null)
                lv.CurrentItems = new Core.ItemsInstance();
            lv.CurrentItems.Add(TheContext, b);
            lv.RefreshFromCollection();
            lv.Refresh();
        }
        private Boolean SaveBids(Boolean bOnlyRed)
        {
            //RzWin.Context.TheLeader.Error("reorg");
            //return false;
            try
            {
                if (lv.CurrentItems == null || lv.CurrentItems.CountGet(TheContext) <= 0)
                {
                    RzWin.Leader.Tell("Please scan bids from Brokerforum before saving.");
                    return false;
                }
                if (!RzWin.Leader.AreYouSure("save these bids"))
                    return false;
                RzWin.Leader.StartPopStatus();
                foreach (Core.IItem i in lv.CurrentItems.AllGet(TheContext))
                {
                    orddet_rfq q = (orddet_rfq)i;
                    if (q == null)
                        continue;
                    if (bOnlyRed)
                    {
                        if (nTools.GetColorFromInt(q.grid_color).ToArgb() == Color.Red.ToArgb())
                            SaveBid(q);
                    }
                    else
                        SaveBid(q);
                }
                RzWin.Leader.Comment("Done.");
                RzWin.Leader.StopPopStatus(true);
                lv.RefreshFromCollection();
                return true;
            }
            catch (Exception ex)
            {
                RzWin.Leader.Tell("There was an error saving these bids: " + ex.Message);
                return false;
            }
        }
        private Boolean SaveBids()
        {
            return SaveBids(false);
        }
        private void SaveBid(orddet_rfq q)
        {
            //RzWin.Context.TheLeader.Error("reorg");
            try
            {
                if (!Tools.Strings.StrExt(q.companyname))
                    return;
                //q.QuoteType = Rz4.Enums.QuoteType.Receiving;
                ArrayList bids = new ArrayList();
                company c = (company)company.GetByName(RzWin.Context, q.companyname);
                if (c == null)
                    c = (company)company.GetByDistilledName(RzWin.Context, company.DistillCompanyName(q.companyname));
                if (c == null)
                {
                    RzWin.Leader.Comment("Creating company " + q.companyname);
                    c = company.New(RzWin.Context);
                    //if (Rz3App.xLogic.IsAAT)
                    //    c.companytype = "Vendor";
                    //else
                        c.companytype = "Broker";
                    c.companyname = q.companyname;
                    c.primaryphone = q.original_vendor_name; //userdata_03;
                    c.primaryfax = q.status; //userdata_04;
                    c.Insert(RzWin.Context);
                }
                q.base_company_uid = c.unique_id;
                q.grid_color = System.Drawing.Color.Red.ToArgb();
                String strReq = PartObject.StripPart(q.fullpartnumber);
                if (strReq.Length > 2)
                {
                    String strSQL = "select * from orddet_quote where replace(replace(replace(prefix, '-', ''), '#', ''), '.', '') + basenumberstripped = '" + RzWin.Context.Filter(strReq) + "' and orderdate >= cast('" + nTools.DateFormat(System.DateTime.Now.Subtract(TimeSpan.FromDays(30))) + "' as datetime) order by orderdate desc";
                    if (ToolsWin.Keyboard.GetControlAndShiftKeys())
                    {
                        ToolsWin.Clipboard.SetClip(strSQL);
                        RzWin.Leader.Tell("SQL: " + strSQL);
                    }
                    ArrayList reqs = AddMatchedToArray(q.unique_id, RzWin.Context.QtC("orddet_quote", strSQL));
                    if (reqs.Count > 0)
                    {
                        foreach (orddet_quote r in reqs)
                        {
                            orddet_rfq existing = (orddet_rfq)RzWin.Context.QtO("orddet_rfq", "select * from orddet_rfq where the_orddet_quote_uid = '" + r.unique_id + "' and companyname = '" + RzWin.Context.Filter(q.companyname) + "' and quantityordered = " + q.quantityordered.ToString() + " and fullpartnumber = '" + RzWin.Context.Filter(q.fullpartnumber) + "'");
                            if (existing == null)
                            {
                                existing = (orddet_rfq)RzWin.Context.QtO("orddet_rfq", "select * from orddet_rfq where orderdate >= cast('" + nTools.DateFormat(System.DateTime.Now.Subtract(TimeSpan.FromDays(30))) + "' as datetime) and the_orddet_quote_uid = '' and companyname = '" + RzWin.Context.Filter(q.companyname) + "' and quantityordered = " + q.quantityordered.ToString() + " and fullpartnumber = '" + RzWin.Context.Filter(q.fullpartnumber) + "'");
                                if (existing == null)
                                {
                                    q.grid_color = System.Drawing.Color.Blue.ToArgb();
                                    orddet_rfq xbid = (orddet_rfq)q.CloneValues(RzWin.Context);
                                    xbid.the_orddet_quote_uid = r.unique_id;
                                    //xbid.sessionid = r.unique_id;
                                    bids.Add(xbid);
                                }
                                else
                                {
                                    q.grid_color = System.Drawing.Color.Blue.ToArgb();
                                    //existing.sessionid = r.unique_id;
                                    existing.the_orddet_quote_uid = r.unique_id;
                                    existing.Update(RzWin.Context);
                                    SetStatus("Linked existing bid " + existing.ToString());
                                }
                            }
                            else
                            {
                                q.grid_color = System.Drawing.Color.Violet.ToArgb();
                            }
                        }
                    }
                    else
                    {
                        RzWin.Leader.Comment("Requirements for " + q.MyReq.fullpartnumber + " could not be found.");
                        orddet_rfq xq = (orddet_rfq)RzWin.Context.QtO("orddet_rfq", "select * from orddet_rfq where companyname = '" + RzWin.Context.Filter(q.companyname) + "' and quantityordered = " + q.quantityordered.ToString() + " and fullpartnumber = '" + RzWin.Context.Filter(q.fullpartnumber) + "'");
                        if (xq == null)
                            bids.Add(q);
                    }
                }
                else
                {
                    RzWin.Leader.Comment("The bid for " + q.MyReq.fullpartnumber + " did not have enough of a part number to look for reqs.");
                    orddet_rfq xq2 = (orddet_rfq)RzWin.Context.QtO("orddet_rfq", "select * from orddet_rfq where companyname = '" + RzWin.Context.Filter(q.companyname) + "' and quantityordered = " + q.quantityordered.ToString() + " and fullpartnumber = '" + RzWin.Context.Filter(q.fullpartnumber) + "'");
                    if (xq2 == null)
                        bids.Add(q);
                }
                if (bids.Count > 0)
                {
                    foreach (orddet_rfq bid in bids)
                    {
                        int color = bid.grid_color;
                        String uid = bid.unique_id;
                        bid.grid_color = 0;
                        bid.unique_id = "";
                        bid.Insert(RzWin.Context);
                        bid.grid_color = color;
                    }
                    RzWin.Leader.Comment("Saved bid from " + q.companyname + " for " + q.fullpartnumber);
                }
            }
            catch { }
        }
        private ArrayList AddMatchedToArray(String uid, ArrayList aIn)
        {
            try
            {
                if (dMatched.Count <= 0)
                    return aIn;
                ArrayList a = new ArrayList(aIn);
                orddet_rfq r = null;
                dMatched.TryGetValue(uid, out r);
                if (r != null)
                    a.Add(r);
                return a;
            }
            catch { return aIn; }
        }
        private String ParseCellText(mshtml.HTMLTableRow r, int i)
        {
            try
            {
                return GetCellText(r, i);
            }
            catch (Exception)
            {
                return "";
            }
        }
        private long ParseCellLong(mshtml.HTMLTableRow r, int i)
        {
            try
            {
                String s = GetCellText(r, i);
                if (Tools.Number.IsNumeric(s))
                    return Convert.ToInt64(s);
                else
                    return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        private Double ParseCellDouble(mshtml.HTMLTableRow r, int i)
        {
            try
            {
                String s = GetCellText(r, i).Replace("$", "").Trim();
                s = nTools.StripNonNumeric(s, true);
                if (Tools.Number.IsNumeric(s))
                    return Convert.ToDouble(s);
                else
                    return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        private DateTime ParseCellDate(mshtml.HTMLTableRow r, int i)
        {
            try
            {
                String s = GetCellText(r, i);
                if (Tools.Dates.IsDate(s))
                    return Convert.ToDateTime(s);
                else
                    return Tools.Dates.GetNullDate();
            }
            catch (Exception)
            {
                return Tools.Dates.GetNullDate();
            }
        }
        private String GetCellText(mshtml.HTMLTableRow r, int i)
        {
            int j = 0;
            foreach (mshtml.IHTMLElement cell in r.cells)
            {
                if (j == i)
                {
                    if (cell.innerText != null)
                        return cell.innerText.Trim();
                    else
                        return "";
                }
                j++;
            }
            return "";
        }
        private mshtml.IHTMLElement GetCell(mshtml.HTMLTableRow r, int i)
        {
            int j = 0;
            foreach (mshtml.IHTMLElement cell in r.cells)
            {
                if (j == i)
                {
                    return cell;
                }
                j++;
            }
            return null;
        }
        private String GetReqBatchWhere()
        {
            try
            {
                String where = "";
                //foreach (KeyValuePair<String, reqbatch> kvp in dSessions)
                //{
                //    if (!Tools.Strings.StrExt(where))
                //        where += "'" + kvp.Value.unique_id + "'";
                //    else
                //        where += ",'" + kvp.Value.unique_id + "'";
                //}
                //if (Tools.Strings.StrExt(where))
                //    where = " unique_id in (" + where + ")";
                return where;
            }
            catch { return ""; }
        }
        private String GetReqWhere()
        {
            try
            {
                String where = "";
                foreach (KeyValuePair<String, ArrayList> kvp in dSessions)
                {
                    foreach (orddet_quote d in kvp.Value)
                    {
                        if (!Tools.Strings.StrExt(where))
                            where += "'" + d.unique_id + "'";
                        else
                            where += ",'" + d.unique_id + "'";
                    }
                }
                if (Tools.Strings.StrExt(where))
                    where = " unique_id in (" + where + ")";
                return where;
            }
            catch { return ""; }
        }
        private void AddToReqBatch(orddet_quote r)
        {
            try
            {
                ArrayList rb = null;
                dSessions.TryGetValue(r.companyname, out rb);
                if (rb != null)
                {
                    rb.Add(r);
                    //r.AbsorbBatch(rb);
                    //r.ISave();
                    return;
                }
                rb = new ArrayList();
                //rb.companyname = r.companyname;
                //rb.contactname = r.contactname;
                //rb.base_company_uid = r.base_company_uid;
                //rb.batchname = "Imported Batch From ICSuorce - " + r.datetaken;
                //rb.batchnumber = rb.GetNextBatchNumber();
                //rb.base_mc_user_uid = Rz3App.xUser.unique_id;
                //rb.ISave();
                dSessions.Add(r.companyname, rb);
                rb.Add(r);
                //r.base_reqbatch_uid = rb.unique_id;
                //r.ISave();
            }
            catch (Exception)
            { }
        }
        private String TryAddCompany(orddet_quote r)
        {
            try
            {
                company c = (company)company.GetByName(RzWin.Context, r.companyname);
                if (c == null)
                    c = (company)company.GetByDistilledName(RzWin.Context, company.DistillCompanyName(r.companyname));
                if (c == null)
                {
                    RzWin.Leader.Comment("Creating company " + r.companyname);
                    c = company.New(RzWin.Context);
                    //if (Rz3App.xLogic.IsAAT)
                    //    c.companytype = "Vendor";
                    //else
                        c.companytype = "Broker";
                    c.isvendor = true;
                    c.iscustomer = false;
                    c.companyname = r.companyname;
                    c.primaryphone = r.original_vendor_name; //companyphone
                    c.primaryfax = r.status; //companyfax
                    c.Insert(RzWin.Context);
                }
                return c.unique_id;
            }
            catch { return ""; }
        }
        //Buttons
        private void cmdScan_Click(object sender, EventArgs e)
        {
            try
            {
                dMatched = new Dictionary<string, orddet_rfq>();
                String s = wb.GetPageText();
                if (RFQs)
                {
                    DoRFQScan();
                }
                else
                {
                    DoScan();
                }
            }
            catch (Exception)
            { }
        }
        private void cmdSave_Click(object sender, EventArgs e)
        {
            SaveBids();
        }
        private void cmdNavigateToPurchaseInbox_Click(object sender, EventArgs e)
        {
            NavigateToPurchaseInbox();
        }
        private void cmdMatch_Click(object sender, EventArgs e)
        {
            MatchToRFQs();
        }
        private void cmdSearch_Click(object sender, EventArgs e)
        {
            String strPart = PartObject.StripPart(txtSearch.Text.Trim());
            if (!Tools.Strings.StrExt(strPart))
                return;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" partrecord.stocktype in ('stock', 'excess', 'oem', 'consign', 'consigned') ");
            ArrayList a = PartObject.GetSearchPermutations(TheContext, strPart, SearchComparison.Normal, true, true, false, false, false);
            if (a.Count > 0)
            {
                sb.AppendLine(" and ( ");
                sb.Append(PartObject.BuildWhere(a));
                sb.AppendLine(" ) ");
            }
            lvParts.ShowData("partrecord", sb.ToString(), "fullpartnumber", SysNewMethod.ListLimitDefault);
            ts.SelectedIndex = 1;
        }
        //Control Events
        private void Scan_BF_RFQs_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void optReqBatch_CheckedChanged(object sender, EventArgs e)
        {
            ShowLV();
        }
        private void sp_SplitterMoved(object sender, SplitterEventArgs e)
        {
            DoResize();
        }
        private void lvReqs_ObjectClicked(object sender, ObjectClickArgs args)
        {
            //try
            //{
            //    req r = (req)args.GetObject();
            //    txtSearch.Text = r.fullpartnumber;
            //}
            //catch (Exception)
            //{ }
        }
    }
}
