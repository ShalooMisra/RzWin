using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Tools;
using NewMethod;
using Tools.Database;

namespace Rz5.Win.Dialogs
{
    public partial class LineCardEditor : ToolsWin.Dialogs.OKCancel
    {
        public company TheCompany;

        public LineCardEditor()
        {
            InitializeComponent();
        }

        public void Init(company c)
        {
            base.Init();
            TheCompany = c;

            List<String> m = n_choices.ChoiceListGet(RzWin.Context, "manufacturer");
            ArrayList already_has = RzWin.Context.SelectScalarArray("select manufacturer from mfg_link where isnull(manufacturer, '') > '' and the_company_uid = '" + TheCompany.unique_id + "' order by manufacturer");
            foreach (String s in m)
            {
                ListViewItem i = lv.Items.Add(s.ToUpper().Trim());
                if (already_has.Contains(s.ToUpper().Trim()))
                    i.Checked = true;
            }
        }

        public override void DoResize()
        {
            base.DoResize();

            try
            {
                columnHeader1.Width = Convert.ToInt32(lv.Width * 0.95);
            }
            catch { }
        }

        public override void Cancel()
        {
            if (!RzWin.Context.TheLeader.AreYouSure("close and cancel any changes"))
                return;

            base.Cancel();
        }

        public override void OK()
        {
            RzWin.Context.Data.FieldMakeExist("mfg_link", new Field("temp_flag", FieldType.Boolean));
            RzWin.Context.Execute("update mfg_link set temp_flag = 0 where the_company_uid = '" + TheCompany.unique_id + "'");
            foreach (ListViewItem i in lv.CheckedItems)
            {
                long aff = 0;
                RzWin.Context.Data.Connection.Execute("update mfg_link set temp_flag = 1 where manufacturer = '" + RzWin.Context.Filter(i.Text) + "' and the_company_uid = '" + TheCompany.unique_id + "'", ref aff);
                if (aff == 0)
                {
                    mfg_link k = mfg_link.New(RzWin.Context);
                    k.manufacturer = i.Text.Trim().ToUpper();
                    k.companyname = TheCompany.companyname;
                    k.the_company_uid = TheCompany.unique_id;
                    k.Insert(RzWin.Context);
                    RzWin.Context.Data.Connection.Execute("update mfg_link set temp_flag = 1 where manufacturer = '" + RzWin.Context.Filter(i.Text) + "' and the_company_uid = '" + TheCompany.unique_id + "'", ref aff);
                }
            }
            RzWin.Context.Execute("delete from mfg_link where temp_flag = 0 and the_company_uid = '" + TheCompany.unique_id + "'");
            base.OK();
        }
    }
}
