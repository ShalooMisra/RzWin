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
    public partial class ChatMessageSearch : WebReport_User_Date
    {
        //Private Variables
        private Tools.Dates.DateRange range;
        private ArrayList agentNames;

        //Constructors
        public ChatMessageSearch()
        {
            InitializeComponent();
        }
        //Public Override Functions
        public override void CompleteStructure()
        {
            base.CompleteStructure();
            SetCaption("Chat Message Search");
        }
        public override void DoResize()
        {
            try
            {
                base.DoResize();
                lv.Top = wb.Top;
                lv.Left = wb.Left;
                lv.Width = wb.Width;
                lv.Height = wb.Height;
                lv.BringToFront();
            }
            catch { }
        }
        public override void RunReport()
        {
            ShowThrobber();
            agentNames = GetUserIDCollection_BlankIfAll();
            range = GetDateRange();
            base.RunReport();
            string where = range.GetSQL("chat_message.date_created");
            if (agentNames.Count > 0)
                where += "and chat_message.the_n_user_uid in ( " + nTools.GetIn(agentNames) + " ) ";
            if (Tools.Strings.StrExt(ctl_search.GetValue_String()))
                where += " and chat_message.chat_text like '%" + ctl_search.GetValue_String() + "%' ";
            ListArgs a = new ListArgs(RzWin.Context);
            a.TheCaption = "Chat Message Results";
            a.TheClass = "chat_message";
            a.TheContext = RzWin.Context;
            a.TheLimit = 200;
            a.TheOrder = "chat_message.date_created";
            a.TheTable = "chat_message";
            a.TheTemplate = "chat_message_results_view";
            a.TheWhere = where;
            lv.ShowData(a);
        }
    }
}
