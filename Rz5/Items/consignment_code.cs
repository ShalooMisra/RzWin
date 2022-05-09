using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;

using Core;
using NewMethod;

namespace Rz5
{
    public partial class consignment_code : consignment_code_auto
    {
        //Public Override Functions
        public override void HandleAction(ActArgs args)
        {
            List<consignment_code> items = new List<consignment_code>();
            foreach (IItem i in args.TheItems.AllGet(args.TheContext))
            {
                if (i is consignment_code)
                    items.Add((consignment_code)i);
            }
            switch (args.ActionName.ToLower())
            {
                case "createp.o.":
                    CreatePO((ContextRz)args.TheContext);
                    break;
                case "activate":
                    ActivateDeActivate((ContextRz)args.TheContext, items, true);
                    break;
                case "de-activate":
                    ActivateDeActivate((ContextRz)args.TheContext, items, false);
                    break;
                default:
                    base.HandleAction(args);
                    break;
            }
        }

        public override void Updating(Context x)
        {
            KeepCalc();

            if (is_stock)
                code_line = (code_name + " : [STOCK] " + description).Trim();
            else
                code_line = code_name + " : [" + payout_percent.ToString() + " % cost] " + vendor_name;
    
            order_key = Tools.Strings.Right("000000000000000000000000000000" + code_name, 30);
            base.Updating(x);
        }

        public void KeepCalc()
        {
            keep_percent = (100 - payout_percent);
        }

        private void CreatePO(ContextRz context)
        {
            ordhed_purchase ordhedPurchase = (Rz5.ordhed_purchase)ordhed.CreateNew(context, Enums.OrderType.Purchase);
            ordhedPurchase.the_consignment_code_uid = this.unique_id;
            context.Update(ordhedPurchase);
            context.Show(ordhedPurchase);
        }

        public override string ToString()
        {
            return this.code_name + " [" + this.payout_percent.ToString() + "]";
        }

        public static consignment_code GetByName(Context context, string name)
        {
            return (consignment_code)context.QtO("consignment_code", "select * from consignment_code where code_name = '" + name + "'");
        }

        public static consignment_code GetByName(Context context, string name, string vendor_id)
        {
            return (consignment_code)context.QtO("consignment_code", "select * from consignment_code where code_name = '" + name + "' and vendor_uid = '" + vendor_id + "'");
        }

        public static String RenderCode(ContextRz x, String code)
        {
            consignment_code c = consignment_code.GetByName(x, code);
            if (c == null)
                return code;
            else
                return c.code_line;
        }

        public static String RenderCode(ContextRz x, String code, String vendor_id)
        {
            consignment_code c = consignment_code.GetByName(x, code, vendor_id);
            if (c == null)
                return code;
            else
                return c.code_line;
        }
        public static String ParseCode(String code)
        {
            return Tools.Strings.ParseDelimit(code, ":", 1).Trim();
        }

        public static List<String> CodesList(ContextNM x)
        {
            List<String> ret = new List<string>();
            ArrayList a = x.SelectScalarArray("select code_line, order_key from consignment_code where isnull(code_line, '') > '' and isnull(code_name, '') > '' order by order_key");
            foreach (String s in a)
            {
                ret.Add(s);
            }
            return ret;
        }

        public static List<String> CodesListShort(ContextNM x)
        {
            List<String> hold = CodesList(x);
            List<String> ret = new List<string>();
            foreach (String s in hold)
            {
                ret.Add(Tools.Strings.Left(s, 26));
            }
            return ret;
        }

        public virtual Double CostCalc(Double price)
        {
            return Math.Round((price * (payout_percent / 100.0)), 6);
        }

        public static ListArgs ConsignmentCodeArgsGet(ContextNM context)
        {
            ListArgs ret = new ListArgs(context);
            ret.TheTemplate = "consignment_code_lv_template";
            ret.TheTable = "consignment_code";
            ret.TheClass = "consignment_code";
            ret.TheCaption = "Consignment Codes";
            ret.AddAllow = true;
            ret.AddCaption = "Add A New Code";
            ret.TheWhere = "";
            ret.TheOrder = "code_name";
            return ret;
        }

        public void ActivateDeActivate(ContextRz x, List<consignment_code> items, bool t_activate_f_deactivate)
        {
            if (items == null)
                return;
            foreach (consignment_code c in items)
            {
                c.is_inactive = !t_activate_f_deactivate;
                c.Update(x);
            }
        }
    }
}
