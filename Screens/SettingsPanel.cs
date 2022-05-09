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
    public partial class SettingsPanel : UserControl, ICompleteLoad
    {
        private ContextRz TheContext
        {
            get { return RzWin.Context; }
        }
        //Constructors
        public SettingsPanel()
        {
            InitializeComponent();
        }
        //Public Functions
        public void CompleteLoad()
        {
            chkDistributedOrders.Checked = n_set.GetSetting_Boolean(RzWin.Context, "use_distributed_orders");
            ShowButton();
            chkMergedQuotes.Checked = n_set.GetSetting_Boolean(RzWin.Context, "use_merged_quotes");
            chkUpdateFromNetwork.Checked = n_set.GetSetting_Boolean(RzWin.Context, "use_network_update");
            ctlUpdateFolder.SetValue(n_set.GetSetting_Boolean(RzWin.Context, "update_folder"));
            ctlFaxIP.SetValue(n_set.GetSetting_Boolean(RzWin.Context, "fax_server_ip"));
            chkQBsPosting.Checked = n_set.GetSetting_Boolean(RzWin.Context, "allow_qbs_posting");
            ShowCards();
        }
        //Private Functions
        private void ShowButton()
        {
            cmdConvertToDistributed.Enabled = RzWin.User.IsDeveloper() && chkDistributedOrders.Checked;
        }
        private void ConvertToDistributedOrders()
        {
            RzWin.Context.Reorg();
            //RzWin.Leader.StartPopStatus();
            //RzWin.Leader.Comment("Converting orders to the distributed system...");

            //ordhed.ShowOriginalOrderTables(TheContext);

            //ordhed.ConvertDistributedOrders(TheContext, "quote");
            //ordhed.ConvertDistributedOrders(TheContext, "rfq");
            //ordhed.ConvertDistributedOrders(TheContext, "service");
            //ordhed.ConvertDistributedOrders(TheContext, "sales");
            //ordhed.ConvertDistributedOrders(TheContext, "purchase");
            //ordhed.ConvertDistributedOrders(TheContext, "invoice");
            //ordhed.ConvertDistributedOrders(TheContext, "vendrma");
            //ordhed.ConvertDistributedOrders(TheContext, "rma");

            ////add the indexes
            //ArrayList a = new ArrayList();
            //RzWin.Logic.GetRz3OrderIndexes(a);
            //foreach (String s in a)
            //{
            //    RzWin.Context.Execute(s, true);
            //}

            //ordhed.HideOriginalOrderTables(TheContext);

            //RzWin.Leader.Comment("Converting templates...");
            //ordhed.ConvertTemplatesForDist(TheContext);

            //RzWin.Leader.Comment("Conversion complete.");
            //RzWin.Leader.StopPopStatus(true);
        }
        private void SaveCards()
        {
            TheContext.SetSetting("creditcard_1", ctlCC1.GetValue_String());
            TheContext.SetSetting("creditcard_2", ctlCC2.GetValue_String());
            TheContext.SetSetting("creditcard_3", ctlCC3.GetValue_String());
            TheContext.SetSetting("creditcard_4", ctlCC4.GetValue_String());
            RzWin.Logic.InitCreditCards(RzWin.Context);
        }
        private void ShowCards()
        {
            ctlCC1.SetValue(RzWin.Logic.CreditCard_1);
            ctlCC2.SetValue(RzWin.Logic.CreditCard_2);
            ctlCC3.SetValue(RzWin.Logic.CreditCard_3);
            ctlCC4.SetValue(RzWin.Logic.CreditCard_4);
        }
        //Control Events
        private void chkDistributedOrders_CheckedChanged(object sender, EventArgs e)
        {
            TheContext.SetSettingBoolean("use_distributed_orders", chkDistributedOrders.Checked);
            //RzWin.Logic.UseDistributedOrders = chkDistributedOrders.Checked; 
            ShowButton();
        }
        private void chkMergedQuotes_CheckedChanged(object sender, EventArgs e)
        {
            TheContext.SetSettingBoolean("use_merged_quotes", chkMergedQuotes.Checked);
            RzWin.Logic.UseMergedQuotes = chkMergedQuotes.Checked;
        }
        //Buttons
        private void cmdConvertToDistributed_Click(object sender, EventArgs e)
        {
            if (!RzWin.Leader.AreYouSure("permanently convert the order system"))
                return;
            RzWin.Leader.Tell("This is a permanent change, and will remove all of the orders currently in the distributed system.");
            if (!RzWin.Leader.AreYouSure("continue, for real"))
                return;
            ConvertToDistributedOrders();
        }
        private void cmdCreateViews_Click(object sender, EventArgs e)
        {
            DoCreateViews();
        }
        private void DoCreateViews()
        {
            DoCreateViews(RzWin.Context);
        }
        private void DoCreateViews(ContextRz x)
        {
            ordhed.CreateOrderViews(x);
            x.TheLeader.TellTemp("Done.");
        }
        private void cmdDropViews_Click(object sender, EventArgs e)
        {
            DoDropOrderViews();
        }
        private void DoDropOrderViews()
        {
            DoDropOrderViews(RzWin.Form.TheContextNM);
        }
        private void DoDropOrderViews(ContextNM x)
        {
            ordhed.DropOrderViews(x);
            x.TheLeader.TellTemp("Done.");
        }
        private void cmdHideOriginalTables_Click(object sender, EventArgs e)
        {
            ordhed.HideOriginalOrderTables(TheContext);
        }
        private void cmdShowOriginalTables_Click(object sender, EventArgs e)
        {
            ordhed.ShowOriginalOrderTables(TheContext);
        }
        private void cmdApplyUpdates_Click(object sender, EventArgs e)
        {
            TheContext.SetSettingBoolean("use_network_update", chkUpdateFromNetwork.Checked);
            TheContext.SetSetting("update_folder", ctlUpdateFolder.GetValue_String());
        }
        private void cmdApplyCC_Click(object sender, EventArgs e)
        {
            SaveCards();
        }
        private void cmdConvertTemplates_Click(object sender, EventArgs e)
        {
            ordhed.ConvertTemplatesForDist(TheContext);
        }
        private void cmdRestoreTemplates_Click(object sender, EventArgs e)
        {
            ordhed.RestoreTemplatesFromDist(TheContext);
        }
        private void cmdApplyFax_Click(object sender, EventArgs e)
        {
            TheContext.SetSetting("fax_server_ip", ctlFaxIP.GetValue_String());
            TheContext.SetSetting("fax_prefix_#", ctlFaxPrefix.GetValue_String());
        }
        private void cmdReqBatches_Click(object sender, EventArgs e)
        {
            //reqbatch.ConvertAllToDealHeaders();
        }
        private void cmdMergeReqs_Click(object sender, EventArgs e)
        {
            //req.ConvertAllToQuoteLines();
        }
        private void cmdSeparateQuotes_Click(object sender, EventArgs e)
        {
            //quote.ConvertGivingToQuoteLines();
        }
        private void cmdQuoteIDs_Click(object sender, EventArgs e)
        {
            //quote.SetAllQuoteIDs();
        }
        private void cmdUpdateBatchLinks_Click(object sender, EventArgs e)
        {
            //req.UpdateBatchLinks();
        }
        private void cmdSeparateBids_Click(object sender, EventArgs e)
        {
            //quote.ConvertReceivingToRFQLines();
        }
        private void cmdCreateDealCompanies_Click(object sender, EventArgs e)
        {
            dealcompany.CreateMissingDealCompanies(TheContext);
        }
        private void cmdUPSWorldship_Click(object sender, EventArgs e)
        {
            frmWorldShipSettings xForm = new frmWorldShipSettings();
            xForm.CompleteLoad();
            xForm.ShowDialog();
        }
        private void cmdInsertUPSServices_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("UPS-Next Day Air Early AM");
            sb.AppendLine("UPS-Next Day Air");
            sb.AppendLine("UPS-Next Day Air Saver");
            sb.AppendLine("UPS-2nd Day Air AM");
            sb.AppendLine("UPS-2nd Day Air");
            sb.AppendLine("UPS-3 Day Select");
            sb.AppendLine("UPS-Ground Service");
            Tools.FileSystem.PopText(sb.ToString());
        }
        private void chkQBsPosting_CheckedChanged(object sender, EventArgs e)
        {
            TheContext.SetSettingBoolean("allow_qbs_posting", chkQBsPosting.Checked);
        }
    }
}
