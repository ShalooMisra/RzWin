using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Core;
using NewMethod;
using Rz5;

namespace RzSensible
{
    public partial class ConsignmentCodes : UserControl
    {
        //Private Variables  
        private ContextRz TheContext;
        private Rz5.company TheCompany;

        //Constructors
        public ConsignmentCodes()
        {
            InitializeComponent();
        }
        //Public Functions
        public void Init(ContextRz x, Rz5.company c)
        {
            TheContext = x;
            if (TheContext == null)
                return;
            TheCompany = c;
            if (TheCompany == null)
                return;
            lvCodes.ShowTemplate("conscodes", "consignment_code");
            lvCodes.ShowData("consignment_code", "vendor_uid = '" + TheCompany.unique_id + "'", "code_name");
        }
        //Control Events
        private void lvCodes_AboutToAdd(object sender, AddArgs args)
        {
            args.Handled = true;
            if (!RzWin.Context.Sys.ThePermitLogic.CheckPermit(RzWin.Context, (Permissions.ThePermits).CanManageConsignment, RzWin.Context.xUser))
                RzWin.Leader.ShowNoRight();
            else
            {

                if (TheCompany == null)
                {
                    TheContext.TheLeader.Tell("This company does not exist.");
                    return;
                }
                string s = TheContext.TheLeader.AskForString("Please enter a name for this consignment code below:");
                if (!Tools.Strings.StrExt(s))
                    return;
                double consignmentBogeyDbl = 0;
                string consignmentBogeyString = TheContext.TheLeader.AskForString("If there is a consignment bogey, please enter it below:");
                if (Tools.Strings.StrExt(consignmentBogeyString))
                {
                    consignmentBogeyDbl = Convert.ToDouble(consignmentBogeyString);
                    double test;
                    bool isDouble = Double.TryParse(consignmentBogeyString, out test);
                    if (isDouble)
                    {
                        consignmentBogeyDbl = Convert.ToDouble(consignmentBogeyString);
                    }
                    else
                    {
                        RzWin.Leader.Tell("Please enter only numbers for the consignment bogey.");
                        return;
                    }

                }



                consignment_code consignmentCode = (consignment_code)RzWin.Context.QtO("consignment_code", "select * from consignment_code where code_name = '" + RzWin.Context.Filter(s.Trim()) + "' and vendor_uid = '" + TheCompany.unique_id + "'");
                if (consignmentCode != null)
                {
                    TheContext.TheLeader.Tell("This name already exists for this supplier. Please enter a unique name.");
                    return;
                }
                consignmentCode = new consignment_code();
                consignmentCode.code_name = s.Trim();
                consignmentCode.vendor_uid = TheCompany.unique_id;
                consignmentCode.vendor_name = TheCompany.companyname;
                consignmentCode.consignment_bogey = consignmentBogeyDbl;
                consignmentCode.Insert(RzWin.Context);
                TheContext.Show(consignmentCode);
            }




        }

        private void lvCodes_AboutToThrow(Context x, ShowArgs args)
        {
            if (!RzWin.Context.Sys.ThePermitLogic.CheckPermit(RzWin.Context, (Permissions.ThePermits).CanManageConsignment, RzWin.Context.xUser))
            {
                RzWin.Leader.ShowNoRight();
                args.Handled = true;
            }
        }
    }
}
