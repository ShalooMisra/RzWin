using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ToolsWin;
using ToolsWin.Dialogs;
using Rz5.Win.Controls;

namespace Rz5.Win.Dialogs
{
    public partial class OrderLine : OKCancel
    {
        orddet_line TheLine;

        public OrderLine()
        {
            InitializeComponent();
        }

        public void Init(orddet_line line)
        {
            base.Init();

            TheLine = line;
            pSale.Init(line, Enums.OrderType.Sales);
            pPurchase.Init(line, Enums.OrderType.Purchase);
            pInvoice.Init(line, Enums.OrderType.Invoice);
            pService.Init(line, Enums.OrderType.Service);
            pRMA.Init(line, Enums.OrderType.RMA);
            pVendRMA.Init(line, Enums.OrderType.VendRMA);
        }

        public override void OK()
        {
            if (!Validate(pSale))
                return;

            if (AllAreNone)
            {
                if (!RzWin.Context.TheLeader.AreYouSure("permanently delete this line"))
                    return;

                TheLine.Obliterate(RzWin.Context);
            }
            else
            {
                pSale.Apply();
                pPurchase.Apply();
                pInvoice.Apply();
                pService.Apply();
                pRMA.Apply();
                pVendRMA.Apply();
            }

            base.OK();
        }

        bool AllAreNone
        {
            get
            {
                return pSale.None && pPurchase.None && pInvoice.None && pService.None && pRMA.None && pVendRMA.None;
            }
        }

        bool Validate(OrderLinePanel p)
        {
            if (!p.Valid)
            {
                RzWin.Context.TheLeader.Tell("Please enter a valid " + p.TheType.ToString() + " number or choose 'None'");
                return false;
            }
            else
                return true;
        }
    }
}
