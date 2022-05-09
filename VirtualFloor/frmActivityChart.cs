//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Text;
//using System.Windows.Forms;
//using NewMethod;

//namespace Rz4.VirtualFloor
//{
//    public partial class frmActivityChart : Form
//    {
//        //public String UserID = "";
//        //public String LinkAction = "";

//        public frmActivityChart()
//        {
//            InitializeComponent();
//        }

//        //public void CompleteLoad(nCubeSummary s, String strLinkCaption, String strUserID, String strLinkAction)
//        //{
//        //    xView.CompleteLoad(RzWin.Context.xSys, s);
//        //    UserID = strUserID;
//        //    LinkAction = strLinkAction;
//        //    lbl.Text = strLinkCaption;
//        //    DoResize();
//        //}

//        //private void frmActivityChart_Resize(object sender, EventArgs e)
//        //{
//        //    DoResize();
//        //}

//        //void DoResize()
//        //{
//        //    try
//        //    {
//        //        pTop.Left = 0;
//        //        pTop.Top = 0;
//        //        pTop.Width = this.ClientRectangle.Width;

//        //        xView.Left = 0;
//        //        xView.Top = pTop.Bottom;
//        //        xView.Width = this.ClientRectangle.Width;
//        //        xView.Height = this.ClientRectangle.Height - pTop.Height;
//        //    }
//        //    catch { }
//        //}

//        //private void lbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
//        //{
//        //    switch (LinkAction.ToLower())
//        //    {
//        //        case "phonereport":
//        //            PhoneReport p = RzWin.Logic.GetPhoneReport();
//        //            p.CompleteLoad();
//        //            RzWin.Context.xSys.ShowTabControl(p, "Phone Report");
//        //            p.SelectUserByID(UserID);
//        //            p.RunReport();
//        //            break;
//        //        case "profitreport":
//        //            ProfitReportScreen pr = new ProfitReportScreen();
//        //            pr.CompleteStructure();
//        //            RzWin.Context.xSys.ShowTabControl(pr, "Profit Report");
//        //            pr.SetUserByID(UserID);
//        //            pr.RunReport();
//        //            break;
//        //    }
//        //}
//    }
//}