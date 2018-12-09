using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TSEntity;
using TSUtility;

namespace TSDAL
{
    public class EmailConfigurationDAL
    {

        #region [ Contructors ]

        public EmailConfigurationDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Used to Save records into database
        /// </summary>
        /// <param name="objEmailConfigurationBO"></param>
        /// <returns></returns>
        public int SaveConfiguration(EmailConfigurationBO objEmailConfigurationBO)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[4];

                    par[0] = new SqlParameter("@Module", objEmailConfigurationBO.Module);
                    par[1] = new SqlParameter("@ApprovalType", objEmailConfigurationBO.ApprovalType);
                    par[2] = new SqlParameter("@EmailID", objEmailConfigurationBO.EmailID);
                    par[3] = new SqlParameter("@CreatedBy", objEmailConfigurationBO.CreatedBy);
                    return SQLHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "sp_ITCMDB_Insert_EmailMaster", par);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Used to Update records into database
        /// </summary>
        /// <param name="objEmailConfigurationBO"></param>
        /// <returns></returns>
        public int UpdateConfiguration(EmailConfigurationBO objEmailConfigurationBO)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[4];

                    par[0] = new SqlParameter("@Module", objEmailConfigurationBO.Module);
                    par[1] = new SqlParameter("@ApprovalType", objEmailConfigurationBO.ApprovalType);
                    par[2] = new SqlParameter("@EmailID", objEmailConfigurationBO.EmailID);
                    par[3] = new SqlParameter("@ModifiedBy", objEmailConfigurationBO.ModifiedBy);
                    return SQLHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "sp_ITCMDB_Update_EmailMaster", par);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Used to Check records into database
        /// </summary>
        /// <param name="objEmailConfigurationBO"></param>
        /// <returns></returns>
        public DataSet CheckConfiguration(EmailConfigurationBO objEmailConfigurationBO)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[3];

                    par[0] = new SqlParameter("@Module", objEmailConfigurationBO.Module);
                    par[1] = new SqlParameter("@ApprovalType", objEmailConfigurationBO.ApprovalType);
                    par[2] = new SqlParameter("@EmailID", objEmailConfigurationBO.EmailID);
                    return SQLHelper.ExecuteDataset(con, CommandType.StoredProcedure, "sp_ITCMDB_Check_EmailMaster", par);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EmailConfigurationBO> GetConfiguration(string Module)
        {
            try
            {
                List<EmailConfigurationBO> objEmailConfigurationBOList = new List<EmailConfigurationBO>();
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[1];
                    par[0] = new SqlParameter("@Module", Module);
                    using (SqlDataReader dr = SQLHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_ITCMDB_Get_EmailMaster", par))
                    {
                        while (dr.Read())
                        {
                            EmailConfigurationBO objEmailConfigurationBO = new EmailConfigurationBO();
                            objEmailConfigurationBO.ApprovalType = SQLHelper.CheckStringNull(dr["ApprovalType"]);
                            objEmailConfigurationBO.EmailID = SQLHelper.CheckStringNull(dr["EmailID"]);
                            objEmailConfigurationBOList.Add(objEmailConfigurationBO);
                        }
                    }
                }
                return objEmailConfigurationBOList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}
