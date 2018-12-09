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
    public class ITTSDAL
    {
        #region [ Contructors ]

        public ITTSDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region [ Methods ]

        #region [ Employee Records ]

        /// <summary>
        /// Used to Save records into database
        /// </summary>
        /// <param name="objTSBO"></param>
        /// <returns></returns>
        public int SaveEmpEffDtls(TSBO objTSBO)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[8];
                    par[0] = new SqlParameter("@EmpId", objTSBO.EmpId);
                    par[1] = new SqlParameter("@TaskId", objTSBO.TaskId);
                    par[2] = new SqlParameter("@AppId", objTSBO.ApplicationId);
                    par[3] = new SqlParameter("@Description", objTSBO.Description);
                    par[4] = new SqlParameter("@TSDate", objTSBO.TSDate);
                    par[5] = new SqlParameter("@TSHrs", objTSBO.TSHrs);
                    par[6] = new SqlParameter("@CreatedBy", objTSBO.CreatedBy);
                    par[7] = new SqlParameter("@EmpName", objTSBO.EmpName);
                    return SQLHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "sp_ITTS_Insert_EMPEffort", par);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Used to Update records in database
        /// </summary>
        /// <param name="objTSBO"></param>
        /// <returns></returns>
        public int UpdateEmpEffDtls(TSBO objTSBO)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[8];
                    par[0] = new SqlParameter("@EmpId", objTSBO.EmpId);
                    par[1] = new SqlParameter("@TaskId", objTSBO.TaskId);
                    par[2] = new SqlParameter("@AppId", objTSBO.ApplicationId);
                    par[3] = new SqlParameter("@Description", objTSBO.Description);
                    par[4] = new SqlParameter("@TSDate", objTSBO.TSDate);
                    par[5] = new SqlParameter("@TSHrs", objTSBO.TSHrs);
                    par[6] = new SqlParameter("@ModifiedBy", objTSBO.ModifiedBy);
                    par[7] = new SqlParameter("@TSId", objTSBO.TSId);
                    return SQLHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "sp_ITTS_Update_EmpEffrtDtls", par);
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
        /// <param name="objTSBO"></param>
        /// <returns></returns>
        public DataSet CheckEmpEffDtls(TSBO objTSBO)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[2];
                    par[0] = new SqlParameter("@EmpId", objTSBO.EmpId);
                    par[1] = new SqlParameter("@TSDate", objTSBO.TSDate);
                    //par[2] = new SqlParameter("@TSFlag", objTSBO.TSFlag);
                    return SQLHelper.ExecuteDataset(con, CommandType.StoredProcedure, "sp_ITTS_Check_EffrtDtls", par);
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
        /// <param name="objTSBO"></param>
        /// <returns></returns>
        public TSBO GetEmpEfftDtls(TSBO objTSBO)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[1];
                    par[0] = new SqlParameter("@TSId", objTSBO.TSId);
                    using (SqlDataReader dr = SQLHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_ITTS_Get_TSbyID", par))
                    {
                        while (dr.Read())
                        {
                            objTSBO.TSDate = Convert.ToDateTime(SQLHelper.CheckStringNull(dr["TSDate"]));
                            objTSBO.TaskId = SQLHelper.CheckStringNull(dr["TaskId"]);
                            objTSBO.TaskName = SQLHelper.CheckStringNull(dr["TaskName"]);
                            objTSBO.ApplicationId = SQLHelper.CheckStringNull(dr["ApplicationId"]);
                            objTSBO.ApplicationName = SQLHelper.CheckStringNull(dr["ApplicationName"]);
                            objTSBO.TSHrs = SQLHelper.CheckStringNull(dr["TSHrs"]);
                            objTSBO.CreatedBy = SQLHelper.CheckStringNull(dr["CreatedBy"]);
                            objTSBO.ModifiedBy = SQLHelper.CheckStringNull(dr["ModifiedBy"]);
                            objTSBO.CreatedDate = Convert.ToDateTime(SQLHelper.CheckStringNull(dr["CreatedDate"]));
                            objTSBO.ModifiedDate = Convert.ToDateTime(SQLHelper.CheckStringNull(dr["ModifiedDate"]));
                        }
                    }
                }
                return objTSBO;
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
        public List<TSBO> GetAllEmpEfforts(string SearchVal)
        {
            try
            {
                List<TSBO> objTSBOList = new List<TSBO>();
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[1];
                    par[0] = new SqlParameter("@SearchVal", SearchVal);

                    using (SqlDataReader dr = SQLHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_ITTS_Get_EmpEffrtDtls", par))
                    {
                        while (dr.Read())
                        {
                            TSBO objTSBO = new TSBO();
                            objTSBO.TSId = SQLHelper.CheckStringNull(dr["TSId"]);
                            objTSBO.EmpId = SQLHelper.CheckStringNull(dr["EmpId"]);
                            objTSBO.TaskId = SQLHelper.CheckStringNull(dr["TaskId"]);
                            objTSBO.TaskName = SQLHelper.CheckStringNull(dr["TaskName"]);
                            objTSBO.ApplicationId = SQLHelper.CheckStringNull(dr["ApplicationId"]);
                            objTSBO.ApplicationName = SQLHelper.CheckStringNull(dr["ApplicationName"]);
                            objTSBO.Description = SQLHelper.CheckStringNull(dr["Description"]);
                            objTSBO.TSDateDisplay = SQLHelper.CheckStringNull(dr["TSDateDisplay"]);
                            objTSBO.TSHrs = SQLHelper.CheckStringNull(dr["TSHrs"]);
                            objTSBO.ModifiedBy = SQLHelper.CheckStringNull(dr["ModifiedBy"]);
                            objTSBO.CreatedDate = Convert.ToDateTime(SQLHelper.CheckDateNull(dr["CreatedDate"]));
                            objTSBO.ModifiedBy = SQLHelper.CheckStringNull(dr["ModifiedBy"]);
                            objTSBO.ModifiedDate = Convert.ToDateTime(SQLHelper.CheckDateNull(dr["ModifiedDate"]));
                            objTSBOList.Add(objTSBO);
                        }
                    }
                }
                return objTSBOList;
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
        public List<TSBO> GetFilteredEmpDtls(TSBO objTSBO)
        {
            try
            {
                List<TSBO> objTSBOList = new List<TSBO>();
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[6];

                    //par[0] = new SqlParameter("@ApprovalLevelID", objTSBO.ApprovalLevelID);
                    //par[1] = new SqlParameter("@DomainID", objTSBO.DomainID);
                    //par[2] = new SqlParameter("@LocationID", objTSBO.LocationID);
                    //par[3] = new SqlParameter("@OSTypeID", objTSBO.OSTypeID);
                    //par[4] = new SqlParameter("@ClientIP", objTSBO.ClientIP);
                    //par[5] = new SqlParameter("@Hostname", objTSBO.Hostname);
                    using (SqlDataReader dr = SQLHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_ITTS_Get_FilteredInstances", par))
                    {
                        while (dr.Read())
                        {
                            objTSBO.TSId = SQLHelper.CheckStringNull(dr["TSId"]);
                            objTSBO.TaskId = SQLHelper.CheckStringNull(dr["TaskId"]);
                            objTSBO.TaskName = SQLHelper.CheckStringNull(dr["TaskName"]);
                            objTSBO.ApplicationId = SQLHelper.CheckStringNull(dr["ApplicationId"]);
                            objTSBO.ApplicationName = SQLHelper.CheckStringNull(dr["ApplicationName"]);
                            objTSBO.Description = SQLHelper.CheckStringNull(dr["Description"]);
                            objTSBO.TSDate = Convert.ToDateTime(SQLHelper.CheckStringNull(dr["TSDate"]));
                            objTSBO.TSHrs = SQLHelper.CheckStringNull(dr["TSHrs"]);
                            objTSBO.CreatedDate = Convert.ToDateTime(SQLHelper.CheckDateNull(dr["CreatedDate"]));
                            objTSBO.ModifiedBy = SQLHelper.CheckStringNull(dr["ModifiedBy"]);
                            objTSBO.ModifiedDate = Convert.ToDateTime(SQLHelper.CheckDateNull(dr["ModifiedDate"]));
                            objTSBOList.Add(objTSBO);
                        }
                    }
                }
                return objTSBOList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Get all records from database
        /// </summary>
        /// <param name="objITDAPsBBO"></param>
        /// <returns></returns>
        public DataSet GetExportFilteredInstances(TSBO objTSBO)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[6];

                    //par[0] = new SqlParameter("@ApprovalLevelID", objTSBO.ApprovalLevelID);
                    //par[1] = new SqlParameter("@DomainID", objTSBO.DomainID);
                    //par[2] = new SqlParameter("@LocationID", objTSBO.LocationID);
                    //par[3] = new SqlParameter("@OSTypeID", objTSBO.OSTypeID);
                    //par[4] = new SqlParameter("@ClientIP", objTSBO.ClientIP);
                    //par[5] = new SqlParameter("@Hostname", objTSBO.Hostname);

                    return SQLHelper.ExecuteDataset(con, CommandType.StoredProcedure, "sp_ITTS_Get_FilteredInstancesReport", par);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<TSBO> GetTSRecords(ITTSSearchCriteria objSearch)
        {
            try
            {
                List<TSBO> newList = new List<TSBO>();

                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[3];

                    par[0] = new SqlParameter("@EmpID", objSearch.EmpId);
                    par[1] = new SqlParameter("@FromDate", objSearch.FromDate);
                    par[2] = new SqlParameter("@ToDate", objSearch.ToDate);

                    using (SqlDataReader dr = SQLHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_ITTS_Get_FilterdRpt", par))
                    {
                        while (dr.Read())
                        {
                            TSBO objTSBO = new TSBO();
                            TSSetProperties(objTSBO, dr);
                            newList.Add(objTSBO);
                        }
                    }
                }
                return newList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void TSSetProperties(TSBO objTSBO, SqlDataReader dr)
        {
            objTSBO.TSDate = Convert.ToDateTime(SQLHelper.CheckStringNull(dr["TSDate"]));
            objTSBO.TSDateDisplay = SQLHelper.CheckStringNull(dr["TSDateDisplay"]);
            objTSBO.EmpId = SQLHelper.CheckStringNull(dr["EMPId"]);
            objTSBO.EmpName = SQLHelper.CheckStringNull(dr["EMPName"]);
            objTSBO.TaskName = SQLHelper.CheckStringNull(dr["TaskName"]);
            objTSBO.ApplicationName = SQLHelper.CheckStringNull(dr["ApplicationName"]);
            objTSBO.Description = SQLHelper.CheckStringNull(dr["Description"]);
            objTSBO.TSHrs = SQLHelper.CheckStringNull(dr["TSHrs"]);
            objTSBO.CreatedDate = Convert.ToDateTime(SQLHelper.CheckDateNull(dr["CreatedDate"]));
            objTSBO.ModifiedDate = Convert.ToDateTime(SQLHelper.CheckDateNull(dr["ModifiedDate"]));
        }

        public DataSet GetTSRptExprt(ITTSSearchCriteria objSearch)
        {
            try
            {
                List<TSBO> newList = new List<TSBO>();

                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[3];

                    par[0] = new SqlParameter("@EmpID", objSearch.EmpId);
                    par[1] = new SqlParameter("@FromDate", objSearch.FromDate);
                    par[2] = new SqlParameter("@ToDate", objSearch.ToDate);

                    return SQLHelper.ExecuteDataset(con, CommandType.StoredProcedure, "sp_ITTS_Get_FilterdRptExprt", par);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region [ Masters ]

        /// <summary>
        /// Used to Save records into database
        /// </summary>
        /// <param name="objTSBO"></param>
        /// <returns></returns>
        public int SaveMaster(TSMasterBO objTSMasterBO)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[4];

                    par[0] = new SqlParameter("@MasterType", objTSMasterBO.MasterType);
                    par[1] = new SqlParameter("@Name", objTSMasterBO.Name);
                    par[2] = new SqlParameter("@Description", objTSMasterBO.Description);
                    par[3] = new SqlParameter("@CreatedBy", objTSMasterBO.CreatedBy);
                    return SQLHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "sp_ITTS_Insert_Master", par);
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
        /// <param name="objTSBO"></param>
        /// <returns></returns>
        public int UpdateMaster(TSMasterBO objTSMasterBO)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[5];

                    par[0] = new SqlParameter("@MasterType", objTSMasterBO.MasterType);
                    par[1] = new SqlParameter("@ID", objTSMasterBO.ID);
                    par[2] = new SqlParameter("@Name", objTSMasterBO.Name);
                    par[3] = new SqlParameter("@Description", objTSMasterBO.Description);
                    par[4] = new SqlParameter("@ModifiedBy", objTSMasterBO.ModifiedBy);
                    return SQLHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "sp_ITTS_Update_Master", par);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete record from database
        /// </summary>
        /// <param name="strMasterID"></param>
        /// <returns></returns>
        public int DeleteMaster(TSMasterBO objTSMasterBO)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[3];

                    par[0] = new SqlParameter("@MasterType", objTSMasterBO.MasterType);
                    par[1] = new SqlParameter("@ID", objTSMasterBO.ID);
                    par[2] = new SqlParameter("@ModifiedBy", objTSMasterBO.ModifiedBy);
                    return SQLHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "sp_ITDAPs_Delete_Master", par);
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
        /// <param name="objTSBO"></param>
        /// <returns></returns>
        public DataSet CheckMaster(TSMasterBO objTSMasterBO)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[2];

                    par[0] = new SqlParameter("@MasterType", objTSMasterBO.MasterType);
                    par[1] = new SqlParameter("@Name", objTSMasterBO.Name);
                    return SQLHelper.ExecuteDataset(con, CommandType.StoredProcedure, "sp_ITTS_Check_Master", par);
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
        /// <param name="objTSBO"></param>
        /// <returns></returns>
        public DataSet CheckInstances(TSMasterBO objTSMasterBO)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[2];
                    par[0] = new SqlParameter("@MasterType", objTSMasterBO.MasterType);
                    par[1] = new SqlParameter("@ID", objTSMasterBO.ID);
                    return SQLHelper.ExecuteDataset(con, CommandType.StoredProcedure, "sp_ITDAPs_Check_Instances", par);
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
        public List<TSMasterBO> GetMaster(int MasterType)
        {
            try
            {
                List<TSMasterBO> objTSMasterBOList = new List<TSMasterBO>();
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[1];
                    par[0] = new SqlParameter("@MasterType", MasterType);
                    using (SqlDataReader dr = SQLHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_ITTS_Get_Master", par))
                    {
                        while (dr.Read())
                        {
                            TSMasterBO objTSMasterBO = new TSMasterBO();
                            objTSMasterBO.ID = SQLHelper.CheckStringNull(dr["ID"]);
                            objTSMasterBO.Name = SQLHelper.CheckStringNull(dr["Name"]);
                            objTSMasterBO.Description = SQLHelper.CheckStringNull(dr["Description"]);
                            objTSMasterBO.CreatedBy = SQLHelper.CheckStringNull(dr["CreatedBy"]);
                            objTSMasterBO.CreatedDate = Convert.ToDateTime(SQLHelper.CheckDateNull(dr["CreatedDate"]));
                            objTSMasterBO.ModifiedBy = SQLHelper.CheckStringNull(dr["ModifiedBy"]);
                            objTSMasterBO.ModifiedDate = Convert.ToDateTime(SQLHelper.CheckDateNull(dr["ModifiedDate"]));
                            objTSMasterBOList.Add(objTSMasterBO);
                        }
                    }
                }
                return objTSMasterBOList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all records from database
        /// </summary>
        /// <param name="objTSBO"></param>
        /// <returns></returns>
        public DataSet GetExportMaster(int MasterType)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[1];
                    par[0] = new SqlParameter("@MasterType", MasterType);
                    return SQLHelper.ExecuteDataset(con, CommandType.StoredProcedure, "sp_ITDAPs_Get_Master", par);
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
