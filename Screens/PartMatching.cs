using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace Rz5
{
    public partial class PartMatching : UserControl, ICompleteLoad
    {
        //Public Variables
        public SysNewMethod xSys
        {
            get
            {
                return TheContext.xSys;
            }
        }
        public ContextNM TheContext
        {
            get
            {
                return RzWin.Context;
            }
        }
        public String CurrentTemplate = "";
        public String CurrentClass = "";
        public String CurrentWhere = "";
        public String CurrentOrder = "";
        public String CurrentTables = "";
        //Private Variables
        private Enums.MatchType CurrentType;
        private ImportInventory TheImportLogic;
        
        //Constructors
        public PartMatching()
        {
            InitializeComponent();
        }
        //Public Functions
        public void CompleteLoad()
        {
            TheImportLogic = RzWin.Logic.GetImportInventoryLogic();
            LoadView();
            CheckScreen();
            LoadImports();
            //if (Rz3App.xLogic.IsAAT)
            //    optOffers.Visible = true;
        }
        public void DoResize()
        {
            try
            {
                gb.Left = 0;
                gbMatch.Left = 0;
                gbQuantity.Left = 0;

                ts.Top = 0;
                ts.Left = gb.Right;
                //dv.Height = this.ClientRectangle.Height / 2;
                ts.Width = this.ClientRectangle.Width - ts.Left;

                lvImports.Width = pageInternal.ClientRectangle.Width - (lvImports.Left * 2);

                lv.Top = ts.Bottom;
                lv.Left = gb.Left;
                lv.Height = this.ClientRectangle.Height - lv.Top;
                lv.Width = this.ClientRectangle.Width - lv.Left;
            }
            catch (Exception)
            { }
        }
        public String GetWhere(String strTable, String strQuantityField, String strExtra, String strDateField)
        {
            String s = "";
            if (optExactPart.Checked)
                s = strTable + ".fullpartnumber = x.fullpartnumber";
            else if (optPartStripped.Checked)
                s = "(" + strTable + ".prefix + " + strTable + ".basenumberstripped) = (x.prefix + x.basenumberstripped) ";
            else if (optBaseStripped.Checked)
                s = strTable + ".basenumber = x.basenumber";
            else if (optBaseStripped.Checked)
                s = strTable + ".basenumberstripped = x.basenumberstripped";
            else if (optExactBase.Checked)
                s = strTable + ".basenumber = x.basenumber";

            if (chkQuantity.Checked)
                s += " and " + strTable + "." + strQuantityField + " >= x.quantity";

            if (Tools.Dates.DateExists(dtStart.GetValue_Date()))
                s += " and " + strTable + "." + strDateField + " >= cast('" + Tools.Dates.DateFormatRegardlessOfWindowsSettings(nTools.GetStartDate(dtStart.GetValue_Date(), Tools.CubeInterval.Day)) + "' as datetime)";

            if (Tools.Dates.DateExists(dtEnd.GetValue_Date()))
                s += " and " + strTable + "." + strDateField + " <= cast('" + Tools.Dates.DateFormatRegardlessOfWindowsSettings(Tools.Dates.GetEndDate(dtEnd.GetValue_Date(), Tools.CubeInterval.Day)) + "' as datetime)";
            
            if (Tools.Strings.StrExt(strExtra))
                s += " and " + strExtra;

            return s;
        }
        public String GetStockTypeRestrictions()
        {
            if (chkStock.Checked && chkConsignments.Checked && chkExcess.Checked)
                return "";

            String s = "";
            if (chkStock.Checked)
            {
                if (Tools.Strings.StrExt(s))
                    s += ", ";
                s += "'stock'";
            }

            if (chkConsignments.Checked)
            {
                if (Tools.Strings.StrExt(s))
                    s += ", ";
                s += "'consign', 'consigned'";
            }

            if (chkExcess.Checked)
            {
                if (Tools.Strings.StrExt(s))
                    s += ", ";
                s += "'oem', 'excess'";
            }

            return "partrecord.stocktype in (" + s + ")";
        }
        //Private Functions
        private void CheckScreen()
        {
            chkStock.Enabled = optInventory.Checked;
            chkConsignments.Enabled = optInventory.Checked;
            chkExcess.Enabled = optInventory.Checked;

            if (optInventory.Checked)
            {
                dv.SetAcceptCaption("Match With Inventory");
                CurrentClass = "partrecord";
                CurrentWhere = GetWhere("partrecord", "quantity", GetStockTypeRestrictions(), "datecreated");
                CurrentOrder = "partrecord.fullpartnumber, partrecord.manufacturer";
            }

            if (optReqs.Checked)
            {
                dv.SetAcceptCaption("Match With Requirements");
                CurrentClass = "req";
                CurrentWhere = GetWhere("req", "targetquantity", "", "datecreated");
                CurrentOrder = "req.fullpartnumber, req.datecreated";

            }

            if (optQuickQuotes.Checked)
            {
                dv.SetAcceptCaption("Match With Quick Quotes");
                CurrentClass = "quote";
                CurrentWhere = GetWhere("quote", "quotequantity", "quotetype = 'giving out'", "quotedate");
                CurrentOrder = "quote.fullpartnumber, quote.quotedate";
            }

            if (optBids.Checked)
            {
                dv.SetAcceptCaption("Match With Bids");
                CurrentClass = "quote";
                CurrentWhere = GetWhere("quote", "quotequantity", "quotetype = 'receiving'", "quotedate");
                CurrentOrder = "quote.fullpartnumber, quote.quotedate";
            }

            if (optSales.Checked)
            {
                dv.SetAcceptCaption("Match With Sales");
                CurrentClass = "orddet";
                CurrentWhere = GetWhere("orddet", "quantityordered", "ordertype in ('sales', 'invoice')", "orderdate");
                CurrentOrder = "orddet.fullpartnumber, orddet.orderdate";
            }

            if (optPurchase.Checked)
            {
                dv.SetAcceptCaption("Match With Purchases");
                CurrentClass = "orddet";
                CurrentWhere = GetWhere("orddet", "quantityordered", "ordertype in ('purchase')", "orderdate");
                CurrentOrder = "orddet.fullpartnumber, orddet.orderdate";
            }

            CurrentTemplate = "batch_matching_" + CurrentClass;
        }
        private void LoadView()
        {
            dv.CompleteLoad();
            dv.AddCommonField("fullpartnumber", "Part Number", TheImportLogic.PartNumberAliases, true);
            dv.AddCommonField("quantity", "Quantity", TheImportLogic.QuantityAliases, false);
            dv.AddCommonField("manufacturer", "Manufacturer", TheImportLogic.ManufacturerAliases);
            dv.AddCommonField("datecode", "Date Code", TheImportLogic.DateCodeAliases);
            dv.AddCommonField("price", "Price", TheImportLogic.PriceAliases);
            dv.AddCommonField("alternatepart", "Alternate Part #", TheImportLogic.AlternatePartAliases);
            dv.AddCommonField("description", "Description", TheImportLogic.DescriptionAliases);
            dv.SetClass("partrecord");
            dv.Clear();
        }
        private void RunReport(Enums.MatchType t)
        {
            CurrentType = t;
            lv.Clear();
            CheckScreen();
            lv.ShowTemplate(CurrentTemplate, CurrentClass, RzWin.User.TemplateEditor);

            String strSQL = GetMatchSQL(t, false, "");

            if (!Tools.Strings.StrExt(strSQL))
                lv.Clear();
            else
                lv.ShowData(CurrentClass, strSQL);
        }
        private String GetMatchSQL(Enums.MatchType t, bool UidOnly, String strExtraWhere)
        {
            String strSQL = "";
            String strGroup = "";

            if (UidOnly)
            {
                strSQL = "select distinct(" + CurrentClass + ".unique_id)";
                strGroup = "";
            }
            else
            {
                strSQL = "select top 200 " + lv.GetSimpleFieldSQL();
                strGroup = lv.GetSimpleGroupSQL();
            }

            switch (t)
            {
                case Enums.MatchType.Imports:
                    String strImports = GetSelectedImports();
                    if (!Tools.Strings.StrExt(strImports))
                        strSQL = "";
                    else
                        strSQL += " from " + CurrentClass + " inner join " + (optOffers.Checked ? "offer" : "partrecord") + " x on " + CurrentWhere + " where isnull(x.fullpartnumber, '') > '' and isnull(x.importid, '') in (" + strImports + ")";
                    break;
                case Enums.MatchType.DataTable:
                    strSQL = "select * from " + CurrentClass + " inner join " + dv.CurrentTable.TableName + " x on " + CurrentWhere + " where isnull(x.fullpartnumber, '') > ''";
                    break;
            }

            if (Tools.Strings.StrExt(strSQL) && Tools.Strings.StrExt(strExtraWhere))
            {
                strSQL += " and " + strExtraWhere;
            }

            if (Tools.Strings.StrExt(strSQL) && Tools.Strings.StrExt(strGroup))
            {
                if (!strSQL.ToLower().StartsWith("select *"))
                {
                    string[] str = Tools.Strings.Split(CurrentOrder, ",");
                    foreach (string s in str)
                    {
                        if (!strGroup.ToLower().Contains(s.ToLower().Trim()))
                        {
                            if (Tools.Strings.StrExt(strGroup))
                                strGroup += ",";
                            strGroup += s;
                        }
                    }
                    strSQL += " group by " + strGroup;
                }
            }

            if (Tools.Strings.StrExt(strSQL) && !UidOnly)
                strSQL += " order by " + CurrentOrder;

            return strSQL;
        }
        private String GetSelectedImports()
        {
            String s = "";
            foreach (ListViewItem i in lvImports.CheckedItems)
            {
                if (Tools.Strings.StrExt(s))
                    s += ", ";
                s += "'" + RzWin.Context.Filter(i.Text) + "'";
            }
            return s;
        }
        private void LoadImports()
        {
            lvImports.BeginUpdate();
            lvImports.Items.Clear();
            try
            {
                DataTable dtPast = null;
                if (optOffers.Checked)
                    dtPast = TheImportLogic.GetImportOffersTable(RzWin.Context);
                else
                    dtPast = TheImportLogic.GetImportStatsTable(RzWin.Context);
                if (Tools.Data.DataTableExists(dtPast))
                {
                    foreach (DataRow r in dtPast.Rows)
                    {
                        ListViewItem i = lvImports.Items.Add(nData.NullFilter_String(r[0].ToString()));
                        i.SubItems.Add(Tools.Number.LongFormat(nData.NullFilter_Int64(r[1])));
                    }
                }
            }
            catch (Exception)
            { }
            lvImports.EndUpdate();
        }
        //Buttons
        private void cmdMatch_Click(object sender, EventArgs e)
        {
            if (lvImports.CheckedItems.Count <= 0)
            {
                TheContext.TheLeader.TellTemp("Please select at least one import before continuing.");
                return;
            }
            RunReport(Enums.MatchType.Imports);
        }
        private void cmdNotify_Click(object sender, EventArgs e)
        {
            String s = GetMatchSQL(CurrentType, true, "");
            String strSQL = "select distinct(agentname) from " + CurrentClass + " where " + CurrentClass + ".unique_id in ( " + s + ") and isnull(agentname, '') > '' order by agentname";
            DataTable d = RzWin.Context.Select(strSQL);
            if (!Tools.Data.DataTableExists(d))
            {
                TheContext.TheLeader.TellTemp("No results.");
                return;
            }

            foreach (DataRow r in d.Rows)
            {
                String strAgent = nData.NullFilter_String(r[0]);
                NewMethod.n_user u = NewMethod.n_user.GetByName(RzWin.Context, strAgent);
                if (u != null)
                {
                    strSQL = GetMatchSQL(CurrentType, false, CurrentClass + ".agentname = '" + RzWin.Context.Filter(strAgent) + "'");
                    String strHTML = "<h2>" + u.name + "</h2><hr><br>" + nData.ConvertDataTableToHTML(RzWin.Context.Select(strSQL));
                    String err = "";
                    //ToolsOffice.OutlookOffice.SendOutlookMessage(u.email_address, strHTML, "Matches", false, true, "", "", false, null, "", "", "", "", ref err);
                    //return context.TheSysRz.TheEmailLogic.SendOutlookEmail(strAddress, strHeader + strFooter, strSubject, false, true, "", AttachmentFileString, false, null, strBCC, strFromAddress, "", context.xUser.email_signature, true, ref err);

                }
            }
            TheContext.TheLeader.TellTemp("Done.");
        }
        //ControlEvents
        private void opt_CheckedChanged(object sender, EventArgs e)
        {
            CheckScreen();
        }
        private void dv_Accept()
        {
            if (!dv.CurrentTable.HasColumnField("basenumberstripped"))
            {
                dv.CurrentTable.ForceTableMode(RzWin.Context);
                dv.CurrentTable.SetActualFieldNames(RzWin.Context);

                long l = 0;
                PartObject.ParsePartNumber(RzWin.Context, dv.CurrentTable, true, ref l);
                dv.ShowTable();
            }

            RunReport(Enums.MatchType.DataTable);
        }
        private void PartMatching_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void optOffers_CheckedChanged(object sender, EventArgs e)
        {
            LoadImports();
        }
        private void optImports_CheckedChanged(object sender, EventArgs e)
        {
            LoadImports();
        }
    }

    namespace Enums
    {
        public enum MatchType
        {
            Imports = 1,
            Reqs = 2,
            DataTable = 3,
        }
    }
}
