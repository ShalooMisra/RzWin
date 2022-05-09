using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.IO;
using System.Drawing;

using Core;
using NewMethod;

namespace Rz5
{
    public partial class qualitycontrol : qualitycontrol_auto, IPartObject
    {
        public Boolean IsFullyReceived = false;


        //Public Override Functions
        public override void HandleAction(ActArgs args)
        {
            switch (args.ActionName.ToLower())
            {
                default:
                    base.HandleAction(args);
                    break;
            }
        }

        public override void Inserting(Context x)
        {
            
            PartObject.ParsePartNumber(this);
            agentname = ((ContextRz)x).xUser.name;
            the_n_user_uid = ((ContextRz)x).xUser.unique_id;
            grid_color = GridColorCalc(x);
            base.Inserting(x);
        }

        public override void Updating(Context x)
        {
            PartObject.ParsePartNumber(this);
            grid_color = GridColorCalc(x);

            tier_1_pass = true;
            if (photos_include_leads || photos_in_box || pre_photo_weight || photo_package_damage || passed_option || lead_free_pass)
                tier_1_pass = false;

            tier_2_pass = true;
            if (datasheet_analysis || datecode_match || good_country_of_origin)
                tier_2_pass = false;

            base.Updating(x);
        }
        //Public Functions
        public ordhed GetOrderObject()
        {           
            //return ordhed.GetByID(xSys, GetOrderDetailObject().base_ordhed_uid);
            return null;
        }

        public orddet GetOrderDetailObject(ContextRz context)
        {
            return orddet.GetById(context, the_orddet_uid);
        }
        public company GetCompanyObject(ContextRz context)
        {
            return company.GetById(context, the_company_uid);
        }
        public companycontact GetCompanyContactObject(ContextRz context)
        {
            return companycontact.GetById(context, the_companycontact_uid);
        }
        public partrecord GetPartRecordObject(ContextRz context)
        {
            return partrecord.GetById(context, the_partrecord_uid);
        }
      

        void PicReplaceWord(ContextRz context, String doc_folder, String desc, String index, ref String doc, String image_name)
        {
            partpicture p = null;
            string file = doc_folder + @"word\media\" + image_name + ".jpg";

            if (!File.Exists(file))
                file = doc_folder + @"word\media\" + image_name + ".jpeg";
            
            if (!File.Exists(file))
                return;

            p = (partpicture)context.QtO("partpicture", "select top 1 * from partpicture where the_qualitycontrol_uid = '" + unique_id + "' and description like '" + desc + "_%'", context.Logic.PictureData);

            if (!File.Exists(file))
                return;

            File.Delete(file);

            int width = 229;
            int height = 172;

            if (p != null)
            {
                p.LoadPictureData(context);
                p.SizeCheck(context);

                Image original = p.GetPictureImage(context);
                Image isize = null;
                if( original.Width <= width && original.Height <= height )
                    isize = original;
                else
                {
                    if( original.Width > original.Height )
                        isize = Tools.Picture.GetThumbnailScaleWidth(original, width);
                    else
                        isize = Tools.Picture.GetThumbnailScaleHeight(original, height);
                }
                isize.Save(file, System.Drawing.Imaging.ImageFormat.Jpeg);
                isize.Dispose();
                isize = null;
                //p.SaveDataAsJpg(, width, height);
                doc = doc.Replace("qc_image_" + index + "_description", Tools.Xml.EncodeForXml(p.description));
            }
            else
            {
                doc = doc.Replace("qc_image_" + index + "_description", "");
                try
                {
                    Image i2 = new Bitmap(width, height);
                    Graphics g = Graphics.FromImage(i2);
                    g.Clear(Color.White);
                    g.Dispose();
                    g = null;                            
                    i2.Save(file, System.Drawing.Imaging.ImageFormat.Jpeg);
                    i2.Dispose();
                    i2 = null;
                }
                catch { }
            }
        }

        //Private Functions
        private string GetTierExtra(string tier)
        {
            if (!Tools.Strings.StrExt(tier))
                return "";
            StringBuilder sb = new StringBuilder();
            switch (tier.ToLower().Trim())
            {
                case "tier1":
                    //country_of_origin_notes
                    if (country_of_origin_notes.ToLower().Contains("yes"))
                        sb.AppendLine("Tier 1 PASSED\n");
                    else
                        sb.AppendLine("Tier 1 FAILED\n");
                    //if (manufacturer_match)
                    //    sb.AppendLine("Mfg Packaging<br>");
                    //if (good_esd_packaging)
                    //    sb.AppendLine("ESD Pkg<br>");
                    //if (gold_standard)
                    //    sb.AppendLine("Dissecant<br>");
                    //if (barcodes_match)
                    //    sb.AppendLine("Moisture Card<br>");
                    //if (certs_included)
                    //    sb.AppendLine("Mfg Certs Included<br>");
                    //if (photos_include_leads)
                    //    sb.AppendLine("Leads Corrosion<br>");
                    //if (photos_in_box)
                    //    sb.AppendLine("Leads Tinned or Resurface<br>");
                    //if (pre_photo_weight)
                    //    sb.AppendLine("Leads Broken/ Damaged<br>");
                    //if (photo_package_damage)
                    //    sb.AppendLine("Leads Bent<br>");
                    //if (passed_option)
                    //    sb.AppendLine("Leads Insertations<br>");
                    //if (lead_free_pass)
                    //    sb.AppendLine("Leads Oxidation<br>");
                    break;
                case "tier2":
                    if (NoMarking)
                        sb.AppendLine("Warning\n");
                    
                    if( CannotBeDecapsulated )
                        sb.AppendLine("Not Recommended\n");

                    if( IncorrectMfg)
                        sb.AppendLine("Incorrect Mfg\n");

                    if( DoesNotMatchGoldStandard )
                        sb.AppendLine("Does not match Gold Standard\n");

                    if( BaseNumberMfgLogoRevealed )
                        sb.AppendLine("Base Number Mfg Logo Revealed\n");

                    if( BaseNumberOnly )
                        sb.AppendLine("Base Number Only\n");

                    if( SameAsGoldStandard )
                        sb.AppendLine("Same As Gold Standard\n");

                    if( LogoOnly )
                        sb.AppendLine("Logo Only\n");

                    //datasheet_analysis_notes
                    //if (datasheet_analysis_notes.ToLower().Contains("yes"))
                    //    sb.AppendLine("Tier 2 PASSED<br>");
                    //else
                    //    sb.AppendLine("Tier 2 FAILED<br>");
                    //if (calibrations_measured)
                    //    sb.AppendLine("Base number & Mfg Logo Revealed<br>");
                    //if (certs_match)
                    //    sb.AppendLine("Base Number Only<br>");
                    //if (country_match)
                    //    sb.AppendLine("Logo Only<br>");
                    //if (country_notes)
                    //    sb.AppendLine("Same as Gold Standard<br>");
                    //if (datasheet_analysis)
                    //    sb.AppendLine("No Marking<br>");
                    //if (datecode_match)
                    //    sb.AppendLine("Incorrect Mfg<br>");
                    //if (good_country_of_origin)
                    //    sb.AppendLine("Does not match Gold Standard<br>");
                    break;
                case "tier3":
                    //vendor_info_notes
                    //if (vendor_info_notes.ToLower().Contains("yes"))
                    //    sb.AppendLine("Tier 3 PASSED<br>");
                    //else
                    //    sb.AppendLine("Tier 3 FAILED<br>");
                    if( pin_correlation )
                        sb.AppendLine("PIN CORRELATION: This test correlates the sample pins to the standard or datasheet (Vcc, Gnd, NC,I/0,ect.)\n\n");

                    if( datasheet_verification )
                        sb.AppendLine("DATASHEET VERIFICATION:  This test measures key or unique values as specified by the datasheet.\n\n");

                    if( functional )
                        sb.AppendLine("FUNCATIONAL:  This tests the functionality of the device as expected or specified.\n\n");

                    if( dc_electrical )
                        sb.AppendLine("BASIC DC ELECTRICAL:  This tests the basic DC parametrics of the device.\n\n");

                    break;
                default:
                    break;
            }
            return sb.ToString();
        }
        private String GetPassFail(bool pass)
        {
            if (pass)
                return "<font color=\"green\"><b>PASS</b></font>";
            else
                return "<font color=\"red\"><b>FAIL</b></font>";
        }

        private String GetPassFailWord(bool pass)
        {
            if (pass)
                return "PASS";
            else
                return "FAIL";
        }

        private String GetTextResponse(string var)
        {
            switch (var)
            {
                case "pin_correlation":
                    if (pin_correlation)
                        return "This test correlates the sample pins to the standard or datasheet (Vcc, Gnd, NC,I/0,ect.)";
                    else
                        return "";
                case "datasheet_verification":
                    if (datasheet_verification)
                        return "This test measures key or unique values as specified by the datasheet.";
                    else
                        return "";
                case "functional":
                    if (functional)
                        return "This tests the functionality of the device as expected or specified.";
                    else
                        return "";
                case "dc_electrical":
                    if (dc_electrical)
                        return "This tests the basic DC parametrics of the device.";
                    else
                        return "";
                default:
                    return "";
            }
        }
       
        private bool NoMarking
        {
            get
            {
                return datasheet_analysis;
            }
        }

        private bool CannotBeDecapsulated
        {
            get
            {
                return false;
            }
        }

        private bool IncorrectMfg
        {
            get
            {
                return datecode_match;
            }
        }


        private bool DoesNotMatchGoldStandard
        {
            get
            {
                return good_country_of_origin;
            }
        }


        private bool BaseNumberMfgLogoRevealed
        {
            get
            {
                return calibrations_measured;
            }
        }

        private bool BaseNumberOnly
        {
            get
            {
                return certs_match;
            }
        }


        private bool SameAsGoldStandard
        {
            get
            {
                return country_notes;
            }
        }


        private bool LogoOnly
        {
            get
            {
                return country_match;
            }
        }

        public bool GrabExtraInfo(ContextNM context)
        {
            context.TheLeader.Error("reorg");
            return false;

            //if (!Tools.Strings.StrExt(fullpartnumber) || !Tools.Strings.StrExt(po_number))
            //{
            //    orddet d = GetOrderDetailObject();

            //    if (d != null)
            //    {
            //        fullpartnumber = d.fullpartnumber;

            //        if (!Tools.Strings.StrExt(po_number))
            //            po_number = d.ordernumber;

            //        if (!Tools.Strings.StrExt(po_number))
            //            po_number = d.ordernumber;

            //        if (!Tools.Strings.StrExt(vendor_name))
            //            vendor_name = d.companyname;

            //        return true;
            //    }
            //    else
            //        return false;
            //}
            //else
            //    return false;
        }
    }
}
