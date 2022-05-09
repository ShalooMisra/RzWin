using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tools.Database;

namespace Core
{
    public class Start
    {
       public virtual void Init(Context context, StartArgs args)
        {
            try
            {
                InitData(context, args);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            try
            {
                InitSystem(context, args);
            }
            catch (Exception ex)
            {
                throw ex;
            } 
            
            try
            { 
                InitStructure(context, args);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            try
            {
                InitComplete(context, args);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected virtual void InitData(Context context, StartArgs args)
        {
            context.TheData = new DataSql();
            context.TheData.Init(context, args.DataKey);

            context.TheLeader.Comment("Connecting with " + context.Data.TheConnection.ConnectionString);
            String strDc = "";
            if (!context.Data.TheConnection.ConnectPossible(ref strDc))
                throw new Exception("Data connect failed: " + strDc);
        }

        protected virtual void InitSystem(Context context, StartArgs args)
        {
            context.Sys = SystemCreate();
        }

        protected virtual void InitStructure(Context context, StartArgs args)
        {
            if (StructureUpdateNeeded(context, args))
            {
                try
                {
                    StructureUpdate(context, args);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                try
                {
                    StructureUpdateComplete(context, args);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected virtual void StructureUpdate(Context context, StartArgs args)
        {
            context.StructureCheck();

            //added 2012_09_28
            //DataSql.FieldMaintenance(context, (DataConnectionSqlServer)context.Data.Connection);
        }

        protected virtual void StructureUpdateComplete(Context context, StartArgs args)
        {
            //takes way too long on loadup
            //context.Sys.FieldMaintenance(context);
        }

        protected virtual bool StructureUpdateNeeded(Context context, StartArgs args)
        {
            return (args.CheckStructureUpdate || Tools.Strings.HasString(System.Environment.CommandLine, "-CheckStructureUpdate"));
        }

        protected virtual void InitComplete(Context context, StartArgs args)
        {
            context.Logic.Init(context);
        }

        protected virtual Sys SystemCreate()
        {
            return new Sys();
        }
    }

    public class StartArgs
    {
        public DataKeySql DataKey;
        public bool CheckStructureUpdate = false;
    }
}
