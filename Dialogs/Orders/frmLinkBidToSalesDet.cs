using System.Windows.Forms;
using Core;
using Rz5;

namespace RzInterfaceWin.Dialogs
{
    public partial class frmLinkBidToSalesDet : Form
    {
        //Public Variables
        public Rz5.orddet_rfq TheRFQ = null;

        //Constructors
        public frmLinkBidToSalesDet()
        {
            InitializeComponent();
        }
        //Public Functions
        public bool CompleteLoad(string deal_uid)
        {
            if (!Tools.Strings.StrExt(deal_uid))
                return false;
            lv.ShowTemplate("link_bid_to_so", "orddet_rfq", true);
            lv.ShowData("orddet_rfq", "base_dealdetail_uid = '" + deal_uid + "' and status != 'canceled'", "");
            return true;
        }
        //Control Events
        private void lv_AboutToAdd(object sender, Core.AddArgs args)
        {
            args.Handled = true;
            TheRFQ = (Rz5.orddet_rfq)lv.GetSelectedObject();
            if (TheRFQ == null)
            {
                RzWin.Context.Leader.Tell("You need to select a bid to continue.");
                return;
            }
            Close();
        }
        private void lv_AboutToThrow(Context context, ShowArgs args)
        {
            args.Handled = true;
        }
    }
}
