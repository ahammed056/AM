using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSDAL;
using TSEntity;
using TSUtility;
using System.Data;


namespace TSBAL
{
    public class MenuBAL
    {

        #region [ Public Variables/Declarations ]

        MenuDAL objMenuDAL;

        #endregion

        #region [ Contructors ]

        public MenuBAL()
        {
            objMenuDAL = new MenuDAL();
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
                return objMenuDAL.ExecNonQuery(strQuery);
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
                return objMenuDAL.GetDataSet(strQuery);
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
        public DataTable GetDataTable(string strQuery)
        {
            try
            {
                return objMenuDAL.GetDataSet(strQuery).Tables[0];
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
                return objMenuDAL.GetAccessLevels();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region [ User ]
        /// <summary>
        /// Update records into database
        /// </summary>
        /// <param name="objTSBO"></param>
        /// <returns></returns>
        public int UpdateEmpPwd(string strPwd, string strEmpId)
        {
            try
            {
                return objMenuDAL.UpdateEmpPwd(strPwd, strEmpId);
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
