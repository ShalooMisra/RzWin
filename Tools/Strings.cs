using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Web;
using System.Text.RegularExpressions;
using System.Linq;

namespace Tools
{
    public partial class Strings
    {


        //Public Static Functions

        public static String GetNewID()
        {
            System.Guid x = System.Guid.NewGuid();
            return x.ToString().Replace("-", "");
        }

        public static string SanitizeInput(string input)
        {
            if (string.IsNullOrEmpty(input))
                return null;
            if (!IsIllegalUserInput(input))
                return input;
            return null;
        }

        public static Boolean StrExt(String s)
        {
            if (s == null)
                return false;
            if (s.Trim().Length <= 0)
                return false;
            return true;
        }

        public static bool HasString(string str, string f)
        {
            if (str == null)
                return false;
            if (f == null)
                return false;
            long l = str.ToLower().IndexOf(f.ToLower());
            return l >= 0;
        }

        public static String Right(String strIn, int len)
        {
            try
            {
                if (strIn.Length <= len)
                    return strIn;

                return strIn.Substring(strIn.Length - len, len);
            }
            catch
            {
                return "";
            }
        }

        public static String[] Split(String strIn, String strSplit)
        {
            return strIn.Split(new String[] { strSplit }, StringSplitOptions.None);
        }

        public static List<String> SplitList(String strIn, String strSplit)
        {
            return new List<String>(Split(strIn, strSplit));
        }

        public static List<String> SplitListBlanksSpacesIgnore(String strIn, String strSplit)
        {
            String[] ary = Split(strIn, strSplit);
            List<String> ret = new List<string>();
            foreach (String s in ary)
            {
                if (Tools.Strings.StrExt(s))
                {
                    ret.Add(s.Trim());
                }
            }
            return ret;
        }
        public static String[] BulkReplace(String[] s, String[] r)
        {
            String[] v = new String[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                v[i] = BulkReplace(s[i], r);
            }
            return v;
        }
        public static String BulkReplace(String s, String[] r)
        {
            String v = s;
            foreach (String x in r)
            {
                v = v.Replace(x, "");
            }
            return v;
        }
        public static bool IsIn(String strStart, String strLook)
        {
            String[] a = strLook.Split(new String[] { "|" }, StringSplitOptions.None);
            foreach (String s in a)
            {
                if (Strings.StrCmp(s, strStart))
                    return true;
            }
            return false;
        }
        public static String GetNextLine(ref String strIn)
        {
            if (!Strings.StrExt(strIn))
                return "";
            Int64 lngMark = strIn.IndexOf("\n", 1);
            if (lngMark == 0)
            {
                if (strIn.Trim().Length <= 0)
                    return "%%EOF%%";
                else
                    return strIn;
            }
            String r = strIn.Substring((Int32)lngMark - 1);
            strIn = strIn.Substring((Int32)lngMark + 2);
            return r;
        }

        public static string GetStringBetweenTwoStrings(string wholeString, string startString, int firstPartSize = 12)
        {
            // wholeString = "soapbox.wistia.com/videos/IGKRnVOpGC farts and pooopos and \"stuff\"";
            // startString = "soapbox.wistia.com/videos/";
            // endString = " ";

            int posA = wholeString.LastIndexOf(startString);
            if (posA == -1)
            {
                //return ("string not found");
                return null;
            }

            int adjustedPosA = posA + startString.Length;
            if (adjustedPosA >= wholeString.Length)
            {
                //("string not found").Dump();
                return null;
            }

            //This should have the first n characters after the startString
            string firstPart = wholeString.Substring(adjustedPosA, firstPartSize);

            //Regex to strim all non-alphanumeric, what's left will be our Video ID
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            string result = rgx.Replace(firstPart, "");
            return result;
        }
        //public static Boolean StrExt(String s)
        //{
        //    return Tools.Strings.StrExt(s);
        //}
        public static Boolean StrCmp(String s1, String s2)
        {
            if (s1 == null)
                return false;
            if (s2 == null)
                return false;
            return (s1.ToLower().Trim() == s2.ToLower().Trim());
        }
        public static String CStr(Object i)
        {
            if (i == null)
                return "";
            return i.ToString();
        }
        public static String Format(String strFormat, Object o)
        {
            try
            {
                switch (strFormat.ToLower())
                {
                    case "yn":
                        if (Convert.ToBoolean(o))
                        {
                            return "Y";
                        }
                        else
                        {
                            return "N";
                        }
                        
                    case "hms":
                        return Dates.FormatHMS(Convert.ToInt64(o));
                    default:
                        return String.Format(strFormat, o);
                        
                }
            }
            catch (Exception e)
            {
                return Convert.ToString(o);
            }
        }
        public static String YesBlankFilter(bool b)
        {
            if (b)
                return "Y";
            else
                return "";
        }
        public static String YesNoFilter(bool b)
        {
            if (b)
                return "Y";
            else
                return "N";
        }

        public static String YesNoFilterActual(bool b)
        {
            if (b)
                return "Yes";
            else
                return "No";
        }

        public static String NiceFormat(String s)
        {
            s = s.Replace(" ", "_");
            s = s.Replace("__", "_");
            String[] a = s.Split("_".ToCharArray());
            String c = "";
            foreach (String b in a)
            {
                if (Strings.StrExt(c))
                    c += " ";
                if (b.Length > 0)
                {
                    c += b.Substring(0, 1).ToUpper();
                    if (b.Length > 1)
                        c += b.Substring(1).ToLower();
                }
            }
            return c;
        }

      

        public static String DownloadInternetString(String strURL)
        {
            try
            {
                WebClient xClient = new WebClient();
                Byte[] b = xClient.DownloadData(strURL);
                return Encoding.ASCII.GetString(b);
            }
            catch (Exception e)
            {
                return "";
            }
        }

        public static String Left(String strIn, int len)
        {
            try
            {
                if (len >= strIn.Length)
                    return strIn;
                else if (!StrExt(strIn))
                    return "";
                else
                    return strIn.Substring(0, len);
            }
            catch (Exception e)
            {
                return "";
            }
        }

        public static string ExtractDigits(string s)
        {
            string ret = Regex.Replace(s, @"[^\d]", "");
            return ret;
        }

        //public static bool HasString(string str, string f)
        //{
        //    return Tools.Strings.HasString(str, f);
        //}
        public static bool HasString(string str, string[] f)
        {
            foreach (String s in f)
            {
                if (HasString(str, s))
                    return true;
            }
            return false;
        }
        public static String Space(int l)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                sb.Append(" ");
            }
            return sb.ToString();
        }
        public static string StripNonAlphaNumeric(String stringToStrip, bool AllowUnderscores)
        {
            String c;
            String r = "";
            
            for (int i = 0; i < stringToStrip.Length; i++)
            {
                c = stringToStrip.Substring(i, 1);
                if ((c.ToLower().CompareTo("a") >= 0 && c.ToLower().CompareTo("z") <= 0) || (c.ToLower().CompareTo("0") >= 0 && c.ToLower().CompareTo("9") <= 0))
                {
                    r += c;
                }
                else
                {
                    if (c == "_" && AllowUnderscores)
                    {
                        r += c;
                    }
                }
            }
            return r;
        }
        public static string StripNonNumeric(String s)
        {
            return StripNonNumeric(s, false);
        }
        public static string StripNonNumeric(String s, bool AllowPeriods)
        {
            String c;
            String r = "";
            for (int i = 0; i < s.Length; i++)
            {
                c = s.Substring(i, 1);
                if ((c.ToLower().CompareTo("0") >= 0 && c.ToLower().CompareTo("9") <= 0))
                {
                    r += c;
                }
                else
                {
                    if (c == "." && AllowPeriods)
                    {
                        r += c;
                    }
                }
            }
            return r;
        }
        public static String GetFirstLine(String s)
        {
            try
            {
                String[] ary = Strings.Split(s, "\r\n");
                return ary[0];
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static String ParseDelimit(String strIn, String s, int p)
        {
            try
            {
                if (!Strings.StrExt(strIn))
                    return "";
                String[] a = strIn.Split(new String[] { s }, StringSplitOptions.None);
                if (a.Length == 0)
                    return "";
                if (a.Length < (p - 1))
                    return "";
                if (a.Length == 1)
                {
                    if (p == 1)
                        return a[0];
                    else
                        return "";
                }
                return a[p - 1];
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static String ParseDelimitBase0(String strIn, String s, int baseZeroPosition)
        {
            try
            {
                if (!Strings.StrExt(strIn))
                    return "";
                String[] a = strIn.Split(new String[] { s }, StringSplitOptions.None);
                if (a.Length == 0)
                    return "";
                if (a.Length <= baseZeroPosition)
                    return "";
                return a[baseZeroPosition];
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static String ParseDelimitLast(String strIn, String s)
        {
            String[] split = Split(strIn, s);
            if (split.Length == 0)
                return "";
            else
                return split[split.Length - 1];
        }

        public static ArrayList GetUniqueStrings(ArrayList a, ArrayList b)
        {
            ArrayList c = new ArrayList();
            foreach (String s in a)
            {
                if (!IsInArray(s, c))
                    c.Add(s);
            }
            foreach (String s in b)
            {
                if (!IsInArray(s, c))
                    c.Add(s);
            }
            return c;
        }
        public static String BlockString(String s, int b)
        {
            StringBuilder ret = new StringBuilder();
            int blocks = s.Length / b;
            int rem = s.Length % b;
            int i = 0;
            for (i = 0; i < blocks; i++)
            {
                ret.AppendLine(s.Substring(i * b, b));
            }
            if (rem > 0)
                ret.Append(s.Substring(i * b));
            return ret.ToString();
        }

        public static String FilterEverythingButNumbers(String strIn)
        {
            String r = "";
            for (int i = 0; i < strIn.Length; i++)
            {
                String c = Mid(strIn, i + 1, 1);
                switch (c)
                {
                    case "0":
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                        r += c;
                        break;
                }
            }
            return r;
        }

        //public static String FilterEverythingButLettersNumbers(String strIn)
        //{
        //    String r = "";
        //    for (int i = 0; i < strIn.Length; i++)
        //    {
        //        String c = Mid(strIn, i + 1, 1);
        //        switch (c)
        //        {
        //            case "0":
        //            case "1":
        //            case "2":
        //            case "3":
        //            case "4":
        //            case "5":
        //            case "6":
        //            case "7":
        //            case "8":
        //            case "9":
        //                r += c;
        //                break;
        //            default:
        //                if (CharInAlphabet(c))
        //                {
        //                    r += c;
        //                }
        //                break;
        //        }
        //    }
        //    return r;
        //}

        //New Sensible Tools - Kevint
        //public static string RemoveSpecialCharacters(string str)//Strip down to only alphanumeric
        //{
        //    //Any character that is NOT a-z, A-Z, 0-9 nor underscore nor period
        //    //string ret = Regex.Replace(str, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
        //    //Any character that is NOT a-z, A-Z, 0-9 nor underscore
        //    //Ensuring 
        //    string ret = FilterTrash(str);      
        //    return ret;
        //}



        public static string[] FilterTrash(string[] str)
        {
            string[] ret = new string[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                ret[i] = FilterTrash(str[i]);
            }
            return ret;
        }
        public static string[] FilterFileNameTrash(string[] str)
        {
            string[] ret = new string[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                ret[i] = FilterFileNameTrash(str[i]);
            }
            return ret;
        }
        public static String FilterTrash(String strIn)
        {
            return FilterTrash(strIn, false);
        }
        public static String FilterFileNameTrash(String s)
        {
            return Strings.BulkReplace(s, Strings.GetTrashKeys());
        }
        public static String FilterTrash(String strIn, bool RemoveNumbers)
        {
            if (RemoveNumbers)
                return Regex.Replace(strIn, @"[^a-zA-Z]", string.Empty);
            else
                return Regex.Replace(strIn, @"[^0-9a-zA-Z]", string.Empty);
        }

        public static String FilterTrashExceptUnderscore(String term)
        {
            return Regex.Replace(term, @"[^0-9a-zA-Z_]", string.Empty);
        }

        public static String FilterTrashExceptPipe(String term)
        {
            return Regex.Replace(term, @"[^0-9a-zA-Z|]", string.Empty);
        }

        public static string StrReplace(string original, string pattern, string replacement)
        {
            int count, position0, position1;
            count = position0 = position1 = 0;
            string upperString = original.ToUpper();
            string upperPattern = pattern.ToUpper();
            int inc = (original.Length / pattern.Length) * (replacement.Length - pattern.Length);
            char[] chars = new char[original.Length + Math.Max(0, inc)];
            while ((position1 = upperString.IndexOf(upperPattern, position0)) != -1)
            {
                for (int i = position0; i < position1; ++i)
                    chars[count++] = original[i];
                for (int i = 0; i < replacement.Length; ++i)
                    chars[count++] = replacement[i];
                position0 = position1 + pattern.Length;
            }
            if (position0 == 0)
                return original;
            for (int i = position0; i < original.Length; ++i)
                chars[count++] = original[i];
            return new string(chars, 0, count);
        }
        public static String StrReverse(String strIn)
        {
            Array arr = strIn.ToCharArray();
            Array.Reverse(arr);    // reverse the string
            char[] c = (char[])arr;
            return (new string(c));
        }
        public static String Trim(String s)
        {
            return s.Trim();
        }
        //public static String[] Split(String strIn, String strSplit)
        //{
        //    return Tools.Strings.Split(strIn, strSplit);
        //}
        public static void SplitInTwo(String start, ref String str1, ref String str2, String split)
        {
            int i = start.IndexOf(split);
            if (i == -1)
            {
                str1 = start;
                str2 = "";
                return;
            }
            str1 = start.Substring(0, i);
            str2 = start.Substring(i + 1);
        }
        public static ArrayList SplitArray(String strIn, String strSplit)
        {
            if (strIn == "")
                return new ArrayList();

            String[] s = Strings.Split(strIn, strSplit);
            return ToArray(s);
        }
        public static ArrayList ToArray(String[] ary)
        {
            ArrayList a = new ArrayList();
            foreach (String s in ary)
            {
                a.Add(s);
            }
            return a;
        }
        public static String ReplaceVisualAll(String s)
        {
            s = Strings.ReplaceVisual(s, "s", "5", "");
            s = Strings.ReplaceVisual(s, "y", "4", "");
            s = Strings.ReplaceVisual(s, "l", "1", "i");
            s = Strings.ReplaceVisual(s, "o", "0", "");
            s = Strings.ReplaceVisual(s, "z", "2", "");
            return s;
        }
        public static String ReplaceVisual(String strBase, String str1, String str2, String str3)
        {
            String strTemp = strBase;
            strTemp = strBase.Replace(str1, "\t");
            strTemp = strTemp.Replace(str2, "\r");
            if (Strings.StrExt(str3))
            {
                strTemp = strTemp.Replace(str3, "\n");
                strTemp = strTemp.Replace("\t", "[" + str1 + str2 + str3 + "]");
                strTemp = strTemp.Replace("\r", "[" + str1 + str2 + str3 + "]");
                strTemp = strTemp.Replace("\n", "[" + str1 + str2 + str3 + "]");
            }
            else
            {
                strTemp = strTemp.Replace("\t", "[" + str1 + str2 + "]");
                strTemp = strTemp.Replace("\r", "[" + str1 + str2 + "]");
            }
            return strTemp;
        }
        public static String Replace(String strExpression, String strSearch, String strReplace)
        {
            String strReturn;
            int intPosition;
            String strTemp;
            strReturn = "";
            strSearch = strSearch.ToUpper();
            strTemp = strExpression.ToUpper();
            intPosition = strTemp.IndexOf(strSearch);
            while (intPosition >= 0)
            {
                strReturn = strReturn + strExpression.Substring(0, intPosition) + strReplace;
                strExpression = strExpression.Substring(intPosition + strSearch.Length);
                strTemp = strTemp.Substring(intPosition + strSearch.Length);
                intPosition = strTemp.IndexOf(strSearch);
            }
            strReturn = strReturn + strExpression;
            return strReturn;
        }
        public static int CharCount(String s, Char l)
        {
            int r = 0;
            Char[] ary = s.ToCharArray();
            foreach (Char c in ary)
            {
                if (c == l)
                    r++;
            }
            return r;
        }

        public static List<String> SplitLinesList(String s)
        {
            return SplitLinesList(s, noBlanks: false);
        }

        public static String JoinLines(List<String> strings)
        {
            StringBuilder ret = new StringBuilder();

            bool first = true;
            foreach (String s in strings)
            {
                if (!first)
                    ret.Append("\r\n");

                ret.Append(s);

                first = false;
            }

            return ret.ToString();
        }

        public static List<String> SplitLinesList(String s, bool noBlanks = false)
        {
            String[] ary = SplitLines(s);
            List<String> ret = new List<string>();
            foreach (String x in ary)
            {
                if (noBlanks && !Tools.Strings.StrExt(x))
                    continue;

                ret.Add(x);
            }
            return ret;
        }

        public static String[] SplitLines(String s)
        {
            return Split(s.Replace("\r\n", "\n"), "\n");
        }
        public static bool IsInArray(ArrayList a, String s)
        {
            return IsInArray(s, a);
        }
        public static bool IsInArray(String s, ArrayList a)
        {
            foreach (String x in a)
            {
                if (Strings.StrCmp(x, s))
                    return true;
            }
            return false;
        }
        public static String ChopFront(String strIn, String strFront)
        {
            if (Strings.StrCmp(Strings.Left(strIn.Trim(), strFront.Length), strFront))
                return strIn.Trim().Substring(strFront.Length);
            else
                return strIn;
        }
        public static String Mid(String s, int start)
        {
            return Mid(s, start, 0);
        }
        public static String Mid(String s, int start, int length)
        {
            try
            {
                String st = s.Substring(start - 1);
                if (length > 0)
                    return Strings.Left(st, length);
                else
                    return st;
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static int Len(String s)
        {
            return s.Length;
        }
        public static Boolean CharInAlphabet(Char c)
        {
            return CharInAlphabet(c.ToString());
        }
        public static Boolean CharInAlphabet(String c)
        {
            switch (c.Trim().ToLower())
            {
                case "a":
                case "b":
                case "c":
                case "d":
                case "e":
                case "f":
                case "g":
                case "h":
                case "i":
                case "j":
                case "k":
                case "l":
                case "m":
                case "n":
                case "o":
                case "p":
                case "q":
                case "r":
                case "s":
                case "t":
                case "u":
                case "v":
                case "w":
                case "x":
                case "y":
                case "z":
                    return true;
                default:
                    return false;
            }
        }
        public static bool StrCmpExcludingTrash(String str1, String str2)
        {
            return StrCmp(FilterTrash(str1), FilterTrash(str2));
        }
        public static String GetInsert(String strLine, String strStart, String strEnd)
        {
            return GetInsert(strLine, strStart, strEnd, "");
        }
        public static String GetInsert(String strLine, String strStart, String strEnd, String strAlternateEnd)
        {
            int lngMark = strLine.ToLower().IndexOf(strStart.ToLower());
            if (lngMark < 0)
                return "";
            lngMark += strStart.Length + 1;
            if (strEnd.Length == 0)
                return Strings.Mid(strLine, lngMark);
            int lngMark2 = strLine.ToLower().IndexOf(strEnd.ToLower(), lngMark);
            if (lngMark2 <= 0)
            {
                if (strAlternateEnd.Length > 0)
                    lngMark2 = strLine.IndexOf(strAlternateEnd, lngMark);
                else
                    return "";
            }
            return Mid(strLine, lngMark, (lngMark2 - lngMark) + 1).Trim();
        }
        public static bool StartsWith(String strBase, String strStart)
        {
            return strBase.ToLower().StartsWith(strStart.ToLower());
        }
        public static bool IncludesLine(String strText, String s)
        {
            //middle
            if (Strings.HasString(strText, "\r\n" + s + "\r\n"))
                return true;
            //top line
            if (Strings.StrCmp(Strings.Left(strText, s.Length + 2), s + "\r\n"))
                return true;
            //bottom line
            if (Strings.StrCmp(Strings.Right(strText, s.Length + 2), "\r\n" + s))
                return true;
            return false;
        }

        public static String PluralizeName(String name)  //for when you know you have singular and know you need plural  
        {
            if (name.EndsWith("y") && !name.EndsWith("ay"))  //this is a rough hack and an example of why English sucks
                return Tools.Strings.Left(name, name.Length - 1) + "ies";
            else
                return name + "s";
        }

        public static String PluralizeNameOnly(String name, Double num)
        {
            long l = Convert.ToInt64(num);
            if (l > 1 || l == 0)
                return PluralizeName(name);
            else
                return name;
        }

        public static String PluralizePhrase(String name, Double num)
        {
            long l = Convert.ToInt64(num);
            if (l > 1 || l == 0)
                return Number.LongFormat(num) + " " + PluralizeName(name);
            else
                return "1 " + name;
        }

        public static String PluralizeUn(String s)
        {
            //a lot more is needed here
            if (s.ToLower().EndsWith("ses"))
                return s.Substring(0, s.Length - 2);
            if (s.ToLower().EndsWith("s") && !s.ToLower().EndsWith("ss"))
                return s.Substring(0, s.Length - 1);
            else if (s.ToLower().EndsWith("ies"))
                return s.Substring(0, s.Length - 1) + "y";
            else
                return s;
        }

        public static String TrimLeadingChars(String s, String ch)
        {
            while (s.ToLower().StartsWith(ch.ToLower()))
            {
                s = s.Substring(1);
            }
            return s;
        }
        public static ArrayList KillBlankLines(ArrayList a)
        {
            ArrayList b = new ArrayList();
            foreach (String s in a)
            {
                if (Strings.StrExt(s))
                    b.Add(s);
            }
            return b;
        }
        public static String KillBlankLines(String s)
        {
            String[] lines = Strings.SplitLines(s);
            StringBuilder ret = new StringBuilder();
            int count = 0;
            foreach (string line in lines)
            {
                if (Strings.StrExt(line))
                {
                    if (count > 0)
                        ret.AppendLine();

                    ret.Append(line);

                    count++;
                }

            }
            return ret.ToString();
        }

        public static String LeftEllipse(String s, int chop)
        {
            if (s.Length <= (chop + 3))
                return s;

            return Left(s, chop) + "...";
        }

        public static String MakeSingleLine(String s)
        {
            return Replace(s, "\r", "").Replace("\n", " ");
        }

        public static String DownloadInternetFileAsString(String strURL)
        {
            try
            {
                String strLocalFile = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "temp_web_download.txt";
                WebClient xClient = new WebClient();
                xClient.DownloadFile(strURL, strLocalFile);
                return Tools.Files.OpenFileAsString(strLocalFile);
            }
            catch (Exception e)
            {
                return "";
            }
        }

        public static String CommaSeparateBlanksIgnore(String[] vals)
        {
            StringBuilder sb = new StringBuilder();
            bool first = true;
            foreach (String v in vals)
            {
                if (StrExt(v))
                {
                    if (!first)
                        sb.Append(", ");

                    first = false;
                    sb.Append(v);
                }
            }
            return sb.ToString();
        }

        public static String CommaSeparateBlanksIgnore(List<String> vals)
        {
            StringBuilder sb = new StringBuilder();
            bool first = true;
            foreach (String v in vals)
            {
                if (StrExt(v))
                {
                    if (!first)
                        sb.Append(", ");

                    first = false;
                    sb.Append(v);
                }
            }
            return sb.ToString();
        }

        public static String DotSeparateBlanksIgnore(List<String> vals)
        {
            StringBuilder sb = new StringBuilder();
            bool first = true;
            foreach (String v in vals)
            {
                if (StrExt(v))
                {
                    if (!first)
                        sb.Append(".");

                    first = false;
                    sb.Append(v);
                }
            }
            return sb.ToString();
        }

        public static String CsvFilter(String s)
        {
            return s.Replace(",", " ").Replace("\"", "").Replace("'", "").Replace("\r", "").Replace("\n", "").Replace("\t", "").Trim();
        }

        /// <summary>
        /// Generates 32-bit MD5 hash from a random number.  Parameters can be empty strings.
        /// </summary>
        /// <param name="prepend"></param>
        /// <returns></returns>
        public static string GenerateRandomName(string prepend, string append)
        {
            Random randomNum = new Random();
            return prepend + Tools.Encryption.getMd5Hash(randomNum.GetHashCode().ToString()) + append;
        }

        public static String StripBadAsciiTrim(String term)
        {
            if (Regex.IsMatch(term, @"[^\u0020-\u007E]", RegexOptions.None))
            {
                term = Regex.Replace(term, @"[^\u0020-\u007E]", string.Empty);
            }
            return term.Trim();
        }

        public static String JavascriptEscapeSingle(String term)
        {
            return term.Replace("'", @"\'");
        }

        //Private Static Variables
        //switched 'only symbols' to the default of just 'trash keys', since that's how i think we've been using them
        //did you know trashfilter was removing things like '011' and 'x' !?!
        //private static String[] TrashKeys_OnlySymbols;

        //removed this; i don't see a difference between file names and the plain trash keys
        //private static String[] TrashKeys_FileName;

        private static String[] TrashKeys_Numbers;

        //this isn't needed; the method to filter phone numbers has to chop it based on things like 'ext', not just remove those letters
        //private static String[] TrashKeys_Phone;

        private static String[] TrashKeys;

        static String TrashBase = "!|&|+|-|/|)|(| |'|\r|\n|\t|.|,|\\|*|#|:|[|]|%|{|}|`|~|$|_|;|@|^|?|<|>";
        public static String[] GetTrashKeys()
        {
            if (TrashKeys != null)
                return TrashKeys;
            TrashKeys = TrashBase.Split("|".ToCharArray());
            return TrashKeys;
        }

        public static ArrayList TrashReplacements = null;
        public static ArrayList GetTrashReplacements()
        {
            if (TrashReplacements != null)
                return TrashReplacements;

            ArrayList ret = new ArrayList();
            ret.Add(new TrashReplacement('!', "EXCLM"));
            ret.Add(new TrashReplacement('@', "AT"));
            ret.Add(new TrashReplacement('#', "POUND"));
            ret.Add(new TrashReplacement('$', "DOLLAR"));
            ret.Add(new TrashReplacement('%', "PERCENT"));
            ret.Add(new TrashReplacement('^', "CARAT"));
            ret.Add(new TrashReplacement('&', "AMPERSAND"));
            ret.Add(new TrashReplacement('*', "STAR"));
            ret.Add(new TrashReplacement('(', "LAPRAN"));
            ret.Add(new TrashReplacement(')', "RPARAN"));
            ret.Add(new TrashReplacement('-', "MINUS"));
            ret.Add(new TrashReplacement('+', "PLUS"));
            ret.Add(new TrashReplacement('=', "EQUALS"));
            ret.Add(new TrashReplacement(' ', "SPACE"));
            ret.Add(new TrashReplacement(']', "RBRACKET"));
            ret.Add(new TrashReplacement('[', "LBRACKET"));
            ret.Add(new TrashReplacement('{', "LCBRACKET"));
            ret.Add(new TrashReplacement('}', "RCBRACKET"));
            ret.Add(new TrashReplacement('\\', "BSLASH"));
            ret.Add(new TrashReplacement('/', "SLASH"));
            ret.Add(new TrashReplacement('"', "DQUOTE"));
            ret.Add(new TrashReplacement('\'', "SQUOTE"));
            ret.Add(new TrashReplacement(':', "COLON"));
            ret.Add(new TrashReplacement(';', "SCOLON"));
            ret.Add(new TrashReplacement(',', "COMMA"));
            ret.Add(new TrashReplacement('.', "DOT"));
            ret.Add(new TrashReplacement('<', "LTHAN"));
            ret.Add(new TrashReplacement('>', "GTHAN"));
            ret.Add(new TrashReplacement('`', "ACCENT"));
            ret.Add(new TrashReplacement('~', "TILDE"));
            //ret.Add(new TrashReplacement('\r', "CR"));
            //ret.Add(new TrashReplacement('\n', "LF"));
            //ret.Add(new TrashReplacement('\t', "TAB"));
            ret.Add(new TrashReplacement('_', "UNDSC"));

            TrashReplacements = ret;
            return TrashReplacements;
        }

        public static String ReplaceTrash(String strIn)
        {
            foreach (TrashReplacement r in GetTrashReplacements())
            {
                strIn = strIn.Replace(r.ch.ToString(), "xx" + r.name + "yy");
            }
            return Tools.Strings.StripNonAlphaNumeric(strIn, false);
        }

        public static String InsertTrash(String strIn)
        {
            foreach (TrashReplacement r in GetTrashReplacements())
            {
                strIn = strIn.Replace("xx" + r.name + "yy", r.ch.ToString());
            }
            return strIn;
        }

        //public static String[] GetTrashKeys_FileName()
        //{
        //    if (TrashKeys_FileName != null)
        //        return TrashKeys_FileName;
        //    String s = "!|&|+|-|/|)|(| |'|\r|\n|\t|,|\\|*|#|:|[|]|%|{|}|`|~|$|;";
        //    TrashKeys_FileName = s.Split("|".ToCharArray());
        //    return TrashKeys_FileName;
        //}
        public static String[] GetTrashKeys_Numbers()
        {
            if (TrashKeys_Numbers != null)
                return TrashKeys_Numbers;
            String s = TrashBase + "|0|1|2|3|4|5|6|7|8|9";
            TrashKeys_Numbers = s.Split("|".ToCharArray());
            return TrashKeys_Numbers;
        }
        //public static String[] GetTrashKeys()
        //{
        //    if (TrashKeys != null)
        //        return TrashKeys;
        //    String s = "+|011|-|/|)|(| |'|\"|.|,|*|ext|#|x|:|[|]";
        //    TrashKeys = s.Split("|".ToCharArray());
        //    return TrashKeys;
        //}

        //public static String[] GetTrashKeys_Phone()
        //{
        //    if (TrashKeys_Phone != null)
        //        return TrashKeys_Phone;
        //    String s = TrashBase + "|011|ext|x";
        //    TrashKeys_Phone = s.Split("|".ToCharArray());
        //    return TrashKeys_Phone;
        //}

        public static String RemoveSqlStrings(String sql)
        {
            String[] pieces = sql.Replace("''", "").Split("'".ToCharArray());
            bool inString = false;
            StringBuilder ret = new StringBuilder();
            foreach (String p in pieces)
            {
                if (inString)
                {
                    inString = false;
                    continue;
                }

                ret.Append(" " + p);
                inString = !inString;
            }
            return ret.ToString().Trim();
        }

        public static List<String> ParseCsvRow(String row)
        {
            List<String> ret = new List<string>();
            StringBuilder sb = new StringBuilder();
            bool inQuotes = false;
            Char[] chars = row.ToCharArray();
            for (int cx = 0; cx < chars.Length; cx++)
            {
                Char c = chars[cx];
                if (c == ',' && !inQuotes)
                {
                    ret.Add(sb.ToString().Trim());
                    sb = new StringBuilder();
                }
                else if (c == '"')
                {
                    if (inQuotes && (cx + 1 < chars.Length) && (chars[cx + 1] == '"'))
                        sb.Append('"');
                    else
                        inQuotes = !inQuotes;
                }
                else if (c == '\\')
                {
                    if ((cx + 1 < chars.Length) && (chars[cx + 1] == '"'))
                        sb.Append('"');
                }
                else
                    sb.Append(c);
            }

            ret.Add(sb.ToString().Trim());
            return ret;
        }

        public static String NiceEnum(String inVal)
        {
            String ret = "";
            foreach (char c in inVal.ToCharArray())
            {
                int x = (int)c;
                if (x >= 65 && x <= 90 && ret != "")
                    ret += " ";
                ret += c;
            }
            return ret;
        }

        public static String Pad2Digits(String s)
        {
            return Right("00" + s, 2);
        }

        public static string CapitalizeFirstLetter(string s)
        {
            // Check for empty string.  
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.  
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        public static bool IsIllegalUserInput(string userInput, bool sanitizeHTML = true, bool sanitizeSQL = true)
        {
            //Note - we use and encourage ORMs where below sanitization is not needed.  However, due to existing code in Rz, that doesn't parameterize it's input, this is a necessary check.
            if (userInput == null)
                return false;
            bool isIllegal = false;

            List<string> sqlCheckList = new List<string>{ "--",

                                       ";--",

                                       ";",

                                       "/*",

                                       "*/",

                                        "@@",

                                        //"@",

                                        "char",

                                       "nchar",

                                       "varchar",

                                       "nvarchar",

                                       "alter",

                                       "begin",

                                       "cast",

                                       //"create",

                                       "cursor",

                                       "declare",

                                       "delete",

                                       "drop",

                                       "end",

                                       "exec",

                                       "execute",

                                       "fetch",

                                            "insert",

                                          "kill",

                                             "select",

                                           "sys",

                                            "sysobjects",

                                            "syscolumns",

                                           "table",

                                           "update",
                                           "http",
                                           "https",
                                           "UNION",
                                           "CONTAT",
                                           "//"

                                       };

            List<string> httpCheckList = new List<string>() { "http", "jquery", "document.", "$(" };

            //Replacing any apostrophes in input with 2 apostrophes??
            var punctuation = userInput.Where(Char.IsPunctuation).Distinct().ToArray();
            var words = userInput.Split().Select(x => x.Trim(punctuation));
            //string CheckString = userInput.Replace("'", "''");

            foreach (string w in words)
            {
                if (sanitizeSQL)
                {
                    if (sqlCheckList.Contains(w.ToLower()))
                        isIllegal = true;
                }

                if (sanitizeHTML)
                {
                    if (httpCheckList.Contains(w.ToLower()))
                        isIllegal = true;
                }
            }



            return isIllegal;
        }
    }





    public class TrashReplacement
    {
        public Char ch = Char.MinValue;
        public String name = "";

        public TrashReplacement(Char c, String n)
        {
            ch = c;
            name = n;
        }
    }
}
