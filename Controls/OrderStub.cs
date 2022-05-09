
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NewMethod;
namespace Rz5
{
    public partial class OrderStub : UserControl
    {
        public OrderHandle CurrentHandle;
        public OrderStub()
        {
            InitializeComponent();
        }
        //Public Functions
        public void CompleteLoad(OrderHandle h)
        {
            CurrentHandle = h;
            lblOrder.Text = CurrentHandle.GetOrderType();
            lblCompany.Text = CurrentHandle.strCompany;
            lblAgent.Text = CurrentHandle.strAgentName;
            lblDate.Text = CurrentHandle.strOrderDate;
            lblVoid.Visible = CurrentHandle.Void;
            lblIncomplete.Visible = CurrentHandle.Incomplete;
            
            mnuAuthorize.Visible = false;
            lblAuthorized.Visible = false;
            
            switch(CurrentHandle.type)
            {
                case Enums.OrderType.Quote:
                    this.BackColor = Color.LightCyan;
                    break;
                case Enums.OrderType.Sales:
                    this.BackColor = Color.MistyRose;
                    break;
                case Enums.OrderType.Purchase:
                    this.BackColor = Color.Honeydew;
                    mnuAuthorize.Visible = true;
                    lblAuthorized.Visible = CurrentHandle.Authorized;
                    break;
                case Enums.OrderType.Invoice:
                    this.BackColor = Color.LightGoldenrodYellow;
                    break;
                case Enums.OrderType.RMA:
                    this.BackColor = Color.Thistle;
                    break;
                case Enums.OrderType.VendRMA:
                    this.BackColor = Color.Thistle;
                    break;
                default:
                    this.BackColor = Color.White;
                    break;
            }
            //if( lblVoid.Visible || lblIncomplete.Visible )
            //    this.Height = 89;
            //else
                this.Height = 65;
            SetBorder();
        }
        //Private Functions
        private void SetBorder()
        {
            try
            {
                pbTop.Top = 0;
                pbTop.Left = -5;
                pbTop.Height = 2;
                pbTop.Width = this.Width + 5;
                pbTop.BringToFront();
                pbBottom.Top = this.Height - 2;
                pbBottom.Left = -5;
                pbBottom.Height = 3;
                pbBottom.Width = this.Width + 5;
                pbBottom.BringToFront();
                pbLeft.Top = -5;
                pbLeft.Left = 0;
                pbLeft.Height = this.Height + 5;
                pbLeft.Width = 2;
                pbLeft.BringToFront();
                pbRight.Top = -5;
                pbRight.Left = this.Width - 2;
                pbRight.Height = this.Height + 5;
                pbRight.Width = 2;
                pbRight.BringToFront();
            }
            catch(Exception)
            {
            }
        }
        private void ViewOrder()
        {
            CurrentHandle.ShowOrder(RzWin.Context);
        }
        private void ViewCompany()
        {
            company c = company.GetById(RzWin.Context, CurrentHandle.strCustID);
            if( c != null )
                RzWin.Context.Show(c);
        }
        private void ShowMenu()
        {
            this.printOrderToolStripMenuItem.Visible = (CurrentHandle.type != Enums.OrderType.Any);
            this.viewCompanyToolStripMenuItem.Visible = (CurrentHandle.type != Enums.OrderType.Any);
            mnu.Show(System.Windows.Forms.Cursor.Position);
        }
        private void PrintOrder(ContextRz context)
        {
            if (CurrentHandle.type == Enums.OrderType.Any)
                return;
            ordhed o = ordhed.GetById(RzWin.Context, CurrentHandle.strID, CurrentHandle.type);
            if (o == null)
                return;
            if (!o.TransmitPossible((ContextRz)context, Enums.TransmitType.Print))
                return;
            List<ordhed> l = new List<ordhed>();
            l.Add(o);
            context.Leader.ShowTransmitOrders((ContextRz)context, l, Rz5.Enums.TransmitType.Print);
        }
        //Menus
        private void viewOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewOrder();
        }
        private void viewCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewCompany();
        }
        private void printOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintOrder(RzWin.Context);
        }
        //Control Events
        private void lblOrder_Click(object sender, EventArgs e)
        {
            ShowMenu();
        }
        private void lblCompany_Click(object sender, EventArgs e)
        {
            ShowMenu();
        }
        private void lblAgent_Click(object sender, EventArgs e)
        {
            ShowMenu();
        }
        private void lblDate_Click(object sender, EventArgs e)
        {
            ShowMenu();
        }
        private void OrderStub_Click(object sender, EventArgs e)
        {
            ShowMenu();
        }

        //private void mnuAuthorize_Click(object sender, EventArgs e)
        //{
        //    ordhed o = ordhed.GetByID(Rz3App.xSys, CurrentHandle.strID, CurrentHandle.type);
        //    if (o != null)
        //    {
        //        o.Authorize();
        //        o.Update(RzWin.Context);
        //        lblAuthorized.Visible = true;
        //    }
        //}
    }
}