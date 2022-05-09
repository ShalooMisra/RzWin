using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core;

namespace Rz5.Win.Controls
{
    public partial class ReportCriteriaControlCompany : ReportCriteriaControl
    {
        //Private Variables
        private ReportCriteriaCompany CompanyCriteria
        {
            get
            {
                return (ReportCriteriaCompany)TheCriteria;
            }
        }

        //Constructors
        public ReportCriteriaControlCompany()
        {
            InitializeComponent();
        }
        //Public Override Functions
        public override void Init(ReportCriteria c)
        {
            base.Init(c);
            company.Caption = c.Caption;
            company.OnlyShowViewClear();
        }
        //Control Events
        private void company_ClearCompanyFinished(Tools.GenericEvent e)
        {
            CompanyCriteria.Clear();
        }
        private void company_CompanyChangeFinished(Tools.GenericEvent e)
        {
            CompanyCriteria.TheID = company.CurrentCompanyID;
            CompanyCriteria.TheName = company.CurrentCompanyName;
        }
    }
}
