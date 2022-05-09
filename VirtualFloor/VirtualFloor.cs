//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
//using System.Data;
//using System.Text;
//using System.Windows.Forms;

//using NewMethod;

//namespace Rz4.VirtualFloor
//{
//    public partial class VirtualFloor : UserControl, IActivityMonitor
//    {
//        //public n_sys xSys;
//        public virtual_floor xFloor;

//        String FirstUser = "";

//        public VirtualFloor()
//        {
//            InitializeComponent();
//        }

//        public void CompleteLoad(virtual_floor f)
//        {
//            xFloor = f;

//            LoadDesks();

//            if( ((ContextRz)RzWin.Context).xHook != null )
//                ((ContextRz)RzWin.Context).xHook.AddActivityMonitor(this);
//            RunCheck();
//            tmrCheck.Start();
//        }

//        public void CompleteUnload()
//        {
//            try
//            {
//                ((ContextRz)RzWin.Context).xHook.RemoveActivityMonitor(this);
//                foreach (VirtualDesk dk in DeskControls)
//                {
//                    pFloor.Controls.Remove(dk);
//                    //dk.GotEvent -= new SoftEventHandler(k_GotEvent);
//                    dk.Dispose();
//                }
//            }
//            catch { }
//        }

//        void LoadDesks()
//        {
//            pFloor.Controls.Clear();
//            DeskControls = new ArrayList();

//            foreach (virtual_desk d in xFloor.Desks)
//            {
//                LoadDesk(d);
//                if (!Tools.Strings.StrExt(FirstUser))
//                    FirstUser = d.the_n_user_uid;
//            }
//        }

//        ArrayList DeskControls;
//        void LoadDesk(virtual_desk d)
//        {
//            try
//            {
//                VirtualDesk k = new VirtualDesk();
//                pFloor.Controls.Add(k);
//                DeskControls.Add(k);
//                k.CompleteLoad(this, d);
//                k.Left = d.CalculateX(pFloor.ClientRectangle.Width);
//                k.Top = d.CalculateY(pFloor.ClientRectangle.Height);

//                //k.GotEvent += new SoftEventHandler(k_GotEvent);
//                k.ShowDesk();
//            }
//            catch { }
//        }

//        void k_GotEvent(object sender, SoftEventArgs args)
//        {
//            switch (args.EventName.ToLower())
//            {
//                case "mousedown":
//                    break;

//            }
//        }

//        private void AddADesk()
//        {
//            String strID = "";
//            String strName = "";
//            frmChooseUser.ChooseUserName(RzWin.Context.xSys, ref strID, ref strName, this.ParentForm, null, false);
//            if (!Tools.Strings.StrExt(strID))
//                return;

//            NewMethod.n_user u = (NewMethod.n_user)RzWin.Context.xSys.Users.GetByID(strID);
//            if (u == null)
//                return;

//            virtual_desk d = xFloor.AddDesk(u);
//            LoadDesk(d);
//        }

//        private void VirtualFloor_Resize(object sender, EventArgs e)
//        {
//            DoResize();
//        }

//        void DoResize()
//        {
//            try
//            {
//                pFloor.Top = 0;
//                pFloor.Height = this.ClientRectangle.Height;
//                pFloor.Width = this.ClientRectangle.Width - pFloor.Left;

//                foreach (VirtualDesk dk in DeskControls)
//                {
//                    dk.Left = dk.xDesk.CalculateX(pFloor.ClientRectangle.Width);
//                    dk.Top = dk.xDesk.CalculateY(pFloor.ClientRectangle.Height);
//                }
//            }
//            catch { }
//        }

//        private void cmdSave_Click(object sender, EventArgs e)
//        {
//            CompleteSave();
//        }

//        void CompleteSave()
//        {
//            foreach (VirtualDesk dk in DeskControls)
//            {
//                dk.xDesk.SavePosition(pFloor.ClientRectangle.Width, pFloor.ClientRectangle.Height, dk.Left, dk.Top);
//            }
//        }

//        ArrayList LineControls = new ArrayList();
//        public void ActuallyHandleActivity(user_activity a)
//        {
//            foreach (VirtualDesk dk in DeskControls)
//            {
//                if (dk.xDesk.the_n_user_uid == a.the_n_user_uid)
//                {
//                    dk.AddActivity(a);

//                    if (dk.ActivityTop < dk.Height * 2)
//                    {
//                        ActivityLine l = new ActivityLine();
//                        l.CompleteLoad(a);
//                        Controls.Add(l);
//                        l.Left = pFloor.Left + 30 + (dk.Left + (dk.Width / 2));
//                        l.Top = (pFloor.Top + dk.Top) - dk.ActivityTop;
//                        dk.ActivityTop += l.Height;
//                        l.BringToFront();
//                        l.xDesk = dk;
//                        LineControls.Add(l);
//                        if (!tmrLine.Enabled)
//                            tmrLine.Start();
//                    }
//                }
//            }
//        }

//        private void tmrCheck_Tick(object sender, EventArgs e)
//        {
//            RunCheck();
//        }

//        void RunCheck()
//        {
//            foreach (VirtualDesk dk in DeskControls)
//            {
//                dk.ShowDesk();
//            }
//        }

//        private void tmrLine_Tick(object sender, EventArgs e)
//        {
//            tmrLine.Start();

//            ArrayList done = new ArrayList();
//            foreach (ActivityLine l in LineControls)
//            {
//                TimeSpan t = DateTime.Now.Subtract(l.StartTime);
//                if (t.TotalSeconds > 2)
//                    done.Add(l);
//            }

//            foreach (ActivityLine l in done)
//            {
//                Controls.Remove(l);
//                LineControls.Remove(l);
//                l.xDesk.ActivityTop -= l.Height;
//                l.Dispose();
//            }

//            if (LineControls.Count > 0)
//                tmrLine.Start();
//        }

//        //private void lblTest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
//        //{
//        //    user_activity a = new user_activity(Rz3App.xSys);
//        //    a.name = "SoldProfit";
//        //    a.activity_type = "soldprofit";
//        //    a.activity_value = 1234.56;
//        //    a.the_n_user_uid = FirstUser;
//        //    a.date_created = DateTime.Now;
//        //    a.description = "$1,234.56 profit sold";
//        //    a.link_list = "ordhed:FFDDEESDSSS:Invoice 123\r\ncompany:WQOIUQWOQIUQWOIU:Some OEM Name";
//        //    ActuallyHandleActivity(a);
//        //}

//        public Double GetHighestActivity(String strKey)
//        {
//            Double ret = 0;
//            foreach (VirtualDesk dk in DeskControls)
//            {
//                try
//                {
//                    Double d = dk.xDesk.Activities[strKey].Value;
//                    if (d > ret)
//                        ret = d;
//                }
//                catch { }
//            }
//            return ret;
//        }

//        public void RemoveDesk(virtual_desk rem, VirtualDesk d)
//        {
//            rem.Delete(RzWin.Context);
//            xFloor.Desks.Remove(rem);
//            DeskControls.Remove(d);
//            pFloor.Controls.Remove(d);

//            try
//            {
//                d.Dispose();
//                d = null;
//            }
//            catch { }
//        }

//        private void cmdAdd_Click(object sender, EventArgs e)
//        {
//            AddADesk();
//        }
//    }
//}
