using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("qualitycontrol")]
    public partial class qualitycontrol_auto : NewMethod.nObject
    {
        static qualitycontrol_auto()
        {
            Item.AttributesCache(typeof(qualitycontrol_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "the_n_user_uid":
                    the_n_user_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_companycontact_uid":
                    the_companycontact_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_company_uid":
                    the_company_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_partrecord_uid":
                    the_partrecord_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_orddet_uid":
                    the_orddet_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "fullpartnumber":
                    fullpartnumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quantityreceived":
                    quantityreceivedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quantitybackordered":
                    quantitybackorderedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "manufacturer":
                    manufacturerAttribute = (CoreVarValAttribute)attr;
                    break;
                case "datecode":
                    datecodeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "condition":
                    conditionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "prefix":
                    prefixAttribute = (CoreVarValAttribute)attr;
                    break;
                case "basenumber":
                    basenumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "basenumberstripped":
                    basenumberstrippedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "companyname":
                    companynameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "contactname":
                    contactnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "packaging":
                    packagingAttribute = (CoreVarValAttribute)attr;
                    break;
                case "alternatepart":
                    alternatepartAttribute = (CoreVarValAttribute)attr;
                    break;
                case "category":
                    categoryAttribute = (CoreVarValAttribute)attr;
                    break;
                case "alternatepartstripped":
                    alternatepartstrippedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "certs_included":
                    certs_includedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "certs_match":
                    certs_matchAttribute = (CoreVarValAttribute)attr;
                    break;
                case "good_package_condition":
                    good_package_conditionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "photo_package_damage":
                    photo_package_damageAttribute = (CoreVarValAttribute)attr;
                    break;
                case "report_package_damage":
                    report_package_damageAttribute = (CoreVarValAttribute)attr;
                    break;
                case "match_vendor_info":
                    match_vendor_infoAttribute = (CoreVarValAttribute)attr;
                    break;
                case "verify_part_number":
                    verify_part_numberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "verify_quantity":
                    verify_quantityAttribute = (CoreVarValAttribute)attr;
                    break;
                case "good_part_packaging":
                    good_part_packagingAttribute = (CoreVarValAttribute)attr;
                    break;
                case "photographed_bad_part_packaging":
                    photographed_bad_part_packagingAttribute = (CoreVarValAttribute)attr;
                    break;
                case "good_esd_packaging":
                    good_esd_packagingAttribute = (CoreVarValAttribute)attr;
                    break;
                case "good_part_sealing":
                    good_part_sealingAttribute = (CoreVarValAttribute)attr;
                    break;
                case "good_package_notes":
                    good_package_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "package_damage_notes":
                    package_damage_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vendor_info_notes":
                    vendor_info_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "part_number_notes":
                    part_number_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quantity_notes":
                    quantity_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "esd_packaging_notes":
                    esd_packaging_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "part_sealing_notes":
                    part_sealing_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "barcodes_match":
                    barcodes_matchAttribute = (CoreVarValAttribute)attr;
                    break;
                case "barcode_notes":
                    barcode_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "good_labeling":
                    good_labelingAttribute = (CoreVarValAttribute)attr;
                    break;
                case "labeling_notes":
                    labeling_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "manufacturer_match":
                    manufacturer_matchAttribute = (CoreVarValAttribute)attr;
                    break;
                case "manufacturer_notes":
                    manufacturer_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "datecode_match":
                    datecode_matchAttribute = (CoreVarValAttribute)attr;
                    break;
                case "datecode_notes":
                    datecode_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "good_country_of_origin":
                    good_country_of_originAttribute = (CoreVarValAttribute)attr;
                    break;
                case "country_of_origin_notes":
                    country_of_origin_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_refurb":
                    is_refurbAttribute = (CoreVarValAttribute)attr;
                    break;
                case "refurb_notes":
                    refurb_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_authentic":
                    is_authenticAttribute = (CoreVarValAttribute)attr;
                    break;
                case "authentic_notes":
                    authentic_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_humidity_controlled":
                    is_humidity_controlledAttribute = (CoreVarValAttribute)attr;
                    break;
                case "humidity_controlled_notes":
                    humidity_controlled_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "check_humidity_status":
                    check_humidity_statusAttribute = (CoreVarValAttribute)attr;
                    break;
                case "photographed_labels":
                    photographed_labelsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "humidity_status_notes":
                    humidity_status_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "photographed_label_notes":
                    photographed_label_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "agentname":
                    agentnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "internalcomment":
                    internalcommentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "has_problem":
                    has_problemAttribute = (CoreVarValAttribute)attr;
                    break;
                case "problem_notes":
                    problem_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "part_package_notes":
                    part_package_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "parts_per_package":
                    parts_per_packageAttribute = (CoreVarValAttribute)attr;
                    break;
                case "lead_free":
                    lead_freeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "lead_free_pass":
                    lead_free_passAttribute = (CoreVarValAttribute)attr;
                    break;
                case "lead_free_na":
                    lead_free_naAttribute = (CoreVarValAttribute)attr;
                    break;
                case "has_test_docs":
                    has_test_docsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "test_performed":
                    test_performedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "qty_tested":
                    qty_testedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "qty_passed":
                    qty_passedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "qty_failed":
                    qty_failedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "initials":
                    initialsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "test_company":
                    test_companyAttribute = (CoreVarValAttribute)attr;
                    break;
                case "pre_photo_weight":
                    pre_photo_weightAttribute = (CoreVarValAttribute)attr;
                    break;
                case "pre_photo_weight_notes":
                    pre_photo_weight_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "photos_in_box":
                    photos_in_boxAttribute = (CoreVarValAttribute)attr;
                    break;
                case "photos_in_box_notes":
                    photos_in_box_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "photos_include_leads":
                    photos_include_leadsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "photos_include_leads_notes":
                    photos_include_leads_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "leaving_photos":
                    leaving_photosAttribute = (CoreVarValAttribute)attr;
                    break;
                case "leaving_photos_notes":
                    leaving_photos_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "processor_name":
                    processor_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "datasheet_analysis":
                    datasheet_analysisAttribute = (CoreVarValAttribute)attr;
                    break;
                case "datasheet_analysis_notes":
                    datasheet_analysis_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ocm_verification":
                    ocm_verificationAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ocm_verification_notes":
                    ocm_verification_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "gold_standard":
                    gold_standardAttribute = (CoreVarValAttribute)attr;
                    break;
                case "gold_standard_notes":
                    gold_standard_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "calibrations_measured":
                    calibrations_measuredAttribute = (CoreVarValAttribute)attr;
                    break;
                case "calibrations_measured_notes":
                    calibrations_measured_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "lot_code_match":
                    lot_code_matchAttribute = (CoreVarValAttribute)attr;
                    break;
                case "lot_code_notes":
                    lot_code_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "country_match":
                    country_matchAttribute = (CoreVarValAttribute)attr;
                    break;
                case "country_notes":
                    country_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "new_option":
                    new_optionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "condition_option":
                    condition_optionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "marking_permanency_option":
                    marking_permanency_optionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "data_sheet_review_option":
                    data_sheet_review_optionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "leads_contact_option":
                    leads_contact_optionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "alteration_option":
                    alteration_optionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "possible_remark_option":
                    possible_remark_optionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "excess_option":
                    excess_optionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "insertion_option":
                    insertion_optionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "maynotbenew_option":
                    maynotbenew_optionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "counterfeit_option":
                    counterfeit_optionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "doesnotmatchdatasheet_option":
                    doesnotmatchdatasheet_optionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "very_poor_quality_option":
                    very_poor_quality_optionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "remark_option":
                    remark_optionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "option_summary":
                    option_summaryAttribute = (CoreVarValAttribute)attr;
                    break;
                case "passed_option":
                    passed_optionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "internal_comment":
                    internal_commentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "tier_1_pass":
                    tier_1_passAttribute = (CoreVarValAttribute)attr;
                    break;
                case "tier_2_pass":
                    tier_2_passAttribute = (CoreVarValAttribute)attr;
                    break;
                case "tier_3_pass":
                    tier_3_passAttribute = (CoreVarValAttribute)attr;
                    break;
                case "use_tier_1":
                    use_tier_1Attribute = (CoreVarValAttribute)attr;
                    break;
                case "use_tier_2":
                    use_tier_2Attribute = (CoreVarValAttribute)attr;
                    break;
                case "use_tier_3":
                    use_tier_3Attribute = (CoreVarValAttribute)attr;
                    break;
                case "pin_correlation":
                    pin_correlationAttribute = (CoreVarValAttribute)attr;
                    break;
                case "datasheet_verification":
                    datasheet_verificationAttribute = (CoreVarValAttribute)attr;
                    break;
                case "functional":
                    functionalAttribute = (CoreVarValAttribute)attr;
                    break;
                case "dc_electrical":
                    dc_electricalAttribute = (CoreVarValAttribute)attr;
                    break;
                case "po_number":
                    po_numberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "service_number":
                    service_numberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vendor_name":
                    vendor_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "packing_slip_date_yn":
                    packing_slip_date_ynAttribute = (CoreVarValAttribute)attr;
                    break;
                case "packing_slip_date_notes":
                    packing_slip_date_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "packing_slip_mfg_yn":
                    packing_slip_mfg_ynAttribute = (CoreVarValAttribute)attr;
                    break;
                case "packing_slip_mfg_notes":
                    packing_slip_mfg_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "packing_slip_cost_yn":
                    packing_slip_cost_ynAttribute = (CoreVarValAttribute)attr;
                    break;
                case "packing_slip_cost_notes":
                    packing_slip_cost_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "packing_slip_ponum_yn":
                    packing_slip_ponum_ynAttribute = (CoreVarValAttribute)attr;
                    break;
                case "packing_slip_ponum_notes":
                    packing_slip_ponum_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "packing_slip_sonum_yn":
                    packing_slip_sonum_ynAttribute = (CoreVarValAttribute)attr;
                    break;
                case "packing_slip_sonum_notes":
                    packing_slip_sonum_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "country_notes_text":
                    country_notes_textAttribute = (CoreVarValAttribute)attr;
                    break;


                //KT Refactored from RzSensible
                case "parts_good_cond":
                    parts_good_condAttribute = (CoreVarValAttribute)attr;
                    break;
                case "parts_good_cond_notes":
                    parts_good_cond_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "qty_amnt_ordered":
                    qty_amnt_orderedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "qty_amnt_ordered_notes":
                    qty_amnt_ordered_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "dc_match_ordered":
                    dc_match_orderedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "dc_match_ordered_notes":
                    dc_match_ordered_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "mfg_match_ordered":
                    mfg_match_orderedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "mfg_match_ordered_notes":
                    mfg_match_ordered_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "cost_match_ordered":
                    cost_match_orderedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "cost_match_ordered_notes":
                    cost_match_ordered_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "pkg_label_auth":
                    pkg_label_authAttribute = (CoreVarValAttribute)attr;
                    break;
                case "pkg_label_auth_notes":
                    pkg_label_auth_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "lot_match_ordered":
                    lot_match_orderedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "lot_match_ordered_notes":
                    lot_match_ordered_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "country_origin_consistent":
                    country_origin_consistentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "country_origin_consistent_notes":
                    country_origin_consistent_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "signs_rework":
                    signs_reworkAttribute = (CoreVarValAttribute)attr;
                    break;
                case "signs_rework_notes":
                    signs_rework_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "pass_acetone":
                    pass_acetoneAttribute = (CoreVarValAttribute)attr;
                    break;
                case "pass_acetone_notes":
                    pass_acetone_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "original_mfg_pkg":
                    original_mfg_pkgAttribute = (CoreVarValAttribute)attr;
                    break;
                case "original_mfg_pkg_notes":
                    original_mfg_pkg_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "pin1_correct_loc":
                    pin1_correct_locAttribute = (CoreVarValAttribute)attr;
                    break;
                case "pin1_correct_loc_notes":
                    pin1_correct_loc_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "micro_sanding":
                    micro_sandingAttribute = (CoreVarValAttribute)attr;
                    break;
                case "micro_sanding_notes":
                    micro_sanding_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "micro_solder":
                    micro_solderAttribute = (CoreVarValAttribute)attr;
                    break;
                case "micro_solder_notes":
                    micro_solder_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "order_meet_criteria":
                    order_meet_criteriaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "order_meet_criteria_notes":
                    order_meet_criteria_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "part_to_be_shipped":
                    part_to_be_shippedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "part_to_be_shipped_notes":
                    part_to_be_shipped_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "parts_nonconfirm_material":
                    parts_nonconfirm_materialAttribute = (CoreVarValAttribute)attr;
                    break;
                case "parts_nonconfirm_material_notes":
                    parts_nonconfirm_material_notesAttribute = (CoreVarValAttribute)attr;
                    break;


            }
        }

        static CoreVarValAttribute the_n_user_uidAttribute;
        static CoreVarValAttribute the_companycontact_uidAttribute;
        static CoreVarValAttribute the_company_uidAttribute;
        static CoreVarValAttribute the_partrecord_uidAttribute;
        static CoreVarValAttribute the_orddet_uidAttribute;
        static CoreVarValAttribute fullpartnumberAttribute;
        static CoreVarValAttribute quantityreceivedAttribute;
        static CoreVarValAttribute quantitybackorderedAttribute;
        static CoreVarValAttribute manufacturerAttribute;
        static CoreVarValAttribute datecodeAttribute;
        static CoreVarValAttribute conditionAttribute;
        static CoreVarValAttribute prefixAttribute;
        static CoreVarValAttribute basenumberAttribute;
        static CoreVarValAttribute basenumberstrippedAttribute;
        static CoreVarValAttribute companynameAttribute;
        static CoreVarValAttribute contactnameAttribute;
        static CoreVarValAttribute packagingAttribute;
        static CoreVarValAttribute alternatepartAttribute;
        static CoreVarValAttribute categoryAttribute;
        static CoreVarValAttribute alternatepartstrippedAttribute;
        static CoreVarValAttribute certs_includedAttribute;
        static CoreVarValAttribute certs_matchAttribute;
        static CoreVarValAttribute good_package_conditionAttribute;
        static CoreVarValAttribute photo_package_damageAttribute;
        static CoreVarValAttribute report_package_damageAttribute;
        static CoreVarValAttribute match_vendor_infoAttribute;
        static CoreVarValAttribute verify_part_numberAttribute;
        static CoreVarValAttribute verify_quantityAttribute;
        static CoreVarValAttribute good_part_packagingAttribute;
        static CoreVarValAttribute photographed_bad_part_packagingAttribute;
        static CoreVarValAttribute good_esd_packagingAttribute;
        static CoreVarValAttribute good_part_sealingAttribute;
        static CoreVarValAttribute good_package_notesAttribute;
        static CoreVarValAttribute package_damage_notesAttribute;
        static CoreVarValAttribute vendor_info_notesAttribute;
        static CoreVarValAttribute part_number_notesAttribute;
        static CoreVarValAttribute quantity_notesAttribute;
        static CoreVarValAttribute esd_packaging_notesAttribute;
        static CoreVarValAttribute part_sealing_notesAttribute;
        static CoreVarValAttribute barcodes_matchAttribute;
        static CoreVarValAttribute barcode_notesAttribute;
        static CoreVarValAttribute good_labelingAttribute;
        static CoreVarValAttribute labeling_notesAttribute;
        static CoreVarValAttribute manufacturer_matchAttribute;
        static CoreVarValAttribute manufacturer_notesAttribute;
        static CoreVarValAttribute datecode_matchAttribute;
        static CoreVarValAttribute datecode_notesAttribute;
        static CoreVarValAttribute good_country_of_originAttribute;
        static CoreVarValAttribute country_of_origin_notesAttribute;
        static CoreVarValAttribute is_refurbAttribute;
        static CoreVarValAttribute refurb_notesAttribute;
        static CoreVarValAttribute is_authenticAttribute;
        static CoreVarValAttribute authentic_notesAttribute;
        static CoreVarValAttribute is_humidity_controlledAttribute;
        static CoreVarValAttribute humidity_controlled_notesAttribute;
        static CoreVarValAttribute check_humidity_statusAttribute;
        static CoreVarValAttribute photographed_labelsAttribute;
        static CoreVarValAttribute humidity_status_notesAttribute;
        static CoreVarValAttribute photographed_label_notesAttribute;
        static CoreVarValAttribute agentnameAttribute;
        static CoreVarValAttribute internalcommentAttribute;
        static CoreVarValAttribute has_problemAttribute;
        static CoreVarValAttribute problem_notesAttribute;
        static CoreVarValAttribute part_package_notesAttribute;
        static CoreVarValAttribute parts_per_packageAttribute;
        static CoreVarValAttribute lead_freeAttribute;
        static CoreVarValAttribute lead_free_passAttribute;
        static CoreVarValAttribute lead_free_naAttribute;
        static CoreVarValAttribute has_test_docsAttribute;
        static CoreVarValAttribute test_performedAttribute;
        static CoreVarValAttribute qty_testedAttribute;
        static CoreVarValAttribute qty_passedAttribute;
        static CoreVarValAttribute qty_failedAttribute;
        static CoreVarValAttribute initialsAttribute;
        static CoreVarValAttribute test_companyAttribute;
        static CoreVarValAttribute pre_photo_weightAttribute;
        static CoreVarValAttribute pre_photo_weight_notesAttribute;
        static CoreVarValAttribute photos_in_boxAttribute;
        static CoreVarValAttribute photos_in_box_notesAttribute;
        static CoreVarValAttribute photos_include_leadsAttribute;
        static CoreVarValAttribute photos_include_leads_notesAttribute;
        static CoreVarValAttribute leaving_photosAttribute;
        static CoreVarValAttribute leaving_photos_notesAttribute;
        static CoreVarValAttribute processor_nameAttribute;
        static CoreVarValAttribute datasheet_analysisAttribute;
        static CoreVarValAttribute datasheet_analysis_notesAttribute;
        static CoreVarValAttribute ocm_verificationAttribute;
        static CoreVarValAttribute ocm_verification_notesAttribute;
        static CoreVarValAttribute gold_standardAttribute;
        static CoreVarValAttribute gold_standard_notesAttribute;
        static CoreVarValAttribute calibrations_measuredAttribute;
        static CoreVarValAttribute calibrations_measured_notesAttribute;
        static CoreVarValAttribute lot_code_matchAttribute;
        static CoreVarValAttribute lot_code_notesAttribute;
        static CoreVarValAttribute country_matchAttribute;
        static CoreVarValAttribute country_notesAttribute;
        static CoreVarValAttribute new_optionAttribute;
        static CoreVarValAttribute condition_optionAttribute;
        static CoreVarValAttribute marking_permanency_optionAttribute;
        static CoreVarValAttribute data_sheet_review_optionAttribute;
        static CoreVarValAttribute leads_contact_optionAttribute;
        static CoreVarValAttribute alteration_optionAttribute;
        static CoreVarValAttribute possible_remark_optionAttribute;
        static CoreVarValAttribute excess_optionAttribute;
        static CoreVarValAttribute insertion_optionAttribute;
        static CoreVarValAttribute maynotbenew_optionAttribute;
        static CoreVarValAttribute counterfeit_optionAttribute;
        static CoreVarValAttribute doesnotmatchdatasheet_optionAttribute;
        static CoreVarValAttribute very_poor_quality_optionAttribute;
        static CoreVarValAttribute remark_optionAttribute;
        static CoreVarValAttribute option_summaryAttribute;
        static CoreVarValAttribute passed_optionAttribute;
        static CoreVarValAttribute internal_commentAttribute;
        static CoreVarValAttribute tier_1_passAttribute;
        static CoreVarValAttribute tier_2_passAttribute;
        static CoreVarValAttribute tier_3_passAttribute;
        static CoreVarValAttribute use_tier_1Attribute;
        static CoreVarValAttribute use_tier_2Attribute;
        static CoreVarValAttribute use_tier_3Attribute;
        static CoreVarValAttribute pin_correlationAttribute;
        static CoreVarValAttribute datasheet_verificationAttribute;
        static CoreVarValAttribute functionalAttribute;
        static CoreVarValAttribute dc_electricalAttribute;
        static CoreVarValAttribute po_numberAttribute;
        static CoreVarValAttribute service_numberAttribute;
        static CoreVarValAttribute vendor_nameAttribute;
        static CoreVarValAttribute packing_slip_date_ynAttribute;
        static CoreVarValAttribute packing_slip_date_notesAttribute;
        static CoreVarValAttribute packing_slip_mfg_ynAttribute;
        static CoreVarValAttribute packing_slip_mfg_notesAttribute;
        static CoreVarValAttribute packing_slip_cost_ynAttribute;
        static CoreVarValAttribute packing_slip_cost_notesAttribute;
        static CoreVarValAttribute packing_slip_ponum_ynAttribute;
        static CoreVarValAttribute packing_slip_ponum_notesAttribute;
        static CoreVarValAttribute packing_slip_sonum_ynAttribute;
        static CoreVarValAttribute packing_slip_sonum_notesAttribute;
        static CoreVarValAttribute country_notes_textAttribute;

        //KT Refactored from RzSensible
        static CoreVarValAttribute parts_good_condAttribute;
        static CoreVarValAttribute parts_good_cond_notesAttribute;
        static CoreVarValAttribute qty_amnt_orderedAttribute;
        static CoreVarValAttribute qty_amnt_ordered_notesAttribute;
        static CoreVarValAttribute dc_match_orderedAttribute;
        static CoreVarValAttribute dc_match_ordered_notesAttribute;
        static CoreVarValAttribute mfg_match_orderedAttribute;
        static CoreVarValAttribute mfg_match_ordered_notesAttribute;
        static CoreVarValAttribute cost_match_orderedAttribute;
        static CoreVarValAttribute cost_match_ordered_notesAttribute;
        static CoreVarValAttribute pkg_label_authAttribute;
        static CoreVarValAttribute pkg_label_auth_notesAttribute;
        static CoreVarValAttribute lot_match_orderedAttribute;
        static CoreVarValAttribute lot_match_ordered_notesAttribute;
        static CoreVarValAttribute country_origin_consistentAttribute;
        static CoreVarValAttribute country_origin_consistent_notesAttribute;
        static CoreVarValAttribute signs_reworkAttribute;
        static CoreVarValAttribute signs_rework_notesAttribute;
        static CoreVarValAttribute pass_acetoneAttribute;
        static CoreVarValAttribute pass_acetone_notesAttribute;
        static CoreVarValAttribute original_mfg_pkgAttribute;
        static CoreVarValAttribute original_mfg_pkg_notesAttribute;
        static CoreVarValAttribute pin1_correct_locAttribute;
        static CoreVarValAttribute pin1_correct_loc_notesAttribute;
        static CoreVarValAttribute micro_sandingAttribute;
        static CoreVarValAttribute micro_sanding_notesAttribute;
        static CoreVarValAttribute micro_solderAttribute;
        static CoreVarValAttribute micro_solder_notesAttribute;
        static CoreVarValAttribute order_meet_criteriaAttribute;
        static CoreVarValAttribute order_meet_criteria_notesAttribute;
        static CoreVarValAttribute part_to_be_shippedAttribute;
        static CoreVarValAttribute part_to_be_shipped_notesAttribute;
        static CoreVarValAttribute parts_nonconfirm_materialAttribute;
        static CoreVarValAttribute parts_nonconfirm_material_notesAttribute;




        [CoreVarVal("the_n_user_uid", "String", TheFieldLength = 255, Caption="The N User Uid", Importance = 1)]
        public VarString the_n_user_uidVar;

        [CoreVarVal("the_companycontact_uid", "String", TheFieldLength = 255, Caption="The Companycontact Uid", Importance = 2)]
        public VarString the_companycontact_uidVar;

        [CoreVarVal("the_company_uid", "String", TheFieldLength = 255, Caption="The Company Uid", Importance = 3)]
        public VarString the_company_uidVar;

        [CoreVarVal("the_partrecord_uid", "String", TheFieldLength = 255, Caption="The Partrecord Uid", Importance = 4)]
        public VarString the_partrecord_uidVar;

        [CoreVarVal("the_orddet_uid", "String", TheFieldLength = 255, Caption="The Orddet Uid", Importance = 5)]
        public VarString the_orddet_uidVar;

        [CoreVarVal("fullpartnumber", "String", TheFieldLength = 255, Caption="Full Partnumber", Importance = 6)]
        public VarString fullpartnumberVar;

        [CoreVarVal("quantityreceived", "Int64", Caption="Quantity Received", Importance = 7)]
        public VarInt64 quantityreceivedVar;

        [CoreVarVal("quantitybackordered", "Int64", Caption="Quantity Backordered", Importance = 8)]
        public VarInt64 quantitybackorderedVar;

        [CoreVarVal("manufacturer", "String", TheFieldLength = 255, Caption="Manufacturer", Importance = 9)]
        public VarString manufacturerVar;

        [CoreVarVal("datecode", "String", TheFieldLength = 255, Caption="Datecode", Importance = 10)]
        public VarString datecodeVar;

        [CoreVarVal("condition", "String", TheFieldLength = 255, Caption="Condition", Importance = 11)]
        public VarString conditionVar;

        [CoreVarVal("prefix", "String", TheFieldLength = 255, Caption="Prefix", Importance = 12)]
        public VarString prefixVar;

        [CoreVarVal("basenumber", "String", TheFieldLength = 255, Caption="Base Number", Importance = 13)]
        public VarString basenumberVar;

        [CoreVarVal("basenumberstripped", "String", TheFieldLength = 255, Caption="Base Number Stripped", Importance = 14)]
        public VarString basenumberstrippedVar;

        [CoreVarVal("companyname", "String", TheFieldLength = 255, Caption="Company Name", Importance = 15)]
        public VarString companynameVar;

        [CoreVarVal("contactname", "String", TheFieldLength = 255, Caption="Contact Name", Importance = 16)]
        public VarString contactnameVar;

        [CoreVarVal("packaging", "String", TheFieldLength = 255, Caption="Packaging", Importance = 17)]
        public VarString packagingVar;

        [CoreVarVal("alternatepart", "String", TheFieldLength = 50, Caption="Alternate Part", Importance = 18)]
        public VarString alternatepartVar;

        [CoreVarVal("category", "String", TheFieldLength = 50, Caption="Category", Importance = 19)]
        public VarString categoryVar;

        [CoreVarVal("alternatepartstripped", "String", TheFieldLength = 255, Caption="Alternatepartstripped", Importance = 20)]
        public VarString alternatepartstrippedVar;

        [CoreVarVal("certs_included", "Boolean", Caption="Certs Included", Importance = 21)]
        public VarBoolean certs_includedVar;

        [CoreVarVal("certs_match", "Boolean", Caption="Certs Match", Importance = 22)]
        public VarBoolean certs_matchVar;

        [CoreVarVal("good_package_condition", "Boolean", Caption="Good Package Condition", Importance = 23)]
        public VarBoolean good_package_conditionVar;

        [CoreVarVal("photo_package_damage", "Boolean", Caption="Photo Package Damage", Importance = 24)]
        public VarBoolean photo_package_damageVar;

        [CoreVarVal("report_package_damage", "Boolean", Caption="Report Package Damage", Importance = 25)]
        public VarBoolean report_package_damageVar;

        [CoreVarVal("match_vendor_info", "Boolean", Caption="Match Vendor Info", Importance = 26)]
        public VarBoolean match_vendor_infoVar;

        [CoreVarVal("verify_part_number", "Boolean", Caption="Verify Part Number", Importance = 27)]
        public VarBoolean verify_part_numberVar;

        [CoreVarVal("verify_quantity", "Boolean", Caption="Verify Quantity", Importance = 28)]
        public VarBoolean verify_quantityVar;

        [CoreVarVal("good_part_packaging", "Boolean", Caption="Good Part Packaging", Importance = 29)]
        public VarBoolean good_part_packagingVar;

        [CoreVarVal("photographed_bad_part_packaging", "Boolean", Caption="Photographed Bad Part Packaging", Importance = 30)]
        public VarBoolean photographed_bad_part_packagingVar;

        [CoreVarVal("good_esd_packaging", "Boolean", Caption="Good Esd Packaging", Importance = 31)]
        public VarBoolean good_esd_packagingVar;

        [CoreVarVal("good_part_sealing", "Boolean", Caption="Good Part Sealing", Importance = 32)]
        public VarBoolean good_part_sealingVar;

        [CoreVarVal("good_package_notes", "String", TheFieldLength = 255, Caption="Good Package Notes", Importance = 33)]
        public VarString good_package_notesVar;

        [CoreVarVal("package_damage_notes", "String", TheFieldLength = 255, Caption="Package Damage Notes", Importance = 34)]
        public VarString package_damage_notesVar;

        [CoreVarVal("vendor_info_notes", "String", TheFieldLength = 255, Caption="Vendor Info Notes", Importance = 35)]
        public VarString vendor_info_notesVar;

        [CoreVarVal("part_number_notes", "String", TheFieldLength = 255, Caption="Part Number Notes", Importance = 36)]
        public VarString part_number_notesVar;

        [CoreVarVal("quantity_notes", "String", TheFieldLength = 255, Caption="Quantity Notes", Importance = 37)]
        public VarString quantity_notesVar;

        [CoreVarVal("esd_packaging_notes", "String", TheFieldLength = 255, Caption="Esd Packaging Notes", Importance = 38)]
        public VarString esd_packaging_notesVar;

        [CoreVarVal("part_sealing_notes", "String", TheFieldLength = 255, Caption="Part Sealing Notes", Importance = 39)]
        public VarString part_sealing_notesVar;

        [CoreVarVal("barcodes_match", "Boolean", Caption="Barcodes Match", Importance = 40)]
        public VarBoolean barcodes_matchVar;

        [CoreVarVal("barcode_notes", "String", TheFieldLength = 255, Caption="Barcode Notes", Importance = 41)]
        public VarString barcode_notesVar;

        [CoreVarVal("good_labeling", "Boolean", Caption="Good Labeling", Importance = 42)]
        public VarBoolean good_labelingVar;

        [CoreVarVal("labeling_notes", "String", TheFieldLength = 255, Caption="Labeling Notes", Importance = 43)]
        public VarString labeling_notesVar;

        [CoreVarVal("manufacturer_match", "Boolean", Caption="Manufacturer Match", Importance = 44)]
        public VarBoolean manufacturer_matchVar;

        [CoreVarVal("manufacturer_notes", "String", TheFieldLength = 255, Caption="Manufacturer Notes", Importance = 45)]
        public VarString manufacturer_notesVar;

        [CoreVarVal("datecode_match", "Boolean", Caption="Datecode Match", Importance = 46)]
        public VarBoolean datecode_matchVar;

        [CoreVarVal("datecode_notes", "String", TheFieldLength = 255, Caption="Datecode Notes", Importance = 47)]
        public VarString datecode_notesVar;

        [CoreVarVal("good_country_of_origin", "Boolean", Caption="Good Country Of Origin", Importance = 48)]
        public VarBoolean good_country_of_originVar;

        [CoreVarVal("country_of_origin_notes", "String", TheFieldLength = 255, Caption="Country Of Origin Notes", Importance = 49)]
        public VarString country_of_origin_notesVar;

        [CoreVarVal("is_refurb", "Boolean", Caption="Is Refurb", Importance = 50)]
        public VarBoolean is_refurbVar;

        [CoreVarVal("refurb_notes", "String", TheFieldLength = 255, Caption="Refurb Notes", Importance = 51)]
        public VarString refurb_notesVar;

        [CoreVarVal("is_authentic", "Boolean", Caption="Is Authentic", Importance = 52)]
        public VarBoolean is_authenticVar;

        [CoreVarVal("authentic_notes", "String", TheFieldLength = 255, Caption="Authentic Notes", Importance = 53)]
        public VarString authentic_notesVar;

        [CoreVarVal("is_humidity_controlled", "Boolean", Caption="Is Humidity Controlled", Importance = 54)]
        public VarBoolean is_humidity_controlledVar;

        [CoreVarVal("humidity_controlled_notes", "String", TheFieldLength = 255, Caption="Humidity Controlled Notes", Importance = 55)]
        public VarString humidity_controlled_notesVar;

        [CoreVarVal("check_humidity_status", "Boolean", Caption="Check Humidity Status", Importance = 56)]
        public VarBoolean check_humidity_statusVar;

        [CoreVarVal("photographed_labels", "Boolean", Caption="Photographed Labels", Importance = 57)]
        public VarBoolean photographed_labelsVar;

        [CoreVarVal("humidity_status_notes", "String", TheFieldLength = 255, Caption="Humidity Status Notes", Importance = 58)]
        public VarString humidity_status_notesVar;

        [CoreVarVal("photographed_label_notes", "String", TheFieldLength = 255, Caption="Photographed Label Notes", Importance = 59)]
        public VarString photographed_label_notesVar;

        [CoreVarVal("agentname", "String", TheFieldLength = 255, Caption="Agentname", Importance = 60)]
        public VarString agentnameVar;

        [CoreVarVal("internalcomment", "Text", Caption="Internal Comment", Importance = 61)]
        public VarText internalcommentVar;

        [CoreVarVal("has_problem", "Boolean", Caption="Has Problem", Importance = 62)]
        public VarBoolean has_problemVar;

        [CoreVarVal("problem_notes", "String", TheFieldLength = 255, Caption="Problem Notes", Importance = 63)]
        public VarString problem_notesVar;

        [CoreVarVal("part_package_notes", "String", TheFieldLength = 255, Caption="Part Package Notes", Importance = 64)]
        public VarString part_package_notesVar;

        [CoreVarVal("parts_per_package", "String", TheFieldLength = 255, Caption="Parts Per Package", Importance = 65)]
        public VarString parts_per_packageVar;

        [CoreVarVal("lead_free", "Boolean", Caption="Lead Free", Importance = 66)]
        public VarBoolean lead_freeVar;

        [CoreVarVal("lead_free_pass", "Boolean", Caption="Lead Free Pass", Importance = 67)]
        public VarBoolean lead_free_passVar;

        [CoreVarVal("lead_free_na", "Boolean", Caption="Lead Free Na", Importance = 68)]
        public VarBoolean lead_free_naVar;

        [CoreVarVal("has_test_docs", "Boolean", Caption="Has Test Docs", Importance = 69)]
        public VarBoolean has_test_docsVar;

        [CoreVarVal("test_performed", "String", TheFieldLength = 255, Caption="Test Performed", Importance = 70)]
        public VarString test_performedVar;

        [CoreVarVal("qty_tested", "Int64", Caption="Qty Tested", Importance = 71)]
        public VarInt64 qty_testedVar;

        [CoreVarVal("qty_passed", "Int64", Caption="Qty Passed", Importance = 72)]
        public VarInt64 qty_passedVar;

        [CoreVarVal("qty_failed", "Int64", Caption="Qty Failed", Importance = 73)]
        public VarInt64 qty_failedVar;

        [CoreVarVal("initials", "String", TheFieldLength = 255, Caption="Initials", Importance = 74)]
        public VarString initialsVar;

        [CoreVarVal("test_company", "String", TheFieldLength = 255, Caption="Test Company", Importance = 75)]
        public VarString test_companyVar;

        [CoreVarVal("pre_photo_weight", "Boolean", Caption="Pre Photo Weight", Importance = 76)]
        public VarBoolean pre_photo_weightVar;

        [CoreVarVal("pre_photo_weight_notes", "String", TheFieldLength = 255, Caption="Pre Photo Weight Notes", Importance = 77)]
        public VarString pre_photo_weight_notesVar;

        [CoreVarVal("photos_in_box", "Boolean", Caption="Photos In Box", Importance = 78)]
        public VarBoolean photos_in_boxVar;

        [CoreVarVal("photos_in_box_notes", "String", TheFieldLength = 255, Caption="Photos In Box Notes", Importance = 79)]
        public VarString photos_in_box_notesVar;

        [CoreVarVal("photos_include_leads", "Boolean", Caption="Photos Include Leads", Importance = 80)]
        public VarBoolean photos_include_leadsVar;

        [CoreVarVal("photos_include_leads_notes", "String", TheFieldLength = 255, Caption="Photos Include Leads Notes", Importance = 81)]
        public VarString photos_include_leads_notesVar;

        [CoreVarVal("leaving_photos", "Boolean", Caption="Leaving Photos", Importance = 82)]
        public VarBoolean leaving_photosVar;

        [CoreVarVal("leaving_photos_notes", "String", TheFieldLength = 255, Caption="Leaving Photos Notes", Importance = 83)]
        public VarString leaving_photos_notesVar;

        [CoreVarVal("processor_name", "String", TheFieldLength = 255, Caption="Processor Name", Importance = 84)]
        public VarString processor_nameVar;

        [CoreVarVal("datasheet_analysis", "Boolean", Caption="Datasheet Analysis", Importance = 85)]
        public VarBoolean datasheet_analysisVar;

        [CoreVarVal("datasheet_analysis_notes", "String", TheFieldLength = 255, Caption="Datasheet Analysis Notes", Importance = 86)]
        public VarString datasheet_analysis_notesVar;

        [CoreVarVal("ocm_verification", "Boolean", Caption="Ocm Verification", Importance = 87)]
        public VarBoolean ocm_verificationVar;

        [CoreVarVal("ocm_verification_notes", "String", TheFieldLength = 255, Caption="Ocm Verification Notes", Importance = 88)]
        public VarString ocm_verification_notesVar;

        [CoreVarVal("gold_standard", "Boolean", Caption="Gold Standard", Importance = 89)]
        public VarBoolean gold_standardVar;

        [CoreVarVal("gold_standard_notes", "String", TheFieldLength = 255, Caption="Gold Standard Notes", Importance = 90)]
        public VarString gold_standard_notesVar;

        [CoreVarVal("calibrations_measured", "Boolean", Caption="Calibrations Measured", Importance = 91)]
        public VarBoolean calibrations_measuredVar;

        [CoreVarVal("calibrations_measured_notes", "String", TheFieldLength = 255, Caption="Calibrations Measured Notes", Importance = 92)]
        public VarString calibrations_measured_notesVar;

        [CoreVarVal("lot_code_match", "Boolean", Caption="Lot Code Match", Importance = 93)]
        public VarBoolean lot_code_matchVar;

        [CoreVarVal("lot_code_notes", "String", TheFieldLength = 255, Caption="Lot Code Notes", Importance = 94)]
        public VarString lot_code_notesVar;

        [CoreVarVal("country_match", "Boolean", Caption="Country Match", Importance = 95)]
        public VarBoolean country_matchVar;

        [CoreVarVal("country_notes", "Boolean", Caption="Country Notes", Importance = 96)]
        public VarBoolean country_notesVar;

        [CoreVarVal("new_option", "String", TheFieldLength = 255, Caption="New Option", Importance = 97)]
        public VarString new_optionVar;

        [CoreVarVal("condition_option", "String", TheFieldLength = 255, Caption="Condition Option", Importance = 98)]
        public VarString condition_optionVar;

        [CoreVarVal("marking_permanency_option", "String", TheFieldLength = 255, Caption="Marking Permanency Option", Importance = 99)]
        public VarString marking_permanency_optionVar;

        [CoreVarVal("data_sheet_review_option", "String", TheFieldLength = 255, Caption="Data Sheet Review Option", Importance = 100)]
        public VarString data_sheet_review_optionVar;

        [CoreVarVal("leads_contact_option", "String", TheFieldLength = 255, Caption="Leads Contact Option", Importance = 101)]
        public VarString leads_contact_optionVar;

        [CoreVarVal("alteration_option", "String", TheFieldLength = 255, Caption="Alteration Option", Importance = 102)]
        public VarString alteration_optionVar;

        [CoreVarVal("possible_remark_option", "String", TheFieldLength = 255, Caption="Possible Remark Option", Importance = 103)]
        public VarString possible_remark_optionVar;

        [CoreVarVal("excess_option", "String", TheFieldLength = 255, Caption="Excess Option", Importance = 104)]
        public VarString excess_optionVar;

        [CoreVarVal("insertion_option", "String", TheFieldLength = 255, Caption="Insertion Option", Importance = 105)]
        public VarString insertion_optionVar;

        [CoreVarVal("maynotbenew_option", "String", TheFieldLength = 255, Caption="Maynotbenew Option", Importance = 106)]
        public VarString maynotbenew_optionVar;

        [CoreVarVal("counterfeit_option", "String", TheFieldLength = 255, Caption="Counterfeit Option", Importance = 107)]
        public VarString counterfeit_optionVar;

        [CoreVarVal("doesnotmatchdatasheet_option", "String", TheFieldLength = 255, Caption="Doesnotmatchdatasheet Option", Importance = 108)]
        public VarString doesnotmatchdatasheet_optionVar;

        [CoreVarVal("very_poor_quality_option", "String", TheFieldLength = 255, Caption="Very Poor Quality Option", Importance = 109)]
        public VarString very_poor_quality_optionVar;

        [CoreVarVal("remark_option", "String", TheFieldLength = 255, Caption="Remark Option", Importance = 110)]
        public VarString remark_optionVar;

        [CoreVarVal("option_summary", "String", TheFieldLength = 8000, Caption="Option Summary", Importance = 111)]
        public VarString option_summaryVar;

        [CoreVarVal("passed_option", "Boolean", Caption="Passed Option", Importance = 112)]
        public VarBoolean passed_optionVar;

        [CoreVarVal("internal_comment", "Text", Caption="Internal Comment", Importance = 113)]
        public VarText internal_commentVar;

        [CoreVarVal("tier_1_pass", "Boolean", Caption="Tier 1 Pass", Importance = 114)]
        public VarBoolean tier_1_passVar;

        [CoreVarVal("tier_2_pass", "Boolean", Caption="Tier 2 Pass", Importance = 115)]
        public VarBoolean tier_2_passVar;

        [CoreVarVal("tier_3_pass", "Boolean", Caption="Tier 3 Pass", Importance = 116)]
        public VarBoolean tier_3_passVar;

        [CoreVarVal("use_tier_1", "Boolean", Caption="Use Tier 1", Importance = 117)]
        public VarBoolean use_tier_1Var;

        [CoreVarVal("use_tier_2", "Boolean", Caption="Use Tier 2", Importance = 118)]
        public VarBoolean use_tier_2Var;

        [CoreVarVal("use_tier_3", "Boolean", Caption="Use Tier 3", Importance = 119)]
        public VarBoolean use_tier_3Var;

        [CoreVarVal("pin_correlation", "Boolean", Caption="Pin Correlation", Importance = 120)]
        public VarBoolean pin_correlationVar;

        [CoreVarVal("datasheet_verification", "Boolean", Caption="Datasheet Verification", Importance = 121)]
        public VarBoolean datasheet_verificationVar;

        [CoreVarVal("functional", "Boolean", Caption="Functional", Importance = 122)]
        public VarBoolean functionalVar;

        [CoreVarVal("dc_electrical", "Boolean", Caption="Dc Electrical", Importance = 123)]
        public VarBoolean dc_electricalVar;

        [CoreVarVal("po_number", "String", TheFieldLength = 255, Caption="Po Number", Importance = 124)]
        public VarString po_numberVar;

        [CoreVarVal("service_number", "String", TheFieldLength = 255, Caption="Service Number", Importance = 125)]
        public VarString service_numberVar;

        [CoreVarVal("vendor_name", "String", TheFieldLength = 255, Caption="Vendor Name", Importance = 126)]
        public VarString vendor_nameVar;

        [CoreVarVal("packing_slip_date_yn", "Boolean", Caption="Packing Slip Date Yn", Importance = 127)]
        public VarBoolean packing_slip_date_ynVar;

        [CoreVarVal("packing_slip_date_notes", "String", TheFieldLength = 255, Caption="Packing Slip Date Notes", Importance = 128)]
        public VarString packing_slip_date_notesVar;

        [CoreVarVal("packing_slip_mfg_yn", "Boolean", Caption="Packing Slip Mfg Yn", Importance = 129)]
        public VarBoolean packing_slip_mfg_ynVar;

        [CoreVarVal("packing_slip_mfg_notes", "String", TheFieldLength = 255, Caption="Packing Slip Mfg Notes", Importance = 130)]
        public VarString packing_slip_mfg_notesVar;

        [CoreVarVal("packing_slip_cost_yn", "Boolean", Caption="Packing Slip Cost Yn", Importance = 131)]
        public VarBoolean packing_slip_cost_ynVar;

        [CoreVarVal("packing_slip_cost_notes", "String", TheFieldLength = 255, Caption="Packing Slip Cost Notes", Importance = 132)]
        public VarString packing_slip_cost_notesVar;

        [CoreVarVal("packing_slip_ponum_yn", "Boolean", Caption="Packing Slip Ponum Yn", Importance = 133)]
        public VarBoolean packing_slip_ponum_ynVar;

        [CoreVarVal("packing_slip_ponum_notes", "String", TheFieldLength = 255, Caption="Packing Slip Ponum Notes", Importance = 134)]
        public VarString packing_slip_ponum_notesVar;

        [CoreVarVal("packing_slip_sonum_yn", "Boolean", Caption="Packing Slip Sonum Yn", Importance = 135)]
        public VarBoolean packing_slip_sonum_ynVar;

        [CoreVarVal("packing_slip_sonum_notes", "String", TheFieldLength = 255, Caption="Packing Slip Sonum Notes", Importance = 136)]
        public VarString packing_slip_sonum_notesVar;

        [CoreVarVal("country_notes_text", "String", TheFieldLength = 255, Caption="Country Notes Text", Importance = 137)]
        public VarString country_notes_textVar;


        //KT Refactored from RzSensible
        [CoreVarVal("parts_good_cond", "Boolean", Caption = "Parts Good Cond", Importance = 1)]
        public VarBoolean parts_good_condVar;

        [CoreVarVal("parts_good_cond_notes", "String", TheFieldLength = 255, Caption = "Parts Good Cond Notes", Importance = 2)]
        public VarString parts_good_cond_notesVar;

        [CoreVarVal("qty_amnt_ordered", "Boolean", Caption = "Qty Amnt Ordered", Importance = 3)]
        public VarBoolean qty_amnt_orderedVar;

        [CoreVarVal("qty_amnt_ordered_notes", "String", TheFieldLength = 255, Caption = "Qty Amnt Ordered Notes", Importance = 4)]
        public VarString qty_amnt_ordered_notesVar;

        [CoreVarVal("dc_match_ordered", "Boolean", Caption = "Dc Match Ordered", Importance = 5)]
        public VarBoolean dc_match_orderedVar;

        [CoreVarVal("dc_match_ordered_notes", "String", TheFieldLength = 255, Caption = "Dc Match Ordered Notes", Importance = 6)]
        public VarString dc_match_ordered_notesVar;

        [CoreVarVal("mfg_match_ordered", "Boolean", Caption = "Mfg Match Ordered", Importance = 7)]
        public VarBoolean mfg_match_orderedVar;

        [CoreVarVal("mfg_match_ordered_notes", "String", TheFieldLength = 255, Caption = "Mfg Match Ordered Notes", Importance = 8)]
        public VarString mfg_match_ordered_notesVar;

        [CoreVarVal("cost_match_ordered", "Boolean", Caption = "Cost Match Ordered", Importance = 9)]
        public VarBoolean cost_match_orderedVar;

        [CoreVarVal("cost_match_ordered_notes", "String", TheFieldLength = 255, Caption = "Cost Match Ordered Notes", Importance = 10)]
        public VarString cost_match_ordered_notesVar;

        [CoreVarVal("pkg_label_auth", "Boolean", Caption = "Pkg Label Auth", Importance = 11)]
        public VarBoolean pkg_label_authVar;

        [CoreVarVal("pkg_label_auth_notes", "String", TheFieldLength = 255, Caption = "Pkg Label Auth Notes", Importance = 12)]
        public VarString pkg_label_auth_notesVar;

        [CoreVarVal("lot_match_ordered", "Boolean", Caption = "Lot Match Ordered", Importance = 13)]
        public VarBoolean lot_match_orderedVar;

        [CoreVarVal("lot_match_ordered_notes", "String", TheFieldLength = 255, Caption = "Lot Match Ordered Notes", Importance = 14)]
        public VarString lot_match_ordered_notesVar;

        [CoreVarVal("country_origin_consistent", "Boolean", Caption = "Country Origin Consistent", Importance = 15)]
        public VarBoolean country_origin_consistentVar;

        [CoreVarVal("country_origin_consistent_notes", "String", TheFieldLength = 255, Caption = "Country Origin Consistent Notes", Importance = 16)]
        public VarString country_origin_consistent_notesVar;

        [CoreVarVal("signs_rework", "Boolean", Caption = "Signs Rework", Importance = 17)]
        public VarBoolean signs_reworkVar;

        [CoreVarVal("signs_rework_notes", "String", TheFieldLength = 255, Caption = "Signs Rework Notes", Importance = 18)]
        public VarString signs_rework_notesVar;

        [CoreVarVal("pass_acetone", "Boolean", Caption = "Pass Acetone", Importance = 19)]
        public VarBoolean pass_acetoneVar;

        [CoreVarVal("pass_acetone_notes", "String", TheFieldLength = 255, Caption = "Pass Acetone Notes", Importance = 20)]
        public VarString pass_acetone_notesVar;

        [CoreVarVal("original_mfg_pkg", "Boolean", Caption = "Original Mfg Pkg", Importance = 21)]
        public VarBoolean original_mfg_pkgVar;

        [CoreVarVal("original_mfg_pkg_notes", "String", TheFieldLength = 255, Caption = "Original Mfg Pkg Notes", Importance = 22)]
        public VarString original_mfg_pkg_notesVar;

        [CoreVarVal("pin1_correct_loc", "Boolean", Caption = "Pin1 Correct Loc", Importance = 23)]
        public VarBoolean pin1_correct_locVar;

        [CoreVarVal("pin1_correct_loc_notes", "String", TheFieldLength = 255, Caption = "Pin1 Correct Loc Notes", Importance = 24)]
        public VarString pin1_correct_loc_notesVar;

        [CoreVarVal("micro_sanding", "Boolean", Caption = "Micro Sanding", Importance = 25)]
        public VarBoolean micro_sandingVar;

        [CoreVarVal("micro_sanding_notes", "String", TheFieldLength = 255, Caption = "Micro Sanding Notes", Importance = 26)]
        public VarString micro_sanding_notesVar;

        [CoreVarVal("micro_solder", "Boolean", Caption = "Micro Solder", Importance = 27)]
        public VarBoolean micro_solderVar;

        [CoreVarVal("micro_solder_notes", "String", TheFieldLength = 255, Caption = "Micro Solder Notes", Importance = 28)]
        public VarString micro_solder_notesVar;

        [CoreVarVal("order_meet_criteria", "Boolean", Caption = "Order Meet Criteria", Importance = 29)]
        public VarBoolean order_meet_criteriaVar;

        [CoreVarVal("order_meet_criteria_notes", "String", TheFieldLength = 255, Caption = "Order Meet Criteria Notes", Importance = 30)]
        public VarString order_meet_criteria_notesVar;

        [CoreVarVal("part_to_be_shipped", "Boolean", Caption = "Part To Be Shipped", Importance = 31)]
        public VarBoolean part_to_be_shippedVar;

        [CoreVarVal("part_to_be_shipped_notes", "String", TheFieldLength = 255, Caption = "Part To Be Shipped Notes", Importance = 32)]
        public VarString part_to_be_shipped_notesVar;

        [CoreVarVal("parts_nonconfirm_material", "Boolean", Caption = "Parts Nonconfirm Material", Importance = 33)]
        public VarBoolean parts_nonconfirm_materialVar;

        [CoreVarVal("parts_nonconfirm_material_notes", "String", TheFieldLength = 255, Caption = "Parts Nonconfirm Material Notes", Importance = 34)]
        public VarString parts_nonconfirm_material_notesVar;




        public qualitycontrol_auto()
        {
            StaticInit();
            the_n_user_uidVar = new VarString(this, the_n_user_uidAttribute);
            the_companycontact_uidVar = new VarString(this, the_companycontact_uidAttribute);
            the_company_uidVar = new VarString(this, the_company_uidAttribute);
            the_partrecord_uidVar = new VarString(this, the_partrecord_uidAttribute);
            the_orddet_uidVar = new VarString(this, the_orddet_uidAttribute);
            fullpartnumberVar = new VarString(this, fullpartnumberAttribute);
            quantityreceivedVar = new VarInt64(this, quantityreceivedAttribute);
            quantitybackorderedVar = new VarInt64(this, quantitybackorderedAttribute);
            manufacturerVar = new VarString(this, manufacturerAttribute);
            datecodeVar = new VarString(this, datecodeAttribute);
            conditionVar = new VarString(this, conditionAttribute);
            prefixVar = new VarString(this, prefixAttribute);
            basenumberVar = new VarString(this, basenumberAttribute);
            basenumberstrippedVar = new VarString(this, basenumberstrippedAttribute);
            companynameVar = new VarString(this, companynameAttribute);
            contactnameVar = new VarString(this, contactnameAttribute);
            packagingVar = new VarString(this, packagingAttribute);
            alternatepartVar = new VarString(this, alternatepartAttribute);
            categoryVar = new VarString(this, categoryAttribute);
            alternatepartstrippedVar = new VarString(this, alternatepartstrippedAttribute);
            certs_includedVar = new VarBoolean(this, certs_includedAttribute);
            certs_matchVar = new VarBoolean(this, certs_matchAttribute);
            good_package_conditionVar = new VarBoolean(this, good_package_conditionAttribute);
            photo_package_damageVar = new VarBoolean(this, photo_package_damageAttribute);
            report_package_damageVar = new VarBoolean(this, report_package_damageAttribute);
            match_vendor_infoVar = new VarBoolean(this, match_vendor_infoAttribute);
            verify_part_numberVar = new VarBoolean(this, verify_part_numberAttribute);
            verify_quantityVar = new VarBoolean(this, verify_quantityAttribute);
            good_part_packagingVar = new VarBoolean(this, good_part_packagingAttribute);
            photographed_bad_part_packagingVar = new VarBoolean(this, photographed_bad_part_packagingAttribute);
            good_esd_packagingVar = new VarBoolean(this, good_esd_packagingAttribute);
            good_part_sealingVar = new VarBoolean(this, good_part_sealingAttribute);
            good_package_notesVar = new VarString(this, good_package_notesAttribute);
            package_damage_notesVar = new VarString(this, package_damage_notesAttribute);
            vendor_info_notesVar = new VarString(this, vendor_info_notesAttribute);
            part_number_notesVar = new VarString(this, part_number_notesAttribute);
            quantity_notesVar = new VarString(this, quantity_notesAttribute);
            esd_packaging_notesVar = new VarString(this, esd_packaging_notesAttribute);
            part_sealing_notesVar = new VarString(this, part_sealing_notesAttribute);
            barcodes_matchVar = new VarBoolean(this, barcodes_matchAttribute);
            barcode_notesVar = new VarString(this, barcode_notesAttribute);
            good_labelingVar = new VarBoolean(this, good_labelingAttribute);
            labeling_notesVar = new VarString(this, labeling_notesAttribute);
            manufacturer_matchVar = new VarBoolean(this, manufacturer_matchAttribute);
            manufacturer_notesVar = new VarString(this, manufacturer_notesAttribute);
            datecode_matchVar = new VarBoolean(this, datecode_matchAttribute);
            datecode_notesVar = new VarString(this, datecode_notesAttribute);
            good_country_of_originVar = new VarBoolean(this, good_country_of_originAttribute);
            country_of_origin_notesVar = new VarString(this, country_of_origin_notesAttribute);
            is_refurbVar = new VarBoolean(this, is_refurbAttribute);
            refurb_notesVar = new VarString(this, refurb_notesAttribute);
            is_authenticVar = new VarBoolean(this, is_authenticAttribute);
            authentic_notesVar = new VarString(this, authentic_notesAttribute);
            is_humidity_controlledVar = new VarBoolean(this, is_humidity_controlledAttribute);
            humidity_controlled_notesVar = new VarString(this, humidity_controlled_notesAttribute);
            check_humidity_statusVar = new VarBoolean(this, check_humidity_statusAttribute);
            photographed_labelsVar = new VarBoolean(this, photographed_labelsAttribute);
            humidity_status_notesVar = new VarString(this, humidity_status_notesAttribute);
            photographed_label_notesVar = new VarString(this, photographed_label_notesAttribute);
            agentnameVar = new VarString(this, agentnameAttribute);
            internalcommentVar = new VarText(this, internalcommentAttribute);
            has_problemVar = new VarBoolean(this, has_problemAttribute);
            problem_notesVar = new VarString(this, problem_notesAttribute);
            part_package_notesVar = new VarString(this, part_package_notesAttribute);
            parts_per_packageVar = new VarString(this, parts_per_packageAttribute);
            lead_freeVar = new VarBoolean(this, lead_freeAttribute);
            lead_free_passVar = new VarBoolean(this, lead_free_passAttribute);
            lead_free_naVar = new VarBoolean(this, lead_free_naAttribute);
            has_test_docsVar = new VarBoolean(this, has_test_docsAttribute);
            test_performedVar = new VarString(this, test_performedAttribute);
            qty_testedVar = new VarInt64(this, qty_testedAttribute);
            qty_passedVar = new VarInt64(this, qty_passedAttribute);
            qty_failedVar = new VarInt64(this, qty_failedAttribute);
            initialsVar = new VarString(this, initialsAttribute);
            test_companyVar = new VarString(this, test_companyAttribute);
            pre_photo_weightVar = new VarBoolean(this, pre_photo_weightAttribute);
            pre_photo_weight_notesVar = new VarString(this, pre_photo_weight_notesAttribute);
            photos_in_boxVar = new VarBoolean(this, photos_in_boxAttribute);
            photos_in_box_notesVar = new VarString(this, photos_in_box_notesAttribute);
            photos_include_leadsVar = new VarBoolean(this, photos_include_leadsAttribute);
            photos_include_leads_notesVar = new VarString(this, photos_include_leads_notesAttribute);
            leaving_photosVar = new VarBoolean(this, leaving_photosAttribute);
            leaving_photos_notesVar = new VarString(this, leaving_photos_notesAttribute);
            processor_nameVar = new VarString(this, processor_nameAttribute);
            datasheet_analysisVar = new VarBoolean(this, datasheet_analysisAttribute);
            datasheet_analysis_notesVar = new VarString(this, datasheet_analysis_notesAttribute);
            ocm_verificationVar = new VarBoolean(this, ocm_verificationAttribute);
            ocm_verification_notesVar = new VarString(this, ocm_verification_notesAttribute);
            gold_standardVar = new VarBoolean(this, gold_standardAttribute);
            gold_standard_notesVar = new VarString(this, gold_standard_notesAttribute);
            calibrations_measuredVar = new VarBoolean(this, calibrations_measuredAttribute);
            calibrations_measured_notesVar = new VarString(this, calibrations_measured_notesAttribute);
            lot_code_matchVar = new VarBoolean(this, lot_code_matchAttribute);
            lot_code_notesVar = new VarString(this, lot_code_notesAttribute);
            country_matchVar = new VarBoolean(this, country_matchAttribute);
            country_notesVar = new VarBoolean(this, country_notesAttribute);
            new_optionVar = new VarString(this, new_optionAttribute);
            condition_optionVar = new VarString(this, condition_optionAttribute);
            marking_permanency_optionVar = new VarString(this, marking_permanency_optionAttribute);
            data_sheet_review_optionVar = new VarString(this, data_sheet_review_optionAttribute);
            leads_contact_optionVar = new VarString(this, leads_contact_optionAttribute);
            alteration_optionVar = new VarString(this, alteration_optionAttribute);
            possible_remark_optionVar = new VarString(this, possible_remark_optionAttribute);
            excess_optionVar = new VarString(this, excess_optionAttribute);
            insertion_optionVar = new VarString(this, insertion_optionAttribute);
            maynotbenew_optionVar = new VarString(this, maynotbenew_optionAttribute);
            counterfeit_optionVar = new VarString(this, counterfeit_optionAttribute);
            doesnotmatchdatasheet_optionVar = new VarString(this, doesnotmatchdatasheet_optionAttribute);
            very_poor_quality_optionVar = new VarString(this, very_poor_quality_optionAttribute);
            remark_optionVar = new VarString(this, remark_optionAttribute);
            option_summaryVar = new VarString(this, option_summaryAttribute);
            passed_optionVar = new VarBoolean(this, passed_optionAttribute);
            internal_commentVar = new VarText(this, internal_commentAttribute);
            tier_1_passVar = new VarBoolean(this, tier_1_passAttribute);
            tier_2_passVar = new VarBoolean(this, tier_2_passAttribute);
            tier_3_passVar = new VarBoolean(this, tier_3_passAttribute);
            use_tier_1Var = new VarBoolean(this, use_tier_1Attribute);
            use_tier_2Var = new VarBoolean(this, use_tier_2Attribute);
            use_tier_3Var = new VarBoolean(this, use_tier_3Attribute);
            pin_correlationVar = new VarBoolean(this, pin_correlationAttribute);
            datasheet_verificationVar = new VarBoolean(this, datasheet_verificationAttribute);
            functionalVar = new VarBoolean(this, functionalAttribute);
            dc_electricalVar = new VarBoolean(this, dc_electricalAttribute);
            po_numberVar = new VarString(this, po_numberAttribute);
            service_numberVar = new VarString(this, service_numberAttribute);
            vendor_nameVar = new VarString(this, vendor_nameAttribute);
            packing_slip_date_ynVar = new VarBoolean(this, packing_slip_date_ynAttribute);
            packing_slip_date_notesVar = new VarString(this, packing_slip_date_notesAttribute);
            packing_slip_mfg_ynVar = new VarBoolean(this, packing_slip_mfg_ynAttribute);
            packing_slip_mfg_notesVar = new VarString(this, packing_slip_mfg_notesAttribute);
            packing_slip_cost_ynVar = new VarBoolean(this, packing_slip_cost_ynAttribute);
            packing_slip_cost_notesVar = new VarString(this, packing_slip_cost_notesAttribute);
            packing_slip_ponum_ynVar = new VarBoolean(this, packing_slip_ponum_ynAttribute);
            packing_slip_ponum_notesVar = new VarString(this, packing_slip_ponum_notesAttribute);
            packing_slip_sonum_ynVar = new VarBoolean(this, packing_slip_sonum_ynAttribute);
            packing_slip_sonum_notesVar = new VarString(this, packing_slip_sonum_notesAttribute);
            country_notes_textVar = new VarString(this, country_notes_textAttribute);

            //KT Refactored from RzSensible
            parts_good_condVar = new VarBoolean(this, parts_good_condAttribute);
            parts_good_cond_notesVar = new VarString(this, parts_good_cond_notesAttribute);
            qty_amnt_orderedVar = new VarBoolean(this, qty_amnt_orderedAttribute);
            qty_amnt_ordered_notesVar = new VarString(this, qty_amnt_ordered_notesAttribute);
            dc_match_orderedVar = new VarBoolean(this, dc_match_orderedAttribute);
            dc_match_ordered_notesVar = new VarString(this, dc_match_ordered_notesAttribute);
            mfg_match_orderedVar = new VarBoolean(this, mfg_match_orderedAttribute);
            mfg_match_ordered_notesVar = new VarString(this, mfg_match_ordered_notesAttribute);
            cost_match_orderedVar = new VarBoolean(this, cost_match_orderedAttribute);
            cost_match_ordered_notesVar = new VarString(this, cost_match_ordered_notesAttribute);
            pkg_label_authVar = new VarBoolean(this, pkg_label_authAttribute);
            pkg_label_auth_notesVar = new VarString(this, pkg_label_auth_notesAttribute);
            lot_match_orderedVar = new VarBoolean(this, lot_match_orderedAttribute);
            lot_match_ordered_notesVar = new VarString(this, lot_match_ordered_notesAttribute);
            country_origin_consistentVar = new VarBoolean(this, country_origin_consistentAttribute);
            country_origin_consistent_notesVar = new VarString(this, country_origin_consistent_notesAttribute);
            signs_reworkVar = new VarBoolean(this, signs_reworkAttribute);
            signs_rework_notesVar = new VarString(this, signs_rework_notesAttribute);
            pass_acetoneVar = new VarBoolean(this, pass_acetoneAttribute);
            pass_acetone_notesVar = new VarString(this, pass_acetone_notesAttribute);
            original_mfg_pkgVar = new VarBoolean(this, original_mfg_pkgAttribute);
            original_mfg_pkg_notesVar = new VarString(this, original_mfg_pkg_notesAttribute);
            pin1_correct_locVar = new VarBoolean(this, pin1_correct_locAttribute);
            pin1_correct_loc_notesVar = new VarString(this, pin1_correct_loc_notesAttribute);
            micro_sandingVar = new VarBoolean(this, micro_sandingAttribute);
            micro_sanding_notesVar = new VarString(this, micro_sanding_notesAttribute);
            micro_solderVar = new VarBoolean(this, micro_solderAttribute);
            micro_solder_notesVar = new VarString(this, micro_solder_notesAttribute);
            order_meet_criteriaVar = new VarBoolean(this, order_meet_criteriaAttribute);
            order_meet_criteria_notesVar = new VarString(this, order_meet_criteria_notesAttribute);
            part_to_be_shippedVar = new VarBoolean(this, part_to_be_shippedAttribute);
            part_to_be_shipped_notesVar = new VarString(this, part_to_be_shipped_notesAttribute);
            parts_nonconfirm_materialVar = new VarBoolean(this, parts_nonconfirm_materialAttribute);
            parts_nonconfirm_material_notesVar = new VarString(this, parts_nonconfirm_material_notesAttribute);
        }

        public override string ClassId
        { get { return "qualitycontrol"; } }

        public String the_n_user_uid
        {
            get  { return (String)the_n_user_uidVar.Value; }
            set  { the_n_user_uidVar.Value = value; }
        }

        public String the_companycontact_uid
        {
            get  { return (String)the_companycontact_uidVar.Value; }
            set  { the_companycontact_uidVar.Value = value; }
        }

        public String the_company_uid
        {
            get  { return (String)the_company_uidVar.Value; }
            set  { the_company_uidVar.Value = value; }
        }

        public String the_partrecord_uid
        {
            get  { return (String)the_partrecord_uidVar.Value; }
            set  { the_partrecord_uidVar.Value = value; }
        }

        public String the_orddet_uid
        {
            get  { return (String)the_orddet_uidVar.Value; }
            set  { the_orddet_uidVar.Value = value; }
        }

        public String fullpartnumber
        {
            get  { return (String)fullpartnumberVar.Value; }
            set  { fullpartnumberVar.Value = value; }
        }

        public Int64 quantityreceived
        {
            get  { return (Int64)quantityreceivedVar.Value; }
            set  { quantityreceivedVar.Value = value; }
        }

        public Int64 quantitybackordered
        {
            get  { return (Int64)quantitybackorderedVar.Value; }
            set  { quantitybackorderedVar.Value = value; }
        }

        public String manufacturer
        {
            get  { return (String)manufacturerVar.Value; }
            set  { manufacturerVar.Value = value; }
        }

        public String datecode
        {
            get  { return (String)datecodeVar.Value; }
            set  { datecodeVar.Value = value; }
        }

        public String condition
        {
            get  { return (String)conditionVar.Value; }
            set  { conditionVar.Value = value; }
        }

        public String prefix
        {
            get  { return (String)prefixVar.Value; }
            set  { prefixVar.Value = value; }
        }

        public String basenumber
        {
            get  { return (String)basenumberVar.Value; }
            set  { basenumberVar.Value = value; }
        }

        public String basenumberstripped
        {
            get  { return (String)basenumberstrippedVar.Value; }
            set  { basenumberstrippedVar.Value = value; }
        }

        public String companyname
        {
            get  { return (String)companynameVar.Value; }
            set  { companynameVar.Value = value; }
        }

        public String contactname
        {
            get  { return (String)contactnameVar.Value; }
            set  { contactnameVar.Value = value; }
        }

        public String packaging
        {
            get  { return (String)packagingVar.Value; }
            set  { packagingVar.Value = value; }
        }

        public String alternatepart
        {
            get  { return (String)alternatepartVar.Value; }
            set  { alternatepartVar.Value = value; }
        }

        public String category
        {
            get  { return (String)categoryVar.Value; }
            set  { categoryVar.Value = value; }
        }

        public String alternatepartstripped
        {
            get  { return (String)alternatepartstrippedVar.Value; }
            set  { alternatepartstrippedVar.Value = value; }
        }

        public Boolean certs_included
        {
            get  { return (Boolean)certs_includedVar.Value; }
            set  { certs_includedVar.Value = value; }
        }

        public Boolean certs_match
        {
            get  { return (Boolean)certs_matchVar.Value; }
            set  { certs_matchVar.Value = value; }
        }

        public Boolean good_package_condition
        {
            get  { return (Boolean)good_package_conditionVar.Value; }
            set  { good_package_conditionVar.Value = value; }
        }

        public Boolean photo_package_damage
        {
            get  { return (Boolean)photo_package_damageVar.Value; }
            set  { photo_package_damageVar.Value = value; }
        }

        public Boolean report_package_damage
        {
            get  { return (Boolean)report_package_damageVar.Value; }
            set  { report_package_damageVar.Value = value; }
        }

        public Boolean match_vendor_info
        {
            get  { return (Boolean)match_vendor_infoVar.Value; }
            set  { match_vendor_infoVar.Value = value; }
        }

        public Boolean verify_part_number
        {
            get  { return (Boolean)verify_part_numberVar.Value; }
            set  { verify_part_numberVar.Value = value; }
        }

        public Boolean verify_quantity
        {
            get  { return (Boolean)verify_quantityVar.Value; }
            set  { verify_quantityVar.Value = value; }
        }

        public Boolean good_part_packaging
        {
            get  { return (Boolean)good_part_packagingVar.Value; }
            set  { good_part_packagingVar.Value = value; }
        }

        public Boolean photographed_bad_part_packaging
        {
            get  { return (Boolean)photographed_bad_part_packagingVar.Value; }
            set  { photographed_bad_part_packagingVar.Value = value; }
        }

        public Boolean good_esd_packaging
        {
            get  { return (Boolean)good_esd_packagingVar.Value; }
            set  { good_esd_packagingVar.Value = value; }
        }

        public Boolean good_part_sealing
        {
            get  { return (Boolean)good_part_sealingVar.Value; }
            set  { good_part_sealingVar.Value = value; }
        }

        public String good_package_notes
        {
            get  { return (String)good_package_notesVar.Value; }
            set  { good_package_notesVar.Value = value; }
        }

        public String package_damage_notes
        {
            get  { return (String)package_damage_notesVar.Value; }
            set  { package_damage_notesVar.Value = value; }
        }

        public String vendor_info_notes
        {
            get  { return (String)vendor_info_notesVar.Value; }
            set  { vendor_info_notesVar.Value = value; }
        }

        public String part_number_notes
        {
            get  { return (String)part_number_notesVar.Value; }
            set  { part_number_notesVar.Value = value; }
        }

        public String quantity_notes
        {
            get  { return (String)quantity_notesVar.Value; }
            set  { quantity_notesVar.Value = value; }
        }

        public String esd_packaging_notes
        {
            get  { return (String)esd_packaging_notesVar.Value; }
            set  { esd_packaging_notesVar.Value = value; }
        }

        public String part_sealing_notes
        {
            get  { return (String)part_sealing_notesVar.Value; }
            set  { part_sealing_notesVar.Value = value; }
        }

        public Boolean barcodes_match
        {
            get  { return (Boolean)barcodes_matchVar.Value; }
            set  { barcodes_matchVar.Value = value; }
        }

        public String barcode_notes
        {
            get  { return (String)barcode_notesVar.Value; }
            set  { barcode_notesVar.Value = value; }
        }

        public Boolean good_labeling
        {
            get  { return (Boolean)good_labelingVar.Value; }
            set  { good_labelingVar.Value = value; }
        }

        public String labeling_notes
        {
            get  { return (String)labeling_notesVar.Value; }
            set  { labeling_notesVar.Value = value; }
        }

        public Boolean manufacturer_match
        {
            get  { return (Boolean)manufacturer_matchVar.Value; }
            set  { manufacturer_matchVar.Value = value; }
        }

        public String manufacturer_notes
        {
            get  { return (String)manufacturer_notesVar.Value; }
            set  { manufacturer_notesVar.Value = value; }
        }

        public Boolean datecode_match
        {
            get  { return (Boolean)datecode_matchVar.Value; }
            set  { datecode_matchVar.Value = value; }
        }

        public String datecode_notes
        {
            get  { return (String)datecode_notesVar.Value; }
            set  { datecode_notesVar.Value = value; }
        }

        public Boolean good_country_of_origin
        {
            get  { return (Boolean)good_country_of_originVar.Value; }
            set  { good_country_of_originVar.Value = value; }
        }

        public String country_of_origin_notes
        {
            get  { return (String)country_of_origin_notesVar.Value; }
            set  { country_of_origin_notesVar.Value = value; }
        }

        public Boolean is_refurb
        {
            get  { return (Boolean)is_refurbVar.Value; }
            set  { is_refurbVar.Value = value; }
        }

        public String refurb_notes
        {
            get  { return (String)refurb_notesVar.Value; }
            set  { refurb_notesVar.Value = value; }
        }

        public Boolean is_authentic
        {
            get  { return (Boolean)is_authenticVar.Value; }
            set  { is_authenticVar.Value = value; }
        }

        public String authentic_notes
        {
            get  { return (String)authentic_notesVar.Value; }
            set  { authentic_notesVar.Value = value; }
        }

        public Boolean is_humidity_controlled
        {
            get  { return (Boolean)is_humidity_controlledVar.Value; }
            set  { is_humidity_controlledVar.Value = value; }
        }

        public String humidity_controlled_notes
        {
            get  { return (String)humidity_controlled_notesVar.Value; }
            set  { humidity_controlled_notesVar.Value = value; }
        }

        public Boolean check_humidity_status
        {
            get  { return (Boolean)check_humidity_statusVar.Value; }
            set  { check_humidity_statusVar.Value = value; }
        }

        public Boolean photographed_labels
        {
            get  { return (Boolean)photographed_labelsVar.Value; }
            set  { photographed_labelsVar.Value = value; }
        }

        public String humidity_status_notes
        {
            get  { return (String)humidity_status_notesVar.Value; }
            set  { humidity_status_notesVar.Value = value; }
        }

        public String photographed_label_notes
        {
            get  { return (String)photographed_label_notesVar.Value; }
            set  { photographed_label_notesVar.Value = value; }
        }

        public String agentname
        {
            get  { return (String)agentnameVar.Value; }
            set  { agentnameVar.Value = value; }
        }

        public String internalcomment
        {
            get  { return (String)internalcommentVar.Value; }
            set  { internalcommentVar.Value = value; }
        }

        public Boolean has_problem
        {
            get  { return (Boolean)has_problemVar.Value; }
            set  { has_problemVar.Value = value; }
        }

        public String problem_notes
        {
            get  { return (String)problem_notesVar.Value; }
            set  { problem_notesVar.Value = value; }
        }

        public String part_package_notes
        {
            get  { return (String)part_package_notesVar.Value; }
            set  { part_package_notesVar.Value = value; }
        }

        public String parts_per_package
        {
            get  { return (String)parts_per_packageVar.Value; }
            set  { parts_per_packageVar.Value = value; }
        }

        public Boolean lead_free
        {
            get  { return (Boolean)lead_freeVar.Value; }
            set  { lead_freeVar.Value = value; }
        }

        public Boolean lead_free_pass
        {
            get  { return (Boolean)lead_free_passVar.Value; }
            set  { lead_free_passVar.Value = value; }
        }

        public Boolean lead_free_na
        {
            get  { return (Boolean)lead_free_naVar.Value; }
            set  { lead_free_naVar.Value = value; }
        }

        public Boolean has_test_docs
        {
            get  { return (Boolean)has_test_docsVar.Value; }
            set  { has_test_docsVar.Value = value; }
        }

        public String test_performed
        {
            get  { return (String)test_performedVar.Value; }
            set  { test_performedVar.Value = value; }
        }

        public Int64 qty_tested
        {
            get  { return (Int64)qty_testedVar.Value; }
            set  { qty_testedVar.Value = value; }
        }

        public Int64 qty_passed
        {
            get  { return (Int64)qty_passedVar.Value; }
            set  { qty_passedVar.Value = value; }
        }

        public Int64 qty_failed
        {
            get  { return (Int64)qty_failedVar.Value; }
            set  { qty_failedVar.Value = value; }
        }

        public String initials
        {
            get  { return (String)initialsVar.Value; }
            set  { initialsVar.Value = value; }
        }

        public String test_company
        {
            get  { return (String)test_companyVar.Value; }
            set  { test_companyVar.Value = value; }
        }

        public Boolean pre_photo_weight
        {
            get  { return (Boolean)pre_photo_weightVar.Value; }
            set  { pre_photo_weightVar.Value = value; }
        }

        public String pre_photo_weight_notes
        {
            get  { return (String)pre_photo_weight_notesVar.Value; }
            set  { pre_photo_weight_notesVar.Value = value; }
        }

        public Boolean photos_in_box
        {
            get  { return (Boolean)photos_in_boxVar.Value; }
            set  { photos_in_boxVar.Value = value; }
        }

        public String photos_in_box_notes
        {
            get  { return (String)photos_in_box_notesVar.Value; }
            set  { photos_in_box_notesVar.Value = value; }
        }

        public Boolean photos_include_leads
        {
            get  { return (Boolean)photos_include_leadsVar.Value; }
            set  { photos_include_leadsVar.Value = value; }
        }

        public String photos_include_leads_notes
        {
            get  { return (String)photos_include_leads_notesVar.Value; }
            set  { photos_include_leads_notesVar.Value = value; }
        }

        public Boolean leaving_photos
        {
            get  { return (Boolean)leaving_photosVar.Value; }
            set  { leaving_photosVar.Value = value; }
        }

        public String leaving_photos_notes
        {
            get  { return (String)leaving_photos_notesVar.Value; }
            set  { leaving_photos_notesVar.Value = value; }
        }

        public String processor_name
        {
            get  { return (String)processor_nameVar.Value; }
            set  { processor_nameVar.Value = value; }
        }

        public Boolean datasheet_analysis
        {
            get  { return (Boolean)datasheet_analysisVar.Value; }
            set  { datasheet_analysisVar.Value = value; }
        }

        public String datasheet_analysis_notes
        {
            get  { return (String)datasheet_analysis_notesVar.Value; }
            set  { datasheet_analysis_notesVar.Value = value; }
        }

        public Boolean ocm_verification
        {
            get  { return (Boolean)ocm_verificationVar.Value; }
            set  { ocm_verificationVar.Value = value; }
        }

        public String ocm_verification_notes
        {
            get  { return (String)ocm_verification_notesVar.Value; }
            set  { ocm_verification_notesVar.Value = value; }
        }

        public Boolean gold_standard
        {
            get  { return (Boolean)gold_standardVar.Value; }
            set  { gold_standardVar.Value = value; }
        }

        public String gold_standard_notes
        {
            get  { return (String)gold_standard_notesVar.Value; }
            set  { gold_standard_notesVar.Value = value; }
        }

        public Boolean calibrations_measured
        {
            get  { return (Boolean)calibrations_measuredVar.Value; }
            set  { calibrations_measuredVar.Value = value; }
        }

        public String calibrations_measured_notes
        {
            get  { return (String)calibrations_measured_notesVar.Value; }
            set  { calibrations_measured_notesVar.Value = value; }
        }

        public Boolean lot_code_match
        {
            get  { return (Boolean)lot_code_matchVar.Value; }
            set  { lot_code_matchVar.Value = value; }
        }

        public String lot_code_notes
        {
            get  { return (String)lot_code_notesVar.Value; }
            set  { lot_code_notesVar.Value = value; }
        }

        public Boolean country_match
        {
            get  { return (Boolean)country_matchVar.Value; }
            set  { country_matchVar.Value = value; }
        }

        public Boolean country_notes
        {
            get  { return (Boolean)country_notesVar.Value; }
            set  { country_notesVar.Value = value; }
        }

        public String new_option
        {
            get  { return (String)new_optionVar.Value; }
            set  { new_optionVar.Value = value; }
        }

        public String condition_option
        {
            get  { return (String)condition_optionVar.Value; }
            set  { condition_optionVar.Value = value; }
        }

        public String marking_permanency_option
        {
            get  { return (String)marking_permanency_optionVar.Value; }
            set  { marking_permanency_optionVar.Value = value; }
        }

        public String data_sheet_review_option
        {
            get  { return (String)data_sheet_review_optionVar.Value; }
            set  { data_sheet_review_optionVar.Value = value; }
        }

        public String leads_contact_option
        {
            get  { return (String)leads_contact_optionVar.Value; }
            set  { leads_contact_optionVar.Value = value; }
        }

        public String alteration_option
        {
            get  { return (String)alteration_optionVar.Value; }
            set  { alteration_optionVar.Value = value; }
        }

        public String possible_remark_option
        {
            get  { return (String)possible_remark_optionVar.Value; }
            set  { possible_remark_optionVar.Value = value; }
        }

        public String excess_option
        {
            get  { return (String)excess_optionVar.Value; }
            set  { excess_optionVar.Value = value; }
        }

        public String insertion_option
        {
            get  { return (String)insertion_optionVar.Value; }
            set  { insertion_optionVar.Value = value; }
        }

        public String maynotbenew_option
        {
            get  { return (String)maynotbenew_optionVar.Value; }
            set  { maynotbenew_optionVar.Value = value; }
        }

        public String counterfeit_option
        {
            get  { return (String)counterfeit_optionVar.Value; }
            set  { counterfeit_optionVar.Value = value; }
        }

        public String doesnotmatchdatasheet_option
        {
            get  { return (String)doesnotmatchdatasheet_optionVar.Value; }
            set  { doesnotmatchdatasheet_optionVar.Value = value; }
        }

        public String very_poor_quality_option
        {
            get  { return (String)very_poor_quality_optionVar.Value; }
            set  { very_poor_quality_optionVar.Value = value; }
        }

        public String remark_option
        {
            get  { return (String)remark_optionVar.Value; }
            set  { remark_optionVar.Value = value; }
        }

        public String option_summary
        {
            get  { return (String)option_summaryVar.Value; }
            set  { option_summaryVar.Value = value; }
        }

        public Boolean passed_option
        {
            get  { return (Boolean)passed_optionVar.Value; }
            set  { passed_optionVar.Value = value; }
        }

        public String internal_comment
        {
            get  { return (String)internal_commentVar.Value; }
            set  { internal_commentVar.Value = value; }
        }

        public Boolean tier_1_pass
        {
            get  { return (Boolean)tier_1_passVar.Value; }
            set  { tier_1_passVar.Value = value; }
        }

        public Boolean tier_2_pass
        {
            get  { return (Boolean)tier_2_passVar.Value; }
            set  { tier_2_passVar.Value = value; }
        }

        public Boolean tier_3_pass
        {
            get  { return (Boolean)tier_3_passVar.Value; }
            set  { tier_3_passVar.Value = value; }
        }

        public Boolean use_tier_1
        {
            get  { return (Boolean)use_tier_1Var.Value; }
            set  { use_tier_1Var.Value = value; }
        }

        public Boolean use_tier_2
        {
            get  { return (Boolean)use_tier_2Var.Value; }
            set  { use_tier_2Var.Value = value; }
        }

        public Boolean use_tier_3
        {
            get  { return (Boolean)use_tier_3Var.Value; }
            set  { use_tier_3Var.Value = value; }
        }

        public Boolean pin_correlation
        {
            get  { return (Boolean)pin_correlationVar.Value; }
            set  { pin_correlationVar.Value = value; }
        }

        public Boolean datasheet_verification
        {
            get  { return (Boolean)datasheet_verificationVar.Value; }
            set  { datasheet_verificationVar.Value = value; }
        }

        public Boolean functional
        {
            get  { return (Boolean)functionalVar.Value; }
            set  { functionalVar.Value = value; }
        }

        public Boolean dc_electrical
        {
            get  { return (Boolean)dc_electricalVar.Value; }
            set  { dc_electricalVar.Value = value; }
        }

        public String po_number
        {
            get  { return (String)po_numberVar.Value; }
            set  { po_numberVar.Value = value; }
        }

        public String service_number
        {
            get  { return (String)service_numberVar.Value; }
            set  { service_numberVar.Value = value; }
        }

        public String vendor_name
        {
            get  { return (String)vendor_nameVar.Value; }
            set  { vendor_nameVar.Value = value; }
        }

        public Boolean packing_slip_date_yn
        {
            get  { return (Boolean)packing_slip_date_ynVar.Value; }
            set  { packing_slip_date_ynVar.Value = value; }
        }

        public String packing_slip_date_notes
        {
            get  { return (String)packing_slip_date_notesVar.Value; }
            set  { packing_slip_date_notesVar.Value = value; }
        }

        public Boolean packing_slip_mfg_yn
        {
            get  { return (Boolean)packing_slip_mfg_ynVar.Value; }
            set  { packing_slip_mfg_ynVar.Value = value; }
        }

        public String packing_slip_mfg_notes
        {
            get  { return (String)packing_slip_mfg_notesVar.Value; }
            set  { packing_slip_mfg_notesVar.Value = value; }
        }

        public Boolean packing_slip_cost_yn
        {
            get  { return (Boolean)packing_slip_cost_ynVar.Value; }
            set  { packing_slip_cost_ynVar.Value = value; }
        }

        public String packing_slip_cost_notes
        {
            get  { return (String)packing_slip_cost_notesVar.Value; }
            set  { packing_slip_cost_notesVar.Value = value; }
        }

        public Boolean packing_slip_ponum_yn
        {
            get  { return (Boolean)packing_slip_ponum_ynVar.Value; }
            set  { packing_slip_ponum_ynVar.Value = value; }
        }

        public String packing_slip_ponum_notes
        {
            get  { return (String)packing_slip_ponum_notesVar.Value; }
            set  { packing_slip_ponum_notesVar.Value = value; }
        }

        public Boolean packing_slip_sonum_yn
        {
            get  { return (Boolean)packing_slip_sonum_ynVar.Value; }
            set  { packing_slip_sonum_ynVar.Value = value; }
        }

        public String packing_slip_sonum_notes
        {
            get  { return (String)packing_slip_sonum_notesVar.Value; }
            set  { packing_slip_sonum_notesVar.Value = value; }
        }

        public String country_notes_text
        {
            get  { return (String)country_notes_textVar.Value; }
            set  { country_notes_textVar.Value = value; }
        }


        //KT Refactored from RzSensible
        public Boolean parts_good_cond
        {
            get { return (Boolean)parts_good_condVar.Value; }
            set { parts_good_condVar.Value = value; }
        }

        public String parts_good_cond_notes
        {
            get { return (String)parts_good_cond_notesVar.Value; }
            set { parts_good_cond_notesVar.Value = value; }
        }

        public Boolean qty_amnt_ordered
        {
            get { return (Boolean)qty_amnt_orderedVar.Value; }
            set { qty_amnt_orderedVar.Value = value; }
        }

        public String qty_amnt_ordered_notes
        {
            get { return (String)qty_amnt_ordered_notesVar.Value; }
            set { qty_amnt_ordered_notesVar.Value = value; }
        }

        public Boolean dc_match_ordered
        {
            get { return (Boolean)dc_match_orderedVar.Value; }
            set { dc_match_orderedVar.Value = value; }
        }

        public String dc_match_ordered_notes
        {
            get { return (String)dc_match_ordered_notesVar.Value; }
            set { dc_match_ordered_notesVar.Value = value; }
        }

        public Boolean mfg_match_ordered
        {
            get { return (Boolean)mfg_match_orderedVar.Value; }
            set { mfg_match_orderedVar.Value = value; }
        }

        public String mfg_match_ordered_notes
        {
            get { return (String)mfg_match_ordered_notesVar.Value; }
            set { mfg_match_ordered_notesVar.Value = value; }
        }

        public Boolean cost_match_ordered
        {
            get { return (Boolean)cost_match_orderedVar.Value; }
            set { cost_match_orderedVar.Value = value; }
        }

        public String cost_match_ordered_notes
        {
            get { return (String)cost_match_ordered_notesVar.Value; }
            set { cost_match_ordered_notesVar.Value = value; }
        }

        public Boolean pkg_label_auth
        {
            get { return (Boolean)pkg_label_authVar.Value; }
            set { pkg_label_authVar.Value = value; }
        }

        public String pkg_label_auth_notes
        {
            get { return (String)pkg_label_auth_notesVar.Value; }
            set { pkg_label_auth_notesVar.Value = value; }
        }

        public Boolean lot_match_ordered
        {
            get { return (Boolean)lot_match_orderedVar.Value; }
            set { lot_match_orderedVar.Value = value; }
        }

        public String lot_match_ordered_notes
        {
            get { return (String)lot_match_ordered_notesVar.Value; }
            set { lot_match_ordered_notesVar.Value = value; }
        }

        public Boolean country_origin_consistent
        {
            get { return (Boolean)country_origin_consistentVar.Value; }
            set { country_origin_consistentVar.Value = value; }
        }

        public String country_origin_consistent_notes
        {
            get { return (String)country_origin_consistent_notesVar.Value; }
            set { country_origin_consistent_notesVar.Value = value; }
        }

        public Boolean signs_rework
        {
            get { return (Boolean)signs_reworkVar.Value; }
            set { signs_reworkVar.Value = value; }
        }

        public String signs_rework_notes
        {
            get { return (String)signs_rework_notesVar.Value; }
            set { signs_rework_notesVar.Value = value; }
        }

        public Boolean pass_acetone
        {
            get { return (Boolean)pass_acetoneVar.Value; }
            set { pass_acetoneVar.Value = value; }
        }

        public String pass_acetone_notes
        {
            get { return (String)pass_acetone_notesVar.Value; }
            set { pass_acetone_notesVar.Value = value; }
        }

        public Boolean original_mfg_pkg
        {
            get { return (Boolean)original_mfg_pkgVar.Value; }
            set { original_mfg_pkgVar.Value = value; }
        }

        public String original_mfg_pkg_notes
        {
            get { return (String)original_mfg_pkg_notesVar.Value; }
            set { original_mfg_pkg_notesVar.Value = value; }
        }

        public Boolean pin1_correct_loc
        {
            get { return (Boolean)pin1_correct_locVar.Value; }
            set { pin1_correct_locVar.Value = value; }
        }

        public String pin1_correct_loc_notes
        {
            get { return (String)pin1_correct_loc_notesVar.Value; }
            set { pin1_correct_loc_notesVar.Value = value; }
        }

        public Boolean micro_sanding
        {
            get { return (Boolean)micro_sandingVar.Value; }
            set { micro_sandingVar.Value = value; }
        }

        public String micro_sanding_notes
        {
            get { return (String)micro_sanding_notesVar.Value; }
            set { micro_sanding_notesVar.Value = value; }
        }

        public Boolean micro_solder
        {
            get { return (Boolean)micro_solderVar.Value; }
            set { micro_solderVar.Value = value; }
        }

        public String micro_solder_notes
        {
            get { return (String)micro_solder_notesVar.Value; }
            set { micro_solder_notesVar.Value = value; }
        }

        public Boolean order_meet_criteria
        {
            get { return (Boolean)order_meet_criteriaVar.Value; }
            set { order_meet_criteriaVar.Value = value; }
        }

        public String order_meet_criteria_notes
        {
            get { return (String)order_meet_criteria_notesVar.Value; }
            set { order_meet_criteria_notesVar.Value = value; }
        }

        public Boolean part_to_be_shipped
        {
            get { return (Boolean)part_to_be_shippedVar.Value; }
            set { part_to_be_shippedVar.Value = value; }
        }

        public String part_to_be_shipped_notes
        {
            get { return (String)part_to_be_shipped_notesVar.Value; }
            set { part_to_be_shipped_notesVar.Value = value; }
        }

        public Boolean parts_nonconfirm_material
        {
            get { return (Boolean)parts_nonconfirm_materialVar.Value; }
            set { parts_nonconfirm_materialVar.Value = value; }
        }

        public String parts_nonconfirm_material_notes
        {
            get { return (String)parts_nonconfirm_material_notesVar.Value; }
            set { parts_nonconfirm_material_notesVar.Value = value; }
        }

    }
    public partial class qualitycontrol
    {
        public static qualitycontrol New(Context x)
        {  return (qualitycontrol)x.Item("qualitycontrol"); }

        public static qualitycontrol GetById(Context x, String uid)
        { return (qualitycontrol)x.GetById("qualitycontrol", uid); }

        public static qualitycontrol QtO(Context x, String sql)
        { return (qualitycontrol)x.QtO("qualitycontrol", sql); }
    }
}
