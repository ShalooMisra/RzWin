using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Reflection;
using System.Diagnostics;
//using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;
using System.Drawing;
using System.Xml;
using ICSharpCode.SharpZipLib.Zip;
using System.Globalization;

namespace Tools
{
    public partial class People
    {
        //Public Static Variables
        public static String[] ContactPrefixes = new String[] { "mr", "ms", "mrs", "miss", "dr", "sfc", "chief", "commander", "sgt", "ssgt", "smsgt", "sargeant", "sqn", "ltc", "cdr", "col", "cpl", "maj", "cw5", "cw2", "lcdr", "cwo4", "sgm", "jr", "pvt", "capt", "lt", "spc", "lt commander", "sfc", "cw3", "cw4", "major", "ssg", "sr", "csm", "msgt", "captain", "skc", "cpt", "1lt", "tsgt", "sk2", "sk1", "et1", "et2", "ssg", "ak1", "ak2", "ret", "ls1", "msg" };
        public static String[] ContactRemoveAfter = new String[] { ",", "-" };

        //Public Static Functions
        public static String ContactNameClean(String val)
        {
            String original = val;

            while (val.Contains("( "))
            {
                val = val.Replace("( ", "(");
            }

            while (val.Contains(") "))
            {
                val = val.Replace(") ", ")");
            }

            val = TrimFull(val.ToLower()).Replace("(r)", "");

            //get rid of prefixes
            String[] pieces = Tools.Strings.Split(val, " ");
            val = "";
            for (int i = 0; i < pieces.Length; i++)
            {
                String p = pieces[i];
                foreach (String x in ContactPrefixes)
                {
                    if (p == x || p == x + ".")
                    {
                        p = "";
                        break;
                        //changed = true;
                    }
                }

                if (p.StartsWith("(") && p.EndsWith(")"))
                {
                    p = "";
                    //changed = true;
                }

                if (p.StartsWith("'") && p.EndsWith("'"))
                {
                    p = "";
                    //changed = true;
                }

                val += " " + p;
            }

            val = TrimFull(val);

            foreach (String r in ContactRemoveAfter)
            {
                val = TrimFull(Tools.Strings.ParseDelimit(val, r, 1));
            }

            //middles

            pieces = Tools.Strings.Split(val, " ");
            if (pieces.Length == 3)
            {
                if (pieces[1].Length == 1 || (pieces[1].Length == 2 && pieces[1].EndsWith(".")))
                    val = pieces[0] + " " + pieces[2];
                else if ((pieces[0].Length == 1 || (pieces[0].Length == 2 && pieces[0].EndsWith("."))) && pieces[1].Length > 3 && pieces[2].Length > 3)
                    val = pieces[1] + " " + pieces[2];
            }

            return val;
        }

        public static String FirstNameParse(String fullName)
        {
            String cleanName = ContactNameClean(fullName);
            return Tools.Strings.ParseDelimit(cleanName, " ", 1);
        }

        public static String TrimFull(String val)
        {
            val = val.Trim();
            while (Tools.Strings.HasString(val, "  "))
            {
                val = val.Replace("  ", " ");
            }
            return val;
        }
        public static string ToProperCase(string original)
        {
            if (String.IsNullOrEmpty(original))
                return original;

            string result = _properNameRx.Replace(original.ToLower(CultureInfo.CurrentCulture), HandleWord);
            return result;
        }
        public static string WordToProperCase(string word)
        {
            if (String.IsNullOrEmpty(word))
                return word;

            if (word.Length > 1)
                return Char.ToUpper(word[0], CultureInfo.CurrentCulture) + word.Substring(1);

            return word.ToUpper(CultureInfo.CurrentCulture);
        }

        public static CompanyCountry GetCompanyCountryEnum(string country, string email, string phone)
        {
            try
            {
                if (Strings.StrExt(country))
                {
                    switch (country.ToLower())
                    {
                        case "china":
                            return CompanyCountry.China;
                        case "albania":
                        case "andorra":
                        case "austria":
                        case "belarus":
                        case "belgium":
                        case "bosnia and herzegovina":
                        case "bosnia":
                        case "herzegovina":
                        case "bulgaria":
                        case "croatia":
                        case "cyprus":
                        case "czech republic":
                        case "denmark":
                        case "estonia":
                        case "finland":
                        case "france":
                        case "germany":
                        case "greece":
                        case "hungary":
                        case "iceland":
                        case "ireland":
                        case "italy":
                        case "latvia":
                        case "liechtenstein":
                        case "lithuania":
                        case "luxembourg":
                        case "macedonia":
                        case "malta":
                        case "moldova":
                        case "monaco":
                        case "netherlands":
                        case "norway":
                        case "poland":
                        case "portugal":
                        case "romania":
                        case "russia":
                        case "san marino":
                        case "serbia and montenegro":
                        case "serbia":
                        case "montenegro":
                        case "slovakia":
                        case "slovak republic":
                        case "slovenia":
                        case "spain":
                        case "sweden":
                        case "switzerland":
                        case "turkey":
                        case "ukraine":
                        case "united kingdom":
                        case "uk":
                        case "vatican city":
                            return CompanyCountry.Europe;
                        default:
                            return CompanyCountry.UnitedStates;
                    }
                }
                if (Strings.StrExt(email))
                {
                    string domain = Email.ParseEmailDomain(email);
                    if (!Strings.StrExt(domain))
                        return CompanyCountry.UnitedStates;
                    switch (domain.ToLower())
                    {
                        case "cn":
                            return CompanyCountry.China;
                        case "eu":
                            return CompanyCountry.Europe;
                        default:
                            return CompanyCountry.UnitedStates;
                    }
                }
                if (Strings.StrExt(phone))
                {
                    if (!phone.Contains("+"))
                        return CompanyCountry.UnitedStates;
                    phone = phone.Replace("+", "");
                    string three = phone.Substring(0, 3);
                    switch (three)
                    {
                        case "420":
                        case "372":
                        case "358":
                        case "353":
                        case "371":
                        case "370":
                        case "352":
                        case "356":
                        case "357":
                        case "351":
                        case "421":
                        case "386":
                            return CompanyCountry.Europe;
                    }
                    string two = phone.Substring(0, 2);
                    switch (two)
                    {
                        case "43":
                        case "32":
                        case "45":
                        case "33":
                        case "49":
                        case "30":
                        case "36":
                        case "39":
                        case "31":
                        case "48":
                        case "34":
                        case "46":
                        case "44":
                            return CompanyCountry.Europe;
                    }
                    return CompanyCountry.China;
                }
            }
            catch { }
            return CompanyCountry.UnitedStates;
        }
        //Private Static Functions
        private static readonly Regex _properNameRx = new Regex(@"\b(\w+)\b");
        private static readonly string[] _prefixes = { "mc", "o'" };
        private static string HandleWord(Match m)
        {
            string word = m.Groups[1].Value;

            foreach (string prefix in _prefixes)
            {
                if (word.StartsWith(prefix, StringComparison.CurrentCultureIgnoreCase))
                    return WordToProperCase(prefix) + WordToProperCase(word.Substring(prefix.Length));
            }

            return WordToProperCase(word);
        }
    }
    public enum CompanyCountry
    {
        UnitedStates = 0,
        Europe = 1,
        China = 3,
    }
}
