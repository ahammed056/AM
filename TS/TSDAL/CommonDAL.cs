using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.Diagnostics;
using System.Data.SqlClient;
using TSEntity;
using TSUtility;

namespace TSDAL
{
    public class CommonDAL
    {

        #region [ Contructors ]

        public CommonDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region [ Methods ]

        #region [ Exception ]

        /// <summary>
        /// "Author : Bhanuprakash"
        /// "Create date : 02-Aug-2013"
        /// "Description : Insert the error information to the database/log file including name of the file, line number & error message description"
        /// </summary>
        /// <param name="Exception">exception</param>
        public static void SaveException(Exception exception)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[9];

                    //Get a StackTrace object for the exception
                    var stackTrace = new StackTrace(exception, true);
                    //Get StackFrames
                    var stackFrames = stackTrace.GetFrames()
                                  .Select(frame => new
                                  {
                                      FileName = frame.GetFileName(),               //File name
                                      LineNumber = frame.GetFileLineNumber(),       //Line number
                                      ColumnNumber = frame.GetFileColumnNumber(),   //Column number
                                      Method = frame.GetMethod().Name,              //Method name
                                      Class = frame.GetMethod().DeclaringType,      //Class name
                                  });

                    foreach (var stackFrame in stackFrames)
                    {
                        if (stackFrame.FileName != null)
                        {
                            try
                            {
                                par[0] = new SqlParameter("@FileName", stackFrame.FileName.ToString());
                                par[1] = new SqlParameter("@Method", stackFrame.Method.ToString());
                                par[2] = new SqlParameter("@LineNumber", int.Parse(stackFrame.LineNumber.ToString()));
                                par[3] = new SqlParameter("@ColumnNumber", int.Parse(stackFrame.ColumnNumber.ToString()));
                                par[4] = new SqlParameter("@Class", stackFrame.Class.ToString());
                                par[5] = new SqlParameter("@Exception", exception.Message);
                                par[6] = new SqlParameter("@InnerException", exception.ToString());
                                par[7] = new SqlParameter("@HostName", SessionVariables.HostName);
                                par[8] = new SqlParameter("@CreatedBy", SessionVariables.UserID);
                                SQLHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "sp_Exception_Insert_Tracker", par);
                            }
                            catch (Exception)
                            {
                                par[0] = new SqlParameter("@FileName", string.Empty);
                                par[1] = new SqlParameter("@Method", stackFrame.Method.ToString());
                                par[2] = new SqlParameter("@LineNumber", 0);
                                par[3] = new SqlParameter("@ColumnNumber", 0);
                                par[4] = new SqlParameter("@Class", string.Empty);
                                par[5] = new SqlParameter("@Exception", exception.Message);
                                par[6] = new SqlParameter("@InnerException", exception.ToString());
                                par[7] = new SqlParameter("@HostName", SessionVariables.HostName);
                                par[8] = new SqlParameter("@CreatedBy", SessionVariables.UserID);
                                SQLHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "sp_Exception_Insert_Tracker", par);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("RM Solution", "Log File Path : " + ex.ToString());
            }
        }

        #endregion

        #region [ User Login Info ]

        /// <summary>
        /// "Author : Bhanuprakash"
        /// "Create date : 02-Aug-2013"
        /// "Description : Insert the error information to the database/log file including name of the file, line number & error message description"
        /// </summary>
        /// <param name="Exception">exception</param>
        public static void SaveUserLoginInfo()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[5];

                    par[0] = new SqlParameter("@UserID", SessionVariables.UserID);
                    par[1] = new SqlParameter("@UserName", SessionVariables.UserName);
                    par[2] = new SqlParameter("@GroupID", SessionVariables.GroupID);
                    par[3] = new SqlParameter("@GroupName", SessionVariables.GroupName);
                    par[4] = new SqlParameter("@HostName", SessionVariables.HostName);
                    SQLHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "sp_UserLogin_Insert_Tracker", par);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// "Author : Bhanuprakash"
        /// "Create date : 02-Aug-2013"
        /// "Description : Insert the error information to the database/log file including name of the file, line number & error message description"
        /// </summary>
        /// <param name="Exception">exception</param>
        public static void UpdateUserLoginInfo()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[3];

                    par[0] = new SqlParameter("@UserID", SessionVariables.UserID);
                    par[1] = new SqlParameter("@GroupID", SessionVariables.GroupID);
                    par[2] = new SqlParameter("@HostName", SessionVariables.HostName);
                    SQLHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "sp_UserLogin_Update_Tracker", par);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        /// <summary>
        /// Get all records from database
        /// </summary>
        /// <param name="objITDCSCMDBBO"></param>
        /// <returns></returns>
        public DataSet GetCMDBInstancesByModule(string Module, string IPAddress, string Hostname)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(SQLHelper.GetConnectionString()))
                {
                    SqlParameter[] par = new SqlParameter[3];

                    par[0] = new SqlParameter("@Module", Module);
                    par[1] = new SqlParameter("@IPAddress", IPAddress);
                    par[2] = new SqlParameter("@Hostname", Hostname);

                    return SQLHelper.ExecuteDataset(con, CommandType.StoredProcedure, "sp_Get_CMDBData_By_Module", par);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}
