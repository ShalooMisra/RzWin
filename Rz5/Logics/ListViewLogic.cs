//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Core;
//using NewMethod;

//namespace Rz4
//{
//    public class ListViewLogic : NewMethod.ListViewLogic 
//    {
//        public override ActArgs GetRunActionKeyActArgs(ContextNM x, string key, ListArgs listArgs)
//        {
//            nList l = (nList)lv;
//            if (l.TheArgs == null)
//                return base.GetRunActionKeyActArgs(x, key, lv);

//            if (Tools.Strings.StrCmp(listArgs.TheClass, "orddet_line"))
//            {
//                OrddetLineArgs args = new OrddetLineArgs();
//                args.TheContext = x;    //temporary
//                args.Name = key;
//                switch (l.zz_OrderLineType)
//                {
//                    case "invoice":
//                        args.TheType = Enums.OrderType.Invoice;
//                        break;
//                    case "purchase":
//                        args.TheType = Enums.OrderType.Purchase;
//                        break;
//                    case "rma":
//                        args.TheType = Enums.OrderType.RMA;
//                        break;
//                    case "sales":
//                        args.TheType = Enums.OrderType.Sales;
//                        break;
//                    case "service":
//                        args.TheType = Enums.OrderType.Service;
//                        break;
//                    case "vendrma":
//                        args.TheType = Enums.OrderType.VendRMA;
//                        break;
//                    default:
//                        args.TheType = Enums.OrderType.Any;
//                        break;
//                }
//                return args;
//            }
//            else
//                return base.GetRunActionKeyActArgs(x, key, lv);
//        }
//    }
//}
