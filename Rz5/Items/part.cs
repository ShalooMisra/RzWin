using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using NewMethod;

namespace Rz5
{
    public partial class part : part_auto
    {
        public override void Updating(Core.Context x)
        {
            manufacturer_stripped = Tools.Strings.FilterTrash(manufacturer);
            description_stripped = Tools.Strings.FilterTrash(description);
            category_stripped = Tools.Strings.FilterTrash(category);
            alternatepartstripped = Tools.Strings.FilterTrash(alternatepart);

            base.Updating(x);
        }
    }
}
