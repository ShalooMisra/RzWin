using System;
using System.Windows.Forms;
using NewMethod;

namespace Rz5
{
    public partial class frmChooseFQSO : Form
    {
        //Public Variables
        public ordhed TheOrder;
        //Private Variables
        private ContextRz TheContext;
        private String TheCompID = "";

        private string TheOrdhedType = null;      

        //Constructors
        public frmChooseFQSO()
        {
            InitializeComponent();
        }
        //Public Static Functions
        public static ordhed ChooseFormalQuoteSalesOrder(ContextRz x, string company_id)
        {
            frmChooseFQSO f = new frmChooseFQSO();
            f.CompleteLoad(x, company_id);
            f.ShowDialog();
            return f.TheOrder;
        }
        //Public Functions
        public void CompleteLoad(ContextRz x, string company_id)
        {
            TheContext = x;
            TheCompID = company_id;
            LoadLV();
        }

        public void CompleteLoad(ContextRz x, string company_id, string ordhedType)
        {
            TheContext = x;
            TheCompID = company_id;
            TheOrdhedType = ordhedType;
            LoadLV();
        }
        //Private Functions       
        private void LoadLV()
        {
            
          

            try
            {
                ListArgs args = new ListArgs(TheContext);
                args.AddAllow = false;
                args.TheLimit = 200;
                args.TheOrder = "orderdate desc";

                switch(TheOrdhedType)
                {
                    case "FormalQuote":
                         args.TheCaption = "Formal Quotes";
                        args.TheClass = "ordhed_quote";
                        args.TheTable = "ordhed_quote";
                        args.TheTemplate = "ordhed_choose_for_add_quote";
                        break;
                    case "SalesOrder":
                        args.TheCaption = "Sales Orders";
                        args.TheClass = "ordhed_sales";
                        args.TheTable = "ordhed_sales";
                        args.TheTemplate = "ordhed_choose_for_add_quote";
                        break;
                }
               
                if (Tools.Strings.StrExt(TheCompID))
                    args.TheWhere = "base_company_uid = '" + TheCompID + "'";
                lv.ShowData(args);
            }
            catch { }
        }
        private void Accept()
        {
            TheOrder = null;
            try { TheOrder = (ordhed)lv.GetSelectedObject(); }
            catch { }
        }
        //Buttons
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            TheOrder = null;
            Close();
        }
        private void cmdAccept_Click(object sender, EventArgs e)
        {
            Accept();
            Close();
        }
        //Control Events
        private void optQuote_CheckedChanged(object sender, EventArgs e)
        {
            LoadLV();
        }
        private void optSales_CheckedChanged(object sender, EventArgs e)
        {
            LoadLV();
        }
    }
}
