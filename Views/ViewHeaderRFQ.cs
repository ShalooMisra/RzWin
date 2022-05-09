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
    public partial class ViewHeaderRFQ : ViewHeader
    {
        //Constructors
        public ViewHeaderRFQ()
        {
            InitializeComponent();
            agent.Caption = "Buyer";
        }
    }
}
