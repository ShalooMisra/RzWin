using System;
using System.Collections.Generic;
using System.Text;

using Core;
using Tools.Database;

namespace NewMethod
{
    namespace Enums
    {

        public enum EmailClient
        {
            Outlook,
            Gmail,
            MicrosoftMail,
            Thunderbird,
            Generic,
            Other,
        }

        public enum IconType
        {
            Unknown = -1,
            Any = 0,
            Class = 1,
            Property = 2,
            Method = 3,
            GuidedClass = 4,
            GuidedProperty = 5,
            GuidedMethod = 6,
        }

        public enum ClipType
        {
            Unknown = 0,
            Folder = 1,
            Instance = 2,
        }
        public enum SoftControlType
        {
            Unknown = 0,
            TextBox = 1,
            TextLabel = 2,
            TextBoxWithLabel = 3,
            Actions = 4,

        }
        public enum RelationshipType
        {
            ParentChild = 0,
            Inherit = 1,
            Self = 2,
            Subscribe = 3,
        }
        public enum MenuType
        {
            Unknown = 0,
            Screen = 1,
            ContextMenu = 2
        }
        public enum PermitMode
        {
            Normal = 0,
            AskIfMissing = 1,
            AskIfMissingOrBlocked = 2,
            AskAlways = 3,
        }
        public enum CountContext
        {
            Single = 0,
            Multiple = 1,
        }
        public enum RecallType
        {
            None = 0,
            Insert = 1,
            Update = 2,
            Delete = 3,
        }
        //Public Classes
        public partial class ConvertEnum
        {
            //Main Translation
            public static String TranslateEnumTypeToString(Int32 val, String enum_type)
            {
                String t = val.ToString();
                switch (enum_type.ToLower())
                {
                    case "accessspecifier":
                        t = ConvertAccessSpecifier(val);
                        break;
                    //case "activitytype":
                    //    t = ConvertActivityType(val); 
                    //    break;
                    case "choicetype":
                        t = ConvertChoiceType(val);
                        break;
                    case "cliptype":
                        t = ConvertClipType(val);
                        break;
                    case "comparetype":
                        t = ConvertCompareType(val);
                        break;
                    case "controltype":
                        t = ConvertControlType(val);
                        break;
                    //case "cubetype":
                    //    t = ConvertCubeType(val);
                    //    break;
                    case "dataconversiontype":
                        t = ConvertDataConversionType(val);
                        break;
                    //case "fieldtype":
                    //    t = ConvertDataType(val);
                    //    break;
                    //case "datause":
                    //    t = ConvertUseType(val);
                    //    break;
                    case "edgetype":
                        t = ConvertEdgeType(val);
                        break;
                    case "icontype":
                        t = ConvertIconType(val);
                        break;
                    case "language":
                        t = ConvertLanguage(val);
                        break;
                    case "permitmode":
                        t = ConvertPermitMode(val);
                        break;
                    case "recalltype":
                        t = ConvertRecallType(val);
                        break;
                    case "relatetype":
                        t = ConvertRelateType(val);
                        break;
                    //case "screenquadrant":
                    //    t = ConvertScreenQuadrant(val);
                    //    break;
                    case "servertypes":
                        t = ConvertServerTypes(val);
                        break;
                    //case "statusmode":
                    //    t = ConvertStatusMode(val);
                    //    break;
                }
                return t;
            }
            //Sub Translators
            public static String ConvertChoiceType(Int32 d)
            {
                switch (d)
                {
                    case (Int32)ChoiceType.None:
                        return "None";
                    case (Int32)ChoiceType.FreeType:
                        return "FreeType";
                    case (Int32)ChoiceType.SelectOnly:
                        return "SelectOnly";
                    case (Int32)ChoiceType.MustSelect:
                        return "MustSelect";
                    default:
                        return "(Unknown)";
                }
            }
            public static Int32 ConvertChoiceType(String str)
            {
                if (Tools.Strings.StrCmp(str, "None"))
                    return (Int32)ChoiceType.None;
                if (Tools.Strings.StrCmp(str, "FreeType"))
                    return (Int32)ChoiceType.FreeType;
                if (Tools.Strings.StrCmp(str, "SelectOnly"))
                    return (Int32)ChoiceType.SelectOnly;
                if (Tools.Strings.StrCmp(str, "MustSelect"))
                    return (Int32)ChoiceType.MustSelect;

                return (Int32)0;
            }
            public static String ConvertAccessSpecifier(Int32 d)
            {
                //switch (d)
                //{
                //    case (Int32)AccessSpecifier.Public:
                //        return "Public";
                //    case (Int32)AccessSpecifier.Protected:
                //        return "Protected";
                //    case (Int32)AccessSpecifier.Private:
                //        return "Private";
                //    default:
                        return "(Unknown)";
                //}
            }
            public static Int32 ConvertAccessSpecifier(String str)
            {
                //if (Tools.Strings.StrCmp(str, "Public"))
                //    return (Int32)AccessSpecifier.Public;
                //if (Tools.Strings.StrCmp(str, "Protected"))
                //    return (Int32)AccessSpecifier.Protected;
                //if (Tools.Strings.StrCmp(str, "Private"))
                //    return (Int32)AccessSpecifier.Private;
                return (Int32)0;
            }
            //public static String ConvertDataType(Int32 d)
            //{
            //    return nData.ConvertDataType(d);
            //}
            //public static Int32 ConvertDataType(String str)
            //{
            //    return nData.ConvertDataType(str);
            //}
            public static ValueUse ConvertUseType(Int32 d)
            {
                return nData.ConvertUseType(d);
            }
            public static Int32 ConvertUseType(String str)
            {
                return nData.ConvertUseType(str);
            }
            //public static String ConvertActivityType(Int32 d)
            //{
            //    switch (d)
            //    {
            //        case (Int32)ActivityType.None:
            //            return "None";
            //        case (Int32)ActivityType.Deleting:
            //            return "Deleting";
            //        case (Int32)ActivityType.Saving:
            //            return "Saving";
            //        case (Int32)ActivityType.Searching:
            //            return "Searching";
            //        case (Int32)ActivityType.Updating:
            //            return "Updating";
            //        default:
            //            return "(Unknown)";
            //    }
            //}
            //public static Int32 ConvertActivityType(String str)
            //{
            //    if (Tools.Strings.StrCmp(str, "None"))
            //        return (Int32)ActivityType.None;
            //    if (Tools.Strings.StrCmp(str, "Deleting"))
            //        return (Int32)ActivityType.Deleting;
            //    if (Tools.Strings.StrCmp(str, "Saving"))
            //        return (Int32)ActivityType.Saving;
            //    if (Tools.Strings.StrCmp(str, "Searching"))
            //        return (Int32)ActivityType.Searching;
            //    if (Tools.Strings.StrCmp(str, "Updating"))
            //        return (Int32)ActivityType.Updating;
            //    return (Int32)0;
            //}
            public static String ConvertClipType(Int32 d)
            {
                switch (d)
                {
                    case (Int32)ClipType.Folder:
                        return "Folder";
                    case (Int32)ClipType.Instance:
                        return "Instance";
                    case (Int32)ClipType.Unknown:
                        return "Unknown";
                    default:
                        return "(Unknown)";
                }
            }
            public static Int32 ConvertClipType(String str)
            {
                if (Tools.Strings.StrCmp(str, "Folder"))
                    return (Int32)ClipType.Folder;
                if (Tools.Strings.StrCmp(str, "Instance"))
                    return (Int32)ClipType.Instance;
                if (Tools.Strings.StrCmp(str, "Unknown"))
                    return (Int32)ClipType.Unknown;
                return (Int32)0;
            }
            public static String ConvertCompareType(Int32 d)
            {
                switch (d)
                {
                    case (Int32)CompareType.Equal:
                        return "Equal";
                    case (Int32)CompareType.GreaterThan:
                        return "GreaterThan";
                    case (Int32)CompareType.In:
                        return "In";
                    case (Int32)CompareType.LessThan:
                        return "LessThan";
                    case (Int32)CompareType.LikeFuzzy:
                        return "LikeFuzzy";
                    case (Int32)CompareType.LikeLeading:
                        return "LikeLeading";
                    case (Int32)CompareType.LikeTrailing:
                        return "LikeTrailing";
                    case (Int32)CompareType.LikeVeryFuzzy:
                        return "LikeVeryFuzzy";
                    case (Int32)CompareType.NotEqual:
                        return "NotEqual";
                    case (Int32)CompareType.NotIn:
                        return "NotIn";
                    case (Int32)CompareType.NotLikeTrailing:
                        return "NotLikeTrailing";
                    default:
                        return "(Unknown)";
                }
            }
            public static Int32 ConvertCompareType(String str)
            {
                if (Tools.Strings.StrCmp(str, "Equal"))
                    return (Int32)CompareType.Equal;
                if (Tools.Strings.StrCmp(str, "GreaterThan"))
                    return (Int32)CompareType.GreaterThan;
                if (Tools.Strings.StrCmp(str, "In"))
                    return (Int32)CompareType.In;
                if (Tools.Strings.StrCmp(str, "LessThan"))
                    return (Int32)CompareType.LessThan;
                if (Tools.Strings.StrCmp(str, "LikeFuzzy"))
                    return (Int32)CompareType.LikeFuzzy;
                if (Tools.Strings.StrCmp(str, "LikeLeading"))
                    return (Int32)CompareType.LikeLeading;
                if (Tools.Strings.StrCmp(str, "LikeTrailing"))
                    return (Int32)CompareType.LikeTrailing;
                if (Tools.Strings.StrCmp(str, "LikeVeryFuzzy"))
                    return (Int32)CompareType.LikeVeryFuzzy;
                if (Tools.Strings.StrCmp(str, "NotEqual"))
                    return (Int32)CompareType.NotEqual;
                if (Tools.Strings.StrCmp(str, "NotIn"))
                    return (Int32)CompareType.NotIn;
                if (Tools.Strings.StrCmp(str, "NotLikeTrailing"))
                    return (Int32)CompareType.NotLikeTrailing;
                return (Int32)0;
            }
            public static String ConvertControlType(Int32 d)
            {
                try
                {
                    SoftControlType t = (SoftControlType)d;
                    return t.ToString();
                }
                catch
                {
                    return "Unknown";
                }
            }
            public static Int32 ConvertControlType(String str)
            {
                try
                {
                    SoftControlType t = (SoftControlType)Enum.Parse(Type.GetType("NewMethod.Enums.SoftControlType"), str);
                    return (Int32)t;
                }
                catch
                {
                    return 0;
                }
            }
            //public static String ConvertCubeType(Int32 d)
            //{
            //    switch (d)
            //    {
            //        case (Int32)CubeType.Any:
            //            return "Any";
            //        case (Int32)CubeType.Team:
            //            return "Team";
            //        case (Int32)CubeType.User:
            //            return "User";
            //        default:
            //            return "(Unknown)";
            //    }
            //}
            //public static Int32 ConvertCubeType(String str)
            //{
            //    if (Tools.Strings.StrCmp(str, "Any"))
            //        return (Int32)CubeType.Any;
            //    if (Tools.Strings.StrCmp(str, "Team"))
            //        return (Int32)CubeType.Team;
            //    if (Tools.Strings.StrCmp(str, "User"))
            //        return (Int32)CubeType.User;
            //    return (Int32)0;
            //}
            public static String ConvertDataConversionType(Int32 d)
            {
                switch (d)
                {
                    case (Int32)DataConversionType.Cancel:
                        return "Cancel";
                    case (Int32)DataConversionType.DeleteRow:
                        return "DeleteRow";
                    case (Int32)DataConversionType.SetDefault:
                        return "SetDefault";
                    default:
                        return "(Unknown)";
                }
            }
            public static Int32 ConvertDataConversionType(String str)
            {
                if (Tools.Strings.StrCmp(str, "Cancel"))
                    return (Int32)DataConversionType.Cancel;
                if (Tools.Strings.StrCmp(str, "DeleteRow"))
                    return (Int32)DataConversionType.DeleteRow;
                if (Tools.Strings.StrCmp(str, "SetDefault"))
                    return (Int32)DataConversionType.SetDefault;
                return (Int32)0;
            }
            public static String ConvertEdgeType(Int32 d)
            {
                switch (d)
                {
                    case (Int32)EdgeType.Bottom:
                        return "Bottom";
                    case (Int32)EdgeType.BottomLeft:
                        return "BottomLeft";
                    case (Int32)EdgeType.BottomRight:
                        return "BottomRight";
                    case (Int32)EdgeType.Left:
                        return "Left";
                    case (Int32)EdgeType.Right:
                        return "Right";
                    case (Int32)EdgeType.Top:
                        return "Top";
                    case (Int32)EdgeType.TopLeft:
                        return "TopLeft";
                    case (Int32)EdgeType.TopRight:
                        return "TopRight";
                    case (Int32)EdgeType.Unknown:
                        return "Unknown";
                    default:
                        return "(Unknown)";
                }
            }
            public static Int32 ConvertEdgeType(String str)
            {
                if (Tools.Strings.StrCmp(str, "Bottom"))
                    return (Int32)EdgeType.Bottom;
                if (Tools.Strings.StrCmp(str, "BottomLeft"))
                    return (Int32)EdgeType.BottomLeft;
                if (Tools.Strings.StrCmp(str, "BottomRight"))
                    return (Int32)EdgeType.BottomRight;
                if (Tools.Strings.StrCmp(str, "Left"))
                    return (Int32)EdgeType.Left;
                if (Tools.Strings.StrCmp(str, "Right"))
                    return (Int32)EdgeType.Right;
                if (Tools.Strings.StrCmp(str, "Top"))
                    return (Int32)EdgeType.Top;
                if (Tools.Strings.StrCmp(str, "TopLeft"))
                    return (Int32)EdgeType.TopLeft;
                if (Tools.Strings.StrCmp(str, "TopRight"))
                    return (Int32)EdgeType.TopRight;
                if (Tools.Strings.StrCmp(str, "Unknown"))
                    return (Int32)EdgeType.Unknown;
                return (Int32)0;
            }
            public static String ConvertIconType(Int32 d)
            {
                switch (d)
                {
                    case (Int32)IconType.Any:
                        return "Any";
                    case (Int32)IconType.Class:
                        return "Class";
                    case (Int32)IconType.GuidedClass:
                        return "GuidedClass";
                    case (Int32)IconType.GuidedMethod:
                        return "GuidedMethod";
                    case (Int32)IconType.GuidedProperty:
                        return "GuidedProperty";
                    case (Int32)IconType.Method:
                        return "Method";
                    case (Int32)IconType.Property:
                        return "Property";
                    case (Int32)IconType.Unknown:
                        return "Unknown";
                    default:
                        return "(Unknown)";
                }
            }
            public static Int32 ConvertIconType(String str)
            {
                if (Tools.Strings.StrCmp(str, "Any"))
                    return (Int32)IconType.Any;
                if (Tools.Strings.StrCmp(str, "Class"))
                    return (Int32)IconType.Class;
                if (Tools.Strings.StrCmp(str, "GuidedClass"))
                    return (Int32)IconType.GuidedClass;
                if (Tools.Strings.StrCmp(str, "GuidedMethod"))
                    return (Int32)IconType.GuidedMethod;
                if (Tools.Strings.StrCmp(str, "GuidedProperty"))
                    return (Int32)IconType.GuidedProperty;
                if (Tools.Strings.StrCmp(str, "Method"))
                    return (Int32)IconType.Method;
                if (Tools.Strings.StrCmp(str, "Property"))
                    return (Int32)IconType.Property;
                if (Tools.Strings.StrCmp(str, "Unknown"))
                    return (Int32)IconType.Unknown;
                return (Int32)0;
            }
            public static String ConvertLanguage(Int32 d)
            {
                //switch (d)
                //{
                //    case (Int32)Language.CSharp:
                //        return "CSharp";
                //    default:
                        return "(Unknown)";
                //}
            }
            public static Int32 ConvertLanguage(String str)
            {
                //if (Tools.Strings.StrCmp(str, "CSharp"))
                //    return (Int32)Language.CSharp;
                return (Int32)0;
            }
            public static String ConvertPermitMode(Int32 d)
            {
                switch (d)
                {
                    case (Int32)PermitMode.AskAlways:
                        return "AskAlways";
                    case (Int32)PermitMode.AskIfMissing:
                        return "AskIfMissing";
                    case (Int32)PermitMode.AskIfMissingOrBlocked:
                        return "AskIfMissingOrBlocked";
                    case (Int32)PermitMode.Normal:
                        return "Normal";
                    default:
                        return "(Unknown)";
                }
            }
            public static Int32 ConvertPermitMode(String str)
            {
                if (Tools.Strings.StrCmp(str, "AskAlways"))
                    return (Int32)PermitMode.AskAlways;
                if (Tools.Strings.StrCmp(str, "AskIfMissing"))
                    return (Int32)PermitMode.AskIfMissing;
                if (Tools.Strings.StrCmp(str, "AskIfMissingOrBlocked"))
                    return (Int32)PermitMode.AskIfMissingOrBlocked;
                if (Tools.Strings.StrCmp(str, "Normal"))
                    return (Int32)PermitMode.Normal;
                return (Int32)0;
            }
            public static String ConvertRecallType(Int32 d)
            {
                switch (d)
                {
                    case (Int32)RecallType.Delete:
                        return "Delete";
                    case (Int32)RecallType.Insert:
                        return "Insert";
                    case (Int32)RecallType.None:
                        return "None";
                    case (Int32)RecallType.Update:
                        return "Update";
                    default:
                        return "(Unknown)";
                }
            }
            public static Int32 ConvertRecallType(String str)
            {
                if (Tools.Strings.StrCmp(str, "Delete"))
                    return (Int32)RecallType.Delete;
                if (Tools.Strings.StrCmp(str, "Insert"))
                    return (Int32)RecallType.Insert;
                if (Tools.Strings.StrCmp(str, "None"))
                    return (Int32)RecallType.None;
                if (Tools.Strings.StrCmp(str, "Update"))
                    return (Int32)RecallType.Update;
                return (Int32)0;
            }
            public static String ConvertRelateType(Int32 d)
            {
                switch (d)
                {
                    case (Int32)RelationshipType.Inherit:
                        return "Inherit";
                    case (Int32)RelationshipType.ParentChild:
                        return "ParentChild";
                    case (Int32)RelationshipType.Self:
                        return "Self";
                    case (Int32)RelationshipType.Subscribe:
                        return "Subscribe";
                    default:
                        return "(Unknown)";
                }
            }
            public static Int32 ConvertRelateType(String str)
            {
                if (Tools.Strings.StrCmp(str, "Inherit"))
                    return (Int32)RelationshipType.Inherit;
                if (Tools.Strings.StrCmp(str, "ParentChild"))
                    return (Int32)RelationshipType.ParentChild;
                if (Tools.Strings.StrCmp(str, "Self"))
                    return (Int32)RelationshipType.Self;
                if (Tools.Strings.StrCmp(str, "Subscribe"))
                    return (Int32)RelationshipType.Subscribe;
                return (Int32)0;
            }
            //public static String ConvertScreenQuadrant(Int32 d)
            //{
            //    switch (d)
            //    {
            //        case (Int32)ScreenQuadrant.BottomCenter:
            //            return "BottomCenter";
            //        case (Int32)ScreenQuadrant.BottomLeft:
            //            return "BottomLeft";
            //        case (Int32)ScreenQuadrant.BottomRight:
            //            return "BottomRight";
            //        case (Int32)ScreenQuadrant.MidCenter:
            //            return "MidCenter";
            //        case (Int32)ScreenQuadrant.MidLeft:
            //            return "MidLeft";
            //        case (Int32)ScreenQuadrant.MidRight:
            //            return "MidRight";
            //        case (Int32)ScreenQuadrant.TopCenter:
            //            return "TopCenter";
            //        case (Int32)ScreenQuadrant.TopLeft:
            //            return "TopLeft";
            //        case (Int32)ScreenQuadrant.TopRight:
            //            return "TopRight";
            //        default:
            //            return "(Unknown)";
            //    }
            //}
            //public static Int32 ConvertScreenQuadrant(String str)
            //{
            //    if (Tools.Strings.StrCmp(str, "BottomCenter"))
            //        return (Int32)ScreenQuadrant.BottomCenter;
            //    if (Tools.Strings.StrCmp(str, "BottomLeft"))
            //        return (Int32)ScreenQuadrant.BottomLeft;
            //    if (Tools.Strings.StrCmp(str, "BottomRight"))
            //        return (Int32)ScreenQuadrant.BottomRight;
            //    if (Tools.Strings.StrCmp(str, "MidCenter"))
            //        return (Int32)ScreenQuadrant.MidCenter;
            //    if (Tools.Strings.StrCmp(str, "MidLeft"))
            //        return (Int32)ScreenQuadrant.MidLeft;
            //    if (Tools.Strings.StrCmp(str, "MidRight"))
            //        return (Int32)ScreenQuadrant.MidRight;
            //    if (Tools.Strings.StrCmp(str, "TopCenter"))
            //        return (Int32)ScreenQuadrant.TopCenter;
            //    if (Tools.Strings.StrCmp(str, "TopLeft"))
            //        return (Int32)ScreenQuadrant.TopLeft;
            //    if (Tools.Strings.StrCmp(str, "TopRight"))
            //        return (Int32)ScreenQuadrant.TopRight;
            //    return (Int32)0;
            //}
            public static String ConvertServerTypes(Int32 d)
            {
                switch (d)
                {
                    case (Int32)ServerTypes.Any:
                        return "Any";
                    case (Int32)ServerTypes.MySQL:
                        return "MySQL";
                    case (Int32)ServerTypes.SQLServer:
                        return "SQLServer";
                    case (Int32)ServerTypes.Unknown:
                        return "Unknown";
                    default:
                        return "(Unknown)";
                }
            }
            public static Int32 ConvertServerTypes(String str)
            {
                if (Tools.Strings.StrCmp(str, "Any"))
                    return (Int32)ServerTypes.Any;
                if (Tools.Strings.StrCmp(str, "MySQL"))
                    return (Int32)ServerTypes.MySQL;
                if (Tools.Strings.StrCmp(str, "SQLServer"))
                    return (Int32)ServerTypes.SQLServer;
                if (Tools.Strings.StrCmp(str, "Unknown"))
                    return (Int32)ServerTypes.Unknown;
                return (Int32)0;
            }
            //public static String ConvertStatusMode(Int32 d)
            //{
            //    switch (d)
            //    {
            //        case (Int32)StatusMode.NoModal:
            //            return "NoModal";
            //        case (Int32)StatusMode.Normal:
            //            return "Normal";
            //        default:
            //            return "(Unknown)";
            //    }
            //}
            //public static Int32 ConvertStatusMode(String str)
            //{
            //    if (Tools.Strings.StrCmp(str, "NoModal"))
            //        return (Int32)StatusMode.NoModal;
            //    if (Tools.Strings.StrCmp(str, "Normal"))
            //        return (Int32)StatusMode.Normal;
            //    return (Int32)0;
            //}
        }
    }

    namespace Enums
    {
        public enum EdgeType
        {
            Unknown = 0,
            Top = 12,
            Left = 10,
            Bottom = 15,
            Right = 11,

            TopLeft = 13,
            TopRight = 14,
            BottomLeft = 16,
            BottomRight = 17,
        }
    }
}
