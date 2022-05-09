using System;
using System.Collections.Generic;
using System.Text;

using Tools;
using Tools.Database;
using Core;

namespace Core
{
    class DataXml : DataStore
    {
        public DataKeyXml TheKeyXml
        {
            get
            {
                return (DataKeyXml)TheKey;
            }
        }
    }
}
