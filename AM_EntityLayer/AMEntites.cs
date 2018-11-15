using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM_EntityLayer
{
    #region Desktop Entities

    public class asset_info
    {
        public int Asset_id { get; set; }
        private String as_assetcode; public String AS_ASSETCODE { get { return as_assetcode; } set { as_assetcode = value; } }
        private String as_type; public String AS_TYPE { get { return as_type; } set { as_type = value; } }
        private Boolean as_isactive; public Boolean AS_ISACTIVE { get { return as_isactive; } set { as_isactive = value; } }
        private String as_createdby; public String AS_CREATEDBY { get { return as_createdby; } set { as_createdby = value; } }
        private DateTime as_createdtime; public DateTime AS_CREATEDTIME { get { return as_createdtime; } set { as_createdtime = value; } }
    }

    public class CPU_Details
    {
        private Int32 cpu_am_id; public Int32 CPU_AM_ID { get { return cpu_am_id; } set { cpu_am_id = value; } }
        private Int32 cpu_brand_id; public Int32 Cpu_brand_id{ get { return cpu_brand_id; }  set { cpu_brand_id = value; }}
        private String cpu_assetcode; public String CPU_ASSETCODE { get { return cpu_assetcode; } set { cpu_assetcode = value; } }
        private String cpu_product_number; public String CPU_PRODUCT_NUMBER { get { return cpu_product_number; } set { cpu_product_number = value; } }
        private String cpu_serial_number; public String CPU_SERIAL_NUMBER { get { return cpu_serial_number; } set { cpu_serial_number = value; } }
        private String cpu_pr_number; public String CPU_PR_NUMBER { get { return cpu_pr_number; } set { cpu_pr_number = value; } }
        private String cpu_voucher_number; public String CPU_VOUCHER_NUMBER { get { return cpu_voucher_number; } set { cpu_voucher_number = value; } }
        private String cpu_brand_make; public String CPU_BRAND_MAKE { get { return cpu_brand_make; } set { cpu_brand_make = value; } }
        private String cpu_model; public String CPU_MODEL { get { return cpu_model; } set { cpu_model = value; } }
        private DateTime cpu_receive_date; public DateTime CPU_RECEIVE_DATE { get { return cpu_receive_date; } set { cpu_receive_date = value; } }
        private DateTime cpu_warranty_start_date; public DateTime CPU_WARRANTY_START_DATE { get { return cpu_warranty_start_date; } set { cpu_warranty_start_date = value; } }
        private DateTime cpu_warranty_end_date; public DateTime CPU_WARRANTY_END_DATE { get { return cpu_warranty_end_date; } set { cpu_warranty_end_date = value; } }
        private String cpu_ip_address; public String CPU_IP_ADDRESS { get { return cpu_ip_address; } set { cpu_ip_address = value; } }
        private String cpu_mac_id; public String CPU_MAC_ID { get { return cpu_mac_id; } set { cpu_mac_id = value; } }
        private String cpu_host_name; public String CPU_HOST_NAME { get { return cpu_host_name; } set { cpu_host_name = value; } }
        private String cpu_domain_name_group; public String CPU_DOMAIN_NAME_GROUP { get { return cpu_domain_name_group; } set { cpu_domain_name_group = value; } }
        private String cpu_processor_serialnumber; public String CPU_PROCESSOR_SERIALNUMBER { get { return cpu_processor_serialnumber; } set { cpu_processor_serialnumber = value; } }
        private String cpu_processor_model; public String CPU_PROCESSOR_MODEL { get { return cpu_processor_model; } set { cpu_processor_model = value; } }
        private String cpu_processor_type; public String CPU_PROCESSOR_TYPE { get { return cpu_processor_type; } set { cpu_processor_type = value; } }
        private String cpu_processor_speed; public String CPU_PROCESSOR_SPEED { get { return cpu_processor_speed; } set { cpu_processor_speed = value; } }
        private String cpu_item_createdby; public String CPU_ITEM_CREATEDBY { get { return cpu_item_createdby; } set { cpu_item_createdby = value; } }
        private DateTime cpu_item_createdtime; public DateTime CPU_ITEM_CREATEDTIME { get { return cpu_item_createdtime; } set { cpu_item_createdtime = value; } }
        private String cpu_remarks; public String CPU_REMARKS { get { return cpu_remarks; } set { cpu_remarks = value; } }
        private Boolean cpu_isactive; public Boolean CPU_ISACTIVE { get { return cpu_isactive; } set { cpu_isactive = value; } }
        private DateTime cpu_isrepairdate; public DateTime CPU_ISREPAIRDATE { get { return cpu_isrepairdate; } set { cpu_isrepairdate = value; } }
    }
    public class Monitor_Details
    {
        private Int32 mo_id; public Int32 MO_ID { get { return mo_id; } set { mo_id = value; } }
        private String mo_assetcode; public String MO_ASSETCODE { get { return mo_assetcode; } set { mo_assetcode = value; } }
        private String mo_make; public String MO_MAKE { get { return mo_make; } set { mo_make = value; } }
        private String mo_model; public String MO_MODEL { get { return mo_model; } set { mo_model = value; } }
        private String mo_productno; public String MO_PRODUCTNO { get { return mo_productno; } set { mo_productno = value; } }
        private String mo_serialnumber; public String MO_SERIALNUMBER { get { return mo_serialnumber; } set { mo_serialnumber = value; } }
        private DateTime mo_receiveddate; public DateTime MO_RECEIVEDDATE { get { return mo_receiveddate; } set { mo_receiveddate = value; } }
        private String mo_goodsissuedvoucher; public String MO_GOODSISSUEDVOUCHER { get { return mo_goodsissuedvoucher; } set { mo_goodsissuedvoucher = value; } }
        private String mo_prno; public String MO_PRNO { get { return mo_prno; } set { mo_prno = value; } }
        private String mo_warrentystartdate; public String MO_WARRENTYSTARTDATE { get { return mo_warrentystartdate; } set { mo_warrentystartdate = value; } }
        private String mo_warrentyenddate; public String MO_WARRENTYENDDATE { get { return mo_warrentyenddate; } set { mo_warrentyenddate = value; } }
        private Boolean mo_isvalid; public Boolean MO_ISVALID { get { return mo_isvalid; } set { mo_isvalid = value; } }
        private String mo_createdby; public String MO_CREATEDBY { get { return mo_createdby; } set { mo_createdby = value; } }
        private DateTime mo_createdtime; public DateTime MO_CREATEDTIME { get { return mo_createdtime; } set { mo_createdtime = value; } }
        private Boolean mo_isrepair; public Boolean MO_ISREPAIR { get { return mo_isrepair; } set { mo_isrepair = value; } }
        private DateTime mo_repairdate; public DateTime MO_REPAIRDATE { get { return mo_repairdate; } set { mo_repairdate = value; } }
        private String mo_remarks; public String MO_REMARKS { get { return mo_remarks; } set { mo_remarks = value; } }
    }
    public class KeyBoard_Details
    {



    }
    public class Mouse_Details
    {




    } 
    #endregion
}

namespace Am_DBlAYER
{
    public class AMCPUTASK
    {




    }
}