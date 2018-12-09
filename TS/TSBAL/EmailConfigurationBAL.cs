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
    public class EmailConfigurationBAL
    {
        #region [ Public Variables/Declarations ]

        EmailConfigurationDAL objEmailConfigurationDAL;

        #endregion

        #region [ Contructors ]

        public EmailConfigurationBAL()
        {
            objEmailConfigurationDAL = new EmailConfigurationDAL();
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Save records into database
        /// </summary>
        /// <param name="objEmailConfigurationBO"></param>
        /// <returns></returns>
        public int SaveConfiguration(EmailConfigurationBO objEmailConfigurationBO)
        {
            try
            {
                return objEmailConfigurationDAL.SaveConfiguration(objEmailConfigurationBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update record into database
        /// </summary>
        /// <param name="objEmailConfigurationBO"></param>
        /// <returns></returns>
        public int UpdateConfiguration(EmailConfigurationBO objEmailConfigurationBO)
        {
            try
            {
                return objEmailConfigurationDAL.UpdateConfiguration(objEmailConfigurationBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Check record in database
        /// </summary>
        /// <param name="objEmailConfigurationBO"></param>
        /// <returns></returns>
        public DataSet CheckConfiguration(EmailConfigurationBO objEmailConfigurationBO)
        {
            try
            {
                return objEmailConfigurationDAL.CheckConfiguration(objEmailConfigurationBO);
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
        public List<EmailConfigurationBO> GetConfiguration(string Module)
        {
            try
            {
                return objEmailConfigurationDAL.GetConfiguration(Module);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
