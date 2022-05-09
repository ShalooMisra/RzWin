//using System;
//using System.Collections.Generic;
//using System.Collections;
//using System.Text;
//using System.Data;
//using System.Windows.Forms;

//using Core;
//using NewMethod.Enums;

//namespace NewMethod
//{
//    public partial class n_prop  // : n_prop_auto  //, IFrameworkClass 
//    {
//        //public nRefresh xRefresh = new nRefresh();

//        // the line /////////--------------------------------------------------------------------------

//        public n_class xClass;
//        public n_choices xChoices;

       
//        //Public Functions
//        //public void LoadNode(TreeNode xNode)
//        //{
//        //    if (xNode == null)
//        //        return;

//        //    MyNode = xNode.Nodes.Add(this.name);
//        //    MyNode.Tag = this;
//        //    MyNode.ImageIndex = nTools.GetIconIndex(IconType.GuidedProperty);
//        //    MyNode.SelectedImageIndex = MyNode.ImageIndex;

//        //    UpdateMyNode();
//        //}
//        //public bool IsUniqueID
//        //{
//        //    get
//        //    {
//        //        return (property_order == 0);
//        //    }
//        //}
//        public FieldType PropertyType
//        {
//            get
//            {
//                return nData.ConvertDataTypeToEnum(property_type);
//            }
//        }

//        public Enums.DataUse PropertyUse
//        {
//            get
//            {
//                return nData.ConvertUseType(property_use);
//            }
//        }

//        public void MakeFieldExist(nData d, n_class c)
//        {
//            if( !this.name.ToLower().StartsWith("hold_temp_") )
//            {
//                d.MakeFieldExist(c.class_name, this.name, this.property_type, this.property_length);
//            }
//        }
//        //public void SetSoft()
//        //{
//        //    xClass.SetSoft();
//        //    this.is_soft = true;
//        //    this.IUpdate();
//        //    xRefresh.Refresh();
//        //}
//        //public void SetHard()
//        //{
//        //    this.is_soft = false;
//        //    this.IUpdate();
//        //    xRefresh.Refresh();
//        //}
//        //public void CompleteDelete()
//        //{
//        //    IDelete();
//        //}
//        //public string GetOrderedID()
//        //{
//        //    String n = "000000000" + this.property_order.ToString();
//        //    n = n.Substring(n.Length - 8);
//        //    return this.xClass.unique_id + n + this.unique_id; 
//        //}
//        public void AbsorbChoicesObject(n_choices c)
//        {
//            xChoices = c;
//            this.the_n_choices_uid = c.unique_id;
//            ISave();
//        }
//        //public bool IsFramework
//        //{
//        //    get
//        //    {
//        //        switch (name.ToLower())
//        //        {
//        //            case "unique_id":
//        //            case "grid_color":
//        //            case "icon_index":
//        //            case "date_created":
//        //            case "date_modified":
//        //                return true;
//        //            default:
//        //                return false;
//        //        }
//        //    }
//        //}

//        public String GetFriendlyName()
//        {
//            if (Tools.Strings.StrExt(property_tag))
//                return property_tag;
//            return name;
//        }
//    }
//}
