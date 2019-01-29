using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace AM
{
    public class MysqlAsMDBCS
    {

        /// <summary>
        /// This is the Mysql connection Baby try Hard
        /// </summary>
        MySqlConnection acon = new MySqlConnection(ConfigurationManager.ConnectionStrings["mysqlAMS"].ConnectionString.ToString());
        MySqlAsmObjs objs = new MySqlAsmObjs();
        /// <summary>
        /// used to insert the products
        /// </summary>
        /// <param name="mso_products"></param>
        /// <returns></returns>
        public int _insert_product_info(MySqlAsmObjs mso_products)
        {
            try
            {
                int result = 0;
                {
                    MySqlCommand cmd = new MySqlCommand("pro_insert_product_info", acon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("@name", mso_products.Pr_Name));
                    cmd.Parameters.Add(new MySqlParameter("@createdby", mso_products.Pr_createdby));
                    acon.Open();
                    result = cmd.ExecuteNonQuery();
                    acon.Close();
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                acon.Close();
            }


        }
        /// <summary>
        /// used to insert the products types
        /// </summary>
        /// <param name="mso_products"></param>
        /// <returns></returns>
        public int _insert_product_type_info(MySqlAsmObjs mso_products)
        {
            try
            {
                int result = 0;
                {
                    MySqlCommand cmd = new MySqlCommand("pro_insert_product_type_info", acon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("@type_name", mso_products.Pr_type_Name));
                    cmd.Parameters.Add(new MySqlParameter("@pro_id", mso_products.Prfk_id));
                    cmd.Parameters.Add(new MySqlParameter("@creby", mso_products.Pr_type_created_by));
                    acon.Open();
                    result = cmd.ExecuteNonQuery();
                    acon.Close();
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                acon.Close();
            }


        }


        public DataTable _load_Asset_Products()
        {
            DataTable dt = new DataTable();
            try
            {
                acon.Open();
                MySqlCommand msc = new MySqlCommand("pro_view_products", acon);
                msc.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(msc);
                da.Fill(dt);
            }
            catch (Exception)
            {
                throw new Exception("who knows ahammed");
            }
            finally
            {
                acon.Close();
            }
            return dt;
        }

        public DataTable _load_Asset_Products_types()
        {
            DataTable dt = new DataTable();
            try
            {
                acon.Open();
                MySqlCommand msc = new MySqlCommand("pro_view_products_types", acon);
                msc.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(msc);
                da.Fill(dt);
            }
            catch
            {             
                throw new Exception("who knows ahammed");
            }
            finally
            {
                acon.Close();
            }
            return dt;
        }

        public DataTable _load_Asset_Products_types_byid(MySqlAsmObjs mys)
        {
            DataTable dt = new DataTable();
            try
            {
                acon.Open();
                MySqlCommand msc = new MySqlCommand("pro_view_products_types_byid", acon);
                msc.Parameters.Add(new MySqlParameter("pro_id", mys.Prfk_id));
                msc.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(msc);
                da.Fill(dt);
            }
            catch
            {
                throw new Exception("who knows ahammed");
            }
            finally
            {
                acon.Close();
            }
            return dt;
        }

    }
}




///use less code can u reuse
///

//public  bool IsAvailable(this MySqlConnection acon)
//{
//    try
//    {
//        acon.Open();
//       // conn.Close();
//    }
//    catch (MySqlException)
//    {
//        return false;
//    }
//    return true;
//}