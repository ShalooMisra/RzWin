using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.IO;

using Core;
using NewMethod;

namespace Rz5
{
    public partial class orddet_old : orddet_old_auto, IPartObject, IAssignedAgent
    {
        public VarRefOrderOld TheOrderVar;
        public VarRefFieldPlusName<orddet_old, company> CompanyVar;
        public VarRefFieldPlusName<orddet_old, companycontact> ContactVar;
        public VarRefFieldPlusName<orddet_old, n_user> AgentVar;

        public override List<Var> VarsGetInitially()
        {
            List<Var> ret = base.VarsGetInitially();
            ret.Add(TheOrderVar);
            ret.Add(CompanyVar);
            ret.Add(ContactVar);
            ret.Add(AgentVar);
            return ret;
        }
  
        //Constructor
        public orddet_old()
        {
            TheOrderVar = new VarRefOrderOld(this);
            CompanyVar = new VarRefFieldPlusName<orddet_old, company>(this, new CoreVarRefSingleAttribute("Company", "Rz4.orddet_old", "Rz4.company", "", "base_company_uid"), "companyname", "companyname");
            ContactVar = new VarRefFieldPlusName<orddet_old, companycontact>(this, new CoreVarRefSingleAttribute("Contact", "Rz4.orddet_old", "Rz4.companycontact", "", "base_companycontact_uid"), "contactname", "contactname");
            AgentVar = new VarRefFieldPlusName<orddet_old, n_user>(this, new CoreVarRefSingleAttribute("Agent", "Rz4.orddet_old", "Rz4.n_user", "", "base_mc_user_uid"), "name", "agentname");          
        }

        public override void CompanyRefSet(ContextRz context, company companyObject, Enums.OrderType t)
        {
            base.CompanyRefSet(context, companyObject, t);
            CompanyVar.RefSet(context, companyObject);
        }

        public override void ContactRefSet(ContextRz context, companycontact contactObject, Enums.OrderType t)
        {
            base.ContactRefSet(context, contactObject, t);
            ContactVar.RefSet(context, contactObject);
        }

        public override void AgentRefSet(ContextRz context, n_user userObject, Enums.OrderType t)
        {
            base.AgentRefSet(context, userObject, t);
            AgentVar.RefSet(context, userObject);
        }
        public TreeNode MyNode;
        public ArrayList MyNodes;
        protected orddet_old m_ParentDetail;
        public orddet_old ParentDetailGet(ContextRz context)
        {
            if (m_ParentDetail == null)
                ParentDetailCache(context);
            return m_ParentDetail;
        }

        public void ParentDetailSet(ContextRz context, orddet_old value)
        {
            m_ParentDetail = value;
            ParentDetailAbsorb(context, value);
        }

        private ArrayList m_Details;

        public virtual void Init(ContextRz x)
        {
            DetailsSet(new ArrayList());
        }

        private void RemoveDisposedNodes()
        {
            if (MyNodes == null)
                return;
            try
            {
                ArrayList remove = new ArrayList();
                foreach (TreeNode n in MyNodes)
                {
                    if (n.TreeView == null)
                        remove.Add(n);
                    else if (n.TreeView.IsDisposed)
                        remove.Add(n);
                }
                foreach (TreeNode n in remove)
                {
                    MyNodes.Remove(n);
                }
            }
            catch
            {
            }
        }

        public virtual void RefreshNodes(ContextRz context)
        {
            if (MyNodes == null)
                return;
            RemoveDisposedNodes();
            foreach (TreeNode n in MyNodes)
            {
                n.Text = GetTreeCaption(context);
            }
        }
        //Public Override Functions
        public override void HandleAction(ActArgs args)
        {
            ContextRz xrz = (ContextRz)args.TheContext;

            switch (args.ActionName.ToLower())
            {
                case "newformalquote":
                    List<orddet> qs = new List<orddet>();
                    qs.Add(this);
                    ShowNewFormalQuote(xrz, qs);
                    args.Handled = true;
                    break;
                case "formalquote":
                    ordhed o = OrderObject(xrz);
                    if (o != null)
                        args.TheContext.Show(o);
                    else
                    {
                        MakeDealExist(xrz);
                        args.TheContext.Show(MakeHeaderExist(xrz));
                    }
                    break;
                case "duplicate":
                    Duplicate(xrz);
                    break;
                case "vieworderbatch":
                    Do_ViewOrderBatch(xrz);
                    args.Handled = true;
                    break;
                case "select":
                    isselected = !isselected;
                    args.TheContext.TheDelta.Update(xrz, this);
                    break;
                default:
                    base.HandleAction(args);
                    break;
            }
        }

        public virtual orddet Duplicate(ContextRz context)
        {
            bool link_prompt = false;
            orddet ret = DuplicateNoShow(context, ref link_prompt);

            if (link_prompt)
            {
                context.Show(ret);
                context.TheLeader.Tell("The original sales order line was linked to inventory ( " + LinkedPart.ToString() + " ).  Please create a PO for the new sales order line, or link it to the appropriate stock or buy inventory item.");
            }

            return ret;
        }

        public virtual orddet_old DuplicateNoShow(ContextRz context, ref bool link_prompt)
        {
            orddet_old d = (orddet_old)this.CloneValues(context);

            //2011_03_08 removed the dealdetail carry over
            d.base_dealdetail_uid = "";

            ordhed o = OrderObject(context);
            if (o != null)
            {
                d.linecode = o.GetNextLineCode(context);
            }
            link_prompt = false;
            if (OrderType == Enums.OrderType.Sales)
            {
                partrecord p = this.LinkedPart;
                if (p != null)
                {
                    link_prompt = true;
                }
                d.stockid = "";
            }
            context.Insert(d);
            if (o != null)
            {
                o.InsertDetail(context, d);
                //xSys.NotifyClassChange(ordhed.MakeOrddetName(d.OrderType), true);
            }
            return d;
        }

        public override void Inserting(Context x)
        {            
            buyerid = ((ContextRz)x).xUser.unique_id;
            isselected = true;
            base.Inserting(x);
        }

        public override void Updating(Context x)
        {
            ContextRz xrz = (ContextRz)x;

            if (!Tools.Strings.StrExt(base_mc_user_uid))
                base_mc_user_uid = xrz.xUser.unique_id;

            if (xrz.Accounts.IsBaseCurrency(currency_name))
            {
                currency_name = xrz.Accounts.BaseCurrency;  //fill in if blank
                exchange_rate = 1;
                unitprice_exchanged = unitprice;
                totalprice_exchanged = totalprice;
            }

            CalculateAmounts();
            PartObject.ParsePartNumber(this);
            company.FillIn(xrz, this, "vendor_company_uid", "vendorname");
            companycontact.FillIn(xrz, this, "vendorcontactid", "vendorcontactname", vendor_company_uid);
            NewMethod.n_user.FillIn(xrz, this, "base_mc_user_uid", "agentname");
            NewMethod.n_user.FillIn(xrz, this, "buyerid", "buyername");
            if (OrderType == Enums.OrderType.Purchase && quantityfilled > 0 && unitprice > 0 && !Tools.Strings.StrExt(fullpartnumber))
            {
                xrz.TheLeader.TellTemp("Why does this line item have a price and quantity but no part number?");
            }
            if (Tools.Strings.StrExt(vendorname) && !Tools.Strings.StrExt(original_vendor_name))
                original_vendor_name = vendorname;
            String si = PartObject.StripPart(internalpartnumber);
            if (si != internalstripped)
                internalstripped = si;
            if (si != internalpartnumber_stripped)
                internalpartnumber_stripped = si;
            si = PartObject.StripPart(alternatepart);
            if (si != alternatepartstripped)
                alternatepartstripped = si;
            if (xrz.TheSysRz.TheOrderLogic.UpperCasePartInfo())
            {
                fullpartnumber = fullpartnumber.ToUpper();
                alternatepart = alternatepart.ToUpper();
                internalpartnumber = internalpartnumber.ToUpper();
                manufacturer = manufacturer.ToUpper();
            }
            else if (xrz.Logic.UpperCaseEverything)
            {
                fullpartnumber = fullpartnumber.ToUpper();
                manufacturer = manufacturer.ToUpper();
                description = description.ToUpper();
                datecode = datecode.ToUpper();
                companyname = companyname.ToUpper();
                contactname = contactname.ToUpper();
            }
            part_number_stripped = Tools.Strings.FilterTrash(fullpartnumber);

            unitprice_print = xrz.Accounts.CurrencySymbol(currency_name) + Tools.Number.MoneyFormat(Math.Round(unitprice_exchanged, 6));
            totalprice_print = xrz.Accounts.CurrencySymbol(currency_name) + Tools.Number.MoneyFormat(Math.Round(totalprice_exchanged, 6));

            part_master m = part_master.Find(xrz, fullpartnumber);
            if(m != null)
            {
                if(m.manufacturer != "")
                    manufacturer = m.manufacturer;
                if(m.description != "")
                    description = m.description;
            }

            base.Updating(x);

            //is this a good idea?  i see at least major performance problems with this
            //could this be why the batch screen is so slow?
            //ordhed o = ordhed.GetById(x, this.base_ordhed_uid);
            //if (o != null)           
            //    o.Update(x);

            //how about this?  at least this way if the var is already initialized it doesn't have another round trip and doesn't create a separate instance
            ordhed o = TheOrderVar.RefGet(x);
            if (o != null)           
                o.Update(x);
        }

        public virtual void ApplyNewCurrency(ContextRz context, currency newCurrency)
        {
            currency_name = newCurrency.name;
            exchange_rate = newCurrency.exchange_rate;
            CurrencyUpdate(context);
        }

        public virtual void CurrencyUpdate(ContextRz x)
        {
            if (x.Sys.TheAccountLogic.IsBaseCurrency(currency_name))
            {
                exchange_rate = 1;
                unitprice_exchanged = unitprice;
            }
            else
            {
                if (exchange_rate == 0)
                    throw new Exception(ToString() + " has a currency of " + currency_name + " but an exchange rate of 0");

                unitprice_exchanged = currency.CalculateExchangeFromBase(unitprice, exchange_rate, 6);
            }
        }

        public void SetUnitPriceExchanged(ContextRz context, Double newForeignValue)
        {
            //if (exchange_rate == 0)
            //    throw new Exception(ToString() + " has a currency of " + currency_name + " but an exchange rate of 0");

            //unitprice = currency.CalculateExchangeFromForeign(newForeignValue, exchange_rate);
            //Update(context);
        }

        public virtual void AbsorbDetail(orddet_old d)
        {
            fullpartnumber = d.fullpartnumber;
            alternatepart = d.alternatepart;
            description = d.description;

            //stockid = d.stockid;
            //original_stock_id = d.original_stock_id;
            manufacturer = d.manufacturer;
            condition = d.condition;
            category = d.category;
            datecode = d.datecode;
            location = d.location;
            boxnum = d.boxnum;
            partsetup = d.partsetup;
            packaging = d.packaging;
            partsperpack = d.partsperpack;
            printedas = d.printedas;
            //stocktable = d.stocktable;
            userid = d.userid;
            mfg_certifications = d.mfg_certifications;
            agentname = d.agentname;
            base_mc_user_uid = d.base_mc_user_uid;
            userid = d.userid;
            stocktype = d.stocktype;
            //the_qualitycontrol_uid = d.the_qualitycontrol_uid;
            //buytype = d.buytype;

            lotnumber = d.lotnumber;
            consignment_code = d.consignment_code;

            quantityordered = d.quantityordered;

            //should this be here?
            isselected = true;

            ////this obviously shouldn't
            //if (Rz3App.xLogic.IsPhoenix)
            //{
            //    ISet("pec", d.IGet("pec"));
            //    ISet("release", d.IGet("release"));
            //    ISet("heci", d.IGet("heci"));
            //    ISet("line", d.IGet("line"));
            //}
        }

        public static List<orddet> DetailsSum(ContextNM context, List<orddet> a)
        {
            List<orddet> ret = new List<orddet>();
            Dictionary<String, orddet_old> dict = new Dictionary<string, orddet_old>();
            orddet_old yDetail;
            foreach (orddet_old xDetail in a)
            {
                String strAll = xDetail.fullpartnumber + "|" + xDetail.internalpartnumber + "|" + xDetail.packaging + "|" + xDetail.alternatepart + "|" + xDetail.manufacturer + "|" + xDetail.datecode + "|" + xDetail.condition + "|" + xDetail.partsetup + "|" + xDetail.lotnumber + "|" + xDetail.location + "|" + nTools.MoneyFormat_2_6(xDetail.unitprice) + "|" + xDetail.description; //nTools.DateFormat(xDetail.shipdate) + "|" + nTools.DateFormat(xDetail.requireddate) + "|"
                strAll = strAll.ToLower();
                if( dict.ContainsKey(strAll) )
                {                
                    yDetail = (orddet_old)dict[strAll];
                    yDetail.quantityordered += xDetail.quantityordered;
                    yDetail.quantityfilled += xDetail.quantityfilled;
                    yDetail.Updating(context);
                }
                else
                {
                    orddet_old nd = (orddet_old)xDetail.CloneValues(context);
                    nd.unique_id = "<none>";
                    dict.Add(strAll, nd);
                    ret.Add(nd);
                }
            }
            return ret;
        }

        public override String GetExtraClassInfo()
        {
            return ordertype;
        }

        public String OrdhedName
        {
            get
            {
                return ordhed.MakeOrdhedName(OrderType);
            }
        }
        //public String GetOrderCompanyName()
        //{
        //    if (ParentOrder == null)
        //        return xSys.xData.GetScalar_String("SELECT COMPANYNAME FROM " + OrdhedName + " WHERE unique_id = '" + base_ordhed_uid + "'");
        //    else
        //        return ParentOrder.companyname;
        //}
        //public String GetOrderReferenceNumber()
        //{
        //    if (ParentOrder == null)
        //        return xSys.xData.GetScalar_String("SELECT orderreference FROM " + OrdhedName + " WHERE unique_id = '" + base_ordhed_uid + "'");
        //    else
        //        return ParentOrder.orderreference;
        //}

        //public virtual void CalculateAmounts()
        //{
        //    extendedorder = Math.Round(quantityordered * unitprice, 6);
        //    extendedfilled = Math.Round(quantityfilled * unitprice, 6);
        //    quantitybacked = (quantityordered - quantityfilled - quantitycancelled);
        //    stockvalue = Math.Round(quantityordered * unitcost, 6);

        //    if (quantityfilled > 0)
        //    {
        //        lineprofit = GetLineProfit(true);
        //        totalprice = Math.Round(quantityfilled * unitprice, 2);
        //        totalvalue = totalprice;

        //        total_cost = Math.Round(quantityfilled * unitcost, 2);
        //    }
        //    else
        //    {
        //        lineprofit = GetLineProfit(false);
        //        totalprice = Math.Round(quantityordered * unitprice, 2);
        //        totalvalue = 0;

        //        total_cost = Math.Round(quantityordered * unitcost, 2);
        //    }

        //    totalprice_exchanged = Math.Round(quantityordered * unitprice_exchanged, 2);
        //}

        public virtual void CalculateAmounts()
        {
            extendedorder = Tools.Number.CommonSensibleRounding(quantityordered * unitprice);
            extendedfilled = Tools.Number.CommonSensibleRounding(quantityfilled * unitprice);
            quantitybacked = (quantityordered - quantityfilled - quantitycancelled);
            stockvalue = Tools.Number.CommonSensibleRounding(quantityordered * unitcost);

            if (quantityfilled > 0)
            {
                lineprofit = GetLineProfit(true);
                totalprice = Tools.Number.CommonSensibleRounding(quantityfilled * unitprice);
                totalvalue = totalprice;
                total_cost = Tools.Number.CommonSensibleRounding(quantityfilled * unitcost);
            }
            else
            {
                lineprofit = GetLineProfit(false);
                totalprice = Tools.Number.CommonSensibleRounding(quantityordered * unitprice);
                totalvalue = 0;

                total_cost = Tools.Number.CommonSensibleRounding(quantityordered * unitcost);
            }

            totalprice_exchanged = Math.Round(quantityordered * unitprice_exchanged, 2);
        }

        public virtual double GetLineProfit(bool tFilled_fOrdered)
        {
            double d = 0;  // freightcost;
            if (tFilled_fOrdered)
                return Tools.Number.CommonSensibleRounding((extendedfilled - (quantityfilled * unitcost) - (d)));  // + servicecost
            else
                return Tools.Number.CommonSensibleRounding((extendedorder - (quantityordered * unitcost) - (d)));  // + servicecost
        }

        public dealheader InferDealHeader(ContextNM x)
        {
            x.Reorg();
            return null;

            //ordhed xOrder;
            //dealheader xDeal;
            //xOrder = GetOrderObject();
            //if (xOrder == null)
            //    return null;
            //xDeal = xOrder.GetDealHeader(x);
            //if (xDeal == null)
            //    return null;
            //this.base_dealheader_uid = xDeal.unique_id;
            //this.base_dealdetail_uid = "";
            //this.ISave();
            //return xDeal;
        }

        public company CompanyObjectGet(ContextRz context)
        {
                return company.GetById(context, base_company_uid);
        }

        public void CompanyObjectSet(company value)
        {
            if (value == null)
            {
                base_company_uid = "";
                companyname = "";
            }
            else
            {
                base_company_uid = value.unique_id;
                companyname = value.companyname;
            }
        }
        public companycontact ContactObjectGet(ContextRz context)
        {
            return companycontact.GetById(context, base_companycontact_uid);
        }

        public void ContactObjectSet(companycontact value)
        {
            if (value == null)
            {
                base_companycontact_uid = "";
                contactname = "";
            }
            else
            {
                base_companycontact_uid = value.unique_id;
                contactname = value.contactname;
            }
        }
        public dealheader xDeal;
        public void TryCacheDeal(ContextRz x)
        {
            if (CompanyObjectGet(x) == null)
                return;
            if (((SysRz5)x.xSys).TheCompanyLogic.DealContactRequired(ContactObjectGet(x)))
                return;
            if (xDeal != null)
                return;
            //if (xDeal == null)
            //{
            //    ordhed p = OrderObject(x);
            //    if (p != null)
            //    {
            //        if (Tools.Strings.StrExt(p.base_dealheader_uid))
            //        {
            //            xDeal = dealheader.GetById(x, p.base_dealheader_uid);
            //            if (xDeal != null)
            //                xDeal.Init(x);
            //        }
            //    }
            //}
            if (xDeal == null)
            {
                if (Tools.Strings.StrExt(base_dealheader_uid))
                {
                    xDeal = dealheader.GetById(x, base_dealheader_uid);
                    if (xDeal != null)
                        xDeal.Init(x);
                }
            }
        }
        public dealheader MakeDealExist(ContextRz x)
        {
            //this isn't as crucial as it used to be
            ////company
            //company xCompany = CompanyObject;
            //if (xCompany == null)
            //{
            //    context.TheLeader.Tell("Please choose a company before continuing.");
            //    return null;
            //}
            ////contact
            //companycontact xContact = ContactObject;
            //if (xContact == null)
            //{
            //    if (Rz3App.xLogic.IsCTG && OrderType == Enums.OrderType.Quote)
            //    {
            //        context.TheLeader.Tell("Please choose a contact before continuing.");
            //        return null;
            //    }
            //    xContact = new companycontact(Rz3App.xSys);
            //}
            dealheader d = null;
            if (xDeal != null)
                d = xDeal;
            if (d == null)
            {
                ordhed p = OrderObject(x);
                if (p != null)
                {
                    //contextRz.TheLeader.Error("reorg");
                    //if (ParentOrder.xDeal != null)
                    //    d = ParentOrder.xDeal;
                }
            }
            if (d == null)
            {
                if (Tools.Strings.StrExt(base_dealheader_uid))
                {
                    d = dealheader.GetById(x, base_dealheader_uid);
                    if (d != null)
                    {
                        d.Init(x);
                    }
                }
            }
            if (d == null)
            {
                ordhed p = OrderObject(x);
                if (p != null)
                {
                    //contextRz.TheLeader.Error("reorg");
                    //d = ParentOrder.MakeDealExist(x);
                }
            }
            if (d == null)
            {
                d = dealheader.MakeManualDeal(x, CompanyObjectGet(x), ContactObjectGet(x));
                this.base_dealheader_uid = d.unique_id;
                x.Update(this);
            }
            //dealcompany c = d.MakeCompanyExist(xCompany.unique_id, xCompany.companyname, xContact.unique_id, xContact.contactname, ordhed.GetAsVendor(OrderDirection), ordhed.GetAsService(OrderType));
            //nObject dd = c.GetObjectByID(this.unique_id);
            //if (dd == null)
            //{
            //    if (this.OrderType == Enums.OrderType.Quote)
            //        c.AbsorbQuoteDetail((orddet_quote)this, null);
            //    else
            //    {
            //        //this duplicated the lines
            //        //c.AbsorbRFQDetail((orddet_rfq)this, this.ParentDetail);
            //        context.TheLeader.Tell("Absorbing bids is not yet supported.");
            //    }
            //}
            xDeal = d;
            return xDeal;
        }
        public ordhed MakeHeaderExist(ContextRz context)
        {
            ordhed q = OrderObject(context);
            if (q != null)
                return q;
            q = ordhed.CreateNew(context, OrderType);
            company xc = company.GetById(context, base_company_uid);
            if (xc != null)
            {
                q.AbsorbCompany(context, xc);
            }
            companycontact xct = companycontact.GetById(context, base_companycontact_uid);
            if (xct != null)
            {
                q.AbsorbContact(context, xct);
            }
            q.companyname = companyname;
            q.base_company_uid = base_company_uid;
            q.contactname = contactname;
            q.base_companycontact_uid = base_companycontact_uid;
            if (OrderType == Enums.OrderType.Quote)  //this logic to use the line's date was commented out, and uncommented for quotes per Jeff@ctg on 2009_02_16
            {
                if (Tools.Dates.DateExists(orderdate))
                    q.orderdate = orderdate;
            }
            else
                q.orderdate = DateTime.Now;

            n_user agent = AgentVar.RefGet(context);
            if (agent == null)
            {
                if (Tools.Strings.StrExt(base_mc_user_uid))
                {
                    q.base_mc_user_uid = base_mc_user_uid;
                    q.agentname = agentname;
                }
            }
            else
            {
                q.AgentVar.RefSet(context, agent);  //i think this was the missing email cc's; the agent var wasn't actually set the first time
            }

            q.base_dealheader_uid = base_dealheader_uid;
            
            //contextRz.TheLeader.Error("reorg");
            //q.xDeal = xDeal;
            
            context.Update(q);
            base_ordhed_uid = q.unique_id;
            ordernumber = q.ordernumber;
            context.Update(this);
            
            q.DetailInsert(context, this);
            
            //this should happen automatically with detailinsert, right?
            //this.ParentOrder = q;
            
            return q;
        }

        public bool SwitchCompany(ContextRz context, IWin32Window owner)
        {
            //String strCompanyID = "";
            //String strCompanyName = "";
            //String strContactID = "";
            //String strContactName = "";
            company comp = null;
            companycontact cont = null;
            context.TheLeaderRz.ChooseCompany(context, ref comp, ref cont);
            //frmChooseCompany_Big.ChooseCompanyID(ref strCompanyID, ref strCompanyName, ref strContactID, ref strContactName, Enums.CompanySelectionType.Both, "Please choose a company", owner);
            //if (!Tools.Strings.StrExt(strCompanyID) || !Tools.Strings.StrExt(strCompanyName))
            //    return false;
            if (OrderType == Enums.OrderType.Quote && ((SysRz5)context.xSys).TheQuoteLogic.CompanyAndContactRequired())
            {
                //if (!Tools.Strings.StrExt(strContactID) || !Tools.Strings.StrExt(strContactName))
                if (comp == null || cont == null)
                {
                    context.TheLeader.Tell("Please choose both a company and a contact before continuing.");
                    return false;
                }
            }
            ordhed p = OrderObject(context);
            //company comp = company.GetById(context, strCompanyID);
            if (p != null)
            {
                //companycontact cont = companycontact.GetById(context, strContactID);
                if (comp != null)
                {
                    if (cont != null)
                        p.AbsorbCompanyAndContact(context, comp, cont);
                    else
                        p.AbsorbCompany(context, comp);
                    if (!Tools.Strings.StrExt(p.unique_id))
                        p.Insert(context);
                    else
                        p.Update(context);
                }
            }
            //base_company_uid = strCompanyID;
            //companyname = strCompanyName;
            //base_companycontact_uid = strContactID;
            //contactname = strContactName;
            if (comp != null)
            {
                base_company_uid = comp.unique_id;
                companyname = comp.companyname;
            }
            if (cont != null)
            {
                base_companycontact_uid = cont.unique_id;
                contactname = cont.contactname;
            }
            if (comp != null)
                abs_type = comp.abs_type;
            if (!Tools.Strings.StrExt(unique_id))
                Insert(context);
            else
                Update(context);
            return true;
        }
        public String UserID
        {
            get
            {
                return base_mc_user_uid;
            }
            set
            {
                base_mc_user_uid = value;
            }
        }
        public String UserName
        {
            get
            {
                return agentname;
            }
            set
            {
                agentname = value;
            }
        }
        public n_user UserObjectGet(ContextRz x)
        {
            return n_user.GetById(x, base_mc_user_uid);
        }

        public void UserObjectSet(n_user value)
        {
            if (value == null)
            {
                base_mc_user_uid = "";
                agentname = "";
            }
            else
            {
                base_mc_user_uid = value.unique_id;
                agentname = value.name;
            }
        }

        public String FriendlyOrderType
        {
            get
            {
                return RzLogic.GetFriendlyOrderType(OrderType);
            }
        }

        public String GetCompanyID(ContextRz context)
        {
            ordhed p = OrderObject(context);
            if( p == null )
                return "";
            else
                return p.base_company_uid;
        }
        public ordhed OrderObject(ContextRz context)
        {
            return TheOrderVar.RefGet(context);
            //get
            //{
            //    if (ParentOrder == null)
            //        ParentOrder = ordhed.GetByID(xSys, base_ordhed_uid);
            //    return ParentOrder;
            //}
            //set
            //{
            //    if (value == null)
            //    {
            //        base_ordhed_uid = "";
            //    }
            //    else
            //    {
            //        base_ordhed_uid = value.unique_id;
            //        ParentOrder = value;
            //    }
            //}
        }
        public String GetVendorEmailAddress(ContextRz context)
        {
            if (Tools.Strings.StrExt(vendorcontactid))
            {
                companycontact xContact = companycontact.GetById(context, vendorcontactid);
                if (xContact != null)
                {
                    if (Tools.Strings.StrExt(xContact.primaryemailaddress))
                        return xContact.primaryemailaddress;
                }
            }
            company xVendor = company.GetById(context, vendor_company_uid);
            if (xVendor == null)
                return "";
            else
                return xVendor.primaryemailaddress;
        }
        public dealheader GetDealHeader(ContextNM x)
        {
            dealheader xDeal;
            if (!Tools.Strings.StrExt(base_dealheader_uid))
            {
                return InferDealHeader(x);
            }
            else
            {
                xDeal = dealheader.GetById(x, base_dealheader_uid);
                if (xDeal == null)
                    return InferDealHeader(x);
                else
                    return xDeal;
            }
        }
        public ordhed GetOrderObject(ContextRz context)
        {
            return ordhed.GetById(context, base_ordhed_uid, OrderType);
        }
        public void AbsorbDetailFull(orddet d)
        {
            MessageBox.Show("reorg");

            //AbsorbDetail(d);

            //internalpartnumber = d.internalpartnumber;
            //quantityfilled = d.quantityfilled;

            //unitcost = d.unitcost;
            //unitprice = d.unitprice;

            //vendor_company_uid = d.vendor_company_uid;
            //vendorname = d.vendorname;
            //vendorcontactid = d.vendorcontactid;
            //vendorcontactname = d.vendorcontactname;

            //warranty_period = d.warranty_period;

            //buyerid = d.buyerid;
            //buyername = d.buyername;
            //country = d.country;
            //freightcost = d.freightcost;
            //servicecost = d.servicecost;

            //original_vendor_name = d.original_vendor_name;
            //is_service = d.is_service;
            //leadtime = d.leadtime;

            //shipvia = d.shipvia;
            //shipdate = d.shipdate;
            //sales_orddet_uid = d.unique_id;

            ////wow.  i don't know what else to say
            ////if (d.LinkedPart != null)
            ////{
            ////    HandleConsignmentPercentInvoice(d.LinkedPart, yDetail);
            ////}

            //consignment_percent = d.consignment_percent;
        }
        public Double GetNetProfit()
        {
            return GetNetProfit(false);
        }
        public Double GetNetProfit(bool BlockNegative)
        {
            Double dblHold = unitprice - unitcost;
            if (BlockNegative && dblHold < 0)
                dblHold = 0;
            return Math.Round(dblHold * quantityfilled, 2);
        }
        public Double GetGrossProfit()
        {
            return GetGrossProfit(false);
        }
        public Double GetGrossProfit(bool BlockNegative)
        {
            Double dblHold = unitprice;
            if (BlockNegative && dblHold < 0)
                dblHold = 0;
            return Math.Round(dblHold * quantityfilled, 2);
        }
        public virtual void AddDetail(ContextRz x, orddet_old d)
        {
            DetailsGet(x).Add(d);
        }
        public virtual void DetailAbsorb(ContextRz x, orddet_old d)
        {

        }
        public void RemoveNodes()
        {
            try
            {
                if (MyNodes == null)
                    return;
                foreach (TreeNode n in MyNodes)
                {
                    n.Parent.Nodes.Remove(n);
                }
                MyNodes.Clear();
            }
            catch
            {
            }
        }
        public void AddNode(TreeNode n)
        {
            if (MyNodes == null)
                MyNodes = new ArrayList();
            MyNodes.Add(n);
        }
        public ArrayList DetailsGet(ContextRz context)
        {
            if (m_Details == null)
                CacheDetails(context);
            return m_Details;
        }
        public void DetailsSet(ArrayList value)
        {
            m_Details = value;
        }
        public ArrayList DetailsList()
        {
            if (m_Details == null)
                return new ArrayList();
            if (m_Details.Count == 0)
                return new ArrayList();
            return m_Details;
        }
        public void AddDetailDirectly(orddet d)
        {
            if (m_Details == null)
                m_Details = new ArrayList();
            m_Details.Add(d);
        }
        public void ShowDetail(ContextRz x, orddet_old d)
        {
            if (d == null)
                return;

            if (MyNode == null)
                return;
            if (d == null)
                return;
            TreeNode n = MyNode.Nodes.Add(d.GetTreeCaption(x, true));
            d.AddNode(n);
            d.RefreshNodes(x);
            OrderTreeNodeHandle h = new OrderTreeNodeHandle("detail", d);
            h.MyNode = n;
            n.Tag = h;
            MyNode.ExpandAll();
        }

        public virtual Enums.OrderType OrderType
        {
            get
            {
                return RzLogic.ConvertOrderType(ordertype);
            }
            set
            {
                ordertype = RzLogic.ConvertOrderType(value);
            }
        }

        public override int LineCodeGet(Enums.OrderType t)
        {
            return Convert.ToInt32(linecode);
        }

        public override Var VarGetByName(string name)
        {
            switch (name.ToLower().Trim())
            {
                case "theorder":
                    return TheOrderVar;
                case "company":
                    return CompanyVar;
                case "contact":
                    return ContactVar;
                case "agent":
                    return AgentVar;
                default:
                    return base.VarGetByName(name);
            }
        }

        //public override List<Var> VarsGet()
        //{
        //    List<Var> ret = base.VarsGet();
        //    ret.Add(TheOrderVar);
        //    return ret;
        //}

        public override bool CanBeViewedBy(ContextNM context, ShowArgs args)
        {
            return CanBeViewedByActual(context, args);
        }

        protected bool CanBeViewedByActual(ContextNM context, ShowArgs args)
        {
            return true;
        }

        public override bool CanBeEditedBy(ContextNM context, ShowArgs args)
        {
            return CanBeEditedByActual(context, args);
        }

        protected bool CanBeEditedByActual(ContextNM context, ShowArgs args)
        {
            return true;
        }

        public override bool CanBeDeletedBy(ContextNM context, ShowArgs args)
        {
            return CanBeDeletedByActual(context, args);
        }

        protected bool CanBeDeletedByActual(ContextNM context, ShowArgs args)
        {
            try
            {
                return this.OrderObject((ContextRz)context).CanBeDeletedBy(context);
            }
            catch
            {
                if (context.xUser.SuperUser)
                    return true;
                return context.xUser.IsOnTeamWith(context, base_mc_user_uid);
            }
        }

        //public override bool CanBeDeletedBy(ContextNM context, ShowArgs args)
        //{
        //    try
        //    {
        //        return this.GetOrderObject((ContextRz)context).CanBeDeletedBy(context, args);
        //    }
        //    catch
        //    {
        //        if (context.xUser.SuperUser)
        //            return true;
        //        return context.xUser.IsOnTeamWith(context, base_mc_user_uid);
        //    }
        //}
        //public override bool CanBeViewedBy(ContextNM context, ShowArgs args)
        //{
        //    switch (OrderType)
        //    {
        //        case Enums.OrderType.Quote:
        //        case Enums.OrderType.RFQ:
        //            return true;
        //    }
        //    try
        //    {
        //        return this.GetOrderObject((ContextRz)context).CanBeViewedBy(context, args);
        //    }
        //    catch
        //    {
        //        return false;
        //        //return Rz3App.xLogic.CanBeViewedBy(this, u);
        //    }
        //}
        //public override bool CanBeEditedBy(ContextNM context, ShowArgs args)
        //{
        //    //MessageBox.Show("reorg");
        //    return false;

        //    //try
        //    //{
        //    //    return this.OrderObject.CanBeEditedBy(u);
        //    //}
        //    //catch
        //    //{

        //    //    if (Rz3App.xUser.CheckPermit(context, "General:Edit:CanEditOrddet-" + OrderType.ToString()))
        //    //        return true;

        //    //    return Rz3App.xLogic.CanBeEditedBy(this, u);
        //    //}
        //}


        //public override nObject CloneValues(ContextNM x)
        //{
        //    nObject n = base.CloneValues(x);

        //    foreach (CoreVarValAttribute p in x.TheSys.CoreClassGet("orddet").VarValsGet())  //orddet isn't officially a base because of the NMI
        //    {
        //        n.ISet(p.Name, this.IGet(p.Name));
        //    }

        //    return n;
        //}

        public void Do_ViewOrderBatch(ContextRz x)
        {
            TryCacheDeal(x);
            if (xDeal == null)
                x.TheLeader.Tell("This item isn't attached to an order batch");
            else
                x.Show(xDeal);
        }

        public override void OrderDateSet(ContextRz context, DateTime d, Enums.OrderType t)
        {
            base.OrderDateSet(context, d, t);
            orderdate = d;
            context.TheDelta.Update(context, this);
        }

        public override String GetClipHTML(ContextNM context)
        {
            String s = GetClipHeader(context);
            s += PartObject.GetClipLine_Part(this, "quantityordered");
            return s;
        }        
    }

    public class VarRefOrderOld : VarRefSingle<orddet_old, ordhed>
    {
        public orddet_old TheDetail;
        public VarRefOrderOld(orddet_old detail)
            : base(detail, new CoreVarRefSingleAttribute("TheOrder", "orddet_old", "ordhed", "Details", "base_ordhed_uid"))
        {
            TheDetail = detail;
        }

        public override void RefSet(Context x, ordhed value, bool includeReverse)
        {
            base.RefSet(x, value, includeReverse);

            if (value == null)
            {
                TheDetail.linecode = 0;
                TheDetail.base_ordhed_uid = "";
            }
            else
            {
                TheDetail.linecode = value.GetNextLineCode((ContextRz)x);
                TheDetail.base_ordhed_uid = value.unique_id;
            }
        }

        public override string ReferenceId
        {
            get
            {
                return TheDetail.base_ordhed_uid;
            }
            set
            {
                base.ReferenceId = value;
            }
        }

        protected override QueryClass QueryCreate(Context context)
        {
            QueryClass q = new QueryClass("ordhed_" + TheDetail.OrderType.ToString().ToLower());
            q.Where = new ExpressionBinaryOperator(new ExpressionIdentifier("unique_id"), BinaryOperatorType.Equality, new ExpressionLiteralString(TheDetail.base_ordhed_uid));
            return q;
        }
    }
}
