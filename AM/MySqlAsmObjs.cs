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
    }
}