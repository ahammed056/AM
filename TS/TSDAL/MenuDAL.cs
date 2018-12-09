using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TSEntity;

namespace TSDAL
{
    public class MenuDAL
    {

        #region [ Contructors ]

        public MenuDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region [ Methods ]

        #region [ Menu ]

        /// <summary>
        /// Get all records from database
        /// </summary>
        /// <param name="strQuery"></param>
        /// <returns></returns>
        public int ExecNonQuery(string strQuery)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    return SQLHelper.ExecuteNonQuery(con, CommandType.Text, strQuery);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all records from database
        /// </summary>
        /// <param name="strQuery"></param>
        /// <returns></returns>
        public DataSet GetDataSet(string strQuery)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    return SQLHelper.ExecuteDataset(con, CommandType.Text, strQuery);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all records from database
        /// </summary>
        /// <returns></returns>
        public DataSet GetAccessLevels()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    return SQLHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_getAccessLevels");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region [ User ]

        /// <summary>
        /// Used to Update records in database
        /// </summary>
        /// <param name="objTSBO"></param>
        /// <returns></returns>
        public int UpdateEmpPwd(string  strPwd, string strEmpId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[2];
                    par[0] = new SqlParameter("@EmpId", strEmpId);
                    par[1] = new SqlParameter("@Password", strPwd);

                    return SQLHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "USP_Update_UserPassword", par);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #endregion

    }
}
