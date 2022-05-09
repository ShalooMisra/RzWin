using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class nEdit_Modified : NewMethod.nEdit
    {
        private String m_CreatedOnField = "";
        public String CreatedOnField
        {
            get { return m_CreatedOnField; }
            set { m_CreatedOnField = value; }
        }

        private String m_CreatedByField = "";
        public String CreatedByField
        {
            get { return m_CreatedByField; }
            set { m_CreatedByField = value; }
        }

        private String m_ModifiedOnField = "";
        public String ModifiedOnField
        {
            get { return m_ModifiedOnField; }
            set { m_ModifiedOnField = value; }
        }

        private String m_ModifiedByField = "";
        public String ModifiedByField
        {
            get { return m_ModifiedByField; }
            set { m_ModifiedByField = value; }
        }

        public nEdit_Modified()
        {
            InitializeComponent();
        }

        public override string GetControlType()
        {
            return "modified";
        }

        public void SetObject(nObject xObject)
        {
            base.lblCaption.Visible = false;

            String strCreatedBy = "";
            if (Tools.Strings.StrExt(m_CreatedByField))
                strCreatedBy = "By " + n_user.TranslateIDToName(NMWin.ContextDefault, (String)xObject.IGet(m_CreatedByField));

            String strCreatedOn = "";
            if (Tools.Strings.StrExt(m_CreatedOnField))
                strCreatedOn = "Created On " + nTools.DateFormat_Extra((DateTime)xObject.IGet(m_CreatedOnField));
            
            String strModifiedBy = "";
            if (Tools.Strings.StrExt(m_ModifiedByField))
                strCreatedBy = "By " + n_user.TranslateIDToName(NMWin.ContextDefault, (String)xObject.IGet(m_ModifiedByField));

            String strModifiedOn = "";
            if (Tools.Strings.StrExt(m_ModifiedOnField))
                strModifiedOn = "Modified On " + nTools.DateFormat_Extra((DateTime)xObject.IGet(m_ModifiedOnField));

            lblCreated.Text = strCreatedOn + " " + strCreatedBy;
            lblModified.Text = strModifiedOn + " " + strModifiedBy;
        }

        private void nEdit_Modified_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
    }
}

