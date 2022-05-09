using System;
using System.Collections.Generic;
using System.Text;
using NewMethod;

namespace Rz5
{
    public partial class UPSWorldship
    {
        //Public Static Variables
        public static String XMLPath(ContextRz context)
        {
            return context.GetSetting("upsworldship_xmlpath");
        }

        public static void XMLPathSet(ContextRz context, String value)
        {
            context.SetSetting("upsworldship_xmlpath", value.Trim());
        }

        public static Boolean UseWorldship(ContextRz context)
        {
            return context.GetSettingBoolean("use_upsworldship");
        }

        public static void UseWorldShipSet(ContextRz context, bool value)
        {
            context.SetSettingBoolean("use_upsworldship", value);
        }

        //Public Static Functions
        public static Boolean SendToUPSWorldship(ordhed o)
        {
            return false;

            //UPSObject u = ShowUPSShipScreen(o);
            //if (u == null)
            //    return false;
            //String XML = GetImportXML(u);
            //if (!Tools.Strings.StrExt(XML))
            //    return false;
            //return WriteOutXML(o.unique_id, XML);
        }
        public static String TranslateShipViaToCode(String s)
        {
            String r = "";
            switch (s.Trim().ToLower())
            {
                case "next day air early am":
                    r = "1DM";
                    break;
                case "next day air":
                    r = "1DA";
                    break;
                case "next day air saver":
                    r = "1DP";
                    break;
                case "2nd day air am":
                    r = "2DM";
                    break;
                case "2nd day air":
                    r = "2DA";
                    break;
                case "3 day select":
                    r = "3DS";
                    break;
                case "ground service":
                    r = "GND";
                    break;
                case "ltl express":
                    r = "FTX";
                    break;
                case "ltl standard":
                    r = "FTS";
                    break;
                case "worldwide express plus":
                    r = "EP";
                    break;
                case "worldwide express":
                    r = "ES";
                    break;
                case "worldwide expedited":
                    r = "EX";
                    break;
                case "standard":
                    r = "ST";
                    break;
                default:
                    r = "GND";
                    break;
            }
            return r;
        }
        public static String TranslateBillingToCode(String s)
        {
            String r = "";
            switch (s.Trim().ToLower())
            {
                case "bill shipper":
                    r = "PP";
                    break;
                case "bill receiver":
                    r = "BR";
                    break;
                default:
                    r = "PP";
                    break;
            }
            return r;
        }
        public static String TranslateCountryToCode(String s)
        {
            String r = "";
            switch (s.Trim().ToLower())
            {
                case "united states":
                    r = "US";
                    break;
                case "canada":
                    r = "CA";
                    break;
                default:
                    r = "US";
                    break;
            }
            return r;
        }
        public static String TranslateStateToCode(String country, String s)
        {
            String r = "";
            switch (country.Trim().ToLower())
            {
                case "canada":
                    r = TranslateCanadianProvinceToCode(s);
                    break;
                default:
                    r = s;
                    break;
            }
            return r;
        }
        public static Boolean UpdateOrderTracking(ordhed o)
        {
            return false;

            //if (o == null)
            //    return false;
            //if (!Tools.Strings.StrExt(o.unique_id))
            //    return false;
            //if (!Tools.Strings.StrExt(XMLPath))
            //    return false;
            //String path = Tools.Folder.ConditionFolderName(XMLPath);
            //String f = Tools.Files.OpenFileAsString(path + "ups_" + o.unique_id + ".Out");
            //if (!Tools.Strings.StrExt(f))
            //    return false;
            //String hold = Tools.Strings.ParseDelimit(Tools.Strings.ParseDelimit(f, "<TrackingNumber>", 2), "</TrackingNumber>", 1).Trim();
            //if (!Tools.Strings.StrExt(hold))
            //    return false;
            //o.trackingnumber = hold;

            //bool b = false;
            //try
            //{
            //    o.ISave();
            //    b = true;
            //}
            //catch
            //{
            //    b = false;
            //}

            //try { System.IO.File.Delete(path + "ups_" + o.unique_id + ".Out"); }
            //catch { }
            //try { System.IO.File.Delete(path + "ups_" + o.unique_id + ".XXX"); }
            //catch { }
            //return b;
        }
        public static Boolean HasUPSTrackingUpdate(ordhed o)
        {
            return false;

            //if (o == null)
            //    return false;
            //if (!Tools.Strings.StrExt(o.unique_id))
            //    return false;
            //if (!Tools.Strings.StrExt(XMLPath))
            //    return false;
            //String path = Tools.Folder.ConditionFolderName(XMLPath);
            //String file = "ups_" + o.unique_id + ".Out";
            //return System.IO.File.Exists(path + file);
        }
        //Private Static Functions
        private static UPSObject ShowUPSShipScreen(ContextRz context, ordhed o)
        {
            context.Reorg();
            return null;

            //if (o == null)
            //    return null;
            //frmUPSWorldShip xForm = new frmUPSWorldShip();
            //if (!xForm.CompleteLoad(o))
            //    return null;
            //xForm.ShowDialog();
            //return xForm.UPS;
        }
        private static String GetImportXML(UPSObject o)
        {
            if (o == null)
                return "";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"WINDOWS-1252\"?>");
            sb.AppendLine("<OpenShipments xmlns=\"x-schema:OpenShipments.xdr\">");
            sb.AppendLine("  <OpenShipment ShipmentOption=\"SC\" ProcessStatus=\"\">");
            sb.AppendLine("    <ShipTo>");
            sb.AppendLine("      " + o.CustomerID);
            sb.AppendLine("      " + o.CompanyOrName);
            sb.AppendLine("      " + o.Attention);
            sb.AppendLine("      " + o.Address1);
            sb.AppendLine("      " + o.Address2);
            sb.AppendLine("      " + o.Address3);
            sb.AppendLine("      " + o.CountryTerritory);
            sb.AppendLine("      " + o.PostalCode);
            sb.AppendLine("      " + o.CityOrTown);
            sb.AppendLine("      " + o.StateProvinceCounty);
            sb.AppendLine("      " + o.Telephone);
            sb.AppendLine("      " + o.FaxNumber);
            sb.AppendLine("      " + o.EmailAddress);
            sb.AppendLine("      " + o.TaxIDNumber);
            sb.AppendLine("      " + o.ReceiverUpsAccountNumber);
            sb.AppendLine("      " + o.LocationID);
            sb.AppendLine("      " + o.ResidentialIndicator);
            sb.AppendLine("    </ShipTo>");
            sb.AppendLine("    <ShipmentInformation>");
            sb.AppendLine("      " + o.VoidIndicator);
            sb.AppendLine("      " + o.ServiceType);
            sb.AppendLine("      " + o.PackageType);
            sb.AppendLine("      " + o.NumberOfPackages);
            sb.AppendLine("      " + o.ShipmentActualWeight);
            sb.AppendLine("      " + o.DescriptionOfGoods);
            sb.AppendLine("      " + o.Reference1);
            sb.AppendLine("      " + o.Reference2);
            sb.AppendLine("      " + o.Reference3);
            sb.AppendLine("      " + o.DocumentOnly);
            sb.AppendLine("      " + o.GoodsNotInFreeCirculation);
            sb.AppendLine("      " + o.SpecialInstructionForShipment);
            sb.AppendLine("      " + o.ShipperNumber);
            sb.AppendLine("      " + o.BillingOption);
            sb.AppendLine("    </ShipmentInformation>");
            sb.AppendLine("  </OpenShipment>");
            sb.AppendLine("</OpenShipments>");
            return sb.ToString();
        }
        private static Boolean WriteOutXML(String id, String XML)
        {
            return false;

            //if (!Tools.Strings.StrExt(XMLPath))
            //    return false;
            //if (!Tools.Strings.StrExt(XML))
            //    return false;
            //try
            //{
            //    String path = Tools.Folder.ConditionFolderName(XMLPath);
            //    String file = "ups_" + id.Trim();
            //    if (!Tools.Files.SaveFileAsString(path + file + ".xml", XML))
            //        return false;
            //    return true;
            //}
            //catch { }
            //return false;
        }
        private static String TranslateCanadianProvinceToCode(String s)
        {
            String r = "";
            switch (s.Trim().ToLower())
            {
                case "alberta":
                    r = "AB";
                    break;
                case "british columbia":
                    r = "BC";
                    break;
                case "manitoba":
                    r = "MB";
                    break;
                case "new brunswick":
                    r = "NB";
                    break;
                case "newfoundland and labrador":
                    r = "NL";
                    break;
                case "northwest territories":
                    r = "NT";
                    break;
                case "nova scotia":
                    r = "NS";
                    break;
                case "nunavut":
                    r = "NU";
                    break;
                case "ontario":
                    r = "ON";
                    break;
                case "prince edward island":
                    r = "PE";
                    break;
                case "quebec":
                    r = "QC";
                    break;
                case "saskatchewan":
                    r = "SK";
                    break;
                case "yukon":
                    r = "YT";
                    break;
                default:
                    r = s;
                    break;
            }
            return r;
        }
    }
    public partial class UPSObject
    {
        //Public Variables
        public String OrderID = "";
        public String CustomerID
        {
            get { return bCustomerID; }
            set
            {
                if (Tools.Strings.StrExt(value))
                    bCustomerID = "<CustomerID>" + value.Substring(0, (value.Length >= 30 ? 30 : value.Length)) + "</CustomerID>";
                else
                    bCustomerID = "<CustomerID />";
            }
        }//30
        public String CompanyOrName
        {
            get { return bCompanyOrName; }
            set
            {
                if (Tools.Strings.StrExt(value))
                    bCompanyOrName = "<CompanyOrName>" + value.Substring(0, (value.Length >= 35 ? 35 : value.Length)) + "</CompanyOrName>";
                else
                    bCompanyOrName = "<CompanyOrName />";
            }
        }//35
        public String Attention
        {
            get { return bAttention; }
            set
            {
                if (Tools.Strings.StrExt(value))
                    bAttention = "<Attention>" + value.Substring(0, (value.Length >= 35 ? 35 : value.Length)) + "</Attention>";
                else
                    bAttention = "<Attention />";
            }
        }//35
        public String Address1
        {
            get { return bAddress1; }
            set
            {
                if (Tools.Strings.StrExt(value))
                    bAddress1 = "<Address1>" + value.Substring(0, (value.Length >= 35 ? 35 : value.Length)) + "</Address1>";
                else
                    bAddress1 = "<Address1 />";
            }
        }//35
        public String Address2
        {
            get { return bAddress2; }
            set
            {
                if (Tools.Strings.StrExt(value))
                    bAddress2 = "<Address2>" + value.Substring(0, (value.Length >= 35 ? 35 : value.Length)) + "</Address2>";
                else
                    bAddress2 = "<Address2 />";
            }
        }//35
        public String Address3
        {
            get { return bAddress3; }
            set
            {
                if (Tools.Strings.StrExt(value))
                    bAddress3 = "<Address3>" + value.Substring(0, (value.Length >= 35 ? 35 : value.Length)) + "</Address3>";
                else
                    bAddress3 = "<Address3 />";
            }
        }//35
        public String CountryTerritory
        {
            get { return bCountryTerritory; }
            set
            {
                if (Tools.Strings.StrExt(value))
                    bCountryTerritory = "<CountryTerritory>" + value.Substring(0, (value.Length >= 50 ? 50 : value.Length)) + "</CountryTerritory>";
                else
                    bCountryTerritory = "<CountryTerritory>United States</CountryTerritory>";
            }
        }//50
        public String PostalCode
        {
            get { return bPostalCode; }
            set
            {
                if (Tools.Strings.StrExt(value))
                    bPostalCode = "<PostalCode>" + value.Substring(0, (value.Length >= 10 ? 10 : value.Length)) + "</PostalCode>";
                else
                    bPostalCode = "<PostalCode />";
            }
        }//10
        public String CityOrTown
        {
            get { return bCityOrTown; }
            set
            {
                if (Tools.Strings.StrExt(value))
                    bCityOrTown = "<CityOrTown>" + value.Substring(0, (value.Length >= 30 ? 30 : value.Length)) + "</CityOrTown>";
                else
                    bCityOrTown = "<CityOrTown />";
            }
        }//30
        public String StateProvinceCounty
        {
            get { return bStateProvinceCounty; }
            set
            {
                if (Tools.Strings.StrExt(value))
                    bStateProvinceCounty = "<StateProvinceCounty>" + value.Substring(0, (value.Length >= 5 ? 5 : value.Length)) + "</StateProvinceCounty>";
                else
                    bStateProvinceCounty = "<StateProvinceCounty />";
            }
        }//5
        public String Telephone
        {
            get { return bTelephone; }
            set
            {
                if (Tools.Strings.StrExt(value))
                {
                    String v = nTools.StripPhoneNumber(value);
                    bTelephone = "<Telephone>" + v.Substring(0, (v.Length >= 15 ? 15 : v.Length)) + "</Telephone>";
                }
                else
                    bTelephone = "<Telephone />";
            }
        }//15
        public String FaxNumber
        {
            get { return bFaxNumber; }
            set
            {
                if (Tools.Strings.StrExt(value))
                {
                    String v = nTools.StripPhoneNumber(value);
                    bFaxNumber = "<FaxNumber>" + v.Substring(0, (v.Length >= 15 ? 15 : v.Length)) + "</FaxNumber>";
                }
                else
                    bFaxNumber = "<FaxNumber />";
            }
        }//15
        public String EmailAddress
        {
            get { return bEmailAddress; }
            set
            {
                if (Tools.Strings.StrExt(value))
                    bEmailAddress = "<EmailAddress>" + value.Substring(0, (value.Length >= 50 ? 50 : value.Length)) + "</EmailAddress>";
                else
                    bEmailAddress = "<EmailAddress />";
            }
        }//50
        public String TaxIDNumber
        {
            get { return bTaxIDNumber; }
            set
            {
                if (Tools.Strings.StrExt(value))
                    bTaxIDNumber = "<TaxIDNumber>" + value.Substring(0, (value.Length >= 15 ? 15 : value.Length)) + "</TaxIDNumber>";
                else
                    bTaxIDNumber = "<TaxIDNumber />";
            }
        }//15
        public String ReceiverUpsAccountNumber
        {
            get { return bReceiverUpsAccountNumber; }
            set
            {
                if (Tools.Strings.StrExt(value))
                    bReceiverUpsAccountNumber = "<ReceiverUpsAccountNumber>" + value.Substring(0, (value.Length >= 10 ? 10 : value.Length)) + "</ReceiverUpsAccountNumber>";
                else
                    bReceiverUpsAccountNumber = "<ReceiverUpsAccountNumber />";
            }
        }//10
        public String LocationID
        {
            get { return bLocationID; }
            set
            {
                if (Tools.Strings.StrExt(value))
                    bLocationID = "<LocationID>" + value.Substring(0, (value.Length >= 10 ? 10 : value.Length)) + "</LocationID>";
                else
                    bLocationID = "<LocationID />";
            }
        }//10
        public String ResidentialIndicator
        {
            get { return bResidentialIndicator; }
            set
            {
                if (Tools.Strings.StrExt(value))
                    bResidentialIndicator = "<ResidentialIndicator>" + value.Substring(0, (value.Length >= 1 ? 1 : value.Length)) + "</ResidentialIndicator>";
                else
                    bResidentialIndicator = "<ResidentialIndicator>0</ResidentialIndicator>";
            }
        }//1
        public String VoidIndicator
        {
            get { return bVoidIndicator; }
            set
            {
                if (Tools.Strings.StrExt(value))
                    bVoidIndicator = "<VoidIndicator>" + value.Substring(0, (value.Length >= 1 ? 1 : value.Length)) + "</VoidIndicator>";
                else
                    bVoidIndicator = "<VoidIndicator />";
            }
        }//1
        public String ServiceType
        {
            get { return bServiceType; }
            set
            {
                if (Tools.Strings.StrExt(value))
                    bServiceType = "<ServiceType>" + value.Substring(0, (value.Length >= 25 ? 25 : value.Length)) + "</ServiceType>";
                else
                    bServiceType = "<ServiceType />";
            }
        }//25
        public String PackageType
        {
            get { return bPackageType; }
            set
            {
                if (Tools.Strings.StrExt(value))
                    bPackageType = "<PackageType>" + value.Substring(0, (value.Length >= 35 ? 35 : value.Length)) + "</PackageType>";
                else
                    bPackageType = "<PackageType>Package</PackageType>";
            }
        }//35
        public String NumberOfPackages
        {
            get { return bNumberOfPackages; }
            set
            {
                if (Tools.Strings.StrExt(value))
                    bNumberOfPackages = "<NumberOfPackages>" + value + "</NumberOfPackages>";
                else
                    bNumberOfPackages = "<NumberOfPackages>1</NumberOfPackages>";
            }
        }
        public String ShipmentActualWeight
        {
            get { return bShipmentActualWeight; }
            set
            {
                if (Tools.Strings.StrExt(value))
                    bShipmentActualWeight = "<ShipmentActualWeight>" + value + "</ShipmentActualWeight>";
                else
                    bShipmentActualWeight = "<ShipmentActualWeight />";
            }
        }
        public String DescriptionOfGoods
        {
            get { return bDescriptionOfGoods; }
            set
            {
                if (Tools.Strings.StrExt(value))
                    bDescriptionOfGoods = "<DescriptionOfGoods>" + value.Substring(0, (value.Length >= 105 ? 105 : value.Length)) + "</DescriptionOfGoods>";
                else
                    bDescriptionOfGoods = "<DescriptionOfGoods>Regular Shipment</DescriptionOfGoods>";
            }
        }//105
        public String Reference1
        {
            get { return bReference1; }
            set
            {
                if (Tools.Strings.StrExt(value))
                    bReference1 = "<Reference1>" + value.Substring(0, (value.Length >= 35 ? 35 : value.Length)) + "</Reference1>";
                else
                    bReference1 = "<Reference1 />";
            }
        }//35
        public String Reference2
        {
            get { return bReference2; }
            set
            {
                if (Tools.Strings.StrExt(value))
                    bReference2 = "<Reference2>" + value.Substring(0, (value.Length >= 35 ? 35 : value.Length)) + "</Reference2>";
                else
                    bReference2 = "<Reference2 />";
            }
        }//35
        public String Reference3
        {
            get { return bReference3; }
            set
            {
                if (Tools.Strings.StrExt(value))
                    bReference3 = "<Reference3>" + value.Substring(0, (value.Length >= 35 ? 35 : value.Length)) + "</Reference3>";
                else
                    bReference3 = "<Reference3 />";
            }
        }//35
        public String DocumentOnly
        {
            get { return bDocumentOnly; }
            set
            {
                if (Tools.Strings.StrExt(value))
                    bDocumentOnly = "<DocumentOnly>" + value.Substring(0, (value.Length >= 1 ? 1 : value.Length)) + "</DocumentOnly>";
                else
                    bDocumentOnly = "<DocumentOnly />";
            }
        }//1
        public String GoodsNotInFreeCirculation
        {
            get { return bGoodsNotInFreeCirculation; }
            set
            {
                if (Tools.Strings.StrExt(value))
                    bGoodsNotInFreeCirculation = "<GoodsNotInFreeCirculation>" + value.Substring(0, (value.Length >= 1 ? 1 : value.Length)) + "</GoodsNotInFreeCirculation>";
                else
                    bGoodsNotInFreeCirculation = "<GoodsNotInFreeCirculation />";
            }
        }//1
        public String SpecialInstructionForShipment
        {
            get { return bSpecialInstructionForShipment; }
            set
            {
                if (Tools.Strings.StrExt(value))
                    bSpecialInstructionForShipment = "<SpecialInstructionForShipment>" + value.Substring(0, (value.Length >= 69 ? 69 : value.Length)) + "</SpecialInstructionForShipment>";
                else
                    bSpecialInstructionForShipment = "<SpecialInstructionForShipment />";
            }
        }//69
        public String ShipperNumber
        {
            get { return bShipperNumber; }
            set
            {
                if (Tools.Strings.StrExt(value))
                    bShipperNumber = "<ShipperNumber>" + value.Substring(0, (value.Length >= 10 ? 10 : value.Length)) + "</ShipperNumber>";
                else
                    bShipperNumber = "<ShipperNumber />";
            }
        }//10
        public String BillingOption
        {
            get { return bBillingOption; }
            set
            {
                if (Tools.Strings.StrExt(value))
                    bBillingOption = "<BillingOption>" + value.Substring(0, (value.Length >= 20 ? 20 : value.Length)) + "</BillingOption>";
                else
                    bBillingOption = "<BillingOption>PP</BillingOption>";
            }
        }//20

        public String COD
        {
            get { return bCOD; }
            set
            {
                if (Tools.Strings.StrExt(value))
                    bCOD = "<COD>" + value.Substring(0, (value.Length >= 20 ? 20 : value.Length)) + "</COD>";
                else
                    bCOD = "<COD />";
            }
        }//20

        //Private Variables
        private String bCustomerID = "<CustomerID />";
        private String bCompanyOrName = "<CompanyOrName />";
        private String bAttention = "<Attention />";
        private String bAddress1 = "<Address1 />";
        private String bAddress2 = "<Address2 />";
        private String bAddress3 = "<Address3 />";
        private String bCountryTerritory = "<CountryTerritory>United States</CountryTerritory>";
        private String bPostalCode = "<PostalCode />";
        private String bCityOrTown = "<CityOrTown />";
        private String bStateProvinceCounty = "<StateProvinceCounty />";
        private String bTelephone = "<Telephone />";
        private String bFaxNumber = "<FaxNumber />";
        private String bEmailAddress = "<EmailAddress />";
        private String bTaxIDNumber = "<TaxIDNumber />";
        private String bReceiverUpsAccountNumber = "<ReceiverUpsAccountNumber />";
        private String bLocationID = "<LocationID />";
        private String bResidentialIndicator = "<ResidentialIndicator>0</ResidentialIndicator>";
        private String bVoidIndicator = "<VoidIndicator />";
        private String bServiceType = "<ServiceType />";
        private String bPackageType = "<PackageType>Package</PackageType>";
        private String bNumberOfPackages = "<NumberOfPackages>1</NumberOfPackages>";
        private String bShipmentActualWeight = "<ShipmentActualWeight />";
        private String bDescriptionOfGoods = "<DescriptionOfGoods>Regular Shipment</DescriptionOfGoods>";
        private String bReference1 = "<Reference1 />";
        private String bReference2 = "<Reference2 />";
        private String bReference3 = "<Reference3 />";
        private String bDocumentOnly = "<DocumentOnly />";
        private String bGoodsNotInFreeCirculation = "<GoodsNotInFreeCirculation />";
        private String bSpecialInstructionForShipment = "<SpecialInstructionForShipment />";
        private String bShipperNumber = "<ShipperNumber />";
        private String bBillingOption = "<BillingOption>PP</BillingOption>";
        private String bCOD = "<COD />";
    }
}
