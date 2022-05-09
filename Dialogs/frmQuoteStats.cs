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
    public partial class frmQuoteStats : Form
    {
        //Private Variables
        private string TheID = "";
        private bool IsDeal
        {
            get
            {
                return Tools.Strings.StrCmp("base_dealheader_uid", prop);
            }
            set
            {
                if (value)
                    prop = "base_dealheader_uid";
                else
                    prop = "unique_id";                
            }
        }
        private string prop = "unique_id";
        private StringBuilder HTML;

        //Constructors
        public frmQuoteStats()
        {
            InitializeComponent();
        }
        //Public Functions
        public bool CompleteLoad(string id, bool is_deal)
        {
            if (!Tools.Strings.StrExt(id))
                return false;
            TheID = id;
            IsDeal = is_deal;
            SetCaption();
            HTML = new StringBuilder();
            GetResults();
            DisplayHTML();
            return true;
        }

        private void GetResults()
        {
            ArrayList a = RzWin.Context.QtC("orddet_quote", "select * from orddet_quote where " + prop + " = '" + TheID + "'");
            if (a == null)
                return;
            foreach (orddet_quote q in a)
            {
                AddOneQuote(q);
            }
        }
        private void SetCaption()
        {
            if (IsDeal)
                this.Text = SetCaption_Batch();
            else
                this.Text = SetCaption_Quote();
        }
        private string SetCaption_Quote()
        {
            orddet_quote q = orddet_quote.GetById(RzWin.Context, TheID);
            if (q == null)
                return "Quote Stats";
            return q.ToString();
        }
        private string SetCaption_Batch()
        {
            dealheader d = dealheader.GetById(RzWin.Context, TheID);
            if (d == null)
                return "Quote Stats";
            return d.ToString();
        }
        private void AddOneQuote(orddet_quote q)
        {
            string date = "";
            if (!IsDeal)
                q.UpdateQuoteStats(RzWin.Context);
            HTML.AppendLine("<table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
            HTML.AppendLine("  <tr>");
            HTML.AppendLine("    <td width=\"100%\" bgcolor=\"#E1E1E1\">" + q.GetTreeCaption(RzWin.Context, true) + "</td>");
            HTML.AppendLine("  </tr>");
            HTML.AppendLine("  <tr>");
            HTML.AppendLine("    <td width=\"100%\" bgcolor=\"#E1E1E1\">");
            HTML.AppendLine("      <table border=\"0\" width=\"100%\" cellpadding=\"0\" cellspacing=\"10\">");
            HTML.AppendLine("        <tr>");
            HTML.AppendLine("          <td width=\"25%\" valign=\"top\" bgcolor=\"#E1E1E1\">");
            HTML.AppendLine("            <table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
            HTML.AppendLine("              <tr>");
            HTML.AppendLine("                <td width=\"50%\" bgcolor=\"#000080\"><b><font color=\"#FFFFFF\">Stock");
            HTML.AppendLine("                  Matches</font></b></td>");
            HTML.AppendLine("                <td width=\"50%\" align=\"right\" bgcolor=\"#FFFFFF\"><font color=\"#FF0000\"><b>" + q.stock_matches.ToString() + "</b></font></td>");
            HTML.AppendLine("              </tr>");
            HTML.AppendLine("              <tr>");
            HTML.AppendLine("                <td width=\"50%\" bgcolor=\"#000080\"><b><font color=\"#FFFFFF\">Excess");
            HTML.AppendLine("                  Matches</font></b></td>");
            HTML.AppendLine("                <td width=\"50%\" align=\"right\" bgcolor=\"#FFFFFF\"><font color=\"#0000FF\"><b>" + q.excess_matches.ToString() + "</b></font></td>");
            HTML.AppendLine("              </tr>");
            HTML.AppendLine("              <tr>");
            HTML.AppendLine("                <td width=\"50%\" bgcolor=\"#000080\"><b><font color=\"#FFFFFF\">Consign");
            HTML.AppendLine("                  Matches</font></b></td>");
            HTML.AppendLine("                <td width=\"50%\" align=\"right\" bgcolor=\"#FFFFFF\"><font color=\"#008000\"><b>" + q.consign_matches.ToString() + "</b></font></td>");
            HTML.AppendLine("              </tr>");
            HTML.AppendLine("            </table>");
            HTML.AppendLine("          </td>");
            HTML.AppendLine("          <td width=\"25%\" bgcolor=\"#E1E1E1\">");
            HTML.AppendLine("            <table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
            HTML.AppendLine("              <tr>");
            HTML.AppendLine("                <td width=\"50%\" bgcolor=\"#000080\"><b><font color=\"#FFFFFF\">Sales");
            HTML.AppendLine("                  Matches</font></b></td>");
            HTML.AppendLine("                <td width=\"50%\" align=\"right\" bgcolor=\"#FFFFFF\"><b><font color=\"#FF0000\">" + q.sale_matches.ToString() + "</font></b></td>");
            HTML.AppendLine("              </tr>");
            HTML.AppendLine("              <tr>");
            HTML.AppendLine("                <td width=\"50%\" bgcolor=\"#000080\"><b><font color=\"#FFFFFF\">Sales");
            HTML.AppendLine("                  Average " + RzWin.Context.TheSys.CurrencySymbol + "</font></b></td>");
            HTML.AppendLine("                <td width=\"50%\" align=\"right\" bgcolor=\"#FFFFFF\"><b><font color=\"#008000\">" + RzWin.Context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(q.sale_average) + "</font></b></td>");
            HTML.AppendLine("              </tr>");
            HTML.AppendLine("              <tr>");
            HTML.AppendLine("                <td width=\"50%\" bgcolor=\"#000080\"><b><font color=\"#FFFFFF\">Sales");
            HTML.AppendLine("                  Min " + RzWin.Context.TheSys.CurrencySymbol + "</font></b></td>");
            HTML.AppendLine("                <td width=\"50%\" align=\"right\" bgcolor=\"#FFFFFF\"><b><font color=\"#008000\">" + RzWin.Context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(q.sale_min) + "</font></b></td>");
            HTML.AppendLine("              </tr>");
            HTML.AppendLine("              <tr>");
            HTML.AppendLine("                <td width=\"50%\" bgcolor=\"#000080\"><b><font color=\"#FFFFFF\">Sales");
            HTML.AppendLine("                  Max " + RzWin.Context.TheSys.CurrencySymbol + "</font></b></td>");
            HTML.AppendLine("                <td width=\"50%\" align=\"right\" bgcolor=\"#FFFFFF\"><b><font color=\"#008000\">" + RzWin.Context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(q.sale_max) + "</font></b></td>");
            HTML.AppendLine("              </tr>");
            HTML.AppendLine("              <tr>");
            HTML.AppendLine("                <td width=\"50%\" bgcolor=\"#000080\"><b><font color=\"#FFFFFF\">Sales");
            HTML.AppendLine("                  Earliest</font></b></td>");
            date = "";
            if (Tools.Dates.DateExists(q.sale_earliest))
                date = q.sale_earliest.ToShortDateString();
            HTML.AppendLine("                <td width=\"50%\" align=\"right\" bgcolor=\"#FFFFFF\"><b>" + date + "</b></td>");
            HTML.AppendLine("              </tr>");
            HTML.AppendLine("              <tr>");
            HTML.AppendLine("                <td width=\"50%\" bgcolor=\"#000080\"><b><font color=\"#FFFFFF\">Sales");
            HTML.AppendLine("                  Latest</font></b></td>");
            date = "";
            if (Tools.Dates.DateExists(q.sale_latest))
                date = q.sale_latest.ToShortDateString();
            HTML.AppendLine("                <td width=\"50%\" align=\"right\" bgcolor=\"#FFFFFF\"><b>" + date + "</b></td>");
            HTML.AppendLine("              </tr>");
            HTML.AppendLine("            </table>");
            HTML.AppendLine("          </td>");
            HTML.AppendLine("          <td width=\"25%\" bgcolor=\"#FFFFFF\">");
            HTML.AppendLine("            <table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
            HTML.AppendLine("              <tr>");
            HTML.AppendLine("                <td width=\"50%\" bgcolor=\"#000080\"><b><font color=\"#FFFFFF\">Purchase");
            HTML.AppendLine("                  Matches</font></b></td>");
            HTML.AppendLine("                <td width=\"50%\" align=\"right\" bgcolor=\"#E1E1E1\"><b><font color=\"#FF0000\">" + q.purchase_matches.ToString() + "</font></b></td>");
            HTML.AppendLine("              </tr>");
            HTML.AppendLine("              <tr>");
            HTML.AppendLine("                <td width=\"50%\" bgcolor=\"#000080\"><b><font color=\"#FFFFFF\">Purchase");
            HTML.AppendLine("                  Average " + RzWin.Context.TheSys.CurrencySymbol + "</font></b></td>");
            HTML.AppendLine("                <td width=\"50%\" align=\"right\" bgcolor=\"#E1E1E1\"><b><font color=\"#008000\">" + RzWin.Context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(q.purchase_average) + "</font></b></td>");
            HTML.AppendLine("              </tr>");
            HTML.AppendLine("              <tr>");
            HTML.AppendLine("                <td width=\"50%\" bgcolor=\"#000080\"><b><font color=\"#FFFFFF\">Purchase");
            HTML.AppendLine("                  Min " + RzWin.Context.TheSys.CurrencySymbol + "</font></b></td>");
            HTML.AppendLine("                <td width=\"50%\" align=\"right\" bgcolor=\"#E1E1E1\"><b><font color=\"#008000\">" + RzWin.Context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(q.purchase_min) + "</font></b></td>");
            HTML.AppendLine("              </tr>");
            HTML.AppendLine("              <tr>");
            HTML.AppendLine("                <td width=\"50%\" bgcolor=\"#000080\"><b><font color=\"#FFFFFF\">Purchase");
            HTML.AppendLine("                  Max " + RzWin.Context.TheSys.CurrencySymbol + "</font></b></td>");
            HTML.AppendLine("                <td width=\"50%\" align=\"right\" bgcolor=\"#E1E1E1\"><b><font color=\"#008000\">" + RzWin.Context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(q.purchase_max) + "</font></b></td>");
            HTML.AppendLine("              </tr>");
            HTML.AppendLine("              <tr>");
            HTML.AppendLine("                <td width=\"50%\" bgcolor=\"#000080\"><b><font color=\"#FFFFFF\">Purchase");
            HTML.AppendLine("                  Earliest</font></b></td>");
            date = "";
            if (Tools.Dates.DateExists(q.purchase_earliest))
                date = q.purchase_earliest.ToShortDateString();
            HTML.AppendLine("                <td width=\"50%\" align=\"right\" bgcolor=\"#E1E1E1\"><b>" + date + "</b></td>");
            HTML.AppendLine("              </tr>");
            HTML.AppendLine("              <tr>");
            HTML.AppendLine("                <td width=\"50%\" bgcolor=\"#000080\"><b><font color=\"#FFFFFF\">Purchase");
            HTML.AppendLine("                  Latest</font></b></td>");
            date = "";
            if (Tools.Dates.DateExists(q.purchase_latest))
                date = q.purchase_latest.ToShortDateString();
            HTML.AppendLine("                <td width=\"50%\" align=\"right\" bgcolor=\"#E1E1E1\"><b>" + date + "</b></td>");
            HTML.AppendLine("              </tr>");
            HTML.AppendLine("            </table>");
            HTML.AppendLine("          </td>");
            HTML.AppendLine("          <td width=\"25%\" bgcolor=\"#E1E1E1\">");
            HTML.AppendLine("            <table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
            HTML.AppendLine("              <tr>");
            HTML.AppendLine("                <td width=\"50%\" bgcolor=\"#000080\"><b><font color=\"#FFFFFF\">Quote");
            HTML.AppendLine("                  Matches</font></b></td>");
            HTML.AppendLine("                <td width=\"50%\" align=\"right\" bgcolor=\"#FFFFFF\"><b><font color=\"#FF0000\">" + q.quote_matches.ToString() + "</font></b></td>");
            HTML.AppendLine("              </tr>");
            HTML.AppendLine("              <tr>");
            HTML.AppendLine("                <td width=\"50%\" bgcolor=\"#000080\"><b><font color=\"#FFFFFF\">Quote");
            HTML.AppendLine("                  Average " + RzWin.Context.TheSys.CurrencySymbol + "</font></b></td>");
            HTML.AppendLine("                <td width=\"50%\" align=\"right\" bgcolor=\"#FFFFFF\"><b><font color=\"#008000\">" + RzWin.Context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(q.quote_average) + "</font></b></td>");
            HTML.AppendLine("              </tr>");
            HTML.AppendLine("              <tr>");
            HTML.AppendLine("                <td width=\"50%\" bgcolor=\"#000080\"><b><font color=\"#FFFFFF\">Quote");
            HTML.AppendLine("                  Min " + RzWin.Context.TheSys.CurrencySymbol + "</font></b></td>");
            HTML.AppendLine("                <td width=\"50%\" align=\"right\" bgcolor=\"#FFFFFF\"><b><font color=\"#008000\">" + RzWin.Context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(q.quote_min) + "</font></b></td>");
            HTML.AppendLine("              </tr>");
            HTML.AppendLine("              <tr>");
            HTML.AppendLine("                <td width=\"50%\" bgcolor=\"#000080\"><b><font color=\"#FFFFFF\">Quote");
            HTML.AppendLine("                  Max " + RzWin.Context.TheSys.CurrencySymbol + "</font></b></td>");
            HTML.AppendLine("                <td width=\"50%\" align=\"right\" bgcolor=\"#FFFFFF\"><b><font color=\"#008000\">" + RzWin.Context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(q.quote_max) + "</font></b></td>");
            HTML.AppendLine("              </tr>");
            HTML.AppendLine("              <tr>");
            HTML.AppendLine("                <td width=\"50%\" bgcolor=\"#000080\"><b><font color=\"#FFFFFF\">Quote");
            HTML.AppendLine("                  Earliest</font></b></td>");
            date = "";
            if (Tools.Dates.DateExists(q.quote_earliest))
                date = q.quote_earliest.ToShortDateString();
            HTML.AppendLine("                <td width=\"50%\" align=\"right\" bgcolor=\"#FFFFFF\"><b>" + date + "</b></td>");
            HTML.AppendLine("              </tr>");
            HTML.AppendLine("              <tr>");
            HTML.AppendLine("                <td width=\"50%\" bgcolor=\"#000080\"><b><font color=\"#FFFFFF\">Quote");
            HTML.AppendLine("                  Latest</font></b></td>");
            date = "";
            if (Tools.Dates.DateExists(q.quote_latest))
                date = q.quote_latest.ToShortDateString();
            HTML.AppendLine("                <td width=\"50%\" align=\"right\" bgcolor=\"#FFFFFF\"><b>" + date + "</b></td>");
            HTML.AppendLine("              </tr>");
            HTML.AppendLine("            </table>");
            HTML.AppendLine("          </td>");
            HTML.AppendLine("        </tr>");
            HTML.AppendLine("      </table>");
            HTML.AppendLine("    </td>");
            HTML.AppendLine("  </tr>");
            HTML.AppendLine("</table>");
            HTML.AppendLine("<table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
            HTML.AppendLine("  <tr>");
            HTML.AppendLine("    <td width=\"100%\"></td>");
            HTML.AppendLine("  </tr>");
            HTML.AppendLine("</table>");
        }
        private void DisplayHTML()
        {
            if (!Tools.Strings.StrExt(HTML.ToString()))
                HTML.Append("<font color=\"red\">No Results!");
            wb.ReloadWB();
            wb.Add(HTML.ToString());
        }
    }
}
