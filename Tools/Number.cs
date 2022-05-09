using System;
using System.Collections.Generic;
using System.Text;

namespace Tools
{
    public static partial class Number
    {
        //Public Static Functions
        public static String MoneyFormat_2_6(Double d)
        {
            return String.Format("{0:###,###,##0.00####}", d);
        }
        public static long DivideWithFractions(long lng1, long lng2)
        {
            return Convert.ToInt64(Convert.ToDouble(lng1) / Convert.ToDouble(lng2));
        }
        public static String LongFormat(Double d)
        {
            return String.Format("{0:###,###,###,##0}", Convert.ToInt64(d));
        }

        public static String LongFormatBlank(Double d)
        {
            if (d == 0)
                return "";
            else
                return LongFormat(d);
        }

        public static String PercentFormatBlank(int pct)
        {
            if (pct == 0)
                return "";
            else
                return pct.ToString() + "%";
        }

        public static String LongFormat(long l)
        {
            return String.Format("{0:###,###,###,##0}", l);
        }
        public static String LongFormat(int i)
        {
            return String.Format("{0:###,###,###,##0}", i);
        }
        public static String LongFormatBlank(int i)
        {
            if (i == 0)
                return "";

            return String.Format("{0:###,###,###,##0}", i);
        }
        public static String MoneyFilter(String s)
        {
            s = s.ToUpper();
            s = s.Replace("EACH", "").Trim();
            s = s.Replace("EA", "").Trim();
            return s.Replace("$", "");//.Replace(",", "").Trim()
        }
        public static Double MoneyFilterAsDouble(String s)
        {
            try
            {
                s = MoneyFilter(s);
                if (IsNumeric(s))
                    return Convert.ToDouble(s);
                else
                    return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static String LongFilter(String s)
        {
            s = s.ToUpper();
            s = Tools.Strings.Replace(s.Replace(",", "").Trim(), "K", "000");

            if (s.StartsWith("."))
                s = Tools.Strings.Mid(s, 2);
            s = Tools.Strings.ParseDelimit(s, ".", 1);
            return s;
        }

        public static long LongFilterAsLong(String s)
        {
            try
            {
                s = LongFilter(s);
                if (IsNumeric(s))
                    return Convert.ToInt64(s);
                else
                    return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static String QuantityFilter(String s)
        {
            s = LongFilter(s);
            s = s.Replace("EACH", "").Trim();
            s = s.Replace("EA", "").Trim();
            s = s.Replace("PIECES", "").Trim();
            s = s.Replace("PCS", "").Trim();
            s = s.Replace("FEET", "").Trim();
            s = s.Replace("FT", "").Trim();
            s = s.Replace("SF", "").Trim();
            s = s.Replace("SL", "").Trim();

            if (Tools.Strings.HasString(s, "TO"))
                s = Tools.Strings.ParseDelimit(s, "TO", 2).Trim();

            if (Tools.Strings.HasString(s, "-"))
                s = Tools.Strings.ParseDelimit(s, "-", 2).Trim();

            return s;
        }
        public static long QuantityFilterAsLong(String s)
        {
            try
            {
                s = QuantityFilter(s);
                if (IsNumeric(s))
                    return Convert.ToInt64(s);
                else
                    return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static int ToInt(String s)
        {
            return Convert.ToInt32(Convert.ToDouble(s));  //to remove decimals in the string
        }

        public static String MoneyFormat(Double d)
        {
            return String.Format("{0:###,###,###,##0.00}", d);
        }
        public static Int32 GetRandomInteger()
        {
            return RandomProvider.Next((int)-100, (int)250000);
        }
        public static Int32 GetRandomInteger(int min, int max)
        {
            return RandomProvider.Next(min, max);
        }
        public static Int64 GetRandomLong()
        {
            return RandomProvider.Next((long)-100, (long)500000);
        }
        public static Int64 GetRandomLong(Int64 low, Int64 high)
        {
            return RandomProvider.Next(low, high);
        }

        public static double CommonSensibleRounding(double d)
        {
            return Math.Round(d, 2, MidpointRounding.AwayFromZero);
        }

        public static Double GetRandomFloat()
        {
            return Convert.ToDouble(Math.Round(RandomProvider.Next(Convert.ToDouble(-10000), Convert.ToDouble(10000)), 6));
        }

        public static bool GetRandomBoolean()
        {
            return RandomProvider.NextBoolean();
        }

        public static String PadTwoDigits(String s)
        {
            return Tools.Strings.Right("00" + s, 2);
        }
        public static bool IsNumeric(String s)
        {
            if (s == null)
                return false;
            if (!Tools.Strings.StrExt(s))
                return false;
            try
            {
                Double d = Double.Parse(s);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static long CalcPercent(long large, long small)
        {
            return Convert.ToInt64(CalcPercent(Convert.ToDouble(large), Convert.ToDouble(small)));
        }
        public static int CalcPercent(int large, int small)
        {
            return Convert.ToInt32(CalcPercent(Convert.ToDouble(large), Convert.ToDouble(small)));
        }
        public static double CalcPercent(Double large, Double small)
        {
            if (large == 0)
                return 0;
            try
            {
                Double d = small / large;
                return d * 100.0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static int CalcAverage(int total, int divide)
        {
            if (divide == 0)
                return 0;

            return total / divide;
        }

        public static String FormatLocalCurrency(Double val, String local)
        {
            String strVal = String.Format("{0:c}", val);
            if (local != "$")
                strVal = strVal.Replace("$", local);
            return strVal;
        }

        public static int DecimalPlacesGetAtLeast2(Double d)
        {
            String dec = Tools.Strings.ParseDelimit(d.ToString(), ".", 2);
            if (dec.Length <= 2)
                return 2;
            if (dec.Length > 6)
                return 6;
            return dec.Length;
        }
    }

    public class NumberedFile
    {
        public String FileBase = "";
        public String FilePath = "";
        public Int64 HighestNumber = -1;
    }

    public class RandomProvider
    {
        private static Random m_RNG1;
        private static double m_StoredUniformDeviate;
        private static bool m_StoredUniformDeviateIsGood = false;

        #region -- Construction/Initialization --

        static RandomProvider()
        {
            Reset();
        }
        public static void Reset()
        {
            m_RNG1 = new Random(Environment.TickCount);
        }

        #endregion

        #region -- Uniform Deviates --

        /// <summary>
        /// Returns double in the range [0, 1)
        /// </summary>
        public static double Next()
        {
            return m_RNG1.NextDouble();
        }

        /// <summary>
        /// Returns true or false randomly.
        /// </summary>
        public static bool NextBoolean()
        {
            if (m_RNG1.Next(0, 2) == 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Returns double in the range [0, 1)
        /// </summary>
        public static double NextDouble()
        {
            double rn = m_RNG1.NextDouble();
            return rn;
        }

        /// <summary>
        /// Returns Int16 in the range [min, max)
        /// </summary>
        public static Int16 Next(Int16 min, Int16 max)
        {
            if (max <= min)
            {
                string message = "Max must be greater than min.";
                throw new ArgumentException(message);
            }
            double rn = (max * 1.0 - min * 1.0) * m_RNG1.NextDouble() + min * 1.0;
            return Convert.ToInt16(rn);
        }

        /// <summary>
        /// Returns Int32 in the range [min, max)
        /// </summary>
        public static int Next(int min, int max)
        {
            return m_RNG1.Next(min, max);
        }

        /// <summary>
        /// Returns Int64 in the range [min, max)
        /// </summary>
        public static Int64 Next(Int64 min, Int64 max)
        {
            if (max <= min)
            {
                string message = "Max must be greater than min.";
                throw new ArgumentException(message);
            }

            double rn = (max * 1.0 - min * 1.0) * m_RNG1.NextDouble() + min * 1.0;
            return Convert.ToInt64(rn);
        }

        /// <summary>
        /// Returns float (Single) in the range [min, max)
        /// </summary>
        public static Single Next(Single min, Single max)
        {
            if (max <= min)
            {
                string message = "Max must be greater than min.";
                throw new ArgumentException(message);
            }

            double rn = (max * 1.0 - min * 1.0) * m_RNG1.NextDouble() + min * 1.0;
            return Convert.ToSingle(rn);
        }

        /// <summary>
        /// Returns double in the range [min, max)
        /// </summary>
        public static double Next(double min, double max)
        {
            if (max <= min)
            {
                string message = "Max must be greater than min.";
                throw new ArgumentException(message);
            }

            double rn = (max - min) * m_RNG1.NextDouble() + min;
            return rn;
        }

        /// <summary>
        /// Returns DateTime in the range [min, max)
        /// </summary>
        public static DateTime Next(DateTime min, DateTime max)
        {
            if (max <= min)
            {
                string message = "Max must be greater than min.";
                throw new ArgumentException(message);
            }
            long minTicks = min.Ticks;
            long maxTicks = max.Ticks;
            double rn = (Convert.ToDouble(maxTicks)
               - Convert.ToDouble(minTicks)) * m_RNG1.NextDouble()
               + Convert.ToDouble(minTicks);
            return new DateTime(Convert.ToInt64(rn));
        }

        /// <summary>
        /// Returns TimeSpan in the range [min, max)
        /// </summary>
        public static TimeSpan Next(TimeSpan min, TimeSpan max)
        {
            if (max <= min)
            {
                string message = "Max must be greater than min.";
                throw new ArgumentException(message);
            }

            long minTicks = min.Ticks;
            long maxTicks = max.Ticks;
            double rn = (Convert.ToDouble(maxTicks)
               - Convert.ToDouble(minTicks)) * m_RNG1.NextDouble()
               + Convert.ToDouble(minTicks);
            return new TimeSpan(Convert.ToInt64(rn));
        }

        /// <summary>
        /// Returns double in the range [min, max)
        /// </summary>
        public static double NextUniform()
        {
            return Next();
        }

        /// <summary>
        /// Returns a uniformly random integer representing one of the values 
        /// in the enum.
        /// </summary>
        public static int NextEnum(Type enumType)
        {
            int[] values = (int[])Enum.GetValues(enumType);
            int randomIndex = Next(0, values.Length);
            return values[randomIndex];
        }

        #endregion

        #region -- Exponential Deviates --

        /// <summary>
        /// Returns an exponentially distributed, positive, random deviate 
        /// of unit mean.
        /// </summary>
        public static double NextExponential()
        {
            double dum = 0.0;
            while (dum == 0.0)
                dum = NextUniform();
            return -1.0 * System.Math.Log(dum, System.Math.E);
        }

        #endregion

        #region -- Normal Deviates --

        /// <summary>
        /// Returns a normally distributed deviate with zero mean and unit 
        /// variance.
        /// </summary>
        public static double NextNormal()
        {
            // based on algorithm from Numerical Recipes
            if (m_StoredUniformDeviateIsGood)
            {
                m_StoredUniformDeviateIsGood = false;
                return m_StoredUniformDeviate;
            }
            else
            {
                double rsq = 0.0;
                double v1 = 0.0, v2 = 0.0, fac = 0.0;
                while (rsq >= 1.0 || rsq == 0.0)
                {
                    v1 = 2.0 * Next() - 1.0;
                    v2 = 2.0 * Next() - 1.0;
                    rsq = v1 * v1 + v2 * v2;
                }
                fac = System.Math.Sqrt(-2.0
                   * System.Math.Log(rsq, System.Math.E) / rsq);
                m_StoredUniformDeviate = v1 * fac;
                m_StoredUniformDeviateIsGood = true;
                return v2 * fac;
            }
        }

        #endregion

    }
}
