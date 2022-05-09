using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Rz5.Win.Dialogs
{
    public partial class StockChooser : ToolsWin.Dialogs.OKCancel
    {
        public static partrecord Choose(String partNumber)
        {
            StockChooser c = new StockChooser();
            c.Init(partNumber);
            c.ShowDialog();
            partrecord ret = c.Result;
            try
            {
                c.Close();
                c.Dispose();
                c = null;
            }
            catch { }
            return ret;
        }

        public partrecord Result;
        public List<partrecord> ListResult;

        public StockChooser()
        {
            InitializeComponent();
        }

        public void Init(String part)
        {
            txtPartNumber.Text = part;            
            lvResult.Init(RzWin.Context.TheSysRz.ThePartLogic.PartSearchArgsGet(RzWin.Context, GetParams(part)));
        }

        

        private PartSearchParameters GetParams(String part)
        {
            PartSearchParameters p = new PartSearchParameters(part);
            p.IncludeStock = chkStock.Checked;
            p.IncludeConsign = chkConsign.Checked;
            //p.IncludeExcess = false;
            p.IncludeExcess = chkExcess.Checked;
            p.TheTarget = PartSearchTarget.Part;
            return p;
        }

        public override void Cancel()
        {
            Result = null;
            base.Cancel();
        }

        public override void OK()
        {
            if (Result == null)
                Result = (partrecord)lvResult.GetSelectedObject();
            if (Result == null)
            {
                RzWin.Context.TheLeader.Error("Please choose an inventory item before continuing");
                return;
            }
            ListResult = GetList();
            base.OK();
        }

        private List<partrecord> GetList()
        {
            ArrayList a = lvResult.GetSelectedObjects();
            List<partrecord> l = new List<partrecord>();
            foreach (partrecord p in a)
            {
                l.Add(p);
            }
            return l;
        }

        private void lvResult_AboutToThrow(Core.Context x, Core.ShowArgs args)
        {
            args.Handled = true;
            Result = (partrecord)args.TheItems.FirstGet(RzWin.Context);
            OK();
        }

        public override void DoResize()
        {
            base.DoResize();

            try
            {
                lvResult.Left = 0;
                lvResult.Width = pContents.ClientRectangle.Width;
                lvResult.Height = pContents.ClientRectangle.Height - lvResult.Top;
            }
            catch { }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            lvResult.Init(RzWin.Context.TheSysRz.ThePartLogic.PartSearchArgsGet(RzWin.Context, GetParams(txtPartNumber.Text)));
        }
    }
}
