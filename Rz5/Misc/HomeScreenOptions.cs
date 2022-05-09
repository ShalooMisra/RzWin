using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using NewMethod;

namespace Rz5
{
    public class HomeScreenOption
    {
        public String Name = "";
        public String Caption = "";
        public String ClassName = "";
        public String Where = "";
        public String WhereNoUsers = "";
        public String OrderField = "";
        public String TemplateName = "";
        public bool UnlimitedResults = false;
        public bool All = false;
        public string SelectedIDs = "";
        public string DateRange = "";
        public bool NSNView = false;
        public string NSNSearch = "";
        public long Limit = 0;

        public HomeScreenOption(String strName, String strCaption, String strClassName, String strWhere, String strWhereNoUsers, String strOrderField, String strTemplateName)
        {
            Name = strName;
            Caption = strCaption;
            ClassName = strClassName;
            Where = strWhere;
            WhereNoUsers = strWhereNoUsers;
            OrderField = strOrderField;
            TemplateName = strTemplateName;
        }

        public virtual String SearchGet(ContextNM x, HomePanelSearchArgs args)
        {
            return "";
        }
    }

    public class HomeScreenOptionNotes : HomeScreenOption
    {
        public HomeScreenOptionNotes(String strName, String strCaption, String strClassName, String strWhere, String strWhereNoUsers, String strOrderField, String strTemplateName)
            : base(strName, strCaption, strClassName, strWhere, strWhereNoUsers, strOrderField, strTemplateName)
        {

        }

        public override string SearchGet(ContextNM x, HomePanelSearchArgs args)
        {
            HomePanelNotesArgs nargs = (HomePanelNotesArgs)args;
            String ret = "";
            if (Tools.Strings.StrExt(nargs.SearchTerm))
                ret = " and ( companyname like '%" + x.Filter(nargs.SearchTerm) + "%' or subjectstring like '%" + x.Filter(nargs.SearchTerm) + "%' or notetext like '%" + x.Filter(nargs.SearchTerm) + "%' ) ";

            if (nargs.OnlyOpen)
                ret += " and isnull(isclosed, 0) = 0 ";
            else if (nargs.OnlyClosed)
                ret += " and isnull(isclosed, 0) = 1 ";

            return ret;
        }
    }

    public class HomeScreenOptionBatches : HomeScreenOption
    {
        public HomeScreenOptionBatches(String strName, String strCaption, String strClassName, String strWhere, String strWhereNoUsers, String strOrderField, String strTemplateName)
            : base(strName, strCaption, strClassName, strWhere, strWhereNoUsers, strOrderField, strTemplateName)
        {

        }

        public override string SearchGet(ContextNM x, HomePanelSearchArgs args)
        {
            HomePanelBatchesArgs nargs = (HomePanelBatchesArgs)args;
            String ret = "";
            if (Tools.Strings.StrExt(nargs.SearchTerm))
            {
                ret += " and ( customer_name like '%" + x.Filter(nargs.SearchTerm) + "%' or contact_name like '%" + x.Filter(nargs.SearchTerm) + "%' or dealheader_name like '%" + x.Filter(nargs.SearchTerm) + "%' ) ";
            }

            if (nargs.OnlyOpen)
                ret += " and isnull(is_closed, 0) = 0 ";
            else if (nargs.OnlyClosed)
                ret += " and isnull(is_closed, 0) = 1 ";

            if (nargs.OppStage != "All")
                ret += "and opportunity_stage = '" + nargs.OppStage + "'";
            //switch(nargs.OppStage)
            //{
            //    case "Identify":
            //        " and opportunity_stage"
            //}


            return ret;
        }
    }

    public class HomePanelBatchesArgs : HomePanelSearchArgs
    {
        public String SearchTerm;
        public bool OnlyOpen;
        public bool OnlyClosed;

        //KT - Setting filter for Opportunity Stage
        //public HomePanelBatchesArgs(String search, bool only_open, bool only_closed)
        //{
        //    SearchTerm = search;
        //    OnlyOpen = only_open;
        //    OnlyClosed = only_closed;
        //}
        public string OppStage;
        public HomePanelBatchesArgs(String search, bool only_open, bool only_closed, string opp_stage)
        {
            SearchTerm = search;
            OnlyOpen = only_open;
            OnlyClosed = only_closed;
            OppStage = opp_stage;
        }
    }


    public class HomePanelSearchArgs
    {

    }

    public class HomePanelNotesArgs : HomePanelSearchArgs
    {
        public String SearchTerm;
        public bool OnlyOpen;
        public bool OnlyClosed;

        public HomePanelNotesArgs(String search, bool only_open, bool only_closed)
        {
            SearchTerm = search;
            OnlyOpen = only_open;
            OnlyClosed = only_closed;
        }
    }
}