using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace AM
{
    public class printers    
    {
        /// <summary>
        /// SQL Connection for am2
        /// </summary>
        SqlConnection amons = new SqlConnection(ConfigurationManager.ConnectionStrings["am"].ConnectionString.ToString());

        public int insert()
        {
            int i = 0;



            return i;
        }

    }
}