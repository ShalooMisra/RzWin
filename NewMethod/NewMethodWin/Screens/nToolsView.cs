using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Tools.Database;

namespace NewMethod
{
    public partial class nToolsView : UserControl
    {
        public nToolsView()
        {
            InitializeComponent();
        }

        public void CompleteLoad(SysNewMethod xs)
        {
            lblSystem.Text = NMWin.ContextDefault.xSys.Name;
        }

        private void cmdSplitEmailDomain_Click(object sender, EventArgs e)
        {
            String strTable = ctlTable.GetValue_String();
            String strField1 = ctlField1.GetValue_String();
            String strField2 = ctlField2.GetValue_String();

            if (!Tools.Strings.StrExt(strTable))
                return;

            if (!Tools.Strings.StrExt(strField1))
                return;

            if (!Tools.Strings.StrExt(strField2))
                return;

            String desc = "update the table " + strTable + ", taking the domain from " + strField1 + " and copying it to " + strField2;
            if (Tools.Strings.StrExt(ctlWhere.GetValue_String()))
                desc += " where " + ctlWhere.GetValue_String();

            if (!NMWin.Leader.AreYouSure(desc))
                return;


            NMWin.Leader.StartPopStatus("Splitting...");
            long l = 0;
            NMWin.Data.SplitEmailDomain(strTable, strField1, strField2, ref l, ctlWhere.GetValue_String());
            NMWin.Leader.Comment("Done: " + Tools.Strings.PluralizePhrase("row", l) + " affected");
            NMWin.Leader.StopPopStatus();
        }

        private void cmdSplitEmailSuffix_Click(object sender, EventArgs e)
        {
            String strTable = ctlTable.GetValue_String();
            String strField1 = ctlField1.GetValue_String();
            String strField2 = ctlField2.GetValue_String();

            String desc = "update the table " + strTable + ", taking the suffix from " + strField1 + " and copying it to " + strField2;
            if (Tools.Strings.StrExt(ctlWhere.GetValue_String()))
                desc += " where " + ctlWhere.GetValue_String();

            if (!NMWin.Leader.AreYouSure(desc))
                return;

            NMWin.Leader.StartPopStatus("Splitting...");
            NMWin.Data.SplitEmailSuffix(strTable, strField1, strField2, ctlWhere.GetValue_String());
            NMWin.Leader.Comment("Done.");
            NMWin.Leader.StopPopStatus();
        }

        private void cmdStrip_Click(object sender, EventArgs e)
        {
            if( !Tools.Strings.StrExt(ctlTable.GetValue_String()) )
                return;

            if( !Tools.Strings.StrExt(ctlField1.GetValue_String()) )
                return;

            if( !Tools.Strings.StrExt(ctlField2.GetValue_String()) )
                return;

            String desc = "strip " + ctlField1.GetValue_String() + " into " + ctlField2.GetValue_String();
            if (Tools.Strings.StrExt(ctlWhere.GetValue_String()))
                desc += " where " + ctlWhere.GetValue_String();

            if (!NMWin.Leader.AreYouSure(desc))
                return;

            desc = "delete all of the info in " + ctlTable.GetValue_String() + "." + ctlField2.GetValue_String();
            if (Tools.Strings.StrExt(ctlWhere.GetValue_String()))
                desc += " where " + ctlWhere.GetValue_String();

            if (!NMWin.Leader.AreYouSure(desc))
                return;

            NMWin.Data.StripFieldInto(ctlTable.GetValue_String(), ctlField1.GetValue_String(), ctlField2.GetValue_String(), ctlWhere.GetValue_String());

            NMWin.Leader.Tell("Done.");
        }

        private void cmdSplitLeft_Click(object sender, EventArgs e)
        {
            Split(SplitDirection.Left);
        }

        private void cmdSplitRight_Click(object sender, EventArgs e)
        {
            Split(SplitDirection.Right);
        }

        void Split(SplitDirection direction)
        {
            if (!Tools.Strings.StrExt(ctlTable.GetValue_String()))
                return;

            if (!Tools.Strings.StrExt(ctlField1.GetValue_String()))
                return;

            if (!Tools.Strings.StrExt(ctlField2.GetValue_String()))
                return;

            if (ctlDivider.GetValue_String() == "")
                return;

            String desc = "split " + direction.ToString().ToLower() + " from " + ctlField1.GetValue_String() + " into " + ctlField2.GetValue_String() + " on the divider '" + ctlDivider.GetValue_String() + "'";
            if (Tools.Strings.StrExt(ctlWhere.GetValue_String()))
                desc += " where " + ctlWhere.GetValue_String();
            
            if (!NMWin.Leader.AreYouSure(desc))
                return;

            long l = 0;

            if (direction == SplitDirection.Left)
                NMWin.Data.SplitFieldLeft(ctlTable.GetValue_String(), ctlField1.GetValue_String(), ctlField2.GetValue_String(), ctlDivider.GetValue_String(), ref l, ctlWhere.GetValue_String());
            else
                NMWin.Data.SplitFieldRight(ctlTable.GetValue_String(), ctlField1.GetValue_String(), ctlField2.GetValue_String(), ctlDivider.GetValue_String(), ref l, ctlWhere.GetValue_String());

            NMWin.Leader.Comment("Done: " + Tools.Strings.PluralizePhrase("row", l) + " affected");
        }

        private void cmdSplitFirstName_Click(object sender, EventArgs e)
        {
            String table = ctlTable.GetValue_String();
            if( !Tools.Strings.StrExt(table))
                return;

            String field2 = ctlField2.GetValue_String();
            if( !Tools.Strings.StrExt(field2))
                return;

            if (!NMWin.Leader.AreYouSure("delete all information in " + field2))
                return;

            foreach(DataRow r in NMWin.Data.Select("select unique_id, " + ctlField1.GetValue_String() + " as full_name from " + table).Rows)
            {
                String uid = Tools.Data.NullFilterString(r["unique_id"]);
                String fullName = Tools.Data.NullFilterString(r["full_name"]);
                String firstName = Tools.Strings.NiceFormat(Tools.People.FirstNameParse(fullName));
                NMWin.ContextDefault.Execute("update " + table + " set " + field2 + " = '" + NMWin.ContextDefault.Filter(firstName) + "' where unique_id = '" + NMWin.ContextDefault.Filter(uid) + "'");
            }

            NMWin.ContextDefault.Leader.Tell("Done");
        }

        private void commonFieldsButton_Click(object sender, EventArgs e)
        {
            if(!Tools.Strings.StrExt(ctlTable.GetValue_String()) || !Tools.Strings.StrExt(ctlTable.GetValue_String()) )
            {
                NMWin.Leader.Tell("Please enter a table 1 and table 2 name");
                return;
            }

            DataTable t1 = NMWin.ContextDefault.Select("select top 1 * from " + ctlTable.GetValue_String());
            DataTable t2 = NMWin.ContextDefault.Select("select top 1 * from " + ctlTable2.GetValue_String());

            List<String> commonFields = new List<string>();
            foreach (DataColumn c1 in t1.Columns)
            {
                DataColumn c2 = null;

                try
                {
                    c2 = t2.Columns[c1.Caption];
                    if( c2 != null )
                        commonFields.Add(c1.Caption);
                }
                catch { }
            }

            Tools.FileSystem.PopText(Tools.Strings.CommaSeparateBlanksIgnore(commonFields));
        }
    }
}
