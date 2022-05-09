using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Tools;
using Core;
using Tools.Database;
using System.Data;

namespace NewMethod
{
    public class ContextNM : Context
    {
        public SysNewMethod xSys
        {
            get
            {
                return (SysNewMethod)TheSys;
            }

            set
            {
                TheSys = value;
            }
        }

        new public SysNewMethod Sys
        {
            get
            {
                return (SysNewMethod)TheSys;
            }

            set
            {
                TheSys = value;
            }
        }

        public ILeaderNM LeaderNM
        {
            get
            {
                return (ILeaderNM)TheLeader;
            }
        }

        public n_user xUser;

        public ContextNM()
        {

        }

        public ContextNM(Leader l) : base(null, l) 
        {
        }

        //public virtual n_step PathStepAdd(n_path p, n_step s)
        //{
        //    return null;
        //}

        //public override void Show(ShowArgs args)
        //{
        //    if (args.TheItems.CountGet(this) == 1)
        //    {
        //        IItem i = args.TheItems.FirstGet(this);
        //        if (!(i is nObject))
        //            throw new Exception("Not an nObject
        //        nObject x = (nObject)i;
        //        if (!x.CanBeViewedBy(this, args))
        //        {
        //            TheLeader.Error("This workstation is not configured to access this information");
        //            return false;
        //        }
        //        if (TheLeader.Show(this, args))
        //            return true;
        //        xSys.Show(x);
        //    }
        //    else
        //        return false;
        //}

        public override Context Create()
        {
            return new ContextNM();
        }

        public override void Apply(Context x)
        {
            base.Apply(x);
            ((ContextNM)x).xUser = xUser;
        }

        public ArrayList List(ListArgs args)
        {
            return QtC(args.TheClass, "select * from " + args.TheTable + " where " + args.TheWhere + " order by " + args.TheOrder);
        }

        public virtual string GetSystenIdent()
        {
            return "";
        }

        public bool CheckPermit(String permit)
        {
            return ((SysNewMethod)TheSys).ThePermitLogic.CheckPermitBlockOption(this, permit, xUser, blockIfMissing: true);
        }

        public bool CheckPermitAllowMissing(String permit)
        {
            return ((SysNewMethod)TheSys).ThePermitLogic.CheckPermitBlockOption(this, permit, xUser, blockIfMissing: false);
        }

        public void SetSetting(String settingName, String settingValue)
        {
            n_set.SetSetting(this, settingName, settingValue);
        }

        public String GetSetting(String settingName)
        {
            return n_set.GetSetting(this, settingName);
        }

        public void SetSettingBlob(String settingName, byte[] b)
        {
            n_set.SetSettingBlob(this, settingName, b);
        }

        public byte[] GetSettingBlob(String settingName)
        {
            return n_set.GetSettingBlob(this, settingName);
        }

        public void SetSettingInt64(String settingName, Int64 settingValue)
        {
            n_set.SetSetting_Long(this, settingName, settingValue);
        }

        public Int64 GetSettingInt64(String settingName)
        {
            return n_set.GetSetting_Long(this, settingName);
        }

        public void SetSettingInt32(String settingName, Int32 settingValue)
        {
            n_set.SetSetting_Integer(this, settingName, settingValue);
        }

        public Int32 GetSettingInt32(String settingName)
        {
            return n_set.GetSetting_Integer(this, settingName);
        }

        public void SetSettingBoolean(String settingName, bool settingValue)
        {
            n_set.SetSetting_Boolean(this, settingName, settingValue);
        }

        public bool GetSettingBoolean(String settingName)
        {
            return n_set.GetSetting_Boolean(this, settingName);
        }

        public void SetSettingDateTime(String settingName, DateTime settingValue)
        {
            n_set.SetSetting_Date(this, settingName, settingValue);
        }

        public DateTime GetSettingDateTime(String settingName)
        {
            return n_set.GetSetting_Date(this, settingName);
        }

        public void SetSettingDouble(String settingName, Double settingValue)
        {
            n_set.SetSetting_Double(this, settingName, settingValue);
        }

        public Double GetSettingDouble(String settingName)
        {
            return n_set.GetSetting_Double(this, settingName);
        }

        public virtual String ProgramCaption
        {
            get
            {
                return "this program";
            }
        }
    }

    public interface ILeaderNM : ILeader
    {
        void GridShow(Context x, Grid g, String caption);
        Enums.DataConversionType AskConversionType(ref String def, String instructions, FieldType fieldType);
        String ChooseOneChoice(ContextNM x, String strName);
        string ChooseOneChoice(ContextNM x, List<string> List, string strCaption);
        String ChooseOneChoice(ContextNM x, String strName, String strCaption);        
        String ChooseMultipleChoices(ContextNM x, String strName, String strCaption, String defaultChoicesFullBarSeparated);
        bool AskForAdminRights();
        List<ColumnAction> AskForColumnActions(DataTable original);
        n_user AskForUser(ArrayList choices, bool allowAdd);
        n_user AskForUser();
    }
}
