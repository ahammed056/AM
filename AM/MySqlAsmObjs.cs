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
        private string pr_Name, pr_createdby;

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
        private string pr_type_Name, pr_type_created_by;

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
    }
}