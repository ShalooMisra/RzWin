//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SensibleDAL.ef
{
    using System;
    using System.Collections.Generic;
    
    public partial class partpicture
    {
        public string unique_id { get; set; }
        public Nullable<int> grid_color { get; set; }
        public Nullable<int> icon_index { get; set; }
        public string fullpartnumber { get; set; }
        public string prefix { get; set; }
        public string basenumber { get; set; }
        public string basenumberstripped { get; set; }
        public string companyname { get; set; }
        public string contactname { get; set; }
        public string filename { get; set; }
        public string description { get; set; }
        public string linktype { get; set; }
        public string filetype { get; set; }
        public string the_partrecord_uid { get; set; }
        public string the_qualitycontrol_uid { get; set; }
        public string the_company_uid { get; set; }
        public string the_orddet_uid { get; set; }
        public string the_companycontact_uid { get; set; }
        public Nullable<System.DateTime> date_created { get; set; }
        public Nullable<System.DateTime> date_modified { get; set; }
        public byte[] picturedata { get; set; }
        public Nullable<bool> is_cofc { get; set; }
        public string the_ordhed_uid { get; set; }
        public Nullable<int> image_height { get; set; }
        public Nullable<int> image_width { get; set; }
        public byte[] thumbnail_thirty_two_square { get; set; }
        public string order_caption { get; set; }
        public string file_path { get; set; }
    }
}
