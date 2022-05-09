using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Tools
{
    public class Style
    {
        static Style m_StyleCurrent = null;
        public static Style StyleCurrent
        {
            get
            {
                if (m_StyleCurrent == null)
                    m_StyleCurrent = new Style(new Font("Times New Roman", 10.0F));
                return m_StyleCurrent;
            }

            set
            {
                m_StyleCurrent = value;
            }
        }

        public Font TheFont;

        public Style(Font f)
        {
            TheFont = f;
        }

        Dictionary<RuneType, Rune> Runes = null;
        public Rune RuneGet(RuneType t)
        {
            if (Runes.ContainsKey(t))
                return Runes[t];
            else
                return RuneUnknown;
        }

        public virtual Rune RuneUnknown
        {
            get
            {
                return new Rune(RuneType.Blank, "");
            }
        }

        Icon m_IconFormDefault = null;
        public Icon IconFormDefault
        {
            get
            {
                return m_IconFormDefault;
            }

            set
            {
                m_IconFormDefault = value;
            }
        }
    }

    public class Rune
    {
        public RuneType TheType;
        public Image TheImage = null;
        public String Caption = "";

        public Rune(RuneType t)
        {
            TheType = t;
        }

        public Rune(RuneType t, String c) : this(t)
        {
            Caption = c;
        }
    }

    public enum RuneType
    {
        NoCancel = 0,
        YesOK = 1,
        Blank = 2,
    }
}
