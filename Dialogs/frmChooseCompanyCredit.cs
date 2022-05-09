using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using Tools;
using Tools.Database;
using NewMethod;
using Core;
using System.Collections;

namespace Rz5
{
    public partial class frmChooseCompanyCredit : Form
    {
        //public variables
        //public ordhed CurrentOrder;
        ContextRz TheContext;
        company TheCompany;
        ordhed TheOrder;



        public frmChooseCompanyCredit()
        {
            InitializeComponent();
        }

        public void CompleteLoad()
        {
            LoadCompanyCredit();
        }

        public void Init(ContextRz x, company c, ordhed o)
        {
            TheContext = x;
            TheCompany = c;
            TheOrder = o;
            CompleteLoad();
        }



        public List<companycredit> GetSelectedCredits()
        {
            //foreach item selected, add to list.            
            List<companycredit> xList = new List<companycredit>();
            foreach (companycredit c in lvCredits.GetSelectedObjects())
            {
                xList.Add(c);
            }


            foreach (companycredit c in xList)
            {

                if (c.applied_to_order_uid.Length > 0) //It's already applied to an order
                { 
                    //Begin Unassign Routing
                    if (!TheContext.TheLeader.AskYesNo("Are you sure you want to unassign this credit from PO# " + c.applied_to_order + " ?"))
                    {
                        break;
                    }
                    c.applied_to_order = "";
                    c.applied_to_order_uid = "";
                    c.purchase_order_uid = "";
                }
                else
                {
                    //Begin Assing Routing
                    if (!TheContext.TheLeader.AskYesNo("Are you sure you want assign this to PO# " + TheOrder.ordernumber+ " ?"))
                    {
                        break;
                    }
                    else
                    {
                        if (TheOrder.ordertype == "Purchase")
                        {
                            c.purchase_order_uid = TheOrder.unique_id;
                        }
                        c.applied_to_order = TheOrder.ordernumber;
                        c.applied_to_order_uid = TheOrder.unique_id;
                    }
                    
                }
                //c.applied_to_order = TheOrder.ordernumber;
                //c.applied_to_order_uid = TheOrder.unique_id;
                //if (TheOrder.ordertype == "Purchase")
                //{
                //    if(c.applied_to_order_uid.Length > 0) //It's already applied to an order
                //    {
                //        if(!TheContext.TheLeader.AskYesNo("Are you sure you want to unassign this credit from PO# "+c.applied_to_order+" ?"))
                //        {
                //            break;
                //        }
                //        else
                //        {
                //            c.applied_to_order = "";
                //            c.applied_to_order_uid = "";
                //        }                        
                //    }
                //    c.purchase_order_uid = TheOrder.unique_id;
                //}
                c.Update(RzWin.Context);
            }
            this.Close();
            return xList;
        }


        private void LoadCompanyCredit()
        {
            ListArgs args = new ListArgs(RzWin.Context);
            args.TheClass = "companycredit";
            args.TheLimit = 200;
            args.AddCaption = "Apply Selected Credits";
            args.TheOrder = "date_created desc";
            args.TheTable = "companycredit";
            args.TheTemplate = "companycredit";
            args.TheWhere = "base_company_uid = '" + TheCompany.unique_id + "' OR applied_to_order_uid = '" + TheOrder.unique_id + "'";
            if (!RzWin.Context.Sys.ThePermitLogic.CheckPermit(RzWin.Context, NewMethod.Permissions.ThePermits.AddOtherChargeCredit, RzWin.Context.xUser))
                args.AddAllow = false;
            else
                args.AddAllow = true;

            lvCredits.ShowData(args);
        }

        private void lvCredits_AboutToAdd(object sender, AddArgs args)
        {
            args.Handled = true;
            GetSelectedCredits();
            CompleteLoad();
        }

        private void lvCredits_AboutToThrow(Context x, ShowArgs args)
        {
            args.Handled = true;
            CompleteLoad();

        }

        private void lvCredits_ObjectClicked(object sender, ObjectClickArgs args)
        {
            lvCredits.Select();

        }
    }
}
