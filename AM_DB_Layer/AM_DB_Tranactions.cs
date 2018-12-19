using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using AM_EntityLayer;


namespace AM_DB_Layer
{
    
    public class AM_DB_Tranactions
    {
        SqlConnection amon = new SqlConnection(ConfigurationManager.ConnectionStrings["am"].ConnectionString.ToString());

        #region cpu area
        public String insertAssertid(asset_info ai)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("pro_insert_Asset_id", amon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@As_AssetCode", ai.AS_ASSETCODE));
                cmd.Parameters.Add(new SqlParameter("@As_Type", ai.AS_TYPE));
                cmd.Parameters.Add(new SqlParameter("@As_IsActive", 1));
                cmd.Parameters.Add(new SqlParameter("@As_CreatedBy", "ahammed"));
                cmd.Parameters.Add(new SqlParameter("@As_CreatedTime", DateTime.Now));
                amon.Open();
                return cmd.ExecuteScalar().ToString();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                amon.Close();
            }


        }
        public String insertCpuDetails(CPU_Details cd)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("pro_insert_cpu_details", amon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@cpu_AssetCode", cd.CPU_ASSETCODE));
                cmd.Parameters.Add(new SqlParameter("@Cpu_Product_Number", cd.CPU_PRODUCT_NUMBER));
                cmd.Parameters.Add(new SqlParameter("@Cpu_Serial_Number", cd.CPU_SERIAL_NUMBER));
                cmd.Parameters.Add(new SqlParameter("@Cpu_PR_Number", cd.CPU_PR_NUMBER));
                cmd.Parameters.Add(new SqlParameter("@Cpu_Voucher_Number", cd.CPU_VOUCHER_NUMBER));
                cmd.Parameters.Add(new SqlParameter("@Cpu_Model", cd.CPU_MODEL));
                cmd.Parameters.Add(new SqlParameter("@Cpu_Brand_Make", cd.CPU_BRAND_MAKE));
                cmd.Parameters.Add(new SqlParameter("@Cpu_Receive_Date", cd.CPU_RECEIVE_DATE));
                cmd.Parameters.Add(new SqlParameter("@Cpu_Warranty_Start_Date", cd.CPU_WARRANTY_START_DATE));
                cmd.Parameters.Add(new SqlParameter("@Cpu_Warranty_End_Date", cd.CPU_WARRANTY_END_DATE));
                cmd.Parameters.Add(new SqlParameter("@Cpu_IP_Address", cd.CPU_IP_ADDRESS));
                cmd.Parameters.Add(new SqlParameter("@Cpu_MAC_ID", cd.CPU_MAC_ID));
                cmd.Parameters.Add(new SqlParameter("@Cpu_Host_Name", cd.CPU_HOST_NAME));
                cmd.Parameters.Add(new SqlParameter("@Cpu_Domain_Name_group", cd.CPU_DOMAIN_NAME_GROUP));
                cmd.Parameters.Add(new SqlParameter("@Cpu_processor_SerialNumber", cd.CPU_SERIAL_NUMBER));
                cmd.Parameters.Add(new SqlParameter("@Cpu_processor_Model", cd.CPU_PROCESSOR_MODEL));
                // cmd.Parameters.Add(new SqlParameter("@Cpu_processor_Type", cd.CPU_PROCESSOR_TYPE)); 
                cmd.Parameters.Add(new SqlParameter("@Cpu_processor_Speed", cd.CPU_PROCESSOR_SPEED));
                cmd.Parameters.Add(new SqlParameter("@cpu_item_CreatedBy", cd.CPU_ITEM_CREATEDBY));
                amon.Open();
                return cmd.ExecuteScalar().ToString();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                amon.Close();
            }


        }
        public DataTable view_AssetId()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("pro_View_AssetID", amon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable view_AssetId_for_desktop()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("pro_View_AssetID_for_desktop", amon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable view_Cpu_details()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [AM].[dbo].[tbl_Cpu]", amon);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Domain Name Group

        public DataTable view_dng_details()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("pro_view_DomainNameGroup", amon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #endregion

        #region Monitor
        public DataTable view_moitor_brand_details()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("pro_view_DomainNameGroup", amon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }




        #endregion

        
        #region Masters

        public String insert_AssetType(asset_info ai)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("pro_insert_Asset_type", amon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@type_name", ai.AS_TYPE));
                cmd.Parameters.Add(new SqlParameter("@type_cdby", ai.AS_CREATEDBY));
                amon.Open();
                return cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                amon.Close();
            }
        }
        public String Upadte_AssetType(asset_info ai)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("pro_Update_Asset_type", amon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@type_id", ai.Asset_id));
                cmd.Parameters.Add(new SqlParameter("@type_name", ai.AS_TYPE));
                amon.Open();
                return cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                amon.Close();
            }
        }
        public DataTable view_Asset_type_grid()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select * from [tbl_M_Asset_type]", amon);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable view_Asset_type_edit_dispaly(string txt_dis)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select * from [tbl_M_Asset_type] where type_name = @type_name", amon);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.Add(new SqlParameter("@type_name", txt_dis));
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public String insert_brand_Name_cpu(CPU_Details cu)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("pro_insert_barnd_Master_cpu", amon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@bmbrand", cu.CPU_BRAND_MAKE));
                cmd.Parameters.Add(new SqlParameter("@cdby", cu.CPU_ITEM_CREATEDBY));
                amon.Open();
                return cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                amon.Close();
            }


        }
        public String Upadte_brand_Name_cpu(CPU_Details cu)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("pro_Update_brand_Name", amon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@bm_id", cu.Cpu_brand_id));
                cmd.Parameters.Add(new SqlParameter("@brand_name", cu.CPU_BRAND_MAKE));
                amon.Open();
                return cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                amon.Close();
            }
        }
        public DataTable view_Cpu_brand()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select bm_id,bm_brand from tbl_Brand_Master", amon);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable view_Cpu_brand_edit_dispaly(CPU_Details cu)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("pro_view_brand_byID", amon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@bm_id", cu.Cpu_brand_id));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

       
        public String insert_barnd_Model_cpu(CPU_Details cu)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("pro_insert_Brand_Model_Master_cpu", amon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@bm_brand_id", cu.Cpu_brand_id));
                cmd.Parameters.Add(new SqlParameter("@bm_model", cu.CPU_BRAND_MAKE));
                cmd.Parameters.Add(new SqlParameter("@cdby", cu.CPU_ITEM_CREATEDBY));
                amon.Open();
                return cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                amon.Close();
            }


        }
        public DataTable view_Cpu_brand_model()
       {

            try
            {
                SqlCommand cmd = new SqlCommand("pro_view_brand_model", amon);         
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable view_Cpu_brand_model_edit_dispaly(CPU_Details cu)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("pro_view_brand_model_byID_cpu", amon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@bm_model", cu.Cpu_model_make));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
       
        public DataTable view_Cpu_model(string bm_model)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("pro_view_Cpu_model", amon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@bm_brand_id", bm_model));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int insert_Processor_Name(CPU_Details cu)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("pro_insert_Processor_Name", amon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@processor_Name", cu.CPU_PROCESSOR_MODEL));
                cmd.Parameters.Add(new SqlParameter("@processor_createdby", cu.CPU_ITEM_CREATEDBY));             
                amon.Open();
                return (int)cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                amon.Close();
            }


        }
        public int insert_Processor_speed(CPU_Details cu)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("pro_insert_processor_speed", amon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@processor_speed", cu.CPU_PROCESSOR_SPEED));
                cmd.Parameters.Add(new SqlParameter("@processor_speed_createdby", cu.CPU_ITEM_CREATEDBY));
                cmd.Parameters.Add(new SqlParameter("@processor_speed_id", cu.Cpu_brand_id));
                amon.Open();
                return (int)cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                amon.Close();
            }


        }

        public DataTable view_processorModel_name()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("pro_view_processorName", amon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable view_processor_Speed()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("pro_view_processorspeed", amon);
                cmd.CommandType = CommandType.StoredProcedure;         
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }



       // [pro_insert_barnd_Master_monitor]

        public String insert_brand_Name_monitor(Monitor_Details mu)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("pro_insert_barnd_Master_monitor", amon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@bmbrand", mu.MO_MAKE));
                cmd.Parameters.Add(new SqlParameter("@cdby", mu.MO_CREATEDBY));
                amon.Open();
                return cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                amon.Close();
            }
        }
        //public String Upadte_brand_Name_cpu(CPU_Details cu)
        //{
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("pro_Update_brand_Name", amon);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add(new SqlParameter("@bm_id", cu.Cpu_brand_id));
        //        cmd.Parameters.Add(new SqlParameter("@brand_name", cu.CPU_BRAND_MAKE));
        //        amon.Open();
        //        return cmd.ExecuteScalar().ToString();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        amon.Close();
        //    }
        //}
        //public DataTable view_Cpu_brand()
        //{
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("select bm_id,bm_brand from tbl_Brand_Master", amon);
        //        cmd.CommandType = CommandType.Text;
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);
        //        return dt;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        //public DataTable view_Cpu_brand_edit_dispaly(CPU_Details cu)
        //{
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("pro_view_brand_byID", amon);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add(new SqlParameter("@bm_id", cu.Cpu_brand_id));
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);
        //        return dt;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        #endregion


    }
}
