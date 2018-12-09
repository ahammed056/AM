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
    public class ITPRODAL
    {

     #region [ Contructors ]

        public ITPRODAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region [ Methods ]

        #region [ Instances ]


        public int SaveVisitorDtls(PROBO objPROBO)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[16];
                    //par[0] = new SqlParameter("@PrId", objPROBO.PrId);
                    //par[1] = new SqlParameter("@TransId", objPROBO.TransId);
                    par[0] = new SqlParameter("@VisitorName", objPROBO.VisitorName);
                    par[1] = new SqlParameter("@FatherName", objPROBO.FatherName);
                    par[2] = new SqlParameter("@DistId", objPROBO.DistId);
                    par[3] = new SqlParameter("@MandalId", objPROBO.MandalId);
                    par[4] = new SqlParameter("@VillageId", objPROBO.VillageId);
                    par[5] = new SqlParameter("@ProofTypeId", objPROBO.ProofTypeId);
                    par[6] = new SqlParameter("@ProofId", objPROBO.ProofId);
                    par[7] = new SqlParameter("@ContactNo", objPROBO.ContactNo);
                    par[8] = new SqlParameter("@VisitDate", objPROBO.VisitDate);
                    par[9] = new SqlParameter("@NextCallDate", objPROBO.NextCallDate);
                    par[10] = new SqlParameter("@VisitPurpose", objPROBO.VisitPurpose);
                    par[11] = new SqlParameter("@Remarks", objPROBO.Remarks);
                    par[12] = new SqlParameter("@StatusId", objPROBO.StatusId);
                    par[13] = new SqlParameter("@CreatedBy", objPROBO.CreatedBy);
                    return SQLHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "sp_ITPRO_Insert_VisitorDtls", par);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public int UpdateVisitorDtls(PROBO objPROBO)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[11];

                    par[0] = new SqlParameter("@PrId", objPROBO.PrId);
                    par[1] = new SqlParameter("@TransId", objPROBO.TransId);
                    par[2] = new SqlParameter("@ProofTypeId", objPROBO.ProofTypeId);
                    par[3] = new SqlParameter("@ProofId", objPROBO.ProofId);
                    par[4] = new SqlParameter("@ContactNo", objPROBO.ContactNo);
                    par[5] = new SqlParameter("@VisitDate", objPROBO.VisitDate);
                    par[6] = new SqlParameter("@NextCallDate", objPROBO.NextCallDate);
                    par[7] = new SqlParameter("@VisitPurpose", objPROBO.VisitPurpose);
                    par[8] = new SqlParameter("@Remarks", objPROBO.Remarks);
                    par[9] = new SqlParameter("@StatusId", objPROBO.StatusId);
                    par[10] = new SqlParameter("@ModifiedBy", objPROBO.ModifiedBy);

                    return SQLHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "sp_ITPRO_Update_VisitorDtls", par);
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

        public PROBO GetVisitorDtls(PROBO objPROBO)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[1];
                    par[0] = new SqlParameter("@TransId", objPROBO.TransId);
                    using (SqlDataReader dr = SQLHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_ITPRO_Get_PRObyID", par))
                    {
                        while (dr.Read())
                        {
                            objPROBO.PrId = SQLHelper.CheckStringNull(dr["PrId"]);
                            objPROBO.TransId = SQLHelper.CheckStringNull(dr["TransId"]);
                            objPROBO.VisitorName = SQLHelper.CheckStringNull(dr["VisitorName"]);
                            objPROBO.FatherName = SQLHelper.CheckStringNull(dr["FatherName"]);
                            objPROBO.ContactNo = SQLHelper.CheckStringNull(dr["ContactNo"]);
                            objPROBO.DistId = SQLHelper.CheckStringNull(dr["DistId"]);
                            objPROBO.DistrictName = SQLHelper.CheckStringNull(dr["DistrictName"]);
                            objPROBO.MandalId = SQLHelper.CheckStringNull(dr["MandalId"]);
                            objPROBO.MandalName = SQLHelper.CheckStringNull(dr["MandalName"]);
                            objPROBO.VillageId = SQLHelper.CheckStringNull(dr["VillageId"]);
                            objPROBO.VillageName = SQLHelper.CheckStringNull(dr["VillageName"]);
                            objPROBO.ProofTypeId = SQLHelper.CheckStringNull(dr["ProofTypeId"]);
                            objPROBO.ProofTypeName = SQLHelper.CheckStringNull(dr["ProofTypeName"]);
                            objPROBO.ProofId = SQLHelper.CheckStringNull(dr["ProofId"]);
                            objPROBO.VisitDate = Convert.ToDateTime(SQLHelper.CheckDateNull(dr["VisitDate"]));
                            objPROBO.NextCallDate = Convert.ToDateTime(SQLHelper.CheckDateNull(dr["NextCallDate"]));
                            objPROBO.VisitPurpose = SQLHelper.CheckStringNull(dr["VisitPurpose"]);
                            objPROBO.Remarks = SQLHelper.CheckStringNull(dr["Remarks"]);
                            objPROBO.StatusId = Convert.ToInt32(SQLHelper.CheckStringNull(dr["StatusId"]));
                            objPROBO.StatusName = SQLHelper.CheckStringNull(dr["StatusName"]);
                            objPROBO.CreatedBy = SQLHelper.CheckStringNull(dr["CreatedBy"]);
                            objPROBO.CreatedDate = Convert.ToDateTime(SQLHelper.CheckDateNull(dr["CreatedDate"]));
                            objPROBO.ModifiedBy = SQLHelper.CheckStringNull(dr["ModifiedBy"]);
                            objPROBO.ModifiedDate = Convert.ToDateTime(SQLHelper.CheckStringNull(dr["ModifiedDate"]));
                        }
                    }
                }
                return objPROBO;
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
        public List<PROBO> GetPendingVisitDtls(string SearchVal)
        {
            try
            {
                List<PROBO> objTSBOList = new List<PROBO>();
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[1];
                    par[0] = new SqlParameter("@PrSearchVal", SearchVal);

                    using (SqlDataReader dr = SQLHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_ITPRO_Get_VisitDtls", par))
                    {
                        while (dr.Read())
                        {
                            PROBO objPROBO = new PROBO();
                            objPROBO.PrId = SQLHelper.CheckStringNull(dr["PrId"]);
                            objPROBO.TransId = SQLHelper.CheckStringNull(dr["TransId"]);
                            objPROBO.VisitorName = SQLHelper.CheckStringNull(dr["VisitorName"]);
                            objPROBO.FatherName = SQLHelper.CheckStringNull(dr["FatherName"]);
                            objPROBO.ContactNo = SQLHelper.CheckStringNull(dr["ContactNo"]);
                            objPROBO.DistId = SQLHelper.CheckStringNull(dr["DistId"]);
                            objPROBO.DistrictName = SQLHelper.CheckStringNull(dr["DistrictName"]);
                            objPROBO.MandalId = SQLHelper.CheckStringNull(dr["MandalId"]);
                            objPROBO.MandalName = SQLHelper.CheckStringNull(dr["MandalName"]);
                            objPROBO.VillageId = SQLHelper.CheckStringNull(dr["VillageId"]);
                            objPROBO.VillageName = SQLHelper.CheckStringNull(dr["VillageName"]);
                            objPROBO.ProofTypeId = SQLHelper.CheckStringNull(dr["ProofTypeId"]);
                            objPROBO.ProofTypeName = SQLHelper.CheckStringNull(dr["ProofTypeName"]);
                            objPROBO.ProofId = SQLHelper.CheckStringNull(dr["ProofId"]);
                            objPROBO.VisitDate = Convert.ToDateTime(SQLHelper.CheckDateNull(dr["VisitDate"]));
                            objPROBO.NextCallDate = Convert.ToDateTime(SQLHelper.CheckDateNull(dr["NextCallDate"]));
                            objPROBO.VisitPurpose = SQLHelper.CheckStringNull(dr["VisitPurpose"]);
                            objPROBO.Remarks = SQLHelper.CheckStringNull(dr["Remarks"]);
                            objPROBO.StatusId = Convert.ToInt32(SQLHelper.CheckStringNull(dr["StatusId"]));
                            objPROBO.StatusName = SQLHelper.CheckStringNull(dr["StatusName"]);
                            objPROBO.CreatedBy = SQLHelper.CheckStringNull(dr["CreatedBy"]);
                            objPROBO.CreatedDate = Convert.ToDateTime(SQLHelper.CheckDateNull(dr["CreatedDate"]));
                            objPROBO.ModifiedBy = SQLHelper.CheckStringNull(dr["ModifiedBy"]);
                            objPROBO.ModifiedDate = Convert.ToDateTime(SQLHelper.CheckStringNull(dr["ModifiedDate"]));
                            objTSBOList.Add(objPROBO);
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

        public List<PROBO> GetPROVisitRecords(ITPROSearchCriteria objSearch)
        {
            try
            {
                List<PROBO> newList = new List<PROBO>();

                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[3];

                    par[0] = new SqlParameter("@PrID", objSearch.EmpId);
                    par[1] = new SqlParameter("@VisitorName", objSearch.FromDate);
                    par[2] = new SqlParameter("@ContactNo", objSearch.ToDate);

                    using (SqlDataReader dr = SQLHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_ITTS_Get_FilterdRpt", par))
                    {
                        while (dr.Read())
                        {
                            PROBO objPROBO = new PROBO();
                            PROSetProperties(objPROBO, dr);
                            newList.Add(objPROBO);
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

        public void PROSetProperties(PROBO objPROBO, SqlDataReader dr)
        {
            objPROBO.PrId = SQLHelper.CheckStringNull(dr["PrId"]);
            objPROBO.TransId = SQLHelper.CheckStringNull(dr["TransId"]);
            objPROBO.VisitorName = SQLHelper.CheckStringNull(dr["VisitorName"]);
            objPROBO.FatherName = SQLHelper.CheckStringNull(dr["FatherName"]);
            objPROBO.ContactNo = SQLHelper.CheckStringNull(dr["ContactNo"]);
            objPROBO.DistId = SQLHelper.CheckStringNull(dr["DistId"]);
            objPROBO.DistrictName = SQLHelper.CheckStringNull(dr["DistrictName"]);
            objPROBO.MandalId = SQLHelper.CheckStringNull(dr["MandalId"]);
            objPROBO.MandalName = SQLHelper.CheckStringNull(dr["MandalName"]);
            objPROBO.VillageId = SQLHelper.CheckStringNull(dr["VillageId"]);
            objPROBO.VillageName = SQLHelper.CheckStringNull(dr["VillageName"]);
            objPROBO.ProofTypeId = SQLHelper.CheckStringNull(dr["ProofTypeId"]);
            objPROBO.ProofTypeName = SQLHelper.CheckStringNull(dr["ProofTypeName"]);
            objPROBO.ProofId = SQLHelper.CheckStringNull(dr["ProofId"]);
            objPROBO.VisitDate = Convert.ToDateTime(SQLHelper.CheckDateNull(dr["VisitDate"]));
            objPROBO.NextCallDate = Convert.ToDateTime(SQLHelper.CheckDateNull(dr["NextCallDate"]));
            objPROBO.VisitPurpose = SQLHelper.CheckStringNull(dr["VisitPurpose"]);
            objPROBO.Remarks = SQLHelper.CheckStringNull(dr["Remarks"]);
            objPROBO.StatusId = Convert.ToInt32(SQLHelper.CheckStringNull(dr["StatusId"]));
            objPROBO.StatusName = SQLHelper.CheckStringNull(dr["StatusName"]);
            objPROBO.CreatedBy = SQLHelper.CheckStringNull(dr["CreatedBy"]);
            objPROBO.CreatedDate = Convert.ToDateTime(SQLHelper.CheckDateNull(dr["CreatedDate"]));
            objPROBO.ModifiedBy = SQLHelper.CheckStringNull(dr["ModifiedBy"]);
            objPROBO.ModifiedDate = Convert.ToDateTime(SQLHelper.CheckStringNull(dr["ModifiedDate"]));
        }

        public DataSet GetPRORptExprt(ITTSSearchCriteria objSearch)
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
        /// <param name="objPROMasterBO"></param>
        /// <returns></returns>
        public int SaveMaster(PROMasterBO objPROMasterBO)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[6];

                    par[0] = new SqlParameter("@MasterType", objPROMasterBO.MasterType);
                    par[1] = new SqlParameter("@Name", objPROMasterBO.Name);
                    par[2] = new SqlParameter("@Description", objPROMasterBO.Description);
                    par[3] = new SqlParameter("@CreatedBy", objPROMasterBO.CreatedBy);
                    par[4] = new SqlParameter("@DistId", objPROMasterBO.DistId);
                    par[5] = new SqlParameter("@MandalId", objPROMasterBO.MandalId);
                    return SQLHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "sp_ITPRO_Insert_Master", par);
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
        public int UpdateMaster(PROMasterBO objPROMasterBO)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[7];

                    par[0] = new SqlParameter("@MasterType", objPROMasterBO.MasterType);
                    par[1] = new SqlParameter("@ID", objPROMasterBO.ID);
                    par[2] = new SqlParameter("@Name", objPROMasterBO.Name);
                    par[3] = new SqlParameter("@Description", objPROMasterBO.Description);
                    par[4] = new SqlParameter("@ModifiedBy", objPROMasterBO.ModifiedBy);
                    par[5] = new SqlParameter("@DistId", objPROMasterBO.DistId);
                    par[6] = new SqlParameter("@MandalId", objPROMasterBO.MandalId);

                    return SQLHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "sp_ITPRO_Update_Master", par);
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
        public int DeleteMaster(PROMasterBO objPROMasterBO)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[3];

                    par[0] = new SqlParameter("@MasterType", objPROMasterBO.MasterType);
                    par[1] = new SqlParameter("@ID", objPROMasterBO.ID);
                    par[2] = new SqlParameter("@ModifiedBy", objPROMasterBO.ModifiedBy);
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
        /// <param name="objPROMasterBO"></param>
        /// <returns></returns>
        public DataSet CheckMaster(PROMasterBO objPROMasterBO)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[4];

                    par[0] = new SqlParameter("@MasterType", objPROMasterBO.MasterType);
                    par[1] = new SqlParameter("@Name", objPROMasterBO.Name);
                    par[2] = new SqlParameter("@DistId", objPROMasterBO.DistId);
                    par[3] = new SqlParameter("@MandalId", objPROMasterBO.MandalId);

                    return SQLHelper.ExecuteDataset(con, CommandType.StoredProcedure, "sp_ITPRO_Check_Master", par);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet CheckVisitor(PROBO objPROBO)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[2];
                    par[0] = new SqlParameter("@VisitorName", objPROBO.VisitorName);
                    par[1] = new SqlParameter("@ContactNo", objPROBO.ContactNo);
                    return SQLHelper.ExecuteDataset(con, CommandType.StoredProcedure, "sp_ITTS_Check_VisitorDtls", par);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDistrictMst()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    return SQLHelper.ExecuteDataset(con, CommandType.StoredProcedure, "sp_ITPRO_Get_DistMaster");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetMandalMst(string DistId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[1];
                    par[0] = new SqlParameter("@DistId", DistId);
                    return SQLHelper.ExecuteDataset(con, CommandType.StoredProcedure, "sp_ITPRO_Get_MandalMaster", par);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetVillageMst(string DistId, string MandalId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[2];
                    par[0] = new SqlParameter("@DistId", DistId);
                    par[1] = new SqlParameter("@MandalId", MandalId);
                    return SQLHelper.ExecuteDataset(con, CommandType.StoredProcedure, "sp_ITPRO_Get_VillageMaster", par);
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
        public List<PROMasterBO> GetMaster(int MasterType, string strDistId, string strMandalId)
        {
            try
            {
                List<PROMasterBO> objPROMasterBOList = new List<PROMasterBO>();
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[3];
                    par[0] = new SqlParameter("@MasterType", MasterType);
                    par[1] = new SqlParameter("@DistId", strDistId);
                    par[2] = new SqlParameter("@MandalId", strMandalId);

                    using (SqlDataReader dr = SQLHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_ITPRO_Get_Master", par))
                    {
                        while (dr.Read())
                        {
                            PROMasterBO objPROMasterBO = new PROMasterBO();
                            objPROMasterBO.ID = SQLHelper.CheckStringNull(dr["ID"]);
                            objPROMasterBO.Name = SQLHelper.CheckStringNull(dr["Name"]);
                            objPROMasterBO.Description = SQLHelper.CheckStringNull(dr["Description"]);
                            objPROMasterBO.CreatedBy = SQLHelper.CheckStringNull(dr["CreatedBy"]);
                            objPROMasterBO.CreatedDate = Convert.ToDateTime(SQLHelper.CheckDateNull(dr["CreatedDate"]));
                            objPROMasterBO.ModifiedBy = SQLHelper.CheckStringNull(dr["ModifiedBy"]);
                            objPROMasterBO.ModifiedDate = Convert.ToDateTime(SQLHelper.CheckDateNull(dr["ModifiedDate"]));
                            objPROMasterBOList.Add(objPROMasterBO);
                        }
                    }
                }
                return objPROMasterBOList;
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
