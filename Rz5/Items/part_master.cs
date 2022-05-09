using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using NewMethod;
using Core;

namespace Rz5
{
    public partial class part_master : part_master_auto
    {
        public override void Updating(Core.Context x)
        {
            part_number_stripped = Tools.Strings.FilterTrash(part_number);
            base.Updating(x);
        }

        public static part_master Find(ContextRz x, String partNumber)
        {
            String strippedPart = Tools.Strings.FilterTrash(partNumber);

            if(!Tools.Strings.StrExt(strippedPart))
                return null;

            return part_master.QtO(x, "select * from part_master where part_number_stripped = '" + x.Data.Connection.SyntaxFilter(strippedPart) + "'");
        }

        public static void CheckEverything(ContextRz x, Item i)
        {
            String part = (String)i.ValGet("fullpartnumber");
            String stripped = Tools.Strings.FilterTrash(part);

            if (!Tools.Strings.StrExt(stripped))
                return;

            part_master m = part_master.Find(x, part);
            if (m == null)
            {
                m = part_master.New(x);
                m.part_number = part;
                m.part_number_stripped = stripped;
                m.Insert(x);
            }

            bool changed = false;
            if (Tools.Strings.StrExt(m.manufacturer) && !Tools.Strings.StrExt((String)i.ValGet("manufacturer")))
                i.ValSet("manufacturer", m.manufacturer);
            else if(!Tools.Strings.StrExt(m.manufacturer) && Tools.Strings.StrExt((String)i.ValGet("manufacturer")))
            {
                m.manufacturer = (String)i.ValGet("manufacturer");
                changed = true;
            }

            changed = false;
            if (Tools.Strings.StrExt(m.description) && !Tools.Strings.StrExt((String)i.ValGet("description")))
                i.ValSet("description", m.description);
            else if (!Tools.Strings.StrExt(m.description) && Tools.Strings.StrExt((String)i.ValGet("description")))
            {
                m.description = (String)i.ValGet("description");
                changed = true;
            }

            changed = false;
            if (Tools.Strings.StrExt(m.category) && !Tools.Strings.StrExt((String)i.ValGet("category")))
                i.ValSet("category", m.category);
            else if (!Tools.Strings.StrExt(m.category) && Tools.Strings.StrExt((String)i.ValGet("category")))
            {
                m.category = (String)i.ValGet("category");
                changed = true;
            }

            changed = false;
            if (Tools.Strings.StrExt(m.alternatepart) && !Tools.Strings.StrExt((String)i.ValGet("alternatepart")))
                i.ValSet("alternatepart", m.alternatepart);
            else if (!Tools.Strings.StrExt(m.alternatepart) && Tools.Strings.StrExt((String)i.ValGet("alternatepart")))
            {
                m.alternatepart = (String)i.ValGet("alternatepart");
                changed = true;
            }

            if(changed)
                m.Update(x);
        }
    }
}
