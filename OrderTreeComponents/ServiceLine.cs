using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NewMethod;

namespace Rz5
{
    public partial class ServiceLine : RzLine
    {
        public orddet_line CurrentService;

        public ServiceLine()
        {
            InitializeComponent();
        }

        public void CompleteLoad(orddet_line s, Image i)
        {
            ctl_fullpartnumber.LoadChoices(TheContext.xSys.GetChoicesByName("services"));

            CurrentService = s;
            CurrentObject = CurrentService;
            NMWin.LoadFormValues(this, CurrentService);

            MessageBox.Show("reorg");
            //lblVendor.Text = CurrentService.companyname;
            //lblContact.Text = CurrentService.contactname;

            SetImage(i);
            SetColor(Color.Green);
            DoResize();
        }

        public override void DoResize()
        {
            try
            {
                CommandLeft = ctl_internalcomment.Right + 4;
                base.DoResize();
            }
            catch { }
        }
    }
}

