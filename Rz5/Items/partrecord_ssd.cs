using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Core;
using NewMethod;
using Tools.Database;

namespace Rz5
{
    public partial class partrecord_ssd : partrecord_ssd_auto
    {
        [CoreVarRefSingle("Partrecord", "Rz5.partrecord_ssd", "Rz5.partrecord", "partrecord_ssd", "unique_id")]
        VarRefSingle<partrecord_ssd, partrecord> PartrecordVar;
    

    //Constructor
        public partrecord_ssd()
        {
            PartrecordVar = new VarRefSingle<partrecord_ssd, partrecord>(this, new CoreVarRefSingleAttribute("Partrecord", "Rz5.partrecord_ssd", "Rz5.partrecord_ssd", "partrecord_ssd", "unique_id"));
        }

        public override Var VarGetByName(string name)
        {
            switch (name)
            {
                case "Partrecord":
                    return PartrecordVar;
                default:
                    return base.VarGetByName(name);
            }
        }
    }
}
