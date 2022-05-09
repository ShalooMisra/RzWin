using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using NewMethod;
using Tools.Database;

namespace Rz5.Reports
{
    public partial class UserInfoChanges : WebReport_User_Date
    {
        public UserInfoChanges()
        {
            InitializeComponent();
        }

        public override void CompleteStructure()
        {
            SetCaption("User Info Changes");
            base.CompleteStructure();
        }
        ContextNM TheContext
        {
            get { return RzWin.Context; }
        }
        StringBuilder result;
        Tools.Dates.DateRange range;
        ArrayList userids = new ArrayList();
        DataConnectionSqlServer RecallData = null;
        public override void RunReport()
        {
            base.RunReport();

            if (!TheContext.xSys.Recall)
            {
                RzWin.Leader.Tell("Recall isn't enabled");
                return;
            }

            RecallData = RzWin.Context.Sys.RecallConnection;
            String err = "";
            if (!RecallData.ConnectPossible(ref err))
            {
                RzWin.Leader.Tell("Can't connect to Recall: " + err);
                return;
            }

            result = new StringBuilder();
            range = GetDateRange();
            userids = GetUserIDCollection_BlankIfAll();

            wb.ReloadWB();
            wb.Add("Calculating...");
            ShowThrobber();
            StartAsync();
        }

        public override void DoAsync()
        {
            base.DoAsync();
            ResultAdd("company", "Companies", "companyname as [Company], primarycontact as [Contact], primaryphone as [Phone], primaryfax as [Fax], primaryemailaddress as [Email]");
        }

        void ResultAdd(String classname, String caption, String show)
        {
            result.Append("<h2>" + caption + "</h2>");

            String usersql = "";
            if( userids.Count > 0 )
                usersql = " and recall_user_uid in ( " + nTools.GetIn(userids) + " ) ";

            DataTable d = RecallData.Select("select cast(recall_date as varchar(50)) as [Date], recall_user_name as [User], case when recall_type = 1 then 'Added' when recall_type = 2 then 'Updated' when recall_type = 3 then 'Deleted' else 'Unknown' end as [Type], " + show + " from " + classname + " where " + range.GetSQL("recall_date") + usersql + " order by unique_id, recall_date");
            result.Append(nData.ConvertDataTableToHTML(d));
            //if (!nTools.DataTableExists(d))
            //{
            //    result.Append("No Info");
            //    return;
            //}

            //foreach (DataRow r in d.Rows)
            //{
            //    int rt = Tools.Data.NullFilterInt(r["recall_type"]);

            //}
        }

        public override void AsyncFinished()
        {
            base.AsyncFinished();

            wb.ReloadWB();
            wb.Add(result.ToString());

            HideThrobber();
        }
    }
}
