using System;
using System.Collections.Generic;
using System.Text;

using Tools;
using Core;
using Core.Display;
using CoreWin;
using NewMethod.Grids;
using Tools.Database;
using System.Data;
using System.Collections;
using System.Reflection;

namespace NewMethod.Win
{
    public class LeaderWinUserNM : LeaderWinUser, ILeaderNM
    {
        public LeaderWinUserNM()
        {

        }

        public LeaderWinUserNM(MainForm f)
            : base(f)
        {

        }

        public override void IconsAppend(List<ImageHandle> icons)
        {
            Assembly thisExe = Assembly.GetExecutingAssembly();
            icons.Add(new ImageHandle("cloud", NewMethodWin.Properties.Resources.cloud));         //1
            icons.Add(new ImageHandle("earth", NewMethodWin.Properties.Resources.earth));         //2
            icons.Add(new ImageHandle("fire", NewMethodWin.Properties.Resources.fire));           //3
            icons.Add(new ImageHandle("lightning", NewMethodWin.Properties.Resources.lightning)); //4
            icons.Add(new ImageHandle("dollar", NewMethodWin.Properties.Resources.fa_dollar)); //5
            icons.Add(new ImageHandle("calendar", NewMethodWin.Properties.Resources.fa_calendar)); //6
            icons.Add(new ImageHandle("plane", NewMethodWin.Properties.Resources.fa_plane)); //7


        }

        ////this is kind of a hack until the nObject structure goes away
        //public override bool Show(Context x, ShowArgs args)
        //{
        //    if (args.TheItems.CountGet(x) > 1)
        //    {
        //        //show a summary page
        //        return false;
        //    }
        //    else
        //    {
        //        IItem item = args.TheItems.FirstGet(x);
        //        return ((ContextNM)x).xSys.Show((nObject)item);
        //    }
        //}

        //Public Override Functions
        public override IView ViewCreate(Context x, ShowArgs args)
        {
            switch (args.ClassId.ToLower())
            {
                case "n_choices":
                    return new nView_n_choices();
                case "n_choice":
                    return new nView_n_choice();
                case "n_user":
                    return new view_n_user();
            }

            return null;
        }
        public virtual void GridShow(Context x, Grid g, String caption)
        {
            GridView v = new GridView();
            TheMainForm.TabShow(v, caption);
            v.Init(g);
        }

        public Enums.DataConversionType AskConversionType(ref String def, String instructions, FieldType fieldType)
        {
            if (FastForwardMode)
                return Enums.DataConversionType.DeleteRow;
            else
                return frmConversionOptions.AskForType(null, ref def, instructions, fieldType);
        }

        public override void ShowSql(string sql)
        {
            TheMainForm.TabShow(new nQuery(sql), "Sql");
        }

        public override string AskForPaste()
        {
            return ToolsWin.Dialogs.Paste.AskForPaste();
        }

        public String ChooseOneChoice(ContextNM x, String strName)
        {
            return ChooseOneChoice(x, strName, "Choose");
        }
        public String ChooseOneChoice(ContextNM x, String strName, String strCaption)
        {
            n_choices c = (n_choices)x.xSys.AllChoices.GetByName(strName);
            if (c == null)
                return "";
            frmChooseOneChoice xForm = new frmChooseOneChoice();
            //xForm.CompleteLoad(c, strCaption);         
            xForm.Init(x.xSys, strName, strCaption, System.Windows.Forms.FormStartPosition.CenterScreen);          
            xForm.ShowDialog();            
            //xForm.Show();
            String s = xForm.SelectedChoice;
            xForm.Close();
            xForm.Dispose();
            xForm = null;
            return s;
        }

        public String ChooseOneChoice(ContextNM x, List<string> theList, String strCaption)
        {
           
            frmChooseOneChoice xForm = new frmChooseOneChoice();
            //xForm.CompleteLoad(c, strCaption);         
            xForm.Init(x.xSys, theList, strCaption, System.Windows.Forms.FormStartPosition.CenterScreen);
            xForm.ShowDialog();
            //xForm.Show();
            String s = xForm.SelectedChoice;
            xForm.Close();
            xForm.Dispose();
            xForm = null;
            return s;
        }
        public String ChooseMultipleChoices(ContextNM x, String strName, String strCaption, String defaultChoicesFullBarSeparated)
        {
            n_choices c = (n_choices)x.xSys.AllChoices.GetByName(strName);
            if (c == null)
                return "";
            frmChooseMultipleChoices xForm = new frmChooseMultipleChoices();
            xForm.DefaultChoicesFullBarSeparated = defaultChoicesFullBarSeparated;
            xForm.CompleteLoad(c, strCaption);
            xForm.ShowDialog();
            String s = xForm.SelectedChoice;
            xForm.Close();
            xForm.Dispose();
            xForm = null;
            return s;
        }

        public override object ChooseFromObjects(List<object> objects, object auto_choose)
        {
            return frmChooseObject.ChooseFromPlainCollection(objects, "Choose");
        }

        public bool AskForAdminRights()
        {
            Error("Need implement");
            return false;
            //String s = AskForString("Enter the password for admin rights:");
            //return s.ToLower().EndsWith(System.DateTime.Now.Hour.ToString());
        }

        public List<ColumnAction> AskForColumnActions(DataTable original)
        {
            return frmDataTableProcess.GetActions(original);
        }

        public n_user AskForUser(ArrayList choices, bool allowAdd)
        {
            String strID = "";
            String strName = "";
            frmChooseUser.ChooseUserName(ref strID, ref strName, choices, allowAdd);
            return n_user.GetById(NMWin.ContextDefault, strID);
        }

        public n_user AskForUser()
        {
            String strID = "";
            String strName = "";
            frmChooseUser.ChooseUserName(ref strID, ref strName, null, false);
            return n_user.GetById(NMWin.ContextDefault, strID);
        }

        public virtual nSearch GetSearch(String strClass, String strExtra)
        {
            //nSearch s = GetSoftSearch(strClass, strExtra);
            //if (s != null)
            //    return s;
            //if (ParentSystem != null)
            //    return ParentSystem.GetSearch(strClass, strExtra);
            return null;
        }

       
    }
}
