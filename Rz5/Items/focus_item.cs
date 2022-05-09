using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Windows.Forms;


using Tools;
//using ToolsWin;
using NewMethod;

namespace Rz5
{
    public partial class focus_item : focus_item_auto
    {
        public Object CurrentHandle = null;

        public FocusItemType ItemType
        {
            get
            {
                try
                {
                    return (FocusItemType)Enum.Parse(Type.GetType(SysRz5.RzNamespace + ".FocusItemType"), item_type);
                }
                catch
                {
                    return FocusItemType.Unknown;
                }
            }

            set
            {
                item_type = value.ToString();
            }
        }
    }

    public enum FocusItemType
    {
        Unknown = 0,
        UserNote = 1,
        HitRapid = 2,
        ContactConsolidation = 3,
        QuoteFollowUp = 4,
        AdvanceShipmentNotification = 5,
        ShipmentConfirmation = 6,
    }

    public interface IFocusControl
    {
        void LimitControls();
        void CompleteSave();
    }
}
