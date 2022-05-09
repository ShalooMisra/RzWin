using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Data;

using Tools;
using Core;
using NewMethod;
using Tools.Database;

namespace Rz5
{
    public class LinkLogic
    {
        public bool activatedCheck = false;
        bool m_activated = false;
        public bool Activated(ContextRz context)
        {
            context.Reorg();
            //if (!activatedCheck)
            //{
            //    m_activated = context.xSys.GetSetting_Boolean("rz_link_active");
            //    activatedCheck = true;
            //}
            return m_activated;
        }

        public bool Export(ContextRz context, ref string msg)
        {
            context.Reorg();
            return false;

            //CompanyInfo companyInfo = GetCompanyInfo(context);
            //if (!IsOnServer(context.xSys.xData))
            //{
            //    context.TheLeader.Comment("This needs to run from the server: " + context.xSys.xData.server_name);
            //    msg = "This needs to run from the server: " + context.xSys.xData.server_name;
            //    return false;
            //}
            //String folder = "";
            //if (Tools.Strings.StrCmp(Environment.MachineName, "LAPTOP07"))
            //    folder = @"c:\Bilge\RzLink\";
            //else
            //{
            //    folder = Tools.Strings.Left(Tools.FileSystem.GetAppPath(), 1) + @":\";
            //    if (!Directory.Exists(folder))
            //    {
            //        context.TheLeader.Comment("No root folder found");
            //        msg = "No root folder found";
            //        return false;
            //    }
            //    folder += @"RzLink\";
            //}
            //if (!Directory.Exists(folder))
            //    Directory.CreateDirectory(folder);
            //String iFile = folder + companyInfo.LinkId + ".infox";
            //String dFile = folder + companyInfo.LinkId + ".x";
            //Tools.FTP.DeleteFile("mike.recognin.com", "RzLink", "RzLink", Path.GetFileName(iFile));
            //Tools.FTP.DeleteFile("mike.recognin.com", "RzLink", "RzLink", Path.GetFileName(dFile));
            //string db = Tools.Strings.FilterTrash(companyInfo.CompanyName) + "_" + companyInfo.LinkId;
            //nStatus.SetProgress(10);
            //if (!LinkLogic.DetachAndRemoveDB(context, db))
            //{
            //    context.TheLeader.Comment("DB: " + db + " could not be removed.");
            //    msg = "DB: " + db + " could not be removed.";
            //    return false;
            //}
            //nStatus.SetProgress(10);
            //Tools.Folder.FolderObliterate(folder);
            //string err = "";
            //if (!context.xSys.xData.CreateDatabaseWithoutChanging(db, ref err, folder))
            //{
            //    context.TheLeader.Comment("xError: " + err);
            //    msg = "xError: " + err;
            //    return false;
            //}
            //Delay();
            //nData d = new nData(2, context.xSys.xData.server_name, db, context.xSys.xData.user_name, context.xSys.xData.user_password);
            //d.GetConnectionString();
            //if (!d.ConnectPossible())
            //{
            //    msg = "Cannot connect to database: " + db;
            //    return false;
            //}
            //nStatus.SetProgress(10);
            //if (!ImportDataToDB(context, d, db))
            //{
            //    msg = "Import failed";
            //    return false;
            //}
            //nStatus.SetProgress(10);
            //string file = Tools.Folder.ConditionFolderName(folder) + companyInfo.LinkId + ".bak";
            //if (!d.Backup(ref file, ref err))
            //{
            //    context.TheLeader.Comment("xError: " + err);
            //    msg = "xError: " + err;
            //    return false;
            //}
            //nStatus.SetProgress(10);
            //if (!DetachAndRemoveDB(context, db))
            //{
            //    context.TheLeader.Comment("DB: " + db + " could not be removed.");
            //    msg = "DB: " + db + " could not be removed.";
            //    return false;
            //}
            //bool ret = true;
            //String zFile = folder + "Upload.zip";
            //if (!Tools.Zip.ZipOneFile(file, zFile))
            //{
            //    context.TheLeader.Error("Zip error");
            //    msg = "Zip error";
            //    return false;
            //}
            //nStatus.SetProgress(10);
            //Tools.Encryption.Encrypt(zFile, dFile, "RzLink");
            //Tools.Files.SaveStringAsFile(iFile + "z", companyInfo.ToString());
            //Tools.Encryption.Encrypt(iFile + "z", iFile, "RzLink");
            //if (Tools.FTP.SendFile("mike.recognin.com", "RzLink", "RzLink", dFile, Path.GetFileName(dFile), null, null, new List<string>()))
            //{
            //    if (Tools.FTP.SendFile("mike.recognin.com", "RzLink", "RzLink", iFile, Path.GetFileName(iFile), null, null, new List<string>()))
            //    {
            //        context.TheLeader.Comment("Data and info sent");
            //        msg = "Data and info sent";
            //        ret = true;
            //    }
            //    else
            //    {
            //        context.TheLeader.Error("Info FTP failed");
            //        msg = "Info FTP failed";
            //        ret = false;
            //    }
            //}
            //else
            //{
            //    context.TheLeader.Error("Data FTP failed");
            //    msg = "Data FTP failed";
            //    ret = false;
            //}
            //nStatus.SetProgress(10);
            //String req = Tools.Strings.DownloadInternetString("http://portal.recognin.com:8086/Import.aspx?id=" + companyInfo.LinkId);
            ////String req = Tools.Strings.DownloadInternetString("http://localhost:50489/Import.aspx?id=" + companyInfo.LinkId);            
            //context.TheLeader.Comment("Import request result: " + req);
            //if (Tools.Strings.StrExt(msg))
            //    msg += " - ";
            //msg += "Import request result: " + req;
            //context.xSys.SetSetting("rz_link_last_result", req);
            //context.xSys.SetSetting_Date("rz_link_last_upload", DateTime.Now);
            //nStatus.SetProgress(10);
            //return ret;
        }
        public static bool DetachAndRemoveDB(ContextRz context, string db)
        {
            context.Reorg();
            return false;

            //if (!context.xSys.xData.DatabaseExists(db))
            //    return true;
            //string msg = "";
            //context.Execute("ALTER DATABASE " + db + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE", false, true, ref msg);
            //if (!context.Execute("DROP DATABASE " + db, false, true, ref msg))
            //    return false;
            //return true;
        }
        private void ImportDataToDB(ContextRz context, DataConnection d, string db)
        {
            //if (context == null)
            //    throw new Exception("No context");
            
            //if (!Tools.Strings.StrExt(db))
            //    throw new Exception("No database name");

            //if (d == null)
            //    throw new Exception("No data");

            ////partrecord
            //d.Execute(GetInventorySQL(context.TheData.DatabaseName, db));
            ////ordhed_invoice
            //d.Execute(GetOrdersSQL(Enums.OrderType.Invoice, context.TheData.DatabaseName, db));
            ////ordhed_purchase
            //d.Execute(GetOrdersSQL(Enums.OrderType.Purchase, context.TheData.DatabaseName, db));
            ////ordhed_rma
            //d.Execute(GetOrdersSQL(Enums.OrderType.RMA, context.TheData.DatabaseName, db));
            ////ordhed_vendrma
            //d.Execute(GetOrdersSQL(Enums.OrderType.VendRMA, context.TheData.DatabaseName, db));
            ////ordhed_quote
            //d.Execute(GetOrdersSQL(Enums.OrderType.Quote, context.TheData.DatabaseName, db));
            ////ordhed_rfq
            //d.Execute(GetOrdersSQL(Enums.OrderType.RFQ, context.TheData.DatabaseName, db));
            ////ordhed_service
            //d.Execute(GetOrdersSQL(Enums.OrderType.Service, context.TheData.DatabaseName, db));
            ////orddet_quote
            //d.Execute(GetOrderDetailSQL(Enums.OrderType.Quote, context.TheData.DatabaseName, db));
            ////orddet_rfq
            //d.Execute(GetOrderDetailSQL(Enums.OrderType.RFQ, context.TheData.DatabaseName, db));
            ////company
            //d.Execute(GetCompanySQL(context.TheData.DatabaseName, db));
            ////orddet_line
            //d.Execute(GetOrderLineSQL(context.TheData.DatabaseName, db));
            ////n_set
            //d.Execute(GetSettingsSQL(context.TheData.DatabaseName, db));
        }

        private bool IsOnServer(DataConnectionSqlServer d)
        {
            if (d == null)
                return false;
            string file = d.ScalarString("select mf.physical_name from sys.dm_io_virtual_file_stats(NULL, NULL) as divfs JOIN sys.master_files as mf on mf.database_id = divfs.database_id AND mf.file_id = divfs.file_id where DB_NAME(mf.database_id) = '" + d.DatabaseName + "' and mf.physical_name like '%mdf'");
            if (!Tools.Strings.StrExt(file))
                return false;
            return Tools.Files.FileExists(file);
        }

        DataTable GetDataTableOrders(ContextRz context, Enums.OrderType type)
        {
            return context.Select("select unique_id, ordernumber, orderdate, companyname, base_company_uid, contactname, base_companycontact_uid, agentname, base_mc_user_uid, shipvia, trackingnumber, terms, orderreference, billingaddress, shippingaddress from ordhed_" + type.ToString().ToLower() + " where isnull(isvoid, 0) = 0 and orderdate > '" + DateTime.Now.Subtract(TimeSpan.FromDays(400)).ToString() + "' order by orderdate");
        }

        DataTable GetDataTableOrderLines(ContextRz context)
        {
            return context.Select("select unique_id, orderid_invoice, orderid_purchase, orderid_rma, orderid_vendrma, ordernumber_invoice, ordernumber_purchase, ordernumber_rma, ordernumber_vendrma, fullpartnumber, quantity from orddet_line where date_created >= '" + DateTime.Now.Subtract(TimeSpan.FromDays(400)).ToString() + "' order by date_created");
        }
        void Delay()
        {
            for (int i = 0; i < 1000000; i++)
            {
                System.Windows.Forms.Application.DoEvents();
            }
        }
        bool Export(ContextRz context, String folder, String name, DataTable table)
        {
            if (!Tools.Data.DataTableExists(table))
            {
                context.TheLeader.Comment("No data for " + name);
                return true;
            }

            StringBuilder sb = new StringBuilder();

            bool first = true;
            foreach (DataColumn c in table.Columns)
            {
                if (!first)
                    sb.Append(",");
                sb.Append(c.Caption);
                first = false;
            }

            String file = folder + name + ".columns";
            Tools.Files.SaveStringAsFile(file, sb.ToString());

            sb = new StringBuilder();

            foreach (DataRow r in table.Rows)
            {
                first = true;
                foreach (DataColumn c in table.Columns)
                {
                    if (!first)
                        sb.Append(",");

                    Object x = r[c.Caption];
                    if (x == null || x == DBNull.Value)
                        sb.Append("\"\"");
                    else
                        sb.Append("\"" + x.ToString().Replace("\r", "").Replace("\n", "|").Replace("\t", "").Replace("\"", "") + "\"");

                    first = false;
                }

                sb.Append("\r\n");
            }

            file = folder + name + ".csv";
            return Tools.Files.SaveStringAsFile(file, sb.ToString());
        }
        private string GetInventorySQL(string from_db, string to_db)
        {
            return "";
            //string types = "";
            //if (Rz4Win.RzCommunitySettings.ShowStock)
            //    types += "'stock'";
            //if (Rz4Win.RzCommunitySettings.ShowConsign)
            //{
            //    if (Tools.Strings.StrExt(types))
            //        types += ",";
            //    types += "'consign'";
            //}
            //if (Rz4Win.RzCommunitySettings.ShowExcess)
            //{
            //    if (Tools.Strings.StrExt(types))
            //        types += ",";
            //    types += "'excess'";
            //}
            //if (!Tools.Strings.StrExt(types))
            //    types = "'stock'";
            //string sql = "select * "; //fullpartnumber, quantity, ";
            ////if (Rz4Win.RzCommunitySettings.ShowManufacturer)
            ////    sql += "manufacturer, ";
            ////else
            ////    sql += "'' as manufacturer, ";
            ////if (Rz4Win.RzCommunitySettings.ShowDateCode)
            ////    sql += "datecode, ";
            ////else
            ////    sql += "'' as datecode, ";
            ////if (Rz4Win.RzCommunitySettings.ShowDescription)
            ////    sql += "description, ";
            ////else
            ////    sql += "'' as description, ";
            ////if (Rz4Win.RzCommunitySettings.ShowCondition)
            ////    sql += "condition,";
            ////else
            ////    sql += "'' as condition, ";
            ////if (Rz4Win.RzCommunitySettings.ShowPackaging)
            ////    sql += "packaging, ";
            ////else
            ////    sql += "'' as packaging, ";
            ////stocktype
            //sql += " into " + to_db + ".dbo.partrecord" + " from " + from_db + ".dbo.partrecord where stocktype in (" + types + ") and len(fullpartnumber) > 3 and quantity > 0";
            //return sql;
        }
        private string GetCompanySQL(string from_db, string to_db)
        {
            return "select * into " + to_db + ".dbo.company" + " from " + from_db + ".dbo.company";
        }
        private string GetOrdersSQL(Enums.OrderType type, string from_db, string to_db)
        {
            return "select * into " + to_db + ".dbo.ordhed_" + type.ToString().ToLower() + " from " + from_db + ".dbo.ordhed_" + type.ToString().ToLower() + " where isnull(isvoid, 0) = 0 and orderdate > '" + DateTime.Now.Subtract(TimeSpan.FromDays(400)).ToString() + "' order by orderdate";
            //return "select unique_id, ordernumber, orderdate, companyname, base_company_uid, contactname, base_companycontact_uid, agentname, base_mc_user_uid, shipvia, trackingnumber, terms, orderreference, billingaddress, shippingaddress into " + to_db + ".dbo.ordhed_" + type.ToString().ToLower() + " from " + from_db + ".dbo.ordhed_" + type.ToString().ToLower() + " where isnull(isvoid, 0) = 0 and orderdate > '" + DateTime.Now.Subtract(TimeSpan.FromDays(400)).ToString() + "' order by orderdate";
        }
        private string GetOrderLineSQL(string from_db, string to_db)
        {
            return "select * into " + to_db + ".dbo.orddet_line from " + from_db + ".dbo.orddet_line where date_created >= '" + DateTime.Now.Subtract(TimeSpan.FromDays(400)).ToString() + "' order by date_created";
            //return "select unique_id, orderid_invoice, orderid_purchase, orderid_rma, orderid_vendrma, ordernumber_invoice, ordernumber_purchase, ordernumber_rma, ordernumber_vendrma, fullpartnumber, quantity, shipvia_invoice, linecode_invoice, ship_date_actual, tracking_invoice, total_price into " + to_db + ".dbo.orddet_line from " + from_db + ".dbo.orddet_line where date_created >= '" + DateTime.Now.Subtract(TimeSpan.FromDays(400)).ToString() + "' order by date_created";
        }
        private string GetOrderDetailSQL(Enums.OrderType type, string from_db, string to_db)
        {
            return "select * into " + to_db + ".dbo.orddet_" + type.ToString().ToLower() + " from " + from_db + ".dbo.orddet_" + type.ToString().ToLower() + " where isnull(isvoid, 0) = 0 and orderdate > '" + DateTime.Now.Subtract(TimeSpan.FromDays(400)).ToString() + "' order by orderdate";
            //return "select unique_id,ordernumber,orderdate,companyname,base_company_uid,contactname,base_companycontact_uid,agentname,base_mc_user_uid,shipvia,vendor_company_uid,vendorid,vendorname,vendorcontactid,vendorcontactname,base_ordhed_uid,fullpartnumber,manufacturer,datecode,condition,leadtime,target_price,target_quantity,delivery,quantityordered,req_uid " + extra + " into " + to_db + ".dbo.orddet_" + type.ToString().ToLower() + " from " + from_db + ".dbo.orddet_" + type.ToString().ToLower() + " where isnull(isvoid, 0) = 0 and orderdate > '" + DateTime.Now.Subtract(TimeSpan.FromDays(400)).ToString() + "' order by orderdate";
        }
        private string GetSettingsSQL(string from_db, string to_db)
        {
            return "select * into " + to_db + ".dbo.n_set from " + from_db + ".dbo.n_set";
        }
        //Private Functions
        private DataTable GetDataTableInventory(ContextNM q)
        {
            q.Reorg();
            return null;

            //string types = "";
            //if (Rz4Win.RzCommunitySettings.ShowStock)
            //    types += "'stock'";
            //if (Rz4Win.RzCommunitySettings.ShowConsign)
            //{
            //    if (Tools.Strings.StrExt(types))
            //        types += ",";
            //    types += "'consign'";
            //}
            //if (Rz4Win.RzCommunitySettings.ShowExcess)
            //{
            //    if (Tools.Strings.StrExt(types))
            //        types += ",";
            //    types += "'excess'";
            //}
            //if (!Tools.Strings.StrExt(types))
            //    types = "'stock'";

            //string sql = "select fullpartnumber, quantity, ";
            //if (Rz4Win.RzCommunitySettings.ShowManufacturer)
            //    sql += "manufacturer, ";
            //else
            //    sql += "'' as manufacturer, ";
            //if (Rz4Win.RzCommunitySettings.ShowDateCode)
            //    sql += "datecode, ";
            //else
            //    sql += "'' as datecode, ";
            //if (Rz4Win.RzCommunitySettings.ShowDescription)
            //    sql += "description, ";
            //else
            //    sql += "'' as description, ";
            //if (Rz4Win.RzCommunitySettings.ShowCondition)
            //    sql += "condition,";
            //else
            //    sql += "'' as condition, ";
            //if (Rz4Win.RzCommunitySettings.ShowPackaging)
            //    sql += "packaging, ";
            //else
            //    sql += "'' as packaging, ";
            //sql += "stocktype from partrecord where stocktype in (" + types + ") and len(fullpartnumber) > 3 and quantity > 0";
            //return q.xSys.xData.GetDataTable(sql, false, true);
        }
        private String CsvFilter(String s)
        {
            s = Tools.Strings.CsvFilter(s);
            if (s.Length > 255)
                s = s.Substring(0, 255);
            return s;
        }
        private CompanyInfo GetCompanyInfo(ContextRz q)
        {
            CompanyInfo c = new CompanyInfo();
            q.Reorg();
            //c.CompanyName = RzApp.OwnerSettings.CompanyName;
            //if (!Tools.Strings.StrExt(c.CompanyName))
            //    c.CompanyName = Tools.Strings.NiceFormat(context.Logic.CompanyIdentifier);
            //if (!Tools.Strings.StrExt(c.CompanyName))
            //    c.CompanyName = "Vendor";
            //c.ContactName = c.CompanyName;
            //c.Phone = RzApp.OwnerSettings.Phone;
            //n_user u = n_user.GetById(q, Rz4Win.RzCommunitySettings.ContactAgent);
            //if (u != null)
            //{
            //    if (Tools.Strings.StrExt(u.name))
            //        c.ContactName = u.name;
            //    if (Tools.Strings.StrExt(u.phone))
            //        c.Phone = u.phone;
            //    c.Email = u.email_address;
            //}
            //c.LinkId = RzLinkId(q);
            return c;
        }

        bool linkChecked = false;
        String m_Link;
        public virtual string RzLinkId(ContextRz context)
        {
            context.Reorg();
            //if (!linkChecked)
            //{
            //    m_Link = context.xSys.GetSetting("rz_link_id");
            //    if (!Tools.Strings.StrExt(m_Link))
            //    {
            //        m_Link = Tools.Strings.GetNewID();
            //        context.xSys.SetSetting("rz_link_id", m_Link);
            //    }
   
            //    linkChecked = true;
            //}
            return m_Link;
        }

        public String LinkUrl(ContextRz context)
        {
            //return "http://localhost:50489/Default.aspx?id=" + RzLinkId(context);
            return "http://portal.recognin.com:8086/Default.aspx?id=" + RzLinkId(context);
        }

        //Private Classes
        public class CompanyInfo
        {
            //Public Variables
            public string CompanyName = "";
            public string ContactName = "";
            public string Phone = "";
            public string Email = "";
            public string LinkId = "";
            public string CompanyNameFiltered
            {
                get
                {
                    return Tools.Strings.FilterTrash(CompanyName);
                }
            }
            public string DatabaseName
            {
                get
                {
                    return CompanyNameFiltered + "_" + LinkId;
                }
            }

            public CompanyInfo()
            {

            }
            public CompanyInfo(String s)
            {
                List<String> strings = Tools.Strings.SplitLinesList(s);
                foreach (String st in strings)
                {
                    String key = Tools.Strings.ParseDelimit(st, ":", 1);
                    String value = Tools.Strings.ParseDelimit(st, ":", 2);

                    switch (key)
                    {
                        case "Id":
                            LinkId = value;
                            break;
                        case "CompanyName":
                            CompanyName = value;
                            break;
                        case "ContactName":
                            ContactName = value;
                            break;
                        case "Phone":
                            Phone = value;
                            break;
                        case "Email":
                            Email = value;
                            break;
                    }
                }
            }
            //Public Override Functions
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Id:" + LinkId);
                sb.AppendLine("CompanyName:" + CompanyName);
                sb.AppendLine("ContactName:" + ContactName);
                sb.AppendLine("Phone:" + Phone);
                sb.AppendLine("Email:" + Email);
                return sb.ToString();
            }
        }
    }
}
