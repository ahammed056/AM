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
                    cmd.Parameters.Add(new MySqlParameter("@type_SH_name", mso_products.Pr_type_SH_name));
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
        /// <summary>
        /// used to insert the 4 fileds in the brands table
        /// </summary>
        /// <param name="mso_products"></param>
        /// <returns></returns>
        public int _insert_brands_info(MySqlAsmObjs mso_products)
        {
            try
            {
                int result = 0;
                {
                    MySqlCommand cmd = new MySqlCommand("pro_insert_brand_info", acon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("@br_name1", mso_products.Br_name));
                    cmd.Parameters.Add(new MySqlParameter("@br_pr_id1", mso_products.Pr_id));
                    cmd.Parameters.Add(new MySqlParameter("@br_prt_id1", mso_products.Prfk_id));
                    cmd.Parameters.Add(new MySqlParameter("@br_createdBy1", mso_products.Br_createdtime));
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
        ///  this used to insert the models
        /// </summary>
        /// <param name="mso_products"></param>
        /// <returns></returns>
        public int _insert_model_info(MySqlAsmObjs mso_products)
        {
            try
            {
                int result = 0;
                {
                    MySqlCommand cmd = new MySqlCommand("pro_insert_model_info", acon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("@mo_Name1", mso_products.Mo_Name));
                    cmd.Parameters.Add(new MySqlParameter("@mo_br_id1", mso_products.Mo_br_id));
                    cmd.Parameters.Add(new MySqlParameter("@mo_created_by1", mso_products.Mo_created_by));
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
        ///  this used to insert the Asset Codes
        /// </summary>
        /// <param name="mso_products"></param>
        /// <returns></returns>
        public int _insert_Asset_Code_info(MySqlAsmObjs mso_products)
        {
            try
            {
                int result = 0;
                {
                    MySqlCommand cmd = new MySqlCommand("pro_insert_AssetCode", acon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("@AS_AssetCode1", mso_products.AS_AssetCode));
                    cmd.Parameters.Add(new MySqlParameter("@prtids", mso_products.Pr_type_id));
                    cmd.Parameters.Add(new MySqlParameter("@prid", mso_products.Prfk_id));
                    cmd.Parameters.Add(new MySqlParameter("@As_cre", mso_products.As_CreatedBy));
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
        /// to insert the full Asset INformation       
        /// </summary>
        /// <returns></returns>
        /// 

        public int _insert_Asset_full_info(MySqlAsmObjs mso_products)
        {
            try
            {
                int result = 0;
                {
                    MySqlCommand cmd = new MySqlCommand("Pro_insert_Asset_full_info", acon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("@at_type1", mso_products.At_type_id));
                    cmd.Parameters.Add(new MySqlParameter("@at_subtype1", mso_products.At_subtype_id));
                    cmd.Parameters.Add(new MySqlParameter("@at_brandMake1", mso_products.At_brandMake_id));
                    cmd.Parameters.Add(new MySqlParameter("@at_model1",mso_products.At_model_id));
                    cmd.Parameters.Add(new MySqlParameter("@at_aseet_code_id1", mso_products.At_aseet_code_id));
                    cmd.Parameters.Add(new MySqlParameter("@at_Assetcode1", mso_products.At_Assetcode));
                    cmd.Parameters.Add(new MySqlParameter("@at_productNumber1", mso_products.At_productNumber));
                    cmd.Parameters.Add(new MySqlParameter("@at_purchaseNumber1", mso_products.At_purchaseNumber));
                    cmd.Parameters.Add(new MySqlParameter("@at_SerialNumber1", mso_products.At_SerialNumber));
                    cmd.Parameters.Add(new MySqlParameter("@at_voucherNumber1", mso_products.At_voucherNumber));
                    cmd.Parameters.Add(new MySqlParameter("@at_receivedDate1", mso_products.At_receivedDate));
                    cmd.Parameters.Add(new MySqlParameter("@at_wsd1", mso_products.At_wsd));
                    cmd.Parameters.Add(new MySqlParameter("@at_wed1", mso_products.At_wed));
                    cmd.Parameters.Add(new MySqlParameter("@at_cby1", mso_products.At_cby));
                    
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
       /// to insert the cartrige model
       /// </summary>
       /// <param name="mso_products"></param>
       /// <returns></returns>

        public int _insert_asset_cartridge(MySqlAsmObjs mso_products)
        {
            try
            {
                int result = 0;
                {
                    MySqlCommand cmd = new MySqlCommand("pro_insert_asset_cartridge", acon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("@Catri_Model1", mso_products.Cat_Model));
                    cmd.Parameters.Add(new MySqlParameter("@catri_createdby1", mso_products.Cat_AssetcodeID));

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
        public DataTable _load_Asset_cartridge()
        {
            DataTable dt = new DataTable();
            try
            {
                acon.Open();
                MySqlCommand msc = new MySqlCommand("pro_view_asset_cartridge", acon);
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
        public DataTable _load_Asset_Short_name(MySqlAsmObjs mys)
        {
            DataTable dt = new DataTable();
            try
            {
                acon.Open();
                MySqlCommand msc = new MySqlCommand("pro_view_shortName", acon);
                msc.Parameters.Add(new MySqlParameter("shname", mys.Pr_sh_name));
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

        //pro_view_assetCode_info_by_pr_and_prt_id

        public DataTable _view_assetCode_info_by_pr_and_prt_id(MySqlAsmObjs mys)
        {
            DataTable dt = new DataTable();
            try
            {
                acon.Open();
                MySqlCommand msc = new MySqlCommand("pro_view_assetCode_info_by_pr_and_prt_id", acon);
                msc.Parameters.Add(new MySqlParameter("prid", mys.Pr_id));
                msc.Parameters.Add(new MySqlParameter("prtid", mys.Pr_type_id));
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

        public DataTable _load_Asset_brands_byid(MySqlAsmObjs mys)
        {
            DataTable dt = new DataTable();
            try
            {
                acon.Open();
                MySqlCommand msc = new MySqlCommand("pro_view_brands_byids", acon);
                msc.Parameters.Add(new MySqlParameter("prid", mys.Pr_id));
                msc.Parameters.Add(new MySqlParameter("prtid", mys.Pr_type_id));
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

        //pro_view_brands_by_prptr_ids
        public DataTable _load_Asset_brands_byprptrid(MySqlAsmObjs mys)
        {
            DataTable dt1 = new DataTable();
            try
            {
                acon.Open();
                MySqlCommand msc = new MySqlCommand("pro_view_brands_by_prptr_ids", acon);
                msc.Parameters.Add(new MySqlParameter("prid", mys.Pr_id));
                msc.Parameters.Add(new MySqlParameter("prtid", mys.Pr_type_id));
                msc.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(msc);
                da.Fill(dt1);
            }
            catch
            {
                throw new Exception("who knows ahammed");
            }
            finally
            {
                acon.Close();
            }
            return dt1;
        }


        public DataTable _load_Asset_models_byid(MySqlAsmObjs mys)
        {
            DataTable dt = new DataTable();
            try
            {
                acon.Open();
                MySqlCommand msc = new MySqlCommand("pro_view_model_byid", acon);
                msc.Parameters.Add(new MySqlParameter("@mo_br_id1", mys.Mo_br_id));              
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

        public DataTable _load_Asset_Codes1()
        {
            DataTable dt = new DataTable();
            try
            {
                acon.Open();
                MySqlCommand msc = new MySqlCommand("pro_view_1stAssetInfo", acon);
                msc.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(msc);
                da.Fill(dt);
            }
            catch (Exception ex)
            {                
                throw new Exception("who knows ahammed",ex);
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