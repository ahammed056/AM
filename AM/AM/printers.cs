using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;


namespace AM
{
    public class printers    
    {
        /// <summary>
        /// SQL Connection for am2
        /// </summary>
        MySqlConnection pcon = new MySqlConnection(ConfigurationManager.ConnectionStrings["mysqlAMS"].ConnectionString.ToString());

        public int insert()
        {
            int i = 0;



            return i;
        }


        /// <summary>
        /// _insert_Asset_printer_info
        /// </summary>
        /// <param name="mso_products"></param>
        /// <returns></returns>
        public int _insert_Asset_printer_info(MySqlAsmObjs mso_products)
        {
            try
            {
                int result = 0;
                {
                    MySqlCommand cmd = new MySqlCommand("Pro_insert_Asset_full_info", pcon);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add(new MySqlParameter("@at_aseet_code_id1", mso_products.At_aseet_code_id));
                    cmd.Parameters.Add(new MySqlParameter("@at_Assetcode1", mso_products.At_Assetcode));

                    pcon.Open();
                    result = cmd.ExecuteNonQuery();
                    pcon.Close();
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                pcon.Close();
            }


        }

    }
}