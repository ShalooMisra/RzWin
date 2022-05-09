using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

using OfficeOpenXml;

using Tools.Database;
using Core;

namespace NewMethod
{
    public class nObjectHandle
    {
        public String ClassName = "";
        public String unique_id = "";
        public String ExtraClassInfo = "";
        public String AlternateTable = "";
        public nObjectHandle(String strClass, String strID, String AltTableName)
        {
            ClassName = strClass;
            unique_id = strID;
            AlternateTable = AltTableName;
        }
        //Public Functions
        public nObject GetObject(ContextNM context)
        {
            try
            {
                nObject obj = (nObject)context.GetById(ClassName, unique_id, AlternateTable);
                return obj;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
