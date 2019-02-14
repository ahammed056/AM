using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AM
{
    public class MySqlAsmObjs
    {

        #region Tbl_products

        /// <summary>
        /// Designed the  Tbl Porducts
        /// </summary>
        private int pr_id;

        public int Pr_id
        {
            get { return pr_id; }
            set { pr_id = value; }
        }
        private string pr_Name, pr_createdby, pr_sh_name;

        public string Pr_sh_name
        {
            get { return pr_sh_name; }
            set { pr_sh_name = value; }
        }

        public string Pr_createdby
        {
            get { return pr_createdby; }
            set { pr_createdby = value; }
        }

        public string Pr_Name
        {
            get { return pr_Name; }
            set { pr_Name = value; }
        }
        private DateTime pr_createdTime;

        public DateTime Pr_createdTime
        {
            get { return pr_createdTime; }
            set { pr_createdTime = value; }
        }
        private Boolean pr_isActive;

        public Boolean Pr_isActive
        {
            get { return pr_isActive; }
            set { pr_isActive = value; }
        }
        #endregion

        #region tbl_products_types
        private int pr_type_id, prfk_id;

        public int Prfk_id
        {
            get { return prfk_id; }
            set { prfk_id = value; }
        }

        public int Pr_type_id
        {
            get { return pr_type_id; }
            set { pr_type_id = value; }
        }
        private string pr_type_Name, pr_type_created_by, pr_type_SH_name;

        public string Pr_type_SH_name
        {
            get { return pr_type_SH_name; }
            set { pr_type_SH_name = value; }
        }

        public string Pr_type_created_by
        {
            get { return pr_type_created_by; }
            set { pr_type_created_by = value; }
        }

        public string Pr_type_Name
        {
            get { return pr_type_Name; }
            set { pr_type_Name = value; }
        }
        private DateTime pr_type_created_time;

        public DateTime Pr_type_created_time
        {
            get { return pr_type_created_time; }
            set { pr_type_created_time = value; }
        }
        private bool pr_type_isactive;

        public bool Pr_type_isactive
        {
            get { return pr_type_isactive; }
            set { pr_type_isactive = value; }
        }
        #endregion

        #region tbl_brands

        private int br_id, br_pr_id, br_prt_id;

        public int Br_prt_id
        {
            get { return br_prt_id; }
            set { br_prt_id = value; }
        }

        public int Br_pr_id
        {
            get { return br_pr_id; }
            set { br_pr_id = value; }
        }

        public int Br_id
        {
            get { return br_id; }
            set { br_id = value; }
        }
        private string br_name, br_createdBy;

        public string Br_createdBy
        {
            get { return br_createdBy; }
            set { br_createdBy = value; }
        }

        public string Br_name
        {
            get { return br_name; }
            set { br_name = value; }
        }
        private DateTime br_createdtime;

        public DateTime Br_createdtime
        {
            get { return br_createdtime; }
            set { br_createdtime = value; }
        }
        private bool br_isactive;

        public bool Br_isactive
        {
            get { return br_isactive; }
            set { br_isactive = value; }
        }

        #endregion

        #region tbl_models



        private int mo_id, mo_br_id;

        public int Mo_br_id
        {
            get { return mo_br_id; }
            set { mo_br_id = value; }
        }

        public int Mo_id
        {
            get { return mo_id; }
            set { mo_id = value; }
        }
        private string mo_Name, mo_created_by;

        public string Mo_created_by
        {
            get { return mo_created_by; }
            set { mo_created_by = value; }
        }

        public string Mo_Name
        {
            get { return mo_Name; }
            set { mo_Name = value; }
        }
        private DateTime mo_createdTime;

        public DateTime Mo_createdTime
        {
            get { return mo_createdTime; }
            set { mo_createdTime = value; }
        }
        private bool mo_isactive;

        public bool Mo_isactive
        {
            get { return mo_isactive; }
            set { mo_isactive = value; }
        }
        #endregion

        #region tbl_AssetCode
        private int asid, as_Type;
        public int As_Type
        {
            get { return as_Type; }
            set { as_Type = value; }
        }
        public int Asid
        {
            get { return asid; }
            set { asid = value; }
        }
        private string aS_AssetCode, as_CreatedBy;
        public string As_CreatedBy
        {
            get { return as_CreatedBy; }
            set { as_CreatedBy = value; }
        }
        public string AS_AssetCode
        {
            get { return aS_AssetCode; }
            set { aS_AssetCode = value; }
        }
        private DateTime as_CreatedTime;
        public DateTime As_CreatedTime
        {
            get { return as_CreatedTime; }
            set { as_CreatedTime = value; }
        }
        private bool as_IsActive;
        public bool As_IsActive
        {
            get { return as_IsActive; }
            set { as_IsActive = value; }
        }
        #endregion

        #region tbl_asset_ful_info

        private int asset_id, at_type_id, at_subtype_id, at_brandMake_id, at_model_id, at_aseet_code_id;

        public int Asset_id
        {
            get { return asset_id; }
            set { asset_id = value; }
        }

        public int At_type_id
        {
            get { return at_type_id; }
            set { at_type_id = value; }
        }

        public int At_subtype_id
        {
            get { return at_subtype_id; }
            set { at_subtype_id = value; }
        }

        public int At_brandMake_id
        {
            get { return at_brandMake_id; }
            set { at_brandMake_id = value; }
        }

        public int At_model_id
        {
            get { return at_model_id; }
            set { at_model_id = value; }
        }

        public int At_aseet_code_id
        {
            get { return at_aseet_code_id; }
            set { at_aseet_code_id = value; }
        }

        private string at_Assetcode, at_productNumber, at_purchaseNumber, at_SerialNumber, at_voucherNumber, at_cby;

        public string At_Assetcode
        {
            get { return at_Assetcode; }
            set { at_Assetcode = value; }
        }

        public string At_productNumber
        {
            get { return at_productNumber; }
            set { at_productNumber = value; }
        }

        public string At_purchaseNumber
        {
            get { return at_purchaseNumber; }
            set { at_purchaseNumber = value; }
        }

        public string At_SerialNumber
        {
            get { return at_SerialNumber; }
            set { at_SerialNumber = value; }
        }

        public string At_voucherNumber
        {
            get { return at_voucherNumber; }
            set { at_voucherNumber = value; }
        }

        public string At_cby
        {
            get { return at_cby; }
            set { at_cby = value; }
        }

        private DateTime at_receivedDate, at_wsd, at_wed, at_cd;

        public DateTime At_receivedDate
        {
            get { return at_receivedDate; }
            set { at_receivedDate = value; }
        }

        public DateTime At_wsd
        {
            get { return at_wsd; }
            set { at_wsd = value; }
        }

        public DateTime At_wed
        {
            get { return at_wed; }
            set { at_wed = value; }
        }

        public DateTime At_cd
        {
            get { return at_cd; }
            set { at_cd = value; }
        }

        private bool at_active;

        public bool At_active
        {
            get { return at_active; }
            set { at_active = value; }
        }

          
	#endregion


         #region tbl_Cartrige

        private int cat_ID, cat_AssetcodeID;

        public int Cat_AssetcodeID
        {
            get { return cat_AssetcodeID; }
            set { cat_AssetcodeID = value; }
        }

        public int Cat_ID
        {
            get { return cat_ID; }
            set { cat_ID = value; }
        }
        private string cat_Assetcode, cat_Createdby, cat_Model;

        public string Cat_Model
        {
            get { return cat_Model; }
            set { cat_Model = value; }
        }

        public string Cat_Createdby
        {
            get { return cat_Createdby; }
            set { cat_Createdby = value; }
        }

        public string Cat_Assetcode
        {
            get { return cat_Assetcode; }
            set { cat_Assetcode = value; }
        }
        private bool cat_Isactive;

        public bool Cat_Isactive
        {
            get { return cat_Isactive; }
            set { cat_Isactive = value; }
        }
        private DateTime cat_Createdtime;

        public DateTime Cat_Createdtime
        {
            get { return cat_Createdtime; }
            set { cat_Createdtime = value; }
        }
	#endregion



    }
}