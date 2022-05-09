using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Tools;
using Core;
using CoreWin;
using NewMethod;

namespace Rz5.Win.Screens
{
    public partial class PartSearchBase : UserControl
    {
        protected Stack PartNumbers = null;
        protected Stack colPartNumbers = null;
        
        public PartSearchBase()
        {
            InitializeComponent();
        }

        public void CachePartNumbers()
        {
            PartNumbers = ((ContextRz)RzWin.Context).TheSysRz.ThePartLogic.GetRecentSearchStack((ContextRz)RzWin.Context);
            colPartNumbers = new Stack();
        }
        public void SavePartNumbers()
        {
            if (colPartNumbers == null)
                return;
            String strPart;
            String strDate;
            foreach (String x in colPartNumbers)
            {
                if (Tools.Strings.HasString(x, "><"))
                {
                    strPart = Tools.Strings.ParseDelimit(x, "><", 1).Trim();
                    strDate = Tools.Strings.ParseDelimit(x, "><", 2).Trim();
                    RzWin.Context.Execute("insert into partsearch(base_mc_user_uid, fullpartnumber, searchdate) values ('" + RzWin.User.unique_id + "', '" + RzWin.Context.Filter(strPart) + "', '" + strDate + "')", failOK: true);
                    PartNumbers.Push(x.Replace("><", "<>"));
                }
            }
            colPartNumbers = new Stack();
        }
        protected void CheckAddPartNumber(String strPart)
        {
            if (strPart.Length > 150)
                return;
            if (colPartNumbers == null)
                return;
            foreach (String st in colPartNumbers)
            {
                if (Tools.Strings.HasString(st, strPart))
                    return;
            }
            foreach (String st in PartNumbers)
            {
                if (Tools.Strings.HasString(st, strPart))
                    return;
            }
            colPartNumbers.Push(strPart + " >< " + Tools.Dates.DateFormatWithTimeRegardlessOfWindowsSettings(DateTime.Now));
        }

        //public virtual partrecord GetSelectedPart()
        //{
        //    return null;
        //}

        protected void ShowRecentSearches()
        {
            mnuSearches.Items.Clear();
            if (colPartNumbers != null)
            {
                foreach (String s in colPartNumbers)
                {
                    ToolStripItem t = mnuSearches.Items.Add(s);
                    t.Click += new EventHandler(mnuSearches_Click);
                }
            }
            foreach (String s in PartNumbers)
            {
                ToolStripItem t = mnuSearches.Items.Add(s);
                t.Click += new EventHandler(mnuSearches_Click);
            }
            mnuSearches.Show(System.Windows.Forms.Cursor.Position);
        }

        private void mnuSearches_Click(Object sender, Object e)
        {
            try
            {
                ToolStripItem t = (ToolStripItem)sender;
                SetPartNumber(Tools.Strings.ParseDelimit(t.Text, "<", 1).Replace(">", "").Trim());
            }
            catch (Exception)
            {
            }
        }

        public virtual void SetPartNumber(String part)
        {

        }
    }
}
