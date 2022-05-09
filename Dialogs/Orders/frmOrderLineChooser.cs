using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rz5;

namespace RzInterfaceWin.Dialogs
{
    public partial class frmOrderLineChooser : Rz5.Win.Dialogs.OrderLineChooser
    {
        //Constructors
        public frmOrderLineChooser()
        {
            InitializeComponent();
        }
        //Protected Override
        protected override SalesLineGroupTargetType GetTargetTypeHandle(bool has_invoices)
        {
            return SalesLineGroupTargetType.NewOrder;
        }
    }
}
