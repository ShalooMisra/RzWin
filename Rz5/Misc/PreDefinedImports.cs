//using System;
//using System.Collections.Generic;
//using System.Text;
//using NewMethod;
//using Tools.Database;

//namespace Rz4
//{
//    public class PreDefinedImports
//    {
//        public static bool ImportUsersFromHT(ContextNM x, n_data_target t)
//        {
//            nDataTable dtUser = new nDataTable(x.xSys.xData);
//            String strSQL = "select spi as user_code, spi as user_initials, sp as name, email as email_address from salespeople where sp > ''";
//            t.command_string = strSQL;
//            dtUser.ImportFromSQL(t);
//            dtUser.MatchWithClass("n_user", x.xSys);

//            if (n_user.Import(x.xSys, dtUser))
//            {
//                context.TheLeader.Tell("Done.");
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }
//        public static bool ImportCompaniesFromSDS(ContextNM x, n_data_target t)
//        {
//            nDataTable dtCompany = new nDataTable(x.xSys.xData);
//            String strSQL = "select companyno as companycode, salesman as user_code, company as companyname, class as companytype, phone1 as primaryphone, fax1 as primaryfax, email1 as primaryemailaddress, webpage as primaryurl, created as datecreated, salesrep as agentname, customerterms as termsascustomer, vendorterms as termsasvendor, taxid from companies where isnull(company, '') > '' order by company";
//            t.command_string = strSQL;
//            dtCompany.ImportFromSQL(t);
//            dtCompany.MatchWithClass("company", x.xSys);

//            nDataTable dtContact = new nDataTable(x.xSys.xData);
//            strSQL = "select companyno as companycode, LTRIM(RTRIM(isnull(firstname, '') + ' ' + isnull(lastname, ''))) as contactname, title as jobtype, phone as primaryphone, extension as primaryphoneext, fax as primaryfax, email as primaryemailaddress from contacts where isnull(companyno, 0) > 0";
//            t.command_string = strSQL;
//            dtContact.ImportFromSQL(t);
//            dtContact.MatchWithClass("companycontact", x.xSys);
//            dtContact.RenameFieldByIndex(0, "companycode");

//            nDataTable dtAddress = new nDataTable(x.xSys.xData);
//            strSQL = "select companyno as companycode, description, address1 as line1, address2 as line2, address3 as line3, city as adrcity, state as adrstate, zip as adrzip, country as adrcountry, defaultbilling as isdefaultbilling, defaultshipping as isdefaultshipping from companyaddress where isnull(companyno, 0) > 0";
//            t.command_string = strSQL;
//            dtAddress.ImportFromSQL(t);
//            dtAddress.MatchWithClass("companyaddress", x.xSys);
//            dtAddress.RenameFieldByIndex(0, "companycode");

//            if (company.Import(x, dtCompany, "companycode", dtContact, "companycode", dtAddress, "companycode", "user_code"))
//            {
//                context.TheLeader.Tell("Done.");
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }
//        public static bool ImportCompaniesFromSolomon(ContextNM x, n_data_target t)
//        {
//            throw new NotImplementedException("ImportCompaniesFromSolomon");
//            return false;

//            nDataTable dtCompany = new nDataTable(x.xSys.xData);
//            String strSQL = "select custid as companycode, name as companyname, phone as primaryphone, fax as primaryfax, emailaddr as primaryemailaddress, slsperid as agentname, from customer where name > ''";
//            t.command_string = strSQL;
//            dtCompany.ImportFromSQL(t);
//            dtCompany.MatchWithClass("company", x.xSys);

//            nDataTable dtContact = new nDataTable(x.xSys.xData);
//            strSQL = "select companyno as companycode, LTRIM(RTRIM(isnull(firstname, '') + ' ' + isnull(lastname, ''))) as contactname, title as jobtype, phone as primaryphone, extension as primaryphoneext, fax as primaryfax, email as primaryemailaddress from contacts where isnull(companyno, 0) > 0";
//            t.command_string = strSQL;
//            dtContact.ImportFromSQL(t);
//            dtContact.MatchWithClass("companycontact", x.xSys);
//            dtContact.RenameFieldByIndex(0, "companycode");

//            nDataTable dtAddress = new nDataTable(x.xSys.xData);
//            strSQL = "select companyno as companycode, description, address1 as line1, address2 as line2, address3 as line3, city as adrcity, state as adrstate, zip as adrzip, country as adrcountry, defaultbilling as isdefaultbilling, defaultshipping as isdefaultshipping from companyaddress where isnull(companyno, 0) > 0";
//            t.command_string = strSQL;
//            dtAddress.ImportFromSQL(t);
//            dtAddress.MatchWithClass("companyaddress", x.xSys);
//            dtAddress.RenameFieldByIndex(0, "companycode");

//            if (company.Import(x, dtCompany, "companycode", dtContact, "companycode", dtAddress, "companycode", ""))
//            {
//                context.TheLeader.Tell("Done.");
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }
//        public static bool ImportCompaniesFromHT(ContextNM x, n_data_target t)
//        {
//            nDataTable dtCompany = new nDataTable(x.xSys.xData);
//            String strSQL = "select custcode as companycode, salesman as user_code, name as companyname, phone as primaryphone, terms as termsascustomer, custcomment as description, shipdefault as contactmethod, fax as primaryfax, email as primaryemailaddress, cinfo as notetext from customer where isnull(name, '') > ''";
//            t.command_string = strSQL;
//            dtCompany.ImportFromSQL(t);
//            dtCompany.MatchWithClass("company", x.xSys);
//            dtCompany.RenameFieldByIndex(1, "user_code");

//            nDataTable dtContact = null;
//            //nDataTable dtContact = new nDataTable(Rz3App.xSys.xData);
//            //strSQL = "select companyno as companycode, LTRIM(RTRIM(isnull(firstname, '') + ' ' + isnull(lastname, ''))) as contactname, title as jobtype, phone as primaryphone, extension as primaryphoneext, fax as primaryfax, email as primaryemailaddress from contacts where isnull(companyno, 0) > 0";
//            //t.command_string = strSQL;
//            //dtContact.ImportFromSQL(t);
//            //dtContact.MatchWithClass("companycontact", Rz3App.xSys);
//            //dtContact.RenameFieldByIndex(0, "companycode");

//            nData xd = new nData(t);
//            nDataTable dtAddress = new nDataTable(x.xSys.xData);

//            strSQL = "drop table temp_rz_address";
//            xd.Execute(strSQL, true);

//            strSQL = "create table temp_rz_address( custcode varchar(255), description varchar(255), isdefaultbilling bit, isdefaultshipping bit, line1 varchar(255), line2 varchar(255), line3 varchar(255), adrcity varchar(255), adrstate varchar(255), adrzip varchar(255), adrcountry varchar(255))";
//            if (!xd.Execute(strSQL))
//                return false;

//            strSQL = "insert into temp_rz_address select custcode as companycode, 'Billing' as description, 1 as isdefaultbilling, 0 as isdefaultshipping, billst as line1, billst2 as line2, LTRIM(RTRIM(isnull(billst3, '') + ' ' + isnull(billst4, ''))) as line3, billcity as adrcity, billstat as adrstate, billzip as adrzip, billextr as adrcountry from customer where ( isnull(billst, '') > '' or isnull(billst2, '') > '' ) ";
//            if (!xd.Execute(strSQL))
//                return false;

//            strSQL = "insert into temp_rz_address select custcode as companycode, 'Shipping' as description, 0 as isdefaultbilling, 1 as isdefaultshipping, left(shipst, 50) as line1, left(shipst2, 50) as line2, left(LTRIM(RTRIM(isnull(shipst3, '') + ' ' + isnull(shipst4, ''))), 50) as line3, left(shipcity, 50) as adrcity, left(shipstat, 50) as adrstate, left(shipzip, 50) as adrzip, '' as adrcountry from customer where ( isnull(shipst, '') > '' or isnull(shipst2, '') > '' )";
//            if (!xd.Execute(strSQL))
//                return false;

//            strSQL = "select * from temp_rz_address";

//            t.command_string = strSQL;
//            dtAddress.ImportFromSQL(t);
//            dtAddress.MatchWithClass("companyaddress", x.xSys);
//            dtAddress.RenameFieldByIndex(0, "companycode");

//            if (!company.Import(x, dtCompany, "companycode", dtContact, "companycode", dtAddress, "companycode", "user_code"))
//                return false;

//            nDataTable dtVendor = new nDataTable(x.xSys.xData);
//            strSQL = "select vendcode as legacyid, vname as companyname, isnull(st1, '') + ' - ' + isnull(st2, '') + ' - ' + isnull(st3, '') + ' - ' + isnull(st4, '') + ' - ' + isnull(cinfo, '') as notetext, country as country, phone as primaryphone, fax as primaryfax, contacts as primarycontact, comment as internalcomment, terms as termsasvendor from [vendor info]";
//            t.command_string = strSQL;
//            dtVendor.ImportFromSQL(t);
//            dtVendor.MatchWithClass("company", x.xSys);
//            return company.Import(dtVendor, "", "");
//        }
//        public static bool ImportInvoicesFromSDS(ContextNM x, n_data_target t)
//        {
//            x.Reorg();
//            return false;
//            //nDataTable dtHeader = new nDataTable(x.xSys.xData);
//            //String strSQL = "select companyno as companycode, invoiceno as ordercode, RIGHT('000000' + cast(invoiceno as varchar(50)), 6) as ordernumber,  invoicedate as orderdate, shipto as shippingaddress, salesrep as agentname, shipdate as dockdate, comments as internalcomment, shipvia as shipvia, shippingcharge as shippingamount, customerpo as orderreference, trackingno as trackingnumber, 'Invoice' as ordertype from invoices where isnull(companyno, 0) > 0";
//            //t.command_string = strSQL;
//            //dtHeader.ImportFromSQL(t);
//            //dtHeader.MatchWithClass("ordhed", x.xSys);
//            //dtHeader.RenameFieldByIndex(0, "companycode");
//            //dtHeader.RenameFieldByIndex(1, "ordercode");

//            //nDataTable dtDetail = new nDataTable(x.xSys.xData);
//            //strSQL = "select invoiceno as ordercode, qty as quantityordered, qty as quantityfilled, price as unitprice, isnull(prefix, '') + isnull(partnumber, '') as fullpartnumber, customerpn as alternatepart, mfr as manufacturer, datecode, package as packaging, physpkg as partsetup, condition as condition, 'Invoice' as ordertype, 1 as isselected from invoiceitems where isnull(invoiceno, 0) > 0";
//            //t.command_string = strSQL;
//            //dtDetail.ImportFromSQL(t);
//            //dtDetail.MatchWithClass("orddet", x.xSys);
//            //dtDetail.RenameFieldByIndex(0, "ordercode");

//            //if (ordhed.Import(x, dtHeader, "ordercode", "companycode", dtDetail, "ordercode", Enums.OrderType.Invoice))
//            //{
//            //    context.TheLeader.Tell("Done.");
//            //    return true;
//            //}
//            //else
//            //{
//            //    return false;
//            //}
//        }
//        public static bool ImportInvoicesFromSolomon(ContextNM x, n_data_target t)
//        {
//            x.Reorg();
//            return false;
//            //nDataTable dtHeader = new nDataTable(x.xSys.xData);
//            //String strSQL = "select custid as companycode, ordnbr as ordercode, custordnbr as orderreference, billname as companyname, orddate as orderdate, MAX(shipattn + ' / ' + shipaddr1 + ' / ' + ShipAddr2 + ' / ' + ShipCity + ' / ' + ShipState + ' / ' + ShipZip + ' / ' + ShipCountry) as shippingaddress, ordnbr as ordernumber, 'invoice' as ordertype, MAX(termsid) as terms, MAX(CAST(snote.snotetext AS VARCHAR(255))) as internalcomment, slsperid as agentname from soshipheader left join sNote on snote.stablename = 'soshipheader' and sNote.nid = soshipheader.noteid where ordnbr > '' GROUP BY custid, ordnbr, custordnbr, billname, orddate, slsperid order by ordernumber";
//            //t.command_string = strSQL;
//            //dtHeader.ImportFromSQL(t);
//            //dtHeader.MatchWithClass("ordhed", x.xSys);
//            //dtHeader.RenameFieldByIndex(0, "companycode");
//            //dtHeader.RenameFieldByIndex(1, "ordercode");

//            //nDataTable dtDetail = new nDataTable(x.xSys.xData);
//            //strSQL = "select ordnbr as ordercode, invtid as fullpartnumber, qtyord as quantityordered, qtyship as quantityfilled, slsprice as unitprice, 'invoice' as ordertype, 1 as isselected, cost as unitcost from soshipline where ordnbr > ''";
//            //t.command_string = strSQL;
//            //dtDetail.ImportFromSQL(t);
//            //dtDetail.MatchWithClass("orddet", x.xSys);
//            //dtDetail.RenameFieldByIndex(0, "ordercode");

//            //if (ordhed.Import(x, dtHeader, "ordercode", "companycode", dtDetail, "ordercode", Enums.OrderType.Invoice))
//            //{
//            //    context.TheLeader.Tell("Done.");
//            //    return true;
//            //}
//            //else
//            //{
//            //    return false;
//            //}
//        }
//        public static bool ImportInvoicesFromHT(ContextNM x, n_data_target t)
//        {
//            x.Reorg();
//            return false;
//            //nDataTable dtHeader = new nDataTable(x.xSys.xData);
//            //String strSQL = "select custcode as companycode, orderno as ordercode, RIGHT('000000' + Cast(orderno as varchar(255)), 6) as ordernumber, purchord as orderreference, orderdate as orderdate, shipvia as shipvia, comment as internalcomment, buyer as contactname, 'Invoice' as ordertype from orders";
//            //t.command_string = strSQL;
//            //dtHeader.ImportFromSQL(t);
//            //dtHeader.MatchWithClass("ordhed", x.xSys);
//            //dtHeader.RenameFieldByIndex(0, "companycode");
//            //dtHeader.RenameFieldByIndex(1, "ordercode");

//            //nDataTable dtDetail = new nDataTable(x.xSys.xData);
//            ////strSQL = "select orderno as ordercode, vendor as vendorcode, item as linecode, isnull(partprefix, '') + isnull(partno, '') as fullpartnumber, manufact as manufacturer, purchprice as unitcost, salesprice as unitprice, quantsold as quantityordered, quantsold as quantityfilled, 'Invoice' as ordertype, 1 as isselected from lineitem";
//            //strSQL = "select orderno as ordercode, vendor as vendorcode, item as linecode, isnull(partprefix, '') + isnull(partno, '') as fullpartnumber, manufacturers.manufactur as manufacturer, purchprice as unitcost, salesprice as unitprice, quantsold as quantityordered, quantsold as quantityfilled, 'Invoice' as ordertype, 1 as isselected from lineitem left join manufacturers on manufact  = manufacturers.manfcode";
//            //t.command_string = strSQL;
//            //dtDetail.ImportFromSQL(t);
//            //dtDetail.MatchWithClass("orddet", x.xSys);
//            //dtDetail.RenameFieldByIndex(0, "ordercode");
//            //dtDetail.RenameFieldByIndex(1, "vendorcode");

//            //if (ordhed.Import(x, dtHeader, "ordercode", "companycode", dtDetail, "ordercode", Enums.OrderType.Invoice))
//            //{
//            //    context.TheLeader.Tell("Done.");
//            //    return true;
//            //}
//            //else
//            //{
//            //    return false;
//            //}
//        }
//        public static bool ImportPOsFromSDS(ContextNM x, n_data_target t)
//        {
//            x.Reorg();
//            return false;
//            //nDataTable dtHeader = new nDataTable(x.xSys.xData);
//            //String strSQL = "select companyno as companycode, pono as ordercode, pono as ordernumber, podate as orderdate, shipto as shippingaddress, purchaser as agentname, terms, shipvia, duedate as dockdate, comments as internalcomment, shippingcharge as shippingamount, trackingno as trackingnumber, 'Purchase' as ordertype from POs where isnull(companyno, 0) > 0";
//            //t.command_string = strSQL;
//            //dtHeader.ImportFromSQL(t);
//            //dtHeader.MatchWithClass("ordhed", x.xSys);
//            //dtHeader.RenameFieldByIndex(0, "companycode");
//            //dtHeader.RenameFieldByIndex(1, "ordercode");

//            //nDataTable dtDetail = new nDataTable(x.xSys.xData);
//            //strSQL = "select pono as ordercode, qty as quantityordered, qty as quantityfilled, cost as unitprice, isnull(prefix, '') + isnull(partnumber, '') as fullpartnumber, mfr as manufacturer, datecode, package as packaging, physpkg as partsetup, condition as condition, 'Purchase' as ordertype, 1 as isselected from POItems where isnull(pono, 0) > 0";
//            //t.command_string = strSQL;
//            //dtDetail.ImportFromSQL(t);
//            //dtDetail.MatchWithClass("orddet", x.xSys);
//            //dtDetail.RenameFieldByIndex(0, "ordercode");

//            //if (ordhed.Import(x, dtHeader, "ordercode", "companycode", dtDetail, "ordercode", Enums.OrderType.Purchase))
//            //{
//            //    context.TheLeader.Tell("PO Import Complete");
//            //    return true;
//            //}
//            //else
//            //{
//            //    return false;
//            //}
//        }
//        public static bool ImportPOsFromSolomon(ContextNM x, n_data_target t)
//        {
//            nDataTable dtHeader = new nDataTable(x.xSys.xData);
//            String strSQL = "select vendid as companycode, ponbr as ordercode, vendname as companyname, ponbr as ordernumber, shipvia as shipvia, terms as terms, PODate as orderdate, 'Purchase' as ordertype, buyer as agentname, MAX(CAST(snote.snotetext AS VARCHAR(255))) as internalcomment from purchord left join sNote on snote.stablename = 'purchord' and sNote.nid = purchord.noteid where ponbr > '' group by vendid, ponbr, vendname, shipvia, terms, PODate, buyer order by ponbr";
//            t.command_string = strSQL;
//            dtHeader.ImportFromSQL(t);
//            dtHeader.MatchWithClass("ordhed", x.xSys);
//            dtHeader.RenameFieldByIndex(0, "companycode");
//            dtHeader.RenameFieldByIndex(1, "ordercode");

//            nDataTable dtDetail = new nDataTable(x.xSys.xData);
//            strSQL = "select ponbr as ordercode, invtid as fullpartnumber, qtyord as quantityordered, qtyrcvd as quantityfilled, unitcost as unitprice, 'Purchase' as ordertype, 1 as isselected from purorddet where ponbr > ''";
//            t.command_string = strSQL;
//            dtDetail.ImportFromSQL(t);
//            dtDetail.MatchWithClass("orddet", x.xSys);
//            dtDetail.RenameFieldByIndex(0, "ordercode");

//            if (ordhed.Import(x, dtHeader, "ordercode", "companycode", dtDetail, "ordercode", Enums.OrderType.Purchase))
//            {
//                context.TheLeader.Tell("PO Import Complete");
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }
//        public static bool ImportPOsFromHT(ContextNM x, n_data_target t)
//        {
//            nDataTable dtHeader = new nDataTable(x.xSys.xData);
//            //String strSQL = "select vend as vendorcode, who as user_code, partno as fullpartnumber, mfr as manufacturer, buyp as unitprice, qbuy as quantityordered, qbuy as quantityfilled, [DATE] as orderdate, cpo as orderreference, right('000000' + cast(orderno as varchar(255)), 6) as ordernumber, 'Purchase' as ordertype from view_display_po";
//            String strSQL = "select vend as vendorcode, who as user_code, partno as fullpartnumber, manufacturers.manufactur as manufacturer, buyp as unitprice, qbuy as quantityordered, qbuy as quantityfilled, [DATE] as orderdate, cpo as orderreference, right('000000' + cast(orderno as varchar(255)), 6) as ordernumber, 'Purchase' as ordertype from view_display_po left join manufacturers on mfr  = manufacturers.manfcode";
//            t.command_string = strSQL;
//            dtHeader.ImportFromSQL(t);
//            dtHeader.MatchWithClass("ordhed", x.xSys);
//            dtHeader.RenameFieldByIndex(0, "vendorcode");
//            dtHeader.RenameFieldByIndex(1, "user_code");
//            dtHeader.RenameFieldByIndex(2, "fullpartnumber");
//            dtHeader.RenameFieldByIndex(3, "manufacturer");
//            dtHeader.RenameFieldByIndex(4, "unitprice");
//            dtHeader.RenameFieldByIndex(5, "quantityordered");
//            dtHeader.RenameFieldByIndex(6, "quantityfilled");

//            if (ordhed.Import(dtHeader, Enums.OrderType.Purchase))
//            {
//                context.TheLeader.Tell("PO Import Complete");
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }
//        public static void ImportStockFromHT(ContextNM x, n_data_target t)
//        {
//            DataConnection rd = t.GetAsDataConnection();
//            rd.Execute("drop table temp_inventory", true);
//            nDataTable dt = new nDataTable(x.xSys.xData);
//            String strSQL = "select mp_part_no as fullpartnumber, mfg as temp_manufacturer, quantity, date_code as datecode, loc as location, mycost as cost, value as price, ocode into temp_inventory from inventory";
//            rd.Execute(strSQL);

//            rd.Execute("alter table temp_inventory add manufacturer varchar(255), companyname varchar(255), companycontactname varchar(255), companyphone varchar(255), companyfax varchar(255), companyemailaddress varchar(255)");

//            rd.Execute("update temp_inventory set manufacturer = (select max(manufactur) from manufacturers where manufacturers.manfcode = temp_manufacturer)");

//            rd.Execute("update temp_inventory set companyname = (select max(isnull(vname, '')) from [vendor info] v where v.ocode = temp_inventory.ocode)");

//            rd.Execute("update temp_inventory set companycontactname = (select max(isnull(contacts, '')) from [vendor info] v where v.ocode = temp_inventory.ocode)");

//            rd.Execute("update temp_inventory set companyphone = (select max(isnull(phone, '')) from [vendor info] v where v.ocode = temp_inventory.ocode)");

//            rd.Execute("update temp_inventory set companyfax = (select max(isnull(fax, '')) from [vendor info] v where v.ocode = temp_inventory.ocode)");

//            rd.Execute("update temp_inventory set companyemailaddress = (select max(isnull(email, '')) from [vendor info] v where v.ocode = temp_inventory.ocode)");

//            rd.Execute("alter table temp_inventory drop column temp_manufacturer");

//            rd.Execute("alter table temp_inventory drop column ocode");

//            t.command_string = "select * from temp_inventory";
//            dt.ImportFromSQL(x, t);
//            dt.MatchWithClass(x, "partrecord");
//            PartImportArgs args = new PartImportArgs("partrecord", false);
//            ImportInventory inv = context.Logic.GetImportInventoryLogic(SysRz4.Context);
//            if( inv.ImportParts(dt, Enums.StockType.Stock, null, "", "Original Stock Import: " + nTools.DateFormat(System.DateTime.Now), args) )
//            {
//                TellUserTemp("Stock Import Complete", RzApp.xMainForm.TheContextNM);
//                return;
//            }
//            else
//            {
//                context.TheLeader.Tell("Stock import failed.");
//                return;
//            }
//        }
//        public static void ImportExcessFromHT(ContextNM x, n_data_target t)
//        {
//            DataConnection rd = t.GetAsDataConnection();
//            rd.Execute("drop table temp_blinker", true);
//            nDataTable dt = new nDataTable(x.xSys.xData);
//            String strSQL = "select mp_part_no as fullpartnumber, mfg as temp_manufacturer, quantity, date_code as datecode, avail as datecreated, description as description, comment as internalcomment, loc as location, mycost as cost, ocode into temp_blinker from blinker";
//            rd.Execute(strSQL);

//            rd.Execute("alter table temp_blinker add manufacturer varchar(255), companyname varchar(255), companycontactname varchar(255), companyphone varchar(255), companyfax varchar(255), companyemailaddress varchar(255)");

//            rd.Execute("update temp_blinker set manufacturer = (select max(manufactur) from manufacturers where manufacturers.manfcode = temp_manufacturer)");

//            rd.Execute("update temp_blinker set companyname = (select max(isnull(vname, '')) from [vendor info] v where v.ocode = temp_blinker.ocode)");

//            rd.Execute("update temp_blinker set companycontactname = (select max(isnull(contacts, '')) from [vendor info] v where v.ocode = temp_blinker.ocode)");

//            rd.Execute("update temp_blinker set companyphone = (select max(isnull(phone, '')) from [vendor info] v where v.ocode = temp_blinker.ocode)");

//            rd.Execute("update temp_blinker set companyfax = (select max(isnull(fax, '')) from [vendor info] v where v.ocode = temp_blinker.ocode)");

//            rd.Execute("update temp_blinker set companyemailaddress = (select max(isnull(email, '')) from [vendor info] v where v.ocode = temp_blinker.ocode)");

//            rd.Execute("alter table temp_blinker drop column temp_manufacturer");

//            rd.Execute("alter table temp_blinker drop column ocode");

//            t.command_string = "select * from temp_blinker";
//            dt.ImportFromSQL(t);
//            dt.MatchWithClass("partrecord", x.xSys);

//            PartImportArgs args = new PartImportArgs("partrecord", false);
//            ImportInventory inv = context.Logic.GetImportInventoryLogic(SysRz4.Context);
//            if (inv.ImportParts(dt, Enums.StockType.Excess, null, "", "Original Excess Import: " + nTools.DateFormat(System.DateTime.Now), args))
//            {
//                context.TheLeader.Tell("Excess Import Complete");
//                return;
//            }
//            else
//            {
//                context.TheLeader.Tell("Excess import failed.");
//                return;
//            }
//        }
//        private static void TellUserTemp(string s, ContextNM x)
//        {
//            if (x != null)
//                x.TheLeader.TellTemp(s);
//        }
//    }
//}
