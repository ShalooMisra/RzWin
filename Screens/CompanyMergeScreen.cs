using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace Rz5
{
    public partial class CompanyMergeScreen : UserControl
    {
        public ArrayList AllCompanies;
        public ArrayList AllControls;

        public CompanyMergeScreen()
        {
            InitializeComponent();
        }

        public void CompleteLoad(ArrayList companies)
        {
            AllCompanies = companies;
            AllControls = new ArrayList();
            AllControls.Add(m1);
            AllControls.Add(m2);
            AllControls.Add(m3);
            AllControls.Add(m4);
            AllControls.Add(m5);

            foreach (CompanyMerge m in AllControls)
            {
                m.CurrentCompany = null;
                m.Visible = false;
            }

            int i = AllCompanies.Count;
            if (i > AllControls.Count)
                i = AllControls.Count;

            for (int j = 0; j < i; j++)
            {
                CompanyMerge cm = (CompanyMerge)AllControls[j];
                company co = (company)AllCompanies[j];
                cm.Visible = true;
                cm.CompleteLoad(co);
            }
        }

        private void m_Accept(object source, company c)
        {
            ArrayList ToConsolidate = GetConsolidatedCompanies(c.unique_id);

            if (ToConsolidate.Count == 0)
            {
                RzWin.Leader.Tell("Condolidation requires at least 2 companies.");
                return;
            }

            String s = "";
            foreach (company consol in ToConsolidate)
            {
                s += consol.ToString() + "\r\n";
            }

            if (!RzWin.Leader.AreYouSure("consolidate the following companies with " + c.ToString() + "\r\n\r\n\r\n" + s))
                return;

            if (!RzWin.Leader.AreYouSure("continue"))
                return;

            try
            {
                //save the data
                CompanyMerge m = (CompanyMerge)source;
                m.CompleteSave();  //this calls ISave
            }
            catch (Exception)
            { }

            c.MergeWith(RzWin.Context, ToConsolidate);
            ArrayList a = new ArrayList();
            a.Add(c);
            CompleteLoad(a);
        }

        public ArrayList GetConsolidatedCompanies(String strKeepID)
        {
            ArrayList a = new ArrayList();
            foreach (CompanyMerge m in AllControls)
            {
                if (m.CurrentCompany != null)
                {
                    if (!Tools.Strings.StrCmp(m.CurrentCompany.unique_id, strKeepID))
                        a.Add(m.CurrentCompany);
                }
            }
            return a;
        }

    }
}
