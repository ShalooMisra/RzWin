//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
//using System.Data;
//using System.Text;
//using System.Windows.Forms;
//using NewMethod;

//namespace Rz4.VirtualFloor
//{
   
//    public partial class ActivityPane : UserControl
//    {
//        //public ActivityHandle xHandle;
//        //public VirtualDesk xDeskControl;

//        public ActivityPane()
//        {
//            InitializeComponent();
//        }

//        //public void CompleteLoad(VirtualFloor f, VirtualDesk d, ActivityHandle h, Color color)
//        //{
//        //    xDeskControl = d;
//        //    xHandle = h;
//        //    picBar.BackColor = color;
//        //    ShowActivity(f);
//        //}

//        //public void ShowActivity(VirtualFloor f)
//        //{
//        //    Double highest = f.GetHighestActivity(xHandle.Key);

//        //    lblName.Text = xHandle.Caption;
//        //    lblValue.Text = nCube.DisplayFormat(xHandle.Value, xHandle.ValueDisplay);

//        //    Double pct = nTools.CalcPercent(highest, xHandle.Value);
//        //    int w = Convert.ToInt32(30 * (pct / 100));
//        //    picBar.Width = w;

//        //    if (highest > 0 && highest == xHandle.Value)
//        //    {
//        //        picStar.Image = il.Images[0];
//        //        picStar.Visible = true;
//        //    }
//        //    else
//        //        picStar.Visible = false;
//        //}

//        //private void ActivityPane_Load(object sender, EventArgs e)
//        //{

//        //}

//        //private void lblName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
//        //{
//        //    ShowActivityChart();
//        //}

//        //void ShowActivityChart()
//        //{
//        //    nCubeSummary sum = xHandle.GetTodaysSummary();
//        //    frmActivityChart xForm = new frmActivityChart();
//        //    xForm.Text = xHandle.Caption;

//        //    if (Cursor.Position.X > (System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width / 2))
//        //    {
//        //        xForm.Left = Cursor.Position.X - xForm.Width;
//        //    }
//        //    else
//        //    {
//        //        xForm.Left = Cursor.Position.X;
//        //    }

//        //    if (Cursor.Position.Y > (System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height / 2))
//        //    {
//        //        xForm.Top = Cursor.Position.Y - xForm.Height;
//        //    }
//        //    else
//        //    {
//        //        xForm.Top = Cursor.Position.Y;
//        //    }

//        //    xForm.Show();
//        //    xForm.BringToFront();

//        //    NewMethod.n_user u = (NewMethod.n_user)RzWin.Context.xSys.Users.GetByID(xDeskControl.xDesk.the_n_user_uid);

//        //    switch (xHandle.Key)
//        //    {
//        //        case "phonecall":
//        //            xForm.CompleteLoad(sum, "Phone Report for " + u.name, u.unique_id, "PhoneReport");
//        //            break;
//        //        case "shippedprofit":
//        //        case "soldprofit":
//        //            xForm.CompleteLoad(sum, "Profit Report for " + u.name, u.unique_id, "ProfitReport");
//        //            break;
//        //    }
//        //}
//    }
//}
