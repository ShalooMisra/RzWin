using System;
using System.Collections.Generic;
using System.Text;

using Core;
using Tools.Database;

namespace Core
{
    public class DataKeySql : DataKeySqlBase
    {
        //public DataKeySql(ItemArgs a)
        //    : base(a)
        //{
        //}

        public DataKeySql()
        {

        }

        public DataKeySql(ServerType type)
        {
            ServerTypeVar.Value = type;
        }

        public Tools.Database.Key KeyConnection
        {
            get
            {
                Tools.Database.Key ret = new Tools.Database.Key();
                ret.ServerName = ServerNameVar.ValueString;
                ret.DatabaseName = DatabaseNameVar.ValueString;
                ret.UserName = UserNameVar.ValueString;
                ret.UserPassword = UserPasswordVar.ValueString;
                ret.FolderPath = FolderPathVar.ValueString;
                return ret;
            }
        }

        public bool Valid
        {
            get
            {
                return Tools.Strings.StrExt(ServerName) && Tools.Strings.StrExt(DatabaseName) && Tools.Strings.StrExt(UserName) && Tools.Strings.StrExt(UserPassword);
            }
        }
    }
}
