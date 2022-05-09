using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rz5
{
    public partial class ViewDetailRFQ : ViewDetail
    {
        //Protected Override Variables
        protected override Rz5.Enums.OrderType OrderType
        {
            get
            {
                return Rz5.Enums.OrderType.RFQ;
            }
        }
        protected override string OrderNumber
        {
            get
            {
                //if (CurrentDetail == null)
                    return "";
                //return CurrentDetail.ordernumber_rfq;
            }
        }

        //Constructors
        public ViewDetailRFQ()
        {
            InitializeComponent();
        }
    }
}
