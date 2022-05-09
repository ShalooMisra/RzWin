using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Core;
using NewMethod;

namespace Rz5
{
    public partial class view_orddet_rfq : ViewPlusMenu
    {
        //Protected Variables
        protected IBidLine xLine;

        public orddet_rfq CurrentDetail
        {
            get
            {
                return (orddet_rfq)GetCurrentObject();
            }
        }
        public view_orddet_rfq()
        {
            InitializeComponent();
            if (RzWin.Context != null)
            {
                xLine = ((LeaderWinUserRz)RzWin.Context.TheLeader).GetBidLine();
                Controls.Add((Control)xLine);
                xLine.Left = 0;
                xLine.Top = 0;
                xLine.HeightInit();
            }
        }

        public override void CompleteLoad()
        {
            //if (Rz3App.xLogic.IsAAT)
            //    ChangeEditStringsToCaps();

            xLine.CompleteLoad((orddet_rfq)CurrentDetail, null);  //il.Images["rfq"]  this image says 'rfq'; that's confusing now
           
            base.CompleteLoad();
        }

        public override void CompleteSave()
        {
            try
            {
                xLine.CompleteSave();

               
                //Double tp = (Double)ctl_target_price.GetValue();
                //if (tp > 0)
                //    CurrentDetail.description = "Target Price: " + nTools.MoneyFormat_2_6(tp);
                //else
                //    CurrentDetail.description = "";
            }
            catch { }

            base.CompleteSave();
            
        }

        private void ChangeEditStringsToCaps()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    SetAllCaps(c);
                }
            }
            catch
            { }
        }

        public override void FinishedAction(ActArgs args)
        {
            switch (args.ActionName.ToLower().Trim())
            {
                case "givequote":
                    this.SendCloseRequest();
                    break;
            }
            base.FinishedAction(args);
        }

        private void SetAllCaps(Control c)
        {
            try
            {
                if (c == null)
                    return;
                nEdit_String str = null;
                try { str = (nEdit_String)c; }
                catch { }
                if (str == null)
                {
                    foreach (Control cc in c.Controls)
                    {
                        SetAllCaps(cc);
                    }
                    return;
                }
                str.AllCaps = true;
            }
            catch (Exception ee)
            { }
        }

        protected override void DoResize()
        {
            try
            {
                base.DoResize();
                xLine.Left = 0;
            }
            catch { }
        }

    }
}

