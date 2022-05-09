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
    public partial class orddet : orddet_auto
    {
        //Public Static Variables
        public static orddet TheCutDetail = null;
        public static ArrayList GlobalLineInfo = null;
    
        //Public Static Functions
        public static void SetLotNumber(ContextNM context, List<orddet> details)
        {
            String lot = context.TheLeader.AskForString("Lot Number", "", false);
            if (!Tools.Strings.StrExt(lot))
                return;
            if (!context.TheLeader.AreYouSure("Set the lot number on " + Tools.Strings.PluralizePhrase("item", details.Count) + " to " + lot))
                return;

            foreach (orddet d in details)
            {
                d.lotnumber = lot;
                d.consignment_code = lot;
                context.Update(d);
            }
        }
        public static ordhed SendForService(ContextNM context, orddet o)
        {
            return SendForService(context, o, true);
        }
        public static ordhed SendForService(ContextNM context, orddet o, bool show)
        {
            List<orddet> a = new List<orddet>();
            a.Add(o);
            return SendForService(context, a, show);
        }
        public static ordhed SendForService(ContextNM context, List<orddet> a, bool show)
        {
            MessageBox.Show("reorg");
            return null;

            ////checks for stock links and quantities (for service POs we have to have the parts)
            //StringBuilder sb = new StringBuilder();
            //bool ok = true;
            //SortedList sos = new SortedList();
            //foreach(orddet o in a)
            //{
            //    partrecord p = o.LinkedPart;
            //    if(p == null)
            //    {
            //        ok = false;
            //        sb.AppendLine(o.ToString() + " doesn't appear to be linked to an inventory line.");
            //    }
            //    if(ok)
            //    {
            //        ordhed so = o.GetOrderObject();
            //        if(so != null)
            //        {
            //            try
            //            {
            //                sos.Add(so.ordernumber, so);
            //            }
            //            catch(Exception)
            //            {
            //            }
            //        }
            //    }
            //}
            //if(!ok)
            //{
            //    context.TheLeader.Tell("A service order could not be created because:\r\n\r\n" + sb.ToString());
            //    return null;
            //}
            ////creates the PO
            //ordhed po = ordhed.CreateNew(context, Enums.OrderType.Service);
            //po.ISave();
            //foreach(DictionaryEntry d in sos)
            //{
            //    ordhed xso = (ordhed)d.Value;
            //    dealheader.CheckDealLinks(Rz3App.xMainForm.TheContextNM, xso, po);    //deal links
            //}
            ////DOES NOT MARK THE LINES AS PURCHASED
            //foreach(orddet o in a)
            //{
            //    //deal stock links to the original lines
            //    dealdetail.CheckDealLinksStock(Rz3App.xMainForm.TheContextNM, o, o.LinkedPart, null, null);
            //    orddet nd = po.LineCreate();
            //    nd.AbsorbDetail(o);    // ordhed.AssociateDetails(o, nd, false);
            //    nd.vendor_company_uid = "";
            //    nd.vendorname = "";
            //    nd.unitprice = 0;
            //    nd.unitcost = 0;
            //    nd.base_dealheader_uid = o.base_dealheader_uid;
            //    nd.base_dealdetail_uid = o.base_dealdetail_uid;
            //    nd.IUpdate();
            //    dealdetail.CheckDealLinksStock(Rz3App.xMainForm.TheContextNM, nd, o.LinkedPart, null, null);
            //    o.location = "Sent For Service On " + nTools.DateFormat(System.DateTime.Now) + " : " + o.location;
            //    o.ISave();
            //    //picks each line out of stock
            //    partrecord p = o.LinkedPart;
            //    p.location = "Waiting For Service on Service Order " + po.ordernumber;
            //    p.ISave();
            //    //deal links
            //    dealdetail.CheckDealLinksDetail(Rz3App.xMainForm.TheContextNM, o, nd);
            //}
            ////links them to the sales order(s)
            //foreach(DictionaryEntry d in sos)
            //{
            //    try
            //    {
            //        ordhed xso = (ordhed)d.Value;
            //        po.MakeLinkObject(Rz3App.xMainForm.TheContextNM, xso);
            //    }
            //    catch(Exception)
            //    {
            //    }
            //}
            //if (show)
            //    context.Show(po);
            //return po;
        }
        public static ArrayList GetDetailTableNames()
        {
            ArrayList a = new ArrayList();
            List<Enums.OrderType> t = ordhed.OrderTypes;
            foreach(Enums.OrderType s in t)
            {
                a.Add("orddet_" + s.ToString().ToLower());
            }
            return a;
        }
        public static bool RunSQLOnDetailTables(ContextRz context, String strSQL)
        {
            ArrayList a = GetDetailTableNames();
            foreach(String s in a)
            {
                context.Execute(strSQL.Replace("<detail table>", s));
            }
            return true;
        }
        public static void SetSupplier(List<orddet> a)
        {
            MessageBox.Show("reorg");


            //try
            //{
            //    if (a == null)
            //        return;
            //    if (a.Count <= 0)
            //        return;
            //    orddet d = (orddet)a[0];
            //    if (d == null)
            //        return;
            //    ordhed hed = d.GetOrderObject();
            //    if (hed == null)
            //        return;
            //    foreach (KeyValuePair<String, nObject> kvp in hed.AllDetails)
            //    {
            //        if (((orddet)kvp.Value).linecode == 1)
            //        {
            //            d = (orddet)kvp.Value;
            //            break;
            //        }
            //    }
            //    foreach (orddet o in a)
            //    {
            //        if (o == null)
            //            continue;
            //        o.vendor_company_uid = d.vendor_company_uid;
            //        o.vendorid = d.vendorid;
            //        o.vendorname = d.vendorname;
            //        o.ISave();
            //    }
            //}
            //catch { }
        }
        public static void Restore(ContextNM x)
        {
            //try
            //{
            //    if (!x.xSys.Recall)
            //    {
            //        x.TheLeader.Tell("This system isn't configured to restore deleted items.");
            //        return;
            //    }
            //    String s = "";
            //    if (!x.xSys.recall_connection.CanConnect(ref s))
            //    {
            //        x.TheLeader.Tell("The Recall connection is unavailable: " + s);
            //        return;
            //    }
            //    ordhed o = frmOrderSelection.Choose(null);
            //    if (o == null)
            //        return;
            //    bool is_detline = false;
            //    string SQL = "";
                
            //    switch (o.OrderType)
            //    {
            //        case Enums.OrderType.Invoice:
            //        case Enums.OrderType.Purchase:
            //        case Enums.OrderType.RMA:
            //        case Enums.OrderType.Sales:
            //        case Enums.OrderType.Service:
            //        case Enums.OrderType.VendRMA:
            //            SQL = "select * from orddet_line where recall_type = 3 and orderid_" + o.OrderType.ToString() + " = '" + o.unique_id + "' order by linecode_" + o.OrderType.ToString();
            //            is_detline = true;
            //            break;
            //        default:
            //            SQL = "select * from " + ordhed.MakeOrddetName(o.OrderType) + " where recall_type = 3 and base_ordhed_uid = '" + o.unique_id + "' order by linecode";
            //            is_detline = false;
            //            break;
            //    }
            //    DataTable d = x.xSys.recall_connection.GetDataTable(SQL);
            //    if (!Tools.Data.DataTableExists(d))
            //    {
            //        x.TheLeader.Tell("No line items were found for " + o.ToString());
            //        return;
            //    }
            //    ArrayList a = new ArrayList();
            //    foreach (DataRow r in d.Rows)
            //    {
            //        if (is_detline)
            //            a.Add("Part: " + nData.NullFilter_String(r["fullpartnumber"]) + " Qty: " + nData.NullFilter_Long(r["quantity"]).ToString() + " [" + nData.NullFilter_String(r["unique_id"]) + "]");
            //        else
            //            a.Add("Part: " + nData.NullFilter_String(r["fullpartnumber"]) + " Qty: " + nData.NullFilter_Long(r["quantityordered"]).ToString() + " [" + nData.NullFilter_String(r["unique_id"]) + "]");
            //    }
            //    ArrayList xss = frmChooseMultipleChoices.ChooseFromArray(a, "Please choose a line to restore", null);
            //    if (xss == null)
            //        return;
            //    if (xss.Count == 0)
            //        return;
            //    foreach (String xs in xss)
            //    {
            //        String xid = Tools.Strings.ParseDelimit(xs, "[", 2);
            //        xid = Tools.Strings.Left(xid, xid.Length - 1);
            //        string table = ordhed.MakeOrddetName(o.OrderType);
            //        if (is_detline)
            //            table = "orddet_line";
            //        DataTable st = x.xSys.RecallConnection.Select("select top 1 * from " + table + " ");
            //        SortedList props = x.xSys.GetPropsByClass(table);
            //        String strSQL = "";
            //        a = new ArrayList();
            //        foreach (DictionaryEntry xd in props)
            //        {
            //            n_prop p = (n_prop)xd.Value;
            //            if (!p.IsUniqueID)
            //            {
            //                //only restore fields that exist in the backup
            //                if (nData.HasField(st, p.name))
            //                {
            //                    if (!nTools.IsInArray(p.name, a))
            //                    {
            //                        if (Tools.Strings.StrExt(strSQL))
            //                            strSQL += ", ";
            //                        strSQL += p.name;
            //                        a.Add(p.Name);
            //                    }
            //                }
            //            }
            //        }
            //        strSQL = "insert into " + x.xSys.xData.database_name + ".dbo." + table + " (unique_id, " + strSQL + ") select top 1 unique_id, " + strSQL + " from " + table + " where unique_id = '" + xid + "' and recall_type = 3 order by recall_date desc";
            //        if (!x.xSys.recall_connection.Execute(strSQL))
            //            x.TheLeader.Tell("The restore was not successful on " + xs);
            //    }
            //    x.Show(o);
            //}
            //catch { }
        }
        public static void ShowNewFormalQuote(ContextRz context, List<orddet> lines)
        {
            orddet_old q = (orddet_old)lines[0];

            ordhed_quote h = (ordhed_quote)ordhed.CreateNew(context, Enums.OrderType.Quote);
            h.base_company_uid = q.base_company_uid;
            h.companyname = q.companyname;
            h.base_companycontact_uid = q.base_companycontact_uid;
            h.contactname = q.contactname;

            ordhed header = q.OrderObject(context);
            if (header != null)
            {
                h.primaryphone = header.primaryphone;
                h.primaryfax = header.primaryfax;
                h.primaryemailaddress = header.primaryemailaddress;
            }

            context.Update(h);

            foreach (orddet_old line in lines)
            {
                orddet_quote d = (orddet_quote)h.AddLineItem(context, line.fullpartnumber, line.quantityordered, line.unitprice);
                d.AbsorbDetail(line);
                d.base_dealdetail_uid = "";
                d.base_dealheader_uid = "";
                context.Update(d);
            }

            context.Show(h);
        }
        //Public Virtual Functions
        public String GetTreeCaption(ContextRz context)
        {
            return GetTreeCaption(context, false);
        }
        public virtual String GetTreeCaption(ContextRz context, bool show_company)
        {
            return ToString();
        }
        public virtual void CacheDetails(ContextRz context)
        {
        }
        //Public Override Functions
        public override void HandleAction(ActArgs args)
        {
            ContextRz xrz = (ContextRz)args.TheContext;

            switch(args.ActionName.Trim().ToLower())
            {
                case "duplicatesupplier":
                    List<orddet> a = new List<orddet>();
                    a.Add(this);
                    orddet.SetSupplier(a);
                    args.Handled = true;
                    break;
                case "importpictures":
                    ImportPictures((ContextRz)args.TheContext);
                    break;
                //case "backorderinvoice":
                //    BackOrderInvoice((ContextRz)args.TheContext);
                //    args.ShouldClose = true;
                //    break;
                //case "select":
                //    Select();
                //    break;
                case "linkstock":
                    LinkStockItem(null);
                    break;
                case "breaklink":
                    BreakLink((ContextRz)args.TheContext);
                    break;
                //case "emailvendor":
                //    DoAction_EmailVendor(args);
                //    break;
                //case "directemailvendor":
                //    DoAction_DirectEmailVendor(args);
                //    break;
                //case "faxvendor":
                //    DoAction_FaxVendor(args);
                //    break;
                //case "vieworder":
                //    ViewOrder((ContextNM)args.TheContext);
                //    break;
                //case "receivestock":
                //case "receiveparts":
                //    DoAction_ReceiveStock(args);
                //    break;
                //case "pickstock":
                //    DoAction_PickStock(args);
                //    break;
                case "viewstock":
                case "viewpart":
                    ViewPartObject(xrz);
                    break;
                //case "printboxlabel":
                //    PrintBoxLabel(null);
                //    break;
                //case "un-purchase":
                //case "unpurchase":
                //    DoAction_UnPurchase(args);
                //    break;
                //case "re-number":
                //    DoAction_ReNumber(args);
                //    break;
                case "hotpart":
                    xrz.Logic.NewHotPart(xrz, null, null, fullpartnumber);
                    break;
                case "sendforservice":
                    orddet.SendForService((ContextNM)args.TheContext, this);
                    break;
                case "hardwarerfq":
                    WebRFQ(xrz, null, Enums.EmailRFQType.Web);
                    break;
                case "wire/cablerfq":
                    WebRFQ(xrz, null, Enums.EmailRFQType.Franchise);
                    break;
                case "chinarfq":
                    WebRFQ(xrz, null, Enums.EmailRFQType.China);
                    break;
                case "preferredvendorrfq":
                    WebRFQ(xrz, null, Enums.EmailRFQType.Preferred);
                    break;
                //case "allocate":
                //    DoAction_AllocateStock(args);
                //    return;
                case "copylineinfo":
                    CopyLineInfo();
                    break;
                //case "salesorder":
                //    MakeSalesOrder(xrz);
                //    break;
                //case "forms":
                //    ShowForms();
                //    break;
                //case "viewserialnumbers":
                //    Rz3App.xLogic.ShowSerialNumbers(this);
                //    break;
                //case "setserials":
                //    Rz3App.xLogic.SetSerials(this);
                //    break;
                //case "clearserials":
                //    Rz3App.xLogic.ClearSerials(this);
                //    break;
                //case "pickserialnumbers":
                //    Rz3App.xLogic.ShipSerialNumbers(Rz3App.xMainForm.TheContextNM, this);
                //    break;
                //case "receiveserialnumbers":
                //    Rz3App.xLogic.ReceiveSerialNumbers(Rz3App.xMainForm.TheContextNM, this);
                //    break;

                //case "fixserialnumbers":
                //    Rz3App.xLogic.FixSerialNumber(this);
                //    break;
                case "pictures":
                    //involves the leader
                    args.TheContext.Reorg();    
                    //PicturesShow(xrz);
                    break;
                case "setlotnumber":
                    List<orddet> objs = new List<orddet>();
                    objs.Add(this);
                    SetLotNumber((ContextNM)args.TheContext, objs);
                    break;
                default:
                    base.HandleAction(args);
                    break;
            }
        }
        public override string ToString()
        {
            return ("Line Item " + fullpartnumber).Trim();
        }

       
        public partrecord LinkedPart
        {

            get
            {
                return null;
                
                //if( !Tools.Strings.StrExt(stockid) )
                //    return null;
                //if( m_LinkedPart == null )
                //    m_LinkedPart = partrecord.GetByID(xSys, stockid);
                //return m_LinkedPart;
            }
            set
            {
                //if( value == null )
                //    stockid = "";
                //else
                //    stockid = value.unique_id;
                //m_LinkedPart = value;
            }
        }
        public Double GetPurchaseCost(ContextRz context, String strStockID)
        {
            return context.SelectScalarDouble("select max(unitprice) from " + ordhed.MakeOrddetName(Enums.OrderType.Purchase) + " where ordertype = 'purchase' and stockid = '" + strStockID + "'");
        }
        public String FullName(bool SkipOrder)
        {
            MessageBox.Show("reorg");
            return "";

            //if( SkipOrder )
            //    return "Part: " + fullpartnumber + " Qty: " + Tools.Number.LongFormat(quantityordered);
            //else
            //    return nTools.NiceFormat(ordertype) + " " + ordernumber + " Part: " + fullpartnumber + " Qty: " + Tools.Number.LongFormat(quantityordered);
        }
        public void ImportPictures(ContextRz context)
        {
            try
            {
                FolderBrowserDialog fb = new FolderBrowserDialog();
                DialogResult dr = fb.ShowDialog();
                if( dr == DialogResult.Cancel || dr == DialogResult.Abort )
                    return;
                String folder = fb.SelectedPath;
                if( !Directory.Exists(folder) )
                    return;
                String[] files = Directory.GetFiles(folder);
                if( files == null )
                    return;
                if(files.Length <= 0)
                {
                    context.TheLeader.TellTemp("No pictures found");
                    return;
                }
                foreach(String s in files)
                {
                    if( !File.Exists(s) )
                        continue;
                    if( !IsPictureFile(s) )
                        continue;
                    //ImportOrderPicture(context, s);
                }
                context.TheLeader.TellTemp("Done.");
            }
            catch
            {
            }
        }
        public void LinkStockItem(System.Windows.Forms.IWin32Window owner)
        {
            MessageBox.Show("reorg");


            //partrecord xPart = LinkedPart;
            //if(xPart != null)
            //{
            //    if( !context.TheLeader.AskYesNo("This line item is already linked to the part '" + xPart.fullpartnumber + "'.  Do you want to re-assign the line item to a different part?") )
            //        return;
            //    if(xPart.StockType == Enums.StockType.Buy && xPart.quantity > 0)
            //    {
            //        xPart.StockType = Enums.StockType.Stock;
            //        xPart.ISave();
            //    }
            //}
            //xPart = partrecord.Choose(owner, this.fullpartnumber);
            //if( xPart == null )
            //    return;
            ////this is not the place to allocate the stock
            //stockid = xPart.unique_id;
            //if(OrderType == Enums.OrderType.Quote || OrderType == Enums.OrderType.Sales)
            //{
            //    //if( unitcost == 0 && xPart.cost != 0 )
            //    //    unitcost = xPart.cost;
            //    //if (xPart.StockType != Enums.StockType.Buy)
            //    //{
            //    //    unitcost = 0;
            //    //    internalcomment = "Stock cost=$" + nTools.MoneyFormat_2_6(xPart.cost) + "  Stock price=$" + nTools.MoneyFormat_2_6(xPart.price);
            //    //}
            //    InferOriginalCost(xPart);
            //}
            //SetPartInfoToOrdDet(xPart);
            //ISave();
            //LinkedPart = xPart;
            //LinkedPart.original_stocktype = LinkedPart.stocktype;
            //LinkedPart.ISave();
            //if (OrderObject != null)
            //    OrderObject.HandleConsignmentPercent(LinkedPart, this);
            //TellUserTemp("The link was created.", Rz3App.xMainForm.TheContextNM);
        }
        public bool HasPartObject()
        {
            return ( LinkedPart != null );
        }

        public Enums.StockType StockType
        {
            get
            {
                return PartObject.ConvertStockType(stocktype);
            }

            set
            {
                stocktype = value.ToString();
            }
        }
        public void BreakLink(ContextNM x)
        {
            if (LinkedPart == null)
            {
                x.TheLeader.Tell("This part does not appear to be linked.");
                return;
            }
            if (!x.TheLeader.AreYouSure("break this link"))
                return;
            //if (Tools.Strings.StrCmp(LinkedPart.original_stocktype, "consign"))
            //    ClearConsignmentInfo();
            LinkedPart = null;
            x.Update(this);
        }
        public void WebRFQ(ContextRz context, System.Windows.Forms.IWin32Window owner, Enums.EmailRFQType rType)
        {
            n_choices xList;    //removed below per Eric
            //emailtemplate xTemplate = emailtemplate.Choose(this, owner);
            emailtemplate xTemplate = emailtemplate.GetById(context, "fd0da9b87333472d82a81f4bfabf23f4");
            if(xTemplate == null)
            {
                xTemplate = emailtemplate.GetByName(context, "QUOTE RFQ");
                if( xTemplate == null )
                    return;
            }
            String strName = "";
            switch(rType)
            {
                case Enums.EmailRFQType.Franchise:
                    strName = "cable_wire_websites";    //franchise_websites
                    break;
                case Enums.EmailRFQType.China:
                    strName = "china_websites";
                    break;
                case Enums.EmailRFQType.Web:
                    strName = "hardware_websites";    //broker_websites
                    break;
                case Enums.EmailRFQType.Preferred:
                    strName = "connector_websites";    //preferred_websites
                    break;
            }
            xList = context.xSys.GetChoicesByName(strName);
            if(xList == null)
            {
                context.TheLeader.Error("Please create a list named '" + strName + "', and try again.");
                return;
            }
            xList.CacheChoiceList(context);
            if( xList.AllChoices.Count <= 0 )
                return;
            String address = context.xUser.email_address;
            String bcc = "";
            foreach(n_choice c in xList.AllChoices)
            {
                if( !Tools.Strings.StrExt(c.name) )
                    continue;
                if( !Tools.Strings.StrExt(address) )
                    address = c.name;
                else
                    bcc += c.name + ";";
            }
            xTemplate.SendGeneralEmail(context, this, address, bcc, "", null, "");
        }      
        public void CopyLineInfo()
        {
            GlobalLineInfo = new ArrayList();
            GlobalLineInfo.Add(this);
        }       

        //Protected Virtual Functions
        protected virtual void ParentDetailCache(ContextRz context)
        {
        }
        protected virtual void ParentDetailAbsorb(ContextRz context, orddet parent)
        {
        }
        //Private Functions
        private bool IsPictureFile(String filepath)
        {
            switch (nTools.GetFileExtention(filepath))
            {
                case "jpg":
                case "jpeg":
                case "bmp":
                case "wmf":
                case "png":
                case "gif":
                    return true;
                default:
                    return false;
            }
        }      
        private String GetFileName(String file)
        {
            String hold = file.Trim().Replace(".pdf", "-pdf.pdf");
            if (hold.Contains(":") && hold.Contains("\\"))
            {
                string[] s = Tools.Strings.Split(hold, "\\");
                hold = s[(s.Length - 1)].Trim();
                s = Tools.Strings.Split(hold, ".");
                hold = s[0];
            }
            return hold;
        }      
        private bool AlreadyQCd(ContextRz context)
        {
            try
            {
                string id = context.SelectScalarString("select unique_id from qualitycontrol where the_orddet_uid = '" + unique_id + "'");
                if (!Tools.Strings.StrExt(id))
                    return false;
                return true;
            }
            catch { }
            return true;
        }        
        private partrecord m_LinkedPart;
        private void PrintLabel()
        {
            throw new NotImplementedException("OrderLine:PrintLabel");
        }
        private void ViewPartObject(ContextRz context)
        {
            partrecord xPart = LinkedPart;
            if(xPart == null)
            {
                context.TheLeader.Tell("The part could not be found.");
                return;
            }
            context.Show(xPart);
        }
        private void AskForSalesLineCancel(ContextRz context)
        {
            context.Logic.AskForSalesLineCancel(this);
        }
        public virtual Enums.OrderLineStatus Status
        {
            get
            {
                try
                {
                    return (Enums.OrderLineStatus)Enum.Parse(typeof(Enums.OrderLineStatus), status.Replace(" ", "_"));
                }
                catch { return Enums.OrderLineStatus.Open; }
            }

            set
            {
                status = StatusConvert(value);
            }
        }
        public static String StatusConvert(Enums.OrderLineStatus s)
        {
            return s.ToString().Replace("_", " ");
        }
        public virtual int LineCodeGet(Enums.OrderType t)
        {
            return 0;
        }
        public virtual void CompanyRefSet(ContextRz context, company companyObject, Enums.OrderType t)
        {
        }
        public virtual void ContactRefSet(ContextRz context, companycontact contactObject, Enums.OrderType t)
        {
        }
        public virtual void AgentRefSet(ContextRz context, n_user userObject, Enums.OrderType t)
        {
        }
        public virtual void OrderDateSet(ContextRz context, DateTime d, Enums.OrderType t)
        {

        }
        public static List<orddet> Listify(List<orddet_line> list)
        {
            List<orddet> ret = new List<orddet>();
            foreach (orddet_line l in list)
            {
                ret.Add(l);
            }
            return ret;
        }
    }
    public class OrderTreeNodeHandle
    {
        public TreeNode MyNode;
        public String HandleType = "";
        public orddet_old xDetail;
        public OrderTreeNodeHandle(String type, orddet_old d)
        {
            HandleType = type;
            xDetail = d;
        }
    }
}