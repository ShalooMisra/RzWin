using System;
using System.Data;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;
using System.Drawing;
using System.Xml;
using ICSharpCode.SharpZipLib.Zip;

using Tools;
using Tools.Database;

namespace NewMethod
{
    
    public partial class nTools
    {
        //Tools.Strings
        public static String GetNextLine(ref String strIn)
        {
            return Tools.Strings.GetNextLine(ref strIn);
        }
        public static Boolean StrExt(String s)
        {
            return Tools.Strings.StrExt(s);
        }
        public static Boolean StrCmp(String s1, String s2)
        {
            return Tools.Strings.StrCmp(s1, s2);
        }
        public static String CStr(Object i)
        {
            return Tools.Strings.CStr(i);
        }
        public static String Format(String strFormat, Object o)
        {
            return Tools.Strings.Format(strFormat, o);
        }
        public static String YesBlankFilter(bool b)
        {
            return Tools.Strings.YesBlankFilter(b);
        }
        public static String YesNoFilter(bool b)
        {
            return Tools.Strings.YesNoFilter(b);
        }
        public static String NiceFormat(String s)
        {
            return Tools.Strings.NiceFormat(s);
        }
        public static String Right(String strIn, int len)
        {
            return Tools.Strings.Right(strIn, len);
        }
        public static String Left(String strIn, int len)
        {
            return Tools.Strings.Left(strIn, len);
        }
        public static bool HasString(string str, string f)
        {
            return Tools.Strings.HasString(str, f);
        }
        public static bool HasString(string str, string[] f)
        {
            return Tools.Strings.HasString(str, f);
        }
        public static String Space(int l)
        {
            return Tools.Strings.Space(l);
        }
        public static string StripNonAlphaNumeric(String s, bool AllowUnderscores)
        {
            return Tools.Strings.StripNonAlphaNumeric(s, AllowUnderscores);
        }
        public static string StripNonNumeric(String s)
        {
            return Tools.Strings.StripNonNumeric(s);
        }
        public static string StripNonNumeric(String s, bool AllowPeriods)
        {
            return Tools.Strings.StripNonNumeric(s, AllowPeriods);
        }
        public static String GetFirstLine(String s)
        {
            return Tools.Strings.GetFirstLine(s);
        }
        public static String ParseDelimit(String strIn, String s, int p)
        {
            return Tools.Strings.ParseDelimit(strIn, s, p);
        }
        public static String FilterPhoneNumber(String strPhone)
        {
            return Tools.Industry.FilterPhoneNumber(strPhone);
        }
        public static String FilterPhoneNumber(String strPhone, String strAreaCode)
        {
            return Tools.Industry.FilterPhoneNumber(strPhone, strAreaCode);
        }
        public static ArrayList GetUniqueStrings(ArrayList a, ArrayList b)
        {
            return Tools.Strings.GetUniqueStrings(a, b);
        }
        public static String BlockString(String s, int b)
        {
            return Tools.Strings.BlockString(s, b);
        }
        public static String GetIDString(ArrayList l)
        {
            return Tools.ToolsNM.GetIDString(l);
        }
        public static String GetIDString(SortedList l)
        {
            return Tools.ToolsNM.GetIDString(l);
        }
        public static String FilterEverythingButNumbers(String strIn)
        {
            return Tools.Strings.FilterEverythingButNumbers(strIn);
        }
        //public static String FilterTrash(String strIn)
        //{
        //    return Tools.Strings.FilterTrash(strIn);
        //}
        //public static String FilterTrash(String strIn, bool RemoveNumbers, bool OnlySymbols)
        //{
        //    return Tools.Strings.FilterTrash(strIn, RemoveNumbers, OnlySymbols);
        //}
        public static string StrReplace(string original, string pattern, string replacement)
        {
            return Tools.Strings.StrReplace(original, pattern, replacement);
        }
        public static String StrReverse(String strIn)
        {
            return Tools.Strings.StrReverse(strIn);
        }
        public static String Trim(String s)
        {
            return Tools.Strings.Trim(s);
        }
        public static String[] Split(String strIn, String strSplit)
        {
            return Tools.Strings.Split(strIn, strSplit);
        }
        public static void SplitInTwo(String start, ref String str1, ref String str2, String split)
        {
            Tools.Strings.SplitInTwo(start, ref str1, ref str2, split);
        }
        public static ArrayList SplitArray(String strIn, String strSplit)
        {
            return Tools.Strings.SplitArray(strIn, strSplit);
        }
        public static ArrayList ToArray(String[] ary)
        {
            return Tools.Strings.ToArray(ary);
        }
        public static String ReplaceVisualAll(String s)
        {
            return Tools.Strings.ReplaceVisualAll(s);
        }
        public static String ReplaceVisual(String strBase, String str1, String str2, String str3)
        {
            return Tools.Strings.ReplaceVisual(strBase, str1, str2, str3);
        }
        public static String Replace(String strExpression, String strSearch, String strReplace)
        {
            return Tools.Strings.Replace(strExpression, strSearch, strReplace);
        }
        public static int CharCount(String s, Char l)
        {
            return Tools.Strings.CharCount(s, l);
        }
        public static String[] SplitLines(String s)
        {
            return Tools.Strings.SplitLines(s);
        }
        public static bool IsInArray(ArrayList a, String s)
        {
            return Tools.Strings.IsInArray(a, s);
        }
        public static bool IsInArray(String s, ArrayList a)
        {
            return Tools.Strings.IsInArray(s, a);
        }
        public static String ChopFront(String strIn, String strFront)
        {
            return Tools.Strings.ChopFront(strIn, strFront);
        }
        public static String Mid(String s, int start)
        {
            return Tools.Strings.Mid(s, start);
        }
        public static String Mid(String s, int start, int length)
        {
            return Tools.Strings.Mid(s, start, length);
        }
        public static int Len(String s)
        {
            return Tools.Strings.Len(s);
        }
        public static Boolean CharInAlphabet(Char c)
        {
            return Tools.Strings.CharInAlphabet(c);
        }
        public static Boolean CharInAlphabet(String c)
        {
            return Tools.Strings.CharInAlphabet(c);
        }
        public static bool StrCmpExcludingTrash(String str1, String str2)
        {
            return Tools.Strings.StrCmpExcludingTrash(str1, str2);
        }
        public static String GetInsert(String strLine, String strStart, String strEnd)
        {
            return Tools.Strings.GetInsert(strLine, strStart, strEnd);
        }
        public static String GetInsert(String strLine, String strStart, String strEnd, String strAlternateEnd)
        {
            return Tools.Strings.GetInsert(strLine, strStart, strEnd, strAlternateEnd);
        }
        public static bool StartsWith(String strBase, String strStart)
        {
            return Tools.Strings.StartsWith(strBase, strStart);
        }
        public static bool IncludesLine(String strText, String s)
        {
            return Tools.Strings.IncludesLine(strText, s);
        }
        public static String Pluralize(String name, Double num)
        {
            return Tools.Strings.PluralizeNameOnly(name, num);
        }
        public static String TrimLeadingChars(String s, String ch)
        {
            return Tools.Strings.TrimLeadingChars(s, ch);
        }
        public static ArrayList KillBlankLines(ArrayList a)
        {
            return Tools.Strings.KillBlankLines(a);
        }
        public static String KillBlankLines(String s)
        {
            return Tools.Strings.KillBlankLines(s);
        }
        public static String BulkReplace(String s, String[] r)
        {
            return Tools.Strings.BulkReplace(s, r);
        }
        public static bool IsIn(String strStart, String strLook)
        {
            return Tools.Strings.IsIn(strStart, strLook);
        }
        //Tools.Number
        public static String MoneyFormat_2_6(Double d)
        {
            return Tools.Number.MoneyFormat_2_6(d);
        }
        public static long DivideWithFractions(long lng1, long lng2)
        {
            return Tools.Number.DivideWithFractions(lng1, lng2);
        }
        public static String LongFormat(Double d)
        {
            return Tools.Number.LongFormat(d);
        }
        public static String LongFormat(long l)
        {
            return Tools.Number.LongFormat(l);
        }
        public static String LongFormat(int i)
        {
            return Tools.Number.LongFormat(i);
        }
        public static String LongFormatBlank(int i)
        {
            return Tools.Number.LongFormatBlank(i);
        }
        public static String MoneyFilter(String s)
        {
            return Tools.Number.MoneyFilter(s);
        }
        public static Double MoneyFilterAsDouble(String s)
        {
            return Tools.Number.MoneyFilterAsDouble(s);
        }
        public static String QuantityFilter(String s)
        {
            return Tools.Number.QuantityFilter(s);
        }
        public static long QuantityFilterAsLong(String s)
        {
            return Tools.Number.QuantityFilterAsLong(s);
        }
        public static String MoneyFormat(Double d)
        {
            return Tools.Number.MoneyFormat(d);
        }
        public static Int32 GetRandomInteger()
        {
            return Tools.Number.GetRandomInteger();
        }
        public static Int32 GetRandomInteger(int min, int max)
        {
            return Tools.Number.GetRandomInteger(min, max);
        }
        public static Int64 GetRandomLong()
        {
            return Tools.Number.GetRandomLong();
        }
        public static Int64 GetRandomLong(Int64 low, Int64 high)
        {
            return Tools.Number.GetRandomLong(low, high);
        }
        public static Double GetRandomFloat()
        {
            return Tools.Number.GetRandomFloat();
        }
        public static String PadTwoDigits(String s)
        {
            return Tools.Number.PadTwoDigits(s);
        }
        public static bool IsNumeric(String s)
        {
            return Tools.Number.IsNumeric(s);
        }
        public static long CalcPercent(long large, long small)
        {
            return Tools.Number.CalcPercent(large, small);
        }
        public static int CalcPercent(int large, int small)
        {
            return Tools.Number.CalcPercent(large, small);
        }
        public static double CalcPercent(Double large, Double small)
        {
            return Tools.Number.CalcPercent(large, small);
        }
        //Tools.Files
        public static String FilterFileNameTrash(String s)
        {
            return Tools.Files.FilterFileNameTrash(s);
        }
        public static String RelativeToAbsolute(String strRelative, String strFolder)
        {
            return Tools.Files.RelativeToAbsolute(strRelative, strFolder);
        }
        public static String AbsoluteToRelative(String strFile, String strFolder)
        {
            return Tools.Files.AbsoluteToRelative(strFile, strFolder);
        }
        public static void MakeBackup(String f)
        {
            Tools.Files.MakeBackup(f);
        }

        public static bool BinCpy(String strOriginal, String strNew)
        {
            return Tools.Files.BinCpy(strOriginal, strNew);
        }
        public static String GetFileNameNoExtention(String strFilePath)
        {
            return Tools.Files.GetFileNameNoExtention(strFilePath);
        }
        public static bool SaveFileAsString(String strFileName, String strData)
        {
            return Tools.Files.SaveFileAsString(strFileName, strData);
        }
        public static String OpenFileAsString(String strFile)
        {
            return Tools.Files.OpenFileAsString(strFile);
        }
        public static bool Shell(String strFilePath)
        {
            return Tools.FileSystem.Shell(strFilePath);
        }
        public static bool Shell(String strFilePath, String strArguments)
        {
            return Tools.FileSystem.Shell(strFilePath, strArguments);
        }
        public static bool Shell(String strFilePath, String strArguments, StringBuilder sb, bool NoWindow, bool WaitForDone)
        {
            string s = "";
            bool b = Tools.FileSystem.Shell(strFilePath, strArguments, NoWindow, WaitForDone, ref s);
            sb.Append(s);
            return b;
        }
        public static bool ShellAndViewOutput(String strFilePath, String strArguments, ref String output, String strIgnore)
        {
            return Tools.FileSystem.ShellAndViewOutput(strFilePath, strArguments, ref output, strIgnore);
        }
        public static bool PopText(String s)
        {
            return Tools.FileSystem.PopText(s);
        }
        public static bool PopTextFile(String strFile)
        {
            return Tools.FileSystem.PopTextFile(strFile);
        }
        public static bool HasFileName(String s)
        {
            return Tools.Files.HasFileName(s);
        }
        public static SortedList GetHighestFileCollection(String strFolder)
        {
            return Tools.Files.GetHighestFileCollection(strFolder);
        }
        public static String RemoveNumberedFileName(String strFile)
        {
            return Tools.Files.RemoveNumberedFileName(strFile);
        }
        public static Int64 GetHighestFileNumber(String[] files, String strBaseName, ref String strActualName)
        {
            return Tools.Files.GetHighestFileNumber(files, strBaseName, ref strActualName);
        }
        public static String GetHighestFileName(String strFolder, String strBaseName)
        {
            return Tools.Files.GetHighestFileName(strFolder, strBaseName);
        }
        public static Int64 GetHighestFileNumber(String strFolder, String strBaseName)
        {
            return Tools.Files.GetHighestFileNumber(strFolder, strBaseName);
        }
        public static Int64 GetHighestFileNumber(String strFolder, String strBaseName, ref String strActualName)
        {
            return Tools.Files.GetHighestFileNumber(strFolder, strBaseName, ref strActualName);
        }
        public static Int64 GetFileNumber(String strFileName)
        {
            return Tools.Files.GetFileNumber(strFileName);
        }
        public static String GetFileName(String fullpath)
        {
            return Tools.Files.GetFileName(fullpath);
        }
        public static String GetFileExtention(String file)
        {
            return Tools.Files.GetFileExtention(file);
        }
        public static String InsertNumberedFileName(String strName, Int64 num)
        {
            return Tools.Files.InsertNumberedFileName(strName, num);
        }
        public static String GetNextNumberedFileName(String strFolder, String strName)
        {
            return Tools.Files.GetNextNumberedFileName(strFolder, strName);
        }
        public static bool WriteTestFile(String strFolder)
        {
            return Tools.Files.WriteTestFile(strFolder);
        }
        public static bool WriteTestFile(String strFolder, ref String strCool)
        {
            return Tools.Files.WriteTestFile(strFolder, ref strCool);
        }
        public static ArrayList GetFileCollection(String strFolder, String strBase)
        {
            return Tools.Files.GetFileCollection(strFolder, strBase);
        }
        public static void TryDeleteFile(String strFile)
        {
            Tools.Files.TryDeleteFile(strFile);
        }
        //public static String ChooseAFile(System.Windows.Forms.IWin32Window owner)
        //{
        //    return ToolsWin.FileSystem.ChooseAFile(owner);
        //}
        public static void CoalesceFileNames(ref ArrayList ary, String strFolder, String strExtension)
        {
            Tools.Files.CoalesceFileNames(ref ary, strFolder, strExtension);
        }
        public static bool AppendLogFile(String strFile, String strLine)
        {
            return Tools.Files.AppendLogFile(strFile, strLine);
        }
        public static bool OpenFileInDefaultViewer(String strFile)
        {
            return Tools.Files.OpenFileInDefaultViewer(strFile);
        }

        public static bool FilesAreExactlyTheSame(string file1, string file2)
        {
            return Tools.Files.FilesAreExactlyTheSame(file1, file2);
        }
        public static String SpaceFormat(long l)
        {
            return Tools.Files.SpaceFormat(l);
        }
        //Tools.Folder
        public static String ConditionFolderName(String s)
        {
            return Tools.Folder.ConditionFolderName(s);
        }
        public static String FilterPath(String s)
        {
            return Tools.Folder.FilterPath(s);
        }
        public static String GetTopLevelFolderName(String s)
        {
            return Tools.Folder.GetTopLevelFolderName(s);
        }
        public static String GetFolderName(String strFilePath)
        {
            return Tools.Folder.GetFolderName(strFilePath);
        }
        public static void MakeFolderExist(String f)
        {
            Tools.Folder.MakeFolderExist(f);
        }
        public static String GetAppPath()
        {
            return Tools.Folder.GetAppPath();
        }
        public static String GetAppParentPath()
        {
            return Tools.FileSystem.GetAppParentPath();
        }
        public static String GetDirectoryParent(String s)
        {
            return Tools.FileSystem.GetDirectoryParent(s);
        }
        public static String GetNowPath()
        {
            return Tools.Folder.GetNowPath();
        }
        public static String GetNowPathPlusTime()
        {
            return Tools.Folder.GetNowPathPlusTime();
        }
        public static String GetDriveLetter()
        {
            return Tools.Folder.GetDriveLetter();
        }

        public static void TryUnlockFolder(String strFolder)
        {
            Tools.Folder.TryUnlockFolder(strFolder);
        }

        public static bool ExploreFolder(String strFolder)
        {
            return Tools.Folder.ExploreFolder(strFolder);
        }
        public static bool SoftUpdateFolder(String strSource, String strDest)
        {
            return Tools.Folder.SoftUpdateFolder(strSource, strDest);
        }
        //Tools.ZipUnZip
        public static bool ZipOneFile(String strFileName, String strZipName)
        {
            return Tools.Zip.ZipOneFile(strFileName, strZipName);
        }
        public static bool UnZipOneFile(String strZipName, String strFolder)
        {
            return Tools.Zip.UnZipOneFile(strZipName, strFolder);
        }
        public static bool ZipFolder(String FolderPath, String SavePath, String ZipName)
        {
            return Tools.Zip.ZipFolder(FolderPath, SavePath, ZipName);
        }
        //Tools.XML
        public static String BuildXmlProp(String strName, long val)
        {
            return Tools.Xml.BuildXmlProp(strName, val);
        }
        public static String BuildXmlProp(String strName, int val)
        {
            return Tools.Xml.BuildXmlProp(strName, val);
        }
        public static String BuildXmlProp(String strName, bool val)
        {
            return Tools.Xml.BuildXmlProp(strName, val);
        }
        public static String BuildXmlProp(String strName, String strValue)
        {
            return Tools.Xml.BuildXmlProp(strName, strValue);
        }
        public static String BuildXmlProp(String strName, String strValue, bool encode)
        {
            return Tools.Xml.BuildXmlProp(strName, strValue, encode);
        }
        public static String ReadXmlProp(XmlNode n, String strName)
        {
            return Tools.Xml.ReadXmlProp(n, strName);
        }
        public static long ReadXmlProp_Long(XmlNode n, String strName)
        {
            return Tools.Xml.ReadXmlProp_Long(n, strName);
        }
        public static int ReadXmlProp_Integer(XmlNode n, String strName)
        {
            return Tools.Xml.ReadXmlProp_Integer(n, strName);
        }
        public static bool ReadXmlProp_Boolean(XmlNode n, String strName)
        {
            return Tools.Xml.ReadXmlProp_Boolean(n, strName);
        }
        public static String EncodeForXml(String s)
        {
            return Tools.Xml.EncodeForXml(s);
        }

        public static String GetNewID()
        {
            return Tools.Strings.GetNewID();
        }
        public static bool GetFileFTP(FTP ftplib, String strName, String strLocal, FTPProgressHandler progress, FTPStatusHandler status)
        {
            return Tools.Ftp.GetFileFTP(ftplib, strName, strLocal, progress, status);
        }
        //Tools.HTML
        public static String ConvertTextToHTML(String strText)
        {
            return Tools.Html.ConvertTextToHTML(strText);
        }
        public static String ConvertTextToHTML_AllowBreaks(String strText)
        {
            return Tools.Html.ConvertTextToHTML_AllowBreaks(strText);
        }
        public static String ConvertHTMLToText_Quick(String strHTML)
        {
            return Tools.Html.ConvertHTMLToText_Quick(strHTML);
        }

        public static String WebTrim(String s)
        {
            return Tools.Html.WebTrim(s);
        }

        public static String GetHTMLColor(int color)
        {
            return Tools.Html.GetHTMLColor(color);
        }
        public static String RemoveHTMLScripts(String s)
        {
            return Tools.Html.RemoveHTMLScripts(s);
        }
        public static String RemoveHTMLComments(String s)
        {
            return Tools.Html.RemoveHTMLComments(s);
        }
        //Tools.Industry
        public static String DistillPhoneNumber(String s)
        {
            return Tools.Industry.DistillPhoneNumber(s);
        }
        public static bool IsTermsCreditCard(String terms)
        {
            return Tools.Industry.IsTermsCreditCard(terms);
        }
        public static bool IsTermsCreditCard(String terms, bool excludegeneric)
        {
            return Tools.Industry.IsTermsCreditCard(terms, excludegeneric);
        }
        public static bool IsTermsCOD(String terms)
        {
            return Tools.Industry.IsTermsCOD(terms);
        }
        public static bool IsTermsTT(String terms)
        {
            return Tools.Industry.IsTermsTT(terms);
        }
        public static bool IsEmailAddress(String s)
        {
            return Tools.Email.IsEmailAddress(s);
        }
        public static String ParseEmailDomain(String strEmail)
        {
            return Tools.Email.ParseEmailDomain(strEmail);
        }
        public static String ParseEmailSuffix(String strEmail)
        {
            return Tools.Email.ParseEmailSuffix(strEmail);
        }
        public static bool IsPhoneNumber(String s)
        {
            return Tools.Industry.IsPhoneNumber(s);
        }
        public static String StripPhoneNumber(String s)
        {
            return Tools.Industry.StripPhoneNumber(s);
        }
        public static bool StripPhoneNumberField(DataConnection xd, String strTable, String strField)
        {
            return Tools.Industry.StripPhoneNumberField(xd, strTable, strField);
        }
        //Tools.Colors
        public static System.Drawing.Color GetColorFromInt(int c)
        {
            return Tools.Colors.GetColorFromInt(c);
        }
        public static int GetIntFromColor(System.Drawing.Color c)
        {
            return Tools.Colors.GetIntFromColor(c);
        }
        //public static int ChooseColor(System.Windows.Forms.IWin32Window owner)
        //{
        //    return ToolsWin.Screens.ChooseColor(owner);
        //}
        public static string RGBtoHEX(int Value)
        {
            return Tools.Colors.RGBtoHEX(Value);
        }
        public static Color ColorFromHex(String strHex)
        {
            return Tools.Colors.ColorFromHex(strHex);
        }
        public static Bitmap EnsureGraphicsCompatibleBitmap(Bitmap b)
        {
            return Tools.Colors.EnsureGraphicsCompatibleBitmap(b);
        }
        //Tools.Picture
        public static Image GetImage(String strFile, int width, int height)
        {
            return Tools.Picture.GetImage(strFile, width, height);
        }
        public static Image GetGenericThumbnail(int width, int height)
        {
            return Tools.Picture.GetGenericThumbnail(width, height);
        }
        public static Image GetThumbnail(Image i, int width, int height)
        {
            return Tools.Picture.GetThumbnail(i, width, height);
        }
        public static bool ThumbnailCallback()
        {
            return Tools.Picture.ThumbnailCallback();
        }
        public static bool IsPictureFile(String strFile)
        {
            return Tools.Picture.IsPictureFile(strFile);
        }
        //Tools.Data
        //public static Object ReplaceNull(Int32 xType)
        //{
        //    return nData.ReplaceNull(xType);
        //}
        public static void FilterTrashField(DataConnection xd, String strTable, String strField, bool RemoveNumbers, bool OnlySymbols)
        {
            nData.FilterTrashField(xd, strTable, strField, RemoveNumbers, OnlySymbols, "");
        }
        public static void BulkReplaceField(DataConnectionSqlServer xd, String strTable, String strField, String[] r)
        {
            nData.BulkReplaceField(xd, strTable, strField, r, "");
        }
        public static String GetIn(ArrayList a, bool include_blank = false)
        {
            return Tools.Data.GetIn(a, include_blank);
        }
        public static String GetIn_nObjects(ArrayList a)
        {
            return nData.GetIn_nObjects(a);
        }
        public static String GetIn_nObjects(ArrayList a, String fieldname)
        {
            return nData.GetIn_nObjects(a, fieldname);
        }
        public static String GetIn_Integer(ArrayList a)
        {
            return Tools.Data.GetIn_Integer(a);
        }
        public static ArrayList ConvertToArray(SortedList s)
        {
            return Tools.Data.ConvertToArray(s);
        }
        public static Object GetTestValue(FieldType type, Int32 length)
        {
            return Tools.Data.GetTestValue(type, length);
        }

        public static bool DataTableExists(System.Data.DataTable t)
        {
            return Tools.Data.DataTableExists(t);
        }
        public static String BoolToYN(bool b)
        {
            return Tools.Data.BoolToYN(b);
        }
        public static bool StripField(nDataTable d, String strField)
        {
            return nData.StripField(d, strField);
        }
        public static bool StripField(DataConnectionSqlServer xd, String strTable, String strField)
        {
            return xd.StripField(strTable, strField);
        }
        public static byte[] FromHex(string s)
        {
            return Tools.Data.FromHex(s);
        }
        public static String DecodeBinaryString(Byte[] b, String strEncoding)
        {
            return Tools.Data.DecodeBinaryString(b, strEncoding);
        }
        public static bool IsInCollection(String strFind, SortedList s)
        {
            return Tools.Data.IsInCollection(strFind, s);
        }
        public static void AppendArray(ArrayList container, ArrayList contents)
        {
            Tools.Data.AppendArray(container, contents);
        }
        //Tools.Dates
        public static int GetMonthEndDate(Int32 month, Int32 year)
        {
            return Tools.Dates.GetMonthEndDate(month, year);
        }
        public static DateTime GetBlankDate()
        {
            return Tools.Dates.GetBlankDate();
        }
        public static bool DateExists(DateTime d)
        {
            return Tools.Dates.DateExists(d);
        }
        public static String DateFormat(DateTime d)
        {
            return Tools.Dates.DateFormat(d);
        }
        public static String TimeFormat(DateTime d)
        {
            return Tools.Dates.TimeFormat(d);
        }
        public static String TimeFormat24(DateTime d)
        {
            return Tools.Dates.TimeFormat24(d);
        }
        public static String TimeFormat_WithSeconds(DateTime d)
        {
            return Tools.Dates.TimeFormat_WithSeconds(d);
        }
        public static String DateFormat_ShortDateTime(DateTime d)
        {
            return Tools.Dates.DateFormat_ShortDateTime(d);
        }
        public static String DateFormat_Extra(DateTime d)
        {
            return Tools.Dates.DateFormat_Extra(d);
        }
        public static DateTime BuildDate_YM(int year, int month)
        {
            return Tools.Dates.BuildDate_YM(year, month);
        }
        public static DateTime GetNullDate()
        {
            return Tools.Dates.GetNullDate();
        }
        public static DateTime ParseDate_YYYY_MM_DD(String s)
        {
            return Tools.Dates.ParseDate_YYYY_MM_DD(s);
        }
        public static String FormatHMS(int seconds)
        {
            return Tools.Dates.FormatHMS(seconds);
        }
        public static String FormatHMS(Double seconds)
        {
            return Tools.Dates.FormatHMS(seconds);
        }
        public static String FormatHMS(long seconds)
        {
            return Tools.Dates.FormatHMS(seconds);
        }
        public static String FormatHM(long seconds)
        {
            return Tools.Dates.FormatHM(seconds);
        }
        public static String FormatDHMS(long seconds)
        {
            return Tools.Dates.FormatDHMS(seconds);
        }
        public static String FormatDHMS(Double seconds)
        {
            return Tools.Dates.FormatDHMS(seconds);
        }
        public static DateTime GetRandomDate()
        {
            return Tools.Dates.GetRandomDate();
        }
        public static DateTime GetDate_ThisMonthStart()
        {
            return Tools.Dates.GetDate_ThisMonthStart();
        }
        public static String GetDateTimeString()
        {
            return Tools.Dates.GetDateTimeString();
        }
        public static bool IsDate(String s)
        {
            return Tools.Dates.IsDate(s);
        }
        public static DateTime ConcatDateTime(DateTime d, String strTime)
        {
            return Tools.Dates.ConcatDateTime(d, strTime);
        }
        public static String DateFormatWithTime(DateTime d)
        {
            return Tools.Dates.DateFormatWithTime(d);
        }
        public static String GetDateCaption(DateTime d)
        {
            return Tools.Dates.GetDateCaption(d);
        }
        public static DateTime GetWeekStart(DateTime d)
        {
            return Tools.Dates.GetWeekStart(d);
        }
        public static DateTime GetWeekStart(int year, int month, int week)
        {
            return Tools.Dates.GetWeekStart(year, month, week);
        }
        public static DateTime GetQuarterStart(DateTime d)
        {
            return Tools.Dates.GetQuarterStart(d);
        }
        public static DateTime GetQuarterStart(int year, int quarter)
        {
            return Tools.Dates.GetQuarterStart(year, quarter);
        }
        public static DateTime GetQuarterEnd(int year, int quarter)
        {
            return Tools.Dates.GetQuarterEnd(year, quarter);
        }
        public static DateTime GetQuarterEnd(DateTime d)
        {
            return Tools.Dates.GetQuarterEnd(d);
        }
        public static DateTime GetDateByWeek(int year, int week)
        {
            return Tools.Dates.GetDateByWeek(year, week);
        }
        public static DateTime GetDateByQuarter(int year, int quarter)
        {
            return Tools.Dates.GetDateByQuarter(year, quarter);
        }
        public static DateTime GetWeekEnd(DateTime d)
        {
            return Tools.Dates.GetWeekEnd(d);
        }
        public static DateTime GetWeekEnd(int year, int month, int week)
        {
            return Tools.Dates.GetWeekEnd(year, month, week);
        }
        public static DateTime GetDayStart(DateTime d)
        {
            return Tools.Dates.GetDayStart(d);
        }
        public static DateTime GetDayEnd(DateTime d)
        {
            return Tools.Dates.GetDayEnd(d);
        }
        public static DateTime GetDayStart(int year, int month, int day)
        {
            return Tools.Dates.GetDayStart(year, month, day);
        }
        public static String GetMonthName(int month)
        {
            return Tools.Dates.GetMonthName(month);
        }
        public static DateTime GetStartDate(DateTime d, Tools.CubeInterval interval)
        {
            return Tools.Dates.GetStartDate(d, interval);
        }
        public static DateTime GetMonthStart(DateTime d)
        {
            return Tools.Dates.GetMonthStart(d);
        }
        public static DateTime GetMonthStart(int year, int month)
        {
            return Tools.Dates.GetMonthStart(year, month);
        }
        public static DateTime GetMonthEnd(DateTime d)
        {
            return Tools.Dates.GetMonthEnd(d);
        }
        public static DateTime GetMonthEnd(int year, int month)
        {
            return Tools.Dates.GetMonthEnd(year, month);
        }
        public static DateTime GetPreviousMonthStart(DateTime d)
        {
            return Tools.Dates.GetPreviousMonthStart(d);
        }
        public static DateTime GetPreviousMonthEnd(DateTime d)
        {
            return Tools.Dates.GetPreviousMonthEnd(d);
        }
        public static DateTime GetYearStart(DateTime d)
        {
            return Tools.Dates.GetYearStart(d);
        }
        public static DateTime GetYearStart(int year)
        {
            return Tools.Dates.GetYearStart(year);
        }
        public static DateTime GetYearEnd(int year)
        {
            return Tools.Dates.GetYearEnd(year);
        }
        public static DateTime GetYearEnd(DateTime d)
        {
            return Tools.Dates.GetYearEnd(d);
        }
        public static String GetDay_2Digit(DateTime d)
        {
            return Tools.Dates.GetDay_2Digit(d);
        }
        public static String GetMonth_2Digit(DateTime d)
        {
            return Tools.Dates.GetMonth_2Digit(d);
        }
        public static DateTime AddOneMonth(DateTime d)
        {
            return Tools.Dates.AddOneMonth(d);
        }
        public static DateTime SubtractOneMonth(DateTime d)
        {
            return Tools.Dates.SubtractOneMonth(d);
        }
        public static int GetQuarter(DateTime d)
        {
            return Tools.Dates.GetQuarter(d);
        }
        public static int GetWeek(DateTime d)
        {
            return Tools.Dates.GetWeek(d);
        }
        //Tools.Peripheral
        //public static void SetOnMouse(System.Windows.Forms.Form xForm)
        //{
        //    ToolsWin.Screens.SetOnMouse(xForm);
        //}
        //public static ScreenQuadrant GetMouseQuadrant()
        //{
        //    return ToolsWin.Screens.GetMouseQuadrant();
        //}
        //public static String[] GetTrashKeys_OnlySymbols()
        //{
        //    return Tools.Peripheral.GetTrashKeys_OnlySymbols();
        //}
        //public static String[] GetTrashKeys_FileName()
        //{
        //    return Tools.Peripheral.GetTrashKeys_FileName();
        //}
        public static String[] GetTrashKeys_Numbers()
        {
            return Tools.Strings.GetTrashKeys_Numbers();
        }
        public static String[] GetTrashKeys()
        {
            return Tools.Strings.GetTrashKeys();
        }
        //public static bool GetControlKey()
        //{
        //    return ToolsWin.Keyboard.GetControlKey();
        //}
        //public static bool GetShiftKey()
        //{
        //    return ToolsWin.Keyboard.GetShiftKey();
        //}
        //public static bool GetControlAndShiftKeys()
        //{
        //    return ToolsWin.Keyboard.GetControlAndShiftKeys();
        //}
        //public static String GetClipText()
        //{
        //    return ToolsWin.Clipboard.GetClipText();
        //}
        //Tools.Encryption
        public static byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
        {
            return Tools.Encryption.Encrypt(clearData, Key, IV);
        }
        public static string Encrypt(string clearText, string Password)
        {
            return Tools.Encryption.Encrypt(clearText, Password);
        }
        public static byte[] Encrypt(byte[] clearData, string Password)
        {
            return Tools.Encryption.Encrypt(clearData, Password);
        }
        public static void Encrypt(string fileIn, string fileOut, string Password)
        {
            Tools.Encryption.Encrypt(fileIn, fileOut, Password);
        }
        public static byte[] Decrypt(byte[] cipherData, byte[] Key, byte[] IV)
        {
            return Tools.Encryption.Decrypt(cipherData, Key, IV);
        }
        public static string Decrypt(string cipherText, string Password)
        {
            return Tools.Encryption.Decrypt(cipherText, Password);
        }
        public static byte[] Decrypt(byte[] cipherData, string Password)
        {
            return Tools.Encryption.Decrypt(cipherData, Password);
        }
        public static void Decrypt(string fileIn, string fileOut, string Password)
        {
            Tools.Encryption.Decrypt(fileIn, fileOut, Password);
        }

        //Tools.Zebra
        public static bool PrintZebraLabel(ContextNM context, String strLabel, nObject x)
        {
            return Tools.Zebra.PrintZebraLabel(context, strLabel, x, null, false);
        }
        public static bool PrintZebraLabel(ContextNM context, String strLabel, nObject x, ArrayList extra, bool uppercase)
        {
            return Tools.Zebra.PrintZebraLabel(context, strLabel, x, extra, uppercase);
        }
        public static bool PrintZebraLabel(ContextNM context, String strLabel, ArrayList objects, bool uppercase)
        {
            return Tools.Zebra.PrintZebraLabel(context, strLabel, objects, null, uppercase);
        }
        public static bool PrintZebraLabel(ContextNM context, String strLabel, ArrayList objects, ArrayList extra, bool uppercase)
        {
            return Tools.Zebra.PrintZebraLabel(context, strLabel, objects, extra, uppercase);
        }

        ////Tools.Win32API
        //public static IntPtr GetDC_Win32(IntPtr ptr)
        //{
        //    return Win32API.GetDC(ptr);
        //}
        //public static IntPtr GetDesktopWindow()
        //{
        //    return Win32API.GetDesktopWindow();
        //}
        //public static IntPtr ReleaseDC_Win32(IntPtr hWnd, IntPtr hDc)
        //{
        //    return Win32API.ReleaseDC(hWnd, hDc);
        //}
        //public static int GetSystemMetrics_Win32(int abc)
        //{
        //    return Win32API.GetSystemMetrics(abc);
        //}
        //public static Image GetScreenShot()
        //{
        //    return Win32API.GetScreenShot();
        //}
        //public static Image GetRectangleShot(Point start, Point end)
        //{
        //    return Win32API.GetRectangleShot(start, end);
        //}
        //public static IntPtr CreateCompatibleDC_Win32(IntPtr hDC)
        //{
        //    return Win32API.CreateCompatibleDC(hDC);
        //}
        //public static IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth, int nHeight)
        //{
        //    return Win32API.CreateCompatibleBitmap(hDC, nWidth, nHeight);
        //}
        //public static IntPtr SelectObject_Win32(IntPtr hDC, IntPtr hObject)
        //{
        //    return Win32API.SelectObject(hDC, hObject);
        //}
        //public static bool BitBlt(IntPtr hDestDC, int X, int Y, int nWidth, int nHeight, IntPtr hSrcDC, int SrcX, int SrcY, int Rop)
        //{
        //    return Win32API.BitBlt(hDestDC, X, Y, nWidth, nHeight, hSrcDC, SrcX, SrcY, Rop);
        //}
        //public static IntPtr DeleteDC_Win32(IntPtr hDC)
        //{
        //    return Win32API.DeleteDC(hDC);
        //}
    }
    public delegate void NothingDelegate();
}