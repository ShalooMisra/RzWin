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
    public partial class ViewDetailQuote : ViewDetail
    {
        //Protected Override Variables
        protected override Rz5.Enums.OrderType OrderType
        {
            get
            {
                return Rz5.Enums.OrderType.Quote;
            }
        }
        protected override string OrderNumber
        {
            get
            {
                if (CurrentDetail == null)
                    return "";
                return CurrentDetail.ordernumber_quote;
            }
        }

        //Constructors
        public ViewDetailQuote()
        {
            InitializeComponent();
        }
        protected override void CheckUpdateShipping()
        {
            if (CurrentDetail == null)
                return;
        }
    }
}
