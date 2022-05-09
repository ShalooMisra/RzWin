using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using NewMethod;

namespace Rz5
{
    public partial class addresshandler : addresshandler_auto
    {
        //Public Functions
        public void ScanData(String strData, ref String strCompany, ref String strContact, ref String strPhone, ref String strFax)
        {
            strCompany = ScanDataItem(strData, companymap, companystop);
            strContact = ScanDataItem(strData, contactmap, contactstop);
            strPhone = ScanDataItem(strData, phonemap, phonestop);
            strFax = ScanDataItem(strData, faxmap, faxstop);
        }
        //Private Functions
        private String ScanDataItem(String strData, String strMap, String strStop)
        {
            Int64 lngMark = 0;
            Int64 lngCursor = 1;
            String strLine = nTools.GetNextLine(ref strMap);
            String strLastLine = strLine;
            while (!Tools.Strings.StrCmp(strLine, "%%EOF%%"))
            {
                lngMark = strData.IndexOf(strMap, (Int32)lngCursor);
                if (lngMark <= 0)
                    return "";
                lngCursor = lngMark;
                strLastLine = strLine;
                strLine = nTools.GetNextLine(ref strMap);
            }
            lngMark = strData.IndexOf(strStop, (Int32)lngCursor);
            if (lngMark <= 0)
                return "";
            return strData.Substring((Int32)(lngCursor + strLastLine.Length), (Int32)(lngMark - (lngCursor + strLastLine.Length))).Replace("\n", "").Replace("\r", "");
        }
    }
}
